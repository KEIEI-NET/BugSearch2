using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 入金伝票入力（入金型）赤伝作成ＵＩクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 入金伝票入力（入金型）赤伝作成ＵＩの機能を実装します。</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.20</br>
	/// </remarks>
	public class SFUKK01403UB : System.Windows.Forms.Form
	{
		# region Private Members (Component)
		private Infragistics.Win.Misc.UltraLabel ultraLabel57;
		private Broadleaf.Library.Windows.Forms.TLine tLine10;
		private Infragistics.Win.Misc.UltraLabel ultraLabel40;
		private Broadleaf.Library.Windows.Forms.TDateEdit detDepositDate;
		private Infragistics.Win.Misc.UltraButton btnSave;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		private Broadleaf.Library.Windows.Forms.TNedit edtDepositSlipNo;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// 入金伝票入力（入金型）赤伝作成ＵＩクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 使用するメンバの初期化を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		public SFUKK01403UB()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();
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
				if(components != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFUKK01403UB));
            this.detDepositDate = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel57 = new Infragistics.Win.Misc.UltraLabel();
            this.btnSave = new Infragistics.Win.Misc.UltraButton();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.tLine10 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraLabel40 = new Infragistics.Win.Misc.UltraLabel();
            this.edtDepositSlipNo = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tLine10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDepositSlipNo)).BeginInit();
            this.SuspendLayout();
            // 
            // detDepositDate
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.detDepositDate.ActiveEditAppearance = appearance1;
            this.detDepositDate.BackColor = System.Drawing.Color.Transparent;
            this.detDepositDate.CalendarDisp = true;
            this.detDepositDate.EditAppearance = appearance2;
            this.detDepositDate.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.detDepositDate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.detDepositDate.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.detDepositDate.LabelAppearance = appearance3;
            this.detDepositDate.Location = new System.Drawing.Point(104, 48);
            this.detDepositDate.Name = "detDepositDate";
            this.detDepositDate.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.detDepositDate.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.detDepositDate.Size = new System.Drawing.Size(172, 24);
            this.detDepositDate.TabIndex = 1;
            this.detDepositDate.TabStop = true;
            // 
            // ultraLabel57
            // 
            appearance4.TextVAlignAsString = "Middle";
            this.ultraLabel57.Appearance = appearance4;
            this.ultraLabel57.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel57.Location = new System.Drawing.Point(16, 48);
            this.ultraLabel57.Name = "ultraLabel57";
            this.ultraLabel57.Size = new System.Drawing.Size(96, 24);
            this.ultraLabel57.TabIndex = 57;
            this.ultraLabel57.Text = "赤伝入金日";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(28, 104);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(132, 25);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "確定(&S)";
            this.btnSave.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(160, 104);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(132, 25);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "戻る(&C)";
            this.btnCancel.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
            // 
            // tLine10
            // 
            this.tLine10.BackColor = System.Drawing.Color.Transparent;
            this.tLine10.LineStyle = Broadleaf.Library.Windows.Forms.emLineStyle.lsDot;
            this.tLine10.Location = new System.Drawing.Point(16, 88);
            this.tLine10.Name = "tLine10";
            this.tLine10.Size = new System.Drawing.Size(288, 8);
            this.tLine10.TabIndex = 187;
            this.tLine10.Text = "tLine10";
            // 
            // ultraLabel40
            // 
            appearance5.TextVAlignAsString = "Middle";
            this.ultraLabel40.Appearance = appearance5;
            this.ultraLabel40.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ultraLabel40.Location = new System.Drawing.Point(16, 16);
            this.ultraLabel40.Name = "ultraLabel40";
            this.ultraLabel40.Size = new System.Drawing.Size(88, 24);
            this.ultraLabel40.TabIndex = 188;
            this.ultraLabel40.Text = "入金番号";
            // 
            // edtDepositSlipNo
            // 
            this.edtDepositSlipNo.ActiveAppearance = appearance6;
            appearance7.TextHAlignAsString = "Right";
            this.edtDepositSlipNo.Appearance = appearance7;
            this.edtDepositSlipNo.AutoSelect = true;
            this.edtDepositSlipNo.CalcSize = new System.Drawing.Size(172, 200);
            this.edtDepositSlipNo.DataText = "";
            this.edtDepositSlipNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.edtDepositSlipNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.edtDepositSlipNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.edtDepositSlipNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.edtDepositSlipNo.Location = new System.Drawing.Point(104, 16);
            this.edtDepositSlipNo.MaxLength = 9;
            this.edtDepositSlipNo.Name = "edtDepositSlipNo";
            this.edtDepositSlipNo.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.edtDepositSlipNo.ReadOnly = true;
            this.edtDepositSlipNo.Size = new System.Drawing.Size(82, 24);
            this.edtDepositSlipNo.TabIndex = 0;
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
            // SFUKK01403UB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(320, 142);
            this.Controls.Add(this.edtDepositSlipNo);
            this.Controls.Add(this.ultraLabel40);
            this.Controls.Add(this.tLine10);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.detDepositDate);
            this.Controls.Add(this.ultraLabel57);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SFUKK01403UB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "入金　赤伝作成";
            this.Load += new System.EventHandler(this.SFUKK01403UB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tLine10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDepositSlipNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Private Menbers
		/// <summary>入金伝票入力画面(入金型)アクセスクラス</summary>
		private InputDepositNormalTypeAcs _inputDepositNormalTypeAcs;
		# endregion

		# region public Methods
		/// <summary>
		/// 入金伝票赤伝処理
		/// </summary>
		/// <param name="inputDepositNormalTypeAcs">入金伝票入力画面(入金型)アクセスクラス</param>
		/// <param name="depositSlipNo">入金番号</param>
		/// <param name="depositDate">赤伝入金日付</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 入金伝票の赤伝処理UI画面を表示します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		public System.Windows.Forms.DialogResult ShowDialogAkaCreate(InputDepositNormalTypeAcs inputDepositNormalTypeAcs, int depositSlipNo, out int depositDate)
		{
			// 入金伝票入力画面(入金型)アクセスクラス
			this._inputDepositNormalTypeAcs = inputDepositNormalTypeAcs;

			// 入金番号
			edtDepositSlipNo.SetInt(depositSlipNo);

			// 赤伝入金日
			detDepositDate.SetDateTime(TDateTime.GetSFDateNow());

			// 画面起動
			System.Windows.Forms.DialogResult result = this.ShowDialog();

			// 赤伝入金日
			depositDate = TDateTime.DateTimeToLongDate(detDepositDate.GetDateTime());

			return result;
		}
		# endregion

		# region Private Methods
		/// <summary>
		/// 画面初期設定処理
		/// </summary>
		/// <remarks>
		/// <br>Note       : 画面の初期設定を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		private void ScreenInitialSetting()
		{
			ImageList imageList16 = IconResourceManagement.ImageList16;

			// 確定ボタン
			btnSave.ImageList = imageList16;
			btnSave.Appearance.Image = Size16_Index.SAVE;

			// キャンセルボタン
			btnCancel.ImageList = imageList16;
			btnCancel.Appearance.Image = Size16_Index.BEFORE;
		}
		# endregion

		# region Control Events
		/// <summary>
		/// 画面ロードイベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込む時に発生します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void SFUKK01403UB_Load(object sender, System.EventArgs e)
		{
			// 画面初期設定処理
			this.ScreenInitialSetting();

			// 初期カーソルセット
			detDepositDate.Focus();
		}

		/// <summary>
		/// 保存ボタン押下イベント
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントデータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーが保存ボタンをクリックした時に発生します。</br>
		/// <br>Programmer  : 97036 amami</br>
		/// <br>Date        : 2005.07.21</br>
		/// </remarks>
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = System.Windows.Forms.DialogResult.None;

			// 入金日チェック
			if (detDepositDate.GetLongDate() == 0)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "入金日を入力して下さい。", 0, MessageBoxButtons.OK);
				detDepositDate.Focus();
				return;
			}
			if (TDateTime.IsAvailableDate(detDepositDate.GetDateTime()) == false)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "入金日の日付が不正です。", 0, MessageBoxButtons.OK);
				detDepositDate.Focus();
				return;
			}

			// 入金日チェック 最終締次更新年月日チェック
			if (_inputDepositNormalTypeAcs.CheckPastCAddUpUpdDate(detDepositDate.GetLongDate()) <= 0)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "入金日が前回請求締日以前になっています。", 0, MessageBoxButtons.OK);
				detDepositDate.Focus();
				return;
			}

            // ↓ 20070801 18322 a
            if (detDepositDate.GetLongDate() <= this._inputDepositNormalTypeAcs.GetLastMonthlyDate())
            {
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "入金日が前回月次締日以前になっています。", 0, MessageBoxButtons.OK);
				detDepositDate.Focus();
				return;
            }
            // ↑ 20070801 18322 a

			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}
		# endregion
	}
}
