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
using Broadleaf.Library.Text;
using Infragistics.Win.Misc;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 帳票出力設定フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 帳票出力設定を行います。
	///					 IMasterMaintenanceMultiTypeを実装しています。</br>
	/// <br>Programmer : 23010 中村　仁</br>
	/// <br>Date       : 2005.08.12</br>
	/// <br>Update Note: 2005.09.02 22021 谷藤</br> 
	/// <br>             保存確認後のエンターキー押下時のフォーカス対応</br>
	/// <br>Update Note: 2005.09.08 22021 谷藤　範幸</br>
	/// <br>			 ・ログイン情報取得部品の組込み</br>
	/// <br>Update Note: 2005.09.22 22021 谷藤　範幸</br>
	/// <br>			 ・メッセージ表示の変更</br>
	/// <br>Update Note: 2005.10.19 22021 谷藤　範幸</br>
	/// <br>		   : ・UI子画面Hide時のOwner.Activate処理追加</br>
    /// <br>UpdateNote  : 2008/11/04 30462 行澤仁美　バグ修正</br>
	/// </remarks>

	public class SFANL09040UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{	
		# region Private Members (Component)

		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraLabel ultraLabel15;
		private Infragistics.Win.Misc.UltraLabel SectionCd_ultraLabel;
		private Infragistics.Win.Misc.UltraLabel PrintFooter1_ultraLabel;
		private Infragistics.Win.Misc.UltraLabel PrintFooter2_ultraLabel;
		private Infragistics.Win.Misc.UltraLabel FooterPrintOutCd_ultraLabel;
		private Broadleaf.Library.Windows.Forms.TComboEditor FooterPrintOutCd_tComboEditor;
		private Broadleaf.Library.Windows.Forms.TEdit SectionCd_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PrintFooter1_tEdit;
		private Broadleaf.Library.Windows.Forms.TEdit PrintFooter2_tEdit;
		private Infragistics.Win.Misc.UltraLabel SectionNm_ultraLabel;
		private Broadleaf.Library.Windows.Forms.TEdit SectionNm_tEdit;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Data.DataSet Bind_DataSet;
		private System.Windows.Forms.Timer Initial_Timer;
		private Infragistics.Win.Misc.UltraLabel ExtraCondHeadOutDiv_ultraLabel;
		private Broadleaf.Library.Windows.Forms.TComboEditor ExtraCondHeadOutDiv_tComboEditor;
		private System.ComponentModel.IContainer components;

	    # endregion
		
		# region Constructor
		/// <summary>
		/// 帳票出力設定フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 帳票出力設定フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>

		public SFANL09040UA()
		{
			InitializeComponent();

			// データセット列情報構築処理
			DataSetColumnConstruction();

			// プロパティ初期値設定
			this._canPrint				             = false;
			this._canNew					         = false;
			this._canDelete				             = false;
			this._canLogicalDeleteDataExtraction 	 = false;
			this._canClose				             = true;	
			this._defaultAutoFillToColumn		     = true;
			this._canSpecificationSearch		     = false;
			this._dataIndex                          = -1;
			
			//　企業コードを取得する
			// 2005.09.08 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//			this._enterpriseCode = "TBS1";	// ← 要変更
			// 2005.09.08 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// 2005.09.08 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// 2005.09.08 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			// 最小化対応
			this._indexBuf = -2;
			// 比較用クローン
			this._prtOutSetClone = new PrtOutSet();
			// Work用HashTable
			this._prtOutSetTable = new Hashtable();

			this._prtOutSetAcs   = new PrtOutSetAcs();
			this._prtOutSet      = new PrtOutSet();
			

		}
		# endregion
		
		# region Dispose
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
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance21 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFANL09040UA));
            this.SectionCd_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.PrintFooter1_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.PrintFooter2_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.FooterPrintOutCd_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.FooterPrintOutCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.SectionCd_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PrintFooter1_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PrintFooter2_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.SectionNm_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.SectionNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel15 = new Infragistics.Win.Misc.UltraLabel();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.ExtraCondHeadOutDiv_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.ExtraCondHeadOutDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.FooterPrintOutCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCd_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintFooter1_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintFooter2_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtraCondHeadOutDiv_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // SectionCd_ultraLabel
            // 
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.SectionCd_ultraLabel.Appearance = appearance1;
            this.SectionCd_ultraLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SectionCd_ultraLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SectionCd_ultraLabel.Location = new System.Drawing.Point(16, 12);
            this.SectionCd_ultraLabel.Name = "SectionCd_ultraLabel";
            this.SectionCd_ultraLabel.Size = new System.Drawing.Size(100, 25);
            this.SectionCd_ultraLabel.TabIndex = 8;
            this.SectionCd_ultraLabel.Text = "拠点コード";
            // 
            // PrintFooter1_ultraLabel
            // 
            appearance2.TextHAlignAsString = "Left";
            appearance2.TextVAlignAsString = "Middle";
            this.PrintFooter1_ultraLabel.Appearance = appearance2;
            this.PrintFooter1_ultraLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.PrintFooter1_ultraLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PrintFooter1_ultraLabel.Location = new System.Drawing.Point(16, 100);
            this.PrintFooter1_ultraLabel.Name = "PrintFooter1_ultraLabel";
            this.PrintFooter1_ultraLabel.Size = new System.Drawing.Size(144, 25);
            this.PrintFooter1_ultraLabel.TabIndex = 1;
            this.PrintFooter1_ultraLabel.Text = "帳票フッター文左";
            // 
            // PrintFooter2_ultraLabel
            // 
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.PrintFooter2_ultraLabel.Appearance = appearance3;
            this.PrintFooter2_ultraLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.PrintFooter2_ultraLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PrintFooter2_ultraLabel.Location = new System.Drawing.Point(16, 136);
            this.PrintFooter2_ultraLabel.Name = "PrintFooter2_ultraLabel";
            this.PrintFooter2_ultraLabel.Size = new System.Drawing.Size(144, 25);
            this.PrintFooter2_ultraLabel.TabIndex = 3;
            this.PrintFooter2_ultraLabel.Text = "帳票フッター文右";
            // 
            // FooterPrintOutCd_ultraLabel
            // 
            appearance4.TextHAlignAsString = "Left";
            appearance4.TextVAlignAsString = "Middle";
            this.FooterPrintOutCd_ultraLabel.Appearance = appearance4;
            this.FooterPrintOutCd_ultraLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.FooterPrintOutCd_ultraLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FooterPrintOutCd_ultraLabel.Location = new System.Drawing.Point(16, 172);
            this.FooterPrintOutCd_ultraLabel.Name = "FooterPrintOutCd_ultraLabel";
            this.FooterPrintOutCd_ultraLabel.Size = new System.Drawing.Size(132, 25);
            this.FooterPrintOutCd_ultraLabel.TabIndex = 5;
            this.FooterPrintOutCd_ultraLabel.Text = "フッター出力区分";
            // 
            // FooterPrintOutCd_tComboEditor
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FooterPrintOutCd_tComboEditor.ActiveAppearance = appearance5;
            appearance6.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.FooterPrintOutCd_tComboEditor.Appearance = appearance6;
            this.FooterPrintOutCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.FooterPrintOutCd_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FooterPrintOutCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.FooterPrintOutCd_tComboEditor.ItemAppearance = appearance7;
            this.FooterPrintOutCd_tComboEditor.Location = new System.Drawing.Point(196, 172);
            this.FooterPrintOutCd_tComboEditor.MaxDropDownItems = 18;
            this.FooterPrintOutCd_tComboEditor.Name = "FooterPrintOutCd_tComboEditor";
            this.FooterPrintOutCd_tComboEditor.Size = new System.Drawing.Size(115, 24);
            this.FooterPrintOutCd_tComboEditor.TabIndex = 3;
            // 
            // SectionCd_tEdit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SectionCd_tEdit.ActiveAppearance = appearance8;
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            this.SectionCd_tEdit.Appearance = appearance9;
            this.SectionCd_tEdit.AutoSelect = true;
            this.SectionCd_tEdit.DataText = "";
            this.SectionCd_tEdit.Enabled = false;
            this.SectionCd_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionCd_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionCd_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SectionCd_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SectionCd_tEdit.Location = new System.Drawing.Point(196, 13);
            this.SectionCd_tEdit.MaxLength = 6;
            this.SectionCd_tEdit.Name = "SectionCd_tEdit";
            this.SectionCd_tEdit.Size = new System.Drawing.Size(68, 24);
            this.SectionCd_tEdit.TabIndex = 9;
            // 
            // PrintFooter1_tEdit
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintFooter1_tEdit.ActiveAppearance = appearance10;
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            this.PrintFooter1_tEdit.Appearance = appearance11;
            this.PrintFooter1_tEdit.AutoSelect = true;
            this.PrintFooter1_tEdit.DataText = "";
            this.PrintFooter1_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PrintFooter1_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 25, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PrintFooter1_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PrintFooter1_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PrintFooter1_tEdit.Location = new System.Drawing.Point(196, 100);
            this.PrintFooter1_tEdit.MaxLength = 25;
            this.PrintFooter1_tEdit.Name = "PrintFooter1_tEdit";
            this.PrintFooter1_tEdit.Size = new System.Drawing.Size(401, 24);
            this.PrintFooter1_tEdit.TabIndex = 1;
            // 
            // PrintFooter2_tEdit
            // 
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintFooter2_tEdit.ActiveAppearance = appearance12;
            appearance13.BackColorDisabled = System.Drawing.SystemColors.Control;
            this.PrintFooter2_tEdit.Appearance = appearance13;
            this.PrintFooter2_tEdit.AutoSelect = true;
            this.PrintFooter2_tEdit.DataText = "";
            this.PrintFooter2_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PrintFooter2_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 25, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PrintFooter2_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.PrintFooter2_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PrintFooter2_tEdit.Location = new System.Drawing.Point(196, 136);
            this.PrintFooter2_tEdit.MaxLength = 25;
            this.PrintFooter2_tEdit.Name = "PrintFooter2_tEdit";
            this.PrintFooter2_tEdit.Size = new System.Drawing.Size(401, 24);
            this.PrintFooter2_tEdit.TabIndex = 2;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 267);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(608, 23);
            this.ultraStatusBar1.TabIndex = 13;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Ok_Button
            // 
            this.Ok_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(348, 212);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 6;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(476, 212);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 7;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Mode_Label
            // 
            appearance14.ForeColor = System.Drawing.Color.White;
            appearance14.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance14.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance14.TextHAlignAsString = "Center";
            appearance14.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance14;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.Mode_Label.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            this.Mode_Label.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            appearance15.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance15.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance15.TextHAlignAsString = "Center";
            appearance15.TextVAlignAsString = "Middle";
            this.Mode_Label.HotTrackAppearance = appearance15;
            this.Mode_Label.Location = new System.Drawing.Point(500, 8);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 14;
            this.Mode_Label.Text = "更新モード";
            // 
            // SectionNm_ultraLabel
            // 
            appearance16.TextHAlignAsString = "Left";
            appearance16.TextVAlignAsString = "Middle";
            this.SectionNm_ultraLabel.Appearance = appearance16;
            this.SectionNm_ultraLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.SectionNm_ultraLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SectionNm_ultraLabel.Location = new System.Drawing.Point(16, 47);
            this.SectionNm_ultraLabel.Name = "SectionNm_ultraLabel";
            this.SectionNm_ultraLabel.Size = new System.Drawing.Size(100, 25);
            this.SectionNm_ultraLabel.TabIndex = 10;
            this.SectionNm_ultraLabel.Text = "拠点名";
            // 
            // SectionNm_tEdit
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.SectionNm_tEdit.ActiveAppearance = appearance17;
            appearance18.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            this.SectionNm_tEdit.Appearance = appearance18;
            this.SectionNm_tEdit.AutoSelect = true;
            this.SectionNm_tEdit.DataText = "";
            this.SectionNm_tEdit.Enabled = false;
            this.SectionNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.SectionNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 6, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.SectionNm_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SectionNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.SectionNm_tEdit.Location = new System.Drawing.Point(196, 48);
            this.SectionNm_tEdit.MaxLength = 6;
            this.SectionNm_tEdit.Name = "SectionNm_tEdit";
            this.SectionNm_tEdit.Size = new System.Drawing.Size(115, 24);
            this.SectionNm_tEdit.TabIndex = 11;
            // 
            // ultraLabel15
            // 
            this.ultraLabel15.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel15.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.Inset;
            this.ultraLabel15.Location = new System.Drawing.Point(10, 84);
            this.ultraLabel15.Name = "ultraLabel15";
            this.ultraLabel15.Size = new System.Drawing.Size(590, 3);
            this.ultraLabel15.TabIndex = 12;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // ExtraCondHeadOutDiv_ultraLabel
            // 
            appearance22.TextHAlignAsString = "Left";
            appearance22.TextVAlignAsString = "Middle";
            this.ExtraCondHeadOutDiv_ultraLabel.Appearance = appearance22;
            this.ExtraCondHeadOutDiv_ultraLabel.BackColorInternal = System.Drawing.Color.WhiteSmoke;
            this.ExtraCondHeadOutDiv_ultraLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ExtraCondHeadOutDiv_ultraLabel.Location = new System.Drawing.Point(16, 208);
            this.ExtraCondHeadOutDiv_ultraLabel.Name = "ExtraCondHeadOutDiv_ultraLabel";
            this.ExtraCondHeadOutDiv_ultraLabel.Size = new System.Drawing.Size(176, 25);
            this.ExtraCondHeadOutDiv_ultraLabel.TabIndex = 15;
            this.ExtraCondHeadOutDiv_ultraLabel.Text = "抽出条件ヘッダ出力区分";
            // 
            // ExtraCondHeadOutDiv_tComboEditor
            // 
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ExtraCondHeadOutDiv_tComboEditor.ActiveAppearance = appearance19;
            appearance20.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance20.ForeColorDisabled = System.Drawing.Color.Black;
            this.ExtraCondHeadOutDiv_tComboEditor.Appearance = appearance20;
            this.ExtraCondHeadOutDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.ExtraCondHeadOutDiv_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ExtraCondHeadOutDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.ExtraCondHeadOutDiv_tComboEditor.ItemAppearance = appearance21;
            this.ExtraCondHeadOutDiv_tComboEditor.Location = new System.Drawing.Point(12, 240);
            this.ExtraCondHeadOutDiv_tComboEditor.MaxDropDownItems = 18;
            this.ExtraCondHeadOutDiv_tComboEditor.Name = "ExtraCondHeadOutDiv_tComboEditor";
            this.ExtraCondHeadOutDiv_tComboEditor.Size = new System.Drawing.Size(208, 24);
            this.ExtraCondHeadOutDiv_tComboEditor.TabIndex = 0;
            // 
            // SFANL09040UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(608, 290);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.ExtraCondHeadOutDiv_tComboEditor);
            this.Controls.Add(this.ExtraCondHeadOutDiv_ultraLabel);
            this.Controls.Add(this.ultraLabel15);
            this.Controls.Add(this.SectionNm_tEdit);
            this.Controls.Add(this.SectionNm_ultraLabel);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.PrintFooter2_tEdit);
            this.Controls.Add(this.PrintFooter1_tEdit);
            this.Controls.Add(this.SectionCd_tEdit);
            this.Controls.Add(this.FooterPrintOutCd_tComboEditor);
            this.Controls.Add(this.FooterPrintOutCd_ultraLabel);
            this.Controls.Add(this.PrintFooter2_ultraLabel);
            this.Controls.Add(this.PrintFooter1_ultraLabel);
            this.Controls.Add(this.SectionCd_ultraLabel);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFANL09040UA";
            this.Text = "帳票出力設定";
            this.Load += new System.EventHandler(this.SFANL09040U_Load);
            this.VisibleChanged += new System.EventHandler(this.SFANL09040U_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFANL09040U_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.FooterPrintOutCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionCd_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintFooter1_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintFooter2_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SectionNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ExtraCondHeadOutDiv_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Events
		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		# endregion
		
		# region Main
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{	
			System.Windows.Forms.Application.Run(new SFANL09040UA());
		}
		# endregion

		#region Private Menbers

		// アクセスクラスメンバ
		private PrtOutSetAcs _prtOutSetAcs;
		// データクラスメンバ
		private PrtOutSet _prtOutSet;
		// 企業Code
		private string _enterpriseCode;
		// Work用HashTable
		private Hashtable _prtOutSetTable;
		// _GridIndexバッファ（メインフレーム最小化対応）
		private int _indexBuf;
		// 比較用Clone
		private PrtOutSet _prtOutSetClone;

		// プロパティ用
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private int	 _dataIndex;
		private bool _defaultAutoFillToColumn;
		private bool _canSpecificationSearch;
		
		// FrameのGrid列のKEY情報 (HeaderのTitle部となります)
		private const string SECTION_CODE_TITLE			    = "拠点コード";
        //private const string SECTION_NAME_TITLE             = "拠点名称";       // DEL 2008/11/04 不具合対応[7308]
        private const string SECTION_NAME_TITLE             = "拠点名";         // ADD 2008/11/04 不具合対応[7308]
		private const string EXTRA_COND_HEAD_OUT_DIV_TITLE	= "抽出条件ヘッダ出力区分";
		private const string PRINT_FOOTER_TITLE１			= "帳票フッター文左";
		private const string PRINT_FOOTER_TITLE２			= "帳票フッター文右";
		private const string FOOTER_PRINT_OUT_CODE_TITLE	= "フッター出力区分";
		private const string GUID_KEY_TITLE			        = "Guid";

		// FrameのGridに表示させるテーブル名
		private const string VIEW_TABLE = "VIEW_TABLE";

		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";	   
		private const string DELETE_MODE = "削除モード";

		# endregion

		# region Properties
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
		# endregion
		
		# region Public Methods
		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet">グリッドリッド用データセット</param>
		/// <param name="tableName">テーブル名称</param>
		/// <remarks>
		/// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = VIEW_TABLE;
		}

		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 先頭から指定件数分のデータを検索し、</br>
		///	<br>			  抽出結果を展開したDataSetと全該当件数を返します。</br>
		/// <br>Programmer	: 23010　中村　仁</br>
		/// <br>Date		: 2005.08.11</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{	
			int status = 0;
			int index = 0;
			ArrayList prtOutSetList = new ArrayList();

			status = this._prtOutSetAcs.Search(
				out prtOutSetList,
				this._enterpriseCode);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					foreach(PrtOutSet prtOutSet in prtOutSetList)
					{
						if (this._prtOutSetTable.ContainsKey(prtOutSet.FileHeaderGuid) == false)
						{
							prtOutSetToDataSet(prtOutSet.Clone(), index);
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
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					// サーチ
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						"SFANL09040U", 						// アセンブリＩＤまたはクラスＩＤ
						"帳票出力設定",						// プログラム名称
						"Search", 							// 処理名称
						TMsgDisp.OPE_GET, 					// オペレーション
						"読み込みに失敗しました。",			// 表示するメッセージ
						status, 							// ステータス値
						this._prtOutSetAcs,	 				// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					
					// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					MessageBox.Show(
//						"読み込みに失敗しました。 st = " + status.ToString(),
//						"エラー",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
					// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					break;
				}

			}
			totalCount = index;
			return status;

		}

		/// <summary>
		/// ネクストデータ検索処理
		/// </summary>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 指定した件数分のネクストデータを検索します。</br>
		/// <br>Programmer	: 23010 中村　仁</br>
		/// <br>Date		: 2005.08.11</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			// 全件抽出する為処理無し
			return 9;
		}

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 選択中のデータを削除します。</br>
		/// <br>Programmer	: 23010 中村　仁</br>
		/// <br>Date		: 2005.08.11</br>
		/// </remarks>
		public int Delete()
		{
			// 削除処理無し
			return 0;
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note		: 印刷処理を実行します。</br>
		/// <br>Programmer	: 23010 中村　仁</br>
		/// <br>Date		: 2005.08.11</br>
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
		/// <br>Note		: 各列の外見を設定するクラスを格納したHashtableを取得します。</br>
		/// <br>Programmer	: 23010 中村　仁</br>
		/// <br>Date		: 2005.08.18</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			appearanceTable.Add(SECTION_CODE_TITLE			     ,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black)); 
			appearanceTable.Add(SECTION_NAME_TITLE		　       ,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
			
			// ↓後日導入
			appearanceTable.Add(EXTRA_COND_HEAD_OUT_DIV_TITLE    ,new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleLeft,"",Color.Black));
　　    	
			appearanceTable.Add(PRINT_FOOTER_TITLE１    　　     ,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(PRINT_FOOTER_TITLE２　           ,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(FOOTER_PRINT_OUT_CODE_TITLE	     ,new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
			// GUIDは非表示
			appearanceTable.Add(GUID_KEY_TITLE			         ,new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleRight,"",Color.Black));
			return appearanceTable;
		}

		# endregion

		# region Private Method
		/// <summary>
		/// 帳票出力設定データセット処理
		/// </summary>
		/// <param name="vlPntMtRtU">帳票出力設定オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
		/// <br>Note		: 帳票出力設定オブジェクトから画面にデータを展開します。</br>
		/// <br>Programmer	: 23010 中村　仁</br>
		/// <br>Date		: 2005.08.18</br>
		/// </remarks>
		private void prtOutSetToDataSet(PrtOutSet prtOutSet, int index)
		{	
			if ((index < 0) || (this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[VIEW_TABLE].NewRow();
				this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Add(dataRow);

				// indexを行の最終行番号にする
				index = this.Bind_DataSet.Tables[VIEW_TABLE].Rows.Count - 1;
			}
			
			// 拠点コード
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][SECTION_CODE_TITLE] = prtOutSet.SectionCode;
			// 拠点名称
//			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][SECTION_NAME_TITLE] = prtOutSet.SectionName + "　" + prtOutSet.SectionName2;
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][SECTION_NAME_TITLE] = prtOutSet.SectionName;
			// 帳票フッター文左
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][PRINT_FOOTER_TITLE１] = prtOutSet.PrintFooter1;
			// 帳票フッター文右
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][PRINT_FOOTER_TITLE２] = prtOutSet.PrintFooter2;
			// フッター出力区分
			switch(prtOutSet.FooterPrintOutCode)
			{
				case(0):
				{
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][FOOTER_PRINT_OUT_CODE_TITLE] = "する";
					break;
				}
				case(1):
				{
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][FOOTER_PRINT_OUT_CODE_TITLE] = "しない";
					break;
				}
				default:
				{
					break;
				}
			}
			
			// 2005.11.09 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// 抽出条件ヘッダ出力区分
			switch(prtOutSet.ExtraCondHeadOutDiv)
			{
				case(0):
				{
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][EXTRA_COND_HEAD_OUT_DIV_TITLE] = "毎ページ出力する";
					break;
				}
				case(1):
				{
					this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][EXTRA_COND_HEAD_OUT_DIV_TITLE] = "１ページ目のみ出力する";
					break;
				}
				default:
				{
					break;
				}
			}
			// 2005.11.09 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			
			// GUID
			this.Bind_DataSet.Tables[VIEW_TABLE].Rows[index][GUID_KEY_TITLE] = prtOutSet.FileHeaderGuid;

			if (this._prtOutSetTable.ContainsKey(prtOutSet.FileHeaderGuid) == true)
			{
				this._prtOutSetTable.Remove(prtOutSet.FileHeaderGuid);
			}
			this._prtOutSetTable.Add(prtOutSet.FileHeaderGuid, prtOutSet);	
	
		}

		/// <summary>
		/// グリッドバインド処理
		/// </summary>
		/// <remarks>
		/// <br>Note		: 配列項目をグリッドへバインドします。</br>
		/// <br>Programmer	: 23010 中村　仁</br>
		/// <br>Date       : 2005.08.18</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{	
			// Addを行う順番が、列の表示順位となります。
			DataTable viewTable	= new DataTable(VIEW_TABLE);
			viewTable.Columns.Add(SECTION_CODE_TITLE			　 , typeof(string));
			viewTable.Columns.Add(SECTION_NAME_TITLE               , typeof(string));
			viewTable.Columns.Add(EXTRA_COND_HEAD_OUT_DIV_TITLE	   , typeof(string));
			viewTable.Columns.Add(PRINT_FOOTER_TITLE１		       , typeof(string));
			viewTable.Columns.Add(PRINT_FOOTER_TITLE２		       , typeof(string));
			viewTable.Columns.Add(FOOTER_PRINT_OUT_CODE_TITLE	   , typeof(string));
			viewTable.Columns.Add(GUID_KEY_TITLE				   , typeof(Guid));
			this.Bind_DataSet.Tables.Add(viewTable);
		}

		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2005.08.18</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			this.FooterPrintOutCd_tComboEditor.Items.Clear();
			this.FooterPrintOutCd_tComboEditor.Items.Add(0, "する");									
			this.FooterPrintOutCd_tComboEditor.Items.Add(1, "しない");									
			this.FooterPrintOutCd_tComboEditor.MaxDropDownItems = this.FooterPrintOutCd_tComboEditor.Items.Count;

			// 2005.11.09 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this.ExtraCondHeadOutDiv_tComboEditor.Items.Clear();
			this.ExtraCondHeadOutDiv_tComboEditor.Items.Add(0, "毎ページ出力する");									
			this.ExtraCondHeadOutDiv_tComboEditor.Items.Add(1, "１ページ目のみ出力する");									
			this.ExtraCondHeadOutDiv_tComboEditor.MaxDropDownItems = this.ExtraCondHeadOutDiv_tComboEditor.Items.Count;
			// 2005.11.09 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			
			// ↓後日導入
			// 2005.11.18 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this.ExtraCondHeadOutDiv_ultraLabel.Visible = false;
			this.ExtraCondHeadOutDiv_tComboEditor.Visible = false;
			// 2005.11.18 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
		
		}

		/// <summary>
		/// 画面初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期化を行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2005.08.18</br>
		/// </remarks>
		private void ScreenClear()
		{	
			this.SectionCd_tEdit.Text			    = "";
			this.SectionNm_tEdit.Text			    = "";
			this.PrintFooter1_tEdit.Text			= "";
			this.PrintFooter2_tEdit.Text			= "";
			this.FooterPrintOutCd_tComboEditor.SelectedIndex = 0;
			// 2005.11.09 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this.ExtraCondHeadOutDiv_tComboEditor.SelectedIndex = 0;
			// 2005.11.09 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面の再構築を行います。</br>
		/// <br>Programmer : 23010 中村 仁</br>
		/// <br>Date       : 2005.08.18</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			if (this._dataIndex < 0)
			{
				// 新規モード
				//ありえないので未実装
			}
			else
			{
				// 保持しているデータセットより修正前情報取得
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][GUID_KEY_TITLE];
				PrtOutSet prtOutSet = (PrtOutSet)this._prtOutSetTable[guid];
				
				// 帳票出力クラス画面展開処理
				PrtOutSetToScreen(prtOutSet);

				// 更新モード
				this.Mode_Label.Text = UPDATE_MODE;

				// 初期フォーカスを設定　	
				this.PrintFooter1_tEdit.Focus();
				this.PrintFooter1_tEdit.SelectAll();
				
				// ↓後日導入予定
				// 2005.11.09 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//				this.ExtraCondHeadOutDiv_tComboEditor.Focus();
				// 2005.11.09 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
				
				//クローン作成
				this._prtOutSetClone = prtOutSet.Clone();
  
				//画面情報を比較用クローンにコピーする　　　　　   
				DispToPrtOutSet(ref this._prtOutSetClone);

				// フレームの最小化対応
				this._indexBuf = this._dataIndex;
			}
		}

		/// <summary>
		/// 拠点情報クラス画面展開処理
		/// </summary>
		/// <param name="secInfoSet">拠点情報クラス</param>
		/// <remarks>
		/// <br>Note       : 拠点情報クラス情報から画面にデータを展開します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.03.18</br>
		/// </remarks>
		private void PrtOutSetToScreen(PrtOutSet prtOutSet)
		{	
			// 拠点コード
			this.SectionCd_tEdit.Text = prtOutSet.SectionCode;
			// 拠点名称
			
			//2005.10.14 N.TANIFUJI DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
//			this.SectionNm_tEdit.Text = prtOutSet.SectionName + "　" + prtOutSet.SectionName2;
			//2005.10.14 N.TANIFUJI DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
			
			//2005.10.14 N.TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
			this.SectionNm_tEdit.Text = prtOutSet.SectionName; // + "　" + prtOutSet.SectionName2;
			//2005.10.14 N.TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end

			// 帳票フッター文左　
			this.PrintFooter1_tEdit.Text = prtOutSet.PrintFooter1;
			// 帳票フッター文右
			this.PrintFooter2_tEdit.Text = prtOutSet.PrintFooter2;
			// フッター出力区分
			this.FooterPrintOutCd_tComboEditor.SelectedIndex = prtOutSet.FooterPrintOutCode;

			// 2005.11.09 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// 抽出条件ヘッダ出力区分
			this.ExtraCondHeadOutDiv_tComboEditor.SelectedIndex = prtOutSet.ExtraCondHeadOutDiv;
			// 2005.11.09 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
		}

		/// <summary>
		/// 画面情報拠点情報クラス格納処理
		/// </summary>
		/// <param name="secInfoSet">拠点情報クラス</param>
		/// <remarks>
		/// <br>Note       : 画面情報から拠点情報クラスにデータを格納します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2005.08.18</br>
		/// </remarks>
		private void DispToPrtOutSet(ref PrtOutSet prtOutSet)
		{
			if (prtOutSet == null)
			{
				// 新規の場合
				prtOutSet = new PrtOutSet();
			}
			// 企業コード
			prtOutSet.EnterpriseCode = this._enterpriseCode;
			prtOutSet.SectionCode  = this.SectionCd_tEdit.Text.TrimEnd();
 //		    prtOutSet.SectionName  = this.SectionNm_tEdit.Text.TrimEnd();
			prtOutSet.PrintFooter1 = this.PrintFooter1_tEdit.Text.TrimEnd();
			prtOutSet.PrintFooter2 = this.PrintFooter2_tEdit.Text.TrimEnd();
			prtOutSet.FooterPrintOutCode = this.FooterPrintOutCd_tComboEditor.SelectedIndex;
			// 2005.11.09 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			prtOutSet.ExtraCondHeadOutDiv = this.ExtraCondHeadOutDiv_tComboEditor.SelectedIndex;
			// 2005.11.09 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			
		}

		/// <summary>
		/// 保存処理
		/// </summary>
		/// <returns>登録結果結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 保存処理を行います。</br>
		/// <br>Programmer : 23010　中村　仁</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		private bool SavePrtOutSet()
		{
			PrtOutSet prtOutSet = null;

			if (this.DataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[VIEW_TABLE].Rows[this._dataIndex][GUID_KEY_TITLE];
//				prtOutSet = (PrtOutSet)this._prtOutSetTable[guid];
				prtOutSet = ((PrtOutSet)this._prtOutSetTable[guid]).Clone();
			}

			DispToPrtOutSet(ref prtOutSet);
			int status = this._prtOutSetAcs.Write(ref prtOutSet);    //書込み処理

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status);
					return false;
				}
				default:
				{
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					// サーチ
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						"SFANL09040U", 						// アセンブリＩＤまたはクラスＩＤ
						"帳票出力設定",						// プログラム名称
						"SavePrtOutSet", 					// 処理名称
						TMsgDisp.OPE_GET, 					// オペレーション
						"登録に失敗しました。",				// 表示するメッセージ
						status, 							// ステータス値
						this._prtOutSetAcs,	 				// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					
					// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					MessageBox.Show(
//						"登録に失敗しました。 st = " + status.ToString(),
//						"エラー",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
					// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					return false;
				}
			}

			prtOutSetToDataSet(prtOutSet, this.DataIndex);

			return true;
		}

		/// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="control">不正対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の不正チェックを行います。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2005.08.19</br>
		/// </remarks>
		private void ExclusiveTransaction(int status)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					// 他端末更新
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
						"SFANL09040U", 						// アセンブリＩＤまたはクラスＩＤ
						"既に他端末より更新されています。", // 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.OK );				// 表示するボタン
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					MessageBox.Show(
//						"既に他端末より更新されています",
//						"注意",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Exclamation,
//						MessageBoxDefaultButton.Button1);
					// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					this.Hide();
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					// 他端末削除
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
						"SFANL09040U", 						// アセンブリＩＤまたはクラスＩＤ
						"既に他端末より削除されています。", // 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.OK );				// 表示するボタン
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					MessageBox.Show(
//						"既に他端末より削除されています",
//						"注意",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Exclamation,
//						MessageBoxDefaultButton.Button1);
					// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					this.Hide();
					break;
				}
			}
		}
		# endregion

		#region Control Events
		/// <summary>
		/// Form.Load イベント(SFANL09040U)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　 : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date	   : 2005.08.18</br>
		/// </remarks>
		private void SFANL09040U_Load(object sender, System.EventArgs e)
		{
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList25 = IconResourceManagement.ImageList24;

			this.Ok_Button.ImageList	 = imageList25;
			this.Cancel_Button.ImageList = imageList25;

			this.Ok_Button.Appearance.Image		= Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;

			ScreenInitialSetting();		
		}

		/// <summary>
		/// Control.VisibleChanged イベント(SFANL09040U)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note 　　  : フォームの表示状態が変わったときに発生します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date	   : 2005.08.18</br>
		/// </remarks>
		private void SFANL09040U_VisibleChanged(object sender, System.EventArgs e)
		{
			// 自分自身が非表示になった場合は以下の処理をキャンセルする。
			if (this.Visible == false)
			{
				//2005.10.19 N.TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
				// メインフレームアクティブ化
				this.Owner.Activate();
				//2005.10.19 N.TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
				return;
			}

			//フレームの最小化対応
			if(this._indexBuf == this._dataIndex)
			{
				return;
			}

			Initial_Timer.Enabled = true;
			ScreenClear();
		}

		/// <summary>
		/// Form.Closing イベント(SFANL09040)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note　　　  : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
		/// <br>Programmer  : 23010 中村　仁</br>
		/// <br>Date        : 2005.08.19</br>
		/// </remarks>
		private void SFANL09040U_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{	
			//GridのIndexBuffer格納用変数初期化
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
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 23010 中村　仁</br>
		/// <br>Date        : 2005.08.19</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			// 帳票出力登録処理
			if (SavePrtOutSet() == false)
			{
				return;
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;
			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}

			// フレームの最小化対応
			this._indexBuf = -2;
		}

		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 23010 中村　仁</br>
		/// <br>Date        : 2005.08.19</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			//保存確認
			PrtOutSet cmpPrtOutSet = new PrtOutSet();
			cmpPrtOutSet = this._prtOutSetClone.Clone();
			//現在の画面情報を取得する
			DispToPrtOutSet( ref cmpPrtOutSet);
			//最初に取得した画面情報と比較
			if (!(this._prtOutSetClone.Equals(cmpPrtOutSet)))	
			{     
				//画面情報が変更されていた場合は、保存確認メッセージを表示する
				// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				// 保存確認
				DialogResult res = TMsgDisp.Show( 
					this, 								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
					"SFANL09040U", 						// アセンブリＩＤまたはクラスＩＤ
					null, 								// 表示するメッセージ
					0, 									// ステータス値
					MessageBoxButtons.YesNoCancel );	// 表示するボタン
				// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

				// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//				DialogResult res = MessageBox.Show("編集中のデータが存在します"+"\r\n"+"\r\n"+"登録してもよろしいですか？","保存確認",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
				// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
				
				switch(res)
				{
					case DialogResult.Yes:
					{
						if (SavePrtOutSet() == false)
						{
							return;
						}

						this.DialogResult = DialogResult.OK;
						break;
					}
					case DialogResult.No:
					{
						this.DialogResult = DialogResult.Cancel;
						break;
					}
					default:
					{
						// 2005.09.02 TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
						this.Cancel_Button.Focus();
						// 2005.09.02 TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
						return;
					}
				}
			}
			
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
				UnDisplaying(this, me);
			}
			// フレームの最小化対応
			this._indexBuf = -2;
	
			this.DialogResult = DialogResult.Cancel;

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
		/// <br>Programmer  : 23010 中村　仁</br>
		/// <br>Date        : 2005.08.19</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}

		#endregion
	}
}
