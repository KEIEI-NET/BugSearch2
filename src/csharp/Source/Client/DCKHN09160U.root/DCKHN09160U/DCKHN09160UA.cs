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
    /// 掛率マスタフォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note		: 掛率マスタ設定を行う画面です。</br>
	/// <br>Programmer	: 30414 忍 幸史</br>
    /// <br>Date		: 2008/06/18</br>
    /// <br>Update Note : 2008/09/10 30414 忍 幸史</br>
    /// <br>            　・名称変更「定価UP率」→「価格UP率」「商品中分類」→「商品掛率Ｇ」</br>
    /// <br>Update Note : 2009/03/16 30452 上野 俊治</br>
    /// <br>             ・障害対応12346</br>
	/// </remarks>
	public partial class DCKHN09160UA : Form
	{
        #region Dispose
        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
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
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("拠点ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
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
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo2 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("掛率設定区分ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
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
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo3 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("BLｺｰﾄﾞガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo4 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("ｸﾞﾙｰﾌﾟｺｰﾄﾞガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo5 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("商品掛率ｸﾞﾙｰﾌﾟガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
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
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo6 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("メーカーガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
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
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo7 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("仕入先ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance67 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance68 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance124 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance125 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance131 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance132 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance130 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo8 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("得意先ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
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
            this.tNedit_Price.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
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
            this.Price_uLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.Price_uLabel.Location = new System.Drawing.Point(33, 253);
            this.Price_uLabel.Name = "Price_uLabel";
            this.Price_uLabel.Size = new System.Drawing.Size(53, 24);
            this.Price_uLabel.TabIndex = 900;
            this.Price_uLabel.Text = "価格";
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
            this.Detail_uGrid.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.ultraLabel15.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.ultraLabel15.Location = new System.Drawing.Point(5, 222);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(155, 19);
            this.ultraLabel15.TabIndex = 900;
            this.ultraLabel15.Text = "単価端数処理区分";
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
            this.ultraLabel14.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.ultraLabel14.Location = new System.Drawing.Point(5, 204);
            this.ultraLabel14.Name = "ultraLabel14";
            this.ultraLabel14.Size = new System.Drawing.Size(155, 19);
            this.ultraLabel14.TabIndex = 900;
            this.ultraLabel14.Text = "単価端数処理単位";
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
            this.ultraLabel13.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.ultraLabel13.Location = new System.Drawing.Point(65, 186);
            this.ultraLabel13.Name = "ultraLabel13";
            this.ultraLabel13.Size = new System.Drawing.Size(95, 19);
            this.ultraLabel13.TabIndex = 900;
            this.ultraLabel13.Text = "価格UP率";
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
            this.ultraLabel12.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.ultraLabel12.Location = new System.Drawing.Point(65, 168);
            this.ultraLabel12.Name = "ultraLabel12";
            this.ultraLabel12.Size = new System.Drawing.Size(95, 19);
            this.ultraLabel12.TabIndex = 900;
            this.ultraLabel12.Text = "ユーザー価格";
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
            this.ultraLabel11.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.ultraLabel11.Location = new System.Drawing.Point(5, 169);
            this.ultraLabel11.Name = "ultraLabel11";
            this.ultraLabel11.Size = new System.Drawing.Size(61, 36);
            this.ultraLabel11.TabIndex = 900;
            this.ultraLabel11.Text = "価格";
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
            this.ultraLabel9.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.ultraLabel9.Location = new System.Drawing.Point(65, 150);
            this.ultraLabel9.Name = "ultraLabel9";
            this.ultraLabel9.Size = new System.Drawing.Size(95, 19);
            this.ultraLabel9.TabIndex = 900;
            this.ultraLabel9.Text = "仕入原価";
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
            this.ultraLabel8.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.ultraLabel8.Location = new System.Drawing.Point(65, 132);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(95, 19);
            this.ultraLabel8.TabIndex = 900;
            this.ultraLabel8.Text = "仕入率";
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
            this.ultraLabel10.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.ultraLabel10.Location = new System.Drawing.Point(5, 132);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(61, 38);
            this.ultraLabel10.TabIndex = 900;
            this.ultraLabel10.Text = "原価";
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
            this.ultraLabel7.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.ultraLabel7.Location = new System.Drawing.Point(65, 114);
            this.ultraLabel7.Name = "ultraLabel7";
            this.ultraLabel7.Size = new System.Drawing.Size(95, 19);
            this.ultraLabel7.TabIndex = 900;
            this.ultraLabel7.Text = "粗利確保率";
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
            this.ultraLabel6.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.ultraLabel6.Location = new System.Drawing.Point(65, 96);
            this.ultraLabel6.Name = "ultraLabel6";
            this.ultraLabel6.Size = new System.Drawing.Size(95, 19);
            this.ultraLabel6.TabIndex = 900;
            this.ultraLabel6.Text = "原価UP率";
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
            this.ultraLabel5.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.ultraLabel5.Location = new System.Drawing.Point(65, 78);
            this.ultraLabel5.Name = "ultraLabel5";
            this.ultraLabel5.Size = new System.Drawing.Size(95, 19);
            this.ultraLabel5.TabIndex = 900;
            this.ultraLabel5.Text = "売価額";
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
            this.ultraLabel4.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.ultraLabel4.Location = new System.Drawing.Point(65, 60);
            this.ultraLabel4.Name = "ultraLabel4";
            this.ultraLabel4.Size = new System.Drawing.Size(95, 19);
            this.ultraLabel4.TabIndex = 900;
            this.ultraLabel4.Text = "売価率";
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
            this.ultraLabel3.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.ultraLabel3.Location = new System.Drawing.Point(5, 60);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(61, 73);
            this.ultraLabel3.TabIndex = 900;
            this.ultraLabel3.Text = "売価";
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
            this.ultraLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.ultraLabel2.Location = new System.Drawing.Point(5, 42);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(155, 19);
            this.ultraLabel2.TabIndex = 900;
            this.ultraLabel2.Text = "数量(以下)";
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
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 10F);
            this.ultraLabel1.Location = new System.Drawing.Point(5, 24);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(155, 19);
            this.ultraLabel1.TabIndex = 900;
            this.ultraLabel1.Text = "数量(以上)";
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
            this.tNedit_RatePriorityOrder.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
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
            this.ultraLabel16.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.ultraLabel16.Location = new System.Drawing.Point(522, 3);
            this.ultraLabel16.Name = "ultraLabel16";
            this.ultraLabel16.Size = new System.Drawing.Size(76, 24);
            this.ultraLabel16.TabIndex = 1138;
            this.ultraLabel16.Text = "優先順位";
            // 
            // SectionGuide_Button
            // 
            appearance75.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance75.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.SectionGuide_Button.Appearance = appearance75;
            this.SectionGuide_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SectionGuide_Button.Location = new System.Drawing.Point(266, 3);
            this.SectionGuide_Button.Name = "SectionGuide_Button";
            this.SectionGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.SectionGuide_Button.TabIndex = 6;
            ultraToolTipInfo1.ToolTipText = "拠点ガイド";
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
            this.RateCond_Title_uLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RateCond_Title_uLabel.Location = new System.Drawing.Point(0, 0);
            this.RateCond_Title_uLabel.Name = "RateCond_Title_uLabel";
            this.RateCond_Title_uLabel.Size = new System.Drawing.Size(25, 84);
            this.RateCond_Title_uLabel.TabIndex = 900;
            this.RateCond_Title_uLabel.Text = "掛率設定";
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
            this.SectionCodeNm_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.tEdit_SectionCodeAllowZero.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
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
            this.RateMngCustCd_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
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
            this.RateMngCustNm_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
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
            this.RateMngGoodsCd_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
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
            this.SectionCode_uLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.SectionCode_uLabel.Location = new System.Drawing.Point(30, 3);
            this.SectionCode_uLabel.Name = "SectionCode_uLabel";
            this.SectionCode_uLabel.Size = new System.Drawing.Size(89, 24);
            this.SectionCode_uLabel.TabIndex = 900;
            this.SectionCode_uLabel.Text = "拠点";
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
            this.UnitPriceKindWay_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
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
            this.Mode_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.UnitPriceKind_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
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
            this.RateMngGoodsNm_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
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
            this.UnitPriceKind_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.UnitPriceKind_Label.Location = new System.Drawing.Point(30, 30);
            this.UnitPriceKind_Label.Name = "UnitPriceKind_Label";
            this.UnitPriceKind_Label.Size = new System.Drawing.Size(76, 24);
            this.UnitPriceKind_Label.TabIndex = 900;
            this.UnitPriceKind_Label.Text = "単価種類";
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
            this.RateSettingDivide_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
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
            this.RateSettingDivideGuide_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RateSettingDivideGuide_Button.Location = new System.Drawing.Point(469, 3);
            this.RateSettingDivideGuide_Button.Name = "RateSettingDivideGuide_Button";
            this.RateSettingDivideGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.RateSettingDivideGuide_Button.TabIndex = 14;
            ultraToolTipInfo2.ToolTipText = "掛率設定区分ガイド";
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
            this.UnitPriceKindWay_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.UnitPriceKindWay_Label.Location = new System.Drawing.Point(30, 57);
            this.UnitPriceKindWay_Label.Name = "UnitPriceKindWay_Label";
            this.UnitPriceKindWay_Label.Size = new System.Drawing.Size(73, 24);
            this.UnitPriceKindWay_Label.TabIndex = 900;
            this.UnitPriceKindWay_Label.Text = "設定方法";
            // 
            // RateMngCust_Label
            // 
            appearance86.ForeColorDisabled = System.Drawing.Color.Black;
            appearance86.TextHAlignAsString = "Left";
            appearance86.TextVAlignAsString = "Middle";
            this.RateMngCust_Label.Appearance = appearance86;
            this.RateMngCust_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.RateMngCust_Label.Location = new System.Drawing.Point(319, 57);
            this.RateMngCust_Label.Name = "RateMngCust_Label";
            this.RateMngCust_Label.Size = new System.Drawing.Size(111, 24);
            this.RateMngCust_Label.TabIndex = 900;
            this.RateMngCust_Label.Text = "取引先設定区分";
            // 
            // RateMngGoods_Label
            // 
            appearance85.ForeColorDisabled = System.Drawing.Color.Black;
            appearance85.TextHAlignAsString = "Left";
            appearance85.TextVAlignAsString = "Middle";
            this.RateMngGoods_Label.Appearance = appearance85;
            this.RateMngGoods_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.RateMngGoods_Label.Location = new System.Drawing.Point(319, 30);
            this.RateMngGoods_Label.Name = "RateMngGoods_Label";
            this.RateMngGoods_Label.Size = new System.Drawing.Size(111, 24);
            this.RateMngGoods_Label.TabIndex = 900;
            this.RateMngGoods_Label.Text = "商品設定区分";
            // 
            // RateSettingDivide_Label
            // 
            appearance72.ForeColorDisabled = System.Drawing.Color.Black;
            appearance72.TextHAlignAsString = "Left";
            appearance72.TextVAlignAsString = "Middle";
            this.RateSettingDivide_Label.Appearance = appearance72;
            this.RateSettingDivide_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.RateSettingDivide_Label.Location = new System.Drawing.Point(319, 3);
            this.RateSettingDivide_Label.Name = "RateSettingDivide_Label";
            this.RateSettingDivide_Label.Size = new System.Drawing.Size(106, 24);
            this.RateSettingDivide_Label.TabIndex = 900;
            this.RateSettingDivide_Label.Text = "掛率設定区分";
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
            this.tEdit_GoodsNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
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
            this.tNedit_BLGoodsCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
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
            this.tNedit_BLGloupCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
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
            this.tNedit_GoodsMGroup.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
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
            this.Group_Title_uLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Group_Title_uLabel.Location = new System.Drawing.Point(0, 0);
            this.Group_Title_uLabel.Name = "Group_Title_uLabel";
            this.Group_Title_uLabel.Size = new System.Drawing.Size(25, 192);
            this.Group_Title_uLabel.TabIndex = 1106;
            this.Group_Title_uLabel.Text = "商品設定";
            // 
            // BLGoodsGuide_Button
            // 
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.BLGoodsGuide_Button.Appearance = appearance2;
            this.BLGoodsGuide_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BLGoodsGuide_Button.Location = new System.Drawing.Point(439, 111);
            this.BLGoodsGuide_Button.Name = "BLGoodsGuide_Button";
            this.BLGoodsGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.BLGoodsGuide_Button.TabIndex = 62;
            ultraToolTipInfo3.ToolTipText = "BLｺｰﾄﾞガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.BLGoodsGuide_Button, ultraToolTipInfo3);
            this.BLGoodsGuide_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.BLGoodsGuide_Button.Click += new System.EventHandler(this.BLGoodsGuide_Button_Click);
            // 
            // BLGroupGuide_Button
            // 
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.BLGroupGuide_Button.Appearance = appearance3;
            this.BLGroupGuide_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BLGroupGuide_Button.Location = new System.Drawing.Point(439, 84);
            this.BLGroupGuide_Button.Name = "BLGroupGuide_Button";
            this.BLGroupGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.BLGroupGuide_Button.TabIndex = 56;
            ultraToolTipInfo4.ToolTipText = "ｸﾞﾙｰﾌﾟｺｰﾄﾞガイド";
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
            this.GoodsMakerCd_Grp_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.GoodsMakerCd_Grp_Label.Location = new System.Drawing.Point(33, 3);
            this.GoodsMakerCd_Grp_Label.Name = "GoodsMakerCd_Grp_Label";
            this.GoodsMakerCd_Grp_Label.Size = new System.Drawing.Size(80, 24);
            this.GoodsMakerCd_Grp_Label.TabIndex = 900;
            this.GoodsMakerCd_Grp_Label.Text = "メーカー";
            // 
            // GoodsRateGrpGuide_Button
            // 
            appearance4.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance4.ImageVAlign = Infragistics.Win.VAlign.Middle;
            this.GoodsRateGrpGuide_Button.Appearance = appearance4;
            this.GoodsRateGrpGuide_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GoodsRateGrpGuide_Button.Location = new System.Drawing.Point(439, 56);
            this.GoodsRateGrpGuide_Button.Name = "GoodsRateGrpGuide_Button";
            this.GoodsRateGrpGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.GoodsRateGrpGuide_Button.TabIndex = 50;
            ultraToolTipInfo5.ToolTipText = "商品掛率ｸﾞﾙｰﾌﾟガイド";
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
            this.GoodsRateRank_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.GoodsRateRank_Label.Location = new System.Drawing.Point(33, 30);
            this.GoodsRateRank_Label.Name = "GoodsRateRank_Label";
            this.GoodsRateRank_Label.Size = new System.Drawing.Size(80, 24);
            this.GoodsRateRank_Label.TabIndex = 900;
            this.GoodsRateRank_Label.Text = "層別";
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
            this.BLGoodsName_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.tNedit_GoodsMakerCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
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
            this.BLGroupName_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.MakerName_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.GoodsRateGrpName_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.MakerGuide_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MakerGuide_Button.Location = new System.Drawing.Point(439, 3);
            this.MakerGuide_Button.Name = "MakerGuide_Button";
            this.MakerGuide_Button.Size = new System.Drawing.Size(24, 24);
            this.MakerGuide_Button.TabIndex = 42;
            ultraToolTipInfo6.ToolTipText = "メーカーガイド";
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
            this.GoodsNo_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.GoodsNo_Label.Location = new System.Drawing.Point(33, 138);
            this.GoodsNo_Label.Name = "GoodsNo_Label";
            this.GoodsNo_Label.Size = new System.Drawing.Size(65, 24);
            this.GoodsNo_Label.TabIndex = 900;
            this.GoodsNo_Label.Text = "品番";
            // 
            // GoodsRateGrp_Label
            // 
            appearance26.ForeColorDisabled = System.Drawing.Color.Black;
            appearance26.TextHAlignAsString = "Left";
            appearance26.TextVAlignAsString = "Middle";
            this.GoodsRateGrp_Label.Appearance = appearance26;
            this.GoodsRateGrp_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.GoodsRateGrp_Label.Location = new System.Drawing.Point(33, 57);
            this.GoodsRateGrp_Label.Name = "GoodsRateGrp_Label";
            this.GoodsRateGrp_Label.Size = new System.Drawing.Size(91, 24);
            this.GoodsRateGrp_Label.TabIndex = 900;
            this.GoodsRateGrp_Label.Text = "商品掛率Ｇ";
            // 
            // BLGroup_Label
            // 
            this.BLGroup_Label.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            appearance35.ForeColorDisabled = System.Drawing.Color.Black;
            appearance35.TextHAlignAsString = "Left";
            appearance35.TextVAlignAsString = "Middle";
            this.BLGroup_Label.Appearance = appearance35;
            this.BLGroup_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.BLGroup_Label.Location = new System.Drawing.Point(33, 84);
            this.BLGroup_Label.Name = "BLGroup_Label";
            this.BLGroup_Label.Size = new System.Drawing.Size(113, 24);
            this.BLGroup_Label.TabIndex = 900;
            this.BLGroup_Label.Text = "ｸﾞﾙｰﾌﾟｺｰﾄﾞ";
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
            this.GoodsRateRank_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
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
            this.BLGoods_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.BLGoods_Label.Location = new System.Drawing.Point(33, 111);
            this.BLGoods_Label.Name = "BLGoods_Label";
            this.BLGoods_Label.Size = new System.Drawing.Size(113, 24);
            this.BLGoods_Label.TabIndex = 900;
            this.BLGoods_Label.Text = "BLｺｰﾄﾞ";
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
            this.tEdit_GoodsName.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.CustRateGrpCode_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.Customer_Title_uLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Customer_Title_uLabel.Location = new System.Drawing.Point(0, 0);
            this.Customer_Title_uLabel.Name = "Customer_Title_uLabel";
            this.Customer_Title_uLabel.Size = new System.Drawing.Size(25, 84);
            this.Customer_Title_uLabel.TabIndex = 900;
            this.Customer_Title_uLabel.Text = "取引先設定";
            // 
            // CustRateGrpCode_Label
            // 
            appearance136.ForeColorDisabled = System.Drawing.Color.Black;
            appearance136.TextHAlignAsString = "Left";
            appearance136.TextVAlignAsString = "Middle";
            this.CustRateGrpCode_Label.Appearance = appearance136;
            this.CustRateGrpCode_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.CustRateGrpCode_Label.Location = new System.Drawing.Point(30, 30);
            this.CustRateGrpCode_Label.Name = "CustRateGrpCode_Label";
            this.CustRateGrpCode_Label.Size = new System.Drawing.Size(141, 24);
            this.CustRateGrpCode_Label.TabIndex = 900;
            this.CustRateGrpCode_Label.Text = "得意先掛率グループ";
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
            ultraToolTipInfo7.ToolTipText = "仕入先ガイド";
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
            this.CustomerCode_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.CustomerCode_Label.Location = new System.Drawing.Point(30, 3);
            this.CustomerCode_Label.Name = "CustomerCode_Label";
            this.CustomerCode_Label.Size = new System.Drawing.Size(117, 24);
            this.CustomerCode_Label.TabIndex = 900;
            this.CustomerCode_Label.Text = "得意先コード";
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
            this.tNedit_CustomerCode.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
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
            this.tNedit_SupplierCd.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
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
            this.SupplierCdNm_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            ultraToolTipInfo8.ToolTipText = "得意先ガイド";
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
            this.CustomerCodeNm_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
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
            this.SupplierCd_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.SupplierCd_Label.Location = new System.Drawing.Point(30, 57);
            this.SupplierCd_Label.Name = "SupplierCd_Label";
            this.SupplierCd_Label.Size = new System.Drawing.Size(117, 24);
            this.SupplierCd_Label.TabIndex = 900;
            this.SupplierCd_Label.Text = "仕入先コード";
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
            ultraToolbar1.Text = "メニュー";
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
            ultraToolbar2.Text = "標準";
            this.Main_ToolbarsManager.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1,
            ultraToolbar2});
            popupMenuTool3.SharedProps.Caption = "ファイル(&F)";
            popupMenuTool3.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool6,
            buttonTool7,
            buttonTool8});
            popupMenuTool4.SharedProps.Caption = "編集(&E)";
            popupMenuTool4.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool9,
            buttonTool10});
            labelTool3.SharedProps.Spring = true;
            buttonTool11.SharedProps.Caption = "終了(&X)";
            buttonTool12.SharedProps.Caption = "ウィンドウを初期状態に戻す(&R)";
            appearance12.BackColor = System.Drawing.Color.White;
            appearance12.TextHAlignAsString = "Left";
            labelTool4.SharedProps.AppearancesSmall.Appearance = appearance12;
            labelTool4.SharedProps.Visible = false;
            labelTool4.SharedProps.Width = 110;
            buttonTool13.SharedProps.Caption = "保存(&S)";
            buttonTool14.SharedProps.Caption = "新規(&N)";
            buttonTool15.SharedProps.Caption = "削除(&D)";
            buttonTool16.SharedProps.Caption = "復活(&B)";
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
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DCKHN09160UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "掛率マスタ";
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

        // 編集モード
        private const string INSERT_MODE = "新規";
        private const string UPDATE_MODE = "更新";
        private const string DELETE_MODE = "削除";

        private const int COLUMN_COUNT = 10;                    // 列数
        private const int ROW_COUNT = 12;                       // 行数

        private const int ROWINDEX_LOTCOUNTABOVE = 0;           // 数量(以上)
        private const int ROWINDEX_LOTCOUNTBELOW = 1;           // 数量(以下)
        private const int ROWINDEX_SALERATEVAL = 2;             // 売価率
        private const int ROWINDEX_SALEPRICEFL = 3;             // 売価額
        private const int ROWINDEX_COSTUPRATE = 4;              // 原価UP率
        private const int ROWINDEX_GRSPROFITSECURERATE = 5;     // 粗利確保率
        private const int ROWINDEX_COSTRATEVAL = 6;             // 仕入率
        private const int ROWINDEX_COSTPRICEFL = 7;             // 仕入原価
        private const int ROWINDEX_USERPRICEFL = 8;             // ユーザー定価
        private const int ROWINDEX_PRICEUPRATE = 9;             // 価格UP率
        private const int ROWINDEX_UNPRCFRACPROCUNIT = 10;      // 単価端数処理単位
        private const int ROWINDEX_UNPRCFRACPROCDIV = 11;       // 単価端数処理区分

        private const string COLUMNKEY_1 = "LotCount1";         // 数量範囲1
        private const string COLUMNKEY_2 = "LotCount2";         // 数量範囲2
        private const string COLUMNKEY_3 = "LotCount3";         // 数量範囲3
        private const string COLUMNKEY_4 = "LotCount4";         // 数量範囲4
        private const string COLUMNKEY_5 = "LotCount5";         // 数量範囲5
        private const string COLUMNKEY_6 = "LotCount6";         // 数量範囲6
        private const string COLUMNKEY_7 = "LotCount7";         // 数量範囲7
        private const string COLUMNKEY_8 = "LotCount8";         // 数量範囲8
        private const string COLUMNKEY_9 = "LotCount9";         // 数量範囲9
        private const string COLUMNKEY_10 = "LotCount10";       // 数量範囲10

        private const string LOTCOUNT_MIN = "0.01";
        private const string LOTCOUNT_MAX = "9,999,999.99";

        private const string UNITPRICEKIND_1 = "売価設定";
        private const string UNITPRICEKIND_2 = "原価設定";
        private const string UNITPRICEKIND_3 = "価格設定";

        private const string UNITPRICEKINDWAY_0 = "単品設定";
        private const string UNITPRICEKINDWAY_1 = "グループ設定";

        private const string UNPRCFRACPROCDIV_1 = "切捨て";
        private const string UNPRCFRACPROCDIV_2 = "四捨五入";
        private const string UNPRCFRACPROCDIV_3 = "切上げ";

        private const string FORMAT_NUM = "###,###";
        private const string FORMAT_DECIMAL = "N";

        private const string ALL_SECTIONCODE = "00";
        private const string ALL_SECTIONNAME = "全社";

        #endregion Constants

        #region Private Members

        private string _enterpriseCode = "";                // 企業コード
        private List<Rate> _rateListClone;                  // 掛率マスタリスト
        private SortedList _custRateGrpList = null;		    // 得意先掛率グループ
        private bool _cusotmerGuideSelected;                // 得意先ガイド選択フラグ

        // アクセスクラス
        private RateAcs _rateAcs = null;					// 掛率アクセスクラス
        private UserGuideAcs _userGuideAcs = null;			// ユーザーガイドアクセスクラス
        private SecInfoSetAcs _secInfoSetAcs = null;        // 拠点アクセスクラス
        private RateProtyMngAcs _rateProtyMngAcs = null;	// 掛率優先管理アクセスクラス
        private MakerAcs _makerAcs = null;					// メーカーアクセスクラス
        private BLGoodsCdAcs _blGoodsCdAcs = null;			// BLアクセスクラス
        private BLGroupUAcs _blGroupUAcs = null;            // BLグループアクセスクラス
        private GoodsGroupUAcs _goodsGroupUAcs = null;      // 商品掛率Ｇアクセスクラス
        private SecInfoAcs _secInfoAcs = null;              // 拠点情報アクセスクラス
        private CustomerInfoAcs _customerInfoAcs = null;    // 得意先アクセスクラス
        private SupplierAcs _supplierAcs = null;            // 仕入先アクセスクラス
        private GoodsAcs _goodsAcs = null;                  // 商品アクセスクラス

        // 前回値保持用変数
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
        /// 掛率マスタフォームクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 掛率マスタフォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
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

            // 各種マスタ読込
            LoadSecInfoSet();
            LoadSupplier();
            LoadMakerUMnt();
            LoadGoodsGroupU();
            LoadBLGoodsCdUMnt();
            LoadBLGroupU();

            // 画面初期化
            ScreenInitialSetting();

            // グリッド初期化
            ClearGrid("");
		}
		#endregion

        #region Private Methods

        /// <summary>
        /// 拠点情報マスタ読込処理
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
        /// 仕入先マスタ読込処理
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
        /// メーカーマスタ読込処理
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
        /// 商品掛率Ｇマスタ読込処理
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
        /// BLコードマスタ読込処理
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
        /// グループコードマスタ読込処理
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
        /// アイコン設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : ツールバーとボタンのアイコンを設定します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void SetIcon()
        {
            ImageList imageList16 = IconResourceManagement.ImageList16;

            // -----------------------------
            // ツールバーアイコン設定
            // -----------------------------
            ButtonTool workButton;

            // 終了ボタンのアイコン設定
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["Exit_ButtonTool"];
            if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.CLOSE];

            // 新規ボタンのアイコン設定
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["New_ButtonTool"];
            if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.NEW];

            // 保存ボタンのアイコン設定
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["Save_ButtonTool"];
            if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.SAVE];

            // 削除ボタンのアイコン設定
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["Delete_ButtonTool"];
            if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.DELETE];

            // 復活ボタンのアイコン設定
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["Revival_ButtonTool"];
            if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = imageList16.Images[(int)Size16_Index.UNDO];

            // -----------------------------
            // ボタンアイコン設定
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
        /// コントロールサイズ設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : コントロールサイズを設定します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
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

        #region 画面クリア処理

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報をクリアします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.Mode_Label.Text = INSERT_MODE;

            // 条件項目(掛率設定)クリア
            ClearRateCondition();

            // 条件項目(取引先設定)クリア
            ClearCustomerCondition();

            // 条件項目(商品設定)クリア
            ClearGoodsCondition();
        }

        /// <summary>
        /// 条件項目(掛率設定)クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報をクリアします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
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
        /// 条件項目(商品設定)クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報をクリアします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
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
        /// 条件項目(取引先設定)クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報をクリアします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
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
        /// グリッド初期設定処理
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <remarks>
        /// <br>Note       : グリッドの初期設定を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void ClearGrid(string unitPriceKind)
        {
            // --------------------------------------
            // データテーブル作成
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
                    // 売価設定
                    case "1":
                        // 数量(以上)
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
                        // 数量(以下)
                        else if (rowIndex == ROWINDEX_LOTCOUNTBELOW)
                        {
                            for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
                            {
                                string keyName = "LotCount" + (columnIndex + 1).ToString();
                                dataRow[keyName] = LOTCOUNT_MAX;
                            }
                        }
                        // 単価端数処理単位
                        else if (rowIndex == ROWINDEX_UNPRCFRACPROCUNIT)
                        {
                            string keyName = "LotCount1";
                            dataRow[keyName] = "1.00";
                        }
                        // 単価端数処理区分
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
                    // 原価設定、価格設定
                    case "2":
                    case "3":
                        // 数量(以上)
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
                        // 数量(以下)
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
                        // 端数処理単位
                        else if (rowIndex == ROWINDEX_UNPRCFRACPROCUNIT)
                        {
                            string keyName = "LotCount1";
                            dataRow[keyName] = "1.00";
                        }
                        // 単価端数処理区分
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
            // グリッドレイアウト設定
            // --------------------------------------
            ValueList valueList = new ValueList();
            valueList.ValueListItems.Add(1, UNPRCFRACPROCDIV_1);
            valueList.ValueListItems.Add(2, UNPRCFRACPROCDIV_2);
            valueList.ValueListItems.Add(3, UNPRCFRACPROCDIV_3);
            valueList.Appearance.BackColor = Color.FromArgb(247, 227, 156);

            for (int index = 0; index < COLUMN_COUNT; index++)
            {
                // 列幅設定
                this.Detail_uGrid.DisplayLayout.Bands[0].Columns[index].Width = 110;

                // ヘッダーキャプション設定
                this.Detail_uGrid.DisplayLayout.Bands[0].Columns[index].Header.Caption = "数量範囲" + (index + 1).ToString();

                // テキスト右寄せ
                this.Detail_uGrid.DisplayLayout.Bands[0].Columns[index].CellAppearance.TextHAlign = HAlign.Right;

                // 単価端数処理区分設定
                this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[index].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.DropDownList;
                this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[index].ValueList = valueList;
            }

            // 単価端数初期区分左寄せ
            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].CellAppearance.TextHAlign = HAlign.Left;

            // スクロールバーの位置を初期化
            this.Detail_uGrid.DisplayLayout.ColScrollRegions.Clear();

            this.Detail_uGrid.Enabled = false;

            this._prevColumnIndex = -1;
        }

        #endregion 画面クリア処理

        /// <summary>
        /// 画面情報初期設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報の初期設定を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // 単価種類
            this.UnitPriceKind_tComboEditor.Items.Clear();
            this.UnitPriceKind_tComboEditor.Items.Add("1", UNITPRICEKIND_1);
            this.UnitPriceKind_tComboEditor.Items.Add("2", UNITPRICEKIND_2);
            this.UnitPriceKind_tComboEditor.Items.Add("3", UNITPRICEKIND_3);

            // 設定方法
            this.UnitPriceKindWay_tComboEditor.Items.Clear();
            this.UnitPriceKindWay_tComboEditor.Items.Add(1, UNITPRICEKINDWAY_1);
            this.UnitPriceKindWay_tComboEditor.Items.Add(0, UNITPRICEKINDWAY_0);

            // 得意先掛率グループ
            GetCustRateGrp();
            this.CustRateGrpCode_tComboEditor.Items.Clear();
            foreach (DictionaryEntry dic in this._custRateGrpList)
            {
                this.CustRateGrpCode_tComboEditor.Items.Add((int)dic.Key, (string)dic.Value);
            }
        }

        /// <summary>
        /// フォーカス設定処理
        /// </summary>
        /// <param name="prevButton">押下ガイドボタン</param>
        /// <remarks>
        /// <br>Note       : ガイドボタン押下後のフォーカス設定を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void SetFocus(UltraButton prevButton)
        {
            // 拠点ガイドボタン
            if (prevButton.Name == "SectionGuide_Button")
            {
                // 単価種類にフォーカス設定
                this.UnitPriceKind_tComboEditor.Focus();
                return;
            }

            // 掛率設定区分
            string rateSettingDivide = this.RateSettingDivide_tEdit.DataText.Trim();

            switch (prevButton.Name)
            {
                // 掛率設定区分ガイドボタン
                case "RateSettingDivideGuide_Button":
                    if (RateAcs.IsCustomerSetting(rateSettingDivide))
                    {
                        // 得意先コードにフォーカス設定
                        this.tNedit_CustomerCode.Focus();
                    }
                    else if (RateAcs.IsCustRateGrpSetting(rateSettingDivide))
                    {
                        // 得意先掛率グループにフォーカス設定
                        this.CustRateGrpCode_tComboEditor.Focus();
                    }
                    else if (RateAcs.IsSupplierSetting(rateSettingDivide))
                    {
                        // 仕入先コードにフォーカス設定
                        this.tNedit_SupplierCd.Focus();
                    }
                    else if (RateAcs.IsMakerSetting(rateSettingDivide))
                    {
                        // メーカーコードにフォーカス設定
                        this.tNedit_GoodsMakerCd.Focus();
                    }
                    else if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        // 層別にフォーカス設定
                        this.GoodsRateRank_tEdit.Focus();
                    }
                    else if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        // 商品掛率Ｇコードにフォーカス設定
                        this.tNedit_GoodsMGroup.Focus();
                    }
                    else if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        // BLグループコードにフォーカス設定
                        this.tNedit_BLGloupCode.Focus();
                    }
                    else if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        // BLコードにフォーカス設定
                        this.tNedit_BLGoodsCode.Focus();
                    }
                    else if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        // 品番コードにフォーカス設定
                        this.tEdit_GoodsNo.Focus();
                    }
                    else
                    {
                        // グリッドにフォーカス設定
                        this.Detail_uGrid.Focus();
                    }
                    return;
                // 得意先ガイドボタン
                case "CustomerGuide_Button":
                    if (RateAcs.IsCustRateGrpSetting(rateSettingDivide))
                    {
                        // 得意先掛率グループにフォーカス設定
                        this.CustRateGrpCode_tComboEditor.Focus();
                    }
                    else if (RateAcs.IsSupplierSetting(rateSettingDivide))
                    {
                        // 仕入先コードにフォーカス設定
                        this.tNedit_SupplierCd.Focus();
                    }
                    else if (RateAcs.IsMakerSetting(rateSettingDivide))
                    {
                        // メーカーコードにフォーカス設定
                        this.tNedit_GoodsMakerCd.Focus();
                    }
                    else if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        // 層別にフォーカス設定
                        this.GoodsRateRank_tEdit.Focus();
                    }
                    else if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        // 商品掛率Ｇコードにフォーカス設定
                        this.tNedit_GoodsMGroup.Focus();
                    }
                    else if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        // BLグループコードにフォーカス設定
                        this.tNedit_BLGloupCode.Focus();
                    }
                    else if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        // BLコードにフォーカス設定
                        this.tNedit_BLGoodsCode.Focus();
                    }
                    else if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        // 品番コードにフォーカス設定
                        this.tEdit_GoodsNo.Focus();
                    }
                    else
                    {
                        // グリッドにフォーカス設定
                        this.Detail_uGrid.Focus();
                    }
                    return;
                // 仕入先ガイドボタン
                case "SupplierGuide_Button":
                    if (RateAcs.IsMakerSetting(rateSettingDivide))
                    {
                        // メーカーコードにフォーカス設定
                        this.tNedit_GoodsMakerCd.Focus();
                    }
                    else if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        // 層別にフォーカス設定
                        this.GoodsRateRank_tEdit.Focus();
                    }
                    else if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        // 商品掛率Ｇコードにフォーカス設定
                        this.tNedit_GoodsMGroup.Focus();
                    }
                    else if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        // BLグループコードにフォーカス設定
                        this.tNedit_BLGloupCode.Focus();
                    }
                    else if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        // BLコードにフォーカス設定
                        this.tNedit_BLGoodsCode.Focus();
                    }
                    else if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        // 品番コードにフォーカス設定
                        this.tEdit_GoodsNo.Focus();
                    }
                    else
                    {
                        // グリッドにフォーカス設定
                        this.Detail_uGrid.Focus();
                    }
                    return;
                // メーカーガイドボタン
                case "MakerGuide_Button":
                    if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        // 層別にフォーカス設定
                        this.GoodsRateRank_tEdit.Focus();
                    }
                    else if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        // 商品掛率Ｇコードにフォーカス設定
                        this.tNedit_GoodsMGroup.Focus();
                    }
                    else if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        // BLグループコードにフォーカス設定
                        this.tNedit_BLGloupCode.Focus();
                    }
                    else if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        // BLコードにフォーカス設定
                        this.tNedit_BLGoodsCode.Focus();
                    }
                    else if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        // 品番コードにフォーカス設定
                        this.tEdit_GoodsNo.Focus();
                    }
                    else
                    {
                        // グリッドにフォーカス設定
                        this.Detail_uGrid.Focus();
                    }
                    return;
                // 商品掛率Ｇガイドボタン
                case "GoodsRateGrpGuide_Button":
                    if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        // BLグループコードにフォーカス設定
                        this.tNedit_BLGloupCode.Focus();
                    }
                    else if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        // BLコードにフォーカス設定
                        this.tNedit_BLGoodsCode.Focus();
                    }
                    else if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        // 品番コードにフォーカス設定
                        this.tEdit_GoodsNo.Focus();
                    }
                    else
                    {
                        // グリッドにフォーカス設定
                        this.Detail_uGrid.Focus();
                    }
                    return;
                // BLグループコードガイドボタン
                case "BLGroupGuide_Button":
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        // BLコードにフォーカス設定
                        this.tNedit_BLGoodsCode.Focus();
                    }
                    else if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        // 品番コードにフォーカス設定
                        this.tEdit_GoodsNo.Focus();
                    }
                    else
                    {
                        // グリッドにフォーカス設定
                        this.Detail_uGrid.Focus();
                    }
                    return;
                // BLコードガイドボタン
                case "BLGoodsGuide_Button":
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        // 品番コードにフォーカス設定
                        this.tEdit_GoodsNo.Focus();
                    }
                    else
                    {
                        // グリッドにフォーカス設定
                        this.Detail_uGrid.Focus();
                    }
                    break;
                default:
                    // グリッドにフォーカス設定
                    this.Detail_uGrid.Focus();
                    return;
            }
        }

        #region マスタ情報取得

        /// <summary>
        /// ユーザーガイドデータ取得処理
        /// </summary>
        /// <param name="retList">ユーザーガイドボディデータリスト</param>
        /// <param name="userGuideDivCd">ガイド区分</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ユーザーガイドデータを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
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
        /// 得意先掛率グループ情報取得処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループ情報を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private int GetCustRateGrp()
        {
            this._custRateGrpList = new SortedList();

            int status;
            ArrayList retList = new ArrayList();

            // ユーザーガイドデータ取得(得意先掛率グループ)
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
        /// 拠点名称取得処理
        /// </summary>
        /// <param name="sectionCode">拠点コード</param>
        /// <returns>拠点名称</returns>
        /// <remarks>
        /// <br>Note       : 拠点名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            // 全社の場合
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
        /// 掛率優先管理マスタ取得処理
        /// </summary>
        /// <param name="rateProtyMng">掛率優先管理マスタオブジェクト</param>
        /// <param name="RateSettingDivCode">掛率設定区分</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 掛率優先管理マスタを取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private int GetRateProtyMng(out RateProtyMng rateProtyMng, string RateSettingDivCode)
        {
            int status = -1;
            rateProtyMng = new RateProtyMng();

            // 拠点コード
            if (this.tEdit_SectionCodeAllowZero.DataText == "")
            {
                return status;
            }
            string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();

            // 単価種類
            if (this.UnitPriceKind_tComboEditor.Value == null)
            {
                return status;
            }
            int unitPriceKindCode = int.Parse((string)this.UnitPriceKind_tComboEditor.Value);

            // 設定方法
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
        /// 得意先名称取得処理
        /// </summary>
        /// <param name="customerCode">得意先コード</param>
        /// <returns>得意先名称</returns>
        /// <remarks>
        /// <br>Note       : 得意先名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
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
        /// 仕入先名称取得処理
        /// </summary>
        /// <param name="supplierCode">仕入先コード</param>
        /// <returns>仕入先名称</returns>
        /// <remarks>
        /// <br>Note       : 仕入先名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
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
        /// メーカー名称取得処理
        /// </summary>
        /// <param name="makerCode">メーカーコード</param>
        /// <returns>メーカー名称</returns>
        /// <remarks>
        /// <br>Note       : メーカー名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
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
        /// 商品掛率Ｇ名称取得処理
        /// </summary>
        /// <param name="goodsMGroupCode">商品掛率Ｇコード</param>
        /// <returns>商品掛率Ｇ名称</returns>
        /// <remarks>
        /// <br>Note       : 商品掛率Ｇ名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
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
        /// BLグループ名称取得処理
        /// </summary>
        /// <param name="blGroupCode">BLグループコード</param>
        /// <returns>BLグループ名称</returns>
        /// <remarks>
        /// <br>Note       : BLグループ名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
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
        /// BLコード名称取得処理
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        /// <returns>BLコード名称</returns>
        /// <remarks>
        /// <br>Note       : BLコード名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
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
        /// 商品情報取得処理
        /// </summary>
        /// <param name="goodsUnitData">商品マスタ</param>
        /// <param name="goodsCode">商品コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private int GetGoodsInfo(out GoodsUnitData goodsUnitData, string goodsCode)
        {
            return GetGoodsInfo(out goodsUnitData, goodsCode, this.tNedit_GoodsMakerCd.GetInt());
        }
        // --- ADD 2009/03/16 --------------------------------<<<<<

        /// <summary>
        /// 商品情報取得処理
        /// </summary>
        /// <param name="goodsUnitData">商品マスタ</param>
        /// <param name="goodsCode">商品コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品名称を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
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
        /// 商品価格取得処理
        /// </summary>
        /// <param name="goodsPriceList">商品価格リスト</param>
        /// <returns>商品価格</returns>
        /// <remarks>
        /// <br>Note       : 商品価格を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
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

        #endregion マスタ情報取得

        #region 画面入力許可設定

        /// <summary>
        /// 画面入力許可設定処理
        /// </summary>
        /// <param name="editMode">編集モード(新規・更新・削除)</param>
        /// <remarks>
        /// <br>Note       : 画面コントロールの入力許可を設定します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
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
            // 保存ボタンのアイコン設定
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["Save_ButtonTool"];
            if (workButton != null) workButton.SharedProps.Visible = false;

            // 削除ボタン非表示
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["Delete_ButtonTool"];
            if (workButton != null) workButton.SharedProps.Visible = false;

            // 復活ボタン非表示
            workButton = (ButtonTool)Main_ToolbarsManager.Tools["Revival_ButtonTool"];
            if (workButton != null) workButton.SharedProps.Visible = false;

            switch (editMode)
            {
                // 新規モード
                case INSERT_MODE:

                    this.tEdit_SectionCodeAllowZero.Enabled = true;
                    this.UnitPriceKind_tComboEditor.Enabled = true;
                    this.UnitPriceKindWay_tComboEditor.Enabled = true;
                    this.RateSettingDivide_tEdit.Enabled = true;

                    this.SectionGuide_Button.Enabled = true;
                    this.RateSettingDivideGuide_Button.Enabled = true;

                    // 保存ボタン表示
                    workButton = (ButtonTool)Main_ToolbarsManager.Tools["Save_ButtonTool"];
                    if (workButton != null) workButton.SharedProps.Visible = true;

                    break;
                // 更新モード
                case UPDATE_MODE:

                    this.Detail_uGrid.Enabled = true;

                    // 保存ボタン表示
                    workButton = (ButtonTool)Main_ToolbarsManager.Tools["Save_ButtonTool"];
                    if (workButton != null) workButton.SharedProps.Visible = true;

                    // 削除ボタン表示
                    workButton = (ButtonTool)Main_ToolbarsManager.Tools["Delete_ButtonTool"];
                    if (workButton != null) workButton.SharedProps.Visible = true;

                    break;
                // 削除モード
                case DELETE_MODE:

                    // 削除ボタン表示
                    workButton = (ButtonTool)Main_ToolbarsManager.Tools["Delete_ButtonTool"];
                    if (workButton != null) workButton.SharedProps.Visible = true;

                    // 復活ボタン表示
                    workButton = (ButtonTool)Main_ToolbarsManager.Tools["Revival_ButtonTool"];
                    if (workButton != null) workButton.SharedProps.Visible = true;

                    break;
            }
        }

        /// <summary>
        /// グリッド入力許可設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : グリッドの入力許可を設定します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
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

            // 単価種類
            int unitPriceKindCode = int.Parse((string)this.UnitPriceKind_tComboEditor.Value);

            // 設定方法
            int unitPriceKindWayCode = (int)this.UnitPriceKindWay_tComboEditor.Value;

            for (int rowIndex = 0; rowIndex < ROW_COUNT; rowIndex++)
            {
                switch (rowIndex)
                {
                    // 数量(以上)
                    case ROWINDEX_LOTCOUNTABOVE:
                        // 売価設定
                        if (unitPriceKindCode == 1)
                        {
                            // セル入力許可設定
                            SetCellEnabled(rowIndex, 1);
                        }
                        break;
                    // 数量(以下)
                    case ROWINDEX_LOTCOUNTBELOW:
                        break;
                    // 売価率、原価UP率、粗利確保率
                    case ROWINDEX_SALERATEVAL:
                    case ROWINDEX_COSTUPRATE:
                    case ROWINDEX_GRSPROFITSECURERATE:
                        // 売価設定
                        if (unitPriceKindCode == 1)
                        {
                            // セル入力許可設定
                            SetCellEnabled(rowIndex, 0);
                        }
                        break;
                    // 売価額
                    case ROWINDEX_SALEPRICEFL:
                        // 売価設定
                        if (unitPriceKindCode == 1)
                        {
                            // 単品設定
                            if (unitPriceKindWayCode == 0)
                            {
                                // セル入力許可設定
                                SetCellEnabled(rowIndex, 0);
                            }
                        }
                        break;
                    // 仕入率
                    case ROWINDEX_COSTRATEVAL:
                        // 原価設定
                        if (unitPriceKindCode == 2)
                        {
                            // セル入力許可設定
                            SetCellEnabled(rowIndex, 0);
                        }
                        break;
                    // 仕入原価
                    case ROWINDEX_COSTPRICEFL:
                        // 原価設定
                        if (unitPriceKindCode == 2)
                        {
                            // 単品設定
                            if (unitPriceKindWayCode == 0)
                            {
                                // セル入力許可設定
                                SetCellEnabled(rowIndex, 0);
                            }
                        }
                        break;
                    // ユーザー定価
                    case ROWINDEX_USERPRICEFL:
                        // 価格設定
                        if (unitPriceKindCode == 3)
                        {
                            // 単品設定
                            if (unitPriceKindWayCode == 0)
                            {
                                // セル入力許可設定
                                SetCellEnabled(rowIndex, 0);
                            }
                        }
                        break;
                    // 定価UP率
                    case ROWINDEX_PRICEUPRATE:
                        // 価格設定
                        if (unitPriceKindCode == 3)
                        {
                            // セル入力許可設定
                            SetCellEnabled(rowIndex, 0);
                        }
                        break;
                    // 単価端数処理単位、単価端数処理区分
                    case ROWINDEX_UNPRCFRACPROCUNIT:
                    case ROWINDEX_UNPRCFRACPROCDIV:
                        // セル入力許可設定
                        SetCellEnabled(rowIndex, 0);
                        break;
                }
            }
        }

        /// <summary>
        /// セル入力許可設定処理
        /// </summary>
        /// <param name="rowIndex">行インデックス</param>
        /// <param name="allowEditColumnIndex">入力可能列インデックス</param>
        /// <remarks>
        /// <br>Note       : セルの入力許可を設定します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void SetCellEnabled(int rowIndex, int allowEditColumnIndex)
        {
            // 対象行を入力可に設定
            this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Activation = Activation.AllowEdit;

            // 列数分だけループ
            for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
            {
                if (columnIndex == allowEditColumnIndex)
                {
                    // 対象のセルを入力可に設定
                    this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activation = Activation.AllowEdit;
                }
                else
                {
                    // 対象のセルを入力不可に設定
                    this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activation = Activation.Disabled;
                }
            }
        }

        /// <summary>
        /// セル入力許可変更処理
        /// </summary>
        /// <param name="columnIndex">列インデックス</param>
        /// <remarks>
        /// <br>Note       : セルの入力許可を変更します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void ChangeCellEnabled(int columnIndex)
        {
            // 設定方法
            int unitPriceKindWayCode = (int)this.UnitPriceKindWay_tComboEditor.Value;

            for (int rowIndex = 0; rowIndex < ROW_COUNT; rowIndex++)
            {
                // 単品設定
                if (unitPriceKindWayCode == 0)
                {
                    switch (rowIndex)
                    {
                        // 売価率、売価額、原価UP率、粗利確保率、単価端数処理単位、単価端数処理区分
                        case ROWINDEX_SALERATEVAL:
                        case ROWINDEX_SALEPRICEFL:
                        case ROWINDEX_COSTUPRATE:
                        case ROWINDEX_GRSPROFITSECURERATE:
                        case ROWINDEX_UNPRCFRACPROCUNIT:
                        case ROWINDEX_UNPRCFRACPROCDIV:
                            // 対象セルを入力可能に変更
                            this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Activation = Activation.AllowEdit;
                            this.Detail_uGrid.DisplayLayout.Rows[rowIndex].Cells[columnIndex].Activation = Activation.AllowEdit;
                            break;
                        default:
                            break;
                    }
                }
                // グループ設定
                else
                {
                    switch (rowIndex)
                    {
                        // 売価率、原価UP率、粗利確保率、単価端数処理単位、単価端数処理区分
                        case ROWINDEX_SALERATEVAL:
                        case ROWINDEX_COSTUPRATE:
                        case ROWINDEX_GRSPROFITSECURERATE:
                        case ROWINDEX_UNPRCFRACPROCUNIT:
                        case ROWINDEX_UNPRCFRACPROCDIV:
                            // 対象セルを入力可能に変更
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
        /// 条件コントロール(取引先)入力許可設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 条件コントロール(取引先)の入力許可を設定します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void SetCustomerConditionEnabled()
        {
            // 掛率設定区分
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

            // 得意先が掛率設定区分の設定対象かを取得
            if (RateAcs.IsCustomerSetting(rateSettingDivide))
            {
                this.tNedit_CustomerCode.Enabled = true;
                this.CustomerGuide_Button.Enabled = true;
            }
            // 仕入先が掛率設定区分の設定対象かを取得
            if (RateAcs.IsSupplierSetting(rateSettingDivide))
            {
                this.tNedit_SupplierCd.Enabled = true;
                this.SupplierGuide_Button.Enabled = true;
            }
            // 得意先掛率設定GRが掛率設定区分の設定対象かを取得
            if (RateAcs.IsCustRateGrpSetting(rateSettingDivide))
            {
                this.CustRateGrpCode_tComboEditor.Enabled = true;
            }
        }

        /// <summary>
        /// フォーカス設定処理
        /// </summary>
        /// <param name="index">カレントコントロール(0:掛率設定区分　1:得意先　2:仕入先　3:メーカー  4:商品掛率Ｇ　5:グループコード　6:BLコード)</param>
        private void SetNextFocus(int index)
        {
            // 掛率設定区分
            string rateSettingDivide = this.RateSettingDivide_tEdit.DataText.Trim();

            switch (index)
            {
                // 掛率設定区分
                case 0:
                    // 得意先が掛率設定区分の設定対象かを取得
                    if (RateAcs.IsCustomerSetting(rateSettingDivide))
                    {
                        this.tNedit_CustomerCode.Focus();
                        return;
                    }
                    // 得意先掛率設定GRが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsCustRateGrpSetting(rateSettingDivide))
                    {
                        this.CustRateGrpCode_tComboEditor.Focus();
                        return;
                    }
                    // 仕入先が掛率設定区分の設定対象かを取得
                    if (RateAcs.IsSupplierSetting(rateSettingDivide))
                    {
                        this.tNedit_SupplierCd.Focus();
                        return;
                    }
                    // メーカーが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsMakerSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMakerCd.Focus();
                        return;
                    }
                    // 層別が掛率設定区分の設定対象かを取得
                    if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        this.GoodsRateRank_tEdit.Focus();
                        return;
                    }
                    // 商品掛率Ｇが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMGroup.Focus();
                        return;
                    }
                    // BLグループコードが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGloupCode.Focus();
                        return;
                    }
                    // BLコードが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        return;
                    }
                    // 品番が掛率設定区分の設定対象かを取得
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        return;
                    }
                    break;
                // 得意先コード
                case 1:
                    // 得意先掛率設定GRが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsCustRateGrpSetting(rateSettingDivide))
                    {
                        this.CustRateGrpCode_tComboEditor.Focus();
                        return;
                    }
                    // 仕入先が掛率設定区分の設定対象かを取得
                    if (RateAcs.IsSupplierSetting(rateSettingDivide))
                    {
                        this.tNedit_SupplierCd.Focus();
                        return;
                    }
                    // メーカーが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsMakerSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMakerCd.Focus();
                        return;
                    }
                    // 層別が掛率設定区分の設定対象かを取得
                    if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        this.GoodsRateRank_tEdit.Focus();
                        return;
                    }
                    // 商品掛率Ｇが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMGroup.Focus();
                        return;
                    }
                    // BLグループコードが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGloupCode.Focus();
                        return;
                    }
                    // BLコードが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        return;
                    }
                    // 品番が掛率設定区分の設定対象かを取得
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        return;
                    }
                    break;
                // 仕入先コード
                case 2:
                    // メーカーが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsMakerSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMakerCd.Focus();
                        return;
                    }
                    // 層別が掛率設定区分の設定対象かを取得
                    if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        this.GoodsRateRank_tEdit.Focus();
                        return;
                    }
                    // 商品掛率Ｇが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMGroup.Focus();
                        return;
                    }
                    // BLグループコードが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGloupCode.Focus();
                        return;
                    }
                    // BLコードが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        return;
                    }
                    // 品番が掛率設定区分の設定対象かを取得
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        return;
                    }
                    break;
                // メーカー
                case 3:
                    // 層別が掛率設定区分の設定対象かを取得
                    if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
                    {
                        this.GoodsRateRank_tEdit.Focus();
                        return;
                    }
                    // 商品掛率Ｇが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_GoodsMGroup.Focus();
                        return;
                    }
                    // BLグループコードが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGloupCode.Focus();
                        return;
                    }
                    // BLコードが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        return;
                    }
                    // 品番が掛率設定区分の設定対象かを取得
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        return;
                    }
                    break;
                // 商品掛率Ｇ
                case 4:
                    // BLグループコードが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGloupCode.Focus();
                        return;
                    }
                    // BLコードが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        return;
                    }
                    // 品番が掛率設定区分の設定対象かを取得
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        return;
                    }
                    break;
                // グループコード
                case 5:
                    // BLコードが掛率設定区分の設定対象かを取得
                    if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
                    {
                        this.tNedit_BLGoodsCode.Focus();
                        return;
                    }
                    // 品番が掛率設定区分の設定対象かを取得
                    if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                    {
                        this.tEdit_GoodsNo.Focus();
                        return;
                    }
                    break;
                // BLコード
                case 6:
                    // 品番が掛率設定区分の設定対象かを取得
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
        /// 条件コントロール(商品)入力許可設定処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 条件コントロール(商品)の入力許可を設定します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void SetGoodsConditionEnabled()
        {
            // 掛率設定区分
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

            // メーカーが掛率設定区分の設定対象かを取得
            if (RateAcs.IsMakerSetting(rateSettingDivide))
            {
                this.tNedit_GoodsMakerCd.Enabled = true;
                this.MakerGuide_Button.Enabled = true;
            }
            // 層別が掛率設定区分の設定対象かを取得
            if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
            {
                this.GoodsRateRank_tEdit.Enabled = true;
            }
            // 商品掛率Ｇが掛率設定区分の設定対象かを取得
            if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
            {
                this.tNedit_GoodsMGroup.Enabled = true;
                this.GoodsRateGrpGuide_Button.Enabled = true;
            }
            // BLグループコードが掛率設定区分の設定対象かを取得
            if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
            {
                this.tNedit_BLGloupCode.Enabled = true;
                this.BLGroupGuide_Button.Enabled = true;
            }
            // BLコードが掛率設定区分の設定対象かを取得
            if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
            {
                this.tNedit_BLGoodsCode.Enabled = true;
                this.BLGoodsGuide_Button.Enabled = true;
            }
            // 品番が掛率設定区分の設定対象かを取得
            if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
            {
                this.tEdit_GoodsNo.Enabled = true;
            }
        }

        #endregion 画面入力許可設定

        #region メッセージボックス表示

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <param name="defaultButton">初期表示ボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string message, int status, MessageBoxButtons msgButton, MessageBoxDefaultButton defaultButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this,                              // 親ウィンドウフォーム
                                         errLevel,                          // エラーレベル
                                         ASSEMBLY_ID,                       // アセンブリID
                                         message,                           // 表示するメッセージ
                                         status,                            // ステータス値
                                         msgButton,                         // 表示するボタン
                                         defaultButton);                    // 初期表示ボタン
            return dialogResult;
        }

        /// <summary>
        /// メッセージボックス表示処理
        /// </summary>
        /// <param name="errLevel">エラーレベル</param>
        /// <param name="methodName">処理名称</param>
        /// <param name="message">表示するメッセージ</param>
        /// <param name="status">ステータス値</param>
        /// <param name="msgButton">表示するボタン</param>
        /// <returns>DialogResult</returns>
        /// <remarks>
        /// <br>Note       : メッセージボックスを表示します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private DialogResult ShowMessageBox(emErrorLevel errLevel, string methodName, string message, int status, MessageBoxButtons msgButton)
        {
            DialogResult dialogResult;
            dialogResult = TMsgDisp.Show(this, 						        // 親ウィンドウフォーム
                                         errLevel,			                // エラーレベル
                                         this.Name,						    // プログラム名称
                                         ASSEMBLY_ID, 		  　　			// アセンブリID
                                         methodName,						// 処理名称
                                         "",					            // オペレーション
                                         message,	                        // 表示するメッセージ
                                         status,							// ステータス値
                                         this._rateAcs,					    // エラーが発生したオブジェクト
                                         msgButton,         			  	// 表示するボタン
                                         MessageBoxDefaultButton.Button1);	// 初期表示ボタン

            return dialogResult;
        }

        #endregion メッセージボックス表示

        /// <summary>
        /// 掛率マスタ新規作成処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタを新規作成します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private bool NewProc()
        {
            this.Enabled = false;

            // 画面入力許可制御
            ScreenInputPermissionControl(INSERT_MODE);

            // 画面情報クリア
            ScreenClear();

            // グリッド初期化
            ClearGrid("");

            this.Enabled = true;

            // フォーカス設定
            this.tEdit_SectionCodeAllowZero.Focus();

            this._rateListClone = new List<Rate>();

            return (true);
        }

        /// <summary>
        /// 掛率マスタ保存処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタの保存を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private bool SaveProc()
        {
            bool bStatus;
            int status;
            string msg;
            int saveRecordCount;

            // 入力チェック
            bStatus = CheckInputScreen(true);
            if (bStatus != true)
            {
                return (false);
            }

            // 単価種類
            if (this.UnitPriceKind_tComboEditor.Value == null)
            {
                return (false);
            }
            string unitPriceKind = (string)this.UnitPriceKind_tComboEditor.Value;

            // 保存件数取得
            saveRecordCount = GetSaveRecordCount(unitPriceKind);

            // 保存リスト
            ArrayList saveList = new ArrayList();

            // 削除リスト
            ArrayList deleteList = new ArrayList();
            bool deleteFlg = false;

            if (this._rateListClone.Count != 0)
            {
                // ----------------------
                // 更新の場合
                // ----------------------
                deleteFlg = true;

                foreach (Rate wkRate in this._rateListClone)
                {
                    // 削除リストに追加
                    deleteList.Add(wkRate.Clone());
                }
            }

            for (int index = 0; index < saveRecordCount; index++)
            {
                Rate rate = new Rate();

                // 画面情報取得
                ScreenToRate(ref rate, index);

                // 保存リストに追加
                saveList.Add(rate);
            }

            if (deleteFlg == true)
            {
                // 物理削除処理
                status = this._rateAcs.Delete(ref deleteList, out msg);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (false);
                    default:
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "SaveProc",
                                       "掛率マスタ削除時にエラーが発生しました。",
                                       status,
                                       MessageBoxButtons.OK);

                        return (false);
                }
            }

            // 保存処理
            status = this._rateAcs.Write(ref saveList, out msg);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                   "キー項目が重複しています。",
                                   status,
                                   MessageBoxButtons.OK,
                                   MessageBoxDefaultButton.Button1);
                    return (false);
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status);
                    return (false);
                default:
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "SaveProc",
                                       "掛率マスタ修正時にエラーが発生しました。",
                                       status,
                                       MessageBoxButtons.OK);
                    return (false);
            }

            // 登録完了ダイアログ表示
            SaveCompletionDialog dialog = new SaveCompletionDialog();
            dialog.ShowDialog(2);

            // 新規作成処理
            NewProc();

            return (true);
        }

        /// <summary>
        /// 掛率マスタ検索処理(フォーカス移動後)
        /// </summary>
        private void SearchAfterLeaveControl()
        {
            string errMsg;
            bool bStatus;

            // 掛率設定チェック
            bStatus = CheckRateCondition(out errMsg, false, false);
            if (!bStatus)
            {
                return;
            }

            // 取引先設定チェック
            bStatus = CheckCustomerCondition(out errMsg, false, false);
            if (!bStatus)
            {
                return;
            }

            // 商品設定チェック
            bStatus = CheckGoodsCondition(out errMsg, false, false);
            if (!bStatus)
            {
                return;
            }

            // 検索処理
            SearchProc();
        }

        /// <summary>
        /// 掛率マスタ検索処理
        /// </summary>
        /// <param name="msgFlg">メッセージフラグ(True:表示　False:非表示)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタの検索を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private bool SearchProc()
        {
            int status;
            bool bStatus;

            // 検索条件入力チェック
            bStatus = CheckInputScreen(false);
            if (bStatus == false)
            {
                return (false);
            }
            
            // 検索条件設定
            Rate rate = new Rate();
            RateConditionToRate(ref rate);
            CustomerConditionToRate(ref rate);
            GoodsConditionToRate(ref rate);

            ArrayList retList = new ArrayList();
            string msg;
            
            // 検索処理
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

            // 画面クリア
            ScreenClear();

            // グリッド初期化
            ClearGrid(rateList[0].UnitPriceKind.Trim());

            // 画面コントロール入力許可制御
            if (rateList[0].LogicalDeleteCode == 0)
            {
                // 更新モード
                this.Mode_Label.Text = UPDATE_MODE;
                ScreenInputPermissionControl(UPDATE_MODE);
            }
            else
            {
                // 削除モード
                this.Mode_Label.Text = DELETE_MODE;
                ScreenInputPermissionControl(DELETE_MODE);
            }

            // 掛率マスタ画面展開
            RateToScreen(rateList);

            if (rateList[0].LogicalDeleteCode == 0)
            {
                // グリッド入力制御
                SetGridEnabled();

                // 売価設定のときのみ
                string unitPriceKind = (string)this.UnitPriceKind_tComboEditor.Value;
                if (unitPriceKind == "1")
                {
                    for (int index = 0; index < rateList.Count; index++)
                    {
                        // セル入力許可変更
                        ChangeCellEnabled(index);
                    }

                    // 数量(以上)の入力許可制御
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

            // 検索後のフォーカス設定を行います
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
        /// 掛率マスタ論理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタの論理削除を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private bool LogicalDeleteProc()
        {
            // 論理削除確認
            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                 "データを論理削除します。\r\nよろしいですか？",
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

                // 論理削除処理
                status = this._rateAcs.LogicalDelete(ref deleteList, out msg);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (false);
                    default:
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "LogicalDeleteProc",
                                       "掛率マスタ削除時にエラーが発生しました。",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                }

                // 新規作成処理
                NewProc();
            }

            return (true);
        }

        /// <summary>
        /// 掛率マスタ物理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタの物理削除を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private bool DeleteProc()
        {
            // 完全削除確認
            DialogResult result = ShowMessageBox(emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                                 "データを物理削除します。\r\nよろしいですか？",
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

                // 物理削除処理
                status = this._rateAcs.Delete(ref deleteList, out msg);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                        // 排他処理
                        ExclusiveTransaction(status);
                        return (false);
                    default:
                        ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "DeleteProc",
                                       "掛率マスタ削除時にエラーが発生しました。",
                                       status,
                                       MessageBoxButtons.OK);
                        return (false);
                }

                // 新規作成処理
                NewProc();
            }

            return (true);
        }

        /// <summary>
        /// 掛率マスタ復活処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタの復活を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
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

            // 復活処理
            status = this._rateAcs.Revival(ref revivalList, out msg);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    // 排他処理
                    ExclusiveTransaction(status);
                    return (false);
                default:
                    ShowMessageBox(emErrorLevel.ERR_LEVEL_STOP,
                                       "RevivalProc",
                                       "掛率マスタ復活時にエラーが発生しました。",
                                       status,
                                       MessageBoxButtons.OK);
                    return (false);
            }

            // 新規作成処理
            NewProc();

            return (true);
        }

        #region チェック処理

        /// <summary>
        /// 画面情報入力チェック処理
        /// </summary>
        /// <param name="saveFlg">保存フラグ(True:保存前チェック　False:検索条件チェック)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面情報の入力チェックを行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private bool CheckInputScreen(bool saveFlg)
        {
            string errMsg = "";
            bool bStatus;

            try
            {
                // 掛率設定チェック
                bStatus = CheckRateCondition(out errMsg, saveFlg, true);
                if (!bStatus)
                {
                    return (false);
                }

                // 取引先設定チェック
                bStatus = CheckCustomerCondition(out errMsg, saveFlg, true);
                if (!bStatus)
                {
                    return (false);
                }

                // 商品設定チェック
                bStatus = CheckGoodsCondition(out errMsg, saveFlg, true);
                if (!bStatus)
                {
                    return (false);
                }

                if (saveFlg == true)
                {
                    // グリッドチェック
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
        /// 画面情報(掛率設定)入力チェック処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="saveFlg">保存フラグ(True:保存前チェック  False:検索条件チェック)</param>
        /// <param name="focusFlg">フォーカス設定フラグ(True:設定する　False:設定しない)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面情報(掛率設定)の入力チェックを行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private bool CheckRateCondition(out string errMsg, bool saveFlg, bool focusFlg)
        {
            errMsg = "";

            // 拠点コード
            if (this.tEdit_SectionCodeAllowZero.DataText.Trim() == "")
            {
                errMsg = "拠点コードを入力してください。";
                if (focusFlg == true)
                {
                    this.tEdit_SectionCodeAllowZero.Focus();
                }
                return (false);
            }
            if (saveFlg == true)
            {
                // 保存前チェック時のみ
                string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();
                if (GetSectionName(sectionCode) == "")
                {
                    errMsg = "マスタに登録されていません。";
                    if (focusFlg == true)
                    {
                        this.tEdit_SectionCodeAllowZero.Focus();
                    }
                    return (false);
                }
            }
            // 単価種類
            if (this.UnitPriceKind_tComboEditor.Value == null)
            {
                errMsg = "単価種類を選択してください。";
                if (focusFlg == true)
                {
                    this.UnitPriceKind_tComboEditor.Focus();
                }
                return (false);
            }
            // 設定方法
            if (this.UnitPriceKindWay_tComboEditor.Value == null)
            {
                errMsg = "設定方法を選択してください。";
                if (focusFlg == true)
                {
                    this.UnitPriceKindWay_tComboEditor.Focus();
                }
                return (false);
            }
            // 掛率設定区分
            if (this.RateSettingDivide_tEdit.DataText.Trim() == "")
            {
                errMsg = "掛率設定区分を入力してください。";
                if (focusFlg == true)
                {
                    this.RateSettingDivide_tEdit.Focus();
                }
                return (false);
            }
            if (saveFlg == true)
            {
                // 保存前チェック時のみ
                string rateSettingDivideCode = this.RateSettingDivide_tEdit.DataText;
                RateProtyMng rateProgyMng = new RateProtyMng();
                if (GetRateProtyMng(out rateProgyMng, rateSettingDivideCode) != 0)
                {
                    errMsg = "マスタに登録されていません。";
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
        /// 画面情報(取引先設定)入力チェック処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="saveFlg">保存フラグ(True:保存前チェック  False:検索条件チェック)</param>
        /// <param name="focusFlg">フォーカス設定フラグ(True:設定する　False:設定しない)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面情報(取引先設定)の入力チェックを行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private bool CheckCustomerCondition(out string errMsg, bool saveFlg, bool focusFlg)
        {
            errMsg = "";

            // 掛率設定区分
            string rateSettingDivide = this.RateSettingDivide_tEdit.DataText.Trim();

            // 得意先コード
            if (RateAcs.IsCustomerSetting(rateSettingDivide))
            {
                if (this.tNedit_CustomerCode.GetInt() == 0)
                {
                    errMsg = "得意先コードを入力してください。";
                    if (focusFlg == true)
                    {
                        this.tNedit_CustomerCode.Focus();
                    }
                    return (false);
                }
                if (saveFlg == true)
                {
                    // 保存前チェックのみ
                    int customerCode = this.tNedit_CustomerCode.GetInt();
                    if (GetCustomerName(customerCode) == "")
                    {
                        errMsg = "マスタに登録されていません。";
                        if (focusFlg == true)
                        {
                            this.tNedit_CustomerCode.Focus();
                        }
                        return (false);
                    }
                }
            }

            // 得意先掛率グループコード
            if (RateAcs.IsCustRateGrpSetting(rateSettingDivide))
            {
                if (this.CustRateGrpCode_tComboEditor.Value == null)
                {
                    errMsg = "得意先掛率グループを選択してください。";
                    if (focusFlg == true)
                    {
                        this.CustRateGrpCode_tComboEditor.Focus();
                    }
                    return (false);
                }
            }

            // 仕入先コード
            if (RateAcs.IsSupplierSetting(rateSettingDivide))
            {
                if (this.tNedit_SupplierCd.GetInt() == 0)
                {
                    errMsg = "仕入先コードを入力してください。";
                    if (focusFlg == true)
                    {
                        this.tNedit_SupplierCd.Focus();
                    }
                    return (false);
                }
                if (saveFlg == true)
                {
                    // 保存前チェックのみ
                    int supplierCode = this.tNedit_SupplierCd.GetInt();
                    if (GetSupplierName(supplierCode) == "")
                    {
                        errMsg = "マスタに登録されていません。";
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
        /// 画面情報(商品設定)入力チェック処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="saveFlg">保存フラグ(True:保存前チェック  False:検索条件チェック)</param>
        /// <param name="focusFlg">フォーカス設定フラグ(True:設定する　False:設定しない)</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面情報(商品設定)の入力チェックを行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private bool CheckGoodsCondition(out string errMsg, bool saveFlg, bool focusFlg)
        {
            errMsg = "";

            // 掛率設定区分
            string rateSettingDivide = this.RateSettingDivide_tEdit.DataText.Trim();

            // メーカーコード
            if (RateAcs.IsMakerSetting(rateSettingDivide))
            {
                if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                {
                    errMsg = "メーカーコードを入力してください。";
                    if (focusFlg == true)
                    {
                        this.tNedit_GoodsMakerCd.Focus();
                    }
                    return (false);
                }
                if (saveFlg == true)
                {
                    // 保存前チェックのみ
                    int makerCode = this.tNedit_GoodsMakerCd.GetInt();
                    if (GetMakerName(makerCode) == "")
                    {
                        errMsg = "マスタに登録されていません。";
                        if (focusFlg == true)
                        {
                            this.tNedit_GoodsMakerCd.Focus();
                        }
                        return (false);
                    }
                }
            }

            // 層別
            if (RateAcs.IsGoodsRateRankSetting(rateSettingDivide))
            {
                if (this.GoodsRateRank_tEdit.DataText.Trim() == "")
                {
                    errMsg = "層別を入力してください。";
                    if (focusFlg == true)
                    {
                        this.GoodsRateRank_tEdit.Focus();
                    }
                    return (false);
                }
            }

            // 商品掛率Ｇ
            if (RateAcs.IsGoodsRateGrpCodeSetting(rateSettingDivide))
            {
                if (this.tNedit_GoodsMGroup.GetInt() == 0)
                {
                    errMsg = "商品掛率Ｇコードを入力してください。";
                    if (focusFlg == true)
                    {
                        this.tNedit_GoodsMGroup.Focus();
                    }
                    return (false);
                }
                if (saveFlg == true)
                {
                    // 保存前チェックのみ
                    int goodsRateGrpCode = this.tNedit_GoodsMGroup.GetInt();
                    if (GetGoodsMGroupName(goodsRateGrpCode) == "")
                    {
                        errMsg = "マスタに登録されていません。";
                        if (focusFlg == true)
                        {
                            this.tNedit_GoodsMGroup.Focus();
                        }
                        return (false);
                    }
                }
            }

            // BLグループコード
            if (RateAcs.IsBLGroupCodeSetting(rateSettingDivide))
            {
                if (this.tNedit_BLGloupCode.GetInt() == 0)
                {
                    errMsg = "ｸﾞﾙｰﾌﾟｺｰﾄﾞを入力してください。";
                    if (focusFlg == true)
                    {
                        this.tNedit_BLGloupCode.Focus();
                    }
                    return (false);
                }
                if (saveFlg == true)
                {
                    // 保存前チェックのみ
                    int blGroupCode = this.tNedit_BLGloupCode.GetInt();
                    if (GetBLGroupName(blGroupCode) == "")
                    {
                        errMsg = "マスタに登録されていません。";
                        if (focusFlg == true)
                        {
                            this.tNedit_BLGloupCode.Focus();
                        }
                        return (false);
                    }
                }
            }

            // BLコード
            if (RateAcs.IsBLGoodsSetting(rateSettingDivide))
            {
                if (this.tNedit_BLGoodsCode.GetInt() == 0)
                {
                    errMsg = "BLｺｰﾄﾞを入力してください。";
                    if (focusFlg == true)
                    {
                        this.tNedit_BLGoodsCode.Focus();
                    }
                    return (false);
                }
                if (saveFlg == true)
                {
                    // 保存前チェックのみ
                    int blGoodsCode = this.tNedit_BLGoodsCode.GetInt();
                    if (GetBLGoodsName(blGoodsCode) == "")
                    {
                        errMsg = "マスタに登録されていません。";
                        if (focusFlg == true)
                        {
                            this.tNedit_BLGoodsCode.Focus();
                        }
                        return (false);
                    }
                }
            }

            // 品番
            if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
            {
                if (this.tEdit_GoodsNo.DataText.Trim() == "")
                {
                    errMsg = "品番を入力してください。";
                    if (focusFlg == true)
                    {
                        this.tEdit_GoodsNo.Focus();
                    }
                    return (false);
                }
                if (saveFlg == true)
                {
                    // 保存前チェックのみ
                    GoodsUnitData goodsUnitData;
                    string goodsNoCode = this.tEdit_GoodsNo.DataText.Trim();
                    if (GetGoodsInfo(out goodsUnitData, goodsNoCode) != 0)
                    {
                        errMsg = "マスタに登録されていません。";
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
        /// 画面情報(グリッド)入力チェック処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 画面情報(グリッド)の入力チェックを行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private bool CheckDetail(out string errMsg)
        {
            errMsg = "";

            // 単価種類
            int unitPriceKindCode = int.Parse((string)this.UnitPriceKind_tComboEditor.Value);
            // 設定方法
            int unitPriceKindWay = (int)this.UnitPriceKindWay_tComboEditor.Value;
            // 数量(以上)
            double lotCountAbove;
            // 数量(以下)
            double lotCountBelow;

            bool checkFlg;

            for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
            {
                checkFlg = false;

                switch (unitPriceKindCode)
                {
                    // 売価設定
                    case 1:
                        if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTABOVE].Cells[columnIndex].Value == DBNull.Value) ||
                        ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTABOVE].Cells[columnIndex].Value == ""))
                        {
                            errMsg = "数量範囲項目に誤りがあります。\n再設定をお願いします。";
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
                            errMsg = "数量範囲項目に誤りがあります。\n再設定をお願いします。";
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTABOVE].Cells[columnIndex].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }

                        // 売価率
                        if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALERATEVAL].Cells[columnIndex].Text != "") &&
                            (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALERATEVAL].Cells[columnIndex].Text) != 0))
                        {
                            checkFlg = true;
                        }

                        // 売価額
                        if (unitPriceKindWay == 0)
                        {
                            // 単品設定のときのみチェック
                            if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALEPRICEFL].Cells[columnIndex].Text != "") &&
                                (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALEPRICEFL].Cells[columnIndex].Text) != 0))
                            {
                                checkFlg = true;
                            }
                        }

                        // 原価UP率
                        if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTUPRATE].Cells[columnIndex].Text != "") && 
                            (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTUPRATE].Cells[columnIndex].Text) != 0))
                        {
                            checkFlg = true;
                        }

                        // 粗利確保率
                        if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_GRSPROFITSECURERATE].Cells[columnIndex].Text != "") &&
                            (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_GRSPROFITSECURERATE].Cells[columnIndex].Text) != 0))
                        {
                            checkFlg = true;
                        }

                        if (checkFlg == false)
                        {
                            errMsg = "未入力の項目が存在するため、登録できません。\n売価設定";
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALERATEVAL].Cells[columnIndex].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        break;
                    // 原価設定
                    case 2:
                        // 原価設定は1レコードのみ登録可能
                        if (columnIndex > 0)
                        {
                            return (true);
                        }

                        // 仕入率
                        if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTRATEVAL].Cells[columnIndex].Text != "") &&
                            (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTRATEVAL].Cells[columnIndex].Text) != 0))
                        {
                            checkFlg = true;
                        }

                        // 仕入原価
                        if (unitPriceKindWay == 0)
                        {
                            // 単品設定のときのみチェック
                            if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTPRICEFL].Cells[columnIndex].Text != "") &&
                                (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTPRICEFL].Cells[columnIndex].Text) != 0))
                            {
                                checkFlg = true;
                            }
                        }

                        if (checkFlg == false)
                        {
                            errMsg = "未入力の項目が存在するため、登録できません。\n原価設定";
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTRATEVAL].Cells[columnIndex].Activate();
                            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                            return (false);
                        }
                        break;
                    // 価格設定
                    case 3:
                        // 価格設定は1レコードのみ登録可能
                        if (columnIndex > 0)
                        {
                            return (true);
                        }

                        // ユーザー定価
                        if (unitPriceKindWay == 0)
                        {
                            // 単品設定のときのみチェック
                            if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_USERPRICEFL].Cells[columnIndex].Text != "") &&
                                (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_USERPRICEFL].Cells[columnIndex].Text) != 0))
                            {
                                checkFlg = true;
                            }
                        }

                        // 価格UP率
                        if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_PRICEUPRATE].Cells[columnIndex].Text != "") &&
                            (double.Parse(this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_PRICEUPRATE].Cells[columnIndex].Text) != 0))
                        {
                            checkFlg = true;
                        }

                        if (checkFlg == false)
                        {
                            errMsg = "未入力の項目が存在するため、登録できません。\n価格設定";
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

                // 単価端数処理単位
                if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Value == DBNull.Value) ||
                    ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Value == "") ||
                    (double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Value) == 0))
                {
                    errMsg = "未入力の項目が存在するため、登録できません。\n単価端数処理単位";
                    this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Activate();
                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }

                // 単価端数処理区分
                if ((this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[columnIndex].Value == DBNull.Value) ||
                    (this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[columnIndex].Text == ""))
                {
                    errMsg = "未入力の項目が存在するため、登録できません。\n単価端数処理区分";
                    this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCDIV].Cells[columnIndex].Activate();
                    this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);
                    return (false);
                }
            }
            return (true);
        }

        /// <summary>
        /// 画面情報変更チェック処理
        /// </summary>
        /// <returns>ステータス(True:変更なし　False:変更あり)</returns>
        /// <remarks>
        /// <br>Note       : 画面情報が変更されているかどうかチェックします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private bool CompareInputScreen()
        {
            // 単価種類
            string unitPriceKind = (string)this.UnitPriceKind_tComboEditor.Value;

            // 保存件数取得処理
            int saveRecordCount = GetSaveRecordCount(unitPriceKind);

            if (saveRecordCount != this._rateListClone.Count)
            {
                return (false);
            }

            // 新規モードの場合
            if (saveRecordCount == 0)
            {
                Rate rate = new Rate();
                rate.EnterpriseCode = this._enterpriseCode;

                Rate compareRate = rate.Clone();

                // 画面情報取得(掛率設定)
                RateConditionToRate(ref compareRate);
                // 画面情報取得(取引先設定)
                CustomerConditionToRate(ref compareRate);
                // 画面情報取得(商品設定)
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

                // 画面情報取得
                ScreenToRate(ref rate, columnIndex);

                if (!(compareRate.Equals(rate)))
                {
                    return (false);
                }
            }

            return (true);
        }

        /// <summary>
        /// 掛率設定区分存在チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 掛率設定区分が存在するかどうかチェックします。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void CheckExistRateSettingDivide()
        {
            int status;
            RateProtyMng rateProtyMng = new RateProtyMng();

            // 掛率設定区分
            if (RateSettingDivide_tEdit.DataText.Trim() == "")
            {
                return;
            }
            string rateSettingDivCode = this.RateSettingDivide_tEdit.DataText.Trim();

            // 掛率マスタ取得
            status = GetRateProtyMng(out rateProtyMng, rateSettingDivCode);
            if (status == 0)
            {
                // 商品設定区分取得
                this.RateMngGoodsCd_tEdit.DataText = rateProtyMng.RateMngGoodsCd;
                this.RateMngGoodsNm_tEdit.DataText = rateProtyMng.RateMngGoodsNm.Trim();

                // 取引先設定区分取得
                this.RateMngCustCd_tEdit.DataText = rateProtyMng.RateMngCustCd;
                this.RateMngCustNm_tEdit.DataText = rateProtyMng.RateMngCustNm.Trim();

                // 優先順位
                this.tNedit_RatePriorityOrder.SetInt(rateProtyMng.RatePriorityOrder);

                // グリッド初期化
                ClearGrid(rateProtyMng.UnitPriceKind.ToString());
            }
            else
            {
                // 掛率設定区分初期化
                this.RateSettingDivide_tEdit.Clear();

                // 商品設定区分初期化
                this.RateMngGoodsCd_tEdit.Clear();
                this.RateMngGoodsNm_tEdit.Clear();

                // 取引先設定区分初期化
                this.RateMngCustCd_tEdit.Clear();
                this.RateMngCustNm_tEdit.Clear();

                // 優先順位初期化
                this.tNedit_RatePriorityOrder.Clear();

                // グリッド初期化
                ClearGrid("");
            }

            // 条件項目(取引先)クリア
            ClearCustomerCondition();

            // 条件項目(商品)クリア
            ClearGoodsCondition();

            // 条件コントロール(取引先)入力許可制御
            SetCustomerConditionEnabled();

            // 条件コントロール(商品)入力許可制御
            SetGoodsConditionEnabled();

            // グリッド入力許可制御
            SetGridEnabled();
        }

        #endregion チェック処理

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : 排他制御を行います。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            string errMsg = "";

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        errMsg = "既に他端末より更新されています。";
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        errMsg = "既に他端末より削除されています。";
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
        /// 保存件数取得処理
        /// </summary>
        /// <param name="unitPriceKind">単価種類</param>
        /// <returns>保存件数</returns>
        /// <remarks>
        /// <br>Note       : 保存件数を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private int GetSaveRecordCount(string unitPriceKind)
        {
            int saveRecordCount = 0;

            switch (unitPriceKind)
            {
                // 売価設定
                case "1":
                    for (int columnIndex = 0; columnIndex < COLUMN_COUNT; columnIndex++)
                    {
                        if ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTABOVE].Cells[columnIndex].Value == "" &&
                            (string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTBELOW].Cells[columnIndex].Value == "")
                        {
                            return saveRecordCount;
                        }

                        double lotCountAbove;   // 数量(以上)
                        double lotCountBelow;   // 数量(以下)

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
                // 原価設定、価格設定
                case "2":
                case "3":
                    saveRecordCount = 1;
                    break;
            }

            return saveRecordCount;
        }

        #region 画面情報取得処理

        /// <summary>
        /// 画面情報取得処理
        /// </summary>
        /// <param name="rate">掛率マスタオブジェクト</param>
        /// <param name="columnIndex">列インデックス</param>
        /// <remarks>
        /// <br>Note       : 画面情報を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void ScreenToRate(ref Rate rate, int columnIndex)
        {
            // 画面情報(掛率設定)取得
            RateConditionToRate(ref rate);

            // 画面情報(取引先設定)取得
            CustomerConditionToRate(ref rate);

            // 画面情報(商品設定)取得
            GoodsConditionToRate(ref rate);

            // 画面情報(グリッド)取得
            DetailToRate(ref rate, columnIndex);
        }

        /// <summary>
        /// 画面情報(掛率設定)取得処理
        /// </summary>
        /// <param name="rate">掛率マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報(掛率設定)を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void RateConditionToRate(ref Rate rate)
        {
            // 企業コード
            rate.EnterpriseCode = this._enterpriseCode;

            // 拠点コード
            rate.SectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();

            // 単価掛率設定区分(単価種類＋掛率設定区分)
            if (this.UnitPriceKind_tComboEditor.Value != null &&
                this.RateSettingDivide_tEdit.DataText != "")
            {
                rate.UnitRateSetDivCd = (string)this.UnitPriceKind_tComboEditor.Value + this.RateSettingDivide_tEdit.DataText;
            }

            // 単価種類
            rate.UnitPriceKind = (string)this.UnitPriceKind_tComboEditor.Value;

            // 掛率設定区分
            rate.RateSettingDivide = this.RateSettingDivide_tEdit.DataText;

            // 掛率設定区分（商品）
            rate.RateMngGoodsCd = this.RateMngGoodsCd_tEdit.DataText;

            // 掛率設定名称（商品）
            rate.RateMngGoodsNm = this.RateMngGoodsNm_tEdit.DataText;

            // 掛率設定区分（得意先）
            rate.RateMngCustCd = this.RateMngCustCd_tEdit.DataText;

            // 掛率設定名称（得意先）
            rate.RateMngCustNm = this.RateMngCustNm_tEdit.DataText;
        }

        /// <summary>
        /// 画面情報(取引先設定)取得処理
        /// </summary>
        /// <param name="rate">掛率マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報(取引先設定)を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void CustomerConditionToRate(ref Rate rate)
        {
            // 得意先コード
            rate.CustomerCode = this.tNedit_CustomerCode.GetInt();

            // 得意先掛率グループコード
            if (this.CustRateGrpCode_tComboEditor.Value != null)
            {
                rate.CustRateGrpCode = (int)this.CustRateGrpCode_tComboEditor.Value;
            }
            else
            {
                rate.CustRateGrpCode = 0;
            }

            // 仕入先コード
            rate.SupplierCd = this.tNedit_SupplierCd.GetInt();
        }

        /// <summary>
        /// 画面情報(商品設定)取得処理
        /// </summary>
        /// <param name="rate">掛率マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報(商品設定)を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void GoodsConditionToRate(ref Rate rate)
        {
            // 商品メーカーコード
            rate.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();

            // 層別
            rate.GoodsRateRank = this.GoodsRateRank_tEdit.DataText;

            // 商品掛率Ｇコード
            rate.GoodsRateGrpCode = this.tNedit_GoodsMGroup.GetInt();

            // BLグループコード
            rate.BLGroupCode = this.tNedit_BLGloupCode.GetInt();

            // BL商品コード
            rate.BLGoodsCode = this.tNedit_BLGoodsCode.GetInt();

            // 商品番号
            rate.GoodsNo = this.tEdit_GoodsNo.DataText;
        }

        /// <summary>
        /// 画面情報(グリッド)取得処理
        /// </summary>
        /// <param name="rate">掛率マスタオブジェクト</param>
        /// <param name="columnIndex">列インデックス</param>
        /// <remarks>
        /// <br>Note       : 画面情報(グリッド)を取得します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void DetailToRate(ref Rate rate, int columnIndex)
        {
            // ロット数
            rate.LotCount = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTBELOW].Cells[columnIndex].Text);

            switch ((string)this.UnitPriceKind_tComboEditor.Value)
            {
                // 売価設定
                case "1":
                    // 価格(浮動)
                    if ((int)this.UnitPriceKindWay_tComboEditor.Value == 0)
                    {
                        // 単品設定
                        if ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALEPRICEFL].Cells[columnIndex].Text == "")
                        {
                            rate.PriceFl = 0;
                        }
                        else
                        {
                            rate.PriceFl = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALEPRICEFL].Cells[columnIndex].Text);
                        }
                    }

                    // 掛率
                    if ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALERATEVAL].Cells[columnIndex].Text == "")
                    {
                        rate.RateVal = 0;
                    }
                    else
                    {
                        rate.RateVal = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALERATEVAL].Cells[columnIndex].Text);
                    }

                    // UP率
                    if ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTUPRATE].Cells[columnIndex].Text == "")
                    {

                    }
                    else
                    {
                        rate.UpRate = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTUPRATE].Cells[columnIndex].Text);
                    }

                    // 粗利確保率
                    if ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_GRSPROFITSECURERATE].Cells[columnIndex].Text == "")
                    {
                        rate.GrsProfitSecureRate = 0;
                    }
                    else
                    {
                        rate.GrsProfitSecureRate = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_GRSPROFITSECURERATE].Cells[columnIndex].Text);
                    }

                    break;
                // 原価設定
                case "2":
                    // 価格(浮動)
                    if ((int)this.UnitPriceKindWay_tComboEditor.Value == 0)
                    {
                        // 単品設定
                        if ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTPRICEFL].Cells[columnIndex].Text == "")
                        {
                            rate.PriceFl = 0;
                        }
                        else
                        {
                            rate.PriceFl = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTPRICEFL].Cells[columnIndex].Text);
                        }
                    }

                    // 掛率
                    if ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTRATEVAL].Cells[columnIndex].Text == "")
                    {
                        rate.RateVal = 0;
                    }
                    else
                    {
                        rate.RateVal = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTRATEVAL].Cells[columnIndex].Text);
                    }

                    break;
                // 価格設定
                case "3":
                    // 価格(浮動)
                    if ((int)this.UnitPriceKindWay_tComboEditor.Value == 0)
                    {
                        // 単品設定
                        if ((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_USERPRICEFL].Cells[columnIndex].Text == "")
                        {
                            rate.PriceFl = 0;
                        }
                        else
                        {
                            rate.PriceFl = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_USERPRICEFL].Cells[columnIndex].Text);
                        }
                    }

                    // UP率
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

            // 単価端数処理単位
            rate.UnPrcFracProcUnit = double.Parse((string)this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Text);

            // 単価端数処理区分
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

        #endregion 画面情報取得処理

        #region 画面展開処理

        /// <summary>
        /// 掛率マスタ画面展開処理
        /// </summary>
        /// <param name="rateList">掛率マスタリスト</param>
        /// <remarks>
        /// <br>Note       : 掛率マスタを画面に展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void RateToScreen(List<Rate> rateList)
        {
            // 画面展開(掛率設定)処理
            RateToRateCondition(rateList[0]);

            // 画面展開(取引先設定)処理
            RateToCustomerCondition(rateList[0]);

            // 画面展開(商品設定)処理
            RateToGoodsCondition(rateList[0]);

            // 画面展開(グリッド)処理
            RateToDetail(rateList);
        }

        /// <summary>
        /// 掛率マスタ画面展開(掛率設定)処理
        /// </summary>
        /// <param name="rate">掛率マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 掛率マスタを画面(掛率設定)に展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void RateToRateCondition(Rate rate)
        {
            // 拠点コード
            this.tEdit_SectionCodeAllowZero.DataText = rate.SectionCode.Trim();

            // 拠点名称
            this.SectionCodeNm_tEdit.DataText = GetSectionName(rate.SectionCode.Trim());

            // 単価種類
            this.UnitPriceKind_tComboEditor.Value = rate.UnitPriceKind;

            // 設定方法
            if (rate.RateMngGoodsCd.Trim() == "A")
            {
                // 単品設定
                this.UnitPriceKindWay_tComboEditor.Value = 0;
            }
            else
            {
                // グループ設定
                this.UnitPriceKindWay_tComboEditor.Value = 1;
            }

            // 掛率設定区分
            this.RateSettingDivide_tEdit.DataText = rate.RateSettingDivide;

            // 優先順位
            RateProtyMng rateProtyMng = new RateProtyMng();
            int status = GetRateProtyMng(out rateProtyMng, rate.RateSettingDivide);
            if (status == 0)
            {
                this.tNedit_RatePriorityOrder.SetInt(rateProtyMng.RatePriorityOrder);
            }

            // 商品設定区分
            this.RateMngGoodsCd_tEdit.DataText = rate.RateMngGoodsCd.Trim();

            // 商品設定区分名称
            this.RateMngGoodsNm_tEdit.DataText = rate.RateMngGoodsNm.Trim();

            // 取引先設定区分
            this.RateMngCustCd_tEdit.DataText = rate.RateMngCustCd.Trim();

            // 取引先設定区分名称
            this.RateMngCustNm_tEdit.DataText = rate.RateMngCustNm.Trim();
        }

        /// <summary>
        /// 掛率マスタ画面展開(取引先設定)処理
        /// </summary>
        /// <param name="rate">掛率マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 掛率マスタを画面(取引先設定)に展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void RateToCustomerCondition(Rate rate)
        {
            if (rate.CustomerCode == 0)
            {
                // 得意先コード
                this.tNedit_CustomerCode.DataText = "";

                // 得意先名称
                this.CustomerCodeNm_tEdit.DataText = "";
            }
            else
            {
                // 得意先コード
                this.tNedit_CustomerCode.SetInt(rate.CustomerCode);

                // 得意先名称
                this.CustomerCodeNm_tEdit.DataText = GetCustomerName(rate.CustomerCode);
            }

            // 得意先掛率グループ
            this.CustRateGrpCode_tComboEditor.Value = rate.CustRateGrpCode;

            if (rate.SupplierCd == 0)
            {
                // 仕入先コード
                this.tNedit_SupplierCd.DataText = "";

                // 仕入先名称
                this.SupplierCdNm_tEdit.DataText = "";
            }
            else
            {
                // 仕入先コード
                this.tNedit_SupplierCd.SetInt(rate.SupplierCd);

                // 仕入先名称
                this.SupplierCdNm_tEdit.DataText = GetSupplierName(rate.SupplierCd);
            }
        }

        /// <summary>
        /// 掛率マスタ画面展開(商品設定)処理
        /// </summary>
        /// <param name="rate">掛率マスタオブジェクト</param>
        /// <remarks>
        /// <br>Note       : 掛率マスタを画面(商品設定)に展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void RateToGoodsCondition(Rate rate)
        {
            if (rate.GoodsMakerCd == 0)
            {
                // メーカーコード
                this.tNedit_GoodsMakerCd.DataText = "";

                // メーカー名称
                this.MakerName_tEdit.DataText = "";
            }
            else
            {
                // メーカーコード
                this.tNedit_GoodsMakerCd.SetInt(rate.GoodsMakerCd);

                // メーカー名称
                this.MakerName_tEdit.DataText = GetMakerName(rate.GoodsMakerCd);
            }

            // 層別
            this.GoodsRateRank_tEdit.DataText = rate.GoodsRateRank.Trim();

            if (rate.GoodsRateGrpCode == 0)
            {
                // 商品掛率Ｇコード
                this.tNedit_GoodsMGroup.DataText = "";

                // 商品掛率Ｇ名称
                this.GoodsRateGrpName_tEdit.DataText = "";
            }
            else
            {
                // 商品掛率Ｇコード
                this.tNedit_GoodsMGroup.SetInt(rate.GoodsRateGrpCode);

                // 商品掛率Ｇ名称
                this.GoodsRateGrpName_tEdit.DataText = GetGoodsMGroupName(rate.GoodsRateGrpCode);
            }

            if (rate.BLGroupCode == 0)
            {
                // BLグループコード
                this.tNedit_BLGloupCode.DataText = "";

                // BLグループ名称
                this.BLGroupName_tEdit.DataText = "";
            }
            else
            {
                // BLグループコード
                this.tNedit_BLGloupCode.SetInt(rate.BLGroupCode);

                // BLグループ名称
                this.BLGroupName_tEdit.DataText = GetBLGroupName(rate.BLGroupCode);
            }

            if (rate.BLGoodsCode == 0)
            {
                // BLコード
                this.tNedit_BLGoodsCode.DataText = "";

                // BLコード名称
                this.BLGoodsName_tEdit.DataText = "";
            }
            else
            {
                // BLコード
                this.tNedit_BLGoodsCode.SetInt(rate.BLGoodsCode);

                // BLコード名称
                this.BLGoodsName_tEdit.DataText = GetBLGoodsName(rate.BLGoodsCode);
            }

            if (rate.GoodsNo.Trim() == "")
            {
                // 品番
                this.tEdit_GoodsNo.DataText = "";

                // 品番名称
                this.tEdit_GoodsName.DataText = "";
            }
            else
            {
                // 品番
                this.tEdit_GoodsNo.DataText = rate.GoodsNo.Trim();

                // 品番名称
                GoodsUnitData goodsUnitData;
                int status = GetGoodsInfo(out goodsUnitData, rate.GoodsNo);
                if (status == 0)
                {
                    this.tEdit_GoodsName.DataText = goodsUnitData.GoodsNameKana.Trim();

                    // 定価
                    this.tNedit_Price.SetValue(GetPrice(goodsUnitData.GoodsPriceList));
                }
                else
                {
                    this.tEdit_GoodsName.Clear();
                }
            }
        }

        /// <summary>
        /// 掛率マスタ画面展開(グリッド)処理
        /// </summary>
        /// <param name="rateList">掛率マスタリスト</param>
        /// <remarks>
        /// <br>Note       : 掛率マスタを画面(グリッド)に展開します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
        /// <br>Date       : 2008/06/18</br>
        /// </remarks>
        private void RateToDetail(List<Rate> rateList)
        {
            for (int columnIndex = 0; columnIndex < rateList.Count; columnIndex++)
            {
                // 単価種類
                string unitPriceKindCode = rateList[columnIndex].UnitPriceKind;
                // 掛率設定区分
                string rateSettingDivide = rateList[columnIndex].RateSettingDivide;
                
                switch (unitPriceKindCode)
                {
                    // 売価設定
                    case "1":

                        // 数量(以上)
                        if (columnIndex == 0)
                        {
                            // 数量(以上)1は固定
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTABOVE].Cells[columnIndex].Value = LOTCOUNT_MIN;
                        }
                        else
                        {
                            // 数量(以上)2～10
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTABOVE].Cells[columnIndex].Value = (rateList[columnIndex - 1].LotCount + 0.01).ToString(FORMAT_DECIMAL);
                        }

                        // 数量(以下)
                        this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_LOTCOUNTBELOW].Cells[columnIndex].Value = rateList[columnIndex].LotCount.ToString(FORMAT_DECIMAL);

                        // 売価率
                        if (rateList[columnIndex].RateVal != 0)
                        {
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALERATEVAL].Cells[columnIndex].Value = rateList[columnIndex].RateVal.ToString(FORMAT_DECIMAL);
                        }

                        // 売価額
                        if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                        {
                            // 単品設定のときのみ設定
                            if (rateList[columnIndex].PriceFl != 0)
                            {
                                this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_SALEPRICEFL].Cells[columnIndex].Value = rateList[columnIndex].PriceFl.ToString(FORMAT_DECIMAL);
                            }
                        }

                        // 原価UP率
                        if (rateList[columnIndex].UpRate != 0)
                        {
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTUPRATE].Cells[columnIndex].Value = rateList[columnIndex].UpRate.ToString(FORMAT_DECIMAL);
                        }

                        // 粗利確保率
                        if (rateList[columnIndex].GrsProfitSecureRate != 0)
                        {
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_GRSPROFITSECURERATE].Cells[columnIndex].Value = rateList[columnIndex].GrsProfitSecureRate.ToString(FORMAT_DECIMAL);
                        }

                        break;
                    // 原価設定
                    case "2":

                        // 仕入率
                        if (rateList[columnIndex].RateVal != 0)
                        {
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTRATEVAL].Cells[columnIndex].Value = rateList[columnIndex].RateVal.ToString(FORMAT_DECIMAL);
                        }

                        // 仕入原価
                        if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                        {
                            // 単品設定のときのみ設定
                            if (rateList[columnIndex].PriceFl != 0)
                            {
                                this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_COSTPRICEFL].Cells[columnIndex].Value = rateList[columnIndex].PriceFl.ToString(FORMAT_DECIMAL);
                            }
                        }

                        break;
                    // 価格設定
                    case "3":

                        // 価格UP率
                        if (rateList[columnIndex].UpRate != 0)
                        {
                            this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_PRICEUPRATE].Cells[columnIndex].Value = rateList[columnIndex].UpRate.ToString(FORMAT_DECIMAL);
                        }

                        // ユーザー定価
                        if (RateAcs.IsGoodsNoSetting(rateSettingDivide))
                        {
                            // 単品設定のときのみ設定
                            if (rateList[columnIndex].PriceFl != 0)
                            {
                                this.Detail_uGrid.Rows[ROWINDEX_USERPRICEFL].Cells[columnIndex].Value = rateList[columnIndex].PriceFl.ToString(FORMAT_NUM);
                            }
                        }

                        break;
                }

                // 単価端数処理単位
                this.Detail_uGrid.DisplayLayout.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Value = rateList[columnIndex].UnPrcFracProcUnit.ToString(FORMAT_DECIMAL);

                // 単価端数処理区分
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

        #endregion 画面展開処理

        #region 文字列編集処理

        /// <summary>
        /// カンマ・ピリオド削除処理
        /// </summary>
        /// <param name="targetText">カンマ・ピリオド削除前テキスト</param>
        /// <param name="retText">カンマ・ピリオド削除済みテキスト</param>
        /// <param name="periodDelFlg">ピリオド削除フラグ(True:カンマ・ピリオド削除  False:カンマ削除)</param>
        /// <remarks>
        /// <br>Note		: 対象のテキストからカンマ・ピリオドを削除します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void RemoveCommaPeriod(string targetText, out string retText, bool periodDelFlg)
        {
            retText = "";

            // セル値編集用にカンマ・ピリオド削除
            for (int i = targetText.Length - 1; i >= 0; i--)
            {
                // カンマ・ピリオド削除
                if (periodDelFlg == true)
                {
                    if ((targetText[i].ToString() == ",") || (targetText[i].ToString() == "."))
                    {
                        targetText = targetText.Remove(i, 1);
                    }
                }
                // カンマのみ削除
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
        /// 小数点取得処理
        /// </summary>
        /// <param name="targetText">チェック対象テキスト</param>
        /// <param name="retText">小数部分テキスト</param>
        /// <remarks>
        /// <br>Note		: 対象のテキストから小数部分のみを返します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
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

        #endregion 文字列編集処理

        #endregion Private Methods

        #region Control Events
        /// <summary>
        /// フォームロードイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note		: フォームが読み込まれた時に発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void DCKHN09160UA_Load(object sender, EventArgs e)
        {
            // アイコン設定
            SetIcon();

            // コントロールサイズ設定
            SetControlSize();

            // 画面クリア
            ScreenClear();

            // 画面入力許可制御
            ScreenInputPermissionControl(INSERT_MODE);

            // フォーカス設定
            this.tEdit_SectionCodeAllowZero.Focus();

            this._firstFlg = true;
        }

        /// <summary>
        /// ツールバークリックイベント
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: ツールバー上のツールがクリックされた時に発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void Main_ToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
        {
            bool bStatus;

            switch (e.Tool.Key)
            {
                // 終了ボタン
                case "Exit_ButtonTool":
                    {
                        // 変更点チェック
                        if (!CompareInputScreen())
                        {
                            //画面情報が変更されていた場合は、保存確認メッセージを表示する
                            DialogResult res = ShowMessageBox(emErrorLevel.ERR_LEVEL_SAVECONFIRM,
                                                              "",
                                                              0,
                                                              MessageBoxButtons.YesNoCancel,
                                                              MessageBoxDefaultButton.Button1);
                            switch (res)
                            {
                                case DialogResult.Yes:
                                    {
                                        // 保存処理
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
                // 新規ボタン
                case "New_ButtonTool":
                    {
                        // 変更点チェック
                        if (!CompareInputScreen())
                        {
                            //画面情報が変更されていた場合は、保存確認メッセージを表示する
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

                        // 新規作成処理
                        bStatus = NewProc();
                        return;
                    }
                // 保存ボタン
                case "Save_ButtonTool":
                    {
                        // 一時的にフォーカスを移動します
                        this.SectionCode_uLabel.Focus();

                        // 保存処理
                        bStatus = SaveProc();
                        return;
                    }
                // 削除ボタン
                case "Delete_ButtonTool":
                    {
                        if (this.Mode_Label.Text == DELETE_MODE)
                        {
                            // 物理削除処理
                            bStatus = DeleteProc();
                        }
                        else
                        {
                            // 論理削除処理
                            bStatus = LogicalDeleteProc();
                        }
                        return;
                    }
                // 復活ボタン
                case "Revival_ButtonTool":
                    {
                        // 復活処理
                        bStatus = RevivalProc();
                        return;
                    }
            }
        }

        #region ガイド処理

        /// <summary>
        /// Button_Click イベント(SectionGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 拠点ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void SectionGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                SecInfoSet secInfoSet = new SecInfoSet();

                // 拠点ガイド表示
                status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
                if (status == 0)
                {
                    if (secInfoSet.SectionCode.Trim() != this._prevSectionCode)
                    {
                        this._prevSectionCode = secInfoSet.SectionCode.Trim();

                        // 拠点コード
                        this.tEdit_SectionCodeAllowZero.DataText = secInfoSet.SectionCode.Trim();

                        // 拠点名称
                        this.SectionCodeNm_tEdit.DataText = secInfoSet.SectionGuideNm.Trim();

                        // 掛率設定区分存在チェック
                        CheckExistRateSettingDivide();
                    }

                    // フォーカス設定
                    SetFocus(this.SectionGuide_Button);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(RateSettingDivideGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 掛率設定区分ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void RateSettingDivideGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                RateProtyMng rateProtyMng = new RateProtyMng();

                // 拠点コード
                string sectionCode = this.tEdit_SectionCodeAllowZero.DataText;
                // 単価種類
                int unitPriceKind = int.Parse((string)this.UnitPriceKind_tComboEditor.Value);
                // 設定方法
                int unitPriceKindWay = (int)this.UnitPriceKindWay_tComboEditor.Value;

                // 掛率設定区分ガイド表示
                status = this._rateProtyMngAcs.ExecuteGuid(this._enterpriseCode, sectionCode, unitPriceKind,
                                                           unitPriceKindWay, out rateProtyMng);
                if (status == 0)
                {
                    if (rateProtyMng.RateSettingDivide.Trim() != this._prevRateSettingDivide)
                    {
                        this._prevRateSettingDivide = rateProtyMng.RateSettingDivide;

                        // 掛率設定区分
                        this.RateSettingDivide_tEdit.DataText = rateProtyMng.RateSettingDivide;

                        // 商品設定区分
                        this.RateMngGoodsCd_tEdit.DataText = rateProtyMng.RateMngGoodsCd;

                        // 商品設定区分名称
                        this.RateMngGoodsNm_tEdit.DataText = rateProtyMng.RateMngGoodsNm.Trim();

                        // 取引先設定区分
                        this.RateMngCustCd_tEdit.DataText = rateProtyMng.RateMngCustCd;

                        // 取引先設定区分名称
                        this.RateMngCustNm_tEdit.DataText = rateProtyMng.RateMngCustNm.Trim();

                        // 優先順位
                        this.tNedit_RatePriorityOrder.SetInt(rateProtyMng.RatePriorityOrder);

                        // 条件項目(取引先)クリア
                        ClearCustomerCondition();

                        // 条件項目(商品)クリア
                        ClearGoodsCondition();

                        // 条件コントロール(取引先)入力許可制御
                        SetCustomerConditionEnabled();

                        // 条件コントロール(商品)入力許可制御
                        SetGoodsConditionEnabled();

                        // グリッド初期化
                        ClearGrid(unitPriceKind.ToString());

                        // グリッド入力許可制御
                        SetGridEnabled();
                    }

                    // フォーカス設定
                    SetFocus(this.RateSettingDivideGuide_Button);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(CustomerGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 得意先ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void CustomerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                this._cusotmerGuideSelected = false;

                // 得意先ガイド
                PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);

                customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
                customerSearchForm.ShowDialog(this);

                // フォーカス設定
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
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : 得意先選択時に発生します。</br>
        /// <br>Programmer : 30414 忍　幸史</br>
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

                // 得意先コード
                this.tNedit_CustomerCode.SetInt(customerSearchRet.CustomerCode);

                // 得意先名称
                this.CustomerCodeNm_tEdit.DataText = customerSearchRet.Snm.Trim();
            }

            this._cusotmerGuideSelected = true;
        }

        /// <summary>
        /// Button_Click イベント(SupplierGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 仕入先ガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void SupplierGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                Supplier supplier = new Supplier();

                // 拠点コード
                string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim();

                // 仕入先ガイド表示
                status = this._supplierAcs.ExecuteGuid(out supplier, this._enterpriseCode, sectionCode);
                if (status == 0)
                {
                    if (supplier.SupplierCd != this._prevSupplierCode)
                    {
                        this._prevSupplierCode = supplier.SupplierCd;

                        // 仕入先コード
                        this.tNedit_SupplierCd.SetInt(supplier.SupplierCd);

                        // 仕入先名称
                        this.SupplierCdNm_tEdit.DataText = supplier.SupplierSnm.Trim();
                    }

                    // フォーカス設定
                    SetFocus(this.SupplierGuide_Button);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(MakerGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: メーカーガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void MakerGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                MakerUMnt makerUMnt = new MakerUMnt();

                // メーカーガイド表示
                status = this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
                if (status == 0)
                {
                    if (makerUMnt.GoodsMakerCd != this._prevMakerCode)
                    {
                        this._prevMakerCode = makerUMnt.GoodsMakerCd;

                        // メーカーコード
                        this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);

                        // メーカー名称
                        this.MakerName_tEdit.DataText = makerUMnt.MakerName.Trim();

                        // 商品コード取得
                        string goodsCode = this.tEdit_GoodsNo.DataText.Trim();

                        if (goodsCode != "")
                        {
                            GoodsUnitData goodsUnitData;

                            status = GetGoodsInfo(out goodsUnitData, goodsCode);
                            if (status == 0)
                            {
                                // 商品名称
                                this.tEdit_GoodsName.DataText = goodsUnitData.GoodsNameKana.Trim();

                                // 定価
                                List<GoodsPrice> goodsPriceList = goodsUnitData.GoodsPriceList;
                                this.tNedit_Price.SetValue(GetPrice(goodsPriceList));
                            }
                            else
                            {
                                // 商品名称
                                this.tEdit_GoodsName.Clear();

                                // 定価
                                this.tNedit_Price.Clear();
                            }
                        }
                    }

                    // フォーカス設定
                    SetFocus(this.MakerGuide_Button);
                }

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(GoodsRateGrpGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 商品掛率Ｇガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void GoodsRateGrpGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                GoodsGroupU goodsGroupU = new GoodsGroupU();

                // 商品掛率Ｇガイド表示
                status = this._goodsGroupUAcs.ExecuteGuid(this._enterpriseCode, out goodsGroupU, false);
                if (status == 0)
                {
                    if (goodsGroupU.GoodsMGroup != this._prevGoodsRateGrpCode)
                    {
                        this._prevGoodsRateGrpCode = goodsGroupU.GoodsMGroup;

                        // 商品掛率Ｇコード
                        this.tNedit_GoodsMGroup.SetInt(goodsGroupU.GoodsMGroup);

                        // 商品掛率Ｇ名称
                        this.GoodsRateGrpName_tEdit.DataText = goodsGroupU.GoodsMGroupName.Trim();
                    }

                    // フォーカス設定
                    SetFocus(this.GoodsRateGrpGuide_Button);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(BLGroupGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: BLグループガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void BLGroupGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGroupU blGroupU = new BLGroupU();

                // BLグループガイド表示
                status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupU);
                if (status == 0)
                {
                    if (blGroupU.BLGroupCode != this._prevBLGroupCode)
                    {
                        this._prevBLGroupCode = blGroupU.BLGroupCode;

                        // BLグループコード
                        this.tNedit_BLGloupCode.SetInt(blGroupU.BLGroupCode);

                        // BLグループ名称
                        this.BLGroupName_tEdit.DataText = blGroupU.BLGroupName.Trim();
                    }

                    // フォーカス設定
                    SetFocus(this.BLGroupGuide_Button);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Button_Click イベント(BLGoodsGuide_Button)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: BLコードガイドボタンがクリックされた時に発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void BLGoodsGuide_Button_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int status;
                BLGoodsCdUMnt blGoodsCdUMnt = new BLGoodsCdUMnt();

                // BLコードガイド表示
                status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
                if (status == 0)
                {
                    if (blGoodsCdUMnt.BLGoodsCode != this._prevBLGoodsCode)
                    {
                        this._prevBLGoodsCode = blGoodsCdUMnt.BLGoodsCode;

                        // BLコード
                        this.tNedit_BLGoodsCode.SetInt(blGoodsCdUMnt.BLGoodsCode);

                        // BLコード名称
                        this.BLGoodsName_tEdit.DataText = blGoodsCdUMnt.BLGoodsHalfName.Trim();
                    }

                    // フォーカス設定
                    SetFocus(this.BLGoodsGuide_Button);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion ガイド処理

        /// <summary>
        /// ValueChanged イベント(UnitPriceKind_tComboEditor)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 単価種類の値が変更されたときに発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void UnitPriceKind_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // 削除モードの場合
            if (this.Mode_Label.Text == DELETE_MODE)
            {
                return;
            }

            if (this.UnitPriceKind_tComboEditor.Value == null)
            {
                this._prevUnitPriceKind = "";
                return;
            }

            // 単価種類取得
            string unitPriceKind = (string)this.UnitPriceKind_tComboEditor.Value;

            if (unitPriceKind == this._prevUnitPriceKind)
            {
                return;
            }

            // 掛率設定区分存在チェック
            CheckExistRateSettingDivide();

            this._prevUnitPriceKind = unitPriceKind;
        }

        /// <summary>
        /// ValueChanged イベント(UnitPriceKindWay_tComboEditor)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 設定方法の値が変更されたときに発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void UnitPriceKindWay_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // 削除モードの場合
            if (this.Mode_Label.Text == DELETE_MODE)
            {
                return;
            }

            if (this.UnitPriceKindWay_tComboEditor.Value == null)
            {
                this._prevUnitPriceKindWay = -1;
                return;
            }

            // 設定方法取得
            int unitPriceKindWay = (int)this.UnitPriceKindWay_tComboEditor.Value;

            if (unitPriceKindWay == this._prevUnitPriceKindWay)
            {
                return;
            }

            // 掛率設定区分存在チェック
            CheckExistRateSettingDivide();

            this._prevUnitPriceKindWay = unitPriceKindWay;
        }

        #region グリッド処理

        /// <summary>
        /// AfterExitEditMode イベント(Detail_uGrid)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 編集モードが終了したときに発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
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

            // 単価端数処理区分の場合
            if (rowIndex == ROWINDEX_UNPRCFRACPROCDIV)
            {
                return;
            }

            string retText;
            string targetText = (string)this.Detail_uGrid.ActiveCell.Value;

            // カンマのみ削除
            RemoveCommaPeriod(targetText, out retText, false);

            double targetValue = double.Parse(retText);

            // ユーザー定価の場合
            if (rowIndex == ROWINDEX_USERPRICEFL)
            {
                this.Detail_uGrid.ActiveCell.Value = targetValue.ToString(FORMAT_NUM);
            }
            else
            {
                this.Detail_uGrid.ActiveCell.Value = targetValue.ToString(FORMAT_DECIMAL);
            }

            // 数量(以上)の場合
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
        /// AfterEnterEditMode イベント(Detail_uGrid)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 編集モードが開始したときに発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void Detail_uGrid_AfterEnterEditMode(object sender, EventArgs e)
        {
            int rowIndex = this.Detail_uGrid.ActiveCell.Row.Index;

            // 単価端数処理区分の場合
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

            // カンマのみ削除
            RemoveCommaPeriod(targetText, out retText, false);

            this.Detail_uGrid.ActiveCell.Value = retText;
            this.Detail_uGrid.ActiveCell.SelStart = 0;
            this.Detail_uGrid.ActiveCell.SelLength = retText.Length;
        }

        /// <summary>
        /// CellChange イベント(Detail_uGrid)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: セルの値が変更されたときに発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
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

            // セルの値を取得
            string targetText = e.Cell.Text.Trim();

            if (targetText == "")
            {
                return;
            }

            // セル入力許可変更
            ChangeCellEnabled(columnIndex);

            // 単価端数処理単位
            if (this.Detail_uGrid.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Text == "")
            {
                this.Detail_uGrid.Rows[ROWINDEX_UNPRCFRACPROCUNIT].Cells[columnIndex].Value = "1.00";
            }
            // 単価端数処理区分
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
        /// KeyDown イベント(Detail_uGrid)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: キーが押されたときに発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
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

            // グリッド内のカーソル移動を設定します
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
                        // 単価端数処理区分
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
                            // アクティブセルを1つ上に移動します
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
                            // アクティブセルを1つ下に移動します
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
                            // アクティブセルを1つ左に移動します
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
                            // アクティブセルを1つ右に移動します
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
        /// KeyPress イベント(Detail_uGrid)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: キーが押されたときに発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
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

            // 単価端数処理区分の場合
            if (rowIndex == ROWINDEX_UNPRCFRACPROCDIV)
            {
                return;
            }

            // 「Backspace」キーを押された時
            if ((byte)e.KeyChar == (byte)'\b')
            {
                return;
            }

            // 対象セルのテキスト取得
            string retText;
            string targetText = this.Detail_uGrid.ActiveCell.Text;
            this.Detail_uGrid.PerformAction(UltraGridAction.EnterEditMode);

            // 各行の入力可能桁数を設定します
            switch (rowIndex)
            {
                // 数量(以上)、数量(以下)、単価端数処理単位
                // 7V2
                case ROWINDEX_LOTCOUNTABOVE:
                case 1:
                case ROWINDEX_UNPRCFRACPROCUNIT:
                    // セルのテキストが選択されている場合
                    if (this.Detail_uGrid.ActiveCell.SelText == targetText)
                    {
                        // 数値のみ入力可
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // カンマ、ピリオド削除
                        RemoveCommaPeriod(targetText, out retText, true);

                        // 文字数が9文字だったら入力不可
                        if (retText.Length == 9)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // 数値以外の時
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // 入力値の1文字目は「,」「.」不可
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

                                    // カンマ、ピリオド削除
                                    RemoveCommaPeriod(targetText, out retText, true);

                                    if (retText.Length == 7)
                                    {
                                        if ((byte)e.KeyChar != '.')
                                        {
                                            e.KeyChar = '\0';
                                        }
                                    }

                                    // 「,」「.」は入力可
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
                                    // 小数点取得
                                    GetDecimal(targetText, out retText);

                                    if (retText.Length == 2)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                                else
                                {
                                    // カンマ、ピリオド削除
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

                // 売価率、原価UP率、粗利確保率、仕入率、価格UP率
                // 3V2
                case ROWINDEX_SALERATEVAL:
                case ROWINDEX_COSTUPRATE:
                case ROWINDEX_GRSPROFITSECURERATE:
                case ROWINDEX_COSTRATEVAL:
                case ROWINDEX_PRICEUPRATE:
                    // セルのテキストが選択されている場合
                    if (this.Detail_uGrid.ActiveCell.SelText == targetText)
                    {
                        // 数値のみ入力可
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // カンマ、ピリオド削除
                        RemoveCommaPeriod(targetText, out retText, true);

                        // 文字数が5文字だったら入力不可
                        if (retText.Length == 5)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // 数値以外の時
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // 入力値の1文字目は「,」「.」不可
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

                                    // カンマ、ピリオド削除
                                    RemoveCommaPeriod(targetText, out retText, true);

                                    if (retText.Length == 3)
                                    {
                                        if ((byte)e.KeyChar != '.')
                                        {
                                            e.KeyChar = '\0';
                                        }
                                    }

                                    // 「,」「.」は入力可
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
                                    // 小数点取得
                                    GetDecimal(targetText, out retText);

                                    if (retText.Length == 2)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                                else
                                {
                                    // カンマ、ピリオド削除
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

                // 売価額、仕入原価
                // 9V2
                case ROWINDEX_SALEPRICEFL:
                case ROWINDEX_COSTPRICEFL:
                    // セルのテキストが選択されている場合
                    if (this.Detail_uGrid.ActiveCell.SelText == targetText)
                    {
                        // 数値のみ入力可
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // カンマ、ピリオド削除
                        RemoveCommaPeriod(targetText, out retText, true);

                        // 文字数が11文字だったら入力不可
                        if (retText.Length == 11)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // 数値以外の時
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // 入力値の1文字目は「,」「.」不可
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

                                    // カンマ、ピリオド削除
                                    RemoveCommaPeriod(targetText, out retText, true);

                                    if (retText.Length == 9)
                                    {
                                        if ((byte)e.KeyChar != '.')
                                        {
                                            e.KeyChar = '\0';
                                        }
                                    }

                                    // 「,」「.」は入力可
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
                                    // 小数点取得
                                    GetDecimal(targetText, out retText);

                                    if (retText.Length == 2)
                                    {
                                        e.KeyChar = '\0';
                                    }
                                }
                                else
                                {
                                    // カンマ、ピリオド削除
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

                // ユーザー定価
                // 9
                case ROWINDEX_USERPRICEFL:
                    // セルのテキストが選択されている場合
                    if (this.Detail_uGrid.ActiveCell.SelText == targetText)
                    {
                        // 数値のみ入力可
                        if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                        {
                            e.KeyChar = '\0';
                        }
                    }
                    else
                    {
                        // カンマ、ピリオド削除
                        RemoveCommaPeriod(targetText, out retText, true);

                        // 文字数が9文字だったら入力不可
                        if (retText.Length == 9)
                        {
                            e.KeyChar = '\0';
                        }
                        else
                        {
                            // 数値以外の時
                            if ((byte)e.KeyChar < (byte)'0' || (byte)'9' < (byte)e.KeyChar)
                            {
                                // 入力値の1文字目は「,」不可
                                if (targetText == "")
                                {
                                    e.KeyChar = '\0';
                                }
                                else
                                {
                                    // 「,」は入力可
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

        #endregion グリッド処理

        /// <summary>
        /// ChangeFocus イベント(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">イベントオブジェクト</param>
        /// <param name="e">イベント情報</param>
        /// <remarks>
        /// <br>Note		: 各コントロールからフォーカスが離れたときに発生します。</br>
        /// <br>Programmer	: 30414　忍　幸史</br>
        /// <br>Date		: 2008/06/18</br>
        /// </remarks>
        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // グリッド
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
            // 拠点コード
            else if (e.PrevCtrl == this.tEdit_SectionCodeAllowZero)
            {
                // 拠点コード取得
                string sectionCode = this.tEdit_SectionCodeAllowZero.DataText.Trim().PadLeft(2, '0');

                // 拠点名称取得
                this.SectionCodeNm_tEdit.DataText = GetSectionName(sectionCode);

                if (this.SectionCodeNm_tEdit.DataText.Trim() == "")
                {
                    // 商品設定区分初期化
                    this.RateMngGoodsCd_tEdit.Clear();
                    this.RateMngGoodsNm_tEdit.Clear();

                    // 取引先設定区分初期化
                    this.RateMngCustCd_tEdit.Clear();
                    this.RateMngCustNm_tEdit.Clear();

                    // 優先順位初期化
                    this.tNedit_RatePriorityOrder.Clear();

                    // グリッド初期化
                    ClearGrid("");

                    // 条件項目(取引先)クリア
                    ClearCustomerCondition();

                    // 条件項目(商品)クリア
                    ClearGoodsCondition();

                    // 条件コントロール(取引先)入力許可制御
                    SetCustomerConditionEnabled();

                    // 条件コントロール(商品)入力許可制御
                    SetGoodsConditionEnabled();

                    // グリッド入力許可制御
                    SetGridEnabled();
                }
                else
                {
                    if (sectionCode != this._prevSectionCode)
                    {
                        // 掛率設定区分存在チェック
                        CheckExistRateSettingDivide();
                    }

                    SearchAfterLeaveControl();

                    if (e.ShiftKey == false)
                    {
                        if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                        {
                            // フォーカス設定
                            e.NextCtrl = this.UnitPriceKind_tComboEditor;
                        }
                    }
                }

                this._prevSectionCode = sectionCode;
            }
            // 掛率設定区分
            else if (e.PrevCtrl == this.RateSettingDivide_tEdit)
            {
                if (this.RateSettingDivide_tEdit.DataText == "")
                {
                    this.RateMngGoodsCd_tEdit.Clear();
                    this.RateMngGoodsNm_tEdit.Clear();
                    this.RateMngCustCd_tEdit.Clear();
                    this.RateMngCustNm_tEdit.Clear();
                    this._prevRateSettingDivide = "";

                    // 条件コントロール(取引先)入力許可制御
                    SetCustomerConditionEnabled();

                    // 条件コントロール(商品)入力許可制御
                    SetGoodsConditionEnabled();

                    return;
                }

                // 掛率設定区分
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

                // 掛率設定区分存在チェック
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
            // 得意先コード
            else if (e.PrevCtrl == this.tNedit_CustomerCode)
            {
                if (this.tNedit_CustomerCode.GetInt() == 0)
                {
                    this.CustomerCodeNm_tEdit.Clear();
                    return;
                }

                // 得意先コード取得
                int customerCode = this.tNedit_CustomerCode.GetInt();

                // 得意先名称取得
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
            // 仕入先コード
            else if (e.PrevCtrl == this.tNedit_SupplierCd)
            {
                if (this.tNedit_SupplierCd.GetInt() == 0)
                {
                    this.SupplierCdNm_tEdit.Clear();
                    return;
                }

                // 仕入先コード取得
                int supplierCode = this.tNedit_SupplierCd.GetInt();

                // 仕入先名称取得
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
            // メーカーコード
            else if (e.PrevCtrl == this.tNedit_GoodsMakerCd)
            {
                if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                {
                    this.MakerName_tEdit.Clear();
                    this.tEdit_GoodsName.Clear();
                    return;
                }

                // メーカーコード取得
                int makerCode = this.tNedit_GoodsMakerCd.GetInt();

                // メーカー名称取得
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

                // 商品コード取得
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
                    // 商品名称
                    this.tEdit_GoodsName.DataText = goodsUnitData.GoodsNameKana.Trim();

                    // 定価
                    List<GoodsPrice> goodsPriceList = goodsUnitData.GoodsPriceList;
                    this.tNedit_Price.SetValue(GetPrice(goodsPriceList));
                }
                else
                {
                    // 商品名称
                    this.tEdit_GoodsName.Clear();

                    // 定価
                    this.tNedit_Price.Clear();
                }
            }
            // 商品掛率Ｇ
            else if (e.PrevCtrl == this.tNedit_GoodsMGroup)
            {
                if (this.tNedit_GoodsMGroup.GetInt() == 0)
                {
                    this.GoodsRateGrpName_tEdit.Clear();
                    return;
                }

                // 商品掛率Ｇコード取得
                int goodsRateGrpCode = this.tNedit_GoodsMGroup.GetInt();

                // 商品掛率Ｇ名称取得
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
            // グループコード
            else if (e.PrevCtrl == this.tNedit_BLGloupCode)
            {
                if (this.tNedit_BLGloupCode.GetInt() == 0)
                {
                    this.BLGroupName_tEdit.Clear();
                    return;
                }

                // BLグループコード取得
                int blGroupCode = this.tNedit_BLGloupCode.GetInt();

                // BLグループ名称
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
            // BLコード
            else if (e.PrevCtrl == this.tNedit_BLGoodsCode)
            {
                if (this.tNedit_BLGoodsCode.GetInt() == 0)
                {
                    this.BLGoodsName_tEdit.Clear();
                    return;
                }

                // BLコード取得
                int blGoodsCode = this.tNedit_BLGoodsCode.GetInt();

                // BL名称取得
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
            // 品番
            else if (e.PrevCtrl == this.tEdit_GoodsNo)
            {
                if (this.tEdit_GoodsNo.DataText.Trim() == "")
                {
                    this.tEdit_GoodsName.Clear();
                    this.tNedit_Price.Clear();
                    return;
                }

                // 商品コード取得
                string goodsCode = this.tEdit_GoodsNo.DataText.Trim();

                // 商品名称取得
                GoodsUnitData goodsUnitData;
                //int status = GetGoodsInfo(out goodsUnitData, goodsCode); // DEL 2009/03/16
                int status = GetGoodsInfo(out goodsUnitData, goodsCode, 0); // ADD 2009/03/16

                if (status == 0)
                {
                    // 商品名称
                    this.tEdit_GoodsName.DataText = goodsUnitData.GoodsNameKana.Trim();

                    // メーカー
                    this.tNedit_GoodsMakerCd.SetInt(goodsUnitData.GoodsMakerCd);
                    this.MakerName_tEdit.DataText = goodsUnitData.MakerName.Trim();
                    this._prevMakerCode = goodsUnitData.GoodsMakerCd;

                    // 定価
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
                        // フォーカス設定
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

            // タブ移動、またはカーソル移動でグリッドにフォーカスが当たった時のアクティブセルを設定します
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
        /// Leave イベント 
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        private void Detail_uGrid_Leave(object sender, EventArgs e)
        {
            this.Detail_uGrid.ActiveCell = null;
            this.Detail_uGrid.ActiveRow = null;
        }

        /// <summary>
        /// Shown イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
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
        // プライベートメンバー
        // ===================================================================================== //
        #region Private Members

        private string[] _tableNameList = new string[2];
        private string[] _gridTitleList = new string[2];
        private int[] _dataIndexList = new int[2];
        private bool[] _canLogicalDeleteDataExtractionList = new bool[2];
        private bool[] _defaultAutoFillToGridColumnList = new bool[2];
        private Image[] _gridIconList = new Image[2];
        private Hashtable[] _appearanceTable = new Hashtable[2];

        //　企業コード
        private string _enterpriseCode = "";

        // 自拠点コード
        private string _loginSectionCode = "";

        // 従業員
        private Employee _loginEmployee = null;

        
        //------------------------
        // 各種アクセスクラス定義
        //------------------------
        private RateAcs _rateAcs = null;					// 掛率アクセスクラス
        private UserGuideAcs _userGuideAcs = null;			// ユーザーガイドアクセスクラス
        //private CustomerInfoAcs _customerInfoAcs = null;	// 得意先アクセスクラス
        private SecInfoSetAcs _secInfoSetAcs = null;        // 拠点アクセスクラス
        private RateProtyMngAcs _rateProtyMngAcs = null;	// 掛率優先管理アクセスクラス
        private GoodsAcs _goodsAcs = null;					// 商品アクセスクラス
        private MakerAcs _makerAcs = null;					// メーカーアクセスクラス
        //private LGoodsGanreAcs _lGoodsGanreAcs = null;		// 商品区分グループアクセスクラス
        //private MGoodsGanreAcs _mGoodsGanreAcs = null;		// 商品区分アクセスクラス
        //private DGoodsGanreAcs _dGoodsGanreAcs = null;		// 商品区分詳細アクセスクラス
        private BLGoodsCdAcs _blGoodsCdAcs = null;			// BLアクセスクラス

        private SortedList _custRateGrpList = null;		// 得意先掛率グループ
        private bool _cusotmerGuideSelected;
        private string _customerGuideButtonName;

        private BLGroupUAcs _blGroupUAcs = null;
        private GoodsGroupUAcs _goodsGroupUAcs = null;
        private SecInfoAcs _secInfoAcs = null;
        private CustomerSearchAcs _customerSearchAcs = null;

        //------------
        // 各種検索用
        //------------
        private Rate _searchRate = null;		// 掛率データ検索用

        // 掛率データ格納用データテーブル
        private DataTable _dataTableRate = null;

        // 掛率データ検索結果リスト格納用
        private Hashtable _rateSrchRsltHashList = null;	// HashKey（key:新旧区分+ロット数）

        // 掛率データ検索結果比較用
        private Hashtable _rateSrchRsltHashListClone = null;

        //--------------------
        // ユーザーガイド関連
        //--------------------
        private SortedList _custRateGrpCodeSList = null;		// 得意先掛率グループ
        private SortedList _suppRateGrpCodeSList = null;		// 仕入先掛率グループ
        private SortedList _enterpriseGanreCodeSList = null;	// 自社分類
        private SortedList _priceDivSList = null;				// 価格区分
        private SortedList _bargainCdSList = null;				// 特売区分

        //--------------
        // タブ制御関連
        //--------------
        private SortedList _nextCtrlTable = null;		// 次項目
        private SortedList _forwardCtrlTable = null;	// 前項目

        // 文字列結合用
        private StringBuilder _stringBuilder = null;

        // 現在の入力状況フラグ
        private AllCtrlInputStatus _AllCtrlInputStatus;

        // 新規更新モードフラグ
        private ModeFlag _modeFlag;

        // 新単価算出区分フラグ（false:単価算出区分1選択不可, true:単価算出区分1選択可）
        private bool _unitPrcCalcDivNewFlag = true;

        // 旧単価算出区分フラグ（false:単価算出区分1選択不可, true:単価算出区分1選択可）
        private bool _unitPrcCalcDivOldFlag = true;

        // 画面デザイン変更クラス
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        //--------------
        // ロット画面用
        //--------------
        private DataTable _dataTableLotNew = null;	// 新ロット用データテーブル
        private DataTable _dataTableLotOld = null;	// 旧ロット用データテーブル
        private DataTable _dataTableLotNewClone = null;	// 新ロット用データテーブルクローン
        private DataTable _dataTableLotOldClone = null;	// 旧ロット用データテーブルクローン

        //------------------
        // コンボボックス用
        //------------------
        private int _unitPriceKindtComboEditorValue = -1;		// 単価種類コンボボックスデータ
        private int _unitPriceKindWaytComboEditorValue = -1;	// 設定方法コンボボックスデータ
        private DataTable _dataTableCustRateGrpCode = null;		// 得意先掛率グループコンボボックス用
        private DataTable _dataTableSuppRateGrpCode = null;		// 仕入先掛率グループコンボボックス用
        private DataTable _dataTableUnitPriceKind = null;		// 単価種類コンボボックス用
        private DataTable _dataTableUnitPriceKindWay = null;	// 設定方法コンボボックス用
		private DataTable _dataTableEnterpriseGanreCode = null;	// 自社分類コンボボックス用
        private DataTable _dataTablePriceDiv = null;			// 価格区分コンボボックス用
		private DataTable _dataTableUnPrcCalcDivNew = null;		// 単価算出区分コンボボックス用（新）
		private DataTable _dataTableUnPrcCalcDivOld = null;		// 単価算出区分コンボボックス用（旧）
        private DataTable _dataTableUnPrcFracProcDiv = null;	// 端数処理区分コンボボックス用
		private DataTable _dataTableBargainCd = null;			// 特売区分コンボボックス用

        //------------------------------
        // 各種条件設定用データテーブル
        //------------------------------
        private DataTable _dataTableAllInpCtrl = null;			// 全体入力コントロールデータテーブル
        private DataTable _dataTableInpCond = null;				// 入力条件設定用データテーブル
        private DataTable _dataTableRateGoodsCond = null;		// 商品掛率条件用データテーブル
        private DataTable _dataTableRateCustCond = null;		// 得意先掛率条件用データテーブル
		private DataTable _dataTableRateInpCond = null;			// 新旧掛率入力条件用データテーブル

        //----------------------------------
        // ロットグリッド用ＶＡＬＵＥリスト
        //----------------------------------
        ValueList _gVListPriceDiv = null;			// 価格区分
        ValueList _gVListUnPrcCalcDiv = null;		// 単価算出区分
        ValueList _gVListUnPrcFracProcUnit = null;	// 単価端数処理
        ValueList _gVListBargainCd = null;			// 特売区分コード
        ValueList _gVListOldPriceDiv = null;			// 価格区分
        ValueList _gVListOldUnPrcCalcDiv = null;		// 単価算出区分
        ValueList _gVListOldUnPrcFracProcUnit = null;	// 単価端数処理
        ValueList _gVListOldBargainCd = null;			// 特売区分コード

        // 編集モード
        private const string INSERT_MODE = "新規モード";
        private const string UPDATE_MODE = "更新モード";
        private const string DELETE_MODE = "削除モード";

        //----- ueno upd ---------- start 2008.02.18
        private const string COMMON_MODE = "全社";
        //----- ueno upd ---------- end 2008.02.18

        // 汎用新旧掛率設定
        private const string RATE_NEW = "新掛率設定(&L)";
        private const string RATE_OLD = "旧掛率設定(&L)";
		

        // Message関連定義
        private const string ASSEMBLY_ID = "DCKHN09160UA";
        private const string ERR_READ_MSG = "読み込みに失敗しました。";
        private const string NOT_FOUND_MSG = "データが存在しませんでした。";
        private const string ERR_DPR_MSG = "このコードは既に使用されています。";
        private const string ERR_LRDEL_MSG = "論理削除に失敗しました。";
        private const string ERR_PRDEL_MSG = "物理削除に失敗しました。";
        private const string ERR_UPDT_MSG = "登録に失敗しました。";
        private const string ERR_RVV_MSG = "復活に失敗しました。";
        private const string ERR_800_MSG = "既に他端末より更新されています";
        private const string ERR_801_MSG = "既に他端末より削除されています";
        private const string SDC_RDEL_MSG = "マスタから削除されています";
        private const string RATE_CPY_MSG = "新掛率設定のデータを旧掛率設定へ移動します。\nよろしいですか？";
        private const string ALL_DEL_MSG = "全てのデータが初期化されますがよろしいですか？";
        private const string RATE_ERR_MSG = "単価か掛率の何れかを設定してください。";
        private const string RATE_ERR_MSG2 = "掛率設定に未入力項目が存在します。";
        private const string RATE_SAVE_MSG = "掛率設定マスタにデータを登録しますか？";
        private const string RATE_STDATE_MSG = "「新掛率開始日　＞　旧掛率開始日」で設定してください。";
        private const string DATASET_NG_MSG = "データテーブルへの保存に失敗しました。";
        private const string DISP_CHG_MSG = "が変更されました。\n検索結果が初期化されます。よろしいですか？";
        private const string PHY_DEL_MSG = "データを削除します。\r\nよろしいですか？";
        private const string LOG_OLDDEL_MSG = "表示データを削除しますか？";
        private const string PHY_OLDDEL_MSG = "旧掛率データ及び、関連ロットデータを完全削除します。\r\nよろしいですか？";
        private const string SAV_INFO_MSG = "保存しました。";
        private const string LDEL_INFO_MSG = "論理削除しました。";
        private const string REV_INFO_MSG = "復活しました。";
        private const string PDEL_INFO_MSG = "物理削除しました。";
        private const string DISP_CLR_MSG = "現在、編集中のデータが存在します。\n初期状態に戻しますか？";
        private const string PHY_OLDDEL_INFO_MSG = "旧掛率データ及び、関連ロットデータを物理削除しました。";

        // コンボボックス用
        private const string COMBO_CODE = "COMBO_CODE";
        private const string COMBO_NAME = "COMBO_NAME";

        //------------
        // 入力条件用
        //------------
        // 全体入力コントロール用
        private const string ALLCTRL_ACTIVE_TAB = "画面タブ";
        private const string ALLCTRL_INPUT_STATUS = "画面入力状況";
        private const string ALLCTRL_RATECOND_PANEL = "掛率設定パネル";
        private const string ALLCTRL_SINGLE_PANEL = "単品設定パネル";
        private const string ALLCTRL_GRP_PANEL = "商品Ｇ設定パネル";
        private const string ALLCTRL_CUSTOMER_PANEL = "取引先パネル";
        private const string ALLCTRL_SEARCH_UBUTTON = "検索ボタン";
        private const string ALLCTRL_LOT_PANEL = "ロット開始日パネル";
        private const string ALLCTRL_NEWRATE_PANEL = "新掛率パネル";
        private const string ALLCTRL_OLDRATE_PANEL = "旧掛率パネル";
        private const string ALLCTRL_COPYTOOLDFROMNEWBTN = "新掛率→旧掛率";
        private const string ALLCTRL_RATE_OK_BUTTON = "保存ボタン";
        private const string ALLCTRL_RATE_LOGICALDELBTN = "論理削除ボタン";
        private const string ALLCTRL_RATE_PHYSICALDELBTN = "物理削除ボタン";
        private const string ALLCTRL_RATE_REVIVEBTN = "復活ボタン";
        private const string ALLCTRL_RATE_UTABPAGECONTROL = "掛率タブ";
        private const string ALLCTRL_LOT_UTABPAGECONTROL = "ロットタブ";

        // 入力条件用
        private const string COND_UNITPRICEKIND = "単価種類";
        private const string COND_UNITPRICEKINDWAYCD = "設定方法";
        private const string COND_GOODSNO = "商品番号";
        private const string COND_GOODSMAKERCD = "商品メーカーコード";
        private const string COND_GOODSRATERANK = "商品掛率ランク";
        private const string COND_LARGEGOODSGANRECODE = "商品区分グループコード";
        private const string COND_MEDIUMGOODSGANRECODE = "商品区分コード";
        private const string COND_DETAILGOODSGANRECODE = "商品区分詳細コード";
        private const string COND_ENTERPRISEGANRECODE = "自社分類コード";
        private const string COND_BLGOODSCODE = "BL商品コード";
        private const string COND_CUSTOMERCODE = "得意先コード";
        private const string COND_CUSTRATEGRPCODE = "得意先掛率グループコード";
        private const string COND_SUPPLIERCD = "仕入先コード";
        private const string COND_SUPPRATEGRPCODE = "仕入先掛率グループコード";
        private const string COND_RATESTARTDATE = "掛率開始日";
        private const string COND_PRICE = "価格";
        private const string COND_PRICEDIV = "価格区分";
        private const string COND_UNPRCCALCDIV = "単価算出区分";
        private const string COND_RATEMNGGOODSCD = "掛率設定区分（商品）";
        private const string COND_RATEMNGCUSTCD = "掛率設定区分（得意先）";

        // ファイルレイアウト関連
        private const string OLDNEWDIVCD_NEW = "0";	// 新旧フラグ（新）
        private const string OLDNEWDIVCD_OLD = "1";	// 新旧フラグ（旧）

        // ユーザーガイドデータ関連
        private const int GUIDEDIVCD_CUSTRATEGRPCODE = 43;	// ガイド区分（得意先掛率グループ）
        private const int GUIDEDIVCD_SUPPRATEGRPCODE = 44;	// ガイド区分（仕入先掛率グループ）
        private const int GUIDEDIVCD_ENTERPRISEGANRECODE = 41;	// ガイド区分（自社分類）
        private const int GUIDEDIVCD_PRICEDIV = 47;	// ガイド区分（価格区分）
        private const int GUIDEDIVCD_BARGAINCD = 42;	// ガイド区分（特売区分）
        
        #endregion

        #region enum

        /// <summary>
        /// 全体画面入力状況
        /// </summary>
        private enum AllCtrlInputStatus
        {
            // 初期(掛率設定)
            New = 0,

            // 条件設定
            InputCondition = 1,

            // 検索後新規ﾓｰﾄﾞ,
            // 削除ﾓｰﾄﾞ物理削除後
            SearchNew = 2,

            // 検索後更新ﾓｰﾄﾞ
            // 新規ﾓｰﾄﾞ保存後
            // 更新ﾓｰﾄﾞ保存後
            // 削除ﾓｰﾄﾞ復活後
            SearchUpdate = 3,

            // 検索後削除ﾓｰﾄﾞ
            SearchDelete = 4
        }
        
        /// <summary>
        /// 全体画面入力状況アクティブタブ
        /// </summary>
        private enum AllCtrlActiveTab
        {
            // 掛率タブ
            Rate = 0,
            // ロットタブ
            Lot = 1
        }

        /// <summary>
        /// モードフラグ
        /// </summary>
        private enum ModeFlag
        {
            // 未確定
            None = 0,
            // 新規
            New = 1,
            // 更新
            Update = 2,
            // 削除
            Delete = 3
        }

        /// <summary>
        /// 画面データ設定ステータス
        /// </summary>
        private enum DispSetStatus
        {
            // クリア
            Clear = 0,
            // 更新
            Update = 1,
            // 元に戻す
            Back = 2
        }

        /// <summary>
        /// 入力エラーチェックステータス
        /// </summary>
        private enum InputChkStatus
        {
            // 未入力
            NotInput = -1,
            // 存在しない
            NotExist = -2,
            // 入力ミス
            InputErr = -3,
            // 正常
            Normal = 0,

            //----- ueno add ---------- start 2008.03.04
            // キャンセル（曖昧検索用）
            Cancel = 1
            //----- ueno add ---------- end 2008.03.04			
        }
        #endregion
           --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/

        /* --- DEL 2008/06/18 --------------------------------------------------------------------->>>>>
		// ===================================================================================== //
		// 内部メソッド
		// ===================================================================================== //
		# region Private Methods

		/// <summary>画面初期設定処理</summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.03</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			//--------------------------
			// ユーザーガイドデータ取得
			//--------------------------
			ArrayList userGdBdList;

			// 得意先掛率グループ
			userGdBdList = null;
			GetUserGdBdList(out userGdBdList, GUIDEDIVCD_CUSTRATEGRPCODE);
			SetUserGdBd(ref this._custRateGrpCodeSList, ref userGdBdList);

            // 仕入先掛率グループ
            userGdBdList = null;
            GetUserGdBdList(out userGdBdList, GUIDEDIVCD_SUPPRATEGRPCODE);
            SetUserGdBd(ref this._suppRateGrpCodeSList  , ref userGdBdList);
			
            // 自社分類コード
            userGdBdList = null;
            GetUserGdBdList(out userGdBdList, GUIDEDIVCD_ENTERPRISEGANRECODE);
            SetUserGdBd(ref this._enterpriseGanreCodeSList, ref userGdBdList);
			
            // 価格区分
            userGdBdList = null;
            GetUserGdBdList(out userGdBdList, GUIDEDIVCD_PRICEDIV);
            SetUserGdBd(ref this._priceDivSList, ref userGdBdList);
			
            // 特売区分
            userGdBdList = null;
            GetUserGdBdList(out userGdBdList, GUIDEDIVCD_BARGAINCD);
            SetUserGdBd(ref this._bargainCdSList, ref userGdBdList);

            //--------------
            // 入力条件設定
            //--------------
            SetDataTableCond(ref Rate._setDataAllInpCtrl,		ref this._dataTableAllInpCtrl);
            SetDataTableCond(ref Rate._setDataInpCond,			ref this._dataTableInpCond);
            SetDataTableCond(ref Rate._setDataGoodsRateCond,	ref this._dataTableRateGoodsCond);
            SetDataTableCond(ref Rate._setDataCustRateCond,		ref this._dataTableRateCustCond);
            SetDataTableCond(ref Rate._setDataRateInpCond,		ref this._dataTableRateInpCond);

            //------------------------------------
            // コンボボックス用データテーブル設定
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
            // コンボボックス設定
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
        /// ユーザーガイドマスタボディ部リスト取得処理
        /// </summary>
        /// <param name="userGdBdList">ユーザーガイドリスト</param>
        /// <param name="guideDivCode">ユーザーガイド区分</param>
        /// <returns>STATUS [0:取得 0以外:取得失敗]</returns>
        /// <remarks>
        /// <br>Note       : ユーザーガイドマスタボディ部のリストを取得します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
                    "ユーザーガイド（ヘッダ）情報の取得に失敗しました。" + "\r\n" + e.Message,
                    -1,
                    MessageBoxButtons.OK);

                status = -1;
            }
            return status;
        }
		
        /// <summary>
        /// ユーザーガイドボディデータ設定処理
        /// </summary>
        /// <param name="sList">ユーザーガイドSortedList</param>
        /// <param name="userGdBdList">ユーザーガイドリスト</param>
        /// <returns>STATUS [0:取得 0以外:取得失敗]</returns>
        /// <remarks>
        /// <br>Note       : ユーザーガイドボディデータを設定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.03</br>
        /// </remarks>
        private void ScreenClear()
        {
            //----------------
            // 各フラグ初期化
            //----------------
            // パネル表示可否初期化
            this.Single_panel.Show();
            this.Grp_panel.Hide();

            // 入力状況フラグ初期化
            this._AllCtrlInputStatus = AllCtrlInputStatus.New;
			
            // モードラベル初期化
            this._modeFlag = ModeFlag.None;	// 未確定

            //------------
            // 初期化処理
            //------------
            // 前回の検索結果データが残っている場合削除
            if (this._dataTableRate != null)
            {
                this._dataTableRate.Rows.Clear();
            }
            if (this._rateSrchRsltHashList != null)
            {
                this._rateSrchRsltHashList = new Hashtable();
            }
            // 検索データがあればクリア
            if (this._searchRate.EnterpriseCode != null)
            {
                this._searchRate = null;
                this._searchRate = new Rate();
            }
			
            //------------------
            // 設定データクリア
            //------------------
            this._unitPriceKindtComboEditorValue	= NullChgInt(Rate._unitPriceKindTable.GetKey(0));		// 単価種類コンボボックス
            this._unitPriceKindWaytComboEditorValue = NullChgInt(Rate._unitPriceKindWayTable.GetKey(0));	// 設定方法コンボボックス
			
            // コンボボックス初期化
            this.UnitPriceKind_tComboEditor.Value			= Rate._unitPriceKindTable.GetKey(0);			// 単価種類
            this.UnitPriceKindWay_tComboEditor.Value		= Rate._unitPriceKindWayTable.GetKey(0);		// 設定方法
            this.CustRateGrpCode_tComboEditor.Clear();														// 得意先掛率グループ
            this.SuppRateGrpCode_tComboEditor.Clear();														// 仕入先掛率グループ
            this.EnterpriseGanreCode_Grp_tComboEditor.Clear();												// 自社分類
            this.NewPriceDiv_tComboEditor.Value				= this._priceDivSList.GetKey(0);				// 新基準価格区分
            this.NewUnPrcCalcDiv_tComboEditor.Value			= Rate._unPrcCalcDivTable.GetKey(0);			// 新単価算出区分
            this.NewUnPrcFracProcDiv_tComboEditor.Value		= Rate._unPrcFracProcDivTable.GetKey(0);		// 新単価端数処理区分
            this.NewBargainCd_tComboEditor.Value			= this._bargainCdSList.GetKey(0);				// 新特売区分
            this.OldPriceDiv_tComboEditor.Value				= this._priceDivSList.GetKey(0);				// 旧基準価格区分
            this.OldUnPrcCalcDiv_tComboEditor.Value			= Rate._unPrcCalcDivTable.GetKey(0);			// 旧単価算出区分
            this.OldUnPrcFracProcDiv_tComboEditor.Value		= Rate._unPrcFracProcDivTable.GetKey(0);		// 旧単価端数処理区分
            this.OldBargainCd_tComboEditor.Value			= this._bargainCdSList.GetKey(0);				// 旧特売区分
			
            // コンボボックスフィルタークリア
            this._dataTableUnPrcCalcDivNew.DefaultView.RowFilter = "";
            this._dataTableUnPrcCalcDivOld.DefaultView.RowFilter = "";

            // ヘッダ項目
            this.RateSectionCode_tEdit.Clear();			// 拠点コード
            this.SectionCodeNm_tEdit.Clear();		// 拠点名称
            this.RateSettingDivide_tEdit.Clear();	// 掛率設定区分
            this.RateMngGoodsCd_tEdit.Clear();		// 商品設定区分（コード）
            this.RateMngGoodsNm_tEdit.Clear();		// 商品設定区分（名称）
            this.RateMngCustCd_tEdit.Clear();		// 取引先設定区分（コード）
            this.RateMngCustNm_tEdit.Clear();		// 取引先設定区分（名称）
            this.Mode_Label.Text = "";

            // 単品設定項目
            this.GoodsNoCd_tEdit.Clear();					// 商品コード
            this.GoodsNoNm_tEdit.Clear();					// 商品名称
            this.GoodsMakerCd_tNedit.Clear();				// 商品メーカーコード
            this.GoodsMakerCdNm_tEdit.Clear();				// 商品メーカーコード（名称）

            // グループ設定項目
            this.GoodsMakerCd_Grp_tNedit.Clear();			// 商品メーカーコード
            this.GoodsMakerCdNm_Grp_tEdit.Clear();			// 商品メーカーコード（名称）
            this.GoodsRateRankCd_Grp_tEdit.Clear();			// 商品掛率ランク
            this.LargeGoodsGanreCode_Grp_tEdit.Clear();		// 商品区分グループコード
            this.LargeGoodsGanreCodeNm_Grp_tEdit.Clear();	// 商品区分グループコード（名称）
            this.MediumGoodsGanreCode_Grp_tEdit.Clear();	// 商品区分コード
            this.MediumGoodsGanreCodeNm_Grp_tEdit.Clear();	// 商品区分コード（名称）
            this.DetailGoodsGanreCode_Grp_tEdit.Clear();	// 商品区分詳細コード
            this.DetailGoodsGanreCodeNm_Grp_tEdit.Clear();	// 商品区分詳細コード（名称）
            this.BLGoodsCode_Grp_tNedit.Clear();			// ＢＬ商品コード
            this.BLGoodsCodeNm_Grp_tEdit.Clear();			// ＢＬ商品コード（名称）
			
            // 取引先設定項目
            this.CustomerCode_tNedit.Clear();				// 得意先コード
            this.CustomerCodeNm_tEdit.Clear();				// 得意先名称
            this.SupplierCd_tNedit.Clear();					// 仕入先コード
            this.SupplierCdNm_tEdit.Clear();				// 仕入先名称

            // 新掛率設定項目
            this.NewRateStartDate_tDateEdit.Clear();		// 掛率開始日
            this.NewPrice_tNedit.Clear();					// 単価
            this.NewRate_tNedit.Clear();					// 掛率
            this.NewUnPrcFracProcUnit_tNedit.Clear();		// 単価端数処理単位
			
            // 旧掛率設定項目
            this.OldRateStartDate_tDateEdit.Clear();		// 掛率開始日
            this.OldPrice_tNedit.Clear();					// 単価
            this.OldRate_tNedit.Clear();					// 掛率
            this.OldUnPrcFracProcUnit_tNedit.Clear();		// 単価端数処理単位

            //--------------------
            // 入力制御（パネル）
            //--------------------
            // 設定初期化
            this.RateCond_panel.Enabled = true;			// 掛率設定パネル
            this.Single_panel.Enabled = false;			// 単品設定パネル
            this.Grp_panel.Enabled = false;				// 商品Ｇ設定パネル
            this.Customer_panel.Enabled = false;		// 取引先パネル
            this.NewRate_panel.Enabled = false;			// 新掛率パネル（掛率タブ内）
            this.OldRate_panel.Enabled = false;			// 旧掛率パネル（掛率タブ内）
            this.Rate_uTabPageControl.Enabled = false;	// 掛率タブ
            this.Lot_uTabPageControl.Enabled = false;	// ロットタブ

            //--------------
            // 入力制御設定
            //--------------
            // 制御系ボタン設定
            this.Search_uButton.Enabled = false;					// 検索ボタン
            this.CopyToOldFromNewbtn.Enabled = false;				// 新掛率→旧掛率（掛率タブ内）
            this.Rate_Ok_Btn.Enabled = true;						// 保存ボタン（掛率タブ内）
			this.Rate_LogicalDel_Btn.Enabled = false;				// 論理削除ボタン（掛率タブ内）
			this.Rate_PhysicalDelBtn.Enabled = false;				// 物理削除ボタン（掛率タブ内）
			this.Rate_ReviveBtn.Enabled = false;					// 復活ボタン（掛率タブ内）
			this.Lot_Ok_Btn.Enabled = true;							// 保存ボタン（ロットタブ内）
			this.Lot_Clear_Btn.Enabled = true;						// 物理削除ボタン（ロットタブ内）
            
            // 項目ボタン設定
			this.GoodsNo_uButton.Enabled = false;					// 商品番号（単品）
			this.GoodsMakerCd_uButton.Enabled = false;				// 商品メーカー（単品）
            this.GoodsMakerCd_Grp_uButton.Enabled = false;			// 商品メーカー
			this.LargeGoodsGanreCode_Grp_uButton.Enabled = false;	// 商品区分グループコード
			this.MediumGoodsGanreCode_Grp_uButton.Enabled = false;	// 商品区分
			this.DetailGoodsGanreCode_Grp_uButton.Enabled = false;	// 商品区分詳細
			this.BLGoodsCode_Grp_uButton.Enabled = false;			// ＢＬ商品
			this.CustomerCode_uButton.Enabled = false;				// 得意先
			this.SupplierCd_uButton.Enabled = false;				// 仕入先
			this.NewRateStartDate_tDateEdit.Enabled = false;		// 新掛率開始カレンダー
			this.OldRateStartDate_tDateEdit.Enabled = false;		// 旧掛率開始カレンダー
			
			// 単品設定
			this.GoodsNoCd_tEdit.Enabled = false;					// 商品コード
			this.GoodsMakerCd_tNedit.Enabled = false;				// 商品メーカーコード
            
            // グループ設定
			this.GoodsMakerCd_Grp_tNedit.Enabled = false;			// 商品メーカーコード
			this.GoodsRateRankCd_Grp_tEdit.Enabled = false;			// 商品掛率ランク
			this.LargeGoodsGanreCode_Grp_tEdit.Enabled = false;		// 商品区分グループコード
			this.MediumGoodsGanreCode_Grp_tEdit.Enabled = false;	// 商品区分コード
			this.DetailGoodsGanreCode_Grp_tEdit.Enabled = false;	// 商品区分詳細コード
			this.BLGoodsCode_Grp_tNedit.Enabled = false;			// ＢＬ商品コード
			
			// 取引先設定
			this.CustomerCode_tNedit.Enabled = false;				// 得意先コード
			this.CustRateGrpCode_tComboEditor.Enabled = false;		// 得意先掛率グループ
			this.SupplierCd_tNedit.Enabled = false;					// 仕入先コード
			this.SuppRateGrpCode_tComboEditor.Enabled = false;		// 仕入先掛率グループ
			
			// 新掛率設定
			this.NewPrice_tNedit.Enabled = false;					// 新価格
			this.NewPriceDiv_tComboEditor.Enabled = false;			// 新基準価格区分
			this.NewUnPrcCalcDiv_tComboEditor.Enabled = false;		// 新単価算出区分
			this.NewRate_tNedit.Enabled = false;					// 新掛率
			this.NewUnPrcFracProcUnit_tNedit.Enabled = false;		// 新単価端数処理単位
			this.NewUnPrcFracProcDiv_tComboEditor.Enabled = false;	// 新単価端数処理区分
			this.NewBargainCd_tComboEditor.Enabled = false;			// 新特売区分コード

			// 旧掛率設定
			this.OldPrice_tNedit.Enabled = false;					// 旧価格
			this.OldPriceDiv_tComboEditor.Enabled = false;			// 旧基準価格区分
			this.OldUnPrcCalcDiv_tComboEditor.Enabled = false;		// 旧単価算出区分
			this.OldRate_tNedit.Enabled = false;					// 旧掛率
			this.OldUnPrcFracProcUnit_tNedit.Enabled = false;		// 旧単価端数処理単位
			this.OldUnPrcFracProcDiv_tComboEditor.Enabled = false;	// 旧単価端数処理区分
			this.OldBargainCd_tComboEditor.Enabled = false;			// 旧特売区分コード

			//------------
			// ロット画面
			//------------
			// ロット画面新旧ボタン
			this.LotOldNewRateStartDate_uButton.Text = RATE_NEW;
			
			// ロット掛率開始日
			this.LotNewRateStartDate_tDateEdit.ReadOnly = true;
			this.LotOldRateStartDate_tDateEdit.ReadOnly = true;
			
			// 全体入力コントロール
			SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.New.GetHashCode());
            
            this._AllCtrlInputStatus = AllCtrlInputStatus.New;
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.03</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			// フォーカス設定
			this.RateSectionCode_tEdit.Focus();
		}

		/// <summary>
		/// 全体入力コントロール用データセット列情報構築処理
		/// </summary>
		/// <param name="wkTable">データテーブル</param>
		/// <remarks>
		/// <br>Note       : 全体入力コントロール用データセットの列情報を構築します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.19</br>
		/// </remarks>
		private void DataTblColumnConstAllInpCtrl(ref DataTable wkTable)
		{
			//----------
			// 条件部分
			//----------
			// 画面タブ
			wkTable.Columns.Add(ALLCTRL_ACTIVE_TAB, typeof(string));

			// 画面入力状況
			wkTable.Columns.Add(ALLCTRL_INPUT_STATUS, typeof(string));

			//---------------------------
			// 設定可否（0：不可, 1：可）
			//---------------------------
			// 掛率設定パネル
			wkTable.Columns.Add(ALLCTRL_RATECOND_PANEL, typeof(string));
			
			// 単品設定パネル
			wkTable.Columns.Add(ALLCTRL_SINGLE_PANEL, typeof(string));
			
			// 商品Ｇ設定パネル
			wkTable.Columns.Add(ALLCTRL_GRP_PANEL, typeof(string));
			
			// 取引先パネル
			wkTable.Columns.Add(ALLCTRL_CUSTOMER_PANEL, typeof(string));
			
			// 検索ボタン
			wkTable.Columns.Add(ALLCTRL_SEARCH_UBUTTON, typeof(string));
			
			// 新掛率パネル
			wkTable.Columns.Add(ALLCTRL_NEWRATE_PANEL, typeof(string));
			
			// 旧掛率パネル
			wkTable.Columns.Add(ALLCTRL_OLDRATE_PANEL, typeof(string));
			
			// 新掛率→旧掛率
			wkTable.Columns.Add(ALLCTRL_COPYTOOLDFROMNEWBTN, typeof(string));
			
			// 保存ボタン
			wkTable.Columns.Add(ALLCTRL_RATE_OK_BUTTON, typeof(string));
			
			// 論理削除ボタン
			wkTable.Columns.Add(ALLCTRL_RATE_LOGICALDELBTN, typeof(string));
			
			// 物理削除ボタン
			wkTable.Columns.Add(ALLCTRL_RATE_PHYSICALDELBTN, typeof(string));
			
			// 復活ボタン
			wkTable.Columns.Add(ALLCTRL_RATE_REVIVEBTN, typeof(string));
			
			// 掛率タブ
			wkTable.Columns.Add(ALLCTRL_RATE_UTABPAGECONTROL, typeof(string));
			
			// ロットタブ
			wkTable.Columns.Add(ALLCTRL_LOT_UTABPAGECONTROL, typeof(string));
			
			// プライマリキー設定
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[ALLCTRL_ACTIVE_TAB], wkTable.Columns[ALLCTRL_INPUT_STATUS] };
		}

		/// <summary>
		/// 入力条件設定用データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 入力条件設定用データセットの列情報を構築します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.05</br>
		/// </remarks>
		private void DataTblColumnConstInpCond(ref DataTable wkTable)
		{
			//----------
			// 条件部分
			//----------
			// 単価種類
			wkTable.Columns.Add(COND_UNITPRICEKIND, typeof(string));

			// 設定方法
			wkTable.Columns.Add(COND_UNITPRICEKINDWAYCD, typeof(string));

			//---------------------------
			// 設定可否（0：不可, 1：可）
			//---------------------------
			// 商品番号
			wkTable.Columns.Add(COND_GOODSNO, typeof(string));

			// 商品メーカーコード
			wkTable.Columns.Add(COND_GOODSMAKERCD, typeof(string));

			// 商品掛率ランク
			wkTable.Columns.Add(COND_GOODSRATERANK, typeof(string));

			// 商品区分グループコード
			wkTable.Columns.Add(COND_LARGEGOODSGANRECODE, typeof(string));

			// 商品区分コード
			wkTable.Columns.Add(COND_MEDIUMGOODSGANRECODE, typeof(string));

			// 商品区分詳細コード
			wkTable.Columns.Add(COND_DETAILGOODSGANRECODE, typeof(string));

			// 自社分類コード
			wkTable.Columns.Add(COND_ENTERPRISEGANRECODE, typeof(string));

			// BL商品コード
			wkTable.Columns.Add(COND_BLGOODSCODE, typeof(string));

			// 得意先コード
			wkTable.Columns.Add(COND_CUSTOMERCODE, typeof(string));

			// 得意先掛率グループコード
			wkTable.Columns.Add(COND_CUSTRATEGRPCODE, typeof(string));

			// 仕入先コード
			wkTable.Columns.Add(COND_SUPPLIERCD, typeof(string));

			// 仕入先掛率グループコード
			wkTable.Columns.Add(COND_SUPPRATEGRPCODE, typeof(string));

			// プライマリキー設定
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COND_UNITPRICEKIND], wkTable.Columns[COND_UNITPRICEKINDWAYCD] };
		}

		/// <summary>
		/// 商品掛率条件設定用データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 商品掛率条件設定用データセットの列情報を構築します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.09</br>
		/// </remarks>
		private void DataTblColumnConstGoodsRateCond(ref DataTable wkTable)
		{
			//----------
			// 条件部分
			//----------
			// 区分
			wkTable.Columns.Add(COND_RATEMNGGOODSCD, typeof(string));

			//---------------------------
			// 設定可否（0：不可, 1：可）
			//---------------------------
			// 商品番号
			wkTable.Columns.Add(COND_GOODSNO, typeof(string));

			// 商品メーカーコード
			wkTable.Columns.Add(COND_GOODSMAKERCD, typeof(string));

			// 商品掛率ランク
			wkTable.Columns.Add(COND_GOODSRATERANK, typeof(string));

			// 商品区分グループコード
			wkTable.Columns.Add(COND_LARGEGOODSGANRECODE, typeof(string));

			// 商品区分コード
			wkTable.Columns.Add(COND_MEDIUMGOODSGANRECODE, typeof(string));

			// 商品区分詳細コード
			wkTable.Columns.Add(COND_DETAILGOODSGANRECODE, typeof(string));

			// 自社分類コード
			wkTable.Columns.Add(COND_ENTERPRISEGANRECODE, typeof(string));

			// BL商品コード
			wkTable.Columns.Add(COND_BLGOODSCODE, typeof(string));

			// プライマリキー設定
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COND_RATEMNGGOODSCD] };
		}

		/// <summary>
		/// 得意先掛率条件設定用データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 得意先掛率条件設定用データセットの列情報を構築します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.09</br>
		/// </remarks>
		private void DataTblColumnConstCustRateCond(ref DataTable wkTable)
		{
			//----------
			// 条件部分
			//----------
			// 区分
			wkTable.Columns.Add(COND_RATEMNGCUSTCD, typeof(string));

			//---------------------------
			// 設定可否（0：不可, 1：可）
			//---------------------------
			// 得意先コード
			wkTable.Columns.Add(COND_CUSTOMERCODE, typeof(string));
			
			// 得意先掛率グループコード
			wkTable.Columns.Add(COND_CUSTRATEGRPCODE, typeof(string));
			
			// 仕入先コード
			wkTable.Columns.Add(COND_SUPPLIERCD, typeof(string));
			
			// 仕入先掛率グループコード
			wkTable.Columns.Add(COND_SUPPRATEGRPCODE, typeof(string));
			
			// プライマリキー設定
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COND_RATEMNGCUSTCD] };
		}

		/// <summary>
		/// 新旧掛率入力条件用データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 新旧掛率入力条件用データセットの列情報を構築します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.11</br>
		/// </remarks>
		private void DataTblColumnConstRateInp(ref DataTable wkTable)
		{
			//----------
			// 条件部分
			//----------
			// 単価種類
			wkTable.Columns.Add(COND_UNITPRICEKIND, typeof(string));

			// 設定方法
			wkTable.Columns.Add(COND_UNITPRICEKINDWAYCD, typeof(string));

			//---------------------------
			// 設定可否（0：不可, 1：可）
			//---------------------------
			// 掛率開始日
			wkTable.Columns.Add(COND_RATESTARTDATE, typeof(string));

			// 価格
			wkTable.Columns.Add(COND_PRICE, typeof(string));

			// 価格区分
			wkTable.Columns.Add(COND_PRICEDIV, typeof(string));

			// 単価算出区分
			wkTable.Columns.Add(COND_UNPRCCALCDIV, typeof(string));

			// プライマリキー設定
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COND_UNITPRICEKIND], wkTable.Columns[COND_UNITPRICEKINDWAYCD] };
		}

		/// <summary>
		/// 条件設定用データ設定
		/// </summary>
		/// <param name="al">条件設定ArrayList</param>
		/// <param name="dataTable">データテーブル</param>
		/// <remarks>
		/// <br>Note       : 条件設定用データを設定します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
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
		/// 入力条件データ取得
		/// </summary>
		/// <param name="primaryKey1">プライマリキー１</param>
		/// <param name="primaryKey2">プライマリキー２</param>
		/// <param name="chkStr">チェック文字列</param>
		/// <param name="dataTable">データテーブル</param>
		/// <returns>結果文字列</returns>
		/// <remarks>
		/// <br>Note       : 入力条件データを取得します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
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
		/// 掛率条件データ取得
		/// </summary>
		/// <param name="code">コード</param>
		/// <param name="chkStr">名称</param>
		/// <param name="dataTable">データテーブル</param>
		/// <returns>結果文字列</returns>
		/// <remarks>
		/// <br>Note       : 掛率条件データを取得します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
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
		/// コンボボックスデフォルトデータ設定
		/// </summary>
		/// <remarks>
		/// <param name="sList">ソートリスト</param>
		/// <param name="dataTable">データテーブル</param>
		/// <br>Note       : コンボボックスデフォルトデータを先頭に設定します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
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
		/// コンボボックスデータ設定
		/// </summary>
		/// <remarks>
		/// <param name="sList">ソートリスト</param>
		/// <param name="dataTable">データテーブル</param>
		/// <br>Note       : コンボボックスデータを設定します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
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
		/// コンボボックスバインド
		/// </summary>
		/// <remarks>
		/// <param name="tCombo">TComboEditor</param>
		/// <param name="dataTable">データテーブル</param>
		/// <br>Note       : コンボボックスにバインドします。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.05</br>
		/// </remarks>
		private void BindCombo(ref TComboEditor tCombo, ref DataTable dataTable)
		{
			tCombo.DisplayMember = COMBO_NAME;
			tCombo.DataSource = dataTable.DefaultView;
		}

		/// <summary>
		/// 単価種類変更
		/// </summary>
		/// <param name="unitPriceKind">設定方法コード</param>
		/// <remarks>
		/// <br>Note　     : 単価種類の選択を変更したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.12</br>
		/// </remarks>
		private void UnitPriceKindVisibleChange(int unitPriceKind)
		{
			if (this._unitPriceKindtComboEditorValue == unitPriceKind) return;

			// 入力エリアが掛率条件設定エリア以外は全て初期化する
			if (_AllCtrlInputStatus != AllCtrlInputStatus.New )
			{
				string wkSectionCode = "";		// ワーク拠点コード
				string wkSectionCodeNm = "";	// ワーク拠点名称
				
				DialogResult res = TMsgDisp.Show(
					this, 								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_INFO,		// エラーレベル
					ASSEMBLY_ID,   						// アセンブリＩＤまたはクラスＩＤ
					ALL_DEL_MSG,						// 表示するメッセージ
					0, 									// ステータス値
					MessageBoxButtons.YesNo, 			// 表示するボタン
					MessageBoxDefaultButton.Button2);	// 初期表示ボタン

				if (res == DialogResult.Yes)
				{
					// 拠点コードのみ一時保存
					wkSectionCode = this.RateSectionCode_tEdit.Text;
					wkSectionCodeNm = this.SectionCodeNm_tEdit.Text;
					
					ScreenClear();
					
					this.UnitPriceKind_tComboEditor.Value = unitPriceKind;

					// 拠点コード設定
					this.RateSectionCode_tEdit.Text = wkSectionCode;
					this.SectionCodeNm_tEdit.Text = wkSectionCodeNm;

					// 現在データ保存
					this._searchRate.SectionCode = this.RateSectionCode_tEdit.Text;
				}
				else
				{
					// 選択状態を戻す
					this.UnitPriceKind_tComboEditor.Value = this._unitPriceKindtComboEditorValue;
					unitPriceKind = this._unitPriceKindtComboEditorValue;
				}
			}
			// 選択番号保持
			this._unitPriceKindtComboEditorValue = unitPriceKind;
		}

		/// <summary>
		/// 設定方法変更
		/// </summary>
		/// <param name="unitPriceKindWay">設定方法コード</param>
		/// <remarks>
		/// <br>Note　     : 設定方法の選択を変更したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.05</br>
		/// </remarks>
		private void UnitPriceKindWayVisibleChange(int unitPriceKindWay)
		{
			if (this._unitPriceKindWaytComboEditorValue == unitPriceKindWay) return;
			
			// 入力エリアが掛率条件設定エリア以外は全て初期化する
			if (_AllCtrlInputStatus != AllCtrlInputStatus.New)
			
			{
				string wkSectionCode = "";		// ワーク拠点コード
				string wkSectionCodeNm = "";	// ワーク拠点名称
				
				DialogResult res = TMsgDisp.Show(
					this, 								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_INFO,		// エラーレベル
					ASSEMBLY_ID,   						// アセンブリＩＤまたはクラスＩＤ
					ALL_DEL_MSG,						// 表示するメッセージ
					0, 									// ステータス値
					MessageBoxButtons.YesNo, 			// 表示するボタン
					MessageBoxDefaultButton.Button2);	// 初期表示ボタン

				if(res == DialogResult.Yes)
				{
					// 拠点コードのみ一時保存
					wkSectionCode = this.RateSectionCode_tEdit.Text;
					wkSectionCodeNm = this.SectionCodeNm_tEdit.Text;

					ScreenClear();
					this.UnitPriceKindWay_tComboEditor.Value = unitPriceKindWay;

					// 拠点コード設定
					this.RateSectionCode_tEdit.Text = wkSectionCode;
					this.SectionCodeNm_tEdit.Text = wkSectionCodeNm;
					
					// 現在データ保存
					this._searchRate.SectionCode = this.RateSectionCode_tEdit.Text;
				}
				else
				{
					// 選択状態を戻す
					this.UnitPriceKindWay_tComboEditor.Value = this._unitPriceKindWaytComboEditorValue;
					unitPriceKindWay = this._unitPriceKindWaytComboEditorValue;
				}
			}

			if (unitPriceKindWay == 0)
			{
				// 単品設定
				this.Single_panel.Show();
				this.Grp_panel.Hide();
			}
			else
			{
				// 商品グループ設定
				this.Single_panel.Hide();
				this.Grp_panel.Show();
			}
            
            // 選択番号保持
			this._unitPriceKindWaytComboEditorValue = unitPriceKindWay;
		}

		/// <summary>
		/// コンボボックス用データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <param name="wkTable">データテーブル</param>
		/// <br>Note       : コンボボックス用データセットの列情報を構築します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.04</br>
		/// </remarks>
		private void DataTblColumnConstComboList(ref DataTable wkTable)
		{
			wkTable.Columns.Add(COMBO_CODE, typeof(Int32));		// コード
			wkTable.Columns.Add(COMBO_NAME, typeof(string));	// 名称

			// プライマリキー設定
			wkTable.PrimaryKey = new DataColumn[] { wkTable.Columns[COMBO_CODE] };
		}

		/// <summary>
		/// 新掛率設定→旧掛率設定移動処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 新掛率設定を旧掛率設定へ移動します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.09</br>
		/// </remarks>
		private void CopyToOldRateFromNewRate()
		{
			// 新掛率設定データを旧掛率設定データにコピー
			this.OldRateStartDate_tDateEdit.SetDateTime(this.NewRateStartDate_tDateEdit.GetDateTime());	// 掛率開始日
			this.OldPrice_tNedit.Value					= this.NewPrice_tNedit.Value;					// 単価
			this.OldPriceDiv_tComboEditor.Value			= this.NewPriceDiv_tComboEditor.Value;			// 基準価格区分
			this.OldUnPrcCalcDiv_tComboEditor.Value		= this.NewUnPrcCalcDiv_tComboEditor.Value;		// 単価算出区分
			this.OldRate_tNedit.Value					= this.NewRate_tNedit.Value;					// 掛率
			this.OldUnPrcFracProcUnit_tNedit.Value		= this.NewUnPrcFracProcUnit_tNedit.Value;		// 単価端数処理単位
			this.OldUnPrcFracProcDiv_tComboEditor.Value = this.NewUnPrcFracProcDiv_tComboEditor.Value;	// 単価端数処理区分
			this.OldBargainCd_tComboEditor.Value		= this.NewBargainCd_tComboEditor.Value;			// 特売区分コード
			
			// 新掛率開始日は1日加算
			DateTime dtWk = this.OldRateStartDate_tDateEdit.GetDateTime();
			this.NewRateStartDate_tDateEdit.SetDateTime(dtWk.AddDays(1));
		}
        
        /// <summary>
		/// 全体入力コントロール設定制御処理
		/// </summary>
		/// <param name="activeTab">アクティブタブ</param>
		/// <param name="allCtrlInputStatus">画面入力状況</param>
		/// <remarks>
		/// <br>Note       : 全体入力コントロール設定を制御します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.10.19</br>
		/// </remarks>
		private void SettingAllInpCtrl(int activeTab, int allCtrlInputStatus)
		{
			string inpChkStr = "";
			
			//----------------
			// 掛率設定パネル
			//----------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_RATECOND_PANEL, ref this._dataTableAllInpCtrl);
			
			// 判定
			this.RateCond_panel.Enabled = string.Equals(inpChkStr, "1");
			
			//----------------
			// 単品設定パネル
			//----------------
			// 条件データテーブルより検索結果取得
			inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_SINGLE_PANEL, ref this._dataTableAllInpCtrl);

            // 判定
            this.Single_panel.Enabled = string.Equals(inpChkStr, "1");
			
            //------------------
            // 商品Ｇ設定パネル
            //------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_GRP_PANEL, ref this._dataTableAllInpCtrl);

            // 判定
            this.Grp_panel.Enabled = string.Equals(inpChkStr, "1");

            //------------------
            // 取引先パネル
            //------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_CUSTOMER_PANEL, ref this._dataTableAllInpCtrl);

            // 判定
            this.Customer_panel.Enabled = string.Equals(inpChkStr, "1");

            //------------------
            // 検索ボタン
            //------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_SEARCH_UBUTTON, ref this._dataTableAllInpCtrl);

            // 判定
            this.Search_uButton.Enabled = string.Equals(inpChkStr, "1");

            //------------------
            // 新掛率パネル
            //------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_NEWRATE_PANEL, ref this._dataTableAllInpCtrl);

            // 判定
            this.NewRate_panel.Enabled = string.Equals(inpChkStr, "1");

            //------------------
            // 旧掛率パネル
            //------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_OLDRATE_PANEL, ref this._dataTableAllInpCtrl);

            // 判定
            this.OldRate_panel.Enabled = string.Equals(inpChkStr, "1");

            //------------------
            // 新掛率→旧掛率
            //------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_COPYTOOLDFROMNEWBTN, ref this._dataTableAllInpCtrl);

            // 判定
            this.CopyToOldFromNewbtn.Enabled = string.Equals(inpChkStr, "1");

            //------------------
            // 保存ボタン
            //------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_RATE_OK_BUTTON, ref this._dataTableAllInpCtrl);

            // 判定
            if (string.Equals(inpChkStr, "1") == true)
            {
                this.Rate_Ok_Btn.Enabled = true;
            }
            else
            {
                this.Rate_Ok_Btn.Enabled = false;
            }
			
            //------------------
            // 論理削除ボタン
            //------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_RATE_LOGICALDELBTN, ref this._dataTableAllInpCtrl);
			
            // 判定
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
            // 物理削除ボタン
            //------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_RATE_PHYSICALDELBTN, ref this._dataTableAllInpCtrl);

            // 判定
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
            // 復活ボタン
            //------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_RATE_REVIVEBTN, ref this._dataTableAllInpCtrl);

            // 判定
            if (string.Equals(inpChkStr, "1") == true)
            {
                this.Rate_ReviveBtn.Show();
                this.Rate_ReviveBtn.Enabled = true;
				
                this.Rate_Ok_Btn.Hide();	// 保存ボタン非表示
            }
            else
            {
                this.Rate_ReviveBtn.Hide();
                this.Rate_ReviveBtn.Enabled = false;

                this.Rate_Ok_Btn.Show();	// 保存ボタン表示
            }

            //------------------
            // 掛率タブ
            //------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_RATE_UTABPAGECONTROL, ref this._dataTableAllInpCtrl);

            // 判定
            this.Rate_uTabPageControl.Enabled = string.Equals(inpChkStr, "1");

            //------------------
            // ロットタブ
            //------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(activeTab.ToString(), allCtrlInputStatus.ToString(), ALLCTRL_LOT_UTABPAGECONTROL, ref this._dataTableAllInpCtrl);

            // 判定
            this.Lot_uTabPageControl.Enabled = string.Equals(inpChkStr, "1");
        }

        /// <summary>
        /// 入力条件制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 入力条件入力域を制御します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.10.11</br>
        /// </remarks>
        private void SettingInpCond()
        {
            string inpUnitPriceKind		= NullChgStr(this.UnitPriceKind_tComboEditor.Value);
            string inpUnitPriceKindWay	= NullChgStr(this.UnitPriceKindWay_tComboEditor.Value);
			
            string inpChkStr = "";
            string rateChkStr = "";

            //---------------------------------------------------
            // 掛率設定区分最新情報取得（ショートカットキー対応）
            //---------------------------------------------------
            // 条件設定
            ArrayList wkInParamList = new ArrayList();
            wkInParamList.Add(this.RateSectionCode_tEdit.Text);
            wkInParamList.Add(NullChgInt(this.UnitPriceKind_tComboEditor.Value));
            wkInParamList.Add(NullChgInt(this.UnitPriceKindWay_tComboEditor.Value));
            wkInParamList.Add(this.RateSettingDivide_tEdit.Text);
			
            object wkInParamObj = wkInParamList;
            object wkOutParamObj = null;
			
            // 存在チェック
            int status = CheckRateSettingDivide(wkInParamList, out wkOutParamObj);
			
            bool canChangeFocus = false;
			
            if(status == 0)
            {
                // データ設定
                DispSetRateSettingDivide(DispSetStatus.Update, ref canChangeFocus, wkOutParamObj);
            }

            string inpRateMngGoodsCd	= this.RateMngGoodsCd_tEdit.Text;
            string inpRateMngCustCd		= this.RateMngCustCd_tEdit.Text;

            //--------------
            // 商品コード
            //--------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_GOODSNO, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_GOODSNO, ref this._dataTableRateGoodsCond).ToString();

            // 判定
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
            // 商品メーカーコード
            //--------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_GOODSMAKERCD, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_GOODSMAKERCD, ref this._dataTableRateGoodsCond).ToString();

            // 判定
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
            // 商品掛率ランク
            //------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_GOODSRATERANK, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_GOODSRATERANK, ref this._dataTableRateGoodsCond).ToString();

            // 判定
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
            // 商品区分グループコード
            //------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_LARGEGOODSGANRECODE, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_LARGEGOODSGANRECODE, ref this._dataTableRateGoodsCond).ToString();

            // 判定
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
            // 商品区分コード
            //------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_MEDIUMGOODSGANRECODE, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_MEDIUMGOODSGANRECODE, ref this._dataTableRateGoodsCond).ToString();

            // 判定
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
            // 商品区分詳細コード
            //--------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_DETAILGOODSGANRECODE, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_DETAILGOODSGANRECODE, ref this._dataTableRateGoodsCond).ToString();

            // 判定
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
            // 自社分類コード
            //--------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_ENTERPRISEGANRECODE, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_ENTERPRISEGANRECODE, ref this._dataTableRateGoodsCond).ToString();

            // 判定
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
            // ＢＬ商品コード
            //--------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_BLGOODSCODE, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngGoodsCd, COND_BLGOODSCODE, ref this._dataTableRateGoodsCond).ToString();

            // 判定
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
            // 得意先コード
            //--------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_CUSTOMERCODE, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngCustCd, COND_CUSTOMERCODE, ref this._dataTableRateCustCond).ToString();

            // 判定
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
            // 得意先掛率コード
            //--------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_CUSTRATEGRPCODE, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngCustCd, COND_CUSTRATEGRPCODE, ref this._dataTableRateCustCond).ToString();

            // 判定
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
            // 仕入先コード
            //--------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_SUPPLIERCD, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngCustCd, COND_SUPPLIERCD, ref this._dataTableRateCustCond).ToString();

            // 判定
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
            // 仕入先掛率コード
            //--------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_SUPPRATEGRPCODE, ref this._dataTableInpCond).ToString();
            rateChkStr = GetDataRateSettingCond(inpRateMngCustCd, COND_SUPPRATEGRPCODE, ref this._dataTableRateCustCond).ToString();

            // 判定
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
        /// 掛率入力制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 掛率入力域を制御します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.10.11</br>
        /// </remarks>
        private void SettingRateInpCond()
        {
            string inpUnitPriceKind		= NullChgStr(this.UnitPriceKind_tComboEditor.Value);
            string inpUnitPriceKindWay	= NullChgStr(this.UnitPriceKindWay_tComboEditor.Value);

            //---------------------------------------------------
            // 掛率設定区分最新情報取得（ショートカットキー対応）
            //---------------------------------------------------
            // 条件設定
            ArrayList wkInParamList = new ArrayList();
            wkInParamList.Add(this.RateSectionCode_tEdit.Text);
            wkInParamList.Add(NullChgInt(this.UnitPriceKind_tComboEditor.Value));
            wkInParamList.Add(NullChgInt(this.UnitPriceKindWay_tComboEditor.Value));
            wkInParamList.Add(this.RateSettingDivide_tEdit.Text);

            object wkInParamObj = wkInParamList;
            object wkOutParamObj = null;

            // 存在チェック
            int status = CheckRateSettingDivide(wkInParamList, out wkOutParamObj);

            bool canChangeFocus = false;

            if (status == 0)
            {
                // データ設定
                DispSetRateSettingDivide(DispSetStatus.Update, ref canChangeFocus, wkOutParamObj);
            }
            string inpRateMngGoodsCd = this.RateMngGoodsCd_tEdit.Text;
            string inpRateMngCustCd = this.RateMngCustCd_tEdit.Text;


            string inpChkStr = "";
            string rateChkStr = "";
			
            //------------------
            // 掛率開始日
            //------------------
            // 常に入力可
            this.NewRateStartDate_tDateEdit.Enabled = true;
            this.OldRateStartDate_tDateEdit.Enabled = true;
			
            //--------------------
            // 価格
            //--------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_PRICE, ref this._dataTableRateInpCond).ToString();
            rateChkStr = "";

            // 判定
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
            // 基準価格区分
            //------------------
            // 常に入力可
            this.NewPriceDiv_tComboEditor.Enabled = true;
            this.OldPriceDiv_tComboEditor.Enabled = true;
			
            //--------------------
            // 単価算出区分
            //--------------------
            // 条件データテーブルより検索結果取得
            inpChkStr = GetDataInpCond(inpUnitPriceKind, inpUnitPriceKindWay, COND_UNPRCCALCDIV, ref this._dataTableRateInpCond).ToString();
            rateChkStr = "";
			
            // フィルタークリア
            this._dataTableUnPrcCalcDivNew.DefaultView.RowFilter = "";
            this._dataTableUnPrcCalcDivOld.DefaultView.RowFilter = "";
			
            // 判定
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

                // 1:基準価格×掛率のみ
                string wkStr = "";
                _stringBuilder.Remove(0, _stringBuilder.Length);
                _stringBuilder.Append(COMBO_CODE);
                _stringBuilder.Append(" = '1'");
                wkStr = _stringBuilder.ToString();

                this._dataTableUnPrcCalcDivNew.DefaultView.RowFilter = wkStr;
                this._dataTableUnPrcCalcDivOld.DefaultView.RowFilter = wkStr;
            }

            //--------------------
            // 掛率
            //--------------------
            // 常に入力可
            this.NewRate_tNedit.Enabled = true;
            this.OldRate_tNedit.Enabled = true;

            //--------------------
            // 単価端数処理単位
            //--------------------
            // 常に入力可
            this.NewUnPrcFracProcUnit_tNedit.Enabled = true;
            this.OldUnPrcFracProcUnit_tNedit.Enabled = true;
			
            //--------------------
            // 単価端数処理区分
            //--------------------
            // 常に入力可
            this.NewUnPrcFracProcDiv_tComboEditor.Enabled = true;
            this.OldUnPrcFracProcDiv_tComboEditor.Enabled = true;
			
            //--------------------
            // 特売区分
            //--------------------
            // 常に入力可
            this.NewBargainCd_tComboEditor.Enabled = true;
            this.OldBargainCd_tComboEditor.Enabled = true;

            //----------------------
            // 掛率新旧コピーボタン
            //----------------------
            this.CopyToOldFromNewbtn.Enabled = true;
        }
		
        /// <summary>
        /// 条件チェック処理
        /// </summary>
        /// <param name="inpChkStr">入力チェック文字列</param>
        /// <param name="rateChkStr">掛率チェック文字列</param>
        /// <returns>結果文字列</returns>
        /// <remarks>
        /// <br>Note       : 条件をチェックします。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.10.09</br>
        /// </remarks>
        private string CheckCond(string inpChkStr, string rateChkStr)
        {
            string retStr = "0";
			
            // 入力制御チェック
            if (string.Equals(inpChkStr, "0") == false)
            {
                // 掛率チェック
                if (string.Equals(rateChkStr, "") == true)
                {
                    // 未設定の場合はチェックしない
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
        /// 掛率設定条件入力エラーチェック処理
        /// </summary>
        /// <returns>結果(true:正常, false:エラー)</returns>
        /// <remarks>
        /// <br>Note       : 掛率設定条件入力データのエラーチェックを行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.26</br>
        /// </remarks>
        private bool InpRateCondCheck()
        {
            bool retBool = false;
            string errMsg = null;
			
            // 拠点コード、掛率設定区分が入力されている場合
            if (InpRateSettingDataCheck(out errMsg) == 0)
            {
                // 入力条件制御
                SettingInpCond();

                // 全体入力コントロール
                SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.InputCondition.GetHashCode());
                this._AllCtrlInputStatus = AllCtrlInputStatus.InputCondition;

                // モードラベル
                this._modeFlag = ModeFlag.None;	// 未確定
				
                retBool = true;
            }
            else
            {
                // 全体入力コントロール
                SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.New.GetHashCode());
                this._AllCtrlInputStatus = AllCtrlInputStatus.New;
			
                retBool = false;
            }
            return retBool;
        }

        /// <summary>
        /// 掛率条件入力データエラーチェック処理
        /// </summary>
        /// <returns>チェック結果(0:NG, 1:OK)</returns>
        /// <remarks>
        /// <br>Note       : 掛率条件入力データのエラーチェックを行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private int InpRateSettingDataCheck(out string errMsg)
        {
            int ret = 0;
			
            errMsg = "";	// エラーメッセージ
			
            _stringBuilder.Remove(0, _stringBuilder.Length);
            _stringBuilder.Append("以下項目は必須入力です。\n");
			
            //------------
            // 拠点コード
            //------------
            if ((this.RateSectionCode_tEdit.Enabled == true)&&(this.RateSectionCode_tEdit.Text == ""))
            {
                // 名称クリア
                this.SectionCodeNm_tEdit.Clear();

                // 現在データクリア
                this._searchRate.SectionCode = "";

                _stringBuilder.Append("拠点コード\n");
                ret = 1;
            }
			
            //--------------
            // 掛率設定区分
            //--------------
            if ((this.RateSettingDivide_tEdit.Enabled == true)&&(this.RateSettingDivide_tEdit.Text == ""))
            {
                // 名称クリア
                this.RateMngCustCd_tEdit.Clear();
                this.RateMngCustNm_tEdit.Clear();
                this.RateMngGoodsCd_tEdit.Clear();
                this.RateMngGoodsNm_tEdit.Clear();

                // 現在データクリア
                this._searchRate.RateSettingDivide = "";
                this._searchRate.RateMngCustCd = "";
                this._searchRate.RateMngCustNm = "";
                this._searchRate.RateMngGoodsCd = "";
                this._searchRate.RateMngGoodsNm = "";

                _stringBuilder.Append("掛率設定区分\n");
                ret = 1;
            }

            // エラーメッセージ出力
            if (ret == 1)
            {
                errMsg = _stringBuilder.ToString();
            }
            return ret;
        }
		
        /// <summary>
        /// 入力データエラーチェック処理
        /// </summary>
        /// <returns>チェック結果(0:NG, 1:OK)</returns>
        /// <remarks>
        /// <br>Note       : 入力データのエラーチェックを行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private int InpDataCheck()
        {
            int ret = 0;
			
            string errMsg = "";	// エラーメッセージ
			
            _stringBuilder.Remove(0, _stringBuilder.Length);
            _stringBuilder.Append("以下項目は必須入力です。\n");
			
            // 条件部分未入力チェック
			
            //--------------------
            // 商品メーカーコード
            //--------------------
            if (this.UnitPriceKindWay_tComboEditor.SelectedIndex == 0)
            {
                // 単品
                if ((this.GoodsMakerCd_tNedit.Enabled == true)&&(this.GoodsMakerCd_tNedit.Text == ""))
                {
                    // 名称クリア
                    this.GoodsMakerCdNm_tEdit.Clear();

                    // 現在データクリア
                    this._searchRate.GoodsMakerCd = 0;
					
                    _stringBuilder.Append("商品メーカーコード\n");
                    ret = 1;
                }
            }
            else
            {
                // グループ
                if ((this.GoodsMakerCd_Grp_tNedit.Enabled == true)&&(this.GoodsMakerCd_Grp_tNedit.Text == ""))
                {
                    // 名称クリア
                    this.GoodsMakerCdNm_Grp_tEdit.Clear();

                    // 現在データクリア
                    this._searchRate.GoodsMakerCd = 0;
					
                    _stringBuilder.Append("商品メーカーコード\n");
                    ret = 1;
                }
            }

            //--------------
            // 商品コード
            //--------------
            if ((this.GoodsNoCd_tEdit.Enabled == true) && (this.GoodsNoCd_tEdit.Text == ""))
            {
                // 名称クリア
                this.GoodsNoNm_tEdit.Clear();

                // 現在データクリア
                this._searchRate.GoodsNo = "";
				
                _stringBuilder.Append("商品コード\n");
                ret = 1;
            }
			
            //------------------
            // 商品掛率ランク
            //------------------
            if ((this.GoodsRateRankCd_Grp_tEdit.Enabled == true)&&(this.GoodsRateRankCd_Grp_tEdit.Text == ""))
            {
                _stringBuilder.Append("商品掛率ランク\n");
                ret = 1;
            }
			
            //------------------------
            // 商品区分グループコード
            //------------------------
            if ((this.LargeGoodsGanreCode_Grp_tEdit.Enabled == true)&&(this.LargeGoodsGanreCode_Grp_tEdit.Text == ""))
            {
                // 名称クリア
                this.LargeGoodsGanreCodeNm_Grp_tEdit.Clear();

                // 現在データクリア
                this._searchRate.LargeGoodsGanreCode = "";

                _stringBuilder.Append("商品区分グループコード\n");
                ret = 1;
            }

            //------------------
            // 商品区分コード
            //------------------
            if ((this.MediumGoodsGanreCode_Grp_tEdit.Enabled == true)&&(this.MediumGoodsGanreCode_Grp_tEdit.Text == ""))
            {
                // 名称クリア
                this.MediumGoodsGanreCodeNm_Grp_tEdit.Clear();

                // 現在データクリア
                this._searchRate.MediumGoodsGanreCode = "";

                _stringBuilder.Append("商品区分\n");
                ret = 1;
            }

            //--------------------
            // 商品区分詳細コード
            //--------------------
            if ((this.DetailGoodsGanreCode_Grp_tEdit.Enabled == true)&&(this.DetailGoodsGanreCode_Grp_tEdit.Text == ""))
            {
                // 名称クリア
                this.DetailGoodsGanreCodeNm_Grp_tEdit.Clear();

                // 現在データクリア
                this._searchRate.DetailGoodsGanreCode = "";

                _stringBuilder.Append("商品区分詳細\n");
                ret = 1;
            }

            //--------------------
            // 自社分類コード
            //--------------------
            // 画面上に「0」を表示させないため半角空白を設定しているので空白削除する
            if ((this.EnterpriseGanreCode_Grp_tComboEditor.Enabled == true)
                &&(this.EnterpriseGanreCode_Grp_tComboEditor.Text.Trim() == ""))
            {
                _stringBuilder.Append("自社分類コード\n");
                ret = 1;
            }

            //--------------------
            // ＢＬ商品コード
            //--------------------
            if ((this.BLGoodsCode_Grp_tNedit.Enabled == true)&&(this.BLGoodsCode_Grp_tNedit.Text == ""))
            {
                // 名称クリア
                this.BLGoodsCodeNm_Grp_tEdit.Clear();

                // 現在データクリア
                this._searchRate.BLGoodsCode = 0;
				
                _stringBuilder.Append("ＢＬ商品コード\n");
                ret = 1;
            }

            //--------------------
            // 得意先コード
            //--------------------
            if ((this.CustomerCode_tNedit.Enabled == true)&&(this.CustomerCode_tNedit.Text == ""))
            {
                // 名称クリア
                this.CustomerCodeNm_tEdit.Clear();
				
                // 現在データクリア
                this._searchRate.CustomerCode = 0;
				
                _stringBuilder.Append("得意先コード\n");
                ret = 1;
            }

            //--------------------
            // 得意先掛率コード
            //--------------------
            // 画面上に「0」を表示させないため半角空白を設定しているので、空白削除する
            if ((this.CustRateGrpCode_tComboEditor.Enabled == true)
                &&(this.CustRateGrpCode_tComboEditor.Text.Trim() == ""))
            {
                _stringBuilder.Append("得意先掛率グループコード\n");
                ret = 1;
            }

            //--------------------
            // 仕入先コード
            //--------------------
            if ((this.SupplierCd_tNedit.Enabled == true)&&(this.SupplierCd_tNedit.Text == ""))
            {
                // 名称クリア
                this.SupplierCdNm_tEdit.Clear();

                // 現在データクリア
                this._searchRate.SupplierCd = 0;

                _stringBuilder.Append("仕入先コード\n");
                ret = 1;
            }

            //--------------------
            // 仕入先掛率コード
            //--------------------
            // 画面上に「0」を表示させないため半角空白を設定しているので空白削除する
            if ((this.SuppRateGrpCode_tComboEditor.Enabled == true)
                &&(this.SuppRateGrpCode_tComboEditor.Text.Trim() == ""))
            {
                _stringBuilder.Append("仕入先掛率グループコード\n");
                ret = 1;
            }
			
            // エラーメッセージ出力
            if(ret == 1)
            {
                errMsg = _stringBuilder.ToString();
                ShowInpErrMsg(errMsg);
            }
            return ret;
        }

        /// <summary>
        /// 条件項目チェック処理
        /// </summary>
        /// <returns>チェック結果(true:OK, false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 条件項目に対して過不足が無いがチェックします。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
            // 拠点コード
            //------------
            if (this.RateSectionCode_tEdit.Enabled == true)
            {
                // 条件設定クリア
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
                status = (int)InputChkStatus.NotExist;

                //----- ueno add ---------- start 2008.03.31
                // 拠点コードゼロ埋め
                if (this.RateSectionCode_tEdit.Text != "")
                {
                    this.RateSectionCode_tEdit.Text = GetZeroPaddedTextProc(this.RateSectionCode_tEdit.Text, this.RateSectionCode_tEdit.ExtEdit.Column);

                    // ワークデータもゼロ埋めする
                    this._searchRate.SectionCode = GetZeroPaddedTextProc(this._searchRate.SectionCode, this.RateSectionCode_tEdit.ExtEdit.Column);
                }
                //----- ueno add ---------- end 2008.03.31

                // 条件設定
                inParamObj = this.RateSectionCode_tEdit.Text;

                // 存在チェック
                status = CheckSectionCode(inParamObj, out outParamObj);
                switch(status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // 値変更チェック
                            if (this.RateSectionCode_tEdit.Text != this._searchRate.SectionCode)
                            {
                                dispSetStatus = editChgDataChk("拠点コード", this.RateSectionCode_tEdit.Text, this._searchRate.SectionCode);

                                // データ設定
                                DispSetSectionCode(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("拠点コード");
                            dispSetStatus = this._searchRate.SectionCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;

                            // データ設定
                            DispSetSectionCode(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }

                //--------------------------------
                // 拠点コード関連項目クリア処理
                //--------------------------------
                // 画面データ、ワークデータともに未入力時は全て削除する
                if ((this.RateSectionCode_tEdit.Text == "") && (this._searchRate.SectionCode == ""))
                {
                    SectionCodeVisibleChange();
                }
				
                // 値が変更される場合、または、存在チェックがエラーの場合は以下の処理に進まない
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //--------------
            // 掛率設定区分
            //--------------
            if (this.RateSettingDivide_tEdit.Enabled == true)
            {
                // 条件設定クリア
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
                status = (int)InputChkStatus.NotExist;

                // 条件設定
                inParamList.Add(this.RateSectionCode_tEdit.Text);
                inParamList.Add(NullChgInt(this.UnitPriceKind_tComboEditor.Value));
                inParamList.Add(NullChgInt(this.UnitPriceKindWay_tComboEditor.Value));
                inParamList.Add(this.RateSettingDivide_tEdit.Text);
                inParamObj = inParamList;

                // 存在チェック
                status = CheckRateSettingDivide(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // 値変更チェック
                            if (this.RateSettingDivide_tEdit.Text != this._searchRate.RateSettingDivide)
                            {
                                dispSetStatus = editChgDataChk("掛率設定区分", this.RateSettingDivide_tEdit.Text, this._searchRate.RateSettingDivide);

                                // データ設定
                                DispSetRateSettingDivide(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("掛率設定区分");
                            dispSetStatus = this._searchRate.RateSettingDivide == "" ? DispSetStatus.Clear : DispSetStatus.Back;

                            // データ設定
                            DispSetRateSettingDivide(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }

                //--------------------------------
                // 掛率設定区分関連項目クリア処理
                //--------------------------------
                // 画面データ、ワークデータともに未入力時は全て削除する
                if ((this.RateSettingDivide_tEdit.Text == "") && (this._searchRate.RateSettingDivide == ""))
                {
                    RateSettingDivideVisibleChange();
                }

                // 値が変更される場合、または、存在チェックがエラーの場合は以下の処理に進まない
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //----------------
            // メーカーコード
            //----------------
            // 単品設定時
            if (this.UnitPriceKindWay_tComboEditor.SelectedIndex == 0)
            {
                if (this.GoodsMakerCd_tNedit.Enabled == true)
                {
                    // 条件設定クリア
                    inParamObj = null;
                    outParamObj = null;
                    inParamList = new ArrayList();
                    dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
                    status = (int)InputChkStatus.NotExist;

                    // 条件設定
                    inParamObj = this.GoodsMakerCd_tNedit.GetInt();

                    // 存在チェック
                    status = CheckGoodsMakerCd(inParamObj, out outParamObj); 
                    switch (status)
                    {
                        case (int)InputChkStatus.Normal:
                        case (int)InputChkStatus.NotInput:
                            {
                                // 値変更チェック
                                if (this.GoodsMakerCd_tNedit.GetInt() != this._searchRate.GoodsMakerCd)
                                {
                                    dispSetStatus = editChgDataChk("メーカーコード（単品）", this.GoodsMakerCd_tNedit.GetInt(), this._searchRate.GoodsMakerCd);

                                    // データ設定
                                    DispSetGoodsMakerCd(dispSetStatus, ref canChangeFocus, outParamObj);
                                }
                                break;
                            }
                        default:
                            {
                                ShowNotFoundErrMsg("メーカーコード（単品）");
                                dispSetStatus = this._searchRate.GoodsMakerCd == 0 ? DispSetStatus.Clear : DispSetStatus.Back;

                                // データ設定
                                DispSetGoodsMakerCd(dispSetStatus, ref canChangeFocus, outParamObj);
                                break;
                            }
                    }
					
                    // 値が変更される場合、または、存在チェックがエラーの場合は以下の処理に進まない
                    if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                    {
                        return false;
                    }
                }
            }
            // グループ設定時
            else
            {
                if (this.GoodsMakerCd_Grp_tNedit.Enabled == true)
                {
                    // 条件設定クリア
                    inParamObj = null;
                    outParamObj = null;
                    inParamList = new ArrayList();
                    dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
                    status = (int)InputChkStatus.NotExist;

                    // 条件設定
                    inParamObj = this.GoodsMakerCd_Grp_tNedit.GetInt();

                    // 存在チェック
                    status = CheckGoodsMakerCd(inParamObj, out outParamObj); 
                    switch (status)
                    {
                        case (int)InputChkStatus.Normal:
                        case (int)InputChkStatus.NotInput:
                            {
                                // 値変更チェック
                                if (this.GoodsMakerCd_Grp_tNedit.GetInt() != this._searchRate.GoodsMakerCd)
                                {
                                    dispSetStatus = editChgDataChk("メーカーコード", this.GoodsMakerCd_Grp_tNedit.GetInt(), this._searchRate.GoodsMakerCd);

                                    // データ設定
                                    DispSetGoodsMakerCdGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                                }
                                break;
                            }
                        default:
                            {
                                ShowNotFoundErrMsg("メーカーコード");
                                dispSetStatus = this._searchRate.GoodsMakerCd == 0 ? DispSetStatus.Clear : DispSetStatus.Back;

                                // データ設定
                                DispSetGoodsMakerCdGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                                break;
                            }
                    }

                    // 値が変更される場合、または、存在チェックがエラーの場合は以下の処理に進まない
                    if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                    {
                        return false;
                    }
                }
            }

            //----------------
            // 商品掛率ランク
            //----------------
            if (this.GoodsRateRankCd_Grp_tEdit.Enabled == true)
            {
                status = (int)InputChkStatus.Normal;

                // 値変更チェック
                if (this.GoodsRateRankCd_Grp_tEdit.Text != this._searchRate.GoodsRateRank)
                {
                    dispSetStatus = editChgDataChk("商品掛率ランク", this.GoodsRateRankCd_Grp_tEdit.Text, this._searchRate.GoodsRateRank);
                }
				
                outParamObj = this.GoodsRateRankCd_Grp_tEdit.Text;
				
                // データ設定
                DispSetGoodsRateRankCd(dispSetStatus, ref canChangeFocus, outParamObj);

                // 値が変更される場合、または、存在チェックがエラーの場合は以下の処理に進まない
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //------------
            // 商品コード
            //------------
            if (this.GoodsNoCd_tEdit.Enabled == true)
            {
                // 条件設定クリア
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
                status = (int)InputChkStatus.NotExist;

                // 条件設定
                inParamList.Add(this.GoodsMakerCd_tNedit.GetInt());
                inParamList.Add(this.GoodsNoCd_tEdit.Text);
                inParamObj = inParamList;

                // 存在チェック（曖昧無し）
                status = CheckGoodsNoCdDirect(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // 値変更チェック
                            if (this.GoodsNoCd_tEdit.Text != this._searchRate.GoodsNo)
                            {
                                dispSetStatus = editChgDataChk("商品コード", this.GoodsNoCd_tEdit.Text, this._searchRate.GoodsNo);

                                // データ設定
                                DispSetGoodsNoCd(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("商品コード");
                            dispSetStatus = this._searchRate.GoodsNo == "" ? DispSetStatus.Clear : DispSetStatus.Back;

                            // データ設定
                            DispSetGoodsNoCd(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }

                // 値が変更される場合、または、存在チェックがエラーの場合は以下の処理に進まない
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //------------------------
            // 商品区分グループコード
            //------------------------
            if (this.LargeGoodsGanreCode_Grp_tEdit.Enabled == true)
            {
                // 条件設定クリア
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
                status = (int)InputChkStatus.NotExist;

                // 条件設定
                inParamObj = this.LargeGoodsGanreCode_Grp_tEdit.Text;

                // 存在チェック
                status = CheckLargeGoodsGanreCodeGrp(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // 値変更チェック
                            if (this.LargeGoodsGanreCode_Grp_tEdit.Text != this._searchRate.LargeGoodsGanreCode)
                            {
                                dispSetStatus = editChgDataChk("商品区分グループコード", this.LargeGoodsGanreCode_Grp_tEdit.Text, this._searchRate.LargeGoodsGanreCode);

                                // データ設定
                                DispSetLargeGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("商品区分グループコード");
                            dispSetStatus = this._searchRate.LargeGoodsGanreCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;

                            // データ設定
                            DispSetLargeGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }
                // 値が変更される場合、または、存在チェックがエラーの場合は以下の処理に進まない
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //----------------
            // 商品区分コード
            //----------------
            if (this.MediumGoodsGanreCode_Grp_tEdit.Enabled == true)
            {
                // 条件設定クリア
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用

                // 条件設定
                inParamList.Add(this.LargeGoodsGanreCode_Grp_tEdit.Text);
                inParamList.Add(this.MediumGoodsGanreCode_Grp_tEdit.Text);
                inParamObj = inParamList;
                status = (int)InputChkStatus.NotExist;

                // 存在チェック
                status = CheckMediumGoodsGanreCodeGrp(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // 値変更チェック
                            if (this.MediumGoodsGanreCode_Grp_tEdit.Text != this._searchRate.MediumGoodsGanreCode)
                            {
                                dispSetStatus = editChgDataChk("商品区分コード", this.MediumGoodsGanreCode_Grp_tEdit.Text, this._searchRate.MediumGoodsGanreCode);

                                // データ設定
                                DispSetMediumGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("商品区分コード");
                            dispSetStatus = this._searchRate.MediumGoodsGanreCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;

                            // データ設定
                            DispSetMediumGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;

                        }
                }
                // 値が変更される場合、または、存在チェックがエラーの場合は以下の処理に進まない
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //--------------------
            // 商品区分詳細コード
            //--------------------
            if (this.DetailGoodsGanreCode_Grp_tEdit.Enabled == true)
            {
                // 条件設定クリア
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
                status = (int)InputChkStatus.NotExist;

                // 条件設定
                inParamList.Add(this.LargeGoodsGanreCode_Grp_tEdit.Text);
                inParamList.Add(this.MediumGoodsGanreCode_Grp_tEdit.Text);
                inParamList.Add(this.DetailGoodsGanreCode_Grp_tEdit.Text);
                inParamObj = inParamList;

                // 存在チェック
                status = CheckDetailGoodsGanreCodeGrp(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // 値変更チェック
                            if (this.DetailGoodsGanreCode_Grp_tEdit.Text != this._searchRate.DetailGoodsGanreCode)
                            {
                                dispSetStatus = editChgDataChk("商品区分詳細コード", this.DetailGoodsGanreCode_Grp_tEdit.Text, this._searchRate.DetailGoodsGanreCode);

                                // データ設定
                                DispSetDetailGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("商品区分詳細コード");
                            dispSetStatus = this._searchRate.DetailGoodsGanreCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;

                            // データ設定
                            DispSetDetailGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }
                // 値が変更される場合、または、存在チェックがエラーの場合は以下の処理に進まない
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //----------------
            // 自社分類コード
            //----------------
            if ((this.EnterpriseGanreCode_Grp_tComboEditor.Enabled == true) && (this.EnterpriseGanreCode_Grp_tComboEditor.Value != null))
            {
                // 条件設定クリア
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
                status = (int)InputChkStatus.NotExist;

                // 条件設定
                inParamList.Add(this._enterpriseGanreCodeSList);
                inParamList.Add((int)this.EnterpriseGanreCode_Grp_tComboEditor.Value);
                inParamObj = inParamList;

                // 存在チェック
                status = CheckUserGuide(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // 値変更チェック
                            if ((int)this.EnterpriseGanreCode_Grp_tComboEditor.Value != this._searchRate.EnterpriseGanreCode)
                            {
                                dispSetStatus = editChgDataChk("自社分類コード", this.EnterpriseGanreCode_Grp_tComboEditor.Value.ToString(), this._searchRate.EnterpriseGanreCode);

                                // データ設定
                                DispSetEnterpriseGanreCode(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("自社分類コード");
                            dispSetStatus = this._searchRate.EnterpriseGanreCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;

                            // データ設定
                            DispSetEnterpriseGanreCode(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }
                // 値が変更される場合、または、存在チェックがエラーの場合は以下の処理に進まない
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //----------------
            // ＢＬ商品コード
            //----------------
            if (this.BLGoodsCode_Grp_tNedit.Enabled == true)
            {
                // 条件設定クリア
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
                status = (int)InputChkStatus.NotExist;

                // 条件設定
                inParamObj = this.BLGoodsCode_Grp_tNedit.GetInt();

                // 存在チェック
                status = CheckBLGoodsCodeGrp(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // 値変更チェック
                            if (this.BLGoodsCode_Grp_tNedit.GetInt() != this._searchRate.BLGoodsCode)
                            {
                                dispSetStatus = editChgDataChk("ＢＬ商品コード", this.BLGoodsCode_Grp_tNedit.GetInt(), this._searchRate.BLGoodsCode);

                                // データ設定
                                DispSetBLGoodsCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("ＢＬ商品コード");
                            dispSetStatus = this._searchRate.BLGoodsCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;

                            // データ設定
                            DispSetBLGoodsCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }
                // 値が変更される場合、または、存在チェックがエラーの場合は以下の処理に進まない
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //----------------
            // 得意先コード
            //----------------
            if (this.CustomerCode_tNedit.Enabled == true)
            {
                // 条件設定クリア
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
                status = (int)InputChkStatus.NotExist;

                // 条件設定
                inParamObj = this.CustomerCode_tNedit.GetInt();

                // 存在チェック
                status = CheckCustomerCode(inParamObj, out outParamObj);
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // 値変更チェック
                            if (this.CustomerCode_tNedit.GetInt() != this._searchRate.CustomerCode)
                            {
                                dispSetStatus = editChgDataChk("得意先コード", this.CustomerCode_tNedit.GetInt(), this._searchRate.CustomerCode);

                                // データ設定
                                DispSetCustomerCode(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("得意先コード");
                            dispSetStatus = this._searchRate.CustomerCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;

                            // データ設定
                            DispSetCustomerCode(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }
                // 値が変更される場合、または、存在チェックがエラーの場合は以下の処理に進まない
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //--------------------
            // 得意先掛率グループ
            //--------------------
            if ((this.CustRateGrpCode_tComboEditor.Enabled == true) && (this.CustRateGrpCode_tComboEditor.Value != null))
            {
                // 条件設定クリア
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
                status = (int)InputChkStatus.NotExist;

                // 条件設定
                inParamList.Add(this._custRateGrpCodeSList);
                inParamList.Add((int)this.CustRateGrpCode_tComboEditor.Value);
                inParamObj = inParamList;

                // 存在チェック
                status = CheckUserGuide(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // 値変更チェック
                            if ((int)this.CustRateGrpCode_tComboEditor.Value != this._searchRate.CustRateGrpCode)
                            {
                                dispSetStatus = editChgDataChk("得意先掛率グループ", this.CustRateGrpCode_tComboEditor.Value.ToString(), this._searchRate.CustRateGrpCode);

                                // データ設定
                                DispSetCustRateGrpCode(dispSetStatus, ref canChangeFocus, outParamObj);

                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("得意先掛率グループ");
                            dispSetStatus = this._searchRate.CustRateGrpCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;

                            // データ設定
                            DispSetCustRateGrpCode(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }
                // 値が変更される場合、または、存在チェックがエラーの場合は以下の処理に進まない
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //----------------
            // 仕入先コード
            //----------------
            if (this.SupplierCd_tNedit.Enabled == true)
            {
                // 条件設定クリア
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
                status = (int)InputChkStatus.NotExist;

                // 条件設定
                inParamObj = this.SupplierCd_tNedit.GetInt();

                // 存在チェック
                status = CheckSupplierCd(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // 値変更チェック
                            if (this.SupplierCd_tNedit.GetInt() != this._searchRate.SupplierCd)
                            {
                                dispSetStatus = editChgDataChk("仕入先コード", this.SupplierCd_tNedit.GetInt(), this._searchRate.SupplierCd);

                                // データ設定
                                DispSetSupplierCd(dispSetStatus, ref canChangeFocus, outParamObj);
                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("仕入先コード");
                            dispSetStatus = this._searchRate.SupplierCd == 0 ? DispSetStatus.Clear : DispSetStatus.Back;

                            // データ設定
                            DispSetSupplierCd(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }
                // 値が変更される場合、または、存在チェックがエラーの場合は以下の処理に進まない
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            //--------------------
            // 仕入先掛率グループ
            //--------------------
            if ((this.SuppRateGrpCode_tComboEditor.Enabled == true) && (this.SuppRateGrpCode_tComboEditor.Value != null))
            {
                // 条件設定クリア
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
                dispSetStatus = DispSetStatus.Back;	// 値が変更されていないという意味合いで使用
                status = (int)InputChkStatus.NotExist;

                // 条件設定
                inParamList.Add(this._suppRateGrpCodeSList);
                inParamList.Add((int)this.SuppRateGrpCode_tComboEditor.Value);
                inParamObj = inParamList;

                // 存在チェック
                status = CheckUserGuide(inParamObj, out outParamObj);
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // 値変更チェック
                            if ((int)this.SuppRateGrpCode_tComboEditor.Value != this._searchRate.SuppRateGrpCode)
                            {
                                dispSetStatus = editChgDataChk("仕入先掛率グループ", this.SuppRateGrpCode_tComboEditor.Value.ToString(), this._searchRate.SuppRateGrpCode);

                                // データ設定
                                DispSetSuppRateGrpCode(dispSetStatus, ref canChangeFocus, outParamObj);

                            }
                            break;
                        }
                    default:
                        {
                            ShowNotFoundErrMsg("仕入先掛率グループ");
                            dispSetStatus = this._searchRate.SuppRateGrpCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;

                            // データ設定
                            DispSetSuppRateGrpCode(dispSetStatus, ref canChangeFocus, outParamObj);
                            break;
                        }
                }
                // 値が変更される場合、または、存在チェックがエラーの場合は以下の処理に進まない
                if ((dispSetStatus != DispSetStatus.Back) || (status != (int)InputChkStatus.Normal))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 掛率項目全体チェック処理
        /// </summary>
        /// <param name="oldSaveFlag">旧掛率データ設定有無（0:設定無し, 1:設定有り）</param>
        /// <param name="oldDataDelFlag">旧掛率データ削除要否（0:否, 1:要）</param>
        /// <returns>チェック結果(true:OK, false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 掛率項目全体に対して過不足が無いがチェックします。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        private bool InpRateDataCheck(ref int oldSaveFlag, ref int oldDataDelFlag)
        {
            oldSaveFlag = 0; // 旧掛率設定無し

            object inParamObj = null;
            object outParamObj = null;
            ArrayList inParamList = null;
            int status = (int)InputChkStatus.InputErr;
			
            //------------------------
            // 条件項目エラーチェック
            //------------------------
            if(InpCondDataCheck() == false)
            {
                return false;
            }
			
            //---------------
            // 新基準価格区分
            //---------------
            if ((this.NewPriceDiv_tComboEditor.Enabled == true) && (this.NewPriceDiv_tComboEditor.Value != null))
            {
                // 条件設定クリア
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();

                // 条件設定
                inParamList.Add(this._priceDivSList);
                inParamList.Add((int)this.NewPriceDiv_tComboEditor.Value);
                inParamObj = inParamList;

                // 存在チェック
                status = CheckUserGuide(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // そのまま進む
                            break;
                        }
                    default:
                        {
                            // 存在しない場合は処理を中断する
                            ShowNotFoundErrMsg("新基準価格区分");
                            return false;
                        }
                }
            }

            //---------------
            // 旧基準価格区分
            //---------------
            if ((this.OldPriceDiv_tComboEditor.Enabled == true) && (this.OldPriceDiv_tComboEditor.Value != null))
            {
                // 条件設定クリア
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();

                // 条件設定
                inParamList.Add(this._priceDivSList);
                inParamList.Add((int)this.OldPriceDiv_tComboEditor.Value);
                inParamObj = inParamList;

                // 存在チェック
                status = CheckUserGuide(inParamObj, out outParamObj); 
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                    case (int)InputChkStatus.NotInput:
                        {
                            // そのまま進む
                            break;
                        }
                    default:
                        {
                            // 存在しない場合は処理を中断する
                            ShowNotFoundErrMsg("旧基準価格区分");
                            return false;
                        }
                }
            }
			
            //----------------
            // 新掛率設定判定
            //----------------
            // 未設定の場合（単価 == 0, 掛率 == 0, 端数処理単位 == 0）
            if ((this.NewPrice_tNedit.GetValue() == 0)
                && (this.NewRate_tNedit.GetValue() == 0)
                && (this.NewUnPrcFracProcUnit_tNedit.GetValue() == 0))
            {
                this.NewPrice_tNedit.Focus();
                ShowInpErrMsg("単価か掛率の何れかを設定してください。（新掛率）");
                return false;
            }
            // 単価設定の場合（単価 > 0）
            if (this.NewPrice_tNedit.GetValue() > 0)
            {
                // 掛率 != 0
                if (this.NewRate_tNedit.GetValue() != 0)
                {
                    this.NewRate_tNedit.Focus();
                    ShowInpErrMsg("掛率が設定されています。（新掛率）");
                    return false;
                }
                // 端数処理単位 != 0
                if (this.NewUnPrcFracProcUnit_tNedit.GetValue() != 0)
                {
                    this.NewUnPrcFracProcUnit_tNedit.Focus();
                    ShowInpErrMsg("端数処理単位が設定されています。（新掛率）");
                    return false;
                }
            }
            // 掛率設定の場合（単価 == 0）
            else
            {
                // 掛率 == 0
                if (this.NewRate_tNedit.GetValue() == 0.00)
                {
                    this.NewRate_tNedit.Focus();
                    ShowInpErrMsg("掛率を設定してください。（新掛率）");
                    return false;
                }
                // 端数処理単位 == 0.00
                if (this.NewUnPrcFracProcUnit_tNedit.GetValue() == 0)
                {
                    this.NewUnPrcFracProcUnit_tNedit.Focus();
                    ShowInpErrMsg("端数処理単位を設定してください。（新掛率）");
                    return false;
                }
            }
			
            //----------------
            // 旧掛率設定判定
            //----------------
            // 未設定の場合（単価 == 0, 掛率 == 0, 端数処理単位 == 0）
            if ((this.OldPrice_tNedit.GetValue() == 0)
                && (this.OldRate_tNedit.GetValue() == 0)
                && (this.OldUnPrcFracProcUnit_tNedit.GetValue() == 0))
            {
                oldSaveFlag = 0; // 旧掛率設定無し

                //------------------------------------------------------------------
                // 元データ有無判定
                //   元データ存在時、画面データが未設定の場合、物理削除データとする
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
                    // 元データ削除処理を行う
                    oldDataDelFlag = 1;	// 削除データ
                }
            }
            else
            {
                // 単価設定の場合（単価 > 0）
                if (this.OldPrice_tNedit.GetValue() > 0)
                {
                    oldSaveFlag = 1; // 旧掛率設定有り

                    // 掛率 != 0
                    if (this.OldRate_tNedit.GetValue() != 0)
                    {
                        this.OldRate_tNedit.Focus();
                        ShowInpErrMsg("掛率が設定されています。（旧掛率）");
                        return false;
                    }
                    // 端数処理単位 != 0
                    if (this.OldUnPrcFracProcUnit_tNedit.GetValue() != 0)
                    {
                        this.OldUnPrcFracProcUnit_tNedit.Focus();
                        ShowInpErrMsg("端数処理単位が設定されています。（旧掛率）");
                        return false;
                    }
                }
                // 掛率設定の場合（単価 == 0）
                else
                {
                    oldSaveFlag = 1; // 旧掛率設定有り

                    // 掛率 > 0 && 端数処理単位 == 0
                    if ((this.OldRate_tNedit.GetValue() > 0)&&(this.OldUnPrcFracProcUnit_tNedit.GetValue() == 0))
                    {
                        this.OldUnPrcFracProcUnit_tNedit.Focus();
                        ShowInpErrMsg("端数処理単位を設定してください。（旧掛率）");
                        return false;
                    }
                    // 掛率 == 0 && 端数処理単位 > 0
                    if ((this.OldRate_tNedit.GetValue() == 0)&&(this.OldUnPrcFracProcUnit_tNedit.GetValue() > 0))
                    {
                        this.OldRate_tNedit.Focus();
                        ShowInpErrMsg("掛率を設定してください。（旧掛率）");
                        return false;
                    }
                }
            }
						
            //----------------
            // 掛率開始日判定
            //----------------
            // 条件設定
            inParamObj = null;
            outParamObj = null;
            inParamList = new ArrayList();

            inParamList.Add(this.NewRateStartDate_tDateEdit.GetDateYear());
            inParamList.Add(this.NewRateStartDate_tDateEdit.GetDateMonth());
            inParamList.Add(this.NewRateStartDate_tDateEdit.GetDateDay());
            inParamObj = inParamList;

            // 新掛率開始日エラーチェック
            status = CheckRateStartDate(inParamObj, out outParamObj);
            switch(status)
            {
                case (int)InputChkStatus.Normal:
                    {
                        // 何もしない
                        break;
                    }
                case (int)InputChkStatus.NotInput:
                    {
                        // 未入力
                        this.NewRateStartDate_tDateEdit.Focus();
                        ShowInpErrMsg("新掛率開始日が未入力です。");
                        return false;
                    }
                case (int)InputChkStatus.InputErr:
                    {
                        // 不正データ
                        this.NewRateStartDate_tDateEdit.Focus();
                        ShowInpErrMsg("新掛率開始日のデータが不正です。");
                        return false;
                    }
                default:
                    {
                        // その他エラー
                        return false;
                    }
            }
						
            // 旧掛率開始日未入力判定
            if (oldSaveFlag == 1)
            {
                // 条件設定
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();
				
                inParamList.Add(this.OldRateStartDate_tDateEdit.GetDateYear());
                inParamList.Add(this.OldRateStartDate_tDateEdit.GetDateMonth());
                inParamList.Add(this.OldRateStartDate_tDateEdit.GetDateDay());
                inParamObj = inParamList;
				
                // 新掛率開始日エラーチェック
                status = CheckRateStartDate(inParamObj, out outParamObj);
                switch (status)
                {
                    case (int)InputChkStatus.Normal:
                        {
                            // 何もしない
                            break;
                        }
                    case (int)InputChkStatus.NotInput:
                        {
                            // 未入力
                            this.OldRateStartDate_tDateEdit.Focus();
                            ShowInpErrMsg("旧掛率開始日が未入力です。");
                            return false;
                        }
                    case (int)InputChkStatus.InputErr:
                        {
                            // 不正データ
                            this.OldRateStartDate_tDateEdit.Focus();
                            ShowInpErrMsg("旧掛率開始日のデータが不正です。");
                            return false;
                        }
                    default:
                        {
                            // その他エラー
                            return false;
                        }
                }
            }
			
            // 掛率開始日判定
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
        /// 入力エラーメッセージ出力処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : 入力エラーメッセージを出力します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.12</br>
        /// </remarks>
        private void ShowInpErrMsg(string errMsg)
        {
            DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_INFO,		                  // エラーレベル
                ASSEMBLY_ID, 			                              // アセンブリＩＤまたはクラスＩＤ
                errMsg,									              // 表示するメッセージ
                0, 					                                  // ステータス値
                MessageBoxButtons.OK);			                      // 表示するボタン
        }

        /// <summary>
        /// データ無しエラーメッセージ出力処理
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <remarks>
        /// <br>Note       : データ無しのエラーメッセージを出力します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.12</br>
        /// </remarks>
        private void ShowNotFoundErrMsg(string errMsg)
        {
            _stringBuilder.Remove(0, _stringBuilder.Length);
            _stringBuilder.Append("指定された条件で、");
            _stringBuilder.Append(errMsg);
            _stringBuilder.Append("は存在しませんでした。");
            errMsg = _stringBuilder.ToString();
			
            DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_INFO,		                  // エラーレベル
                ASSEMBLY_ID, 			                              // アセンブリＩＤまたはクラスＩＤ
                errMsg,									              // 表示するメッセージ
                0, 					                                  // ステータス値
                MessageBoxButtons.OK);			                      // 表示するボタン
        }
		
        /// <summary>
        /// 変更確認メッセージ出力処理
        /// </summary>
        /// <param name="infoMsg">メッセージ</param>
        /// <param name="emErrorLevel">エラーレベル</param>
        /// <remarks>
        /// <br>Note       : 変更確認メッセージを出力します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.25</br>
        /// </remarks>
        private bool ShowConfirmMsg(string infoMsg, emErrorLevel emErrorLevel)
        {
            bool retBool = false;
			
            // 確認メッセージ出力
            DialogResult res = TMsgDisp.Show(
                this, 								// 親ウィンドウフォーム
                emErrorLevel.ERR_LEVEL_INFO,		// エラーレベル
                ASSEMBLY_ID,   						// アセンブリＩＤまたはクラスＩＤ
                infoMsg,							// 表示するメッセージ
                (int)emErrorLevel,					// ステータス値
                MessageBoxButtons.YesNo, 			// 表示するボタン
                MessageBoxDefaultButton.Button2);	// 初期表示ボタン
			
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
        /// NULL文字変換処理
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <returns>string型データ</returns>
        /// <remarks>
        /// <br>Note       : NULL文字が含まれている場合ダブルクォートへ変換する</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
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
        /// NULL文字変換処理
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <returns>int型データ</returns>
        /// <remarks>
        /// <br>Note       : NULL文字が含まれている場合「0」へ変換する</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
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
        /// NULL文字変換処理
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <returns>double型データ</returns>
        /// <remarks>
        /// <br>Note       : NULL文字が含まれている場合「0」へ変換する</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
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
        /// 検索条件画面情報掛率クラス格納処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報から掛率オブジェクトに検索条件を格納します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        private void DispToRateSearch()
        {
            //----- ueno add ---------- start 2008.03.31
            // 拠点コードゼロ埋め
            this.RateSectionCode_tEdit.Text = GetZeroPaddedTextProc(this.RateSectionCode_tEdit.Text, this.RateSectionCode_tEdit.ExtEdit.Column);
            //----- ueno add ---------- end 2008.03.31

            this._searchRate.EnterpriseCode			= this._enterpriseCode;									// 企業コード
            this._searchRate.SectionCode			= this.RateSectionCode_tEdit.Text;							// 拠点コード
            this._searchRate.UnitPriceKind			= NullChgStr(this.UnitPriceKind_tComboEditor.Value);	// 単価種類
            this._searchRate.RateSettingDivide		= this.RateSettingDivide_tEdit.Text;					// 掛率設定区分
            this._searchRate.RateMngGoodsCd			= this.RateMngGoodsCd_tEdit.Text;						// 掛率設定区分（商品）
            this._searchRate.RateMngGoodsNm			= this.RateMngGoodsNm_tEdit.Text;						// 掛率設定名称（商品）
            this._searchRate.RateMngCustCd			= this.RateMngCustCd_tEdit.Text;						// 掛率設定区分（得意先）
            this._searchRate.RateMngCustNm			= this.RateMngCustNm_tEdit.Text;						// 掛率設定名称（得意先）
			
            // 単品設定の場合
            if (this.UnitPriceKindWay_tComboEditor.SelectedIndex == 0)
            {
                this._searchRate.GoodsMakerCd		= this.GoodsMakerCd_tNedit.GetInt();					// 商品メーカーコード（単品）
            }
            // 商品Ｇ設定の場合
            else
            {
                this._searchRate.GoodsMakerCd		= this.GoodsMakerCd_Grp_tNedit.GetInt();				// 商品メーカーコード（商品Ｇ）
            }
			
            this._searchRate.GoodsNo				= this.GoodsNoCd_tEdit.Text;									// 商品番号
            this._searchRate.GoodsRateRank			= this.GoodsRateRankCd_Grp_tEdit.Text;							// 商品掛率ランク
            this._searchRate.LargeGoodsGanreCode	= this.LargeGoodsGanreCode_Grp_tEdit.Text;						// 商品区分グループコード
            this._searchRate.MediumGoodsGanreCode	= this.MediumGoodsGanreCode_Grp_tEdit.Text;						// 商品区分コード
            this._searchRate.DetailGoodsGanreCode	= this.DetailGoodsGanreCode_Grp_tEdit.Text;						// 商品区分詳細コード
            this._searchRate.EnterpriseGanreCode	= NullChgInt(this.EnterpriseGanreCode_Grp_tComboEditor.Value);	// 自社分類コード
            this._searchRate.BLGoodsCode			= this.BLGoodsCode_Grp_tNedit.GetInt();							// ＢＬ商品コード
            this._searchRate.CustomerCode			= this.CustomerCode_tNedit.GetInt();							// 得意先コード
            this._searchRate.CustRateGrpCode		= NullChgInt(this.CustRateGrpCode_tComboEditor.Value);			// 得意先掛率Ｇコード
            this._searchRate.SupplierCd				= this.SupplierCd_tNedit.GetInt();								// 仕入先コード
            this._searchRate.SuppRateGrpCode		= NullChgInt(this.SuppRateGrpCode_tComboEditor.Value);			// 仕入先掛率Ｇコード
        }

        /// <summary>
        /// 検索条件結果画面情報設定処理
        /// </summary>
        /// <param name="dr">掛率データテーブル行</param>
        /// <returns>結果（true:画面設定正常, false:画面設定エラー）</returns>
        /// <remarks>
        /// <br>Note       : 掛率データテーブルから画面項目にデータを設定します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        private int DataRowToScreen(DataRow dr)
        {
            object inParamObj = null;
            object outParamObj = null;
            ArrayList inParamList = null;

            //------------
            // 新掛率設定
            //------------
            if (string.Equals(NullChgStr(dr[RateAcs.OLDNEWDIVCD]), OLDNEWDIVCD_NEW) == true)
            {
                //----- 新基準価格区分存在チェック -----//
                // 条件設定クリア
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();

                // 条件設定
                inParamList.Add(this._priceDivSList);
                inParamList.Add((int)dr[RateAcs.PRICEDIV]);
                inParamObj = inParamList;

                // 存在チェック
                if (CheckUserGuide(inParamObj, out outParamObj) == (int)InputChkStatus.Normal)
                {
                    this.NewPriceDiv_tComboEditor.Value = dr[RateAcs.PRICEDIV];
                }
                else
                {
                    // 存在しない場合は処理を中断する
                    ShowInpErrMsg("新基準価格区分が存在しません。\n基準価格区分の登録をお願いします。");

                    // 検索条件入力状態にする
                    // 全体入力コントロール
                    SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.InputCondition.GetHashCode());
                    this._AllCtrlInputStatus = AllCtrlInputStatus.InputCondition;

                    // モードラベル
                    this._modeFlag = ModeFlag.None;	// 未確定

                    // 検索結果データクリア（前回の分を考慮）
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
				
                // 数値項目最適化
                NumFormatSet(ref this.NewPrice_tNedit);
                NumFormatSet(ref this.NewRate_tNedit);
                NumFormatSet(ref this.NewUnPrcFracProcUnit_tNedit);
            }
			
            //------------
            // 旧掛率設定
            //------------
            else
            {
                //----- 旧基準価格区分存在チェック -----//
                // 条件設定クリア
                inParamObj = null;
                outParamObj = null;
                inParamList = new ArrayList();

                // 条件設定
                inParamList.Add(this._priceDivSList);
                inParamList.Add((int)dr[RateAcs.PRICEDIV]);
                inParamObj = inParamList;

                // 存在チェック
                if (CheckUserGuide(inParamObj, out outParamObj) == (int)InputChkStatus.Normal)
                {
                    this.OldPriceDiv_tComboEditor.Value = dr[RateAcs.PRICEDIV];
                }
                else
                {
                    // 存在しない場合は処理を中断する
                    ShowInpErrMsg("旧基準価格区分が存在しません。\n基準価格区分の登録をお願いします。");

                    // 検索条件入力状態にする
                    // 全体入力コントロール
                    SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.InputCondition.GetHashCode());
                    this._AllCtrlInputStatus = AllCtrlInputStatus.InputCondition;

                    // モードラベル
                    this._modeFlag = ModeFlag.None;	// 未確定

                    // 検索結果データクリア（前回の分を考慮）
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

                // 数値項目最適化
                NumFormatSet(ref this.OldPrice_tNedit);
                NumFormatSet(ref this.OldRate_tNedit);
                NumFormatSet(ref this.OldUnPrcFracProcUnit_tNedit);
            }
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// 検索条件画面情報掛率クラス格納処理（単価算出区分チェック用）
        /// </summary>
        /// <param name="rate">検索条件</param>
        /// <param name="oldNewDivCd">新旧区分</param>
        /// <remarks>
        /// <br>Note       : 画面情報から掛率オブジェクトに検索条件を格納します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.12.03</br>
        /// </remarks>
        private void RateSearchUnitPriceKind(ref Rate rate, string oldNewDivCd)
        {
            rate.EnterpriseCode = this._searchRate.EnterpriseCode;				// 企業コード
            rate.SectionCode = this._searchRate.SectionCode;					// 拠点コード
            rate.OldNewDivCd = oldNewDivCd;										// 新旧区分
            rate.UnitPriceKind = "4";											// 単価種類（定価）
            rate.RateSettingDivide = this._searchRate.RateSettingDivide;		// 掛率設定区分
            rate.RateMngGoodsCd = this._searchRate.RateMngGoodsCd;				// 掛率設定区分（商品）
            rate.RateMngCustNm = this._searchRate.RateMngGoodsNm;				// 掛率設定名称（商品）
            rate.RateMngCustCd = this._searchRate.RateMngCustCd;				// 掛率設定区分（得意先）
            rate.RateMngCustNm = this._searchRate.RateMngCustNm;				// 掛率設定名称（得意先）
            rate.GoodsMakerCd = this._searchRate.GoodsMakerCd;					// 商品メーカーコード（商品Ｇ）

            rate.GoodsNo = this._searchRate.GoodsNo;							// 商品番号
            rate.GoodsRateRank = this._searchRate.GoodsRateRank;				// 商品掛率ランク
            rate.LargeGoodsGanreCode = this._searchRate.LargeGoodsGanreCode;	// 商品区分グループコード
            rate.MediumGoodsGanreCode = this._searchRate.MediumGoodsGanreCode;	// 商品区分コード
            rate.DetailGoodsGanreCode = this._searchRate.DetailGoodsGanreCode;	// 商品区分詳細コード
            rate.EnterpriseGanreCode = this._searchRate.EnterpriseGanreCode;	// 自社分類コード
            rate.BLGoodsCode = this._searchRate.BLGoodsCode;					// ＢＬ商品コード
            rate.CustomerCode = this._searchRate.CustomerCode;					// 得意先コード
            rate.CustRateGrpCode = this._searchRate.CustRateGrpCode;			// 得意先掛率Ｇコード
            rate.SupplierCd = this._searchRate.SupplierCd;						// 仕入先コード
            rate.SuppRateGrpCode = this._searchRate.SuppRateGrpCode;			// 仕入先掛率Ｇコード
        }

        /// <summary>
        /// 単価算出区分チェック処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 単価算出区分チェックを行います。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.12.03</br>
        /// </remarks>
        private void UnPrcCalcDivCheck()
        {
            //=======================================================================================
            // 単価算出区分チェック（単価種類=売上単価時）
            //   掛率設定区分が同じで単価種類=定価のレコードが既に存在している場合、
            //   単価算出区分=1:基準価格x掛率は設定不可とする。
            //   例. 商品Aの価格ﾏｽﾀの定価:\8,000
            //     ①定価     単品設定 A3 ﾒｰｶｰ+商品+得意先 商品A ﾕｰｻﾞｰ定価\10,000
            //     ②売上単価 単品設定 A3 ﾒｰｶｰ+商品+得意先 商品A 単価算出区分1:基準価格x掛率 掛率80%
            //       
            //       ②の基準価格は価格ﾏｽﾀの\8,000が適用され、\8,000 x 80% = \6,400
            //       正しくは、ﾕｰｻﾞｰ定価の\10,000を適用し、\10,000 x 80% = \8,000 となる
            //=======================================================================================

            // 単価算出区分が売上単価の場合
            if (NullChgInt(this.UnitPriceKind_tComboEditor.Value) == 1)
            {
                Rate rate = new Rate();

                foreach (DictionaryEntry de in Rate._OldNewDivCdTable)
                {
                    // 検索データ設定
                    RateSearchUnitPriceKind(ref rate, NullChgStr(de.Key));

                    int ret = this._rateAcs.Read(ref rate);
                    string wkStr = "";

                    // 定価が存在した場合
                    if (ret == 0)
                    {
                        // 1:基準価格×掛率以外
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
                        wkStr = "";	// クリア

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
        /// 数値形式設定処理
        /// </summary>
        /// <param name="tNedit">数値データ</param>
        /// <remarks>
        /// <br>Note       : 数値形式を設定します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.11.1</br>
        /// </remarks>
        private void NumFormatSet(ref TNedit tNedit)
        {
            double value = tNedit.GetValue();
            tNedit.Text = value.ToString("###,#0.00");
        }

        /// <summary>
        /// 掛率マスタ検索処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタから該当データを検索します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        private int RateSearch()
        {
            //-----------------------------------------------------------
            // データの検索及び、ハッシュテーブルに検索結果格納
            //  （this._dataTableRate, this._rateSrchRsltHashListに格納）
            //-----------------------------------------------------------
            int status = SrchRsltDataSet();

            if (status != 0)
            {
                return status;
            }

            string searchStr;
            //--------------------------------------------------------
            // 取得データを画面項目に設定
            //		ロット数が「0」のレコード（新旧掛率データ）
            //--------------------------------------------------------
            searchStr = "";
            _stringBuilder.Remove(0, _stringBuilder.Length);
            _stringBuilder.Append(RateAcs.LOTCOUNT);
            _stringBuilder.Append(" = '0'");
            searchStr = _stringBuilder.ToString();
			
            DataRow[] foundRateRow = this._dataTableRate.Select(searchStr);
            
            // ロットテーブルクリア
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
            // 新規モード
            //------------
            if (foundRateRow.Length == 0)
            {
                this._modeFlag = ModeFlag.New;	// 新規
                this.Mode_Label.Text = INSERT_MODE;
				
                // 全体入力コントロール
                SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.SearchNew.GetHashCode());

                this._AllCtrlInputStatus = AllCtrlInputStatus.SearchNew;

                // 単価算出区分チェック
                UnPrcCalcDivCheck();

                // ロット画面設定
                SetInitialLotTblUnitPrcCalcDiv(ref this._dataTableLotNew, this._unitPrcCalcDivNewFlag);
                SetInitialLotTblUnitPrcCalcDiv(ref this._dataTableLotOld, this._unitPrcCalcDivOldFlag);
            }
            else
            {
                //----------------
                // 更新モード
                //----------------
                if (NullChgInt(foundRateRow[0][RateAcs.LOGICALDELETECODE]) == 0)
                {
                    this._modeFlag = ModeFlag.Update;	// 更新
                    this.Mode_Label.Text = UPDATE_MODE;
					
                    // 全体入力コントロール
                    SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.SearchUpdate.GetHashCode());

                    this._AllCtrlInputStatus = AllCtrlInputStatus.SearchUpdate;
                }
                //----------------
                // 削除モード
                //----------------
                else
                {
                    this._modeFlag = ModeFlag.Delete;	// 削除
                    this.Mode_Label.Text = DELETE_MODE;

                    // 全体入力コントロール
                    SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.SearchDelete.GetHashCode());

                    this._AllCtrlInputStatus = AllCtrlInputStatus.SearchDelete;
                }

                // 単価算出区分チェック
                UnPrcCalcDivCheck();

                // ロット画面設定
                SetInitialLotTblUnitPrcCalcDiv(ref this._dataTableLotNew,  this._unitPrcCalcDivNewFlag);
                SetInitialLotTblUnitPrcCalcDiv(ref this._dataTableLotOld,  this._unitPrcCalcDivOldFlag);

                //----------------
                // 画面データ設定
                //----------------
                foreach (DataRow fRow in foundRateRow)
                {
                    // 画面項目に新旧データを設定
                    status = DataRowToScreen(fRow);
					
                    if(status != 0)
                    {
                        return status;
                    }
                }
				
                // ロット有無判定（ロット数「0」以外が存在するか）
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

                    int lotCnt = 0;	// ロット数カウント

                    if (foundLotRow.Length > 0)
                    {
                        foreach (DataRow lotRow in foundLotRow)
                        {
                            // 掛率ロットデータ構築
                            //     ここでthis._dataTableLotNew, this._dataTableLotOldにデータ格納）
                            SetLotTblList(lotRow, NullChgStr(de.Value), lotCnt);
                            lotCnt++;
                        }
						
                        // 新旧ロットデータクローンへ検索結果データをコピー
                        this._dataTableLotNewClone = this._dataTableLotNew.Copy();
                        this._dataTableLotOldClone = this._dataTableLotOld.Copy();
                    }

                    if ((this.NewRateStartDate_tDateEdit.GetDateYear() != 0)
                        && (this.NewRateStartDate_tDateEdit.GetDateMonth() != 0)
                        && (this.NewRateStartDate_tDateEdit.GetDateDay() != 0))
                    {	
                        // 新ロット開始日設定
                        this.LotNewRateStartDate_tDateEdit.SetDateTime(this.NewRateStartDate_tDateEdit.GetDateTime());
                    }
                    if ((this.OldRateStartDate_tDateEdit.GetDateYear() != 0)
                        && (this.OldRateStartDate_tDateEdit.GetDateMonth() != 0)
                        && (this.OldRateStartDate_tDateEdit.GetDateDay() != 0))
                    {
                        // 旧ロット開始日設定
                        this.LotOldRateStartDate_tDateEdit.SetDateTime(this.OldRateStartDate_tDateEdit.GetDateTime());
                    }
                }
            }
            return 0;
        }

        /// <summary>
        /// 検索結果データ格納
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタから検索した結果を全て格納します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.10.31</br>
        /// </remarks>
        private int SrchRsltDataSet()
        {
            string message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            // 検索結果データクリア（前回の分を考慮）
            SrchRsltDataClear();

            // 掛率マスタ検索用データ格納
            DispToRateSearch();

            //----------------
            // 掛率マスタ検索
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
                        // サーチ
                        TMsgDisp.Show(
                                this, 								// 親ウィンドウフォーム
                                emErrorLevel.ERR_LEVEL_STOP,        // エラーレベル
                                ASSEMBLY_ID,                        // アセンブリＩＤまたはクラスＩＤ
                                this.Text,			                // プログラム名称
                                "RateSearch", 						// 処理名称
                                TMsgDisp.OPE_GET,                   // オペレーション
                                ERR_READ_MSG,					    // 表示するメッセージ
                                status,                             // ステータス値
                                this._rateAcs,		    	        // エラーが発生したオブジェクト
                                MessageBoxButtons.OK,               // 表示するボタン
                                MessageBoxDefaultButton.Button1);   // 初期表示ボタン
						
                        // 以降処理しない
                        return status;
                    }
            }

            if (this._dataTableRate.Rows != null)
            {
                string hashKey = "";
                foreach (DataRow row in this._dataTableRate.Rows)
                {
                    // 検索結果をデータロウから掛率クラスへ変換する
                    Rate wkRate = null;
                    CopyToRateFromRow(ref wkRate, row);
					
                    // ハッシュキー作成
                    hashKey = wkRate.OldNewDivCd + wkRate.LotCount.ToString("000000000.00");

                    // 検索結果を格納
                    if (this._rateSrchRsltHashList.ContainsKey(hashKey) == false)
                    {
                        this._rateSrchRsltHashList.Add(hashKey, wkRate);
                    }
					
                    // 比較用クローンにも格納
                    Rate wkRateClone = wkRate.Clone();

                    if (this._rateSrchRsltHashListClone.ContainsKey(hashKey) == false)
                    {
                        this._rateSrchRsltHashListClone.Add(hashKey, wkRateClone);
                    }
                }
				
                // 新旧掛率設定はデータが無くても空で作成しておく
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
        /// 検索結果データクリア格納
        /// </summary>
        /// <remarks>
        /// <br>Note       : 掛率マスタから検索した結果を全てクリアします。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.11.2</br>
        /// </remarks>
        private void SrchRsltDataClear()
        {
            //------------
            // 初期化処理
            //------------
            // 前回の検索結果データが残っている場合削除
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
			
            // 単価算出区分フラグ初期化
            this._unitPrcCalcDivNewFlag = true;
			
            // 新掛率設定項目
            this.NewRateStartDate_tDateEdit.SetToday();													// 掛率開始日
            this.NewPrice_tNedit.Clear();																// 単価
            this.NewRate_tNedit.Clear();																// 掛率
            this.NewUnPrcFracProcUnit_tNedit.Clear();													// 単価端数処理単位
            this.NewPriceDiv_tComboEditor.Value				= this._priceDivSList.GetKey(0);			// 新基準価格区分
            this.NewUnPrcCalcDiv_tComboEditor.Value			= Rate._unPrcCalcDivTable.GetKey(0);		// 新単価算出区分
            this.NewUnPrcFracProcDiv_tComboEditor.Value		= Rate._unPrcFracProcDivTable.GetKey(0);	// 新単価端数処理区分
            this.NewBargainCd_tComboEditor.Value			= this._bargainCdSList.GetKey(0);			// 新特売区分
			
            // 旧掛率設定項目
            this.OldRateStartDate_tDateEdit.Clear();													// 掛率開始日
            this.OldPrice_tNedit.Clear();																// 単価
            this.OldRate_tNedit.Clear();																// 掛率
            this.OldUnPrcFracProcUnit_tNedit.Clear();													// 単価端数処理単位
            this.OldPriceDiv_tComboEditor.Value				= this._priceDivSList.GetKey(0);			// 旧基準価格区分
            this.OldUnPrcCalcDiv_tComboEditor.Value			= Rate._unPrcCalcDivTable.GetKey(0);		// 旧単価算出区分
            this.OldUnPrcFracProcDiv_tComboEditor.Value		= Rate._unPrcFracProcDivTable.GetKey(0);	// 旧単価端数処理区分
            this.OldBargainCd_tComboEditor.Value			= this._bargainCdSList.GetKey(0);			// 旧特売区分
        }

        /// <summary>
        /// 画面情報掛率クラス格納処理
        /// </summary>
        /// <param name="rate">掛率オブジェクト</param>
        /// <param name="oldNewDivCd">新旧区分</param>
        /// <remarks>
        /// <br>Note       : 画面情報から掛率オブジェクトにデータを格納します。
        ///					 画面項目以外は検索結果データを設定します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        private void DispToRate(out Rate rate, string oldNewDivCd)
        {
            rate = new Rate();
			
            //--------
            // ヘッダ
            //--------
            // モード判定
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
            // 検索条件
            //----------
            //----- ueno add ---------- start 2008.03.31
            // 拠点コードゼロ埋め
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
			
            // 検索データ加工(単価種類＋掛率設定区分＋新旧区分)
            string wkStr = "";
            _stringBuilder.Remove(0, _stringBuilder.Length);
            _stringBuilder.Append(rate.UnitPriceKind);
            _stringBuilder.Append(rate.RateSettingDivide);
            _stringBuilder.Append(rate.OldNewDivCd);
            wkStr = _stringBuilder.ToString();
			
            rate.UnitRateSetDivCd = wkStr;
			
            // 単品設定の場合
            if (this.UnitPriceKindWay_tComboEditor.SelectedIndex == 0)
            {
                rate.GoodsMakerCd			= this.GoodsMakerCd_tNedit.GetInt();
                rate.GoodsNo				= this.GoodsNoCd_tEdit.Text.Trim();
            }
            // 商品グループ設定の場合
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
            // 検索結果
            //----------
            // 新掛率設定
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
            // 旧掛率設定
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
        /// データロウ⇒掛率クラス格納処理
        /// </summary>
        /// <param name="rate">掛率オブジェクト</param>
        /// <param name="dr">データロウ</param>
        /// <remarks>
        /// <br>Note       : 掛率データテーブルの情報を掛率オブジェクトに格納します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
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
        /// 保存処理
        /// </summary>
        /// <param name="oldSaveFlag">旧掛率データ設定有無（0:設定無し, 1:設定有り）</param>
        /// <returns>登録結果（true:OK／false:NG）</returns>
        /// <remarks>
        /// <br>Note		: 画面情報の保存処理を行います。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.10.15</br>
        /// </remarks>
        private bool SaveProc(ref int oldSaveFlag)
        {
            string message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList rateList = new ArrayList();
            Rate rate = null;
            ArrayList diffList = null;	// 項目比較用
			
            //--------------------
            // 新旧掛率データ設定
            //--------------------
            foreach (DictionaryEntry de in Rate._OldNewDivCdTable)
            {
                // 書き込みデータ設定（0:新, 1:旧）
                DispToRate(out rate, NullChgStr(de.Value));

                // 検索キー設定
                string hashKey = de.Value.ToString() + "000000000.00";

                //-------------------------------------------------------------
                // 新規データの場合（検索結果リストクローンが設定無しの場合））
                //     項目比較無し, ロットデータ更新無し, 登録のみ
                //-------------------------------------------------------------
                if (this._rateSrchRsltHashListClone.ContainsKey(hashKey) == false)
                {
                    // 新掛率、または、旧掛率で保存データ有りの場合
                    if ((NullChgInt(de.Key) == 0)||((NullChgInt(de.Key) == 1)&&(oldSaveFlag == 1)))
                    {
                        rateList.Add(rate);
                    }
                }
                //--------------------------------------------------
                // 更新データの場合
                //     項目比較有り, ロットデータ更新有り, 登録有り
                //--------------------------------------------------
                else
                {
                    // 項目比較
                    diffList = null;
					
                    // 検索結果
                    Rate rateWkClone = (Rate)this._rateSrchRsltHashListClone[hashKey];

                    diffList = rate.Compare(rateWkClone);
					
                    // 項目変更有り
                    if (diffList.Count > 0)
                    {
                        // 新掛率、または、旧掛率で保存データ有りの場合
                        if ((NullChgInt(de.Key) == 0) || ((NullChgInt(de.Key) == 1) && (oldSaveFlag == 1)))
                        {
                            // 掛率データ設定
                            rateList.Add(rate);

                            // 掛率開始日が変更されている場合
                            if (diffList.Contains("RateStartDate") == true)
                            {
                                foreach (DataRow dr in this._dataTableRate.Rows)
                                {
                                    if ((NullChgDbl(dr[RateAcs.LOTCOUNT]) > 1)
                                        && (string.Equals(NullChgStr(dr[RateAcs.OLDNEWDIVCD]), de.Value.ToString()) == true))
                                    {
                                        // ロットデータ更新
                                        CopyToRateFromRow(ref rate, dr);
										
                                        // ロット掛率開始日更新
                                        // 新掛率設定
                                        if (string.Equals(NullChgStr(de.Value), OLDNEWDIVCD_NEW) == true)
                                        {
                                            rate.RateStartDate = this.NewRateStartDate_tDateEdit.GetDateTime();
                                        }
                                        // 旧掛率設定
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

            // 書き込み
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
                        TMsgDisp.Show(this,                                 // 親ウィンドウフォーム
                                       emErrLvl,                            // エラーレベル
                                       ASSEMBLY_ID,                         // アセンブリＩＤまたはクラスＩＤ
                                       this.Text, 						    // プログラム名称
                                       "SaveProc", 							// 処理名称
                                       TMsgDisp.OPE_UPDATE, 				// オペレーション
                                       message,                             // 表示するメッセージ
                                       status,  							// ステータス値
                                       this._rateAcs,			            // エラーが発生したオブジェクト
                                       MessageBoxButtons.OK,                // 表示するボタン
                                       MessageBoxDefaultButton.Button1);	// 初期選択ボタン
                        return false;
                    }
					
                    // 保存メッセージ
                    //----- ueno upd ---------- start 2008.02.07
                    //TMsgDisp.Show(this,							// 親ウィンドウフォーム
                    //    emErrorLevel.ERR_LEVEL_INFO,			// エラーレベル
                    //    ASSEMBLY_ID,							// アセンブリID
                    //    SAV_INFO_MSG,							// 表示するメッセージ
                    //    0,										// ステータス値
                    //    MessageBoxButtons.OK);					// 表示するボタン

                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);
                    //----- ueno upd ---------- end 2008.02.07
					
                    // 再読み込み
                    RateSearch();
                }
            }
            return true;
        }
		
        /// <summary>
        /// 掛率マスタ設定 論理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタ設定対象レコードをマスタから論理削除します。
        ///					 新旧掛率及び、紐つくロット全てを論理削除します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        private int LogicalDeleteRate()
        {
            string message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			
            ArrayList rateList = new ArrayList();
            Rate rate = null;
			
            // 検索ボタン押下時に読み込んだデータを全て設定
            foreach(DataRow dr in this._dataTableRate.Rows)
            {
                // 論理削除フラグが0のデータ
                if (NullChgInt(dr[RateAcs.LOGICALDELETECODE]) == 0)
                {
                    CopyToRateFromRow(ref rate, dr);
                    rateList.Add(rate);
                }
            }

            // 論理削除
            status = this._rateAcs.LogicalDelete(ref rateList, out message);
			
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 再読み込み
                        RateSearch();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,						// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,		// エラーレベル
                            ASSEMBLY_ID,						// アセンブリID
                            this.Text,							// プログラム名称
                            "LogicalDeleteRate",				// 処理名称
                            TMsgDisp.OPE_HIDE,					// オペレーション
                            ERR_LRDEL_MSG,					    // 表示するメッセージ
                            status,								// ステータス値
                            this._rateAcs,						// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// 掛率マスタ設定 物理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタ設定対象レコードをマスタから物理削除します。
        ///					 新旧掛率及び、紐つくロット全てを物理削除します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        private int PhysicalDeleteRate()
        {
            string message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList rateList = new ArrayList();
            Rate rate = null;

            // 検索ボタン押下時に読み込んだデータを全て設定
            foreach (DataRow dr in this._dataTableRate.Rows)
            {
                // 論理削除フラグが1のデータ
                if(NullChgInt(dr[RateAcs.LOGICALDELETECODE]) == 1)
                {
                    CopyToRateFromRow(ref rate, dr);
                    rateList.Add(rate);
                }
            }
			
            // 物理削除
            status = this._rateAcs.Delete(ref rateList, out message);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 検索時のデータテーブルレコード削除
                        this._dataTableRate.Rows.Clear();
						
                        // 検索結果格納ハッシュテーブルレコード削除
                        this._rateSrchRsltHashList.Clear();

                        // 検索結果データクリア（前回の分を考慮）
                        SrchRsltDataClear();
						
                        // 掛率マスタ検索用データ格納
                        DispToRateSearch();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,						// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,		// エラーレベル
                            ASSEMBLY_ID,						// アセンブリID
                            this.Text,							// プログラム名称
                            "PhysicalDeleteRate",				// 処理名称
                            TMsgDisp.OPE_HIDE,					// オペレーション
                            ERR_PRDEL_MSG,					    // 表示するメッセージ
                            status,								// ステータス値
                            this._rateAcs,						// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// 旧掛率マスタ設定 物理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 旧掛率マスタ設定対象レコードをマスタから物理削除します。
        ///					 旧掛率及び、紐つくロット全てを物理削除します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.11.05</br>
        /// </remarks>
        private int PhysicalDeleteOldRate()
        {
            string message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList rateList = new ArrayList();
            Rate rate = null;
			
            // 旧掛率関連データを全て取得
            string searchStr = "";
            _stringBuilder.Remove(0, _stringBuilder.Length);
            _stringBuilder.Append(RateAcs.OLDNEWDIVCD);
            _stringBuilder.Append(" = '1'");
            searchStr = _stringBuilder.ToString();
			
            DataRow[] foundRateRow = this._dataTableRate.Select(searchStr);
			
            // 旧掛率データ設定
            foreach (DataRow fRow in foundRateRow)
            {
                CopyToRateFromRow(ref rate, fRow);
                rateList.Add(rate);
            }
			
            // 物理削除
            status = this._rateAcs.Delete(ref rateList, out message);
			
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        //----- ueno add ---------- start 2008.02.07
                        // 物理削除メッセージ
                        TMsgDisp.Show(this,							// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO,			// エラーレベル
                            ASSEMBLY_ID,							// アセンブリID
                            PHY_OLDDEL_INFO_MSG,					// 表示するメッセージ
                            0,										// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン
                        //----- ueno add ---------- end 2008.02.07

                        // 検索時のデータテーブルレコード削除
                        this._dataTableRate.Rows.Clear();
						
                        // 検索結果格納ハッシュテーブルレコード削除
                        this._rateSrchRsltHashList.Clear();
						
                        // 再読み込み
                        RateSearch();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,						// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,		// エラーレベル
                            ASSEMBLY_ID,						// アセンブリID
                            this.Text,							// プログラム名称
                            "PhysicalDeleteRate",				// 処理名称
                            TMsgDisp.OPE_HIDE,					// オペレーション
                            ERR_PRDEL_MSG,					    // 表示するメッセージ
                            status,								// ステータス値
                            this._rateAcs,						// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }
            return status;
        }

        /// <summary>
        /// 掛率マスタ設定 復活処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタ設定対象レコードをマスタから復活します。
        ///					 新旧掛率及び、紐つくロット全てを復活します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        private int ReviveRate()
        {
            string message = "";
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList rateList = new ArrayList();
            Rate rate = null;

            // 検索ボタン押下時に読み込んだデータを全て設定
            foreach (DataRow dr in this._dataTableRate.Rows)
            {
                // 論理削除フラグが1のデータ
                if (NullChgInt(dr[RateAcs.LOGICALDELETECODE]) == 1)
                {
                    CopyToRateFromRow(ref rate, dr);
                    rateList.Add(rate);
                }
            }

            // 復活
            status = this._rateAcs.Revival(ref rateList, out message);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        // 再読み込み
                        RateSearch();
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 排他処理
                        ExclusiveTransaction(status);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(this,						// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,		// エラーレベル
                            ASSEMBLY_ID,						// アセンブリID
                            this.Text,							// プログラム名称
                            "ReviveRate",						// 処理名称
                            TMsgDisp.OPE_HIDE,					// オペレーション
                            ERR_RVV_MSG,					    // 表示するメッセージ
                            status,								// ステータス値
                            this._rateAcs,						// エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				// 表示するボタン
                            MessageBoxDefaultButton.Button1);	// 初期表示ボタン

                        break;
                    }
            }
            return status;
        }
		
        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        TMsgDisp.Show(this,							// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,		// エラーレベル
                            ASSEMBLY_ID,							// アセンブリID
                            ERR_800_MSG,							// 表示するメッセージ
                            status,									// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン

                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        TMsgDisp.Show(this,							// 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,		// エラーレベル
                            ASSEMBLY_ID,							// アセンブリID
                            ERR_801_MSG,							// 表示するメッセージ
                            status,									// ステータス値
                            MessageBoxButtons.OK);					// 表示するボタン

                        break;
                    }
            }
        }
		
        /// <summary>
        /// エディット項目データ変更チェック
        /// </summary>
        /// <param name="errMsg">エラーメッセージ</param>
        /// <param name="editText">項目オブジェクト</param>
        /// <param name="preObj">前回項目文字列</param>
        /// <returns>チェック結果（0:変更無し, 1:存在しない, 2:変更有り）</returns>
        /// <remarks>
        /// <br>Note		: 画面項目テキストのデータ変更チェックを行います。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2007.11.02</br>
        /// </remarks>
        private DispSetStatus editChgDataChk(string errMsg, object editText, object preObj)
        {
            DispSetStatus inputChkRet = DispSetStatus.Clear;

            // 検索後の場合
            if ((this._AllCtrlInputStatus == AllCtrlInputStatus.SearchDelete)
                || (this._AllCtrlInputStatus == AllCtrlInputStatus.SearchNew)
                || (this._AllCtrlInputStatus == AllCtrlInputStatus.SearchUpdate))
            {
                _stringBuilder.Remove(0, _stringBuilder.Length);
                _stringBuilder.Append(errMsg);
                _stringBuilder.Append(DISP_CHG_MSG);	// 変更時初期化確認
                errMsg = _stringBuilder.ToString();

                // 確認メッセージ出力
                if (ShowConfirmMsg(errMsg, emErrorLevel.ERR_LEVEL_INFO) == true)
                {
                    // 入力有無で返却値変更
                    if (editText is string)
                    {
                        inputChkRet = (string)editText == "" ? DispSetStatus.Clear : DispSetStatus.Update;
                    }
                    else if (editText is int)
                    {
                        inputChkRet = (int)editText == 0 ? DispSetStatus.Clear : DispSetStatus.Update;
                    }
					
                    // 掛率条件入力エラーチェック
                    InpRateCondCheck();
                    SrchRsltDataClear();
                }
                else
                {
                    // データがあれば戻す
                    inputChkRet = preObj == null ? DispSetStatus.Clear : DispSetStatus.Back;
                }
            }
            // 検索前の場合
            else
            {
                // 入力有無で返却値変更
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
        /// クラスメンバーコピー処理（掛率保存設定クラス⇒検索結果クラス）
        /// </summary>
        /// <param name="srchRsltRate">検索結果掛率クラス</param>
        /// <param name="svRate">掛率保存クラス</param>
        /// <remarks>
        /// <br>Note       : 掛率保存設定クラスから検索結果クラスへメンバーへの設定を行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.24</br>
        /// </remarks>
        private void CopyToSrchRsltRateFromSvRate(ref Rate srchRsltRate, Rate svRate)
        {
            // 作成日時
            srchRsltRate.CreateDateTime			= svRate.CreateDateTime;
            // 更新日時
            srchRsltRate.UpdateDateTime			= svRate.UpdateDateTime;
            // 企業コード
            srchRsltRate.EnterpriseCode			= svRate.EnterpriseCode;
            // GUID
            srchRsltRate.FileHeaderGuid			= svRate.FileHeaderGuid;
            // 更新従業員コード
            srchRsltRate.UpdEmployeeCode		= svRate.UpdEmployeeCode;
            // 更新アセンブリID1
            srchRsltRate.UpdAssemblyId1			= svRate.UpdAssemblyId1;
            // 更新アセンブリID2
            srchRsltRate.UpdAssemblyId2			= svRate.UpdAssemblyId2;
            // 論理削除区分
            srchRsltRate.LogicalDeleteCode		= svRate.LogicalDeleteCode;
            // 拠点コード
            srchRsltRate.SectionCode			= svRate.SectionCode;
            // 単価掛率設定区分
            srchRsltRate.UnitRateSetDivCd		= svRate.UnitRateSetDivCd;
            // 新旧区分
            srchRsltRate.OldNewDivCd			= svRate.OldNewDivCd;
            // 単価種類
            srchRsltRate.UnitPriceKind			= svRate.UnitPriceKind;
            // 掛率設定区分
            srchRsltRate.RateSettingDivide		= svRate.RateSettingDivide;
            // 掛率設定区分（商品）
            srchRsltRate.RateMngGoodsCd			= svRate.RateMngGoodsCd;
            // 掛率設定名称（商品）
            srchRsltRate.RateMngGoodsNm			= svRate.RateMngGoodsNm;
            // 掛率設定区分（得意先）
            srchRsltRate.RateMngCustCd			= svRate.RateMngCustCd;
            // 掛率設定名称（得意先）
            srchRsltRate.RateMngCustNm			= svRate.RateMngCustNm;
            // 商品メーカーコード
            srchRsltRate.GoodsMakerCd			= svRate.GoodsMakerCd;
            // 商品番号
            srchRsltRate.GoodsNo				= svRate.GoodsNo;
            // 商品掛率ランク
            srchRsltRate.GoodsRateRank			= svRate.GoodsRateRank;
            // 商品区分グループコード
            srchRsltRate.LargeGoodsGanreCode	= svRate.LargeGoodsGanreCode;
            // 商品区分コード
            srchRsltRate.MediumGoodsGanreCode	= svRate.MediumGoodsGanreCode;
            // 商品区分詳細コード
            srchRsltRate.DetailGoodsGanreCode	= svRate.DetailGoodsGanreCode;
            // 自社分類コード
            srchRsltRate.EnterpriseGanreCode	= svRate.EnterpriseGanreCode;
            // BL商品コード
            srchRsltRate.BLGoodsCode			= svRate.BLGoodsCode;
            // 得意先コード
            srchRsltRate.CustomerCode			= svRate.CustomerCode;
            // 得意先掛率グループコード
            srchRsltRate.CustRateGrpCode		= svRate.CustRateGrpCode;
            // 仕入先コード
            srchRsltRate.SupplierCd				= svRate.SupplierCd;
            // 仕入先掛率グループコード
            srchRsltRate.SuppRateGrpCode		= svRate.SuppRateGrpCode;
            // ロット数
            srchRsltRate.LotCount				= svRate.LotCount;
            // 単価算出区分
            srchRsltRate.UnitPrcCalcDiv			= svRate.UnitPrcCalcDiv;
            // 価格区分
            srchRsltRate.PriceDiv				= svRate.PriceDiv;
            // 価格
            srchRsltRate.PriceFl				= svRate.PriceFl;
            // 掛率
            srchRsltRate.RateVal				= svRate.RateVal;
            // 単価端数処理単位
            srchRsltRate.UnPrcFracProcUnit		= svRate.UnPrcFracProcUnit;
            // 単価端数処理区分
            srchRsltRate.UnPrcFracProcDiv		= svRate.UnPrcFracProcDiv;
            // 掛率開始日
            srchRsltRate.RateStartDate			= svRate.RateStartDate;
            // 特売区分コード
            srchRsltRate.BargainCd				= svRate.BargainCd;
            // 削除日
            srchRsltRate.LogicalDeleteCode		= svRate.LogicalDeleteCode;
        }

        /// <summary>
        /// 掛率タブ画面制御処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 掛率タブ画面の制御を行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.11.05</br>
        /// </remarks>
        private void RateTabControl()
        {
            // 全体入力コントロール
            SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.SearchUpdate.GetHashCode());
            this._AllCtrlInputStatus = AllCtrlInputStatus.SearchUpdate;
        }
		
        /// <summary>
        /// ロットタブ画面制御処理
        /// </summary>
        /// <param name="lotOldNewRate">ロット画面掛率開始ボタンテキスト</param>
        /// <remarks>
        /// <br>Note       : ロットタブ画面の制御を行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.11.05</br>
        /// </remarks>
        private void RateLotTabControl(string lotOldNewRate)
        {
            // 全体入力コントロール
            SettingAllInpCtrl(AllCtrlActiveTab.Lot.GetHashCode(), AllCtrlInputStatus.New.GetHashCode());
            this._AllCtrlInputStatus = AllCtrlInputStatus.New;

            // ロット画面掛率開始日ボタン初期設定
            this.LotOldNewRateStartDate_uButton.Text = lotOldNewRate;
			
            // ロット画面掛率開始日ボタン制御（ロット数0以外で旧掛率がなければボタン押下不可）
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
			
            // 検索結果設定
            OldNewRateChange(true);
			
            // ロット単価表示設定
            if (NullChgInt(this.UnitPriceKindWay_tComboEditor.Value) == 0)
            {
                // 単品設定なので単価設定可
                this.rateLotNew_ultraGrid.DisplayLayout.Bands[0].Columns[LOT_PRICEFL].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            }
            else
            {
                // グループ設定なので単価設定不可
                this.rateLotNew_ultraGrid.DisplayLayout.Bands[0].Columns[LOT_PRICEFL].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
			
            // 単価算出区分判定
            if(NullChgInt(this.UnitPriceKind_tComboEditor.Value) == 1)
            {
                this.rateLotNew_ultraGrid.DisplayLayout.Bands[0].Columns[LOT_UNITPRCCALCDIV].CellActivation = Infragistics.Win.UltraWinGrid.Activation.AllowEdit;
            }
            else
            {
                this.rateLotNew_ultraGrid.DisplayLayout.Bands[0].Columns[LOT_UNITPRCCALCDIV].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
            }
			
            // ロット数をアクティブ化
            if (this.rateLotNew_ultraGrid.Rows.Count > 0)
            {
                this.rateLotNew_ultraGrid.Rows[0].Cells[LOT_LOTCOUNT].Activate();
            }
        }

        /// <summary>
        /// 掛率設定変更チェック処理
        /// </summary>
        /// <returns>チェック結果（true:変更有り, false:変更無し）</returns>
        /// <remarks>
        /// <br>Note       : 掛率設定に変更点有無をチェックします。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.09</br>
        /// </remarks>
        private bool CompareRateChange()
        {
            ArrayList rateList = new ArrayList();
            Rate rate = null;
            ArrayList diffList = null;	// 項目比較用

            bool chgFlag = false;

            //--------------------
            // 新旧掛率データ設定
            //--------------------
            foreach (DictionaryEntry de in Rate._OldNewDivCdTable)
            {
                // 書き込みデータ設定（0:新, 1:旧）
                DispToRate(out rate, NullChgStr(de.Value));

                // 検索キー設定
                string hashKey = de.Value.ToString() + "000000000.00";

                //-------------------------------------------------------------
                // 新規データの場合（検索結果リストクローンが設定無しの場合））
                //     項目比較無し, ロットデータ更新無し, 登録のみ
                //-------------------------------------------------------------
                if (this._rateSrchRsltHashListClone.ContainsKey(hashKey) == false)
                {
                    //--- 新掛率設定チェック ---//
                    if (string.Equals(NullChgStr(de.Value), OLDNEWDIVCD_NEW) == true)
                    {
                        // 未設定の場合（単価 == 0, 掛率 == 0, 端数処理単位 == 0）
                        if ((this.NewPrice_tNedit.GetValue() == 0)
                            && (this.NewRate_tNedit.GetValue() == 0)
                            && (this.NewUnPrcFracProcUnit_tNedit.GetValue() == 0))
                        {
                            // 何もしない
                        }
                        else
                        {
                            // 変更有り
                            chgFlag = true;
                            break;
                        }
                    }
                    else
                    {
                        // 未設定の場合（単価 == 0, 掛率 == 0, 端数処理単位 == 0）
                        if ((this.OldPrice_tNedit.GetValue() == 0)
                            && (this.OldRate_tNedit.GetValue() == 0)
                            && (this.OldUnPrcFracProcUnit_tNedit.GetValue() == 0))
                        {
                            // 何もしない
                        }
                        else
                        {
                            // 変更有り
                            chgFlag = true;
                            break;
                        }
                    }
                }
                //--------------------------------------------------
                // 更新データの場合
                //     項目比較有り, ロットデータ更新有り, 登録有り
                //--------------------------------------------------
                else
                {
                    // 項目比較
                    diffList = null;

                    // 検索結果
                    Rate rateWkClone = (Rate)this._rateSrchRsltHashListClone[hashKey];

                    diffList = rate.Compare(rateWkClone);

                    // 項目変更有り
                    if (diffList.Count > 0)
                    {
                        // 変更有り
                        chgFlag = true;
                        break;
                    }
                }
            }
            return chgFlag;
        }

        #region ＜各種エラーチェック処理＞

        #region 拠点コードエラーチェック処理
        /// <summary>
        /// 拠点コードエラーチェック処理
        /// </summary>
        /// <param name="inParamObj">条件オブジェクト</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note       : 拠点コードのエラーチェックを行います。
        ///					 条件オブジェクト:拠点コード
        ///					 結果オブジェクト:拠点マスタ検索結果ステータス, 拠点名称</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
                // 必須入力チェック
                //------------------
                if (inParamObj == null)					return ret;
                if ((inParamObj is string) == false)	return ret;
                if ((string)inParamObj == "")			return ret;
				
                //--------------
                // 存在チェック
                //--------------
                SecInfoSet secInfoSet = null;

                // 全社
                if (string.Equals((string)inParamObj, "000000") == true)
                {
                    secInfoSet = new SecInfoSet();

                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(0);			// 掛率マスタステータス設定
                    outParamList.Add(COMMON_MODE);	// 拠点名称設定
                }
                // 各拠点
                else
                {
                    this.Cursor = Cursors.WaitCursor;
                    status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, (string)inParamObj);
                    this.Cursor = Cursors.Default;

                    outParamList.Add(status);	// 掛率マスタステータス設定
					
                    if (secInfoSet == null)
                    {
                        ret = (int)InputChkStatus.NotExist;
                    }
                    else
                    {
                        ret = (int)InputChkStatus.Normal;
                        outParamList.Add(secInfoSet.SectionGuideNm);	// 拠点名称設定
                    }
                }
            }
            catch(Exception)
            {
            }
            outParamObj = outParamList;
			
            return ret;
        }
        #endregion 拠点コードエラーチェック処理

        #region 掛率設定区分コードエラーチェック処理
        /// <summary>
        /// 掛率設定区分コードエラーチェック処理
        /// </summary>
        /// <param name="inParamObj">条件オブジェクト</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note       : 掛率設定区分コードのエラーチェックを行います。
        ///					 条件オブジェクト:拠点コード, 単価種類, 設定方法, 掛率設定区分
        ///					 結果オブジェクト:掛率マスタ検索結果ステータス,
        ///									  掛率設定区分コード（商品）, 掛率設定区分名称（商品）, 掛率設定区分コード（得意先）, 掛率設定区分名称（得意先）</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
                // 必須入力チェック
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is ArrayList) == false)					return ret;
				
                inParamList = inParamObj as ArrayList;	// ArrayListへキャスト
				
                if ((inParamList == null)||(inParamList.Count != 4))	return ret;
                if ((inParamList[0] is string) == false)				return ret;
                if ((inParamList[1] is int) == false)					return ret;
                if ((inParamList[2] is int) == false)					return ret;
                if ((inParamList[3] is string) == false)				return ret;
                if ((string)inParamList[3] == "")						return ret;
				
                //--------------
                // 存在チェック
                //--------------
                RateProtyMng rateProtyMng = null;
				
                this.Cursor = Cursors.WaitCursor;
                status = this._rateProtyMngAcs.Read(out rateProtyMng, this._enterpriseCode,
                                                (string)inParamList[0], (int)inParamList[1], (int)inParamList[2], (string)inParamList[3]);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// 掛率優先管理マスタステータス設定

                if (rateProtyMng == null)
                {
                    ret = (int)InputChkStatus.NotExist;
                }
                else
                {
                    ret = (int)InputChkStatus.Normal;

                    outParamList.Add(rateProtyMng.RateMngGoodsCd.Trim());	// 掛率設定区分コード（商品）設定
                    outParamList.Add(rateProtyMng.RateMngGoodsNm.Trim());	// 掛率設定区分名称（商品）設定
                    outParamList.Add(rateProtyMng.RateMngCustCd.Trim());	// 掛率設定区分コード（得意先）設定
                    outParamList.Add(rateProtyMng.RateMngCustNm.Trim());	// 掛率設定区分名称（得意先）設定
                }
            }
            catch(Exception)
            {
            }
            outParamObj = outParamList;
			
            return ret;
        }
        #endregion 掛率設定区分コードエラーチェック処理

        #region 商品コードエラーチェック処理
        /// <summary>
        /// 商品コードエラーチェック処理
        /// </summary>
        /// <param name="inParamObj">条件オブジェクト</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note       : 商品コードのエラーチェックを行います。
        ///					 条件オブジェクト:メーカーコード, 商品コード
        ///					 結果オブジェクト:商品マスタ検索結果ステータス, 商品コード, 商品名称, メーカーコード, メーカー名称</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
                // 必須入力チェック
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is ArrayList) == false)					return ret;
				
                inParamList = inParamObj as ArrayList;	// ArrayListへキャスト
				
                if ((inParamList == null)||(inParamList.Count != 2))	return ret;
                if ((inParamList[0] is int) == false)					return ret;
                if ((inParamList[1] is string) == false)				return ret;
                if ((string)inParamList[1] == "")						return ret;
				
                //--------------
                // 存在チェック
                //--------------
                List<GoodsUnitData> goodsUnitDataList = null;
				
                // 検索の種類を取得
                string searchCode;
                int searchType = GetSearchType((string)inParamList[1], out searchCode);

                //----- ueno add ---------- start 2008.03.05
                MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

                GoodsCndtn goodsCndtn = new GoodsCndtn();

                // 商品検索条件設定
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.SectionCode = this.RateSectionCode_tEdit.Text;
                goodsCndtn.GoodsMakerCd = this.GoodsMakerCd_tNedit.GetInt();
                goodsCndtn.MakerName = this.GoodsMakerCdNm_tEdit.Text;
                goodsCndtn.GoodsNo = searchCode.TrimEnd();
                goodsCndtn.GoodsNoSrchTyp = searchType;

                string message;
                this.Cursor = Cursors.WaitCursor;
                // 読み込み
                status = goodsSelectGuide.ReadGoods(this, false, goodsCndtn, out goodsUnitDataList, out message);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// 商品マスタステータス設定

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                {
                    // 商品マスタデータクラス
                    GoodsUnitData goodsUnitData = new GoodsUnitData();
                    goodsUnitData = goodsUnitDataList[0];

                    outParamList.Add(goodsUnitData.GoodsNo);		// 商品コード
                    outParamList.Add(goodsUnitData.GoodsName);		// 商品名称設定
                    outParamList.Add(goodsUnitData.GoodsMakerCd);	// メーカーコード設定
                    outParamList.Add(goodsUnitData.MakerName);		// メーカー名称設定

                    ret = (int)InputChkStatus.Normal;
                }
                else if (status == -1)
                {
                    // 選択ダイアログでキャンセル
                    ret = (int)InputChkStatus.Cancel;
                }
                else
                {
                    ret = (int)InputChkStatus.NotExist;
                }
                //----- ueno add ---------- end 2008.03.05

                //----- ueno del ---------- start 2008.03.05
                //// 通常検索
                //if (searchType == 0)
                //{
                //    // データ存在チェック
                //    this.Cursor = Cursors.WaitCursor;
                //    status = this._goodsAcs.Read(this._enterpriseCode, searchCode, out goodsUnitDataList);
                //    this.Cursor = Cursors.Default;
                //}
                //// 曖昧検索
                //else
                //{
                //    MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

                //    //----- ueno add ---------- start 2008.03.04
                //    GoodsCndtn goodsCndtn = new GoodsCndtn();
					
                //    // 商品検索条件設定
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
                //    // 曖昧商品検索
                //    status = goodsSelectGuide.ReadGoods(this, false, goodsCndtn, out goodsUnitDataList, out message);
                //    //status = goodsSelectGuide.ReadGoods(this, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
                //    //----- ueno upd ---------- end 2008.03.04
                //    this.Cursor = Cursors.Default;

                //    //----- ueno add ---------- start 2008.03.04
                //    // 曖昧検索結果判定
                //    if(status == -1)
                //    {
                //        status = 0;
						
                //        // 選択キャンセルは正常とみなす
                //        outParamList.Add(0);	// 商品マスタステータス設定
                //        outParamObj = outParamList;
						
                //        return (int)InputChkStatus.Cancel;
                //    }
                //    //----- ueno add ---------- end 2008.03.04
                //}

                //outParamList.Add(status);	// 商品マスタステータス設定
				
                //if ((goodsUnitDataList == null)||(goodsUnitDataList.Count == 0))
                //{
                //    ret = (int)InputChkStatus.NotExist;
                //}
                //else
                //{
                //    // 直接コードの場合、該当するメーカーコードで存在するかチェック
                //    if(searchType == 0)
                //    {
                //        ret = (int)InputChkStatus.NotExist;
					
                //        foreach (GoodsUnitData wkGoodsUnitData in goodsUnitDataList)
                //        {
                //            // メーカーコードで検索
                //            if (wkGoodsUnitData.GoodsMakerCd == (int)inParamList[0])
                //            {
                //                ret = (int)InputChkStatus.Normal;

                //                outParamList.Add(wkGoodsUnitData.GoodsNo);		// 商品コード
                //                outParamList.Add(wkGoodsUnitData.GoodsName);	// 商品名称設定
                //                outParamList.Add(wkGoodsUnitData.GoodsMakerCd);	// メーカーコード設定
                //                outParamList.Add(wkGoodsUnitData.MakerName);	// メーカー名称設定
								
                //                break;
                //            }
                //        }
                //    }
                //    // 曖昧検索の場合
                //    else
                //    {
                //        ret = (int)InputChkStatus.Normal;
						
                //        // 商品マスタデータクラス
                //        GoodsUnitData goodsUnitData = new GoodsUnitData();
                //        goodsUnitData = goodsUnitDataList[0];

                //        outParamList.Add(goodsUnitData.GoodsNo);		// 商品コード
                //        outParamList.Add(goodsUnitData.GoodsName);		// 商品名称設定
                //        outParamList.Add(goodsUnitData.GoodsMakerCd);	// メーカーコード設定
                //        outParamList.Add(goodsUnitData.MakerName);		// メーカー名称設定
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
        #endregion 商品コードエラーチェック処理

        #region 商品コードエラーチェック処理（曖昧無し）
        /// <summary>
        /// 商品コードエラーチェック処理（曖昧無し）
        /// </summary>
        /// <param name="inParamObj">条件オブジェクト</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note       : 商品コードのエラーチェックを行います。
        ///					 条件オブジェクト:メーカーコード, 商品コード
        ///					 結果オブジェクト:商品マスタ検索結果ステータス, 商品コード, 商品名称, メーカーコード, メーカー名称</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
                // 必須入力チェック
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is ArrayList) == false) return ret;

                inParamList = inParamObj as ArrayList;	// ArrayListへキャスト

                if ((inParamList == null) || (inParamList.Count != 2)) return ret;
                if ((inParamList[0] is int) == false) return ret;
                if ((inParamList[1] is string) == false) return ret;
                if ((string)inParamList[1] == "") return ret;
				
                // 直接コード以外エラー
                string searchCode;
                if (GetSearchType((string)inParamList[1], out searchCode) != 0) return ret;
				
                //--------------
                // 存在チェック
                //--------------
                List<GoodsUnitData> goodsUnitDataList = null;
				
                // データ存在チェック
                this.Cursor = Cursors.WaitCursor;
                status = this._goodsAcs.Read(this._enterpriseCode, searchCode, out goodsUnitDataList);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// 商品マスタステータス設定

                if ((goodsUnitDataList == null) || (goodsUnitDataList.Count == 0))
                {
                    ret = (int)InputChkStatus.NotExist;
                }
                else
                {
                    ret = (int)InputChkStatus.NotExist;

                    foreach (GoodsUnitData wkGoodsUnitData in goodsUnitDataList)
                    {
                        // メーカーコードで検索
                        if (wkGoodsUnitData.GoodsMakerCd == (int)inParamList[0])
                        {
                            ret = (int)InputChkStatus.Normal;

                            outParamList.Add(wkGoodsUnitData.GoodsNo);		// 商品コード
                            outParamList.Add(wkGoodsUnitData.GoodsName);	// 商品名称設定
                            outParamList.Add(wkGoodsUnitData.GoodsMakerCd);	// メーカーコード設定
                            outParamList.Add(wkGoodsUnitData.MakerName);	// メーカー名称設定

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
        #endregion 商品コードエラーチェック処理（曖昧無し）

        #region メーカーコードエラーチェック処理
        /// <summary>
        /// メーカーコードエラーチェック処理
        /// </summary>
        /// <param name="inParamObj">条件オブジェクト</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note       : メーカーコードのエラーチェックを行います。
        ///					 条件オブジェクト:メーカーコード
        ///					 結果オブジェクト:メーカーマスタ検索結果ステータス, メーカー名称</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
                // 必須入力チェック
                //------------------
                if (inParamObj == null)				return ret;
                if ((inParamObj is int) == false)	return ret;
                if ((int)inParamObj == 0)			return ret;
				
                //--------------
                // 存在チェック
                //--------------
                MakerUMnt makerUMnt = null;
				
                this.Cursor = Cursors.WaitCursor;
                status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, (int)inParamObj);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// メーカーマスタステータス設定

                if (makerUMnt == null)
                {
                    ret = (int)InputChkStatus.NotExist;
                }
                else
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(makerUMnt.MakerName);	// メーカー名称設定
                }
            }
            catch(Exception)
            {
            }
            outParamObj = outParamList;
			
            return ret;
        }
        #endregion メーカーコードエラーチェック処理

        #region 商品区分グループコードエラーチェック処理
        /// <summary>
        /// 商品区分グループコードエラーチェック処理
        /// </summary>
        /// <param name="inParamObj">条件オブジェクト</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note       : 商品区分グループコードエラーチェックを行います。
        ///					 条件オブジェクト:商品区分グループコード
        ///					 結果オブジェクト:商品区分グループマスタ検索結果ステータス, 商品区分グループ名称</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
                // 必須入力チェック
                //------------------
                if (inParamObj == null)					return ret;
                if ((inParamObj is string) == false)	return ret;
                if ((string)inParamObj == "")			return ret;

                //--------------
                // 存在チェック
                //--------------
                LGoodsGanre lGoodsGanre = null;

                this.Cursor = Cursors.WaitCursor;
                status = this._lGoodsGanreAcs.Read(out lGoodsGanre, this._enterpriseCode, (string)inParamObj);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// 商品区分グループマスタステータス設定
				
                if(lGoodsGanre == null)
                {
                    ret = (int)InputChkStatus.NotExist;
                }
                else
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(lGoodsGanre.LargeGoodsGanreName);	// 商品区分グループ名称設定
                }
            }
            catch(Exception)
            {
            }
            outParamObj = outParamList;
			
            return ret;
        }
        #endregion 商品区分グループコードエラーチェック処理

        #region 商品区分コードエラーチェック処理
        /// <summary>
        /// 商品区分コードエラーチェック処理
        /// </summary>
        /// <param name="inParamObj">条件オブジェクト</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note       : 商品区分コードエラーチェックを行います。
        ///					 条件オブジェクト:商品区分グループコード, 商品区分コード
        ///					 結果オブジェクト:商品区分マスタ検索結果ステータス, 商品区分名称</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
                // 必須入力チェック
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is ArrayList) == false) return ret;

                inParamList = inParamObj as ArrayList;	// ArrayListへキャスト

                if ((inParamList == null) || (inParamList.Count != 2))	return ret;
                if ((inParamList[0] is string) == false)				return ret;
                if ((inParamList[1] is string) == false)				return ret;
                if ((string)inParamList[1] == "")						return ret;

                //--------------
                // 存在チェック
                //--------------
                MGoodsGanre mGoodsGanre = null;

                this.Cursor = Cursors.WaitCursor;
                status = this._mGoodsGanreAcs.Read(out mGoodsGanre, this._enterpriseCode, (string)inParamList[0], (string)inParamList[1]);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// 商品区分マスタステータス設定

                if (mGoodsGanre == null)
                {
                    ret = (int)InputChkStatus.NotExist;
                }
                else
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(mGoodsGanre.MediumGoodsGanreName);	// 商品区分名称設定
                }
            }
            catch(Exception)
            {
            }
            outParamObj = outParamList;
			
            return ret;
        }
        #endregion 商品区分コードエラーチェック処理

        #region 商品区分詳細コードエラーチェック処理
        /// <summary>
        /// 商品区分詳細コードエラーチェック処理
        /// </summary>
        /// <param name="inParamObj">条件オブジェクト</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note       : 商品区分詳細コードエラーチェックを行います。
        ///					 条件オブジェクト:商品区分グループコード, 商品区分コード, 商品区分詳細コード
        ///					 結果オブジェクト:商品区分詳細マスタ検索結果ステータス, 商品区分詳細名称</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
                // 必須入力チェック
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is ArrayList) == false) return ret;

                inParamList = inParamObj as ArrayList;	// ArrayListへキャスト

                if ((inParamList == null) || (inParamList.Count != 3)) return ret;
                if ((inParamList[0] is string) == false) return ret;
                if ((inParamList[1] is string) == false) return ret;
                if ((inParamList[2] is string) == false) return ret;
                if ((string)inParamList[2] == "") return ret;

                //--------------
                // 存在チェック
                //--------------
                DGoodsGanre dGoodsGanre = null;

                this.Cursor = Cursors.WaitCursor;
                ret = this._dGoodsGanreAcs.Read(out dGoodsGanre, this._enterpriseCode, (string)inParamList[0], (string)inParamList[1], (string)inParamList[2]);
                this.Cursor = Cursors.Default;
				
                outParamList.Add(status);	// 商品区分詳細マスタステータス設定
				
                if (dGoodsGanre == null)
                {
                    ret = (int)InputChkStatus.NotExist;
                }
                else
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(dGoodsGanre.DetailGoodsGanreName);	// 商品区分詳細名称設定
                }
            }
            catch(Exception)
            {
            }
            outParamObj = outParamList;
			
            return ret;
        }
        #endregion 商品区分詳細コードエラーチェック処理

        #region 自社分類コードエラーチェック処理
            // ユーザーガイドエラーチェック処理で行う
        #endregion 自社分類コードエラーチェック処理

        #region ＢＬ商品コードエラーチェック処理
        /// <summary>
        /// ＢＬ商品コードエラーチェック処理
        /// </summary>
        /// <param name="inParamObj">条件オブジェクト</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note       : ＢＬ商品コードエラーチェックを行います。
        ///					 条件オブジェクト:ＢＬ商品コード
        ///					 結果オブジェクト:ＢＬ商品マスタ検索結果ステータス, ＢＬ商品名称</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
                // 必須入力チェック
                //------------------
                if (inParamObj == null)				return ret;
                if ((inParamObj is int) == false)	return ret;
                if ((int)inParamObj == 0)			return ret;
				
                //--------------
                // 存在チェック
                //--------------
                BLGoodsCdUMnt bLGoodsCdUMnt = null;

                // データ存在チェック
                this.Cursor = Cursors.WaitCursor;
                ret = this._blGoodsCdAcs.Read(out bLGoodsCdUMnt, this._enterpriseCode, (int)inParamObj, 0);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// ＢＬ商品マスタステータス設定

                if (bLGoodsCdUMnt == null)
                {
                    ret = (int)InputChkStatus.NotExist;
                }
                else
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(bLGoodsCdUMnt.BLGoodsFullName);	// ＢＬ商品名称設定
                }
            }
            catch(Exception)
            {
            }
            outParamObj = outParamList;
			
            return ret;
        }
        #endregion ＢＬ商品コードエラーチェック処理

        #region 得意先コードエラーチェック処理
        /// <summary>
        /// 得意先コードエラーチェック処理
        /// </summary>
        /// <param name="inParamObj">条件オブジェクト</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note       : 得意先コードエラーチェックを行います。
        ///					 条件オブジェクト:得意先コード
        ///					 結果オブジェクト:得意先マスタ検索結果ステータス, 得意先名称</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
                // 必須入力チェック
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is int) == false) return ret;
                if ((int)inParamObj == 0) return ret;

                //--------------
                // 存在チェック
                //--------------
                CustomerInfo customerInfo = null;

                this.Cursor = Cursors.WaitCursor;
                ret = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode,
                                (int)inParamObj, out customerInfo);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// 得意先マスタステータス設定
				
                // 入力データが得意先か判定
                if ((customerInfo != null)&&(customerInfo.IsCustomer == true))
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(customerInfo.Name);	// 得意先名称設定
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
        #endregion 得意先コードエラーチェック処理

        #region 得意先掛率グループエラーチェック処理
            // ユーザーガイドエラーチェック処理で行う
        #endregion 得意先掛率グループエラーチェック処理

        #region 仕入先コードエラーチェック処理
        /// <summary>
        /// 仕入先コードエラーチェック処理
        /// </summary>
        /// <param name="inParamObj">条件オブジェクト</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note       : 仕入先コードエラーチェックを行います。
        ///					 条件オブジェクト:仕入先コード
        ///					 結果オブジェクト:仕入先マスタ検索結果ステータス, 仕入先名称</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
                // 必須入力チェック
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is int) == false) return ret;
                if ((int)inParamObj == 0) return ret;

                //--------------
                // 存在チェック
                //--------------
                CustomerInfo customerInfo = null;

                this.Cursor = Cursors.WaitCursor;
                ret = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode,
                                this.SupplierCd_tNedit.GetInt(), out customerInfo);
                this.Cursor = Cursors.Default;

                outParamList.Add(status);	// 仕入先マスタステータス設定

                // 入力データが得意先か判定
                if ((customerInfo != null) && (customerInfo.IsSupplier == true))
                {
                    ret = (int)InputChkStatus.Normal;
                    outParamList.Add(customerInfo.Name);	// 仕入先名称設定
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
        #endregion 仕入先コードエラーチェック処理

        #region 仕入先掛率グループエラーチェック処理
            // ユーザーガイドエラーチェック処理で行う
        #endregion 仕入先掛率グループエラーチェック処理

        #region 掛率開始日エラーチェック処理
        /// <summary>
        /// 掛率開始日エラーチェック処理
        /// </summary>
        /// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note       : 掛率開始日エラーチェックを行います。
        ///					 条件オブジェクト:掛率開始日
        ///					 結果オブジェクト:無し</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private int CheckRateStartDate(object inParamObj, out object outParamObj)
        {
            outParamObj = 0;	// 結果オブジェクトは未使用
            ArrayList outParamList = new ArrayList();
            int ret = (int)InputChkStatus.NotInput;

            ArrayList inParamList = null;
			
            try
            {
                //------------------
                // 必須入力チェック
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is ArrayList) == false) return ret;
				
                inParamList = inParamObj as ArrayList;	// ArrayListへキャスト
				
                if ((inParamList == null) || (inParamList.Count != 3)) return ret;
                if ((inParamList[0] is int) == false) return ret;
                if ((inParamList[1] is int) == false) return ret;
                if ((inParamList[2] is int) == false) return ret;

                if (((int)inParamList[0] > 0) && ((int)inParamList[1] > 0) && ((int)inParamList[2] > 0))
                {
                    // 入力が正しい日付か？
                    int inputDate_int = ((int)inParamList[0] * 10000) + ((int)inParamList[1] * 100) + ((int)inParamList[2]);
                    DateTime inputDate = TDateTime.LongDateToDateTime(inputDate_int);
					
                    // 正しい
                    if (inputDate != DateTime.MinValue)
                    {
                        ret = (int)InputChkStatus.Normal;
                    }
                    else
                    {
                        ret = (int)InputChkStatus.InputErr;	// 不正データ
                    }
                }
            }
            catch(Exception)
            {
            }
            return ret;
        }
        #endregion 掛率開始日エラーチェック処理
		
        #region ユーザーガイドエラーチェック処理
        /// <summary>
        /// ユーザーガイドエラーチェック処理
        /// </summary>
        /// <returns>チェック結果（0:正常, 0以外:エラー）</returns>
        /// <remarks>
        /// <br>Note       : ユーザーガイドのエラーチェックを行います。
        ///					 条件オブジェクト:ユーザーガイドコード
        ///					 結果オブジェクト:未使用</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
                // 必須入力チェック
                //------------------
                if (inParamObj == null) return ret;
                if ((inParamObj is ArrayList) == false) return ret;

                inParamList = inParamObj as ArrayList;	// ArrayListへキャスト

                if ((inParamList == null) || (inParamList.Count != 2)) return ret;
                if ((inParamList[0] is SortedList)	== false) return ret;
                if ((inParamList[1] is int)			== false) return ret;
				
                //--------------
                // 存在チェック
                //--------------
                // 該当データが存在するか確認
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
        #endregion ユーザーガイドエラーチェック処理

        #endregion ＜各種エラーチェック処理＞

        #region ＜項目データ設定処理＞

        #region 拠点コード設定処理
        /// <summary>
        /// 拠点コード設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus">フォーカスフラグ</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 拠点コードを画面に設定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetSectionCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            this.RateSectionCode_tEdit.Clear();
                            this.SectionCodeNm_tEdit.Clear();

                            // 現在データクリア
                            this._searchRate.SectionCode = "";

                            //----- ueno upd ---------- start 2008.03.07
                            // フォーカス
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07
                            break;
                        }
                    case DispSetStatus.Back:	// 元に戻す
                        {
                            this.RateSectionCode_tEdit.Text = this._searchRate.SectionCode;

                            //----- ueno add ---------- start 2008.03.07
                            // フォーカス移動しない
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// 更新
                        {
                            if ((outParamObj != null)&&(outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;
								
                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.SectionCodeNm_tEdit.Text = (string)outParamList[1];	// 拠点名称設定
									
                                    // 現在データ保存
                                    this._searchRate.SectionCode = this.RateSectionCode_tEdit.Text;

                                    //----------------------------------------
                                    // 拠点コード、掛率設定区分関連性チェック
                                    //----------------------------------------
                                    // 条件設定
                                    ArrayList wkInParamList = new ArrayList();
                                    wkInParamList.Add(this.RateSectionCode_tEdit.Text);
                                    wkInParamList.Add(NullChgInt(this.UnitPriceKind_tComboEditor.Value));
                                    wkInParamList.Add(NullChgInt(this.UnitPriceKindWay_tComboEditor.Value));
                                    wkInParamList.Add(this.RateSettingDivide_tEdit.Text);
									
                                    object wkInParamObj = wkInParamList;
                                    object wkOutParamObj = null;
									
                                    // 存在チェック
                                    int status = CheckRateSettingDivide(wkInParamObj, out wkOutParamObj);
									
                                    if(status != 0)
                                    {
                                        // 拠点コード以外全て削除
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
        #endregion 拠点コード設定処理

        #region 掛率設定区分設定処理
        /// <summary>
        /// 掛率設定区分設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus">フォーカスフラグ</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 掛率設定区分を画面に設定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetRateSettingDivide(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            // 掛率設定区分クリア
                            this.RateSettingDivide_tEdit.Clear();
                            this.RateMngGoodsCd_tEdit.Clear();
                            this.RateMngGoodsNm_tEdit.Clear();
                            this.RateMngCustCd_tEdit.Clear();
                            this.RateMngCustNm_tEdit.Clear();

                            // 現在データクリア
                            this._searchRate.RateSettingDivide = "";
                            this._searchRate.RateMngGoodsCd = "";
                            this._searchRate.RateMngGoodsNm = "";
                            this._searchRate.RateMngCustCd = "";
                            this._searchRate.RateMngCustNm = "";

                            //----- ueno upd ---------- start 2008.03.07
                            // フォーカス
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// 元に戻す
                        {
                            this.RateSettingDivide_tEdit.Text = this._searchRate.RateSettingDivide;
                            this.RateMngGoodsCd_tEdit.Text = this._searchRate.RateMngGoodsCd;
                            this.RateMngCustCd_tEdit.Text = this._searchRate.RateMngCustCd;
							
                            this.RateSectionCode_tEdit.Text = this._searchRate.SectionCode;

                            //----- ueno add ---------- start 2008.03.07
                            // フォーカス移動しない
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// 更新
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
                                    this.RateMngGoodsCd_tEdit.Text = (string)outParamList[1];	// 掛率設定区分コード（商品）
                                    this.RateMngGoodsNm_tEdit.Text = (string)outParamList[2];	// 掛率設定区分名称（商品）
                                    this.RateMngCustCd_tEdit.Text = (string)outParamList[3];	// 掛率設定区分コード（得意先）
                                    this.RateMngCustNm_tEdit.Text = (string)outParamList[4];	// 掛率設定区分名称（得意先）

                                    // 現在データ保存
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
        #endregion 掛率設定区分設定処理

        #region 商品掛率ランク設定処理
        /// <summary>
        /// 商品掛率ランク設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus">フォーカスフラグ</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 商品掛率ランクを画面に設定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetGoodsRateRankCd(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            this.GoodsRateRankCd_Grp_tEdit.Clear();
							
                            // 現在データクリア
                            this._searchRate.GoodsRateRank = "";

                            //----- ueno upd ---------- start 2008.03.07
                            // フォーカス
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:		// 元に戻す
                        {
                            this.GoodsRateRankCd_Grp_tEdit.Text = this._searchRate.GoodsRateRank;

                            //----- ueno add ---------- start 2008.03.07
                            // フォーカス移動しない
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// 更新
                        {
                            if ((outParamObj != null) && (outParamObj is string))
                            {
                                this.GoodsRateRankCd_Grp_tEdit.Text = (string)outParamObj;
								
                                // 現在データ保存
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
        #endregion 商品掛率ランク設定処理

        #region 商品コード設定処理
        /// <summary>
        /// 商品コード設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus">フォーカスフラグ</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 商品コードを画面に設定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetGoodsNoCd(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            this.GoodsNoCd_tEdit.Clear();
                            this.GoodsNoNm_tEdit.Clear();

                            // 現在データクリア
                            this._searchRate.GoodsNo = "";

                            //----- ueno upd ---------- start 2008.03.07
                            // フォーカス
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:		// 元に戻す
                        {
                            this.GoodsNoCd_tEdit.Text = this._searchRate.GoodsNo;

                            //----- ueno add ---------- start 2008.03.07
                            // フォーカス移動しない
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// 更新
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
                                    this.GoodsNoCd_tEdit.Text = (string)outParamList[1];		// 商品コード
                                    this.GoodsNoNm_tEdit.Text = (string)outParamList[2];		// 商品名称
                                    this.GoodsMakerCd_tNedit.SetInt((int)outParamList[3]);		// メーカーコード
                                    this.GoodsMakerCdNm_tEdit.Text = (string)outParamList[4];	// メーカー名称

                                    // 現在データ保存
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
        #endregion 商品コード設定処理

        #region メーカーコード（単品）設定処理
        /// <summary>
        /// メーカーコード（単品）設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus">フォーカスフラグ</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <remarks>
        /// <br>Note       : メーカーコード（単品）を画面に設定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetGoodsMakerCd(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            this.GoodsMakerCd_tNedit.Clear();
                            this.GoodsMakerCdNm_tEdit.Clear();

                            // 現在データクリア
                            this._searchRate.GoodsMakerCd = 0;

                            //----- ueno add ---------- start 2008.03.05
                            // 商品コードクリア
                            this.GoodsNoCd_tEdit.Clear();
                            this.GoodsNoNm_tEdit.Clear();
                            this._searchRate.GoodsNo = "";
                            //----- ueno add ---------- end 2008.03.05

                            //----- ueno upd ---------- start 2008.03.07
                            // フォーカス
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07
                            break;
                        }
                    case DispSetStatus.Back:		// 元に戻す
                        {
                            this.GoodsMakerCd_tNedit.SetInt(this._searchRate.GoodsMakerCd);

                            //----- ueno add ---------- start 2008.03.07
                            // フォーカス移動しない
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// 更新
                        {
                            if ((outParamObj != null)&&(outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;
								
                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.GoodsMakerCdNm_tEdit.Text = (string)outParamList[1];	// メーカー名称

                                    //----- ueno add ---------- start 2008.03.05
                                    //----------------------------
                                    // メーカーコード変更チェック
                                    //----------------------------
                                    if (this._searchRate.GoodsMakerCd != this.GoodsMakerCd_tNedit.GetInt())
                                    {
                                        // メーカーコード変更時は、商品コードクリア
                                        this.GoodsNoCd_tEdit.Clear();
                                        this.GoodsNoNm_tEdit.Clear();
                                        this._searchRate.GoodsNo = "";
                                    }
                                    //----- ueno add ---------- end 2008.03.05
									
                                    // 現在データ保存
                                    this._searchRate.GoodsMakerCd = this.GoodsMakerCd_tNedit.GetInt();

                                    //----- ueno del ---------- start 2008.03.05
                                    ////------------------------------------------
                                    //// メーカーコード、商品コード関連性チェック
                                    ////------------------------------------------
                                    //// 条件設定
                                    //ArrayList wkInParamList = new ArrayList();
                                    //wkInParamList.Add(this.GoodsMakerCd_tNedit.GetInt());
                                    //wkInParamList.Add(this.GoodsNoCd_tEdit.Text);
									
                                    //object wkInParamObj = wkInParamList;
                                    //object wkOutParamObj = null;
									
                                    //// 存在チェック（曖昧無し）
                                    //int status = CheckGoodsNoCdDirect(wkInParamObj, out wkOutParamObj);
									
                                    //if(status != 0)
                                    //{
                                    //    // メーカーに紐づく商品コード, 商品名称クリア
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
        #endregion メーカーコード（単品）設定処理

        #region メーカーコード設定処理
        /// <summary>
        /// メーカーコード設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus">フォーカスフラグ</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <remarks>
        /// <br>Note       : メーカーコードを画面に設定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetGoodsMakerCdGrp(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;

            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            this.GoodsMakerCd_Grp_tNedit.Clear();
                            this.GoodsMakerCdNm_Grp_tEdit.Clear();

                            // 現在データクリア
                            this._searchRate.GoodsMakerCd = 0;

                            //----- ueno upd ---------- start 2008.03.07
                            // フォーカス
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:		// 元に戻す
                        {
                            this.GoodsMakerCd_Grp_tNedit.SetInt(this._searchRate.GoodsMakerCd);

                            //----- ueno add ---------- start 2008.03.07
                            // フォーカス移動しない
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// 更新
                        {
                            if ((outParamObj != null) && (outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;

                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.GoodsMakerCdNm_Grp_tEdit.Text = (string)outParamList[1];	// メーカー名称

                                    // 現在データ保存
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
        #endregion メーカーコード設定処理

        #region 商品区分グループコード設定処理
        /// <summary>
        /// 商品区分グループコード設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus">フォーカスフラグ</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 商品区分グループコードを画面に設定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetLargeGoodsGanreCodeGrp(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            this.LargeGoodsGanreCode_Grp_tEdit.Clear();
                            this.LargeGoodsGanreCodeNm_Grp_tEdit.Clear();

                            // 現在データクリア
                            this._searchRate.LargeGoodsGanreCode = "";

                            //----- ueno upd ---------- start 2008.03.07
                            // フォーカス
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// 元に戻す
                        {
                            this.LargeGoodsGanreCode_Grp_tEdit.Text = this._searchRate.LargeGoodsGanreCode;

                            //----- ueno add ---------- start 2008.03.07
                            // フォーカス移動しない
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// 更新
                        {
                            if ((outParamObj != null) && (outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;

                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.LargeGoodsGanreCodeNm_Grp_tEdit.Text = (string)outParamList[1];	// 商品区分グループ名称
									
                                    // 現在データ保存
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
        #endregion 商品区分グループコード設定処理

        #region 商品区分コード設定処理
        /// <summary>
        /// 商品区分コード設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus">フォーカスフラグ</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 商品区分コードを画面に設定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetMediumGoodsGanreCodeGrp(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            this.MediumGoodsGanreCode_Grp_tEdit.Clear();
                            this.MediumGoodsGanreCodeNm_Grp_tEdit.Clear();

                            // 現在データクリア
                            this._searchRate.MediumGoodsGanreCode = "";

                            //----- ueno upd ---------- start 2008.03.07
                            // フォーカス
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// 元に戻す
                        {
                            this.MediumGoodsGanreCode_Grp_tEdit.Text = this._searchRate.MediumGoodsGanreCode;

                            //----- ueno add ---------- start 2008.03.07
                            // フォーカス移動しない
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// 更新
                        {
                            if ((outParamObj != null)&&(outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;
								
                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.MediumGoodsGanreCodeNm_Grp_tEdit.Text = (string)outParamList[1];	// 商品区分名称

                                    // 現在データ保存
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
        #endregion 商品区分コード設定処理

        #region 商品区分詳細コード設定処理
        /// <summary>
        /// 商品区分詳細コード設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus">フォーカスフラグ</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 商品区分詳細コードを画面に設定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetDetailGoodsGanreCodeGrp(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            this.DetailGoodsGanreCode_Grp_tEdit.Clear();
                            this.DetailGoodsGanreCodeNm_Grp_tEdit.Clear();

                            // 現在データクリア
                            this._searchRate.DetailGoodsGanreCode = "";

                            //----- ueno upd ---------- start 2008.03.07
                            // フォーカス
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// 元に戻す
                        {
                            this.DetailGoodsGanreCode_Grp_tEdit.Text = this._searchRate.DetailGoodsGanreCode;

                            //----- ueno add ---------- start 2008.03.07
                            // フォーカス移動しない
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// 更新
                        {
                            if ((outParamObj != null)&&(outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;
															
                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.DetailGoodsGanreCodeNm_Grp_tEdit.Text = (string)outParamList[1];	// 商品区分詳細名称

                                    // 現在データ保存
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
        #endregion 商品区分詳細コード設定処理

        #region 自社分類コード設定処理
        /// <summary>
        /// 自社分類コード設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus">フォーカスフラグ</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 自社分類コードを画面に設定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetEnterpriseGanreCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            this.EnterpriseGanreCode_Grp_tComboEditor.Clear();

                            // 現在データクリア
                            this._searchRate.EnterpriseGanreCode = 0;

                            //----- ueno upd ---------- start 2008.03.07
                            // フォーカス
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// 元に戻す
                        {
                            this.EnterpriseGanreCode_Grp_tComboEditor.Value = this._searchRate.EnterpriseGanreCode;

                            //----- ueno add ---------- start 2008.03.07
                            // フォーカス移動しない
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// 更新
                        {
                            // 現在データ保存
                            this._searchRate.EnterpriseGanreCode = (int)this.EnterpriseGanreCode_Grp_tComboEditor.Value;
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }

        #endregion 自社分類コード設定処理

        #region ＢＬ商品コード設定処理
        /// <summary>
        /// ＢＬ商品コード設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus">フォーカスフラグ</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <remarks>
        /// <br>Note       : ＢＬ商品コードを画面に設定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetBLGoodsCodeGrp(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            this.BLGoodsCode_Grp_tNedit.Clear();
                            this.BLGoodsCodeNm_Grp_tEdit.Clear();

                            // 現在データクリア
                            this._searchRate.BLGoodsCode = 0;

                            //----- ueno upd ---------- start 2008.03.07
                            // フォーカス
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// 元に戻す
                        {
                            this.BLGoodsCode_Grp_tNedit.SetInt(this._searchRate.BLGoodsCode);

                            //----- ueno add ---------- start 2008.03.07
                            // フォーカス移動しない
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// 更新
                        {
                            if ((outParamObj != null)&&(outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;
						
                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.BLGoodsCodeNm_Grp_tEdit.Text = (string)outParamList[1];

                                    // 現在データ保存
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
        #endregion ＢＬ商品コード設定処理

        #region 得意先コード設定処理
        /// <summary>
        /// 得意先コード設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus">フォーカスフラグ</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 得意先コードを画面に設定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetCustomerCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            this.CustomerCode_tNedit.Clear();
                            this.CustomerCodeNm_tEdit.Clear();

                            // 現在データクリア
                            this._searchRate.CustomerCode = 0;

                            //----- ueno upd ---------- start 2008.03.07
                            // フォーカス
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// 元に戻す
                        {
                            this.CustomerCode_tNedit.SetInt(this._searchRate.CustomerCode);

                            //----- ueno add ---------- start 2008.03.07
                            // フォーカス移動しない
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// 更新
                        {
                            if ((outParamObj != null)&&(outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;

                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.CustomerCodeNm_tEdit.Text = (string)outParamList[1];

                                    // 現在データ保存
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
        #endregion 得意先コード設定処理

        #region 得意先掛率グループ設定処理
        /// <summary>
        /// 得意先掛率グループ設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus">フォーカスフラグ</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループを画面に設定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetCustRateGrpCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            this.CustRateGrpCode_tComboEditor.Clear();

                            // 現在データクリア
                            this._searchRate.CustRateGrpCode = 0;

                            //----- ueno upd ---------- start 2008.03.07
                            // フォーカス
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// 元に戻す
                        {
                            this.CustRateGrpCode_tComboEditor.Value = this._searchRate.CustRateGrpCode;

                            //----- ueno add ---------- start 2008.03.07
                            // フォーカス移動しない
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// 更新
                        {
                            // 現在データ保存
                            this._searchRate.CustRateGrpCode = (int)this.CustRateGrpCode_tComboEditor.Value;
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion 得意先掛率グループ設定処理

        #region 仕入先コード設定処理
        /// <summary>
        /// 仕入先コード設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus">フォーカスフラグ</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 仕入先コードを画面に設定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetSupplierCd(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            ArrayList outParamList = null;
			
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            this.SupplierCd_tNedit.Clear();
                            this.SupplierCdNm_tEdit.Clear();

                            // 現在データクリア
                            this._searchRate.SupplierCd = 0;

                            //----- ueno upd ---------- start 2008.03.07
                            // フォーカス
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// 元に戻す
                        {
                            this.SupplierCd_tNedit.SetInt(this._searchRate.SupplierCd);

                            //----- ueno add ---------- start 2008.03.07
                            // フォーカス移動しない
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// 更新
                        {
                            if ((outParamObj != null)&&(outParamObj is ArrayList))
                            {
                                outParamList = outParamObj as ArrayList;

                                if ((outParamList != null)
                                    && (outParamList.Count == 2)
                                    && (outParamList[1] is string))
                                {
                                    this.SupplierCdNm_tEdit.Text = (string)outParamList[1];

                                    // 現在データ保存
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
        #endregion 仕入先コード設定処理
		
        #region 仕入先掛率グループ設定処理
        /// <summary>
        /// 仕入先掛率グループ設定処理
        /// </summary>
        /// <param name="dispSetStatus">入力チェックフラグ</param>
        /// <param name="canChangeFocus">フォーカスフラグ</param>
        /// <param name="outParamObj">結果オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 仕入先掛率グループを画面に設定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void DispSetSuppRateGrpCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        {
            try
            {
                switch (dispSetStatus)
                {
                    case DispSetStatus.Clear:	// データクリア
                        {
                            this.SuppRateGrpCode_tComboEditor.Clear();
							
                            // 現在データクリア
                            this._searchRate.SuppRateGrpCode = 0;

                            //----- ueno upd ---------- start 2008.03.07
                            // フォーカス
                            canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
                            //----- ueno upd ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Back:	// 元に戻す
                        {
                            this.SuppRateGrpCode_tComboEditor.Value = this._searchRate.SuppRateGrpCode;

                            //----- ueno add ---------- start 2008.03.07
                            // フォーカス移動しない
                            canChangeFocus = false;
                            //----- ueno add ---------- end 2008.03.07

                            break;
                        }
                    case DispSetStatus.Update:	// 更新
                        {
                            // 現在データ保存
                            this._searchRate.SuppRateGrpCode = (int)this.SuppRateGrpCode_tComboEditor.Value;
                            break;
                        }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion 仕入先掛率グループ設定処理

        #endregion ＜項目データ設定処理＞

        /// <summary>
        /// 拠点コード変更時処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 拠点コードが変更されたときに処理を行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void SectionCodeVisibleChange()
        {
            string wkSectionCode = this.RateSectionCode_tEdit.Text;
            string wkSectionName = this.SectionCodeNm_tEdit.Text;
			
            // 全クリア
            ScreenClear();
			
            this.RateSectionCode_tEdit.Text = wkSectionCode;
            this.SectionCodeNm_tEdit.Text = wkSectionName;
			
            // 現在データ保存
            this._searchRate.SectionCode = this.RateSectionCode_tEdit.Text;
        }

        /// <summary>
        /// 掛率設定区分変更時処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 掛率設定区分が変更されたときに処理を行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void RateSettingDivideVisibleChange()
        {
            // 一時退避
            string wkSectionCode = this.RateSectionCode_tEdit.Text;
            string wkSectionName = this.SectionCodeNm_tEdit.Text;
            int wkUnitPriceKind = (Int32)this.UnitPriceKind_tComboEditor.Value;
            int wkUnitPriceKindWay = (Int32)this.UnitPriceKindWay_tComboEditor.Value;
			
            string wkRateSettingDivide = this.RateSettingDivide_tEdit.Text;
            string wkRateMngGoodsCd = this.RateMngGoodsCd_tEdit.Text;
            string wkRateMngGoodsNm = this.RateMngGoodsNm_tEdit.Text;
            string wkRateMngCustCd  = this.RateMngCustCd_tEdit.Text;
            string wkRateMngCustNm  = this.RateMngCustNm_tEdit.Text;
			
            // 掛率設定区分は変更されると抽出条件が変更されるので、抽出条件を削除する
            ScreenClear();
			
            // ワークを設定
            this.RateSectionCode_tEdit.Text = wkSectionCode;
            this.UnitPriceKind_tComboEditor.Value = wkUnitPriceKind;
            this.UnitPriceKindWay_tComboEditor.Value = wkUnitPriceKindWay;
            this.SectionCodeNm_tEdit.Text = wkSectionName;

            this.RateSettingDivide_tEdit.Text = wkRateSettingDivide;
            this.RateMngGoodsCd_tEdit.Text = wkRateMngGoodsCd;
            this.RateMngGoodsNm_tEdit.Text = wkRateMngGoodsNm;
            this.RateMngCustCd_tEdit.Text = wkRateMngCustCd;
            this.RateMngCustNm_tEdit.Text = wkRateMngCustNm;

            // 現在データ保存
            this._searchRate.SectionCode = this.RateSectionCode_tEdit.Text;

            this._searchRate.RateSettingDivide = this.RateSettingDivide_tEdit.Text;
            this._searchRate.RateMngGoodsCd = this.RateMngGoodsCd_tEdit.Text;
            this._searchRate.RateMngGoodsNm = this.RateMngGoodsNm_tEdit.Text;
            this._searchRate.RateMngCustCd = this.RateMngCustCd_tEdit.Text;
            this._searchRate.RateMngCustNm = this.RateMngCustNm_tEdit.Text;
			
            // イベント停止
            this.UnitPriceKind_tComboEditor.SelectionChangeCommitted -= new EventHandler(this.UnitPriceKind_tComboEditor_SelectionChangeCommitted);
            this.UnitPriceKindWay_tComboEditor.SelectionChangeCommitted -= new EventHandler(this.UnitPriceKindWay_tComboEditor_SelectionChangeCommitted);

            // コンボボックス設定
            UnitPriceKindVisibleChange((Int32)this.UnitPriceKind_tComboEditor.Value);
            UnitPriceKindWayVisibleChange((Int32)this.UnitPriceKindWay_tComboEditor.Value);

            // イベント発動
            this.UnitPriceKind_tComboEditor.SelectionChangeCommitted += new EventHandler(this.UnitPriceKind_tComboEditor_SelectionChangeCommitted);
            this.UnitPriceKindWay_tComboEditor.SelectionChangeCommitted += new EventHandler(this.UnitPriceKindWay_tComboEditor_SelectionChangeCommitted);
        }

        /// <summary>
        /// データ無しエラーメッセージ作成処理
        /// </summary>
        /// <param name="title">項目名</param>
        /// <returns>メッセージ</returns>
        /// <remarks>
        /// <br>Note       : データ無しのエラーメッセージを作成します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private string MakeShowNotFoundErrMsg(string title)
        {
            string errMsg = "";
            _stringBuilder.Remove(0, _stringBuilder.Length);
            _stringBuilder.Append("指定された条件で、");
            _stringBuilder.Append(title);
            _stringBuilder.Append("は存在しませんでした。");
            errMsg = _stringBuilder.ToString();
			
            return errMsg;
        }

        #region タブコントロールテーブル作成処理
        /// <summary>
        /// タブコントロールテーブル作成処理
        /// </summary>
        /// <br>Note       : タブコントロールテーブルを作成します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.11.06</br>
        private void SetTabControlList()
        {
            //==============================
            // 次項目
            //==============================
            // 掛率設定パネル
            this._nextCtrlTable.Add(this.RateSectionCode_tEdit.Name,				this.SectionCode_uButton);
            this._nextCtrlTable.Add(this.SectionCode_uButton.Name,				this.UnitPriceKind_tComboEditor);
            this._nextCtrlTable.Add(this.UnitPriceKind_tComboEditor.Name,		this.UnitPriceKindWay_tComboEditor);
            this._nextCtrlTable.Add(this.UnitPriceKindWay_tComboEditor.Name,	this.RateSettingDivide_tEdit);
            this._nextCtrlTable.Add(this.RateSettingDivide_tEdit.Name,			this.RateSettingDivide_uButton);
            this._nextCtrlTable.Add(this.RateSettingDivide_uButton.Name,		this.Rate_uTabControl);		// デフォルト設定：掛率タブ
			
            // 単品設定パネル
            this._nextCtrlTable.Add(this.GoodsMakerCd_tNedit.Name,				this.GoodsMakerCd_uButton);
            this._nextCtrlTable.Add(this.GoodsMakerCd_uButton.Name,				this.GoodsNoCd_tEdit);
            this._nextCtrlTable.Add(this.GoodsNoCd_tEdit.Name,					this.GoodsNo_uButton);
            this._nextCtrlTable.Add(this.GoodsNo_uButton.Name,					this.CustomerCode_tNedit);
			
            // 商品G設定パネル
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
			
            // 取引先設定パネル
            this._nextCtrlTable.Add(this.CustomerCode_tNedit.Name,				this.CustomerCode_uButton);
            this._nextCtrlTable.Add(this.CustomerCode_uButton.Name,				this.CustRateGrpCode_tComboEditor);
            this._nextCtrlTable.Add(this.CustRateGrpCode_tComboEditor.Name,		this.SupplierCd_tNedit);
            this._nextCtrlTable.Add(this.SupplierCd_tNedit.Name,				this.SupplierCd_uButton);
            this._nextCtrlTable.Add(this.SupplierCd_uButton.Name,				this.SuppRateGrpCode_tComboEditor);
            this._nextCtrlTable.Add(this.SuppRateGrpCode_tComboEditor.Name,		this.Search_uButton);
			
            // 新掛率設定パネル
            this._nextCtrlTable.Add(this.NewRateStartDate_tDateEdit.Name,		this.NewPrice_tNedit);
            this._nextCtrlTable.Add(this.NewPrice_tNedit.Name,					this.NewPriceDiv_tComboEditor);
            this._nextCtrlTable.Add(this.NewPriceDiv_tComboEditor.Name,			this.NewUnPrcCalcDiv_tComboEditor);
            this._nextCtrlTable.Add(this.NewUnPrcCalcDiv_tComboEditor.Name,		this.NewRate_tNedit);
            this._nextCtrlTable.Add(this.NewRate_tNedit.Name,					this.NewUnPrcFracProcUnit_tNedit);
            this._nextCtrlTable.Add(this.NewUnPrcFracProcUnit_tNedit.Name,		this.NewUnPrcFracProcDiv_tComboEditor);
            this._nextCtrlTable.Add(this.NewUnPrcFracProcDiv_tComboEditor.Name,	this.NewBargainCd_tComboEditor);
            this._nextCtrlTable.Add(this.NewBargainCd_tComboEditor.Name,		this.CopyToOldFromNewbtn);
			
            // 新掛率→旧掛率ボタン
            this._nextCtrlTable.Add(this.CopyToOldFromNewbtn.Name,				this.OldRateStartDate_tDateEdit);
			
            // 旧掛率設定パネル
            this._nextCtrlTable.Add(this.OldRateStartDate_tDateEdit.Name,		this.OldPrice_tNedit);
            this._nextCtrlTable.Add(this.OldPrice_tNedit.Name,					this.OldPriceDiv_tComboEditor);
            this._nextCtrlTable.Add(this.OldPriceDiv_tComboEditor.Name,			this.OldUnPrcCalcDiv_tComboEditor);
            this._nextCtrlTable.Add(this.OldUnPrcCalcDiv_tComboEditor.Name,		this.OldRate_tNedit);
            this._nextCtrlTable.Add(this.OldRate_tNedit.Name,					this.OldUnPrcFracProcUnit_tNedit);
            this._nextCtrlTable.Add(this.OldUnPrcFracProcUnit_tNedit.Name,		this.OldUnPrcFracProcDiv_tComboEditor);
            this._nextCtrlTable.Add(this.OldUnPrcFracProcDiv_tComboEditor.Name,	this.OldBargainCd_tComboEditor);
            this._nextCtrlTable.Add(this.OldBargainCd_tComboEditor.Name,		this.Rate_Clear_Btn);
			
            // 検索ボタン
            this._nextCtrlTable.Add(this.Search_uButton.Name,					this.Rate_uTabControl);
            // 掛率タブ
            this._nextCtrlTable.Add(this.Rate_uTabControl.Name,					this.Rate_Clear_Btn);		// デフォルト設定：取消ボタン
            // 取消ボタン
            this._nextCtrlTable.Add(this.Rate_Clear_Btn.Name,					this.Cancel_Button);		// デフォルト設定：閉じるボタン
            // 削除ボタン
            this._nextCtrlTable.Add(this.Rate_LogicalDel_Btn.Name,				this.Rate_Ok_Btn);
            // 完全削除ボタン
            this._nextCtrlTable.Add(this.Rate_PhysicalDelBtn.Name,				this.Rate_ReviveBtn);
            // 復活ボタン
            this._nextCtrlTable.Add(this.Rate_ReviveBtn.Name,					this.Cancel_Button);
            // 保存ボタン
            this._nextCtrlTable.Add(this.Rate_Ok_Btn.Name,						this.Cancel_Button);
            // 閉じるボタン
            this._nextCtrlTable.Add(this.Cancel_Button.Name,					this.RateSectionCode_tEdit);

            //==============================
            // 前項目
            //==============================
            // 掛率設定パネル
            this._forwardCtrlTable.Add(this.RateSectionCode_tEdit.Name,					this.Cancel_Button);
            this._forwardCtrlTable.Add(this.SectionCode_uButton.Name,				this.RateSectionCode_tEdit);
            this._forwardCtrlTable.Add(this.UnitPriceKind_tComboEditor.Name,		this.SectionCode_uButton);
            this._forwardCtrlTable.Add(this.UnitPriceKindWay_tComboEditor.Name,		this.UnitPriceKind_tComboEditor);
            this._forwardCtrlTable.Add(this.RateSettingDivide_tEdit.Name,			this.UnitPriceKindWay_tComboEditor);
            this._forwardCtrlTable.Add(this.RateSettingDivide_uButton.Name,			this.RateSettingDivide_tEdit);

            // 単品設定パネル
            this._forwardCtrlTable.Add(this.GoodsMakerCd_tNedit.Name,				this.RateSettingDivide_uButton);
            this._forwardCtrlTable.Add(this.GoodsMakerCd_uButton.Name,				this.GoodsMakerCd_tNedit);
            this._forwardCtrlTable.Add(this.GoodsNoCd_tEdit.Name,					this.GoodsMakerCd_uButton);
            this._forwardCtrlTable.Add(this.GoodsNo_uButton.Name,					this.GoodsNoCd_tEdit);

            // 商品G設定パネル
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

            // 取引先設定パネル
            this._forwardCtrlTable.Add(this.CustomerCode_tNedit.Name,				this.CustomerCode_tNedit);	// デフォルト：自分自身
            this._forwardCtrlTable.Add(this.CustomerCode_uButton.Name,				this.CustomerCode_tNedit);
            this._forwardCtrlTable.Add(this.CustRateGrpCode_tComboEditor.Name,		this.CustRateGrpCode_tComboEditor);
            this._forwardCtrlTable.Add(this.SupplierCd_tNedit.Name,					this.CustRateGrpCode_tComboEditor);
            this._forwardCtrlTable.Add(this.SupplierCd_uButton.Name,				this.SupplierCd_tNedit);
            this._forwardCtrlTable.Add(this.SuppRateGrpCode_tComboEditor.Name,		this.SupplierCd_uButton);

            // 新掛率設定パネル
            this._forwardCtrlTable.Add(this.NewRateStartDate_tDateEdit.Name,		this.Rate_uTabControl);
            this._forwardCtrlTable.Add(this.NewPrice_tNedit.Name,					this.NewRateStartDate_tDateEdit);
            this._forwardCtrlTable.Add(this.NewPriceDiv_tComboEditor.Name,			this.NewPrice_tNedit);
            this._forwardCtrlTable.Add(this.NewUnPrcCalcDiv_tComboEditor.Name,		this.NewPriceDiv_tComboEditor);
            this._forwardCtrlTable.Add(this.NewRate_tNedit.Name,					this.NewUnPrcCalcDiv_tComboEditor);
            this._forwardCtrlTable.Add(this.NewUnPrcFracProcUnit_tNedit.Name,		this.NewRate_tNedit);
            this._forwardCtrlTable.Add(this.NewUnPrcFracProcDiv_tComboEditor.Name,	this.NewUnPrcFracProcUnit_tNedit);
            this._forwardCtrlTable.Add(this.NewBargainCd_tComboEditor.Name,			this.NewUnPrcFracProcDiv_tComboEditor);

            // 新掛率→旧掛率ボタン
            this._forwardCtrlTable.Add(this.CopyToOldFromNewbtn.Name,				this.NewBargainCd_tComboEditor);

            // 旧掛率設定パネル
            this._forwardCtrlTable.Add(this.OldRateStartDate_tDateEdit.Name,		this.CopyToOldFromNewbtn);
            this._forwardCtrlTable.Add(this.OldPrice_tNedit.Name,					this.OldRateStartDate_tDateEdit);
            this._forwardCtrlTable.Add(this.OldPriceDiv_tComboEditor.Name,			this.OldPrice_tNedit);
            this._forwardCtrlTable.Add(this.OldUnPrcCalcDiv_tComboEditor.Name,		this.OldPriceDiv_tComboEditor);
            this._forwardCtrlTable.Add(this.OldRate_tNedit.Name,					this.OldUnPrcCalcDiv_tComboEditor);
            this._forwardCtrlTable.Add(this.OldUnPrcFracProcUnit_tNedit.Name,		this.OldRate_tNedit);
            this._forwardCtrlTable.Add(this.OldUnPrcFracProcDiv_tComboEditor.Name,	this.OldUnPrcFracProcUnit_tNedit);
            this._forwardCtrlTable.Add(this.OldBargainCd_tComboEditor.Name,			this.OldUnPrcFracProcDiv_tComboEditor);
			
            // 検索ボタン
            this._forwardCtrlTable.Add(this.Search_uButton.Name,					this.RateSettingDivide_uButton);	// デフォルト設定：掛率設定区分ガイド
            // 掛率タブ
            this._forwardCtrlTable.Add(this.Rate_uTabControl.Name,					this.RateSettingDivide_uButton);	// デフォルト設定：掛率設定区分ガイド
            // 取消ボタン
            this._forwardCtrlTable.Add(this.Rate_Clear_Btn.Name,					this.Rate_uTabControl);				// デフォルト設定：掛率タブ
            // 削除ボタン
            this._forwardCtrlTable.Add(this.Rate_LogicalDel_Btn.Name,				this.Rate_Clear_Btn);
            // 完全削除ボタン
            this._forwardCtrlTable.Add(this.Rate_PhysicalDelBtn.Name,				this.Rate_Clear_Btn);
            // 復活ボタン
            this._forwardCtrlTable.Add(this.Rate_ReviveBtn.Name,					this.Rate_PhysicalDelBtn);
            // 保存ボタン
            this._forwardCtrlTable.Add(this.Rate_Ok_Btn.Name,						this.Rate_Clear_Btn);				// デフォルト設定：取消ボタン
            // 閉じるボタン
            this._forwardCtrlTable.Add(this.Cancel_Button.Name,						this.Rate_Clear_Btn);				// デフォルト設定：取消ボタン
        }
        #endregion タブコントロールテーブル作成処理

        #region ネクストコントロール取得処理
        /// <summary>
        /// ネクストコントロール取得処理
        /// </summary>
        /// <param name="prevCtrl">現在のコントロール</param>
        /// <returns>次のコントロール</returns>
        /// <br>Note       : ネクストコントロールを取得します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.11.06</br>
        private Control GetNextControl(Control prevCtrl)
        {
            Control control = null;
            try
            {
                object hashKey = null;
                //--------------------------
                // 掛率設定パネル次項目設定
                //--------------------------
                // 掛率設定区分ガイド次項目設定
                hashKey = this.RateSettingDivide_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true))
                {
                    // 単品設定
                    if ((this.GoodsMakerCd_tNedit.Enabled == true) && (this.UnitPriceKindWay_tComboEditor.SelectedIndex == 0))
                    {
                        this._nextCtrlTable[hashKey] = this.GoodsMakerCd_tNedit;
                    }
                    // 商品グループ設定
                    else if ((this.GoodsMakerCd_Grp_tNedit.Enabled == true) && (this.UnitPriceKindWay_tComboEditor.SelectedIndex == 1))
                    {
                        this._nextCtrlTable[hashKey] = this.GoodsMakerCd_Grp_tNedit;
                    }
                    // 取引先設定パネル設定
                    else if (this.Customer_panel.Enabled == true)
                    {
                        NextChkCustomerItem(ref this._nextCtrlTable, 0, hashKey);
                    }
                    else if(this.Search_uButton.Enabled == true)
                    {
                        // 検索ボタン設定
                        this._nextCtrlTable[hashKey] = this.Search_uButton;
                    }
                    else
                    {
                        // 掛率タブ設定
                        this._nextCtrlTable[hashKey] = this.Rate_uTabControl;
                    }
                }

                //--------------------------
                // 単品設定パネル次項目設定
                //--------------------------
                // 商品ガイド次項目設定
                hashKey = this.GoodsNo_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.GoodsNo_uButton.Enabled == true))
                {
                    NextChkCustomerItem(ref this._nextCtrlTable, 0, hashKey);
                }

                //----------------------------
                // 商品Ｇ設定パネル次項目設定
                //----------------------------
                // メーカーガイド次項目設定
                hashKey = this.GoodsMakerCd_Grp_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.GoodsMakerCd_Grp_uButton.Enabled == true))
                {
                    NextChkGrpItem(ref this._nextCtrlTable, 1, hashKey);
                }
                // 商品掛率Ｇ次項目設定
                hashKey = this.GoodsRateRankCd_Grp_tEdit.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.GoodsRateRankCd_Grp_tEdit.Enabled == true))
                {
                    NextChkGrpItem(ref this._nextCtrlTable, 2, hashKey);
                }
                // 商品区分グループコードガイド次項目設定
                hashKey = this.LargeGoodsGanreCode_Grp_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.LargeGoodsGanreCode_Grp_uButton.Enabled == true))
                {
                    NextChkGrpItem(ref this._nextCtrlTable, 3, hashKey);
                }
                // 商品区分ガイド次項目設定
                hashKey = this.MediumGoodsGanreCode_Grp_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.MediumGoodsGanreCode_Grp_uButton.Enabled == true))
                {
                    NextChkGrpItem(ref this._nextCtrlTable, 4, hashKey);
                }
                // 商品区分詳細ガイド次項目設定
                hashKey = this.DetailGoodsGanreCode_Grp_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.DetailGoodsGanreCode_Grp_uButton.Enabled == true))
                {
                    NextChkGrpItem(ref this._nextCtrlTable, 5, hashKey);
                }
                // 自社分類次項目設定
                hashKey = this.EnterpriseGanreCode_Grp_tComboEditor.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.EnterpriseGanreCode_Grp_tComboEditor.Enabled == true))
                {
                    NextChkGrpItem(ref this._nextCtrlTable, 6, hashKey);
                }
                // ＢＬ商品ガイド次項目設定
                hashKey = this.BLGoodsCode_Grp_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.BLGoodsCode_Grp_uButton.Enabled == true))
                {
                    NextChkCustomerItem(ref this._nextCtrlTable, 0, hashKey);
                }
				
                //----------------------------
                // 取引先設定パネル次項目設定
                //----------------------------
                // 得意先ガイド次項目設定
                hashKey = this.CustomerCode_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.CustomerCode_uButton.Enabled == true))
                {
                    NextChkCustomerItem(ref this._nextCtrlTable, 1, hashKey);
                }
                // 得意先掛率Ｇ次項目設定
                hashKey = this.CustRateGrpCode_tComboEditor.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.CustRateGrpCode_tComboEditor.Enabled == true))
                {
                    NextChkCustomerItem(ref this._nextCtrlTable, 2, hashKey);
                }
                // 仕入先ガイド次項目設定
                hashKey = this.SupplierCd_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey)&&(this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.SupplierCd_uButton.Enabled == true))
                {
                    NextChkCustomerItem(ref this._nextCtrlTable, 3, hashKey);
                }

                // 仕入先掛率次項目設定
                hashKey = this.SuppRateGrpCode_tComboEditor.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._nextCtrlTable.ContainsKey(hashKey) == true) && (this.SuppRateGrpCode_tComboEditor.Enabled == true))
                {
                    NextChkCustomerItem(ref this._nextCtrlTable, 4, hashKey);
                }
				
                //----------------------------
                // 新掛率設定パネル次項目設定
                //----------------------------
                // 新掛率開始日次項目設定
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
                // 旧掛率設定パネル次項目設定
                //----------------------------
                // 旧掛率開始日次項目設定
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
                // ボタン次項目設定
                //------------------
                // 掛率タブ次項目設定
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
				
                // 取消ボタン次項目設定
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
				
                // 次項目インデックス取得
                if (this._nextCtrlTable.ContainsKey(prevCtrl.Name) == true)
                {
                    control = (Control)this._nextCtrlTable[prevCtrl.Name];
                }
            }
            catch(Exception ex)
            {
                TMsgDisp.Show(this,							// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO,			// エラーレベル
                    ASSEMBLY_ID,							// アセンブリID
                    ex.Message,								// 表示するメッセージ
                    0,										// ステータス値
                    MessageBoxButtons.OK);					// 表示するボタン
            }
            return control;
        }
        #endregion ネクストコントロール取得処理

        #region 商品グループ次項目入力可否判定処理
        /// <summary>
        /// 商品グループ次項目入力可否判定処理
        /// </summary>
        /// <param name="sList">タブ移動制御リスト</param>
        /// <param name="num">チェック開始位置</param>
        /// <param name="hashKey">ハッシュキー</param>
        /// <br>Note       : 商品グループ項目入力可否を判定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.11.06</br>
        private void NextChkGrpItem(ref SortedList sList, int num, object hashKey)
        {
            // メーカーコード
            if ((this.GoodsMakerCd_Grp_tNedit.Enabled == true)&&(num == 0))
            {
                sList[hashKey] = this.GoodsMakerCd_Grp_tNedit;
                return;
            }
            // 商品掛率ランク
            if ((this.GoodsRateRankCd_Grp_tEdit.Enabled == true)&&(0 <= num)&&(num <= 1))
            {
                sList[hashKey] = this.GoodsRateRankCd_Grp_tEdit;
                return;
            }
            // 商品区分グループコード
            if ((this.LargeGoodsGanreCode_Grp_tEdit.Enabled == true)&&(0 <= num)&&(num <= 2))
            {
                sList[hashKey] = this.LargeGoodsGanreCode_Grp_tEdit;
                return;
            }
            // 商品区分コード
            if ((this.MediumGoodsGanreCode_Grp_tEdit.Enabled == true)&&(0 <= num)&&(num <= 3))
            {
                sList[hashKey] = this.MediumGoodsGanreCode_Grp_tEdit;
                return;
            }
            // 商品区分詳細コード
            if ((this.DetailGoodsGanreCode_Grp_tEdit.Enabled == true)&&(0 <= num)&&(num <= 4))
            {
                sList[hashKey] = this.DetailGoodsGanreCode_Grp_tEdit;
                return;
            }
            // 自社分類
            if ((this.EnterpriseGanreCode_Grp_tComboEditor.Enabled == true)&&(0 <= num)&&(num <= 5))
            {
                sList[hashKey] = this.EnterpriseGanreCode_Grp_tComboEditor;
                return;
            }
            // ＢＬ商品コード
            if ((this.BLGoodsCode_Grp_tNedit.Enabled == true)&&(0 <= num) && (num <= 6))
            {
                sList[hashKey] = this.BLGoodsCode_Grp_tNedit;
                return;
            }
            // 取引先パネルへ移動
            if((0 <= num) && (num <= 7))
            {
                NextChkCustomerItem(ref sList, 0, hashKey);
            }
        }
        #endregion 商品グループ次項目入力可否判定処理

        #region 取引先次項目入力可否判定処理
        /// <summary>
        /// 取引先次項目入力可否判定処理
        /// </summary>
        /// <param name="sList">タブ移動制御リスト</param>
        /// <param name="num">チェック開始位置</param>
        /// <param name="hashKey">ハッシュキー</param>
        /// <br>Note       : 取引先項目入力可否を判定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.11.06</br>
        private void NextChkCustomerItem(ref SortedList sList, int num, object hashKey)
        {
            // 得意先コード
            if ((this.CustomerCode_tNedit.Enabled == true)&&(num == 0))
            {
                sList[hashKey] = this.CustomerCode_tNedit;
                return;
            }
            // 得意先掛率Ｇ
            if ((this.CustRateGrpCode_tComboEditor.Enabled == true)&&(0 <= num)&&(num <= 1))
            {
                sList[hashKey] = this.CustRateGrpCode_tComboEditor;
                return;
            }
            // 仕入先コード
            if ((this.SupplierCd_tNedit.Enabled == true)&&(0 <= num)&&(num <= 2))
            {
                sList[hashKey] = this.SupplierCd_tNedit;
                return;
            }
            // 仕入先掛率Ｇ
            if ((this.SuppRateGrpCode_tComboEditor.Enabled == true)&&(0 <= num)&&(num <= 3))
            {
                sList[hashKey] = this.SuppRateGrpCode_tComboEditor;
                return;
            }
            // 検索ボタン
            if ((this.Search_uButton.Enabled == true)&&(0 <= num)&&(num <= 4))
            {
                sList[hashKey] = this.Search_uButton;
                return;
            }
        }
        #endregion 取引先次項目入力可否判定処理

        #region フォワードコントロール取得処理
        /// <summary>
        /// フォワードコントロール取得処理
        /// </summary>
        /// <param name="prevCtrl">現在のコントロール</param>
        /// <returns>前のコントロール</returns>
        /// <br>Note       : フォワードコントロールを取得します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.11.06</br>
        private Control GetForwardControl(Control prevCtrl)
        {
            Control control = null;
            try
            {
                object hashKey = null;
                int unitFlag = 0;	// 0:単品, 1:商品G
				
                //------------------
                // 単品・商品Ｇ判定
                //------------------
                // 単品設定
                if (this.UnitPriceKindWay_tComboEditor.SelectedIndex == 0)
                {
                    unitFlag = 0;
                }
                // 商品グループ設定
                else
                {
                    unitFlag = 1;
                }
				
                //----------------------------
                // 商品Ｇ設定パネル前項目設定
                //----------------------------
                // ＢＬ商品コード前項目設定
                hashKey = this.BLGoodsCode_Grp_tNedit.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.BLGoodsCode_Grp_tNedit.Enabled == true))
                {
                    ForwardChkGrpItem(ref this._forwardCtrlTable, 1, hashKey);
                }
                // 自社分類前項目設定
                hashKey = this.EnterpriseGanreCode_Grp_tComboEditor.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.EnterpriseGanreCode_Grp_tComboEditor.Enabled == true))
                {
                    ForwardChkGrpItem(ref this._forwardCtrlTable, 2, hashKey);
                }
                // 商品区分詳細コード前項目設定
                hashKey = this.DetailGoodsGanreCode_Grp_tEdit.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.DetailGoodsGanreCode_Grp_tEdit.Enabled == true))
                {
                    ForwardChkGrpItem(ref this._forwardCtrlTable, 3, hashKey);
                }
                // 商品区分コード前項目設定
                hashKey = this.MediumGoodsGanreCode_Grp_tEdit.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.MediumGoodsGanreCode_Grp_tEdit.Enabled == true))
                {
                    ForwardChkGrpItem(ref this._forwardCtrlTable, 4, hashKey);
                }
                // 商品区分グループコード前項目設定
                hashKey = this.LargeGoodsGanreCode_Grp_tEdit.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.LargeGoodsGanreCode_Grp_tEdit.Enabled == true))
                {
                    ForwardChkGrpItem(ref this._forwardCtrlTable, 5, hashKey);
                }
                // 商品掛率Ｇ前項目設定
                hashKey = this.GoodsRateRankCd_Grp_tEdit.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.GoodsRateRankCd_Grp_tEdit.Enabled == true))
                {
                    ForwardChkGrpItem(ref this._forwardCtrlTable, 6, hashKey);
                }
                // メーカーコード前項目設定
                hashKey = this.GoodsMakerCd_Grp_tNedit.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.GoodsMakerCd_Grp_tNedit.Enabled == true))
                {
                    ForwardChkGrpItem(ref this._forwardCtrlTable, 7, hashKey);
                }

                //----------------------------
                // 取引先設定パネル次項目設定
                //----------------------------
                // 得意先コード前項目設定
                hashKey = this.CustomerCode_tNedit.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.CustomerCode_tNedit.Enabled == true))
                {
                    ForwardChkCustomerItem(ref this._forwardCtrlTable, 4, hashKey, unitFlag);
                }
                // 得意先掛率Ｇ前項目設定
                hashKey = this.CustRateGrpCode_tComboEditor.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.CustRateGrpCode_tComboEditor.Enabled == true))
                {
                    ForwardChkCustomerItem(ref this._forwardCtrlTable, 3, hashKey, unitFlag);
                }
                // 仕入先コード前項目設定
                hashKey = this.SupplierCd_tNedit.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.SupplierCd_tNedit.Enabled == true))
                {
                    ForwardChkCustomerItem(ref this._forwardCtrlTable, 2, hashKey, unitFlag);
                }
                // 仕入先掛率Ｇ前項目設定
                hashKey = this.SuppRateGrpCode_tComboEditor.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.SuppRateGrpCode_tComboEditor.Enabled == true))
                {
                    ForwardChkCustomerItem(ref this._forwardCtrlTable, 1, hashKey, unitFlag);
                }

                //----------------------------
                // 新掛率設定パネル前項目設定
                //----------------------------
                // 新基準価格区分前項目設定
                hashKey = this.NewPriceDiv_tComboEditor.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.NewPrice_tNedit.Enabled == false))
                {
                    this._forwardCtrlTable[hashKey] = this.NewRateStartDate_tDateEdit;
                }

                //----------------------------
                // 旧掛率設定パネル前項目設定
                //----------------------------
                // 旧基準価格区分前項目設定
                hashKey = this.OldPriceDiv_tComboEditor.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.OldPrice_tNedit.Enabled == false))
                {
                    this._forwardCtrlTable[hashKey] = this.OldRateStartDate_tDateEdit;
                }

                //------------------
                // ボタン次項目設定
                //------------------
                // 検索ボタン前項目設定
                hashKey = this.Search_uButton.Name;
                if ((prevCtrl.Name == (string)hashKey) && (this._forwardCtrlTable.ContainsKey(hashKey) == true) && (this.Search_uButton.Enabled == true))
                {
                    ForwardChkCustomerItem(ref this._forwardCtrlTable, 0, hashKey, unitFlag);
                }
				
                // 掛率タブ前項目設定
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
				
                // 取消ボタン前項目設定
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
				
                // 保存ボタン前項目設定
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
				
                // 閉じるボタン前項目設定
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
				
                // 前項目インデックス取得
                if (this._forwardCtrlTable.ContainsKey(prevCtrl.Name) == true)
                {
                    control = (Control)this._forwardCtrlTable[prevCtrl.Name];
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(this,							// 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_INFO,			// エラーレベル
                    ASSEMBLY_ID,							// アセンブリID
                    ex.Message,								// 表示するメッセージ
                    0,										// ステータス値
                    MessageBoxButtons.OK);					// 表示するボタン
            }
            return control;
        }
        #endregion フォワードコントロール取得処理

        #region 商品グループ前項目入力可否判定処理
        /// <summary>
        /// 商品グループ前項目入力可否判定処理
        /// </summary>
        /// <param name="sList">タブ移動制御リスト</param>
        /// <param name="num">チェック開始位置</param>
        /// <param name="hashKey">ハッシュキー</param>
        /// <br>Note       : 商品グループ項目入力可否を判定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.11.06</br>
        private void ForwardChkGrpItem(ref SortedList sList, int num, object hashKey)
        {
            // ＢＬ商品ガイド
            if ((this.BLGoodsCode_Grp_uButton.Enabled == true) && (num == 0))
            {
                sList[hashKey] = this.BLGoodsCode_Grp_uButton;
                return;
            }
            // 自社分類
            if ((this.EnterpriseGanreCode_Grp_tComboEditor.Enabled == true) && (0 <= num) && (num <= 1))
            {
                sList[hashKey] = this.EnterpriseGanreCode_Grp_tComboEditor;
                return;
            }
            // 商品区分詳細ガイド
            if ((this.DetailGoodsGanreCode_Grp_uButton.Enabled == true) && (0 <= num) && (num <= 2))
            {
                sList[hashKey] = this.DetailGoodsGanreCode_Grp_uButton;
                return;
            }
            // 商品区分ガイド
            if ((this.MediumGoodsGanreCode_Grp_uButton.Enabled == true) && (0 <= num) && (num <= 3))
            {
                sList[hashKey] = this.MediumGoodsGanreCode_Grp_uButton;
                return;
            }
            // 商品区分グループコードガイド
            if ((this.LargeGoodsGanreCode_Grp_uButton.Enabled == true) && (0 <= num) && (num <= 4))
            {
                sList[hashKey] = this.LargeGoodsGanreCode_Grp_uButton;
                return;
            }
            // 商品掛率ランク
            if ((this.GoodsRateRankCd_Grp_tEdit.Enabled == true) && (0 <= num) && (num <= 5))
            {
                sList[hashKey] = this.GoodsRateRankCd_Grp_tEdit;
                return;
            }
            // メーカーガイド
            if ((this.GoodsMakerCd_Grp_uButton.Enabled == true) && (0 <= num) && (num <= 6))
            {
                sList[hashKey] = this.GoodsMakerCd_Grp_uButton;
                return;
            }
            // 掛率設定パネルへ移動
            if((0 <= num) && (num <= 7))
            {
                sList[hashKey] = this.RateSettingDivide_uButton;
                return;
            }
        }
        #endregion 商品グループ前項目入力可否判定処理

        #region 取引先前項目入力可否判定処理
        /// <summary>
        /// 取引先前項目入力可否判定処理
        /// </summary>
        /// <param name="sList">タブ移動制御リスト</param>
        /// <param name="num">チェック開始位置</param>
        /// <param name="hashKey">ハッシュキー</param>
        /// <param name="unitFlag">単品・商品Ｇ判別フラグ（0:単品, 1:商品G）</param>
        /// <br>Note       : 取引先項目入力可否を判定します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.11.06</br>
        private void ForwardChkCustomerItem(ref SortedList sList, int num, object hashKey, int unitFlag)
        {
            // 仕入先掛率Ｇ
            if ((this.SuppRateGrpCode_tComboEditor.Enabled == true) && (num == 0))
            {
                sList[hashKey] = this.SuppRateGrpCode_tComboEditor;
                return;
            }
            // 仕入先ガイド
            if ((this.SupplierCd_uButton.Enabled == true) && (0 <= num) && (num <= 1))
            {
                sList[hashKey] = this.SupplierCd_uButton;
                return;
            }
            // 得意先掛率Ｇ
            if ((this.CustRateGrpCode_tComboEditor.Enabled == true) && (0 <= num) && (num <= 2))
            {
                sList[hashKey] = this.CustRateGrpCode_tComboEditor;
                return;
            }
            // 得意先ガイド
            if ((this.CustomerCode_uButton.Enabled == true) && (0 <= num) && (num <= 3))
            {
                sList[hashKey] = this.CustomerCode_uButton;
                return;
            }
            // 単品・商品Ｇ設定判定
            if((0 <= num) && (num <= 4))
            {
                // 単品設定
                if(unitFlag == 0)
                {
                    sList[hashKey] = this.GoodsNo_uButton;
                }
                // 商品Ｇ設定
                else
                {
                    ForwardChkGrpItem(ref sList, 0, hashKey);
                }
            }
        }
        #endregion 取引先前項目入力可否判定処理

        /// <summary>
        /// 検索タイプ取得処理
        /// </summary>
        /// <param name="inputCode">入力されたコード</param>
        /// <param name="searchCode">検索用コード（*を除く）</param>
        /// <returns>0:完全一致検索 1:前方一致検索 2:後方一致検索 3:曖昧検索</returns>
        /// <remarks>
        /// Note			:	検索する方法を取得する処理を行います。<br />
        /// <br>Programmer : 30167 上野　弘貴</br>
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
                // *が存在しないため完全一致検索
                return 0;
            }
        }

        /// <summary>
        /// エラーメッセージ表示処理
        /// </summary>
        /// <param name="iLevel">エラーレベル</param>
        /// <param name="message">表示メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : メッセージの表示を行います。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.11.08</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// エラーレベル
                ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                this.Text,							// プログラム名称
                "", 								// 処理名称
                "",									// オペレーション
                message,							// 表示するメッセージ
                status, 							// ステータス値
                null, 								// エラーが発生したオブジェクト
                MessageBoxButtons.OK, 				// 表示するボタン
                MessageBoxDefaultButton.Button1);	// 初期表示ボタン
        }
		
        /// <summary>
        /// 商品コードガイド起動処理
        /// </summary>
        /// <param name="goodsMakerCd_tNedit">商品コードコンポーネント</param>
        /// <remarks>
        /// <br>Note       : 商品コードガイドを起動します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
            // 商品コードガイド
            //------------------
            if (goodsMakerCd_tNedit.Text != "")
            {
                // メーカーコード設定
                goodsCndtn.GoodsMakerCd = goodsMakerCd_tNedit.GetInt();

                //----- ueno add ---------- start 2008.03.04
                // メーカー名称設定
                goodsCndtn.MakerName = GoodsMakerCdNm_tEdit.Text.TrimEnd();
                autoSearch = true;
                //----- ueno add ---------- end 2008.03.04
            }

            //----- ueno add ---------- start 2008.03.04
            // 検索条件に拠点をセット
            if (this.RateSectionCode_tEdit.Text != "")
            {
                goodsCndtn.SectionCode = this.RateSectionCode_tEdit.Text;
            }
            //----- ueno add ---------- end 2008.03.04

            //----- ueno upd ---------- start 2008.03.04
            // 自動検索はメーカーコードが存在する場合のみとする
            DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, autoSearch, goodsCndtn, out goodsUnitData);
            //DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, true, goodsCndtn, out goodsUnitData);
            //----- ueno upd ---------- end 2008.03.04

            if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
            {
                // 変更が無ければ処理しない
                if (string.Equals(goodsUnitData.GoodsNo, this._searchRate.GoodsNo) == true)
                {
                    return;
                }

                DispSetStatus dispSetStatus = editChgDataChk("商品コード", goodsUnitData.GoodsNo, this._searchRate.GoodsNo);
                if (dispSetStatus == DispSetStatus.Update)
                {
                    this.GoodsNoCd_tEdit.Text = goodsUnitData.GoodsNo;
                    this.GoodsNoNm_tEdit.Text = goodsUnitData.GoodsName;

                    // 現在データ保存
                    this._searchRate.GoodsNo = this.GoodsNoCd_tEdit.Text;
					
                    //--------------------------------------
                    // 商品コードに対するメーカーコード設定
                    //--------------------------------------
                    MakerUMnt makerUMnt = null;

                    // データ存在チェック
                    int ret = this._goodsAcs.GetMaker(this._enterpriseCode, goodsUnitData.GoodsMakerCd, out makerUMnt);

                    if (ret == 0)
                    {
                        // メーカーコードも設定
                        this.GoodsMakerCd_tNedit.SetInt(goodsUnitData.GoodsMakerCd);
                        this.GoodsMakerCdNm_tEdit.Text = makerUMnt.MakerName;

                        // 現在データ保存
                        this._searchRate.GoodsMakerCd = this.GoodsMakerCd_tNedit.GetInt();
                    }
                }
            }
        }

        /// <summary>
        /// 商品区分グループコードガイド起動処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品区分グループコードガイドを起動します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.31</br>
        /// </remarks>
        private void LargeGoodsGanreCodeGuide()
        {
            LGoodsGanre lGoodsGanre = null;

            if (this._lGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, out lGoodsGanre, 1) == 0)
            {
                // 変更が無ければ処理しない
                if (string.Equals(lGoodsGanre.LargeGoodsGanreCode, this._searchRate.LargeGoodsGanreCode) == true)
                {
                    return;
                }

                DispSetStatus dispSetStatus = editChgDataChk("商品区分グループコード", lGoodsGanre.LargeGoodsGanreCode, this._searchRate.LargeGoodsGanreCode);
                if (dispSetStatus == DispSetStatus.Update)
                {
                    // 商品区分グループコード
                    this.LargeGoodsGanreCode_Grp_tEdit.Text = lGoodsGanre.LargeGoodsGanreCode;
                    this.LargeGoodsGanreCodeNm_Grp_tEdit.Text = lGoodsGanre.LargeGoodsGanreName;

                    // 現在データ保存
                    this._searchRate.LargeGoodsGanreCode = this.LargeGoodsGanreCode_Grp_tEdit.Text;

                    // 商品区分が入力可の場合
                    if (this.MediumGoodsGanreCode_Grp_tEdit.Enabled == true)
                    {
                        // 商品区分ガイド起動
                        MediumGoodsGanreCodeGuide();
                    }
                }
            }
            else
            {
                // 商品区分グループコードクリア
                this.LargeGoodsGanreCode_Grp_tEdit.Clear();
                this.LargeGoodsGanreCodeNm_Grp_tEdit.Clear();

                // 現在データクリア
                this._searchRate.LargeGoodsGanreCode = "";
            }
        }
		
        /// <summary>
        /// 商品区分ガイド起動処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品区分ガイドを起動します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.31</br>
        /// </remarks>
        private void MediumGoodsGanreCodeGuide()
        {
            MGoodsGanre mGoodsGanre = null;
            string lGoodsGanre = this.LargeGoodsGanreCode_Grp_tEdit.Text;	// 大分類設定

            if (this._mGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, lGoodsGanre, out mGoodsGanre, 1) == 0)
            {
                // 変更が無ければ処理しない
                if (string.Equals(mGoodsGanre.MediumGoodsGanreCode, this._searchRate.MediumGoodsGanreCode) == true)
                {
                    return;
                }

                DispSetStatus dispSetStatus = editChgDataChk("商品区分コード", mGoodsGanre.MediumGoodsGanreCode, this._searchRate.MediumGoodsGanreCode);
                if (dispSetStatus == DispSetStatus.Update)
                {
                    // 商品区分
                    this.MediumGoodsGanreCode_Grp_tEdit.Text = mGoodsGanre.MediumGoodsGanreCode;
                    this.MediumGoodsGanreCodeNm_Grp_tEdit.Text = mGoodsGanre.MediumGoodsGanreName;

                    // 現在データ保存
                    this._searchRate.MediumGoodsGanreCode = this.MediumGoodsGanreCode_Grp_tEdit.Text;

                    // 商品区分詳細コードが入力可の場合
                    if (this.DetailGoodsGanreCode_Grp_tEdit.Enabled == true)
                    {
                        // 商品区分詳細ガイド起動
                        DetailGoodsGanreCodeGuide();
                    }
                }
            }
            else
            {
                // 商品区分クリア
                this.MediumGoodsGanreCode_Grp_tEdit.Clear();
                this.MediumGoodsGanreCodeNm_Grp_tEdit.Clear();

                // 商品区分詳細クリア
                this.DetailGoodsGanreCode_Grp_tEdit.Clear();
                this.DetailGoodsGanreCodeNm_Grp_tEdit.Clear();
				
                // 現在データクリア
                this._searchRate.MediumGoodsGanreCode = "";
                this._searchRate.DetailGoodsGanreCode = "";
            }
        }
		
        /// <summary>
        /// 商品区分詳細ガイド起動処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品区分詳細ガイドを起動します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.31</br>
        /// </remarks>
        private void DetailGoodsGanreCodeGuide()
        {
            DGoodsGanre dGoodsGanre = null;

            if (this._dGoodsGanreAcs.ExecuteGuid(this._enterpriseCode, out dGoodsGanre, 1) == 0)
            {
                // 変更が無ければ処理しない
                if (string.Equals(dGoodsGanre.DetailGoodsGanreCode, this._searchRate.DetailGoodsGanreCode) == true)
                {
                    return;
                }

                DispSetStatus dispSetStatus = editChgDataChk("商品コード", dGoodsGanre.DetailGoodsGanreCode, this._searchRate.DetailGoodsGanreCode);
                if (dispSetStatus == DispSetStatus.Update)
                {
                    // 商品区分グループコード
                    this.LargeGoodsGanreCode_Grp_tEdit.Text = dGoodsGanre.LargeGoodsGanreCode;
                    this.LargeGoodsGanreCodeNm_Grp_tEdit.Text = dGoodsGanre.LargeGoodsGanreName;
                    // 商品区分
                    this.MediumGoodsGanreCode_Grp_tEdit.Text = dGoodsGanre.MediumGoodsGanreCode;
                    this.MediumGoodsGanreCodeNm_Grp_tEdit.Text = dGoodsGanre.MediumGoodsGanreName;
                    // 商品区分詳細
                    this.DetailGoodsGanreCode_Grp_tEdit.Text = dGoodsGanre.DetailGoodsGanreCode;
                    this.DetailGoodsGanreCodeNm_Grp_tEdit.Text = dGoodsGanre.DetailGoodsGanreName;

                    // 現在データ保存
                    this._searchRate.LargeGoodsGanreCode = this.LargeGoodsGanreCode_Grp_tEdit.Text;
                    this._searchRate.MediumGoodsGanreCode = this.MediumGoodsGanreCode_Grp_tEdit.Text;
                    this._searchRate.DetailGoodsGanreCode = this.DetailGoodsGanreCode_Grp_tEdit.Text;
                }
            }
            else
            {
                // 商品区分詳細クリア
                this.DetailGoodsGanreCode_Grp_tEdit.Clear();
                this.DetailGoodsGanreCodeNm_Grp_tEdit.Clear();

                // 現在データクリア
                this._searchRate.DetailGoodsGanreCode = "";
            }
        }

        //----- ueno del ---------- start 2008.03.31
        ////----- ueno add ---------- start 2008.03.28
        ///// <summary>
        ///// 拠点コードゼロ埋め処理
        ///// </summary>
        ///// <param name="rateSectionCode_tEdit">拠点コード</param>
        ///// <remarks>
        ///// <br>Note       : 拠点コードをゼロ埋めします。</br>
        ///// <br>Programer  : 30167 上野　弘貴</br>
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
        /// ゼロ埋め後テキスト取得処理実装
        /// </summary>
        /// <param name="fullText">入力済みテキスト</param>
        /// <param name="columnCount">入力可能桁数</param>
        /// <returns>ゼロ埋めしたテキスト</returns>
        /// <br>Note       : 文字列をゼロ埋めします。</br>
        /// <br>Programer  : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.03.31</br>
        private static string GetZeroPaddedTextProc(string fullText, int columnCount)
        {
            if (fullText.Trim() != string.Empty)
            {
                // ゼロ詰め処理
                return fullText.PadLeft(columnCount, '0');
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 文字列→数値変換
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
        /// ゼロ埋めキャンセル後テキスト取得処理実装
        /// </summary>
        /// <param name="fullText">入力済みテキスト</param>
        /// <returns>ゼロ埋めキャンセルしたテキスト</returns>
        /// <br>Note       : 文字列からゼロを削除します。</br>
        /// <br>Programer  : 30167 上野　弘貴</br>
        /// <br>Date       : 2008.03.31</br>
        private static string GetZeroPadCanceledTextProc(string fullText)
        {
            if (fullText.Trim() != string.Empty)
            {
                int cnt = 0;
                string wkStr = fullText;

                // 先頭のゼロ詰めを削除
                while (fullText.StartsWith("0"))
                {
                    fullText = fullText.Substring(1, fullText.Length - 1);
                    cnt++;
                }

                // オールゼロの場合、共通コードとする
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
        // コントロールイベント
        // ===================================================================================== //
        #region Control Events

        /// <summary>Form.Load イベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.05</br>
        /// </remarks>
        private void DCKHN09160UA_Load(object sender, System.EventArgs e)
        {	
            // アイコンを表示する
            ImageList imageList16 = IconResourceManagement.ImageList16;
            ImageList imageList24 = IconResourceManagement.ImageList24;
			
            // 制御ボタンアイコン
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
			
            // ガイドアイコン
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
			
            // 画面初期設定
            ScreenInitialSetting();

            // ロット画面設定
            ScreenInitialSettingLot();
			
            // タブコントロールリスト作成
            SetTabControlList();
			
            // 画面クリア
            ScreenClear();
			
            // 画面構築
            ScreenReconstruction();

            // イベント発動
            this.Rate_uTabControl.SelectedTabChanging += new Infragistics.Win.UltraWinTabControl.SelectedTabChangingEventHandler(this.Rate_uTabControl_SelectedTabChanging);
        }

        /// <summary>
        /// UnitPriceKind_tComboEditor_SelectionChangeCommittedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 単価種類コンボボックスが変化ときに発生します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
        /// UnitPriceKindWay_tComboEditor_SelectionChangeCommittedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 設定方法コンボボックスが変化ときに発生します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
        /// 自社分類変更
        /// </summary>
        /// <param name="enterpriseGanreCode">自社分類コード</param>
        /// <remarks>
        /// <br>Note　     : 自社分類の選択を変更したときに発生します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void EnterpriseGanreCodeVisibleChange(int enterpriseGanreCode)
        {
            if (this._searchRate.EnterpriseGanreCode == enterpriseGanreCode) return;

            this._searchRate.EnterpriseGanreCode = enterpriseGanreCode;
        }

        /// <summary>
        /// 得意先掛率変更
        /// </summary>
        /// <param name="custRateGrpCode">得意先掛率コード</param>
        /// <remarks>
        /// <br>Note　     : 得意先掛率の選択を変更したときに発生します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void CustRateGrpCodeVisibleChange(int custRateGrpCode)
        {
            if (this._searchRate.CustRateGrpCode == custRateGrpCode) return;

            this._searchRate.CustRateGrpCode = custRateGrpCode;
        }

        /// <summary>
        /// 仕入先掛率変更
        /// </summary>
        /// <param name="suppRateGrpCode">仕入先掛率コード</param>
        /// <remarks>
        /// <br>Note　     : 仕入先掛率の選択を変更したときに発生します。</br>
        /// <br>Programmer : 30167 上野 弘貴</br>
        /// <br>Date       : 2008.01.10</br>
        /// </remarks>
        private void SuppRateGrpCodeVisibleChange(int suppRateGrpCode)
        {
            if (this._searchRate.SuppRateGrpCode == suppRateGrpCode) return;

            this._searchRate.SuppRateGrpCode = suppRateGrpCode;
        }

        /// <summary>Control.ChangeFocus イベント</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : フォーカス移動時に発生します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <param name="prevCtrl">前のコントロール</param>
		/// <param name="nextCtrl">次のコントロール</param>
		/// <param name="key">キー</param>
		/// <param name="shiftKey">シフトキー</param>
		/// <remarks>
		/// <br>Note       : Control.ChangeFocusイベント発生時に処理します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
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
			// 編集前イベント一時停止
			this.RateSectionCode_tEdit.BeforeEnterEditMode -= this.RateSectionCode_tEdit_BeforeEnterEditMode;
			//----- ueno add ---------- end 2008.03.31
			
			switch (prevCtrl.Name)
			{
				//------------------
				// 掛率設定条件部分
				//------------------
				#region case 拠点コード
				case "RateSectionCode_tEdit":
					{
						// 画面データ、ワークデータともに未入力時は処理しない
						if ((this.RateSectionCode_tEdit.Text == "") && (this._searchRate.SectionCode == ""))
						{
							break;
						}

						//----- ueno add ---------- start 2008.03.31
						// 拠点コードゼロ埋め対応（ゼロデータを有効にする）
						if (this.RateSectionCode_tEdit.Text != "")
						{
							this.RateSectionCode_tEdit.Text = GetZeroPaddedTextProc(this.RateSectionCode_tEdit.Text, this.RateSectionCode_tEdit.ExtEdit.Column);
							
							// ワークデータもゼロ埋めする
							this._searchRate.SectionCode = GetZeroPaddedTextProc(this._searchRate.SectionCode, this.RateSectionCode_tEdit.ExtEdit.Column);
						}
						//----- ueno add ---------- end 2008.03.31
						
						// 条件設定
						inParamObj = this.RateSectionCode_tEdit.Text;

						// 存在チェック
						switch (CheckSectionCode(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// 値変更チェック
									if (this.RateSectionCode_tEdit.Text != this._searchRate.SectionCode)
									{
										dispSetStatus = editChgDataChk("拠点コード", this.RateSectionCode_tEdit.Text, this._searchRate.SectionCode);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("拠点コード");
									dispSetStatus = this._searchRate.SectionCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						
						// データ設定
						DispSetSectionCode(dispSetStatus, ref canChangeFocus, outParamObj);

						//--------------------------------
						// 拠点コード関連項目クリア処理
						//--------------------------------
						// 画面データ、ワークデータともに未入力時は全て削除する
						if ((this.RateSectionCode_tEdit.Text == "") && (this._searchRate.SectionCode == ""))
						{
							SectionCodeVisibleChange();
						}

						// 検索前の場合
						if ((this._AllCtrlInputStatus == AllCtrlInputStatus.New)
							|| (this._AllCtrlInputStatus == AllCtrlInputStatus.InputCondition))
						{
							// 掛率条件入力エラーチェック
							InpRateCondCheck();
						}
						break;
					}
				#endregion

				#region case 単価種類
				case "UnitPriceKind_tComboEditor":
					{
						if (this.UnitPriceKind_tComboEditor.Value != null)
						{
							// イベント停止
							this.UnitPriceKind_tComboEditor.SelectionChangeCommitted -= new EventHandler(this.UnitPriceKind_tComboEditor_SelectionChangeCommitted);

							UnitPriceKindVisibleChange((Int32)this.UnitPriceKind_tComboEditor.Value);

							// イベント発動
							this.UnitPriceKind_tComboEditor.SelectionChangeCommitted += new EventHandler(this.UnitPriceKind_tComboEditor_SelectionChangeCommitted);
						}

						// 検索前の場合
						if ((this._AllCtrlInputStatus == AllCtrlInputStatus.New)
							|| (this._AllCtrlInputStatus == AllCtrlInputStatus.InputCondition))
						{
							// 掛率条件入力エラーチェック
							InpRateCondCheck();
						}
						break;
					}
				#endregion

				#region case 設定方法
				case "UnitPriceKindWay_tComboEditor":
					{
						if (this.UnitPriceKindWay_tComboEditor.Value != null)
						{
							// イベント停止
							this.UnitPriceKindWay_tComboEditor.SelectionChangeCommitted -= new EventHandler(this.UnitPriceKindWay_tComboEditor_SelectionChangeCommitted);

							UnitPriceKindWayVisibleChange((Int32)this.UnitPriceKindWay_tComboEditor.Value);

							// イベント発動
							this.UnitPriceKindWay_tComboEditor.SelectionChangeCommitted += new EventHandler(this.UnitPriceKindWay_tComboEditor_SelectionChangeCommitted);
						}

						// 検索前の場合
						if ((this._AllCtrlInputStatus == AllCtrlInputStatus.New)
							|| (this._AllCtrlInputStatus == AllCtrlInputStatus.InputCondition))
						{
							// 掛率条件入力エラーチェック
							InpRateCondCheck();
						}
						break;
					}
				#endregion

				#region case 掛率設定区分
				case "RateSettingDivide_tEdit":
					{
						// 画面データ、ワークデータともに未入力時は処理しない
						if ((this.RateSettingDivide_tEdit.Text == "")&&(this._searchRate.RateSettingDivide == ""))
						{
							break;
						}

						// 拠点コード入力チェック
						if (this.RateSectionCode_tEdit.Text == "")
						{
							ShowInpErrMsg("拠点コードを入力してください。");
							canChangeFocus = false;
							prevCtrl = this.RateSectionCode_tEdit;

							// 掛率設定区分クリア
							this.RateSettingDivide_tEdit.Clear();
							this.RateMngGoodsCd_tEdit.Clear();
							this.RateMngGoodsNm_tEdit.Clear();
							this.RateMngCustCd_tEdit.Clear();
							this.RateMngCustNm_tEdit.Clear();

							// 現在データクリア
							this._searchRate.RateSettingDivide = "";
							this._searchRate.RateMngGoodsCd = "";
							this._searchRate.RateMngGoodsNm = "";
							this._searchRate.RateMngCustCd = "";
							this._searchRate.RateMngCustNm = "";
							break;
						}
						
						// 条件設定
						inParamList.Add(this.RateSectionCode_tEdit.Text);
						inParamList.Add(NullChgInt(this.UnitPriceKind_tComboEditor.Value));
						inParamList.Add(NullChgInt(this.UnitPriceKindWay_tComboEditor.Value));
						inParamList.Add(this.RateSettingDivide_tEdit.Text);
						inParamObj = inParamList;
						
						// 存在チェック
						switch(CheckRateSettingDivide(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// 値変更チェック
									if (this.RateSettingDivide_tEdit.Text != this._searchRate.RateSettingDivide)
									{
										dispSetStatus = editChgDataChk("掛率設定区分", this.RateSettingDivide_tEdit.Text, this._searchRate.RateSettingDivide);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("掛率設定区分");
									dispSetStatus = this._searchRate.RateSettingDivide == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}

						// データ設定
						DispSetRateSettingDivide(dispSetStatus, ref canChangeFocus, outParamObj);

						//--------------------------------
						// 掛率設定区分関連項目クリア処理
						//--------------------------------
						// 画面データ、ワークデータともに未入力時は全て削除する
						if ((this.RateSettingDivide_tEdit.Text == "")&&(this._searchRate.RateSettingDivide == ""))
						{
							RateSettingDivideVisibleChange();
						}

						// 検索前の場合
						if ((this._AllCtrlInputStatus == AllCtrlInputStatus.New)
							|| (this._AllCtrlInputStatus == AllCtrlInputStatus.InputCondition))
						{
							// 掛率条件入力エラーチェック
							InpRateCondCheck();
						}
						break;
					}
				#endregion

				//------------------------------
				// 単品, Ｇ商品, 取引先条件部分
				//------------------------------
				#region case メーカーコード（単品）
				case "GoodsMakerCd_tNedit":
					{
						// 画面データ、ワークデータともに未入力時は処理しない
						if ((this.GoodsMakerCd_tNedit.Text == "") && (this._searchRate.GoodsMakerCd == 0))
						{
							break;
						}
						
						// ゼロデータチェック処理
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

						// 条件設定
						inParamObj = this.GoodsMakerCd_tNedit.GetInt();

						// 存在チェック
						switch (CheckGoodsMakerCd(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// 値変更チェック
									if (this.GoodsMakerCd_tNedit.GetInt() != this._searchRate.GoodsMakerCd)
									{
										dispSetStatus = editChgDataChk("メーカーコード（単品）", this.GoodsMakerCd_tNedit.GetInt(), this._searchRate.GoodsMakerCd);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("メーカーコード（単品）");
									dispSetStatus = this._searchRate.GoodsMakerCd == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetGoodsMakerCd(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case メーカーコード
				case "GoodsMakerCd_Grp_tNedit":
					{
						// 画面データ、ワークデータともに未入力時は処理しない
						if ((this.GoodsMakerCd_Grp_tNedit.Text == "") && (this._searchRate.GoodsMakerCd == 0))
						{
							break;
						}

						// ゼロデータチェック処理
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

						// 条件設定
						inParamObj = this.GoodsMakerCd_Grp_tNedit.GetInt();

						// 存在チェック
						switch (CheckGoodsMakerCd(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// 値変更チェック
									if (this.GoodsMakerCd_Grp_tNedit.GetInt() != this._searchRate.GoodsMakerCd)
									{
										dispSetStatus = editChgDataChk("メーカーコード", this.GoodsMakerCd_Grp_tNedit.GetInt(), this._searchRate.GoodsMakerCd);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("メーカーコード");
									dispSetStatus = this._searchRate.GoodsMakerCd == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetGoodsMakerCdGrp(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case 商品掛率ランク
				case "GoodsRateRankCd_Grp_tEdit":
					{
						// 画面データ、ワークデータともに未入力時は処理しない
						if ((this.GoodsRateRankCd_Grp_tEdit.Text == "") && (this._searchRate.GoodsRateRank == ""))
						{
							break;
						}
						
						outParamObj = this.GoodsRateRankCd_Grp_tEdit.Text;
						
						// データ設定
						DispSetGoodsRateRankCd(DispSetStatus.Update, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case 商品コード
				case "GoodsNoCd_tEdit":
					{
						// 画面データ、ワークデータともに未入力時は処理しない
						if ((this.GoodsNoCd_tEdit.Text == "") && (this._searchRate.GoodsNo == ""))
						{
							break;
						}

						// 条件設定
						inParamList.Add(this.GoodsMakerCd_tNedit.GetInt());
						inParamList.Add(this.GoodsNoCd_tEdit.Text);
						inParamObj = inParamList;

						// 存在チェック
						switch(CheckGoodsNoCd(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// 値変更チェック
									if (this.GoodsNoCd_tEdit.Text != this._searchRate.GoodsNo)
									{
										dispSetStatus = editChgDataChk("商品コード", this.GoodsNoCd_tEdit.Text, this._searchRate.GoodsNo);
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
									ShowNotFoundErrMsg("商品コード");
									dispSetStatus = this._searchRate.GoodsNo == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetGoodsNoCd(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case 商品区分グループコード
				case "LargeGoodsGanreCode_Grp_tEdit":
					{
						// 画面データ、ワークデータともに未入力時は処理しない
						if ((this.LargeGoodsGanreCode_Grp_tEdit.Text == "") && (this._searchRate.LargeGoodsGanreCode == ""))
						{
							break;
						}
						
						// 条件設定
						inParamObj = this.LargeGoodsGanreCode_Grp_tEdit.Text;
						
						// 存在チェック
						switch(CheckLargeGoodsGanreCodeGrp(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// 値変更チェック
									if (this.LargeGoodsGanreCode_Grp_tEdit.Text != this._searchRate.LargeGoodsGanreCode)
									{
										dispSetStatus = editChgDataChk("商品区分グループコード", this.LargeGoodsGanreCode_Grp_tEdit.Text, this._searchRate.LargeGoodsGanreCode);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("商品区分グループコード");
									dispSetStatus = this._searchRate.LargeGoodsGanreCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}								
						}
						// データ設定
						DispSetLargeGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case 商品区分コード
				case "MediumGoodsGanreCode_Grp_tEdit":
					{
						// 画面データ、ワークデータともに未入力時は処理しない
						if ((this.MediumGoodsGanreCode_Grp_tEdit.Text == "") && (this._searchRate.MediumGoodsGanreCode == ""))
						{
							break;
						}

						// 条件設定
						inParamList.Add(this.LargeGoodsGanreCode_Grp_tEdit.Text);
						inParamList.Add(this.MediumGoodsGanreCode_Grp_tEdit.Text);
						inParamObj = inParamList;

						// 存在チェック
						switch (CheckMediumGoodsGanreCodeGrp(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// 値変更チェック
									if (this.MediumGoodsGanreCode_Grp_tEdit.Text != this._searchRate.MediumGoodsGanreCode)
									{
										dispSetStatus = editChgDataChk("商品区分コード", this.MediumGoodsGanreCode_Grp_tEdit.Text, this._searchRate.MediumGoodsGanreCode);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("商品区分コード");
									dispSetStatus = this._searchRate.MediumGoodsGanreCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetMediumGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case 商品区分詳細コード
				case "DetailGoodsGanreCode_Grp_tEdit":
					{
						// 画面データ、ワークデータともに未入力時は処理しない
						if ((this.DetailGoodsGanreCode_Grp_tEdit.Text == "") && (this._searchRate.DetailGoodsGanreCode == ""))
						{
							break;
						}

						// 条件設定
						inParamList.Add(this.LargeGoodsGanreCode_Grp_tEdit.Text);
						inParamList.Add(this.MediumGoodsGanreCode_Grp_tEdit.Text);
						inParamList.Add(this.DetailGoodsGanreCode_Grp_tEdit.Text);
						inParamObj = inParamList;

						// 存在チェック
						switch (CheckDetailGoodsGanreCodeGrp(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// 値変更チェック
									if (this.DetailGoodsGanreCode_Grp_tEdit.Text != this._searchRate.DetailGoodsGanreCode)
									{
										dispSetStatus = editChgDataChk("商品区分詳細コード", this.DetailGoodsGanreCode_Grp_tEdit.Text, this._searchRate.DetailGoodsGanreCode);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("商品区分詳細コード");
									dispSetStatus = this._searchRate.DetailGoodsGanreCode == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetDetailGoodsGanreCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case 自社分類コード（エラーチェック無し）
				case "EnterpriseGanreCode_Grp_tComboEditor":
					{
						break;
					}
				#endregion

				#region case ＢＬ商品コード
				case "BLGoodsCode_Grp_tNedit":
					{
						// 画面データ、ワークデータともに未入力時は処理しない
						if ((this.BLGoodsCode_Grp_tNedit.Text == "") && (this._searchRate.BLGoodsCode == 0))
						{
							break;
						}
					
						// ゼロデータチェック処理
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

						// 条件設定
						inParamObj = this.BLGoodsCode_Grp_tNedit.GetInt();

						// 存在チェック
						switch (CheckBLGoodsCodeGrp(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// 値変更チェック
									if (this.BLGoodsCode_Grp_tNedit.GetInt() != this._searchRate.BLGoodsCode)
									{
										dispSetStatus = editChgDataChk("ＢＬ商品コード", this.BLGoodsCode_Grp_tNedit.GetInt(), this._searchRate.BLGoodsCode);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("ＢＬ商品コード");
									dispSetStatus = this._searchRate.BLGoodsCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetBLGoodsCodeGrp(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case 得意先コード
				case "CustomerCode_tNedit":
					{
						// 画面データ、ワークデータともに未入力時は処理しない
						if ((this.CustomerCode_tNedit.Text == "") && (this._searchRate.CustomerCode == 0))
						{
							break;
						}
					
						// ゼロデータチェック処理
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

						// 条件設定
						inParamObj = this.CustomerCode_tNedit.GetInt();

						// 存在チェック
						switch (CheckCustomerCode(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// 値変更チェック
									if (this.CustomerCode_tNedit.GetInt() != this._searchRate.CustomerCode)
									{
										dispSetStatus = editChgDataChk("得意先コード", this.CustomerCode_tNedit.GetInt(), this._searchRate.CustomerCode);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("得意先コード");
									dispSetStatus = this._searchRate.CustomerCode == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetCustomerCode(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case 得意先掛率グループコード（エラーチェック無し）
				case "CustRateGrpCode_tComboEditor":
					{
						break;
					}
				#endregion

				#region case 仕入先コード
				case "SupplierCd_tNedit":
					{
						// 画面データ、ワークデータともに未入力時は処理しない
						if ((this.SupplierCd_tNedit.Text == "") && (this._searchRate.SupplierCd == 0))
						{
							break;
						}
						
						// ゼロデータチェック処理
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

						// 条件設定
						inParamObj = this.SupplierCd_tNedit.GetInt();

						// 存在チェック
						switch (CheckSupplierCd(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
							case (int)InputChkStatus.NotInput:
								{
									// 値変更チェック
									if (this.SupplierCd_tNedit.GetInt() != this._searchRate.SupplierCd)
									{
										dispSetStatus = editChgDataChk("仕入先コード", this.SupplierCd_tNedit.GetInt(), this._searchRate.SupplierCd);
									}
									else
									{
										dispSetStatus = DispSetStatus.Update;
									}
									break;
								}
							default:
								{
									ShowNotFoundErrMsg("仕入先コード");
									dispSetStatus = this._searchRate.SupplierCd == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// データ設定
						DispSetSupplierCd(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
					}
				#endregion

				#region case 仕入先掛率グループコード（エラーチェック無し）
				case "SuppRateGrpCode_tComboEditor":
					{
						break;
					}
				#endregion

				//--------------
				// 掛率設定部分
				//--------------
				#region case 新掛率開始日
				case "NewRateStartDate_tDateEdit":
					{
						// 未入力なら処理しない
						if ((this.NewRateStartDate_tDateEdit.GetDateYear() == 0)
							|| (this.NewRateStartDate_tDateEdit.GetDateMonth() == 0)
							|| (this.NewRateStartDate_tDateEdit.GetDateDay() == 0))
						{
							break;
						}

						// ロット画面の掛率開始日に反映
						this.LotNewRateStartDate_tDateEdit.SetDateTime(this.NewRateStartDate_tDateEdit.GetDateTime());

						// 項目比較
						string hashKey = OLDNEWDIVCD_NEW + "000000000.00";

						if (this._rateSrchRsltHashList.ContainsKey(hashKey) == true)
						{
							Rate rateWk = (Rate)this._rateSrchRsltHashList[hashKey];

							// 変更有り
							if (rateWk.RateStartDate != this.NewRateStartDate_tDateEdit.GetDateTime())
							{
								// 保存を押下するまでロット設定無効
								this.Lot_uTabPageControl.Enabled = false;
							}
							// 変更無し
							else
							{
								this.Lot_uTabPageControl.Enabled = true;
							}
						}
						break;
					}
				#endregion

				#region case 旧掛率開始日
				case "OldRateStartDate_tDateEdit":
					{
						// 未入力なら処理しない
						if ((this.OldRateStartDate_tDateEdit.GetDateYear() == 0)
							|| (this.OldRateStartDate_tDateEdit.GetDateMonth() == 0)
							|| (this.OldRateStartDate_tDateEdit.GetDateDay() == 0))
						{
							break;
						}

						// ロット画面の掛率開始日に反映
						this.LotOldRateStartDate_tDateEdit.SetDateTime(this.OldRateStartDate_tDateEdit.GetDateTime());

						// 項目比較
						string hashKey = OLDNEWDIVCD_OLD + "000000000.00";

						if (this._rateSrchRsltHashList.ContainsKey(hashKey))
						{
							Rate rateWk = (Rate)this._rateSrchRsltHashList[hashKey];

							if (rateWk.RateStartDate != this.OldRateStartDate_tDateEdit.GetDateTime())
							{
								// 保存を押下するまでロット設定無効
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
				// 新旧ロットグリッド制御
				//------------------------
				#region case 新旧ロットグリッド制御
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

						// GridにControlがある時のReturn/Tabの動き設定
						if (prevCtrl == uGrid)
						{
							// リターンキーの時
							if ((key == Keys.Return) || (key == Keys.Tab))
							{
								nextCtrl = null;

								if (uGrid.ActiveCell != null)
								{
									// 最終セルの時
									if ((uGrid.ActiveCell.Row.Index == uGrid.Rows.Count - 1) &&
										(uGrid.ActiveCell.Column.Index == uGrid.DisplayLayout.Bands[0].Columns[LOT_BARGAINCD].Index))
									{
										// 新旧掛率設定ボタンにフォーカス遷移
										nextCtrl = this.LotOldNewRateStartDate_uButton;
									}
									else
									{
										// 「特売」の場合は次のRowに
										if (uGrid.ActiveCell.Column.Index == uGrid.DisplayLayout.Bands[0].Columns[LOT_BARGAINCD].Index)
										{
											// 次のRowにフォーカス遷移
											uGrid.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.NextRow);
											uGrid.PerformAction(UltraGridAction.EnterEditMode);
										}
										else
										{
											// 次のCellにフォーカス遷移
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
			// フォーカス制御
			//===========================
			#region フォーカス制御
			//----------
			// 掛率画面
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
					// 現在の項目から移動せず、テキスト全選択状態とする
					nextCtrl.Select();
					//----- ueno add ---------- end 2008.03.07

					//----- ueno add ---------- start 2008.03.31
					if (this.RateSectionCode_tEdit.Focused == true)
					{
						// 先頭のゼロ詰めを削除
						this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
					}
					//----- ueno add ---------- end 2008.03.31
				}
			}
			//------------
			// ロット画面
			//------------
			else
			{
				// リターンキーの時
				if ((key == Keys.Return) || (key == Keys.Tab))
				{
					// 現在有効なロットテーブル取得
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
			#endregion フォーカス制御

			//----- ueno add ---------- start 2008.03.31
			// 編集前イベント再開
			this.RateSectionCode_tEdit.BeforeEnterEditMode += new System.ComponentModel.CancelEventHandler(this.RateSectionCode_tEdit_BeforeEnterEditMode);
			//----- ueno add ---------- end 2008.03.31
		}
        
        /// <summary>掛率保存ボタンイベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 掛率保存ボタンが選択された時に発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.05</br>
		/// </remarks>
		private void Rate_Ok_Button_Click(object sender, EventArgs e)
		{
			int oldSaveFlag = 0;		// 旧掛率設定有無（0:設定無し, 1:設定有り）
			int oldDataDelFlag = 0;		// 旧掛率データ削除要否（0:否, 1:要）
			
			// 入力データエラーチェック
			if (InpRateDataCheck(ref oldSaveFlag, ref oldDataDelFlag) == true)
			{
				// 旧掛率データ物理削除処理
				if (oldDataDelFlag == 1)
				{
					// 旧掛率削除確認
					DialogResult result = TMsgDisp.Show(
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
						ASSEMBLY_ID,   						// アセンブリＩＤまたはクラスＩＤ
						PHY_OLDDEL_MSG,						// 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.YesNo, 			// 表示するボタン
						MessageBoxDefaultButton.Button2);	// 初期表示ボタン
					
					if (result == DialogResult.Yes)
					{
						// 旧掛率データ物理削除
						PhysicalDeleteOldRate();
					}
					else
					{
						// ハッシュキー作成
						string hashKey = OLDNEWDIVCD_OLD + "000000000.00";
						
						if (this._rateSrchRsltHashList.ContainsKey(hashKey) == true)
						{
							Rate rateWk = (Rate)this._rateSrchRsltHashList[hashKey];
							
							// 旧掛率設定項目のデータを戻す
							this.OldPrice_tNedit.SetValue(rateWk.PriceFl);
							this.OldRate_tNedit.SetValue(rateWk.RateVal);
							this.OldUnPrcFracProcUnit_tNedit.SetValue(rateWk.UnPrcFracProcUnit);
						}
					}
				}
				
				// 書き込み処理
				if (SaveProc(ref oldSaveFlag) == true)
				{
					// 全体入力コントロール（ロット制限解除）
					SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.SearchUpdate.GetHashCode());
					this._AllCtrlInputStatus = AllCtrlInputStatus.SearchUpdate;
				}
			}

			//----- ueno add ---------- start 2008.03.31
			if (this.RateSectionCode_tEdit.Focused == true)
			{
				// 先頭のゼロ詰めを削除
				this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
			}
			//----- ueno add ---------- end 2008.03.31
		}

		/// <summary>Rate_Clear_Btn_Click</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : クリアボタン押下時に実行します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.10</br>
		/// </remarks>
		private void Rate_Clear_Btn_Click(object sender, EventArgs e)
		{
			// 確認メッセージ出力
			if (ShowConfirmMsg(DISP_CLR_MSG, emErrorLevel.ERR_LEVEL_INFO) == true)
			{
				ScreenClear();
				
				// 拠点コードにフォーカス設定
				this.RateSectionCode_tEdit.Focus();
			}
		}

		/// <summary>Rate_LogicalDelBtn_Click</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 削除ボタン押下時に実行します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.19</br>
		/// </remarks>
		private void Rate_LogicalDelBtn_Click(object sender, EventArgs e)
		{
			// 未入力項目があれば以下処理しない
			if (InpCondDataCheck() == false)
			{
				//----- ueno add ---------- start 2008.03.31
				if (this.RateSectionCode_tEdit.Focused == true)
				{
					// 先頭のゼロ詰めを削除
					this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
				}
				//----- ueno add ---------- end 2008.03.31

				return;
			}
			
			// 確認メッセージ出力
			if (ShowConfirmMsg(LOG_OLDDEL_MSG, emErrorLevel.ERR_LEVEL_INFO) == true)
			{
				// 論理削除
				if (LogicalDeleteRate() == 0)
				{
					// 全体入力コントロール
					SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.SearchDelete.GetHashCode());
					this._AllCtrlInputStatus = AllCtrlInputStatus.SearchDelete;
					
					// 削除モードに変更
					this.Mode_Label.Text = DELETE_MODE;

					// 論理削除メッセージ
					TMsgDisp.Show(this,							// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_INFO,			// エラーレベル
						ASSEMBLY_ID,							// アセンブリID
						LDEL_INFO_MSG,							// 表示するメッセージ
						0,										// ステータス値
						MessageBoxButtons.OK);					// 表示するボタン
				}
			}

			//----- ueno add ---------- start 2008.03.31
			if (this.RateSectionCode_tEdit.Focused == true)
			{
				// 先頭のゼロ詰めを削除
				this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
			}
			//----- ueno add ---------- end 2008.03.31
		}

		/// <summary>Rate_PhysicalDelBtn_Click</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 完全削除ボタン押下時に実行します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.19</br>
		/// </remarks>
		private void Rate_PhysicalDelBtn_Click(object sender, EventArgs e)
		{
			// 未入力項目があれば以下処理しない
			if (InpCondDataCheck() == false)
			{
				//----- ueno add ---------- start 2008.03.31
				if (this.RateSectionCode_tEdit.Focused == true)
				{
					// 先頭のゼロ詰めを削除
					this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
				}
				//----- ueno add ---------- end 2008.03.31
			
				return;
			}
			
			// 物理削除確認
			DialogResult result = TMsgDisp.Show(
				this, 								// 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
				ASSEMBLY_ID,   						// アセンブリＩＤまたはクラスＩＤ
				PHY_DEL_MSG,						// 表示するメッセージ
				0, 									// ステータス値
				MessageBoxButtons.YesNo, 			// 表示するボタン
				MessageBoxDefaultButton.Button2);	// 初期表示ボタン

			if(result == DialogResult.Yes)
			{
				// 物理削除
				if (PhysicalDeleteRate() == 0)
				{
					// 全体入力コントロール
					SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.InputCondition.GetHashCode());
					this._AllCtrlInputStatus = AllCtrlInputStatus.InputCondition;
					
					// 新規モードに変更
					this.Mode_Label.Text = INSERT_MODE;
					
					// 掛率設定データクリア
					// 新掛率設定項目
					this.NewRateStartDate_tDateEdit.SetToday();		// 掛率開始日
					this.NewPrice_tNedit.Clear();					// 単価
					this.NewRate_tNedit.Clear();					// 掛率
					this.NewUnPrcFracProcUnit_tNedit.Clear();		// 単価端数処理単位

					// 旧掛率設定項目
					this.OldPrice_tNedit.Clear();					// 単価
					this.OldRate_tNedit.Clear();					// 掛率
					this.OldUnPrcFracProcUnit_tNedit.Clear();		// 単価端数処理単位

					// 物理削除メッセージ
					TMsgDisp.Show(this,							// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_INFO,			// エラーレベル
						ASSEMBLY_ID,							// アセンブリID
						PDEL_INFO_MSG,							// 表示するメッセージ
						0,										// ステータス値
						MessageBoxButtons.OK);					// 表示するボタン
				}
			}

			//----- ueno add ---------- start 2008.03.31
			if (this.RateSectionCode_tEdit.Focused == true)
			{
				// 先頭のゼロ詰めを削除
				this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
			}
			//----- ueno add ---------- end 2008.03.31
		}

		/// <summary>Rate_ReviveBtn_Click</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 復活ボタン押下時に実行します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.19</br>
		/// </remarks>
		private void Rate_ReviveBtn_Click(object sender, EventArgs e)
		{
			// 未入力項目があれば以下処理しない
			if (InpCondDataCheck() == false)
			{
				//----- ueno add ---------- start 2008.03.31
				if (this.RateSectionCode_tEdit.Focused == true)
				{
					// 先頭のゼロ詰めを削除
					this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
				}
				//----- ueno add ---------- end 2008.03.31
			
				return;
			}
			
			// 復活
			if (ReviveRate() == 0)
			{
				// 全体入力コントロール
				SettingAllInpCtrl(AllCtrlActiveTab.Rate.GetHashCode(), AllCtrlInputStatus.SearchUpdate.GetHashCode());
				this._AllCtrlInputStatus = AllCtrlInputStatus.SearchUpdate;
				
				// 更新モードに変更
				this.Mode_Label.Text = UPDATE_MODE;

				// 復活メッセージ
				TMsgDisp.Show(this,							// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_INFO,			// エラーレベル
					ASSEMBLY_ID,							// アセンブリID
					REV_INFO_MSG,							// 表示するメッセージ
					0,										// ステータス値
					MessageBoxButtons.OK);					// 表示するボタン
			}

			//----- ueno add ---------- start 2008.03.31
			if (this.RateSectionCode_tEdit.Focused == true)
			{
				// 先頭のゼロ詰めを削除
				this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
			}
			//----- ueno add ---------- end 2008.03.31

		}

        /// <summary>閉じるボタンイベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 閉じるボタンが選択された時に発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.05</br>
		/// </remarks>
		private void Close_Button_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 閉じるボタンがクリックされたときに発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2008.01.08</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, EventArgs e)
		{
			if (CompareRateChange() == true)
			{
				// 画面情報が変更されていた場合は、保存確認メッセージを表示する
				DialogResult res = TMsgDisp.Show(
					this,								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
					ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
					"",									// 表示するメッセージ 
					0,									// ステータス値
					MessageBoxButtons.YesNoCancel);		// 表示するボタン

				switch (res)
				{
					case DialogResult.Yes:
						{
							int oldSaveFlag = 0;		// 旧掛率設定有無（0:設定無し, 1:設定有り）
							int oldDataDelFlag = 0;		// 旧掛率データ削除要否（0:否, 1:要）

							// 入力データエラーチェック
							if (InpRateDataCheck(ref oldSaveFlag, ref oldDataDelFlag) == true)
							{
								// 旧掛率データ物理削除処理
								if (oldDataDelFlag == 1)
								{
									// 旧掛率削除確認
									DialogResult result = TMsgDisp.Show(
										this, 								// 親ウィンドウフォーム
										emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
										ASSEMBLY_ID,   						// アセンブリＩＤまたはクラスＩＤ
										PHY_OLDDEL_MSG,						// 表示するメッセージ
										0, 									// ステータス値
										MessageBoxButtons.YesNo, 			// 表示するボタン
										MessageBoxDefaultButton.Button2);	// 初期表示ボタン

									if (result == DialogResult.Yes)
									{
										// 旧掛率データ物理削除
										PhysicalDeleteOldRate();
									}
									else
									{
										// ハッシュキー作成
										string hashKey = OLDNEWDIVCD_OLD + "000000000.00";

										if (this._rateSrchRsltHashList.ContainsKey(hashKey) == true)
										{
											Rate rateWk = (Rate)this._rateSrchRsltHashList[hashKey];

											// 旧掛率設定項目のデータを戻す
											this.OldPrice_tNedit.SetValue(rateWk.PriceFl);
											this.OldRate_tNedit.SetValue(rateWk.RateVal);
											this.OldUnPrcFracProcUnit_tNedit.SetValue(rateWk.UnPrcFracProcUnit);
										}
									}
								}

								// 書き込み処理
								if (SaveProc(ref oldSaveFlag) == true)
								{
									// 全体入力コントロール（ロット制限解除）
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
		/// Timer.Tick イベント イベント(Initial_Timer)(SF100%流用)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 指定された間隔の時間が経過したときに発生します。</br>
		///	<br>             この処理は、システムが提供するスレッド プール</br>
		///	<br>             スレッドで実行されます。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.03</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}

        /// <summary>タイマーイベント</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 終了処理時に実行します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.05</br>
		/// </remarks>
		private void Close_Timer_Tick(object sender, System.EventArgs e)
		{
			this.Close_Timer.Enabled = false;
		}

		/// <summary>CopyToOldFromNewbtn_Click</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 新掛率設定→旧掛率へ移動ボタン押下時に実行します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.05</br>
		/// </remarks>
		private void CopyToOldFromNewbtn_Click(object sender, EventArgs e)
		{
			// 確認メッセージ出力
			DialogResult res = TMsgDisp.Show(
				this, 								// 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_INFO,		// エラーレベル
				ASSEMBLY_ID,   						// アセンブリＩＤまたはクラスＩＤ
				RATE_CPY_MSG,						// 表示するメッセージ
				0, 									// ステータス値
				MessageBoxButtons.YesNo, 			// 表示するボタン
				MessageBoxDefaultButton.Button2);	// 初期表示ボタン

			if (res == DialogResult.Yes)
			{
				CopyToOldRateFromNewRate();
			}
		}

		/// <summary>Search_uButton_Click</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 検索押下時に実行します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.12</br>
		/// </remarks>
		private void Search_uButton_Click(object sender, EventArgs e)
		{
			// 掛率条件必須チェック
			if (InpRateCondCheck() == false)
			{
				RateSettingDivideVisibleChange();

				//----- ueno add ---------- start 2008.03.31
				if (this.RateSectionCode_tEdit.Focused == true)
				{
					// 先頭のゼロ詰めを削除
					this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
				}
				//----- ueno add ---------- end 2008.03.31

				return;
			}
			
			// 入力状況フラグ
			this._AllCtrlInputStatus = AllCtrlInputStatus.InputCondition;	// 条件入力
			
			// 入力条件制御
			SettingInpCond();

			// 入力条件必須チェック
			if (InpDataCheck() != 0)
			{
				InpRateCondCheck();
				SrchRsltDataClear();

				//----- ueno add ---------- start 2008.03.31
				if (this.RateSectionCode_tEdit.Focused == true)
				{
					// 先頭のゼロ詰めを削除
					this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
				}
				//----- ueno add ---------- end 2008.03.31

				return;
			}

			//---------------------------------------------------------------------------------
			// 入力データチェックは2度行う
			//   ショートカットキー使用時はワーククラスにデータがセットされていない状態なので
			//	 1回目の入力データチェックで、正常時にワーククラスへ入力データをセットする
			//   2回目の入力データチェックで、エラーを判定する
			//---------------------------------------------------------------------------------
			// 入力データチェック及びワーククラスへデータ格納
			InpCondDataCheck();
			
			// 入力データ全体チェック
			if (InpCondDataCheck() == false)
			{
				// 掛率条件入力エラーチェック
				InpRateCondCheck();
				SrchRsltDataClear();

				//----- ueno add ---------- start 2008.03.31
				if (this.RateSectionCode_tEdit.Focused == true)
				{
					// 先頭のゼロ詰めを削除
					this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
				}
				//----- ueno add ---------- end 2008.03.31

				return;
			}

			// 掛率入力制御
			SettingRateInpCond();
			
			// 掛率マスタ検索
			// データ存在チェック
			this.Cursor = Cursors.WaitCursor;
			RateSearch();

			//----- ueno add ---------- start 2008.03.31
			if (this.RateSectionCode_tEdit.Focused == true)
			{
				// 先頭のゼロ詰めを削除
				this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);
			}
			//----- ueno add ---------- end 2008.03.31

			this.Cursor = Cursors.Default;
		}

		/// <summary>Rate_uTabControl_SelectedTabChanging</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : タブ切替時に実行します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
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
						// 新ロットグリッド
						//------------------
						// ロット不正チェック
						foreach (UltraGridRow uRow in this.rateLotNew_ultraGrid.Rows)
						{
							if (InpLotDataCheck(uRow, out message, out uGridCell) == false)
							{
								// エラー発生時は新ロットグリッドへ切り替え
								this.LotOldNewRateStartDate_uButton.Text = RATE_NEW;
								OldNewRateChange(false);

								// エラー行にフォーカスセット
								if (uGridCell != null)
								{
									uGridCell.Activate();
								}

								// エラーメッセージ出力
								ShowInpErrMsg(message);
								e.Cancel = true;
								return;
							}
						}

						// 同一ロットチェック
						int index = 0; // 重複行の先頭
						if (InpLotDuplicateCheck(ref this._dataTableLotNew, ref this.rateLotNew_ultraGrid, ref index) == false)
						{
							// エラー発生時は新ロットグリッドへ切り替え
							this.LotOldNewRateStartDate_uButton.Text = RATE_NEW;
							OldNewRateChange(false);

							// エラー行にフォーカスセット
							this.rateLotNew_ultraGrid.Rows[index].Cells[LOT_LOTCOUNT].Activate();

							// エラーメッセージ出力
							ShowInpErrMsg(LOT_DUP_MSG);
							e.Cancel = true;
							return;
						}

						//------------------
						// 旧ロットグリッド
						//------------------
						// ロット不正チェック
						foreach (UltraGridRow uRow in this.rateLotOld_ultraGrid.Rows)
						{
							if (InpLotDataCheck(uRow, out message, out uGridCell) == false)
							{
								// エラー発生時は旧ロットグリッドへ切り替え
								this.LotOldNewRateStartDate_uButton.Text = RATE_OLD;
								OldNewRateChange(false);

								// エラー行にフォーカスセット
								if (uGridCell != null)
								{
									uGridCell.Activate();
								}

								// エラーメッセージ出力
								ShowInpErrMsg(message);
								e.Cancel = true;
								return;
							}
						}

						// 同一ロットチェック
						index = 0; // 重複行の先頭
						if (InpLotDuplicateCheck(ref this._dataTableLotOld, ref this.rateLotOld_ultraGrid, ref index) == false)
						{
							// エラー発生時は旧ロットグリッドへ切り替え
							this.LotOldNewRateStartDate_uButton.Text = RATE_OLD;
							OldNewRateChange(false);

							// エラー行にフォーカスセット
							this.rateLotOld_ultraGrid.Rows[index].Cells[LOT_LOTCOUNT].Activate();

							// エラーメッセージ出力
							ShowInpErrMsg(LOT_DUP_MSG);
							e.Cancel = true;
							return;
						}
						
						// 掛率タブ制御
						RateTabControl();
						break;
					}
				case "rateLotTab":
					{
						// ロットタブ制御
						RateLotTabControl(RATE_NEW);
						break;
					}
				default:
					{
						return;
					}
			}
		}

        #region ガイドボタン
        /// <summary>SectionCode_uButton_Click</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 拠点コードガイドボタンを押下すると発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.26</br>
		/// </remarks>
		private void SectionCode_uButton_Click(object sender, EventArgs e)
		{
			SecInfoSet secInfoSet = null;
			
			if (this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet) == 0)
			{
				// 変更が無ければ処理しない
				if(string.Equals(secInfoSet.SectionCode, this._searchRate.SectionCode) == true)
				{
					return;
				}
				
				DispSetStatus dispSetStatus = editChgDataChk("拠点コード", secInfoSet.SectionCode, this._searchRate.SectionCode);
				if(dispSetStatus == DispSetStatus.Update)
				{
					this.RateSectionCode_tEdit.Text = secInfoSet.SectionCode;
					this.SectionCodeNm_tEdit.Text = secInfoSet.SectionGuideNm;
					
					// 現在データ保存
					this._searchRate.SectionCode = this.RateSectionCode_tEdit.Text;
				}
			}
		}
		
		/// <summary>RateSettingDivide_uButton_Click</summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 掛率設定区分ガイドボタンを押下すると発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
		/// <br>Date       : 2007.10.10</br>
		/// </remarks>
		private void RateSettingDivide_uButton_Click(object sender, EventArgs e)
		{
			RateProtyMng rateProtyMng = null;
			
			if (this._rateProtyMngAcs.ExecuteGuid(this._enterpriseCode, this.RateSectionCode_tEdit.Text, NullChgInt(this.UnitPriceKind_tComboEditor.Value),
				NullChgInt(this.UnitPriceKindWay_tComboEditor.Value), out rateProtyMng) == 0)
			{
				// 変更が無ければ処理しない
				if (string.Equals(rateProtyMng.RateSettingDivide, this._searchRate.RateSettingDivide) == true)
				{
					return;
				}
				
				DispSetStatus dispSetStatus = editChgDataChk("掛率設定区分", rateProtyMng.RateSettingDivide, this._searchRate.RateSettingDivide);
				if (dispSetStatus == DispSetStatus.Update)
				{
					this.RateSettingDivide_tEdit.Text = rateProtyMng.RateSettingDivide;
					this.RateMngGoodsCd_tEdit.Text = rateProtyMng.RateMngGoodsCd;
					this.RateMngGoodsNm_tEdit.Text = rateProtyMng.RateMngGoodsNm;
					this.RateMngCustCd_tEdit.Text = rateProtyMng.RateMngCustCd;
					this.RateMngCustNm_tEdit.Text = rateProtyMng.RateMngCustNm;
					
					// 現在データ保存
					this._searchRate.RateSettingDivide = this.RateSettingDivide_tEdit.Text;
					this._searchRate.RateMngGoodsCd	= this.RateMngGoodsCd_tEdit.Text;
					this._searchRate.RateMngGoodsNm = this.RateMngGoodsNm_tEdit.Text;
					this._searchRate.RateMngCustCd = this.RateMngCustCd_tEdit.Text;
					this._searchRate.RateMngCustNm = this.RateMngCustNm_tEdit.Text;

					// 検索前の場合
					if ((this._AllCtrlInputStatus == AllCtrlInputStatus.New)
						|| (this._AllCtrlInputStatus == AllCtrlInputStatus.InputCondition))
					{
						// 掛率条件入力エラーチェック
						InpRateCondCheck();
					}
				}
			}
		}

        /// <summary>GoodsNo_uButton_Click</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 商品番号（単品）ガイドボタンを押下すると発生します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private void GoodsNo_uButton_Click(object sender, EventArgs e)
        {
            GoodsNoGuide(this.GoodsMakerCd_tNedit);
        }

        /// <summary>GoodsMakerCd_uButton_Click</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 商品メーカー（単品）ガイドボタンを押下すると発生します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private void GoodsMakerCd_uButton_Click(object sender, EventArgs e)
        {
            MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt = null;
			
            //----------------------
            // メーカーコードガイド
            //----------------------
            if (makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt) == 0)
            {
                // 変更が無ければ処理しない
                if (makerUMnt.GoodsMakerCd == this._searchRate.GoodsMakerCd)
                {
                    return;
                }

                DispSetStatus dispSetStatus = editChgDataChk("メーカーコード", makerUMnt.GoodsMakerCd, this._searchRate.GoodsMakerCd);
                if (dispSetStatus == DispSetStatus.Update)
                {
                    this.GoodsMakerCd_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                    this.GoodsMakerCdNm_tEdit.Text = makerUMnt.MakerName;

                    // 変更が有る場合
                    if (makerUMnt.GoodsMakerCd != this._searchRate.GoodsMakerCd)
                    {
                        // メーカーに紐づく商品コード, 商品名称クリア
                        this.GoodsNoCd_tEdit.Clear();
                        this.GoodsNoNm_tEdit.Clear();
                        this._searchRate.GoodsNo = "";
                    }

                    // 現在データ保存
                    this._searchRate.GoodsMakerCd = this.GoodsMakerCd_tNedit.GetInt();
					
                    // 商品コードガイド
                    GoodsNoGuide(this.GoodsMakerCd_tNedit);
                }
            }
        }

        /// <summary>GoodsMakerCd_Grp_uButton_Click</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 商品メーカーガイドボタンを押下すると発生します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private void GoodsMakerCd_Grp_uButton_Click(object sender, EventArgs e)
        {
            MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt = null;

            if (makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt) == 0)
            {
                // 変更が無ければ処理しない
                if (makerUMnt.GoodsMakerCd == this._searchRate.GoodsMakerCd)
                {
                    return;
                }

                DispSetStatus dispSetStatus = editChgDataChk("商品メーカー", makerUMnt.GoodsMakerCd, this._searchRate.GoodsMakerCd);
                if (dispSetStatus == DispSetStatus.Update)
                {
                    this.GoodsMakerCd_Grp_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                    this.GoodsMakerCdNm_Grp_tEdit.Text = makerUMnt.MakerName;
					
                    // 現在データ保存
                    this._searchRate.GoodsMakerCd = this.GoodsMakerCd_Grp_tNedit.GetInt();
                }
            }
        }

        /// <summary>LargeGoodsGanreCode_Grp_uButton_Click</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 商品区分グループコードガイドボタンを押下すると発生します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private void LargeGoodsGanreCode_Grp_uButton_Click(object sender, EventArgs e)
        {
            // 商品区分グループコードガイド起動
            LargeGoodsGanreCodeGuide();
        }
		
        /// <summary>MediumGoodsGanreCode_Grp_uButton_Click</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 商品区分ガイドボタンを押下すると発生します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private void MediumGoodsGanreCode_Grp_uButton_Click(object sender, EventArgs e)
        {
            // 商品区分ガイド起動
            MediumGoodsGanreCodeGuide();
        }

        /// <summary>DetailGoodsGanreCode_Grp_uButton_Click</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 商品区分詳細ガイドボタンを押下すると発生します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private void DetailGoodsGanreCode_Grp_uButton_Click(object sender, EventArgs e)
        {
            // 商品区分詳細ガイド起動
            DetailGoodsGanreCodeGuide();
        }

        /// <summary>BLGoodsCode_Grp_uButton_Click</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ＢＬガイドボタンを押下すると発生します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private void BLGoodsCode_Grp_uButton_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsCdUMnt = null;
			
            if (this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt) == 0)
            {
                // 変更が無ければ処理しない
                if (blGoodsCdUMnt.BLGoodsCode == this._searchRate.BLGoodsCode)
                {
                    return;
                }

                DispSetStatus dispSetStatus = editChgDataChk("ＢＬ商品コード", blGoodsCdUMnt.BLGoodsCode, this._searchRate.BLGoodsCode);
                if (dispSetStatus == DispSetStatus.Update)
                {
                    this.BLGoodsCode_Grp_tNedit.SetInt(blGoodsCdUMnt.BLGoodsCode);
                    this.BLGoodsCodeNm_Grp_tEdit.Text = blGoodsCdUMnt.BLGoodsFullName;
					
                    // 現在データ保存
                    this._searchRate.BLGoodsCode = this.BLGoodsCode_Grp_tNedit.GetInt();
                }
            }
        }

        /// <summary>CustomerCode_uButton_Click</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 得意先ガイドボタンを押下すると発生します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private void CustomerCode_uButton_Click(object sender, EventArgs e)
        {
            SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_CUSTOMER_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);	// 得意先検索アクセスクラス
            customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);
        }

        /// <summary>SupplierCd_uButton_Click</summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 仕入先ガイドボタンを押下すると発生します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.10</br>
        /// </remarks>
        private void SupplierCd_uButton_Click(object sender, EventArgs e)
        {
            SFTOK01370UA supplierSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);	// 仕入先検索アクセスクラス
            supplierSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.SupplierSearchForm_CustomerSelect);
            supplierSearchForm.ShowDialog(this);
        }

        /// <summary>
        /// 得意先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">得意先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : 得意先選択時に発生します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.11</br>
        /// </remarks>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            // 変更が無ければ処理しない
            if (customerSearchRet.CustomerCode == this._searchRate.CustomerCode)
            {
                return;
            }

            CustomerInfo customerInfo;

            //選択された得意先の状態をチェック
            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode,
                                    customerSearchRet.CustomerCode, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 選択データが得意先でない場合
                if (customerInfo.IsCustomer == false)
                {
                    // エラー
                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "指定された条件で、得意先は存在しませんでした。", status);
                    return;
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "選択した得意先は既に削除されています。", status);
                return;
            }
            else
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "得意先情報の取得に失敗しました。", status);
                return;
            }

            DispSetStatus dispSetStatus = editChgDataChk("得意先コード", customerSearchRet.CustomerCode, this._searchRate.CustomerCode);
            if (dispSetStatus == DispSetStatus.Update)
            {
                this.CustomerCode_tNedit.SetInt(customerSearchRet.CustomerCode);
                this.CustomerCodeNm_tEdit.Text = customerSearchRet.Name;

                // 現在データ保存
                this._searchRate.CustomerCode = this.CustomerCode_tNedit.GetInt();
            }
        }

        /// <summary>
        /// 仕入先選択時発生イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="customerSearchRet">仕入先検索戻り値クラス</param>
        /// <remarks>
        /// <br>Note       : 仕入先選択時に発生します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
        /// <br>Date       : 2007.10.11</br>
        /// </remarks>
        private void SupplierSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            // 変更が無ければ処理しない
            if (customerSearchRet.CustomerCode == this._searchRate.SupplierCd)
            {
                return;
            }

            CustomerInfo customerInfo;

            //選択された得意先の状態をチェック
            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode,
                                    customerSearchRet.CustomerCode, out customerInfo);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 選択データが仕入先でない場合
                if (customerInfo.IsSupplier == false)
                {
                    // エラー
                    MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "指定された条件で、仕入先は存在しませんでした。", status);
                    return;
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "選択した仕入先は既に削除されています。", status);
                return;
            }
            else
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, "仕入先情報の取得に失敗しました。", status);
                return;
            }

            DispSetStatus dispSetStatus = editChgDataChk("仕入先コード", customerSearchRet.CustomerCode, this._searchRate.SupplierCd);
            if (dispSetStatus == DispSetStatus.Update)
            {
                this.SupplierCd_tNedit.SetInt(customerSearchRet.CustomerCode);
                this.SupplierCdNm_tEdit.Text = customerSearchRet.Name;
				
                // 現在データ保存
                this._searchRate.SupplierCd = this.SupplierCd_tNedit.GetInt();
            }
        }
        #endregion

        /// <summary>
        /// EnterpriseGanreCode_Grp_tComboEditor_SelectionChangeCommittedイベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 自社分類コンボボックスが変化ときに発生します。</br>
        /// <br>Programmer : 30167 上野　弘貴</br>
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
		/// CustRateGrpCode_tComboEditor_SelectionChangeCommittedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 得意先掛率コンボボックスが変化ときに発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
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
		/// SuppRateGrpCode_tComboEditor_SelectionChangeCommittedイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 仕入先掛率コンボボックスが変化ときに発生します。</br>
		/// <br>Programmer : 30167 上野　弘貴</br>
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
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note        : コントロールが編集モードに入る前に発生します。</br>
		/// <br>Programmer  : 30167 上野　弘貴</br>
		/// <br>Date        : 2008.03.31</br>
		/// </remarks>
		private void RateSectionCode_tEdit_BeforeEnterEditMode(object sender, CancelEventArgs e)
		{
			// ChangeFocusイベント一時停止
			this.tArrowKeyControl1.ChangeFocus -= this.tArrowKeyControl1_ChangeFocus;

			// 先頭のゼロ詰めを削除
			this.RateSectionCode_tEdit.Text = GetZeroPadCanceledTextProc(this.RateSectionCode_tEdit.Text);

			// ChangeFocusイベント再開
			this.tArrowKeyControl1.ChangeFocus += new ChangeFocusEventHandler(tArrowKeyControl1_ChangeFocus);
		}

		//----- ueno add ---------- end 2008.03.31
        
	}
    # endregion
       --- DEL 2008/06/18 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/06/18
    }
}