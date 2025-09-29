using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Broadleaf.Library.Resources
{
	/// <summary>
	/// 装備アイコンリソース管理クラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 装備アイコンリソースの管理を行います。</br>
	/// <br>Programmer : 980076 妻鳥　謙一郎</br>
	/// <br>Date       : 2004.05.19</br>
	/// <br></br>
	/// </remarks>
	public class EquipmentIconResourceManagement : System.ComponentModel.Component
	{
		# region Private Members (Component)
		private System.Windows.Forms.ImageList Equipment_ImageList_24;
		private System.ComponentModel.IContainer components;
		# endregion

		# region Constructor
		/// <summary>
		/// 装備アイコンリソース管理クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 装備アイコンリソース管理クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.06.19</br>
		/// </remarks>
		public EquipmentIconResourceManagement(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
		}

		/// <summary>
		/// 装備アイコンリソース管理クラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 装備アイコンリソース管理クラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 980076 妻鳥  謙一郎</br>
		/// <br>Date       : 2005.06.19</br>
		/// </remarks>
		public EquipmentIconResourceManagement()
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

		#region コンポーネント デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(EquipmentIconResourceManagement));
			this.Equipment_ImageList_24 = new System.Windows.Forms.ImageList(this.components);
			// 
			// Equipment_ImageList_24
			// 
			this.Equipment_ImageList_24.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
			this.Equipment_ImageList_24.ImageSize = new System.Drawing.Size(24, 24);
			this.Equipment_ImageList_24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Equipment_ImageList_24.ImageStream")));
			this.Equipment_ImageList_24.TransparentColor = System.Drawing.Color.Cyan;

		}
		#endregion

		private static EquipmentIconResourceManagement icon = null;

		# region Properties
		/// <summary>装備用24×24アイコン格納ImageListプロパティ</summary>
		/// <value>装備用24×24のアイコンをコレクション化したImageListの取得を行います。</value>
		public static ImageList Equipment_ImageList16
		{
			get
			{
				if (icon == null) icon = new EquipmentIconResourceManagement();
				//EquipmentIconResourceManagement icon = new EquipmentIconResourceManagement();
				return icon.Equipment_ImageList_24;
			}
		}
		# endregion
	}
}
