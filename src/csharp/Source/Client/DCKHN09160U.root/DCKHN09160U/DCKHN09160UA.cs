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
    /// <br>Date		: 2008/06/18</br>
    /// <br>Update Note : 2008/09/10 30414 �E �K�j</br>
    /// <br>            �@�E���̕ύX�u�艿UP���v���u���iUP���v�u���i�����ށv���u���i�|���f�v</br>
    /// <br>Update Note : 2009/03/16 30452 ��� �r��</br>
    /// <br>             �E��Q�Ή�12346</br>
	/// </remarks>
	public partial class DCKHN09160UA : Form
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
            Infragistics.Win.Appearance appearance133 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance134 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance129 = new Infragistics.Win.Appearance();
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
            Infragistics.Win.Appearance appearance119 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance120 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance121 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance122 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance136 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance123 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo7 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("�d����K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo8 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("���Ӑ�K�C�h", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance126 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance127 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance69 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Menu_Toolbar");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool1 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenu");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool2 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenu");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool1 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("PayAddUpSec_LabelTool");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar2 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("Button_Toolbar");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Exit_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("New_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Save_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Delete_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Revival_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool3 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("File_PopupMenu");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("New_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Save_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Exit_ButtonTool");
            Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenuTool4 = new Infragistics.Win.UltraWinToolbars.PopupMenuTool("Window_PopupMenu");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Delete_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Revival_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("Dummy_LabelTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Exit_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool12 = new Infragistics.Win.UltraWinToolbars.ButtonTool("InitWindow_ButtonTool");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("PayAddUpSec_LabelTool");
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Save_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("New_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Delete_ButtonTool");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("Revival_ButtonTool");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKHN09160UA));
            this.Main_panel = new System.Windows.Forms.Panel();
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
            this.CustRateGrpCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Customer_Title_uLabel = new Infragistics.Win.Misc.UltraLabel();
            this.CustRateGrpCode_Label = new Infragistics.Win.Misc.UltraLabel();
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
            this._SFSIR02101UA_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Main_ToolbarsManager = new Broadleaf.Library.Windows.Forms.TToolbarsManager(this.components);
            this._SFSIR02101UA_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFSIR02101UA_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._SFSIR02101UA_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
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
            ((System.ComponentModel.ISupportInitialize)(this.CustRateGrpCode_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCdNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCodeNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShape2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).BeginInit();
            this.SuspendLayout();
            // 
            // Main_panel
            // 
            this.Main_panel.Controls.Add(this.tNedit_Price);
            this.Main_panel.Controls.Add(this.Price_uLabel);
            this.Main_panel.Controls.Add(this.Detail_panel);
            this.Main_panel.Controls.Add(this.RateCond_panel);
            this.Main_panel.Controls.Add(this.Goods_panel);
            this.Main_panel.Controls.Add(this.Customer_panel);
            this.Main_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_panel.Location = new System.Drawing.Point(0, 63);
            this.Main_panel.Name = "Main_panel";
            this.Main_panel.Padding = new System.Windows.Forms.Padding(5);
            this.Main_panel.Size = new System.Drawing.Size(992, 551);
            this.Main_panel.TabIndex = 0;
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
            this.tNedit_Price.Location = new System.Drawing.Point(92, 253);
            this.tNedit_Price.MaxLength = 9;
            this.tNedit_Price.Name = "tNedit_Price";
            this.tNedit_Price.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, false, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_Price.ReadOnly = true;
            this.tNedit_Price.Size = new System.Drawing.Size(82, 24);
            this.tNedit_Price.TabIndex = 900;
            // 
            // Price_uLabel
            // 
            appearance129.ForeColorDisabled = System.Drawing.Color.Black;
            appearance129.TextHAlignAsString = "Left";
            appearance129.TextVAlignAsString = "Middle";
            this.Price_uLabel.Appearance = appearance129;
            this.Price_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.Price_uLabel.Location = new System.Drawing.Point(33, 253);
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
            this.Detail_panel.Location = new System.Drawing.Point(3, 285);
            this.Detail_panel.Name = "Detail_panel";
            this.Detail_panel.Size = new System.Drawing.Size(985, 262);
            this.Detail_panel.TabIndex = 69;
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
            appearance17.BackColor = System.Drawing.SystemColors.Window;
            appearance17.ForeColor = System.Drawing.SystemColors.ControlText;
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
            this.Detail_uGrid.Location = new System.Drawing.Point(159, 3);
            this.Detail_uGrid.Name = "Detail_uGrid";
            this.Detail_uGrid.Size = new System.Drawing.Size(822, 256);
            this.Detail_uGrid.TabIndex = 70;
            this.Detail_uGrid.AfterExitEditMode += new System.EventHandler(this.Detail_uGrid_AfterExitEditMode);
            this.Detail_uGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Detail_uGrid_KeyDown);
            this.Detail_uGrid.AfterEnterEditMode += new System.EventHandler(this.Detail_uGrid_AfterEnterEditMode);
            this.Detail_uGrid.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.Detail_uGrid_CellChange);
            this.Detail_uGrid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Detail_uGrid_KeyPress);
            this.Detail_uGrid.Leave += new System.EventHandler(this.Detail_uGrid_Leave);
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
            this.ultraLabel15.Location = new System.Drawing.Point(5, 222);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(155, 19);
            this.ultraLabel15.TabIndex = 900;
            this.ultraLabel15.Text = "�P���[�������敪";
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
            this.ultraLabel14.Location = new System.Drawing.Point(5, 204);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(155, 19);
            this.ultraLabel14.TabIndex = 900;
            this.ultraLabel14.Text = "�P���[�������P��";
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
            this.ultraLabel13.Location = new System.Drawing.Point(65, 186);
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
            this.ultraLabel12.Location = new System.Drawing.Point(65, 168);
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
            this.ultraLabel11.Location = new System.Drawing.Point(5, 169);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(61, 36);
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
            this.ultraLabel9.Location = new System.Drawing.Point(65, 150);
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
            this.ultraLabel8.Location = new System.Drawing.Point(65, 132);
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
            this.ultraLabel10.Location = new System.Drawing.Point(5, 132);
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
            this.ultraLabel7.Location = new System.Drawing.Point(65, 114);
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
            this.ultraLabel6.Location = new System.Drawing.Point(65, 96);
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
            this.ultraLabel5.Location = new System.Drawing.Point(65, 78);
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
            this.ultraLabel4.Location = new System.Drawing.Point(65, 60);
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
            this.ultraLabel3.Location = new System.Drawing.Point(5, 60);
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
            this.ultraLabel2.Location = new System.Drawing.Point(5, 42);
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
            this.ultraLabel1.Location = new System.Drawing.Point(5, 24);
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
            this.tShape3.Size = new System.Drawing.Size(985, 262);
            this.tShape3.TabIndex = 1138;
            // 
            // RateCond_panel
            // 
            this.RateCond_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
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
            this.RateCond_panel.Location = new System.Drawing.Point(3, 3);
            this.RateCond_panel.Name = "RateCond_panel";
            this.RateCond_panel.Size = new System.Drawing.Size(985, 84);
            this.RateCond_panel.TabIndex = 1;
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
            this.tNedit_RatePriorityOrder.Location = new System.Drawing.Point(602, 3);
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
            this.ultraLabel16.Location = new System.Drawing.Point(522, 3);
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
            this.SectionGuide_Button.Location = new System.Drawing.Point(266, 3);
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
            this.RateCond_Title_uLabel.Size = new System.Drawing.Size(25, 84);
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
            this.SectionCodeNm_tEdit.Location = new System.Drawing.Point(150, 3);
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
            this.tEdit_SectionCodeAllowZero.Location = new System.Drawing.Point(119, 3);
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
            this.RateMngCustCd_tEdit.Location = new System.Drawing.Point(438, 57);
            this.RateMngCustCd_tEdit.MaxLength = 1;
            this.RateMngCustCd_tEdit.Name = "RateMngCustCd_tEdit";
            this.RateMngCustCd_tEdit.ReadOnly = true;
            this.RateMngCustCd_tEdit.Size = new System.Drawing.Size(20, 24);
            this.RateMngCustCd_tEdit.TabIndex = 20;
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
            this.RateMngCustNm_tEdit.Location = new System.Drawing.Point(461, 57);
            this.RateMngCustNm_tEdit.MaxLength = 50;
            this.RateMngCustNm_tEdit.Name = "RateMngCustNm_tEdit";
            this.RateMngCustNm_tEdit.ReadOnly = true;
            this.RateMngCustNm_tEdit.Size = new System.Drawing.Size(516, 24);
            this.RateMngCustNm_tEdit.TabIndex = 22;
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
            this.RateMngGoodsCd_tEdit.Location = new System.Drawing.Point(438, 30);
            this.RateMngGoodsCd_tEdit.MaxLength = 1;
            this.RateMngGoodsCd_tEdit.Name = "RateMngGoodsCd_tEdit";
            this.RateMngGoodsCd_tEdit.ReadOnly = true;
            this.RateMngGoodsCd_tEdit.Size = new System.Drawing.Size(20, 24);
            this.RateMngGoodsCd_tEdit.TabIndex = 16;
            this.RateMngGoodsCd_tEdit.TabStop = false;
            // 
            // SectionCode_uLabel
            // 
            appearance80.ForeColorDisabled = System.Drawing.Color.Black;
            appearance80.TextHAlignAsString = "Left";
            appearance80.TextVAlignAsString = "Middle";
            this.SectionCode_uLabel.Appearance = appearance80;
            this.SectionCode_uLabel.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.SectionCode_uLabel.Location = new System.Drawing.Point(30, 3);
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
            this.UnitPriceKindWay_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.UnitPriceKindWay_tComboEditor.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            appearance93.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance93.ForeColorDisabled = System.Drawing.Color.Black;
            this.UnitPriceKindWay_tComboEditor.ItemAppearance = appearance93;
            this.UnitPriceKindWay_tComboEditor.Location = new System.Drawing.Point(119, 57);
            this.UnitPriceKindWay_tComboEditor.Name = "UnitPriceKindWay_tComboEditor";
            this.UnitPriceKindWay_tComboEditor.Size = new System.Drawing.Size(153, 24);
            this.UnitPriceKindWay_tComboEditor.TabIndex = 10;
            this.UnitPriceKindWay_tComboEditor.ValueChanged += new System.EventHandler(this.UnitPriceKindWay_tComboEditor_ValueChanged);
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
            this.Mode_Label.Location = new System.Drawing.Point(918, 3);
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
            this.UnitPriceKind_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.UnitPriceKind_tComboEditor.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            appearance100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance100.ForeColorDisabled = System.Drawing.Color.Black;
            this.UnitPriceKind_tComboEditor.ItemAppearance = appearance100;
            this.UnitPriceKind_tComboEditor.Location = new System.Drawing.Point(119, 30);
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
            this.RateMngGoodsNm_tEdit.Location = new System.Drawing.Point(461, 30);
            this.RateMngGoodsNm_tEdit.MaxLength = 50;
            this.RateMngGoodsNm_tEdit.Name = "RateMngGoodsNm_tEdit";
            this.RateMngGoodsNm_tEdit.ReadOnly = true;
            this.RateMngGoodsNm_tEdit.Size = new System.Drawing.Size(516, 24);
            this.RateMngGoodsNm_tEdit.TabIndex = 18;
            this.RateMngGoodsNm_tEdit.TabStop = false;
            // 
            // UnitPriceKind_Label
            // 
            appearance82.ForeColorDisabled = System.Drawing.Color.Black;
            appearance82.TextHAlignAsString = "Left";
            appearance82.TextVAlignAsString = "Middle";
            this.UnitPriceKind_Label.Appearance = appearance82;
            this.UnitPriceKind_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.UnitPriceKind_Label.Location = new System.Drawing.Point(30, 30);
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
            this.RateSettingDivide_tEdit.Location = new System.Drawing.Point(438, 3);
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
            this.RateSettingDivideGuide_Button.Location = new System.Drawing.Point(469, 3);
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
            this.UnitPriceKindWay_Label.Location = new System.Drawing.Point(30, 57);
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
            this.RateMngCust_Label.Location = new System.Drawing.Point(319, 57);
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
            this.RateMngGoods_Label.Location = new System.Drawing.Point(319, 30);
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
            this.RateSettingDivide_Label.Location = new System.Drawing.Point(319, 3);
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
            this.tShape1.Size = new System.Drawing.Size(985, 84);
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
            this.Goods_panel.Location = new System.Drawing.Point(513, 90);
            this.Goods_panel.Name = "Goods_panel";
            this.Goods_panel.Size = new System.Drawing.Size(475, 192);
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
            this.tEdit_GoodsNo.Location = new System.Drawing.Point(152, 138);
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
            this.tNedit_BLGoodsCode.Location = new System.Drawing.Point(152, 111);
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
            this.tNedit_BLGloupCode.Location = new System.Drawing.Point(152, 84);
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
            this.tNedit_GoodsMGroup.Location = new System.Drawing.Point(152, 57);
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
            this.Group_Title_uLabel.Size = new System.Drawing.Size(25, 192);
            this.Group_Title_uLabel.TabIndex = 1106;
            this.Group_Title_uLabel.Text = "���i�ݒ�";
            // 
            // BLGoodsGuide_Button
            // 
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.BLGoodsGuide_Button.Appearance = appearance2;
            this.BLGoodsGuide_Button.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BLGoodsGuide_Button.Location = new System.Drawing.Point(439, 111);
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
            this.BLGroupGuide_Button.Location = new System.Drawing.Point(439, 84);
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
            this.GoodsMakerCd_Grp_Label.Location = new System.Drawing.Point(33, 3);
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
            this.GoodsRateGrpGuide_Button.Location = new System.Drawing.Point(439, 56);
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
            this.GoodsRateRank_Label.Location = new System.Drawing.Point(33, 30);
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
            this.BLGoodsName_tEdit.Location = new System.Drawing.Point(214, 111);
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
            this.tNedit_GoodsMakerCd.Location = new System.Drawing.Point(152, 3);
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
            this.BLGroupName_tEdit.Location = new System.Drawing.Point(214, 84);
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
            this.MakerName_tEdit.Location = new System.Drawing.Point(214, 3);
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
            this.GoodsRateGrpName_tEdit.Location = new System.Drawing.Point(214, 57);
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
            this.MakerGuide_Button.Location = new System.Drawing.Point(439, 3);
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
            this.GoodsNo_Label.Location = new System.Drawing.Point(33, 138);
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
            this.GoodsRateGrp_Label.Location = new System.Drawing.Point(33, 57);
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
            this.BLGroup_Label.Location = new System.Drawing.Point(33, 84);
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
            this.GoodsRateRank_tEdit.Location = new System.Drawing.Point(152, 30);
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
            this.BLGoods_Label.Location = new System.Drawing.Point(33, 111);
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
            this.tEdit_GoodsName.Location = new System.Drawing.Point(152, 165);
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
            this.Goods_tShape.Size = new System.Drawing.Size(475, 192);
            this.Goods_tShape.TabIndex = 1136;
            // 
            // Customer_panel
            // 
            this.Customer_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Customer_panel.Controls.Add(this.CustRateGrpCode_tComboEditor);
            this.Customer_panel.Controls.Add(this.Customer_Title_uLabel);
            this.Customer_panel.Controls.Add(this.CustRateGrpCode_Label);
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
            this.Customer_panel.Location = new System.Drawing.Point(3, 90);
            this.Customer_panel.Name = "Customer_panel";
            this.Customer_panel.Size = new System.Drawing.Size(507, 84);
            this.Customer_panel.TabIndex = 23;
            // 
            // CustRateGrpCode_tComboEditor
            // 
            appearance119.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustRateGrpCode_tComboEditor.ActiveAppearance = appearance119;
            appearance120.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance120.ForeColorDisabled = System.Drawing.Color.Black;
            this.CustRateGrpCode_tComboEditor.Appearance = appearance120;
            this.CustRateGrpCode_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.CustRateGrpCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.CustRateGrpCode_tComboEditor.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance121.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustRateGrpCode_tComboEditor.ItemAppearance = appearance121;
            this.CustRateGrpCode_tComboEditor.Location = new System.Drawing.Point(182, 30);
            this.CustRateGrpCode_tComboEditor.Name = "CustRateGrpCode_tComboEditor";
            this.CustRateGrpCode_tComboEditor.Size = new System.Drawing.Size(280, 24);
            this.CustRateGrpCode_tComboEditor.TabIndex = 30;
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
            this.Customer_Title_uLabel.Size = new System.Drawing.Size(25, 84);
            this.Customer_Title_uLabel.TabIndex = 900;
            this.Customer_Title_uLabel.Text = "�����ݒ�";
            // 
            // CustRateGrpCode_Label
            // 
            appearance136.ForeColorDisabled = System.Drawing.Color.Black;
            appearance136.TextHAlignAsString = "Left";
            appearance136.TextVAlignAsString = "Middle";
            this.CustRateGrpCode_Label.Appearance = appearance136;
            this.CustRateGrpCode_Label.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.CustRateGrpCode_Label.Location = new System.Drawing.Point(30, 30);
            this.CustRateGrpCode_Label.Name = "CustRateGrpCode_Label";
            this.CustRateGrpCode_Label.Size = new System.Drawing.Size(141, 24);
            this.CustRateGrpCode_Label.TabIndex = 900;
            this.CustRateGrpCode_Label.Text = "���Ӑ�|���O���[�v";
            // 
            // SupplierGuide_Button
            // 
            appearance123.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance123.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.SupplierGuide_Button.Appearance = appearance123;
            this.SupplierGuide_Button.Location = new System.Drawing.Point(476, 57);
            this.SupplierGuide_Button.Name = "SupplierGuide_Button";
            this.SupplierGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.SupplierGuide_Button.TabIndex = 36;
            ultraToolTipInfo7.ToolTipText = "�d����K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.SupplierGuide_Button, ultraToolTipInfo7);
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
            this.CustomerCode_Label.Location = new System.Drawing.Point(30, 3);
            this.CustomerCode_Label.Name = "CustomerCode_Label";
            this.CustomerCode_Label.Size = new System.Drawing.Size(117, 24);
            this.CustomerCode_Label.TabIndex = 900;
            this.CustomerCode_Label.Text = "���Ӑ�R�[�h";
            // 
            // tNedit_CustomerCode
            // 
            appearance67.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_CustomerCode.ActiveAppearance = appearance67;
            appearance68.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance68.ForeColorDisabled = System.Drawing.Color.Black;
            appearance68.TextHAlignAsString = "Right";
            this.tNedit_CustomerCode.Appearance = appearance68;
            this.tNedit_CustomerCode.AutoSelect = true;
            this.tNedit_CustomerCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_CustomerCode.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_CustomerCode.DataText = "";
            this.tNedit_CustomerCode.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_CustomerCode.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_CustomerCode.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F);
            this.tNedit_CustomerCode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_CustomerCode.Location = new System.Drawing.Point(182, 3);
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
            this.tNedit_SupplierCd.Location = new System.Drawing.Point(182, 57);
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
            this.SupplierCdNm_tEdit.Location = new System.Drawing.Point(267, 57);
            this.SupplierCdNm_tEdit.MaxLength = 60;
            this.SupplierCdNm_tEdit.Name = "SupplierCdNm_tEdit";
            this.SupplierCdNm_tEdit.ReadOnly = true;
            this.SupplierCdNm_tEdit.Size = new System.Drawing.Size(206, 24);
            this.SupplierCdNm_tEdit.TabIndex = 34;
            this.SupplierCdNm_tEdit.TabStop = false;
            // 
            // CustomerGuide_Button
            // 
            appearance130.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance130.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.CustomerGuide_Button.Appearance = appearance130;
            this.CustomerGuide_Button.Location = new System.Drawing.Point(476, 3);
            this.CustomerGuide_Button.Name = "CustomerGuide_Button";
            this.CustomerGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.CustomerGuide_Button.TabIndex = 28;
            ultraToolTipInfo8.ToolTipText = "���Ӑ�K�C�h";
            this.ultraToolTipManager1.SetUltraToolTip(this.CustomerGuide_Button, ultraToolTipInfo8);
            this.CustomerGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CustomerGuide_Button.Click += new System.EventHandler(this.CustomerGuide_Button_Click);
            // 
            // CustomerCodeNm_tEdit
            // 
            appearance126.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustomerCodeNm_tEdit.ActiveAppearance = appearance126;
            appearance127.BackColor = System.Drawing.Color.Gainsboro;
            appearance127.BackColorDisabled = System.Drawing.Color.Gainsboro;
            appearance127.ForeColorDisabled = System.Drawing.Color.Black;
            this.CustomerCodeNm_tEdit.Appearance = appearance127;
            this.CustomerCodeNm_tEdit.AutoSelect = true;
            this.CustomerCodeNm_tEdit.BackColor = System.Drawing.Color.Gainsboro;
            this.CustomerCodeNm_tEdit.DataText = "";
            this.CustomerCodeNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.CustomerCodeNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 60, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.CustomerCodeNm_tEdit.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustomerCodeNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.CustomerCodeNm_tEdit.Location = new System.Drawing.Point(267, 3);
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
            this.SupplierCd_Label.Location = new System.Drawing.Point(30, 57);
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
            this.tShape2.Size = new System.Drawing.Size(507, 84);
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
            // _SFSIR02101UA_Toolbars_Dock_Area_Left
            // 
            this._SFSIR02101UA_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFSIR02101UA_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFSIR02101UA_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._SFSIR02101UA_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFSIR02101UA_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 63);
            this._SFSIR02101UA_Toolbars_Dock_Area_Left.Name = "_SFSIR02101UA_Toolbars_Dock_Area_Left";
            this._SFSIR02101UA_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 551);
            this._SFSIR02101UA_Toolbars_Dock_Area_Left.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // Main_ToolbarsManager
            // 
            this.Main_ToolbarsManager.DesignerFlags = 1;
            this.Main_ToolbarsManager.DockWithinContainer = this;
            this.Main_ToolbarsManager.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.Main_ToolbarsManager.RuntimeCustomizationOptions = Infragistics.Win.UltraWinToolbars.RuntimeCustomizationOptions.None;
            this.Main_ToolbarsManager.ShowFullMenusDelay = 500;
            this.Main_ToolbarsManager.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2003;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.FloatingLocation = new System.Drawing.Point(642, 381);
            ultraToolbar1.FloatingSize = new System.Drawing.Size(244, 20);
            ultraToolbar1.IsMainMenuBar = true;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool1,
            popupMenuTool2,
            labelTool1,
            labelTool2});
            ultraToolbar1.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar1.Text = "���j���[";
            ultraToolbar2.DockedColumn = 0;
            ultraToolbar2.DockedRow = 1;
            ultraToolbar2.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool2,
            buttonTool3,
            buttonTool4,
            buttonTool5});
            ultraToolbar2.Settings.AllowHiding = Infragistics.Win.DefaultableBoolean.False;
            ultraToolbar2.Settings.CaptionPlacement = Infragistics.Win.TextPlacement.BelowImage;
            ultraToolbar2.Settings.ToolDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            ultraToolbar2.Text = "�W��";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            popupMenuTool3.SharedProps.Caption = "�t�@�C��(&F)";
            popupMenuTool3.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool6,
            buttonTool7,
            buttonTool8});
            popupMenuTool4.SharedProps.Caption = "�ҏW(&E)";
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool9,
            buttonTool10});
            labelTool3.SharedProps.Spring = true;
            buttonTool11.SharedProps.Caption = "�I��(&X)";
            buttonTool12.SharedProps.Caption = "�E�B���h�E��������Ԃɖ߂�(&R)";
            appearance12.BackColor = System.Drawing.Color.White;
            appearance12.TextHAlignAsString = "Left";
            labelTool4.SharedProps.AppearancesSmall.Appearance = appearance12;
            labelTool4.SharedProps.Visible = false;
            labelTool4.SharedProps.Width = 110;
            buttonTool13.SharedProps.Caption = "�ۑ�(&S)";
            buttonTool14.SharedProps.Caption = "�V�K(&N)";
            buttonTool15.SharedProps.Caption = "�폜(&D)";
            buttonTool16.SharedProps.Caption = "����(&B)";
            this.Main_ToolbarsManager.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            popupMenuTool3,
            popupMenuTool4,
            labelTool3,
            buttonTool11,
            buttonTool12,
            labelTool4,
            buttonTool13,
            buttonTool14,
            buttonTool15,
            buttonTool16});
            this.Main_ToolbarsManager.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Main_ToolbarsManager_ToolClick);
            // 
            // _SFSIR02101UA_Toolbars_Dock_Area_Right
            // 
            this._SFSIR02101UA_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFSIR02101UA_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFSIR02101UA_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._SFSIR02101UA_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFSIR02101UA_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(992, 63);
            this._SFSIR02101UA_Toolbars_Dock_Area_Right.Name = "_SFSIR02101UA_Toolbars_Dock_Area_Right";
            this._SFSIR02101UA_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 551);
            this._SFSIR02101UA_Toolbars_Dock_Area_Right.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _SFSIR02101UA_Toolbars_Dock_Area_Top
            // 
            this._SFSIR02101UA_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFSIR02101UA_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFSIR02101UA_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._SFSIR02101UA_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFSIR02101UA_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._SFSIR02101UA_Toolbars_Dock_Area_Top.Name = "_SFSIR02101UA_Toolbars_Dock_Area_Top";
            this._SFSIR02101UA_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(992, 63);
            this._SFSIR02101UA_Toolbars_Dock_Area_Top.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // _SFSIR02101UA_Toolbars_Dock_Area_Bottom
            // 
            this._SFSIR02101UA_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._SFSIR02101UA_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(190)))), ((int)(((byte)(245)))));
            this._SFSIR02101UA_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._SFSIR02101UA_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._SFSIR02101UA_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 614);
            this._SFSIR02101UA_Toolbars_Dock_Area_Bottom.Name = "_SFSIR02101UA_Toolbars_Dock_Area_Bottom";
            this._SFSIR02101UA_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(992, 0);
            this._SFSIR02101UA_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Main_ToolbarsManager;
            // 
            // DCKHN09160UA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 614);
            this.Controls.Add(this.Main_panel);
            this.Controls.Add(this._SFSIR02101UA_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._SFSIR02101UA_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._SFSIR02101UA_Toolbars_Dock_Area_Top);
            this.Controls.Add(this._SFSIR02101UA_Toolbars_Dock_Area_Bottom);
            this.Font = new System.Drawing.Font("�l�r �S�V�b�N", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DCKHN09160UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "�|���}�X�^";
            this.Shown += new System.EventHandler(this.DCKHN09160UA_Shown);
            this.Load += new System.EventHandler(this.DCKHN09160UA_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.CustRateGrpCode_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_CustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_SupplierCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierCdNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CustomerCodeNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tShape2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Main_ToolbarsManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        # region Private Members (Component)

        private Broadleaf.Library.Windows.Forms.TToolbarsManager Main_ToolbarsManager;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFSIR02101UA_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFSIR02101UA_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFSIR02101UA_Toolbars_Dock_Area_Top;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _SFSIR02101UA_Toolbars_Dock_Area_Bottom;
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
        private Broadleaf.Library.Windows.Forms.TComboEditor CustRateGrpCode_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel Customer_Title_uLabel;
        private Infragistics.Win.Misc.UltraLabel CustRateGrpCode_Label;
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
        public Infragistics.Win.UltraWinGrid.UltraGrid Detail_uGrid;
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
        private const int ROWINDEX_UNPRCFRACPROCUNIT = 10;      // �P���[�������P��
        private const int ROWINDEX_UNPRCFRACPROCDIV = 11;       // �P���[�������敪

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

        private const string UNITPRICEKIND_1 = "�����ݒ�";
        private const string UNITPRICEKIND_2 = "�����ݒ�";
        private const string UNITPRICEKIND_3 = "���i�ݒ�";

        private const string UNITPRICEKINDWAY_0 = "�P�i�ݒ�";
        private const string UNITPRICEKINDWAY_1 = "�O���[�v�ݒ�";

        private const string UNPRCFRACPROCDIV_1 = "�؎̂�";
        private const string UNPRCFRACPROCDIV_2 = "�l�̌ܓ�";
        private const string UNPRCFRACPROCDIV_3 = "�؏グ";

        private const string FORMAT_NUM = "###,###";
        private const string FORMAT_DECIMAL = "N";

        private const string ALL_SECTIONCODE = "00";
        private const string ALL_SECTIONNAME = "�S��";

        #endregion Constants

        #region Private Members

        private string _enterpriseCode = "";                // ��ƃR�[�h
        private List<Rate> _rateListClone;                  // �|���}�X�^���X�g
        private SortedList _custRateGrpList = null;		    // ���Ӑ�|���O���[�v
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
        private CustomerInfoAcs _customerInfoAcs = null;    // ���Ӑ�A�N�Z�X�N���X
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

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, Supplier> _supplierDic;
        private Dictionary<int, MakerUMnt> _makerUMntDic;
        private Dictionary<int, GoodsGroupU> _goodsGroupUDic;
        private Dictionary<int, BLGoodsCdUMnt> _blGoodsCdUMntDic;
        private Dictionary<int, BLGroupU> _blGroupUDic;
        private Dictionary<string, GoodsUnitData> _goodsUnitDataDic;
        
        private bool _firstFlg;

        #endregion Private Members

        #region Constructor
        /// <summary>
        /// �|���}�X�^�t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
		public DCKHN09160UA()
		{
			InitializeComponent();

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
            this._customerInfoAcs = new CustomerInfoAcs();
            this._supplierAcs = new SupplierAcs();
            this._goodsAcs = new GoodsAcs();

            this._rateListClone = new List<Rate>();

            this._goodsUnitDataDic = new Dictionary<string, GoodsUnitData>();

            // �e��}�X�^�Ǎ�
            LoadSecInfoSet();
            LoadSupplier();
            LoadMakerUMnt();
            LoadGoodsGroupU();
            LoadBLGoodsCdUMnt();
            LoadBLGroupU();

            // ��ʏ�����
            ScreenInitialSetting();

            // �O���b�h������
            ClearGrid("");
		}
		#endregion

        #region Private Methods

        /// <summary>
        /// ���_���}�X�^�Ǎ�����
        /// </summary>
        private void LoadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
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
                        this._supplierDic.Add(supplier.SupplierCd, supplier);
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
                        this._makerUMntDic.Add(makerUMnt.GoodsMakerCd, makerUMnt);
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
                        this._goodsGroupUDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
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
                        this._blGoodsCdUMntDic.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt);
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
                        this._blGroupUDic.Add(blGroupU.BLGroupCode, blGroupU);
                    }
                }
            }
            catch
            {
                this._blGroupUDic = new Dictionary<int, BLGroupU>();
            }
        }

        /// <summary>
        /// �A�C�R���ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �c�[���o�[�ƃ{�^���̃A�C�R����ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void SetIcon()
        {
            ImageList imageList16 = IconResourceManagement.ImageList16;

            // -----------------------------
            // �c�[���o�[�A�C�R���ݒ�
            // -----------------------------
            ButtonTool workButton;

            // �I���{�^���̃A�C�R���ݒ�
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["Exit_ButtonTool"];
            if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.CLOSE];

            // �V�K�{�^���̃A�C�R���ݒ�
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["New_ButtonTool"];
            if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.NEW];

            // �ۑ��{�^���̃A�C�R���ݒ�
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["Save_ButtonTool"];
            if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.SAVE];

            // �폜�{�^���̃A�C�R���ݒ�
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["Delete_ButtonTool"];
            if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.DELETE];

            // �����{�^���̃A�C�R���ݒ�
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["Revival_ButtonTool"];
            if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.UNDO];

            // -----------------------------
            // �{�^���A�C�R���ݒ�
            // -----------------------------
            this.SectionGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.RateSettingDivideGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
            this.CustomerGuide_Button.Appearance.Image = imageList16.Images[(int)Size16_Index.STAR1];
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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.Mode_Label.Text = INSERT_MODE;

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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
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
        }

        /// <summary>
        /// ��������(�����ݒ�)�N���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ����N���A���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void ClearCustomerCondition()
        {
            this.tNedit_CustomerCode.Clear();
            this.CustomerCodeNm_tEdit.Clear();
            this.CustRateGrpCode_tComboEditor.Value = 0;
            this.tNedit_SupplierCd.Clear();
            this.SupplierCdNm_tEdit.Clear();

            this._prevCustomerCode = -1;
            this._prevSupplierCode = -1;
        }

        /// <summary>
        /// �O���b�h�����ݒ菈��
        /// </summary>
        /// <param name="unitPriceKind">�P�����</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�̏����ݒ���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/18</br>
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
                        // �P���[�������P��
                        else if (rowIndex == ROWINDEX_UNPRCFRACPROCUNIT)
                        {
                            string keyName = "LotCount1";
                            dataRow[keyName] = "1.00";
                        }
                        // �P���[�������敪
                        else if (rowIndex == ROWINDEX_UNPRCFRACPROCDIV)
                        {
                            string keyName = "LotCount1";
                            dataRow[keyName] = 1;
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
                            string keyName = "LotCount1";
                            dataRow[keyName] = "1.00";
                        }
                        // �P���[�������敪
                        else if (rowIndex == ROWINDEX_UNPRCFRACPROCDIV)
                        {
                            string keyName = "LotCount1";
                            dataRow[keyName] = 1;
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

                // �e�L�X�g�E��
                this.Detail_uGrid.DisplayLayout.Bands[0].Columns[index].CellAppearance.TextHAlign = HAlign.Right;

                // �P���[�������敪�ݒ�
                this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[index].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
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
        /// <br>Date       : 2008/06/18</br>
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

            // ���Ӑ�|���O���[�v
            GetCustRateGrp();
            this.CustRateGrpCode_tComboEditor.Items.Clear();
            foreach (DictionaryEntry dic in this._custRateGrpList)
            {
                this.CustRateGrpCode_tComboEditor.Items.Add((int)dic.Key, (string)dic.Value);
            }
        }

        /// <summary>
        /// �t�H�[�J�X�ݒ菈��
        /// </summary>
        /// <param name="prevButton">�����K�C�h�{�^��</param>
        /// <remarks>
        /// <br>Note       : �K�C�h�{�^��������̃t�H�[�J�X�ݒ���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void SetFocus(UltraButton prevButton)
        {
            // ���_�K�C�h�{�^��
            if (prevButton.Name == "SectionGuide_Button")
            {
                // �P����ނɃt�H�[�J�X�ݒ�
                this.UnitPriceKind_tComboEditor.Focus();
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
                    }
                    else if (RateAcs.IsCustRateGrpSetting(rateSettingDivide))
                    {
                        // ���Ӑ�|���O���[�v�Ƀt�H�[�J�X�ݒ�
                        this.CustRateGrpCode_tComboEditor.Focus();
                    }
                    else if (RateAcs.IsSupplierSetting(rateSettingDivide))
                    {
                        // �d����R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_SupplierCd.Focus();
                    }
                    else if (RateAcs.IsMakerSetting(rateSettingDivide))
                    {
                        // ���[�J�[�R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_GoodsMakerCd.Focus();
                    }
                    else if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        // �w�ʂɃt�H�[�J�X�ݒ�
                        this.GoodsRateRank_tEdit.Focus();
                    }
                    else if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        // ���i�|���f�R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_GoodsMGroup.Focus();
                    }
                    else if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        // BL�O���[�v�R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_BLGloupCode.Focus();
                    }
                    else if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        // BL�R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_BLGoodsCode.Focus();
                    }
                    else if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        // �i�ԃR�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tEdit_GoodsNo.Focus();
                    }
                    else
                    {
                        // �O���b�h�Ƀt�H�[�J�X�ݒ�
                        this.Detail_uGrid.Focus();
                    }
                    return;
                // ���Ӑ�K�C�h�{�^��
                case "CustomerGuide_Button":
                    if (RateAcs.IsCustRateGrpSetting(rateSettingDivide))
                    {
                        // ���Ӑ�|���O���[�v�Ƀt�H�[�J�X�ݒ�
                        this.CustRateGrpCode_tComboEditor.Focus();
                    }
                    else if (RateAcs.IsSupplierSetting(rateSettingDivide))
                    {
                        // �d����R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_SupplierCd.Focus();
                    }
                    else if (RateAcs.IsMakerSetting(rateSettingDivide))
                    {
                        // ���[�J�[�R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_GoodsMakerCd.Focus();
                    }
                    else if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        // �w�ʂɃt�H�[�J�X�ݒ�
                        this.GoodsRateRank_tEdit.Focus();
                    }
                    else if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        // ���i�|���f�R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_GoodsMGroup.Focus();
                    }
                    else if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        // BL�O���[�v�R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_BLGloupCode.Focus();
                    }
                    else if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        // BL�R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_BLGoodsCode.Focus();
                    }
                    else if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        // �i�ԃR�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tEdit_GoodsNo.Focus();
                    }
                    else
                    {
                        // �O���b�h�Ƀt�H�[�J�X�ݒ�
                        this.Detail_uGrid.Focus();
                    }
                    return;
                // �d����K�C�h�{�^��
                case "SupplierGuide_Button":
                    if (RateAcs.IsMakerSetting(rateSettingDivide))
                    {
                        // ���[�J�[�R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_GoodsMakerCd.Focus();
                    }
                    else if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        // �w�ʂɃt�H�[�J�X�ݒ�
                        this.GoodsRateRank_tEdit.Focus();
                    }
                    else if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        // ���i�|���f�R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_GoodsMGroup.Focus();
                    }
                    else if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        // BL�O���[�v�R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_BLGloupCode.Focus();
                    }
                    else if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        // BL�R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_BLGoodsCode.Focus();
                    }
                    else if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        // �i�ԃR�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tEdit_GoodsNo.Focus();
                    }
                    else
                    {
                        // �O���b�h�Ƀt�H�[�J�X�ݒ�
                        this.Detail_uGrid.Focus();
                    }
                    return;
                // ���[�J�[�K�C�h�{�^��
                case "MakerGuide_Button":
                    if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        // �w�ʂɃt�H�[�J�X�ݒ�
                        this.GoodsRateRank_tEdit.Focus();
                    }
                    else if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        // ���i�|���f�R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_GoodsMGroup.Focus();
                    }
                    else if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        // BL�O���[�v�R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_BLGloupCode.Focus();
                    }
                    else if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        // BL�R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_BLGoodsCode.Focus();
                    }
                    else if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        // �i�ԃR�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tEdit_GoodsNo.Focus();
                    }
                    else
                    {
                        // �O���b�h�Ƀt�H�[�J�X�ݒ�
                        this.Detail_uGrid.Focus();
                    }
                    return;
                // ���i�|���f�K�C�h�{�^��
                case "GoodsRateGrpGuide_Button":
                    if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        // BL�O���[�v�R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_BLGloupCode.Focus();
                    }
                    else if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        // BL�R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_BLGoodsCode.Focus();
                    }
                    else if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        // �i�ԃR�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tEdit_GoodsNo.Focus();
                    }
                    else
                    {
                        // �O���b�h�Ƀt�H�[�J�X�ݒ�
                        this.Detail_uGrid.Focus();
                    }
                    return;
                // BL�O���[�v�R�[�h�K�C�h�{�^��
                case "BLGroupGuide_Button":
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        // BL�R�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tNedit_BLGoodsCode.Focus();
                    }
                    else if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        // �i�ԃR�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tEdit_GoodsNo.Focus();
                    }
                    else
                    {
                        // �O���b�h�Ƀt�H�[�J�X�ݒ�
                        this.Detail_uGrid.Focus();
                    }
                    return;
                // BL�R�[�h�K�C�h�{�^��
                case "BLGoodsGuide_Button":
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        // �i�ԃR�[�h�Ƀt�H�[�J�X�ݒ�
                        this.tEdit_GoodsNo.Focus();
                    }
                    else
                    {
                        // �O���b�h�Ƀt�H�[�J�X�ݒ�
                        this.Detail_uGrid.Focus();
                    }
                    break;
                default:
                    // �O���b�h�Ƀt�H�[�J�X�ݒ�
                    this.Detail_uGrid.Focus();
                    return;
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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private int GetCustRateGrp()
        {
            this._custRateGrpList = new SortedList();

            int status;
            ArrayList retList = new ArrayList();

            // ���[�U�[�K�C�h�f�[�^�擾(���Ӑ�|���O���[�v)
            status = GetUserGuideBd(out retList, 43);
            if (status == 0)
            {
                foreach (UserGdBd userGdBd in retList)
                {
                    this._custRateGrpList.Add(userGdBd.GuideCode, userGdBd.GuideName.Trim());
                }
            }

            return status;
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
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
            int unitPriceKindCode = int.Parse((string)this.UnitPriceKind_tComboEditor.Value);

            // �ݒ���@
            if (this.UnitPriceKindWay_tComboEditor.Value == null)
            {
                return status;
            }
            int unitPriceKindWayCode = (int)this.UnitPriceKindWay_tComboEditor.Value;

            try
            {
                status = this._rateProtyMngAcs.Read(out rateProtyMng, this._enterpriseCode, sectionCode, 
                                                        unitPriceKindCode, unitPriceKindWayCode, RateSettingDivCode);
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
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private string GetCustomerName(int customerCode)
        {
            string customerName = "";
            
            try
            {
                CustomerInfo customerInfo;

                int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                if (status == 0)
                {
                    customerName = customerInfo.CustomerSnm.Trim();
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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        //private int GetGoodsInfo(out GoodsUnitData goodsUnitData, string goodsCode) // DEL 2009/03/16
        private int GetGoodsInfo(out GoodsUnitData goodsUnitData, string goodsCode, int GoodsMakerCd) // ADD 2009/03/16
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
                goodsCndtn.GoodsMakerCd = GoodsMakerCd; // ADD 2009/03/16
                goodsCndtn.GoodsNo = goodsCode;

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
        /// <br>Date       : 2008/06/18</br>
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

        #region ��ʓ��͋��ݒ�

        /// <summary>
        /// ��ʓ��͋��ݒ菈��
        /// </summary>
        /// <param name="editMode">�ҏW���[�h(�V�K�E�X�V�E�폜)</param>
        /// <remarks>
        /// <br>Note       : ��ʃR���g���[���̓��͋���ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/18</br>
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
            this.CustRateGrpCode_tComboEditor.Enabled = false;
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

            ButtonTool workButton;
            // �ۑ��{�^���̃A�C�R���ݒ�
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["Save_ButtonTool"];
            if (workButton != null) workButton.SharedProps.Visible = false;

            // �폜�{�^����\��
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["Delete_ButtonTool"];
            if (workButton != null) workButton.SharedProps.Visible = false;

            // �����{�^����\��
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["Revival_ButtonTool"];
            if (workButton != null) workButton.SharedProps.Visible = false;

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
                    workButton = (ButtonTool)Main_ToolbarsManager.Tools["Save_ButtonTool"];
                    if (workButton != null) workButton.SharedProps.Visible = true;

                    break;
                // �X�V���[�h
                case UPDATE_MODE:

                    this.Detail_uGrid.Enabled = true;

                    // �ۑ��{�^���\��
                    workButton = (ButtonTool)Main_ToolbarsManager.Tools["Save_ButtonTool"];
                    if (workButton != null) workButton.SharedProps.Visible = true;

                    // �폜�{�^���\��
                    workButton = (ButtonTool)Main_ToolbarsManager.Tools["Delete_ButtonTool"];
                    if (workButton != null) workButton.SharedProps.Visible = true;

                    break;
                // �폜���[�h
                case DELETE_MODE:

                    // �폜�{�^���\��
                    workButton = (ButtonTool)Main_ToolbarsManager.Tools["Delete_ButtonTool"];
                    if (workButton != null) workButton.SharedProps.Visible = true;

                    // �����{�^���\��
                    workButton = (ButtonTool)Main_ToolbarsManager.Tools["Revival_ButtonTool"];
                    if (workButton != null) workButton.SharedProps.Visible = true;

                    break;
            }
        }

        /// <summary>
        /// �O���b�h���͋��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �O���b�h�̓��͋���ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/18</br>
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
            int unitPriceKindWayCode = (int)this.UnitPriceKindWay_tComboEditor.Value;

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
                        // ���i�ݒ�
                        if (unitPriceKindCode == 3)
                        {
                            // �Z�����͋��ݒ�
                            SetCellEnabled(rowIndex, 0);
                        }
                        break;
                    // �P���[�������P�ʁA�P���[�������敪
                    case ROWINDEX_UNPRCFRACPROCUNIT:
                    case ROWINDEX_UNPRCFRACPROCDIV:
                        // �Z�����͋��ݒ�
                        SetCellEnabled(rowIndex, 0);
                        break;
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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
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
                        // �������A�����z�A����UP���A�e���m�ۗ��A�P���[�������P�ʁA�P���[�������敪
                        case ROWINDEX_SALERATEVAL:
                        case ROWINDEX_SALEPRICEFL:
                        case ROWINDEX_COSTUPRATE:
                        case ROWINDEX_GRSPROFITSECURERATE:
                        case ROWINDEX_UNPRCFRACPROCUNIT:
                        case ROWINDEX_UNPRCFRACPROCDIV:
                            // �ΏۃZ������͉\�ɕύX
                            this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Activation = Activation.AllowEdit;
                            this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activation = Activation.AllowEdit;
                            break;
                        default:
                            break;
                    }
                }
                // �O���[�v�ݒ�
                else
                {
                    switch (rowIndex)
                    {
                        // �������A����UP���A�e���m�ۗ��A�P���[�������P�ʁA�P���[�������敪
                        case ROWINDEX_SALERATEVAL:
                        case ROWINDEX_COSTUPRATE:
                        case ROWINDEX_GRSPROFITSECURERATE:
                        case ROWINDEX_UNPRCFRACPROCUNIT:
                        case ROWINDEX_UNPRCFRACPROCDIV:
                            // �ΏۃZ������͉\�ɕύX
                            this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Activation = Activation.AllowEdit;
                            this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activation = Activation.AllowEdit;
                            break;
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
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void SetCustomerConditionEnabled()
        {
            // �|���ݒ�敪
            string rateSettingDivide = this.RateSettingDivide_tEdit.DataText.Trim();

            this.tNedit_CustomerCode.Enabled = false;
            this.CustomerGuide_Button.Enabled = false;
            this.CustRateGrpCode_tComboEditor.Enabled = false;
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
                this.CustRateGrpCode_tComboEditor.Enabled = true;
            }
        }

        /// <summary>
        /// �t�H�[�J�X�ݒ菈��
        /// </summary>
        /// <param name="index">�J�����g�R���g���[��(0:�|���ݒ�敪�@1:���Ӑ�@2:�d����@3:���[�J�[  4:���i�|���f�@5:�O���[�v�R�[�h�@6:BL�R�[�h)</param>
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
                        return;
                    }
                    // ���Ӑ�|���ݒ�GR���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsCustRateGrpSetting(rateSettingDivide))
                    {
                        this.CustRateGrpCode_tComboEditor.Focus();
                        return;
                    }
                    // �d���悪�|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsSupplierSetting(rateSettingDivide))
                    {
                        this.tNedit_SupplierCd.Focus();
                        return;
                    }
                    // ���[�J�[���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsMakerSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMakerCd.Focus();
                        return;
                    }
                    // �w�ʂ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        this.GoodsRateRank_tEdit.Focus();
                        return;
                    }
                    // ���i�|���f���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMGroup.Focus();
                        return;
                    }
                    // BL�O���[�v�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGloupCode.Focus();
                        return;
                    }
                    // BL�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        return;
                    }
                    // �i�Ԃ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        return;
                    }
                    break;
                // ���Ӑ�R�[�h
                case 1:
                    // ���Ӑ�|���ݒ�GR���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsCustRateGrpSetting(rateSettingDivide))
                    {
                        this.CustRateGrpCode_tComboEditor.Focus();
                        return;
                    }
                    // �d���悪�|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsSupplierSetting(rateSettingDivide))
                    {
                        this.tNedit_SupplierCd.Focus();
                        return;
                    }
                    // ���[�J�[���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsMakerSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMakerCd.Focus();
                        return;
                    }
                    // �w�ʂ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        this.GoodsRateRank_tEdit.Focus();
                        return;
                    }
                    // ���i�|���f���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMGroup.Focus();
                        return;
                    }
                    // BL�O���[�v�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGloupCode.Focus();
                        return;
                    }
                    // BL�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        return;
                    }
                    // �i�Ԃ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        return;
                    }
                    break;
                // �d����R�[�h
                case 2:
                    // ���[�J�[���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsMakerSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMakerCd.Focus();
                        return;
                    }
                    // �w�ʂ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        this.GoodsRateRank_tEdit.Focus();
                        return;
                    }
                    // ���i�|���f���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMGroup.Focus();
                        return;
                    }
                    // BL�O���[�v�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGloupCode.Focus();
                        return;
                    }
                    // BL�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        return;
                    }
                    // �i�Ԃ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        return;
                    }
                    break;
                // ���[�J�[
                case 3:
                    // �w�ʂ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        this.GoodsRateRank_tEdit.Focus();
                        return;
                    }
                    // ���i�|���f���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMGroup.Focus();
                        return;
                    }
                    // BL�O���[�v�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGloupCode.Focus();
                        return;
                    }
                    // BL�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        return;
                    }
                    // �i�Ԃ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        return;
                    }
                    break;
                // ���i�|���f
                case 4:
                    // BL�O���[�v�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGloupCode.Focus();
                        return;
                    }
                    // BL�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        return;
                    }
                    // �i�Ԃ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        return;
                    }
                    break;
                // �O���[�v�R�[�h
                case 5:
                    // BL�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        return;
                    }
                    // �i�Ԃ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        return;
                    }
                    break;
                // BL�R�[�h
                case 6:
                    // �i�Ԃ��|���ݒ�敪�̐ݒ�Ώۂ����擾
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        return;
                    }
                    break;
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
        /// �����R���g���[��(���i)���͋��ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����R���g���[��(���i)�̓��͋���ݒ肵�܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
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

            // �V�K�쐬����
            NewProc();

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
        /// <br>Date       : 2008/06/18</br>
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

            // �|���}�X�^��ʓW�J
            RateToScreen(rateList);

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

            return true;
        }

        /// <summary>
        /// �|���}�X�^�_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�̘_���폜���s���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private bool LogicalDeleteProc()
        {
            // �_���폜�m�F
            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
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
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private bool DeleteProc()
        {
            // ���S�폜�m�F
            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
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
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private bool RevivalProc()
        {
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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
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
                    }
                    return (false);
                }
                if (saveFlg == true)
                {
                    // �ۑ��O�`�F�b�N�̂�
                    int customerCode = this.tNedit_CustomerCode.GetInt();
                    if (GetCustomerName(customerCode) == "")
                    {
                        errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                        if (focusFlg == true)
                        {
                            this.tNedit_CustomerCode.Focus();
                        }
                        return (false);
                    }
                }
            }

            // ���Ӑ�|���O���[�v�R�[�h
            if (RateAcs.IsCustRateGrpSetting(rateSettingDivide))
            {
                if (this.CustRateGrpCode_tComboEditor.Value == null)
                {
                    errMsg = "���Ӑ�|���O���[�v��I�����Ă��������B";
                    if (focusFlg == true)
                    {
                        this.CustRateGrpCode_tComboEditor.Focus();
                    }
                    return (false);
                }
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
                    }
                    return (false);
                }
                if (saveFlg == true)
                {
                    // �ۑ��O�`�F�b�N�̂�
                    int supplierCode = this.tNedit_SupplierCd.GetInt();
                    if (GetSupplierName(supplierCode) == "")
                    {
                        errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                        if (focusFlg == true)
                        {
                            this.tNedit_SupplierCd.Focus();
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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
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

                        // ���[�U�[�艿
                        if (unitPriceKindWay == 0)
                        {
                            // �P�i�ݒ�̂Ƃ��̂݃`�F�b�N
                            if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_USERPRICEFL].Cells[columnIndex].Text != "") &&
                                (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_USERPRICEFL].Cells[columnIndex].Text) != 0))
                            {
                                checkFlg = true;
                            }
                        }

                        // ���iUP��
                        if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_PRICEUPRATE].Cells[columnIndex].Text != "") &&
                            (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_PRICEUPRATE].Cells[columnIndex].Text) != 0))
                        {
                            checkFlg = true;
                        }

                        if (checkFlg == false)
                        {
                            errMsg = "�����͂̍��ڂ����݂��邽�߁A�o�^�ł��܂���B\n���i�ݒ�";
                            if (unitPriceKindWay == 0)
                            {
                                this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_USERPRICEFL].Cells[columnIndex].Activate();
                            }
                            else
                            {
                                this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_PRICEUPRATE].Cells[columnIndex].Activate();
                            }
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        break;
                }

                // �P���[�������P��
                if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Value == DBNull.Value) ||
                    ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Value == "") ||
                    (double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Value) == 0))
                {
                    errMsg = "�����͂̍��ڂ����݂��邽�߁A�o�^�ł��܂���B\n�P���[�������P��";
                    this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Activate();
                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }

                // �P���[�������敪
                if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[columnIndex].Value == DBNull.Value) ||
                    (this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[columnIndex].Text == ""))
                {
                    errMsg = "�����͂̍��ڂ����݂��邽�߁A�o�^�ł��܂���B\n�P���[�������敪";
                    this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[columnIndex].Activate();
                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
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
        /// <br>Date       : 2008/06/18</br>
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
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// �|���ݒ�敪���݃`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|���ݒ�敪�����݂��邩�ǂ����`�F�b�N���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void CheckExistRateSettingDivide()
        {
            int status;
            RateProtyMng rateProtyMng = new RateProtyMng();

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
                this.RateSettingDivide_tEdit.Clear();

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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
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

                        if (lotCountAbove != lotCountBelow)
                        {
                            saveRecordCount++;
                        }
                        else
                        {
                            return saveRecordCount;
                        }
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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void CustomerConditionToRate(ref Rate rate)
        {
            // ���Ӑ�R�[�h
            rate.CustomerCode = this.tNedit_CustomerCode.GetInt();

            // ���Ӑ�|���O���[�v�R�[�h
            if (this.CustRateGrpCode_tComboEditor.Value != null)
            {
                rate.CustRateGrpCode = (int)this.CustRateGrpCode_tComboEditor.Value;
            }
            else
            {
                rate.CustRateGrpCode = 0;
            }

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
        /// <br>Date       : 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
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

                    break;
            }

            // �P���[�������P��
            rate.UnPrcFracProcUnit = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Text);

            // �P���[�������敪
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
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void RateToScreen(List<Rate> rateList)
        {
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
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void RateToRateCondition(Rate rate)
        {
            // ���_�R�[�h
            this.tEdit_SectionCodeAllowZero.DataText = rate.SectionCode.Trim();

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
        /// <br>Date       : 2008/06/18</br>
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

            // ���Ӑ�|���O���[�v
            this.CustRateGrpCode_tComboEditor.Value = rate.CustRateGrpCode;

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
        }

        /// <summary>
        /// �|���}�X�^��ʓW�J(���i�ݒ�)����
        /// </summary>
        /// <param name="rate">�|���}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�����(���i�ݒ�)�ɓW�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/18</br>
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

            // �w��
            this.GoodsRateRank_tEdit.DataText = rate.GoodsRateRank.Trim();

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
                    this.tEdit_GoodsName.Clear();
                }
            }
        }

        /// <summary>
        /// �|���}�X�^��ʓW�J(�O���b�h)����
        /// </summary>
        /// <param name="rateList">�|���}�X�^���X�g</param>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�����(�O���b�h)�ɓW�J���܂��B</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/06/18</br>
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

                        break;
                }

                // �P���[�������P��
                this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Value = rateList[columnIndex].UnPrcFracProcUnit.ToString(FORMAT_DECIMAL);

                // �P���[�������敪
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
        /// <br>Date		: 2008/06/18</br>
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
        /// <br>Date		: 2008/06/18</br>
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
        /// <br>Date		: 2008/06/18</br>
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

            this._firstFlg = true;
        }

        /// <summary>
        /// �c�[���o�[�N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �c�[���o�[��̃c�[�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void Main_ToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
        {
            bool bStatus;

            switch (e.Tool.Key)
            {
                // �I���{�^��
                case "Exit_ButtonTool":
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
                                            return;
                                        }
                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        break;
                                    }
                                default:
                                    {
                                        return;
                                    }
                            }
                        }

                        this.Close();
                        return;
                    }
                // �V�K�{�^��
                case "New_ButtonTool":
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
                                            return;
                                        }
                                        break;
                                    }
                                case DialogResult.No:
                                    {
                                        break;
                                    }
                                default:
                                    {
                                        return;
                                    }
                            }
                        }

                        // �V�K�쐬����
                        bStatus = NewProc();
                        return;
                    }
                // �ۑ��{�^��
                case "Save_ButtonTool":
                    {
                        // �ꎞ�I�Ƀt�H�[�J�X���ړ����܂�
                        this.SectionCode_uLabel.Focus();

                        // �ۑ�����
                        bStatus = SaveProc();
                        return;
                    }
                // �폜�{�^��
                case "Delete_ButtonTool":
                    {
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
                        return;
                    }
                // �����{�^��
                case "Revival_ButtonTool":
                    {
                        // ��������
                        bStatus = RevivalProc();
                        return;
                    }
            }
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
        /// <br>Date		: 2008/06/18</br>
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
                        CheckExistRateSettingDivide();
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
        /// <br>Date		: 2008/06/18</br>
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
                                                           unitPriceKindWay, out rateProtyMng);
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
        /// <br>Date		: 2008/06/18</br>
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
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null)
            {
                this._cusotmerGuideSelected = false;
                return;
            }

            if (customerSearchRet.CustomerCode != this._prevCustomerCode)
            {
                this._prevCustomerCode = customerSearchRet.CustomerCode;

                // ���Ӑ�R�[�h
                this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);

                // ���Ӑ於��
                this.CustomerCodeNm_tEdit.DataText = customerSearchRet.Snm.Trim();
            }

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// Button_Click �C�x���g(SupplierGuide_Button)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �d����K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/06/18</br>
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
                    if (supplier.SupplierCd != this._prevSupplierCode)
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
        /// <br>Date		: 2008/06/18</br>
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
                    if (makerUMnt.GoodsMakerCd != this._prevMakerCode)
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
                                // ���i����
                                this.tEdit_GoodsName.Clear();

                                // �艿
                                this.tNedit_Price.Clear();
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
        /// <br>Date		: 2008/06/18</br>
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
                    if (goodsGroupU.GoodsMGroup != this._prevGoodsRateGrpCode)
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
        /// <br>Date		: 2008/06/18</br>
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
                    if (blGroupU.BLGroupCode != this._prevBLGroupCode)
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
        /// <br>Date		: 2008/06/18</br>
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
                    if (blGoodsCdUMnt.BLGoodsCode != this._prevBLGoodsCode)
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
        /// <br>Date		: 2008/06/18</br>
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

            // �|���ݒ�敪���݃`�F�b�N
            CheckExistRateSettingDivide();

            this._prevUnitPriceKind = unitPriceKind;
        }

        /// <summary>
        /// ValueChanged �C�x���g(UnitPriceKindWay_tComboEditor)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �ݒ���@�̒l���ύX���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void UnitPriceKindWay_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
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
            int unitPriceKindWay = (int)this.UnitPriceKindWay_tComboEditor.Value;

            if (unitPriceKindWay == this._prevUnitPriceKindWay)
            {
                return;
            }

            // �|���ݒ�敪���݃`�F�b�N
            CheckExistRateSettingDivide();

            this._prevUnitPriceKindWay = unitPriceKindWay;
        }

        #region �O���b�h����

        /// <summary>
        /// AfterExitEditMode �C�x���g(Detail_uGrid)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �ҏW���[�h���I�������Ƃ��ɔ������܂��B</br>
        /// <br>Programmer	: 30414�@�E�@�K�j</br>
        /// <br>Date		: 2008/06/18</br>
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

            // �P���[�������敪�̏ꍇ
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
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void Detail_uGrid_AfterEnterEditMode(object sender, EventArgs e)
        {
            int rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;

            // �P���[�������敪�̏ꍇ
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
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void Detail_uGrid_CellChange(object sender, CellEventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = e.Cell.Row.Index;
            int columnIndex = e.Cell.Column.Index;

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

            // �P���[�������P��
            if (this.Detail_uGrid.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Text == "")
            {
                this.Detail_uGrid.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Value = "1.00";
            }
            // �P���[�������敪
            if (this.Detail_uGrid.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[columnIndex].Text == "")
            {
                this.Detail_uGrid.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[columnIndex].Value = 1;
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
        /// <br>Date		: 2008/06/18</br>
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
                    if (rowIndex == 0)
                    {
                        e.Handled = true;
                        return;
                    }
                    if (rowIndex == ROW_COUNT - 1)
                    {
                        // �P���[�������敪
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
                    for (int index = rowIndex - 1; index >= 0; index--)
                    {
                        if ((this.Detail_uGrid.DisplayLayout.Rows[index].Activation == Activation.AllowEdit) &&
                            (this.Detail_uGrid.DisplayLayout.Rows[index].Cells[columnIndex].Activation == Activation.AllowEdit))
                        {
                            // �A�N�e�B�u�Z����1��Ɉړ����܂�
                            e.Handled = true;
                            this.Detail_uGrid.DisplayLayout.Rows[index].Cells[columnIndex].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return;
                        }
                    }
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
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void Detail_uGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.Detail_uGrid.ActiveCell == null)
            {
                return;
            }

            int rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;
            int columnIndex = this.Detail_uGrid.ActiveCell.Column.Index;

            // �P���[�������敪�̏ꍇ
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
                // ����(�ȏ�)�A����(�ȉ�)�A�P���[�������P��
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

                // �������A����UP���A�e���m�ۗ��A�d�����A���iUP��
                // 3V2
                case ROWINDEX_SALERATEVAL:
                case ROWINDEX_COSTUPRATE:
                case ROWINDEX_GRSPROFITSECURERATE:
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
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // �O���b�h
            if (e.PrevCtrl == this.Detail_uGrid)
            {
                if (e.Key == Keys.Enter)
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
                }
            }
            // ���_�R�[�h
            else if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero)
            {
                // ���_�R�[�h�擾
                string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');

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
                        CheckExistRateSettingDivide();
                    }

                    SearchAfterLeaveControl();

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

                    return;
                }

                // �|���ݒ�敪
                string rateSettingDivCode = this.RateSettingDivide_tEdit.DataText.Trim();

                if (e.Key == Keys.Enter)
                {
                    e.NextCtrl = null;
                    SetNextFocus(0);
                }

                if (rateSettingDivCode == this._prevRateSettingDivide)
                {
                    return;
                }

                // �|���ݒ�敪���݃`�F�b�N
                CheckExistRateSettingDivide();

                SearchAfterLeaveControl();

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                    {
                        e.NextCtrl = null;
                        SetNextFocus(0);
                    }
                }

                this._prevRateSettingDivide = rateSettingDivCode;
            }
            // ���Ӑ�R�[�h
            else if (e.PrevCtrl == this.tNedit_CustomerCode)
            {
                if (this.tNedit_CustomerCode.GetInt() == 0)
                {
                    this.CustomerCodeNm_tEdit.Clear();
                    return;
                }

                // ���Ӑ�R�[�h�擾
                int customerCode = this.tNedit_CustomerCode.GetInt();

                // ���Ӑ於�̎擾
                this.CustomerCodeNm_tEdit.DataText = GetCustomerName(customerCode);

                if (this.CustomerCodeNm_tEdit.DataText.Trim() != "")
                {
                    SearchAfterLeaveControl();

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = null;
                            SetNextFocus(1);
                        }
                    }
                }
            }
            // �d����R�[�h
            else if (e.PrevCtrl == this.tNedit_SupplierCd)
            {
                if (this.tNedit_SupplierCd.GetInt() == 0)
                {
                    this.SupplierCdNm_tEdit.Clear();
                    return;
                }

                // �d����R�[�h�擾
                int supplierCode = this.tNedit_SupplierCd.GetInt();

                // �d���於�̎擾
                this.SupplierCdNm_tEdit.DataText = GetSupplierName(supplierCode);

                if (this.SupplierCdNm_tEdit.DataText.Trim() != "")
                {
                    SearchAfterLeaveControl();

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = null;
                            SetNextFocus(2);
                        }
                    }
                }
            }
            // ���[�J�[�R�[�h
            else if (e.PrevCtrl == this.tNedit_GoodsMakerCd)
            {
                if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                {
                    this.MakerName_tEdit.Clear();
                    this.tEdit_GoodsName.Clear();
                    return;
                }

                // ���[�J�[�R�[�h�擾
                int makerCode = this.tNedit_GoodsMakerCd.GetInt();

                // ���[�J�[���̎擾
                this.MakerName_tEdit.DataText = GetMakerName(makerCode);

                if (this.MakerName_tEdit.DataText.Trim() != "")
                {
                    SearchAfterLeaveControl();

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
                    // ���i����
                    this.tEdit_GoodsName.DataText = goodsUnitData.GoodsNameKana.Trim();

                    // �艿
                    List<GoodsPrice> goodsPriceList = goodsUnitData.GoodsPriceList;
                    this.tNedit_Price.SetValue(GetPrice(goodsPriceList));
                }
                else
                {
                    // ���i����
                    this.tEdit_GoodsName.Clear();

                    // �艿
                    this.tNedit_Price.Clear();
                }
            }
            // ���i�|���f
            else if (e.PrevCtrl == this.tNedit_GoodsMGroup)
            {
                if (this.tNedit_GoodsMGroup.GetInt() == 0)
                {
                    this.GoodsRateGrpName_tEdit.Clear();
                    return;
                }

                // ���i�|���f�R�[�h�擾
                int goodsRateGrpCode = this.tNedit_GoodsMGroup.GetInt();

                // ���i�|���f���̎擾
                this.GoodsRateGrpName_tEdit.DataText = GetGoodsMGroupName(goodsRateGrpCode);

                if (this.GoodsRateGrpName_tEdit.DataText.Trim() != "")
                {
                    SearchAfterLeaveControl();

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = null;
                            SetNextFocus(4);
                        }
                    }
                }
            }
            // �O���[�v�R�[�h
            else if (e.PrevCtrl == this.tNedit_BLGloupCode)
            {
                if (this.tNedit_BLGloupCode.GetInt() == 0)
                {
                    this.BLGroupName_tEdit.Clear();
                    return;
                }

                // BL�O���[�v�R�[�h�擾
                int blGroupCode = this.tNedit_BLGloupCode.GetInt();

                // BL�O���[�v����
                this.BLGroupName_tEdit.DataText = GetBLGroupName(blGroupCode);

                if (this.BLGroupName_tEdit.DataText.Trim() != "")
                {
                    SearchAfterLeaveControl();

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = null;
                            SetNextFocus(5);
                        }
                    }
                }
            }
            // BL�R�[�h
            else if (e.PrevCtrl == this.tNedit_BLGoodsCode)
            {
                if (this.tNedit_BLGoodsCode.GetInt() == 0)
                {
                    this.BLGoodsName_tEdit.Clear();
                    return;
                }

                // BL�R�[�h�擾
                int blGoodsCode = this.tNedit_BLGoodsCode.GetInt();

                // BL���̎擾
                this.BLGoodsName_tEdit.DataText = GetBLGoodsName(blGoodsCode);

                if (this.BLGoodsName_tEdit.DataText.Trim() != "")
                {
                    SearchAfterLeaveControl();

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            e.NextCtrl = null;
                            SetNextFocus(6);
                        }
                    }
                }
            }
            // �i��
            else if (e.PrevCtrl == this.tEdit_GoodsNo)
            {
                if (this.tEdit_GoodsNo.DataText.Trim() == "")
                {
                    this.tEdit_GoodsName.Clear();
                    this.tNedit_Price.Clear();
                    return;
                }

                // ���i�R�[�h�擾
                string goodsCode = this.tEdit_GoodsNo.DataText.Trim();

                // ���i���̎擾
                GoodsUnitData goodsUnitData;
                //int status = GetGoodsInfo(out goodsUnitData, goodsCode); // DEL 2009/03/16
                int status = GetGoodsInfo(out goodsUnitData, goodsCode, 0); // ADD 2009/03/16

                if (status == 0)
                {
                    // ���i����
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
                    this.tEdit_GoodsName.Clear();
                    this.tNedit_Price.Clear();
                }

                if (e.ShiftKey == false)
                {
                    if (e.Key == Keys.Enter)
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
                }
            }

            if ((e.NextCtrl != this.Detail_uGrid) || (this.Detail_uGrid.Enabled != true))
            {
                return;
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

                    e.NextCtrl = null;
                    this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activate();
                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    return;
                }
            }
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
        private void DCKHN09160UA_Shown(object sender, EventArgs e)
        {
            if (this._firstFlg)
            {
                this.tEdit_SectionCodeAllowZero.Focus();
            }

            this._firstFlg = false;
        }

        #endregion Control Events

        #region DEL 2008/06/18

        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
        // ===================================================================================== //
        // �v���C�x�[�g�����o�[
        // ===================================================================================== //
        #region Private Members

        private string[] _tableNameList = new string[2];
        private string[] _gridTitleList = new string[2];
        private int[] _dataIndexList = new int[2];
        private bool[] _canLogicalDeleteDataExtractionList = new bool[2];
        private bool[] _defaultAutoFillToGridColumnList = new bool[2];
        private Image[] _gridIconList = new Image[2];
        private Hashtable[] _appearanceTable = new Hashtable[2];

        //�@��ƃR�[�h
        private string _enterpriseCode = "";

        // �����_�R�[�h
        private string _loginSectionCode = "";

        // �]�ƈ�
        private Employee _loginEmployee = null;

        
        //------------------------
        // �e��A�N�Z�X�N���X��`
        //------------------------
        private RateAcs _rateAcs = null;					// �|���A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs = null;			// ���[�U�[�K�C�h�A�N�Z�X�N���X
        //private CustomerInfoAcs _customerInfoAcs = null;	// ���Ӑ�A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs = null;        // ���_�A�N�Z�X�N���X
        private RateProtyMngAcs _rateProtyMngAcs = null;	// �|���D��Ǘ��A�N�Z�X�N���X
        private GoodsAcs _goodsAcs = null;					// ���i�A�N�Z�X�N���X
        private MakerAcs _makerAcs = null;					// ���[�J�[�A�N�Z�X�N���X
        //private LGoodsGanreAcs _lGoodsGanreAcs = null;		// ���i�敪�O���[�v�A�N�Z�X�N���X
        //private MGoodsGanreAcs _mGoodsGanreAcs = null;		// ���i�敪�A�N�Z�X�N���X
        //private DGoodsGanreAcs _dGoodsGanreAcs = null;		// ���i�敪�ڍ׃A�N�Z�X�N���X
        private BLGoodsCdAcs _blGoodsCdAcs = null;			// BL�A�N�Z�X�N���X

        private SortedList _custRateGrpList = null;		// ���Ӑ�|���O���[�v
        private bool _cusotmerGuideSelected;
        private string _customerGuideButtonName;

        private BLGroupUAcs _blGroupUAcs = null;
        private GoodsGroupUAcs _goodsGroupUAcs = null;
        private SecInfoAcs _secInfoAcs = null;
        private CustomerSearchAcs _customerSearchAcs = null;

        //------------
        // �e�팟���p
        //------------
        private Rate _searchRate = null;		// �|���f�[�^�����p

        // �|���f�[�^�i�[�p�f�[�^�e�[�u��
        private DataTable _dataTableRate = null;

        // �|���f�[�^�������ʃ��X�g�i�[�p
        private Hashtable _rateSrchRsltHashList = null;	// HashKey�ikey:�V���敪+���b�g���j

        // �|���f�[�^�������ʔ�r�p
        private Hashtable _rateSrchRsltHashListClone = null;

        //--------------------
        // ���[�U�[�K�C�h�֘A
        //--------------------
        private SortedList _custRateGrpCodeSList = null;		// ���Ӑ�|���O���[�v
        private SortedList _suppRateGrpCodeSList = null;		// �d����|���O���[�v
        private SortedList _enterpriseGanreCodeSList = null;	// ���Е���
        private SortedList _priceDivSList = null;				// ���i�敪
        private SortedList _bargainCdSList = null;				// �����敪

        //--------------
        // �^�u����֘A
        //--------------
        private SortedList _nextCtrlTable = null;		// ������
        private SortedList _forwardCtrlTable = null;	// �O����

        // �����񌋍��p
        private StringBuilder _stringBuilder = null;

        // ���݂̓��͏󋵃t���O
        private AllCtrlInputStatus _AllCtrlInputStatus;

        // �V�K�X�V���[�h�t���O
        private ModeFlag _modeFlag;

        // �V�P���Z�o�敪�t���O�ifalse:�P���Z�o�敪1�I��s��, true:�P���Z�o�敪1�I���j
        private bool _unitPrcCalcDivNewFlag = true;

        // ���P���Z�o�敪�t���O�ifalse:�P���Z�o�敪1�I��s��, true:�P���Z�o�敪1�I���j
        private bool _unitPrcCalcDivOldFlag = true;

        // ��ʃf�U�C���ύX�N���X
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        //--------------
        // ���b�g��ʗp
        //--------------
        private DataTable _dataTableLotNew = null;	// �V���b�g�p�f�[�^�e�[�u��
        private DataTable _dataTableLotOld = null;	// �����b�g�p�f�[�^�e�[�u��
        private DataTable _dataTableLotNewClone = null;	// �V���b�g�p�f�[�^�e�[�u���N���[��
        private DataTable _dataTableLotOldClone = null;	// �����b�g�p�f�[�^�e�[�u���N���[��

        //------------------
        // �R���{�{�b�N�X�p
        //------------------
        private int _unitPriceKindtComboEditorValue = -1;		// �P����ރR���{�{�b�N�X�f�[�^
        private int _unitPriceKindWaytComboEditorValue = -1;	// �ݒ���@�R���{�{�b�N�X�f�[�^
        private DataTable _dataTableCustRateGrpCode = null;		// ���Ӑ�|���O���[�v�R���{�{�b�N�X�p
        private DataTable _dataTableSuppRateGrpCode = null;		// �d����|���O���[�v�R���{�{�b�N�X�p
        private DataTable _dataTableUnitPriceKind = null;		// �P����ރR���{�{�b�N�X�p
        private DataTable _dataTableUnitPriceKindWay = null;	// �ݒ���@�R���{�{�b�N�X�p
		private DataTable _dataTableEnterpriseGanreCode = null;	// ���Е��ރR���{�{�b�N�X�p
        private DataTable _dataTablePriceDiv = null;			// ���i�敪�R���{�{�b�N�X�p
		private DataTable _dataTableUnPrcCalcDivNew = null;		// �P���Z�o�敪�R���{�{�b�N�X�p�i�V�j
		private DataTable _dataTableUnPrcCalcDivOld = null;		// �P���Z�o�敪�R���{�{�b�N�X�p�i���j
        private DataTable _dataTableUnPrcFracProcDiv = null;	// �[�������敪�R���{�{�b�N�X�p
		private DataTable _dataTableBargainCd = null;			// �����敪�R���{�{�b�N�X�p

        //------------------------------
        // �e������ݒ�p�f�[�^�e�[�u��
        //------------------------------
        private DataTable _dataTableAllInpCtrl = null;			// �S�̓��̓R���g���[���f�[�^�e�[�u��
        private DataTable _dataTableInpCond = null;				// ���͏����ݒ�p�f�[�^�e�[�u��
        private DataTable _dataTableRateGoodsCond = null;		// ���i�|�������p�f�[�^�e�[�u��
        private DataTable _dataTableRateCustCond = null;		// ���Ӑ�|�������p�f�[�^�e�[�u��
		private DataTable _dataTableRateInpCond = null;			// �V���|�����͏����p�f�[�^�e�[�u��

        //----------------------------------
        // ���b�g�O���b�h�p�u�`�k�t�d���X�g
        //----------------------------------
        ValueList _gVListPriceDiv = null;			// ���i�敪
        ValueList _gVListUnPrcCalcDiv = null;		// �P���Z�o�敪
        ValueList _gVListUnPrcFracProcUnit = null;	// �P���[������
        ValueList _gVListBargainCd = null;			// �����敪�R�[�h
        ValueList _gVListOldPriceDiv = null;			// ���i�敪
        ValueList _gVListOldUnPrcCalcDiv = null;		// �P���Z�o�敪
        ValueList _gVListOldUnPrcFracProcUnit = null;	// �P���[������
        ValueList _gVListOldBargainCd = null;			// �����敪�R�[�h

        // �ҏW���[�h
        private const string INSERT_MODE = "�V�K���[�h";
        private const string UPDATE_MODE = "�X�V���[�h";
        private const string DELETE_MODE = "�폜���[�h";

        //----- ueno upd ---------- start 2008.02.18
        private const string COMMON_MODE = "�S��";
        //----- ueno upd ---------- end 2008.02.18

        // �ėp�V���|���ݒ�
        private const string RATE_NEW = "�V�|���ݒ�(&L)";
        private const string RATE_OLD = "���|���ݒ�(&L)";
		

        // Message�֘A��`
        private const string ASSEMBLY_ID = "DCKHN09160UA";
        private const string ERR_READ_MSG = "�ǂݍ��݂Ɏ��s���܂����B";
        private const string NOT_FOUND_MSG = "�f�[�^�����݂��܂���ł����B";
        private const string ERR_DPR_MSG = "���̃R�[�h�͊��Ɏg�p����Ă��܂��B";
        private const string ERR_LRDEL_MSG = "�_���폜�Ɏ��s���܂����B";
        private const string ERR_PRDEL_MSG = "�����폜�Ɏ��s���܂����B";
        private const string ERR_UPDT_MSG = "�o�^�Ɏ��s���܂����B";
        private const string ERR_RVV_MSG = "�����Ɏ��s���܂����B";
        private const string ERR_800_MSG = "���ɑ��[�����X�V����Ă��܂�";
        private const string ERR_801_MSG = "���ɑ��[�����폜����Ă��܂�";
        private const string SDC_RDEL_MSG = "�}�X�^����폜����Ă��܂�";
        private const string RATE_CPY_MSG = "�V�|���ݒ�̃f�[�^�����|���ݒ�ֈړ����܂��B\n��낵���ł����H";
        private const string ALL_DEL_MSG = "�S�Ẵf�[�^������������܂�����낵���ł����H";
        private const string RATE_ERR_MSG = "�P�����|���̉��ꂩ��ݒ肵�Ă��������B";
        private const string RATE_ERR_MSG2 = "�|���ݒ�ɖ����͍��ڂ����݂��܂��B";
        private const string RATE_SAVE_MSG = "�|���ݒ�}�X�^�Ƀf�[�^��o�^���܂����H";
        private const string RATE_STDATE_MSG = "�u�V�|���J�n���@���@���|���J�n���v�Őݒ肵�Ă��������B";
        private const string DATASET_NG_MSG = "�f�[�^�e�[�u���ւ̕ۑ��Ɏ��s���܂����B";
        private const string DISP_CHG_MSG = "���ύX����܂����B\n�������ʂ�����������܂��B��낵���ł����H";
        private const string PHY_DEL_MSG = "�f�[�^���폜���܂��B\r\n��낵���ł����H";
        private const string LOG_OLDDEL_MSG = "�\���f�[�^���폜���܂����H";
        private const string PHY_OLDDEL_MSG = "���|���f�[�^�y�сA�֘A���b�g�f�[�^�����S�폜���܂��B\r\n��낵���ł����H";
        private const string SAV_INFO_MSG = "�ۑ����܂����B";
        private const string LDEL_INFO_MSG = "�_���폜���܂����B";
        private const string REV_INFO_MSG = "�������܂����B";
        private const string PDEL_INFO_MSG = "�����폜���܂����B";
        private const string DISP_CLR_MSG = "���݁A�ҏW���̃f�[�^�����݂��܂��B\n������Ԃɖ߂��܂����H";
        private const string PHY_OLDDEL_INFO_MSG = "���|���f�[�^�y�сA�֘A���b�g�f�[�^�𕨗��폜���܂����B";

        // �R���{�{�b�N�X�p
        private const string COMBO_CODE = "COMBO_CODE";
        private const string COMBO_NAME = "COMBO_NAME";

        //------------
        // ���͏����p
        //------------
        // �S�̓��̓R���g���[���p
        private const string ALLCTRL_ACTIVE_TAB = "��ʃ^�u";
        private const string ALLCTRL_INPUT_STATUS = "��ʓ��͏�";
        private const string ALLCTRL_RATECOND_PANEL = "�|���ݒ�p�l��";
        private const string ALLCTRL_SINGLE_PANEL = "�P�i�ݒ�p�l��";
        private const string ALLCTRL_GRP_PANEL = "���i�f�ݒ�p�l��";
        private const string ALLCTRL_CUSTOMER_PANEL = "�����p�l��";
        private const string ALLCTRL_SEARCH_UBUTTON = "�����{�^��";
        private const string ALLCTRL_LOT_PANEL = "���b�g�J�n���p�l��";
        private const string ALLCTRL_NEWRATE_PANEL = "�V�|���p�l��";
        private const string ALLCTRL_OLDRATE_PANEL = "���|���p�l��";
        private const string ALLCTRL_COPYTOOLDFROMNEWBTN = "�V�|�������|��";
        private const string ALLCTRL_RATE_OK_BUTTON = "�ۑ��{�^��";
        private const string ALLCTRL_RATE_LOGICALDELBTN = "�_���폜�{�^��";
        private const string ALLCTRL_RATE_PHYSICALDELBTN = "�����폜�{�^��";
        private const string ALLCTRL_RATE_REVIVEBTN = "�����{�^��";
        private const string ALLCTRL_RATE_UTABPAGECONTROL = "�|���^�u";
        private const string ALLCTRL_LOT_UTABPAGECONTROL = "���b�g�^�u";

        // ���͏����p
        private const string COND_UNITPRICEKIND = "�P�����";
        private const string COND_UNITPRICEKINDWAYCD = "�ݒ���@";
        private const string COND_GOODSNO = "���i�ԍ�";
        private const string COND_GOODSMAKERCD = "���i���[�J�[�R�[�h";
        private const string COND_GOODSRATERANK = "���i�|�������N";
        private const string COND_LARGEGOODSGANRECODE = "���i�敪�O���[�v�R�[�h";
        private const string COND_MEDIUMGOODSGANRECODE = "���i�敪�R�[�h";
        private const string COND_DETAILGOODSGANRECODE = "���i�敪�ڍ׃R�[�h";
        private const string COND_ENTERPRISEGANRECODE = "���Е��ރR�[�h";
        private const string COND_BLGOODSCODE = "BL���i�R�[�h";
        private const string COND_CUSTOMERCODE = "���Ӑ�R�[�h";
        private const string COND_CUSTRATEGRPCODE = "���Ӑ�|���O���[�v�R�[�h";
        private const string COND_SUPPLIERCD = "�d����R�[�h";
        private const string COND_SUPPRATEGRPCODE = "�d����|���O���[�v�R�[�h";
        private const string COND_RATESTARTDATE = "�|���J�n��";
        private const string COND_PRICE = "���i";
        private const string COND_PRICEDIV = "���i�敪";
        private const string COND_UNPRCCALCDIV = "�P���Z�o�敪";
        private const string COND_RATEMNGGOODSCD = "�|���ݒ�敪�i���i�j";
        private const string COND_RATEMNGCUSTCD = "�|���ݒ�敪�i���Ӑ�j";

        // �t�@�C�����C�A�E�g�֘A
        private const string OLDNEWDIVCD_NEW = "0";	// �V���t���O�i�V�j
        private const string OLDNEWDIVCD_OLD = "1";	// �V���t���O�i���j

        // ���[�U�[�K�C�h�f�[�^�֘A
        private const int GUIDEDIVCD_CUSTRATEGRPCODE = 43;	// �K�C�h�敪�i���Ӑ�|���O���[�v�j
        private const int GUIDEDIVCD_SUPPRATEGRPCODE = 44;	// �K�C�h�敪�i�d����|���O���[�v�j
        private const int GUIDEDIVCD_ENTERPRISEGANRECODE = 41;	// �K�C�h�敪�i���Е��ށj
        private const int GUIDEDIVCD_PRICEDIV = 47;	// �K�C�h�敪�i���i�敪�j
        private const int GUIDEDIVCD_BARGAINCD = 42;	// �K�C�h�敪�i�����敪�j
        
        #endregion

        #region enum

        /// <summary>
        /// �S�̉�ʓ��͏�
        /// </summary>
        private enum AllCtrlInputStatus
        {
            // ����(�|���ݒ�)
            New = 0,

            // �����ݒ�
            InputCondition = 1,

            // ������V�KӰ��,
            // �폜Ӱ�ޕ����폜��
            SearchNew = 2,

            // ������X�VӰ��
            // �V�KӰ�ޕۑ���
            // �X�VӰ�ޕۑ���
            // �폜Ӱ�ޕ�����
            SearchUpdate = 3,

            // ������폜Ӱ��
            SearchDelete = 4
        }
        
        /// <summary>
        /// �S�̉�ʓ��͏󋵃A�N�e�B�u�^�u
        /// </summary>
        private enum AllCtrlActiveTab
        {
            // �|���^�u
            Rate = 0,
            // ���b�g�^�u
            Lot = 1
        }

        /// <summary>
        /// ���[�h�t���O
        /// </summary>
        private enum ModeFlag
        {
            // ���m��
            None = 0,
            // �V�K
            New = 1,
            // �X�V
            Update = 2,
            // �폜
            Delete = 3
        }

        /// <summary>
        /// ��ʃf�[�^�ݒ�X�e�[�^�X
        /// </summary>
        private enum DispSetStatus
        {
            // �N���A
            Clear = 0,
            // �X�V
            Update = 1,
            // ���ɖ߂�
            Back = 2
        }

        /// <summary>
        /// ���̓G���[�`�F�b�N�X�e�[�^�X
        /// </summary>
        private enum InputChkStatus
        {
            // ������
            NotInput = -1,
            // ���݂��Ȃ�
            NotExist = -2,
            // ���̓~�X
            InputErr = -3,
            // ����
            Normal = 0,

            //----- ueno add ---------- start 2008.03.04
            // �L�����Z���i�B�������p�j
            Cancel = 1
            //----- ueno add ---------- end 2008.03.04			
        }
        #endregion
           --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
		// ===================================================================================== //
		// �������\�b�h
		// ===================================================================================== //
		# region Private Methods

		/// <summary>��ʏ����ݒ菈��</summary>
		/// <remarks>
		/// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.10.03</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			//--------------------------
			// ���[�U�[�K�C�h�f�[�^�擾
			//--------------------------
			ArrayList userGdBdList;

			// ���Ӑ�|���O���[�v
			userGdBdList = null;
			GetUserGdBdList(out userGdBdList, GUIDEDIVCD_CUSTRATEGRPCODE);
			SetUserGdBd(ref this._custRateGrpCodeSList, ref userGdBdList);

            // �d����|���O���[�v
            userGdBdList = null;
            GetUserGdBdList(out userGdBdList, GUIDEDIVCD_SUPPRATEGRPCODE);
            SetUserGdBd(ref this._suppRateGrpCodeSList  , ref userGdBdList);
			
            // ���Е��ރR�[�h
            userGdBdList = null;
            GetUserGdBdList(out userGdBdList, GUIDEDIVCD_ENTERPRISEGANRECODE);
            SetUserGdBd(ref this._enterpriseGanreCodeSList, ref userGdBdList);
			
            // ���i�敪
            userGdBdList = null;
            GetUserGdBdList(out userGdBdList, GUIDEDIVCD_PRICEDIV);
            SetUserGdBd(ref this._priceDivSList, ref userGdBdList);
			
            // �����敪
            userGdBdList = null;
            GetUserGdBdList(out userGdBdList, GUIDEDIVCD_BARGAINCD);
            SetUserGdBd(ref this._bargainCdSList, ref userGdBdList);

            //--------------
            // ���͏����ݒ�
            //--------------
            SetDataTableCond(ref Rate._setDataAllInpCtrl,		ref this._dataTableAllInpCtrl);
            SetDataTableCond(ref Rate._setDataInpCond,			ref this._dataTableInpCond);
            SetDataTableCond(ref Rate._setDataGoodsRateCond,	ref this._dataTableRateGoodsCond);
            SetDataTableCond(ref Rate._setDataCustRateCond,		ref this._dataTableRateCustCond);
            SetDataTableCond(ref Rate._setDataRateInpCond,		ref this._dataTableRateInpCond);

            //------------------------------------
            // �R���{�{�b�N�X�p�f�[�^�e�[�u���ݒ�
            //------------------------------------
            SetComboData(ref Rate._unitPriceKindTable,				ref this._dataTableUnitPriceKind);
            SetComboData(ref Rate._unitPriceKindWayTable,			ref this._dataTableUnitPriceKindWay);
            SetComboDataDefault(ref this._custRateGrpCodeSList,		ref this._dataTableCustRateGrpCode);
            SetComboDataDefault(ref this._suppRateGrpCodeSList,		ref this._dataTableSuppRateGrpCode);
            SetComboDataDefault(ref this._enterpriseGanreCodeSList, ref this._dataTableEnterpriseGanreCode);
            SetComboData(ref this._priceDivSList,					ref this._dataTablePriceDiv);
            SetComboData(ref Rate._unPrcCalcDivTable,				ref this._dataTableUnPrcCalcDivNew);
            SetComboData(ref Rate._unPrcCalcDivTable,				ref this._dataTableUnPrcCalcDivOld);

            SetComboData(ref Rate._unPrcFracProcDivTable,			ref this._dataTableUnPrcFracProcDiv);

            SetComboData(ref this._bargainCdSList,					ref this._dataTableBargainCd);

            //--------------------
            // �R���{�{�b�N�X�ݒ�
            //--------------------
            BindCombo(ref this.UnitPriceKind_tComboEditor,				ref this._dataTableUnitPriceKind);
            BindCombo(ref this.UnitPriceKindWay_tComboEditor,			ref this._dataTableUnitPriceKindWay);
            BindCombo(ref this.CustRateGrpCode_tComboEditor,			ref this._dataTableCustRateGrpCode);
            BindCombo(ref this.SuppRateGrpCode_tComboEditor,			ref this._dataTableSuppRateGrpCode);
            BindCombo(ref this.EnterpriseGanreCode_Grp_tComboEditor,	ref this._dataTableEnterpriseGanreCode);
            BindCombo(ref this.NewPriceDiv_tComboEditor,				ref this._dataTablePriceDiv);
            BindCombo(ref this.NewUnPrcCalcDiv_tComboEditor,			ref this._dataTableUnPrcCalcDivNew);
            BindCombo(ref this.NewUnPrcFracProcDiv_tComboEditor,		ref this._dataTableUnPrcFracProcDiv);
            BindCombo(ref this.NewBargainCd_tComboEditor,				ref this._dataTableBargainCd);
            BindCombo(ref this.OldPriceDiv_tComboEditor,				ref this._dataTablePriceDiv);
            BindCombo(ref this.OldUnPrcCalcDiv_tComboEditor,			ref this._dataTableUnPrcCalcDivOld);
            BindCombo(ref this.OldUnPrcFracProcDiv_tComboEditor,		ref this._dataTableUnPrcFracProcDiv);
            BindCombo(ref this.OldBargainCd_tComboEditor,				ref this._dataTableBargainCd);
        }

        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^�{�f�B�����X�g�擾����
        /// </summary>
        /// <param name="userGdBdList">���[�U�[�K�C�h���X�g</param>
        /// <param name="guideDivCode">���[�U�[�K�C�h�敪</param>
        /// <returns>STATUS [0:�擾 0�ȊO:�擾���s]</returns>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^�{�f�B���̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.11.05</br>
        /// </remarks>
        public int GetUserGdBdList(out ArrayList userGdBdList, int guideDivCode)
        {
            userGdBdList = null;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			
            try
            {
                status = this._userGuideAcs.SearchAllDivCodeBody(out userGdBdList, this._enterpriseCode, guideDivCode, UserGuideAcsData.UserBodyData);
            }
            catch (Exception e)
            {
                TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.ToString(),
                    "���[�U�[�K�C�h�i�w�b�_�j���̎擾�Ɏ��s���܂����B" + "\r\n" + e.Message,
                    -1,
                    MessageBoxButtons.OK);

                status = -1;
            }
            return status;
        }
		
        /// <summary>
        /// ���[�U�[�K�C�h�{�f�B�f�[�^�ݒ菈��
        /// </summary>
        /// <param name="sList">���[�U�[�K�C�hSortedList</param>
        /// <param name="userGdBdList">���[�U�[�K�C�h���X�g</param>
        /// <returns>STATUS [0:�擾 0�ȊO:�擾���s]</returns>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�{�f�B�f�[�^��ݒ肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.11.05</br>
        /// </remarks>
        public void SetUserGdBd(ref SortedList sList, ref ArrayList userGdBdList)
        {
            foreach (UserGdBd userGdBd in userGdBdList)
            {
                sList.Add(userGdBd.GuideCode, userGdBd.GuideName);
            }
        }
	
        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.03</br>
        /// </remarks>
        private void ScreenClear()
        {
            //----------------
            // �e�t���O������
            //----------------
            // �p�l���\���ۏ�����
            this.Single_panel.Show();
            this.Grp_panel.Hide();

            // ���͏󋵃t���O������
            this._AllCtrlInputStatus = AllCtrlInputStatus.New;
			
            // ���[�h���x��������
            this._modeFlag = ModeFlag.None;	// ���m��

            //------------
            // ����������
            //------------
            // �O��̌������ʃf�[�^���c���Ă���ꍇ�폜
            if (this._dataTableRate != null)
            {
                this._dataTableRate.Rows.Clear();
            }
            if (this._rateSrchRsltHashList != null)
            {
                this._rateSrchRsltHashList = new Hashtable();
            }
            // �����f�[�^������΃N���A
            if (this._searchRate.EnterpriseCode != null)
            {
                this._searchRate = null;
                this._searchRate = new Rate();
            }
			
            //------------------
            // �ݒ�f�[�^�N���A
            //------------------
            this._unitPriceKindtComboEditorValue	= NullChgInt(Rate._unitPriceKindTable.GetKey(0));		// �P����ރR���{�{�b�N�X
            this._unitPriceKindWaytComboEditorValue = NullChgInt(Rate._unitPriceKindWayTable.GetKey(0));	// �ݒ���@�R���{�{�b�N�X
			
            // �R���{�{�b�N�X������
            this.UnitPriceKind_tComboEditor.Value			= Rate._unitPriceKindTable.GetKey(0);			// �P�����
            this.UnitPriceKindWay_tComboEditor.Value		= Rate._unitPriceKindWayTable.GetKey(0);		// �ݒ���@
            this.CustRateGrpCode_tComboEditor.Clear();														// ���Ӑ�|���O���[�v
            this.SuppRateGrpCode_tComboEditor.Clear();														// �d����|���O���[�v
            this.EnterpriseGanreCode_Grp_tComboEditor.Clear();												// ���Е���
            this.NewPriceDiv_tComboEditor.Value				= this._priceDivSList.GetKey(0);				// �V����i�敪
            this.NewUnPrcCalcDiv_tComboEditor.Value			= Rate._unPrcCalcDivTable.GetKey(0);			// �V�P���Z�o�敪
            this.NewUnPrcFracProcDiv_tComboEditor.Value		= Rate._unPrcFracProcDivTable.GetKey(0);		// �V�P���[�������敪
            this.NewBargainCd_tComboEditor.Value			= this._bargainCdSList.GetKey(0);				// �V�����敪
            this.OldPriceDiv_tComboEditor.Value				= this._priceDivSList.GetKey(0);				// ������i�敪
            this.OldUnPrcCalcDiv_tComboEditor.Value			= Rate._unPrcCalcDivTable.GetKey(0);			// ���P���Z�o�敪
            this.OldUnPrcFracProcDiv_tComboEditor.Value		= Rate._unPrcFracProcDivTable.GetKey(0);		// ���P���[�������敪
            this.OldBargainCd_tComboEditor.Value			= this._bargainCdSList.GetKey(0);				// �������敪
			
            // �R���{�{�b�N�X�t�B���^�[�N���A
            this._dataTableUnPrcCalcDivNew.DefaultView.RowFilter = "";
            this._dataTableUnPrcCalcDivOld.DefaultView.RowFilter = "";

            // �w�b�_����
            this.RateSectionCode_tEdit.Clear();			// ���_�R�[�h
            this.SectionCodeNm_tEdit.Clear();		// ���_����
            this.RateSettingDivide_tEdit.Clear();	// �|���ݒ�敪
            this.RateMngGoodsCd_tEdit.Clear();		// ���i�ݒ�敪�i�R�[�h�j
            this.RateMngGoodsNm_tEdit.Clear();		// ���i�ݒ�敪�i���́j
            this.RateMngCustCd_tEdit.Clear();		// �����ݒ�敪�i�R�[�h�j
            this.RateMngCustNm_tEdit.Clear();		// �����ݒ�敪�i���́j
            this.Mode_Label.Text = "";

            // �P�i�ݒ荀��
            this.GoodsNoCd_tEdit.Clear();					// ���i�R�[�h
            this.GoodsNoNm_tEdit.Clear();					// ���i����
            this.GoodsMakerCd_tNedit.Clear();				// ���i���[�J�[�R�[�h
            this.GoodsMakerCdNm_tEdit.Clear();				// ���i���[�J�[�R�[�h�i���́j

            // �O���[�v�ݒ荀��
            this.GoodsMakerCd_Grp_tNedit.Clear();			// ���i���[�J�[�R�[�h
            this.GoodsMakerCdNm_Grp_tEdit.Clear();			// ���i���[�J�[�R�[�h�i���́j
            this.GoodsRateRankCd_Grp_tEdit.Clear();			// ���i�|�������N
            this.LargeGoodsGanreCode_Grp_tEdit.Clear();		// ���i�敪�O���[�v�R�[�h
            this.LargeGoodsGanreCodeNm_Grp_tEdit.Clear();	// ���i�敪�O���[�v�R�[�h�i���́j
            this.MediumGoodsGanreCode_Grp_tEdit.Clear();	// ���i�敪�R�[�h
            this.MediumGoodsGanreCodeNm_Grp_tEdit.Clear();	// ���i�敪�R�[�h�i���́j
            this.DetailGoodsGanreCode_Grp_tEdit.Clear();	// ���i�敪�ڍ׃R�[�h
            this.DetailGoodsGanreCodeNm_Grp_tEdit.Clear();	// ���i�敪�ڍ׃R�[�h�i���́j
            this.BLGoodsCode_Grp_tNedit.Clear();			// �a�k���i�R�[�h
            this.BLGoodsCodeNm_Grp_tEdit.Clear();			// �a�k���i�R�[�h�i���́j
			
            // �����ݒ荀��
            this.CustomerCode_tNedit.Clear();				// ���Ӑ�R�[�h
            this.CustomerCodeNm_tEdit.Clear();				// ���Ӑ於��
            this.SupplierCd_tNedit.Clear();					// �d����R�[�h
            this.SupplierCdNm_tEdit.Clear();				// �d���於��

            // �V�|���ݒ荀��
            this.NewRateStartDate_tDateEdit.Clear();		// �|���J�n��
            this.NewPrice_tNedit.Clear();					// �P��
            this.NewRate_tNedit.Clear();					// �|��
            this.NewUnPrcFracProcUnit_tNedit.Clear();		// �P���[�������P��
			
            // ���|���ݒ荀��
            this.OldRateStartDate_tDateEdit.Clear();		// �|���J�n��
            this.OldPrice_tNedit.Clear();					// �P��
            this.OldRate_tNedit.Clear();					// �|��
            this.OldUnPrcFracProcUnit_tNedit.Clear();		// �P���[�������P��

            //--------------------
            // ���͐���i�p�l���j
            //--------------------
            // �ݒ菉����
            this.RateCond_panel.Enabled = true;			// �|���ݒ�p�l��
            this.Single_panel.Enabled = false;			// �P�i�ݒ�p�l��
            this.Grp_panel.Enabled = false;				// ���i�f�ݒ�p�l��
            this.Customer_panel.Enabled = false;		// �����p�l��
            this.NewRate_panel.Enabled = false;			// �V�|���p�l���i�|���^�u���j
            this.OldRate_panel.Enabled = false;			// ���|���p�l���i�|���^�u���j
            this.Rate_uTabPageControl.Enabled = false;	// �|���^�u
            this.Lot_uTabPageControl.Enabled = false;	// ���b�g�^�u

            //--------------
            // ���͐���ݒ�
            //--------------
            // ����n�{�^���ݒ�
            this.Search_uButton.Enabled = false;					// �����{�^��
            this.CopyToOldFromNewbtn.Enabled = false;				// �V�|�������|���i�|���^�u���j
            this.Rate_Ok_Btn.Enabled = true;						// �ۑ��{�^���i�|���^�u���j
			this.Rate_LogicalDel_Btn.Enabled = false;				// �_���폜�{�^���i�|���^�u���j
			this.Rate_PhysicalDelBtn.Enabled = false;				// �����폜�{�^���i�|���^�u���j
			this.Rate_ReviveBtn.Enabled = false;					// �����{�^���i�|���^�u���j
			this.Lot_Ok_Btn.Enabled = true;							// �ۑ��{�^���i���b�g�^�u���j
			this.Lot_Clear_Btn.Enabled = true;						// �����폜�{�^���i���b�g�^�u���j
            
            // ���ڃ{�^���ݒ�
			this.GoodsNo_uButton.Enabled = false;					// ���i�ԍ��i�P�i�j
			this.GoodsMakerCd_uButton.Enabled = false;				// ���i���[�J�[�i�P�i�j
            this.GoodsMakerCd_Grp_uButton.Enabled = false;			// ���i���[�J�[
			this.LargeGoodsGanreCode_Grp_uButton.Enabled = false;	// ���i�敪�O���[�v�R�[�h
			this.MediumGoodsGanreCode_Grp_uButton.Enabled = false;	// ���i�敪
			this.DetailGoodsGanreCode_Grp_uButton.Enabled = false;	// ���i�敪�ڍ�
			this.BLGoodsCode_Grp_uButton.Enabled = false;			// �a�k���i
			this.CustomerCode_uButton.Enabled = false;				// ���Ӑ�
			this.SupplierCd_uButton.Enabled = false;				// �d����
			this.NewRateStartDate_tDateEdit.Enabled = false;		// �V�|���J�n�J�����_�[
			this.OldRateStartDate_tDateEdit.Enabled = false;		// ���|���J�n�J�����_�[
			
			// �P�i�ݒ�
			this.GoodsNoCd_tEdit.Enabled = false;					// ���i�R�[�h
			this.GoodsMakerCd_tNedit.Enabled = false;				// ���i���[�J�[�R�[�h
            
            // �O���[�v�ݒ�
			this.GoodsMakerCd_Grp_tNedit.Enabled = false;			// ���i���[�J�[�R�[�h
			this.GoodsRateRankCd_Grp_tEdit.Enabled = false;			// ���i�|�������N
			this.LargeGoodsGanreCode_Grp_tEdit.Enabled = false;		// ���i�敪�O���[�v�R�[�h
			this.MediumGoodsGanreCode_Grp_tEdit.Enabled = false;	// ���i�敪�R�[�h
			this.DetailGoodsGanreCode_Grp_tEdit.Enabled = false;	// ���i�敪�ڍ׃R�[�h
			this.BLGoodsCode_Grp_tNedit.Enabled = false;			// �a�k���i�R�[�h
			
			// �����ݒ�
			this.CustomerCode_tNedit.Enabled = false;				// ���Ӑ�R�[�h
			this.CustRateGrpCode_tComboEditor.Enabled = false;		// ���Ӑ�|���O���[�v
			this.SupplierCd_tNedit.Enabled = false;					// �d����R�[�h
			this.SuppRateGrpCode_tComboEditor.Enabled = false;		// �d����|���O���[�v
			
			// �V�|���ݒ�
			this.NewPrice_tNedit.Enabled = false;					// �V���i
			this.NewPriceDiv_tComboEditor.Enabled = false;			// �V����i�敪
			this.NewUnPrcCalcDiv_tComboEditor.Enabled = false;		// �V�P���Z�o�敪
			this.NewRate_tNedit.Enabled = false;					// �V�|��
			this.NewUnPrcFracProcUnit_tNedit.Enabled = false;		// �V�P���[�������P��
			this.NewUnPrcFracProcDiv_tComboEditor.Enabled = false;	// �V�P���[�������敪
			this.NewBargainCd_tComboEditor.Enabled = false;			// �V�����敪�R�[�h

			// ���|���ݒ�
			this.OldPrice_tNedit.Enabled = false;					// �����i
			this.OldPriceDiv_tComboEditor.Enabled = false;			// ������i�敪
			this.OldUnPrcCalcDiv_tComboEditor.Enabled = false;		// ���P���Z�o�敪
			this.OldRate_tNedit.Enabled = false;					// ���|��
			this.OldUnPrcFracProcUnit_tNedit.Enabled = false;		// ���P���[�������P��
			this.OldUnPrcFracProcDiv_tComboEditor.Enabled = false;	// ���P���[�������敪
			this.OldBargainCd_tComboEditor.Enabled = false;			// �������敪�R�[�h

			//------------
			// ���b�g���
			//------------
			// ���b�g��ʐV���{�^��
			this.LotOldNewRateStartDate_uButton.Text = RATE_NEW;
			
			// ���b�g�|���J�n��
			this.LotNewRateStartDate_tDateEdit.ReadOnly = true;
			this.LotOldRateStartDate_tDateEdit.ReadOnly = true;
			
			// �S�̓��̓R���g���[��
			SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.New.GetHashCode());
            
            this._AllCtrlInputStatus = AllCtrlInputStatus.New;
		}

		/// <summary>
		/// ��ʍč\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���[�h�Ɋ�Â��ĉ�ʂ��č\�z���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.10.03</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			// �t�H�[�J�X�ݒ�
			this.RateSectionCode_tEdit.Focus();
		}

		/// <summary>
		/// �S�̓��̓R���g���[���p�f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <param name="wkTable">�f�[�^�e�[�u��</param>
		/// <remarks>
		/// <br>Note       : �S�̓��̓R���g���[���p�f�[�^�Z�b�g�̗�����\�z���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.10.19</br>
		/// </remarks>
		private void DataTblColumnConstAllInpCtrl(ref DataTable wkTable)
		{
			//----------
			// ��������
			//----------
			// ��ʃ^�u
			wkTable.Columns.Add(ALLCTRL_ACTIVE_TAB, typeof(string));

			// ��ʓ��͏�
			wkTable.Columns.Add(ALLCTRL_INPUT_STATUS, typeof(string));

			//---------------------------
			// �ݒ�ہi0�F�s��, 1�F�j
			//---------------------------
			// �|���ݒ�p�l��
			wkTable.Columns.Add(ALLCTRL_RATECOND_PANEL, typeof(string));
			
			// �P�i�ݒ�p�l��
			wkTable.Columns.Add(ALLCTRL_SINGLE_PANEL, typeof(string));
			
			// ���i�f�ݒ�p�l��
			wkTable.Columns.Add(ALLCTRL_GRP_PANEL, typeof(string));
			
			// �����p�l��
			wkTable.Columns.Add(ALLCTRL_CUSTOMER_PANEL, typeof(string));
			
			// �����{�^��
			wkTable.Columns.Add(ALLCTRL_SEARCH_UBUTTON, typeof(string));
			
			// �V�|���p�l��
			wkTable.Columns.Add(ALLCTRL_NEWRATE_PANEL, typeof(string));
			
			// ���|���p�l��
			wkTable.Columns.Add(ALLCTRL_OLDRATE_PANEL, typeof(string));
			
			// �V�|�������|��
			wkTable.Columns.Add(ALLCTRL_COPYTOOLDFROMNEWBTN, typeof(string));
			
			// �ۑ��{�^��
			wkTable.Columns.Add(ALLCTRL_RATE_OK_BUTTON, typeof(string));
			
			// �_���폜�{�^��
			wkTable.Columns.Add(ALLCTRL_RATE_LOGICALDELBTN, typeof(string));
			
			// �����폜�{�^��
			wkTable.Columns.Add(ALLCTRL_RATE_PHYSICALDELBTN, typeof(string));
			
			// �����{�^��
			wkTable.Columns.Add(ALLCTRL_RATE_REVIVEBTN, typeof(string));
			
			// �|���^�u
			wkTable.Columns.Add(ALLCTRL_RATE_UTABPAGECONTROL, typeof(string));
			
			// ���b�g�^�u
			wkTable.Columns.Add(ALLCTRL_LOT_UTABPAGECONTROL, typeof(string));
			
			// �v���C�}���L�[�ݒ�
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[ALLCTRL_ACTIVE_TAB], wkTable.Columns[ALLCTRL_INPUT_STATUS] };
		}

		/// <summary>
		/// ���͏����ݒ�p�f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���͏����ݒ�p�f�[�^�Z�b�g�̗�����\�z���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.10.05</br>
		/// </remarks>
		private void DataTblColumnConstInpCond(ref DataTable wkTable)
		{
			//----------
			// ��������
			//----------
			// �P�����
			wkTable.Columns.Add(COND_UNITPRICEKIND, typeof(string));

			// �ݒ���@
			wkTable.Columns.Add(COND_UNITPRICEKINDWAYCD, typeof(string));

			//---------------------------
			// �ݒ�ہi0�F�s��, 1�F�j
			//---------------------------
			// ���i�ԍ�
			wkTable.Columns.Add(COND_GOODSNO, typeof(string));

			// ���i���[�J�[�R�[�h
			wkTable.Columns.Add(COND_GOODSMAKERCD, typeof(string));

			// ���i�|�������N
			wkTable.Columns.Add(COND_GOODSRATERANK, typeof(string));

			// ���i�敪�O���[�v�R�[�h
			wkTable.Columns.Add(COND_LARGEGOODSGANRECODE, typeof(string));

			// ���i�敪�R�[�h
			wkTable.Columns.Add(COND_MEDIUMGOODSGANRECODE, typeof(string));

			// ���i�敪�ڍ׃R�[�h
			wkTable.Columns.Add(COND_DETAILGOODSGANRECODE, typeof(string));

			// ���Е��ރR�[�h
			wkTable.Columns.Add(COND_ENTERPRISEGANRECODE, typeof(string));

			// BL���i�R�[�h
			wkTable.Columns.Add(COND_BLGOODSCODE, typeof(string));

			// ���Ӑ�R�[�h
			wkTable.Columns.Add(COND_CUSTOMERCODE, typeof(string));

			// ���Ӑ�|���O���[�v�R�[�h
			wkTable.Columns.Add(COND_CUSTRATEGRPCODE, typeof(string));

			// �d����R�[�h
			wkTable.Columns.Add(COND_SUPPLIERCD, typeof(string));

			// �d����|���O���[�v�R�[�h
			wkTable.Columns.Add(COND_SUPPRATEGRPCODE, typeof(string));

			// �v���C�}���L�[�ݒ�
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COND_UNITPRICEKIND], wkTable.Columns[COND_UNITPRICEKINDWAYCD] };
		}

		/// <summary>
		/// ���i�|�������ݒ�p�f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���i�|�������ݒ�p�f�[�^�Z�b�g�̗�����\�z���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.10.09</br>
		/// </remarks>
		private void DataTblColumnConstGoodsRateCond(ref DataTable wkTable)
		{
			//----------
			// ��������
			//----------
			// �敪
			wkTable.Columns.Add(COND_RATEMNGGOODSCD, typeof(string));

			//---------------------------
			// �ݒ�ہi0�F�s��, 1�F�j
			//---------------------------
			// ���i�ԍ�
			wkTable.Columns.Add(COND_GOODSNO, typeof(string));

			// ���i���[�J�[�R�[�h
			wkTable.Columns.Add(COND_GOODSMAKERCD, typeof(string));

			// ���i�|�������N
			wkTable.Columns.Add(COND_GOODSRATERANK, typeof(string));

			// ���i�敪�O���[�v�R�[�h
			wkTable.Columns.Add(COND_LARGEGOODSGANRECODE, typeof(string));

			// ���i�敪�R�[�h
			wkTable.Columns.Add(COND_MEDIUMGOODSGANRECODE, typeof(string));

			// ���i�敪�ڍ׃R�[�h
			wkTable.Columns.Add(COND_DETAILGOODSGANRECODE, typeof(string));

			// ���Е��ރR�[�h
			wkTable.Columns.Add(COND_ENTERPRISEGANRECODE, typeof(string));

			// BL���i�R�[�h
			wkTable.Columns.Add(COND_BLGOODSCODE, typeof(string));

			// �v���C�}���L�[�ݒ�
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COND_RATEMNGGOODSCD] };
		}

		/// <summary>
		/// ���Ӑ�|�������ݒ�p�f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���Ӑ�|�������ݒ�p�f�[�^�Z�b�g�̗�����\�z���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.10.09</br>
		/// </remarks>
		private void DataTblColumnConstCustRateCond(ref DataTable wkTable)
		{
			//----------
			// ��������
			//----------
			// �敪
			wkTable.Columns.Add(COND_RATEMNGCUSTCD, typeof(string));

			//---------------------------
			// �ݒ�ہi0�F�s��, 1�F�j
			//---------------------------
			// ���Ӑ�R�[�h
			wkTable.Columns.Add(COND_CUSTOMERCODE, typeof(string));
			
			// ���Ӑ�|���O���[�v�R�[�h
			wkTable.Columns.Add(COND_CUSTRATEGRPCODE, typeof(string));
			
			// �d����R�[�h
			wkTable.Columns.Add(COND_SUPPLIERCD, typeof(string));
			
			// �d����|���O���[�v�R�[�h
			wkTable.Columns.Add(COND_SUPPRATEGRPCODE, typeof(string));
			
			// �v���C�}���L�[�ݒ�
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COND_RATEMNGCUSTCD] };
		}

		/// <summary>
		/// �V���|�����͏����p�f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �V���|�����͏����p�f�[�^�Z�b�g�̗�����\�z���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.10.11</br>
		/// </remarks>
		private void DataTblColumnConstRateInp(ref DataTable wkTable)
		{
			//----------
			// ��������
			//----------
			// �P�����
			wkTable.Columns.Add(COND_UNITPRICEKIND, typeof(string));

			// �ݒ���@
			wkTable.Columns.Add(COND_UNITPRICEKINDWAYCD, typeof(string));

			//---------------------------
			// �ݒ�ہi0�F�s��, 1�F�j
			//---------------------------
			// �|���J�n��
			wkTable.Columns.Add(COND_RATESTARTDATE, typeof(string));

			// ���i
			wkTable.Columns.Add(COND_PRICE, typeof(string));

			// ���i�敪
			wkTable.Columns.Add(COND_PRICEDIV, typeof(string));

			// �P���Z�o�敪
			wkTable.Columns.Add(COND_UNPRCCALCDIV, typeof(string));

			// �v���C�}���L�[�ݒ�
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COND_UNITPRICEKIND], wkTable.Columns[COND_UNITPRICEKINDWAYCD] };
		}

		/// <summary>
		/// �����ݒ�p�f�[�^�ݒ�
		/// </summary>
		/// <param name="al">�����ݒ�ArrayList</param>
		/// <param name="dataTable">�f�[�^�e�[�u��</param>
		/// <remarks>
		/// <br>Note       : �����ݒ�p�f�[�^��ݒ肵�܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.10.09</br>
		/// </remarks>
		private void SetDataTableCond(ref ArrayList al, ref DataTable dataTable)
		{
			try
			{
				foreach (string[] wkAl in (ArrayList)al)
				{
					if (dataTable.Columns.Count == wkAl.Length)
					{
						DataRow dr = dataTable.NewRow();

						for (int i = 0; i < dataTable.Columns.Count; i++)
						{
							dr[i] = wkAl[i];
						}
						dataTable.Rows.Add(dr);
					}
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// ���͏����f�[�^�擾
		/// </summary>
		/// <param name="primaryKey1">�v���C�}���L�[�P</param>
		/// <param name="primaryKey2">�v���C�}���L�[�Q</param>
		/// <param name="chkStr">�`�F�b�N������</param>
		/// <param name="dataTable">�f�[�^�e�[�u��</param>
		/// <returns>���ʕ�����</returns>
		/// <remarks>
		/// <br>Note       : ���͏����f�[�^���擾���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.10.05</br>
		/// </remarks>
		private string GetDataInpCond(string primaryKey1, string primaryKey2, string chkStr, ref DataTable dataTable)
		{
			string retStr = "0";

			DataRow chkRow = dataTable.Rows.Find(new object[] { primaryKey1, primaryKey2 });
			if (chkRow != null)
			{
				retStr = (string)chkRow[chkStr];
			}
			return retStr;
		}

		/// <summary>
		/// �|�������f�[�^�擾
		/// </summary>
		/// <param name="code">�R�[�h</param>
		/// <param name="chkStr">����</param>
		/// <param name="dataTable">�f�[�^�e�[�u��</param>
		/// <returns>���ʕ�����</returns>
		/// <remarks>
		/// <br>Note       : �|�������f�[�^���擾���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.10.05</br>
		/// </remarks>
		private string GetDataRateSettingCond(string code, string chkStr, ref DataTable dataTable)
		{
			string retStr = "0";

			DataRow chkRow = dataTable.Rows.Find(code);
			if (chkRow != null)
			{
				retStr = (string)chkRow[chkStr];
			}
			return retStr;
		}

		/// <summary>
		/// �R���{�{�b�N�X�f�t�H���g�f�[�^�ݒ�
		/// </summary>
		/// <remarks>
		/// <param name="sList">�\�[�g���X�g</param>
		/// <param name="dataTable">�f�[�^�e�[�u��</param>
		/// <br>Note       : �R���{�{�b�N�X�f�t�H���g�f�[�^��擪�ɐݒ肵�܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.11.19</br>
		/// </remarks>
		private void SetComboDataDefault(ref SortedList sList, ref DataTable dataTable)
		{
			try
			{
				DataRow dr = dataTable.NewRow();

				dr[COMBO_CODE] = 0;
				dr[COMBO_NAME] = " ";

				dataTable.Rows.Add(dr);

				SetComboData(ref sList, ref dataTable);
			}
			catch
			{
			}
		}

		/// <summary>
		/// �R���{�{�b�N�X�f�[�^�ݒ�
		/// </summary>
		/// <remarks>
		/// <param name="sList">�\�[�g���X�g</param>
		/// <param name="dataTable">�f�[�^�e�[�u��</param>
		/// <br>Note       : �R���{�{�b�N�X�f�[�^��ݒ肵�܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.10.05</br>
		/// </remarks>
		private void SetComboData(ref SortedList sList, ref DataTable dataTable)
		{
			try
			{
				foreach (DictionaryEntry de in sList)
				{
					DataRow dr = dataTable.NewRow();

					dr[COMBO_CODE] = (Int32)de.Key;
					dr[COMBO_NAME] = de.Value.ToString();

					dataTable.Rows.Add(dr);
				}
			}
			catch
			{
			}
		}

		/// <summary>
		/// �R���{�{�b�N�X�o�C���h
		/// </summary>
		/// <remarks>
		/// <param name="tCombo">TComboEditor</param>
		/// <param name="dataTable">�f�[�^�e�[�u��</param>
		/// <br>Note       : �R���{�{�b�N�X�Ƀo�C���h���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.10.05</br>
		/// </remarks>
		private void BindCombo(ref TComboEditor tCombo, ref DataTable dataTable)
		{
			tCombo.DisplayMember = COMBO_NAME;
			tCombo.DataSource = dataTable.DefaultView;
		}

		/// <summary>
		/// �P����ޕύX
		/// </summary>
		/// <param name="unitPriceKind">�ݒ���@�R�[�h</param>
		/// <remarks>
		/// <br>Note�@     : �P����ނ̑I����ύX�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.10.12</br>
		/// </remarks>
		private void UnitPriceKindVisibleChange(int unitPriceKind)
		{
			if (this._unitPriceKindtComboEditorValue == unitPriceKind) return;

			// ���̓G���A���|�������ݒ�G���A�ȊO�͑S�ď���������
			if (_AllCtrlInputStatus != AllCtrlInputStatus.New )
			{
				string wkSectionCode = "";		// ���[�N���_�R�[�h
				string wkSectionCodeNm = "";	// ���[�N���_����
				
				DialogResult res = TMsgDisp.Show(
					this, 								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_INFO,		// �G���[���x��
					ASSEMBLY_ID,   						// �A�Z���u���h�c�܂��̓N���X�h�c
					ALL_DEL_MSG,						// �\�����郁�b�Z�[�W
					0, 									// �X�e�[�^�X�l
					MessageBoxButtons.YesNo, 			// �\������{�^��
					MessageBoxDefaultButton.Button2);	// �����\���{�^��

				if (res == DialogResult.Yes)
				{
					// ���_�R�[�h�݈̂ꎞ�ۑ�
					wkSectionCode = this.RateSectionCode_tEdit.Text;
					wkSectionCodeNm = this.SectionCodeNm_tEdit.Text;
					
					ScreenClear();
					
					this.UnitPriceKind_tComboEditor.Value = unitPriceKind;

					// ���_�R�[�h�ݒ�
					this.RateSectionCode_tEdit.Text = wkSectionCode;
					this.SectionCodeNm_tEdit.Text = wkSectionCodeNm;

					// ���݃f�[�^�ۑ�
					this._searchRate.SectionCode = this.RateSectionCode_tEdit.Text;
				}
				else
				{
					// �I����Ԃ�߂�
					this.UnitPriceKind_tComboEditor.Value = this._unitPriceKindtComboEditorValue;
					unitPriceKind = this._unitPriceKindtComboEditorValue;
				}
			}
			// �I��ԍ��ێ�
			this._unitPriceKindtComboEditorValue = unitPriceKind;
		}

		/// <summary>
		/// �ݒ���@�ύX
		/// </summary>
		/// <param name="unitPriceKindWay">�ݒ���@�R�[�h</param>
		/// <remarks>
		/// <br>Note�@     : �ݒ���@�̑I����ύX�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.10.05</br>
		/// </remarks>
		private void UnitPriceKindWayVisibleChange(int unitPriceKindWay)
		{
			if (this._unitPriceKindWaytComboEditorValue == unitPriceKindWay) return;
			
			// ���̓G���A���|�������ݒ�G���A�ȊO�͑S�ď���������
			if (_AllCtrlInputStatus != AllCtrlInputStatus.New)
			
			{
				string wkSectionCode = "";		// ���[�N���_�R�[�h
				string wkSectionCodeNm = "";	// ���[�N���_����
				
				DialogResult res = TMsgDisp.Show(
					this, 								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_INFO,		// �G���[���x��
					ASSEMBLY_ID,   						// �A�Z���u���h�c�܂��̓N���X�h�c
					ALL_DEL_MSG,						// �\�����郁�b�Z�[�W
					0, 									// �X�e�[�^�X�l
					MessageBoxButtons.YesNo, 			// �\������{�^��
					MessageBoxDefaultButton.Button2);	// �����\���{�^��

				if(res == DialogResult.Yes)
				{
					// ���_�R�[�h�݈̂ꎞ�ۑ�
					wkSectionCode = this.RateSectionCode_tEdit.Text;
					wkSectionCodeNm = this.SectionCodeNm_tEdit.Text;

					ScreenClear();
					this.UnitPriceKindWay_tComboEditor.Value = unitPriceKindWay;

					// ���_�R�[�h�ݒ�
					this.RateSectionCode_tEdit.Text = wkSectionCode;
					this.SectionCodeNm_tEdit.Text = wkSectionCodeNm;
					
					// ���݃f�[�^�ۑ�
					this._searchRate.SectionCode = this.RateSectionCode_tEdit.Text;
				}
				else
				{
					// �I����Ԃ�߂�
					this.UnitPriceKindWay_tComboEditor.Value = this._unitPriceKindWaytComboEditorValue;
					unitPriceKindWay = this._unitPriceKindWaytComboEditorValue;
				}
			}

			if (unitPriceKindWay == 0)
			{
				// �P�i�ݒ�
				this.Single_panel.Show();
				this.Grp_panel.Hide();
			}
			else
			{
				// ���i�O���[�v�ݒ�
				this.Single_panel.Hide();
				this.Grp_panel.Show();
			}
            
            // �I��ԍ��ێ�
			this._unitPriceKindWaytComboEditorValue = unitPriceKindWay;
		}

		/// <summary>
		/// �R���{�{�b�N�X�p�f�[�^�Z�b�g����\�z����
		/// </summary>
		/// <remarks>
		/// <param name="wkTable">�f�[�^�e�[�u��</param>
		/// <br>Note       : �R���{�{�b�N�X�p�f�[�^�Z�b�g�̗�����\�z���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.10.04</br>
		/// </remarks>
		private void DataTblColumnConstComboList(ref DataTable wkTable)
		{
			wkTable.Columns.Add(COMBO_CODE, typeof(Int32));		// �R�[�h
			wkTable.Columns.Add(COMBO_NAME, typeof(string));	// ����

			// �v���C�}���L�[�ݒ�
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COMBO_CODE] };
		}

		/// <summary>
		/// �V�|���ݒ聨���|���ݒ�ړ�����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �V�|���ݒ�����|���ݒ�ֈړ����܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.10.09</br>
		/// </remarks>
		private void CopyToOldRateFromNewRate()
		{
			// �V�|���ݒ�f�[�^�����|���ݒ�f�[�^�ɃR�s�[
			this.OldRateStartDate_tDateEdit.SetDateTime(this.NewRateStartDate_tDateEdit.GetDateTime());	// �|���J�n��
			this.OldPrice_tNedit.Value					= this.NewPrice_tNedit.Value;					// �P��
			this.OldPriceDiv_tComboEditor.Value			= this.NewPriceDiv_tComboEditor.Value;			// ����i�敪
			this.OldUnPrcCalcDiv_tComboEditor.Value		= this.NewUnPrcCalcDiv_tComboEditor.Value;		// �P���Z�o�敪
			this.OldRate_tNedit.Value					= this.NewRate_tNedit.Value;					// �|��
			this.OldUnPrcFracProcUnit_tNedit.Value		= this.NewUnPrcFracProcUnit_tNedit.Value;		// �P���[�������P��
			this.OldUnPrcFracProcDiv_tComboEditor.Value = this.NewUnPrcFracProcDiv_tComboEditor.Value;	// �P���[�������敪
			this.OldBargainCd_tComboEditor.Value		= this.NewBargainCd_tComboEditor.Value;			// �����敪�R�[�h
			
			// �V�|���J�n����1�����Z
			DateTime dtWk = this.OldRateStartDate_tDateEdit.GetDateTime();
			this.NewRateStartDate_tDateEdit.SetDateTime(dtWk.AddDays(1));
		}
        
        /// <summary>
		/// �S�̓��̓R���g���[���ݒ萧�䏈��
		/// </summary>
		/// <param name="activeTab">�A�N�e�B�u�^�u</param>
		/// <param name="allCtrlInputStatus">��ʓ��͏�</param>
		/// <remarks>
		/// <br>Note       : �S�̓��̓R���g���[���ݒ�𐧌䂵�܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.10.19</br>
		/// </remarks>
		private void SettingAllInpCtrl(int activeTab, int allCtrlInputStatus)
		{
			string inpChkStr = "";
			
			//----------------
			// �|���ݒ�p�l��
			//----------------
			// �����f�[�^�e�[�u����茟�����ʎ擾
			inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_RATECOND_PANEL, ref this._dataTableAllInpCtrl);
			
			// ����
			this.RateCond_panel.Enabled = string.Equals(inpChkStr, "1");
			
			//----------------
			// �P�i�ݒ�p�l��
			//----------------
			// �����f�[�^�e�[�u����茟�����ʎ擾
			inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_SINGLE_PANEL, ref this._dataTableAllInpCtrl);

            // ����
            this.Single_panel.Enabled = string.Equals(inpChkStr, "1");
			
            //------------------
            // ���i�f�ݒ�p�l��
            //------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_GRP_PANEL, ref this._dataTableAllInpCtrl);

            // ����
            this.Grp_panel.Enabled = string.Equals(inpChkStr, "1");

            //------------------
            // �����p�l��
            //------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_CUSTOMER_PANEL, ref this._dataTableAllInpCtrl);

            // ����
            this.Customer_panel.Enabled = string.Equals(inpChkStr, "1");

            //------------------
            // �����{�^��
            //------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_SEARCH_UBUTTON, ref this._dataTableAllInpCtrl);

            // ����
            this.Search_uButton.Enabled = string.Equals(inpChkStr, "1");

            //------------------
            // �V�|���p�l��
            //------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_NEWRATE_PANEL, ref this._dataTableAllInpCtrl);

            // ����
            this.NewRate_panel.Enabled = string.Equals(inpChkStr, "1");

            //------------------
            // ���|���p�l��
            //------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_OLDRATE_PANEL, ref this._dataTableAllInpCtrl);

            // ����
            this.OldRate_panel.Enabled = string.Equals(inpChkStr, "1");

            //------------------
            // �V�|�������|��
            //------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_COPYTOOLDFROMNEWBTN, ref this._dataTableAllInpCtrl);

            // ����
            this.CopyToOldFromNewbtn.Enabled = string.Equals(inpChkStr, "1");

            //------------------
            // �ۑ��{�^��
            //------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_RATE_OK_BUTTON, ref this._dataTableAllInpCtrl);

            // ����
            if (string.Equals(inpChkStr, "1") == true)
            {
                this.Rate_Ok_Btn.Enabled = true;
            }
            else
            {
                this.Rate_Ok_Btn.Enabled = false;
            }
			
            //------------------
            // �_���폜�{�^��
            //------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_RATE_LOGICALDELBTN, ref this._dataTableAllInpCtrl);
			
            // ����
            if (string.Equals(inpChkStr, "1") == true)
            {
                this.Rate_LogicalDel_Btn.Show();
                this.Rate_LogicalDel_Btn.Enabled = true;
            }
            else
            {
                this.Rate_LogicalDel_Btn.Hide();
                this.Rate_LogicalDel_Btn.Enabled = false;
            }
			
            //------------------
            // �����폜�{�^��
            //------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_RATE_PHYSICALDELBTN, ref this._dataTableAllInpCtrl);

            // ����
            if (string.Equals(inpChkStr, "1") == true)
            {
                this.Rate_PhysicalDelBtn.Show();
                this.Rate_PhysicalDelBtn.Enabled = true;
            }
            else
            {
                this.Rate_PhysicalDelBtn.Hide();
                this.Rate_PhysicalDelBtn.Enabled = false;
            }
			
            //------------------
            // �����{�^��
            //------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_RATE_REVIVEBTN, ref this._dataTableAllInpCtrl);

            // ����
            if (string.Equals(inpChkStr, "1") == true)
            {
                this.Rate_ReviveBtn.Show();
                this.Rate_ReviveBtn.Enabled = true;
				
                this.Rate_Ok_Btn.Hide();	// �ۑ��{�^����\��
            }
            else
            {
                this.Rate_ReviveBtn.Hide();
                this.Rate_ReviveBtn.Enabled = false;

                this.Rate_Ok_Btn.Show();	// �ۑ��{�^���\��
            }

            //------------------
            // �|���^�u
            //------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_RATE_UTABPAGECONTROL, ref this._dataTableAllInpCtrl);

            // ����
            this.Rate_uTabPageControl.Enabled = string.Equals(inpChkStr, "1");

            //------------------
            // ���b�g�^�u
            //------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_LOT_UTABPAGECONTROL, ref this._dataTableAllInpCtrl);

            // ����
            this.Lot_uTabPageControl.Enabled = string.Equals(inpChkStr, "1");
        }

        /// <summary>
        /// ���͏������䏈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���͏������͈�𐧌䂵�܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.10.11</br>
        /// </remarks>
        private void SettingInpCond()
        {
            string inpUnitPriceKind		= NullChgStr(this.UnitPriceKind_tComboEditor.Value);
            string inpUnitPriceKindWay	= NullChgStr(this.UnitPriceKindWay_tComboEditor.Value);
			
            string inpChkStr = "";
            string rateChkStr = "";

            //---------------------------------------------------
            // �|���ݒ�敪�ŐV���擾�i�V���[�g�J�b�g�L�[�Ή��j
            //---------------------------------------------------
            // �����ݒ�
            ArrayList wkInParamList = new ArrayList();
            wkInParamList.Add(this.RateSectionCode_tEdit.Text);
            wkInParamList.Add(NullChgInt(this.UnitPriceKind_tComboEditor.Value));
            wkInParamList.Add(NullChgInt(this.UnitPriceKindWay_tComboEditor.Value));
            wkInParamList.Add(this.RateSettingDivide_tEdit.Text);
			
            object wkInParamObj = wkInParamList;
            object wkOutParamObj = null;
			
            // ���݃`�F�b�N
            int status = CheckRateSettingDivide(wkInParamList, out wkOutParamObj);
			
            bool canChangeFocus = false;
			
            if(status == 0)
            {
                // �f�[�^�ݒ�
                DispSetRateSettingDivide(DispSetStatus.Update, ref canChangeFocus, wkOutParamObj);
            }

            string inpRateMngGoodsCd	= this.RateMngGoodsCd_tEdit.Text;
            string inpRateMngCustCd		= this.RateMngCustCd_tEdit.Text;

            //--------------
            // ���i�R�[�h
            //--------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_GOODSNO, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_GOODSNO, ref this._dataTableRateGoodsCond).ToString();

            // ����
            if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
            {
                this.GoodsNoCd_tEdit.Enabled = true;
                this.GoodsNoNm_tEdit.Enabled = true;
                this.GoodsNo_uButton.Enabled = true;
            }
            else
            {
                this.GoodsNoCd_tEdit.Enabled = false;
                this.GoodsNoNm_tEdit.Enabled = false;
                this.GoodsNo_uButton.Enabled = false;
				
                this.GoodsNoCd_tEdit.Clear();
                this.GoodsNoNm_tEdit.Clear();
            }

            //--------------------
            // ���i���[�J�[�R�[�h
            //--------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_GOODSMAKERCD, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_GOODSMAKERCD, ref this._dataTableRateGoodsCond).ToString();

            // ����
            if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
            {
                this.GoodsMakerCd_tNedit.Enabled = true;
                this.GoodsMakerCdNm_tEdit.Enabled = true;
                this.GoodsMakerCd_Grp_tNedit.Enabled = true;
                this.GoodsMakerCdNm_Grp_tEdit.Enabled = true;
                this.GoodsMakerCd_uButton.Enabled = true;
                this.GoodsMakerCd_Grp_uButton.Enabled = true;

            }
            else
            {
                this.GoodsMakerCd_tNedit.Enabled = false;
                this.GoodsMakerCdNm_tEdit.Enabled = false;
                this.GoodsMakerCd_Grp_tNedit.Enabled = false;
                this.GoodsMakerCdNm_Grp_tEdit.Enabled = false;
                this.GoodsMakerCd_uButton.Enabled = false;
                this.GoodsMakerCd_Grp_uButton.Enabled = false;

                this.GoodsMakerCd_tNedit.Clear();
                this.GoodsMakerCdNm_tEdit.Clear();
                this.GoodsMakerCd_Grp_tNedit.Clear();
                this.GoodsMakerCdNm_Grp_tEdit.Clear();
            }

            //------------------
            // ���i�|�������N
            //------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_GOODSRATERANK, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_GOODSRATERANK, ref this._dataTableRateGoodsCond).ToString();

            // ����
            if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
            {
                this.GoodsRateRankCd_Grp_tEdit.Enabled = true;
            }
            else
            {
                this.GoodsRateRankCd_Grp_tEdit.Enabled = false;
				
                this.GoodsRateRankCd_Grp_tEdit.Clear();
            }

            //------------------
            // ���i�敪�O���[�v�R�[�h
            //------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_LARGEGOODSGANRECODE, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_LARGEGOODSGANRECODE, ref this._dataTableRateGoodsCond).ToString();

            // ����
            if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
            {
                this.LargeGoodsGanreCode_Grp_tEdit.Enabled = true;
                this.LargeGoodsGanreCodeNm_Grp_tEdit.Enabled = true;
                this.LargeGoodsGanreCode_Grp_uButton.Enabled = true;
            }
            else
            {
                this.LargeGoodsGanreCode_Grp_tEdit.Enabled = false;
                this.LargeGoodsGanreCodeNm_Grp_tEdit.Enabled = false;
                this.LargeGoodsGanreCode_Grp_uButton.Enabled = false;
				
                this.LargeGoodsGanreCode_Grp_tEdit.Clear();
                this.LargeGoodsGanreCodeNm_Grp_tEdit.Clear();
            }

            //------------------
            // ���i�敪�R�[�h
            //------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_MEDIUMGOODSGANRECODE, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_MEDIUMGOODSGANRECODE, ref this._dataTableRateGoodsCond).ToString();

            // ����
            if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
            {
                this.MediumGoodsGanreCode_Grp_tEdit.Enabled = true;
                this.MediumGoodsGanreCodeNm_Grp_tEdit.Enabled = true;
                this.MediumGoodsGanreCode_Grp_uButton.Enabled = true;
            }
            else
            {
                this.MediumGoodsGanreCode_Grp_tEdit.Enabled = false;
                this.MediumGoodsGanreCodeNm_Grp_tEdit.Enabled = false;
                this.MediumGoodsGanreCode_Grp_uButton.Enabled = false;
				
                this.MediumGoodsGanreCode_Grp_tEdit.Clear();
                this.MediumGoodsGanreCodeNm_Grp_tEdit.Clear();
            }

            //--------------------
            // ���i�敪�ڍ׃R�[�h
            //--------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_DETAILGOODSGANRECODE, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_DETAILGOODSGANRECODE, ref this._dataTableRateGoodsCond).ToString();

            // ����
            if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
            {
                this.DetailGoodsGanreCode_Grp_tEdit.Enabled = true;
                this.DetailGoodsGanreCodeNm_Grp_tEdit.Enabled = true;
                this.DetailGoodsGanreCode_Grp_uButton.Enabled = true;
            }
            else
            {
                this.DetailGoodsGanreCode_Grp_tEdit.Enabled = false;
                this.DetailGoodsGanreCodeNm_Grp_tEdit.Enabled = false;
                this.DetailGoodsGanreCode_Grp_uButton.Enabled = false;
				
                this.DetailGoodsGanreCode_Grp_tEdit.Clear();
                this.DetailGoodsGanreCodeNm_Grp_tEdit.Clear();
            }

            //--------------------
            // ���Е��ރR�[�h
            //--------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_ENTERPRISEGANRECODE, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_ENTERPRISEGANRECODE, ref this._dataTableRateGoodsCond).ToString();

            // ����
            if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
            {
                this.EnterpriseGanreCode_Grp_tComboEditor.Enabled = true;
            }
            else
            {
                this.EnterpriseGanreCode_Grp_tComboEditor.Enabled = false;
                this.EnterpriseGanreCode_Grp_tComboEditor.Clear();
            }

            //--------------------
            // �a�k���i�R�[�h
            //--------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_BLGOODSCODE, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_BLGOODSCODE, ref this._dataTableRateGoodsCond).ToString();

            // ����
            if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
            {
                this.BLGoodsCode_Grp_tNedit.Enabled = true;
                this.BLGoodsCodeNm_Grp_tEdit.Enabled = true;
                this.BLGoodsCode_Grp_uButton.Enabled = true;
            }
            else
            {
                this.BLGoodsCode_Grp_tNedit.Enabled = false;
                this.BLGoodsCodeNm_Grp_tEdit.Enabled = false;
                this.BLGoodsCode_Grp_uButton.Enabled = false;
				
                this.BLGoodsCode_Grp_tNedit.Clear();
                this.BLGoodsCodeNm_Grp_tEdit.Clear();
            }

            //--------------------
            // ���Ӑ�R�[�h
            //--------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_CUSTOMERCODE, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngCustCd, COND_CUSTOMERCODE, ref this._dataTableRateCustCond).ToString();

            // ����
            if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
            {
                this.CustomerCode_tNedit.Enabled = true;
                this.CustomerCodeNm_tEdit.Enabled = true;
                this.CustomerCode_uButton.Enabled = true;
            }
            else
            {
                this.CustomerCode_tNedit.Enabled = false;
                this.CustomerCodeNm_tEdit.Enabled = false;
                this.CustomerCode_uButton.Enabled = false;
				
                this.CustomerCode_tNedit.Clear();
                this.CustomerCodeNm_tEdit.Clear();
            }

            //--------------------
            // ���Ӑ�|���R�[�h
            //--------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_CUSTRATEGRPCODE, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngCustCd, COND_CUSTRATEGRPCODE, ref this._dataTableRateCustCond).ToString();

            // ����
            if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
            {
                this.CustRateGrpCode_tComboEditor.Enabled = true;
            }
            else
            {
                this.CustRateGrpCode_tComboEditor.Enabled = false;
                this.CustRateGrpCode_tComboEditor.Clear();
            }

            //--------------------
            // �d����R�[�h
            //--------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_SUPPLIERCD, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngCustCd, COND_SUPPLIERCD, ref this._dataTableRateCustCond).ToString();

            // ����
            if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
            {
                this.SupplierCd_tNedit.Enabled = true;
                this.SupplierCdNm_tEdit.Enabled = true;
                this.SupplierCd_uButton.Enabled = true;
            }
            else
            {
                this.SupplierCd_tNedit.Enabled = false;
                this.SupplierCdNm_tEdit.Enabled = false;
                this.SupplierCd_uButton.Enabled = false;
				
                this.SupplierCd_tNedit.Clear();
                this.SupplierCdNm_tEdit.Clear();
            }

            //--------------------
            // �d����|���R�[�h
            //--------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_SUPPRATEGRPCODE, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngCustCd, COND_SUPPRATEGRPCODE, ref this._dataTableRateCustCond).ToString();

            // ����
            if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
            {
                this.SuppRateGrpCode_tComboEditor.Enabled = true;
            }
            else
            {
                this.SuppRateGrpCode_tComboEditor.Enabled = false;
                this.SuppRateGrpCode_tComboEditor.Clear();
            }
        }

        /// <summary>
        /// �|�����͐��䏈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|�����͈�𐧌䂵�܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.10.11</br>
        /// </remarks>
        private void SettingRateInpCond()
        {
            string inpUnitPriceKind		= NullChgStr(this.UnitPriceKind_tComboEditor.Value);
            string inpUnitPriceKindWay	= NullChgStr(this.UnitPriceKindWay_tComboEditor.Value);

            //---------------------------------------------------
            // �|���ݒ�敪�ŐV���擾�i�V���[�g�J�b�g�L�[�Ή��j
            //---------------------------------------------------
            // �����ݒ�
            ArrayList wkInParamList = new ArrayList();
            wkInParamList.Add(this.RateSectionCode_tEdit.Text);
            wkInParamList.Add(NullChgInt(this.UnitPriceKind_tComboEditor.Value));
            wkInParamList.Add(NullChgInt(this.UnitPriceKindWay_tComboEditor.Value));
            wkInParamList.Add(this.RateSettingDivide_tEdit.Text);

            object wkInParamObj = wkInParamList;
            object wkOutParamObj = null;

            // ���݃`�F�b�N
            int status = CheckRateSettingDivide(wkInParamList, out wkOutParamObj);

            bool canChangeFocus = false;

            if (status == 0)
            {
                // �f�[�^�ݒ�
                DispSetRateSettingDivide(DispSetStatus.Update, ref canChangeFocus, wkOutParamObj);
            }
            string inpRateMngGoodsCd = this.RateMngGoodsCd_tEdit.Text;
            string inpRateMngCustCd = this.RateMngCustCd_tEdit.Text;


            string inpChkStr = "";
            string rateChkStr = "";
			
            //------------------
            // �|���J�n��
            //------------------
            // ��ɓ��͉�
            this.NewRateStartDate_tDateEdit.Enabled = true;
            this.OldRateStartDate_tDateEdit.Enabled = true;
			
            //--------------------
            // ���i
            //--------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_PRICE, ref this._dataTableRateInpCond).ToString();
            rateChkStr = "";

            // ����
            if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == false)
            {
                this.NewPrice_tNedit.Enabled = true;
                this.OldPrice_tNedit.Enabled = true;
            }
            else
            {
                this.NewPrice_tNedit.Enabled = false;
                this.OldPrice_tNedit.Enabled = false;
            }

            //------------------
            // ����i�敪
            //------------------
            // ��ɓ��͉�
            this.NewPriceDiv_tComboEditor.Enabled = true;
            this.OldPriceDiv_tComboEditor.Enabled = true;
			
            //--------------------
            // �P���Z�o�敪
            //--------------------
            // �����f�[�^�e�[�u����茟�����ʎ擾
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_UNPRCCALCDIV, ref this._dataTableRateInpCond).ToString();
            rateChkStr = "";
			
            // �t�B���^�[�N���A
            this._dataTableUnPrcCalcDivNew.DefaultView.RowFilter = "";
            this._dataTableUnPrcCalcDivOld.DefaultView.RowFilter = "";
			
            // ����
            if (string.Equals(CheckCond(inpChkStr, rateChkStr), "0") == true)
            {
                this.NewUnPrcCalcDiv_tComboEditor.Enabled = false;
                this.OldUnPrcCalcDiv_tComboEditor.Enabled = false;
            }
            else if (string.Equals(CheckCond(inpChkStr, rateChkStr), "1") == true)
            {
                this.NewUnPrcCalcDiv_tComboEditor.Enabled = true;
                this.OldUnPrcCalcDiv_tComboEditor.Enabled = true;
            }
            else if (string.Equals(CheckCond(inpChkStr, rateChkStr), "11") == true)
            {
                this.NewUnPrcCalcDiv_tComboEditor.Enabled = true;
                this.OldUnPrcCalcDiv_tComboEditor.Enabled = true;

                // 1:����i�~�|���̂�
                string wkStr = "";
                _stringBuilder.Remove(0, _stringBuilder.Length);
                _stringBuilder.Append(COMBO_CODE);
                _stringBuilder.Append(" = '1'");
                wkStr = _stringBuilder.ToString();

                this._dataTableUnPrcCalcDivNew.DefaultView.RowFilter = wkStr;
                this._dataTableUnPrcCalcDivOld.DefaultView.RowFilter = wkStr;
            }

            //--------------------
            // �|��
            //--------------------
            // ��ɓ��͉�
            this.NewRate_tNedit.Enabled = true;
            this.OldRate_tNedit.Enabled = true;

            //--------------------
            // �P���[�������P��
            //--------------------
            // ��ɓ��͉�
            this.NewUnPrcFracProcUnit_tNedit.Enabled = true;
            this.OldUnPrcFracProcUnit_tNedit.Enabled = true;
			
            //--------------------
            // �P���[�������敪
            //--------------------
            // ��ɓ��͉�
            this.NewUnPrcFracProcDiv_tComboEditor.Enabled = true;
            this.OldUnPrcFracProcDiv_tComboEditor.Enabled = true;
			
            //--------------------
            // �����敪
            //--------------------
            // ��ɓ��͉�
            this.NewBargainCd_tComboEditor.Enabled = true;
            this.OldBargainCd_tComboEditor.Enabled = true;

            //----------------------
            // �|���V���R�s�[�{�^��
            //----------------------
            this.CopyToOldFromNewbtn.Enabled = true;
        }
		
        /// <summary>
        /// �����`�F�b�N����
        /// </summary>
        /// <param name="inpChkStr">���̓`�F�b�N������</param>
        /// <param name="rateChkStr">�|���`�F�b�N������</param>
        /// <returns>���ʕ�����</returns>
        /// <remarks>
        /// <br>Note       : �������`�F�b�N���܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.10.09</br>
        /// </remarks>
        private string CheckCond(string inpChkStr, string rateChkStr)
        {
            string retStr = "0";
			
            // ���͐���`�F�b�N
            if (string.Equals(inpChkStr, "0") == false)
            {
                // �|���`�F�b�N
                if (string.Equals(rateChkStr, "") == true)
                {
                    // ���ݒ�̏ꍇ�̓`�F�b�N���Ȃ�
                    retStr = inpChkStr;
                }
                else
                {
                    if (string.Equals(rateChkStr, "0") == false)
                    {
                        retStr = rateChkStr;
                    }
                }
            }
            return retStr;
        }

        /// <summary>
        /// �|���ݒ�������̓G���[�`�F�b�N����
        /// </summary>
        /// <returns>����(true:����, false:�G���[)</returns>
        /// <remarks>
        /// <br>Note       : �|���ݒ�������̓f�[�^�̃G���[�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.26</br>
        /// </remarks>
        private bool InpRateCondCheck()
        {
            bool retBool = false;
            string errMsg = null;
			
            // ���_�R�[�h�A�|���ݒ�敪�����͂���Ă���ꍇ
            if (InpRateSettingDataCheck(out errMsg) == 0)
            {
                // ���͏�������
                SettingInpCond();

                // �S�̓��̓R���g���[��
                SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.InputCondition.GetHashCode());
                this._AllCtrlInputStatus = AllCtrlInputStatus.InputCondition;

                // ���[�h���x��
                this._modeFlag = ModeFlag.None;	// ���m��
				
                retBool = true;
            }
            else
            {
                // �S�̓��̓R���g���[��
                SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.New.GetHashCode());
                this._AllCtrlInputStatus = AllCtrlInputStatus.New;
			
                retBool = false;
            }
            return retBool;
        }

        /// <summary>
        /// �|���������̓f�[�^�G���[�`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N����(0:NG, 1:OK)</returns>
        /// <remarks>
        /// <br>Note       : �|���������̓f�[�^�̃G���[�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private int InpRateSettingDataCheck(out string errMsg)
        {
            int ret = 0;
			
            errMsg = "";	// �G���[���b�Z�[�W
			
            _stringBuilder.Remove(0, _stringBuilder.Length);
            _stringBuilder.Append("�ȉ����ڂ͕K�{���͂ł��B\n");
			
            //------------
            // ���_�R�[�h
            //------------
            if ((this.RateSectionCode_tEdit.Enabled == true)&&(this.RateSectionCode_tEdit.Text == ""))
            {
                // ���̃N���A
                this.SectionCodeNm_tEdit.Clear();

                // ���݃f�[�^�N���A
                this._searchRate.SectionCode = "";

                _stringBuilder.Append("���_�R�[�h\n");
                ret = 1;
            }
			
            //--------------
            // �|���ݒ�敪
            //--------------
            if ((this.RateSettingDivide_tEdit.Enabled == true)&&(this.RateSettingDivide_tEdit.Text == ""))
            {
                // ���̃N���A
                this.RateMngCustCd_tEdit.Clear();
                this.RateMngCustNm_tEdit.Clear();
                this.RateMngGoodsCd_tEdit.Clear();
                this.RateMngGoodsNm_tEdit.Clear();

                // ���݃f�[�^�N���A
                this._searchRate.RateSettingDivide = "";
                this._searchRate.RateMngCustCd = "";
                this._searchRate.RateMngCustNm = "";
                this._searchRate.RateMngGoodsCd = "";
                this._searchRate.RateMngGoodsNm = "";

                _stringBuilder.Append("�|���ݒ�敪\n");
                ret = 1;
            }

            // �G���[���b�Z�[�W�o��
            if (ret == 1)
            {
                errMsg = _stringBuilder.ToString();
            }
            return ret;
        }
		
        /// <summary>
        /// ���̓f�[�^�G���[�`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N����(0:NG, 1:OK)</returns>
        /// <remarks>
        /// <br>Note       : ���̓f�[�^�̃G���[�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private int InpDataCheck()
        {
            int ret = 0;
			
            string errMsg = "";	// �G���[���b�Z�[�W
			
            _stringBuilder.Remove(0, _stringBuilder.Length);
            _stringBuilder.Append("�ȉ����ڂ͕K�{���͂ł��B\n");
			
            // �������������̓`�F�b�N
			
            //--------------------
            // ���i���[�J�[�R�[�h
            //--------------------
            if (this.UnitPriceKindWay_tComboEditor.SelectedIndex == 0)
            {
                // �P�i
                if ((this.GoodsMakerCd_tNedit.Enabled == true)&&(this.GoodsMakerCd_tNedit.Text == ""))
                {
                    // ���̃N���A
                    this.GoodsMakerCdNm_tEdit.Clear();

                    // ���݃f�[�^�N���A
                    this._searchRate.GoodsMakerCd = 0;
					
                    _stringBuilder.Append("���i���[�J�[�R�[�h\n");
                    ret = 1;
                }
            }
            else
            {
                // �O���[�v
                if ((this.GoodsMakerCd_Grp_tNedit.Enabled == true)&&(this.GoodsMakerCd_Grp_tNedit.Text == ""))
                {
                    // ���̃N���A
                    this.GoodsMakerCdNm_Grp_tEdit.Clear();

                    // ���݃f�[�^�N���A
                    this._searchRate.GoodsMakerCd = 0;
					
                    _stringBuilder.Append("���i���[�J�[�R�[�h\n");
                    ret = 1;
                }
            }

            //--------------
            // ���i�R�[�h
            //--------------
            if ((this.GoodsNoCd_tEdit.Enabled == true) && (this.GoodsNoCd_tEdit.Text == ""))
            {
                // ���̃N���A
                this.GoodsNoNm_tEdit.Clear();

                // ���݃f�[�^�N���A
                this._searchRate.GoodsNo = "";
				
                _stringBuilder.Append("���i�R�[�h\n");
                ret = 1;
            }
			
            //------------------
            // ���i�|�������N
            //------------------
            if ((this.GoodsRateRankCd_Grp_tEdit.Enabled == true)&&(this.GoodsRateRankCd_Grp_tEdit.Text == ""))
            {
                _stringBuilder.Append("���i�|�������N\n");
                ret = 1;
            }
			
            //------------------------
            // ���i�敪�O���[�v�R�[�h
            //------------------------
            if ((this.LargeGoodsGanreCode_Grp_tEdit.Enabled == true)&&(this.LargeGoodsGanreCode_Grp_tEdit.Text == ""))
            {
                // ���̃N���A
                this.LargeGoodsGanreCodeNm_Grp_tEdit.Clear();

                // ���݃f�[�^�N���A
                this._searchRate.LargeGoodsGanreCode = "";

                _stringBuilder.Append("���i�敪�O���[�v�R�[�h\n");
                ret = 1;
            }

            //------------------
            // ���i�敪�R�[�h
            //------------------
            if ((this.MediumGoodsGanreCode_Grp_tEdit.Enabled == true)&&(this.MediumGoodsGanreCode_Grp_tEdit.Text == ""))
            {
                // ���̃N���A
                this.MediumGoodsGanreCodeNm_Grp_tEdit.Clear();

                // ���݃f�[�^�N���A
                this._searchRate.MediumGoodsGanreCode = "";

                _stringBuilder.Append("���i�敪\n");
                ret = 1;
            }

            //--------------------
            // ���i�敪�ڍ׃R�[�h
            //--------------------
            if ((this.DetailGoodsGanreCode_Grp_tEdit.Enabled == true)&&(this.DetailGoodsGanreCode_Grp_tEdit.Text == ""))
            {
                // ���̃N���A
                this.DetailGoodsGanreCodeNm_Grp_tEdit.Clear();

                // ���݃f�[�^�N���A
                this._searchRate.DetailGoodsGanreCode = "";

                _stringBuilder.Append("���i�敪�ڍ�\n");
                ret = 1;
            }

            //--------------------
            // ���Е��ރR�[�h
            //--------------------
            // ��ʏ�Ɂu0�v��\�������Ȃ����ߔ��p�󔒂�ݒ肵�Ă���̂ŋ󔒍폜����
            if ((this.EnterpriseGanreCode_Grp_tComboEditor.Enabled == true)
                &&(this.EnterpriseGanreCode_Grp_tComboEditor.Text.Trim() == ""))
            {
                _stringBuilder.Append("���Е��ރR�[�h\n");
                ret = 1;
            }

            //--------------------
            // �a�k���i�R�[�h
            //--------------------
            if ((this.BLGoodsCode_Grp_tNedit.Enabled == true)&&(this.BLGoodsCode_Grp_tNedit.Text == ""))
            {
                // ���̃N���A
                this.BLGoodsCodeNm_Grp_tEdit.Clear();

                // ���݃f�[�^�N���A
                this._searchRate.BLGoodsCode = 0;
				
                _stringBuilder.Append("�a�k���i�R�[�h\n");
                ret = 1;
            }

            //--------------------
            // ���Ӑ�R�[�h
            //--------------------
            if ((this.CustomerCode_tNedit.Enabled == true)&&(this.CustomerCode_tNedit.Text == ""))
            {
                // ���̃N���A
                this.CustomerCodeNm_tEdit.Clear();
				
                // ���݃f�[�^�N���A
                this._searchRate.CustomerCode = 0;
				
                _stringBuilder.Append("���Ӑ�R�[�h\n");
                ret = 1;
            }

            //--------------------
            // ���Ӑ�|���R�[�h
            //--------------------
            // ��ʏ�Ɂu0�v��\�������Ȃ����ߔ��p�󔒂�ݒ肵�Ă���̂ŁA�󔒍폜����
            if ((this.CustRateGrpCode_tComboEditor.Enabled == true)
                &&(this.CustRateGrpCode_tComboEditor.Text.Trim() == ""))
            {
                _stringBuilder.Append("���Ӑ�|���O���[�v�R�[�h\n");
                ret = 1;
            }

            //--------------------
            // �d����R�[�h
            //--------------------
            if ((this.SupplierCd_tNedit.Enabled == true)&&(this.SupplierCd_tNedit.Text == ""))
            {
                // ���̃N���A
                this.SupplierCdNm_tEdit.Clear();

                // ���݃f�[�^�N���A
                this._searchRate.SupplierCd = 0;

                _stringBuilder.Append("�d����R�[�h\n");
                ret = 1;
            }

            //--------------------
            // �d����|���R�[�h
            //--------------------
            // ��ʏ�Ɂu0�v��\�������Ȃ����ߔ��p�󔒂�ݒ肵�Ă���̂ŋ󔒍폜����
            if ((this.SuppRateGrpCode_tComboEditor.Enabled == true)
                &&(this.SuppRateGrpCode_tComboEditor.Text.Trim() == ""))
            {
                _stringBuilder.Append("�d����|���O���[�v�R�[�h\n");
                ret = 1;
            }
			
            // �G���[���b�Z�[�W�o��
            if(ret == 1)
            {
                errMsg = _stringBuilder.ToString();
                ShowInpErrMsg(errMsg);
            }
            return ret;
        }

        /// <summary>
        /// �������ڃ`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N����(true:OK, false:NG)</returns>
        /// <remarks>
        /// <br>Note       : �������ڂɑ΂��ĉߕs�����������`�F�b�N���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        private bool InpCondDataCheck()
        {
            object inParamObj = null;
            object outParamObj = null;
            ArrayList inParamList = null;

            bool canChangeFocus = false;
            DispSetStatus dispSetStatus = DispSetStatus.Clear;
            int status = (int)InputChkStatus.NotExist;
			
            //------------
            // ���_�R�[�h
            //------------
            if (this.RateSectionCode_tEdit.Enabled == true)
            {
                // �����ݒ�N���A
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p
                status = (int)InputChkStatus.NotExist;

                //----- ueno add ---------- start 2008.03.31
                // ���_�R�[�h�[������
                if (this.RateSectionCode_tEdit.Text != "")
                {
                    this.RateSectionCode_tEdit.Text = GetZeroPaddedTextProc(this.RateSectionCode_tEdit.Text, this.RateSectionCode_tEdit.ExtEdit.Column);

                    // ���[�N�f�[�^���[�����߂���
                    this._searchRate.SectionCode = GetZeroPaddedTextProc(this._searchRate.SectionCode, this.RateSectionCode_tEdit.ExtEdit.Column);
                }
                //----- ueno add ---------- end 2008.03.31

                // �����ݒ�
                inParamObj = this.RateSectionCode_tEdit.Text;

                // ���݃`�F�b�N
                status = CheckSectionCode(inParamObj, out outParamObj);
                switch(status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // �l�ύX�`�F�b�N
                            if (this.RateSectionCode_tEdit.Text != this._searchRate.SectionCode)
                            {
                                dispSetStatus = editChgDataChk("���_�R�[�h", this.RateSectionCode_tEdit.Text, this._searchRate.SectionCode);

                                // �f�[�^�ݒ�
                                DispSetSectionCode(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("���_�R�[�h");
                            dispSetStatus = this._searchRate.SectionCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;

                            // �f�[�^�ݒ�
                            DispSetSectionCode(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }

                //--------------------------------
                // ���_�R�[�h�֘A���ڃN���A����
                //--------------------------------
                // ��ʃf�[�^�A���[�N�f�[�^�Ƃ��ɖ����͎��͑S�č폜����
                if ((this.RateSectionCode_tEdit.Text == "") && (this._searchRate.SectionCode == ""))
                {
                    SectionCodeVisibleChange();
                }
				
                // �l���ύX�����ꍇ�A�܂��́A���݃`�F�b�N���G���[�̏ꍇ�͈ȉ��̏����ɐi�܂Ȃ�
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //--------------
            // �|���ݒ�敪
            //--------------
            if (this.RateSettingDivide_tEdit.Enabled == true)
            {
                // �����ݒ�N���A
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p
                status = (int)InputChkStatus.NotExist;

                // �����ݒ�
                inParamList.Add(this.RateSectionCode_tEdit.Text);
                inParamList.Add(NullChgInt(this.UnitPriceKind_tComboEditor.Value));
                inParamList.Add(NullChgInt(this.UnitPriceKindWay_tComboEditor.Value));
                inParamList.Add(this.RateSettingDivide_tEdit.Text);
                inParamObj = inParamList;

                // ���݃`�F�b�N
                status = CheckRateSettingDivide(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // �l�ύX�`�F�b�N
                            if (this.RateSettingDivide_tEdit.Text != this._searchRate.RateSettingDivide)
                            {
                                dispSetStatus = editChgDataChk("�|���ݒ�敪", this.RateSettingDivide_tEdit.Text, this._searchRate.RateSettingDivide);

                                // �f�[�^�ݒ�
                                DispSetRateSettingDivide(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("�|���ݒ�敪");
                            dispSetStatus = this._searchRate.RateSettingDivide == "" ? DispSetStatus.Clear : DispSetStatus.Back;

                            // �f�[�^�ݒ�
                            DispSetRateSettingDivide(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }

                //--------------------------------
                // �|���ݒ�敪�֘A���ڃN���A����
                //--------------------------------
                // ��ʃf�[�^�A���[�N�f�[�^�Ƃ��ɖ����͎��͑S�č폜����
                if ((this.RateSettingDivide_tEdit.Text == "") && (this._searchRate.RateSettingDivide == ""))
                {
                    RateSettingDivideVisibleChange();
                }

                // �l���ύX�����ꍇ�A�܂��́A���݃`�F�b�N���G���[�̏ꍇ�͈ȉ��̏����ɐi�܂Ȃ�
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //----------------
            // ���[�J�[�R�[�h
            //----------------
            // �P�i�ݒ莞
            if (this.UnitPriceKindWay_tComboEditor.SelectedIndex == 0)
            {
                if (this.GoodsMakerCd_tNedit.Enabled == true)
                {
                    // �����ݒ�N���A
                    inParamObj = null;
                    outParamObj = null;
                    inParamList = new ArrayList();
                    dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p
                    status = (int)InputChkStatus.NotExist;

                    // �����ݒ�
                    inParamObj = this.GoodsMakerCd_tNedit.GetInt();

                    // ���݃`�F�b�N
                    status = CheckGoodsMakerCd(inParamObj, out outParamObj); 
                    switch (status)
                    {
                        case (int)InputChkStatus.Normal:
                        case (int)InputChkStatus.NotInput:
                            {
                                // �l�ύX�`�F�b�N
                                if (this.GoodsMakerCd_tNedit.GetInt() != this._searchRate.GoodsMakerCd)
                                {
                                    dispSetStatus = editChgDataChk("���[�J�[�R�[�h�i�P�i�j", this.GoodsMakerCd_tNedit.GetInt(), this._searchRate.GoodsMakerCd);

                                    // �f�[�^�ݒ�
                                    DispSetGoodsMakerCd(dispSetStatus, ref canChangeFocus, outParamObj);
                                }
                                break;
                            }
                        default:
                            {
                                ShowNotFoundErrMsg("���[�J�[�R�[�h�i�P�i�j");
                                dispSetStatus = this._searchRate.GoodsMakerCd == 0 ? DispSetStatus.Clear : DispSetStatus.Back;

                                // �f�[�^�ݒ�
                                DispSetGoodsMakerCd(dispSetStatus, ref canChangeFocus, outParamObj);
                                break;
                            }
                    }
					
                    // �l���ύX�����ꍇ�A�܂��́A���݃`�F�b�N���G���[�̏ꍇ�͈ȉ��̏����ɐi�܂Ȃ�
                    if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                    {
                        return false;
                    }
                }
            }
            // �O���[�v�ݒ莞
            else
            {
                if (this.GoodsMakerCd_Grp_tNedit.Enabled == true)
                {
                    // �����ݒ�N���A
                    inParamObj = null;
                    outParamObj = null;
                    inParamList = new ArrayList();
                    dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p
                    status = (int)InputChkStatus.NotExist;

                    // �����ݒ�
                    inParamObj = this.GoodsMakerCd_Grp_tNedit.GetInt();

                    // ���݃`�F�b�N
                    status = CheckGoodsMakerCd(inParamObj, out outParamObj); 
                    switch (status)
                    {
                        case (int)InputChkStatus.Normal:
                        case (int)InputChkStatus.NotInput:
                            {
                                // �l�ύX�`�F�b�N
                                if (this.GoodsMakerCd_Grp_tNedit.GetInt() != this._searchRate.GoodsMakerCd)
                                {
                                    dispSetStatus = editChgDataChk("���[�J�[�R�[�h", this.GoodsMakerCd_Grp_tNedit.GetInt(), this._searchRate.GoodsMakerCd);

                                    // �f�[�^�ݒ�
                                    DispSetGoodsMakerCdGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                                }
                                break;
                            }
                        default:
                            {
                                ShowNotFoundErrMsg("���[�J�[�R�[�h");
                                dispSetStatus = this._searchRate.GoodsMakerCd == 0 ? DispSetStatus.Clear : DispSetStatus.Back;

                                // �f�[�^�ݒ�
                                DispSetGoodsMakerCdGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                                break;
                            }
                    }

                    // �l���ύX�����ꍇ�A�܂��́A���݃`�F�b�N���G���[�̏ꍇ�͈ȉ��̏����ɐi�܂Ȃ�
                    if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                    {
                        return false;
                    }
                }
            }

            //----------------
            // ���i�|�������N
            //----------------
            if (this.GoodsRateRankCd_Grp_tEdit.Enabled == true)
            {
                status = (int)InputChkStatus.Normal;

                // �l�ύX�`�F�b�N
                if (this.GoodsRateRankCd_Grp_tEdit.Text != this._searchRate.GoodsRateRank)
                {
                    dispSetStatus = editChgDataChk("���i�|�������N", this.GoodsRateRankCd_Grp_tEdit.Text, this._searchRate.GoodsRateRank);
                }
				
                outParamObj = this.GoodsRateRankCd_Grp_tEdit.Text;
				
                // �f�[�^�ݒ�
                DispSetGoodsRateRankCd(dispSetStatus, ref canChangeFocus, outParamObj);

                // �l���ύX�����ꍇ�A�܂��́A���݃`�F�b�N���G���[�̏ꍇ�͈ȉ��̏����ɐi�܂Ȃ�
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //------------
            // ���i�R�[�h
            //------------
            if (this.GoodsNoCd_tEdit.Enabled == true)
            {
                // �����ݒ�N���A
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p
                status = (int)InputChkStatus.NotExist;

                // �����ݒ�
                inParamList.Add(this.GoodsMakerCd_tNedit.GetInt());
                inParamList.Add(this.GoodsNoCd_tEdit.Text);
                inParamObj = inParamList;

                // ���݃`�F�b�N�i�B�������j
                status = CheckGoodsNoCdDirect(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // �l�ύX�`�F�b�N
                            if (this.GoodsNoCd_tEdit.Text != this._searchRate.GoodsNo)
                            {
                                dispSetStatus = editChgDataChk("���i�R�[�h", this.GoodsNoCd_tEdit.Text, this._searchRate.GoodsNo);

                                // �f�[�^�ݒ�
                                DispSetGoodsNoCd(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("���i�R�[�h");
                            dispSetStatus = this._searchRate.GoodsNo == "" ? DispSetStatus.Clear : DispSetStatus.Back;

                            // �f�[�^�ݒ�
                            DispSetGoodsNoCd(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }

                // �l���ύX�����ꍇ�A�܂��́A���݃`�F�b�N���G���[�̏ꍇ�͈ȉ��̏����ɐi�܂Ȃ�
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //------------------------
            // ���i�敪�O���[�v�R�[�h
            //------------------------
            if (this.LargeGoodsGanreCode_Grp_tEdit.Enabled == true)
            {
                // �����ݒ�N���A
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p
                status = (int)InputChkStatus.NotExist;

                // �����ݒ�
                inParamObj = this.LargeGoodsGanreCode_Grp_tEdit.Text;

                // ���݃`�F�b�N
                status = CheckLargeGoodsGanreCodeGrp(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // �l�ύX�`�F�b�N
                            if (this.LargeGoodsGanreCode_Grp_tEdit.Text != this._searchRate.LargeGoodsGanreCode)
                            {
                                dispSetStatus = editChgDataChk("���i�敪�O���[�v�R�[�h", this.LargeGoodsGanreCode_Grp_tEdit.Text, this._searchRate.LargeGoodsGanreCode);

                                // �f�[�^�ݒ�
                                DispSetLargeGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("���i�敪�O���[�v�R�[�h");
                            dispSetStatus = this._searchRate.LargeGoodsGanreCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;

                            // �f�[�^�ݒ�
                            DispSetLargeGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }
                // �l���ύX�����ꍇ�A�܂��́A���݃`�F�b�N���G���[�̏ꍇ�͈ȉ��̏����ɐi�܂Ȃ�
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //----------------
            // ���i�敪�R�[�h
            //----------------
            if (this.MediumGoodsGanreCode_Grp_tEdit.Enabled == true)
            {
                // �����ݒ�N���A
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p

                // �����ݒ�
                inParamList.Add(this.LargeGoodsGanreCode_Grp_tEdit.Text);
                inParamList.Add(this.MediumGoodsGanreCode_Grp_tEdit.Text);
                inParamObj = inParamList;
                status = (int)InputChkStatus.NotExist;

                // ���݃`�F�b�N
                status = CheckMediumGoodsGanreCodeGrp(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // �l�ύX�`�F�b�N
                            if (this.MediumGoodsGanreCode_Grp_tEdit.Text != this._searchRate.MediumGoodsGanreCode)
                            {
                                dispSetStatus = editChgDataChk("���i�敪�R�[�h", this.MediumGoodsGanreCode_Grp_tEdit.Text, this._searchRate.MediumGoodsGanreCode);

                                // �f�[�^�ݒ�
                                DispSetMediumGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("���i�敪�R�[�h");
                            dispSetStatus = this._searchRate.MediumGoodsGanreCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;

                            // �f�[�^�ݒ�
                            DispSetMediumGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;

                        }
                }
                // �l���ύX�����ꍇ�A�܂��́A���݃`�F�b�N���G���[�̏ꍇ�͈ȉ��̏����ɐi�܂Ȃ�
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //--------------------
            // ���i�敪�ڍ׃R�[�h
            //--------------------
            if (this.DetailGoodsGanreCode_Grp_tEdit.Enabled == true)
            {
                // �����ݒ�N���A
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p
                status = (int)InputChkStatus.NotExist;

                // �����ݒ�
                inParamList.Add(this.LargeGoodsGanreCode_Grp_tEdit.Text);
                inParamList.Add(this.MediumGoodsGanreCode_Grp_tEdit.Text);
                inParamList.Add(this.DetailGoodsGanreCode_Grp_tEdit.Text);
                inParamObj = inParamList;

                // ���݃`�F�b�N
                status = CheckDetailGoodsGanreCodeGrp(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // �l�ύX�`�F�b�N
                            if (this.DetailGoodsGanreCode_Grp_tEdit.Text != this._searchRate.DetailGoodsGanreCode)
                            {
                                dispSetStatus = editChgDataChk("���i�敪�ڍ׃R�[�h", this.DetailGoodsGanreCode_Grp_tEdit.Text, this._searchRate.DetailGoodsGanreCode);

                                // �f�[�^�ݒ�
                                DispSetDetailGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("���i�敪�ڍ׃R�[�h");
                            dispSetStatus = this._searchRate.DetailGoodsGanreCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;

                            // �f�[�^�ݒ�
                            DispSetDetailGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }
                // �l���ύX�����ꍇ�A�܂��́A���݃`�F�b�N���G���[�̏ꍇ�͈ȉ��̏����ɐi�܂Ȃ�
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //----------------
            // ���Е��ރR�[�h
            //----------------
            if ((this.EnterpriseGanreCode_Grp_tComboEditor.Enabled == true) && (this.EnterpriseGanreCode_Grp_tComboEditor.Value != null))
            {
                // �����ݒ�N���A
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p
                status = (int)InputChkStatus.NotExist;

                // �����ݒ�
                inParamList.Add(this._enterpriseGanreCodeSList);
                inParamList.Add((int)this.EnterpriseGanreCode_Grp_tComboEditor.Value);
                inParamObj = inParamList;

                // ���݃`�F�b�N
                status = CheckUserGuide(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // �l�ύX�`�F�b�N
                            if ((int)this.EnterpriseGanreCode_Grp_tComboEditor.Value != this._searchRate.EnterpriseGanreCode)
                            {
                                dispSetStatus = editChgDataChk("���Е��ރR�[�h", this.EnterpriseGanreCode_Grp_tComboEditor.Value.ToString(), this._searchRate.EnterpriseGanreCode);

                                // �f�[�^�ݒ�
                                DispSetEnterpriseGanreCode(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("���Е��ރR�[�h");
                            dispSetStatus = this._searchRate.EnterpriseGanreCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;

                            // �f�[�^�ݒ�
                            DispSetEnterpriseGanreCode(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }
                // �l���ύX�����ꍇ�A�܂��́A���݃`�F�b�N���G���[�̏ꍇ�͈ȉ��̏����ɐi�܂Ȃ�
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //----------------
            // �a�k���i�R�[�h
            //----------------
            if (this.BLGoodsCode_Grp_tNedit.Enabled == true)
            {
                // �����ݒ�N���A
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p
                status = (int)InputChkStatus.NotExist;

                // �����ݒ�
                inParamObj = this.BLGoodsCode_Grp_tNedit.GetInt();

                // ���݃`�F�b�N
                status = CheckBLGoodsCodeGrp(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // �l�ύX�`�F�b�N
                            if (this.BLGoodsCode_Grp_tNedit.GetInt() != this._searchRate.BLGoodsCode)
                            {
                                dispSetStatus = editChgDataChk("�a�k���i�R�[�h", this.BLGoodsCode_Grp_tNedit.GetInt(), this._searchRate.BLGoodsCode);

                                // �f�[�^�ݒ�
                                DispSetBLGoodsCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("�a�k���i�R�[�h");
                            dispSetStatus = this._searchRate.BLGoodsCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;

                            // �f�[�^�ݒ�
                            DispSetBLGoodsCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }
                // �l���ύX�����ꍇ�A�܂��́A���݃`�F�b�N���G���[�̏ꍇ�͈ȉ��̏����ɐi�܂Ȃ�
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //----------------
            // ���Ӑ�R�[�h
            //----------------
            if (this.CustomerCode_tNedit.Enabled == true)
            {
                // �����ݒ�N���A
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p
                status = (int)InputChkStatus.NotExist;

                // �����ݒ�
                inParamObj = this.CustomerCode_tNedit.GetInt();

                // ���݃`�F�b�N
                status = CheckCustomerCode(inParamObj, out outParamObj);
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // �l�ύX�`�F�b�N
                            if (this.CustomerCode_tNedit.GetInt() != this._searchRate.CustomerCode)
                            {
                                dispSetStatus = editChgDataChk("���Ӑ�R�[�h", this.CustomerCode_tNedit.GetInt(), this._searchRate.CustomerCode);

                                // �f�[�^�ݒ�
                                DispSetCustomerCode(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("���Ӑ�R�[�h");
                            dispSetStatus = this._searchRate.CustomerCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;

                            // �f�[�^�ݒ�
                            DispSetCustomerCode(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }
                // �l���ύX�����ꍇ�A�܂��́A���݃`�F�b�N���G���[�̏ꍇ�͈ȉ��̏����ɐi�܂Ȃ�
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //--------------------
            // ���Ӑ�|���O���[�v
            //--------------------
            if ((this.CustRateGrpCode_tComboEditor.Enabled == true) && (this.CustRateGrpCode_tComboEditor.Value != null))
            {
                // �����ݒ�N���A
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p
                status = (int)InputChkStatus.NotExist;

                // �����ݒ�
                inParamList.Add(this._custRateGrpCodeSList);
                inParamList.Add((int)this.CustRateGrpCode_tComboEditor.Value);
                inParamObj = inParamList;

                // ���݃`�F�b�N
                status = CheckUserGuide(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // �l�ύX�`�F�b�N
                            if ((int)this.CustRateGrpCode_tComboEditor.Value != this._searchRate.CustRateGrpCode)
                            {
                                dispSetStatus = editChgDataChk("���Ӑ�|���O���[�v", this.CustRateGrpCode_tComboEditor.Value.ToString(), this._searchRate.CustRateGrpCode);

                                // �f�[�^�ݒ�
                                DispSetCustRateGrpCode(dispSetStatus, ref canChangeFocus, outParamObj);

                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("���Ӑ�|���O���[�v");
                            dispSetStatus = this._searchRate.CustRateGrpCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;

                            // �f�[�^�ݒ�
                            DispSetCustRateGrpCode(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }
                // �l���ύX�����ꍇ�A�܂��́A���݃`�F�b�N���G���[�̏ꍇ�͈ȉ��̏����ɐi�܂Ȃ�
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //----------------
            // �d����R�[�h
            //----------------
            if (this.SupplierCd_tNedit.Enabled == true)
            {
                // �����ݒ�N���A
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p
                status = (int)InputChkStatus.NotExist;

                // �����ݒ�
                inParamObj = this.SupplierCd_tNedit.GetInt();

                // ���݃`�F�b�N
                status = CheckSupplierCd(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // �l�ύX�`�F�b�N
                            if (this.SupplierCd_tNedit.GetInt() != this._searchRate.SupplierCd)
                            {
                                dispSetStatus = editChgDataChk("�d����R�[�h", this.SupplierCd_tNedit.GetInt(), this._searchRate.SupplierCd);

                                // �f�[�^�ݒ�
                                DispSetSupplierCd(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("�d����R�[�h");
                            dispSetStatus = this._searchRate.SupplierCd == 0 ? DispSetStatus.Clear : DispSetStatus.Back;

                            // �f�[�^�ݒ�
                            DispSetSupplierCd(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }
                // �l���ύX�����ꍇ�A�܂��́A���݃`�F�b�N���G���[�̏ꍇ�͈ȉ��̏����ɐi�܂Ȃ�
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //--------------------
            // �d����|���O���[�v
            //--------------------
            if ((this.SuppRateGrpCode_tComboEditor.Enabled == true) && (this.SuppRateGrpCode_tComboEditor.Value != null))
            {
                // �����ݒ�N���A
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p
                status = (int)InputChkStatus.NotExist;

                // �����ݒ�
                inParamList.Add(this._suppRateGrpCodeSList);
                inParamList.Add((int)this.SuppRateGrpCode_tComboEditor.Value);
                inParamObj = inParamList;

                // ���݃`�F�b�N
                status = CheckUserGuide(inParamObj, out outParamObj);
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // �l�ύX�`�F�b�N
                            if ((int)this.SuppRateGrpCode_tComboEditor.Value != this._searchRate.SuppRateGrpCode)
                            {
                                dispSetStatus = editChgDataChk("�d����|���O���[�v", this.SuppRateGrpCode_tComboEditor.Value.ToString(), this._searchRate.SuppRateGrpCode);

                                // �f�[�^�ݒ�
                                DispSetSuppRateGrpCode(dispSetStatus, ref canChangeFocus, outParamObj);

                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("�d����|���O���[�v");
                            dispSetStatus = this._searchRate.SuppRateGrpCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;

                            // �f�[�^�ݒ�
                            DispSetSuppRateGrpCode(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }
                // �l���ύX�����ꍇ�A�܂��́A���݃`�F�b�N���G���[�̏ꍇ�͈ȉ��̏����ɐi�܂Ȃ�
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// �|�����ڑS�̃`�F�b�N����
        /// </summary>
        /// <param name="oldSaveFlag">���|���f�[�^�ݒ�L���i0:�ݒ薳��, 1:�ݒ�L��j</param>
        /// <param name="oldDataDelFlag">���|���f�[�^�폜�v�ہi0:��, 1:�v�j</param>
        /// <returns>�`�F�b�N����(true:OK, false:NG)</returns>
        /// <remarks>
        /// <br>Note       : �|�����ڑS�̂ɑ΂��ĉߕs�����������`�F�b�N���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        private bool InpRateDataCheck(ref int oldSaveFlag, ref int oldDataDelFlag)
        {
            oldSaveFlag = 0; // ���|���ݒ薳��

            object inParamObj = null;
            object outParamObj = null;
            ArrayList inParamList = null;
            int status = (int)InputChkStatus.InputErr;
			
            //------------------------
            // �������ڃG���[�`�F�b�N
            //------------------------
            if(InpCondDataCheck() == false)
            {
                return false;
            }
			
            //---------------
            // �V����i�敪
            //---------------
            if ((this.NewPriceDiv_tComboEditor.Enabled == true) && (this.NewPriceDiv_tComboEditor.Value != null))
            {
                // �����ݒ�N���A
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();

                // �����ݒ�
                inParamList.Add(this._priceDivSList);
                inParamList.Add((int)this.NewPriceDiv_tComboEditor.Value);
                inParamObj = inParamList;

                // ���݃`�F�b�N
                status = CheckUserGuide(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // ���̂܂ܐi��
                            break;
                        }
                    default:
                        {
                            // ���݂��Ȃ��ꍇ�͏����𒆒f����
                            ShowNotFoundErrMsg("�V����i�敪");
                            return false;
                        }
                }
            }

            //---------------
            // ������i�敪
            //---------------
            if ((this.OldPriceDiv_tComboEditor.Enabled == true) && (this.OldPriceDiv_tComboEditor.Value != null))
            {
                // �����ݒ�N���A
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();

                // �����ݒ�
                inParamList.Add(this._priceDivSList);
                inParamList.Add((int)this.OldPriceDiv_tComboEditor.Value);
                inParamObj = inParamList;

                // ���݃`�F�b�N
                status = CheckUserGuide(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // ���̂܂ܐi��
                            break;
                        }
                    default:
                        {
                            // ���݂��Ȃ��ꍇ�͏����𒆒f����
                            ShowNotFoundErrMsg("������i�敪");
                            return false;
                        }
                }
            }
			
            //----------------
            // �V�|���ݒ蔻��
            //----------------
            // ���ݒ�̏ꍇ�i�P�� == 0, �|�� == 0, �[�������P�� == 0�j
            if ((this.NewPrice_tNedit.GetValue() == 0)
                && (this.NewRate_tNedit.GetValue() == 0)
                && (this.NewUnPrcFracProcUnit_tNedit.GetValue() == 0))
            {
                this.NewPrice_tNedit.Focus();
                ShowInpErrMsg("�P�����|���̉��ꂩ��ݒ肵�Ă��������B�i�V�|���j");
                return false;
            }
            // �P���ݒ�̏ꍇ�i�P�� > 0�j
            if (this.NewPrice_tNedit.GetValue() > 0)
            {
                // �|�� != 0
                if (this.NewRate_tNedit.GetValue() != 0)
                {
                    this.NewRate_tNedit.Focus();
                    ShowInpErrMsg("�|�����ݒ肳��Ă��܂��B�i�V�|���j");
                    return false;
                }
                // �[�������P�� != 0
                if (this.NewUnPrcFracProcUnit_tNedit.GetValue() != 0)
                {
                    this.NewUnPrcFracProcUnit_tNedit.Focus();
                    ShowInpErrMsg("�[�������P�ʂ��ݒ肳��Ă��܂��B�i�V�|���j");
                    return false;
                }
            }
            // �|���ݒ�̏ꍇ�i�P�� == 0�j
            else
            {
                // �|�� == 0
                if (this.NewRate_tNedit.GetValue() == 0.00)
                {
                    this.NewRate_tNedit.Focus();
                    ShowInpErrMsg("�|����ݒ肵�Ă��������B�i�V�|���j");
                    return false;
                }
                // �[�������P�� == 0.00
                if (this.NewUnPrcFracProcUnit_tNedit.GetValue() == 0)
                {
                    this.NewUnPrcFracProcUnit_tNedit.Focus();
                    ShowInpErrMsg("�[�������P�ʂ�ݒ肵�Ă��������B�i�V�|���j");
                    return false;
                }
            }
			
            //----------------
            // ���|���ݒ蔻��
            //----------------
            // ���ݒ�̏ꍇ�i�P�� == 0, �|�� == 0, �[�������P�� == 0�j
            if ((this.OldPrice_tNedit.GetValue() == 0)
                && (this.OldRate_tNedit.GetValue() == 0)
                && (this.OldUnPrcFracProcUnit_tNedit.GetValue() == 0))
            {
                oldSaveFlag = 0; // ���|���ݒ薳��

                //------------------------------------------------------------------
                // ���f�[�^�L������
                //   ���f�[�^���ݎ��A��ʃf�[�^�����ݒ�̏ꍇ�A�����폜�f�[�^�Ƃ���
                //------------------------------------------------------------------
                string searchStr = "";
                _stringBuilder.Remove(0, _stringBuilder.Length);
                _stringBuilder.Append(RateAcs.OLDNEWDIVCD);
                _stringBuilder.Append(" = '1' and ");
                _stringBuilder.Append(RateAcs.LOTCOUNT);
                _stringBuilder.Append(" = '0'");
                searchStr = _stringBuilder.ToString();

                DataRow[] foundRateRow = this._dataTableRate.Select(searchStr);
				
                if (foundRateRow.Length > 0)
                {
                    // ���f�[�^�폜�������s��
                    oldDataDelFlag = 1;	// �폜�f�[�^
                }
            }
            else
            {
                // �P���ݒ�̏ꍇ�i�P�� > 0�j
                if (this.OldPrice_tNedit.GetValue() > 0)
                {
                    oldSaveFlag = 1; // ���|���ݒ�L��

                    // �|�� != 0
                    if (this.OldRate_tNedit.GetValue() != 0)
                    {
                        this.OldRate_tNedit.Focus();
                        ShowInpErrMsg("�|�����ݒ肳��Ă��܂��B�i���|���j");
                        return false;
                    }
                    // �[�������P�� != 0
                    if (this.OldUnPrcFracProcUnit_tNedit.GetValue() != 0)
                    {
                        this.OldUnPrcFracProcUnit_tNedit.Focus();
                        ShowInpErrMsg("�[�������P�ʂ��ݒ肳��Ă��܂��B�i���|���j");
                        return false;
                    }
                }
                // �|���ݒ�̏ꍇ�i�P�� == 0�j
                else
                {
                    oldSaveFlag = 1; // ���|���ݒ�L��

                    // �|�� > 0 && �[�������P�� == 0
                    if ((this.OldRate_tNedit.GetValue() > 0)&&(this.OldUnPrcFracProcUnit_tNedit.GetValue() == 0))
                    {
                        this.OldUnPrcFracProcUnit_tNedit.Focus();
                        ShowInpErrMsg("�[�������P�ʂ�ݒ肵�Ă��������B�i���|���j");
                        return false;
                    }
                    // �|�� == 0 && �[�������P�� > 0
                    if ((this.OldRate_tNedit.GetValue() == 0)&&(this.OldUnPrcFracProcUnit_tNedit.GetValue() > 0))
                    {
                        this.OldRate_tNedit.Focus();
                        ShowInpErrMsg("�|����ݒ肵�Ă��������B�i���|���j");
                        return false;
                    }
                }
            }
						
            //----------------
            // �|���J�n������
            //----------------
            // �����ݒ�
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            inParamList.Add(this.NewRateStartDate_tDateEdit.GetDateYear());
            inParamList.Add(this.NewRateStartDate_tDateEdit.GetDateMonth());
            inParamList.Add(this.NewRateStartDate_tDateEdit.GetDateDay());
            inParamObj = inParamList;

            // �V�|���J�n���G���[�`�F�b�N
            status = CheckRateStartDate(inParamObj, out outParamObj);
            switch(status)
            {
                case (int)InputChkStatus.Normal:
                    {
                        // �������Ȃ�
                        break;
                    }
                case (int)InputChkStatus.NotInput:
                    {
                        // ������
                        this.NewRateStartDate_tDateEdit.Focus();
                        ShowInpErrMsg("�V�|���J�n���������͂ł��B");
                        return false;
                    }
                case (int)InputChkStatus.InputErr:
                    {
                        // �s���f�[�^
                        this.NewRateStartDate_tDateEdit.Focus();
                        ShowInpErrMsg("�V�|���J�n���̃f�[�^���s���ł��B");
                        return false;
                    }
                default:
                    {
                        // ���̑��G���[
                        return false;
                    }
            }
						
            // ���|���J�n�������͔���
            if (oldSaveFlag == 1)
            {
                // �����ݒ�
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
				
                inParamList.Add(this.OldRateStartDate_tDateEdit.GetDateYear());
                inParamList.Add(this.OldRateStartDate_tDateEdit.GetDateMonth());
                inParamList.Add(this.OldRateStartDate_tDateEdit.GetDateDay());
                inParamObj = inParamList;
				
                // �V�|���J�n���G���[�`�F�b�N
                status = CheckRateStartDate(inParamObj, out outParamObj);
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                        {
                            // �������Ȃ�
                            break;
                        }
                    case (int)InputChkStatus.NotInput:
                        {
                            // ������
                            this.OldRateStartDate_tDateEdit.Focus();
                            ShowInpErrMsg("���|���J�n���������͂ł��B");
                            return false;
                        }
                    case (int)InputChkStatus.InputErr:
                        {
                            // �s���f�[�^
                            this.OldRateStartDate_tDateEdit.Focus();
                            ShowInpErrMsg("���|���J�n���̃f�[�^���s���ł��B");
                            return false;
                        }
                    default:
                        {
                            // ���̑��G���[
                            return false;
                        }
                }
            }
			
            // �|���J�n������
            if (oldSaveFlag == 1)
            {
                if (this.NewRateStartDate_tDateEdit.GetDateTime() <= this.OldRateStartDate_tDateEdit.GetDateTime())
                {
                    this.NewRateStartDate_tDateEdit.Focus();
                    ShowInpErrMsg(RATE_STDATE_MSG);
                    return false;
                }
            }
			
            return true;
        }

        /// <summary>
        /// ���̓G���[���b�Z�[�W�o�͏���
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : ���̓G���[���b�Z�[�W���o�͂��܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.12</br>
        /// </remarks>
        private void ShowInpErrMsg(string errMsg)
        {
            DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_INFO,		                  // �G���[���x��
                ASSEMBLY_ID, 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
                errMsg,									              // �\�����郁�b�Z�[�W
                0, 					                                  // �X�e�[�^�X�l
                MessageBoxButtons.OK);			                      // �\������{�^��
        }

        /// <summary>
        /// �f�[�^�����G���[���b�Z�[�W�o�͏���
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�����̃G���[���b�Z�[�W���o�͂��܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.12</br>
        /// </remarks>
        private void ShowNotFoundErrMsg(string errMsg)
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);
            _stringBuilder.Append("�w�肳�ꂽ�����ŁA");
            _stringBuilder.Append(errMsg);
            _stringBuilder.Append("�͑��݂��܂���ł����B");
            errMsg = _stringBuilder.ToString();
			
            DialogResult res = TMsgDisp.Show(this,                    // �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_INFO,		                  // �G���[���x��
                ASSEMBLY_ID, 			                              // �A�Z���u���h�c�܂��̓N���X�h�c
                errMsg,									              // �\�����郁�b�Z�[�W
                0, 					                                  // �X�e�[�^�X�l
                MessageBoxButtons.OK);			                      // �\������{�^��
        }
		
        /// <summary>
        /// �ύX�m�F���b�Z�[�W�o�͏���
        /// </summary>
        /// <param name="infoMsg">���b�Z�[�W</param>
        /// <param name="emErrorLevel">�G���[���x��</param>
        /// <remarks>
        /// <br>Note       : �ύX�m�F���b�Z�[�W���o�͂��܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.25</br>
        /// </remarks>
        private bool ShowConfirmMsg(string infoMsg, emErrorLevel emErrorLevel)
        {
            bool retBool = false;
			
            // �m�F���b�Z�[�W�o��
            DialogResult res = TMsgDisp.Show(
                this, 								// �e�E�B���h�E�t�H�[��
                emErrorLevel.ERR_LEVEL_INFO,		// �G���[���x��
                ASSEMBLY_ID,   						// �A�Z���u���h�c�܂��̓N���X�h�c
                infoMsg,							// �\�����郁�b�Z�[�W
                (int)emErrorLevel,					// �X�e�[�^�X�l
                MessageBoxButtons.YesNo, 			// �\������{�^��
                MessageBoxDefaultButton.Button2);	// �����\���{�^��
			
                if (res == DialogResult.Yes)
                {
                    retBool = true;
                }
                else
                {
                    retBool = false;
                }
            return retBool;
        }
		
        /// <summary>
        /// NULL�����ϊ�����
        /// </summary>
        /// <param name="obj">�I�u�W�F�N�g</param>
        /// <returns>string�^�f�[�^</returns>
        /// <remarks>
        /// <br>Note       : NULL�������܂܂�Ă���ꍇ�_�u���N�H�[�g�֕ϊ�����</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.10.11</br>
        /// </remarks>
        private string NullChgStr(object obj)
        {
            string ret;
            try
            {
                if (obj == null)
                {
                    ret = "";
                }
                else
                {
                    ret = obj.ToString();
                }
            }
            catch
            {
                ret = "";
            }
            return ret;
        }
		
        /// <summary>
        /// NULL�����ϊ�����
        /// </summary>
        /// <param name="obj">�I�u�W�F�N�g</param>
        /// <returns>int�^�f�[�^</returns>
        /// <remarks>
        /// <br>Note       : NULL�������܂܂�Ă���ꍇ�u0�v�֕ϊ�����</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        private int NullChgInt(object obj)
        {
            int ret;
            try
            {
                if((obj == null)||(string.Equals(obj.ToString(), "") == true))
                {
                    ret = 0;
                }
                else
                {
                    ret = Convert.ToInt32(obj);
                }
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        /// <summary>
        /// NULL�����ϊ�����
        /// </summary>
        /// <param name="obj">�I�u�W�F�N�g</param>
        /// <returns>double�^�f�[�^</returns>
        /// <remarks>
        /// <br>Note       : NULL�������܂܂�Ă���ꍇ�u0�v�֕ϊ�����</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        private double NullChgDbl(object obj)
        {
            double ret;
            try
            {
                if ((obj == null)||(string.Equals(obj.ToString(), "") == true))
                {
                    ret = 0;
                }
                else
                {
                    ret = double.Parse(obj.ToString());
                }
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        /// <summary>
        /// ����������ʏ��|���N���X�i�[����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�|���I�u�W�F�N�g�Ɍ����������i�[���܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        private void DispToRateSearch()
        {
            //----- ueno add ---------- start 2008.03.31
            // ���_�R�[�h�[������
            this.RateSectionCode_tEdit.Text = GetZeroPaddedTextProc(this.RateSectionCode_tEdit.Text, this.RateSectionCode_tEdit.ExtEdit.Column);
            //----- ueno add ---------- end 2008.03.31

            this._searchRate.EnterpriseCode			= this._enterpriseCode;									// ��ƃR�[�h
            this._searchRate.SectionCode			= this.RateSectionCode_tEdit.Text;							// ���_�R�[�h
            this._searchRate.UnitPriceKind			= NullChgStr(this.UnitPriceKind_tComboEditor.Value);	// �P�����
            this._searchRate.RateSettingDivide		= this.RateSettingDivide_tEdit.Text;					// �|���ݒ�敪
            this._searchRate.RateMngGoodsCd			= this.RateMngGoodsCd_tEdit.Text;						// �|���ݒ�敪�i���i�j
            this._searchRate.RateMngGoodsNm			= this.RateMngGoodsNm_tEdit.Text;						// �|���ݒ薼�́i���i�j
            this._searchRate.RateMngCustCd			= this.RateMngCustCd_tEdit.Text;						// �|���ݒ�敪�i���Ӑ�j
            this._searchRate.RateMngCustNm			= this.RateMngCustNm_tEdit.Text;						// �|���ݒ薼�́i���Ӑ�j
			
            // �P�i�ݒ�̏ꍇ
            if (this.UnitPriceKindWay_tComboEditor.SelectedIndex == 0)
            {
                this._searchRate.GoodsMakerCd		= this.GoodsMakerCd_tNedit.GetInt();					// ���i���[�J�[�R�[�h�i�P�i�j
            }
            // ���i�f�ݒ�̏ꍇ
            else
            {
                this._searchRate.GoodsMakerCd		= this.GoodsMakerCd_Grp_tNedit.GetInt();				// ���i���[�J�[�R�[�h�i���i�f�j
            }
			
            this._searchRate.GoodsNo				= this.GoodsNoCd_tEdit.Text;									// ���i�ԍ�
            this._searchRate.GoodsRateRank			= this.GoodsRateRankCd_Grp_tEdit.Text;							// ���i�|�������N
            this._searchRate.LargeGoodsGanreCode	= this.LargeGoodsGanreCode_Grp_tEdit.Text;						// ���i�敪�O���[�v�R�[�h
            this._searchRate.MediumGoodsGanreCode	= this.MediumGoodsGanreCode_Grp_tEdit.Text;						// ���i�敪�R�[�h
            this._searchRate.DetailGoodsGanreCode	= this.DetailGoodsGanreCode_Grp_tEdit.Text;						// ���i�敪�ڍ׃R�[�h
            this._searchRate.EnterpriseGanreCode	= NullChgInt(this.EnterpriseGanreCode_Grp_tComboEditor.Value);	// ���Е��ރR�[�h
            this._searchRate.BLGoodsCode			= this.BLGoodsCode_Grp_tNedit.GetInt();							// �a�k���i�R�[�h
            this._searchRate.CustomerCode			= this.CustomerCode_tNedit.GetInt();							// ���Ӑ�R�[�h
            this._searchRate.CustRateGrpCode		= NullChgInt(this.CustRateGrpCode_tComboEditor.Value);			// ���Ӑ�|���f�R�[�h
            this._searchRate.SupplierCd				= this.SupplierCd_tNedit.GetInt();								// �d����R�[�h
            this._searchRate.SuppRateGrpCode		= NullChgInt(this.SuppRateGrpCode_tComboEditor.Value);			// �d����|���f�R�[�h
        }

        /// <summary>
        /// �����������ʉ�ʏ��ݒ菈��
        /// </summary>
        /// <param name="dr">�|���f�[�^�e�[�u���s</param>
        /// <returns>���ʁitrue:��ʐݒ萳��, false:��ʐݒ�G���[�j</returns>
        /// <remarks>
        /// <br>Note       : �|���f�[�^�e�[�u�������ʍ��ڂɃf�[�^��ݒ肵�܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        private int DataRowToScreen(DataRow dr)
        {
            object inParamObj = null;
            object outParamObj = null;
            ArrayList inParamList = null;

            //------------
            // �V�|���ݒ�
            //------------
            if (string.Equals(NullChgStr(dr[RateAcs.OLDNEWDIVCD]), OLDNEWDIVCD_NEW) == true)
            {
                //----- �V����i�敪���݃`�F�b�N -----//
                // �����ݒ�N���A
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();

                // �����ݒ�
                inParamList.Add(this._priceDivSList);
                inParamList.Add((int)dr[RateAcs.PRICEDIV]);
                inParamObj = inParamList;

                // ���݃`�F�b�N
                if (CheckUserGuide(inParamObj, out outParamObj) == (int)InputChkStatus.Normal)
                {
                    this.NewPriceDiv_tComboEditor.Value = dr[RateAcs.PRICEDIV];
                }
                else
                {
                    // ���݂��Ȃ��ꍇ�͏����𒆒f����
                    ShowInpErrMsg("�V����i�敪�����݂��܂���B\n����i�敪�̓o�^�����肢���܂��B");

                    // �����������͏�Ԃɂ���
                    // �S�̓��̓R���g���[��
                    SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.InputCondition.GetHashCode());
                    this._AllCtrlInputStatus = AllCtrlInputStatus.InputCondition;

                    // ���[�h���x��
                    this._modeFlag = ModeFlag.None;	// ���m��

                    // �������ʃf�[�^�N���A�i�O��̕����l���j
                    SrchRsltDataClear();

                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                this.NewRateStartDate_tDateEdit.SetDateTime((DateTime)dr[RateAcs.RATESTARTDATE]);
                this.NewPrice_tNedit.Value					= dr[RateAcs.PRICEFL];
                this.NewUnPrcCalcDiv_tComboEditor.Value		= dr[RateAcs.UNITPRCCALCDIV];
                this.NewRate_tNedit.Value					= dr[RateAcs.RATEVAL];
                this.NewUnPrcFracProcUnit_tNedit.Value		= dr[RateAcs.UNPRCFRACPROCUNIT];
                this.NewUnPrcFracProcDiv_tComboEditor.Value = dr[RateAcs.UNPRCFRACPROCDIV];
                this.NewBargainCd_tComboEditor.Value		= dr[RateAcs.BARGAINCD];
				
                // ���l���ڍœK��
                NumFormatSet(ref this.NewPrice_tNedit);
                NumFormatSet(ref this.NewRate_tNedit);
                NumFormatSet(ref this.NewUnPrcFracProcUnit_tNedit);
            }
			
            //------------
            // ���|���ݒ�
            //------------
            else
            {
                //----- ������i�敪���݃`�F�b�N -----//
                // �����ݒ�N���A
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();

                // �����ݒ�
                inParamList.Add(this._priceDivSList);
                inParamList.Add((int)dr[RateAcs.PRICEDIV]);
                inParamObj = inParamList;

                // ���݃`�F�b�N
                if (CheckUserGuide(inParamObj, out outParamObj) == (int)InputChkStatus.Normal)
                {
                    this.OldPriceDiv_tComboEditor.Value = dr[RateAcs.PRICEDIV];
                }
                else
                {
                    // ���݂��Ȃ��ꍇ�͏����𒆒f����
                    ShowInpErrMsg("������i�敪�����݂��܂���B\n����i�敪�̓o�^�����肢���܂��B");

                    // �����������͏�Ԃɂ���
                    // �S�̓��̓R���g���[��
                    SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.InputCondition.GetHashCode());
                    this._AllCtrlInputStatus = AllCtrlInputStatus.InputCondition;

                    // ���[�h���x��
                    this._modeFlag = ModeFlag.None;	// ���m��

                    // �������ʃf�[�^�N���A�i�O��̕����l���j
                    SrchRsltDataClear();

                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                this.OldRateStartDate_tDateEdit.SetDateTime((DateTime)dr[RateAcs.RATESTARTDATE]);
                this.OldPrice_tNedit.Value					= dr[RateAcs.PRICEFL];
                this.OldUnPrcCalcDiv_tComboEditor.Value		= dr[RateAcs.UNITPRCCALCDIV];
                this.OldRate_tNedit.Value					= dr[RateAcs.RATEVAL];
                this.OldUnPrcFracProcUnit_tNedit.Value		= dr[RateAcs.UNPRCFRACPROCUNIT];
                this.OldUnPrcFracProcDiv_tComboEditor.Value = dr[RateAcs.UNPRCFRACPROCDIV];
                this.OldBargainCd_tComboEditor.Value		= dr[RateAcs.BARGAINCD];

                // ���l���ڍœK��
                NumFormatSet(ref this.OldPrice_tNedit);
                NumFormatSet(ref this.OldRate_tNedit);
                NumFormatSet(ref this.OldUnPrcFracProcUnit_tNedit);
            }
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// ����������ʏ��|���N���X�i�[�����i�P���Z�o�敪�`�F�b�N�p�j
        /// </summary>
        /// <param name="rate">��������</param>
        /// <param name="oldNewDivCd">�V���敪</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�|���I�u�W�F�N�g�Ɍ����������i�[���܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.12.03</br>
        /// </remarks>
        private void RateSearchUnitPriceKind(ref Rate rate, string oldNewDivCd)
        {
            rate.EnterpriseCode = this._searchRate.EnterpriseCode;				// ��ƃR�[�h
            rate.SectionCode = this._searchRate.SectionCode;					// ���_�R�[�h
            rate.OldNewDivCd = oldNewDivCd;										// �V���敪
            rate.UnitPriceKind = "4";											// �P����ށi�艿�j
            rate.RateSettingDivide = this._searchRate.RateSettingDivide;		// �|���ݒ�敪
            rate.RateMngGoodsCd = this._searchRate.RateMngGoodsCd;				// �|���ݒ�敪�i���i�j
            rate.RateMngCustNm = this._searchRate.RateMngGoodsNm;				// �|���ݒ薼�́i���i�j
            rate.RateMngCustCd = this._searchRate.RateMngCustCd;				// �|���ݒ�敪�i���Ӑ�j
            rate.RateMngCustNm = this._searchRate.RateMngCustNm;				// �|���ݒ薼�́i���Ӑ�j
            rate.GoodsMakerCd = this._searchRate.GoodsMakerCd;					// ���i���[�J�[�R�[�h�i���i�f�j

            rate.GoodsNo = this._searchRate.GoodsNo;							// ���i�ԍ�
            rate.GoodsRateRank = this._searchRate.GoodsRateRank;				// ���i�|�������N
            rate.LargeGoodsGanreCode = this._searchRate.LargeGoodsGanreCode;	// ���i�敪�O���[�v�R�[�h
            rate.MediumGoodsGanreCode = this._searchRate.MediumGoodsGanreCode;	// ���i�敪�R�[�h
            rate.DetailGoodsGanreCode = this._searchRate.DetailGoodsGanreCode;	// ���i�敪�ڍ׃R�[�h
            rate.EnterpriseGanreCode = this._searchRate.EnterpriseGanreCode;	// ���Е��ރR�[�h
            rate.BLGoodsCode = this._searchRate.BLGoodsCode;					// �a�k���i�R�[�h
            rate.CustomerCode = this._searchRate.CustomerCode;					// ���Ӑ�R�[�h
            rate.CustRateGrpCode = this._searchRate.CustRateGrpCode;			// ���Ӑ�|���f�R�[�h
            rate.SupplierCd = this._searchRate.SupplierCd;						// �d����R�[�h
            rate.SuppRateGrpCode = this._searchRate.SuppRateGrpCode;			// �d����|���f�R�[�h
        }

        /// <summary>
        /// �P���Z�o�敪�`�F�b�N����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �P���Z�o�敪�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.12.03</br>
        /// </remarks>
        private void UnPrcCalcDivCheck()
        {
            //=======================================================================================
            // �P���Z�o�敪�`�F�b�N�i�P�����=����P�����j
            //   �|���ݒ�敪�������ŒP�����=�艿�̃��R�[�h�����ɑ��݂��Ă���ꍇ�A
            //   �P���Z�o�敪=1:����ix�|���͐ݒ�s�Ƃ���B
            //   ��. ���iA�̉��iϽ��̒艿:\8,000
            //     �@�艿     �P�i�ݒ� A3 Ұ��+���i+���Ӑ� ���iA հ�ް�艿\10,000
            //     �A����P�� �P�i�ݒ� A3 Ұ��+���i+���Ӑ� ���iA �P���Z�o�敪1:����ix�|�� �|��80%
            //       
            //       �A�̊���i�͉��iϽ���\8,000���K�p����A\8,000 x 80% = \6,400
            //       �������́Aհ�ް�艿��\10,000��K�p���A\10,000 x 80% = \8,000 �ƂȂ�
            //=======================================================================================

            // �P���Z�o�敪������P���̏ꍇ
            if (NullChgInt(this.UnitPriceKind_tComboEditor.Value) == 1)
            {
                Rate rate = new Rate();

                foreach (DictionaryEntry de in Rate._OldNewDivCdTable)
                {
                    // �����f�[�^�ݒ�
                    RateSearchUnitPriceKind(ref rate, NullChgStr(de.Key));

                    int ret = this._rateAcs.Read(ref rate);
                    string wkStr = "";

                    // �艿�����݂����ꍇ
                    if (ret == 0)
                    {
                        // 1:����i�~�|���ȊO
                        _stringBuilder.Remove(0, _stringBuilder.Length);
                        _stringBuilder.Append(COMBO_CODE);
                        _stringBuilder.Append(" <> '1'");
                        wkStr = _stringBuilder.ToString();

                        if (NullChgStr(de.Key) == "0")
                        {
                            this._dataTableUnPrcCalcDivNew.DefaultView.RowFilter = wkStr;
                            this.NewUnPrcCalcDiv_tComboEditor.Value = Rate._unPrcCalcDivTable.GetKey(1);
                            this._unitPrcCalcDivNewFlag = false;
                        }
                        else
                        {
                            this._dataTableUnPrcCalcDivOld.DefaultView.RowFilter = wkStr;
                            this.OldUnPrcCalcDiv_tComboEditor.Value = Rate._unPrcCalcDivTable.GetKey(1);
                            this._unitPrcCalcDivOldFlag = false;
                        }
                    }
                    else
                    {
                        wkStr = "";	// �N���A

                        if (NullChgStr(de.Key) == "0")
                        {
                            this._dataTableUnPrcCalcDivNew.DefaultView.RowFilter = wkStr;
                            this.NewUnPrcCalcDiv_tComboEditor.Value = Rate._unPrcCalcDivTable.GetKey(0);
                            this._unitPrcCalcDivNewFlag = true;
                        }
                        else
                        {
                            this._dataTableUnPrcCalcDivOld.DefaultView.RowFilter = wkStr;
                            this.OldUnPrcCalcDiv_tComboEditor.Value = Rate._unPrcCalcDivTable.GetKey(0);
                            this._unitPrcCalcDivOldFlag = true;
                        }
                    }
                }
            }
        }
		
        /// <summary>
        /// ���l�`���ݒ菈��
        /// </summary>
        /// <param name="tNedit">���l�f�[�^</param>
        /// <remarks>
        /// <br>Note       : ���l�`����ݒ肵�܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.11.1</br>
        /// </remarks>
        private void NumFormatSet(ref TNedit tNedit)
        {
            double value = tNedit.GetValue();
            tNedit.Text = value.ToString("###,#0.00");
        }

        /// <summary>
        /// �|���}�X�^��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^����Y���f�[�^���������܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        private int RateSearch()
        {
            //-----------------------------------------------------------
            // �f�[�^�̌����y�сA�n�b�V���e�[�u���Ɍ������ʊi�[
            //  �ithis._dataTableRate, this._rateSrchRsltHashList�Ɋi�[�j
            //-----------------------------------------------------------
            int status = SrchRsltDataSet();

            if (status != 0)
            {
                return status;
            }

            string searchStr;
            //--------------------------------------------------------
            // �擾�f�[�^����ʍ��ڂɐݒ�
            //		���b�g�����u0�v�̃��R�[�h�i�V���|���f�[�^�j
            //--------------------------------------------------------
            searchStr = "";
            _stringBuilder.Remove(0, _stringBuilder.Length);
            _stringBuilder.Append(RateAcs.LOTCOUNT);
            _stringBuilder.Append(" = '0'");
            searchStr = _stringBuilder.ToString();
			
            DataRow[] foundRateRow = this._dataTableRate.Select(searchStr);
            
            // ���b�g�e�[�u���N���A
            if (this._dataTableLotNew != null)
            {
                LotTableClear(ref this._dataTableLotNew, OLDNEWDIVCD_NEW, ref this._unitPrcCalcDivNewFlag);
            }

            if (this._dataTableLotOld != null)
            {
                LotTableClear(ref this._dataTableLotOld, OLDNEWDIVCD_OLD, ref this._unitPrcCalcDivOldFlag);
            }

            if (this._dataTableLotNewClone != null)
            {
                LotTableClear(ref this._dataTableLotNewClone, OLDNEWDIVCD_NEW, ref this._unitPrcCalcDivNewFlag);
            }

            if (this._dataTableLotOldClone != null)
            {
                LotTableClear(ref this._dataTableLotOldClone, OLDNEWDIVCD_OLD, ref this._unitPrcCalcDivOldFlag);
            }
			

            //------------
            // �V�K���[�h
            //------------
            if (foundRateRow.Length == 0)
            {
                this._modeFlag = ModeFlag.New;	// �V�K
                this.Mode_Label.Text = INSERT_MODE;
				
                // �S�̓��̓R���g���[��
                SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.SearchNew.GetHashCode());

                this._AllCtrlInputStatus = AllCtrlInputStatus.SearchNew;

                // �P���Z�o�敪�`�F�b�N
                UnPrcCalcDivCheck();

                // ���b�g��ʐݒ�
                SetInitialLotTblUnitPrcCalcDiv(ref this._dataTableLotNew, this._unitPrcCalcDivNewFlag);
                SetInitialLotTblUnitPrcCalcDiv(ref this._dataTableLotOld, this._unitPrcCalcDivOldFlag);
            }
            else
            {
                //----------------
                // �X�V���[�h
                //----------------
                if (NullChgInt(foundRateRow[0][RateAcs.LOGICALDELETECODE]) == 0)
                {
                    this._modeFlag = ModeFlag.Update;	// �X�V
                    this.Mode_Label.Text = UPDATE_MODE;
					
                    // �S�̓��̓R���g���[��
                    SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.SearchUpdate.GetHashCode());

                    this._AllCtrlInputStatus = AllCtrlInputStatus.SearchUpdate;
                }
                //----------------
                // �폜���[�h
                //----------------
                else
                {
                    this._modeFlag = ModeFlag.Delete;	// �폜
                    this.Mode_Label.Text = DELETE_MODE;

                    // �S�̓��̓R���g���[��
                    SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.SearchDelete.GetHashCode());

                    this._AllCtrlInputStatus = AllCtrlInputStatus.SearchDelete;
                }

                // �P���Z�o�敪�`�F�b�N
                UnPrcCalcDivCheck();

                // ���b�g��ʐݒ�
                SetInitialLotTblUnitPrcCalcDiv(ref this._dataTableLotNew,  this._unitPrcCalcDivNewFlag);
                SetInitialLotTblUnitPrcCalcDiv(ref this._dataTableLotOld,  this._unitPrcCalcDivOldFlag);

                //----------------
                // ��ʃf�[�^�ݒ�
                //----------------
                foreach (DataRow fRow in foundRateRow)
                {
                    // ��ʍ��ڂɐV���f�[�^��ݒ�
                    status = DataRowToScreen(fRow);
					
                    if(status != 0)
                    {
                        return status;
                    }
                }
				
                // ���b�g�L������i���b�g���u0�v�ȊO�����݂��邩�j
                foreach (DictionaryEntry de in Rate._OldNewDivCdTable)
                {
                    searchStr = "";
                    _stringBuilder.Remove(0, _stringBuilder.Length);
                    _stringBuilder.Append(RateAcs.OLDNEWDIVCD);
                    _stringBuilder.Append(" = '");
                    _stringBuilder.Append(de.Key);
                    _stringBuilder.Append("' and ");
                    _stringBuilder.Append(RateAcs.LOTCOUNT);
                    _stringBuilder.Append(" <> '0'");
                    searchStr = _stringBuilder.ToString();

                    DataRow[] foundLotRow = this._dataTableRate.Select(searchStr);

                    int lotCnt = 0;	// ���b�g���J�E���g

                    if (foundLotRow.Length > 0)
                    {
                        foreach (DataRow lotRow in foundLotRow)
                        {
                            // �|�����b�g�f�[�^�\�z
                            //     ������this._dataTableLotNew, this._dataTableLotOld�Ƀf�[�^�i�[�j
                            SetLotTblList(lotRow, NullChgStr(de.Value), lotCnt);
                            lotCnt++;
                        }
						
                        // �V�����b�g�f�[�^�N���[���֌������ʃf�[�^���R�s�[
                        this._dataTableLotNewClone = this._dataTableLotNew.Copy();
                        this._dataTableLotOldClone = this._dataTableLotOld.Copy();
                    }

                    if ((this.NewRateStartDate_tDateEdit.GetDateYear() != 0)
                        && (this.NewRateStartDate_tDateEdit.GetDateMonth() != 0)
                        && (this.NewRateStartDate_tDateEdit.GetDateDay() != 0))
                    {	
                        // �V���b�g�J�n���ݒ�
                        this.LotNewRateStartDate_tDateEdit.SetDateTime(this.NewRateStartDate_tDateEdit.GetDateTime());
                    }
                    if ((this.OldRateStartDate_tDateEdit.GetDateYear() != 0)
                        && (this.OldRateStartDate_tDateEdit.GetDateMonth() != 0)
                        && (this.OldRateStartDate_tDateEdit.GetDateDay() != 0))
                    {
                        // �����b�g�J�n���ݒ�
                        this.LotOldRateStartDate_tDateEdit.SetDateTime(this.OldRateStartDate_tDateEdit.GetDateTime());
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// �������ʃf�[�^�i�[
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^���猟���������ʂ�S�Ċi�[���܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.10.31</br>
        /// </remarks>
        private int SrchRsltDataSet()
        {
            string message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // �������ʃf�[�^�N���A�i�O��̕����l���j
            SrchRsltDataClear();

            // �|���}�X�^�����p�f�[�^�i�[
            DispToRateSearch();

            //----------------
            // �|���}�X�^����
            //----------------
            status = this._rateAcs.SearchAll(out this._dataTableRate
                                            , ref this._searchRate
                                            , out message);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        // �T�[�`
                        TMsgDisp.Show(
                                this, 								// �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_STOP,        // �G���[���x��
                                ASSEMBLY_ID,                        // �A�Z���u���h�c�܂��̓N���X�h�c
                                this.Text,			                // �v���O��������
                                "RateSearch", 						// ��������
                                TMsgDisp.OPE_GET,                   // �I�y���[�V����
                                ERR_READ_MSG,					    // �\�����郁�b�Z�[�W
                                status,                             // �X�e�[�^�X�l
                                this._rateAcs,		    	        // �G���[�����������I�u�W�F�N�g
                                MessageBoxButtons.OK,               // �\������{�^��
                                MessageBoxDefaultButton.Button1);   // �����\���{�^��
						
                        // �ȍ~�������Ȃ�
                        return status;
                    }
            }

            if (this._dataTableRate.Rows != null)
            {
                string hashKey = "";
                foreach (DataRow row in this._dataTableRate.Rows)
                {
                    // �������ʂ��f�[�^���E����|���N���X�֕ϊ�����
                    Rate wkRate = null;
                    CopyToRateFromRow(ref wkRate, row);
					
                    // �n�b�V���L�[�쐬
                    hashKey = wkRate.OldNewDivCd + wkRate.LotCount.ToString("000000000.00");

                    // �������ʂ��i�[
                    if (this._rateSrchRsltHashList.ContainsKey(hashKey) == false)
                    {
                        this._rateSrchRsltHashList.Add(hashKey, wkRate);
                    }
					
                    // ��r�p�N���[���ɂ��i�[
                    Rate wkRateClone = wkRate.Clone();

                    if (this._rateSrchRsltHashListClone.ContainsKey(hashKey) == false)
                    {
                        this._rateSrchRsltHashListClone.Add(hashKey, wkRateClone);
                    }
                }
				
                // �V���|���ݒ�̓f�[�^�������Ă���ō쐬���Ă���
                foreach (DictionaryEntry de in Rate._OldNewDivCdTable)				
                {
                    hashKey = de.Key + "000000000.00";
					
                    if (this._rateSrchRsltHashList.ContainsKey(hashKey) == false)
                    {
                        this._rateSrchRsltHashList.Add(hashKey, new Rate());
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// �������ʃf�[�^�N���A�i�[
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|���}�X�^���猟���������ʂ�S�ăN���A���܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.11.2</br>
        /// </remarks>
        private void SrchRsltDataClear()
        {
            //------------
            // ����������
            //------------
            // �O��̌������ʃf�[�^���c���Ă���ꍇ�폜
            if (this._dataTableRate != null)
            {
                this._dataTableRate.Rows.Clear();
            }
            if (this._rateSrchRsltHashList != null)
            {
                this._rateSrchRsltHashList = new Hashtable();
            }
            if (this._rateSrchRsltHashListClone != null)
            {
                this._rateSrchRsltHashListClone = new Hashtable();
            }
			
            // �P���Z�o�敪�t���O������
            this._unitPrcCalcDivNewFlag = true;
			
            // �V�|���ݒ荀��
            this.NewRateStartDate_tDateEdit.SetToday();													// �|���J�n��
            this.NewPrice_tNedit.Clear();																// �P��
            this.NewRate_tNedit.Clear();																// �|��
            this.NewUnPrcFracProcUnit_tNedit.Clear();													// �P���[�������P��
            this.NewPriceDiv_tComboEditor.Value				= this._priceDivSList.GetKey(0);			// �V����i�敪
            this.NewUnPrcCalcDiv_tComboEditor.Value			= Rate._unPrcCalcDivTable.GetKey(0);		// �V�P���Z�o�敪
            this.NewUnPrcFracProcDiv_tComboEditor.Value		= Rate._unPrcFracProcDivTable.GetKey(0);	// �V�P���[�������敪
            this.NewBargainCd_tComboEditor.Value			= this._bargainCdSList.GetKey(0);			// �V�����敪
			
            // ���|���ݒ荀��
            this.OldRateStartDate_tDateEdit.Clear();													// �|���J�n��
            this.OldPrice_tNedit.Clear();																// �P��
            this.OldRate_tNedit.Clear();																// �|��
            this.OldUnPrcFracProcUnit_tNedit.Clear();													// �P���[�������P��
            this.OldPriceDiv_tComboEditor.Value				= this._priceDivSList.GetKey(0);			// ������i�敪
            this.OldUnPrcCalcDiv_tComboEditor.Value			= Rate._unPrcCalcDivTable.GetKey(0);		// ���P���Z�o�敪
            this.OldUnPrcFracProcDiv_tComboEditor.Value		= Rate._unPrcFracProcDivTable.GetKey(0);	// ���P���[�������敪
            this.OldBargainCd_tComboEditor.Value			= this._bargainCdSList.GetKey(0);			// �������敪
        }

        /// <summary>
        /// ��ʏ��|���N���X�i�[����
        /// </summary>
        /// <param name="rate">�|���I�u�W�F�N�g</param>
        /// <param name="oldNewDivCd">�V���敪</param>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂�|���I�u�W�F�N�g�Ƀf�[�^���i�[���܂��B
        ///					 ��ʍ��ڈȊO�͌������ʃf�[�^��ݒ肵�܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        private void DispToRate(out Rate rate, string oldNewDivCd)
        {
            rate = new Rate();
			
            //--------
            // �w�b�_
            //--------
            // ���[�h����
            if (this._modeFlag != ModeFlag.New)
            {
                string hashKey = oldNewDivCd + "000000000.00";

                if (this._rateSrchRsltHashList.ContainsKey(hashKey) == true)
                {
                    Rate rateWk = (Rate)this._rateSrchRsltHashList[hashKey];
                    rate.CreateDateTime = rateWk.CreateDateTime;
                    rate.UpdateDateTime = rateWk.UpdateDateTime;
                    rate.FileHeaderGuid = rateWk.FileHeaderGuid;
                }
            }
			
            //----------
            // ��������
            //----------
            //----- ueno add ---------- start 2008.03.31
            // ���_�R�[�h�[������
            this.RateSectionCode_tEdit.Text = GetZeroPaddedTextProc(this.RateSectionCode_tEdit.Text, this.RateSectionCode_tEdit.ExtEdit.Column);
            //----- ueno add ---------- end 2008.03.31

            rate.EnterpriseCode				= this._enterpriseCode;
            rate.SectionCode				= this.RateSectionCode_tEdit.Text.Trim();
            rate.UnitPriceKind				= NullChgStr(this.UnitPriceKind_tComboEditor.Value);
            rate.RateSettingDivide			= this.RateSettingDivide_tEdit.Text.Trim();
            rate.RateMngGoodsCd				= this.RateMngGoodsCd_tEdit.Text.Trim();
            rate.RateMngGoodsNm				= this.RateMngGoodsNm_tEdit.Text.Trim();
            rate.RateMngCustCd				= this.RateMngCustCd_tEdit.Text.Trim();
            rate.RateMngCustNm				= this.RateMngCustNm_tEdit.Text.Trim();

            rate.OldNewDivCd				= oldNewDivCd;
			
            // �����f�[�^���H(�P����ށ{�|���ݒ�敪�{�V���敪)
            string wkStr = "";
            _stringBuilder.Remove(0, _stringBuilder.Length);
            _stringBuilder.Append(rate.UnitPriceKind);
            _stringBuilder.Append(rate.RateSettingDivide);
            _stringBuilder.Append(rate.OldNewDivCd);
            wkStr = _stringBuilder.ToString();
			
            rate.UnitRateSetDivCd = wkStr;
			
            // �P�i�ݒ�̏ꍇ
            if (this.UnitPriceKindWay_tComboEditor.SelectedIndex == 0)
            {
                rate.GoodsMakerCd			= this.GoodsMakerCd_tNedit.GetInt();
                rate.GoodsNo				= this.GoodsNoCd_tEdit.Text.Trim();
            }
            // ���i�O���[�v�ݒ�̏ꍇ
            else
            {
                rate.GoodsMakerCd			= this.GoodsMakerCd_Grp_tNedit.GetInt();
                rate.GoodsRateRank			= this.GoodsRateRankCd_Grp_tEdit.Text.Trim();
                rate.LargeGoodsGanreCode	= this.LargeGoodsGanreCode_Grp_tEdit.Text.Trim();
                rate.MediumGoodsGanreCode	= this.MediumGoodsGanreCode_Grp_tEdit.Text.Trim();
                rate.DetailGoodsGanreCode	= this.DetailGoodsGanreCode_Grp_tEdit.Text.Trim();
                rate.EnterpriseGanreCode	= NullChgInt(this.EnterpriseGanreCode_Grp_tComboEditor.Value);
                rate.BLGoodsCode			= this.BLGoodsCode_Grp_tNedit.GetInt();
            }

            rate.CustomerCode				= this.CustomerCode_tNedit.GetInt();
            rate.CustRateGrpCode			= NullChgInt(this.CustRateGrpCode_tComboEditor.Value);
            rate.SupplierCd					= this.SupplierCd_tNedit.GetInt();
            rate.SuppRateGrpCode			= NullChgInt(this.SuppRateGrpCode_tComboEditor.Value);
						
            //----------
            // ��������
            //----------
            // �V�|���ݒ�
            if (string.Equals(oldNewDivCd, OLDNEWDIVCD_NEW) == true)
            {
                rate.LotCount			= 0;
                rate.UnitPrcCalcDiv		= NullChgInt(this.NewUnPrcCalcDiv_tComboEditor.Value);
                rate.PriceDiv			= NullChgInt(this.NewPriceDiv_tComboEditor.Value);
                rate.PriceFl			= this.NewPrice_tNedit.GetValue();
                rate.RateVal			= this.NewRate_tNedit.GetValue();
                rate.UnPrcFracProcUnit	= this.NewUnPrcFracProcUnit_tNedit.GetValue();
                rate.UnPrcFracProcDiv	= NullChgInt(this.NewUnPrcFracProcDiv_tComboEditor.Value);
                rate.RateStartDate		= this.NewRateStartDate_tDateEdit.GetDateTime();
                rate.BargainCd			= NullChgInt(this.NewBargainCd_tComboEditor.Value);
            }
            // ���|���ݒ�
            else
            {
                rate.LotCount = 0;
                rate.UnitPrcCalcDiv		= NullChgInt(this.OldUnPrcCalcDiv_tComboEditor.Value);
                rate.PriceDiv			= NullChgInt(this.OldPriceDiv_tComboEditor.Value);
                rate.PriceFl			= this.OldPrice_tNedit.GetValue();
                rate.RateVal			= this.OldRate_tNedit.GetValue();
                rate.UnPrcFracProcUnit	= this.OldUnPrcFracProcUnit_tNedit.GetValue();
                rate.UnPrcFracProcDiv	= NullChgInt(this.OldUnPrcFracProcDiv_tComboEditor.Value);
                rate.RateStartDate		= this.OldRateStartDate_tDateEdit.GetDateTime();
                rate.BargainCd			= NullChgInt(this.OldBargainCd_tComboEditor.Value);
            }
        }

        /// <summary>
        /// �f�[�^���E�ˊ|���N���X�i�[����
        /// </summary>
        /// <param name="rate">�|���I�u�W�F�N�g</param>
        /// <param name="dr">�f�[�^���E</param>
        /// <remarks>
        /// <br>Note       : �|���f�[�^�e�[�u���̏����|���I�u�W�F�N�g�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.10.30</br>
        /// </remarks>
        private void CopyToRateFromRow(ref Rate rate, DataRow dr)
        {
            rate = new Rate();

            rate.CreateDateTime			= (DateTime)dr[RateAcs.CREATEDATETIME];
            rate.UpdateDateTime			= (DateTime)dr[RateAcs.UPDATEDATETIME];
            rate.EnterpriseCode			= NullChgStr(dr[RateAcs.ENTERPRISECODE]);
            rate.FileHeaderGuid			= (Guid)dr[RateAcs.FILEHEADERGUID];

            rate.LogicalDeleteCode		= NullChgInt(dr[RateAcs.LOGICALDELETECODE]);
            rate.SectionCode			= NullChgStr(dr[RateAcs.SECTIONCODE]);
            rate.UnitRateSetDivCd		= NullChgStr(dr[RateAcs.UNITRATESETDIVCD]).Trim();
            rate.OldNewDivCd			= NullChgStr(dr[RateAcs.OLDNEWDIVCD]).Trim();
            rate.UnitPriceKind			= NullChgStr(dr[RateAcs.UNITPRICEKIND]).Trim();
            rate.RateSettingDivide		= NullChgStr(dr[RateAcs.RATESETTINGDIVIDE]).Trim();
            rate.RateMngGoodsCd			= NullChgStr(dr[RateAcs.RATEMNGGOODSCD]).Trim();
            rate.RateMngGoodsNm			= NullChgStr(dr[RateAcs.RATEMNGGOODSNM]).Trim();
            rate.RateMngCustCd			= NullChgStr(dr[RateAcs.RATEMNGCUSTCD]).Trim();
            rate.RateMngCustNm			= NullChgStr(dr[RateAcs.RATEMNGCUSTNM]).Trim();
            rate.GoodsMakerCd			= NullChgInt(dr[RateAcs.GOODSMAKERCD]);
            rate.GoodsNo				= NullChgStr(dr[RateAcs.GOODSNO]).Trim();
            rate.GoodsRateRank			= NullChgStr(dr[RateAcs.GOODSRATERANK]).Trim();
            rate.LargeGoodsGanreCode	= NullChgStr(dr[RateAcs.LARGEGOODSGANRECODE]).Trim();
            rate.MediumGoodsGanreCode	= NullChgStr(dr[RateAcs.MEDIUMGOODSGANRECODE]).Trim();
            rate.DetailGoodsGanreCode	= NullChgStr(dr[RateAcs.DETAILGOODSGANRECODE]).Trim();
            rate.EnterpriseGanreCode	= NullChgInt(dr[RateAcs.ENTERPRISEGANRECODE]);
            rate.BLGoodsCode			= NullChgInt(dr[RateAcs.BLGOODSCODE]);
            rate.CustomerCode			= NullChgInt(dr[RateAcs.CUSTOMERCODE]);
            rate.CustRateGrpCode		= NullChgInt(dr[RateAcs.CUSTRATEGRPCODE]);
            rate.SupplierCd				= NullChgInt(dr[RateAcs.SUPPLIERCD]);
            rate.SuppRateGrpCode		= NullChgInt(dr[RateAcs.SUPPRATEGRPCODE]);
            rate.LotCount				= NullChgDbl(dr[RateAcs.LOTCOUNT]);
            rate.UnitPrcCalcDiv			= NullChgInt(dr[RateAcs.UNITPRCCALCDIV]);
            rate.PriceDiv				= NullChgInt(dr[RateAcs.PRICEDIV]);
            rate.PriceFl				= NullChgDbl(dr[RateAcs.PRICEFL]);
            rate.RateVal				= NullChgDbl(dr[RateAcs.RATEVAL]);
            rate.UnPrcFracProcUnit		= NullChgDbl(dr[RateAcs.UNPRCFRACPROCUNIT]);
            rate.UnPrcFracProcDiv		= NullChgInt(dr[RateAcs.UNPRCFRACPROCDIV]);
            rate.RateStartDate			= (DateTime)dr[RateAcs.RATESTARTDATE];
            rate.BargainCd				= NullChgInt(dr[RateAcs.BARGAINCD]);
        }
		
        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <param name="oldSaveFlag">���|���f�[�^�ݒ�L���i0:�ݒ薳��, 1:�ݒ�L��j</param>
        /// <returns>�o�^���ʁitrue:OK�^false:NG�j</returns>
        /// <remarks>
        /// <br>Note		: ��ʏ��̕ۑ��������s���܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        private bool SaveProc(ref int oldSaveFlag)
        {
            string message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList rateList = new ArrayList();
            Rate rate = null;
            ArrayList diffList = null;	// ���ڔ�r�p
			
            //--------------------
            // �V���|���f�[�^�ݒ�
            //--------------------
            foreach (DictionaryEntry de in Rate._OldNewDivCdTable)
            {
                // �������݃f�[�^�ݒ�i0:�V, 1:���j
                DispToRate(out rate, NullChgStr(de.Value));

                // �����L�[�ݒ�
                string hashKey = de.Value.ToString() + "000000000.00";

                //-------------------------------------------------------------
                // �V�K�f�[�^�̏ꍇ�i�������ʃ��X�g�N���[�����ݒ薳���̏ꍇ�j�j
                //     ���ڔ�r����, ���b�g�f�[�^�X�V����, �o�^�̂�
                //-------------------------------------------------------------
                if (this._rateSrchRsltHashListClone.ContainsKey(hashKey) == false)
                {
                    // �V�|���A�܂��́A���|���ŕۑ��f�[�^�L��̏ꍇ
                    if ((NullChgInt(de.Key) == 0)||((NullChgInt(de.Key) == 1)&&(oldSaveFlag == 1)))
                    {
                        rateList.Add(rate);
                    }
                }
                //--------------------------------------------------
                // �X�V�f�[�^�̏ꍇ
                //     ���ڔ�r�L��, ���b�g�f�[�^�X�V�L��, �o�^�L��
                //--------------------------------------------------
                else
                {
                    // ���ڔ�r
                    diffList = null;
					
                    // ��������
                    Rate rateWkClone = (Rate)this._rateSrchRsltHashListClone[hashKey];

                    diffList = rate.Compare(rateWkClone);
					
                    // ���ڕύX�L��
                    if (diffList.Count > 0)
                    {
                        // �V�|���A�܂��́A���|���ŕۑ��f�[�^�L��̏ꍇ
                        if ((NullChgInt(de.Key) == 0) || ((NullChgInt(de.Key) == 1) && (oldSaveFlag == 1)))
                        {
                            // �|���f�[�^�ݒ�
                            rateList.Add(rate);

                            // �|���J�n�����ύX����Ă���ꍇ
                            if (diffList.Contains("RateStartDate") == true)
                            {
                                foreach (DataRow dr in this._dataTableRate.Rows)
                                {
                                    if ((NullChgDbl(dr[RateAcs.LOTCOUNT]) > 1)
                                        && (string.Equals(NullChgStr(dr[RateAcs.OLDNEWDIVCD]), de.Value.ToString()) == true))
                                    {
                                        // ���b�g�f�[�^�X�V
                                        CopyToRateFromRow(ref rate, dr);
										
                                        // ���b�g�|���J�n���X�V
                                        // �V�|���ݒ�
                                        if (string.Equals(NullChgStr(de.Value), OLDNEWDIVCD_NEW) == true)
                                        {
                                            rate.RateStartDate = this.NewRateStartDate_tDateEdit.GetDateTime();
                                        }
                                        // ���|���ݒ�
                                        else
                                        {
                                            rate.RateStartDate = this.OldRateStartDate_tDateEdit.GetDateTime();
                                        }
                                        rateList.Add(rate);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // ��������
            if ((this._modeFlag == ModeFlag.New)||(this._modeFlag == ModeFlag.Update))
            {
                if (rateList.Count > 0)
                {
                    status = this._rateAcs.Write(ref rateList, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        emErrorLevel emErrLvl = emErrorLevel.ERR_LEVEL_INFO;
                        if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                        {
                            emErrLvl = emErrorLevel.ERR_LEVEL_STOP;
                        }
                        TMsgDisp.Show(this,                                 // �e�E�B���h�E�t�H�[��
                                       emErrLvl,                            // �G���[���x��
                                       ASSEMBLY_ID,                         // �A�Z���u���h�c�܂��̓N���X�h�c
                                       this.Text, 						    // �v���O��������
                                       "SaveProc", 							// ��������
                                       TMsgDisp.OPE_UPDATE, 				// �I�y���[�V����
                                       message,                             // �\�����郁�b�Z�[�W
                                       status,  							// �X�e�[�^�X�l
                                       this._rateAcs,			            // �G���[�����������I�u�W�F�N�g
                                       MessageBoxButtons.OK,                // �\������{�^��
                                       MessageBoxDefaultButton.Button1);	// �����I���{�^��
                        return false;
                    }
					
                    // �ۑ����b�Z�[�W
                    //----- ueno upd ---------- start 2008.02.07
                    //TMsgDisp.Show(this,							// �e�E�B���h�E�t�H�[��
                    //    emErrorLevel.ERR_LEVEL_INFO,			// �G���[���x��
                    //    ASSEMBLY_ID,							// �A�Z���u��ID
                    //    SAV_INFO_MSG,							// �\�����郁�b�Z�[�W
                    //    0,										// �X�e�[�^�X�l
                    //    MessageBoxButtons.OK);					// �\������{�^��

                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);
                    //----- ueno upd ---------- end 2008.02.07
					
                    // �ēǂݍ���
                    RateSearch();
                }
            }
            return true;
        }
		
        /// <summary>
        /// �|���}�X�^�ݒ� �_���폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�ݒ�Ώۃ��R�[�h���}�X�^����_���폜���܂��B
        ///					 �V���|���y�сA�R�����b�g�S�Ă�_���폜���܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        private int LogicalDeleteRate()
        {
            string message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			
            ArrayList rateList = new ArrayList();
            Rate rate = null;
			
            // �����{�^���������ɓǂݍ��񂾃f�[�^��S�Đݒ�
            foreach(DataRow dr in this._dataTableRate.Rows)
            {
                // �_���폜�t���O��0�̃f�[�^
                if (NullChgInt(dr[RateAcs.LOGICALDELETECODE]) == 0)
                {
                    CopyToRateFromRow(ref rate, dr);
                    rateList.Add(rate);
                }
            }

            // �_���폜
            status = this._rateAcs.LogicalDelete(ref rateList, out message);
			
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ēǂݍ���
                        RateSearch();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,						// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,		// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u��ID
                            this.Text,							// �v���O��������
                            "LogicalDeleteRate",				// ��������
                            TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                            ERR_LRDEL_MSG,					    // �\�����郁�b�Z�[�W
                            status,								// �X�e�[�^�X�l
                            this._rateAcs,						// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// �|���}�X�^�ݒ� �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�ݒ�Ώۃ��R�[�h���}�X�^���畨���폜���܂��B
        ///					 �V���|���y�сA�R�����b�g�S�Ă𕨗��폜���܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        private int PhysicalDeleteRate()
        {
            string message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList rateList = new ArrayList();
            Rate rate = null;

            // �����{�^���������ɓǂݍ��񂾃f�[�^��S�Đݒ�
            foreach (DataRow dr in this._dataTableRate.Rows)
            {
                // �_���폜�t���O��1�̃f�[�^
                if(NullChgInt(dr[RateAcs.LOGICALDELETECODE]) == 1)
                {
                    CopyToRateFromRow(ref rate, dr);
                    rateList.Add(rate);
                }
            }
			
            // �����폜
            status = this._rateAcs.Delete(ref rateList, out message);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �������̃f�[�^�e�[�u�����R�[�h�폜
                        this._dataTableRate.Rows.Clear();
						
                        // �������ʊi�[�n�b�V���e�[�u�����R�[�h�폜
                        this._rateSrchRsltHashList.Clear();

                        // �������ʃf�[�^�N���A�i�O��̕����l���j
                        SrchRsltDataClear();
						
                        // �|���}�X�^�����p�f�[�^�i�[
                        DispToRateSearch();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,						// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,		// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u��ID
                            this.Text,							// �v���O��������
                            "PhysicalDeleteRate",				// ��������
                            TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                            ERR_PRDEL_MSG,					    // �\�����郁�b�Z�[�W
                            status,								// �X�e�[�^�X�l
                            this._rateAcs,						// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// ���|���}�X�^�ݒ� �����폜����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���|���}�X�^�ݒ�Ώۃ��R�[�h���}�X�^���畨���폜���܂��B
        ///					 ���|���y�сA�R�����b�g�S�Ă𕨗��폜���܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.11.05</br>
        /// </remarks>
        private int PhysicalDeleteOldRate()
        {
            string message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList rateList = new ArrayList();
            Rate rate = null;
			
            // ���|���֘A�f�[�^��S�Ď擾
            string searchStr = "";
            _stringBuilder.Remove(0, _stringBuilder.Length);
            _stringBuilder.Append(RateAcs.OLDNEWDIVCD);
            _stringBuilder.Append(" = '1'");
            searchStr = _stringBuilder.ToString();
			
            DataRow[] foundRateRow = this._dataTableRate.Select(searchStr);
			
            // ���|���f�[�^�ݒ�
            foreach (DataRow fRow in foundRateRow)
            {
                CopyToRateFromRow(ref rate, fRow);
                rateList.Add(rate);
            }
			
            // �����폜
            status = this._rateAcs.Delete(ref rateList, out message);
			
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        //----- ueno add ---------- start 2008.02.07
                        // �����폜���b�Z�[�W
                        TMsgDisp.Show(this,							// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_INFO,			// �G���[���x��
                            ASSEMBLY_ID,							// �A�Z���u��ID
                            PHY_OLDDEL_INFO_MSG,					// �\�����郁�b�Z�[�W
                            0,										// �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��
                        //----- ueno add ---------- end 2008.02.07

                        // �������̃f�[�^�e�[�u�����R�[�h�폜
                        this._dataTableRate.Rows.Clear();
						
                        // �������ʊi�[�n�b�V���e�[�u�����R�[�h�폜
                        this._rateSrchRsltHashList.Clear();
						
                        // �ēǂݍ���
                        RateSearch();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,						// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,		// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u��ID
                            this.Text,							// �v���O��������
                            "PhysicalDeleteRate",				// ��������
                            TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                            ERR_PRDEL_MSG,					    // �\�����郁�b�Z�[�W
                            status,								// �X�e�[�^�X�l
                            this._rateAcs,						// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// �|���}�X�^�ݒ� ��������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�ݒ�Ώۃ��R�[�h���}�X�^���畜�����܂��B
        ///					 �V���|���y�сA�R�����b�g�S�Ă𕜊����܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        private int ReviveRate()
        {
            string message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList rateList = new ArrayList();
            Rate rate = null;

            // �����{�^���������ɓǂݍ��񂾃f�[�^��S�Đݒ�
            foreach (DataRow dr in this._dataTableRate.Rows)
            {
                // �_���폜�t���O��1�̃f�[�^
                if (NullChgInt(dr[RateAcs.LOGICALDELETECODE]) == 1)
                {
                    CopyToRateFromRow(ref rate, dr);
                    rateList.Add(rate);
                }
            }

            // ����
            status = this._rateAcs.Revival(ref rateList, out message);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // �ēǂݍ���
                        RateSearch();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // �r������
                        ExclusiveTransaction(status);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,						// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,		// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u��ID
                            this.Text,							// �v���O��������
                            "ReviveRate",						// ��������
                            TMsgDisp.OPE_HIDE,					// �I�y���[�V����
                            ERR_RVV_MSG,					    // �\�����郁�b�Z�[�W
                            status,								// �X�e�[�^�X�l
                            this._rateAcs,						// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        break;
                    }
            }
            return status;
        }
		
        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�X�V���̔r���������s���܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(this,							// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,		// �G���[���x��
                            ASSEMBLY_ID,							// �A�Z���u��ID
                            ERR_800_MSG,							// �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(this,							// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,		// �G���[���x��
                            ASSEMBLY_ID,							// �A�Z���u��ID
                            ERR_801_MSG,							// �\�����郁�b�Z�[�W
                            status,									// �X�e�[�^�X�l
                            MessageBoxButtons.OK);					// �\������{�^��

                        break;
                    }
            }
        }
		
        /// <summary>
        /// �G�f�B�b�g���ڃf�[�^�ύX�`�F�b�N
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="editText">���ڃI�u�W�F�N�g</param>
        /// <param name="preObj">�O�񍀖ڕ�����</param>
        /// <returns>�`�F�b�N���ʁi0:�ύX����, 1:���݂��Ȃ�, 2:�ύX�L��j</returns>
        /// <remarks>
        /// <br>Note		: ��ʍ��ڃe�L�X�g�̃f�[�^�ύX�`�F�b�N���s���܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2007.11.02</br>
        /// </remarks>
        private DispSetStatus editChgDataChk(string errMsg, object editText, object preObj)
        {
            DispSetStatus inputChkRet = DispSetStatus.Clear;

            // ������̏ꍇ
            if ((this._AllCtrlInputStatus == AllCtrlInputStatus.SearchDelete)
                || (this._AllCtrlInputStatus == AllCtrlInputStatus.SearchNew)
                || (this._AllCtrlInputStatus == AllCtrlInputStatus.SearchUpdate))
            {
                _stringBuilder.Remove(0, _stringBuilder.Length);
                _stringBuilder.Append(errMsg);
                _stringBuilder.Append(DISP_CHG_MSG);	// �ύX���������m�F
                errMsg = _stringBuilder.ToString();

                // �m�F���b�Z�[�W�o��
                if (ShowConfirmMsg(errMsg, emErrorLevel.ERR_LEVEL_INFO) == true)
                {
                    // ���͗L���ŕԋp�l�ύX
                    if (editText is string)
                    {
                        inputChkRet = (string)editText == "" ? DispSetStatus.Clear : DispSetStatus.Update;
                    }
                    else if (editText is int)
                    {
                        inputChkRet = (int)editText == 0 ? DispSetStatus.Clear : DispSetStatus.Update;
                    }
					
                    // �|���������̓G���[�`�F�b�N
                    InpRateCondCheck();
                    SrchRsltDataClear();
                }
                else
                {
                    // �f�[�^������Ζ߂�
                    inputChkRet = preObj == null ? DispSetStatus.Clear : DispSetStatus.Back;
                }
            }
            // �����O�̏ꍇ
            else
            {
                // ���͗L���ŕԋp�l�ύX
                if (editText is string)
                {
                    inputChkRet = (string)editText == "" ? DispSetStatus.Clear : DispSetStatus.Update;
                }
                else if (editText is int)
                {
                    inputChkRet = (int)editText == 0 ? DispSetStatus.Clear : DispSetStatus.Update;
                }
            }
            return inputChkRet;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�|���ۑ��ݒ�N���X�ˌ������ʃN���X�j
        /// </summary>
        /// <param name="srchRsltRate">�������ʊ|���N���X</param>
        /// <param name="svRate">�|���ۑ��N���X</param>
        /// <remarks>
        /// <br>Note       : �|���ۑ��ݒ�N���X���猟�����ʃN���X�փ����o�[�ւ̐ݒ���s���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.24</br>
        /// </remarks>
        private void CopyToSrchRsltRateFromSvRate(ref Rate srchRsltRate, Rate svRate)
        {
            // �쐬����
            srchRsltRate.CreateDateTime			= svRate.CreateDateTime;
            // �X�V����
            srchRsltRate.UpdateDateTime			= svRate.UpdateDateTime;
            // ��ƃR�[�h
            srchRsltRate.EnterpriseCode			= svRate.EnterpriseCode;
            // GUID
            srchRsltRate.FileHeaderGuid			= svRate.FileHeaderGuid;
            // �X�V�]�ƈ��R�[�h
            srchRsltRate.UpdEmployeeCode		= svRate.UpdEmployeeCode;
            // �X�V�A�Z���u��ID1
            srchRsltRate.UpdAssemblyId1			= svRate.UpdAssemblyId1;
            // �X�V�A�Z���u��ID2
            srchRsltRate.UpdAssemblyId2			= svRate.UpdAssemblyId2;
            // �_���폜�敪
            srchRsltRate.LogicalDeleteCode		= svRate.LogicalDeleteCode;
            // ���_�R�[�h
            srchRsltRate.SectionCode			= svRate.SectionCode;
            // �P���|���ݒ�敪
            srchRsltRate.UnitRateSetDivCd		= svRate.UnitRateSetDivCd;
            // �V���敪
            srchRsltRate.OldNewDivCd			= svRate.OldNewDivCd;
            // �P�����
            srchRsltRate.UnitPriceKind			= svRate.UnitPriceKind;
            // �|���ݒ�敪
            srchRsltRate.RateSettingDivide		= svRate.RateSettingDivide;
            // �|���ݒ�敪�i���i�j
            srchRsltRate.RateMngGoodsCd			= svRate.RateMngGoodsCd;
            // �|���ݒ薼�́i���i�j
            srchRsltRate.RateMngGoodsNm			= svRate.RateMngGoodsNm;
            // �|���ݒ�敪�i���Ӑ�j
            srchRsltRate.RateMngCustCd			= svRate.RateMngCustCd;
            // �|���ݒ薼�́i���Ӑ�j
            srchRsltRate.RateMngCustNm			= svRate.RateMngCustNm;
            // ���i���[�J�[�R�[�h
            srchRsltRate.GoodsMakerCd			= svRate.GoodsMakerCd;
            // ���i�ԍ�
            srchRsltRate.GoodsNo				= svRate.GoodsNo;
            // ���i�|�������N
            srchRsltRate.GoodsRateRank			= svRate.GoodsRateRank;
            // ���i�敪�O���[�v�R�[�h
            srchRsltRate.LargeGoodsGanreCode	= svRate.LargeGoodsGanreCode;
            // ���i�敪�R�[�h
            srchRsltRate.MediumGoodsGanreCode	= svRate.MediumGoodsGanreCode;
            // ���i�敪�ڍ׃R�[�h
            srchRsltRate.DetailGoodsGanreCode	= svRate.DetailGoodsGanreCode;
            // ���Е��ރR�[�h
            srchRsltRate.EnterpriseGanreCode	= svRate.EnterpriseGanreCode;
            // BL���i�R�[�h
            srchRsltRate.BLGoodsCode			= svRate.BLGoodsCode;
            // ���Ӑ�R�[�h
            srchRsltRate.CustomerCode			= svRate.CustomerCode;
            // ���Ӑ�|���O���[�v�R�[�h
            srchRsltRate.CustRateGrpCode		= svRate.CustRateGrpCode;
            // �d����R�[�h
            srchRsltRate.SupplierCd				= svRate.SupplierCd;
            // �d����|���O���[�v�R�[�h
            srchRsltRate.SuppRateGrpCode		= svRate.SuppRateGrpCode;
            // ���b�g��
            srchRsltRate.LotCount				= svRate.LotCount;
            // �P���Z�o�敪
            srchRsltRate.UnitPrcCalcDiv			= svRate.UnitPrcCalcDiv;
            // ���i�敪
            srchRsltRate.PriceDiv				= svRate.PriceDiv;
            // ���i
            srchRsltRate.PriceFl				= svRate.PriceFl;
            // �|��
            srchRsltRate.RateVal				= svRate.RateVal;
            // �P���[�������P��
            srchRsltRate.UnPrcFracProcUnit		= svRate.UnPrcFracProcUnit;
            // �P���[�������敪
            srchRsltRate.UnPrcFracProcDiv		= svRate.UnPrcFracProcDiv;
            // �|���J�n��
            srchRsltRate.RateStartDate			= svRate.RateStartDate;
            // �����敪�R�[�h
            srchRsltRate.BargainCd				= svRate.BargainCd;
            // �폜��
            srchRsltRate.LogicalDeleteCode		= svRate.LogicalDeleteCode;
        }

        /// <summary>
        /// �|���^�u��ʐ��䏈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|���^�u��ʂ̐�����s���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.11.05</br>
        /// </remarks>
        private void RateTabControl()
        {
            // �S�̓��̓R���g���[��
            SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.SearchUpdate.GetHashCode());
            this._AllCtrlInputStatus = AllCtrlInputStatus.SearchUpdate;
        }
		
        /// <summary>
        /// ���b�g�^�u��ʐ��䏈��
        /// </summary>
        /// <param name="lotOldNewRate">���b�g��ʊ|���J�n�{�^���e�L�X�g</param>
        /// <remarks>
        /// <br>Note       : ���b�g�^�u��ʂ̐�����s���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.11.05</br>
        /// </remarks>
        private void RateLotTabControl(string lotOldNewRate)
        {
            // �S�̓��̓R���g���[��
            SettingAllInpCtrl(AllCtrlActiveTab.Lot.GetHashCode(), AllCtrlInputStatus.New.GetHashCode());
            this._AllCtrlInputStatus = AllCtrlInputStatus.New;

            // ���b�g��ʊ|���J�n���{�^�������ݒ�
            this.LotOldNewRateStartDate_uButton.Text = lotOldNewRate;
			
            // ���b�g��ʊ|���J�n���{�^������i���b�g��0�ȊO�ŋ��|�����Ȃ���΃{�^�������s�j
            string searchStr = "";
            _stringBuilder.Remove(0, _stringBuilder.Length);
            _stringBuilder.Append(RateAcs.OLDNEWDIVCD);
            _stringBuilder.Append(" = '1'");
            searchStr = _stringBuilder.ToString();

            DataRow[] foundRateRow = this._dataTableRate.Select(searchStr);

            if (foundRateRow.Length == 0)
            {
                this.LotOldNewRateStartDate_uButton.Enabled = false;
            }
            else
            {
                this.LotOldNewRateStartDate_uButton.Enabled = true;
            }
			
            // �������ʐݒ�
            OldNewRateChange(true);
			
            // ���b�g�P���\���ݒ�
            if (NullChgInt(this.UnitPriceKindWay_tComboEditor.Value) == 0)
            {
                // �P�i�ݒ�Ȃ̂ŒP���ݒ��
                this.rateLotNew_ultraGrid.DisplayLayout.Bands[0].Columns[LOT_PRICEFL].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            }
            else
            {
                // �O���[�v�ݒ�Ȃ̂ŒP���ݒ�s��
                this.rateLotNew_ultraGrid.DisplayLayout.Bands[0].Columns[LOT_PRICEFL].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
			
            // �P���Z�o�敪����
            if(NullChgInt(this.UnitPriceKind_tComboEditor.Value) == 1)
            {
                this.rateLotNew_ultraGrid.DisplayLayout.Bands[0].Columns[LOT_UNITPRCCALCDIV].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            }
            else
            {
                this.rateLotNew_ultraGrid.DisplayLayout.Bands[0].Columns[LOT_UNITPRCCALCDIV].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
			
            // ���b�g�����A�N�e�B�u��
            if (this.rateLotNew_ultraGrid.Rows.Count > 0)
            {
                this.rateLotNew_ultraGrid.Rows[0].Cells[LOT_LOTCOUNT].Activate();
            }
        }

        /// <summary>
        /// �|���ݒ�ύX�`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N���ʁitrue:�ύX�L��, false:�ύX�����j</returns>
        /// <remarks>
        /// <br>Note       : �|���ݒ�ɕύX�_�L�����`�F�b�N���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.09</br>
        /// </remarks>
        private bool CompareRateChange()
        {
            ArrayList rateList = new ArrayList();
            Rate rate = null;
            ArrayList diffList = null;	// ���ڔ�r�p

            bool chgFlag = false;

            //--------------------
            // �V���|���f�[�^�ݒ�
            //--------------------
            foreach (DictionaryEntry de in Rate._OldNewDivCdTable)
            {
                // �������݃f�[�^�ݒ�i0:�V, 1:���j
                DispToRate(out rate, NullChgStr(de.Value));

                // �����L�[�ݒ�
                string hashKey = de.Value.ToString() + "000000000.00";

                //-------------------------------------------------------------
                // �V�K�f�[�^�̏ꍇ�i�������ʃ��X�g�N���[�����ݒ薳���̏ꍇ�j�j
                //     ���ڔ�r����, ���b�g�f�[�^�X�V����, �o�^�̂�
                //-------------------------------------------------------------
                if (this._rateSrchRsltHashListClone.ContainsKey(hashKey) == false)
                {
                    //--- �V�|���ݒ�`�F�b�N ---//
                    if (string.Equals(NullChgStr(de.Value), OLDNEWDIVCD_NEW) == true)
                    {
                        // ���ݒ�̏ꍇ�i�P�� == 0, �|�� == 0, �[�������P�� == 0�j
                        if ((this.NewPrice_tNedit.GetValue() == 0)
                            && (this.NewRate_tNedit.GetValue() == 0)
                            && (this.NewUnPrcFracProcUnit_tNedit.GetValue() == 0))
                        {
                            // �������Ȃ�
                        }
                        else
                        {
                            // �ύX�L��
                            chgFlag = true;
                            break;
                        }
                    }
                    else
                    {
                        // ���ݒ�̏ꍇ�i�P�� == 0, �|�� == 0, �[�������P�� == 0�j
                        if ((this.OldPrice_tNedit.GetValue() == 0)
                            && (this.OldRate_tNedit.GetValue() == 0)
                            && (this.OldUnPrcFracProcUnit_tNedit.GetValue() == 0))
                        {
                            // �������Ȃ�
                        }
                        else
                        {
                            // �ύX�L��
                            chgFlag = true;
                            break;
                        }
                    }
                }
                //--------------------------------------------------
                // �X�V�f�[�^�̏ꍇ
                //     ���ڔ�r�L��, ���b�g�f�[�^�X�V�L��, �o�^�L��
                //--------------------------------------------------
                else
                {
                    // ���ڔ�r
                    diffList = null;

                    // ��������
                    Rate rateWkClone = (Rate)this._rateSrchRsltHashListClone[hashKey];

                    diffList = rate.Compare(rateWkClone);

                    // ���ڕύX�L��
                    if (diffList.Count > 0)
                    {
                        // �ύX�L��
                        chgFlag = true;
                        break;
                    }
                }
            }
            return chgFlag;
        }

        #region ���e��G���[�`�F�b�N������

        #region ���_�R�[�h�G���[�`�F�b�N����
        /// <summary>
        /// ���_�R�[�h�G���[�`�F�b�N����
        /// </summary>
        /// <param name="inParamObj">�����I�u�W�F�N�g</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note       : ���_�R�[�h�̃G���[�`�F�b�N���s���܂��B
        ///					 �����I�u�W�F�N�g:���_�R�[�h
        ///					 ���ʃI�u�W�F�N�g:���_�}�X�^�������ʃX�e�[�^�X, ���_����</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private int CheckSectionCode(object inParamObj, out object outParamObj)
        {
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			
            try
            {
                //------------------
                // �K�{���̓`�F�b�N
                //------------------
                if (inParamObj == null)					return ret;
                if ((inParamObj is string) == false)	return ret;
                if ((string)inParamObj == "")			return ret;
				
                //--------------
                // ���݃`�F�b�N
                //--------------
                SecInfoSet secInfoSet = null;

                // �S��
                if (string.Equals((string)inParamObj, "000000") == true)
                {
                    secInfoSet = new SecInfoSet();

                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(0);			// �|���}�X�^�X�e�[�^�X�ݒ�
                    outParamList.Add(COMMON_MODE);	// ���_���̐ݒ�
                }
                // �e���_
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, (string)inParamObj);
                    this.Cursor = Cursors.Default;

                    outParamList.Add(status);	// �|���}�X�^�X�e�[�^�X�ݒ�
					
                    if (secInfoSet == null)
                    {
                        ret = (int)InputChkStatus.NotExist;
                    }
                    else
                    {
                        ret = (int)InputChkStatus.Normal;
                        outParamList.Add(secInfoSet.SectionGuideNm);	// ���_���̐ݒ�
                    }
                }
            }
            catch(Exception)
            {
            }
            outParamObj = outParamList;
			
            return ret;
        }
        #endregion ���_�R�[�h�G���[�`�F�b�N����

        #region �|���ݒ�敪�R�[�h�G���[�`�F�b�N����
        /// <summary>
        /// �|���ݒ�敪�R�[�h�G���[�`�F�b�N����
        /// </summary>
        /// <param name="inParamObj">�����I�u�W�F�N�g</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note       : �|���ݒ�敪�R�[�h�̃G���[�`�F�b�N���s���܂��B
        ///					 �����I�u�W�F�N�g:���_�R�[�h, �P�����, �ݒ���@, �|���ݒ�敪
        ///					 ���ʃI�u�W�F�N�g:�|���}�X�^�������ʃX�e�[�^�X,
        ///									  �|���ݒ�敪�R�[�h�i���i�j, �|���ݒ�敪���́i���i�j, �|���ݒ�敪�R�[�h�i���Ӑ�j, �|���ݒ�敪���́i���Ӑ�j</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private int CheckRateSettingDivide(object inParamObj, out object outParamObj)
        {
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			
            ArrayList inParamList = null;
			
            try
            {
                //------------------
                // �K�{���̓`�F�b�N
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is ArrayList) == false)					return ret;
				
                inParamList = inParamObj as ArrayList;	// ArrayList�փL���X�g
				
                if ((inParamList == null)||(inParamList.Count != 4))	return ret;
                if ((inParamList[0] is string) == false)				return ret;
                if ((inParamList[1] is int) == false)					return ret;
                if ((inParamList[2] is int) == false)					return ret;
                if ((inParamList[3] is string) == false)				return ret;
                if ((string)inParamList[3] == "")						return ret;
				
                //--------------
                // ���݃`�F�b�N
                //--------------
                RateProtyMng rateProtyMng = null;
				
                this.Cursor = Cursors.WaitCursor;
                status = this._rateProtyMngAcs.Read(out rateProtyMng, this._enterpriseCode,
                                                (string)inParamList[0], (int)inParamList[1], (int)inParamList[2], (string)inParamList[3]);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// �|���D��Ǘ��}�X�^�X�e�[�^�X�ݒ�

                if (rateProtyMng == null)
                {
                    ret = (int)InputChkStatus.NotExist;
                }
                else
                {
                    ret = (int)InputChkStatus.Normal;

                    outParamList.Add(rateProtyMng.RateMngGoodsCd.Trim());	// �|���ݒ�敪�R�[�h�i���i�j�ݒ�
                    outParamList.Add(rateProtyMng.RateMngGoodsNm.Trim());	// �|���ݒ�敪���́i���i�j�ݒ�
                    outParamList.Add(rateProtyMng.RateMngCustCd.Trim());	// �|���ݒ�敪�R�[�h�i���Ӑ�j�ݒ�
                    outParamList.Add(rateProtyMng.RateMngCustNm.Trim());	// �|���ݒ�敪���́i���Ӑ�j�ݒ�
                }
            }
            catch(Exception)
            {
            }
            outParamObj = outParamList;
			
            return ret;
        }
        #endregion �|���ݒ�敪�R�[�h�G���[�`�F�b�N����

        #region ���i�R�[�h�G���[�`�F�b�N����
        /// <summary>
        /// ���i�R�[�h�G���[�`�F�b�N����
        /// </summary>
        /// <param name="inParamObj">�����I�u�W�F�N�g</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note       : ���i�R�[�h�̃G���[�`�F�b�N���s���܂��B
        ///					 �����I�u�W�F�N�g:���[�J�[�R�[�h, ���i�R�[�h
        ///					 ���ʃI�u�W�F�N�g:���i�}�X�^�������ʃX�e�[�^�X, ���i�R�[�h, ���i����, ���[�J�[�R�[�h, ���[�J�[����</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private int CheckGoodsNoCd(object inParamObj, out object outParamObj)
        {
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList inParamList = null;
			
            try
            {
                //------------------
                // �K�{���̓`�F�b�N
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is ArrayList) == false)					return ret;
				
                inParamList = inParamObj as ArrayList;	// ArrayList�փL���X�g
				
                if ((inParamList == null)||(inParamList.Count != 2))	return ret;
                if ((inParamList[0] is int) == false)					return ret;
                if ((inParamList[1] is string) == false)				return ret;
                if ((string)inParamList[1] == "")						return ret;
				
                //--------------
                // ���݃`�F�b�N
                //--------------
                List<GoodsUnitData> goodsUnitDataList = null;
				
                // �����̎�ނ��擾
                string searchCode;
                int searchType = GetSearchType((string)inParamList[1], out searchCode);

                //----- ueno add ---------- start 2008.03.05
                MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

                GoodsCndtn goodsCndtn = new GoodsCndtn();

                // ���i���������ݒ�
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.SectionCode = this.RateSectionCode_tEdit.Text;
                goodsCndtn.GoodsMakerCd = this.GoodsMakerCd_tNedit.GetInt();
                goodsCndtn.MakerName = this.GoodsMakerCdNm_tEdit.Text;
                goodsCndtn.GoodsNo = searchCode.TrimEnd();
                goodsCndtn.GoodsNoSrchTyp = searchType;

                string message;
                this.Cursor = Cursors.WaitCursor;
                // �ǂݍ���
                status = goodsSelectGuide.ReadGoods(this, false, goodsCndtn, out goodsUnitDataList, out message);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// ���i�}�X�^�X�e�[�^�X�ݒ�

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                {
                    // ���i�}�X�^�f�[�^�N���X
                    GoodsUnitData goodsUnitData = new GoodsUnitData();
                    goodsUnitData = goodsUnitDataList[0];

                    outParamList.Add(goodsUnitData.GoodsNo);		// ���i�R�[�h
                    outParamList.Add(goodsUnitData.GoodsName);		// ���i���̐ݒ�
                    outParamList.Add(goodsUnitData.GoodsMakerCd);	// ���[�J�[�R�[�h�ݒ�
                    outParamList.Add(goodsUnitData.MakerName);		// ���[�J�[���̐ݒ�

                    ret = (int)InputChkStatus.Normal;
                }
                else if (status == -1)
                {
                    // �I���_�C�A���O�ŃL�����Z��
                    ret = (int)InputChkStatus.Cancel;
                }
                else
                {
                    ret = (int)InputChkStatus.NotExist;
                }
                //----- ueno add ---------- end 2008.03.05

                //----- ueno del ---------- start 2008.03.05
                //// �ʏ팟��
                //if (searchType == 0)
                //{
                //    // �f�[�^���݃`�F�b�N
                //    this.Cursor = Cursors.WaitCursor;
                //    status = this._goodsAcs.Read(this._enterpriseCode, searchCode, out goodsUnitDataList);
                //    this.Cursor = Cursors.Default;
                //}
                //// �B������
                //else
                //{
                //    MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

                //    //----- ueno add ---------- start 2008.03.04
                //    GoodsCndtn goodsCndtn = new GoodsCndtn();
					
                //    // ���i���������ݒ�
                //    goodsCndtn.EnterpriseCode = this._enterpriseCode;
                //    goodsCndtn.SectionCode = this.SectionCode_tEdit.Text;
                //    goodsCndtn.GoodsMakerCd = this.GoodsMakerCd_tNedit.GetInt();
                //    goodsCndtn.MakerName = this.GoodsMakerCdNm_tEdit.Text;
                //    goodsCndtn.GoodsNo = searchCode.TrimEnd();
                //    goodsCndtn.GoodsNoSrchTyp = searchType;
                //    //----- ueno add ---------- end 2008.03.04

                //    string message;
                //    this.Cursor = Cursors.WaitCursor;
                //    //----- ueno upd ---------- start 2008.03.04
                //    // �B�����i����
                //    status = goodsSelectGuide.ReadGoods(this, false, goodsCndtn, out goodsUnitDataList, out message);
                //    //status = goodsSelectGuide.ReadGoods(this, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
                //    //----- ueno upd ---------- end 2008.03.04
                //    this.Cursor = Cursors.Default;

                //    //----- ueno add ---------- start 2008.03.04
                //    // �B���������ʔ���
                //    if(status == -1)
                //    {
                //        status = 0;
						
                //        // �I���L�����Z���͐���Ƃ݂Ȃ�
                //        outParamList.Add(0);	// ���i�}�X�^�X�e�[�^�X�ݒ�
                //        outParamObj = outParamList;
						
                //        return (int)InputChkStatus.Cancel;
                //    }
                //    //----- ueno add ---------- end 2008.03.04
                //}

                //outParamList.Add(status);	// ���i�}�X�^�X�e�[�^�X�ݒ�
				
                //if ((goodsUnitDataList == null)||(goodsUnitDataList.Count == 0))
                //{
                //    ret = (int)InputChkStatus.NotExist;
                //}
                //else
                //{
                //    // ���ڃR�[�h�̏ꍇ�A�Y�����郁�[�J�[�R�[�h�ő��݂��邩�`�F�b�N
                //    if(searchType == 0)
                //    {
                //        ret = (int)InputChkStatus.NotExist;
					
                //        foreach (GoodsUnitData wkGoodsUnitData in goodsUnitDataList)
                //        {
                //            // ���[�J�[�R�[�h�Ō���
                //            if (wkGoodsUnitData.GoodsMakerCd == (int)inParamList[0])
                //            {
                //                ret = (int)InputChkStatus.Normal;

                //                outParamList.Add(wkGoodsUnitData.GoodsNo);		// ���i�R�[�h
                //                outParamList.Add(wkGoodsUnitData.GoodsName);	// ���i���̐ݒ�
                //                outParamList.Add(wkGoodsUnitData.GoodsMakerCd);	// ���[�J�[�R�[�h�ݒ�
                //                outParamList.Add(wkGoodsUnitData.MakerName);	// ���[�J�[���̐ݒ�
								
                //                break;
                //            }
                //        }
                //    }
                //    // �B�������̏ꍇ
                //    else
                //    {
                //        ret = (int)InputChkStatus.Normal;
						
                //        // ���i�}�X�^�f�[�^�N���X
                //        GoodsUnitData goodsUnitData = new GoodsUnitData();
                //        goodsUnitData = goodsUnitDataList[0];

                //        outParamList.Add(goodsUnitData.GoodsNo);		// ���i�R�[�h
                //        outParamList.Add(goodsUnitData.GoodsName);		// ���i���̐ݒ�
                //        outParamList.Add(goodsUnitData.GoodsMakerCd);	// ���[�J�[�R�[�h�ݒ�
                //        outParamList.Add(goodsUnitData.MakerName);		// ���[�J�[���̐ݒ�
                //    }
                //}
                //----- ueno del ---------- end 2008.03.05
            }
            catch(Exception)
            {
            }
            outParamObj = outParamList;
			
            return ret;
        }
        #endregion ���i�R�[�h�G���[�`�F�b�N����

        #region ���i�R�[�h�G���[�`�F�b�N�����i�B�������j
        /// <summary>
        /// ���i�R�[�h�G���[�`�F�b�N�����i�B�������j
        /// </summary>
        /// <param name="inParamObj">�����I�u�W�F�N�g</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note       : ���i�R�[�h�̃G���[�`�F�b�N���s���܂��B
        ///					 �����I�u�W�F�N�g:���[�J�[�R�[�h, ���i�R�[�h
        ///					 ���ʃI�u�W�F�N�g:���i�}�X�^�������ʃX�e�[�^�X, ���i�R�[�h, ���i����, ���[�J�[�R�[�h, ���[�J�[����</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private int CheckGoodsNoCdDirect(object inParamObj, out object outParamObj)
        {
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList inParamList = null;

            try
            {
                //------------------
                // �K�{���̓`�F�b�N
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is ArrayList) == false) return ret;

                inParamList = inParamObj as ArrayList;	// ArrayList�փL���X�g

                if ((inParamList == null) || (inParamList.Count != 2)) return ret;
                if ((inParamList[0] is int) == false) return ret;
                if ((inParamList[1] is string) == false) return ret;
                if ((string)inParamList[1] == "") return ret;
				
                // ���ڃR�[�h�ȊO�G���[
                string searchCode;
                if (GetSearchType((string)inParamList[1], out searchCode) != 0) return ret;
				
                //--------------
                // ���݃`�F�b�N
                //--------------
                List<GoodsUnitData> goodsUnitDataList = null;
				
                // �f�[�^���݃`�F�b�N
                this.Cursor = Cursors.WaitCursor;
                status = this._goodsAcs.Read(this._enterpriseCode, searchCode, out goodsUnitDataList);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// ���i�}�X�^�X�e�[�^�X�ݒ�

                if ((goodsUnitDataList == null) || (goodsUnitDataList.Count == 0))
                {
                    ret = (int)InputChkStatus.NotExist;
                }
                else
                {
                    ret = (int)InputChkStatus.NotExist;

                    foreach (GoodsUnitData wkGoodsUnitData in goodsUnitDataList)
                    {
                        // ���[�J�[�R�[�h�Ō���
                        if (wkGoodsUnitData.GoodsMakerCd == (int)inParamList[0])
                        {
                            ret = (int)InputChkStatus.Normal;

                            outParamList.Add(wkGoodsUnitData.GoodsNo);		// ���i�R�[�h
                            outParamList.Add(wkGoodsUnitData.GoodsName);	// ���i���̐ݒ�
                            outParamList.Add(wkGoodsUnitData.GoodsMakerCd);	// ���[�J�[�R�[�h�ݒ�
                            outParamList.Add(wkGoodsUnitData.MakerName);	// ���[�J�[���̐ݒ�

                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            outParamObj = outParamList;

            return ret;
        }
        #endregion ���i�R�[�h�G���[�`�F�b�N�����i�B�������j

        #region ���[�J�[�R�[�h�G���[�`�F�b�N����
        /// <summary>
        /// ���[�J�[�R�[�h�G���[�`�F�b�N����
        /// </summary>
        /// <param name="inParamObj">�����I�u�W�F�N�g</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�R�[�h�̃G���[�`�F�b�N���s���܂��B
        ///					 �����I�u�W�F�N�g:���[�J�[�R�[�h
        ///					 ���ʃI�u�W�F�N�g:���[�J�[�}�X�^�������ʃX�e�[�^�X, ���[�J�[����</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private int CheckGoodsMakerCd(object inParamObj, out object outParamObj)
        {
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			
            try
            {
                //------------------
                // �K�{���̓`�F�b�N
                //------------------
                if (inParamObj == null)				return ret;
                if ((inParamObj is int) == false)	return ret;
                if ((int)inParamObj == 0)			return ret;
				
                //--------------
                // ���݃`�F�b�N
                //--------------
                MakerUMnt makerUMnt = null;
				
                this.Cursor = Cursors.WaitCursor;
                status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, (int)inParamObj);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// ���[�J�[�}�X�^�X�e�[�^�X�ݒ�

                if (makerUMnt == null)
                {
                    ret = (int)InputChkStatus.NotExist;
                }
                else
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(makerUMnt.MakerName);	// ���[�J�[���̐ݒ�
                }
            }
            catch(Exception)
            {
            }
            outParamObj = outParamList;
			
            return ret;
        }
        #endregion ���[�J�[�R�[�h�G���[�`�F�b�N����

        #region ���i�敪�O���[�v�R�[�h�G���[�`�F�b�N����
        /// <summary>
        /// ���i�敪�O���[�v�R�[�h�G���[�`�F�b�N����
        /// </summary>
        /// <param name="inParamObj">�����I�u�W�F�N�g</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note       : ���i�敪�O���[�v�R�[�h�G���[�`�F�b�N���s���܂��B
        ///					 �����I�u�W�F�N�g:���i�敪�O���[�v�R�[�h
        ///					 ���ʃI�u�W�F�N�g:���i�敪�O���[�v�}�X�^�������ʃX�e�[�^�X, ���i�敪�O���[�v����</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private int CheckLargeGoodsGanreCodeGrp(object inParamObj, out object outParamObj)
        {
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			
            try
            {
                //------------------
                // �K�{���̓`�F�b�N
                //------------------
                if (inParamObj == null)					return ret;
                if ((inParamObj is string) == false)	return ret;
                if ((string)inParamObj == "")			return ret;

                //--------------
                // ���݃`�F�b�N
                //--------------
                LGoodsGanre lGoodsGanre = null;

                this.Cursor = Cursors.WaitCursor;
                status = this._lGoodsGanreAcs.Read(out lGoodsGanre, this._enterpriseCode, (string)inParamObj);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// ���i�敪�O���[�v�}�X�^�X�e�[�^�X�ݒ�
				
                if(lGoodsGanre == null)
                {
                    ret = (int)InputChkStatus.NotExist;
                }
                else
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(lGoodsGanre.LargeGoodsGanreName);	// ���i�敪�O���[�v���̐ݒ�
                }
            }
            catch(Exception)
            {
            }
            outParamObj = outParamList;
			
            return ret;
        }
        #endregion ���i�敪�O���[�v�R�[�h�G���[�`�F�b�N����

        #region ���i�敪�R�[�h�G���[�`�F�b�N����
        /// <summary>
        /// ���i�敪�R�[�h�G���[�`�F�b�N����
        /// </summary>
        /// <param name="inParamObj">�����I�u�W�F�N�g</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note       : ���i�敪�R�[�h�G���[�`�F�b�N���s���܂��B
        ///					 �����I�u�W�F�N�g:���i�敪�O���[�v�R�[�h, ���i�敪�R�[�h
        ///					 ���ʃI�u�W�F�N�g:���i�敪�}�X�^�������ʃX�e�[�^�X, ���i�敪����</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private int CheckMediumGoodsGanreCodeGrp(object inParamObj, out object outParamObj)
        {
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList inParamList = null;
			
            try
            {
                //------------------
                // �K�{���̓`�F�b�N
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is ArrayList) == false) return ret;

                inParamList = inParamObj as ArrayList;	// ArrayList�փL���X�g

                if ((inParamList == null) || (inParamList.Count != 2))	return ret;
                if ((inParamList[0] is string) == false)				return ret;
                if ((inParamList[1] is string) == false)				return ret;
                if ((string)inParamList[1] == "")						return ret;

                //--------------
                // ���݃`�F�b�N
                //--------------
                MGoodsGanre mGoodsGanre = null;

                this.Cursor = Cursors.WaitCursor;
                status = this._mGoodsGanreAcs.Read(out mGoodsGanre, this._enterpriseCode, (string)inParamList[0], (string)inParamList[1]);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// ���i�敪�}�X�^�X�e�[�^�X�ݒ�

                if (mGoodsGanre == null)
                {
                    ret = (int)InputChkStatus.NotExist;
                }
                else
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(mGoodsGanre.MediumGoodsGanreName);	// ���i�敪���̐ݒ�
                }
            }
            catch(Exception)
            {
            }
            outParamObj = outParamList;
			
            return ret;
        }
        #endregion ���i�敪�R�[�h�G���[�`�F�b�N����

        #region ���i�敪�ڍ׃R�[�h�G���[�`�F�b�N����
        /// <summary>
        /// ���i�敪�ڍ׃R�[�h�G���[�`�F�b�N����
        /// </summary>
        /// <param name="inParamObj">�����I�u�W�F�N�g</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note       : ���i�敪�ڍ׃R�[�h�G���[�`�F�b�N���s���܂��B
        ///					 �����I�u�W�F�N�g:���i�敪�O���[�v�R�[�h, ���i�敪�R�[�h, ���i�敪�ڍ׃R�[�h
        ///					 ���ʃI�u�W�F�N�g:���i�敪�ڍ׃}�X�^�������ʃX�e�[�^�X, ���i�敪�ڍז���</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private int CheckDetailGoodsGanreCodeGrp(object inParamObj, out object outParamObj)
        {
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            ArrayList inParamList = null;
			
            try
            {
                //------------------
                // �K�{���̓`�F�b�N
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is ArrayList) == false) return ret;

                inParamList = inParamObj as ArrayList;	// ArrayList�փL���X�g

                if ((inParamList == null) || (inParamList.Count != 3)) return ret;
                if ((inParamList[0] is string) == false) return ret;
                if ((inParamList[1] is string) == false) return ret;
                if ((inParamList[2] is string) == false) return ret;
                if ((string)inParamList[2] == "") return ret;

                //--------------
                // ���݃`�F�b�N
                //--------------
                DGoodsGanre dGoodsGanre = null;

                this.Cursor = Cursors.WaitCursor;
                ret = this._dGoodsGanreAcs.Read(out dGoodsGanre, this._enterpriseCode, (string)inParamList[0], (string)inParamList[1], (string)inParamList[2]);
                this.Cursor = Cursors.Default;
				
                outParamList.Add(status);	// ���i�敪�ڍ׃}�X�^�X�e�[�^�X�ݒ�
				
                if (dGoodsGanre == null)
                {
                    ret = (int)InputChkStatus.NotExist;
                }
                else
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(dGoodsGanre.DetailGoodsGanreName);	// ���i�敪�ڍז��̐ݒ�
                }
            }
            catch(Exception)
            {
            }
            outParamObj = outParamList;
			
            return ret;
        }
        #endregion ���i�敪�ڍ׃R�[�h�G���[�`�F�b�N����

        #region ���Е��ރR�[�h�G���[�`�F�b�N����
            // ���[�U�[�K�C�h�G���[�`�F�b�N�����ōs��
        #endregion ���Е��ރR�[�h�G���[�`�F�b�N����

        #region �a�k���i�R�[�h�G���[�`�F�b�N����
        /// <summary>
        /// �a�k���i�R�[�h�G���[�`�F�b�N����
        /// </summary>
        /// <param name="inParamObj">�����I�u�W�F�N�g</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note       : �a�k���i�R�[�h�G���[�`�F�b�N���s���܂��B
        ///					 �����I�u�W�F�N�g:�a�k���i�R�[�h
        ///					 ���ʃI�u�W�F�N�g:�a�k���i�}�X�^�������ʃX�e�[�^�X, �a�k���i����</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private int CheckBLGoodsCodeGrp(object inParamObj, out object outParamObj)
        {
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			
            try
            {
                //------------------
                // �K�{���̓`�F�b�N
                //------------------
                if (inParamObj == null)				return ret;
                if ((inParamObj is int) == false)	return ret;
                if ((int)inParamObj == 0)			return ret;
				
                //--------------
                // ���݃`�F�b�N
                //--------------
                BLGoodsCdUMnt bLGoodsCdUMnt = null;

                // �f�[�^���݃`�F�b�N
                this.Cursor = Cursors.WaitCursor;
                ret = this._blGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, (int)inParamObj, 0);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// �a�k���i�}�X�^�X�e�[�^�X�ݒ�

                if (bLGoodsCdUMnt == null)
                {
                    ret = (int)InputChkStatus.NotExist;
                }
                else
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(bLGoodsCdUMnt.BLGoodsFullName);	// �a�k���i���̐ݒ�
                }
            }
            catch(Exception)
            {
            }
            outParamObj = outParamList;
			
            return ret;
        }
        #endregion �a�k���i�R�[�h�G���[�`�F�b�N����

        #region ���Ӑ�R�[�h�G���[�`�F�b�N����
        /// <summary>
        /// ���Ӑ�R�[�h�G���[�`�F�b�N����
        /// </summary>
        /// <param name="inParamObj">�����I�u�W�F�N�g</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ�R�[�h�G���[�`�F�b�N���s���܂��B
        ///					 �����I�u�W�F�N�g:���Ӑ�R�[�h
        ///					 ���ʃI�u�W�F�N�g:���Ӑ�}�X�^�������ʃX�e�[�^�X, ���Ӑ於��</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private int CheckCustomerCode(object inParamObj, out object outParamObj)
        {
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                //------------------
                // �K�{���̓`�F�b�N
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is int) == false) return ret;
                if ((int)inParamObj == 0) return ret;

                //--------------
                // ���݃`�F�b�N
                //--------------
                CustomerInfo customerInfo = null;

                this.Cursor = Cursors.WaitCursor;
                ret = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode,
                                (int)inParamObj, out customerInfo);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// ���Ӑ�}�X�^�X�e�[�^�X�ݒ�
				
                // ���̓f�[�^�����Ӑ悩����
                if ((customerInfo != null)&&(customerInfo.IsCustomer == true))
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(customerInfo.Name);	// ���Ӑ於�̐ݒ�
                }
                else
                {
                    ret = (int)InputChkStatus.NotExist;
                }
            }
            catch(Exception)
            {
            }
            outParamObj = outParamList;
			
            return ret;
        }
        #endregion ���Ӑ�R�[�h�G���[�`�F�b�N����

        #region ���Ӑ�|���O���[�v�G���[�`�F�b�N����
            // ���[�U�[�K�C�h�G���[�`�F�b�N�����ōs��
        #endregion ���Ӑ�|���O���[�v�G���[�`�F�b�N����

        #region �d����R�[�h�G���[�`�F�b�N����
        /// <summary>
        /// �d����R�[�h�G���[�`�F�b�N����
        /// </summary>
        /// <param name="inParamObj">�����I�u�W�F�N�g</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note       : �d����R�[�h�G���[�`�F�b�N���s���܂��B
        ///					 �����I�u�W�F�N�g:�d����R�[�h
        ///					 ���ʃI�u�W�F�N�g:�d����}�X�^�������ʃX�e�[�^�X, �d���於��</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private int CheckSupplierCd(object inParamObj, out object outParamObj)
        {
            outParamObj = null;
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                //------------------
                // �K�{���̓`�F�b�N
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is int) == false) return ret;
                if ((int)inParamObj == 0) return ret;

                //--------------
                // ���݃`�F�b�N
                //--------------
                CustomerInfo customerInfo = null;

                this.Cursor = Cursors.WaitCursor;
                ret = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode,
                                this.SupplierCd_tNedit.GetInt(), out customerInfo);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// �d����}�X�^�X�e�[�^�X�ݒ�

                // ���̓f�[�^�����Ӑ悩����
                if ((customerInfo != null) && (customerInfo.IsSupplier == true))
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(customerInfo.Name);	// �d���於�̐ݒ�
                }
                else
                {
                    ret = (int)InputChkStatus.NotExist;
                }
            }
            catch(Exception)
            {
            }
            outParamObj = outParamList;
			
            return ret;
        }
        #endregion �d����R�[�h�G���[�`�F�b�N����

        #region �d����|���O���[�v�G���[�`�F�b�N����
            // ���[�U�[�K�C�h�G���[�`�F�b�N�����ōs��
        #endregion �d����|���O���[�v�G���[�`�F�b�N����

        #region �|���J�n���G���[�`�F�b�N����
        /// <summary>
        /// �|���J�n���G���[�`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note       : �|���J�n���G���[�`�F�b�N���s���܂��B
        ///					 �����I�u�W�F�N�g:�|���J�n��
        ///					 ���ʃI�u�W�F�N�g:����</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private int CheckRateStartDate(object inParamObj, out object outParamObj)
        {
            outParamObj = 0;	// ���ʃI�u�W�F�N�g�͖��g�p
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;

            ArrayList inParamList = null;
			
            try
            {
                //------------------
                // �K�{���̓`�F�b�N
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is ArrayList) == false) return ret;
				
                inParamList = inParamObj as ArrayList;	// ArrayList�փL���X�g
				
                if ((inParamList == null) || (inParamList.Count != 3)) return ret;
                if ((inParamList[0] is int) == false) return ret;
                if ((inParamList[1] is int) == false) return ret;
                if ((inParamList[2] is int) == false) return ret;

                if (((int)inParamList[0] > 0) && ((int)inParamList[1] > 0) && ((int)inParamList[2] > 0))
                {
                    // ���͂����������t���H
                    int inputDate_int = ((int)inParamList[0] * 10000) + ((int)inParamList[1] * 100) + ((int)inParamList[2]);
                    DateTime inputDate = TDateTime.LongDateToDateTime(inputDate_int);
					
                    // ������
                    if (inputDate != DateTime.MinValue)
                    {
                        ret = (int)InputChkStatus.Normal;
                    }
                    else
                    {
                        ret = (int)InputChkStatus.InputErr;	// �s���f�[�^
                    }
                }
            }
            catch(Exception)
            {
            }
            return ret;
        }
        #endregion �|���J�n���G���[�`�F�b�N����
		
        #region ���[�U�[�K�C�h�G���[�`�F�b�N����
        /// <summary>
        /// ���[�U�[�K�C�h�G���[�`�F�b�N����
        /// </summary>
        /// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
        /// <remarks>
        /// <br>Note       : ���[�U�[�K�C�h�̃G���[�`�F�b�N���s���܂��B
        ///					 �����I�u�W�F�N�g:���[�U�[�K�C�h�R�[�h
        ///					 ���ʃI�u�W�F�N�g:���g�p</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private int CheckUserGuide(object inParamObj, out object outParamObj)
        {
            outParamObj = 0;
            int ret = (int)InputChkStatus.NotInput;
			
            ArrayList inParamList = null;
			
            try
            {
                //------------------
                // �K�{���̓`�F�b�N
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is ArrayList) == false) return ret;

                inParamList = inParamObj as ArrayList;	// ArrayList�փL���X�g

                if ((inParamList == null) || (inParamList.Count != 2)) return ret;
                if ((inParamList[0] is SortedList)	== false) return ret;
                if ((inParamList[1] is int)			== false) return ret;
				
                //--------------
                // ���݃`�F�b�N
                //--------------
                // �Y���f�[�^�����݂��邩�m�F
                ret = (int)InputChkStatus.NotExist;
				
                foreach (DictionaryEntry de in (SortedList)inParamList[0])
                {
                    if ((Int32)de.Key == (int)inParamList[1])
                    {
                        ret = (int)InputChkStatus.Normal;
                        break;
                    }
                }
            }
            catch (Exception)
            {
            }
			
            return ret;
        }
        #endregion ���[�U�[�K�C�h�G���[�`�F�b�N����

        #endregion ���e��G���[�`�F�b�N������

        #region �����ڃf�[�^�ݒ菈����

        #region ���_�R�[�h�ݒ菈��
        /// <summary>
        /// ���_�R�[�h�ݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���_�R�[�h����ʂɐݒ肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetSectionCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            this.RateSectionCode_tEdit.Clear();
                            this.SectionCodeNm_tEdit.Clear();

                            // ���݃f�[�^�N���A
                            this._searchRate.SectionCode = "";

                            //----- ueno upd ---------- start 2008.03.07
                            // �t�H�[�J�X
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07
                            break;
                        }
                    case DispSetStatus.Back:	// ���ɖ߂�
                        {
                            this.RateSectionCode_tEdit.Text = this._searchRate.SectionCode;

                            //----- ueno add ---------- start 2008.03.07
                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            if ((outParamObj != null)&&(outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;
								
                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.SectionCodeNm_tEdit.Text = (string)outParamList[1];	// ���_���̐ݒ�
									
                                    // ���݃f�[�^�ۑ�
                                    this._searchRate.SectionCode = this.RateSectionCode_tEdit.Text;

                                    //----------------------------------------
                                    // ���_�R�[�h�A�|���ݒ�敪�֘A���`�F�b�N
                                    //----------------------------------------
                                    // �����ݒ�
                                    ArrayList wkInParamList = new ArrayList();
                                    wkInParamList.Add(this.RateSectionCode_tEdit.Text);
                                    wkInParamList.Add(NullChgInt(this.UnitPriceKind_tComboEditor.Value));
                                    wkInParamList.Add(NullChgInt(this.UnitPriceKindWay_tComboEditor.Value));
                                    wkInParamList.Add(this.RateSettingDivide_tEdit.Text);
									
                                    object wkInParamObj = wkInParamList;
                                    object wkOutParamObj = null;
									
                                    // ���݃`�F�b�N
                                    int status = CheckRateSettingDivide(wkInParamObj, out wkOutParamObj);
									
                                    if(status != 0)
                                    {
                                        // ���_�R�[�h�ȊO�S�č폜
                                        SectionCodeVisibleChange();
                                    }
                                }
                            }
                            break;
                        }
                }
            }
            catch(Exception)
            {
            }
        }
        #endregion ���_�R�[�h�ݒ菈��

        #region �|���ݒ�敪�ݒ菈��
        /// <summary>
        /// �|���ݒ�敪�ݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �|���ݒ�敪����ʂɐݒ肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetRateSettingDivide(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            // �|���ݒ�敪�N���A
                            this.RateSettingDivide_tEdit.Clear();
                            this.RateMngGoodsCd_tEdit.Clear();
                            this.RateMngGoodsNm_tEdit.Clear();
                            this.RateMngCustCd_tEdit.Clear();
                            this.RateMngCustNm_tEdit.Clear();

                            // ���݃f�[�^�N���A
                            this._searchRate.RateSettingDivide = "";
                            this._searchRate.RateMngGoodsCd = "";
                            this._searchRate.RateMngGoodsNm = "";
                            this._searchRate.RateMngCustCd = "";
                            this._searchRate.RateMngCustNm = "";

                            //----- ueno upd ---------- start 2008.03.07
                            // �t�H�[�J�X
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// ���ɖ߂�
                        {
                            this.RateSettingDivide_tEdit.Text = this._searchRate.RateSettingDivide;
                            this.RateMngGoodsCd_tEdit.Text = this._searchRate.RateMngGoodsCd;
                            this.RateMngCustCd_tEdit.Text = this._searchRate.RateMngCustCd;
							
                            this.RateSectionCode_tEdit.Text = this._searchRate.SectionCode;

                            //----- ueno add ---------- start 2008.03.07
                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            if ((outParamObj != null)&&(outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;
								
                                if ((outParamList != null)
                                    && (outParamList.Count == 5) 
                                    && (outParamList[1] is string)
                                    && (outParamList[2] is string)
                                    && (outParamList[3] is string)
                                    && (outParamList[4] is string))
                                {
                                    this.RateMngGoodsCd_tEdit.Text = (string)outParamList[1];	// �|���ݒ�敪�R�[�h�i���i�j
                                    this.RateMngGoodsNm_tEdit.Text = (string)outParamList[2];	// �|���ݒ�敪���́i���i�j
                                    this.RateMngCustCd_tEdit.Text = (string)outParamList[3];	// �|���ݒ�敪�R�[�h�i���Ӑ�j
                                    this.RateMngCustNm_tEdit.Text = (string)outParamList[4];	// �|���ݒ�敪���́i���Ӑ�j

                                    // ���݃f�[�^�ۑ�
                                    this._searchRate.RateSettingDivide = this.RateSettingDivide_tEdit.Text;
                                    this._searchRate.RateMngGoodsCd = this.RateMngGoodsCd_tEdit.Text;
                                    this._searchRate.RateMngGoodsNm = this.RateMngGoodsNm_tEdit.Text;
                                    this._searchRate.RateMngCustCd = this.RateMngCustCd_tEdit.Text;
                                    this._searchRate.RateMngCustNm = this.RateMngCustNm_tEdit.Text;
                                }
                            }
							
                            break;
                        }
                }
            }
            catch(Exception)
            {
            }
        }
        #endregion �|���ݒ�敪�ݒ菈��

        #region ���i�|�������N�ݒ菈��
        /// <summary>
        /// ���i�|�������N�ݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���i�|�������N����ʂɐݒ肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetGoodsRateRankCd(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            this.GoodsRateRankCd_Grp_tEdit.Clear();
							
                            // ���݃f�[�^�N���A
                            this._searchRate.GoodsRateRank = "";

                            //----- ueno upd ---------- start 2008.03.07
                            // �t�H�[�J�X
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:		// ���ɖ߂�
                        {
                            this.GoodsRateRankCd_Grp_tEdit.Text = this._searchRate.GoodsRateRank;

                            //----- ueno add ---------- start 2008.03.07
                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            if ((outParamObj != null) && (outParamObj is string))
                            {
                                this.GoodsRateRankCd_Grp_tEdit.Text = (string)outParamObj;
								
                                // ���݃f�[�^�ۑ�
                                this._searchRate.GoodsRateRank = this.GoodsRateRankCd_Grp_tEdit.Text;
                            }
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion ���i�|�������N�ݒ菈��

        #region ���i�R�[�h�ݒ菈��
        /// <summary>
        /// ���i�R�[�h�ݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���i�R�[�h����ʂɐݒ肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetGoodsNoCd(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            this.GoodsNoCd_tEdit.Clear();
                            this.GoodsNoNm_tEdit.Clear();

                            // ���݃f�[�^�N���A
                            this._searchRate.GoodsNo = "";

                            //----- ueno upd ---------- start 2008.03.07
                            // �t�H�[�J�X
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:		// ���ɖ߂�
                        {
                            this.GoodsNoCd_tEdit.Text = this._searchRate.GoodsNo;

                            //----- ueno add ---------- start 2008.03.07
                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            if ((outParamObj != null)&&(outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;
								
                                if ((outParamList != null)
                                    && (outParamList.Count == 5)
                                    && (outParamList[1] is string)
                                    && (outParamList[2] is string)
                                    && (outParamList[3] is int)
                                    && (outParamList[4] is string))
                                {
                                    this.GoodsNoCd_tEdit.Text = (string)outParamList[1];		// ���i�R�[�h
                                    this.GoodsNoNm_tEdit.Text = (string)outParamList[2];		// ���i����
                                    this.GoodsMakerCd_tNedit.SetInt((int)outParamList[3]);		// ���[�J�[�R�[�h
                                    this.GoodsMakerCdNm_tEdit.Text = (string)outParamList[4];	// ���[�J�[����

                                    // ���݃f�[�^�ۑ�
                                    this._searchRate.GoodsNo = this.GoodsNoCd_tEdit.Text;
                                    this._searchRate.GoodsMakerCd = this.GoodsMakerCd_tNedit.GetInt();
                                }
                            }
                            break;
                        }
                }
            }
            catch(Exception)
            {
            }
        }
        #endregion ���i�R�[�h�ݒ菈��

        #region ���[�J�[�R�[�h�i�P�i�j�ݒ菈��
        /// <summary>
        /// ���[�J�[�R�[�h�i�P�i�j�ݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�R�[�h�i�P�i�j����ʂɐݒ肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetGoodsMakerCd(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            this.GoodsMakerCd_tNedit.Clear();
                            this.GoodsMakerCdNm_tEdit.Clear();

                            // ���݃f�[�^�N���A
                            this._searchRate.GoodsMakerCd = 0;

                            //----- ueno add ---------- start 2008.03.05
                            // ���i�R�[�h�N���A
                            this.GoodsNoCd_tEdit.Clear();
                            this.GoodsNoNm_tEdit.Clear();
                            this._searchRate.GoodsNo = "";
                            //----- ueno add ---------- end 2008.03.05

                            //----- ueno upd ---------- start 2008.03.07
                            // �t�H�[�J�X
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07
                            break;
                        }
                    case DispSetStatus.Back:		// ���ɖ߂�
                        {
                            this.GoodsMakerCd_tNedit.SetInt(this._searchRate.GoodsMakerCd);

                            //----- ueno add ---------- start 2008.03.07
                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            if ((outParamObj != null)&&(outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;
								
                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.GoodsMakerCdNm_tEdit.Text = (string)outParamList[1];	// ���[�J�[����

                                    //----- ueno add ---------- start 2008.03.05
                                    //----------------------------
                                    // ���[�J�[�R�[�h�ύX�`�F�b�N
                                    //----------------------------
                                    if (this._searchRate.GoodsMakerCd != this.GoodsMakerCd_tNedit.GetInt())
                                    {
                                        // ���[�J�[�R�[�h�ύX���́A���i�R�[�h�N���A
                                        this.GoodsNoCd_tEdit.Clear();
                                        this.GoodsNoNm_tEdit.Clear();
                                        this._searchRate.GoodsNo = "";
                                    }
                                    //----- ueno add ---------- end 2008.03.05
									
                                    // ���݃f�[�^�ۑ�
                                    this._searchRate.GoodsMakerCd = this.GoodsMakerCd_tNedit.GetInt();

                                    //----- ueno del ---------- start 2008.03.05
                                    ////------------------------------------------
                                    //// ���[�J�[�R�[�h�A���i�R�[�h�֘A���`�F�b�N
                                    ////------------------------------------------
                                    //// �����ݒ�
                                    //ArrayList wkInParamList = new ArrayList();
                                    //wkInParamList.Add(this.GoodsMakerCd_tNedit.GetInt());
                                    //wkInParamList.Add(this.GoodsNoCd_tEdit.Text);
									
                                    //object wkInParamObj = wkInParamList;
                                    //object wkOutParamObj = null;
									
                                    //// ���݃`�F�b�N�i�B�������j
                                    //int status = CheckGoodsNoCdDirect(wkInParamObj, out wkOutParamObj);
									
                                    //if(status != 0)
                                    //{
                                    //    // ���[�J�[�ɕR�Â����i�R�[�h, ���i���̃N���A
                                    //    this.GoodsNoCd_tEdit.Clear();
                                    //    this.GoodsNoNm_tEdit.Clear();
                                    //    this._searchRate.GoodsNo = "";
                                    //}
                                    //----- ueno del ---------- end 2008.03.05
                                }
                            }
                            break;
                        }
                }
            }
            catch(Exception)
            {
            }
        }
        #endregion ���[�J�[�R�[�h�i�P�i�j�ݒ菈��

        #region ���[�J�[�R�[�h�ݒ菈��
        /// <summary>
        /// ���[�J�[�R�[�h�ݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���[�J�[�R�[�h����ʂɐݒ肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetGoodsMakerCdGrp(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;

            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            this.GoodsMakerCd_Grp_tNedit.Clear();
                            this.GoodsMakerCdNm_Grp_tEdit.Clear();

                            // ���݃f�[�^�N���A
                            this._searchRate.GoodsMakerCd = 0;

                            //----- ueno upd ---------- start 2008.03.07
                            // �t�H�[�J�X
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:		// ���ɖ߂�
                        {
                            this.GoodsMakerCd_Grp_tNedit.SetInt(this._searchRate.GoodsMakerCd);

                            //----- ueno add ---------- start 2008.03.07
                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            if ((outParamObj != null) && (outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;

                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.GoodsMakerCdNm_Grp_tEdit.Text = (string)outParamList[1];	// ���[�J�[����

                                    // ���݃f�[�^�ۑ�
                                    this._searchRate.GoodsMakerCd = this.GoodsMakerCd_Grp_tNedit.GetInt();
                                }
                            }
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion ���[�J�[�R�[�h�ݒ菈��

        #region ���i�敪�O���[�v�R�[�h�ݒ菈��
        /// <summary>
        /// ���i�敪�O���[�v�R�[�h�ݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���i�敪�O���[�v�R�[�h����ʂɐݒ肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetLargeGoodsGanreCodeGrp(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            this.LargeGoodsGanreCode_Grp_tEdit.Clear();
                            this.LargeGoodsGanreCodeNm_Grp_tEdit.Clear();

                            // ���݃f�[�^�N���A
                            this._searchRate.LargeGoodsGanreCode = "";

                            //----- ueno upd ---------- start 2008.03.07
                            // �t�H�[�J�X
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// ���ɖ߂�
                        {
                            this.LargeGoodsGanreCode_Grp_tEdit.Text = this._searchRate.LargeGoodsGanreCode;

                            //----- ueno add ---------- start 2008.03.07
                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            if ((outParamObj != null) && (outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;

                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.LargeGoodsGanreCodeNm_Grp_tEdit.Text = (string)outParamList[1];	// ���i�敪�O���[�v����
									
                                    // ���݃f�[�^�ۑ�
                                    this._searchRate.LargeGoodsGanreCode = this.LargeGoodsGanreCode_Grp_tEdit.Text;
                                }
                            }
                            break;
                        }
                }
            }
            catch(Exception)
            {
            }
        }
        #endregion ���i�敪�O���[�v�R�[�h�ݒ菈��

        #region ���i�敪�R�[�h�ݒ菈��
        /// <summary>
        /// ���i�敪�R�[�h�ݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���i�敪�R�[�h����ʂɐݒ肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetMediumGoodsGanreCodeGrp(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            this.MediumGoodsGanreCode_Grp_tEdit.Clear();
                            this.MediumGoodsGanreCodeNm_Grp_tEdit.Clear();

                            // ���݃f�[�^�N���A
                            this._searchRate.MediumGoodsGanreCode = "";

                            //----- ueno upd ---------- start 2008.03.07
                            // �t�H�[�J�X
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// ���ɖ߂�
                        {
                            this.MediumGoodsGanreCode_Grp_tEdit.Text = this._searchRate.MediumGoodsGanreCode;

                            //----- ueno add ---------- start 2008.03.07
                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            if ((outParamObj != null)&&(outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;
								
                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.MediumGoodsGanreCodeNm_Grp_tEdit.Text = (string)outParamList[1];	// ���i�敪����

                                    // ���݃f�[�^�ۑ�
                                    this._searchRate.MediumGoodsGanreCode = this.MediumGoodsGanreCode_Grp_tEdit.Text;
                                }
                            }
                            break;
                        }
                }				
            }
            catch(Exception)
            {
            }
        }
        #endregion ���i�敪�R�[�h�ݒ菈��

        #region ���i�敪�ڍ׃R�[�h�ݒ菈��
        /// <summary>
        /// ���i�敪�ڍ׃R�[�h�ݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���i�敪�ڍ׃R�[�h����ʂɐݒ肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetDetailGoodsGanreCodeGrp(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            this.DetailGoodsGanreCode_Grp_tEdit.Clear();
                            this.DetailGoodsGanreCodeNm_Grp_tEdit.Clear();

                            // ���݃f�[�^�N���A
                            this._searchRate.DetailGoodsGanreCode = "";

                            //----- ueno upd ---------- start 2008.03.07
                            // �t�H�[�J�X
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// ���ɖ߂�
                        {
                            this.DetailGoodsGanreCode_Grp_tEdit.Text = this._searchRate.DetailGoodsGanreCode;

                            //----- ueno add ---------- start 2008.03.07
                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            if ((outParamObj != null)&&(outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;
															
                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.DetailGoodsGanreCodeNm_Grp_tEdit.Text = (string)outParamList[1];	// ���i�敪�ڍז���

                                    // ���݃f�[�^�ۑ�
                                    this._searchRate.DetailGoodsGanreCode = this.DetailGoodsGanreCode_Grp_tEdit.Text;
                                }
                            }
                            break;
                        }
                }
            }
            catch(Exception)
            {
            }
        }
        #endregion ���i�敪�ڍ׃R�[�h�ݒ菈��

        #region ���Е��ރR�[�h�ݒ菈��
        /// <summary>
        /// ���Е��ރR�[�h�ݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���Е��ރR�[�h����ʂɐݒ肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetEnterpriseGanreCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            this.EnterpriseGanreCode_Grp_tComboEditor.Clear();

                            // ���݃f�[�^�N���A
                            this._searchRate.EnterpriseGanreCode = 0;

                            //----- ueno upd ---------- start 2008.03.07
                            // �t�H�[�J�X
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// ���ɖ߂�
                        {
                            this.EnterpriseGanreCode_Grp_tComboEditor.Value = this._searchRate.EnterpriseGanreCode;

                            //----- ueno add ---------- start 2008.03.07
                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            // ���݃f�[�^�ۑ�
                            this._searchRate.EnterpriseGanreCode = (int)this.EnterpriseGanreCode_Grp_tComboEditor.Value;
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion ���Е��ރR�[�h�ݒ菈��

        #region �a�k���i�R�[�h�ݒ菈��
        /// <summary>
        /// �a�k���i�R�[�h�ݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �a�k���i�R�[�h����ʂɐݒ肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetBLGoodsCodeGrp(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            this.BLGoodsCode_Grp_tNedit.Clear();
                            this.BLGoodsCodeNm_Grp_tEdit.Clear();

                            // ���݃f�[�^�N���A
                            this._searchRate.BLGoodsCode = 0;

                            //----- ueno upd ---------- start 2008.03.07
                            // �t�H�[�J�X
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// ���ɖ߂�
                        {
                            this.BLGoodsCode_Grp_tNedit.SetInt(this._searchRate.BLGoodsCode);

                            //----- ueno add ---------- start 2008.03.07
                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            if ((outParamObj != null)&&(outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;
						
                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.BLGoodsCodeNm_Grp_tEdit.Text = (string)outParamList[1];

                                    // ���݃f�[�^�ۑ�
                                    this._searchRate.BLGoodsCode = this.BLGoodsCode_Grp_tNedit.GetInt();
                                }
                            }
                            break;
                        }
                }
            }
            catch(Exception)
            {
            }
        }
        #endregion �a�k���i�R�[�h�ݒ菈��

        #region ���Ӑ�R�[�h�ݒ菈��
        /// <summary>
        /// ���Ӑ�R�[�h�ݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�R�[�h����ʂɐݒ肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetCustomerCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            this.CustomerCode_tNedit.Clear();
                            this.CustomerCodeNm_tEdit.Clear();

                            // ���݃f�[�^�N���A
                            this._searchRate.CustomerCode = 0;

                            //----- ueno upd ---------- start 2008.03.07
                            // �t�H�[�J�X
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// ���ɖ߂�
                        {
                            this.CustomerCode_tNedit.SetInt(this._searchRate.CustomerCode);

                            //----- ueno add ---------- start 2008.03.07
                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            if ((outParamObj != null)&&(outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;

                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.CustomerCodeNm_tEdit.Text = (string)outParamList[1];

                                    // ���݃f�[�^�ۑ�
                                    this._searchRate.CustomerCode = this.CustomerCode_tNedit.GetInt();
                                }
                            }
                            break;
                        }
                }
            }
            catch(Exception)
            {
            }
        }
        #endregion ���Ӑ�R�[�h�ݒ菈��

        #region ���Ӑ�|���O���[�v�ݒ菈��
        /// <summary>
        /// ���Ӑ�|���O���[�v�ݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�|���O���[�v����ʂɐݒ肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetCustRateGrpCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            this.CustRateGrpCode_tComboEditor.Clear();

                            // ���݃f�[�^�N���A
                            this._searchRate.CustRateGrpCode = 0;

                            //----- ueno upd ---------- start 2008.03.07
                            // �t�H�[�J�X
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// ���ɖ߂�
                        {
                            this.CustRateGrpCode_tComboEditor.Value = this._searchRate.CustRateGrpCode;

                            //----- ueno add ---------- start 2008.03.07
                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            // ���݃f�[�^�ۑ�
                            this._searchRate.CustRateGrpCode = (int)this.CustRateGrpCode_tComboEditor.Value;
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion ���Ӑ�|���O���[�v�ݒ菈��

        #region �d����R�[�h�ݒ菈��
        /// <summary>
        /// �d����R�[�h�ݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �d����R�[�h����ʂɐݒ肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetSupplierCd(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            this.SupplierCd_tNedit.Clear();
                            this.SupplierCdNm_tEdit.Clear();

                            // ���݃f�[�^�N���A
                            this._searchRate.SupplierCd = 0;

                            //----- ueno upd ---------- start 2008.03.07
                            // �t�H�[�J�X
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// ���ɖ߂�
                        {
                            this.SupplierCd_tNedit.SetInt(this._searchRate.SupplierCd);

                            //----- ueno add ---------- start 2008.03.07
                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            if ((outParamObj != null)&&(outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;

                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.SupplierCdNm_tEdit.Text = (string)outParamList[1];

                                    // ���݃f�[�^�ۑ�
                                    this._searchRate.SupplierCd = this.SupplierCd_tNedit.GetInt();
                                }
                            }
                            break;
                        }
                }
            }
            catch(Exception)
            {
            }
        }
        #endregion �d����R�[�h�ݒ菈��
		
        #region �d����|���O���[�v�ݒ菈��
        /// <summary>
        /// �d����|���O���[�v�ݒ菈��
        /// </summary>
        /// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        /// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        /// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �d����|���O���[�v����ʂɐݒ肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetSuppRateGrpCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// �f�[�^�N���A
                        {
                            this.SuppRateGrpCode_tComboEditor.Clear();
							
                            // ���݃f�[�^�N���A
                            this._searchRate.SuppRateGrpCode = 0;

                            //----- ueno upd ---------- start 2008.03.07
                            // �t�H�[�J�X
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// ���ɖ߂�
                        {
                            this.SuppRateGrpCode_tComboEditor.Value = this._searchRate.SuppRateGrpCode;

                            //----- ueno add ---------- start 2008.03.07
                            // �t�H�[�J�X�ړ����Ȃ�
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// �X�V
                        {
                            // ���݃f�[�^�ۑ�
                            this._searchRate.SuppRateGrpCode = (int)this.SuppRateGrpCode_tComboEditor.Value;
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion �d����|���O���[�v�ݒ菈��

        #endregion �����ڃf�[�^�ݒ菈����

        /// <summary>
        /// ���_�R�[�h�ύX������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_�R�[�h���ύX���ꂽ�Ƃ��ɏ������s���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void SectionCodeVisibleChange()
        {
            string wkSectionCode = this.RateSectionCode_tEdit.Text;
            string wkSectionName = this.SectionCodeNm_tEdit.Text;
			
            // �S�N���A
            ScreenClear();
			
            this.RateSectionCode_tEdit.Text = wkSectionCode;
            this.SectionCodeNm_tEdit.Text = wkSectionName;
			
            // ���݃f�[�^�ۑ�
            this._searchRate.SectionCode = this.RateSectionCode_tEdit.Text;
        }

        /// <summary>
        /// �|���ݒ�敪�ύX������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|���ݒ�敪���ύX���ꂽ�Ƃ��ɏ������s���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void RateSettingDivideVisibleChange()
        {
            // �ꎞ�ޔ�
            string wkSectionCode = this.RateSectionCode_tEdit.Text;
            string wkSectionName = this.SectionCodeNm_tEdit.Text;
            int wkUnitPriceKind = (Int32)this.UnitPriceKind_tComboEditor.Value;
            int wkUnitPriceKindWay = (Int32)this.UnitPriceKindWay_tComboEditor.Value;
			
            string wkRateSettingDivide = this.RateSettingDivide_tEdit.Text;
            string wkRateMngGoodsCd = this.RateMngGoodsCd_tEdit.Text;
            string wkRateMngGoodsNm = this.RateMngGoodsNm_tEdit.Text;
            string wkRateMngCustCd  = this.RateMngCustCd_tEdit.Text;
            string wkRateMngCustNm  = this.RateMngCustNm_tEdit.Text;
			
            // �|���ݒ�敪�͕ύX�����ƒ��o�������ύX�����̂ŁA���o�������폜����
            ScreenClear();
			
            // ���[�N��ݒ�
            this.RateSectionCode_tEdit.Text = wkSectionCode;
            this.UnitPriceKind_tComboEditor.Value = wkUnitPriceKind;
            this.UnitPriceKindWay_tComboEditor.Value = wkUnitPriceKindWay;
            this.SectionCodeNm_tEdit.Text = wkSectionName;

            this.RateSettingDivide_tEdit.Text = wkRateSettingDivide;
            this.RateMngGoodsCd_tEdit.Text = wkRateMngGoodsCd;
            this.RateMngGoodsNm_tEdit.Text = wkRateMngGoodsNm;
            this.RateMngCustCd_tEdit.Text = wkRateMngCustCd;
            this.RateMngCustNm_tEdit.Text = wkRateMngCustNm;

            // ���݃f�[�^�ۑ�
            this._searchRate.SectionCode = this.RateSectionCode_tEdit.Text;

            this._searchRate.RateSettingDivide = this.RateSettingDivide_tEdit.Text;
            this._searchRate.RateMngGoodsCd = this.RateMngGoodsCd_tEdit.Text;
            this._searchRate.RateMngGoodsNm = this.RateMngGoodsNm_tEdit.Text;
            this._searchRate.RateMngCustCd = this.RateMngCustCd_tEdit.Text;
            this._searchRate.RateMngCustNm = this.RateMngCustNm_tEdit.Text;
			
            // �C�x���g��~
            this.UnitPriceKind_tComboEditor.SelectionChangeCommitted -= new EventHandler(this.UnitPriceKind_tComboEditor_SelectionChangeCommitted);
            this.UnitPriceKindWay_tComboEditor.SelectionChangeCommitted -= new EventHandler(this.UnitPriceKindWay_tComboEditor_SelectionChangeCommitted);

            // �R���{�{�b�N�X�ݒ�
            UnitPriceKindVisibleChange((Int32)this.UnitPriceKind_tComboEditor.Value);
            UnitPriceKindWayVisibleChange((Int32)this.UnitPriceKindWay_tComboEditor.Value);

            // �C�x���g����
            this.UnitPriceKind_tComboEditor.SelectionChangeCommitted += new EventHandler(this.UnitPriceKind_tComboEditor_SelectionChangeCommitted);
            this.UnitPriceKindWay_tComboEditor.SelectionChangeCommitted += new EventHandler(this.UnitPriceKindWay_tComboEditor_SelectionChangeCommitted);
        }

        /// <summary>
        /// �f�[�^�����G���[���b�Z�[�W�쐬����
        /// </summary>
        /// <param name="title">���ږ�</param>
        /// <returns>���b�Z�[�W</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�����̃G���[���b�Z�[�W���쐬���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private string MakeShowNotFoundErrMsg(string title)
        {
            string errMsg = "";
            _stringBuilder.Remove(0, _stringBuilder.Length);
            _stringBuilder.Append("�w�肳�ꂽ�����ŁA");
            _stringBuilder.Append(title);
            _stringBuilder.Append("�͑��݂��܂���ł����B");
            errMsg = _stringBuilder.ToString();
			
            return errMsg;
        }

        #region �^�u�R���g���[���e�[�u���쐬����
        /// <summary>
        /// �^�u�R���g���[���e�[�u���쐬����
        /// </summary>
        /// <br>Note       : �^�u�R���g���[���e�[�u�����쐬���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.11.06</br>
        private void SetTabControlList()
        {
            //==============================
            // ������
            //==============================
            // �|���ݒ�p�l��
            this._nextCtrlTable.Add(this.RateSectionCode_tEdit.Name,				this.SectionCode_uButton);
            this._nextCtrlTable.Add(this.SectionCode_uButton.Name,				this.UnitPriceKind_tComboEditor);
            this._nextCtrlTable.Add(this.UnitPriceKind_tComboEditor.Name,		this.UnitPriceKindWay_tComboEditor);
            this._nextCtrlTable.Add(this.UnitPriceKindWay_tComboEditor.Name,	this.RateSettingDivide_tEdit);
            this._nextCtrlTable.Add(this.RateSettingDivide_tEdit.Name,			this.RateSettingDivide_uButton);
            this._nextCtrlTable.Add(this.RateSettingDivide_uButton.Name,		this.Rate_uTabControl);		// �f�t�H���g�ݒ�F�|���^�u
			
            // �P�i�ݒ�p�l��
            this._nextCtrlTable.Add(this.GoodsMakerCd_tNedit.Name,				this.GoodsMakerCd_uButton);
            this._nextCtrlTable.Add(this.GoodsMakerCd_uButton.Name,				this.GoodsNoCd_tEdit);
            this._nextCtrlTable.Add(this.GoodsNoCd_tEdit.Name,					this.GoodsNo_uButton);
            this._nextCtrlTable.Add(this.GoodsNo_uButton.Name,					this.CustomerCode_tNedit);
			
            // ���iG�ݒ�p�l��
            this._nextCtrlTable.Add(this.GoodsMakerCd_Grp_tNedit.Name,			this.GoodsMakerCd_Grp_uButton);
            this._nextCtrlTable.Add(this.GoodsMakerCd_Grp_uButton.Name,			this.GoodsRateRankCd_Grp_tEdit);
            this._nextCtrlTable.Add(this.GoodsRateRankCd_Grp_tEdit.Name,		this.LargeGoodsGanreCode_Grp_tEdit);
            this._nextCtrlTable.Add(this.LargeGoodsGanreCode_Grp_tEdit.Name,	this.LargeGoodsGanreCode_Grp_uButton);
            this._nextCtrlTable.Add(this.LargeGoodsGanreCode_Grp_uButton.Name,	this.MediumGoodsGanreCode_Grp_tEdit);
            this._nextCtrlTable.Add(this.MediumGoodsGanreCode_Grp_tEdit.Name,	this.MediumGoodsGanreCode_Grp_uButton);
            this._nextCtrlTable.Add(this.MediumGoodsGanreCode_Grp_uButton.Name,	this.DetailGoodsGanreCode_Grp_tEdit);
            this._nextCtrlTable.Add(this.DetailGoodsGanreCode_Grp_tEdit.Name,	this.DetailGoodsGanreCode_Grp_uButton);
            this._nextCtrlTable.Add(this.DetailGoodsGanreCode_Grp_uButton.Name,	this.EnterpriseGanreCode_Grp_tComboEditor);
            this._nextCtrlTable.Add(this.EnterpriseGanreCode_Grp_tComboEditor.Name, this.BLGoodsCode_Grp_tNedit);
            this._nextCtrlTable.Add(this.BLGoodsCode_Grp_tNedit.Name,			this.BLGoodsCode_Grp_uButton);
            this._nextCtrlTable.Add(this.BLGoodsCode_Grp_uButton.Name,			this.CustomerCode_tNedit);
			
            // �����ݒ�p�l��
            this._nextCtrlTable.Add(this.CustomerCode_tNedit.Name,				this.CustomerCode_uButton);
            this._nextCtrlTable.Add(this.CustomerCode_uButton.Name,				this.CustRateGrpCode_tComboEditor);
            this._nextCtrlTable.Add(this.CustRateGrpCode_tComboEditor.Name,		this.SupplierCd_tNedit);
            this._nextCtrlTable.Add(this.SupplierCd_tNedit.Name,				this.SupplierCd_uButton);
            this._nextCtrlTable.Add(this.SupplierCd_uButton.Name,				this.SuppRateGrpCode_tComboEditor);
            this._nextCtrlTable.Add(this.SuppRateGrpCode_tComboEditor.Name,		this.Search_uButton);
			
            // �V�|���ݒ�p�l��
            this._nextCtrlTable.Add(this.NewRateStartDate_tDateEdit.Name,		this.NewPrice_tNedit);
            this._nextCtrlTable.Add(this.NewPrice_tNedit.Name,					this.NewPriceDiv_tComboEditor);
            this._nextCtrlTable.Add(this.NewPriceDiv_tComboEditor.Name,			this.NewUnPrcCalcDiv_tComboEditor);
            this._nextCtrlTable.Add(this.NewUnPrcCalcDiv_tComboEditor.Name,		this.NewRate_tNedit);
            this._nextCtrlTable.Add(this.NewRate_tNedit.Name,					this.NewUnPrcFracProcUnit_tNedit);
            this._nextCtrlTable.Add(this.NewUnPrcFracProcUnit_tNedit.Name,		this.NewUnPrcFracProcDiv_tComboEditor);
            this._nextCtrlTable.Add(this.NewUnPrcFracProcDiv_tComboEditor.Name,	this.NewBargainCd_tComboEditor);
            this._nextCtrlTable.Add(this.NewBargainCd_tComboEditor.Name,		this.CopyToOldFromNewbtn);
			
            // �V�|�������|���{�^��
            this._nextCtrlTable.Add(this.CopyToOldFromNewbtn.Name,				this.OldRateStartDate_tDateEdit);
			
            // ���|���ݒ�p�l��
            this._nextCtrlTable.Add(this.OldRateStartDate_tDateEdit.Name,		this.OldPrice_tNedit);
            this._nextCtrlTable.Add(this.OldPrice_tNedit.Name,					this.OldPriceDiv_tComboEditor);
            this._nextCtrlTable.Add(this.OldPriceDiv_tComboEditor.Name,			this.OldUnPrcCalcDiv_tComboEditor);
            this._nextCtrlTable.Add(this.OldUnPrcCalcDiv_tComboEditor.Name,		this.OldRate_tNedit);
            this._nextCtrlTable.Add(this.OldRate_tNedit.Name,					this.OldUnPrcFracProcUnit_tNedit);
            this._nextCtrlTable.Add(this.OldUnPrcFracProcUnit_tNedit.Name,		this.OldUnPrcFracProcDiv_tComboEditor);
            this._nextCtrlTable.Add(this.OldUnPrcFracProcDiv_tComboEditor.Name,	this.OldBargainCd_tComboEditor);
            this._nextCtrlTable.Add(this.OldBargainCd_tComboEditor.Name,		this.Rate_Clear_Btn);
			
            // �����{�^��
            this._nextCtrlTable.Add(this.Search_uButton.Name,					this.Rate_uTabControl);
            // �|���^�u
            this._nextCtrlTable.Add(this.Rate_uTabControl.Name,					this.Rate_Clear_Btn);		// �f�t�H���g�ݒ�F����{�^��
            // ����{�^��
            this._nextCtrlTable.Add(this.Rate_Clear_Btn.Name,					this.Cancel_Button);		// �f�t�H���g�ݒ�F����{�^��
            // �폜�{�^��
            this._nextCtrlTable.Add(this.Rate_LogicalDel_Btn.Name,				this.Rate_Ok_Btn);
            // ���S�폜�{�^��
            this._nextCtrlTable.Add(this.Rate_PhysicalDelBtn.Name,				this.Rate_ReviveBtn);
            // �����{�^��
            this._nextCtrlTable.Add(this.Rate_ReviveBtn.Name,					this.Cancel_Button);
            // �ۑ��{�^��
            this._nextCtrlTable.Add(this.Rate_Ok_Btn.Name,						this.Cancel_Button);
            // ����{�^��
            this._nextCtrlTable.Add(this.Cancel_Button.Name,					this.RateSectionCode_tEdit);

            //==============================
            // �O����
            //==============================
            // �|���ݒ�p�l��
            this._forwardCtrlTable.Add(this.RateSectionCode_tEdit.Name,					this.Cancel_Button);
            this._forwardCtrlTable.Add(this.SectionCode_uButton.Name,				this.RateSectionCode_tEdit);
            this._forwardCtrlTable.Add(this.UnitPriceKind_tComboEditor.Name,		this.SectionCode_uButton);
            this._forwardCtrlTable.Add(this.UnitPriceKindWay_tComboEditor.Name,		this.UnitPriceKind_tComboEditor);
            this._forwardCtrlTable.Add(this.RateSettingDivide_tEdit.Name,			this.UnitPriceKindWay_tComboEditor);
            this._forwardCtrlTable.Add(this.RateSettingDivide_uButton.Name,			this.RateSettingDivide_tEdit);

            // �P�i�ݒ�p�l��
            this._forwardCtrlTable.Add(this.GoodsMakerCd_tNedit.Name,				this.RateSettingDivide_uButton);
            this._forwardCtrlTable.Add(this.GoodsMakerCd_uButton.Name,				this.GoodsMakerCd_tNedit);
            this._forwardCtrlTable.Add(this.GoodsNoCd_tEdit.Name,					this.GoodsMakerCd_uButton);
            this._forwardCtrlTable.Add(this.GoodsNo_uButton.Name,					this.GoodsNoCd_tEdit);

            // ���iG�ݒ�p�l��
            this._forwardCtrlTable.Add(this.GoodsMakerCd_Grp_tNedit.Name,			this.RateSettingDivide_uButton);
            this._forwardCtrlTable.Add(this.GoodsMakerCd_Grp_uButton.Name,			this.GoodsMakerCd_Grp_tNedit);
            this._forwardCtrlTable.Add(this.GoodsRateRankCd_Grp_tEdit.Name,			this.GoodsMakerCd_Grp_uButton);
            this._forwardCtrlTable.Add(this.LargeGoodsGanreCode_Grp_tEdit.Name,		this.GoodsRateRankCd_Grp_tEdit);
            this._forwardCtrlTable.Add(this.LargeGoodsGanreCode_Grp_uButton.Name,	this.LargeGoodsGanreCode_Grp_tEdit);
            this._forwardCtrlTable.Add(this.MediumGoodsGanreCode_Grp_tEdit.Name,	this.LargeGoodsGanreCode_Grp_uButton);
            this._forwardCtrlTable.Add(this.MediumGoodsGanreCode_Grp_uButton.Name,	this.MediumGoodsGanreCode_Grp_tEdit);
            this._forwardCtrlTable.Add(this.DetailGoodsGanreCode_Grp_tEdit.Name,	this.MediumGoodsGanreCode_Grp_uButton);
            this._forwardCtrlTable.Add(this.DetailGoodsGanreCode_Grp_uButton.Name,	this.DetailGoodsGanreCode_Grp_tEdit);
            this._forwardCtrlTable.Add(this.EnterpriseGanreCode_Grp_tComboEditor.Name, this.DetailGoodsGanreCode_Grp_uButton);
            this._forwardCtrlTable.Add(this.BLGoodsCode_Grp_tNedit.Name,			this.EnterpriseGanreCode_Grp_tComboEditor);
            this._forwardCtrlTable.Add(this.BLGoodsCode_Grp_uButton.Name,			this.BLGoodsCode_Grp_tNedit);

            // �����ݒ�p�l��
            this._forwardCtrlTable.Add(this.CustomerCode_tNedit.Name,				this.CustomerCode_tNedit);	// �f�t�H���g�F�������g
            this._forwardCtrlTable.Add(this.CustomerCode_uButton.Name,				this.CustomerCode_tNedit);
            this._forwardCtrlTable.Add(this.CustRateGrpCode_tComboEditor.Name,		this.CustRateGrpCode_tComboEditor);
            this._forwardCtrlTable.Add(this.SupplierCd_tNedit.Name,					this.CustRateGrpCode_tComboEditor);
            this._forwardCtrlTable.Add(this.SupplierCd_uButton.Name,				this.SupplierCd_tNedit);
            this._forwardCtrlTable.Add(this.SuppRateGrpCode_tComboEditor.Name,		this.SupplierCd_uButton);

            // �V�|���ݒ�p�l��
            this._forwardCtrlTable.Add(this.NewRateStartDate_tDateEdit.Name,		this.Rate_uTabControl);
            this._forwardCtrlTable.Add(this.NewPrice_tNedit.Name,					this.NewRateStartDate_tDateEdit);
            this._forwardCtrlTable.Add(this.NewPriceDiv_tComboEditor.Name,			this.NewPrice_tNedit);
            this._forwardCtrlTable.Add(this.NewUnPrcCalcDiv_tComboEditor.Name,		this.NewPriceDiv_tComboEditor);
            this._forwardCtrlTable.Add(this.NewRate_tNedit.Name,					this.NewUnPrcCalcDiv_tComboEditor);
            this._forwardCtrlTable.Add(this.NewUnPrcFracProcUnit_tNedit.Name,		this.NewRate_tNedit);
            this._forwardCtrlTable.Add(this.NewUnPrcFracProcDiv_tComboEditor.Name,	this.NewUnPrcFracProcUnit_tNedit);
            this._forwardCtrlTable.Add(this.NewBargainCd_tComboEditor.Name,			this.NewUnPrcFracProcDiv_tComboEditor);

            // �V�|�������|���{�^��
            this._forwardCtrlTable.Add(this.CopyToOldFromNewbtn.Name,				this.NewBargainCd_tComboEditor);

            // ���|���ݒ�p�l��
            this._forwardCtrlTable.Add(this.OldRateStartDate_tDateEdit.Name,		this.CopyToOldFromNewbtn);
            this._forwardCtrlTable.Add(this.OldPrice_tNedit.Name,					this.OldRateStartDate_tDateEdit);
            this._forwardCtrlTable.Add(this.OldPriceDiv_tComboEditor.Name,			this.OldPrice_tNedit);
            this._forwardCtrlTable.Add(this.OldUnPrcCalcDiv_tComboEditor.Name,		this.OldPriceDiv_tComboEditor);
            this._forwardCtrlTable.Add(this.OldRate_tNedit.Name,					this.OldUnPrcCalcDiv_tComboEditor);
            this._forwardCtrlTable.Add(this.OldUnPrcFracProcUnit_tNedit.Name,		this.OldRate_tNedit);
            this._forwardCtrlTable.Add(this.OldUnPrcFracProcDiv_tComboEditor.Name,	this.OldUnPrcFracProcUnit_tNedit);
            this._forwardCtrlTable.Add(this.OldBargainCd_tComboEditor.Name,			this.OldUnPrcFracProcDiv_tComboEditor);
			
            // �����{�^��
            this._forwardCtrlTable.Add(this.Search_uButton.Name,					this.RateSettingDivide_uButton);	// �f�t�H���g�ݒ�F�|���ݒ�敪�K�C�h
            // �|���^�u
            this._forwardCtrlTable.Add(this.Rate_uTabControl.Name,					this.RateSettingDivide_uButton);	// �f�t�H���g�ݒ�F�|���ݒ�敪�K�C�h
            // ����{�^��
            this._forwardCtrlTable.Add(this.Rate_Clear_Btn.Name,					this.Rate_uTabControl);				// �f�t�H���g�ݒ�F�|���^�u
            // �폜�{�^��
            this._forwardCtrlTable.Add(this.Rate_LogicalDel_Btn.Name,				this.Rate_Clear_Btn);
            // ���S�폜�{�^��
            this._forwardCtrlTable.Add(this.Rate_PhysicalDelBtn.Name,				this.Rate_Clear_Btn);
            // �����{�^��
            this._forwardCtrlTable.Add(this.Rate_ReviveBtn.Name,					this.Rate_PhysicalDelBtn);
            // �ۑ��{�^��
            this._forwardCtrlTable.Add(this.Rate_Ok_Btn.Name,						this.Rate_Clear_Btn);				// �f�t�H���g�ݒ�F����{�^��
            // ����{�^��
            this._forwardCtrlTable.Add(this.Cancel_Button.Name,						this.Rate_Clear_Btn);				// �f�t�H���g�ݒ�F����{�^��
        }
        #endregion �^�u�R���g���[���e�[�u���쐬����

        #region �l�N�X�g�R���g���[���擾����
        /// <summary>
        /// �l�N�X�g�R���g���[���擾����
        /// </summary>
        /// <param name="prevCtrl">���݂̃R���g���[��</param>
        /// <returns>���̃R���g���[��</returns>
        /// <br>Note       : �l�N�X�g�R���g���[�����擾���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.11.06</br>
        private Control GetNextControl(Control prevCtrl)
        {
            Control control = null;
            try
            {
                object hashKey = null;
                //--------------------------
                // �|���ݒ�p�l�������ڐݒ�
                //--------------------------
                // �|���ݒ�敪�K�C�h�����ڐݒ�
                hashKey = this.RateSettingDivide_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true))
                {
                    // �P�i�ݒ�
                    if ((this.GoodsMakerCd_tNedit.Enabled == true) && (this.UnitPriceKindWay_tComboEditor.SelectedIndex == 0))
                    {
                        this._nextCtrlTable[hashKey] = this.GoodsMakerCd_tNedit;
                    }
                    // ���i�O���[�v�ݒ�
                    else if ((this.GoodsMakerCd_Grp_tNedit.Enabled == true) && (this.UnitPriceKindWay_tComboEditor.SelectedIndex == 1))
                    {
                        this._nextCtrlTable[hashKey] = this.GoodsMakerCd_Grp_tNedit;
                    }
                    // �����ݒ�p�l���ݒ�
                    else if (this.Customer_panel.Enabled == true)
                    {
                        NextChkCustomerItem(ref this._nextCtrlTable, 0, hashKey);
                    }
                    else if(this.Search_uButton.Enabled == true)
                    {
                        // �����{�^���ݒ�
                        this._nextCtrlTable[hashKey] = this.Search_uButton;
                    }
                    else
                    {
                        // �|���^�u�ݒ�
                        this._nextCtrlTable[hashKey] = this.Rate_uTabControl;
                    }
                }

                //--------------------------
                // �P�i�ݒ�p�l�������ڐݒ�
                //--------------------------
                // ���i�K�C�h�����ڐݒ�
                hashKey = this.GoodsNo_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.GoodsNo_uButton.Enabled == true))
                {
                    NextChkCustomerItem(ref this._nextCtrlTable, 0, hashKey);
                }

                //----------------------------
                // ���i�f�ݒ�p�l�������ڐݒ�
                //----------------------------
                // ���[�J�[�K�C�h�����ڐݒ�
                hashKey = this.GoodsMakerCd_Grp_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.GoodsMakerCd_Grp_uButton.Enabled == true))
                {
                    NextChkGrpItem(ref this._nextCtrlTable, 1, hashKey);
                }
                // ���i�|���f�����ڐݒ�
                hashKey = this.GoodsRateRankCd_Grp_tEdit.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.GoodsRateRankCd_Grp_tEdit.Enabled == true))
                {
                    NextChkGrpItem(ref this._nextCtrlTable, 2, hashKey);
                }
                // ���i�敪�O���[�v�R�[�h�K�C�h�����ڐݒ�
                hashKey = this.LargeGoodsGanreCode_Grp_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.LargeGoodsGanreCode_Grp_uButton.Enabled == true))
                {
                    NextChkGrpItem(ref this._nextCtrlTable, 3, hashKey);
                }
                // ���i�敪�K�C�h�����ڐݒ�
                hashKey = this.MediumGoodsGanreCode_Grp_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.MediumGoodsGanreCode_Grp_uButton.Enabled == true))
                {
                    NextChkGrpItem(ref this._nextCtrlTable, 4, hashKey);
                }
                // ���i�敪�ڍ׃K�C�h�����ڐݒ�
                hashKey = this.DetailGoodsGanreCode_Grp_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.DetailGoodsGanreCode_Grp_uButton.Enabled == true))
                {
                    NextChkGrpItem(ref this._nextCtrlTable, 5, hashKey);
                }
                // ���Е��ގ����ڐݒ�
                hashKey = this.EnterpriseGanreCode_Grp_tComboEditor.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.EnterpriseGanreCode_Grp_tComboEditor.Enabled == true))
                {
                    NextChkGrpItem(ref this._nextCtrlTable, 6, hashKey);
                }
                // �a�k���i�K�C�h�����ڐݒ�
                hashKey = this.BLGoodsCode_Grp_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.BLGoodsCode_Grp_uButton.Enabled == true))
                {
                    NextChkCustomerItem(ref this._nextCtrlTable, 0, hashKey);
                }
				
                //----------------------------
                // �����ݒ�p�l�������ڐݒ�
                //----------------------------
                // ���Ӑ�K�C�h�����ڐݒ�
                hashKey = this.CustomerCode_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.CustomerCode_uButton.Enabled == true))
                {
                    NextChkCustomerItem(ref this._nextCtrlTable, 1, hashKey);
                }
                // ���Ӑ�|���f�����ڐݒ�
                hashKey = this.CustRateGrpCode_tComboEditor.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.CustRateGrpCode_tComboEditor.Enabled == true))
                {
                    NextChkCustomerItem(ref this._nextCtrlTable, 2, hashKey);
                }
                // �d����K�C�h�����ڐݒ�
                hashKey = this.SupplierCd_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.SupplierCd_uButton.Enabled == true))
                {
                    NextChkCustomerItem(ref this._nextCtrlTable, 3, hashKey);
                }

                // �d����|�������ڐݒ�
                hashKey = this.SuppRateGrpCode_tComboEditor.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.SuppRateGrpCode_tComboEditor.Enabled == true))
                {
                    NextChkCustomerItem(ref this._nextCtrlTable, 4, hashKey);
                }
				
                //----------------------------
                // �V�|���ݒ�p�l�������ڐݒ�
                //----------------------------
                // �V�|���J�n�������ڐݒ�
                hashKey = this.NewRateStartDate_tDateEdit.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.NewRateStartDate_tDateEdit.Enabled == true))
                {
                    if (this.NewPrice_tNedit.Enabled == false)
                    {
                        this._nextCtrlTable[hashKey] = this.NewPriceDiv_tComboEditor;
                    }
                    else
                    {
                        this._nextCtrlTable[hashKey] = this.NewPrice_tNedit;
                    }
                }
				
                //----------------------------
                // ���|���ݒ�p�l�������ڐݒ�
                //----------------------------
                // ���|���J�n�������ڐݒ�
                hashKey = this.OldRateStartDate_tDateEdit.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.OldRateStartDate_tDateEdit.Enabled == true))
                {
                    if (this.OldPrice_tNedit.Enabled == false)
                    {
                        this._nextCtrlTable[hashKey] = this.OldPriceDiv_tComboEditor;
                    }
                    else
                    {
                        this._nextCtrlTable[hashKey] = this.OldPrice_tNedit;
                    }
                }
				
                //------------------
                // �{�^�������ڐݒ�
                //------------------
                // �|���^�u�����ڐݒ�
                hashKey = this.Rate_uTabControl.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.Rate_uTabControl.Enabled == true))
                {
                    if (this.NewRateStartDate_tDateEdit.Enabled == true)
                    {
                        this._nextCtrlTable[hashKey] = this.NewRateStartDate_tDateEdit;
                    }
                    else
                    {
                        this._nextCtrlTable[hashKey] = this.Rate_Clear_Btn;
                    }
                }
				
                // ����{�^�������ڐݒ�
                hashKey = this.Rate_Clear_Btn.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.Rate_Clear_Btn.Enabled == true))
                {
                    if (this.Rate_LogicalDel_Btn.Enabled == true)
                    {
                        this._nextCtrlTable[hashKey] = this.Rate_LogicalDel_Btn;
                    }
                    else if(this.Rate_PhysicalDelBtn.Enabled == true)
                    {
                        this._nextCtrlTable[hashKey] = this.Rate_PhysicalDelBtn;
                    }
                    else if(this.Rate_Ok_Btn.Enabled == true)
                    {
                        this._nextCtrlTable[hashKey] = this.Rate_Ok_Btn;
                    }
                    else
                    {
                        this._nextCtrlTable[hashKey] = this.Cancel_Button;
                    }
                }
				
                // �����ڃC���f�b�N�X�擾
                if (this._nextCtrlTable.ContainsKey(prevCtrl.Name) == true)
                {
                    control = (Control)this._nextCtrlTable[prevCtrl.Name];
                }
            }
            catch(Exception ex)
            {
                TMsgDisp.Show(this,							// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_INFO,			// �G���[���x��
                    ASSEMBLY_ID,							// �A�Z���u��ID
                    ex.Message,								// �\�����郁�b�Z�[�W
                    0,										// �X�e�[�^�X�l
                    MessageBoxButtons.OK);					// �\������{�^��
            }
            return control;
        }
        #endregion �l�N�X�g�R���g���[���擾����

        #region ���i�O���[�v�����ړ��͉۔��菈��
        /// <summary>
        /// ���i�O���[�v�����ړ��͉۔��菈��
        /// </summary>
        /// <param name="sList">�^�u�ړ����䃊�X�g</param>
        /// <param name="num">�`�F�b�N�J�n�ʒu</param>
        /// <param name="hashKey">�n�b�V���L�[</param>
        /// <br>Note       : ���i�O���[�v���ړ��͉ۂ𔻒肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.11.06</br>
        private void NextChkGrpItem(ref SortedList sList, int num, object hashKey)
        {
            // ���[�J�[�R�[�h
            if ((this.GoodsMakerCd_Grp_tNedit.Enabled == true)&&(num == 0))
            {
                sList[hashKey] = this.GoodsMakerCd_Grp_tNedit;
                return;
            }
            // ���i�|�������N
            if ((this.GoodsRateRankCd_Grp_tEdit.Enabled == true)&&(0 <= num)&&(num <= 1))
            {
                sList[hashKey] = this.GoodsRateRankCd_Grp_tEdit;
                return;
            }
            // ���i�敪�O���[�v�R�[�h
            if ((this.LargeGoodsGanreCode_Grp_tEdit.Enabled == true)&&(0 <= num)&&(num <= 2))
            {
                sList[hashKey] = this.LargeGoodsGanreCode_Grp_tEdit;
                return;
            }
            // ���i�敪�R�[�h
            if ((this.MediumGoodsGanreCode_Grp_tEdit.Enabled == true)&&(0 <= num)&&(num <= 3))
            {
                sList[hashKey] = this.MediumGoodsGanreCode_Grp_tEdit;
                return;
            }
            // ���i�敪�ڍ׃R�[�h
            if ((this.DetailGoodsGanreCode_Grp_tEdit.Enabled == true)&&(0 <= num)&&(num <= 4))
            {
                sList[hashKey] = this.DetailGoodsGanreCode_Grp_tEdit;
                return;
            }
            // ���Е���
            if ((this.EnterpriseGanreCode_Grp_tComboEditor.Enabled == true)&&(0 <= num)&&(num <= 5))
            {
                sList[hashKey] = this.EnterpriseGanreCode_Grp_tComboEditor;
                return;
            }
            // �a�k���i�R�[�h
            if ((this.BLGoodsCode_Grp_tNedit.Enabled == true)&&(0 <= num) && (num <= 6))
            {
                sList[hashKey] = this.BLGoodsCode_Grp_tNedit;
                return;
            }
            // �����p�l���ֈړ�
            if((0 <= num) && (num <= 7))
            {
                NextChkCustomerItem(ref sList, 0, hashKey);
            }
        }
        #endregion ���i�O���[�v�����ړ��͉۔��菈��

        #region ����掟���ړ��͉۔��菈��
        /// <summary>
        /// ����掟���ړ��͉۔��菈��
        /// </summary>
        /// <param name="sList">�^�u�ړ����䃊�X�g</param>
        /// <param name="num">�`�F�b�N�J�n�ʒu</param>
        /// <param name="hashKey">�n�b�V���L�[</param>
        /// <br>Note       : ����捀�ړ��͉ۂ𔻒肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.11.06</br>
        private void NextChkCustomerItem(ref SortedList sList, int num, object hashKey)
        {
            // ���Ӑ�R�[�h
            if ((this.CustomerCode_tNedit.Enabled == true)&&(num == 0))
            {
                sList[hashKey] = this.CustomerCode_tNedit;
                return;
            }
            // ���Ӑ�|���f
            if ((this.CustRateGrpCode_tComboEditor.Enabled == true)&&(0 <= num)&&(num <= 1))
            {
                sList[hashKey] = this.CustRateGrpCode_tComboEditor;
                return;
            }
            // �d����R�[�h
            if ((this.SupplierCd_tNedit.Enabled == true)&&(0 <= num)&&(num <= 2))
            {
                sList[hashKey] = this.SupplierCd_tNedit;
                return;
            }
            // �d����|���f
            if ((this.SuppRateGrpCode_tComboEditor.Enabled == true)&&(0 <= num)&&(num <= 3))
            {
                sList[hashKey] = this.SuppRateGrpCode_tComboEditor;
                return;
            }
            // �����{�^��
            if ((this.Search_uButton.Enabled == true)&&(0 <= num)&&(num <= 4))
            {
                sList[hashKey] = this.Search_uButton;
                return;
            }
        }
        #endregion ����掟���ړ��͉۔��菈��

        #region �t�H���[�h�R���g���[���擾����
        /// <summary>
        /// �t�H���[�h�R���g���[���擾����
        /// </summary>
        /// <param name="prevCtrl">���݂̃R���g���[��</param>
        /// <returns>�O�̃R���g���[��</returns>
        /// <br>Note       : �t�H���[�h�R���g���[�����擾���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.11.06</br>
        private Control GetForwardControl(Control prevCtrl)
        {
            Control control = null;
            try
            {
                object hashKey = null;
                int unitFlag = 0;	// 0:�P�i, 1:���iG
				
                //------------------
                // �P�i�E���i�f����
                //------------------
                // �P�i�ݒ�
                if (this.UnitPriceKindWay_tComboEditor.SelectedIndex == 0)
                {
                    unitFlag = 0;
                }
                // ���i�O���[�v�ݒ�
                else
                {
                    unitFlag = 1;
                }
				
                //----------------------------
                // ���i�f�ݒ�p�l���O���ڐݒ�
                //----------------------------
                // �a�k���i�R�[�h�O���ڐݒ�
                hashKey = this.BLGoodsCode_Grp_tNedit.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.BLGoodsCode_Grp_tNedit.Enabled == true))
                {
                    ForwardChkGrpItem(ref this._forwardCtrlTable, 1, hashKey);
                }
                // ���Е��ޑO���ڐݒ�
                hashKey = this.EnterpriseGanreCode_Grp_tComboEditor.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.EnterpriseGanreCode_Grp_tComboEditor.Enabled == true))
                {
                    ForwardChkGrpItem(ref this._forwardCtrlTable, 2, hashKey);
                }
                // ���i�敪�ڍ׃R�[�h�O���ڐݒ�
                hashKey = this.DetailGoodsGanreCode_Grp_tEdit.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.DetailGoodsGanreCode_Grp_tEdit.Enabled == true))
                {
                    ForwardChkGrpItem(ref this._forwardCtrlTable, 3, hashKey);
                }
                // ���i�敪�R�[�h�O���ڐݒ�
                hashKey = this.MediumGoodsGanreCode_Grp_tEdit.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.MediumGoodsGanreCode_Grp_tEdit.Enabled == true))
                {
                    ForwardChkGrpItem(ref this._forwardCtrlTable, 4, hashKey);
                }
                // ���i�敪�O���[�v�R�[�h�O���ڐݒ�
                hashKey = this.LargeGoodsGanreCode_Grp_tEdit.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.LargeGoodsGanreCode_Grp_tEdit.Enabled == true))
                {
                    ForwardChkGrpItem(ref this._forwardCtrlTable, 5, hashKey);
                }
                // ���i�|���f�O���ڐݒ�
                hashKey = this.GoodsRateRankCd_Grp_tEdit.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.GoodsRateRankCd_Grp_tEdit.Enabled == true))
                {
                    ForwardChkGrpItem(ref this._forwardCtrlTable, 6, hashKey);
                }
                // ���[�J�[�R�[�h�O���ڐݒ�
                hashKey = this.GoodsMakerCd_Grp_tNedit.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.GoodsMakerCd_Grp_tNedit.Enabled == true))
                {
                    ForwardChkGrpItem(ref this._forwardCtrlTable, 7, hashKey);
                }

                //----------------------------
                // �����ݒ�p�l�������ڐݒ�
                //----------------------------
                // ���Ӑ�R�[�h�O���ڐݒ�
                hashKey = this.CustomerCode_tNedit.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.CustomerCode_tNedit.Enabled == true))
                {
                    ForwardChkCustomerItem(ref this._forwardCtrlTable, 4, hashKey, unitFlag);
                }
                // ���Ӑ�|���f�O���ڐݒ�
                hashKey = this.CustRateGrpCode_tComboEditor.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.CustRateGrpCode_tComboEditor.Enabled == true))
                {
                    ForwardChkCustomerItem(ref this._forwardCtrlTable, 3, hashKey, unitFlag);
                }
                // �d����R�[�h�O���ڐݒ�
                hashKey = this.SupplierCd_tNedit.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.SupplierCd_tNedit.Enabled == true))
                {
                    ForwardChkCustomerItem(ref this._forwardCtrlTable, 2, hashKey, unitFlag);
                }
                // �d����|���f�O���ڐݒ�
                hashKey = this.SuppRateGrpCode_tComboEditor.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.SuppRateGrpCode_tComboEditor.Enabled == true))
                {
                    ForwardChkCustomerItem(ref this._forwardCtrlTable, 1, hashKey, unitFlag);
                }

                //----------------------------
                // �V�|���ݒ�p�l���O���ڐݒ�
                //----------------------------
                // �V����i�敪�O���ڐݒ�
                hashKey = this.NewPriceDiv_tComboEditor.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.NewPrice_tNedit.Enabled == false))
                {
                    this._forwardCtrlTable[hashKey] = this.NewRateStartDate_tDateEdit;
                }

                //----------------------------
                // ���|���ݒ�p�l���O���ڐݒ�
                //----------------------------
                // ������i�敪�O���ڐݒ�
                hashKey = this.OldPriceDiv_tComboEditor.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.OldPrice_tNedit.Enabled == false))
                {
                    this._forwardCtrlTable[hashKey] = this.OldRateStartDate_tDateEdit;
                }

                //------------------
                // �{�^�������ڐݒ�
                //------------------
                // �����{�^���O���ڐݒ�
                hashKey = this.Search_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.Search_uButton.Enabled == true))
                {
                    ForwardChkCustomerItem(ref this._forwardCtrlTable, 0, hashKey, unitFlag);
                }
				
                // �|���^�u�O���ڐݒ�
                hashKey = this.Rate_uTabControl.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.Rate_uTabControl.Enabled == true))
                {
                    if(this.Search_uButton.Enabled == true)
                    {
                        this._forwardCtrlTable[hashKey] = this.Search_uButton;
                    }
                    else
                    {
                        this._forwardCtrlTable[hashKey] = RateSettingDivide_uButton;
                    }
					
                }
				
                // ����{�^���O���ڐݒ�
                hashKey = this.Rate_Clear_Btn.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.Rate_Clear_Btn.Enabled == true))
                {
                    if(this.OldBargainCd_tComboEditor.Enabled == true)
                    {
                        this._forwardCtrlTable[hashKey] = this.OldBargainCd_tComboEditor;
                    }
                    else
                    {
                        this._forwardCtrlTable[hashKey] = this.Rate_uTabControl;
                    }
                }
				
                // �ۑ��{�^���O���ڐݒ�
                hashKey = this.Rate_Ok_Btn.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.Rate_Ok_Btn.Enabled == true))
                {
                    if(this.Rate_LogicalDel_Btn.Enabled == true)
                    {
                        this._forwardCtrlTable[hashKey] = this.Rate_LogicalDel_Btn;
                    }
                    else
                    {
                        this._forwardCtrlTable[hashKey] = this.Rate_Clear_Btn;
                    }
                }
				
                // ����{�^���O���ڐݒ�
                hashKey = this.Cancel_Button.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.Cancel_Button.Enabled == true))
                {
                    if(this.Rate_Ok_Btn.Enabled == true)
                    {
                        this._forwardCtrlTable[hashKey] = this.Rate_Ok_Btn;
                    }
                    else if(this.Rate_ReviveBtn.Enabled == true)
                    {
                        this._forwardCtrlTable[hashKey] = this.Rate_ReviveBtn;
                    }
                    else
                    {
                        this._forwardCtrlTable[hashKey] = this.Rate_Clear_Btn;
                    }
                }
				
                // �O���ڃC���f�b�N�X�擾
                if (this._forwardCtrlTable.ContainsKey(prevCtrl.Name) == true)
                {
                    control = (Control)this._forwardCtrlTable[prevCtrl.Name];
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(this,							// �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_INFO,			// �G���[���x��
                    ASSEMBLY_ID,							// �A�Z���u��ID
                    ex.Message,								// �\�����郁�b�Z�[�W
                    0,										// �X�e�[�^�X�l
                    MessageBoxButtons.OK);					// �\������{�^��
            }
            return control;
        }
        #endregion �t�H���[�h�R���g���[���擾����

        #region ���i�O���[�v�O���ړ��͉۔��菈��
        /// <summary>
        /// ���i�O���[�v�O���ړ��͉۔��菈��
        /// </summary>
        /// <param name="sList">�^�u�ړ����䃊�X�g</param>
        /// <param name="num">�`�F�b�N�J�n�ʒu</param>
        /// <param name="hashKey">�n�b�V���L�[</param>
        /// <br>Note       : ���i�O���[�v���ړ��͉ۂ𔻒肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.11.06</br>
        private void ForwardChkGrpItem(ref SortedList sList, int num, object hashKey)
        {
            // �a�k���i�K�C�h
            if ((this.BLGoodsCode_Grp_uButton.Enabled == true) && (num == 0))
            {
                sList[hashKey] = this.BLGoodsCode_Grp_uButton;
                return;
            }
            // ���Е���
            if ((this.EnterpriseGanreCode_Grp_tComboEditor.Enabled == true) && (0 <= num) && (num <= 1))
            {
                sList[hashKey] = this.EnterpriseGanreCode_Grp_tComboEditor;
                return;
            }
            // ���i�敪�ڍ׃K�C�h
            if ((this.DetailGoodsGanreCode_Grp_uButton.Enabled == true) && (0 <= num) && (num <= 2))
            {
                sList[hashKey] = this.DetailGoodsGanreCode_Grp_uButton;
                return;
            }
            // ���i�敪�K�C�h
            if ((this.MediumGoodsGanreCode_Grp_uButton.Enabled == true) && (0 <= num) && (num <= 3))
            {
                sList[hashKey] = this.MediumGoodsGanreCode_Grp_uButton;
                return;
            }
            // ���i�敪�O���[�v�R�[�h�K�C�h
            if ((this.LargeGoodsGanreCode_Grp_uButton.Enabled == true) && (0 <= num) && (num <= 4))
            {
                sList[hashKey] = this.LargeGoodsGanreCode_Grp_uButton;
                return;
            }
            // ���i�|�������N
            if ((this.GoodsRateRankCd_Grp_tEdit.Enabled == true) && (0 <= num) && (num <= 5))
            {
                sList[hashKey] = this.GoodsRateRankCd_Grp_tEdit;
                return;
            }
            // ���[�J�[�K�C�h
            if ((this.GoodsMakerCd_Grp_uButton.Enabled == true) && (0 <= num) && (num <= 6))
            {
                sList[hashKey] = this.GoodsMakerCd_Grp_uButton;
                return;
            }
            // �|���ݒ�p�l���ֈړ�
            if((0 <= num) && (num <= 7))
            {
                sList[hashKey] = this.RateSettingDivide_uButton;
                return;
            }
        }
        #endregion ���i�O���[�v�O���ړ��͉۔��菈��

        #region �����O���ړ��͉۔��菈��
        /// <summary>
        /// �����O���ړ��͉۔��菈��
        /// </summary>
        /// <param name="sList">�^�u�ړ����䃊�X�g</param>
        /// <param name="num">�`�F�b�N�J�n�ʒu</param>
        /// <param name="hashKey">�n�b�V���L�[</param>
        /// <param name="unitFlag">�P�i�E���i�f���ʃt���O�i0:�P�i, 1:���iG�j</param>
        /// <br>Note       : ����捀�ړ��͉ۂ𔻒肵�܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.11.06</br>
        private void ForwardChkCustomerItem(ref SortedList sList, int num, object hashKey, int unitFlag)
        {
            // �d����|���f
            if ((this.SuppRateGrpCode_tComboEditor.Enabled == true) && (num == 0))
            {
                sList[hashKey] = this.SuppRateGrpCode_tComboEditor;
                return;
            }
            // �d����K�C�h
            if ((this.SupplierCd_uButton.Enabled == true) && (0 <= num) && (num <= 1))
            {
                sList[hashKey] = this.SupplierCd_uButton;
                return;
            }
            // ���Ӑ�|���f
            if ((this.CustRateGrpCode_tComboEditor.Enabled == true) && (0 <= num) && (num <= 2))
            {
                sList[hashKey] = this.CustRateGrpCode_tComboEditor;
                return;
            }
            // ���Ӑ�K�C�h
            if ((this.CustomerCode_uButton.Enabled == true) && (0 <= num) && (num <= 3))
            {
                sList[hashKey] = this.CustomerCode_uButton;
                return;
            }
            // �P�i�E���i�f�ݒ蔻��
            if((0 <= num) && (num <= 4))
            {
                // �P�i�ݒ�
                if(unitFlag == 0)
                {
                    sList[hashKey] = this.GoodsNo_uButton;
                }
                // ���i�f�ݒ�
                else
                {
                    ForwardChkGrpItem(ref sList, 0, hashKey);
                }
            }
        }
        #endregion �����O���ړ��͉۔��菈��

        /// <summary>
        /// �����^�C�v�擾����
        /// </summary>
        /// <param name="inputCode">���͂��ꂽ�R�[�h</param>
        /// <param name="searchCode">�����p�R�[�h�i*�������j</param>
        /// <returns>0:���S��v���� 1:�O����v���� 2:�����v���� 3:�B������</returns>
        /// <remarks>
        /// Note			:	����������@���擾���鏈�����s���܂��B<br />
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.11.08</br>
        /// </remarks>
        public int GetSearchType(string inputCode, out string searchCode)
        {
            searchCode = inputCode;
            if (String.IsNullOrEmpty(inputCode)) return 0;

            if (inputCode.Contains("*"))
            {
                searchCode = inputCode.Replace("*", "");
                string firstString = inputCode.Substring(0, 1);
                string lastString = inputCode.Substring(inputCode.Length - 1, 1);

                if ((firstString == "*") && (lastString == "*"))
                {
                    return 3;
                }
                else if (firstString == "*")
                {
                    return 2;
                }
                else if (lastString == "*")
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                // *�����݂��Ȃ����ߊ��S��v����
                return 0;
            }
        }

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.11.08</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                this.Text,							// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
		
        /// <summary>
        /// ���i�R�[�h�K�C�h�N������
        /// </summary>
        /// <param name="goodsMakerCd_tNedit">���i�R�[�h�R���|�[�l���g</param>
        /// <remarks>
        /// <br>Note       : ���i�R�[�h�K�C�h���N�����܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.31</br>
        /// </remarks>
        private void GoodsNoGuide(TNedit goodsMakerCd_tNedit)
        {
            MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
            GoodsUnitData goodsUnitData = null;
            GoodsCndtn goodsCndtn = new GoodsCndtn();
            goodsCndtn.EnterpriseCode = this._enterpriseCode;

            //----- ueno add ---------- start 2008.03.04
            bool autoSearch = false;
            //----- ueno add ---------- end 2008.03.04

            //------------------
            // ���i�R�[�h�K�C�h
            //------------------
            if (goodsMakerCd_tNedit.Text != "")
            {
                // ���[�J�[�R�[�h�ݒ�
                goodsCndtn.GoodsMakerCd = goodsMakerCd_tNedit.GetInt();

                //----- ueno add ---------- start 2008.03.04
                // ���[�J�[���̐ݒ�
                goodsCndtn.MakerName = GoodsMakerCdNm_tEdit.Text.TrimEnd();
                autoSearch = true;
                //----- ueno add ---------- end 2008.03.04
            }

            //----- ueno add ---------- start 2008.03.04
            // ���������ɋ��_���Z�b�g
            if (this.RateSectionCode_tEdit.Text != "")
            {
                goodsCndtn.SectionCode = this.RateSectionCode_tEdit.Text;
            }
            //----- ueno add ---------- end 2008.03.04

            //----- ueno upd ---------- start 2008.03.04
            // ���������̓��[�J�[�R�[�h�����݂���ꍇ�݂̂Ƃ���
            DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, autoSearch, goodsCndtn, out goodsUnitData);
            //DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, true, goodsCndtn, out goodsUnitData);
            //----- ueno upd ---------- end 2008.03.04

            if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
            {
                // �ύX��������Ώ������Ȃ�
                if (string.Equals(goodsUnitData.GoodsNo, this._searchRate.GoodsNo) == true)
                {
                    return;
                }

                DispSetStatus dispSetStatus = editChgDataChk("���i�R�[�h", goodsUnitData.GoodsNo, this._searchRate.GoodsNo);
                if (dispSetStatus == DispSetStatus.Update)
                {
                    this.GoodsNoCd_tEdit.Text = goodsUnitData.GoodsNo;
                    this.GoodsNoNm_tEdit.Text = goodsUnitData.GoodsName;

                    // ���݃f�[�^�ۑ�
                    this._searchRate.GoodsNo = this.GoodsNoCd_tEdit.Text;
					
                    //--------------------------------------
                    // ���i�R�[�h�ɑ΂��郁�[�J�[�R�[�h�ݒ�
                    //--------------------------------------
                    MakerUMnt makerUMnt = null;

                    // �f�[�^���݃`�F�b�N
                    int ret = this._goodsAcs.GetMaker(this._enterpriseCode, goodsUnitData.GoodsMakerCd, out makerUMnt);

                    if (ret == 0)
                    {
                        // ���[�J�[�R�[�h���ݒ�
                        this.GoodsMakerCd_tNedit.SetInt(goodsUnitData.GoodsMakerCd);
                        this.GoodsMakerCdNm_tEdit.Text = makerUMnt.MakerName;

                        // ���݃f�[�^�ۑ�
                        this._searchRate.GoodsMakerCd = this.GoodsMakerCd_tNedit.GetInt();
                    }
                }
            }
        }

        /// <summary>
        /// ���i�敪�O���[�v�R�[�h�K�C�h�N������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�敪�O���[�v�R�[�h�K�C�h���N�����܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.31</br>
        /// </remarks>
        private void LargeGoodsGanreCodeGuide()
        {
            LGoodsGanre lGoodsGanre = null;

            if (this._lGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, out lGoodsGanre, 1) == 0)
            {
                // �ύX��������Ώ������Ȃ�
                if (string.Equals(lGoodsGanre.LargeGoodsGanreCode, this._searchRate.LargeGoodsGanreCode) == true)
                {
                    return;
                }

                DispSetStatus dispSetStatus = editChgDataChk("���i�敪�O���[�v�R�[�h", lGoodsGanre.LargeGoodsGanreCode, this._searchRate.LargeGoodsGanreCode);
                if (dispSetStatus == DispSetStatus.Update)
                {
                    // ���i�敪�O���[�v�R�[�h
                    this.LargeGoodsGanreCode_Grp_tEdit.Text = lGoodsGanre.LargeGoodsGanreCode;
                    this.LargeGoodsGanreCodeNm_Grp_tEdit.Text = lGoodsGanre.LargeGoodsGanreName;

                    // ���݃f�[�^�ۑ�
                    this._searchRate.LargeGoodsGanreCode = this.LargeGoodsGanreCode_Grp_tEdit.Text;

                    // ���i�敪�����͉̏ꍇ
                    if (this.MediumGoodsGanreCode_Grp_tEdit.Enabled == true)
                    {
                        // ���i�敪�K�C�h�N��
                        MediumGoodsGanreCodeGuide();
                    }
                }
            }
            else
            {
                // ���i�敪�O���[�v�R�[�h�N���A
                this.LargeGoodsGanreCode_Grp_tEdit.Clear();
                this.LargeGoodsGanreCodeNm_Grp_tEdit.Clear();

                // ���݃f�[�^�N���A
                this._searchRate.LargeGoodsGanreCode = "";
            }
        }
		
        /// <summary>
        /// ���i�敪�K�C�h�N������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�敪�K�C�h���N�����܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.31</br>
        /// </remarks>
        private void MediumGoodsGanreCodeGuide()
        {
            MGoodsGanre mGoodsGanre = null;
            string lGoodsGanre = this.LargeGoodsGanreCode_Grp_tEdit.Text;	// �啪�ސݒ�

            if (this._mGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, lGoodsGanre, out mGoodsGanre, 1) == 0)
            {
                // �ύX��������Ώ������Ȃ�
                if (string.Equals(mGoodsGanre.MediumGoodsGanreCode, this._searchRate.MediumGoodsGanreCode) == true)
                {
                    return;
                }

                DispSetStatus dispSetStatus = editChgDataChk("���i�敪�R�[�h", mGoodsGanre.MediumGoodsGanreCode, this._searchRate.MediumGoodsGanreCode);
                if (dispSetStatus == DispSetStatus.Update)
                {
                    // ���i�敪
                    this.MediumGoodsGanreCode_Grp_tEdit.Text = mGoodsGanre.MediumGoodsGanreCode;
                    this.MediumGoodsGanreCodeNm_Grp_tEdit.Text = mGoodsGanre.MediumGoodsGanreName;

                    // ���݃f�[�^�ۑ�
                    this._searchRate.MediumGoodsGanreCode = this.MediumGoodsGanreCode_Grp_tEdit.Text;

                    // ���i�敪�ڍ׃R�[�h�����͉̏ꍇ
                    if (this.DetailGoodsGanreCode_Grp_tEdit.Enabled == true)
                    {
                        // ���i�敪�ڍ׃K�C�h�N��
                        DetailGoodsGanreCodeGuide();
                    }
                }
            }
            else
            {
                // ���i�敪�N���A
                this.MediumGoodsGanreCode_Grp_tEdit.Clear();
                this.MediumGoodsGanreCodeNm_Grp_tEdit.Clear();

                // ���i�敪�ڍ׃N���A
                this.DetailGoodsGanreCode_Grp_tEdit.Clear();
                this.DetailGoodsGanreCodeNm_Grp_tEdit.Clear();
				
                // ���݃f�[�^�N���A
                this._searchRate.MediumGoodsGanreCode = "";
                this._searchRate.DetailGoodsGanreCode = "";
            }
        }
		
        /// <summary>
        /// ���i�敪�ڍ׃K�C�h�N������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�敪�ڍ׃K�C�h���N�����܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.31</br>
        /// </remarks>
        private void DetailGoodsGanreCodeGuide()
        {
            DGoodsGanre dGoodsGanre = null;

            if (this._dGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, out dGoodsGanre, 1) == 0)
            {
                // �ύX��������Ώ������Ȃ�
                if (string.Equals(dGoodsGanre.DetailGoodsGanreCode, this._searchRate.DetailGoodsGanreCode) == true)
                {
                    return;
                }

                DispSetStatus dispSetStatus = editChgDataChk("���i�R�[�h", dGoodsGanre.DetailGoodsGanreCode, this._searchRate.DetailGoodsGanreCode);
                if (dispSetStatus == DispSetStatus.Update)
                {
                    // ���i�敪�O���[�v�R�[�h
                    this.LargeGoodsGanreCode_Grp_tEdit.Text = dGoodsGanre.LargeGoodsGanreCode;
                    this.LargeGoodsGanreCodeNm_Grp_tEdit.Text = dGoodsGanre.LargeGoodsGanreName;
                    // ���i�敪
                    this.MediumGoodsGanreCode_Grp_tEdit.Text = dGoodsGanre.MediumGoodsGanreCode;
                    this.MediumGoodsGanreCodeNm_Grp_tEdit.Text = dGoodsGanre.MediumGoodsGanreName;
                    // ���i�敪�ڍ�
                    this.DetailGoodsGanreCode_Grp_tEdit.Text = dGoodsGanre.DetailGoodsGanreCode;
                    this.DetailGoodsGanreCodeNm_Grp_tEdit.Text = dGoodsGanre.DetailGoodsGanreName;

                    // ���݃f�[�^�ۑ�
                    this._searchRate.LargeGoodsGanreCode = this.LargeGoodsGanreCode_Grp_tEdit.Text;
                    this._searchRate.MediumGoodsGanreCode = this.MediumGoodsGanreCode_Grp_tEdit.Text;
                    this._searchRate.DetailGoodsGanreCode = this.DetailGoodsGanreCode_Grp_tEdit.Text;
                }
            }
            else
            {
                // ���i�敪�ڍ׃N���A
                this.DetailGoodsGanreCode_Grp_tEdit.Clear();
                this.DetailGoodsGanreCodeNm_Grp_tEdit.Clear();

                // ���݃f�[�^�N���A
                this._searchRate.DetailGoodsGanreCode = "";
            }
        }

        //----- ueno del ---------- start 2008.03.31
        ////----- ueno add ---------- start 2008.03.28
        ///// <summary>
        ///// ���_�R�[�h�[�����ߏ���
        ///// </summary>
        ///// <param name="rateSectionCode_tEdit">���_�R�[�h</param>
        ///// <remarks>
        ///// <br>Note       : ���_�R�[�h���[�����߂��܂��B</br>
        ///// <br>Programer  : 30167 ���@�O�M</br>
        ///// <br>Date       : 2008.03.28</br>
        ///// </remarks>
        //private void ZeroFillSectionCode(ref TEdit rateSectionCode_tEdit)
        //{
        //    string wkStr = rateSectionCode_tEdit.Text;
			
        //    rateSectionCode_tEdit.Text = wkStr.PadLeft(6, '0');
        //}
        ////----- ueno add ---------- end 2008.03.28
        //----- ueno del ---------- end 2008.03.31

        //----- ueno add ---------- start 2008.03.31
        /// <summary>
        /// �[�����ߌ�e�L�X�g�擾��������
        /// </summary>
        /// <param name="fullText">���͍ς݃e�L�X�g</param>
        /// <param name="columnCount">���͉\����</param>
        /// <returns>�[�����߂����e�L�X�g</returns>
        /// <br>Note       : ��������[�����߂��܂��B</br>
        /// <br>Programer  : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.03.31</br>
        private static string GetZeroPaddedTextProc(string fullText, int columnCount)
        {
            if (fullText.Trim() != string.Empty)
            {
                // �[���l�ߏ���
                return fullText.PadLeft(columnCount, '0');
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// �����񁨐��l�ϊ�
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        static int GetIntFromString(string str, int defaultValue)
        {
            try
            {
                return Int32.Parse(str);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// �[�����߃L�����Z����e�L�X�g�擾��������
        /// </summary>
        /// <param name="fullText">���͍ς݃e�L�X�g</param>
        /// <returns>�[�����߃L�����Z�������e�L�X�g</returns>
        /// <br>Note       : �����񂩂�[�����폜���܂��B</br>
        /// <br>Programer  : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.03.31</br>
        private static string GetZeroPadCanceledTextProc(string fullText)
        {
            if (fullText.Trim() != string.Empty)
            {
                int cnt = 0;
                string wkStr = fullText;

                // �擪�̃[���l�߂��폜
                while (fullText.StartsWith("0"))
                {
                    fullText = fullText.Substring(1, fullText.Length - 1);
                    cnt++;
                }

                // �I�[���[���̏ꍇ�A���ʃR�[�h�Ƃ���
                if (wkStr.Length == cnt)
                {
                    fullText = "0";
                }
                return fullText;
            }
            else
            {
                return string.Empty;
            }
        }
        //----- ueno add ---------- end 2008.03.31

        # endregion

        // ===================================================================================== //
        // �R���g���[���C�x���g
        // ===================================================================================== //
        #region Control Events

        /// <summary>Form.Load �C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.05</br>
        /// </remarks>
        private void DCKHN09160UA_Load(object sender, System.EventArgs e)
        {	
            // �A�C�R����\������
            ImageList imageList16 = IconResourceManagement.ImageList16;
            ImageList imageList24 = IconResourceManagement.ImageList24;
			
            // ����{�^���A�C�R��
            this.Rate_Ok_Btn.ImageList = imageList24;
            this.Rate_Ok_Btn.Appearance.Image = Size24_Index.SAVE;
			
            this.Cancel_Button.ImageList = imageList24;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			
            this.Rate_LogicalDel_Btn.ImageList = imageList24;
            this.Rate_LogicalDel_Btn.Appearance.Image = Size24_Index.DELETE;
			
            this.Rate_PhysicalDelBtn.ImageList = imageList24;
            this.Rate_PhysicalDelBtn.Appearance.Image = Size24_Index.DELETE;
			
            this.Rate_ReviveBtn.ImageList = imageList24;
            this.Rate_ReviveBtn.Appearance.Image = Size24_Index.REVIVAL;
			
            this.Search_uButton.ImageList = imageList16;
            this.Search_uButton.Appearance.Image = Size16_Index.SEARCH;
			
            this.Rate_Clear_Btn.ImageList = imageList16;
            this.Rate_Clear_Btn.Appearance.Image = Size16_Index.UNDO;
			
            this.Lot_Clear_Btn.ImageList = imageList16;
            this.Lot_Clear_Btn.Appearance.Image = Size16_Index.UNDO;
			
            this.Lot_Ok_Btn.ImageList = imageList24;
            this.Lot_Ok_Btn.Appearance.Image = Size24_Index.SAVE;
			
            this.Lot_Cancel_Button.ImageList = imageList24;
            this.Lot_Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			
            // �K�C�h�A�C�R��
            this.SectionCode_uButton.ImageList = imageList16;
            this.RateSettingDivide_uButton.ImageList = imageList16;
            this.GoodsNo_uButton.ImageList = imageList16;
            this.GoodsMakerCd_uButton.ImageList = imageList16;
            this.GoodsMakerCd_Grp_uButton.ImageList = imageList16;
            this.LargeGoodsGanreCode_Grp_uButton.ImageList = imageList16;
            this.MediumGoodsGanreCode_Grp_uButton.ImageList = imageList16;
            this.DetailGoodsGanreCode_Grp_uButton.ImageList = imageList16;
            this.BLGoodsCode_Grp_uButton.ImageList = imageList16;
            this.CustomerCode_uButton.ImageList = imageList16;
            this.SupplierCd_uButton.ImageList = imageList16;

            this.SectionCode_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.RateSettingDivide_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.GoodsNo_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.GoodsMakerCd_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.GoodsMakerCd_Grp_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.LargeGoodsGanreCode_Grp_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.MediumGoodsGanreCode_Grp_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.DetailGoodsGanreCode_Grp_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.BLGoodsCode_Grp_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.CustomerCode_uButton.Appearance.Image = (int)Size16_Index.STAR1;
            this.SupplierCd_uButton.Appearance.Image = (int)Size16_Index.STAR1;
			
            // ��ʏ����ݒ�
            ScreenInitialSetting();

            // ���b�g��ʐݒ�
            ScreenInitialSettingLot();
			
            // �^�u�R���g���[�����X�g�쐬
            SetTabControlList();
			
            // ��ʃN���A
            ScreenClear();
			
            // ��ʍ\�z
            ScreenReconstruction();

            // �C�x���g����
            this.Rate_uTabControl.SelectedTabChanging += new Infragistics.Win.UltraWinTabControl.SelectedTabChangingEventHandler(this.Rate_uTabControl_SelectedTabChanging);
        }

        /// <summary>
        /// UnitPriceKind_tComboEditor_SelectionChangeCommitted�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �P����ރR���{�{�b�N�X���ω��Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.12</br>
        /// </remarks>
        private void UnitPriceKind_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (UnitPriceKind_tComboEditor.Value != null)
            {
                UnitPriceKindVisibleChange((Int32)UnitPriceKind_tComboEditor.Value);
            }
        }

        /// <summary>
        /// UnitPriceKindWay_tComboEditor_SelectionChangeCommitted�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �ݒ���@�R���{�{�b�N�X���ω��Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.05</br>
        /// </remarks>
        private void UnitPriceKindWay_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (UnitPriceKindWay_tComboEditor.Value != null)
            {
                UnitPriceKindWayVisibleChange((Int32)UnitPriceKindWay_tComboEditor.Value);
            }
        }

        /// <summary>
        /// ���Е��ޕύX
        /// </summary>
        /// <param name="enterpriseGanreCode">���Е��ރR�[�h</param>
        /// <remarks>
        /// <br>Note�@     : ���Е��ނ̑I����ύX�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void EnterpriseGanreCodeVisibleChange(int enterpriseGanreCode)
        {
            if (this._searchRate.EnterpriseGanreCode == enterpriseGanreCode) return;

            this._searchRate.EnterpriseGanreCode = enterpriseGanreCode;
        }

        /// <summary>
        /// ���Ӑ�|���ύX
        /// </summary>
        /// <param name="custRateGrpCode">���Ӑ�|���R�[�h</param>
        /// <remarks>
        /// <br>Note�@     : ���Ӑ�|���̑I����ύX�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void CustRateGrpCodeVisibleChange(int custRateGrpCode)
        {
            if (this._searchRate.CustRateGrpCode == custRateGrpCode) return;

            this._searchRate.CustRateGrpCode = custRateGrpCode;
        }

        /// <summary>
        /// �d����|���ύX
        /// </summary>
        /// <param name="suppRateGrpCode">�d����|���R�[�h</param>
        /// <remarks>
        /// <br>Note�@     : �d����|���̑I����ύX�����Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30167 ��� �O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void SuppRateGrpCodeVisibleChange(int suppRateGrpCode)
        {
            if (this._searchRate.SuppRateGrpCode == suppRateGrpCode) return;

            this._searchRate.SuppRateGrpCode = suppRateGrpCode;
        }

        /// <summary>Control.ChangeFocus �C�x���g</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �t�H�[�J�X�ړ����ɔ������܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.05</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

            Control NextCtrl = e.NextCtrl;
            ControlChangeFocus(sender, e.PrevCtrl, ref NextCtrl, e.Key, e.ShiftKey);
            e.NextCtrl = NextCtrl;
        }

		/// <summary>ControlChangeFocus</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <param name="prevCtrl">�O�̃R���g���[��</param>
		/// <param name="nextCtrl">���̃R���g���[��</param>
		/// <param name="key">�L�[</param>
		/// <param name="shiftKey">�V�t�g�L�[</param>
		/// <remarks>
		/// <br>Note       : Control.ChangeFocus�C�x���g�������ɏ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.01.09</br>
		/// </remarks>
		private void ControlChangeFocus(object sender, Control prevCtrl, ref Control nextCtrl, Keys key, bool shiftKey)
		{
		    bool canChangeFocus = true;
			DispSetStatus dispSetStatus = DispSetStatus.Clear;
			
			object inParamObj = null;
			object outParamObj = null;
			ArrayList inParamList = new ArrayList();

			//----- ueno add ---------- start 2008.03.31
			// �ҏW�O�C�x���g�ꎞ��~
			this.RateSectionCode_tEdit.BeforeEnterEditMode -= this.RateSectionCode_tEdit_BeforeEnterEditMode;
			//----- ueno add ---------- end 2008.03.31
			
			switch (prevCtrl.Name)
			{
				//------------------
				// �|���ݒ��������
				//------------------
				#region case ���_�R�[�h
				case "RateSectionCode_tEdit":
					{
						// ��ʃf�[�^�A���[�N�f�[�^�Ƃ��ɖ����͎��͏������Ȃ�
						if ((this.RateSectionCode_tEdit.Text == "") && (this._searchRate.SectionCode == ""))
						{
							break;
						}

						//----- ueno add ---------- start 2008.03.31
						// ���_�R�[�h�[�����ߑΉ��i�[���f�[�^��L���ɂ���j
						if (this.RateSectionCode_tEdit.Text != "")
						{
							this.RateSectionCode_tEdit.Text = GetZeroPaddedTextProc(this.RateSectionCode_tEdit.Text, this.RateSectionCode_tEdit.ExtEdit.Column);
							
							// ���[�N�f�[�^���[�����߂���
							this._searchRate.SectionCode = GetZeroPaddedTextProc(this._searchRate.SectionCode, this.RateSectionCode_tEdit.ExtEdit.Column);
						}
						//----- ueno add ---------- end 2008.03.31
						
						// �����ݒ�
						inParamObj = this.RateSectionCode_tEdit.Text;

						// ���݃`�F�b�N
						switch (CheckSectionCode(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// �l�ύX�`�F�b�N
									if (this.RateSectionCode_tEdit.Text != this._searchRate.SectionCode)
									{
										dispSetStatus = editChgDataChk("���_�R�[�h", this.RateSectionCode_tEdit.Text, this._searchRate.SectionCode);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("���_�R�[�h");
									dispSetStatus = this._searchRate.SectionCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						
						// �f�[�^�ݒ�
						DispSetSectionCode(dispSetStatus, ref canChangeFocus, outParamObj);

						//--------------------------------
						// ���_�R�[�h�֘A���ڃN���A����
						//--------------------------------
						// ��ʃf�[�^�A���[�N�f�[�^�Ƃ��ɖ����͎��͑S�č폜����
						if ((this.RateSectionCode_tEdit.Text == "") && (this._searchRate.SectionCode == ""))
						{
							SectionCodeVisibleChange();
						}

						// �����O�̏ꍇ
						if ((this._AllCtrlInputStatus == AllCtrlInputStatus.New)
							|| (this._AllCtrlInputStatus == AllCtrlInputStatus.InputCondition))
						{
							// �|���������̓G���[�`�F�b�N
							InpRateCondCheck();
						}
						break;
					}
				#endregion

				#region case �P�����
				case "UnitPriceKind_tComboEditor":
					{
						if (this.UnitPriceKind_tComboEditor.Value != null)
						{
							// �C�x���g��~
							this.UnitPriceKind_tComboEditor.SelectionChangeCommitted -= new EventHandler(this.UnitPriceKind_tComboEditor_SelectionChangeCommitted);

							UnitPriceKindVisibleChange((Int32)this.UnitPriceKind_tComboEditor.Value);

							// �C�x���g����
							this.UnitPriceKind_tComboEditor.SelectionChangeCommitted += new EventHandler(this.UnitPriceKind_tComboEditor_SelectionChangeCommitted);
						}

						// �����O�̏ꍇ
						if ((this._AllCtrlInputStatus == AllCtrlInputStatus.New)
							|| (this._AllCtrlInputStatus == AllCtrlInputStatus.InputCondition))
						{
							// �|���������̓G���[�`�F�b�N
							InpRateCondCheck();
						}
						break;
					}
				#endregion

				#region case �ݒ���@
				case "UnitPriceKindWay_tComboEditor":
					{
						if (this.UnitPriceKindWay_tComboEditor.Value != null)
						{
							// �C�x���g��~
							this.UnitPriceKindWay_tComboEditor.SelectionChangeCommitted -= new EventHandler(this.UnitPriceKindWay_tComboEditor_SelectionChangeCommitted);

							UnitPriceKindWayVisibleChange((Int32)this.UnitPriceKindWay_tComboEditor.Value);

							// �C�x���g����
							this.UnitPriceKindWay_tComboEditor.SelectionChangeCommitted += new EventHandler(this.UnitPriceKindWay_tComboEditor_SelectionChangeCommitted);
						}

						// �����O�̏ꍇ
						if ((this._AllCtrlInputStatus == AllCtrlInputStatus.New)
							|| (this._AllCtrlInputStatus == AllCtrlInputStatus.InputCondition))
						{
							// �|���������̓G���[�`�F�b�N
							InpRateCondCheck();
						}
						break;
					}
				#endregion

				#region case �|���ݒ�敪
				case "RateSettingDivide_tEdit":
					{
						// ��ʃf�[�^�A���[�N�f�[�^�Ƃ��ɖ����͎��͏������Ȃ�
						if ((this.RateSettingDivide_tEdit.Text == "")&&(this._searchRate.RateSettingDivide == ""))
						{
							break;
						}

						// ���_�R�[�h���̓`�F�b�N
						if (this.RateSectionCode_tEdit.Text == "")
						{
							ShowInpErrMsg("���_�R�[�h����͂��Ă��������B");
							canChangeFocus = false;
							prevCtrl = this.RateSectionCode_tEdit;

							// �|���ݒ�敪�N���A
							this.RateSettingDivide_tEdit.Clear();
							this.RateMngGoodsCd_tEdit.Clear();
							this.RateMngGoodsNm_tEdit.Clear();
							this.RateMngCustCd_tEdit.Clear();
							this.RateMngCustNm_tEdit.Clear();

							// ���݃f�[�^�N���A
							this._searchRate.RateSettingDivide = "";
							this._searchRate.RateMngGoodsCd = "";
							this._searchRate.RateMngGoodsNm = "";
							this._searchRate.RateMngCustCd = "";
							this._searchRate.RateMngCustNm = "";
							break;
						}
						
						// �����ݒ�
						inParamList.Add(this.RateSectionCode_tEdit.Text);
						inParamList.Add(NullChgInt(this.UnitPriceKind_tComboEditor.Value));
						inParamList.Add(NullChgInt(this.UnitPriceKindWay_tComboEditor.Value));
						inParamList.Add(this.RateSettingDivide_tEdit.Text);
						inParamObj = inParamList;
						
						// ���݃`�F�b�N
						switch(CheckRateSettingDivide(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// �l�ύX�`�F�b�N
									if (this.RateSettingDivide_tEdit.Text != this._searchRate.RateSettingDivide)
									{
										dispSetStatus = editChgDataChk("�|���ݒ�敪", this.RateSettingDivide_tEdit.Text, this._searchRate.RateSettingDivide);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("�|���ݒ�敪");
									dispSetStatus = this._searchRate.RateSettingDivide == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}

						// �f�[�^�ݒ�
						DispSetRateSettingDivide(dispSetStatus, ref canChangeFocus, outParamObj);

						//--------------------------------
						// �|���ݒ�敪�֘A���ڃN���A����
						//--------------------------------
						// ��ʃf�[�^�A���[�N�f�[�^�Ƃ��ɖ����͎��͑S�č폜����
						if ((this.RateSettingDivide_tEdit.Text == "")&&(this._searchRate.RateSettingDivide == ""))
						{
							RateSettingDivideVisibleChange();
						}

						// �����O�̏ꍇ
						if ((this._AllCtrlInputStatus == AllCtrlInputStatus.New)
							|| (this._AllCtrlInputStatus == AllCtrlInputStatus.InputCondition))
						{
							// �|���������̓G���[�`�F�b�N
							InpRateCondCheck();
						}
						break;
					}
				#endregion

				//------------------------------
				// �P�i, �f���i, ������������
				//------------------------------
				#region case ���[�J�[�R�[�h�i�P�i�j
				case "GoodsMakerCd_tNedit":
					{
						// ��ʃf�[�^�A���[�N�f�[�^�Ƃ��ɖ����͎��͏������Ȃ�
						if ((this.GoodsMakerCd_tNedit.Text == "") && (this._searchRate.GoodsMakerCd == 0))
						{
							break;
						}
						
						// �[���f�[�^�`�F�b�N����
						if ((this.GoodsMakerCd_tNedit.Text != "")&&(this.GoodsMakerCd_tNedit.GetInt() == 0))
						{
							if(this._searchRate.GoodsMakerCd == 0)
							{
								this.GoodsMakerCd_tNedit.Clear();
								canChangeFocus = false;
							}
							else
							{
								this.GoodsMakerCd_tNedit.SetInt(this._searchRate.GoodsMakerCd);
							}
							break;
						}

						// �����ݒ�
						inParamObj = this.GoodsMakerCd_tNedit.GetInt();

						// ���݃`�F�b�N
						switch (CheckGoodsMakerCd(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// �l�ύX�`�F�b�N
									if (this.GoodsMakerCd_tNedit.GetInt() != this._searchRate.GoodsMakerCd)
									{
										dispSetStatus = editChgDataChk("���[�J�[�R�[�h�i�P�i�j", this.GoodsMakerCd_tNedit.GetInt(), this._searchRate.GoodsMakerCd);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("���[�J�[�R�[�h�i�P�i�j");
									dispSetStatus = this._searchRate.GoodsMakerCd == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// �f�[�^�ݒ�
						DispSetGoodsMakerCd(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case ���[�J�[�R�[�h
				case "GoodsMakerCd_Grp_tNedit":
					{
						// ��ʃf�[�^�A���[�N�f�[�^�Ƃ��ɖ����͎��͏������Ȃ�
						if ((this.GoodsMakerCd_Grp_tNedit.Text == "") && (this._searchRate.GoodsMakerCd == 0))
						{
							break;
						}

						// �[���f�[�^�`�F�b�N����
						if ((this.GoodsMakerCd_Grp_tNedit.Text != "") && (this.GoodsMakerCd_Grp_tNedit.GetInt() == 0))
						{
							if (this._searchRate.GoodsMakerCd == 0)
							{
								this.GoodsMakerCd_Grp_tNedit.Clear();
								canChangeFocus = false;
							}
							else
							{
								this.GoodsMakerCd_Grp_tNedit.SetInt(this._searchRate.GoodsMakerCd);
							}
							break;
						}

						// �����ݒ�
						inParamObj = this.GoodsMakerCd_Grp_tNedit.GetInt();

						// ���݃`�F�b�N
						switch (CheckGoodsMakerCd(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// �l�ύX�`�F�b�N
									if (this.GoodsMakerCd_Grp_tNedit.GetInt() != this._searchRate.GoodsMakerCd)
									{
										dispSetStatus = editChgDataChk("���[�J�[�R�[�h", this.GoodsMakerCd_Grp_tNedit.GetInt(), this._searchRate.GoodsMakerCd);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("���[�J�[�R�[�h");
									dispSetStatus = this._searchRate.GoodsMakerCd == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// �f�[�^�ݒ�
						DispSetGoodsMakerCdGrp(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case ���i�|�������N
				case "GoodsRateRankCd_Grp_tEdit":
					{
						// ��ʃf�[�^�A���[�N�f�[�^�Ƃ��ɖ����͎��͏������Ȃ�
						if ((this.GoodsRateRankCd_Grp_tEdit.Text == "") && (this._searchRate.GoodsRateRank == ""))
						{
							break;
						}
						
						outParamObj = this.GoodsRateRankCd_Grp_tEdit.Text;
						
						// �f�[�^�ݒ�
						DispSetGoodsRateRankCd(DispSetStatus.Update, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case ���i�R�[�h
				case "GoodsNoCd_tEdit":
					{
						// ��ʃf�[�^�A���[�N�f�[�^�Ƃ��ɖ����͎��͏������Ȃ�
						if ((this.GoodsNoCd_tEdit.Text == "") && (this._searchRate.GoodsNo == ""))
						{
							break;
						}

						// �����ݒ�
						inParamList.Add(this.GoodsMakerCd_tNedit.GetInt());
						inParamList.Add(this.GoodsNoCd_tEdit.Text);
						inParamObj = inParamList;

						// ���݃`�F�b�N
						switch(CheckGoodsNoCd(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// �l�ύX�`�F�b�N
									if (this.GoodsNoCd_tEdit.Text != this._searchRate.GoodsNo)
									{
										dispSetStatus = editChgDataChk("���i�R�[�h", this.GoodsNoCd_tEdit.Text, this._searchRate.GoodsNo);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							//----- ueno add ---------- start 2008.03.04
							case (int)InputChkStatus.Cancel:
								{
									dispSetStatus = DispSetStatus.Clear;
									break;
								}
							//----- ueno add ---------- end 2008.03.04
							default:
								{
									ShowNotFoundErrMsg("���i�R�[�h");
									dispSetStatus = this._searchRate.GoodsNo == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// �f�[�^�ݒ�
						DispSetGoodsNoCd(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case ���i�敪�O���[�v�R�[�h
				case "LargeGoodsGanreCode_Grp_tEdit":
					{
						// ��ʃf�[�^�A���[�N�f�[�^�Ƃ��ɖ����͎��͏������Ȃ�
						if ((this.LargeGoodsGanreCode_Grp_tEdit.Text == "") && (this._searchRate.LargeGoodsGanreCode == ""))
						{
							break;
						}
						
						// �����ݒ�
						inParamObj = this.LargeGoodsGanreCode_Grp_tEdit.Text;
						
						// ���݃`�F�b�N
						switch(CheckLargeGoodsGanreCodeGrp(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// �l�ύX�`�F�b�N
									if (this.LargeGoodsGanreCode_Grp_tEdit.Text != this._searchRate.LargeGoodsGanreCode)
									{
										dispSetStatus = editChgDataChk("���i�敪�O���[�v�R�[�h", this.LargeGoodsGanreCode_Grp_tEdit.Text, this._searchRate.LargeGoodsGanreCode);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("���i�敪�O���[�v�R�[�h");
									dispSetStatus = this._searchRate.LargeGoodsGanreCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}								
						}
						// �f�[�^�ݒ�
						DispSetLargeGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case ���i�敪�R�[�h
				case "MediumGoodsGanreCode_Grp_tEdit":
					{
						// ��ʃf�[�^�A���[�N�f�[�^�Ƃ��ɖ����͎��͏������Ȃ�
						if ((this.MediumGoodsGanreCode_Grp_tEdit.Text == "") && (this._searchRate.MediumGoodsGanreCode == ""))
						{
							break;
						}

						// �����ݒ�
						inParamList.Add(this.LargeGoodsGanreCode_Grp_tEdit.Text);
						inParamList.Add(this.MediumGoodsGanreCode_Grp_tEdit.Text);
						inParamObj = inParamList;

						// ���݃`�F�b�N
						switch (CheckMediumGoodsGanreCodeGrp(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// �l�ύX�`�F�b�N
									if (this.MediumGoodsGanreCode_Grp_tEdit.Text != this._searchRate.MediumGoodsGanreCode)
									{
										dispSetStatus = editChgDataChk("���i�敪�R�[�h", this.MediumGoodsGanreCode_Grp_tEdit.Text, this._searchRate.MediumGoodsGanreCode);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("���i�敪�R�[�h");
									dispSetStatus = this._searchRate.MediumGoodsGanreCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// �f�[�^�ݒ�
						DispSetMediumGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case ���i�敪�ڍ׃R�[�h
				case "DetailGoodsGanreCode_Grp_tEdit":
					{
						// ��ʃf�[�^�A���[�N�f�[�^�Ƃ��ɖ����͎��͏������Ȃ�
						if ((this.DetailGoodsGanreCode_Grp_tEdit.Text == "") && (this._searchRate.DetailGoodsGanreCode == ""))
						{
							break;
						}

						// �����ݒ�
						inParamList.Add(this.LargeGoodsGanreCode_Grp_tEdit.Text);
						inParamList.Add(this.MediumGoodsGanreCode_Grp_tEdit.Text);
						inParamList.Add(this.DetailGoodsGanreCode_Grp_tEdit.Text);
						inParamObj = inParamList;

						// ���݃`�F�b�N
						switch (CheckDetailGoodsGanreCodeGrp(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// �l�ύX�`�F�b�N
									if (this.DetailGoodsGanreCode_Grp_tEdit.Text != this._searchRate.DetailGoodsGanreCode)
									{
										dispSetStatus = editChgDataChk("���i�敪�ڍ׃R�[�h", this.DetailGoodsGanreCode_Grp_tEdit.Text, this._searchRate.DetailGoodsGanreCode);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("���i�敪�ڍ׃R�[�h");
									dispSetStatus = this._searchRate.DetailGoodsGanreCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// �f�[�^�ݒ�
						DispSetDetailGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case ���Е��ރR�[�h�i�G���[�`�F�b�N�����j
				case "EnterpriseGanreCode_Grp_tComboEditor":
					{
						break;
					}
				#endregion

				#region case �a�k���i�R�[�h
				case "BLGoodsCode_Grp_tNedit":
					{
						// ��ʃf�[�^�A���[�N�f�[�^�Ƃ��ɖ����͎��͏������Ȃ�
						if ((this.BLGoodsCode_Grp_tNedit.Text == "") && (this._searchRate.BLGoodsCode == 0))
						{
							break;
						}
					
						// �[���f�[�^�`�F�b�N����
						if ((this.BLGoodsCode_Grp_tNedit.Text != "") && (this.BLGoodsCode_Grp_tNedit.GetInt() == 0))
						{
							if (this._searchRate.BLGoodsCode == 0)
							{
								this.BLGoodsCode_Grp_tNedit.Clear();
								canChangeFocus = false;
							}
							else
							{
								this.BLGoodsCode_Grp_tNedit.SetInt(this._searchRate.BLGoodsCode);
							}
							break;
						}

						// �����ݒ�
						inParamObj = this.BLGoodsCode_Grp_tNedit.GetInt();

						// ���݃`�F�b�N
						switch (CheckBLGoodsCodeGrp(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// �l�ύX�`�F�b�N
									if (this.BLGoodsCode_Grp_tNedit.GetInt() != this._searchRate.BLGoodsCode)
									{
										dispSetStatus = editChgDataChk("�a�k���i�R�[�h", this.BLGoodsCode_Grp_tNedit.GetInt(), this._searchRate.BLGoodsCode);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("�a�k���i�R�[�h");
									dispSetStatus = this._searchRate.BLGoodsCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// �f�[�^�ݒ�
						DispSetBLGoodsCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case ���Ӑ�R�[�h
				case "CustomerCode_tNedit":
					{
						// ��ʃf�[�^�A���[�N�f�[�^�Ƃ��ɖ����͎��͏������Ȃ�
						if ((this.CustomerCode_tNedit.Text == "") && (this._searchRate.CustomerCode == 0))
						{
							break;
						}
					
						// �[���f�[�^�`�F�b�N����
						if ((this.CustomerCode_tNedit.Text != "") && (this.CustomerCode_tNedit.GetInt() == 0))
						{
							if (this._searchRate.CustomerCode == 0)
							{
								this.CustomerCode_tNedit.Clear();
								canChangeFocus = false;
							}
							else
							{
								this.CustomerCode_tNedit.SetInt(this._searchRate.CustomerCode);
							}
							break;
						}

						// �����ݒ�
						inParamObj = this.CustomerCode_tNedit.GetInt();

						// ���݃`�F�b�N
						switch (CheckCustomerCode(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// �l�ύX�`�F�b�N
									if (this.CustomerCode_tNedit.GetInt() != this._searchRate.CustomerCode)
									{
										dispSetStatus = editChgDataChk("���Ӑ�R�[�h", this.CustomerCode_tNedit.GetInt(), this._searchRate.CustomerCode);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("���Ӑ�R�[�h");
									dispSetStatus = this._searchRate.CustomerCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// �f�[�^�ݒ�
						DispSetCustomerCode(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case ���Ӑ�|���O���[�v�R�[�h�i�G���[�`�F�b�N�����j
				case "CustRateGrpCode_tComboEditor":
					{
						break;
					}
				#endregion

				#region case �d����R�[�h
				case "SupplierCd_tNedit":
					{
						// ��ʃf�[�^�A���[�N�f�[�^�Ƃ��ɖ����͎��͏������Ȃ�
						if ((this.SupplierCd_tNedit.Text == "") && (this._searchRate.SupplierCd == 0))
						{
							break;
						}
						
						// �[���f�[�^�`�F�b�N����
						if ((this.SupplierCd_tNedit.Text != "") && (this.SupplierCd_tNedit.GetInt() == 0))
						{
							if (this._searchRate.SupplierCd == 0)
							{
								this.SupplierCd_tNedit.Clear();
								canChangeFocus = false;
							}
							else
							{
								this.SupplierCd_tNedit.SetInt(this._searchRate.SupplierCd);
							}
							break;
						}

						// �����ݒ�
						inParamObj = this.SupplierCd_tNedit.GetInt();

						// ���݃`�F�b�N
						switch (CheckSupplierCd(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// �l�ύX�`�F�b�N
									if (this.SupplierCd_tNedit.GetInt() != this._searchRate.SupplierCd)
									{
										dispSetStatus = editChgDataChk("�d����R�[�h", this.SupplierCd_tNedit.GetInt(), this._searchRate.SupplierCd);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("�d����R�[�h");
									dispSetStatus = this._searchRate.SupplierCd == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// �f�[�^�ݒ�
						DispSetSupplierCd(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case �d����|���O���[�v�R�[�h�i�G���[�`�F�b�N�����j
				case "SuppRateGrpCode_tComboEditor":
					{
						break;
					}
				#endregion

				//--------------
				// �|���ݒ蕔��
				//--------------
				#region case �V�|���J�n��
				case "NewRateStartDate_tDateEdit":
					{
						// �����͂Ȃ珈�����Ȃ�
						if ((this.NewRateStartDate_tDateEdit.GetDateYear() == 0)
							|| (this.NewRateStartDate_tDateEdit.GetDateMonth() == 0)
							|| (this.NewRateStartDate_tDateEdit.GetDateDay() == 0))
						{
							break;
						}

						// ���b�g��ʂ̊|���J�n���ɔ��f
						this.LotNewRateStartDate_tDateEdit.SetDateTime(this.NewRateStartDate_tDateEdit.GetDateTime());

						// ���ڔ�r
						string hashKey = OLDNEWDIVCD_NEW + "000000000.00";

						if (this._rateSrchRsltHashList.ContainsKey(hashKey) == true)
						{
							Rate rateWk = (Rate)this._rateSrchRsltHashList[hashKey];

							// �ύX�L��
							if (rateWk.RateStartDate != this.NewRateStartDate_tDateEdit.GetDateTime())
							{
								// �ۑ�����������܂Ń��b�g�ݒ薳��
								this.Lot_uTabPageControl.Enabled = false;
							}
							// �ύX����
							else
							{
								this.Lot_uTabPageControl.Enabled = true;
							}
						}
						break;
					}
				#endregion

				#region case ���|���J�n��
				case "OldRateStartDate_tDateEdit":
					{
						// �����͂Ȃ珈�����Ȃ�
						if ((this.OldRateStartDate_tDateEdit.GetDateYear() == 0)
							|| (this.OldRateStartDate_tDateEdit.GetDateMonth() == 0)
							|| (this.OldRateStartDate_tDateEdit.GetDateDay() == 0))
						{
							break;
						}

						// ���b�g��ʂ̊|���J�n���ɔ��f
						this.LotOldRateStartDate_tDateEdit.SetDateTime(this.OldRateStartDate_tDateEdit.GetDateTime());

						// ���ڔ�r
						string hashKey = OLDNEWDIVCD_OLD + "000000000.00";

						if (this._rateSrchRsltHashList.ContainsKey(hashKey))
						{
							Rate rateWk = (Rate)this._rateSrchRsltHashList[hashKey];

							if (rateWk.RateStartDate != this.OldRateStartDate_tDateEdit.GetDateTime())
							{
								// �ۑ�����������܂Ń��b�g�ݒ薳��
								this.Lot_uTabPageControl.Enabled = false;
							}
							else
							{
								this.Lot_uTabPageControl.Enabled = true;
							}
						}
						break;
					}
				#endregion

				//------------------------
				// �V�����b�g�O���b�h����
				//------------------------
				#region case �V�����b�g�O���b�h����
				case "rateLotNew_ultraGrid":
				case "rateLotOld_ultraGrid":
					{
						UltraGrid uGrid;
						if (prevCtrl.Name == "rateLotNew_ultraGrid")
						{
							uGrid = this.rateLotNew_ultraGrid;
						}
						else
						{
							uGrid = this.rateLotOld_ultraGrid;
						}

						// Grid��Control�����鎞��Return/Tab�̓����ݒ�
						if (prevCtrl == uGrid)
						{
							// ���^�[���L�[�̎�
							if ((key == Keys.Return) || (key == Keys.Tab))
							{
								nextCtrl = null;

								if (uGrid.ActiveCell != null)
								{
									// �ŏI�Z���̎�
									if ((uGrid.ActiveCell.Row.Index == uGrid.Rows.Count - 1) &&
										(uGrid.ActiveCell.Column.Index == uGrid.DisplayLayout.Bands[0].Columns[LOT_BARGAINCD].Index))
									{
										// �V���|���ݒ�{�^���Ƀt�H�[�J�X�J��
										nextCtrl = this.LotOldNewRateStartDate_uButton;
									}
									else
									{
										// �u�����v�̏ꍇ�͎���Row��
										if (uGrid.ActiveCell.Column.Index == uGrid.DisplayLayout.Bands[0].Columns[LOT_BARGAINCD].Index)
										{
											// ����Row�Ƀt�H�[�J�X�J��
											uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow);
											uGrid.PerformAction(UltraGridAction.EnterEditMode);
										}
										else
										{
											// ����Cell�Ƀt�H�[�J�X�J��
											uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextCell);
										}
									}
								}
							}
						}
						break;
					}
				#endregion
			}

			//===========================
			// �t�H�[�J�X����
			//===========================
			#region �t�H�[�J�X����
			//----------
			// �|�����
			//----------
			if(Rate_uTabControl.ActiveTab.Key == "rateTab")
			{
				if (canChangeFocus == true)
				{
					switch (key)
					{
						case Keys.Return:
						case Keys.Tab:
							{
								Control control = null;

								if (shiftKey == false)
								{
									control = GetNextControl(prevCtrl);
								}
								else
								{
									control = GetForwardControl(prevCtrl);
								}

								if (control != null)
								{
									nextCtrl = control;
								}
								break;
							}
					}
				}
				else
				{
					nextCtrl = prevCtrl;

					//----- ueno add ---------- start 2008.03.07
					// ���݂̍��ڂ���ړ������A�e�L�X�g�S�I����ԂƂ���
					nextCtrl.Select();
					//----- ueno add ---------- end 2008.03.07

					//----- ueno add ---------- start 2008.03.31
					if (this.RateSectionCode_tEdit.Focused == true)
					{
						// �擪�̃[���l�߂��폜
						this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
					}
					//----- ueno add ---------- end 2008.03.31
				}
			}
			//------------
			// ���b�g���
			//------------
			else
			{
				// ���^�[���L�[�̎�
				if ((key == Keys.Return) || (key == Keys.Tab))
				{
					// ���ݗL���ȃ��b�g�e�[�u���擾
					UltraGrid uGrid;
					
					if (this.rateLotNew_ultraGrid.Visible == true)
					{
						uGrid = this.rateLotNew_ultraGrid;
					}
					else
					{
						uGrid = this.rateLotOld_ultraGrid;
					}

					switch(prevCtrl.Name)
					{
						case "Rate_uTabControl":
							{
								if (shiftKey == false)
								{
									uGrid.Rows[0].Cells[LOT_LOTCOUNT].Activate();
									nextCtrl = uGrid;
								}
								else
								{
									nextCtrl = this.Lot_Cancel_Button;
								}
								break;
							}
						case "LotOldNewRateStartDate_uButton":
							{
								if (shiftKey == false)
								{
									nextCtrl = this.Lot_Clear_Btn;
								}
								else
								{
									uGrid.Rows[0].Cells[LOT_LOTCOUNT].Activate();
									nextCtrl = uGrid;
								}
								break;
							}
						case "Lot_Clear_Btn":	
							{
								if (shiftKey == false)
								{
									nextCtrl = this.Lot_Ok_Btn;
								}
								else
								{
									nextCtrl = this.LotOldNewRateStartDate_uButton;
								}
								break;
							}
						case "Lot_Ok_Btn":
							{
								if (shiftKey == false)
								{
									nextCtrl = this.Lot_Cancel_Button;
								}
								else
								{
									nextCtrl = this.Lot_Clear_Btn;
								}
								break;
							}
						case "Lot_Cancel_Button":
							{
								if (shiftKey == false)
								{
									nextCtrl = this.Rate_uTabControl;
								}
								else
								{
									nextCtrl = this.Lot_Ok_Btn;
								}
								break;
							}
						
					}
				}
			}
			#endregion �t�H�[�J�X����

			//----- ueno add ---------- start 2008.03.31
			// �ҏW�O�C�x���g�ĊJ
			this.RateSectionCode_tEdit.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.RateSectionCode_tEdit_BeforeEnterEditMode);
			//----- ueno add ---------- end 2008.03.31
		}
        
        /// <summary>�|���ۑ��{�^���C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �|���ۑ��{�^�����I�����ꂽ���ɔ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.10.05</br>
		/// </remarks>
		private void Rate_Ok_Button_Click(object sender, EventArgs e)
		{
			int oldSaveFlag = 0;		// ���|���ݒ�L���i0:�ݒ薳��, 1:�ݒ�L��j
			int oldDataDelFlag = 0;		// ���|���f�[�^�폜�v�ہi0:��, 1:�v�j
			
			// ���̓f�[�^�G���[�`�F�b�N
			if (InpRateDataCheck(ref oldSaveFlag, ref oldDataDelFlag) == true)
			{
				// ���|���f�[�^�����폜����
				if (oldDataDelFlag == 1)
				{
					// ���|���폜�m�F
					DialogResult result = TMsgDisp.Show(
						this, 								// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
						ASSEMBLY_ID,   						// �A�Z���u���h�c�܂��̓N���X�h�c
						PHY_OLDDEL_MSG,						// �\�����郁�b�Z�[�W
						0, 									// �X�e�[�^�X�l
						MessageBoxButtons.YesNo, 			// �\������{�^��
						MessageBoxDefaultButton.Button2);	// �����\���{�^��
					
					if (result == DialogResult.Yes)
					{
						// ���|���f�[�^�����폜
						PhysicalDeleteOldRate();
					}
					else
					{
						// �n�b�V���L�[�쐬
						string hashKey = OLDNEWDIVCD_OLD + "000000000.00";
						
						if (this._rateSrchRsltHashList.ContainsKey(hashKey) == true)
						{
							Rate rateWk = (Rate)this._rateSrchRsltHashList[hashKey];
							
							// ���|���ݒ荀�ڂ̃f�[�^��߂�
							this.OldPrice_tNedit.SetValue(rateWk.PriceFl);
							this.OldRate_tNedit.SetValue(rateWk.RateVal);
							this.OldUnPrcFracProcUnit_tNedit.SetValue(rateWk.UnPrcFracProcUnit);
						}
					}
				}
				
				// �������ݏ���
				if (SaveProc(ref oldSaveFlag) == true)
				{
					// �S�̓��̓R���g���[���i���b�g���������j
					SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.SearchUpdate.GetHashCode());
					this._AllCtrlInputStatus = AllCtrlInputStatus.SearchUpdate;
				}
			}

			//----- ueno add ---------- start 2008.03.31
			if (this.RateSectionCode_tEdit.Focused == true)
			{
				// �擪�̃[���l�߂��폜
				this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
			}
			//----- ueno add ---------- end 2008.03.31
		}

		/// <summary>Rate_Clear_Btn_Click</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �N���A�{�^���������Ɏ��s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void Rate_Clear_Btn_Click(object sender, EventArgs e)
		{
			// �m�F���b�Z�[�W�o��
			if (ShowConfirmMsg(DISP_CLR_MSG, emErrorLevel.ERR_LEVEL_INFO) == true)
			{
				ScreenClear();
				
				// ���_�R�[�h�Ƀt�H�[�J�X�ݒ�
				this.RateSectionCode_tEdit.Focus();
			}
		}

		/// <summary>Rate_LogicalDelBtn_Click</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �폜�{�^���������Ɏ��s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.10.19</br>
		/// </remarks>
		private void Rate_LogicalDelBtn_Click(object sender, EventArgs e)
		{
			// �����͍��ڂ�����Έȉ��������Ȃ�
			if (InpCondDataCheck() == false)
			{
				//----- ueno add ---------- start 2008.03.31
				if (this.RateSectionCode_tEdit.Focused == true)
				{
					// �擪�̃[���l�߂��폜
					this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
				}
				//----- ueno add ---------- end 2008.03.31

				return;
			}
			
			// �m�F���b�Z�[�W�o��
			if (ShowConfirmMsg(LOG_OLDDEL_MSG, emErrorLevel.ERR_LEVEL_INFO) == true)
			{
				// �_���폜
				if (LogicalDeleteRate() == 0)
				{
					// �S�̓��̓R���g���[��
					SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.SearchDelete.GetHashCode());
					this._AllCtrlInputStatus = AllCtrlInputStatus.SearchDelete;
					
					// �폜���[�h�ɕύX
					this.Mode_Label.Text = DELETE_MODE;

					// �_���폜���b�Z�[�W
					TMsgDisp.Show(this,							// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_INFO,			// �G���[���x��
						ASSEMBLY_ID,							// �A�Z���u��ID
						LDEL_INFO_MSG,							// �\�����郁�b�Z�[�W
						0,										// �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��
				}
			}

			//----- ueno add ---------- start 2008.03.31
			if (this.RateSectionCode_tEdit.Focused == true)
			{
				// �擪�̃[���l�߂��폜
				this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
			}
			//----- ueno add ---------- end 2008.03.31
		}

		/// <summary>Rate_PhysicalDelBtn_Click</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ���S�폜�{�^���������Ɏ��s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.10.19</br>
		/// </remarks>
		private void Rate_PhysicalDelBtn_Click(object sender, EventArgs e)
		{
			// �����͍��ڂ�����Έȉ��������Ȃ�
			if (InpCondDataCheck() == false)
			{
				//----- ueno add ---------- start 2008.03.31
				if (this.RateSectionCode_tEdit.Focused == true)
				{
					// �擪�̃[���l�߂��폜
					this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
				}
				//----- ueno add ---------- end 2008.03.31
			
				return;
			}
			
			// �����폜�m�F
			DialogResult result = TMsgDisp.Show(
				this, 								// �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
				ASSEMBLY_ID,   						// �A�Z���u���h�c�܂��̓N���X�h�c
				PHY_DEL_MSG,						// �\�����郁�b�Z�[�W
				0, 									// �X�e�[�^�X�l
				MessageBoxButtons.YesNo, 			// �\������{�^��
				MessageBoxDefaultButton.Button2);	// �����\���{�^��

			if(result == DialogResult.Yes)
			{
				// �����폜
				if (PhysicalDeleteRate() == 0)
				{
					// �S�̓��̓R���g���[��
					SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.InputCondition.GetHashCode());
					this._AllCtrlInputStatus = AllCtrlInputStatus.InputCondition;
					
					// �V�K���[�h�ɕύX
					this.Mode_Label.Text = INSERT_MODE;
					
					// �|���ݒ�f�[�^�N���A
					// �V�|���ݒ荀��
					this.NewRateStartDate_tDateEdit.SetToday();		// �|���J�n��
					this.NewPrice_tNedit.Clear();					// �P��
					this.NewRate_tNedit.Clear();					// �|��
					this.NewUnPrcFracProcUnit_tNedit.Clear();		// �P���[�������P��

					// ���|���ݒ荀��
					this.OldPrice_tNedit.Clear();					// �P��
					this.OldRate_tNedit.Clear();					// �|��
					this.OldUnPrcFracProcUnit_tNedit.Clear();		// �P���[�������P��

					// �����폜���b�Z�[�W
					TMsgDisp.Show(this,							// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_INFO,			// �G���[���x��
						ASSEMBLY_ID,							// �A�Z���u��ID
						PDEL_INFO_MSG,							// �\�����郁�b�Z�[�W
						0,										// �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��
				}
			}

			//----- ueno add ---------- start 2008.03.31
			if (this.RateSectionCode_tEdit.Focused == true)
			{
				// �擪�̃[���l�߂��폜
				this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
			}
			//----- ueno add ---------- end 2008.03.31
		}

		/// <summary>Rate_ReviveBtn_Click</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �����{�^���������Ɏ��s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.10.19</br>
		/// </remarks>
		private void Rate_ReviveBtn_Click(object sender, EventArgs e)
		{
			// �����͍��ڂ�����Έȉ��������Ȃ�
			if (InpCondDataCheck() == false)
			{
				//----- ueno add ---------- start 2008.03.31
				if (this.RateSectionCode_tEdit.Focused == true)
				{
					// �擪�̃[���l�߂��폜
					this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
				}
				//----- ueno add ---------- end 2008.03.31
			
				return;
			}
			
			// ����
			if (ReviveRate() == 0)
			{
				// �S�̓��̓R���g���[��
				SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.SearchUpdate.GetHashCode());
				this._AllCtrlInputStatus = AllCtrlInputStatus.SearchUpdate;
				
				// �X�V���[�h�ɕύX
				this.Mode_Label.Text = UPDATE_MODE;

				// �������b�Z�[�W
				TMsgDisp.Show(this,							// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_INFO,			// �G���[���x��
					ASSEMBLY_ID,							// �A�Z���u��ID
					REV_INFO_MSG,							// �\�����郁�b�Z�[�W
					0,										// �X�e�[�^�X�l
					MessageBoxButtons.OK);					// �\������{�^��
			}

			//----- ueno add ---------- start 2008.03.31
			if (this.RateSectionCode_tEdit.Focused == true)
			{
				// �擪�̃[���l�߂��폜
				this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
			}
			//----- ueno add ---------- end 2008.03.31

		}

        /// <summary>����{�^���C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ����{�^�����I�����ꂽ���ɔ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.10.05</br>
		/// </remarks>
		private void Close_Button_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Control.Click �C�x���g(Cancel_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ����{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.01.08</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, EventArgs e)
		{
			if (CompareRateChange() == true)
			{
				// ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
				DialogResult res = TMsgDisp.Show(
					this,								// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// �G���[���x��
					ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
					"",									// �\�����郁�b�Z�[�W 
					0,									// �X�e�[�^�X�l
					MessageBoxButtons.YesNoCancel);		// �\������{�^��

				switch (res)
				{
					case DialogResult.Yes:
						{
							int oldSaveFlag = 0;		// ���|���ݒ�L���i0:�ݒ薳��, 1:�ݒ�L��j
							int oldDataDelFlag = 0;		// ���|���f�[�^�폜�v�ہi0:��, 1:�v�j

							// ���̓f�[�^�G���[�`�F�b�N
							if (InpRateDataCheck(ref oldSaveFlag, ref oldDataDelFlag) == true)
							{
								// ���|���f�[�^�����폜����
								if (oldDataDelFlag == 1)
								{
									// ���|���폜�m�F
									DialogResult result = TMsgDisp.Show(
										this, 								// �e�E�B���h�E�t�H�[��
										emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
										ASSEMBLY_ID,   						// �A�Z���u���h�c�܂��̓N���X�h�c
										PHY_OLDDEL_MSG,						// �\�����郁�b�Z�[�W
										0, 									// �X�e�[�^�X�l
										MessageBoxButtons.YesNo, 			// �\������{�^��
										MessageBoxDefaultButton.Button2);	// �����\���{�^��

									if (result == DialogResult.Yes)
									{
										// ���|���f�[�^�����폜
										PhysicalDeleteOldRate();
									}
									else
									{
										// �n�b�V���L�[�쐬
										string hashKey = OLDNEWDIVCD_OLD + "000000000.00";

										if (this._rateSrchRsltHashList.ContainsKey(hashKey) == true)
										{
											Rate rateWk = (Rate)this._rateSrchRsltHashList[hashKey];

											// ���|���ݒ荀�ڂ̃f�[�^��߂�
											this.OldPrice_tNedit.SetValue(rateWk.PriceFl);
											this.OldRate_tNedit.SetValue(rateWk.RateVal);
											this.OldUnPrcFracProcUnit_tNedit.SetValue(rateWk.UnPrcFracProcUnit);
										}
									}
								}

								// �������ݏ���
								if (SaveProc(ref oldSaveFlag) == true)
								{
									// �S�̓��̓R���g���[���i���b�g���������j
									SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.SearchUpdate.GetHashCode());
									this._AllCtrlInputStatus = AllCtrlInputStatus.SearchUpdate;
								}
								
								this.DialogResult = DialogResult.OK;
								break;
							}
							else
							{
								return;
							}
						}
					case DialogResult.No:
						{
							this.DialogResult = DialogResult.Cancel;
							break;
						}
					default:
						{
							this.Cancel_Button.Focus();
							return;
						}
				}
			}
			this.Close();
		}

		/// <summary>
		/// Timer.Tick �C�x���g �C�x���g(Initial_Timer)(SF100%���p)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ�Ԋu�̎��Ԃ��o�߂����Ƃ��ɔ������܂��B</br>
		///	<br>             ���̏����́A�V�X�e�����񋟂���X���b�h �v�[��</br>
		///	<br>             �X���b�h�Ŏ��s����܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.10.03</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}

        /// <summary>�^�C�}�[�C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �I���������Ɏ��s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.10.05</br>
		/// </remarks>
		private void Close_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Close_Timer.Enabled = false;
		}

		/// <summary>CopyToOldFromNewbtn_Click</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �V�|���ݒ聨���|���ֈړ��{�^���������Ɏ��s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.10.05</br>
		/// </remarks>
		private void CopyToOldFromNewbtn_Click(object sender, EventArgs e)
		{
			// �m�F���b�Z�[�W�o��
			DialogResult res = TMsgDisp.Show(
				this, 								// �e�E�B���h�E�t�H�[��
				emErrorLevel.ERR_LEVEL_INFO,		// �G���[���x��
				ASSEMBLY_ID,   						// �A�Z���u���h�c�܂��̓N���X�h�c
				RATE_CPY_MSG,						// �\�����郁�b�Z�[�W
				0, 									// �X�e�[�^�X�l
				MessageBoxButtons.YesNo, 			// �\������{�^��
				MessageBoxDefaultButton.Button2);	// �����\���{�^��

			if (res == DialogResult.Yes)
			{
				CopyToOldRateFromNewRate();
			}
		}

		/// <summary>Search_uButton_Click</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �����������Ɏ��s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.10.12</br>
		/// </remarks>
		private void Search_uButton_Click(object sender, EventArgs e)
		{
			// �|�������K�{�`�F�b�N
			if (InpRateCondCheck() == false)
			{
				RateSettingDivideVisibleChange();

				//----- ueno add ---------- start 2008.03.31
				if (this.RateSectionCode_tEdit.Focused == true)
				{
					// �擪�̃[���l�߂��폜
					this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
				}
				//----- ueno add ---------- end 2008.03.31

				return;
			}
			
			// ���͏󋵃t���O
			this._AllCtrlInputStatus = AllCtrlInputStatus.InputCondition;	// ��������
			
			// ���͏�������
			SettingInpCond();

			// ���͏����K�{�`�F�b�N
			if (InpDataCheck() != 0)
			{
				InpRateCondCheck();
				SrchRsltDataClear();

				//----- ueno add ---------- start 2008.03.31
				if (this.RateSectionCode_tEdit.Focused == true)
				{
					// �擪�̃[���l�߂��폜
					this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
				}
				//----- ueno add ---------- end 2008.03.31

				return;
			}

			//---------------------------------------------------------------------------------
			// ���̓f�[�^�`�F�b�N��2�x�s��
			//   �V���[�g�J�b�g�L�[�g�p���̓��[�N�N���X�Ƀf�[�^���Z�b�g����Ă��Ȃ���ԂȂ̂�
			//	 1��ڂ̓��̓f�[�^�`�F�b�N�ŁA���펞�Ƀ��[�N�N���X�֓��̓f�[�^���Z�b�g����
			//   2��ڂ̓��̓f�[�^�`�F�b�N�ŁA�G���[�𔻒肷��
			//---------------------------------------------------------------------------------
			// ���̓f�[�^�`�F�b�N�y�у��[�N�N���X�փf�[�^�i�[
			InpCondDataCheck();
			
			// ���̓f�[�^�S�̃`�F�b�N
			if (InpCondDataCheck() == false)
			{
				// �|���������̓G���[�`�F�b�N
				InpRateCondCheck();
				SrchRsltDataClear();

				//----- ueno add ---------- start 2008.03.31
				if (this.RateSectionCode_tEdit.Focused == true)
				{
					// �擪�̃[���l�߂��폜
					this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
				}
				//----- ueno add ---------- end 2008.03.31

				return;
			}

			// �|�����͐���
			SettingRateInpCond();
			
			// �|���}�X�^����
			// �f�[�^���݃`�F�b�N
			this.Cursor = Cursors.WaitCursor;
			RateSearch();

			//----- ueno add ---------- start 2008.03.31
			if (this.RateSectionCode_tEdit.Focused == true)
			{
				// �擪�̃[���l�߂��폜
				this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
			}
			//----- ueno add ---------- end 2008.03.31

			this.Cursor = Cursors.Default;
		}

		/// <summary>Rate_uTabControl_SelectedTabChanging</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �^�u�ؑ֎��Ɏ��s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.10.12</br>
		/// </remarks>
		private void Rate_uTabControl_SelectedTabChanging(object sender, Infragistics.Win.UltraWinTabControl.SelectedTabChangingEventArgs e)
		{
			switch (Rate_uTabControl.ActiveTab.Key)
			{
				case "rateTab":
					{
						string message;
						UltraGridCell uGridCell;
						
						//------------------
						// �V���b�g�O���b�h
						//------------------
						// ���b�g�s���`�F�b�N
						foreach (UltraGridRow uRow in this.rateLotNew_ultraGrid.Rows)
						{
							if (InpLotDataCheck(uRow, out message, out uGridCell) == false)
							{
								// �G���[�������͐V���b�g�O���b�h�֐؂�ւ�
								this.LotOldNewRateStartDate_uButton.Text = RATE_NEW;
								OldNewRateChange(false);

								// �G���[�s�Ƀt�H�[�J�X�Z�b�g
								if (uGridCell != null)
								{
									uGridCell.Activate();
								}

								// �G���[���b�Z�[�W�o��
								ShowInpErrMsg(message);
								e.Cancel = true;
								return;
							}
						}

						// ���ꃍ�b�g�`�F�b�N
						int index = 0; // �d���s�̐擪
						if (InpLotDuplicateCheck(ref this._dataTableLotNew, ref this.rateLotNew_ultraGrid, ref index) == false)
						{
							// �G���[�������͐V���b�g�O���b�h�֐؂�ւ�
							this.LotOldNewRateStartDate_uButton.Text = RATE_NEW;
							OldNewRateChange(false);

							// �G���[�s�Ƀt�H�[�J�X�Z�b�g
							this.rateLotNew_ultraGrid.Rows[index].Cells[LOT_LOTCOUNT].Activate();

							// �G���[���b�Z�[�W�o��
							ShowInpErrMsg(LOT_DUP_MSG);
							e.Cancel = true;
							return;
						}

						//------------------
						// �����b�g�O���b�h
						//------------------
						// ���b�g�s���`�F�b�N
						foreach (UltraGridRow uRow in this.rateLotOld_ultraGrid.Rows)
						{
							if (InpLotDataCheck(uRow, out message, out uGridCell) == false)
							{
								// �G���[�������͋����b�g�O���b�h�֐؂�ւ�
								this.LotOldNewRateStartDate_uButton.Text = RATE_OLD;
								OldNewRateChange(false);

								// �G���[�s�Ƀt�H�[�J�X�Z�b�g
								if (uGridCell != null)
								{
									uGridCell.Activate();
								}

								// �G���[���b�Z�[�W�o��
								ShowInpErrMsg(message);
								e.Cancel = true;
								return;
							}
						}

						// ���ꃍ�b�g�`�F�b�N
						index = 0; // �d���s�̐擪
						if (InpLotDuplicateCheck(ref this._dataTableLotOld, ref this.rateLotOld_ultraGrid, ref index) == false)
						{
							// �G���[�������͋����b�g�O���b�h�֐؂�ւ�
							this.LotOldNewRateStartDate_uButton.Text = RATE_OLD;
							OldNewRateChange(false);

							// �G���[�s�Ƀt�H�[�J�X�Z�b�g
							this.rateLotOld_ultraGrid.Rows[index].Cells[LOT_LOTCOUNT].Activate();

							// �G���[���b�Z�[�W�o��
							ShowInpErrMsg(LOT_DUP_MSG);
							e.Cancel = true;
							return;
						}
						
						// �|���^�u����
						RateTabControl();
						break;
					}
				case "rateLotTab":
					{
						// ���b�g�^�u����
						RateLotTabControl(RATE_NEW);
						break;
					}
				default:
					{
						return;
					}
			}
		}

        #region �K�C�h�{�^��
        /// <summary>SectionCode_uButton_Click</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ���_�R�[�h�K�C�h�{�^������������Ɣ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.10.26</br>
		/// </remarks>
		private void SectionCode_uButton_Click(object sender, EventArgs e)
		{
			SecInfoSet secInfoSet = null;
			
			if (this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet) == 0)
			{
				// �ύX��������Ώ������Ȃ�
				if(string.Equals(secInfoSet.SectionCode, this._searchRate.SectionCode) == true)
				{
					return;
				}
				
				DispSetStatus dispSetStatus = editChgDataChk("���_�R�[�h", secInfoSet.SectionCode, this._searchRate.SectionCode);
				if(dispSetStatus == DispSetStatus.Update)
				{
					this.RateSectionCode_tEdit.Text = secInfoSet.SectionCode;
					this.SectionCodeNm_tEdit.Text = secInfoSet.SectionGuideNm;
					
					// ���݃f�[�^�ۑ�
					this._searchRate.SectionCode = this.RateSectionCode_tEdit.Text;
				}
			}
		}
		
		/// <summary>RateSettingDivide_uButton_Click</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �|���ݒ�敪�K�C�h�{�^������������Ɣ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.10.10</br>
		/// </remarks>
		private void RateSettingDivide_uButton_Click(object sender, EventArgs e)
		{
			RateProtyMng rateProtyMng = null;
			
			if (this._rateProtyMngAcs.ExecuteGuid(this._enterpriseCode, this.RateSectionCode_tEdit.Text, NullChgInt(this.UnitPriceKind_tComboEditor.Value),
				NullChgInt(this.UnitPriceKindWay_tComboEditor.Value), out rateProtyMng) == 0)
			{
				// �ύX��������Ώ������Ȃ�
				if (string.Equals(rateProtyMng.RateSettingDivide, this._searchRate.RateSettingDivide) == true)
				{
					return;
				}
				
				DispSetStatus dispSetStatus = editChgDataChk("�|���ݒ�敪", rateProtyMng.RateSettingDivide, this._searchRate.RateSettingDivide);
				if (dispSetStatus == DispSetStatus.Update)
				{
					this.RateSettingDivide_tEdit.Text = rateProtyMng.RateSettingDivide;
					this.RateMngGoodsCd_tEdit.Text = rateProtyMng.RateMngGoodsCd;
					this.RateMngGoodsNm_tEdit.Text = rateProtyMng.RateMngGoodsNm;
					this.RateMngCustCd_tEdit.Text = rateProtyMng.RateMngCustCd;
					this.RateMngCustNm_tEdit.Text = rateProtyMng.RateMngCustNm;
					
					// ���݃f�[�^�ۑ�
					this._searchRate.RateSettingDivide = this.RateSettingDivide_tEdit.Text;
					this._searchRate.RateMngGoodsCd	= this.RateMngGoodsCd_tEdit.Text;
					this._searchRate.RateMngGoodsNm = this.RateMngGoodsNm_tEdit.Text;
					this._searchRate.RateMngCustCd = this.RateMngCustCd_tEdit.Text;
					this._searchRate.RateMngCustNm = this.RateMngCustNm_tEdit.Text;

					// �����O�̏ꍇ
					if ((this._AllCtrlInputStatus == AllCtrlInputStatus.New)
						|| (this._AllCtrlInputStatus == AllCtrlInputStatus.InputCondition))
					{
						// �|���������̓G���[�`�F�b�N
						InpRateCondCheck();
					}
				}
			}
		}

        /// <summary>GoodsNo_uButton_Click</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���i�ԍ��i�P�i�j�K�C�h�{�^������������Ɣ������܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private void GoodsNo_uButton_Click(object sender, EventArgs e)
        {
            GoodsNoGuide(this.GoodsMakerCd_tNedit);
        }

        /// <summary>GoodsMakerCd_uButton_Click</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���i���[�J�[�i�P�i�j�K�C�h�{�^������������Ɣ������܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private void GoodsMakerCd_uButton_Click(object sender, EventArgs e)
        {
            MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt = null;
			
            //----------------------
            // ���[�J�[�R�[�h�K�C�h
            //----------------------
            if (makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt) == 0)
            {
                // �ύX��������Ώ������Ȃ�
                if (makerUMnt.GoodsMakerCd == this._searchRate.GoodsMakerCd)
                {
                    return;
                }

                DispSetStatus dispSetStatus = editChgDataChk("���[�J�[�R�[�h", makerUMnt.GoodsMakerCd, this._searchRate.GoodsMakerCd);
                if (dispSetStatus == DispSetStatus.Update)
                {
                    this.GoodsMakerCd_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                    this.GoodsMakerCdNm_tEdit.Text = makerUMnt.MakerName;

                    // �ύX���L��ꍇ
                    if (makerUMnt.GoodsMakerCd != this._searchRate.GoodsMakerCd)
                    {
                        // ���[�J�[�ɕR�Â����i�R�[�h, ���i���̃N���A
                        this.GoodsNoCd_tEdit.Clear();
                        this.GoodsNoNm_tEdit.Clear();
                        this._searchRate.GoodsNo = "";
                    }

                    // ���݃f�[�^�ۑ�
                    this._searchRate.GoodsMakerCd = this.GoodsMakerCd_tNedit.GetInt();
					
                    // ���i�R�[�h�K�C�h
                    GoodsNoGuide(this.GoodsMakerCd_tNedit);
                }
            }
        }

        /// <summary>GoodsMakerCd_Grp_uButton_Click</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���i���[�J�[�K�C�h�{�^������������Ɣ������܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private void GoodsMakerCd_Grp_uButton_Click(object sender, EventArgs e)
        {
            MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt = null;

            if (makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt) == 0)
            {
                // �ύX��������Ώ������Ȃ�
                if (makerUMnt.GoodsMakerCd == this._searchRate.GoodsMakerCd)
                {
                    return;
                }

                DispSetStatus dispSetStatus = editChgDataChk("���i���[�J�[", makerUMnt.GoodsMakerCd, this._searchRate.GoodsMakerCd);
                if (dispSetStatus == DispSetStatus.Update)
                {
                    this.GoodsMakerCd_Grp_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                    this.GoodsMakerCdNm_Grp_tEdit.Text = makerUMnt.MakerName;
					
                    // ���݃f�[�^�ۑ�
                    this._searchRate.GoodsMakerCd = this.GoodsMakerCd_Grp_tNedit.GetInt();
                }
            }
        }

        /// <summary>LargeGoodsGanreCode_Grp_uButton_Click</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���i�敪�O���[�v�R�[�h�K�C�h�{�^������������Ɣ������܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private void LargeGoodsGanreCode_Grp_uButton_Click(object sender, EventArgs e)
        {
            // ���i�敪�O���[�v�R�[�h�K�C�h�N��
            LargeGoodsGanreCodeGuide();
        }
		
        /// <summary>MediumGoodsGanreCode_Grp_uButton_Click</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���i�敪�K�C�h�{�^������������Ɣ������܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private void MediumGoodsGanreCode_Grp_uButton_Click(object sender, EventArgs e)
        {
            // ���i�敪�K�C�h�N��
            MediumGoodsGanreCodeGuide();
        }

        /// <summary>DetailGoodsGanreCode_Grp_uButton_Click</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���i�敪�ڍ׃K�C�h�{�^������������Ɣ������܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private void DetailGoodsGanreCode_Grp_uButton_Click(object sender, EventArgs e)
        {
            // ���i�敪�ڍ׃K�C�h�N��
            DetailGoodsGanreCodeGuide();
        }

        /// <summary>BLGoodsCode_Grp_uButton_Click</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �a�k�K�C�h�{�^������������Ɣ������܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private void BLGoodsCode_Grp_uButton_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt = null;
			
            if (this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt) == 0)
            {
                // �ύX��������Ώ������Ȃ�
                if (blGoodsCdUMnt.BLGoodsCode == this._searchRate.BLGoodsCode)
                {
                    return;
                }

                DispSetStatus dispSetStatus = editChgDataChk("�a�k���i�R�[�h", blGoodsCdUMnt.BLGoodsCode, this._searchRate.BLGoodsCode);
                if (dispSetStatus == DispSetStatus.Update)
                {
                    this.BLGoodsCode_Grp_tNedit.SetInt(blGoodsCdUMnt.BLGoodsCode);
                    this.BLGoodsCodeNm_Grp_tEdit.Text = blGoodsCdUMnt.BLGoodsFullName;
					
                    // ���݃f�[�^�ۑ�
                    this._searchRate.BLGoodsCode = this.BLGoodsCode_Grp_tNedit.GetInt();
                }
            }
        }

        /// <summary>CustomerCode_uButton_Click</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�K�C�h�{�^������������Ɣ������܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private void CustomerCode_uButton_Click(object sender, EventArgs e)
        {
            SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);	// ���Ӑ挟���A�N�Z�X�N���X
            customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);
        }

        /// <summary>SupplierCd_uButton_Click</summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �d����K�C�h�{�^������������Ɣ������܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private void SupplierCd_uButton_Click(object sender, EventArgs e)
        {
            SFTOK01370UA supplierSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);	// �d���挟���A�N�Z�X�N���X
            supplierSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.SupplierSearchForm_CustomerSelect);
            supplierSearchForm.ShowDialog(this);
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�I�����ɔ������܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.11</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            // �ύX��������Ώ������Ȃ�
            if (customerSearchRet.CustomerCode == this._searchRate.CustomerCode)
            {
                return;
            }

            CustomerInfo customerInfo;

            //�I�����ꂽ���Ӑ�̏�Ԃ��`�F�b�N
            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode,
                                    customerSearchRet.CustomerCode, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �I���f�[�^�����Ӑ�łȂ��ꍇ
                if (customerInfo.IsCustomer == false)
                {
                    // �G���[
                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "�w�肳�ꂽ�����ŁA���Ӑ�͑��݂��܂���ł����B", status);
                    return;
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "�I���������Ӑ�͊��ɍ폜����Ă��܂��B", status);
                return;
            }
            else
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "���Ӑ���̎擾�Ɏ��s���܂����B", status);
                return;
            }

            DispSetStatus dispSetStatus = editChgDataChk("���Ӑ�R�[�h", customerSearchRet.CustomerCode, this._searchRate.CustomerCode);
            if (dispSetStatus == DispSetStatus.Update)
            {
                this.CustomerCode_tNedit.SetInt(customerSearchRet.CustomerCode);
                this.CustomerCodeNm_tEdit.Text = customerSearchRet.Name;

                // ���݃f�[�^�ۑ�
                this._searchRate.CustomerCode = this.CustomerCode_tNedit.GetInt();
            }
        }

        /// <summary>
        /// �d����I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">�d���挟���߂�l�N���X</param>
        /// <remarks>
        /// <br>Note       : �d����I�����ɔ������܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2007.10.11</br>
        /// </remarks>
        private void SupplierSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            // �ύX��������Ώ������Ȃ�
            if (customerSearchRet.CustomerCode == this._searchRate.SupplierCd)
            {
                return;
            }

            CustomerInfo customerInfo;

            //�I�����ꂽ���Ӑ�̏�Ԃ��`�F�b�N
            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode,
                                    customerSearchRet.CustomerCode, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �I���f�[�^���d����łȂ��ꍇ
                if (customerInfo.IsSupplier == false)
                {
                    // �G���[
                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "�w�肳�ꂽ�����ŁA�d����͑��݂��܂���ł����B", status);
                    return;
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "�I�������d����͊��ɍ폜����Ă��܂��B", status);
                return;
            }
            else
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "�d������̎擾�Ɏ��s���܂����B", status);
                return;
            }

            DispSetStatus dispSetStatus = editChgDataChk("�d����R�[�h", customerSearchRet.CustomerCode, this._searchRate.SupplierCd);
            if (dispSetStatus == DispSetStatus.Update)
            {
                this.SupplierCd_tNedit.SetInt(customerSearchRet.CustomerCode);
                this.SupplierCdNm_tEdit.Text = customerSearchRet.Name;
				
                // ���݃f�[�^�ۑ�
                this._searchRate.SupplierCd = this.SupplierCd_tNedit.GetInt();
            }
        }
        #endregion

        /// <summary>
        /// EnterpriseGanreCode_Grp_tComboEditor_SelectionChangeCommitted�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���Е��ރR���{�{�b�N�X���ω��Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : 30167 ���@�O�M</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void EnterpriseGanreCode_Grp_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.EnterpriseGanreCode_Grp_tComboEditor.Value != null)
            {
                EnterpriseGanreCodeVisibleChange((Int32)this.EnterpriseGanreCode_Grp_tComboEditor.Value);
            }
        }
        
        /// <summary>
		/// CustRateGrpCode_tComboEditor_SelectionChangeCommitted�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : ���Ӑ�|���R���{�{�b�N�X���ω��Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void CustRateGrpCode_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.CustRateGrpCode_tComboEditor.Value != null)
			{
				CustRateGrpCodeVisibleChange((Int32)this.CustRateGrpCode_tComboEditor.Value);
			}
		}

		/// <summary>
		/// SuppRateGrpCode_tComboEditor_SelectionChangeCommitted�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �d����|���R���{�{�b�N�X���ω��Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void SuppRateGrpCode_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.SuppRateGrpCode_tComboEditor.Value != null)
			{
				SuppRateGrpCodeVisibleChange((Int32)this.SuppRateGrpCode_tComboEditor.Value);
			}
		}
        
        //----- ueno add ---------- start 2008.03.31
		/// <summary>
		/// RateSectionCode_tEdit_BeforeEnterEditMode
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note        : �R���g���[�����ҏW���[�h�ɓ���O�ɔ������܂��B</br>
		/// <br>Programmer  : 30167 ���@�O�M</br>
		/// <br>Date        : 2008.03.31</br>
		/// </remarks>
		private void RateSectionCode_tEdit_BeforeEnterEditMode(object sender, CancelEventArgs e)
		{
			// ChangeFocus�C�x���g�ꎞ��~
			this.tArrowKeyControl1.ChangeFocus -= this.tArrowKeyControl1_ChangeFocus;

			// �擪�̃[���l�߂��폜
			this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);

			// ChangeFocus�C�x���g�ĊJ
			this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tArrowKeyControl1_ChangeFocus);
		}

		//----- ueno add ---------- end 2008.03.31
        
	}
    # endregion
       --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/18
    }
}