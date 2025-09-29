using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// SFCMN00221UL の概要の説明です。
	/// </summary>
	internal class SFCMN00221UL : System.Windows.Forms.UserControl
	{
		# region Components
		private Infragistics.Win.Misc.UltraLabel uLabel_Title2;
		private Infragistics.Win.Misc.UltraLabel uLabel_Title1;
		private System.ComponentModel.IContainer components = null;
		# endregion

		// ===================================================================================== //
		// コンストラクタ
		// ===================================================================================== //
		# region Constructor
		/// <summary>
		/// 抽出中フォームクラスコンストラクタ
		/// </summary>
		public SFCMN00221UL()
		{
			InitializeComponent();
		}
		# endregion

		// ===================================================================================== //
		// 破棄処理
		// ===================================================================================== //
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

		// ===================================================================================== //
		// コンポーネント デザイナ デザイナで作成されたコード
		// ===================================================================================== //
		#region コンポーネント デザイナ デザイナで作成されたコード
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
			Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
			this.uLabel_Title2 = new Infragistics.Win.Misc.UltraLabel();
			this.uLabel_Title1 = new Infragistics.Win.Misc.UltraLabel();
			this.SuspendLayout();
			// 
			// uLabel_Title2
			// 
			appearance1.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance1.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.uLabel_Title2.Appearance = appearance1;
			this.uLabel_Title2.BackColor = System.Drawing.Color.Transparent;
			this.uLabel_Title2.Dock = System.Windows.Forms.DockStyle.Top;
			this.uLabel_Title2.Location = new System.Drawing.Point(0, 18);
			this.uLabel_Title2.Name = "uLabel_Title2";
			this.uLabel_Title2.Size = new System.Drawing.Size(250, 18);
			this.uLabel_Title2.TabIndex = 5;
			this.uLabel_Title2.Text = "しばらくお待ち下さい。";
			// 
			// uLabel_Title1
			// 
			appearance2.TextHAlign = Infragistics.Win.HAlign.Center;
			appearance2.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.uLabel_Title1.Appearance = appearance2;
			this.uLabel_Title1.BackColor = System.Drawing.Color.Transparent;
			this.uLabel_Title1.Dock = System.Windows.Forms.DockStyle.Top;
			this.uLabel_Title1.Location = new System.Drawing.Point(0, 0);
			this.uLabel_Title1.Name = "uLabel_Title1";
			this.uLabel_Title1.Size = new System.Drawing.Size(250, 18);
			this.uLabel_Title1.TabIndex = 4;
			this.uLabel_Title1.Text = "現在、○○情報を抽出中です。";
			// 
			// SFCMN00221UL
			// 
			this.BackColor = System.Drawing.Color.GhostWhite;
			this.Controls.Add(this.uLabel_Title2);
			this.Controls.Add(this.uLabel_Title1);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.Name = "SFCMN00221UL";
			this.Size = new System.Drawing.Size(250, 40);
			this.ResumeLayout(false);

		}
		#endregion

		// ===================================================================================== //
		// プライベート変数
		// ===================================================================================== //
		# region Private Members
		private string _dataType = "";
		private int _mode = 0;
		# endregion

		// ===================================================================================== //
		// プロパティ
		// ===================================================================================== //
		# region Properties
		/// <summary>
		/// データタイプ文字列
		/// </summary>
		internal string DataType
		{
			set
			{
				this._dataType = value;
				this.uLabel_Title1.Text = "現在、" + this._dataType + "情報を抽出中です。";
				this.uLabel_Title2.Text = "しばらくお待ち下さい。";
			}
			get
			{
				return this._dataType;
			}
		}

		/// <summary>
		/// モードプロパティ
		/// </summary>
		internal int mode
		{
			set
			{
				this._mode = value;

				if (this._mode == 0)
				{
					this.uLabel_Title1.Text = "現在、" + this._dataType + "情報を抽出中です。";
					this.uLabel_Title2.Text = "しばらくお待ち下さい。";
				}
				else
				{
					this.uLabel_Title1.Text = "該当するデータが";
					this.uLabel_Title2.Text = "見つかりませんでした。";
				}
			}
			get
			{
				return this._mode;
			}
		}
		# endregion
	}
}
