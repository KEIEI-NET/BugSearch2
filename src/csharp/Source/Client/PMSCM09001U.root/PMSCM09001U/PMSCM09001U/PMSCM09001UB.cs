//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : SCM�i�ڐݒ�}�X�^�����e�i���X
// �v���O�����T�v   : SCM�i�ڐݒ�}�X�^�̑�����s���܂�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��� ���b
// �� �� ��  2009/05/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �r�b�l�i�ڐݒ�}�X�^�����e�i���X�ҏW�t�H�[��
    /// </summary>
    /// <remarks>
    /// <br>Note       : �r�b�l�i�ڐݒ�}�X�^�̓��͂��s���܂��B</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2009.05.18</br>
    /// <br>Update Note: </br>
    /// <br></br>
    /// </remarks>
    public partial class PMSCM09001UB : System.Windows.Forms.Form
    {
        #region Private Menbers

        private string _enterpriseCode;         // ��ƃR�[�h

        // �t�h�z�u�p�i�J�n�ʒu�j
        private const int ct_PositionStart = 105;
        // �t�h�z�u�p�i�Ԋu�j
        private const int ct_Interval = 4;


        // SCM�i�ڐݒ�A�N�Z�X�N���X
        private SCMPrtSettingAcs _scmPrtSettingAcs;
        // SCM�i�ڐݒ�}�X�����p�K�C�h����N���X
        private SCMPrtSettingGuideControl _guideControl;

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
        // ���i�ԍ��i�O��l�j
        private string _prevGoodsNo;
        
        // �O���[�v�R�[�h�i�ޔ�p�j
        private int _blGroupCode;


        // �ҏW�����R�[�hGUID
        private Guid _recordGuid;
        // �ҏW�����R�[�h
        private SCMPrtSetting _scmPrtSetting;

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        // �I�����̕ҏW�`�F�b�N�p
        private SCMPrtSetting _recordClone;


        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        private const string DELETE_DATE_TITLE = "�폜��";
        private const string SECTIONCODE_TITLE = "���_�R�[�h";
        private const string SECTIONGUIDENM_TITLE = "���_��";
        private const string SUBSECTIONCODE_TITLE = "SCM�i�ڐݒ�R�[�h";
        private const string SUBSECTIONNAME_TITLE = "SCM�i�ڐݒ薼";

        // ��ʃ��C�A�E�g�p�萔
        private const int BUTTON_LOCATION1_X = 196;     // ���S�폜�{�^���ʒuX
        private const int BUTTON_LOCATION2_X = 323;     // �����{�^���ʒuX
        private const int BUTTON_LOCATION3_X = 450;     // �ۑ��{�^���ʒuX
        private const int BUTTON_LOCATION4_X = 577;     // ����{�^���ʒuX
        private const int BUTTON_LOCATION_Y = 8;        // �{�^���ʒuY(����)

        // Message�֘A��`
        private const string ASSEMBLY_ID = "DCKHN09010U";
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string ERR_DPR_MSG = "���͂��ꂽ�i�ڐݒ�͊��ɓo�^����Ă��܂��B�ҏW���s���܂����H";
        private const string ERR_RDEL_MSG = "�폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂�";

        #endregion


        # region Constructor

        /// <summary>
        /// �r�b�l�i�ڐݒ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        public PMSCM09001UB( SCMPrtSettingAcs scmPrtSettingAcs, SCMPrtSettingGuideControl scmPrtSettingGuideControl )
        {
            InitializeComponent();

            // �e��C���X�^���X���󂯎��
            _scmPrtSettingAcs = scmPrtSettingAcs;
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
            _blGroupCode = 0;
            // ���i�ԍ��i�O��l�j
            _prevGoodsNo = string.Empty;

            // �ҏW�����R�[�h��GUID�ƃ��R�[�h
            _recordGuid = Guid.Empty;
            _scmPrtSetting = null;
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
            _prevGoodsMakerCd = 0;
            _prevGoodsMGroup = 0;
            _prevBLGoodsCode = 0;
            _prevGoodsNo = string.Empty;

            _blGroupCode = 0;

            // ���̍Ď擾
            // ���_
            MasterRead( ref tEdit_SectionCodeAllowZero, ref tEdit_SectionGuideNm, ref _prevSectionCode, ReadSection );
            // ���Ӑ�
            MasterRead( ref tNedit_CustomerCode, ref tEdit_CustomerName, ref _prevCustomerCode, ReadCustomer );
            // ���[�J�[
            MasterRead( ref tNedit_GoodsMakerCd, ref tEdit_GoodsMakerName, ref _prevGoodsMakerCd, ReadMaker );
            // ���i������
            MasterRead( ref tNedit_GoodsMGroup, ref tEdit_GoodsMGroupName, ref _prevGoodsMGroup, ReadGoodsMGroup );
            // �a�k�R�[�h
            MasterRead( ref tNedit_BLGoodsCode, ref tEdit_BLCodeName, ref _prevBLGoodsCode, ReadBLCode );
            if ( _prevBLGoodsCode == 0 ) _blGroupCode = 0;
            // �i�ԁ����i
            ReadGoods();
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
                    panel_Customer.Visible = false;
                    panel_Line.Visible = false;
                    break;
                // 1:���_
                case 1:
                    panel_Section.Visible = true;
                    panel_Customer.Visible = false;
                    panel_Line.Visible = true;

                    panel_Section.Top = currPosition;
                    currPosition += panel_Section.Height + ct_Interval;
                    panel_Line.Top = currPosition;
                    currPosition += panel_Line.Height + ct_Interval;
                    break;
                // 2:���Ӑ�
                case 2:
                    panel_Section.Visible = false;
                    panel_Customer.Visible = true;
                    panel_Line.Visible = true;

                    panel_Customer.Top = currPosition;
                    currPosition += panel_Customer.Height + ct_Interval;
                    panel_Line.Top = currPosition;
                    currPosition += panel_Line.Height + ct_Interval;
                    break;
            }


            // �N���A
            if ( panel_Section.Visible == false )
            {
                ClearEditOnPanel( panel_Section );
                _prevSectionCode = string.Empty;
            }
            else
            {
                string sectionCode = tEdit_SectionCodeAllowZero.Text.Trim();
                if ( sectionCode == string.Empty || sectionCode == "00" )
                {
                    tEdit_SectionCodeAllowZero.Text = "00";
                    tEdit_SectionGuideNm.Text = "�S��";
                }
            }
            if ( panel_Customer.Visible == false)
            { 
                ClearEditOnPanel( panel_Customer );
                _prevCustomerCode = 0;
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
            //if ( panel_Line.Visible )
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
            bool goodsMakerEnabled = false;
            bool goodsMGroupEnabled = false;
            bool goodsNoEnabled = false;

            // ���[�J�[,������,�a�k�R�[�h,�i��
            switch ( (int)tComboEditor_SetKind2.Value )
            {
                // 0:���[�J�[
                default:
                case 0:
                    goodsMakerEnabled = true;
                    break;
                // 1:���[�J�[�{������
                case 1:
                    goodsMakerEnabled = true;
                    goodsMGroupEnabled = true;
                    break;
                // 2:���[�J�[�{�a�k�R�[�h
                case 2:
                    goodsMakerEnabled = true;
                    blCodeEnabled = true;
                    break;
                // 3:���[�J�[�{�i��
                case 3:
                    goodsMakerEnabled = true;
                    goodsNoEnabled = true;
                    break;
            }
            # endregion

            # region [�R���g���[���̔z�u]
            // ���[�J�[
            if ( goodsMakerEnabled )
            {
                panel_GoodsMaker.Top = currPosition;
                currPosition += panel_GoodsMaker.Height + ct_Interval;
            }
            panel_GoodsMaker.Enabled = goodsMakerEnabled;
            panel_GoodsMaker.Visible = goodsMakerEnabled;

            // �a�k�R�[�h
            if ( blCodeEnabled )
            {
                panel_BLCode.Top = currPosition;
                currPosition += panel_BLCode.Height + ct_Interval;
            }
            panel_BLCode.Enabled = blCodeEnabled;
            panel_BLCode.Visible = blCodeEnabled;
            
            // ���i������
            if ( goodsMGroupEnabled )
            {
                panel_GoodsMGroup.Top = currPosition;
                currPosition += panel_GoodsMGroup.Height + ct_Interval;
            }
            panel_GoodsMGroup.Enabled = goodsMGroupEnabled;
            panel_GoodsMGroup.Visible = goodsMGroupEnabled;
            
            // �i��
            if ( goodsNoEnabled )
            {
                panel_GoodsNo.Top = currPosition;
                currPosition += panel_GoodsNo.Height + ct_Interval;
            }
            panel_GoodsNo.Enabled = goodsNoEnabled;
            panel_GoodsNo.Visible = goodsNoEnabled;

            // �����񓚋敪
            panel_AutoAnswerDiv.Top = currPosition;
            # endregion

            # region [�p�l�����̃N���A]
            // �p�l�����N���A
            if ( panel_BLCode.Enabled == false )
            {
                ClearEditOnPanel( panel_BLCode );
                _prevBLGoodsCode = 0;
                _blGroupCode = 0;
            }
            if ( panel_GoodsMaker.Enabled == false )
            {
                ClearEditOnPanel( panel_GoodsMaker );
                _prevGoodsMakerCd = 0;
            }
            if ( panel_GoodsMGroup.Enabled == false )
            {
                ClearEditOnPanel( panel_GoodsMGroup );
                _prevGoodsMGroup = 0;
            }
            if ( panel_GoodsNo.Enabled == false )
            {
                ClearEditOnPanel( panel_GoodsNo );
                _prevGoodsNo = string.Empty;
            }
            # endregion
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
        private delegate bool MasterReadForNumber( ref int code, out string name );
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
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
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            if ( this.RecordGuid == null || this.RecordGuid == Guid.Empty )
            {
                // �V�K
                _scmPrtSetting = new SCMPrtSetting();
                ScreenInputPermissionControl( 0 );
            }
            else
            {
                // ���R�[�h�擾
                _scmPrtSetting = _scmPrtSettingAcs.GetRecordForMaintenance( this.RecordGuid );

                if ( _scmPrtSetting.LogicalDeleteCode == 0 )
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
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="setType">�ݒ�^�C�v 0:�e-�V�K, 1:�e-�X�V, 2:�e-�폜, 3:�q-�V�K, 4:�q-�X�V, 5:�q-�폜</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
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
                    this.panel_GoodsNo.Enabled = true;
                    this.panel_AutoAnswerDiv.Enabled = true;

                    break;
                // 1:�X�V
                case 1:
                    // �ݒ��ʎ擾
                    GetSetKind( _scmPrtSetting, out setKind1, out setKind2 );
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
                    this.panel_GoodsNo.Enabled = false;
                    this.panel_AutoAnswerDiv.Enabled = true;

                    break;
                // 2:�폜
                case 2:
                    // �ݒ��ʎ擾
                    GetSetKind( _scmPrtSetting, out setKind1, out setKind2 );
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
                    this.panel_GoodsNo.Enabled = false;
                    this.panel_AutoAnswerDiv.Enabled = false;

                    break;
            }
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if ( _scmPrtSetting == null || _scmPrtSetting.FileHeaderGuid == null || _scmPrtSetting.FileHeaderGuid == Guid.Empty )
            {
                //---------------------------------------------
                // �V�K
                //---------------------------------------------
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓW�J����
                RecordToScreen( _scmPrtSetting );

                // �N���[���쐬
                this._recordClone = _scmPrtSetting.Clone();
                DispToRecord( ref this._recordClone );
            }
            else if ( _scmPrtSetting.LogicalDeleteCode == 0 )
            {
                //---------------------------------------------
                // �X�V
                //---------------------------------------------
                this.Mode_Label.Text = UPDATE_MODE;

                // ��ʓW�J����
                RecordToScreen( _scmPrtSetting );

                // �N���[���쐬
                this._recordClone = _scmPrtSetting.Clone();
                DispToRecord( ref this._recordClone );
            }
            else
            {
                //---------------------------------------------
                // �폜
                //---------------------------------------------
                this.Mode_Label.Text = DELETE_MODE;

                // ��ʓW�J����
                RecordToScreen( _scmPrtSetting );
            }
        }

        /// <summary>
        /// ���_�N���X��ʓW�J����
        /// </summary>
        /// <param name="secInfoSet">���_�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void SecInfoSetToScreen(SecInfoSet secInfoSet)
        {
            this.tEdit_SectionCodeAllowZero.Text     = secInfoSet.SectionCode;       // ���_�R�[�h
            this.tEdit_SectionGuideNm.Text  = secInfoSet.SectionGuideNm;    // ���_����
        }

        /// <summary>
        /// SCM�i�ڐݒ�N���X��ʓW�J����
        /// </summary>
        /// <param name="Subsection">SCM�i�ڐݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void RecordToScreen(SCMPrtSetting scmPrtSetting)
        {
            if ( scmPrtSetting.SectionCode.Trim() == "00" || scmPrtSetting.SectionCode.Trim() == string.Empty )
            {
                // ���_�R�[�h
                this.tEdit_SectionCodeAllowZero.Text = "00";
                // ���_��
                this.tEdit_SectionGuideNm.Text = "�S��";
            }
            else
            {
                // ���_�R�[�h
                this.tEdit_SectionCodeAllowZero.Text = scmPrtSetting.SectionCode.Trim();
                // ���_��
                this.tEdit_SectionGuideNm.Text = scmPrtSetting.SectionNm.Trim();
            }

            // ���Ӑ�R�[�h
            this.tNedit_CustomerCode.SetInt( scmPrtSetting.CustomerCode );

            // ���Ӑ於
            this.tEdit_CustomerName.Text = scmPrtSetting.CustomerName.Trim();

            // ���[�J�[�R�[�h
            this.tNedit_GoodsMakerCd.SetInt( scmPrtSetting.GoodsMakerCd );

            // ���[�J�[��
            this.tEdit_GoodsMakerName.Text = scmPrtSetting.MakerName.Trim();

            // ���i�����ރR�[�h
            this.tNedit_GoodsMGroup.SetInt( scmPrtSetting.GoodsMGroup );

            // ���i�����ޖ�
            this.tEdit_GoodsMGroupName.Text = scmPrtSetting.GoodsMGroupName.Trim();

            // �a�k�R�[�h
            this.tNedit_BLGoodsCode.SetInt( scmPrtSetting.BLGoodsCode );

            // �a�k�R�[�h��
            this.tEdit_BLCodeName.Text = scmPrtSetting.BLGoodsName.Trim();

            // �i��
            this.tEdit_GoodsNo.Text = scmPrtSetting.GoodsNo.Trim();

            // �i��
            this.tEdit_GoodsName_ReadOnly.Text = scmPrtSetting.GoodsName.Trim();

            // �����񓚋敪
            this.tComboEditor_AutoAnswerDiv.Value = scmPrtSetting.AutoAnswerDiv;
        }

        /// <summary>
        /// ��ʏ�񋒓_�N���X�i�[����
        /// </summary>
        /// <param name="secInfoSet">���_�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void DispToSecInfoSet(ref SecInfoSet secInfoSet)
        {
            secInfoSet.SectionCode      = this.tEdit_SectionCodeAllowZero.Text;      // ���_�R�[�h
            secInfoSet.SectionGuideNm   = this.tEdit_SectionGuideNm.Text;   // ���_����
            secInfoSet.EnterpriseCode   = this._enterpriseCode;             // ��ƃR�[�h
        }

        /// <summary>
        /// ��ʏ��SCM�i�ڐݒ�N���X�i�[����
        /// </summary>
        /// <param name="Subsection">SCM�i�ڐݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�SCM�i�ڐݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void DispToRecord( ref SCMPrtSetting scmPrtSetting )
        {
            // ��ƃR�[�h
            scmPrtSetting.EnterpriseCode = this._enterpriseCode;

            // ���_�R�[�h
            scmPrtSetting.SectionCode = this.GetDispValue( this.tEdit_SectionCodeAllowZero );
            // ���_��
            scmPrtSetting.SectionNm = this.GetDispValue( this.tEdit_SectionGuideNm );
            // ���Ӑ�R�[�h
            scmPrtSetting.CustomerCode = this.GetDispValue( this.tNedit_CustomerCode );
            // ���Ӑ於
            scmPrtSetting.CustomerName = this.GetDispValue( this.tEdit_CustomerName );
            // ���[�J�[�R�[�h
            scmPrtSetting.GoodsMakerCd = this.GetDispValue( this.tNedit_GoodsMakerCd );
            // ���[�J�[��
            scmPrtSetting.MakerName = this.GetDispValue( this.tEdit_GoodsMakerName );
            // ���i�����ރR�[�h
            scmPrtSetting.GoodsMGroup = this.GetDispValue( this.tNedit_GoodsMGroup );
            // ���i�����ޖ�
            scmPrtSetting.GoodsMGroupName = this.GetDispValue( this.tEdit_GoodsMGroupName );
            // �a�k�R�[�h
            scmPrtSetting.BLGoodsCode = this.GetDispValue( this.tNedit_BLGoodsCode );
            // �a�k�R�[�h��
            scmPrtSetting.BLGoodsName = this.GetDispValue( this.tEdit_BLCodeName );
            // �i��
            scmPrtSetting.GoodsNo = this.GetDispValue( this.tEdit_GoodsNo );
            // �i��
            scmPrtSetting.GoodsName = this.GetDispValue( this.tEdit_GoodsName_ReadOnly );
            // �����񓚋敪
            scmPrtSetting.AutoAnswerDiv = (int)this.tComboEditor_AutoAnswerDiv.Value;

            // �O���[�v�R�[�h
            scmPrtSetting.BLGroupCode = _blGroupCode;
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
        /// ��ʓ��͏��s���`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note		: ��ʓ��͏��̕s���`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private bool ScreenDataCheck( ref Control control, ref string message )
        {
            bool result = true;

            // ���͍��ڈꗗ
            List<Control> ctrlList = new List<Control>();
            ctrlList.Add(tEdit_SectionCodeAllowZero);
            ctrlList.Add(tNedit_CustomerCode);
            ctrlList.Add(tNedit_GoodsMakerCd);
            ctrlList.Add(tNedit_GoodsMGroup);
            ctrlList.Add(tNedit_BLGoodsCode);
            ctrlList.Add(tEdit_GoodsNo);

            // ���b�Z�[�W�ꗗ
            Dictionary<string, string> messageList = new Dictionary<string, string>();
            messageList.Add( tEdit_SectionCodeAllowZero.Name, "���_�R�[�h" );
            messageList.Add( tNedit_CustomerCode.Name, "���Ӑ�R�[�h" );
            messageList.Add( tNedit_GoodsMakerCd.Name, "���[�J�[�R�[�h" );
            messageList.Add( tNedit_GoodsMGroup.Name, "���i�����ރR�[�h" );
            messageList.Add( tNedit_BLGoodsCode.Name, "�a�k�R�[�h" );
            messageList.Add( tEdit_GoodsNo.Name, "�i��" );


            // �\������Ă��ē��͉\�ȑS�Ă̍��ڂ͕K�{���́B
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
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

            return true;
        }

        /// <summary>
        /// SCM�i�ڐݒ�e�[�u���X�V
        /// </summary>
        /// <return>�X�V����status</return>
        /// <remarks>
        /// <br>Note       : Subsection�e�[�u���̍X�V���s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private bool SaveRecord()
        {
            // �o�^���R�[�h���擾(�ύX�O)
            if ( _scmPrtSetting == null || _scmPrtSetting.FileHeaderGuid == Guid.Empty )
            {
                _scmPrtSetting = _scmPrtSettingAcs.GetRecordForMaintenance( _recordGuid );
            }

            // �t�h����f�[�^�擾
            DispToRecord( ref _scmPrtSetting );
            ArrayList writeList = new ArrayList();
            writeList.Add( _scmPrtSetting );

            // �X�V
            string msg;
            int status = _scmPrtSettingAcs.Write( ref writeList, out msg );

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
                    ExclusiveTransaction( status, TMsgDisp.OPE_UPDATE, this._scmPrtSettingAcs );
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
                        this._scmPrtSettingAcs,				    // �G���[�����������I�u�W�F�N�g
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
        /// SCM�i�ڐݒ� �_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : SCM�i�ڐݒ�̑Ώۃ��R�[�h���}�X�^����_���폜���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private int LogicalDeleteSubsection()
        {
            int status = 0;

            return status;
        }

        /// <summary>
        /// SCM�i�ڐݒ� �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : SCM�i�ڐݒ�̑Ώۃ��R�[�h���}�X�^���畨���폜���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private int PhysicalDeleteRecord()
        {
            int status = 0;


            // �o�^���R�[�h���擾(�ύX�O)
            if ( _scmPrtSetting == null || _scmPrtSetting.FileHeaderGuid == Guid.Empty )
            {
                _scmPrtSetting = _scmPrtSettingAcs.GetRecordForMaintenance( _recordGuid );
            }
            ArrayList writeList = new ArrayList();
            writeList.Add( _scmPrtSetting );

            // �����폜
            string msg;
            status = _scmPrtSettingAcs.Delete( ref writeList, out msg );

            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction( status, TMsgDisp.OPE_DELETE, this._scmPrtSettingAcs );
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
                        this._scmPrtSettingAcs,					// �G���[�����������I�u�W�F�N�g
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
        /// ���_ ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : SCM�i�ڐݒ�̑Ώۃ��R�[�h�𕜊����܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private int ReviveRecord()
        {
            int status = 0;

                // �o�^���R�[�h���擾(�ύX�O)
                if ( _scmPrtSetting == null || _scmPrtSetting.FileHeaderGuid == Guid.Empty )
                {
                    _scmPrtSetting = _scmPrtSettingAcs.GetRecordForMaintenance( _recordGuid );
                }
                ArrayList writeList = new ArrayList();
                writeList.Add( _scmPrtSetting );


                string msg;
                status = this._scmPrtSettingAcs.Revival( ref writeList, out msg );


                switch ( status )
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        // �r������
                        ExclusiveTransaction( status, TMsgDisp.OPE_UPDATE, this._scmPrtSettingAcs );
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
                            this._scmPrtSettingAcs,					// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1 );	// �����\���{�^��
                        return status;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            return status;
        }

        /// <summary>
        /// �V�K�o�^������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�K�o�^���̏������s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void NewEntryTransaction()
        {
            // �V�K���[�h�̏ꍇ�͉�ʂ��I�������ɘA�����͂��\�Ƃ���
            if ( this.Mode_Label.Text == INSERT_MODE )
            {
                // �N���[���쐬
                this._recordClone = _scmPrtSetting.Clone();

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
        /// UI�q��ʋ����I������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V�G���[����UI�q��ʋ����I���������s���܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
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
                _scmPrtSetting = new SCMPrtSetting();
                DispToRecord( ref _scmPrtSetting );
                int retStatus = _scmPrtSettingAcs.Read( ref _scmPrtSetting );

                // ��ʃN���A����
                ScreenClear();
                
                if ( retStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if ( _scmPrtSetting.LogicalDeleteCode == 0 )
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
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
        # endregion

        # region Control Events

        /// <summary>
        /// Form.Load �C�x���g(MAKHN09230U)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void PMSCM09001UB_Load(object sender, System.EventArgs e)
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
            
            // �����t�H�[�J�X
            this.tComboEditor_SetKind1.Focus();
        }

        /// <summary>
        /// Form.Closing �C�x���g(MAKHN09230UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�������O�ɁA���[�U�[���t�H�[������悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void PMSCM09001UB_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        /// <summary>
        /// Control.VisibleChanged �C�x���g(MAKHN09230UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �t�H�[���̕\����Ԃ��ς�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void PMSCM09001UB_VisibleChanged(object sender, System.EventArgs e)
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            bool cloneFlg = true;

            // �폜���[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if ( this.Mode_Label.Text != DELETE_MODE )
            {
                // ���݂̉�ʏ����擾
                SCMPrtSetting scmPrtSetting = new SCMPrtSetting();
                scmPrtSetting = this._recordClone.Clone();
                DispToRecord( ref scmPrtSetting );
                // �ŏ��Ɏ擾������ʏ��Ɣ�r
                cloneFlg = this._recordClone.Equals( scmPrtSetting );


                if ( !(cloneFlg) )
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

            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
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
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2009/05/11</br>
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
        /// <br>Programmer : 22018 ��� ���b</br>
        /// <br>Date       : 2008.06.04</br>
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
        /// <br>Programmer	: 22018�@��� ���b</br>
        /// <br>Date		: 2009/05/11</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            //_modeFlg = false;
        
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
                        MasterRead(ref tNedit_CustomerCode, ref tEdit_CustomerName, ref _prevCustomerCode, ReadCustomer, ref e, "���Ӑ�" );
                    }
                    break;
                // ���[�J�[
                case "tNedit_GoodsMakerCd":
                    {
                        int makerCdBackup = _prevGoodsMakerCd;
                        MasterRead(ref tNedit_GoodsMakerCd, ref tEdit_GoodsMakerName, ref _prevGoodsMakerCd, ReadMaker, ref e, "���[�J�[" );

                        // ���i�Ď擾
                        if ( this.tEdit_GoodsNo.Text.Trim() != string.Empty )
                        {
                            // ��������ׁ̈A�ꎞ�I�ɖ߂��܂�
                            _prevGoodsMakerCd = makerCdBackup;
                            ReadGoods( ref e );
                        }
                    }
                    break;
                // ���i������
                case "tNedit_GoodsMGroup":
                    {
                        MasterRead(ref tNedit_GoodsMGroup, ref tEdit_GoodsMGroupName, ref _prevGoodsMGroup, ReadGoodsMGroup, ref e, "���i������" );
                    }
                    break;
                // �a�k�R�[�h
                case "tNedit_BLGoodsCode":
                    {
                        MasterRead( ref tNedit_BLGoodsCode, ref tEdit_BLCodeName, ref _prevBLGoodsCode, ReadBLCode, ref e, "�a�k�R�[�h" );
                        if ( _prevBLGoodsCode == 0 ) _blGroupCode = 0;
                    }
                    break;
                // �i��
                case "tEdit_GoodsNo":
                    {
                        ReadGoods( ref e );

                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
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
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD
                    }
                    break;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
                case "tComboEditor_AutoAnswerDiv":
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
                    break;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD
                default:
                    break;
            }
        }

        /// <summary>
        /// �e��}�X�^�ǂݍ��݋��ʏ����i���l�R�[�h�p�j
        /// </summary>
        /// <param name="tNedit"></param>
        /// <param name="tEdit"></param>
        /// <param name="e"></param>
        /// <param name="proc"></param>
        /// <param name="masterName"></param>
        private void MasterRead(ref TNedit codeEdit, ref TEdit nameEdit, ref int prevCode, MasterReadForNumber proc, ref ChangeFocusEventArgs e, string masterName )
        {
            int code = codeEdit.GetInt();

            if ( code != 0 )
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
                    codeEdit.SetInt( code );
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
                codeEdit.SetInt( 0 );
                nameEdit.Text = string.Empty;
                prevCode = 0;
            }

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
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
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD
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

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
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
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD
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
        private void MasterRead( ref TEdit codeEdit, ref TEdit nameEdit, ref string prevCode, MasterReadForText proc )
        {
            string code = codeEdit.Text.Trim();

            if ( code != string.Empty )
            {
                string name;
                bool status = proc( ref code, out name );

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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SetKind1_ValueChanged( object sender, EventArgs e )
        {
            DrawPanelsBySetKind1();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tComboEditor_SetKind2_ValueChanged( object sender, EventArgs e )
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
                    this.tNedit_GoodsMGroup.SetInt( goodsMGroup.GoodsMGroup );
                    this.tEdit_GoodsMGroupName.Text = goodsMGroup.GoodsMGroupName;
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
                    _prevBLGoodsCode = bLGoodsCdUMnt.BLGoodsCode;

                    _blGroupCode = bLGoodsCdUMnt.BLGloupCode;

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
            MakerUMnt maker;
            int status = _guideControl.MakerAcs.Read( out maker, this._enterpriseCode, code );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && maker != null )
            {
                name = maker.MakerName;
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
        /// ���i�����ޖ��擾
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool ReadGoodsMGroup( ref int code, out string name )
        {
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
        private bool ReadBLCode( ref int code, out string name )
        {
            BLGoodsCdUMnt blGoodsCdUMnt;
            int status = _guideControl.BLGoodsCdAcs.Read( out blGoodsCdUMnt, _enterpriseCode, code );

            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && blGoodsCdUMnt != null )
            {
                name = blGoodsCdUMnt.BLGoodsFullName;
                _blGroupCode = blGoodsCdUMnt.BLGloupCode;
                return true;
            }
            else
            {
                code = 0;
                name = string.Empty;
                _blGroupCode = 0;

                return false;
            }
        }

        /// <summary>
        /// ���i���@�擾����
        /// </summary>
        private void ReadGoods( ref ChangeFocusEventArgs e )
        {
            // ��ʓ��͂̎擾
            int makerCode = this.tNedit_GoodsMakerCd.GetInt();
            string makerName = tEdit_GoodsMakerName.Text.Trim();
            string goodsNo = this.tEdit_GoodsNo.Text.Trim();
            string goodsName = string.Empty;

            bool checkOK = false;

            if ( goodsNo != string.Empty )
            {
                if ( goodsNo != _prevGoodsNo || makerCode != _prevGoodsMakerCd )
                {
                    # region [���o����]
                    GoodsCndtn cndtn = new GoodsCndtn();
                    cndtn.EnterpriseCode = this._enterpriseCode;
                    cndtn.GoodsMakerCd = makerCode;
                    cndtn.GoodsNo = goodsNo;
                    cndtn.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
                    cndtn.PriceApplyDate = DateTime.Today;
                    # endregion

                    // �������s
                    List<GoodsUnitData> goodsUnitDataList;
                    string msg;
                    int status = this._guideControl.GoodsAcs.SearchPartsFromGoodsNoNonVariousSearch( cndtn, out goodsUnitDataList, out msg );

                    # region [���ʎ擾�Ɣ��f]
                    // ���ʎ擾
                    if ( status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL )
                    {
                        // �L�����Z����
                        goodsNo = string.Empty;
                        goodsName = string.Empty;

                        _prevGoodsNo = string.Empty;

                        checkOK = false;
                    }
                    else if ( goodsUnitDataList.Count > 0 )
                    {
                        // �ʏ�
                        GoodsUnitData goodsUnitData = goodsUnitDataList[0];
                        makerCode = goodsUnitData.GoodsMakerCd;
                        makerName = goodsUnitData.MakerName;
                        goodsNo = goodsUnitData.GoodsNo;
                        goodsName = goodsUnitData.GoodsName;

                        checkOK = true;
                    }
                    else
                    {
                        // �G���[���b�Z�[�W
                        TMsgDisp.Show( this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���i�����݂��܂���B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK );				// �\������{�^��


                        goodsNo = string.Empty;
                        goodsName = string.Empty;

                        checkOK = false;
                    }


                    // �t�h�\��
                    tNedit_GoodsMakerCd.SetInt( makerCode );
                    tEdit_GoodsMakerName.Text = makerName;
                    tEdit_GoodsNo.Text = goodsNo;
                    tEdit_GoodsName_ReadOnly.Text = goodsName;

                    // �O����͂Ƃ��đޔ�
                    _prevGoodsMakerCd = makerCode;
                    _prevGoodsNo = goodsNo;
                    # endregion
                }
                else
                {
                    // �i�ԁE���[�J�[���ς��Ȃ���Ζ�������
                    checkOK = true;
                }
            }
            else
            {
                // ���̓N���A�i�i�ԁE�i���̂݁j
                tEdit_GoodsNo.Text = string.Empty;
                tEdit_GoodsName_ReadOnly.Text = string.Empty;

                _prevGoodsNo = string.Empty;

                checkOK = true;
            }

            if ( checkOK )
            {
            }
            else
            {
                e.NextCtrl = e.PrevCtrl;
            }
        }
        /// <summary>
        /// ���i�ǂݍ���
        /// </summary>
        private void ReadGoods()
        {
            int makerCd = this.tNedit_GoodsMakerCd.GetInt();
            string goodsNo = this.tEdit_GoodsNo.Text.Trim();

            if ( goodsNo != string.Empty && makerCd != 0 )
            {
                GoodsUnitData goodsUnitData;
                int status = this._guideControl.GoodsAcs.Read( this._enterpriseCode, makerCd, goodsNo, out goodsUnitData );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    tEdit_GoodsNo.Text = goodsUnitData.GoodsNo;
                    tEdit_GoodsName_ReadOnly.Text = goodsUnitData.GoodsName;

                    _prevGoodsNo = goodsUnitData.GoodsNo;
                }
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
                case "tComboEditor_SetKind2":
                    nextControl = tEdit_SectionCodeAllowZero;
                    break;
                case "tEdit_SectionCodeAllowZero":
                    nextControl = tNedit_CustomerCode;
                    break;
                case "tNedit_CustomerCode":
                    nextControl = tNedit_GoodsMakerCd;
                    break;
                case "tNedit_GoodsMakerCd":
                    nextControl = tNedit_GoodsMGroup;
                    break;
                case "tNedit_GoodsMGroup":
                    nextControl = tNedit_BLGoodsCode;
                    break;
                case "tNedit_BLGoodsCode":
                    nextControl = tEdit_GoodsNo;
                    break;
                default:
                    nextControl = tComboEditor_AutoAnswerDiv;
                    break;
            }

            // ���͕s�Ȃ�ċA�I�Ɏ擾
            if ( !nextControl.Enabled || !nextControl.Visible )
            {
                nextControl = GetNextEdit( nextControl );
            }

            // �ԋp
            return nextControl;
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/27 ADD
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
                case "tComboEditor_AutoAnswerDiv":
                    prevControl = tEdit_GoodsNo;
                    break;
                case "tEdit_GoodsNo":
                    prevControl = tNedit_BLGoodsCode;
                    break;
                case "tNedit_BLGoodsCode":
                    prevControl = tNedit_GoodsMGroup;
                    break;
                case "tNedit_GoodsMGroup":
                    prevControl = tNedit_GoodsMakerCd;
                    break;
                case "tNedit_GoodsMakerCd":
                    prevControl = tNedit_CustomerCode;
                    break;
                case "tNedit_CustomerCode":
                    prevControl = tEdit_SectionCodeAllowZero;
                    break;
                case "tEdit_SectionCodeAllowZero":
                    prevControl = tComboEditor_SetKind2;
                    break;
                case "tComboEditor_SetKind2":
                    prevControl = tComboEditor_SetKind1;
                    break;
                default:
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/28 DEL
                    //prevControl = tComboEditor_AutoAnswerDiv;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/28 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/28 ADD
                    prevControl = Cancel_Button;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/28 ADD
                    break;
            }

            // ���͕s�Ȃ�ċA�I�Ɏ擾
            if ( !prevControl.Enabled || !prevControl.Visible )
            {
                prevControl = GetPrevEdit( prevControl );
            }

            // �O���ڂ̓��̓`�F�b�N
            if ( prevControl != null )
            {
                if ( prevControl is TNedit )
                {
                    if ( (prevControl as TNedit).GetInt() == 0 )
                    {
                        prevControl = null;
                    }
                }
                else if ( prevControl is TEdit )
                {
                    if ( (prevControl as TEdit).Text.Trim() == string.Empty )
                    {
                        prevControl = null;
                    }
                }
            }

            // �ԋp
            return prevControl;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/27 ADD

        /// <summary>
        /// �ݒ��ʂP�E�Q�擾����
        /// </summary>
        /// <param name="scmPrtSetting"></param>
        /// <param name="setKind1"></param>
        /// <param name="setKind2"></param>
        private void GetSetKind( SCMPrtSetting scmPrtSetting, out int setKind1, out int setKind2 )
        {
            # region [�ݒ��ʂP]
            if ( scmPrtSetting.SectionCode == null || scmPrtSetting.SectionCode.Trim() != string.Empty )
            {
                // 1:���_
                setKind1 = 1;
            }
            else if ( scmPrtSetting.CustomerCode != 0 )
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
            if ( scmPrtSetting.GoodsNo != string.Empty )
            {
                // 3:���[�J�[�{�i��
                setKind2 = 3;
            }
            else if ( scmPrtSetting.BLGoodsCode != 0 )
            {
                // 2:���[�J�[�{�a�k�R�[�h
                setKind2 = 2;
            }
            else if ( scmPrtSetting.GoodsMGroup != 0 )
            {
                // 1:���[�J�[�{���i������
                setKind2 = 1;
            }
            else
            {
                // 0:���[�J�[
                setKind2 = 0;
            }

            # endregion
        }

        # endregion
    }
}
