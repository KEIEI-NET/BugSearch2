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

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 仕入金額処理区分設定フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 仕入金額処理区分の設定を行います。
	///					 IMasterMaintenanceMultiTypeを実装しています。</br>
	/// <br>Programmer : 30167 上野 弘貴</br>
	/// <br>Date       : 2007.08.20</br>
	/// <br>Update Note: 2008.02.07 30167 上野　弘貴
	/// <br>			 ・重複メッセージ修正
	///					 ・消費税設定の上限金額オール9に設定</br>
    /// <br>           : 2008/11/07       照田 貴志</br>
    /// <br>           　・単数処理コードの入力桁を9→4に変更</br>
    /// <br>           : 2009/02/05 30414 忍 幸史</br>
    /// <br>           　・単数処理コードの入力桁を4→8に変更</br>
    /// </remarks>
	public class DCKON09100UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		# region Private Members (Component)
		private Infragistics.Win.Misc.UltraLabel FRACPROCMONEYDIV_TITLE_Label;
		private Infragistics.Win.Misc.UltraLabel FRACTIONPROCCODE_TITLE_Label;
		private Infragistics.Win.Misc.UltraLabel UPPERLIMITPRICE_TITLE_Label;
		private Infragistics.Win.Misc.UltraLabel FRACTIONPROCUNIT_TITLE_Label;
		private Infragistics.Win.Misc.UltraLabel FRACTIONPROCCD_TITLE_Label;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private System.Data.DataSet Bind_DataSet;
		private TComboEditor fracProcMoneyDiv_tComboEditor1;
		private TNedit upperLimitPrice_tNedit2;
		private TNedit fractionProcCode_tNedit1;
		private TComboEditor fractionProcCd_tComboEditor2;
		private TNedit fractionProcUnit_tNedit3;
		private System.ComponentModel.IContainer components;
		# endregion

		/// <summary>
		/// 仕入金額処理区分設定情報入力フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定情報入力フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2005.08.14</br>
		/// </remarks>
		public DCKON09100UA()
		{
			InitializeComponent();

			// データセット列情報構築処理
			DataSetColumnConstruction();

			// プロパティ初期値設定
			this._canPrint	= false;
			this._canClose	= false;
			this._canNew	= true;
			this._canDelete = true;
			this._canLogicalDeleteDataExtraction = true;
			this._defaultAutoFillToColumn = true;
			this._canSpecificationSearch = false;

			// 企業コードを取得する
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// 変数初期化
			this._dataIndex = -1;
			this._stockProcMoneyAcs = new StockProcMoneyAcs();
			this._totalCount = 0;
			this._stockProcMoneyTable = new Hashtable();

			//_dataIndexバッファ（メインフレーム最小化対応）
			this._indexBuf = -2;
		}

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

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DCKON09100UA));
            this.FRACPROCMONEYDIV_TITLE_Label = new Infragistics.Win.Misc.UltraLabel();
            this.FRACTIONPROCCODE_TITLE_Label = new Infragistics.Win.Misc.UltraLabel();
            this.UPPERLIMITPRICE_TITLE_Label = new Infragistics.Win.Misc.UltraLabel();
            this.FRACTIONPROCUNIT_TITLE_Label = new Infragistics.Win.Misc.UltraLabel();
            this.FRACTIONPROCCD_TITLE_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Bind_DataSet = new System.Data.DataSet();
            this.fracProcMoneyDiv_tComboEditor1 = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.fractionProcCode_tNedit1 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.upperLimitPrice_tNedit2 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.fractionProcUnit_tNedit3 = new Broadleaf.Library.Windows.Forms.TNedit();
            this.fractionProcCd_tComboEditor2 = new Broadleaf.Library.Windows.Forms.TComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fracProcMoneyDiv_tComboEditor1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fractionProcCode_tNedit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitPrice_tNedit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fractionProcUnit_tNedit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fractionProcCd_tComboEditor2)).BeginInit();
            this.SuspendLayout();
            // 
            // FRACPROCMONEYDIV_TITLE_Label
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.FRACPROCMONEYDIV_TITLE_Label.Appearance = appearance1;
            this.FRACPROCMONEYDIV_TITLE_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.FRACPROCMONEYDIV_TITLE_Label.Location = new System.Drawing.Point(24, 35);
            this.FRACPROCMONEYDIV_TITLE_Label.Name = "FRACPROCMONEYDIV_TITLE_Label";
            this.FRACPROCMONEYDIV_TITLE_Label.Size = new System.Drawing.Size(164, 24);
            this.FRACPROCMONEYDIV_TITLE_Label.TabIndex = 0;
            this.FRACPROCMONEYDIV_TITLE_Label.Text = "端数処理対象金額区分";
            // 
            // FRACTIONPROCCODE_TITLE_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.FRACTIONPROCCODE_TITLE_Label.Appearance = appearance2;
            this.FRACTIONPROCCODE_TITLE_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.FRACTIONPROCCODE_TITLE_Label.Location = new System.Drawing.Point(24, 70);
            this.FRACTIONPROCCODE_TITLE_Label.Name = "FRACTIONPROCCODE_TITLE_Label";
            this.FRACTIONPROCCODE_TITLE_Label.Size = new System.Drawing.Size(164, 24);
            this.FRACTIONPROCCODE_TITLE_Label.TabIndex = 1;
            this.FRACTIONPROCCODE_TITLE_Label.Text = "端数処理コード";
            // 
            // UPPERLIMITPRICE_TITLE_Label
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.UPPERLIMITPRICE_TITLE_Label.Appearance = appearance3;
            this.UPPERLIMITPRICE_TITLE_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.UPPERLIMITPRICE_TITLE_Label.Location = new System.Drawing.Point(24, 105);
            this.UPPERLIMITPRICE_TITLE_Label.Name = "UPPERLIMITPRICE_TITLE_Label";
            this.UPPERLIMITPRICE_TITLE_Label.Size = new System.Drawing.Size(164, 24);
            this.UPPERLIMITPRICE_TITLE_Label.TabIndex = 2;
            this.UPPERLIMITPRICE_TITLE_Label.Text = "上限金額";
            // 
            // FRACTIONPROCUNIT_TITLE_Label
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.FRACTIONPROCUNIT_TITLE_Label.Appearance = appearance4;
            this.FRACTIONPROCUNIT_TITLE_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.FRACTIONPROCUNIT_TITLE_Label.Location = new System.Drawing.Point(24, 140);
            this.FRACTIONPROCUNIT_TITLE_Label.Name = "FRACTIONPROCUNIT_TITLE_Label";
            this.FRACTIONPROCUNIT_TITLE_Label.Size = new System.Drawing.Size(164, 24);
            this.FRACTIONPROCUNIT_TITLE_Label.TabIndex = 3;
            this.FRACTIONPROCUNIT_TITLE_Label.Text = "端数処理単位";
            // 
            // FRACTIONPROCCD_TITLE_Label
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.FRACTIONPROCCD_TITLE_Label.Appearance = appearance5;
            this.FRACTIONPROCCD_TITLE_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.FRACTIONPROCCD_TITLE_Label.Location = new System.Drawing.Point(24, 175);
            this.FRACTIONPROCCD_TITLE_Label.Name = "FRACTIONPROCCD_TITLE_Label";
            this.FRACTIONPROCCD_TITLE_Label.Size = new System.Drawing.Size(164, 24);
            this.FRACTIONPROCCD_TITLE_Label.TabIndex = 4;
            this.FRACTIONPROCCD_TITLE_Label.Text = "端数処理区分";
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(234, 227);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 5;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(364, 227);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 6;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(364, 227);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 7;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(494, 227);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 8;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Mode_Label
            // 
            appearance6.ForeColor = System.Drawing.Color.White;
            appearance6.TextHAlignAsString = "Center";
            appearance6.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance6;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(515, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 14;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            this.tArrowKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            this.tRetKeyControl1.ChangeFocus += new Broadleaf.Library.Windows.Forms.ChangeFocusEventHandler(this.tArrowKeyControl1_ChangeFocus);
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 268);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(632, 23);
            this.ultraStatusBar1.TabIndex = 15;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // fracProcMoneyDiv_tComboEditor1
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.fracProcMoneyDiv_tComboEditor1.ActiveAppearance = appearance15;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.fracProcMoneyDiv_tComboEditor1.Appearance = appearance16;
            this.fracProcMoneyDiv_tComboEditor1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.fracProcMoneyDiv_tComboEditor1.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.fracProcMoneyDiv_tComboEditor1.ItemAppearance = appearance17;
            this.fracProcMoneyDiv_tComboEditor1.Location = new System.Drawing.Point(215, 35);
            this.fracProcMoneyDiv_tComboEditor1.Name = "fracProcMoneyDiv_tComboEditor1";
            this.fracProcMoneyDiv_tComboEditor1.Size = new System.Drawing.Size(139, 24);
            this.fracProcMoneyDiv_tComboEditor1.TabIndex = 16;
            this.fracProcMoneyDiv_tComboEditor1.SelectionChangeCommitted += new System.EventHandler(this.fracProcMoneyDiv_tComboEditor1_SelectionChangeCommitted);
            // 
            // fractionProcCode_tNedit1
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance13.TextHAlignAsString = "Right";
            this.fractionProcCode_tNedit1.ActiveAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance14.TextHAlignAsString = "Right";
            this.fractionProcCode_tNedit1.Appearance = appearance14;
            this.fractionProcCode_tNedit1.AutoSelect = true;
            this.fractionProcCode_tNedit1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.fractionProcCode_tNedit1.CalcSize = new System.Drawing.Size(172, 200);
            this.fractionProcCode_tNedit1.DataText = "";
            this.fractionProcCode_tNedit1.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.fractionProcCode_tNedit1.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 8, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.fractionProcCode_tNedit1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.fractionProcCode_tNedit1.Location = new System.Drawing.Point(215, 70);
            this.fractionProcCode_tNedit1.MaxLength = 8;
            this.fractionProcCode_tNedit1.Name = "fractionProcCode_tNedit1";
            this.fractionProcCode_tNedit1.NullText = "0";
            this.fractionProcCode_tNedit1.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.fractionProcCode_tNedit1.Size = new System.Drawing.Size(136, 24);
            this.fractionProcCode_tNedit1.TabIndex = 17;
            // 
            // upperLimitPrice_tNedit2
            // 
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance11.TextHAlignAsString = "Right";
            this.upperLimitPrice_tNedit2.ActiveAppearance = appearance11;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance12.TextHAlignAsString = "Right";
            this.upperLimitPrice_tNedit2.Appearance = appearance12;
            this.upperLimitPrice_tNedit2.AutoSelect = true;
            this.upperLimitPrice_tNedit2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.upperLimitPrice_tNedit2.CalcSize = new System.Drawing.Size(172, 200);
            this.upperLimitPrice_tNedit2.DataText = "";
            this.upperLimitPrice_tNedit2.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.upperLimitPrice_tNedit2.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.upperLimitPrice_tNedit2.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.upperLimitPrice_tNedit2.Location = new System.Drawing.Point(215, 105);
            this.upperLimitPrice_tNedit2.MaxLength = 9;
            this.upperLimitPrice_tNedit2.Name = "upperLimitPrice_tNedit2";
            this.upperLimitPrice_tNedit2.NullText = "0";
            this.upperLimitPrice_tNedit2.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.upperLimitPrice_tNedit2.Size = new System.Drawing.Size(136, 24);
            this.upperLimitPrice_tNedit2.TabIndex = 18;
            // 
            // fractionProcUnit_tNedit3
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance9.TextHAlignAsString = "Right";
            this.fractionProcUnit_tNedit3.ActiveAppearance = appearance9;
            appearance10.TextHAlignAsString = "Right";
            this.fractionProcUnit_tNedit3.Appearance = appearance10;
            this.fractionProcUnit_tNedit3.AutoSelect = true;
            this.fractionProcUnit_tNedit3.CalcSize = new System.Drawing.Size(172, 200);
            this.fractionProcUnit_tNedit3.DataText = "";
            this.fractionProcUnit_tNedit3.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.fractionProcUnit_tNedit3.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.fractionProcUnit_tNedit3.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.fractionProcUnit_tNedit3.Location = new System.Drawing.Point(215, 140);
            this.fractionProcUnit_tNedit3.MaxLength = 9;
            this.fractionProcUnit_tNedit3.Name = "fractionProcUnit_tNedit3";
            this.fractionProcUnit_tNedit3.NullText = "0";
            this.fractionProcUnit_tNedit3.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, true, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.fractionProcUnit_tNedit3.Size = new System.Drawing.Size(136, 24);
            this.fractionProcUnit_tNedit3.TabIndex = 19;
            // 
            // fractionProcCd_tComboEditor2
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.fractionProcCd_tComboEditor2.ActiveAppearance = appearance7;
            this.fractionProcCd_tComboEditor2.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.fractionProcCd_tComboEditor2.ItemAppearance = appearance8;
            this.fractionProcCd_tComboEditor2.Location = new System.Drawing.Point(215, 175);
            this.fractionProcCd_tComboEditor2.Name = "fractionProcCd_tComboEditor2";
            this.fractionProcCd_tComboEditor2.Size = new System.Drawing.Size(139, 24);
            this.fractionProcCd_tComboEditor2.TabIndex = 20;
            // 
            // DCKON09100UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(632, 291);
            this.Controls.Add(this.fractionProcCd_tComboEditor2);
            this.Controls.Add(this.fractionProcUnit_tNedit3);
            this.Controls.Add(this.upperLimitPrice_tNedit2);
            this.Controls.Add(this.fractionProcCode_tNedit1);
            this.Controls.Add(this.fracProcMoneyDiv_tComboEditor1);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.FRACTIONPROCCD_TITLE_Label);
            this.Controls.Add(this.FRACTIONPROCUNIT_TITLE_Label);
            this.Controls.Add(this.UPPERLIMITPRICE_TITLE_Label);
            this.Controls.Add(this.FRACTIONPROCCODE_TITLE_Label);
            this.Controls.Add(this.FRACPROCMONEYDIV_TITLE_Label);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DCKON09100UA";
            this.Text = "仕入金額処理区分設定";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fracProcMoneyDiv_tComboEditor1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fractionProcCode_tNedit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.upperLimitPrice_tNedit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fractionProcUnit_tNedit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fractionProcCd_tComboEditor2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region Events

		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;

		#endregion

		#region Private Members

		private StockProcMoneyAcs _stockProcMoneyAcs;

		//比較用clone
		private StockProcMoney _stockProcMoneyClone;
		
		private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _stockProcMoneyTable;
		private int _fracProcMoneyDiv_tComboEditor1Value = -1;

		// プロパティ用
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
		private bool _canSpecificationSearch;

		//_dataIndexバッファ（メインフレーム最小化対応）
		private int _indexBuf;

		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";
		private const string DELETE_MODE = "削除モード";

		// FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
		private const string DELETE_DATE			= "削除日";
		private const string FRACPROCMONEYDIV_TITLE	= "端数処理対象金額区分";
		private const string FRACTIONPROCCODE_TITLE	= "端数処理コード";
		private const string UPPERLIMITPRICE_TITLE	= "上限金額";
		private const string FRACTIONPROCUNIT_TITLE	= "端数処理単位";
		private const string FRACTIONPROCCD_TITLE	= "端数処理区分";

		// テーブル名称
		private const string MAIN_TABLE = "STOCKPROCMONEY";		// 仕入金額処理区分設定

		// ガイドキー
		private const string GUID_TITLE = "GUID";

		// Message関連定義
        private const string ASSEMBLY_ID	= "DCKON09100U";
        private const string ERR_READ_MSG	= "読み込みに失敗しました。";

		//----- ueno upd ---------- start 2008.02.07		
		private const string ERR_DPR_MSG = "このコードは既に使用されています。\r\n端数処理コード、上限金額を確認して下さい。";
		//----- ueno upd ---------- end 2008.02.07		
		
		private const string ERR_RDEL_MSG = "削除に失敗しました。";
        private const string ERR_UPDT_MSG	= "登録に失敗しました。";
        private const string ERR_RVV_MSG	= "復活に失敗しました。";
        private const string ERR_800_MSG	= "既に他端末より更新されています";
        private const string ERR_801_MSG	= "既に他端末より削除されています";
        private const string SDC_RDEL_MSG	= "マスタから削除されています";
		private const string CONF_DEL_MSG	= "データを削除します。" + "\r\n" + "よろしいですか？";

		// 小数入力用定義
		private const int MAXLENGTH_DECIMAL		= 11;		// 実桁数
		private const string NULLTEXT_DECIMAL	= "0.00";	// 初期表示
		private const int NUMEDIT_DECIMAL		= 2;		// 小数点以下表示桁数
		private const int EXTEDITCOLUMN_DECIMAL = 14;		// 表示桁数(カンマ、ピリオド含む)
		
		// 整数入力定義
		private const int MAXLENGTH_INT		= 9;	// 実桁数
		private const string NULLTEXT_INT	= "0";	// 初期表示
		private const int NUMEDIT_INT		= 0;	// 小数点以下表示桁数
		private const int EXTEDITCOLUMN_INT = 11;	// 表示桁数(カンマ、ピリオド含む)

		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new DCKON09100UA());
		}

		/// <summary>印刷可能設定プロパティ</summary>
		/// <value>印刷可能かどうかの設定を取得します。</value>
		public bool CanPrint
		{
			get{ return this._canPrint; }
		}

		/// <summary>論理削除データ抽出可能設定プロパティ</summary>
		/// <value>論理削除データの抽出が可能かどうかの設定を取得します。</value>
		public bool CanLogicalDeleteDataExtraction
		{
			get{ return this._canLogicalDeleteDataExtraction; }
		}

		/// <summary>画面終了設定プロパティ</summary>
		/// <value>画面クローズを許可するかどうかの設定を取得または設定します。</value>
		/// <remarks>falseの場合は、画面を閉じる際、CloseではなくHide(非表示)を実行します。</remarks>
		public bool CanClose
		{
			get{ return this._canClose; }
			set{ this._canClose = value; }
		}

		/// <summary>新規登録可能設定プロパティ</summary>
		/// <value>新規登録が可能かどうかの設定を取得します。</value>
		public bool CanNew
		{
			get{ return this._canNew; }
		}

		/// <summary>削除可能設定プロパティ</summary>
		/// <value>削除が可能かどうかの設定を取得します。</value>
		public bool CanDelete
		{
			get{ return this._canDelete; }
		}

		/// <summary>データセットの選択データインデックスプロパティ</summary>
		/// <value>データセットの選択データインデックスを取得または設定します。</value>
		public int DataIndex
		{
			get{ return this._dataIndex; }
			set{ this._dataIndex = value; }
		}

		/// <summary>列のサイズの自動調整のデフォルト値プロパティ</summary>
		/// <value>列のサイズの自動調整チェックボックスのチェック有無のデフォルト値を取得します。</value>
		public bool DefaultAutoFillToColumn
		{
			get{ return this._defaultAutoFillToColumn; }
		}

		/// <summary>件数指定抽出可能設定プロパティ</summary>
		/// <value>件数指定抽出を可能とするかどうかの設定を取得または設定します。</value>
		public bool CanSpecificationSearch
		{					 
			get{ return this._canSpecificationSearch; }
		}

		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet">グリッドリッド用データセット</param>
		/// <param name="tableName">テーブル名称</param>
		/// <remarks>
		/// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = MAIN_TABLE;
		}

		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数(未使用)</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList stockProcMoneyList = null;

			// グリッドをクリア
			this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Clear();
			
			// 抽出対象件数が0の場合は全件抽出を実行する
			status = this._stockProcMoneyAcs.SearchAll(out stockProcMoneyList, this._enterpriseCode);

			this._totalCount = stockProcMoneyList.Count;

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					int index = 0;
					foreach(StockProcMoney stockProcMoney in stockProcMoneyList)
					{
						StockProcMoneyToDataSet(stockProcMoney.Clone(), index);
						++index;
					}
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					// データなしの場合はグリッドをクリア
					this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Clear();
					this._stockProcMoneyTable.Clear();
					break;
				}
				default:
				{
					TMsgDisp.Show(this,						// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,		// エラーレベル
						ASSEMBLY_ID,						// アセンブリID
						this.Text,							// プログラム名称
						"Search",							// 処理名称
						TMsgDisp.OPE_GET,					// オペレーション
						ERR_READ_MSG,						// 表示するメッセージ
						status,								// ステータス値
						this._stockProcMoneyAcs,			// エラーが発生したオブジェクト
						MessageBoxButtons.OK,				// 表示するボタン
						MessageBoxDefaultButton.Button1);	// 初期表示ボタン
					
					this.Hide();
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
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			// 未実装
			return 0;
		}

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 選択中のデータを削除します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int Delete()
		{
			int status = 0;
			
			//仕入金額処理区分設定論理削除
			status = LogicalDeleteStockProcMoney();
			
			return status;
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を実行します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int Print()
		{
			// 未実装
			return 0;
		}

		/// <summary>
		/// グリッド列外観情報取得処理
		/// </summary>
		/// <returns>グリッド列外観情報格納Hashtable</returns>
		/// <remarks>
		/// <br>Note       : 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth,ContentAlignment.MiddleLeft,"",Color.Red));
			appearanceTable.Add(FRACPROCMONEYDIV_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(FRACTIONPROCCODE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "", Color.Black));
			appearanceTable.Add(UPPERLIMITPRICE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "###,#0.00", Color.Black));
			appearanceTable.Add(FRACTIONPROCUNIT_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleRight, "###,#0.00", Color.Black));
			appearanceTable.Add(FRACTIONPROCCD_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));
			appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleLeft,"",Color.Black));

			return appearanceTable;
		}

		/// <summary>
		/// 仕入金額処理区分設定オブジェクトデータセット展開処理
		/// </summary>
		/// <param name="stockProcMoney">仕入金額処理区分設定オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定クラスをデータセットに格納します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void StockProcMoneyToDataSet(StockProcMoney stockProcMoney, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[MAIN_TABLE].NewRow();
				this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Add(dataRow);

				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count - 1;
			}

			// 論理削除区分
			if (stockProcMoney.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][DELETE_DATE] = "";
			}
			else
			{
				this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][DELETE_DATE] = stockProcMoney.UpdateDateTimeJpInFormal;
			}

			// 端数処理対象金額区分(該当文字列を表示)
			this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][FRACPROCMONEYDIV_TITLE] = StockProcMoney.GetFracProcMoneyDivNm(stockProcMoney.FracProcMoneyDiv);
			
			// 端数処理コード
			this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][FRACTIONPROCCODE_TITLE] = stockProcMoney.FractionProcCode;

			// 上限金額
			this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][UPPERLIMITPRICE_TITLE] = stockProcMoney.UpperLimitPrice;

			// 端数処理単位
			this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][FRACTIONPROCUNIT_TITLE] = stockProcMoney.FractionProcUnit;

			// 端数処理区分(該当文字列を表示)
			this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][FRACTIONPROCCD_TITLE] = StockProcMoney.GetFractionProcCdNm(stockProcMoney.FractionProcCd);
			
			// GUID
			this.Bind_DataSet.Tables[MAIN_TABLE].Rows[index][GUID_TITLE] = stockProcMoney.FileHeaderGuid;

            // ハッシュテーブル更新
			if (this._stockProcMoneyTable.ContainsKey(stockProcMoney.FileHeaderGuid) == true)
			{
				this._stockProcMoneyTable.Remove(stockProcMoney.FileHeaderGuid);
			}
			this._stockProcMoneyTable.Add(stockProcMoney.FileHeaderGuid, stockProcMoney);
		}

		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable stockProcMoneyTable = new DataTable(MAIN_TABLE);

			// Addを行う順番が、列の表示順位となります。
			stockProcMoneyTable.Columns.Add(DELETE_DATE, typeof(string));
			stockProcMoneyTable.Columns.Add(FRACPROCMONEYDIV_TITLE, typeof(string));
			stockProcMoneyTable.Columns.Add(FRACTIONPROCCODE_TITLE, typeof(string));
			stockProcMoneyTable.Columns.Add(UPPERLIMITPRICE_TITLE, typeof(double));
			stockProcMoneyTable.Columns.Add(FRACTIONPROCUNIT_TITLE, typeof(double));
			stockProcMoneyTable.Columns.Add(FRACTIONPROCCD_TITLE, typeof(string));
			stockProcMoneyTable.Columns.Add(GUID_TITLE, typeof(Guid));

			this.Bind_DataSet.Tables.Add(stockProcMoneyTable);
		}

		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			// 端数処理対象金額区分取得
			ArrayList wkListCd1 = StockProcMoney.GetFracProcMoneyDivCdList();
			ArrayList wkListNm1 = StockProcMoney.GetFracProcMoneyDivNmList();

			this.fracProcMoneyDiv_tComboEditor1.Items.Clear();			// 既存アイテムクリア

			for(int ix = 0; ix != wkListCd1.Count; ix++)
			{
				Int32 code = (Int32)wkListCd1[ix];
				this.fracProcMoneyDiv_tComboEditor1.Items.Add(code, wkListNm1[ix].ToString());
			}

			this.fracProcMoneyDiv_tComboEditor1.Value = 0;				// 「仕入金額」に設定

			// 端数処理区分取得
			ArrayList wkListCd2 = StockProcMoney.GetFractionProcCdCdList();
			ArrayList wkListNm2 = StockProcMoney.GetFractionProcCdNmList();

			this.fractionProcCd_tComboEditor2.Items.Clear();			// 既存アイテムクリア

			for (int ix = 0; ix != wkListCd2.Count; ix++)
			{
				Int32 code = (Int32)wkListCd2[ix];
				this.fractionProcCd_tComboEditor2.Items.Add(code, wkListNm2[ix].ToString());
			}

			this.fractionProcCd_tComboEditor2.Value = 1;				// 「切捨て」に設定

			_fracProcMoneyDiv_tComboEditor1Value = -1;

			// 金額表示変更チェック
			MoneyVisibleChange(0);

			// 新規の場合
			if (this._dataIndex < 0)
			{
				ScreenInputPermissionControl(0);                        // 画面入力許可制御
			}
			// 削除の場合
			else if ((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._dataIndex][DELETE_DATE] != "")
			{
				ScreenInputPermissionControl(2);                        // 画面入力許可制御
			}
			// 更新の場合
			else
			{
				ScreenInputPermissionControl(1);                        // 画面入力許可制御
			}
		}

		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面をクリアします。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void ScreenClear()
		{
			// モードラベル
			this.Mode_Label.Text = INSERT_MODE;

			// ボタン
			this.Delete_Button.Visible	= true;	// 完全削除ボタン
			this.Revive_Button.Visible	= true;	// 復活ボタン
			this.Ok_Button.Visible		= true;	// 保存ボタン
			this.Cancel_Button.Visible	= true;	// 閉じるボタン

			// 入力制御
			this.fracProcMoneyDiv_tComboEditor1.Enabled = true;	// 端数処理対象金額区分
			this.fractionProcCode_tNedit1.Enabled		= true;	// 端数処理コード
			this.upperLimitPrice_tNedit2.Enabled		= true;	// 上限金額
			this.fractionProcUnit_tNedit3.Enabled		= true;	// 端数処理単位
			this.fractionProcCd_tComboEditor2.Enabled	= true;	// 端数処理区分

			// 項目
			this.fracProcMoneyDiv_tComboEditor1.Value = 0;	// 端数処理対象金額区分(「仕入金額」)
			this.fractionProcCode_tNedit1.SetInt(0);		// 端数処理コード
			this.upperLimitPrice_tNedit2.SetInt(0);			// 上限金額
			this.fractionProcUnit_tNedit3.SetInt(0);		// 端数処理単位
			this.fractionProcCd_tComboEditor2.Value = 1;	// 端数処理区分(「切捨て」)
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			// 新規の場合
			if (this._dataIndex < 0)
			{
				StockProcMoney stockProcMoney = new StockProcMoney();

				// 新規モード
				this.Mode_Label.Text = INSERT_MODE;

				//クローン作成
				this._stockProcMoneyClone = stockProcMoney.Clone();

				//画面情報を比較用クローンにコピーする　　　　　   
				DispToStockProcMoney(ref this._stockProcMoneyClone);

				// フォーカス設定(端数処理対象金額区分)
				this.fracProcMoneyDiv_tComboEditor1.Focus();
			}
			else
			{
				// 表示情報取得
				Guid guid = (Guid)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._dataIndex][GUID_TITLE];
				StockProcMoney stockProcMoney = (StockProcMoney)this._stockProcMoneyTable[guid];

				// 金額表示変更チェック
				MoneyVisibleChange(stockProcMoney.FracProcMoneyDiv);

				// 画面展開処理
				StockProcMoneyToScreen(stockProcMoney);

				if (stockProcMoney.LogicalDeleteCode == 0)
				{
					// 更新モード
					this.Mode_Label.Text = UPDATE_MODE;

					//クローン作成
					this._stockProcMoneyClone = stockProcMoney.Clone();
					
					//画面情報を比較用クローンにコピーする　　　　　   
					DispToStockProcMoney(ref this._stockProcMoneyClone);

					this.fracProcMoneyDiv_tComboEditor1.Enabled = false;	// 入力不可(端数処理対象金額区分)
					this.fractionProcCode_tNedit1.Enabled		= false;	// 入力不可(端数処理コード)
					this.upperLimitPrice_tNedit2.Enabled		= false;	// 入力不可(上限金額)

					// フォーカス設定(端数処理単位)
					this.fractionProcUnit_tNedit3.Focus();
				}
				else
				{
					// 削除モード
					this.Mode_Label.Text = DELETE_MODE;
					
					this.fracProcMoneyDiv_tComboEditor1.Enabled = false;	// 入力不可(端数処理対象金額区分)
					this.fractionProcCode_tNedit1.Enabled		= false;	// 入力不可(端数処理コード)
					this.upperLimitPrice_tNedit2.Enabled		= false;	// 入力不可(上限金額)
					this.fractionProcUnit_tNedit3.Enabled		= false;	// 入力不可(端数処理単位)
					this.fractionProcCd_tComboEditor2.Enabled	= false;	// 入力不可(端数処理区分)
					
					// フォーカス(削除ボタン)
					this.Delete_Button.Focus();
				}
			}

			//_dataIndexバッファ保持
			this._indexBuf = this._dataIndex;
		}

		/// <summary>
		/// 画面入力許可制御処理
		/// </summary>
		/// <param name="enabled">入力許可設定値</param>
		/// <remarks>
		/// <br>Note       : 画面の入力許可を制御します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void ScreenInputPermissionControl(int setType)
		{
			switch (setType)
			{
				// 0:新規
				// 1:更新
				case 0:
				case 1:
					{
						// ボタン
						this.Delete_Button.Visible	= false;
						this.Revive_Button.Visible	= false;
						this.Ok_Button.Visible		= true;
						this.Cancel_Button.Visible	= true;

						break;
					}
				// 2:削除
				case 2:
					{
						// ボタン
						this.Delete_Button.Visible	= true;
						this.Revive_Button.Visible	= true;
						this.Ok_Button.Visible		= false;
						this.Cancel_Button.Visible	= true;

						break;
					}
			}
		}

		/// <summary>
		/// 仕入金額処理区分設定クラス画面展開処理
		/// </summary>
		/// <param name="stockProcMoney">仕入金額処理区分設定オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定オブジェクトから画面にデータを展開します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void StockProcMoneyToScreen(StockProcMoney stockProcMoney)
		{
			this.fracProcMoneyDiv_tComboEditor1.Value = stockProcMoney.FracProcMoneyDiv;		// 端数処理対象金額区分
			this.fractionProcCode_tNedit1.SetInt(stockProcMoney.FractionProcCode);				// 端数処理コード
			this.upperLimitPrice_tNedit2.SetValue(stockProcMoney.UpperLimitPrice);				// 上限金額
			this.fractionProcUnit_tNedit3.SetValue(stockProcMoney.FractionProcUnit);			// 端数処理単位
			this.fractionProcCd_tComboEditor2.Value = stockProcMoney.FractionProcCd;			// 端数処理区分
		}

		/// <summary>
		/// 画面情報仕入金額処理区分設定クラス格納処理
		/// </summary>
		/// <param name="stockProcMoney">仕入金額処理区分設定オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 画面情報から仕入金額処理区分設定オブジェクトにデータを格納します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void DispToStockProcMoney(ref StockProcMoney stockProcMoney)
		{
			if (stockProcMoney == null)
			{
				// 新規の場合
				stockProcMoney = new StockProcMoney();
			}

			stockProcMoney.EnterpriseCode	= this._enterpriseCode;									// 企業コード
			stockProcMoney.FracProcMoneyDiv = (Int32)this.fracProcMoneyDiv_tComboEditor1.Value;		// 端数処理対象金額区分
			stockProcMoney.FractionProcCode = this.fractionProcCode_tNedit1.GetInt();				// 端数処理コード
			stockProcMoney.UpperLimitPrice	= this.upperLimitPrice_tNedit2.GetValue();				// 上限金額
			stockProcMoney.FractionProcUnit = this.fractionProcUnit_tNedit3.GetValue();				// 端数処理単位
			stockProcMoney.FractionProcCd	= (Int32)this.fractionProcCd_tComboEditor2.Value;		// 端数処理区分
		}

		/// <summary>
		/// 画面入力情報不正チェック処理
		/// </summary>
		/// <param name="control">不正対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の不正チェックを行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private bool ScreenDataCheck(ref Control control, ref string message)
		{
			bool result = true;

			// 端数処理コード(必須入力チェック)
			if (this.fractionProcCode_tNedit1.Text == "")
			{
				control = this.fractionProcCode_tNedit1;
				message = this.FRACTIONPROCCODE_TITLE_Label.Text + "を入力して下さい。";
				result = false;
			}
			// 上限金額(必須入力チェック)
			else if (this.upperLimitPrice_tNedit2.GetValue() == 0)
			{
				control = this.upperLimitPrice_tNedit2;
				message = this.UPPERLIMITPRICE_TITLE_Label.Text + "を入力して下さい。";
				result = false;
			}
			// 端数処理単位(必須入力チェック)
			else if (this.fractionProcUnit_tNedit3.GetValue() == 0)
			{
				control = this.fractionProcUnit_tNedit3;
				message = this.FRACTIONPROCUNIT_TITLE_Label.Text + "を入力して下さい。";
				result = false;
			}
			return result;
		}

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <returns>登録結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定への保存を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private bool SaveProc()
		{
			Control control = null;
			string message = null;

			// 不正データ入力チェック
			if (!ScreenDataCheck(ref control, ref message))
			{
				TMsgDisp.Show(this,                         // 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
					ASSEMBLY_ID,							// アセンブリID
					message,	                            // 表示するメッセージ
					0,   									// ステータス値
					MessageBoxButtons.OK);					// 表示するボタン

				control.Focus();
				return false;
			}

			// 仕入金額処理区分設定更新
			if (!SaveStockProcMoney())
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// 仕入金額処理区分設定更新
		/// </summary>
		/// <return>更新結果status</return>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定の更新を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
        private bool SaveStockProcMoney()
		{
			int status = 0;
			StockProcMoney stockProcMoney = new StockProcMoney();
			
			// 登録レコード情報取得
			if (this._dataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._dataIndex][GUID_TITLE];
				stockProcMoney = ((StockProcMoney)this._stockProcMoneyTable[guid]).Clone();
			}

			DispToStockProcMoney(ref stockProcMoney);

			// 書き込み
			status = this._stockProcMoneyAcs.Write(ref stockProcMoney);

			// エラー処理
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// DataSet更新処理
						StockProcMoneyToDataSet(stockProcMoney, this._indexBuf);
						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
					{
						//重複
						TMsgDisp.Show(this,					// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_INFO,	// エラーレベル
							ASSEMBLY_ID,					// アセンブリID
							ERR_DPR_MSG,					// 表示するメッセージ
							status,							// ステータス値
							MessageBoxButtons.OK);			// 表示するボタン

						// 端数処理コードへフォーカスセット
						this.fractionProcCode_tNedit1.Focus();
						
						return false;
					}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						// 排他処理
						ExclusiveTransaction(status);

						// UI子画面強制終了処理
						EnforcedEndTransaction();

						return false;
					}
				default:
					{
						// 登録失敗
						TMsgDisp.Show(this,						// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_STOPDISP,	// エラーレベル
							ASSEMBLY_ID,						// アセンブリID
							this.Text,							// プログラム名称
							"SaveProc",							// 処理名称
							TMsgDisp.OPE_UPDATE,				// オペレーション
							ERR_UPDT_MSG,						// 表示するメッセージ
							status,								// ステータス値
							this._stockProcMoneyAcs,			// エラーが発生したオブジェクト
							MessageBoxButtons.OK,				// 表示するボタン
							MessageBoxDefaultButton.Button1);	// 初期表示ボタン

						// UI子画面強制終了処理
						EnforcedEndTransaction();

						return false;
					}
			}
			// 新規登録時処理
			NewEntryTransaction();

			return true;
		}

        /// <summary>
        /// 仕入金額処理区分設定 論理削除処理
        /// </summary>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 仕入金額処理区分設定対象レコードをマスタから論理削除します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
        /// </remarks>
        private int LogicalDeleteStockProcMoney()
        {
			int status = 0;
			int dummy = 0;
			
			// 削除対象仕入金額区分設定取得
			Guid guid = (Guid)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._dataIndex][GUID_TITLE];
			StockProcMoney stockProcMoney = ((StockProcMoney)this._stockProcMoneyTable[guid]).Clone();

			// 論理削除
			status = this._stockProcMoneyAcs.LogicalDelete(ref stockProcMoney);

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
						ExclusiveTransaction(status);
						break;
					}
				default:
					{
						TMsgDisp.Show(this,						// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_STOP,		// エラーレベル
							ASSEMBLY_ID,						// アセンブリID
							this.Text,							// プログラム名称
							"Delete",							// 処理名称
							TMsgDisp.OPE_HIDE,					// オペレーション
							ERR_RDEL_MSG,					    // 表示するメッセージ
							status,								// ステータス値
							this._stockProcMoneyAcs,			// エラーが発生したオブジェクト
							MessageBoxButtons.OK,				// 表示するボタン
							MessageBoxDefaultButton.Button1);	// 初期表示ボタン

						break;
					}
			}
			// フレーム更新
			Search(ref dummy, 0);

			return status;
		}

		/// <summary>
		/// 仕入金額処理区分設定 物理削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定対象レコードをマスタから物理削除します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
        private int PhysicalDeleteStockProcMoney()
		{
			int status = 0;
			int dummy = 0;

			// 削除対象仕入金額処理区分設定取得
			Guid guid = (Guid)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._dataIndex][GUID_TITLE];
			StockProcMoney stockProcMoney = ((StockProcMoney)this._stockProcMoneyTable[guid]).Clone();

			// 物理削除
			status = this._stockProcMoneyAcs.Delete(stockProcMoney);
			
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// DataSet更新の為
						Search(ref dummy, 0);
						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						// 排他処理
						ExclusiveTransaction(status);

						// UI子画面強制終了処理
						EnforcedEndTransaction();

						return status;
					}
				default:
					{
						TMsgDisp.Show(this,						// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_STOP,		// エラーレベル
							ASSEMBLY_ID,						// アセンブリID
							this.Text,							// プログラム名称
							"Delete_Button_Click",				// 処理名称
							TMsgDisp.OPE_DELETE,				// オペレーション
							ERR_RDEL_MSG,						// 表示するメッセージ
							status,								// ステータス値
							this._stockProcMoneyAcs,			// エラーが発生したオブジェクト
							MessageBoxButtons.OK,				// 表示するボタン
							MessageBoxDefaultButton.Button1);	// 初期表示ボタン

						// UI子画面強制終了処理
						EnforcedEndTransaction();

						return status;
					}
			}
			return status;
		}

		/// <summary>
		/// 仕入金額処理区分設定 復活処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 仕入金額処理区分設定対象レコードを復活します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.23</br>
		/// </remarks>
		private int ReviveStockProcMoney()
		{
			int status = 0;

			// 復活対象仕入金額処理区分設定取得
			Guid guid = (Guid)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[this._dataIndex][GUID_TITLE];
			StockProcMoney stockProcMoney = ((StockProcMoney)this._stockProcMoneyTable[guid]).Clone();

			// 復活
			status = this._stockProcMoneyAcs.Revival(ref stockProcMoney);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						// DataSet展開処理
						StockProcMoneyToDataSet(stockProcMoney, this._dataIndex);
						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						// 排他処理
						ExclusiveTransaction(status);
						return status;
					}
				default:
					{
						TMsgDisp.Show(
							this,								// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_STOPDISP,    // エラーレベル
							ASSEMBLY_ID,						// アセンブリＩＤまたはクラスＩＤ
							this.Text,							// プログラム名称
							"ReviveStockProcMoney",			    // 処理名称
							TMsgDisp.OPE_UPDATE,				// オペレーション
							ERR_RVV_MSG,						// 表示するメッセージ 
							status,								// ステータス値
							this._stockProcMoneyAcs,			// エラーが発生したオブジェクト
							MessageBoxButtons.OK,				// 表示するボタン
							MessageBoxDefaultButton.Button1);	// 初期表示ボタン
						return status;
					}
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			//_dataIndexバッファ保持
			this._indexBuf = -2;

			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
			return status;
		}

        /// <summary>
        /// 新規登録時処理
        /// </summary>
        /// <param name="status">ステータス</param>
        /// <remarks>
        /// <br>Note       : 新規登録時の処理を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
        /// </remarks>
        private void NewEntryTransaction()
		{
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			// 新規モードの場合は画面を終了せずに連続入力を可能とする
			if (this.Mode_Label.Text == INSERT_MODE)
			{
				this._dataIndex = -1;

				// フレーム更新
				int dummy = 0;
				Search(ref dummy, 0);

				// 画面クリア処理
				ScreenClear();

				// 画面初期設定処理
				ScreenInitialSetting();

				Initial_Timer.Enabled = true;
			}
			else
			{
				this.DialogResult = DialogResult.OK;

				if (CanClose == true)
				{
					this.Close();
				}
				else
				{
					this.Hide();
				}

				//_dataIndexバッファ保持
				this._indexBuf = -2;
			}
		}

		/// <summary>
		/// UI子画面強制終了処理
		/// </summary>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : データ更新エラー時のUI子画面強制終了処理を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void EnforcedEndTransaction()
		{
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;

			//_dataIndexバッファ保持
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
		/// 排他処理
		/// </summary>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : データ更新時の排他処理を行います。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
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
		/// Form.Load イベント(DCKON09100UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList24 = IconResourceManagement.ImageList24;

			this.Ok_Button.ImageList     = imageList24;
			this.Cancel_Button.ImageList = imageList24;
			this.Revive_Button.ImageList = imageList24;
			this.Delete_Button.ImageList = imageList24;

			this.Ok_Button.Appearance.Image     = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
		}

		/// <summary>
		/// Form.Closing イベント(DCKON09100UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note　　　  : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//_dataIndexバッファ保持
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
		/// Control.VisibleChanged イベント(DCKON09100UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void Form1_VisibleChanged(object sender, System.EventArgs e)
		{
			// メインフレームアクティブ化
			this.Owner.Activate();

			// 自分自身が非表示になった場合は以下の処理をキャンセルする。
			if (this.Visible == false)
			{
				return;
			}

			// 画面クリア処理
			ScreenClear();

			// 画面初期設定処理
			ScreenInitialSetting();

			Initial_Timer.Enabled = true;
		}

		/// <summary>
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			// 登録処理
			SaveProc();
		}

		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// 削除モード以外の場合は保存確認処理を行う
			if (this.Mode_Label.Text != DELETE_MODE)
			{
				//保存確認
				StockProcMoney compareStockProcMoney = new StockProcMoney();
				compareStockProcMoney = this._stockProcMoneyClone.Clone();  
				
				//現在の画面情報を取得する
				DispToStockProcMoney(ref compareStockProcMoney);
				
				//最初に取得した画面情報と比較
				if (!(this._stockProcMoneyClone.Equals(compareStockProcMoney)))	
				{
					//画面情報が変更されていた場合は、保存確認メッセージを表示する
					DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
						ASSEMBLY_ID, 			                              // アセンブリＩＤまたはクラスＩＤ
						null, 					                              // 表示するメッセージ
						0, 					                                  // ステータス値
						MessageBoxButtons.YesNoCancel);	                      // 表示するボタン

					switch(res)
					{
						case DialogResult.Yes:
						{
							if(!SaveProc()) 
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
							this.Cancel_Button.Focus();
							return;
						}
					}
				}
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;

			//_dataIndexバッファ保持
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
		/// <br>Note　　　  : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			DialogResult result = TMsgDisp.Show(this,	// 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_EXCLAMATION,		// エラーレベル
				ASSEMBLY_ID,							// アセンブリＩＤまたはクラスＩＤ
				CONF_DEL_MSG,							// 表示するメッセージ
				0,										// ステータス値
				MessageBoxButtons.OKCancel,				// 表示するボタン
				MessageBoxDefaultButton.Button2);		// 初期表示ボタン

			if (result == DialogResult.OK)
			{
				// 仕入金額処理区分設定物理削除
				PhysicalDeleteStockProcMoney();
			}
			else
			{
				return;
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			//_dataIndexバッファ保持
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
		/// <br>Note　　　  : 復活ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
			// 仕入金額処理区分復活
			ReviveStockProcMoney();
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
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}

		/// <summary>
		/// fracProcMoneyDiv_tComboEditor1_SelectionChangeCommitted イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 端数処理対象金額区分が変化したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.31</br>
		/// </remarks>
		private void fracProcMoneyDiv_tComboEditor1_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (fracProcMoneyDiv_tComboEditor1.Value != null)
			{
				MoneyVisibleChange((Int32)fracProcMoneyDiv_tComboEditor1.Value);
			}
		}

		/// <summary>
		/// 金額表示変更
		/// </summary>
		/// <param name="fracProvMoneyDiv">端数処理対象金額区分</param>
		/// <remarks>
		/// <br>Note　     : 端数処理対象金額区分の選択を変更したときに発生します。</br>
		/// <br>Programmer : 30167 上野 弘貴</br>
		/// <br>Date       : 2007.08.31</br>
		/// </remarks>
		private void MoneyVisibleChange(int fracProcMoneyDiv)
		{
			if (_fracProcMoneyDiv_tComboEditor1Value == fracProcMoneyDiv) return;

			if (fracProcMoneyDiv == 2)
			{
				// 上限金額小数点設定
				this.upperLimitPrice_tNedit2.MaxLength = MAXLENGTH_DECIMAL;
				this.upperLimitPrice_tNedit2.NullText = NULLTEXT_DECIMAL;
				this.upperLimitPrice_tNedit2.NumEdit.DecLen = NUMEDIT_DECIMAL;
				this.upperLimitPrice_tNedit2.ExtEdit.Column = EXTEDITCOLUMN_DECIMAL;

				// 端数処理単位小数点設定
				this.fractionProcUnit_tNedit3.MaxLength = MAXLENGTH_DECIMAL;
				this.fractionProcUnit_tNedit3.NullText = NULLTEXT_DECIMAL;
				this.fractionProcUnit_tNedit3.NumEdit.DecLen = NUMEDIT_DECIMAL;
				this.fractionProcUnit_tNedit3.ExtEdit.Column = EXTEDITCOLUMN_DECIMAL;
			}
			else
			{
				// 上限金額整数設定
				this.upperLimitPrice_tNedit2.MaxLength = MAXLENGTH_INT;
				this.upperLimitPrice_tNedit2.NullText = NULLTEXT_INT;
				this.upperLimitPrice_tNedit2.NumEdit.DecLen = NUMEDIT_INT;
				this.upperLimitPrice_tNedit2.ExtEdit.Column = EXTEDITCOLUMN_INT;

				// 端数処理単位整数設定
				this.fractionProcUnit_tNedit3.MaxLength = MAXLENGTH_INT;
				this.fractionProcUnit_tNedit3.NullText = NULLTEXT_INT;
				this.fractionProcUnit_tNedit3.NumEdit.DecLen = NUMEDIT_INT;
				this.fractionProcUnit_tNedit3.ExtEdit.Column = EXTEDITCOLUMN_INT;
			}

			// 上限金額クリア
			this.upperLimitPrice_tNedit2.SetInt(0);

			// 端数処理単位クリア
			this.fractionProcUnit_tNedit3.SetInt(0);

			//----- ueno add ---------- start 2008.02.07		
			// 消費税の場合は上限金額固定
			if (fracProcMoneyDiv == 1)
			{
				this.upperLimitPrice_tNedit2.SetInt(999999999);
				this.upperLimitPrice_tNedit2.Enabled = false;
			}
			else
			{
				this.upperLimitPrice_tNedit2.Enabled = true;
			}
			//----- ueno add ---------- end 2008.02.07

            // 選択した番号を保持
            _fracProcMoneyDiv_tComboEditor1Value = fracProcMoneyDiv;
        }

		/// <summary>
		/// tArrowKeyControl1_ChangeFocusイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

            if (e.PrevCtrl.Name == "fracProcMoneyDiv_tComboEditor1")
            {
                MoneyVisibleChange((Int32)fracProcMoneyDiv_tComboEditor1.Value);
            }

            // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            switch (e.NextCtrl.Name)
            {
                case "fractionProcUnit_tNedit3":        // 端数処理単位
                case "fractionProcCd_tComboEditor2":    // 端数処理区分
                    {
                        if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                MoneyVisibleChange((Int32)fracProcMoneyDiv_tComboEditor1.Value);
                                e.NextCtrl = fracProcMoneyDiv_tComboEditor1;
                            }
                        }
                        break;
                    }
            }
            // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END
		}

        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // 端数処理対象金額区分
            string fracProcMoneyDiv = fracProcMoneyDiv_tComboEditor1.SelectedItem.DisplayText;
            // 端数処理コード
            string fractionProcCode = fractionProcCode_tNedit1.GetInt().ToString();
            // 上限金額
            double upperLimitPrice = upperLimitPrice_tNedit2.GetValue();

            for (int i = 0; i < this.Bind_DataSet.Tables[MAIN_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                string dsFracProcMoneyDiv = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[i][FRACPROCMONEYDIV_TITLE];
                string dsFractionProcCode = (string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[i][FRACTIONPROCCODE_TITLE];
                double dsUpperLimitPrice = (double)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[i][UPPERLIMITPRICE_TITLE];
                if ((fracProcMoneyDiv == dsFracProcMoneyDiv) &&
                    (fractionProcCode == dsFractionProcCode) &&
                    (upperLimitPrice == dsUpperLimitPrice))
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[MAIN_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          ASSEMBLY_ID,						    // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードの仕入金額処理区分設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // 端数処理対象金額区分、端数処理コード、上限金額のクリア
                        fracProcMoneyDiv_tComboEditor1.Value = 0;
                        fractionProcCode_tNedit1.SetInt(0);
                        upperLimitPrice_tNedit2.SetInt(0);
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        ASSEMBLY_ID,                            // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードの仕入金額処理区分設定情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenInitialSetting();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // 端数処理対象金額区分、端数処理コード、上限金額のクリア
                                fracProcMoneyDiv_tComboEditor1.Value = 0;
                                fractionProcCode_tNedit1.SetInt(0);
                                upperLimitPrice_tNedit2.SetInt(0);
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.25 30413 犬飼 新規モードからモード変更対応 <<<<<<END
	}
}
