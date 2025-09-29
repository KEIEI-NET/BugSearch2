using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.Collections;

namespace Broadleaf.Library.Text
{
    //*******************************************************************
    //
    //  ���̃\�[�X�t�@�C���ɂ́u�e�L�X�g�o�͊֘A���ʃN���X, �p�����[�^�v
    // �Ɋ֘A����N���X, �e���`����������Ă��܂�
    //
    //*******************************************************************

    /// <summary>
    /// �e�L�X�g�o�̓T�[�r�X�p�����[�^
    /// </summary>
    /// <remarks>
    /// <br>Note       : �e�L�X�g�o�̓T�[�r�X�����s���邽�߂̊e��ݒ襏����p�����[�^</br>
    /// <br>Programmer : R.Sokei</br>
    /// <br>Date       : 2006.04.21</br>
    /// </remarks>
    public class CustomTextProviderInfo
    {

        #region �R���X�g���N�^
        public CustomTextProviderInfo()
        {

        
        }

        /// <summary>
        /// �e�L�X�g�o�̓T�[�r�X�p�����[�^ �����l�擾
        /// </summary>
        /// <returns>�e�L�X�g�o�̓T�[�r�X�p�����[�^�����l</returns>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�̓T�[�r�X�p�����[�^�̏����l���Z�b�g���ĕԂ��܂�</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public CustomTextProviderInfo(string shemaName, string outputName)
        {
            InitProc();

            SchemaFileName = shemaName;
            if ((outputName != null) && (outputName != ""))
            {
                OutPutFileName = System.IO.Path.GetFileName(outputName);           // �t�@�C����
                OutPutFolderName = System.IO.Path.GetDirectoryName(outputName);    // �t�@�C���쐬�t�H���_
            }
        }

        #endregion �R���X�g���N�^

        
        #region �v���p�e�B

        /// <summary>
        /// �X�L�[�}�t�@�C����
        /// </summary>
        public string SchemaFileName = "";

        /// <summary>
        /// �t�@�C����
        /// </summary>
        public string OutPutFileName = "";

        /// <summary>
        /// �t�@�C���쐬�t�H���_
        /// </summary>
        public string OutPutFolderName = "";

        /// <summary>
        /// �e�L�X�g���
        /// </summary>
        public CustomTextKinds TextKind = CustomTextKinds.CSV;

        /// <summary>
        /// �o�C�i���`��
        /// </summary>
        public CustomTextFormats TextFormat = CustomTextFormats.TEXT;

        /// <summary>
        /// �����R�[�h(�o�̓G���R�[�h�w�� SJIS, UTF-8��)
        /// </summary>
        public System.Text.Encoding EncodeType = System.Text.Encoding.Default;

        /// <summary>
        /// �e�L�X�g�ǉ����[�h(True:�ǉ����[�h,False:�㏑�����[�h)
        /// </summary>
        public bool AppendMode = false;

        // �o�͎��Í����L��

        /// <summary>
        /// �w�b�_���t���敪
        /// </summary>
        public bool AddTextHeder = false;


        // �e��v���p�e�B�̓��͏��(true=�f�t�H���g�l)
        public bool IsDefaultData_OutPutFileName = true;
        public bool IsDefaultData_OutPutFolderName = true;
        public bool IsDefaultData_TextKind = true;
        public bool IsDefaultData_TextFormat = true;
        public bool IsDefaultData_EncodeType = true;
        public bool IsDefaultData_AppendMode = true;
        public bool IsDefaultData_AddTextHeder = true;


        // �e��v���p�e�B�̓��͏�Ԃ�ύX����
        public void SetDataState(bool outPutFileName, bool outPutFolderName, bool textKind, bool textFormat, bool encodeType, bool appendMode, bool addTextHeder)
        {
            this.IsDefaultData_OutPutFileName = outPutFileName;
            this.IsDefaultData_OutPutFolderName = outPutFolderName;
            this.IsDefaultData_TextKind = textKind;
            this.IsDefaultData_TextFormat = textFormat;
            this.IsDefaultData_EncodeType = encodeType;
            this.IsDefaultData_AppendMode = appendMode;
            this.IsDefaultData_AddTextHeder = addTextHeder;

            return;
        }


        #endregion �v���p�e�B


        private void InitProc()
        {
            CustomTextProviderInfo tmp = CustomTextProviderInfo.GetDefaultInfo();
            this.AddTextHeder = tmp.AddTextHeder;
            this.OutPutFileName = tmp.OutPutFileName;
            this.OutPutFolderName = tmp.OutPutFolderName;
            this.SchemaFileName = tmp.SchemaFileName;
            this.TextFormat = tmp.TextFormat;
            this.TextKind = tmp.TextKind;
            this.AppendMode = tmp.AppendMode;

            return;
        }



        static public CustomTextProviderInfo GetDefaultInfo()
        {
            CustomTextProviderInfo tmp = new CustomTextProviderInfo();

            //--- �ݒ��񏉊���
            tmp.TextKind = CustomTextKinds.CSV;         // �e�L�X�g���
            tmp.TextFormat = CustomTextFormats.TEXT;  // �o�C�i���`��
            tmp.EncodeType = System.Text.Encoding.Default;  // �����R�[�h(�o�̓G���R�[�h�w�� SJIS, UTF-8��)

            // �o�͎��Í����L��
            
            tmp.SchemaFileName = "";                        // �X�L�[�}�t�@�C����
            tmp.OutPutFileName = "";                        // �t�@�C����
            tmp.OutPutFolderName = System.IO.Directory.GetCurrentDirectory();                      // �t�@�C���쐬�t�H���_
//            tmp.outPutFolderName = "";                      // �t�@�C���쐬�t�H���_
            tmp.AddTextHeder = false;                       // �w�b�_���t���敪
            tmp.AppendMode = false;

            return tmp;

        }
 

    }

    /// <summary>
    /// �e�L�X�g�o�̓T�[�r�X �X�e�[�^�X
    /// </summary>
    public enum CustomTextProviderStatus
    {
        JOB_SUCCESS,        // ��������    
        NOTHING_DATA,       // �Ώۃf�[�^����
        PROTECTED_ERROER,   // �e�L�X�g���ΏۊO
        EXCEPTION_ERROER    // ��O�G���[ 
    }

    /// <summary>
    /// �e�L�X�g���
    /// </summary>
    public enum CustomTextKinds
    {
        CSV,                // CSV�`��
        FIXED_LENGTH,       // �Œ蒷�e�L�X�g
        XML,                // XML�`��        
        XML_WITH_SCHEMA,    // XML�`��(�X�L�[�}��`�t��)
        MSOffice_XML        // MS Office XML�`��
    }

    /// <summary>
    /// �e�L�X�g��o�C�i���`���敪
    /// </summary>
    public enum CustomTextFormats
    {
        TEXT,               // �e�L�X�g�`��
        BINARY              // �o�C�i���`��
    }


    /// <summary>
    /// �e�L�X�g�o�̓c�[�����C�u����
    /// </summary>
    /// <remarks>
    /// <br>Note       : �e�L�X�g�o�ͥ���͂Ɋ֘A����e��c�[����T�[�r�X���</br>
    /// <br>Programmer : R.Sokei</br>
    /// <br>Date       : 2006.04.21</br>
    /// </remarks>
    public class CustomTextTool
    {

        public CustomTextTool()
        {

        }


        /// <summary>
        /// �N���X���X�g(�z��)-->DataSet�ϊ��A�R�s�[
        /// </summary>
        /// <param name="source">����ΏۃI�u�W�F�N�g</param>
        /// <param name="retDataSet">�ϊ���DataSet</param>
        /// <returns>�������� 0:��������, 4:�Ώۃf�[�^�Ȃ�, -9:�o�͑ΏۊO�̃f�[�^���w�肳�ꂽ, -1:���̑��G���[</returns>
        /// <remarks>
        /// <br>Note       : �N���X���X�g(�z��)-->DataSet</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        static public int ClassArrayToDataSet(object source, ref DataSet retDataSet)
        {
            int st = 4;

            if (source != null)
            {

                // �f�[�^�\�[�X(����ΏۃI�u�W�F�N�g)��ArrayList�ɓ���Ȃ���
                ArrayList alSource;
                if (source is ArrayList)
                {
                    alSource = (ArrayList)source;
                }
                else if (source is Array)
                {
                    alSource = new ArrayList((Array)source);
                }
                else
                {
                    alSource = new ArrayList();
                    alSource.Add(source);
                }

                // �N���X�^�C�v���擾
                Type workClassType = ((ArrayList)alSource)[0].GetType();

                // �v���p�e�B���擾
                PropertyInfo[] propInfo = workClassType.GetProperties();
                object obj = null;
                bool needDefaultDataSet = false;
                ArrayList alIndex = new ArrayList();
                Hashtable hs = new Hashtable();

                if (retDataSet == null)
                {
                    // �]�L��DataSet����̏ꍇ�̓N���X������ɋ�DataSet���쐬����                
                    retDataSet = new DataSet();
                    retDataSet.Tables.Add("DefaultTable1");
                    needDefaultDataSet = true;
                }
                else
                {
                    // �]�L��DataSet���w�肳��Ă���ꍇ�́A�񖼔���p��HashTable���쐬����                

                    foreach (DataColumn col in retDataSet.Tables[0].Columns)
                    {
                        hs.Add(col.ColumnName, col.Caption);
                    }
                }


                TransportIndexClasstoDataSet tIndex;
                int cnt = 0;

                // �]�L�ΏۃN���X�v���p�e�B��Data�Z�b�g��̃}�b�s���O�C���f�b�N�X�̍쐬
                foreach (PropertyInfo prop in propInfo)
                {
                    if (needDefaultDataSet)
                    {
                        retDataSet.Tables[0].Columns.Add(prop.Name, prop.PropertyType);
                        tIndex = new TransportIndexClasstoDataSet(cnt, prop.Name);
                        alIndex.Add(tIndex);
                    }
                    else if (hs.ContainsKey(prop.Name))
                    {
                        tIndex = new TransportIndexClasstoDataSet(cnt, prop.Name);
                        alIndex.Add(tIndex);
                    }

                    cnt++;
                }

              
                // �N���X���X�g��DataSet�֓]������
                PropertyInfo propInf;
                DataRow dr;
                if (alIndex.Count > 0)
                {
          
                    foreach (object sourceDtl in (ArrayList)alSource)
                    {
                        // DataSet�V�K�s�̍쐬
                        dr = retDataSet.Tables[0].NewRow();

                        foreach (TransportIndexClasstoDataSet tiIndex in alIndex)
                        {
                            propInf = propInfo[tiIndex.SourcePropIndex];
                            obj = propInf.GetValue(sourceDtl, null);

                            if (obj != null)
                            {
                                dr[tiIndex.EditColKey] = obj;
                            }
                            else
                            {
                                dr[tiIndex.EditColKey] = DBNull.Value;
                            }
                        }

                        retDataSet.Tables[0].Rows.Add(dr);
                    }
                }
            }

            return st;        
        
        }


        /// <summary>
        /// DataSet�f�[�^�l-->XMLSchema�`���e�L�X�g�o��
        /// </summary>
        /// <param name="source">����ΏۃI�u�W�F�N�g</param>
        /// <param name="schemaPath">�X�L�[�}�t�@�C���p�X</param>
        /// <returns>�������� 0:��������, 4:�Ώۃf�[�^�Ȃ�, -9:�o�͑ΏۊO�̃f�[�^���w�肳�ꂽ, -1:���̑��G���[</returns>
        /// <remarks>
        /// <br>Note       : DataSet�f�[�^�l-->�e�L�X�g�o��</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        static public int DataSetToXMLSchema(DataSet source, string outputFilePath)
        {
            int st = 0;
            string text = "";
            StringBuilder strBuilder;
            StringBuilder allText = new StringBuilder();

            if (source.Tables.Count.Equals(0))
            {

                // �o�͑Ώۃf�[�^�����݂��Ȃ�
                st = 4;
            }
            else
            {
                // �f�[�^�e�[�u���̊e����(�w�b�_���)���o�͂���

                string headerStr;
                strBuilder = new StringBuilder();

                strBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
                strBuilder.AppendLine("<TextServiceSchema>");
                strBuilder.AppendLine("<!-- �X�L�[�}�t�@�C���̏��  -->");
                strBuilder.AppendLine("<SchemaInfoDef>");
                strBuilder.AppendLine("<SchemaName></SchemaName>");
                strBuilder.AppendLine("<SchemaFileName></SchemaFileName>");
                strBuilder.AppendLine("<Writer></Writer>");
                strBuilder.AppendLine("<Date>" + DateTime.Today.ToString("d") + "</Date>");
                strBuilder.AppendLine("<Version></Version>");
                strBuilder.AppendLine("</SchemaInfoDef>");
                strBuilder.AppendLine("<!--  �o�̓t�@�C���̐ݒ�  -->");
                strBuilder.AppendLine("<FileInfoDef>");
                strBuilder.AppendLine("<OutPutFileName></OutPutFileName>");
                strBuilder.AppendLine("<OutPutDir></OutPutDir>");
                strBuilder.AppendLine("<EncodeType>SJIS</EncodeType>");
                strBuilder.AppendLine("<Formatter>Text</Formatter>");
                strBuilder.AppendLine("<Encryption>false</Encryption>");
                strBuilder.AppendLine("<CipherType>Default</CipherType>");
                strBuilder.AppendLine("<OutputHeader>true</OutputHeader>");
                strBuilder.AppendLine("</FileInfoDef>");
                strBuilder.AppendLine("<!-- �o�͏��ݒ�  -->");
                strBuilder.AppendLine("<ColInfoDef>");


                foreach (System.Data.DataColumn dtl in source.Tables[0].Columns)
                {

                    if (dtl.ColumnName != null)
                    {
                        strBuilder.AppendLine("<ColInfo key=\"" + dtl.ColumnName + "\">");
                        strBuilder.AppendLine("<ColKey>" + dtl.ColumnName + "</ColKey>");
                        strBuilder.AppendLine("<ColName></ColName>");
                        strBuilder.AppendLine("<ColWidth></ColWidth>");
                        strBuilder.AppendLine("<ColDataType>" + dtl.DataType.ToString() + "</ColDataType>");
                        strBuilder.AppendLine("</ColInfo>");
                    }

                }

                strBuilder.AppendLine("</ColInfoDef>");
                strBuilder.AppendLine("</TextServiceSchema>");
                headerStr = strBuilder.ToString();

                // �f�[�^�e�[�u���̊e�s�����o�͂���
                allText.AppendLine(headerStr);
            }

            text = allText.ToString();

            if ((text != null) && (text != ""))
            {
                MakeTextFile(text, ref outputFilePath, 0, System.Text.Encoding.UTF8);
            }


            return st;

        }


        static private int MakeTextFile(string source, ref string outputFilepath, int cipherMode, System.Text.Encoding enCode)
        {
            int st = 0;

            if ((outputFilepath != null) && (outputFilepath.Trim() != ""))
            {
                // �e�L�X�g�u������


            }
            else
            {
                // �o�̓t�@�C�����̐���
                outputFilepath = Guid.NewGuid().ToString() + ".xml";
            }

            // Shift JIS �R�[�h�ŏ����o��
            System.IO.StreamWriter writer =
                new System.IO.StreamWriter(outputFilepath, false,
                    enCode);
            writer.WriteLine(source);
            writer.Close();

            return st;
        }


        class TransportIndexClasstoDataSet
        {
            public int SourcePropIndex;
            public string EditColKey;

            public TransportIndexClasstoDataSet()
            {


            }

            public TransportIndexClasstoDataSet(int sourcePropIndex, string editColKey)
            {
                SourcePropIndex = sourcePropIndex;
                EditColKey = editColKey;
            }

        }

    }

}
