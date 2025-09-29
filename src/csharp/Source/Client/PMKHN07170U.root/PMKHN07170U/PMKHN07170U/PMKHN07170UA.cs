//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �����}�X�^�̴���߰ď������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/05/14  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Library.Resources;
using Infragistics.Win.Misc;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �����}�X�^�i�G�N�X�|�[�g�j UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����}�X�^�i�G�N�X�|�[�g�jUI�t�H�[���N���X</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.05.14</br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public partial class PMKHN07170UA : Form, IExportConditionInpType
    {
        #region �� Constructor
        /// <summary>
        /// �����}�X�^�i�G�N�X�|�[�g�j UI�t�H�[���N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����}�X�^�i�G�N�X�|�[�g�j UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// <br></br>
        /// </remarks>
        public PMKHN07170UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._JoinPartsSetExpAcs = new JoinPartsSetExpAcs();

            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.SetUIMemInputControl();

            DataSetColumnConstruction();
        }
        #endregion �� Constructor

        #region �� Private Member
        #region �� Interface member
        //--IPrintConditionInpType�̃v���p�e�B�p�ϐ� ----------------------------------
        // �N���XID
        private const string ct_ClassID = "PMKHN07150UA";
        // �v���O����ID
        private const string ct_PGID = "PMKHN07150U";
        // CSV����
        private string _printName = "�����}�X�^�i�G�N�X�|�[�g�j";
        #endregion �� Interface member

        // ��ƃR�[�h
        private string _enterpriseCode = "";

        private GoodsAcs _goodsAcs;

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ���o�����N���X
        private JoinPartsExpWork _joinPartsExpWork;

        // �f�[�^�A�N�Z�X
        private JoinPartsSetExpAcs _JoinPartsSetExpAcs;
        #endregion �� Private Member

        #region �� Private Const

        // dataview���̗p
        private const string JOINSOURCEMAKERCODE = "JoinSourceMakerCode";
        private const string JOINSOURCEMAKERNAME = "JoinSourceMakerName";
        private const string JOINSOURPARTSNOWITHH = "JoinSourPartsNoWithH";
        private const string JOINSOURPARTSNONONEH = "JoinSourPartsNoNoneH";
        private const string JOINDISPORDER = "JoinDispOrder";
        private const string JOINDESTPARTSNO = "JoinDestPartsNo";
        private const string JOINDESTMAKERCD = "JoinDestMakerCd";
        private const string JOINDESTMAKERNAME = "JoinDestMakerCdName";
        private const string JOINQTY = "JoinQty";
        private const string JOINSPECIALNOTE = "JoinSpecialNote";

        private const string PRINTSET_TABLE = "JOINPARTSSET";
        private const string PMKHN07120U_PRPID = "PMKHN07170U.xml";

        private const string NUMBER_FORMAT = "##0.00";
        #endregion

        #region �� IExportConditionInpType �����o
        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion �� Public Event

        #region �� Public Method
        /// <summary>
        /// ����߰đO�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : ����߰đO�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public bool ExportBeforeCheck()
        {
            bool status = true;

            string errMessage = "";
            Control errComponent = null;

            // ���̓`�F�b�N����
            if (!this.ScreenInputCheck(ref errMessage, ref errComponent))
            {
                // ���b�Z�[�W��\��
                this.MsgDispProc(emErrorLevel.ERR_LEVEL_EXCLAMATION, errMessage, 0);

                // �R���g���[���Ƀt�H�[�J�X���Z�b�g
                if (errComponent != null)
                {
                    errComponent.Focus();
                }

                status = false;
            }

            return status;
        }

        /// <summary>
        /// �o�C���h�f�[�^�Z�b�g�擾����
        /// </summary>
        /// <param name="bindDataSet">�O���b�h���b�h�p�f�[�^�Z�b�g</param>
        /// <param name="tableName">�e�[�u������</param>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = PRINTSET_TABLE;
        }

        /// <summary>
        /// ���o�f�[�^����
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            this.uLabel_OutPutNum.Text = "0";

            ArrayList PrintSets = null;

            // ��ʁ����o�����N���X
            status = this.SetExtraInfoFromScreen();
            if (status != 0)
            {
                return -1;
            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Clear();

            SFCMN00299CA form = new SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "�G�N�X�|�[�g��";
            form.Message = "���݁A�f�[�^���G�N�X�|�[�g���ł��B";

            try
            {
                // �_�C�A���O�\��
                form.Show();
                this.Cursor = Cursors.WaitCursor;
                status = this._JoinPartsSetExpAcs.Search(
                    out PrintSets,
                    this._enterpriseCode,
                    this._joinPartsExpWork);
                this.Cursor = Cursors.Default;
            }
            finally
            {
                // �_�C�A���O�����
                form.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {

                        // BL�R�[�h�N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;
                        foreach (JoinPartsSetExp joinPartsSetExp in PrintSets)
                        {
                            SecExportSetToDataSet(joinPartsSetExp, index);
                            ++index;
                        }

                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "PMKHN07170U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "�����}�X�^�i����߰āj", 			// �v���O��������
                            "Extract", 							// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._JoinPartsSetExpAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        break;
                    }
            }

            return status;
        }

        /// <summary>
        /// CSV�o�͏�񏈗�
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int GetCSVInfo(ref object parameter)
        {
            SFCMN06002C printInfo = parameter as SFCMN06002C;
            printInfo.prpid = PMKHN07120U_PRPID;
            printInfo.outPutFilePathName = this.tEdit_TextFileName.DataText;
            printInfo.overWriteFlag = false;
            return 0;
        }

        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : ��ʕ\�����s���B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public void Show(object parameter)
        {
            this._joinPartsExpWork = new JoinPartsExpWork();

            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.uiMemInput1.OptionCode = "0";

            // ��ʕ\��
            this.Show();
            return;
        }

        /// <summary>
        /// ����߰Ċ�������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ����߰Ċ����������s���B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public void AfterExportSuccess()
        {
            this.uLabel_OutPutNum.Text = this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Count.ToString("#,###,##0");
        }
        #endregion  �� Public Method
        #endregion �� IExportConditionInpType �����o

        #region �� Private Method
        #region �� ��ʏ������֌W
        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : ���͍��ڂ̏��������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private int InitializeScreen(out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            errMsg = string.Empty;

            try
            {
                // �����l�Z�b�g�E������
                this.tNedit_GoodsMakerCd_St.DataText = string.Empty;
                this.tNedit_GoodsMakerCd_Ed.DataText = string.Empty;
                this.tEdit_TextFileName.DataText = string.Empty;

                // �{�^���ݒ�
                this.SetIconImage(this.ub_St_GuideCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_GuideCode, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_TextFileName, Size16_Index.STAR1);

                // �����t�H�[�J�X�Z�b�g
                this.tNedit_GoodsMakerCd_St.Focus();

                // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
                this.uiMemInput1.ReadMemInput();
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }

            return status;
        }
        #endregion �� ��ʏ���������

        #region �� ��ʐݒ�ۑ�
        /// <summary>
        /// UIMemInput�̕ۑ����ڐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : UIMemInput�̕ۑ����ڐݒ���s���B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // ���͕ۑ����ڂ��Z�b�g
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tEdit_TextFileName);
            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;
        }
        #endregion

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note	   : �{�^���A�C�R���ݒ菈�����s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion �� �{�^���A�C�R���ݒ菈��
        #endregion �� ��ʏ������֌W

        #region �� ����߰đO����
        #region �� ���̓`�F�b�N����
        /// <summary>
        /// Coopy�`�F�b�N����                                              
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : Copy�������ɔ������܂�</br>                  
        /// <br>Programmer  : �����</br>                                    
        /// <br>Date        : 2009.05.14</br>                                        
        /// </remarks>
        private void WordCoopyCheck()
        {
            Regex r = new Regex(@"^\d+(\.)?\d*$");
            // ���[�J�[
            if (!String.IsNullOrEmpty(this.tNedit_GoodsMakerCd_St.DataText.TrimEnd()) && !r.IsMatch(this.tNedit_GoodsMakerCd_St.DataText))
            {
                this.tNedit_GoodsMakerCd_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this.tNedit_GoodsMakerCd_Ed.DataText.TrimEnd()) && !r.IsMatch(this.tNedit_GoodsMakerCd_Ed.DataText))
            {
                this.tNedit_GoodsMakerCd_Ed.Text = String.Empty;
            }
            if (this.tEdit_GoodsNo_St.DataText.Contains("�@") || this.tEdit_GoodsNo_St.DataText.Contains(" "))
            {
                this.tEdit_GoodsNo_St.Text = String.Empty;
            }
            if (this.tEdit_GoodsNo_Ed.DataText.Contains("�@") || this.tEdit_GoodsNo_Ed.DataText.Contains(" "))
            {
                this.tEdit_GoodsNo_Ed.Text = String.Empty;
            }
            Regex r1 = new Regex(@"^[\uFF61-\uFF9F-A-Za-z0-9\x00-\xff]*$");
            if (!String.IsNullOrEmpty(this.tEdit_GoodsNo_St.DataText.TrimEnd()) && !r1.IsMatch(this.tEdit_GoodsNo_St.DataText))
            {
                this.tEdit_GoodsNo_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) && !r1.IsMatch(this.tEdit_GoodsNo_Ed.DataText))
            {
                this.tEdit_GoodsNo_Ed.Text = String.Empty;
            }
        }

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;

            // Coopy�`�F�b�N
            WordCoopyCheck();

            const string ct_RangeError = "�͈͎̔w��Ɍ�肪����܂��B";

            string fileName = tEdit_TextFileName.DataText.Trim();
            if (fileName == string.Empty)
            {
                errMessage = "�e�L�X�g�t�@�C��������͂��Ă��������B";
                errComponent = this.tEdit_TextFileName;
                status = false;
                return status;
            }

            if (!Directory.Exists(System.IO.Path.GetDirectoryName(fileName)))
            {
                errMessage = "CSV�t�@�C���p�X���s���ł��B";
                errComponent = this.tEdit_TextFileName;
                status = false;
                return status;
            }

            // ����
            if (
                (this.tNedit_GoodsMakerCd_St.GetInt() != 0) &&
                (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0) &&
                this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                errMessage = string.Format("���������[�J�[{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
                return status;
            }

            // �J�i
            if (
                (this.tEdit_GoodsNo_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_GoodsNo_Ed.DataText.TrimEnd() != string.Empty) &&
                this.tEdit_GoodsNo_St.DataText.CompareTo(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) > 0)
            {
                errMessage = string.Format("�������i��{0}", ct_RangeError);
                errComponent = this.tEdit_GoodsNo_St;
                status = false;
                return status;
            }

            return status;
        }
        #endregion �� ���̓`�F�b�N����

        #region �� ���o�����ݒ菈��(��ʁ����o����)
        /// <summary>
        /// ����߰ď����ݒ菈��(��ʁ�����߰ď���)
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note		 : ��ʁ�����߰ď����֐ݒ肷��B</br>
        /// <br>Programmer �@: �����</br>
        /// <br>Date       �@: 2009.05.14</br>
        /// </remarks>
        private int SetExtraInfoFromScreen()
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            try
            {
                // �J�nBL�R�[�h
                this._joinPartsExpWork.JoinSourceMakerCodeSt = this.tNedit_GoodsMakerCd_St.GetInt();
                // �I��BL�R�[�h
                this._joinPartsExpWork.JoinSourceMakerCodeEd = this.tNedit_GoodsMakerCd_Ed.GetInt();
                // �J�n�������i��
                this._joinPartsExpWork.JoinSourPartsNoWithHSt = this.tEdit_GoodsNo_St.DataText;
                // �I���������i��
                this._joinPartsExpWork.JoinSourPartsNoWithHEd = this.tEdit_GoodsNo_Ed.DataText;
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion �� ���o�����ݒ菈��(��ʁ����o����)
        #endregion �� ����߰đO����

        #region �� �G���[���b�Z�[�W�\������
        /// <summary>
        /// �G���[���b�Z�[�W�\������
        /// </summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�\�����b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Note       : �G���[���b�Z�[�W�̕\�����s���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_ClassID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                this._printName,					// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion �� �G���[���b�Z�[�W�\������

        #region DataSet�֘A
        /// <summary>
        /// BL�R�[�h�N���X�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="joinPartsSetExp">BL�R�[�h�N���X</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : BL�R�[�h�N���X���f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SecExportSetToDataSet(JoinPartsSetExp joinPartsSetExp, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;

            }
            if (joinPartsSetExp.JoinSourceMakerCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINSOURCEMAKERCODE] = "0";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINSOURCEMAKERCODE] = joinPartsSetExp.JoinSourceMakerCode.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINSOURCEMAKERNAME] = joinPartsSetExp.JoinSourceMakerName;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINSOURPARTSNOWITHH] = GetSubString(joinPartsSetExp.JoinSourPartsNoWithH,24);

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINSOURPARTSNONONEH] = GetSubString(joinPartsSetExp.JoinSourPartsNoNoneH,24);
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINDISPORDER] = joinPartsSetExp.JoinDispOrder;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINDESTPARTSNO] = GetSubString(joinPartsSetExp.JoinDestPartsNo,24);
            if (joinPartsSetExp.JoinDestMakerCd == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINDESTMAKERCD] = "0";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINDESTMAKERCD] = joinPartsSetExp.JoinDestMakerCd.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINDESTMAKERNAME] = joinPartsSetExp.JoinDestMakerName;
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINQTY] = joinPartsSetExp.JoinQty.ToString(NUMBER_FORMAT);
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINSPECIALNOTE] = GetSubString(joinPartsSetExp.JoinSpecialNote,20);
        }

        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <remarks>
        /// <br>Note       : DataSet�̗�����\�z���܂��B�f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            DataTable PrintSetTable = new DataTable(PRINTSET_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            PrintSetTable.Columns.Add(JOINSOURCEMAKERCODE, typeof(string));		// 	���������[�J�[�R�[�h
            PrintSetTable.Columns.Add(JOINSOURCEMAKERNAME, typeof(string));		// 	���������[�J�[����
            PrintSetTable.Columns.Add(JOINSOURPARTSNOWITHH, typeof(string));	// 	�������i��(�|�t���i��)
            PrintSetTable.Columns.Add(JOINSOURPARTSNONONEH, typeof(string));	// 	�������i��(�|�����i��)
            PrintSetTable.Columns.Add(JOINDISPORDER, typeof(Int32));		    // 	�����\������
            PrintSetTable.Columns.Add(JOINDESTPARTSNO, typeof(string));		    // 	������i��(�|�t���i��)
            PrintSetTable.Columns.Add(JOINDESTMAKERCD, typeof(string));		    // 	�����惁�[�J�[�R�[�h
            PrintSetTable.Columns.Add(JOINDESTMAKERNAME, typeof(string));		// 	�����惁�[�J�[��
            PrintSetTable.Columns.Add(JOINQTY, typeof(string));		            // 	����QTY
            PrintSetTable.Columns.Add(JOINSPECIALNOTE, typeof(string));		    // 	�����K�i�E���L����

            this.Bind_DataSet.Tables.Add(PrintSetTable);
        }
        #endregion DataSet�֘A

        /// <summary>
        /// GetSubString
        /// </summary>
        /// <param name="bfString">bfString</param>
        /// <param name="length">��</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataSet�ɍs���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetSubString(string bfString, int length)
        {
            string afString = "";
            bfString = bfString.Trim();
            if (bfString.Length > length)
            {
                afString = bfString.Substring(0, length);
            }
            else
            {
                afString = bfString;
            }
            return afString.Trim();
        }
        #endregion �� Private Method

        #region �� Control Event
        /// <summary>
        /// PMKHN07120U_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void PMKHN07150U_Load(object sender, EventArgs e)
        {
            string errMsg = string.Empty;


            // �R���g���[��������
            int status = this.InitializeScreen(out errMsg);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                MsgDispProc(emErrorLevel.ERR_LEVEL_STOPDISP, errMsg, status);
                return;
            }

            // ��ʃC���[�W����
            this._controlScreenSkin.LoadSkin();						// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.SettingScreenSkin(this);		// ��ʃX�L���ύX

            ParentToolbarSettingEvent(this);						// �c�[���o�[�{�^���ݒ�C�x���g�N��
        }

        /// <summary>
        /// ���[�J�[�K�C�h
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : ���[�J�[�K�C�h���N���b�N�Ƃ��ɔ�������</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void ub_GuideCode_Click(object sender, EventArgs e)
        {
            if (this._goodsAcs == null)
            {
                this._goodsAcs = new GoodsAcs();
                string msg;
                this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            }

            MakerUMnt maker;
            int status = this._goodsAcs.ExecuteMakerGuid(this._enterpriseCode, out maker);
            if (status != 0) return;

            TNedit targetControl;
            Control nextControl = null;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_GoodsMakerCd_St;
                nextControl = this.tNedit_GoodsMakerCd_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_GoodsMakerCd_Ed;
                nextControl = this.tEdit_GoodsNo_St;
            }
            else
            {
                return;
            }
            targetControl.DataText = maker.GoodsMakerCd.ToString().TrimEnd();

            // ���t�H�[�J�X
            nextControl.Focus();
        }

        /// <summary>
        /// CSV�t�@�C���I���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : CSV�t�@�C���I���{�^���N���b�N���ɔ������܂��B</br> 
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.12</br>
        /// </remarks>
        private void uButton_TextFileName_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // �^�C�g���o�[�̕�����
                saveFileDialog.Title = "�o�̓t�@�C���I��";
                saveFileDialog.RestoreDirectory = true;

                if (this.tEdit_TextFileName.Text.Trim() == string.Empty)
                {
                    saveFileDialog.InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                }
                else
                {
                    saveFileDialog.FileName = System.IO.Path.GetFileName(this.tEdit_TextFileName.Text);
                    saveFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.tEdit_TextFileName.Text);
                }

                //�u�t�@�C���̎�ށv���w��
                saveFileDialog.Filter = "CSV�t�@�C�� (*.CSV)|*.CSV|���ׂẴt�@�C�� (*.*)|*.*";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_TextFileName.DataText = saveFileDialog.FileName;
                }
            }
        }

        /// <summary>
        /// ChangeFocus �C�x���g(tRetKeyControl1)
        /// </summary>
        /// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
        /// <param name="e">�C�x���g���</param>
        /// <remarks>
        /// <br>Note		: �e�R���g���[������t�H�[�J�X�����ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : �����</br>
        /// <br>Date        : 2009.05.12</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null || e.NextCtrl == null) return;

            // Coopy�`�F�b�N
            WordCoopyCheck();
        }

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �t�H�[�J�X�ړ����ɔ������܂�</br>                 
        /// <br>Programmer  : ���R</br>                                   
        /// <br>Date        : 2009.05.12</br>                                       
        /// </remarks>
        private void Center_AfterExitEditMode(object sender, EventArgs e)
        {
            // Coopy�`�F�b�N
            WordCoopyCheck();
        }
        #endregion �� Control Event
    }
}