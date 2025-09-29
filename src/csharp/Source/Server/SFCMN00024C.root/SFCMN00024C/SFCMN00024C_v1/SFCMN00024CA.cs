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
	///                      �I�t���C���f�[�^�V���A���C�U
	/// </summary>
	/// <remarks>
	/// <br>note             :   �I�t���C���f�[�^�V���A���C�U���s���܂�</br>
	/// <br>                 :   �V���A���C�Y�\�ȃI�u�W�F�N�g�̏���</br>
	/// <br>                 :   �@�J�X�^���V���A���C�Y���\�ȃI�u�W�F�N�g</br>
	/// <br>                 :   �A�@�𕡐��i�[���Ă���ArrayList</br>
	/// <br>                 :   �B�@�𕡐��i�[���Ă���CustomSerializeArrayList</br>
	/// <br>Programmer       :   �v�ۓc�@�M��</br>
	/// <br>Date             :   2005/10/24</br>
	/// <br>Update Note      :   2006/09/12 21027 �{��@���u�Y</br>
	/// <br>                 :   1.���ׂĂ̒񋟃��\�b�h�Ƀf�B���N�g���w��\�ȃI�[�o�[���[�h�쐬</br>
	/// <br>                 :   2.�I�t���C���p�ۑ��f�B���N�g�����`�A�Z���u�����擾</br>
	/// <br>Update Note      :   2006/09/12 21027 �{��@���u�Y</br>
	/// <br>                 :   1.�t�@�C���ۑ����s�킸�A�f�[�^�̂�Serialize/Deserialize���郁�\�b�h��ǉ�</br>
    /// <br>Update Note      :   2008/05/09 18322 T.Kimura Vista�Ή�</br>
    /// <br>                       "Program Files"�t�H���_���ɍ쐬����t�@�C����"Document and Settings"�t�H���_���ɍ쐬����悤�ɕύX</br>
    /// <br>Update Note      :   2009.06.23 23011 noguchi �t�@�C���Ǎ����ɂ��͂ނ̂��C��</br>
    /// <br>Update Note      :   2017.07.10 30221 �ēc ��t J#��SharpZipLib</br>
	/// </remarks>
	public class OfflineDataSerializer
	{
		/// <summary>�ۑ�Directory</summary>
//		private string _saveDir = "Temp";		// 2006.09.12 Chg T.Sugawa
		private string _saveDir = Broadleaf.Application.Resources.ConstantManagement_ClientDirectory.Temp_OfflineDownload;
		/// <summary>�ۑ��g���q</summary>
		private string _saveExt = ".tmp";
#if UAC
        /// <summary>�N���C�A���g�f�B���N�g���p�X����</summary>
        private Type _SFCMN00045C = null;

        /// <summary>���[�U�[�ݒ萧��N���X</summary>
        private Type _SFCMN00501C = null;

        private const string CT_FILENAME_SFCMN00045C = "SFCMN00045C.DLL";
        private const string CT_FILENAME_SFCMN00501C = "SFCMN00501C.DLL";
#endif

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public OfflineDataSerializer()
		{
#if UAC
            // �� 20080509 18322 a "AssemblyDeployment(DeployPosition.Common)"�Ȃ̂ŁA�A�Z���u�������鎞�̂�
            //                     Vista�Ή��̏������s���悤�ɂ���
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

		#region public Method CustomSerializer Object Serialize�֘A
//-- 2007.05.15 Add Start by T.Sugawa ------------------------------------------------------------//
		/// <summary>
		/// �V���A���C�Y
		/// </summary>
		/// <param name="classId">�N���XID</param>
		/// <param name="keyList">�L�[List</param>
		/// <param name="data">�V���A���C�Y�Ώۃf�[�^</param>
		/// <param name="serializedData">�V���A���C�Y���ʃf�[�^</param>
		/// <returns>STATUS</returns>
		public int Serialize(string classId, string[] keyList, object data, out byte[] serializedData)
		{
			serializedData = null;

			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			if (data == null || (data is ArrayList && ((ArrayList)data).Count == 0)) return status;

			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			try
			{
				//�ۑ��f�[�^���J�X�^���V���A���C�Y��
				byte[] saveData = CustomSerializeSaveData(data);

				//Zip���k
				if (saveData != null) saveData = CompressionEntry("", saveData);

				if (saveData != null) serializedData = saveData;

				status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
			}
			catch (Exception ex)
			{
				throw new Exception(string.Format("�f�[�^�̃V���A���C�Y�Ɏ��s���܂����BException={0}", ex.Message), ex);
			}

			return status;
		}
//-- 2007.05.15 Add End by T.Sugawa --------------------------------------------------------------//

		/// <summary>
		/// �V���A���C�Y
		/// </summary>
		/// <param name="classId">�N���XID</param>
		/// <param name="keyList">�L�[List</param>
		/// <param name="data">�V���A���C�Y�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		public int Serialize(string classId, string[] keyList, object data)
		{
			return this.Serialize(classId, keyList, data, _saveDir);
		}

		/// <summary>
		/// �V���A���C�Y
		/// </summary>
		/// <param name="classId">�N���XID</param>
		/// <param name="keyList">�L�[List</param>
		/// <param name="data">�V���A���C�Y�Ώۃf�[�^</param>
		/// <param name="targetDir">�����Ώۃf�B���N�g��</param>
		/// <returns>STATUS</returns>
		public int Serialize(string classId, string[] keyList, object data, string targetDir)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			if (data == null || (data is ArrayList && ((ArrayList)data).Count == 0)) return status;

			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			try
			{
				//�ۑ���̃t�H���_�ʒu���w��
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
				//�ۑ��f�B���N�g����������΍쐬
				if (!Directory.Exists(saveFilePath)) Directory.CreateDirectory(saveFilePath);

				//�ۑ��p�̃t�@�C��ID�𐶐�
				string saveFileName = MakeFileName(classId, keyList);
				if (saveFileName != "")
				{
					//�ۑ��t�@�C���t���p�X���擾
					string saveFullPath = Path.Combine(saveFilePath,saveFileName);
					//�ۑ��t�@�C��������Α����ύX
					if (File.Exists(saveFullPath)) File.SetAttributes(saveFullPath,FileAttributes.Normal);

					//�ۑ��f�[�^���J�X�^���V���A���C�Y��
					byte[] saveData = CustomSerializeSaveData(data);

					//Zip���k
					if (saveData != null) saveData = CompressionEntry(saveFileName,saveData);

					//�Í�������
					byte[] desKey = new byte[24];
					byte[] desIv  = new byte[8];
					if (saveData != null) saveData = EncryptionEntry(saveData,out desKey,out desIv);

					if (saveData != null)
					{
						//�t�@�C���ۑ�
						FileStream fs = null;
						try
						{
							//�B�t�@�C����������
							fs = File.Create(saveFullPath);
							fs.Write(desKey,0,desKey.Length);
							fs.Write(desIv,0,desIv.Length);
							fs.Write(saveData,0,saveData.Length);
							fs.Close();
							fs = null;
							//�C�쐬�����𒲐�
							if (File.Exists( saveFullPath ))	File.SetCreationTime(saveFullPath,DateTime.Now);
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						}
						catch(Exception ex)
						{
							if (fs != null) fs.Close();
							status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
							throw new Exception(string.Format("OfflineDataSerializer.Serialize [{0}]�̃t�@�C���ۑ��Ɏ��s���܂����BException={1}",saveFullPath,ex.Message),ex);
						}
						finally
						{
							if (fs != null) fs.Close();
						}
#if UAC
                        // �� 20080509 18322 a ���̃��[�U�[�ł��t�@�C���ɃA�N�Z�X�ł���悤�Ɍ�����ǉ�
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
				throw new Exception(string.Format("�I�t���C���f�[�^�̕ۑ��Ɏ��s���܂����BException={0}",ex.Message),ex);
			}
			return status;
		}

//-- 2007.05.15 Add Start by T.Sugawa ------------------------------------------------------------//
		/// <summary>
		/// �f�V���A���C�Y
		/// </summary>
		/// <param name="classId">�N���XID</param>
		/// <param name="keyList">�L�[List</param>
		/// <param name="deserializeData">�f�V���A���C�Y�Ώۃf�[�^</param>
		/// <returns>�f�V���A���C�Y����</returns>
		public object DeSerialize(string classId, string[] keyList, byte[] deserializeData)
		{
			object result = null;
			try
			{
				if (deserializeData != null && deserializeData.Length > 0)
				{
					//Zip��
					deserializeData = DeCompressionEntry(deserializeData);

					//�J�X�^���V���A���C�U�f�V���A���C�Y
					if (deserializeData != null && deserializeData.Length > 0)
						result = CustomDeSerializeSaveData(deserializeData);
				}
			}
			catch (Exception ex)
			{
				throw new Exception(string.Format("�f�[�^�̃f�V���A���C�Y�Ɏ��s���܂����BException={0}", ex.Message), ex);
			}
			return result;
		}
//-- 2007.05.15 Add End by T.Sugawa --------------------------------------------------------------//

		/// <summary>
		/// �f�V���A���C�Y
		/// </summary>
		/// <param name="classId">�N���XID</param>
		/// <param name="keyList">�L�[List</param>
		/// <returns>�f�V���A���C�Y����</returns>
		public object DeSerialize(string classId, string[] keyList)
		{
			return this.DeSerialize(classId, keyList, _saveDir);
		}

		/// <summary>
		/// �f�V���A���C�Y
		/// </summary>
		/// <param name="classId">�N���XID</param>
		/// <param name="keyList">�L�[List</param>
		/// <param name="targetDir">�����Ώۃf�B���N�g��</param>
		/// <returns>�f�V���A���C�Y����</returns>
		public object DeSerialize(string classId, string[] keyList, string targetDir)
		{
			object result = null;
			try
			{
				//�ۑ���̃t�H���_�ʒu���w��
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
				//�ۑ��f�B���N�g����������΍쐬
				if (!Directory.Exists(saveFilePath)) Directory.CreateDirectory(saveFilePath);

				//�ۑ��p�̃t�@�C��ID�𐶐�
				string saveFileName = MakeFileName(classId, keyList);
				string saveFullPath = Path.Combine(saveFilePath,saveFileName);
				if (saveFileName != "" && File.Exists( saveFullPath ))
				{
					byte[] desKey;
					byte[] desIv;
					//�t�@�C�����擾
					byte[] saveData = FileReadProc(saveFilePath, saveFileName,out desKey,out desIv);
					if (saveData == null) return null;

					//������
					saveData = CompoundEntry(saveData,desKey,desIv);

					if (saveData != null && saveData.Length > 0)
					{
						//Zip��
						saveData = DeCompressionEntry(saveData);

						//�J�X�^���V���A���C�U�f�V���A���C�Y
						if (saveData != null && saveData.Length > 0) result = CustomDeSerializeSaveData(saveData);
					}
				}
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("�I�t���C���f�[�^�̎擾�Ɏ��s���܂����BException={0}",ex.Message),ex);
			}
			return result;
		}
		#endregion

		#region public Method String[] Serialize�֘A
		/// <summary>
		/// �V���A���C�Y
		/// </summary>
		/// <param name="classId">�N���XID</param>
		/// <param name="keyList">�L�[List</param>
		/// <param name="data">�V���A���C�Y�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		public int SerializeString(string classId, string[] keyList, string[] data)
		{
			return this.SerializeString(classId, keyList, data, _saveDir);
		}

		/// <summary>
		/// �V���A���C�Y
		/// </summary>
		/// <param name="classId">�N���XID</param>
		/// <param name="keyList">�L�[List</param>
		/// <param name="data">�V���A���C�Y�Ώۃf�[�^</param>
		/// <param name="targetDir">�����Ώۃf�B���N�g��</param>
		/// <returns>STATUS</returns>
		public int SerializeString(string classId, string[] keyList, string[] data, string targetDir)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			if (data == null || data.Length == 0) return status;

			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			try
			{
				//�ۑ���̃t�H���_�ʒu���w��(Temp�t�H���_�ɐ���)
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
				//�ۑ��f�B���N�g����������΍쐬
				if (!Directory.Exists(saveFilePath)) Directory.CreateDirectory(saveFilePath);

				//�ۑ��p�̃t�@�C��ID�𐶐�
				string saveFileName = MakeFileName(classId, keyList);
				if (saveFileName != "")
				{
					//�ۑ��t�@�C���t���p�X���擾
					string saveFullPath = Path.Combine(saveFilePath,saveFileName);
					//�ۑ��t�@�C��������Α����ύX
					if (File.Exists(saveFullPath)) File.SetAttributes(saveFullPath,FileAttributes.Normal);

					//�ۑ��f�[�^���V���A���C�Y��(string[]��byte[])
					byte[] saveData = SerializeStringSaveData(data);

					//Zip���k
					if (saveData != null) saveData = CompressionEntry(saveFileName,saveData);

					//�Í�������
					byte[] desKey = new byte[24];
					byte[] desIv  = new byte[8];
					if (saveData != null) saveData = EncryptionEntry(saveData,out desKey,out desIv);

					if (saveData != null)
					{
						//�t�@�C���ۑ�
						FileStream fs = null;
						try
						{
							//�B�t�@�C����������
							fs = File.Create(saveFullPath);
							fs.Write(desKey,0,desKey.Length);
							fs.Write(desIv,0,desIv.Length);
							fs.Write(saveData,0,saveData.Length);
							fs.Close();
							fs = null;
							//�C�쐬�����𒲐�
							if (File.Exists( saveFullPath ))	File.SetCreationTime(saveFullPath,DateTime.Now);
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						}
						catch(Exception ex)
						{
							if (fs != null) fs.Close();
							status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
							throw new Exception(string.Format("OfflineDataSerializer.SerializeString [{0}]�̃t�@�C���ۑ��Ɏ��s���܂����BException=",saveFullPath,ex.Message),ex);
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
				throw new Exception(string.Format("�I�t���C���f�[�^�̕ۑ��Ɏ��s���܂����BException={0}",ex.Message),ex);
			}
			return status;
		}

		/// <summary>
		/// �f�V���A���C�Y
		/// </summary>
		/// <param name="classId">�N���XID</param>
		/// <param name="keyList">�L�[List</param>
		/// <returns>�f�V���A���C�Y����</returns>
		public string[] DeSerializeString(string classId, string[] keyList)
		{
			return this.DeSerializeString(classId, keyList, _saveDir);
		}

		/// <summary>
		/// �f�V���A���C�Y
		/// </summary>
		/// <param name="classId">�N���XID</param>
		/// <param name="keyList">�L�[List</param>
		/// <param name="targetDir">�����Ώۃf�B���N�g��</param>
		/// <returns>�f�V���A���C�Y����</returns>
		public string[] DeSerializeString(string classId, string[] keyList, string targetDir)
		{
			string[] result = null;
			try
			{
				//�ۑ���̃t�H���_�ʒu���w��(Temp�t�H���_�ɐ���)
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
				//�ۑ��f�B���N�g����������΍쐬
				if (!Directory.Exists(saveFilePath)) Directory.CreateDirectory(saveFilePath);

				//�ۑ��p�̃t�@�C��ID�𐶐�
				string saveFileName = MakeFileName(classId, keyList);
				string saveFullPath = Path.Combine(saveFilePath,saveFileName);
				if (saveFileName != "" && File.Exists( saveFullPath ))
				{
					byte[] desKey;
					byte[] desIv;
					//�t�@�C�����擾
					byte[] saveData = FileReadProc(saveFilePath, saveFileName,out desKey,out desIv);
					if (saveData == null) return null;

					//������
					saveData = CompoundEntry(saveData,desKey,desIv);

					if (saveData != null && saveData.Length > 0)
					{
						//Zip��
						saveData = DeCompressionEntry(saveData);

						//�f�V���A���C�Y
						if (saveData != null && saveData.Length > 0) result = DeSerializeStringSaveData(saveData);
					}
				}
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("�I�t���C���f�[�^�̎擾�Ɏ��s���܂����BException={0}",ex.Message),ex);
			}
			return result;
		}
		#endregion

		#region public Method byte[] Serialize �֘A
		/// <summary>
		/// �V���A���C�Y
		/// </summary>
		/// <param name="classId">�N���XID</param>
		/// <param name="keyList">�L�[List</param>
		/// <param name="data">�V���A���C�Y�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		public int SerializeByte(string classId, string[] keyList, byte[] data)
		{
			return this.SerializeByte(classId, keyList, data, _saveDir);
		}

		/// <summary>
		/// �V���A���C�Y
		/// </summary>
		/// <param name="classId">�N���XID</param>
		/// <param name="keyList">�L�[List</param>
		/// <param name="data">�V���A���C�Y�Ώۃf�[�^</param>
		/// <param name="targetDir">�����Ώۃf�B���N�g��</param>
		/// <returns>STATUS</returns>
		public int SerializeByte(string classId, string[] keyList, byte[] data, string targetDir)
		{
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			if (data == null || data.Length == 0) return status;

			status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

			try
			{
				//�ۑ���̃t�H���_�ʒu���w��(Temp�t�H���_�ɐ���)
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
				//�ۑ��f�B���N�g����������΍쐬
				if (!Directory.Exists(saveFilePath)) Directory.CreateDirectory(saveFilePath);

				//�ۑ��p�̃t�@�C��ID�𐶐�
				string saveFileName = MakeFileName(classId, keyList);
				if (saveFileName != "")
				{
					//�ۑ��t�@�C���t���p�X���擾
					string saveFullPath = Path.Combine(saveFilePath,saveFileName);
					//�ۑ��t�@�C��������Α����ύX
					if (File.Exists(saveFullPath)) File.SetAttributes(saveFullPath,FileAttributes.Normal);

					//Zip���k
					if (data != null) data = CompressionEntry(saveFileName,data);

					//�Í�������
					byte[] desKey = new byte[24];
					byte[] desIv  = new byte[8];
					if (data != null) data = EncryptionEntry(data,out desKey,out desIv);

					if (data != null)
					{
						//�t�@�C���ۑ�
						FileStream fs = null;
						try
						{
							//�B�t�@�C����������
							fs = File.Create(saveFullPath);
							fs.Write(desKey,0,desKey.Length);
							fs.Write(desIv,0,desIv.Length);
							fs.Write(data,0,data.Length);
							fs.Close();
							fs = null;
							//�C�쐬�����𒲐�
							if (File.Exists( saveFullPath ))	File.SetCreationTime(saveFullPath,DateTime.Now);
							status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
						}
						catch(Exception ex)
						{
							if (fs != null) fs.Close();
							status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
							throw new Exception(string.Format("OfflineDataSerializer.SerializeByte [{0}]�̃t�@�C���ۑ��Ɏ��s���܂����BException=",saveFullPath,ex.Message),ex);
						}
						finally
						{
							if (fs != null) fs.Close();
						}
#if UAC
                        // �� 20080509 18322 a ���̃��[�U�[�ł��t�@�C���ɃA�N�Z�X�ł���悤�Ɍ�����ǉ�
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
				throw new Exception(string.Format("�I�t���C���f�[�^�̕ۑ��Ɏ��s���܂����BException={0}",ex.Message),ex);
			}
			return status;
		}

		/// <summary>
		/// �f�V���A���C�Y
		/// </summary>
		/// <param name="classId">�N���XID</param>
		/// <param name="keyList">�L�[List</param>
		/// <returns>�f�V���A���C�Y����</returns>
		public byte[] DeSerializeByte(string classId, string[] keyList)
		{
			return this.DeSerializeByte(classId, keyList, _saveDir);
		}

		/// <summary>
		/// �f�V���A���C�Y
		/// </summary>
		/// <param name="classId">�N���XID</param>
		/// <param name="keyList">�L�[List</param>
		/// <param name="targetDir">�����Ώۃf�B���N�g��</param>
		/// <returns>�f�V���A���C�Y����</returns>
		public byte[] DeSerializeByte(string classId, string[] keyList, string targetDir)
		{
			byte[] result = null;
			try
			{
				//�ۑ���̃t�H���_�ʒu���w��(Temp�t�H���_�ɐ���)
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
				//�ۑ��f�B���N�g����������΍쐬
				if (!Directory.Exists(saveFilePath)) Directory.CreateDirectory(saveFilePath);

				//�ۑ��p�̃t�@�C��ID�𐶐�
				string saveFileName = MakeFileName(classId, keyList);
				string saveFullPath = Path.Combine(saveFilePath,saveFileName);
				if (saveFileName != "" && File.Exists( saveFullPath ))
				{
					byte[] desKey;
					byte[] desIv;
					//�t�@�C�����擾
					byte[] saveData = FileReadProc(saveFilePath, saveFileName,out desKey,out desIv);
					if (saveData == null) return null;

					//������
					saveData = CompoundEntry(saveData,desKey,desIv);

					if (saveData != null && saveData.Length > 0)
					{
						//Zip��
						result = DeCompressionEntry(saveData);
					}
				}
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("�I�t���C���f�[�^�̎擾�Ɏ��s���܂����BException={0}",ex.Message),ex);
			}
			return result;
		}
		#endregion 

		#region public Method ���ʃ��\�b�h
		/// <summary>
		/// �V���A���C�Y�t�@�C���폜
		/// </summary>
		/// <param name="classId">�N���X��</param>
		/// <param name="keyList">KEY���X�g</param>
		/// <returns>STATUS</returns>
		public int Delete(string classId, string[] keyList)
		{
			return Delete(classId, keyList, _saveDir);
		}

		/// <summary>
		/// �V���A���C�Y�t�@�C���폜
		/// </summary>
		/// <param name="classId">�N���X��</param>
		/// <param name="keyList">KEY���X�g</param>
		/// <param name="targetDir">�����Ώۃf�B���N�g��</param>
		/// <returns>STATUS</returns>
		public int Delete(string classId, string[] keyList, string targetDir)
		{
			int result = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

			try
			{
				//�ۑ���̃t�H���_�ʒu���w��(Temp�t�H���_�ɐ���)
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
				//�ۑ��f�B���N�g����������΍폜�f�[�^����
				if (Directory.Exists(saveFilePath))
				{
					//�ۑ��p�̃t�@�C��ID�𐶐�
					string saveFileName = MakeFileName(classId, keyList);
					string saveFullPath = Path.Combine(saveFilePath,saveFileName);
					if (saveFileName != "" && File.Exists( saveFullPath ))
					{
						//�ۑ��t�@�C��������Α����ύX
						File.SetAttributes(saveFullPath,FileAttributes.Normal);
						//�t�@�C���폜
						File.Delete(saveFullPath);
						//�߂�l��ݒ�
						result = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
					}
				}
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("�I�t���C���f�[�^�̍폜�Ɏ��s���܂����BException={0}",ex.Message),ex);
			}
			return result;
		}

		/// <summary>
		/// �V���A���C�Y�t�@�C�����݃`�F�b�N
		/// </summary>
		/// <param name="classId">�N���X��</param>
		/// <param name="keyList">KEY���X�g</param>
		/// <returns>T:�L�� F:����</returns>
		public bool Exists(string classId, string[] keyList)
		{
			return this.Exists(classId, keyList, _saveDir);
		}

		/// <summary>
		/// �V���A���C�Y�t�@�C�����݃`�F�b�N
		/// </summary>
		/// <param name="classId">�N���X��</param>
		/// <param name="keyList">KEY���X�g</param>
		/// <param name="targetDir">�����Ώۃf�B���N�g��</param>
		/// <returns>T:�L�� F:����</returns>
		public bool Exists(string classId, string[] keyList, string targetDir)
		{
			bool result = false;

			try
			{
				//�ۑ���̃t�H���_�ʒu���w��(Temp�t�H���_�ɐ���)
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
				//�ۑ��f�B���N�g����������΃f�[�^����
				if (Directory.Exists(saveFilePath))
				{
					//�ۑ��p�̃t�@�C��ID�𐶐�
					string saveFileName = MakeFileName(classId, keyList);
					string saveFullPath = Path.Combine(saveFilePath,saveFileName);
					//�ۑ��t�@�C���������True��߂�
					if (saveFileName != "" && File.Exists( saveFullPath )) result = true;
				}
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("�I�t���C���f�[�^�̑��݃`�F�b�N�Ɏ��s���܂����BException={0}",ex.Message),ex);
			}
			return result;
		}
		#endregion

		#region private Method Customer Serialize �֘A
		/// <summary>
		/// �J�X�^���V���A���C�U�@�V���A���C�Y
		/// </summary>
		/// <param name="input">�Ώۃf�[�^</param>
		/// <returns>�J�X�^���V���A���C�Y����</returns>
		private byte[] CustomSerializeSaveData(object input)
		{
			byte[] ret = null;
			MemoryStream ms = null;
			System.IO.BinaryWriter writer = null;
			try
			{
				//�o�C�i�����C�^����
				ms = new MemoryStream();
				writer = new BinaryWriter(ms);

				//�T���Q�[�g�^�[�Q�b�g�擾
				string SurrogateTarget = MakeSurrogateName(input);
				//�t�H�[�}�b�^�擾
				ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( SurrogateTarget );
				//�T���Q�[�g�^�[�Q�b�g���̏�������
				writer.Write( SurrogateTarget );
				//�T���Q�[�g�I�u�W�F�N�g��������
				formatter.Serialize( writer , input );

				//�߂�l�փo�C�g����߂�
				ret = ms.ToArray();
				writer.Close();
				ms.Close();
			}
			catch(Exception ex)
			{
				if (writer != null) writer.Close();
				if (ms != null) ms.Close();
				throw new Exception(string.Format("OfflineDataSerializer.CustomSerializeSaveData �\���t�@�C���̋L�q�Ɍ�肪����܂��B[{0}]",ex.Message),ex);
			}

			return ret;
		}

		/// <summary>
		/// �J�X�^���V���A���C�U�@�f�V���A���C�Y
		/// </summary>
		/// <param name="data">�f�V���A���C�Y�Ώۃf�[�^</param>
		/// <returns>�f�V���A���C�Y����</returns>
		private object CustomDeSerializeSaveData(byte[] data)
		{
			object result = null;
			MemoryStream ms = null;
			System.IO.BinaryReader reader = null;
			try
			{
				ms = new MemoryStream(data);
				reader = new BinaryReader(ms);
				//�T���Q�[�g���̎擾
				string SurrogateTarget = reader.ReadString();
				ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( SurrogateTarget );
				result = formatter.Deserialize( reader );
			}
			catch(Exception ex)
			{
				if (reader != null) reader.Close();
				if (ms != null) ms.Close();
				throw new Exception(string.Format("OfflineDataSerializer.CustomSerializeSaveData �\���t�@�C���̋L�q�Ɍ�肪����܂��B[{0}]",ex.Message),ex);
			}
			finally
			{
				if (reader != null) reader.Close();
				if (ms != null) ms.Close();
			}

			return result;
		}

		/// <summary>
		/// Binary�V���A���C�U�������ݏ���
		/// </summary>
		/// <param name="writer">�V���A���C�U</param>
		/// <param name="input">�������ݑΏۃI�u�W�F�N�g</param>
		private void WriteClassInfo(System.IO.BinaryWriter writer, object input)
		{
			string SurrogateTarget = MakeSurrogateName(input);
			ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( SurrogateTarget );
			//�T���Q�[�g�^�[�Q�b�g���̏�������
			writer.Write( SurrogateTarget );
			//�T���Q�[�g�I�u�W�F�N�g��������
			formatter.Serialize( writer , input );
		}

		/// <summary>
		/// �T���Q�[�g�^�[�Q�b�g���̍쐬
		/// </summary>
		/// <param name="input">�V���A���C�Y�ΏۃI�u�W�F�N�g</param>
		/// <returns>�T���Q�[�g�^�[�Q�b�g����</returns>
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

		#region private Method string[] �֘A
		/// <summary>
		/// String�V���A���C�U
		/// </summary>
		/// <param name="input">�V���A���C�Y�Ώە�����</param>
		/// <returns>�V���A���C�Y����</returns>
		private byte[] SerializeStringSaveData(string[] input)
		{
			byte[] ret = null;
			MemoryStream ms = null;
			System.IO.BinaryWriter writer = null;
			try
			{
				//�o�C�i�����C�^����
				ms = new MemoryStream();
				writer = new BinaryWriter(ms);
				writer.Write( (Int32)input.Length );
				foreach(string str in input)
				{
					writer.Write( (string)str );
				}
				//�߂�l�փo�C�g����߂�
				ret = ms.ToArray();
				writer.Close();
				ms.Close();
			}
			catch(Exception ex)
			{
				if (writer != null) writer.Close();
				if (ms != null) ms.Close();
				throw new Exception(string.Format("OfflineDataSerializer.SerializeStringSaveData �����z��̃V���A���C�Y�Ɏ��s�B[{0}]",ex.Message),ex);
			}

			return ret;
		}

		/// <summary>
		/// String�f�V���A���C�U
		/// </summary>
		/// <param name="data">�f�V���A���C�Y�Ώ�Binary</param>
		/// <returns>�f�V���A���C�Y����</returns>
		private string[] DeSerializeStringSaveData(byte[] data)
		{
			string[] result = null;
			MemoryStream ms = null;
			System.IO.BinaryReader reader = null;
			try
			{
				ms = new MemoryStream(data);
				reader = new BinaryReader(ms);
				//������i�[���擾
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
				throw new Exception(string.Format("OfflineDataSerializer.DeSerializeStringSaveData �����z��̃f�V���A���C�Y�Ɏ��s�B[{0}]",ex.Message),ex);
			}
			finally
			{
				if (reader != null) reader.Close();
				if (ms != null) ms.Close();
			}

			return result;
		}
		#endregion

		#region private Method ���ʃ��\�b�h
		/// <summary>
		/// �t�@�C�����̐���
		/// </summary>
		/// <param name="classId">�N���XID</param>
		/// <param name="keyList">Key���X�g</param>
		/// <returns>�t�@�C������</returns>
		private string MakeFileName(string classId, string[] keyList)
		{
			//�߂�l������
			string result = "";

			try
			{
				//���t�@�C��������
				StringBuilder sb = new StringBuilder(256);
				//�N���XID�t�^
				sb.Append(classId);
				//KEY���ݒ�
				foreach(string key in keyList) sb.Append(key);

				//��������t�@�C�����𐶐�
				string tempFileName = sb.ToString();

				//��������t�@�C�������n�b�V����
				byte[] byteFileName = Encoding.Unicode.GetBytes(tempFileName);
				// This is one implementation of the abstract class MD5.
				MD5 md5 = new MD5CryptoServiceProvider();
				byte[] byteResult = md5.ComputeHash(byteFileName);
				tempFileName =  BitConverter.ToString(byteResult).Replace("-","");
		
				//���g���q���Ō�ɕt����
				result = tempFileName + _saveExt;
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("�I�t���C���t�@�C�����̂̐����Ɏ��s���܂����BException={0}",ex.Message),ex);
			}

			return result;
		}

		/// <summary>
		/// ZIP���k
		/// </summary>
		/// <param name="fileName">�t�@�C������</param>
		/// <param name="data">�������݃f�[�^</param>
		/// <returns>ZIP���k����</returns>
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

				//ZIP�ɒǉ�����Ƃ��̃t�@�C������SET����
				ze = new ZipEntry(fileName);
				ze.CompressionMethod = CompressionMethod.Deflated;
				zos.PutNextEntry(ze);

				ms = new MemoryStream(data);
				reader = new BinaryReader(ms);
			
				//��������
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

				//ZIP�`���̃o�C�g�z����擾
				result = fos.ToArray();
				fos.Close();
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("OfflineDataSerializer.ZipEntry ���k�����Ɏ��s���܂����B[{0}]",ex.Message),ex);
			}
			finally
			{
				//����
				if (reader != null) reader.Close();
				if (ms != null) ms.Close();
			}
			return result;
		}

		/// <summary>
		/// Zip��
		/// </summary>
		/// <returns>Zip�𓀌���</returns>
		private byte[] DeCompressionEntry(byte[] data)
		{
			byte[] result = null;
			MemoryStream fis = null;
			ZipInputStream zis = null;

			try
			{
				//�ǂݍ���
				fis = new MemoryStream(data);
				zis = new ZipInputStream(fis);
			
				//ZIP���̃t�@�C�������擾
				ZipEntry ze;
				while ((ze = zis.GetNextEntry()) != null)
				{
					if(!ze.IsDirectory)
					{
						MemoryStream ms = new MemoryStream();
						//������
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
				//����
				if (zis != null) zis.Close();
				if (fis != null) fis.Close();
			}
			return result;
		}

		/// <summary>
		/// �f�[�^�Í���
		/// </summary>
		/// <param name="source">�Í����Ώۃf�[�^</param>
		/// <param name="desKey">�L�[</param>
		/// <param name="desIv">�K��l</param>
		private byte[] EncryptionEntry(byte[] source,out byte[] desKey,out byte[] desIv)
		{
			byte[] result = null;
			MemoryStream mem = null;
			CryptoStream cs = null;
			desKey = null;
			desIv = null;
			try
			{

				// Trippe DES �̃T�[�r�X �v���o�C�_�𐶐����܂�
				TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();

				provider.GenerateKey();
				provider.GenerateIV();

				desKey = provider.Key;
				desIv = provider.IV;

				// ���o�͗p�̃X�g���[���𐶐����܂�
				mem = new MemoryStream();
				cs = new CryptoStream(mem, provider.CreateEncryptor( desKey, desIv), CryptoStreamMode.Write);

				// �X�g���[���ɈÍ������ꂽ�f�[�^���������݂܂�
				cs.Write(source, 0, source.Length);
				cs.Close();

				// �Í������ꂽ�f�[�^�� byte �z��Ŗ߂��܂�
				result = mem.ToArray();				
				mem.Close();		
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("OfflineDataSerializer.EncryptionEntry �Í��������Ɏ��s���܂����B[{0}]",ex.Message),ex);
			}
			finally
			{
				if (cs != null) cs.Close();
				if (mem != null ) mem.Close();				
			}
			return result;
		}

		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="data">�������Ώۃf�[�^</param>
		/// <param name="desKey">�Í���KEY</param>
		/// <param name="desIv">�Í���KEY</param>
		/// <returns>��������</returns>
		private byte[] CompoundEntry(byte[] data,byte[] desKey,byte[] desIv)
		{
			byte[] result = null;
			MemoryStream ms = null;
			CryptoStream cs = null;
			try
			{
				// Trippe DES �̃T�[�r�X �v���o�C�_�𐶐����܂�
				TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();

				// ���o�͗p�̃X�g���[���𐶐����܂�
				ms = new MemoryStream();
				cs = new CryptoStream(ms, des.CreateDecryptor( desKey, desIv ), CryptoStreamMode.Write);

				// �X�g���[���ɈÍ������ꂽ�f�[�^���������݂܂�
				cs.Write(data, 0, data.Length);
				cs.Close();

				// ���������ꂽ�f�[�^�� byte �z��Ŏ擾���܂�
				result = ms.ToArray();
				ms.Close();
			}
			catch(Exception ex)
			{
				throw new Exception(string.Format("OfflineDataSerializer.CompoundEntry �������G���[ Exception=",ex.Message),ex);
			}
			finally
			{
				if (cs != null) cs.Close();
				if (ms != null) ms.Close();
			}

			return result;
		}

		/// <summary>
		/// �t�@�C���Ǎ�����
		/// </summary>
		/// <param name="filePath">�ۑ��t�@�C���p�X</param>
		/// <param name="fileName">�ۑ��t�@�C������</param>
		/// <param name="desKey">�Í����L�[</param>
		/// <param name="desIv">�Í����L�[</param>
		/// <returns>�Ǎ�����</returns>
		private byte[] FileReadProc(string filePath, string fileName,out byte[] desKey,out byte[] desIv)
		{
			desKey	= null;
			desIv	= null;
			byte[] result = null;

			//�ۑ��p�f�B���N�g���������ꍇ�͏I��
			if (!Directory.Exists(filePath)) return result;

			//�t���p�X�擾
			string fileFullPath = Path.Combine(filePath, fileName);

			//�@�摜��񂪑��݂��Ȃ��ꍇ�I��
			if (!File.Exists( fileFullPath )) return result;

			FileStream fs = null;
			BinaryReader br = null;
			try
			{
				TripleDESCryptoServiceProvider tds = new TripleDESCryptoServiceProvider();

                //2009.06.23 23011 noguchi del ���I�t���C���f�[�^���[�h���Ƀt�@�C����͂�ł܂��G���[���ł�̂ŏC�� >>
                //fs = new FileStream( fileFullPath , FileMode.Open );
                ////�@�t�@�C���ǂݍ���
                //br = new BinaryReader(fs);
                //desKey	= br.ReadBytes((int)tds.Key.Length);
                //desIv	= br.ReadBytes((int)tds.IV.Length);
                //result = br.ReadBytes((int)(fs.Length - (tds.Key.Length + tds.IV.Length)));
                //br.Close();
                //br = null;
                //fs.Close();
                //fs = null;
                //>> 2009.06.23 23011 noguchi del

                //2009.06.23 23011 noguchi add �t�@�C����͂܂Ȃ��ŊJ���悤�ɏC�� >>
                using(fs = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                //�@�t�@�C���ǂݍ���
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
				throw new Exception(string.Format("�I�t���C���f�[�^�̓Ǎ��Ɏ��s���܂����BException={0}",ex.Message),ex);
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
