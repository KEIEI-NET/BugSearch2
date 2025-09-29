using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Collections;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Windows.Forms
{
    public partial class PMJKN09011UF : Form
    {
        /// <summary>
        /// ���p�o�^ �t�H�[���N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���p�o�^ �t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.26</br>
        /// <br>UpDate</br>
        /// <br>2010.05.22 ���R RedMine#8049</br>
        /// </remarks>
        //public PMJKN09011UF(ArrayList fspFullRowRestList, ArrayList fspOneRowRestList)// DEL 2010/05/22 GEJUN FOR REDMINE#8049
        public PMJKN09011UF(ArrayList fspFullRowRestList, ArrayList fspOneRowRestList, FreeSearchModel freeSearchModel)// ADD 2010/05/22 GEJUN FOR REDMINE#8049
        {
            InitializeComponent();
            this._fspFullRowRestList = fspFullRowRestList;
            this._fspOneRowRestList = fspOneRowRestList;
            this._freeSearchModel = freeSearchModel;    // ADD 2010/05/22 GEJUN FOR REDMINE#8049
        }

        # region Private Members
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        // ���׍s�S�Ẵf�[�^���X�g
        private ArrayList _fspFullRowRestList;
        // �J�[�\���s�݂̂̃f�[�^
        private ArrayList _fspOneRowRestList;
        // ADD START 2010/05/22 GEJUN FOR REDMINE#8049
        // �r�K�X�L��
        private string _exhaustGasSign;
        // �V���[�Y�^��
        private string _seriesModel;
        // �^���i�ޕʋL���j
        private string _categorySignModel;
        // ���R�����^���f�[�^
        private FreeSearchModel _freeSearchModel;
        // ADD END 2010/05/22 GEJUN FOR REDMINE#8049
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        # endregion

        /// <summary>
        /// ��ʃ��[�h�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        private void PMJKN09011UF_Load(object sender, EventArgs e)
        {
            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.uButton_ModelFullGuide.ImageList = imageList16;
            this.uButton_ModelFullGuide.Appearance.Image = (int)Size16_Index.STAR1;

            this.Ok_Button.ImageList = imageList24;
            this.Cancel_Button.ImageList = imageList24;

            this.Ok_Button.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_Button.Appearance.Image = Size24_Index.CLOSE;
            this.QuoteMode_OptionSet.CheckedIndex = 0;
        }

        /// <summary>
        /// �ۑ��f�[�^�`�F�b�N����
        /// </summary>
        /// <returns></returns>
        private bool CheckSaveData()
        {
            bool flg = true;

            #region ��ʓ��͒l�`�F�b�N
            // �Ԏ�
            if (String.IsNullOrEmpty(this.tEdit_ModelFullName.Text))
            {
                if (this.tNedit_MakerCode.GetInt() == 0
                    && this.tNedit_ModelCode.GetInt() == 0
                    && this.tNedit_ModelSubCode.GetInt() == 0)
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "�Ԏ����͂��ĉ������B",
                        0,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);
                }
                else
                {
                    DialogResult dialogResult = TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "�Ԏ킪���͕s���ł��B",
                        0,
                        MessageBoxButtons.OK,
                        MessageBoxDefaultButton.Button1);
                }

                // �w��t�H�[�J�X�ݒ菈��
                this.tNedit_MakerCode.Focus();

                return false;
            }

            // �^��
            if (String.IsNullOrEmpty(this.tEdit_FullModel.Text))
            {
                DialogResult dialogResult = TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "�^������͂��ĉ������B",
                    0,
                    MessageBoxButtons.OK,
                    MessageBoxDefaultButton.Button1);

                // �w��t�H�[�J�X�ݒ菈��
                this.tEdit_FullModel.Focus();

                return false;
            }

            // �^���̔��f
            if (!String.IsNullOrEmpty(this.tEdit_FullModel.Text))
            {
                string fullModel = this.tEdit_FullModel.Text;

                bool flag = false;
                flag = this.CheckModelName(fullModel);

                if (!flag)
                {
                    this.tEdit_FullModel.Focus();
                    return false;
                }
            }
            #endregion

            return flg;
        }
        #region [�^���i�t���^�j�̔��f]
        /// <summary>
        /// �^���i�t���^�j�̔��f����
        /// </summary>
        /// <param name="fullModels">�^������</param>
        /// <param name="modelName">�^���i�t���^�j</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Programmer : �я���</br>
        /// <br>Date       : 2010/04/30</br>
        /// </remarks>
        private bool CheckModelName(string modelName)
        {
            string msg = string.Empty;

            if (string.IsNullOrEmpty(modelName))
            {
                msg = "�^������͂��ĉ������B";
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
                return false;
            }

            //�^���i�t���^�j
            string[] fullModels = modelName.Split('-');

            //if (fullModels.Length < 3)
            //{
            //    msg = "�^�������͕s���ł��B";
            //    // ���b�Z�[�W��\��
            //    this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
            //    return false;
            //}

            string zrModel = string.Empty;
            string frModel = string.Empty;
            string sdModel = string.Empty;

            //�擪�̗v�f���S���ȏ�̂��߁A��P�v�f�����݂��Ȃ�
            if (fullModels[0].Length >= 4)
            {
                //msg = "�^���O����͂��ĉ������B";
                //// ���b�Z�[�W��\��
                //this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
                //return false;
                frModel = fullModels[0]; // �^���P�ɂ���
                for (int i = 1; i < fullModels.Length; i++)
                {
                    sdModel += fullModels[i];
                    if (i != fullModels.Length - 1)
                    {
                        sdModel += "-";
                    }
                } // �^���Q
            }
            else
            {
                zrModel = fullModels[0]; // �^���O
                if (fullModels.Length > 1)
                {
                    frModel = fullModels[1]; // �^���P
                    for (int i = 2; i < fullModels.Length; i++)
                    {
                        sdModel += fullModels[i];
                        if (i != fullModels.Length - 1)
                        {
                            sdModel += "-";
                        }
                    } // �^���Q
                }
            }

            if (zrModel.Length >= 5)
            {
                msg = "�^���O���S�����ȉ��ɂ��ĉ������B";
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
                return false;
            }
            if (frModel.Length >= 16)
            {
                msg = "�^���P���P�T�����ȉ��ɂ��ĉ������B";
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
                return false;
            }
            if (sdModel.Length >= 16)
            {
                msg = "�^���Q���P�T�����ȉ��ɂ��ĉ������B";
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, msg, 0);
                return false;
            }

            // ADD START 2010/05/22 GEJUN FOR REDMINE#8049

            // �����������ʁA�^���Q��0���̏ꍇ
            if (String.IsNullOrEmpty(sdModel))
            {
                // �^���P�̌�����0���̏ꍇ�́A�^���O���^���P�Ƃ���
                if (String.IsNullOrEmpty(frModel))
                {
                    frModel = zrModel;
                    zrModel = string.Empty;
                }
                // �^���O�����݂��A�^���P�������Ŏn�܂�ꍇ�́A�^���O���^���P�A�^���P���^���Q�Ƃ���
                if (!String.IsNullOrEmpty(zrModel)
                    && (!String.IsNullOrEmpty(frModel) && frModel.ToCharArray()[0] <= '9' && frModel.ToCharArray()[0] >= '0'))
                {
                    sdModel = frModel;
                    frModel = zrModel;
                    zrModel = string.Empty;
                }
            }
            this._exhaustGasSign = zrModel;
            this._seriesModel = frModel;
            this._categorySignModel = sdModel;
            // ADD END 2010/05/22 GEJUN FOR REDMINE#8049
            return true;
        }
        #endregion

        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note        : �G���[���b�Z�[�W�\������</br>
        /// <br>Programmer  : �я���</br>
        /// <br>Date        : 2010.04.26</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel,        // �G���[���x��
                "PMJKN09011UF",      // �A�Z���u���h�c�܂��̓N���X�h�c
                "���p�o�^",            // �v���O��������
                "",         // ��������
                "",         // �I�y���[�V����
                message,       // �\�����郁�b�Z�[�W
                status,        // �X�e�[�^�X�l
                null,         // �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK,     // �\������{�^��
                MessageBoxDefaultButton.Button1); // �����\���{�^��
        }


        /// <summary>
        /// �Ԏ�K�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void uButton_ModelFullGuide_Click(object sender, EventArgs e)
        {
            ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
            ModelNameU modelNameU;
            int makerCode = this.tNedit_MakerCode.GetInt();

            int status = modelNameUAcs.ExecuteGuid2(makerCode, this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt(),
                this._enterpriseCode, out modelNameU);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.tNedit_MakerCode.SetInt(modelNameU.MakerCode);
                this.tNedit_ModelCode.SetInt(modelNameU.ModelCode);
                this.tNedit_ModelSubCode.SetInt(modelNameU.ModelSubCode);
                this.tEdit_ModelFullName.Text = modelNameU.ModelFullName;

                this.tEdit_FullModel.Focus();
            }
        }


        /// <summary>
        /// tNedit_MakerCode_ValueChanged�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tNedit_MakerCode_ValueChanged(object sender, EventArgs e)
        {
            string makerCode = this.tNedit_MakerCode.Text;
            if (string.IsNullOrEmpty(makerCode))
            {
                //�Ԏ��
                this.tNedit_ModelCode.Clear();
                this.tNedit_ModelCode.Enabled = false;
                //�Ԏ�ď̺��
                this.tNedit_ModelSubCode.Clear();
                this.tNedit_ModelSubCode.Enabled = false;
                //�Ԏ햼��
                this.tEdit_ModelFullName.Clear();
            }
            else
            {
                //�Ԏ��
                this.tNedit_ModelCode.Enabled = true;
            }
        }

        /// <summary>
        /// tNedit_ModelCode_ValueChanged�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tNedit_ModelCode_ValueChanged(object sender, EventArgs e)
        {
            string modelCode = this.tNedit_ModelCode.Text;
            if (string.IsNullOrEmpty(modelCode))
            {
                //�Ԏ�ď̺��
                this.tNedit_ModelSubCode.Clear();
                this.tNedit_ModelSubCode.Enabled = false;
                //�Ԏ햼��
                this.tEdit_ModelFullName.Clear();
            }
            else
            {
                //�Ԏ�ď̺��
                this.tNedit_ModelSubCode.Enabled = true;
            }
        }

        /// <summary>
        /// tNedit_ModelSubCode_ValueChanged�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tNedit_ModelSubCode_ValueChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tNedit_ModelSubCode.Text))
            {
                //�Ԏ햼��
                this.tEdit_ModelFullName.Clear();
            }
        }

        /// <summary>
        /// tNedit_ModelSubCode_AfterExitEditMode�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tNedit_ModelSubCode_AfterExitEditMode(object sender, EventArgs e)
        {
            TNedit tNedit = (TNedit)sender;// ADD 2010/05/22 GEJUN FOR REDMINE#8049
            //��Ұ�����
            string makerCode = this.tNedit_MakerCode.Text;
            //�Ԏ��
            string modelCode = this.tNedit_ModelCode.Text;
            //�Ԏ�ď̺��
            string modelSubCode = this.tNedit_ModelSubCode.Text;
            MakerAcs makerAcs = new MakerAcs();// ADD 2010/05/22 GEJUN FOR REDMINE#8049
            ModelNameUAcs modelNameUAcs = new ModelNameUAcs();
            MakerUMnt makerUMnt; // ADD 2010/05/22 GEJUN FOR REDMINE#8049
            ModelNameU modelNameU;
            // DEL START 2010/05/22 GEJUN FOR REDMINE#8049
            //if (!string.IsNullOrEmpty(makerCode) && !string.IsNullOrEmpty(modelCode) && !string.IsNullOrEmpty(modelSubCode))
            //{
            //    int status = modelNameUAcs.Read(out modelNameU, this._enterpriseCode, this.tNedit_MakerCode.GetInt(), this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt());
            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    {
            //        this.tEdit_ModelFullName.Text = modelNameU.ModelFullName;
            //    }
            //}
            // DEL END 2010/05/22 GEJUN FOR REDMINE#8049
            // ADD START 2010/05/22 GEJUN FOR REDMINE#8049
            if (!string.IsNullOrEmpty(makerCode))
            {
                if ((this.tNedit_MakerCode.GetInt() != 0) && (this.tNedit_ModelCode.GetInt() == 0))
                {
                    //���[�J�[�f�[�^�̎擾
                    int status = makerAcs.Read(out makerUMnt, this._enterpriseCode, this.tNedit_MakerCode.GetInt());
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        //���[�J�[
                        this.tNedit_MakerCode.SetInt(makerUMnt.GoodsMakerCd);
                        this.tEdit_ModelFullName.Text = makerUMnt.MakerName;
                    }
                    else
                    {
                        TMsgDisp.Show(this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "�Y���f�[�^������܂���B",
                           -1,
                           MessageBoxButtons.OK);
                        tNedit.Clear();
                        tNedit.Focus();
                    }
                }
                else if (this.tNedit_ModelCode.GetInt() != 0)
                {
                    int status = modelNameUAcs.Read(out modelNameU, this._enterpriseCode, this.tNedit_MakerCode.GetInt(), this.tNedit_ModelCode.GetInt(), this.tNedit_ModelSubCode.GetInt());
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.tEdit_ModelFullName.Text = modelNameU.ModelFullName;
                        if (modelNameU.ModelCode != 0)
                        {
                            this.tNedit_ModelCode.Text = modelNameU.ModelCode.ToString("000");
                        }
                        if (modelNameU.ModelSubCode != 0)
                        {
                            this.tNedit_ModelSubCode.Text = modelNameU.ModelSubCode.ToString("000");
                        }
                    }
                    else
                    {
                        TMsgDisp.Show(this,
                           emErrorLevel.ERR_LEVEL_INFO,
                           this.Name,
                           "�Y���f�[�^������܂���B",
                           -1,
                           MessageBoxButtons.OK);
                        tNedit.Clear();
                        tNedit.Focus();
                    }
                }
            }
            // ADD END 2010/05/22 GEJUN FOR REDMINE#8049
        }

        /// <summary>
        /// ����{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// �ۑ��{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void Ok_Button_Click(object sender, EventArgs e)
        {
            if (CheckSaveData())
            {

                if (this._fspFullRowRestList.Count > 0 && this._fspOneRowRestList.Count > 0)
                {
                    FreeSearchPartsAcs freeSearchPartsAcs = new FreeSearchPartsAcs();
                    ArrayList retList = new ArrayList();
                    if (this.QuoteMode_OptionSet.CheckedIndex == 0)
                    {
                        foreach (FreeSearchParts freeSearchPartsPara in this._fspFullRowRestList)
                        {
                            //���[�J�[�R�[�h			��ʎ��q���		 ��Ұ�����ނ��
                            freeSearchPartsPara.MakerCode = this.tNedit_MakerCode.GetInt();
                            //�Ԏ�R�[�h			��ʎ��q���		�Ԏ��ނ��
                            freeSearchPartsPara.ModelCode = this.tNedit_ModelCode.GetInt();
                            //�Ԏ�T�u�R�[�h			��ʎ��q���		�Ԏ�ď̺��ނ��
                            freeSearchPartsPara.ModelSubCode = this.tNedit_ModelSubCode.GetInt();
                            //�^���i�t���^�j			��ʎ��q���		�^�����
                            freeSearchPartsPara.FullModel = this.tEdit_FullModel.Text;
                            //UpdateDateTime
                            freeSearchPartsPara.UpdateDateTime = DateTime.MinValue;
                            //���R�������i�ŗL�ԍ�
                            freeSearchPartsPara.FreSrchPrtPropNo = Guid.NewGuid().ToString().Replace("-", "");
                            retList.Add(freeSearchPartsPara);
                        }
                    }
                    else
                    {
                        foreach (FreeSearchParts freeSearchPartsPara in this._fspOneRowRestList)
                        {
                            //���[�J�[�R�[�h			��ʎ��q���		 ��Ұ�����ނ��
                            freeSearchPartsPara.MakerCode = this.tNedit_MakerCode.GetInt();
                            //�Ԏ�R�[�h			��ʎ��q���		�Ԏ��ނ��
                            freeSearchPartsPara.ModelCode = this.tNedit_ModelCode.GetInt();
                            //�Ԏ�T�u�R�[�h			��ʎ��q���		�Ԏ�ď̺��ނ��
                            freeSearchPartsPara.ModelSubCode = this.tNedit_ModelSubCode.GetInt();
                            //�^���i�t���^�j			��ʎ��q���		�^�����
                            freeSearchPartsPara.FullModel = this.tEdit_FullModel.Text;
                            //UpdateDateTime
                            freeSearchPartsPara.UpdateDateTime = DateTime.MinValue;
                            //���R�������i�ŗL�ԍ�
                            freeSearchPartsPara.FreSrchPrtPropNo = Guid.NewGuid().ToString().Replace("-", "");
                            retList.Add(freeSearchPartsPara);
                        }

                    }
                    int status = freeSearchPartsAcs.Write(ref retList);

                    // ADD START 2010/05/22 GEJUN FOR REDMINE#8049
                    // ��ʏ�񎩗R�����^���}�X�^�̍X�V
                    this._freeSearchModel.LogicalDeleteCode = 0;
                    this._freeSearchModel.EnterpriseCode = this._enterpriseCode;
                    this._freeSearchModel.FreeSrchMdlFxdNo = Guid.NewGuid().ToString().Replace("-", "");
                    this._freeSearchModel.MakerCode = this.tNedit_MakerCode.GetInt(); //���[�J�[�R�[�h
                    this._freeSearchModel.ModelCode = this.tNedit_ModelCode.GetInt(); // �Ԏ�R�[�h
                    this._freeSearchModel.ModelSubCode = this.tNedit_ModelSubCode.GetInt(); // �Ԏ�T�u�R�[�h
                    this._freeSearchModel.FullModel = this.tEdit_FullModel.Text.ToUpper(); // �^���i�t���^�j
                    this._freeSearchModel.ExhaustGasSign = this._exhaustGasSign;
                    this._freeSearchModel.SeriesModel = this._seriesModel;
                    this._freeSearchModel.CategorySignModel = this._categorySignModel;
                    // �쐬���t
                    int createDate = TDateTime.DateTimeToLongDate("YYYYMMDD", DateTime.Now);
                    this._freeSearchModel.CreateDate = createDate;
                    // �X�V�N����
                    this._freeSearchModel.UpdateDate = createDate;

                    FreeSearchModelAcs freeSearchModelAcs = new FreeSearchModelAcs();
                    freeSearchModelAcs.Write(ref _freeSearchModel);
                    // ADD END 2010/05/22 GEJUN FOR REDMINE#8049
                    //ADD START 2009/05/22 GEJUN FOR REDMINE#8049
                    SaveCompletionDialog dialog = new SaveCompletionDialog();
                    dialog.ShowDialog(2);
                    //ADD END 2009/05/22 GEJUN FOR REDMINE#8049

                }
                this.Close();
            }
        }

        /// <summary>
        /// �c�[���o�[�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null) return;

            switch (e.PrevCtrl.Name)
            {
                case "tEdit_FullModel":
                    {
                        this.tEdit_FullModel.Text = this.tEdit_FullModel.Text.ToUpper();
                        break;
                    }
            }
        }
    }
}