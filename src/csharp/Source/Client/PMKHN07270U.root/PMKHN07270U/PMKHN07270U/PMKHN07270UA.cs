//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�Ǘ����}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : ���i�Ǘ����}�X�^�i�G�N�X�|�[�g�j�t�H�[��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ���R
// �� �� ��  2012/06/05  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : liusy
// �X �V ��  2012/09/24�@�C�����e : 2012/10/17�z�M���ARedmine#32367 
//                                  ���i�Ǘ����}�X�^�ɓ��̓p�^�[����ǉ������Ɣ����A�s����ۂ̑Ή��B
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ������
// �� �� ��  2012/11/13  �C�����e : 2012/10/17�z�M���ARedmine#32367
//                                  ���i�}�X�^�G�N�X�|�[�g�ŕs����ۂ̑Ή�
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
using System.Text.RegularExpressions;
using System.IO;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Infragistics.Win.Misc;
using Infragistics.Win.UltraWinEditors;
using Broadleaf.Application.Remoting.ParamData; // ADD 2019/08/19 �c���� �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���i�Ǘ����}�X�^�}�X�^�i�G�N�X�|�[�g�j
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�Ǘ����}�X�^�}�X�^�i�G�N�X�|�[�g�j�N���X�̃C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2012/06/05</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>Note       : ���i�Ǘ����}�X�^�ɓ��̓p�^�[����ǉ������Ɣ����A�s����ۂ̑Ή��B</br>
    /// <br>Programmer : liusy</br>
    /// <br>Date       : 2012/09/24</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>Note       : ���i�}�X�^�G�N�X�|�[�g�ŕs����ۂ̑Ή��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2012/11/13</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>Note       : �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2019/08/19</br>
    /// </remarks>
    public partial class PMKHN07270UA : Form, IExportConditionInpType
    {
        #region �� Constructor
        /// <summary>
        /// �N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2012/06/05</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00</br>
        /// <br>Note        : �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2019/08/19</br>
        /// </remarks>
        public PMKHN07270UA()
        {
            InitializeComponent();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.SetUIMemInputControl();

            this.TextOutPutOprtnHisLogAcsObj = new TextOutPutOprtnHisLogAcs(); // ADD 2019/08/19 �c���� �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�
        }
        #endregion

        #region �� Private member
        // ���i�Ǘ����}�X�^�}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X
        private GoodsMngExportAcs _goodsMngExportAcs;
        // ��ƃR�[�h
        private string _enterpriseCode;
        // ���[�J�[�K�C�h�A�N�Z�X�N���X
        private GoodsAcs _goodsAcs;
        // ���_�A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs;

        //----- ADD 2019/08/19 �c���� �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� ----->>>>>
        // ���O�o�͋��ʕ��i
        private TextOutPutOprtnHisLogAcs TextOutPutOprtnHisLogAcsObj = null;
        // �o�^�E�X�V�p���엚�����[�N
        private TextOutPutOprtnHisLogWork TextOutPutOprtnHisLogWorkObj = null;
        //----- ADD 2019/08/19 �c���� �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� -----<<<<<
        #endregion �� Private member

        #region  �� Private cost
        //�G���[�������b�Z�[�W
        private const string ct_INPUTERROR = "���s���ł��B";
        private const string ct_NOINPUT = "����͂��Ă��������B";
        private const string ct_RANGEERROR = "�͈͎̔w��Ɍ�肪����܂��B";
        // �N���XID
        private const string ct_CLASSID = "PMKHN07270UA";
        private const string PMKHN07270U_PRPID = "PMKHN07270U.xml";
        private const string PRINTSET_TABLE = "GoodsMngExp";

        // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>
        //�ݒ���
        private const string SETKIND_1 = "���_�{�i��";
        private const string SETKIND_2 = "���_�{�����ށ{���[�J�[�{BL�R�[�h";
        private const string SETKIND_3 = "���_�{�����ށ{���[�J�[";
        private const string SETKIND_4 = "���_�{���[�J�[";
        private const string SETKIND_5 = "�S��";
        private const int SETKIND_1_VALUE = 0;
        private const int SETKIND_2_VALUE = 1;
        private const int SETKIND_3_VALUE = 2;
        private const int SETKIND_4_VALUE = 3;
        private const int SETKIND_5_VALUE = 4;
        // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<

        //----- ADD 2019/08/19 �c���� �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� ----->>>>>
        // �ŏ�����
        private const string StartStr = "�ŏ�����";
        // �Ō�܂�
        private const string EndStr = "�Ō�܂�";
        // �A�Z���u��ID
        private const string AssemblyID = "PMKHN07270U";
        // �A�Z���u����
        private const string AssemblyNm = "���i�Ǘ����}�X�^�i�G�N�X�|�[�g�j";
        // ���\�b�h��
        private const string MethodNm = "Extract";
        // ��ʏ���
        private const string MenuCon1 = "���̓p�^�[���F{0},���_�F{1} �` {2},���[�J�[�F{3} �` {4},�i�ԁF{5} �` {6},÷��̧�ٖ��F{7}";
        private const string MenuCon2 = "���̓p�^�[���F{0},���_�F{1} �` {2},���[�J�[�F{3} �` {4},BL�R�[�h�F{5} �` {6},�����ށF{7} �` {8},÷��̧�ٖ��F{9}";
        private const string MenuCon3 = "���̓p�^�[���F{0},���_�F{1} �` {2},���[�J�[�F{3} �` {4},�����ށF{5} �` {6},÷��̧�ٖ��F{7}";
        private const string MenuCon4 = "���̓p�^�[���F{0},���_�F{1} �` {2},���[�J�[�F{3} �` {4},÷��̧�ٖ��F{5}";
        private const string MenuCon5 = "���̓p�^�[���F{0},���_�F{1} �` {2},���[�J�[�F{3} �` {4},�i�ԁF{5} �` {6},BL�R�[�h�F{7} �` {8},�����ށF{9} �` {10},÷��̧�ٖ��F{11}";
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
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2012/06/05</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
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
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2012/06/05</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
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
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2012/06/05</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
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
            TextOutPutOprtnHisLogWorkObj.LogDataObjAssemblyID = AssemblyID;
            // ���O�f�[�^�ΏۃA�Z���u������
            TextOutPutOprtnHisLogWorkObj.LogDataObjAssemblyNm = AssemblyNm;
            // ���O�f�[�^�ΏۋN���v���O��������
            TextOutPutOprtnHisLogWorkObj.LogDataObjBootProgramNm = AssemblyNm;
            // ���O�f�[�^�Ώۏ�����
            TextOutPutOprtnHisLogWorkObj.LogDataObjProcNm = MethodNm;
            // ���̓p�^�[��
            string inputCase = this.SetKind_tComboEditor.SelectedItem.DisplayText.Trim();
            // ���_
            string sectionSt = this.tEdit_SectionCode_St.Text.Trim();
            sectionSt = string.IsNullOrEmpty(sectionSt) ? StartStr : sectionSt;
            string sectionEd = this.tEdit_SectionCode_Ed.Text.Trim();
            sectionEd = string.IsNullOrEmpty(sectionEd) ? EndStr : sectionEd;
            // ���[�J�[
            string makerCodeSt = this.tNedit_GoodsMakerCd_St.Text.Trim();
            makerCodeSt = string.IsNullOrEmpty(makerCodeSt) ? StartStr : makerCodeSt;
            string makerCodeEd = this.tNedit_GoodsMakerCd_Ed.Text.Trim();
            makerCodeEd = string.IsNullOrEmpty(makerCodeEd) ? EndStr : makerCodeEd;
            // �i��
            string goodsNoSt = string.Empty;
            string goodsNoEd = string.Empty;
            // BL�R�[�h
            string blCodeSt = string.Empty;
            string blCodeEd = string.Empty;
            // ������
            string goodsMGroupSt = string.Empty;
            string goodsMGroupEd = string.Empty;
            // �o�̓t�@�C����
            string filePath = this.tEdit_TextFileName.Text.Trim();
            // ���O�I�y���[�V�����f�[�^
            string logOperationData = string.Empty;
            switch (this.SetKind_tComboEditor.SelectedIndex)
            {
                // ���_�{�i��
                case 0:
                    // �i��
                    goodsNoSt = this.tEdit_GoodsNo_St.Text.Trim();
                    goodsNoSt = string.IsNullOrEmpty(goodsNoSt) ? StartStr : goodsNoSt;
                    goodsNoEd = this.tEdit_GoodsNo_Ed.Text.Trim();
                    goodsNoEd = string.IsNullOrEmpty(goodsNoEd) ? EndStr : goodsNoEd;
                    logOperationData = string.Format(MenuCon1, inputCase, sectionSt, sectionEd, makerCodeSt, makerCodeEd, goodsNoSt, goodsNoEd, filePath);
                    break;
                // ���_�{�����ށ{���[�J�[�{BL�R�[�h
                case 1:
                    // BL�R�[�h
                    blCodeSt = this.tNedit_BLGoodsCode_St.Text.Trim();
                    blCodeSt = string.IsNullOrEmpty(blCodeSt) ? StartStr : blCodeSt;
                    blCodeEd = this.tNedit_BLGoodsCode_Ed.Text.Trim();
                    blCodeEd = string.IsNullOrEmpty(blCodeEd) ? EndStr : blCodeEd;
                    // ������
                    goodsMGroupSt = this.tNedit_GoodsMGroup_St.Text.Trim();
                    goodsMGroupSt = string.IsNullOrEmpty(goodsMGroupSt) ? StartStr : goodsMGroupSt;
                    goodsMGroupEd = this.tNedit_GoodsMGroup_Ed.Text.Trim();
                    goodsMGroupEd = string.IsNullOrEmpty(goodsMGroupEd) ? EndStr : goodsMGroupEd;
                    logOperationData = string.Format(MenuCon2, inputCase, sectionSt, sectionEd, makerCodeSt, makerCodeEd, blCodeSt, blCodeEd, goodsMGroupSt, goodsMGroupEd, filePath);
                    break;
                // ���_�{�����ށ{���[�J�[
                case 2:
                    // ������
                    goodsMGroupSt = this.tNedit_GoodsMGroup_St.Text.Trim();
                    goodsMGroupSt = string.IsNullOrEmpty(goodsMGroupSt) ? StartStr : goodsMGroupSt;
                    goodsMGroupEd = this.tNedit_GoodsMGroup_Ed.Text.Trim();
                    goodsMGroupEd = string.IsNullOrEmpty(goodsMGroupEd) ? EndStr : goodsMGroupEd;
                    logOperationData = string.Format(MenuCon3, inputCase, sectionSt, sectionEd, makerCodeSt, makerCodeEd, goodsMGroupSt, goodsMGroupEd, filePath);
                    break;
                // ���_�{���[�J�[
                case 3:
                    logOperationData = string.Format(MenuCon4, inputCase, sectionSt, sectionEd, makerCodeSt, makerCodeEd, filePath);
                    break;
                // �S��
                case 4:
                    // �i��
                    goodsNoSt = this.tEdit_GoodsNo_St.Text.Trim();
                    goodsNoSt = string.IsNullOrEmpty(goodsNoSt) ? StartStr : goodsNoSt;
                    goodsNoEd = this.tEdit_GoodsNo_Ed.Text.Trim();
                    goodsNoEd = string.IsNullOrEmpty(goodsNoEd) ? EndStr : goodsNoEd;
                    // BL�R�[�h
                    blCodeSt = this.tNedit_BLGoodsCode_St.Text.Trim();
                    blCodeSt = string.IsNullOrEmpty(blCodeSt) ? StartStr : blCodeSt;
                    blCodeEd = this.tNedit_BLGoodsCode_Ed.Text.Trim();
                    blCodeEd = string.IsNullOrEmpty(blCodeEd) ? EndStr : blCodeEd;
                    // ������
                    goodsMGroupSt = this.tNedit_GoodsMGroup_St.Text.Trim();
                    goodsMGroupSt = string.IsNullOrEmpty(goodsMGroupSt) ? StartStr : goodsMGroupSt;
                    goodsMGroupEd = this.tNedit_GoodsMGroup_Ed.Text.Trim();
                    goodsMGroupEd = string.IsNullOrEmpty(goodsMGroupEd) ? EndStr : goodsMGroupEd;
                    logOperationData = string.Format(MenuCon5, inputCase, sectionSt, sectionEd, makerCodeSt, makerCodeEd, goodsNoSt, goodsNoEd, blCodeSt, blCodeEd, goodsMGroupSt, goodsMGroupEd, filePath);
                    break;
                default:
                    // �Ȃ�
                    break;
            }
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
            // ��ʁ����o�����N���X
            GoodsMngExport goodsMngExportWork = new GoodsMngExport();
            this.SetExtraInfoFromScreen(ref goodsMngExportWork);
            this.Bind_DataSet.Tables.Clear();
            DataTable dataTable;
            SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            // �\��������ݒ�
            form.Title = "�G�N�X�|�[�g��";
            form.Message = "���݁A�f�[�^���G�N�X�|�[�g���ł��B";
            try
            {
                // �_�C�A���O�\��
                form.Show();
                this.Cursor = Cursors.WaitCursor;
                // ����
                if (_goodsMngExportAcs == null) _goodsMngExportAcs = new GoodsMngExportAcs();
                status = this._goodsMngExportAcs.Search(goodsMngExportWork, out dataTable);
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
                        //�f�[�^�Z�b�g�֓W�J����
                        this.Bind_DataSet.Tables.Add(dataTable);
                        break;
                    }
                default:
                    {
                        TMsgDisp.Show(						// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            ct_CLASSID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���i�Ǘ����}�X�^�i����߰āj", 			// �v���O��������
                            "Extract", 							// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._goodsMngExportAcs, 				// �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2012/06/05</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        public int GetCSVInfo(ref object parameter)
        {
            SFCMN06002C printInfo = parameter as SFCMN06002C;
            printInfo.prpid = PMKHN07270U_PRPID;
            printInfo.outPutFilePathName = this.tEdit_TextFileName.DataText;
            printInfo.overWriteFlag = false;
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : ��ʕ\�����s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2012/06/05</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
        /// </remarks>
        public void Show(object parameter)
        {
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
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2012/06/05</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00</br>
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

        #region �� Private Event
        #region �� �K�C�h����
        /// <summary>
        /// ���_�R�[�h�K�C�h�N���{�^���N���C�x���g                                               
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                              
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���_�R�[�h�K�C�h�N���b�N���ɔ������܂�</br>                  
        /// <br>Programmer  : ���R</br>                                    
        /// <br>Date        : 2012/06/05</br> 
        /// <br>�Ǘ��ԍ�    : 10801804-00</br>
        /// </remarks>
        private void ub_SectionCodeStGuid_Click(object sender, EventArgs e)
        {
            int status = 0;

            SecInfoSet secInfoSet;

            // ���_�K�C�h�\��
            if (_secInfoSetAcs == null) _secInfoSetAcs = new SecInfoSetAcs();
            status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
            string tag = (string)((UltraButton)sender).Tag;
            TEdit targetControl = null;
            Control nextControl = null;
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // ���_�J�n�R�[�h
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    targetControl = this.tEdit_SectionCode_St;
                    nextControl = this.tEdit_SectionCode_Ed;
                }
                // ���_�I���R�[�h
                else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
                {
                    targetControl = this.tEdit_SectionCode_Ed;
                    nextControl = this.tNedit_GoodsMakerCd_St;
                }
                else
                {
                    return;
                }
                // �R�[�h�W�J
                targetControl.DataText = secInfoSet.SectionCode.Trim();
                // �t�H�[�J�X
                nextControl.Focus();
            }
            else
            {
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    nextControl = this.ub_SectionCodeStGuid;
                }
                else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
                {
                    nextControl = this.ub_SectionCodeEdGuid;
                }
                nextControl.Focus();
            }

        }

        /// <summary>
        /// ���[�J�[�K�C�h�N���{�^���N���C�x���g                                               
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                              
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���[�J�[�K�C�h�N���b�N���ɔ������܂�</br>                  
        /// <br>Programmer  : ���R</br>                                    
        /// <br>Date        : 2012/06/05</br> 
        /// <br>�Ǘ��ԍ�    : 10801804-00</br>
        /// </remarks>
        private void ub_St_GoodsMakerCdGuide_Click(object sender, EventArgs e)
        {
            if (this._goodsAcs == null)
            {
                this._goodsAcs = new GoodsAcs();
                string msg;
                this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            }

            MakerUMnt maker;
            // ���[�J�[�K�C�h�\��
            int status = this._goodsAcs.ExecuteMakerGuid(this._enterpriseCode, out maker);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return;

            TNedit targetControl;
            Control nextControl = null;
            // ���[�J�[�J�n�R�[�h
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_GoodsMakerCd_St;
                nextControl = this.tNedit_GoodsMakerCd_Ed;
            }
            // ���[�J�[�I���R�[�h
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_GoodsMakerCd_Ed;
                // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>
                if (SetKind_tComboEditor.Text == SETKIND_1 || SetKind_tComboEditor.Text == SETKIND_5)
                {
                    nextControl = this.tEdit_GoodsNo_St;

                }
                else if (SetKind_tComboEditor.Text == SETKIND_2)
                {
                    nextControl = this.tNedit_BLGoodsCode_St;
                }
                else if (SetKind_tComboEditor.Text == SETKIND_3)
                {
                    nextControl = this.tNedit_GoodsMGroup_St;
                }
                else
                {
                    nextControl = this.tEdit_TextFileName;
                }
                // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<
                //nextControl = this.tEdit_GoodsNo_St; //DEL liusy 2012/09/24 for Redmine#32367
            }
            else
            {
                return;
            }
            targetControl.DataText = maker.GoodsMakerCd.ToString().TrimEnd().PadLeft(4, '0');

            // ���t�H�[�J�X
            nextControl.Focus();
        }

        // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>
        /// <summary>
        /// Control.Click �C�x���g(BLGoodsCodeGuide_Button)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note        : BL�R�[�h�K�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : liusy</br>
        /// <br>Date        : 2012/09/24</br>
        /// </remarks>
        private void BLGoodsGuide_Button_Click(object sender, EventArgs e)
        {

            // ���������̐ݒ�
            BLGoodsCdUMnt bLGoodsCdUMnt = new BLGoodsCdUMnt();
            BLGoodsCdAcs bLGoodsCdAcs = new BLGoodsCdAcs();

            //BL�R�[�h�K�C�h�N��
            int status = bLGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out bLGoodsCdUMnt);
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return;


            TNedit targetControl;
            Control nextControl = null;
            // BL�J�n�R�[�h
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_St;
                nextControl = this.tNedit_BLGoodsCode_Ed;
            }
            // BL�I���R�[�h
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_Ed;
                nextControl = this.tNedit_GoodsMGroup_St;
            }
            else
            {
                return;
            }
            targetControl.DataText = bLGoodsCdUMnt.BLGoodsCode.ToString().TrimEnd().PadLeft(5, '0');
            // ���t�H�[�J�X
            nextControl.Focus();
        }
        /// <summary>
        /// ���i�����ރK�C�h�{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <br>Note        : �����ރK�C�h�{�^�����N���b�N���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer  : liusy</br>
        /// <br>Date        : 2012/09/24</br>
        /// 
        private void uButton_GoodsMGroup_Click(object sender, EventArgs e)
        {
            if (this._goodsAcs == null)
            {
                this._goodsAcs = new GoodsAcs();
            }
            GoodsGroupU goodsMGroup;
            // �K�C�h�N��
            int status = this._goodsAcs.ExecuteGoodsMGroupGuid( this._enterpriseCode, out goodsMGroup );
            if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL) return;
            TNedit targetControl;
            Control nextControl = null;
            // BL�J�n�R�[�h
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_GoodsMGroup_St;
                nextControl = this.tNedit_GoodsMGroup_Ed;
            }
            // BL�I���R�[�h
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_GoodsMGroup_Ed;
                nextControl = this.tEdit_TextFileName;
            }
            else
            {
                return;
            }
            targetControl.DataText = goodsMGroup.GoodsMGroup.ToString().TrimEnd().PadLeft(4, '0');
            // ���t�H�[�J�X
            nextControl.Focus();
        }
        // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<
        #endregion

        #region �� �t�@�C���_�C�A���O
        /// <summary>
        /// CSV�t�@�C���I���{�^���N���b�N�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note        : CSV�t�@�C���I���{�^���N���b�N���ɔ������܂��B</br> 
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2012/06/05</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00</br>
        /// </remarks>
        private void uButton_TextFileName_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // �^�C�g���o�[�̕�����
                saveFileDialog.Title = "�o�̓t�@�C���I��";
                saveFileDialog.RestoreDirectory = true;

                if (String.IsNullOrEmpty(this.tEdit_TextFileName.Text.Trim()))
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
        #endregion

        #region �� ChangeFocus
        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���L�[�ł̃t�H�[�J�X�ړ����ɔ������܂�</br>                 
        /// <br>Programmer  : ���R</br>                                   
        /// <br>Date        : 2012/06/05</br>  
        /// <br>�Ǘ��ԍ�    : 10801804-00</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // --- DEL liusy 2012/09/24 for Redmine#32367---------->>>>>
            //if (!e.ShiftKey)
            //{
            //    if (e.PrevCtrl == this.tEdit_SectionCode_St)
            //    {
            //        if (!"00".Equals(tEdit_SectionCode_St.Text.Trim().PadLeft(2, '0')))
            //            tEdit_SectionCode_St.Text = tEdit_SectionCode_St.Text.Trim().PadLeft(2, '0');
            //        else
            //            tEdit_SectionCode_St.Text = "";
            //    }
            //    else if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
            //    {
            //        if (!"00".Equals(tEdit_SectionCode_Ed.Text.Trim().PadLeft(2, '0')))
            //            tEdit_SectionCode_Ed.Text = tEdit_SectionCode_Ed.Text.Trim().PadLeft(2, '0');
            //        else
            //            tEdit_SectionCode_Ed.Text = "";
            //    }
            //    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
            //    {
            //        tNedit_GoodsMakerCd_St.Text = tNedit_GoodsMakerCd_St.Text.Trim().PadLeft(4, '0');
            //    }
            //    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
            //    {
            //        tNedit_GoodsMakerCd_Ed.Text = tNedit_GoodsMakerCd_Ed.Text.Trim().PadLeft(4, '0');
            //    }
            //    // SHIFT�L�[������
            //    if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
            //    {
            //        if (e.PrevCtrl == this.tEdit_SectionCode_St)
            //        {
            //            // ���_(�J�n)�����_(�I��)
            //            e.NextCtrl = this.tEdit_SectionCode_Ed;
            //        }
            //        else if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
            //        {
            //            // ���_(�I��)�����[�J�[(�J�n)
            //            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
            //        }
            //        else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
            //        {
            //            // ���[�J�[(�J�n)�����[�J�[(�I��)
            //            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
            //        }
            //        else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
            //        {
            //            // ���[�J�[(�I��)���i��(�J�n)
            //            e.NextCtrl = this.tEdit_GoodsNo_St;
            //        }
            //        else if (e.PrevCtrl == this.tEdit_GoodsNo_St)
            //        {
            //            // �i��(�J�n)���i��(�I��)
            //            e.NextCtrl = this.tEdit_GoodsNo_Ed;
            //        }
            //        else if (e.PrevCtrl == this.tEdit_GoodsNo_Ed)
            //        {
            //            // �i��(�I��)�� ÷��̧�ٖ�
            //            e.NextCtrl = this.tEdit_TextFileName;
            //        }
            //        else if (e.PrevCtrl == this.tEdit_TextFileName)
            //        {
            //            // ÷��̧�ٖ��� �t�@�C���_�C�A���O
            //            e.NextCtrl = this.uButton_TextFileName;
            //        }
            //        else if (e.PrevCtrl == this.uButton_TextFileName)
            //        {
            //            // �t�@�C���_�C�A���O�� ���[�J�[(�J�n)
            //            e.NextCtrl = this.tEdit_SectionCode_St;
            //        }
            //    }
            //}
            //else
            //{
            //    // SHIFT�L�[����
            //    if (e.Key == Keys.Tab)
            //    {
            //        if (e.PrevCtrl == this.tEdit_SectionCode_St)
            //        {
            //            // ���_(�J�n)���t�@�C���_�C�A���O
            //            e.NextCtrl = this.uButton_TextFileName;
            //        }
            //        else if (e.PrevCtrl == this.tEdit_SectionCode_Ed)
            //        {
            //            // ���_(�I��)�����_(�J�n)
            //            e.NextCtrl = this.tEdit_SectionCode_St;
            //        }
            //        else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
            //        {
            //            // ���[�J�[(�J�n)���t�@�C���_�C�A���O
            //            e.NextCtrl = this.tEdit_SectionCode_Ed;
            //        }
            //        else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
            //        {
            //            // ���[�J�[(�I��)�����[�J�[(�J�n)
            //            e.NextCtrl = this.tNedit_GoodsMakerCd_St;
            //        }
            //        else if (e.PrevCtrl == this.tEdit_GoodsNo_St)
            //        {
            //            // �i��(�J�n)���a�k�R�[�h(�I��)
            //            e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
            //        }
            //        else if (e.PrevCtrl == this.tEdit_GoodsNo_Ed)
            //        {
            //            // �i��(�I��)�� �i��(�J�n)
            //            e.NextCtrl = this.tEdit_GoodsNo_St;
            //        }
            //        else if (e.PrevCtrl == this.tEdit_TextFileName)
            //        {
            //            // ÷��̧�ٖ��� �i��(�I��)
            //            e.NextCtrl = this.tEdit_GoodsNo_Ed;
            //        }
            //        else if (e.PrevCtrl == this.uButton_TextFileName)
            //        {
            //            // �t�@�C���_�C�A���O�� ÷��̧�ٖ�
            //            e.NextCtrl = this.tEdit_TextFileName;
            //        }
            //    }
            // --- DEL liusy 2012/09/24 for Redmine#32367----------<<<<<
            // Coopy�`�F�b�N
            WordCoopyCheck();
        }
        #endregion

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �t�H�[�J�X�ړ����ɔ������܂�</br>                 
        /// <br>Programmer  : ���R</br>                                   
        /// <br>Date        : 2012/06/05</br> 
        /// <br>�Ǘ��ԍ�    : 10801804-00</br>
        /// </remarks>
        private void Center_AfterExitEditMode(object sender, EventArgs e)
        {
            // Coopy�`�F�b�N
            WordCoopyCheck();
        }
        #endregion�@�� Private Event

        #region �� Control Event
        /// <summary>
        /// PMKHN07270UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2012/06/05</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00</br>
        /// </remarks>
        private void PMKHN07270UA_Load(object sender, EventArgs e)
        {
            this.InitializeScreen();
            ParentToolbarSettingEvent(this);						// �c�[���o�[�{�^���ݒ�C�x���g�N�� 
        }
        #endregion

        #region �� Private Method
        #region �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )
        /// <summary>�G���[���b�Z�[�W�\������</summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="status">�G���[�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2012/06/05</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_CLASSID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                "���i�Ǘ����}�X�^�i����߰āj",	// �v���O��������
                "", 								// ��������
                "",									// �I�y���[�V����
                message,							// �\�����郁�b�Z�[�W
                status, 							// �X�e�[�^�X�l
                null, 								// �G���[�����������I�u�W�F�N�g
                MessageBoxButtons.OK, 				// �\������{�^��
                MessageBoxDefaultButton.Button1);	// �����\���{�^��
        }
        #endregion �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )

        #region �� ��ʏ���������
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note		: ��ʏ������������s��</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2012/06/05</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // ���[�J�[
            this.tNedit_GoodsMakerCd_St.Clear();
            this.tNedit_GoodsMakerCd_Ed.Clear();
            // ���_
            this.tEdit_SectionCode_Ed.Clear();
            this.tEdit_SectionCode_St.Clear();
            // �i��
            this.tEdit_GoodsNo_St.Clear();
            this.tEdit_GoodsNo_Ed.Clear();


            this.SetIconImage(this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1);
            this.SetIconImage(this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1);
            this.SetIconImage(this.ub_SectionCodeStGuid, Size16_Index.STAR1);
            this.SetIconImage(this.ub_SectionCodeEdGuid, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_TextFileName, Size16_Index.STAR1);

            //this.tEdit_SectionCode_St.Focus(); // DEL liusy 2012/09/24 for Redmine#32367
            // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>> 
            // BL�R�[�h
            this.tNedit_BLGoodsCode_St.Clear();
            this.tNedit_BLGoodsCode_Ed.Clear();
            // ������
            this.tNedit_GoodsMGroup_Ed.Clear();
            this.tNedit_GoodsMGroup_St.Clear();

            this.SetIconImage(this.ub_St_BLGoodsGuide, Size16_Index.STAR1);
            this.SetIconImage(this.ub_Ed_BLGoodsGuide, Size16_Index.STAR1);
            this.SetIconImage(this.ub_St_GoodsMGroupGuid, Size16_Index.STAR1);
            this.SetIconImage(this.ub_Ed_GoodsMGroupGuid, Size16_Index.STAR1);
            // �ݒ���

            this.SetKind_tComboEditor.Items.Clear();
            this.SetKind_tComboEditor.Items.Add(SETKIND_1_VALUE, SETKIND_1);
            this.SetKind_tComboEditor.Items.Add(SETKIND_2_VALUE, SETKIND_2);
            this.SetKind_tComboEditor.Items.Add(SETKIND_3_VALUE, SETKIND_3);
            this.SetKind_tComboEditor.Items.Add(SETKIND_4_VALUE, SETKIND_4);
            this.SetKind_tComboEditor.Items.Add(SETKIND_5_VALUE, SETKIND_5);
            this.SetKind_tComboEditor.MaxDropDownItems = this.SetKind_tComboEditor.Items.Count;
            this.SetKind_tComboEditor.SelectedIndex = 0;
            // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<

            // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
            this.uiMemInput1.ReadMemInput();
        }
        #endregion

        #region �� ��ʐݒ�ۑ�
        /// <summary>
        /// UIMemInput�̕ۑ����ڐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : UIMemInput�̕ۑ����ڐݒ���s���B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2012/06/05</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00</br>
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

        #region �� ������񏈗�
        /// <summary>
        /// ������񏈗�
        /// </summary>
        /// <param name="goodsMngExportWork">���o�����N���X</param>
        /// <remarks>
        /// <br>Note		: ������񏈗����s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2012/06/05</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00</br>
        /// <br>Update Note : 2012/11/13 ������</br>
        ///	<br>			  Redmine#32367 ���i�}�X�^�G�N�X�|�[�g�ŕs����ۂ̑Ή�</br>
        /// </remarks>
        private void SetExtraInfoFromScreen(ref GoodsMngExport goodsMngExportWork)
        {
            // ��ƃR�[�h
            goodsMngExportWork.EnterpriseCode = this._enterpriseCode;
            // ���[�J�[�J�n
            goodsMngExportWork.GoodsMakerCdSt = this.tNedit_GoodsMakerCd_St.GetInt();

            // ���[�J�[�I��
            goodsMngExportWork.GoodsMakerCdEd = this.tNedit_GoodsMakerCd_Ed.GetInt();

            // ���_�R�[�h�J�n
            goodsMngExportWork.SectionCdSt = this.tEdit_SectionCode_St.DataText.TrimEnd();

            // ���_�R�[�h�I��
            goodsMngExportWork.SectionCdEd = this.tEdit_SectionCode_Ed.DataText.TrimEnd();

            // �i�ԊJ�n
            goodsMngExportWork.GoodsNoSt = this.tEdit_GoodsNo_St.DataText.TrimEnd();

            // �i�ԏI��
            goodsMngExportWork.GoodsNoEd = this.tEdit_GoodsNo_Ed.DataText.TrimEnd();

            // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>
            // BL�R�[�h�J�n
            goodsMngExportWork.BLGoodsCodeSt = this.tNedit_BLGoodsCode_St.GetInt();

            // BL�R�[�h�I��
            goodsMngExportWork.BLGoodsCodeEd = this.tNedit_BLGoodsCode_Ed.GetInt();

            // �����ފJ�n
            goodsMngExportWork.GoodsMGroupSt = this.tNedit_GoodsMGroup_St.GetInt();

            // �����ޏI��
            goodsMngExportWork.GoodsMGroupEd = this.tNedit_GoodsMGroup_Ed.GetInt();
            // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<
            // --- ADD ������ 2012/11/13 for Redmine#32367---------->>>>>
            //�ݒ���
            goodsMngExportWork.SetKind = (Int32)this.SetKind_tComboEditor.Value;
            // --- ADD ������ 2012/11/13 for Redmine#32367----------<<<<<
        }
        #endregion

        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2012/06/05</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            // Coopy�`�F�b�N
            WordCoopyCheck();
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

            // ���_�i�J�n�`�I���j
            if ((this.tEdit_SectionCode_St.DataText.TrimEnd() != string.Empty) &&
                (this.tEdit_SectionCode_Ed.DataText.TrimEnd() != string.Empty) &&
                Int32.Parse(this.tEdit_SectionCode_St.DataText.TrimEnd()) > Int32.Parse(this.tEdit_SectionCode_Ed.DataText.TrimEnd()))
            {
                errMessage = string.Format("���_{0}", ct_RANGEERROR);
                errComponent = this.tEdit_SectionCode_St;
                status = false;
                return status;
            }

            // ���[�J�[
            if ((this.tNedit_GoodsMakerCd_St.GetInt() != 0) &&
                (this.tNedit_GoodsMakerCd_Ed.GetInt() != 0) &&
                this.tNedit_GoodsMakerCd_St.GetInt() > this.tNedit_GoodsMakerCd_Ed.GetInt())
            {
                errMessage = string.Format("���[�J�[{0}", ct_RANGEERROR);
                errComponent = this.tNedit_GoodsMakerCd_St;
                status = false;
                return status;
            }

            // �i��
            if (
                !String.IsNullOrEmpty(this.tEdit_GoodsNo_St.DataText.TrimEnd()) &&
                !String.IsNullOrEmpty(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) &&
                this.tEdit_GoodsNo_St.DataText.CompareTo(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) == 1)
            {
                errMessage = string.Format("�i��{0}", ct_RANGEERROR);
                errComponent = this.tEdit_GoodsNo_St;
                status = false;
                return status;
            }

            // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>

            // BL�R�[�h
            if ((this.tNedit_BLGoodsCode_St.GetInt() != 0) &&
                (this.tNedit_BLGoodsCode_Ed.GetInt() != 0) &&
                this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                errMessage = string.Format("BL�R�[�h{0}", ct_RANGEERROR);
                errComponent = this.tNedit_BLGoodsCode_St;
                status = false;
                return status;
            }

            // ������
            if ((this.tNedit_GoodsMGroup_St.GetInt() != 0) &&
                (this.tNedit_GoodsMGroup_Ed.GetInt() != 0) &&
                this.tNedit_GoodsMGroup_St.GetInt() > this.tNedit_GoodsMGroup_Ed.GetInt())
            {
                errMessage = string.Format("������{0}", ct_RANGEERROR);
                errComponent = this.tNedit_GoodsMGroup_St;
                status = false;
                return status;
            }
            // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<
            return status;
        }

        /// <summary>
        /// Coopy�`�F�b�N����                                              
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : Copy�������ɔ������܂�</br>                  
        /// <br>Programmer  : ���R</br>                                    
        /// <br>Date        : 2012/06/05</br> 
        /// <br>�Ǘ��ԍ�    : 10801804-00</br>
        /// </remarks>
        private void WordCoopyCheck()
        {
            // ���_�R�[�h
            Regex sectionRegex = new Regex(@"^\d+(\.)?\d*$");
            if (!String.IsNullOrEmpty(this.tEdit_SectionCode_St.DataText.TrimEnd()) && !sectionRegex.IsMatch(this.tEdit_SectionCode_St.DataText))
            {
                this.tEdit_SectionCode_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this.tEdit_SectionCode_Ed.DataText.TrimEnd()) && !sectionRegex.IsMatch(this.tEdit_SectionCode_Ed.DataText))
            {
                this.tEdit_SectionCode_Ed.Text = String.Empty;
            }
            // ���[�J�[
            int goodsMakerStCode = this.tNedit_GoodsMakerCd_St.GetInt();
            int goodsMakerEdCode = this.tNedit_GoodsMakerCd_Ed.GetInt();
            if (goodsMakerStCode == 0 && this.tNedit_GoodsMakerCd_St.Text.Trim().Length > 0)
            {
                this.tNedit_GoodsMakerCd_St.Text = String.Empty;
            }
            if (goodsMakerEdCode == 0 && this.tNedit_GoodsMakerCd_Ed.Text.Trim().Length > 0)
            {
                this.tNedit_GoodsMakerCd_Ed.Text = String.Empty;
            }
            // �i��
            if (this.tEdit_GoodsNo_St.DataText.Contains("�@") || this.tEdit_GoodsNo_St.DataText.Contains(" "))
            {
                this.tEdit_GoodsNo_St.Text = String.Empty;
            }
            if (this.tEdit_GoodsNo_Ed.DataText.Contains("�@") || this.tEdit_GoodsNo_Ed.DataText.Contains(" "))
            {
                this.tEdit_GoodsNo_Ed.Text = String.Empty;
            }
            Regex goodsRegex = new Regex(@"^[\uFF61-\uFF9F-A-Za-z0-9\x00-\xff]*$");
            if (!String.IsNullOrEmpty(this.tEdit_GoodsNo_St.DataText.TrimEnd()) && !goodsRegex.IsMatch(this.tEdit_GoodsNo_St.DataText.Trim()))
            {
                this.tEdit_GoodsNo_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) && !goodsRegex.IsMatch(this.tEdit_GoodsNo_Ed.DataText.Trim()))
            {
                this.tEdit_GoodsNo_Ed.Text = String.Empty;
            }

            // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>
            //BL�R�[�h
            int bLGoodsCodeSt = this.tNedit_BLGoodsCode_St.GetInt();
            int bLGoodsCodeEd = this.tNedit_BLGoodsCode_Ed.GetInt();
            if (bLGoodsCodeSt == 0 && this.tNedit_GoodsMakerCd_St.Text.Trim().Length > 0)
            {
                this.tNedit_BLGoodsCode_St.Text = String.Empty;
            }
            if (bLGoodsCodeEd == 0 && this.tNedit_BLGoodsCode_Ed.Text.Trim().Length > 0)
            {
                this.tNedit_BLGoodsCode_Ed.Text = String.Empty;
            }

            //������
            int goodsMGroupSt = this.tNedit_GoodsMGroup_St.GetInt();
            int goodsMGroupEd = this.tNedit_GoodsMGroup_Ed.GetInt();
            if (goodsMGroupSt == 0 && this.tNedit_GoodsMGroup_St.Text.Trim().Length > 0)
            {
                this.tNedit_GoodsMGroup_St.Text = String.Empty;
            }
            if (goodsMGroupEd == 0 && this.tNedit_GoodsMGroup_Ed.Text.Trim().Length > 0)
            {
                this.tNedit_GoodsMGroup_Ed.Text = String.Empty;
            }
            // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<
        }

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note		: �{�^���A�C�R���ݒ菈�����s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2012/06/05</br>
        /// <br>�Ǘ��ԍ�    : 10801804-00</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        // --- ADD liusy 2012/09/24 for Redmine#32367---------->>>>>
        #region �� �ݒ��ʕύX�C�x���g
        /// <summary>
        /// �ݒ��ʕύX�C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@ : �ݒ��ʂ��ύX���ꂽ�Ƃ��ɔ������܂��B</br>
        /// <br>Programmer : liusy</br>
        /// <br>Date       : 2012/09/24</br>
        /// </remarks>
        private void SetKind_tComboEditor_ValueChanged(object sender, EventArgs e)
        {

            this.BLGoodsCode_Label.Location = new System.Drawing.Point(12, 188);
            this.BlCodeRange_Label.Location = new System.Drawing.Point(315, 188);
            this.tNedit_BLGoodsCode_St.Location = new System.Drawing.Point(147, 188);
            this.tNedit_BLGoodsCode_Ed.Location = new System.Drawing.Point(341, 188);
            this.ub_St_BLGoodsGuide.Location = new System.Drawing.Point(203, 188);
            this.ub_Ed_BLGoodsGuide.Location = new System.Drawing.Point(397, 188);

            this.GoodMGroup_Label.Location = new System.Drawing.Point(12, 214);
            this.GoodMGroupRange_Label.Location = new System.Drawing.Point(315, 214);
            this.tNedit_GoodsMGroup_St.Location = new System.Drawing.Point(147, 214);
            this.tNedit_GoodsMGroup_Ed.Location = new System.Drawing.Point(341, 214);
            this.ub_St_GoodsMGroupGuid.Location = new System.Drawing.Point(195, 214);
            this.ub_Ed_GoodsMGroupGuid.Location = new System.Drawing.Point(391, 214);

            //���_�{�i��
            if (this.SetKind_tComboEditor.Text == SETKIND_1)
            {

                this.tEdit_GoodsNo_St.Enabled = true;
                this.tEdit_GoodsNo_Ed.Enabled = true;

                this.tNedit_BLGoodsCode_St.Enabled = false;
                this.tNedit_BLGoodsCode_Ed.Enabled = false;
                this.ub_St_BLGoodsGuide.Enabled = false;
                this.ub_Ed_BLGoodsGuide.Enabled = false;

                this.tNedit_GoodsMGroup_St.Enabled = false;
                this.tNedit_GoodsMGroup_Ed.Enabled = false;
                this.ub_St_GoodsMGroupGuid.Enabled = false;
                this.ub_Ed_GoodsMGroupGuid.Enabled = false;


                this.GoodNo_Label.Visible = true;
                this.GoodNoRange_Label.Visible = true;
                this.tEdit_GoodsNo_St.Visible = true;
                this.tEdit_GoodsNo_Ed.Visible = true;

                this.BLGoodsCode_Label.Visible = false;
                this.BlCodeRange_Label.Visible = false;
                this.tNedit_BLGoodsCode_St.Visible = false;
                this.tNedit_BLGoodsCode_Ed.Visible = false;
                this.ub_St_BLGoodsGuide.Visible = false;
                this.ub_Ed_BLGoodsGuide.Visible = false;

                this.GoodMGroup_Label.Visible = false;
                this.GoodMGroupRange_Label.Visible = false;
                this.tNedit_GoodsMGroup_St.Visible = false;
                this.tNedit_GoodsMGroup_Ed.Visible = false;
                this.ub_St_GoodsMGroupGuid.Visible = false;
                this.ub_Ed_GoodsMGroupGuid.Visible = false;
            }
            //���_�{�����ށ{���[�J�[�{BL�R�[�h
            else if (this.SetKind_tComboEditor.Text == SETKIND_2)
            {

                this.tEdit_GoodsNo_St.Enabled = false;
                this.tEdit_GoodsNo_Ed.Enabled = false;

                this.tNedit_BLGoodsCode_St.Enabled = true;
                this.tNedit_BLGoodsCode_Ed.Enabled = true;
                this.ub_St_BLGoodsGuide.Enabled = true;
                this.ub_Ed_BLGoodsGuide.Enabled = true;

                this.tNedit_GoodsMGroup_St.Enabled = true;
                this.tNedit_GoodsMGroup_Ed.Enabled = true;
                this.ub_St_GoodsMGroupGuid.Enabled = true;
                this.ub_Ed_GoodsMGroupGuid.Enabled = true;

                this.GoodNo_Label.Visible = false;
                this.GoodNoRange_Label.Visible = false;
                this.tEdit_GoodsNo_St.Visible = false;
                this.tEdit_GoodsNo_Ed.Visible = false;

                this.BLGoodsCode_Label.Visible = true;
                this.BlCodeRange_Label.Visible = true;
                this.tNedit_BLGoodsCode_St.Visible = true;
                this.tNedit_BLGoodsCode_Ed.Visible = true;
                this.ub_St_BLGoodsGuide.Visible = true;
                this.ub_Ed_BLGoodsGuide.Visible = true;

                this.GoodMGroup_Label.Visible = true;
                this.GoodMGroupRange_Label.Visible = true;
                this.tNedit_GoodsMGroup_St.Visible = true;
                this.tNedit_GoodsMGroup_Ed.Visible = true;
                this.ub_St_GoodsMGroupGuid.Visible = true;
                this.ub_Ed_GoodsMGroupGuid.Visible = true;

                this.BLGoodsCode_Label.Location = new System.Drawing.Point(12, 136);
                this.BlCodeRange_Label.Location = new System.Drawing.Point(315, 136);
                this.tNedit_BLGoodsCode_St.Location = new System.Drawing.Point(147, 136);
                this.tNedit_BLGoodsCode_Ed.Location = new System.Drawing.Point(341, 136);
                this.ub_St_BLGoodsGuide.Location = new System.Drawing.Point(203, 136);
                this.ub_Ed_BLGoodsGuide.Location = new System.Drawing.Point(397, 136);

                this.GoodMGroup_Label.Location = new System.Drawing.Point(12, 162);
                this.GoodMGroupRange_Label.Location = new System.Drawing.Point(315, 162);
                this.tNedit_GoodsMGroup_St.Location = new System.Drawing.Point(147, 162);
                this.tNedit_GoodsMGroup_Ed.Location = new System.Drawing.Point(341, 162);
                this.ub_St_GoodsMGroupGuid.Location = new System.Drawing.Point(195, 162);
                this.ub_Ed_GoodsMGroupGuid.Location = new System.Drawing.Point(391, 162);
            }
            //���_�{�����ށ{���[�J�[
            else if (this.SetKind_tComboEditor.Text == SETKIND_3)
            {

                this.tEdit_GoodsNo_St.Enabled = false;
                this.tEdit_GoodsNo_Ed.Enabled = false;

                this.tNedit_BLGoodsCode_St.Enabled = false;
                this.tNedit_BLGoodsCode_Ed.Enabled = false;
                this.ub_St_BLGoodsGuide.Enabled = false;
                this.ub_Ed_BLGoodsGuide.Enabled = false;

                this.tNedit_GoodsMGroup_St.Enabled = true;
                this.tNedit_GoodsMGroup_Ed.Enabled = true;
                this.ub_St_GoodsMGroupGuid.Enabled = true;
                this.ub_Ed_GoodsMGroupGuid.Enabled = true;

                this.GoodNo_Label.Visible = false;
                this.GoodNoRange_Label.Visible = false;
                this.tEdit_GoodsNo_St.Visible = false;
                this.tEdit_GoodsNo_Ed.Visible = false;

                this.BLGoodsCode_Label.Visible = false;
                this.BlCodeRange_Label.Visible = false;
                this.tNedit_BLGoodsCode_St.Visible = false;
                this.tNedit_BLGoodsCode_Ed.Visible = false;
                this.ub_St_BLGoodsGuide.Visible = false;
                this.ub_Ed_BLGoodsGuide.Visible = false;

                this.GoodMGroup_Label.Visible = true;
                this.GoodMGroupRange_Label.Visible = true;
                this.tNedit_GoodsMGroup_St.Visible = true;
                this.tNedit_GoodsMGroup_Ed.Visible = true;
                this.ub_St_GoodsMGroupGuid.Visible = true;
                this.ub_Ed_GoodsMGroupGuid.Visible = true;

                this.GoodMGroup_Label.Location = new System.Drawing.Point(12, 136);
                this.GoodMGroupRange_Label.Location = new System.Drawing.Point(315, 136);
                this.tNedit_GoodsMGroup_St.Location = new System.Drawing.Point(147, 136);
                this.tNedit_GoodsMGroup_Ed.Location = new System.Drawing.Point(341, 136);
                this.ub_St_GoodsMGroupGuid.Location = new System.Drawing.Point(195, 136);
                this.ub_Ed_GoodsMGroupGuid.Location = new System.Drawing.Point(391, 136);
            }
            //�@���_�{���[�J�[
            else if (this.SetKind_tComboEditor.Text == SETKIND_4)
            {

                this.tEdit_GoodsNo_St.Enabled = false;
                this.tEdit_GoodsNo_Ed.Enabled = false;

                this.tNedit_BLGoodsCode_St.Enabled = false;
                this.tNedit_BLGoodsCode_Ed.Enabled = false;
                this.ub_St_BLGoodsGuide.Enabled = false;
                this.ub_Ed_BLGoodsGuide.Enabled = false;

                this.tNedit_GoodsMGroup_St.Enabled = false;
                this.tNedit_GoodsMGroup_Ed.Enabled = false;
                this.ub_St_GoodsMGroupGuid.Enabled = false;
                this.ub_Ed_GoodsMGroupGuid.Enabled = false;

                this.GoodNo_Label.Visible = false;
                this.GoodNoRange_Label.Visible = false;
                this.tEdit_GoodsNo_St.Visible = false;
                this.tEdit_GoodsNo_Ed.Visible = false;

                this.BLGoodsCode_Label.Visible = false;
                this.BlCodeRange_Label.Visible = false;
                this.tNedit_BLGoodsCode_St.Visible = false;
                this.tNedit_BLGoodsCode_Ed.Visible = false;
                this.ub_St_BLGoodsGuide.Visible = false;
                this.ub_Ed_BLGoodsGuide.Visible = false;

                this.GoodMGroup_Label.Visible = false;
                this.GoodMGroupRange_Label.Visible = false;
                this.tNedit_GoodsMGroup_St.Visible = false;
                this.tNedit_GoodsMGroup_Ed.Visible = false;
                this.ub_St_GoodsMGroupGuid.Visible = false;
                this.ub_Ed_GoodsMGroupGuid.Visible = false;
            }
            //�S��
            else 
            {

                this.tEdit_GoodsNo_St.Enabled = true;
                this.tEdit_GoodsNo_Ed.Enabled = true;

                this.tNedit_BLGoodsCode_St.Enabled = true;
                this.tNedit_BLGoodsCode_Ed.Enabled = true;
                this.ub_St_BLGoodsGuide.Enabled = true;
                this.ub_Ed_BLGoodsGuide.Enabled = true;

                this.tNedit_GoodsMGroup_St.Enabled = true;
                this.tNedit_GoodsMGroup_Ed.Enabled = true;
                this.ub_St_GoodsMGroupGuid.Enabled = true;
                this.ub_Ed_GoodsMGroupGuid.Enabled = true;

                this.GoodNo_Label.Visible = true;
                this.GoodNoRange_Label.Visible = true;
                this.tEdit_GoodsNo_St.Visible = true;
                this.tEdit_GoodsNo_Ed.Visible = true;

                this.BLGoodsCode_Label.Visible = true;
                this.BlCodeRange_Label.Visible = true;
                this.tNedit_BLGoodsCode_St.Visible = true;
                this.tNedit_BLGoodsCode_Ed.Visible = true;
                this.ub_St_BLGoodsGuide.Visible = true;
                this.ub_Ed_BLGoodsGuide.Visible = true;

                this.GoodMGroup_Label.Visible = true;
                this.GoodMGroupRange_Label.Visible = true;
                this.tNedit_GoodsMGroup_St.Visible = true;
                this.tNedit_GoodsMGroup_Ed.Visible = true;
                this.ub_St_GoodsMGroupGuid.Visible = true;
                this.ub_Ed_GoodsMGroupGuid.Visible = true;
            }

            this.tEdit_SectionCode_St.Clear();
            this.tEdit_SectionCode_Ed.Clear();

            this.tNedit_GoodsMakerCd_St.Clear();
            this.tNedit_GoodsMakerCd_Ed.Clear();

            this.tEdit_GoodsNo_St.Clear();
            this.tEdit_GoodsNo_Ed.Clear();

            this.tNedit_BLGoodsCode_St.Clear();
            this.tNedit_BLGoodsCode_Ed.Clear();

            this.tNedit_GoodsMGroup_St.Clear();
            this.tNedit_GoodsMGroup_Ed.Clear();
        }
        #endregion
        // --- ADD liusy 2012/09/24 for Redmine#32367----------<<<<<
        #endregion�@�� Private Method


    }
}