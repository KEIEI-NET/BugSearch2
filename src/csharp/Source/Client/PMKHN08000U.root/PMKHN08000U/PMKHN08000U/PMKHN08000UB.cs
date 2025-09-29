//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PMNS�C���|�[�g�ҋ@���
// �v���O�����T�v   : PM.NS�̃C���|�[�g���ɑҋ@���[�h��ǉ���PM7SP���̏I���t�@�C����
//                  : �Ď����Ď����Ŏ�荞�߂�悤�ɂ��܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
						

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Broadleaf.Library.Windows.Forms;
using System.IO;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// PMNS�C���|�[�g�ҋ@�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : PMNS�C���|�[�g�ҋ@�t�H�[���N���X�ł��B</br>
    /// <br>Programmer  : ���E</br>
    /// <br>Date        : 2012/11/09</br>
    /// </remarks>
    public partial class PMKHN08000UB : Form
    {
        #region �� �R���X�g���N�^ ��
        /// <summary>
        /// PMNS�C���|�[�g�ҋ@�t�H�[���N���X
        /// </summary>
        /// <remarks>
        /// <br>Note        : PMNS�C���|�[�g�ҋ@�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : zhangy3</br>
        /// <br>Date        : 2012/11/09</br>
        /// </remarks>
        public PMKHN08000UB(string convPath,bool convertRowSelectedFlg)
        {
            InitializeComponent();
            this._serverPath = convPath;
            if (!this._serverPath.EndsWith("\\"))
            {
                this._serverPath += "\\";
            }
            this.convertRowSelectedFlg = convertRowSelectedFlg;
        }

        #endregion

        #region  �� Private Members

        private bool convertRowSelectedFlg = true;//�R���o�[�g�Ώۂ�I�������t���O
        private int _preSelType = 0;//�C���|�[�g�t�@�C��
        private string _serverPath;//�C���|�[�g���i�[�p�X
        private string[] _fileLst;//�t�@�C�����X�g
        private Dictionary<int, string> Dic_DelModel = new Dictionary<int, string>();//�폜���b�Z�b�W�̏W��
        private const string ctPGID = "PMKHN08000UB";//PGID
        private string EndFileName = "ConvertEnd.csv"; //�I���t�@�C��
        private string Message_Info = "�����G�N�X�|�[�g�I���t�@�C�������݂��܂��B\r\n�C���|�[�g�����������ɊJ�n���܂����H";//���b�Z�b�W
        private string DelModel0 = "�m�r�C���|�[�g��ʎw������ɏ]���폜���܂��B";//�폜���b�Z�b�W
        private string DelModel1 = "�C���|�[�g�������s�����̂���ʎw������ɏ]���폜���܂��B";//�폜���b�Z�b�W
        private string Message_NoSelect = "�R���o�[�g�Ώۂ�I��ŉ������B";

        #endregion 

        # region �� Public Properties

        /// <summary>
        /// �t�@�C�����X�g
        /// </summary>
        public string[] FileLst
        {
            get
            {
                return this._fileLst;
            }
            set
            {
                this._fileLst = value;
            }
        }

        /// <summary>
        /// �����̃��W���b��
        /// </summary>
        public int SelModelType
        {
            get
            {
                return this._preSelType;
            }
            set
            {
                this._preSelType = value;
            }
        }

        # endregion

        #region  �� Private Methods

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ����������B</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private void InitConstruction()
        {
            Dic_DelModel.Add(0, DelModel0);
            Dic_DelModel.Add(1, DelModel1);
            this.comb_FileImport.SelectedIndex = 0;
            ultraLabel_Message.Visible = false;
            this.comb_FileImport.Focus();
        }

        /// <summary>
        /// �I���t�@�C�������݂��邩�ǂ���
        /// </summary>
        /// <returns>ture:����,false:���݂��܂���</returns>
        /// <remarks>
        /// <br>Note       : �I���t�@�C�������݂��܂����B</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private bool IsEndFileExcisted()
        {
            //�Ď��̃p�X
            string path = this._serverPath + EndFileName;
            //�t�H���_���Ď�����
            if (File.Exists(path))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// ConvertEnd.csv���w��t�H���_�Ɉړ�����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : ConvertEnd.csv���w��t�H���_�Ɉړ�����B</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private bool FileReName()
        {
            try
            {
                string newFileNm = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string fileDir = this._serverPath+"\\" + newFileNm+"\\";
                if (!Directory.Exists(fileDir))
                {
                    Directory.CreateDirectory(fileDir);
                }
                Directory.Move(this._serverPath + EndFileName, fileDir + EndFileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// ConvertEnd.csv�̓��e��ǂݍ���
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ConvertEnd.csv�̓��e��ǂݍ��݁B</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private bool FileRead()
        {
            try
            {
                StringBuilder strBulider = new StringBuilder();
                FileStream fileStream = new FileStream(this._serverPath + EndFileName, FileMode.Open);
                StreamReader stream = new StreamReader(fileStream);
                string str = stream.ReadLine();
                while (!string.IsNullOrEmpty(str))
                {
                    strBulider.Append(str);
                    str = stream.ReadLine();
                }
                str = strBulider.ToString();
                stream.Close();
                if (!string.IsNullOrEmpty(str))
                {

                    List<string> lst = new List<string>();
                    lst.AddRange(str.Split(','));
                    this._fileLst = lst.FindAll(delegate(string x)
                     {
                         if (string.IsNullOrEmpty(x))
                         {
                             return false;
                         }
                         else
                         {
                             return true;
                         }
                     }).ToArray();
                }
                stream.Close();
                fileStream.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        #endregion

        #region �� �C�x���g

        /// <summary>
        /// ��ʂ̃��[�h
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ��ʂ����[�h����B</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private void PmNsWait_Load(object sender, EventArgs e)
        {
            InitConstruction();
        }

        /// <summary>
        /// �莞����
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �莞�@�C�x���g�����B</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private void timer_StartWait_Tick(object sender, EventArgs e)
        {
            if (IsEndFileExcisted())
            {
                timer_StartWait.Enabled = false;
                if (FileRead())
                {
                    if (FileReName())
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        ultraLabel_Message.Visible = false;
                    }
                }
                else
                {
                    ultraLabel_Message.Visible = false;
                }
            }
        }

        /// <summary>
        /// �ҋ@�{�^���̃C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       :  �ҋ@�{�^���̃C�x���g�B</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private void ultraButton_Wait_Click(object sender, EventArgs e)
        {
            DialogResult result;
            bool flg = true;
            if (this.comb_FileImport.SelectedIndex == 0)
            {
                if (!convertRowSelectedFlg)
                {
                    TMsgDisp.Show(
                                 this, 								            // �e�E�B���h�E�t�H�[��
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                 ctPGID, 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                 Message_NoSelect,     // �\�����郁�b�Z�[�W
                                 0, 									            // �X�e�[�^�X�l
                                 MessageBoxButtons.OK, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            ultraLabel_Message.Visible = true;
            try
            {
                //�I���t�@�C�������݂��邩�ǂ���
                if (IsEndFileExcisted())
                {
                    result = TMsgDisp.Show(
                                 this, 								            // �e�E�B���h�E�t�H�[��
                                 emErrorLevel.ERR_LEVEL_QUESTION, 		    // �G���[���x��
                                 ctPGID, 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                 Message_Info,     // �\�����郁�b�Z�[�W
                                 0, 									            // �X�e�[�^�X�l
                                 MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        //ConvertEnd.csv�̓��e��ǂݍ���
                        if (FileRead())
                        {
                            //ConvertEnd.csv���X������
                            if (FileReName())
                            {
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                            else
                            {
                                flg = false;
                            }
                        }
                        else
                        {
                            flg = false;
                        }
                    }
                    else
                    {
                        //ConvertEnd.csv���X������
                        if(FileReName())
                            this.timer_StartWait.Enabled = true;
                        else
                            flg = false;
                    }
                }
                else
                {
                    this.timer_StartWait.Enabled = true;
                }
                ultraLabel_Message.Visible = flg;
            }
            catch
            {

            }
        }

        /// <summary>
        /// �L�����Z���{�^���̃C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �L�����Z���{�^���̃C�x���g�B</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private void ultraButton_Cancel_Click(object sender, EventArgs e)
        {
            
            ultraLabel_Message.Visible = false;
            this.timer_StartWait.Enabled = false;
        }

        /// <summary>
        /// �C���|�[�g�t�@�C����Index�ύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �C���|�[�g�t�@�C����Index�ύX�C�x���g�B</br>
        /// <br>Programer  : zhangy3</br>
        /// <br>Date       : 2012/11/09</br>
        /// </remarks>
        private void comb_FileImport_SelectedIndexChanged(object sender, EventArgs e)
        {
            this._preSelType = this.comb_FileImport.SelectedIndex;
            ultraLabel_DelText.Text = Dic_DelModel[this._preSelType].ToString();
        }

        #endregion 
    }
}