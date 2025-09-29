using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 支払伝票入力赤伝作成ＵＩクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 支払伝票入力赤伝作成ＵＩの機能を実装します。</br>
	/// <br>Programmer : 18322 木村 武正</br>
	/// <br>Date       : 2006.12.22 携帯.NS用に追加</br>
	/// </remarks>
	internal class SFSIR02102UE : System.Windows.Forms.Form
	{
		# region Private Members (Component)
		private Infragistics.Win.Misc.UltraLabel ultraLabel57;
		private Broadleaf.Library.Windows.Forms.TLine tLine10;
		private Infragistics.Win.Misc.UltraLabel ultraLabel40;
		private Broadleaf.Library.Windows.Forms.TDateEdit detPaymentDate;
		private Infragistics.Win.Misc.UltraButton btnSave;
		private Infragistics.Win.Misc.UltraButton btnCancel;
		private Broadleaf.Library.Windows.Forms.TNedit edtPaymentSlipNo;
		private Broadleaf.Library.Windows.Forms.TArrowKeyControl tArrowKeyControl1;
		private Broadleaf.Library.Windows.Forms.TRetKeyControl tRetKeyControl1;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// 支払伝票入力赤伝作成ＵＩクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 使用するメンバの初期化を行います。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		public SFSIR02102UE()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFSIR02102UE));
            this.detPaymentDate = new Broadleaf.Library.Windows.Forms.TDateEdit();
            this.ultraLabel57 = new Infragistics.Win.Misc.UltraLabel();
            this.btnSave = new Infragistics.Win.Misc.UltraButton();
            this.btnCancel = new Infragistics.Win.Misc.UltraButton();
            this.tLine10 = new Broadleaf.Library.Windows.Forms.TLine();
            this.ultraLabel40 = new Infragistics.Win.Misc.UltraLabel();
            this.edtPaymentSlipNo = new Broadleaf.Library.Windows.Forms.TNedit();
            this.tArrowKeyControl1 = new Broadleaf.Library.Windows.Forms.TArrowKeyControl(this.components);
            this.tRetKeyControl1 = new Broadleaf.Library.Windows.Forms.TRetKeyControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tLine10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPaymentSlipNo)).BeginInit();
            this.SuspendLayout();
            // 
            // detPaymentDate
            // 
            appearance1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(227)))), ((int)(((byte)(156)))));
            appearance1.ForeColor = System.Drawing.Color.Black;
            this.detPaymentDate.ActiveEditAppearance = appearance1;
            this.detPaymentDate.BackColor = System.Drawing.Color.Transparent;
            this.detPaymentDate.CalendarDisp = true;
            this.detPaymentDate.EditAppearance = appearance2;
            this.detPaymentDate.EnableEditors = new Broadleaf.Library.Windows.Forms.TEnableEditors(true, true, true, true);
            this.detPaymentDate.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.detPaymentDate.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            appearance3.TextHAlignAsString = "Left";
            appearance3.TextVAlignAsString = "Middle";
            this.detPaymentDate.LabelAppearance = appearance3;
            this.detPaymentDate.Location = new System.Drawing.Point(104, 48);
            this.detPaymentDate.Name = "detPaymentDate";
            this.detPaymentDate.NecessaryEditors = new Broadleaf.Library.Windows.Forms.TNecessaryEditors(false, false, false, false);
            this.detPaymentDate.Options = new Broadleaf.Library.Windows.Forms.TDateEditOptions(false, false, false, true, false, true);
            this.detPaymentDate.Size = new System.Drawing.Size(172, 24);
            this.detPaymentDate.TabIndex = 1;
            this.detPaymentDate.TabStop = true;
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
            this.ultraLabel57.Text = "赤伝支払日";
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
            this.ultraLabel40.Text = "支払番号";
            // 
            // edtPaymentSlipNo
            // 
            this.edtPaymentSlipNo.ActiveAppearance = appearance6;
            appearance7.TextHAlignAsString = "Right";
            this.edtPaymentSlipNo.Appearance = appearance7;
            this.edtPaymentSlipNo.AutoSelect = true;
            this.edtPaymentSlipNo.CalcSize = new System.Drawing.Size(172, 200);
            this.edtPaymentSlipNo.DataText = "";
            this.edtPaymentSlipNo.ExtCase = new Broadleaf.Library.Windows.Forms.TExtCase(true, true, true, true, true, true, true, true, false);
            this.edtPaymentSlipNo.ExtEdit = new Broadleaf.Library.Windows.Forms.TExtEdit(Broadleaf.Library.Windows.Forms.emCursorPosition.Prev, false, false, 9, new Broadleaf.Library.Windows.Forms.TEnableChars(false, false, false, false, false, true, true));
            this.edtPaymentSlipNo.Font = new System.Drawing.Font("ＭＳ ゴシック", 11F);
            this.edtPaymentSlipNo.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.edtPaymentSlipNo.Location = new System.Drawing.Point(104, 16);
            this.edtPaymentSlipNo.MaxLength = 9;
            this.edtPaymentSlipNo.Name = "edtPaymentSlipNo";
            this.edtPaymentSlipNo.NumEdit = new Broadleaf.Library.Windows.Forms.TNumEdit(false, 0, false, false, false, Broadleaf.Library.Windows.Forms.emZeroSupp.zsFILL);
            this.edtPaymentSlipNo.ReadOnly = true;
            this.edtPaymentSlipNo.Size = new System.Drawing.Size(82, 24);
            this.edtPaymentSlipNo.TabIndex = 0;
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
            // SFSIR02102UE
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(320, 142);
            this.Controls.Add(this.edtPaymentSlipNo);
            this.Controls.Add(this.ultraLabel40);
            this.Controls.Add(this.tLine10);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.detPaymentDate);
            this.Controls.Add(this.ultraLabel57);
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SFSIR02102UE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "支払　赤伝作成";
            this.Load += new System.EventHandler(this.SFSIR02102UE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tLine10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPaymentSlipNo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		# region Private Menbers
		/// <summary>支払伝票クラス</summary>
        private PaymentSlp _paymentSlp;

        private int        _lastMonthlyDate = 0;
		# endregion

		# region public Methods
		/// <summary>
		/// 支払伝票赤伝処理
		/// </summary>
        /// <param name="paymentSlp">支払伝票クラス</param>
		/// <param name="paymentSlipNo">支払伝票番号</param>
        /// <param name="lastMonthlyDate">前回月次締め日</param>
		/// <param name="paymentDate">赤伝支払日付</param>
		/// <returns>ステータス</returns>
		/// <remarks>
		/// <br>Note       : 支払伝票の赤伝処理UI画面を表示します。</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.07.21</br>
		/// </remarks>
		internal DialogResult ShowDialogAkaCreate(PaymentSlp paymentSlp, int paymentSlipNo, int lastMonthlyDate, out int paymentDate)
		{
			// 支払伝票入力画面アクセスクラス
            this._paymentSlp = paymentSlp;

            // 前回締め日
            this._lastMonthlyDate = lastMonthlyDate;

			// 支払番号
			edtPaymentSlipNo.SetInt(paymentSlipNo);

			// 赤伝支払日
			detPaymentDate.SetDateTime(TDateTime.GetSFDateNow());

			// 画面起動
			System.Windows.Forms.DialogResult result = this.ShowDialog();

			// 赤伝支払日
			paymentDate = TDateTime.DateTimeToLongDate(detPaymentDate.GetDateTime());

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
		private void SFSIR02102UE_Load(object sender, System.EventArgs e)
		{
			// 画面初期設定処理
			this.ScreenInitialSetting();

			// 初期カーソルセット
			detPaymentDate.Focus();
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

			// 支払日チェック
			if (detPaymentDate.GetLongDate() == 0)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "支払日を入力して下さい。", 0, MessageBoxButtons.OK);
				detPaymentDate.Focus();
				return;
			}
			if (TDateTime.IsAvailableDate(detPaymentDate.GetDateTime()) == false)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "支払日の日付が不正です。", 0, MessageBoxButtons.OK);
				detPaymentDate.Focus();
				return;
			}

			// 支払日チェック 最終締次更新年月日チェック
			if (TDateTime.DateTimeToLongDate(detPaymentDate.GetDateTime()) <= _paymentSlp.CAddUpUpdDate)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "支払日が前回締日以前になっています。", 0, MessageBoxButtons.OK);
				detPaymentDate.Focus();
				return;
			}

            // ↓ 20070801 18322 a
			if (TDateTime.DateTimeToLongDate(detPaymentDate.GetDateTime()) <= this._lastMonthlyDate)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "支払日が前回月次締日以前になっています。", 0, MessageBoxButtons.OK);
				detPaymentDate.Focus();
				return;
			}
            // ↑ 20070801 18322 a

			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}
		# endregion
	}
}
