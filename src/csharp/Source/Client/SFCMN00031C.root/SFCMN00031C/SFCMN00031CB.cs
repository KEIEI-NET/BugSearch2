using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Library.Text
{
    //************************************************************
    //
    //  ���̃\�[�X�t�@�C���ɂ́u�e�L�X�g�o��(�O�����J�N���X)�v
    // �Ɋ֘A����N���X, �e���`����������Ă��܂�
    //
    //************************************************************

    /// <summary>
    /// �e�L�X�g�o�̓N���X	
    /// </summary>
    /// <remarks>
    /// <br>Note       : �N���X��DataSet(DataTable)�����o�l���e�L�X�g������</br> 
    /// <br>           : �e��T�[�r�X��񋟂��܂�</br>
    /// <br>Programmer : 980056 R.Sokei</br>
    /// <br>Date       : 2006.04.25</br>
	/// <br>Update Date: �@ 2007.06.26 ���c�@�`�� (20015)
	///                :    �ǉ����[�h�ł̏o�͎��A�w�b�_���o�͂���Ă����̂ŁAPegasus�Ɠ��l�ɒǉ�����
	///                :    �w�b�_���o�͂��Ȃ��悤�ɕύX
	/// </br>
	/// </remarks>
    public class CustomTextWriter 
    {

        public CustomTextWriter()
        {
            TextIO = new CustomTextProvider();
        }

        private CustomTextProvider TextIO;

        /// <summary>
        /// �e�L�X�g�f�[�^�擾
        /// </summary>
        /// <param name="source">����ΏۃI�u�W�F�N�g</param>
        /// <param name="schemaPath">�X�L�[�}�t�@�C���p�X</param>
        /// <param name="text">�����e�L�X�g</param>
        /// <returns>�������� 0:��������, 4:�Ώۃf�[�^�Ȃ�, -9:�o�͑ΏۊO�̃f�[�^���w�肳�ꂽ, -1:���̑��G���[</returns>
        /// <remarks>
        /// <br>Note       : source�̃����o�l���X�g���e�L�X�g�f�[�^�Ƃ��Ď擾���܂�</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public int GetText(object source, string schemaPath, out string text)
        {
            return GetText(source, schemaPath, out text, null);
        }


        /// <summary>
        /// �e�L�X�g�f�[�^�擾
        /// </summary>
        /// <param name="source">����ΏۃI�u�W�F�N�g</param>
        /// <param name="schemaPath">�X�L�[�}�t�@�C���p�X</param>
        /// <param name="text">�����e�L�X�g</param>
        /// <param name="textInfo">�J�X�^���e�L�X�g�쐬�p���</param>
        /// <returns>�������� 0:��������, 4:�Ώۃf�[�^�Ȃ�, -9:�o�͑ΏۊO�̃f�[�^���w�肳�ꂽ, -1:���̑��G���[</returns>
        /// <remarks>
        /// <br>Note       : source�̃����o�l���X�g���e�L�X�g�f�[�^�Ƃ��Ď擾���܂�</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public int GetText(object source, string schemaPath, out string text, CustomTextProviderInfo customTextProviderInfo)
        {
            customTextProviderInfo = SetCustomTextProviderInfo(schemaPath, "", customTextProviderInfo);
            return MakeTextProc(source, out text, customTextProviderInfo);
        }


        /// <summary>
        /// �e�L�X�g�f�[�^�o��
        /// </summary>
        /// <param name="source">����ΏۃI�u�W�F�N�g</param>
        /// <param name="schemaPath">�X�L�[�}�t�@�C���p�X</param>
        /// <param name="outputFilepath">�o�̓t�@�C���p�X</param>
        /// <param name="appendMode">�e�L�X�g�ǉ����[�h true:�ǉ����[�h, false:�㏑�����[�h</param>
        /// <returns>�������� 0:��������, 4:�Ώۃf�[�^�Ȃ�, -9:�o�͑ΏۊO�̃f�[�^���w�肳�ꂽ, -1:���̑��G���[</returns>
        /// <remarks>
        /// <br>Note       : source�̃����o�l���X�g���e�L�X�g�f�[�^�Ƃ��ăt�@�C���ɏo�͂��܂�</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public int WriteText(object source, string schemaPath, string outputFilepath, bool appendMode)
        {
            CustomTextProviderInfo customTextProviderInfo = SetCustomTextProviderInfo(schemaPath, outputFilepath, null);
            customTextProviderInfo.AppendMode = appendMode;
            return WriteText(source, schemaPath, outputFilepath, customTextProviderInfo);
        }

        /// <summary>
        /// �e�L�X�g�f�[�^�o��
        /// </summary>
        /// <param name="source">����ΏۃI�u�W�F�N�g</param>
        /// <param name="schemaPath">�X�L�[�}�t�@�C���p�X</param>
        /// <param name="outputFilepath">�o�̓t�@�C���p�X</param>
        /// <param name="textInfo">�J�X�^���e�L�X�g�쐬�p���</param>
        /// <returns>�������� 0:��������, 4:�Ώۃf�[�^�Ȃ�, -9:�o�͑ΏۊO�̃f�[�^���w�肳�ꂽ, -1:���̑��G���[</returns>
        /// <remarks>
        /// <br>Note       : source�̃����o�l���X�g���e�L�X�g�f�[�^�Ƃ��ăt�@�C���ɏo�͂��܂�</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public int WriteText(object source, string schemaPath, string outputFilepath, CustomTextProviderInfo customTextProviderInfo)
        {
			string text;
            customTextProviderInfo = SetCustomTextProviderInfo(schemaPath, outputFilepath, customTextProviderInfo);

// >>>> 2007.06.26 ���c Add ���ǉ��o�͎��w�b�_�����Ή� >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
			// �ǉ����[�h�`�F�b�N�iUI�㖳�`�F�b�N�Œǉ����[�h�ɂł���B�{���̓t�@�C���������̂ɒǉ����[�h�ŗ���\�������邽�߃`�F�b�N�j
			if (customTextProviderInfo.AppendMode == true)
			{
				customTextProviderInfo.AppendMode = AppendModeCheck(customTextProviderInfo);
			}
// <<<< 2007.06.26 ���c Add ���ǉ��o�͎��w�b�_�����Ή� <<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // �e�L�X�g����
            int st = MakeTextProc(source, out text, customTextProviderInfo);

            // �e�L�X�g�t�@�C���֏o��
//            MakeTextFile(text, ref outputFilepath, 0, System.Text.Encoding.Default);
			MakeTextFile(text, ref customTextProviderInfo);


            return st; 

        }
		/// <summary>
		/// �ǉ����[�h�`�F�b�N����
		/// </summary>
		/// <param name="customTextProviderInfo">�e�L�X�g�o�̓T�[�r���p�����[�^</param>
		/// <returns>�ǉ����[�h(True:�ǉ����[�h,False:�㏑�����[�h)</returns>
		/// <remarks>
		/// <br>Note       : �e�L�X�g�o�̓T�[�r�X�Ăё��ł́A�`�F�b�N�����Œǉ����[�h���w�肳���̂ŁA�ǉ����[�h�ŗǂ����`�F�b�N���s��</br>
		/// <br>Programmer : ���c�@�`��</br>
		/// <br>Date       : 2007.06.26</br>
		/// </remarks>
		private bool AppendModeCheck(CustomTextProviderInfo customTextProviderInfo)
		{
			string lOutputFilepath;
			string folderName = "";

			// �o�̓t�@�C�����̂����ݒ�̏ꍇ �� �㏑�����[�h�ɕύX
			if ((customTextProviderInfo.OutPutFileName == null) ||
				((customTextProviderInfo.OutPutFileName != null) && (customTextProviderInfo.OutPutFileName.Trim() == "")))
				return false;

			// �o�̓f�B���N�g���ƃt�@�C����������
			if ((customTextProviderInfo.OutPutFolderName != null) && (customTextProviderInfo.OutPutFolderName.Trim() != ""))
			{
				folderName = customTextProviderInfo.OutPutFolderName;
			}
			else
			{
				folderName = System.IO.Directory.GetCurrentDirectory();
			}

			if (folderName.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
			{
				lOutputFilepath = folderName + customTextProviderInfo.OutPutFileName;
			}
			else
			{
				lOutputFilepath = folderName + System.IO.Path.DirectorySeparatorChar.ToString() + customTextProviderInfo.OutPutFileName;
			}

			// �t�@�C�������݂��Ȃ��ꍇ �� �㏑�����[�h�ɕύX
			if (System.IO.File.Exists(lOutputFilepath) == false) return false;

			try
			{
				// �t�@�C�������݂���ꍇ�́A�t�@�C���̒��ɍs�����݂���̂��`�F�b�N
				System.IO.StreamReader reader = new System.IO.StreamReader(lOutputFilepath);

				if (reader == null) return false;

				string oneLine = reader.ReadLine();

				// �P�s�ڂ��ǂݍ��߂Ȃ��ꍇ
				if ((oneLine == null) || ((oneLine != null) && (oneLine.Trim() == ""))) return false;

				reader.Close();
			}
			catch
			{
				// �G���[�͖���
				return false;
			}

			return true;
		}


        public CustomTextProviderInfo GetCustomTextProviderInfo(string schemaPath)
        {
            CustomTextProviderInfo inf;
            TextIO.ReadSchemaInfo(schemaPath, out inf);

            if (inf == null)
            {
                inf = CustomTextProviderInfo.GetDefaultInfo();
            }

            return inf;

        }


        private CustomTextProviderInfo SetCustomTextProviderInfo(string schemaPath, string outputFilepath, CustomTextProviderInfo customTextProviderInfo)
        {
            CustomTextProviderInfo ltmp;

            if (customTextProviderInfo == null)
            {
                // textInfo ���w�肳��Ă��Ȃ��ꍇ
                if ((schemaPath != null) && (schemaPath.Trim() != ""))
                {
                    // schemaPath���w�肳��Ă���΁A���̐ݒ���g�p����
                    TextIO.ReadSchemaInfo(schemaPath, out ltmp);
                }
                else
                {
                    // schemaPath�������ꍇ�̓f�t�H���g�ݒ���g�p����
                    ltmp = CustomTextProviderInfo.GetDefaultInfo();
                }
            }
            else
            {
                // customTextProviderInfo������ꍇ�́A������g�p����
                ltmp = customTextProviderInfo;
            }

            // schemaPath���w�肳��Ă���΁A���̃p�X��]�L����
            if ((schemaPath != null) && (schemaPath.Trim() != ""))
            {
                ltmp.SchemaFileName = schemaPath;

            }

            // outputFilepath���w�肳��Ă���΁A���̃p�X�𕪉����ē]�L����
            if ((outputFilepath != null) && (outputFilepath.Trim() != ""))
            {

                ltmp.OutPutFileName = System.IO.Path.GetFileName(outputFilepath);
                ltmp.OutPutFolderName = System.IO.Path.GetDirectoryName(outputFilepath);

            }
            
            return ltmp;
        }

        /// <summary>
        /// �e�L�X�g�f�[�^�o��
        /// </summary>
        /// <param name="source">����ΏۃI�u�W�F�N�g</param>
        /// <param name="schemaPath">�X�L�[�}�t�@�C���p�X</param>
        /// <param name="schemaPath">�o�̓t�@�C���p�X</param>
        /// <param name="textInfo">�J�X�^���e�L�X�g�쐬�p���</param>
        /// <remarks>
        /// <br>Note       : source�̃����o�l���X�g���e�L�X�g�f�[�^�Ƃ��ăt�@�C���ɏo�͂��܂�</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        private int MakeTextProc(object source, out string text, CustomTextProviderInfo textInfo)
        {
            string strTmp;
            int st = 0;

            if(textInfo == null)
            {
                textInfo = new CustomTextProviderInfo();
            }
            
            if (source is DataSet)
            {
                st = TextIO.DataSetToText((DataSet)source, out strTmp, textInfo);
            }
            else if (source is DataTable)
            {
                // �f�[�^�\�[�X�� DataTable �̏ꍇ�� DataSet���쐬���� DataTable ���i�[����
                DataSet ds = new DataSet("systemMadeDataSet");

//				ds.Tables.Add((DataTable)source);				// 2006.08.30 ���c Del

// >>>>> 2006.08.30 ���c Add �������� >>>>>>>>>>>>>>>>>>>>>>>>
				// �o�͑Ώۃf�[�^��DataTable�̏ꍇ�́A���ɓn���ꂽTable��DataSet�Ɋ��ɑ����Ă���\��������̂ŁA�e�[�u����COPY����
				DataTable dt = ((DataTable)source).Copy();
				ds.Tables.Add(dt);

                st = TextIO.DataSetToText(ds, out strTmp, textInfo);
// <<<<> 2006.08.30 ���c Add �����܂� <<<<<<<<<<<<<<<<<<<<<<<<

			}
// >>>>> 2006.08.30 ���c Add �������� >>>>>>>>>>>>>>>>>>>>>>>>
			// DataView�̑Ή�
			else if (source is DataView)
			{ 
				DataView dv = (DataView)source;

				DataSet ds = new DataSet("systemMadeDataSet");
				DataTable dt = dv.ToTable();

				ds.Tables.Add(dt);
				 
				st = TextIO.DataSetToText(ds, out strTmp, textInfo);
			}
// <<<<> 2006.08.30 ���c Add �����܂� <<<<<<<<<<<<<<<<<<<<<<<<
			else
			{

				// �f�[�^�\�[�X(����ΏۃI�u�W�F�N�g)��ArrayList�ɓ���Ȃ���
				ArrayList al;
				if (source is ArrayList)
				{
					al = (ArrayList)source;
				}
				else if (source is Array)
				{
					al = new ArrayList((Array)source);
				}
				else
				{
					al = new ArrayList();
					al.Add(source);
				}

				st = TextIO.ClassMemberToText(al, out strTmp, textInfo);

			}


            text = strTmp;
            return st;
        }


        /// <summary>
        /// �e�L�X�g�f�[�^�o��
        /// </summary>
        /// <param name="source">�o�̓f�[�^</param>
        /// <param name="schemaPath">�o�̓t�@�C���p�X</param>
        /// <param name="cipherMode">�Í����[�h 0:�Í����Ȃ�, 0<>�Í����L��</param>
        /// <remarks>
        /// <br>Note       : source���t�@�C���ɏo�͂��܂�</br>
        /// <br>           : �o�̓t�@�C���p�X�����Ă��Ȃ������ꍇ�͎������������t�@�C���p�X��Ԃ��܂�</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
//        private int MakeTextFile(string source, ref string outputFilepath, int cipherMode, System.Text.Encoding enCode)
        private int MakeTextFile(string source, ref CustomTextProviderInfo customTextProviderInfo)
        {
            int st = 0;

            string lOutputFilepath;
            string lOutputFileName = customTextProviderInfo.OutPutFileName;

            if ((lOutputFileName != null) && (lOutputFileName.Trim() != ""))
            {
                // �e�L�X�g�u������

            }
            else 
            {
                // �o�̓t�@�C�����̐���
                lOutputFileName = Guid.NewGuid().ToString() + ".csv";

            }
            
            // �o�̓f�B���N�g���ƃt�@�C����������
//            lOutputFilepath = System.IO.Path.Combine(customTextProviderInfo.outPutFolderName, "\\"+lOutputFileName);
            if (customTextProviderInfo.OutPutFolderName == null)
            {
                customTextProviderInfo.OutPutFolderName = System.IO.Directory.GetCurrentDirectory();
            }


            if (customTextProviderInfo.OutPutFolderName.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
            {
                lOutputFilepath = customTextProviderInfo.OutPutFolderName + lOutputFileName;
            }
            else
            {
                lOutputFilepath = customTextProviderInfo.OutPutFolderName + System.IO.Path.DirectorySeparatorChar.ToString() + lOutputFileName;
            }

            //          outputFilepath = System.IO.Path.Combine
//            System.Windows.Forms.MessageBox.Show(customTextProviderInfo.outPutFolderName + "\n" + lOutputFileName + "\n" + lOutputFilepath);

            // Shift JIS �R�[�h�ŏ����o��
            System.IO.StreamWriter writer =
                new System.IO.StreamWriter(lOutputFilepath, customTextProviderInfo.AppendMode,
                    customTextProviderInfo.EncodeType);
//            writer.WriteLine(source);								// 2007.06.26 ���c Del ���ǉ��o�͎��w�b�_�����Ή�
			writer.Write(source);									// 2007.06.26 ���c Add ���ǉ��o�͎��w�b�_�����Ή�
            writer.Close();

            return st;
        }

    }


}
