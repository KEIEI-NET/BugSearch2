using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Broadleaf.Library.Resources
{
	/// <summary>
	/// 申請書類システム用アイコンリソース管理クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 申請書類システム用アイコンリソースの管理を行います。</br>
	/// <br>Programmer : 980076 妻鳥　謙一郎</br>
	/// <br>Date       : 2004.03.19</br>
	/// <br></br>
	/// <br>Update Note : </br>
	/// <br>2006.12.13 men 余計なインスタンス化処理を省いて高速化</br>
	/// </remarks>
	public class ApplyDocIconResourceManagement : System.ComponentModel.Component
	{
		# region Private Members (Component)

		private System.Windows.Forms.ImageList ApplyDoc1_ImageList_16;
		private System.Windows.Forms.ImageList ApplyDoc2_ImageList_16;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// 申請書類システム用アイコンリソース管理クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : アイコンリソース管理クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.03.19</br>
		/// </remarks>
		public ApplyDocIconResourceManagement()
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
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}
		# endregion

		#region コンポーネント デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を 
		/// コード］エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplyDocIconResourceManagement));
			this.ApplyDoc1_ImageList_16 = new System.Windows.Forms.ImageList(this.components);
			this.ApplyDoc2_ImageList_16 = new System.Windows.Forms.ImageList(this.components);
			// 
			// ApplyDoc1_ImageList_16
			// 
			this.ApplyDoc1_ImageList_16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ApplyDoc1_ImageList_16.ImageStream")));
			this.ApplyDoc1_ImageList_16.TransparentColor = System.Drawing.Color.Cyan;
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(0, "");
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(1, "");
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(2, "");
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(3, "");
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(4, "");
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(5, "");
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(6, "");
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(7, "");
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(8, "");
			this.ApplyDoc1_ImageList_16.Images.SetKeyName(9, "");
			// 
			// ApplyDoc2_ImageList_16
			// 
			this.ApplyDoc2_ImageList_16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ApplyDoc2_ImageList_16.ImageStream")));
			this.ApplyDoc2_ImageList_16.TransparentColor = System.Drawing.Color.Cyan;
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(0, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(1, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(2, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(3, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(4, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(5, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(6, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(7, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(8, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(9, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(10, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(11, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(12, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(13, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(14, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(15, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(16, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(17, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(18, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(19, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(20, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(21, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(22, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(23, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(24, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(25, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(26, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(27, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(28, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(29, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(30, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(31, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(32, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(33, "");
			this.ApplyDoc2_ImageList_16.Images.SetKeyName(34, "");

		}
		#endregion

		private static ApplyDocIconResourceManagement _icon = null;									// 2006.12.13 men DEL

		# region Properties
		/// <summary>申請書類用16×16アイコン格納ImageListプロパティ①</summary>
		/// <value>申請書類用16×16のアイコンをコレクション化したImageListの取得を行います。</value>
		public static ImageList ApplyDoc1_ImageList16
		{
			get
			{
				//ApplyDocIconResourceManagement icon = new ApplyDocIconResourceManagement();		// 2006.12.13 men DEL
				//return icon.ApplyDoc1_ImageList_16;												// 2006.12.13 men DEL
				if (_icon == null) _icon = new ApplyDocIconResourceManagement();					// 2006.12.13 men ADD
				return _icon.ApplyDoc1_ImageList_16;												// 2006.12.13 men ADD
			}
		}

		/// <summary>申請書類用16×16アイコン格納ImageListプロパティ②</summary>
		/// <value>申請書類用16×16のアイコンをコレクション化したImageListの取得を行います。</value>
		public static ImageList ApplyDoc2_ImageList16
		{
			get
			{
				//ApplyDocIconResourceManagement icon = new ApplyDocIconResourceManagement();		// 2006.12.13 men DEL
				//return icon.ApplyDoc2_ImageList_16;												// 2006.12.13 men DEL
				if (_icon == null) _icon = new ApplyDocIconResourceManagement();					// 2006.12.13 men ADD
				return _icon.ApplyDoc2_ImageList_16;												// 2006.12.13 men ADD
			}
		}
		# endregion
	}
}
