//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^�G�N�X�|�[�g���
// �v���O�����T�v   : �|���}�X�^�G�N�X�|�[�g��ʂ�\������
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  ********-** �쐬�S�� : FSI���� �f��
// �� �� ��  2013/06/12  �C�����e : �T�|�[�g�c�[���Ή��A�V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30521 �{�R�@�M�� 
// �C �� ��  2013.10.28  �C�����e : �|�����}�X�^�C���|�[�g�E�G�N�X�|�[�g�@�\�ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�               �쐬�S�� : ���V�@���M
// �C �� ��  2015/10/14   �C�����e : �N���X���d���̂��ߕύX 
//                                   StockMasExportAcs �� RateTextExportAcs
//                                   StockMasShWork �� RateTextShWork
//                                   ���ꊇ�u���ׁ̈A�R�����g�Ȃ�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
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

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    ///  �|���}�X�^�G�N�X�|�[�g���
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���}�X�^�G�N�X�|�[�g��ʃN���X�̒�`</br>
    /// <br>Programmer : FSI���� �f��</br>
    /// <br>Date       : 2013/06/12</br>
    /// <br>Description: �|���}�X�^�G�N�X�|�[�g�@�\�ŋ��ʂ̏����̒�`</br>
    /// </remarks>
    public partial class PMKHN09812UA : Form, ICSVExportConditionInpType
    {
        #region �� Constructor
        /// <summary>
        /// �N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �N���X�̏���������уC���X�^���X�̐������s��</br>
        /// <br>Programmer	: FSI���� �f��</br>
        /// <br>Date		: 2013/06/12</br>
        /// <br>>Description: �|���}�X�^�G�N�X�|�[�g�@�\�̏����̒�`</br>
        /// </remarks>
        public PMKHN09812UA()
        {
            InitializeComponent();
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            _rateTextExportAcs = new RateTextExportAcs();
            _rateTextExportWork = new RateTextShWork();
            _secInfoSetAcs = new SecInfoSetAcs();  // Add 2013.10.28 T.MOTOYAMA

            // UI�ݒ�ۑ��R���|�[�l���g�ݒ�
            this.SetUIMemInputControl();

            // �_�~�[���s�i�R���p�C�����x���Ή�
            ExecCsvConvertEvent = null;
            if (null != ExecCsvConvertEvent)
            {
                int? dummyVal = 0;
                ExecCsvConvertEvent(null, ref dummyVal);
            }
        }
        #endregion

        #region �� Private member
        // �|���}�X�^�G�N�X�|�[�g �A�N�Z�T�N���X
        private RateTextExportAcs _rateTextExportAcs;
        // �|���}�X�^�G�N�X�|�[�g ���o�����N���X�N���X
        private RateTextShWork _rateTextExportWork;

        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
        // ���_�A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs;
        // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

        // ��ƃR�[�h
        private string _enterpriseCode;

        #endregion �� Private member

        #region  �� Private cost

        ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
        private const string UNITPRICEKIND_1 = "�����ݒ�";
        private const string UNITPRICEKIND_2 = "�����ݒ�";
        private const string UNITPRICEKIND_3 = "���i�ݒ�";
        // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

        #endregion

        #region �� ICSVExportConditionInpType �����o
        #region �� Public Event
        /// <summary> �e�c�[���o�[�ݒ�C�x���g </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        /// <summary> �C�x���g�ݒ� </summary>
        /// <remarks> ���Ӑ�}�X�^�̂悤�ɁA�W���̏����ł͑���Ȃ��ꍇ�Ɏg�p����</remarks>
        public event ExecCsvConvertEventHandler ExecCsvConvertEvent;

        #endregion �� Public Event

        #region �� Public Method
        /// <summary>
        /// �|���}�X�^�G�N�X�|�[�g�O�m�F����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : �|���}�X�^�G�N�X�|�[�g�O�m�F�������s���B(���̓`�F�b�N�Ȃ�)</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
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
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public void GetBindDataSet(ref System.Data.DataSet bindDataSet, ref string tableName)
        {
            bindDataSet = this.Bind_DataSet;
            tableName = Properties.Resources.PRINTSET_TABLE;
        }

        /// <summary>
        /// ���o�f�[�^����
        /// </summary>
        /// <param name="parameter">�p�����[�^</param>
        /// <returns>0( �Œ� )</returns>
        /// <remarks>
        /// <br>Note       : �O���b�h�Ƀo�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public int Extract(ref object parameter)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            this.uLabel_OutPutNum.Text = Properties.Resources.LabelTxtOutPutNum;
            // ��ʁ����o�����N���X
            this.SetExtraInfoFromScreen();

            // ���C���t���[������ȉ��̒l���擾
            Dictionary<string, object> paramDic = parameter as Dictionary<string, object>;

            this.Bind_DataSet.Tables.Clear();
            DataTable dataTable;

            try
            {
                // ����
                status = this._rateTextExportAcs.Search(_rateTextExportWork, out dataTable);
            }
            catch
            {
                dataTable = null;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
            }
            switch (status)
            {
                case (int)ConstantManagement.MethodResult.ctFNC_NORMAL:
                    {
                        // BL�R�[�h�N���X���f�[�^�Z�b�g�֓W�J����
                        this.Bind_DataSet.Tables.Add(dataTable);
                        break;
                    }
                default:
                    {
                        // �_�C�A���O�����
                        SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                        form = paramDic["formexport"] as SFCMN00299CA;
                        form.Close();

                        TMsgDisp.Show(						    // �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOP, 		// �G���[���x��
                            Properties.Resources.ClassID,       // �A�Z���u���h�c�܂��̓N���X�h�c
                            Properties.Resources.ProgramName,   // �v���O��������
                            "Extract", 							// ��������
                            TMsgDisp.OPE_GET, 					// �I�y���[�V����
                            "�ǂݍ��݂Ɏ��s���܂����B", 		// �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._rateTextExportAcs,            // �G���[�����������I�u�W�F�N�g
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
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public int GetCSVInfo(ref object parameter)
        {
            ArrayList paramList = parameter as ArrayList;

            // �o�̓X�L�[�}���X�g
            List<string> schemeList = new List<string>();
            // �o�͍��ڍő咷��
            Dictionary<string, int> maxLengthList = new Dictionary<string, int>();

            // ���_�R�[�h
            schemeList.Add("���_�R�[�h");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 2);
            // �P���|���ݒ�敪
            schemeList.Add("�P���|���ݒ�敪");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 4);
            // �P�����
            schemeList.Add("�P�����");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 1);
            // �|���ݒ�敪
            schemeList.Add("�|���ݒ�敪");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 2);
            // �|���ݒ�敪(���i)
            schemeList.Add("�|���ݒ�敪(���i)");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 1);
            // �|���ݒ薼��(���i)
            schemeList.Add("�|���ݒ薼��(���i)");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 50);
            // �|���ݒ�敪(���Ӑ�)
            schemeList.Add("�|���ݒ�敪(���Ӑ�)");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 1);
            // �|���ݒ薼��(���Ӑ�)
            schemeList.Add("�|���ݒ薼��(���Ӑ�)");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 50);
            // ���i���[�J�[�R�[�h
            schemeList.Add("���i���[�J�[�R�[�h");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 6);
            // ���i�ԍ�
            schemeList.Add("���i�ԍ�");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 40);
            // ���i�|�������N
            schemeList.Add("���i�|�������N");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 6);
            // ���i�|���O���[�v�R�[�h
            schemeList.Add("���i�|���O���[�v�R�[�h");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 4);
            // BL�O���[�v�R�[�h
            schemeList.Add("BL�O���[�v�R�[�h");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 5);
            // BL���i�R�[�h
            schemeList.Add("BL���i�R�[�h");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 8);
            // ���Ӑ�R�[�h
            schemeList.Add("���Ӑ�R�[�h");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 9);
            // ���Ӑ�|���O���[�v�R�[�h
            schemeList.Add("���Ӑ�|���O���[�v�R�[�h");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 4);
            // �d����R�[�h
            schemeList.Add("�d����R�[�h");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 9);
            // ���b�g��
            schemeList.Add("���b�g��");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 9);
            // ���i(����)
            schemeList.Add("���i(����)");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 12);
            // �|��
            schemeList.Add("�|��");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 9);
            // UP��
            schemeList.Add("UP��");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 5);
            // �e���m�ۗ�
            schemeList.Add("�e���m�ۗ�");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 5);
            // �P���[�������P��
            schemeList.Add("�P���[�������P��");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 9);
            // �P���[�������敪
            schemeList.Add("�P���[�������敪");
            maxLengthList.Add(schemeList[schemeList.Count - 1], 2);

            paramList.Add(schemeList);
            paramList.Add(maxLengthList);
            paramList.Add(this.tEdit_TextFileName.DataText.ToString());
            
            return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
        }

        /// <summary>
        /// ��ʕ\������
        /// </summary>
        /// <param name="parameter">�N���p�����[�^</param>
        /// <remarks>
        /// <br>Note	   : ��ʕ\�����s���B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
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
        /// �|���}�X�^�G�N�X�|�[�g��������
        /// </summary>
        /// <remarks>
        /// <br>Note	   : �e�L�X�g�ϊ������������s���B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public void AfterExportSuccess()
        {
            // �|���}�X�^�G�N�X�|�[�g������ɉ�ʂ̐ݒ荀�ڂ�ۑ�����(PM7����)
            this.uiMemInput1.WriteMemInput();

            this.uLabel_OutPutNum.Text =
                this.Bind_DataSet.Tables[Properties.Resources.PRINTSET_TABLE].DefaultView.Count.ToString(
                    Properties.Resources.LabelFmtOutPutNum);

            this.uLabel_OutPutNum.Text = String.Format("{0, 13}", this.uLabel_OutPutNum.Text);
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
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void ub_SectionCodeStGuid_Click(object sender, EventArgs e)
        {
            int status = 0;

            SecInfoSet secInfoSet�@=new SecInfoSet();

            // ���_�K�C�h�\��
            if (_secInfoSetAcs == null)
                _secInfoSetAcs = new SecInfoSetAcs();
            try
            {
                status = _secInfoSetAcs.ExecuteGuid(this._enterpriseCode, true, out secInfoSet);
            }
            catch
            {
            }            
            
            string tag = (string)((UltraButton)sender).Tag;
            TEdit targetControl = null;
            Control nextControl = null;
            if (status == 0)
            {
                if (((UltraButton)sender).Tag.ToString().CompareTo("1") == 0)
                {
                    targetControl = this._tEdit_SectionCode_St;
                    nextControl = this._tEdit_SectionCode_Ed;

                    ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
                    // ���_����(�J�n)
                    this.SectionCodeNm_tEdit_St.DataText = secInfoSet.SectionGuideNm;
                    // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
                }
                else if (((UltraButton)sender).Tag.ToString().CompareTo("2") == 0)
                {
                    targetControl = this._tEdit_SectionCode_Ed;
                    // nextControl = this.tNedit_ExpenseDivCd;    // Del 2013.10.28 T.MOTOYAMA
                    
                    ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
                    nextControl = this.UnitPriceKind_tComboEditor;
                    
                    // ���_����(�I��)
                    this.SectionCodeNm_tEdit_Ed.DataText = secInfoSet.SectionGuideNm;
                    // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
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
        #endregion // �� �K�C�h����

        #region  // Add 2013.10.28 T.MOTOYAMA ���_���̎擾����
        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCd">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note�@�@�@ : ���_���̂��擾���܂�</br>                 
        /// <br>Programmer : 30521 T.MOTOYAMA</br>
        /// <br>Date       : 2013.10.28</br>
        /// </remarks>
        private String GetSectionName(string sectionCd)
        {
            int status = 0;
            string sectionName = "";

            SecInfoSet secInfoSet = new SecInfoSet();

            // ���_�A�N�Z�X�N���X
            if (_secInfoSetAcs == null)
                _secInfoSetAcs = new SecInfoSetAcs();
            
            // �S�Ѓ��R�[�h�̏ꍇ
            if (sectionCd == "0" || sectionCd == "00")
            {
                sectionName = "�S��";
                return sectionName;
            }

            try
            {
                status = _secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, sectionCd);
            }
            catch
            {
                // ���_���̎擾�ł��Ȃ��Ă����ɏ����͂��Ȃ�
            }

            if (status == 0)
            {
                sectionName = secInfoSet.SectionGuideNm;
            }
            else
            {
                sectionName = "";
            }

            return sectionName;
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
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void uButton_TextFileName_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // �^�C�g���o�[�̕�����
                saveFileDialog.Title = Properties.Resources.SaveFileDialogTitle;
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
                saveFileDialog.Filter = Properties.Resources.SaveFileDialogFilter;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.tEdit_TextFileName.DataText = saveFileDialog.FileName;
                }
            }
        }
        #endregion // �� �t�@�C���_�C�A���O

        #region �� ChangeFocus
        /// <summary>
        /// ���L�[�ł̃t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���L�[�ł̃t�H�[�J�X�ړ����ɔ������܂�</br>                 
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void tArrowKeyControl1_ChangeFocus(object sender, Broadleaf.Library.Windows.Forms.ChangeFocusEventArgs e)
        {
            if (!e.ShiftKey)
            {
                // SHIFT�L�[������
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this._tEdit_SectionCode_St)
                    {
                        // ���_(�J�n)�����_�K�C�h�{�^��(�J�n)
                        // e.NextCtrl = this._tEdit_SectionCode_Ed;  // Del 2013.10.28 T.MOTOYAMA
                        e.NextCtrl = this.ub_SectionCodeStGuid;      // Add 2013.10.28 T.MOTOYAMA
                    }
                    ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
                    else if (e.PrevCtrl == this.ub_SectionCodeStGuid) // Add 2013.10.28 T.MOTOYAMA
                    {
                        // ���_�K�C�h�{�^��(�J�n)�����_(�I��)
                        e.NextCtrl = this._tEdit_SectionCode_Ed;
                    }
                    // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
                    else if (e.PrevCtrl == this._tEdit_SectionCode_Ed)
                    {
                        // ���_(�I��)�����_�K�C�h�{�^��(�I��)
                        // e.NextCtrl = this.tNedit_ExpenseDivCd;     // Del 2013.10.28 T.MOTOYAMA
                        e.NextCtrl = this.ub_SectionCodeEdGuid; // Add 2013.10.28 T.MOTOYAMA
                    }
                    ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
                    else if (e.PrevCtrl == this.ub_SectionCodeEdGuid)
                    {
                        // ���_�K�C�h�{�^��(�I��)���P�����
                        e.NextCtrl = this.UnitPriceKind_tComboEditor;
                    }
                    // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

                    // else if (e.PrevCtrl == this.tNedit_ExpenseDivCd)     // Del 2013.10.28 T.MOTOYAMA
                    else if (e.PrevCtrl == this.UnitPriceKind_tComboEditor) // Add 2013.10.28 T.MOTOYAMA
                    {
                        // �P����ށ� ÷��̧�ٖ�
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ÷��̧�ٖ��� �t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileName;
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileName)
                    {
                        // �t�@�C���_�C�A���O�� ���_(�J�n)
                        e.NextCtrl = this._tEdit_SectionCode_St;
                    }
                }
            }
            else
            {
                // SHIFT�L�[����
                if ((e.Key == Keys.Enter) || (e.Key == Keys.Tab))
                {
                    if (e.PrevCtrl == this._tEdit_SectionCode_St)
                    {
                        // ���_(�J�n)���t�@�C���_�C�A���O
                        e.NextCtrl = this.uButton_TextFileName;
                    }
                    else if (e.PrevCtrl == this._tEdit_SectionCode_Ed)
                    {
                        // ���_(�I��)�����_(�J�n)
                        e.NextCtrl = this._tEdit_SectionCode_St;
                    }
                    // else if (e.PrevCtrl == this.tNedit_ExpenseDivCd)     // Del 2013.10.28 T.MOTOYAMA
                    else if (e.PrevCtrl == this.UnitPriceKind_tComboEditor) // Add 2013.10.28 T.MOTOYAMA
                    {
                        // �P����ށ����_(�I��)
                        e.NextCtrl = this._tEdit_SectionCode_Ed;
                    }
                    else if (e.PrevCtrl == this.tEdit_TextFileName)
                    {
                        // ÷��̧�ٖ����P�����
                        // e.NextCtrl = this.tNedit_ExpenseDivCd;     // Del 2013.10.28 T.MOTOYAMA
                        e.NextCtrl = this.UnitPriceKind_tComboEditor; // Add 2013.10.28 T.MOTOYAMA
                    }
                    else if (e.PrevCtrl == this.uButton_TextFileName)
                    {
                        // �t�@�C���_�C�A���O��÷��̧�ٖ�
                        e.NextCtrl = this.tEdit_TextFileName;
                    }
                }
            }
            // Coopy�`�F�b�N
            WordCopyCheck();
        }
        #endregion // �� ChangeFocus

        /// <summary>
        /// �t�H�[�J�X�ړ��C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : �t�H�[�J�X�ړ����ɔ������܂�</br>                 
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void Center_AfterExitEditMode(object sender, EventArgs e)
        {
            // Coopy�`�F�b�N
            WordCopyCheck();
        }
        #endregion�@�� Private Event

        #region �� Control Event
        /// <summary>
        /// PMKHN09812UA_Load Event
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���[�U�[��̫�т�ǂݍ��ނƂ��ɔ�������</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void PMKHN09812UA_Load(object sender, EventArgs e)
        {
            this.InitializeScreen();
            if (ParentToolbarSettingEvent != null)
            {
                ParentToolbarSettingEvent(this);// �c�[���o�[�{�^���ݒ�C�x���g�N�� 
            }
        }
        #endregion

        #region �� Private Method

        #region �� �G���[���b�Z�[�W�\������ ( +1�̃I�[�o�[���[�h )
        /// <summary>�G���[���b�Z�[�W�\������</summary>
        /// <param name="iLevel">�G���[���x��</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <param name="status">�G���[�X�e�[�^�X</param>
        /// <remarks>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void MsgDispProc(emErrorLevel iLevel, string message, int status)
        {
            TMsgDisp.Show(
                iLevel, 							// �G���[���x��
                Properties.Resources.ClassID,       // �A�Z���u���h�c�܂��̓N���X�h�c
                Properties.Resources.ProgramName,   // �v���O��������
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
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void InitializeScreen()
        {
            // ���_
            this.ultraLabel5.Text = Properties.Resources.LabelTxtSection;
            this._tEdit_SectionCode_Ed.Clear();
            this._tEdit_SectionCode_St.Clear();

            // �P�����
            this.ultraLabel4.Text = "�P�����";
            // this.tNedit_ExpenseDivCd.Clear();           // Del 2013.10.28 T.MOTOYAMA
            
            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
            this.UnitPriceKind_tComboEditor.Items.Clear();
            this.UnitPriceKind_tComboEditor.Items.Add("", "");
            this.UnitPriceKind_tComboEditor.Items.Add("1", UNITPRICEKIND_1);
            this.UnitPriceKind_tComboEditor.Items.Add("2", UNITPRICEKIND_2);
            this.UnitPriceKind_tComboEditor.Items.Add("3", UNITPRICEKIND_3);
            // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
            
            //�{�^���A�C�R���ݒ�
            this.SetIconImage(this.ub_SectionCodeStGuid, Size16_Index.STAR1);
            this.SetIconImage(this.ub_SectionCodeEdGuid, Size16_Index.STAR1);
            this.SetIconImage(this.uButton_TextFileName, Size16_Index.STAR1);

            // �O��\����Ԃ��ۑ�����Ă���Ώ㏑��
            this.uiMemInput1.ReadMemInput();
            this._tEdit_SectionCode_St.Focus();
        }
        #endregion

        #region �� ��ʐݒ�ۑ�
        /// <summary>
        /// UIMemInput�̕ۑ����ڐݒ�
        /// </summary>
        /// <remarks>
        /// <br>Note	   : UIMemInput�̕ۑ����ڐݒ���s���B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void SetUIMemInputControl()
        {
            // ���͕ۑ����ڂ��Z�b�g
            List<Control> saveCtrAry = new List<Control>();

            saveCtrAry.Add(this.tEdit_TextFileName);
            saveCtrAry.Add(this._tEdit_SectionCode_St);
            saveCtrAry.Add(this._tEdit_SectionCode_Ed);
            // saveCtrAry.Add(this.tNedit_ExpenseDivCd); // Del 2013.10.28 T.MOTOYAMA

            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
            saveCtrAry.Add(this.SectionCodeNm_tEdit_St);
            saveCtrAry.Add(this.SectionCodeNm_tEdit_Ed);
            saveCtrAry.Add(this.UnitPriceKind_tComboEditor);
            // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
                        
            this.uiMemInput1.TargetControls = saveCtrAry;
            this.uiMemInput1.ReadOnLoad = false;

            // ���Close���ɉ�ʏ���ۑ����Ȃ�(PM7����)
            this.uiMemInput1.WriteOnClose = false;

        }
        #endregion

        #region �� ������񏈗�
        /// <summary>
        /// ������񏈗�
        /// </summary>
        /// <remarks>
        /// <br>Note		: ������񏈗����s���B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void SetExtraInfoFromScreen()
        {
            // ��ƃR�[�h
            _rateTextExportWork.EnterpriseCode = this._enterpriseCode;

            #region Del 2013.10.28 T.MOTOYAMA
            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA DEL STA
            //// ���_�R�[�h(�J�n)
            //_stockMasExportWork.SectionCodeSt = this.tEdit_SectionCode_St.DataText.TrimEnd();

            //// ���_�R�[�h(�I��)
            //_stockMasExportWork.SectionCodeEd = this.tEdit_SectionCode_Ed.DataText.TrimEnd();
            // 2013.10.28 T.MOTOYAMA DEL END ///////////////////////////////////////////////////////////////////
            #endregion
            
            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
            if (this._tEdit_SectionCode_St.Text == null)
                this._tEdit_SectionCode_St.Text = String.Empty;

            if (this._tEdit_SectionCode_Ed.Text == null)
                this._tEdit_SectionCode_Ed.Text = String.Empty;

            if (!String.IsNullOrEmpty(this._tEdit_SectionCode_St.Text.Trim()))
            {
                // ���_�R�[�h(�J�n)
                _rateTextExportWork.SectionCodeSt = this._tEdit_SectionCode_St.Text.PadLeft(2, '0');
            }
            else
            {
                _rateTextExportWork.SectionCodeSt = this._tEdit_SectionCode_St.Text;
            }

            if (!String.IsNullOrEmpty(this._tEdit_SectionCode_Ed.Text.Trim()))
            {
                // ���_�R�[�h(�I��)
                _rateTextExportWork.SectionCodeEd = this._tEdit_SectionCode_Ed.Text.PadLeft(2, '0');
            }
            else
            {
                _rateTextExportWork.SectionCodeSt = this._tEdit_SectionCode_Ed.Text;
            }
            // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

            // �P�����
            // _stockMasExportWork.WarehouseCdSt = this.tNedit_ExpenseDivCd.Text;  // Del 2013.10.28 T.MOTOYAMA
            
            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
            if (this.UnitPriceKind_tComboEditor.Value == null)
            {
                this.UnitPriceKind_tComboEditor.Value = "";
            }
            _rateTextExportWork.WarehouseCdSt = this.UnitPriceKind_tComboEditor.Value.ToString();
            // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////
        }
        #endregion //�� ������񏈗�

        #region ���@���̓`�F�b�N����
        /// <summary>
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <param name="errComponent">�G���[�����R���|�[�l���g</param>
        /// <returns>True:OK, False:NG</returns>
        /// <remarks>
        /// <br>Note		: ��ʂ̓��̓`�F�b�N���s���B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private bool ScreenInputCheck(ref string errMessage, ref Control errComponent)
        {
            bool status = true;
            // Coopy�`�F�b�N
            WordCopyCheck();
            string fileName = tEdit_TextFileName.DataText.Trim();
            if (fileName == string.Empty)
            {
                errMessage = Properties.Resources.MsgStrEmptyFileName;
                errComponent = this.tEdit_TextFileName;
                status = false;
                return status;
            }

            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
            // �t�@�C���̊g���q�`�F�b�N
            string stExtension = System.IO.Path.GetExtension(fileName);

            if (stExtension == ".CSV" ||
                stExtension == ".csv")
            {                
            }
            else
            {
                errMessage = "�g���q���s���ł��B";
                errComponent = this.tEdit_TextFileName;
                status = false;
                return status;
            }
            // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////

            // �t�@�C�����ɕs���������܂܂�Ă��邩�`�F�b�N
            try
            {
                // �܂��t�H���_���݂̃`�F�b�N
                if (!Directory.Exists(System.IO.Path.GetDirectoryName(fileName)))
                {
                    errMessage = Properties.Resources.MsgStrNotExistPath;
                    errComponent = this.tEdit_TextFileName;
                    status = false;
                    return status;
                }
                else
                {
                    string _fileName = fileName.Substring(fileName.LastIndexOf('\\') + 1);

                    if (_fileName.IndexOf("/") >= 0 ||
                        _fileName.IndexOf(":") >= 0 ||
                        _fileName.IndexOf(";") >= 0 ||
                        _fileName.IndexOf("*") >= 0 ||
                        _fileName.IndexOf("?") >= 0 ||
                        _fileName.IndexOf("\"") >= 0 ||
                        _fileName.IndexOf("<") >= 0 ||
                        _fileName.IndexOf(">") >= 0 ||
                        _fileName.IndexOf("|") >= 0 ||
                        Path.GetFileNameWithoutExtension(_fileName).IndexOf(".") >= 0)
                    {
                        errMessage = Properties.Resources.MsgStrInvalidFileName;
                        errComponent = this.tEdit_TextFileName;
                        status = false;
                        return status;
                    }
                }
            }
            catch
            {
                errMessage = Properties.Resources.MsgStrNotExistPath;
                errComponent = this.tEdit_TextFileName;
                status = false;
                return status;
            }

            // �t�@�C�����g�p�����ǂ����`�F�b�N����
            if (File.Exists(fileName) == true)
            {
                try
                {
                    Stream st = null;
                    st = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
                    if (st != null)
                    {
                        st.Close();
                        st.Dispose();
                    }
                    else
                    {
                        errMessage = Properties.Resources.MsgStrFileLocked;
                        return false;
                    }
                }
                catch
                {
                    errMessage = Properties.Resources.MsgStrFileLocked;
                    return false;
                }
            }

            // ���_�i�J�n�`�I���j
            if ((this._tEdit_SectionCode_St.DataText.TrimEnd() != string.Empty) &&
                (this._tEdit_SectionCode_Ed.DataText.TrimEnd() != string.Empty) &&
                Int32.Parse(this._tEdit_SectionCode_St.DataText.TrimEnd()) > Int32.Parse(this._tEdit_SectionCode_Ed.DataText.TrimEnd()))
            {
                errMessage = string.Format(Properties.Resources.MsgStrRangeError, Properties.Resources.LabelTxtSection);
                errComponent = this._tEdit_SectionCode_St;
                status = false;
                return status;
            }
            
            return status;
        }

        /// <summary>
        /// Copy�`�F�b�N����                                              
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@ : Copy�������ɔ������܂�</br>                  
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void WordCopyCheck()
        {
            #region Del 2013.10.28 T.MOTOYAMA
            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA DEL STA
            //int warehouseStCode = this.tNedit_ExpenseDivCd.GetInt();
            //if (warehouseStCode == 0 && this.tNedit_ExpenseDivCd.Text.Trim().Length > 0)
            //{
            //    this.tNedit_ExpenseDivCd.Text = String.Empty;
            //}
            // 2013.10.28 T.MOTOYAMA DEL END ///////////////////////////////////////////////////////////////////
            #endregion

            Regex r = new Regex(@"^\d+(\.)?\d*$");
            if (!String.IsNullOrEmpty(this._tEdit_SectionCode_St.DataText.TrimEnd()) && !r.IsMatch(this._tEdit_SectionCode_St.DataText))
            {
                this._tEdit_SectionCode_St.Text = String.Empty;
            }
            if (!String.IsNullOrEmpty(this._tEdit_SectionCode_Ed.DataText.TrimEnd()) && !r.IsMatch(this._tEdit_SectionCode_Ed.DataText))
            {
                this._tEdit_SectionCode_Ed.Text = String.Empty;
            }

            ///////////////////////////////////////////////////////////////////// 2013.10.28 T.MOTOYAMA ADD STR //
            if (!String.IsNullOrEmpty(this._tEdit_SectionCode_St.Text.Trim()))
            {
                // ���_�R�[�h(�J�n)
                this._tEdit_SectionCode_St.Text = this._tEdit_SectionCode_St.Text.PadLeft(2, '0');
                // ���_����(�J�n)
                this.SectionCodeNm_tEdit_St.Text = GetSectionName(this._tEdit_SectionCode_St.Text);
            }
            else
            {
                // ���_����(�J�n)
                this.SectionCodeNm_tEdit_St.Text = String.Empty;
            }

            if (!String.IsNullOrEmpty(this._tEdit_SectionCode_Ed.Text.Trim()))
            {
                // ���_�R�[�h(�I��)
                this._tEdit_SectionCode_Ed.Text = this._tEdit_SectionCode_Ed.Text.PadLeft(2, '0');
                // ���_����(�I��)
                this.SectionCodeNm_tEdit_Ed.Text = GetSectionName(this._tEdit_SectionCode_Ed.Text);
            }
            else
            {
                // ���_����(�I��)
                this.SectionCodeNm_tEdit_Ed.Text = String.Empty;
            }
            // 2013.10.28 T.MOTOYAMA ADD END /////////////////////////////////////////////////////////////////////                        
        }
        #endregion

        #region �� �{�^���A�C�R���ݒ菈��
        /// <summary>
        /// �{�^���A�C�R���ݒ菈��
        /// </summary>
        /// <param name="settingControl">�A�C�R���Z�b�g����R���g���[��</param>
        /// <param name="iconIndex">�A�C�R���C���f�b�N�X</param>
        /// <remarks>
        /// <br>Note		: �{�^���A�C�R���ݒ菈�����s���B</br>
        /// <br>Programmer : FSI���� �f��</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void SetIconImage(object settingControl, Size16_Index iconIndex)
        {
            ((UltraButton)settingControl).ImageList = IconResourceManagement.ImageList16;
            ((UltraButton)settingControl).Appearance.Image = iconIndex;
        }
        #endregion //�� �{�^���A�C�R���ݒ菈��
        #endregion�@//�� Private Method
    }
}