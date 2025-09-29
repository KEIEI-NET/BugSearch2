//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Y�ƕi�ԕϊ��}�X�^�ϊ�����
// �v���O�����T�v   : �����𖞂������f�[�^���e�L�X�g�t�@�C���֏o�͂���
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : �i�N
// �� �� ��  2015/01/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/02/26  �C�����e : Redmine#44209 ���b�Z�[�W�̕����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���R
// �� �� ��  2015/04/27  �C�����e : ���r���[���ʑΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/04/29  �C�����e : ���X�g��NULL�A��count�͔��f����Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : ���V��
// �� �� ��  2015/05/14  �C�����e : ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h�`�F�b�N�̍폜
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.FileIO;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �i�ԕϊ��}�X�^DB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �i�ԕϊ��}�X�^�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : �i�N</br>
    /// <br>Date       : 2015/01/26</br>
    /// </remarks>
    [Serializable]
    public class MeijiGoodsChgMstDB : RemoteDB
    {
        #region �� private Memebers
        //�G���[�������b�Z�[�W
        private const string ct_FILE_MSG = "�i�ԕϊ��}�X�^�捞�p�̃N���X�C���f�b�N�X�t�@�C��������܂���B" + "\r\n" + "AP�T�[�o�[�ɃN���X�C���f�b�N�X�t�@�C�����z�u����Ă��邩�m�F���Ă��������B";
        private const string ct_FILE_NODATA = "�Y������f�[�^������܂���B";
        private const int OF_READWRITE = 2;
        private const int OF_SHARE_DENY_NONE = 0x40;
        private readonly IntPtr HFILE_ERROR = new IntPtr(-1);
        private GoodsNoChangeDB _goodsNoChangeDB;
        private GoodsNoChgCommonDB _iGoodsNoChgCommonDB;
        #endregion

        /// <summary>
        /// �i�ԕϊ��}�X�^DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        public MeijiGoodsChgMstDB()
            :
            base("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.GoodsNoChangeWork", "GOODSNOCHANGERF")
        {
            this._goodsNoChangeDB = new GoodsNoChangeDB();
            // --- ADD chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� ----->>>>>
            // �i�ԕϊ���������
            if (this._iGoodsNoChgCommonDB == null)
            {
                this._iGoodsNoChgCommonDB = new GoodsNoChgCommonDB();
            }
            // --- ADD chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� -----<<<<<
        }


        /// <summary>
        /// �i�ԕϊ��}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="goodsChangeAllCndWorkWork">��������</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="loadCnt">�ǉ�����</param>
        /// <param name="errCnt">�G���[����</param>
        /// <param name="addUpdWorkObj">�o�^�����f�[�^</param>
        /// <param name="dataObjectList">�G���[�f�[�^</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �i�ԕϊ��}�X�^�i�C���|�[�g�j�̃C���|�[�g�������s��</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        public int ImportFile(object goodsChangeAllCndWorkWork, out object addUpdWorkObj, out object dataObjectList, out Int32 readCnt, out Int32 loadCnt, out Int32 errCnt, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string err = string.Empty;
            string workDir = string.Empty;
            addUpdWorkObj = null;
            dataObjectList = null;
            readCnt = 0;
            loadCnt = 0;
            errCnt = 0;
            errMsg = string.Empty;
            // �t�@�C�����X�g
            List<string[]> csvDataList = new List<string[]>();
            GoodsChangeAllCndWorkWork cndWork = null;

            cndWork = goodsChangeAllCndWorkWork as GoodsChangeAllCndWorkWork;

            // �t�@�C�����擾
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");
            if (key == null) // �����Ă͂����Ȃ��P�[�X
            {
                workDir = @"C:\Program Files\Partsman\USER_AP"; // ���W�X�g���ɏ�񂪂Ȃ����߁A���Ƀf�t�H���g�̃t�H���_��ݒ�
            }
            else
            {
                workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
            }
            string fileName = Path.Combine(@workDir, "Log\\Trance_csv\\Cross_Index.csv");

            // �t�@�C���`�F�b�N����
            //if (!CheckInputFile(fileName, out err)) // DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
            if (!_iGoodsNoChgCommonDB.CheckInputFile(fileName, out err, 0)) // ADD chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
            {
                errMsg = err;
                return status;
            }
            bool isReadErr = false;
            // ���R�[�h���݃`�F�b�N����
            //if (!CheckInputFileDataExists(fileName, out err, out csvDataList, out isReadErr)) // DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
            if (!_iGoodsNoChgCommonDB.CheckInputFileDataExists(fileName, out err, out csvDataList, out isReadErr)) // ADD chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
            {
                if (isReadErr)
                {
                    // �Ǎ��G���[
                    errMsg = err;
                }
                else
                {
                    if (csvDataList.Count == 0)
                    {
                        // ���R�[�h���Ȃ�
                        errMsg = ct_FILE_NODATA;
                    }
                }
                return status;
            }

            List<string[]> csvDataInfoList = (List<string[]>)csvDataList;

            ArrayList importGoodsMngWorkList = null;
            // �i�ԕϊ��}�X�^�̃C���|�[�g���[�N�̕ϊ�����
            status = ConvertToGoodsMngImportWorkList(cndWork, csvDataInfoList, out importGoodsMngWorkList, out errMsg);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // �Y�����R�[�h���Ȃ��ꍇ
                if (importGoodsMngWorkList != null && importGoodsMngWorkList.Count == 0)
                {
                    loadCnt = 0;
                    return status;
                }
                Object objGoodsMngImportWorkList = (object)importGoodsMngWorkList;

                status = this.Import(ref objGoodsMngImportWorkList, out readCnt, out loadCnt, out errCnt, out dataObjectList, out addUpdWorkObj, out errMsg);
            }

            return status;
        }

        #region �t�@�C���`�F�b�N�����ւ���
        // --- DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� ----->>>>>
        #region DEL
        ///// <summary>
        ///// ÷��̧�ٖ��`�F�b�N����
        ///// </summary>
        ///// <param name="filePath">�t�@�C�����O</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>status</returns>
        ///// <remarks>
        ///// <br>Note	   : ÷��̧�ٖ��`�F�b�N�������s���B(���̓`�F�b�N�Ȃ�)</br>
        ///// <br>Programmer : �i�N</br>
        ///// <br>Date       : 2015/01/26</br>
        ///// </remarks>
        //private bool CheckInputFile(string filePath, out string errMsg)
        //{
        //    bool status = true;
        //    errMsg = string.Empty;
        //    string fileName = filePath.Trim();

        //    try
        //    {
        //        if (!Directory.Exists(System.IO.Path.GetDirectoryName(fileName)))
        //        {
        //            errMsg = ct_FILE_MSG;
        //            status = false;
        //            return status;
        //        }

        //        if (!File.Exists(fileName))
        //        {
        //            errMsg = ct_FILE_MSG;
        //            status = false;
        //            return status;
        //        }

        //        IntPtr vHandle = _lopen(fileName, OF_READWRITE | OF_SHARE_DENY_NONE);
        //        if (vHandle == HFILE_ERROR)
        //        {
        //            errMsg = ct_FILE_MSG;
        //            status = false;
        //            return status;
        //        }
        //        CloseHandle(vHandle);
        //    }
        //    catch
        //    {
        //        errMsg = ct_FILE_MSG;
        //        status = false;
        //        return status;
        //    }

        //    return true;
        //}

        ///// <summary>
        ///// ÷��̧�ٖ��̃��R�[�h���݃`�F�b�N����
        ///// </summary>
        ///// <param name="fileName">�t�@�C�����O</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <param name="dataList">�f�[�^���X�g</param>
        ///// <param name="isReadErr">�Ǎ��G���[���ǂ���</param>
        ///// <returns>status</returns>
        ///// <remarks>
        ///// <br>Note	   : ÷��̧�ٖ��̃��R�[�h���݃`�F�b�N�������s���B(���̓`�F�b�N�Ȃ�)</br>
        ///// <br>Programmer : �i�N</br>
        ///// <br>Date       : 2015/01/26</br>
        ///// </remarks>
        //private bool CheckInputFileDataExists(string fileName, out string errMsg, out List<string[]> dataList, out bool isReadErr)
        //{
        //    errMsg = string.Empty;
        //    isReadErr = false;
        //    bool bStatus = true;
        //    dataList = GetCsvData(fileName, out errMsg);
        //    // �Ǎ����ɃG���[�����������ꍇ
        //    if (!string.IsNullOrEmpty(errMsg))
        //    {
        //        isReadErr = true;
        //        bStatus = false;
        //    }
        //    return bStatus;
        //}

        ///// <summary>
        ///// CSV���擾����
        ///// </summary>
        ///// <param name="fileName">�t�@�C�����O</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>CSV���</returns>
        ///// <remarks>
        ///// <br>Note       : CSV�����擾��������B</br>
        ///// <br>Programmer : �i�N</br>
        ///// <br>Date       : 2015/01/26</br>
        ///// </remarks>
        //private List<String[]> GetCsvData(String fileName, out string errMsg)
        //{
        //    errMsg = string.Empty;
        //    List<string[]> csvDataList = new List<string[]>();
        //    TextFieldParser parser = new TextFieldParser(fileName, System.Text.Encoding.GetEncoding("Shift_JIS"));
        //    try
        //    {
        //        using (parser)
        //        {
        //            parser.TextFieldType = FieldType.Delimited;
        //            parser.SetDelimiters(","); // ��؂蕶���̓R���}
        //            while (!parser.EndOfData)
        //            {
        //                string[] row = parser.ReadFields(); // 1�s�ǂݍ���
        //                csvDataList.Add(row);
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        // �Ȃ�
        //    }
        //    return csvDataList;

        //}

        ///// <summary>
        ///// _lopen
        ///// </summary>
        ///// <param name="lpPathName"></param>
        ///// <param name="iReadWrite"></param>
        ///// <returns></returns>
        //[DllImport("kernel32.dll")]
        //public static extern IntPtr _lopen(string lpPathName, int iReadWrite);

        ///// <summary>
        ///// CloseHandle
        ///// </summary>
        ///// <param name="hObject"></param>
        ///// <returns></returns>
        //[DllImport("kernel32.dll")]
        //public static extern bool CloseHandle(IntPtr hObject);
        #endregion
        // --- DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� -----<<<<<

        /// <summary>
        /// �i�ԕϊ��}�X�^�̃C���|�[�g���[�N�̕ϊ�����
        /// </summary>
        /// <param name="cndWork">�����N���X</param>
        /// <param name="csvDataInfoList"></param>
        /// <param name="importWorkList">�����[�g�p�̃C���|�[�g���[�N���X�g</param>
        /// <param name="errMsg">errMsg</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : �i�ԕϊ��}�X�^�̃C���|�[�g���[�N�̕ϊ��������s���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private int ConvertToGoodsMngImportWorkList(GoodsChangeAllCndWorkWork cndWork, List<string[]> csvDataInfoList, out ArrayList importWorkList, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            // ���[�J�[���X�g�̎擾
            ArrayList makerList = new ArrayList();
            ArrayList makerCodeList = new ArrayList();
            status = this.SearchMakerAll(out makerList, cndWork);
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // ���[�J�[�R�[�h���X�g�̍쐬
                if (makerList != null && makerList.Count > 0)
                {
                    makerCodeList = makerList;
                }
            }

            errMsg = string.Empty;
            importWorkList = new ArrayList();
            GoodsNoChangeWork work = null;
            try
            {
                foreach (string[] csvDataArr in csvDataInfoList)
                {
                    work = new GoodsNoChangeWork();

                    if (csvDataArr.Length < 3)
                    {
                        work.CountErrLog = true;
                        int index = 0;
                        work.EnterpriseCode = cndWork.EnterpriseCode;                    // ��ƃR�[�h
                        // --- DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� ----->>>>>
                        //work.OldGoodsNo = ConvertToEmpty(csvDataArr, index++).Replace("\"\"", "\"");  // ���i��
                        //work.NewGoodsNo = ConvertToEmpty(csvDataArr, index++).Replace("\"\"", "\"");  // �V�i��
                        // --- DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� -----<<<<<
                        // --- ADD chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� ----->>>>>
                        work.OldGoodsNo = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index++).Replace("\"\"", "\"");  // ���i��
                        work.NewGoodsNo = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index++).Replace("\"\"", "\"");  // �V�i��
                        // --- ADD chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� -----<<<<<
                        importWorkList.Add(work);
                        continue;
                    }

                    int index2 = 0;
                    int a = 0;
                    work.EnterpriseCode = cndWork.EnterpriseCode;                                 // ��ƃR�[�h
                    // --- DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� ----->>>>>
                    //work.OldGoodsNo = ConvertToEmpty(csvDataArr, index2++).Replace("\"\"", "\"");              // ���i��
                    //work.NewGoodsNo = ConvertToEmpty(csvDataArr, index2++).Replace("\"\"", "\"");              // �V�i��
                    //string goodsMakerCd = ConvertToEmpty(csvDataArr, index2++); �@                               // ���[�J�[
                    // --- DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� -----<<<<<
                    // --- ADD chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� ----->>>>>
                    work.OldGoodsNo = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index2++).Replace("\"\"", "\"");              // ���i��
                    work.NewGoodsNo = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index2++).Replace("\"\"", "\"");              // �V�i��
                    string goodsMakerCd = _iGoodsNoChgCommonDB.ConvertToEmpty(csvDataArr, index2++);
                    // --- ADD chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� -----<<<<<
                    if (makerCodeList != null && makerCodeList.Count > 0 && !string.IsNullOrEmpty(goodsMakerCd))
                    {
                        if (int.TryParse(goodsMakerCd.Trim(), out a))
                        {
                            if (makerCodeList.IndexOf(a) < 0)
                            {
                                work.MakerErrLog = true;
                            }
                            work.GoodsMakerCd = a;
                        }
                        work.MakerCdCheck = goodsMakerCd;
                    }
                    else
                    {
                        work.MakerErrLog = true;
                    }

                    importWorkList.Add(work);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            return status;
        }

        // --- DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� ----->>>>>
        #region DEL
        ///// <summary>
        ///// �󔒍��ڂ֕ϊ�����
        ///// </summary>
        ///// <param name="csvDataArr">CSV���ڔz��</param>
        ///// <param name="index">�C���f�b�N�X</param>
        ///// <returns>�ύX��������</returns>
        ///// <remarks>
        ///// <br>Note       : ���ڐ�������Ȃ��ꍇ�͋󔒍��ڂ֕ϊ������������s���B</br>
        ///// <br>Programmer : �i�N</br>
        ///// <br>Date       : 2015/01/26</br>
        ///// </remarks>
        //private string ConvertToEmpty(string[] csvDataArr, Int32 index)
        //{
        //    string retContent = string.Empty;

        //    if (index < csvDataArr.Length)
        //    {
        //        retContent = csvDataArr[index];
        //    }

        //    return retContent;
        //}
        #endregion
        // --- DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� -----<<<<<

        /// <summary>
        /// �w�肳�ꂽ�����̃��[�J�[�}�X�^�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="makerList">��������</param>
        /// <param name="cndWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������e-JIBAI�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        private int SearchMakerAll( out ArrayList makerList, GoodsChangeAllCndWorkWork cndWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlConnection sqlConnection = null;
            makerList = null;
             try
            {
                //�R�l�N�V��������
                //sqlConnection = CreateSqlConnection(); //DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
                sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true); //ADD chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
                if (sqlConnection == null) return status;
                //sqlConnection.Open(); //DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�

                return SearchMakerProc(out makerList, cndWork, ref sqlConnection);
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "MeijiGoodsChgMstDB.SearchMakerAll");
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
        }

        /// <summary>
        /// �w�肳�ꂽ�����̃��[�J�[�}�X�^�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)
        /// </summary>
        /// <param name="makerUWorkList">��������</param>
        /// <param name="cndWork">�����p�����[�^</param>
        /// <param name="sqlConnection">sqlConnection</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ������e-JIBAI�߂�f�[�^���LIST��߂��܂�(�O�������SqlConnection���g�p)</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        public int SearchMakerProc(out ArrayList makerUWorkList, GoodsChangeAllCndWorkWork cndWork, ref SqlConnection sqlConnection)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            SqlDataReader myReader = null;
            SqlCommand sqlCommand = null;
            string sqlText = "";

            ArrayList al = new ArrayList();
            try
            {
                sqlText = "";
                sqlText += "SELECT " + Environment.NewLine;
                sqlText += " MAKER.ENTERPRISECODERF " + Environment.NewLine;
                sqlText += " ,MAKER.LOGICALDELETECODERF " + Environment.NewLine;
                sqlText += " ,MAKER.GOODSMAKERCDRF " + Environment.NewLine;
                sqlText += "FROM " + Environment.NewLine;
                sqlText += "  MAKERURF AS MAKER WITH (READUNCOMMITTED)" + Environment.NewLine;

                sqlCommand = new SqlCommand(sqlText, sqlConnection);

                string wkstring = "";
                string retstring = "WHERE " + Environment.NewLine;

                //��ƃR�[�h
                retstring += "  ENTERPRISECODERF = @ENTERPRISECODE " + Environment.NewLine;
                SqlParameter paraEnterpriseCode = sqlCommand.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(cndWork.EnterpriseCode);

                //�_���폜�敪
                wkstring = "  AND LOGICALDELETECODERF = @FINDLOGICALDELETECODE " + Environment.NewLine;
                if (wkstring != "")
                {
                    retstring += wkstring;
                    SqlParameter paraLogicalDeleteCode = sqlCommand.Parameters.Add("@FINDLOGICALDELETECODE", SqlDbType.Int);
                    paraLogicalDeleteCode.Value = 0;
                }

                sqlCommand.CommandText += retstring;

                myReader = sqlCommand.ExecuteReader();

                while (myReader.Read())
                {

                    al.Add(SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF")));

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                //���N���X�ɗ�O��n���ď������Ă��炤
                status = base.WriteSQLErrorLog(ex);
            }
            finally
            {
                if (sqlCommand != null) sqlCommand.Dispose();
                if (myReader != null)
                {
                    if (!myReader.IsClosed) myReader.Close();
                    myReader.Dispose();
                }
            }

            makerUWorkList = al;

            return status;
        }
        #endregion

        # region [Import]
        /// <summary>
        /// �i�ԕϊ��}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="importGoodsWorkList">�i�ԕϊ��}�X�^�C���|�[�g�f�[�^���X�g</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="errCnt">�G���[����</param>
        /// <param name="dataList">�G���[�e�[�u���p</param>
        /// <param name="addUpdWorkObj">�o�^�����f�[�^</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �i�ԕϊ��}�X�^�i�C���|�[�g�j�̃C���|�[�g�������s��</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        public int Import(ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 errCnt, out object dataList, out object addUpdWorkObj, out string errMsg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            SqlConnection sqlConnection = null;
            SqlTransaction sqlTransaction = null;
            readCnt = 0;
            addCnt = 0;
            errCnt = 0;
            errMsg = string.Empty;
            dataList = null;
            addUpdWorkObj = null;

            try
            {
                //this._iGoodsNoChgCommonDB = new GoodsNoChgCommonDB(); //DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
                // �R�l�N�V��������              
                sqlConnection = this._iGoodsNoChgCommonDB.CreateSqlConnection(true);
                if (sqlConnection == null) return status;
                sqlTransaction = sqlConnection.BeginTransaction((IsolationLevel)ConstantManagement.DB_IsolationLevel.ctDB_Default);

                // �C���|�[�g����
                status = this.ImportProc(ref importGoodsWorkList, out readCnt, out addCnt, out errCnt, out dataList, out addUpdWorkObj, out errMsg, ref sqlConnection, ref sqlTransaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �R�~�b�g
                    sqlTransaction.Commit();
                }
                else
                {
                    // ���[���o�b�N
                    sqlTransaction.Rollback();
                    addCnt = 0;// �ǉ�������0�ɂȂ�
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                base.WriteErrorLog(ex, errMsg, status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // ���[���o�b�N
                if (sqlTransaction.Connection != null) sqlTransaction.Rollback();
            }
            finally
            {
                if (sqlTransaction != null) sqlTransaction.Dispose();
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �i�ԕϊ��}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="importGoodsWorkList">�i�ԕϊ��}�X�^�C���|�[�g�f�[�^���X�g</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="errCnt">�G���[����</param>
        /// <param name="dataObjectList">�G���[�e�[�u���p</param>
        /// <param name="addUpdWorkObj">�o�^�����f�[�^</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="sqlConnection">�R���N�V����</param>
        /// <param name="sqlTransaction">�g�����U�N�V����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �i�ԕϊ��}�X�^�i�C���|�[�g�j�̃C���|�[�g�������s��</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>Note       : ���X�g��NULL�A��count�͔��f����Ή�</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/04/29</br>
        /// </remarks>
        private int ImportProc(ref object importGoodsWorkList, out Int32 readCnt, out Int32 addCnt, out Int32 errCnt, out object dataObjectList, out object addUpdWorkObj, out string errMsg, ref SqlConnection sqlConnection, ref SqlTransaction sqlTransaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            readCnt = 0;
            addCnt = 0;
            errCnt = 0;
            dataObjectList = null;
            addUpdWorkObj = null;
            errMsg = string.Empty;

            ArrayList GoodsNoChangeList = new ArrayList();
            GoodsNoChangeWork paraGoodsNoChangeWork = new GoodsNoChangeWork();

            string enterpriseCode = string.Empty;

            try
            {
                // �p�����[�^�̐ݒ�
                // �i�ԕϊ��}�X�^�̃p�����[�^�̐ݒ�
                ArrayList importGoodsWorkArray = importGoodsWorkList as ArrayList;
                if (importGoodsWorkArray == null)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    return status;
                }
                else
                {
                    enterpriseCode = ((GoodsNoChangeWork)importGoodsWorkArray[0]).EnterpriseCode;
                    paraGoodsNoChangeWork.EnterpriseCode = enterpriseCode;
                }

                // �S�������������s��
                // �S�ĕi�ԕϊ��}�X�^�̃f�[�^�̌�������
                status = _goodsNoChangeDB.SearchGoodsNoChange(out GoodsNoChangeList, paraGoodsNoChangeWork, 0, ConstantManagement.LogicalMode.GetData01);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL &&
                    status != (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                    return status;
                }

                ArrayList secList = new ArrayList();
                // �S���������ʂ�Dictionary�Ɋi�[����
                // �i�ԕϊ��}�X�^��Dictionary�̍쐬
                Dictionary<string, GoodsNoChangeWork> OldGoodsNoChangeDict = new Dictionary<string, GoodsNoChangeWork>();
                Dictionary<string, GoodsNoChangeWork> NewGoodsNoChangeDict = new Dictionary<string, GoodsNoChangeWork>();
                foreach (GoodsNoChangeWork work in GoodsNoChangeList)
                {
                    // ���i��Dictionary�Z�b�g
                    string key = work.EnterpriseCode + "-" + work.OldGoodsNo.Trim() + "-" + work.GoodsMakerCd.ToString().PadLeft(4, '0');
                    if (!OldGoodsNoChangeDict.ContainsKey(key))
                    {
                        OldGoodsNoChangeDict.Add(key, work);
                    }

                    // �V�i��Dictionary�Z�b�g
                    string key2 = work.EnterpriseCode + "-" + work.NewGoodsNo.Trim() + "-" + work.GoodsMakerCd.ToString().PadLeft(4, '0');
                    if (!NewGoodsNoChangeDict.ContainsKey(key2))
                    {
                        NewGoodsNoChangeDict.Add(key2, work);
                    }

                }

                // �ǉ��ƍX�V�f�[�^�̍쐬
                // �i�ԕϊ��}�X�^�̒ǉ����X�g
                ArrayList addGoodsNoChangeList = new ArrayList();
                // �i�ԕϊ��}�X�^�̍X�V���X�g
                ArrayList updGoodsNoChangeList = new ArrayList();

                // �i�ԕϊ��}�X�^�̃G���[table 
                ArrayList dataErrList = new ArrayList();

                // �i�ԕϊ��}�X�^�`�F�b�N
                ArrayList importCheckWorkList = importGoodsWorkList as ArrayList;
                foreach (GoodsNoChangeWork importWork in importGoodsWorkArray)
                {
                    addGoodsNoChangeList.Add(importWork);
                }

                // �Ǎ�����
                readCnt = importGoodsWorkArray.Count;

                ArrayList addUpdList = new ArrayList();

                if (addGoodsNoChangeList != null && addGoodsNoChangeList.Count > 0)
                {
                    // �b�r�u���R�[�h�`�F�b�NOK�ł���΁A�ǉ����X�g�֒ǉ�����B
                    AddUpdListCheck(addGoodsNoChangeList, out addUpdList, ref errCnt, ref dataErrList, OldGoodsNoChangeDict, NewGoodsNoChangeDict);

                    // �G���[�f�[�^������ꍇ
                    if (errCnt > 0)
                    {
                        dataObjectList = dataErrList;
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        return status;
                    }

                    // �i�ԕϊ��}�X�^�̓o�^����
                    for (int i = 0; i < addUpdList.Count; i++ )                 
                    {
                        //GoodsNoChangeWork newGoodsNoChangeWork = (GoodsNoChangeWork)addUpdList[i];// DEL 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�
                        //----- ADD 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�------>>>>>
                        GoodsNoChangeWork newGoodsNoChangeWork = null;
                        if (addUpdList != null && addUpdList.Count > 0)
                        {
                            newGoodsNoChangeWork = (GoodsNoChangeWork)addUpdList[i];
                        }
                        //----- ADD 2015/04/29 ���V�� ���X�g��NULL�A��count�͔��f����Ή�------<<<<<
                        status = _goodsNoChangeDB.WriteGoodsNoChangeProc(ref newGoodsNoChangeWork, ref sqlConnection, ref sqlTransaction);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // �o�^�ُ킪��������ꍇ�A�ǉ�������0�ɂȂ�
                            addCnt = 0;
                            // �o�^�ُ킪��������ꍇ�A�G���[�����{�P�A�c�a�o�^�ُ�̃G���[���O�Z�b�g
                            errCnt = errCnt + 1;
                            SetErrLog(UPDATEERR, newGoodsNoChangeWork, ref dataErrList);
                            break;
                        }
                    }
                }

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    addCnt = addUpdList.Count;
                    addUpdWorkObj = (object)addUpdList;
                }
                dataObjectList = dataErrList;
          

            }
            catch (SqlException ex)
            {
                errMsg = ex.Message;
                base.WriteSQLErrorLog(ex, errMsg, ex.Number);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                base.WriteErrorLog(ex, errMsg, status);
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        # endregion

        #region �f�[�^�捞�`�F�b�N
        /// <summary>
        /// �f�[�^�捞���`�F�b�N����(�G���[�Əd���`�F�b�N)
        /// </summary>
        /// <param name="importWork">�f�[�^</param>
        /// <param name="errMsg">���b�Z�[�W</param>
        /// <param name="OldGoodsNoChangeDict">�ϊ����i��dictionary</param>
        /// <param name="NewGoodsNoChangeDict">�ϊ���i��dictionary</param>
        /// <param name="oldGoodsNoDic">�ϊ����i�ԃ`�F�b�N�pdictionary</param>
        /// <param name="newGoodsNoDic">�ϊ���i�ԃ`�F�b�N�pdictionary</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>Note       : ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h�`�F�b�N�̍폜</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/05/14</br>
        /// </remarks>
        private bool ImportCheck(GoodsNoChangeWork importWork, out string errMsg, Dictionary<string, GoodsNoChangeWork> OldGoodsNoChangeDict,
             Dictionary<string, GoodsNoChangeWork> NewGoodsNoChangeDict, ref Dictionary<string, string> oldGoodsNoDic, ref Dictionary<string, string> newGoodsNoDic)
        {
            errMsg = string.Empty;
            bool errFlg = false;
            string oldGoodsRepeat = "";
            string newGoodsRepeat = "";
            string oldGoodsNoKey = importWork.OldGoodsNo.Trim() + "-" + importWork.GoodsMakerCd.ToString().Trim();
            string newGoodsNoKey = importWork.NewGoodsNo.Trim() + "-" + importWork.GoodsMakerCd.ToString().Trim();

            // �d���`�F�b�N��Dictionary�̍쐬
            if (!oldGoodsNoDic.ContainsKey(oldGoodsNoKey) && !newGoodsNoDic.ContainsKey(oldGoodsNoKey))
            {
                oldGoodsNoDic.Add(oldGoodsNoKey, oldGoodsNoKey);
            }
            else
            {
                oldGoodsRepeat = ERRMSG_OLDREPEAT;
            }
            if (!newGoodsNoDic.ContainsKey(newGoodsNoKey) && !oldGoodsNoDic.ContainsKey(newGoodsNoKey))
            {
                newGoodsNoDic.Add(newGoodsNoKey, newGoodsNoKey);
            }
            else
            {
                newGoodsRepeat = ERRMSG_NEWREPEAT;
            }

            //���ڐ��`�F�b�N
            if (importWork.CountErrLog)
            {
                errFlg = true;
                //errMsg = ERRMSG_COUNTERR; //DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
                errMsg = GoodsNoChgCommonDB.ERRMSG_COUNTERR; //ADD chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
            }
            if (!string.IsNullOrEmpty(errMsg))
            {
                return false;
            }
            
            //���i�ԃ`�F�b�N
            string oldGoodsMsg = string.Empty;
            //if (!Check_IsNull("�ϊ����i��", importWork.OldGoodsNo.Trim(), out oldGoodsMsg)) // DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
            if (!_iGoodsNoChgCommonDB.Check_IsNull("�ϊ����i��", importWork.OldGoodsNo.Trim(), out oldGoodsMsg)) // ADD chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
                errFlg = true;
            //else if (!Check_StrUnFixedLen("�ϊ����i��", importWork.OldGoodsNo.Trim(), 24, out oldGoodsMsg))  // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
            //else if (!Check_StrUnFixedLen("�ϊ����i��", importWork.OldGoodsNo.Trim(), 24, out oldGoodsMsg, GOODSNOMODE))  // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή� // DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
            else if (!_iGoodsNoChgCommonDB.Check_StrUnFixedLen("�ϊ����i��", importWork.OldGoodsNo.Trim(), 24, out oldGoodsMsg)) // ADD chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
                errFlg = true;
            else if (!Check_HalfEngNumFixedLength("�ϊ����i��", importWork.OldGoodsNo.Trim(), out oldGoodsMsg))
                errFlg = true;

            if (errFlg && !string.IsNullOrEmpty(oldGoodsMsg))
            {
                errMsg = oldGoodsMsg;
            }

            //�V�i�ԃ`�F�b�N
            string newGoodsMsg = string.Empty;
            //if (!Check_IsNull("�ϊ���i��", importWork.NewGoodsNo.Trim(), out newGoodsMsg)) // DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
            if (!_iGoodsNoChgCommonDB.Check_IsNull("�ϊ���i��", importWork.NewGoodsNo.Trim(), out newGoodsMsg)) // ADD chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
                errFlg = true;
            //else if (!Check_StrUnFixedLen("�ϊ���i��", importWork.NewGoodsNo.Trim(), 24, out newGoodsMsg))  // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
            //else if (!Check_StrUnFixedLen("�ϊ���i��", importWork.NewGoodsNo.Trim(), 24, out newGoodsMsg, GOODSNOMODE))  // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή� // DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
            else if (!_iGoodsNoChgCommonDB.Check_StrUnFixedLen("�ϊ���i��", importWork.NewGoodsNo.Trim(), 24, out newGoodsMsg)) // ADD chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
                errFlg = true;
            else if (!Check_HalfEngNumFixedLength("�ϊ���i��", importWork.NewGoodsNo.Trim(), out newGoodsMsg))
                errFlg = true;
            else if (importWork.OldGoodsNo.Trim().Equals(importWork.NewGoodsNo.Trim()))            // �V���i�Ԃ�����̃`�F�b�N
            {
                newGoodsMsg = ERRMSG_OLDCHGDESTGOODSNO;
                errFlg = true;
            }

            if (errFlg && !string.IsNullOrEmpty(newGoodsMsg))
            {
                if (string.IsNullOrEmpty(errMsg))
                {
                    errMsg = newGoodsMsg;
                }
                else
                {
                    errMsg = errMsg + "�A" + newGoodsMsg;
                }
            }

            //���[�J�[�`�F�b�N
            string makerMsg = string.Empty;
            //if (!Check_IsNull("���[�J�[", importWork.MakerCdCheck.Trim(), out makerMsg)) // DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
            if (!_iGoodsNoChgCommonDB.Check_IsNull("���[�J�[", importWork.MakerCdCheck.Trim(), out makerMsg)) // ADD chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
                errFlg = true;
            //else if (!Check_StrUnFixedLen("���[�J�[", importWork.MakerCdCheck.Trim(), 5, out makerMsg))  // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
            //else if (!Check_StrUnFixedLen("���[�J�[", importWork.MakerCdCheck.Trim(), 4, out makerMsg, MAKERMODE))  // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή� // DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
            else if (!_iGoodsNoChgCommonDB.Check_StrUnFixedLen("���[�J�[", importWork.MakerCdCheck.Trim(), 4, out makerMsg)) // ADD chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
                errFlg = true;
            //else if (!IsDigitAdd("���[�J�[", importWork.MakerCdCheck.Trim(), out makerMsg)) // DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
            else if (!_iGoodsNoChgCommonDB.IsDigitAdd("���[�J�[", importWork.MakerCdCheck.Trim(), out makerMsg)) // ADD chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
                errFlg = true;
            //----- DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h�`�F�b�N�̍폜------>>>>>
            //else if (importWork.MakerErrLog)
            //{
            //    errFlg = true;
            //    //makerMsg = "���[�J�[���o�^"; // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
            //    //makerMsg = ERRMSG_NOTFOUND; // ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή� //DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
            //    makerMsg = GoodsNoChgCommonDB.ERRMSG_MAKERNOTFOUND; //ADD chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
            //}
            //----- DEL 2015/05/14 ���V�� ���[�J�[�R�[�h�A���i�����ރR�[�h�A�a�k�R�[�h�`�F�b�N�̍폜------<<<<<
            else
            {
                importWork.GoodsMakerCd = Convert.ToInt32(importWork.MakerCdCheck);
            }

            if (errFlg && !string.IsNullOrEmpty(makerMsg))
            {
                if (string.IsNullOrEmpty(errMsg))
                {
                    errMsg = makerMsg;
                }
                else
                {
                    errMsg = errMsg + "�A" + makerMsg;
                }
            }
            if (!string.IsNullOrEmpty(errMsg))
            {
                return false;
            }

            // ���R�[�h���d�����`�F�b�N
            if (!string.IsNullOrEmpty(oldGoodsRepeat))
            {
                errMsg = oldGoodsRepeat;
                return false;
            }
            else if (!string.IsNullOrEmpty(newGoodsRepeat))
            {
                errMsg = newGoodsRepeat;
                return false;
            }

            // ���݃`�F�b�N
            string key1 = importWork.EnterpriseCode + "-" + importWork.OldGoodsNo.Trim() + "-" + importWork.GoodsMakerCd.ToString().Trim().PadLeft(4, '0');
            string key2 = importWork.EnterpriseCode + "-" + importWork.NewGoodsNo.Trim() + "-" + importWork.GoodsMakerCd.ToString().Trim().PadLeft(4, '0');
            if (OldGoodsNoChangeDict.ContainsKey(key1) || NewGoodsNoChangeDict.ContainsKey(key1))
            {
                errMsg = ERRMSG_OLDEXISTREPEAT;
                return false;
            }
            else if (OldGoodsNoChangeDict.ContainsKey(key2) || NewGoodsNoChangeDict.ContainsKey(key2))
            {
                errMsg = ERRMSG_NEWEXISTREPEAT;
                return false;
            }

            return true;
        }

        // --- DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� ----->>>>>
        #region DEL
        ///// <summary>
        ///// �����A�������`�F�b�N����
        ///// </summary>
        ///// <param name="fieldNm">���ږ�</param>
        ///// <param name="val">�l</param>
        ///// <param name="numLen"></param>
        ///// <param name="msg">����[���b�Z�[�W</param>
        ///// <returns></returns>
        //private bool Check_IntAndLen(string fieldNm, string val, int numLen, out string msg)
        //{
        //    msg = string.Empty;
        //    string regex1 = "^[0-9]*[1-9][0-9]*$";
        //    Regex objRegex = new Regex(regex1);
        //    if (!objRegex.IsMatch(val))
        //    {
        //        msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm);
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        ///// <summary>
        ///// NULL���f
        ///// </summary>
        ///// <param name="fieldNm">���ږ�</param>
        ///// <param name="val">�l</param>
        ///// <param name="msg">����[���b�Z�[�W</param>
        ///// <returns>���b�Z�[�W</returns>
        //private bool Check_IsNull(string fieldNm, string val, out string msg)
        //{
        //    msg = string.Empty;
        //    if (string.IsNullOrEmpty(val.ToString().Trim()))
        //    {
        //        msg = string.Format(FORMAT_ERRMSG_MUSTINPUT, fieldNm);
        //        return false;
        //    }
        //    return true;
        //}

        ///// <summary>
        ///// �����������f
        ///// </summary>
        ///// <param name="fieldNm">���ږ�</param>
        ///// <param name="val">�l</param>
        ///// <param name="msg">����[���b�Z�[�W</param>
        ///// <returns>���b�Z�[�W</returns>
        //private bool IsDigitAdd(string fieldNm, string val, out string msg)
        //{
        //    msg = string.Empty;
        //    string regex1 = "^[0-9]*[1-9][0-9]*$";
        //    Regex objRegex = new Regex(regex1);
        //    if (!objRegex.IsMatch(val))
        //    {
        //        msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm);
        //        return false;
        //    }
        //    return true;
        //}

        ///// <summary>
        ///// �������w�肵�Ȃ��̕�����`�F�b�N
        ///// </summary>
        ///// <param name="fieldNm">���ږ�</param>
        ///// <param name="val">�l</param>
        ///// <param name="len">����</param>
        ///// <param name="msg">����[���b�Z�[�W</param>
        ///// <param name="mode">�i�Ԗ��̓��[�J�[�̃`�F�b�N</param>
        ///// <returns>���b�Z�[�W</returns>
        ////private bool Check_StrUnFixedLen(string fieldNm, string val, int len, out string msg)// DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
        //private bool Check_StrUnFixedLen(string fieldNm, string val, int len, out string msg, int mode)// ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
        //{
        //    msg = string.Empty;
        //    if (val.Trim().Length > len)
        //    {
        //        //msg = string.Format(FORMAT_ERRMSG_LEN, fieldNm); // DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�
        //        //----- ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�----->>>>>
        //        if (mode == GOODSNOMODE)
        //        {
        //            msg = string.Format(FORMAT_ERRMSG_LENGOODSNO, fieldNm);
        //        }
        //        else
        //        {
        //            msg = string.Format(FORMAT_ERRMSG_LENMAKER, fieldNm);
        //        }
        //        //----- ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�-----<<<<<
        //        return false;
        //    }
        //    return true;
        //}
        #endregion
        // --- DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� -----<<<<<

        /// <summary>
        /// ���p�p�����A�����̃`�F�b�N
        /// </summary>
        /// <param name="fieldNm">���ږ�</param>
        /// <param name="val">�l</param>
        /// <param name="msg">����[���b�Z�[�W</param>
        /// <returns>���b�Z�[�W</returns>
        private bool Check_HalfEngNumFixedLength(string fieldNm, string val, out string msg)
        {
            msg = string.Empty;

            if (val.Length == Encoding.Default.GetByteCount(val))
            {
                return true;
            }
            else
            {
                //msg = string.Format(FORMAT_ERRMSG_TYPE, fieldNm); // DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
                msg = string.Format(GoodsNoChgCommonDB.FORMAT_ERRMSG_TYPE, fieldNm); // ADD chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
                return false;
            }

        }

        // --- DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� ----->>>>>
        ///// <summary>
        ///// ���l���ڂ֕ϊ�����
        ///// </summary>
        ///// <param name="str">CSV���ڔz��</param>
        ///// <returns>�ύX�������l</returns>
        ///// <remarks>
        ///// <br>Note       : ���ڐ�������Ȃ��ꍇ�̓[���֕ϊ������������s���B</br>
        ///// <br>Programmer : �i�N</br>
        ///// <br>Date       : 2015/01/26</br>
        ///// </remarks>
        //private Int32 ConvertToInt32(string str)
        //{
        //    Int32 retNum = 0;
        //    try
        //    {
        //        retNum = Convert.ToInt32(str);
        //    }
        //    catch
        //    {
        //        retNum = 0;
        //    }
        //    return retNum;
        //}
        // --- DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� -----<<<<<


        /// <summary>
        /// �i�ԕϊ��}�X�^�̒ǉ����X�g�Y���̃f�[�^�����݂��邩�`�F�b�N���s���܂��B
        /// </summary>
        /// <param name="ImportAddUpdList">�`�F�b�N���X�g</param>
        /// <param name="addUpdList">�ǉ����X�g</param>
        /// <param name="errCnt">�G���[����</param>
        /// <param name="dataList">�G���[�e�[�u���p</param>
        /// <param name="OldGoodsNoChangeDict">�ϊ����i��dictionary</param>
        /// <param name="NewGoodsNoChangeDict">�ϊ���i��dictionary</param>
        /// <remarks>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void AddUpdListCheck(ArrayList ImportAddUpdList, out ArrayList addUpdList, ref int errCnt, ref ArrayList dataList, Dictionary<string, GoodsNoChangeWork> OldGoodsNoChangeDict, Dictionary<string, GoodsNoChangeWork> NewGoodsNoChangeDict)
        {
            string message = string.Empty;
            addUpdList = new ArrayList();
            Dictionary<string, string> oldGoodsNoDic = new Dictionary<string, string>();
            Dictionary<string, string> newGoodsNoDic = new Dictionary<string, string>();
            foreach (GoodsNoChangeWork addUpdwork in ImportAddUpdList)
            {
                bool checkRes = ImportCheck(addUpdwork, out message, OldGoodsNoChangeDict, NewGoodsNoChangeDict, ref oldGoodsNoDic, ref newGoodsNoDic);

                if (!checkRes)
                {
                    ConverToDataSetCustomerInf(addUpdwork, message, ref dataList);
                    errCnt++;
                }
                else
                {
                    addUpdList.Add(addUpdwork);
                }
            }
        }
        # endregion

        # region ���b�Z�[�W
        //----- DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�----->>>>>
        //private const string FORMAT_ERRMSG_LEN = "{0}�����s��";

        //private const string FORMAT_ERRMSG_TYPE = "{0}�s��";

        //private const string FORMAT_ERRMSG_MUSTINPUT = "{0}���ݒ�";

        //private const string ERRMSG_OLDCHGDESTGOODSNO = "�ϊ����ϊ���i�ԏd��";

        //private const string ERRMSG_COUNTERR = "���ڐ��s��";

        //private const string ERRMSG_NOTFOUND = "���o�^";

        //private const string ERRMSG_OLDREPEAT = "�ϊ����i�ԏd��";

        //private const string ERRMSG_NEWREPEAT = "�ϊ���i�ԏd��";

        //private const string ERRMSG_OLDEXISTREPEAT = "�ϊ����i�Ԃ����ɓo�^��";

        //private const string ERRMSG_NEWEXISTREPEAT = "�ϊ���i�Ԃ����ɓo�^��";

        //private const string UPDATEERR = "�i�ԕϊ��}�X�^�̓o�^�ɃG���[�������܂���";
        //----- DEL 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�-----<<<<<

        //----- ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�----->>>>>
        // --- DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� -----<<<<<
        //private const int MAKERMODE = 0;

        //private const int GOODSNOMODE = 1;

        //private const string FORMAT_ERRMSG_LENGOODSNO = "{0}�̌�����24���𒴂��Ă��܂�";

        //private const string FORMAT_ERRMSG_LENMAKER = "{0}�̌�����4���𒴂��Ă��܂�";

        //private const string FORMAT_ERRMSG_TYPE = "{0}�ɕs���ȕ������܂܂�Ă��܂�";

        //private const string FORMAT_ERRMSG_MUSTINPUT = "{0}���ݒ肳��Ă��܂���";
        // --- DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� -----<<<<<

        private const string ERRMSG_OLDCHGDESTGOODSNO = "�ϊ����i�Ԃƕϊ���i�Ԃ��d�����Ă��܂�";

        //private const string ERRMSG_COUNTERR = "���ڐ����s���ł�"; //DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�

        //private const string ERRMSG_NOTFOUND = "���[�J�[���}�X�^�ɓo�^����Ă��܂���"; //DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�

        private const string ERRMSG_OLDREPEAT = "���[�J�[�{�ϊ����i�Ԃ��d�����Ă���s�����݂��܂�";

        private const string ERRMSG_NEWREPEAT = "���[�J�[�{�ϊ���i�Ԃ��d�����Ă���s�����݂��܂�";

        private const string ERRMSG_OLDEXISTREPEAT = "���[�J�[�{�ϊ����i�Ԃ����ɕi�ԕϊ��}�X�^�ɓo�^����Ă��܂�";

        private const string ERRMSG_NEWEXISTREPEAT = "���[�J�[�{�ϊ���i�Ԃ����ɕi�ԕϊ��}�X�^�ɓo�^����Ă��܂�";

        //private const string UPDATEERR = "�i�ԕϊ��}�X�^�̓o�^�ɃG���[�������܂���"; // DEL ���R 2015/04/27 ���r���[���ʑΉ�
        private const string UPDATEERR = "�i�ԕϊ��}�X�^�̓o�^�Ɏ��s���܂���";  // ADD ���R 2015/04/27 ���r���[���ʑΉ�
        //----- ADD 2015/02/26 ���V�� Redmine#44209 ���b�Z�[�W�̕����Ή�-----<<<<<
        # endregion

        #region �G���[�f�[�^�e�[�u���ւ���
        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="goodsMng">���i�Ǘ��f�[�^</param>
        /// <param name="dataList">�e�[�v������</param>
        ///<param name="message">����[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void ConverToDataSetCustomerInf(GoodsNoChangeWork goodsMng, string message, ref ArrayList dataList)
        {
            GoodsNoChangeWork tempWork = new GoodsNoChangeWork();

            // ���i��
            tempWork.OldGoodsNo = goodsMng.OldGoodsNo;
            // �V�i��
            tempWork.NewGoodsNo = goodsMng.NewGoodsNo;
            // ���i���[�J�[�R�[�h
            tempWork.GoodsMakerCd = goodsMng.GoodsMakerCd;
            tempWork.MakerCdCheck = goodsMng.MakerCdCheck;
            // �G���[���b�Z�[�W
            tempWork.ErroLogMessage = message;
            dataList.Add(tempWork);
        }
        # endregion

        //--- DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� ----->>>>>
        //#region [�R�l�N�V������������]
        ///// <summary>
        ///// SqlConnection��������
        ///// </summary>
        ///// <returns>SqlConnection</returns>
        ///// <remarks>
        ///// <br>Programmer : �i�N</br>
        ///// <br>Date       : 2015/01/26</br>
        ///// </remarks>
        //private SqlConnection CreateSqlConnection()
        //{
        //    SqlConnection retSqlConnection = null;

        //    SqlConnectionInfo sqlConnectionInfo = new SqlConnectionInfo();
        //    string connectionText = sqlConnectionInfo.GetConnectionInfo(ConstantManagement_SF_PRO.IndexCode_UserDB);
        //    if (connectionText == null || connectionText == "") return null;

        //    retSqlConnection = new SqlConnection(connectionText);

        //    return retSqlConnection;
        //}
        //#endregion
        //--- DEL chenyk 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ� -----<<<<<

        /// <summary>
        /// �G���[���O�ݒ菈��
        /// </summary>
        /// <param name="erroLogMessage">�G���[���b�Z�[�W</param>
        /// <param name="goodsNoChangeWork">���i�i�ԕϊ����</param>
        /// <param name="dataErrList">�G���[�f�[�^���X�g</param>
        /// <remarks>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void SetErrLog(string erroLogMessage, GoodsNoChangeWork goodsNoChangeWork, ref ArrayList dataErrList)
        {
            GoodsNoChangeWork tempImportWork = new GoodsNoChangeWork();
            // ���i��
            tempImportWork.OldGoodsNo = goodsNoChangeWork.OldGoodsNo;
            // �V�i��
            tempImportWork.NewGoodsNo = goodsNoChangeWork.NewGoodsNo;
            // ���i���[�J�[�R�[�h
            tempImportWork.GoodsMakerCd = goodsNoChangeWork.GoodsMakerCd;
            // �G���[���b�Z�[�W
            tempImportWork.ErroLogMessage = erroLogMessage;

            dataErrList.Add(tempImportWork);
        }
    }

        

}
