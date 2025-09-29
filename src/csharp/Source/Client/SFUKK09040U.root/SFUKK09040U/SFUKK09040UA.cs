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
	/// 金額種別入力フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 金額種別設定を行います。
	///					 IMasterMaintenanceMultiTypeを実装しています。</br>
	/// <br>Programmer : 97134　元村 雅博</br>
	/// <br>Date       : 2005.06.24</br>
	/// <br></br>
	/// <br>Update Note: 2005.05.28 22025 當間 豊</br>
	/// <br>					・フレームの最小化対応</br>
	/// <br>Update Note: 2005.06.10 23001 秋山　亮介</br>
	/// <br>					・View画面の数値項目を右詰に変更</br>
	/// <br>Update Note: 2005.06.13 22025 當間 豊</br>
	/// <br>					・UI子画面各項目の左、右詰め最適化対応</br>
	/// <br>Update Note: 2005.09.02 22021 谷藤　範幸</br> 
	/// <br>					・保存確認後のエンターキー押下時のフォーカス対応</br>
	/// <br>Update Note: 2005.09.08 22021 谷藤　範幸</br>
	/// <br>					・ログイン情報取得部品の組込み</br>
	/// <br>Update Note: 2005.09.22 22021 谷藤　範幸</br>
	/// <br>					・メッセージ表示の変更</br>
	/// <br>Update Note: 2005.09.26 22021 谷藤　範幸</br>
	/// <br>					・完全削除ボタンでのキャンセル選択後のフォーカスの追加</br>
	/// <br>Update Note: 2005.10.19 22021 谷藤　範幸</br>
	/// <br>		   :        ・UI子画面Hide時のOwner.Activate処理追加</br>
	/// <br>Update Note: 2005.12.17 23003 榎田　まさみ</br>
    /// <br>		   :        ・ユーザ分のみ読込・編集するよう修正</br>	
    /// <br>Update Note: 2006.12.26 22022 段上 知子</br>
    /// <br>					1.SF版を流用し携帯版を作成</br>
	/// <br>Update Note: 2008.02.18 30167 上野　弘貴</br>
	/// <br>					1.レジ管理区分は不要なので非表示にする</br>
    /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
    /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
    /// <br>Programmer : 2008/06/12 30415 柴田 倫幸</br>
    /// <br>                    項目削除の為、修正</br>
    /// </remarks>
	public class SFUKK09040UA : System.Windows.Forms.Form, IMasterMaintenanceMultiType
	{
		# region Private Members (Component)

		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private System.Windows.Forms.Timer Initial_Timer;
		private System.Data.DataSet Bind_DataSet;
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.Misc.UltraButton Delete_Button;
		private Infragistics.Win.Misc.UltraButton Revive_Button;
        private Broadleaf.Library.Windows.Forms.TNedit MnyKindCord_tNedit;
        private Broadleaf.Library.Windows.Forms.TEdit MnyKindName_tEdit;
        private Infragistics.Win.Misc.UltraLabel MnyKindDivCd_Title_Label;
        private Broadleaf.Library.Windows.Forms.TComboEditor MnyKindDivCd_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel MnyKindCord_Title_Label;
        private Infragistics.Win.Misc.UltraLabel MnyKindName_Title_Label;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// 金額種別情報入力フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 金額種別情報入力フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 97134　元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public SFUKK09040UA()
		{
			InitializeComponent();

			// データセット列情報構築処理
			DataSetColumnConstruction();

			// プロパティ初期値設定
			this._canPrint = false;
			this._canNew = false;                           // MOD 2008/09/19 不具合対応[5433] true→false
            this._canDelete = false;                        // MOD 2008/09/19 不具合対応[5433] true→false
			this._canClose = true;		                    // デフォルト:true固定
			this._canLogicalDeleteDataExtraction = false;   // MOD 2008/09/22 不具合対応[5630] true→false
			this._canSpecificationSearch = false;
			this._defaultAutoFillToColumn = true;

			//　企業コードを取得する
			// 2005.09.08 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//			this._enterpriseCode = "TBS1";	// ← 要変更
			// 2005.09.08 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// 2005.09.08 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// 2005.09.08 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// 変数初期化
			this._dataIndex = -1;
			this._nextData = false;
			this._totalCount = 0;

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005 07.07 H.NAKAMURA Insert Start
			//_dataIndexバッファ（メインフレーム最小化対応）
			this._indexBuffer = -2;
			//2005 07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            this._mnykindAcs    = new MoneyKindAcs();
            this._prevMoneyKind = null;
            this._mnykindTable  = new Hashtable();
            this._mnykindDivTbl = new Hashtable();
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
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKK09040UA));
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.Bind_DataSet = new System.Data.DataSet();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.Delete_Button = new Infragistics.Win.Misc.UltraButton();
            this.Revive_Button = new Infragistics.Win.Misc.UltraButton();
            this.MnyKindCord_tNedit = new Broadleaf.Library.Windows.Forms.TNedit();
            this.MnyKindCord_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MnyKindName_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MnyKindName_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.MnyKindDivCd_Title_Label = new Infragistics.Win.Misc.UltraLabel();
            this.MnyKindDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MnyKindCord_tNedit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MnyKindName_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MnyKindDivCd_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
            this.tRetKeyControl1.Style = Broadleaf.Library.Windows.Forms.emFocusStyle.ByTab;
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 206);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(647, 23);
            this.ultraStatusBar1.TabIndex = 15;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // Bind_DataSet
            // 
            this.Bind_DataSet.DataSetName = "NewDataSet";
            this.Bind_DataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // Mode_Label
            // 
            appearance19.ForeColor = System.Drawing.Color.White;
            appearance19.TextHAlignAsString = "Center";
            appearance19.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance19;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.Location = new System.Drawing.Point(540, 5);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(100, 23);
            this.Mode_Label.TabIndex = 14;
            this.Mode_Label.Text = "更新モード";
            // 
            // Initial_Timer
            // 
            this.Initial_Timer.Interval = 1;
            this.Initial_Timer.Tick += new System.EventHandler(this.Initial_Timer_Tick);
            // 
            // Ok_Button
            // 
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(377, 161);
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
            this.Cancel_Button.Location = new System.Drawing.Point(511, 161);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 8;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // Delete_Button
            // 
            this.Delete_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Delete_Button.Location = new System.Drawing.Point(246, 161);
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
            this.Revive_Button.Location = new System.Drawing.Point(377, 161);
            this.Revive_Button.Name = "Revive_Button";
            this.Revive_Button.Size = new System.Drawing.Size(125, 34);
            this.Revive_Button.TabIndex = 6;
            this.Revive_Button.Text = "復活(&R)";
            this.Revive_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Revive_Button.Click += new System.EventHandler(this.Revive_Button_Click);
            // 
            // MnyKindCord_tNedit
            // 
            appearance15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance15.TextHAlignAsString = "Right";
            appearance15.TextVAlignAsString = "Middle";
            this.MnyKindCord_tNedit.ActiveAppearance = appearance15;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance16.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance16.ForeColor = System.Drawing.Color.Black;
            appearance16.ForeColorDisabled = System.Drawing.Color.Black;
            appearance16.TextHAlignAsString = "Right";
            appearance16.TextVAlignAsString = "Middle";
            this.MnyKindCord_tNedit.Appearance = appearance16;
            this.MnyKindCord_tNedit.AutoSelect = true;
            this.MnyKindCord_tNedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MnyKindCord_tNedit.CalcSize = new System.Drawing.Size(172, 200);
            this.MnyKindCord_tNedit.DataText = "";
            this.MnyKindCord_tNedit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MnyKindCord_tNedit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 3, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, false, true));
            this.MnyKindCord_tNedit.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.MnyKindCord_tNedit.Location = new System.Drawing.Point(124, 36);
            this.MnyKindCord_tNedit.MaxLength = 3;
            this.MnyKindCord_tNedit.Name = "MnyKindCord_tNedit";
            this.MnyKindCord_tNedit.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, true, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsON);
            this.MnyKindCord_tNedit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MnyKindCord_tNedit.Size = new System.Drawing.Size(35, 24);
            this.MnyKindCord_tNedit.TabIndex = 1;
            // 
            // MnyKindCord_Title_Label
            // 
            appearance18.BackColor = System.Drawing.Color.Transparent;
            appearance18.TextVAlignAsString = "Middle";
            this.MnyKindCord_Title_Label.Appearance = appearance18;
            this.MnyKindCord_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MnyKindCord_Title_Label.Location = new System.Drawing.Point(12, 36);
            this.MnyKindCord_Title_Label.Name = "MnyKindCord_Title_Label";
            this.MnyKindCord_Title_Label.Size = new System.Drawing.Size(104, 24);
            this.MnyKindCord_Title_Label.TabIndex = 10;
            this.MnyKindCord_Title_Label.Text = "金種コード";
            // 
            // MnyKindName_Title_Label
            // 
            appearance17.BackColor = System.Drawing.Color.Transparent;
            appearance17.TextVAlignAsString = "Middle";
            this.MnyKindName_Title_Label.Appearance = appearance17;
            this.MnyKindName_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MnyKindName_Title_Label.Location = new System.Drawing.Point(12, 76);
            this.MnyKindName_Title_Label.Name = "MnyKindName_Title_Label";
            this.MnyKindName_Title_Label.Size = new System.Drawing.Size(104, 24);
            this.MnyKindName_Title_Label.TabIndex = 11;
            this.MnyKindName_Title_Label.Text = "金種名";
            // 
            // MnyKindName_tEdit
            // 
            appearance13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MnyKindName_tEdit.ActiveAppearance = appearance13;
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance14.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance14.ForeColor = System.Drawing.Color.Black;
            appearance14.ForeColorDisabled = System.Drawing.Color.Black;
            this.MnyKindName_tEdit.Appearance = appearance14;
            this.MnyKindName_tEdit.AutoSelect = true;
            this.MnyKindName_tEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MnyKindName_tEdit.DataText = "";
            this.MnyKindName_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.MnyKindName_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, true, 30, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.MnyKindName_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.MnyKindName_tEdit.Location = new System.Drawing.Point(124, 76);
            this.MnyKindName_tEdit.MaxLength = 30;
            this.MnyKindName_tEdit.Name = "MnyKindName_tEdit";
            this.MnyKindName_tEdit.Size = new System.Drawing.Size(496, 24);
            this.MnyKindName_tEdit.TabIndex = 2;
            // 
            // MnyKindDivCd_Title_Label
            // 
            appearance8.BackColor = System.Drawing.Color.Transparent;
            appearance8.TextVAlignAsString = "Middle";
            this.MnyKindDivCd_Title_Label.Appearance = appearance8;
            this.MnyKindDivCd_Title_Label.BackColorInternal = System.Drawing.Color.Transparent;
            this.MnyKindDivCd_Title_Label.Location = new System.Drawing.Point(12, 116);
            this.MnyKindDivCd_Title_Label.Name = "MnyKindDivCd_Title_Label";
            this.MnyKindDivCd_Title_Label.Size = new System.Drawing.Size(96, 24);
            this.MnyKindDivCd_Title_Label.TabIndex = 12;
            this.MnyKindDivCd_Title_Label.Text = "金種区分";
            // 
            // MnyKindDivCd_tComboEditor
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MnyKindDivCd_tComboEditor.ActiveAppearance = appearance5;
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            appearance6.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance6.ForeColor = System.Drawing.Color.Black;
            appearance6.ForeColorDisabled = System.Drawing.Color.Black;
            this.MnyKindDivCd_tComboEditor.Appearance = appearance6;
            this.MnyKindDivCd_tComboEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(219)))), ((int)(((byte)(231)))));
            this.MnyKindDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.MnyKindDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.MnyKindDivCd_tComboEditor.ItemAppearance = appearance7;
            this.MnyKindDivCd_tComboEditor.Location = new System.Drawing.Point(124, 116);
            this.MnyKindDivCd_tComboEditor.MaxDropDownItems = 18;
            this.MnyKindDivCd_tComboEditor.Name = "MnyKindDivCd_tComboEditor";
            this.MnyKindDivCd_tComboEditor.Size = new System.Drawing.Size(144, 24);
            this.MnyKindDivCd_tComboEditor.TabIndex = 3;
            // 
            // SFUKK09040UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(647, 229);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.MnyKindDivCd_tComboEditor);
            this.Controls.Add(this.MnyKindDivCd_Title_Label);
            this.Controls.Add(this.MnyKindName_tEdit);
            this.Controls.Add(this.MnyKindCord_tNedit);
            this.Controls.Add(this.MnyKindName_Title_Label);
            this.Controls.Add(this.MnyKindCord_Title_Label);
            this.Controls.Add(this.Revive_Button);
            this.Controls.Add(this.Delete_Button);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Ok_Button);
            this.Controls.Add(this.Cancel_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFUKK09040UA";
            this.Text = "金額種別設定";
            this.Load += new System.EventHandler(this.SFUKK09040UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFUKK09040UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFUKK09040UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.Bind_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MnyKindCord_tNedit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MnyKindName_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MnyKindDivCd_tComboEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Events
		/// <summary>画面非表示イベント</summary>
		/// <remarks>画面が非表示状態になった際に発生します。</remarks>
		public event MasterMaintenanceMultiTypeUnDisplayingEventHandler UnDisplaying;
		# endregion
				
		#region Private Menbers
		//private InsurCoNmAcs _insurconmAcs;
	//	private InsurCoNm _prevInsurCoNm;
		private bool _nextData;
		private int _totalCount;
		private string _enterpriseCode;
      //private Hashtable _insurconmTable;

		// プロパティ用
		private bool _canPrint;
		private bool _canLogicalDeleteDataExtraction;
		private bool _canClose;
		private bool _canNew;
		private bool _canDelete;
		private bool _canSpecificationSearch;
		private int _dataIndex;
		private bool _defaultAutoFillToColumn;

		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005 07.07 H.NAKAMURA Insert Start
		//_dataIndexバッファ（メインフレーム最小化対応）
		private int _indexBuffer;
		//2005 07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		// FremのView用Grid列のKEY情報 (ヘッダのタイトル部となります)
		private const string DELETE_DATE  = "削除日";

        // DEL 2008/09/19 不具合対応[5416]↓
        //private const string PRICE_TITLE = "金額設定区分";

        private const string DIV_TITLE    = "金種区分";
		private const string CODE_TITLE   = "金種コード";
        private const string NAME_TITLE   = "金種名";   // MOD 2008/10/23 不具合対応[6943] "金種名称"→"金種名"
        // 2007.05.17  S.Koga  add --------------------------------------------
        private const string REGCODE_TITLE = "レジ管理区分コード";
        private const string REGTEXT_TITLE = "レジ管理区分";
        // --------------------------------------------------------------------
        private const string GUID_TITLE = "GUID";
		private const string MONEYSKIND_TABLE = "MONEYSKIND";

        private MoneyKindAcs _mnykindAcs;      //金額種別マスタアクセスクラス
        private MoneyKind _prevMoneyKind;      //金額種別データクラスバッファ
        private Hashtable _mnykindTable;       //金額種別テーブル
        //private string[] _priceSt  = {"入金", "サービス", "売掛"};  // DEL 2008/06/12
        private string[] _priceSt = { "入金・支払", "", "売掛・買掛" };
        private Hashtable _mnykindDivTbl;   //金種区分変換テーブル(コード⇔名称を変換します)

		//比較用clone
		private MoneyKind _moneyKindClone;


		// 編集モード
		private const string INSERT_MODE = "新規モード";
		private const string UPDATE_MODE = "更新モード";
		private const string DELETE_MODE = "削除モード";
        private const string VIEW_MODE   = "参照モード";
		#endregion
    
		# region Main
		/// <summary>アプリケーションのメイン エントリ ポイントです。</summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFUKK09040UA());
		}
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

		/// <summary>件数指定読込設定プロパティ</summary>
		/// <value>件数指定読込が可能かどうかの設定を取得します。</value>
		public bool CanSpecificationSearch
		{
			get{ return this._canSpecificationSearch; }
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
		# endregion

		# region Public Methods
		/// <summary>
		/// バインドデータセット取得処理
		/// </summary>
		/// <param name="bindDataSet">グリッド用データセット</param>
		/// <param name="tableName">テーブル名称</param>
		/// <remarks>
		/// <br>Note       : グリッドにバインドさせるデータセットを取得します。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
		{
			bindDataSet = this.Bind_DataSet;
			tableName = MONEYSKIND_TABLE;            
		}


        /// <summary>
		/// データ検索処理
		/// </summary>
		/// <param name="totalCount">全該当件数</param>
		/// <param name="readCount">抽出対象件数</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 先頭から指定件数分のデータを検索し、抽出結果を展開したDataSetと全該当件数を返します。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
        /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
        /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
        /// </remarks>
        public int Search(ref int totalCount, int readCount)
		{
			int status = 0;
			ArrayList mnykindAry = null;

            //金額種別区分マスタを読込み、テーブルへセット
            SetMnyKindDivTbl();
            
            if (readCount == 0)
			{
				// 抽出対象件数が0の場合は全件抽出を実行する
				status = this._mnykindAcs.SearchAll( out mnykindAry, 
                                                     this._enterpriseCode);
				this._totalCount = mnykindAry.Count;
			}else{
				status = this._mnykindAcs.SearchSpecificationAll(
							out mnykindAry,
							out this._totalCount,
							out this._nextData,
							this._enterpriseCode,
							readCount,
							this._prevMoneyKind);
			}

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( mnykindAry.Count > 0 ) {
						// 最終の金額種別オブジェクトを退避する
						this._prevMoneyKind = ((MoneyKind)mnykindAry[mnykindAry.Count - 1]).Clone();
					}

					int index = 0;
					foreach(MoneyKind mnykind in mnykindAry)
                    {
                        // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
                        //if (this._mnykindTable.ContainsKey(mnykind.FileHeaderGuid) == false)
                        if (this._mnykindTable.ContainsKey(CreateHashKey(mnykind)) == false)
                        // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
                        {
							InsutanceToDataSet(mnykind.Clone(), index);
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
						"SFUKK09040U", 						// アセンブリＩＤまたはクラスＩＤ
						"金額種別設定",　					// プログラム名称
						"Search", 							// 処理名称
						TMsgDisp.OPE_GET, 					// オペレーション
						"読み込みに失敗しました。", 		// 表示するメッセージ
						status, 							// ステータス値
						this._mnykindAcs,	 				// エラーが発生したオブジェクト
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
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
        /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
        /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
        /// </remarks>
		public int SearchNext(int readCount)
		{
                     
            int dummy = 0;
            ArrayList mnykindAry = null;

			// 抽出対象件数が0の場合は、残りの全件を抽出
			if (readCount == 0)
			{
				readCount =	this._totalCount - this.Bind_DataSet.Tables[0].Rows.Count;
			}

            int status = this._mnykindAcs.SearchSpecificationAll(
							out mnykindAry,
							out dummy,
							out this._nextData, 
							this._enterpriseCode,
							readCount,
							this._prevMoneyKind);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					if( mnykindAry.Count > 0 ) {
						// 最終の金額種別クラスを退避する
						this._prevMoneyKind = ((MoneyKind)mnykindAry[mnykindAry.Count - 1]).Clone();
                    }

					int index = 0;

                    foreach(MoneyKind moneykind in mnykindAry)
                    {
                        // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
                        //if (this._mnykindTable.ContainsKey(moneykind.FileHeaderGuid) == false)
						if (this._mnykindTable.ContainsKey(CreateHashKey(moneykind)) == false)
                        // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
                        {
							index = this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows.Count;
							InsutanceToDataSet(moneykind.Clone(), index);
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
						"SFUKK09040U", 						// アセンブリＩＤまたはクラスＩＤ
						"金額種別設定",　					// プログラム名称
						"Search", 							// 処理名称
						TMsgDisp.OPE_GET, 					// オペレーション
						"読み込みに失敗しました。", 		// 表示するメッセージ
						status, 							// ステータス値
						this._mnykindAcs,	 				// エラーが発生したオブジェクト
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

			return status;
		}

		/// <summary>
		/// データ削除処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 選択中のデータを削除します。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
        /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
        /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
        /// </remarks>
		public int Delete()
		{

//TODO:メンテナンスされる方へ　　SFカスタマイズ課元村
//     Pegasusでは入金設定にて使用されている金種は削除できないようになっていますので
//     削除の際は入金設定マスタ（？）を確認する必要があります。

            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
            //Guid guid = (Guid)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];
            string guid = (string)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];
            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
            MoneyKind moneykind = (MoneyKind)this._mnykindTable[guid];

			/* 2005.12.17 enokida DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
            //提供データの時は削除させない
            if (moneykind.MoneyKindCode < 900)
			{
				// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				TMsgDisp.Show( 
					this, 									// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION,		// エラーレベル
					"SFUKK09040U", 							// アセンブリＩＤまたはクラスＩＤ
					"提供データのため、削除はできません。", // 表示するメッセージ
					0, 										// ステータス値
					MessageBoxButtons.OK );					// 表示するボタン
				// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
				
				// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//				MessageBox.Show(
//					"提供データのため、削除はできません。",
//					"入力チェック",
//					MessageBoxButtons.OK,
//					MessageBoxIcon.Exclamation,
//    				MessageBoxDefaultButton.Button1);
				// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

                    return 0;
            }
			2005.12.17 enokida DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end */

            //論理削除
            int status = this._mnykindAcs.LogicalDelete(ref moneykind);
			////////////////////////////////////////////////2005 07.07 H.NAKAMURA DEL STA //////
//            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//			{
//				MessageBox.Show(
//					"削除に失敗しました。 st = " + status.ToString(),
//					"エラー",
//					MessageBoxButtons.OK,
//					MessageBoxIcon.Error,
//					MessageBoxDefaultButton.Button1);
//				return status;
//			}
			////////////////////////////////////////////////2005 07.07 H.NAKAMURA DEL END //////

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>20050706 Misaki Insert Start
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
					return status;
				}
				default:
				{
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						"SFUKK09040U", 						// アセンブリＩＤまたはクラスＩＤ
						"金額種別設定",　					// プログラム名称
						"Delete", 							// 処理名称
						TMsgDisp.OPE_GET, 					// オペレーション
						"削除に失敗しました。", 			// 表示するメッセージ
						status, 							// ステータス値
						this._mnykindAcs,	 				// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					MessageBox.Show(
//						"削除に失敗しました。 st = " + status.ToString(),
//						"エラー",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
					// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					this.Hide();
					return status;
				}
			}
			//200500706 Misaki Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			/////////////////2005 07.07 H.NAKAMURA DEL STA ////////////////////////////////////////
//            status = this._mnykindAcs.Read(ref moneykind, 1);
//			if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//			{
//				MessageBox.Show(
//					"読み込みに失敗しました。 st = " + status.ToString(),
//					"エラー",
//					MessageBoxButtons.OK,
//					MessageBoxIcon.Error,
//					MessageBoxDefaultButton.Button1);
//				return status;
//			}
			/////////////////2005 07.07 H.NAKAMURA DEL END /////////////////////////////////////////

			InsutanceToDataSet(moneykind.Clone(), this._dataIndex);
			return status;
		}

		/// <summary>
		/// 印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 印刷処理を実行します。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
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
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public Hashtable GetAppearanceTable()
		{
			Hashtable appearanceTable = new Hashtable();
           
            appearanceTable.Add(DELETE_DATE,new GridColAppearance(MGridColDispType.DeletionDataBoth, ContentAlignment.MiddleLeft,   "", Color.Red));

            // DEL 2008/09/19 不具合対応[5416]↓
            //appearanceTable.Add(PRICE_TITLE, new GridColAppearance(MGridColDispType.Both, ContentAlignment.MiddleLeft, "", Color.Black));

            appearanceTable.Add(DIV_TITLE,  new GridColAppearance(MGridColDispType.Both,			  ContentAlignment.MiddleLeft,  "", Color.Black));
            appearanceTable.Add(CODE_TITLE,	new GridColAppearance(MGridColDispType.Both,			  ContentAlignment.MiddleRight, "", Color.Black));
			appearanceTable.Add(NAME_TITLE,	new GridColAppearance(MGridColDispType.Both,			  ContentAlignment.MiddleLeft,  "", Color.Black));
            // 2007.05.17  S.Koga  add ----------------------------------------
            appearanceTable.Add(REGCODE_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleRight, "", Color.Black));

			//----- ueno upd ---------- start 2008.02.18 不要なので非表示にする
			appearanceTable.Add(REGTEXT_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));
			//----- ueno upd ---------- end 2008.02.18

            // ----------------------------------------------------------------
            appearanceTable.Add(GUID_TITLE, new GridColAppearance(MGridColDispType.None, ContentAlignment.MiddleLeft, "", Color.Black));

			return appearanceTable;
		}
		# endregion

		# region Private Methods

        /// <summary>
		/// 金額種別オブジェクトデータセット展開処理
		/// </summary>
		/// <param name="moneykind">金額種別オブジェクト</param>
		/// <param name="index">データセットへ展開するインデックス</param>
		/// <remarks>
		/// <br>Note       : 金額種別クラスをデータセットに格納します。</br>
		/// <br>Programmer : 97134 元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
        /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
        /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
        /// </remarks>
        private void InsutanceToDataSet(MoneyKind moneykind, int index)
        {
            string mnykinddivnm = "";
            
            if ((index < 0) || (this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows.Count <= index))
			{
				// 新規と判断して、行を追加する
				DataRow dataRow = this.Bind_DataSet.Tables[MONEYSKIND_TABLE].NewRow();
				this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows.Add(dataRow);

				// indexを行の最終行番号する
				index = this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows.Count - 1;
			}

			if (moneykind.LogicalDeleteCode == 0)
			{
				this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][DELETE_DATE] = "";
			}
			else
			{
				this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][DELETE_DATE] = moneykind.UpdateDateTimeJpInFormal;
			}

			this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][CODE_TITLE]  = moneykind.MoneyKindCode;
			this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][NAME_TITLE]  = moneykind.MoneyKindName;
            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
            //this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][GUID_TITLE] = moneykind.FileHeaderGuid;
            this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][GUID_TITLE] = CreateHashKey(moneykind);
            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end

            // DEL 2008/09/19 不具合対応[5416]↓
            //this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][PRICE_TITLE] = this._priceSt[moneykind.PriceStCode];

            if(this._mnykindDivTbl.ContainsKey(moneykind.MoneyKindDiv))               // 金種区分コードがあれば
                mnykinddivnm = (string)this._mnykindDivTbl[moneykind.MoneyKindDiv];   // 金種区分名称をセット

            this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][DIV_TITLE]   = mnykinddivnm;

            /* --- DEL 2008/06/12 -------------------------------->>>>>
                // 2007.05.17  S.Koga  add ----------------------------------------
                this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][REGCODE_TITLE] = moneykind.RegiMgCd;
                if (moneykind.RegiMgCd == 0)
                    this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][REGTEXT_TITLE] = "レジ管理しない";
                else if (moneykind.RegiMgCd == 1)
                    this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[index][REGTEXT_TITLE] = "レジ管理する";
                // ----------------------------------------------------------------
               --- DEL 2008/06/12 --------------------------------<<<<< */

            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
            //if (this._mnykindTable.ContainsKey(moneykind.FileHeaderGuid) == true)
			//{
			//	this._mnykindTable.Remove(moneykind.FileHeaderGuid);
			//}
			//this._mnykindTable.Add(moneykind.FileHeaderGuid, moneykind);
            if (this._mnykindTable.ContainsKey(CreateHashKey(moneykind)) == true)
            {
                this._mnykindTable.Remove(CreateHashKey(moneykind));
            }
            this._mnykindTable.Add(CreateHashKey(moneykind), moneykind);
            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
        }


		/// <summary>
		/// データセット列情報構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : データセットの列情報を構築します。
		///					 データセットの列情報がフレームのビュー用グリッドの列になります</br>
		/// <br>Programmer : 97134　元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
        /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
        /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
        /// </remarks>
		private void DataSetColumnConstruction()
		{
            DataTable mnykindTable = new DataTable(MONEYSKIND_TABLE);

			// Addを行う順番が、列の表示順位となります。
			mnykindTable.Columns.Add(DELETE_DATE,   typeof(string));

            // DEL 2008/09/19 不具合対応[5416]↓
            //mnykindTable.Columns.Add(PRICE_TITLE, typeof(string));

            mnykindTable.Columns.Add(CODE_TITLE,    typeof(int));
			mnykindTable.Columns.Add(NAME_TITLE,    typeof(string));
            mnykindTable.Columns.Add(DIV_TITLE, typeof(string));
            // 2007.05.17  S.Koga  add ----------------------------------------
            mnykindTable.Columns.Add(REGCODE_TITLE, typeof(int));
            mnykindTable.Columns.Add(REGTEXT_TITLE, typeof(string));
            // ----------------------------------------------------------------
            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
            //mnykindTable.Columns.Add(GUID_TITLE, typeof(Guid));
            mnykindTable.Columns.Add(GUID_TITLE, typeof(string));
            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end

            this.Bind_DataSet.Tables.Add(mnykindTable);
        }

		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 97134　元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
            ArrayList aryBuf = new ArrayList();
            IMnyKindDibComp Imnycmp = new IMnyKindDibComp();

            // DEL 2008/09/19 不具合対応[5416] ---------->>>>>
            ////金額設定区分
            //this.PriceStCd_tComboEditor.Clear();

            //for(int cnt=0; cnt < _priceSt.Length; cnt++)
            //{
            //    if (_priceSt[cnt] != "")
            //    {
            //        this.PriceStCd_tComboEditor.Items.Add(cnt, _priceSt[cnt]);
            //    }
            //}
            // DEL 2008/09/19 不具合対応[5416] ----------<<<<<

            //金種コードがKEYになっているためKEYを列挙する
            foreach(int cord in this._mnykindDivTbl.Keys)
            {               
                MnyKindDibInf mnykinddivinf = new MnyKindDibInf();      //構造体を作成
                mnykinddivinf.mnykinddivCd = cord;                      //金種コード
                mnykinddivinf.mnykinddivNm = (string)this._mnykindDivTbl[cord];
                aryBuf.Add(mnykinddivinf);                              //リストへ追加
            }
            //リストを金種コード順で並び替える
            aryBuf.Sort(Imnycmp);
            
            //金種区分コンボボックスへ項目追加
            this.MnyKindDivCd_tComboEditor.Clear();   
            foreach(MnyKindDibInf mnyinf in aryBuf){
                this.MnyKindDivCd_tComboEditor.Items.Add(mnyinf.mnykinddivCd, mnyinf.mnykinddivNm);
            }

            /* --- DEL 2008/06/12 -------------------------------->>>>>
                // 2007.05.17  S.Koga  add ----------------------------------------
                // レジ管理区分コンボボックスへ項目追加
                this.RegiMgCd_tComboEditor.Items.Clear();
                this.RegiMgCd_tComboEditor.Items.Add(0, "レジ管理しない");
                this.RegiMgCd_tComboEditor.Items.Add(1, "レジ管理する");
                // ----------------------------------------------------------------
               --- DEL 2008/06/12 --------------------------------<<<<< */
		}

		/// <summary>
		/// 画面クリア処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面をクリアします。</br>
		/// <br>Programmer : 97134　元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		private void ScreenClear()
		{
            this.MnyKindCord_tNedit.Clear();
			this.MnyKindName_tEdit.Clear();

            // DEL 2008/09/19 不具合対応[5416]↓
            //this.PriceStCd_tComboEditor.SelectedIndex = 0;

            this.MnyKindDivCd_tComboEditor.SelectedIndex = 0;
            // 2007.05.17  S.Koga  add ----------------------------------------

			//----- ueno upd ---------- start 2008.02.18
			//this.RegiMgCd_tComboEditor.SelectedIndex = 1;	// レジ管理する固定  // DEL 2008/06/12
			//----- ueno upd ---------- end 2008.02.18
            
            // ----------------------------------------------------------------
		}

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
		/// <br>Programmer : 97134　元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
        /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
        /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
        /// </remarks>
		private void ScreenReconstruction()
		{

            if (this.DataIndex < 0)
            {
                MoneyKind mnykind = new MoneyKind();
                this._moneyKindClone = mnykind.Clone();     //クローン作成
				DispToInsutance(ref this._moneyKindClone);

                // ----- 登録モード ----- //
                //画面表示設定
				this.Mode_Label.Text = INSERT_MODE;
				this.Ok_Button.Visible = true;
				this.Cancel_Button.Visible = true;
				this.Delete_Button.Visible = false;
				this.Revive_Button.Visible = false;
                
                //入力可不可設定

                // DEL 2008/09/19 不具合対応[5416]↓
                //this.PriceStCd_tComboEditor.Enabled     = true;

                this.MnyKindDivCd_tComboEditor.Enabled  = true;
                this.MnyKindCord_tNedit.Enabled         = true;
                this.MnyKindName_tEdit.Enabled          = true;
                // 2007.05.17  S.Koga  add ------------------------------------
                //this.RegiMgCd_tComboEditor.Enabled      = true;  // DEL 2008/06/12
                // ------------------------------------------------------------

                // DEL 2008/09/19 不具合対応[5416]↓
                //this.PriceStCd_tComboEditor.Focus();

				ScreenInputPermissionControl(true);
			}else{

                //グリッド上で選択された行の一意の値を取得
                // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
                //Guid guid = (Guid)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];
                string guid = (string)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];
                // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
                MoneyKind mnykind = (MoneyKind)this._mnykindTable[guid];
                InsutanceToDisp(mnykind);             //画面へ情報を反映

/* 2005.12.17 enokida DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
                //提供分のデータの時は修正させない
                if(mnykind.MoneyKindCode <= 899)
                {
					ScreenInputPermissionControl(false);
					this.Ok_Button.Visible     = false;
					this.Cancel_Button.Visible = true;
					this.Delete_Button.Visible = false;
					this.Revive_Button.Visible = false;

                    this.Mode_Label.Text = VIEW_MODE;               //参照モードに設定
                    return;
                }
2005.12.17 enokida DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end */

				if (mnykind.LogicalDeleteCode == 0) 
				{
                    // ----- 更新モード ----- //
                    //画面表示設定
                    this.Mode_Label.Text = UPDATE_MODE;
					this.Ok_Button.Visible = true;
					this.Cancel_Button.Visible = true;
					this.Delete_Button.Visible = false;
					this.Revive_Button.Visible = false;
					ScreenInputPermissionControl(true);

					// 更新モードの場合は金額種別コード、金額区分、金種区分を入力不可とする

                    // DEL 2008/09/19 不具合対応[5416]↓
                    //this.PriceStCd_tComboEditor.Enabled     = false;

                    this.MnyKindDivCd_tComboEditor.Enabled  = false;    // MOD 2008/09/19 不具合対応[5433] true→false
                    this.MnyKindCord_tNedit.Enabled         = false;
                    // 2007.05.17  S.Koga  add --------------------------------
                    //this.RegiMgCd_tComboEditor.Enabled = true;  // DEL 2008/06/12
                    // --------------------------------------------------------

                    this.MnyKindName_tEdit.Focus();
                    this.MnyKindName_tEdit.SelectAll();

					//画面情報を比較用クローンにコピーする　　　　　   
                    this._moneyKindClone = mnykind.Clone();     //クローン作成
					DispToInsutance( ref this._moneyKindClone);
				}
				else
				{
					// 削除モード
					this.Mode_Label.Text = DELETE_MODE;

					this.Ok_Button.Visible = false;
					this.Cancel_Button.Visible = true;
					this.Delete_Button.Visible = true;
					this.Revive_Button.Visible = true;
                    this.Delete_Button.Focus();

					ScreenInputPermissionControl(false);

				}
            }
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005 07.07 H.NAKAMURA Insert Start
			//_dataIndexバッファ保持
			this._indexBuffer = this._dataIndex;
			//2005 07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
		}

		/// <summary>
		/// 画面入力許可制御処理
		/// </summary>
		/// <param name="enabled">入力許可設定値</param>
		/// <remarks>
		/// <br>Note       : 画面の入力許可を制御します。</br>
		/// <br>Programmer : 97134　元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		private void ScreenInputPermissionControl(bool enabled)
		{
            //金額種別用
            this.MnyKindCord_tNedit.Enabled         = enabled;
            this.MnyKindName_tEdit.Enabled          = enabled;

            // DEL 2008/09/19 不具合対応[5416]↓
            //this.PriceStCd_tComboEditor.Enabled     = enabled;

            this.MnyKindDivCd_tComboEditor.Enabled  = enabled;
            // 2007.05.17  S.Koga  add ----------------------------------------
            //this.RegiMgCd_tComboEditor.Enabled      = enabled;  // DEL 2008/06/12
            // ----------------------------------------------------------------
		}

		/// <summary>
		/// 金額種別クラス画面展開処理
		/// </summary>
		/// <param name="moneykind">金額種別オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 金額種別オブジェクトから画面にデータを展開します。</br>
		/// <br>Programmer : 97134　元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
        private void InsutanceToDisp(MoneyKind moneykind)
        {
            //金額種別用
            this.MnyKindCord_tNedit.SetInt(moneykind.MoneyKindCode);            //金額種別コード
            this.MnyKindName_tEdit.Text             = moneykind.MoneyKindName;  //金額種別名称

            // DEL 2008/09/19 不具合対応[5416]↓
            //this.PriceStCd_tComboEditor.Value       = moneykind.PriceStCode;    //金額設定区分

            this.MnyKindDivCd_tComboEditor.Value    = moneykind.MoneyKindDiv;   //金種コード
            // 2007.05.17  S.Koga  add ----------------------------------------
            //this.RegiMgCd_tComboEditor.Value        = moneykind.RegiMgCd;       //レジ管理区分  // DEL 2008/06/12
            // ----------------------------------------------------------------
        
        }


		/// <summary>
		/// 画面情報金額種別クラス格納処理
		/// </summary>
		/// <param name="moneykind">金額種別オブジェクト</param>
		/// <remarks>
		/// <br>Note       : 画面情報から金額種別オブジェクトにデータを格納します。</br>
		/// <br>Programmer : 97134　元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
        private void DispToInsutance(ref MoneyKind moneykind)
		{
			if (moneykind == null)
            {				
				moneykind = new MoneyKind();    // 新規の場合
			}

			moneykind.EnterpriseCode  = this._enterpriseCode;			            //TODO:要変更

            // DEL 2008/09/19 不具合対応[5416]↓ 
            //moneykind.PriceStCode     = (int)this.PriceStCd_tComboEditor.Value;
            // 金額区分
            moneykind.PriceStCode = 0;  // ADD 2008/09/19 不具合対応[5416]

            moneykind.MoneyKindDiv    = (int)this.MnyKindDivCd_tComboEditor.Value; //金種区分
            moneykind.MoneyKindCode	  = this.MnyKindCord_tNedit.GetInt();           //金種別コード
            moneykind.MoneyKindName   = this.MnyKindName_tEdit.Text;      //金額種別名称
            // 2007.05.17  S.Koga  add ----------------------------------------
            //moneykind.RegiMgCd = (int)this.RegiMgCd_tComboEditor.Value;  // DEL 2008/06/12
            // ----------------------------------------------------------------
		}


		/// <summary>
		/// 画面入力情報不正チェック処理
		/// </summary>
		/// <param name="control">不正対象コントロール</param>
		/// <param name="message">メッセージ</param>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の不正チェックを行います。</br>
		/// <br>Programmer : 97134　元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		private bool ScreenDataCheck(ref Control control, ref string message)
        {
            # region 2007.05.17  S.Koga  DLL
            //bool result = true;
            # endregion

            //金額種別コードをチェック
            if (this.MnyKindCord_tNedit.GetInt() == 0)
            {
                control = this.MnyKindCord_tNedit;
                message = this.MnyKindCord_Title_Label.Text + "を入力して下さい。";
                // 2007.05.17  S.Koga  amend ----------------------------------
				//result = false;
                return false;
                // ------------------------------------------------------------
            }else 
/* 2005.12.17 enokida DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
            if (this.MnyKindCord_tNedit.GetInt() < 900)
            {
                control = this.MnyKindCord_tNedit;
                message = this.MnyKindCord_Title_Label.Text + "は「900」以上を入力して下さい。";
				result = false;
            }else
2005.12.17 enokide DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end */			
            if (this.MnyKindName_tEdit.Text.Trim() == "")
            {
            //金額種別名称をチェック
                control = this.MnyKindName_tEdit;
                message = this.MnyKindName_Title_Label.Text + "を入力して下さい。";
                // 2007.05.17  S.Koga  amend ----------------------------------
                //result = false;
                return false;
                // ------------------------------------------------------------
            }

            // 2007.05.17  S.Koga  add ----------------------------------------
        if (this.MnyKindDivCd_tComboEditor.Text.Equals(""))
        {
            //金種区分をチェック
            control = this.MnyKindDivCd_tComboEditor;
            message = this.MnyKindDivCd_Title_Label.Text + "を入力して下さい。";
            return false;
        }

        /* --- DEL 2008/06/12 -------------------------------->>>>>
        if (this.RegiMgCd_tComboEditor.Text.Equals(""))
        {
            //金種区分をチェック
            control = this.RegiMgCd_tComboEditor;
            message = this.RegiMgCd_Title_Label.Text + "を入力して下さい。";
            return false;
        }
           --- DEL 2008/06/12 --------------------------------<<<<< */
        
        // 2007.05.17  S.Koga  amend ----------------------------------
        //return result;
        return true;
        // ------------------------------------------------------------
    }

		/// <summary>
		/// 金額種別保存処理
		/// </summary>
		/// <returns>登録結果結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 金額種別登録を行います。</br>
		/// <br>Programmer : 97134　元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
        /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
        /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
        /// </remarks>
		private bool SaveMnyKind()
		{
			Control control = null;
			string message = null;

			if (!ScreenDataCheck(ref control, ref message))
			{
				// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				// 入力チェック
				TMsgDisp.Show( 
					this, 								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
					"SFUKK09040U", 						// アセンブリＩＤまたはクラスＩＤ
					message, 							// 表示するメッセージ
					0, 									// ステータス値
					MessageBoxButtons.OK );				// 表示するボタン
				// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

				// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//				MessageBox.Show(
//					message,
//					"入力チェック",
//					MessageBoxButtons.OK,
//					MessageBoxIcon.Exclamation,
//					MessageBoxDefaultButton.Button1);
				// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

				control.Focus();
				return false;
			}

            MoneyKind moneykind = null;
            if (this.DataIndex >= 0)
            {
                // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
                //Guid guid = (Guid)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];
                string guid = (string)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];
                // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
                //	moneykind = (MoneyKind)this._mnykindTable[guid];
				moneykind = ((MoneyKind)this._mnykindTable[guid]).Clone();
			}

            DispToInsutance(ref moneykind);
			int status = this._mnykindAcs.Write(ref moneykind);    //書込み処理

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
				{
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					// コード重複
					TMsgDisp.Show( 
						this, 											// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_INFO, 					// エラーレベル
						"SFUKK09040U", 									// アセンブリＩＤまたはクラスＩＤ
						"この金種コードは既に使用されています。",		// 表示するメッセージ
						0, 												// ステータス値
						MessageBoxButtons.OK );							// 表示するボタン
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					MessageBox.Show(
//						//"この保険会社コードは既に使用されています。",
//						"この金種コードは既に使用されています。",
//                        "入力チェック",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Exclamation,
//						MessageBoxDefaultButton.Button1);
					// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

                    this.MnyKindCord_tNedit.Focus();
					return false;
				}
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005.07.07 H.NAKAMURA Insert Start>>>>
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status);
					return false;
				}
				//2005.07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
				default:
				{
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					// サーチ
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						"SFUKK09040U", 						// アセンブリＩＤまたはクラスＩＤ
						"金額種別設定",　					// プログラム名称
						"SaveMnyKind", 						// 処理名称
						TMsgDisp.OPE_GET, 					// オペレーション
						"登録に失敗しました。",				// 表示するメッセージ
						status, 							// ステータス値
						this._mnykindAcs,	 				// エラーが発生したオブジェクト
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

            InsutanceToDataSet(moneykind, this.DataIndex);

			return true;
		}

		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005.07.07 H.NAKAMURA Insert Start
		/// <summary>
		/// 排他処理
		/// </summary>
		/// <returns>チェック結果（true:OK／false:NG）</returns>
		/// <remarks>
		/// <br>Note       : 画面入力情報の不正チェックを行います。</br>
		/// <br>Programmer : 23010  中村　仁</br>
		/// <br>Date       : 2005.07.07	</br>
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
						"SFUKK09040U", 						// アセンブリＩＤまたはクラスＩＤ
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
						"SFUKK09040U", 						// アセンブリＩＤまたはクラスＩＤ
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
		//2005.07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
        /// <summary>
        /// HashTable用キー作成
        /// </summary>
        /// <param name="makerUMnt">MoneyKindクラス</param>
        /// <returns>Hashテーブル用キー</returns>
        /// <remarks>
        /// <br>Note      : MoneyKindクラスからハッシュテーブル用のキーを作成します。</br>
        /// <br>Programer : 96012 日色 馨</br>
        /// <br>Date      : 2008.02.29</br>
        /// </remarks>
        private string CreateHashKey(MoneyKind moneyKind)
        {
            return moneyKind.EnterpriseCode + moneyKind.PriceStCode.ToString("d2") + moneyKind.MoneyKindCode.ToString("d3");
        }
        // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
        # endregion

		#region Control Events
		/// <summary>
		/// Form.Load イベント(SFUKK09040UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer  : 97134　元村 雅博</br>
		/// <br>Date        : 2005.06.24</br>
		/// </remarks>
		private void SFUKK09040UA_Load(object sender, System.EventArgs e)
		{
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList25 = IconResourceManagement.ImageList24;
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Ok_Button.ImageList = imageList25;
			this.Cancel_Button.ImageList = imageList25;
			this.Delete_Button.ImageList = imageList25;
			this.Revive_Button.ImageList = imageList25;

			this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
			this.Delete_Button.Appearance.Image = Size24_Index.DELETE;
			this.Revive_Button.Appearance.Image = Size24_Index.REVIVAL;

			ScreenInitialSetting();
		}

		/// <summary>
		/// Form.Closing イベント(SFUKK09040UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note　　　  : フォームを閉じる前に、ユーザーがフォームを閉じようとしたときに発生します。</br>
		/// <br>Programmer  : 97134　元村 雅博</br>
		/// <br>Date        : 2005.06.24</br>
		/// </remarks>
		private void SFUKK09040UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005 07.07 H.NAKAMURA Insert Start
			this._indexBuffer = -2;
			//2005 07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			// フォームの「×」をクリックされた場合の対応です。
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
				return;
			}
		}

		/// <summary>
		/// Control.VisibleChanged イベント(SFUKK09040UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : フォームの表示状態が変わったときに発生します。</br>
		/// <br>Programmer  : 97134　元村 雅博</br>
		/// <br>Date        : 2005.06.24</br>
		/// </remarks>
		private void SFUKK09040UA_VisibleChanged(object sender, System.EventArgs e)
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

			// 2005.07.07 H.NAKAMURA ADD フレームの最小化対応 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			if (this._indexBuffer == this._dataIndex)
			{
				return;
			}
			// 2005.07.07 H.NAKAMURA ADD フレームの最小化対応 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

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
		/// <br>Programmer  : 97134　元村 雅博</br>
		/// <br>Date        : 2005.06.24</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			// 金額種別登録処理
			if (SaveMnyKind() == false)
			{
				return;
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			// 登録モードの場合は画面を終了せずに連続入力を可能とする
			if (this.Mode_Label.Text == INSERT_MODE)
			{
				this.DataIndex = -1;

				ScreenClear();

                // DEL 2008/09/19 不具合対応[5416]↓
                //this.PriceStCd_tComboEditor.Focus();
                this.MnyKindCord_tNedit.Focus();    // ADD 2008/09/19 不具合対応[5416]

				// クローンを再度取得する
                MoneyKind moneykind = new MoneyKind();

				//クローン作成
                this._moneyKindClone = moneykind.Clone();

				DispToInsutance( ref this._moneyKindClone);

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

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005 07.07 H.NAKAMURA Insert Start
				this._indexBuffer = -2;
				//2005 07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
			}
		}

		/// <summary>
		/// Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 97134　元村 雅博</br>
		/// <br>Date        : 2005.06.24</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
            // 削除モード・参照モード以外の場合は保存確認処理を行う
			if (this.Mode_Label.Text != DELETE_MODE && this.Mode_Label.Text != VIEW_MODE)
			{
                //保存確認
                MoneyKind cmpMoneyKind = new MoneyKind();
                cmpMoneyKind = this._moneyKindClone.Clone();
				//現在の画面情報を取得する
				DispToInsutance( ref cmpMoneyKind);
				//最初に取得した画面情報と比較
				if (!(this._moneyKindClone.Equals(cmpMoneyKind)))	
				{
                    //画面情報が変更されていた場合は、保存確認メッセージを表示する
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					// 保存確認
					DialogResult res = TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
						"SFUKK09040U", 						// アセンブリＩＤまたはクラスＩＤ
						null, 								// 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.YesNoCancel );	// 表示するボタン
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					DialogResult res = MessageBox.Show("編集中のデータが存在します"+"\r\n"+"\r\n"+"登録してもよろしいですか？","保存確認",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
					// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					
					switch(res)
					{
						case DialogResult.Yes:
						{
							// 金額種別登録処理
							if (SaveMnyKind() == false)
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
			}
			
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult);
				UnDisplaying(this, me);
			}

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005 07.07 H.NAKAMURA Insert Start
			this._indexBuffer = -2;
			//2005 07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

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
		/// <br>Programmer  : 97134　元村 雅博</br>
		/// <br>Date        : 2005.06.24</br>
        /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
        /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
        /// </remarks>
		private void Delete_Button_Click(object sender, System.EventArgs e)
		{
			// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			// 完全削除確認
			DialogResult result = TMsgDisp.Show( 
				this, 								// 親ウィンドウフォーム
				emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
				"SFUKK09040U", 						// アセンブリＩＤまたはクラスＩＤ
				"データを削除します。" + "\r\n" + 
				"よろしいですか？", 				// 表示するメッセージ
				0, 									// ステータス値
				MessageBoxButtons.OKCancel, 		// 表示するボタン
				MessageBoxDefaultButton.Button2 );	// 初期表示ボタン
			// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					
			// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//			DialogResult result = MessageBox.Show(
//				"データを削除します。" + "\r\n" + "よろしいですか？",
//				"削除確認",
//				MessageBoxButtons.OKCancel,
//				MessageBoxIcon.Exclamation,
//				MessageBoxDefaultButton.Button2);
			// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			if (result == DialogResult.OK)
			{
                // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
                //Guid guid = (Guid)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];    //ｸﾞﾘｯﾄﾞより削除ﾚｺｰﾄﾞ情報取得
                string guid = (string)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];    //ｸﾞﾘｯﾄﾞより削除ﾚｺｰﾄﾞ情報取得
                // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
                MoneyKind moneykind = (MoneyKind)this._mnykindTable[guid];                                          //情報をコピー
                int status = this._mnykindAcs.Delete(moneykind);                                                    //削除処理

                switch (status)
				{
					case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
                        this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this.DataIndex].Delete();
                        // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
                        //this._mnykindTable.Remove(moneykind.FileHeaderGuid);
                        this._mnykindTable.Remove(CreateHashKey(moneykind));
                        // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
                        break;
					}
					////////////////////////////////////2005 07.07 H.NAKAMURA ADD STA //////////////
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
					case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
					{
						ExclusiveTransaction(status);
						return ;
					}
					///////////////////////////////////2005 07.07 H.NAKAMURA ADD END //////////////
					default:
					{
						// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
						// 物理削除
						TMsgDisp.Show( 
							this, 								// 親ウィンドウフォーム
							emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
							"SFUKK09040U", 						// アセンブリＩＤまたはクラスＩＤ
							"金額種別設定",　					// プログラム名称
							"Delete_Button_Click", 				// 処理名称
							TMsgDisp.OPE_GET, 					// オペレーション
							"削除に失敗しました。", 			// 表示するメッセージ
							status, 							// ステータス値
							this._mnykindAcs,	 				// エラーが発生したオブジェクト
							MessageBoxButtons.OK, 				// 表示するボタン
							MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
						// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					
						// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//						MessageBox.Show(
//							"削除に失敗しました。 st = " + status.ToString(),
//							"エラー",
//							MessageBoxButtons.OK,
//							MessageBoxIcon.Error,
//							MessageBoxDefaultButton.Button1);
						// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

						return;
					}
				}
			}
			else
			{
				// 2005.09.26 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				this.Delete_Button.Focus();
				// 2005.09.26 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
				return;
			}

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005 07.07 H.NAKAMURA Insert Start
			this._indexBuffer = -2;
			//2005 07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

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
		/// <br>Programmer  : 97134　元村 雅博</br>
		/// <br>Date        : 2005.06.24</br>
        /// <br>UpdateNote : 2008.02.29 96012　日色 馨</br>
        /// <br>           : HashTableのキー変更(FileHeaderGuidの使用禁止)</br>
        /// </remarks>
		private void Revive_Button_Click(object sender, System.EventArgs e)
		{
            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) Begin
            //Guid guid = (Guid)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];
            string guid = (string)this.Bind_DataSet.Tables[MONEYSKIND_TABLE].Rows[this._dataIndex][GUID_TITLE];
            // 2008.02.29 96012 HashTableのキー変更(FileHeaderGuidの使用禁止) end
            MoneyKind moneykind = (MoneyKind)this._mnykindTable[guid];
                
            //復活処理
            int status = this._mnykindAcs.Revival(ref moneykind);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				{
					break;
				}
				////////////////////////////////////2005 07.07 H.NAKAMURA ADD STA //////////////
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
				{
					ExclusiveTransaction(status);
					return ;
				}
				///////////////////////////////////2005 07.07 H.NAKAMURA ADD END //////////////
				
				///////////////////////////////////2005 07.07 H.NAKAMURA DEL STA //////////////
//				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
//				{
//					MessageBox.Show(
//						"既にデータが完全削除されています。" + status.ToString(),
//						"情報",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Information,
//						MessageBoxDefaultButton.Button1);
//
//					break;
//				}
				//////////////////////////////////2005 07.07 H.NAKAMURA DEL END ////////////////
				default:
				{
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					// 復活失敗
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						"SFUKK09040U", 						// アセンブリＩＤまたはクラスＩＤ
						"金額種別設定",　　 				// プログラム名称
						"Revive_Button_Click", 				// 処理名称
						TMsgDisp.OPE_UPDATE, 				// オペレーション
						"復活に失敗しました。", 			// 表示するメッセージ
						status, 							// ステータス値
						this._mnykindAcs, 					// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					
					// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					MessageBox.Show(
//						"復活に失敗しました。 st = " + status.ToString(),
//						"エラー",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
					// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					this.Hide();
					return;
				}
			}


            InsutanceToDataSet(moneykind, this.DataIndex);

			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(DialogResult.OK);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.OK;

			//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>2005 07.07 H.NAKAMURA Insert Start
			this._indexBuffer = -2;
			//2005 07.07 H.NAKAMURA Insert End<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

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
		/// <br>Programmer  : 97134　元村 雅博</br>
		/// <br>Date        : 2005.06.24</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}


		/// <summary>
		/// 金額種別区分テーブ作成処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 金額種別区分テーブを作成します。</br>
		/// <br>Programmer : 97134　元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
        private void SetMnyKindDivTbl()
        {
			MnyKindDivAcs mnyKindDivAcs = new MnyKindDivAcs();
			ArrayList mnyKindDivList;
            mnyKindDivAcs.Search(out mnyKindDivList);

            // 2007.05.17  S.Koga  amend --------------------------------------
            // 金額種別を必須項目にするため、空のデータを削除
            // ----------------------------------------------------------------
            //int[] divCd = new int[mnyKindDivList.Count + 1];
            //string[] divName = new string[ mnyKindDivList.Count + 1 ];
            int[] divCd = new int[mnyKindDivList.Count];
            string[] divName = new string[mnyKindDivList.Count];

            //divCd[0]   = 0;		// 金額種別区分
            //divName[0] = " ";	// 金額種別名称
            //int ix = 1;
            int ix = 0;
            // ----------------------------------------------------------------
			foreach( MnyKindDiv mnyKindDiv in mnyKindDivList )
			{
				divCd[ix]	= mnyKindDiv.MoneyKindDiv;		// 金額種別区分
				divName[ix] = mnyKindDiv.MoneyKindDivName;	// 金額種別名称
				ix++;
			}


//// ------------------------------------------------------>>
//            //TODO:メンテナンスされる方へ   2005.06.22 SFｶｽﾀﾏｲｽﾞ 元村 
//            //     現時点では金額種別区分マスタのリモート部品が無いため、情報の取得はできません。
//            //     リモート部品完成後はここでそのSearchﾒｿｯﾄﾞを使用し全データの取得を行って下さい。           
//            
//            //リモート部品が未完成のためテスト用にデータをセットする
//            //テスト用ロジック
//            string[] divName = {"現金・小切手","振込み","クレジット","手数料","手形","相殺","その他","値引き","預かり金",
//                                 "サービス","持ち込み","クレーム","後日整備"};
//            int[]    divCd    = {101,102,103,104,105,106,107,108,109,
//                                  201,202,203,204};
//// ------------------------------------------------------>>

            
            //変換テーブルへセット
            for(int cnt = 0; cnt <divName.Length ; cnt++) {
                this._mnykindDivTbl.Add(divCd[cnt],   divName[cnt]); //ｺｰﾄﾞをｷｰに名称を値にをセット
            }
        }
		# endregion


        //金額種別区分用構造体
        struct MnyKindDibInf
        {
            public int    mnykinddivCd;
            public string mnykinddivNm;        
        }

        //
		/// <summary>
		/// 金種コード順並び替用クラス
		/// </summary>
		/// <remarks>
		/// <br>Note       : 金種コード順に並び替えます。</br>
		/// <br>Programmer : 97134　元村 雅博</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
        public class IMnyKindDibComp : IComparer  
        {
            int IComparer.Compare( Object x, Object y )  
            {
                return ((MnyKindDibInf)x).mnykinddivCd - ((MnyKindDibInf)y).mnykinddivCd;
            }
        }

	}


}
