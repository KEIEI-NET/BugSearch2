//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Y�ƕi�ԕϊ��ꊇ����
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : ���V��
// �� �� ��  2015/03/02   �C�����e : Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// �����t�e�L�X�g�o��
    /// </summary>
    public class FormattedTextWriter
    {
        #region �v���C�x�[�g�ϐ�

        #region �v���p�e�B�Ŏg�p

        /// <summary>�f�[�^�\�[�X</summary>
        private Object _dataSource;

        /// <summary>�f�[�^�����o��</summary>
        private String _dataMember;

        /// <summary>�o�̓t�@�C����</summary>
        private String _outputFileName;

        /// <summary>�e�L�X�g�o�͂���J�������ꗗ</summary>
        private List<String> _schemeList;

        /// <summary>���ڂ̋�؂蕶��(��)�A"\t"�Ȃ��TAB</summary>
        private String _splitter;

        /// <summary>���ڊ��蕶��</summary>
        private string _encloser;

        /// <summary>���ڊ��蕶����K�p����^</summary>
        private List<Type> _enclosingTypeList;

        /// <summary>��P�ʂ̏o�̓t�H�[�}�b�g�w�胊�X�g</summary>
        private Dictionary<String, String> _formatList;

        /// <summary>�^�C�g���s�o�̓t���O</summary>
        private bool _captionOutput;

        /// <summary>�Œ蒷�o�̓t���O</summary>
        private bool _fixedLength;

        /// <summary>������u�����鍀�ڂ̈ꗗ�B</summary>
        private Dictionary<String, String> _replaceList;

        /// <summary>��P�ʂ̍ő咷�w�胊�X�g</summary>
        private Dictionary<string, int> _maxLengthList;

        /// <summary>����t�@�C�����ݎ��̏���(True:�I�_�s�֒ǉ�����False:�I�_�s�֒ǉ����Ȃ�)</summary>
        private bool _outputMode;

        #endregion // �v���p�e�B�Ŏg�p

        #region �����Ŏg�p

        private StreamWriter _sw;
        private Encoding _sjisEnc;

        #endregion // �����Ŏg�p

        #endregion

        #region �萔

        /// <summary>�Ԃ�l�F����I��</summary>
        private const int CT_RETURN_STATUS_OK = 0;

        /// <summary>�Ԃ�l�F�G���[</summary>
        private const int CT_RETURN_STATUS_ERROR = 9;

        /// <summary>�f�t�H���g�̍ő�o�C�g���icolumn�ɑ΂���MaxLength���ݒ肳��Ă��Ȃ��ꍇ�̂ݎg�p�j</summary>
        private const int CT_DEFAULT_MAXBYTECOUNT = 10;

        #endregion // �萔

        #region �R���X�g���N�^

        /// <summary>
        /// �e�L�X�g�o�͕��i
        /// </summary>
        public FormattedTextWriter()
        {
            // �����l�Z�b�g
            this._outputFileName = string.Empty;
            this._dataSource = null;
            this._dataMember = string.Empty;
            this._schemeList = null;
            this._captionOutput = true;
            this._fixedLength = false;
            this._splitter = ",";
            this._encloser = "\"";
            this._formatList = null;
            this._replaceList = null;
            this._outputMode = false;

            _sjisEnc = Encoding.GetEncoding("Shift_JIS");
        }

        #endregion // �R���X�g���N�^

        #region �v���p�e�B
        /// <summary>
        /// DataSource
        /// </summary>
        public Object DataSource
        {
            get { return this._dataSource; }
            set { this._dataSource = value; }
        }
        /// <summary>
        /// DataMember
        /// </summary>
        public String DataMember
        {
            get { return this._dataMember; }
            set { this._dataMember = value; }
        }
        /// <summary>
        /// OutputFileName
        /// </summary>
        public String OutputFileName
        {
            get { return this._outputFileName; }
            set { this._outputFileName = value; }
        }
        /// <summary>
        /// SchemeList
        /// </summary>
        public List<String> SchemeList
        {
            get { return this._schemeList; }
            set { this._schemeList = value; }
        }
        /// <summary>
        /// Splitter
        /// </summary>
        public String Splitter
        {
            get { return this._splitter; }
            set { this._splitter = value; }
        }
        /// <summary>
        /// Encloser
        /// </summary>
        public String Encloser
        {
            get { return this._encloser; }
            set { this._encloser = value; }
        }
        /// <summary>
        /// EnclosingTypeList
        /// </summary>
        public List<Type> EnclosingTypeList
        {
            get { return this._enclosingTypeList; }
            set { this._enclosingTypeList = value; }
        }
        /// <summary>
        /// FormatList
        /// </summary>
        public Dictionary<String, String> FormatList
        {
            get { return this._formatList; }
            set { this._formatList = value; }
        }
        /// <summary>
        /// CaptionOutput
        /// </summary>
        public bool CaptionOutput
        {
            get { return this._captionOutput; }
            set { this._captionOutput = value; }
        }
        /// <summary>
        /// FixedLength
        /// </summary>
        public bool FixedLength
        {
            get { return this._fixedLength; }
            set { this._fixedLength = value; }
        }
        /// <summary>
        /// ReplaceList
        /// </summary>
        public Dictionary<String, String> ReplaceList
        {
            get { return this._replaceList; }
            set { this._replaceList = value; }
        }
        /// <summary>
        /// MaxLengthList
        /// </summary>
        public Dictionary<string, int> MaxLengthList
        {
            get { return _maxLengthList; }
            set { _maxLengthList = value; }
        }
        /// <summary>
        /// OutputMode
        /// </summary>
        public bool OutputMode
        {
            get { return this._outputMode; }
            set { this._outputMode = value; }
        }
        #endregion

        #region ���\�b�h

        /// <summary>
        /// �e�L�X�g�o�͏���
        /// </summary>
        /// <param name="totalCount">out�p�����[�^ �o�͌���</param>
        /// <returns>����:0, �G���[:9</returns>
        public int TextOut(out int totalCount)
        {
            int status = CT_RETURN_STATUS_ERROR;
            totalCount = 0;

            // ----------------------------
            // �v���p�e�B�l�̃`�F�b�N
            // ----------------------------
            // �t�@�C�������Ȃ��ꍇ�̓G���[
            if (String.IsNullOrEmpty(this._outputFileName)) return status;
            // �X�L�[�}���X�g���Ȃ��ꍇ�̓G���[
            if (this._schemeList == null) return status;


            DataTable dt = new DataTable();
            DataView dv = new DataView();
            DataSet ds = new DataSet();

            // �f�[�^�\�[�X�̌���
            if (this._dataSource.GetType() == dt.GetType())
            {
                dt = (DataTable)this._dataSource;
                status = OutputData(dt, out totalCount);
            }
            else if (this._dataSource.GetType() == ds.GetType())
            {
                ds = (DataSet)this._dataSource;
                // �f�[�^�Z�b�g�̏ꍇ�A�܂܂��f�[�^�e�[�u���������̎���DataMember���w�肳��Ă��Ȃ��ƃG���[
                if (ds.Tables.Count > 1 && String.IsNullOrEmpty(this._dataMember))
                {
                    return status;
                }
                else
                {
                    dt = ds.Tables[this._dataMember];
                    status = OutputData(dt, out totalCount);
                }
            }
            else if (this._dataSource.GetType() == dv.GetType())
            {
                dv = (DataView)this._dataSource;
                dt = dv.ToTable();
                status = OutputData(dt, out totalCount);
            }
            else
            {
                // DataSet, DataView, DataTable�ȊO�ɑΉ�����ꍇ��else if�𑝂₷����
            }

            // �Ԃ�l�͕K�v
            return status;
        }

        /// <summary>
        /// �o�̓X�g���[���擾
        /// </summary>
        /// <returns></returns>
        private bool getStreamWriter()
        {
            try
            {
                // �G���R�[�f�B���O��Shift_JIS�ŌŒ�
                Encoding enc = _sjisEnc;
                // outputMode��True�̏ꍇ:�I�_�s�֒ǉ�����
                if (this._outputMode)
                {
                    this._sw = new StreamWriter(this._outputFileName, true, enc);
                }
                // outputMode��False�̏ꍇ:�I�_�s�֒ǉ����Ȃ�
                else
                {
                    this._sw = new StreamWriter(this._outputFileName, false, enc);
                }
                return true;
            }
            catch (Exception ex)
            {
                // �o�͎��s
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "FormattedTextWriter",
                    ex.Message, -1, MessageBoxButtons.OK);
                return false;
            }
        }


        /// <summary>
        /// �o�̓��C��
        /// </summary>
        /// <param name="dt">�o�͑ΏۂƂȂ�f�[�^�e�[�u��</param>
        /// <param name="outputLineCount">�o�͌���</param>
        /// <returns></returns>
        private int OutputData(DataTable dt, out int outputLineCount)
        {
            // �Ԃ�l�̏����l�̓G���[
            int status = CT_RETURN_STATUS_ERROR;
            outputLineCount = 0;

            DataRowCollection rows;
            int colCount = 0;
            int lastColIndex = 0;
            int currentRow = 0;

            string formatStr = string.Empty;
            string replaceList = string.Empty;
            string colName = string.Empty;

            string repKey = string.Empty;
            string repValue = string.Empty;

            if (_maxLengthList == null)
            {
                _maxLengthList = new Dictionary<string, int>();
            }

            // �o�̓X�g���[���擾
            if (!getStreamWriter())
            {
                return status;
            }

            // �o�͂���񐔂��J�E���g�i�X�L�[�}���X�g�ɂȂ���͏o�͂���Ȃ��j
            colCount = this._schemeList.Count;
            lastColIndex = colCount - 1;

            #region �^�C�g���s�o��

            // �^�C�g���s���o�͂���
            if (this._captionOutput)
            {
                for (int i = 0; i < this._schemeList.Count; i++)
                {
                    DataColumn col = dt.Columns[this._schemeList[i]];

                    // �񂪑��݂��Ȃ���΃G���[��Ԃ��i���̃G���[���͂킩��Ȃ��j
                    if (col == null) return status;

                    // �������݃e�L�X�g
                    string writeString = col.Caption;

                    // �ő咷(�o�C�g���w��)
                    int maxLength = CT_DEFAULT_MAXBYTECOUNT;
                    if (_maxLengthList.ContainsKey(col.ColumnName))
                    {
                        maxLength = _maxLengthList[col.ColumnName];
                    }

                    bool isString = false;

                    if (col.DataType == typeof(Int16) ||
                         col.DataType == typeof(Int32) ||
                         col.DataType == typeof(Int64) ||
                         col.DataType == typeof(decimal) ||
                         col.DataType == typeof(float) ||
                         col.DataType == typeof(double))
                    {
                    }
                    else
                    {
                        isString = true;
                    }

                    // �Œ蒷
                    if (this._fixedLength)
                    {
                        if (isString)
                        {
                            // ���l�� (XXXXX_____)
                            writeString = this.BytePadRight(writeString, maxLength);
                        }
                        else
                        {
                            // �E�l�� (_____XXXXX)
                            writeString = this.BytePadLeft(writeString, maxLength);
                        }
                    }

                    // ����Ώۂ̌^
                    if (_enclosingTypeList.Contains(col.DataType))
                    {
                        writeString = this._encloser + writeString + this._encloser;
                    }

                    // ��������
                    this._sw.Write(writeString);

                    // ��؂蕶������������
                    if (lastColIndex > i) this._sw.Write(this._splitter);
                }

                // ���s
                this._sw.Write(Environment.NewLine);
            }

            #endregion // �^�C�g���s�o��

            #region �f�[�^�o��

            rows = dt.Rows;
            foreach (DataRow row in rows)
            {
                // �f�[�^�������o��
                for (int i = 0; i < this._schemeList.Count; i++)
                {
                    DataColumn col = dt.Columns[this._schemeList[i]];
                    // �񂪑��݂��Ȃ���΃G���[��Ԃ��i���̃G���[���͂킩��Ȃ��j
                    if (col == null) return status;

                    colName = this._schemeList[i].ToString();

                    // �ő咷(�o�C�g���w��)
                    int maxLength = CT_DEFAULT_MAXBYTECOUNT;
                    if (_maxLengthList.ContainsKey(col.ColumnName))
                    {
                        maxLength = _maxLengthList[col.ColumnName];
                    }

                    if (this._formatList != null && !String.IsNullOrEmpty(this._formatList[colName]))
                    {
                        // �t�H�[�}�b�g�w�肠��
                        formatStr = this._formatList[colName].ToString();
                    }
                    else
                    {
                        // �t�H�[�}�b�g�w��Ȃ�
                        formatStr = string.Empty;
                    }

                    // �������݃e�L�X�g
                    string writeString = string.Empty;
                    bool isString = false;

                    // �W���e�L�X�g���e
                    # region [�W���e�L�X�g���e]
                    if (row[colName] == DBNull.Value)
                    {
                        writeString = string.Empty;
                    }
                    else if (col.DataType == typeof(DateTime))
                    {
                        writeString = ((DateTime)row[colName]).ToString(formatStr);
                        isString = true;
                    }
                    else if (col.DataType == typeof(Int16))
                    {
                        writeString = ((Int16)row[colName]).ToString(formatStr);
                    }
                    else if (col.DataType == typeof(Int32))
                    {
                        writeString = ((Int32)row[colName]).ToString(formatStr);
                    }
                    else if (col.DataType == typeof(Int64))
                    {
                        writeString = ((Int64)row[colName]).ToString(formatStr);
                    }
                    else if (col.DataType == typeof(decimal))
                    {
                        writeString = ((decimal)row[colName]).ToString(formatStr);
                    }
                    else if (col.DataType == typeof(float))
                    {
                        writeString = ((float)row[colName]).ToString(formatStr);
                    }
                    else if (col.DataType == typeof(double))
                    {
                        writeString = ((double)row[colName]).ToString(formatStr);
                    }
                    else if (col.DataType == typeof(string))
                    {
                        if (_replaceList != null)
                        {
                            // ������̂�ReplaceList�Ɣ�r
                            foreach (KeyValuePair<string, string> rPage in this._replaceList)
                            {
                                if (row[colName].ToString().Contains(rPage.Key))
                                {
                                    writeString = row[colName].ToString().Replace(rPage.Key, rPage.Value);
                                }
                                else
                                {
                                    writeString = row[colName].ToString();
                                }
                            }
                        }
                        else
                        {
                            writeString = row[colName].ToString();
                        }
                        isString = true;
                    }
                    else
                    {
                        writeString = row[colName].ToString();
                        isString = true;
                    }
                    # endregion

                    // �Œ蒷
                    if (this._fixedLength && maxLength > 0)
                    {
                        if (isString)
                        {
                            // ���l��
                            writeString = this.BytePadRight(writeString, maxLength);
                        }
                        else
                        {
                            // �E�l��
                            writeString = this.BytePadLeft(writeString, maxLength);
                        }
                    }

                    // ����Ώۂ̌^
                    if (_enclosingTypeList.Contains(col.DataType))
                    {
                        writeString = this._encloser + writeString + this._encloser;
                    }

                    // ��������
                    this._sw.Write(writeString);

                    // ��؂蕶������������
                    if (lastColIndex > i) this._sw.Write(this._splitter);
                }

                // ���s
                this._sw.Write(Environment.NewLine);

                currentRow++;
            }

            #endregion // �f�[�^�o��

            // �o�͏I��
            this._sw.Close();
            this._sw.Dispose();
            status = CT_RETURN_STATUS_OK;

            outputLineCount = currentRow;

            return status;
        }

        /// <summary>
        /// �o�C�g�P��PadLeft�����i�E�񂹁j�i"_____XXXXX"�j
        /// </summary>
        /// <param name="writeString"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        private string BytePadLeft(string writeString, int maxLength)
        {
            writeString = writeString.Trim();

            // ���ӂꂽ������菜��
            writeString = SubStringOfByte(writeString, maxLength);

            // �o�C�g���擾
            int orgByteCount = _sjisEnc.GetByteCount(writeString);

            // ����Ȃ������󔒂ō��ɖ��߂�
            return new string(' ', maxLength - orgByteCount) + writeString;
        }
        /// <summary>
        /// �o�C�g�P��PadRight�����i���񂹁j�i"XXXXX_____"�j
        /// </summary>
        /// <param name="writeString"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        private string BytePadRight(string writeString, int maxLength)
        {
            writeString = writeString.Trim();

            // ���ӂꂽ������菜��
            writeString = SubStringOfByte(writeString, maxLength);

            // �o�C�g���擾
            int orgByteCount = _sjisEnc.GetByteCount(writeString);

            // ����Ȃ������󔒂ŉE�ɖ��߂�
            return writeString + new string(' ', maxLength - orgByteCount);
        }
        /// <summary>
        /// ������@�o�C�g���w��؂蔲��
        /// </summary>
        /// <param name="orgString">���̕�����</param>
        /// <param name="byteCount">�o�C�g��</param>
        /// <returns>�w��o�C�g���Ő؂蔲����������</returns>
        private string SubStringOfByte(string orgString, int byteCount)
        {
            string resultString = string.Empty;

            // ���炩���߁u�������v���w�肵�Đ؂蔲���Ă���
            // (���̒i�K��byte����<������>�`2*<������>�̊ԂɂȂ�)
            orgString = orgString.PadRight(byteCount).Substring(0, byteCount);

            int count;

            for (int i = orgString.Length; i >= 0; i--)
            {
                // �u�������v�����炷
                resultString = orgString.Substring(0, i);

                // �o�C�g�����擾���Ĕ���
                count = _sjisEnc.GetByteCount(resultString);
                if (count <= byteCount) break;
            }

            // ���̗]������菜���ĕԂ�
            return resultString.TrimEnd();
        }

        #endregion
    }
}
