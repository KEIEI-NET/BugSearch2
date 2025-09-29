//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : SCM�D��ݒ�}�X�^
// �v���O�����T�v   : SCM�D��ݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
// Update Note      :    2011.08.08 lingxiaoqing                              //
//                  :    �D��ݒ�}�X�^������                                 // 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00    �쐬�S���F����R
// �C����    2011/09/07     �C�����e�F��Q�� #24169�@���_�ݒ���s�����Ƌ��_�K�C�h������ƑS�Ћ��ʂ̕ҏW���s�����Ƃ��Ă��܂��B
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@ ���_�R�[�h�Ƌ��_�K�C�h�̃t�H�[�J�X�ړ��̓��b�Z�[�W�\�����s��Ȃ��悤�ɏC��
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00    �쐬�S���Fwujun�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@   //
// �C����    2011/09/17     �C�����e�F�d�l�A�� #25263�@PCCUOE�^PM���@PCC�D��ݒ�}�X�^�̎d�l�ύX
// ---------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00    �쐬�S���Fliusy�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@   //
// �C����    2011/09/26     �C�����e�F�d�l�A�� #25492�@25263�ɖ߂�
// ---------------------------------------------------------------------------//
// �Ǘ��ԍ�  10904597-00    �쐬�S���F30744 ���� ����q                       //
// �C����    2013/12/16     �C�����e�FSCM�d�|�ꗗ��10590�Ή�                  //
//                                    ����ʂ̃I�u�W�F�N�g�ύX�ɂ��
//                                      �\�[�X�R�����g�́u�\�����v���u�����I�����v�ɕύX���܂�
//�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@���̑����̕ύX
// ---------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470103-00  �쐬�S�� : 杍^
// �� �� ��  2018/07/26   �C�����e : BL�p�[�c�I�[�_�[�����񓚕s��Ή�
//----------------------------------------------------------------------------//

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util; // ADD 2011/09/07

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// SCM�D��ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: SCM�D��ݒ���s���܂��B
    ///					  IMasterMaintenanceMultiType���������Ă��܂��B</br>   
    /// <br>Update Note:  2011.08.08 ������</br>
    /// <br>              �D��ݒ�}�X�^������</br>
    /// <br>Update Note : BL�p�[�c�I�[�_�[�����񓚕s��Ή�</br>
    /// <br>Programmer  : 杍^</br>
    /// <br>Date        : 2018/07/26</br>
    /// <br></br>
    /// </remarks>
    public class PMSCM09060UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
    {
        #region -- Component --

        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        //private Infragistics.Win.Misc.UltraLabel PriorPriceSetCd1_uLabel;
        //private Broadleaf.Library.Windows.Forms.TComboEditor PriorPriceSetCd1_tComboEditor;
        //private Infragistics.Win.Misc.UltraLabel PriorPriceSetCd2_uLabel;
        //private Broadleaf.Library.Windows.Forms.TEdit SectionName_tEdit;
        private Infragistics.Win.Misc.UltraLabel PriorPriceSetCd1_uLabel;
        private Infragistics.Win.Misc.UltraLabel PriorPriceSetCd2_uLabel;
        private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private System.Data.DataSet Bind_DataSet;
        private System.Windows.Forms.Timer Timer;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        //private Infragistics.Win.Misc.UltraLabel SalesSlipPrtDiv_uLabel;
        private Infragistics.Win.Misc.UltraLabel PriorPriceSetCd3_uLabel;
        // private TComboEditor PriorPriceSetCd3_tComboEditor;�@
        // private TComboEditor PriorPriceSetCd2_tComboEditor;
        //private TComboEditor PrioritySetting_tComboEditor;    
        private Infragistics.Win.Misc.UltraLabel DivideLine_Label;
        //private Infragistics.Win.Misc.UltraButton SectionGuide_Button;
        //private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraButton Delete_Button;
        private Infragistics.Win.Misc.UltraButton Revive_Button;
        //private TEdit tEdit_SectionCodeAllowZero; 
        private UiSetControl uiSetControl1;
        private Infragistics.Win.Misc.UltraButton Renewal_Button;
        private TComboEditor Discriminition_ComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel2;
        private Infragistics.Win.Misc.UltraLabel ultraLabel3;
        private TComboEditor SetKind_tComboEditor;
        private Panel panel_Customer;
        private Infragistics.Win.Misc.UltraLabel CustomerCode_Title_Label;
        private Infragistics.Win.Misc.UltraButton uButton_CustomerGuide;
        private TEdit CustomerCodeNm_tEdit;
        private TNedit tNedit_CustomerCode;
        private TComboEditor CampingCode_ComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel7;
        private TComboEditor InStock_ComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private TComboEditor PureSuperio_ComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel9;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private TComboEditor Order1_ComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel18;
        private Panel panel_Section;
        private Infragistics.Win.Misc.UltraLabel Section_uLabel;
        private TEdit tEdit_SectionCodeAllowZero2;
        private Infragistics.Win.Misc.UltraButton SectionGuide_Button;
        private TComboEditor PriorPriceSetCd3_tComboEditor;
        private TComboEditor PriorPriceSetCd2_tComboEditor;
        private TComboEditor PriorPriceSetCd1_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel ultraLabel00;
        private Infragistics.Win.Misc.UltraLabel ultraLabel15;
        private Infragistics.Win.Misc.UltraLabel ultraLabel12;
        private Infragistics.Win.Misc.UltraLabel ultraLabel13;
        private Infragistics.Win.Misc.UltraLabel ultraLabel6;
        private Infragistics.Win.Misc.UltraLabel ultraLabel11;
        private Infragistics.Win.Misc.UltraLabel ultraLabel1;
        //private Broadleaf.Library.Windows.Forms.TComboEditor PriorPriceSetCd2_tComboEditor;
        private TComboEditor Order7_ComboEditor;
        private TComboEditor Order6_ComboEditor;
        private TComboEditor Order5_ComboEditor;
        private TComboEditor Order4_ComboEditor;
        private TComboEditor Order3_ComboEditor;
        private TComboEditor Order2_ComboEditor;
        private TEdit SectionName_tEdit;
        #endregion

        #region -- Constructor --
        /// <summary>
        /// SCM�D��ݒ�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note		: SCM�D��ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br></br>
        /// </remarks>
        public PMSCM09060UA()
        {
            InitializeComponent();

            // �f�[�^�Z�b�g����\�z����
            DataSetColumnConstruction();

            // �v���p�e�B�����l�ݒ�
            this._canPrint = false;
            this._canClose = false;
            this._canNew = true;
            this._canDelete = true;
            this._canClose = true;
            this._defaultAutoFillToColumn = false;
            this._canSpecificationSearch = false;
            this._canLogicalDeleteDataExtraction = true;

            //�@��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // �ϐ�������
            this._dataIndex = -1;
            this._scmPriorStAcs = new SCMPriorStAcs();
            this._totalCount = 0;
            this._scmPriorStTable = new Hashtable();

            //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            // ���_�ݒ�A�N�Z�X�N���X
            this._secInfoAcs = new SecInfoAcs();
        }
        #endregion

        private System.ComponentModel.IContainer components;

        /// <summary>
        /// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region -- Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance137 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance138 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance139 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem94 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem95 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem96 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem97 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem98 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem86 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem87 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem88 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem89 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem90 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem91 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem92 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem93 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem76 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem77 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem78 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem79 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem80 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem81 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem82 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem83 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem84 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem85 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem61 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem62 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem63 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem64 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem65 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem66 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem67 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem68 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem69 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem70 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem71 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem72 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem73 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem74 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem75 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem51 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem52 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem53 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem54 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem55 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem56 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem57 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem58 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem59 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem60 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem41 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem42 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem43 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem44 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem45 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem46 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem47 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem48 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem49 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem50 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem31 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem32 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem33 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem34 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem35 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem36 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem37 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem38 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem39 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem40 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem21 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem22 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem23 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem24 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem25 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem26 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem27 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem28 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem29 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem30 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem11 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem12 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem13 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem14 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem15 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem16 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem17 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem18 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem19 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem20 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem3 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem4 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem5 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem6 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem7 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem8 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem9 = new Infragistics.Win.ValueListItem();
            Infragistics.Win.ValueListItem valueListItem10 = new Infragistics.Win.ValueListItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMSCM09060UA));
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PriorPriceSetCd1_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.PriorPriceSetCd2_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.PriorPriceSetCd3_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.DivideLine_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.Renewal_Button = new Infragistics.Win.Misc.UltraButton();
            this.Discriminition_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.SetKind_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tNedit_CustomerCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.CustomerCodeNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uButton_CustomerGuide = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.panel_Customer = new System.Windows.Forms.Panel();
            this.panel_Section = new System.Windows.Forms.Panel();
            this.Section_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_SectionCodeAllowZero2 = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.SectionName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel00 = new Infragistics.Win.Misc.UltraLabel();
            this.CampingCode_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.InStock_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.PureSuperio_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.Order1_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.PriorPriceSetCd3_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.PriorPriceSetCd2_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.PriorPriceSetCd1_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.Order2_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Order3_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Order4_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Order5_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Order6_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Order7_ComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Discriminition_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetKind_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCodeNm_tEdit)).BeginInit();
            this.panel_Customer.SuspendLayout();
            this.panel_Section.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampingCode_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InStock_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureSuperio_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order1_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorPriceSetCd3_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorPriceSetCd2_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorPriceSetCd1_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order2_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order3_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order4_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order5_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order6_ComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order7_ComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(317, 587);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 25;
            this.Cancel_Button.Text = "����(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(190, 587);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 24;
            this.Ok_Button.Text = "�ۑ�(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 634);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(461, 23);
            this.ultraStatusBar1.TabIndex = 11;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance137.ForeColor = System.Drawing.Color.White;
            appearance137.TextHAlignAsString = "Center";
            appearance137.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance137;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(325, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 61;
            this.Mode_Label.Text = "�X�V���[�h";
            // 
            // PriorPriceSetCd1_uLabel
            // 
            appearance138.TextVAlignAsString = "Middle";
            this.PriorPriceSetCd1_uLabel.Appearance = appearance138;
            this.PriorPriceSetCd1_uLabel.Location = new System.Drawing.Point(16, 269);
            this.PriorPriceSetCd1_uLabel.Name = "PriorPriceSetCd1_uLabel";
            this.PriorPriceSetCd1_uLabel.Size = new System.Drawing.Size(149, 24);
            this.PriorPriceSetCd1_uLabel.TabIndex = 179;
            this.PriorPriceSetCd1_uLabel.Text = "���i�敪�P";
            // 
            // PriorPriceSetCd2_uLabel
            // 
            appearance139.TextVAlignAsString = "Middle";
            this.PriorPriceSetCd2_uLabel.Appearance = appearance139;
            this.PriorPriceSetCd2_uLabel.Location = new System.Drawing.Point(16, 298);
            this.PriorPriceSetCd2_uLabel.Name = "PriorPriceSetCd2_uLabel";
            this.PriorPriceSetCd2_uLabel.Size = new System.Drawing.Size(149, 24);
            this.PriorPriceSetCd2_uLabel.TabIndex = 183;
            this.PriorPriceSetCd2_uLabel.Text = "���i�敪�Q";
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Timer
            // 
            this.Timer.Interval = 1;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // PriorPriceSetCd3_uLabel
            // 
            appearance63.TextVAlignAsString = "Middle";
            this.PriorPriceSetCd3_uLabel.Appearance = appearance63;
            this.PriorPriceSetCd3_uLabel.Location = new System.Drawing.Point(16, 328);
            this.PriorPriceSetCd3_uLabel.Name = "PriorPriceSetCd3_uLabel";
            this.PriorPriceSetCd3_uLabel.Size = new System.Drawing.Size(149, 24);
            this.PriorPriceSetCd3_uLabel.TabIndex = 258;
            this.PriorPriceSetCd3_uLabel.Text = "���i�敪�R";
            // 
            // DivideLine_Label
            // 
            this.DivideLine_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DivideLine_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.DivideLine_Label.Location = new System.Drawing.Point(16, 170);
            this.DivideLine_Label.Name = "DivideLine_Label";
            this.DivideLine_Label.Size = new System.Drawing.Size(430, 3);
            this.DivideLine_Label.TabIndex = 261;
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(190, 587);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 24;
            this.Revive_Button.Text = "����(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(59, 587);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 23;
            this.Delete_Button.Text = "���S�폜(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // Renewal_Button
            // 
            this.Renewal_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Renewal_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Renewal_Button.Location = new System.Drawing.Point(59, 587);
            this.Renewal_Button.Margin = new System.Windows.Forms.Padding(1);
            this.Renewal_Button.Name = "Renewal_Button";
            this.Renewal_Button.Size = new System.Drawing.Size(125, 34);
            this.Renewal_Button.TabIndex = 23;
            this.Renewal_Button.Text = "�ŐV���(&I)";
            this.Renewal_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Renewal_Button.Click += new System.EventHandler(this.Renewal_Button_Click);
            // 
            // Discriminition_ComboEditor
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Discriminition_ComboEditor.ActiveAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance7.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            appearance7.TextVAlignAsString = "Middle";
            this.Discriminition_ComboEditor.Appearance = appearance7;
            this.Discriminition_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Discriminition_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Discriminition_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Discriminition_ComboEditor.ItemAppearance = appearance8;
            valueListItem94.DataValue = 0;
            valueListItem94.DisplayText = "����";
            valueListItem95.DataValue = "1";
            valueListItem95.DisplayText = "PCC";
            valueListItem96.DataValue = "2";
            valueListItem96.DisplayText = "BL�߰µ��ް����";
            this.Discriminition_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem94,
            valueListItem95,
            valueListItem96});
            this.Discriminition_ComboEditor.Location = new System.Drawing.Point(171, 39);
            this.Discriminition_ComboEditor.Name = "Discriminition_ComboEditor";
            this.Discriminition_ComboEditor.Size = new System.Drawing.Size(254, 24);
            this.Discriminition_ComboEditor.TabIndex = 1;
            // 
            // ultraLabel2
            // 
            appearance34.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance34;
            this.ultraLabel2.Location = new System.Drawing.Point(17, 39);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(115, 24);
            this.ultraLabel2.TabIndex = 1324;
            this.ultraLabel2.Text = "�D��K�p�敪";
            // 
            // ultraLabel3
            // 
            appearance15.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance15;
            this.ultraLabel3.Location = new System.Drawing.Point(19, 69);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(115, 24);
            this.ultraLabel3.TabIndex = 1323;
            this.ultraLabel3.Text = "�ݒ���";
            // 
            // SetKind_tComboEditor
            // 
            appearance64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SetKind_tComboEditor.ActiveAppearance = appearance64;
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance65.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance65.ForeColorDisabled = System.Drawing.Color.Black;
            appearance65.TextVAlignAsString = "Middle";
            this.SetKind_tComboEditor.Appearance = appearance65;
            this.SetKind_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SetKind_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SetKind_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SetKind_tComboEditor.ItemAppearance = appearance66;
            valueListItem97.DataValue = 0;
            valueListItem97.DisplayText = "���_�P��";
            valueListItem98.DataValue = 1;
            valueListItem98.DisplayText = "���Ӑ�P��";
            this.SetKind_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem97,
            valueListItem98});
            this.SetKind_tComboEditor.Location = new System.Drawing.Point(171, 69);
            this.SetKind_tComboEditor.Name = "SetKind_tComboEditor";
            this.SetKind_tComboEditor.Size = new System.Drawing.Size(176, 24);
            this.SetKind_tComboEditor.TabIndex = 2;
            this.SetKind_tComboEditor.ValueChanged += new System.EventHandler(this.SetKind_tComboEditor_ValueChanged);
            // 
            // tNedit_CustomerCode
            // 
            appearance135.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance135.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode.ActiveAppearance = appearance135;
            appearance136.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance136.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance136.ForeColorDisabled = System.Drawing.Color.Black;
            appearance136.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode.Appearance = appearance136;
            this.tNedit_CustomerCode.AutoSelect = true;
            this.tNedit_CustomerCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_CustomerCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode.DataText = "123456789";
            this.tNedit_CustomerCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.tNedit_CustomerCode.Location = new System.Drawing.Point(155, 1);
            this.tNedit_CustomerCode.MaxLength = 9;
            this.tNedit_CustomerCode.Name = "tNedit_CustomerCode";
            this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.tNedit_CustomerCode.Size = new System.Drawing.Size(82, 24);
            this.tNedit_CustomerCode.TabIndex = 40;
            this.tNedit_CustomerCode.Text = "123456789";
            // 
            // CustomerCodeNm_tEdit
            // 
            appearance133.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance133.ForeColor = System.Drawing.Color.Black;
            appearance133.TextVAlignAsString = "Middle";
            this.CustomerCodeNm_tEdit.ActiveAppearance = appearance133;
            appearance134.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance134.ForeColor = System.Drawing.Color.Black;
            appearance134.ForeColorDisabled = System.Drawing.Color.Black;
            appearance134.TextVAlignAsString = "Middle";
            this.CustomerCodeNm_tEdit.Appearance = appearance134;
            this.CustomerCodeNm_tEdit.AutoSelect = true;
            this.CustomerCodeNm_tEdit.DataText = "";
            this.CustomerCodeNm_tEdit.Enabled = false;
            this.CustomerCodeNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerCodeNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CustomerCodeNm_tEdit.Location = new System.Drawing.Point(272, 1);
            this.CustomerCodeNm_tEdit.MaxLength = 20;
            this.CustomerCodeNm_tEdit.Name = "CustomerCodeNm_tEdit";
            this.CustomerCodeNm_tEdit.ReadOnly = true;
            this.CustomerCodeNm_tEdit.Size = new System.Drawing.Size(128, 24);
            this.CustomerCodeNm_tEdit.TabIndex = 100;
            this.CustomerCodeNm_tEdit.TabStop = false;
            // 
            // uButton_CustomerGuide
            // 
            appearance132.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance132.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.uButton_CustomerGuide.Appearance = appearance132;
            this.uButton_CustomerGuide.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.uButton_CustomerGuide.Location = new System.Drawing.Point(241, 1);
            this.uButton_CustomerGuide.Name = "uButton_CustomerGuide";
            this.uButton_CustomerGuide.Size = new System.Drawing.Size(24, 24);
            this.uButton_CustomerGuide.TabIndex = 3;
            this.uButton_CustomerGuide.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.uButton_CustomerGuide.Click += new System.EventHandler(this.ub_St_CustomerGuide_Click);
            // 
            // CustomerCode_Title_Label
            // 
            appearance131.TextVAlignAsString = "Middle";
            this.CustomerCode_Title_Label.Appearance = appearance131;
            this.CustomerCode_Title_Label.Location = new System.Drawing.Point(2, 2);
            this.CustomerCode_Title_Label.Name = "CustomerCode_Title_Label";
            this.CustomerCode_Title_Label.Size = new System.Drawing.Size(136, 24);
            this.CustomerCode_Title_Label.TabIndex = 1313;
            this.CustomerCode_Title_Label.Text = "���Ӑ�R�[�h";
            // 
            // panel_Customer
            // 
            this.panel_Customer.Controls.Add(this.CustomerCode_Title_Label);
            this.panel_Customer.Controls.Add(this.uButton_CustomerGuide);
            this.panel_Customer.Controls.Add(this.CustomerCodeNm_tEdit);
            this.panel_Customer.Controls.Add(this.tNedit_CustomerCode);
            this.panel_Customer.Location = new System.Drawing.Point(16, 99);
            this.panel_Customer.Name = "panel_Customer";
            this.panel_Customer.Size = new System.Drawing.Size(426, 30);
            this.panel_Customer.TabIndex = 1325;
            this.panel_Customer.Visible = false;
            // 
            // panel_Section
            // 
            this.panel_Section.Controls.Add(this.Section_uLabel);
            this.panel_Section.Controls.Add(this.tEdit_SectionCodeAllowZero2);
            this.panel_Section.Controls.Add(this.SectionGuide_Button);
            this.panel_Section.Controls.Add(this.SectionName_tEdit);
            this.panel_Section.Location = new System.Drawing.Point(16, 99);
            this.panel_Section.Name = "panel_Section";
            this.panel_Section.Size = new System.Drawing.Size(426, 30);
            this.panel_Section.TabIndex = 3;
            // 
            // Section_uLabel
            // 
            appearance22.TextVAlignAsString = "Middle";
            this.Section_uLabel.Appearance = appearance22;
            this.Section_uLabel.Location = new System.Drawing.Point(3, 4);
            this.Section_uLabel.Name = "Section_uLabel";
            this.Section_uLabel.Size = new System.Drawing.Size(132, 24);
            this.Section_uLabel.TabIndex = 1324;
            this.Section_uLabel.Text = "���_";
            // 
            // tEdit_SectionCodeAllowZero2
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCodeAllowZero2.ActiveAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCodeAllowZero2.Appearance = appearance11;
            this.tEdit_SectionCodeAllowZero2.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero2.DataText = "00";
            this.tEdit_SectionCodeAllowZero2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.tEdit_SectionCodeAllowZero2.Location = new System.Drawing.Point(154, 2);
            this.tEdit_SectionCodeAllowZero2.MaxLength = 2;
            this.tEdit_SectionCodeAllowZero2.Name = "tEdit_SectionCodeAllowZero2";
            this.tEdit_SectionCodeAllowZero2.Size = new System.Drawing.Size(20, 24);
            this.tEdit_SectionCodeAllowZero2.TabIndex = 1;
            this.tEdit_SectionCodeAllowZero2.Text = "00";
            // 
            // SectionGuide_Button
            // 
            appearance12.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance12.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.SectionGuide_Button.Appearance = appearance12;
            this.SectionGuide_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SectionGuide_Button.Location = new System.Drawing.Point(184, 3);
            this.SectionGuide_Button.Name = "SectionGuide_Button";
            this.SectionGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.SectionGuide_Button.TabIndex = 2;
            this.SectionGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
            // 
            // SectionName_tEdit
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextVAlignAsString = "Middle";
            this.SectionName_tEdit.ActiveAppearance = appearance1;
            appearance2.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance2.ForeColor = System.Drawing.Color.Black;
            appearance2.ForeColorDisabled = System.Drawing.Color.Black;
            appearance2.TextVAlignAsString = "Middle";
            this.SectionName_tEdit.Appearance = appearance2;
            this.SectionName_tEdit.AutoSelect = true;
            this.SectionName_tEdit.DataText = "";
            this.SectionName_tEdit.Enabled = false;
            this.SectionName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionName_tEdit.Location = new System.Drawing.Point(214, 3);
            this.SectionName_tEdit.MaxLength = 20;
            this.SectionName_tEdit.Name = "SectionName_tEdit";
            this.SectionName_tEdit.ReadOnly = true;
            this.SectionName_tEdit.Size = new System.Drawing.Size(35, 24);
            this.SectionName_tEdit.TabIndex = 100;
            this.SectionName_tEdit.TabStop = false;
            // 
            // ultraLabel00
            // 
            appearance30.TextVAlignAsString = "Middle";
            this.ultraLabel00.Appearance = appearance30;
            this.ultraLabel00.Location = new System.Drawing.Point(170, 135);
            this.ultraLabel00.Name = "ultraLabel00";
            this.ultraLabel00.Size = new System.Drawing.Size(210, 23);
            this.ultraLabel00.TabIndex = 1328;
            this.ultraLabel00.Text = "���[���ŋ��ʐݒ�ɂȂ�܂�";
            // 
            // CampingCode_ComboEditor
            // 
            appearance92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CampingCode_ComboEditor.ActiveAppearance = appearance92;
            appearance93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance93.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance93.ForeColorDisabled = System.Drawing.Color.Black;
            appearance93.TextVAlignAsString = "Middle";
            this.CampingCode_ComboEditor.Appearance = appearance93;
            this.CampingCode_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CampingCode_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.CampingCode_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CampingCode_ComboEditor.ItemAppearance = appearance94;
            valueListItem86.DataValue = 0;
            valueListItem86.DisplayText = "�S��";
            valueListItem87.DataValue = 1;
            valueListItem87.DisplayText = "�L�����y�[��";
            this.CampingCode_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem86,
            valueListItem87});
            this.CampingCode_ComboEditor.Location = new System.Drawing.Point(171, 238);
            this.CampingCode_ComboEditor.Name = "CampingCode_ComboEditor";
            this.CampingCode_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.CampingCode_ComboEditor.TabIndex = 8;
            // 
            // ultraLabel7
            // 
            appearance72.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance72;
            this.ultraLabel7.Location = new System.Drawing.Point(16, 238);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(130, 24);
            this.ultraLabel7.TabIndex = 1342;
            this.ultraLabel7.Text = "�L�����y�[���敪";
            // 
            // InStock_ComboEditor
            // 
            appearance95.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InStock_ComboEditor.ActiveAppearance = appearance95;
            appearance96.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance96.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance96.ForeColorDisabled = System.Drawing.Color.Black;
            appearance96.TextVAlignAsString = "Middle";
            this.InStock_ComboEditor.Appearance = appearance96;
            this.InStock_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.InStock_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.InStock_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance97.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InStock_ComboEditor.ItemAppearance = appearance97;
            valueListItem88.DataValue = 0;
            valueListItem88.DisplayText = "�S��";
            valueListItem89.DataValue = 1;
            valueListItem89.DisplayText = "�݌�";
            valueListItem90.DataValue = "2";
            valueListItem90.DisplayText = "�ϑ��E�Q�Ƒq��";
            valueListItem91.DataValue = "3";
            valueListItem91.DisplayText = "�ϑ�";
            this.InStock_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem88,
            valueListItem89,
            valueListItem90,
            valueListItem91});
            this.InStock_ComboEditor.Location = new System.Drawing.Point(171, 209);
            this.InStock_ComboEditor.Name = "InStock_ComboEditor";
            this.InStock_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.InStock_ComboEditor.TabIndex = 6;
            // 
            // ultraLabel8
            // 
            appearance76.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance76;
            this.ultraLabel8.Location = new System.Drawing.Point(16, 209);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(77, 24);
            this.ultraLabel8.TabIndex = 1340;
            this.ultraLabel8.Text = "�݌ɋ敪";
            this.ultraLabel8.TextRenderingMode = Infragistics.Win.TextRenderingMode.GDI;
            // 
            // PureSuperio_ComboEditor
            // 
            appearance98.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PureSuperio_ComboEditor.ActiveAppearance = appearance98;
            appearance99.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance99.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance99.ForeColorDisabled = System.Drawing.Color.Black;
            appearance99.TextVAlignAsString = "Middle";
            this.PureSuperio_ComboEditor.Appearance = appearance99;
            this.PureSuperio_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PureSuperio_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PureSuperio_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PureSuperio_ComboEditor.ItemAppearance = appearance100;
            valueListItem92.DataValue = 0;
            valueListItem92.DisplayText = "�S��";
            valueListItem93.DataValue = 1;
            valueListItem93.DisplayText = "����";
            this.PureSuperio_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem92,
            valueListItem93});
            this.PureSuperio_ComboEditor.Location = new System.Drawing.Point(171, 179);
            this.PureSuperio_ComboEditor.Name = "PureSuperio_ComboEditor";
            this.PureSuperio_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.PureSuperio_ComboEditor.TabIndex = 4;
            // 
            // ultraLabel9
            // 
            appearance80.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance80;
            this.ultraLabel9.Location = new System.Drawing.Point(18, 179);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(77, 24);
            this.ultraLabel9.TabIndex = 1338;
            this.ultraLabel9.Text = "���D�敪";
            // 
            // Order1_ComboEditor
            // 
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order1_ComboEditor.ActiveAppearance = appearance60;
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance67.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance67.ForeColorDisabled = System.Drawing.Color.Black;
            appearance67.TextVAlignAsString = "Middle";
            this.Order1_ComboEditor.Appearance = appearance67;
            this.Order1_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Order1_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Order1_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order1_ComboEditor.ItemAppearance = appearance68;
            valueListItem76.DataValue = 0;
            valueListItem76.DisplayText = "�Ȃ�";
            valueListItem77.DataValue = 1;
            valueListItem77.DisplayText = "�e����(��)";
            valueListItem78.DataValue = "2";
            valueListItem78.DisplayText = "�P��(��)";
            valueListItem79.DataValue = "3";
            valueListItem79.DisplayText = "�艿(��)";
            valueListItem80.DataValue = "4";
            valueListItem80.DisplayText = "�艿(��)";
            valueListItem81.DataValue = "5";
            valueListItem81.DisplayText = "�L�����y�[��";
            valueListItem82.DataValue = "6";
            valueListItem82.DisplayText = "�݌�";
            valueListItem83.DataValue = "7";
            valueListItem83.DisplayText = "�ϑ�";
            valueListItem84.DataValue = "8";
            valueListItem84.DisplayText = "�Q�Ƒq��";
            valueListItem85.DataValue = "9";
            valueListItem85.DisplayText = "�D�ǐݒ�";
            this.Order1_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem76,
            valueListItem77,
            valueListItem78,
            valueListItem79,
            valueListItem80,
            valueListItem81,
            valueListItem82,
            valueListItem83,
            valueListItem84,
            valueListItem85});
            this.Order1_ComboEditor.Location = new System.Drawing.Point(171, 367);
            this.Order1_ComboEditor.MaxDropDownItems = 10;
            this.Order1_ComboEditor.Name = "Order1_ComboEditor";
            this.Order1_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.Order1_ComboEditor.TabIndex = 16;
            // 
            // ultraLabel18
            // 
            appearance25.TextVAlignAsString = "Middle";
            this.ultraLabel18.Appearance = appearance25;
            this.ultraLabel18.Location = new System.Drawing.Point(16, 367);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel18.TabIndex = 1374;
            this.ultraLabel18.Text = "�����I�����P";
            // 
            // ultraLabel10
            // 
            this.ultraLabel10.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel10.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel10.Location = new System.Drawing.Point(16, 358);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(430, 3);
            this.ultraLabel10.TabIndex = 1382;
            // 
            // PriorPriceSetCd3_tComboEditor
            // 
            appearance87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PriorPriceSetCd3_tComboEditor.ActiveAppearance = appearance87;
            appearance88.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance88.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance88.ForeColorDisabled = System.Drawing.Color.Black;
            appearance88.TextVAlignAsString = "Middle";
            this.PriorPriceSetCd3_tComboEditor.Appearance = appearance88;
            this.PriorPriceSetCd3_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PriorPriceSetCd3_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PriorPriceSetCd3_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance89.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PriorPriceSetCd3_tComboEditor.ItemAppearance = appearance89;
            valueListItem61.DataValue = 0;
            valueListItem61.DisplayText = "�Ȃ�";
            valueListItem62.DataValue = 1;
            valueListItem62.DisplayText = "�e����(��)";
            valueListItem63.DataValue = "2";
            valueListItem63.DisplayText = "�P��(��)";
            valueListItem64.DataValue = "3";
            valueListItem64.DisplayText = "�艿(��)";
            valueListItem65.DataValue = "4";
            valueListItem65.DisplayText = "�艿(��)";
            this.PriorPriceSetCd3_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem61,
            valueListItem62,
            valueListItem63,
            valueListItem64,
            valueListItem65});
            this.PriorPriceSetCd3_tComboEditor.Location = new System.Drawing.Point(171, 328);
            this.PriorPriceSetCd3_tComboEditor.Name = "PriorPriceSetCd3_tComboEditor";
            this.PriorPriceSetCd3_tComboEditor.Size = new System.Drawing.Size(180, 24);
            this.PriorPriceSetCd3_tComboEditor.TabIndex = 14;
            // 
            // PriorPriceSetCd2_tComboEditor
            // 
            appearance90.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PriorPriceSetCd2_tComboEditor.ActiveAppearance = appearance90;
            appearance91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance91.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance91.ForeColorDisabled = System.Drawing.Color.Black;
            appearance91.TextVAlignAsString = "Middle";
            this.PriorPriceSetCd2_tComboEditor.Appearance = appearance91;
            this.PriorPriceSetCd2_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PriorPriceSetCd2_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PriorPriceSetCd2_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance102.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PriorPriceSetCd2_tComboEditor.ItemAppearance = appearance102;
            valueListItem66.DataValue = 0;
            valueListItem66.DisplayText = "�Ȃ�";
            valueListItem67.DataValue = 1;
            valueListItem67.DisplayText = "�e����(��)";
            valueListItem68.DataValue = "2";
            valueListItem68.DisplayText = "�P��(��)";
            valueListItem69.DataValue = "3";
            valueListItem69.DisplayText = "�艿(��)";
            valueListItem70.DataValue = "4";
            valueListItem70.DisplayText = "�艿(��)";
            this.PriorPriceSetCd2_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem66,
            valueListItem67,
            valueListItem68,
            valueListItem69,
            valueListItem70});
            this.PriorPriceSetCd2_tComboEditor.Location = new System.Drawing.Point(171, 298);
            this.PriorPriceSetCd2_tComboEditor.Name = "PriorPriceSetCd2_tComboEditor";
            this.PriorPriceSetCd2_tComboEditor.Size = new System.Drawing.Size(180, 24);
            this.PriorPriceSetCd2_tComboEditor.TabIndex = 12;
            // 
            // PriorPriceSetCd1_tComboEditor
            // 
            appearance103.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PriorPriceSetCd1_tComboEditor.ActiveAppearance = appearance103;
            appearance104.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance104.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance104.ForeColorDisabled = System.Drawing.Color.Black;
            appearance104.TextVAlignAsString = "Middle";
            this.PriorPriceSetCd1_tComboEditor.Appearance = appearance104;
            this.PriorPriceSetCd1_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PriorPriceSetCd1_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PriorPriceSetCd1_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance105.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PriorPriceSetCd1_tComboEditor.ItemAppearance = appearance105;
            valueListItem71.DataValue = 0;
            valueListItem71.DisplayText = "�Ȃ�";
            valueListItem72.DataValue = 1;
            valueListItem72.DisplayText = "�e����(��)";
            valueListItem73.DataValue = "2";
            valueListItem73.DisplayText = "�P��(��)";
            valueListItem74.DataValue = "3";
            valueListItem74.DisplayText = "�艿(��)";
            valueListItem75.DataValue = "4";
            valueListItem75.DisplayText = "�艿(��)";
            this.PriorPriceSetCd1_tComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem71,
            valueListItem72,
            valueListItem73,
            valueListItem74,
            valueListItem75});
            this.PriorPriceSetCd1_tComboEditor.Location = new System.Drawing.Point(171, 269);
            this.PriorPriceSetCd1_tComboEditor.Name = "PriorPriceSetCd1_tComboEditor";
            this.PriorPriceSetCd1_tComboEditor.Size = new System.Drawing.Size(180, 24);
            this.PriorPriceSetCd1_tComboEditor.TabIndex = 10;
            // 
            // ultraLabel1
            // 
            appearance24.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance24;
            this.ultraLabel1.Location = new System.Drawing.Point(16, 397);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel1.TabIndex = 1387;
            this.ultraLabel1.Text = "�����I�����Q";
            // 
            // ultraLabel6
            // 
            appearance21.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance21;
            this.ultraLabel6.Location = new System.Drawing.Point(16, 457);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel6.TabIndex = 1389;
            this.ultraLabel6.Text = "�����I�����S";
            // 
            // ultraLabel11
            // 
            appearance23.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance23;
            this.ultraLabel11.Location = new System.Drawing.Point(16, 427);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel11.TabIndex = 1388;
            this.ultraLabel11.Text = "�����I�����R";
            // 
            // ultraLabel12
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance4;
            this.ultraLabel12.Location = new System.Drawing.Point(16, 517);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel12.TabIndex = 1391;
            this.ultraLabel12.Text = "�����I�����U";
            // 
            // ultraLabel13
            // 
            appearance16.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance16;
            this.ultraLabel13.Location = new System.Drawing.Point(16, 487);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel13.TabIndex = 1390;
            this.ultraLabel13.Text = "�����I�����T";
            // 
            // ultraLabel15
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance3;
            this.ultraLabel15.Location = new System.Drawing.Point(16, 547);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(128, 24);
            this.ultraLabel15.TabIndex = 1392;
            this.ultraLabel15.Text = "�����I�����V";
            // 
            // Order2_ComboEditor
            // 
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order2_ComboEditor.ActiveAppearance = appearance45;
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance58.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance58.ForeColorDisabled = System.Drawing.Color.Black;
            appearance58.TextVAlignAsString = "Middle";
            this.Order2_ComboEditor.Appearance = appearance58;
            this.Order2_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Order2_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Order2_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order2_ComboEditor.ItemAppearance = appearance59;
            valueListItem51.DataValue = 0;
            valueListItem51.DisplayText = "�Ȃ�";
            valueListItem52.DataValue = 1;
            valueListItem52.DisplayText = "�e����(��)";
            valueListItem53.DataValue = "2";
            valueListItem53.DisplayText = "�P��(��)";
            valueListItem54.DataValue = "3";
            valueListItem54.DisplayText = "�艿(��)";
            valueListItem55.DataValue = "4";
            valueListItem55.DisplayText = "�艿(��)";
            valueListItem56.DataValue = "5";
            valueListItem56.DisplayText = "�L�����y�[��";
            valueListItem57.DataValue = "6";
            valueListItem57.DisplayText = "�݌�";
            valueListItem58.DataValue = "7";
            valueListItem58.DisplayText = "�ϑ�";
            valueListItem59.DataValue = "8";
            valueListItem59.DisplayText = "�Q�Ƒq��";
            valueListItem60.DataValue = "9";
            valueListItem60.DisplayText = "�D�ǐݒ�";
            this.Order2_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem51,
            valueListItem52,
            valueListItem53,
            valueListItem54,
            valueListItem55,
            valueListItem56,
            valueListItem57,
            valueListItem58,
            valueListItem59,
            valueListItem60});
            this.Order2_ComboEditor.Location = new System.Drawing.Point(171, 397);
            this.Order2_ComboEditor.MaxDropDownItems = 10;
            this.Order2_ComboEditor.Name = "Order2_ComboEditor";
            this.Order2_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.Order2_ComboEditor.TabIndex = 17;
            // 
            // Order3_ComboEditor
            // 
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order3_ComboEditor.ActiveAppearance = appearance42;
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance43.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance43.ForeColorDisabled = System.Drawing.Color.Black;
            appearance43.TextVAlignAsString = "Middle";
            this.Order3_ComboEditor.Appearance = appearance43;
            this.Order3_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Order3_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Order3_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order3_ComboEditor.ItemAppearance = appearance44;
            valueListItem41.DataValue = 0;
            valueListItem41.DisplayText = "�Ȃ�";
            valueListItem42.DataValue = 1;
            valueListItem42.DisplayText = "�e����(��)";
            valueListItem43.DataValue = "2";
            valueListItem43.DisplayText = "�P��(��)";
            valueListItem44.DataValue = "3";
            valueListItem44.DisplayText = "�艿(��)";
            valueListItem45.DataValue = "4";
            valueListItem45.DisplayText = "�艿(��)";
            valueListItem46.DataValue = "5";
            valueListItem46.DisplayText = "�L�����y�[��";
            valueListItem47.DataValue = "6";
            valueListItem47.DisplayText = "�݌�";
            valueListItem48.DataValue = "7";
            valueListItem48.DisplayText = "�ϑ�";
            valueListItem49.DataValue = "8";
            valueListItem49.DisplayText = "�Q�Ƒq��";
            valueListItem50.DataValue = "9";
            valueListItem50.DisplayText = "�D�ǐݒ�";
            this.Order3_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem41,
            valueListItem42,
            valueListItem43,
            valueListItem44,
            valueListItem45,
            valueListItem46,
            valueListItem47,
            valueListItem48,
            valueListItem49,
            valueListItem50});
            this.Order3_ComboEditor.Location = new System.Drawing.Point(171, 427);
            this.Order3_ComboEditor.MaxDropDownItems = 10;
            this.Order3_ComboEditor.Name = "Order3_ComboEditor";
            this.Order3_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.Order3_ComboEditor.TabIndex = 18;
            // 
            // Order4_ComboEditor
            // 
            appearance36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order4_ComboEditor.ActiveAppearance = appearance36;
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance38.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance38.ForeColorDisabled = System.Drawing.Color.Black;
            appearance38.TextVAlignAsString = "Middle";
            this.Order4_ComboEditor.Appearance = appearance38;
            this.Order4_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Order4_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Order4_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order4_ComboEditor.ItemAppearance = appearance39;
            valueListItem31.DataValue = 0;
            valueListItem31.DisplayText = "�Ȃ�";
            valueListItem32.DataValue = 1;
            valueListItem32.DisplayText = "�e����(��)";
            valueListItem33.DataValue = "2";
            valueListItem33.DisplayText = "�P��(��)";
            valueListItem34.DataValue = "3";
            valueListItem34.DisplayText = "�艿(��)";
            valueListItem35.DataValue = "4";
            valueListItem35.DisplayText = "�艿(��)";
            valueListItem36.DataValue = "5";
            valueListItem36.DisplayText = "�L�����y�[��";
            valueListItem37.DataValue = "6";
            valueListItem37.DisplayText = "�݌�";
            valueListItem38.DataValue = "7";
            valueListItem38.DisplayText = "�ϑ�";
            valueListItem39.DataValue = "8";
            valueListItem39.DisplayText = "�Q�Ƒq��";
            valueListItem40.DataValue = "9";
            valueListItem40.DisplayText = "�D�ǐݒ�";
            this.Order4_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem31,
            valueListItem32,
            valueListItem33,
            valueListItem34,
            valueListItem35,
            valueListItem36,
            valueListItem37,
            valueListItem38,
            valueListItem39,
            valueListItem40});
            this.Order4_ComboEditor.Location = new System.Drawing.Point(171, 457);
            this.Order4_ComboEditor.MaxDropDownItems = 10;
            this.Order4_ComboEditor.Name = "Order4_ComboEditor";
            this.Order4_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.Order4_ComboEditor.TabIndex = 19;
            // 
            // Order5_ComboEditor
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order5_ComboEditor.ActiveAppearance = appearance31;
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance32.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance32.ForeColorDisabled = System.Drawing.Color.Black;
            appearance32.TextVAlignAsString = "Middle";
            this.Order5_ComboEditor.Appearance = appearance32;
            this.Order5_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Order5_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Order5_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance35.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order5_ComboEditor.ItemAppearance = appearance35;
            valueListItem21.DataValue = 0;
            valueListItem21.DisplayText = "�Ȃ�";
            valueListItem22.DataValue = 1;
            valueListItem22.DisplayText = "�e����(��)";
            valueListItem23.DataValue = "2";
            valueListItem23.DisplayText = "�P��(��)";
            valueListItem24.DataValue = "3";
            valueListItem24.DisplayText = "�艿(��)";
            valueListItem25.DataValue = "4";
            valueListItem25.DisplayText = "�艿(��)";
            valueListItem26.DataValue = "5";
            valueListItem26.DisplayText = "�L�����y�[��";
            valueListItem27.DataValue = "6";
            valueListItem27.DisplayText = "�݌�";
            valueListItem28.DataValue = "7";
            valueListItem28.DisplayText = "�ϑ�";
            valueListItem29.DataValue = "8";
            valueListItem29.DisplayText = "�Q�Ƒq��";
            valueListItem30.DataValue = "9";
            valueListItem30.DisplayText = "�D�ǐݒ�";
            this.Order5_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem21,
            valueListItem22,
            valueListItem23,
            valueListItem24,
            valueListItem25,
            valueListItem26,
            valueListItem27,
            valueListItem28,
            valueListItem29,
            valueListItem30});
            this.Order5_ComboEditor.Location = new System.Drawing.Point(171, 487);
            this.Order5_ComboEditor.MaxDropDownItems = 10;
            this.Order5_ComboEditor.Name = "Order5_ComboEditor";
            this.Order5_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.Order5_ComboEditor.TabIndex = 20;
            // 
            // Order6_ComboEditor
            // 
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order6_ComboEditor.ActiveAppearance = appearance27;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance28.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance28.ForeColorDisabled = System.Drawing.Color.Black;
            appearance28.TextVAlignAsString = "Middle";
            this.Order6_ComboEditor.Appearance = appearance28;
            this.Order6_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Order6_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Order6_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order6_ComboEditor.ItemAppearance = appearance29;
            valueListItem11.DataValue = 0;
            valueListItem11.DisplayText = "�Ȃ�";
            valueListItem12.DataValue = 1;
            valueListItem12.DisplayText = "�e����(��)";
            valueListItem13.DataValue = "2";
            valueListItem13.DisplayText = "�P��(��)";
            valueListItem14.DataValue = "3";
            valueListItem14.DisplayText = "�艿(��)";
            valueListItem15.DataValue = "4";
            valueListItem15.DisplayText = "�艿(��)";
            valueListItem16.DataValue = "5";
            valueListItem16.DisplayText = "�L�����y�[��";
            valueListItem17.DataValue = "6";
            valueListItem17.DisplayText = "�݌�";
            valueListItem18.DataValue = "7";
            valueListItem18.DisplayText = "�ϑ�";
            valueListItem19.DataValue = "8";
            valueListItem19.DisplayText = "�Q�Ƒq��";
            valueListItem20.DataValue = "9";
            valueListItem20.DisplayText = "�D�ǐݒ�";
            this.Order6_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem11,
            valueListItem12,
            valueListItem13,
            valueListItem14,
            valueListItem15,
            valueListItem16,
            valueListItem17,
            valueListItem18,
            valueListItem19,
            valueListItem20});
            this.Order6_ComboEditor.Location = new System.Drawing.Point(171, 517);
            this.Order6_ComboEditor.MaxDropDownItems = 10;
            this.Order6_ComboEditor.Name = "Order6_ComboEditor";
            this.Order6_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.Order6_ComboEditor.TabIndex = 21;
            // 
            // Order7_ComboEditor
            // 
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order7_ComboEditor.ActiveAppearance = appearance37;
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance40.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance40.ForeColorDisabled = System.Drawing.Color.Black;
            appearance40.TextVAlignAsString = "Middle";
            this.Order7_ComboEditor.Appearance = appearance40;
            this.Order7_ComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.Order7_ComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.Order7_ComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.Order7_ComboEditor.ItemAppearance = appearance41;
            valueListItem1.DataValue = 0;
            valueListItem1.DisplayText = "�Ȃ�";
            valueListItem2.DataValue = 1;
            valueListItem2.DisplayText = "�e����(��)";
            valueListItem3.DataValue = "2";
            valueListItem3.DisplayText = "�P��(��)";
            valueListItem4.DataValue = "3";
            valueListItem4.DisplayText = "�艿(��)";
            valueListItem5.DataValue = "4";
            valueListItem5.DisplayText = "�艿(��)";
            valueListItem6.DataValue = "5";
            valueListItem6.DisplayText = "�L�����y�[��";
            valueListItem7.DataValue = "6";
            valueListItem7.DisplayText = "�݌�";
            valueListItem8.DataValue = "7";
            valueListItem8.DisplayText = "�ϑ�";
            valueListItem9.DataValue = "8";
            valueListItem9.DisplayText = "�Q�Ƒq��";
            valueListItem10.DataValue = "9";
            valueListItem10.DisplayText = "�D�ǐݒ�";
            this.Order7_ComboEditor.Items.AddRange(new Infragistics.Win.ValueListItem[] {
            valueListItem1,
            valueListItem2,
            valueListItem3,
            valueListItem4,
            valueListItem5,
            valueListItem6,
            valueListItem7,
            valueListItem8,
            valueListItem9,
            valueListItem10});
            this.Order7_ComboEditor.Location = new System.Drawing.Point(171, 547);
            this.Order7_ComboEditor.MaxDropDownItems = 10;
            this.Order7_ComboEditor.Name = "Order7_ComboEditor";
            this.Order7_ComboEditor.Size = new System.Drawing.Size(180, 24);
            this.Order7_ComboEditor.TabIndex = 22;
            // 
            // PMSCM09060UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(461, 657);
            this.Controls.Add(this.ultraLabel00);
            this.Controls.Add(this.Order7_ComboEditor);
            this.Controls.Add(this.Order6_ComboEditor);
            this.Controls.Add(this.Order5_ComboEditor);
            this.Controls.Add(this.Order4_ComboEditor);
            this.Controls.Add(this.panel_Section);
            this.Controls.Add(this.Order3_ComboEditor);
            this.Controls.Add(this.Order2_ComboEditor);
            this.Controls.Add(this.ultraLabel15);
            this.Controls.Add(this.ultraLabel12);
            this.Controls.Add(this.ultraLabel13);
            this.Controls.Add(this.ultraLabel6);
            this.Controls.Add(this.ultraLabel11);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.PriorPriceSetCd3_tComboEditor);
            this.Controls.Add(this.PriorPriceSetCd2_tComboEditor);
            this.Controls.Add(this.ultraLabel10);
            this.Controls.Add(this.PriorPriceSetCd1_tComboEditor);
            this.Controls.Add(this.Order1_ComboEditor);
            this.Controls.Add(this.ultraLabel18);
            this.Controls.Add(this.CampingCode_ComboEditor);
            this.Controls.Add(this.ultraLabel7);
            this.Controls.Add(this.InStock_ComboEditor);
            this.Controls.Add(this.ultraLabel8);
            this.Controls.Add(this.PureSuperio_ComboEditor);
            this.Controls.Add(this.ultraLabel9);
            this.Controls.Add(this.panel_Customer);
            this.Controls.Add(this.Discriminition_ComboEditor);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel3);
            this.Controls.Add(this.SetKind_tComboEditor);
            this.Controls.Add(this.Renewal_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.DivideLine_Label);
            this.Controls.Add(this.PriorPriceSetCd3_uLabel);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.PriorPriceSetCd2_uLabel);
            this.Controls.Add(this.PriorPriceSetCd1_uLabel);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMSCM09060UA";
            this.Text = "PCC�D��ݒ�";
            this.Load += new System.EventHandler(this.PMSCM09060UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMSCM09060UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMSCM09060UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Discriminition_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SetKind_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCodeNm_tEdit)).EndInit();
            this.panel_Customer.ResumeLayout(false);
            this.panel_Customer.PerformLayout();
            this.panel_Section.ResumeLayout(false);
            this.panel_Section.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CampingCode_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InStock_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PureSuperio_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order1_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorPriceSetCd3_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorPriceSetCd2_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PriorPriceSetCd1_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order2_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order3_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order4_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order5_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order6_ComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Order7_ComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region -- Events --
        /// <summary>��ʔ�\���C�x���g</summary>
        /// <remarks>��ʂ���\����ԂɂȂ����ۂɔ������܂��B</remarks>
        public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
        #endregion

        #region -- Private Members --
        private SCMPriorStAcs _scmPriorStAcs;
        private int _totalCount;
        private string _enterpriseCode;
        private Hashtable _scmPriorStTable;

        private SecInfoAcs _secInfoAcs;

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // �ۑ���r�pClone
        private SCMPriorSt _scmPriorStClone;

        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canLogicalDeleteDataExtraction;
        private bool _canClose;
        private bool _canNew;
        private bool _canDelete;
        private int _dataIndex;
        private bool _defaultAutoFillToColumn;
        private bool _canSpecificationSearch;
        private bool isError = false; // ADD 2011/09/07

        //------------ADD BY lingxiaoqing  2011.08.08-------------------------->>>>>>>>>>>>>>
        private CustomerInfoAcs _customerInfoAcs = new CustomerInfoAcs();
        private CustomerInfo _customerInfo = new CustomerInfo();
        private string _customerName = string.Empty;
        private Hashtable _customersList = new Hashtable();
        private bool _isNewSave = false;
        private bool _cusModeFlg = false;
        //------------ADD BY lingxiaoqing 2011.08.08-------------------------<<<<<<<<<<<<<<<<

        //_dataIndex�o�b�t�@�i���C���t���[���ŏ����Ή��j
        private int _indexBuf;

        // �V�K���[�h���烂�[�h�ύX�Ή�
        // ���[�h�t���O(true�F�R�[�h�Afalse�F�R�[�h�ȊO)
        private bool _modeFlg = false;

        private const string PROGRAM_ID = "PMSCM09060U";    // �v���O����ID

        // View�pGrid�ɕ\��������e�[�u����
        private const string VIEW_TABLE = "VIEW_TABLE";

        // Frame��View�pGrid���KEY��� (Header��Title���ƂȂ�܂�)
        private const string DELETE_DATE = "�폜��";

        private const string VIEW_SECTION_CODE_TITLE = "���_�R�[�h";
        private const string VIEW_SECTION_NAME_TITLE = "���_����";
        private const string VIEW_CUSTOMER_CODE_TITLE = "���Ӑ�R�[�h";
        private const string VIEW_CUSTOMER_NAME_TITLE = "���Ӑ於��";

        // ----------DELETE BY lingxiaoqing 2011.08.08 ---------->>>>>>>>>
        //private const string VIEW_PRIORITY_SETTING = "�D��ݒ�";
        //private const string VIEW_PRIOR_PRICE_SET1 = "�D�承�i�ݒ�P";
        //private const string VIEW_PRIOR_PRICE_SET2 = "�D�承�i�ݒ�Q";
        //private const string VIEW_PRIOR_PRICE_SET3 = "�D�承�i�ݒ�R";
        // ----------DELETE BY lingxiaoqing 2011.08.08 ----------<<<<<<<<<
        // ----------ADD BY lingxiaoqing 2011.08.08 ---------->>>>>>>>>
        private const string VIEW_PRIORITY_DISCRIMITION = "�D��K�p�敪";
        // ---UPD 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
        //private const string VIEW_PRIOR_PRICE_SET1 = "�I�������i�敪�P";
        //private const string VIEW_PRIOR_PRICE_SET2 = "�I�������i�敪�Q";
        //private const string VIEW_PRIOR_PRICE_SET3 = "�I�������i�敪�R";
        private const string VIEW_PRIOR_PRICE_SET1 = "���i�敪�P";
        private const string VIEW_PRIOR_PRICE_SET2 = "���i�敪�Q";
        private const string VIEW_PRIOR_PRICE_SET3 = "���i�敪�R";
        // ---UPD 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
        // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
        //private const string VIEW_PRIOR_PRICE_SET4 = "��I�������i�敪�P";
        //private const string VIEW_PRIOR_PRICE_SET5 = "��I�������i�敪�Q";
        //private const string VIEW_PRIOR_PRICE_SET6 = "��I�������i�敪�R";
        // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
        // ---UPD 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
        //private const string VIEW_PRIOR_SUPERIO1 = "�I�������D�敪";
        //private const string VIEW_PRIOR_SUPERIO2 = "�I�����݌ɋ敪";
        //private const string VIEW_PRIOR_SUPERIO3 = "�I�����L�����y�[���敪";
        private const string VIEW_PRIOR_SUPERIO1 = "���D�敪";
        private const string VIEW_PRIOR_SUPERIO2 = "�݌ɋ敪";
        private const string VIEW_PRIOR_SUPERIO3 = "�L�����y�[���敪";
        // ---UPD 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
        // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
        //private const string VIEW_PRIOR_SUPERIO4 = "��I�������D�敪";
        //private const string VIEW_PRIOR_SUPERIO5 = "��I�����݌ɋ敪";
        //private const string VIEW_PRIOR_SUPERIO6 = "��I�����L�����y�[���敪";
        // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
        private const string VIEW_PRIOR_ORDER1 = "�����I�����P";
        private const string VIEW_PRIOR_ORDER2 = "�����I�����Q";
        private const string VIEW_PRIOR_ORDER3 = "�����I�����R";
        private const string VIEW_PRIOR_ORDER4 = "�����I�����S";
        private const string VIEW_PRIOR_ORDER5 = "�����I�����T";
        private const string VIEW_PRIOR_ORDER6 = "�����I�����U";
        private const string VIEW_PRIOR_ORDER7 = "�����I�����V";
        private const string ct_NO_MESSAGE = "�Ȃ�";
        // ----------ADD BY lingxiaoqing 2011.08.08 ----------<<<<<<<<<
        private const string VIEW_GUID_KEY_TITLE = "Guid";

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        // �S�Ћ���
        private const string ALL_SECTIONCODE = "00";

        // �D��(���i)�ݒ薼��
        private const string ct_PRIORITY_NAME0 = "�Ȃ�";
        private const string ct_PRIORITY_NAME1 = "�e����(��)";
        private const string ct_PRIORITY_NAME2 = "�P��(��)";
        private const string ct_PRIORITY_NAME3 = "�艿(��)";
        private const string ct_PRIORITY_NAME4 = "�艿(��)";
        private const string ct_PRIORITY_NAME5 = "�L�����y�[��";
        private const string ct_PRIORITY_NAME6 = "�݌�";
        private const string ct_PRIORITY_NAME7 = "�ϑ�";//ADD BY  lingxiaoqing    2011.08.08

        private const string ct_PRIORITY_NAME50 = "�L�����y�[��";
        private const string ct_PRIORITY_NAME56 = "�L�����y�[�����݌�";
        private const string ct_PRIORITY_NAME60 = "�݌�";
        private const string ct_PRIORITY_NAME65 = "�݌Ɂ��L�����y�[��";
        // ----------ADD BY lingxiaoqing 2011.08.08 ---------->>>>>>>>>
        private const string ct_ORDER_MESSAGE1 = "���������I�����͈�ȏ�ݒ肳��邱�Ƃ��ł��܂���B";
        private const string ct_ORDER_MESSAGE2 = "�艿(��)�ƒ艿(��)�͂ǂ��炩�����ݒ�ł��܂���B";
        // ----------ADD BY lingxiaoqing 2011.08.08 ----------<<<<<<<<<
        // �ő�D��ݒ萔
        private const int MAX_PRIOR_PRICE_SET = 3;

        #endregion

        #region -- Main --
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMSCM09060UA());
        }
        # endregion

        #region -- Properties --
        /// <summary>����\�ݒ�v���p�e�B</summary>
        /// <value>����\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanPrint
        {
            get
            {
                return this._canPrint;
            }
        }

        /// <summary>�_���폜�f�[�^���o�\�ݒ�v���p�e�B</summary>
        /// <value>�_���폜�f�[�^�̒��o���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanLogicalDeleteDataExtraction
        {
            get
            {
                return this._canLogicalDeleteDataExtraction;
            }
        }

        /// <summary>��ʏI���ݒ�v���p�e�B</summary>
        /// <value>��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        /// <remarks>false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B</remarks>
        public bool CanClose
        {
            get
            {
                return this._canClose;
            }
            set
            {
                this._canClose = value;
            }
        }

        /// <summary>�V�K�o�^�\�ݒ�v���p�e�B</summary>
        /// <value>�V�K�o�^���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanNew
        {
            get
            {
                return this._canNew;
            }
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>�폜�\�ݒ�v���p�e�B</summary>
        /// <value>�폜���\���ǂ����̐ݒ���擾���܂��B</value>
        public bool CanDelete
        {
            get
            {
                return this._canDelete;
            }
        }

        /// <summary>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X�v���p�e�B</summary>
        /// <value>�f�[�^�Z�b�g�̑I���f�[�^�C���f�b�N�X���擾�܂��͐ݒ肵�܂��B</value>
        public int DataIndex
        {
            get
            {
                return this._dataIndex;
            }
            set
            {
                this._dataIndex = value;
            }
        }

        /// <summary>��̃T�C�Y�̎��������̃f�t�H���g�l�v���p�e�B</summary>
        /// <value>��̃T�C�Y�̎��������`�F�b�N�{�b�N�X�̃`�F�b�N�L���̃f�t�H���g�l���擾���܂��B</value>
        public bool DefaultAutoFillToColumn
        {
            get
            {
                return this._defaultAutoFillToColumn;
            }
        }

        /// <summary>�����w�蒊�o�\�ݒ�v���p�e�B</summary>
        /// <value>�����w�蒊�o���\�Ƃ��邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B</value>
        public bool CanSpecificationSearch
        {
            get
            {
                return this._canSpecificationSearch;
            }
        }
        #endregion

        #region -- Public Methods --
        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note		: �t���[�����̃O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = VIEW_TABLE;
        }

        /// <summary>
        /// �f�[�^��������
        /// </summary>
        /// <param name="totalCount">�S�Y������</param>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �擪����w�茏�����̃f�[�^���������A</br>
        ///	<br>			  ���o���ʂ�W�J����DataSet�ƑS�Y��������Ԃ��܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
        {
            int status = 0;
            ArrayList retList = null;
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Clear();
            this._scmPriorStTable.Clear();

            // �S����
            status = this._scmPriorStAcs.SearchAll(out retList, this._enterpriseCode);
            this._totalCount = retList.Count;

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        int index = 0;

                        foreach (SCMPriorSt scmPriorSt in retList)
                        {
                            //--------ADD BY lingxiaoqing 2011.08.08  �������Ӑ旪��----------->>>>>>>>>>>>>>
                            if (scmPriorSt.CustomerCode != 0)
                            {
                                if (!_customersList.Contains(scmPriorSt.CustomerCode))
                                {
                                    status = _customerInfoAcs.ReadDBData(_enterpriseCode, scmPriorSt.CustomerCode, out _customerInfo);
                                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                                    {
                                        if (!_customersList.Contains(scmPriorSt.CustomerCode))
                                        {
                                            _customersList.Add(scmPriorSt.CustomerCode, _customerInfo.CustomerSnm);
                                        }
                                    }
                                    else
                                    {
                                        this._customerName = string.Empty;
                                    }
                                }
                            }
                            else
                            {
                                this._customerName = string.Empty;
                            }
                            //--------ADD BY lingxiaoqing 2011.08.08 -----------------------<<<<<<<<<<<<<
                            // SCM�D��ݒ���N���X�̃f�[�^�Z�b�g�W�J����
                            SCMPriorStToDataSet(scmPriorSt.Clone(), index);
                            ++index;
                        }
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL; //ADD BY lingxiaoqing 2011.08.08
                        break;
                    }

                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }

                default:
                    {
                        TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
                            PROGRAM_ID,							    // �A�Z���u��ID
                            this.Text,              �@�@            // �v���O��������
                            "Search",                               // ��������
                            TMsgDisp.OPE_GET,                       // �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            this._scmPriorStAcs,					    // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,					// �\������{�^��
                            MessageBoxDefaultButton.Button1);		// �����\���{�^��

                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// �l�N�X�g�f�[�^��������
        /// </summary>
        /// <param name="readCount">���o�Ώی���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: �w�肵���������̃l�N�X�g�f�[�^���������܂��B</br>
        /// <br></br>
        /// </remarks>
        public int SearchNext(int readCount)
        {
            // �����Ȃ�
            return 9;
        }

        /// <summary>
        /// �f�[�^�폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : �I�𒆂̃f�[�^���폜���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Delete()
        {
            // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SCMPriorSt scmPriorSt = (SCMPriorSt)this._scmPriorStTable[guid];

            //-------DELETE BY lingxiaoqing 2011.08.08------------->>>>>>>>>>>>>
            // �S�Ћ��ʃf�[�^�͍폜�s��
            //if (scmPriorSt.SectionCode.Trim() == ALL_SECTIONCODE)
            //{
            //    TMsgDisp.Show(this,                             // �e�E�B���h�E�t�H�[��
            //            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
            //            PROGRAM_ID,							    // �A�Z���u��ID
            //            "�S�Ћ��ʃf�[�^�͍폜�ł��܂���B",	    // �\�����郁�b�Z�[�W
            //            0,									    // �X�e�[�^�X�l
            //            MessageBoxButtons.OK);					// �\������{�^��
            //    return (0);
            //}
            //-------DELETE BY lingxiaoqing 2011.08.08-------------<<<<<<<<<<<<
            //-------ADD BY lingxiaoqing 2011.08.08------------->>>>>>>>>>>>>
            if (scmPriorSt.CustomerCode == 0)
            {
                // �S�Ћ��ʃf�[�^�͍폜�s��
                if (scmPriorSt.SectionCode.Trim() == ALL_SECTIONCODE)
                {
                    TMsgDisp.Show(this,                             // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,     // �G���[���x��
                            PROGRAM_ID,							    // �A�Z���u��ID
                            "�S�Ћ��ʃf�[�^�͍폜�ł��܂���B",	    // �\�����郁�b�Z�[�W
                            0,									    // �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��
                    return (0);
                }
            }
            //-------ADD BY lingxiaoqing 2011.08.08-------------<<<<<<<<<<<<<<<
            int status;

            // SCM�D��ݒ���̘_���폜����
            status = this._scmPriorStAcs.LogicalDelete(ref scmPriorSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        ExclusiveTransaction(status, false);
                        return status;
                    }
                default:
                    {
                        // �_���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete", 							// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._scmPriorStAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        return status;
                    }
            }

            // SCM�D��ݒ���N���X�̃f�[�^�Z�b�g�W�J����
            SCMPriorStToDataSet(scmPriorSt.Clone(), this.DataIndex);

            return status;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note        : ������������s���܂��B(������)</br>
        /// <br></br>
        /// </remarks>
        public int Print()
        {
            return 0;
        }

        /// <summary>
        /// �O���b�h��O�Ϗ��擾����
        /// </summary>
        /// <returns>�O���b�h��O�Ϗ��i�[Hashtable</returns>
        /// <remarks>
        /// <br>Note        : �e��̊O����ݒ肷��N���X���i�[����Hashtable���擾���܂��B</br>
        /// <br>Update Note : BL�p�[�c�I�[�_�[�����񓚕s��Ή�</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2018/07/26</br>
        /// <br></br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
        {
            Hashtable appearanceTable = new Hashtable();

            // �폜��
            appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            // ���_�R�[�h
            appearanceTable.Add(VIEW_SECTION_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ���_����
            appearanceTable.Add(VIEW_SECTION_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // -------DELETE BY lingxiaoqing 2011.08.08------------>>>>>>>>>>
            // �D��ݒ�
            //appearanceTable.Add(VIEW_PRIORITY_SETTING, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �D�承�i�ݒ�P
            //appearanceTable.Add(VIEW_PRIOR_PRICE_SET1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �D�承�i�ݒ�Q
            //appearanceTable.Add(VIEW_PRIOR_PRICE_SET2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �D�承�i�ݒ�R
            //appearanceTable.Add(VIEW_PRIOR_PRICE_SET3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // -------DELETE BY lingxiaoqing 2011.08.08------------<<<<<<<<<
            //-----------ADD BY lingxiaoqing 2011.08.08---------->>>>>>>>>>>>
            //���Ӑ�R�[�h
            appearanceTable.Add(VIEW_CUSTOMER_CODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //���Ӑ於��
            appearanceTable.Add(VIEW_CUSTOMER_NAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // �D��K�p�敪
            appearanceTable.Add(VIEW_PRIORITY_DISCRIMITION, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�I�����Ώۏ��D�敪
            appearanceTable.Add(VIEW_PRIOR_SUPERIO1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
            ////��I�����Ώۏ��D�敪
            //appearanceTable.Add(VIEW_PRIOR_SUPERIO4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
            //�I�����Ώۍ݌ɋ敪
            appearanceTable.Add(VIEW_PRIOR_SUPERIO2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
            ////��I�����Ώۍ݌ɋ敪
            //appearanceTable.Add(VIEW_PRIOR_SUPERIO5, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
            //�I�����ΏۃL�����y�[���敪
            appearanceTable.Add(VIEW_PRIOR_SUPERIO3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
            ////��I�����ΏۃL�����y�[���敪
            //appearanceTable.Add(VIEW_PRIOR_SUPERIO6, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
            // �I�����Ώۉ��i�敪�P
            appearanceTable.Add(VIEW_PRIOR_PRICE_SET1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
            //// ��I�����Ώۉ��i�敪�P
            //appearanceTable.Add(VIEW_PRIOR_PRICE_SET4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
            // �I�����Ώۉ��i�敪�Q
            appearanceTable.Add(VIEW_PRIOR_PRICE_SET2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
            //// ��I�����Ώۉ��i�敪�Q
            //appearanceTable.Add(VIEW_PRIOR_PRICE_SET5, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
            // �I�����Ώۉ��i�敪�R
            appearanceTable.Add(VIEW_PRIOR_PRICE_SET3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
            //// ��I�����Ώۉ��i�敪�R
            //appearanceTable.Add(VIEW_PRIOR_PRICE_SET6, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
            //�����I����1
            appearanceTable.Add(VIEW_PRIOR_ORDER1, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�����I����2
            appearanceTable.Add(VIEW_PRIOR_ORDER2, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�����I����3
            appearanceTable.Add(VIEW_PRIOR_ORDER3, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�����I����4
            appearanceTable.Add(VIEW_PRIOR_ORDER4, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�����I����5
            appearanceTable.Add(VIEW_PRIOR_ORDER5, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�����I����6
            appearanceTable.Add(VIEW_PRIOR_ORDER6, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //�����I����7
            appearanceTable.Add(VIEW_PRIOR_ORDER7, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
            //-----------ADD BY lingxiaoqing 2011.08.08---------->>>>>>>>>>>>
            // Guid
            appearanceTable.Add(VIEW_GUID_KEY_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

            return appearanceTable;
        }
        # endregion

        #region -- Private Methods --
        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ̍č\�z���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this.DataIndex < 0)
            {
                SCMPriorSt scmPriorSt = new SCMPriorSt();
                //�N���[���쐬
                this._scmPriorStClone = scmPriorSt.Clone();
                this._indexBuf = this._dataIndex;

                // ��ʏ����r�p�N���[���ɃR�s�[���܂�
                ScreenToSCMPriorSt(ref this._scmPriorStClone);

                // �V�K���[�h
                this.Mode_Label.Text = INSERT_MODE;

                // ��ʓ��͋����䏈��
                ScreenInputPermissionControl(INSERT_MODE);

                // �t�H�[�J�X�ݒ�
                //this.tEdit_SectionCodeAllowZero.Focus(); //DELETE BY lingxiaoqing  2011.08.08
                this.Discriminition_ComboEditor.Focus();  //ADD BY lingxiaoqing  2011.08.08
            }
            else
            {
                // �ێ����Ă���f�[�^�Z�b�g���C���O���擾
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
                SCMPriorSt scmPriorSt = (SCMPriorSt)this._scmPriorStTable[guid];

                // SCM�D��ݒ�N���X��ʓW�J����
                SCMPriorStToScreen(scmPriorSt);

                if (scmPriorSt.LogicalDeleteCode == 0)
                {
                    // �X�V�\��Ԃ̎�
                    this.Mode_Label.Text = UPDATE_MODE;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(UPDATE_MODE);

                    // �t�H�[�J�X�ݒ�
                    //this.PrioritySetting_tComboEditor.Focus();  //DELETE BY lingxiaoqing 2011.08.08  

                    // �N���[���쐬
                    this._scmPriorStClone = scmPriorSt.Clone();

                    // ��ʏ����r�p�N���[���ɃR�s�[���܂��@   
                    ScreenToSCMPriorSt(ref this._scmPriorStClone);
                }
                else
                {
                    // �폜��Ԃ̎�
                    this.Mode_Label.Text = DELETE_MODE;

                    this.Ok_Button.Visible = false;
                    this.Cancel_Button.Visible = true;
                    this.Delete_Button.Visible = true;
                    this.Revive_Button.Visible = true;

                    // ��ʓ��͋����䏈��
                    ScreenInputPermissionControl(DELETE_MODE);

                    // �t�H�[�J�X�ݒ�
                    this.Delete_Button.Focus();
                }

                this._indexBuf = this._dataIndex;
            }
        }

        /// <summary>
        /// ��ʓ��͋����䏈��
        /// </summary>
        /// <param name="mode">���[�h(�V�K�E�X�V�E�폜)</param>
        /// <remarks>
        /// <br>Note       : ��ʂ̓��͋��𐧌䂵�܂��B</br>
        /// <br>Update Note : BL�p�[�c�I�[�_�[�����񓚕s��Ή�</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2018/07/26</br>
        /// <br></br>
        /// </remarks>
        private void ScreenInputPermissionControl(string mode)
        {
            switch (mode)
            {
                case INSERT_MODE:
                case UPDATE_MODE:
                    {
                        this.Ok_Button.Visible = true;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = false;
                        this.Revive_Button.Visible = false;
                        this.Renewal_Button.Visible = true;
                        this.SectionName_tEdit.Enabled = false;
                        //this.PrioritySetting_tComboEditor.Enabled = true;  //DELETE BY lingxiaoqing 2011.08.08                      
                        //---------ADD BY lingxiaoqing  2011.08.08------------------>>>>>>>>>>
                        this.SetKind_tComboEditor.Enabled = false;
                        this.PureSuperio_ComboEditor.Enabled = true;
                        //this.PureSuperio1_ComboEditor.Enabled = true; // DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή�
                        this.InStock_ComboEditor.Enabled = true;
                        //this.InStock1_ComboEditor.Enabled = true; // DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή�
                        this.CampingCode_ComboEditor.Enabled = true;
                        //this.CampingCode1_ComboEditor.Enabled = true; // DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή�
                        this.PriorPriceSetCd1_tComboEditor.Enabled = true;
                        this.PriorPriceSetCd2_tComboEditor.Enabled = true;
                        this.PriorPriceSetCd3_tComboEditor.Enabled = true;
                        // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
                        //this.PriorPriceSetCd4_tComboEditor.Enabled = true;
                        //this.PriorPriceSetCd5_tComboEditor.Enabled = true;
                        //this.PriorPriceSetCd6_tComboEditor.Enabled = true;
                        // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
                        this.Order1_ComboEditor.Enabled = true;
                        this.Order2_ComboEditor.Enabled = true;
                        this.Order3_ComboEditor.Enabled = true;
                        this.Order4_ComboEditor.Enabled = true;
                        this.Order5_ComboEditor.Enabled = true;
                        this.Order6_ComboEditor.Enabled = true;
                        this.Order7_ComboEditor.Enabled = true;
                        //---------ADD BY lingxiaoqing   2011.08.08---------------<<<<<<<<<<<<
                        //-----------DELETE BY lingxiaoqing 2011.08.08---------->>>>>>>>>>>>
                        //this.PrioritySetting_tComboEditor.Enabled = true;
                        //this.PriorPriceSetCd1_tComboEditor.Enabled = true;
                        //this.PriorPriceSetCd2_tComboEditor.Enabled = true;
                        //this.PriorPriceSetCd3_tComboEditor.Enabled = true;
                        //-----------DELETE BY lingxiaoqing  2011.08.08-----------<<<<<<<<<<<<<

                        if (mode == INSERT_MODE)
                        {
                            // �V�K���[�h
                            this.tEdit_SectionCodeAllowZero2.Enabled = true;
                            this.SectionGuide_Button.Enabled = true;
                            //-----------ADD BY lingxiaoqing  2011.08.08--------->>>>>>>>>>>>
                            this.SetKind_tComboEditor.Enabled = true;
                            this.tNedit_CustomerCode.Enabled = true;
                            this.uButton_CustomerGuide.Enabled = true;
                            this.Discriminition_ComboEditor.Enabled = true;
                            //-----------ADD BY lingxiaoqing  2011.08.08----------<<<<<<<<<<<
                        }
                        else
                        {
                            // �X�V���[�h
                            //this.tEdit_SectionCodeAllowZero.Enabled = false;  //DELETE BY lingxiaoqing  2011.08.08 
                            //this.SectionGuide_Button.Enabled = false;  //DELETE BY lingxiaoqing 2011.08.08
                            //-----------ADD BY lingxiaoqing  2011.08.08--------->>>>>>>>>>>>
                            if (this.SetKind_tComboEditor.SelectedIndex == 0)
                            {
                                this.tEdit_SectionCodeAllowZero2.Enabled = false;
                                this.SectionGuide_Button.Enabled = false;
                            }
                            else
                            {
                                this.tNedit_CustomerCode.Enabled = false;
                                this.uButton_CustomerGuide.Enabled = false;
                            }
                            this.Discriminition_ComboEditor.Enabled = false;
                            //-----------ADD BY lingxiaoqing  2011.08.08----------<<<<<<<<<<<
                        }

                        break;
                    }
                case DELETE_MODE:
                    {
                        this.Ok_Button.Visible = false;
                        this.Cancel_Button.Visible = true;
                        this.Delete_Button.Visible = true;
                        this.Revive_Button.Visible = true;
                        this.Renewal_Button.Visible = false;
                        this.tEdit_SectionCodeAllowZero2.Enabled = false;
                        this.SectionGuide_Button.Enabled = false;
                        this.SectionName_tEdit.Enabled = false;
                        //this.PrioritySetting_tComboEditor.Enabled = false; //DELETE BY lingxiaoqing  2011.08.08
                        //---------ADD BY lingxiaoqing  2011.08.08------------------>>>>>>>>>>
                        this.PureSuperio_ComboEditor.Enabled = false;
                        //this.PureSuperio1_ComboEditor.Enabled = false; // DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή�
                        this.InStock_ComboEditor.Enabled = false;
                        //this.InStock1_ComboEditor.Enabled = false; // DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή�
                        this.CampingCode_ComboEditor.Enabled = false;
                        //this.CampingCode1_ComboEditor.Enabled = false; // DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή�
                        this.PriorPriceSetCd1_tComboEditor.Enabled = false;
                        this.PriorPriceSetCd2_tComboEditor.Enabled = false;
                        this.PriorPriceSetCd3_tComboEditor.Enabled = false;
                        // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
                        //this.PriorPriceSetCd4_tComboEditor.Enabled = false;
                        //this.PriorPriceSetCd5_tComboEditor.Enabled = false;
                        //this.PriorPriceSetCd6_tComboEditor.Enabled = false;
                        // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
                        this.Order1_ComboEditor.Enabled = false;
                        this.Order2_ComboEditor.Enabled = false;
                        this.Order3_ComboEditor.Enabled = false;
                        this.Order4_ComboEditor.Enabled = false;
                        this.Order5_ComboEditor.Enabled = false;
                        this.Order6_ComboEditor.Enabled = false;
                        this.Order7_ComboEditor.Enabled = false;
                        //---------ADD BY lingxiaoqing  2011.08.08-------------------------<<<<<<<<<<<<
                        //-----------DELETE BY lingxiaoqing 2011.08.08---------->>>>>>>>>>>>
                        //this.PrioritySetting_tComboEditor.Enabled = false;
                        //this.PriorPriceSetCd1_tComboEditor.Enabled = false;
                        //this.PriorPriceSetCd2_tComboEditor.Enabled = false;
                        //this.PriorPriceSetCd3_tComboEditor.Enabled = false;
                        //-----------DELETE BY lingxiaoqing 2011.08.08----------<<<<<<<<<<<<<

                        break;
                    }
            }
        }

        /// <summary>
        /// SCM�D��ݒ�I�u�W�F�N�g�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="scmPriorSt">SCM�D��ݒ�I�u�W�F�N�g</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : SCM�D��ݒ�N���X���f�[�^�Z�b�g�Ɋi�[���܂��B</br>
        /// <br>Update Note : BL�p�[�c�I�[�_�[�����񓚕s��Ή�</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2018/07/26</br>
        /// <br></br>
        /// </remarks>
        private void SCMPriorStToDataSet(SCMPriorSt scmPriorSt, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);
                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
            }

            if (scmPriorSt.LogicalDeleteCode == 0)
            {
                // �X�V�\��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = "";
            }
            else
            {
                // �폜��Ԃ̎�
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][DELETE_DATE] = scmPriorSt.UpdateDateTimeJpInFormal;
            }

            //-----------DELETE BY lingxiaoqing 2011.08.08---------->>>>>>>>>>>>
            // �D��ݒ�
            //if (scmPriorSt.PrioritySettingCd2 == 0)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITY_SETTING] = scmPriorSt.PrioritySettingNm1;
            //}
            //else
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITY_SETTING] = scmPriorSt.PrioritySettingNm1 + "��" + scmPriorSt.PrioritySettingNm2;
            //}
            // ���_�R�[�h
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = scmPriorSt.SectionCode;
            //// ���_����
            //string sectionName = GetSectionName(scmPriorSt.SectionCode);
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = sectionName;

            //// �D��ݒ�
            //if (scmPriorSt.PrioritySettingCd2 == 0)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITY_SETTING] = scmPriorSt.PrioritySettingNm1;
            //}
            //else
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITY_SETTING] = scmPriorSt.PrioritySettingNm1 + "��" + scmPriorSt.PrioritySettingNm2;
            //}
            // �D�承�i�ݒ�P
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET1] = scmPriorSt.PriorPriceSetNm1;
            // �D�承�i�ݒ�Q
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET2] = scmPriorSt.PriorPriceSetNm2;
            // �D�承�i�ݒ�R
            //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET3] = scmPriorSt.PriorPriceSetNm3;
            //-----------DELETE BY lingxiaoqing 2011.08.08----------<<<<<<<<<<<<<<<<

            //-------------ADD BY lingxiaoqing 2011.08.08 ---------->>>>>>>>>>>>>>>>
            if (scmPriorSt.CustomerCode != 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = ct_NO_MESSAGE;
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = ct_NO_MESSAGE;
                //���Ӑ�R�[�h
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_CODE_TITLE] = scmPriorSt.CustomerCode.ToString().TrimEnd().PadLeft(8, '0');
                if (scmPriorSt.CustomerCode == 0 || _isNewSave)
                {
                    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_NAME_TITLE] = _customerName;  // ���Ӑ於�̎擾
                }
                else
                {
                    foreach (DictionaryEntry customer in _customersList)
                    {
                        if ((int)customer.Key == scmPriorSt.CustomerCode)
                        {
                            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_NAME_TITLE] = (string)customer.Value;
                        }
                    }
                }
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_CODE_TITLE] = scmPriorSt.SectionCode;
                // ���_����
                string sectionName = string.Empty;
                sectionName = GetSectionName(scmPriorSt.SectionCode);
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_SECTION_NAME_TITLE] = sectionName;
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_CODE_TITLE] = ct_NO_MESSAGE;
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_CUSTOMER_NAME_TITLE] = ct_NO_MESSAGE;
            }
            //�D��K�p�敪           
            if (scmPriorSt.PriorAppliDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITY_DISCRIMITION] = "����";
            }
            else if (scmPriorSt.PriorAppliDiv == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITY_DISCRIMITION] = "PCC";
            }
            else
            {
                //this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITY_DISCRIMITION] = "PCCUOE"; //DEL BY wujun FOR Redmine#25173 ON 2011.09.15 
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIORITY_DISCRIMITION] = "BL�߰µ��ް����"; //ADD BY wujun FOR Redmine#25173 ON 2011.09.15�@
            }
            //�I�����Ώۏ��D�敪���D�敪
            if (scmPriorSt.SelTgtPureDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO1] = "�S��";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO1] = "����";
            }
            //�I�����Ώۏ��D�敪�݌ɋ敪 
            if (scmPriorSt.SelTgtStckDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO2] = "�S��";
            }
            else if (scmPriorSt.SelTgtStckDiv == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO2] = "�݌�";
            }
            else if (scmPriorSt.SelTgtStckDiv == 2)
            {
                // UPD 2013/12/16 �g�� CM�d�|�ꗗ��10590�Ή� 2014/03/19�z�M�\�� -------->>>>>>>>>>>>>>>>>
                // this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO2] = "�ϑ��E�D��q��";
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO2] = "�ϑ��E�Q�Ƒq��";
                // UPD 2013/12/16 �g�� CM�d�|�ꗗ��10590�Ή� 2014/03/19�z�M�\�� --------<<<<<<<<<<<<<<<<<
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO2] = "�ϑ�";
            }
            //�I�����Ώۏ��D�敪�L�����y�[���敪
            if (scmPriorSt.SelTgtCampDiv == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO3] = "�S��";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO3] = "�L�����y�[��";
            }
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
            ////��I�����Ώۏ��D�敪���D�敪
            //if (scmPriorSt.UnSelTgtPureDiv == 0)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO4] = "�S��";
            //}
            //else
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO4] = "����";
            //}
            ////��I�����Ώۏ��D�敪�݌ɋ敪
            //if (scmPriorSt.UnSelTgtStckDiv == 0)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO5] = "�S��";
            //}
            //else if (scmPriorSt.UnSelTgtStckDiv == 1)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO5] = "�݌�";
            //}
            //else if (scmPriorSt.UnSelTgtStckDiv == 2)
            //{
            //    // UPD 2013/12/16 �g�� CM�d�|�ꗗ��10590�Ή� 2014/03/19�z�M�\�� -------->>>>>>>>>>>>>>>>>
            //    // this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO5] = "�ϑ��E�D��q��";
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO5] = "�ϑ��E�Q�Ƒq��";
            //    // UPD 2013/12/16 �g�� CM�d�|�ꗗ��10590�Ή� 2014/03/19�z�M�\�� --------<<<<<<<<<<<<<<<<<
            //}
            //else
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO5] = "�ϑ�";
            //}
            ////��I�����Ώۏ��D�敪�L�����y�[���敪
            //if (scmPriorSt.UnSelTgtCampDiv == 0)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO6] = "�S��";
            //}
            //else
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_SUPERIO6] = "�L�����y�[��";
            //}
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
            // �I�����Ώۉ��i�敪�P
            if (scmPriorSt.SelTgtPricDiv1 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET1] = "�Ȃ�";
            }
            else if (scmPriorSt.SelTgtPricDiv1 == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET1] = "�e����(��)";
            }
            else if (scmPriorSt.SelTgtPricDiv1 == 2)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET1] = "�P��(��)";
            }
            else if (scmPriorSt.SelTgtPricDiv1 == 3)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET1] = "�艿(��)";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET1] = "�艿(��)";
            }
            // �I�����Ώۉ��i�敪�Q
            if (scmPriorSt.SelTgtPricDiv2 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET2] = "�Ȃ�";
            }
            else if (scmPriorSt.SelTgtPricDiv2 == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET2] = "�e����(��)";
            }
            else if (scmPriorSt.SelTgtPricDiv2 == 2)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET2] = "�P��(��)";
            }
            else if (scmPriorSt.SelTgtPricDiv2 == 3)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET2] = "�艿(��)";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET2] = "�艿(��)";
            }
            // �I�����Ώۉ��i�敪 3
            if (scmPriorSt.SelTgtPricDiv3 == 0)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET3] = "�Ȃ�";
            }
            else if (scmPriorSt.SelTgtPricDiv3 == 1)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET3] = "�e����(��)";
            }
            else if (scmPriorSt.SelTgtPricDiv3 == 2)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET3] = "�P��(��)";
            }
            else if (scmPriorSt.SelTgtPricDiv3 == 3)
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET3] = "�艿(��)";
            }
            else
            {
                this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET3] = "�艿(��)";
            }
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
            //// ��I�����Ώۉ��i�敪�P
            //if (scmPriorSt.UnSelTgtPricDiv1 == 0)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET4] = "�Ȃ�";
            //}
            //else if (scmPriorSt.UnSelTgtPricDiv1 == 1)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET4] = "�e����(��)";
            //}
            //else if (scmPriorSt.UnSelTgtPricDiv1 == 2)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET4] = "�P��(��)";
            //}
            //else if (scmPriorSt.UnSelTgtPricDiv1 == 3)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET4] = "�艿(��)";
            //}
            //else
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET4] = "�艿(��)";
            //}
            //// ��I�����Ώۉ��i�敪 2
            //if (scmPriorSt.UnSelTgtPricDiv2 == 0)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET5] = "�Ȃ�";
            //}
            //else if (scmPriorSt.UnSelTgtPricDiv2 == 1)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET5] = "�e����(��)";
            //}
            //else if (scmPriorSt.UnSelTgtPricDiv2 == 2)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET5] = "�P��(��)";
            //}
            //else if (scmPriorSt.UnSelTgtPricDiv2 == 3)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET5] = "�艿(��)";
            //}
            //else
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET5] = "�艿(��)";
            //}
            //// ��I�����Ώۉ��i�敪�R
            //if (scmPriorSt.UnSelTgtPricDiv3 == 0)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET6] = "�Ȃ�";
            //}
            //else if (scmPriorSt.UnSelTgtPricDiv3 == 1)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET6] = "�e����(��)";
            //}
            //else if (scmPriorSt.UnSelTgtPricDiv3 == 2)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET6] = "�P��(��)";
            //}
            //else if (scmPriorSt.UnSelTgtPricDiv3 == 3)
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET6] = "�艿(��)";
            //}
            //else
            //{
            //    this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_PRICE_SET6] = "�艿(��)";
            //}
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
            //�����I����1
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_ORDER1] = scmPriorSt.PrioritySettingNm1;
            //�����I����2
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_ORDER2] = scmPriorSt.PrioritySettingNm2;
            //�����I����3
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_ORDER3] = scmPriorSt.PrioritySettingNm3;
            //�����I����4
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_ORDER4] = scmPriorSt.PrioritySettingNm4;
            //�����I����5
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_ORDER5] = scmPriorSt.PrioritySettingNm5;
            //�����I����6
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_ORDER6] = scmPriorSt.PriorPriceSetNm1;
            //�����I����7
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_PRIOR_ORDER7] = scmPriorSt.PriorPriceSetNm2;
            //-------------ADD BY lingxiaoqing 2011.08.08 --------------<<<<<<<<<<<<<<
            // Guid
            this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][VIEW_GUID_KEY_TITLE] = scmPriorSt.FileHeaderGuid;

            if (this._scmPriorStTable.ContainsKey(scmPriorSt.FileHeaderGuid) == true)
            {
                this._scmPriorStTable.Remove(scmPriorSt.FileHeaderGuid);
            }
            this._scmPriorStTable.Add(scmPriorSt.FileHeaderGuid, scmPriorSt);
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///					 �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂�</br>
        /// <br>Update Note : BL�p�[�c�I�[�_�[�����񓚕s��Ή�</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2018/07/26</br>
        /// <br></br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable scmPriorStTable = new DataTable(VIEW_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B

            scmPriorStTable.Columns.Add(DELETE_DATE, typeof(string));			            // �폜��

            scmPriorStTable.Columns.Add(VIEW_SECTION_CODE_TITLE, typeof(string));           // ���_�R�[�h
            scmPriorStTable.Columns.Add(VIEW_SECTION_NAME_TITLE, typeof(string));           // ���_����
            //-------DELETE BY lingxiaoqing 2011.08.08 ------>>>>>>>>>>
            //scmPriorStTable.Columns.Add(VIEW_PRIORITY_SETTING, typeof(string));             // �D��ݒ�
            //scmPriorStTable.Columns.Add(VIEW_PRIOR_PRICE_SET1, typeof(string));             // �D�承�i�ݒ�P
            //scmPriorStTable.Columns.Add(VIEW_PRIOR_PRICE_SET2, typeof(string));             // �D�承�i�ݒ�Q
            //scmPriorStTable.Columns.Add(VIEW_PRIOR_PRICE_SET3, typeof(string));             // �D�承�i�ݒ�R
            //-------DELETE BY lingxiaoqing 2011.08.08 ------<<<<<<<<<<

            //--------ADD BY lingxiaoiqng 2011.080.08 -------------->>>>>>>>>>>>
            scmPriorStTable.Columns.Add(VIEW_CUSTOMER_CODE_TITLE, typeof(string));           // ���Ӑ�R�[�h
            scmPriorStTable.Columns.Add(VIEW_CUSTOMER_NAME_TITLE, typeof(string));           // ���Ӑ於��
            scmPriorStTable.Columns.Add(VIEW_PRIORITY_DISCRIMITION, typeof(string));          // �D��K�p�敪
            scmPriorStTable.Columns.Add(VIEW_PRIOR_SUPERIO1, typeof(string));               // �I�����Ώۏ��D�敪
            //scmPriorStTable.Columns.Add(VIEW_PRIOR_SUPERIO4, typeof(string));               //  ��I�����Ώۏ��D�敪 // DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή�
            scmPriorStTable.Columns.Add(VIEW_PRIOR_SUPERIO2, typeof(string));                // �I�����Ώۍ݌ɋ敪
            //scmPriorStTable.Columns.Add(VIEW_PRIOR_SUPERIO5, typeof(string));                // ��I�����Ώۍ݌ɋ敪 // DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή�
            scmPriorStTable.Columns.Add(VIEW_PRIOR_SUPERIO3, typeof(string));                // �I�����ΏۃL�����y�[���敪  
            //scmPriorStTable.Columns.Add(VIEW_PRIOR_SUPERIO6, typeof(string));                // ��I�����ΏۃL�����y�[���敪 // DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή�
            scmPriorStTable.Columns.Add(VIEW_PRIOR_PRICE_SET1, typeof(string));             // �I�����Ώۉ��i�敪�P
            //scmPriorStTable.Columns.Add(VIEW_PRIOR_PRICE_SET4, typeof(string));             // ��I�����Ώۉ��i�敪�P // DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή�
            scmPriorStTable.Columns.Add(VIEW_PRIOR_PRICE_SET2, typeof(string));             // �I�����Ώۉ��i�敪�Q
            //scmPriorStTable.Columns.Add(VIEW_PRIOR_PRICE_SET5, typeof(string));             // ��I�����Ώۉ��i�敪�Q // DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή�
            scmPriorStTable.Columns.Add(VIEW_PRIOR_PRICE_SET3, typeof(string));             // �I�����Ώۉ��i�敪�R
            //scmPriorStTable.Columns.Add(VIEW_PRIOR_PRICE_SET6, typeof(string));             // ��I�����Ώۉ��i�敪�R // DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή�
            scmPriorStTable.Columns.Add(VIEW_PRIOR_ORDER1, typeof(string));                   //�����I����1
            scmPriorStTable.Columns.Add(VIEW_PRIOR_ORDER2, typeof(string));                   //�����I����2
            scmPriorStTable.Columns.Add(VIEW_PRIOR_ORDER3, typeof(string));                   //�����I����3
            scmPriorStTable.Columns.Add(VIEW_PRIOR_ORDER4, typeof(string));                   //�����I����4
            scmPriorStTable.Columns.Add(VIEW_PRIOR_ORDER5, typeof(string));                    //�����I����5
            scmPriorStTable.Columns.Add(VIEW_PRIOR_ORDER6, typeof(string));                    //�����I����6
            scmPriorStTable.Columns.Add(VIEW_PRIOR_ORDER7, typeof(string));                    //�����I����7
            //--------ADD BY lingxiaoiqng 2011.080.08 --------------<<<<<<<<<<<<
            scmPriorStTable.Columns.Add(VIEW_GUID_KEY_TITLE, typeof(Guid));                 // Guid

            this.Bind_DataSet.Tables.Add(scmPriorStTable);
        }

        //------------DELETE BY lingxiaoqing 2011.08.08--------------->>>>>>>>>>>>>>>>
        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        //private void ScreenInitialSetting()
        //{
        //// �D��ݒ�
        //PrioritySetting_tComboEditor.Items.Clear();
        //PrioritySetting_tComboEditor.Items.Add(65, ct_PRIORITY_NAME65);
        //PrioritySetting_tComboEditor.Items.Add(56, ct_PRIORITY_NAME56);
        //PrioritySetting_tComboEditor.Items.Add(60, ct_PRIORITY_NAME60);
        //PrioritySetting_tComboEditor.Items.Add(50, ct_PRIORITY_NAME50);
        //PrioritySetting_tComboEditor.Items.Add(0, ct_PRIORITY_NAME0);
        //PrioritySetting_tComboEditor.MaxDropDownItems = PrioritySetting_tComboEditor.Items.Count;

        //// �D�承�i�ݒ�P
        //PriorPriceSetCd1_tComboEditor.Items.Clear();
        //PriorPriceSetCd1_tComboEditor.Items.Add(0, ct_PRIORITY_NAME0);
        //PriorPriceSetCd1_tComboEditor.Items.Add(1, ct_PRIORITY_NAME1);
        //PriorPriceSetCd1_tComboEditor.Items.Add(2, ct_PRIORITY_NAME2);
        //PriorPriceSetCd1_tComboEditor.Items.Add(3, ct_PRIORITY_NAME3);
        //PriorPriceSetCd1_tComboEditor.Items.Add(4, ct_PRIORITY_NAME4);
        //PriorPriceSetCd1_tComboEditor.MaxDropDownItems = PriorPriceSetCd1_tComboEditor.Items.Count;

        // �D�承�i�ݒ�Q
        //PriorPriceSetCd2_tComboEditor.Items.Clear();
        //PriorPriceSetCd2_tComboEditor.Items.Add(0, ct_PRIORITY_NAME0);
        //PriorPriceSetCd2_tComboEditor.Items.Add(1, ct_PRIORITY_NAME1);
        //PriorPriceSetCd2_tComboEditor.Items.Add(2, ct_PRIORITY_NAME2);
        //PriorPriceSetCd2_tComboEditor.Items.Add(3, ct_PRIORITY_NAME3);
        //PriorPriceSetCd2_tComboEditor.Items.Add(4, ct_PRIORITY_NAME4);
        //PriorPriceSetCd2_tComboEditor.MaxDropDownItems = PriorPriceSetCd2_tComboEditor.Items.Count;

        // �D�承�i�ݒ�R
        //PriorPriceSetCd3_tComboEditor.Items.Clear();
        //PriorPriceSetCd3_tComboEditor.Items.Add(0, ct_PRIORITY_NAME0);
        //PriorPriceSetCd3_tComboEditor.Items.Add(1, ct_PRIORITY_NAME1);
        //PriorPriceSetCd3_tComboEditor.Items.Add(2, ct_PRIORITY_NAME2);
        //PriorPriceSetCd3_tComboEditor.Items.Add(3, ct_PRIORITY_NAME3);
        //PriorPriceSetCd3_tComboEditor.Items.Add(4, ct_PRIORITY_NAME4);
        //PriorPriceSetCd3_tComboEditor.MaxDropDownItems = PriorPriceSetCd3_tComboEditor.Items.Count;

        //}
        //------------DELETE BY lingxiaoqing ---------------<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ��ʂ��N���A���܂��B</br>
        /// <br>Update Note : BL�p�[�c�I�[�_�[�����񓚕s��Ή�</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2018/07/26</br>
        /// <br></br>
        /// </remarks>
        private void ScreenClear()
        {
            this.tEdit_SectionCodeAllowZero2.DataText = "";
            this.SectionName_tEdit.DataText = "";
            //--------DELTE BY lingxiaoqing 2011.08.08 ---------->>>>>>>>>>
            //this.PrioritySetting_tComboEditor.SelectedIndex = 0;        // �D��ݒ�
            //this.PriorPriceSetCd1_tComboEditor.SelectedIndex = 0;       // �D�承�i�ݒ�P
            //this.PriorPriceSetCd2_tComboEditor.SelectedIndex = 0;       // �D�承�i�ݒ�Q
            //this.PriorPriceSetCd3_tComboEditor.SelectedIndex = 0;       // �D�承�i�ݒ�R
            //--------DELTE BY lingxiaoqing 2011.08.08 ----------<<<<<<<<<

            //--------ADD BY lingxiaoqing 2011.08.08 ---------->>>>>>>>>>>
            this.tEdit_SectionCodeAllowZero2.Clear();                    // ���_�R�[�h
            this.SectionName_tEdit.Clear();                             // ���_����
            this.tNedit_CustomerCode.Clear();                           // ���Ӑ�
            this.CustomerCodeNm_tEdit.Clear();                          // ���Ӑ於 
            this.Discriminition_ComboEditor.SelectedIndex = 0;          //�D��K�p�敪
            this.SetKind_tComboEditor.SelectedIndex = 0;                //�ݒ���
            this.PureSuperio_ComboEditor.SelectedIndex = 0;             //�I�����Ώۏ��D�敪       
            this.InStock_ComboEditor.SelectedIndex = 0;                 //�I�����Ώۍ݌ɋ敪
            this.CampingCode_ComboEditor.SelectedIndex = 0;             //�I�����ΏۃL�����y�[���敪
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
            //this.PureSuperio1_ComboEditor.SelectedIndex = 0;            //��I�����Ώۏ��D�敪   
            //this.InStock1_ComboEditor.SelectedIndex = 0;                //��I�����Ώۍ݌ɋ敪
            //this.CampingCode1_ComboEditor.SelectedIndex = 0;            //��I�����ΏۃL�����y�[���敪
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
            this.PriorPriceSetCd1_tComboEditor.SelectedIndex = 0;       // �I�����Ώۉ��i�敪�P
            this.PriorPriceSetCd2_tComboEditor.SelectedIndex = 0;       // �I�����Ώۉ��i�敪�Q
            this.PriorPriceSetCd3_tComboEditor.SelectedIndex = 0;       // �I�����Ώۉ��i�敪�R
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
            //this.PriorPriceSetCd4_tComboEditor.SelectedIndex = 0;       // ��I�����Ώۉ��i�敪�P
            //this.PriorPriceSetCd5_tComboEditor.SelectedIndex = 0;       // ��I�����Ώۉ��i�敪�Q
            //this.PriorPriceSetCd6_tComboEditor.SelectedIndex = 0;       // ��I�����Ώۉ��i�敪�R
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
            this.Order1_ComboEditor.SelectedIndex = 0;                 //�����I����1
            this.Order2_ComboEditor.SelectedIndex = 0;                  //�����I����2
            this.Order3_ComboEditor.SelectedIndex = 0;                  //�����I����3
            this.Order4_ComboEditor.SelectedIndex = 0;                  //�����I����4
            this.Order5_ComboEditor.SelectedIndex = 0;                  //�����I����5
            this.Order6_ComboEditor.SelectedIndex = 0;                  //�����I����6
            this.Order7_ComboEditor.SelectedIndex = 0;                   //�����I����7
            //--------ADD BY lingxiaoqing 2011.08.08 ----------<<<<<<<<<
        }

        /// <summary>
        /// SCM�D��ݒ�N���X��ʓW�J����
        /// </summary>
        /// <param name="scmPriorSt">SCM�D��ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : SCM�D��ݒ�I�u�W�F�N�g�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Update Note : BL�p�[�c�I�[�_�[�����񓚕s��Ή�</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2018/07/26</br>
        /// <br></br>
        /// </remarks>
        private void SCMPriorStToScreen(SCMPriorSt scmPriorSt)
        {
            //--------ADD BY lingxiaoqing 2011.08.08 ---------->>>>>>>>>>
            //// ���_�R�[�h
            //this.tEdit_SectionCodeAllowZero.DataText = scmPriorSt.SectionCode;
            //// ���_����
            //string sectionName = string.Empty;
            //if (scmPriorSt.SectionCode.Trim().Equals(ALL_SECTIONCODE))
            //{
            //    sectionName = "�S�Ћ���";
            //}
            //else
            //{
            //    sectionName = this.GetSectionName(scmPriorSt.SectionCode);
            //}
            //this.SectionName_tEdit.DataText = sectionName;
            // �D��ݒ�
            //this.PrioritySetting_tComboEditor.Value = (scmPriorSt.PrioritySettingCd1 * 10) + scmPriorSt.PrioritySettingCd2;

            // �D�承�i�ݒ�P
            //this.PriorPriceSetCd1_tComboEditor.Value = scmPriorSt.PriorPriceSetCd1;

            // �D�承�i�ݒ�Q
            //this.PriorPriceSetCd2_tComboEditor.Value = scmPriorSt.PriorPriceSetCd2;

            // �D�承�i�ݒ�R
            //this.PriorPriceSetCd3_tComboEditor.Value = scmPriorSt.PriorPriceSetCd3;
            //--------ADD BY lingxiaoqing 2011.08.08 ----------<<<<<<<<<

            //-------------ADD BY lingxiaoqing 2011.08.08 ---------->>>>>>>>>>>>>>>>
            //�ݒ���
            if (scmPriorSt.CustomerCode == 0)
            {
                this.SetKind_tComboEditor.Value = 0;
                this.Discriminition_ComboEditor.Enabled = false;
                this.SetKind_tComboEditor.Enabled = false;
                this.tEdit_SectionCodeAllowZero2.Enabled = false;
                this.SectionGuide_Button.Enabled = false;
                // ���_�R�[�h
                this.tEdit_SectionCodeAllowZero2.DataText = scmPriorSt.SectionCode.ToString();
                // ���_����
                string sectionName = string.Empty;
                if (scmPriorSt.SectionCode.Trim().Equals(ALL_SECTIONCODE))
                {
                    sectionName = "�S�Ћ���";
                }
                else
                {
                    sectionName = this.GetSectionName(scmPriorSt.SectionCode);
                }
                this.SectionName_tEdit.DataText = sectionName;
            }
            else
            {
                this.SetKind_tComboEditor.Value = 1;
                this.Discriminition_ComboEditor.Enabled = false;
                this.SetKind_tComboEditor.Enabled = false;
                this.tNedit_CustomerCode.Enabled = false;
                this.uButton_CustomerGuide.Enabled = false;
                //���Ӑ�R�[�h
                this.tNedit_CustomerCode.DataText = scmPriorSt.CustomerCode.ToString().TrimEnd().PadLeft(8, '0');
                if (scmPriorSt.CustomerCode == 0)
                {
                    this.CustomerCodeNm_tEdit.Text = _customerName;  // ���Ӑ於�̎擾
                }
                else
                {
                    foreach (DictionaryEntry customer in _customersList)
                    {
                        if ((int)customer.Key == scmPriorSt.CustomerCode)
                        {
                            this.CustomerCodeNm_tEdit.Text = (string)customer.Value;
                        }
                    }
                }
            }
            //�D��K�p�敪
            this.Discriminition_ComboEditor.Value = scmPriorSt.PriorAppliDiv;

            //�I�����Ώۏ��D�敪���D�敪
            this.PureSuperio_ComboEditor.Value = scmPriorSt.SelTgtPureDiv;
            //�I�����Ώۏ��D�敪�݌ɋ敪
            this.InStock_ComboEditor.Value = scmPriorSt.SelTgtStckDiv;
            //�I�����Ώۏ��D�敪�L�����y�[���敪
            this.CampingCode_ComboEditor.Value = scmPriorSt.SelTgtCampDiv;
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
            ////��I�����Ώۏ��D�敪���D�敪
            //this.PureSuperio1_ComboEditor.Value = scmPriorSt.UnSelTgtPureDiv;
            ////��I�����Ώۏ��D�敪�݌ɋ敪
            //this.InStock1_ComboEditor.Value = scmPriorSt.UnSelTgtStckDiv;
            ////��I�����Ώۏ��D�敪�L�����y�[���敪
            //this.CampingCode1_ComboEditor.Value = scmPriorSt.UnSelTgtCampDiv;
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
            // �I�����Ώۉ��i�敪�P
            this.PriorPriceSetCd1_tComboEditor.Value = scmPriorSt.SelTgtPricDiv1;
            // �I�����Ώۉ��i�敪�Q
            this.PriorPriceSetCd2_tComboEditor.Value = scmPriorSt.SelTgtPricDiv2;
            // �I�����Ώۉ��i�敪 3
            this.PriorPriceSetCd3_tComboEditor.Value = scmPriorSt.SelTgtPricDiv3;
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
            //// ��I�����Ώۉ��i�敪�P
            //this.PriorPriceSetCd4_tComboEditor.Value = scmPriorSt.UnSelTgtPricDiv1;
            //// ��I�����Ώۉ��i�敪 2
            //this.PriorPriceSetCd5_tComboEditor.Value = scmPriorSt.UnSelTgtPricDiv2;
            //// ��I�����Ώۉ��i�敪�R
            //this.PriorPriceSetCd6_tComboEditor.Value = scmPriorSt.UnSelTgtPricDiv3;
            // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
            //�����I����1
            this.Order1_ComboEditor.Value = scmPriorSt.PrioritySettingCd1;
            //�����I����2
            this.Order2_ComboEditor.Value = scmPriorSt.PrioritySettingCd2;
            //�����I����3
            this.Order3_ComboEditor.Value = scmPriorSt.PrioritySettingCd3;
            //�����I����4
            this.Order4_ComboEditor.Value = scmPriorSt.PrioritySettingCd4;
            //�����I����5
            this.Order5_ComboEditor.Value = scmPriorSt.PrioritySettingCd5;
            //�����I����6
            this.Order6_ComboEditor.Value = scmPriorSt.PriorPriceSetCd1;
            //�����I����7
            this.Order7_ComboEditor.Value = scmPriorSt.PriorPriceSetCd2;
            //-------------ADD BY lingxiaoqing 2011.08.08 --------------<<<<<<<<<<<<<<


        }

        /// <summary>
        /// ��ʏ��SCM�D��ݒ�N���X�i�[����
        /// </summary>
        /// <param name="scmPriorSt">SCM�D��ݒ�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�SCM�D��ݒ�I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Update Note : BL�p�[�c�I�[�_�[�����񓚕s��Ή�</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2018/07/26</br>
        /// <br></br>
        /// </remarks>
        private void ScreenToSCMPriorSt(ref SCMPriorSt scmPriorSt)
        {
            if (scmPriorSt == null)
            {
                // �V�K�̏ꍇ
                scmPriorSt = new SCMPriorSt();
            }

            //��ƃR�[�h
            scmPriorSt.EnterpriseCode = this._enterpriseCode;
            //-------------DELETE BY lingxiaoqing 2011.08.08 -------------->>>>>>>>>>>>>>>
            // ���_�R�[�h
            //scmPriorSt.SectionCode = this.tEdit_SectionCodeAllowZero.DataText;   

            // �D��ݒ�
            //int prioritySetting = (int)this.PrioritySetting_tComboEditor.Value;
            //switch (prioritySetting)
            //{
            //    case 0:     // �Ȃ�
            //        {
            //            scmPriorSt.PrioritySettingCd1 = 0;
            //            scmPriorSt.PrioritySettingNm1 = ct_PRIORITY_NAME0;
            //            scmPriorSt.PrioritySettingCd2 = 0;
            //            scmPriorSt.PrioritySettingNm2 = ct_PRIORITY_NAME0;
            //            break;
            //        }
            //    case 50:    // �L�����y�[��
            //        {
            //            scmPriorSt.PrioritySettingCd1 = 5;
            //            scmPriorSt.PrioritySettingNm1 = ct_PRIORITY_NAME5;
            //            scmPriorSt.PrioritySettingCd2 = 0;
            //            scmPriorSt.PrioritySettingNm2 = ct_PRIORITY_NAME0;
            //            break;
            //        }
            //    case 56:    // �L�����y�[�����q��
            //        {
            //            scmPriorSt.PrioritySettingCd1 = 5;
            //            scmPriorSt.PrioritySettingNm1 = ct_PRIORITY_NAME5;
            //            scmPriorSt.PrioritySettingCd2 = 6;
            //            scmPriorSt.PrioritySettingNm2 = ct_PRIORITY_NAME6;
            //            break;
            //        }
            //    case 60:    // �q��
            //        {
            //            scmPriorSt.PrioritySettingCd1 = 6;
            //            scmPriorSt.PrioritySettingNm1 = ct_PRIORITY_NAME6;
            //            scmPriorSt.PrioritySettingCd2 = 0;
            //            scmPriorSt.PrioritySettingNm2 = ct_PRIORITY_NAME0;
            //            break;
            //        }
            //    case 65:    // �q�Ɂ��L�����y�[��
            //        {
            //            scmPriorSt.PrioritySettingCd1 = 6;
            //            scmPriorSt.PrioritySettingNm1 = ct_PRIORITY_NAME6;
            //            scmPriorSt.PrioritySettingCd2 = 5;
            //            scmPriorSt.PrioritySettingNm2 = ct_PRIORITY_NAME5;
            //            break;
            //        }
            //}

            //int inputCnt = 0;
            //for (int no = 0; no < MAX_PRIOR_PRICE_SET; no++)
            //{
            //    // �D�承�i�ݒ�̐ݒ�
            //    SetPriorPriceSet(no, ref scmPriorSt, ref inputCnt);
            //}
            //-------------DELETE BY lingxiaoqing 2011.08.08 --------------<<<<<<<<<<<<<

            //-------------ADD BY lingxiaoqing 2011.08.08 ------------->>>>>>>>>>>>>>>>>
            if (this.SetKind_tComboEditor.SelectedIndex == 0)
            {
                // ���_�R�[�h
                // ���_����
                string sectionName = string.Empty;
                if (this.tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0') == ALL_SECTIONCODE)
                {
                    // �S�Аݒ�
                    scmPriorSt.SectionCode = ALL_SECTIONCODE;
                }
                else
                {
                    // �S�Аݒ�ȊO
                    scmPriorSt.SectionCode = this.tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');

                }
                // ���Ӑ�R�[�h
                scmPriorSt.CustomerCode = 0;
            }
            else
            {
                // ���_�R�[�h
                scmPriorSt.SectionCode = "00";
                // ���Ӑ�R�[�h
                scmPriorSt.CustomerCode = this.tNedit_CustomerCode.GetInt();

            }
            //�D��K�p�敪
            scmPriorSt.PriorAppliDiv = Convert.ToInt32(this.Discriminition_ComboEditor.SelectedItem.DataValue);
            //�I�����Ώۏ��D�敪    
            scmPriorSt.SelTgtPureDiv = Convert.ToInt32(this.PureSuperio_ComboEditor.SelectedItem.DataValue);
            //�I�����Ώۍ݌ɋ敪
            scmPriorSt.SelTgtStckDiv = Convert.ToInt32(this.InStock_ComboEditor.SelectedItem.DataValue);
            //�I�����ΏۃL�����y�[���敪
            scmPriorSt.SelTgtCampDiv = Convert.ToInt32(this.CampingCode_ComboEditor.SelectedItem.DataValue);
            // ---UPD 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
            ////��I�����Ώۏ��D�敪    
            //scmPriorSt.UnSelTgtPureDiv = Convert.ToInt32(this.PureSuperio1_ComboEditor.SelectedItem.DataValue);
            ////��I�����Ώۍ݌ɋ敪
            //scmPriorSt.UnSelTgtStckDiv = Convert.ToInt32(this.InStock1_ComboEditor.SelectedItem.DataValue);
            ////��I�����ΏۃL�����y�[���敪
            //scmPriorSt.UnSelTgtCampDiv = Convert.ToInt32(this.CampingCode1_ComboEditor.SelectedItem.DataValue);
            //��I�����Ώۏ��D�敪    
            scmPriorSt.UnSelTgtPureDiv = 0;
            //��I�����Ώۍ݌ɋ敪
            scmPriorSt.UnSelTgtStckDiv = 0;
            //��I�����ΏۃL�����y�[���敪
            scmPriorSt.UnSelTgtCampDiv = 0;
            // ---UPD 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
            //�I�����Ώۉ��i�敪�P
            scmPriorSt.SelTgtPricDiv1 = Convert.ToInt32(this.PriorPriceSetCd1_tComboEditor.SelectedItem.DataValue);
            //�I�����Ώۉ��i�敪�Q
            scmPriorSt.SelTgtPricDiv2 = Convert.ToInt32(this.PriorPriceSetCd2_tComboEditor.SelectedItem.DataValue);
            //�I�����Ώۉ��i�敪 3
            scmPriorSt.SelTgtPricDiv3 = Convert.ToInt32(this.PriorPriceSetCd3_tComboEditor.SelectedItem.DataValue);
            // ---UPD 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
            ////��I�����Ώۉ��i�敪�P
            //scmPriorSt.UnSelTgtPricDiv1 = Convert.ToInt32(this.PriorPriceSetCd4_tComboEditor.SelectedItem.DataValue);
            ////��I�����Ώۉ��i�敪�Q
            //scmPriorSt.UnSelTgtPricDiv2 = Convert.ToInt32(this.PriorPriceSetCd5_tComboEditor.SelectedItem.DataValue);
            ////��I�����Ώۉ��i�敪 3
            //scmPriorSt.UnSelTgtPricDiv3 = Convert.ToInt32(this.PriorPriceSetCd6_tComboEditor.SelectedItem.DataValue);
            //��I�����Ώۉ��i�敪�P
            scmPriorSt.UnSelTgtPricDiv1 = 0;
            //��I�����Ώۉ��i�敪�Q
            scmPriorSt.UnSelTgtPricDiv2 = 0;
            //��I�����Ώۉ��i�敪 3
            scmPriorSt.UnSelTgtPricDiv3 = 0;
            // ---UPD 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
            // �D��ݒ�R�[�h�P
            scmPriorSt.PrioritySettingCd1 = Convert.ToInt32(this.Order1_ComboEditor.SelectedItem.DataValue);
            // �D��ݒ薼�̂P
            scmPriorSt.PrioritySettingNm1 = this.Order1_ComboEditor.SelectedItem.DisplayText;
            // �D��ݒ�R�[�h2
            scmPriorSt.PrioritySettingCd2 = Convert.ToInt32(this.Order2_ComboEditor.SelectedItem.DataValue);
            // �D��ݒ薼��2   
            scmPriorSt.PrioritySettingNm2 = this.Order2_ComboEditor.SelectedItem.DisplayText;
            // �D��ݒ�R�[�h3
            scmPriorSt.PrioritySettingCd3 = Convert.ToInt32(this.Order3_ComboEditor.SelectedItem.DataValue);
            // �D��ݒ薼��3
            scmPriorSt.PrioritySettingNm3 = this.Order3_ComboEditor.SelectedItem.DisplayText;
            // �D��ݒ�R�[�h4
            scmPriorSt.PrioritySettingCd4 = Convert.ToInt32(this.Order4_ComboEditor.SelectedItem.DataValue);
            // �D��ݒ薼��4
            scmPriorSt.PrioritySettingNm4 = this.Order4_ComboEditor.SelectedItem.DisplayText;
            // �D��ݒ�R�[�h5
            scmPriorSt.PrioritySettingCd5 = Convert.ToInt32(this.Order5_ComboEditor.SelectedItem.DataValue);
            // �D��ݒ薼��5
            scmPriorSt.PrioritySettingNm5 = this.Order5_ComboEditor.SelectedItem.DisplayText;
            // �D�承�i�ݒ�R�[�h1
            scmPriorSt.PriorPriceSetCd1 = Convert.ToInt32(this.Order6_ComboEditor.SelectedItem.DataValue);
            // �D�承�i�ݒ薼��1
            scmPriorSt.PriorPriceSetNm1 = this.Order6_ComboEditor.SelectedItem.DisplayText;
            // �D�承�i�ݒ�R�[�h2
            scmPriorSt.PriorPriceSetCd2 = Convert.ToInt32(this.Order7_ComboEditor.SelectedItem.DataValue);
            // �D�承�i�ݒ薼��2
            scmPriorSt.PriorPriceSetNm2 = this.Order7_ComboEditor.SelectedItem.DisplayText;
            // �D�承�i�ݒ�R�[�h3
            scmPriorSt.PriorPriceSetCd3 = 0;
            // �D�承�i�ݒ薼��3
            scmPriorSt.PriorPriceSetNm3 = ct_PRIORITY_NAME0;
            // �D�承�i�ݒ�R�[�h4
            scmPriorSt.PriorPriceSetCd4 = 0;
            // �D�承�i�ݒ薼��4
            scmPriorSt.PriorPriceSetNm4 = ct_PRIORITY_NAME0;
            // �D�承�i�ݒ�R�[�h5   
            scmPriorSt.PriorPriceSetCd5 = 0;
            // �D�承�i�ݒ薼��5
            scmPriorSt.PriorPriceSetNm5 = ct_PRIORITY_NAME0;
            //-------------ADD BY lingxiaoqing -----------------------------<<<<<<<<<<<<<<<<          

        }

        //-------------DELETE BY lingxiaoqing ----------------------------->>>>>>>>>>>>>>
        /// <summary>
        /// ��ʏ���SCM�D��ݒ�N���X�i�[����
        /// </summary>
        /// <br paramname="setNo">�ݒ�Ώۂ̗D�承�i�ݒ�̔ԍ�</br>
        /// <br paramname="scmPriorSt">�ۑ�����f�[�^�N���X</br>
        /// <br paramname="inputCnt">��ʓǍ��J�n�̃J�E���g��</br>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�SCM�[���ݒ�N���X�Ƀf�[�^���i�[���܂��B</br>
        /// <br></br>
        /// </remarks>
        //private void SetPriorPriceSet(int setNo, ref SCMPriorSt scmPriorSt, ref int inputCnt)
        //{
        //    int priorPriceSetCd = 0;
        //    string priorPriceSetNm = ct_PRIORITY_NAME0;

        //    int i;
        //    for (i = inputCnt; i < MAX_PRIOR_PRICE_SET; i++)
        //    {
        //        // ��ʂ̗D�承�i�ݒ�
        //        switch (i)
        //        {
        //            case 0:
        //                {
        //                    if ((int)this.PriorPriceSetCd1_tComboEditor.Value != 0)
        //                    {
        //                        priorPriceSetCd = (int)this.PriorPriceSetCd1_tComboEditor.SelectedItem.DataValue;
        //                        priorPriceSetNm = this.PriorPriceSetCd1_tComboEditor.SelectedItem.DisplayText;
        //                    }
        //                    break;
        //                }
        //            case 1:
        //                {
        //                    if ((int)this.PriorPriceSetCd2_tComboEditor.Value != 0)
        //                    {
        //                        priorPriceSetCd = (int)this.PriorPriceSetCd2_tComboEditor.SelectedItem.DataValue;
        //                        priorPriceSetNm = this.PriorPriceSetCd2_tComboEditor.SelectedItem.DisplayText;
        //                    }
        //                    break;
        //                }
        //            case 2:
        //                {
        //                    if ((int)this.PriorPriceSetCd3_tComboEditor.Value != 0)
        //                    {
        //                        priorPriceSetCd = (int)this.PriorPriceSetCd3_tComboEditor.SelectedItem.DataValue;
        //                        priorPriceSetNm = this.PriorPriceSetCd3_tComboEditor.SelectedItem.DisplayText;
        //                    }
        //                    break;
        //                }
        //        }

        //        if (priorPriceSetCd != 0)
        //        {
        //            // �D�承�i�ݒ���擾�ς̏ꍇ�A�擾�����I��
        //            break;
        //        }
        //    }

        //    // ����Ǎ��J�n�̃J�E���g���X�V
        //    inputCnt = ++i;

        //    // �f�[�^�N���X�̗D�承�i�ݒ�ɐݒ�
        //    switch (setNo)
        //    {
        //        case 0:
        //            {
        //                scmPriorSt.PriorPriceSetCd1 = priorPriceSetCd;      //�D�承�i�ݒ�R�[�h�P
        //                scmPriorSt.PriorPriceSetNm1 = priorPriceSetNm;      //�D�承�i�ݒ薼�̂P
        //                break;
        //            }
        //        case 1:
        //            {
        //                scmPriorSt..PriorPriceSetCd2 = priorPriceSetCd;      // �D�承�i�ݒ�R�[�h�Q
        //                scmPriorSt.PriorPriceSetNm2 = priorPriceSetNm;       // �D�承�i�ݒ薼�̂Q
        //                break;
        //            }
        //        case 2:
        //            {
        //                scmPriorSt.PriorPriceSetCd3 = priorPriceSetCd;       // �D�承�i�ݒ�R�[�h�R
        //                scmPriorSt..PriorPriceSetNm3 = priorPriceSetNm;      // �D�承�i�ݒ薼�̂P�R
        //                break;
        //            }               
        //    }
        //}
        //-------------DELETE BY lingxiaoqing -----------------------------<<<<<<<<<<<<<<

        /// <summary>
        /// �t�H�[���N���[�Y����
        /// </summary>
        /// <param name="dialogResult">�_�C�A���O����</param>
        /// <remarks>
        /// <br>Note       : �t�H�[������܂��B���̍ۉ�ʃN���[�Y�C�x���g���̔������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // _GridIndex�o�b�t�@�������i���C���t���[���ŏ����Ή��j
            this._indexBuf = -2;

            // ��r�p�N���[���N���A
            this._scmPriorStClone = null;

            // �t�H�[�����\��������B
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br></br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
                            0, 									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);				// �\������{�^��
                        if (hide == true)
                        {
                            CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        ///	SCM�D��ݒ��ʓ��̓`�F�b�N����
        /// </summary>
        /// <param name="control">�s���ΏۃR���g���[��</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�`�F�b�N����(true:OK�^false:NG)</returns>
        /// <remarks>
        /// <br>Note	   : SCM�D��ݒ��ʂ̓��̓`�F�b�N�����܂��B</br>
        /// <br></br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {

            //---------DELETE BY lingxiaoqing  2011.08.08------------>>>>>>>>>>>>>>>>>
            // ���_�R�[�h
            //if (this.tEdit_SectionCodeAllowZero.DataText == "")
            //{
            //    message = this.Section_uLabel.Text + "��ݒ肵�ĉ������B";
            //    control = this.tEdit_SectionCodeAllowZero;
            //    return false;
            //}

            //ArrayList chkList = new ArrayList();
            //// �D�承�i�ݒ�P
            //if ((int)this.PriorPriceSetCd1_tComboEditor.Value != 0)
            //{
            //    if (chkList.Contains(this.PriorPriceSetCd1_tComboEditor.Value))
            //    {
            //        message = "�D�承�i�ݒ肪�d�����Ă��܂��B";
            //        control = this.PriorPriceSetCd1_tComboEditor;
            //        return false;
            //    }
            //    else
            //    {
            //        chkList.Add(this.PriorPriceSetCd1_tComboEditor.Value);
            //    }
            //}

            //// �D�承�i�ݒ�Q
            //if ((int)this.PriorPriceSetCd2_tComboEditor.Value != 0)
            //{
            //    if (chkList.Contains(this.PriorPriceSetCd2_tComboEditor.Value))
            //    {
            //        message = "�D�承�i�ݒ肪�d�����Ă��܂��B";
            //        control = this.PriorPriceSetCd2_tComboEditor;
            //        return false;
            //    }
            //    else
            //    {
            //        chkList.Add(this.PriorPriceSetCd2_tComboEditor.Value);
            //    }
            //}

            //// �D�承�i�ݒ�R
            //if ((int)this.PriorPriceSetCd3_tComboEditor.Value != 0)
            //{
            //    if (chkList.Contains(this.PriorPriceSetCd3_tComboEditor.Value))
            //    {
            //        message = "�D�承�i�ݒ肪�d�����Ă��܂��B";
            //        control = this.PriorPriceSetCd3_tComboEditor;
            //        return false;
            //    }
            //    else
            //    {
            //        chkList.Add(this.PriorPriceSetCd3_tComboEditor.Value);
            //    }
            //}
            //---------DELETE BY lingxiaoqing  2011.08.08------------<<<<<<<<<<<<<<<<<<
            //---------ADD BY lingxiaoqing  2011.08.08------------>>>>>>>>>>>>>>>>>
            if (SetKind_tComboEditor.SelectedIndex == 0)
            {
                // ���_�R�[�h
                if (this.tEdit_SectionCodeAllowZero2.DataText == "")
                {
                    message = this.Section_uLabel.Text + "��ݒ肵�ĉ������B";
                    control = this.tEdit_SectionCodeAllowZero2;
                    return false;
                }
                // --- ADD 2011/09/07 -------------------------------->>>>>
                this.tEdit_SectionCodeAllowZero2.DataText = tEdit_SectionCodeAllowZero2.Text.Trim().PadLeft(2, '0');

                // ���_�R�[�h�擾
                string sectionCode = this.tEdit_SectionCodeAllowZero2.DataText;

                // ���_���̎擾
                string sectionName = GetSectionName(sectionCode);
                if (sectionName == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���_�����݂��܂���B",
                        -1,
                        MessageBoxButtons.OK
                    );
                    message = string.Empty;
                    control = this.tEdit_SectionCodeAllowZero2;
                    this.tEdit_SectionCodeAllowZero2.Clear();
                    return false;
                }
                this.SectionName_tEdit.DataText = sectionName;

                // ���_�R�[�h�̑��݃`�F�b�N
                bool existCheck = false;
                // �S�Ћ��ʂ͋��_�}�X�^�ɓo�^����Ă��Ȃ����߁A�`�F�b�N�̑ΏۊO
                if (!SectionUtil.IsAllSection(this.tEdit_SectionCodeAllowZero2.DataText) || this.tEdit_SectionCodeAllowZero2.DataText == "0")
                {
                    foreach (SecInfoSet si in this._secInfoAcs.SecInfoSetList)
                    {
                        if (si.SectionCode.TrimEnd() == this.tEdit_SectionCodeAllowZero2.DataText)
                        {
                            existCheck = true;
                            break;
                        }
                    }
                }
                else
                {
                    existCheck = true;
                }

                if (!existCheck)
                {
                    message = "�w�肵�����_�R�[�h�͑��݂��܂���B";
                    control = this.tEdit_SectionCodeAllowZero2;
                    this.tEdit_SectionCodeAllowZero2.Clear();
                    return false;
                }
                // --- ADD 2011/09/07 --------------------------------<<<<<

            }
            //-------------ADD BY lingxiaoqing 2011.08.08 ------------->>>>>>>>>>>>>>>>>
            else
            {
                // ���Ӑ�R�[�h
                if (this.tNedit_CustomerCode.DataText == "")
                {
                    message = this.CustomerCode_Title_Label.Text + "��ݒ肵�ĉ������B";
                    control = this.tNedit_CustomerCode;
                    return false;
                }
            }

            //�����I���� 
            ArrayList selectedList = new ArrayList();
            selectedList.Add(this.Order1_ComboEditor.SelectedIndex);
            selectedList.Add(this.Order2_ComboEditor.SelectedIndex);
            selectedList.Add(this.Order3_ComboEditor.SelectedIndex);
            selectedList.Add(this.Order4_ComboEditor.SelectedIndex);
            selectedList.Add(this.Order5_ComboEditor.SelectedIndex);
            selectedList.Add(this.Order6_ComboEditor.SelectedIndex);
            selectedList.Add(this.Order7_ComboEditor.SelectedIndex);
            ArrayList compentList = new ArrayList();
            compentList.Add(this.Order1_ComboEditor);
            compentList.Add(this.Order2_ComboEditor);
            compentList.Add(this.Order3_ComboEditor);
            compentList.Add(this.Order4_ComboEditor);
            compentList.Add(this.Order5_ComboEditor);
            compentList.Add(this.Order6_ComboEditor);
            compentList.Add(this.Order7_ComboEditor);
            for (int i = 0; i < selectedList.Count; i++)
            {
                if ((int)selectedList[i] != 0)
                {
                    for (int j = i; j < compentList.Count - 1; j++)
                    {
                        if ((int)selectedList[i] == (int)selectedList[j + 1])
                        {
                            message = ct_ORDER_MESSAGE1;
                            control = (Control)compentList[j + 1];
                            return false;
                        }
                    }
                }
                if ((int)selectedList[i] == 3 || (int)selectedList[i] == 4)
                {
                    for (int j = i; j < compentList.Count - 1; j++)
                    {
                        if ((int)selectedList[j + 1] == 4 || (int)selectedList[j + 1] == 3)
                        {
                            message = ct_ORDER_MESSAGE2;
                            control = (Control)compentList[j + 1];
                            return false;
                        }
                    }
                }
            }
            //-------------ADD BY lingxiaoqing 2011.08.08-----------------------------<<<<<<<<<<<<<<<<<<<           
            return true;
        }

        /// <summary>
        ///�@�ۑ�����(SaveProc())
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private bool SaveProc()
        {
            bool result = false;

            //��ʃf�[�^���̓`�F�b�N����
            Control control = null;
            string message = null;
            if (!ScreenDataCheck(ref control, ref message))
            {
                // --- ADD 2011/09/07 -------------------------------->>>>>
                if (!string.IsNullOrEmpty(message))
                {
                    // --- ADD 2011/09/07 --------------------------------<<<<<
                    // ���̓`�F�b�N
                    TMsgDisp.Show(
                        this, 								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                        PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                        message, 							// �\�����郁�b�Z�[�W
                        0, 									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��
                }//ADD 2011/09/07
                control.Focus();
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                else if (control is TEdit)
                {
                    ((TEdit)control).SelectAll();
                }
                return result;
            }

            // ----- ADD 2011/09/07 ---------->>>>>
            // ���_
            if (this.tEdit_SectionCodeAllowZero2.Focused)
            {
                ChangeFocusEventArgs eArgs = new ChangeFocusEventArgs(false, false, false, Keys.Enter, this.tEdit_SectionCodeAllowZero2, this.tEdit_SectionCodeAllowZero2);
                this.tEdit_SectionCodeAllowZero2.Text = this.tEdit_SectionCodeAllowZero2.Text.PadLeft(2, '0');
                tRetKeyControl1_ChangeFocus(null, eArgs);
                if (isError == true)
                {
                    result = false;
                    return result;
                }
            }
            // ----- ADD 2011/09/07 ----------<<<<<

            SCMPriorSt scmPriorSt = null;

            if (this.DataIndex >= 0)
            {
                Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
                scmPriorSt = ((SCMPriorSt)this._scmPriorStTable[guid]).Clone();
                _isNewSave = false; // ADD BY lingxiaoqing on 2011.08.08 for �f�[�^�͍X�V����
            }
            else
            {
                _isNewSave = true; // ADD BY lingxiaoqing on 2011.08.08 for �f�[�^�͍X�V���Ȃ�
            }
            // ��ʏ����擾           
            ScreenToSCMPriorSt(ref scmPriorSt);
            // �o�^�E�X�V����
            int status = this._scmPriorStAcs.Write(ref scmPriorSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        RepeatTransaction(status, ref control);
                        control.Focus();
                        return false;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, true);

                        if (UnDisplaying != null)
                        {
                            MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                            UnDisplaying(this, me);
                        }

                        this.DialogResult = DialogResult.Cancel;
                        this._indexBuf = -2;

                        if (CanClose == true)
                        {
                            this.Close();
                        }
                        else
                        {
                            this.Hide();
                        }
                        return false;
                    }
                default:
                    {
                        TMsgDisp.Show(this,                         // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
                            PROGRAM_ID,							    // �A�Z���u��ID
                            this.Text,  �@�@                        // �v���O��������
                            "SaveProc",                             // ��������
                            TMsgDisp.OPE_UPDATE,                    // �I�y���[�V����
                            "�o�^�Ɏ��s���܂����B",				    // �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            this._scmPriorStAcs,				    	// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,			  		// �\������{�^��
                            MessageBoxDefaultButton.Button1);		// �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return false;
                    }
            }
            //----------ADD BY lingxiaoqing 2011.08.08 ------------->>>>>>>>>>>>>
            if (!_customersList.Contains(scmPriorSt.CustomerCode))
            {
                _customersList.Add(scmPriorSt.CustomerCode, this.CustomerCodeNm_tEdit.DataText);
            }
            //----------ADD BY lingxiaoqing 2011.08.08 -------------<<<<<<<<<<<<<
            // SCM�D��ݒ���N���X�̃f�[�^�Z�b�g�W�J����
            SCMPriorStToDataSet(scmPriorSt, this.DataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
            this.DialogResult = DialogResult.OK;
            this._indexBuf = -2;

            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
            result = true;
            return result;
        }


        /// <summary>
        ///�@���������b�Z�[�W�\��
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : �Y���R�[�h���g�p����Ă���ꍇ�Ƀ��b�Z�[�W��\�����܂��B</br>
        /// <br></br>
        /// </remarks>
        private void RepeatTransaction(int status, ref Control control)
        {
            TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                "���̃R�[�h�͊��Ɏg�p����Ă��܂�",// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                MessageBoxButtons.OK);				// �\������{�^��
            //------------ADD BY lingxiaoqing 2011.08.08 ----------->>>>>>>>>>>>
            if (this.SetKind_tComboEditor.SelectedIndex == 0)
            {
                tEdit_SectionCodeAllowZero2.Focus();
                control = tEdit_SectionCodeAllowZero2;
            }
            else
            {
                this.tNedit_CustomerCode.Focus();
                control = this.tNedit_CustomerCode;
            }
            //------------ADD BY lingxiaoqing 2010.08.08 -----------<<<<<<<<<<<<<<
        }

        /// <summary>
        /// �R���g���[���T�C�Y�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���g���[���̃T�C�Y�ݒ菈�����s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tEdit_SectionCodeAllowZero2.Size = new System.Drawing.Size(28, 24);
            this.SectionName_tEdit.Size = new System.Drawing.Size(195, 24);
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_���� ���Y��������̂������ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            // �S�Ћ��ʃ`�F�b�N
            if (sectionCode.Trim().PadLeft(2, '0') == ALL_SECTIONCODE)
            {
                sectionName = "�S�Ћ���";
                return sectionName;
            }

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        return sectionName;
                    }
                }
                sectionName = null;
            }
            catch
            {
                sectionName = null;
            }

            return sectionName;
        }

        /// <summary>
        /// ���[�h�ύX����
        /// </summary>
        private bool ModeChangeProc()
        {
            isError = false;//ADD 2011/09/07
            string msg = "���͂��ꂽ�R�[�h��SCM�D��ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";

            // ���_�R�[�h
            string sectionCd = tEdit_SectionCodeAllowZero2.Text.TrimEnd().PadLeft(2, '0');
            string priorAppliDivCd = this.Discriminition_ComboEditor.SelectedItem.DisplayText; //ADD BY lingxiaoqing on 2011.08.08 for �敪�D��K�p�敪

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsSecCd = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_SECTION_CODE_TITLE];
                string priorAppliDiv = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_PRIORITY_DISCRIMITION];//ADD BY  lingxiaoqing on 2011.08.08 for �敪�D��K�p�敪
                //if (sectionCd.Equals(dsSecCd.TrimEnd())) // DELETE BY lingxiaoqing on 2011.08.08 for ���̑��̏�����Y�����܂�
                if (sectionCd.Equals(dsSecCd.TrimEnd()) && priorAppliDivCd.Equals(priorAppliDiv.TrimEnd()))// ADD BY lingxiaoqing on 2011.08.08 for ���̑��̏�����Y�����܂�
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h��SCM�D��ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        isError = true; // ADD 2011/09/07
                        // ���_�R�[�h�A���̂̃N���A
                        tEdit_SectionCodeAllowZero2.Clear();
                        SectionName_tEdit.Clear();
                        return true;
                    }

                    if (sectionCd == ALL_SECTIONCODE)
                    {
                        // �S�Ћ��ʂ̃��b�Z�[�W�ύX
                        msg = "���͂��ꂽ�R�[�h��SCM�D��ݒ��񂪊��ɓo�^����Ă��܂��B\n�@�y���_���́F�S�Ћ��ʁz\n�ҏW���s���܂����H";
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        PROGRAM_ID,                             // �A�Z���u���h�c�܂��̓N���X�h�c
                        msg,                                    // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    isError = true; // ADD 2011/09/07
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ���_�R�[�h�A���̂̃N���A
                                tEdit_SectionCodeAllowZero2.Clear();
                                SectionName_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }

        # endregion

        //------------ADD BY lingxiaoqing 2011.08.08 ----------->>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���[�h�ύX�����@�@�@�@�@�@�@�@�@�@�@�@�@�@
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ惂�[�h�ύX����</br>                   
        /// <br>Programmer : ������</br>                               
        /// <br>Date       : 2011.08.08</br>                                         
        /// </remarks>
        private bool CusModeChangeProc()
        {
            string msg = "���͂��ꂽ�R�[�h��SCM�D��ݒ��񂪊��ɓo�^����Ă��܂��B\n�ҏW���s���܂����H";

            // ���Ӑ�R�[�h
            string customerCd = this.tNedit_CustomerCode.Text.TrimEnd().PadLeft(8, '0');
            string priorAppliDivCd = this.Discriminition_ComboEditor.SelectedItem.DisplayText;

            for (int i = 0; i < this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count; i++)
            {
                // �f�[�^�Z�b�g�Ɣ�r
                string dsCusCd = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_CUSTOMER_CODE_TITLE];
                string priorAppliDiv = (string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][VIEW_PRIORITY_DISCRIMITION];
                if (customerCd.Equals(dsCusCd.TrimEnd()) && priorAppliDivCd.Equals(priorAppliDiv.TrimEnd()))
                {
                    // ���̓R�[�h���f�[�^�Z�b�g�ɑ��݂���ꍇ
                    if ((string)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // �_���폜
                        TMsgDisp.Show(this, 					// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "���͂��ꂽ�R�[�h��SCM�D��ݒ���͊��ɍ폜����Ă��܂��B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��
                        // ���Ӑ�R�[�h�A���̂̃N���A
                        this.tNedit_CustomerCode.Clear();
                        CustomerCodeNm_tEdit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO,            // �G���[���x��
                        PROGRAM_ID,                             // �A�Z���u���h�c�܂��̓N���X�h�c
                        msg,                                    // �\�����郁�b�Z�[�W
                        0,                                      // �X�e�[�^�X�l
                        MessageBoxButtons.YesNo);               // �\������{�^��
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // ��ʍĕ`��
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // ���Ӑ�R�[�h�A���̂̃N���A
                                this.tNedit_CustomerCode.Clear();
                                CustomerCodeNm_tEdit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        //------------ADD BY lingxiaoqing 2011.08.08 -----------<<<<<<<<<<<<<<

        # region -- Control Events --
        /// <summary>
        ///	Form.Load �C�x���g(PMSCM09060UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void PMSCM09060UA_Load(object sender, System.EventArgs e)
        {
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;
            this.Delete_Button.ImageList = imageList24;
            this.Revive_Button.ImageList = imageList24;
            this.Renewal_Button.ImageList = imageList16;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
            this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
            this.Renewal_Button.Appearance.Image = Size16_Index.RENEWAL;

            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            // ���Ӑ�R�[�h�K�C�h�{�^���̉摜�C���[�W�ǉ� 
            this.uButton_CustomerGuide.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1]; //ADD BY lingxiaoqing 2011.08.08

            // �R���g���[���T�C�Y�ݒ�
            SetControlSize();

            // ��ʏ����ݒ菈��  DELETE BY lingxiaoqing 2011.08.08
            //ScreenInitialSetting();
        }

        /// <summary>
        ///	Form.Closing �C�x���g(PMSCM09060UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�L�����Z���ł���C�x���g�̃f�[�^��񋟂���N���X</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�������O�ɁA���[�U�[���t�H�[�����
        ///					  �悤�Ƃ����Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void PMSCM09060UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this._indexBuf = -2;
            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            //�i�t�H�[���́u�~�v���N���b�N���ꂽ�ꍇ�̑Ή��ł��B�j
            if (CanClose == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        /// <summary>
        ///	Form.VisibleChanged �C�x���g(PMSCM09060UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: �t�H�[���̕\���E��\�����؂�ւ����
        ///					  ���Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void PMSCM09060UA_VisibleChanged(object sender, System.EventArgs e)
        {
            // �������g����\���ɂȂ����ꍇ�͈ȉ��̏������L�����Z������B
            if (this.Visible == false)
            {
                // ���C���t���[���A�N�e�B�u��
                this.Owner.Activate();
                return;
            }

            // �������g����\���ɂȂ����ꍇ�A
            // �܂��̓^�[�Q�b�g���R�[�h(Index)���ς���Ă��Ȃ��ꍇ�͈ȉ��̏������L�����Z������
            if (this._indexBuf == this._dataIndex)
            {
                return;
            }

            // ��ʃN���A
            ScreenClear();

            Timer.Enabled = true;
        }

        /// <summary>
        /// Control.Click �C�x���g(Ok_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �ۑ��{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Ok_Button_Click(object sender, System.EventArgs e)
        {
            // �o�^�E�X�V����
            if (!SaveProc())
            {
                return;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Cancel_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, System.EventArgs e)
        {
            // �폜���[�h�E�Q�ƃ��[�h�ȊO�̏ꍇ�͕ۑ��m�F�������s��
            if (this.Mode_Label.Text != DELETE_MODE)
            {
                // ��ʂ̃f�[�^���擾����
                SCMPriorSt compareSCMPriorSt = new SCMPriorSt();

                compareSCMPriorSt = this._scmPriorStClone.Clone();
                ScreenToSCMPriorSt(ref compareSCMPriorSt);

                // ��ʏ��ƋN�����̃N���[���Ɣ�r���ύX���Ď�����
                if ((!(this._scmPriorStClone.Equals(compareSCMPriorSt))))
                {
                    // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                    DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                        //emErrorLevel.ERR_LEVEL_SAVECONFIRM,                 // �G���[���x�� //DELETE BY lingxiaoqing 2010.08.08
                        emErrorLevel.ERR_LEVEL_QUESTION,                      // �G���[���x�� //ADD BY lingxiaoqing 2010.08.08 FOR PCCUOE-0195
                        PROGRAM_ID, 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
                        //null, 					                          // �\�����郁�b�Z�[�W //DELETE BY lingxiaoqing 2010.08.08
                        "���݁A�ΏW���̃f�[�^�����݂��܂��B\r\n" +
                        "�j�����Ă���낵���ł����H", 					      // �\�����郁�b�Z�[�W //ADD BY lingxiaoqing 2010.08.08 FOR PCCUOE-0195 
                        0, 					                                  // �X�e�[�^�X�l
                        //MessageBoxButtons.YesNoCancel);	                  // �\������{�^�� //DELETE BY lingxiaoqing 2010.08.08 
                        MessageBoxButtons.YesNo,                              // �\������{�^�� //ADD BY lingxiaoqing 2010.08.08 FOR PCCUOE-0195 
                         MessageBoxDefaultButton.Button2);	                  // �\������{�^�� //ADD BY lingxiaoqing 2010.08.08 FOR PCCUOE-0195 

                    switch (res)
                    {
                        case DialogResult.Yes:
                            {

                                //----------DELETE BY lingxiaoqing 2010.08.08 ---------->>>>>>>>>>>
                                //if (!SaveProc())
                                //{
                                //    return;
                                //}
                                //return;
                                //----------DELETE BY lingxiaoqing 2010.08.08 ----------<<<<<<<<<<<
                                break;  //ADD BY lingxiaoqing 2010.08.08 FOR PCCUOE-0195 
                            }
                        case DialogResult.No:
                            {
                                //----------DELETE BY lingxiaoqing 2010.08.08 ---------->>>>>>>>>>>
                                //��ʔ�\���C�x���g
                                //if (UnDisplaying != null)
                                //{
                                //    MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.No);
                                //    UnDisplaying(this, me);
                                //}
                                //break;
                                //----------DELETE BY lingxiaoqing 2010.08.08 ----------<<<<<<<<<<<<
                                return; //ADD BY lingxiaoqing 2010.08.08 FOR PCCUOE-0195 
                            }
                        default:
                            {
                                // �V�K���[�h���烂�[�h�ύX�Ή�
                                if (_modeFlg)
                                {
                                    tEdit_SectionCodeAllowZero2.Focus();
                                    _modeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                //-------ADD BY lingxiaoqing 2011.08.08 ------------>>>>>>>>>>>>>>
                                if (_cusModeFlg)
                                {
                                    this.tNedit_CustomerCode.Focus();
                                    _cusModeFlg = false;
                                }
                                else
                                {
                                    this.Cancel_Button.Focus();
                                }
                                //-------ADD BY lingxiaoqing 2011.08.08 ------------<<<<<<<<<<<<<
                                return;
                            }
                    }
                }
            }

            this.DialogResult = DialogResult.Cancel;
            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Timer.Tick �C�x���g(timer)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B
        ///					  ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��
        ///					  �X���b�h�Ŏ��s����܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Timer_Tick(object sender, System.EventArgs e)
        {
            Timer.Enabled = false;

            // ��ʕ\������
            ScreenReconstruction();
        }

        /// <summary>
        /// Control.Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_�K�C�h�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();
                SecInfoSet secInfoSet = new SecInfoSet();

                status = secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    this.tEdit_SectionCodeAllowZero2.DataText = secInfoSet.SectionCode.Trim();
                    this.SectionName_tEdit.DataText = secInfoSet.SectionGuideNm.Trim();

                    //this.PrioritySetting_tComboEditor.Focus(); //DELETE BY lingxiaoqing 2011.08.08
                    //------ADD BY lingxiaoqing 2011.08.08------------------>>>>>>>>>>>>>>>>>                    
                    this.PureSuperio_ComboEditor.Focus();
                    this.tNedit_CustomerCode.Clear();
                    this.CustomerCodeNm_tEdit.Clear();
                    //------ADD BY lingxiaoqing 2011.08.08------------------<<<<<<<<<<<<<<<<<

                    // �V�K���[�h���烂�[�h�ύX�Ή�
                    if (this.DataIndex < 0)
                    {
                        if (ModeChangeProc())
                        {
                            SectionGuide_Button.Focus();
                        }
                    }
                }
                //--------DELETE BY lingxiaoqing 2011.08.08 ---------->>>>>>>>>>>
                //else if (status == 1)
                //{
                //    // [�߂�]�̏ꍇ
                //    if (ModeChangeProc())
                //    {
                //        SectionGuide_Button.Focus();
                //    }
                //}
                //--------DELETE BY lingxiaoqing 2011.08.08 ----------<<<<<<<<<<<<
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        //------------ADD BY lingxiaoqing 2011.08.08 ----------->>>>>>>>>>>>>>
        /// <summary>
        /// ���Ӑ�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���Ӑ�K�C�h�{�^���N���b�N�C�x���g�B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void ub_St_CustomerGuide_Click(object sender, EventArgs e)
        {
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_NORMAL, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);
            this.PureSuperio_ComboEditor.Focus();
        }
        //------------ADD BY lingxiaoqing 2011.08.08 -----------<<<<<<<<<<<<<<


        //------------ADD BY lingxiaoqing 2011.08.08 ----------->>>>>>>>>>>>>>
        /// <summary>
        /// ���Ӑ�K�C�h�I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="customerSearchRet"></param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���Ӑ�K�C�h�I���C�x���g�B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.08</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;
            try
            {
                int status = _customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out _customerInfo);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.tNedit_CustomerCode.SetInt(_customerInfo.CustomerCode);
                    this.CustomerCodeNm_tEdit.Text = _customerInfo.CustomerSnm;  // ����
                    _customerName = _customerInfo.CustomerSnm;
                    this.tEdit_SectionCodeAllowZero2.Clear();
                    this.SectionName_tEdit.Clear();

                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                        status,
                        MessageBoxButtons.OK);

                    return;
                }
                else
                {
                    TMsgDisp.Show(this,
                                  emErrorLevel.ERR_LEVEL_STOPDISP,
                                  this.Name,
                                  "���Ӑ���̎擾�Ɏ��s���܂����B",
                                  status,
                                  MessageBoxButtons.OK);

                    return;
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }
        //------------ADD BY lingxiaoqing 2011.08.08 ------------<<<<<<<<<<<<<<<<

        /// <summary>
        /// Control.Click �C�x���g(Delete_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : ���S�폜�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Delete_Button_Click(object sender, EventArgs e)
        {
            // ���S�폜�m�F
            DialogResult result = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                "�f�[�^���폜���܂��B" + "\r\n" +
                "��낵���ł����H", 				// �\�����郁�b�Z�[�W
                0, 									// �X�e�[�^�X�l
                //MessageBoxButtons.OKCancel,       //DELETE BY lingxiaoqing 2011.08.08 
                MessageBoxButtons.YesNo,            //ADD BY lingxiaoqing 2011.08.08 FOR Redmine#0203
                MessageBoxDefaultButton.Button2);	// �\������{�^��

            //if (result != DialogResult.OK)//DELETE BY lingxiaoqing 2011.08.08
            if (result != DialogResult.Yes)//ADD BY lingxiaoqing 2011.08.08  FOR Redmine#0203
            {
                this.Delete_Button.Focus();
                return;
            }

            // �ێ����Ă���f�[�^�Z�b�g�����擾
            Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex][VIEW_GUID_KEY_TITLE];
            SCMPriorSt scmPriorSt = (SCMPriorSt)this._scmPriorStTable[guid];

            // ���S�폜����
            int status = this._scmPriorStAcs.Delete(scmPriorSt);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this.DataIndex].Delete();
                        this._scmPriorStTable.Remove(scmPriorSt.FileHeaderGuid);

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        // ���S�폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            PROGRAM_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text, 				            // �v���O��������
                            "Delete_Button_Click", 				// ��������
                            TMsgDisp.OPE_DELETE, 				// �I�y���[�V����
                            "�폜�Ɏ��s���܂����B", 			// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._scmPriorStAcs, 				    // �G���[�����������I�u�W�F�N�g
                            //MessageBoxButtons.OK, 				// �\������{�^��  // DELETE BY lingxiaoqing 2011.08.08
                            MessageBoxButtons.YesNo, 				// �\������{�^��  // ADD BY lingxiaoqing 2011.08.08  FOR PCCUOE-0203
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        //CloseForm(DialogResult.Cancel); //DELETE BY lingxiaoqing 2011.08.08
                        CloseForm(DialogResult.No);       //ADD BY lingxiaoqing 2011.08.08
                        return;
                    }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(Revive_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �����{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br></br>
        /// </remarks>
        private void Revive_Button_Click(object sender, EventArgs e)
        {
            int status = 0;
            Guid guid;

            // �����Ώۃf�[�^�擾
            guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][VIEW_GUID_KEY_TITLE];
            SCMPriorSt scmPriorSt = ((SCMPriorSt)this._scmPriorStTable[guid]).Clone();

            // ��������
            status = this._scmPriorStAcs.Revival(ref scmPriorSt);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // SCM�D��ݒ���N���X�̃f�[�^�Z�b�g�W�J����
                        SCMPriorStToDataSet(scmPriorSt, this._dataIndex);
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status, true);
                        return;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,    // �G���[���x��
                            PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "Revive_Button_Click",				// ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            "�����Ɏ��s���܂����B",			    // �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._scmPriorStAcs,					// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        CloseForm(DialogResult.Cancel);
                        return;
                    }
            }

            // ��ʔ�\���C�x���g
            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }

            this.DialogResult = DialogResult.OK;

            this._indexBuf = -2;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������
            // �t�H�[�����\��������B
            if (CanClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        /// <summary>
        /// ChangeFocus �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            // �V�K���[�h���烂�[�h�ύX�Ή�
            _modeFlg = false;
            _cusModeFlg = false; // ADD BY lingxiaoqing on 2011.08.08

            if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero2)
            {
                // --- ADD 2011/09/07 -------------------------------->>>>>
                if (string.IsNullOrEmpty(tEdit_SectionCodeAllowZero2.Text.Trim()))
                {
                    this.SectionName_tEdit.Clear();
                    return;
                }
                this.tEdit_SectionCodeAllowZero2.DataText = tEdit_SectionCodeAllowZero2.Text.Trim().PadLeft(2, '0');
                // --- ADD 2011/09/07 --------------------------------<<<<<
                // ���_�R�[�h�擾
                string sectionCode = this.tEdit_SectionCodeAllowZero2.DataText;

                // ���_���̎擾
                string sectionName = GetSectionName(sectionCode);
                if (sectionName == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_INFO,
                        this.Name,
                        "���_�����݂��܂���B",
                        -1,
                        MessageBoxButtons.OK
                    );
                    this.tEdit_SectionCodeAllowZero2.Clear();
                    this.SectionName_tEdit.Clear();
                    e.NextCtrl = SectionGuide_Button; //ADD BY lingxiaoqing 2011.08.08
                    e.NextCtrl = this.tEdit_SectionCodeAllowZero2;
                    e.NextCtrl.Select();
                    return;
                }
                //this.tEdit_SectionCodeAllowZero2.DataText = sectionCode.Trim().PadLeft(2, '0'); // ADD BY lingxiaoqing on 2011.08.08//DEL 2011/09/07
                this.SectionName_tEdit.DataText = sectionName;

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (this.SectionName_tEdit.DataText.Trim() != "")
                        {
                            // �t�H�[�J�X�ݒ�
                            //e.NextCtrl = this.PrioritySetting_tComboEditor;//DELETE BY lingxiaoqing on 2011.08.08
                            e.NextCtrl = this.PureSuperio_ComboEditor; // ADD BY lingxiaoqing on 2011.08.08
                        }
                    }
                    //------------ADD BY lingxiaoqing 2011.08.08 ------------->>>>>>>>>>>>>>>>>>
                    else
                    {
                        if (sectionName.Equals("�S�Ћ���") && e.NextCtrl == this.SectionGuide_Button)
                        {
                            return;
                        }

                    }
                    e.NextCtrl = this.SectionGuide_Button;
                    //------------ADD BY lingxiaoqing 2011.08.08 -------------<<<<<<<<<<<<<<<<<<
                }
                //ADD BY lingxiaoqing 2011.08.08 
                else
                {
                    e.NextCtrl = this.SetKind_tComboEditor;
                }

                // �V�K���[�h���烂�[�h�ύX�Ή�
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // �J�ڐ悪����{�^��
                    _modeFlg = true;
                }
                else if (e.NextCtrl.Name == "Renewal_Button")
                {
                    // �ŐV���{�^���͍X�V�`�F�b�N����O��
                    ;
                }
                else if (this.DataIndex < 0)
                {
                    if (
                        e.PrevCtrl == this.tEdit_SectionCodeAllowZero2
                            &&
                        e.NextCtrl == this.SectionGuide_Button
                            &&
                        string.IsNullOrEmpty(this.tEdit_SectionCodeAllowZero2.Text.Trim())
                    )
                    {
                        // �������Ȃ� ��V�K���[�h�ŋN������ɋ��_�̃K�C�h�{�^�����N���b�N�����ꍇ�ɑ���
                    }
                    else if (ModeChangeProc())
                    {
                        e.NextCtrl = tEdit_SectionCodeAllowZero2;
                    }
                }
            }
            //-------------- ADD BY lingxiaoqing 2011.08.08------------>>>>>>>>>>>>>>>>>
            if (e.PrevCtrl == this.tNedit_CustomerCode)
            {
                // ���Ӑ�R�[�h�擾
                int customerCode = this.tNedit_CustomerCode.GetInt();
                if (this.tNedit_CustomerCode.GetInt() != 0)
                {
                    int status = _customerInfoAcs.ReadDBData(_enterpriseCode, this.tNedit_CustomerCode.GetInt(), out _customerInfo);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this._customerName = _customerInfo.CustomerSnm;
                        this.CustomerCodeNm_tEdit.DataText = _customerName;
                        e.NextCtrl = this.PureSuperio_ComboEditor;
                    }
                    else
                    {
                        this.CustomerCodeNm_tEdit.DataText = "";
                        TMsgDisp.Show(
                                               this,
                                               emErrorLevel.ERR_LEVEL_INFO,
                                               this.Name,
                                               "���Ӑ悪���݂��܂���B",
                                               -1,
                                               MessageBoxButtons.OK
                                           );
                        this.tNedit_CustomerCode.Clear();
                        this.CustomerCodeNm_tEdit.Clear();
                        e.NextCtrl = this.uButton_CustomerGuide;
                        e.NextCtrl = this.tNedit_CustomerCode;
                        e.NextCtrl.Select();
                        return;
                    }
                    if (string.IsNullOrEmpty(this.CustomerCodeNm_tEdit.DataText) && this.tNedit_CustomerCode.GetInt() == 0)
                    {
                        e.NextCtrl = this.PureSuperio_ComboEditor;
                    }
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            if (this.CustomerCodeNm_tEdit.DataText.Trim() != "")
                            {
                                e.NextCtrl = this.PureSuperio_ComboEditor;
                            }
                        }
                    }
                }
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        e.NextCtrl = this.uButton_CustomerGuide;
                    }
                }
                else
                {
                    e.NextCtrl = this.SetKind_tComboEditor;
                }
                // �V�K���[�h���烂�[�h�ύX�Ή�
                if (e.NextCtrl.Name == "Cancel_Button")
                {
                    // �J�ڐ悪����{�^��
                    _cusModeFlg = true;
                }
                else if (e.NextCtrl.Name == "Renewal_Button")
                {
                    // �ŐV���{�^���͍X�V�`�F�b�N����O��
                    ;
                }
                else if (this.DataIndex < 0)
                {
                    if (
                        e.PrevCtrl == this.tNedit_CustomerCode
                            &&
                        e.NextCtrl == this.uButton_CustomerGuide
                            &&
                        string.IsNullOrEmpty(this.tNedit_CustomerCode.Text.Trim())
                    )
                    {
                        // �������Ȃ� ��V�K���[�h�ŋN������ɋ��_�̃K�C�h�{�^�����N���b�N�����ꍇ�ɑ���
                    }
                    else if (CusModeChangeProc())
                    {
                        e.NextCtrl = tNedit_CustomerCode;
                    }
                }
            }
            else if (e.PrevCtrl == this.SetKind_tComboEditor)
            {
                if (e.ShiftKey == false)
                {
                    // --- UPD 2011/09/07 -------------------------------->>>>>
                    //if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab) || (e.Key == Keys.Down))
                    {
                        // --- UPD 2011/09/07 --------------------------------<<<<<
                        if (this.SetKind_tComboEditor.SelectedIndex == 0)
                        {
                            e.NextCtrl = this.tEdit_SectionCodeAllowZero2;
                        }
                        else
                        {
                            e.NextCtrl = this.tNedit_CustomerCode;
                        }
                    }
                }
                else
                {
                    e.NextCtrl = this.Discriminition_ComboEditor;
                }
            }
            else if (e.PrevCtrl == this.Cancel_Button)
            {
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (this.Discriminition_ComboEditor.Enabled == false)
                        {
                            e.NextCtrl = this.PureSuperio_ComboEditor;
                        }
                        else
                        {
                            e.NextCtrl = this.Discriminition_ComboEditor;
                        }
                    }
                }
                else
                {
                    if (this.Revive_Button.Visible)
                    {
                        e.NextCtrl = this.Revive_Button;
                    }
                    else
                    {
                        e.NextCtrl = this.Ok_Button;
                    }
                }
            }
            else if (e.PrevCtrl == this.uButton_CustomerGuide)
            {
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        e.NextCtrl = this.PureSuperio_ComboEditor;
                    }
                }
                else
                {
                    e.NextCtrl = this.tNedit_CustomerCode;
                }
            }
            else if (e.PrevCtrl == this.SectionGuide_Button)
            {
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        e.NextCtrl = this.PureSuperio_ComboEditor;
                    }
                }
                else
                {
                    e.NextCtrl = this.tEdit_SectionCodeAllowZero2;
                }
            }
            else if (e.PrevCtrl == this.PureSuperio_ComboEditor)
            {
                if (e.ShiftKey == true)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        if (this.SectionGuide_Button.Visible)
                        {
                            e.NextCtrl = this.SectionGuide_Button;
                        }
                        else
                        {
                            e.NextCtrl = this.uButton_CustomerGuide;
                        }
                    }
                }
            }
            else if (e.PrevCtrl == this.Discriminition_ComboEditor)
            {
                if (e.ShiftKey == true)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        e.NextCtrl = this.Cancel_Button;
                    }
                }
            }
            else if (e.PrevCtrl == this.Renewal_Button)
            {
                if (e.Key == Keys.Left)
                {
                    e.NextCtrl = this.Order7_ComboEditor;
                }
            }


            //-------------- ADD BY lingxiaoqing 2011.08.08-------------<<<<<<<<<<<<<<<<<<
            //-------------- DELETE BY lingxiaoqing 2011.08.08 -------------<<<<<<<<<<<<<<<<<<
            //else if (e.PrevCtrl == PrioritySetting_tComboEditor) 
            //{
            //    if ((e.ShiftKey) && (e.Key == Keys.Tab))
            //    {
            //        // SHIFT+TAB����
            //        if (!tEdit_SectionCodeAllowZero.Enabled)
            //        {
            //            e.NextCtrl = Cancel_Button;
            //        }
            //        else
            //        {
            //            if (SectionName_tEdit.DataText != "")
            //            {
            //                e.NextCtrl = tEdit_SectionCodeAllowZero;
            //            }
            //        }
            //    }
            //}
            //--------------DELETE BY lingxiaoqing 2011.08.08 ------------->>>>>>>>>>>>>>>>>
        }

        /// <summary>
        /// �ŐV���{�^���N���b�N
        /// </summary>
        private void Renewal_Button_Click(object sender, EventArgs e)
        {
            //------------ADD BY lingxiaoqing 2011.08.08------------------>>>>>>>>>>>>>
            int status = 0;
            ArrayList retList = null;
            SCMPriorSt scmPriorSt = null;
            this.ScreenToSCMPriorSt(ref scmPriorSt);
            status = this._scmPriorStAcs.SearchAll(out retList, this._enterpriseCode);
            foreach (SCMPriorSt sp in retList)
            {
                if (sp.CustomerCode == scmPriorSt.CustomerCode &&
                    sp.SectionCode.TrimEnd().Equals(scmPriorSt.SectionCode.TrimEnd()) &&
                    sp.PriorAppliDiv == scmPriorSt.PriorAppliDiv)
                {
                    SCMPriorStToScreen(sp);
                    // SCM�D��ݒ���N���X�̃f�[�^�Z�b�g�W�J����
                    SCMPriorStToDataSet(sp, this.DataIndex);
                }
            }
            //------------ADD BY lingxiaoqing 2011.08.08------------------<<<<<<<<<<<<<
            //this._secInfoAcs.ResetSectionInfo();              //DELETE BY lingxiaoqing 2011.08.08

            TMsgDisp.Show(this, 								// �e�E�B���h�E�t�H�[��
                          emErrorLevel.ERR_LEVEL_INFO,          // �G���[���x��
                          PROGRAM_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                          "�ŐV�����擾���܂����B", 			// �\�����郁�b�Z�[�W
                          0, 									// �X�e�[�^�X�l
                          MessageBoxButtons.OK);				// �\������{�^��          
        }

        #endregion

        //------------ADD BY lingxiaoqing 2011.08.08 ----------->>>>>>>>>>>>>>>
        /// <summary>
        /// �ݒ��ʕύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �ݒ��ʂ̒l���ύX���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.08.08</br>
        /// <br>Update Note : BL�p�[�c�I�[�_�[�����񓚕s��Ή�</br>
        /// <br>Programmer  : 杍^</br>
        /// <br>Date        : 2018/07/26</br>
        /// </remarks>
        private void SetKind_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            if (SetKind_tComboEditor.SelectedIndex == 0)
            {
                // ���_�P��
                this.panel_Section.Visible = true;
                this.panel_Customer.Visible = false;
                this.tNedit_CustomerCode.Clear();
                this.CustomerCodeNm_tEdit.Clear();
                // �t�H�[�J�X�ݒ�
                this.tEdit_SectionCodeAllowZero2.Focus();
                this.ultraLabel00.Visible = true; // ADD 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή�
            }
            else
            {
                // ���Ӑ�P��
                this.panel_Section.Visible = false;
                this.panel_Customer.Visible = true;
                this.tEdit_SectionCodeAllowZero2.Clear();
                this.SectionName_tEdit.Clear();
                // �t�H�[�J�X�ݒ�
                this.tNedit_CustomerCode.Focus();
                this.ultraLabel00.Visible = false; // ADD 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή�
            }

        }
        //------------ADD BY lingxiaoqing 2011.08.08 -----------<<<<<<<<<<<<<<

        // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------>>>>>
        ////------------ADD BY lingxiaoqing 2011.08.08 ----------->>>>>>>>>>>>>>>
        ///// <summary>
        /////  �D��K�p�敪��I��
        ///// </summary>
        ///// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        ///// <param name="e">�C�x���g�p�����[�^</param>
        ///// <remarks>
        ///// <br>Note�@�@�@ : �D��K�p�敪��I���B</br>
        ///// <br>Programmer : ������</br>
        ///// <br>Date       : 2011.08.08</br>
        ///// </remarks>
        //private void Discriminition_ComboEditor_ValueChanged(object sender, EventArgs e)
        //{
        //    //�D��K�p�敪
        //    if (this.Discriminition_ComboEditor.SelectedIndex == 1)
        //    {
        //        this.ultraLabel5.Visible = false;
        //        this.PureSuperio1_ComboEditor.Visible = false;
        //        this.InStock1_ComboEditor.Visible = false;
        //        this.CampingCode1_ComboEditor.Visible = false;
        //        this.PriorPriceSetCd4_tComboEditor.Visible = false;
        //        this.PriorPriceSetCd5_tComboEditor.Visible = false;
        //        this.PriorPriceSetCd6_tComboEditor.Visible = false;
        //    }
        //    else
        //    {

        //        this.ultraLabel5.Visible = true;
        //        this.PureSuperio1_ComboEditor.Visible = true;
        //        this.InStock1_ComboEditor.Visible = true;
        //        this.CampingCode1_ComboEditor.Visible = true;
        //        this.PriorPriceSetCd4_tComboEditor.Visible = true;
        //        this.PriorPriceSetCd5_tComboEditor.Visible = true;
        //        this.PriorPriceSetCd6_tComboEditor.Visible = true;
        //    }
        //    this.SetKind_tComboEditor.Focus();
        //}
        ////------------ADD BY lingxiaoqing 2011.08.08 -----------<<<<<<<<<<<<<<
        // ---DEL 杍^ 2018/07/26 BL�p�[�c�I�[�_�[�����񓚕s��Ή� ------<<<<<
    }
}