using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    class ProcClass
    {
        /// <summary> CSV�ǂݍ��ݗpTextFieldParser </summary>
        private TextFieldParser _csvRead;
        /// <summary> CSV�������ݗpStreamWriter </summary>
        private StreamWriter _csvWrite;
        /// <summary> ���O�������ݗpStreamWriter </summary>
        private StreamWriter _logWrite;
        /// <summary> Shift_JIS�R�[�h </summary>
        private static readonly Encoding encSJIS = Encoding.GetEncoding("Shift_JIS");

        #region -- Internal Methods --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �e��t�@�C���̑��݃`�F�b�N
        /// </summary>
        /// <param name="param">�p�����[�^</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  ���� ���q</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        internal bool CheckFilePathsExists(PMKHN09951A_Common.CSVCheckToolPara param, out string msg)
        {
            #region
            msg = String.Empty;

            #region ---- ���C���t�@�C���p�X�̃`�F�b�N ----
            if ((param.MainFilePath == null) || (param.MainFilePath.Length <= 0))
            {
                msg = param.MainFileDispName + "�t�@�C����I�����Ă��������B";
                return false;
            }

            if (!this.CheckExists(1, param.MainFilePath))
            {
                msg = param.MainFileDispName + "�őI�����ꂽCSV�t�@�C�������݂��܂���B";
                return false;
            }

            if (!this.CheckExists(3, param.MainFilePath))
            {
                msg = param.MainFileDispName + "��CSV�t�@�C���ȊO���I������Ă��܂��B\r\nCSV�t�@�C����I�����Ă��������B";
                return false;
            }
            #endregion

            #region ---- �T�u�t�@�C���p�X�̃`�F�b�N ----
            if ((param.SubFilePathList == null) || (param.SubFilePathList.Count <= 0))
            {
                msg = "��r�T�u�t�@�C����I�����Ă��������B";
                return false;
            }

            foreach (string key in param.SubFilePathList.Keys)
            {
                if (!this.CheckExists(1, param.SubFilePathList[key]))
                {
                    msg = key + "�őI�����ꂽCSV�t�@�C�������݂��܂���B";
                    return false;
                }
            }

            foreach (string key in param.SubFilePathList.Keys)
            {
                if (!this.CheckExists(3, param.SubFilePathList[key]))
                {
                    msg = key + "��CSV�t�@�C���ȊO���I������Ă��܂��B\r\nCSV�t�@�C����I�����Ă��������B";
                    return false;
                }
            }
            #endregion

            #region ---- �o�̓t�@�C���p�X�̃`�F�b�N ----
            if ((param.OutputFilePath == null) || (param.OutputFilePath.Length <= 0))
            {
                msg = "�o�̓t�@�C����I�����Ă��������B";
                return false;
            }

            string outputFilePath = Path.GetDirectoryName(param.OutputFilePath);
            if (!this.CheckExists(2, outputFilePath))
            {
                msg = "�I�����ꂽ�o�͐悪���݂��܂���B";
                return false;
            }

            if (!this.CheckExists(3, param.OutputFilePath))
            {
                msg = "�o�̓t�@�C������CSV�t�@�C���ȊO���I������Ă��܂��B\r\nCSV�t�@�C����I�����Ă��������B";
                return false;
            }
            #endregion

            return true;
            #endregion
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���C���t�@�C���f�[�^�擾
        /// </summary>
        /// <param name="param">�p�����[�^</param>
        /// <param name="headerLine">�w�b�_�[�s</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>DataView</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  ���� ���q</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        internal DataView GetMainFileData(PMKHN09951A_Common.CSVCheckToolPara param, out string headerLine, out string msg)
        {
            #region
            headerLine = String.Empty;
            msg = String.Empty;

            DataView retDV = null;
            DataTable dt = new DataTable(param.MainFileDispName);

            this._csvRead = null;

            try
            {
                this._csvRead = new TextFieldParser(param.MainFilePath, encSJIS);
                this._csvRead.TextFieldType = FieldType.Delimited;     // �t�B�[���h�F��؂�`��
                this._csvRead.SetDelimiters(",");     // ��؂�L���F�u,�v�J���}

                // �w�b�_�[�s������ꍇ
                if (param.HeaderLineExistDiv)
                    // �t�@�C���̃w�b�_�[�s���擾
                    headerLine = this._csvRead.ReadLine();

                string[] csvRowData;

                // CSV�t�@�C���̃f�[�^�ǂݍ���
                while (!this._csvRead.EndOfData)
                {
                    csvRowData = this._csvRead.ReadFields();

                    this.SetDTFromCSVRowData(ref dt, csvRowData);
                }

                if (dt.Rows.Count > 0)
                    // �L�[���ɏ]���ĕ��ёւ�
                    retDV = this.CreateSortedDataView(dt, param.PrimaryKeyList);
                else
                    msg = param.MainFileDispName + "�ŋ��CSV�t�@�C�����I������Ă��܂��B\r\nCSV�t�@�C����I�����Ă��������B";
            }
            catch (Exception ex)
            {
                retDV = null;
                msg = "CSV�t�@�C�����̎擾�Ɏ��s���܂����B\r\n" + ex.Message;
            }
            finally
            {
                if (this._csvRead != null)
                    this._csvRead.Close();
            }

            return retDV;
            #endregion
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �T�u�t�@�C���f�[�^�擾
        /// </summary>
        /// <param name="param">�p�����[�^</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>Dictionary</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  ���� ���q</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        internal Dictionary<string, DataView> GetSubFileData(PMKHN09951A_Common.CSVCheckToolPara param, out string msg)
        {
            #region
            msg = String.Empty;

            Dictionary<string, DataView> retDic = null;

            this._csvRead = null;

            try
            {
                foreach (string key in param.SubFilePathList.Keys)
                {
                    DataTable dt = new DataTable();

                    this._csvRead = new TextFieldParser(param.SubFilePathList[key], encSJIS);
                    this._csvRead.TextFieldType = FieldType.Delimited;     // �t�B�[���h�F��؂�`��
                    this._csvRead.SetDelimiters(",");     // ��؂�L���F�u,�v�J���}

                    // �w�b�_�[�s������ꍇ
                    if (param.HeaderLineExistDiv)
                        // �t�@�C���̃w�b�_�[�s�͓ǂݔ�΂����擾
                        this._csvRead.ReadLine();

                    string[] csvRowData;

                    // CSV�t�@�C���̃f�[�^�ǂݍ���
                    while (!this._csvRead.EndOfData)
                    {
                        csvRowData = this._csvRead.ReadFields();

                        this.SetDTFromCSVRowData(ref dt, csvRowData);
                    }

                    if (dt.Rows.Count > 0)
                    {
                        // �L�[���ɏ]���ĕ��ёւ�
                        DataView dv = this.CreateSortedDataView(dt, param.PrimaryKeyList);

                        if (retDic == null)
                            retDic = new Dictionary<string, DataView>();

                        if (!retDic.ContainsKey(key))
                            retDic.Add(key, dv);
                    }
                }

                if ((retDic == null) || (retDic.Count <= 0))
                    msg = "��r�T�u�ŋ��CSV�t�@�C�����I������Ă��܂��B\r\nCSV�t�@�C����I�����Ă��������B";
            }
            catch (Exception ex)
            {
                retDic = null;
                msg = "CSV�t�@�C�����̎擾�Ɏ��s���܂����B\r\n" + ex.Message;
            }
            finally
            {
                if (this._csvRead != null)
                    this._csvRead.Close();
            }

            return retDic;
            #endregion
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���ڐ��`�F�b�N����
        /// </summary>
        /// <param name="mainDV">���C��DataView</param>
        /// <param name="subDic">�T�uDataView��Dictoinary</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  ���� ���q</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        internal bool CheckItemsCount(DataView mainDV, Dictionary<string, DataView> subDic)
        {
            int mainItemsCount = mainDV.Table.Columns.Count;

            foreach (DataView dv in subDic.Values)
            {
                if (!dv.Table.Columns.Count.Equals(mainItemsCount))
                    // �eCSV�t�@�C���̍��ڐ�������Ȃ��ꍇ�́A���֐i�܂Ȃ�
                    return false;
            }

            return true;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^��r����
        /// </summary>
        /// <param name="param">�p�����[�^</param>
        /// <param name="mainDV">���C��DataView</param>
        /// <param name="subDic">�T�uDataView��Dictoinary</param>
        /// <param name="header">�w�b�_�[���</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>MethodResult</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  ���� ���q</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        internal ConstantManagement.MethodResult CompareData(PMKHN09951A_Common.CSVCheckToolPara param,
            DataView mainDV, Dictionary<string, DataView> subDic, string header, out bool msgDiv, out string msg)
        {
            #region
            ConstantManagement.MethodResult status = ConstantManagement.MethodResult.ctFNC_CANCEL;
            msgDiv = false;
            msg = String.Empty;

            // �L�[��񃊃X�g�@(key1�̒l)_(key2�̒l)_(key3�̒l)_�c�̌`���Ŋi�[
            // �����񃌃x���ł̃\�[�g�����ł��Ȃ��B�B�B
            SortedList<string, string> keyValList = new SortedList<string, string>();

            // ���C���f�[�^�����ɃL�[��񃊃X�g�𐶐�
            foreach (DataRowView drv in mainDV)
            {
                string mainKey = String.Empty;

                for (int count = 1; count <= param.PrimaryKeyList.Count; count++)
                {
                    if (mainKey.Length > 0)
                        mainKey += "__";

                    mainKey += "(" + drv["col" + param.PrimaryKeyList[count].ToString()] + ")";
                }

                if (!keyValList.ContainsKey(mainKey))
                    // �ǉ�
                    keyValList.Add(mainKey, mainKey);
            }

            // �T�u�f�[�^�����ɃL�[��񃊃X�g�𐶐�
            foreach (DataView dv in subDic.Values)
            {
                foreach (DataRowView drv in dv)
                {
                    string subKey = String.Empty;

                    for (int count = 1; count <= param.PrimaryKeyList.Count; count++)
                    {
                        if (subKey.Length > 0)
                            subKey += "__";

                        subKey += "(" + drv["col" + param.PrimaryKeyList[count].ToString()] + ")";
                    }

                    if (!keyValList.ContainsKey(subKey))
                        // �ǉ�
                        keyValList.Add(subKey, subKey);
                }
            }

            // ���يi�[�pDataTable
            DataTable dt = null;

            switch (param.OutputMode)
            {
                #region ---- �L�[�P�ʂɗ��� ----
                case PMKHN09951A_Common.OutputMode.ctByTheKey:
                    {
                        // TODO : ��r�����@���s

                        // TODO : �@�\�g�����Ɏ���
                        switch (status)
                        {
                            default:
                                {
                                    break;
                                }
                        }

                        break;
                    }
                #endregion

                #region ---- �x�[�X�Ƃ̔�r�`�F�b�N ----
                case PMKHN09951A_Common.OutputMode.ctForCompCheck:
                    {
                        // ��r�����@���s
                        status = this.Compare_ForCheck(param, mainDV, subDic, keyValList, out dt);

                        if (status == ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            if ((dt == null) || (dt.Rows.Count <= 0))
                            {
                                // ���قȂ�

                                msgDiv = true;
                                msg = "����ɏ������I�����܂����B�@���ق͂���܂���B";
                            }
                            else
                            {
                                // ���ق���

                                // ���كf�[�^��CSV�ϊ����ďo��
                                status = this.ExportCSVFile(param, header, dt, out msg);

                                if (status == ConstantManagement.MethodResult.ctFNC_NORMAL)
                                {
                                    msgDiv = true;
                                    //msg = "����ɏ������I�����܂����B�@�����������ɍ��ق��������Ă��܂��B\r\n" 
                                    msg = "����ɏ������I�����܂����B�@" + dt.Rows.Count / 2 + "�� ���ق��������Ă��܂��B\r\n"
                                        + "�o�̓t�@�C�����Q�Ƃ��Ă��������B\r\n\r\n"
                                        + "�@�@�o�͐�F" + param.OutputFilePath;
                                }
                            }
                        }

                        break;
                    }
                #endregion

                #region ---- �����p ----
                case PMKHN09951A_Common.OutputMode.ctForConsolidate:
                    {
                        // TODO : ��r�����@���s

                        // TODO : �@�\�g�����Ɏ���
                        switch (status)
                        {
                            default:
                                {
                                    break;
                                }
                        }

                        break;
                    }
                #endregion

                default:
                    {
                        status = ConstantManagement.MethodResult.ctFNC_CANCEL;
                        break;
                    }
            }

            return status;
            #endregion
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���O�o��
        /// </summary>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  ���� ���q</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        internal void WriteLog(PMKHN09951A_Common.CSVCheckToolPara param, string msg)
        {
            #region
            this._logWrite = null;

            try
            {
                // ���O�́A�o�͌��ʂƓ����K�w�ɏo�͂���
                string path = Path.Combine(Path.GetDirectoryName(param.OutputFilePath), "CSV��r�c�[��.log");

                this._logWrite = new StreamWriter(path, true, encSJIS);

                if (File.Exists(path))
                    // �����t�@�C���ɒǋL����ꍇ�́A�r���ǉ�
                    this._logWrite.WriteLine("----------------------------------------");

                // �w�b�_�[��
                this._logWrite.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss" + "�@���{"));
                // ���C��
                this._logWrite.WriteLine("�@�E" + param.MainFileDispName + "�F" + param.MainFilePath);
                // �T�u
                foreach (string key in param.SubFilePathList.Keys)
                    this._logWrite.WriteLine("�@�E" + key + "�F" + param.SubFilePathList[key]);
                // ��̉��s
                this._logWrite.WriteLine();
                // ����
                this._logWrite.WriteLine(msg);
                // ��̉��s
                this._logWrite.WriteLine();
            }
            catch
            {
                // �������Ȃ�
            }
            finally
            {
                if (this._logWrite != null)
                    this._logWrite.Close();
            }
            #endregion
        }
        #endregion

        #region -- Private Methods --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ���݃`�F�b�N
        /// </summary>
        /// <param name="mode">���[�h�i1�F�t�@�C���A2�F�f�B���N�g���A3�F�g���q�`�F�b�N�j</param>
        /// <param name="filePath">�t�@�C���p�X</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  ���� ���q</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        private bool CheckExists(int mode, string filePath)
        {
            #region
            try
            {
                switch (mode)
                {
                    // �t�@�C�����݃`�F�b�N
                    case 1:
                        return File.Exists(filePath);

                    // �f�B���N�g�����݃`�F�b�N
                    case 2:
                        return Directory.Exists(filePath);

                    // �g���q�`�F�b�N
                    case 3:
                        {
                            string extension = Path.GetExtension(filePath);

                            bool checkDiv = extension.Equals(".csv");

                            if (!checkDiv)
                                checkDiv = extension.Equals(".CSV");

                            return checkDiv;
                        }

                    default:
                        return false;
                }
            }
            catch
            {
                return false;
            }
            #endregion
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// CSV1�s����DataTable�̍s�f�[�^�֕ϊ�
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="csvRowData">CSV1�s�̃f�[�^</param>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  ���� ���q</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        private void SetDTFromCSVRowData(ref DataTable dt, string[] csvRowData)
        {
            #region
            if ((csvRowData == null) || (csvRowData.Length <= 0))
                return;

            if (dt == null)
                dt = new DataTable();

            if (dt.Columns.Count <= 0)
            {
                // �J��������
                for (int index = 1; index <= csvRowData.Length; index++)
                {
                    DataColumn dc = new DataColumn("col" + index.ToString());
                    dt.Columns.Add(dc);
                }
            }

            // �s�f�[�^����
            DataRow dr = dt.NewRow();
            for (int index = 1; index <= csvRowData.Length; index++)
                dr["col" + index.ToString()] = csvRowData[index - 1];

            // DataTable��add
            dt.Rows.Add(dr);
            #endregion
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �\�[�g����DataTable�̍쐬
        /// </summary>
        /// <param name="baseDT">DataTable</param>
        /// <param name="PKList">�v���C�}���[�L�[List</param>
        /// <returns>DataView</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  ���� ���q</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        private DataView CreateSortedDataView(DataTable baseDT, SortedList<int, int> PKList)
        {
            #region
            DataView dv = new DataView(baseDT);

            string sortCondi = String.Empty;
            for (int count = 1; count <= PKList.Count; count++)
            {
                if (sortCondi.Length > 0)
                    sortCondi += ", ";

                sortCondi += "col" + PKList[count].ToString();
            }

            sortCondi += " ASC";

            // �L�[���ɏ]���ĕ��ёւ�
            dv.Sort = sortCondi;

            return dv;
            #endregion
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// �f�[�^��r����
        /// </summary>
        /// <param name="param">�p�����[�^</param>
        /// <param name="mainDV">���C��DataView</param>
        /// <param name="subDic">�T�uDataView��Dictoinary</param>
        /// <param name="keyValList">�L�[���</param>
        /// <param name="difDataTable">���يi�[�pDataTable</param>
        /// <returns>MethodResult</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  ���� ���q</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        private ConstantManagement.MethodResult Compare_ForCheck(PMKHN09951A_Common.CSVCheckToolPara param,
            DataView mainDV, Dictionary<string, DataView> subDic, SortedList<string, string> keyValList, out DataTable difDataTable)
        {
            #region
            ConstantManagement.MethodResult status = ConstantManagement.MethodResult.ctFNC_CANCEL;
            string[] split = {")__("};
            string subName = String.Empty;

            difDataTable = new DataTable();

            try
            {
                // ���يi�[�pDataTable�̐���
                for (int col = 0; col <= mainDV.Table.Columns.Count; col++)
                {
                    // 0�Ԗڂ̓w�b�_�[�p
                    DataColumn dc = new DataColumn("col" + col.ToString());
                    difDataTable.Columns.Add(dc);
                }

                // �����ł̓��C���F�T�u = 1�F1�̔�r�݂̂��s��
                // �Е��ɂ̂ݑ��݂���f�[�^���u���فv�Ƃ݂Ȃ�

                DataView subDV = null;
                foreach (string subKey in param.SubFilePathList.Keys)
                {
                    if (subDic.ContainsKey(subKey))
                    {
                        subName = subKey;
                        subDV = subDic[subKey];
                        break;
                    }
                }

                // �L�[�������ɍ����`�F�b�N���s��
                foreach (string keyVal in keyValList.Keys)
                {
                    // �L�[���𕪊�
                    string[] values = keyVal.Split(split, StringSplitOptions.RemoveEmptyEntries);
                    // �t�B���^�[
                    string filter = String.Empty;

                    for (int count = 1; count <= values.Length; count++)
                    {
                        // �L�[�w�肳��Ă���J�����̒l�Ńt�B���^�[����������

                        string value = values[count - 1];

                        if (count == 1)
                            // ���̕s�v��������폜
                            value = value.Remove(0, 1);
                        else if (count == values.Length)
                            // �����̕s�v��������폜
                            value = value.Remove(value.Length - 1, 1);

                        if (filter.Length > 0)
                            filter += " AND ";

                        filter += "col" + param.PrimaryKeyList[count].ToString() + "='" + value + "'";
                    }

                    mainDV.RowFilter = filter;

                    subDV.RowFilter = filter;

                    if (mainDV.Count <= 0)
                    {
                        // ���C���͋�s��ǉ�
                        DataRow dr_null = difDataTable.NewRow();
                        dr_null["col0"] = param.MainFileDispName;
                        difDataTable.Rows.Add(dr_null);

                        #region ---- �T�u�ɂ̂ݑ��݂��邽�߁A�o�͑Ώۂɒǉ� ----
                        DataRow dr = difDataTable.NewRow();

                        // �L�[���w�肵�Ĕ����o���Ă�̂ŁA�������ׂ͑��݂��Ȃ��B�B�B�n�Y
                        DataRowView drv = subDV[0];

                        for (int col = 0; col <= drv.DataView.Table.Columns.Count; col++)
                        {
                            if (col == 0)
                                // �w�b�_�[��
                                dr["col0"] = subName;
                            else
                                // ���̑��f�[�^
                                dr["col" + col.ToString()] = drv["col" + col.ToString()];
                        }

                        difDataTable.Rows.Add(dr);
                        #endregion
                    }
                    else if (subDV.Count <= 0)
                    {
                        #region ---- ���C���ɂ̂ݑ��݂��邽�߁A�o�͑Ώۂɒǉ� ----
                        DataRow dr = difDataTable.NewRow();

                        // �L�[���w�肵�Ĕ����o���Ă�̂ŁA�������ׂ͑��݂��Ȃ��B�B�B�n�Y
                        DataRowView drv = mainDV[0];

                        for (int col = 0; col <= drv.DataView.Table.Columns.Count; col++)
                        {
                            if (col == 0)
                                // �w�b�_�[��
                                dr["col0"] = param.MainFileDispName;
                            else
                                // ���̑��f�[�^
                                dr["col" + col.ToString()] = drv["col" + col.ToString()];
                        }

                        difDataTable.Rows.Add(dr);
                        #endregion

                        // �T�u�͋�s��ǉ�
                        DataRow dr_null = difDataTable.NewRow();
                        dr_null["col0"] = subName;
                        difDataTable.Rows.Add(dr_null);
                    }
                    else
                    {
                        #region ---- �����ɑ��݂��邽�߁A1���ږ��ɔ�r ----

                        // �L�[���w�肵�Ĕ����o���Ă�̂ŁA�������ׂ͑��݂��Ȃ��B�B�B�n�Y

                        // 1���ږ��ɍ��ك`�F�b�N�����{
                        bool difDiv = false;
                        for (int col = 1; col <= mainDV[0].DataView.Table.Columns.Count; col++)
                        {
                            if (!mainDV[0]["col" + col.ToString()].Equals(subDV[0]["col" + col.ToString()]))
                            {
                                // ���ق�����̂ŁA�`�F�b�N���f
                                difDiv = true;
                                break;
                            }
                        }

                        if (difDiv)
                        {
                            // ���ق���

                            #region ---- ���C���̃��R�[�h���o�͑Ώۂɒǉ� ----
                            DataRow mainDR = difDataTable.NewRow();

                            // �L�[���w�肵�Ĕ����o���Ă�̂ŁA�������ׂ͑��݂��Ȃ��B�B�B�n�Y
                            DataRowView mainDRV = mainDV[0];

                            for (int col = 0; col <= mainDRV.DataView.Table.Columns.Count; col++)
                            {
                                if (col == 0)
                                    // �w�b�_�[��
                                    mainDR["col0"] = param.MainFileDispName;
                                else
                                    // ���̑��f�[�^
                                    mainDR["col" + col.ToString()] = mainDRV["col" + col.ToString()];
                            }

                            difDataTable.Rows.Add(mainDR);
                            #endregion

                            #region ---- �T�u�̃��R�[�h���o�͑Ώۂɒǉ� ----
                            DataRow subDR = difDataTable.NewRow();

                            // �L�[���w�肵�Ĕ����o���Ă�̂ŁA�������ׂ͑��݂��Ȃ��B�B�B�n�Y
                            DataRowView subDRV = subDV[0];

                            for (int col = 0; col <= subDRV.DataView.Table.Columns.Count; col++)
                            {
                                if (col == 0)
                                    // �w�b�_�[��
                                    subDR["col0"] = subName;
                                else
                                    // ���̑��f�[�^
                                    subDR["col" + col.ToString()] = subDRV["col" + col.ToString()];
                            }

                            difDataTable.Rows.Add(subDR);
                            #endregion
                        }
                        else
                        {
                            // ���قȂ��Ȃ̂ŁA�������Ȃ�
                        }
                        #endregion
                    }
                }

                status = ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch
            {
                difDataTable = null;
                status = ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
            #endregion
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ����CSV�o��
        /// </summary>
        /// <param name="param">�p�����[�^</param>
        /// <param name="headerLine">�w�b�_�[���</param>
        /// <param name="difDT">���يi�[�pDataTable</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns>MethodResult</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  ���� ���q</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        private ConstantManagement.MethodResult ExportCSVFile(PMKHN09951A_Common.CSVCheckToolPara param, string headerLine, DataTable difDT, out string msg)
        {
            #region
            ConstantManagement.MethodResult status = ConstantManagement.MethodResult.ctFNC_CANCEL;
            msg = String.Empty;

            this._csvWrite = null;

            try
            {
                // CSV�́@��d���p���t���A�J���}��؂�@�ŏo��

                this._csvWrite = new StreamWriter(param.OutputFilePath, false, encSJIS);

                // �w�b�_�[��������
                if (headerLine.Length > 0)
                {
                    headerLine = "�w�b�_," + headerLine;
                    this._csvWrite.WriteLine(headerLine);
                }

                string writeStr = String.Empty;

                foreach (DataRow dr in difDT.Rows)
                {
                    StringBuilder sb = new StringBuilder();

                    for (int col = 0; col < dr.Table.Columns.Count; col++)
                    {
                        if (sb.Length > 0)
                            sb.Append(",");

                        sb.Append("\"" + dr["col" + col.ToString()] + "\"");
                    }

                    // 1�s���̕�����Ɖ��s����������
                    this._csvWrite.WriteLine(sb.ToString());
                }

                status = ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                msg = "CSV�t�@�C�����̏o�͂Ɏ��s���܂����B\r\n" + ex.Message;
                status = ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (this._csvWrite != null)
                    this._csvWrite.Close();
            }

            return status;
            #endregion
        }
        #endregion
    }
}
