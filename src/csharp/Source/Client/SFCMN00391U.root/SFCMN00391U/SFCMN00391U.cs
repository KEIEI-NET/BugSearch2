//**********************************************************************//
// System			:	PM.NS       				    				//
// Sub System		:							   						//
// Program name		:	テキスト出力共通ダイアログクラス				//
//					:	SFCMN00391U.DLL									//
// Name Space		:	Broadleaf.Windows.Forms			                //
// Programmer		:	佐々木 健　　　　　							　　//
// Date				:	2009.04.07										//
//----------------------------------------------------------------------//
// Update Note		:	2009.04.07 SFから流用して作成					//
//----------------------------------------------------------------------//
//				  (c)Copyright  2009 Broadleaf Co.,Ltd.		            //
//**********************************************************************//

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;
using System.Reflection;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Text;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// テキスト出力共通ダイアログクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : テキスト出力共通ダイアログの詳細設定を行います。</br>
	/// <br>Programmer : 23010 中村　仁</br>
	/// <br>Date       : 2006.03.31</br>
    /// <br>=============================================================</br>
    /// <br>Update Note: 2009.04.07　佐々木 健</br>
    /// <br>             SFから参照作成</br>
    /// <br>-------------------------------------------------------------</br>
    /// <br>Update Note: 2009.05.20　佐々木 健</br>
    /// <br>             抽出を行わない場合に、上書き有無がセットされない不具合の修正</br>
    /// </remarks>
	public class SFCMN00391U : System.Windows.Forms.Form
	{
		#region Component
		private System.Windows.Forms.GroupBox groupBox3;
		private Infragistics.Win.Misc.UltraButton OKButton;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private Infragistics.Win.Misc.UltraLabel ultraLabel2;
		private Broadleaf.Library.Windows.Forms.TComboEditor DispName_tComboEditor;
		private Infragistics.Win.Misc.UltraButton CanButton;
        private Broadleaf.Library.Windows.Forms.TEdit OutPutFilePath_tEdit;
		private Infragistics.Win.Misc.UltraButton OutPutChang_Button;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel1;
		private Infragistics.Win.Misc.UltraLabel ultraLabel3;
		private Broadleaf.Library.Windows.Forms.TEdit fullPath_tEdit;
        private Infragistics.Win.Misc.UltraLabel MessageLabel;

		#endregion
        private Infragistics.Win.UltraWinToolTip.UltraToolTipManager ultraToolTipManager1;
        private IContainer components;

		#region コンストラクター
        /// <summary>
        /// テキスト出力共通ダイアログクラスコンストラクター
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力共通ダイアログクラスの変数を初期化します</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2006.03.31</br>
        /// </remarks>
		public SFCMN00391U()
		{			
			InitializeComponent();
            //出力設定マスタアクセスクラス
			_outPutSetAcs = new OutputSetAcs();
                   
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
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance13 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance14 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFCMN00391U));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.MessageLabel = new Infragistics.Win.Misc.UltraLabel();
            this.fullPath_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.ultraLabel3 = new Infragistics.Win.Misc.UltraLabel();
            this.ultraLabel1 = new Infragistics.Win.Misc.UltraLabel();
            this.DispName_tComboEditor = new Broadleaf.Library.Windows.Forms.TComboEditor();
            this.OutPutChang_Button = new Infragistics.Win.Misc.UltraButton();
            this.OutPutFilePath_tEdit = new Broadleaf.Library.Windows.Forms.TEdit();
            this.OKButton = new Infragistics.Win.Misc.UltraButton();
            this.CanButton = new Infragistics.Win.Misc.UltraButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.ultraLabel2 = new Infragistics.Win.Misc.UltraLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ultraToolTipManager1 = new Infragistics.Win.UltraWinToolTip.UltraToolTipManager(this.components);
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fullPath_tEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DispName_tComboEditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutPutFilePath_tEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.MessageLabel);
            this.groupBox3.Controls.Add(this.fullPath_tEdit);
            this.groupBox3.Controls.Add(this.ultraLabel3);
            this.groupBox3.Controls.Add(this.ultraLabel1);
            this.groupBox3.Controls.Add(this.DispName_tComboEditor);
            this.groupBox3.Controls.Add(this.OutPutChang_Button);
            this.groupBox3.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox3.Location = new System.Drawing.Point(7, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(552, 128);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            // 
            // MessageLabel
            // 
            appearance1.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.MessageLabel.Appearance = appearance1;
            this.MessageLabel.Font = new System.Drawing.Font("ＭＳ ゴシック", 10.8F);
            appearance2.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance2.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.MessageLabel.HotTrackAppearance = appearance2;
            this.MessageLabel.Location = new System.Drawing.Point(8, 94);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(408, 23);
            this.MessageLabel.TabIndex = 21;
            this.MessageLabel.Text = "テキスト出力を行います。";
            // 
            // fullPath_tEdit
            // 
            this.fullPath_tEdit.ActiveAppearance = appearance3;
            appearance4.ForeColorDisabled = System.Drawing.Color.Black;
            this.fullPath_tEdit.Appearance = appearance4;
            this.fullPath_tEdit.AutoSelect = false;
            this.fullPath_tEdit.DataText = "";
            this.fullPath_tEdit.Enabled = false;
            this.fullPath_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.fullPath_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 12, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.fullPath_tEdit.Font = new System.Drawing.Font("ＭＳ ゴシック", 10.8F);
            this.fullPath_tEdit.Location = new System.Drawing.Point(112, 58);
            this.fullPath_tEdit.MaxLength = 48;
            this.fullPath_tEdit.Name = "fullPath_tEdit";
            this.fullPath_tEdit.Size = new System.Drawing.Size(431, 24);
            this.fullPath_tEdit.TabIndex = 19;
            // 
            // ultraLabel3
            // 
            appearance5.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance5.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel3.Appearance = appearance5;
            this.ultraLabel3.Font = new System.Drawing.Font("ＭＳ ゴシック", 10.8F);
            appearance6.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance6.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel3.HotTrackAppearance = appearance6;
            this.ultraLabel3.Location = new System.Drawing.Point(8, 58);
            this.ultraLabel3.Name = "ultraLabel3";
            this.ultraLabel3.Size = new System.Drawing.Size(104, 24);
            this.ultraLabel3.TabIndex = 20;
            this.ultraLabel3.Text = "出力先";
            // 
            // ultraLabel1
            // 
            appearance7.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance7.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel1.Appearance = appearance7;
            this.ultraLabel1.Font = new System.Drawing.Font("ＭＳ ゴシック", 10.8F);
            appearance8.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance8.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel1.HotTrackAppearance = appearance8;
            this.ultraLabel1.Location = new System.Drawing.Point(8, 23);
            this.ultraLabel1.Name = "ultraLabel1";
            this.ultraLabel1.Size = new System.Drawing.Size(104, 24);
            this.ultraLabel1.TabIndex = 19;
            this.ultraLabel1.Text = "出力パターン";
            // 
            // DispName_tComboEditor
            // 
            appearance9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DispName_tComboEditor.ActiveAppearance = appearance9;
            this.DispName_tComboEditor.DropDownStyle = Infragistics.Win.DropDownStyle.DropDownList;
            this.DispName_tComboEditor.Font = new System.Drawing.Font("ＭＳ ゴシック", 10.8F);
            appearance10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            this.DispName_tComboEditor.ItemAppearance = appearance10;
            this.DispName_tComboEditor.Location = new System.Drawing.Point(112, 24);
            this.DispName_tComboEditor.Name = "DispName_tComboEditor";
            this.DispName_tComboEditor.Size = new System.Drawing.Size(431, 24);
            this.DispName_tComboEditor.TabIndex = 13;
            // 
            // OutPutChang_Button
            // 
            this.OutPutChang_Button.Font = new System.Drawing.Font("ＭＳ ゴシック", 10.8F);
            this.OutPutChang_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.OutPutChang_Button.Location = new System.Drawing.Point(424, 91);
            this.OutPutChang_Button.Name = "OutPutChang_Button";
            this.OutPutChang_Button.Size = new System.Drawing.Size(120, 27);
            this.OutPutChang_Button.TabIndex = 16;
            this.OutPutChang_Button.Text = "出力先変更(&P)";
            this.OutPutChang_Button.Click += new System.EventHandler(this.OutPutChang_Button_Click);
            // 
            // OutPutFilePath_tEdit
            // 
            this.OutPutFilePath_tEdit.ActiveAppearance = appearance11;
            appearance12.ForeColorDisabled = System.Drawing.Color.Black;
            this.OutPutFilePath_tEdit.Appearance = appearance12;
            this.OutPutFilePath_tEdit.AutoSelect = false;
            this.OutPutFilePath_tEdit.DataText = "";
            this.OutPutFilePath_tEdit.Enabled = false;
            this.OutPutFilePath_tEdit.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.OutPutFilePath_tEdit.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 48, new Broadleaf.Library.Windows.Forms.TEnableChars(true, true, true, false, true, true, true));
            this.OutPutFilePath_tEdit.Location = new System.Drawing.Point(248, 152);
            this.OutPutFilePath_tEdit.MaxLength = 48;
            this.OutPutFilePath_tEdit.Name = "OutPutFilePath_tEdit";
            this.OutPutFilePath_tEdit.Size = new System.Drawing.Size(20, 24);
            this.OutPutFilePath_tEdit.TabIndex = 0;
            this.OutPutFilePath_tEdit.Visible = false;
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 10.8F);
            this.OKButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.OKButton.Location = new System.Drawing.Point(269, 159);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(140, 27);
            this.OKButton.TabIndex = 14;
            this.OKButton.Text = "出力(&S)";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CanButton
            // 
            this.CanButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CanButton.Font = new System.Drawing.Font("ＭＳ ゴシック", 10.8F);
            this.CanButton.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.CanButton.Location = new System.Drawing.Point(411, 159);
            this.CanButton.Name = "CanButton";
            this.CanButton.Size = new System.Drawing.Size(140, 27);
            this.CanButton.TabIndex = 15;
            this.CanButton.Text = "キャンセル(&C)";
            this.CanButton.Click += new System.EventHandler(this.CanButton_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.Font = new System.Drawing.Font("ＭＳ ゴシック", 10.8F);
            this.radioButton1.Location = new System.Drawing.Point(15, 164);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(112, 24);
            this.radioButton1.TabIndex = 16;
            this.radioButton1.Text = "上書きする";
            this.radioButton1.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.Font = new System.Drawing.Font("ＭＳ ゴシック", 10.8F);
            this.radioButton2.Location = new System.Drawing.Point(127, 164);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(112, 24);
            this.radioButton2.TabIndex = 17;
            this.radioButton2.Text = "追加する";
            this.radioButton2.Visible = false;
            // 
            // ultraLabel2
            // 
            appearance13.TextHAlign = Infragistics.Win.HAlign.Left;
            appearance13.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel2.Appearance = appearance13;
            this.ultraLabel2.Font = new System.Drawing.Font("ＭＳ ゴシック", 10.8F);
            appearance14.TextHAlign = Infragistics.Win.HAlign.Center;
            appearance14.TextVAlign = Infragistics.Win.VAlign.Middle;
            this.ultraLabel2.HotTrackAppearance = appearance14;
            this.ultraLabel2.Location = new System.Drawing.Point(15, 139);
            this.ultraLabel2.Name = "ultraLabel2";
            this.ultraLabel2.Size = new System.Drawing.Size(224, 24);
            this.ultraLabel2.TabIndex = 18;
            this.ultraLabel2.Text = "ファイルが既に存在します。";
            this.ultraLabel2.Visible = false;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Title = "出力先設定";
            // 
            // SFCMN00391U
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.CancelButton = this.CanButton;
            this.ClientSize = new System.Drawing.Size(568, 195);
            this.ControlBox = false;
            this.Controls.Add(this.ultraLabel2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.CanButton);
            this.Controls.Add(this.OutPutFilePath_tEdit);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 10.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SFCMN00391U";
            this.Opacity = 0;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "出力設定";
            this.Load += new System.EventHandler(this.SFCMN00391U_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fullPath_tEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DispName_tComboEditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OutPutFilePath_tEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		#region main
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.Run(new SFCMN00391U());
		}
		#endregion

		#region Privateメンバ

        private SFCMN06002C _printInfo;

		private OutputSet _outPutSet; //出力設定マスタデータクラス(SFCMN09121E)
		private ArrayList _outPutList; 
		private OutputSetAcs _outPutSetAcs;//出力設定マスタアクセスクラス(SFCMN09121A)
		private ArrayList wkOutPutList = null;
        private string localFilePahtName = "";
        private string localFileName     = "";
        private int _PrintMode = 0; //印刷モード 0:okボタン時押下時に抽出印刷を行う。 1:okボタン押下時に帳票プリンタ設定のみをセットし終了
        private int _ltimeSelectIndex = -1;

        //定数
        private const string DEFAULT = "DEFAULT.CSV";　　　　　　　　　　　　　
        private const string DEFAULTFILENAME = "PRTOUT\\CSV";
        private const string OUTPUTSET_DEFAULT_FILEPAHTNAME = @"\PRTOUT\CSV\";

		#endregion

		#region プロパティ

		/// 印刷条件プロパティ
        public SFCMN06002C PrintInfo
        {
            get { return this._printInfo; }
            set { this._printInfo = value; }
        }

        /// <summary>
        ///	印刷モード 0:okボタン時押下時に抽出印刷を行う。 1:okボタン押下時に帳票プリンタ設定のみをセットし終了 
        /// </summary>
        public int PrintMode
        {
            get { return this._PrintMode; }
            set { this._PrintMode = value; }
        }

		#endregion

        #region Method

        /// <summary>
        /// 出力設定マスタ情報取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 出力設定マスタ情報取得処理を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2006.03.31</br>
        /// </remarks>
		private int GetPaperInfo()
		{
			int status  = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			// コンボボックスに追加
			this._outPutSet       = new OutputSet();                              
			this.wkOutPutList     = new ArrayList();
            this._outPutList      = new ArrayList();				
			OutputSet outPutSet_r = new OutputSet();
           
            outPutSet_r.EnterpriseCode      = this._printInfo.enterpriseCode;   //企業コード
            outPutSet_r.PgId                = this._printInfo.kidopgid;         //プログラムID
            outPutSet_r.PrintPaperSetCd     = this._printInfo.PrintPaperSetCd;  //設定コード(自由に設定可能)
            outPutSet_r.SelectInfoCode      = this._printInfo.selectInfoCode;	//0:帳票　1:テキスト						
            outPutSet_r.OutputFormFileName  = "";	                            //出力ファイル名
            outPutSet_r.DisplayName         = "";	                            //出力名称
            outPutSet_r.ExtractionPgId      = "";	                            //抽出プログラムID
            outPutSet_r.ExtractionPgClassId = "";	                            //抽出プログラムクラスID
            outPutSet_r.OutputPgId          = "";	                            //テキスト出力プログラムID
            outPutSet_r.OutputPgClassId     = "";	                            //テキスト出力プログラムクラスID
            outPutSet_r.OutConfimationMsg   = "";	                            //出力確認メッセージ
            outPutSet_r.OutputFilePathName  = "";                               //テキスト出力先ファイルパス名
            outPutSet_r.OutputFileName      = "";                               //テキスト出力ファイル名

                 
            //出力設定マスタ読込み処理
            status = _outPutSetAcs.SearchOutputSet(out _outPutList, outPutSet_r);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (OutputSet outPutSet in _outPutList)
                {
                    if (outPutSet != null)
                    {
                        if ((outPutSet.PgId == this._printInfo.kidopgid) && (outPutSet.LogicalDeleteCode == 0) && (outPutSet.SelectInfoCode == 1))
                        {
                            wkOutPutList.Add(outPutSet);
                            DispName_tComboEditor.Items.Add(outPutSet.DisplayName.ToString());
                        }
                    }
                }

                //テキスト出力が登録されていない
                if (wkOutPutList.Count == 0)
                {
                    DialogResult res = TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_INFO,            　// エラーレベル
                    "SFCMN00391U", 						      // アセンブリＩＤまたはクラスＩＤ
                    "出力可能なテキストが契約されていません", // 表示するメッセージ
                    -1, 									  // ステータス値
                    MessageBoxButtons.OK);				    　// 表示するボタン

                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    this.Close();
                    return status;
                 
                }
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                DialogResult res = TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_INFO,            　// エラーレベル
                "SFCMN00391U", 						      // アセンブリＩＤまたはクラスＩＤ
                "出力可能なテキストが契約されていません", // 表示するメッセージ
                -1, 									  // ステータス値
                MessageBoxButtons.OK);				    　// 表示するボタン

                if (res == DialogResult.OK)
                {
                    this.Close();
                    return status;
                }
            }
            else
            {
                DialogResult res = TMsgDisp.Show(
                emErrorLevel.ERR_LEVEL_STOP,            　 // エラーレベル
                "SFCMN00391U", 						       // アセンブリＩＤまたはクラスＩＤ
                "出力設定読込み処理でエラーが発生しました",// 表示するメッセージ 
                -1, 									   // ステータス値
                 MessageBoxButtons.OK);				    　 // 表示するボタン

                if (res == DialogResult.OK)
                {
                    this.Close();
                    return status;
                }
            }
                     
			// デフォルト設定マスタリード
            ReadDefaultSettings();
                          				
            //追加・上書き選択ラベル表示・非表示処理
            //出力先のファイルが存在している場合に表示します
            if ((System.IO.File.Exists(this._printInfo.outPutFilePathName)))
            {
                ultraLabel2.Visible = true;
                radioButton1.Visible = true;
                radioButton2.Visible = true;
                radioButton1.Checked = true;
            }

            //ファイル名とフルパスを取得しておく         
            this.OutPutFilePath_tEdit.Text = this._printInfo.outPutFileName;
            this.fullPath_tEdit.Text = this._printInfo.outPutFilePathName;
            //ありえないが、ファイル名、出力先パスが登録されていなかった場合
            if (this._printInfo.outPutFileName == "" || this._printInfo.outPutFilePathName == "")
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
           
            return status;
		}

        /// <summary>
        /// 抽出ロジック
        /// </summary>
        public int ExtraProc() 
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string AssemblyID = "";
            string ClassID = "";
            object ob = null;
            //抽出処理
            if (this._printInfo.extrapgid != null)
            {

                if (this._printInfo.extrapgid.ToString().Trim() != "")
                {
                    //抽出ＤＬＬをリフレクション
                    //印刷ＤＬＬをリフレクション
                    AssemblyID = this._printInfo.extrapgid.ToString();
                    AssemblyID += ".DLL";
                    ClassID = this._printInfo.extraclassid.ToString();

                    // アセンブリのロード
                    try
                    {
                        Assembly assm = Assembly.LoadFrom(AssemblyID);
                        // アセンブリ内のクラスを取得します。
                        // ネームスペースを含めた完全なクラス名で指定する必要があります。
                        System.Type type = assm.GetType(ClassID);

                        if (type != null)
                        {
                            // クラスを動的に作成します。
                            object instance = Activator.CreateInstance(type, new object[] { this._printInfo });
                            // クラス内のメソッドを取得して呼び出します。
                            MethodInfo method = type.GetMethod("ExtrPrintData", new Type[0]);
                            ob = method.Invoke(instance, null);

                            status = (int)ob;                          
                            this._printInfo.status = (int)ob;
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception)
                    {                     
                        this.DialogResult = DialogResult.Abort;
                        status = -1;
                        this._printInfo.status = -1;
                    }
                }
            }
            return status;
        }


        /// <summary>
        /// テキスト出力メイン処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : テキスト出力メイン処理を行います。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2006.03.31</br>
        /// </remarks>
		public int PrtProc() 
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;		
			string AssemblyID = "";
			string ClassID    = "";

            // 2009.05.20 Del >>>
			//上書き用フラグ
            //2006/10/02 H.NAKAMURA EDIT
            ////条件からVisibleプロパティを消します。
            //if (this.radioButton1.Checked)
            //{
            //    this._printInfo.overWriteFlag = false; //上書きする
            //}
            //else if (this.radioButton2.Checked)
            //{              
            //    this._printInfo.overWriteFlag = true; //追加する
            //}
            //else
            //{
            //    this._printInfo.overWriteFlag = false; //上書きする
            //}
            // 2009.05.20 Del <<<

            //印刷処理
            if (this._printInfo.printpgid != null)
            {
                if (this._printInfo.printpgid.ToString().Trim() != "")
                {
                    //印刷ＤＬＬをリフレクション
                    AssemblyID = _printInfo.printpgid.ToString();
                    AssemblyID += ".DLL";
                    ClassID = this._printInfo.printclassid.ToString();
                    // アセンブリのロード
                    try
                    {
                        Assembly assm = Assembly.LoadFrom(AssemblyID);
                        // アセンブリ内のクラスを取得します。
                        // ネームスペースを含めた完全なクラス名で指定する必要があります。
                        System.Type type = assm.GetType(ClassID);
                        if (type != null)
                        {
                            // クラスを動的に作成します。
                            object instance = Activator.CreateInstance(type, new object[] { this._printInfo });
                            int ret = 0;
                            if (instance is IOutPutText)
                            {
                                ret = ((IOutPutText)instance).StartOutPutText();
                                //内部でSystem.IO.IOExceptionが出た場合
                                //Abordを返す
                                if (ret == -2)
                                {
                                    status = ret;
                                    this._printInfo.status = ret;
                                    this.DialogResult = DialogResult.Abort;
                                }
                                else
                                {
                                    status = ret;
                                    this._printInfo.status = ret;
                                    this.DialogResult = DialogResult.OK;
                                }
                            }
                            else if (instance is ICustomTextWriter)
                            {
                                //テキスト出力スキーマファイルパス保存処理
                                //string current = System.IO.Path.Combine(ConstantManagement_ClientDirectory.TextOutSchema + "\\";
                                string _textSchema = System.IO.Path.Combine(ConstantManagement_ClientDirectory.TextOutSchema, this._printInfo.prpid);                               
                                                           
                                CustomTextProviderInfo customTextProviderInfo = new CustomTextProviderInfo();
                                ret = ((ICustomTextWriter)instance).MakeCustomText(this._printInfo.rdData, _textSchema,
                                    this._printInfo.outPutFilePathName, ref customTextProviderInfo);
                                status = ret;
                                this._printInfo.status = ret;
                                this.DialogResult = DialogResult.OK;   
                            }
                  
                            //status = ret;
                            //this._printInfo.status = ret;
                            //this.DialogResult = DialogResult.OK;                             
                        }
                    }
                    catch (System.IO.IOException)
                    {                      
                        status = -1;
                        this._printInfo.status = -2;
                        this.DialogResult = DialogResult.Abort;
                    }
                    catch (Exception e)
                    {
                        e.ToString();
                        status = -1;
                        this._printInfo.status = -1;
                        this.DialogResult = DialogResult.Abort; 
                    }
                }
            }
            return status;

		}

        /// <summary>
        ///	デフォルト設定マスタリード処理
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ユーザーがフォームを読み込むときに発生します。</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2006.03.30</br>
        /// </remarks>
        private void ReadDefaultSettings()
        {          
            int defcnt = 0;
            this.localFilePahtName  = "";
            this.localFileName      = "";
            OutputSet _defOutPutSet = new OutputSet();

            //ローカル設定あり
            if (_outPutSetAcs.ReadDefault(out _defOutPutSet, this._printInfo.enterpriseCode, this._printInfo.kidopgid, this._printInfo.PrintPaperSetCd, 1) == 0)//最後の引数の"1"は選択情報区分1はテキスト出力選択
            {
                //ローカル設定がnullの時
                if (_defOutPutSet == null)
                {
                    defcnt = -99;
                }
                else
                {
                    defcnt = _defOutPutSet.SelectPgSequenceNo;//プログラム通しNo
                    // 2009.04.07 >>>
                    //this.localFilePahtName = _defOutPutSet.OutputFilePathName; //出力先パス
                    //this.localFileName = _defOutPutSet.OutputFileName;     //出力ファイル名
                    // 出力先パスのディレクトリが存在する場合は、そのままセット
                    if (System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(_defOutPutSet.OutputFilePathName)))
                    {
                        this.localFilePahtName = _defOutPutSet.OutputFilePathName; //出力先パス
                        this.localFileName = _defOutPutSet.OutputFileName;     //出力ファイル名
                    }
                    // 2009.04.07 <<<
                }
            }
            //ローカル設定なし
            else
            {
                defcnt = -99;
            }

            int cnt = 1;
            for (int lpcnt = 0; lpcnt < wkOutPutList.Count; lpcnt++)
            {
                OutputSet myOutputSet = (OutputSet)wkOutPutList[lpcnt];

                if (((myOutputSet != null) && (myOutputSet.SelectPgSequenceNo == defcnt)) || (defcnt == -99))
                {
                    this._printInfo.frycd = myOutputSet.OutputPurpose;			    //出力用途(自由に)
                    this._printInfo.prpid = myOutputSet.OutputFormFileName;         //フォームファイルID(スキーマファイルの名称など)
                    this._printInfo.prpnm = myOutputSet.DisplayName;				//出力名称(お正月パックなど)
                    this._printInfo.printpgid = myOutputSet.OutputPgId;			    //テキスト出力プログラムID
                    this._printInfo.printclassid = myOutputSet.OutputPgClassId;	    //テキスト出力クラス名
                    //2006 05/16 H.NAKAMURA ADD 
                    this._printInfo.extrapgid = myOutputSet.ExtractionPgId;           //抽出PGID
                    this._printInfo.extraclassid = myOutputSet.ExtractionPgClassId;   //抽出クラス名
                    //2006/09/05 H.NAKAMURA ADD
                    //出力確認メッセージを取得
                    this.MessageLabel.Text = myOutputSet.OutConfimationMsg;
                   

                    //ローカル設定無し、又はnullの場合
                    if ((this.localFilePahtName == "") || (this.localFileName == ""))
                    {
                        string current = System.IO.Directory.GetCurrentDirectory();
                        //Combaineできないのでパスを足す                            
                        string defaultPaht = current + myOutputSet.OutputFilePathName;
                        //フルパスを作成
                        string fullPath = System.IO.Path.Combine(defaultPaht, myOutputSet.OutputFileName);
                        //フルパス、ファイル名をセット
                        this._printInfo.outPutFilePathName = fullPath;                          //出力先フルパス
                        this._printInfo.outPutFileName = System.IO.Path.GetFileName(fullPath);　//出力先ファイル名
                    }
                    //ローカル設定がある場合
                    else
                    {                           
                        this._printInfo.outPutFilePathName = this.localFilePahtName;            //出力先フルパス
                        this._printInfo.outPutFileName = this.localFileName;　                  //出力先ファイル名                    
                    }

                    DispName_tComboEditor.Text = this._printInfo.prpnm;
                    break;
                }
                cnt++;
            }                               
            DispName_tComboEditor.SelectionChanged -= new EventHandler(DispName_tComboEditor_SelectionChanged);                      
            DispName_tComboEditor.SelectedIndex = cnt - 1;
            DispName_tComboEditor.SelectionChanged += new EventHandler(DispName_tComboEditor_SelectionChanged);
            //ローカルデータを持っているテキストのSelectIndexを保持しておく
            this._ltimeSelectIndex = this.DispName_tComboEditor.SelectedIndex;
             
        }

        /// <summary>
        ///	ローカルデータセット処理
        /// </summary>
        /// <param name="mode">0:初期表示と同じテキストが選択された場合1:初期表示以外のテキストが選択された場合</param>
        /// <param name="myOutputSet">出力設定マスタデータクラス</param>
        /// <remarks>
        /// <br>Note	   : 出力対象テキストが変更された時に、各々に応じたローカルデータをセットします</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2006.09.02</br>
        /// </remarks>
        private void RocalDataSetting(int mode, OutputSet myOutputSet)
        {
            if (mode == 0)
            {
                //ローカル設定がある場合は必ず読む    
                OutputSet _defOutPutSet = new OutputSet();
                if (_outPutSetAcs.ReadDefault(out _defOutPutSet, this._printInfo.enterpriseCode, this._printInfo.kidopgid, this._printInfo.PrintPaperSetCd, 1) == 0)//最後の引数の"1"は選択情報区分1はテキスト出力選択
                {
                    //ローカル設定がnullの時
                    if (_defOutPutSet == null)
                    {
                        //カレントディレクトリを取得
                        string current = System.IO.Directory.GetCurrentDirectory();
                        //ルートディレクトリを取得                                              
                        //Combineできないのでパスを足します
                        string defaultPaht = current + myOutputSet.OutputFilePathName;
                        //フルパスを作成
                        string fullPath = System.IO.Path.Combine(defaultPaht, myOutputSet.OutputFileName);
                        //フルパス、ファイル名をセット
                        this._printInfo.outPutFilePathName = fullPath;                          //出力先フルパス
                        this._printInfo.outPutFileName = System.IO.Path.GetFileName(fullPath);　//出力先ファイル名
                    }
                    else
                    {
                        this._printInfo.outPutFilePathName = _defOutPutSet.OutputFilePathName;  //出力先パス
                        this._printInfo.outPutFileName = _defOutPutSet.OutputFileName;                      //出力ファイル名
                    }
                }
                //ローカル設定が存在しない時
                else
                {
                    //カレントディレクトリを取得
                    string current = System.IO.Directory.GetCurrentDirectory();
                    //ルートディレクトリを取得                                              
                    //Combineできないのでパスを足します
                    string defaultPaht = current + myOutputSet.OutputFilePathName;
                    //フルパスを作成
                    string fullPath = System.IO.Path.Combine(defaultPaht, myOutputSet.OutputFileName);
                    //フルパス、ファイル名をセット
                    this._printInfo.outPutFilePathName = fullPath;                          //出力先フルパス
                    this._printInfo.outPutFileName = System.IO.Path.GetFileName(fullPath);　//出力先ファイル名
                }

            }
            else if(mode == 1)
            {
                OutputSet _defOutPutSet = new OutputSet();
                if (_outPutSetAcs.ReadDefault(out _defOutPutSet, this._printInfo.enterpriseCode, this._printInfo.kidopgid, this._printInfo.PrintPaperSetCd, 1) == 0)//最後の引数の"1"は選択情報区分1はテキスト出力選択
                {
                    //ローカル設定がnullの時
                    if (_defOutPutSet == null)
                    {
                        //カレントディレクトリを取得
                        string current = System.IO.Directory.GetCurrentDirectory();
                        //ルートディレクトリを取得                                              
                        //Combineできないのでパスを足します
                        string defaultPaht = current + myOutputSet.OutputFilePathName;
                        //フルパスを作成
                        string fullPath = System.IO.Path.Combine(defaultPaht, myOutputSet.OutputFileName);
                        //フルパス、ファイル名をセット
                        this._printInfo.outPutFilePathName = fullPath;                          //出力先フルパス
                        this._printInfo.outPutFileName = System.IO.Path.GetFileName(fullPath);　//出力先ファイル名
                    }
                    else
                    {
                        //ローカル設定のフルパスからディレクトリを取得
                        string outputDirectory = System.IO.Path.GetDirectoryName(_defOutPutSet.OutputFilePathName);
                        string fullPath = System.IO.Path.Combine(outputDirectory, myOutputSet.OutputFileName);

                        this._printInfo.outPutFilePathName = fullPath;  //出力先パス
                        //出力ファイル名はマスタに登録されているものを使用(前回出力分のファイル名しかローカルにもっていない為)
                        this._printInfo.outPutFileName = myOutputSet.OutputFileName;            //出力ファイル名
                    }
                }
                //ローカル設定が存在しない時
                else
                {
                    //カレントディレクトリを取得
                    string current = System.IO.Directory.GetCurrentDirectory();
                    //ルートディレクトリを取得                                              
                    //Combineできないのでパスを足します
                    string defaultPaht = current + myOutputSet.OutputFilePathName;
                    //フルパスを作成
                    string fullPath = System.IO.Path.Combine(defaultPaht, myOutputSet.OutputFileName);
                    //フルパス、ファイル名をセット
                    this._printInfo.outPutFilePathName = fullPath;                          //出力先フルパス
                    this._printInfo.outPutFileName = System.IO.Path.GetFileName(fullPath);　//出力先ファイル名
                }
                
            }

        }

		#endregion

		#region イベント
		/// <summary>
		///	Form.Load イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note	   : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2006.03.30</br>
		/// </remarks>
		private void SFCMN00391U_Load(object sender, System.EventArgs e)
		{
			ImageList imglist = IconResourceManagement.ImageList16;
			
			OKButton.ImageList			= imglist;
			OKButton.Appearance.Image	= Size16_Index.CSVOUTPUT;
			CanButton.ImageList			= imglist;
			CanButton.Appearance.Image	= Size16_Index.BEFORE;
		         
			this.DispName_tComboEditor.Items.Clear();
			this.OutPutFilePath_tEdit.Clear();

            //上書き用Label、radioボタンの初期化
            //2006/09/02 H.NAKLAMURA ADD
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            ultraLabel2.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;

			int status = GetPaperInfo();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //2006/09/12 H.NAKAMURA ADD
                //不透明度を100％に戻す
                this.Opacity = 100D;

                // 2009.04.07 Del >>>
                //string path = System.IO.Path.GetDirectoryName(this._printInfo.outPutFilePathName);
                ////整備帳票選択設定で指定されたファイルが存在しない場合ファイルを作成する
                //if (!(System.IO.Directory.Exists(path)))
                //{                
                //    System.IO.Directory.CreateDirectory(path);
                //}
                // 2009.04.07 Del <<<
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                this._printInfo.status = -1;
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            else
            {
                this._printInfo.status = -1;
                this.DialogResult = DialogResult.Abort;
                return;
            }
           			
		}

		/// <summary>
		/// キャンセルボタン押下時処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CanButton_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			Close();				
		}

		/// <summary>
		/// 出力ボタン押下時処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OKButton_Click(object sender, System.EventArgs e)
		{
            //出力パスが変更された時の処理
            if (this.OutPutFilePath_tEdit.Text == "")
            {
                DialogResult res = TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_EXCLAMATION, // エラーレベル
                    "SFCMN00391U", 						// アセンブリＩＤまたはクラスＩＤ
                    "出力先を入力して下さい", 			// 表示するメッセージ
                    -1, 								// ステータス値
                    MessageBoxButtons.OK);				// 表示するボタン

                if (res == DialogResult.OK)
                {
                    return;
                }
            }

            // 2009.04.07 Add >>>
            string path = System.IO.Path.GetDirectoryName(this._printInfo.outPutFilePathName);
            //整備帳票選択設定で指定されたファイルが存在しない場合ファイルを作成する
            if (!( System.IO.Directory.Exists(path) ))
            {
                try
                {
                    //ディレクトリ作成処理
                    //前回出力したディレクトリが存在しない→デフォルトの出力先を指定して起動
                    //デフォルトの出力先ディレクトリが存在しない→ディレクトリの作成
                    System.IO.Directory.CreateDirectory(path);
                }
                catch (Exception ex)
                {
                    TMsgDisp.Show(
                    emErrorLevel.ERR_LEVEL_STOP,                            // エラーレベル
                    "SFCMN00391U", 						                    // アセンブリＩＤまたはクラスＩＤ
                    ex.Message,                                             // 表示するメッセージ
                    0, 									                // ステータス値
                    MessageBoxButtons.OK);				                    // 表示するボタン
                    this.DialogResult = DialogResult.Abort;
                    this._printInfo.status = -1;
                    this.Close();
                    return;
                }

            }
            // 2009.04.07 Add <<<

            // 2009.05.20 Add >>>
            if (this.radioButton1.Checked)
            {
                this._printInfo.overWriteFlag = false;  // 上書きする
            }
            else if (this.radioButton2.Checked)
            {
                this._printInfo.overWriteFlag = true;   // 追加する
            }
            else
            {
                this._printInfo.overWriteFlag = false;  // 上書きする
            }
            // 2009.05.20 Add <<<

            //PrintMode == "0"の時は抽出処理を行う
            if (this._PrintMode == 0)
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // 抽出処理 
                status = ExtraProc();

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.Close();
                    return;
                }
                // 印刷処理 
                int st = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                st = PrtProc();

                if (st != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.Close();
                    return;
                }
            }
           
            //デフォルト設定マスタ(PrtDefault)を更新
            OutputSet wkOutPutset = new OutputSet();
            int selcnt = 1;
            int ret = 0;
            foreach (OutputSet mfOutputSet in wkOutPutList)
            {
                if ((mfOutputSet != null) && (selcnt == DispName_tComboEditor.SelectedIndex + 1))
                {
                    wkOutPutset = mfOutputSet.Clone();
                    //パスを更新
                    wkOutPutset.OutputFilePathName = this._printInfo.outPutFilePathName;
                    wkOutPutset.OutputFileName = this._printInfo.outPutFileName;

                    ret = this._outPutSetAcs.WriteDefault(ref wkOutPutset);
                    if (ret != 0)
                    {
                        TMsgDisp.Show(
                        emErrorLevel.ERR_LEVEL_STOP,                            // エラーレベル
                        "SFCMN00391U", 						                    // アセンブリＩＤまたはクラスＩＤ
                        "デフォルト設定マスタ更新処理でエラーが発生しました",   // 表示するメッセージ
                        ret, 									                // ステータス値
                        MessageBoxButtons.OK);				                    // 表示するボタン
                        this.DialogResult = DialogResult.Abort;
                        this._printInfo.status = -1;
                        this.Close();
                        return;
                    }  
                    
                    // PrintInfoの選択プログラム通し番号を更新
                    this._printInfo.SelectPgSequenceNo = wkOutPutset.SelectPgSequenceNo;                   
                }
                selcnt++;
            }

            this.DialogResult = DialogResult.OK;
            this._ltimeSelectIndex = this.DispName_tComboEditor.SelectedIndex;
			this.Close();				
		}
		

		/// <summary>
		/// 出力先変更ボタンクリックイベント
		/// </summary>
		/// <remarks>
		/// <br>Note       : 出力先変更ボタンが押された時に処理を行います</br>
		/// <br>Programmer : 23010 中村　仁</br>
		/// <br>Date       : 2006.03.31</br>
		/// </remarks>
		private void OutPutChang_Button_Click(object sender, System.EventArgs e)
		{
			//SaveDialog使用パターン
			DialogResult ret;

			//ダイアログボックスの初期設定を行う
			this.saveFileDialog1.RestoreDirectory = true;
			this.saveFileDialog1.OverwritePrompt  = false;
			//取り合えずＣＳＶのみ
            this.saveFileDialog1.Filter = "CSVファイル(*.csv)|*.csv";
                                        //+ "テキストファイル(*.txt)|*.txt";

			//ファイル名←出力ファイル名
            this.saveFileDialog1.FileName = System.IO.Path.GetFileName(this.fullPath_tEdit.Text);

			//起動ディレクトリ←フルパスからディレクトリを取得
            this.saveFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(this.fullPath_tEdit.Text);

			ret = saveFileDialog1.ShowDialog();

			switch(ret)
			{
				case DialogResult.OK:
				{
					string rdire = System.IO.Directory.GetDirectoryRoot(this.saveFileDialog1.FileName);
					string fullpaht = System.IO.Path.GetFullPath(this.saveFileDialog1.FileName);
					string FileName = System.IO.Path.GetFileName(this.saveFileDialog1.FileName);
					string dire     = System.IO.Path.GetDirectoryName(this.saveFileDialog1.FileName);
					//指定されたディレクトリが存在するか？
					if(System.IO.Directory.Exists(rdire))
					{	
						//指定されたフォルダが存在するか？
						if(System.IO.Directory.Exists(dire))
						{
							//指定されたファイルが存在するか？
							if(System.IO.File.Exists(fullpaht))
							{
								//上書き確認のラベルを表示
								ultraLabel2.Visible = true;
								radioButton1.Visible = true;
								radioButton2.Visible = true;
								radioButton1.Checked = true;
								this.OutPutFilePath_tEdit.Text = System.IO.Path.GetFileName(saveFileDialog1.FileName);
								this.fullPath_tEdit.Text = System.IO.Path.GetFullPath(saveFileDialog1.FileName);
								break;
							}
							//ファイルが存在しない
							else
							{
								//上書き確認のラベルを非表示
								ultraLabel2.Visible = false;
								radioButton1.Visible = false;
								radioButton2.Visible = false;
								this.OutPutFilePath_tEdit.Text = System.IO.Path.GetFileName(saveFileDialog1.FileName);
								this.fullPath_tEdit.Text = System.IO.Path.GetFullPath(saveFileDialog1.FileName);
								break;
							}
						}
						//フォルダが存在しない
						else
						{
							DialogResult res = TMsgDisp.Show( 
								emErrorLevel.ERR_LEVEL_INFO,                        // エラーレベル
								"SFCMN00391U", 						                // アセンブリＩＤまたはクラスＩＤ
								"指定されたファイルが存在しません。作成しますか？", // 表示するメッセージ
								0, 									                // ステータス値
								MessageBoxButtons.YesNo );				            // 表示するボタン
					
							//フォルダを作成します
							if(res == DialogResult.Yes)
							{
								System.IO.Directory.CreateDirectory(dire);
								ultraLabel2.Visible = false;
								radioButton1.Visible = false;
								radioButton2.Visible = false;
								goto case DialogResult.OK;
												
							}
							else
							{
								break;
							}
					
						}
					}
						//ディレクトリが存在しない
					else
					{
						DialogResult ress = TMsgDisp.Show( 
							emErrorLevel.ERR_LEVEL_INFO,                // エラーレベル
							"SFCMN00391U", 						        // アセンブリＩＤまたはクラスＩＤ
							"指定されたディレクトリが存在しません。",   // 表示するメッセージ
							0, 									        // ステータス値
							MessageBoxButtons.OK );				        // 表示するボタン
							break;
					}
				}
				case DialogResult.Cancel:
				{
					break;
				}
			}					
            this._printInfo.outPutFileName = System.IO.Path.GetFileName(this.fullPath_tEdit.Text);
            this._printInfo.outPutFilePathName = this.fullPath_tEdit.Text;

		}

        /// <summary>
        /// 出力パターン変更イベント
        /// </summary>
        /// <remarks>
        /// <br>Note       : 出力パターンが変更された時に発生します</br>
        /// <br>Programmer : 23010 中村　仁</br>
        /// <br>Date       : 2006.05.19</br>
        /// </remarks>
        private void DispName_tComboEditor_SelectionChanged(object sender, EventArgs e)
        {         
            int selcnt = 0;
            selcnt = DispName_tComboEditor.SelectedIndex;
            selcnt++;

            int cnt = 1;
            foreach (OutputSet mfOutputSet in wkOutPutList)
            {
                if ((mfOutputSet != null) && (cnt == selcnt))
                {
                    this._printInfo.frycd = mfOutputSet.OutputPurpose;
                    this._printInfo.prpid = mfOutputSet.OutputFormFileName;
                    this._printInfo.prpnm = mfOutputSet.DisplayName;
                    this._printInfo.extrapgid = mfOutputSet.ExtractionPgId;
                    this._printInfo.extraclassid = mfOutputSet.ExtractionPgClassId;
                    this._printInfo.printpgid = mfOutputSet.OutputPgId;
                    this._printInfo.printclassid = mfOutputSet.OutputPgClassId;

                    //TODO                   
                    this._printInfo.SelectPgSequenceNo = mfOutputSet.SelectPgSequenceNo;
                    this._printInfo.PrintPaperSetCd = mfOutputSet.PrintPaperSetCd;
                
                    DispName_tComboEditor.Text = this._printInfo.prpnm;
                       
         
                    //出力を行った時のselectIndexと現在選択されているselectIndexが同じである場合                               
                    if (DispName_tComboEditor.SelectedIndex == this._ltimeSelectIndex)
                    {
                        RocalDataSetting(0, mfOutputSet);                    
                    }
                    else
                    {
                        RocalDataSetting(1, mfOutputSet);                                                     
                    }
                    //テキストに表示
                    this.fullPath_tEdit.Text = this._printInfo.outPutFilePathName;
                    this.OutPutFilePath_tEdit.Text = this._printInfo.outPutFileName;       
                
                   
                    //上書き表示LabelVisible変更
                    if ((System.IO.File.Exists(this._printInfo.outPutFilePathName)))
                    {
                        ultraLabel2.Visible = true;
                        radioButton1.Visible = true;
                        radioButton2.Visible = true;
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        ultraLabel2.Visible = false;
                        radioButton1.Visible = false;
                        radioButton2.Visible = false;
                        radioButton1.Checked = false;
                    }

                }
                cnt++;
            }
        }
		#endregion      
	}
}
