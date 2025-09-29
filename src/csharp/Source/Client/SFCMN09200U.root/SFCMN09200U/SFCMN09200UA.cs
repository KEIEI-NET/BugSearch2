using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
//using Broadleaf.Resouces;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using System.Management;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// プリンタ管理情報入力フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : プリンタ管理情報設定を行います。
	///					 IMasterMaintenanceMultiTypeを実装しています。</br>
	/// <br>Programmer : 97606 藤　江梨子</br>
	/// <br>Date       : 2005.03.22</br>
	/// <br></br>
	/// <br>Update Note: 2005.05.27 22025 當間 豊</br>
	/// <br>			・フレームの最小化対応</br>
	/// <br>Update Note: 2005.06.09 22025 當間 豊</br>
	/// <br>			・フレームに表示する内容の表示位置を右詰めに変更</br>
	/// <br>Update Note: 2005.06.13 22011 柏原 頼人</br>
	/// <br>			・左・右詰めを最適化(プロパティの変更のみ)</br> 
	/// <br>Update Note: 2005.06.21 22011 柏原 頼人</br>
	/// <br>			・ラベルをクリックしてもフォーカスがラベルに移らないよう修正(プロパティの変更のみ)</br> 
	/// <br>			・数値項目でゼロの抑制(プロパティの変更のみ)</br> 
	/// <br>Update Note: 2005.06.23 22011 柏原 頼人</br>
	/// <br>			・入力不可項目の文字色を黒に設定(プロパティの変更のみ)</br>
	/// <br>			・フォームに無駄な余白があったのでデザイナ上でトリミング</br>
	/// <br>			・印刷種類のコンボボックスのMaxDropDownItemsを18に変更(プロパティの変更のみ)</br>	  
	/// <br>Update Note: 2005.06.24 22011 柏原 頼人</br>
	/// <br>			・tNEditのForeColerをBlackに変更(プロパティの変更のみ)</br>
	/// <br>			・tNEditのTextに直接値を代入しないよう変更</br>
	/// <br>Update Note: 2005.07.01 22011 柏原 頼人</br>
	/// <br>			・入力不可項目のIMEModeをDisableに変更(プロパティの変更のみ)</br>
	/// <br>Update Note: 2005.07.02 22011 柏原 頼人</br>
	/// <br>            ・最小化対応を新ロジックに変更</br>
	/// <br>Update Note: 2005.07.06 22011 柏原 頼人</br>
	/// <br>            ・排他制御対応</br>
	/// <br>Update Note: 2005.07.07 22011 柏原 頼人</br>
	/// <br>            ・エラー発生時クローズ処理追加</br>
	/// <br>Update Note:2005.07.11 22011 柏原</br> 
	/// <br>            NetAdvantege 2005 Vol.1対応(リコンパイル)</br>
	/// <br>Update Note:2005.07.12 22011 柏原</br> 
	/// <br>            排他制御のメッセージを修正</br>
	/// <br>Update Note:2005.09.14 22011 柏原</br> 
	/// <br>            ログイン情報取得部品使用</br>
	/// <br>Update Note:2005.09.20 22011 柏原</br> 
	/// <br>            MessageBox→TMsgDispに変更</br>
	/// <br>Update Note:2005.09.26 22011 柏原</br> 
	/// <br>            削除確認ダイアログでキャンセルを押下時に削除ボタンへフォーカス</br>
	/// <br>Update Note:2005.10.19 22011 柏原</br> 
	/// <br>            ダイアログ表示後フレームが他のウィンドウの後ろに回りこむ現象への対応</br> 
	/// <br></br>
	/// <br>Update Note : 2007.02.06 18322 T.Kimura MA.NS用に変更</br>
	/// <br>			:                           ・画面スキン変更対応</br>
    /// <br>Update Note : 2007.04.02 20031 古賀</br>
    /// <br>			: プリンタ管理No.のグリッド表示型を文字列(string)から数値(Int32)に変更</br>
    /// <br>Update Note : 2008.06.10 30413 犬飼</br>
    /// <br>             ・PM.NS対応 (プリンタ種類を項目から削除)</br>
    /// </remarks>
	public class SFCMN09200UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		# region Private Members (Component)
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private Infragistics.Win.Misc.UltraLabel Guid_Label;
		private Broadleaf.Library.Windows.Forms.TEdit PrinterPort_tEdit;
		private Infragistics.Win.Misc.UltraLabel PrinterName_Title_Label;
        private Infragistics.Win.Misc.UltraLabel PrinterMngNo_Title_Label;
		private Broadleaf.Library.Windows.Forms.TComboEditor PrinterName_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel PrinterPort_Title_Label;
		private System.Data.DataSet Bind_DataSet;
		private Broadleaf.Library.Windows.Forms.TNedit PrinterMngNo_tNedit;
        private Infragistics.Win.Misc.UltraLabel PrinterKind_Title_Label;
        private TComboEditor PrinterKind_tComboEditor;
		private System.ComponentModel.IContainer components;
		# endregion

		#region Constractor
		/// <summary>
		/// プリンタ管理情報入力フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : プリンタ管理情報入力フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public SFCMN09200UA()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			// データセット列情報構築処理
			DataSetColumnConstruction();

			// プロパティ初期値設定
			this._canPrint  = false;
			this._canClose  = false;
			this._canNew    = true;
			this._canDelete = true;
			this._canLogicalDeleteDataExtraction = true;
			this._canClose  = true;			// デフォルト:true固定
			this._defaultAutoFillToColumn = true;
			this._canSpecificationSearch = false;

			//　企業コードを取得する
			//2005.09.14 ---START
			//2005.09.14 this._enterpriseCode = "TBS1";	// ← 要変更
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			//2005.09.14 ---START

			// 変数初期化
			this._dataIndex = -1;
			this._prtManageAcs = new PrtManageAcs();
			this._prevPrtManage = null;
			this._nextData = false;
			this._totalCount = 0;
			this._prtManageTable = new Hashtable();

			// 2005.05.27 TOUMA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
			// 最小化判定用フラグ
			//2005.07.02 this._minFlg = false;
			this._indexBuf = -2;
			//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
			// 2005.05.27 TOUMA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

		}
		#endregion

		#region Dispose
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
		#endregion

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
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFCMN09200UA));
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.PrinterMngNo_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Guid_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PrinterName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PrinterPort_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PrinterPort_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PrinterName_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.PrinterMngNo_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PrinterKind_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PrinterKind_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrinterPort_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrinterName_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrinterMngNo_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrinterKind_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // Mode_Label
            // 
            appearance1.ForeColor = System.Drawing.Color.White;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance1;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(540, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 9;
            // 
            // Delete_Button
            // 
            appearance2.ForeColor = System.Drawing.Color.Black;
            this.Delete_Button.Appearance = appearance2;
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(140, 200);
            this.Delete_Button.Name = "Delete_Button";
            this.Delete_Button.Size = new System.Drawing.Size(125, 34);
            this.Delete_Button.TabIndex = 3;
            this.Delete_Button.Text = "完全削除(&D)";
            this.Delete_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Delete_Button.Click += new System.EventHandler(this.Delete_Button_Click);
            // 
            // Revive_Button
            // 
            appearance3.ForeColor = System.Drawing.Color.Black;
            this.Revive_Button.Appearance = appearance3;
            this.Revive_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Revive_Button.Location = new System.Drawing.Point(265, 200);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 4;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // Ok_Button
            // 
            appearance4.ForeColor = System.Drawing.Color.Black;
            this.Ok_Button.Appearance = appearance4;
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(390, 200);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 5;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            appearance5.ForeColor = System.Drawing.Color.Black;
            this.Cancel_Button.Appearance = appearance5;
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(515, 200);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 6;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 244);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(652, 23);
            this.ultraStatusBar1.TabIndex = 5;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
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
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // PrinterMngNo_Title_Label
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.PrinterMngNo_Title_Label.Appearance = appearance19;
            this.PrinterMngNo_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.PrinterMngNo_Title_Label.Location = new System.Drawing.Point(15, 50);
            this.PrinterMngNo_Title_Label.Name = "PrinterMngNo_Title_Label";
            this.PrinterMngNo_Title_Label.Size = new System.Drawing.Size(120, 24);
            this.PrinterMngNo_Title_Label.TabIndex = 10;
            this.PrinterMngNo_Title_Label.Text = "プリンタ管理No";
            // 
            // Guid_Label
            // 
            this.Guid_Label.Location = new System.Drawing.Point(210, 50);
            this.Guid_Label.Name = "Guid_Label";
            this.Guid_Label.Size = new System.Drawing.Size(428, 25);
            this.Guid_Label.TabIndex = 8;
            this.Guid_Label.Visible = false;
            // 
            // PrinterName_Title_Label
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.PrinterName_Title_Label.Appearance = appearance18;
            this.PrinterName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.PrinterName_Title_Label.Location = new System.Drawing.Point(15, 85);
            this.PrinterName_Title_Label.Name = "PrinterName_Title_Label";
            this.PrinterName_Title_Label.Size = new System.Drawing.Size(120, 24);
            this.PrinterName_Title_Label.TabIndex = 11;
            this.PrinterName_Title_Label.Text = "プリンタ名";
            // 
            // PrinterPort_Title_Label
            // 
            appearance13.TextVAlignAsString = "Middle";
            this.PrinterPort_Title_Label.Appearance = appearance13;
            this.PrinterPort_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.PrinterPort_Title_Label.Location = new System.Drawing.Point(15, 120);
            this.PrinterPort_Title_Label.Name = "PrinterPort_Title_Label";
            this.PrinterPort_Title_Label.Size = new System.Drawing.Size(120, 24);
            this.PrinterPort_Title_Label.TabIndex = 12;
            this.PrinterPort_Title_Label.Text = "プリンタパス";
            // 
            // PrinterPort_tEdit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.ForeColor = System.Drawing.Color.Black;
            appearance8.ForeColorDisabled = System.Drawing.Color.Black;
            this.PrinterPort_tEdit.ActiveAppearance = appearance8;
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColor = System.Drawing.Color.Black;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            this.PrinterPort_tEdit.Appearance = appearance9;
            this.PrinterPort_tEdit.AutoSelect = true;
            this.PrinterPort_tEdit.DataText = "";
            this.PrinterPort_tEdit.Enabled = false;
            this.PrinterPort_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PrinterPort_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 128, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PrinterPort_tEdit.Location = new System.Drawing.Point(140, 120);
            this.PrinterPort_tEdit.MaxLength = 128;
            this.PrinterPort_tEdit.Name = "PrinterPort_tEdit";
            this.PrinterPort_tEdit.Size = new System.Drawing.Size(469, 24);
            this.PrinterPort_tEdit.TabIndex = 2;
            // 
            // PrinterName_tComboEditor
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            this.PrinterName_tComboEditor.ActiveAppearance = appearance14;
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance15.ForeColor = System.Drawing.Color.Black;
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            this.PrinterName_tComboEditor.Appearance = appearance15;
            this.PrinterName_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrinterName_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PrinterName_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrinterName_tComboEditor.ItemAppearance = appearance16;
            this.PrinterName_tComboEditor.Location = new System.Drawing.Point(140, 85);
            this.PrinterName_tComboEditor.MaxDropDownItems = 18;
            this.PrinterName_tComboEditor.Name = "PrinterName_tComboEditor";
            this.PrinterName_tComboEditor.Size = new System.Drawing.Size(480, 24);
            this.PrinterName_tComboEditor.TabIndex = 1;
            this.PrinterName_tComboEditor.ValueChanged += new System.EventHandler(this.PrinterName_tComboEditor_ValueChanged);
            // 
            // PrinterMngNo_tNedit
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            appearance6.TextHAlignAsString = "Right";
            this.PrinterMngNo_tNedit.ActiveAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance7.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance7.ForeColor = System.Drawing.Color.Black;
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            appearance7.TextHAlignAsString = "Right";
            this.PrinterMngNo_tNedit.Appearance = appearance7;
            this.PrinterMngNo_tNedit.AutoSelect = true;
            this.PrinterMngNo_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrinterMngNo_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PrinterMngNo_tNedit.DataText = "";
            this.PrinterMngNo_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PrinterMngNo_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 4, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PrinterMngNo_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PrinterMngNo_tNedit.Location = new System.Drawing.Point(140, 50);
            this.PrinterMngNo_tNedit.MaxLength = 4;
            this.PrinterMngNo_tNedit.Name = "PrinterMngNo_tNedit";
            this.PrinterMngNo_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.PrinterMngNo_tNedit.Size = new System.Drawing.Size(43, 24);
            this.PrinterMngNo_tNedit.TabIndex = 0;
            // 
            // PrinterKind_Title_Label
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.PrinterKind_Title_Label.Appearance = appearance17;
            this.PrinterKind_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.PrinterKind_Title_Label.Location = new System.Drawing.Point(12, 155);
            this.PrinterKind_Title_Label.Name = "PrinterKind_Title_Label";
            this.PrinterKind_Title_Label.Size = new System.Drawing.Size(120, 24);
            this.PrinterKind_Title_Label.TabIndex = 13;
            this.PrinterKind_Title_Label.Text = "プリンタ種別";
            // 
            // PrinterKind_tComboEditor
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance10.ForeColor = System.Drawing.Color.Black;
            appearance10.ForeColorDisabled = System.Drawing.Color.Black;
            this.PrinterKind_tComboEditor.ActiveAppearance = appearance10;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance11.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance11.ForeColor = System.Drawing.Color.Black;
            appearance11.ForeColorDisabled = System.Drawing.Color.Black;
            this.PrinterKind_tComboEditor.Appearance = appearance11;
            this.PrinterKind_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrinterKind_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PrinterKind_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrinterKind_tComboEditor.ItemAppearance = appearance12;
            this.PrinterKind_tComboEditor.Location = new System.Drawing.Point(140, 155);
            this.PrinterKind_tComboEditor.MaxDropDownItems = 2;
            this.PrinterKind_tComboEditor.Name = "PrinterKind_tComboEditor";
            this.PrinterKind_tComboEditor.Size = new System.Drawing.Size(175, 24);
            this.PrinterKind_tComboEditor.TabIndex = 14;
            // 
            // SFCMN09200UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(652, 267);
            this.Controls.Add(this.PrinterKind_tComboEditor);
            this.Controls.Add(this.PrinterKind_Title_Label);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.PrinterMngNo_tNedit);
            this.Controls.Add(this.PrinterPort_tEdit);
            this.Controls.Add(this.PrinterName_tComboEditor);
            this.Controls.Add(this.PrinterPort_Title_Label);
            this.Controls.Add(this.PrinterName_Title_Label);
            this.Controls.Add(this.Guid_Label);
            this.Controls.Add(this.PrinterMngNo_Title_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Mode_Label);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFCMN09200UA";
            this.Text = "プリンタ設定";
            this.Load += new System.EventHandler(this.SFCMN09200UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFCMN09200UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFCMN09200UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrinterPort_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrinterName_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrinterMngNo_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrinterKind_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;

		#region Private Members
		private PrtManageAcs _prtManageAcs;
		private PrtManage _prevPrtManage;
		private bool _nextData;
		private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _prtManageTable;
		private PrtManage _prtManageClone;

		// プロパティ用
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
		private bool _canSpecificationSearch;

		// 2005.05.27 TOUMA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
		//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
		// 最小化判定用フラグ
		//2005.07.02 private bool _minFlg;
		private int _indexBuf;
		//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
		// 2005.05.27 TOUMA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        // モードフラグ(true：コード、false：コード以外)
        private bool _modeFlg = false;
        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END

		// FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
		private const string DELETE_DATE		= "削除日";
		private const string PRINTERMNGNO_TITLE	= "プリンタ管理No";
		private const string PRINTERNAME_TITLE	= "プリンタ名";
		private const string PRINTERPORT_TITLE	= "プリンタパス";
        private const string PRINTERKIND_TITLE = "プリンタ種別";
        // 2008.06.10 30413 犬飼 プリンタ種類の削除 >>>>>>START
		//private const string PRINTERKIND_TITLE	= "種類";
        // 2008.06.10 30413 犬飼 プリンタ種類の削除 <<<<<<END
		private const string GUID_TITLE			= "GUID";
		private const string PRTMANAGE_TABLE	= "PRTMANAGE";

		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";
		private const string DELETE_MODE = "削除モード";

        // ↓ 20070206 18322 a MA.NS用に変更
        /// <summary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        // ↑ 20070206 18322 a

		// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
		private const string PGID = "SFCMN9200U";
		// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
		#endregion

		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFCMN09200UA());
		}

		#region Property
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
		/// <value>件数指定抽出を可能とするかどうかの設定を取得します。</value>
		public bool CanSpecificationSearch
		{
			get{ return this._canSpecificationSearch; }
		}
		#endregion
 
		#region Public Methods
		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet">グリッドリッド用データセット</param>
		/// <param name="tableName">テーブル名称</param>
		/// <remarks>
		/// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = PRTMANAGE_TABLE;
		}

		/// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList prtManageList = null;

//			if (readCount == 0)
//			{
				// 現在の時刻を取得 【デバッグ用】
				//				DateTime t1 = DateTime.Now;

				// 抽出対象件数が0の場合は全件抽出を実行する
				status = this._prtManageAcs.SearchAll(
					out prtManageList,
					this._enterpriseCode);

				// 掛かった時間を表示 【デバッグ用】
				//				float ms = (float)DateTime.Now.Subtract(t1).TotalMilliseconds;
				//				ultraStatusBar1.Text = ms.ToString() + "㍉秒";

				this._totalCount = prtManageList.Count;
//			}
/*************************************************************************************************
			// 件数指定検索の機能を外す 2005.04.28 M.Ito
			else
			{
				status = this._prtManageAcs.SearchSpecificationAllPrtManage(
					out prtManageList,
					out this._totalCount,
					out this._nextData,
					this._enterpriseCode,
					readCount,
					this._prevPrtManage);
			}
 *************************************************************************************************/
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( prtManageList.Count > 0 ) {
						// 最終のプリンタ管理オブジェクトを退避する
						this._prevPrtManage = ((PrtManage)prtManageList[prtManageList.Count - 1]).Clone();
					}

					int index = 0;
					foreach(PrtManage prtManage in prtManageList)
					{
						PrtManageToDataSet(prtManage.Clone(), index);
						++index;
					}

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}
				default:
				{
					// 2005.07.06 柏原 排他制御対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					if(ExclusiveControl(status) == false)
					{
						break;
					}
					// 2005.07.06 柏原 排他制御対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					/* 2005.09.20
					MessageBox.Show(
						"読み込みに失敗しました。 st = " + status.ToString(),
						"エラー",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error,
						MessageBoxDefaultButton.Button1);
						2005.09.20 */
					TMsgDisp.Show(this,Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
						PGID, "プリンタ管理情報設定", "Search",TMsgDisp.OPE_READ,
						"読み込みに失敗しました。",status,
						"SFCMN09202A",MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
					// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					//2005.07.07 柏原 エラー発生時クローズ処理追加>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					CloseUI();
					//2005.07.07 柏原 エラー発生時クローズ処理追加>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
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
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int SearchNext(int readCount)
		{
			int dummy = 0;
			ArrayList prtManages = null;

			// 抽出対象件数が0の場合は、残りの全件を抽出
			if (readCount == 0)
			{
				readCount =	this._totalCount - this.Bind_DataSet.Tables[0].Rows.Count;
			}

			int status = this._prtManageAcs.SearchSpecificationAll(
				out prtManages,
				out dummy,
				out this._nextData, 
				this._enterpriseCode,
				readCount,
				this._prevPrtManage);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( prtManages.Count > 0 ) {
						// 最終のプリンタ管理クラスを退避する
						this._prevPrtManage = ((PrtManage)prtManages[prtManages.Count - 1]).Clone();
					}

					int index = 0;
					foreach(PrtManage prtManage in prtManages)
					{
						index = this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows.Count;
						PrtManageToDataSet(prtManage.Clone(), index);
					}

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}
				default:
				{
					// 2005.07.06 柏原 排他制御対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					if(ExclusiveControl(status) == false)
					{
						break;
					}
					// 2005.07.06 柏原 排他制御対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					/* 2005.09.20
					MessageBox.Show(
						"読み込みに失敗しました。 st = " + status.ToString(),
						"エラー",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error,
						MessageBoxDefaultButton.Button1);
					2005.09.20 */
					TMsgDisp.Show(this,Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
						PGID, "プリンタ管理情報設定", "SearchNext",TMsgDisp.OPE_READ,
						"読み込みに失敗しました。",status,
						"SFCMN09202A",MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
					// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					
					//2005.07.07 柏原 エラー発生時クローズ処理追加>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					CloseUI();
					//2005.07.07 柏原 エラー発生時クローズ処理追加>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					break;
				}
			}

			return status;
		}

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 選択中のデータを削除します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public int Delete()
		{
			Guid guid = (Guid)this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[this._dataIndex][GUID_TITLE];
			PrtManage prtManage = (PrtManage)this._prtManageTable[guid];

			int status = this._prtManageAcs.LogicalDelete(ref prtManage);
			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// 2005.07.06 柏原 排他制御対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				if(ExclusiveControl(status) == false)
				{
					return status;
				}
				// 2005.07.06 柏原 排他制御対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				
				// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				/* 2005.09.20
				    MessageBox.Show(
					"削除に失敗しました。 st = " + status.ToString(),
					"エラー",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1);
				2005.09.20 */
				TMsgDisp.Show(this,Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
					PGID, "プリンタ管理情報設定", "Delete",TMsgDisp.OPE_DELETE,
					"削除に失敗しました。",status,
					"SFCMN09202A",MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
				// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END

				//2005.07.07 柏原 エラー発生時クローズ処理追加>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				CloseUI();
				//2005.07.07 柏原 エラー発生時クローズ処理追加>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				return status;
			}

			status = this._prtManageAcs.Read(out prtManage, prtManage.EnterpriseCode, prtManage.PrinterMngNo);

			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// 2005.07.06 柏原 排他制御対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				if(ExclusiveControl(status) == false)
				{
					return status;
				}
				// 2005.07.06 柏原 排他制御対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				/* 2005.09.20
				MessageBox.Show(
					"読み込みに失敗しました。 st = " + status.ToString(),
					"エラー",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error,
					MessageBoxDefaultButton.Button1);
					2005.09.20 */
				TMsgDisp.Show(this,Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
					PGID, "プリンタ管理情報設定", "Delete",TMsgDisp.OPE_DELETE,
					"読み込みに失敗しました。",status,
					"SFCMN09202A",MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
				// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				//2005.07.07 柏原 エラー発生時クローズ処理追加>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				CloseUI();
				//2005.07.07 柏原 エラー発生時クローズ処理追加>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				return status;
			}

			PrtManageToDataSet(prtManage.Clone(), this._dataIndex);

			return status;
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を実行します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
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
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();

			appearanceTable.Add(DELETE_DATE, new GridColAppearance(MGridColDispType.DeletionDataBoth,ContentAlignment.MiddleLeft,"",Color.Red));
//			appearanceTable.Add(PRINTERMNGNO_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));	// 2005.06.09 TOUMA DEL フレームに表示する内容の表示位置を右詰めに変更
			appearanceTable.Add(PRINTERMNGNO_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleRight,"",Color.Black));	// 2005.06.09 TOUMA ADD フレームに表示する内容の表示位置を右詰めに変更
			appearanceTable.Add(PRINTERNAME_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(PRINTERPORT_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            appearanceTable.Add(PRINTERKIND_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            // 2008.06.10 30413 犬飼 プリンタ種類の削除 >>>>>>START
			//appearanceTable.Add(PRINTERKIND_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
            // 2008.06.10 30413 犬飼 プリンタ種類の削除 <<<<<<END
			appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleLeft,"",Color.Black));

			return appearanceTable;
		}
		#endregion

		#region Private Methods
		/// <summary>
		/// プリンタ管理オブジェクトデータセット展開処理
		/// </summary>
		/// <param name="prtManage">プリンタ管理オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
		/// <br>Note       : プリンタ管理クラスをデータセットに格納します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void PrtManageToDataSet(PrtManage prtManage, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[PRTMANAGE_TABLE].NewRow();
				this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows.Add(dataRow);

				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows.Count - 1;

				// ↓があると、
				// メインフレーム側で複数件数の抽出途中で子画面を呼び出すと
				// 選択した行でなく抽出最終行が呼び出される
				//this.DataIndex = index;
			}

			if (prtManage.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[index][DELETE_DATE] = "";
			}
			else
			{
				this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[index][DELETE_DATE] = prtManage.UpdateDateTimeJpInFormal;
			}

			this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[index][PRINTERMNGNO_TITLE] = prtManage.PrinterMngNo.ToString();
			this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[index][PRINTERNAME_TITLE]  = prtManage.PrinterName;
			this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[index][PRINTERPORT_TITLE]  = prtManage.PrinterPort;
            if (prtManage.PrinterKind == 0)
                this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[index][PRINTERKIND_TITLE] = "レーザープリンタ";
            else
                this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[index][PRINTERKIND_TITLE] = "ドットプリンタ";
            // 2008.06.10 30413 犬飼 プリンタ種類の削除 >>>>>>START
			//this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[index][PRINTERKIND_TITLE]  = prtManage.DefaultSvfCtlName;
            // 2008.06.10 30413 犬飼 プリンタ種類の削除 <<<<<<END
			this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[index][GUID_TITLE] = prtManage.FileHeaderGuid;
			//
			if (this._prtManageTable.ContainsKey(prtManage.FileHeaderGuid) == true)
			{
				this._prtManageTable.Remove(prtManage.FileHeaderGuid);
			}
			this._prtManageTable.Add(prtManage.FileHeaderGuid, prtManage);
		}

		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			DataTable prtManageTable = new DataTable(PRTMANAGE_TABLE);

			// Addを行う順番が、列の表示順位となります。
			prtManageTable.Columns.Add(DELETE_DATE, typeof(string));
            //2007.04.02  S.Koga  amend ------------------------------------------------------------------------
			//prtManageTable.Columns.Add(PRINTERMNGNO_TITLE, typeof(string));
            prtManageTable.Columns.Add(PRINTERMNGNO_TITLE, typeof(Int32));
            // -------------------------------------------------------------------------------------------------
			prtManageTable.Columns.Add(PRINTERNAME_TITLE, typeof(string));
			prtManageTable.Columns.Add(PRINTERPORT_TITLE, typeof(string));
            prtManageTable.Columns.Add(PRINTERKIND_TITLE, typeof(string));
            // 2008.06.10 30413 犬飼 プリンタ種類の削除 >>>>>>START
			//prtManageTable.Columns.Add(PRINTERKIND_TITLE, typeof(string));
            // 2008.06.10 30413 犬飼 プリンタ種類の削除 <<<<<<END
			prtManageTable.Columns.Add(GUID_TITLE, typeof(Guid));

			this.Bind_DataSet.Tables.Add(prtManageTable);
		}

		private System.Management.ManagementObjectSearcher _mos;
		private System.Management.ManagementObjectCollection _moc;
		private Hashtable _printerInfoTable = new Hashtable();

		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			this.PrinterName_tComboEditor.Items.Clear();
            this.PrinterKind_tComboEditor.Items.Clear();
			// プリンター情報をWIN32のクエリを使って取得
			_mos = new System.Management.ManagementObjectSearcher("Select * from Win32_Printer");
			_moc = _mos.Get();
		
			// プリンタを列挙する
			foreach(System.Management.ManagementObject mo in _moc)
			{
				// プリンタ情報一時格納用Hashtable
				Hashtable wkprt = new Hashtable();
		
				// 名称
                wkprt.Add("Name", mo["Name"]);
				// 状態
				wkprt.Add("Status",mo["Status"]);
				// ポート番号
				wkprt.Add("PortName",mo["PortName"]);
//				// キャプション
//				wkprt.Add("Caption",mo["Caption"]);
//				// ディスクリプション
//				wkprt.Add("Description",mo["Description"]);
//				// ドライバＩＤ
//				wkprt.Add("DeviceID",mo["DeviceID"]);
//				// ドライバ名称
//				wkprt.Add("DriverName",mo["DriverName"]);
//				// 場所
//				wkprt.Add("Location",mo["Location"]);
//				// プリンタ状態
//				wkprt.Add("PrinterState",mo["PrinterState"]);
//				// サーバー名称
//				wkprt.Add("SeverName",mo["ServerName"]);
//				// 共有名称
//				wkprt.Add("ShareName",mo["ShareName"]);
//				// 状態情報
//				wkprt.Add("StatusInfo",mo["StatusInfo"]);
		
				//
				_printerInfoTable.Add(mo["Name"],wkprt);
				// コンボボックスに追加
				PrinterName_tComboEditor.Items.Add(mo["Name"]);

                if (PrinterKind_tComboEditor.Items.Count == 0)
                {
                    // コンボボックスに追加
                    PrinterKind_tComboEditor.Items.Add("レーザープリンタ");
                    PrinterKind_tComboEditor.Items.Add("ドットプリンタ");
                    PrinterKind_tComboEditor.MaxDropDownItems = PrinterKind_tComboEditor.Items.Count;
                }
//				// デフォルトのプリンタか調べる
//				if ((((uint) mo["Attributes"]) & 4) == 4)
//				{
//					// コンボのTextにデフォルトのプリンタ名を表示
//					PrinterName_tComboEditor.Text = mo["Name"].ToString();
//				}
			}
			if (PrinterName_tComboEditor.Items.Count > 0)
				this.PrinterName_tComboEditor.MaxDropDownItems = PrinterName_tComboEditor.Items.Count;

            // 2008.06.10 30413 犬飼 プリンタ種類の削除 >>>>>>START
			// プリンタ種類
			//PrtManage prtManageTemp = new PrtManage();
			//this.PrinterKind_tComboEditor.Items.Clear();
			//foreach (string code in PrtManage.PrinterKindCodes)
			//	this.PrinterKind_tComboEditor.Items.Add(code, prtManageTemp.GetPrinterKindName(code));
			//if (PrinterKind_tComboEditor.Items.Count > 0)
			//	this.PrinterKind_tComboEditor.MaxDropDownItems = PrinterKind_tComboEditor.Items.Count;
            // 2008.06.10 30413 犬飼 プリンタ種類の削除 <<<<<<END

			// ボタンの位置を調整する
			// 終了ボタンの画面デザインの位置から計算する
			System.Drawing.Point buttonLocation = this.Cancel_Button.Location;
			buttonLocation.X -= this.Cancel_Button.Size.Width;
			this.Ok_Button.Location = buttonLocation;
			this.Revive_Button.Location = buttonLocation;
			buttonLocation.X -= this.Cancel_Button.Size.Width;
			this.Delete_Button.Location = buttonLocation;
		}

		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面をクリアします。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// <br>Update Note: 2005.06.24 22011 柏原 頼人</br>
		/// <br>			・tNEditのTextに直接値を代入しないよう変更</br>
		/// </remarks>
		private void ScreenClear()
		{
			this.Guid_Label.Text = "";	
			// 2005.06.24 柏原 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
			// 2005.06.24 this.PrinterMngNo_tNedit.Text = "";							
			this.PrinterMngNo_tNedit.SetInt(0);							
			// 2005.06.24 柏原 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
			this.PrinterName_tComboEditor.Text = "";
			this.PrinterPort_tEdit.Text = "";
            this.PrinterKind_tComboEditor.Text = "";
            // 2008.06.10 30413 犬飼 プリンタ種類の削除 >>>>>>START
			//this.PrinterKind_tComboEditor.Text = "";
            // 2008.06.10 30413 犬飼 プリンタ種類の削除 <<<<<<END
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			PrtManage prtManage;
			if (this._dataIndex < 0)
			{
				prtManage = new PrtManage();			
				// 登録モード
				this.Mode_Label.Text = INSERT_MODE;
				//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				//_dataIndexバッファ保持
				this._indexBuf = this._dataIndex;
				//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
			
				this.Ok_Button.Visible = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;

				this.PrinterMngNo_tNedit.Enabled = true;
				this.PrinterMngNo_tNedit.Focus();

				ScreenInputPermissionControl(true);

			}
			else
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[this._dataIndex][GUID_TITLE];
				prtManage = (PrtManage)this._prtManageTable[guid];
				PrtManageToScreen(prtManage);

				if (prtManage.LogicalDeleteCode == 0)
				{
					// 更新モード
					this.Mode_Label.Text = UPDATE_MODE;

					this.Ok_Button.Visible = true;
					this.Cancel_Button.Visible = true;
					this.Delete_Button.Visible = false;
					this.Revive_Button.Visible = false;

					ScreenInputPermissionControl(true);
					
					// 更新モードの場合は、プリンタ管理コードのみ入力不可とする
					this.PrinterMngNo_tNedit.Enabled = false;
					this.PrinterName_tComboEditor.Focus();
					//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					//_dataIndexバッファ保持
					this._indexBuf = this._dataIndex;
					//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
			
				}
				else
				{
					// 削除モード
					this.Mode_Label.Text = DELETE_MODE;

					this.Ok_Button.Visible = false;
					this.Cancel_Button.Visible = true;
					this.Delete_Button.Visible = true;
					this.Revive_Button.Visible = true;

					ScreenInputPermissionControl(false);
					//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					//_dataIndexバッファ保持
					this._indexBuf = this._dataIndex;
					//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					this.Delete_Button.Focus();
				}
			}
			// 新規の未入力状態をバックアップ
			this._prtManageClone = prtManage.Clone();
			DispToPrtManage(ref this._prtManageClone);
			//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
			//_dataIndexバッファ保持
			this._indexBuf = this._dataIndex;
			//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
		}

		/// <summary>
		/// 画面入力許可制御処理
		/// </summary>
		/// <param name="enabled">入力許可設定値</param>
		/// <remarks>
		/// <br>Note       : 画面の入力許可を制御します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void ScreenInputPermissionControl(bool enabled)
		{
			this.PrinterMngNo_tNedit.Enabled = enabled;
			this.PrinterName_tComboEditor.Enabled = enabled;

            this.PrinterKind_tComboEditor.Enabled = enabled;
//			this.PrinterPort_tEdit.Enabled = enabled;
            // 2008.06.10 30413 犬飼 プリンタ種類の削除 >>>>>>START
			//this.PrinterKind_tComboEditor.Enabled = enabled;
            // 2008.06.10 30413 犬飼 プリンタ種類の削除 <<<<<<END
		}

		/// <summary>
		/// プリンタ管理クラス画面展開処理
		/// </summary>
		/// <param name="prtManage">プリンタ管理オブジェクト</param>
		/// <remarks>
		/// <br>Note       : プリンタ管理オブジェクトから画面にデータを展開します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void PrtManageToScreen(PrtManage prtManage)
		{
			this.Guid_Label.Text = prtManage.FileHeaderGuid.ToString();
			this.PrinterMngNo_tNedit.SetInt( prtManage.PrinterMngNo );
            this.PrinterName_tComboEditor.Value = prtManage.PrinterName;
            if( prtManage.PrinterKind == 0)
            this.PrinterKind_tComboEditor.Value = "レーザープリンタ";
            else
                this.PrinterKind_tComboEditor.Value = "ドットプリンタ";
			this.PrinterPort_tEdit.Text = prtManage.PrinterPort;
            // 2008.06.10 30413 犬飼 プリンタ種類の削除 >>>>>>START
			//this.PrinterKind_tComboEditor.Value = prtManage.DefaultSvfCtlCode;
            // 2008.06.10 30413 犬飼 プリンタ種類の削除 <<<<<<END
		}

		/// <summary>
		/// 画面情報プリンタ管理クラス格納処理
		/// </summary>
		/// <param name="prtManage">プリンタ管理オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 画面情報からプリンタ管理オブジェクトにデータを格納します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void DispToPrtManage(ref PrtManage prtManage)
		{
			if (prtManage == null)
			{
				// 新規の場合
				prtManage = new PrtManage();
			}

			prtManage.EnterpriseCode		= this._enterpriseCode;								//企業コード				← 要変更
			prtManage.PrinterMngNo			= this.PrinterMngNo_tNedit.GetInt();				//プリンタ管理No
			prtManage.PrinterName			= this.PrinterName_tComboEditor.Text;				//プリンタ名
			prtManage.PrinterPort			= this.PrinterPort_tEdit.Text;						//プリンタポート（パス）
            if (this.PrinterKind_tComboEditor.Text == "レーザープリンタ")
                prtManage.PrinterKind = 0;
            else
                prtManage.PrinterKind = 1;
            // 2008.06.10 30413 犬飼 プリンタ種類の削除 >>>>>>START
			//if(this.PrinterKind_tComboEditor.SelectedIndex < 0)
			//{
			//	prtManage.DefaultSvfCtlCode = "";
			//	prtManage.ImgPrtSvfCtlCode  = "";
			//}
			//else
			//{
			//	prtManage.DefaultSvfCtlCode	= (string)this.PrinterKind_tComboEditor.SelectedItem.DataValue;	//SVF制御コード（デフォルト値）
			//	prtManage.ImgPrtSvfCtlCode	= (string)this.PrinterKind_tComboEditor.SelectedItem.DataValue;	//SVF制御コード（イメージ印刷）
			//}
			//prtManage.SvfCtlCodeUseCode		= 0;	//SVF制御コード使用区分 0:デフォルト,1:イメージ
            // 2008.06.10 30413 犬飼 プリンタ種類の削除 <<<<<<END
		}

		/// <summary>
		/// 画面入力情報不正チェック処理
		/// </summary>
		/// <param name="control">不正対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の不正チェックを行います。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private bool ScreenDataCheck(ref Control control, ref string message)
		{
			bool result = true;

			if (this.PrinterMngNo_tNedit.GetInt() == 0)
			{
				control = this.PrinterMngNo_tNedit;
				message = this.PrinterMngNo_Title_Label.Text + "を入力して下さい。";
				result = false;
			}
			else if (this.PrinterName_tComboEditor.Text.Trim() == "")
			{
				control = this.PrinterName_tComboEditor;
				message = this.PrinterName_Title_Label.Text + "を入力して下さい。";
				result = false;
			}
            else if (this.PrinterKind_tComboEditor.Text.Trim() == "")
            {
                control = this.PrinterKind_tComboEditor;
                message = this.PrinterKind_Title_Label.Text + "を入力して下さい。";
                result = false;
            }
            // 2008.06.10 30413 犬飼 プリンタ種類の削除 >>>>>>START
            //else if (this.PrinterKind_tComboEditor.SelectedIndex < 0)
            //{
            //	control = this.PrinterKind_tComboEditor;
            //	message = this.PrinterKind_Title_Label.Text + "を入力して下さい。";
            //	result = false;
            //}
            // 2008.06.10 30413 犬飼 プリンタ種類の削除 <<<<<<END
            else
            {
                // 重複チェック
                foreach (PrtManage prtManage in _prtManageTable.Values)
                {
                    if ((this.DataIndex < 0) ||
                       ((this.DataIndex >= 0) &&
                        (prtManage.FileHeaderGuid != (Guid)this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[this._dataIndex][GUID_TITLE])))
                    {
                        if (PrinterName_tComboEditor.SelectedItem.DisplayText == prtManage.PrinterName)
                        {
                            control = this.PrinterName_tComboEditor;
                            message = "同じプリンタは登録できません";
                            result = false;
                            break;
                        }
                    }
                }
            }

			return result;
		}

		/// <summary>
		/// プリンタ設定情報登録
		/// </summary>
		/// <param name="control">フォーカスセットコントロール(エラー時)</param>
		/// <returns>登録OK/登録NG</returns>
		private bool RegistData(out Control control)
		{
			control = null;

			// 入力チェック
			string message = null;
			if (!ScreenDataCheck(ref control, ref message))
			{
				// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				/*2005.09.20
				MessageBox.Show(message,		
					"入力チェック",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button1);
					2005.09.20*/
				TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
					PGID,message,0,MessageBoxButtons.OK);
				// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END

				control.Focus();
				return false;
			}
			PrtManage prtManage = null;
			if (this._dataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[this._dataIndex][GUID_TITLE];
				prtManage = ((PrtManage)this._prtManageTable[guid]).Clone();
			}

			DispToPrtManage(ref prtManage);

			int status = this._prtManageAcs.Write(ref prtManage);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					/* 2005.09.20
					MessageBox.Show(
						"このプリンタ管理コードは既に使用されています。",
						"情報",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information,
						MessageBoxDefaultButton.Button1);
					2005.09.20 */
					TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_INFO,
						PGID,"このプリンタ管理コードは既に使用されています。",status,MessageBoxButtons.OK);
					// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					control = this.PrinterMngNo_tNedit;
					control.Focus();
					return false;
				}
				default:
				{
					// 2005.07.06 柏原 排他制御対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					if(ExclusiveControl(status) == false)
					{
						return false;
					}
					// 2005.07.06 柏原 排他制御対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					/* 2005.09.20
					MessageBox.Show(
						"登録に失敗しました。 st = " + status.ToString(),
						"エラー",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error,
						MessageBoxDefaultButton.Button1);
					2005.09.20 */
					TMsgDisp.Show(this,Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
						PGID, "プリンタ管理情報設定", "RegistData",TMsgDisp.OPE_UPDATE,
						"読み込みに失敗しました。",status,
						"SFCMN09202A",MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
					// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END

					//2005.07.07 柏原 エラー発生時クローズ処理追加>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					CloseUI();
					//2005.07.07 柏原 エラー発生時クローズ処理追加>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					return false;
				}
			}

			PrtManageToDataSet(prtManage, this._dataIndex);

			return true;
		}

		/// <summary>
		/// 終了前編集中チェック
		/// </summary>
		/// <param name="control">登録チェックNG時のフォーカス移動先</param>
		/// <returns>true:終了可/false:終了不可</returns>
		/// <remarks>
		/// <br>Note       : 子画面終了時に編集中なら登録確認を行う</br>
		/// <br>Programmer : 99032 伊藤 美紀</br>
		/// <br>Date       : 2005.04.28</br>
		/// </remarks>
		private bool CheckEditingClose(out Control control)
		{
			control = null;
			bool closeOK = true;

			// 入力状態を取得
			PrtManage comparePrtManage = new PrtManage();
			comparePrtManage = this._prtManageClone.Clone();
			DispToPrtManage(ref comparePrtManage);
			// 入力状態を初期状態と比較
			if(this._prtManageClone.Equals(comparePrtManage) == false)
			{
				// 編集中
				// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				/* 2005.09.20
				switch (MessageBox.Show("編集中のデータが存在します\r\n\r\n登録してもよろしいですか？",
										"保存確認",
										MessageBoxButtons.YesNoCancel,
										MessageBoxIcon.Question))
				2005.09.20 */
				switch(TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_QUESTION,
					PGID,"編集中のデータが存在します\r\n\r\n登録してもよろしいですか？",0,MessageBoxButtons.YesNoCancel))
						// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				{
					case DialogResult.Yes:
					{
						// 登録する
						if(RegistData(out control) == false)   {closeOK = false;}

						if (UnDisplaying != null)
						{
							MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
							UnDisplaying(this, me);
						}

						break;
					}
					case DialogResult.Cancel:
					{
						// Closeキャンセル
						closeOK = false;

                        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
                        //this.Cancel_Button.Focus();
                        if (_modeFlg)
                        {
                            control = PrinterMngNo_tNedit;
                            _modeFlg = false;
                        }
                        else
                        {
                            this.Cancel_Button.Focus();
                        }
                        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END

						if (UnDisplaying != null)
						{
							MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
							UnDisplaying(this, me);
						}
						
						break;
					}
				}
			}
			return closeOK;
		}


		// 2005.07.06 柏原 排他制御対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
		/// <summary>
		///	排他制御処理
		/// </summary>
		/// <remarks>
		/// <br>Programmer		:	柏原 頼人</br>
		/// <br>Note            :   ＤＢに排他制御が掛かっていた際にメッセージを表示しUI画面を閉じる</br>
		/// <br>Date			:	2005.07.06</br>
		/// </remarks>
		private bool ExclusiveControl(int Status)
		{
			// 既に更新が掛かっていたとき
			if(Status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
			{
				// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				// 2005.09.20MessageBox.Show(
				// 2005.09.20	"既に他端末より更新されています",
				// 2005.09.20	"注意",
				// 2005.09.20	MessageBoxButtons.OK,
				// 2005.09.20	MessageBoxIcon.Exclamation,
				// 2005.09.20	MessageBoxDefaultButton.Button1);
				TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
					PGID, "既に他端末より更新されています", 0, MessageBoxButtons.OK);

				// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				CloseUI();	
				return false;
			}
			// 既に削除されていたとき
			if(Status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE)
			{
				// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				// 2005.09.20 MessageBox.Show(
				// 2005.09.20 	"既に他端末で削除されています",
				// 2005.09.20 	"注意",
				// 2005.09.20 	MessageBoxButtons.OK,
				// 2005.09.20 	MessageBoxIcon.Exclamation,
				// 2005.09.20 	MessageBoxDefaultButton.Button1);
				TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
					PGID, "既に他端末で削除されています", 0, MessageBoxButtons.OK);
				// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				CloseUI();
				return false;
			}
			return true;
		}

		// 2005.07.06 柏原 排他制御対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END

		//2005.07.07 柏原 エラー発生時クローズ処理追加>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
		/// <summary>
		///	UI画面終了処理
		/// </summary>
		/// <remarks>
		/// <br>Programmer		:	柏原 頼人</br>
		/// <br>Note            :   UI画面を閉じる</br>
		/// <br>Date			:	2005.07.06</br>
		/// </remarks>
		private void CloseUI()
		{
			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
		}
		//2005.07.07 柏原 エラー発生時クローズ処理追加>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END

		#endregion

		#region Events
		/// <summary>
		/// Form.Load イベント(SFCMN09200UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void SFCMN09200UA_Load(object sender, System.EventArgs e)
		{
            // ↓ 20070206 18322 a MA.NS用に変更
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
            // ↑ 20070206 18322 a

            // 元のカーソルを保持
			Cursor preCursor = Cursor.Current;
			// カーソルを砂時計にする
			Cursor.Current = Cursors.WaitCursor;

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

			// 画面初期設定処理
			ScreenInitialSetting();

			// カーソルを戻す
			Cursor.Current = preCursor;

		}

		/// <summary>
		/// Form.Closing イベント(SFCMN09200UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note　　　  : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void SFCMN09200UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// 2005.05.27 TOUMA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
			// 最小化判定フラグの初期化
			//2005.07.02 this._minFlg = false;
			this._indexBuf = -2;
			//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
			// 2005.05.27 TOUMA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// フォームの「×」をクリックされた場合の対応です。
			if (CanClose == false)
			{
				e.Cancel = true;

				this.Hide();
				return;
			}
		}

		/// <summary>
		/// Control.VisibleChanged イベント(SFCMN09200UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void SFCMN09200UA_VisibleChanged(object sender, System.EventArgs e)
		{
			// 自分自身が非表示になった場合は以下の処理をキャンセルする。
			if (this.Visible == false)
			{
				// メインフレームアクティブ化
				this.Owner.Activate();
				return;
			}
			
			// 自分自身が非表示になった場合、
			// またはターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}
			//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
			
			
			Initial_Timer.Enabled = true;
			ScreenClear();
		}

		/// <summary>
		/// Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 保存ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			Control control = null;

			if(RegistData(out control) == false)
			{
				return;
			}
/*************************************************************************************************
			string message = null;

			if (!ScreenDataCheck(ref control, ref message))
			{
				MessageBox.Show(
					message,
					"入力チェック",
					MessageBoxButtons.OK,
					MessageBoxIcon.Exclamation,
					MessageBoxDefaultButton.Button1);

				control.Focus();
				return;
			}

			PrtManage prtManage = null;
			if (this._dataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[this._dataIndex][GUID_TITLE];
				prtManage = (PrtManage)this._prtManageTable[guid];
			}

			DispToPrtManage(ref prtManage);

			int status = this._prtManageAcs.Write(ref prtManage);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					MessageBox.Show(
						"このプリンタ管理コードは既に使用されています。",
						"情報",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information,
						MessageBoxDefaultButton.Button1);
					this.PrinterMngNo_tNedit.Focus();
					return;
				}
				default:
				{
					MessageBox.Show(
						"登録に失敗しました。 st = " + status.ToString(),
						"エラー",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error,
						MessageBoxDefaultButton.Button1);
					return;
				}
			}

			PrtManageToDataSet(prtManage, this._dataIndex);
 *************************************************************************************************/

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}
			// 登録モードの場合は画面を終了せずに連続入力を可能とする
			if (this.Mode_Label.Text == INSERT_MODE)
			{
				this._dataIndex = -1;

				ScreenClear();
				this.PrinterMngNo_tNedit.Focus();
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

				// 2005.05.27 TOUMA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
				// 最小化判定フラグの初期化
				// 2005.07.02 this._minFlg = false;
				this._indexBuf = -2;
				//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				// 2005.05.27 TOUMA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			}
		}

		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			// 編集中なら登録確認を表示
			Control control;
			Control nowFocusd = this.ActiveControl;
			if(CheckEditingClose(out control) == false)   
			{
				if(control == null)   {nowFocusd.Focus();}
				else                  {control.Focus();}
				return;
			}
			
			// 2005.05.27 TOUMA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
			// 最小化判定フラグの初期化
			// 2005.07.02 this._minFlg = false;
			this._indexBuf = -2;
			//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
			// 2005.05.27 TOUMA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
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
		/// Control.Click イベント(Delete_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 完全削除ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
			/* 2005.09.20
			DialogResult result = MessageBox.Show(
				"データを削除します。" + "\r\n" + "よろしいですか？",
				"削除確認",
				MessageBoxButtons.OKCancel,
				MessageBoxIcon.Exclamation,
				MessageBoxDefaultButton.Button2);
			2005.09.20 */
			DialogResult result = TMsgDisp.Show(Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_EXCLAMATION,
				PGID,"データを削除します。" + "\r\n" + "よろしいですか？",0,MessageBoxButtons.OKCancel,
				MessageBoxDefaultButton.Button2);
			// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END

			if (result == DialogResult.OK)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[this._dataIndex][GUID_TITLE];
				PrtManage prtManage = (PrtManage)this._prtManageTable[guid];

				int status = this._prtManageAcs.Delete(prtManage);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[this._dataIndex].Delete();
						this._prtManageTable.Remove(guid);
						break;
					}
					default:
					{
						// 2005.07.06 柏原 排他制御対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
						if(ExclusiveControl(status) == false)
						{
							return;
						}
						// 2005.07.06 柏原 排他制御対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
						
						// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
						/* 2005.09.20
						MessageBox.Show(
							"削除に失敗しました。 st = " + status.ToString(),
							"エラー",
							MessageBoxButtons.OK,
							MessageBoxIcon.Error,
							MessageBoxDefaultButton.Button1);
						2005.09.20 */
						TMsgDisp.Show(this,Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
							PGID, "プリンタ管理情報設定", "Delete_Button_Click",TMsgDisp.OPE_DELETE,
							"削除に失敗しました。",status,
							"SFCMN09202A",MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
						// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END

						//2005.07.07 柏原 エラー発生時クローズ処理追加>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
						CloseUI();
						//2005.07.07 柏原 エラー発生時クローズ処理追加>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
						return;
					}
				}
			}
			else
			{
				// 2005.09.26 >>>>>>>>>>>>>>>>>>>>>>>>>>START
				Delete_Button.Focus();
				// 2005.09.26 >>>>>>>>>>>>>>>>>>>>>>>>>>>>END
				return;
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			// 2005.05.27 TOUMA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
			// 最小化判定フラグの初期化
			// 2005.07.02 this._minFlg = false;
			this._indexBuf = -2;
			//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
			// 2005.05.27 TOUMA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			this.DialogResult = DialogResult.OK;

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
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
			Guid guid = (Guid)this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[this._dataIndex][GUID_TITLE];
			PrtManage prtManage = (PrtManage)this._prtManageTable[guid];

			int status = this._prtManageAcs.Revival(ref prtManage);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					/* 2005.09.20
					MessageBox.Show(
						"既にデータが完全削除されています。" + status.ToString(),
						"情報",
						MessageBoxButtons.OK,
						MessageBoxIcon.Information,
						MessageBoxDefaultButton.Button1);
					2005.09.20 */
					TMsgDisp.Show(this,Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
						PGID, "プリンタ管理情報設定", "Revive_Button_Click",TMsgDisp.OPE_UPDATE,
						"既にデータが完全削除されています。",status,
						"SFCMN09202A",MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
					// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					break;
				}
				default:
				{
					// 2005.07.06 柏原 排他制御対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					if(ExclusiveControl(status) == false)
					{
						break;
					}
					// 2005.07.06 柏原 排他制御対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					/* 2005.09.20
					MessageBox.Show(
						"復活に失敗しました。 st = " + status.ToString(),
						"エラー",
						MessageBoxButtons.OK,
						MessageBoxIcon.Error,
						MessageBoxDefaultButton.Button1);
					2005.09.20 */
					TMsgDisp.Show(this,Broadleaf.Library.Windows.Forms.emErrorLevel.ERR_LEVEL_STOP,
						PGID, "プリンタ管理情報設定", "Revive_Button_Click",TMsgDisp.OPE_UPDATE,
						"復活に失敗しました。",status,
						"SFCMN09202A",MessageBoxButtons.OK,MessageBoxDefaultButton.Button1);
					// 2005.09.20 柏原 MsgDisp対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END

					//2005.07.07 柏原 エラー発生時クローズ処理追加>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
					CloseUI();
					//2005.07.07 柏原 エラー発生時クローズ処理追加>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
					break;
				}
			}

			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
			}

			PrtManageToDataSet(prtManage, this._dataIndex);

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			// 2005.05.27 TOUMA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>START
			// 最小化判定フラグの初期化
			// 2005.07.02 this._minFlg = false;
			this._indexBuf = -2;
			//2005.07.02 柏原 新フレーム最小化対応>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>END
			// 2005.05.27 TOUMA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			this.DialogResult = DialogResult.OK;

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
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}

		/// <summary>
		/// PrinterName_tComboEditor_ValueChanged イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : プリンタ名を選択した時、プリンタポートを表示します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void PrinterName_tComboEditor_ValueChanged(object sender, System.EventArgs e)
		{
			if(PrinterName_tComboEditor.Text == null)   return;      // 最小化→親フォーム最小化→親フォーム表示で Text=null で走ってしまうので

			Hashtable ht = (Hashtable)_printerInfoTable[PrinterName_tComboEditor.Text.Trim()];
			if (ht != null)
				PrinterPort_tEdit.Text = (string)ht["PortName"];
		}
		#endregion

        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
        /// <summary>
        /// ChanageFocus イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 >>>>>>START
            _modeFlg = false;
            // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END

            switch (e.PrevCtrl.Name)
            {
                case "PrinterMngNo_tNedit":
                    {
                        // プリンタ管理No.
                        if (e.NextCtrl.Name == "Cancel_Button")
                        {
                            // 遷移先が閉じるボタン
                            _modeFlg = true;
                        }
                        else if (this._dataIndex < 0)
                        {
                            if (ModeChangeProc())
                            {
                                e.NextCtrl = PrinterMngNo_tNedit;
                            }
                        }
                        break;
                    }
            }
        }
        
        /// <summary>
        /// モード変更処理
        /// </summary>
        private bool ModeChangeProc()
        {
            // プリンタ管理No.
            int printerMngNo = PrinterMngNo_tNedit.GetInt();

            for (int i = 0; i < this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows.Count; i++)
            {
                // データセットと比較
                int dsPrinterMngNo = (int)this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[i][PRINTERMNGNO_TITLE];
                if (printerMngNo == dsPrinterMngNo)
                {
                    // 入力コードがデータセットに存在する場合
                    if ((string)this.Bind_DataSet.Tables[PRTMANAGE_TABLE].Rows[i][DELETE_DATE] != "")
                    {
                        // 論理削除
                        TMsgDisp.Show(this, 					// 親ウィンドウフォーム
                          emErrorLevel.ERR_LEVEL_INFO,          // エラーレベル
                          PGID,						            // アセンブリＩＤまたはクラスＩＤ
                          "入力されたコードのプリンタ設定情報は既に削除されています。", 			// 表示するメッセージ
                          0, 									// ステータス値
                          MessageBoxButtons.OK);				// 表示するボタン
                        // プリンタ管理No.のクリア
                        PrinterMngNo_tNedit.Clear();
                        return true;
                    }

                    DialogResult res = TMsgDisp.Show(
                        this,                                   // 親ウィンドウフォーム
                        emErrorLevel.ERR_LEVEL_INFO,            // エラーレベル
                        PGID,                                   // アセンブリＩＤまたはクラスＩＤ
                        "入力されたコードのプリンタ設定情報が既に登録されています。\n編集を行いますか？",   // 表示するメッセージ
                        0,                                      // ステータス値
                        MessageBoxButtons.YesNo);               // 表示するボタン
                    switch (res)
                    {
                        case DialogResult.Yes:
                            {
                                // 画面再描画
                                this._dataIndex = i;
                                ScreenClear();
                                ScreenReconstruction();
                                break;
                            }
                        case DialogResult.No:
                            {
                                // プリンタ管理No.のクリア
                                PrinterMngNo_tNedit.Clear();
                                break;
                            }
                    }
                    return true;
                }
            }
            return false;
        }
        // 2009.03.24 30413 犬飼 新規モードからモード変更対応 <<<<<<END
	}
}
