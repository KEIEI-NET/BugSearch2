using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// 簡易マスタメンテナンスメニューフォームクラス
	/// </summary>
	/// <remarks>
	/// <br>Note       : 簡易マスタメンテナンスのメニューです。</br>
	/// <br>Programmer : 23001 秋山　亮介</br>
	/// <br>Date       : 2007.03.26</br>
	/// </remarks>
	public partial class SimpleMasterMaintenanceMenu : Form
	{
		#region << Constructor >>

		/// <summary>
		/// 簡易マスタメンテナンスメニューフォームクラスコンストラクタ
		/// </summary>
		/// <remarks>
		/// <br>Note       : 簡易マスタメンテナンスメニューフォームクラスの新しいインスタンスを初期化します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		public SimpleMasterMaintenanceMenu()
		{
			InitializeComponent();
		}

		#endregion

		#region << Private Members >>

		/// <summary>メニュー設定リスト</summary>
		private List<MenuSetting> _menuSettingList = null;

		#endregion

		#region << Private Constant >>

		private const string         ctMenuSettingFileName = "SimpleMasterMaintenance_MenuSetting.xml";
		private static readonly Size ctButtonSize          = new Size( 200, 50 );
		//private const int            ctButtonCol           = 2; //Change 2008/01/17 Maki 
        private const int            ctButtonCol           = 1; //Change 2008/01/17 Maki 
		private const int            ctButtonRow           = 5;

		#endregion

		#region << Private Methods >>

		#region ■メニューボタン設定処理

		private void MenuButtonSetting()
		{
			this._menuSettingList = MenuSetting.Load( ctMenuSettingFileName );

			int index = 0;
			foreach( MenuSetting menuSetting in this._menuSettingList ) {
				// ボタン作成
				Button button = new Button();
				button.Name     = "MenuButton" + ( index + 1 ).ToString();
				button.Text     = menuSetting.Title;
				button.Size     = ctButtonSize;
				button.TabIndex = index;
				button.Click   += new EventHandler(this.MenuButton_Click);
				//button.Location = new Point( ( index % ctButtonCol ) * ctButtonSize.Width, ( index / ctButtonCol ) * ctButtonSize.Height ); //Change 2008/01/17
                button.Location = new Point( 0, (index / ctButtonCol) * ctButtonSize.Height); //Change 2008/01/17
				button.Tag      = menuSetting;
				button.Font     = new Font( "ＭＳ ゴシック", 9F, FontStyle.Bold, GraphicsUnit.Point, 128 );
				this.Controls.Add( button );

				index++;
			}

            this.ClientSize = new Size(ctButtonSize.Width * ctButtonCol, Math.Min(ctButtonSize.Height * ctButtonRow, (((index - 1) / ctButtonCol) + 1) * ctButtonSize.Height));
		}

		#endregion

		#endregion

		#region << Control Events >>

		#region ■Load イベント (SimpleMasterMaintenanceMenu)

		/// <summary>
		/// Load イベント (SimpleMasterMaintenanceMenu)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : フォームが初めて表示されるときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void SimpleMasterMaintenanceMenu_Load( object sender, EventArgs e )
		{
			this.MenuButtonSetting();
		}

		#endregion

		#region ■Click イベント (RunMulticastInfo_button)

		/// <summary>
		/// Click イベント (MenuButton)
		/// </summary>
		/// <param name="sender">対象オブジェクト</param>
		/// <param name="e">イベントパラメータ</param>
		/// <remarks>
		/// <br>Note       : コントロールがクリックされたときに発生します。</br>
		/// <br>Programmer : 23001 秋山　亮介</br>
		/// <br>Date       : 2007.03.26</br>
		/// </remarks>
		private void MenuButton_Click( object sender, EventArgs e )
		{
			Button menuButton = sender as Button;
			if( menuButton == null ) {
				return;
			}

			MenuSetting menuSetting = menuButton.Tag as MenuSetting;
			if( menuSetting == null ) {
				return;
			}

			if( ( menuSetting.Type == 0 ) || 
				( String.IsNullOrEmpty( menuSetting.AssemblyFileName ) ) || 
				( String.IsNullOrEmpty( menuSetting.ClassName ) ) ) {
				return;
			}

			if( ( menuSetting.Form == null ) || 
				( menuSetting.Form.IsDisposed ) ) {
				try {
					switch( menuSetting.Type ) {
						case 2:
						{
							menuSetting.Form = new SimpleMasterMaintenanceMulti( menuSetting.AssemblyFileName, menuSetting.ClassName, typeof( Form ) );
							menuSetting.Form.Text = menuSetting.Title;
							break;
						}
					}
				}
				catch( Exception ex ) {
					MessageBox.Show( this, ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1 );
				}
			}
			
			if( ( menuSetting.Form != null ) && 
				( ! menuSetting.Form.IsDisposed ) ) {
				switch( menuSetting.Type ) {
					case 2:
					{
						( ( SimpleMasterMaintenanceMulti )menuSetting.Form ).Show();
						break;
					}
				}
			}
		}

		#endregion

		#endregion

		#region ★簡易マスタメンテナンスメニュー設定クラス

		/// <summary>
		/// 簡易マスタメンテナンスメニュー設定クラス
		/// </summary>
		private class MenuSetting
		{
			#region << Constructor >>

			/// <summary>
			/// 簡易マスタメンテナンスメニュー設定クラスコンストラクタ
			/// </summary>
			public MenuSetting()
			{
			}

			/// <summary>
			/// 簡易マスタメンテナンスメニュー設定クラスコンストラクタ
			/// </summary>
			public MenuSetting( int type, string title, string assemblyFileName, string className, Form form )
			{
				this._type             = type;
				this._title            = title;
				this._assemblyFileName = assemblyFileName;
				this._className        = className;
				this._form             = form;
			}

			#endregion

			#region << Private Members >>

			/// <summary>タイプ</summary>
			private int    _type             = 0;
			/// <summary>タイトル</summary>
			private string _title            = "";
			/// <summary>アセンブリファイル名</summary>
			private string _assemblyFileName = "";
			/// <summary>クラス名</summary>
			private string _className        = "";
			/// <summary>編集フォーム</summary>
			private Form   _form             = null;

			#endregion

			#region << Public Properties >>

			/// <summary>タイプ</summary>
			public int Type
			{
				get {
					return this._type;
				}
				set {
					this._type = value;
				}
			}

			/// <summary>
			/// タイトル
			/// </summary>
			public string Title
			{
				get {
					return this._title;
				}
				set {
					this._title = value;
				}
			}

			/// <summary>
			/// アセンブリファイル名
			/// </summary>
			public string AssemblyFileName
			{
				get {
					return this._assemblyFileName;
				}
				set {
					this._assemblyFileName = value;
				}
			}

			/// <summary>
			/// クラス名
			/// </summary>
			public string ClassName
			{
				get {
					return this._className;
				}
				set {
					this._className = value;
				}
			}

			/// <summary>
			/// 編集フォーム
			/// </summary>
			public Form Form
			{
				get {
					return this._form;
				}
				set {
					this._form = value;
				}
			}

			#endregion

			#region << Static Methods >>

			/// <summary>
			/// メニュー設定読み込み処理
			/// </summary>
			/// <param name="fileName">ファイル名</param>
			/// <returns>メニュー設定リスト</returns>
			public static List<MenuSetting> Load( string fileName )
			{
				List<MenuSetting> retList = new List<MenuSetting>();

				// ファイルが存在しない
				if( ! File.Exists( fileName ) ) {
					return retList;
				}

				XmlDocument xmlDoc = null;

				try {
					xmlDoc = new XmlDocument();
					xmlDoc.Load( fileName );

					// 設定の読み込み
					XmlNodeList menuItems = xmlDoc.SelectNodes( "/MenuSetting/MenuItems/MenuItem" );

					foreach( XmlNode menuItem in menuItems ) {
						MenuSetting menuSetting = new MenuSetting();

						menuSetting.Type             = GetXmlAttributeValueInt32(  menuItem.Attributes, "Type" );
						menuSetting.Title            = GetXmlAttributeValueString( menuItem.Attributes, "Title" );
						menuSetting.AssemblyFileName = GetXmlAttributeValueString( menuItem.Attributes, "AssemblyFileName" );
						menuSetting.ClassName        = GetXmlAttributeValueString( menuItem.Attributes, "ClassName" );

						retList.Add( menuSetting );
					}
				}
				catch {
				}
				finally {
				}

				return retList;
			}

			/// <summary>
			/// XML属性値取得処理(Int32)
			/// </summary>
			/// <param name="attributes">XML属性コレクション</param>
			/// <param name="name">XML属性名</param>
			/// <returns>XML属性値</returns>
			private static int GetXmlAttributeValueInt32( XmlAttributeCollection attributes, string name )
			{
				int value = 0;

				if( attributes[ name ] != null ) {
					if( ! Int32.TryParse( attributes[ name ].Value, out value ) ) {
						value = 0;
					}
				}

				return value;
			}

			/// <summary>
			/// XML属性値取得処理(String)
			/// </summary>
			/// <param name="attributes">XML属性コレクション</param>
			/// <param name="name">XML属性名</param>
			/// <returns>XML属性値</returns>
			private static string GetXmlAttributeValueString( XmlAttributeCollection attributes, string name )
			{
				string value = "";

				if( attributes[ name ] != null ) {
					value = attributes[ name ].Value;
				}

				return value;
			}

			#endregion
		}

		#endregion
	}
}