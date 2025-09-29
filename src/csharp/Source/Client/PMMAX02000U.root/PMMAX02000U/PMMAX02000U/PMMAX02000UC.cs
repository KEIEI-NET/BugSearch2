//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �o�i�E���ח\��
// �v���O�����T�v   : �o�i�E���ח\�� �O���ݒ�t�@�C��
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00  �쐬�S�� : ���O
// �� �� �� : 2016/01/21   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using System.IO;
using Broadleaf.Application.Common;
using System.Data;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �O���ݒ�t�@�C���p�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �O���ݒ�t�@�C���p�N���X�B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2016/01/21</br>
    /// </remarks>
    public class PMMAX02000UC
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        // �ݒ�XML�t�@�C����
        private string XML_FILE_NAME = "UISettings_PMMAX02000U.xml";
        // ���[�U�[�ݒ胊�X�g
        private OutAndInPutUserData _exportSalesDataList;
        // �ݒ�DAT�t�@�C����
        private const string DAT_FILE_NAME = @"AppSettingData\BuhinMax.dat";
        // �ݒ�DAT�R�s�[�t�@�C����
        private const string DAT_FILE_NAME_COPY = @"AppSettingData\BuhinMaxCopy.dat";
        // DAT���쐬����N���X
        private FileEncryptgraphy _saveInDat;
        // DAT�t�@�C���̃p�[�X�̐ݒ�
        private string filePath;
        // �R�s�[�t�@�C���̃p�[�X�̐ݒ�
        private string filePathTemp;
        // ��ƃR�[�h
        private string _enterpriseCode;
        // ���O�C�����_�R�[�h
        private string _loginSectionCode;

        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// <summary>
        /// ���O�C�����_�R�[�h
        /// </summary>
        public string LoginSectionCode
        {
            get { return _loginSectionCode; }
            set { _loginSectionCode = value; }
        }
        # endregion

        // ===================================================================================== //
        // ���[�U�[���p�e�[�u��
        // ===================================================================================== //
        #region ���[�U�[���p�e�[�u��
        /// <summary>���[�U�[���p�e�[�u������</summary>
        public const string ct_Tbl_Users = "Tbl_User";

        /// <summary>��ƃR�[�h</summary>
        public const string ct_Col_EnterPriseCode = "EnterPriseCode";
        /// <summary>���_�R�[�h</summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary>���[�U�[ID</summary>
        public const string ct_Col_UserID = "UserID";
        /// <summary>���[�U�[�p�[�X���[�h</summary>
        public const string ct_Col_UserPassWord = "UserPassWord";
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        /// <summary>
        /// ���ʂ̃��[�U�[
        /// </summary>
        public OutAndInPutUserData ExportSalesDataList
        {
            get { return _exportSalesDataList; }
            set { _exportSalesDataList = value; }
        }
        # endregion

        // ===================================================================================== //
        // Constructor
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// �o�i�E���ח\�񋤒ʃN���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�i�E���ח\�񋤒ʃN���X�R���X�g���N�^�����������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public PMMAX02000UC()
        {
            // ��ƃR�[�h
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ���O�C�����_�R�[�h
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim().PadLeft(2, '0');
            // DAT�t�@�C���̈Í���
            _saveInDat = new FileEncryptgraphy(this._enterpriseCode);
            // DAT�t�@�C���̃p�[�X�̐ݒ�
            filePath = Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.LocalApplicationData, DAT_FILE_NAME));
            // �R�s�[�t�@�C���̃p�[�X�̐ݒ�
            filePathTemp = Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.LocalApplicationData, DAT_FILE_NAME_COPY));
        }
        # endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region Public Methods
        /// <summary>
        /// �V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V���A���C�Y�������s���B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                // �V���A���C�Y����
                UserSettingController.SerializeUserSetting(_exportSalesDataList, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// �f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �f�V���A���C�Y�������s���B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            {
                try
                {
                    this._exportSalesDataList = UserSettingController.DeserializeUserSetting<OutAndInPutUserData>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));

                }
                catch
                {
                    this._exportSalesDataList = new OutAndInPutUserData();
                }
            }
            else
            {
                this._exportSalesDataList = new OutAndInPutUserData();
            }
        }

        /// <summary>
        /// ���[�U�[���ۑ��pDateTable�̍쐬
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�U�[���ۑ��pDateTable�̍쐬</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public void CreatUserDateTable(ref DataSet menuDataSet, string userID, string userPassWord)
        {
            // DateTable���Ȃ��ꍇ
            if (menuDataSet.Tables.Count == 0)
            {
                DataTable userDataTable = new DataTable(PMMAX02000UC.ct_Tbl_Users);

                // ��ƃR�[�h
                DataColumn columnEnterPriseCode = new DataColumn(PMMAX02000UC.ct_Col_EnterPriseCode, typeof(string));
                columnEnterPriseCode.Caption = "��ƃR�[�h";
                userDataTable.Columns.Add(columnEnterPriseCode);

                // ���_�R�[�h
                DataColumn columnSectionCode = new DataColumn(PMMAX02000UC.ct_Col_SectionCode, typeof(string));
                columnSectionCode.Caption = "���_�R�[�h";
                userDataTable.Columns.Add(columnSectionCode);

                // ���[�U�[ID
                DataColumn columnUserId = new DataColumn(PMMAX02000UC.ct_Col_UserID, typeof(string));
                columnUserId.Caption = "���[�U�[ID";
                userDataTable.Columns.Add(columnUserId);

                // ���[�U�[�p�[�X���[�h
                DataColumn columnUserPassWord = new DataColumn(PMMAX02000UC.ct_Col_UserPassWord, typeof(string));
                columnUserPassWord.Caption = "���[�U�[�p�[�X���[�h";
                userDataTable.Columns.Add(columnUserPassWord);

                menuDataSet.Tables.Add(userDataTable);
            }
            // �V�����s��ǉ�����
            DataRow row = menuDataSet.Tables[PMMAX02000UC.ct_Tbl_Users].NewRow();

            row[PMMAX02000UC.ct_Col_EnterPriseCode] = this._enterpriseCode;
            row[PMMAX02000UC.ct_Col_SectionCode] = this._loginSectionCode;
            row[PMMAX02000UC.ct_Col_UserID] = userID;
            row[PMMAX02000UC.ct_Col_UserPassWord] = userPassWord;

            menuDataSet.Tables[PMMAX02000UC.ct_Tbl_Users].Rows.Add(row);
        }

        /// <summary>
        /// ���[�U�[���ۑ��pDateTable�̍Đݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[�U�[���ۑ��pDateTable�̍Đݒ�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public void ReSetDateTable(ref DataSet menuDataSet, string userID, string userPassWord)
        {
            // �Y�����[�U�[����DAT�t�@�C���ɕۑ������ꍇ
            if (menuDataSet != null && menuDataSet.Tables.Count > 0 && menuDataSet.Tables[PMMAX02000UC.ct_Tbl_Users].Rows.Count > 0)
            {
                foreach (DataRow stdRow in menuDataSet.Tables[PMMAX02000UC.ct_Tbl_Users].Rows)
                {
                    // ��ƃR�[�h�Ƌ��_���L�[�Ƃ��āA�Y�����郆�[�U�[�����擾����
                    if (this._enterpriseCode == stdRow[PMMAX02000UC.ct_Col_EnterPriseCode].ToString() && this._loginSectionCode == stdRow[PMMAX02000UC.ct_Col_SectionCode].ToString())
                    {
                        // �Y�����郆�[�U�[�����擾����
                        stdRow[PMMAX02000UC.ct_Col_UserID] = userID;
                        stdRow[PMMAX02000UC.ct_Col_UserPassWord] = userPassWord;
                    }
                }
            }
        }

        /// <summary>
        /// DAT�t�@�C���̏�������
        /// </summary>
        /// <remarks>
        /// <br>Note       : DAT�t�@�C���̏�������</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public void SetDateToDat(DataSet menuDataSet)
        {
            // ID�ƃp�[�X���[�h��Dat�t�@�C���ɃZ�b�g����
            using (MemoryStream ms = new MemoryStream())
            {
                // ���[�U�[����DAT�t�@�C���փZ�b�g����
                menuDataSet.WriteXml(ms, XmlWriteMode.WriteSchema);

                this._saveInDat.EncryptFile(filePath, ms);
            }
        }

        /// <summary>
        /// DAT�t�@�C���̓ǂݍ���
        /// </summary>
        /// <remarks>
        /// <br>Note       : DAT�t�@�C���̓ǂݍ���</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public DataSet ReadDatFile(string tableName, string enterPriseCode, string sectionCode, out string userID, out string userPassWord, out bool userExistFlag)
        {
            userExistFlag = false;
            DataSet menuDataSet = new DataSet();
            // ���[�U�[���
            userID = string.Empty;
            userPassWord = string.Empty;
            // DAT�t�@�C���𑶍݂��Ȃ��ꍇ
            if (!File.Exists(filePath))
            {
                // �߂�
                return menuDataSet;
            }
            // �R�s�[�t�@�C���𑶍݂���ꍇ
            if (File.Exists(filePathTemp))
            {
                // �R�s�[�t�@�C�����폜����
                File.Delete(filePathTemp);
            }
            // �t�@�C���̃R�s�[
            File.Copy(filePath, filePathTemp);
            // ��������
            MemoryStream readMs = this._saveInDat.DecryptFile(filePathTemp);

            if (readMs != null)
            {
                try
                {
                    // DAT�t�@�C������A�f�[�^���擾����
                    menuDataSet.ReadXml(readMs, XmlReadMode.Auto);
                    // DateSet���烆�[�U�[�����擾����
                    if (menuDataSet != null && menuDataSet.Tables[tableName].Rows.Count > 0)
                    {
                        foreach (DataRow stdRow in menuDataSet.Tables[tableName].Rows)
                        {
                            // ��ƃR�[�h�Ƌ��_���L�[�Ƃ��āA�Y�����郆�[�U�[�����擾����
                            if (this._enterpriseCode == stdRow[ct_Col_EnterPriseCode].ToString() && this._loginSectionCode == stdRow[ct_Col_SectionCode].ToString())
                            {
                                // �Y�����郆�[�U�[�����擾����
                                userID = stdRow[ct_Col_UserID].ToString();
                                userPassWord = stdRow[ct_Col_UserPassWord].ToString();
                                userExistFlag = true;
                                break;
                            }
                        }
                    }
                    else
                    {

                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    readMs.Dispose();
                    // �R�s�[�t�@�C���𑶍݂���ꍇ
                    if (File.Exists(filePathTemp))
                    {
                        // �R�s�[�t�@�C�����폜����
                        File.Delete(filePathTemp);
                    }
                }
            }

            return menuDataSet;
        }
        # endregion
    }

    #region [XML�t�@�C���o�͗p]
    /// <summary>
    /// �o�i�E���ח\��p���[�U�[�ݒ胊�X�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�i�E���ח\��̃��[�U�[�ݒ�����Ǘ����郊�X�g</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2016/01/21</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class OutAndInPutUserData
    {
        private List<OutAndInPutUserSaveItems> _exportSalesDataList;

        /// <summary>
        /// �o�i�E���ח\��p���[�U�[�ݒ胊�X�g
        /// </summary>
        public List<OutAndInPutUserSaveItems> ExportSalesDataList
        {
            get
            {
                if (_exportSalesDataList == null) _exportSalesDataList = new List<OutAndInPutUserSaveItems>();
                return _exportSalesDataList;
            }
            set
            {
                _exportSalesDataList = value;
            }
        }
    }

    /// <summary>
    /// �o�i�E���ח\��p���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�i�E���ח\��̃��[�U�[�ݒ�����Ǘ�����N���X</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2016/01/21</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class OutAndInPutUserSaveItems
    {
        # region �R���X�g���N�^

        /// <summary>
        /// ���Ӑ�d�q�������[�U�[�ݒ���N���X
        /// </summary>
        public OutAndInPutUserSaveItems()
        {

        }

        # endregion // �R���X�g���N�^

        # region �v���C�x�[�g�ϐ�

        // ��ƃR�[�h
        private string _enterpriseCode = "";

        // ���_�R�[�h
        private string _sectionCode = ""; 

        // ���Ӑ�R�[�h
        private Int32 _customerCode;

        // �o�ɋ��_�R�[�h
        private string _bfSectionCode = "";

        // ���ɋ��_�R�[�h
        private string _afSectionCode = "";

        // �o�ɑq�ɃR�[�h���X�g
        private string _bfWarehouseCodeList = "";
        
        // ���ɑq�ɃR�[�h���X�g
        private string _afWarehouseCodeList = "";
        
        //�o�ד��t 
        private int _shipDateInit;

        // ��������
        private int _salesOrderCount;

        // �����������l
        private int _salesRate;

        // �̔��P�������l
        private int _salesPrice;

        // �`�F�b�N���X�g�o�͑I��
        private int _moveChecked;

        // �`�F�b�N���X�g�o�͐�
        private string _moveFileName = ""; 

        # endregion // �v���C�x�[�g�ϐ�

        # region �v���p�e�B

        /// <summary>
        /// ���Ӑ�R�[�h
        /// </summary>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// <summary>
        /// �o�ɋ��_�R�[�h
        /// </summary>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// <summary>
        /// ���ɋ��_�R�[�h
        /// </summary>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// <summary>
        /// �o�ד��t
        /// </summary>
        public int ShipDateInit
        {
            get { return _shipDateInit; }
            set { _shipDateInit = value; }
        }

        /// <summary>
        /// �o�ɑq�ɃR�[�h���X�g
        /// </summary>
        public string BfWarehouseCodeList
        {
            get { return _bfWarehouseCodeList; }
            set { _bfWarehouseCodeList = value; }
        }

        /// <summary>
        /// ���ɑq�ɃR�[�h���X�g
        /// </summary>
        public string AfWarehouseCodeList
        {
            get { return _afWarehouseCodeList; }
            set { _afWarehouseCodeList = value; }
        }

        /// <summary>
        /// ������
        /// </summary>
        public int SalesOrderCount
        {
            get { return _salesOrderCount; }
            set { _salesOrderCount = value; }
        }

        /// <summary>
        /// �����������l
        /// </summary>
        public int SalesRate
        {
            get { return _salesRate; }
            set { _salesRate = value; }
        }

        /// <summary>
        /// �̔��P�������l
        /// </summary>
        public int SalesPrice
        {
            get { return _salesPrice; }
            set { _salesPrice = value; }
        }

        /// <summary>
        /// �`�F�b�N���X�g�o�͑I��
        /// </summary>
        public int MoveChecked
        {
            get { return _moveChecked; }
            set { _moveChecked = value; }
        }

        /// <summary>
        /// �`�F�b�N���X�g�o�͐�
        /// </summary>
        public string MoveFileName
        {
            get { return _moveFileName; }
            set { _moveFileName = value; }
        }

        # endregion
    }
    #endregion

    #region [�Í��������p�N���X]
    /// <summary>
    /// �Í��������p�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �Í��������p�N���X�B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2016/01/21</br>
    /// </remarks>
    public class FileEncryptgraphy
    {
        RijndaelManaged aes;

        /// <summary>
        /// �Í��������p�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Í��������p�N���X�B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public FileEncryptgraphy(string PassKey)
        {
            aes = new RijndaelManaged();

            byte[] bKey = System.Text.Encoding.UTF8.GetBytes(PassKey);

            aes.Key = ResizeBytesArray(bKey, aes.Key.Length);
            aes.IV = ResizeBytesArray(bKey, aes.IV.Length);
        }

        /// <summary>
        /// �Í�������
        /// </summary>
        /// <param name="sFileName">�o�͐於��</param>
        /// <param name="ms"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Í��������p�N���X�B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public int EncryptFile(string sFileName, MemoryStream ms)
        {
            try
            {
                string strPath = Path.GetDirectoryName(sFileName);
                if (!Directory.Exists(strPath))
                {
                    Directory.CreateDirectory(strPath);
                }

                ms.Position = 0;
                byte[] source = new byte[ms.Length];
                ms.Read(source, 0, (int)ms.Length);

                using (FileStream streamWrite = new FileStream(sFileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    using (CryptoStream cs = new CryptoStream(streamWrite, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(source, 0, source.Length);
                        cs.FlushFinalBlock();
                        streamWrite.Close();
                    }
                }

                return 0; ;
            }
            catch
            { 
                return -1;
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sFileName">�o�͐於��</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Í��������p�N���X�B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        public MemoryStream DecryptFile(string sFileName)
        {
            if (File.Exists(sFileName) == false)
        {
                return null;
            }

            try
            {
                MemoryStream ms = new MemoryStream();

                using (FileStream streamRead = new FileStream(sFileName, FileMode.Open, FileAccess.Read))
                {
                    using (CryptoStream cs = new CryptoStream(streamRead, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        byte[] source = new byte[256];
                        int readLen;
                        while ((readLen = cs.Read(source, 0, source.Length)) > 0)
                {
                            ms.Write(source, 0, readLen);
                        }
                    }
                }

                ms.Position = 0;

                return ms;
                }
            catch
                {
                return null;
            }
                }

        /// <summary>
        /// ���L�L�[�p�ɁA�o�C�g�z��̃T�C�Y��ύX����
        /// </summary>
        /// <param name="bytes">�T�C�Y��ύX����o�C�g�z��</param>
        /// <param name="newSize">�o�C�g�z��̐V�����傫��</param>
        /// <returns>�T�C�Y���ύX���ꂽ�o�C�g�z��</returns>
        /// <remarks>
        /// <br>Note       : �Í��������p�N���X�B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2016/01/21</br>
        /// </remarks>
        private static byte[] ResizeBytesArray(byte[] bytes, int newSize)
        {
            byte[] newBytes = new byte[newSize];

            if (bytes.Length <= newSize)
            {
                for (int i = 0; i < bytes.Length; i++)
                    newBytes[i] = bytes[i];
            }
            else
            {
                int pos = 0;
                for (int i = 0; i < bytes.Length; i++)
            {
                    newBytes[pos++] ^= bytes[i];
                    if (pos >= newBytes.Length)
                        pos = 0;
            }
        }

            return newBytes;
        }
    }
    # endregion
}
