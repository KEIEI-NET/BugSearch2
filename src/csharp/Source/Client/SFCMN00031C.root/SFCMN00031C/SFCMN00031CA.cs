using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections;
using System.Text;
using System.Data;
using System.Xml;
using System.IO;

namespace Broadleaf.Library.Text
{

    //************************************************************
    //
    //  ���̃\�[�X�t�@�C���ɂ́u�e�L�X�g���o��(�O������J�N���X)�v
    // �Ɋ֘A����N���X, �e���`����������Ă��܂�
    //
    //************************************************************


    /// <summary>
    /// �e�L�X�g���o�̓N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �e�L�X�g�o�ͥ���͏�����{�N���X</br>
    /// <br>Programmer : R.Sokei</br>
    /// <br>Date       : 2006.04.21</br>
	/// <br>Update Date: �@ 2007.06.26 ���c�@�`�� (20015)
	///                :    �ǉ����[�h�ł̏o�͎��A�w�b�_���o�͂���Ă����̂ŁAPegasus�Ɠ��l�ɒǉ�����
	///                :    �w�b�_���o�͂��Ȃ��悤�ɕύX
    /// </br>
    /// <br>Update Note: 2011/08/15  �A��923 ���X��</br>
    /// <br>            : �i�Ԃ�i���� "(����ٺ�ð���)���܂܂��ƁA���߰Ď��ɃG���[�ɂȂ�ׂ̑Ή�</br>
    /// <br>Update Note: 2011/08/17  �A��923 ���X��</br>
    /// </br>            : �������ڂ�"�Ŋ���K�v�͂���܂���A�����񍀖ڂ̂�""�Ŋ����Ă̑Ή�</br>
	/// </remarks>
    internal class CustomTextProvider
    { 
    

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�ͥ���̓N���X �R���X�g���N�^</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public CustomTextProvider()
        {
            InitProc();
        }


        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="source">����ΏۃI�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�ͥ���̓N���X �R���X�g���N�^</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public CustomTextProvider(object source)
        {
            InitProc();
        }

        private void InitProc()
        {
            _ColInfoList = new Hashtable();
            _IsExistsSchemaFile = false;

            return;
        }


        // �v���p�e�B

        private Hashtable _ColInfoList;
        private bool _IsExistsSchemaFile;

        // ���쑮���Z�b�g


        // �X�L�[�}��͊֘A(�X�L�[�}�t�@�C���̉��)


        // �e�L�X�g�o�͊֘A


        // �e�L�X�g���͊֘A


        // �e�L�X�g�ҏW�֘A


        // �Í�����������֘A


        // �N���X���
        /// <summary>
        /// �N���X�����o�l-->�e�L�X�g�o��
        /// </summary>
        /// <param name="source">����ΏۃI�u�W�F�N�g</param>
        /// <param name="schemaPath">�X�L�[�}�t�@�C���p�X</param>
        /// <param name="text">�����e�L�X�g</param>
        /// <remarks>
        /// <br>Note       : �N���X�����o�l-->�e�L�X�g�o��</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public int ClassMemberToText(object source, out string text, CustomTextProviderInfo textInfo)
        {

            int st = 0;
            text = "";
            if (source != null)
            {
                ArrayList colInfoNumberList = null;

                // �N���X�^�C�v���擾
                Type workClassType = ((ArrayList)source)[0].GetType();

                // �e�L�X�g�T�[�r�X�Ώۂ̑����������Ă��邩�`�F�b�N����
                string protectType;
                if (HasTextServiceSerializationAttribute(workClassType, out protectType))
                {
                    DataSet retDataSet = null;
                    // �X�L�[�}�t�@�C�����w�肳��Ă���ꍇ�͕ҏW�pDataSet���쐬����
                    if (textInfo.SchemaFileName.Trim() != "")
                    {
                        // �ҏW�p�f�[�^�Z�b�g�̍쐬
                        MakeEditDataSet(source, textInfo.SchemaFileName, out retDataSet, out colInfoNumberList);
                    }

                    
                    // �N���X���X�g --> DataSet�ϊ�
                    CustomTextTool.ClassArrayToDataSet(source, ref retDataSet);
                    st = DataSetToText(retDataSet, out text, textInfo, colInfoNumberList);

                }
                else
                {
                    st = -9;  // �o�͑ΏۊO�̃N���X���w�肳�ꂽ
             
                }

            }

            return st;        
        }


        /// <summary>
        /// DataSet�f�[�^�l-->�e�L�X�g�o��
        /// </summary>
        /// <param name="source">����ΏۃI�u�W�F�N�g</param>
        /// <param name="schemaPath">�X�L�[�}�t�@�C���p�X</param>
        /// <param name="text">�����e�L�X�g</param>
        /// <remarks>
        /// <br>Note       : DataSet�f�[�^�l-->�e�L�X�g�o��</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public int DataSetToText(DataSet source, out string text, CustomTextProviderInfo textInfo)
        { 
            ArrayList colInfoNumberList = null;
            return DataSetToText(source, out text, textInfo, colInfoNumberList);
        }

        /// <summary>
        /// DataSet�f�[�^�l-->�e�L�X�g�o��
        /// </summary>
        /// <param name="source">����ΏۃI�u�W�F�N�g</param>
        /// <param name="schemaPath">�X�L�[�}�t�@�C���p�X</param>
        /// <param name="text">�����e�L�X�g</param>
        /// <remarks>
        /// <br>Note       : DataSet�f�[�^�l-->�e�L�X�g�o��</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// <br>Update Note: 2011/08/17  �A��923 ���X��</br>
        /// <br>            : �������ڂ�"�Ŋ���K�v�͂���܂���A�����񍀖ڂ̂�""�Ŋ����Ă̑Ή�</br>
        /// </remarks>
        public int DataSetToText(DataSet source, out string text, CustomTextProviderInfo textInfo, ArrayList colInfoNumberList)
        {

            int st = 0;
            text = "";
            StringBuilder strBuilder;
            StringBuilder allText = new StringBuilder();

            if (colInfoNumberList == null)
            {
                colInfoNumberList = new ArrayList();
            }

            if (source.Tables.Count.Equals(0))
            {

                // �o�͑Ώۃf�[�^�����݂��Ȃ�
                st = 4;
            }
            else
            {
                DataSet editDataSet = null;
                string headerStr;


                // �ҏW�p�f�[�^�Z�b�g�̍쐬
                st = MakeEditDataSet(source, textInfo.SchemaFileName, out editDataSet, out colInfoNumberList);

                // �f�[�^�e�[�u���̊e����(�w�b�_���)���o�͂���

                strBuilder = new StringBuilder();
                //                foreach (System.Data.DataColumn dtl in source.Tables[0].Columns)

                if (editDataSet != null)
                {
					// �ǉ����[�h�̏ꍇ�́A�w�b�_�͒ǉ����Ȃ�
					if (textInfo.AppendMode == false)											// 2007.06.26 ���c Add ���ǉ��o�͎��w�b�_�����Ή�
					{
						foreach (System.Data.DataColumn dtl in editDataSet.Tables[0].Columns)
						{

							if (strBuilder.Length > 0)
							{
								strBuilder.Append(",");
							}

							if (dtl.Caption != null)
							{
								strBuilder.Append("\"");
								strBuilder.Append(dtl.Caption);
								strBuilder.Append("\"");
							}
							else
							{
								strBuilder.Append("\"");
								strBuilder.Append("\"");
							}

						}

						headerStr = strBuilder.ToString();

						// �f�[�^�e�[�u���̊e�s�����o�͂���
						allText.AppendLine(headerStr);
					}

					int colCnt = editDataSet.Tables[0].Columns.Count;

                    foreach (System.Data.DataRow row in editDataSet.Tables[0].Rows)
                    {

                        strBuilder = new StringBuilder();
                        for (int idx = 0; idx < colCnt; idx++)
                        {


                            if (strBuilder.Length > 0)
                            {
                                strBuilder.Append(",");
                            }

                            if (row[idx] != null)
                            {
                                if (((TextColInfo)colInfoNumberList[idx]).ColDataType == "System.String")  //ADD by Liangsd     2011/08/17
                                {
                                    strBuilder.Append("\"");
                                }
                                string strTmp = "";


                                int textWidth = 0;
                                if (colInfoNumberList.Count > idx)
                                {

                                    // �o�̓T�C�Y�̎擾
                                    textWidth = ((TextColInfo)colInfoNumberList[idx]).ColWidth;

                                    // �f�[�^�R���o�[�g���@�A�ҏW�����w�肳��Ă���΂����ŕҏW���s��
                                    if ((((TextColInfo)colInfoNumberList[idx]).DataConvert == "") && (((TextColInfo)colInfoNumberList[idx]).EditMode == 0))
                                    {
                                        // �f�[�^�R���o�[�g���@�A�ҏW�����w�肳��Ă��Ȃ��ꍇ�͂��̂܂܏o��
                                        strTmp = row[idx].ToString();
                                    }
                                    else
                                    {
                                        object obj = null;
                                        if (((TextColInfo)colInfoNumberList[idx]).DataConvert != "")
                                        {
                                            // �w�肳�ꂽ�����Ńf�[�^�R���o�[�g�����s
                                            //                                    strTmp = strBuilder.Append(row[idx].ToString());
                                            obj = ConvertData(((TextColInfo)colInfoNumberList[idx]).DataConvert, row[idx]);
                                            if (obj != null)
                                            {
                                                strTmp = obj.ToString();
                                            }
                                        }


                                        if (((TextColInfo)colInfoNumberList[idx]).EditMode != 0)
                                        {
                                            // �w�肳�ꂽ�ҏW��������
                                            strTmp = row[idx].ToString();

                                        }


                                        //                                strTmp = strBuilder.Append(row[idx].ToString());
                                    }
                                }
                                else
                                {
                                    strTmp = row[idx].ToString();
                                }

                                // �w�肳�ꂽ�T�C�Y�ɕ������ҏW
                                if (textWidth > 0)
                                {
                                    if (textWidth < strTmp.Length)
                                    {
                                        strTmp = strTmp.Substring(0, textWidth);
                                    }
                                }

                                strBuilder.Append(strTmp);
                                if (((TextColInfo)colInfoNumberList[idx]).ColDataType == "System.String")//ADD by Liangsd     2011/08/17
                                {
                                    strBuilder.Append("\"");
                                }
                            }
                            else
                            {
                                if (((TextColInfo)colInfoNumberList[idx]).ColDataType == "System.String")//ADD by Liangsd     2011/08/17
                                {
                                    strBuilder.Append("\"");
                                    strBuilder.Append("\"");
                                }
                            }

                        }

                        if (strBuilder.Length > 0)
                        {
                            allText.AppendLine(strBuilder.ToString());
                        }

                    }

                }

            }

            text = allText.ToString();
            return st;
        }

        private object ConvertData(string convertFormat, object source)
        {
            object obj = source;
            string strTmp = null;
            int    numTmp = 0;

            switch (convertFormat.ToUpper())
            {
                case "DATETIMETOINT_YYYYMMDD":
                    {
                        if (source is DateTime)
                        {
                            if (((DateTime)source) == DateTime.MinValue)
                            {
                                numTmp = 0;
                            }
                            else
                            {
                                numTmp = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate((DateTime)source);
                            }
                            obj = numTmp;
                        }
                    }
                    break;
                case "DATETIMETOINT_YYYYMM":
                    {
                        if (source is DateTime)
                        {

                            if (((DateTime)source) == DateTime.MinValue)
                            {
                                numTmp = 0;
                            }
                            else
                            {
                                numTmp = Broadleaf.Library.Globarization.TDateTime.DateTimeToLongDate("YYYYMM", (DateTime)source);
                            }

                            obj = numTmp;
                        }
                    }
                    break;
                case "DATETIMETOSTRING_YYYYMMDD":
                    {
                        if (source is DateTime)
                        {
                            strTmp = Broadleaf.Library.Globarization.TDateTime.DateTimeToString("YYYYMMDD", (DateTime)source);
                            obj = strTmp;
                        }
                    }
                    break; 
                case "DATETIMETOSTRING_YYYYMM":
                    {
                        if (source is DateTime)
                        {
                            strTmp = Broadleaf.Library.Globarization.TDateTime.DateTimeToString("YYYYMMDD", (DateTime)source);
                            obj = strTmp;
                        }
                    }
                    break;

                default:
                    {
                        obj = source;
                        break;
                    }
            }

//            case convertFormat

            return obj;
        }



        /// <summary>
        /// �e�L�X�g�o�͑����`�F�b�N
        /// </summary>
        /// <param name="type">�ΏۃI�u�W�F�N�g</param>
        /// <param name="protectType">�e�L�X�g�o�͑���</param>
        /// <remarks>
        /// <br>Note       : �e�L�X�g�o�͑����������Ă��邩�ǂ����`�F�b�N���Ď擾����������Ԃ�</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        private bool HasTextServiceSerializationAttribute(Type type, out string protectType)
        {
            protectType = "";
            bool st = false;

            Attribute[] attributes = Attribute.GetCustomAttributes(type);
            foreach (Attribute att in attributes)
            {
                if (att is TextServiceSerializationAttribute)
                {
                    protectType = ((TextServiceSerializationAttribute)att).ProtectType;
                    st = true;
                    break;
                }            
            }
        
            return st;
        }



        //private int MakeEditDataSet(object source, string schemaPath, out DataSet editDataSet)
        //{
        //    Hashtable colInfoList = null;
        //    ArrayList colInfoNumberList = null;

        //    return MakeEditDataSet(source, schemaPath, out editDataSet, out colInfoList, out colInfoNumberList);
        
        //}


        private int MakeEditDataSet(object source, string schemaPath, out DataSet editDataSet, out ArrayList colInfoNumberList)
        {
            editDataSet = null;
            colInfoNumberList = null;
            if (source == null)
            {
                return 4;
            }            
            
            CustomTextProviderInfo customTextProviderInfo;
            Hashtable colInfoList = null;
//            ArrayList colInfoNumberList = null;
            bool isSuccess = false;

            CustomTextProviderInfo customTextProviderInfoUserDef;
            Hashtable colInfoListUserDef = null;
            ArrayList colInfoNumberListUserDef = null;

            int st   = ReadSchemaInfo(schemaPath, out customTextProviderInfo, out colInfoList, out colInfoNumberList);
            int stEx = ReadCustomSchemaInfo(schemaPath, out customTextProviderInfoUserDef, out colInfoListUserDef, out colInfoNumberListUserDef);

            // ���[�U��`�X�L�[�}�t�@�C�������݂���Ƃ��́A���[�U��`�Ɋ�Â��ăX�L�[�}����ҏW����
            if (st.Equals(0) && stEx.Equals(0))
            { 

                // �񋟃X�L�[�}�t�@�C���̓��e�����[�U��`�ŏ㏑������
                UpdateSchemaInfoByCustomSchemaInfo(ref customTextProviderInfo, ref colInfoList, ref colInfoNumberList, customTextProviderInfoUserDef, colInfoListUserDef, colInfoNumberListUserDef);

            }


            if (st.Equals(0)) 
            {
                if ((colInfoNumberList != null) && (colInfoNumberList.Count > 0))
                {
                    editDataSet = new DataSet();
                    editDataSet.Tables.Add("EditDataTable1");
                    // �X�L�[�}��`�t�@�C�������݂���΃t�@�C���̐ݒ�����DataSet�𐶐�����
                    foreach (TextColInfo colInfo in colInfoNumberList)
                    {
                        DataColumn dc = editDataSet.Tables[0].Columns.Add(colInfo.ColKey, Type.GetType(colInfo.ColDataType));
                        dc.Caption = colInfo.ColName;

                        // �f�t�H���g�l�̐ݒ�
                        switch (colInfo.ColDataType)
                        {
                            case "System.Int32":
                                dc.DefaultValue = 0;
                                break;
                            case "System.String":
                                dc.DefaultValue = "";
                                break;
                            case "System.Int64":
                                dc.DefaultValue = 0;
                                break;
                            case "System.Double":
                                dc.DefaultValue = 0.0d;
                                break;
                            default:
                                break;
                        }
                        
                        dc.Unique = false;
                    }

                    isSuccess = true;
                }
            }

            if (!isSuccess)
            {

                if (source is DataSet)
                {
                    // �X�L�[�}��`�����݂��Ȃ�&�\�[�X�� DataSet �̏ꍇ
                    // �f�[�^�Z�b�g�̃R�s�[�𐶐����ĕԂ�
                    if (schemaPath.Trim().Equals(""))
                    {
                        editDataSet = ((DataSet)source).Copy();
                    }
                    else
                    {
                        // �X�L�[�}�t�@�C���̃p�X���w�肵�Ă��邪�A�t�@�C�����Ǎ��߂Ȃ��ꍇ�̓e�L�X�g�o�͂��Ȃ�
                        editDataSet = null;

                        // �X�L�[�}�t�@�C�������݂��Ȃ�
                        st = 21;
                    }
                }
                else 
                {
                    // �X�L�[�}��`�����݂��Ȃ�&�\�[�X�� Class �̏ꍇ
                    // �N���X�̃����o��DataSet�֓]�L���ĕԂ�
                 


                }
            }

//            System.Windows.Forms.MessageBox.Show(st.ToString());

            // �\�[�X����ҏW�p�f�[�^�Z�b�g�փf�[�^���R�s�[����
            if (editDataSet != null)
            {
                ArrayList indexList = new ArrayList();

                if (source is DataSet)
                {
                    DataSet tmpDs = (DataSet)source;
                    // �]�L�p�C���f�b�N�X�̍쐬
                    foreach (DataColumn col in tmpDs.Tables[0].Columns)
                    {
                        if (colInfoList.ContainsKey(col.ColumnName))
                        {

                            TransportIndexForDataSet Tds = new TransportIndexForDataSet(col.Ordinal, col.ColumnName);
                            indexList.Add(Tds);
                        }

                    }

                    // �]�L�p�C���f�b�N�X�̓��e�ɏ]���� source --> editDataSet �փf�[�^��]�L����
                    if (indexList.Count > 0)
                    {
                        DataRow editRow;

                        foreach (DataRow row in ((DataSet)source).Tables[0].Rows)
                        {

                            editRow = editDataSet.Tables[0].NewRow();
                            foreach (TransportIndexForDataSet tsIndex in indexList)
                            {
                                //editRow[tsIndex.EditColKey] = row[tsIndex.SourceColIndex];                                 //DEL by Liangsd     2011/08/15  
                                editRow[tsIndex.EditColKey] = ConvertString(row[tsIndex.SourceColIndex]);        //ADD by Liangsd     2011/08/15
                            }
                            editDataSet.Tables[0].Rows.Add(editRow);
                        }


                        st = 0;
                    }
                }

            }
            else
            {
                if (st.Equals(0))
                    st = 4;
            }

            return st;
        }

        //ADD by Liangsd   2011/08/15----------------->>>>>>>>>>
        /// <summary>
        /// ���ʂȕ�����̕ϊ�
        /// </summary>
        /// <param name="str">���C�O�̕�����</param>
        /// <returns>���C��̕�����</returns>
        /// <remarks>
        /// <br>Note        : ���ʂȕ�����̕ϊ����s��</br>
        /// <br>Programmer  : Liangsd</br>
        /// <br>Date        : 2011/08/15</br>
        /// </remarks>
        private string ConvertString(object obj)
        {
            string res = obj.ToString();
            // ������̏ꍇ
            if (obj is string)
            {
                if (obj.ToString().Contains("\""))
                {
                    res = obj.ToString().Replace("\"", "\"\"");
                }
            }
            return res;
        }
        //ADD by Liangsd   2011/08/15-----------------<<<<<<<<<<

        private int CopyDtataTable(DataSet source, DataSet target)
        {
            // DataSet�̃f�[�^�e�[�u�����̃f�[�^���R�s�[����



            return 0;
        }


        #region �X�L�[�}���擾

        /// <summary>
        /// �X�L�[�}���擾
        /// </summary>
        /// <param name="schemaPath">�X�L�[�}�t�@�C���p�X</param>
        /// <param name="customTextProviderInfo">�X�L�[�}���(�ԋp�l)</param>
        /// <returns>�������� 0:�擾����, -1:�擾�G���[</returns>
        /// <remarks>
        /// <br>Note       : �X�L�[�}�t�@�C���̏����擾���� customTextProviderInfo �֕Ԃ��܂�</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public int ReadSchemaInfo(string schemaPath, out CustomTextProviderInfo customTextProviderInfo)
        { 
            Hashtable ht;
            ArrayList al;
            return ReadSchemaInfo(schemaPath, out customTextProviderInfo, out ht, out al);
        }

        private int ReadSchemaInfo(string schemaPath, out CustomTextProviderInfo customTextProviderInfo, out Hashtable colInfoList, out ArrayList colInfoNumberList)
        {
            customTextProviderInfo = CustomTextProviderInfo.GetDefaultInfo();
            Hashtable ht = new Hashtable();
            ArrayList al = new ArrayList();

            int st = -1;
            bool IsSchemaError = true;
            

            // �X�L�[�}�t�@�C���ǂݍ���
//            string path = MakeFilePath(0, customTextProviderInfo.outPutFolderName, customTextProviderInfo.outPutFileName);
            string path = schemaPath;
            bool existFile = false;
            if (System.IO.File.Exists(path))
            {
                existFile = true;
            }
            else
            {
                string lFileName = System.IO.Path.GetFileName(path);

                if (System.IO.File.Exists(lFileName))
                {
                    existFile = true;
                    path = lFileName;
                }            
            }


            if(existFile)
            {

           		XmlDocument _xmlDoc = null;
                bool _xPathDocEnable = false;

                // �o�̓t�@�C���̐ݒ�擾
                try
                {
                    _xmlDoc = new XmlDocument();
//                    _xmlDoc.Load(path);
                    _xmlDoc.LoadXml(ReadXMLFile(path));
                    _xPathDocEnable = true;
                }
                catch (FileNotFoundException e)
                {
                    System.Windows.Forms.MessageBox.Show(e.StackTrace);
                }
                catch (XmlException e)
                {
                    System.Windows.Forms.MessageBox.Show(e.StackTrace);
                }

                // �K�C�h�ݒ�t�@�C���̓Ǎ�
                if (_xPathDocEnable)
                {
                    #region �e�L�X�g�o�̓t�@�C���Ɋւ���ݒ�
                    XmlElement xmlElem = _xmlDoc.DocumentElement;
                    XmlElement xmlElem2;
//                    int numTmp = 0;

                    // �t�H�[�����b�Z�[�W
                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/OutPutFileName");
                    if (!(xmlElem2 == null))
                    {
                        customTextProviderInfo.OutPutFileName = xmlElem2.InnerText;
                    }

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/OutPutDir");
                    if (!(xmlElem2 == null))
                    {
                        customTextProviderInfo.OutPutFolderName = xmlElem2.InnerText;
                    }

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/TextKind");
                    if (!(xmlElem2 == null))
                    {
                        SetTextKinds(ref customTextProviderInfo, xmlElem2.InnerText);
                    }

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/EncodeType");
                    if (!(xmlElem2 == null))
                    {
                        SetEncodeType(ref customTextProviderInfo, xmlElem2.InnerText);
                    }

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/Formatter");
                    if (!(xmlElem2 == null))
                    {
                        SetTextFormats(ref customTextProviderInfo, xmlElem2.InnerText);
                    }

                    //xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/Encryption");
                    //if (!(xmlElem2 == null))
                    //{
                    //    customTextProviderInfo.e = xmlElem2.InnerText;
                    //}

                    //xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/CipherType");
                    //if (!(xmlElem2 == null))
                    //{
                    //    customTextProviderInfo = xmlElem2.InnerText;
                    //}

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/OutputHeader");
                    if (!(xmlElem2 == null))
                    {
                        if (xmlElem2.InnerText.Trim().ToUpper() == "TRUE")
                            customTextProviderInfo.AddTextHeder = true;
                        else
                            customTextProviderInfo.AddTextHeder = false;

                    }
                    #endregion �e�L�X�g�o�̓t�@�C���Ɋւ���ݒ�

                    #region �o�͏��̐ݒ�
                    XmlNodeList nodeList;
                    XmlNodeList nodeListChild;

                    nodeList = xmlElem.SelectNodes("/TextServiceSchema/ColInfoDef/ColInfo");
                    int idx = 0;
                    foreach (XmlNode isbn in nodeList)
                    {
                        string lColKey = "";
                        string lColName = "";
                        string lColType = "";
                        int lColWidth = 0;
                        int lColEditMode = 0;
                        string lColDataConvert = "";

                        nodeListChild = isbn.ChildNodes;

                        foreach (XmlElement iElem in nodeListChild)
                        {
                            if (!(iElem == null))
                            {

                                switch (iElem.Name)
                                {
                                    case "ColKey":
                                        lColKey = iElem.InnerText;
                                        break;
                                    case "ColName":
                                        lColName = iElem.InnerText;
                                        break;
                                    case "ColDataType":
                                        {
                                            switch (iElem.InnerText.ToUpper())
                                            {
                                                case "STRING":
                                                    lColType = "System.String";
                                                    break;
                                                case "INT32":
                                                    lColType = "System.Int32";
                                                    break;
                                                case "INT":
                                                    lColType = "System.Int32";
                                                    break;
                                                case "INT64":
                                                    lColType = "System.Int64";
                                                    break;
                                                case "LONG":
                                                    lColType = "System.Int64";
                                                    break;
                                                case "DOUBLE":
                                                    lColType = "System.Double";
                                                    break;
                                                case "GUID":
                                                    lColType = "System.Guid";
                                                    break;
                                                case "DATETIME":
                                                    lColType = "System.DateTime";
                                                    break;
                                                case "INTEGER":
                                                    lColType = "System.Int32";
                                                    break;
                                                default:
                                                    lColType = iElem.InnerText;
                                                    break;
                                            }
                                        }
                                        break;
                                    case "ColWidth":
                                        if (iElem.InnerText.Trim() != "")
                                        {
                                            lColWidth = Convert.ToInt32(iElem.InnerText);
                                        }
                                        else
                                        {
                                            lColWidth = 0;
                                        }
                                        break;
                                    case "ColEditMode":
                                        if (iElem.InnerText.Trim() != "")
                                        {
                                            lColEditMode = Convert.ToInt32(iElem.InnerText);
                                        }
                                        else
                                        {
                                            lColEditMode = 0;
                                        }
                                        break;

                                    case "ColDataConvert":
                                        if (iElem.InnerText.Trim() != "")
                                        {
                                            lColDataConvert = iElem.InnerText;
                                        }
                                        break;
                                        
                                    default:
                                        break;
                                }
                            }
                        }

                        if ((!(lColKey == "")) && (!(lColName == "")))
                        {
                            TextColInfo txinf = new TextColInfo(idx, lColKey, lColName, lColWidth, lColType, lColEditMode, lColDataConvert);

                            ht.Add(txinf.ColKey, txinf);
                            al.Add(txinf);
                            idx++;
                        }

                    }

                    #endregion �o�͏��̐ݒ�
                    IsSchemaError = false;
                    st = 0;
                }
                else
                {
                    // �X�L�[�}�t�@�C������荞�߂Ȃ������ꍇ    
                    IsSchemaError = true;
                    st = -1;
                }

            }


            // ���s�����ꍇ�̓Z�L�����e�B�֘A�̐ݒ��MAX�ɐݒ肷��
            if (IsSchemaError)
            {
                customTextProviderInfo.AddTextHeder = false;
                st = -1;
            }

            colInfoList = ht;
            colInfoNumberList = al;
            return st;
        }

        #endregion �X�L�[�}���擾


        #region �X�L�[�}(���[�U��`)���擾

        /// <summary>
        /// �X�L�[�}(���[�U��`)���擾
        /// </summary>
        /// <param name="schemaPath">�I���W�i���X�L�[�}�t�@�C���p�X</param>
        /// <param name="customTextProviderInfo">�X�L�[�}���(�ԋp�l)</param>
        /// <returns>�������� 0:�擾����, -1:�擾�G���[</returns>
        /// <remarks>
        /// <br>Note       : �X�L�[�}�t�@�C���̏����擾���� customTextProviderInfo �֕Ԃ��܂�</br>
        /// <br>           : originalSchemaPath����Ƀ��[�U��`�X�L�[�}�t�@�C���p�X�������I�ɐ������܂�</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        public int ReadCustomSchemaInfo(string originalSchemaPath, out CustomTextProviderInfo customTextProviderInfo)
        {
            Hashtable ht;
            ArrayList al;
            return ReadSchemaInfo(originalSchemaPath, out customTextProviderInfo, out ht, out al);
        }

        private int ReadCustomSchemaInfo(string originalSchemaPath, out CustomTextProviderInfo customTextProviderInfo, out Hashtable colInfoList, out ArrayList colInfoNumberList)
        {
            customTextProviderInfo = CustomTextProviderInfo.GetDefaultInfo();
            Hashtable ht = new Hashtable();
            ArrayList al = new ArrayList();

            int st = -1;
            bool IsSchemaError = true; 


            // ���[�U��`�X�L�[�}�t�@�C���p�X�̐���
            string path = MakeCustomSchemaPath(originalSchemaPath);

            bool existFile = false;
            if (System.IO.File.Exists(path))
            {
                existFile = true;
            }
            else
            {
                string lFileName = System.IO.Path.GetFileName(path);

                if (System.IO.File.Exists(lFileName))
                {
                    existFile = true;
                    path = lFileName;
                }            
            }

            // �X�L�[�}�t�@�C���ǂݍ���
            if(existFile)
            {

                XmlDocument _xmlDoc = null;
                bool _xPathDocEnable = false;

                // �o�̓t�@�C���̐ݒ�擾
                try
                {
                    _xmlDoc = new XmlDocument();
                    _xmlDoc.Load(path);
                    _xPathDocEnable = true;
                }
                catch (FileNotFoundException e)
                {
                    System.Windows.Forms.MessageBox.Show(e.StackTrace);
                }
                catch (XmlException e)
                {
                    System.Windows.Forms.MessageBox.Show(e.StackTrace);
                }

                // �K�C�h�ݒ�t�@�C���̓Ǎ�
                if (_xPathDocEnable)
                {
                    #region �e�L�X�g�o�̓t�@�C���Ɋւ���ݒ�
                    XmlElement xmlElem = _xmlDoc.DocumentElement;
                    XmlElement xmlElem2;
                    //                    int numTmp = 0;

                    // �t�H�[�����b�Z�[�W
                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/OutPutFileName");
                    if (!(xmlElem2 == null))
                    {
                        customTextProviderInfo.OutPutFileName = xmlElem2.InnerText;
                        customTextProviderInfo.IsDefaultData_OutPutFileName = false;
                    }

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/OutPutDir");
                    if (!(xmlElem2 == null))
                    {
                        customTextProviderInfo.OutPutFolderName = xmlElem2.InnerText;
                        customTextProviderInfo.IsDefaultData_OutPutFolderName = false;
                    }

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/TextKind");
                    if (!(xmlElem2 == null))
                    {
                        SetTextKinds(ref customTextProviderInfo, xmlElem2.InnerText);
                        customTextProviderInfo.IsDefaultData_TextKind = false;
                    }

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/EncodeType");
                    if (!(xmlElem2 == null))
                    {
                        SetEncodeType(ref customTextProviderInfo, xmlElem2.InnerText);
                        customTextProviderInfo.IsDefaultData_TextFormat = false;
                    }

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/Formatter");
                    if (!(xmlElem2 == null))
                    {
                        SetTextFormats(ref customTextProviderInfo, xmlElem2.InnerText);
                        customTextProviderInfo.IsDefaultData_TextFormat = false;
                    }

                    //xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/Encryption");
                    //if (!(xmlElem2 == null))
                    //{
                    //    customTextProviderInfo.e = xmlElem2.InnerText;
                    //}

                    //xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/CipherType");
                    //if (!(xmlElem2 == null))
                    //{
                    //    customTextProviderInfo = xmlElem2.InnerText;
                    //}

                    xmlElem2 = (XmlElement)xmlElem.SelectSingleNode("//FileInfoDef/OutputHeader");
                    if (!(xmlElem2 == null))
                    {
                        if (xmlElem2.InnerText.Trim().ToUpper() == "TRUE")
                            customTextProviderInfo.AddTextHeder = true;
                        else
                            customTextProviderInfo.AddTextHeder = false;

                        customTextProviderInfo.IsDefaultData_AddTextHeder = false;

                    }
                    #endregion �e�L�X�g�o�̓t�@�C���Ɋւ���ݒ�

                    #region �o�͏��̐ݒ�
                    XmlNodeList nodeList;
                    XmlNodeList nodeListChild;

                    nodeList = xmlElem.SelectNodes("/TextServiceSchema/ColInfoDef/ColInfo");
                    int idx = 0;
                    foreach (XmlNode isbn in nodeList)
                    {
                        string lColKey = "";
                        string lColName = "";
                        string lColType = "";
                        int lColWidth = 0;
                        int lColEditMode = 0;
                        string lColDataConvert = "";
                        bool lColEnable = true;

                        bool isDefaultData_ColName = true;
                        bool isDefaultData_ColWidth = true;
                        bool isDefaultData_ColDataType = true;
                        bool isDefaultData_EditMode = true;
                        bool isDefaultData_DataConvert = true;


                        nodeListChild = isbn.ChildNodes;

                        foreach (XmlElement iElem in nodeListChild)
                        {
                            if (!(iElem == null))
                            {

                                switch (iElem.Name)
                                {
                                    case "ColKey":
                                        lColKey = iElem.InnerText;
                                        break;
                                    case "ColName":
                                        lColName = iElem.InnerText;
                                        isDefaultData_ColName = false;
                                        break;
                                    case "ColDataType":
                                        {
                                            switch (iElem.InnerText.ToUpper())
                                            {
                                                case "STRING":
                                                    lColType = "System.String";
                                                    break;
                                                case "INT32":
                                                    lColType = "System.Int32";
                                                    break;
                                                case "INT":
                                                    lColType = "System.Int32";
                                                    break;
                                                case "INT64":
                                                    lColType = "System.Int64";
                                                    break;
                                                case "LONG":
                                                    lColType = "System.Int64";
                                                    break;
                                                case "DOUBLE":
                                                    lColType = "System.Double";
                                                    break;
                                                case "GUID":
                                                    lColType = "System.Guid";
                                                    break;
                                                case "DATETIME":
                                                    lColType = "System.DateTime";
                                                    break;
                                                case "INTEGER":
                                                    lColType = "System.Int32";
                                                    break;
                                                default:
                                                    lColType = iElem.InnerText;
                                                    break;

                                            }
                                            isDefaultData_ColDataType = false;

                                        }
                                        break;
                                    case "ColWidth":
                                        if (iElem.InnerText.Trim() != "")
                                        {
                                            lColWidth = Convert.ToInt32(iElem.InnerText);
                                            isDefaultData_ColWidth = false;
                                        }
                                        else
                                        {
                                            lColWidth = 0;
                                        }

                                        break;
                                    case "ColEditMode":
                                        if (iElem.InnerText.Trim() != "")
                                        {
                                            lColEditMode = Convert.ToInt32(iElem.InnerText);
                                            isDefaultData_EditMode = false;
                                        }
                                        else
                                        {
                                            lColEditMode = 0;
                                        }
                                        break;
                                    case "ColDataConvert":
                                        if (iElem.InnerText.Trim() != "")
                                        {
                                            lColDataConvert = iElem.InnerText;
                                            isDefaultData_DataConvert = false;
                                        }
                                        break;
                                    case "ColEnable":
                                        if (iElem.InnerText.Trim() != "")
                                        {
                                            if (xmlElem2.InnerText.Trim().ToUpper() == "TRUE")
                                                lColEnable = true;
                                            else
                                                lColEnable = false;

                                        }
                                        break;

                                    default:
                                        break;
                                }
                            }
                        }

                        if ((!(lColKey == "")) && (!(lColName == "")))
                        {
                            TextColInfo txinf = new TextColInfo(idx, lColKey, lColName, lColWidth, lColType, lColEditMode, lColDataConvert);
                            txinf.SetDataState(isDefaultData_ColName, isDefaultData_ColWidth, isDefaultData_ColDataType, isDefaultData_EditMode, isDefaultData_DataConvert);
                            txinf.Enable = lColEnable;

                            ht.Add(txinf.ColKey, txinf);
                            al.Add(txinf);
                            idx++;
                        }

                    }

                    #endregion �o�͏��̐ݒ�
                    IsSchemaError = false;
                    st = 0;
                }
                else
                {
                    // �X�L�[�}�t�@�C������荞�߂Ȃ������ꍇ    
                    IsSchemaError = true;
                    st = -1;
                }

            }


            // ���s�����ꍇ�̓Z�L�����e�B�֘A�̐ݒ��MAX�ɐݒ肷��
            if (IsSchemaError)
            {
                customTextProviderInfo.AddTextHeder = false;
                st = -1;
            }

            colInfoList = ht;
            colInfoNumberList = al;
            return st;
        }

        // �I���W�i���X�L�[�}�p�X����Ƀ��[�U��`�X�L�[�}�p�X�𐶐�
        private string MakeCustomSchemaPath(string originalschemaPath)
        {
            string strTmp = "";
            string cFileName = "";

            // �f�B���N�g����, �t�@�C�����𕪉�
            cFileName = System.IO.Path.GetFileNameWithoutExtension(originalschemaPath);


            // �t�@�C������ _CD �������ă��[�U��`�X�L�[�}�t�@�C�����Ƃ���( "XXXXXXX_Ex.xml" )
            if ((cFileName != null) && (cFileName != ""))
            {
                cFileName = cFileName + "_Ex" + System.IO.Path.GetExtension(originalschemaPath);
                strTmp = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(originalschemaPath), cFileName);
            }

            return strTmp;

        }



        /// <summary>
        /// �X�L�[�}���X�V(���[�U��`���ǉ�)
        /// </summary>
        /// <param name="customTextProviderInfo">�񋟃X�L�[�}���(�ԋp�l)</param>
        /// <param name="colInfoList">�o�͍��ڏ��񋟃X�L�[�}���X�g(�ԋp�l)</param>
        /// <param name="colInfoNumberList">�o�͍��ڏ��񋟃X�L�[�}�o�͏����X�g(�ԋp�l)</param>
        /// <param name="customTextProviderInfoUserDef">���[�U��`�X�L�[�}���(�ԋp�l)</param>
        /// <param name="colInfoListUserDef">�o�͍��ڏ�񃆁[�U��`�X�L�[�}���X�g(�ԋp�l)</param>
        /// <param name="colInfoNumberListUserDef">�o�͍��ڏ�񃆁[�U��`�X�L�[�}�o�͏����X�g(�ԋp�l)</param>
        /// <remarks>
        /// <br>Note       : �񋟃X�L�[�}�������[�U��`�X�L�[�}�ōX�V���܂�</br>
        /// <br>Programmer : R.Sokei</br>
        /// <br>Date       : 2006.04.21</br>
        /// </remarks>
        private void UpdateSchemaInfoByCustomSchemaInfo(ref CustomTextProviderInfo customTextProviderInfo, ref Hashtable colInfoList, ref ArrayList colInfoNumberList,
                                                        CustomTextProviderInfo customTextProviderInfoUserDef, Hashtable colInfoListUserDef, ArrayList colInfoNumberListUserDef)
        {

            Hashtable orgInfoList = new Hashtable();
            ArrayList newOrgNumberList = new ArrayList();
            Hashtable newOrgInfoList = new Hashtable();


            #region �e�L�X�g�o�͂ɑ΂��郆�[�U��`

            // �o�̓t�@�C������
            if (!customTextProviderInfoUserDef.IsDefaultData_OutPutFileName)
            {
                customTextProviderInfo.OutPutFileName = customTextProviderInfoUserDef.OutPutFileName;
            }

            // �o�̓t�H���_
            if (!customTextProviderInfoUserDef.IsDefaultData_OutPutFolderName)
            {
                customTextProviderInfo.OutPutFolderName = customTextProviderInfoUserDef.OutPutFolderName;
            }

            // �e�L�X�g���
            if (!customTextProviderInfoUserDef.IsDefaultData_TextKind)
            {
                customTextProviderInfo.TextKind = customTextProviderInfoUserDef.TextKind;
            }

            // �e�L�X�g�t�H�[�}�b�g
            if (!customTextProviderInfoUserDef.IsDefaultData_TextFormat)
            {
                customTextProviderInfo.TextFormat = customTextProviderInfoUserDef.TextFormat;
            }

            // �R�[�h�̌n
            if (!customTextProviderInfoUserDef.IsDefaultData_EncodeType)
            {
                customTextProviderInfo.EncodeType = customTextProviderInfoUserDef.EncodeType;
            }

            // �ǉ����[�h
            if (!customTextProviderInfoUserDef.IsDefaultData_AppendMode)
            {
                customTextProviderInfo.AppendMode = customTextProviderInfoUserDef.AppendMode;
            }

            #endregion

            #region �e�o�͍��ڂɑ΂��郆�[�U��`

            // ColKey-->ColName �C���f�b�N�X�̍č\�z
            foreach (TextColInfo orgInfDtl in colInfoNumberList)
            {
                orgInfoList.Add(orgInfDtl.ColName, orgInfDtl);
            }

            //--------------------------------------------------------------------------------
            //
            // �e�o�͍��ڂɑ΂��郆�[�U��`
            //
            //--------------------------------------------------------------------------------
            foreach (TextColInfo infDtl in colInfoNumberListUserDef)
            {

                if (!infDtl.Enable) 
                {

                    // �o�͍��ڂ��o�͔�Ώ̂ɂ���(�X�L�[�}��񂩂獀�ڂ��폜����)

                    int delIndex = 0;
                    bool delFg = false;
                    for (int idx = 0; idx < colInfoNumberList.Count; idx++)
                    {
                        TextColInfo orgInfDtl = (TextColInfo)colInfoNumberList[idx];

                        if (orgInfDtl.ColName.Trim() == infDtl.ColKey.Trim())
                        {
                            delIndex = idx;
                            delFg = true;
                            break;
                        }
                    }

                    if (delFg)
                    {
                        // ���ڏ��폜
                        colInfoList.Remove(((TextColInfo)colInfoNumberList[delIndex]).ColKey);
                        colInfoNumberList.RemoveAt(delIndex);
                    }

                }
                else if (orgInfoList.ContainsKey(infDtl.ColKey))
                {

                    TextColInfo orgInfDtl = (TextColInfo)orgInfoList[infDtl.ColKey];
                    if(!infDtl.IsDefaultData_ColWidth)
                    {
                        orgInfDtl.ColWidth = infDtl.ColWidth;
                    }

                    if (!infDtl.IsDefaultData_EditMode)
                    {
                        orgInfDtl.EditMode = infDtl.EditMode;
                    }

                    if (!infDtl.IsDefaultData_DataConvert)
                    {
                        orgInfDtl.DataConvert = infDtl.DataConvert;
                    }

                    if (!infDtl.IsDefaultData_ColName)
                    {
                        orgInfDtl.ColName = infDtl.ColName;
                    }


                    newOrgNumberList.Add(orgInfDtl);
                    newOrgInfoList.Add(orgInfDtl.ColKey, orgInfDtl);
                }


            }

            #endregion


            // ���[�U��`�X�L�[�}�ŗ��`����Ă��Ȃ������񋟃X�L�[�}����폜����
            //Hashtable hs = (Hashtable)colInfoList.Clone();
            //foreach (string key in hs.Keys)
            //{
            //    if (!newOrgInfoList.ContainsKey(key))
            //    {
            //        colInfoList.Remove(key);
            //    }
            //}

            colInfoList = newOrgInfoList;
            colInfoNumberList = newOrgNumberList;

            return;
        }


        #endregion �X�L�[�}(���[�U��`)���擾


        private string MakeFilePath(int mode, string outPutDir, string filePath)
        { 


            string madePath;

            if (System.IO.File.Exists(filePath))
            {
                // filePath �Ƀt���p�X�����݂���ꍇ�͂����OK
                madePath = filePath;
            }
            // customTextProviderInfo �� �t�@�C���p�X�ƃf�B���N�g�����w�肳��Ă���΂�����g�p����
           
            else
            {
                // filePath���w�肳��Ă���ꍇ�͂������������           
                madePath = "";
            
            }

            return madePath;
        }



        private string ReadXMLFile(string filePath)
        {
            // �w�肳�ꂽ�t�@�C�����ʏ�t�@�C�����A�Í������ꂽ�t�@�C�����𔻕ʂ���
            // �t�@�C�����e��Ԃ�

            string retStr = "";

            CrptographicMaker textCipher = new CrptographicMaker();

            string textTmp = File.ReadAllText(filePath);
            int pos = textTmp.IndexOf("<TextServiceSchema>");

            if (pos > 0)
            {
                // �ʏ�t�@�C��
                retStr = textTmp;
            }
            else
            {
                // �Í����t�@�C��

                retStr = textCipher.GetDecryptText(filePath, "abcdefghijklmn9587432");
            }

//            System.Windows.Forms.MessageBox.Show(retStr);

            return retStr;
        }



        private void SetTextKinds(ref CustomTextProviderInfo customTextProviderInfo, string textkind)
        {

            switch (textkind.ToUpper())
            {
                case "CSV":
                    customTextProviderInfo.TextKind = CustomTextKinds.CSV;
                    break;
                default:
                    customTextProviderInfo.TextKind = CustomTextKinds.CSV;
                    break;
            }

            return;
        }


        private void SetTextFormats(ref CustomTextProviderInfo customTextProviderInfo, string textFormat)
        {

            switch (textFormat.ToUpper())
            {
                case "TEXT":
                    customTextProviderInfo.TextFormat = CustomTextFormats.TEXT;
                    break;
                case "BINARY":
                    customTextProviderInfo.TextFormat = CustomTextFormats.BINARY;
                    break;
                default:
                    customTextProviderInfo.TextFormat = CustomTextFormats.TEXT;
                    break;
            }

            return;
        }

        private void SetEncodeType(ref CustomTextProviderInfo customTextProviderInfo, string encodeType)
        {

            switch (encodeType.ToUpper())
            {
                case "SJIS":
                    customTextProviderInfo.EncodeType = Encoding.Default;
                    break;
                case "UTF-8":
                    customTextProviderInfo.EncodeType = Encoding.UTF8;
                    break;
                default:
                    customTextProviderInfo.EncodeType = Encoding.Default;
                    break;
            }

            return;
        }


        class TransportIndexForDataSet
        {
            public int SourceColIndex;
            public string EditColKey;

            public TransportIndexForDataSet()
            { 
            
            
            }

            public TransportIndexForDataSet(int sourceColIndex, string editColKey)
            {
                SourceColIndex = sourceColIndex;
                EditColKey = editColKey;
            }
        
        }

    }


    internal class TextColInfo
    {

        public TextColInfo()
        { 
        
        
        }

        public TextColInfo(int index, string colKey, string colName, int colWidth, string colDataType, int colEditMode, string colDataConvert)
        {
            ColIndex = index;           // �C���f�b�N�X
            ColKey = colKey;            // �L�[���
            ColName = colName;          // ���ږ���
            ColWidth = colWidth;        // �T�C�Y(byte)
            ColDataType = colDataType;  // �^
            EditMode = colEditMode;     // �ҏW����
            DataConvert = colDataConvert;
        }

        public int ColIndex = 0;               // �T�C�Y(byte)
        public string ColKey = "";             // �L�[���
        public string ColName = "";            // ���ږ���
        public int ColWidth = 0;               // �T�C�Y(byte)
        public string ColDataType = "";        // �^
        public int EditMode = 0;               // �ҏW����
        public string DataConvert = "";        // �f�[�^�R���o�[�g���� 
        public bool Enable = true;             // �o�͑Ώۋ敪(true:�o��, false:�o�͖���) 

        // �e��v���p�e�B�̓��͏��(true=�f�t�H���g�l)
        public bool IsDefaultData_ColName = true;
        public bool IsDefaultData_ColWidth = true;
        public bool IsDefaultData_ColDataType = true;
        public bool IsDefaultData_EditMode = true;
        public bool IsDefaultData_DataConvert = true;
        
        // �e��v���p�e�B�̓��͏�Ԃ�ύX����
        public void SetDataState(bool colNameState, bool colWidth, bool colDataType, bool editMode, bool dataConvert)
        {
            this.IsDefaultData_ColName = colNameState;
            this.IsDefaultData_ColWidth = colWidth;
            this.IsDefaultData_ColDataType = colDataType;
            this.IsDefaultData_EditMode = editMode;
            this.IsDefaultData_DataConvert = dataConvert;

            return;
        }


    }




    //public enum ColObjectEditMode
    //{ 
    //    DateTimeToInt_YYYYMMDD = 1010;    
    
    
    //}


}
