using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Management;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// UOE自社マスタ入力フォームクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : UOE自社マスタ設定を行います。
    ///					 IMasterMaintenanceSingleTypeを実装しています。</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2008.06.25</br>
    /// <br></br>
    /// </remarks>
    public class PMUOE09040UA : System.Windows.Forms.Form, IMasterMaintenanceSingleType
    {
        # region ※Private Members (Component)

        private Infragistics.Win.Misc.UltraLabel Mode_Label;
        private Infragistics.Win.Misc.UltraLabel ultraLabel10;
        private Infragistics.Win.Misc.UltraLabel FollowSlipOutputDiv_Label;
        private Infragistics.Win.Misc.UltraLabel AddUpADateDiv_Label;
        private Infragistics.Win.Misc.UltraLabel StockBlnktPrtNoDiv_Label;
        private Infragistics.Win.Misc.UltraLabel MakerFollowAddUpDiv_Label;
        private Infragistics.Win.Misc.UltraLabel DistEnterDiv_Label;
        private Infragistics.Win.Misc.UltraLabel DistSectionSetDiv_Label;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel ultraLabel8;
        private Infragistics.Win.Misc.UltraLabel InpSearchRemark_Label;
        private Infragistics.Win.Misc.UltraLabel StockBlnktRemark_Label;
        private Infragistics.Win.Misc.UltraLabel SlipOutputRemarkDiv_Label;
        private Infragistics.Win.Misc.UltraLabel SlipOutputRemark_Label;
        private TComboEditor SlipOutputDivCd_tComboEditor;
        private TComboEditor FollowSlipOutputDiv_tComboEditor;
        private TComboEditor AddUpADateDiv_tComboEditor;
        private TComboEditor StockBlnktPrtNoDiv_tComboEditor;
        private TComboEditor MakerFollowAddUpDiv_tComboEditor;
        private TComboEditor DistEnterDiv_tComboEditor;
        private TComboEditor DistSectionSetDiv_tComboEditor;
        private TEdit InpSearchRemark_tEdit;
        private TEdit StockBlnktRemark_tEdit;
        private TEdit SlipOutputRemark_tEdit;
        private TComboEditor SlipOutputRemarkDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
        private Infragistics.Win.Misc.UltraButton Ok_Button;
        private TRetKeyControl tRetKeyControl1;
        private IContainer components;
        private TArrowKeyControl tArrowKeyControl1;
        private Timer Initial_Timer;
        private THtmlGenerate tHtmlGenerate1;
        private TComboEditor UOESlipPrtDiv_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel UOESlipPrtDiv_Label;
        private Infragistics.Win.Misc.UltraLabel SlipOutputDivCd_Label;

        #endregion

        #region ※Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance24 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance27 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance30 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance38 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance39 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance40 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance46 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance41 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance50 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance47 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance48 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance49 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance42 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance43 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMUOE09040UA));
            this.SlipOutputDivCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel10 = new Infragistics.Win.Misc.UltraLabel();
            this.FollowSlipOutputDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.AddUpADateDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.StockBlnktPrtNoDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MakerFollowAddUpDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DistEnterDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.DistSectionSetDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.ultraLabel8 = new Infragistics.Win.Misc.UltraLabel();
            this.InpSearchRemark_Label = new Infragistics.Win.Misc.UltraLabel();
            this.StockBlnktRemark_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SlipOutputRemarkDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SlipOutputRemark_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SlipOutputDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.FollowSlipOutputDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.AddUpADateDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.StockBlnktPrtNoDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.MakerFollowAddUpDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DistEnterDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DistSectionSetDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.InpSearchRemark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.StockBlnktRemark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SlipOutputRemark_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.SlipOutputRemarkDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tHtmlGenerate1 = new Broadleaf.Library.Windows.Forms.THtmlGenerate(this.components);
            this.UOESlipPrtDiv_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UOESlipPrtDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.SlipOutputDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FollowSlipOutputDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpADateDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockBlnktPrtNoDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerFollowAddUpDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DistEnterDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DistSectionSetDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InpSearchRemark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockBlnktRemark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipOutputRemark_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipOutputRemarkDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESlipPrtDiv_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // SlipOutputDivCd_Label
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.SlipOutputDivCd_Label.Appearance = appearance5;
            this.SlipOutputDivCd_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SlipOutputDivCd_Label.Location = new System.Drawing.Point(12, 51);
            this.SlipOutputDivCd_Label.Name = "SlipOutputDivCd_Label";
            this.SlipOutputDivCd_Label.Size = new System.Drawing.Size(170, 23);
            this.SlipOutputDivCd_Label.TabIndex = 12;
            this.SlipOutputDivCd_Label.Text = "伝票出力形態";
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(533, 12);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 23;
            this.Mode_Label.Text = "更新モード";
            // 
            // ultraLabel10
            // 
            this.ultraLabel10.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel10.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel10.Location = new System.Drawing.Point(12, 41);
            this.ultraLabel10.Name = "ultraLabel10";
            this.ultraLabel10.Size = new System.Drawing.Size(621, 4);
            this.ultraLabel10.TabIndex = 24;
            // 
            // FollowSlipOutputDiv_Label
            // 
            appearance6.TextVAlignAsString = "Middle";
            this.FollowSlipOutputDiv_Label.Appearance = appearance6;
            this.FollowSlipOutputDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.FollowSlipOutputDiv_Label.Location = new System.Drawing.Point(12, 80);
            this.FollowSlipOutputDiv_Label.Name = "FollowSlipOutputDiv_Label";
            this.FollowSlipOutputDiv_Label.Size = new System.Drawing.Size(170, 23);
            this.FollowSlipOutputDiv_Label.TabIndex = 12;
            this.FollowSlipOutputDiv_Label.Text = "ﾌｫﾛｰ伝票出力形態";
            // 
            // AddUpADateDiv_Label
            // 
            appearance7.TextVAlignAsString = "Middle";
            this.AddUpADateDiv_Label.Appearance = appearance7;
            this.AddUpADateDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.AddUpADateDiv_Label.Location = new System.Drawing.Point(12, 109);
            this.AddUpADateDiv_Label.Name = "AddUpADateDiv_Label";
            this.AddUpADateDiv_Label.Size = new System.Drawing.Size(170, 23);
            this.AddUpADateDiv_Label.TabIndex = 12;
            this.AddUpADateDiv_Label.Text = "伝発計上日";
            // 
            // StockBlnktPrtNoDiv_Label
            // 
            appearance8.TextVAlignAsString = "Middle";
            this.StockBlnktPrtNoDiv_Label.Appearance = appearance8;
            this.StockBlnktPrtNoDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.StockBlnktPrtNoDiv_Label.Location = new System.Drawing.Point(12, 138);
            this.StockBlnktPrtNoDiv_Label.Name = "StockBlnktPrtNoDiv_Label";
            this.StockBlnktPrtNoDiv_Label.Size = new System.Drawing.Size(170, 23);
            this.StockBlnktPrtNoDiv_Label.TabIndex = 12;
            this.StockBlnktPrtNoDiv_Label.Text = "在庫一括品番区分";
            // 
            // MakerFollowAddUpDiv_Label
            // 
            appearance9.TextVAlignAsString = "Middle";
            this.MakerFollowAddUpDiv_Label.Appearance = appearance9;
            this.MakerFollowAddUpDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MakerFollowAddUpDiv_Label.Location = new System.Drawing.Point(12, 167);
            this.MakerFollowAddUpDiv_Label.Name = "MakerFollowAddUpDiv_Label";
            this.MakerFollowAddUpDiv_Label.Size = new System.Drawing.Size(170, 23);
            this.MakerFollowAddUpDiv_Label.TabIndex = 12;
            this.MakerFollowAddUpDiv_Label.Text = "ﾒｰｶｰﾌｫﾛｰ計上区分";
            // 
            // DistEnterDiv_Label
            // 
            appearance14.TextVAlignAsString = "Middle";
            this.DistEnterDiv_Label.Appearance = appearance14;
            this.DistEnterDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DistEnterDiv_Label.Location = new System.Drawing.Point(12, 196);
            this.DistEnterDiv_Label.Name = "DistEnterDiv_Label";
            this.DistEnterDiv_Label.Size = new System.Drawing.Size(170, 23);
            this.DistEnterDiv_Label.TabIndex = 12;
            this.DistEnterDiv_Label.Text = "卸商入庫更新";
            // 
            // DistSectionSetDiv_Label
            // 
            appearance10.TextVAlignAsString = "Middle";
            this.DistSectionSetDiv_Label.Appearance = appearance10;
            this.DistSectionSetDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.DistSectionSetDiv_Label.Location = new System.Drawing.Point(12, 225);
            this.DistSectionSetDiv_Label.Name = "DistSectionSetDiv_Label";
            this.DistSectionSetDiv_Label.Size = new System.Drawing.Size(170, 23);
            this.DistSectionSetDiv_Label.TabIndex = 12;
            this.DistSectionSetDiv_Label.Text = "卸商拠点設定";
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 467);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(645, 23);
            this.ultraStatusBar1.SizeGripVisible = Infragistics.Win.DefaultableBoolean.False;
            this.ultraStatusBar1.TabIndex = 25;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // ultraLabel8
            // 
            this.ultraLabel8.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel8.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel8.Location = new System.Drawing.Point(12, 285);
            this.ultraLabel8.Name = "ultraLabel8";
            this.ultraLabel8.Size = new System.Drawing.Size(621, 4);
            this.ultraLabel8.TabIndex = 24;
            // 
            // InpSearchRemark_Label
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.InpSearchRemark_Label.Appearance = appearance17;
            this.InpSearchRemark_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.InpSearchRemark_Label.Location = new System.Drawing.Point(12, 295);
            this.InpSearchRemark_Label.Name = "InpSearchRemark_Label";
            this.InpSearchRemark_Label.Size = new System.Drawing.Size(170, 23);
            this.InpSearchRemark_Label.TabIndex = 12;
            this.InpSearchRemark_Label.Text = "手入力・検索";
            // 
            // StockBlnktRemark_Label
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.StockBlnktRemark_Label.Appearance = appearance18;
            this.StockBlnktRemark_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.StockBlnktRemark_Label.Location = new System.Drawing.Point(12, 324);
            this.StockBlnktRemark_Label.Name = "StockBlnktRemark_Label";
            this.StockBlnktRemark_Label.Size = new System.Drawing.Size(170, 23);
            this.StockBlnktRemark_Label.TabIndex = 12;
            this.StockBlnktRemark_Label.Text = "在庫一括・補充";
            // 
            // SlipOutputRemarkDiv_Label
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.SlipOutputRemarkDiv_Label.Appearance = appearance19;
            this.SlipOutputRemarkDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SlipOutputRemarkDiv_Label.Location = new System.Drawing.Point(12, 382);
            this.SlipOutputRemarkDiv_Label.Name = "SlipOutputRemarkDiv_Label";
            this.SlipOutputRemarkDiv_Label.Size = new System.Drawing.Size(170, 23);
            this.SlipOutputRemarkDiv_Label.TabIndex = 12;
            this.SlipOutputRemarkDiv_Label.Text = "伝発区分";
            // 
            // SlipOutputRemark_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.SlipOutputRemark_Label.Appearance = appearance2;
            this.SlipOutputRemark_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.SlipOutputRemark_Label.Location = new System.Drawing.Point(12, 353);
            this.SlipOutputRemark_Label.Name = "SlipOutputRemark_Label";
            this.SlipOutputRemark_Label.Size = new System.Drawing.Size(170, 23);
            this.SlipOutputRemark_Label.TabIndex = 12;
            this.SlipOutputRemark_Label.Text = "伝発マーク";
            // 
            // SlipOutputDivCd_tComboEditor
            // 
            appearance20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance20.ForeColor = System.Drawing.Color.Black;
            appearance20.ForeColorDisabled = System.Drawing.Color.Black;
            this.SlipOutputDivCd_tComboEditor.ActiveAppearance = appearance20;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance21.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance21.ForeColor = System.Drawing.Color.Black;
            appearance21.ForeColorDisabled = System.Drawing.Color.Black;
            this.SlipOutputDivCd_tComboEditor.Appearance = appearance21;
            this.SlipOutputDivCd_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SlipOutputDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SlipOutputDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance22.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SlipOutputDivCd_tComboEditor.ItemAppearance = appearance22;
            this.SlipOutputDivCd_tComboEditor.Location = new System.Drawing.Point(188, 51);
            this.SlipOutputDivCd_tComboEditor.MaxDropDownItems = 18;
            this.SlipOutputDivCd_tComboEditor.Name = "SlipOutputDivCd_tComboEditor";
            this.SlipOutputDivCd_tComboEditor.Size = new System.Drawing.Size(417, 24);
            this.SlipOutputDivCd_tComboEditor.TabIndex = 1;
            // 
            // FollowSlipOutputDiv_tComboEditor
            // 
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance23.ForeColor = System.Drawing.Color.Black;
            appearance23.ForeColorDisabled = System.Drawing.Color.Black;
            this.FollowSlipOutputDiv_tComboEditor.ActiveAppearance = appearance23;
            appearance24.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance24.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance24.ForeColor = System.Drawing.Color.Black;
            appearance24.ForeColorDisabled = System.Drawing.Color.Black;
            this.FollowSlipOutputDiv_tComboEditor.Appearance = appearance24;
            this.FollowSlipOutputDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.FollowSlipOutputDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.FollowSlipOutputDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FollowSlipOutputDiv_tComboEditor.ItemAppearance = appearance25;
            this.FollowSlipOutputDiv_tComboEditor.Location = new System.Drawing.Point(188, 80);
            this.FollowSlipOutputDiv_tComboEditor.MaxDropDownItems = 18;
            this.FollowSlipOutputDiv_tComboEditor.Name = "FollowSlipOutputDiv_tComboEditor";
            this.FollowSlipOutputDiv_tComboEditor.Size = new System.Drawing.Size(92, 24);
            this.FollowSlipOutputDiv_tComboEditor.TabIndex = 2;
            // 
            // AddUpADateDiv_tComboEditor
            // 
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance26.ForeColor = System.Drawing.Color.Black;
            appearance26.ForeColorDisabled = System.Drawing.Color.Black;
            this.AddUpADateDiv_tComboEditor.ActiveAppearance = appearance26;
            appearance27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance27.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance27.ForeColor = System.Drawing.Color.Black;
            appearance27.ForeColorDisabled = System.Drawing.Color.Black;
            this.AddUpADateDiv_tComboEditor.Appearance = appearance27;
            this.AddUpADateDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.AddUpADateDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.AddUpADateDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance28.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.AddUpADateDiv_tComboEditor.ItemAppearance = appearance28;
            this.AddUpADateDiv_tComboEditor.Location = new System.Drawing.Point(188, 109);
            this.AddUpADateDiv_tComboEditor.MaxDropDownItems = 18;
            this.AddUpADateDiv_tComboEditor.Name = "AddUpADateDiv_tComboEditor";
            this.AddUpADateDiv_tComboEditor.Size = new System.Drawing.Size(137, 24);
            this.AddUpADateDiv_tComboEditor.TabIndex = 3;
            // 
            // StockBlnktPrtNoDiv_tComboEditor
            // 
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance29.ForeColor = System.Drawing.Color.Black;
            appearance29.ForeColorDisabled = System.Drawing.Color.Black;
            this.StockBlnktPrtNoDiv_tComboEditor.ActiveAppearance = appearance29;
            appearance30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance30.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance30.ForeColor = System.Drawing.Color.Black;
            appearance30.ForeColorDisabled = System.Drawing.Color.Black;
            this.StockBlnktPrtNoDiv_tComboEditor.Appearance = appearance30;
            this.StockBlnktPrtNoDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.StockBlnktPrtNoDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.StockBlnktPrtNoDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.StockBlnktPrtNoDiv_tComboEditor.ItemAppearance = appearance31;
            this.StockBlnktPrtNoDiv_tComboEditor.Location = new System.Drawing.Point(188, 138);
            this.StockBlnktPrtNoDiv_tComboEditor.MaxDropDownItems = 18;
            this.StockBlnktPrtNoDiv_tComboEditor.Name = "StockBlnktPrtNoDiv_tComboEditor";
            this.StockBlnktPrtNoDiv_tComboEditor.Size = new System.Drawing.Size(137, 24);
            this.StockBlnktPrtNoDiv_tComboEditor.TabIndex = 4;
            // 
            // MakerFollowAddUpDiv_tComboEditor
            // 
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance32.ForeColor = System.Drawing.Color.Black;
            appearance32.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerFollowAddUpDiv_tComboEditor.ActiveAppearance = appearance32;
            appearance33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance33.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance33.ForeColor = System.Drawing.Color.Black;
            appearance33.ForeColorDisabled = System.Drawing.Color.Black;
            this.MakerFollowAddUpDiv_tComboEditor.Appearance = appearance33;
            this.MakerFollowAddUpDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MakerFollowAddUpDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MakerFollowAddUpDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance34.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MakerFollowAddUpDiv_tComboEditor.ItemAppearance = appearance34;
            this.MakerFollowAddUpDiv_tComboEditor.Location = new System.Drawing.Point(188, 167);
            this.MakerFollowAddUpDiv_tComboEditor.MaxDropDownItems = 18;
            this.MakerFollowAddUpDiv_tComboEditor.Name = "MakerFollowAddUpDiv_tComboEditor";
            this.MakerFollowAddUpDiv_tComboEditor.Size = new System.Drawing.Size(92, 24);
            this.MakerFollowAddUpDiv_tComboEditor.TabIndex = 5;
            // 
            // DistEnterDiv_tComboEditor
            // 
            appearance38.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance38.ForeColor = System.Drawing.Color.Black;
            appearance38.ForeColorDisabled = System.Drawing.Color.Black;
            this.DistEnterDiv_tComboEditor.ActiveAppearance = appearance38;
            appearance39.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance39.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance39.ForeColor = System.Drawing.Color.Black;
            appearance39.ForeColorDisabled = System.Drawing.Color.Black;
            this.DistEnterDiv_tComboEditor.Appearance = appearance39;
            this.DistEnterDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.DistEnterDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DistEnterDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance40.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DistEnterDiv_tComboEditor.ItemAppearance = appearance40;
            this.DistEnterDiv_tComboEditor.Location = new System.Drawing.Point(188, 196);
            this.DistEnterDiv_tComboEditor.MaxDropDownItems = 18;
            this.DistEnterDiv_tComboEditor.Name = "DistEnterDiv_tComboEditor";
            this.DistEnterDiv_tComboEditor.Size = new System.Drawing.Size(92, 24);
            this.DistEnterDiv_tComboEditor.TabIndex = 7;
            // 
            // DistSectionSetDiv_tComboEditor
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            this.DistSectionSetDiv_tComboEditor.ActiveAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance12.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance12.ForeColor = System.Drawing.Color.Black;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            this.DistSectionSetDiv_tComboEditor.Appearance = appearance12;
            this.DistSectionSetDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.DistSectionSetDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DistSectionSetDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DistSectionSetDiv_tComboEditor.ItemAppearance = appearance13;
            this.DistSectionSetDiv_tComboEditor.Location = new System.Drawing.Point(188, 225);
            this.DistSectionSetDiv_tComboEditor.MaxDropDownItems = 18;
            this.DistSectionSetDiv_tComboEditor.Name = "DistSectionSetDiv_tComboEditor";
            this.DistSectionSetDiv_tComboEditor.Size = new System.Drawing.Size(137, 24);
            this.DistSectionSetDiv_tComboEditor.TabIndex = 8;
            // 
            // InpSearchRemark_tEdit
            // 
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.InpSearchRemark_tEdit.ActiveAppearance = appearance45;
            appearance3.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance3.ForeColorDisabled = System.Drawing.Color.Black;
            this.InpSearchRemark_tEdit.Appearance = appearance3;
            this.InpSearchRemark_tEdit.AutoSelect = true;
            this.InpSearchRemark_tEdit.DataText = "";
            this.InpSearchRemark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.InpSearchRemark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.InpSearchRemark_tEdit.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.InpSearchRemark_tEdit.Location = new System.Drawing.Point(188, 295);
            this.InpSearchRemark_tEdit.MaxLength = 10;
            this.InpSearchRemark_tEdit.Name = "InpSearchRemark_tEdit";
            this.InpSearchRemark_tEdit.Size = new System.Drawing.Size(90, 24);
            this.InpSearchRemark_tEdit.TabIndex = 9;
            // 
            // StockBlnktRemark_tEdit
            // 
            appearance46.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.StockBlnktRemark_tEdit.ActiveAppearance = appearance46;
            appearance4.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.StockBlnktRemark_tEdit.Appearance = appearance4;
            this.StockBlnktRemark_tEdit.AutoSelect = true;
            this.StockBlnktRemark_tEdit.DataText = "";
            this.StockBlnktRemark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.StockBlnktRemark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 10, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.StockBlnktRemark_tEdit.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.StockBlnktRemark_tEdit.Location = new System.Drawing.Point(188, 324);
            this.StockBlnktRemark_tEdit.MaxLength = 10;
            this.StockBlnktRemark_tEdit.Name = "StockBlnktRemark_tEdit";
            this.StockBlnktRemark_tEdit.Size = new System.Drawing.Size(90, 24);
            this.StockBlnktRemark_tEdit.TabIndex = 10;
            // 
            // SlipOutputRemark_tEdit
            // 
            appearance41.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SlipOutputRemark_tEdit.ActiveAppearance = appearance41;
            appearance50.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance50.ForeColorDisabled = System.Drawing.Color.Black;
            this.SlipOutputRemark_tEdit.Appearance = appearance50;
            this.SlipOutputRemark_tEdit.AutoSelect = true;
            this.SlipOutputRemark_tEdit.DataText = "";
            this.SlipOutputRemark_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SlipOutputRemark_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 1, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, true, true, true));
            this.SlipOutputRemark_tEdit.Location = new System.Drawing.Point(188, 353);
            this.SlipOutputRemark_tEdit.MaxLength = 1;
            this.SlipOutputRemark_tEdit.Name = "SlipOutputRemark_tEdit";
            this.SlipOutputRemark_tEdit.Size = new System.Drawing.Size(20, 24);
            this.SlipOutputRemark_tEdit.TabIndex = 11;
            // 
            // SlipOutputRemarkDiv_tComboEditor
            // 
            appearance47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance47.ForeColor = System.Drawing.Color.Black;
            appearance47.ForeColorDisabled = System.Drawing.Color.Black;
            this.SlipOutputRemarkDiv_tComboEditor.ActiveAppearance = appearance47;
            appearance48.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance48.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance48.ForeColor = System.Drawing.Color.Black;
            appearance48.ForeColorDisabled = System.Drawing.Color.Black;
            this.SlipOutputRemarkDiv_tComboEditor.Appearance = appearance48;
            this.SlipOutputRemarkDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.SlipOutputRemarkDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.SlipOutputRemarkDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance49.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SlipOutputRemarkDiv_tComboEditor.ItemAppearance = appearance49;
            this.SlipOutputRemarkDiv_tComboEditor.Location = new System.Drawing.Point(188, 382);
            this.SlipOutputRemarkDiv_tComboEditor.MaxDropDownItems = 18;
            this.SlipOutputRemarkDiv_tComboEditor.Name = "SlipOutputRemarkDiv_tComboEditor";
            this.SlipOutputRemarkDiv_tComboEditor.Size = new System.Drawing.Size(244, 24);
            this.SlipOutputRemarkDiv_tComboEditor.TabIndex = 12;
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(508, 423);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 15;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(383, 423);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 14;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // tHtmlGenerate1
            // 
            this.tHtmlGenerate1.Align = Broadleaf.Library.Windows.Forms.align.center;
            this.tHtmlGenerate1.coltype = true;
            this.tHtmlGenerate1.Guusuucolor = System.Drawing.Color.PaleTurquoise;
            this.tHtmlGenerate1.GuusuuRow = true;
            this.tHtmlGenerate1.HaikeiColor = System.Drawing.Color.AliceBlue;
            this.tHtmlGenerate1.HightBR = 1;
            this.tHtmlGenerate1.koteicolcolor = System.Drawing.Color.RoyalBlue;
            this.tHtmlGenerate1.koteifontcolor = System.Drawing.Color.White;
            this.tHtmlGenerate1.RowBackColor = System.Drawing.Color.Transparent;
            this.tHtmlGenerate1.RowFontColor = System.Drawing.Color.Black;
            this.tHtmlGenerate1.RowFontSize = 7;
            this.tHtmlGenerate1.SelectedBackColor = System.Drawing.Color.White;
            this.tHtmlGenerate1.TitleColor = System.Drawing.Color.Navy;
            this.tHtmlGenerate1.TitleFontColor = System.Drawing.Color.White;
            this.tHtmlGenerate1.TitleFontSize = 7;
            // 
            // UOESlipPrtDiv_Label
            // 
            appearance15.TextVAlignAsString = "Middle";
            this.UOESlipPrtDiv_Label.Appearance = appearance15;
            this.UOESlipPrtDiv_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UOESlipPrtDiv_Label.Location = new System.Drawing.Point(12, 254);
            this.UOESlipPrtDiv_Label.Name = "UOESlipPrtDiv_Label";
            this.UOESlipPrtDiv_Label.Size = new System.Drawing.Size(170, 23);
            this.UOESlipPrtDiv_Label.TabIndex = 12;
            this.UOESlipPrtDiv_Label.Text = "UOE伝票発行区分";
            // 
            // UOESlipPrtDiv_tComboEditor
            // 
            appearance42.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance42.ForeColor = System.Drawing.Color.Black;
            appearance42.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOESlipPrtDiv_tComboEditor.ActiveAppearance = appearance42;
            appearance43.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance43.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance43.ForeColor = System.Drawing.Color.Black;
            appearance43.ForeColorDisabled = System.Drawing.Color.Black;
            this.UOESlipPrtDiv_tComboEditor.Appearance = appearance43;
            this.UOESlipPrtDiv_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.UOESlipPrtDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.UOESlipPrtDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.UOESlipPrtDiv_tComboEditor.ItemAppearance = appearance44;
            this.UOESlipPrtDiv_tComboEditor.Location = new System.Drawing.Point(188, 255);
            this.UOESlipPrtDiv_tComboEditor.MaxDropDownItems = 18;
            this.UOESlipPrtDiv_tComboEditor.Name = "UOESlipPrtDiv_tComboEditor";
            this.UOESlipPrtDiv_tComboEditor.Size = new System.Drawing.Size(92, 24);
            this.UOESlipPrtDiv_tComboEditor.TabIndex = 8;
            // 
            // PMUOE09040UA
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(645, 490);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.SlipOutputRemark_tEdit);
            this.Controls.Add(this.StockBlnktRemark_tEdit);
            this.Controls.Add(this.InpSearchRemark_tEdit);
            this.Controls.Add(this.SlipOutputRemarkDiv_tComboEditor);
            this.Controls.Add(this.UOESlipPrtDiv_tComboEditor);
            this.Controls.Add(this.DistSectionSetDiv_tComboEditor);
            this.Controls.Add(this.DistEnterDiv_tComboEditor);
            this.Controls.Add(this.MakerFollowAddUpDiv_tComboEditor);
            this.Controls.Add(this.StockBlnktPrtNoDiv_tComboEditor);
            this.Controls.Add(this.AddUpADateDiv_tComboEditor);
            this.Controls.Add(this.FollowSlipOutputDiv_tComboEditor);
            this.Controls.Add(this.SlipOutputDivCd_tComboEditor);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.ultraLabel8);
            this.Controls.Add(this.ultraLabel10);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.SlipOutputRemark_Label);
            this.Controls.Add(this.SlipOutputRemarkDiv_Label);
            this.Controls.Add(this.StockBlnktRemark_Label);
            this.Controls.Add(this.InpSearchRemark_Label);
            this.Controls.Add(this.UOESlipPrtDiv_Label);
            this.Controls.Add(this.DistSectionSetDiv_Label);
            this.Controls.Add(this.DistEnterDiv_Label);
            this.Controls.Add(this.MakerFollowAddUpDiv_Label);
            this.Controls.Add(this.StockBlnktPrtNoDiv_Label);
            this.Controls.Add(this.AddUpADateDiv_Label);
            this.Controls.Add(this.FollowSlipOutputDiv_Label);
            this.Controls.Add(this.SlipOutputDivCd_Label);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMUOE09040UA";
            this.Text = "UOE自社マスタ設定";
            this.Load += new System.EventHandler(this.PMUOE09040UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMUOE09040UA_VisibleChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMUOE09040UA_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SlipOutputDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FollowSlipOutputDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AddUpADateDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockBlnktPrtNoDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MakerFollowAddUpDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DistEnterDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DistSectionSetDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InpSearchRemark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockBlnktRemark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipOutputRemark_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SlipOutputRemarkDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UOESlipPrtDiv_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region << Private Members >>

        private UOESettingAcs _uoeSettingAcs;           // UOE自社マスタテーブルアクセスクラス
        private UOESetting _uoeSetting;                 // UOE自社データクラス

        private string _enterpriseCode;                 // 企業コード
        private string _sectionCode;

        // 比較用クローン
        private UOESetting _uoeSettingClone;            // 比較用UOE自社クラス

        // プロパティ用
        private bool _canPrint;
        private bool _canClose;

        private const string HTML_HEADER_TITLE = "設定項目";
        private const string HTML_HEADER_VALUE = "設定値";
        private const string HTML_UNREGISTER = "未設定";

        // 編集モード
        private const string UPDATE_MODE = "更新モード";

        private const string CT_PGID = "PMUOE09040UA";
        private const string CT_PGNM = "UOE自社マスタ設定";

        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        
        #endregion

        #region << Constructor >>

		/// <summary>
        /// UOE自社マスタ設定フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : UOE自社マスタ設定フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30413 犬飼</br>
		/// <br>Date       : 2008.06.25</br>
		/// </remarks>
        public PMUOE09040UA()
		{
			InitializeComponent();

			// 企業コード取得
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            //拠点コード取得
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            // UOE自社マスタテーブルアクセスクラス
			this._uoeSettingAcs   = new UOESettingAcs();

			// 比較用クローン
			this._uoeSettingClone = null;

			// プロパティの初期設定
			this._canPrint        = false;
			this._canClose        = false;
		}

		#endregion

        # region ※Dispose
        /// <summary>
        /// 使用されているリソースに後処理を実行します。
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
        # endregion

        # region ※Main
        /// <summary>メイン処理</summary>
        /// <value></value>
        /// <remarks>アプリケーションのメイン エントリ ポイントです。</remarks>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.Run(new PMUOE09040UA());
        }
        # endregion

        # region Events
        /// <summary>画面非表示イベント</summary>
        /// <remarks>画面が非表示状態になった際に発生します。</remarks>
        public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;
        # endregion

        #region << Properties >>

        /// <summary>
        /// 印刷プロパティ
        /// </summary>
        /// <remarks>
        /// 印刷可能かどうかの設定を取得します。（false固定）
        /// </remarks>
        public bool CanPrint
        {
            get { return _canPrint; }
        }

        /// <summary>
        /// 画面クローズプロパティ
        /// </summary>
        /// <remarks>
        /// 画面クローズを許可するかどうかの設定を取得または設定します。
        /// falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。
        /// </remarks>
        public bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }

        #endregion

        #region << Public Methods >>

        /// <summary>
        /// 印刷処理
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 未実装</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public int Print()
        {
            // 印刷アセンブリをロードする（未実装）
            return 0;
        }

        /// <summary>
        /// HTMLコード取得処理
        /// </summary>
        /// <returns>HTMLコード</returns>
        /// <remarks>
        /// <br>Note       : HTMLコードの取得を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        public string GetHtmlCode()
        {
            const string ctPROCNM = "GetHtmlCode";
            string outCode = "";

            // tHtmlGenerate部品の引数を生成する
            List<string> titleList = new List<string>();
            List<string> valueList = new List<string>();
            titleList.Add(HTML_HEADER_TITLE);							// 「設定項目」
            valueList.Add(HTML_HEADER_VALUE);							// 「設定値」

            // 設定項目タイトル設定
            titleList.Add(this.SlipOutputDivCd_Label.Text);             // 伝票出力形態
            titleList.Add(this.FollowSlipOutputDiv_Label.Text);         // ﾌｫﾛｰ伝票出力形態
            titleList.Add(this.AddUpADateDiv_Label.Text);               // 伝発計上日
            titleList.Add(this.StockBlnktPrtNoDiv_Label.Text);          // 在庫一括品番区分
            titleList.Add(this.MakerFollowAddUpDiv_Label.Text);         // ﾒｰｶｰﾌｫﾛｰ計上区分
            titleList.Add(this.DistEnterDiv_Label.Text);                // 卸商入庫更新
            titleList.Add(this.DistSectionSetDiv_Label.Text);           // 卸商拠点設定

            // 2008.12.24 30413 犬飼 UOE伝票発行区分の追加 >>>>>>START
            titleList.Add(this.UOESlipPrtDiv_Label.Text);               // UOE伝票発行区分
            // 2008.12.24 30413 犬飼 UOE伝票発行区分の追加 <<<<<<END

            titleList.Add(this.InpSearchRemark_Label.Text);             // 手入力・検索
            titleList.Add(this.StockBlnktRemark_Label.Text);            // 在庫一括・補充
            titleList.Add(this.SlipOutputRemark_Label.Text);            // 伝発マーク
            titleList.Add(this.SlipOutputRemarkDiv_Label.Text);         // 伝発区分

            // UOE自社マスタ設定データ取得
            int status = 0;
            status = this._uoeSettingAcs.Read(out this._uoeSetting, this._enterpriseCode, this._sectionCode);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {

                        // UOE自社マスタデータ設定
                        if (this._uoeSetting != null)
                        {
                            // 伝票出力形態
                            switch (this._uoeSetting.SlipOutputDivCd)
                            {
                                case 1:
                                    {
                                        valueList.Add("確認伝票・フォロー伝票・ゼロ伝票有り");
                                        break;
                                    }
                                case 2:
                                    {
                                        valueList.Add("確認伝票・フォロー伝票有り");
                                        break;
                                    }
                                case 3:
                                    {
                                        valueList.Add("確認伝票・フォロー伝票（合算）");
                                        break;
                                    }
                                case 4:
                                    {
                                        // 2009.01.20 30413 犬飼 テキスト変更 >>>>>>START
                                        //valueList.Add("確認伝票（ｾﾞﾛ明細印字なし・ﾌｫﾛｰ伝票・ｾﾞﾛ伝票有り");
                                        valueList.Add("確認伝票（ｾﾞﾛ明細印字なし）・ﾌｫﾛｰ伝票・ｾﾞﾛ伝票有り");
                                        // 2009.01.20 30413 犬飼 テキスト変更 <<<<<<END
                                        break;
                                    }
                                case 5:
                                    {
                                        // 2009.01.20 30413 犬飼 テキスト変更 >>>>>>START
                                        //valueList.Add("確認伝票（ｾﾞﾛ明細印字なし・ﾌｫﾛｰ伝票・有り");
                                        valueList.Add("確認伝票（ｾﾞﾛ明細印字なし）・ﾌｫﾛｰ伝票有り");
                                        // 2009.01.20 30413 犬飼 テキスト変更 <<<<<<END
                                        break;
                                    }
                                case 6:
                                    {
                                        // 2009.01.20 30413 犬飼 テキスト変更 >>>>>>START
                                        //valueList.Add("確認伝票（ｾﾞﾛ明細印字なし・ﾌｫﾛｰ伝票（合算) ");
                                        valueList.Add("確認伝票（ｾﾞﾛ明細印字なし）・ﾌｫﾛｰ伝票（合算) ");
                                        // 2009.01.20 30413 犬飼 テキスト変更 <<<<<<END
                                        break;
                                    }
                                default:
                                    {
                                        valueList.Add(HTML_UNREGISTER);
                                        break;
                                    }
                            }

                            // ﾌｫﾛｰ伝票出力形態
                            switch (this._uoeSetting.FollowSlipOutputDiv)
                            {
                                case 0:
                                    {
                                        valueList.Add("合算");
                                        break;
                                    }
                                case 1:
                                    {
                                        valueList.Add("別々");
                                        break;
                                    }
                                default:
                                    {
                                        valueList.Add(HTML_UNREGISTER);
                                        break;
                                    }
                            }

                            // 伝発計上日
                            switch (this._uoeSetting.AddUpADateDiv)
                            {
                                case 0:
                                    {
                                        valueList.Add("マシン日付");
                                        break;
                                    }
                                case 1:
                                    {
                                        valueList.Add("売伝日付");
                                        break;
                                    }
                                default:
                                    {
                                        valueList.Add(HTML_UNREGISTER);
                                        break;
                                    }
                            }

                            // 在庫一括品番区分
                            switch (this._uoeSetting.StockBlnktPrtNoDiv)
                            {
                                case 0:
                                    {
                                        valueList.Add("代替品番採用");
                                        break;
                                    }
                                case 1:
                                    {
                                        valueList.Add("発注品番採用");
                                        break;
                                    }
                                default:
                                    {
                                        valueList.Add(HTML_UNREGISTER);
                                        break;
                                    }
                            }

                            // ﾒｰｶｰﾌｫﾛｰ計上区分
                            switch (this._uoeSetting.MakerFollowAddUpDiv)
                            {
                                case 0:
                                    {
                                        valueList.Add("売上");
                                        break;
                                    }
                                case 1:
                                    {
                                        valueList.Add("受注");
                                        break;
                                    }
                                default:
                                    {
                                        valueList.Add(HTML_UNREGISTER);
                                        break;
                                    }
                            }

                            // 卸商入庫更新
                            switch (this._uoeSetting.DistEnterDiv)
                            {
                                case 0:
                                    {
                                        valueList.Add("自動");
                                        break;
                                    }
                                case 1:
                                    {
                                        valueList.Add("手動");
                                        break;
                                    }
                                default:
                                    {
                                        valueList.Add(HTML_UNREGISTER);
                                        break;
                                    }
                            }

                            // 卸商拠点設定
                            switch (this._uoeSetting.DistSectionSetDiv)
                            {
                                case 0:
                                    {
                                        valueList.Add("仕入先マスタ");
                                        break;
                                    }
                                case 1:
                                    {
                                        valueList.Add("発注データ");
                                        break;
                                    }
                                case 2:
                                    {
                                        valueList.Add("自社マスタ");
                                        break;
                                    }
                                default:
                                    {
                                        valueList.Add(HTML_UNREGISTER);
                                        break;
                                    }
                            }

                            // 2008.12.24 30413 犬飼 UOE伝票発行区分の追加 >>>>>>START
                            // UOE伝票発行区分
                            switch (this._uoeSetting.UOESlipPrtDiv)
                            {
                                case 0:
                                    {
                                        valueList.Add("する");
                                        break;
                                    }
                                case 1:
                                    {
                                        valueList.Add("しない");
                                        break;
                                    }
                                default:
                                    {
                                        valueList.Add(HTML_UNREGISTER);
                                        break;
                                    }
                            }
                            // 2008.12.24 30413 犬飼 UOE伝票発行区分の追加 <<<<<<END
                            
                            // 手入力・検索
                            valueList.Add(this._uoeSetting.InpSearchRemark);

                            // 在庫一括・補充
                            valueList.Add(this._uoeSetting.StockBlnktRemark);

                            // 伝発マーク
                            valueList.Add(this._uoeSetting.SlipOutputRemark);

                            // 伝発区分
                            switch (this._uoeSetting.SlipOutputRemarkDiv)
                            {
                                case 1:
                                    {
                                        valueList.Add("マーク＋得意先");
                                        break;
                                    }
                                case 2:
                                    {
                                        valueList.Add("マーク＋地区");
                                        break;
                                    }
                                case 3:
                                    {
                                        valueList.Add("マーク＋担当者");
                                        break;
                                    }
                                case 4:
                                    {
                                        valueList.Add("マーク＋発行者");
                                        break;
                                    }
                                case 5:
                                    {
                                        valueList.Add("マーク＋得意先＋略称区分");
                                        break;
                                    }
                                case 6:
                                    {
                                        valueList.Add("マーク＋型式＋得意先");
                                        break;
                                    }
                                default:
                                    {
                                        valueList.Add(HTML_UNREGISTER);
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            // 未設定
                            for (int ix = 0; ix < titleList.Count; ix++)
                            {
                                valueList.Add(HTML_UNREGISTER);
                            }
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        // 未設定
                        for (int ix = 0; ix < titleList.Count; ix++)
                        {
                            valueList.Add(HTML_UNREGISTER);
                        }
                        break;
                    }
                default:
                    {
                        // リード
                        TMsgDisp.Show(
                            this,                                 // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
                            CT_PGID,                              // アセンブリＩＤまたはクラスＩＤ
                            CT_PGNM,                              // プログラム名称
                            ctPROCNM,                             // 処理名称
                            TMsgDisp.OPE_READ,                    // オペレーション
                            "読み込みに失敗しました。",           // 表示するメッセージ
                            status,                               // ステータス値
                            this._uoeSettingAcs,                  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,                 // 表示するボタン
                            MessageBoxDefaultButton.Button1);    // 初期表示ボタン

                        // 未設定
                        for (int ix = 0; ix < titleList.Count; ix++)
                        {
                            valueList.Add(HTML_UNREGISTER);
                        }
                        break;
                    }
            }

            this.tHtmlGenerate1.Coltypes = new int[2];
            this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
            this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;

            // 配列にコピー
            string[,] array = new string[titleList.Count, 2];
            for (int ix = 0; ix < array.GetLength(0); ix++)
            {
                array[ix, 0] = titleList[ix];
                array[ix, 1] = valueList[ix];
            }

            this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array, ref outCode);

            return outCode;
        }

        #endregion

        #region << Private Methods >>

        /// <summary>
        /// 画面初期設定
        /// </summary>
        /// <remarks>
        /// <br>Note       : UI画面の初期設定を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            // コンボボックス初期化

            // 伝票出力形態
            this.SlipOutputDivCd_tComboEditor.Items.Clear();
            this.SlipOutputDivCd_tComboEditor.Items.Add(1, "確認伝票・フォロー伝票・ゼロ伝票有り");
            this.SlipOutputDivCd_tComboEditor.Items.Add(2, "確認伝票・フォロー伝票有り");
            this.SlipOutputDivCd_tComboEditor.Items.Add(3, "確認伝票・フォロー伝票（合算）");
            this.SlipOutputDivCd_tComboEditor.Items.Add(4, "確認伝票（ｾﾞﾛ明細印字なし）・ﾌｫﾛｰ伝票・ｾﾞﾛ伝票有り");
            // 2009.01.20 30413 犬飼 テキスト変更 >>>>>>START
            //this.SlipOutputDivCd_tComboEditor.Items.Add(5, "確認伝票（ｾﾞﾛ明細印字なし）・ﾌｫﾛｰ伝票・有り");
            this.SlipOutputDivCd_tComboEditor.Items.Add(5, "確認伝票（ｾﾞﾛ明細印字なし）・ﾌｫﾛｰ伝票有り");
            // 2009.01.20 30413 犬飼 テキスト変更 <<<<<<END
            this.SlipOutputDivCd_tComboEditor.Items.Add(6, "確認伝票（ｾﾞﾛ明細印字なし）・ﾌｫﾛｰ伝票（合算)");
            this.SlipOutputDivCd_tComboEditor.MaxDropDownItems = this.SlipOutputDivCd_tComboEditor.Items.Count;

            // ﾌｫﾛｰ伝票出力形態
            this.FollowSlipOutputDiv_tComboEditor.Items.Clear();
            this.FollowSlipOutputDiv_tComboEditor.Items.Add(0, "合算");
            this.FollowSlipOutputDiv_tComboEditor.Items.Add(1, "別々");
            this.FollowSlipOutputDiv_tComboEditor.MaxDropDownItems = this.FollowSlipOutputDiv_tComboEditor.Items.Count;

            // 伝発計上日
            this.AddUpADateDiv_tComboEditor.Items.Clear();
            this.AddUpADateDiv_tComboEditor.Items.Add(0, "マシン日付");
            this.AddUpADateDiv_tComboEditor.Items.Add(1, "売伝日付");
            this.AddUpADateDiv_tComboEditor.MaxDropDownItems = this.AddUpADateDiv_tComboEditor.Items.Count;

            // 在庫一括品番区分
            this.StockBlnktPrtNoDiv_tComboEditor.Items.Clear();
            this.StockBlnktPrtNoDiv_tComboEditor.Items.Add(0, "代替品番採用");
            this.StockBlnktPrtNoDiv_tComboEditor.Items.Add(1, "発注品番採用");
            this.StockBlnktPrtNoDiv_tComboEditor.MaxDropDownItems = this.StockBlnktPrtNoDiv_tComboEditor.Items.Count;

            // ﾒｰｶｰﾌｫﾛｰ計上区分
            this.MakerFollowAddUpDiv_tComboEditor.Items.Clear();
            this.MakerFollowAddUpDiv_tComboEditor.Items.Add(0, "売上");
            this.MakerFollowAddUpDiv_tComboEditor.Items.Add(1, "受注");
            this.MakerFollowAddUpDiv_tComboEditor.MaxDropDownItems = this.MakerFollowAddUpDiv_tComboEditor.Items.Count;

            // 卸商入庫更新
            this.DistEnterDiv_tComboEditor.Items.Clear();
            this.DistEnterDiv_tComboEditor.Items.Add(0, "自動");
            this.DistEnterDiv_tComboEditor.Items.Add(1, "手動");
            this.DistEnterDiv_tComboEditor.MaxDropDownItems = this.DistEnterDiv_tComboEditor.Items.Count;

            // 卸商拠点設定
            this.DistSectionSetDiv_tComboEditor.Items.Clear();
            this.DistSectionSetDiv_tComboEditor.Items.Add(0, "仕入先マスタ");
            this.DistSectionSetDiv_tComboEditor.Items.Add(1, "発注データ");
            this.DistSectionSetDiv_tComboEditor.Items.Add(2, "自社マスタ");
            this.DistSectionSetDiv_tComboEditor.MaxDropDownItems = this.DistSectionSetDiv_tComboEditor.Items.Count;

            // 2008.12.24 30413 犬飼 UOE伝票発行区分の追加 >>>>>>START
            // UOE伝票発行区分
            this.UOESlipPrtDiv_tComboEditor.Items.Clear();
            this.UOESlipPrtDiv_tComboEditor.Items.Add(0, "する");
            this.UOESlipPrtDiv_tComboEditor.Items.Add(1, "しない");
            this.UOESlipPrtDiv_tComboEditor.MaxDropDownItems = this.UOESlipPrtDiv_tComboEditor.Items.Count;
            // 2008.12.24 30413 犬飼 UOE伝票発行区分の追加 <<<<<<END

            // 伝発区分
            this.SlipOutputRemarkDiv_tComboEditor.Items.Clear();
            this.SlipOutputRemarkDiv_tComboEditor.Items.Add(1, "マーク＋得意先");
            this.SlipOutputRemarkDiv_tComboEditor.Items.Add(2, "マーク＋地区");
            this.SlipOutputRemarkDiv_tComboEditor.Items.Add(3, "マーク＋担当者");
            this.SlipOutputRemarkDiv_tComboEditor.Items.Add(4, "マーク＋発行者");
            this.SlipOutputRemarkDiv_tComboEditor.Items.Add(5, "マーク＋得意先＋略称区分");
            this.SlipOutputRemarkDiv_tComboEditor.Items.Add(6, "マーク＋型式＋得意先");
            this.SlipOutputRemarkDiv_tComboEditor.MaxDropDownItems = this.SlipOutputRemarkDiv_tComboEditor.Items.Count;
        }

        /// <summary>
        /// 画面情報UOE自社クラス格納処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面情報からUOE自社クラスにデータを格納します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private void ScreenToUOESetting()
        {
            if (this._uoeSetting == null)
            {
                // 新規の場合
                this._uoeSetting = new UOESetting();
            }

            this._uoeSetting.EnterpriseCode = this._enterpriseCode;                                     // 企業コード
            this._uoeSetting.SectionCode = this._sectionCode;                                           // 拠点コード

            this._uoeSetting.SlipOutputDivCd = (int)this.SlipOutputDivCd_tComboEditor.Value;            // 伝票出力区分
            this._uoeSetting.FollowSlipOutputDiv = (int)this.FollowSlipOutputDiv_tComboEditor.Value;    // フォロー伝票出力区分
            this._uoeSetting.AddUpADateDiv = (int)this.AddUpADateDiv_tComboEditor.Value;                // 計上日付区分
            this._uoeSetting.StockBlnktPrtNoDiv = (int)this.StockBlnktPrtNoDiv_tComboEditor.Value;      // 在庫一括品番区分
            this._uoeSetting.MakerFollowAddUpDiv = (int)this.MakerFollowAddUpDiv_tComboEditor.Value;    // メーカーフォロー計上区分
            this._uoeSetting.DistEnterDiv = (int)this.DistEnterDiv_tComboEditor.Value;                  // 卸商入庫更新区分
            this._uoeSetting.DistSectionSetDiv = (int)this.DistSectionSetDiv_tComboEditor.Value;        // 卸商拠点設定区分

            // 2008.12.24 30413 犬飼 UOE伝票発行区分の追加 >>>>>>START
            this._uoeSetting.UOESlipPrtDiv = (int)this.UOESlipPrtDiv_tComboEditor.Value;                // UOE伝票発行区分
            // 2008.12.24 30413 犬飼 UOE伝票発行区分の追加 <<<<<<END
            
            this._uoeSetting.InpSearchRemark = this.InpSearchRemark_tEdit.Text.TrimEnd();               // 手入力検索リマーク
            this._uoeSetting.StockBlnktRemark = this.StockBlnktRemark_tEdit.Text.TrimEnd();             // 在庫一括補充リマーク
            this._uoeSetting.SlipOutputRemark = this.SlipOutputRemark_tEdit.Text.TrimEnd();             // 伝発リマーク
            this._uoeSetting.SlipOutputRemarkDiv = (int)this.SlipOutputRemarkDiv_tComboEditor.Value;    // 伝発リマーク区分
        }

        /// <summary>
        /// 画面情報UOE自社クラス格納処理(チェック用)
        /// </summary>
        /// <param name="alItmDspNm">UOE自社オブジェクト</param>
        /// <remarks>
        /// <br>Note       : 画面情報からUOE自社クラスにデータを格納します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private void DispToUOESetting(ref UOESetting uoeSetting)
        {
            if (uoeSetting == null)
            {
                // 新規の場合
                uoeSetting = new UOESetting();
            }

            uoeSetting.SlipOutputDivCd = (int)this.SlipOutputDivCd_tComboEditor.Value;                  // 伝票出力区分
            uoeSetting.FollowSlipOutputDiv = (int)this.FollowSlipOutputDiv_tComboEditor.Value;          // フォロー伝票出力区分
            uoeSetting.AddUpADateDiv = (int)this.AddUpADateDiv_tComboEditor.Value;                      // 計上日付区分
            uoeSetting.StockBlnktPrtNoDiv = (int)this.StockBlnktPrtNoDiv_tComboEditor.Value;            // 在庫一括品番区分
            uoeSetting.MakerFollowAddUpDiv = (int)this.MakerFollowAddUpDiv_tComboEditor.Value;          // メーカーフォロー計上区分
            uoeSetting.DistEnterDiv = (int)this.DistEnterDiv_tComboEditor.Value;                        // 卸商入庫更新区分
            uoeSetting.DistSectionSetDiv = (int)this.DistSectionSetDiv_tComboEditor.Value;              // 卸商拠点設定区分

            // 2009.02.10 30413 犬飼 NULLチェックを追加 >>>>>>START
            // 2008.12.24 30413 犬飼 UOE伝票発行区分の追加 >>>>>>START
            //uoeSetting.UOESlipPrtDiv = (int)this.UOESlipPrtDiv_tComboEditor.Value;                      // UOE伝票発行区分
            // 2008.12.24 30413 犬飼 UOE伝票発行区分の追加 <<<<<<END
            if (this.UOESlipPrtDiv_tComboEditor.Value != null)
            {
                uoeSetting.UOESlipPrtDiv = (int)this.UOESlipPrtDiv_tComboEditor.Value;                  // UOE伝票発行区分
            }
            // 2009.02.10 30413 犬飼 NULLチェックを追加 <<<<<<END
            
            uoeSetting.InpSearchRemark = this.InpSearchRemark_tEdit.Text.TrimEnd();                     // 手入力検索リマーク
            uoeSetting.StockBlnktRemark = this.StockBlnktRemark_tEdit.Text.TrimEnd();                   // 在庫一括補充リマーク
            uoeSetting.SlipOutputRemark = this.SlipOutputRemark_tEdit.Text.TrimEnd();                   // 伝発リマーク
            uoeSetting.SlipOutputRemarkDiv = (int)this.SlipOutputRemarkDiv_tComboEditor.Value;          // 伝発リマーク区分
        }

        /// <summary>
        /// 画面展開処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : UOE自社クラスから画面にデータを展開します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private void UOESettingToScreen()
        {
            this.SlipOutputDivCd_tComboEditor.Value = this._uoeSetting.SlipOutputDivCd;                 // 伝票出力形態
            this.FollowSlipOutputDiv_tComboEditor.Value = this._uoeSetting.FollowSlipOutputDiv;         // ﾌｫﾛｰ伝票出力形態
            this.AddUpADateDiv_tComboEditor.Value = this._uoeSetting.AddUpADateDiv;                     // 伝発計上日
            this.StockBlnktPrtNoDiv_tComboEditor.Value = this._uoeSetting.StockBlnktPrtNoDiv;           // 在庫一括品番区分
            this.MakerFollowAddUpDiv_tComboEditor.Value = this._uoeSetting.MakerFollowAddUpDiv;         // ﾒｰｶｰﾌｫﾛｰ計上区分
            this.DistEnterDiv_tComboEditor.Value = this._uoeSetting.DistEnterDiv;                       // 卸商入庫更新
            this.DistSectionSetDiv_tComboEditor.Value = this._uoeSetting.DistSectionSetDiv;             // 卸商拠点設定

            // 2008.12.24 30413 犬飼 UOE伝票発行区分の追加 >>>>>>START
            this.UOESlipPrtDiv_tComboEditor.Value = this._uoeSetting.UOESlipPrtDiv;                     // UOE伝票発行区分
            // 2008.12.24 30413 犬飼 UOE伝票発行区分の追加 <<<<<<END

            this.InpSearchRemark_tEdit.Text = this._uoeSetting.InpSearchRemark;                         // 手入力・検索
            this.StockBlnktRemark_tEdit.Text = this._uoeSetting.StockBlnktRemark;                       // 在庫一括・補充
            this.SlipOutputRemark_tEdit.Text = this._uoeSetting.SlipOutputRemark;                       // 伝発マーク
            this.SlipOutputRemarkDiv_tComboEditor.Value = this._uoeSetting.SlipOutputRemarkDiv;         // 伝発区分
        }

        /// <summary>
        /// 画面クリア処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.SlipOutputDivCd_tComboEditor.Value = 1;                // 伝票出力形態
            this.FollowSlipOutputDiv_tComboEditor.Value = 0;            // ﾌｫﾛｰ伝票出力形態
            this.AddUpADateDiv_tComboEditor.Value = 0;                  // 伝発計上日
            this.StockBlnktPrtNoDiv_tComboEditor.Value = 0;             // 在庫一括品番区分
            this.MakerFollowAddUpDiv_tComboEditor.Value = 0;            // ﾒｰｶｰﾌｫﾛｰ計上区分
            this.DistEnterDiv_tComboEditor.Value = 0;                   // 卸商入庫更新
            this.DistSectionSetDiv_tComboEditor.Value = 0;              // 卸商拠点設定

            // 2008.12.24 30413 犬飼 UOE伝票発行区分の追加 >>>>>>START
            this.UOESlipPrtDiv_tComboEditor.Value = 0;                  // UOE伝票発行区分
            // 2008.12.24 30413 犬飼 UOE伝票発行区分の追加 <<<<<<END
            
            this.InpSearchRemark_tEdit.Clear();                         // 手入力・検索
            this.StockBlnktRemark_tEdit.Clear();                        // 在庫一括・補充
            this.SlipOutputRemark_tEdit.Text = "*";                     // 伝発マーク
            this.SlipOutputRemarkDiv_tComboEditor.Value = 1;            // 伝発区分
        }

        /// <summary>
        /// 画面再構築処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面を再構築します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            //const string ctPROCNM = "ScreenReconstruction";
            int status = 0;

            this._uoeSetting = new UOESetting();

            // UOE自社データ取得
            status = this._uoeSettingAcs.Read(out this._uoeSetting, this._enterpriseCode, this._sectionCode);
            
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (this._uoeSetting == null)
                {
                    this._uoeSetting = new UOESetting();
                }

                this.Mode_Label.Text = UPDATE_MODE;

                // UOE自社画面展開処理
                this.UOESettingToScreen();
                // 比較用クローン作成
                this._uoeSettingClone = this._uoeSetting.Clone();
                // 画面情報を比較用クローンにコピー
                this.DispToUOESetting(ref this._uoeSettingClone);

                // 初期フォーカスをセット
                this.SlipOutputDivCd_tComboEditor.Focus();
            }
            else
            {
                // リード
                //TMsgDisp.Show(
                //    this,                                 // 親ウィンドウフォーム
                //    emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
                //    CT_PGID,                              // アセンブリＩＤまたはクラスＩＤ
                //    CT_PGNM,                              // プログラム名称
                //    ctPROCNM,                             // 処理名称
                //    TMsgDisp.OPE_READ,                    // オペレーション
                //    "読み込みに失敗しました。",           // 表示するメッセージ
                //    status,                               // ステータス値
                //    this._uoeSettingAcs,                  // エラーが発生したオブジェクト
                //    MessageBoxButtons.OK,                 // 表示するボタン
                //    MessageBoxDefaultButton.Button1);    // 初期表示ボタン

                this.Mode_Label.Text = UPDATE_MODE;

                this._uoeSetting = new UOESetting();

                // UOE自社画面展開処理
                //this.UOESettingToScreen();
                // 比較用クローン作成
                this._uoeSettingClone = this._uoeSetting.Clone();
                // 画面情報を比較用クローンにコピー
                //this.DispToUOESetting(ref this._uoeSettingClone);

                // 初期フォーカスをセット
                this.SlipOutputDivCd_tComboEditor.Focus();
            }
        }

        /// <summary>
        /// 画面入力チェック処理
        /// </summary>
        /// <param name="control">対象コントロール</param>
        /// <param name="message">表示メッセージ</param>
        /// <returns>チェック結果(true: OK, false:NG)</returns>
        /// <remarks>
        /// <br>Note       : 画面の入力チェックを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string message)
        {
            int selectVal = -1;
            bool result = true;

            // コンボボックスの入力チェック（入力範囲が0を含まない項目）
            // 伝票出力形態
            selectVal = (int)this.SlipOutputDivCd_tComboEditor.Value;
            if ((selectVal < 1) && (6 < selectVal))
            {
                control = this.SlipOutputDivCd_tComboEditor;
                message = this.SlipOutputDivCd_Label.Text + "を選択して下さい。";
                return false;
            }

            // 2009.02.10 30413 犬飼 NULLチェックを追加 >>>>>>START
            // UOE伝票発行区分
            if (this.UOESlipPrtDiv_tComboEditor.Value == null)
            {
                control = this.UOESlipPrtDiv_tComboEditor;
                message = this.UOESlipPrtDiv_Label.Text + "を選択して下さい。";
                return false;
            }
            // 2009.02.10 30413 犬飼 NULLチェックを追加 <<<<<<END
            
            // 伝発区分
            selectVal = (int)this.SlipOutputRemarkDiv_tComboEditor.Value;
            if ((selectVal < 1) && (6 < selectVal))
            {
                control = this.SlipOutputRemarkDiv_tComboEditor;
                message = this.SlipOutputRemarkDiv_Label.Text + "を選択して下さい。";
                return false;
            }

            return result;
        }

        /// <summary>
        /// 保存処理
        /// </summary>
        /// <returns>結果</returns>
        /// <remarks>
        /// <br>Note       : UOE自社の保存を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private bool SaveProc()
        {
            const string ctPROCNM = "SaveProc";
            bool result = false;

            Control control = null;
            string message = null;
            if (this.ScreenDataCheck(ref control, ref message) == false)
            {
                // 入力チェック
                TMsgDisp.Show(
                    this,                                  // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
                    CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
                    message,                               // 表示するメッセージ
                    0,                                     // ステータス値
                    MessageBoxButtons.OK);                // 表示するボタン

                // コントロールを選択
                control.Focus();
                if (control is TEdit)
                {
                    ((TEdit)control).SelectAll();
                }
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }

                return false;
            }

            // 画面からUOE自社のデータを取得
            this.ScreenToUOESetting();

            int status = 0;
            status = this._uoeSettingAcs.Write(ref this._uoeSetting);
            
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        result = true;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // コード重複
                        TMsgDisp.Show(
                            this,                                    // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_INFO,             // エラーレベル
                            CT_PGID,                                 // アセンブリＩＤまたはクラスＩＤ
                            "このコードは既に使用されています。",    // 表示するメッセージ
                            0,                                       // ステータス値
                            MessageBoxButtons.OK);                  // 表示するボタン

                        return result;
                    }
                // 排他制御
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        this.ExclusiveTransaction(status, true);
                        return result;
                    }
                default:
                    {
                        // 登録失敗
                        TMsgDisp.Show(
                            this,                                 // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOP,          // エラーレベル
                            CT_PGID,                              // アセンブリＩＤまたはクラスＩＤ
                            CT_PGNM,                              // プログラム名称
                            ctPROCNM,                             // 処理名称
                            TMsgDisp.OPE_READ,                    // オペレーション
                            "登録に失敗しました。",           // 表示するメッセージ
                            status,                               // ステータス値
                            this._uoeSettingAcs,                  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,                 // 表示するボタン
                            MessageBoxDefaultButton.Button1);    // 初期表示ボタン

                        this.CloseForm(DialogResult.Cancel);

                        return result;
                    }
            }

            return result;
        }

        /// <summary>
        /// 排他処理
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">非表示フラグ(true: 非表示にする, false: 非表示にしない)</param>
        /// <remarks>
        /// <br>Note       : 排他処理を行います</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // 他端末更新
                        TMsgDisp.Show(
                            this,                                  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
                            CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より更新されています。",    // 表示するメッセージ
                            0,                                     // ステータス値
                            MessageBoxButtons.OK);                // 表示するボタン
                        if (hide == true)
                        {
                            this.CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // 他端末削除
                        TMsgDisp.Show(
                            this,                                  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,    // エラーレベル
                            CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
                            "既に他端末より削除されています。",    // 表示するメッセージ
                            0,                                     // ステータス値
                            MessageBoxButtons.OK);                // 表示するボタン
                        if (hide == true)
                        {
                            this.CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// フォームクローズ処理
        /// </summary>
        /// <param name="dialogResult">ダイアログ結果</param>
        /// <remarks>
        /// <br>Note       : フォームを閉じます。その際画面クローズイベント等の発生を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // 画面非表示イベント
            if (this.UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                this.UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // 比較用クローンクリア
            this._uoeSettingClone = null;

            // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
            // フォームを非表示化する。
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        #endregion

        #region << Control Events >>

        /// <summary>
        /// Form.Load イベント (PMUOE09040UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private void PMUOE09040UA_Load(object sender, EventArgs e)
        {
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
            
            // アイコンリソース管理クラスを使用して、アイコンを表示する
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Ok_Button.ImageList = imageList24;                     // 保存ボタン
            this.Cancel_Button.ImageList = imageList24;                 // 閉じるボタン

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;        // 保存ボタン
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;   // 閉じるボタン

            // 画面初期化
            this.ScreenInitialSetting();
        }

        /// <summary>
        /// Form.FormClosing イベント (PMUOE09040UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : ユーザーがフォームを閉じるたびに、フォームが閉じられる前、および閉じる理由を指定する前に発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private void PMUOE09040UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // チェック用クローン初期化
            this._uoeSettingClone = null;

            // ユーザーによって閉じられる場合
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルしてフォームを非表示化する。
                if (this._canClose == false)
                {
                    e.Cancel = true;
                    this.Hide();
                }
            }
        }

        /// <summary>
        /// Form.VisibleChanged イベント (PMUOE09040UA)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コントロールの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private void PMUOE09040UA_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // データがセットされていたら抜ける
            if (this._uoeSettingClone != null)
            {
                return;
            }

            this.Initial_Timer.Enabled = true;
            // 画面クリア
            this.ScreenClear();
        }

        /// <summary>
        /// Timer.Tick イベント (Initial_Timer)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 指定された間隔の時間が経過したときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;

            this.ScreenReconstruction();
        }

        /// <summary>
        /// UltraButton.Click イベント (Ok_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if (this.SaveProc() == false)
            {
                return;
            }

            // フォームを閉じる
            this.CloseForm(DialogResult.OK);
        }

        /// <summary>
        /// UltraButton.Click イベント (Cancel_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : コンポーネントがクリックされたときに発生します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2008.06.25</br>
        /// </remarks>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.Cancel;

            UOESetting compareUOESetting = new UOESetting();
            compareUOESetting = this._uoeSettingClone.Clone();
            this.DispToUOESetting(ref compareUOESetting);

            if (compareUOESetting.Equals(this._uoeSettingClone) == false)
            {
                // 画面情報が変更されていた場合は、保存確認メッセージを表示する
                // 保存確認
                DialogResult res = TMsgDisp.Show(
                    this,                                  // 親ウィンドウフォーム
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM,    // エラーレベル
                    CT_PGID,                               // アセンブリＩＤまたはクラスＩＤ
                    null,                                  // 表示するメッセージ
                    0,                                     // ステータス値
                    MessageBoxButtons.YesNoCancel);       // 表示するボタン
                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            if (this.SaveProc() == false)
                            {
                                return;
                            }
                            result = DialogResult.OK;
                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    default:
                        {
                            this.Cancel_Button.Focus();
                            return;
                        }
                }
            }

            // 画面を閉じる
            this.CloseForm(result);
        }

        #endregion
    }
}
