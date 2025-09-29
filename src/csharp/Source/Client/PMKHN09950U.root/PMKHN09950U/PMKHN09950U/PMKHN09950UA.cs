using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

using Broadleaf.Application.Resources;


namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// CSV�`�F�b�N�c�[���@�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: CSV�`�F�b�N�c�[���̉�ʂł��B</br>
    /// <br>Programmer  : Miwa Honda</br>
    /// <br>Date        : 2014.08.20</br>
    /// </remarks>
    public partial class PMKHN09950UA : Form
    {
        public PMKHN09950UA()
        {
            InitializeComponent();
        }


        string _fileInfoXml = "PMKHN09950U_FileInfo.XML";
        PMKHN09951A _csvAcs = new PMKHN09951A();

        Dictionary<int, CSVFileInfo> _cSVFileInfoList = null;


        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// </remarks>
        public void PMKHN09950UShow()
        {
            this.Show();

        }

        /// <summary>
        /// Load �C�x���g
        /// </summary>
        /// <remarks>
        /// <br>Note		: ��ʂ�Load���ꂽ���ɔ������܂��B</br>
        /// </remarks>
        private void PMKHN09950UA_Load(object sender, EventArgs e)
        {
            bool msgDiv;
            string errMsg;

            // XML�쐬�p�@���i��OFF
            //SetCSVFileInfoListInfo();

            ImageList imageList16 = IconResourceManagement.ImageList16;
            this.MainFolderSelect_button.ImageList = imageList16;
            this.MainFolderSelect_button.Appearance.Image = Size16_Index.STAR1;

            this.SubFolderSelect_button.ImageList = imageList16;
            this.SubFolderSelect_button.Appearance.Image = Size16_Index.STAR1;

            this.OutputFolderSelect_button.ImageList = imageList16;
            this.OutputFolderSelect_button.Appearance.Image = Size16_Index.STAR1;

            // �Ώۃt�@�C�����擾����
            int status = this.GetTargetFileInfo(out msgDiv, out errMsg);
            {
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    if (msgDiv)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, errMsg, 0, MessageBoxButtons.OK);
                    }
                    Close();
                }
            }
        }

        /// <summary>
        /// �o�͊J�n�{�^��
        /// </summary>
        /// <remarks>
        /// <br>Note		: �o�͂��s���܂��B</br>
        /// </remarks>
        private void Start_Button_Click(object sender, EventArgs e)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                bool msgDiv = false;
                string dispMsg = "";
                emErrorLevel emlevel;

                // ���̓`�F�b�N
                if (this.InputCheck() == true)
                    return;

                // �f�[�^�Z�b�g����
                PMKHN09951A_Common.CSVCheckToolPara para = null;
                status = this.SetParaInfo(out para, out  msgDiv, out dispMsg);

                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // �`�F�b�N�����J�n
                    status = this._csvAcs.CompareFiles(para, out msgDiv, out dispMsg);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        emlevel = emErrorLevel.ERR_LEVEL_INFO;
                        if (!msgDiv)
                            dispMsg = "����ɏ������I�����܂����B";
                            
                    }
                    else if (status == (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                    {
                        emlevel = emErrorLevel.ERR_LEVEL_INFO;
                        if (!msgDiv)
                            dispMsg = "��肪���������̂ŏ����𒆒f���܂����B"; 
                    }
                    else //�G���[
                    {
                         emlevel = emErrorLevel.ERR_LEVEL_STOPDISP;
                         if (msgDiv)
                             dispMsg = "�G���[���������܂����B�������I�����܂��B";
                    }

                    TMsgDisp.Show(emlevel, this.Name, dispMsg, status, MessageBoxButtons.OK);
                }
                else
                {
                    if (msgDiv)
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, dispMsg, 0, MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOP, this.Name, "CSV�`�F�b�N�Ɏ��s���܂����B\r\n" + ex, status, MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <returns>true:�`�F�b�N����iNG�ƌ������Ɓj</returns>
        /// <remarks>
        /// <br>Note       : ���̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2014.08.20</br>
        /// </remarks>
        private bool InputCheck()
        {
            bool msgDiv = false;
            string dispMsg = "";

            bool result = false;

            try
            {
                // ���݃`�F�b�N���s���܂�
                if (TargetFile_tComboEditor.Value == null)
                {
                    msgDiv = true;
                    dispMsg = TargetFile_label.Text.Trim() + "��I�����Ă�������";
                    TargetFile_tComboEditor.Focus();
                }
                else if (MainCompfile_Edit.Text.Trim() == "")
                {
                    msgDiv = true;
                    dispMsg = MainCompfile_label.Text.Trim() + "��I�����Ă�������";
                    MainCompfile_Edit.Focus();
                }
                else if (SubCompfile_Edit.Text.Trim() == "")
                {
                    msgDiv = true;
                    dispMsg = SubCompfile_label.Text.Trim() + "��I�����Ă�������";
                    SubCompfile_Edit.Focus();
                }
                else if (Outputfile_Edit.Text.Trim() == "")
                {
                    msgDiv = true;
                    dispMsg = Outputfile_label.Text.Trim() + "��I�����Ă�������";
                    Outputfile_Edit.Focus();
                }

            }
            finally
            {
                if (msgDiv)
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, dispMsg,  0, MessageBoxButtons.OK);
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// �p�����[�^���Z�b�g����
        /// </summary>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>0( �Œ� )</returns>
        /// <remarks>
        /// <br>Note       : �p�����[�^�ɃZ�b�g���܂��B</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2014.08.20</br>
        /// </remarks>
        private int SetParaInfo(out  PMKHN09951A_Common.CSVCheckToolPara para ,out bool msgDiv, out string errMsg)
        {
            msgDiv = false;
            errMsg = "";
            CSVFileInfo cSVFileInfo = null;
            int status = 0;

            para = new PMKHN09951A_Common.CSVCheckToolPara();

            //�I�����Ă���R���{�{�b�N�X�������擾����
            int targetFileNo = (int)this.TargetFile_tComboEditor.Value;
            bool getSt = this._cSVFileInfoList.TryGetValue(targetFileNo, out cSVFileInfo);
            if (getSt)
            {
                // PrimaryKeyList �L�[���X�g
                string[] stArrayData = cSVFileInfo.PrimaryKey.Split(',');
                para.PrimaryKeyList = new SortedList<int, int>();
                // List�ɃZ�b�g����
                int count = 1;
                foreach (string stData in stArrayData)
                {
                    para.PrimaryKeyList.Add(count, Convert.ToInt32(stData));
                    count++;
                }

                // �Ώۃt�@�C�����C��
                para.MainFilePath = MainCompfile_Edit.Text;
                // �Ώۃt�@�C�����C��
                para.MainFileDispName = MainCompfile_label.Text;

                // �Ώۃt�@�C���T�u
                para.SubFilePathList = new Dictionary<string, string>();
                para.SubFilePathList.Add(SubCompfile_label.Text, SubCompfile_Edit.Text);
                // �o�̓��[�h
                para.OutputMode = PMKHN09951A_Common.OutputMode.ctForCompCheck;
                // ��r����List
                if ((cSVFileInfo.ComparItem == null) || (cSVFileInfo.ComparItem == ""))
                    para.ComparItemList = null;
                else
                {
                    stArrayData = cSVFileInfo.ComparItem.Split(',');
                    foreach (string stData in stArrayData)
                    {
                        para.ComparItemList.Add(Convert.ToInt32(stData));
                    }
                }
                // �\�[�g����List
                if ((cSVFileInfo.SortItem == null) || (cSVFileInfo.SortItem == ""))
                    para.SortItemList = null;
                else
                {
                    count = 1;
                    para.SortItemList = new SortedList<int, int>();
                    stArrayData = cSVFileInfo.SortItem.Split(',');
                    foreach (string stData in stArrayData)
                    {
                        para.SortItemList.Add(count, Convert.ToInt32(stData));
                        count++;
                    }
                }

                // �o�̓t�@�C���p�X
                para.OutputFilePath = Outputfile_Edit.Text;

                // �w�b�_�L��
                para.HeaderLineExistDiv = cSVFileInfo.HeaderLineExistDiv;

            }
            else
            {
                msgDiv = true;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                errMsg = "��ʏ�񂪐������擾�ł��܂���ł����B";
            }

            return status;
        }

        /// <summary>
        ///�@�Ώۃt�@�C�����擾����
        /// </summary>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>0( �Œ� )</returns>
        /// <remarks>
        /// <br>Note       : �Ώۃt�@�C�������擾���܂��B</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2014.08.20</br>
        /// </remarks>
        private int GetTargetFileInfo(out bool msgDiv, out string errMsg)
        {
            msgDiv = false;
            errMsg = "";
            string msgString = "�Ώۃt�@�C�����擾�����Ɏ��s���܂����B";

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            CSVFileInfo[] csvFileInfList = new CSVFileInfo[] { };

            string filePath = ConstantManagement_ClientDirectory.NSCurrentDirectory + "\\" + this._fileInfoXml;

            try
            {
                //XML�����݂̏ꍇ
                if (UserSettingController.ExistUserSetting(filePath))
                {
                    //�w�l�k�̓ǂݍ���
                    csvFileInfList = (CSVFileInfo[])UserSettingController.DeserializeUserSetting(filePath, typeof(CSVFileInfo[]));
                }
                else
                {
                    msgDiv = true;
                    errMsg = "�ݒ�XML�i"+ _fileInfoXml + ")�����݂��܂���B\r\n�������I�����܂��B";
                    status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    return status;
                }

                if (this._cSVFileInfoList == null)
                    this._cSVFileInfoList = new Dictionary<int, CSVFileInfo>();
                else
                    this._cSVFileInfoList.Clear();

                //�Ώۃt�@�C�����̎擾
                for (int i = 0; i < csvFileInfList.Length; i++)
                {
                    this._cSVFileInfoList.Add(csvFileInfList[i].CSVFileNo, csvFileInfList[i]);
                    this.TargetFile_tComboEditor.Items.Add(csvFileInfList[i].CSVFileNo, csvFileInfList[i].CSVFileName);
                }

                this.TargetFile_tComboEditor.Value = (int)1;


            }
            catch (Exception)
            {
                msgDiv = true;
                errMsg = msgString;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                return status;
            }

            return status;
        }


        /// <summary>
        /// ��r�t�@�C���I���K�C�h
        /// </summary>
        private void FolderSelect_button_Click(object sender, EventArgs e)
        {

            string fileName = "";
            if (sender == this.MainFolderSelect_button)
            {
                fileName = MainCompfile_label.Text.Trim();
            }
            else
            {
                fileName = SubCompfile_label.Text.Trim();
            }

            //OpenFileDialog�N���X�̃C���X�^���X���쐬
            OpenFileDialog ofd = new OpenFileDialog();
            //���݂��Ȃ��t�@�C���̖��O���w�肳�ꂽ�Ƃ��x����\������
            ofd.CheckFileExists = true;
            //�͂��߂ɕ\�������t�H���_���w�肷��
            //ofd.InitialDirectory = @"C:\";
            //[�t�@�C���̎��]�ɕ\�������I�������w�肷��
            //�w�肵�Ȃ��Ƃ��ׂẴt�@�C�����\�������
            ofd.Filter = "CSV�t�@�C��(*.CSV)|*.CSV|���ׂẴt�@�C��(*.*)|*.*";
            //[�t�@�C���̎��]�ł͂��߂ɑI��������
            ofd.FilterIndex = 1;
            //�^�C�g����ݒ肷��
            ofd.Title = fileName + "�t�@�C����I�����Ă�������";
            //�_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���
            ofd.RestoreDirectory = true;

            //���݂��Ȃ��p�X���w�肳�ꂽ�Ƃ��x����\������
            //�f�t�H���g��True�Ȃ̂Ŏw�肷��K�v�͂Ȃ�
            ofd.CheckPathExists = true;

            //�����t�@�C���͑I���_��
            ofd.Multiselect = false;

            //�_�C�A���O��\������
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // ��r���C��
                if (sender == this.MainFolderSelect_button)
                {
                    MainCompfile_Edit.Text = ofd.FileName;
                }
                // ��r�T�u
                else if (sender == this.SubFolderSelect_button)
                {
                    SubCompfile_Edit.Text = ofd.FileName;
                }

            }

        }

        private void OutputFolderSelect_button_Click(object sender, EventArgs e)
        {

            //SaveFileDialog�N���X�̃C���X�^���X���쐬
            SaveFileDialog sfd = new SaveFileDialog();

            //�͂��߂̃t�@�C�������w�肷��
            sfd.FileName = "�`�F�b�N����.csv";
            //�͂��߂ɕ\�������t�H���_���w�肷��
            //sfd.InitialDirectory = @"C:\";
            //[�t�@�C���̎��]�ɕ\�������I�������w�肷��
            sfd.Filter = "CSV�t�@�C��(*.CSV)|*.CSV|���ׂẴt�@�C��(*.*)|*.*";
            //[�t�@�C���̎��]�ł͂��߂ɕ\������ق�
            sfd.FilterIndex = 1;
            //�^�C�g����ݒ肷��
            sfd.Title = Outputfile_label.Text.Trim() + "��I�����Ă�������";
            //�_�C�A���O�{�b�N�X�����O�Ɍ��݂̃f�B���N�g���𕜌�����悤�ɂ���
            sfd.RestoreDirectory = true;
            //���ɑ��݂���t�@�C�������w�肵���Ƃ��x������
            //�f�t�H���g��True�Ȃ̂Ŏw�肷��K�v�͂Ȃ�
            sfd.OverwritePrompt = true;
            //���݂��Ȃ��p�X���w�肳�ꂽ�Ƃ��x����\������
            //�f�t�H���g��True�Ȃ̂Ŏw�肷��K�v�͂Ȃ�
            sfd.CheckPathExists = true;

            //�_�C�A���O��\������
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OK�{�^�����N���b�N���ꂽ�Ƃ�
                //�I�����ꂽ�t�@�C������\������
                Outputfile_Edit.Text = sfd.FileName;
            }
        }

        /// <summary>
        /// �I������
        /// </summary>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        //--XML�쐬�p�B�ӂ��͒ʉ߂��Ȃ�--
        /// <summary>
        ///�@�A�Z���u�����擾����(XML�쐬�p)�@���c�[���Ŗ��g�p
        /// </summary>
        /// <remarks>
        /// <br>Note       : �}�X�^���擾���āA�b�r�u���쐬���܂��B</br>
        /// <br>Programmer  : Miwa Honda</br>
        /// <br>Date        : 2014.08.20</br>
        /// </remarks>
        private void SetCSVFileInfoListInfo()
        {

            CSVFileInfo[] fileInfoList = new CSVFileInfo[] { };

            string filePath = ConstantManagement_ClientDirectory.NSCurrentDirectory + "\\" + this._fileInfoXml;

            //XML�����݂̏ꍇ
            if (UserSettingController.ExistUserSetting(filePath))
            {
                List<CSVFileInfo> a = new List<CSVFileInfo>();

                CSVFileInfo fileInfo = new CSVFileInfo();
                fileInfo.CSVFileNo = 1;
                fileInfo.CSVFileName = "�����c���Ɖ�";
                fileInfo.PrimaryKey = "1,2,3,4,5";
                fileInfo.ComparItem = null;
                fileInfo.SortItem = null;
                fileInfo.HeaderLineExistDiv = true;

                a.Add(fileInfo);

                // XML��������
                UserSettingController.SerializeUserSetting(a, filePath);
            }
        }
    }

    /// public class name:    CSVFileInfo
    /// <summary>
    ///                      CSV�t�@�C�����
    /// </summary>
    /// <remarks>
    /// <br>note             :   CSV�t�@�C�����</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CSVFileInfo
    {

        /// <summary>�Ώۃt�@�C���m�n</summary>
        private int _cSVFileNo = 0;

        /// <summary>�Ώۃt�@�C������</summary>
        private string _cSVFileName = null;

        /// <summary>�v���C�}���[�L�[���</summary>
        private string _primaryKey = null;

        /// <summary>��r���ڏ��<</summary>
        private string _comparItem = "";

        /// <summary>�\�[�g���ڏ��</summary>
        private string _sortItem = null;
        
        /// <summary>�w�b�_�[�s�L���敪</summary>
        private bool _headerLineExistDiv = false;


        /// public propaty name  :  CSVFileName
        /// <summary>�Ώۃt�@�C���m�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// </remarks>
        public int CSVFileNo
        {
            get { return _cSVFileNo; }
            set { _cSVFileNo = value; }
        }

        /// public propaty name  :  CSVFileName
        /// <summary>�Ώۃt�@�C�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// </remarks>
        public string CSVFileName
        {
            get { return _cSVFileName; }
            set { _cSVFileName = value; }
        }

        /// public propaty name  :  PrimaryKey
        /// <summary>�v���C�}���[�L�[���</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v���C�}���[�L�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PrimaryKey
        {
            get { return _primaryKey; }
            set { _primaryKey = value; }
        }

        /// public propaty name  :  ComparItem
        /// <summary>��r���ڏ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��r���ڏ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ComparItem
        {
            get { return _comparItem; }
            set { _comparItem = value; }
        }


        /// public propaty name  :  SortItem
        /// <summary>�\�[�g���ڏ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\�[�g���ڏ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SortItem
        {
            get { return _sortItem; }
            set { _sortItem = value; }
        }

        
         /// public propaty name  :  HeaderLineExistDiv
         /// <summary>�w�b�_�[�s�L���敪�v���p�e�B</summary>
         /// ----------------------------------------------------------------------
         /// <remarks>
         /// <br>note             :   �w�b�_�[�s�L���敪�v���p�e�B</br>
         /// <br>Programer        :   ��������</br>
         /// </remarks>
         public bool HeaderLineExistDiv
         {
             get { return _headerLineExistDiv; }
             set { _headerLineExistDiv = value; }
         }


    }
}