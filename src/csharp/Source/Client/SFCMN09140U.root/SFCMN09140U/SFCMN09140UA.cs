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
	/// 帳票用紙設定情報入力フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 帳票用紙設定情報設定を行います。
	///					 IMasterMaintenanceMultiTypeを実装しています。</br>
	/// <br>Programmer : 97606 藤　江梨子</br>
	/// <br>Date       : 2005.03.22</br>
	/// <br></br>
	/// <br>Update Note: 2005.05.28 22025 當間 豊</br>
	/// <br>					・フレームの最小化対応</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.09 22024 寺坂　誉志</br>
	/// <br>					・Viewの「/ミリ」を「/10ミリ」に修正</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.09 22025 當間 豊</br>
	/// <br>					・フレームに表示する内容の表示位置を右詰めに変更</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.13 22025 當間 豊</br>
	/// <br>					・UI子画面各項目の左、右詰め最適化対応</br>
	/// <br>					・フレームグリッドの「プレビュー区分」の表示内容から、インデックスの番号を非表示</br>
	/// <br></br>
	/// <br>Update Note: 2005.06.18 22025 當間 豊</br>
	/// <br>					・ForeColorDisabledとBackColorDisabledの設定対応</br>
	/// <br>Update Note: 2005.07.05 23013 牧　将人</br>
	/// <br>					・フレームの最終最小化対応</br>
	/// <br>					・ArrowKeyControlのCatchMouseプロパティをTrueに設定</br>
	/// <br>Update Note: 2005.07.06 23013 牧 将人</br>
	/// <br>					・排他制御処理　排他がかかったとき、statusを表示しないよう修正</br>
	/// <br>Update Note: 2005.07.06 23013 牧 将人</br>
	/// <br>					・エラーが出た時MessageBoxのOKボタンを押下したとき、UI画面を閉じる処理</br>
	/// <br>Update Note: 2005.07.11 23013 牧 将人</br>
	/// <br>					・排他制御処理の中に最小化対応追加</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.03 23006 高橋 明子</br>
	/// <br>					・閉じるボタンへのフォーカスセット処理</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.08  23006 高橋 明子</br>
	/// <br>				    ・企業コード取得処理</br>
	/// <br></br>
	/// <br>Update Note : 2005.09.24  23006 高橋 明子</br>
	/// <br>				    ・TMsgDisp部品対応</br>
	/// <br></br>
	/// <br>Update Note : 2005.10.19  23006 高橋 明子</br>
	/// <br>				    ・UI子画面Hide時のOwner.Activate処理追加</br>
    /// <br></br> 
    /// <br>Update Note : 2006.07.31  23006 高橋 明子</br>
    /// <br>                    ・ブラッシュアップ対応</br>
    /// <br></br>
    /// <br>Update Note : 2006.08.30  23006 高橋 明子</br>
    /// <br>                    ・初回起動時印刷プレビュー有無区分名称が表示されるよう修正</br>
	/// <br></br>
	/// <br>			: 2007.02.06 18322 T.Kimura MA.NS用に変更</br>
	/// <br>			:                           ・画面スキン変更対応</br>
	/// </remarks>
	public class SFCMN09140UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		# region Private Members (Component)
		private Infragistics.Win.Misc.UltraLabel PrintPaperCode_Title_Label;
		private Infragistics.Win.Misc.UltraLabel PrintPaperTypeNm_Title_Label;
		private Infragistics.Win.Misc.UltraLabel PrintPaperRow_TitleLabel;
		private Infragistics.Win.Misc.UltraLabel PrintPaperCol_TitleLabel;
		private Infragistics.Win.Misc.UltraLabel PrtPreviewExistCode_TitleLabel;
		private Broadleaf.Library.Windows.Forms.TEdit PrintPaperTypeNm_tEdit;
		private Broadleaf.Library.Windows.Forms.TNedit PrintPaperCol_tNedit;
		private Broadleaf.Library.Windows.Forms.TComboEditor PrtPreviewExistCode_tComboEditor;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Infragistics.Win.Misc.UltraLabel Guid_Label;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private System.Data.DataSet Bind_DataSet;
		private Broadleaf.Library.Windows.Forms.TNedit PrintPaperCode_tNedit;
		private Broadleaf.Library.Windows.Forms.TNedit PrintPaperRow_tNedit;
		private System.ComponentModel.IContainer components;
		# endregion

		/// <summary>
		/// 帳票用紙設定情報入力フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 帳票用紙設定情報入力フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public SFCMN09140UA()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			// データセット列情報構築処理
			DataSetColumnConstruction();

			// プロパティ初期値設定
			this._canPrint	= false;
			this._canClose	= false;
			// TODO ログイン担当者を取得するして設定を切り替える？
			this._canNew	= false;
			this._canDelete = false;
			this._canLogicalDeleteDataExtraction = false;
			this._canClose = true;			// デフォルト:true固定
			this._defaultAutoFillToColumn = true;
			this._canSpecificationSearch = false;

			// 企業コードを取得する
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.08 TAKAHASHI ADD START
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.08 TAKAHASHI ADD END

			// 変数初期化
			this._dataIndex = -1;
			this._prtPaperStAcs = new PrtPaperStAcs();
			this._prevPrtPaperSt = null;
			this._nextData = false;
			this._totalCount = 0;
			this._prtPaperStTable = new Hashtable();

			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//_dataIndexバッファ（メインフレーム最小化対応）
			this._indexBuf = -2;
			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
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
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFCMN09140UA));
            this.PrintPaperCode_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PrintPaperTypeNm_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.PrintPaperRow_TitleLabel = new Infragistics.Win.Misc.UltraLabel();
            this.PrintPaperCol_TitleLabel = new Infragistics.Win.Misc.UltraLabel();
            this.PrtPreviewExistCode_TitleLabel = new Infragistics.Win.Misc.UltraLabel();
            this.PrintPaperTypeNm_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.PrintPaperCol_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PrtPreviewExistCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
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
            this.Guid_Label = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.PrintPaperCode_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.PrintPaperRow_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPaperTypeNm_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPaperCol_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrtPreviewExistCode_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPaperCode_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPaperRow_tNedit)).BeginInit();
            this.SuspendLayout();
            // 
            // PrintPaperCode_Title_Label
            // 
            appearance1.TextVAlignAsString = "Middle";
            this.PrintPaperCode_Title_Label.Appearance = appearance1;
            this.PrintPaperCode_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.PrintPaperCode_Title_Label.Location = new System.Drawing.Point(24, 35);
            this.PrintPaperCode_Title_Label.Name = "PrintPaperCode_Title_Label";
            this.PrintPaperCode_Title_Label.Size = new System.Drawing.Size(146, 24);
            this.PrintPaperCode_Title_Label.TabIndex = 0;
            this.PrintPaperCode_Title_Label.Text = "帳票用紙区分";
            // 
            // PrintPaperTypeNm_Title_Label
            // 
            appearance2.TextVAlignAsString = "Middle";
            this.PrintPaperTypeNm_Title_Label.Appearance = appearance2;
            this.PrintPaperTypeNm_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.PrintPaperTypeNm_Title_Label.Location = new System.Drawing.Point(24, 70);
            this.PrintPaperTypeNm_Title_Label.Name = "PrintPaperTypeNm_Title_Label";
            this.PrintPaperTypeNm_Title_Label.Size = new System.Drawing.Size(146, 24);
            this.PrintPaperTypeNm_Title_Label.TabIndex = 1;
            this.PrintPaperTypeNm_Title_Label.Text = "帳票用紙タイプ";
            // 
            // PrintPaperRow_TitleLabel
            // 
            appearance3.TextVAlignAsString = "Middle";
            this.PrintPaperRow_TitleLabel.Appearance = appearance3;
            this.PrintPaperRow_TitleLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.PrintPaperRow_TitleLabel.Location = new System.Drawing.Point(24, 105);
            this.PrintPaperRow_TitleLabel.Name = "PrintPaperRow_TitleLabel";
            this.PrintPaperRow_TitleLabel.Size = new System.Drawing.Size(146, 24);
            this.PrintPaperRow_TitleLabel.TabIndex = 2;
            this.PrintPaperRow_TitleLabel.Text = "帳票行位置";
            // 
            // PrintPaperCol_TitleLabel
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.PrintPaperCol_TitleLabel.Appearance = appearance4;
            this.PrintPaperCol_TitleLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.PrintPaperCol_TitleLabel.Location = new System.Drawing.Point(24, 140);
            this.PrintPaperCol_TitleLabel.Name = "PrintPaperCol_TitleLabel";
            this.PrintPaperCol_TitleLabel.Size = new System.Drawing.Size(146, 24);
            this.PrintPaperCol_TitleLabel.TabIndex = 3;
            this.PrintPaperCol_TitleLabel.Text = "帳票桁位置";
            // 
            // PrtPreviewExistCode_TitleLabel
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.PrtPreviewExistCode_TitleLabel.Appearance = appearance5;
            this.PrtPreviewExistCode_TitleLabel.BackColorInternal = System.Drawing.Color.Transparent;
            this.PrtPreviewExistCode_TitleLabel.Location = new System.Drawing.Point(24, 175);
            this.PrtPreviewExistCode_TitleLabel.Name = "PrtPreviewExistCode_TitleLabel";
            this.PrtPreviewExistCode_TitleLabel.Size = new System.Drawing.Size(146, 24);
            this.PrtPreviewExistCode_TitleLabel.TabIndex = 4;
            this.PrtPreviewExistCode_TitleLabel.Text = "プレビュー区分";
            // 
            // PrintPaperTypeNm_tEdit
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrintPaperTypeNm_tEdit.ActiveAppearance = appearance6;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance7.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance7.ForeColorDisabled = System.Drawing.Color.Black;
            this.PrintPaperTypeNm_tEdit.Appearance = appearance7;
            this.PrintPaperTypeNm_tEdit.AutoSelect = true;
            this.PrintPaperTypeNm_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrintPaperTypeNm_tEdit.DataText = "";
            this.PrintPaperTypeNm_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PrintPaperTypeNm_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 25, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.PrintPaperTypeNm_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.PrintPaperTypeNm_tEdit.Location = new System.Drawing.Point(180, 70);
            this.PrintPaperTypeNm_tEdit.MaxLength = 25;
            this.PrintPaperTypeNm_tEdit.Name = "PrintPaperTypeNm_tEdit";
            this.PrintPaperTypeNm_tEdit.Size = new System.Drawing.Size(407, 24);
            this.PrintPaperTypeNm_tEdit.TabIndex = 1;
            // 
            // PrintPaperCol_tNedit
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance8.TextHAlignAsString = "Right";
            appearance8.TextVAlignAsString = "Middle";
            this.PrintPaperCol_tNedit.ActiveAppearance = appearance8;
            appearance9.TextHAlignAsString = "Right";
            appearance9.TextVAlignAsString = "Middle";
            this.PrintPaperCol_tNedit.Appearance = appearance9;
            this.PrintPaperCol_tNedit.AutoSelect = true;
            this.PrintPaperCol_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PrintPaperCol_tNedit.DataText = "";
            this.PrintPaperCol_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PrintPaperCol_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.PrintPaperCol_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PrintPaperCol_tNedit.Location = new System.Drawing.Point(180, 140);
            this.PrintPaperCol_tNedit.MaxLength = 5;
            this.PrintPaperCol_tNedit.Name = "PrintPaperCol_tNedit";
            this.PrintPaperCol_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.PrintPaperCol_tNedit.Size = new System.Drawing.Size(52, 24);
            this.PrintPaperCol_tNedit.TabIndex = 3;
            // 
            // PrtPreviewExistCode_tComboEditor
            // 
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrtPreviewExistCode_tComboEditor.ActiveAppearance = appearance10;
            this.PrtPreviewExistCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.PrtPreviewExistCode_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.PrtPreviewExistCode_tComboEditor.ItemAppearance = appearance11;
            this.PrtPreviewExistCode_tComboEditor.Location = new System.Drawing.Point(180, 175);
            this.PrtPreviewExistCode_tComboEditor.Name = "PrtPreviewExistCode_tComboEditor";
            this.PrtPreviewExistCode_tComboEditor.Size = new System.Drawing.Size(120, 24);
            this.PrtPreviewExistCode_tComboEditor.TabIndex = 4;
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
            appearance12.ForeColor = System.Drawing.Color.White;
            appearance12.TextHAlignAsString = "Center";
            appearance12.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance12;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(515, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 14;
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
            // Guid_Label
            // 
            appearance19.TextVAlignAsString = "Middle";
            this.Guid_Label.Appearance = appearance19;
            this.Guid_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.Guid_Label.Location = new System.Drawing.Point(220, 35);
            this.Guid_Label.Name = "Guid_Label";
            this.Guid_Label.Size = new System.Drawing.Size(395, 24);
            this.Guid_Label.TabIndex = 16;
            this.Guid_Label.Visible = false;
            // 
            // ultraLabel1
            // 
            appearance18.TextVAlignAsString = "Middle";
            this.ultraLabel1.Appearance = appearance18;
            this.ultraLabel1.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel1.Location = new System.Drawing.Point(245, 105);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(85, 24);
            this.ultraLabel1.TabIndex = 17;
            this.ultraLabel1.Text = "/10ミリ";
            // 
            // ultraLabel2
            // 
            appearance17.TextVAlignAsString = "Middle";
            this.ultraLabel2.Appearance = appearance17;
            this.ultraLabel2.BackColorInternal = System.Drawing.Color.Transparent;
            this.ultraLabel2.Location = new System.Drawing.Point(245, 140);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(85, 24);
            this.ultraLabel2.TabIndex = 18;
            this.ultraLabel2.Text = "/10ミリ";
            // 
            // PrintPaperCode_tNedit
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance15.TextHAlignAsString = "Right";
            appearance15.TextVAlignAsString = "Middle";
            this.PrintPaperCode_tNedit.ActiveAppearance = appearance15;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance16.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance16.ForeColorDisabled = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.PrintPaperCode_tNedit.Appearance = appearance16;
            this.PrintPaperCode_tNedit.AutoSelect = true;
            this.PrintPaperCode_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.PrintPaperCode_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PrintPaperCode_tNedit.DataText = "";
            this.PrintPaperCode_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PrintPaperCode_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 2, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.PrintPaperCode_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PrintPaperCode_tNedit.Location = new System.Drawing.Point(180, 35);
            this.PrintPaperCode_tNedit.MaxLength = 2;
            this.PrintPaperCode_tNedit.Name = "PrintPaperCode_tNedit";
            this.PrintPaperCode_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, true, Broadleaf.Library.Windows.Forms.emZeroSupp.zsOFF);
            this.PrintPaperCode_tNedit.Size = new System.Drawing.Size(28, 24);
            this.PrintPaperCode_tNedit.TabIndex = 0;
            // 
            // PrintPaperRow_tNedit
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance13.TextHAlignAsString = "Right";
            appearance13.TextVAlignAsString = "Middle";
            this.PrintPaperRow_tNedit.ActiveAppearance = appearance13;
            appearance14.TextHAlignAsString = "Right";
            appearance14.TextVAlignAsString = "Middle";
            this.PrintPaperRow_tNedit.Appearance = appearance14;
            this.PrintPaperRow_tNedit.AutoSelect = true;
            this.PrintPaperRow_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.PrintPaperRow_tNedit.DataText = "";
            this.PrintPaperRow_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.PrintPaperRow_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 5, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.PrintPaperRow_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.PrintPaperRow_tNedit.Location = new System.Drawing.Point(180, 105);
            this.PrintPaperRow_tNedit.MaxLength = 5;
            this.PrintPaperRow_tNedit.Name = "PrintPaperRow_tNedit";
            this.PrintPaperRow_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.PrintPaperRow_tNedit.Size = new System.Drawing.Size(52, 24);
            this.PrintPaperRow_tNedit.TabIndex = 2;
            // 
            // SFCMN09140UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(632, 291);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.PrintPaperRow_tNedit);
            this.Controls.Add(this.PrintPaperCode_tNedit);
            this.Controls.Add(this.PrintPaperCol_tNedit);
            this.Controls.Add(this.PrintPaperTypeNm_tEdit);
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.ultraLabel1);
            this.Controls.Add(this.Guid_Label);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.PrtPreviewExistCode_tComboEditor);
            this.Controls.Add(this.PrtPreviewExistCode_TitleLabel);
            this.Controls.Add(this.PrintPaperCol_TitleLabel);
            this.Controls.Add(this.PrintPaperRow_TitleLabel);
            this.Controls.Add(this.PrintPaperTypeNm_Title_Label);
            this.Controls.Add(this.PrintPaperCode_Title_Label);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFCMN09140UA";
            this.Text = "帳票用紙設定";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VisibleChanged += new System.EventHandler(this.Form1_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.PrintPaperTypeNm_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPaperCol_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrtPreviewExistCode_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPaperCode_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPaperRow_tNedit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;


		private PrtPaperStAcs _prtPaperStAcs;
		private PrtPaperSt _prevPrtPaperSt;

		//比較用clone
		private PrtPaperSt _prtPaperStClone;
		
		private bool _nextData;
		private int _totalCount;
		private string _enterpriseCode;
		private Hashtable _prtPaperStTable;

        // ↓ 20070206 18322 a MA.NS用に変更 
        /// <ummary>画面デザイン変更クラス</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();
        // ↑ 20070206 18322 a

		// プロパティ用
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;
		private bool _canSpecificationSearch;

		// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
		//_dataIndexバッファ（メインフレーム最小化対応）
		private int _indexBuf;
		// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

		// FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
		private const string DELETE_DATE				= "削除日";
		private const string PRINTPAPERCODE_TITLE		= "帳票用紙区分";
		private const string PRINTPAPERTYPENM_TITLE		= "帳票用紙タイプ";
		private const string PRINTPAPERROW_TITLE		= "帳票行位置";
		private const string PRINTPAPERCOL_TITLE		= "帳票桁位置";
		private const string PRTPREVIEWEXISTCODE_TITLE	= "プレビュー区分";
		private const string GUID_TITLE					= "GUID";
		private const string PRTPAPERST_TABLE			= "PRTPAPERST";

		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";
		private const string DELETE_MODE = "削除モード";


		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFCMN09140UA());
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
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = PRTPAPERST_TABLE;
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
			ArrayList prtPaperStList = null;

			if (readCount == 0)
			{
				// 現在の時刻を取得 【デバッグ用】
				//				DateTime t1 = DateTime.Now;

				// 抽出対象件数が0の場合は全件抽出を実行する
				status = this._prtPaperStAcs.SearchAll(
					out prtPaperStList,
					this._enterpriseCode);

				// 掛かった時間を表示 【デバッグ用】
				//				float ms = (float)DateTime.Now.Subtract(t1).TotalMilliseconds;
				//				ultraStatusBar1.Text = ms.ToString() + "㍉秒";

				this._totalCount = prtPaperStList.Count;
			}
			else
			{
				status = this._prtPaperStAcs.SearchAll(
					out prtPaperStList,
					out this._totalCount,
					out this._nextData,
					this._enterpriseCode,
					readCount,
					this._prevPrtPaperSt);
			}

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( prtPaperStList.Count > 0 ) {
						// 最終の帳票用紙設定オブジェクトを退避する
						this._prevPrtPaperSt = ((PrtPaperSt)prtPaperStList[prtPaperStList.Count - 1]).Clone();
					}

					int index = 0;
					foreach(PrtPaperSt prtPaperSt in prtPaperStList)
					{
						PrtPaperStToDataSet(prtPaperSt.Clone(), index);
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
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
						"SFCMN09140U",							// アセンブリID
						"帳票用紙設定",                         // プログラム名称
						"Search",                               // 処理名称
						TMsgDisp.OPE_GET,                       // オペレーション
						"読み込みに失敗しました。",				// 表示するメッセージ
						status,									// ステータス値
						this._prtPaperStAcs,				    // エラーが発生したオブジェクト
						MessageBoxButtons.OK,					// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					// 2005.07.08 エラーが出た時MessageBoxのOKボタンを押下したとき、UI画面を閉じる処理 >>>>>>>>>> START
					this.Hide();
					// 2005.07.08 エラーが出た時MessageBoxのOKボタンを押下したとき、UI画面を閉じる処理 >>>>>>>>>> END
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
			ArrayList prtPaperSts = null;

			// 抽出対象件数が0の場合は、残りの全件を抽出
			if (readCount == 0)
			{
				readCount =	this._totalCount - this.Bind_DataSet.Tables[0].Rows.Count;
			}

			int status = this._prtPaperStAcs.SearchAll(
				out prtPaperSts,
				out dummy,
				out this._nextData, 
				this._enterpriseCode,
				readCount,
				this._prevPrtPaperSt);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( prtPaperSts.Count > 0 ) {
						// 最終の帳票用紙設定クラスを退避する
						this._prevPrtPaperSt = ((PrtPaperSt)prtPaperSts[prtPaperSts.Count - 1]).Clone();
					}

					int index = 0;
					foreach(PrtPaperSt prtPaperSt in prtPaperSts)
					{
						index = this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows.Count;
						PrtPaperStToDataSet(prtPaperSt.Clone(), index);
					}

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				{
					break;
				}
				default:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
						"SFCMN09140U",							// アセンブリID
						"帳票用紙設定",                         // プログラム名称
						"SearchNext",                           // 処理名称
						TMsgDisp.OPE_GET,                       // オペレーション
						"読み込みに失敗しました。",				// 表示するメッセージ
						status,									// ステータス値
						this._prtPaperStAcs,				    // エラーが発生したオブジェクト
						MessageBoxButtons.OK,					// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					// 2005.07.08 エラーが出た時MessageBoxのOKボタンを押下したとき、UI画面を閉じる処理 >>>>>>>>>> START
					this.Hide();
					// 2005.07.08 エラーが出た時MessageBoxのOKボタンを押下したとき、UI画面を閉じる処理 >>>>>>>>>> END
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
			Guid guid = (Guid)this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[this._dataIndex][GUID_TITLE];
			PrtPaperSt prtPaperSt = (PrtPaperSt)this._prtPaperStTable[guid];

			int status = this._prtPaperStAcs.LogicalDelete(ref prtPaperSt);
			// 2005.07.06 排他制御処理　排他がかかったとき、statusを表示しないよう修正 >>>>>>>>>>>>>>>>> START
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
					return status;
				}
				default:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
						"SFCMN09140U",							// アセンブリID
						"帳票用紙設定",                         // プログラム名称
						"Delete",                               // 処理名称
						TMsgDisp.OPE_HIDE,                      // オペレーション
						"削除に失敗しました。",				    // 表示するメッセージ
						status,									// ステータス値
						this._prtPaperStAcs,					// エラーが発生したオブジェクト
						MessageBoxButtons.OK,					// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					return status;
				}
			}
			// 2005.07.06 排他制御処理　排他がかかったとき、statusを表示しないよう修正 >>>>>>>>>>>>>>>>> END

			// 2005.07.06 Readは不要です
			//			status = this._prtPaperStAcs.Read(out prtPaperSt, prtPaperSt.EnterpriseCode, prtPaperSt.PrintPaperCode);
			// 2005.07.06 Readは不要です

			PrtPaperStToDataSet(prtPaperSt.Clone(), this._dataIndex);

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
//			appearanceTable.Add(PRINTPAPERCODE_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));			// 2005.06.09 TOUMA DEL フレームに表示する内容の表示位置を右詰めに変更
			appearanceTable.Add(PRINTPAPERCODE_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleRight,"",Color.Black));		// 2005.06.09 TOUMA ADD フレームに表示する内容の表示位置を右詰めに変更
			appearanceTable.Add(PRINTPAPERTYPENM_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
//			appearanceTable.Add(PRINTPAPERROW_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));			// 2005.06.09 TOUMA DEL フレームに表示する内容の表示位置を右詰めに変更
			appearanceTable.Add(PRINTPAPERROW_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleRight,"",Color.Black));			// 2005.06.09 TOUMA ADD フレームに表示する内容の表示位置を右詰めに変更
//			appearanceTable.Add(PRINTPAPERCOL_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));			// 2005.06.09 TOUMA DEL フレームに表示する内容の表示位置を右詰めに変更
			appearanceTable.Add(PRINTPAPERCOL_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleRight,"",Color.Black));			// 2005.06.09 TOUMA DEL フレームに表示する内容の表示位置を右詰めに変更
			appearanceTable.Add(PRTPREVIEWEXISTCODE_TITLE, new GridColAppearance(MGridColDispType.Both,ContentAlignment.MiddleLeft,"",Color.Black));
			appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None,ContentAlignment.MiddleLeft,"",Color.Black));

			return appearanceTable;
		}



		/// <summary>
		/// 帳票用紙設定オブジェクトデータセット展開処理
		/// </summary>
		/// <param name="prtPaperSt">帳票用紙設定オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
		/// <br>Note       : 帳票用紙設定クラスをデータセットに格納します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void PrtPaperStToDataSet(PrtPaperSt prtPaperSt, int index)
		{
			if ((index < 0) || (this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[PRTPAPERST_TABLE].NewRow();
				this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows.Add(dataRow);

				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows.Count - 1;

				// ↓があると、
				// メインフレーム側で複数件数の抽出途中で子画面を呼び出すと
				// 選択した行でなく抽出最終行が呼び出される
				//this.DataIndex = index;
			}

			if (prtPaperSt.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][DELETE_DATE] = "";
			}
			else
			{
				this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][DELETE_DATE] = prtPaperSt.UpdateDateTimeJpInFormal;
			}
			this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRINTPAPERCODE_TITLE] = prtPaperSt.PrintPaperCode.ToString();
			this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRINTPAPERTYPENM_TITLE] = prtPaperSt.PrintPaperTypeNm;
////////////////////////////////////////////// 2005.06.09 TERASAKA DEL STA //
//			this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRINTPAPERROW_TITLE] = System.String.Format("{0,5} /ミリ", prtPaperSt.PrintPaperRow);
//			this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRINTPAPERCOL_TITLE] = System.String.Format("{0,5} /ミリ", prtPaperSt.PrintPaperCol);
// 2005.06.09 TERASAKA DEL END //////////////////////////////////////////////
////////////////////////////////////////////// 2005.06.09 TERASAKA ADD STA //
			this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRINTPAPERROW_TITLE] = System.String.Format("{0,5} ／ 10ミリ", prtPaperSt.PrintPaperRow);
			this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRINTPAPERCOL_TITLE] = System.String.Format("{0,5} ／ 10ミリ", prtPaperSt.PrintPaperCol);
// 2005.06.09 TERASAKA ADD END //////////////////////////////////////////////
//			this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRTPREVIEWEXISTCODE_TITLE] = prtPaperSt.PrtPreviewExistCode.ToString() + " " + prtPaperSt.PrtPreviewExistName;	// 2005.06.13 TOUMA DEL インデックスの番号を非表示
            
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.30 TAKAHASHI DELETE START
            //this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRTPREVIEWEXISTCODE_TITLE] = prtPaperSt.PrtPreviewExistName;													// 2005.06.13 TOUMA ADD インデックスの番号を非表示
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.30 TAKAHASHI DELETE END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2006.08.30 TAKAHASHI ADD START
            if (prtPaperSt.PrtPreviewExistName != null)
            {
                this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRTPREVIEWEXISTCODE_TITLE] = prtPaperSt.PrtPreviewExistName;
            }
            else
            {
                if (prtPaperSt.PrtPreviewExistCode == 0)
                {
                    this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRTPREVIEWEXISTCODE_TITLE] = "無し";
                }
                else
                {
                    this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][PRTPREVIEWEXISTCODE_TITLE] = "有り";
                }
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2006.08.30 TAKAHASHI ADD END

			this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[index][GUID_TITLE] = prtPaperSt.FileHeaderGuid;
			//
			if (this._prtPaperStTable.ContainsKey(prtPaperSt.FileHeaderGuid) == true)
			{
				this._prtPaperStTable.Remove(prtPaperSt.FileHeaderGuid);
			}
			this._prtPaperStTable.Add(prtPaperSt.FileHeaderGuid, prtPaperSt);
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
			DataTable prtPaperStTable = new DataTable(PRTPAPERST_TABLE);

			// Addを行う順番が、列の表示順位となります。
			prtPaperStTable.Columns.Add(DELETE_DATE, typeof(string));
			prtPaperStTable.Columns.Add(PRINTPAPERCODE_TITLE, typeof(int));
			prtPaperStTable.Columns.Add(PRINTPAPERTYPENM_TITLE, typeof(string));
			prtPaperStTable.Columns.Add(PRINTPAPERROW_TITLE, typeof(string));
			prtPaperStTable.Columns.Add(PRINTPAPERCOL_TITLE, typeof(string));
			prtPaperStTable.Columns.Add(PRTPREVIEWEXISTCODE_TITLE, typeof(string));
			prtPaperStTable.Columns.Add(GUID_TITLE, typeof(Guid));

			this.Bind_DataSet.Tables.Add(prtPaperStTable);
		}

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
			// コンボボックスの初期化
			// 帳票用紙設定クラスにコードをセットして名称を取得
			PrtPaperSt prtPaperSt = new PrtPaperSt();
			
			// プリンタ種類
			PrtPreviewExistCode_tComboEditor.Items.Clear(); 
			foreach (int code in PrtPaperSt.PrtPreviewExistCodes)
			{
				prtPaperSt.PrtPreviewExistCode = code;
				PrtPreviewExistCode_tComboEditor.Items.Add(prtPaperSt.PrtPreviewExistCode, prtPaperSt.PrtPreviewExistName);
			}
			PrtPreviewExistCode_tComboEditor.MaxDropDownItems = PrtPreviewExistCode_tComboEditor.Items.Count;
						
//TODO これ↓何のためにやってるのかナゾ
//			this.Ok_Button.Location = new System.Drawing.Point(550, 375);
//			this.Cancel_Button.Location = new System.Drawing.Point(675, 375);
//			this.Delete_Button.Location = new System.Drawing.Point(300, 375);
//			this.Revive_Button.Location = new System.Drawing.Point(425, 375);
		}

		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面をクリアします。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void ScreenClear()
		{
			this.Guid_Label.Text = "";	
			this.PrintPaperCode_tNedit.Text = "";							
			this.PrintPaperTypeNm_tEdit.Text = "";
			this.PrintPaperRow_tNedit.SetInt(0);
			this.PrintPaperCol_tNedit.SetInt(0);
			this.PrtPreviewExistCode_tComboEditor.Value = 0;
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
			if (this._dataIndex < 0)
			{
				PrtPaperSt prtpaperst = new PrtPaperSt();
				//クローン作成
				this._prtPaperStClone = prtpaperst.Clone(); 
				DispToPrtPaperSt(ref this._prtPaperStClone);

				// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				//_dataIndexバッファ保持
				this._indexBuf = this._dataIndex;
				// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

				// 新規モード
				this.Mode_Label.Text = INSERT_MODE;

				this.Ok_Button.Visible = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;

				this.PrintPaperCode_tNedit.Enabled = true;
				this.PrintPaperCode_tNedit.Focus();

				ScreenInputPermissionControl(true);
			}
			else
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[this._dataIndex][GUID_TITLE];
				PrtPaperSt prtPaperSt = (PrtPaperSt)this._prtPaperStTable[guid];

				PrtPaperStToScreen(prtPaperSt);

				if (prtPaperSt.LogicalDeleteCode == 0)
				{
					// 更新モード
					this.Mode_Label.Text = UPDATE_MODE;

					this.Ok_Button.Visible = true;
					this.Cancel_Button.Visible = true;
					this.Delete_Button.Visible = false;
					this.Revive_Button.Visible = false;

					ScreenInputPermissionControl(true);

					// 更新モードの場合は、帳票用紙区分・帳票用紙タイプ名称を入力不可とする
					this.PrintPaperCode_tNedit.Focus();
					this.PrintPaperCode_tNedit.Enabled = false;
					this.PrintPaperTypeNm_tEdit.Enabled = false;
					this.PrintPaperRow_tNedit.Focus();
					this.PrintPaperRow_tNedit.SelectAll();

					//クローン作成
					this._prtPaperStClone = prtPaperSt.Clone();  
					//画面情報を比較用クローンにコピーする　　　　　   
					DispToPrtPaperSt(ref this._prtPaperStClone);
					// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					//_dataIndexバッファ保持
					this._indexBuf = this._dataIndex;
					// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
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

					this.Delete_Button.Focus();

					// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					//_dataIndexバッファ保持
					this._indexBuf = this._dataIndex;
					// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
				}
			}

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
			this.PrintPaperCode_tNedit.Enabled = enabled;
			this.PrintPaperTypeNm_tEdit.Enabled = enabled;
			this.PrintPaperRow_tNedit.Enabled = enabled;
			this.PrintPaperCol_tNedit.Enabled = enabled;
			this.PrtPreviewExistCode_tComboEditor.Enabled = enabled;
		}

		/// <summary>
		/// 帳票用紙設定クラス画面展開処理
		/// </summary>
		/// <param name="prtPaperSt">帳票用紙設定オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 帳票用紙設定オブジェクトから画面にデータを展開します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void PrtPaperStToScreen(PrtPaperSt prtPaperSt)
		{
			this.Guid_Label.Text = prtPaperSt.FileHeaderGuid.ToString();
			this.PrintPaperCode_tNedit.SetInt( prtPaperSt.PrintPaperCode );
			this.PrintPaperTypeNm_tEdit.Text = prtPaperSt.PrintPaperTypeNm;
			this.PrintPaperRow_tNedit.SetInt(prtPaperSt.PrintPaperRow);
			this.PrintPaperCol_tNedit.SetInt(prtPaperSt.PrintPaperCol);
			this.PrtPreviewExistCode_tComboEditor.Value = prtPaperSt.PrtPreviewExistCode;
		}

		/// <summary>
		/// 画面情報帳票用紙設定クラス格納処理
		/// </summary>
		/// <param name="prtPaperSt">帳票用紙設定オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 画面情報から帳票用紙設定オブジェクトにデータを格納します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void DispToPrtPaperSt(ref PrtPaperSt prtPaperSt)
		{
			if (prtPaperSt == null)
			{
				// 新規の場合
				prtPaperSt = new PrtPaperSt();
			}

			prtPaperSt.EnterpriseCode		= this._enterpriseCode;								//企業コード	
			prtPaperSt.PrintPaperCode		= this.PrintPaperCode_tNedit.GetInt();				//帳票用紙区分
			prtPaperSt.PrintPaperTypeNm		= this.PrintPaperTypeNm_tEdit.Text;					//帳票用紙タイプ名称
			prtPaperSt.PrintPaperRow		= this.PrintPaperRow_tNedit.GetInt();				//帳票行位置
			prtPaperSt.PrintPaperCol		= this.PrintPaperCol_tNedit.GetInt();				//帳票桁位置
			prtPaperSt.PrtPreviewExistCode	= (int)this.PrtPreviewExistCode_tComboEditor.SelectedItem.DataValue;	//プレビュー区分
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

			if (this.PrintPaperCode_tNedit.GetInt() == 0)
			{
				control = this.PrintPaperCode_tNedit;
				message = this.PrintPaperCode_Title_Label.Text + "を入力して下さい。";
				result = false;
			}
			else if (this.PrintPaperTypeNm_tEdit.Text.Trim() == "")
			{
				control = this.PrintPaperTypeNm_tEdit;
				message = this.PrintPaperTypeNm_Title_Label.Text + "を入力して下さい。";
				result = false;
			}

			return result;
		}

		/// <summary>
		/// 帳票用紙設定登録処理
		/// </summary>
		/// <returns>登録結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 帳票用紙設定登録を行います。</br>
		/// <br>Programmer : 22033　三崎  貴史</br>
		/// <br>Date       : 2005.04.30</br>
		/// </remarks>
		private bool SavePrtPaperSt()
		{
			Control control = null;
			string message = null;

			if (!ScreenDataCheck(ref control, ref message))
			{
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
				TMsgDisp.Show(this,                         // 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
					"SFCMN09140U",							// アセンブリID
					message,	                            // 表示するメッセージ
					0,   									// ステータス値
					MessageBoxButtons.OK);					// 表示するボタン
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

				control.Focus();
				if(control is TEdit)  {((TEdit)control).SelectAll();}
				return false;
			}

			PrtPaperSt prtPaperSt = null;
			if (this._dataIndex >= 0)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[this._dataIndex][GUID_TITLE];
				prtPaperSt = ((PrtPaperSt)this._prtPaperStTable[guid]).Clone();
			}

			DispToPrtPaperSt(ref prtPaperSt);

			// TODO ここで書き込みなんだけど・・・
			int status = this._prtPaperStAcs.Write(ref prtPaperSt);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                                     // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_INFO,                        // エラーレベル
						"SFCMN09140U",							            // アセンブリID
						"この帳票用紙設定コードは既に使用されています。",	// 表示するメッセージ
						status,									            // ステータス値
						MessageBoxButtons.OK);					            // 表示するボタン
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					return false;
				}
				// 2005.07.06 排他制御処理　排他がかかったとき、statusを表示しないよう修正 >>>>>>>>>>>>>>>>> START
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// 排他処理
					ExclusiveTransaction(status);
					
					// 2005.07.11 排他制御処理の中に最小化対応追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._indexBuf = -2;
					// 2005.07.11 排他制御処理の中に最小化対応追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

					// 2005.07.06 エラーが出た時MessageBoxのOKボタンを押下したとき、UI画面を閉じる処理 >>>>>>>>>>>>>>>>>>>>>>>> START
					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					// 2005.07.06 エラーが出た時MessageBoxのOKボタンを押下したとき、UI画面を閉じる処理 >>>>>>>>>>>>>>>>>>>>>>>> END
					
					return false;
				}
				// 2005.07.06 排他制御処理　排他がかかったとき、statusを表示しないよう修正 >>>>>>>>>>>>>>>>> END
				default:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
						"SFCMN09140U",							// アセンブリID
						"帳票用紙設定",     // プログラム名称
						"SavePrtPaperSt",                               // 処理名称
						TMsgDisp.OPE_UPDATE,                       // オペレーション
						"登録に失敗しました。",				// 表示するメッセージ
						status,									// ステータス値
						this._prtPaperStAcs,					// エラーが発生したオブジェクト
						MessageBoxButtons.OK,					// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					// 2005.07.11 排他制御処理の中に最小化対応追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					if (UnDisplaying != null)
					{
						MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
						UnDisplaying(this, me);
					}

					this.DialogResult = DialogResult.Cancel;
					this._indexBuf = -2;
					// 2005.07.11 排他制御処理の中に最小化対応追加 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

					// 2005.07.06 エラーが出た時MessageBoxのOKボタンを押下したとき、UI画面を閉じる処理 >>>>>>>>>>>>>>>>>>>>>>>> START
					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					// 2005.07.06 エラーが出た時MessageBoxのOKボタンを押下したとき、UI画面を閉じる処理 >>>>>>>>>>>>>>>>>>>>>>>> END

					return false;
				}
			}

			PrtPaperStToDataSet(prtPaperSt, this._dataIndex);

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
				this.PrintPaperCode_tNedit.Focus();
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

				// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				//_dataIndexバッファ保持
				this._indexBuf = -2;
				// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

			}

			return true;
		}

		/// <summary>
		/// 排他処理
		/// </summary>
		/// <param name="status">ステータス</param>
		/// <remarks>
		/// <br>Note       : データ更新時の排他処理を行います。</br>
		/// <br>Programmer : 23013  牧　将人</br>
		/// <br>Date       : 2005.07.11</br>
		/// </remarks>
		private void ExclusiveTransaction(int status)
		{
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
						"SFCMN09140U",							// アセンブリID
						"既に他端末より更新されています。",	    // 表示するメッセージ
						status,									// ステータス値
						MessageBoxButtons.OK);					// 表示するボタン
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
						"SFCMN09140U",							// アセンブリID
						"既に他端末より削除されています。",	    // 表示するメッセージ
						status,									// ステータス値
						MessageBoxButtons.OK);					// 表示するボタン
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					break;
				}
			}
		}

		/// <summary>
		/// Form.Load イベント(SFCMN09140UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void Form1_Load(object sender, System.EventArgs e)
		{
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList24 = IconResourceManagement.ImageList24;

            // ↓ 20070206 18322 c MA.NS用に変更
            // 画面スキンファイルの読込(デフォルトスキン指定)
            this._controlScreenSkin.LoadSkin();

            // 画面スキン変更
            this._controlScreenSkin.SettingScreenSkin(this);
            // ↑ 20070206 18322 c

			this.Ok_Button.ImageList     = imageList24;
			this.Cancel_Button.ImageList = imageList24;
			this.Revive_Button.ImageList = imageList24;
			this.Delete_Button.ImageList = imageList24;

			this.Ok_Button.Appearance.Image     = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;

			ScreenInitialSetting();		
		}

		/// <summary>
		/// Form.Closing イベント(SFCMN02000UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note　　　  : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//_dataIndexバッファ保持
			this._indexBuf = -2;
			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
	
			// フォームの「×」をクリックされた場合の対応です。
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

		/// <summary>
		/// Control.VisibleChanged イベント(SFCMN02000UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
		/// <br>Programmer : 97606 藤　江梨子</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		private void Form1_VisibleChanged(object sender, System.EventArgs e)
		{
			// 自分自身が非表示になった場合は以下の処理をキャンセルする。
			if (this.Visible == false)
			{
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.10.18 TAKAHASHI ADD START
				// メインフレームアクティブ化
				this.Owner.Activate();
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.10.18 TAKAHASHI ADD END

				return;
			}

			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// 自分自身が非表示になった場合、
			// またはターゲットレコード(Index)が変わっていない場合は以下の処理をキャンセルする
			if (this._indexBuf == this._dataIndex)
			{
				return;
			}
			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END
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
			SavePrtPaperSt();
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
			//保存確認
			PrtPaperSt comparePrtPaperSt = new PrtPaperSt();
			comparePrtPaperSt = this._prtPaperStClone.Clone();  
			//現在の画面情報を取得する
			DispToPrtPaperSt(ref comparePrtPaperSt);
			//最初に取得した画面情報と比較
			if (!(this._prtPaperStClone.Equals(comparePrtPaperSt)))	
			{
				//画面情報が変更されていた場合は、保存確認メッセージを表示する
				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
				DialogResult res = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_SAVECONFIRM,                   // エラーレベル
					"SFCMN09140U", 			                              // アセンブリＩＤまたはクラスＩＤ
					null, 					                              // 表示するメッセージ
					0, 					                                  // ステータス値
					MessageBoxButtons.YesNoCancel);	                      // 表示するボタン
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

				switch(res)
				{
					case DialogResult.Yes:
					{
						// 保険会社名称登録処理
						if(!SavePrtPaperSt()) 
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
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.03 TAKAHASHI ADD START
						this.Cancel_Button.Focus();
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.03 TAKAHASHI ADD END

						return;
					}
				}
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.Cancel);
				UnDisplaying(this, me);
			}

			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//_dataIndexバッファ保持
			this._indexBuf = -2;
			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

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
			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
			DialogResult result = TMsgDisp.Show(this,                    // 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_EXCLAMATION,                      // エラーレベル
				"SFCMN09140U", 					                         // アセンブリＩＤまたはクラスＩＤ
				"データを削除します。" + "\r\n" + 
				"よろしいですか？", 				                     // 表示するメッセージ
				0, 						                                 // ステータス値
				MessageBoxButtons.OKCancel,                              // 表示するボタン
				MessageBoxDefaultButton.Button2);                        // 初期表示ボタン
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

			if (result == DialogResult.OK)
			{
				Guid guid = (Guid)this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[this._dataIndex][GUID_TITLE];
				PrtPaperSt prtPaperSt = (PrtPaperSt)this._prtPaperStTable[guid];

				int status = this._prtPaperStAcs.Delete(prtPaperSt);
				switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						break;
					}
					default:
					{
						// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
						TMsgDisp.Show(this,                         // 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
							"SFCMN09140U",							// アセンブリID
							"帳票用紙設定",                         // プログラム名称
							"Delete_Button_Click",                  // 処理名称
							TMsgDisp.OPE_DELETE,                    // オペレーション
							"削除に失敗しました。",				    // 表示するメッセージ
							status,									// ステータス値
							this._prtPaperStAcs,					// エラーが発生したオブジェクト
							MessageBoxButtons.OK,					// 表示するボタン
							MessageBoxDefaultButton.Button1);		// 初期表示ボタン
						// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

						// 2005.07.08 エラーが出た時MessageBoxのOKボタンを押下したとき、UI画面を閉じる処理 >>>>>>>>>> START
						this.Hide();
						// 2005.07.08 エラーが出た時MessageBoxのOKボタンを押下したとき、UI画面を閉じる処理 >>>>>>>>>> END
						return;
					}
				}
			}
			else
			{
				return;
			}

			this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[this._dataIndex].Delete();

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//_dataIndexバッファ保持
			this._indexBuf = -2;
			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

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
			Guid guid = (Guid)this.Bind_DataSet.Tables[PRTPAPERST_TABLE].Rows[this._dataIndex][GUID_TITLE];
			PrtPaperSt prtPaperSt = (PrtPaperSt)this._prtPaperStTable[guid];

			int status = this._prtPaperStAcs.Revival(ref prtPaperSt);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION,     // エラーレベル
						"SFCMN09140U",							// アセンブリID
						"既にデータが完全削除されています。",	// 表示するメッセージ
						status,									// ステータス値
						MessageBoxButtons.OK);					// 表示するボタン
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					// 2005.07.08 エラーが出た時MessageBoxのOKボタンを押下したとき、UI画面を閉じる処理 >>>>>>>>>> START
					this.Hide();
					// 2005.07.08 エラーが出た時MessageBoxのOKボタンを押下したとき、UI画面を閉じる処理 >>>>>>>>>> END
					break;
				}
				default:
				{
					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.09.24 TAKAHASHI ADD START
					TMsgDisp.Show(this,                         // 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP,			// エラーレベル
						"SFCMN09140U",							// アセンブリID
						"帳票用紙設定",                         // プログラム名称
						"Revive_Button_Click",                  // 処理名称
						TMsgDisp.OPE_UPDATE,                    // オペレーション
						"復活に失敗しました。",				    // 表示するメッセージ
						status,									// ステータス値
						this._prtPaperStAcs,					// エラーが発生したオブジェクト
						MessageBoxButtons.OK,					// 表示するボタン
						MessageBoxDefaultButton.Button1);		// 初期表示ボタン
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.09.24 TAKAHASHI ADD END

					// 2005.07.08 エラーが出た時MessageBoxのOKボタンを押下したとき、UI画面を閉じる処理 >>>>>>>>>> START
					this.Hide();
					// 2005.07.08 エラーが出た時MessageBoxのOKボタンを押下したとき、UI画面を閉じる処理 >>>>>>>>>> END
					break;
				}
			}

			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
			}

			PrtPaperStToDataSet(prtPaperSt, this._dataIndex);

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//_dataIndexバッファ保持
			this._indexBuf = -2;
			// 2005.07.05 フレームの最終最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> END

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
	}
}
