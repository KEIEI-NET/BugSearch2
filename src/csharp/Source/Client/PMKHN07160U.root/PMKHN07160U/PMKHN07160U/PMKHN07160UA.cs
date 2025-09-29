//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�}�X�^�i�G�N�X�|�[�g�j
// �v���O�����T�v   : ���i�}�X�^�i�G�N�X�|�[�g�j���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2009/05/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �C �� ��  2009/08/17  �C�����e : �uBL�R�[�h�K�C�h�v�̉��C
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �C �� ��  2010/05/12  �C�����e : Mantis.15352�t�B�[�h�o�b�N�@���i�}�X�^�ɑ��݂��Ȃ��i�Ԃ��w�肵�Ē��o�����
//                                  �G���[�ƂȂ�s��̏C���i�Y���Ȃ��̃R�����g�ǉ��j
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
    /// ���i�}�X�^�i�G�N�X�|�[�g�j
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�}�X�^�i�G�N�X�|�[�g�j�N���X�̃C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2009.05.13</br>
    /// <br>Note       : �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2019/08/19</br>
    /// </remarks>
    public partial class PMKHN07160UA : Form, IExportConditionInpType
    {
        #region �� Constructor
        /// <summary>
        /// �N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.05.12</br>
        /// <br>Note        : �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�</br>
        /// <br>Programmer  : �c����</br>
        /// <br>Date        : 2019/08/19</br>
        /// <br></br>
        /// </remarks>
        public PMKHN07160UA()
        {
            InitializeComponent();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _goodsExportAcs = new GoodsExportAcs();
            _goodsExportWork = new GoodsExportWork();
            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.SetUIMemInputControl();

            this.TextOutPutOprtnHisLogAcsObj = new TextOutPutOprtnHisLogAcs(); // ADD 2019/08/19 �c���� �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή�
        }
        #endregion

        #region �� Private member
        // ���i�}�X�^�i�G�N�X�|�[�g�j�A�N�Z�X�N���X
        private GoodsExportAcs _goodsExportAcs;
        // ���i�}�X�^�i�G�N�X�|�[�g�j�N���X
        private GoodsExportWork _goodsExportWork;

        // ��ƃR�[�h
        private string _enterpriseCode;
        // ���[�J�[�K�C�h�A�N�Z�X�N���X
        private GoodsAcs _goodsAcs;
        private BLGoodsCdAcs _blGoodsCdAcs; // ADD 2009/08/17

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
        private const string ct_CLASSID = "PMKHN07160UA";
        private const string PMKHN07160U_PRPID = "PMKHN07160U.xml";
        private const string PRINTSET_TABLE = "GoodsExp";

        //----- ADD 2019/08/19 �c���� �e�L�X�g�o�͑��샍�O����яo�͎��A���[�g���b�Z�[�W�ǉ��Ή� ----->>>>>
        // �ŏ�����
        private const string StartStr = "�ŏ�����";
        // �Ō�܂�
        private const string EndStr = "�Ō�܂�";
        // �A�Z���u��ID
        private const string AssemblyID = "PMKHN07160U";
        // �A�Z���u����
        private const string AssemblyNm = "���i�}�X�^�i�G�N�X�|�[�g�j";
        // ���\�b�h��
        private const string MethodNm = "Extract";
        // ��ʏ���
        private const string MenuCon = "���[�J�[�F{0} �` {1},�a�k�R�[�h�F{2} �` {3},�i�ԁF{4} �` {5},÷��̧�ٖ��F{6}";
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
        /// <br>Date       : 2009.05.12</br>
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
        /// <br>Date       : 2009.05.12</br>
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
        /// <br>Date       : 2009.05.12</br>
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
            // ��ʏ���
            // ���[�J�[�R�[�h
            string makerCodeSt = this.tNedit_GoodsMakerCd_St.Text.Trim();
            makerCodeSt = string.IsNullOrEmpty(makerCodeSt) ? StartStr : makerCodeSt;
            string makerCodeEd = this.tNedit_GoodsMakerCd_Ed.Text.Trim();
            makerCodeEd = string.IsNullOrEmpty(makerCodeEd) ? EndStr : makerCodeEd;
            // BL�R�[�h
            string blCodeSt = this.tNedit_BLGoodsCode_St.Text.Trim();
            blCodeSt = string.IsNullOrEmpty(blCodeSt) ? StartStr : blCodeSt;
            string blCodeEd = this.tNedit_BLGoodsCode_Ed.Text.Trim();
            blCodeEd = string.IsNullOrEmpty(blCodeEd) ? EndStr : blCodeEd;
            // �i��
            string goodsNoSt = this.tEdit_GoodsNo_St.Text.Trim();
            goodsNoSt = string.IsNullOrEmpty(goodsNoSt) ? StartStr : goodsNoSt;
            string goodsNoEd = this.tEdit_GoodsNo_Ed.Text.Trim();
            goodsNoEd = string.IsNullOrEmpty(goodsNoEd) ? EndStr : goodsNoEd;
            // �o�̓t�@�C����
            string filePath = this.tEdit_TextFileName.Text.Trim();
            string logOperationData = string.Format(MenuCon, makerCodeSt, makerCodeEd, blCodeSt, blCodeEd, goodsNoSt, goodsNoEd, filePath);
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
            this.SetExtraInfoFromScreen();
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
                status = this._goodsExportAcs.Search(_goodsExportWork, out dataTable);
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
                        this.Bind_DataSet.Tables.Add(dataTable);
                        break;
                    }
                // 2010/05/12 Add >>>
                case (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN:
                    {
                        TMsgDisp.Show(						// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_INFO, 		// �G���[���x��
                            "PMKHN07160U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���i�}�X�^�i����߰āj", 			// �v���O��������
                            "Extract", 							// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�Y���f�[�^������܂���B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._goodsExportAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��

                        break;
                    }
                // 2010/05/12 Add <<<
                default:
                    {
                        TMsgDisp.Show(						// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            "PMKHN07160U", 						// �A�Z���u���h�c�܂��̓N���X�h�c
                            "���i�}�X�^�i����߰āj", 			// �v���O��������
                            "Extract", 							// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._goodsExportAcs, 				// �G���[�����������I�u�W�F�N�g
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
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int GetCSVInfo(ref object parameter)
        {
            SFCMN06002C printInfo = parameter as SFCMN06002C;
            printInfo.prpid = PMKHN07160U_PRPID;
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
        /// <br>Date       : 2009.05.12</br>
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

        #region �� Private Event
        #region �� �K�C�h����
        /// <summary>
        /// ���[�J�[�K�C�h�N���{�^���N���C�x���g                                               
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                              
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���[�J�[�K�C�h�N���b�N���ɔ������܂�</br>                  
        /// <br>Programmer  : ���R</br>                                    
        /// <br>Date        : 2009.05.12</br>                                        
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
                nextControl = this.tNedit_BLGoodsCode_St;
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
        /// BL�R�[�h�K�C�h�N���{�^���N���C�x���g                                               
        /// </summary>
        /// <param name="sender">�C�x���g�\�[�X</param>                              
        /// <param name="e">�C�x���g�f�[�^</param>
        /// <remarks>
        /// <br>Note�@�@�@  : BL�R�[�h�K�C�h�N���b�N���ɔ������܂�</br>                  
        /// <br>Programmer  : ���R</br>                                    
        /// <br>Date        : 2009.05.12</br>                                        
        /// </remarks>
        private void ub_St_BLGoodsCodeGuide_Click(object sender, EventArgs e)
        {
            // --- DEL 2009/08/17 ------------------------------->>>>>
            //if (this._goodsAcs == null)
            //{
            //    this._goodsAcs = new GoodsAcs();
            //    string msg;
            //    this._goodsAcs.SearchInitial(this._enterpriseCode, "", out msg);
            //}

            //BLGoodsCdUMnt blGoodsCdUMnt;
            //int status = this._goodsAcs.ExecuteBLGoodsCd(out blGoodsCdUMnt);
            // --- DEL 2009/08/17 ------------------------------<<<<<

            // --- ADD 2009/08/17 ------------------------------->>>>>
            if (this._blGoodsCdAcs == null)
            {
                this._blGoodsCdAcs = new BLGoodsCdAcs();
            }

            BLGoodsCdUMnt blGoodsCdUMnt;
            // BL�R�[�h�K�C�h�\��
            int status = this._blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsCdUMnt);
            // --- ADD 2009/08/17 ------------------------------<<<<<

            if (status != 0) return;

            TNedit targetControl;
            Control nextControl;
            if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_St;
                nextControl = this.tNedit_BLGoodsCode_Ed;
            }
            else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
            {
                targetControl = this.tNedit_BLGoodsCode_Ed;
                nextControl = this.tEdit_GoodsNo_St;
            }
            else
            {
                return;
            }

            targetControl.SetInt(blGoodsCdUMnt.BLGoodsCode);
            nextControl.Focus();
        }
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
        /// <br>Date        : 2009.05.12</br>
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
        /// <br>Date        : 2009.04.01</br>                                       
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        // ���[�J�[(�J�n)�����[�J�[(�I��)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        // ���[�J�[(�I��)���a�k�R�[�h(�J�n)
                        e.NextCtrl = this.tNedit_BLGoodsCode_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        // �a�k�R�[�h(�J�n)���a�k�R�[�h(�I��)
                        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        // �a�k�R�[�h(�I��)�� �i��(�J�n)
                        e.NextCtrl = tEdit_GoodsNo_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_GoodsNo_St)
                    {
                        // �i��(�J�n)���i��(�I��)
                        e.NextCtrl = this.tEdit_GoodsNo_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_GoodsNo_Ed)
                    {
                        // �i��(�I��)�� ÷��̧�ٖ�
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ÷��̧�ٖ��� �t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileName;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileName)
                    {
                        // �t�@�C���_�C�A���O�� ���[�J�[(�J�n)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if (e.Key == Keys.Tab)
                {
                    if (e.PrevCtrl == this.tNedit_GoodsMakerCd_St)
                    {
                        // ���[�J�[(�J�n)���t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tNedit_GoodsMakerCd_Ed)
                    {
                        // ���[�J�[(�I��)�����[�J�[(�J�n)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_St;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_St)
                    {
                        // �a�k�R�[�h(�J�n)�����[�J�[(�I��)
                        e.NextCtrl = this.tNedit_GoodsMakerCd_Ed;
                    }
                    else if (e.PrevCtrl == this.tNedit_BLGoodsCode_Ed)
                    {
                        // �a�k�R�[�h(�I��)�� �a�k�R�[�h(�J�n)
                        e.NextCtrl = this.tNedit_BLGoodsCode_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_GoodsNo_St)
                    {
                        // �i��(�J�n)���a�k�R�[�h(�I��)
                        e.NextCtrl = this.tNedit_BLGoodsCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_GoodsNo_Ed)
                    {
                        // �i��(�I��)�� �i��(�J�n)
                        e.NextCtrl = this.tEdit_GoodsNo_St;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ÷��̧�ٖ��� �i��(�I��)
                        e.NextCtrl = this.tEdit_GoodsNo_Ed;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileName)
                    {
                        // �t�@�C���_�C�A���O�� ÷��̧�ٖ�
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                }
            }
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
        /// <br>Date        : 2009.05.12</br>                                       
        /// </remarks>
        private void Center_AfterExitEditMode(object sender, EventArgs e)
        {
            // Coopy�`�F�b�N
            WordCoopyCheck();
        }
        #endregion�@�� Private Event

        #region �� Control Event
        /// <summary>
        /// PMKHN07160UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void PMKHN07160UA_Load(object sender, EventArgs e)
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
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                ct_CLASSID,							// �A�Z���u���h�c�܂��̓N���X�h�c
                "���i�}�X�^�i����߰āj",			// �v���O��������
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
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // ���[�J�[
            this.tNedit_GoodsMakerCd_St.Clear();
            this.tNedit_GoodsMakerCd_Ed.Clear();
            // �a�k�R�[�h
            this.tNedit_BLGoodsCode_St.Clear();
            this.tNedit_BLGoodsCode_Ed.Clear();
            // �i��
            this.tEdit_GoodsNo_St.Clear();
            this.tEdit_GoodsNo_Ed.Clear();


            this.SetIconImage(this.ub_St_GoodsMakerCdGuide, Size16_Index.STAR1);
            this.SetIconImage(this.ub_Ed_GoodsMakerCdGuide, Size16_Index.STAR1);
            this.SetIconImage(this.ub_St_BLGoodsCodeGuide, Size16_Index.STAR1);
            this.SetIconImage(this.ub_Ed_BLGoodsCodeGuide, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_TextFileName, Size16_Index.STAR1);
            // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
            this.uiMemInput1.ReadMemInput();
            this.tNedit_GoodsMakerCd_St.Focus();
        }
        #endregion

        #region �� ��ʐݒ�ۑ�
        /// <summary>
        /// UIMemInput�̕ۑ����ڐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : UIMemInput�̕ۑ����ڐݒ���s���B</br>
        /// <br>Programmer : ���R</br>
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

        #region �� ������񏈗�
        /// <summary>
        /// ������񏈗�
        /// </summary>
        /// <remarks>
        /// <br>Note		: ������񏈗����s���B</br>
        /// <br>Programmer	: ���R</br>
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void SetExtraInfoFromScreen()
        {
            // ��ƃR�[�h
            _goodsExportWork.EnterpriseCode = this._enterpriseCode;
            // ���[�J�[�J�n
            _goodsExportWork.GoodsMakerCdSt = this.tNedit_GoodsMakerCd_St.GetInt();

            // ���[�J�[�I��
            _goodsExportWork.GoodsMakerCdEd = this.tNedit_GoodsMakerCd_Ed.GetInt();

            // �a�k�R�[�h�J�n
            _goodsExportWork.BLGoodsCodeSt = this.tNedit_BLGoodsCode_St.GetInt();

            // �a�k�R�[�h�I��
            _goodsExportWork.BLGoodsCodeEd = this.tNedit_BLGoodsCode_Ed.GetInt();

            // �i�ԊJ�n
            _goodsExportWork.GoodsNoSt = this.tEdit_GoodsNo_St.DataText.TrimEnd();

            // �i�ԏI��
            _goodsExportWork.GoodsNoEd = this.tEdit_GoodsNo_Ed.DataText.TrimEnd();
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
        /// <br>Date		: 2009.05.12</br>
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

            // BL�R�[�h
            if ((this.tNedit_BLGoodsCode_St.GetInt() != 0) &&
                (this.tNedit_BLGoodsCode_Ed.GetInt() != 0) &&
                this.tNedit_BLGoodsCode_St.GetInt() > this.tNedit_BLGoodsCode_Ed.GetInt())
            {
                errMessage = string.Format("�a�k�R�[�h{0}", ct_RANGEERROR);
                errComponent = this.tNedit_BLGoodsCode_St;
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

            return status;
        }

        /// <summary>
        /// Coopy�`�F�b�N����                                              
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@  : Copy�������ɔ������܂�</br>                  
        /// <br>Programmer  : ���R</br>                                    
        /// <br>Date        : 2009.05.12</br>                                        
        /// </remarks>
        private void WordCoopyCheck()
        {
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

            int blGoodsStCode = this.tNedit_BLGoodsCode_St.GetInt();
            int blGoodsEdCode = this.tNedit_BLGoodsCode_Ed.GetInt();
            if (blGoodsStCode == 0 && this.tNedit_BLGoodsCode_St.Text.Trim().Length > 0)
            {
                this.tNedit_BLGoodsCode_St.Text = String.Empty;
            }
            if (blGoodsEdCode == 0 && this.tNedit_BLGoodsCode_Ed.Text.Trim().Length > 0)
            {
                this.tNedit_BLGoodsCode_Ed.Text = String.Empty;
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
            if (!String.IsNullOrEmpty(this.tEdit_GoodsNo_St.DataText.TrimEnd()) && !r1.IsMatch(this.tEdit_GoodsNo_St.DataText.Trim()))
            {
                this.tEdit_GoodsNo_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this.tEdit_GoodsNo_Ed.DataText.TrimEnd()) && !r1.IsMatch(this.tEdit_GoodsNo_Ed.DataText.Trim()))
            {
                this.tEdit_GoodsNo_Ed.Text = String.Empty;
            }
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
        /// <br>Date		: 2009.05.12</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion
        #endregion�@�� Private Method


    }
}