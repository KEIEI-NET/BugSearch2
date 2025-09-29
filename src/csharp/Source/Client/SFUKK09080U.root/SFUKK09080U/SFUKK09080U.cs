
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
	/// 請求印刷設定画面クラス
	/// </summary>
	/// <remarks>
	/// <br>Node       : 請求印刷設定を行うクラスです。</br>
	/// <br>Programmer : 23010 中村　仁</br>
	/// <br>Date       : 2005.08.06</br>
	/// <br>Update Note:2005.09.02 22021 谷藤</br> 
	/// <br>            保存確認後のエンターキー押下時のフォーカス対応</br>
	/// <br>Update Note:2005.09.08 22021 谷藤　範幸</br>
	/// <br>			ログイン情報取得部品の組込み</br>
	/// <br>Update Note:2005.09.20 22021 谷藤　範幸</br>
	/// <br>			得意先電話番号印字区分の追加</br>
	/// <br>Update Note:2005.09.22 22021 谷藤　範幸</br>
	/// <br>			メッセージ表示の変更</br>
	/// <br>Update Note: 2005.10.19 22021 谷藤　範幸</br>
	/// <br>		   : ・UI子画面Hide時のOwner.Activate処理追加</br>
	/// <br>Update Note: 2006.01.27 22021 谷藤　範幸</br>
	/// <br>		   : ・請求書印刷一時中断枚数を追加</br>
	/// <br>Update Note: 2006.04.10 23001 秋山　亮介</br>
	/// <br>           : 1.請求書自社プロテクト印刷名称１～４を自社名案内見出し１～４に変更</br>
	/// <br>Update Note: 2006.06.01 23001 秋山　亮介</br>
	/// <br>                        1.集金予定表出力区分を追加</br>
	/// <br>                        2.集金予定表集金予定額（諸費用）を追加</br>
	/// <br>                        3.集金予定表出力タイプを追加</br>
    /// <br>Update Note: 2007.06.27 20031 古賀　小百合</br>
    /// <br>			・画面表示項目名称変更(合計請求書出力区分→請求書(鑑)出力区分)</br>
    /// <br>			・テーブル修正による項目削除</br>
    /// <br>                1.請求前受付出力区分を削除</br>
    /// <br>                2.請求書消費税出力区分を削除</br>
    /// <br>                3.請求書自社プロテクト印刷名称１～４を削除</br>
    /// <br>                4.請求書摘要１、２を削除</br>
    /// <br>                5.集金予定表出力区分を削除</br>
    /// <br>                6.集金予定表集金予定額（諸費用）を削除</br>
    /// <br>                7.集金予定表出力タイプを削除</br>
    /// <br>Update Note: 2007.07.12 20031 古賀　小百合</br>
    /// <br>			・自社名印字区分に項目追加</br>
    /// <br>			・自社名印字区分のコンボボックスデータの扱いを変更</br>
    /// <br>			　（SelectedIndex → SelectedItem）</br>
    /// <br>Update Note: 2008.11.10 30452 上野　俊治</br>
    /// <br>			・以下の項目名称を変更</br>
    /// <br>			・請求書（合計）⇒　請求書出力区分</br>
    /// <br>			・請求書（明細、伝票合計）⇒　領収書出力区分</br>
    /// </remarks>
	public class SFUKK09080UA : System.Windows.Forms.Form, IMasterMaintenanceSingleType
	{	
		# region Private Members (Component)
		private Infragistics.Win.Misc.UltraButton Ok_Button;
		private Infragistics.Win.Misc.UltraButton Cancel_Button;
		private Infragistics.Win.UltraWinStatusBar.UltraStatusBar ultraStatusBar1;
        private Infragistics.Win.Misc.UltraLabel Mode_Label;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.Windows.Forms.Timer Initial_Timer;
		private Broadleaf.Library.Windows.Forms.THtmlGenerate tHtmlGenerate1;
		private System.Windows.Forms.GroupBox ChangeNumber_groupBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private Broadleaf.Library.Windows.Forms.TComboEditor BillTableOutCd_tComboEditor;
		private Broadleaf.Library.Windows.Forms.TComboEditor TotalBillOutputDiv_tComboEditor;
        private Broadleaf.Library.Windows.Forms.TComboEditor DetailBillOutputCode_tComboEditor;
        private Broadleaf.Library.Windows.Forms.TComboEditor BillLastDayPrtDiv_tComboEditor;
		private Broadleaf.Library.Windows.Forms.TComboEditor BillCoNmPrintOutCd_tComboEditor;
		private Broadleaf.Library.Windows.Forms.TComboEditor BillBankNmPrintOut_tComboEditor;
        private Infragistics.Win.Misc.UltraLabel BillTableOutCd_ultraLabel;
        private Infragistics.Win.Misc.UltraLabel BillLastDayPrtDiv_ultraLabel;
		private Infragistics.Win.Misc.UltraLabel BillBankNmPrintOut_ultraLabel;
        private Infragistics.Win.Misc.UltraLabel BillCoNmPrintOutCd_ultraLabel;
		private Infragistics.Win.Misc.UltraLabel TotalBillOutputDiv_ultraLabel;
		private Infragistics.Win.Misc.UltraLabel DetailBillOutputCode_ultraLaｂel;
		private Infragistics.Win.Misc.UltraLabel CustTelNoPrtDivCd_ultraLabel;
        private Broadleaf.Library.Windows.Forms.TComboEditor CustTelNoPrtDivCd_tComboEditor;
        private TArrowKeyControl tArrowKeyControl1;
		private System.ComponentModel.IContainer components;
		#endregion 
		
		# region Constructor
		/// <summary>
		/// 請求印刷設定画面クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note		: 請求印刷設定画面クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer	: 23010 中村　仁</br>
		/// <br>Date		: 2005.08.06</br>
		/// </remarks>
		public SFUKK09080UA()
		{
			InitializeComponent();

			// billPrtStクラスアクセスクラス
			this.billPrtStAcs = new BillPrtStAcs() ;

			// billPrtStクラス
			this.billPrtSt = new BillPrtSt();


			//　企業コードを取得する
			// 2005.09.08 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//			this._enterpriseCode = "TBS1";	// ← 要変更
			// 2005.09.08 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// 2005.09.08 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
			// 2005.09.08 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			// 印刷可能フラグを設定します。
			// Frameの印刷ボタンの表示非表示の制御に使用します。
			_canPrint = false;

			// 画面クローズ許可を設定します。
			// CloseかHideかの制御に使用します。
			_canClose = false;

		}
		#endregion
		
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
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance25 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance26 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance28 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance29 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance17 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance31 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance32 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance20 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance22 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance23 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance33 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance34 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance15 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance16 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance18 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance19 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKK09080UA));
            this.BillTableOutCd_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.Ok_Button = new Infragistics.Win.Misc.UltraButton();
            this.Cancel_Button = new Infragistics.Win.Misc.UltraButton();
            this.ultraStatusBar1 = new Infragistics.Win.UltraWinStatusBar.UltraStatusBar();
            this.Mode_Label = new Infragistics.Win.Misc.UltraLabel();
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            this.Initial_Timer = new System.Windows.Forms.Timer(this.components);
            this.tHtmlGenerate1 = new Broadleaf.Library.Windows.Forms.THtmlGenerate(this.components);
            this.BillTableOutCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.TotalBillOutputDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.DetailBillOutputCode_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.BillLastDayPrtDiv_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.BillLastDayPrtDiv_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.ChangeNumber_groupBox = new System.Windows.Forms.GroupBox();
            this.TotalBillOutputDiv_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.DetailBillOutputCode_ultraLaｂel = new Infragistics.Win.Misc.UltraLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CustTelNoPrtDivCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.CustTelNoPrtDivCd_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.BillBankNmPrintOut_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.BillCoNmPrintOutCd_ultraLabel = new Infragistics.Win.Misc.UltraLabel();
            this.BillCoNmPrintOutCd_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.BillBankNmPrintOut_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BillTableOutCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalBillOutputDiv_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailBillOutputCode_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillLastDayPrtDiv_tComboEditor)).BeginInit();
            this.ChangeNumber_groupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustTelNoPrtDivCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillCoNmPrintOutCd_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillBankNmPrintOut_tComboEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // BillTableOutCd_ultraLabel
            // 
            appearance1.TextHAlignAsString = "Left";
            appearance1.TextVAlignAsString = "Middle";
            this.BillTableOutCd_ultraLabel.Appearance = appearance1;
            this.BillTableOutCd_ultraLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BillTableOutCd_ultraLabel.Location = new System.Drawing.Point(24, 32);
            this.BillTableOutCd_ultraLabel.Name = "BillTableOutCd_ultraLabel";
            this.BillTableOutCd_ultraLabel.Size = new System.Drawing.Size(184, 25);
            this.BillTableOutCd_ultraLabel.TabIndex = 3;
            this.BillTableOutCd_ultraLabel.Text = "請求一覧表";
            // 
            // Ok_Button
            // 
            this.Ok_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Ok_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Ok_Button.Location = new System.Drawing.Point(255, 366);
            this.Ok_Button.Name = "Ok_Button";
            this.Ok_Button.Size = new System.Drawing.Size(125, 34);
            this.Ok_Button.TabIndex = 4;
            this.Ok_Button.Text = "保存(&S)";
            this.Ok_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Ok_Button.Click += new System.EventHandler(this.Ok_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Cancel_Button.ImageSize = new System.Drawing.Size(24, 24);
            this.Cancel_Button.Location = new System.Drawing.Point(385, 366);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(125, 34);
            this.Cancel_Button.TabIndex = 5;
            this.Cancel_Button.Text = "閉じる(&X)";
            this.Cancel_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // ultraStatusBar1
            // 
            this.ultraStatusBar1.Location = new System.Drawing.Point(0, 406);
            this.ultraStatusBar1.Name = "ultraStatusBar1";
            this.ultraStatusBar1.Size = new System.Drawing.Size(527, 23);
            this.ultraStatusBar1.TabIndex = 8;
            this.ultraStatusBar1.ViewStyle = Infragistics.Win.UltraWinStatusBar.ViewStyle.Office2003;
            // 
            // Mode_Label
            // 
            appearance2.ForeColor = System.Drawing.Color.White;
            appearance2.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance2.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance2.TextHAlignAsString = "Center";
            appearance2.TextVAlignAsString = "Middle";
            this.Mode_Label.Appearance = appearance2;
            this.Mode_Label.BackColorInternal = System.Drawing.Color.Navy;
            this.Mode_Label.BorderStyleInner = Infragistics.Win.UIElementBorderStyle.None;
            this.Mode_Label.BorderStyleOuter = Infragistics.Win.UIElementBorderStyle.None;
            appearance3.ImageHAlign = Infragistics.Win.HAlign.Center;
            appearance3.ImageVAlign = Infragistics.Win.VAlign.Middle;
            appearance3.TextHAlignAsString = "Center";
            appearance3.TextVAlignAsString = "Middle";
            this.Mode_Label.HotTrackAppearance = appearance3;
            this.Mode_Label.Location = new System.Drawing.Point(395, 10);
            this.Mode_Label.Name = "Mode_Label";
            this.Mode_Label.Size = new System.Drawing.Size(115, 24);
            this.Mode_Label.TabIndex = 6;
            this.Mode_Label.Text = "更新モード";
            // 
            // tRetKeyControl1
            // 
            this.tRetKeyControl1.OwnerForm = this;
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
            // BillTableOutCd_tComboEditor
            // 
            appearance8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BillTableOutCd_tComboEditor.ActiveAppearance = appearance8;
            appearance25.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance25.ForeColorDisabled = System.Drawing.Color.Black;
            this.BillTableOutCd_tComboEditor.Appearance = appearance25;
            this.BillTableOutCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.BillTableOutCd_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BillTableOutCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BillTableOutCd_tComboEditor.ItemAppearance = appearance26;
            this.BillTableOutCd_tComboEditor.Location = new System.Drawing.Point(208, 33);
            this.BillTableOutCd_tComboEditor.MaxDropDownItems = 18;
            this.BillTableOutCd_tComboEditor.Name = "BillTableOutCd_tComboEditor";
            this.BillTableOutCd_tComboEditor.Size = new System.Drawing.Size(264, 24);
            this.BillTableOutCd_tComboEditor.TabIndex = 0;
            // 
            // TotalBillOutputDiv_tComboEditor
            // 
            appearance14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TotalBillOutputDiv_tComboEditor.ActiveAppearance = appearance14;
            appearance28.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance28.ForeColorDisabled = System.Drawing.Color.Black;
            this.TotalBillOutputDiv_tComboEditor.Appearance = appearance28;
            this.TotalBillOutputDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.TotalBillOutputDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.TotalBillOutputDiv_tComboEditor.ItemAppearance = appearance29;
            this.TotalBillOutputDiv_tComboEditor.Location = new System.Drawing.Point(208, 65);
            this.TotalBillOutputDiv_tComboEditor.MaxDropDownItems = 18;
            this.TotalBillOutputDiv_tComboEditor.Name = "TotalBillOutputDiv_tComboEditor";
            this.TotalBillOutputDiv_tComboEditor.Size = new System.Drawing.Size(264, 24);
            this.TotalBillOutputDiv_tComboEditor.TabIndex = 1;
            // 
            // DetailBillOutputCode_tComboEditor
            // 
            appearance17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DetailBillOutputCode_tComboEditor.ActiveAppearance = appearance17;
            appearance31.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance31.ForeColorDisabled = System.Drawing.Color.Black;
            this.DetailBillOutputCode_tComboEditor.Appearance = appearance31;
            this.DetailBillOutputCode_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DetailBillOutputCode_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance32.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DetailBillOutputCode_tComboEditor.ItemAppearance = appearance32;
            this.DetailBillOutputCode_tComboEditor.Location = new System.Drawing.Point(208, 97);
            this.DetailBillOutputCode_tComboEditor.MaxDropDownItems = 18;
            this.DetailBillOutputCode_tComboEditor.Name = "DetailBillOutputCode_tComboEditor";
            this.DetailBillOutputCode_tComboEditor.Size = new System.Drawing.Size(264, 24);
            this.DetailBillOutputCode_tComboEditor.TabIndex = 2;
            // 
            // BillLastDayPrtDiv_ultraLabel
            // 
            appearance20.TextHAlignAsString = "Left";
            appearance20.TextVAlignAsString = "Middle";
            this.BillLastDayPrtDiv_ultraLabel.Appearance = appearance20;
            this.BillLastDayPrtDiv_ultraLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BillLastDayPrtDiv_ultraLabel.Location = new System.Drawing.Point(24, 24);
            this.BillLastDayPrtDiv_ultraLabel.Name = "BillLastDayPrtDiv_ultraLabel";
            this.BillLastDayPrtDiv_ultraLabel.Size = new System.Drawing.Size(184, 25);
            this.BillLastDayPrtDiv_ultraLabel.TabIndex = 13;
            this.BillLastDayPrtDiv_ultraLabel.Text = "末日印字設定";
            // 
            // BillLastDayPrtDiv_tComboEditor
            // 
            appearance7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BillLastDayPrtDiv_tComboEditor.ActiveAppearance = appearance7;
            appearance22.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance22.ForeColorDisabled = System.Drawing.Color.Black;
            this.BillLastDayPrtDiv_tComboEditor.Appearance = appearance22;
            this.BillLastDayPrtDiv_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.BillLastDayPrtDiv_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BillLastDayPrtDiv_tComboEditor.ItemAppearance = appearance23;
            this.BillLastDayPrtDiv_tComboEditor.Location = new System.Drawing.Point(208, 25);
            this.BillLastDayPrtDiv_tComboEditor.MaxDropDownItems = 18;
            this.BillLastDayPrtDiv_tComboEditor.Name = "BillLastDayPrtDiv_tComboEditor";
            this.BillLastDayPrtDiv_tComboEditor.Size = new System.Drawing.Size(232, 24);
            this.BillLastDayPrtDiv_tComboEditor.TabIndex = 1;
            // 
            // ChangeNumber_groupBox
            // 
            this.ChangeNumber_groupBox.Controls.Add(this.BillTableOutCd_tComboEditor);
            this.ChangeNumber_groupBox.Controls.Add(this.TotalBillOutputDiv_tComboEditor);
            this.ChangeNumber_groupBox.Controls.Add(this.DetailBillOutputCode_tComboEditor);
            this.ChangeNumber_groupBox.Controls.Add(this.BillTableOutCd_ultraLabel);
            this.ChangeNumber_groupBox.Controls.Add(this.TotalBillOutputDiv_ultraLabel);
            this.ChangeNumber_groupBox.Controls.Add(this.DetailBillOutputCode_ultraLaｂel);
            this.ChangeNumber_groupBox.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ChangeNumber_groupBox.Location = new System.Drawing.Point(16, 40);
            this.ChangeNumber_groupBox.Name = "ChangeNumber_groupBox";
            this.ChangeNumber_groupBox.Size = new System.Drawing.Size(494, 136);
            this.ChangeNumber_groupBox.TabIndex = 0;
            this.ChangeNumber_groupBox.TabStop = false;
            this.ChangeNumber_groupBox.Text = "印刷出力金額区分";
            // 
            // TotalBillOutputDiv_ultraLabel
            // 
            appearance33.TextHAlignAsString = "Left";
            appearance33.TextVAlignAsString = "Middle";
            this.TotalBillOutputDiv_ultraLabel.Appearance = appearance33;
            this.TotalBillOutputDiv_ultraLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TotalBillOutputDiv_ultraLabel.Location = new System.Drawing.Point(24, 64);
            this.TotalBillOutputDiv_ultraLabel.Name = "TotalBillOutputDiv_ultraLabel";
            this.TotalBillOutputDiv_ultraLabel.Size = new System.Drawing.Size(184, 25);
            this.TotalBillOutputDiv_ultraLabel.TabIndex = 4;
            this.TotalBillOutputDiv_ultraLabel.Text = "請求書出力区分";
            // 
            // DetailBillOutputCode_ultraLaｂel
            // 
            appearance34.TextHAlignAsString = "Left";
            appearance34.TextVAlignAsString = "Middle";
            this.DetailBillOutputCode_ultraLaｂel.Appearance = appearance34;
            this.DetailBillOutputCode_ultraLaｂel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DetailBillOutputCode_ultraLaｂel.Location = new System.Drawing.Point(24, 96);
            this.DetailBillOutputCode_ultraLaｂel.Name = "DetailBillOutputCode_ultraLaｂel";
            this.DetailBillOutputCode_ultraLaｂel.Size = new System.Drawing.Size(231, 25);
            this.DetailBillOutputCode_ultraLaｂel.TabIndex = 5;
            this.DetailBillOutputCode_ultraLaｂel.Text = "領収書出力区分";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CustTelNoPrtDivCd_tComboEditor);
            this.groupBox1.Controls.Add(this.CustTelNoPrtDivCd_ultraLabel);
            this.groupBox1.Controls.Add(this.BillBankNmPrintOut_ultraLabel);
            this.groupBox1.Controls.Add(this.BillCoNmPrintOutCd_ultraLabel);
            this.groupBox1.Controls.Add(this.BillCoNmPrintOutCd_tComboEditor);
            this.groupBox1.Controls.Add(this.BillBankNmPrintOut_tComboEditor);
            this.groupBox1.Controls.Add(this.BillLastDayPrtDiv_ultraLabel);
            this.groupBox1.Controls.Add(this.BillLastDayPrtDiv_tComboEditor);
            this.groupBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(16, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(494, 160);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "請求書";
            // 
            // CustTelNoPrtDivCd_tComboEditor
            // 
            appearance4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustTelNoPrtDivCd_tComboEditor.ActiveAppearance = appearance4;
            appearance9.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance9.ForeColorDisabled = System.Drawing.Color.Black;
            this.CustTelNoPrtDivCd_tComboEditor.Appearance = appearance9;
            this.CustTelNoPrtDivCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.CustTelNoPrtDivCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.CustTelNoPrtDivCd_tComboEditor.ItemAppearance = appearance10;
            this.CustTelNoPrtDivCd_tComboEditor.Location = new System.Drawing.Point(208, 121);
            this.CustTelNoPrtDivCd_tComboEditor.MaxDropDownItems = 18;
            this.CustTelNoPrtDivCd_tComboEditor.Name = "CustTelNoPrtDivCd_tComboEditor";
            this.CustTelNoPrtDivCd_tComboEditor.Size = new System.Drawing.Size(147, 24);
            this.CustTelNoPrtDivCd_tComboEditor.TabIndex = 9;
            // 
            // CustTelNoPrtDivCd_ultraLabel
            // 
            appearance11.TextHAlignAsString = "Left";
            appearance11.TextVAlignAsString = "Middle";
            this.CustTelNoPrtDivCd_ultraLabel.Appearance = appearance11;
            this.CustTelNoPrtDivCd_ultraLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CustTelNoPrtDivCd_ultraLabel.Location = new System.Drawing.Point(24, 120);
            this.CustTelNoPrtDivCd_ultraLabel.Name = "CustTelNoPrtDivCd_ultraLabel";
            this.CustTelNoPrtDivCd_ultraLabel.Size = new System.Drawing.Size(184, 25);
            this.CustTelNoPrtDivCd_ultraLabel.TabIndex = 22;
            this.CustTelNoPrtDivCd_ultraLabel.Text = "得意先電話番号印字区分";
            // 
            // BillBankNmPrintOut_ultraLabel
            // 
            appearance12.TextHAlignAsString = "Left";
            appearance12.TextVAlignAsString = "Middle";
            this.BillBankNmPrintOut_ultraLabel.Appearance = appearance12;
            this.BillBankNmPrintOut_ultraLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BillBankNmPrintOut_ultraLabel.Location = new System.Drawing.Point(24, 88);
            this.BillBankNmPrintOut_ultraLabel.Name = "BillBankNmPrintOut_ultraLabel";
            this.BillBankNmPrintOut_ultraLabel.Size = new System.Drawing.Size(184, 25);
            this.BillBankNmPrintOut_ultraLabel.TabIndex = 21;
            this.BillBankNmPrintOut_ultraLabel.Text = "銀行名印字区分";
            // 
            // BillCoNmPrintOutCd_ultraLabel
            // 
            appearance13.TextHAlignAsString = "Left";
            appearance13.TextVAlignAsString = "Middle";
            this.BillCoNmPrintOutCd_ultraLabel.Appearance = appearance13;
            this.BillCoNmPrintOutCd_ultraLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BillCoNmPrintOutCd_ultraLabel.Location = new System.Drawing.Point(24, 56);
            this.BillCoNmPrintOutCd_ultraLabel.Name = "BillCoNmPrintOutCd_ultraLabel";
            this.BillCoNmPrintOutCd_ultraLabel.Size = new System.Drawing.Size(184, 25);
            this.BillCoNmPrintOutCd_ultraLabel.TabIndex = 20;
            this.BillCoNmPrintOutCd_ultraLabel.Text = "自社名印字区分";
            // 
            // BillCoNmPrintOutCd_tComboEditor
            // 
            appearance5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BillCoNmPrintOutCd_tComboEditor.ActiveAppearance = appearance5;
            appearance15.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance15.ForeColorDisabled = System.Drawing.Color.Black;
            this.BillCoNmPrintOutCd_tComboEditor.Appearance = appearance15;
            this.BillCoNmPrintOutCd_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.BillCoNmPrintOutCd_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BillCoNmPrintOutCd_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BillCoNmPrintOutCd_tComboEditor.ItemAppearance = appearance16;
            this.BillCoNmPrintOutCd_tComboEditor.Location = new System.Drawing.Point(208, 57);
            this.BillCoNmPrintOutCd_tComboEditor.MaxDropDownItems = 18;
            this.BillCoNmPrintOutCd_tComboEditor.Name = "BillCoNmPrintOutCd_tComboEditor";
            this.BillCoNmPrintOutCd_tComboEditor.Size = new System.Drawing.Size(192, 24);
            this.BillCoNmPrintOutCd_tComboEditor.TabIndex = 7;
            // 
            // BillBankNmPrintOut_tComboEditor
            // 
            appearance6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BillBankNmPrintOut_tComboEditor.ActiveAppearance = appearance6;
            appearance18.BackColorDisabled = System.Drawing.SystemColors.Control;
            appearance18.ForeColorDisabled = System.Drawing.Color.Black;
            this.BillBankNmPrintOut_tComboEditor.Appearance = appearance18;
            this.BillBankNmPrintOut_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.BillBankNmPrintOut_tComboEditor.ImeMode = System.Windows.Forms.ImeMode.Disable;
            appearance19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.BillBankNmPrintOut_tComboEditor.ItemAppearance = appearance19;
            this.BillBankNmPrintOut_tComboEditor.Location = new System.Drawing.Point(208, 89);
            this.BillBankNmPrintOut_tComboEditor.MaxDropDownItems = 18;
            this.BillBankNmPrintOut_tComboEditor.Name = "BillBankNmPrintOut_tComboEditor";
            this.BillBankNmPrintOut_tComboEditor.Size = new System.Drawing.Size(147, 24);
            this.BillBankNmPrintOut_tComboEditor.TabIndex = 8;
            // 
            // tArrowKeyControl1
            // 
            this.tArrowKeyControl1.OwnerForm = this;
            // 
            // SFUKK09080UA
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(527, 429);
            this.Controls.Add(this.ultraStatusBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ChangeNumber_groupBox);
            this.Controls.Add(this.Mode_Label);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.Ok_Button);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SFUKK09080UA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "請求初期値設定";
            this.Load += new System.EventHandler(this.SFUKK09080UA_Load);
            this.VisibleChanged += new System.EventHandler(this.SFUKK09080UA_VisibleChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.SFUKK09080UA_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.BillTableOutCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TotalBillOutputDiv_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailBillOutputCode_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillLastDayPrtDiv_tComboEditor)).EndInit();
            this.ChangeNumber_groupBox.ResumeLayout(false);
            this.ChangeNumber_groupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CustTelNoPrtDivCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillCoNmPrintOutCd_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BillBankNmPrintOut_tComboEditor)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		#region Main
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFUKK09080UA());
		}
		#endregion 

		#region Private Members

		//請求印刷データクラス
		private BillPrtSt billPrtSt;
		//請求印刷アクセスクラス
		private BillPrtStAcs billPrtStAcs;
		// 企業コード
		private string _enterpriseCode;
		// 比較用clone
		private BillPrtSt _billPrtStClone;
		// プロパティ用
		private bool _canPrint;
		private bool _canClose;
		//フレームのタイトル
		private const string HTML_HEADER_TITLE	= "設定項目";
		private const string HTML_HEADER_VALUE	= "設定値";
		//未設定の場合
		private const string HTML_UNREGISTER	= "未設定";
		// 編集モード
		private const string UPDATE_MODE		= "更新モード";

        // 2007.07.12  S.Koga  ADD --------------------------------------------
        //private const string BILLCONMPRINTOUTCD_MYIMAGE = "自社画像で印刷する";  // DEL 2008/06/13
        // --------------------------------------------------------------------

        // --- ADD 2008/06/13 -------------------------------->>>>>
        private const string BILLCONMPRINTOUTCD_OWN     = "自社名";
        private const string BILLCONMPRINTOUTCD_SECTION = "拠点名";
        private const string BILLCONMPRINTOUTCD_BITMAP  = "ビットマップ";
        private const string BILLCONMPRINTOUTCD_NO      = "印字しない";
        // --- ADD 2008/06/13 --------------------------------<<<<< 

		#endregion

		# region Events
		/// <summary>
		/// 画面非表示イベント
		/// </summary>
		/// <remarks>
		/// 画面が非表示状態になった際に発生します。
		/// </remarks>
		public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;
		# endregion

		# region Properties
		/// <summary>
		/// 印刷プロパティ
		/// </summary>
		/// <remarks>
		/// 印刷可能かどうかの設定を取得します。（false固定）
		/// </remarks>
		public bool CanPrint
		{
			get{ return _canPrint; }
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
			get{ return _canClose; }
			set{ _canClose = value; }
		}
		# endregion
		
		#region public Method
		/// <summary>
		///	印刷処理
		/// </summary>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note			:	（未実装）</br>
		/// <br>Programmer		:	23010 中村　仁</br>
		/// <br>Date			:	2005.08.06</br>
		/// </remarks>
		public int Print()
		{
			// 印刷用アセンブリをロードする（未実装）
			return 0;
		}

		/// <summary>
		///	HTMLコード取得処理
		/// </summary>
		/// <returns>HTMLコード</returns>
		/// <remarks>
		/// <br>Note			:	フレーム用のＨＴＭＬコードを取得します。</br>
		/// <br>Programmer		:	23010 中村　仁</br>
		/// <br>Date			:	2005.08.06</br>
		/// </remarks>
		public string GetHtmlCode()
		{
			string outCode = "";

			// tHtmlGenerate部品の引数を生成する
// 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            // 2007.06.27  S.Koga  amend --------------------------------------
            //string [,] array = new string[20,2];
            //string[,] array = new string[9, 2];  // DEL 2008/06/13
            string[,] array = new string[8, 2];  // ADD 2008/06/13
            // ----------------------------------------------------------------
// 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
// 2006.06.01 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//string [,] array = new string[17,2];
// 2006.06.01 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

			this.tHtmlGenerate1.Coltypes = new int[2];

			this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
			this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;
				
			array[0,0]	= HTML_HEADER_TITLE;										//「設定項目」
			array[0,1]	= HTML_HEADER_VALUE;										//「設定値」

			array[1,0]	= this.BillTableOutCd_ultraLabel.Text + "出力区分";			// 請求一覧表出力区分
            //array[2,0]	= this.TotalBillOutputDiv_ultraLabel.Text +"出力区分";		// 請求書(鑑)出力区分 // DEL 2008/11/10
            //array[3,0]	= this.DetailBillOutputCode_ultraLaｂel.Text + "出力区分";　　// 明細請求書出力区分 // DEL 2008/11/10
            array[2, 0] = this.TotalBillOutputDiv_ultraLabel.Text;		// 請求書(鑑)出力区分 // ADD 2008/11/10
            array[3, 0] = this.DetailBillOutputCode_ultraLaｂel.Text;　　// 明細請求書出力区分 // ADD 2008/11/10
            # region 2007.06.27  S.Koga  DEL
            //array[4,0]	= this.BillBfRmonOutltem_ultraLabel.Text;					// 請求前受金出力項目
            # endregion
// 2006.04.10 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            # region 2007.06.27  S.Koga  DEL
            //array[5,0]	= this.BillConstTaxOutPutCd_ultraLabel.Text;				// 請求書消費税出力区分
            # endregion
            //array[6, 0] = this.BillLastDayPrtDiv_ultraLabel.Text;					// 請求書末日印字区分
            array[4, 0] = this.BillLastDayPrtDiv_ultraLabel.Text;					// 請求書末日印字区分
            # region 2007.06.27  S.Koga  DEL
            //array[7,0]	= this.BillEpProtectPrtNm1_ultraLabel.Text;					// 請求書自社プロテクト印刷名称1
            //array[8,0]	= this.BillEpProtectPrtNm2_ultraLabel.Text;					// 請求書自社プロテクト印刷名称2
            //array[9,0]	= this.BillEpProtectPrtNm3_ultraLabel.Text;					// 請求書自社プロテクト印刷名称3
            //array[10,0] = this.BillEpProtectPrtNm4_ultraLabel.Text;					// 請求書自社プロテクト印刷名称4
            # endregion
            //array[11,0] = this.BillPrtSuspendCnt_ultraLabel.Text;					// 請求書印刷一時中断枚数
            //array[5, 0] = this.BillPrtSuspendCnt_ultraLabel.Text;					// 請求書印刷一時中断枚数  // DEL 2008/06/13
            //array[12,0] = this.BillCoNmPrintOutCd_ultraLabel.Text;					// 請求書自社名印字区分
            array[5, 0] = this.BillCoNmPrintOutCd_ultraLabel.Text;					// 請求書自社名印字区分
            //array[13,0] = this.BillBankNmPrintOut_ultraLabel.Text;					// 請求書銀行名印字区分
            array[6, 0] = this.BillBankNmPrintOut_ultraLabel.Text;					// 請求書銀行名印字区分
            //array[14,0] = this.CustTelNoPrtDivCd_ultraLabel.Text;					// 得意先電話番号印字区分
            array[7, 0] = this.CustTelNoPrtDivCd_ultraLabel.Text;					// 得意先電話番号印字区分
            # region 2007.06.27  S.Koga  DEL
            //array[15,0] = this.BillOutline1_ultraLabel.Text;						// 請求書摘要1
            //array[16,0] = this.BillOutline2_ultraLabel.Text;						// 請求書摘要2
            # endregion
// 2006.04.10 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
// 2006.04.10 AKIYAMA DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//			array[5,0]	= "請求書"+this.BillConstTaxOutPutCd_ultraLabel.Text;		// 請求書消費税出力区分
//			array[6,0]	= "請求書"+this.BillLastDayPrtDiv_ultraLabel.Text;			// 請求書末日印字区分
//			array[7,0]	= "請求書"+this.BillEpProtectPrtNm1_ultraLabel.Text;		// 請求書自社プロテクト印刷名称1
//			array[8,0]	= "請求書"+this.BillEpProtectPrtNm2_ultraLabel.Text;		// 請求書自社プロテクト印刷名称2
//			array[9,0]	= "請求書"+this.BillEpProtectPrtNm3_ultraLabel.Text;		// 請求書自社プロテクト印刷名称3
//			array[10,0] = "請求書"+this.BillEpProtectPrtNm4_ultraLabel.Text;		// 請求書自社プロテクト印刷名称4
//			// 2005.09.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//			array[11,0] = "請求書"+this.BillPrtSuspendCnt_ultraLabel.Text;			// 請求書印刷一時中断枚数
//			// 2005.09.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
//			array[12,0] = "請求書"+this.BillCoNmPrintOutCd_ultraLabel.Text;			// 請求書自社名印字区分
//			array[13,0] = "請求書"+this.BillBankNmPrintOut_ultraLabel.Text;			// 請求書銀行名印字区分
//			
//			// 2005.09.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//			array[14,0] = this.CustTelNoPrtDivCd_ultraLabel.Text;					// 得意先電話番号印字区分
//			// 2005.09.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
//			
//			array[15,0] = "請求書"+this.BillOutline1_ultraLabel.Text;				// 請求書摘要1
//			array[16,0] = "請求書"+this.BillOutline2_ultraLabel.Text;				// 請求書摘要2
// 2006.04.10 AKIYAMA DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            # region 2007.06.27  S.Koga  DEL
            // 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            //array[ 17, 0 ] = this.ClctMnyPlnDocOutType_Title_Label.Text;            // 集金予定表出力タイプ
            //array[ 18, 0 ] = this.ClctMnyPlnDocVarCst_Title_Label.Text;             // 集金予定表集金予定額（諸費用）
            //array[ 19, 0 ] = this.ClctMnyPlnDocOutCd_Title_Label.Text;              // 集金予定表出力区分
            // 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            # endregion

            //データ読み込み															
			int status = this.billPrtStAcs.Read(out billPrtSt,this._enterpriseCode);
			if (status == 0)
			{	
				// 請求一覧表出力区分
				switch(billPrtSt.BillTableOutCd)
				{
					case 0:
						array[1,1] = "全て出力";
						break;
					case 1:
						array[1,1] = "０とプラス金額を出力";
						break;
					case 2:
						array[1,1] = "プラス金額のみ出力";
						break;
					case 3:
						array[1,1] = "０のみ出力";
						break;
					case 4:
						array[1,1] = "プラス金額とマイナス金額を出力";
						break;
					case 5:
						array[1,1] = "０とマイナス金額を出力";
						break;
					case 6:
						array[1,1] = "マイナス金額のみ出力";
						break;
					default:
						array[1,1] = HTML_UNREGISTER;
						break;
				}
				// 請求書(合計)出力区分
				switch(billPrtSt.TotalBillOutputDiv)
				{
					case 0:
						array[2,1] = "全て出力";
						break;
					case 1:
						array[2,1] = "０とプラス金額を出力";
						break;
					case 2:
						array[2,1] = "プラス金額のみ出力";
						break;
					case 3:
						array[2,1] = "０のみ出力";
						break;
					case 4:
						array[2,1] = "プラス金額とマイナス金額を出力";
						break;
					case 5:
						array[2,1] = "０とマイナス金額を出力";
						break;
					case 6:
						array[2,1] = "マイナス金額のみ出力";
						break;
					default:
						array[2,1] = HTML_UNREGISTER;
						break;
				}
				// 請求書(明細、伝票合計)出力区分
				switch(billPrtSt.DetailBillOutputCode)
				{
					case 0:
						array[3,1] = "全て出力";
						break;
					case 1:
						array[3,1] = "０とプラス金額を出力";
						break;
					case 2:
						array[3,1] = "プラス金額のみ出力";
						break;
					case 3:
						array[3,1] = "０のみ出力";
						break;
					case 4:
						array[3,1] = "プラス金額とマイナス金額を出力";
						break;
					case 5:
						array[3,1] = "０とマイナス金額を出力";
						break;
					case 6:
						array[3,1] = "マイナス金額のみ出力";
						break;
					default:
						array[3,1] = HTML_UNREGISTER;
						break;
                }
                # region 2007.06.27  S.Koga  DEL
                //// 請求書前受金出力項目
                //switch(billPrtSt.BillBfRmonOutItem)
                //{
                //    case 0:
                //        array[4,1] = "前受金";
                //        break;
                //    case 1:
                //        array[4,1] = "今回入金";
                //        break;
                //    default:
                //        array[4,1] = HTML_UNREGISTER;
                //        break;
                //}
                //// 請求書消費税出力区分
                //switch(billPrtSt.BillConsTaxOutPutCd)
                //{
                //    case 0:
                //        array[5,1] = "消費税別";
                //        break;
                //    case 1:
                //        array[5,1] = "消費税込み";
                //        break;
                //    default:
                //        array[5,1] = HTML_UNREGISTER;
                //        break;
                //}
                # endregion
                // 請求書末日印字区分
				switch(billPrtSt.BillLastDayPrtDiv)
				{
					case 0:
                        //array[6,1] = "数値印字";
                        array[4, 1] = "数値印字";
                        break;
					case 1:
                        //array[6,1] = "２８～３１日は末日と印字";
                        array[4, 1] = "２８～３１日は末日と印字";
                        break;
					default:
                        //array[6,1] = HTML_UNREGISTER;
                        array[4, 1] = HTML_UNREGISTER;
                        break;
				}
                # region 2007.06.27  S.Koga  DEL
                //// 請求書自社プロテクト印刷名称
                //array[7,1]  =  billPrtSt.BillEpProtectPrtNm1;
                //array[8,1]  =  billPrtSt.BillEpProtectPrtNm2;
                //array[9,1]  =  billPrtSt.BillEpProtectPrtNm3;
                //array[10,1] =  billPrtSt.BillEpProtectPrtNm4;　	　 
                # endregion
                // 請求書印刷一時中断枚数
                //array[11,1] =  billPrtSt.BillPrtSuspendCnt.ToString(); 
                //array[5, 1] = billPrtSt.BillPrtSuspendCnt.ToString();  // DEL 2008/06/13

                // 請求書自社名印字区分
				switch(billPrtSt.BillCoNmPrintOutCd)
				{
					case 0:
                        //array[12,1] = "印字する";
                        //array[5, 1] = "印字する";  // DEL 2008/06/13
                        array[5, 1] = BILLCONMPRINTOUTCD_OWN;  // ADD 2008/06/13
                        break;
					case 1:
                        //array[12,1] = "印字しない";
                        //array[5, 1] = "印字しない";  // DEL 2008/06/13
                        array[5, 1] = BILLCONMPRINTOUTCD_SECTION;  // ADD 2008/06/13
                        break;
                    // 2007.07.12  S.Koga  ADD --------------------------------
                    case 2:
                        //array[5, 1] = BILLCONMPRINTOUTCD_MYIMAGE;  // DEL 2008/06/13
                        array[5, 1] = BILLCONMPRINTOUTCD_BITMAP;  // ADD 2008/06/13
                        break;
                    // --------------------------------------------------------
                    // --- ADD 2008/06/13 -------------------------------->>>>>
                    case 3:
                        array[5, 1] = BILLCONMPRINTOUTCD_NO;
                        break;
                    // --- ADD 2008/06/13 --------------------------------<<<<< 
                    default:
                        //array[12,1] = HTML_UNREGISTER;
                        array[5, 1] = HTML_UNREGISTER;
                        break;
				}
				// 請求書銀行名印字区分
				switch(billPrtSt.BillBankNmPrintOut)
				{
					case 0:
                        //array[13,1] = "印字する";
                        array[6, 1] = "印字する";
                        break;
					case 1:
                        //array[13,1] = "印字しない";
                        array[6, 1] = "印字しない";
                        break;
					default:
                        //array[13,1] = HTML_UNREGISTER;
                        array[6, 1] = HTML_UNREGISTER;
                        break;
				}
				
				// 2005.09.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				// 得意先電話番号印字区分
				switch(billPrtSt.CustTelNoPrtDivCd)
				{
					case 0:
                        //array[14,1] = "印字しない";
                        array[7, 1] = "印字しない"; 
                        break;
					case 1:
                        //array[14,1] = "印字する";
                        array[7, 1] = "印字する";
                        break;
					default:
						//array[14,1] = HTML_UNREGISTER;
                        array[7, 1] = HTML_UNREGISTER;
                        break;
				}
                // 2005.09.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

                # region 2007.06.27  S.Koga  DEL
                ////請求書摘要
                //array[15,1] = billPrtSt.BillOutline1;
                //array[16,1] = billPrtSt.BillOutline2;

                // 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
                //// 集金予定表出力タイプ
                //switch( billPrtSt.ClctMnyPlnDocOutType ) {
                //    case 0:
                //    {
                //        array[ 17, 1 ] = "請求書タイプ";
                //        break;
                //    }
                //    case 1:
                //    {
                //        array[ 17, 1 ] = "回収タイプ(支払月に合わせた集金)";
                //        break;
                //    }
                //    default:
                //    {
                //        array[ 17, 1 ] = HTML_UNREGISTER;
                //        break;
                //    }
                //}

                //// 集金予定表集金予定額（諸費用）
                //switch( billPrtSt.ClctMnyPlnDocVarCst ) {
                //    case 0:
                //    {
                //        array[ 18, 1 ] = "受注と同様(支払月に合わせる)";
                //        break;
                //    }
                //    case 1:
                //    {
                //        array[ 18, 1 ] = "集金予定月の締迄を含める";
                //        break;
                //    }
                //    case 2:
                //    {
                //        array[ 18, 1 ] = "即日集金";
                //        break;
                //    }
                //    //case 3:
                //    //{
                //    //    array[ 18, 1 ] = "翌月集金";
                //    //    break;
                //    //}
                //    default:
                //    {
                //        array[ 18, 1 ] = HTML_UNREGISTER;
                //        break;
                //    }
                //}

                //// 集金予定表出力区分
                //switch( billPrtSt.ClctMnyPlnDocOutCd ) {
                //    case 0:
                //    {
                //        array[ 19, 1 ] = "全て出力";
                //        break;
                //    }
                //    case 1:
                //    {
                //        array[ 19, 1 ] = "０とプラス金額を出力";
                //        break;
                //    }
                //    case 2:
                //    {
                //        array[ 19, 1 ] = "プラス金額のみ出力";
                //        break;
                //    }
                //    case 3:
                //    {
                //        array[ 19, 1 ] = "０のみ出力";
                //        break;
                //    }
                //    case 4:
                //    {
                //        array[ 19, 1 ] = "プラス金額とマイナス金額";
                //        break;
                //    }
                //    case 5:
                //    {
                //        array[ 19, 1 ] = "０とマイナス金額を出力";
                //        break;
                //    }
                //    case 6:
                //    {
                //        array[ 19, 1 ] = "マイナス金額のみ出力";
                //        break;
                //    }
                //    default:
                //    {
                //        array[ 19, 1 ] = HTML_UNREGISTER;
                //        break;
                //    }
                //}
// 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
                # endregion
            }
			else
			{
				array[1,1]	= HTML_UNREGISTER;
				array[2,1]	= HTML_UNREGISTER;
				array[3,1]	= HTML_UNREGISTER;
				array[4,1]	= HTML_UNREGISTER;
				array[5,1]	= HTML_UNREGISTER;
				array[6,1]	= HTML_UNREGISTER;
				array[7,1]	= HTML_UNREGISTER;
				//array[8,1]	= HTML_UNREGISTER;  // DEL 2008/06/13
                # region 2007.06.27  S.Koga  DEL
                //array[9,1]  = HTML_UNREGISTER;
                //array[10,1] = HTML_UNREGISTER;
                //array[11,1] = HTML_UNREGISTER;
                //array[12,1] = HTML_UNREGISTER;
                //array[13,1] = HTML_UNREGISTER;
                //array[14,1] = HTML_UNREGISTER;
                //array[15,1] = HTML_UNREGISTER;
                //array[16,1] = HTML_UNREGISTER;
// 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
                //array[17,1] = HTML_UNREGISTER;
                //array[18,1] = HTML_UNREGISTER;
                //array[19,1] = HTML_UNREGISTER;
                // 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
                # endregion
            }
			// データの２次元配列のみを指定して、プロパティを使用してグリッド表示する
			this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array,ref outCode);

			return outCode;	
		}

		#endregion

		# region private Method
		/// <summary>
		///	画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note			:	画面の初期設定を行います。</br>
		/// <br>Programmer		:	23010 中村　仁</br>
		/// <br>Date			:	2005.08.06</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{	
			//請求一覧表出力区分
			this.BillTableOutCd_tComboEditor.Items.Clear();
			this.BillTableOutCd_tComboEditor.Items.Add(0,"全て出力");
			this.BillTableOutCd_tComboEditor.Items.Add(1,"０とプラス金額を出力");
			this.BillTableOutCd_tComboEditor.Items.Add(2,"プラス金額のみ出力");
			this.BillTableOutCd_tComboEditor.Items.Add(3,"０のみ出力");
			this.BillTableOutCd_tComboEditor.Items.Add(4,"プラス金額とマイナス金額を出力");
			this.BillTableOutCd_tComboEditor.Items.Add(5,"０とマイナス金額を出力");
			this.BillTableOutCd_tComboEditor.Items.Add(6,"マイナス金額のみ出力");
			this.BillTableOutCd_tComboEditor.MaxDropDownItems = this.BillTableOutCd_tComboEditor.Items.Count;
			//請求書(合計)出力区分
			this.TotalBillOutputDiv_tComboEditor.Items.Clear();
			this.TotalBillOutputDiv_tComboEditor.Items.Add(0,"全て出力");
			this.TotalBillOutputDiv_tComboEditor.Items.Add(1,"０とプラス金額を出力");
			this.TotalBillOutputDiv_tComboEditor.Items.Add(2,"プラス金額のみ出力");
			this.TotalBillOutputDiv_tComboEditor.Items.Add(3,"０のみ出力");
			this.TotalBillOutputDiv_tComboEditor.Items.Add(4,"プラス金額とマイナス金額を出力");
			this.TotalBillOutputDiv_tComboEditor.Items.Add(5,"０とマイナス金額を出力");
			this.TotalBillOutputDiv_tComboEditor.Items.Add(6,"マイナス金額のみ出力");
			this.TotalBillOutputDiv_tComboEditor.MaxDropDownItems = this.TotalBillOutputDiv_tComboEditor.Items.Count;
			//請求書(明細、伝票合計)出力区分
			this.DetailBillOutputCode_tComboEditor.Items.Clear();
			this.DetailBillOutputCode_tComboEditor.Items.Add(0,"全て出力");
			this.DetailBillOutputCode_tComboEditor.Items.Add(1,"０とプラス金額を出力");
			this.DetailBillOutputCode_tComboEditor.Items.Add(2,"プラス金額のみ出力");
			this.DetailBillOutputCode_tComboEditor.Items.Add(3,"０のみ出力");
			this.DetailBillOutputCode_tComboEditor.Items.Add(4,"プラス金額とマイナス金額を出力");
			this.DetailBillOutputCode_tComboEditor.Items.Add(5,"０とマイナス金額を出力");
			this.DetailBillOutputCode_tComboEditor.Items.Add(6,"マイナス金額のみ出力");
			this.DetailBillOutputCode_tComboEditor.MaxDropDownItems = this.DetailBillOutputCode_tComboEditor.Items.Count;
            # region 2007.06.27  S.Koga  DEL
            ////請求前受金出力項目
            //this.BillBfRmonOutltem_tComboEditor.Items.Clear();
            //this.BillBfRmonOutltem_tComboEditor.Items.Add(0,"前受金");
            //this.BillBfRmonOutltem_tComboEditor.Items.Add(1,"今回入金");
            //this.BillBfRmonOutltem_tComboEditor.MaxDropDownItems = this.BillBfRmonOutltem_tComboEditor.Items.Count;
            ////請求書消費税出力区分
            //this.BillConstTaxOutPutCd_tComboEditor.Items.Clear();
            //this.BillConstTaxOutPutCd_tComboEditor.Items.Add(0,"消費税別");
            //this.BillConstTaxOutPutCd_tComboEditor.Items.Add(1,"消費税込み");
            //this.BillConstTaxOutPutCd_tComboEditor.MaxDropDownItems = this.BillConstTaxOutPutCd_tComboEditor.Items.Count;
            # endregion
            //請求書末日印字区分
			this.BillLastDayPrtDiv_tComboEditor.Items.Clear();
			this.BillLastDayPrtDiv_tComboEditor.Items.Add(0,"数値印字");
			this.BillLastDayPrtDiv_tComboEditor.Items.Add(1,"２８～３１日は末日と印字");
			this.BillLastDayPrtDiv_tComboEditor.MaxDropDownItems = this.BillLastDayPrtDiv_tComboEditor.Items.Count;
			
            //請求書自社名印字区分
			this.BillCoNmPrintOutCd_tComboEditor.Items.Clear();
            /* --- DEL 2008/06/13 -------------------------------->>>>>
			this.BillCoNmPrintOutCd_tComboEditor.Items.Add(1,"印字しない");
			this.BillCoNmPrintOutCd_tComboEditor.Items.Add(0,"印字する");
            // 2007.07.12  S.Koga  ADD ----------------------------------------
            this.BillCoNmPrintOutCd_tComboEditor.Items.Add(2, BILLCONMPRINTOUTCD_MYIMAGE);
            // ----------------------------------------------------------------
               --- DEL 2008/06/13 --------------------------------<<<<< */
            // --- ADD 2008/06/13 -------------------------------->>>>>
            this.BillCoNmPrintOutCd_tComboEditor.Items.Add(0,BILLCONMPRINTOUTCD_OWN);
            this.BillCoNmPrintOutCd_tComboEditor.Items.Add(1,BILLCONMPRINTOUTCD_SECTION);
            this.BillCoNmPrintOutCd_tComboEditor.Items.Add(2,BILLCONMPRINTOUTCD_BITMAP);
            this.BillCoNmPrintOutCd_tComboEditor.Items.Add(3, BILLCONMPRINTOUTCD_NO);
            // --- ADD 2008/06/13 --------------------------------<<<<< 
            this.BillCoNmPrintOutCd_tComboEditor.MaxDropDownItems = this.BillCoNmPrintOutCd_tComboEditor.Items.Count;
			
            //請求書銀行名印字区分
			this.BillBankNmPrintOut_tComboEditor.Items.Clear();
			this.BillBankNmPrintOut_tComboEditor.Items.Add(1,"印字しない");
			this.BillBankNmPrintOut_tComboEditor.Items.Add(0,"印字する");
			//this.BillBankNmPrintOut_tComboEditor.Items.Add(1,"印字しない");
			this.BillBankNmPrintOut_tComboEditor.MaxDropDownItems = this.BillBankNmPrintOut_tComboEditor.Items.Count;

			// 2005.09.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//得意先電話番号印字区分
			this.CustTelNoPrtDivCd_tComboEditor.Items.Clear();
			this.CustTelNoPrtDivCd_tComboEditor.Items.Add(0,"印字しない");
			this.CustTelNoPrtDivCd_tComboEditor.Items.Add(1,"印字する");
			this.CustTelNoPrtDivCd_tComboEditor.MaxDropDownItems = this.CustTelNoPrtDivCd_tComboEditor.Items.Count;
			// 2005.09.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            # region 2007.06.27  S.Koga  DEL
            // 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//            // 集金予定表出力タイプ
//            this.ClctMnyPlnDocOutType_tComboEditor.Items.Clear();
//            this.ClctMnyPlnDocOutType_tComboEditor.Items.Add( 0, "請求書タイプ" );
//            this.ClctMnyPlnDocOutType_tComboEditor.Items.Add( 1, "回収タイプ(支払月に合わせた集金)" );
//            this.ClctMnyPlnDocOutType_tComboEditor.MaxDropDownItems = this.ClctMnyPlnDocOutType_tComboEditor.Items.Count;

//            // 集金予定表集金予定額（諸費用）
//            this.ClctMnyPlnDocVarCst_tComboEditor.Items.Clear();
//            this.ClctMnyPlnDocVarCst_tComboEditor.Items.Add( 0, "受注と同様(支払月に合わせる)" );
//            this.ClctMnyPlnDocVarCst_tComboEditor.Items.Add( 1, "集金予定月の締迄を含める" );
//            this.ClctMnyPlnDocVarCst_tComboEditor.Items.Add( 2, "即日集金" );
////			this.ClctMnyPlnDocVarCst_tComboEditor.Items.Add( 3, "翌月集金" );
//            this.ClctMnyPlnDocVarCst_tComboEditor.MaxDropDownItems = this.ClctMnyPlnDocVarCst_tComboEditor.Items.Count;

//            // 集金予定表出力区分
//            this.ClctMnyPlnDocOutCd_tComboEditor.Items.Clear();
//            this.ClctMnyPlnDocOutCd_tComboEditor.Items.Add( 0, "全て出力" );
//            this.ClctMnyPlnDocOutCd_tComboEditor.Items.Add( 1, "０とプラス金額を出力" );
//            this.ClctMnyPlnDocOutCd_tComboEditor.Items.Add( 2, "プラス金額のみ出力" );
//            this.ClctMnyPlnDocOutCd_tComboEditor.Items.Add( 3, "０のみ出力" );
//            this.ClctMnyPlnDocOutCd_tComboEditor.Items.Add( 4, "プラス金額とマイナス金額" );
//            this.ClctMnyPlnDocOutCd_tComboEditor.Items.Add( 5, "０とマイナス金額を出力" );
//            this.ClctMnyPlnDocOutCd_tComboEditor.Items.Add( 6, "マイナス金額のみ出力" );
//            this.ClctMnyPlnDocOutCd_tComboEditor.MaxDropDownItems = this.ClctMnyPlnDocOutCd_tComboEditor.Items.Count;
            // 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            # endregion

        }
		
		/// <summary>
		///	請求印刷設定画面展開処理
		/// </summary>
		/// <remarks>
		/// <br>Note	   : 請求印刷設定クラスから画面にデータを展開します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2005.08.05</br>
		/// </remarks>
		private void BillPrtStToScreen()
		{
			//請求一覧表出力区分
			this.BillTableOutCd_tComboEditor.SelectedIndex = this.billPrtSt.BillTableOutCd;
			//請求書(鑑)出力区分
			this.TotalBillOutputDiv_tComboEditor.SelectedIndex = this.billPrtSt.TotalBillOutputDiv;
			//明細請求書出力区分
			this.DetailBillOutputCode_tComboEditor.SelectedIndex = this.billPrtSt.DetailBillOutputCode;
            # region 2007.06.27  S.Koga  DEL
            ////請求前受金出力項目
            //this.BillBfRmonOutltem_tComboEditor.SelectedIndex = this.billPrtSt.BillBfRmonOutItem;
            ////請求書消費税出力区分
            //this.BillConstTaxOutPutCd_tComboEditor.SelectedIndex = this.billPrtSt.BillConsTaxOutPutCd;
            # endregion
            //請求書末日印字区分
			this.BillLastDayPrtDiv_tComboEditor.SelectedIndex = this.billPrtSt.BillLastDayPrtDiv;
            # region 2007.06.27  S.Koga  DEL
            ////請求書自社プロテクト印刷名称
            //this.BillEpProtectPrtNm1_tEdit.DataText = billPrtSt.BillEpProtectPrtNm1.TrimEnd();
            //this.BillEpProtectPrtNm2_tEdit.DataText = billPrtSt.BillEpProtectPrtNm2.TrimEnd();
            //this.BillEpProtectPrtNm3_tEdit.DataText = billPrtSt.BillEpProtectPrtNm3.TrimEnd();
            //this.BillEpProtectPrtNm4_tEdit.DataText = billPrtSt.BillEpProtectPrtNm4.TrimEnd();
            # endregion
            // 2006.01.27 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//			//請求書自社名印字区分
//			this.BillCoNmPrintOutCd_tComboEditor.SelectedIndex = this.billPrtSt.BillCoNmPrintOutCd;
//			//請求書銀行名印字区分
//			this.BillBankNmPrintOut_tComboEditor.SelectedIndex = this.billPrtSt.BillBankNmPrintOut;
			// 2006.01.27 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			
			// 2006.01.27 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//請求書自社名印字区分
            // 2007.07.12  S.Koga  AMEND --------------------------------------
            //if(this.billPrtSt.BillCoNmPrintOutCd == 0)
            //{
            //    this.BillCoNmPrintOutCd_tComboEditor.SelectedIndex = 1;
            //}
            //else
            //{
            //    this.BillCoNmPrintOutCd_tComboEditor.SelectedIndex = 0;
            //}
            this.BillCoNmPrintOutCd_tComboEditor.Value = this.billPrtSt.BillCoNmPrintOutCd;
            // ----------------------------------------------------------------
			//請求書銀行名印字区分
			if(this.billPrtSt.BillBankNmPrintOut == 0)
			{
				this.BillBankNmPrintOut_tComboEditor.SelectedIndex = 1;
			}
			else
			{
				this.BillBankNmPrintOut_tComboEditor.SelectedIndex = 0;
			}
			// 2006.01.27 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			
			// 2005.09.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//得意先電話番号印字区分
			this.CustTelNoPrtDivCd_tComboEditor.SelectedIndex = this.billPrtSt.CustTelNoPrtDivCd;
			// 2005.09.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            # region 2007.06.27  S.Koga  DEL
            ////請求摘要
            //this.BillOutline1_tEdit.DataText = this.billPrtSt.BillOutline1.TrimEnd();
            //this.BillOutline2_tEdit.DataText = this.billPrtSt.BillOutline2.TrimEnd();	
            # endregion
            // 2006.01.27 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//請求書印刷一時中断枚数
			//this.BillPrtSuspendCnt_tNedit1.SetInt(this.billPrtSt.BillPrtSuspendCnt);  // DEL 2008/06/13
			// 2006.01.27 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            # region 2007.06.27  S.Koga  DEL
            // 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            //// 集金予定表出力区分
            //this.ClctMnyPlnDocOutCd_tComboEditor.Value   = this.billPrtSt.ClctMnyPlnDocOutCd;
            //// 集金予定表集金予定額（諸費用）
            //this.ClctMnyPlnDocVarCst_tComboEditor.Value  = this.billPrtSt.ClctMnyPlnDocVarCst;
            //// 集金予定表出力タイプ
            //this.ClctMnyPlnDocOutType_tComboEditor.Value = this.billPrtSt.ClctMnyPlnDocOutType;
            // 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            # endregion
        }

		/// <summary>
		///	画面情報⇒請求印刷設定クラス格納処理
		/// </summary>
		/// <remarks>
		/// <br>Note	   : 画面情報から請求印刷設定クラスにデータを
		///					 格納します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private void ScreenTobillPrtSt()
		{
			if (billPrtSt == null)
			{
				// 新規の場合
				billPrtSt = new BillPrtSt();
			}
			//---ヘッダ部--//
			this.billPrtSt.EnterpriseCode = this._enterpriseCode;      //企業コード

			//---データ部--//
			//請求印刷設定管理コード（0固定)
			this.billPrtSt.BillPrtStMngCd       = 0; 
			//請求一覧表出力区分
			this.billPrtSt.BillTableOutCd       = this.BillTableOutCd_tComboEditor.SelectedIndex;
			//請求書(鑑)出力区分
			this.billPrtSt.TotalBillOutputDiv   =  this.TotalBillOutputDiv_tComboEditor.SelectedIndex;
			//明細請求書出力区分
			this.billPrtSt.DetailBillOutputCode =  this.DetailBillOutputCode_tComboEditor.SelectedIndex;
            # region 2007.06.27  S.Koga  DEL
            ////請求前受金出力項目
            //this.billPrtSt.BillBfRmonOutItem    = this.BillBfRmonOutltem_tComboEditor.SelectedIndex;
            ////請求書消費税出力区分
            //this.billPrtSt.BillConsTaxOutPutCd  =  this.BillConstTaxOutPutCd_tComboEditor.SelectedIndex;
            # endregion
            //請求書末日印字区分
			this.billPrtSt.BillLastDayPrtDiv    =  this.BillLastDayPrtDiv_tComboEditor.SelectedIndex;
            # region 2007.06.27  S.Koga  DEL
            ////請求書自社プロテクト印刷名称
            //this.billPrtSt.BillEpProtectPrtNm1  = this.BillEpProtectPrtNm1_tEdit.DataText.TrimEnd();
            //this.billPrtSt.BillEpProtectPrtNm2  = this.BillEpProtectPrtNm2_tEdit.DataText.TrimEnd();	
            //this.billPrtSt.BillEpProtectPrtNm3	= this.BillEpProtectPrtNm3_tEdit.DataText.TrimEnd(); 
            //this.billPrtSt.BillEpProtectPrtNm4	= this.BillEpProtectPrtNm4_tEdit.DataText.TrimEnd(); 
            # endregion
            // 2006.01.27 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//			//請求書自社名印字区分
//			this.billPrtSt.BillCoNmPrintOutCd	= this.BillCoNmPrintOutCd_tComboEditor.SelectedIndex;
//			//請求書銀行名印字区分
//			this.billPrtSt.BillBankNmPrintOut   =  this.BillBankNmPrintOut_tComboEditor.SelectedIndex;
			// 2006.01.27 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			

			// 2006.01.27 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//請求書自社名印字区分
            // 2007.07.12  S.Koga  AMEND --------------------------------------
            //if(this.BillCoNmPrintOutCd_tComboEditor.SelectedIndex == 0)
            //{
            //    this.billPrtSt.BillCoNmPrintOutCd = 1;
            //}
            //else
            //{
            //    this.billPrtSt.BillCoNmPrintOutCd = 0;
            //}
            if (this.BillCoNmPrintOutCd_tComboEditor.SelectedItem != null)
                this.billPrtSt.BillCoNmPrintOutCd = (int)this.BillCoNmPrintOutCd_tComboEditor.SelectedItem.DataValue;
            // ----------------------------------------------------------------
			//請求書銀行名印字区分
			if(this.BillBankNmPrintOut_tComboEditor.SelectedIndex == 0)
			{
				this.billPrtSt.BillBankNmPrintOut = 1;
			}
			else
			{
				this.billPrtSt.BillBankNmPrintOut = 0;
			}
			// 2006.01.27 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
			
			// 2005.09.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//得意先電話番号印字区分
			this.billPrtSt.CustTelNoPrtDivCd    =  this.CustTelNoPrtDivCd_tComboEditor.SelectedIndex;
			// 2005.09.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            # region 2007.06.27  S.Koga  DEL
            ////請求摘要
            //this.billPrtSt.BillOutline1         = this.BillOutline1_tEdit.DataText.TrimEnd();
            //this.billPrtSt.BillOutline2         = this.BillOutline2_tEdit.DataText.TrimEnd();			
            # endregion

            // 2006.01.27 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//請求書一時中断枚数
			//this.billPrtSt.BillPrtSuspendCnt    = TStrConv.StrToIntDef(this.BillPrtSuspendCnt_tNedit1.DataText, 0);  // DEL 2008/06/13		
			// 2006.01.27 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            # region 2007.06.27  S.Koga  DEL
            // 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            //// 集金予定表出力区分
            //if( this.ClctMnyPlnDocOutCd_tComboEditor.SelectedIndex < 0 ) {
            //    // 未選択
            //    this.billPrtSt.ClctMnyPlnDocOutCd = 0;
            //}
            //else {
            //    this.billPrtSt.ClctMnyPlnDocOutCd = ( int )this.ClctMnyPlnDocOutCd_tComboEditor.Value;
            //}

            //// 集金予定表集金予定額（諸費用）
            //if( this.ClctMnyPlnDocVarCst_tComboEditor.SelectedIndex < 0 ) {
            //    // 未選択
            //    this.billPrtSt.ClctMnyPlnDocVarCst = 0;
            //}
            //else {
            //    this.billPrtSt.ClctMnyPlnDocVarCst = ( int )this.ClctMnyPlnDocVarCst_tComboEditor.Value;
            //}

            //// 集金予定表出力タイプ
            //if( this.ClctMnyPlnDocOutType_tComboEditor.SelectedIndex < 0 ) {
            //    // 未選択
            //    this.billPrtSt.ClctMnyPlnDocOutType = 0;
            //}
            //else {
            //    this.billPrtSt.ClctMnyPlnDocOutType = ( int )this.ClctMnyPlnDocOutType_tComboEditor.Value;
            //}
            // 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            # endregion

        }
		/// <summary>
		///	請求全体設定画面初期化処理
		/// </summary>
		/// <remarks>
		/// <br>Note	   : 画面情報を初期化します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private void ScreenClear()
		{
			//請求一覧表出力区分
			this.BillTableOutCd_tComboEditor.SelectedIndex = 0;
			//請求書(合計)出力区分
			this.TotalBillOutputDiv_tComboEditor.SelectedIndex = 0;
			//請求書(明細、伝票合計)出力区分
			this.DetailBillOutputCode_tComboEditor.SelectedIndex = 0;
            # region 2007.06.27  S.Koga  DEL
            ////請求前受金出力項目
            //this.BillBfRmonOutltem_tComboEditor.SelectedIndex = 0;
            ////請求書消費税出力区分
            //this.BillConstTaxOutPutCd_tComboEditor.SelectedIndex = 0;
            # endregion

            //請求書末日印字区分
			this.BillLastDayPrtDiv_tComboEditor.SelectedIndex = 0;
            # region 2007.06.27  S.Koga  DEL
            ////請求書自社プロテクト印刷名称
            //this.BillEpProtectPrtNm1_tEdit.DataText  = "";
            //this.BillEpProtectPrtNm2_tEdit.DataText  = "";
            //this.BillEpProtectPrtNm3_tEdit.DataText  = "";
            //this.BillEpProtectPrtNm4_tEdit.DataText  = "";
            # endregion
            //請求書自社名印字区分
			this.BillCoNmPrintOutCd_tComboEditor.SelectedIndex = 0;
			//請求書銀行名印字区分
			this.BillBankNmPrintOut_tComboEditor.SelectedIndex = 0;
			
			// 2005.09.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//得意先電話番号印字区分
			this.CustTelNoPrtDivCd_tComboEditor.SelectedIndex = 0;
			// 2005.09.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            # region 2007.06.27  S.Koga  DEL
            ////請求摘要
            //this.BillOutline1_tEdit.DataText = "";
            //this.BillOutline2_tEdit.DataText = "";
            # endregion

            // 2006.01.27 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			//請求書印刷一時中断枚数
			//this.BillPrtSuspendCnt_tNedit1.DataText = "";  // DEL 2008/06/13
			// 2006.01.27 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            # region 2007.06.27  S.Koga  DEL
            // 2006.06.01 AKIYAMA ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            //// 集金予定表出力区分
            //this.ClctMnyPlnDocOutCd_tComboEditor.SelectedIndex   = 0;
            //// 集金予定表集金予定額（諸費用）
            //this.ClctMnyPlnDocVarCst_tComboEditor.SelectedIndex  = 0;
            //// 集金予定表出力タイプ
            //this.ClctMnyPlnDocOutType_tComboEditor.SelectedIndex = 0;
            // 2006.06.01 AKIYAMA ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
            # endregion

        }

		/// <summary>
		/// 画面再構築処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : モードに基づいて画面を再構築します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private void ScreenReconstruction()
		{
			int status = billPrtStAcs.Read(out this.billPrtSt, this._enterpriseCode);
			if (status == 0)
			{
				Mode_Label.Text = UPDATE_MODE;
				// 全体初期表示設定クラス画面展開処理
				BillPrtStToScreen();

				this.BillTableOutCd_tComboEditor.Focus();
			}
			//画面に表示した情報を一旦データクラスにセット
			ScreenTobillPrtSt();

			//画面情報を比較用クローンにコピーする
			this._billPrtStClone = this.billPrtSt.Clone();

			return;
		}

		/// <summary>
		/// データ保存処理処理
		/// </summary>
		/// <returns>保存結果（true:OK／false:エラー在り）</returns>
		/// <remarks>
		/// <br>Note       : データの登録更新処理を行います</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private bool DataSaveProc()
		{
			bool blRes = true;

			// 画面から請求全体設定表示クラスにデータをセットします。
			ScreenTobillPrtSt();

			// 請求全体設定登録処理
			int status = this.billPrtStAcs.Write( ref billPrtSt);			
			if (status != 0)
			{
				if (status == (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE)
				{
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			
					// 他端末更新
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
						"SFUKK09080U", 						// アセンブリＩＤまたはクラスＩＤ
						"既に他端末より更新されています。", // 表示するメッセージ
						0, 									// ステータス値
						MessageBoxButtons.OK );				// 表示するボタン
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					MessageBox.Show(
//						"既に他端末より更新されています",
//						"注意",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Exclamation,
//						MessageBoxDefaultButton.Button1);
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					return blRes = false;
				}
				else
				{
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					// 登録失敗
					TMsgDisp.Show( 
						this, 								// 親ウィンドウフォーム
						emErrorLevel.ERR_LEVEL_STOP, 		// エラーレベル
						"SFUKK09080U", 						// アセンブリＩＤまたはクラスＩＤ
						"請求書印刷設定", 					// プログラム名称
						"DataSaveProc", 					// 処理名称
						TMsgDisp.OPE_UPDATE, 				// オペレーション
						"登録に失敗しました。", 			// 表示するメッセージ
						status, 							// ステータス値
						this.billPrtStAcs,	 				// エラーが発生したオブジェクト
						MessageBoxButtons.OK, 				// 表示するボタン
						MessageBoxDefaultButton.Button1 );	// 初期表示ボタン
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					
					// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
//					MessageBox.Show(
//						"請求全体設定の登録に失敗しました",
//						"エラー",
//						MessageBoxButtons.OK,
//						MessageBoxIcon.Error,
//						MessageBoxDefaultButton.Button1);
					// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					if (CanClose == true)
					{
						this.Close();
					}
					else
					{
						this.Hide();
					}
					return blRes = false;
				}
			}
			Mode_Label.Text = UPDATE_MODE;
			return blRes;
		}
		#endregion

		# region Control Events
		/// <summary>
		/// Form.Load イベント(SFUKK09080UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note		: ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer	: 23010 中村　仁</br>
		/// <br>Date		: 2005.08.06</br>
		/// </remarks>
		private void SFUKK09080UA_Load(object sender, System.EventArgs e)
		{
			// ボタンのアイコンの位置を設定
			ImageList imageList24 = IconResourceManagement.ImageList24;
			this.Ok_Button.ImageList		= imageList24;
			this.Cancel_Button.ImageList	= imageList24;
			this.Ok_Button.Appearance.Image		= Size24_Index.SAVE;
			this.Cancel_Button.Appearance.Image	= Size24_Index.CLOSE;
			// 画面初期化処理
			ScreenInitialSetting();
		}
		
		/// <summary>
		/// Timer.Tick イベント(Initial_Timer.Tick)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : 指定された間隔の時間が経過したときに発生します。
		///                  この処理は、システムが提供するスレッド プール
		///	                 スレッドで実行されます。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private void Initial_Timer_Tick(object sender, System.EventArgs e)
		{
			Initial_Timer.Enabled = false;
			ScreenReconstruction();
		}
		
		/// <summary>
		/// Control.VisibleChanged イベント(SFUKK09080UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォームの表示状態が変わったときに発生します。</br>
		/// <br>Programmer : 23010 中村 仁</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private void SFUKK09080UA_VisibleChanged(object sender, System.EventArgs e)
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
			if (this._billPrtStClone != null)
			{
				return;
			}
			Initial_Timer.Enabled = true;

			ScreenClear();
		}

		/// <summary>
		///	Form.Closing イベント(SFUKK09080UA)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">キャンセルできるイベントのデータを提供するクラス</param>
		/// <remarks>
		/// <br>Note	   : フォームを閉じる前に、ユーザーがフォームを閉じ
		///					 ようとしたときに発生します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private void SFUKK09080UA_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this._billPrtStClone = null;
			
			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
			//（フォームの「×」をクリックされた場合の対応です。）
			if (CanClose == false)
			{
				e.Cancel = true;
				this.Hide();
			}
		}
		
		/// <summary>
		///	Control.Click イベント(Ok_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note	   : 保存ボタンコントロールがクリックされたときに
		///					 発生します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private void Ok_Button_Click(object sender, System.EventArgs e)
		{
			//保存処理
			if (!DataSaveProc()) 
			{return;}

			DialogResult dialogResult = DialogResult.OK;

			// 画面非表示イベント
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
				UnDisplaying(this, me);
			}
		
			this.DialogResult = dialogResult;
			this._billPrtStClone = null;

			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
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
		///	Control.Click イベント(Cancel_Button)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note	   : 閉じるボタンコントロールがクリックされたときに
		///					 発生します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2005.08.06</br>
		/// </remarks>
		private void Cancel_Button_Click(object sender, System.EventArgs e)
		{
			DialogResult dialogResult = DialogResult.Cancel;
		  
			//画面情報をとりあえずセット
			ScreenTobillPrtSt();
		
			//変更があるかどうか判定
			if (!_billPrtStClone.Equals(billPrtSt))
			{
				// 2005.09.22 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				// 保存確認
				DialogResult result = TMsgDisp.Show( 
					this, 								// 親ウィンドウフォーム
					emErrorLevel.ERR_LEVEL_SAVECONFIRM, // エラーレベル
					"SFUKK09080U", 						// アセンブリＩＤまたはクラスＩＤ
					null, 								// 表示するメッセージ
					0, 									// ステータス値
					MessageBoxButtons.YesNoCancel );	// 表示するボタン
				// 2005.09.22 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

				// 2005.09.22 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
			
//				result = MessageBox.Show( 
//					"編集中のデータが存在します"+"\r\n"+"\r\n"+"登録してもよろしいですか？",
//					"保存確認",
//					MessageBoxButtons.YesNoCancel,
//					MessageBoxIcon.Question,
//					MessageBoxDefaultButton.Button1);
				// 2005.09.22 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

				switch(result)
				{
						//保存する
					case DialogResult.Yes:
					{
						//保存処理関数
						if (!DataSaveProc())
						{return;}
						dialogResult = DialogResult.OK;
						break;
					}
						//処理しない
					case DialogResult.Cancel:
					{
						// 2005.09.02 TANIFUJI ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
						this.Cancel_Button.Focus();
						// 2005.09.02 TANIFUJI ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
						return;
					}

						//保存しないで終了
					case DialogResult.No:
					{
						dialogResult = DialogResult.Cancel;
						break;
					}
					default:
					{ break;}
				}
			}

			// 画面非表示イベント
			if (UnDisplaying != null)
			{
				MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
				UnDisplaying(this, me);
			}

			this.DialogResult = DialogResult.Cancel;
			this._billPrtStClone = null;

			// CanCloseプロパティがfalseの場合は、クローズ処理をキャンセルして
			// フォームを非表示化する。
			if (CanClose == true)
			{
				this.Close();
			}
			else
			{
				this.Hide();
			}
        }

        # region 2007.06.27  S.Koga  DEL
        ///// <summary>
        ///// TComboEditor.SelectionChanged イベント (ClctMnyPlnDocOutType_tComboEditor)
        ///// </summary>
        ///// <param name="sender">対象オブジェクト</param>
        ///// <param name="e">イベントパラメータ</param>
        ///// <remarks>
        ///// <br>Note       : 出力タイプコンボボックスの選択状態が変わった時に発生します。</br>
        ///// <br>Programmer : 23001 秋山　亮介</br>
        ///// <br>Date       : 2006.06.06</br>
        ///// </remarks>
        //private void ClctMnyPlnDocOutType_tComboEditor_SelectionChanged( object sender, EventArgs e )
        //{
        //    int selectedValue = 0;

        //    if( this.ClctMnyPlnDocOutType_tComboEditor.SelectedIndex >= 0 ) {
        //        selectedValue = ( int )this.ClctMnyPlnDocOutType_tComboEditor.Value;
        //    }

        //    switch( selectedValue ) {
        //        // 請求書タイプ
        //        case 0:
        //        {
        //            // 集金予定額(諸費用)を無効にする
        //            this.ClctMnyPlnDocVarCst_tComboEditor.Enabled = false;
        //            break;
        //        }
        //        // 回収タイプ(支払月に合わせた集金)
        //        case 1:
        //        {
        //            // 集金予定額(諸費用)を有効にする
        //            this.ClctMnyPlnDocVarCst_tComboEditor.Enabled = true;
        //            break;
        //        }
        //        default:
        //        {
        //            break;
        //        }
        //    }
        //}
        # endregion
        #endregion

    }
	
}
