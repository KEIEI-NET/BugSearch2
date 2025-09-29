using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// .NS�z�M�ݒ��ʐݒ�N���X
	/// </summary>
	[Serializable]
	public class MulticastInfoEditorSetting
	{

		#region << Constructor >>

		/// <summary>
		/// .NS�z�M�ݒ��ʐݒ�N���X�̐V�����C���X�^���X�����������܂��B
		/// </summary>
		public MulticastInfoEditorSetting()
		{
		}

		/// <summary>
		/// .NS�z�M�ݒ��ʐݒ�N���X�̐V�����C���X�^���X�����������܂��B
		/// </summary>
		public MulticastInfoEditorSetting( string anothersheetFileDirPath )
		{
			this._anothersheetFileDirPath = anothersheetFileDirPath;
		}

		#endregion


		#region << Private Members >>

		/// <summary>�ʎ��t�@�C���z�u�p�X</summary>
		private string _anothersheetFileDirPath = "";

		#endregion


		#region << Public Properties >>

		/// <summary>
		/// �ʎ��t�@�C���z�u�p�X
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
		/// �N���[���I�u�W�F�N�g���쐬���܂��B
		/// </summary>
		/// <returns>�N���[���I�u�W�F�N�g�B</returns>
		public MulticastInfoEditorSetting Clone()
		{
			return new MulticastInfoEditorSetting( this._anothersheetFileDirPath );
		}

		#endregion


		#region << Public Static Methods >>

		/// <summary>
		/// .NS�z�M�ݒ��ʐݒ�N���X��ǂݍ��݂܂��B
		/// </summary>
		/// <param name="fileName">.NS�z�M�ݒ��ʐݒ�t�@�C����</param>
		/// <returns>.NS�z�M�ݒ��ʐݒ�N���X</returns>
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
		/// .NS�z�M�ݒ��ʐݒ�N���X��ۑ����܂��B
		/// </summary>
		/// <param name="fileName">.NS�z�M�ݒ��ʐݒ�t�@�C����</param>
		/// <param name="multicastInfoEditorSetting">.NS�z�M�ݒ��ʐݒ�N���X</param>
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
