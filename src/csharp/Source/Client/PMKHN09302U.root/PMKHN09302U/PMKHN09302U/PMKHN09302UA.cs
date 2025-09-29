//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �|���}�X�^
// �v���O�����T�v   : �|���}�X�^�̓o�^�E�X�V�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30414 �E �K�j
// �� �� ��  2008/09/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30462 �Ɠc �M�u
// �� �� ��  2008/10/16  �C�����e : �o�O�C���A�d�l�ύX�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30462 �s�V�m��
// �� �� ��  2008/10/29  �C�����e : �o�O�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30452 ��� �r��
// �� �� ��  2009/03/16  �C�����e : ��Q�Ή�12346
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30452 ��� �r��
// �� �� ��  2009/03/23  �C�����e : ��Q�Ή�12346(�ݒ�O�ƕύX�������ꍇ�͏��i�������s��Ȃ��Ή���ǉ�)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/01  �C�����e : ��QID:13410�Ή�(uiSetControl�̏C���ɍ��킹�ă[���l�߉ɖ��̏C��)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/02  �C�����e : ��Q�Ή�13410(�t�B�[�h�o�b�N�Ή�)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/04  �C�����e : ��Q�Ή�13435
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/12  �C�����e : ��Q�Ή�13340
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/16  �C�����e : ��Q�Ή�13366�A13497
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/06/19  �C�����e : ��Q�Ή�13569 �e���m�ۗ���100�ȏ����͕s�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �C �� ��  2009/06/29  �C�����e : MANTIS�y13350�z�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �C �� ��  2009/12/15  �C�����e : �ێ�˗��C�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �k���r
// �C �� ��  2010/08/10  �C�����e : PM1012�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �k���r
// �C �� ��  2010/08/20  �C�����e : #13358�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10704766-00 �쐬�S�� : caohh �A��265
// �C �� ��  2011/08/05  �C�����e : NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���N�@
// �C �� ��  2012/11/30  �C�����e : 20130116�z�M�� Redmine#33663�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���@
// �C �� ��  2014/03/20  �C�����e : Redmine#42174�̊|���}�X�^�X�V���̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Infragistics.Win;
using Infragistics.Win.UltraWinDock;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTabControl;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting.ParamData;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// �|���}�X�^�t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �|���}�X�^�ݒ���s����ʂł��B</br>
	/// <br>Programmer	: 30414 �E �K�j</br>
    /// <br>Date		: 2008/09/25</br>
    /// <br>Update      : 2008/10/16 �Ɠc �M�u�@�o�O�C���A�d�l�ύX�Ή�</br>
    /// <br>UpdateNote  : 2008/10/29 30462 �s�V �m���@�o�O�C��</br>
    /// <br>Update Note : 2009/03/16 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12346</br>
    /// <br>Update Note : 2009/03/23 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12346(�ݒ�O�ƕύX�������ꍇ�͏��i�������s��Ȃ��Ή���ǉ�)</br>
    /// <br>Update Note : 2009/12/15 ���M �ێ�˗��C�Ή�</br>
    /// <br>              �ۑ����s��́A�w�b�_���́u�|���ݒ�v�̓��e���N���A���Ȃ��悤�ɕύX����</br>
    /// <br>              ���ו��̐擪���ڂ���u���ASHIFT+TAB�v���s���ɁA�t�H�[�J�X���u�����ݒ�v���́u���i�ݒ�v�ֈړ�����</br>
    /// <br>Update Note : 2010/08/10 �k���r PM1012�Ή�</br>
    /// <br>              �K�C�h���u�e�T�v�{�^���ŕ\������悤�ɕύX</br>
    /// <br>Update Note : 2010/08/20 �k���r #13358�Ή�</br>
    /// <br>Update Note : 2011/08/05 caohh</br>
    /// <br>              NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
    /// <br>Update Note : 2012/11/30 ���N</br>
    /// <br>			  20130116�z�M�� Redmine #33663�̑Ή�</br>
    /// </remarks>
	public partial class PMKHN09302UA : Form, IRateMDIChild
	{
        #region Dispose
        /// <summary>
        /// �g�p���̃��\�[�X�����ׂăN���[���A�b�v���܂��B
        /// </summary>
        /// <param name="disposing">�}�l�[�W ���\�[�X���j�������ꍇ true�A�j������Ȃ��ꍇ�� false �ł��B</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Windows �t�H�[�� �f�U�C�i�Ő������ꂽ�R�[�h

        /// <summary>
        /// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
        /// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance129 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance54 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance55 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance135 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance57 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance59 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance60 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance58 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance61 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance62 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance63 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance64 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance51 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance52 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance53 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance103 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance104 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance105 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance106 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance70 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance71 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance84 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance75 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���_�K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance87 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance76 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance77 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance65 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance66 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance96 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance94 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance95 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance97 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance80 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance91 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance92 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance93 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance81 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance98 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance99 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance100 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance89 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance90 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance82 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance88 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�|���ݒ�敪�K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance83 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance86 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance85 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance72 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("BL���ރK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("��ٰ�ߺ��ރK�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo5 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���i�|����ٰ�߃K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance73 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance74 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo6 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���[�J�[�K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance35 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance36 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance37 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo7 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���Ӑ�|���O���[�v�K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance126 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo8 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�d����K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance78 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance79 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo9 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���Ӑ�K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance101 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance102 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09302UA));
            this.Main_panel = new System.Windows.Forms.Panel();
            this.ultraLabel17 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_Price = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Price_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Detail_panel = new System.Windows.Forms.Panel();
            this.Detail_uGrid = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel14 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel13 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel12 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel11 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel9 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel7 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel6 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel5 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel4 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.tShape3 = new Broadleaf.Library.Windows.Forms.TShape();
            this.RateCond_panel = new System.Windows.Forms.Panel();
            this.UpdateDateTime_tDateEdit = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel18 = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_RatePriorityOrder = new Broadleaf.Library.Windows.Forms.TNedit();
            this.ultraLabel16 = new Infragistics.Win.Misc.UltraLabel();
            this.SectionGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.RateCond_Title_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SectionCodeNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tEdit_SectionCodeAllowZero = new Broadleaf.Library.Windows.Forms.TEdit();
            this.RateMngCustCd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.RateMngCustNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.RateMngGoodsCd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SectionCode_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.UnitPriceKindWay_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UnitPriceKind_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.RateMngGoodsNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.UnitPriceKind_Label = new Infragistics.Win.Misc.UltraLabel();
            this.RateSettingDivide_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.RateSettingDivideGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.UnitPriceKindWay_Label = new Infragistics.Win.Misc.UltraLabel();
            this.RateMngCust_Label = new Infragistics.Win.Misc.UltraLabel();
            this.RateMngGoods_Label = new Infragistics.Win.Misc.UltraLabel();
            this.RateSettingDivide_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tShape1 = new Broadleaf.Library.Windows.Forms.TShape();
            this.Goods_panel = new System.Windows.Forms.Panel();
            this.tEdit_GoodsNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_BLGoodsCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_BLGloupCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_GoodsMGroup = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Group_Title_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.BLGoodsGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.BLGroupGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.GoodsMakerCd_Grp_Label = new Infragistics.Win.Misc.UltraLabel();
            this.GoodsRateGrpGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.GoodsRateRank_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BLGoodsName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_GoodsMakerCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.BLGroupName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MakerName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GoodsRateGrpName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MakerGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.GoodsNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.GoodsRateGrp_Label = new Infragistics.Win.Misc.UltraLabel();
            this.BLGroup_Label = new Infragistics.Win.Misc.UltraLabel();
            this.GoodsRateRank_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.BLGoods_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_GoodsName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.Goods_tShape = new Broadleaf.Library.Windows.Forms.TShape();
            this.Customer_panel = new System.Windows.Forms.Panel();
            this.CustRateGrpGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.tEdit_CustRateGrpName = new Broadleaf.Library.Windows.Forms.TEdit();
            this.tNedit_CustRateGrpCodeZero = new Broadleaf.Library.Windows.Forms.TNedit();
            this.Customer_Title_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.CustRateGrp_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SupplierGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_CustomerCode = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tNedit_SupplierCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.SupplierCdNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.CustomerGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.CustomerCodeNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SupplierCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tShape2 = new Broadleaf.Library.Windows.Forms.TShape();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.Main_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_Price)).BeginInit();
            this.Detail_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Detail_uGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShape3)).BeginInit();
            this.RateCond_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_RatePriorityOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCodeNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateMngCustCd_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateMngCustNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateMngGoodsCd_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitPriceKindWay_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitPriceKind_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateMngGoodsNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateSettingDivide_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShape1)).BeginInit();
            this.Goods_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGloupCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsRateGrpName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsRateRank_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Goods_tShape)).BeginInit();
            this.Customer_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustRateGrpName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustRateGrpCodeZero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCdNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCodeNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShape2)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_panel
            // 
            this.Main_panel.Controls.Add(this.ultraLabel17);
            this.Main_panel.Controls.Add(this.tNedit_Price);
            this.Main_panel.Controls.Add(this.Price_uLabel);
            this.Main_panel.Controls.Add(this.Detail_panel);
            this.Main_panel.Controls.Add(this.RateCond_panel);
            this.Main_panel.Controls.Add(this.Goods_panel);
            this.Main_panel.Controls.Add(this.Customer_panel);
            this.Main_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_panel.Location = new System.Drawing.Point(0, 0);
            this.Main_panel.Name = "Main_panel";
            this.Main_panel.Padding = new System.Windows.Forms.Padding(5);
            this.Main_panel.Size = new System.Drawing.Size(1016, 614);
            this.Main_panel.TabIndex = 0;
            // 
            // ultraLabel17
            // 
            appearance129.ForeColorDisabled = System.Drawing.Color.Black;
            appearance129.TextHAlignAsString = "Left";
            appearance129.TextVAlignAsString = "Middle";
            this.ultraLabel17.Appearance = appearance129;
            this.ultraLabel17.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.ultraLabel17.Location = new System.Drawing.Point(40, 214);
            this.ultraLabel17.Name = "ultraLabel17";
            this.ultraLabel17.Size = new System.Drawing.Size(256, 24);
            this.ultraLabel17.TabIndex = 901;
            this.ultraLabel17.Text = "�����_�[���ŋ��ʐݒ�ɂȂ�܂��B";
            // 
            // tNedit_Price
            // 
            this.tNedit_Price.ActiveAppearance = appearance133;
            appearance134.BackColorDisabled = System.Drawing.Color.White;
            appearance134.ForeColorDisabled = System.Drawing.Color.Black;
            appearance134.TextHAlignAsString = "Right";
            this.tNedit_Price.Appearance = appearance134;
            this.tNedit_Price.AutoSelect = true;
            this.tNedit_Price.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_Price.DataText = "";
            this.tNedit_Price.Enabled = false;
            this.tNedit_Price.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_Price.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_Price.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.tNedit_Price.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_Price.Location = new System.Drawing.Point(99, 298);
            this.tNedit_Price.MaxLength = 9;
            this.tNedit_Price.Name = "tNedit_Price";
            this.tNedit_Price.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_Price.ReadOnly = true;
            this.tNedit_Price.Size = new System.Drawing.Size(82, 24);
            this.tNedit_Price.TabIndex = 900;
            // 
            // Price_uLabel
            // 
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            appearance12.TextHAlignAsString = "Left";
            appearance12.TextVAlignAsString = "Middle";
            this.Price_uLabel.Appearance = appearance12;
            this.Price_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.Price_uLabel.Location = new System.Drawing.Point(40, 298);
            this.Price_uLabel.Name = "Price_uLabel";
            this.Price_uLabel.Size = new System.Drawing.Size(53, 24);
            this.Price_uLabel.TabIndex = 900;
            this.Price_uLabel.Text = "���i";
            // 
            // Detail_panel
            // 
            this.Detail_panel.Controls.Add(this.Detail_uGrid);
            this.Detail_panel.Controls.Add(this.ultraLabel15);
            this.Detail_panel.Controls.Add(this.ultraLabel14);
            this.Detail_panel.Controls.Add(this.ultraLabel13);
            this.Detail_panel.Controls.Add(this.ultraLabel12);
            this.Detail_panel.Controls.Add(this.ultraLabel11);
            this.Detail_panel.Controls.Add(this.ultraLabel9);
            this.Detail_panel.Controls.Add(this.ultraLabel8);
            this.Detail_panel.Controls.Add(this.ultraLabel10);
            this.Detail_panel.Controls.Add(this.ultraLabel7);
            this.Detail_panel.Controls.Add(this.ultraLabel6);
            this.Detail_panel.Controls.Add(this.ultraLabel5);
            this.Detail_panel.Controls.Add(this.ultraLabel4);
            this.Detail_panel.Controls.Add(this.ultraLabel3);
            this.Detail_panel.Controls.Add(this.ultraLabel2);
            this.Detail_panel.Controls.Add(this.ultraLabel1);
            this.Detail_panel.Controls.Add(this.tShape3);
            this.Detail_panel.Location = new System.Drawing.Point(10, 334);
            this.Detail_panel.Name = "Detail_panel";
            this.Detail_panel.Size = new System.Drawing.Size(995, 268);
            this.Detail_panel.TabIndex = 69;
            this.Detail_panel.TabStop = true;
            // 
            // Detail_uGrid
            // 
            this.Detail_uGrid.Cursor = System.Windows.Forms.Cursors.Default;
            appearance13.BackColor = System.Drawing.Color.White;
            appearance13.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            appearance13.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance13.BorderColor = System.Drawing.Color.Blue;
            this.Detail_uGrid.DisplayLayout.Appearance = appearance13;
            this.Detail_uGrid.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.Detail_uGrid.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance14.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance14.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance14.BorderColor = System.Drawing.SystemColors.Window;
            this.Detail_uGrid.DisplayLayout.GroupByBox.Appearance = appearance14;
            appearance15.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Detail_uGrid.DisplayLayout.GroupByBox.BandLabelAppearance = appearance15;
            this.Detail_uGrid.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.Detail_uGrid.DisplayLayout.GroupByBox.Hidden = true;
            appearance16.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance16.BackColor2 = System.Drawing.SystemColors.Control;
            appearance16.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance16.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Detail_uGrid.DisplayLayout.GroupByBox.PromptAppearance = appearance16;
            this.Detail_uGrid.DisplayLayout.MaxColScrollRegions = 1;
            this.Detail_uGrid.DisplayLayout.MaxRowScrollRegions = 1;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance17.ForeColor = System.Drawing.Color.Black;
            this.Detail_uGrid.DisplayLayout.Override.ActiveCellAppearance = appearance17;
            this.Detail_uGrid.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            this.Detail_uGrid.DisplayLayout.Override.AllowColMoving = Infragistics.Win.UltraWinGrid.AllowColMoving.NotAllowed;
            this.Detail_uGrid.DisplayLayout.Override.AllowColSwapping = Infragistics.Win.UltraWinGrid.AllowColSwapping.NotAllowed;
            this.Detail_uGrid.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.False;
            this.Detail_uGrid.DisplayLayout.Override.AllowRowLayoutCellSizing = Infragistics.Win.UltraWinGrid.RowLayoutSizing.None;
            appearance18.BackColor = System.Drawing.SystemColors.Window;
            this.Detail_uGrid.DisplayLayout.Override.CardAreaAppearance = appearance18;
            appearance19.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance19.BorderColor = System.Drawing.Color.Silver;
            appearance19.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.Detail_uGrid.DisplayLayout.Override.CellAppearance = appearance19;
            this.Detail_uGrid.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.Detail_uGrid.DisplayLayout.Override.CellPadding = 0;
            appearance20.BackColor = System.Drawing.SystemColors.Control;
            appearance20.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance20.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance20.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance20.BorderColor = System.Drawing.SystemColors.Window;
            this.Detail_uGrid.DisplayLayout.Override.GroupByRowAppearance = appearance20;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance21.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance21.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance21.ForeColor = System.Drawing.Color.White;
            appearance21.TextHAlignAsString = "Left";
            appearance21.ThemedElementAlpha = Infragistics.Win.Alpha.Transparent;
            this.Detail_uGrid.DisplayLayout.Override.HeaderAppearance = appearance21;
            appearance23.BackColor = System.Drawing.SystemColors.Window;
            appearance23.BorderColor = System.Drawing.Color.Silver;
            this.Detail_uGrid.DisplayLayout.Override.RowAppearance = appearance23;
            this.Detail_uGrid.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(230)))), ((int)(((byte)(148)))));
            appearance24.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(149)))), ((int)(((byte)(21)))));
            appearance24.ForeColor = System.Drawing.Color.Black;
            this.Detail_uGrid.DisplayLayout.Override.SelectedRowAppearance = appearance24;
            this.Detail_uGrid.DisplayLayout.Override.SelectTypeCell = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.Detail_uGrid.DisplayLayout.Override.SelectTypeCol = Infragistics.Win.UltraWinGrid.SelectType.None;
            this.Detail_uGrid.DisplayLayout.Override.SelectTypeRow = Infragistics.Win.UltraWinGrid.SelectType.None;
            appearance25.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Detail_uGrid.DisplayLayout.Override.TemplateAddRowAppearance = appearance25;
            this.Detail_uGrid.DisplayLayout.RowConnectorColor = System.Drawing.Color.Black;
            this.Detail_uGrid.DisplayLayout.RowConnectorStyle = Infragistics.Win.UltraWinGrid.RowConnectorStyle.Solid;
            this.Detail_uGrid.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.Detail_uGrid.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.Detail_uGrid.Enabled = false;
            this.Detail_uGrid.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Detail_uGrid.Location = new System.Drawing.Point(160, 6);
            this.Detail_uGrid.Name = "Detail_uGrid";
            this.Detail_uGrid.Size = new System.Drawing.Size(828, 256);
            this.Detail_uGrid.TabIndex = 1139;
            this.Detail_uGrid.AfterExitEditMode += new System.EventHandler(this.Detail_uGrid_AfterExitEditMode);
            this.Detail_uGrid.AfterEnterEditMode += new System.EventHandler(this.Detail_uGrid_AfterEnterEditMode);
            this.Detail_uGrid.AfterCellUpdate += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.Detail_uGrid_AfterCellUpdate);
            this.Detail_uGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Detail_uGrid_KeyPress);
            this.Detail_uGrid.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.Detail_uGrid_CellChange);
            this.Detail_uGrid.Leave += new System.EventHandler(this.Detail_uGrid_Leave);
            this.Detail_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Detail_uGrid_KeyDown);
            // 
            // ultraLabel15
            // 
            appearance54.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance54.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance54.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance54.ForeColor = System.Drawing.Color.White;
            appearance54.ForeColorDisabled = System.Drawing.Color.White;
            appearance54.TextHAlignAsString = "Center";
            appearance54.TextVAlignAsString = "Middle";
            this.ultraLabel15.Appearance = appearance54;
            this.ultraLabel15.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel15.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F);
            this.ultraLabel15.Location = new System.Drawing.Point(66, 225);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(95, 19);
            this.ultraLabel15.TabIndex = 900;
            this.ultraLabel15.Text = "�[�������敪";
            // 
            // ultraLabel14
            // 
            appearance55.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance55.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance55.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance55.ForeColor = System.Drawing.Color.White;
            appearance55.ForeColorDisabled = System.Drawing.Color.White;
            appearance55.TextHAlignAsString = "Center";
            appearance55.TextVAlignAsString = "Middle";
            this.ultraLabel14.Appearance = appearance55;
            this.ultraLabel14.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel14.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F);
            this.ultraLabel14.Location = new System.Drawing.Point(66, 207);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(95, 19);
            this.ultraLabel14.TabIndex = 900;
            this.ultraLabel14.Text = "�[�������P��";
            // 
            // ultraLabel13
            // 
            appearance135.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance135.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance135.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance135.ForeColor = System.Drawing.Color.White;
            appearance135.ForeColorDisabled = System.Drawing.Color.White;
            appearance135.TextHAlignAsString = "Center";
            appearance135.TextVAlignAsString = "Middle";
            this.ultraLabel13.Appearance = appearance135;
            this.ultraLabel13.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel13.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F);
            this.ultraLabel13.Location = new System.Drawing.Point(66, 189);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(95, 19);
            this.ultraLabel13.TabIndex = 900;
            this.ultraLabel13.Text = "���iUP��";
            // 
            // ultraLabel12
            // 
            appearance56.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance56.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance56.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance56.ForeColor = System.Drawing.Color.White;
            appearance56.ForeColorDisabled = System.Drawing.Color.White;
            appearance56.TextHAlignAsString = "Center";
            appearance56.TextVAlignAsString = "Middle";
            this.ultraLabel12.Appearance = appearance56;
            this.ultraLabel12.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel12.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F);
            this.ultraLabel12.Location = new System.Drawing.Point(66, 171);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(95, 19);
            this.ultraLabel12.TabIndex = 900;
            this.ultraLabel12.Text = "���[�U�[���i";
            // 
            // ultraLabel11
            // 
            appearance57.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance57.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance57.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance57.ForeColor = System.Drawing.Color.White;
            appearance57.ForeColorDisabled = System.Drawing.Color.White;
            appearance57.TextHAlignAsString = "Center";
            appearance57.TextVAlignAsString = "Middle";
            this.ultraLabel11.Appearance = appearance57;
            this.ultraLabel11.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel11.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F);
            this.ultraLabel11.Location = new System.Drawing.Point(6, 172);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(61, 72);
            this.ultraLabel11.TabIndex = 900;
            this.ultraLabel11.Text = "���i";
            // 
            // ultraLabel9
            // 
            appearance59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance59.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance59.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance59.ForeColor = System.Drawing.Color.White;
            appearance59.ForeColorDisabled = System.Drawing.Color.White;
            appearance59.TextHAlignAsString = "Center";
            appearance59.TextVAlignAsString = "Middle";
            this.ultraLabel9.Appearance = appearance59;
            this.ultraLabel9.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel9.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F);
            this.ultraLabel9.Location = new System.Drawing.Point(66, 153);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(95, 19);
            this.ultraLabel9.TabIndex = 900;
            this.ultraLabel9.Text = "�d������";
            // 
            // ultraLabel8
            // 
            appearance60.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance60.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance60.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance60.ForeColor = System.Drawing.Color.White;
            appearance60.ForeColorDisabled = System.Drawing.Color.White;
            appearance60.TextHAlignAsString = "Center";
            appearance60.TextVAlignAsString = "Middle";
            this.ultraLabel8.Appearance = appearance60;
            this.ultraLabel8.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel8.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F);
            this.ultraLabel8.Location = new System.Drawing.Point(66, 135);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(95, 19);
            this.ultraLabel8.TabIndex = 900;
            this.ultraLabel8.Text = "�d����";
            // 
            // ultraLabel10
            // 
            appearance58.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance58.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance58.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance58.ForeColor = System.Drawing.Color.White;
            appearance58.ForeColorDisabled = System.Drawing.Color.White;
            appearance58.TextHAlignAsString = "Center";
            appearance58.TextVAlignAsString = "Middle";
            this.ultraLabel10.Appearance = appearance58;
            this.ultraLabel10.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel10.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F);
            this.ultraLabel10.Location = new System.Drawing.Point(6, 135);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(61, 38);
            this.ultraLabel10.TabIndex = 900;
            this.ultraLabel10.Text = "����";
            // 
            // ultraLabel7
            // 
            appearance61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance61.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance61.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance61.ForeColor = System.Drawing.Color.White;
            appearance61.ForeColorDisabled = System.Drawing.Color.White;
            appearance61.TextHAlignAsString = "Center";
            appearance61.TextVAlignAsString = "Middle";
            this.ultraLabel7.Appearance = appearance61;
            this.ultraLabel7.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel7.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F);
            this.ultraLabel7.Location = new System.Drawing.Point(66, 117);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(95, 19);
            this.ultraLabel7.TabIndex = 900;
            this.ultraLabel7.Text = "�e���m�ۗ�";
            // 
            // ultraLabel6
            // 
            appearance62.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance62.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance62.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance62.ForeColor = System.Drawing.Color.White;
            appearance62.ForeColorDisabled = System.Drawing.Color.White;
            appearance62.TextHAlignAsString = "Center";
            appearance62.TextVAlignAsString = "Middle";
            this.ultraLabel6.Appearance = appearance62;
            this.ultraLabel6.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel6.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F);
            this.ultraLabel6.Location = new System.Drawing.Point(66, 99);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(95, 19);
            this.ultraLabel6.TabIndex = 900;
            this.ultraLabel6.Text = "����UP��";
            // 
            // ultraLabel5
            // 
            appearance63.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance63.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance63.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance63.ForeColor = System.Drawing.Color.White;
            appearance63.ForeColorDisabled = System.Drawing.Color.White;
            appearance63.TextHAlignAsString = "Center";
            appearance63.TextVAlignAsString = "Middle";
            this.ultraLabel5.Appearance = appearance63;
            this.ultraLabel5.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel5.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F);
            this.ultraLabel5.Location = new System.Drawing.Point(66, 81);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(95, 19);
            this.ultraLabel5.TabIndex = 900;
            this.ultraLabel5.Text = "�����z";
            // 
            // ultraLabel4
            // 
            appearance64.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance64.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance64.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance64.ForeColor = System.Drawing.Color.White;
            appearance64.ForeColorDisabled = System.Drawing.Color.White;
            appearance64.TextHAlignAsString = "Center";
            appearance64.TextVAlignAsString = "Middle";
            this.ultraLabel4.Appearance = appearance64;
            this.ultraLabel4.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel4.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F);
            this.ultraLabel4.Location = new System.Drawing.Point(66, 63);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(95, 19);
            this.ultraLabel4.TabIndex = 900;
            this.ultraLabel4.Text = "������";
            // 
            // ultraLabel3
            // 
            appearance51.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance51.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance51.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance51.ForeColor = System.Drawing.Color.White;
            appearance51.ForeColorDisabled = System.Drawing.Color.White;
            appearance51.TextHAlignAsString = "Center";
            appearance51.TextVAlignAsString = "Middle";
            this.ultraLabel3.Appearance = appearance51;
            this.ultraLabel3.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel3.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F);
            this.ultraLabel3.Location = new System.Drawing.Point(6, 63);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(61, 73);
            this.ultraLabel3.TabIndex = 900;
            this.ultraLabel3.Text = "����";
            // 
            // ultraLabel2
            // 
            appearance52.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance52.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance52.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance52.ForeColor = System.Drawing.Color.White;
            appearance52.ForeColorDisabled = System.Drawing.Color.White;
            appearance52.TextHAlignAsString = "Center";
            appearance52.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance52;
            this.ultraLabel2.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel2.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F);
            this.ultraLabel2.Location = new System.Drawing.Point(6, 45);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(155, 19);
            this.ultraLabel2.TabIndex = 900;
            this.ultraLabel2.Text = "����(�ȉ�)";
            // 
            // ultraLabel1
            // 
            appearance53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance53.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance53.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance53.ForeColor = System.Drawing.Color.White;
            appearance53.ForeColorDisabled = System.Drawing.Color.White;
            appearance53.TextHAlignAsString = "Center";
            appearance53.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance53;
            this.ultraLabel1.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.ultraLabel1.Font = new System.Drawing.Font("�l�r �S�V�b�N", 10F);
            this.ultraLabel1.Location = new System.Drawing.Point(6, 27);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(155, 19);
            this.ultraLabel1.TabIndex = 900;
            this.ultraLabel1.Text = "����(�ȏ�)";
            // 
            // tShape3
            // 
            this.tShape3.BackColor = System.Drawing.Color.Transparent;
            this.tShape3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tShape3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tShape3.HatchBackColor = System.Drawing.Color.Empty;
            this.tShape3.HatchForeColor = System.Drawing.Color.Empty;
            this.tShape3.Location = new System.Drawing.Point(0, 0);
            this.tShape3.Name = "tShape3";
            this.tShape3.ShapeStyle = Broadleaf.Library.Windows.Forms.emShapeStyle.ssRectangle;
            this.tShape3.Size = new System.Drawing.Size(995, 268);
            this.tShape3.TabIndex = 1138;
            // 
            // RateCond_panel
            // 
            this.RateCond_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.RateCond_panel.Controls.Add(this.UpdateDateTime_tDateEdit);
            this.RateCond_panel.Controls.Add(this.ultraLabel18);
            this.RateCond_panel.Controls.Add(this.tNedit_RatePriorityOrder);
            this.RateCond_panel.Controls.Add(this.ultraLabel16);
            this.RateCond_panel.Controls.Add(this.SectionGuide_Button);
            this.RateCond_panel.Controls.Add(this.RateCond_Title_uLabel);
            this.RateCond_panel.Controls.Add(this.SectionCodeNm_tEdit);
            this.RateCond_panel.Controls.Add(this.tEdit_SectionCodeAllowZero);
            this.RateCond_panel.Controls.Add(this.RateMngCustCd_tEdit);
            this.RateCond_panel.Controls.Add(this.RateMngCustNm_tEdit);
            this.RateCond_panel.Controls.Add(this.RateMngGoodsCd_tEdit);
            this.RateCond_panel.Controls.Add(this.SectionCode_uLabel);
            this.RateCond_panel.Controls.Add(this.UnitPriceKindWay_tComboEditor);
            this.RateCond_panel.Controls.Add(this.Mode_Label);
            this.RateCond_panel.Controls.Add(this.UnitPriceKind_tComboEditor);
            this.RateCond_panel.Controls.Add(this.RateMngGoodsNm_tEdit);
            this.RateCond_panel.Controls.Add(this.UnitPriceKind_Label);
            this.RateCond_panel.Controls.Add(this.RateSettingDivide_tEdit);
            this.RateCond_panel.Controls.Add(this.RateSettingDivideGuide_Button);
            this.RateCond_panel.Controls.Add(this.UnitPriceKindWay_Label);
            this.RateCond_panel.Controls.Add(this.RateMngCust_Label);
            this.RateCond_panel.Controls.Add(this.RateMngGoods_Label);
            this.RateCond_panel.Controls.Add(this.RateSettingDivide_Label);
            this.RateCond_panel.Controls.Add(this.tShape1);
            this.RateCond_panel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RateCond_panel.Location = new System.Drawing.Point(10, 10);
            this.RateCond_panel.Name = "RateCond_panel";
            this.RateCond_panel.Size = new System.Drawing.Size(995, 96);
            this.RateCond_panel.TabIndex = 1;
            // 
            // UpdateDateTime_tDateEdit
            // 
            this.UpdateDateTime_tDateEdit.ActiveEditAppearance = appearance103;
            this.UpdateDateTime_tDateEdit.BackColor = System.Drawing.Color.Transparent;
            this.UpdateDateTime_tDateEdit.CalendarDisp = false;
            appearance104.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance104.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance104.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance104.ForeColorDisabled = System.Drawing.Color.Black;
            appearance104.TextHAlignAsString = "Left";
            appearance104.TextVAlignAsString = "Middle";
            this.UpdateDateTime_tDateEdit.EditAppearance = appearance104;
            this.UpdateDateTime_tDateEdit.Enabled = false;
            this.UpdateDateTime_tDateEdit.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.UpdateDateTime_tDateEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.UpdateDateTime_tDateEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 9.75F);
            appearance105.ForeColorDisabled = System.Drawing.Color.Black;
            appearance105.TextHAlignAsString = "Left";
            appearance105.TextVAlignAsString = "Middle";
            this.UpdateDateTime_tDateEdit.LabelAppearance = appearance105;
            this.UpdateDateTime_tDateEdit.Location = new System.Drawing.Point(736, 7);
            this.UpdateDateTime_tDateEdit.Name = "UpdateDateTime_tDateEdit";
            this.UpdateDateTime_tDateEdit.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.UpdateDateTime_tDateEdit.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.UpdateDateTime_tDateEdit.Size = new System.Drawing.Size(143, 22);
            this.UpdateDateTime_tDateEdit.TabIndex = 1140;
            this.UpdateDateTime_tDateEdit.TabStop = true;
            // 
            // ultraLabel18
            // 
            appearance106.ForeColorDisabled = System.Drawing.Color.Black;
            appearance106.TextHAlignAsString = "Left";
            appearance106.TextVAlignAsString = "Middle";
            this.ultraLabel18.Appearance = appearance106;
            this.ultraLabel18.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.ultraLabel18.Location = new System.Drawing.Point(673, 8);
            this.ultraLabel18.Name = "ultraLabel18";
            this.ultraLabel18.Size = new System.Drawing.Size(59, 22);
            this.ultraLabel18.TabIndex = 1139;
            this.ultraLabel18.Text = "�X�V��";
            // 
            // tNedit_RatePriorityOrder
            // 
            appearance70.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_RatePriorityOrder.ActiveAppearance = appearance70;
            appearance71.BackColor = System.Drawing.Color.Gainsboro;
            appearance71.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance71.ForeColor = System.Drawing.Color.Black;
            appearance71.ForeColorDisabled = System.Drawing.Color.Black;
            appearance71.TextHAlignAsString = "Right";
            this.tNedit_RatePriorityOrder.Appearance = appearance71;
            this.tNedit_RatePriorityOrder.AutoSelect = true;
            this.tNedit_RatePriorityOrder.BackColor = System.Drawing.Color.Gainsboro;
            this.tNedit_RatePriorityOrder.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_RatePriorityOrder.DataText = "";
            this.tNedit_RatePriorityOrder.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_RatePriorityOrder.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_RatePriorityOrder.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.tNedit_RatePriorityOrder.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_RatePriorityOrder.Location = new System.Drawing.Point(602, 6);
            this.tNedit_RatePriorityOrder.MaxLength = 4;
            this.tNedit_RatePriorityOrder.Name = "tNedit_RatePriorityOrder";
            this.tNedit_RatePriorityOrder.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_RatePriorityOrder.ReadOnly = true;
            this.tNedit_RatePriorityOrder.Size = new System.Drawing.Size(43, 24);
            this.tNedit_RatePriorityOrder.TabIndex = 900;
            this.tNedit_RatePriorityOrder.TabStop = false;
            // 
            // ultraLabel16
            // 
            appearance84.ForeColorDisabled = System.Drawing.Color.Black;
            appearance84.TextHAlignAsString = "Left";
            appearance84.TextVAlignAsString = "Middle";
            this.ultraLabel16.Appearance = appearance84;
            this.ultraLabel16.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.ultraLabel16.Location = new System.Drawing.Point(522, 6);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(76, 24);
            this.ultraLabel16.TabIndex = 1138;
            this.ultraLabel16.Text = "�D�揇��";
            // 
            // SectionGuide_Button
            // 
            appearance75.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance75.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.SectionGuide_Button.Appearance = appearance75;
            this.SectionGuide_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SectionGuide_Button.Location = new System.Drawing.Point(272, 6);
            this.SectionGuide_Button.Name = "SectionGuide_Button";
            this.SectionGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.SectionGuide_Button.TabIndex = 6;
            ultraToolTipInfo1.ToolTipText = "���_�K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.SectionGuide_Button, ultraToolTipInfo1);
            this.SectionGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SectionGuide_Button.Click += new System.EventHandler(this.SectionGuide_Button_Click);
            // 
            // RateCond_Title_uLabel
            // 
            appearance87.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance87.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance87.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance87.ForeColor = System.Drawing.Color.White;
            appearance87.ForeColorDisabled = System.Drawing.Color.White;
            appearance87.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance87.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance87.TextHAlignAsString = "Center";
            appearance87.TextVAlignAsString = "Middle";
            this.RateCond_Title_uLabel.Appearance = appearance87;
            this.RateCond_Title_uLabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.RateCond_Title_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RateCond_Title_uLabel.Location = new System.Drawing.Point(0, 0);
            this.RateCond_Title_uLabel.Name = "RateCond_Title_uLabel";
            this.RateCond_Title_uLabel.Size = new System.Drawing.Size(25, 96);
            this.RateCond_Title_uLabel.TabIndex = 900;
            this.RateCond_Title_uLabel.Text = "�|���ݒ�";
            // 
            // SectionCodeNm_tEdit
            // 
            appearance76.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SectionCodeNm_tEdit.ActiveAppearance = appearance76;
            appearance77.BackColor = System.Drawing.Color.Gainsboro;
            appearance77.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance77.ForeColorDisabled = System.Drawing.Color.Black;
            this.SectionCodeNm_tEdit.Appearance = appearance77;
            this.SectionCodeNm_tEdit.AutoSelect = true;
            this.SectionCodeNm_tEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.SectionCodeNm_tEdit.DataText = "";
            this.SectionCodeNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionCodeNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionCodeNm_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SectionCodeNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SectionCodeNm_tEdit.Location = new System.Drawing.Point(153, 6);
            this.SectionCodeNm_tEdit.MaxLength = 6;
            this.SectionCodeNm_tEdit.Name = "SectionCodeNm_tEdit";
            this.SectionCodeNm_tEdit.ReadOnly = true;
            this.SectionCodeNm_tEdit.Size = new System.Drawing.Size(113, 24);
            this.SectionCodeNm_tEdit.TabIndex = 4;
            this.SectionCodeNm_tEdit.TabStop = false;
            // 
            // tEdit_SectionCodeAllowZero
            // 
            appearance65.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_SectionCodeAllowZero.ActiveAppearance = appearance65;
            appearance66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance66.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_SectionCodeAllowZero.Appearance = appearance66;
            this.tEdit_SectionCodeAllowZero.AutoSelect = true;
            this.tEdit_SectionCodeAllowZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_SectionCodeAllowZero.DataText = "";
            this.tEdit_SectionCodeAllowZero.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_SectionCodeAllowZero.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tEdit_SectionCodeAllowZero.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.tEdit_SectionCodeAllowZero.Location = new System.Drawing.Point(119, 6);
            this.tEdit_SectionCodeAllowZero.MaxLength = 6;
            this.tEdit_SectionCodeAllowZero.Name = "tEdit_SectionCodeAllowZero";
            this.tEdit_SectionCodeAllowZero.Size = new System.Drawing.Size(28, 24);
            this.tEdit_SectionCodeAllowZero.TabIndex = 2;
            // 
            // RateMngCustCd_tEdit
            // 
            this.RateMngCustCd_tEdit.ActiveAppearance = appearance96;
            appearance22.ForeColorDisabled = System.Drawing.Color.Black;
            this.RateMngCustCd_tEdit.Appearance = appearance22;
            this.RateMngCustCd_tEdit.AutoSelect = true;
            this.RateMngCustCd_tEdit.DataText = "";
            this.RateMngCustCd_tEdit.Enabled = false;
            this.RateMngCustCd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.RateMngCustCd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.RateMngCustCd_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.RateMngCustCd_tEdit.Location = new System.Drawing.Point(438, 36);
            this.RateMngCustCd_tEdit.MaxLength = 1;
            this.RateMngCustCd_tEdit.Name = "RateMngCustCd_tEdit";
            this.RateMngCustCd_tEdit.ReadOnly = true;
            this.RateMngCustCd_tEdit.Size = new System.Drawing.Size(20, 24);
            this.RateMngCustCd_tEdit.TabIndex = 16;
            this.RateMngCustCd_tEdit.TabStop = false;
            // 
            // RateMngCustNm_tEdit
            // 
            appearance94.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.RateMngCustNm_tEdit.ActiveAppearance = appearance94;
            appearance95.BackColor = System.Drawing.Color.Gainsboro;
            appearance95.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance95.ForeColorDisabled = System.Drawing.Color.Black;
            this.RateMngCustNm_tEdit.Appearance = appearance95;
            this.RateMngCustNm_tEdit.AutoSelect = true;
            this.RateMngCustNm_tEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.RateMngCustNm_tEdit.DataText = "";
            this.RateMngCustNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.RateMngCustNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 50, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.RateMngCustNm_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.RateMngCustNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.RateMngCustNm_tEdit.Location = new System.Drawing.Point(464, 36);
            this.RateMngCustNm_tEdit.MaxLength = 50;
            this.RateMngCustNm_tEdit.Name = "RateMngCustNm_tEdit";
            this.RateMngCustNm_tEdit.ReadOnly = true;
            this.RateMngCustNm_tEdit.Size = new System.Drawing.Size(516, 24);
            this.RateMngCustNm_tEdit.TabIndex = 18;
            this.RateMngCustNm_tEdit.TabStop = false;
            // 
            // RateMngGoodsCd_tEdit
            // 
            this.RateMngGoodsCd_tEdit.ActiveAppearance = appearance97;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            this.RateMngGoodsCd_tEdit.Appearance = appearance11;
            this.RateMngGoodsCd_tEdit.AutoSelect = true;
            this.RateMngGoodsCd_tEdit.DataText = "";
            this.RateMngGoodsCd_tEdit.Enabled = false;
            this.RateMngGoodsCd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.RateMngGoodsCd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, false));
            this.RateMngGoodsCd_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.RateMngGoodsCd_tEdit.Location = new System.Drawing.Point(438, 66);
            this.RateMngGoodsCd_tEdit.MaxLength = 1;
            this.RateMngGoodsCd_tEdit.Name = "RateMngGoodsCd_tEdit";
            this.RateMngGoodsCd_tEdit.ReadOnly = true;
            this.RateMngGoodsCd_tEdit.Size = new System.Drawing.Size(20, 24);
            this.RateMngGoodsCd_tEdit.TabIndex = 20;
            this.RateMngGoodsCd_tEdit.TabStop = false;
            // 
            // SectionCode_uLabel
            // 
            appearance80.ForeColorDisabled = System.Drawing.Color.Black;
            appearance80.TextHAlignAsString = "Left";
            appearance80.TextVAlignAsString = "Middle";
            this.SectionCode_uLabel.Appearance = appearance80;
            this.SectionCode_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.SectionCode_uLabel.Location = new System.Drawing.Point(30, 6);
            this.SectionCode_uLabel.Name = "SectionCode_uLabel";
            this.SectionCode_uLabel.Size = new System.Drawing.Size(89, 24);
            this.SectionCode_uLabel.TabIndex = 900;
            this.SectionCode_uLabel.Text = "���_";
            // 
            // UnitPriceKindWay_tComboEditor
            // 
            appearance91.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UnitPriceKindWay_tComboEditor.ActiveAppearance = appearance91;
            appearance92.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance92.ForeColorDisabled = System.Drawing.Color.Black;
            this.UnitPriceKindWay_tComboEditor.Appearance = appearance92;
            this.UnitPriceKindWay_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.UnitPriceKindWay_tComboEditor.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            appearance93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance93.ForeColorDisabled = System.Drawing.Color.Black;
            this.UnitPriceKindWay_tComboEditor.ItemAppearance = appearance93;
            this.UnitPriceKindWay_tComboEditor.Location = new System.Drawing.Point(119, 66);
            this.UnitPriceKindWay_tComboEditor.Name = "UnitPriceKindWay_tComboEditor";
            this.UnitPriceKindWay_tComboEditor.Size = new System.Drawing.Size(153, 24);
            this.UnitPriceKindWay_tComboEditor.TabIndex = 10;
            this.UnitPriceKindWay_tComboEditor.ValueChanged += new System.EventHandler(this.UnitPriceKindWay_tComboEditor_ValueChanged);
            this.UnitPriceKindWay_tComboEditor.Leave += new System.EventHandler(this.UnitPriceKindWay_tComboEditor_Leave);
            // 
            // Mode_Label
            // 
            appearance81.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance81.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance81.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance81.ForeColor = System.Drawing.Color.Yellow;
            appearance81.ForeColorDisabled = System.Drawing.Color.Yellow;
            appearance81.TextHAlignAsString = "Center";
            appearance81.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance81;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.Mode_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Mode_Label.Location = new System.Drawing.Point(926, 6);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(64, 25);
            this.Mode_Label.TabIndex = 900;
            // 
            // UnitPriceKind_tComboEditor
            // 
            appearance98.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UnitPriceKind_tComboEditor.ActiveAppearance = appearance98;
            appearance99.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance99.ForeColorDisabled = System.Drawing.Color.Black;
            this.UnitPriceKind_tComboEditor.Appearance = appearance99;
            this.UnitPriceKind_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.UnitPriceKind_tComboEditor.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            appearance100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance100.ForeColorDisabled = System.Drawing.Color.Black;
            this.UnitPriceKind_tComboEditor.ItemAppearance = appearance100;
            this.UnitPriceKind_tComboEditor.Location = new System.Drawing.Point(119, 36);
            this.UnitPriceKind_tComboEditor.Name = "UnitPriceKind_tComboEditor";
            this.UnitPriceKind_tComboEditor.Size = new System.Drawing.Size(152, 24);
            this.UnitPriceKind_tComboEditor.TabIndex = 8;
            this.UnitPriceKind_tComboEditor.ValueChanged += new System.EventHandler(this.UnitPriceKind_tComboEditor_ValueChanged);
            // 
            // RateMngGoodsNm_tEdit
            // 
            appearance89.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.RateMngGoodsNm_tEdit.ActiveAppearance = appearance89;
            appearance90.BackColor = System.Drawing.Color.Gainsboro;
            appearance90.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance90.ForeColorDisabled = System.Drawing.Color.Black;
            this.RateMngGoodsNm_tEdit.Appearance = appearance90;
            this.RateMngGoodsNm_tEdit.AutoSelect = true;
            this.RateMngGoodsNm_tEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.RateMngGoodsNm_tEdit.DataText = "";
            this.RateMngGoodsNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.RateMngGoodsNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 50, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.RateMngGoodsNm_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.RateMngGoodsNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.RateMngGoodsNm_tEdit.Location = new System.Drawing.Point(464, 66);
            this.RateMngGoodsNm_tEdit.MaxLength = 50;
            this.RateMngGoodsNm_tEdit.Name = "RateMngGoodsNm_tEdit";
            this.RateMngGoodsNm_tEdit.ReadOnly = true;
            this.RateMngGoodsNm_tEdit.Size = new System.Drawing.Size(516, 24);
            this.RateMngGoodsNm_tEdit.TabIndex = 22;
            this.RateMngGoodsNm_tEdit.TabStop = false;
            // 
            // UnitPriceKind_Label
            // 
            appearance82.ForeColorDisabled = System.Drawing.Color.Black;
            appearance82.TextHAlignAsString = "Left";
            appearance82.TextVAlignAsString = "Middle";
            this.UnitPriceKind_Label.Appearance = appearance82;
            this.UnitPriceKind_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.UnitPriceKind_Label.Location = new System.Drawing.Point(30, 36);
            this.UnitPriceKind_Label.Name = "UnitPriceKind_Label";
            this.UnitPriceKind_Label.Size = new System.Drawing.Size(76, 24);
            this.UnitPriceKind_Label.TabIndex = 900;
            this.UnitPriceKind_Label.Text = "�P�����";
            // 
            // RateSettingDivide_tEdit
            // 
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.RateSettingDivide_tEdit.ActiveAppearance = appearance43;
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance44.ForeColorDisabled = System.Drawing.Color.Black;
            this.RateSettingDivide_tEdit.Appearance = appearance44;
            this.RateSettingDivide_tEdit.AutoSelect = true;
            this.RateSettingDivide_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.RateSettingDivide_tEdit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.RateSettingDivide_tEdit.DataText = "";
            this.RateSettingDivide_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.RateSettingDivide_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
            this.RateSettingDivide_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.RateSettingDivide_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.RateSettingDivide_tEdit.Location = new System.Drawing.Point(438, 6);
            this.RateSettingDivide_tEdit.MaxLength = 2;
            this.RateSettingDivide_tEdit.Name = "RateSettingDivide_tEdit";
            this.RateSettingDivide_tEdit.Size = new System.Drawing.Size(28, 24);
            this.RateSettingDivide_tEdit.TabIndex = 12;
            // 
            // RateSettingDivideGuide_Button
            // 
            appearance88.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance88.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.RateSettingDivideGuide_Button.Appearance = appearance88;
            this.RateSettingDivideGuide_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RateSettingDivideGuide_Button.Location = new System.Drawing.Point(472, 6);
            this.RateSettingDivideGuide_Button.Name = "RateSettingDivideGuide_Button";
            this.RateSettingDivideGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.RateSettingDivideGuide_Button.TabIndex = 14;
            ultraToolTipInfo2.ToolTipText = "�|���ݒ�敪�K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.RateSettingDivideGuide_Button, ultraToolTipInfo2);
            this.RateSettingDivideGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.RateSettingDivideGuide_Button.Click += new System.EventHandler(this.RateSettingDivideGuide_Button_Click);
            // 
            // UnitPriceKindWay_Label
            // 
            appearance83.ForeColorDisabled = System.Drawing.Color.Black;
            appearance83.TextHAlignAsString = "Left";
            appearance83.TextVAlignAsString = "Middle";
            this.UnitPriceKindWay_Label.Appearance = appearance83;
            this.UnitPriceKindWay_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.UnitPriceKindWay_Label.Location = new System.Drawing.Point(30, 66);
            this.UnitPriceKindWay_Label.Name = "UnitPriceKindWay_Label";
            this.UnitPriceKindWay_Label.Size = new System.Drawing.Size(73, 24);
            this.UnitPriceKindWay_Label.TabIndex = 900;
            this.UnitPriceKindWay_Label.Text = "�ݒ���@";
            // 
            // RateMngCust_Label
            // 
            appearance86.ForeColorDisabled = System.Drawing.Color.Black;
            appearance86.TextHAlignAsString = "Left";
            appearance86.TextVAlignAsString = "Middle";
            this.RateMngCust_Label.Appearance = appearance86;
            this.RateMngCust_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.RateMngCust_Label.Location = new System.Drawing.Point(319, 36);
            this.RateMngCust_Label.Name = "RateMngCust_Label";
            this.RateMngCust_Label.Size = new System.Drawing.Size(111, 24);
            this.RateMngCust_Label.TabIndex = 900;
            this.RateMngCust_Label.Text = "�����ݒ�敪";
            // 
            // RateMngGoods_Label
            // 
            appearance85.ForeColorDisabled = System.Drawing.Color.Black;
            appearance85.TextHAlignAsString = "Left";
            appearance85.TextVAlignAsString = "Middle";
            this.RateMngGoods_Label.Appearance = appearance85;
            this.RateMngGoods_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.RateMngGoods_Label.Location = new System.Drawing.Point(319, 66);
            this.RateMngGoods_Label.Name = "RateMngGoods_Label";
            this.RateMngGoods_Label.Size = new System.Drawing.Size(111, 24);
            this.RateMngGoods_Label.TabIndex = 900;
            this.RateMngGoods_Label.Text = "���i�ݒ�敪";
            // 
            // RateSettingDivide_Label
            // 
            appearance72.ForeColorDisabled = System.Drawing.Color.Black;
            appearance72.TextHAlignAsString = "Left";
            appearance72.TextVAlignAsString = "Middle";
            this.RateSettingDivide_Label.Appearance = appearance72;
            this.RateSettingDivide_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.RateSettingDivide_Label.Location = new System.Drawing.Point(319, 6);
            this.RateSettingDivide_Label.Name = "RateSettingDivide_Label";
            this.RateSettingDivide_Label.Size = new System.Drawing.Size(106, 24);
            this.RateSettingDivide_Label.TabIndex = 900;
            this.RateSettingDivide_Label.Text = "�|���ݒ�敪";
            // 
            // tShape1
            // 
            this.tShape1.BackColor = System.Drawing.Color.Transparent;
            this.tShape1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tShape1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tShape1.HatchBackColor = System.Drawing.Color.Empty;
            this.tShape1.HatchForeColor = System.Drawing.Color.Empty;
            this.tShape1.Location = new System.Drawing.Point(0, 0);
            this.tShape1.Name = "tShape1";
            this.tShape1.ShapeStyle = Broadleaf.Library.Windows.Forms.emShapeStyle.ssRectangle;
            this.tShape1.Size = new System.Drawing.Size(995, 96);
            this.tShape1.TabIndex = 1137;
            // 
            // Goods_panel
            // 
            this.Goods_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Goods_panel.Controls.Add(this.tEdit_GoodsNo);
            this.Goods_panel.Controls.Add(this.tNedit_BLGoodsCode);
            this.Goods_panel.Controls.Add(this.tNedit_BLGloupCode);
            this.Goods_panel.Controls.Add(this.tNedit_GoodsMGroup);
            this.Goods_panel.Controls.Add(this.Group_Title_uLabel);
            this.Goods_panel.Controls.Add(this.BLGoodsGuide_Button);
            this.Goods_panel.Controls.Add(this.BLGroupGuide_Button);
            this.Goods_panel.Controls.Add(this.GoodsMakerCd_Grp_Label);
            this.Goods_panel.Controls.Add(this.GoodsRateGrpGuide_Button);
            this.Goods_panel.Controls.Add(this.GoodsRateRank_Label);
            this.Goods_panel.Controls.Add(this.BLGoodsName_tEdit);
            this.Goods_panel.Controls.Add(this.tNedit_GoodsMakerCd);
            this.Goods_panel.Controls.Add(this.BLGroupName_tEdit);
            this.Goods_panel.Controls.Add(this.MakerName_tEdit);
            this.Goods_panel.Controls.Add(this.GoodsRateGrpName_tEdit);
            this.Goods_panel.Controls.Add(this.MakerGuide_Button);
            this.Goods_panel.Controls.Add(this.GoodsNo_Label);
            this.Goods_panel.Controls.Add(this.GoodsRateGrp_Label);
            this.Goods_panel.Controls.Add(this.BLGroup_Label);
            this.Goods_panel.Controls.Add(this.GoodsRateRank_tEdit);
            this.Goods_panel.Controls.Add(this.BLGoods_Label);
            this.Goods_panel.Controls.Add(this.tEdit_GoodsName);
            this.Goods_panel.Controls.Add(this.Goods_tShape);
            this.Goods_panel.Location = new System.Drawing.Point(528, 112);
            this.Goods_panel.Name = "Goods_panel";
            this.Goods_panel.Size = new System.Drawing.Size(477, 216);
            this.Goods_panel.TabIndex = 37;
            // 
            // tEdit_GoodsNo
            // 
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_GoodsNo.ActiveAppearance = appearance40;
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance41.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_GoodsNo.Appearance = appearance41;
            this.tEdit_GoodsNo.AutoSelect = true;
            this.tEdit_GoodsNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_GoodsNo.DataText = "";
            this.tEdit_GoodsNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_GoodsNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 40, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
            this.tEdit_GoodsNo.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.tEdit_GoodsNo.Location = new System.Drawing.Point(152, 156);
            this.tEdit_GoodsNo.MaxLength = 40;
            this.tEdit_GoodsNo.Name = "tEdit_GoodsNo";
            this.tEdit_GoodsNo.Size = new System.Drawing.Size(315, 24);
            this.tEdit_GoodsNo.TabIndex = 64;
            // 
            // tNedit_BLGoodsCode
            // 
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_BLGoodsCode.ActiveAppearance = appearance31;
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance32.ForeColorDisabled = System.Drawing.Color.Black;
            appearance32.TextHAlignAsString = "Right";
            this.tNedit_BLGoodsCode.Appearance = appearance32;
            this.tNedit_BLGoodsCode.AutoSelect = true;
            this.tNedit_BLGoodsCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_BLGoodsCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BLGoodsCode.DataText = "";
            this.tNedit_BLGoodsCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BLGoodsCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BLGoodsCode.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.tNedit_BLGoodsCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BLGoodsCode.Location = new System.Drawing.Point(152, 126);
            this.tNedit_BLGoodsCode.MaxLength = 6;
            this.tNedit_BLGoodsCode.Name = "tNedit_BLGoodsCode";
            this.tNedit_BLGoodsCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_BLGoodsCode.Size = new System.Drawing.Size(59, 24);
            this.tNedit_BLGoodsCode.TabIndex = 58;
            // 
            // tNedit_BLGloupCode
            // 
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_BLGloupCode.ActiveAppearance = appearance49;
            appearance50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance50.ForeColorDisabled = System.Drawing.Color.Black;
            appearance50.TextHAlignAsString = "Right";
            this.tNedit_BLGloupCode.Appearance = appearance50;
            this.tNedit_BLGloupCode.AutoSelect = true;
            this.tNedit_BLGloupCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_BLGloupCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_BLGloupCode.DataText = "";
            this.tNedit_BLGloupCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_BLGloupCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_BLGloupCode.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.tNedit_BLGloupCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_BLGloupCode.Location = new System.Drawing.Point(152, 96);
            this.tNedit_BLGloupCode.MaxLength = 6;
            this.tNedit_BLGloupCode.Name = "tNedit_BLGloupCode";
            this.tNedit_BLGloupCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_BLGloupCode.Size = new System.Drawing.Size(59, 24);
            this.tNedit_BLGloupCode.TabIndex = 52;
            // 
            // tNedit_GoodsMGroup
            // 
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_GoodsMGroup.ActiveAppearance = appearance45;
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance46.ForeColorDisabled = System.Drawing.Color.Black;
            appearance46.TextHAlignAsString = "Right";
            this.tNedit_GoodsMGroup.Appearance = appearance46;
            this.tNedit_GoodsMGroup.AutoSelect = true;
            this.tNedit_GoodsMGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_GoodsMGroup.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMGroup.DataText = "";
            this.tNedit_GoodsMGroup.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMGroup.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMGroup.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.tNedit_GoodsMGroup.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMGroup.Location = new System.Drawing.Point(152, 66);
            this.tNedit_GoodsMGroup.MaxLength = 6;
            this.tNedit_GoodsMGroup.Name = "tNedit_GoodsMGroup";
            this.tNedit_GoodsMGroup.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_GoodsMGroup.Size = new System.Drawing.Size(59, 24);
            this.tNedit_GoodsMGroup.TabIndex = 46;
            // 
            // Group_Title_uLabel
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance1.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.ForeColorDisabled = System.Drawing.Color.White;
            appearance1.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance1.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Group_Title_uLabel.Appearance = appearance1;
            this.Group_Title_uLabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.Group_Title_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Group_Title_uLabel.Location = new System.Drawing.Point(0, 0);
            this.Group_Title_uLabel.Name = "Group_Title_uLabel";
            this.Group_Title_uLabel.Size = new System.Drawing.Size(25, 216);
            this.Group_Title_uLabel.TabIndex = 1106;
            this.Group_Title_uLabel.Text = "���i�ݒ�";
            // 
            // BLGoodsGuide_Button
            // 
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.BLGoodsGuide_Button.Appearance = appearance2;
            this.BLGoodsGuide_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BLGoodsGuide_Button.Location = new System.Drawing.Point(445, 126);
            this.BLGoodsGuide_Button.Name = "BLGoodsGuide_Button";
            this.BLGoodsGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.BLGoodsGuide_Button.TabIndex = 62;
            ultraToolTipInfo3.ToolTipText = "BL���ރK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.BLGoodsGuide_Button, ultraToolTipInfo3);
            this.BLGoodsGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.BLGoodsGuide_Button.Click += new System.EventHandler(this.BLGoodsGuide_Button_Click);
            // 
            // BLGroupGuide_Button
            // 
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.BLGroupGuide_Button.Appearance = appearance3;
            this.BLGroupGuide_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BLGroupGuide_Button.Location = new System.Drawing.Point(445, 96);
            this.BLGroupGuide_Button.Name = "BLGroupGuide_Button";
            this.BLGroupGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.BLGroupGuide_Button.TabIndex = 56;
            ultraToolTipInfo4.ToolTipText = "��ٰ�ߺ��ރK�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.BLGroupGuide_Button, ultraToolTipInfo4);
            this.BLGroupGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.BLGroupGuide_Button.Click += new System.EventHandler(this.BLGroupGuide_Button_Click);
            // 
            // GoodsMakerCd_Grp_Label
            // 
            appearance34.ForeColorDisabled = System.Drawing.Color.Black;
            appearance34.TextHAlignAsString = "Left";
            appearance34.TextVAlignAsString = "Middle";
            this.GoodsMakerCd_Grp_Label.Appearance = appearance34;
            this.GoodsMakerCd_Grp_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.GoodsMakerCd_Grp_Label.Location = new System.Drawing.Point(33, 6);
            this.GoodsMakerCd_Grp_Label.Name = "GoodsMakerCd_Grp_Label";
            this.GoodsMakerCd_Grp_Label.Size = new System.Drawing.Size(80, 24);
            this.GoodsMakerCd_Grp_Label.TabIndex = 900;
            this.GoodsMakerCd_Grp_Label.Text = "���[�J�[";
            // 
            // GoodsRateGrpGuide_Button
            // 
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.GoodsRateGrpGuide_Button.Appearance = appearance4;
            this.GoodsRateGrpGuide_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GoodsRateGrpGuide_Button.Location = new System.Drawing.Point(445, 66);
            this.GoodsRateGrpGuide_Button.Name = "GoodsRateGrpGuide_Button";
            this.GoodsRateGrpGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.GoodsRateGrpGuide_Button.TabIndex = 50;
            ultraToolTipInfo5.ToolTipText = "���i�|����ٰ�߃K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.GoodsRateGrpGuide_Button, ultraToolTipInfo5);
            this.GoodsRateGrpGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.GoodsRateGrpGuide_Button.Click += new System.EventHandler(this.GoodsRateGrpGuide_Button_Click);
            // 
            // GoodsRateRank_Label
            // 
            appearance33.ForeColorDisabled = System.Drawing.Color.Black;
            appearance33.TextHAlignAsString = "Left";
            appearance33.TextVAlignAsString = "Middle";
            this.GoodsRateRank_Label.Appearance = appearance33;
            this.GoodsRateRank_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.GoodsRateRank_Label.Location = new System.Drawing.Point(33, 36);
            this.GoodsRateRank_Label.Name = "GoodsRateRank_Label";
            this.GoodsRateRank_Label.Size = new System.Drawing.Size(80, 24);
            this.GoodsRateRank_Label.TabIndex = 900;
            this.GoodsRateRank_Label.Text = "�w��";
            // 
            // BLGoodsName_tEdit
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BLGoodsName_tEdit.ActiveAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.Gainsboro;
            appearance6.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.BLGoodsName_tEdit.Appearance = appearance6;
            this.BLGoodsName_tEdit.AutoSelect = true;
            this.BLGoodsName_tEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.BLGoodsName_tEdit.DataText = "";
            this.BLGoodsName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.BLGoodsName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 60, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.BLGoodsName_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BLGoodsName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.BLGoodsName_tEdit.Location = new System.Drawing.Point(217, 126);
            this.BLGoodsName_tEdit.MaxLength = 60;
            this.BLGoodsName_tEdit.Name = "BLGoodsName_tEdit";
            this.BLGoodsName_tEdit.ReadOnly = true;
            this.BLGoodsName_tEdit.Size = new System.Drawing.Size(222, 24);
            this.BLGoodsName_tEdit.TabIndex = 60;
            this.BLGoodsName_tEdit.TabStop = false;
            // 
            // tNedit_GoodsMakerCd
            // 
            appearance73.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_GoodsMakerCd.ActiveAppearance = appearance73;
            appearance74.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance74.ForeColor = System.Drawing.Color.Black;
            appearance74.ForeColorDisabled = System.Drawing.Color.Black;
            appearance74.TextHAlignAsString = "Right";
            this.tNedit_GoodsMakerCd.Appearance = appearance74;
            this.tNedit_GoodsMakerCd.AutoSelect = true;
            this.tNedit_GoodsMakerCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_GoodsMakerCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMakerCd.DataText = "";
            this.tNedit_GoodsMakerCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMakerCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMakerCd.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.tNedit_GoodsMakerCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMakerCd.Location = new System.Drawing.Point(152, 6);
            this.tNedit_GoodsMakerCd.MaxLength = 6;
            this.tNedit_GoodsMakerCd.Name = "tNedit_GoodsMakerCd";
            this.tNedit_GoodsMakerCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_GoodsMakerCd.Size = new System.Drawing.Size(59, 24);
            this.tNedit_GoodsMakerCd.TabIndex = 38;
            // 
            // BLGroupName_tEdit
            // 
            this.BLGroupName_tEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BLGroupName_tEdit.ActiveAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.Gainsboro;
            appearance8.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            this.BLGroupName_tEdit.Appearance = appearance8;
            this.BLGroupName_tEdit.AutoSelect = true;
            this.BLGroupName_tEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.BLGroupName_tEdit.DataText = "";
            this.BLGroupName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.BLGroupName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 60, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.BLGroupName_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BLGroupName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.BLGroupName_tEdit.Location = new System.Drawing.Point(217, 96);
            this.BLGroupName_tEdit.MaxLength = 60;
            this.BLGroupName_tEdit.Name = "BLGroupName_tEdit";
            this.BLGroupName_tEdit.ReadOnly = true;
            this.BLGroupName_tEdit.Size = new System.Drawing.Size(222, 24);
            this.BLGroupName_tEdit.TabIndex = 54;
            this.BLGroupName_tEdit.TabStop = false;
            // 
            // MakerName_tEdit
            // 
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakerName_tEdit.ActiveAppearance = appearance29;
            appearance30.BackColor = System.Drawing.Color.Gainsboro;
            appearance30.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance30.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerName_tEdit.Appearance = appearance30;
            this.MakerName_tEdit.AutoSelect = true;
            this.MakerName_tEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.MakerName_tEdit.DataText = "";
            this.MakerName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MakerName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.MakerName_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MakerName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.MakerName_tEdit.Location = new System.Drawing.Point(217, 6);
            this.MakerName_tEdit.MaxLength = 30;
            this.MakerName_tEdit.Name = "MakerName_tEdit";
            this.MakerName_tEdit.ReadOnly = true;
            this.MakerName_tEdit.Size = new System.Drawing.Size(222, 24);
            this.MakerName_tEdit.TabIndex = 40;
            this.MakerName_tEdit.TabStop = false;
            // 
            // GoodsRateGrpName_tEdit
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GoodsRateGrpName_tEdit.ActiveAppearance = appearance9;
            appearance10.BackColor = System.Drawing.Color.Gainsboro;
            appearance10.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            this.GoodsRateGrpName_tEdit.Appearance = appearance10;
            this.GoodsRateGrpName_tEdit.AutoSelect = true;
            this.GoodsRateGrpName_tEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.GoodsRateGrpName_tEdit.DataText = "";
            this.GoodsRateGrpName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GoodsRateGrpName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 20, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.GoodsRateGrpName_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GoodsRateGrpName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.GoodsRateGrpName_tEdit.Location = new System.Drawing.Point(217, 66);
            this.GoodsRateGrpName_tEdit.MaxLength = 20;
            this.GoodsRateGrpName_tEdit.Name = "GoodsRateGrpName_tEdit";
            this.GoodsRateGrpName_tEdit.ReadOnly = true;
            this.GoodsRateGrpName_tEdit.Size = new System.Drawing.Size(222, 24);
            this.GoodsRateGrpName_tEdit.TabIndex = 48;
            this.GoodsRateGrpName_tEdit.TabStop = false;
            // 
            // MakerGuide_Button
            // 
            appearance28.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance28.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.MakerGuide_Button.Appearance = appearance28;
            this.MakerGuide_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MakerGuide_Button.Location = new System.Drawing.Point(445, 6);
            this.MakerGuide_Button.Name = "MakerGuide_Button";
            this.MakerGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.MakerGuide_Button.TabIndex = 42;
            ultraToolTipInfo6.ToolTipText = "���[�J�[�K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.MakerGuide_Button, ultraToolTipInfo6);
            this.MakerGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.MakerGuide_Button.Click += new System.EventHandler(this.MakerGuide_Button_Click);
            // 
            // GoodsNo_Label
            // 
            this.GoodsNo_Label.AlphaBlendMode = Infragistics.Win.AlphaBlendMode.Disabled;
            appearance27.ForeColorDisabled = System.Drawing.Color.Black;
            appearance27.TextHAlignAsString = "Left";
            appearance27.TextVAlignAsString = "Middle";
            this.GoodsNo_Label.Appearance = appearance27;
            this.GoodsNo_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.GoodsNo_Label.Location = new System.Drawing.Point(33, 156);
            this.GoodsNo_Label.Name = "GoodsNo_Label";
            this.GoodsNo_Label.Size = new System.Drawing.Size(65, 24);
            this.GoodsNo_Label.TabIndex = 900;
            this.GoodsNo_Label.Text = "�i��";
            // 
            // GoodsRateGrp_Label
            // 
            appearance26.ForeColorDisabled = System.Drawing.Color.Black;
            appearance26.TextHAlignAsString = "Left";
            appearance26.TextVAlignAsString = "Middle";
            this.GoodsRateGrp_Label.Appearance = appearance26;
            this.GoodsRateGrp_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.GoodsRateGrp_Label.Location = new System.Drawing.Point(33, 66);
            this.GoodsRateGrp_Label.Name = "GoodsRateGrp_Label";
            this.GoodsRateGrp_Label.Size = new System.Drawing.Size(91, 24);
            this.GoodsRateGrp_Label.TabIndex = 900;
            this.GoodsRateGrp_Label.Text = "���i�|���f";
            // 
            // BLGroup_Label
            // 
            this.BLGroup_Label.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            appearance35.ForeColorDisabled = System.Drawing.Color.Black;
            appearance35.TextHAlignAsString = "Left";
            appearance35.TextVAlignAsString = "Middle";
            this.BLGroup_Label.Appearance = appearance35;
            this.BLGroup_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.BLGroup_Label.Location = new System.Drawing.Point(33, 96);
            this.BLGroup_Label.Name = "BLGroup_Label";
            this.BLGroup_Label.Size = new System.Drawing.Size(113, 24);
            this.BLGroup_Label.TabIndex = 900;
            this.BLGroup_Label.Text = "��ٰ�ߺ���";
            // 
            // GoodsRateRank_tEdit
            // 
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GoodsRateRank_tEdit.ActiveAppearance = appearance47;
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance48.ForeColorDisabled = System.Drawing.Color.Black;
            this.GoodsRateRank_tEdit.Appearance = appearance48;
            this.GoodsRateRank_tEdit.AutoSelect = true;
            this.GoodsRateRank_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.GoodsRateRank_tEdit.DataText = "";
            this.GoodsRateRank_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GoodsRateRank_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, false, true));
            this.GoodsRateRank_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.GoodsRateRank_tEdit.Location = new System.Drawing.Point(152, 36);
            this.GoodsRateRank_tEdit.MaxLength = 2;
            this.GoodsRateRank_tEdit.Name = "GoodsRateRank_tEdit";
            this.GoodsRateRank_tEdit.Size = new System.Drawing.Size(28, 24);
            this.GoodsRateRank_tEdit.TabIndex = 44;
            // 
            // BLGoods_Label
            // 
            appearance36.ForeColorDisabled = System.Drawing.Color.Black;
            appearance36.TextHAlignAsString = "Left";
            appearance36.TextVAlignAsString = "Middle";
            this.BLGoods_Label.Appearance = appearance36;
            this.BLGoods_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.BLGoods_Label.Location = new System.Drawing.Point(33, 126);
            this.BLGoods_Label.Name = "BLGoods_Label";
            this.BLGoods_Label.Size = new System.Drawing.Size(113, 24);
            this.BLGoods_Label.TabIndex = 900;
            this.BLGoods_Label.Text = "BL����";
            // 
            // tEdit_GoodsName
            // 
            appearance37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_GoodsName.ActiveAppearance = appearance37;
            appearance38.BackColor = System.Drawing.Color.Gainsboro;
            appearance38.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance38.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_GoodsName.Appearance = appearance38;
            this.tEdit_GoodsName.AutoSelect = true;
            this.tEdit_GoodsName.BackColor = System.Drawing.Color.Gainsboro;
            this.tEdit_GoodsName.DataText = "";
            this.tEdit_GoodsName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_GoodsName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 100, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_GoodsName.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_GoodsName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_GoodsName.Location = new System.Drawing.Point(152, 186);
            this.tEdit_GoodsName.MaxLength = 100;
            this.tEdit_GoodsName.Name = "tEdit_GoodsName";
            this.tEdit_GoodsName.ReadOnly = true;
            this.tEdit_GoodsName.Size = new System.Drawing.Size(315, 24);
            this.tEdit_GoodsName.TabIndex = 66;
            this.tEdit_GoodsName.TabStop = false;
            // 
            // Goods_tShape
            // 
            this.Goods_tShape.BackColor = System.Drawing.Color.Transparent;
            this.Goods_tShape.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Goods_tShape.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Goods_tShape.HatchBackColor = System.Drawing.Color.Empty;
            this.Goods_tShape.HatchForeColor = System.Drawing.Color.Empty;
            this.Goods_tShape.Location = new System.Drawing.Point(0, 0);
            this.Goods_tShape.Name = "Goods_tShape";
            this.Goods_tShape.ShapeStyle = Broadleaf.Library.Windows.Forms.emShapeStyle.ssRectangle;
            this.Goods_tShape.Size = new System.Drawing.Size(477, 216);
            this.Goods_tShape.TabIndex = 1136;
            // 
            // Customer_panel
            // 
            this.Customer_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Customer_panel.Controls.Add(this.CustRateGrpGuide_Button);
            this.Customer_panel.Controls.Add(this.tEdit_CustRateGrpName);
            this.Customer_panel.Controls.Add(this.tNedit_CustRateGrpCodeZero);
            this.Customer_panel.Controls.Add(this.Customer_Title_uLabel);
            this.Customer_panel.Controls.Add(this.CustRateGrp_Label);
            this.Customer_panel.Controls.Add(this.SupplierGuide_Button);
            this.Customer_panel.Controls.Add(this.CustomerCode_Label);
            this.Customer_panel.Controls.Add(this.tNedit_CustomerCode);
            this.Customer_panel.Controls.Add(this.tNedit_SupplierCd);
            this.Customer_panel.Controls.Add(this.SupplierCdNm_tEdit);
            this.Customer_panel.Controls.Add(this.CustomerGuide_Button);
            this.Customer_panel.Controls.Add(this.CustomerCodeNm_tEdit);
            this.Customer_panel.Controls.Add(this.SupplierCd_Label);
            this.Customer_panel.Controls.Add(this.tShape2);
            this.Customer_panel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Customer_panel.Location = new System.Drawing.Point(10, 112);
            this.Customer_panel.Name = "Customer_panel";
            this.Customer_panel.Size = new System.Drawing.Size(512, 96);
            this.Customer_panel.TabIndex = 23;
            // 
            // CustRateGrpGuide_Button
            // 
            appearance130.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance130.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.CustRateGrpGuide_Button.Appearance = appearance130;
            this.CustRateGrpGuide_Button.Location = new System.Drawing.Point(482, 36);
            this.CustRateGrpGuide_Button.Name = "CustRateGrpGuide_Button";
            this.CustRateGrpGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.CustRateGrpGuide_Button.TabIndex = 31;
            ultraToolTipInfo7.ToolTipText = "���Ӑ�|���O���[�v�K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.CustRateGrpGuide_Button, ultraToolTipInfo7);
            this.CustRateGrpGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustRateGrpGuide_Button.Click += new System.EventHandler(this.CustRateGrpGuide_Button_Click);
            // 
            // tEdit_CustRateGrpName
            // 
            appearance126.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_CustRateGrpName.ActiveAppearance = appearance126;
            appearance127.BackColor = System.Drawing.Color.Gainsboro;
            appearance127.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance127.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_CustRateGrpName.Appearance = appearance127;
            this.tEdit_CustRateGrpName.AutoSelect = true;
            this.tEdit_CustRateGrpName.BackColor = System.Drawing.Color.Gainsboro;
            this.tEdit_CustRateGrpName.DataText = "";
            this.tEdit_CustRateGrpName.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_CustRateGrpName.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 60, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.tEdit_CustRateGrpName.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tEdit_CustRateGrpName.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.tEdit_CustRateGrpName.Location = new System.Drawing.Point(270, 36);
            this.tEdit_CustRateGrpName.MaxLength = 60;
            this.tEdit_CustRateGrpName.Name = "tEdit_CustRateGrpName";
            this.tEdit_CustRateGrpName.ReadOnly = true;
            this.tEdit_CustRateGrpName.Size = new System.Drawing.Size(206, 24);
            this.tEdit_CustRateGrpName.TabIndex = 30;
            this.tEdit_CustRateGrpName.TabStop = false;
            // 
            // tNedit_CustRateGrpCodeZero
            // 
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance67.TextHAlignAsString = "Right";
            this.tNedit_CustRateGrpCodeZero.ActiveAppearance = appearance67;
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance68.ForeColorDisabled = System.Drawing.Color.Black;
            appearance68.TextHAlignAsString = "Right";
            this.tNedit_CustRateGrpCodeZero.Appearance = appearance68;
            this.tNedit_CustRateGrpCodeZero.AutoSelect = true;
            this.tNedit_CustRateGrpCodeZero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_CustRateGrpCodeZero.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustRateGrpCodeZero.DataText = "";
            this.tNedit_CustRateGrpCodeZero.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustRateGrpCodeZero.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustRateGrpCodeZero.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.tNedit_CustRateGrpCodeZero.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustRateGrpCodeZero.Location = new System.Drawing.Point(182, 36);
            this.tNedit_CustRateGrpCodeZero.MaxLength = 4;
            this.tNedit_CustRateGrpCodeZero.Name = "tNedit_CustRateGrpCodeZero";
            this.tNedit_CustRateGrpCodeZero.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_CustRateGrpCodeZero.Size = new System.Drawing.Size(82, 24);
            this.tNedit_CustRateGrpCodeZero.TabIndex = 29;
            this.tNedit_CustRateGrpCodeZero.Enter += new System.EventHandler(this.tNedit_CustRateGrpCode_Enter);
            // 
            // Customer_Title_uLabel
            // 
            appearance122.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(135)))), ((int)(((byte)(214)))));
            appearance122.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(59)))), ((int)(((byte)(150)))));
            appearance122.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance122.ForeColor = System.Drawing.Color.White;
            appearance122.ForeColorDisabled = System.Drawing.Color.White;
            appearance122.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance122.ImageVAlign = Infragistics.Win.VAlign.Top;
            appearance122.TextHAlignAsString = "Center";
            appearance122.TextVAlignAsString = "Middle";
            this.Customer_Title_uLabel.Appearance = appearance122;
            this.Customer_Title_uLabel.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Etched;
            this.Customer_Title_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Customer_Title_uLabel.Location = new System.Drawing.Point(0, 0);
            this.Customer_Title_uLabel.Name = "Customer_Title_uLabel";
            this.Customer_Title_uLabel.Size = new System.Drawing.Size(25, 96);
            this.Customer_Title_uLabel.TabIndex = 900;
            this.Customer_Title_uLabel.Text = "�����ݒ�";
            // 
            // CustRateGrp_Label
            // 
            appearance136.ForeColorDisabled = System.Drawing.Color.Black;
            appearance136.TextHAlignAsString = "Left";
            appearance136.TextVAlignAsString = "Middle";
            this.CustRateGrp_Label.Appearance = appearance136;
            this.CustRateGrp_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.CustRateGrp_Label.Location = new System.Drawing.Point(30, 36);
            this.CustRateGrp_Label.Name = "CustRateGrp_Label";
            this.CustRateGrp_Label.Size = new System.Drawing.Size(141, 24);
            this.CustRateGrp_Label.TabIndex = 900;
            this.CustRateGrp_Label.Text = "���Ӑ�|���O���[�v";
            // 
            // SupplierGuide_Button
            // 
            appearance123.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance123.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.SupplierGuide_Button.Appearance = appearance123;
            this.SupplierGuide_Button.Location = new System.Drawing.Point(482, 66);
            this.SupplierGuide_Button.Name = "SupplierGuide_Button";
            this.SupplierGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.SupplierGuide_Button.TabIndex = 36;
            ultraToolTipInfo8.ToolTipText = "�d����K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.SupplierGuide_Button, ultraToolTipInfo8);
            this.SupplierGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.SupplierGuide_Button.Click += new System.EventHandler(this.SupplierGuide_Button_Click);
            // 
            // CustomerCode_Label
            // 
            appearance39.ForeColorDisabled = System.Drawing.Color.Black;
            appearance39.TextHAlignAsString = "Left";
            appearance39.TextVAlignAsString = "Middle";
            this.CustomerCode_Label.Appearance = appearance39;
            this.CustomerCode_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.CustomerCode_Label.Location = new System.Drawing.Point(30, 6);
            this.CustomerCode_Label.Name = "CustomerCode_Label";
            this.CustomerCode_Label.Size = new System.Drawing.Size(117, 24);
            this.CustomerCode_Label.TabIndex = 900;
            this.CustomerCode_Label.Text = "���Ӑ�R�[�h";
            // 
            // tNedit_CustomerCode
            // 
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CustomerCode.ActiveAppearance = appearance42;
            appearance78.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance78.ForeColorDisabled = System.Drawing.Color.Black;
            appearance78.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode.Appearance = appearance78;
            this.tNedit_CustomerCode.AutoSelect = true;
            this.tNedit_CustomerCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_CustomerCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode.DataText = "";
            this.tNedit_CustomerCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.tNedit_CustomerCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode.Location = new System.Drawing.Point(182, 6);
            this.tNedit_CustomerCode.MaxLength = 8;
            this.tNedit_CustomerCode.Name = "tNedit_CustomerCode";
            this.tNedit_CustomerCode.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_CustomerCode.Size = new System.Drawing.Size(82, 24);
            this.tNedit_CustomerCode.TabIndex = 24;
            // 
            // tNedit_SupplierCd
            // 
            appearance124.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_SupplierCd.ActiveAppearance = appearance124;
            appearance125.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance125.ForeColorDisabled = System.Drawing.Color.Black;
            appearance125.TextHAlignAsString = "Right";
            this.tNedit_SupplierCd.Appearance = appearance125;
            this.tNedit_SupplierCd.AutoSelect = true;
            this.tNedit_SupplierCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_SupplierCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_SupplierCd.DataText = "";
            this.tNedit_SupplierCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_SupplierCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_SupplierCd.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.tNedit_SupplierCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_SupplierCd.Location = new System.Drawing.Point(182, 66);
            this.tNedit_SupplierCd.MaxLength = 6;
            this.tNedit_SupplierCd.Name = "tNedit_SupplierCd";
            this.tNedit_SupplierCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_SupplierCd.Size = new System.Drawing.Size(82, 24);
            this.tNedit_SupplierCd.TabIndex = 32;
            // 
            // SupplierCdNm_tEdit
            // 
            appearance131.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SupplierCdNm_tEdit.ActiveAppearance = appearance131;
            appearance132.BackColor = System.Drawing.Color.Gainsboro;
            appearance132.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance132.ForeColorDisabled = System.Drawing.Color.Black;
            this.SupplierCdNm_tEdit.Appearance = appearance132;
            this.SupplierCdNm_tEdit.AutoSelect = true;
            this.SupplierCdNm_tEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.SupplierCdNm_tEdit.DataText = "";
            this.SupplierCdNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SupplierCdNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 60, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SupplierCdNm_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SupplierCdNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SupplierCdNm_tEdit.Location = new System.Drawing.Point(270, 66);
            this.SupplierCdNm_tEdit.MaxLength = 60;
            this.SupplierCdNm_tEdit.Name = "SupplierCdNm_tEdit";
            this.SupplierCdNm_tEdit.ReadOnly = true;
            this.SupplierCdNm_tEdit.Size = new System.Drawing.Size(206, 24);
            this.SupplierCdNm_tEdit.TabIndex = 34;
            this.SupplierCdNm_tEdit.TabStop = false;
            // 
            // CustomerGuide_Button
            // 
            appearance79.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance79.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.CustomerGuide_Button.Appearance = appearance79;
            this.CustomerGuide_Button.Location = new System.Drawing.Point(482, 6);
            this.CustomerGuide_Button.Name = "CustomerGuide_Button";
            this.CustomerGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.CustomerGuide_Button.TabIndex = 28;
            ultraToolTipInfo9.ToolTipText = "���Ӑ�K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.CustomerGuide_Button, ultraToolTipInfo9);
            this.CustomerGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerGuide_Button.Click += new System.EventHandler(this.CustomerGuide_Button_Click);
            // 
            // CustomerCodeNm_tEdit
            // 
            appearance101.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerCodeNm_tEdit.ActiveAppearance = appearance101;
            appearance102.BackColor = System.Drawing.Color.Gainsboro;
            appearance102.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance102.ForeColorDisabled = System.Drawing.Color.Black;
            this.CustomerCodeNm_tEdit.Appearance = appearance102;
            this.CustomerCodeNm_tEdit.AutoSelect = true;
            this.CustomerCodeNm_tEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.CustomerCodeNm_tEdit.DataText = "";
            this.CustomerCodeNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerCodeNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 60, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CustomerCodeNm_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustomerCodeNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CustomerCodeNm_tEdit.Location = new System.Drawing.Point(270, 6);
            this.CustomerCodeNm_tEdit.MaxLength = 60;
            this.CustomerCodeNm_tEdit.Name = "CustomerCodeNm_tEdit";
            this.CustomerCodeNm_tEdit.ReadOnly = true;
            this.CustomerCodeNm_tEdit.Size = new System.Drawing.Size(206, 24);
            this.CustomerCodeNm_tEdit.TabIndex = 26;
            this.CustomerCodeNm_tEdit.TabStop = false;
            // 
            // SupplierCd_Label
            // 
            appearance69.ForeColorDisabled = System.Drawing.Color.Black;
            appearance69.TextHAlignAsString = "Left";
            appearance69.TextVAlignAsString = "Middle";
            this.SupplierCd_Label.Appearance = appearance69;
            this.SupplierCd_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.SupplierCd_Label.Location = new System.Drawing.Point(30, 66);
            this.SupplierCd_Label.Name = "SupplierCd_Label";
            this.SupplierCd_Label.Size = new System.Drawing.Size(117, 24);
            this.SupplierCd_Label.TabIndex = 900;
            this.SupplierCd_Label.Text = "�d����R�[�h";
            // 
            // tShape2
            // 
            this.tShape2.BackColor = System.Drawing.Color.Transparent;
            this.tShape2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tShape2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tShape2.HatchBackColor = System.Drawing.Color.Empty;
            this.tShape2.HatchForeColor = System.Drawing.Color.Empty;
            this.tShape2.Location = new System.Drawing.Point(0, 0);
            this.tShape2.Name = "tShape2";
            this.tShape2.ShapeStyle = Broadleaf.Library.Windows.Forms.emShapeStyle.ssRectangle;
            this.tShape2.Size = new System.Drawing.Size(512, 96);
            this.tShape2.TabIndex = 1137;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.AlwaysEvent = true;
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.AlwaysEvent = true;
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            // 
            // PMKHN09302UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1016, 614);
            this.Controls.Add(this.Main_panel);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PMKHN09302UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�|���}�X�^";
            this.Load += new System.EventHandler(this.DCKHN09160UA_Load);
            this.Shown += new System.EventHandler(this.DCKHN09160UA_Shown);
            this.Main_panel.ResumeLayout(false);
            this.Main_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_Price)).EndInit();
            this.Detail_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Detail_uGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShape3)).EndInit();
            this.RateCond_panel.ResumeLayout(false);
            this.RateCond_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_RatePriorityOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCodeNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_SectionCodeAllowZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateMngCustCd_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateMngCustNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateMngGoodsCd_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitPriceKindWay_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UnitPriceKind_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateMngGoodsNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RateSettingDivide_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShape1)).EndInit();
            this.Goods_panel.ResumeLayout(false);
            this.Goods_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGoodsCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_BLGloupCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGoodsName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BLGroupName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsRateGrpName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsRateRank_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_GoodsName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Goods_tShape)).EndInit();
            this.Customer_panel.ResumeLayout(false);
            this.Customer_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_CustRateGrpName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustRateGrpCodeZero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCdNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCodeNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShape2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        # region Private Members (Component)

        private System.Windows.Forms.Panel Main_panel;
        private System.Windows.Forms.Panel Detail_panel;
        private System.Windows.Forms.Panel RateCond_panel;
        private Infragistics.Win.Misc.UltraButton SectionGuide_Button;
        private Infragistics.Win.Misc.UltraLabel RateCond_Title_uLabel;
        private Broadleaf.Library.Windows.Forms.TEdit SectionCodeNm_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_SectionCodeAllowZero;
        private Broadleaf.Library.Windows.Forms.TEdit RateMngCustCd_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit RateMngCustNm_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit RateMngGoodsCd_tEdit;
        private Infragistics.Win.Misc.UltraLabel SectionCode_uLabel;
        private Broadleaf.Library.Windows.Forms.TComboEditor UnitPriceKindWay_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Broadleaf.Library.Windows.Forms.TComboEditor UnitPriceKind_tComboEditor;
        private Broadleaf.Library.Windows.Forms.TEdit RateMngGoodsNm_tEdit;
        private Infragistics.Win.Misc.UltraLabel UnitPriceKind_Label;
        private Broadleaf.Library.Windows.Forms.TEdit RateSettingDivide_tEdit;
        private Infragistics.Win.Misc.UltraButton RateSettingDivideGuide_Button;
        private Infragistics.Win.Misc.UltraLabel UnitPriceKindWay_Label;
        private Infragistics.Win.Misc.UltraLabel RateMngCust_Label;
        private Infragistics.Win.Misc.UltraLabel RateMngGoods_Label;
        private Infragistics.Win.Misc.UltraLabel RateSettingDivide_Label;
        private Broadleaf.Library.Windows.Forms.TShape tShape1;
        private System.Windows.Forms.Panel Goods_panel;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_GoodsNo;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_BLGoodsCode;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_BLGloupCode;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_GoodsMGroup;
        private Infragistics.Win.Misc.UltraLabel Group_Title_uLabel;
        private Infragistics.Win.Misc.UltraButton BLGoodsGuide_Button;
        private Infragistics.Win.Misc.UltraButton BLGroupGuide_Button;
        private Infragistics.Win.Misc.UltraLabel GoodsMakerCd_Grp_Label;
        private Infragistics.Win.Misc.UltraButton GoodsRateGrpGuide_Button;
        private Infragistics.Win.Misc.UltraLabel GoodsRateRank_Label;
        private Broadleaf.Library.Windows.Forms.TEdit BLGoodsName_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit BLGroupName_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit MakerName_tEdit;
        private Broadleaf.Library.Windows.Forms.TEdit GoodsRateGrpName_tEdit;
        private Infragistics.Win.Misc.UltraButton MakerGuide_Button;
        private Infragistics.Win.Misc.UltraLabel GoodsNo_Label;
        private Infragistics.Win.Misc.UltraLabel GoodsRateGrp_Label;
        private Infragistics.Win.Misc.UltraLabel BLGroup_Label;
        private Broadleaf.Library.Windows.Forms.TEdit GoodsRateRank_tEdit;
        private Infragistics.Win.Misc.UltraLabel BLGoods_Label;
        private Broadleaf.Library.Windows.Forms.TEdit tEdit_GoodsName;
        private Broadleaf.Library.Windows.Forms.TShape Goods_tShape;
        private System.Windows.Forms.Panel Customer_panel;
        private Infragistics.Win.Misc.UltraLabel Customer_Title_uLabel;
        private Infragistics.Win.Misc.UltraLabel CustRateGrp_Label;
        private Infragistics.Win.Misc.UltraButton SupplierGuide_Button;
        private Infragistics.Win.Misc.UltraLabel CustomerCode_Label;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_CustomerCode;
        private Broadleaf.Library.Windows.Forms.TNedit tNedit_SupplierCd;
        private Broadleaf.Library.Windows.Forms.TEdit SupplierCdNm_tEdit;
        private Infragistics.Win.Misc.UltraButton CustomerGuide_Button;
        private Broadleaf.Library.Windows.Forms.TEdit CustomerCodeNm_tEdit;
        private Infragistics.Win.Misc.UltraLabel SupplierCd_Label;
        private Broadleaf.Library.Windows.Forms.TShape tShape2;
        private System.ComponentModel.IContainer components;
        private UltraLabel ultraLabel1;
        private TShape tShape3;
        private UltraLabel ultraLabel4;
        private UltraLabel ultraLabel3;
        private UltraLabel ultraLabel2;
        private UltraLabel ultraLabel13;
        private UltraLabel ultraLabel15;
        private UltraLabel ultraLabel14;
        private UltraLabel ultraLabel12;
        private UltraLabel ultraLabel11;
        private UltraLabel ultraLabel10;
        private UltraLabel ultraLabel9;
        private UltraLabel ultraLabel8;
        private UltraLabel ultraLabel7;
        private UltraLabel ultraLabel6;
        private UltraLabel ultraLabel5;
        private TNedit tNedit_Price;
        private UltraLabel Price_uLabel;
        private TArrowKeyControl tArrowKeyControl1;
        private UiSetControl uiSetControl1;
        private TRetKeyControl tRetKeyControl1;
        private TNedit tNedit_GoodsMakerCd;
        private TNedit tNedit_RatePriorityOrder;
        private UltraLabel ultraLabel16;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;

        //-----ADD 2010/08/10---------->>>>>
        private Dictionary<string, string> _guideEnableControlDictionary = new Dictionary<string, string>();
        private string _preDCEditorValue = "";
        //-----ADD 2010/08/10----------<<<<<
        # endregion

        #region Contants

        private const string ASSEMBLY_ID = "DCKHN09160U";

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K";
        private const string UPDATE_MODE = "�X�V";
        private const string DELETE_MODE = "�폜";

        private const int COLUMN_COUNT = 10;                    // ��
        private const int ROW_COUNT = 12;                       // �s��

        private const int ROWINDEX_LOTCOUNTABOVE = 0;           // ����(�ȏ�)
        private const int ROWINDEX_LOTCOUNTBELOW = 1;           // ����(�ȉ�)
        private const int ROWINDEX_SALERATEVAL = 2;             // ������
        private const int ROWINDEX_SALEPRICEFL = 3;             // �����z
        private const int ROWINDEX_COSTUPRATE = 4;              // ����UP��
        private const int ROWINDEX_GRSPROFITSECURERATE = 5;     // �e���m�ۗ�
        private const int ROWINDEX_COSTRATEVAL = 6;             // �d����
        private const int ROWINDEX_COSTPRICEFL = 7;             // �d������
        private const int ROWINDEX_USERPRICEFL = 8;             // ���[�U�[�艿
        private const int ROWINDEX_PRICEUPRATE = 9;             // ���iUP��
        private const int ROWINDEX_UNPRCFRACPROCUNIT = 10;      // �[�������P��
        private const int ROWINDEX_UNPRCFRACPROCDIV = 11;       // �[�������敪

        private const string COLUMNKEY_1 = "LotCount1";         // ���ʔ͈�1
        private const string COLUMNKEY_2 = "LotCount2";         // ���ʔ͈�2
        private const string COLUMNKEY_3 = "LotCount3";         // ���ʔ͈�3
        private const string COLUMNKEY_4 = "LotCount4";         // ���ʔ͈�4
        private const string COLUMNKEY_5 = "LotCount5";         // ���ʔ͈�5
        private const string COLUMNKEY_6 = "LotCount6";         // ���ʔ͈�6
        private const string COLUMNKEY_7 = "LotCount7";         // ���ʔ͈�7
        private const string COLUMNKEY_8 = "LotCount8";         // ���ʔ͈�8
        private const string COLUMNKEY_9 = "LotCount9";         // ���ʔ͈�9
        private const string COLUMNKEY_10 = "LotCount10";       // ���ʔ͈�10

        private const string LOTCOUNT_MIN = "0.01";
        private const string LOTCOUNT_MAX = "9,999,999.99";
        //-----UPD 2010/08/10----------->>>>>
        //private const string UNITPRICEKIND_1 = "�����ݒ�";
        //private const string UNITPRICEKIND_2 = "�����ݒ�";
        //private const string UNITPRICEKIND_3 = "���i�ݒ�";
        private const string UNITPRICEKIND_1 = "1:�����ݒ�";
        private const string UNITPRICEKIND_2 = "2:�����ݒ�";
        private const string UNITPRICEKIND_3 = "3:���i�ݒ�";

        //private const string UNITPRICEKINDWAY_0 = "�P�i�ݒ�";
        //private const string UNITPRICEKINDWAY_1 = "�O���[�v�ݒ�";
        private const string UNITPRICEKINDWAY_1 = "1:�O���[�v�ݒ�";
        private const string UNITPRICEKINDWAY_0 = "2:�P�i�ݒ�";

        //private const string UNPRCFRACPROCDIV_1 = "�؎̂�";
        //private const string UNPRCFRACPROCDIV_2 = "�l�̌ܓ�";
        //private const string UNPRCFRACPROCDIV_3 = "�؏グ";
        private const string UNPRCFRACPROCDIV_1 = "1:�؎̂�";
        private const string UNPRCFRACPROCDIV_2 = "2:�l�̌ܓ�";
        private const string UNPRCFRACPROCDIV_3 = "3:�؏グ";
        //-----UPD 2010/08/10-----------<<<<<

        private const string FORMAT_NUM = "###,###";
        private const string FORMAT_DECIMAL = "N";

        private const string ALL_SECTIONCODE = "00";
        private const string ALL_SECTIONNAME = "�S�Ћ���";

        //-----ADD 2010/08/10----------->>>>>
        private const string ctGUIDE_NAME_SectionGuide = "SectionGuide";
        private const string ctGUIDE_NAME_RateSettingDivideGuide = "RateSettingDivideGuide";
        private const string ctGUIDE_NAME_CustomerGuide = "CustomerGuide";
        private const string ctGUIDE_NAME_CustRateGrpGuide = "CustRateGrpGuide";
        private const string ctGUIDE_NAME_SupplierGuide = "SupplierGuide";
        private const string ctGUIDE_NAME_MakerGuide = "MakerGuide";
        private const string ctGUIDE_NAME_GoodsRateGrpGuide = "GoodsRateGrpGuide";
        private const string ctGUIDE_NAME_BLGroupGuide = "BLGroupGuide";
        private const string ctGUIDE_NAME_BLGoodsGuide = "BLGoodsGuide";
        //-----ADD 2010/08/10-----------<<<<<
        #endregion Constants

        #region Private Members

        private string _enterpriseCode = "";                // ��ƃR�[�h
        private List<Rate> _rateListClone;                  // �|���}�X�^���X�g
        // --- DEL 2009/01/13 --------------------------------------------------------------------->>>>>
        //private SortedList _custRateGrpList = null;		    // ���Ӑ�|���O���[�v
        // --- DEL 2009/01/13 ---------------------------------------------------------------------<<<<<
        private bool _cusotmerGuideSelected;                // ���Ӑ�K�C�h�I���t���O

        // �A�N�Z�X�N���X
        private RateAcs _rateAcs = null;					// �|���A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs = null;			// ���[�U�[�K�C�h�A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs = null;        // ���_�A�N�Z�X�N���X
        private RateProtyMngAcs _rateProtyMngAcs = null;	// �|���D��Ǘ��A�N�Z�X�N���X
        private MakerAcs _makerAcs = null;					// ���[�J�[�A�N�Z�X�N���X
        private BLGoodsCdAcs _blGoodsCdAcs = null;			// BL�A�N�Z�X�N���X
        private BLGroupUAcs _blGroupUAcs = null;            // BL�O���[�v�A�N�Z�X�N���X
        private GoodsGroupUAcs _goodsGroupUAcs = null;      // ���i�|���f�A�N�Z�X�N���X
        private SecInfoAcs _secInfoAcs = null;              // ���_���A�N�Z�X�N���X
        private CustomerSearchAcs _customerSearchAcs = null;    
        private SupplierAcs _supplierAcs = null;            // �d����A�N�Z�X�N���X
        private GoodsAcs _goodsAcs = null;                  // ���i�A�N�Z�X�N���X

        // �O��l�ێ��p�ϐ�
        private string _prevSectionCode;
        private string _prevUnitPriceKind;
        private string _prevRateSettingDivide;
        private int _prevUnitPriceKindWay;
        private int _prevCustomerCode;
        private int _prevSupplierCode;
        private int _prevMakerCode;
        private int _prevGoodsRateGrpCode;
        private int _prevBLGroupCode;
        private int _prevBLGoodsCode;
        private int _prevColumnIndex;
        private string _prevGoodsNo; // ADD 2009/03/23
        private int _prevCustRateGrpCode; // ADD 2009/12/15
        private string _prevGoodsRateRank; // ADD 2009/12/15

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, Supplier> _supplierDic;
        private Dictionary<int, MakerUMnt> _makerUMntDic;
        private Dictionary<int, GoodsGroupU> _goodsGroupUDic;
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;
        private Dictionary<int, BLGroupU> _blGroupUDic;
        private Dictionary<string, GoodsUnitData> _goodsUnitDataDic;
        private Dictionary<int, CustomerSearchRet> _customerSearchRetDic;
        // --- ADD 2009/01/13 --------------------------------------------------------------------->>>>>
        private Dictionary<int, string> _custRateGrpDic;
        // --- ADD 2009/01/13 ---------------------------------------------------------------------<<<<<
        
        private bool _firstFlg;

        private bool _isClose;
        private bool _isNew;
        private bool _isSave;
        private bool _isDelete;
        private bool _isRenewal;
        public UltraGrid Detail_uGrid;
        private UltraLabel ultraLabel17;
        private UltraButton CustRateGrpGuide_Button;
        private TEdit tEdit_CustRateGrpName;
        private TNedit tNedit_CustRateGrpCodeZero;
        private bool _isRevival;

        //-----ADD 2010/08/10----------->>>>>
        private bool _isGuide;
        private object _prevUnitPriceKindWayObj;
        private object _prevUnitPriceKindObj;
        //-----ADD 2010/08/10-----------<<<<<
        //-----ADD caohh 2011/08/05 ----------->>>>>
        // ���[�U�[�ݒ���
        private PMKHN09302UB _pMKHN09302UB;
        // �|���}�X�^��ʗp���[�U�[�ݒ�N���X
        private RateInputConstructionAcs _rateInputConstructionAcs;
        // ADD �� 2014/03/20 ----------------------->>>>>
        private UltraLabel ultraLabel18;
        private TDateEdit UpdateDateTime_tDateEdit;
        // ADD �� 2014/03/20 -----------------------<<<<<<
        private bool _isSetUp;
        //-----ADD caohh 2011/08/05 -----------<<<<<
        #endregion Private Members

        #region Constructor
        /// <summary>
        /// �|���}�X�^�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// <br>Update Note: 2010/08/10 �k���r PM1012�Ή�</br>
        /// <br>              �K�C�h���u�e�T�v�{�^���ŕ\������悤�ɕύX</br>
        /// <br>Update Note : 2011/08/05 caohh</br>
        /// <br>              NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
        /// </remarks>
		public PMKHN09302UA()
		{
			InitializeComponent();

            this._isClose = true;
            this._isNew = true;
            this._isSave = true;
            this._isDelete = false;
            this._isRevival = false;
            this._isRenewal = true;
            //-----ADD 2010/08/10----------->>>>>
            this._isGuide = true;
            //-----ADD 2010/08/10-----------<<<<<
            this._isSetUp = true; // ADD caohh 2011/08/05
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._rateAcs = new RateAcs();
            this._userGuideAcs = new UserGuideAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._rateProtyMngAcs = new RateProtyMngAcs();
            this._makerAcs = new MakerAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._blGroupUAcs = new BLGroupUAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            this._secInfoAcs = new SecInfoAcs();
            this._customerSearchAcs = new CustomerSearchAcs();
            this._supplierAcs = new SupplierAcs();
            this._goodsAcs = new GoodsAcs();

            this._rateListClone = new List<Rate>();

            this._goodsUnitDataDic = new Dictionary<string, GoodsUnitData>();

            //-----ADD 2010/08/10----------->>>>>
            this._guideEnableControlDictionary.Add(this.tEdit_SectionCodeAllowZero.Name, ctGUIDE_NAME_SectionGuide);       		//���_
            this._guideEnableControlDictionary.Add(this.RateSettingDivide_tEdit.Name, ctGUIDE_NAME_RateSettingDivideGuide);		//�|���ݒ�敪
            this._guideEnableControlDictionary.Add(this.tNedit_CustomerCode.Name, ctGUIDE_NAME_CustomerGuide);             		//���Ӑ�R�[�h
            this._guideEnableControlDictionary.Add(this.tNedit_CustRateGrpCodeZero.Name, ctGUIDE_NAME_CustRateGrpGuide);   		//���Ӑ�|���O���[�v
            this._guideEnableControlDictionary.Add(this.tNedit_SupplierCd.Name, ctGUIDE_NAME_SupplierGuide);               		//�d����R�[�h
            this._guideEnableControlDictionary.Add(this.tNedit_GoodsMakerCd.Name, ctGUIDE_NAME_MakerGuide);                		//���[�J�[
            this._guideEnableControlDictionary.Add(this.tNedit_GoodsMGroup.Name, ctGUIDE_NAME_GoodsRateGrpGuide);          		//���i�|���f
            this._guideEnableControlDictionary.Add(this.tNedit_BLGloupCode.Name, ctGUIDE_NAME_BLGroupGuide);               		//�O���[�v�R�[�h
            this._guideEnableControlDictionary.Add(this.tNedit_BLGoodsCode.Name, ctGUIDE_NAME_BLGoodsGuide);               		//�a�k�R�[�h
            //-----ADD 2010/08/10-----------<<<<<

            // �e��}�X�^�Ǎ�
            LoadSecInfoSet();
            LoadSupplier();
            LoadMakerUMnt();
            LoadGoodsGroupU();
            LoadBLGoodsCdUMnt();
            LoadBLGroupU();
            LoadCustomerSearchRet();
            // --- ADD 2009/01/13 --------------------------------------------------------------------->>>>>
            GetCustRateGrp();
            // --- ADD 2009/01/13 ---------------------------------------------------------------------<<<<<

            //-----ADD caohh 2011/08/05 ----------->>>>>
            // ���[�U�[�ݒ���
            this._pMKHN09302UB = new PMKHN09302UB();
            this._rateInputConstructionAcs = new RateInputConstructionAcs();
            //-----ADD caohh 2011/08/05 -----------<<<<<

            // ��ʏ�����
            ScreenInitialSetting();

            // �O���b�h������
            ClearGrid("");
		}
		#endregion

        #region IRateMDIChild �����o

        /// <summary>
        /// �I���O����
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public int BeforeClose(object parameter)
        {
            // �ύX�_�`�F�b�N
            if (!CompareInputScreen())
            {
                //��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                  "",
                                                  0,
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxDefaultButton.Button1);
                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            // �ۑ�����
                            if (!SaveProc())
                            {
                                return (-1);
                            }
                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    default:
                        {
                            return (-1);
                        }
                }
            }

            return 0;
        }

        /// <summary>
        /// �폜����
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public int Delete(object parameter)
        {
            bool bStatus;

            if (this.Mode_Label.Text == DELETE_MODE)
            {
                // �����폜����
                bStatus = DeleteProc();
            }
            else
            {
                // �_���폜����
                bStatus = LogicalDeleteProc();
            }

            return 0;
        }

        /// <summary>
        /// �V�K����
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public int New(object parameter)
        {
            // �ύX�_�`�F�b�N
            if (!CompareInputScreen())
            {
                //��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                  "",
                                                  0,
                                                  MessageBoxButtons.YesNoCancel,
                                                  MessageBoxDefaultButton.Button1);

                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            if (!SaveProc())
                            {
                                return (-1);
                            }
                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    default:
                        {
                            return (-1);
                        }
                }
            }

            // �V�K�쐬����
            NewProc();

            return 0;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public int Revival(object parameter)
        {
            // ��������
            RevivalProc();

            return 0;
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public int Save(object parameter)
        {
            // �ꎞ�I�Ƀt�H�[�J�X���ړ����܂�
            this.SectionCode_uLabel.Focus();

            // �ۑ�����
            SaveProc();

            return 0;
        }

        /// <summary>
        /// �ŐV���擾����
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public int Renewal(object parameter)
        {
            // �e��}�X�^�Ǎ�
            LoadSecInfoSet();
            LoadSupplier();
            LoadMakerUMnt();
            LoadGoodsGroupU();
            LoadBLGoodsCdUMnt();
            LoadBLGroupU();
            LoadCustomerSearchRet();
            GetCustRateGrp();

            ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                           "�ŐV�����擾���܂����B",
                           0,
                           MessageBoxButtons.OK,
                           MessageBoxDefaultButton.Button1);

            return 0;
        }

        //-----ADD 2010/08/10---------->>>>>
        /// <summary>
        /// �K�C�h�擾����
        /// </summary>
        /// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>Note       : �K�C�h���擾����</br>
        /// <br>Programer  : �k���r</br>
        /// <br>Date       : 2010/08/10</br>
        /// </remarks>
        public int Guide(object parameter)
        {
            // �K�C�h�N������
            this.ExecuteGuide();
            return 0;
        }
        //-----ADD 2010/08/10----------<<<<<

        //-----ADD caohh 2011/08/05 ---------->>>>>
        /// <summary>
        /// ���[�U�[�ݒ�擾����
        /// </summary>
        /// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
        /// <param return="int">0��OK, 0��NG</param>
        /// <remarks>
        /// <br>NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
        /// <br>Note       : �K�C�h���擾����</br>
        /// <br>Programer  : caohh</br>
        /// <br>Date       : 2011/08/05</br>
        /// </remarks>
        public int SetUp(object parameter)
        {
            // ���[�U�[�ݒ�N������
            this.ExecuteSetUp();
            return 0;
        }
        //-----ADD caohh 2011/08/05 ----------<<<<<

        public event ParentToolbarRateSettingEventHandler ParentToolbarRateSettingEvent;

        /// <summary> �I���{�^��Enabled�v���p�e�B </summary>
        public bool IsClose
        {
            get { return this._isClose; }
        }

        /// <summary> �V�K�{�^��Enabled�v���p�e�B </summary>
        public bool IsNew
        {
            get { return this._isNew; }
        }

        /// <summary> �ۑ��{�^��Enabled�v���p�e�B </summary>
        public bool IsSave
        {
            get { return this._isSave; }
        }

        //-----ADD 2010/08/10----------->>>>>
        /// <summary> �K�C�h�{�^��Enabled�v���p�e�B </summary>
        public bool IsGuide
        {
            get { return this._isGuide; }
        }
        //-----ADD 2010/08/10-----------<<<<<

        //-----ADD caohh 2011/08/05----------->>>>>
        /// <summary> �ݒ�{�^��Enabled�v���p�e�B </summary>
        public bool IsSetUp
        {
            get { return this._isSetUp; }
        }
        //-----ADD caohh 2011/08/05-----------<<<<<

        /// <summary> �폜�{�^��Enabled�v���p�e�B </summary>
        public bool IsDelete
        {
            get { return this._isDelete; }
        }

        /// <summary> �����{�^��Enabled�v���p�e�B </summary>
        public bool IsRevival
        {
            get { return this._isRevival; }
        }

        /// <summary> �ŐV���{�^��Enabled�v���p�e�B </summary>
        public bool IsRenewal
        {
            get { return this._isRenewal; }
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// ���_���}�X�^�Ǎ�����
        /// </summary>
        private void LoadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            this._secInfoAcs.ResetSectionInfo();

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0)
                    {
                        this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                    }
                }
            }
            catch
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            }
        }

        /// <summary>
        /// �d����}�X�^�Ǎ�����
        /// </summary>
        private void LoadSupplier()
        {
            this._supplierDic = new Dictionary<int, Supplier>();

            try
            {
                ArrayList retList;

                int status = this._supplierAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Supplier supplier in retList)
                    {
                        if (supplier.LogicalDeleteCode == 0)
                        {
                            this._supplierDic.Add(supplier.SupplierCd, supplier);
                        }
                    }
                }
            }
            catch
            {
                this._supplierDic = new Dictionary<int, Supplier>();
            }
        }

        /// <summary>
        /// ���[�J�[�}�X�^�Ǎ�����
        /// </summary>
        private void LoadMakerUMnt()
        {
            this._makerUMntDic = new Dictionary<int, MakerUMnt>();

            try
            {
                ArrayList retList;

                int status = this._makerAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (MakerUMnt makerUMnt in retList)
                    {
                        if (makerUMnt.LogicalDeleteCode == 0)
                        {
                            this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._makerUMntDic = new Dictionary<int, MakerUMnt>();
            }
        }

        /// <summary>
        /// ���i�|���f�}�X�^�Ǎ�����
        /// </summary>
        private void LoadGoodsGroupU()
        {
            this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();

            try
            {
                ArrayList retList;

                int status = this._goodsGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (GoodsGroupU goodsGroupU in retList)
                    {
                        if (goodsGroupU.LogicalDeleteCode == 0)
                        {
                            this._goodsGroupUDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                        }
                    }
                }
            }
            catch
            {
                this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();
            }
        }

        /// <summary>
        /// BL�R�[�h�}�X�^�Ǎ�����
        /// </summary>
        private void LoadBLGoodsCdUMnt()
        {
            this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();

            try
            {
                ArrayList retList;

                int status = this._blGoodsCdAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGoodsCdUMnt blGoodsCdUMnt in retList)
                    {
                        if (blGoodsCdUMnt.LogicalDeleteCode == 0)
                        {
                            this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
                        }
                    }
                }
            }
            catch
            {
                this._blGoodsCdUMntDic = new Dictionary<int, BLGoodsCdUMnt>();
            }
        }

        /// <summary>
        /// �O���[�v�R�[�h�}�X�^�Ǎ�����
        /// </summary>
        private void LoadBLGroupU()
        {
            this._blGroupUDic = new Dictionary<int, BLGroupU>();

            try
            {
                ArrayList retList;

                int status = this._blGroupUAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGroupU blGroupU in retList)
                    {
                        if (blGroupU.LogicalDeleteCode == 0)
                        {
                            this._blGroupUDic.Add(blGroupU.BLGroupCode, blGroupU);
                        }
                    }
                }
            }
            catch
            {
                this._blGroupUDic = new Dictionary<int, BLGroupU>();
            }
        }

        /// <summary>
        /// ���Ӑ挟���}�X�^�Ǎ�����
        /// </summary>
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

        /// <summary>
        /// �A�C�R���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�ƃ{�^���̃A�C�R����ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void SetIcon()
        {
            ImageList imageList16 = IconResourceManagement.ImageList16;

            // -----------------------------
            // �{�^���A�C�R���ݒ�
            // -----------------------------
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.RateSettingDivideGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.CustomerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            // --- ADD 2009/01/13 --------------------------------------------------------------------->>>>>
            this.CustRateGrpGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            // --- ADD 2009/01/13 ---------------------------------------------------------------------<<<<<
            this.SupplierGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.MakerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.GoodsRateGrpGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGroupGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.BLGoodsGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
        }

        /// <summary>
        /// �R���g���[���T�C�Y�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���g���[���T�C�Y��ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void SetControlSize()
        {
            this.tEdit_SectionCodeAllowZero.Size = new Size(28, 24);
            this.SectionCodeNm_tEdit.Size = new Size(113, 24);
            this.RateSettingDivide_tEdit.Size = new Size(28, 24);
            this.RateMngGoodsCd_tEdit.Size = new Size(20, 24);
            this.RateMngGoodsNm_tEdit.Size = new Size(516, 24);
            this.RateMngCustCd_tEdit.Size = new Size(20, 24);
            this.RateMngCustNm_tEdit.Size = new Size(516, 24);
            this.tNedit_RatePriorityOrder.Size = new Size(43, 24);
            this.tNedit_CustomerCode.Size = new Size(82, 24);
            this.CustomerCodeNm_tEdit.Size = new Size(206, 24);
            // --- ADD 2009/01/13 --------------------------------------------------------------------->>>>>
            this.tNedit_CustRateGrpCodeZero.Size = new Size(82, 24);
            this.tEdit_CustRateGrpName.Size = new Size(206, 24);
            // --- ADD 2009/01/13 ---------------------------------------------------------------------<<<<<
            this.tNedit_SupplierCd.Size = new Size(82, 24);
            this.SupplierCdNm_tEdit.Size = new Size(206, 24);
            this.tNedit_GoodsMakerCd.Size = new Size(59, 24);
            this.MakerName_tEdit.Size = new Size(222, 24);
            this.GoodsRateRank_tEdit.Size = new Size(28, 24);
            this.tNedit_GoodsMGroup.Size = new Size(59, 24);
            this.GoodsRateGrpName_tEdit.Size = new Size(222, 24);
            this.tNedit_BLGloupCode.Size = new Size(59, 24);
            this.BLGroupName_tEdit.Size = new Size(222, 24);
            this.tNedit_BLGoodsCode.Size = new Size(59, 24);
            this.BLGoodsName_tEdit.Size = new Size(222, 24);
            this.tEdit_GoodsNo.Size = new Size(315, 24);
            this.tEdit_GoodsName.Size = new Size(315, 24);
        }

        #region ��ʃN���A����

        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ����N���A���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.Mode_Label.Text = INSERT_MODE;
            // ADD �� 2014/03/20 ----------------------->>>>>
            this.UpdateDateTime_tDateEdit.Clear();
            // ADD �� 2014/03/20 -----------------------<<<<<

            // ��������(�|���ݒ�)�N���A
            ClearRateCondition();

            // ��������(�����ݒ�)�N���A
            ClearCustomerCondition();

            // ��������(���i�ݒ�)�N���A
            ClearGoodsCondition();
        }

        /// <summary>
        /// ��������(�|���ݒ�)�N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ����N���A���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void ClearRateCondition()
        {
            this.tEdit_SectionCodeAllowZero.Clear();
            this.SectionCodeNm_tEdit.Clear();
            this.UnitPriceKind_tComboEditor.Value = "1";
            this.UnitPriceKindWay_tComboEditor.Value = 1;
            this.RateSettingDivide_tEdit.Clear();
            this.RateMngGoodsCd_tEdit.Clear();
            this.RateMngGoodsNm_tEdit.Clear();
            this.RateMngCustCd_tEdit.Clear();
            this.RateMngCustNm_tEdit.Clear();
            this.tNedit_RatePriorityOrder.Clear();

            this._prevSectionCode = "";
            this._prevUnitPriceKind = "";
            this._prevUnitPriceKindWay = -1;
            this._prevRateSettingDivide = "";
        }

        /// <summary>
        /// ��������(���i�ݒ�)�N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ����N���A���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void ClearGoodsCondition()
        {
            this.tNedit_GoodsMakerCd.Clear();
            this.MakerName_tEdit.Clear();
            this.GoodsRateRank_tEdit.Clear();
            this.tNedit_GoodsMGroup.Clear();
            this.GoodsRateGrpName_tEdit.Clear();
            this.tNedit_BLGloupCode.Clear();
            this.BLGroupName_tEdit.Clear();
            this.tNedit_BLGoodsCode.Clear();
            this.BLGoodsName_tEdit.Clear();
            this.tEdit_GoodsNo.Clear();
            this.tEdit_GoodsName.Clear();
            this.tNedit_Price.Clear();

            this._prevMakerCode = -1;
            this._prevGoodsRateGrpCode = -1;
            this._prevBLGroupCode = -1;
            this._prevBLGoodsCode = -1;
            this._prevGoodsNo = string.Empty; // ADD 2009/03/23
            this._prevGoodsRateRank = string.Empty;// ADD 2009/12/15
        }

        /// <summary>
        /// ��������(�����ݒ�)�N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ����N���A���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void ClearCustomerCondition()
        {
            this.tNedit_CustomerCode.Clear();
            this.CustomerCodeNm_tEdit.Clear();
            // --- CHG 2009/01/13 --------------------------------------------------------------------->>>>>
            //this.CustRateGrpCode_tComboEditor.Value = 0;
            this.tNedit_CustRateGrpCodeZero.Clear();
            this.tEdit_CustRateGrpName.Clear();
            // --- CHG 2009/01/13 ---------------------------------------------------------------------<<<<<
            this.tNedit_SupplierCd.Clear();
            this.SupplierCdNm_tEdit.Clear();
            // ADD �� 2014/03/20 -------------------------->>>>>
            this.Mode_Label.Text = INSERT_MODE;
            this.UpdateDateTime_tDateEdit.Clear();
            // ADD �� 2014/03/20 --------------------------<<<<<

            this._prevCustomerCode = -1;
            this._prevSupplierCode = -1;
            this._prevCustRateGrpCode = -1;// ADD 2009/12/15
        }

        /// <summary>
        /// �O���b�h�����ݒ菈��
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// <br>Update Note: 2010/08/10 �k���r PM1012�Ή�</br>
        /// <br>             ���X�g���ڂ��R�[�h����ł����͉\�֕ύX</br>
        /// </remarks>
        private void ClearGrid(string unitPriceKind)
        {
            // --------------------------------------
            // �f�[�^�e�[�u���쐬
            // --------------------------------------
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add(COLUMNKEY_1, typeof(string));
            dataTable.Columns.Add(COLUMNKEY_2, typeof(string));
            dataTable.Columns.Add(COLUMNKEY_3, typeof(string));
            dataTable.Columns.Add(COLUMNKEY_4, typeof(string));
            dataTable.Columns.Add(COLUMNKEY_5, typeof(string));
            dataTable.Columns.Add(COLUMNKEY_6, typeof(string));
            dataTable.Columns.Add(COLUMNKEY_7, typeof(string));
            dataTable.Columns.Add(COLUMNKEY_8, typeof(string));
            dataTable.Columns.Add(COLUMNKEY_9, typeof(string));
            dataTable.Columns.Add(COLUMNKEY_10, typeof(string));

            DataRow dataRow;

            for (int rowIndex = 0; rowIndex < ROW_COUNT; rowIndex++)
            {
                dataRow = dataTable.NewRow();

                switch (unitPriceKind)
                {
                    // �����ݒ�
                    case "1":
                        // ����(�ȏ�)
                        if (rowIndex == ROWINDEX_LOTCOUNTABOVE)
                        {
                            for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
                            {
                                string keyName = "LotCount" + (columnIndex + 1).ToString();
                                if (columnIndex == 0)
                                {
                                    dataRow[keyName] = LOTCOUNT_MIN;
                                }
                                else
                                {
                                    dataRow[keyName] = LOTCOUNT_MAX;
                                }
                            }
                        }
                        // ����(�ȉ�)
                        else if (rowIndex == ROWINDEX_LOTCOUNTBELOW)
                        {
                            for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
                            {
                                string keyName = "LotCount" + (columnIndex + 1).ToString();
                                dataRow[keyName] = LOTCOUNT_MAX;
                            }
                        }
                        //// �[�������P��
                        //else if (rowIndex == ROWINDEX_UNPRCFRACPROCUNIT)
                        //{
                        //    string keyName = "LotCount1";
                        //    dataRow[keyName] = "1.00";
                        //}
                        //// �[�������敪
                        //else if (rowIndex == ROWINDEX_UNPRCFRACPROCDIV)
                        //{
                        //    string keyName = "LotCount1";
                        //    //dataRow[keyName] = 1;         //DEL 2008/10/16 �����l���l�̌ܓ��Ƃ����
                        //    dataRow[keyName] = 2;           //ADD 2008/10/16
                        //}
                        else
                        {
                            for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
                            {
                                string keyName = "LotCount" + (columnIndex + 1).ToString();
                                dataRow[keyName] = "";
                            }
                        }
                        break;
                    // �����ݒ�A���i�ݒ�
                    case "2":
                    case "3":
                        // ����(�ȏ�)
                        if (rowIndex == ROWINDEX_LOTCOUNTABOVE)
                        {
                            for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
                            {
                                string keyName = "LotCount" + (columnIndex + 1).ToString();
                                if (columnIndex == 0)
                                {
                                    dataRow[keyName] = LOTCOUNT_MIN;
                                }
                                else
                                {
                                    dataRow[keyName] = "";
                                }
                            }
                        }
                        // ����(�ȉ�)
                        else if (rowIndex == ROWINDEX_LOTCOUNTBELOW)
                        {
                            for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
                            {
                                string keyName = "LotCount" + (columnIndex + 1).ToString();
                                if (columnIndex == 0)
                                {
                                    dataRow[keyName] = LOTCOUNT_MAX;
                                }
                                else
                                {
                                    dataRow[keyName] = "";
                                }
                            }
                        }
                        // �[�������P��
                        else if (rowIndex == ROWINDEX_UNPRCFRACPROCUNIT)
                        {
                            if (unitPriceKind == "3")
                            {
                                string keyName = "LotCount1";
                                dataRow[keyName] = "1.00";
                            }
                        }
                        // �[�������敪
                        else if (rowIndex == ROWINDEX_UNPRCFRACPROCDIV)
                        {
                            if (unitPriceKind == "3")
                            {
                                string keyName = "LotCount1";
                                //dataRow[keyName] = 1;         //DEL 2008/10/16 �����l���l�̌ܓ��Ƃ����
                                dataRow[keyName] = 2;           //ADD 2008/10/16
                            }
                        }
                        else
                        {
                            for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
                            {
                                string keyName = "LotCount" + (columnIndex + 1).ToString();
                                dataRow[keyName] = "";
                            }
                        }
                        break;
                    default:
                        for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
                        {
                            string keyName = "LotCount" + (columnIndex + 1).ToString();
                            dataRow[keyName] = "";
                        }
                        break;
                }

                dataTable.Rows.Add(dataRow);
            }

            this.Detail_uGrid.DataSource = dataTable;

            // --------------------------------------
            // �O���b�h���C�A�E�g�ݒ�
            // --------------------------------------
            ValueList valueList = new ValueList();
            valueList.ValueListItems.Add(1, UNPRCFRACPROCDIV_1);
            valueList.ValueListItems.Add(2, UNPRCFRACPROCDIV_2);
            valueList.ValueListItems.Add(3, UNPRCFRACPROCDIV_3);
            valueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

            for (int index = 0; index < COLUMN_COUNT; index++)
            {
                // �񕝐ݒ�
                this.Detail_uGrid.DisplayLayout.Bands[0].Columns[index].Width = 110;

                // �w�b�_�[�L���v�V�����ݒ�
                this.Detail_uGrid.DisplayLayout.Bands[0].Columns[index].Header.Caption = "���ʔ͈�" + (index + 1).ToString();
                this.Detail_uGrid.DisplayLayout.Bands[0].Columns[index].Header.Appearance.TextHAlign = HAlign.Center;
                this.Detail_uGrid.DisplayLayout.Bands[0].Columns[index].Header.Appearance.TextVAlign = VAlign.Middle;
                this.Detail_uGrid.DisplayLayout.Bands[0].Columns[index].Header.Appearance.ForeColorDisabled = Color.White;

                // �e�L�X�g�E��
                this.Detail_uGrid.DisplayLayout.Bands[0].Columns[index].CellAppearance.TextHAlign = HAlign.Right;
                this.Detail_uGrid.DisplayLayout.Bands[0].Columns[index].CellAppearance.TextVAlign = VAlign.Middle;
                this.Detail_uGrid.DisplayLayout.Bands[0].Columns[index].CellAppearance.ForeColorDisabled = Color.Black;

                // �[�������敪�ݒ�
                // --- ADD 2010/08/10----------------------------------->>>>>
                //this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[index].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[index].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDown;
                // --- ADD 2010/08/10-----------------------------------<<<<<
                this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[index].ValueList = valueList;
            }

            // �P���[�������敪����
            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].CellAppearance.TextHAlign = HAlign.Left;

            // �X�N���[���o�[�̈ʒu��������
            this.Detail_uGrid.DisplayLayout.ColScrollRegions.Clear();

            this.Detail_uGrid.Enabled = false;

            this._prevColumnIndex = -1;
        }

        #endregion ��ʃN���A����

        /// <summary>
        /// ��ʏ�񏉊��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ��̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// <br>Update Note: 2010/08/10 �k���r PM1012�Ή�</br>
        /// <br>             ���X�g���ڂ��R�[�h����ł����͉\�֕ύX</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // �P�����
            this.UnitPriceKind_tComboEditor.Items.Clear();
            this.UnitPriceKind_tComboEditor.Items.Add("1", UNITPRICEKIND_1);
            this.UnitPriceKind_tComboEditor.Items.Add("2", UNITPRICEKIND_2);
            this.UnitPriceKind_tComboEditor.Items.Add("3", UNITPRICEKIND_3);

            // �ݒ���@
            this.UnitPriceKindWay_tComboEditor.Items.Clear();
            this.UnitPriceKindWay_tComboEditor.Items.Add(1, UNITPRICEKINDWAY_1);
            this.UnitPriceKindWay_tComboEditor.Items.Add(0, UNITPRICEKINDWAY_0);

            // --- DEL 2009/01/13 --------------------------------------------------------------------->>>>>
            //// ���Ӑ�|���O���[�v
            //GetCustRateGrp();
            //this.CustRateGrpCode_tComboEditor.Items.Clear();
            //foreach (DictionaryEntry dic in this._custRateGrpList)
            //{
            //    this.CustRateGrpCode_tComboEditor.Items.Add((int)dic.Key, (string)dic.Value);
            //}
            // --- DEL 2009/01/13 ---------------------------------------------------------------------<<<<<
        }

        /// <summary>
        /// �t�H�[�J�X�ݒ菈��
        /// </summary>
        /// <param name="prevButton">�����K�C�h�{�^��</param>
        /// <remarks>
        /// <br>Note       : �K�C�h�{�^��������̃t�H�[�J�X�ݒ���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// <br>Update Note: 2010/08/10 �k���r PM1012�Ή�</br>
        /// <br>             �K�C�h���u�e�T�v�{�^���ŕ\������悤�ɕύX</br>
        /// </remarks>
        private void SetFocus(UltraButton prevButton)
        {
            try
            {
                // ���_�K�C�h�{�^��
                if (prevButton.Name == "SectionGuide_Button")
                {
                    // �P����ނɃt�H�[�J�X�ݒ�
                    this.UnitPriceKind_tComboEditor.Focus();
                    //-----ADD 2010/08/10---------->>>>>
                    SettingGuideButtonToolEnabled(UnitPriceKind_tComboEditor);
                    //-----ADD 2010/08/10----------<<<<<
                    return;
                }

                // �|���ݒ�敪
                string rateSettingDivide = this.RateSettingDivide_tEdit.DataText.Trim();

                switch (prevButton.Name)
                {
                    // �|���ݒ�敪�K�C�h�{�^��
                    case "RateSettingDivideGuide_Button":
                        if (RateAcs.IsCustomerSetting(rateSettingDivide))
                        {
                            // ���Ӑ�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_CustomerCode.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_CustomerCode);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsCustRateGrpSetting(rateSettingDivide))
                        {
                            // ���Ӑ�|���O���[�v�Ƀt�H�[�J�X�ݒ�
                            // --- CHG 2009/01/13 --------------------------------------------------------------------->>>>>
                            //this.CustRateGrpCode_tComboEditor.Focus();
                            this.tNedit_CustRateGrpCodeZero.Focus();
                            // --- CHG 2009/01/13 ---------------------------------------------------------------------<<<<<
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_CustRateGrpCodeZero);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsSupplierSetting(rateSettingDivide))
                        {
                            // �d����R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_SupplierCd.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_SupplierCd);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsMakerSetting(rateSettingDivide))
                        {
                            // ���[�J�[�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_GoodsMakerCd.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_GoodsMakerCd);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                        {
                            // �w�ʂɃt�H�[�J�X�ݒ�
                            this.GoodsRateRank_tEdit.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(GoodsRateRank_tEdit);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                        {
                            // ���i�|���f�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_GoodsMGroup.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_GoodsMGroup);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                        {
                            // BL�O���[�v�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_BLGloupCode.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_BLGloupCode);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                        {
                            // BL�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_BLGoodsCode.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_BLGoodsCode);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                        {
                            // �i�ԃR�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tEdit_GoodsNo.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else
                        {
                            // �O���b�h�Ƀt�H�[�J�X�ݒ�
                            //this.Detail_uGrid.Focus();  // DEL 2008/10/29 �s��Ή�[7174]
                            SetNextFocus(0);    // ADD 2008/10/29 �s��Ή�[7174]
                        }
                        return;
                    // ���Ӑ�K�C�h�{�^��
                    case "CustomerGuide_Button":
                        if (RateAcs.IsCustRateGrpSetting(rateSettingDivide))
                        {
                            // ���Ӑ�|���O���[�v�Ƀt�H�[�J�X�ݒ�
                            // --- CHG 2009/01/13 --------------------------------------------------------------------->>>>>
                            //this.CustRateGrpCode_tComboEditor.Focus();
                            this.tNedit_CustRateGrpCodeZero.Focus();
                            // --- CHG 2009/01/13 ---------------------------------------------------------------------<<<<<
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_CustRateGrpCodeZero);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsSupplierSetting(rateSettingDivide))
                        {
                            // �d����R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_SupplierCd.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_SupplierCd);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsMakerSetting(rateSettingDivide))
                        {
                            // ���[�J�[�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_GoodsMakerCd.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_GoodsMakerCd);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                        {
                            // �w�ʂɃt�H�[�J�X�ݒ�
                            this.GoodsRateRank_tEdit.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(GoodsRateRank_tEdit);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                        {
                            // ���i�|���f�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_GoodsMGroup.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_GoodsMGroup);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                        {
                            // BL�O���[�v�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_BLGloupCode.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_BLGloupCode);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                        {
                            // BL�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_BLGoodsCode.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_BLGoodsCode);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                        {
                            // �i�ԃR�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tEdit_GoodsNo.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else
                        {
                            // �O���b�h�Ƀt�H�[�J�X�ݒ�
                            //this.Detail_uGrid.Focus();  // DEL 2008/10/29 �s��Ή�[7174]
                            SetNextFocus(1);    // ADD 2008/10/29 �s��Ή�[7174]
                        }
                        return;
                    // ���Ӑ�|���O���[�v�K�C�h�{�^��
                    case "CustRateGrpGuide_Button":
                        if (RateAcs.IsSupplierSetting(rateSettingDivide))
                        {
                            // �d����R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_SupplierCd.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_SupplierCd);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsMakerSetting(rateSettingDivide))
                        {
                            // ���[�J�[�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_GoodsMakerCd.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_GoodsMakerCd);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                        {
                            // �w�ʂɃt�H�[�J�X�ݒ�
                            this.GoodsRateRank_tEdit.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(GoodsRateRank_tEdit);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                        {
                            // ���i�|���f�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_GoodsMGroup.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_GoodsMGroup);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                        {
                            // BL�O���[�v�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_BLGloupCode.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_BLGloupCode);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                        {
                            // BL�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_BLGoodsCode.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_BLGoodsCode);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                        {
                            // �i�ԃR�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tEdit_GoodsNo.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else
                        {
                            // �O���b�h�Ƀt�H�[�J�X�ݒ�
                            //this.Detail_uGrid.Focus();  // DEL 2008/10/29 �s��Ή�[7174]
                            SetNextFocus(1);    // ADD 2008/10/29 �s��Ή�[7174]
                        }
                        return;
                    // �d����K�C�h�{�^��
                    case "SupplierGuide_Button":
                        if (RateAcs.IsMakerSetting(rateSettingDivide))
                        {
                            // ���[�J�[�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_GoodsMakerCd.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_GoodsMakerCd);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                        {
                            // �w�ʂɃt�H�[�J�X�ݒ�
                            this.GoodsRateRank_tEdit.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(GoodsRateRank_tEdit);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                        {
                            // ���i�|���f�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_GoodsMGroup.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_GoodsMGroup);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                        {
                            // BL�O���[�v�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_BLGloupCode.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_BLGloupCode);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                        {
                            // BL�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_BLGoodsCode.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_BLGoodsCode);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                        {
                            // �i�ԃR�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tEdit_GoodsNo.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else
                        {
                            // �O���b�h�Ƀt�H�[�J�X�ݒ�
                            //this.Detail_uGrid.Focus();  // DEL 2008/10/29 �s��Ή�[7174]
                            SetNextFocus(2);    // ADD 2008/10/29 �s��Ή�[7174]
                        }
                        return;
                    // ���[�J�[�K�C�h�{�^��
                    case "MakerGuide_Button":
                        if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                        {
                            // �w�ʂɃt�H�[�J�X�ݒ�
                            this.GoodsRateRank_tEdit.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(GoodsRateRank_tEdit);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                        {
                            // ���i�|���f�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_GoodsMGroup.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_GoodsMGroup);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                        {
                            // BL�O���[�v�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_BLGloupCode.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_BLGloupCode);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                        {
                            // BL�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_BLGoodsCode.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_BLGoodsCode);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                        {
                            // �i�ԃR�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tEdit_GoodsNo.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else
                        {
                            // �O���b�h�Ƀt�H�[�J�X�ݒ�
                            //this.Detail_uGrid.Focus();  // DEL 2008/10/29 �s��Ή�[7174]
                            SetNextFocus(3);    // ADD 2008/10/29 �s��Ή�[7174]
                        }
                        return;
                    // ���i�|���f�K�C�h�{�^��
                    case "GoodsRateGrpGuide_Button":
                        if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                        {
                            // BL�O���[�v�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_BLGloupCode.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_BLGloupCode);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                        {
                            // BL�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_BLGoodsCode.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_BLGoodsCode);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                        {
                            // �i�ԃR�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tEdit_GoodsNo.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else
                        {
                            // �O���b�h�Ƀt�H�[�J�X�ݒ�
                            //this.Detail_uGrid.Focus();  // DEL 2008/10/29 �s��Ή�[7174]
                            SetNextFocus(4);            // ADD 2008/10/29 �s��Ή�[7174]
                        }
                        return;
                    // BL�O���[�v�R�[�h�K�C�h�{�^��
                    case "BLGroupGuide_Button":
                        if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                        {
                            // BL�R�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tNedit_BLGoodsCode.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_BLGoodsCode);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                        {
                            // �i�ԃR�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tEdit_GoodsNo.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else
                        {
                            // �O���b�h�Ƀt�H�[�J�X�ݒ�
                            //this.Detail_uGrid.Focus();  // DEL 2008/10/29 �s��Ή�[7174]
                            SetNextFocus(5);        // ADD 2008/10/29 �s��Ή�[7174]
                        }
                        return;
                    // BL�R�[�h�K�C�h�{�^��
                    case "BLGoodsGuide_Button":
                        if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                        {
                            // �i�ԃR�[�h�Ƀt�H�[�J�X�ݒ�
                            this.tEdit_GoodsNo.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        else
                        {
                            // �O���b�h�Ƀt�H�[�J�X�ݒ�
                            //this.Detail_uGrid.Focus();    // DEL 2008/10/29 �s��Ή�[7174]
                            SetNextFocus(6);        // ADD 2008/10/29 �s��Ή�[7174]
                        }
                        break;
                    default:
                        // �O���b�h�Ƀt�H�[�J�X�ݒ�
                        this.Detail_uGrid.Focus();
                        return;
                }
            }
            finally
            {
                SearchAfterLeaveControl();
            }
        }

        #region �}�X�^���擾

        /// <summary>
        /// ���[�U�[�K�C�h�f�[�^�擾����
        /// </summary>
        /// <param name="retList">���[�U�[�K�C�h�{�f�B�f�[�^���X�g</param>
        /// <param name="userGuideDivCd">�K�C�h�敪</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�f�[�^���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
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
        /// ���Ӑ�|���O���[�v���擾����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�|���O���[�v�����擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private int GetCustRateGrp()
        {
            // --- CHG 2009/01/13 --------------------------------------------------------------------->>>>>
            //this._custRateGrpList = new SortedList();
            this._custRateGrpDic = new Dictionary<int, string>();
            // --- CHG 2009/01/13 

            int status;
            ArrayList retList = new ArrayList();

            // ���[�U�[�K�C�h�f�[�^�擾(���Ӑ�|���O���[�v)
            status = GetUserGuideBd(out retList, 43);
            if (status == 0)
            {
                foreach (UserGdBd userGdBd in retList)
                {
                    // --- CHG 2009/01/13 --------------------------------------------------------------------->>>>>
                    //this._custRateGrpList.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                    if (userGdBd.LogicalDeleteCode == 0)
                    {
                        this._custRateGrpDic.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                    }
                    // --- CHG 2009/01/13 
                }
            }

            return status;
        }

        // --- ADD 2009/01/13 --------------------------------------------------------------------->>>>>
        /// ���Ӑ�|���O���[�v���̎擾����
        /// </summary>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <returns>���Ӑ�|���O���[�v����</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�|���O���[�v���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2009/01/13</br>
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
        // --- ADD 2009/01/13 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            // �S�Ђ̏ꍇ
            if ((sectionCode.Trim() == "") ||
                (sectionCode.Trim().PadRight(2, '0') == ALL_SECTIONCODE))
            {
                sectionName = ALL_SECTIONNAME;
                return sectionName;
            }

            try
            {
                if (this._secInfoSetDic.ContainsKey(sectionCode))
                {
                    sectionName = this._secInfoSetDic[sectionCode].SectionGuideNm.Trim();
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        /// <summary>
        /// �|���D��Ǘ��}�X�^�擾����
        /// </summary>
        /// <param name="rateProtyMng">�|���D��Ǘ��}�X�^�I�u�W�F�N�g</param>
        /// <param name="RateSettingDivCode">�|���ݒ�敪</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���D��Ǘ��}�X�^���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// <br>Update Note: 2010/08/10 �k���r PM1012�Ή�</br>
        /// <br>             ���X�g���ڂ��R�[�h����ł����͉\�֕ύX</br>
        /// </remarks>
        private int GetRateProtyMng(out RateProtyMng rateProtyMng, string RateSettingDivCode)
        {
            int status = -1;
            rateProtyMng = new RateProtyMng();

            // ���_�R�[�h
            if (this.tEdit_SectionCodeAllowZero.DataText == "")
            {
                return status;
            }
            string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();

            // �P�����
            if (this.UnitPriceKind_tComboEditor.Value == null)
            {
                return status;
            }
            //-----UPD 2010/08/10---------->>>>>
            //int unitPriceKindCode = int.Parse((string)this.UnitPriceKind_tComboEditor.Value);
            int unitPriceKindCode = -1;
            if (!this.setTComboEditorByName("UnitPriceKind_tComboEditor"))
            {
                unitPriceKindCode = int.Parse((string)this.UnitPriceKind_tComboEditor.Value);
            }
            else
            {
                return status;
            }
            //-----UPD 2010/08/10----------<<<<<   

            // �ݒ���@
            if (this.UnitPriceKindWay_tComboEditor.Value == null)
            {
                return status;
            }

            //-----UPD 2010/08/10---------->>>>>
            //int unitPriceKindWayCode = (int)this.UnitPriceKindWay_tComboEditor.Value;
            int unitPriceKindWayCode = -1;
            if (!this.setTComboEditorByNameForWay("UnitPriceKindWay_tComboEditor"))
            {
                if ("2".Equals(this.UnitPriceKindWay_tComboEditor.Text) || UNITPRICEKINDWAY_0.Equals(this.UnitPriceKindWay_tComboEditor.Text))
                {
                    unitPriceKindWayCode = 0;
                }
                else 
                {
                    unitPriceKindWayCode = (int)this.UnitPriceKindWay_tComboEditor.Value;
                }
            }
            else
            {
                return status;
            }
            //-----UPD 2010/08/10----------<<<<<   
            try
            {
                status = this._rateProtyMngAcs.Read(out rateProtyMng, this._enterpriseCode, sectionCode, 
                                                        unitPriceKindCode, unitPriceKindWayCode, RateSettingDivCode, false);
                if (status != 0)
                {
                    rateProtyMng = new RateProtyMng();
                }
            }
            catch
            {
                rateProtyMng = new RateProtyMng();
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ於�̎擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ於��</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ於�̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
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
        /// �d���於�̎擾����
        /// </summary>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <returns>�d���於��</returns>
        /// <remarks>
        /// <br>Note       : �d���於�̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private string GetSupplierName(int supplierCode)
        {
            string supplierName = "";

            try
            {
                if (this._supplierDic.ContainsKey(supplierCode))
                {
                    supplierName = this._supplierDic[supplierCode].SupplierSnm.Trim();
                }
            }
            catch
            {
                supplierName = "";
            }

            return supplierName;
        }

        /// <summary>
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[����</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private string GetMakerName(int makerCode)
        {
            string makerName = "";

            try
            {
                if (this._makerUMntDic.ContainsKey(makerCode))
                {
                    makerName = this._makerUMntDic[makerCode].MakerName.Trim();
                }
            }
            catch
            {
                makerName = "";
            }

            return makerName;
        }

        /// <summary>
        /// ���i�|���f���̎擾����
        /// </summary>
        /// <param name="goodsMGroupCode">���i�|���f�R�[�h</param>
        /// <returns>���i�|���f����</returns>
        /// <remarks>
        /// <br>Note       : ���i�|���f���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private string GetGoodsMGroupName(int goodsMGroupCode)
        {
            string goodsMGroupName = "";

            try
            {
                if (this._goodsGroupUDic.ContainsKey(goodsMGroupCode))
                {
                    goodsMGroupName = this._goodsGroupUDic[goodsMGroupCode].GoodsMGroupName.Trim();
                }
            }
            catch
            {
                goodsMGroupName = "";
            }

            return goodsMGroupName;
        }

        /// <summary>
        /// BL�O���[�v���̎擾����
        /// </summary>
        /// <param name="blGroupCode">BL�O���[�v�R�[�h</param>
        /// <returns>BL�O���[�v����</returns>
        /// <remarks>
        /// <br>Note       : BL�O���[�v���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private string GetBLGroupName(int blGroupCode)
        {
            string blGroupName = "";

            try
            {
                if (this._blGroupUDic.ContainsKey(blGroupCode))
                {
                    blGroupName = this._blGroupUDic[blGroupCode].BLGroupName.Trim();
                }
            }
            catch
            {
                blGroupName = "";
            }

            return blGroupName;
        }

        /// <summary>
        /// BL�R�[�h���̎擾����
        /// </summary>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <returns>BL�R�[�h����</returns>
        /// <remarks>
        /// <br>Note       : BL�R�[�h���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private string GetBLGoodsName(int blGoodsCode)
        {
            string blGoodsName = "";

            try
            {
                if (this._blGoodsCdUMntDic.ContainsKey(blGoodsCode))
                {
                    blGoodsName = this._blGoodsCdUMntDic[blGoodsCode].BLGoodsHalfName.Trim();
                }
            }
            catch
            {
                blGoodsName = "";
            }

            return blGoodsName;
        }

        // --- ADD 2009/03/16 -------------------------------->>>>>
        /// <summary>
        /// ���i���擾����
        /// </summary>
        /// <param name="goodsUnitData">���i�}�X�^</param>
        /// <param name="goodsCode">���i�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private int GetGoodsInfo(out GoodsUnitData goodsUnitData, string goodsCode)
        {
            return GetGoodsInfo(out goodsUnitData, goodsCode, this.tNedit_GoodsMakerCd.GetInt());
        }
        // --- ADD 2009/03/16 --------------------------------<<<<<

        /// <summary>
        /// ���i���擾����
        /// </summary>
        /// <param name="goodsUnitData">���i�}�X�^</param>
        /// <param name="goodsCode">���i�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        //private int GetGoodsInfo(out GoodsUnitData goodsUnitData, string goodsCode) // DEL 2009/03/16
        private int GetGoodsInfo(out GoodsUnitData goodsUnitData, string goodsCode, int goodsMakerCd) // ADD 2009/03/16
        {
            int status = 0;
            string errMsg;
            goodsUnitData = new GoodsUnitData();

            try
            {
                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.SectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();
                //goodsCndtn.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt(); // DEL 2009/03/16
                goodsCndtn.GoodsMakerCd = goodsMakerCd; // ADD 2009/03/16
                goodsCndtn.GoodsNo = goodsCode;
                goodsCndtn.PriceApplyDate = DateTime.Today;

                List<GoodsUnitData> goodsUnitDataList;

                status = this._goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out errMsg);
                if ((status == 0) && (goodsUnitDataList != null))
                {
                    goodsUnitData = goodsUnitDataList[0];
                }
            }
            catch
            {
                goodsUnitData = new GoodsUnitData();
            }

            return (status);
        }

        /// <summary>
        /// ���i���i�擾����
        /// </summary>
        /// <param name="goodsPriceList">���i���i���X�g</param>
        /// <returns>���i���i</returns>
        /// <remarks>
        /// <br>Note       : ���i���i���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private double GetPrice(List<GoodsPrice> goodsPriceList)
        {
            double price = 0;
            GoodsPrice goodsPrice = new GoodsPrice();

            try
            {
                goodsPrice = this._goodsAcs.GetGoodsPriceFromGoodsPriceList(DateTime.Today, goodsPriceList);
                price = goodsPrice.ListPrice;
            }
            catch
            {
                price = 0;
            }

            return (price);
        }

        #endregion �}�X�^���擾

        // ADD 2009/06/29 ------>>>
        #region �}�X�^���݃`�F�b�N
        /// <summary>
        /// ���Ӑ摶�݃`�F�b�N����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>true�FOK�Afalse�FNG</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ悪���݂��邩�`�F�b�N���܂��B</br>
        /// <br></br>
        /// </remarks>
        private bool CheckCustomer(int customerCode)
        {
            bool check = false;

            try
            {
                if (this._customerSearchRetDic.ContainsKey(customerCode))
                {
                    check = true;
                }
            }
            catch
            {
                check = false;
            }

            return check;
        }

        /// <summary>
        /// �d���摶�݃`�F�b�N����
        /// </summary>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <returns>true�FOK�Afalse�FNG</returns>
        /// <remarks>
        /// <br>Note       : �d���悪���݂��邩�`�F�b�N���܂��B</br>
        /// <br></br>
        /// </remarks>
        private bool CheckSupplier(int supplierCode)
        {
            bool check = false;

            try
            {
                if (this._supplierDic.ContainsKey(supplierCode))
                {
                    check = true;
                }
            }
            catch
            {
                check = false;
            }

            return check;
        }
        #endregion �}�X�^���݃`�F�b�N
        // ADD 2009/06/29 ------<<<
        
        #region ��ʓ��͋��ݒ�

        /// <summary>
        /// ��ʓ��͋��ݒ菈��
        /// </summary>
        /// <param name="editMode">�ҏW���[�h(�V�K�E�X�V�E�폜)</param>
        /// <remarks>
        /// <br>Note       : ��ʃR���g���[���̓��͋���ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// <br></br>
        /// <br>Update Note: 2009/12/15 ���M</br>
        /// <br>             �ێ�˗��C�Ή�</br>
        /// <br>Update Note: 2010/08/10 �k���r PM1012�Ή�</br>
        /// <br>             �t�H�[�J�X����̌�����</br>
        /// <br>Update Note : 2011/08/05 caohh</br>
        /// <br>              NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
        /// <br>Update Note : 2012/11/30 ���N</br>
        /// <br>              20130116�z�M�� Redmine#33663�̑Ή�</br>
        /// </remarks>
        private void ScreenInputPermissionControl(string editMode)
        {
            this.tEdit_SectionCodeAllowZero.Enabled = false;
            this.SectionGuide_Button.Enabled = false;
            this.UnitPriceKind_tComboEditor.Enabled = false;
            this.UnitPriceKindWay_tComboEditor.Enabled = false;
            this.RateSettingDivide_tEdit.Enabled = false;
            this.RateSettingDivideGuide_Button.Enabled = false;
            this.tNedit_CustomerCode.Enabled = false;
            this.CustomerGuide_Button.Enabled = false;
            // --- CHG 2009/01/13 --------------------------------------------------------------------->>>>>
            //this.CustRateGrpCode_tComboEditor.Enabled = false;
            this.tNedit_CustRateGrpCodeZero.Enabled = false;
            this.CustRateGrpGuide_Button.Enabled = false;
            // --- CHG 2009/01/13 ---------------------------------------------------------------------<<<<<
            this.tNedit_SupplierCd.Enabled = false;
            this.SupplierGuide_Button.Enabled = false;
            this.tNedit_GoodsMakerCd.Enabled = false;
            this.MakerGuide_Button.Enabled = false;
            this.GoodsRateRank_tEdit.Enabled = false;
            this.tNedit_GoodsMGroup.Enabled = false;
            this.GoodsRateGrpGuide_Button.Enabled = false;
            this.tNedit_BLGloupCode.Enabled = false;
            this.BLGroupGuide_Button.Enabled = false;
            this.tNedit_BLGoodsCode.Enabled = false;
            this.BLGoodsGuide_Button.Enabled = false;
            this.tEdit_GoodsNo.Enabled = false;
            this.Detail_uGrid.Enabled = false;

            // �ۑ��{�^����\��
            this._isSave = false;

            // �폜�{�^����\��
            this._isDelete = false;

            // �����{�^����\��
            this._isRevival = false;

            // �ŐV���{�^����\��
            this._isRenewal = false;
            
            //-----ADD 2010/08/10---------->>>>>
            this._isGuide = false;
            //-----ADD 2010/08/10----------<<<<<
            this._isSetUp = true; // ADD caohh 2011/08/05
            string unitPriceKind = string.Empty;// ADD 2009/12/15

            switch (editMode)
            {
                // �V�K���[�h
                case INSERT_MODE:

                    this.tEdit_SectionCodeAllowZero.Enabled = true;
                    this.UnitPriceKind_tComboEditor.Enabled = true;
                    this.UnitPriceKindWay_tComboEditor.Enabled = true;
                    this.RateSettingDivide_tEdit.Enabled = true;

                    this.SectionGuide_Button.Enabled = true;
                    this.RateSettingDivideGuide_Button.Enabled = true;

                    // �ۑ��{�^���\��
                    this._isSave = true;

                    // �ŐV���{�^���\��
                    this._isRenewal = true;
                    //-----UPD 2010/08/10---------->>>>>
                    SettingGuideButtonToolEnabled(tEdit_SectionCodeAllowZero);
                    //-----UPD 2010/08/10----------<<<<<
                    // ------- DEL 2012/11/30 ���N Redmine#33663 ------------>>>>>
                    //// -------ADD 2009/12/15------->>>>>
                    //// �P����ގ擾
                    //unitPriceKind = (string)this.UnitPriceKind_tComboEditor.Value;
                    //if (unitPriceKind == "2")
                    //{
                    //    // �����ݒ�̏ꍇ�A�ݒ���@�̓O���[�v�ݒ�Œ�
                    //    UnitPriceKindWay_tComboEditor.Enabled = false;
                    //    UnitPriceKindWay_tComboEditor.Value = 1;
                    //}
                    //else
                    //{
                    //    // �����ݒ�ȊO
                    //    UnitPriceKindWay_tComboEditor.Enabled = true;
                    //}
                    //// -------ADD 2009/12/15-------<<<<<
                    // ------- DEL 2012/11/30 ���N Redmine#33663 ------------<<<<<
                    break;
                // �X�V���[�h
                case UPDATE_MODE:

                    // -------ADD 2009/12/15------->>>>>
                    this.tEdit_SectionCodeAllowZero.Enabled = true;
                    this.SectionGuide_Button.Enabled = true;
                    this.RateSettingDivide_tEdit.Enabled = true;
                    this.RateSettingDivideGuide_Button.Enabled = true;
                    this.UnitPriceKind_tComboEditor.Enabled = true;
                    // -------UPD 2009/12/15------->>>>>
                    //this.UnitPriceKindWay_tComboEditor.Enabled = true;
                    this.UnitPriceKindWay_tComboEditor.Enabled = true; // ADD 2012/11/30  ���N Redmine#33663
                    // -------DEL 2012/11/30 ���N Redmine#33663 ------->>>>>
                    //// �P����ގ擾
                    //unitPriceKind = (string)this.UnitPriceKind_tComboEditor.Value;
                    //if (unitPriceKind == "2")
                    //{
                    //    // �����ݒ�̏ꍇ�A�ݒ���@�̓O���[�v�ݒ�Œ�
                    //    UnitPriceKindWay_tComboEditor.Enabled = false;
                    //    UnitPriceKindWay_tComboEditor.Value = 1;
                    //}
                    //else
                    //{
                    //    // �����ݒ�ȊO
                    //    UnitPriceKindWay_tComboEditor.Enabled = true;
                    //}
                    // -------DEL 2012/11/30 ���N Redmine#33663 -------<<<<<
                    // �ŐV���{�^���\��
                    this._isRenewal = true;
                    // -------UPD 2009/12/15-------<<<<<


                    // �����R���g���[��(�����)���͋�����
                    SetCustomerConditionEnabled();

                    // �����R���g���[��(���i)���͋�����
                    SetGoodsConditionEnabled();
                    // -------ADD 2009/12/15-------<<<<<

                    this.Detail_uGrid.Enabled = true;

                    // �ۑ��{�^���\��
                    this._isSave = true;

                    // �폜�{�^���\��
                    this._isDelete = true;

                    //-----UPD 2010/08/10---------->>>>>
                    SettingGuideButtonToolEnabled(tEdit_SectionCodeAllowZero);
                    //-----UPD 2010/08/10----------<<<<<

                    break;
                // �폜���[�h
                case DELETE_MODE:

                    // �폜�{�^���\��
                    this._isDelete = true;

                    // �����{�^���\��
                    this._isRevival = true;

                    break;
            }

            ParentToolbarRateSettingEvent(this);
        }

        /// <summary>
        /// �O���b�h���͋��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�̓��͋���ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void SetGridEnabled()
        {
            this.Detail_uGrid.Enabled = false;

            if ((this.RateMngCustCd_tEdit.DataText.Trim() == "") || (this.RateMngGoodsCd_tEdit.DataText.Trim() == ""))
            {
                return;
            }

            this.Detail_uGrid.Enabled = true;

            for (int rowIndex = 0; rowIndex < ROW_COUNT; rowIndex++)
            {
                this.Detail_uGrid.Rows[rowIndex].Activation = Activation.Disabled;
            }

            // �P�����
            int unitPriceKindCode = int.Parse((string)this.UnitPriceKind_tComboEditor.Value);

            // �ݒ���@
            //-----UPD 2010/08/10---------->>>>>
            int unitPriceKindWayCode = -1;
            if ("2".Equals(this.UnitPriceKindWay_tComboEditor.Text) || UNITPRICEKINDWAY_0.Equals(this.UnitPriceKindWay_tComboEditor.Text))
            {
                unitPriceKindWayCode = 0;
            }
            else
            {
                unitPriceKindWayCode = (int)this.UnitPriceKindWay_tComboEditor.Value;
            }
            //int unitPriceKindWayCode = (int)this.UnitPriceKindWay_tComboEditor.Value;
            //-----UPD 2010/08/10----------<<<<<

            for (int rowIndex = 0; rowIndex < ROW_COUNT; rowIndex++)
            {
                switch (rowIndex)
                {
                    // ����(�ȏ�)
                    case ROWINDEX_LOTCOUNTABOVE:
                        // �����ݒ�
                        if (unitPriceKindCode == 1)
                        {
                            // �Z�����͋��ݒ�
                            SetCellEnabled(rowIndex, 1);
                        }
                        break;
                    // ����(�ȉ�)
                    case ROWINDEX_LOTCOUNTBELOW:
                        break;
                    // �������A����UP���A�e���m�ۗ�
                    case ROWINDEX_SALERATEVAL:
                    case ROWINDEX_COSTUPRATE:
                    case ROWINDEX_GRSPROFITSECURERATE:
                        // �����ݒ�
                        if (unitPriceKindCode == 1)
                        {
                            // �Z�����͋��ݒ�
                            SetCellEnabled(rowIndex, 0);
                        }
                        break;
                    // �����z
                    case ROWINDEX_SALEPRICEFL:
                        // �����ݒ�
                        if (unitPriceKindCode == 1)
                        {
                            // �P�i�ݒ�
                            if (unitPriceKindWayCode == 0)
                            {
                                // �Z�����͋��ݒ�
                                SetCellEnabled(rowIndex, 0);
                            }
                        }
                        break;
                    // �d����
                    case ROWINDEX_COSTRATEVAL:
                        // �����ݒ�
                        if (unitPriceKindCode == 2)
                        {
                            // �Z�����͋��ݒ�
                            SetCellEnabled(rowIndex, 0);
                        }
                        break;
                    // �d������
                    case ROWINDEX_COSTPRICEFL:
                        // �����ݒ�
                        if (unitPriceKindCode == 2)
                        {
                            // �P�i�ݒ�
                            if (unitPriceKindWayCode == 0)
                            {
                                // �Z�����͋��ݒ�
                                SetCellEnabled(rowIndex, 0);
                            }
                        }
                        break;
                    // ���[�U�[�艿
                    case ROWINDEX_USERPRICEFL:
                        // ���i�ݒ�
                        if (unitPriceKindCode == 3)
                        {
                            // �P�i�ݒ�
                            if (unitPriceKindWayCode == 0)
                            {
                                // �Z�����͋��ݒ�
                                SetCellEnabled(rowIndex, 0);
                            }
                        }
                        break;
                    // �艿UP��
                    case ROWINDEX_PRICEUPRATE:
                    // �[�������P�ʁA�[�������敪
                    case ROWINDEX_UNPRCFRACPROCUNIT:
                    case ROWINDEX_UNPRCFRACPROCDIV:
                        // ���i�ݒ�
                        if (unitPriceKindCode == 3)
                        {
                            // �Z�����͋��ݒ�
                            SetCellEnabled(rowIndex, 0);
                        }
                        break;
                    //// �[�������P�ʁA�[�������敪
                    //case ROWINDEX_UNPRCFRACPROCUNIT:
                    //case ROWINDEX_UNPRCFRACPROCDIV:

                    //    // �Z�����͋��ݒ�
                    //    SetCellEnabled(rowIndex, 0);
                    //    break;
                }
            }
        }

        /// <summary>
        /// �Z�����͋��ݒ菈��
        /// </summary>
        /// <param name="rowIndex">�s�C���f�b�N�X</param>
        /// <param name="allowEditColumnIndex">���͉\��C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �Z���̓��͋���ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void SetCellEnabled(int rowIndex, int allowEditColumnIndex)
        {
            // �Ώۍs����͉ɐݒ�
            this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Activation = Activation.AllowEdit;

            // �񐔕��������[�v
            for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
            {
                if (columnIndex == allowEditColumnIndex)
                {
                    // �Ώۂ̃Z������͉ɐݒ�
                    this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activation = Activation.AllowEdit;
                }
                else
                {
                    // �Ώۂ̃Z������͕s�ɐݒ�
                    this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activation = Activation.Disabled;
                }
            }
        }

        /// <summary>
        /// �Z�����͋��ύX����
        /// </summary>
        /// <param name="columnIndex">��C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �Z���̓��͋���ύX���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void ChangeCellEnabled(int columnIndex)
        {
            // �ݒ���@
            int unitPriceKindWayCode = (int)this.UnitPriceKindWay_tComboEditor.Value;

            for (int rowIndex = 0; rowIndex < ROW_COUNT; rowIndex++)
            {
                // �P�i�ݒ�
                if (unitPriceKindWayCode == 0)
                {
                    switch (rowIndex)
                    {
                        // �������A�����z�A����UP���A�e���m�ۗ��A�[�������P�ʁA�[�������敪
                        case ROWINDEX_SALERATEVAL:
                        case ROWINDEX_SALEPRICEFL:
                        case ROWINDEX_COSTUPRATE:
                        case ROWINDEX_GRSPROFITSECURERATE:
                            // �ΏۃZ������͉\�ɕύX
                            this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Activation = Activation.AllowEdit;
                            this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activation = Activation.AllowEdit;
                            break;
                        //case ROWINDEX_UNPRCFRACPROCUNIT:
                        //case ROWINDEX_UNPRCFRACPROCDIV:
                        //    if (unitPriceKind == "3")
                        //    {
                        //        // �ΏۃZ������͉\�ɕύX
                        //        this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Activation = Activation.AllowEdit;
                        //        this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activation = Activation.AllowEdit;
                        //    }
                        //    break;
                        default:
                            break;
                    }
                }
                // �O���[�v�ݒ�
                else
                {
                    switch (rowIndex)
                    {
                        // �������A����UP���A�e���m�ۗ��A�[�������P�ʁA�[�������敪
                        case ROWINDEX_SALERATEVAL:
                        case ROWINDEX_COSTUPRATE:
                        case ROWINDEX_GRSPROFITSECURERATE:
                            // �ΏۃZ������͉\�ɕύX
                            this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Activation = Activation.AllowEdit;
                            this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activation = Activation.AllowEdit;
                            break;
                        //case ROWINDEX_UNPRCFRACPROCUNIT:
                        //case ROWINDEX_UNPRCFRACPROCDIV:
                        //    // �ΏۃZ������͉\�ɕύX
                        //    this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Activation = Activation.AllowEdit;
                        //    this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activation = Activation.AllowEdit;
                        //    break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// �����R���g���[��(�����)���͋��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����R���g���[��(�����)�̓��͋���ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void SetCustomerConditionEnabled()
        {
            // �|���ݒ�敪
            string rateSettingDivide = this.RateSettingDivide_tEdit.DataText.Trim();

            this.tNedit_CustomerCode.Enabled = false;
            this.CustomerGuide_Button.Enabled = false;
            // --- CHG 2009/01/13 --------------------------------------------------------------------->>>>>
            //this.CustRateGrpCode_tComboEditor.Enabled = false;
            this.tNedit_CustRateGrpCodeZero.Enabled = false;
            this.CustRateGrpGuide_Button.Enabled = false;
            // --- CHG 2009/01/13 ---------------------------------------------------------------------<<<<<
            this.tNedit_SupplierCd.Enabled = false;
            this.SupplierGuide_Button.Enabled = false;

            if (this.tNedit_RatePriorityOrder.GetInt() == 0)
            {
                return;
            }

            // ���Ӑ悪�|���ݒ�敪�̐ݒ�Ώۂ����擾
            if (RateAcs.IsCustomerSetting(rateSettingDivide))
            {
                this.tNedit_CustomerCode.Enabled = true;
                this.CustomerGuide_Button.Enabled = true;
            }
            // �d���悪�|���ݒ�敪�̐ݒ�Ώۂ����擾
            if (RateAcs.IsSupplierSetting(rateSettingDivide))
            {
                this.tNedit_SupplierCd.Enabled = true;
                this.SupplierGuide_Button.Enabled = true;
            }
            // ���Ӑ�|���ݒ�GR���|���ݒ�敪�̐ݒ�Ώۂ����擾
            if (RateAcs.IsCustRateGrpSetting(rateSettingDivide))
            {
                // --- CHG 2009/01/13 --------------------------------------------------------------------->>>>>
                //this.CustRateGrpCode_tComboEditor.Enabled = true;
                this.tNedit_CustRateGrpCodeZero.Enabled = true;
                this.CustRateGrpGuide_Button.Enabled = true;
                // --- CHG 2009/01/13 ---------------------------------------------------------------------<<<<<
            }
        }

        /// <summary>
        /// �t�H�[�J�X�ݒ菈��
        /// </summary>
        /// <param name="index">�J�����g�R���g���[��(0:�|���ݒ�敪�@1:���Ӑ�@2:�d����@3:���[�J�[  4:���i�|���f�@5:�O���[�v�R�[�h�@6:BL�R�[�h)</param>
        /// <br>Update Note: 2010/08/10 �k���r PM1012�Ή�</br>
        /// <br>             �K�C�h���u�e�T�v�{�^���ŕ\������悤�ɕύX</br>
        private void SetNextFocus(int index)
        {
            // �|���ݒ�敪
            string rateSettingDivide = this.RateSettingDivide_tEdit.DataText.Trim();

            switch (index)
            {
                // �|���ݒ�敪
                case 0:
                    // ���Ӑ悪�|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsCustomerSetting(rateSettingDivide))
                    {
                        this.tNedit_CustomerCode.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_CustomerCode);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // ���Ӑ�|���ݒ�GR���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsCustRateGrpSetting(rateSettingDivide))
                    {
                        // --- CHG 2009/01/13 --------------------------------------------------------------------->>>>>
                        //this.CustRateGrpCode_tComboEditor.Focus();
                        this.tNedit_CustRateGrpCodeZero.Focus();
                        // --- CHG 2009/01/13 ---------------------------------------------------------------------<<<<<
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_CustRateGrpCodeZero);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // �d���悪�|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsSupplierSetting(rateSettingDivide))
                    {
                        this.tNedit_SupplierCd.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_SupplierCd);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // ���[�J�[���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsMakerSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMakerCd.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_GoodsMakerCd);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // �w�ʂ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        this.GoodsRateRank_tEdit.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(GoodsRateRank_tEdit);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // ���i�|���f���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMGroup.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_GoodsMGroup);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // BL�O���[�v�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGloupCode.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_BLGloupCode);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // BL�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_BLGoodsCode);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // �i�Ԃ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    break;
                // ���Ӑ�R�[�h
                case 1:
                    // ���Ӑ�|���ݒ�GR���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsCustRateGrpSetting(rateSettingDivide))
                    {
                        // --- CHG 2009/01/13 --------------------------------------------------------------------->>>>>
                        //this.CustRateGrpCode_tComboEditor.Focus();
                        this.tNedit_CustRateGrpCodeZero.Focus();
                        // --- CHG 2009/01/13 ---------------------------------------------------------------------<<<<<
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_CustRateGrpCodeZero);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // �d���悪�|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsSupplierSetting(rateSettingDivide))
                    {
                        this.tNedit_SupplierCd.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_SupplierCd);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // ���[�J�[���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsMakerSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMakerCd.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_GoodsMakerCd);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // �w�ʂ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        this.GoodsRateRank_tEdit.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(GoodsRateRank_tEdit);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // ���i�|���f���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMGroup.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_GoodsMGroup);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // BL�O���[�v�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGloupCode.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_BLGloupCode);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // BL�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_BLGoodsCode);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // �i�Ԃ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    break;
                // �d����R�[�h
                case 2:
                    // ���[�J�[���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsMakerSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMakerCd.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_GoodsMakerCd);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // �w�ʂ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        this.GoodsRateRank_tEdit.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(GoodsRateRank_tEdit);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // ���i�|���f���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMGroup.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_GoodsMGroup);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // BL�O���[�v�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGloupCode.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_BLGloupCode);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // BL�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_BLGoodsCode);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // �i�Ԃ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    break;
                // ���[�J�[
                case 3:
                    // �w�ʂ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        this.GoodsRateRank_tEdit.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(GoodsRateRank_tEdit);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // ���i�|���f���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMGroup.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_GoodsMGroup);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // BL�O���[�v�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGloupCode.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_BLGloupCode);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // BL�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_BLGoodsCode);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // �i�Ԃ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    break;
                // ���i�|���f
                case 4:
                    // BL�O���[�v�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGloupCode.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_BLGloupCode);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // BL�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_BLGoodsCode);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // �i�Ԃ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    break;
                // �O���[�v�R�[�h
                case 5:
                    // BL�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_BLGoodsCode);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // �i�Ԃ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    break;
                // BL�R�[�h
                case 6:
                    // �i�Ԃ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    break;
                // ADD 2008/10/29 �s��Ή�[7174] ---------->>>>>
                // �w��
                case 7:
                    // ���i�|���f���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMGroup.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_GoodsMGroup);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // BL�O���[�v�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGloupCode.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_BLGloupCode);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // BL�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_BLGoodsCode);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    // �i�Ԃ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                        //-----ADD 2010/08/10----------<<<<<
                        return;
                    }
                    break;
                // ADD 2008/10/29 �s��Ή�[7174] ----------<<<<<
                // ���Ӑ�|���O���[�v
                case 8:
                    {
                        // �d���悪�|���ݒ�敪�̐ݒ�Ώۂ����擾
                        if (RateAcs.IsSupplierSetting(rateSettingDivide))
                        {
                            this.tNedit_SupplierCd.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_SupplierCd);
                            //-----ADD 2010/08/10----------<<<<<
                            return;
                        }
                        // ���[�J�[���|���ݒ�敪�̐ݒ�Ώۂ����擾
                        if (RateAcs.IsMakerSetting(rateSettingDivide))
                        {
                            this.tNedit_GoodsMakerCd.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_GoodsMakerCd);
                            //-----ADD 2010/08/10----------<<<<<
                            return;
                        }
                        // �w�ʂ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                        if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                        {
                            this.GoodsRateRank_tEdit.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(GoodsRateRank_tEdit);
                            //-----ADD 2010/08/10----------<<<<<
                            return;
                        }
                        // ���i�|���f���|���ݒ�敪�̐ݒ�Ώۂ����擾
                        if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                        {
                            this.tNedit_GoodsMGroup.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_GoodsMGroup);
                            //-----ADD 2010/08/10----------<<<<<
                            return;
                        }
                        // BL�O���[�v�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                        if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                        {
                            this.tNedit_BLGloupCode.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_BLGloupCode);
                            //-----ADD 2010/08/10----------<<<<<
                            return;
                        }
                        // BL�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                        if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                        {
                            this.tNedit_BLGoodsCode.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_BLGoodsCode);
                            //-----ADD 2010/08/10----------<<<<<
                            return;
                        }
                        // �i�Ԃ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                        if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                        {
                            this.tEdit_GoodsNo.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                            //-----ADD 2010/08/10----------<<<<<
                            return;
                        }
                        break;
                    }
            }

            for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < ROW_COUNT; rowIndex++)
                {
                    if (this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Activation != Activation.AllowEdit)
                    {
                        continue;
                    }

                    if (this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activation != Activation.AllowEdit)
                    {
                        continue;
                    }

                    this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activate();
                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    return;
                }
            }
        }

        /// <summary>
        /// �t�H�[�J�X�ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|���ݒ�敪����āA�t�H�[�J�X�ݒ菈���쐬���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/12/15</br>
        /// <br>Update Note: 2010/08/10 �k���r PM1012�Ή�</br>
        /// <br>             �K�C�h���u�e�T�v�{�^���ŕ\������悤�ɕύX</br>
        /// </remarks>
        private void SetNextFocus()
        {
            // �|���ݒ�敪
            string rateSettingDivide = this.RateSettingDivide_tEdit.DataText.Trim();

            // �i�Ԃ��|���ݒ�敪�̐ݒ�Ώۂ����擾
            if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
            {
                this.tEdit_GoodsNo.Focus();
                //-----ADD 2010/08/10---------->>>>>
                SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                //-----ADD 2010/08/10----------<<<<<
                return;
            }

            // BL�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
            if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
            {
                this.tNedit_BLGoodsCode.Focus();
                //-----ADD 2010/08/10---------->>>>>
                SettingGuideButtonToolEnabled(tNedit_BLGoodsCode);
                //-----ADD 2010/08/10----------<<<<<
                return;
            }

            // BL�O���[�v�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
            if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
            {
                this.tNedit_BLGloupCode.Focus();
                //-----ADD 2010/08/10---------->>>>>
                SettingGuideButtonToolEnabled(tNedit_BLGloupCode);
                //-----ADD 2010/08/10----------<<<<<
                return;
            }

            // ���i�|���f���|���ݒ�敪�̐ݒ�Ώۂ����擾
            if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
            {
                this.tNedit_GoodsMGroup.Focus();
                //-----ADD 2010/08/10---------->>>>>
                SettingGuideButtonToolEnabled(tNedit_GoodsMGroup);
                //-----ADD 2010/08/10----------<<<<<
                return;
            }

            // �w�ʂ��|���ݒ�敪�̐ݒ�Ώۂ����擾
            if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
            {
                this.GoodsRateRank_tEdit.Focus();
                //-----ADD 2010/08/10---------->>>>>
                SettingGuideButtonToolEnabled(GoodsRateRank_tEdit);
                //-----ADD 2010/08/10----------<<<<<
                return;
            }

            // ���[�J�[���|���ݒ�敪�̐ݒ�Ώۂ����擾
            if (RateAcs.IsMakerSetting(rateSettingDivide))
            {
                this.tNedit_GoodsMakerCd.Focus();
                //-----ADD 2010/08/10---------->>>>>
                SettingGuideButtonToolEnabled(tNedit_GoodsMakerCd);
                //-----ADD 2010/08/10----------<<<<<
                return;
            }

            // �d���悪�|���ݒ�敪�̐ݒ�Ώۂ����擾
            if (RateAcs.IsSupplierSetting(rateSettingDivide))
            {
                this.tNedit_SupplierCd.Focus();
                //-----ADD 2010/08/10---------->>>>>
                SettingGuideButtonToolEnabled(tNedit_SupplierCd);
                //-----ADD 2010/08/10----------<<<<<
                return;
            }

            // ���Ӑ�|���ݒ�GR���|���ݒ�敪�̐ݒ�Ώۂ����擾
            if (RateAcs.IsCustRateGrpSetting(rateSettingDivide))
            {
                this.tNedit_CustRateGrpCodeZero.Focus();
                //-----ADD 2010/08/10---------->>>>>
                SettingGuideButtonToolEnabled(tNedit_CustRateGrpCodeZero);
                //-----ADD 2010/08/10----------<<<<<
                return;
            }

            // ���Ӑ悪�|���ݒ�敪�̐ݒ�Ώۂ����擾
            if (RateAcs.IsCustomerSetting(rateSettingDivide))
            {
                this.tNedit_CustomerCode.Focus();
                //-----ADD 2010/08/10---------->>>>>
                SettingGuideButtonToolEnabled(tNedit_CustomerCode);
                //-----ADD 2010/08/10----------<<<<<
                return;
            }
        }

        /// <summary>
        /// �����R���g���[��(���i)���͋��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����R���g���[��(���i)�̓��͋���ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void SetGoodsConditionEnabled()
        {
            // �|���ݒ�敪
            string rateSettingDivide = this.RateSettingDivide_tEdit.DataText.Trim();

            this.tNedit_GoodsMakerCd.Enabled = false;
            this.MakerGuide_Button.Enabled = false;
            this.GoodsRateRank_tEdit.Enabled = false;
            this.tNedit_GoodsMGroup.Enabled = false;
            this.GoodsRateGrpGuide_Button.Enabled = false;
            this.tNedit_BLGloupCode.Enabled = false;
            this.BLGroupGuide_Button.Enabled = false;
            this.tNedit_BLGoodsCode.Enabled = false;
            this.BLGoodsGuide_Button.Enabled = false;
            this.tEdit_GoodsNo.Enabled = false;

            if (this.tNedit_RatePriorityOrder.GetInt() == 0)
            {
                return;
            }

            // ���[�J�[���|���ݒ�敪�̐ݒ�Ώۂ����擾
            if (RateAcs.IsMakerSetting(rateSettingDivide))
            {
                this.tNedit_GoodsMakerCd.Enabled = true;
                this.MakerGuide_Button.Enabled = true;
            }
            // �w�ʂ��|���ݒ�敪�̐ݒ�Ώۂ����擾
            if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
            {
                this.GoodsRateRank_tEdit.Enabled = true;
            }
            // ���i�|���f���|���ݒ�敪�̐ݒ�Ώۂ����擾
            if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
            {
                this.tNedit_GoodsMGroup.Enabled = true;
                this.GoodsRateGrpGuide_Button.Enabled = true;
            }
            // BL�O���[�v�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
            if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
            {
                this.tNedit_BLGloupCode.Enabled = true;
                this.BLGroupGuide_Button.Enabled = true;
            }
            // BL�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
            if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
            {
                this.tNedit_BLGoodsCode.Enabled = true;
                this.BLGoodsGuide_Button.Enabled = true;
            }
            // �i�Ԃ��|���ݒ�敪�̐ݒ�Ώۂ����擾
            if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
            {
                this.tEdit_GoodsNo.Enabled = true;
            }
        }

        #endregion ��ʓ��͋��ݒ�

        #region ���b�Z�[�W�{�b�N�X�\��

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
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
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
        /// ���b�Z�[�W�{�b�N�X�\������
        /// </summary>
        /// <param name="errLevel">�G���[���x��</param>
        /// <param name="methodName">��������</param>
        /// <param name="message">�\�����郁�b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X�l</param>
        /// <param name="msgButton">�\������{�^��</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�{�b�N�X��\�����܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // �e�E�B���h�E�t�H�[��
                                         errLevel,			                // �G���[���x��
                                         this.Name,						    // �v���O��������
                                         ASSEMBLY_ID, 		  �@�@			// �A�Z���u��ID
                                         methodName,						// ��������
                                         "",					            // �I�y���[�V����
                                         message,	                        // �\�����郁�b�Z�[�W
                                         status,							// �X�e�[�^�X�l
                                         this._rateAcs,					    // �G���[�����������I�u�W�F�N�g
                                         msgButton,         			  	// �\������{�^��
                                         MessageBoxDefaultButton.Button1);	// �����\���{�^��

            return dialogResult;
        }

        #endregion ���b�Z�[�W�{�b�N�X�\��

        /// <summary>
        /// �|���}�X�^�V�K�쐬����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^��V�K�쐬���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// <br>Update Note: 2010/08/10 �k���r PM1012�Ή�</br>
        /// <br>             �K�C�h���u�e�T�v�{�^���ŕ\������悤�ɕύX</br>
        /// </remarks>
        private bool NewProc()
        {
            this.Enabled = false;

            // ��ʓ��͋�����
            ScreenInputPermissionControl(INSERT_MODE);

            // ��ʏ��N���A
            ScreenClear();

            // �O���b�h������
            ClearGrid("");

            this.Enabled = true;

            // �t�H�[�J�X�ݒ�
            this.tEdit_SectionCodeAllowZero.Focus();

            //-----ADD 2010/08/10---------->>>>>
            SettingGuideButtonToolEnabled(tEdit_SectionCodeAllowZero);
            //-----ADD 2010/08/10----------<<<<<

            this._rateListClone = new List<Rate>();

            return (true);
        }

        /// <summary>
        /// �ۑ����s��A�|���}�X�^�V�K�쐬�����u�w�b�_���́u�|���ݒ�v�̓��e���N���A���Ȃ��v
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^��V�K�쐬���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/12/15</br>
        /// <br>Update Note: 2010/08/10 �k���r PM1012�Ή�</br>
        /// <br>             �K�C�h���u�e�T�v�{�^���ŕ\������悤�ɕύX</br>
        /// </remarks>
        private bool NewProcNotClear()
        {
            this.Enabled = false;

            // ��ʓ��͋�����
            ScreenInputPermissionControl(INSERT_MODE);

            // ��ʏ��N���A
            this.Mode_Label.Text = INSERT_MODE;

            // ADD �� 2014/03/20 ----------------------->>>>>
            this.UpdateDateTime_tDateEdit.Clear();
            // ADD �� 2014/03/20 -----------------------<<<<<

            // ��������(�����ݒ�)�N���A
            ClearCustomerCondition();

            // ��������(���i�ݒ�)�N���A
            ClearGoodsCondition();

            // �����R���g���[��(�����)���͋�����
            SetCustomerConditionEnabled();

            // �����R���g���[��(���i)���͋�����
            SetGoodsConditionEnabled();

            // �O���b�h������
            ClearGrid("");

            // �P�����
            int unitPriceKind = int.Parse((string)this.UnitPriceKind_tComboEditor.Value);

            // �O���b�h������
            ClearGrid(unitPriceKind.ToString());

            // �O���b�h���͋�����
            SetGridEnabled();

            this.Enabled = true;

            // �t�H�[�J�X�ݒ�
            this.tEdit_SectionCodeAllowZero.Focus();

            //-----ADD 2010/08/10---------->>>>>
            SettingGuideButtonToolEnabled(tEdit_SectionCodeAllowZero);
            //-----ADD 2010/08/10----------<<<<<

            this._rateListClone = new List<Rate>();

            return (true);
        }

        /// <summary>
        /// �|���}�X�^�ۑ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�̕ۑ����s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// <br></br>
        /// <br>Update Note: 2009/12/15 ���M</br>
        /// <br>             �ێ�˗��C�Ή�</br>
        /// <br>Update Note : 2011/08/05 caohh</br>
        /// <br>              NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
        /// </remarks>
        private bool SaveProc()
        {
            bool bStatus;
            int status;
            string msg;
            int saveRecordCount;

            // ���̓`�F�b�N
            bStatus = CheckInputScreen(true);
            if (bStatus != true)
            {
                return (false);
            }

            // �P�����
            if (this.UnitPriceKind_tComboEditor.Value == null)
            {
                return (false);
            }
            string unitPriceKind = (string)this.UnitPriceKind_tComboEditor.Value;

            // �ۑ������擾
            saveRecordCount = GetSaveRecordCount(unitPriceKind);

            // �ۑ����X�g
            ArrayList saveList = new ArrayList();

            // �폜���X�g
            ArrayList deleteList = new ArrayList();
            bool deleteFlg = false;

            if (this._rateListClone.Count != 0)
            {
                // ----------------------
                // �X�V�̏ꍇ
                // ----------------------
                deleteFlg = true;

                foreach (Rate wkRate in this._rateListClone)
                {
                    // �폜���X�g�ɒǉ�
                    deleteList.Add(wkRate.Clone());
                }
            }

            for (int index = 0; index < saveRecordCount; index++)
            {
                Rate rate = new Rate();

                // ��ʏ��擾
                ScreenToRate(ref rate, index);

                // �ۑ����X�g�ɒǉ�
                saveList.Add(rate);
            }

            if (deleteFlg == true)
            {
                // �����폜����
                status = this._rateAcs.Delete(ref deleteList, out msg);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        // �r������
                        ExclusiveTransaction(status);
                        return (false);
                    default:
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "SaveProc",
                                       "�|���}�X�^�폜���ɃG���[���������܂����B",
                                       status,
                                       MessageBoxButtons.OK);

                        return (false);
                }
            }

            // �ۑ�����
            status = this._rateAcs.Write(ref saveList, out msg);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                   "�L�[���ڂ��d�����Ă��܂��B",
                                   status,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                    return (false);
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status);
                    return (false);
                default:
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "SaveProc",
                                       "�|���}�X�^�C�����ɃG���[���������܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                    return (false);
            }

            // �o�^�����_�C�A���O�\��
            SaveCompletionDialog dialog = new SaveCompletionDialog();
            dialog.ShowDialog(2);

            // -------UPD 2009/12/15------->>>>>
            // �V�K�쐬����
            //NewProc();
            //NewProcNotClear(); // DEL caohh 2011/08/05 caohh
            // -------UPD 2009/12/15-------<<<<<
            // -----ADD caohh 2011/08/05 ---------->>>>>
            // ���[�U�[�ݒ�̕ۑ��O�|����񂪁w�N���A����x�ꍇ
            if (this._rateInputConstructionAcs.SaveInfoDiv == 0)
            {
                NewProcNotClear();
            }
            // ���[�U�[�ݒ�̕ۑ��O�|����񂪁w�N���A���Ȃ��x�ꍇ
            else
            {
                // �|���}�X�^�Č���
                SearchAfterLeaveControl();
                // �t�H�[�J�X�ݒ�
                SetNextFocus(0);
            }
            // -----ADD caohh 2011/08/05 ----------<<<<<

            return (true);
        }

        /// <summary>
        /// �|���}�X�^��������(�t�H�[�J�X�ړ���)
        /// </summary>
        private void SearchAfterLeaveControl()
        {
            string errMsg;
            bool bStatus;

            // �|���ݒ�`�F�b�N
            bStatus = CheckRateCondition(out errMsg, false, false);
            if (!bStatus)
            {
                return;
            }

            // �����ݒ�`�F�b�N
            bStatus = CheckCustomerCondition(out errMsg, false, false);
            if (!bStatus)
            {
                return;
            }

            // ���i�ݒ�`�F�b�N
            bStatus = CheckGoodsCondition(out errMsg, false, false);
            if (!bStatus)
            {
                return;
            }

            // ��������
            SearchProc();
        }

        /// <summary>
        /// �|���}�X�^��������
        /// </summary>
        /// <param name="msgFlg">���b�Z�[�W�t���O(True:�\���@False:��\��)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�̌������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// <br></br>
        /// <br>Update Note: 2009/12/15 ���M</br>
        /// <br>             �ێ�˗��C�Ή�</br>
        /// <br>Update Note: 2010/08/10 �k���r PM1012�Ή�</br>
        /// <br>             �t�H�[�J�X����̌�����</br>
        /// <br>Update Note : 2011/08/05 caohh</br>
        /// <br>              NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
        /// </remarks>
        private bool SearchProc()
        {
            int status;
            bool bStatus;

            // �����������̓`�F�b�N
            bStatus = CheckInputScreen(false);
            if (bStatus == false)
            {
                return (false);
            }
            
            // ���������ݒ�
            Rate rate = new Rate();
            RateConditionToRate(ref rate);
            CustomerConditionToRate(ref rate);
            GoodsConditionToRate(ref rate);

            ArrayList retList = new ArrayList();
            string msg;
            
            // ��������
            status = this._rateAcs.SearchAll(out retList, ref rate, out msg);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:

                    // -------ADD 2009/12/15------->>>>>
                    // �V�K���[�h
                    this.Mode_Label.Text = INSERT_MODE;

                    // ADD �� 2014/03/20 ----------------------->>>>>
                    this.UpdateDateTime_tDateEdit.Clear();
                    // ADD �� 2014/03/20 -----------------------<<<<<
                    
                    // �O���b�h������
                    ClearGrid(rate.UnitPriceKind.Trim());

                    // �O���b�h���͐���
                    SetGridEnabled();

                    this._rateListClone = new List<Rate>();
                    // -------ADD 2009/12/15-------<<<<<

                    // -------ADD 2010/08/10------->>>>>
                    // ������̃t�H�[�J�X�ݒ���s���܂�
                    for (int rowIndex = 2; rowIndex < ROW_COUNT; rowIndex++)
                    {
                        if (this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[0].Activation == Activation.AllowEdit)
                        {
                            this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[0].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            break;
                        }
                    }
                    // -------ADD 2010/08/10-------<<<<<
                    return (false);
                default:
                    return (false);
            }

            List<Rate> rateList = new List<Rate>();
            this._rateListClone = new List<Rate>();

            foreach (Rate wkRate in retList)
            {
                rateList.Add(wkRate.Clone());
                this._rateListClone.Add(wkRate.Clone());
            }

            this.Enabled = false;

            // ��ʃN���A
            ScreenClear();

            // �O���b�h������
            ClearGrid(rateList[0].UnitPriceKind.Trim());

            // -------ADD 2009/12/15------->>>>>
            // �|���}�X�^��ʓW�J
            RateToScreen(rateList);
            // -------ADD 2009/12/15-------<<<<<

            // ��ʃR���g���[�����͋�����
            if (rateList[0].LogicalDeleteCode == 0)
            {
                // �X�V���[�h
                this.Mode_Label.Text = UPDATE_MODE;
                ScreenInputPermissionControl(UPDATE_MODE);
            }
            else
            {
                // �폜���[�h
                this.Mode_Label.Text = DELETE_MODE;
                ScreenInputPermissionControl(DELETE_MODE);
            }

            // -------DEL 2009/12/15------->>>>>
            //// �|���}�X�^��ʓW�J
            //RateToScreen(rateList);
            // -------DEL 2009/12/15-------<<<<<

            if (rateList[0].LogicalDeleteCode == 0)
            {
                // �O���b�h���͐���
                SetGridEnabled();

                // �����ݒ�̂Ƃ��̂�
                string unitPriceKind = (string)this.UnitPriceKind_tComboEditor.Value;
                if (unitPriceKind == "1")
                {
                    for (int index = 0; index < rateList.Count; index++)
                    {
                        // �Z�����͋��ύX
                        ChangeCellEnabled(index);
                    }

                    // ����(�ȏ�)�̓��͋�����
                    if (rateList.Count == COLUMN_COUNT)
                    {
                        for (int columnIndex = 1; columnIndex < rateList.Count; columnIndex++)
                        {
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTABOVE].Cells[columnIndex].Activation = Activation.AllowEdit;
                        }
                    }
                    else
                    {
                        for (int columnIndex = 1; columnIndex <= rateList.Count; columnIndex++)
                        {
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTABOVE].Cells[columnIndex].Activation = Activation.AllowEdit;
                        }
                    }
                }
            }

            this.Enabled = true;
            //-----ADD caohh 2011/08/05 ---------->>>>>
            if (this._rateInputConstructionAcs.SaveInfoDiv == 0) 
            {
            //-----ADD caohh 2011/08/05 ----------<<<<<
            // ������̃t�H�[�J�X�ݒ���s���܂�
            if (rateList[0].LogicalDeleteCode == 0)
            {
                for (int rowIndex = 2; rowIndex < ROW_COUNT; rowIndex++)
                {
                    if (this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[0].Activation == Activation.AllowEdit)
                    {
                        this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[0].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        break;
                    }
                }
            }
            } // ADD caohh 2011/08/05
            return true;
        }

        /// <summary>
        /// �|���}�X�^�_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�̘_���폜���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private bool LogicalDeleteProc()
        {
            // �_���폜�m�F
            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                                 "�f�[�^��_���폜���܂��B\r\n��낵���ł����H",
                                                 0,
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxDefaultButton.Button2);

            if (result == DialogResult.OK)
            {
                int status;
                string msg;
                ArrayList deleteList = new ArrayList();
                foreach (Rate rate in this._rateListClone)
                {
                    deleteList.Add(rate);
                }

                // �_���폜����
                status = this._rateAcs.LogicalDelete(ref deleteList, out msg);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        // �r������
                        ExclusiveTransaction(status);
                        return (false);
                    default:
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "LogicalDeleteProc",
                                       "�|���}�X�^�폜���ɃG���[���������܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                }

                // �V�K�쐬����
                NewProc();
            }

            return (true);
        }

        /// <summary>
        /// �|���}�X�^�����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�̕����폜���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private bool DeleteProc()
        {
            // ���S�폜�m�F
            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                                 "�f�[�^�𕨗��폜���܂��B\r\n��낵���ł����H",
                                                 0,
                                                 MessageBoxButtons.OKCancel,
                                                 MessageBoxDefaultButton.Button2);

            if (result == DialogResult.OK)
            {
                int status;
                string msg;
                ArrayList deleteList = new ArrayList();
                foreach (Rate rate in this._rateListClone)
                {
                    deleteList.Add(rate);
                }

                // �����폜����
                status = this._rateAcs.Delete(ref deleteList, out msg);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        // �r������
                        ExclusiveTransaction(status);
                        return (false);
                    default:
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "DeleteProc",
                                       "�|���}�X�^�폜���ɃG���[���������܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                }

                // �V�K�쐬����
                NewProc();
            }

            return (true);
        }

        /// <summary>
        /// �|���}�X�^��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�̕������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private bool RevivalProc()
        {
            DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_QUESTION,
                                              "���ݕ\�����̊|���}�X�^�𕜊����܂��B" + "\r\n" + "��낵���ł����H",
                                              0,
                                              MessageBoxButtons.YesNo,
                                              MessageBoxDefaultButton.Button2);
            if (res != DialogResult.Yes)
            {
                return (false);
            }

            int status;
            string msg;
            ArrayList revivalList = new ArrayList();
            foreach (Rate rate in this._rateListClone)
            {
                revivalList.Add(rate);
            }

            // ��������
            status = this._rateAcs.Revival(ref revivalList, out msg);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // �r������
                    ExclusiveTransaction(status);
                    return (false);
                default:
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "RevivalProc",
                                       "�|���}�X�^�������ɃG���[���������܂����B",
                                       status,
                                       MessageBoxButtons.OK);
                    return (false);
            }

            // �V�K�쐬����
            NewProc();

            return (true);
        }

        #region �`�F�b�N����

        /// <summary>
        /// ��ʏ����̓`�F�b�N����
        /// </summary>
        /// <param name="saveFlg">�ۑ��t���O(True:�ۑ��O�`�F�b�N�@False:���������`�F�b�N)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private bool CheckInputScreen(bool saveFlg)
        {
            string errMsg = "";
            bool bStatus;

            try
            {
                // �|���ݒ�`�F�b�N
                bStatus = CheckRateCondition(out errMsg, saveFlg, true);
                if (!bStatus)
                {
                    return (false);
                }

                // �����ݒ�`�F�b�N
                bStatus = CheckCustomerCondition(out errMsg, saveFlg, true);
                if (!bStatus)
                {
                    return (false);
                }

                // ���i�ݒ�`�F�b�N
                bStatus = CheckGoodsCondition(out errMsg, saveFlg, true);
                if (!bStatus)
                {
                    return (false);
                }

                if (saveFlg == true)
                {
                    // �O���b�h�`�F�b�N
                    bStatus = CheckDetail(out errMsg);
                    if (!bStatus)
                    {
                        return (false);
                    }
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                   errMsg,
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                }
            }

            return (true);
        }

        /// <summary>
        /// ��ʏ��(�|���ݒ�)���̓`�F�b�N����
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="saveFlg">�ۑ��t���O(True:�ۑ��O�`�F�b�N  False:���������`�F�b�N)</param>
        /// <param name="focusFlg">�t�H�[�J�X�ݒ�t���O(True:�ݒ肷��@False:�ݒ肵�Ȃ�)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��(�|���ݒ�)�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// <br>Update Note: 2010/08/10 �k���r PM1012�Ή�</br>
        /// <br>             �K�C�h���u�e�T�v�{�^���ŕ\������悤�ɕύX</br>
        /// </remarks>
        private bool CheckRateCondition(out string errMsg, bool saveFlg, bool focusFlg)
        {
            errMsg = "";

            // ���_�R�[�h
            if (this.tEdit_SectionCodeAllowZero.DataText.Trim() == "")
            {
                errMsg = "���_�R�[�h����͂��Ă��������B";
                if (focusFlg == true)
                {
                    this.tEdit_SectionCodeAllowZero.Focus();

                    //-----ADD 2010/08/10---------->>>>>
                    SettingGuideButtonToolEnabled(tEdit_SectionCodeAllowZero);
                    //-----ADD 2010/08/10----------<<<<<
                }
                return (false);
            }
            if (saveFlg == true)
            {
                // �ۑ��O�`�F�b�N���̂�
                string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();
                if (GetSectionName(sectionCode) == "")
                {
                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                    if (focusFlg == true)
                    {
                        this.tEdit_SectionCodeAllowZero.Focus();

                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tEdit_SectionCodeAllowZero);
                        //-----ADD 2010/08/10----------<<<<<
                    }
                    return (false);
                }
            }
            // �P�����
            if (this.UnitPriceKind_tComboEditor.Value == null)
            {
                errMsg = "�P����ނ�I�����Ă��������B";
                if (focusFlg == true)
                {
                    this.UnitPriceKind_tComboEditor.Focus();

                    //-----ADD 2010/08/10---------->>>>>
                    SettingGuideButtonToolEnabled(UnitPriceKind_tComboEditor);
                    //-----ADD 2010/08/10----------<<<<<
                }
                return (false);
            }
            // �ݒ���@
            if (this.UnitPriceKindWay_tComboEditor.Value == null)
            {
                errMsg = "�ݒ���@��I�����Ă��������B";
                if (focusFlg == true)
                {
                    this.UnitPriceKindWay_tComboEditor.Focus();
                    //-----ADD 2010/08/10---------->>>>>
                    SettingGuideButtonToolEnabled(UnitPriceKindWay_tComboEditor);
                    //-----ADD 2010/08/10----------<<<<<
                }
                return (false);
            }
            // �|���ݒ�敪
            if (this.RateSettingDivide_tEdit.DataText.Trim() == "")
            {
                errMsg = "�|���ݒ�敪����͂��Ă��������B";
                if (focusFlg == true)
                {
                    this.RateSettingDivide_tEdit.Focus();
                    //-----ADD 2010/08/10---------->>>>>
                    SettingGuideButtonToolEnabled(RateSettingDivide_tEdit);
                    //-----ADD 2010/08/10----------<<<<<
                }
                return (false);
            }
            if (saveFlg == true)
            {
                // �ۑ��O�`�F�b�N���̂�
                string rateSettingDivideCode = this.RateSettingDivide_tEdit.DataText;
                RateProtyMng rateProgyMng = new RateProtyMng();
                if (GetRateProtyMng(out rateProgyMng, rateSettingDivideCode) != 0)
                {
                    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                    if (focusFlg == true)
                    {
                        this.RateSettingDivide_tEdit.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(RateSettingDivide_tEdit);
                        //-----ADD 2010/08/10----------<<<<<
                    }
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// ��ʏ��(�����ݒ�)���̓`�F�b�N����
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="saveFlg">�ۑ��t���O(True:�ۑ��O�`�F�b�N  False:���������`�F�b�N)</param>
        /// <param name="focusFlg">�t�H�[�J�X�ݒ�t���O(True:�ݒ肷��@False:�ݒ肵�Ȃ�)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��(�����ݒ�)�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// <br>Update Note: 2010/08/10 �k���r PM1012�Ή�</br>
        /// <br>             �K�C�h���u�e�T�v�{�^���ŕ\������悤�ɕύX</br>
        /// </remarks>
        private bool CheckCustomerCondition(out string errMsg, bool saveFlg, bool focusFlg)
        {
            errMsg = "";

            // �|���ݒ�敪
            string rateSettingDivide = this.RateSettingDivide_tEdit.DataText.Trim();

            // ���Ӑ�R�[�h
            if (RateAcs.IsCustomerSetting(rateSettingDivide))
            {
                if (this.tNedit_CustomerCode.GetInt() == 0)
                {
                    errMsg = "���Ӑ�R�[�h����͂��Ă��������B";
                    if (focusFlg == true)
                    {
                        this.tNedit_CustomerCode.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_CustomerCode);
                        //-----ADD 2010/08/10----------<<<<<
                    }
                    return (false);
                }
                if (saveFlg == true)
                {
                    // �ۑ��O�`�F�b�N�̂�
                    int customerCode = this.tNedit_CustomerCode.GetInt();
                    //if (GetCustomerName(customerCode) == "")  // DEL 2009/06/29
                    if (!CheckCustomer(customerCode))   // ADD 2009/06/29
                    {
                        errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                        if (focusFlg == true)
                        {
                            this.tNedit_CustomerCode.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_CustomerCode);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        return (false);
                    }
                }
            }

            // ���Ӑ�|���O���[�v�R�[�h
            if (RateAcs.IsCustRateGrpSetting(rateSettingDivide))
            {
                // --- CHG 2009/01/13 --------------------------------------------------------------------->>>>>
                //if (this.CustRateGrpCode_tComboEditor.Value == null)
                //{
                //    errMsg = "���Ӑ�|���O���[�v��I�����Ă��������B";
                //    if (focusFlg == true)
                //    {
                //        this.CustRateGrpCode_tComboEditor.Focus();
                //    }
                //    return (false);
                //}
                if (this.tNedit_CustRateGrpCodeZero.DataText.Trim() == "")
                {
                    errMsg = "���Ӑ�|���O���[�v�R�[�h����͂��Ă��������B";
                    if (focusFlg == true)
                    {
                        this.tNedit_CustRateGrpCodeZero.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_CustRateGrpCodeZero);
                        //-----ADD 2010/08/10----------<<<<<
                    }
                    return (false);
                }
                if (saveFlg == true)
                {
                    // �ۑ��O�`�F�b�N�̂�
                    int custRateGrpCode = this.tNedit_CustRateGrpCodeZero.GetInt();
                    if (GetCustRateGrpName(custRateGrpCode) == "")
                    {
                        errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                        if (focusFlg == true)
                        {
                            this.tNedit_CustRateGrpCodeZero.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_CustRateGrpCodeZero);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        return (false);
                    }
                }
                // --- CHG 2009/01/13 ---------------------------------------------------------------------<<<<<
            }

            // �d����R�[�h
            if (RateAcs.IsSupplierSetting(rateSettingDivide))
            {
                if (this.tNedit_SupplierCd.GetInt() == 0)
                {
                    errMsg = "�d����R�[�h����͂��Ă��������B";
                    if (focusFlg == true)
                    {
                        this.tNedit_SupplierCd.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_SupplierCd);
                        //-----ADD 2010/08/10----------<<<<<
                    }
                    return (false);
                }
                if (saveFlg == true)
                {
                    // �ۑ��O�`�F�b�N�̂�
                    int supplierCode = this.tNedit_SupplierCd.GetInt();
                    //if (GetSupplierName(supplierCode) == "")  // DEL 2009/06/29
                    if (!CheckSupplier(supplierCode))   // ADD 2009/06/29
                    {
                        errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                        if (focusFlg == true)
                        {
                            this.tNedit_SupplierCd.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_SupplierCd);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        return (false);
                    }
                }
            }

            return (true);
        }

        /// <summary>
        /// ��ʏ��(���i�ݒ�)���̓`�F�b�N����
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="saveFlg">�ۑ��t���O(True:�ۑ��O�`�F�b�N  False:���������`�F�b�N)</param>
        /// <param name="focusFlg">�t�H�[�J�X�ݒ�t���O(True:�ݒ肷��@False:�ݒ肵�Ȃ�)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��(���i�ݒ�)�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private bool CheckGoodsCondition(out string errMsg, bool saveFlg, bool focusFlg)
        {
            errMsg = "";

            // �|���ݒ�敪
            string rateSettingDivide = this.RateSettingDivide_tEdit.DataText.Trim();

            // ���[�J�[�R�[�h
            if (RateAcs.IsMakerSetting(rateSettingDivide))
            {
                if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                {
                    errMsg = "���[�J�[�R�[�h����͂��Ă��������B";
                    if (focusFlg == true)
                    {
                        this.tNedit_GoodsMakerCd.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_GoodsMakerCd);
                        //-----ADD 2010/08/10----------<<<<<
                    }
                    return (false);
                }
                if (saveFlg == true)
                {
                    // �ۑ��O�`�F�b�N�̂�
                    int makerCode = this.tNedit_GoodsMakerCd.GetInt();
                    if (GetMakerName(makerCode) == "")
                    {
                        errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                        if (focusFlg == true)
                        {
                            this.tNedit_GoodsMakerCd.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_GoodsMakerCd);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        return (false);
                    }
                }
            }

            // �w��
            if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
            {
                if (this.GoodsRateRank_tEdit.DataText.Trim() == "")
                {
                    errMsg = "�w�ʂ���͂��Ă��������B";
                    if (focusFlg == true)
                    {
                        this.GoodsRateRank_tEdit.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(GoodsRateRank_tEdit);
                        //-----ADD 2010/08/10----------<<<<<
                    }
                    return (false);
                }
            }

            // ���i�|���f
            if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
            {
                if (this.tNedit_GoodsMGroup.GetInt() == 0)
                {
                    errMsg = "���i�|���f�R�[�h����͂��Ă��������B";
                    if (focusFlg == true)
                    {
                        this.tNedit_GoodsMGroup.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_GoodsMGroup);
                        //-----ADD 2010/08/10----------<<<<<
                    }
                    return (false);
                }
                if (saveFlg == true)
                {
                    // �ۑ��O�`�F�b�N�̂�
                    int goodsRateGrpCode = this.tNedit_GoodsMGroup.GetInt();
                    if (GetGoodsMGroupName(goodsRateGrpCode) == "")
                    {
                        errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                        if (focusFlg == true)
                        {
                            this.tNedit_GoodsMGroup.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_GoodsMGroup);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        return (false);
                    }
                }
            }

            // BL�O���[�v�R�[�h
            if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
            {
                if (this.tNedit_BLGloupCode.GetInt() == 0)
                {
                    errMsg = "��ٰ�ߺ��ނ���͂��Ă��������B";
                    if (focusFlg == true)
                    {
                        this.tNedit_BLGloupCode.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_BLGloupCode);
                        //-----ADD 2010/08/10----------<<<<<
                    }
                    return (false);
                }
                if (saveFlg == true)
                {
                    // �ۑ��O�`�F�b�N�̂�
                    int blGroupCode = this.tNedit_BLGloupCode.GetInt();
                    if (GetBLGroupName(blGroupCode) == "")
                    {
                        errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                        if (focusFlg == true)
                        {
                            this.tNedit_BLGloupCode.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_BLGloupCode);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        return (false);
                    }
                }
            }

            // BL�R�[�h
            if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
            {
                if (this.tNedit_BLGoodsCode.GetInt() == 0)
                {
                    errMsg = "BL���ނ���͂��Ă��������B";
                    if (focusFlg == true)
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tNedit_BLGoodsCode);
                        //-----ADD 2010/08/10----------<<<<<
                    }
                    return (false);
                }
                if (saveFlg == true)
                {
                    // �ۑ��O�`�F�b�N�̂�
                    int blGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                    if (GetBLGoodsName(blGoodsCode) == "")
                    {
                        errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                        if (focusFlg == true)
                        {
                            this.tNedit_BLGoodsCode.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tNedit_BLGoodsCode);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        return (false);
                    }
                }
            }

            // �i��
            if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
            {
                if (this.tEdit_GoodsNo.DataText.Trim() == "")
                {
                    errMsg = "�i�Ԃ���͂��Ă��������B";
                    if (focusFlg == true)
                    {
                        this.tEdit_GoodsNo.Focus();
                        //-----ADD 2010/08/10---------->>>>>
                        SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                        //-----ADD 2010/08/10----------<<<<<
                    }
                    return (false);
                }
                if (saveFlg == true)
                {
                    // �ۑ��O�`�F�b�N�̂�
                    GoodsUnitData goodsUnitData;
                    string goodsNoCode = this.tEdit_GoodsNo.DataText.Trim();
                    if (GetGoodsInfo(out goodsUnitData, goodsNoCode) != 0)
                    {
                        errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                        if (focusFlg == true)
                        {
                            this.tEdit_GoodsNo.Focus();
                            //-----ADD 2010/08/10---------->>>>>
                            SettingGuideButtonToolEnabled(tEdit_GoodsNo);
                            //-----ADD 2010/08/10----------<<<<<
                        }
                        return (false);
                    }
                }
            }
            return (true);
        }

        /// <summary>
        /// ��ʏ��(�O���b�h)���̓`�F�b�N����
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��(�O���b�h)�̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private bool CheckDetail(out string errMsg)
        {
            errMsg = "";

            // �P�����
            int unitPriceKindCode = int.Parse((string)this.UnitPriceKind_tComboEditor.Value);
            // �ݒ���@
            int unitPriceKindWay = (int)this.UnitPriceKindWay_tComboEditor.Value;
            // ����(�ȏ�)
            double lotCountAbove;
            // ����(�ȉ�)
            double lotCountBelow;

            bool checkFlg;

            for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
            {
                checkFlg = false;

                switch (unitPriceKindCode)
                {
                    // �����ݒ�
                    case 1:
                        if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTABOVE].Cells[columnIndex].Value == DBNull.Value) ||
                        ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTABOVE].Cells[columnIndex].Value == ""))
                        {
                            errMsg = "���ʔ͈͍��ڂɌ�肪����܂��B\n�Đݒ�����肢���܂��B";
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTABOVE].Cells[columnIndex].Activate();
                            return (false);
                        }

                        lotCountAbove = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTABOVE].Cells[columnIndex].Value);
                        lotCountBelow = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTBELOW].Cells[columnIndex].Value);

                        if (lotCountAbove == lotCountBelow)
                        {
                            return (true);
                        }

                        if (lotCountAbove > lotCountBelow)
                        {
                            errMsg = "���ʔ͈͍��ڂɌ�肪����܂��B\n�Đݒ�����肢���܂��B";
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTABOVE].Cells[columnIndex].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }

                        // ������
                        if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALERATEVAL].Cells[columnIndex].Text != "") &&
                            (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALERATEVAL].Cells[columnIndex].Text) != 0))
                        {
                            checkFlg = true;
                        }

                        // �����z
                        if (unitPriceKindWay == 0)
                        {
                            // �P�i�ݒ�̂Ƃ��̂݃`�F�b�N
                            if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALEPRICEFL].Cells[columnIndex].Text != "") &&
                                (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALEPRICEFL].Cells[columnIndex].Text) != 0))
                            {
                                checkFlg = true;
                            }
                        }

                        // ����UP��
                        if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTUPRATE].Cells[columnIndex].Text != "") && 
                            (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTUPRATE].Cells[columnIndex].Text) != 0))
                        {
                            checkFlg = true;
                        }

                        // �e���m�ۗ�
                        if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_GRSPROFITSECURERATE].Cells[columnIndex].Text != "") &&
                            (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_GRSPROFITSECURERATE].Cells[columnIndex].Text) != 0))
                        {
                            checkFlg = true;
                        }

                        if (checkFlg == false)
                        {
                            errMsg = "�����͂̍��ڂ����݂��邽�߁A�o�^�ł��܂���B\n�����ݒ�";
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALERATEVAL].Cells[columnIndex].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        break;
                    // �����ݒ�
                    case 2:
                        // �����ݒ��1���R�[�h�̂ݓo�^�\
                        if (columnIndex > 0)
                        {
                            return (true);
                        }

                        // �d����
                        if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTRATEVAL].Cells[columnIndex].Text != "") &&
                            (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTRATEVAL].Cells[columnIndex].Text) != 0))
                        {
                            checkFlg = true;
                        }

                        // �d������
                        if (unitPriceKindWay == 0)
                        {
                            // �P�i�ݒ�̂Ƃ��̂݃`�F�b�N
                            if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTPRICEFL].Cells[columnIndex].Text != "") &&
                                (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTPRICEFL].Cells[columnIndex].Text) != 0))
                            {
                                checkFlg = true;
                            }
                        }

                        if (checkFlg == false)
                        {
                            errMsg = "�����͂̍��ڂ����݂��邽�߁A�o�^�ł��܂���B\n�����ݒ�";
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTRATEVAL].Cells[columnIndex].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        break;
                    // ���i�ݒ�
                    case 3:
                        // ���i�ݒ��1���R�[�h�̂ݓo�^�\
                        if (columnIndex > 0)
                        {
                            return (true);
                        }

                        checkFlg = true;

                        int rowIndex = ROWINDEX_UNPRCFRACPROCUNIT;

                        // ���[�U�[�艿
                        if (unitPriceKindWay == 0)
                        {
                            // �P�i�ݒ�̂Ƃ��̂݃`�F�b�N
                            // DEL 2009/06/12 ------>>>
                            //if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_USERPRICEFL].Cells[columnIndex].Text == "") ||
                            //    (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_USERPRICEFL].Cells[columnIndex].Text) == 0))
                            // DEL 2009/06/12 ------<<<
                            // ADD 2009/06/12 ------>>>
                            if (((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_USERPRICEFL].Cells[columnIndex].Text == "") ||
                                 (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_USERPRICEFL].Cells[columnIndex].Text) == 0)) &&
                                ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_PRICEUPRATE].Cells[columnIndex].Text == "") ||
                                 (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_PRICEUPRATE].Cells[columnIndex].Text) == 0)))
                            // ADD 2009/06/12 ------<<<
                            {
                                // ���[�U�[���i�Ɖ��iUP��������������
                                checkFlg = false;
                                rowIndex = ROWINDEX_USERPRICEFL;
                            }
                        }
                        else
                        {
                            // ���iUP��
                            if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_PRICEUPRATE].Cells[columnIndex].Text == "") ||
                                (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_PRICEUPRATE].Cells[columnIndex].Text) == 0))
                            {
                                checkFlg = false;
                                rowIndex = ROWINDEX_PRICEUPRATE;
                            }
                        }

                        if (checkFlg == true)
                        {
                            // �[�������P��
                            if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Value == DBNull.Value) ||
                                ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Value == "") ||
                                (double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Value) == 0))
                            {
                                checkFlg = false;
                                rowIndex = ROWINDEX_UNPRCFRACPROCUNIT;
                            }
                        }

                        if (checkFlg == true)
                        {
                            // �[�������敪
                            if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[columnIndex].Value == DBNull.Value) ||
                                (this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[columnIndex].Text == ""))
                            {
                                checkFlg = false;
                                rowIndex = ROWINDEX_UNPRCFRACPROCDIV;
                            }
                        }

                        if (checkFlg == false)
                        {
                            errMsg = "�����͂̍��ڂ����݂��邽�߁A�o�^�ł��܂���B\n���i�ݒ�";
                            this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        break;
                }
            }
            return (true);
        }

        /// <summary>
        /// ��ʏ��ύX�`�F�b�N����
        /// </summary>
        /// <returns>�X�e�[�^�X(True:�ύX�Ȃ��@False:�ύX����)</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂪕ύX����Ă��邩�ǂ����`�F�b�N���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private bool CompareInputScreen()
        {
            // �P�����
            string unitPriceKind = (string)this.UnitPriceKind_tComboEditor.Value;

            // �ۑ������擾����
            int saveRecordCount = GetSaveRecordCount(unitPriceKind);

            if (saveRecordCount != this._rateListClone.Count)
            {
                return (false);
            }

            // �V�K���[�h�̏ꍇ
            if (saveRecordCount == 0)
            {
                Rate rate = new Rate();
                rate.EnterpriseCode = this._enterpriseCode;

                Rate compareRate = rate.Clone();

                // ��ʏ��擾(�|���ݒ�)
                RateConditionToRate(ref compareRate);
                // ��ʏ��擾(�����ݒ�)
                CustomerConditionToRate(ref compareRate);
                // ��ʏ��擾(���i�ݒ�)
                GoodsConditionToRate(ref compareRate);

                if (!(compareRate.Equals(rate)))
                {
                    return (false);
                }
                else
                {
                    return (true);
                }
            }

            for (int columnIndex = 0; columnIndex < saveRecordCount; columnIndex++)
            {
                Rate rate = this._rateListClone[columnIndex];
                Rate compareRate = rate.Clone();

                // ��ʏ��擾
                ScreenToRate(ref rate, columnIndex);

                if (!(compareRate.Equals(rate)))
                {
                    // ADD 2008/10/29 �s��Ή�[7172] ---------->>>>>
                    this._rateListClone[columnIndex] = compareRate;
                    // ADD 2008/10/29 �s��Ή�[7172] ----------<<<<<
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// �|���ݒ�敪���݃`�F�b�N����
        /// </summary>
        /// <param name="clearFlg">�|���ݒ�敪�N���A�t���O(True:�N���A Flase:��N���A)</param>
        /// <remarks>
        /// <br>Note       : �|���ݒ�敪�����݂��邩�ǂ����`�F�b�N���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void CheckExistRateSettingDivide(bool clearFlg)
        {
            int status;
            RateProtyMng rateProtyMng;

            // �|���ݒ�敪
            if (RateSettingDivide_tEdit.DataText.Trim() == "")
            {
                return;
            }
            string rateSettingDivCode = this.RateSettingDivide_tEdit.DataText.Trim();

            // �|���}�X�^�擾
            status = GetRateProtyMng(out rateProtyMng, rateSettingDivCode);
            if (status == 0)
            {
                // ���i�ݒ�敪�擾
                this.RateMngGoodsCd_tEdit.DataText = rateProtyMng.RateMngGoodsCd;
                this.RateMngGoodsNm_tEdit.DataText = rateProtyMng.RateMngGoodsNm.Trim();

                // �����ݒ�敪�擾
                this.RateMngCustCd_tEdit.DataText = rateProtyMng.RateMngCustCd;
                this.RateMngCustNm_tEdit.DataText = rateProtyMng.RateMngCustNm.Trim();

                // �D�揇��
                this.tNedit_RatePriorityOrder.SetInt(rateProtyMng.RatePriorityOrder);

                // �O���b�h������
                ClearGrid(rateProtyMng.UnitPriceKind.ToString());
            }
            else
            {
                // �|���ݒ�敪������
                if (clearFlg)
                {
                    this.RateSettingDivide_tEdit.Clear();
                    this._prevRateSettingDivide = "";
                }

                // ���i�ݒ�敪������
                this.RateMngGoodsCd_tEdit.Clear();
                this.RateMngGoodsNm_tEdit.Clear();

                // �����ݒ�敪������
                this.RateMngCustCd_tEdit.Clear();
                this.RateMngCustNm_tEdit.Clear();

                // �D�揇�ʏ�����
                this.tNedit_RatePriorityOrder.Clear();

                // �O���b�h������
                ClearGrid("");
            }

            // ��������(�����)�N���A
            ClearCustomerCondition();

            // ��������(���i)�N���A
            ClearGoodsCondition();

            // �����R���g���[��(�����)���͋�����
            SetCustomerConditionEnabled();

            // �����R���g���[��(���i)���͋�����
            SetGoodsConditionEnabled();

            // �O���b�h���͋�����
            SetGridEnabled();
        }

        #endregion �`�F�b�N����

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �r��������s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            string errMsg = "";

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        errMsg = "���ɑ��[�����X�V����Ă��܂��B";
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        errMsg = "���ɑ��[�����폜����Ă��܂��B";
                        break;
                    }
            }

            ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                           errMsg,
                           status,
                           MessageBoxButtons.OK,
                           MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// �ۑ������擾����
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <returns>�ۑ�����</returns>
        /// <remarks>
        /// <br>Note       : �ۑ��������擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private int GetSaveRecordCount(string unitPriceKind)
        {
            int saveRecordCount = 0;

            switch (unitPriceKind)
            {
                // �����ݒ�
                case "1":
                    for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
                    {
                        if ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTABOVE].Cells[columnIndex].Value == "" &&
                            (string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTBELOW].Cells[columnIndex].Value == "")
                        {
                            return saveRecordCount;
                        }

                        double lotCountAbove;   // ����(�ȏ�)
                        double lotCountBelow;   // ����(�ȉ�)

                        lotCountAbove = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTABOVE].Cells[columnIndex].Value);
                        lotCountBelow = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTBELOW].Cells[columnIndex].Value);

                        // DEL 2008/10/29 �s��Ή�[7170] ---------->>>>>
                        //if (lotCountAbove != lotCountBelow)
                        //{
                        //    saveRecordCount++;
                        //}
                        //else
                        //{
                        //    return saveRecordCount;
                        //}
                        // DEL 2008/10/29 �s��Ή�[7170] ----------<<<<<

                        // ADD 2008/10/29 �s��Ή�[7170] ---------->>>>>
                        if (lotCountAbove != double.Parse(LOTCOUNT_MAX) ||
                            lotCountBelow != double.Parse(LOTCOUNT_MAX))
                        {
                            saveRecordCount++;
                        }
                        else{
                            return saveRecordCount;
                        }
                        // ADD 2008/10/29 �s��Ή�[7170] ----------<<<<<
                        
                    }
                    break;
                // �����ݒ�A���i�ݒ�
                case "2":
                case "3":
                    saveRecordCount = 1;
                    break;
            }

            return saveRecordCount;
        }

        #region ��ʏ��擾����

        /// <summary>
        /// ��ʏ��擾����
        /// </summary>
        /// <param name="rate">�|���}�X�^�I�u�W�F�N�g</param>
        /// <param name="columnIndex">��C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ��ʏ����擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void ScreenToRate(ref Rate rate, int columnIndex)
        {
            // ��ʏ��(�|���ݒ�)�擾
            RateConditionToRate(ref rate);

            // ��ʏ��(�����ݒ�)�擾
            CustomerConditionToRate(ref rate);

            // ��ʏ��(���i�ݒ�)�擾
            GoodsConditionToRate(ref rate);

            // ��ʏ��(�O���b�h)�擾
            DetailToRate(ref rate, columnIndex);
        }

        /// <summary>
        /// ��ʏ��(�|���ݒ�)�擾����
        /// </summary>
        /// <param name="rate">�|���}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ��(�|���ݒ�)���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void RateConditionToRate(ref Rate rate)
        {
            // ��ƃR�[�h
            rate.EnterpriseCode = this._enterpriseCode;

            // ���_�R�[�h
            rate.SectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();

            // �P���|���ݒ�敪(�P����ށ{�|���ݒ�敪)
            if (this.UnitPriceKind_tComboEditor.Value != null &&
                this.RateSettingDivide_tEdit.DataText != "")
            {
                rate.UnitRateSetDivCd = (string)this.UnitPriceKind_tComboEditor.Value + this.RateSettingDivide_tEdit.DataText;
            }

            // �P�����
            rate.UnitPriceKind = (string)this.UnitPriceKind_tComboEditor.Value;

            // �|���ݒ�敪
            rate.RateSettingDivide = this.RateSettingDivide_tEdit.DataText;

            // �|���ݒ�敪�i���i�j
            rate.RateMngGoodsCd = this.RateMngGoodsCd_tEdit.DataText;

            // �|���ݒ薼�́i���i�j
            rate.RateMngGoodsNm = this.RateMngGoodsNm_tEdit.DataText;

            // �|���ݒ�敪�i���Ӑ�j
            rate.RateMngCustCd = this.RateMngCustCd_tEdit.DataText;

            // �|���ݒ薼�́i���Ӑ�j
            rate.RateMngCustNm = this.RateMngCustNm_tEdit.DataText;
        }

        /// <summary>
        /// ��ʏ��(�����ݒ�)�擾����
        /// </summary>
        /// <param name="rate">�|���}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ��(�����ݒ�)���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void CustomerConditionToRate(ref Rate rate)
        {
            // ���Ӑ�R�[�h
            rate.CustomerCode = this.tNedit_CustomerCode.GetInt();

            // ���Ӑ�|���O���[�v�R�[�h
            // --- CHG 2009/01/13 --------------------------------------------------------------------->>>>>
            //if (this.CustRateGrpCode_tComboEditor.Value != null)
            //{
            //    rate.CustRateGrpCode = (int)this.CustRateGrpCode_tComboEditor.Value;
            //}
            //else
            //{
            //    rate.CustRateGrpCode = 0;
            //}
            rate.CustRateGrpCode = this.tNedit_CustRateGrpCodeZero.GetInt();
            // --- CHG 2009/01/13 ---------------------------------------------------------------------<<<<<

            // �d����R�[�h
            rate.SupplierCd = this.tNedit_SupplierCd.GetInt();
        }

        /// <summary>
        /// ��ʏ��(���i�ݒ�)�擾����
        /// </summary>
        /// <param name="rate">�|���}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ��ʏ��(���i�ݒ�)���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void GoodsConditionToRate(ref Rate rate)
        {
            // ���i���[�J�[�R�[�h
            rate.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();

            // �w��
            rate.GoodsRateRank = this.GoodsRateRank_tEdit.DataText;

            // ���i�|���f�R�[�h
            rate.GoodsRateGrpCode = this.tNedit_GoodsMGroup.GetInt();

            // BL�O���[�v�R�[�h
            rate.BLGroupCode = this.tNedit_BLGloupCode.GetInt();

            // BL���i�R�[�h
            rate.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();

            // ���i�ԍ�
            rate.GoodsNo = this.tEdit_GoodsNo.DataText;
        }

        /// <summary>
        /// ��ʏ��(�O���b�h)�擾����
        /// </summary>
        /// <param name="rate">�|���}�X�^�I�u�W�F�N�g</param>
        /// <param name="columnIndex">��C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : ��ʏ��(�O���b�h)���擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void DetailToRate(ref Rate rate, int columnIndex)
        {
            // ���b�g��
            rate.LotCount = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTBELOW].Cells[columnIndex].Text);

            switch ((string)this.UnitPriceKind_tComboEditor.Value)
            {
                // �����ݒ�
                case "1":
                    // ���i(����)
                    if ((int)this.UnitPriceKindWay_tComboEditor.Value == 0)
                    {
                        // �P�i�ݒ�
                        if ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALEPRICEFL].Cells[columnIndex].Text == "")
                        {
                            rate.PriceFl = 0;
                        }
                        else
                        {
                            rate.PriceFl = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALEPRICEFL].Cells[columnIndex].Text);
                        }
                    }

                    // �|��
                    if ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALERATEVAL].Cells[columnIndex].Text == "")
                    {
                        rate.RateVal = 0;
                    }
                    else
                    {
                        rate.RateVal = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALERATEVAL].Cells[columnIndex].Text);
                    }

                    // UP��
                    if ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTUPRATE].Cells[columnIndex].Text == "")
                    {

                    }
                    else
                    {
                        rate.UpRate = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTUPRATE].Cells[columnIndex].Text);
                    }

                    // �e���m�ۗ�
                    if ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_GRSPROFITSECURERATE].Cells[columnIndex].Text == "")
                    {
                        rate.GrsProfitSecureRate = 0;
                    }
                    else
                    {
                        rate.GrsProfitSecureRate = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_GRSPROFITSECURERATE].Cells[columnIndex].Text);
                    }

                    break;
                // �����ݒ�
                case "2":
                    // ���i(����)
                    if ((int)this.UnitPriceKindWay_tComboEditor.Value == 0)
                    {
                        // �P�i�ݒ�
                        if ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTPRICEFL].Cells[columnIndex].Text == "")
                        {
                            rate.PriceFl = 0;
                        }
                        else
                        {
                            rate.PriceFl = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTPRICEFL].Cells[columnIndex].Text);
                        }
                    }

                    // �|��
                    if ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTRATEVAL].Cells[columnIndex].Text == "")
                    {
                        rate.RateVal = 0;
                    }
                    else
                    {
                        rate.RateVal = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTRATEVAL].Cells[columnIndex].Text);
                    }

                    break;
                // ���i�ݒ�
                case "3":
                    // ���i(����)
                    if ((int)this.UnitPriceKindWay_tComboEditor.Value == 0)
                    {
                        // �P�i�ݒ�
                        if ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_USERPRICEFL].Cells[columnIndex].Text == "")
                        {
                            rate.PriceFl = 0;
                        }
                        else
                        {
                            rate.PriceFl = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_USERPRICEFL].Cells[columnIndex].Text);
                        }
                    }

                    // UP��
                    if ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_PRICEUPRATE].Cells[columnIndex].Text == "")
                    {
                        rate.UpRate = 0;
                    }
                    else
                    {
                        rate.UpRate = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_PRICEUPRATE].Cells[columnIndex].Text);
                    }

                    // �[�������P��
                    rate.UnPrcFracProcUnit = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Text);

                    // �[�������敪
                    string unPrcFracProcDivName = this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[columnIndex].Text;
                    switch (unPrcFracProcDivName)
                    {
                        case UNPRCFRACPROCDIV_1:
                            rate.UnPrcFracProcDiv = 1;
                            break;
                        case UNPRCFRACPROCDIV_2:
                            rate.UnPrcFracProcDiv = 2;
                            break;
                        case UNPRCFRACPROCDIV_3:
                            rate.UnPrcFracProcDiv = 3;
                            break;
                    }

                    break;
            }
        }

        #endregion ��ʏ��擾����

        #region ��ʓW�J����

        /// <summary>
        /// �|���}�X�^��ʓW�J����
        /// </summary>
        /// <param name="rateList">�|���}�X�^���X�g</param>
        /// <remarks>
        /// <br>Note       : �|���}�X�^����ʂɓW�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void RateToScreen(List<Rate> rateList)
        {
            // ADD �� 2014/03/20 ----------------------------------------------------->>>>>
            // �X�V���̐ݒ�
            if (rateList[0].UpdateDateTime != DateTime.MinValue)
            {
                this.UpdateDateTime_tDateEdit.SetDateTime(rateList[0].UpdateDateTime);
            }
            else
            {
                this.UpdateDateTime_tDateEdit.Clear();
            }
            // ADD �� 2014/03/20 ----------------------------------------------------->>>>>
            // ��ʓW�J(�|���ݒ�)����
            RateToRateCondition(rateList[0]);

            // ��ʓW�J(�����ݒ�)����
            RateToCustomerCondition(rateList[0]);

            // ��ʓW�J(���i�ݒ�)����
            RateToGoodsCondition(rateList[0]);

            // ��ʓW�J(�O���b�h)����
            RateToDetail(rateList);
        }

        /// <summary>
        /// �|���}�X�^��ʓW�J(�|���ݒ�)����
        /// </summary>
        /// <param name="rate">�|���}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�����(�|���ݒ�)�ɓW�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// <br></br>
        /// <br>Update Note: 2009/12/15 ���M</br>
        /// <br>             �ێ�˗��C�Ή�</br>
        /// </remarks>
        private void RateToRateCondition(Rate rate)
        {
            // ���_�R�[�h
            this.tEdit_SectionCodeAllowZero.DataText = rate.SectionCode.Trim();

            // -------ADD 2009/12/15------->>>>>
            this._prevSectionCode = rate.SectionCode.Trim();
            this._prevRateSettingDivide = rate.RateSettingDivide;
            // -------ADD 2009/12/15-------<<<<<

            // ���_����
            this.SectionCodeNm_tEdit.DataText = GetSectionName(rate.SectionCode.Trim());

            // �P�����
            this.UnitPriceKind_tComboEditor.Value = rate.UnitPriceKind;

            // �ݒ���@
            if (rate.RateMngGoodsCd.Trim() == "A")
            {
                // �P�i�ݒ�
                this.UnitPriceKindWay_tComboEditor.Value = 0;
            }
            else
            {
                // �O���[�v�ݒ�
                this.UnitPriceKindWay_tComboEditor.Value = 1;
                
            }

            // �|���ݒ�敪
            this.RateSettingDivide_tEdit.DataText = rate.RateSettingDivide;

            // �D�揇��
            RateProtyMng rateProtyMng = new RateProtyMng();
            int status = GetRateProtyMng(out rateProtyMng, rate.RateSettingDivide);
            if (status == 0)
            {
                this.tNedit_RatePriorityOrder.SetInt(rateProtyMng.RatePriorityOrder);
            }

            // ���i�ݒ�敪
            this.RateMngGoodsCd_tEdit.DataText = rate.RateMngGoodsCd.Trim();

            // ���i�ݒ�敪����
            this.RateMngGoodsNm_tEdit.DataText = rate.RateMngGoodsNm.Trim();

            // �����ݒ�敪
            this.RateMngCustCd_tEdit.DataText = rate.RateMngCustCd.Trim();

            // �����ݒ�敪����
            this.RateMngCustNm_tEdit.DataText = rate.RateMngCustNm.Trim();
        }

        /// <summary>
        /// �|���}�X�^��ʓW�J(�����ݒ�)����
        /// </summary>
        /// <param name="rate">�|���}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�����(�����ݒ�)�ɓW�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void RateToCustomerCondition(Rate rate)
        {
            if (rate.CustomerCode == 0)
            {
                // ���Ӑ�R�[�h
                this.tNedit_CustomerCode.DataText = "";

                // ���Ӑ於��
                this.CustomerCodeNm_tEdit.DataText = "";
            }
            else
            {
                // ���Ӑ�R�[�h
                this.tNedit_CustomerCode.SetInt(rate.CustomerCode);

                // ���Ӑ於��
                this.CustomerCodeNm_tEdit.DataText = GetCustomerName(rate.CustomerCode);
            }

            // -------ADD 2009/12/15------->>>>>
            this._prevCustomerCode = rate.CustomerCode;
            // -------ADD 2009/12/15-------<<<<<

            // ���Ӑ�|���O���[�v
            // --- CHG 2009/01/13 --------------------------------------------------------------------->>>>>
            //this.CustRateGrpCode_tComboEditor.Value = rate.CustRateGrpCode;
            if (RateAcs.IsCustRateGrpSetting(rate.RateSettingDivide.Trim()))
            {
                this.tNedit_CustRateGrpCodeZero.DataText = rate.CustRateGrpCode.ToString("0000");
                this.tEdit_CustRateGrpName.DataText = GetCustRateGrpName(rate.CustRateGrpCode);
            }
            // --- CHG 2009/01/13 ---------------------------------------------------------------------<<<<<

            // -------ADD 2009/12/15------->>>>>
            this._prevCustRateGrpCode = rate.CustRateGrpCode;
            // -------ADD 2009/12/15-------<<<<<

            if (rate.SupplierCd == 0)
            {
                // �d����R�[�h
                this.tNedit_SupplierCd.DataText = "";

                // �d���於��
                this.SupplierCdNm_tEdit.DataText = "";
            }
            else
            {
                // �d����R�[�h
                this.tNedit_SupplierCd.SetInt(rate.SupplierCd);

                // �d���於��
                this.SupplierCdNm_tEdit.DataText = GetSupplierName(rate.SupplierCd);
            }

            // -------ADD 2009/12/15------->>>>>
            this._prevSupplierCode = rate.SupplierCd;
            // -------ADD 2009/12/15-------<<<<<
        }

        /// <summary>
        /// �|���}�X�^��ʓW�J(���i�ݒ�)����
        /// </summary>
        /// <param name="rate">�|���}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�����(���i�ݒ�)�ɓW�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void RateToGoodsCondition(Rate rate)
        {
            if (rate.GoodsMakerCd == 0)
            {
                // ���[�J�[�R�[�h
                this.tNedit_GoodsMakerCd.DataText = "";

                // ���[�J�[����
                this.MakerName_tEdit.DataText = "";
            }
            else
            {
                // ���[�J�[�R�[�h
                this.tNedit_GoodsMakerCd.SetInt(rate.GoodsMakerCd);

                // ���[�J�[����
                this.MakerName_tEdit.DataText = GetMakerName(rate.GoodsMakerCd);
            }

            // -------ADD 2009/12/15------->>>>>
            this._prevMakerCode = rate.GoodsMakerCd;
            // -------ADD 2009/12/15-------<<<<<

            // �w��
            this.GoodsRateRank_tEdit.DataText = rate.GoodsRateRank.Trim();

            // -------ADD 2009/12/15------->>>>>
            this._prevGoodsRateRank = rate.GoodsRateRank.Trim();
            // -------ADD 2009/12/15-------<<<<<

            if (rate.GoodsRateGrpCode == 0)
            {
                // ���i�|���f�R�[�h
                this.tNedit_GoodsMGroup.DataText = "";

                // ���i�|���f����
                this.GoodsRateGrpName_tEdit.DataText = "";
            }
            else
            {
                // ���i�|���f�R�[�h
                this.tNedit_GoodsMGroup.SetInt(rate.GoodsRateGrpCode);

                // ���i�|���f����
                this.GoodsRateGrpName_tEdit.DataText = GetGoodsMGroupName(rate.GoodsRateGrpCode);
            }

            // -------ADD 2009/12/15------->>>>>
            this._prevGoodsRateGrpCode = rate.GoodsRateGrpCode;
            // -------ADD 2009/12/15-------<<<<<

            if (rate.BLGroupCode == 0)
            {
                // BL�O���[�v�R�[�h
                this.tNedit_BLGloupCode.DataText = "";

                // BL�O���[�v����
                this.BLGroupName_tEdit.DataText = "";
            }
            else
            {
                // BL�O���[�v�R�[�h
                this.tNedit_BLGloupCode.SetInt(rate.BLGroupCode);

                // BL�O���[�v����
                this.BLGroupName_tEdit.DataText = GetBLGroupName(rate.BLGroupCode);
            }

            // -------ADD 2009/12/15------->>>>>
            this._prevBLGroupCode = rate.BLGroupCode;
            // -------ADD 2009/12/15-------<<<<<

            if (rate.BLGoodsCode == 0)
            {
                // BL�R�[�h
                this.tNedit_BLGoodsCode.DataText = "";

                // BL�R�[�h����
                this.BLGoodsName_tEdit.DataText = "";
            }
            else
            {
                // BL�R�[�h
                this.tNedit_BLGoodsCode.SetInt(rate.BLGoodsCode);

                // BL�R�[�h����
                this.BLGoodsName_tEdit.DataText = GetBLGoodsName(rate.BLGoodsCode);
            }

            // -------ADD 2009/12/15------->>>>>
            this._prevBLGoodsCode = rate.BLGoodsCode;
            // -------ADD 2009/12/15-------<<<<<

            if (rate.GoodsNo.Trim() == "")
            {
                // �i��
                this.tEdit_GoodsNo.DataText = "";

                // �i�Ԗ���
                this.tEdit_GoodsName.DataText = "";
            }
            else
            {
                // �i��
                this.tEdit_GoodsNo.DataText = rate.GoodsNo.Trim();

                // �i�Ԗ���
                GoodsUnitData goodsUnitData;
                int status = GetGoodsInfo(out goodsUnitData, rate.GoodsNo);
                if (status == 0)
                {
                    this.tEdit_GoodsName.DataText = goodsUnitData.GoodsNameKana.Trim();

                    // �艿
                    this.tNedit_Price.SetValue(GetPrice(goodsUnitData.GoodsPriceList));
                }
                else
                {
                    if (status != -1)
                    {
                        this.tEdit_GoodsName.Clear();
                    }
                }
            }

            // -------ADD 2009/12/15------->>>>>
            this._prevGoodsNo = rate.GoodsNo;
            // -------ADD 2009/12/15-------<<<<<
        }

        /// <summary>
        /// �|���}�X�^��ʓW�J(�O���b�h)����
        /// </summary>
        /// <param name="rateList">�|���}�X�^���X�g</param>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�����(�O���b�h)�ɓW�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void RateToDetail(List<Rate> rateList)
        {
            for (int columnIndex = 0; columnIndex < rateList.Count; columnIndex++)
            {
                // �P�����
                string unitPriceKindCode = rateList[columnIndex].UnitPriceKind;
                // �|���ݒ�敪
                string rateSettingDivide = rateList[columnIndex].RateSettingDivide;
                
                switch (unitPriceKindCode)
                {
                    // �����ݒ�
                    case "1":

                        // ����(�ȏ�)
                        if (columnIndex == 0)
                        {
                            // ����(�ȏ�)1�͌Œ�
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTABOVE].Cells[columnIndex].Value = LOTCOUNT_MIN;
                        }
                        else
                        {
                            // ����(�ȏ�)2�`10
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTABOVE].Cells[columnIndex].Value = (rateList[columnIndex - 1].LotCount + 0.01).ToString(FORMAT_DECIMAL);
                        }

                        // ����(�ȉ�)
                        this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTBELOW].Cells[columnIndex].Value = rateList[columnIndex].LotCount.ToString(FORMAT_DECIMAL);

                        // ������
                        if (rateList[columnIndex].RateVal != 0)
                        {
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALERATEVAL].Cells[columnIndex].Value = rateList[columnIndex].RateVal.ToString(FORMAT_DECIMAL);
                        }

                        // �����z
                        if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                        {
                            // �P�i�ݒ�̂Ƃ��̂ݐݒ�
                            if (rateList[columnIndex].PriceFl != 0)
                            {
                                this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALEPRICEFL].Cells[columnIndex].Value = rateList[columnIndex].PriceFl.ToString(FORMAT_DECIMAL);
                            }
                        }

                        // ����UP��
                        if (rateList[columnIndex].UpRate != 0)
                        {
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTUPRATE].Cells[columnIndex].Value = rateList[columnIndex].UpRate.ToString(FORMAT_DECIMAL);
                        }

                        // �e���m�ۗ�
                        if (rateList[columnIndex].GrsProfitSecureRate != 0)
                        {
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_GRSPROFITSECURERATE].Cells[columnIndex].Value = rateList[columnIndex].GrsProfitSecureRate.ToString(FORMAT_DECIMAL);
                        }

                        break;
                    // �����ݒ�
                    case "2":

                        // �d����
                        if (rateList[columnIndex].RateVal != 0)
                        {
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTRATEVAL].Cells[columnIndex].Value = rateList[columnIndex].RateVal.ToString(FORMAT_DECIMAL);
                        }

                        // �d������
                        if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                        {
                            // �P�i�ݒ�̂Ƃ��̂ݐݒ�
                            if (rateList[columnIndex].PriceFl != 0)
                            {
                                this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTPRICEFL].Cells[columnIndex].Value = rateList[columnIndex].PriceFl.ToString(FORMAT_DECIMAL);
                            }
                        }

                        break;
                    // ���i�ݒ�
                    case "3":

                        // ���iUP��
                        if (rateList[columnIndex].UpRate != 0)
                        {
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_PRICEUPRATE].Cells[columnIndex].Value = rateList[columnIndex].UpRate.ToString(FORMAT_DECIMAL);
                        }

                        // ���[�U�[�艿
                        if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                        {
                            // �P�i�ݒ�̂Ƃ��̂ݐݒ�
                            if (rateList[columnIndex].PriceFl != 0)
                            {
                                this.Detail_uGrid.Rows[ROWINDEX_USERPRICEFL].Cells[columnIndex].Value = rateList[columnIndex].PriceFl.ToString(FORMAT_NUM);
                            }
                        }

                        // �[�������P��
                        this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Value = rateList[columnIndex].UnPrcFracProcUnit.ToString(FORMAT_DECIMAL);

                        // �[�������敪
                        switch (rateList[columnIndex].UnPrcFracProcDiv)
                        {
                            case 1:
                                this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[columnIndex].Value = UNPRCFRACPROCDIV_1;
                                break;
                            case 2:
                                this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[columnIndex].Value = UNPRCFRACPROCDIV_2;
                                break;
                            case 3:
                                this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[columnIndex].Value = UNPRCFRACPROCDIV_3;
                                break;
                        }

                        break;
                }
            }
        }

        #endregion ��ʓW�J����

        #region ������ҏW����

        /// <summary>
        /// �J���}�E�s���I�h�폜����
        /// </summary>
        /// <param name="targetText">�J���}�E�s���I�h�폜�O�e�L�X�g</param>
        /// <param name="retText">�J���}�E�s���I�h�폜�ς݃e�L�X�g</param>
        /// <param name="periodDelFlg">�s���I�h�폜�t���O(True:�J���}�E�s���I�h�폜  False:�J���}�폜)</param>
        /// <remarks>
        /// <br>Note		: �Ώۂ̃e�L�X�g����J���}�E�s���I�h���폜���܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// </remarks>
        private void RemoveCommaPeriod(string targetText, out string retText, bool periodDelFlg)
        {
            retText = "";

            // �Z���l�ҏW�p�ɃJ���}�E�s���I�h�폜
            for (int i = targetText.Length - 1; i >= 0; i--)
            {
                // �J���}�E�s���I�h�폜
                if (periodDelFlg == true)
                {
                    if ((targetText[i].ToString() == ",") || (targetText[i].ToString() == "."))
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
                // �J���}�̂ݍ폜
                else
                {
                    if (targetText[i].ToString() == ",")
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
            }

            retText = targetText;
        }

        /// <summary>
        /// �����_�擾����
        /// </summary>
        /// <param name="targetText">�`�F�b�N�Ώۃe�L�X�g</param>
        /// <param name="retText">���������e�L�X�g</param>
        /// <remarks>
        /// <br>Note		: �Ώۂ̃e�L�X�g���珬�������݂̂�Ԃ��܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// </remarks>
        private void GetDecimal(string targetText, out string retText)
        {
            retText = "";

            for (int i = targetText.IndexOf(".") + 1; i < targetText.Length; i++)
            {
                retText += targetText[i].ToString();
            }
        }

        #endregion ������ҏW����

        //-----ADD 2010/08/10---------->>>>>
        /// <summary>
        /// �K�C�h�{�^���c�[���L�������ݒ菈��
        /// </summary>
        /// <param name="nextControl">���̃R���g���[��</param>
        private void SettingGuideButtonToolEnabled(Control nextControl)
        {
            if (nextControl == null) return;

            Control targetControl = nextControl;
            if (nextControl.Parent != null)
            {
                if ((nextControl.Parent is Broadleaf.Library.Windows.Forms.TNedit) ||
                        (nextControl.Parent is Broadleaf.Library.Windows.Forms.TEdit))
                {
                    targetControl = nextControl.Parent;
                }
            }

            // ���ו��Ƀt�H�[�J�X�����鎞�͖��׉�ʂɏ]���Đݒ肷��
            if (this._guideEnableControlDictionary.ContainsKey(targetControl.Name))
            {
                this._isGuide = true;
            }
            else
            {
                this._isGuide = false;
            }
            ParentToolbarRateSettingEvent(this);
        }

        /// <summary>
        /// �K�C�h�N������
        /// </summary>
        private void ExecuteGuide()
        {
            //-----------------------------------------------------------------------------
            // ���_
            //-----------------------------------------------------------------------------
            if (this.tEdit_SectionCodeAllowZero.Focused)
            {
                this.SectionGuide_Button_Click(this.SectionGuide_Button, new EventArgs());
            }
            //-----------------------------------------------------------------------------
            // �|���ݒ�敪
            //-----------------------------------------------------------------------------
            else if (this.RateSettingDivide_tEdit.Focused)
            {
                this.RateSettingDivideGuide_Button_Click(this.RateSettingDivideGuide_Button, new EventArgs());
            }
            //-----------------------------------------------------------------------------
            // ���Ӑ�R�[�h
            //-----------------------------------------------------------------------------
            else if (this.tNedit_CustomerCode.Focused)
            {
                this.CustomerGuide_Button_Click(this.CustomerGuide_Button, new EventArgs());
            }
            //-----------------------------------------------------------------------------
            // ���Ӑ�|���O���[�v
            //-----------------------------------------------------------------------------
            else if (this.tNedit_CustRateGrpCodeZero.Focused)
            {
                this.CustRateGrpGuide_Button_Click(this.CustRateGrpGuide_Button, new EventArgs());
            }
            //-----------------------------------------------------------------------------
            // �d����R�[�h
            //-----------------------------------------------------------------------------
            else if (this.tNedit_SupplierCd.Focused)
            {
                this.SupplierGuide_Button_Click(this.SupplierGuide_Button, new EventArgs());
            }
            //-----------------------------------------------------------------------------
            // ���[�J�[
            //-----------------------------------------------------------------------------
            else if (this.tNedit_GoodsMakerCd.Focused)
            {
                this.MakerGuide_Button_Click(this.MakerGuide_Button, new EventArgs());
            }
            //-----------------------------------------------------------------------------
            // ���i�|���f
            //-----------------------------------------------------------------------------
            else if (this.tNedit_GoodsMGroup.Focused)
            {
                this.GoodsRateGrpGuide_Button_Click(this.GoodsRateGrpGuide_Button, new EventArgs());
            }
            //-----------------------------------------------------------------------------
            // �O���[�v�R�[�h
            //-----------------------------------------------------------------------------
            else if (this.tNedit_BLGloupCode.Focused)
            {
                this.BLGroupGuide_Button_Click(this.BLGroupGuide_Button, new EventArgs());
            }
            //-----------------------------------------------------------------------------
            // �a�k�R�[�h
            //-----------------------------------------------------------------------------
            else if (this.tNedit_BLGoodsCode.Focused)
            {
                this.BLGoodsGuide_Button_Click(this.BLGoodsGuide_Button, new EventArgs());
            }
        }

        /// <summary>
        /// �R�[�h����̑I�����\�֕ύX����
        /// </summary>
        /// <param name="name"></param>
        private bool setTComboEditorByName(string name)
        {
            TComboEditor control = (TComboEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));

            bool inputErrorFlg = true;
            foreach (Infragistics.Win.ValueListItem item in control.Items)
            {
                if (item.DataValue == control.Value)
                {
                    inputErrorFlg = false;
                    break;
                }
            }

            return inputErrorFlg;
        }

        /// <summary>
        /// �R�[�h����̑I�����\�֕ύX����
        /// </summary>
        /// <param name="name"></param>
        private bool setTComboEditorByNameForWay(string name)
        {
            TComboEditor control = (TComboEditor)(this.GetType().GetField(name, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.IgnoreCase).GetValue(this));

            bool inputErrorFlg = true;

            if ((1 as object).Equals(control.Value))
            {
                inputErrorFlg = false;
                return inputErrorFlg;
            }
            if (("2").Equals(control.Text) || UNITPRICEKINDWAY_0.Equals(control.Text))
            {
                inputErrorFlg = false;
                return inputErrorFlg;
            }
            return inputErrorFlg;
        }

        private bool SetDetailFocus(Control nextControl)
        {
            if (!(nextControl == this.Detail_uGrid || nextControl == this.Detail_panel) || (this.Detail_uGrid.Enabled != true))
            {
                return false;
            }
            // �^�u�ړ��A�܂��̓J�[�\���ړ��ŃO���b�h�Ƀt�H�[�J�X�������������̃A�N�e�B�u�Z����ݒ肵�܂�
            for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < ROW_COUNT; rowIndex++)
                {
                    if (this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Activation != Activation.AllowEdit)
                    {
                        continue;
                    }

                    if (this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activation != Activation.AllowEdit)
                    {
                        continue;
                    }

                    this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activate();
                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    return true;
                }
            }
            return false;
        }
        //-----ADD 2010/08/10-----------<<<<<

        //-----ADD caohh 2011/08/05 ---------->>>>>
        /// <summary>
        /// ���[�U�[�ݒ�N������
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
        /// <br>Note       : ���[�U�[�ݒ�N���������s���܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/05</br>
        /// </remarks>
        private void ExecuteSetUp()
        {
            this._pMKHN09302UB.ShowDialog();
        }
        //-----ADD caohh 2011/08/05 ----------<<<<<
        #endregion Private Methods

        #region Control Events
        /// <summary>
        /// �t�H�[�����[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �t�H�[�����ǂݍ��܂ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// <br>Update Note: 2010/08/10 �k���r PM1012�Ή�</br>
        /// <br>             �K�C�h���u�e�T�v�{�^���ŕ\������悤�ɕύX</br>
        /// </remarks>
        private void DCKHN09160UA_Load(object sender, EventArgs e)
        {
            // �A�C�R���ݒ�
            SetIcon();

            // �R���g���[���T�C�Y�ݒ�
            SetControlSize();

            // ��ʃN���A
            ScreenClear();

            // ��ʓ��͋�����
            ScreenInputPermissionControl(INSERT_MODE);

            // �t�H�[�J�X�ݒ�
            this.tEdit_SectionCodeAllowZero.Focus();

            //-----ADD 2010/08/10---------->>>>>
            SettingGuideButtonToolEnabled(tEdit_SectionCodeAllowZero);
            //-----ADD 2010/08/10----------<<<<

            this._firstFlg = true;
        }

        #region �K�C�h����

        /// <summary>
        /// Button_Click �C�x���g(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: ���_�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSet secInfoSet = new SecInfoSet();

                // ���_�K�C�h�\��
                status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    if (secInfoSet.SectionCode.Trim() != this._prevSectionCode)
                    {
                        this._prevSectionCode = secInfoSet.SectionCode.Trim();

                        // ���_�R�[�h
                        this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();

                        // ���_����
                        this.SectionCodeNm_tEdit.DataText = secInfoSet.SectionGuideNm.Trim();

                        // �|���ݒ�敪���݃`�F�b�N
                        CheckExistRateSettingDivide(true);
                    }

                    // �t�H�[�J�X�ݒ�
                    SetFocus(this.SectionGuide_Button);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(RateSettingDivideGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �|���ݒ�敪�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// </remarks>
        private void RateSettingDivideGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                RateProtyMng rateProtyMng = new RateProtyMng();

                // ���_�R�[�h
                string sectionCode = this.tEdit_SectionCodeAllowZero.DataText;
                // �P�����
                int unitPriceKind = int.Parse((string)this.UnitPriceKind_tComboEditor.Value);
                // �ݒ���@
                int unitPriceKindWay = (int)this.UnitPriceKindWay_tComboEditor.Value;

                // �|���ݒ�敪�K�C�h�\��
                status = this._rateProtyMngAcs.ExecuteGuid(this._enterpriseCode, sectionCode, unitPriceKind,
                                                           unitPriceKindWay, out rateProtyMng, false);
                if (status == 0)
                {
                    if (rateProtyMng.RateSettingDivide.Trim() != this._prevRateSettingDivide)
                    {
                        this._prevRateSettingDivide = rateProtyMng.RateSettingDivide;

                        // �|���ݒ�敪
                        this.RateSettingDivide_tEdit.DataText = rateProtyMng.RateSettingDivide;

                        // ���i�ݒ�敪
                        this.RateMngGoodsCd_tEdit.DataText = rateProtyMng.RateMngGoodsCd;

                        // ���i�ݒ�敪����
                        this.RateMngGoodsNm_tEdit.DataText = rateProtyMng.RateMngGoodsNm.Trim();

                        // �����ݒ�敪
                        this.RateMngCustCd_tEdit.DataText = rateProtyMng.RateMngCustCd;

                        // �����ݒ�敪����
                        this.RateMngCustNm_tEdit.DataText = rateProtyMng.RateMngCustNm.Trim();

                        // �D�揇��
                        this.tNedit_RatePriorityOrder.SetInt(rateProtyMng.RatePriorityOrder);

                        // ��������(�����)�N���A
                        ClearCustomerCondition();

                        // ��������(���i)�N���A
                        ClearGoodsCondition();

                        // �����R���g���[��(�����)���͋�����
                        SetCustomerConditionEnabled();

                        // �����R���g���[��(���i)���͋�����
                        SetGoodsConditionEnabled();

                        // �O���b�h������
                        ClearGrid(unitPriceKind.ToString());

                        // �O���b�h���͋�����
                        SetGridEnabled();
                    }

                    // �t�H�[�J�X�ݒ�
                    SetFocus(this.RateSettingDivideGuide_Button);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(CustomerGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: ���Ӑ�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;

                // ���Ӑ�K�C�h
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                // �t�H�[�J�X�ݒ�
                if (this._cusotmerGuideSelected == true)
                {
                    SetFocus(this.CustomerGuide_Button);
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
        /// <br>Note       : ���Ӑ�I�����ɔ������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            //if (customerSearchRet.CustomerCode != this._prevCustomerCode)// DEL 2008/10/29 �s��Ή�[7173]
            // ADD 2008/10/29 �s��Ή�[7173] ---------->>>>>
            if (customerSearchRet.CustomerCode != this._prevCustomerCode ||
                this.CustomerCodeNm_tEdit.DataText.Trim() == string.Empty)
            // ADD 2008/10/29 �s��Ή�[7173] ----------<<<<<
            {
                this._prevCustomerCode = customerSearchRet.CustomerCode;

                // ���Ӑ�R�[�h
                this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);

                // ���Ӑ於��
                this.CustomerCodeNm_tEdit.DataText = customerSearchRet.Snm.Trim();
            }

            this._cusotmerGuideSelected = true;
        }

        // --- ADD 2009/01/13 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Button_Click �C�x���g(CustRateGrpGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: ���Ӑ�|���O���[�v�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2009/01/13</br>
        /// </remarks>
        private void CustRateGrpGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;

                UserGdHd userGdHd;
                UserGdBd userGdBd;

                status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGdHd, out userGdBd, 43);
                if (status == 0)
                {
                    // -------ADD 2009/12/15------->>>>>
                    if (userGdBd.GuideCode != this._prevCustRateGrpCode ||
                        this.tNedit_CustRateGrpCodeZero.DataText.Trim() == string.Empty)
                    {
                        this._prevCustRateGrpCode = userGdBd.GuideCode;
                    }
                    // -------ADD 2009/12/15-------<<<<<

                    this.tNedit_CustRateGrpCodeZero.DataText = userGdBd.GuideCode.ToString("0000");
                    this.tEdit_CustRateGrpName.DataText = userGdBd.GuideName.Trim();

                    // �t�H�[�J�X�ݒ�
                    SetFocus(this.CustRateGrpGuide_Button);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        // --- ADD 2009/01/13 ---------------------------------------------------------------------<<<<<

        /// <summary>
        /// Button_Click �C�x���g(SupplierGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �d����K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// </remarks>
        private void SupplierGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                Supplier supplier = new Supplier();

                // ���_�R�[�h
                string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();

                // �d����K�C�h�\��
                status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, sectionCode);
                if (status == 0)
                {
                    //if (supplier.SupplierCd != this._prevSupplierCode)  // DEL 2008/10/29 �s��Ή�[7173]
                    // ADD 2008/10/29 �s��Ή�[7173] ---------->>>>>
                    if (supplier.SupplierCd != this._prevSupplierCode ||
                        this.SupplierCdNm_tEdit.DataText.Trim() == string.Empty)
                    // ADD 2008/10/29 �s��Ή�[7173] ----------<<<<<
                    {
                        this._prevSupplierCode = supplier.SupplierCd;

                        // �d����R�[�h
                        this.tNedit_SupplierCd.SetInt(supplier.SupplierCd);

                        // �d���於��
                        this.SupplierCdNm_tEdit.DataText = supplier.SupplierSnm.Trim();
                    }

                    // �t�H�[�J�X�ݒ�
                    SetFocus(this.SupplierGuide_Button);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(MakerGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: ���[�J�[�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                MakerUMnt makerUMnt = new MakerUMnt();

                // ���[�J�[�K�C�h�\��
                status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    //if (makerUMnt.GoodsMakerCd != this._prevMakerCode)        // DEL 2008/10/29 �s��Ή�[7173]
                    // ADD 2008/10/29 �s��Ή�[7173] ---------->>>>>
                    if (makerUMnt.GoodsMakerCd != this._prevMakerCode ||
                        this.MakerName_tEdit.DataText.Trim() == string.Empty)
                    // ADD 2008/10/29 �s��Ή�[7173] ----------<<<<<
                    {
                        this._prevMakerCode = makerUMnt.GoodsMakerCd;

                        // ���[�J�[�R�[�h
                        this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);

                        // ���[�J�[����
                        this.MakerName_tEdit.DataText = makerUMnt.MakerName.Trim();

                        // ���i�R�[�h�擾
                        string goodsCode = this.tEdit_GoodsNo.DataText.Trim();

                        if (goodsCode != "")
                        {
                            GoodsUnitData goodsUnitData;

                            status = GetGoodsInfo(out goodsUnitData, goodsCode);
                            if (status == 0)
                            {
                                // ���i����
                                this.tEdit_GoodsName.DataText = goodsUnitData.GoodsNameKana.Trim();

                                // �艿
                                List<GoodsPrice> goodsPriceList = goodsUnitData.GoodsPriceList;
                                this.tNedit_Price.SetValue(GetPrice(goodsPriceList));
                            }
                            else
                            {
                                if (status != -1)
                                {
                                    // ���i����
                                    this.tEdit_GoodsName.Clear();

                                    // �艿
                                    this.tNedit_Price.Clear();
                                }
                            }
                        }
                    }

                    // �t�H�[�J�X�ݒ�
                    SetFocus(this.MakerGuide_Button);
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(GoodsRateGrpGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: ���i�|���f�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// </remarks>
        private void GoodsRateGrpGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                GoodsGroupU goodsGroupU = new GoodsGroupU();

                // ���i�|���f�K�C�h�\��
                status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU, false);
                if (status == 0)
                {
                    //if (goodsGroupU.GoodsMGroup != this._prevGoodsRateGrpCode)  // DEL 2008/10/29 �s��Ή�[7173]
                    // ADD 2008/10/29 �s��Ή�[7173] ---------->>>>>
                    if (goodsGroupU.GoodsMGroup != this._prevGoodsRateGrpCode ||
                        this.GoodsRateGrpName_tEdit.DataText.Trim() == string.Empty)
                    // ADD 2008/10/29 �s��Ή�[7173] ----------<<<<<
                    {
                        this._prevGoodsRateGrpCode = goodsGroupU.GoodsMGroup;

                        // ���i�|���f�R�[�h
                        this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);

                        // ���i�|���f����
                        this.GoodsRateGrpName_tEdit.DataText = goodsGroupU.GoodsMGroupName.Trim();
                    }

                    // �t�H�[�J�X�ݒ�
                    SetFocus(this.GoodsRateGrpGuide_Button);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(BLGroupGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: BL�O���[�v�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// </remarks>
        private void BLGroupGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGroupU blGroupU = new BLGroupU();

                // BL�O���[�v�K�C�h�\��
                status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
                if (status == 0)
                {
                    //if (blGroupU.BLGroupCode != this._prevBLGroupCode)  // DEL 2008/10/29 �s��Ή�[7173]
                    // ADD 2008/10/29 �s��Ή�[7173] ---------->>>>>
                    if (blGroupU.BLGroupCode != this._prevBLGroupCode ||
                        this.BLGroupName_tEdit.DataText.Trim() == string.Empty)
                    // ADD 2008/10/29 �s��Ή�[7173] ----------<<<<<
                    {
                        this._prevBLGroupCode = blGroupU.BLGroupCode;

                        // BL�O���[�v�R�[�h
                        this.tNedit_BLGloupCode.SetInt(blGroupU.BLGroupCode);

                        // BL�O���[�v����
                        this.BLGroupName_tEdit.DataText = blGroupU.BLGroupName.Trim();
                    }

                    // �t�H�[�J�X�ݒ�
                    SetFocus(this.BLGroupGuide_Button);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click �C�x���g(BLGoodsGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: BL�R�[�h�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// </remarks>
        private void BLGoodsGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGoodsCdUMnt blGoodsCdUMnt = new BLGoodsCdUMnt();

                // BL�R�[�h�K�C�h�\��
                status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
                if (status == 0)
                {
                    //if (blGoodsCdUMnt.BLGoodsCode != this._prevBLGoodsCode)  // DEL 2008/10/29 �s��Ή�[7173]
                    // ADD 2008/10/29 �s��Ή�[7173] ---------->>>>>
                    if (blGoodsCdUMnt.BLGoodsCode != this._prevBLGoodsCode ||
                        this.BLGoodsName_tEdit.DataText.Trim() == string.Empty)
                    // ADD 2008/10/29 �s��Ή�[7173] ----------<<<<<
                    {
                        this._prevBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;

                        // BL�R�[�h
                        this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);

                        // BL�R�[�h����
                        this.BLGoodsName_tEdit.DataText = blGoodsCdUMnt.BLGoodsHalfName.Trim();
                    }

                    // �t�H�[�J�X�ݒ�
                    SetFocus(this.BLGoodsGuide_Button);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion �K�C�h����

        /// <summary>
        /// ValueChanged �C�x���g(UnitPriceKind_tComboEditor)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �P����ނ̒l���ύX���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// <br>Update Note : 2010/08/10 �k���r PM1012�Ή�</br>
        /// <br>              ���X�g���ڂ��R�[�h����ł����͉\�֕ύX</br>
        /// </remarks>
        private void UnitPriceKind_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // �폜���[�h�̏ꍇ
            if (this.Mode_Label.Text == DELETE_MODE)
            {
                return;
            }

            if (this.UnitPriceKind_tComboEditor.Value == null)
            {
                this._prevUnitPriceKind = "";
                return;
            }

            // �P����ގ擾
            string unitPriceKind = (string)this.UnitPriceKind_tComboEditor.Value;

            if (unitPriceKind == this._prevUnitPriceKind)
            {
                return;
            }
            // ------------- DEL 2012/11/30 ���N Redmine#33663 --------->>>>>
            //// ADD 2009/06/16 ------>>>
            //if (unitPriceKind == "2")
            //{
            //    // �����ݒ�̏ꍇ�A�ݒ���@�̓O���[�v�ݒ�Œ�
            //    UnitPriceKindWay_tComboEditor.Enabled = false;
            //    UnitPriceKindWay_tComboEditor.Value = 1;
            //}
            //else
            //{
            //    // �����ݒ�ȊO
            //    UnitPriceKindWay_tComboEditor.Enabled = true;
            //}
            //// ADD 2009/06/16 ------<<<
            // ------------- DEL 2012/11/30 ���N Redmine#33663 ---------<<<<<
            // �|���ݒ�敪���݃`�F�b�N
            CheckExistRateSettingDivide(true);

            //-----UPD 2010/08/10----------->>>>>
            //this._prevUnitPriceKind = unitPriceKind;
            if (!this.setTComboEditorByName("UnitPriceKind_tComboEditor"))
            {
                this._prevUnitPriceKind = (string)this.UnitPriceKind_tComboEditor.Value;
                this._prevUnitPriceKindObj = this.UnitPriceKind_tComboEditor.Value;
            }
            //-----UPD 2010/08/10-----------<<<<<

        }

        /// <summary>
        /// ValueChanged �C�x���g(UnitPriceKindWay_tComboEditor)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �ݒ���@�̒l���ύX���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// <br>Update Note : 2010/08/10 �k���r PM1012�Ή�</br>
        /// <br>              ���X�g���ڂ��R�[�h����ł����͉\�֕ύX</br>
        /// </remarks>
        private void UnitPriceKindWay_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            //-----ADD 2010/08/10----------->>>>>
            if (!("2".Equals(this.UnitPriceKindWay_tComboEditor.Text)
                || UNITPRICEKINDWAY_0.Equals(this.UnitPriceKindWay_tComboEditor.Text))
                && !(1 as object).Equals(this.UnitPriceKindWay_tComboEditor.Value))
            {
                return;
            }
            //-----ADD 2010/08/10-----------<<<<<
            // �폜���[�h�̏ꍇ
            if (this.Mode_Label.Text == DELETE_MODE)
            {
                return;
            }

            if (this.UnitPriceKindWay_tComboEditor.Value == null)
            {
                this._prevUnitPriceKindWay = -1;
                return;
            }

            // �ݒ���@�擾
            //-----UPD 2010/08/10----------->>>>>
            //int unitPriceKindWay = (int)this.UnitPriceKindWay_tComboEditor.Value;
            int unitPriceKindWay = -1;
            if (!this.setTComboEditorByNameForWay("UnitPriceKindWay_tComboEditor"))
            {
                if ("2".Equals(this.UnitPriceKindWay_tComboEditor.Text) || UNITPRICEKINDWAY_0.Equals(this.UnitPriceKindWay_tComboEditor.Text))
                {
                    unitPriceKindWay = 0;
                }
                else
                {
                    unitPriceKindWay = (int)this.UnitPriceKindWay_tComboEditor.Value;
                }
            }
            //-----UPD 2010/08/10-----------<<<<<

            if (unitPriceKindWay == this._prevUnitPriceKindWay)
            {
                return;
            }

            // �|���ݒ�敪���݃`�F�b�N
            CheckExistRateSettingDivide(true);

            //-----UPD 2010/08/10----------->>>>>
            //this._prevUnitPriceKindWay = unitPriceKindWay;
            if (!this.setTComboEditorByNameForWay("UnitPriceKindWay_tComboEditor"))
            {
                if ("2".Equals(this.UnitPriceKindWay_tComboEditor.Text) || UNITPRICEKINDWAY_0.Equals(this.UnitPriceKindWay_tComboEditor.Text))
                {
                    this._prevUnitPriceKindWay = 0;
                    this._prevUnitPriceKindWayObj = 0;
                    //this.UnitPriceKindWay_tComboEditor.Value = 0;
                }
                else 
                {
                    this._prevUnitPriceKindWay = (int)this.UnitPriceKindWay_tComboEditor.Value;
                    this._prevUnitPriceKindWayObj = this.UnitPriceKindWay_tComboEditor.Value;
                }
            }
            //-----UPD 2010/08/10-----------<<<<<

        }

        // --- ADD 2009/01/13 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Enter �C�x���g(tNedit_CustRateGrpCode)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Note		: �e�L�X�g�{�b�N�X���A�N�e�B�u�ɂȂ����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2009/01/13</br>
        /// </remarks>
        private void tNedit_CustRateGrpCode_Enter(object sender, EventArgs e)
        {
            if (this.tNedit_CustRateGrpCodeZero.DataText.Trim() == "")
            {
                return;
            }

            int custRateGrpCode = this.tNedit_CustRateGrpCodeZero.GetInt();

            this.tNedit_CustRateGrpCodeZero.SetInt(custRateGrpCode);
            this.tNedit_CustRateGrpCodeZero.SelectAll();
        }
        // --- ADD 2009/01/13 ---------------------------------------------------------------------<<<<<

        #region �O���b�h����

        /// <summary>
        /// AfterExitEditMode �C�x���g(Detail_uGrid)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �ҏW���[�h���I�������Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// </remarks>
        private void Detail_uGrid_AfterExitEditMode(object sender, EventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
            int columnIndex = this.Detail_uGrid.ActiveCell.Column.Index;

            if ((this.Detail_uGrid.ActiveCell.Value == DBNull.Value) || ((string)this.Detail_uGrid.ActiveCell.Value == ""))
            {
                return;
            }

            // �[�������敪�̏ꍇ
            if (rowIndex == ROWINDEX_UNPRCFRACPROCDIV)
            {
                return;
            }

            string retText;
            string targetText = (string)this.Detail_uGrid.ActiveCell.Value;

            // �J���}�̂ݍ폜
            RemoveCommaPeriod(targetText, out retText, false);

            double targetValue = double.Parse(retText);

            // ���[�U�[�艿�̏ꍇ
            if (rowIndex == ROWINDEX_USERPRICEFL)
            {
                this.Detail_uGrid.ActiveCell.Value = targetValue.ToString(FORMAT_NUM);
            }
            else
            {
                this.Detail_uGrid.ActiveCell.Value = targetValue.ToString(FORMAT_DECIMAL);
            }

            // ����(�ȏ�)�̏ꍇ
            if (rowIndex == ROWINDEX_LOTCOUNTABOVE)
            {
                if (targetValue != 9999999.99)
                {
                    this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTBELOW].Cells[columnIndex - 1].Value = (targetValue - 0.01).ToString(FORMAT_DECIMAL);
                }
                else
                {
                    this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTBELOW].Cells[columnIndex - 1].Value = targetValue.ToString("N");
                }
            }
        }

        /// <summary>
        /// AfterEnterEditMode �C�x���g(Detail_uGrid)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �ҏW���[�h���J�n�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// </remarks>
        private void Detail_uGrid_AfterEnterEditMode(object sender, EventArgs e)
        {
            int rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;

            // �[�������敪�̏ꍇ
            if (rowIndex == ROWINDEX_UNPRCFRACPROCDIV)
            {
                return;
            }

            if ((this.Detail_uGrid.ActiveCell.Value == DBNull.Value) || ((string)this.Detail_uGrid.ActiveCell.Value == ""))
            {
                return;
            }

            string retText;
            string targetText = (string)this.Detail_uGrid.ActiveCell.Value;

            // �J���}�̂ݍ폜
            RemoveCommaPeriod(targetText, out retText, false);

            this.Detail_uGrid.ActiveCell.Value = retText;
            this.Detail_uGrid.ActiveCell.SelStart = 0;
            this.Detail_uGrid.ActiveCell.SelLength = retText.Length;
        }

        /// <summary>
        /// CellChange �C�x���g(Detail_uGrid)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �Z���̒l���ύX���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// <br>Update Note : 2010/08/10 �k���r PM1012�Ή�</br>
        /// <br>              ���X�g���ڂ��R�[�h����ł����͉\�֕ύX</br>
        /// </remarks>
        private void Detail_uGrid_CellChange(object sender, CellEventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = e.Cell.Row.Index;
            int columnIndex = e.Cell.Column.Index;

            //-----ADD 2010/08/10---------->>>>>
            if (rowIndex == ROWINDEX_UNPRCFRACPROCDIV)
            {
                this._preDCEditorValue = (string)e.Cell.Value;
            }
            //-----ADD 2010/08/10----------<<<<<
            if ((rowIndex != ROWINDEX_LOTCOUNTABOVE) || (columnIndex == this._prevColumnIndex))
            {
                return;
            }

            // �Z���̒l���擾
           string targetText = e.Cell.Text.Trim();

            if (targetText == "")
            {
                return;
            }

            // �Z�����͋��ύX
            ChangeCellEnabled(columnIndex);

            string unitPriceKind = (string)this.UnitPriceKind_tComboEditor.Value;

            if (unitPriceKind == "3")
            {
                // �[�������P��
                if (this.Detail_uGrid.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Text == "")
                {
                    this.Detail_uGrid.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Value = "1.00";
                }
                // �[�������敪
                if (this.Detail_uGrid.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[columnIndex].Text == "")
                {
                    //this.Detail_uGrid.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[columnIndex].Value = 1;       //DEL 2008/10/16 �����l���l�̌ܓ��Ƃ����
                    this.Detail_uGrid.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[columnIndex].Value = 2;         //ADD 2008/10/16
                }
            }

            if (columnIndex != (COLUMN_COUNT - 1))
            {
                this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTABOVE].Cells[columnIndex + 1].Activation = Activation.AllowEdit;
            }

            this._prevColumnIndex = columnIndex;
        }

        /// <summary>
        /// KeyDown �C�x���g(Detail_uGrid)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �L�[�������ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// <br></br>
        /// <br>Update Note: 2009/12/15 ���M</br>
        /// <br>             �ێ�˗��C�Ή�</br>
        /// </remarks>
        private void Detail_uGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
            int columnIndex = this.Detail_uGrid.ActiveCell.Column.Index;

            // �O���b�h���̃J�[�\���ړ���ݒ肵�܂�
            switch (e.KeyCode)
            {
                case Keys.Up:
                    // -------DEL 2009/12/15------->>>>>
                    //if (rowIndex == 0)
                    //{
                    //    e.Handled = true;
                    //    return;
                    //}
                    // -------DEL 2009/12/15-------<<<<<
                    if (rowIndex == ROW_COUNT - 1)
                    {
                        // �[�������敪
                        string unPrcFracProcDivName = this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[columnIndex].Text;
                        switch (unPrcFracProcDivName)
                        {
                            case UNPRCFRACPROCDIV_1:
                                break;
                            case UNPRCFRACPROCDIV_2:
                            case UNPRCFRACPROCDIV_3:
                                return;
                        }
                    }

                    bool allowFalg = false; //ADD 2009/12/15

                    // -------UPD 2009/12/15------->>>>>
                    //for (int index = rowIndex - 1; index >= 0; index--)
                    //{
                    //    if ((this.Detail_uGrid.DisplayLayout.Rows[index].Activation == Activation.AllowEdit) &&
                    //        (this.Detail_uGrid.DisplayLayout.Rows[index].Cells[columnIndex].Activation == Activation.AllowEdit))
                    //    {
                    //        // �A�N�e�B�u�Z����1��Ɉړ����܂�
                    //        e.Handled = true;
                    //        this.Detail_uGrid.DisplayLayout.Rows[index].Cells[columnIndex].Activate();
                    //        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);

                    //        return;
                    //    }
                    //}
                    if (rowIndex > 0)
                    {
                        for (int index = rowIndex - 1; index >= 0; index--)
                        {
                            if ((this.Detail_uGrid.DisplayLayout.Rows[index].Activation == Activation.AllowEdit) &&
                                (this.Detail_uGrid.DisplayLayout.Rows[index].Cells[columnIndex].Activation == Activation.AllowEdit))
                            {
                                // �A�N�e�B�u�Z����1��Ɉړ����܂�
                                e.Handled = true;
                                this.Detail_uGrid.DisplayLayout.Rows[index].Cells[columnIndex].Activate();
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);

                                allowFalg = true;
                                return;
                            }
                        }
                    }
                    // -------UPD 2009/12/15-------<<<<<

                    // -------ADD 2009/12/15------->>>>>
                    if (allowFalg == false && columnIndex == 0)
                    {
                        SetNextFocus();
                    }
                    else if (rowIndex == 0)
                    {
                        for (int columnIndexFor = columnIndex; columnIndexFor >= 0; columnIndexFor--)
                        {
                            if (columnIndexFor != columnIndex)
                            {
                                for (int rowIndexFor = ROW_COUNT - 1; rowIndexFor >= 0; rowIndexFor--)
                                {
                                    if ((this.Detail_uGrid.Rows[rowIndexFor].Activation == Activation.AllowEdit) &&
                                        (this.Detail_uGrid.Rows[rowIndexFor].Cells[columnIndexFor].Activation == Activation.AllowEdit))
                                    {
                                        this.Detail_uGrid.Rows[rowIndexFor].Cells[columnIndexFor].Activate();
                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                    // -------ADD 2009/12/15-------<<<<<
                    break;
                case Keys.Down:
                    if (rowIndex == ROW_COUNT - 1)
                    {
                        return;
                    }
                    for (int index = rowIndex + 1; index < ROW_COUNT; index++)
                    {
                        if ((this.Detail_uGrid.DisplayLayout.Rows[index].Activation == Activation.AllowEdit) &&
                            (this.Detail_uGrid.DisplayLayout.Rows[index].Cells[columnIndex].Activation == Activation.AllowEdit))
                        {
                            // �A�N�e�B�u�Z����1���Ɉړ����܂�
                            e.Handled = true;
                            this.Detail_uGrid.DisplayLayout.Rows[index].Cells[columnIndex].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                    }
                    break;
                case Keys.Left:
                    if (columnIndex == 0)
                    {
                        return;
                    }
                    for (int index = columnIndex - 1; index >= 0; index--)
                    {
                        if (this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[index].Activation == Activation.AllowEdit)
                        {
                            // �A�N�e�B�u�Z����1���Ɉړ����܂�
                            e.Handled = true;
                            this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[index].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                    }
                    break;
                case Keys.Right:
                    if (columnIndex == COLUMN_COUNT - 1)
                    {
                        return;
                    }
                    for (int index = columnIndex + 1; index < COLUMN_COUNT; index++)
                    {
                        if (this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[index].Activation == Activation.AllowEdit)
                        {
                            // �A�N�e�B�u�Z����1�E�Ɉړ����܂�
                            e.Handled = true;
                            this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[index].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// KeyPress �C�x���g(Detail_uGrid)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �L�[�������ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// </remarks>
        private void Detail_uGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
            int columnIndex = this.Detail_uGrid.ActiveCell.Column.Index;

            // �[�������敪�̏ꍇ
            if (rowIndex == ROWINDEX_UNPRCFRACPROCDIV)
            {
                return;
            }

            // �uBackspace�v�L�[�������ꂽ��
            if ((byte)e.KeyChar == (byte)'\b')
            {
                return;
            }

            // �ΏۃZ���̃e�L�X�g�擾
            string retText;
            string targetText = this.Detail_uGrid.ActiveCell.Text;
            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);

            // �e�s�̓��͉\������ݒ肵�܂�
            switch (rowIndex)
            {
                // ����(�ȏ�)�A����(�ȉ�)�A�[�������P��
                // 7V2
                case ROWINDEX_LOTCOUNTABOVE:
                case 1:
                case ROWINDEX_UNPRCFRACPROCUNIT:
                    // �Z���̃e�L�X�g���I������Ă���ꍇ
                    if (this.Detail_uGrid.ActiveCell.SelText == targetText)
                    {
                        // ���l�̂ݓ��͉�
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // �J���}�A�s���I�h�폜
                        RemoveCommaPeriod(targetText, out retText, true);

                        // ��������9��������������͕s��
                        if (retText.Length == 9)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // ���l�ȊO�̎�
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // ���͒l��1�����ڂ́u,�v�u.�v�s��
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    if (targetText.IndexOf(".") >= 0)
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    if (targetText[targetText.Length - 1].ToString() == ",")
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    // �J���}�A�s���I�h�폜
                                    RemoveCommaPeriod(targetText, out retText, true);

                                    if (retText.Length == 7)
                                    {
                                        if ((byte)e.KeyChar != '.')
                                        {
                                            e.KeyChar = '\0';
                                        }
                                    }

                                    // �u,�v�u.�v�͓��͉�
                                    if (((byte)e.KeyChar == ',') || ((byte)e.KeyChar == '.'))
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                            else
                            {
                                if (targetText.IndexOf(".") >= 0)
                                {
                                    // �����_�擾
                                    GetDecimal(targetText, out retText);

                                    if (retText.Length == 2)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                                else
                                {
                                    // �J���}�A�s���I�h�폜
                                    RemoveCommaPeriod(targetText, out retText, true);

                                    if (retText.Length == 7)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                    break;

                //// �������A����UP���A�e���m�ۗ��A�d�����A���iUP�� // DEL 2009/06/19
                // �������A����UP���A�d�����A���iUP��   // ADD 2009/06/19
                // 3V2
                case ROWINDEX_SALERATEVAL:
                case ROWINDEX_COSTUPRATE:
                //case ROWINDEX_GRSPROFITSECURERATE:    // DEL 2009/06/19
                case ROWINDEX_COSTRATEVAL:
                case ROWINDEX_PRICEUPRATE:
                    // �Z���̃e�L�X�g���I������Ă���ꍇ
                    if (this.Detail_uGrid.ActiveCell.SelText == targetText)
                    {
                        // ���l�̂ݓ��͉�
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // �J���}�A�s���I�h�폜
                        RemoveCommaPeriod(targetText, out retText, true);

                        // ��������5��������������͕s��
                        if (retText.Length == 5)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // ���l�ȊO�̎�
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // ���͒l��1�����ڂ́u,�v�u.�v�s��
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    if (targetText.IndexOf(".") >= 0)
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    if (targetText[targetText.Length - 1].ToString() == ",")
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    // �J���}�A�s���I�h�폜
                                    RemoveCommaPeriod(targetText, out retText, true);

                                    if (retText.Length == 3)
                                    {
                                        if ((byte)e.KeyChar != '.')
                                        {
                                            e.KeyChar = '\0';
                                        }
                                    }

                                    // �u,�v�u.�v�͓��͉�
                                    if (((byte)e.KeyChar == ',') || ((byte)e.KeyChar == '.'))
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                            else
                            {
                                if (targetText.IndexOf(".") >= 0)
                                {
                                    // �����_�擾
                                    GetDecimal(targetText, out retText);

                                    if (retText.Length == 2)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                                else
                                {
                                    // �J���}�A�s���I�h�폜
                                    RemoveCommaPeriod(targetText, out retText, true);

                                    if (retText.Length == 3)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                    break;

                // ADD 2009/06/19 ------>>>
                // �e���m�ۗ�
                // 2V2
                case ROWINDEX_GRSPROFITSECURERATE:
                    // �Z���̃e�L�X�g���I������Ă���ꍇ
                    if (this.Detail_uGrid.ActiveCell.SelText == targetText)
                    {
                        // ���l�̂ݓ��͉�
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // �J���}�A�s���I�h�폜
                        RemoveCommaPeriod(targetText, out retText, true);

                        // ��������4��������������͕s��
                        if (retText.Length == 4)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // ���l�ȊO�̎�
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // ���͒l��1�����ڂ́u,�v�u.�v�s��
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    if (targetText.IndexOf(".") >= 0)
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    if (targetText[targetText.Length - 1].ToString() == ",")
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    // �J���}�A�s���I�h�폜
                                    RemoveCommaPeriod(targetText, out retText, true);

                                    if (retText.Length == 2)
                                    {
                                        if ((byte)e.KeyChar != '.')
                                        {
                                            e.KeyChar = '\0';
                                        }
                                    }

                                    // �u,�v�u.�v�͓��͉�
                                    if (((byte)e.KeyChar == ',') || ((byte)e.KeyChar == '.'))
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                            else
                            {
                                if (targetText.IndexOf(".") >= 0)
                                {
                                    // �����_�擾
                                    GetDecimal(targetText, out retText);

                                    if (retText.Length == 2)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                                else
                                {
                                    // �J���}�A�s���I�h�폜
                                    RemoveCommaPeriod(targetText, out retText, true);

                                    if (retText.Length == 2)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                    break;
                // ADD 2009/06/19 ------<<<
                
                // �����z�A�d������
                // 9V2
                case ROWINDEX_SALEPRICEFL:
                case ROWINDEX_COSTPRICEFL:
                    // �Z���̃e�L�X�g���I������Ă���ꍇ
                    if (this.Detail_uGrid.ActiveCell.SelText == targetText)
                    {
                        // ���l�̂ݓ��͉�
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // �J���}�A�s���I�h�폜
                        RemoveCommaPeriod(targetText, out retText, true);

                        // ��������11��������������͕s��
                        if (retText.Length == 11)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // ���l�ȊO�̎�
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // ���͒l��1�����ڂ́u,�v�u.�v�s��
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    if (targetText.IndexOf(".") >= 0)
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    if (targetText[targetText.Length - 1].ToString() == ",")
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    // �J���}�A�s���I�h�폜
                                    RemoveCommaPeriod(targetText, out retText, true);

                                    if (retText.Length == 9)
                                    {
                                        if ((byte)e.KeyChar != '.')
                                        {
                                            e.KeyChar = '\0';
                                        }
                                    }

                                    // �u,�v�u.�v�͓��͉�
                                    if (((byte)e.KeyChar == ',') || ((byte)e.KeyChar == '.'))
                                    {
                                        return;
                                    }
                                    else
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                            else
                            {
                                if (targetText.IndexOf(".") >= 0)
                                {
                                    // �����_�擾
                                    GetDecimal(targetText, out retText);

                                    if (retText.Length == 2)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                                else
                                {
                                    // �J���}�A�s���I�h�폜
                                    RemoveCommaPeriod(targetText, out retText, true);

                                    if (retText.Length == 9)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                    break;

                // ���[�U�[�艿
                // 9
                case ROWINDEX_USERPRICEFL:
                    // �Z���̃e�L�X�g���I������Ă���ꍇ
                    if (this.Detail_uGrid.ActiveCell.SelText == targetText)
                    {
                        // ���l�̂ݓ��͉�
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // �J���}�A�s���I�h�폜
                        RemoveCommaPeriod(targetText, out retText, true);

                        // ��������9��������������͕s��
                        if (retText.Length == 9)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // ���l�ȊO�̎�
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // ���͒l��1�����ڂ́u,�v�s��
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    // �u,�v�͓��͉�
                                    if ((byte)e.KeyChar != ',')
                                    {
                                        e.KeyChar = '\0';
                                    }

                                    if (targetText[targetText.Length - 1].ToString() == ",")
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                            }
                        }
                    }
                    break;
            }
        }

        #endregion �O���b�h����

        /// <summary>
        /// ChangeFocus �C�x���g(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/09/25</br>
        /// <br></br>
        /// <br>Update Note: 2009/12/15 ���M</br>
        /// <br>             �ێ�˗��C�Ή�</br>
        /// <br>Update Note : 2010/08/10 �k���r PM1012�Ή�</br>
        /// <br>              �ŏI���ڂ���̂d����er�œo�^�m�F���[�h�ֈڍs������</br>
        /// <br>              �t�H�[�J�X����̌�����</br>
        /// <br>              �K�C�h���u�e�T�v�{�^���ŕ\������悤�ɕύX</br>
        /// <br>Update Note : 2010/08/20 �k���r #13358�Ή�</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // --- ADD 2010/08/10----------------------------------->>>>>
            // --- UPD 2010/08/20----------------------------------->>>>>
            //this.SettingGuideButtonToolEnabled(e.NextCtrl);
            if (e.PrevCtrl == this.Detail_uGrid)
            {
                this._isGuide = false;
            }
            else
            {
                this.SettingGuideButtonToolEnabled(e.NextCtrl);
            }
            // --- UPD 2010/08/20-----------------------------------<<<<<
            if (e.NextCtrl == null)
            {
                e.NextCtrl = e.PrevCtrl;
            }
            if (e.NextCtrl.GetType().Name == "TComboEditor")
            {
                if ("UnitPriceKind_tComboEditor".Equals(e.NextCtrl.Name))
                {
                    this._prevUnitPriceKindObj = (string)((TComboEditor)e.NextCtrl).Value;
                }
                else if ("UnitPriceKindWay_tComboEditor".Equals(e.NextCtrl.Name))
                {
                    if ("2".Equals(((TComboEditor)e.NextCtrl).Value))
                    {
                        this._prevUnitPriceKindWayObj = 0;
                    }
                    else
                    {
                        this._prevUnitPriceKindWayObj = ((TComboEditor)e.NextCtrl).Value;
                    }
                }
            }
            // --- ADD 2010/08/10-----------------------------------<<<<<

            // �O���b�h
            if (e.PrevCtrl == this.Detail_uGrid)
            {
                // -------ADD 2010/08/20------->>>>>
                if (e.ShiftKey && (e.Key == Keys.Tab || e.Key == Keys.Enter))
                {
                    if (this.Detail_uGrid.ActiveCell == null)
                    {
                        this.Detail_uGrid.PerformAction(UltraGridAction.NextCell);
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        e.NextCtrl = null;
                        return;
                    }

                    int activeRowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
                    int activeColumnIndex = this.Detail_uGrid.ActiveCell.Column.Index;
                    bool allowFalg = false;

                    if (activeRowIndex > 0)
                    {
                        for (int index = activeRowIndex - 1; index >= 0; index--)
                        {
                            if ((this.Detail_uGrid.DisplayLayout.Rows[index].Activation == Activation.AllowEdit) &&
                                (this.Detail_uGrid.DisplayLayout.Rows[index].Cells[activeColumnIndex].Activation == Activation.AllowEdit))
                            {
                                allowFalg = true;
                                break;
                            }
                        }
                    }

                    if (allowFalg == false && activeColumnIndex == 0)
                    {
                        e.NextCtrl = null;
                        SetNextFocus();
                    }
                    else
                    {
                        for (int columnIndex = activeColumnIndex; columnIndex >= 0; columnIndex--)
                        {
                            if (columnIndex == activeColumnIndex)
                            {
                                for (int rowIndex = activeRowIndex - 1; rowIndex >= 0; rowIndex--)
                                {
                                    if ((this.Detail_uGrid.Rows[rowIndex].Activation == Activation.AllowEdit) &&
                                        (this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activation == Activation.AllowEdit))
                                    {
                                        this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                for (int rowIndex = ROW_COUNT - 1; rowIndex >= 0; rowIndex--)
                                {
                                    if ((this.Detail_uGrid.Rows[rowIndex].Activation == Activation.AllowEdit) &&
                                        (this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activation == Activation.AllowEdit))
                                    {
                                        this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                        e.NextCtrl = null;
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
                // -------ADD 2010/08/20-------<<<<<

                // --- UPD 2010/08/10----------------------------------->>>>>
                //if (e.Key == Keys.Enter)
                if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                // --- UPD 2010/08/10-----------------------------------<<<<<
                {
                    if (this.Detail_uGrid.ActiveCell == null)
                    {
                        this.Detail_uGrid.PerformAction(UltraGridAction.NextCell);
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        e.NextCtrl = null;
                        return;
                    }
                    
                    int activeRowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
                    int activeColumnIndex = this.Detail_uGrid.ActiveCell.Column.Index;

                    for (int columnIndex = activeColumnIndex; columnIndex < COLUMN_COUNT; columnIndex++)
                    {
                        if (columnIndex == activeColumnIndex)
                        {
                            for (int rowIndex = activeRowIndex + 1; rowIndex < ROW_COUNT; rowIndex++)
                            {
                                if ((this.Detail_uGrid.Rows[rowIndex].Activation == Activation.AllowEdit) &&
                                    (this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activation == Activation.AllowEdit))
                                {
                                    this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    e.NextCtrl = null;
                                    return;
                                }
                            }
                        }
                        else
                        {
                            for (int rowIndex = 0; rowIndex < ROW_COUNT; rowIndex++)
                            {
                                if ((this.Detail_uGrid.Rows[rowIndex].Activation == Activation.AllowEdit) &&
                                    (this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activation == Activation.AllowEdit))
                                {
                                    this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                    e.NextCtrl = null;
                                    return;
                                }
                            }
                        }
                    }
                    // --- ADD 2010/08/10----------------------------------->>>>>
                    if (e.Key == Keys.Enter)
                    {
                        DialogResult dialogResult = TMsgDisp.Show(this,
                                      emErrorLevel.ERR_LEVEL_QUESTION,
                                      this.Name,
                                      "�o�^���Ă���낵���ł����B",
                                      0,
                                      MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            e.NextCtrl = null;
                            this.SaveProc();
                            return;
                        }
                        else
                        {
                            this.Detail_uGrid.Rows[activeRowIndex].Cells[activeColumnIndex].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            e.NextCtrl = null;
                            return;
                        }
                    }
                    if (e.Key == Keys.Tab)
                    {
                        this.Detail_uGrid.Rows[activeRowIndex].Cells[activeColumnIndex].Activate();
                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                        e.NextCtrl = null;
                        return;
                    }
                    // --- ADD 2010/08/10-----------------------------------<<<<<
                }
                // -------DEL 2010/08/20------->>>>>
                //// -------ADD 2009/12/15------->>>>>
                //if (e.ShiftKey && e.Key == Keys.Tab)
                //{
                //    if (this.Detail_uGrid.ActiveCell == null)
                //    {
                //        this.Detail_uGrid.PerformAction(UltraGridAction.NextCell);
                //        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                //        e.NextCtrl = null;
                //        return;
                //    }

                //    int activeRowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
                //    int activeColumnIndex = this.Detail_uGrid.ActiveCell.Column.Index;
                //    bool allowFalg = false;

                //    if (activeRowIndex > 0)
                //    {
                //        for (int index = activeRowIndex - 1; index >= 0; index--)
                //        {
                //            if ((this.Detail_uGrid.DisplayLayout.Rows[index].Activation == Activation.AllowEdit) &&
                //                (this.Detail_uGrid.DisplayLayout.Rows[index].Cells[activeColumnIndex].Activation == Activation.AllowEdit))
                //            {
                //                allowFalg = true;
                //                break;
                //            }
                //        }
                //    }

                //    if (allowFalg == false && activeColumnIndex == 0)
                //    {
                //        e.NextCtrl = null;
                //        SetNextFocus();
                //    }
                //    else
                //    {
                //        for (int columnIndex = activeColumnIndex; columnIndex >= 0; columnIndex--)
                //        {
                //            if (columnIndex == activeColumnIndex)
                //            {
                //                for (int rowIndex = activeRowIndex - 1; rowIndex >= 0; rowIndex--)
                //                {
                //                    if ((this.Detail_uGrid.Rows[rowIndex].Activation == Activation.AllowEdit) &&
                //                        (this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activation == Activation.AllowEdit))
                //                    {
                //                        this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                //                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                //                        e.NextCtrl = null;
                //                        return;
                //                    }
                //                }
                //            }
                //            else
                //            {
                //                for (int rowIndex = ROW_COUNT-1; rowIndex >= 0; rowIndex--)
                //                {
                //                    if ((this.Detail_uGrid.Rows[rowIndex].Activation == Activation.AllowEdit) &&
                //                        (this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activation == Activation.AllowEdit))
                //                    {
                //                        this.Detail_uGrid.Rows[rowIndex].Cells[columnIndex].Activate();
                //                        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                //                        e.NextCtrl = null;
                //                        return;
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}
                //// -------ADD 2009/12/15-------<<<<<
                // -------DEL 2010/08/20-------<<<<<
            }
            // ���_�R�[�h
            else if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero)
            {
                // ���_�R�[�h�擾
                string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');

                string sectionName = GetSectionName(sectionCode);

                if (sectionName == "")
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "�}�X�^�ɓo�^����Ă��܂���B",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);

                    this.SectionCodeNm_tEdit.Clear();
                    this.tEdit_SectionCodeAllowZero.SelectAll();

                    e.NextCtrl = e.PrevCtrl;
                    return;
                }

                // ���_���̎擾
                this.SectionCodeNm_tEdit.DataText = GetSectionName(sectionCode);

                if (this.SectionCodeNm_tEdit.DataText.Trim() == "")
                {
                    // ���i�ݒ�敪������
                    this.RateMngGoodsCd_tEdit.Clear();
                    this.RateMngGoodsNm_tEdit.Clear();

                    // �����ݒ�敪������
                    this.RateMngCustCd_tEdit.Clear();
                    this.RateMngCustNm_tEdit.Clear();

                    // �D�揇�ʏ�����
                    this.tNedit_RatePriorityOrder.Clear();

                    // �O���b�h������
                    ClearGrid("");

                    // ��������(�����)�N���A
                    ClearCustomerCondition();

                    // ��������(���i)�N���A
                    ClearGoodsCondition();

                    // �����R���g���[��(�����)���͋�����
                    SetCustomerConditionEnabled();

                    // �����R���g���[��(���i)���͋�����
                    SetGoodsConditionEnabled();

                    // �O���b�h���͋�����
                    SetGridEnabled();
                }
                else
                {
                    if (sectionCode != this._prevSectionCode)
                    {
                        // �|���ݒ�敪���݃`�F�b�N
                        CheckExistRateSettingDivide(true);

                        SearchAfterLeaveControl(); // ADD 2009/12/15
                    }

                    //SearchAfterLeaveControl(); DEL 2009/12/15

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            // �t�H�[�J�X�ݒ�
                            e.NextCtrl = this.UnitPriceKind_tComboEditor;
                        }
                    }
                }

                this._prevSectionCode = sectionCode;
                // --- ADD 2010/08/10----------------------------------->>>>>
                if (e.ShiftKey == true)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                }
                // --- ADD 2010/08/10-----------------------------------<<<<<
            }
            // �|���ݒ�敪
            else if (e.PrevCtrl == this.RateSettingDivide_tEdit)
            {
                if (this.RateSettingDivide_tEdit.DataText == "")
                {
                    this.RateMngGoodsCd_tEdit.Clear();
                    this.RateMngGoodsNm_tEdit.Clear();
                    this.RateMngCustCd_tEdit.Clear();
                    this.RateMngCustNm_tEdit.Clear();
                    this._prevRateSettingDivide = "";

                    // �����R���g���[��(�����)���͋�����
                    SetCustomerConditionEnabled();

                    // �����R���g���[��(���i)���͋�����
                    SetGoodsConditionEnabled();
                    // -------ADD 2010/08/10------->>>>>
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Down)) 
                        {
                            if (SetDetailFocus(e.NextCtrl))
                            {
                                e.NextCtrl = null;
                            }
                        }
                    }
                    // -------ADD 2010/08/10-------<<<<<
                    return;
                }

                // �|���ݒ�敪
                string rateSettingDivCode = this.RateSettingDivide_tEdit.DataText.Trim();

                // -------UPD 2010/08/10------->>>>>
                //if (e.Key == Keys.Enter)
                if ((e.ShiftKey == false) && (e.Key == Keys.Enter))
                // -------UPD 2010/08/10-------<<<<<
                {
                    e.NextCtrl = null;
                    SetNextFocus(0);
                }

                if (rateSettingDivCode == this._prevRateSettingDivide)
                {
                    return;
                }

                // �|���ݒ�敪���݃`�F�b�N
                CheckExistRateSettingDivide(false);

                if (this.tNedit_RatePriorityOrder.DataText.Trim() == "")
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                       "�}�X�^�ɓo�^����Ă��܂���B",
                                       0,
                                       MessageBoxButtons.OK,
                                       MessageBoxDefaultButton.Button1);

                    this._prevRateSettingDivide = rateSettingDivCode;
                    this.RateSettingDivide_tEdit.SelectAll();
                    e.NextCtrl = e.PrevCtrl;
                    return;
                }

                SearchAfterLeaveControl();

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        e.NextCtrl = null;
                        SetNextFocus(0);
                    }
                }
                // -------UPD 2010/08/10------->>>>>
                else
                {
                    if (e.Key == Keys.Enter)
                    {
                        e.NextCtrl = this.UnitPriceKindWay_tComboEditor;
                    }
                }
                // -------UPD 2010/08/10-------<<<<<
                this._prevRateSettingDivide = rateSettingDivCode;
            }
            // ���Ӑ�R�[�h
            else if (e.PrevCtrl == this.tNedit_CustomerCode)
            {
                if (this.tNedit_CustomerCode.GetInt() == 0)
                {
                    this.CustomerCodeNm_tEdit.Clear();
                    // -------ADD 2009/12/15------->>>>>
                    this._prevCustomerCode = -1;
                    // -------ADD 2009/12/15-------<<<<<
                    // -------ADD 2010/08/10------->>>>>
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Down))
                        {
                            if (SetDetailFocus(e.NextCtrl))
                            {
                                e.NextCtrl = null;
                            }
                        }
                        if (e.Key == Keys.Left)
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    // -------ADD 2010/08/10-------<<<<<
                    return;
                }

                // ���Ӑ�R�[�h�擾
                int customerCode = this.tNedit_CustomerCode.GetInt();

                // ���Ӑ於�̎擾
                string customerName = GetCustomerName(customerCode);

                //if (customerName == "")   // DEL 2009/06/29
                if (!CheckCustomer(customerCode))   // ADD 2009/06/29
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "�}�X�^�ɓo�^����Ă��܂���B",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);

                    this.CustomerCodeNm_tEdit.Clear();
                    this.tNedit_CustomerCode.SelectAll();

                    e.NextCtrl = e.PrevCtrl;
                    return;
                }

                this.CustomerCodeNm_tEdit.DataText = customerName;

                //if (this.CustomerCodeNm_tEdit.DataText.Trim() != "")  // DEL 2009/06/29
                if (CheckCustomer(customerCode))    // ADD 2009/06/29
                {
                    // -------UPD 2009/12/15------->>>>>
                    //SearchAfterLeaveControl();
                    if (this._prevCustomerCode != customerCode)
                    {
                        SearchAfterLeaveControl();
                    }

                    this._prevCustomerCode = customerCode;
                    // -------UPD 2009/12/15-------<<<<<

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = null;
                            SetNextFocus(1);
                        }
                    }
                }
                // -------ADD 2010/08/10------->>>>>
                if (e.ShiftKey == false)
                {
                    if (e.Key == Keys.Left)
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                }
                // -------ADD 2010/08/10-------<<<<<
            }
            // --- ADD 2009/01/13 --------------------------------------------------------------------->>>>>
            // ���Ӑ�|���O���[�v
            else if (e.PrevCtrl == this.tNedit_CustRateGrpCodeZero)
            {
                if (this.tNedit_CustRateGrpCodeZero.DataText.Trim() == "")
                {
                    this.tNedit_CustRateGrpCodeZero.Clear();
                    this.tEdit_CustRateGrpName.Clear();
                    // -------ADD 2009/12/15------->>>>>
                    this._prevCustRateGrpCode = -1;
                    // -------ADD 2009/12/15-------<<<<<
                    // -------ADD 2010/08/10------->>>>>
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Down))
                        {
                            if (SetDetailFocus(e.NextCtrl))
                            {
                                e.NextCtrl = null;
                            }
                        }
                        if (e.Key == Keys.Left)
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    // -------ADD 2010/08/10-------<<<<<
                    return;
                }

                // ���Ӑ�|���O���[�v�R�[�h�擾
                int custRateGrpCode = this.tNedit_CustRateGrpCodeZero.GetInt();

                // ���Ӑ�|���O���[�v���擾
                string custRateGrpName = GetCustRateGrpName(custRateGrpCode);

                if (custRateGrpName == "")
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "�}�X�^�ɓo�^����Ă��܂���B",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);

                    this.tNedit_CustRateGrpCodeZero.Clear();
                    this.tEdit_CustRateGrpName.Clear();

                    e.NextCtrl = e.PrevCtrl;
                    return;
                }

                this.tNedit_CustRateGrpCodeZero.DataText = custRateGrpCode.ToString("0000");
                this.tEdit_CustRateGrpName.DataText = custRateGrpName;

                if (this.tEdit_CustRateGrpName.DataText.Trim() != "")
                {
                    // -------UPD 2009/12/15------->>>>>
                    //SearchAfterLeaveControl();
                    if (this._prevCustRateGrpCode != custRateGrpCode)
                    {
                        SearchAfterLeaveControl();
                    }

                    this._prevCustRateGrpCode = custRateGrpCode;
                    // -------UPD 2009/12/15-------<<<<<

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = null;
                            SetNextFocus(8);
                        }
                    }
                }
                // -------ADD 2010/08/10------->>>>>
                if (e.ShiftKey == false)
                {
                    if (e.Key == Keys.Left)
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                }
                // -------ADD 2010/08/10-------<<<<<
            }
            // --- ADD 2009/01/13 ---------------------------------------------------------------------<<<<<
            // �d����R�[�h
            else if (e.PrevCtrl == this.tNedit_SupplierCd)
            {
                if (this.tNedit_SupplierCd.GetInt() == 0)
                {
                    this.SupplierCdNm_tEdit.Clear();
                    // -------ADD 2009/12/15------->>>>>
                    this._prevSupplierCode = -1;
                    // -------ADD 2009/12/15-------<<<<<
                    // -------ADD 2010/08/10------->>>>>
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Down))
                        {
                            if (SetDetailFocus(e.NextCtrl))
                            {
                                e.NextCtrl = null;
                            }
                        }
                        if (e.Key == Keys.Left)
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    // -------ADD 2010/08/10-------<<<<<
                    return;
                }

                // �d����R�[�h�擾
                int supplierCode = this.tNedit_SupplierCd.GetInt();

                // �d���於�̎擾
                string supplierName = GetSupplierName(supplierCode);

                //if (supplierName == "")   // DEL 2009/06/29
                if (!CheckSupplier(supplierCode))   // ADD 2009/06/29
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "�}�X�^�ɓo�^����Ă��܂���B",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);

                    this.SupplierCdNm_tEdit.Clear();
                    this.tNedit_SupplierCd.SelectAll();

                    e.NextCtrl = e.PrevCtrl;
                    return;
                }

                this.SupplierCdNm_tEdit.DataText = supplierName;

                //if (this.SupplierCdNm_tEdit.DataText.Trim() != "")    // DEL 2009/06/29
                if (CheckSupplier(supplierCode))    // ADD 2009/06/29
                {
                    // -------UPD 2009/12/15------->>>>>
                    //SearchAfterLeaveControl();
                    if (this._prevSupplierCode != supplierCode)
                    {
                        SearchAfterLeaveControl();
                    }

                    this._prevSupplierCode = supplierCode;
                    // -------UPD 2009/12/15-------<<<<<

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = null;
                            SetNextFocus(2);
                        }
                    }
                }
                // -------ADD 2010/08/10------->>>>>
                if (e.ShiftKey == false)
                {
                    if (e.Key == Keys.Left)
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                }
                // -------ADD 2010/08/10-------<<<<<
            }
            // ���[�J�[�R�[�h
            else if (e.PrevCtrl == this.tNedit_GoodsMakerCd)
            {
                if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                {
                    this._prevMakerCode = 0;    // ADD 2009/06/16
                    this.MakerName_tEdit.Clear();
                    this.tEdit_GoodsName.Clear();
                    // -------ADD 2009/12/15------->>>>>
                    this._prevMakerCode = -1;
                    // -------ADD 2009/12/15-------<<<<<
                    // -------ADD 2010/08/10------->>>>>
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Down))
                        {
                            if (SetDetailFocus(e.NextCtrl))
                            {
                                e.NextCtrl = null;
                            }
                        }
                        if ((e.Key == Keys.Left))
                        {
                            if (this.SupplierGuide_Button.Enabled == true)
                            {
                                e.NextCtrl = this.SupplierGuide_Button;
                            }
                            else if (this.CustRateGrpGuide_Button.Enabled == true)
                            {
                                e.NextCtrl = this.CustRateGrpGuide_Button;
                            }
                            else if (this.CustomerGuide_Button.Enabled == true)
                            {
                                e.NextCtrl = this.CustomerGuide_Button;
                            }
                            else
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                    }
                    // -------ADD 2010/08/10-------<<<<<
                    return;
                }

                // --- ADD 2009/03/23 -------------------------------->>>>>
                // �O��ݒ�l�ƕύX�Ȃ�
                if (this._prevMakerCode == this.tNedit_GoodsMakerCd.GetInt())
                {
                    // --- ADD 2010/08/20 -------------------------------->>>>>
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = null;
                            SetNextFocus(3);
                        }
                    }
                    // --- ADD 2010/08/20 --------------------------------<<<<<
                    return;
                }
                // --- ADD 2009/03/23 --------------------------------<<<<<

                // ���[�J�[�R�[�h�擾
                int makerCode = this.tNedit_GoodsMakerCd.GetInt();

                // ���[�J�[���̎擾
                string makerName = GetMakerName(makerCode);

                if (makerName == "")
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "�}�X�^�ɓo�^����Ă��܂���B",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);

                    this.MakerName_tEdit.Clear();
                    this.tNedit_GoodsMakerCd.SelectAll();

                    e.NextCtrl = e.PrevCtrl;
                    return;
                }

                this.MakerName_tEdit.DataText = makerName;

                if (this.MakerName_tEdit.DataText.Trim() != "")
                {
                    SearchAfterLeaveControl();

                    // -------ADD 2009/12/15------->>>>>
                    this._prevMakerCode = makerCode;
                    // -------ADD 2009/12/15-------<<<<<

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = null;
                            SetNextFocus(3);
                        }
                    }
                }

                // ���i�R�[�h�擾
                string goodsCode = this.tEdit_GoodsNo.DataText.Trim();

                if (goodsCode == "")
                {
                    return;
                }

                int status;
                GoodsUnitData goodsUnitData;

                status = GetGoodsInfo(out goodsUnitData, goodsCode);
                if (status == 0)
                {
                    // �i��
                    this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo.Trim();

                    // �i��
                    this.tEdit_GoodsName.DataText = goodsUnitData.GoodsNameKana.Trim();

                    // �艿
                    List<GoodsPrice> goodsPriceList = goodsUnitData.GoodsPriceList;
                    this.tNedit_Price.SetValue(GetPrice(goodsPriceList));
                }
                else
                {
                    if (status != -1)
                    {
                        // �i��
                        this.tEdit_GoodsNo.Clear();

                        // �i��
                        this.tEdit_GoodsName.Clear();

                        // �艿
                        this.tNedit_Price.Clear();
                    }
                }
                // -------ADD 2010/08/10------->>>>>
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Left))
                    {
                        if (this.SupplierGuide_Button.Enabled == true)
                        {
                            e.NextCtrl = this.SupplierGuide_Button;
                        }
                        else if (this.CustRateGrpGuide_Button.Enabled == true)
                        {
                            e.NextCtrl = this.CustRateGrpGuide_Button;
                        }
                        else if (this.CustomerGuide_Button.Enabled == true)
                        {
                            e.NextCtrl = this.CustomerGuide_Button;
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                }
                // -------ADD 2010/08/10-------<<<<<
            }
            // ���i�|���f
            else if (e.PrevCtrl == this.tNedit_GoodsMGroup)
            {
                if (this.tNedit_GoodsMGroup.GetInt() == 0)
                {
                    this.GoodsRateGrpName_tEdit.Clear();
                    // -------ADD 2009/12/15------->>>>>
                    this._prevGoodsRateGrpCode = -1;
                    // -------ADD 2009/12/15-------<<<<<
                    // -------ADD 2010/08/10------->>>>>
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Down))
                        {
                            if (SetDetailFocus(e.NextCtrl))
                            {
                                e.NextCtrl = null;
                            }
                        }
                        if ((e.Key == Keys.Left))
                        {
                            if (this.SupplierGuide_Button.Enabled == true)
                            {
                                e.NextCtrl = this.SupplierGuide_Button;
                            }
                            else if (this.CustRateGrpGuide_Button.Enabled == true)
                            {
                                e.NextCtrl = this.CustRateGrpGuide_Button;
                            }
                            else if (this.CustomerGuide_Button.Enabled == true)
                            {
                                e.NextCtrl = this.CustomerGuide_Button;
                            }
                            else
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                    }
                    // -------ADD 2010/08/10-------<<<<<
                    return;
                }

                // ���i�|���f�R�[�h�擾
                int goodsRateGrpCode = this.tNedit_GoodsMGroup.GetInt();

                // ���i�|���f���̎擾
                string goodsRateGrpName = GetGoodsMGroupName(goodsRateGrpCode);

                if (goodsRateGrpName == "")
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "�}�X�^�ɓo�^����Ă��܂���B",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);

                    this.GoodsRateGrpName_tEdit.Clear();
                    this.tNedit_GoodsMGroup.SelectAll();

                    e.NextCtrl = e.PrevCtrl;
                    return;
                }

                this.GoodsRateGrpName_tEdit.DataText = goodsRateGrpName;

                if (this.GoodsRateGrpName_tEdit.DataText.Trim() != "")
                {
                    // -------UPD 2009/12/15------->>>>>
                    //SearchAfterLeaveControl();
                    if (this._prevGoodsRateGrpCode != goodsRateGrpCode)
                    {
                        SearchAfterLeaveControl();
                    }

                    this._prevGoodsRateGrpCode = goodsRateGrpCode;
                    // -------UPD 2009/12/15-------<<<<<

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = null;
                            SetNextFocus(4);
                        }
                    }
                }
                // -------ADD 2010/08/10------->>>>>
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Left))
                    {
                        if (this.SupplierGuide_Button.Enabled == true)
                        {
                            e.NextCtrl = this.SupplierGuide_Button;
                        }
                        else if (this.CustRateGrpGuide_Button.Enabled == true)
                        {
                            e.NextCtrl = this.CustRateGrpGuide_Button;
                        }
                        else if (this.CustomerGuide_Button.Enabled == true)
                        {
                            e.NextCtrl = this.CustomerGuide_Button;
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                }
                // -------ADD 2010/08/10-------<<<<<
            }
            // �O���[�v�R�[�h
            else if (e.PrevCtrl == this.tNedit_BLGloupCode)
            {
                if (this.tNedit_BLGloupCode.GetInt() == 0)
                {
                    this.BLGroupName_tEdit.Clear();
                    // -------ADD 2009/12/15------->>>>>
                    this._prevBLGroupCode = -1;
                    // -------ADD 2009/12/15-------<<<<<
                    // -------ADD 2010/08/10------->>>>>
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Down))
                        {
                            if (SetDetailFocus(e.NextCtrl))
                            {
                                e.NextCtrl = null;
                            }
                        }
                        if ((e.Key == Keys.Left))
                        {
                            if (this.SupplierGuide_Button.Enabled == true)
                            {
                                e.NextCtrl = this.SupplierGuide_Button;
                            }
                            else if (this.CustRateGrpGuide_Button.Enabled == true)
                            {
                                e.NextCtrl = this.CustRateGrpGuide_Button;
                            }
                            else if (this.CustomerGuide_Button.Enabled == true)
                            {
                                e.NextCtrl = this.CustomerGuide_Button;
                            }
                            else
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                    }
                    // -------ADD 2010/08/10-------<<<<<
                    return;
                }

                // BL�O���[�v�R�[�h�擾
                int blGroupCode = this.tNedit_BLGloupCode.GetInt();

                // BL�O���[�v����
                string blGroupName = GetBLGroupName(blGroupCode);

                if (blGroupName == "")
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "�}�X�^�ɓo�^����Ă��܂���B",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);

                    this.BLGroupName_tEdit.Clear();
                    this.tNedit_BLGloupCode.SelectAll();

                    e.NextCtrl = e.PrevCtrl;
                    return;
                }

                this.BLGroupName_tEdit.DataText = blGroupName;

                if (this.BLGroupName_tEdit.DataText.Trim() != "")
                {
                    // -------UPD 2009/12/15------->>>>>
                    //SearchAfterLeaveControl();
                    if (this._prevBLGroupCode != blGroupCode)
                    {
                        SearchAfterLeaveControl();
                    }

                    this._prevBLGroupCode = blGroupCode;
                    // -------UPD 2009/12/15-------<<<<<

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = null;
                            SetNextFocus(5);
                        }
                    }
                }
                // -------ADD 2010/08/10------->>>>>
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Left))
                    {
                        if (this.SupplierGuide_Button.Enabled == true)
                        {
                            e.NextCtrl = this.SupplierGuide_Button;
                        }
                        else if (this.CustRateGrpGuide_Button.Enabled == true)
                        {
                            e.NextCtrl = this.CustRateGrpGuide_Button;
                        }
                        else if (this.CustomerGuide_Button.Enabled == true)
                        {
                            e.NextCtrl = this.CustomerGuide_Button;
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                }
                // -------ADD 2010/08/10-------<<<<<
            }
            // BL�R�[�h
            else if (e.PrevCtrl == this.tNedit_BLGoodsCode)
            {
                if (this.tNedit_BLGoodsCode.GetInt() == 0)
                {
                    this.BLGoodsName_tEdit.Clear();
                    // -------ADD 2009/12/15------->>>>>
                    this._prevBLGoodsCode = -1;
                    // -------ADD 2009/12/15-------<<<<<
                    // -------ADD 2010/08/10------->>>>>
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Down))
                        {
                            if (SetDetailFocus(e.NextCtrl))
                            {
                                e.NextCtrl = null;
                            }
                        }

                        if ((e.Key == Keys.Left))
                        {
                            if (this.SupplierGuide_Button.Enabled == true)
                            {
                                e.NextCtrl = this.SupplierGuide_Button;
                            }
                            else if (this.CustRateGrpGuide_Button.Enabled == true)
                            {
                                e.NextCtrl = this.CustRateGrpGuide_Button;
                            }
                            else if (this.CustomerGuide_Button.Enabled == true)
                            {
                                e.NextCtrl = this.CustomerGuide_Button;
                            }
                            else
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                    }
                    // -------ADD 2010/08/10-------<<<<<
                    return;
                }

                // BL�R�[�h�擾
                int blGoodsCode = this.tNedit_BLGoodsCode.GetInt();

                // BL���̎擾
                string blGoodsName = GetBLGoodsName(blGoodsCode);

                if (blGoodsName == "")
                {
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "�}�X�^�ɓo�^����Ă��܂���B",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);

                    this.BLGoodsName_tEdit.Clear();
                    this.tNedit_BLGoodsCode.SelectAll();

                    e.NextCtrl = e.PrevCtrl;
                    return;
                }

                this.BLGoodsName_tEdit.DataText = blGoodsName;

                if (this.BLGoodsName_tEdit.DataText.Trim() != "")
                {
                    // -------UPD 2009/12/15------->>>>>
                    //SearchAfterLeaveControl();
                    if (this._prevBLGoodsCode != blGoodsCode)
                    {
                        SearchAfterLeaveControl();
                    }

                    this._prevBLGoodsCode = blGoodsCode;
                    // -------UPD 2009/12/15-------<<<<<

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = null;
                            SetNextFocus(6);
                        }
                    }
                }
                // -------ADD 2010/08/10------->>>>>
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Left))
                    {
                        if (this.SupplierGuide_Button.Enabled == true)
                        {
                            e.NextCtrl = this.SupplierGuide_Button;
                        }
                        else if (this.CustRateGrpGuide_Button.Enabled == true)
                        {
                            e.NextCtrl = this.CustRateGrpGuide_Button;
                        }
                        else if (this.CustomerGuide_Button.Enabled == true)
                        {
                            e.NextCtrl = this.CustomerGuide_Button;
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                }
                // -------ADD 2010/08/10-------<<<<<

            }
            // �i��
            else if (e.PrevCtrl == this.tEdit_GoodsNo)
            {
                if (this.tEdit_GoodsNo.DataText.Trim() == "")
                {
                    this.tEdit_GoodsName.Clear();
                    this.tNedit_Price.Clear();
                    // -------ADD 2009/12/15------->>>>>
                    this._prevGoodsNo = string.Empty;
                    // -------ADD 2009/12/15-------<<<<<
                    // -------ADD 2010/08/10------->>>>>
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Down) || e.Key == Keys.Tab)
                        {
                            if (SetDetailFocus(e.NextCtrl))
                            {
                                e.NextCtrl = null;
                            }
                        }
                        if ((e.Key == Keys.Left))
                        {
                            if (this.SupplierGuide_Button.Enabled == true)
                            {
                                e.NextCtrl = this.SupplierGuide_Button;
                            }
                            else if (this.CustRateGrpGuide_Button.Enabled == true)
                            {
                                e.NextCtrl = this.CustRateGrpGuide_Button;
                            }
                            else if (this.CustomerGuide_Button.Enabled == true)
                            {
                                e.NextCtrl = this.CustomerGuide_Button;
                            }
                            else
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                    }
                    // -------ADD 2010/08/10-------<<<<<
                    return;
                }

                // --- ADD 2009/03/23 -------------------------------->>>>>
                // �O��ݒ�l�ƕύX�Ȃ�
                if (this._prevGoodsNo == this.tEdit_GoodsNo.DataText.Trim())
                {
                    // -------ADD 2010/08/10------->>>>>
                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Down) || e.Key == Keys.Tab)
                        {
                            if (SetDetailFocus(e.NextCtrl))
                            {
                                e.NextCtrl = null;
                            }
                        }
                        if ((e.Key == Keys.Left))
                        {
                            if (this.SupplierGuide_Button.Enabled == true)
                            {
                                e.NextCtrl = this.SupplierGuide_Button;
                            }
                            else if (this.CustRateGrpGuide_Button.Enabled == true)
                            {
                                e.NextCtrl = this.CustRateGrpGuide_Button;
                            }
                            else if (this.CustomerGuide_Button.Enabled == true)
                            {
                                e.NextCtrl = this.CustomerGuide_Button;
                            }
                            else
                            {
                                e.NextCtrl = e.PrevCtrl;
                            }
                        }
                    }
                    // -------ADD 2010/08/10-------<<<<<
                    return;
                }
                // --- ADD 2009/03/23 --------------------------------<<<<<

                // ���i�R�[�h�擾
                string goodsCode = this.tEdit_GoodsNo.DataText.Trim();

                // ���i���̎擾
                GoodsUnitData goodsUnitData;
                //int status = GetGoodsInfo(out goodsUnitData, goodsCode); // DEL 2009/03/16
                int status = GetGoodsInfo(out goodsUnitData, goodsCode, 0);

                if (status == 0)
                {
                    // �i��
                    this.tEdit_GoodsNo.DataText = goodsUnitData.GoodsNo.Trim();
                    this._prevGoodsNo = goodsUnitData.GoodsNo.Trim(); // ADD 2009/03/23

                    // �i��
                    this.tEdit_GoodsName.DataText = goodsUnitData.GoodsNameKana.Trim();

                    // ���[�J�[
                    this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd);
                    this.MakerName_tEdit.DataText = goodsUnitData.MakerName.Trim();
                    this._prevMakerCode = goodsUnitData.GoodsMakerCd;

                    // �艿
                    List<GoodsPrice> goodsPriceList = goodsUnitData.GoodsPriceList;
                    this.tNedit_Price.SetValue(GetPrice(goodsPriceList));

                    SearchAfterLeaveControl();
                }
                else
                {
                    if (status == -1)
                    {
                        this.tEdit_GoodsNo.Clear();
                        this.tEdit_GoodsName.Clear();
                        this.tNedit_Price.Clear();
                        e.NextCtrl = e.PrevCtrl;
                        return;
                    }
                    else
                    {
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_INFO,
                                   "�}�X�^�ɓo�^����Ă��܂���B",
                                   0,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);

                        this.tNedit_Price.Clear();
                        this.tEdit_GoodsName.Clear();
                        this.tEdit_GoodsNo.SelectAll();

                        e.NextCtrl = e.PrevCtrl;
                        return;
                    }
                }

                if (e.ShiftKey == false)
                {
                    if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                    {
                        e.NextCtrl = null;
                        // �t�H�[�J�X�ݒ�
                        for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
                        {
                            for (int rowIndex = 0; rowIndex < ROW_COUNT; rowIndex++)
                            {
                                if (this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Activation != Activation.AllowEdit)
                                {
                                    continue;
                                }

                                if (this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activation != Activation.AllowEdit)
                                {
                                    continue;
                                }

                                this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activate();
                                this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                                return;
                            }
                        }
                    }
                    // -------ADD 2010/08/10------->>>>>
                    if ((e.Key == Keys.Left))
                    {
                        if (this.SupplierGuide_Button.Enabled == true)
                        {
                            e.NextCtrl = this.SupplierGuide_Button;
                        }
                        else if (this.CustRateGrpGuide_Button.Enabled == true)
                        {
                            e.NextCtrl = this.CustRateGrpGuide_Button;
                        }
                        else if (this.CustomerGuide_Button.Enabled == true)
                        {
                            e.NextCtrl = this.CustomerGuide_Button;
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                    // -------ADD 2010/08/10-------<<<<<
                }
            }
            // ADD 2008/10/29 �s��Ή�[7174] ---------->>>>>
            // �w��
            else if (e.PrevCtrl == this.GoodsRateRank_tEdit)
            {
                if (this.GoodsRateRank_tEdit.DataText.Trim() != "")
                {
                    // -------UPD 2009/12/15------->>>>>
                    //SearchAfterLeaveControl();
                    if (!this._prevGoodsRateRank.Equals(this.GoodsRateRank_tEdit.DataText.Trim()))
                    {
                        SearchAfterLeaveControl();
                    }

                    this._prevGoodsRateRank = this.GoodsRateRank_tEdit.DataText.Trim();
                    // -------UPD 2009/12/15-------<<<<<

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = null;
                            SetNextFocus(7);
                        }
                    }
                }
                else
                {
                    // -------ADD 2009/12/15------->>>>>
                    this._prevGoodsRateRank = string.Empty;
                    // -------ADD 2009/12/15-------<<<<<
                }

                // -------ADD 2010/08/10------->>>>>
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Left))
                    {
                        if (this.SupplierGuide_Button.Enabled == true)
                        {
                            e.NextCtrl = this.SupplierGuide_Button;
                        }
                        else if (this.CustRateGrpGuide_Button.Enabled == true)
                        {
                            e.NextCtrl = this.CustRateGrpGuide_Button;
                        }
                        else if (this.CustomerGuide_Button.Enabled == true)
                        {
                            e.NextCtrl = this.CustomerGuide_Button;
                        }
                        else
                        {
                            e.NextCtrl = e.PrevCtrl;
                        }
                    }
                }
                // -------ADD 2010/08/10-------<<<<<
            }
            //-----ADD 2010/08/10---------->>>>>
            // �P�����
            else if (e.PrevCtrl == this.UnitPriceKind_tComboEditor)
            {
                if (this.setTComboEditorByName(e.PrevCtrl.Name))
                {
                    this.UnitPriceKind_tComboEditor.Value = this._prevUnitPriceKindObj;
                }
                else
                {
                    this._prevUnitPriceKindObj = (string)this.UnitPriceKind_tComboEditor.Value;
                }

                e.PrevCtrl.Focus();
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Right) || (e.Key == Keys.Left))
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                }
            }
            // �ݒ���@
            else if (e.PrevCtrl == this.UnitPriceKindWay_tComboEditor)
            {
                if (this.setTComboEditorByNameForWay(e.PrevCtrl.Name))
                {
                    this.UnitPriceKindWay_tComboEditor.Value = this._prevUnitPriceKindWayObj;
                }
                else
                {
                    if ("2".Equals(this.UnitPriceKindWay_tComboEditor.Text) || UNITPRICEKINDWAY_0.Equals(this.UnitPriceKindWay_tComboEditor.Text))
                    {
                        this._prevUnitPriceKindWayObj = "0";
                        this.UnitPriceKindWay_tComboEditor.Value = 0;
                    }
                    else
                    {
                        this._prevUnitPriceKindWayObj = this.UnitPriceKindWay_tComboEditor.Value;
                    }
                }

                e.PrevCtrl.Focus();
                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Right) || (e.Key == Keys.Left))
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                }
            }
            //�|���ݒ�敪�K�C�h
            else if (e.PrevCtrl == this.RateSettingDivideGuide_Button)
            {
                if (e.ShiftKey == false)
                {
                    if (e.Key == Keys.Right)
                    {
                        e.NextCtrl = e.PrevCtrl;
                    }
                }
            }
            //-----ADD 2010/08/10----------<<<<<
            // ADD 2008/10/29 �s��Ή�[7174] ----------<<<<<

            //-----ADD 2010/08/10---------->>>>>
            //---------------------------------------------------------------
            // �{�^���c�[���L�������ݒ菈��
            //---------------------------------------------------------------
            if ((e.NextCtrl != null) && (e.NextCtrl.TabStop))
            {
                this.SettingGuideButtonToolEnabled(e.NextCtrl);
            }
            //-----ADD 2010/08/10----------<<<<<
            //-----UPD 2010/08/10---------->>>>>
            //if ((e.NextCtrl != this.Detail_uGrid) || (this.Detail_uGrid.Enabled != true))
            if (!(e.NextCtrl == this.Detail_uGrid || e.NextCtrl == this.Detail_panel) || (this.Detail_uGrid.Enabled != true))
            //-----UPD 2010/08/10----------<<<<<
            {
                return;
            }
            //-----UPD 2010/08/10---------->>>>>
           
            // �^�u�ړ��A�܂��̓J�[�\���ړ��ŃO���b�h�Ƀt�H�[�J�X�������������̃A�N�e�B�u�Z����ݒ肵�܂�
            if (e.ShiftKey == false)
            {
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Down))
                {
                    if (SetDetailFocus(e.NextCtrl))
                    {
                        e.NextCtrl = null;
                    }
                }
            }
            return;
            //for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
            //{
            //    for (int rowIndex = 0; rowIndex < ROW_COUNT; rowIndex++)
            //    {
            //        if (this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Activation != Activation.AllowEdit)
            //        {
            //            continue;
            //        }

            //        if (this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activation != Activation.AllowEdit)
            //        {
            //            continue;
            //        }

            //        e.NextCtrl = null;
            //        this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activate();
            //        this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
            //        return;
            //    }
            //}
            //-----UPD 2010/08/10----------<<<<<
        }

        /// <summary>
        /// Leave �C�x���g 
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void Detail_uGrid_Leave(object sender, EventArgs e)
        {
            this.Detail_uGrid.ActiveCell = null;
            this.Detail_uGrid.ActiveRow = null;
        }

        /// <summary>
        /// Shown �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <br>Update Note : 2010/08/10 �k���r PM1012�Ή�</br>
        /// <br>              �K�C�h���u�e�T�v�{�^���ŕ\������悤�ɕύX</br>
        private void DCKHN09160UA_Shown(object sender, EventArgs e)
        {
            if (this._firstFlg)
            {
                this.tEdit_SectionCodeAllowZero.Focus();
                //-----ADD 2010/08/10---------->>>>>
                SettingGuideButtonToolEnabled(tEdit_SectionCodeAllowZero);
                //-----ADD 2010/08/10----------<<<<<
            }

            this._firstFlg = false;
        }

        #endregion Control Events

        //-----ADD 2010/08/10---------->>>>>
        /// <summary>
        /// AfterCellUpdate �C�x���g(Detail_uGrid)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �Z���̒l���ύX���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �k���r </br>
        /// <br>Date        : 2010/08/10 </br>
        ///                   ���X�g���ڂ��R�[�h����ł����͉\�֕ύX</br>
        /// </remarks>
        private void Detail_uGrid_AfterCellUpdate(object sender, CellEventArgs e)
        {
            int rowIndex = e.Cell.Row.Index;
            int columnIndex = e.Cell.Column.Index;

            if (rowIndex == ROWINDEX_UNPRCFRACPROCDIV && (!e.Cell.Value.Equals(this._preDCEditorValue)))
            {
                string targetValue = (string)e.Cell.Text;
                if (string.IsNullOrEmpty(targetValue))
                {
                    e.Cell.Value = this._preDCEditorValue;
                    return;
                }
                if ("1".Equals(targetValue) || UNPRCFRACPROCDIV_1.Equals(targetValue))
                {
                    this._preDCEditorValue = (string)e.Cell.Value;
                    e.Cell.Value = "1";
                    return;
                }
                else if ("2".Equals(targetValue) || UNPRCFRACPROCDIV_2.Equals(targetValue))
                {
                    this._preDCEditorValue = (string)e.Cell.Value;
                    e.Cell.Value = "2";
                    return;
                }
                else if ("3".Equals(targetValue) || UNPRCFRACPROCDIV_3.Equals(targetValue))
                {
                    this._preDCEditorValue = (string)e.Cell.Value;
                    e.Cell.Value = "3";
                    return;
                }
                else
                {
                    e.Cell.Value = this._preDCEditorValue;
                    return;
                }
            }
            return;
        }

        /// <summary>
        /// Leave �C�x���g(ComboEditor)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: ���X�g���ڂ���Leave�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �k���r </br>
        /// <br>Date        : 2010/08/10 </br>
        ///                   ���X�g���ڂ��R�[�h����ł����͉\�֕ύX</br>
        /// </remarks>
        private void UnitPriceKindWay_tComboEditor_Leave(object sender, EventArgs e)
        {
            if (!("2".Equals(this.UnitPriceKindWay_tComboEditor.Text)
                || UNITPRICEKINDWAY_0.Equals(this.UnitPriceKindWay_tComboEditor.Text))
                && !(1 as object).Equals(this.UnitPriceKindWay_tComboEditor.Value))
            {
                this.UnitPriceKindWay_tComboEditor.Value = this._prevUnitPriceKindWayObj;
            }

            if ("2".Equals(this.UnitPriceKindWay_tComboEditor.Text) || UNITPRICEKINDWAY_0.Equals(this.UnitPriceKindWay_tComboEditor.Text))
            {
                this.UnitPriceKindWay_tComboEditor.Value = 0;
            }
        }
        //-----ADD 2010/08/10----------<<<<<
    }
}