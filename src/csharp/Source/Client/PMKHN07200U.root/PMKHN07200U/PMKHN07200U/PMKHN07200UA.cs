//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �s�a�n�����}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : �s�a�n�����}�X�^�̴���߰ď������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/05/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570163-00 �쐬�S�� : �c����
// �C �� ��  2019/08/19  �C�����e : �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�
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
using Broadleaf.Application.Remoting.ParamData; // ADD 2019/08/19 �c���� �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �s�a�n�����}�X�^�i�G�N�X�|�[�g�j UI�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �s�a�n�����}�X�^�i�G�N�X�|�[�g�j UI�t�H�[���N���X</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009.05.14</br>
    /// <br>Note       : �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2019/08/19</br>
    /// </remarks>
    public partial class PMKHN07200UA : Form, IExportConditionInpType
    {
        #region �� Constructor
        /// <summary>
        /// �s�a�n�����}�X�^�i�G�N�X�|�[�g�j UI�t�H�[���N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : �s�a�n�����}�X�^�i�G�N�X�|�[�g�j UI�t�H�[���N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// <br>Note       : �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/08/19</br>
        /// <br></br>
        /// </remarks>
        public PMKHN07200UA()
        {
            InitializeComponent();

            // ��ƃR�[�h�擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._tBOSearchExportWork = new TBOSearchExportWork();

            this._tBOSearchSetExpAcs = new TBOSearchSetExpAcs();

            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.SetUIMemInputControl();

            DataSetColumnConstruction();

            this.TextOutPutOprtnHisLogAcsObj = new TextOutPutOprtnHisLogAcs(); // ADD 2019/08/19 �c���� �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�
        }
        #endregion �� Constructor

        #region �� Private Member
        #region �� Interface member
        //--IPrintConditionInpType�̃v���p�e�B�p�ϐ� ----------------------------------
        // �N���XID
        private const string ct_ClassID = "PMKHN07200UA";
        // �v���O����ID
        private const string ct_PGID = "PMKHN07200U";
        // CSV����
        private string _printName = "�s�a�n�����}�X�^�i�G�N�X�|�[�g�j";
        #endregion �� Interface member

        // ��ƃR�[�h
        private string _enterpriseCode = "";

        private GoodsAcs _goodsAcs;

        // ��ʃC���[�W�R���g���[�����i
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

        // ���o�����N���X
        private TBOSearchExportWork _tBOSearchExportWork;

        // �f�[�^�A�N�Z�X
        private TBOSearchSetExpAcs _tBOSearchSetExpAcs;

        //----- ADD 2019/08/19 �c���� �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� ----->>>>>
        // ���O�o�͋��ʕ��i
        private TextOutPutOprtnHisLogAcs TextOutPutOprtnHisLogAcsObj = null;
        // �o�^�E�X�V�p���엚�����[�N
        private TextOutPutOprtnHisLogWork TextOutPutOprtnHisLogWorkObj = null;
        //----- ADD 2019/08/19 �c���� �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� -----<<<<<
        #endregion �� Private Member

        #region �� Private Const

        // dataview���̗p
        private const string EQUIPGENRECODE = "EquipGenreCode";
        private const string EQUIPNAME = "EquipName";
        private const string CARINFOJOINDISPORDER = "CarInfoJoinDispOrder";
        private const string JOINDESTPARTSNO = "JoinDestPartsNo";
        private const string JOINDESTMAKERCD = "JoinDestMakerCd";
        private const string BLGOODSCODE = "BLGoodsCode";
        private const string JOINQTY = "JoinQty";
        private const string EQUIPSPECIALNOTE = "EquipSpecialNote";


        private const string PRINTSET_TABLE = "TBOSearchU";
        private const string PMKHN07120U_PRPID = "PMKHN07200U.xml";

        //----- ADD 2019/08/19 �c���� �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� ----->>>>>
        // �ŏ�����
        private const string StartStr = "�ŏ�����";
        // �Ō�܂�
        private const string EndStr = "�Ō�܂�";
        // �A�Z���u����
        private const string AssemblyNm = "�s�a�n�}�X�^�i�G�N�X�|�[�g�j";
        // ���\�b�h��
        private const string MethodNm = "Extract";
        // ��ʏ���
        private const string MenuCon = "�������ށF{0},���[�J�[�F{1} �` {2},÷��̧�ٖ��F{3}";
        // �o�͌���
        private const string CountNumStr = "�f�[�^�o�͌���:{0},";
        //----- ADD 2019/08/19 �c���� �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� -----<<<<<
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
        /// <br>Note       : �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/08/19</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            //----- ADD 2019/08/19 �c���� �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� ----->>>>>
            #region �A���[�g�\��
            // �G���[���b�Z�[�W
            string errMsg = string.Empty;
            // �A���[�g�\��
            status = TextOutPutOprtnHisLogAcsObj.ShowTextOutPut(this, out errMsg);
            // �A���[�g��OK�{�^����������Ȃ��ꍇ�A�e�L�X�g�o�͂����s�ł��Ȃ�
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (!string.IsNullOrEmpty(errMsg))
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                errMsg, status, MessageBoxButtons.OK);
                }
                // ���~
                return status;
            }
            #endregion

            #region ���엚��o�^
            TextOutPutOprtnHisLogWorkObj = new TextOutPutOprtnHisLogWork();
            // ���O�f�[�^�ΏۃA�Z���u��ID
            TextOutPutOprtnHisLogWorkObj.LogDataObjAssemblyID = ct_PGID;
            // ���O�f�[�^�ΏۃA�Z���u������
            TextOutPutOprtnHisLogWorkObj.LogDataObjAssemblyNm = AssemblyNm;
            // ���O�f�[�^�ΏۋN���v���O��������
            TextOutPutOprtnHisLogWorkObj.LogDataObjBootProgramNm = AssemblyNm;
            // ���O�f�[�^�Ώۏ�����
            TextOutPutOprtnHisLogWorkObj.LogDataObjProcNm = MethodNm;
            // ��ʏ���
            string equipGenreNm = this.tComboEditor_EquipGenreCode.SelectedItem.DisplayText.Trim();
            string makerCodeSt = this.tNedit_GoodsMakerCd_St.Text.Trim();
            makerCodeSt = string.IsNullOrEmpty(makerCodeSt) ? StartStr : makerCodeSt;
            string makerCodeEd = this.tNedit_GoodsMakerCd_Ed.Text.Trim();
            makerCodeEd = string.IsNullOrEmpty(makerCodeEd) ? EndStr : makerCodeEd;
            string filePath = this.tEdit_TextFileName.Text.Trim();
            string logOperationData = string.Format(MenuCon, equipGenreNm, makerCodeSt, makerCodeEd, filePath);
            // ���O�I�y���[�V�����f�[�^
            TextOutPutOprtnHisLogWorkObj.LogOperationData = logOperationData;

            // �G���[���b�Z�[�W
            errMsg = string.Empty;
            // ���엚��o�^
            status = TextOutPutOprtnHisLogAcsObj.Write(this, ref TextOutPutOprtnHisLogWorkObj, out errMsg);

            // ���O�o�^�ُ�܂��̓A���[�g��OK�{�^����������Ȃ��ꍇ�A�e�L�X�g�o�͂����s�ł��Ȃ�
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                if (!string.IsNullOrEmpty(errMsg))
                {
                    TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                                errMsg, status, MessageBoxButtons.OK);
                }
                return status;
            }
            #endregion
            //----- ADD 2019/08/19 �c���� �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� -----<<<<<

            this.uLabel_OutPutNum.Text = "0";

            ArrayList ayList = null;

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
                status = this._tBOSearchSetExpAcs.SearchAll(
                        out ayList,
                        this._enterpriseCode,
                        this._tBOSearchExportWork);
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

                        // �s�a�n�����}�X�^�N���X���f�[�^�Z�b�g�֓W�J����
                        int index = 0;
                        foreach (TBOSearchSetExp tBOSearchSetExp in ayList)
                        {
                            SecExportSetToDataSet(tBOSearchSetExp.Clone(), index);
                            ++index;
                        }

                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            ct_PGID, 						    // �A�Z���u���h�c�܂��̓N���X�h�c
                            "�s�a�n�����}�X�^�i����߰āj", 			// �v���O��������
                            "Extract", 							// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._tBOSearchSetExpAcs, 				// �G���[�����������I�u�W�F�N�g
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
            this._tBOSearchExportWork = new TBOSearchExportWork();

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
        /// <br>Note       : �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/08/19</br>
        /// </remarks>
        public void AfterExportSuccess()
        {
            this.uLabel_OutPutNum.Text = this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Count.ToString("#,###,##0");

            //----- ADD 2019/08/19 �c���� �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� ----->>>>>
            // �G���[���b�Z�[�W
            string errMsg = string.Empty;
            // ���엚��o�^
            TextOutPutOprtnHisLogWorkObj.LogOperationData = string.Format(CountNumStr, this.Bind_DataSet.Tables[PRINTSET_TABLE].DefaultView.Count.ToString()) + TextOutPutOprtnHisLogWorkObj.LogOperationData;
            int status = TextOutPutOprtnHisLogAcsObj.Write(this, ref TextOutPutOprtnHisLogWorkObj, out errMsg);
            // ���O�o�^�ُ�̏ꍇ�A�e�L�X�g�o�͂����s�ł��Ȃ�
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && !string.IsNullOrEmpty(errMsg))
            {
                TMsgDisp.Show(this, emErrorLevel.ERR_LEVEL_STOP, this.Name,
                            errMsg, status, MessageBoxButtons.OK);
                // ���~
                return;
            }
            //----- ADD 2019/08/19 �c���� �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� -----<<<<<
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
                // �������ސݒ�
                this.tComboEditor_EquipGenreCode.Items.Clear();
                this.tComboEditor_EquipGenreCode.Items.Add(1001, "�o�b�e���[");
                this.tComboEditor_EquipGenreCode.Items.Add(1005, "�^�C��");
                this.tComboEditor_EquipGenreCode.Items.Add(1010, "�I�C��");

                this.tComboEditor_EquipGenreCode.Value = 1001;

                // �����l�Z�b�g�E������
                this.tNedit_GoodsMakerCd_St.DataText = string.Empty;
                this.tNedit_GoodsMakerCd_Ed.DataText = string.Empty;
                this.tEdit_TextFileName.DataText = string.Empty;

                // �{�^���ݒ�
                this.SetIconImage(this.ub_St_MarkGuideCode, Size16_Index.STAR1);
                this.SetIconImage(this.ub_Ed_MarkGuideCode, Size16_Index.STAR1);
                this.SetIconImage(this.uButton_TextFileName, Size16_Index.STAR1);

                // �����t�H�[�J�X�Z�b�g
                this.tComboEditor_EquipGenreCode.Focus();

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
        /// <br>Date        : 2009.05.12</br>                                        
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

            // ���[�J�[�K�C�h
            if (
                (this.tNedit_GoodsMakerCd_St.GetInt() != 0) &&
                (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0) &&
                this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                errMessage = string.Format("���[�J�[{0}", ct_RangeError);
                errComponent = this.tNedit_GoodsMakerCd_St;
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
                // ��������
                this._tBOSearchExportWork.EquipGenreCodeCd = (int)this.tComboEditor_EquipGenreCode.Value;
                // �J�n���[�J�[
                this._tBOSearchExportWork.JoinDestMakerCdSt = this.tNedit_GoodsMakerCd_St.GetInt();
                // �I�����[�J�[
                this._tBOSearchExportWork.JoinDestMakerCdEd = this.tNedit_GoodsMakerCd_Ed.GetInt();
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
        /// �s�a�n�����}�X�^�N���X�f�[�^�Z�b�g�W�J����
        /// </summary>
        /// <param name="tBOSearchSetExp">�s�a�n�����}�X�^�N���X</param>
        /// <param name="index">�f�[�^�Z�b�g�֓W�J����C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note       : �s�a�n�����}�X�^�N���X���f�[�^�Z�b�g�֊i�[���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void SecExportSetToDataSet(TBOSearchSetExp tBOSearchSetExp, int index)
        {
            if ((index < 0) || (this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count <= index))
            {
                // �V�K�Ɣ��f���āA�s��ǉ�����
                DataRow dataRow = this.Bind_DataSet.Tables[PRINTSET_TABLE].NewRow();
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Add(dataRow);

                // index���s�̍ŏI�s�ԍ�����
                index = this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows.Count - 1;

            }
            if (tBOSearchSetExp.EquipGenreCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EQUIPGENRECODE] = "0";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EQUIPGENRECODE] = tBOSearchSetExp.EquipGenreCode.ToString("0000");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EQUIPNAME] = GetSubString(tBOSearchSetExp.EquipName,40);

            if (tBOSearchSetExp.CarInfoJoinDispOrder == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CARINFOJOINDISPORDER] = "0";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][CARINFOJOINDISPORDER] = tBOSearchSetExp.CarInfoJoinDispOrder.ToString();
            }

            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINDESTPARTSNO] = GetSubString(tBOSearchSetExp.JoinDestPartsNo,24);
            if (tBOSearchSetExp.JoinDestMakerCd == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINDESTMAKERCD] = "0";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINDESTMAKERCD] = tBOSearchSetExp.JoinDestMakerCd.ToString("0000");
            }

            if (tBOSearchSetExp.BLGoodsCode == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODE] = "0";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][BLGOODSCODE] = tBOSearchSetExp.BLGoodsCode.ToString("00000");
            }

            if (tBOSearchSetExp.JoinQty == 0)
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINQTY] = "0.00";
            }
            else
            {
                this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][JOINQTY] = tBOSearchSetExp.JoinQty.ToString("##0.00");
            }
            this.Bind_DataSet.Tables[PRINTSET_TABLE].Rows[index][EQUIPSPECIALNOTE] = GetSubString(tBOSearchSetExp.EquipSpecialNote,20);
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
            DataTable exportSetTable = new DataTable(PRINTSET_TABLE);

            // Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            exportSetTable.Columns.Add(EQUIPGENRECODE, typeof(string));		        // 	��������
            exportSetTable.Columns.Add(EQUIPNAME, typeof(string));		            // 	��������
            exportSetTable.Columns.Add(CARINFOJOINDISPORDER, typeof(string));		// 	�ԗ������\������
            exportSetTable.Columns.Add(JOINDESTPARTSNO, typeof(string));		    // 	������i��(�|�t���i��)
            exportSetTable.Columns.Add(JOINDESTMAKERCD, typeof(string));		    // 	�����惁�[�J�[�R�[�h
            exportSetTable.Columns.Add(BLGOODSCODE, typeof(string));		        // 	BL���i�R�[�h
            exportSetTable.Columns.Add(JOINQTY, typeof(string));	                // 	�����p�s�x
            exportSetTable.Columns.Add(EQUIPSPECIALNOTE, typeof(string));		    // 	�����K�i�E���L����

            this.Bind_DataSet.Tables.Add(exportSetTable);
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
        private void PMKHN07120UA_Load(object sender, EventArgs e)
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
        /// �a�k�R�[�h�K�C�h
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : �a�k�R�[�h�K�C�h���N���b�N�Ƃ��ɔ�������</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void ub_MarkGuideCode_Click(object sender, EventArgs e)
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
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_GoodsMakerCd_St;
                nextControl = this.tNedit_GoodsMakerCd_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_GoodsMakerCd_Ed;
                nextControl = this.tEdit_TextFileName;
            }
            else
            {
                return;
            }

            targetControl.DataText = maker.GoodsMakerCd.ToString().TrimEnd();

            // �t�H�[�J�X�ړ�
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