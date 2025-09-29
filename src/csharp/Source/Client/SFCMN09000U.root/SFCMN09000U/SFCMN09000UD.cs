using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 抽出方法設定フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 抽出方法設定を行います。</br>
	/// <br>Programmer : 980076 妻鳥　謙一郎</br>
	/// <br>Date       : 2004.03.19</br>
	/// <br></br>
	/// </remarks>
	internal class SFCMN09000UD : System.Windows.Forms.Form
	{
		# region Private Members (Component)
		private Infragistics.Win.Misc.UltraButton Decision_Button;
		private Infragistics.Win.Misc.UltraButton Close_Button;
		private Infragistics.Win.UltraWinEditors.UltraOptionSet ExtractionSetUp_OptionSet;

		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;
		# endregion

		# region Constructors
		/// <summary>
		/// 抽出方法設定フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 抽出方法設定フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		internal SFCMN09000UD()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 抽出方法設定フォームクラスコンストラクタ
		/// </summary>
		/// <param name="type">抽出方法設定</param>
		/// <remarks>
		/// <br>Note       : 抽出方法設定フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		internal SFCMN09000UD(ExtractionSetUpType type)
		{
			InitializeComponent();

			switch (type)
			{
				case ExtractionSetUpType.SearchAuto:
				{
					this.ExtractionSetUp_OptionSet.CheckedIndex = 0;
					break;
				}
				case ExtractionSetUpType.SearchSpecification:
				{
					this.ExtractionSetUp_OptionSet.CheckedIndex = 1;
					break;
				}
			}
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
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.ValueListItem valueListItem1 = new Infragistics.Win.ValueListItem();
			Infragistics.Win.ValueListItem valueListItem2 = new Infragistics.Win.ValueListItem();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SFCMN09000UD));
			this.ExtractionSetUp_OptionSet = new Infragistics.Win.UltraWinEditors.UltraOptionSet();
			this.Decision_Button = new Infragistics.Win.Misc.UltraButton();
			this.Close_Button = new Infragistics.Win.Misc.UltraButton();
			((System.ComponentModel.ISupportInitialize)(this.ExtractionSetUp_OptionSet)).BeginInit();
			this.SuspendLayout();
			// 
			// ExtractionSetUp_OptionSet
			// 
			this.ExtractionSetUp_OptionSet.BorderStyle = Infragistics.Win.UIElementBorderStyle.Etched;
			this.ExtractionSetUp_OptionSet.ItemAppearance = appearance1;
			this.ExtractionSetUp_OptionSet.ItemOrigin = new System.Drawing.Point(5, 5);
			valueListItem1.DataValue = "Default Item";
			valueListItem1.DisplayText = "全件自動抽出";
			valueListItem2.DataValue = "ValueListItem1";
			valueListItem2.DisplayText = "件数指定抽出";
			this.ExtractionSetUp_OptionSet.Items.Add(valueListItem1);
			this.ExtractionSetUp_OptionSet.Items.Add(valueListItem2);
			this.ExtractionSetUp_OptionSet.ItemSpacingVertical = 5;
			this.ExtractionSetUp_OptionSet.Location = new System.Drawing.Point(10, 10);
			this.ExtractionSetUp_OptionSet.Name = "ExtractionSetUp_OptionSet";
			this.ExtractionSetUp_OptionSet.Size = new System.Drawing.Size(210, 60);
			this.ExtractionSetUp_OptionSet.TabIndex = 0;
			// 
			// Decision_Button
			// 
            this.Decision_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.Decision_Button.Location = new System.Drawing.Point(40, 80);
			this.Decision_Button.Name = "Decision_Button";
			this.Decision_Button.Size = new System.Drawing.Size(90, 30);
			this.Decision_Button.TabIndex = 1;
			this.Decision_Button.Text = "確定(&S)";
			this.Decision_Button.Click += new System.EventHandler(this.Decision_Button_Click);
			// 
			// Close_Button
			// 
            this.Close_Button.UseHotTracking = Infragistics.Win.DefaultableBoolean.True;
			this.Close_Button.Location = new System.Drawing.Point(130, 80);
			this.Close_Button.Name = "Close_Button";
			this.Close_Button.Size = new System.Drawing.Size(90, 30);
			this.Close_Button.TabIndex = 2;
			this.Close_Button.Text = "戻る(&X)";
			this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
			// 
			// SFCMN09000UD
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
			this.BackColor = System.Drawing.Color.GhostWhite;
			this.ClientSize = new System.Drawing.Size(232, 123);
			this.Controls.Add(this.Close_Button);
			this.Controls.Add(this.Decision_Button);
			this.Controls.Add(this.ExtractionSetUp_OptionSet);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "SFCMN09000UD";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "抽出方法設定";
			this.Load += new System.EventHandler(this.SFCMN09000UD_Load);
			((System.ComponentModel.ISupportInitialize)(this.ExtractionSetUp_OptionSet)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		# region Internal Methods
		/// <summary>
		/// 抽出方法設定取得処理
		/// </summary>
		/// <returns>抽出方法設定値</returns>
		/// <remarks>
		/// <br>Note       : 画面で選択中の抽出方法設定を取得します。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		internal ExtractionSetUpType GetExtractionSetUpType()
		{
			if (this.ExtractionSetUp_OptionSet.CheckedIndex == 0)
			{
				return ExtractionSetUpType.SearchAuto;
			}
			else
			{
				return ExtractionSetUpType.SearchSpecification;
			}
		}
		# endregion

		# region Control Events
		/// <summary>
		/// Form.Load イベント(SFCMN09000UD)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : ユーザーがフォームを読み込むときに発生します。</br>
		/// <br>Programmer  : 980076 妻鳥  謙一郎</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void SFCMN09000UD_Load(object sender, System.EventArgs e)
		{
			// アイコンリソース管理クラスを使用して、アイコンを表示する
			ImageList imageList16 = IconResourceManagement.ImageList16;

			this.Decision_Button.ImageList = imageList16;
			this.Close_Button.ImageList = imageList16;
			this.Decision_Button.Appearance.Image = Size16_Index.DECISION;
			this.Close_Button.Appearance.Image = Size16_Index.CLOSE;
		}

		/// <summary>
		/// Control.Click イベント(Decision_Button_Click)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 確定ボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 980076 妻鳥  謙一郎</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Decision_Button_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		/// <summary>
		/// Control.Click イベント(Close_Button_Click)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note　　　  : 閉じるボタンコントロールがクリックされたときに発生します。</br>
		/// <br>Programmer  : 980076 妻鳥  謙一郎</br>
		/// <br>Date        : 2005.03.19</br>
		/// </remarks>
		private void Close_Button_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		# endregion
	}
}
