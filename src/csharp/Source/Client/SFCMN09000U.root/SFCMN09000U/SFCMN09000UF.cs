using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// その他用フォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : その他パターンのマスタメンテナンスを表示します。</br>
	/// <br>Programmer : 980076 妻鳥　謙一郎</br>
	/// <br>Date       : 2004.03.19</br>
	/// <br></br>
	/// </remarks>
	public class SFCMN09000UF : System.Windows.Forms.Form
	{
		# region Private Members (Component)
		private System.ComponentModel.IContainer components = null;
		# endregion

		# region Constructor
		/// <summary>
		/// その他用フォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 単票表示フォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public SFCMN09000UF()
		{
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
			// 
			// SFCMN09000UF
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 15);
			this.BackColor = System.Drawing.Color.GhostWhite;
			this.ClientSize = new System.Drawing.Size(759, 670);
			this.Font = new System.Drawing.Font("ＭＳ ゴシック", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(128)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "SFCMN09000UF";
			this.Text = "SFCMN09000UF";

		}
		#endregion

		# region Private Members
		private SFCMN09000UA _owningForm;
		private Form _otherTypeObj;
		private ProgramItem _programItemObj;
		# endregion

		# region Internal Methods
		/// <summary>
		/// 画面表示処理
		/// </summary>
		/// <param name="owningForm">親フォームのインスタンス</param>
		/// <param name="programItemObj">プログラム情報管理クラスのインスタンス</param>
		/// <remarks>
		/// <br>Note       : 親フォームのインスタンスを受け取り、自身のフォームをモードレスで表示します。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		internal void ShowMe(SFCMN09000UA owningForm, ProgramItem programItemObj)
		{
			this._owningForm = owningForm;
			this._programItemObj = programItemObj;
			this._otherTypeObj = (Form)programItemObj.CustomForm;
			this.Show();

			this.Font = this._otherTypeObj.Font;

			this._otherTypeObj.TopLevel = false;
			this._otherTypeObj.FormBorderStyle = FormBorderStyle.None;
			this._otherTypeObj.Show();
			this.Controls.Add(this._otherTypeObj);
			this._otherTypeObj.Dock = System.Windows.Forms.DockStyle.Fill;

			this._otherTypeObj.Closed +=new EventHandler(OtherTypeObj_Closed);
		}
		# endregion

		# region Control Events
		/// <summary>
		/// Closedイベント用メソッド
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータクラス</param>
		/// <remarks>
		/// <br>Note       : 親フォームのインスタンスを受け取り、自身のフォームをモードレスで表示します。</br>
		/// <br>Programmer : 980079 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public void OtherTypeObj_Closed(object sender, EventArgs e)
		{
			this.Close();
		}
		# endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/10 ADD
        /// <summary>
        /// 親タブがアクティブになった場合のフォーカス制御
        /// </summary>
        public void SetFocusOnParentTabActive()
        {
            this.Focus();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/10 ADD
	}
}
