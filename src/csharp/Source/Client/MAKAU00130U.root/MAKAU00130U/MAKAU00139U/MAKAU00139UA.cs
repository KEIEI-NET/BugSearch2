//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F�d�������X�V
// �v���O�����T�v   �F�d�������X�V���s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E �K�j
// �C����    2008/08/21     �C�����e�FPartsman�p�ɕύX
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/08     �C�����e�FMantis�y11604�z�S���_�w��Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  10700008-00    �쐬�S���Fliyp
// �C����    2011/04/11     �C�����e�F�����X�V�Ƀ^�C�}�[�����āA�����J�n���Ԃ��w��\�Ƃ���
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���Fzhujc
// �C����    2011/05/10     �C�����e�FRedmine#20853�ARedmine#20844�ARedmine#20840
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���Fzhujc
// �C����    2011/06/03     �C�����e�FRedmine#21960
// ---------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
    /// �����X�V����(�d��)�t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �����X�V����(�d��)���s���t�H�[���N���X�ł��B</br>
	/// <br>Programer  : 19077 �n糋M�T</br>
	/// <br>Date       : 2007.04.03</br>
    /// <br>Update Note: 2008/08/21 30414 �E �K�j Partsman�p�ɕύX</br>
    /// <br>UpdateNote   : 2011/04/11 liyp �����X�V�Ƀ^�C�}�[�����āA�����J�n���Ԃ��w��\�Ƃ���</br>
    /// <br>UpdateNote   : 2011/05/10 zhujc Redmine#20853�ARedmine#20844</br>
	/// </remarks>
	public partial class MAKAU00139UA : Form
    {
        // --- ADD 2008/08/21 --------------------------------------------------------------------->>>>>

        // -------------------------------------------------
        // Constants
        // -------------------------------------------------
        #region Constants

        private const string ctPGID = "MAKAU00139U";

        private const string SECTION_CODE_COMMON = "00";    // ADD 2009/04/08

        #endregion Constants


        // -------------------------------------------------
        // Private Members
        // -------------------------------------------------
        #region Private Members

        private string _enterpriseCode;         // ��ƃR�[�h
        private string _prevSectionCode;        // ���_�R�[�h(�O��l)
        private DateTime _prevTotalDay;         // �O�񌎎�������
        private DateTime _currentTotalDay;      // ���񌎎�������
        private int _convertProcessDivCd;       // �R���o�[�g�����敪
        private bool _processWaitFlg;           // ���������ҋ@��� True:�ҋ@ False:���~�ҋ@ //ADD 2011/04/11
        private int counter = 0;                //ADD 2011/04/11

        private SecInfoSetAcs _secInfoSetAcs;
        private CustDmdPrcAcs _custDmdPrcAcs;

        #endregion Private Members


        // -------------------------------------------------
        // Constructor
        // -------------------------------------------------
        #region Constructor
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public MAKAU00139UA()
        {
            InitializeComponent();

            if (LoginInfoAcquisition.EnterpriseCode != null)
            {
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }

            this._secInfoSetAcs = new SecInfoSetAcs();
            this._custDmdPrcAcs = new CustDmdPrcAcs();

            // �A�C�R���ݒ�
            this.uButton_SectionGuide.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            // ��ʏ�����
            ClearAllDisp();

            // ��ʏ����ݒ�
            InitializeSetting();
            // ADD 2011/04/11 ------>>>>>
            this._processWaitFlg = false;
            if (this._processWaitFlg)
            {
                this.ultraLabel_Message.Visible = true;
                this.ultraButton_StopPrepare.Visible = true;
                this.ultraButton_Prepare.Visible = false;
            }
            else
            {
                this.ultraLabel_Message.Visible = false;
                this.ultraButton_StopPrepare.Visible = false;
                this.ultraButton_Prepare.Visible = true;
            }
            // ADD 2011/04/11 ------<<<<<

            // �t�H�[�J�X�ݒ�
            SetFocus();
        }

        // -------ADD 2011/04/11 ----->>>>>
        public Boolean ProcessWaitFlg
        {
            get { return _processWaitFlg; }
            set { _processWaitFlg = value; }
        }
        // -------ADD 2011/04/11 -----<<<<<
        #endregion Constructor


        // -------------------------------------------------
        // Public Methods
        // -------------------------------------------------
        #region Public Methods
        /// <summary>
        /// �����t�H�[�J�X�ݒ菈��
        /// </summary>
        public void SetFocus()
        {
            // ���_�R�[�h�Ƀt�H�[�J�X�ݒ�
            //this.tEdit_SectionCode.Focus();           // DEL 2009/04/08
            // this.tDateEdit_CurrentTotalMonth.Focus();   // ADD 2009/04/08 // DEL 2011/04/11
            // --------------ADD 2011/04/11 ------------------>>>>>
            if (this.tDateEdit_CurrentTotalMonth.Enabled)
            {
                this.tDateEdit_CurrentTotalMonth.Focus();
            }
            else if (this.tEdit_Hour.Enabled)
            {
                this.tEdit_Hour.Focus();
            }
            // --------------ADD 2011/04/11 ------------------<<<<<
        }

        /// <summary>
        /// ��ʏ���������
        /// </summary>
        public void DispClear()
        {
            // ��ʏ�����
            ClearAllDisp();
        }

        /// <summary>
        /// ���̓`�F�b�N
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <br>UpdateNote   : 2011/05/10 zhujc Redmine#20844</br>
        public int CheckInput()
        {
            string errMsg = "";

            try
            {
                // DEL 2009/004/08 ------>>>
                //if (this.tEdit_SectionCode.DataText.Trim() == "")
                //{
                //    errMsg = "���_�R�[�h����͂��Ă��������B";
                //    this.tEdit_SectionCode.Focus();
                //    return (-1);
                //}

                //string sectionCode = this.tEdit_SectionCode.DataText.Trim();
                //if (this._custDmdPrcAcs.GetSectionName(sectionCode) == "")
                //{
                //    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                //    this.tEdit_SectionCode.Focus();
                //    return (-1);
                //}
                // DEL 2009/004/08 ------<<<
                
                if ((this.tDateEdit_CurrentTotalMonth.GetDateYear() == 0) ||
                    // DEL 2011/05/10 ------>>>>>
                    //(this.tDateEdit_CurrentTotalMonth.GetDateMonth() == 0))
                    // DEL 2011/05/10 ------<<<<<
                    // ADD 2011/05/10 ------>>>>>
                    (this.tDateEdit_CurrentTotalMonth.GetDateMonth() == 0) ||
                    (this.tDateEdit_CurrentTotalMonth.GetDateYear() < 1900))
                    // ADD 2011/05/10 ------<<<<<
                {
                    errMsg = "���񌎎�����������͂��Ă��������B";
                    this.tDateEdit_CurrentTotalMonth.Focus();
                    return (-1);
                }
                if (this.tDateEdit_CurrentTotalMonth.GetDateMonth() > 12)
                {
                    errMsg = "���񌎎����������s���ł��B";
                    this.tDateEdit_CurrentTotalMonth.Focus();
                    return (-1);
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(this, 							// �e�E�B���h�E�t�H�[��
                                  emErrorLevel.ERR_LEVEL_INFO, 		// �G���[���x��
                                  ctPGID, 						    // �A�Z���u���h�c�܂��̓N���X�h�c
                                  errMsg, 	                        // �\�����郁�b�Z�[�W
                                  0, 								// �X�e�[�^�X�l
                                  MessageBoxButtons.OK);			// �\������{�^��
                }
            }

            return (0);
        }

        /// <summary>
        /// �����X�V����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <br>UpdateNote   : 2011/04/11 liyp �����X�V�Ƀ^�C�}�[�����āA�����J�n���Ԃ��w��\�Ƃ���</br>
        /// <br>UpdateNote   : 2011/05/10 zhujc Redmine#20853</br>
        public int ExecuteSaveProc()
        {
            // --------------ADD 2011/04/11 ----------->>>>>
            if (!this._processWaitFlg)
            {
                // --------------ADD 2011/04/11 -----------<<<<<
                DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                                ctPGID,
                                                "�X�V���Ă���낵���ł����H",
                                                0,
                                                MessageBoxButtons.YesNo);
                if (dr == DialogResult.No)
                {
                    return (0);
                }
            } //ADD 2011/04/11
            // ADD 2011/05/10 ------>>>>>
            // ���������X�V���鎞�A�����J�n���Ԃ��N���A����
            else
            {
                this.tEdit_Hour.Text = string.Empty;
                this.tEdit_Minute.Text = string.Empty;
            }
            // ADD 2011/05/10 ------<<<<<

            string errMsg;

            // ���̓`�F�b�N
            int status = CheckInput();
            if (status != 0)
            {
                return (-1);
            }

            // ���_�R�[�h
            //string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');  // DEL 2009/04/08
            string sectionCode = SECTION_CODE_COMMON;                                       // ADD 2009/04/08
            // �v��N��
            DateTime cAddUpUpdDate = new DateTime(this.tDateEdit_CurrentTotalMonth.GetDateYear(),
                                                  this.tDateEdit_CurrentTotalMonth.GetDateMonth(),
                                                  1);

            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "�X�V��";
            msgForm.Message = "�d�������X�V�������ł��B" + "\n" + "���΂炭���҂����������B";

            try
            {
                msgForm.Show();

                status = this._custDmdPrcAcs.RegistDmdData(this._enterpriseCode,
                                                               sectionCode,
                                                               cAddUpUpdDate,
                                                               this.tDateEdit_PrevTotalMonth.GetDateTime(),
                                                               cAddUpUpdDate,
                                                               1,
                                                               out errMsg);
            }
            finally
            {
                msgForm.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    ExclusiveTransaction(status);
                    return (status);
                // ��ƃ��b�N�^�C���A�E�g
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "�X�V�Ɏ��s���܂����B" + "\r\n"
                                    + "\r\n" +
                                    "�V�F�A�`�F�b�N�G���[�i��ƃ��b�N�j�ł��B" + "\r\n" +
                                    "�����������A���̑��̋Ɩ����s���Ă��邽�ߖ{�����͍s���܂���B" + "\r\n" +
                                    "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                    status,
                                    MessageBoxButtons.OK);
                        return (status);
                    }
                // ���_���b�N�^�C���A�E�g
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "�X�V�Ɏ��s���܂����B" + "\r\n"
                                    + "\r\n" +
                                    "�V�F�A�`�F�b�N�G���[�i���_���b�N�j�ł��B" + "\r\n" +
                                    "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n" +
                                    "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                    status,
                                    MessageBoxButtons.OK);
                        return (status);
                    }
                // �q�Ƀ��b�N�^�C���A�E�g
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "�X�V�Ɏ��s���܂����B" + "\r\n"
                                    + "\r\n" +
                                    "�V�F�A�`�F�b�N�G���[�i�q�Ƀ��b�N�j�ł��B" + "\r\n" +
                                    "�I���������A���̑��̍݌ɋƖ����s���Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n" +
                                    "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                    status,
                                    MessageBoxButtons.OK);
                        return (status);
                    }
                default:
                    if ((errMsg == null) || (errMsg.Trim() == ""))
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            ctPGID,     						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "ExecuteSaveProc",				    // ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            "�X�V�Ɏ��s���܂����B",				// �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._custDmdPrcAcs,				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                    }
                    else
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                            ctPGID,     						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "ExecuteSaveProc",				    // ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            errMsg,				                // �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._custDmdPrcAcs,				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                    }
                    
                    return (status);
            }

            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                          ctPGID,
                          "�����X�V�͊������܂����B",
                          0,
                          MessageBoxButtons.OK);

            //// ��ʏ�����
            //ClearAllDisp();

            // �����������ݒ�
            SetHisTotalDayMonthlyAccRec(sectionCode);
            // --------ADD 2011/04/11 ----------->>>>>
            this.tEdit_Hour.DataText = string.Empty;
            this.tEdit_Minute.DataText = string.Empty;
            // --------ADD 2011/04/11 -----------<<<<<

            // �t�H�[�J�X�ݒ�
            SetFocus();

            return (status);
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        public int ExecuteDelProc()
        {
            DialogResult result = TMsgDisp.Show(
                                        this, 								                    // �e�E�B���h�E�t�H�[��
                                        emErrorLevel.ERR_LEVEL_QUESTION, 		                // �G���[���x��
                                        ctPGID, 						                        // �A�Z���u���h�c�܂��̓N���X�h�c
                                        "�O�񌎎��������ɊY�����������\n������������܂��B", // �\�����郁�b�Z�[�W
                                        0, 									                    // �X�e�[�^�X�l
                                        MessageBoxButtons.YesNo);				                // �\������{�^��

            if (result == DialogResult.No)
            {
                return (-1);
            }

            if (this._convertProcessDivCd == 1)
            {
                result = TMsgDisp.Show(
                                this, 								            // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                ctPGID, 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                "�R���o�[�g�ȑO�̒�����͎��s�ł��܂���B",     // �\�����郁�b�Z�[�W
                                0, 									            // �X�e�[�^�X�l
                                MessageBoxButtons.OK);				            // �\������{�^��
                return (-1);
            }

            // ���̓`�F�b�N
            int status = CheckInput();
            if (status != 0)
            {
                return (-1);
            }

            string errMsg;

            // ���_�R�[�h
            //string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');  // DEL 2009/04/08
            string sectionCode = SECTION_CODE_COMMON;                                       // ADD 2009/04/08
            // �v��N��
            DateTime cAddUpUpdDate = new DateTime(this.tDateEdit_CurrentTotalMonth.GetDateYear(),
                                                  this.tDateEdit_CurrentTotalMonth.GetDateMonth(),
                                                  1);

            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "�����";
            msgForm.Message = "�d�������X�V������ł��B" + "\n" + "���΂炭���҂����������B";

            try
            {
                msgForm.Show();

                status = this._custDmdPrcAcs.BanishDmdData(this._enterpriseCode,
                                                           sectionCode,
                                                           cAddUpUpdDate,
                                                           this.tDateEdit_PrevTotalMonth.GetDateTime(),
                                                           cAddUpUpdDate,
                                                           1,
                                                           out errMsg);
            }
            finally
            {
                msgForm.Close();
            }

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                  ctPGID,
                                  "�������܂����B",
                                  0,
                                  MessageBoxButtons.OK);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                  ctPGID,
                                  errMsg,
                                  0,
                                  MessageBoxButtons.OK);
                    return (status);
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    ExclusiveTransaction(status);
                    return (status);
                // ��ƃ��b�N�^�C���A�E�g
                case (int)ConstantManagement.DB_Status.ctDB_ENT_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "�����Ɏ��s���܂����B" + "\r\n"
                                    + "\r\n" +
                                    "�V�F�A�`�F�b�N�G���[�i��ƃ��b�N�j�ł��B" + "\r\n" +
                                    "�����������A���̑��̋Ɩ����s���Ă��邽�ߖ{�����͍s���܂���B" + "\r\n" +
                                    "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                    status,
                                    MessageBoxButtons.OK);
                        return (status);
                    }
                // ���_���b�N�^�C���A�E�g
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "�����Ɏ��s���܂����B" + "\r\n"
                                    + "\r\n" +
                                    "�V�F�A�`�F�b�N�G���[�i���_���b�N�j�ł��B" + "\r\n" +
                                    "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n" +
                                    "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                    status,
                                    MessageBoxButtons.OK);
                        return (status);
                    }
                // �q�Ƀ��b�N�^�C���A�E�g
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(this,
                                    emErrorLevel.ERR_LEVEL_STOPDISP,
                                    this.Name,
                                    "�����Ɏ��s���܂����B" + "\r\n"
                                    + "\r\n" +
                                    "�V�F�A�`�F�b�N�G���[�i�q�Ƀ��b�N�j�ł��B" + "\r\n" +
                                    "�I���������A���̑��̍݌ɋƖ����s���Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n" +
                                    "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                                    status,
                                    MessageBoxButtons.OK);
                        return (status);
                    }
                default:
                    if ((errMsg == null) || (errMsg.Trim() == ""))
                    {
                        TMsgDisp.Show(this,								// �e�E�B���h�E�t�H�[��
                                      emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                                      ctPGID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                                      this.Text,						// �v���O��������
                                      "ExecuteDelProc",				    // ��������
                                      TMsgDisp.OPE_DELETE,				// �I�y���[�V����
                                      "�����Ɏ��s���܂����B",			// �\�����郁�b�Z�[�W 
                                      status,							// �X�e�[�^�X�l
                                      this._custDmdPrcAcs,				// �G���[�����������I�u�W�F�N�g
                                      MessageBoxButtons.OK,				// �\������{�^��
                                      MessageBoxDefaultButton.Button1);	// �����\���{�^��
                    }
                    else
                    {
                        TMsgDisp.Show(this,								    // �e�E�B���h�E�t�H�[��
                                      emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                                      ctPGID,						        // �A�Z���u���h�c�܂��̓N���X�h�c
                                      this.Text,						    // �v���O��������
                                      "ExecuteDelProc",				        // ��������
                                      TMsgDisp.OPE_DELETE,				    // �I�y���[�V����
                                      errMsg,			                    // �\�����郁�b�Z�[�W 
                                      status,							    // �X�e�[�^�X�l
                                      this._custDmdPrcAcs,				    // �G���[�����������I�u�W�F�N�g
                                      MessageBoxButtons.OK,				    // �\������{�^��
                                      MessageBoxDefaultButton.Button1);	    // �����\���{�^��
                    }

                    return (status);
            }

            //// ��ʏ�����
            //ClearAllDisp();

            // �����������ݒ�
            SetHisTotalDayMonthlyAccRec(sectionCode);

            // --------ADD 2011/04/11 ----------->>>>>
            this.tEdit_Hour.DataText = string.Empty;
            this.tEdit_Minute.DataText = string.Empty;
            // --------ADD 2011/04/11 -----------<<<<<

            // �t�H�[�J�X�ݒ�
            SetFocus();

            return (status);
        }
        #endregion Public Methods


        // -------------------------------------------------
        // Private Methods
        // -------------------------------------------------
        #region Private Methods
        /// <summary>
        /// ��ʏ���������
        /// </summary>
        private void ClearAllDisp()
        {
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();
            this.tDateEdit_PrevTotalMonth.SetDateTime(DateTime.MinValue);
            this.tDateEdit_CurrentTotalMonth.SetDateTime(DateTime.MinValue);

            this.tDateEdit_CurrentTotalMonth.Enabled = false;

            this._prevSectionCode = "";
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/08/21</br>
        /// </remarks>
        private void InitializeSetting()
        {
            // �R���g���[���T�C�Y�ݒ�
            this.tEdit_SectionCode.Size = new Size(36, 24);
            this.tEdit_SectionName.Size = new Size(179, 24);

            // DEL 2009/04/08 ------>>>
            //// ���_�R�[�h
            //this.tEdit_SectionCode.DataText = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            //this._prevSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            //// ���_����
            //this.tEdit_SectionName.DataText = this._custDmdPrcAcs.GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
            //// �����������ݒ�
            //SetHisTotalDayMonthlyAccRec(LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
            // DEL 2009/04/08 ------<<<

            // ADD 2009/04/08 ------>>>
            // ���_�R�[�h
            this.tEdit_SectionCode.DataText = SECTION_CODE_COMMON;
            this._prevSectionCode = SECTION_CODE_COMMON;
            // �����������ݒ�
            SetHisTotalDayMonthlyAccRec(SECTION_CODE_COMMON);
            // ADD 2009/04/08 ------<<<
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/08/21</br>
        /// </remarks>
        private void ExclusiveTransaction(int status)
        {
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    {
                        // ���[���X�V
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            ctPGID,      						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,				            // �v���O��������
                            "ExclusiveTransaction", 			// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "���ɑ��[�����X�V����Ă��܂��B", // �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._custDmdPrcAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
                case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    {
                        // ���[���폜
                        TMsgDisp.Show(
                            this, 								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_EXCLAMATION, // �G���[���x��
                            ctPGID,     						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,				            // �v���O��������
                            "ExclusiveTransaction", 			// ��������
                            TMsgDisp.OPE_HIDE, 					// �I�y���[�V����
                            "���ɑ��[�����폜����Ă��܂��B", // �\�����郁�b�Z�[�W
                            status, 							// �X�e�[�^�X�l
                            this._custDmdPrcAcs, 				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK, 				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                        break;
                    }
            }
        }

        /// <summary>
        /// ���񌎎��������ݒ菈��
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <remarks>
        /// <br>Note       : ���񌎎���������ݒ肵�܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/08/21</br>
        /// </remarks>
        private void SetHisTotalDayMonthlyAccRec(string sectionCode)
        {
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;

            int status = this._custDmdPrcAcs.GetHisTotalDayMonthlyAccRecPay(sectionCode,
                                                                            1,
                                                                            out prevTotalDay,
                                                                            out currentTotalDay,
                                                                            out prevTotalMonth,
                                                                            out currentTotalMonth,
                                                                            out this._convertProcessDivCd);
            if (status == 0)
            {
                // ���񌎎��������ݒ�
                this.tDateEdit_CurrentTotalMonth.SetDateTime(currentTotalMonth);
                // �O�񌎎��������ݒ�
                this.tDateEdit_PrevTotalMonth.SetDateTime(prevTotalMonth);

                if (prevTotalDay == DateTime.MinValue)
                {
                    this.tDateEdit_CurrentTotalMonth.Enabled = true;
                }
                else
                {
                    this.tDateEdit_CurrentTotalMonth.Enabled = false;
                }

                // ���񌎎��������ݒ�
                this._currentTotalDay = currentTotalDay;
                // �O�񌎎��������ݒ�
                this._prevTotalDay = prevTotalDay;
            }
            else
            {
                // ���񌎎��������ݒ�
                this.tDateEdit_CurrentTotalMonth.SetDateTime(new DateTime());
                // �O�񌎎��������ݒ�
                this.tDateEdit_PrevTotalMonth.SetDateTime(new DateTime());

                this.tDateEdit_CurrentTotalMonth.Enabled = true;

                // ���񌎎��������ݒ�
                this._currentTotalDay = new DateTime();
                // �O�񌎎��������ݒ�
                this._prevTotalDay = new DateTime();
            }
        }
        #endregion Private Methods

        
        // -------------------------------------------------
        // Control Events
        // -------------------------------------------------
        #region Control Events
        /// <summary>
        /// Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        private void uButton_SectionGuide_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                SecInfoSet secInfoSet;

                int status = this._secInfoSetAcs.ExecuteGuid(this._enterpriseCode, false, out secInfoSet);
                if (status == 0)
                {
                    if (secInfoSet.SectionCode.Trim() == this._prevSectionCode.Trim())
                    {
                        return;
                    }

                    // ���_�R�[�h�擾
                    this.tEdit_SectionCode.DataText = secInfoSet.SectionCode.Trim();
                    // ���_���̎擾
                    this.tEdit_SectionName.DataText = secInfoSet.SectionGuideNm.Trim();

                    // �o�b�t�@�ɑO��l��ۑ�
                    this._prevSectionCode = secInfoSet.SectionCode.Trim();

                    // �����������ݒ�
                    SetHisTotalDayMonthlyAccRec(secInfoSet.SectionCode.Trim());

                    // �t�H�[�J�X�ݒ�
                    this.tDateEdit_CurrentTotalMonth.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            // ���_�R�[�h�擾
            // 2009.02.20 30413 ���� ��r�ŕs��v�ɂȂ�̂�0�l�� >>>>>>START
            //string sectionCode = this.tEdit_SectionCode.DataText.Trim();
            string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
            // 2009.02.20 30413 ���� ��r�ŕs��v�ɂȂ�̂�0�l�� <<<<<<END
            
            if (sectionCode != this._prevSectionCode)
            {
                // �o�b�t�@�ɑO��l��ۑ�
                this._prevSectionCode = sectionCode;

                // ���_���̎擾
                this.tEdit_SectionName.DataText = this._custDmdPrcAcs.GetSectionName(sectionCode);

                // �����������ݒ�
                SetHisTotalDayMonthlyAccRec(sectionCode);
            }

            if (e.ShiftKey == false)
            {
                if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                {
                    if (this.tEdit_SectionName.DataText.Trim() != "")
                    {
                        if (this.tDateEdit_CurrentTotalMonth.Enabled == true)
                        {
                            e.NextCtrl = this.tDateEdit_CurrentTotalMonth;
                        }
                    }
                }
            }
        }

        // --------------ADD 2011/04/11 ---------------->>>>>
        /// <summary>
        /// Tick �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���b�Z�[�W��_�ł�����B</br>
        /// <br>Programer  : liyp</br>
        /// <br>Date       : 2011/04/11</br>
        /// <br>UpdateNote : 2011/05/10 zhujc Redmine#20853</br>
        /// <br>UpdateNote : 2011/06/03 zhujc Redmine#21960</br>
        /// </remarks>
        private void timer_ShowOrNot_Tick(object sender, EventArgs e)
        {
            counter = counter + 1;
            if (Int32.Parse(this.tEdit_Hour.DataText.Trim()) == System.DateTime.Now.Hour && Int32.Parse(this.tEdit_Minute.DataText.Trim()) == System.DateTime.Now.Minute)
            {
                this.timer_ShowOrNot.Stop();
                this.ultraLabel_Message.Visible = false;
                this.tEdit_Hour.Enabled = true;
                // ���������A��ʂ̐���̐ݒ�

                // DEL 2011/05/10 ------>>>>>
                //this.tEdit_Hour.Text = string.Empty;
                // DEL 2011/05/10 ------<<<<<

                this.tEdit_Minute.Enabled = true;

                // DEL 2011/05/10 ------>>>>>
                //this.tEdit_Minute.Text = string.Empty;
                // DEL 2011/05/10 ------<<<<<

                this.ultraButton_Prepare.Visible = true;

                // ADD 2011/05/10 ------>>>>>
                this.ultraButton_Prepare.Focus();
                // ADD 2011/05/10 ------<<<<<

                this.ultraButton_StopPrepare.Visible = false;

                // DEL 2011/05/10 ------>>>>>
                //this.tDateEdit_CurrentTotalMonth.Enabled = true;
                // DEL 2011/05/10 ------<<<<<

                //ExecuteSaveProc();//�����X�V���s�� //DEL 2011/06/03
                // ADD 2011/06/03  ----------------------------->>>>>>
                if (0 != ExecuteSaveProc())
                {
                    this.tEdit_Hour.Focus();
                    if(DateTime.MinValue == this.tDateEdit_PrevTotalMonth.GetDateTime())
                    {
                        this.tDateEdit_CurrentTotalMonth.Enabled = true;
                    }
                }
                // ADD 2011/06/03  -----------------------------<<<<<<
                this._processWaitFlg = false; //���������ҋ@��Ԃ�������
                ParentToolbarSettingEvent(this);
                return;
            }
            if (counter % 4 == 0)
            {
                this.ultraLabel_Message.Visible = false;
            }
            else
            {
                this.ultraLabel_Message.Visible = true;
            }
        }

        /// <summary>
        /// Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : �����ҋ@�������s���܂��B</br>
        /// <br>Programer  : liyp</br>
        /// <br>Date       : 2011/04/11</br>
        /// </remarks>
        private void ultraButton_Prepare_Click(object sender, EventArgs e)
        {
            DialogResult result;
            // ���̓`�F�b�N
            int status = CheckInput();
            if (status != 0)
            {
                return;
            }
            if (checkStartTime(this.tEdit_Hour.Text, this.tEdit_Minute.Text))
            {
                if ((Int32.Parse(this.tEdit_Hour.Text) > System.DateTime.Now.Hour) || (Int32.Parse(this.tEdit_Hour.Text) == System.DateTime.Now.Hour && Int32.Parse(this.tEdit_Minute.Text) >= System.DateTime.Now.Minute))
                {
                    result = TMsgDisp.Show(
                                     this, 								            // �e�E�B���h�E�t�H�[��
                                     emErrorLevel.ERR_LEVEL_QUESTION, 		    // �G���[���x��
                                     ctPGID, 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                     "�ҋ@�������J�n���Ă�낵���ł����H",     // �\�����郁�b�Z�[�W
                                     0, 									            // �X�e�[�^�X�l
                                     MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);				            // �\������{�^��
                }
                else
                {
                    result = TMsgDisp.Show(
                                         this, 								            // �e�E�B���h�E�t�H�[��
                                         emErrorLevel.ERR_LEVEL_QUESTION, 		    // �G���[���x��
                                         ctPGID, 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                         "�ҋ@�������J�n���Ă�낵���ł����H" + "\r\n"
                                          + "(�����J�n���Ԃ͗����ł�)",     // �\�����郁�b�Z�[�W
                                         0, 									            // �X�e�[�^�X�l
                                         MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);				            // �\������{�^��
                }

                if (result == DialogResult.Yes)
                {
                    this._processWaitFlg = true;
                    ParentToolbarSettingEvent(this);
                    this.ultraButton_Prepare.Visible = false;
                    this.ultraButton_StopPrepare.Visible = true;
                    this.ultraLabel_Message.Visible = true;
                    this.tEdit_Hour.Enabled = false;
                    this.tEdit_Minute.Enabled = false;
                    this.tDateEdit_CurrentTotalMonth.Enabled = false;
                    this.timer_ShowOrNot.Start();
                }

            }
        }

        /// <summary>
        /// Click �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���������ҋ@��Ԃ̉������s���܂��B</br>
        /// <br>Programer  : liyp</br>
        /// <br>Date       : 2011/04/11</br>
        /// </remarks>
        private void ultraButton_StopPrepare_Click(object sender, EventArgs e)
        {
            DateTime prevTotalDay;
            DateTime currentTotalDay;
            DateTime prevTotalMonth;
            DateTime currentTotalMonth;
            DialogResult result = TMsgDisp.Show(
                                 this, 								            // �e�E�B���h�E�t�H�[��
                                 emErrorLevel.ERR_LEVEL_QUESTION, 		    // �G���[���x��
                                 ctPGID, 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                 "�ҋ@�����𒆎~���Ă�낵���ł����H",     // �\�����郁�b�Z�[�W
                                 0, 									            // �X�e�[�^�X�l
                                 MessageBoxButtons.YesNo, MessageBoxDefaultButton.Button1);				            // �\������{�^��
            if (result == DialogResult.Yes)
            {
                this._processWaitFlg = false; //���������ҋ@��Ԃ�������
                ParentToolbarSettingEvent(this);
                this.tEdit_Hour.Enabled = true;
                this.tEdit_Minute.Enabled = true;
                this.ultraButton_Prepare.Visible = true;
                this.ultraButton_StopPrepare.Visible = false;
                this.ultraLabel_Message.Visible = false;
                int status = this._custDmdPrcAcs.GetHisTotalDayMonthlyAccRecPay(SECTION_CODE_COMMON,
                                                                            1,
                                                                            out prevTotalDay,
                                                                            out currentTotalDay,
                                                                            out prevTotalMonth,
                                                                            out currentTotalMonth,
                                                                            out this._convertProcessDivCd);
                if (status == 0)
                {
                    if (prevTotalDay == DateTime.MinValue)
                    {
                        this.tDateEdit_CurrentTotalMonth.Enabled = true;
                    }
                    else
                    {
                        this.tDateEdit_CurrentTotalMonth.Enabled = false;
                    }
                }
                else
                {
                    // ���񌎎��������ݒ�
                    this.tDateEdit_CurrentTotalMonth.SetDateTime(new DateTime());
                    this.tDateEdit_CurrentTotalMonth.Enabled = true;
                }
                this.timer_ShowOrNot.Stop();
            }
        }

        /// <summary>
        /// Leave  �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���Ԃ͂Q�����s�����ɔ������܂��B</br>
        /// <br>Programer   : liyp</br>
        /// <br>Date	    : 2011/04/11</br>
        /// </remarks>
        private void tEdit_Hour_Leave(object sender, EventArgs e)
        {
            this.tEdit_Hour.DataText = this.tEdit_Hour.DataText.Trim();
            if (this.tEdit_Hour.DataText.Length < 2 && this.tEdit_Hour.DataText.Length > 0)
            {
                this.tEdit_Hour.DataText = this.tEdit_Hour.DataText.PadLeft(2, '0');
            }
        }

        /// <summary>
        /// Leave  �C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note		: ���Ԃ͂Q�����s�����ɔ������܂��B</br>
        /// <br>Programer   : liyp</br>
        /// <br>Date	    : 2011/04/11</br>
        /// </remarks>
        private void tEdit_Minute_Leave(object sender, EventArgs e)
        {
            this.tEdit_Minute.DataText = this.tEdit_Minute.DataText.Trim();
            if (this.tEdit_Minute.DataText.Length < 2 && this.tEdit_Minute.DataText.Length > 0)
            {
                this.tEdit_Minute.DataText = this.tEdit_Minute.DataText.PadLeft(2, '0');
            }
        }

        // --------------ADD 2011/04/11 ----------------<<<<<

        #endregion Control Events
        // --- ADD 2008/08/21 ---------------------------------------------------------------------<<<<<

        // --- ADD 2011/04/11 ----------------->>>>>
        /// <summary>
        /// ���̓`�F�b�N
        /// </summary>
        /// <br>Programer   : liyp</br>
        /// <br>Date	    : 2011/04/11</br>
        /// <returns>�X�e�[�^�X</returns>
        private bool checkStartTime(string hour, string minute)
        {
            bool checkFlg = true;
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^\\d{2}$");
            if (!string.IsNullOrEmpty(hour) && !string.IsNullOrEmpty(minute))
            {
                if (!regex.IsMatch(hour) || !regex.IsMatch(minute))
                {
                    TMsgDisp.Show(
                                   this, 								            // �e�E�B���h�E�t�H�[��
                                   emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                   ctPGID, 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                   "�����J�n���Ԃ̐ݒ肪�s���ł��B",     // �\�����郁�b�Z�[�W
                                   0, 									            // �X�e�[�^�X�l
                                   MessageBoxButtons.OK);				            // �\������{�^��
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }

                if (Int32.Parse(hour) < 0 || Int32.Parse(hour) > 23)
                {
                    TMsgDisp.Show(
                                this, 								            // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                ctPGID, 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                "�����J�n���Ԃ̐ݒ肪�s���ł��B",     // �\�����郁�b�Z�[�W
                                0, 									            // �X�e�[�^�X�l
                                MessageBoxButtons.OK);				            // �\������{�^��
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }
                if (Int32.Parse(minute) < 0 || Int32.Parse(minute) > 59)
                {
                    TMsgDisp.Show(
                                this, 								            // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                ctPGID, 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                "�����J�n���Ԃ̐ݒ肪�s���ł��B",     // �\�����郁�b�Z�[�W
                                0, 									            // �X�e�[�^�X�l
                                MessageBoxButtons.OK);				            // �\������{�^��
                    this.tEdit_Minute.Focus();
                    checkFlg = false;
                    return checkFlg;
                }
                if (Int32.Parse(hour) <= 5 || Int32.Parse(hour) >= 23 || (Int32.Parse(hour) == 6 && Int32.Parse(minute) == 0))
                {
                    TMsgDisp.Show(
                                 this, 								            // �e�E�B���h�E�t�H�[��
                                 emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                 ctPGID, 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                 "23��00���`06��00���̓����e�i���X���Ԃׁ̈A�ݒ�o���܂���B",     // �\�����郁�b�Z�[�W
                                 0, 									            // �X�e�[�^�X�l
                                 MessageBoxButtons.OK);				            // �\������{�^��
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }
            }
            else if (string.IsNullOrEmpty(hour) && !string.IsNullOrEmpty(minute))
            {
                TMsgDisp.Show(
                                    this, 								            // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                    ctPGID, 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                    "�����J�n���Ԃ̐ݒ肪�s���ł��B",     // �\�����郁�b�Z�[�W
                                    0, 									            // �X�e�[�^�X�l
                                    MessageBoxButtons.OK);				            // �\������{�^��
                this.tEdit_Hour.Focus();
                checkFlg = false;
                return checkFlg;
            }
            else if (!string.IsNullOrEmpty(hour) && string.IsNullOrEmpty(minute))
            {
                if (!regex.IsMatch(hour))
                {
                    TMsgDisp.Show(
                                   this, 								            // �e�E�B���h�E�t�H�[��
                                   emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                   ctPGID, 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                   "�����J�n���Ԃ̐ݒ肪�s���ł��B",     // �\�����郁�b�Z�[�W
                                   0, 									            // �X�e�[�^�X�l
                                   MessageBoxButtons.OK);				            // �\������{�^��
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }

                if (Int32.Parse(hour) < 0 || Int32.Parse(hour) > 23)
                {
                    TMsgDisp.Show(
                                this, 								            // �e�E�B���h�E�t�H�[��
                                emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                ctPGID, 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                "�����J�n���Ԃ̐ݒ肪�s���ł��B",     // �\�����郁�b�Z�[�W
                                0, 									            // �X�e�[�^�X�l
                                MessageBoxButtons.OK);				            // �\������{�^��
                    this.tEdit_Hour.Focus();
                    checkFlg = false;
                    return checkFlg;
                }
                TMsgDisp.Show(
                                    this, 								            // �e�E�B���h�E�t�H�[��
                                    emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                    ctPGID, 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                    "�����J�n���Ԃ̐ݒ肪�s���ł��B",     // �\�����郁�b�Z�[�W
                                    0, 									            // �X�e�[�^�X�l
                                    MessageBoxButtons.OK);				            // �\������{�^��
                this.tEdit_Minute.Focus();
                checkFlg = false;
                return checkFlg;
            }
            else if (string.IsNullOrEmpty(hour) && string.IsNullOrEmpty(minute))
            {
                TMsgDisp.Show(
                                        this, 								            // �e�E�B���h�E�t�H�[��
                                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 		    // �G���[���x��
                                        ctPGID, 						                // �A�Z���u���h�c�܂��̓N���X�h�c
                                        "�����J�n���Ԃ���͂��Ă��������B",     // �\�����郁�b�Z�[�W
                                        0, 									            // �X�e�[�^�X�l
                                        MessageBoxButtons.OK);				            // �\������{�^��
                this.tEdit_Hour.Focus();
                checkFlg = false;
                return checkFlg;
            }

            return checkFlg;
        }

        // ===================================================================================== //
        // Internal�C�x���g
        // ===================================================================================== //
        #region Internal event
        /// <summary>
        /// �c�[���o�[�\������C�x���g
        /// </summary>
        public event ParentToolbarSettingEventHandler ParentToolbarSettingEvent;
        #endregion

        // --- ADD 2011/04/11 -----------------<<<<<

        #region DEL 2008/08/21 Partsman�p�ɕύX
        /* --- DEL 2008/08/21 --------------------------------------------------------------------->>>>>
		//==================================================================
		//  �R���X�g���N�^
		//==================================================================
		#region �R���X�g���N�^
		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public MAKAU00139UA()
		{
			InitializeComponent();                        
            
            //CustDmdPrcAcs = CustDmdPrcAcs.GetInstance();

            if (LoginInfoAcquisition.EnterpriseCode != null)
            {
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }

            this._customerInfoAcs = new CustomerInfoAcs();            

            this._companyInfAcs = new CompanyInfAcs();
            this._custDmdPrcAcs = new CustDmdPrcAcs();

            // ��ʏ�����
            AllDispClear(false);
		}
		#endregion

		//--------------------------------------------------------
		//  �v���C�x�[�g�ϐ�
		//--------------------------------------------------------
		#region �v���C�x�[�g�ϐ�

        private ArrayList _stockRet = new ArrayList();

        /// <summary>
        /// ���ԍ݌ɃA�N�Z�X�N���X
        /// </summary>
        private CompanyInfAcs _companyInfAcs;
        private CustDmdPrcAcs _custDmdPrcAcs;

		/// <summary>
		/// �`�[���ח�\���X�e�[�^�X
		/// </summary>
		private ProductStockDisplayStatus _colDispInfo = null;

        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
		private string _enterpriseCode;

		/// <summary>
		/// �C�x���g����t���O
		/// </summary>
		private bool _localEventBlockFlg = false;
        /// <summary>
		/// �Z����A�N�e�B�u���̃Z�����
		/// </summary>
//*		private UltraGridCell _tempCell = null;
		/// <summary>
		/// �Z����A�N�e�B�u���̏����l
		/// </summary>
//*		private object _tempValue = null;
		/// <summary>
		/// �Z����A�N�e�B�u�C�x���g���s�t���O
		/// </summary>
//*		private bool _beforeCellDeactivateRun = false;

        private Infragistics.Win.Misc.UltraButton _pushBtn = null;

        private int[] _customerTotalDay;

        private CustomerInfoAcs _customerInfoAcs;

        #endregion

        //--------------------------------------------------------
		//  �v���C�x�[�g�萔
		//--------------------------------------------------------
		#region �v���C�x�[�g�萔

		/// <summary>���ח�\���X�e�[�^�X�t�@�C������</summary>
		private const string ctFILE_ColDispInfo = "MAKAU00129U.DAT";
        
        /// <summary>PGID</summary>
		private const string ctPGID = "MAKAU00139U";
		#endregion

		//==================================================================
		//  �p�u���b�N�C�x���g
		//==================================================================
        public static event GetSectionEventHandler GetSection;
        public delegate string GetSectionEventHandler();

        public string _sectionCd;

        //--------------------------------------------------------
		//  �C���^�[�t�F�[�X������
		//--------------------------------------------------------
		#region �C���^�[�t�F�[�X������
		#region IStockEntryTbsCtrlChild �����o
		/// <summary>
		/// ��ʕ\�����\�b�h
		/// </summary>
		/// <param name="parameter">�p�����[�^�I�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �p�����[�^�t���ŉ�ʕ\�����s���܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.08</br>
		/// </remarks>
		public void Show(object parameter)
		{
			// �I�v�V�����ɂ��c�[���o�[�ݒ�
			this.SettingOptionTool();

			this.Show();
		}

		#endregion

		#region IStockEntryTbsCtrlChildEdit �����o
		/// <summary>
		/// StaticMemory�̏���ۑ����܂��B
		/// </summary>
		/// <param name="sender"></param>
		/// <returns></returns>
		public int SaveStaticMemoryData(object sender)
		{
			// ���͒��̃f�[�^�����肷��B
			// �G�f�B�b�g�n
			Control wkCtrl = this.ActiveControl;
			if (wkCtrl != null)
			{
				if (wkCtrl is EmbeddableTextBoxWithUIPermissions)
				{
					wkCtrl = wkCtrl.Parent;

					if ((wkCtrl is TNedit) && (wkCtrl.Parent != null) && (wkCtrl.Parent is TDateEdit))
					{
						wkCtrl = wkCtrl.Parent;
					}
				}

				this.tRetKeyControl_ChangeFocus(wkCtrl, new ChangeFocusEventArgs(false, false, false, Keys.Enter, wkCtrl, wkCtrl));
			}

			return 0;
		}

		/// <summary>
		/// �G���[���ڂ�\�����܂��B
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="ErrorItems"></param>
		/// <returns></returns>
		public int ShowErrorItems(object sender, ArrayList ErrorItems)
		{
			// ������
			return 0;
		}
		#endregion

		#region IStockEntryTbsCtrlChildEvent �����o
		/// <summary>
		/// �^�u�q��ʃA�N�e�B�u������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void EntryTabChildFormActivated(object sender, EventArgs e)
		{
			// ���ԍ݌ɃA�N�Z�X�N���X�̖��וύX�C�x���g�Ƀn���h����ǉ�
//			CustDmdPrcAcs.SlipDtlColChanged += PtSuplSlipAcs_SlipDtlColChanged;

			// ���ԍ݌ɃA�N�Z�X�N���X�̖��׃e�[�u���s�ύX�C�x���g�Ƀn���h����ǉ�
//			CustDmdPrcAcs.SlipDtlRowChanged += SlipDtlDataTable_SlipDtlRowChanged;
		}

		/// <summary>
		/// �^�u�q��ʔ�A�N�e�B�u������
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		/// <returns></returns>
		public int EntryTabChildFormDeactivate(object sender, EventArgs e)
		{
			return 0;
		}

        /// <summary>
        /// ���͓��e�`�F�b�N
        /// </summary>
        /// <returns></returns>
        public int CheckInput()
        {
            return CheckInputData();
        }

        /// <summary>
        /// ���͓��e�`�F�b�N
        /// </summary>
        /// <returns></returns>
        private int CheckInputData()
        {
            //����
            int result = 0;
            //����
            int chkInt = (int)TotalDay_tNedit.GetInt();
            if ((chkInt <= 0) || ((chkInt > 31) && (chkInt != 99)))
            {
                return 1;
            }

            // ���t�̗L����
            try
            {
                int year = tDateEdit1.GetDateYear();
                int month = tDateEdit1.GetDateMonth();
                int day = tDateEdit1.GetDateDay();
                DateTime datetime = new DateTime(year, month, day);
            }
            catch
            {
                return 2;
            }
            return result;            
        }
    
        /// <summary>
        /// ������
        /// </summary>
        public int ExecuteSaveProc()
        {
            string msg;
            int status = SaveProc(out msg);
            if (status != 0)
            {
                if (String.IsNullOrEmpty(msg))
                {
                    msg = "�X�V�Ɏ��s���܂���" + "(" + status.ToString() + ")" ;
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        msg,
                        status,
                        MessageBoxButtons.OK);
                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        msg,
                        status,
                        MessageBoxButtons.OK);
                }

            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "�X�V���܂���", 0, MessageBoxButtons.OK);
            }

            return status;
        }

        /// <summary>
        /// ����������
        /// </summary>
        private int SaveProc(out string msg)
        {
            int retTotalCnt = 0;
            
            ArrayList setCustomer = new ArrayList();
            ArrayList setTotalDay = new ArrayList();

            int totalDay = TotalDay_tNedit.GetInt();

            DateTime addUpdate = tDateEdit1.GetDateTime();
            DateTime addupYM = addUpdate;

            return _custDmdPrcAcs.RegistDmdData(out retTotalCnt, this._enterpriseCode, this._sectionCd,addUpdate,addupYM, totalDay,2,out msg);
        }

        /// <summary>
        /// ������
        /// </summary>
        public int ExecuteDelProc()
        {
            string msg;
            int status = DelProc(out msg);

            if (status != 0)
            {
                if (String.IsNullOrEmpty(msg))
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "�����Ɏ��s���܂����B", 0, MessageBoxButtons.OK);
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, msg, 0, MessageBoxButtons.OK);
                }
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "�������܂����B", 0, MessageBoxButtons.OK);
            }

            return status;
        }

        /// <summary>
        /// ������������
        /// </summary>
        private int DelProc(out string msg)
        {
            int retTotalCnt = 0;

            int totalDay = TotalDay_tNedit.GetInt();
            DateTime addUpDate = tDateEdit1.GetDateTime();
            DateTime addUpYM = addUpDate;

            return _custDmdPrcAcs.BanishDmdData(out retTotalCnt, _enterpriseCode, _sectionCd, totalDay, addUpDate, addUpYM, 2, out msg);
        }

		#endregion

		#region IStockEntryTbsCtrlChildResponse �����o
		/// <summary>
		/// �e�A�N�V�����Ή�����
		/// </summary>
		/// <param name="sender">�C�x���g�I�u�W�F�N�g</param>
		/// <param name="targetInstance">�Ή��ΏۃI�u�W�F�N�g</param>
		/// <param name="actionKey">�A�N�V�������ʃL�[</param>
		/// <param name="param">�A�N�V�����p�����[�^</param>
		/// <returns></returns>
		public int ChildResponse(object sender, object targetInstance, string actionKey, object param)
		{
			int st = 0;

			// ���̃C���X�^���X�ւ̗v�����ǂ����̔���
			if (targetInstance.Equals(this))
			{
				switch (actionKey)
				{
					//-- �o�[�R�[�h���̓C�x���g�ʒm
					case "BarcodeRead":
						// �K�C�h���\�����ł��t���[������ʒm������̂�,���̂Ƃ��̓K�C�h���̏����ɂ܂����B
//						if (this._tspBarcodeInputGuide.IsGuideShowing) return 0;

						// �X�N���[������
						break;
					//-- ����NewEntry����
					case "SpecificNewEntry":
						break;
                }
			}

			return st;
		}
		#endregion
		#endregion

		//--------------------------------------------------------
		//  �R���g���[���C�x���g�n���h��
		//--------------------------------------------------------
		#region �R���g���[���C�x���g�n���h��

		/// <summary>
		/// �`�[��ʃR���{�{�b�N�X�l�ύX�C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void cmbSlipKindDiv_ValueChanged(object sender, EventArgs e)
		{
			// �C�x���g���䔻��
			if (_localEventBlockFlg) return;


		}

		/// <summary>
		/// �c�[���o�[�h���b�v�_�E���O�C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void ToolbarsManager_Main_BeforeToolDropdown(object sender, Infragistics.Win.UltraWinToolbars.BeforeToolDropdownEventArgs e)
		{
			// �h���b�v�_�E������O�Ɋe���j���[�A�C�e���̏�Ԃ�ݒ肷��
			if ((e.Tool.Key == "PopupMenuTool_Edit") && (e.Tool is Infragistics.Win.UltraWinToolbars.PopupMenuTool))
			{
				Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenu = (Infragistics.Win.UltraWinToolbars.PopupMenuTool)e.Tool;

				// ���j���[�A�C�e���ݒ�
				Boolean dispFlg = false;

				// ���j���[��\���\���H
				e.Cancel = (!dispFlg);

				if (!e.Cancel)
				{
				}
			}
		}

		/// <summary>
		/// �c�[���o�[�N���[�Y�A�b�v��C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void ToolbarsManager_Main_AfterToolCloseup(object sender, Infragistics.Win.UltraWinToolbars.ToolDropdownEventArgs e)
		{
			if (e.Tool.Key == "PopupMenuTool_Edit")
			{
				Infragistics.Win.UltraWinToolbars.PopupMenuTool popupMenu = e.Tool as Infragistics.Win.UltraWinToolbars.PopupMenuTool;

			}
		}

		/// <summary>
		/// ���׃O���b�h�I����ԕύX��C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void SlipGrid_AfterSelectChange(object sender, AfterSelectChangeEventArgs e)
		{

		}

		/// <summary>
		/// ���͕⏕�G�N�X�v���[���o�[�A�C�e���N���b�N�C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void ExplorerBar_InputHelp_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
		{
			this.InputHelperItemExecute(e.Item.Key);
		}

		/// <summary>
		/// ��ʓ��͗��G���^�[�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void Edit_Enter(object sender, EventArgs e)
		{
		}

        /// <summary>
		/// RetKeyControll�t�H�[�J�X�ύX�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		private void tRetKeyControl_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
		}

        public void SetFocus()
        {
            tDateEdit1.Focus();            
        }

        public void DispClear()
        {
            // ��ʏ�����
            AllDispClear(false);
        }

        /// <summary>
        /// ��ʏ�����
        /// </summary>
        /// <param name="TempCheck">�`�F�b�N�L��</param>
        /// <param name="e">�C�x���g�p�����[�^</param>
        /// <remarks>
        /// <br>Note       : ��ʂ�������</br>
        /// <br>Programer  : 19077 �n糋M�T</br>
        /// <br>Date       : 2007.03.08</br>
        /// </remarks>
        private void AllDispClear(bool TempCheck)
        {
            int setInt = 10;
            _customerTotalDay = new int[setInt];
            for (int i = 0; i < setInt; i++)
            {
                _customerTotalDay[i] = 0;
            }

            TotalDay_tNedit.Text = "";

            tDateEdit1.Clear();

            //���Џ��擾            
            CompanyInf companyInf = new CompanyInf();
            _companyInfAcs.Read(out companyInf, this._enterpriseCode);
            TotalDay_tNedit.Text = companyInf.CompanyTotalDay.ToString();

            DateTime datetime = DateTime.Now;  //���ݓ��t

            if (datetime.Day > companyInf.CompanyTotalDay)�@//���ݓ��t�̓��������w�����=�O��
            {
                datetime = DateTime.Parse(datetime.ToString("yyyy/MM/01")).AddDays(-1); //
            }
            datetime = ChkDate(datetime,companyInf.CompanyTotalDay.ToString());
            tDateEdit1.SetDateTime(datetime);
        }

        private DateTime ChkDate(DateTime tgtDateTime, String tgtDay)
        {
            int year = tgtDateTime.Year;
            int month = tgtDateTime.Month;
            int day = Int32.Parse(tgtDay);

            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    {
                        break;
                    }
                case 2:
                    if (DateTime.IsLeapYear(year))
                    {
                        if (day > 29)
                        {
                            day = 29;
                        }
                    }
                    else
                    {
                        if (day > 28)
                        {
                            day = 28;
                        }
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    {
                        if (day > 30)
                        {
                            day = 30;
                        }                        
                        break;
                    }
            }

            DateTime rtnDateTime = new DateTime(year, month, day);

            return rtnDateTime;
        }

        #endregion

        //--------------------------------------------------------
        //  ��������
        //--------------------------------------------------------
        #region ��������

        /// <summary>
        /// ���͕⏕���ڎ��s����
        /// </summary>
        /// <param name="itemKey">���ڃL�[������</param>
        private void InputHelperItemExecute(string itemKey)
		{
			


		}

        /// <summary>
		/// �I�v�V�����n�c�[���o�[�ݒ�
		/// </summary>
		private void SettingOptionTool()
		{
			PurchaseStatus purchaseStatus;

			//**************************************************
			// TSP�񓚃f�[�^�捞 �I�v�V�����`�F�b�N
			//**************************************************
			// TSP�I�����C���̃I�v�V�����`�F�b�N
			purchaseStatus =
				LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
				ConstantManagement_SF_PRO.SoftwareCode_OPT_SB_TSP_ONLINE);

			if ((purchaseStatus != PurchaseStatus.Contract) &&
				(purchaseStatus != PurchaseStatus.Trial_Contract))
			{
				// ���_��̏ꍇ�́ATSP�C�����C���̃I�v�V�����`�F�b�N���s��
				purchaseStatus =
					LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
					ConstantManagement_SF_PRO.SoftwareCode_OPT_SB_TSP_INLINE);
			}

			// �_��
			if ((purchaseStatus == PurchaseStatus.Contract) ||
				(purchaseStatus == PurchaseStatus.Trial_Contract))
			{
				// �{�^���̕\��-�\��
//				this.ExplorerBar_InputHelp.Groups["InputHelper"].Items["TSPResponseDataImport"].Visible = true;
				// �c�[���o�[��TSP�񓚃f�[�^�捞�͕\��
//				this.ToolbarsManager_Main.Tools["ButtonTool_TSPResponseDataImport"].SharedProps.Visible = true;
			}
			else
			{
				// �{�^���̕\��-��\��
//				this.ExplorerBar_InputHelp.Groups["InputHelper"].Items["TSPResponseDataImport"].Visible = false;
				// �c�[���o�[��TSP�񓚃f�[�^�捞�͔�\��
//				this.ToolbarsManager_Main.Tools["ButtonTool_TSPResponseDataImport"].SharedProps.Visible = false;
			}

			//**************************************************
			// TSP�o�[�R�[�h���� �I�v�V�����`�F�b�N
			//**************************************************
			// TSP�I�t���C���̃I�v�V�����`�F�b�N
			purchaseStatus = PurchaseStatus.Uncontract;
// �Ƃ肠��������ł͔�\��
//			purchaseStatus =
//				Broadleaf.Application.Common.LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
//				Broadleaf.Application.Resources.ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BarCodeTspInput);

			// �_��
			if ((purchaseStatus == PurchaseStatus.Contract) ||
				(purchaseStatus == PurchaseStatus.Trial_Contract))
			{
				// �{�^���̕\��-��\��
//				this.ExplorerBar_InputHelp.Groups["InputHelper"].Items["TSPBarcodeInput"].Visible = true;
				// �c�[���o�[��TSP�񓚃f�[�^�捞�͕\��
//				this.ToolbarsManager_Main.Tools["ButtonTool_TSPBarcodeInput"].SharedProps.Visible = true;
			}
			else
			{
				// �{�^���̕\��-��\��
//				this.ExplorerBar_InputHelp.Groups["InputHelper"].Items["TSPBarcodeInput"].Visible = false;
				// �c�[���o�[��TSP�񓚃f�[�^�捞�͔�\��
//				this.ToolbarsManager_Main.Tools["ButtonTool_TSPBarcodeInput"].SharedProps.Visible = false;
			}
        }

		/// <summary>
		/// �i�ԓ��̓`�F�b�N����
		/// </summary>
		/// <param name="prevVal">���͍ς݃e�L�X�g</param>
		/// <param name="key">���͕���</param>
		/// <param name="selstart">�I���J�n�ʒu</param>
		/// <param name="sellength">�I���e�L�X�g������</param>
		/// <returns>True:���͕�����t��, False:���͕�����t�s��</returns>
		private bool KeyPressPartsNoCheck(string prevVal, char key, int selstart, int sellength)
		{
			int withHyphenLength = 24;
			int withoutHyphenLength = 20;

			// ����L�[�������ꂽ�H
			if (Char.IsControl(key))
			{
				return true;
			}

			// �p����,�n�C�t���ȊO��NG
			if (!Regex.IsMatch(key.ToString(), "[a-zA-Z0-9-]"))
			{
				return false;
			}

			// �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
			string _strResult = "";
			if (sellength > 0)
			{
				_strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
			}
			else
			{
				_strResult = prevVal;
			}

			// �n�C�t�����擾
			int hyphenCnt = 0;
			foreach(char wkChar in _strResult)
			{
				if (wkChar == '-') hyphenCnt++;
			}

			// �n�C�t�����`�F�b�N
			if ((hyphenCnt >= withHyphenLength - withoutHyphenLength) && (key == '-'))
			{
				return false;
			}

			// �n�C�t�����������`�F�b�N
			if ((_strResult.Length - hyphenCnt >= withoutHyphenLength) && (key != '-'))
			{
				return false;
			}

			// �L�[�������ꂽ���ʂ̕�����𐶐�����
			_strResult = prevVal.Substring(0, selstart)
				+ key
				+ prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

			// �����`�F�b�N
			if (_strResult.Length > withHyphenLength)
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// �i�ԓ��̓`�F�b�N����
		/// </summary>
		/// <param name="inputString">���͕i��</param>
		/// <returns>�`�F�b�N�E�C����i��</returns>
		private string TextChangePartsNoCheck(string inputString)
		{
			if (inputString == null) return "";

			int withHyphenLength = 24;
			int withoutHyphenLength = 20;
			int hyphenCnt = 0;
			StringBuilder retStr = new StringBuilder();

			for (int i = 0; i < inputString.Length; i++)
			{
				// �p����,�n�C�t���ȊO��NG
				if (!Regex.IsMatch(inputString[i].ToString(), "[a-zA-Z0-9-]"))
				{
					continue;
				}

				if (inputString[i] == '-')
				{
					// �ǉ��\�ł���Βǉ�����
					if (hyphenCnt < withHyphenLength - withoutHyphenLength)
					{
						retStr.Append(inputString[i]);
					}
					// �n�C�t���J�E���^�C���N�������g
					hyphenCnt++;
				}
				else
				{
					// �ǉ��\�ł���Βǉ�����
					if (retStr.Length - hyphenCnt < withoutHyphenLength)
					{
						retStr.Append(inputString[i]);
					}
				}
			}

			return retStr.ToString();
		}

		/// <summary>
		/// ���l���̓`�F�b�N����
		/// </summary>
		/// <param name="keta">����(�}�C�i�X�������܂܂�)</param>
		/// <param name="priod">�����_�ȉ�����</param>
		/// <param name="prevVal">���݂̕�����</param>
		/// <param name="key">���͂��ꂽ�L�[�l</param>
		/// <param name="selstart">�J�[�\���ʒu</param>
		/// <param name="sellength">�I�𕶎���</param>
		/// <param name="minusFlg">�}�C�i�X���͉H</param>
		/// <returns>true=���͉�,false=���͕s��</returns>
		private bool KeyPressNumCheck(int keta, int priod, string prevVal, char key, int selstart, int sellength, Boolean minusFlg)
		{
			// ����L�[�������ꂽ�H
			if (Char.IsControl(key))
			{
				return true;
			}
			// ���l�ȊO�́A�m�f
			if (!Char.IsDigit(key))
			{
				// �����_�܂��́A�}�C�i�X�ȊO
				if ((key != '.') && (key != '-'))
				{
					return false;
				}
			}

			// �L�[�������ꂽ�Ɖ��肵���ꍇ�̕�����𐶐�����B
			string _strResult = "";
			if (sellength > 0)
			{
				_strResult = prevVal.Substring(0, selstart) + prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));
			}
			else
			{
				_strResult = prevVal;
			}

			// �}�C�i�X�̃`�F�b�N
			if (key == '-')
			{
				if ((minusFlg == false) || (selstart > 0) || (_strResult.IndexOf('-') != -1))
				{
					return false;
				}
			}

			// �����_�̃`�F�b�N
			if (key == '.')
			{
				if ((priod <= 0) || (_strResult.IndexOf('.') != -1))
				{
					return false;
				}
			}
			// �L�[�������ꂽ���ʂ̕�����𐶐�����B
			_strResult = prevVal.Substring(0, selstart)
				+ key
				+ prevVal.Substring(selstart + sellength, prevVal.Length - (selstart + sellength));

			// �����`�F�b�N�I
			if (_strResult.Length > keta)
			{
				if (_strResult[0] == '-')
				{
					if (_strResult.Length > (keta + 1))
					{
						return false;
					}
				}
				else
				{
					return false;
				}
			}

			// �����_�ȉ��̃`�F�b�N
			if (priod > 0)
			{
				// �����_�̈ʒu����
				int _pointPos = _strResult.IndexOf('.');

				// �������ɓ��͉\�Ȍ���������I
				int _Rketa = (_strResult[0] == '-') ? keta - priod : keta - priod - 1;
				// �������̌������`�F�b�N
				if (_pointPos != -1)
				{
					if (_pointPos > _Rketa)
					{
						return false;
					}
				}
				else
				{
					if (_strResult.Length > _Rketa)
					{
						return false;
					}
				}

				// �������̌������`�F�b�N
				if (_pointPos != -1)
				{
					// �������̌������v�Z
					int _priketa = _strResult.Length - _pointPos - 1;
					if (priod < _priketa)
					{
						return false;
					}
				}
			}
			return true;
		}

        #endregion

        /// <summary>
        /// �ҏW�ەύX����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void methoduoptSet_ValueChanged(object sender, EventArgs e)
        {
            
        }
        
        /// <summary>
        /// ���Ӑ���擾
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetCustomerInf(object sender, EventArgs e)
        {
//            SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);
            _pushBtn = (Infragistics.Win.Misc.UltraButton)sender;
            SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_NORMAL, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);

            customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);
        }

        /// <summary>
        /// ���Ӑ�I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">���Ӑ�ԗ������߂�l�N���X</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
//            CustSuppli custSuppli;
            
//            int status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo, out custSuppli);
            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (custSuppli == null)
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "�I�������d����͎d��������͂��s���Ă��Ȃ��ׁA�g�p�o���܂���B",
                        status,
                        MessageBoxButtons.OK);

                    return;
                }
 
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "�I���������Ӑ�͊��ɍ폜����Ă��܂��B",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
            else
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_STOPDISP,
                    this.Name,
                    "���Ӑ���̎擾�Ɏ��s���܂����B",
                    status,
                    MessageBoxButtons.OK);

                return;
            }

            if (_pushBtn != null)
            {
            }

            _pushBtn = null;

        }

        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {

        }

        private void CustomerCode01_tNedit_ValueChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// �t�H�[�J�X����������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerCode_tNedit_BeforeExitEditMode(object sender, Infragistics.Win.BeforeExitEditModeEventArgs e)
        {
            CustomerInfo customerInfo = new CustomerInfo();

            int setCode = 0;
            bool exist = false;

//            exist = CheckValue(ref sender,ref setCode);
           

            if (exist)
            {
                //���͂��m�F���ꂽ�Ƃ��̏���
                int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, setCode, out customerInfo);

                
                if (status == 0)
                {
                    //�����`�F�b�N
                    int totalDay = customerInfo.TotalDay;

                    //�`�F�b�N�Ώۂ�����
                    bool chkTarget = false;

                    //if ((totalDay < 28) && ((TotalDay_tNedit.GetInt() >= 28) || (LastDay_CheckEditor.Checked == true)))
                    if ((TotalDay_tNedit.GetInt() == 0) || (TotalDay_tNedit.GetInt() == 99))
                    {
                        chkTarget = false;
                    }
                    else if (totalDay < 28)
                    {
                        chkTarget = true;
                    }
//                    else if ((totalDay > 28) && (LastDay_CheckEditor.Checked != true))
//                    {
//                        chkTarget = true;
//                    }
                    if (chkTarget)
                    {
                        if (totalDay != TotalDay_tNedit.GetInt())
                        {
                            TMsgDisp.Show(
                                this,
                                emErrorLevel.ERR_LEVEL_EXCLAMATION,
                                this.Name,
                                "�������قȂ链�Ӑ�ł�",
                                status,
                                MessageBoxButtons.OK);

                            //Object���擾
                            TNedit errNedit = new TNedit();
                            errNedit = (TNedit)sender;

                            errNedit.Focus();

                            return;
                        }
                    }

                }
                else
                {
                    TMsgDisp.Show(
                        this,
                        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                        this.Name,
                        "�Y�����链�Ӑ�͂���܂���B",
                        status,
                        MessageBoxButtons.OK);
                }
            }
            else
            {
            }           
        }

        private void TotalDay_tNedit_AfterExitEditMode(object sender, EventArgs e)
        {
            //�������t��ύX���܂��B
            int setDay = TotalDay_tNedit.GetInt();
            if (setDay != 0)
            {
                // �����X�V���ύX����
                ChangeDate(setDay);
            }            
        }

        /// <summary>
        /// �����X�V���ύX
        /// </summary>
        /// <param name="totalday"></param>
        private void ChangeDate(int totalday)
        {
            int year = tDateEdit1.GetDateYear();
            int month = tDateEdit1.GetDateMonth();
            int day = tDateEdit1.GetDateDay();
            if (totalday < 28)
            {
                day = totalday;
            }
            else if (totalday > 31)
            {
                day = SetMaxDay(year, month);
            }
            else
            {
                int chkday = SetMaxDay(year, month);

                if (chkday == totalday)
                {
                    day = chkday;
                }
                else if (totalday > chkday)
                {
                    day = chkday;
                }
            }
            DateTime setDate = new DateTime(year, month, day);
            tDateEdit1.SetDateTime(setDate);
        }

        /// <summary>
        /// �����擾
        /// </summary>
        /// <param name="targetDay"></param>
        /// <returns></returns>
        private int SetMaxDay(int year, int month)
        {
            int totalday = DateTime.Today.Day;

            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    {
                        totalday = 31;
                        break;
                    }
                case 2:
                    if (DateTime.IsLeapYear(year))
                    {
                        totalday = 29;
                    }
                    else
                    {
                        totalday = 28;
                    }
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    {
                        totalday = 30;
                        break;
                    }
            }

            return totalday;
        }
           --- DEL 2008/08/21 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/21 Partsman�p�ɕύX
    }
}