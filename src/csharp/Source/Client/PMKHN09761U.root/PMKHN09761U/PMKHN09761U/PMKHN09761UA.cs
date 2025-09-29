# region ※using
using Infragistics.Win.Misc;
using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Globarization;
using System.Text;
# endregion

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// 品番変換マスタ フォームクラス
	/// </summary>
	/// <remarks>
    /// <br>Note		: 品番変換の設定を行います。
	///					  IMasterMaintenanceMultiTypeを実装しています。</br>
    /// <br>Programmer  : 陳永康</br>
    /// <br>Date        : 2014/12/23</br>
    /// <br>UpdateNote  : Redmine#45436 No.93の対応</br>
    /// <br>            : 陳永康</br>
    /// <br>            : 2015/4/27</br>
    /// </remarks>
    public class PMKHN09761UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		# region ※Private Members (Component)

        private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
        private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private System.Windows.Forms.Timer Initial_Timer;
        private System.Data.DataSet Bind_DataSet;
        private Broadleaf.Library.Windows.Forms.TImeControl tImeControl1;
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private UltraLabel GoodsMakerCd_Label;
        private UltraLabel OldGoodsNo_Label;
        private TNedit tNedit_GoodsMakerCd;
        private TEdit tEdit_OldGoodsNo;
        private TEdit GoodsMakerName_tEdit;
        private UiSetControl uiSetControl1;
        private UltraButton GoodsMakerGuide_Button;
		private System.ComponentModel.IContainer components;
        private UltraLabel NewGoodsNo_Label;
        private TEdit tEdit_NewGoodsNo;

		# endregion

		# region ■Constructor
		/// <summary>
        /// 品番変換マスタ フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
        /// <br>Note       : 品番変換マスタ フォームクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer  : 陳永康</br>
        /// <br>Date        : 2014/12/23</br>
        /// </remarks>
        public PMKHN09761UA()
		{
			InitializeComponent();

			// データセット列情報構築処理
			DataSetColumnConstruction();

			// プロパティ初期値設定
			this._canPrint = false;
			this._canClose = false;
			this._canNew = true;
			this._canDelete = true;
			this._canLogicalDeleteDataExtraction = true;
			this._canClose = true;		// デフォルト:true固定
            this._defaultAutoFillToColumn = true;
            this._canSpecificationSearch = false;

			//　企業コード取得
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// 変数初期化
			this._dataIndex = -1;
            this._goodsNoChangeAcs = new GoodsNoChangeAcs();
			 
			this._totalCount = 0;
            this._goodsNoChangeTable = new Hashtable();

			//_dataIndexバッファ（メインフレーム最小化対応）
			this._indexBuf = -2;

            this._newGoodsNo = string.Empty;
		}
		# endregion

		# region ※Dispose
		/// <summary>
		/// 使用されているリソースに後処理を実行します。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		# endregion

		#region ※Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance56 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolTip.UltraToolTipInfo ultraToolTipInfo1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipInfo("メーカー名称ガイド", Infragistics.Win.ToolTipImage.Default, null, Infragistics.Win.DefaultableBoolean.Default);
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance44 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance45 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMKHN09761UA));
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tImeControl1 = new Broadleaf.Library.Windows.Forms.TImeControl(this.components);
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.GoodsMakerGuide_Button = new Infragistics.Win.Misc.UltraButton();
            this.GoodsMakerCd_Label = new Infragistics.Win.Misc.UltraLabel();
            this.OldGoodsNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tNedit_GoodsMakerCd = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tEdit_OldGoodsNo = new Broadleaf.Library.Windows.Forms.TEdit();
            this.GoodsMakerName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.uiSetControl1 = new Broadleaf.Library.Windows.Forms.UiSetControl(this.components);
            this.NewGoodsNo_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tEdit_NewGoodsNo = new Broadleaf.Library.Windows.Forms.TEdit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_OldGoodsNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_NewGoodsNo)).BeginInit();
            this.SuspendLayout();
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(305, 161);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 16;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 202);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(574, 23);
            this.ultraStatusBar1.TabIndex = 11;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Mode_Label
            // 
            appearance56.ForeColor = System.Drawing.Color.White;
            appearance56.TextHAlignAsString = "Center";
            appearance56.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance56;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(446, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 12;
            this.Mode_Label.Text = "更新モード";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(180, 161);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 15;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(305, 161);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 17;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(430, 161);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 18;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // tImeControl1
            // 
            this.tImeControl1.InControl = null;
            this.tImeControl1.OutControl = null;
            this.tImeControl1.OwnerForm = this;
            this.tImeControl1.PutLength = 30;
            // 
            // ultraToolTipManager1
            // 
            this.ultraToolTipManager1.ContainingControl = this;
            this.ultraToolTipManager1.DisplayStyle = Infragistics.Win.ToolTipDisplayStyle.Standard;
            // 
            // GoodsMakerGuide_Button
            // 
            this.GoodsMakerGuide_Button.Location = new System.Drawing.Point(174, 108);
            this.GoodsMakerGuide_Button.Name = "GoodsMakerGuide_Button";
            this.GoodsMakerGuide_Button.Size = new System.Drawing.Size(26, 26);
            this.GoodsMakerGuide_Button.TabIndex = 7;
            ultraToolTipInfo1.ToolTipText = "メーカー名称ガイド";
            this.ultraToolTipManager1.SetUltraToolTip(this.GoodsMakerGuide_Button, ultraToolTipInfo1);
            this.GoodsMakerGuide_Button.Click += new System.EventHandler(this.GoodsMakerGuide_Button_Click);
            // 
            // GoodsMakerCd_Label
            // 
            this.GoodsMakerCd_Label.Location = new System.Drawing.Point(30, 110);
            this.GoodsMakerCd_Label.Name = "GoodsMakerCd_Label";
            this.GoodsMakerCd_Label.Size = new System.Drawing.Size(79, 23);
            this.GoodsMakerCd_Label.TabIndex = 4;
            this.GoodsMakerCd_Label.Text = "メーカー";
            // 
            // OldGoodsNo_Label
            // 
            this.OldGoodsNo_Label.Location = new System.Drawing.Point(30, 51);
            this.OldGoodsNo_Label.Name = "OldGoodsNo_Label";
            this.OldGoodsNo_Label.Size = new System.Drawing.Size(79, 23);
            this.OldGoodsNo_Label.TabIndex = 8;
            this.OldGoodsNo_Label.Text = "旧品番";
            // 
            // tNedit_GoodsMakerCd
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tNedit_GoodsMakerCd.ActiveAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.tNedit_GoodsMakerCd.Appearance = appearance6;
            this.tNedit_GoodsMakerCd.AutoSelect = true;
            this.tNedit_GoodsMakerCd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tNedit_GoodsMakerCd.CalcSize = new System.Drawing.Size(172, 200);
            this.tNedit_GoodsMakerCd.DataText = "";
            this.tNedit_GoodsMakerCd.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tNedit_GoodsMakerCd.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.tNedit_GoodsMakerCd.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tNedit_GoodsMakerCd.Location = new System.Drawing.Point(125, 109);
            this.tNedit_GoodsMakerCd.MaxLength = 4;
            this.tNedit_GoodsMakerCd.Name = "tNedit_GoodsMakerCd";
            this.tNedit_GoodsMakerCd.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.tNedit_GoodsMakerCd.Size = new System.Drawing.Size(43, 24);
            this.tNedit_GoodsMakerCd.TabIndex = 6;
            // 
            // tEdit_OldGoodsNo
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_OldGoodsNo.ActiveAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_OldGoodsNo.Appearance = appearance14;
            this.tEdit_OldGoodsNo.AutoSelect = true;
            this.tEdit_OldGoodsNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_OldGoodsNo.DataText = "";
            this.tEdit_OldGoodsNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_OldGoodsNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_OldGoodsNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_OldGoodsNo.Location = new System.Drawing.Point(125, 49);
            this.tEdit_OldGoodsNo.MaxLength = 24;
            this.tEdit_OldGoodsNo.Name = "tEdit_OldGoodsNo";
            this.tEdit_OldGoodsNo.Size = new System.Drawing.Size(198, 24);
            this.tEdit_OldGoodsNo.TabIndex = 4;
            // 
            // GoodsMakerName_tEdit
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.GoodsMakerName_tEdit.ActiveAppearance = appearance7;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            appearance8.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance8.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            appearance8.Cursor = System.Windows.Forms.Cursors.Default;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            appearance8.TextVAlignAsString = "Middle";
            this.GoodsMakerName_tEdit.Appearance = appearance8;
            this.GoodsMakerName_tEdit.AutoSelect = true;
            this.GoodsMakerName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GoodsMakerName_tEdit.DataText = "あいうえおあいうえおあいうえお";
            this.GoodsMakerName_tEdit.Enabled = false;
            this.GoodsMakerName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.GoodsMakerName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, true, true, true, true));
            this.GoodsMakerName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.GoodsMakerName_tEdit.Location = new System.Drawing.Point(206, 109);
            this.GoodsMakerName_tEdit.MaxLength = 30;
            this.GoodsMakerName_tEdit.Name = "GoodsMakerName_tEdit";
            this.GoodsMakerName_tEdit.Size = new System.Drawing.Size(252, 24);
            this.GoodsMakerName_tEdit.TabIndex = 24;
            this.GoodsMakerName_tEdit.Tag = "False";
            this.GoodsMakerName_tEdit.Text = "あいうえおあいうえおあいうえお";
            // 
            // uiSetControl1
            // 
            this.uiSetControl1.EditWidthSettingWay = Broadleaf.Library.Windows.Forms.UiSetControl.EditWidthSettingWayState.None;
            this.uiSetControl1.OwnerForm = this;
            this.uiSetControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tRetKeyControl1_ChangeFocus);
            // 
            // NewGoodsNo_Label
            // 
            this.NewGoodsNo_Label.Location = new System.Drawing.Point(30, 81);
            this.NewGoodsNo_Label.Name = "NewGoodsNo_Label";
            this.NewGoodsNo_Label.Size = new System.Drawing.Size(79, 23);
            this.NewGoodsNo_Label.TabIndex = 26;
            this.NewGoodsNo_Label.Text = "新品番";
            // 
            // tEdit_NewGoodsNo
            // 
            appearance44.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.tEdit_NewGoodsNo.ActiveAppearance = appearance44;
            appearance45.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance45.ForeColorDisabled = System.Drawing.Color.Black;
            this.tEdit_NewGoodsNo.Appearance = appearance45;
            this.tEdit_NewGoodsNo.AutoSelect = true;
            this.tEdit_NewGoodsNo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.tEdit_NewGoodsNo.DataText = "";
            this.tEdit_NewGoodsNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.tEdit_NewGoodsNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 24, new Broadleaf.Library.Windows.Forms.TEnableChars(false, true, true, true, true, true, true));
            this.tEdit_NewGoodsNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.tEdit_NewGoodsNo.Location = new System.Drawing.Point(125, 79);
            this.tEdit_NewGoodsNo.MaxLength = 24;
            this.tEdit_NewGoodsNo.Name = "tEdit_NewGoodsNo";
            this.tEdit_NewGoodsNo.Size = new System.Drawing.Size(198, 24);
            this.tEdit_NewGoodsNo.TabIndex = 5;
            // 
            // PMKHN09761UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(574, 225);
            this.Controls.Add(this.NewGoodsNo_Label);
            this.Controls.Add(this.tEdit_NewGoodsNo);
            this.Controls.Add(this.GoodsMakerGuide_Button);
            this.Controls.Add(this.GoodsMakerCd_Label);
            this.Controls.Add(this.OldGoodsNo_Label);
            this.Controls.Add(this.tNedit_GoodsMakerCd);
            this.Controls.Add(this.tEdit_OldGoodsNo);
            this.Controls.Add(this.GoodsMakerName_tEdit);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Ok_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PMKHN09761UA";
            this.Text = "品番変換マスタ";
            this.Load += new System.EventHandler(this.PMKHN09761UA_Load);
            this.VisibleChanged += new System.EventHandler(this.PMKHN09761UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.PMKHN09761UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNedit_GoodsMakerCd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_OldGoodsNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GoodsMakerName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tEdit_NewGoodsNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region ■IMasterMaintenanceArrayTypeメンバー

		# region ▼Events
		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		# region ▼Properties
		/// <summary>印刷可能設定プロパティ</summary>
		/// <value>印刷可能かどうかの設定を取得します。</value>
		public bool CanPrint
		{
			get
			{
				return this._canPrint;
			}
		}

		/// <summary>件数指定抽出可能設定プロパティ</summary>
		/// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
		public bool CanSpecificationSearch
		{
			get
			{
				return this._canSpecificationSearch;
			}
		}

		/// <summary>論理削除データ抽出可能設定プロパティ</summary>
		/// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get
			{
				return this._canLogicalDeleteDataExtraction;
			}
		}

		/// <summary>画面終了設定プロパティ</summary>
		/// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
		/// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
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

		/// <summary>新規登録可能設定プロパティ</summary>
		/// <value>新規登録が可能かどうかの設定を取得します。</value>
		public bool CanNew
		{
			get
			{
				return this._canNew;
			}
		}

		/// <summary>削除可能設定プロパティ</summary>
		/// <value>削除が可能かどうかの設定を取得します。</value>
		public bool CanDelete
		{
			get
			{
				return this._canDelete;
			}
		}

		/// <summary>データセットの選択データインデックスプロパティ</summary>
		/// <value>データセットの選択データインデックスを取得または設定します。</value>
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

		/// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
		/// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
		public bool DefaultAutoFillToColumn
		{
			get
			{
				return this._defaultAutoFillToColumn;
			}
		}
		# endregion

        //メーカーコード変数
        int prvGoodsMakerCd = 0;

		# region ▼Public Methods
		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet">グリッドリッド用データセット</param>
		/// <param name="tableName">テーブル名称</param>
        /// <returns>なし</returns>
        /// <remarks>
		/// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = MAKERU_TABLE;
		}

		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList goodsNoChangeList = null;

            // 抽出対象件数が0の場合は全件抽出を実行する
            status = this._goodsNoChangeAcs.SearchAll(this._enterpriseCode, out goodsNoChangeList);
 
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        this._totalCount = goodsNoChangeList.Count;

                        if (goodsNoChangeList.Count > 0)
                        {
                            this._goodsNoChangeTable.Clear();
                            this.Bind_DataSet.Tables[MAKERU_TABLE].Clear();
                        }
                        int index = 0;
                        foreach (GoodsNoChange lgoodsgranre in goodsNoChangeList)
                        {
                            if (this._goodsNoChangeTable.ContainsKey(lgoodsgranre.FileHeaderGuid) == false)
                            {
                                GoodsNoChangeToDataSet(lgoodsgranre.Clone(), index);
                                ++index;
                            }
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this,								  // 親ウィンドウフォーム
                            emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
                            ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
                            this.Text,							  // プログラム名称
                            "Search",							  // 処理名称
                            TMsgDisp.OPE_GET,					  // オペレーション
                            ERR_READ_MSG,						  // 表示するメッセージ 
                            status,								  // ステータス値
                            this._goodsNoChangeAcs,				  // エラーが発生したオブジェクト
                            MessageBoxButtons.OK,				  // 表示するボタン
                            MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

                        break;
                    }
            }

            totalCount = this._totalCount;
            
            return status;
		}

		/// <summary>
		/// ネクストデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 指定した件数分のネクストデータを検索します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		public int SearchNext(int readCount)
		{
			// ネクストデータ検索処理（未実装）
			return 0;
		}

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 選択中のデータを削除します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		public int Delete()
		{
			int status = 0;
            Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsNoChangeAcs.FILEHEADERGUID_TITLE];
            GoodsNoChange goodsNoChange = ((GoodsNoChange)this._goodsNoChangeTable[guid]).Clone();
            status = this._goodsNoChangeAcs.LogicalDelete(ref goodsNoChange);

            switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 排他処理
                    ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._goodsNoChangeAcs);
					return status;
				}
                case (int)ConstantManagement.DB_Status.ctDB_ERROR:
                {
                    //削除不可
                    TMsgDisp.Show(this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        ASSEMBLY_ID,
                        "このレコードは品番変換マスタで削除して下さい",
                        status,
                        MessageBoxButtons.OK);
                    this.Hide();

                    return status;
                }
				case -2:
				{
					//主作業設定で使用中
					TMsgDisp.Show(this,
						emErrorLevel.ERR_LEVEL_EXCLAMATION,
						ASSEMBLY_ID,
						"このレコードは主作業設定で使用されているため削除できません",
						status,
						MessageBoxButtons.OK);
					this.Hide();

					return status;
				}

				default:
				{
					TMsgDisp.Show(
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						this.Text,							// プログラム名称
						"Delete",							// 処理名称
						TMsgDisp.OPE_HIDE,					// オペレーション
						ERR_RDEL_MSG,						// 表示するメッセージ 
						status,								// ステータス値
                        this._goodsNoChangeAcs,					// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン

					return status;
				}
			}

			// データセット展開処理
            GoodsNoChangeToDataSet(goodsNoChange.Clone(), this._dataIndex);
			return status;
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を実行します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		public int Print()
		{
			// 印刷用アセンブリをロードする（未実装）
			return 0;
		}

		/// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
		/// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

            #region ■グリッド列設定
            /******************
             *①削除日            
             *②論理削除区分    
             *③旧品番
             *④新品番
             *⑤商品メーカーコード
             *⑥メーカー名称      
             ******************/

            appearanceTable.Add(GoodsNoChangeAcs.DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft, "", Color.Red));
            appearanceTable.Add(GoodsNoChangeAcs.LOGICALDELETE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));
            appearanceTable.Add(GoodsNoChangeAcs.OLDGOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));             // 商品コード
            appearanceTable.Add(GoodsNoChangeAcs.NEWGOODSNO_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));             // 商品コード
            appearanceTable.Add(GoodsNoChangeAcs.GOODSMAKERCD_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));       // 商品メーカーコード
            appearanceTable.Add(GoodsNoChangeAcs.MAKERNAME_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));           // メーカー名称
            appearanceTable.Add(GoodsNoChangeAcs.FILEHEADERGUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));     // データテーブルカラム名称           
            #endregion

			return appearanceTable;
		}
		# endregion

		# endregion

		#region ■Private Menbers
        private GoodsNoChangeAcs _goodsNoChangeAcs;
		private int _totalCount;
		private string _enterpriseCode;
        private Hashtable _goodsNoChangeTable;

		// プロパティ用
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private bool _canSpecificationSearch;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
        private GoodsNoChange _goodsNoChangeClone;

		//_dataIndexバッファ（メインフレーム最小化対応）
		private int _indexBuf;

        private string _newGoodsNo;
		# endregion

		# region ■Consts
        private const string MAKERU_TABLE = "LGOODSGANRE";

		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";
		private const string DELETE_MODE = "削除モード";

		// Message関連定義
		private const string ASSEMBLY_ID	= "PMKHN09761U";
		private const string PG_NM			= "品番変換マスタ";
		private const string ERR_READ_MSG	= "読み込みに失敗しました。";
		private const string ERR_DPR_MSG	= "このコードは既に使用されています。";
		private const string ERR_RDEL_MSG	= "削除に失敗しました。";
		private const string ERR_UPDT_MSG	= "登録に失敗しました。";
		private const string ERR_RVV_MSG	= "復活に失敗しました。";
		private const string ERR_800_MSG	= "既に他端末より更新されています";
		private const string ERR_801_MSG	= "既に他端末より削除されています";
		private const string SDC_RDEL_MSG	= "マスタから削除されています";

        #endregion

        #region enum
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
            // キャンセル
            Cancel = 1
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
        #endregion enum

		# region ※Main
		/// <summary>アプリケーションのメイン エントリ ポイントです。</summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new PMKHN09761UA());
		}
		# endregion

		#region ■IMasterMaintenanceInputStart Members
		/// <summary>
		/// 
		/// </summary>
		/// <param name="paraTable"></param>
		/// <returns></returns>
		public DialogResult ShowDialog(Hashtable paraTable)
		{
			this.ShowDialog();
			return this.DialogResult;
		}
		#endregion

		# region ■Private Methods
		/// <summary>
        /// 品番変換マスタ オブジェクトデータセット展開処理
		/// </summary>
        /// <param name="goodsNoChange">品番変換マスタ オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
        /// <br>Note       : 品番変換マスタ クラスをデータセットに格納します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private void GoodsNoChangeToDataSet(GoodsNoChange goodsNoChange, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[MAKERU_TABLE].NewRow();
				this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Add(dataRow);

				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[MAKERU_TABLE].Rows.Count - 1;
			}

            if (goodsNoChange.LogicalDeleteCode == 0)
			{
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsNoChangeAcs.DELETE_DATE] = "";
            }
			else
			{
                this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsNoChangeAcs.DELETE_DATE] = TDateTime.DateTimeToString("ggYY/MM/DD", goodsNoChange.UpdateDateTime);
            }

            #region ●商品メーカー
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsNoChangeAcs.GOODSMAKERCD_TITLE] = goodsNoChange.GoodsMakerCd;
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsNoChangeAcs.MAKERNAME_TITLE] = goodsNoChange.MakerName;
            #endregion

            #region ●商品コード
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsNoChangeAcs.OLDGOODSNO_TITLE] = goodsNoChange.OldGoodsNo;
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsNoChangeAcs.NEWGOODSNO_TITLE] = goodsNoChange.NewGoodsNo;
            #endregion
          
            this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[index][GoodsNoChangeAcs.FILEHEADERGUID_TITLE] = goodsNoChange.FileHeaderGuid;

            if (this._goodsNoChangeTable.ContainsKey(goodsNoChange.FileHeaderGuid))
            {
                this._goodsNoChangeTable.Remove(goodsNoChange.FileHeaderGuid);
            }
            this._goodsNoChangeTable.Add(goodsNoChange.FileHeaderGuid, goodsNoChange);

        }

		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void DataSetColumnConstruction()
		{
            DataTable goodsNoChangeTable = new DataTable(MAKERU_TABLE);

            // Addを行う順番が、列の表示順位となります。
            goodsNoChangeTable.Columns.Add(GoodsNoChangeAcs.DELETE_DATE, typeof(string));

            // 商品コード
            goodsNoChangeTable.Columns.Add(GoodsNoChangeAcs.OLDGOODSNO_TITLE, typeof(string));
            goodsNoChangeTable.Columns.Add(GoodsNoChangeAcs.NEWGOODSNO_TITLE, typeof(string));
            // 商品メーカー
            goodsNoChangeTable.Columns.Add(GoodsNoChangeAcs.GOODSMAKERCD_TITLE, typeof(int));
            goodsNoChangeTable.Columns.Add(GoodsNoChangeAcs.MAKERNAME_TITLE, typeof(string));


            // GUID
            goodsNoChangeTable.Columns.Add(GoodsNoChangeAcs.FILEHEADERGUID_TITLE, typeof(Guid));

            this.Bind_DataSet.Tables.Add(goodsNoChangeTable);
        }

		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void ScreenInitialSetting()
		{
            Point point = new Point();
            point.X = this.Cancel_Button.Location.X;
            point.Y = this.Cancel_Button.Location.Y;

            point.X = point.X - this.Ok_Button.Size.Width;
            this.Ok_Button.Location     = point;
            this.Revive_Button.Location = point;

            point.X = point.X - this.Delete_Button.Size.Width;
            this.Delete_Button.Location = point;
        }

		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面をクリアします。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void ScreenClear()
		{
            this.tNedit_GoodsMakerCd.Clear();
            this.GoodsMakerName_tEdit.Clear();
            this.tEdit_OldGoodsNo.Clear();
            this.tEdit_NewGoodsNo.Clear();
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void ScreenReconstruction()
		{
			if (this.DataIndex < 0)
			{
				// 新規モード
				this.Mode_Label.Text = INSERT_MODE;

                // ボタン設定
                this.Ok_Button.Visible = true;
                this.Delete_Button.Visible = false;
                this.Revive_Button.Visible = false;
                
                //_dataIndexバッファ保持
				this._indexBuf = this._dataIndex;
                                       				
				// 画面入力許可制御処理
				ScreenInputPermissionControl(true);

                this.tEdit_OldGoodsNo.Focus();

                GoodsNoChange goodsNoChange = new GoodsNoChange();
				//クローン作成
                this._goodsNoChangeClone = goodsNoChange.Clone(); 
                DispToGoodsNoChange(ref this._goodsNoChangeClone);

            }
			else
			{
                Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsNoChangeAcs.FILEHEADERGUID_TITLE];
                GoodsNoChange goodsNoChange = (GoodsNoChange)this._goodsNoChangeTable[guid];

                if (goodsNoChange.LogicalDeleteCode == 0)
				{
					// 更新モード
					this.Mode_Label.Text = UPDATE_MODE;

					// ボタン設定
					this.Ok_Button.Visible = true;
					this.Delete_Button.Visible = false;
					this.Revive_Button.Visible = false;

					// 画面入力許可制御処理
                    ScreenInputPermissionControl(false);
                    this.tEdit_NewGoodsNo.Focus();

					// 画面展開処理
                    MakerUMntToScreen(goodsNoChange);

					//クローン作成
                    this._goodsNoChangeClone = goodsNoChange.Clone();
                    DispToGoodsNoChange(ref this._goodsNoChangeClone);
                    //_dataIndexバッファ保持
					this._indexBuf = this._dataIndex;
                    

				}
				else
				{
					// 削除モード
					this.Mode_Label.Text = DELETE_MODE;

					// ボタン設定
					this.Ok_Button.Visible = false;
					this.Revive_Button.Visible = true;
                    this.Delete_Button.Visible = true;
					//_dataIndexバッファ保持
					this._indexBuf = this._dataIndex;

					// 画面入力許可制御処理
					ScreenInputPermissionControl(false);

					// 画面展開処理
                    MakerUMntToScreen(goodsNoChange);

					// フォーカス設定
					this.Delete_Button.Focus();
				}

			}
		}

		/// <summary>
		/// 画面入力許可制御処理
		/// </summary>
		/// <param name="enabled">入力許可設定値</param>
		/// <remarks>
		/// <br>Note       : 画面の入力許可を制御します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private void ScreenInputPermissionControl(bool enabled)
        {
            this.tNedit_GoodsMakerCd.Enabled = enabled;
            this.tEdit_OldGoodsNo.Enabled = enabled;
            this.tEdit_NewGoodsNo.Enabled = enabled;
            this.GoodsMakerGuide_Button.Enabled = enabled;  // 商品メーカーガイドボタン

            if (this.Mode_Label.Text == UPDATE_MODE)
            {
                this.tEdit_NewGoodsNo.Enabled = true;
            }
        }

		/// <summary>
        /// 品番変換マスタ クラス画面展開処理
		/// </summary>
        /// <param name="goodsNoChange">品番変換設定マスタ オブジェクト</param>
		/// <remarks>
        /// <br>Note       : 品番変換マスタ オブジェクトから画面にデータを展開します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private void MakerUMntToScreen(GoodsNoChange goodsNoChange)
        {
            #region ●商品メーカー
            if (goodsNoChange.GoodsMakerCd != 0)
            {
                this.tNedit_GoodsMakerCd.SetInt(goodsNoChange.GoodsMakerCd);
            }
            if (goodsNoChange.MakerName != string.Empty)
            {
                this.GoodsMakerName_tEdit.DataText = goodsNoChange.MakerName;
            }
            #endregion

            #region ●商品コード
            if (goodsNoChange.OldGoodsNo != string.Empty)
            {
                this.tEdit_OldGoodsNo.DataText = goodsNoChange.OldGoodsNo;
            }
            if (goodsNoChange.NewGoodsNo != string.Empty)
            {
                this.tEdit_NewGoodsNo.DataText = goodsNoChange.NewGoodsNo;
                this._newGoodsNo = this.tEdit_NewGoodsNo.Text.Trim();
            }
            #endregion

        }

		/// <summary>
		/// Valueチェック処理（int）
		/// </summary>
		/// <param name="sorce">tComboのValue</param>
		/// <returns>チェック後の値</returns>
		/// <remarks>
		/// <br>Note       : tComboの値をClassに入れる時のNULLチェックを行います。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private int ValueToInt(object sorce)
		{
			int dest = 0;
			try
			{
				dest = Convert.ToInt32(sorce);
			}
			catch
			{
				return dest;
			}
			return dest;
		}

        /// <summary>
        /// 画面情報格納処理
        /// </summary>
        /// <param name="goodsNoChange">品番変換データクラス</param>
        /// <remarks>
        /// Note       : 画面情報のデータクラス格納処理を行います<br />
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private void DispToGoodsNoChange(ref GoodsNoChange goodsNoChange)
        {
            if (goodsNoChange == null)
            {
                // 新規の場合
                goodsNoChange = new GoodsNoChange();
            }

            goodsNoChange.EnterpriseCode = this._enterpriseCode;

            goodsNoChange.GoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();   // 商品メーカーコード
            goodsNoChange.MakerName = this.GoodsMakerName_tEdit.DataText;     // メーカー名称
            goodsNoChange.OldGoodsNo = this.tEdit_OldGoodsNo.DataText;        // 旧商品コード
            goodsNoChange.NewGoodsNo = this.tEdit_NewGoodsNo.DataText;        // 新商品コード
        }


        /// <summary>
		/// 画面入力情報不正チェック処理
		/// </summary>
		/// <param name="control">不正対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <param name="loginID">ログインID</param>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の不正チェックを行います。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
 		private bool ScreenDataCheck(ref Control control, ref string message, string loginID)
		{
			bool result = true;

            #region < メーカー,品番入力チェック >

            if (this.Mode_Label.Text == INSERT_MODE || this.Mode_Label.Text == UPDATE_MODE)
            {
                string valNew = this.tEdit_NewGoodsNo.Text.Trim();
                if (!(valNew.Length == Encoding.Default.GetByteCount(valNew)))
                {
                    this.tEdit_NewGoodsNo.Text = string.Empty;
                }
                string valOld = this.tEdit_OldGoodsNo.Text.Trim();
                if (!(valOld.Length == Encoding.Default.GetByteCount(valOld)))
                {
                    this.tEdit_OldGoodsNo.Text = string.Empty;
                }
                if (this.tEdit_OldGoodsNo.DataText.Trim().Equals(string.Empty))
                {
                    message = "旧品番を入力して下さい。";
                    control = this.tEdit_OldGoodsNo;
                    result = false;
                }
                else if (this.tEdit_NewGoodsNo.DataText.Trim().Equals(string.Empty))
                {
                    message = "新品番を入力して下さい。";
                    control = this.tEdit_NewGoodsNo;
                    result = false;
                }
                else if (this.tEdit_OldGoodsNo.DataText.Trim() == this.tEdit_NewGoodsNo.DataText.Trim())
                {
                    message = "新旧品番が重複しています。";
                    control = this.tEdit_NewGoodsNo;
                    result = false;
                }
                else if (this.tNedit_GoodsMakerCd.GetInt() == 0)
                {
                    message = "メーカーを入力して下さい。";
                    control = this.tNedit_GoodsMakerCd;
                    result = false;
                }
                else
                {
                    // メーカーデータクラス
                    MakerUMnt makerUMnt;
                    // 商品データクラスインスタンス化
                    MakerAcs makerAcs = new MakerAcs();

                    #region < メーカー情報取得処理 >
                    makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_GoodsMakerCd.GetInt());
                    #endregion
                    if (makerUMnt != null && makerUMnt.LogicalDeleteCode != 1)
                    {
                        this.GoodsMakerName_tEdit.DataText = makerUMnt.MakerName;
                    }
                    else
                    {
                        message = "メーカーが登録されていません。";
                        control = this.tNedit_GoodsMakerCd;
                        this.tNedit_GoodsMakerCd.SetInt(prvGoodsMakerCd);
                        result = false;
                    }
                }
            }
            #endregion

			return result;
		}

		/// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="operation">オペレーション</param>
		/// <param name="erObject">エラーオブジェクト</param>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : データ更新時の排他処理を行います。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void ExclusiveTransaction(int status, string operation, object erObject)
		{				   
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						this.Text,							// プログラム名称
						"ExclusiveTransaction",				// 処理名称
						operation,							// オペレーション
						ERR_800_MSG,						// 表示するメッセージ 
						status,								// ステータス値
						erObject,							// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						this.Text,							// プログラム名称
						"ExclusiveTransaction",				// 処理名称
						operation,							// オペレーション
						ERR_801_MSG,						// 表示するメッセージ 
						status,								// ステータス値
						erObject,							// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン
					break;
				}
			}
		}
		# endregion

		#region ■Control Events
		/// <summary>
		/// Form.Load イベント(PMKHN09761UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private void PMKHN09761UA_Load(object sender, System.EventArgs e)
		{
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList25 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList     = imageList25;
			this.Cancel_Button.ImageList = imageList25;
			this.Revive_Button.ImageList = imageList25;
			this.Delete_Button.ImageList = imageList25;

            this.GoodsMakerGuide_Button.ImageList        = imageList16;
            // 処理ボタンのアイコン設定
            this.Ok_Button.Appearance.Image     = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

            // ガイドボタンのアイコン設定
            this.GoodsMakerGuide_Button.Appearance.Image        = Size16_Index.STAR1;

			// 画面初期設定処理
            ScreenInitialSetting();
		}

		/// <summary>
        /// Form.Closing イベント(PMKHN09761UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note       : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private void PMKHN09761UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._indexBuf = -2;

			// フォームの「×」をクリックされた場合の対応です。
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

		/// <summary>
        /// Control.VisibleChanged イベント(DCKHN09090UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　 : フォームの表示状態が変わったときに発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private void PMKHN09761UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// 自分自身が非表示になった場合は以下の処理をキャンセルする。
			if (this.Visible == false)
			{
				this.Owner.Activate();
				return;
			}

			// 自分自身が非表示になった場合、
			// またはターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}

			Initial_Timer.Enabled = true;
			ScreenClear();
		}

		/// <summary>
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 保存ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			if (SaveProc() == false)
			{
				return;
			}
			// 新規モードの場合は画面を終了せずに連続入力を可能とする
			if (this.Mode_Label.Text == INSERT_MODE)
			{
				// データインデックスを初期化する
				this.DataIndex = -1;

				// 画面クリア処理
                this.tNedit_GoodsMakerCd.Clear();
                this.GoodsMakerName_tEdit.Clear();
                this.tEdit_OldGoodsNo.Clear();
                this.tEdit_NewGoodsNo.Clear();

				// 新規モード
				this.Mode_Label.Text = INSERT_MODE;

				this.Ok_Button.Visible = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;

				ScreenInputPermissionControl(true);

				// 初期値設定

				// クローンを再度取得する
                GoodsNoChange goodsNoChange = new GoodsNoChange();
				
				//クローン作成
                this._goodsNoChangeClone = goodsNoChange.Clone(); 
                DispToGoodsNoChange(ref this._goodsNoChangeClone);

				// フォーカス設定
                this.tEdit_OldGoodsNo.Focus();
                //SetKind_tComboEditor_ValueChanged(sender, e);
            }
			else
			{
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
			}
		}
		/// <summary>
        /// 品番変換マスタ 情報登録処理
		/// </summary>
		/// <returns>登録結果（true:OK／false:NG）</returns>
		/// <remarks>
        /// <br>Note       : 品番変換マスタ 情報登録を行います。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private bool SaveProc()
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			Control control = null;
			string message = null;
			string loginID = "";

            GoodsNoChange goodsNoChange = null;


			if (this.DataIndex >= 0)
			{
                Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsNoChangeAcs.FILEHEADERGUID_TITLE];
                goodsNoChange = ((GoodsNoChange)this._goodsNoChangeTable[guid]).Clone();
			}

            if (!ScreenDataCheck(ref control, ref message, loginID))
            {
				TMsgDisp.Show( 
					this,								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
					ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
					message,							// 表示するメッセージ 
					0,									// ステータス値
					MessageBoxButtons.OK);				// 表示するボタン

				control.Focus();
				return false;
            }

            #region 品番重複チェクウ
            ArrayList goodsNoChangeList = null;
            status = this._goodsNoChangeAcs.SearchAll(this._enterpriseCode, out goodsNoChangeList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 品番変換マスタのDictionaryの作成
                Dictionary<string, GoodsNoChange> oldGoodsNoChangeDict = new Dictionary<string, GoodsNoChange>();
                foreach (GoodsNoChange work in goodsNoChangeList)
                {
                    string key = work.EnterpriseCode + "-" + work.OldGoodsNo.Trim() + "-" + work.GoodsMakerCd.ToString().PadLeft(4, '0');
                    if (!oldGoodsNoChangeDict.ContainsKey(key))
                    {
                        oldGoodsNoChangeDict.Add(key, work);
                    }
                }
                Dictionary<string, GoodsNoChange> newGoodsNoChangeDict = new Dictionary<string, GoodsNoChange>();
                foreach (GoodsNoChange work in goodsNoChangeList)
                {
                    string key = work.EnterpriseCode + "-" + work.NewGoodsNo.Trim() + "-" + work.GoodsMakerCd.ToString().PadLeft(4, '0');
                    if (!newGoodsNoChangeDict.ContainsKey(key))
                    {
                        newGoodsNoChangeDict.Add(key, work);
                    }
                }
                string key1 = this._enterpriseCode + "-" + this.tEdit_OldGoodsNo.DataText.Trim() + "-" + this.tNedit_GoodsMakerCd.DataText.Trim().PadLeft(4, '0');
                string key2 = this._enterpriseCode + "-" + this.tEdit_NewGoodsNo.DataText.Trim() + "-" + this.tNedit_GoodsMakerCd.DataText.Trim().PadLeft(4, '0');

                if (this.Mode_Label.Text == UPDATE_MODE)
                {
                    if (!_newGoodsNo.Equals(this.tEdit_NewGoodsNo.DataText.Trim()))
                    {
                        if (oldGoodsNoChangeDict.ContainsKey(key2) || newGoodsNoChangeDict.ContainsKey(key2))
                        {
                            message = "新品番は既に品番変換マスタに登録されています。";
                            control = this.tEdit_NewGoodsNo;
                        }
                    }
                }

                if (this.Mode_Label.Text == INSERT_MODE)
                {
                    if (oldGoodsNoChangeDict.ContainsKey(key1) || newGoodsNoChangeDict.ContainsKey(key1))
                    {
                        message = "旧品番は既に品番変換マスタに登録されています。";
                        control = this.tEdit_OldGoodsNo;
                    }
                    else if (oldGoodsNoChangeDict.ContainsKey(key2) || newGoodsNoChangeDict.ContainsKey(key2))
                    {
                        message = "新品番は既に品番変換マスタに登録されています。";
                        control = this.tEdit_NewGoodsNo;
                    }
                    else
                    { 
                    }
                }
                if (!string.IsNullOrEmpty(message))
                {
                    TMsgDisp.Show(
                                        this,								// 親ウィンドウフォーム
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
                                        ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                                        message,							// 表示するメッセージ 
                                        0,									// ステータス値
                                        MessageBoxButtons.OK);				// 表示するボタン
                    control.Focus();
                    return false;
                }
            }
            #endregion

            this.DispToGoodsNoChange(ref goodsNoChange);

            status = this._goodsNoChangeAcs.Write(ref goodsNoChange);
            switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
                        ERR_800_MSG,						// 表示するメッセージ
						status,								// ステータス値
						MessageBoxButtons.OK);				// 表示するボタン

                    this.tEdit_NewGoodsNo.Focus();
                    this.tEdit_NewGoodsNo.SelectAll();
                    return false;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._goodsNoChangeAcs);

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
					TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						this.Text,							// プログラム名称
						"SaveProc",							// 処理名称
						TMsgDisp.OPE_UPDATE,				// オペレーション
						ERR_UPDT_MSG,						// 表示するメッセージ 
						status,								// ステータス値
                        this._goodsNoChangeAcs,				// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン
					
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
			}

			// DataSet展開処理
            GoodsNoChangeToDataSet(goodsNoChange, this.DataIndex);

            if (UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
                UnDisplaying(this, me);
            }
			
			return true;
		}

		/// <summary>
		/// ゼロ埋め後テキスト取得処理実装
		/// </summary>
		/// <param name="fullText">入力済みテキスト</param>
		/// <param name="columnCount">入力可能桁数</param>
		/// <returns>ゼロ埋めしたテキスト</returns>
		/// <br>Note       : 文字列をゼロ埋めします。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
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
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
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
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
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

		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 閉じるボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// 削除モード以外の場合は保存確認処理を行う
			if (this.Mode_Label.Text != DELETE_MODE) 
			{
				//保存確認
                GoodsNoChange compareGoodsNoChange = new GoodsNoChange();
                compareGoodsNoChange = this._goodsNoChangeClone.Clone();  
				//現在の画面情報を取得する
                DispToGoodsNoChange(ref compareGoodsNoChange);
                //最初に取得した画面情報と比較
                if (!(this._goodsNoChangeClone.Equals(compareGoodsNoChange)))	
				{
					//画面情報が変更されていた場合は、保存確認メッセージを表示する
					DialogResult res = TMsgDisp.Show( 
						this,								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_SAVECONFIRM,	// エラーレベル
						ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
						"",									// 表示するメッセージ 
						0,									// ステータス値
						MessageBoxButtons.YesNoCancel);		// 表示するボタン

					switch(res)
					{
						case DialogResult.Yes:
						{
							if (SaveProc() == false)
							{
								return;
							}

							if (UnDisplaying != null)
							{
								MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
								UnDisplaying(this, me);
							}

							break;
						}
						case DialogResult.No:
						{
							if (UnDisplaying != null)
							{
								MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
								UnDisplaying(this, me);
							}

							break;
						}
						default:
						{
							this.Cancel_Button.Focus();
							return;
						}
					}
				}

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
		}

		/// <summary>
		/// Control.Click イベント(Delete_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			int status = 0;
			DialogResult result = TMsgDisp.Show( 
				this,													// 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_QUESTION,						// エラーレベル
				ASSEMBLY_ID,											// アセンブリＩＤまたはクラスＩＤ
				"データを削除します。" + "\r\n" + "よろしいですか？",	// 表示するメッセージ 
				0,														// ステータス値
				MessageBoxButtons.OKCancel,								// 表示するボタン
				MessageBoxDefaultButton.Button2);						// 初期表示ボタン


			if (result == DialogResult.OK)
			{
                Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsNoChangeAcs.FILEHEADERGUID_TITLE];
                GoodsNoChange goodsNoChange = ((GoodsNoChange)this._goodsNoChangeTable[guid]).Clone();
                
                status = this._goodsNoChangeAcs.Delete(goodsNoChange);

                switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this.DataIndex].Delete();
                        this._goodsNoChangeTable.Remove(goodsNoChange.FileHeaderGuid);

						break;
					}
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
                        ExclusiveTransaction(status, TMsgDisp.OPE_DELETE, this._goodsNoChangeAcs);

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
						
						return;
					}
					default:
					{
						TMsgDisp.Show( 
							this,								  // 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
							ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
							this.Text,							  // プログラム名称
							"Delete_Button_Click",				  // 処理名称
							TMsgDisp.OPE_DELETE,				  // オペレーション
							ERR_RDEL_MSG,						  // 表示するメッセージ 
							status,								  // ステータス値
                            this._goodsNoChangeAcs,				  // エラーが発生したオブジェクト
							MessageBoxButtons.OK,				  // 表示するボタン
							MessageBoxDefaultButton.Button1);	  // 初期表示ボタン
						
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
						
						return;
					}
				}
			}
			else
			{
				this.Delete_Button.Focus();
				return;
			}

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
		}

		/// <summary>
		/// Control.Click イベント(Revive_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note 　　  : 復活ボタンコントロールがクリックされたときに発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            Guid guid = (Guid)this.Bind_DataSet.Tables[MAKERU_TABLE].Rows[this._dataIndex][GoodsNoChangeAcs.FILEHEADERGUID_TITLE];
            GoodsNoChange goodsNoChange = ((GoodsNoChange)_goodsNoChangeTable[guid]).Clone();

            status = this._goodsNoChangeAcs.Revival(ref goodsNoChange);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
                    ExclusiveTransaction(status, TMsgDisp.OPE_UPDATE, this._goodsNoChangeAcs);

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
					
					return;
				}
				default:
				{
					TMsgDisp.Show( 
						this,								  // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOPDISP,	  // エラーレベル
						ASSEMBLY_ID,						  // アセンブリＩＤまたはクラスＩＤ
						this.Text,							  // プログラム名称
						"Revive_Button_Click",				  // 処理名称
						TMsgDisp.OPE_UPDATE,				  // オペレーション
						ERR_RVV_MSG,						  // 表示するメッセージ 
						status,								  // ステータス値
                        this._goodsNoChangeAcs,				  // エラーが発生したオブジェクト
						MessageBoxButtons.OK,				  // 表示するボタン
						MessageBoxDefaultButton.Button1);	  // 初期表示ボタン

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
					
					return;
				}
			}

			// DataSet展開処理
            GoodsNoChangeToDataSet(goodsNoChange, this.DataIndex);

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
		}

		/// <summary>
		/// Timer.Tick イベント イベント(Initial_Timer)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 指定された間隔の時間が経過したときに発生します。
		///					  この処理は、システムが提供するスレッド プール
		///					  スレッドで実行されます。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
            ScreenReconstruction();
		}

		/// <summary>
		/// TRetKeyControl.ChangeFocus イベント イベント(tRetKeyControl1)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　 : フォーカスが遷移する際に発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
		private void tRetKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
		{
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            if (e.NextCtrl == this.tNedit_GoodsMakerCd)
            {
                prvGoodsMakerCd = this.tNedit_GoodsMakerCd.GetInt();
            }

            switch (e.PrevCtrl.Name)
            {
                case "tNedit_GoodsMakerCd":
                    {
                        #region < ゼロ入力チェック >
                        if (this.tNedit_GoodsMakerCd.GetInt() != 0)
                        {
                            if (prvGoodsMakerCd != tNedit_GoodsMakerCd.GetInt())
                            {
                                // メーカーデータクラス
                                MakerUMnt makerUMnt;
                                // 商品データクラスインスタンス化
                                MakerAcs makerAcs = new MakerAcs();

                                #region < メーカー情報取得処理 >
                                makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_GoodsMakerCd.GetInt());
                                #endregion

                                #region < 画面表示処理 >

                                if (makerUMnt != null && makerUMnt.LogicalDeleteCode != 1)
                                {
                                    #region -- 取得データ展開 --
                                    // メーカー情報画面表示
                                    this.GoodsMakerName_tEdit.DataText = makerUMnt.MakerName;
                                    if (!e.ShiftKey)
                                    {
                                        if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                                        {
                                            e.NextCtrl = this.Ok_Button;
                                        }
                                    }
                                    #endregion
                                }
                                else
                                {
                                    #region -- 取得失敗 --
                                    TMsgDisp.Show(
                                        this,
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                        this.Name,
                                        "メーカーが登録されていません。",
                                        -1,
                                        MessageBoxButtons.OK);

                                    this.tNedit_GoodsMakerCd.SetInt(prvGoodsMakerCd);
                                    e.NextCtrl.Select();
                                    e.NextCtrl = tNedit_GoodsMakerCd;
                                    #endregion
                                }
                                #endregion
                            }
                            else
                            {
                                if (!e.ShiftKey)
                                {
                                    if (e.Key == Keys.Enter || e.Key == Keys.Tab)
                                    {
                                        e.NextCtrl = this.Ok_Button;
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.tNedit_GoodsMakerCd.DataText = string.Empty;
                            this.GoodsMakerName_tEdit.DataText = string.Empty;
                        }
                        #endregion

                        break;
                    }

                case "tEdit_OldGoodsNo":
                    {
                        string val = this.tEdit_OldGoodsNo.Text.Trim();
                        if (!(val.Length == Encoding.Default.GetByteCount(val)))
                        {
                            this.tEdit_OldGoodsNo.Text = string.Empty;
                        }
                        break;
                    }

                case "tEdit_NewGoodsNo":
                    {
                        string val = this.tEdit_NewGoodsNo.Text.Trim();
                        if (!(val.Length == Encoding.Default.GetByteCount(val)))
                        {
                            this.tEdit_NewGoodsNo.Text = string.Empty;
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// 検索タイプ取得処理
        /// </summary>
        /// <param name="inputCode">入力されたコード</param>
        /// <param name="searchCode">検索用コード（*を除く）</param>
        /// <returns>0:完全一致検索 1:前方一致検索 2:後方一致検索 3:曖昧検索</returns>
        /// <remarks>
        /// Note           : 検索する方法を取得する処理を行います。<br />
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
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

        # endregion

		# region ガイド処理
        /// <summary>
        /// Control.Click イベント(GoodsMakerGuide_Button)
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントパラメータ</param>
        /// <remarks>
        /// <br>Note       : 商品メーカーガイドボタンがクリックされたときに発生します。</br>
        /// <br>Programmer : 陳永康</br>
        /// <br>Date       : 2014/12/23</br>
        /// </remarks>
        private void GoodsMakerGuide_Button_Click(object sender, EventArgs e)
        {
            MakerAcs makerAcs = new MakerAcs();
            MakerUMnt makerUMnt = new MakerUMnt();

            //メーカーガイド起動
            int status = makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt);
            if (status != 0) return;

            // 取得データ表示
            this.tNedit_GoodsMakerCd.SetInt(makerUMnt.GoodsMakerCd);
            this.GoodsMakerName_tEdit.DataText = makerUMnt.MakerName;

            // --- DEL 陳永康 2015/04/27 Redmine#45436 No.93の対応----->>>>>
            //// 商品データとの整合性を取るため商品情報のクリア
            //this.tEdit_OldGoodsNo.Clear();
            // --- DEL 陳永康 2015/04/27 Redmine#45436 No.93の対応-----<<<<<
        }
        # endregion
    }
}
