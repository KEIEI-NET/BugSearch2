using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// .NS配信設定画面設定クラス
	/// </summary>
	[Serializable]
	public class MulticastInfoEditorSetting
	{

		#region << Constructor >>

		/// <summary>
		/// .NS配信設定画面設定クラスの新しいインスタンスを初期化します。
		/// </summary>
		public MulticastInfoEditorSetting()
		{
		}

		/// <summary>
		/// .NS配信設定画面設定クラスの新しいインスタンスを初期化します。
		/// </summary>
		public MulticastInfoEditorSetting( string anothersheetFileDirPath )
		{
			this._anothersheetFileDirPath = anothersheetFileDirPath;
		}

		#endregion


		#region << Private Members >>

		/// <summary>別紙ファイル配置パス</summary>
		private string _anothersheetFileDirPath = "";

		#endregion


		#region << Public Properties >>

		/// <summary>
		/// 別紙ファイル配置パス
		/// </summary>
		public string AnothersheetFileDirPath
		{
			get {
				return this._anothersheetFileDirPath;
			}
			set {
				this._anothersheetFileDirPath = value;
			}
		}

		#endregion


		#region << Public Methods >>

		/// <summary>
		/// クローンオブジェクトを作成します。
		/// </summary>
		/// <returns>クローンオブジェクト。</returns>
		public MulticastInfoEditorSetting Clone()
		{
			return new MulticastInfoEditorSetting( this._anothersheetFileDirPath );
		}

		#endregion


		#region << Public Static Methods >>

		/// <summary>
		/// .NS配信設定画面設定クラスを読み込みます。
		/// </summary>
		/// <param name="fileName">.NS配信設定画面設定ファイル名</param>
		/// <returns>.NS配信設定画面設定クラス</returns>
		public static MulticastInfoEditorSetting Load( string fileName )
		{
			MulticastInfoEditorSetting multicastInfoEditorSetting = null;

			if( ! File.Exists( fileName ) ) {
				multicastInfoEditorSetting = new MulticastInfoEditorSetting();
				multicastInfoEditorSetting.AnothersheetFileDirPath = Directory.GetCurrentDirectory();
				return multicastInfoEditorSetting;
			}

			StreamReader sr = null;
			try {
				using( sr = new StreamReader( fileName, Encoding.UTF8 ) ) {
					XmlSerializer xmlSerializer = new XmlSerializer( typeof( MulticastInfoEditorSetting ) );
					multicastInfoEditorSetting = xmlSerializer.Deserialize( sr ) as MulticastInfoEditorSetting;
				}
			}
			catch {
			}
			finally {
				if( multicastInfoEditorSetting == null ) {
					multicastInfoEditorSetting = new MulticastInfoEditorSetting();
					multicastInfoEditorSetting.AnothersheetFileDirPath = Directory.GetCurrentDirectory();
				}
			}

			return multicastInfoEditorSetting;
		}

		/// <summary>
		/// .NS配信設定画面設定クラスを保存します。
		/// </summary>
		/// <param name="fileName">.NS配信設定画面設定ファイル名</param>
		/// <param name="multicastInfoEditorSetting">.NS配信設定画面設定クラス</param>
		public static void Save( string fileName, MulticastInfoEditorSetting multicastInfoEditorSetting )
		{
			if( ( String.IsNullOrEmpty( fileName ) ) || 
				( multicastInfoEditorSetting == null ) ) {
				return;
			}

			StreamWriter sw = null;
			try {
				using( sw = new StreamWriter( fileName, false, Encoding.UTF8 ) ) {
					XmlSerializer xmlSerializer = new XmlSerializer( typeof( MulticastInfoEditorSetting ) );
					xmlSerializer.Serialize( sw, multicastInfoEditorSetting );
				}
			}
			catch {
			}
			finally {
			}
		}

		#endregion

    }
}
