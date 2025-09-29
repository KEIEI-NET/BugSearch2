//********************************************************************//
// System           :   PM.NS                                         //
// Sub System       :                                                 //
// Program name     :   ����A�g�ݒ�t�H�[���N���X                    //
//                  :   PMSCM09070UA.DLL                              //
// Name Space       :   Broadleaf.Windows.Forms                       //
// Programmer       :   gaoy                                          //
// Date             :   2011.07.21                                    //
//--------------------------------------------------------------------//
// Update Note      :                                                 //
//--------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.               //
//********************************************************************//

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ����A�g�ݒ�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ����A�g�ݒ�̐ݒ���s���܂��B</br>
    /// <br>Programmer       :   gaoy</br>
    /// <br>Date             :   2011/7/21</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public partial class PMSCM09070UA : Form, IMasterMaintenanceSingleType
    {

        #region << Conductor >>

        /// <summary>
        /// ����A�g�ݒ�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>note             :   ����A�g�ݒ�t�H�[���N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer       :   gaoy</br>
        /// <br>Date             :   2011/7/21</br>
        /// </remarks>
        public PMSCM09070UA()
        {

            InitializeComponent();

            //����A�g�ݒ�e�[�u���A�N�Z�X�N���X
            this._pm7RkSettingAcs = new PM7RkSettingAcs();
            //����A�g�ݒ�UI�N���X
            this._pm7RkSetting = new PM7RkSetting();
            this._pm7RkSettingDataSet = new PM7RkSetting();

            //��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            //���_�R�[�h�擾
            this._sectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;

            this._pm7RkSetting.EnterpriseCode = this._enterpriseCode;
            this._pm7RkSetting.SectionCode = this._sectionCode;

            // ��r�p�N���[��
            this._pm7RkSettingClone = null;

            // �v���p�e�B�̏����ݒ�
            this._canPrint = false;
            this._canClose = false;

        }

        #endregion

        #region << Private Members >>

        private PM7RkSettingAcs _pm7RkSettingAcs;   //����A�g�ݒ�e�[�u���A�N�Z�X�N���X
        private PM7RkSetting _pm7RkSetting;         //����A�g�ݒ�f�[�^�N���X
        private PM7RkSetting _pm7RkSettingDataSet;  //����A�g�ݒ�f�[�^�N���X

        private string _enterpriseCode;             //��ƃR�[�h
        private string _sectionCode;                 //���_�R�[�h

        // ��r�p�N���[��
        private PM7RkSetting _pm7RkSettingClone;    //��r�p����A�g�ݒ�f�[�^�N���X

        // �v���p�e�B�p
        private bool _canPrint;
        private bool _canClose;

        private const string HTML_HEADER_TITLE = "�ݒ荀��";
        private const string HTML_HEADER_VALUE = "�ݒ�l";
        private const string HTML_UNREGISTER = "���ݒ�";

        // �ҏW���[�h
        private const string UPDATE_MODE1 = "�V�K���[�h";
        private const string UPDATE_MODE2 = "�X�V���[�h";

        private const string CT_PGID = "PMSCM09070U";
        private const string CT_PGNM = "����A�g�S�̐ݒ�";

        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        #endregion

        #region << Events >>

        /// <summary>
        /// ��ʔ�\���C�x���g
        /// </summary>
        /// <remarks>
        /// ��ʂ���\����ԂɂȂ����ۂɔ������܂��B
        /// </remarks>
        public event MasterMaintenanceSingleTypeUnDisplayingEventHandler UnDisplaying;

        # endregion

        #region << Properties >>

        /// <summary>
        /// ����v���p�e�B
        /// </summary>
        /// <remarks>
        /// ����\���ǂ����̐ݒ���擾���܂��B�ifalse�Œ�j
        /// </remarks>
        public bool CanPrint
        {
            get { return _canPrint; }
        }

        /// <summary>
        /// ��ʃN���[�Y�v���p�e�B
        /// </summary>
        /// <remarks>
        /// ��ʃN���[�Y�������邩�ǂ����̐ݒ���擾�܂��͐ݒ肵�܂��B
        /// false�̏ꍇ�́A��ʂ����ہAClose�ł͂Ȃ�Hide(��\��)�����s���܂��B
        /// </remarks>
        public bool CanClose
        {
            get { return _canClose; }
            set { _canClose = value; }
        }

        #endregion

        #region << Public Methods >>

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ������</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        public int Print()
        {
            return 0;

        }

        /// <summary>
        /// HTML�R�[�h�擾
        /// </summary>
        /// <returns>HTML�R�[�h</returns>
        /// <remarks>
        /// <br>Note       : HTML�R�[�h�̎擾���s���܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        public string GetHtmlCode()
        {
            const string ctPROCNM = "GetHtmlCode";
            string outCode = "";

            List<string> titleList = new List<string>();
            List<string> valueList = new List<string>();

            titleList.Add(HTML_HEADER_TITLE);               //�u�ݒ荀�ځv
            valueList.Add(HTML_HEADER_VALUE);               //�u�ݒ�l�v
            titleList.Add(this.SalesRkAutoCode_ultraLabel.Text);     //����A�g�����敪
            titleList.Add(this.SalesRkAutoSndTime_ultraLabel.Text);  //����A�g�������M�Ԋu
            titleList.Add(this.MasterRkAutoCode_ultraLabel.Text);    //�}�X�^�A�g�����敪
            titleList.Add(this.MasterRkAutoRcvTime_ultraLabel.Text); //�}�X�^�A�g������M�Ԋu
            titleList.Add(this.TextSaveFolder_ultraLabel.Text);          //�e�L�X�g�i�[�t�H���_

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = this._pm7RkSettingAcs.Read(ref this._pm7RkSetting);
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        if (this._pm7RkSetting != null)
                        {
                            this._pm7RkSettingDataSet = this._pm7RkSetting.Clone();

                            valueList.Add(this.SalesRkAutoCode_tComboEditor.Items.GetItem(this._pm7RkSetting.SalesRkAutoCode).ToString());
                            if (this._pm7RkSetting.SalesRkAutoCode == 1)
                            {
                                valueList.Add(this._pm7RkSetting.SalesRkAutoSndTime.ToString()+"��");
                            }
                            else
                            { 
                                valueList.Add("");
                            }
                            valueList.Add(this.MasterRkAutoCode_tComboEditor.Items.GetItem(this._pm7RkSetting.MasterRkAutoCode).ToString());
                            if (this._pm7RkSetting.MasterRkAutoCode == 1)
                            {
                                valueList.Add(this._pm7RkSetting.MasterRkAutoRcvTime.ToString() + "��");
                            }
                            else
                            {
                                valueList.Add("");
                            }
                            valueList.Add(this._pm7RkSetting.TextSaveFolder);
                        }
                        else
                        {
                            valueList.Add("���Ȃ�");
                            valueList.Add(HTML_UNREGISTER);
                            valueList.Add("���Ȃ�");
                            valueList.Add(HTML_UNREGISTER);
                            valueList.Add(HTML_UNREGISTER);
                        }
                        break;

                    }
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    {
                        valueList.Add("���Ȃ�");
                        valueList.Add(HTML_UNREGISTER);
                        valueList.Add("���Ȃ�");
                        valueList.Add(HTML_UNREGISTER);
                        valueList.Add(HTML_UNREGISTER);
                        break;
                    }
                default:
                    {
                        //���[�h
                        TMsgDisp.Show(
                            this,                                 // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,          // �G���[���x��
                            CT_PGID,                              // �A�Z���u���h�c�܂��̓N���X�h�c
                            CT_PGNM,                              // �v���O��������
                            ctPROCNM,                             // ��������
                            TMsgDisp.OPE_READ,                    // �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B",           // �\�����郁�b�Z�[�W
                            status,                               // �X�e�[�^�X�l
                            this._pm7RkSettingAcs,                 // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,                 // �\������{�^��
                            MessageBoxDefaultButton.Button1);     // �����\���{�^��

                        // ���ݒ�
                        valueList.Add("���Ȃ�");
                        valueList.Add(HTML_UNREGISTER);
                        valueList.Add("���Ȃ�");
                        valueList.Add(HTML_UNREGISTER);
                        valueList.Add(HTML_UNREGISTER);

                        break;
                    }
            }

            this.tHtmlGenerate1.Coltypes = new int[2];
            this.tHtmlGenerate1.Coltypes[0] = this.tHtmlGenerate1.ColtypeString;
            this.tHtmlGenerate1.Coltypes[1] = this.tHtmlGenerate1.ColtypeString;

            string[,] array = new string[titleList.Count, 2];

            for (int ix = 0; ix < array.GetLength(0); ix++)
            {
                array[ix, 0] = titleList[ix];
                array[ix, 1] = valueList[ix];
            }

            this.tHtmlGenerate1.ShowArrayStringtoGridwithProperty(array, ref outCode);

            return outCode;
        }

        #endregion

        #region << Private Methods >>

        /// <summary>
        /// �f�[�^�ҏW��ʏ����ݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note       : UI��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void ScreenInitialSetting()
        {
            //����A�g�����敪
            this.SalesRkAutoCode_tComboEditor.Items.Clear();
            this.SalesRkAutoCode_tComboEditor.Items.Add(0, "���Ȃ�");
            this.SalesRkAutoCode_tComboEditor.Items.Add(1, "����");
            this.SalesRkAutoCode_tComboEditor.MaxDropDownItems = this.SalesRkAutoCode_tComboEditor.Items.Count;
            this.SalesRkAutoCode_tComboEditor.SelectedIndex = 0;

            //�}�X�^�A�g�����敪
            this.MasterRkAutoCode_tComboEditor.Items.Clear();
            this.MasterRkAutoCode_tComboEditor.Items.Add(0, "���Ȃ�");
            this.MasterRkAutoCode_tComboEditor.Items.Add(1, "����");
            this.MasterRkAutoCode_tComboEditor.MaxDropDownItems = this.SalesRkAutoCode_tComboEditor.Items.Count;
            this.MasterRkAutoCode_tComboEditor.SelectedIndex = 0;

            //�e�L�X�g�i�[�t�H���_IME���[�h
            this.TextSaveFolder_tEdit.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
        }

        /// <summary>
        /// ��ʏ�񔄏�A�g�ݒ�N���X�i�[����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂甄��A�g�ݒ�N���X�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void ScreenToPM7RkSetting()
        {
            if (this._pm7RkSetting == null)
            {
                this._pm7RkSetting = new PM7RkSetting();
            }

            //����A�g�����敪
            if (this.SalesRkAutoCode_tComboEditor.Value != null)
            {
                this._pm7RkSetting.SalesRkAutoCode = this.SalesRkAutoCode_tComboEditor.SelectedIndex;
            }

            //����A�g�������M�Ԋu
            try
            {
                if (this.SalesRkAutoSndTime_tEdit.Text.Trim() == "")
                {
                    this._pm7RkSetting.SalesRkAutoSndTime = 0; 
                }
                else
                {
                    this._pm7RkSetting.SalesRkAutoSndTime = Convert.ToInt64(this.SalesRkAutoSndTime_tEdit.Text.Trim());
                }
            }
            catch (Exception)
            {
                this._pm7RkSetting.SalesRkAutoSndTime = 0;
            }

            //�}�X�^�A�g�����敪
            if (this.MasterRkAutoCode_tComboEditor.Value != null)
            {
                this._pm7RkSetting.MasterRkAutoCode = this.MasterRkAutoCode_tComboEditor.SelectedIndex;
            }

            //�}�X�^�A�g������M�Ԋu
            try
            {
                if (this.MasterRkAutoRcvTime_tEdit.Text.Trim() == "")
                {
                    this._pm7RkSetting.MasterRkAutoRcvTime = 0;
                }
                else
                {
                    this._pm7RkSetting.MasterRkAutoRcvTime = Convert.ToInt64(this.MasterRkAutoRcvTime_tEdit.Text.Trim());
                }
            }
            catch (Exception)
            {
                this._pm7RkSetting.MasterRkAutoRcvTime = 0;
            }

            //�e�L�X�g�i�[�t�H���_
            this._pm7RkSetting.TextSaveFolder = this.TextSaveFolder_tEdit.Text.TrimEnd();
        }

        /// <summary>
        /// ��ʏ�񔄏�A�g�ݒ�N���X�i�[����(�`�F�b�N�p)
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʏ�񂩂甄��A�g�ݒ�N���X�Ƀf�[�^���i�[���܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void DispToPM7RkSetting(ref PM7RkSetting pm7RkSetting)
        {
            if (pm7RkSetting == null)
            {
                pm7RkSetting = new PM7RkSetting();
            }

            //����A�g�����敪
            if (this.SalesRkAutoCode_tComboEditor.Value != null)
            {
                pm7RkSetting.SalesRkAutoCode = this.SalesRkAutoCode_tComboEditor.SelectedIndex;
            }

            //����A�g�������M�Ԋu
            try
            {
                if (this.SalesRkAutoSndTime_tEdit.Text.Trim() == "")
                {
                    pm7RkSetting.SalesRkAutoSndTime = 0;
                }
                else
                {
                    pm7RkSetting.SalesRkAutoSndTime = Convert.ToInt64(this.SalesRkAutoSndTime_tEdit.Text.TrimEnd());
                }
            }
            catch (Exception)
            {
                pm7RkSetting.SalesRkAutoSndTime = 0;
            }

            //�}�X�^�A�g�����敪
            if (this.MasterRkAutoCode_tComboEditor.Value != null)
            {
                pm7RkSetting.MasterRkAutoCode = this.MasterRkAutoCode_tComboEditor.SelectedIndex;
            }

            //�}�X�^�A�g������M�Ԋu
            try
            {
                if (this.MasterRkAutoRcvTime_tEdit.Text.Trim() == "")
                {
                    pm7RkSetting.MasterRkAutoRcvTime = 0;
                }
                else
                {
                    pm7RkSetting.MasterRkAutoRcvTime = Convert.ToInt64(this.MasterRkAutoRcvTime_tEdit.Text.TrimEnd());
                }
            }
            catch (Exception)
            {
                pm7RkSetting.MasterRkAutoRcvTime = 0;
            }
            //�e�L�X�g�i�[�t�H���_
            pm7RkSetting.TextSaveFolder = this.TextSaveFolder_tEdit.Text.TrimEnd();
           
        }

        /// <summary>
        /// ��ʓW�J����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����A�g�ݒ�N���X�����ʂɃf�[�^��W�J���܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void PM7RkSettingToScreen()
        {
            //����A�g�����敪
            this.SalesRkAutoCode_tComboEditor.SelectedIndex = this._pm7RkSetting.SalesRkAutoCode;
            
            //����A�g�������M�Ԋu
            if (this._pm7RkSetting.SalesRkAutoCode == 1)
            {
                this.SalesRkAutoSndTime_tEdit.Text = this._pm7RkSetting.SalesRkAutoSndTime.ToString();
            }
            else 
            {
                this.SalesRkAutoSndTime_tEdit.Text = "";
            }
            
            //�}�X�^�A�g�����敪
            this.MasterRkAutoCode_tComboEditor.SelectedIndex = this._pm7RkSetting.MasterRkAutoCode;

            //�}�X�^�A�g������M�Ԋu
            if (this._pm7RkSetting.MasterRkAutoCode == 1)
            {
                this.MasterRkAutoRcvTime_tEdit.Text = this._pm7RkSetting.MasterRkAutoRcvTime.ToString();
            }
            else
            {
                this.MasterRkAutoRcvTime_tEdit.Text = ""; 
            }
            
            //�e�L�X�g�i�[�t�H���_
            this.TextSaveFolder_tEdit.Text = this._pm7RkSetting.TextSaveFolder;

        }


        /// <summary>
        /// ��ʃN���A����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��N���A���܂�</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void ScreenClear()
        {
            this.SalesRkAutoSndTime_tEdit.Clear();
            this.MasterRkAutoRcvTime_tEdit.Clear();
            this.TextSaveFolder_tEdit.Clear();
        }

        /// <summary>
        /// ��ʍč\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ��č\�z�������܂�</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void ScreenReconstruction()
        {
            if (this._pm7RkSettingDataSet == null)
            {
                this.Mode_ultraLabel.Text = UPDATE_MODE1;   //�V�K���[�h

                this.SalesRkAutoCode_tComboEditor.SelectedIndex = 0;
                this.SalesRkAutoSndTime_tEdit.Text = "";
                this.MasterRkAutoCode_tComboEditor.SelectedIndex = 0;
                this.MasterRkAutoRcvTime_tEdit.Text = "";
                this.TextSaveFolder_tEdit.Text = "";

                // �����t�H�[�J�X���Z�b�g
                this.SalesRkAutoCode_tComboEditor.Focus();

                this._pm7RkSetting = new PM7RkSetting();

                // ��r�p�N���[���쐬
                this._pm7RkSettingClone = this._pm7RkSetting.Clone();
                // ��ʏ����r�p�N���[���ɃR�s�[
                this.DispToPM7RkSetting(ref this._pm7RkSettingClone);

            }

            this.Mode_ultraLabel.Text = UPDATE_MODE2;   //�X�V���[�h

            this._pm7RkSetting = this._pm7RkSettingDataSet.Clone();

            //��ʓW�J����
            this.PM7RkSettingToScreen();

            // �����t�H�[�J�X���Z�b�g
            this.SalesRkAutoCode_tComboEditor.Focus();

            // ��r�p�N���[���쐬
            this._pm7RkSettingClone = this._pm7RkSetting.Clone();
            // ��ʏ����r�p�N���[���ɃR�s�[
            this.DispToPM7RkSetting(ref this._pm7RkSettingClone);

        }

        /// <summary>
        /// ��ʂ̃f�[�^�`�F�b�N
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʍ��ڂ̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private bool ScreenDataCheck(ref Control control, ref string errorMessage)
        {
            bool result = false;
            //�K�{���̓`�F�b�N
            //����A�g�������M�Ԋu�����K�{
            if (this.SalesRkAutoCode_tComboEditor.Text == "����")
            {
                if (this.SalesRkAutoSndTime_tEdit.Text.Trim() == "")
                {
                    control = this.SalesRkAutoSndTime_tEdit;
                    errorMessage = this.SalesRkAutoSndTime_ultraLabel.Text + "����͂��ĉ������B";
                    return result;
                }
            }
            //�}�X�^�A�g������M�Ԋu�����K�{
            if (this.MasterRkAutoCode_tComboEditor.Text == "����")
            {
                if (this.MasterRkAutoRcvTime_tEdit.Text.Trim() == "")
                {
                    control = this.MasterRkAutoRcvTime_tEdit;
                    errorMessage = this.MasterRkAutoRcvTime_ultraLabel.Text + "����͂��ĉ������B";
                    return result;
                }
            }
            //�e�L�X�g�i�[�t�H���_�K�{���̓`�F�b�N
            if (this.TextSaveFolder_tEdit.Text.Trim() == "")
            {
                control = this.TextSaveFolder_tEdit;
                errorMessage = this.TextSaveFolder_ultraLabel.Text + "����͂��ĉ������B";
                return result;
            }

            //����A�g�������M�Ԋu
            if (this.SalesRkAutoCode_tComboEditor.Text == "����")
            {
                try
                {
                    if (this.SalesRkAutoSndTime_tEdit.Text.Trim() != "" && Int64.Parse(this.SalesRkAutoSndTime_tEdit.Text.Trim()) <= 4)
                    {
                        this.SalesRkAutoSndTime_tEdit.Clear();
                        control = this.SalesRkAutoSndTime_tEdit;
                        errorMessage = this.SalesRkAutoSndTime_ultraLabel.Text + "�̒l���T���ȏ�œ��͂��Ă��������B";
                        return result;
                    }
                }
                catch (Exception)
                {
                    this.SalesRkAutoSndTime_tEdit.Clear();
                    control = this.SalesRkAutoSndTime_tEdit;
                    errorMessage = "�������M�Ԋu�𐔒l�œ��͂��Ă��������B";
                    return result;
                }
            }

            //�}�X�^�A�g������M�Ԋu
            if (this.MasterRkAutoCode_tComboEditor.Text == "����")
            {
                try
                {
                    if (this.MasterRkAutoRcvTime_tEdit.Text.Trim() != "" && Int64.Parse(this.MasterRkAutoRcvTime_tEdit.Text.Trim()) <= 4)
                    {
                        this.MasterRkAutoRcvTime_tEdit.Clear();
                        control = this.MasterRkAutoRcvTime_tEdit;
                        errorMessage = this.MasterRkAutoRcvTime_ultraLabel.Text + "�̒l���T���ȏ�œ��͂��Ă��������B";
                        return result;
                    }
                }
                catch (Exception)
                {
                    this.MasterRkAutoRcvTime_tEdit.Clear();
                    control = this.MasterRkAutoRcvTime_tEdit;
                    errorMessage = "������M�Ԋu�𐔒l�œ��͂��Ă��������B";
                    return result;
                }
            }

            //�e�L�X�g�i�[�t�H���_�L�����`�F�b�N
            if (this.TextSaveFolder_tEdit.Text.Trim() != "" && !Directory.Exists(this.TextSaveFolder_tEdit.Text))
            {
                this.TextSaveFolder_tEdit.Clear();
                control = this.TextSaveFolder_tEdit;
                errorMessage = "�w�肵���t�H���_�����݂��܂���B";
                return result;
            }
            else if (this.TextSaveFolder_tEdit.Text.Length >= 129)
            {
                this.TextSaveFolder_tEdit.Clear();
                control = this.TextSaveFolder_tEdit;
                errorMessage = "�w�肵���t�H���_�̒�����128���𒴂��܂����B";
                return result;
            }
            else
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>result</returns>
        /// <remarks>
        /// <br>Note       : �S�̍��ڕ\�����̂̕ۑ����s���܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private bool SaveProc()
        {
            const string ctPROCNM = "SaveProc";
            bool result = false;

            Control control = null;
            string message = "";
            if (this.ScreenDataCheck(ref control, ref message) == false)
            {
                // ���̓`�F�b�N
                TMsgDisp.Show(
                    this,                                  // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,    // �G���[���x��
                    CT_PGID,                               // �A�Z���u���h�c�܂��̓N���X�h�c
                    message,                               // �\�����郁�b�Z�[�W
                    0,                                     // �X�e�[�^�X�l
                    MessageBoxButtons.OK);                // �\������{�^��

                // �R���g���[����I��
                control.Focus();
                if (control is TEdit)
                {
                    ((TEdit)control).SelectAll();
                }
                if (control is TNedit)
                {
                    ((TNedit)control).SelectAll();
                }
                return false;
            }

            this.ScreenToPM7RkSetting();

            this._pm7RkSetting.EnterpriseCode = this._enterpriseCode;
            this._pm7RkSetting.SectionCode = this._sectionCode;

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            status = this._pm7RkSettingAcs.Write(ref this._pm7RkSetting);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    {
                        result = true;
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    {
                        // �R�[�h�d��
                        TMsgDisp.Show(
                            this,                                    // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_INFO,             // �G���[���x��
                            CT_PGID,                                 // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���̃R�[�h�͊��Ɏg�p����Ă��܂��B",    // �\�����郁�b�Z�[�W
                            0,                                       // �X�e�[�^�X�l
                            MessageBoxButtons.OK);                   // �\������{�^��

                        return result;
                    }
                // �r������
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        this.ExclusiveTransaction(status, true);
                        return result;
                    }
                default:
                    {
                        // �o�^���s
                        TMsgDisp.Show(
                            this,                                 // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP,          // �G���[���x��
                            CT_PGID,                              // �A�Z���u���h�c�܂��̓N���X�h�c
                            CT_PGNM,                              // �v���O��������
                            ctPROCNM,                             // ��������
                            TMsgDisp.OPE_READ,                    // �I�y���[�V����
                            "�o�^�Ɏ��s���܂����B",               // �\�����郁�b�Z�[�W
                            status,                               // �X�e�[�^�X�l
                            this._pm7RkSettingAcs,              // �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,                 // �\������{�^��
                            MessageBoxDefaultButton.Button1);     // �����\���{�^��

                        this.CloseForm(DialogResult.Cancel);

                        return result;
                    }
            }
            return result;
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <param name="hide">��\���t���O(true: ��\���ɂ���, false: ��\���ɂ��Ȃ�)</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.23</br>
        /// </remarks>
        private void ExclusiveTransaction(int status, bool hide)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        TMsgDisp.Show(
                            this,                                  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,    // �G���[���x��
                            CT_PGID,                               // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����X�V����Ă��܂��B",    // �\�����郁�b�Z�[�W
                            0,                                     // �X�e�[�^�X�l
                            MessageBoxButtons.OK);                // �\������{�^��
                        if (hide == true)
                        {
                            this.CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        TMsgDisp.Show(
                            this,                                  // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,    // �G���[���x��
                            CT_PGID,                               // �A�Z���u���h�c�܂��̓N���X�h�c
                            "���ɑ��[�����폜����Ă��܂��B",    // �\�����郁�b�Z�[�W
                            0,                                     // �X�e�[�^�X�l
                            MessageBoxButtons.OK);                // �\������{�^��
                        if (hide == true)
                        {
                            this.CloseForm(DialogResult.Cancel);
                        }
                        break;
                    }
            }
        }

        /// <summary>
        /// �t�H�[���N���[�Y����
        /// </summary>
        /// <param name="dialogResult">�_�C�A���O����</param>
        /// <remarks>
        /// <br>Note       : �t�H�[������܂��B���̍ۉ�ʃN���[�Y�C�x���g���̔������s���܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void CloseForm(DialogResult dialogResult)
        {
            // ��ʔ�\���C�x��
            if (this.UnDisplaying != null)
            {
                MasterMaintenanceUnDisplayingEventArgs me = new MasterMaintenanceUnDisplayingEventArgs(dialogResult);
                this.UnDisplaying(this, me);
            }

            this.DialogResult = dialogResult;

            // ��r�p�N���[���N���A
            this._pm7RkSettingClone = null;

            // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z������ �t�H�[�����\��������B
            if (this._canClose == true)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        #endregion

        #region << Control Events >>

        /// <summary>
        /// Form.Load �C�x���g (PMSCM09070UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks> 
        private void PMSCM09070UA_Load(object sender, EventArgs e)
        {
            this._controlScreenSkin.LoadSkin();
            this._controlScreenSkin.SettingScreenSkin(this);

            // �A�C�R�����\�[�X�Ǘ��N���X���g�p���āA�A�C�R����\������
            ImageList imageList24 = IconResourceManagement.ImageList24;
            ImageList imageList16 = IconResourceManagement.ImageList16;

            this.Save_uButton.ImageList = imageList24;
            this.Cancel_uButton.ImageList = imageList24;
            this.DirGuide_uButton.ImageList = imageList16;

            this.Save_uButton.Appearance.Image = Size24_Index.SAVE;
            this.Cancel_uButton.Appearance.Image = Size24_Index.CLOSE;
            this.DirGuide_uButton.Appearance.Image = Size16_Index.STAR1;

            this.ScreenInitialSetting();
        }

        /// <summary>
        /// Form.FormClosing �C�x���g (PMSCM09070UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�U�[���t�H�[������邽�тɁA�t�H�[����������O�A����ѕ��闝�R���w�肷��O�ɔ������܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void PMSCM09070UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �`�F�b�N�p�N���[��������
            this._pm7RkSettingClone = null;

            // ���[�U�[�ɂ���ĕ�����ꍇ
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // CanClose�v���p�e�B��false�̏ꍇ�́A�N���[�Y�������L�����Z�����ăt�H�[�����\��������B
                if (this._canClose == false)
                {
                    e.Cancel = true;
                    this.Hide();
                }
            }
        }

        /// <summary>
        /// Form.Load �C�x���g (PMSCM09070UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ���[�U�[���t�H�[����ǂݍ��ނƂ��ɔ������܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks> 
        private void PMSCM09070UA_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                this.Owner.Activate();
                return;
            }

            // �f�[�^���Z�b�g����Ă����甲����
            if (this._pm7RkSettingClone != null)
            {
                return;
            }

            this.Initial_Timer.Enabled = true;
            //// ��ʃN���A
            this.ScreenClear();
        }

        /// <summary>
        /// Initial_Timer_Tick �C�x���g (PMSCM09070UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �Ȃ�</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void Initial_Timer_Tick(object sender, EventArgs e)
        {
            this.Initial_Timer.Enabled = false;
            this.ScreenReconstruction();
        }

        /// <summary>
        /// ValueChanged �C�x���g (PMSCM09070UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���|�[�l���g��value���ύX���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void SalesRkAutoCode_ValueChanged(object sender, EventArgs e)
        {
            if (this.SalesRkAutoCode_tComboEditor.SelectedIndex == 1)
            {
                this.SalesRkAutoSndTime_tEdit.Enabled = true;
            }
            //����A�g�������M�Ԋu���͕s�\
            else
            {
                this.SalesRkAutoSndTime_tEdit.Clear();
                this.SalesRkAutoSndTime_tEdit.Enabled = false;
            }
        }

        /// <summary>
        /// ValueChanged �C�x���g (PMSCM09070UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���|�[�l���g��value���ύX���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void MasterRkAutoCode_ValueChanged(object sender, EventArgs e)
        {
            if (this.MasterRkAutoCode_tComboEditor.SelectedIndex == 1)
            {
                this.MasterRkAutoRcvTime_tEdit.Enabled = true;
            }
            //�}�X�^�A�g������M�Ԋu���͕s�\
            else
            {
                this.MasterRkAutoRcvTime_tEdit.Clear();
                this.MasterRkAutoRcvTime_tEdit.Enabled = false;
            }
        }

        /// <summary>
        /// Control.Click �C�x���g(DirGuide_uButton)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �e�L�X�g�i�[�t�H���_�{�^���R���g���[�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void DirGuide_uButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "�e�L�X�g�i�[�t�H���_�I��";

                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    TextSaveFolder_tEdit.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        /// <summary>
        /// Control.MouseHover �C�x���g(DirGuide_uButton)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �e�L�X�g�i�[�t�H���_�{�^���R���g���[����MouseHover���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.23</br>
        /// </remarks>
        private void DirGuide_uButton_MouseHover(object sender, EventArgs e)
        {
            this.DirGuide_uButton.Refresh();
            this.toolTip1.SetToolTip(this.DirGuide_uButton, "�e�L�X�g�i�[�t�H���_�K�C�h");
        }

        /// <summary>
        /// UltraButton.Click �C�x���g (Save_uButton_Click)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void Save_uButton_Click(object sender, EventArgs e)
        {
            if (this.SaveProc() == false)
            {
                return;
            }

            // �t�H�[�������
            this.CloseForm(DialogResult.OK);

        }


        /// <summary>
        /// UltraButton.Click �C�x���g (Cancel_uButton_Click)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : �R���|�[�l���g���N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        private void Cancel_uButton_Click(object sender, EventArgs e)
        {
            DialogResult result = DialogResult.Cancel;

            PM7RkSetting comparePM7RkSetting = new PM7RkSetting();

            comparePM7RkSetting = this._pm7RkSettingClone.Clone();

            this.DispToPM7RkSetting(ref comparePM7RkSetting);

            if (comparePM7RkSetting.Equals(this._pm7RkSettingClone) == false)
            {
                // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\������
                DialogResult res = TMsgDisp.Show(
                    this,                                  // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM,    // �G���[���x��
                    CT_PGID,                               // �A�Z���u���h�c�܂��̓N���X�h�c
                    null,                                  // �\�����郁�b�Z�[�W
                    0,                                     // �X�e�[�^�X�l
                    MessageBoxButtons.YesNoCancel);       // �\������{�^��
                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            if (this.SaveProc() == false)
                            {
                                return;
                            }
                            result = DialogResult.OK;
                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    default:
                        {
                            this.Cancel_uButton.Focus();
                            return;
                        }
                }
            }

            // ��ʂ����
            this.CloseForm(result);
        }

        #endregion

    }
}