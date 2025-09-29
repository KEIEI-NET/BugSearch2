using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Security.Cryptography;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Runtime.Serialization;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;

namespace Broadleaf.Library.Runtime.Serialization
{
	/// public class name:   OfflineDataSerializer
	/// <summary>
	///                      オフラインデータシリアライザ
	/// </summary>
	/// <remarks>
	/// <br>note             :   オフラインデータシリアライザを行います</br>
	/// <br>                 :   シリアライズ可能なオブジェクトの条件</br>
	/// <br>                 :   ①カスタムシリアライズが可能なオブジェクト</br>
	/// <br>                 :   ②①を複数格納しているArrayList</br>
	/// <br>                 :   ③①を複数格納しているCustomSerializeArrayList</br>
	/// <br>Programmer       :   久保田　信一</br>
	/// <br>Date             :   2005/10/24</br>
	/// <br>Update Note      :   2006/09/12 21027 須川　程志郎</br>
	/// <br>                 :   1.すべての提供メソッドにディレクトリ指定可能なオーバーロード作成</br>
	/// <br>                 :   2.オフライン用保存ディレクトリを定義アセンブリより取得</br>
	/// <br>Update Note      :   2006/09/12 21027 須川　程志郎</br>
	/// <br>                 :   1.ファイル保存を行わず、データのみSerialize/Deserializeするメソッドを追加</br>
    /// <br>Update Note      :   2008/05/09 18322 T.Kimura Vista対応</br>
    /// <br>                       "Program Files"フォルダ下に作成するファイルを"Document and Settings"フォルダ下に作成するように変更</br>
    /// <br>Update Note      :   2009.06.23 23011 noguchi ファイル読込時にも掴むのを修正</br>
    /// <br>Update Note      :   2017.07.10 30221 柴田 千春 J#→SharpZipLib</br>
	/// </remarks>
	public class OfflineDataSerializer
	{
		/// <summary>保存Directory</summary>
//		private string _saveDir = "Temp";		// 2006.09.12 Chg T.Sugawa
		private string _saveDir = Broadleaf.Application.Resources.ConstantManagement_ClientDirectory.Temp_OfflineDownload;
		/// <summary>保存拡張子</summary>
		private string _saveExt = ".tmp";
#if UAC
        /// <summary>クライアントディレクトリパス生成</summary>
        private Type _SFCMN00045C = null;

        /// <summary>ユーザー設定制御クラス</summary>
        private Type _SFCMN00501C = null;

        private const string CT_FILENAME_SFCMN00045C = "SFCMN00045C.DLL";
        private const string CT_FILENAME_SFCMN00501C = "SFCMN00501C.DLL";
#endif

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public OfflineDataSerializer()
		{
#if UAC
            // ↓ 20080509 18322 a "AssemblyDeployment(DeployPosition.Common)"なので、アセンブリがある時のみ
            //                     Vista対応の処理を行うようにする
            _SFCMN00045C = null;
            if (File.Exists(CT_FILENAME_SFCMN00045C))
            {
                FileInfo fileInfo = new FileInfo(CT_FILENAME_SFCMN00045C);
                Assembly assembly = Assembly.LoadFile(fileInfo.FullName);
                _SFCMN00045C = assembly.GetType("Broadleaf.Application.Common.ProductUsesPathGenerator");
            }
            _SFCMN00501C = null;
            if (File.Exists(CT_FILENAME_SFCMN00501C))
            {
                FileInfo fileInfo = new FileInfo(CT_FILENAME_SFCMN00501C);
                Assembly assembly = Assembly.LoadFile(fileInfo.FullName);
                _SFCMN00501C = assembly.GetType("Broadleaf.Application.Common.UserSettingController");
            }
#endif
		}

		#region public Method CustomSerializer Object Serialize関連
//-- 2007.05.15 Add Start by T.Sugawa ------------------------------------------------------------//
		/// <summary>
		/// シリアライズ
		/// </summary>
		/// <param name="classId">クラスID</param>
		/// <param name="keyList">キーList</param>
		/// <param name="data">シリアライズ対象データ</param>
		/// <param name="serializedData">シリアライズ結果データ</param>
		/// <returns>STATUS</returns>
		public int Serialize(string classId, string[] keyList, object data, out byte[] serializedData)
		{
			serializedData = null;

			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			if (data == null || (data is ArrayList && ((ArrayList)data).Count == 0)) return status;

			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			try
			{
				//保存データをカスタムシリアライズ化
				byte[] saveData = CustomSerializeSaveData(data);

				//Zip圧縮
				if (saveData != null) saveData = CompressionEntry("", saveData);

				if (saveData != null) serializedData = saveData;

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (Exception ex)
			{
				throw new Exception(string.Format("データのシリアライズに失敗しました。Exception={0}", ex.Message), ex);
			}

			return status;
		}
//-- 2007.05.15 Add End by T.Sugawa --------------------------------------------------------------//

		/// <summary>
		/// シリアライズ
		/// </summary>
		/// <param name="classId">クラスID</param>
		/// <param name="keyList">キーList</param>
		/// <param name="data">シリアライズ対象データ</param>
		/// <returns>STATUS</returns>
		public int Serialize(string classId, string[] keyList, object data)
		{
			return this.Serialize(classId, keyList, data, _saveDir);
		}

		/// <summary>
		/// シリアライズ
		/// </summary>
		/// <param name="classId">クラスID</param>
		/// <param name="keyList">キーList</param>
		/// <param name="data">シリアライズ対象データ</param>
		/// <param name="targetDir">処理対象ディレクトリ</param>
		/// <returns>STATUS</returns>
		public int Serialize(string classId, string[] keyList, object data, string targetDir)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			if (data == null || (data is ArrayList && ((ArrayList)data).Count == 0)) return status;

			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			try
			{
				//保存先のフォルダ位置を指定
				string saveFilePath = Path.Combine(Directory.GetCurrentDirectory(), targetDir);
#if UAC
                if (_SFCMN00045C != null)
                {
                    string retPath = (string)_SFCMN00045C.InvokeMember("GetFullPath",
                                                                       BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod,
                                                                       null,
                                                                       _SFCMN00045C,
                                                                       new object[] { saveFilePath });
                    if (retPath != "")
                    {
                        saveFilePath = retPath;
                    }
                }
#endif
				//保存ディレクトリが無ければ作成
				if (!Directory.Exists(saveFilePath)) Directory.CreateDirectory(saveFilePath);

				//保存用のファイルIDを生成
				string saveFileName = MakeFileName(classId, keyList);
				if (saveFileName != "")
				{
					//保存ファイルフルパスを取得
					string saveFullPath = Path.Combine(saveFilePath,saveFileName);
					//保存ファイルがあれば属性変更
					if (File.Exists(saveFullPath)) File.SetAttributes(saveFullPath,FileAttributes.Normal);

					//保存データをカスタムシリアライズ化
					byte[] saveData = CustomSerializeSaveData(data);

					//Zip圧縮
					if (saveData != null) saveData = CompressionEntry(saveFileName,saveData);

					//暗号化処理
					byte[] desKey = new byte[24];
					byte[] desIv  = new byte[8];
					if (saveData != null) saveData = EncryptionEntry(saveData,out desKey,out desIv);

					if (saveData != null)
					{
						//ファイル保存
						FileStream fs = null;
						try
						{
							//③ファイル書き込み
							fs = File.Create(saveFullPath);
							fs.Write(desKey,0,desKey.Length);
							fs.Write(desIv,0,desIv.Length);
							fs.Write(saveData,0,saveData.Length);
							fs.Close();
							fs = null;
							//④作成日時を調整
							if (File.Exists( saveFullPath ))	File.SetCreationTime(saveFullPath,DateTime.Now);
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						}
						catch(Exception ex)
						{
							if (fs != null) fs.Close();
							status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
							throw new Exception(string.Format("OfflineDataSerializer.Serialize [{0}]のファイル保存に失敗しました。Exception={1}",saveFullPath,ex.Message),ex);
						}
						finally
						{
							if (fs != null) fs.Close();
						}
#if UAC
                        // ↓ 20080509 18322 a 他のユーザーでもファイルにアクセスできるように権限を追加
                        if (_SFCMN00501C != null && File.Exists(saveFullPath))
                        {
                            try
                            {
                                _SFCMN00501C.InvokeMember("AddFileAccessControl",
                                                          BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod,
                                                          null,
                                                          _SFCMN00501C,
                                                          new object[] { saveFullPath });
                            }
                            catch (Exception)
                            {
                            }
                        }
#endif
					}
				}
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("オフラインデータの保存に失敗しました。Exception={0}",ex.Message),ex);
			}
			return status;
		}

//-- 2007.05.15 Add Start by T.Sugawa ------------------------------------------------------------//
		/// <summary>
		/// デシリアライズ
		/// </summary>
		/// <param name="classId">クラスID</param>
		/// <param name="keyList">キーList</param>
		/// <param name="deserializeData">デシリアライズ対象データ</param>
		/// <returns>デシリアライズ結果</returns>
		public object DeSerialize(string classId, string[] keyList, byte[] deserializeData)
		{
			object result = null;
			try
			{
				if (deserializeData != null && deserializeData.Length > 0)
				{
					//Zip解凍
					deserializeData = DeCompressionEntry(deserializeData);

					//カスタムシリアライザデシリアライズ
					if (deserializeData != null && deserializeData.Length > 0)
						result = CustomDeSerializeSaveData(deserializeData);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(string.Format("データのデシリアライズに失敗しました。Exception={0}", ex.Message), ex);
			}
			return result;
		}
//-- 2007.05.15 Add End by T.Sugawa --------------------------------------------------------------//

		/// <summary>
		/// デシリアライズ
		/// </summary>
		/// <param name="classId">クラスID</param>
		/// <param name="keyList">キーList</param>
		/// <returns>デシリアライズ結果</returns>
		public object DeSerialize(string classId, string[] keyList)
		{
			return this.DeSerialize(classId, keyList, _saveDir);
		}

		/// <summary>
		/// デシリアライズ
		/// </summary>
		/// <param name="classId">クラスID</param>
		/// <param name="keyList">キーList</param>
		/// <param name="targetDir">処理対象ディレクトリ</param>
		/// <returns>デシリアライズ結果</returns>
		public object DeSerialize(string classId, string[] keyList, string targetDir)
		{
			object result = null;
			try
			{
				//保存先のフォルダ位置を指定
				string saveFilePath = Path.Combine(Directory.GetCurrentDirectory(), targetDir);
#if UAC
                if (_SFCMN00045C != null)
                {
                    string retPath = (string)_SFCMN00045C.InvokeMember("GetFullPath",
                                                                       BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod,
                                                                       null,
                                                                       _SFCMN00045C,
                                                                       new object[] { saveFilePath });
                    if (retPath != "")
                    {
                        saveFilePath = retPath;
                    }
                }
#endif
				//保存ディレクトリが無ければ作成
				if (!Directory.Exists(saveFilePath)) Directory.CreateDirectory(saveFilePath);

				//保存用のファイルIDを生成
				string saveFileName = MakeFileName(classId, keyList);
				string saveFullPath = Path.Combine(saveFilePath,saveFileName);
				if (saveFileName != "" && File.Exists( saveFullPath ))
				{
					byte[] desKey;
					byte[] desIv;
					//ファイル情報取得
					byte[] saveData = FileReadProc(saveFilePath, saveFileName,out desKey,out desIv);
					if (saveData == null) return null;

					//複合化
					saveData = CompoundEntry(saveData,desKey,desIv);

					if (saveData != null && saveData.Length > 0)
					{
						//Zip解凍
						saveData = DeCompressionEntry(saveData);

						//カスタムシリアライザデシリアライズ
						if (saveData != null && saveData.Length > 0) result = CustomDeSerializeSaveData(saveData);
					}
				}
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("オフラインデータの取得に失敗しました。Exception={0}",ex.Message),ex);
			}
			return result;
		}
		#endregion

		#region public Method String[] Serialize関連
		/// <summary>
		/// シリアライズ
		/// </summary>
		/// <param name="classId">クラスID</param>
		/// <param name="keyList">キーList</param>
		/// <param name="data">シリアライズ対象データ</param>
		/// <returns>STATUS</returns>
		public int SerializeString(string classId, string[] keyList, string[] data)
		{
			return this.SerializeString(classId, keyList, data, _saveDir);
		}

		/// <summary>
		/// シリアライズ
		/// </summary>
		/// <param name="classId">クラスID</param>
		/// <param name="keyList">キーList</param>
		/// <param name="data">シリアライズ対象データ</param>
		/// <param name="targetDir">処理対象ディレクトリ</param>
		/// <returns>STATUS</returns>
		public int SerializeString(string classId, string[] keyList, string[] data, string targetDir)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			if (data == null || data.Length == 0) return status;

			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			try
			{
				//保存先のフォルダ位置を指定(Tempフォルダに生成)
				string saveFilePath = Path.Combine(Directory.GetCurrentDirectory(), targetDir);
#if UAC
                if (_SFCMN00045C != null)
                {
                    string retPath = (string)_SFCMN00045C.InvokeMember("GetFullPath",
                                                                       BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod,
                                                                       null,
                                                                       _SFCMN00045C,
                                                                       new object[] { saveFilePath });
                    if (retPath != "")
                    {
                        saveFilePath = retPath;
                    }
                }
#endif
				//保存ディレクトリが無ければ作成
				if (!Directory.Exists(saveFilePath)) Directory.CreateDirectory(saveFilePath);

				//保存用のファイルIDを生成
				string saveFileName = MakeFileName(classId, keyList);
				if (saveFileName != "")
				{
					//保存ファイルフルパスを取得
					string saveFullPath = Path.Combine(saveFilePath,saveFileName);
					//保存ファイルがあれば属性変更
					if (File.Exists(saveFullPath)) File.SetAttributes(saveFullPath,FileAttributes.Normal);

					//保存データをシリアライズ化(string[]⇒byte[])
					byte[] saveData = SerializeStringSaveData(data);

					//Zip圧縮
					if (saveData != null) saveData = CompressionEntry(saveFileName,saveData);

					//暗号化処理
					byte[] desKey = new byte[24];
					byte[] desIv  = new byte[8];
					if (saveData != null) saveData = EncryptionEntry(saveData,out desKey,out desIv);

					if (saveData != null)
					{
						//ファイル保存
						FileStream fs = null;
						try
						{
							//③ファイル書き込み
							fs = File.Create(saveFullPath);
							fs.Write(desKey,0,desKey.Length);
							fs.Write(desIv,0,desIv.Length);
							fs.Write(saveData,0,saveData.Length);
							fs.Close();
							fs = null;
							//④作成日時を調整
							if (File.Exists( saveFullPath ))	File.SetCreationTime(saveFullPath,DateTime.Now);
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						}
						catch(Exception ex)
						{
							if (fs != null) fs.Close();
							status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
							throw new Exception(string.Format("OfflineDataSerializer.SerializeString [{0}]のファイル保存に失敗しました。Exception=",saveFullPath,ex.Message),ex);
						}
						finally
						{
							if (fs != null) fs.Close();
						}
#if UAC
                        if (_SFCMN00501C != null && File.Exists(saveFullPath))
                        {
                            try
                            {
                                _SFCMN00501C.InvokeMember("AddFileAccessControl",
                                                          BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod,
                                                          null,
                                                          _SFCMN00501C,
                                                          new object[] { saveFullPath });
                            }
                            catch (Exception)
                            {
                            }
                        }
#endif
					}
				}
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("オフラインデータの保存に失敗しました。Exception={0}",ex.Message),ex);
			}
			return status;
		}

		/// <summary>
		/// デシリアライズ
		/// </summary>
		/// <param name="classId">クラスID</param>
		/// <param name="keyList">キーList</param>
		/// <returns>デシリアライズ結果</returns>
		public string[] DeSerializeString(string classId, string[] keyList)
		{
			return this.DeSerializeString(classId, keyList, _saveDir);
		}

		/// <summary>
		/// デシリアライズ
		/// </summary>
		/// <param name="classId">クラスID</param>
		/// <param name="keyList">キーList</param>
		/// <param name="targetDir">処理対象ディレクトリ</param>
		/// <returns>デシリアライズ結果</returns>
		public string[] DeSerializeString(string classId, string[] keyList, string targetDir)
		{
			string[] result = null;
			try
			{
				//保存先のフォルダ位置を指定(Tempフォルダに生成)
				string saveFilePath = Path.Combine(Directory.GetCurrentDirectory(), targetDir);
#if UAC
                if (_SFCMN00045C != null)
                {
                    string retPath = (string)_SFCMN00045C.InvokeMember("GetFullPath",
                                                                       BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod,
                                                                       null,
                                                                       _SFCMN00045C,
                                                                       new object[] { saveFilePath });
                    if (retPath != "")
                    {
                        saveFilePath = retPath;
                    }
                }
#endif
				//保存ディレクトリが無ければ作成
				if (!Directory.Exists(saveFilePath)) Directory.CreateDirectory(saveFilePath);

				//保存用のファイルIDを生成
				string saveFileName = MakeFileName(classId, keyList);
				string saveFullPath = Path.Combine(saveFilePath,saveFileName);
				if (saveFileName != "" && File.Exists( saveFullPath ))
				{
					byte[] desKey;
					byte[] desIv;
					//ファイル情報取得
					byte[] saveData = FileReadProc(saveFilePath, saveFileName,out desKey,out desIv);
					if (saveData == null) return null;

					//複合化
					saveData = CompoundEntry(saveData,desKey,desIv);

					if (saveData != null && saveData.Length > 0)
					{
						//Zip解凍
						saveData = DeCompressionEntry(saveData);

						//デシリアライズ
						if (saveData != null && saveData.Length > 0) result = DeSerializeStringSaveData(saveData);
					}
				}
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("オフラインデータの取得に失敗しました。Exception={0}",ex.Message),ex);
			}
			return result;
		}
		#endregion

		#region public Method byte[] Serialize 関連
		/// <summary>
		/// シリアライズ
		/// </summary>
		/// <param name="classId">クラスID</param>
		/// <param name="keyList">キーList</param>
		/// <param name="data">シリアライズ対象データ</param>
		/// <returns>STATUS</returns>
		public int SerializeByte(string classId, string[] keyList, byte[] data)
		{
			return this.SerializeByte(classId, keyList, data, _saveDir);
		}

		/// <summary>
		/// シリアライズ
		/// </summary>
		/// <param name="classId">クラスID</param>
		/// <param name="keyList">キーList</param>
		/// <param name="data">シリアライズ対象データ</param>
		/// <param name="targetDir">処理対象ディレクトリ</param>
		/// <returns>STATUS</returns>
		public int SerializeByte(string classId, string[] keyList, byte[] data, string targetDir)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			if (data == null || data.Length == 0) return status;

			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			try
			{
				//保存先のフォルダ位置を指定(Tempフォルダに生成)
				string saveFilePath = Path.Combine(Directory.GetCurrentDirectory(), targetDir);
#if UAC
                if (_SFCMN00045C != null)
                {
                    string retPath = (string)_SFCMN00045C.InvokeMember("GetFullPath",
                                                                       BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod,
                                                                       null,
                                                                       _SFCMN00045C,
                                                                       new object[] { saveFilePath });
                    if (retPath != "")
                    {
                        saveFilePath = retPath;
                    }
                }
#endif
				//保存ディレクトリが無ければ作成
				if (!Directory.Exists(saveFilePath)) Directory.CreateDirectory(saveFilePath);

				//保存用のファイルIDを生成
				string saveFileName = MakeFileName(classId, keyList);
				if (saveFileName != "")
				{
					//保存ファイルフルパスを取得
					string saveFullPath = Path.Combine(saveFilePath,saveFileName);
					//保存ファイルがあれば属性変更
					if (File.Exists(saveFullPath)) File.SetAttributes(saveFullPath,FileAttributes.Normal);

					//Zip圧縮
					if (data != null) data = CompressionEntry(saveFileName,data);

					//暗号化処理
					byte[] desKey = new byte[24];
					byte[] desIv  = new byte[8];
					if (data != null) data = EncryptionEntry(data,out desKey,out desIv);

					if (data != null)
					{
						//ファイル保存
						FileStream fs = null;
						try
						{
							//③ファイル書き込み
							fs = File.Create(saveFullPath);
							fs.Write(desKey,0,desKey.Length);
							fs.Write(desIv,0,desIv.Length);
							fs.Write(data,0,data.Length);
							fs.Close();
							fs = null;
							//④作成日時を調整
							if (File.Exists( saveFullPath ))	File.SetCreationTime(saveFullPath,DateTime.Now);
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						}
						catch(Exception ex)
						{
							if (fs != null) fs.Close();
							status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
							throw new Exception(string.Format("OfflineDataSerializer.SerializeByte [{0}]のファイル保存に失敗しました。Exception=",saveFullPath,ex.Message),ex);
						}
						finally
						{
							if (fs != null) fs.Close();
						}
#if UAC
                        // ↓ 20080509 18322 a 他のユーザーでもファイルにアクセスできるように権限を追加
                        if (_SFCMN00501C != null && File.Exists(saveFullPath))
                        {
                            try
                            {
                                _SFCMN00501C.InvokeMember("AddFileAccessControl",
                                                          BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod,
                                                          null,
                                                          _SFCMN00501C,
                                                          new object[] { saveFullPath });
                            }
                            catch (Exception)
                            {
                            }
                        }
#endif
					}
				}
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("オフラインデータの保存に失敗しました。Exception={0}",ex.Message),ex);
			}
			return status;
		}

		/// <summary>
		/// デシリアライズ
		/// </summary>
		/// <param name="classId">クラスID</param>
		/// <param name="keyList">キーList</param>
		/// <returns>デシリアライズ結果</returns>
		public byte[] DeSerializeByte(string classId, string[] keyList)
		{
			return this.DeSerializeByte(classId, keyList, _saveDir);
		}

		/// <summary>
		/// デシリアライズ
		/// </summary>
		/// <param name="classId">クラスID</param>
		/// <param name="keyList">キーList</param>
		/// <param name="targetDir">処理対象ディレクトリ</param>
		/// <returns>デシリアライズ結果</returns>
		public byte[] DeSerializeByte(string classId, string[] keyList, string targetDir)
		{
			byte[] result = null;
			try
			{
				//保存先のフォルダ位置を指定(Tempフォルダに生成)
				string saveFilePath = Path.Combine(Directory.GetCurrentDirectory(), targetDir);
#if UAC
                if (_SFCMN00045C != null)
                {
                    string retPath = (string)_SFCMN00045C.InvokeMember("GetFullPath",
                                                                       BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod,
                                                                       null,
                                                                       _SFCMN00045C,
                                                                       new object[] { saveFilePath });
                    if (retPath != "")
                    {
                        saveFilePath = retPath;
                    }
                }
#endif
				//保存ディレクトリが無ければ作成
				if (!Directory.Exists(saveFilePath)) Directory.CreateDirectory(saveFilePath);

				//保存用のファイルIDを生成
				string saveFileName = MakeFileName(classId, keyList);
				string saveFullPath = Path.Combine(saveFilePath,saveFileName);
				if (saveFileName != "" && File.Exists( saveFullPath ))
				{
					byte[] desKey;
					byte[] desIv;
					//ファイル情報取得
					byte[] saveData = FileReadProc(saveFilePath, saveFileName,out desKey,out desIv);
					if (saveData == null) return null;

					//複合化
					saveData = CompoundEntry(saveData,desKey,desIv);

					if (saveData != null && saveData.Length > 0)
					{
						//Zip解凍
						result = DeCompressionEntry(saveData);
					}
				}
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("オフラインデータの取得に失敗しました。Exception={0}",ex.Message),ex);
			}
			return result;
		}
		#endregion 

		#region public Method 共通メソッド
		/// <summary>
		/// シリアライズファイル削除
		/// </summary>
		/// <param name="classId">クラス名</param>
		/// <param name="keyList">KEYリスト</param>
		/// <returns>STATUS</returns>
		public int Delete(string classId, string[] keyList)
		{
			return Delete(classId, keyList, _saveDir);
		}

		/// <summary>
		/// シリアライズファイル削除
		/// </summary>
		/// <param name="classId">クラス名</param>
		/// <param name="keyList">KEYリスト</param>
		/// <param name="targetDir">処理対象ディレクトリ</param>
		/// <returns>STATUS</returns>
		public int Delete(string classId, string[] keyList, string targetDir)
		{
			int result = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			try
			{
				//保存先のフォルダ位置を指定(Tempフォルダに生成)
				string saveFilePath = Path.Combine(Directory.GetCurrentDirectory(), targetDir);
#if UAC
                if (_SFCMN00045C != null)
                {
                    string retPath = (string)_SFCMN00045C.InvokeMember("GetFullPath",
                                                                       BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod,
                                                                       null,
                                                                       _SFCMN00045C,
                                                                       new object[] { saveFilePath });
                    if (retPath != "")
                    {
                        saveFilePath = retPath;
                    }
                }
#endif
				//保存ディレクトリが無ければ削除データ無し
				if (Directory.Exists(saveFilePath))
				{
					//保存用のファイルIDを生成
					string saveFileName = MakeFileName(classId, keyList);
					string saveFullPath = Path.Combine(saveFilePath,saveFileName);
					if (saveFileName != "" && File.Exists( saveFullPath ))
					{
						//保存ファイルがあれば属性変更
						File.SetAttributes(saveFullPath,FileAttributes.Normal);
						//ファイル削除
						File.Delete(saveFullPath);
						//戻り値を設定
						result = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("オフラインデータの削除に失敗しました。Exception={0}",ex.Message),ex);
			}
			return result;
		}

		/// <summary>
		/// シリアライズファイル存在チェック
		/// </summary>
		/// <param name="classId">クラス名</param>
		/// <param name="keyList">KEYリスト</param>
		/// <returns>T:有り F:無し</returns>
		public bool Exists(string classId, string[] keyList)
		{
			return this.Exists(classId, keyList, _saveDir);
		}

		/// <summary>
		/// シリアライズファイル存在チェック
		/// </summary>
		/// <param name="classId">クラス名</param>
		/// <param name="keyList">KEYリスト</param>
		/// <param name="targetDir">処理対象ディレクトリ</param>
		/// <returns>T:有り F:無し</returns>
		public bool Exists(string classId, string[] keyList, string targetDir)
		{
			bool result = false;

			try
			{
				//保存先のフォルダ位置を指定(Tempフォルダに生成)
				string saveFilePath = Path.Combine(Directory.GetCurrentDirectory(), targetDir);
#if UAC
                if (_SFCMN00045C != null)
                {
                    string retPath = (string)_SFCMN00045C.InvokeMember("GetFullPath",
                                                                       BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod,
                                                                       null,
                                                                       _SFCMN00045C,
                                                                       new object[] { saveFilePath });
                    if (retPath != "")
                    {
                        saveFilePath = retPath;
                    }
                }
#endif
				//保存ディレクトリが無ければデータ無し
				if (Directory.Exists(saveFilePath))
				{
					//保存用のファイルIDを生成
					string saveFileName = MakeFileName(classId, keyList);
					string saveFullPath = Path.Combine(saveFilePath,saveFileName);
					//保存ファイルがあればTrueを戻す
					if (saveFileName != "" && File.Exists( saveFullPath )) result = true;
				}
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("オフラインデータの存在チェックに失敗しました。Exception={0}",ex.Message),ex);
			}
			return result;
		}
		#endregion

		#region private Method Customer Serialize 関連
		/// <summary>
		/// カスタムシリアライザ　シリアライズ
		/// </summary>
		/// <param name="input">対象データ</param>
		/// <returns>カスタムシリアライズ結果</returns>
		private byte[] CustomSerializeSaveData(object input)
		{
			byte[] ret = null;
			MemoryStream ms = null;
			System.IO.BinaryWriter writer = null;
			try
			{
				//バイナリライタ生成
				ms = new MemoryStream();
				writer = new BinaryWriter(ms);

				//サロゲートターゲット取得
				string SurrogateTarget = MakeSurrogateName(input);
				//フォーマッタ取得
				ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( SurrogateTarget );
				//サロゲートターゲット名称書き込み
				writer.Write( SurrogateTarget );
				//サロゲートオブジェクト書き込み
				formatter.Serialize( writer , input );

				//戻り値へバイト情報を戻す
				ret = ms.ToArray();
				writer.Close();
				ms.Close();
			}
			catch(Exception ex)
			{
				if (writer != null) writer.Close();
				if (ms != null) ms.Close();
				throw new Exception(string.Format("OfflineDataSerializer.CustomSerializeSaveData 構成ファイルの記述に誤りがあります。[{0}]",ex.Message),ex);
			}

			return ret;
		}

		/// <summary>
		/// カスタムシリアライザ　デシリアライズ
		/// </summary>
		/// <param name="data">デシリアライズ対象データ</param>
		/// <returns>デシリアライズ結果</returns>
		private object CustomDeSerializeSaveData(byte[] data)
		{
			object result = null;
			MemoryStream ms = null;
			System.IO.BinaryReader reader = null;
			try
			{
				ms = new MemoryStream(data);
				reader = new BinaryReader(ms);
				//サロゲート名称取得
				string SurrogateTarget = reader.ReadString();
				ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( SurrogateTarget );
				result = formatter.Deserialize( reader );
			}
			catch(Exception ex)
			{
				if (reader != null) reader.Close();
				if (ms != null) ms.Close();
				throw new Exception(string.Format("OfflineDataSerializer.CustomSerializeSaveData 構成ファイルの記述に誤りがあります。[{0}]",ex.Message),ex);
			}
			finally
			{
				if (reader != null) reader.Close();
				if (ms != null) ms.Close();
			}

			return result;
		}

		/// <summary>
		/// Binaryシリアライザ書き込み処理
		/// </summary>
		/// <param name="writer">シリアライザ</param>
		/// <param name="input">書き込み対象オブジェクト</param>
		private void WriteClassInfo(System.IO.BinaryWriter writer, object input)
		{
			string SurrogateTarget = MakeSurrogateName(input);
			ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( SurrogateTarget );
			//サロゲートターゲット名称書き込み
			writer.Write( SurrogateTarget );
			//サロゲートオブジェクト書き込み
			formatter.Serialize( writer , input );
		}

		/// <summary>
		/// サロゲートターゲット名称作成
		/// </summary>
		/// <param name="input">シリアライズ対象オブジェクト</param>
		/// <returns>サロゲートターゲット名称</returns>
		private string MakeSurrogateName(object input)
		{
			Type type;
			if (input is CustomSerializeArrayList)
				type = input.GetType();
			else if (input is ArrayList)
				type = ((ArrayList)input)[0].GetType();
			else
				type = input.GetType();
			
			return type.FullName + ", " + type.Assembly.FullName.Split(',')[0];
		}
		#endregion

		#region private Method string[] 関連
		/// <summary>
		/// Stringシリアライザ
		/// </summary>
		/// <param name="input">シリアライズ対象文字列</param>
		/// <returns>シリアライズ結果</returns>
		private byte[] SerializeStringSaveData(string[] input)
		{
			byte[] ret = null;
			MemoryStream ms = null;
			System.IO.BinaryWriter writer = null;
			try
			{
				//バイナリライタ生成
				ms = new MemoryStream();
				writer = new BinaryWriter(ms);
				writer.Write( (Int32)input.Length );
				foreach(string str in input)
				{
					writer.Write( (string)str );
				}
				//戻り値へバイト情報を戻す
				ret = ms.ToArray();
				writer.Close();
				ms.Close();
			}
			catch(Exception ex)
			{
				if (writer != null) writer.Close();
				if (ms != null) ms.Close();
				throw new Exception(string.Format("OfflineDataSerializer.SerializeStringSaveData 文字配列のシリアライズに失敗。[{0}]",ex.Message),ex);
			}

			return ret;
		}

		/// <summary>
		/// Stringデシリアライザ
		/// </summary>
		/// <param name="data">デシリアライズ対象Binary</param>
		/// <returns>デシリアライズ結果</returns>
		private string[] DeSerializeStringSaveData(byte[] data)
		{
			string[] result = null;
			MemoryStream ms = null;
			System.IO.BinaryReader reader = null;
			try
			{
				ms = new MemoryStream(data);
				reader = new BinaryReader(ms);
				//文字列格納数取得
				Int32 strLen = reader.ReadInt32();
				if (strLen > 0)
				{
					result = new string[strLen];
					for(int i=0;i<strLen;i++) result[i] = reader.ReadString();
				}
			}
			catch(Exception ex)
			{
				if (reader != null) reader.Close();
				if (ms != null) ms.Close();
				throw new Exception(string.Format("OfflineDataSerializer.DeSerializeStringSaveData 文字配列のデシリアライズに失敗。[{0}]",ex.Message),ex);
			}
			finally
			{
				if (reader != null) reader.Close();
				if (ms != null) ms.Close();
			}

			return result;
		}
		#endregion

		#region private Method 共通メソッド
		/// <summary>
		/// ファイル名称生成
		/// </summary>
		/// <param name="classId">クラスID</param>
		/// <param name="keyList">Keyリスト</param>
		/// <returns>ファイル名称</returns>
		private string MakeFileName(string classId, string[] keyList)
		{
			//戻り値初期化
			string result = "";

			try
			{
				//●ファイル名生成
				StringBuilder sb = new StringBuilder(256);
				//クラスID付与
				sb.Append(classId);
				//KEY情報設定
				foreach(string key in keyList) sb.Append(key);

				//●文字列ファイル名を生成
				string tempFileName = sb.ToString();

				//●文字列ファイル名をハッシュ化
				byte[] byteFileName = Encoding.Unicode.GetBytes(tempFileName);
				// This is one implementation of the abstract class MD5.
				MD5 md5 = new MD5CryptoServiceProvider();
				byte[] byteResult = md5.ComputeHash(byteFileName);
				tempFileName =  BitConverter.ToString(byteResult).Replace("-","");
		
				//●拡張子を最後に付ける
				result = tempFileName + _saveExt;
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("オフラインファイル名称の生成に失敗しました。Exception={0}",ex.Message),ex);
			}

			return result;
		}

		/// <summary>
		/// ZIP圧縮
		/// </summary>
		/// <param name="fileName">ファイル名称</param>
		/// <param name="data">書き込みデータ</param>
		/// <returns>ZIP圧縮結果</returns>
		private byte[] CompressionEntry(string fileName, byte[] data)
		{
			byte[] result = null;
			MemoryStream fos = null;
			ZipOutputStream zos =	null;			
			ZipEntry ze = null;
			MemoryStream ms = null;
			System.IO.BinaryReader reader = null;
			try
			{
				fos = new MemoryStream();
				zos = new ZipOutputStream(fos);

				//ZIPに追加するときのファイル名をSETする
				ze = new ZipEntry(fileName);
				ze.CompressionMethod = CompressionMethod.Deflated;
				zos.PutNextEntry(ze);

				ms = new MemoryStream(data);
				reader = new BinaryReader(ms);
			
				//書き込み
				int len = 0;
				while(len < data.Length)
				{
					byte[] work = reader.ReadBytes(8192);
					if (work == null || work.Length == 0) break;
					zos.Write(work, 0, work.Length);
					len += work.Length;
				}
				reader.Close();
				ms.Close();
				
				zos.CloseEntry();
				zos.Close();

				//ZIP形式のバイト配列を取得
				result = fos.ToArray();
				fos.Close();
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("OfflineDataSerializer.ZipEntry 圧縮処理に失敗しました。[{0}]",ex.Message),ex);
			}
			finally
			{
				//閉じる
				if (reader != null) reader.Close();
				if (ms != null) ms.Close();
			}
			return result;
		}

		/// <summary>
		/// Zip解凍
		/// </summary>
		/// <returns>Zip解凍結果</returns>
		private byte[] DeCompressionEntry(byte[] data)
		{
			byte[] result = null;
			MemoryStream fis = null;
			ZipInputStream zis = null;

			try
			{
				//読み込む
				fis = new MemoryStream(data);
				zis = new ZipInputStream(fis);
			
				//ZIP内のファイル情報を取得
				ZipEntry ze;
				while ((ze = zis.GetNextEntry()) != null)
				{
					if(!ze.IsDirectory)
					{
						MemoryStream ms = new MemoryStream();
						//書込み
						byte[] work = new byte[8192];
						int len;
						while ((len = zis.Read(work, 0, work.Length)) > 0)
						{
							ms.Write(work,0,len);
						}
						result = ms.ToArray();
						ms.Close();
						break;
					}
				}	
			}
			finally
			{
				//閉じる
				if (zis != null) zis.Close();
				if (fis != null) fis.Close();
			}
			return result;
		}

		/// <summary>
		/// データ暗号化
		/// </summary>
		/// <param name="source">暗号化対象データ</param>
		/// <param name="desKey">キー</param>
		/// <param name="desIv">規定値</param>
		private byte[] EncryptionEntry(byte[] source,out byte[] desKey,out byte[] desIv)
		{
			byte[] result = null;
			MemoryStream mem = null;
			CryptoStream cs = null;
			desKey = null;
			desIv = null;
			try
			{

				// Trippe DES のサービス プロバイダを生成します
				TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();

				provider.GenerateKey();
				provider.GenerateIV();

				desKey = provider.Key;
				desIv = provider.IV;

				// 入出力用のストリームを生成します
				mem = new MemoryStream();
				cs = new CryptoStream(mem, provider.CreateEncryptor( desKey, desIv), CryptoStreamMode.Write);

				// ストリームに暗号化されたデータを書き込みます
				cs.Write(source, 0, source.Length);
				cs.Close();

				// 暗号化されたデータを byte 配列で戻します
				result = mem.ToArray();				
				mem.Close();		
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("OfflineDataSerializer.EncryptionEntry 暗号化処理に失敗しました。[{0}]",ex.Message),ex);
			}
			finally
			{
				if (cs != null) cs.Close();
				if (mem != null ) mem.Close();				
			}
			return result;
		}

		/// <summary>
		/// 複合化処理
		/// </summary>
		/// <param name="data">複合化対象データ</param>
		/// <param name="desKey">暗号化KEY</param>
		/// <param name="desIv">暗号化KEY</param>
		/// <returns>複合結果</returns>
		private byte[] CompoundEntry(byte[] data,byte[] desKey,byte[] desIv)
		{
			byte[] result = null;
			MemoryStream ms = null;
			CryptoStream cs = null;
			try
			{
				// Trippe DES のサービス プロバイダを生成します
				TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();

				// 入出力用のストリームを生成します
				ms = new MemoryStream();
				cs = new CryptoStream(ms, des.CreateDecryptor( desKey, desIv ), CryptoStreamMode.Write);

				// ストリームに暗号化されたデータを書き込みます
				cs.Write(data, 0, data.Length);
				cs.Close();

				// 復号化されたデータを byte 配列で取得します
				result = ms.ToArray();
				ms.Close();
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("OfflineDataSerializer.CompoundEntry 複合化エラー Exception=",ex.Message),ex);
			}
			finally
			{
				if (cs != null) cs.Close();
				if (ms != null) ms.Close();
			}

			return result;
		}

		/// <summary>
		/// ファイル読込処理
		/// </summary>
		/// <param name="filePath">保存ファイルパス</param>
		/// <param name="fileName">保存ファイル名称</param>
		/// <param name="desKey">暗号化キー</param>
		/// <param name="desIv">暗号化キー</param>
		/// <returns>読込結果</returns>
		private byte[] FileReadProc(string filePath, string fileName,out byte[] desKey,out byte[] desIv)
		{
			desKey	= null;
			desIv	= null;
			byte[] result = null;

			//保存用ディレクトリが無い場合は終了
			if (!Directory.Exists(filePath)) return result;

			//フルパス取得
			string fileFullPath = Path.Combine(filePath, fileName);

			//①画像情報が存在しない場合終了
			if (!File.Exists( fileFullPath )) return result;

			FileStream fs = null;
			BinaryReader br = null;
			try
			{
				TripleDESCryptoServiceProvider tds = new TripleDESCryptoServiceProvider();

                //2009.06.23 23011 noguchi del 旧オフラインデータロード時にファイルを掴んでますエラーがでるので修正 >>
                //fs = new FileStream( fileFullPath , FileMode.Open );
                ////①ファイル読み込み
                //br = new BinaryReader(fs);
                //desKey	= br.ReadBytes((int)tds.Key.Length);
                //desIv	= br.ReadBytes((int)tds.IV.Length);
                //result = br.ReadBytes((int)(fs.Length - (tds.Key.Length + tds.IV.Length)));
                //br.Close();
                //br = null;
                //fs.Close();
                //fs = null;
                //>> 2009.06.23 23011 noguchi del

                //2009.06.23 23011 noguchi add ファイルを掴まないで開くように修正 >>
                using(fs = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                //①ファイル読み込み
                using (br = new BinaryReader(fs))
                {
                    desKey = br.ReadBytes((int)tds.Key.Length);
                    desIv = br.ReadBytes((int)tds.IV.Length);
                    result = br.ReadBytes((int)(fs.Length - (tds.Key.Length + tds.IV.Length)));
                }
                //>> 2009.06.23 23011 noguchi add
            }
			catch(Exception ex)
			{
                //2009.06.23 23011 noguchi del
                //if (br != null) br.Close();
                //if (fs != null) fs.Close();
				throw new Exception(string.Format("オフラインデータの読込に失敗しました。Exception={0}",ex.Message),ex);
			}
            //2009.06.23 23011 noguchi del
            //finally
            //{
            //    if (br != null) br.Close();
            //    if (fs != null) fs.Close();
            //}
			return result;
		}
		#endregion
	}
}
