//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F��������X�V
// �v���O�����T�v   �F��������X�V���s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E �K�j
// �C����    2008/08/08     �C�����e�FPartsman�p�ɕύX
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/04/06     �C�����e�FMantis�y10079�z�S���_�w��Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F22018 ��� ���b
// �C����    2010/08/17     �C�����e�F�������b�N�Ή�
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
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.Misc;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ��������X�V�t�H�[���N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ��������X�V���s���t�H�[���N���X�ł��B</br>
	/// <br>Programer  : 19077 �n糋M�T</br>
	/// <br>Date       : 2007.04.03</br>
    /// <br>Update Note: 2008/08/08 30414 �E �K�j Partsman�p�ɕύX</br>
    /// <br>Update Note: 2010/08/17 22018 ��� ���b�@�������b�N�Ή�</br>
    /// </remarks>
	public partial class MAKAU00128UA : Form
	{
		//==================================================================
		//  �R���X�g���N�^
		//==================================================================
		#region �R���X�g���N�^
		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public MAKAU00128UA()
		{
			InitializeComponent();                        
            
            //CustDmdPrcAcs = CustDmdPrcAcs.GetInstance();

            if (LoginInfoAcquisition.EnterpriseCode != null)
            {
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }
/*
			// ���ח���\������
			_colDispInfo = new ProductStockDisplayStatus();
			// ��`�t�@�C����菉���l�擾
			_colDispInfo.DeserializeData(ctFILE_ColDispInfo);
			// ��`�t�@�C���𐳂����ǂݍ��߂����H
			if (_colDispInfo.CheckDisplayStatus() == false)
			{
				// �����l�ɂ���B
				_colDispInfo.SetDefaultValue();
			}
*/
            /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
            this._customerInfoAcs = new CustomerInfoAcs();
               --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/

            this._custDmdPrcAcs = new CustDmdPrcAcs();

            // --- ADD 2008/08/08 --------------------------------------------------------------------->>>>>
            this._secInfoAcs = new SecInfoAcs();
            this._secInfoSetAcs = new SecInfoSetAcs();
            this._billAllStAcs = new BillAllStAcs();

            this._totalDayCalculator = TotalDayCalculator.GetInstance();
            this._totalDayCalculator.InitializeHisDmdC();

            this._billAllStDic = new Dictionary<string, BillAllSt>();

            // �����S�̐ݒ�}�X�^�Ǎ�
            LoadBillAllSt();
            // --- ADD 2008/08/08 ---------------------------------------------------------------------<<<<<

            // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
            ////------ �A�C�R���ݒ� ------
            //this.Customer01_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            //this.Customer02_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            //this.Customer03_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            //this.Customer04_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            //this.Customer05_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            //this.Customer06_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            //this.Customer07_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            //this.Customer08_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            //this.Customer09_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            //this.Customer10_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            //// ��ʏ�����
            //AllDispClear(false);
            
            //// �t�H�[�J�X�ݒ�
            //tNedit_TotalDay.Focus();

            //------ �A�C�R���ݒ� ------
            this.uButton_SectionGuide.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            // ��ʏ�����
            AllDispClear();

            // ��ʏ����ݒ�
            InitializeSetting();

            // �t�H�[�J�X�ݒ�
            //this.tEdit_SectionCode.Focus();       // DEL 2009/04/06
            SetFocus();                             // ADD 2009/04/06
            // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<
        }
		#endregion

		//--------------------------------------------------------
		//  �v���C�x�[�g�ϐ�
		//--------------------------------------------------------
		#region �v���C�x�[�g�ϐ�

        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
        private ArrayList _stockRet = new ArrayList();
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/

        /// <summary>
        /// ���ԍ݌ɃA�N�Z�X�N���X
        /// </summary>
        private CustDmdPrcAcs _custDmdPrcAcs;

		/// <summary>
		/// �`�[���ח�\���X�e�[�^�X
		/// </summary>
//		private ProductStockDisplayStatus _colDispInfo = null;

        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
		private string _enterpriseCode;

        // --- ADD 2008/08/08 --------------------------------------------------------------------->>>>>
        private SecInfoAcs _secInfoAcs;
        private SecInfoSetAcs _secInfoSetAcs;
        private BillAllStAcs _billAllStAcs;
        private TotalDayCalculator _totalDayCalculator;
        
        private Dictionary<string, BillAllSt> _billAllStDic;

        private string _prevSectionCode;

        private int _convertProcessDivCd;

        // �v���O����ID
        private const string ASSEMBLY_ID = "MAKAU00128U";
        // --- ADD 2008/08/08 ---------------------------------------------------------------------<<<<<

        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �C�x���g����t���O
		/// </summary>
		private bool _localEventBlockFlg = false;

        private UltraButton _pushBtn = null;
        private int[] _customerTotalDay;

        private CustomerInfoAcs _customerInfoAcs;
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/

        private const string SECTION_CODE_COMMON = "00";    // ADD 2009/04/06
        
        #endregion

        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
        //--------------------------------------------------------
		//  �v���C�x�[�g�萔
		//--------------------------------------------------------
		#region �v���C�x�[�g�萔
		/// <summary>���ח�\���X�e�[�^�X�t�@�C������</summary>
		private const string ctFILE_ColDispInfo = "MAKAU00128U.DAT";
		
		/// <summary>PGID</summary>
		private const string ctPGID = "MAKAU00128U";
		#endregion

		//==================================================================
		//  �p�u���b�N�C�x���g
		//==================================================================
        public static event GetSectionEventHandler GetSection;
        public delegate string GetSectionEventHandler();

        public string _sectionCd;
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/

        //--------------------------------------------------------
		//  �C���^�[�t�F�[�X������
		//--------------------------------------------------------
		#region �C���^�[�t�F�[�X������

        #region DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
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
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #region IStockEntryTbsCtrlChildEvent �����o

        #region DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
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

            tNedit_TotalDay.Focus();
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
        /// ���̓`�F�b�N
        /// </summary>
        /// <returns></returns>
        public int CheckInput()
        {
            return CheckInputData();
        }

        /// <summary>
        /// ���̓`�F�b�N
        /// </summary>
        /// <returns></returns>
        private int CheckInputData()
        {
            int result = 0;

            //����
            if (LastDay_CheckEditor.Checked != true)
            {
                int chkInt = (int)TotalDay_tNedit.GetInt();
                if ((chkInt <= 0) || ((chkInt > 31) && (chkInt != 99)))
                {
                    return 1;
                }
            }

            //���Ӑ�
            if (Target_uOptionSet.CheckedIndex != 0)
            {
                //���Ӑ�ʑS�ċ�
                if ((CustomerCode1_tNedit.Text.Trim() == "") &&
                    (CustomerCode2_tNedit.Text.Trim() == "") &&
                    (CustomerCode3_tNedit.Text.Trim() == "") &&
                    (CustomerCode4_tNedit.Text.Trim() == "") &&
                    (CustomerCode5_tNedit.Text.Trim() == "") &&
                    (CustomerCode6_tNedit.Text.Trim() == "") &&
                    (CustomerCode7_tNedit.Text.Trim() == "") &&
                    (CustomerCode8_tNedit.Text.Trim() == "") &&
                    (CustomerCode9_tNedit.Text.Trim() == "") &&
                    (CustomerCode10_tNedit.Text.Trim() == ""))
                {
                    return 2;
                }

                //���Ӑ�d��
                int[] chkInt;
                chkInt = new int[10];
                chkInt[0] = CustomerCode1_tNedit.GetInt();
                chkInt[1] = CustomerCode2_tNedit.GetInt();
                chkInt[2] = CustomerCode3_tNedit.GetInt();
                chkInt[3] = CustomerCode4_tNedit.GetInt();
                chkInt[4] = CustomerCode5_tNedit.GetInt();
                chkInt[5] = CustomerCode6_tNedit.GetInt();
                chkInt[6] = CustomerCode7_tNedit.GetInt();
                chkInt[7] = CustomerCode8_tNedit.GetInt();
                chkInt[8] = CustomerCode9_tNedit.GetInt();
                chkInt[9] = CustomerCode10_tNedit.GetInt();

                for (int i = 0; i < 10; i++)
                {
                    for (int ii = i; ii < 10; ii++)
                    {
                        if ((chkInt[i] != 0) && (i != ii) && (chkInt[i] == chkInt[ii]))
                        {
                            return 3;
                        }
                    }
                }
            }

            // ���t�̗L����
            try
            {
                int year = tDateEdit_CAddUpUpdDate.GetDateYear();
                int month = tDateEdit_CAddUpUpdDate.GetDateMonth();
                int day = tDateEdit_CAddUpUpdDate.GetDateDay();
                DateTime datetime = new DateTime(year, month, day);
            }
            catch
            {
                return 4;
            }

            return result;            
        }
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
        /// ������
        /// </summary>
        public int ExecuteSaveProc()
        {
            // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
            //string msg;
            //int status = SaveProc(out msg);
            //if (status != 0)
            //{
            //    if (String.IsNullOrEmpty(msg))
            //    {
            //        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, "�X�V�Ɏ��s���܂���", 0, MessageBoxButtons.OK);
            //    }
            //    else
            //    {
            //        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, msg, 0, MessageBoxButtons.OK);
            //    }
            //}
            //else
            //{
            //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, this.Name, "�X�V���܂���", 0, MessageBoxButtons.OK);
            //}

            int status = SaveProc();
            // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<

            return status;
        }

        /// <summary>
        /// ���������s
        /// </summary>
        private int SaveProc()
        {
            DialogResult dr = TMsgDisp.Show(emErrorLevel.ERR_LEVEL_QUESTION,
                                            ASSEMBLY_ID,
                                            "�X�V���Ă���낵���ł����H",
                                            0,
                                            MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
            {
                return (0);
            }

            // ���̓`�F�b�N
            bool bStatus = CheckInputData(false);
            if (!bStatus)
            {
                return (-1);
            }

            string errMsg;

            // ���_�R�[�h
            //string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');  // DEL 2009/04/06
            string sectionCode = SECTION_CODE_COMMON;                                       // ADD 2009/04/06
            // �����������
            DateTime cAddUpUpdDate = this.tDateEdit_CAddUpUpdDate.GetDateTime();
            // �Ώے���
            int totalDay = this.tNedit_TotalDay.GetInt();

            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "�X�V��";
            msgForm.Message = "��������X�V�������ł��B" + "\n" + "���΂炭���҂����������B";

            int status;

            try
            {
                msgForm.Show();

                status = this._custDmdPrcAcs.RegistDmdData(this._enterpriseCode,
                                                               sectionCode,
                                                               cAddUpUpdDate,
                                                               totalDay,
                                                               out errMsg);
            }
            finally
            {
                msgForm.Close();
            }

            // 2009.04.02 30413 ���� �t�H�[�����ŏ�ʂɎ����Ă��� >>>>>>START
            this.TopMost = true;
            this.TopMost = false;
            // 2009.04.02 30413 ���� �t�H�[�����ŏ�ʂɎ����Ă��� <<<<<<END
            
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
                        // --- UPD m.suzuki 2010/08/17 ---------->>>>>
                        //TMsgDisp.Show(this,
                        //            emErrorLevel.ERR_LEVEL_STOPDISP,
                        //            this.Name,
                        //            "�X�V�Ɏ��s���܂����B" + "\r\n"
                        //            + "\r\n" +
                        //            "�V�F�A�`�F�b�N�G���[�i��ƃ��b�N�j�ł��B" + "\r\n" +
                        //            "�����������A���̑��̋Ɩ����s���Ă��邽�ߖ{�����͍s���܂���B" + "\r\n" +
                        //            "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                        //            status,
                        //            MessageBoxButtons.OK);
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            "",
                            "���������ݍ����Ă��邽�ߒ��f���܂����B" + "\r\n" +
                            "�Ď��s���邩�A���΂炭�҂��Ă���ēx���������s���ĉ������B" + "\r\n",
                            status,
                            MessageBoxButtons.OK );
                        // --- UPD m.suzuki 2010/08/17 ----------<<<<<
                        return (status);
                    }
                // ���_���b�N�^�C���A�E�g
                case (int)ConstantManagement.DB_Status.ctDB_SEC_LOCK_TIMEOUT:
                // --- ADD m.suzuki 2010/08/17 ---------->>>>>
                // �������b�N(�`�[��)�^�C���A�E�g
                case (int)ConstantManagement.DB_Status.ctDB_ADS_LOCK_TIMEOUT:
                // --- ADD m.suzuki 2010/08/17 ----------<<<<<
                    {
                        // --- UPD m.suzuki 2010/08/17 ---------->>>>>
                        //TMsgDisp.Show(this,
                        //            emErrorLevel.ERR_LEVEL_STOPDISP,
                        //            this.Name,
                        //            "�X�V�Ɏ��s���܂����B" + "\r\n"
                        //            + "\r\n" +
                        //            "�V�F�A�`�F�b�N�G���[�i���_���b�N�j�ł��B" + "\r\n" +
                        //            "���������A���������ݍ����Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n" +
                        //            "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                        //            status,
                        //            MessageBoxButtons.OK);
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            "",
                            "���������ݍ����Ă��邽�ߒ��f���܂����B" + "\r\n" +
                            "�Ď��s���邩�A���΂炭�҂��Ă���ēx���������s���ĉ������B" + "\r\n",
                            status,
                            MessageBoxButtons.OK );
                        // --- UPD m.suzuki 2010/08/17 ----------<<<<<
                        return (status);
                    }
                // �q�Ƀ��b�N�^�C���A�E�g
                case (int)ConstantManagement.DB_Status.ctDB_WAR_LOCK_TIMEOUT:
                    {
                        // --- UPD m.suzuki 2010/08/17 ---------->>>>>
                        //TMsgDisp.Show(this,
                        //            emErrorLevel.ERR_LEVEL_STOPDISP,
                        //            this.Name,
                        //            "�X�V�Ɏ��s���܂����B" + "\r\n"
                        //            + "\r\n" +
                        //            "�V�F�A�`�F�b�N�G���[�i�q�Ƀ��b�N�j�ł��B" + "\r\n" +
                        //            "�I���������A���̑��̍݌ɋƖ����s���Ă��邽�߃^�C���A�E�g���܂����B" + "\r\n" +
                        //            "�Ď��s���邩�A���΂炭�҂��Ă���ēx�������s���Ă��������B",
                        //            status,
                        //            MessageBoxButtons.OK);
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            "",
                            "���������ݍ����Ă��邽�ߒ��f���܂����B" + "\r\n" +
                            "�Ď��s���邩�A���΂炭�҂��Ă���ēx���������s���ĉ������B" + "\r\n",
                            status,
                            MessageBoxButtons.OK );
                        // --- UPD m.suzuki 2010/08/17 ----------<<<<<
                        return (status);
                    }
                // --- ADD m.suzuki 2010/08/17 ---------->>>>>
                // �������b�N(�W�v��)�^�C���A�E�g
                case (int)ConstantManagement.DB_Status.ctDB_ADU_LOCK_TIMEOUT:
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            "",
                            "�Ώۂ̊��Ԃ��W�v�������̂��ߒ��f���܂����B" + "\r\n" +
                            "�Ď��s���邩�A���΂炭�҂��Ă���ēx���������s���ĉ������B" + "\r\n",
                            status,
                            MessageBoxButtons.OK );
                        return (status);
                    }
                // --- ADD m.suzuki 2010/08/17 ----------<<<<<
                default:
                    if ((errMsg == null) || (errMsg.Trim() == ""))
                    {
                        TMsgDisp.Show(
                            this,								// �e�E�B���h�E�t�H�[��
                            emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "SaveProc",				            // ��������
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
                            ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                            this.Text,							// �v���O��������
                            "SaveProc",				            // ��������
                            TMsgDisp.OPE_UPDATE,				// �I�y���[�V����
                            errMsg,				                // �\�����郁�b�Z�[�W 
                            status,								// �X�e�[�^�X�l
                            this._custDmdPrcAcs,				// �G���[�����������I�u�W�F�N�g
                            MessageBoxButtons.OK,				// �\������{�^��
                            MessageBoxDefaultButton.Button1);	// �����\���{�^��
                    }

                    // �Y���f�[�^�Ȃ����@�ꎞ�I��126�ɂ��Ă���
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        // �������ݒ菈��
                        SetNextTotalDay(sectionCode, totalDay);
                    }
                    return (status);
            }

            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                          ASSEMBLY_ID,
                          "�����X�V�͊������܂����B",
                          0,
                          MessageBoxButtons.OK);

            this._totalDayCalculator.ClearCache();
            this._totalDayCalculator.InitializeHisDmdC();

            // �����ݒ�
            SetHisTotalDayDmdC(sectionCode);

            // �t�H�[�J�X�ݒ�
            SetFocus();
            
            return (status);
        }

        /// <summary>
        /// �������ݒ菈��
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="totalDay">�Ώے���</param>
        private void SetNextTotalDay(string sectionCode, int totalDay)
        {
            BillAllSt billAllSt;

            if (this._billAllStDic.ContainsKey(sectionCode))
            {
                // �Ώۋ��_�̐����S�̐ݒ�}�X�^���擾
                billAllSt = this._billAllStDic[sectionCode];
            }
            else
            {
                // �S�Ћ��ʂ̐����S�̐ݒ�}�X�^���擾
                billAllSt = this._billAllStDic["00"];
            }

            // ���Ӑ���������X�g�ɕێ�
            ArrayList totalDayList = new ArrayList();

            if (billAllSt.CustomerTotalDay1 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay1);
            }
            if (billAllSt.CustomerTotalDay2 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay2);
            }
            if (billAllSt.CustomerTotalDay3 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay3);
            }
            if (billAllSt.CustomerTotalDay4 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay4);
            }
            if (billAllSt.CustomerTotalDay5 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay5);
            }
            if (billAllSt.CustomerTotalDay6 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay6);
            }
            if (billAllSt.CustomerTotalDay7 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay7);
            }
            if (billAllSt.CustomerTotalDay8 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay8);
            }
            if (billAllSt.CustomerTotalDay9 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay9);
            }
            if (billAllSt.CustomerTotalDay10 != 0)
            {
                totalDayList.Add(billAllSt.CustomerTotalDay10);
            }

            // �ݒ肳��Ă��������1�ȉ��̏ꍇ�A�����I��
            if (totalDayList.Count <= 1)
            {
                return;
            }

            int index = 0;
            foreach (int day in totalDayList)
            {
                if (totalDay <= day)
                {
                    break;
                }

                index++;
            }

            // ���̒����擾
            int nextTotalDay;
            if (totalDay >= 28)
            {
                nextTotalDay = (int)totalDayList[0];
            }
            else
            {
                if (index == totalDayList.Count - 1)
                {
                    nextTotalDay = (int)totalDayList[0];
                }
                else
                {
                    nextTotalDay = (int)totalDayList[index + 1];
                }
            }

            // ���͂��ꂽ������������擾
            DateTime currentTotalDay = this.tDateEdit_CAddUpUpdDate.GetDateTime();

            if (totalDay > nextTotalDay)
            {
                currentTotalDay = currentTotalDay.AddMonths(1);
            }

            if (nextTotalDay >= 28)
            {
                nextTotalDay = DateTime.DaysInMonth(currentTotalDay.Year, currentTotalDay.Month);
            }

            // ������������Ɏ��̒������Z�b�g
            this.tDateEdit_CAddUpUpdDate.SetDateTime(new DateTime(currentTotalDay.Year, currentTotalDay.Month, nextTotalDay));
            // �Ώے����Ɏ��̒������Z�b�g
            this.tNedit_TotalDay.SetInt(nextTotalDay);
        }

        /// <summary>
        /// �r������
        /// </summary>
        /// <param name="status">STATUS</param>
        /// <remarks>
        /// <br>Note       : �r���������s���܂�</br>
        /// <br>Programmer : 30414 �E�@�K�j</br>
        /// <br>Date       : 2008/08/08</br>
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
                            ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
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
                            ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
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
        /// ���̓`�F�b�N����
        /// </summary>
        /// <param name="deleteFlg">True:�����O�`�F�b�N False:�X�V�O�`�F�b�N</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʏ��̓��̓`�F�b�N���s���܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private bool CheckInputData(bool deleteFlg)
        {
            string errMsg = "";

            try
            {
                // DEL 2009/04/06 ------>>>
                //// ���_
                //if (this.tEdit_SectionCode.DataText.Trim() == "")
                //{
                //    errMsg = "���_����͂��Ă��������B";
                //    this.tEdit_SectionCode.Focus();
                //    return (false);
                //}
                //string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');
                //if (GetSectionName(sectionCode) == "")
                //{
                //    errMsg = "�}�X�^�ɓo�^����Ă��܂���B";
                //    this.tEdit_SectionCode.Focus();
                //    return (false);
                //}
                // DEL 2009/04/06 ------<<<
                
                // �����������
                if (this.tDateEdit_CAddUpUpdDate.GetDateTime() == DateTime.MinValue)
                {
                    errMsg = "���������������͂��Ă��������B";
                    this.tDateEdit_CAddUpUpdDate.Focus();
                    return (false);
                }
                if (this.tDateEdit_LastCAddUpUpdDate.GetDateTime() != DateTime.MinValue)
                {
                    if (this.tDateEdit_CAddUpUpdDate.GetDateTime() <= this.tDateEdit_LastCAddUpUpdDate.GetDateTime())
                    {
                        errMsg = "���t�̎w��Ɍ�肪����܂��B";
                        this.tDateEdit_CAddUpUpdDate.Focus();
                        return (false);
                    }
                }

                // �����O
                if (deleteFlg == true)
                {
                    // �R���o�[�g���s��
                    if (this._convertProcessDivCd == 1)
                    {
                        errMsg = "�R���o�[�g�ȑO�̒�����͂ł��܂���B";
                        //this.tEdit_SectionCode.Focus();       // DEL 2009/04/06
                        this.tDateEdit_CAddUpUpdDate.Focus();   // ADD 2009/04/06
                        return (false);
                    }

                    if (this.tDateEdit_LastCAddUpUpdDate.GetDateTime() == DateTime.MinValue)
                    {
                        errMsg = "�O��̒��X�V���������݂��Ȃ����߁A����������͎��s�ł��܂���B";
                        //this.tEdit_SectionCode.Focus();       // DEL 2009/04/06
                        this.tDateEdit_CAddUpUpdDate.Focus();   // ADD 2009/04/06
                        return (false);
                    }
                }
                // �X�V�O
                else
                {
                    // �Ώے���
                    if (!CheckTotalDay(out errMsg))
                    {
                        this.tNedit_TotalDay.Focus();
                        return (false);
                    }
                }
            }
            finally
            {
                if (errMsg.Length > 0)
                {
                    TMsgDisp.Show(
                        this, 								// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_INFO, 		// �G���[���x��
                        ASSEMBLY_ID, 						// �A�Z���u���h�c�܂��̓N���X�h�c
                        errMsg, 	                        // �\�����郁�b�Z�[�W
                        0, 									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);				// �\������{�^��
                }
            }

            return (true);
        }

        /// <summary>
        /// �Ώے����`�F�b�N����
        /// </summary>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ώے����̃`�F�b�N���s���܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private bool CheckTotalDay(out string errMsg)
        {
            errMsg = "";

            int totalDay = this.tNedit_TotalDay.GetInt();

            if (totalDay == 0)
            {
                errMsg = "�Ώے�������͂��Ă��������B";
                return (false);
            }
            else if (totalDay == 99)
            {
                // �Ώے�����99�̏ꍇ�A�S�����Ή�
                return (true);
            }

            //string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');  // DEL 2009/04/06
            string sectionCode = SECTION_CODE_COMMON;                                       // ADD 2009/04/06

            BillAllSt billAllSt;

            if (this._billAllStDic.ContainsKey(sectionCode))
            {
                // �Ώۋ��_�̐����S�̐ݒ�}�X�^���擾
                billAllSt = this._billAllStDic[sectionCode];
            }
            else
            {
                // �Ώۋ��_�̐����S�̐ݒ�}�X�^���擾
                billAllSt = this._billAllStDic["00"];
            }

            if (totalDay >= 28)
            {
                if ((28 > billAllSt.CustomerTotalDay1) && (28 > billAllSt.CustomerTotalDay2) &&
                    (28 > billAllSt.CustomerTotalDay3) && (28 > billAllSt.CustomerTotalDay4) &&
                    (28 > billAllSt.CustomerTotalDay5) && (28 > billAllSt.CustomerTotalDay6) &&
                    (28 > billAllSt.CustomerTotalDay7) && (28 > billAllSt.CustomerTotalDay8) &&
                    (28 > billAllSt.CustomerTotalDay9) && (28 > billAllSt.CustomerTotalDay10) &&
                    (28 > billAllSt.CustomerTotalDay11) && (28 > billAllSt.CustomerTotalDay12))
                {
                    errMsg = "�����S�̐ݒ�̏����Ώے����ɊY������������܂���B";
                    return (false);
                }
            }
            else
            {
                if ((totalDay != billAllSt.CustomerTotalDay1) && (totalDay != billAllSt.CustomerTotalDay2) &&
                    (totalDay != billAllSt.CustomerTotalDay3) && (totalDay != billAllSt.CustomerTotalDay4) &&
                    (totalDay != billAllSt.CustomerTotalDay5) && (totalDay != billAllSt.CustomerTotalDay6) &&
                    (totalDay != billAllSt.CustomerTotalDay7) && (totalDay != billAllSt.CustomerTotalDay8) &&
                    (totalDay != billAllSt.CustomerTotalDay9) && (totalDay != billAllSt.CustomerTotalDay10) &&
                    (totalDay != billAllSt.CustomerTotalDay11) && (totalDay != billAllSt.CustomerTotalDay12))
                {
                    errMsg = "�����S�̐ݒ�̏����Ώے����ɊY������������܂���B";
                    return (false);
                }
            }

            int year = this.tDateEdit_CAddUpUpdDate.GetDateYear();
            int month = this.tDateEdit_CAddUpUpdDate.GetDateMonth();
            int day = this.tDateEdit_CAddUpUpdDate.GetDateDay();

            // ��������������̏ꍇ�A����31���̓G���[�Ƃ��Ȃ�
            if ((DateTime.DaysInMonth(year, month) != day) || (totalDay != 31))
            {
                if (this.tDateEdit_CAddUpUpdDate.GetDateDay() != totalDay)
                {
                    errMsg = "���t�̎w��Ɍ�肪����܂��B";
                    return (false);
                }
            }

            return (true);
        }

        #region DEL 2008/08/08 Partsman�p�ɕύX
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ����������
        /// </summary>
        private int SaveProc(out string msg)
        {
            int retTotalCnt = 0;
            
            ArrayList setCustomer = new ArrayList();
            ArrayList setTotalDay = new ArrayList();

            int totalDay = 0;

            if (LastDay_CheckEditor.Checked)
            {
                //�`�F�b�N����=>����
                totalDay = 99;
            }else if (TotalDay_tNedit.Text.ToString().Trim() != "")
            {
                totalDay = Int32.Parse(this.TotalDay_tNedit.Text.ToString());
            }

            //���Ӑ�
            if (CustomerCode1_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(Int32.Parse(CustomerCode1_tNedit.Text.ToString().Trim()));
            }
            if (CustomerCode2_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(Int32.Parse(CustomerCode2_tNedit.Text.ToString().Trim()));
            }
            if (CustomerCode3_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(Int32.Parse(CustomerCode3_tNedit.Text.ToString().Trim()));
            }
            if (CustomerCode4_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(Int32.Parse(CustomerCode4_tNedit.Text.ToString().Trim()));
            }
            if (CustomerCode5_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(Int32.Parse(CustomerCode5_tNedit.Text.ToString().Trim()));
            }
            if (CustomerCode6_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(Int32.Parse(CustomerCode6_tNedit.Text.ToString().Trim()));
            }
            if (CustomerCode7_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(Int32.Parse(CustomerCode7_tNedit.Text.ToString().Trim()));
            }
            if (CustomerCode8_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(Int32.Parse(CustomerCode8_tNedit.Text.ToString().Trim()));
            }
            if (CustomerCode9_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(Int32.Parse(CustomerCode9_tNedit.Text.ToString().Trim()));
            }
            if (CustomerCode10_tNedit.Text.ToString().Trim() == "")
            {
                setCustomer.Add(0);
            }
            else
            {
                setCustomer.Add(Int32.Parse(CustomerCode10_tNedit.Text.ToString().Trim()));
            }

            for (int i = 0; i < 10; i++)
            {
                setTotalDay.Add(_customerTotalDay[i]);
            }

            int setOption = (int)Target_uOptionSet.CheckedItem.DataValue;

            DateTime addUpdate = tDateEdit_CAddUpUpdDate.GetDateTime();

            if (addUpdate == DateTime.MinValue)
            {
                msg = "�����X�V�N�����̎w��Ɍ�肪����܂��B";
                return -1;
            }

            DateTime addupYM = addUpdate;

            return _custDmdPrcAcs.RegistDmdData(out retTotalCnt, this._enterpriseCode, this._sectionCd, addUpdate, addupYM, setCustomer, setTotalDay, totalDay, setOption, 1, out msg);
        }
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 Partsman�p�ɕύX

        /// <summary>
        /// ������
        /// </summary>
        public int ExecuteDelProc()
        {
            // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
            //string msg ;
            //int status = DelProc(out msg);
            //if (status != 0)
            //{
            //    if (!String.IsNullOrEmpty(msg))
            //    {
            //        TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_EXCLAMATION,
            //            this.Name,
            //            msg,
            //            status,
            //            MessageBoxButtons.OK);
            //    }
            //    else
            //    {
            //        TMsgDisp.Show(
            //            this,
            //            emErrorLevel.ERR_LEVEL_INFO,
            //            this.Name,
            //            "�������Ɏ��s���܂���",
            //            status,
            //            MessageBoxButtons.OK);
            //    }
            //}
            //else
            //{
            //    TMsgDisp.Show(
            //        this,
            //        emErrorLevel.ERR_LEVEL_INFO,
            //        this.Name,
            //        "���������܂���",
            //        status,
            //        MessageBoxButtons.OK);
            //}
            int status = DelProc();
            // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<

            return status;
        }

        /// <summary>
        /// ���������s����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        /// </remarks>
        private int DelProc()
        {
            DialogResult result = TMsgDisp.Show(
                                        this, 								                    // �e�E�B���h�E�t�H�[��
                                        emErrorLevel.ERR_LEVEL_QUESTION, 		                // �G���[���x��
                                        ASSEMBLY_ID, 						                    // �A�Z���u���h�c�܂��̓N���X�h�c
                                        "�O����������ɊY�����������\n������������܂��B",   // �\�����郁�b�Z�[�W
                                        0, 									                    // �X�e�[�^�X�l
                                        MessageBoxButtons.YesNo);				                // �\������{�^��

            if (result == DialogResult.No)
            {
                return (-1);
            }

            // ���̓`�F�b�N
            bool bStatus = CheckInputData(true);
            if (!bStatus)
            {
                return (-1);
            }

            string errMsg;

            // ���_�R�[�h
            //string sectionCode = this.tEdit_SectionCode.DataText.Trim().PadLeft(2, '0');      // DEL 2009/04/06
            string sectionCode = SECTION_CODE_COMMON;                                           // ADD 2009/04/06
            // �O���������
            DateTime lastCAddUpUpdDate = this.tDateEdit_LastCAddUpUpdDate.GetDateTime();

            // ���o����ʕ��i�̃C���X�^���X���쐬
            SFCMN00299CA msgForm = new SFCMN00299CA();
            msgForm.Title = "�����";
            msgForm.Message = "��������X�V������ł��B" + "\n" + "���΂炭���҂����������B";
            
            int status;

            try
            {
                msgForm.Show();

                status = this._custDmdPrcAcs.BanishDmdData(this._enterpriseCode,
                                                               sectionCode,
                                                               lastCAddUpUpdDate,
                                                               out errMsg);
            }
            finally
            {
                msgForm.Close();
            }

            // 2009.04.02 30413 ���� �t�H�[�����ŏ�ʂɎ����Ă��� >>>>>>START
            this.TopMost = true;
            this.TopMost = false;
            // 2009.04.02 30413 ���� �t�H�[�����ŏ�ʂɎ����Ă��� <<<<<<END

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                  ASSEMBLY_ID,
                                  "�������܂����B",
                                  0,
                                  MessageBoxButtons.OK);
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                  ASSEMBLY_ID,
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
                        TMsgDisp.Show(this,							// �e�E�B���h�E�t�H�[��
                                  emErrorLevel.ERR_LEVEL_STOPDISP,	// �G���[���x��
                                  ASSEMBLY_ID,						// �A�Z���u���h�c�܂��̓N���X�h�c
                                  this.Text,						// �v���O��������
                                  "DelProc",				        // ��������
                                  TMsgDisp.OPE_DELETE,				// �I�y���[�V����
                                  "�����Ɏ��s���܂����B",			// �\�����郁�b�Z�[�W 
                                  status,							// �X�e�[�^�X�l
                                  this._custDmdPrcAcs,				// �G���[�����������I�u�W�F�N�g
                                  MessageBoxButtons.OK,				// �\������{�^��
                                  MessageBoxDefaultButton.Button1);	// �����\���{�^��
                    }
                    else
                    {
                        TMsgDisp.Show(this,							    // �e�E�B���h�E�t�H�[��
                                  emErrorLevel.ERR_LEVEL_EXCLAMATION,	// �G���[���x��
                                  ASSEMBLY_ID,						    // �A�Z���u���h�c�܂��̓N���X�h�c
                                  this.Text,						    // �v���O��������
                                  "DelProc",				            // ��������
                                  TMsgDisp.OPE_DELETE,				    // �I�y���[�V����
                                  errMsg,			                    // �\�����郁�b�Z�[�W 
                                  status,							    // �X�e�[�^�X�l
                                  this._custDmdPrcAcs,				    // �G���[�����������I�u�W�F�N�g
                                  MessageBoxButtons.OK,				    // �\������{�^��
                                  MessageBoxDefaultButton.Button1);	    // �����\���{�^��
                    }

                    return (status);
            }

            this._totalDayCalculator.ClearCache();
            this._totalDayCalculator.InitializeHisDmdC();

            // �����ݒ�
            SetHisTotalDayDmdC(sectionCode);

            // �t�H�[�J�X�ݒ�
            SetFocus();

            return (status);
        }

        #region DEL 2008/08/08 Partsman�p�ɕύX
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ������������
        /// </summary>
        private int DelProc(out string msg)
        {
            int retTotalCnt = 0;

            ArrayList setCustomer = new ArrayList();
            ArrayList setTotalDay = new ArrayList();

            int totalDay = 0;

            if (LastDay_CheckEditor.Checked)
            {
                totalDay = 99;
            }
            else if (this.TotalDay_tNedit.Text.ToString().Trim() != "")
            {
                totalDay = Int32.Parse(this.TotalDay_tNedit.Text.ToString());
            }

            //int setOption = Target_uOptionSet.CheckedIndex;
            int setOption = (int)Target_uOptionSet.Value;

            //���Ӑ�
            if (CustomerCode1_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode1_tNedit.Text.ToString().Trim())); 
            }
            else
            {
                setCustomer.Add(0);
            }
            if (CustomerCode2_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode2_tNedit.Text.ToString().Trim()));
            }
            else
            {
                setCustomer.Add(0);
            }
            if (CustomerCode3_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode3_tNedit.Text.ToString().Trim()));
            }
            else
            {
                setCustomer.Add(0);
            }
            if (CustomerCode4_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode4_tNedit.Text.ToString().Trim()));
            }
            else
            {
                setCustomer.Add(0);
            }
            if (CustomerCode5_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode5_tNedit.Text.ToString().Trim()));
            }
            else
            {
                setCustomer.Add(0);
            }
            if (CustomerCode6_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode6_tNedit.Text.ToString().Trim()));
            }
            else
            {
                setCustomer.Add(0);
            }
            if (CustomerCode7_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode7_tNedit.Text.ToString().Trim()));
            }
            else
            {
                setCustomer.Add(0);
            }
            if (CustomerCode8_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode8_tNedit.Text.ToString().Trim()));
            }
            else
            {
                setCustomer.Add(0);
            }
            if (CustomerCode9_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode9_tNedit.Text.ToString().Trim()));
            }
            else
            {
                setCustomer.Add(0);
            }
            if (CustomerCode10_tNedit.Text.ToString().Trim() != "")
            {
                setCustomer.Add(Int32.Parse(CustomerCode10_tNedit.Text.ToString().Trim()));
            }
            else
            {
                setCustomer.Add(0);
            }

            for (int i = 0; i < 10; i++)
            {
                setTotalDay.Add(_customerTotalDay[i]);
            }

            return _custDmdPrcAcs.BanishDmdData(out retTotalCnt, _enterpriseCode,_sectionCd, setCustomer, setTotalDay, totalDay, setOption, 1, out msg);
        }
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 Partsman�p�ɕύX

        #endregion

        #region DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
        #region IStockEntryTbsCtrlChildCheck �����o
        /// <summary>
		/// ���̓`�F�b�N����
		/// </summary>
		/// <param name="sender"></param>
		/// <returns></returns>
		public int CheckInputData(object sender)
		{
			string message = "";
			bool errFlg = false;
			Control invalidCtrl = null;

            // ���׍s�`�F�b�N
            if (!errFlg)
            {
            }
            
            if (errFlg)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, message, 0, MessageBoxButtons.OK);

				if (invalidCtrl != null)
				{
					invalidCtrl.Focus();
				}

				return 1;
			}

			return 0;
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
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        #endregion

        //--------------------------------------------------------
		//  �R���g���[���C�x���g�n���h��
		//--------------------------------------------------------
		#region �R���g���[���C�x���g�n���h��

        #region DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
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
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
        /// �����t�H�[�J�X�Z�b�g
        /// </summary>
        public void SetFocus()
        {
            // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
            //tNedit_TotalDay.Focus();
            //this.tEdit_SectionCode.Focus();       // DEL 2009/04/06
            // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<
            this.tDateEdit_CAddUpUpdDate.Focus();   // ADD 2009/04/06
        }

        /// <summary>
        /// ��ʃN���A
        /// </summary>
        public void DispClear()
        {
            // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
            //AllDispClear(false);
            AllDispClear();
            // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<
        }

        // --- ADD 2008/08/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ��ʏ�����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ����������܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private void AllDispClear()
        {
            this.tEdit_SectionCode.Clear();
            this.tEdit_SectionName.Clear();
            this.tDateEdit_LastCAddUpUpdDate.Clear();
            this.tDateEdit_CAddUpUpdDate.Clear();
            this.tNedit_TotalDay.Clear();

            this._prevSectionCode = "";
        }

        /// <summary>
        /// ��ʏ����ݒ菈��
        /// </summary>
        /// <remarks>
        /// <br>Note       : ��ʂ̏����ݒ���s���܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private void InitializeSetting()
        {
            // DEL 2009/04/06 ------>>>
            //// ���_�R�[�h
            //this.tEdit_SectionCode.DataText = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            //this._prevSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.Trim();
            //// ���_����
            //this.tEdit_SectionName.DataText = GetSectionName(LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
            //// �����ݒ�
            //SetHisTotalDayDmdC(LoginInfoAcquisition.Employee.BelongSectionCode.Trim());
            // DEL 2009/04/06 ------<<<

            // ADD 2009/04/06 ------>>>
            // ���_�R�[�h
            this.tEdit_SectionCode.DataText = SECTION_CODE_COMMON;
            this._prevSectionCode = SECTION_CODE_COMMON;
            // �����ݒ�
            SetHisTotalDayDmdC(SECTION_CODE_COMMON);
            // ADD 2009/04/06 ------<<<
            //// �Ώے���
            //this.tNedit_TotalDay.SetInt(this.tDateEdit_CAddUpUpdDate.GetDateDay());
        }

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.SectionCode.Trim() == sectionCode.Trim().PadLeft(2, '0'))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                        break;
                    }
                }
            }
            catch
            {
                sectionName = "";
            }

            return sectionName;
        }

        /// <summary>
        /// �����擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="lastCAddUpUpdDate">�O�����</param>
        /// <param name="currentCAddUpUpdDate">�������</param>
        /// <param name="convertProcessDivCd">�R���o�[�g�����敪</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �O������A����������擾���܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private int GetHisTotalDayDmdC(string sectionCode, out DateTime lastCAddUpUpdDate, out DateTime currentCAddUpUpdDate, out int convertProcessDivCd)
        {
            lastCAddUpUpdDate = new DateTime();
            currentCAddUpUpdDate = new DateTime();
            convertProcessDivCd = 0;
            
            if ((sectionCode == "") || (sectionCode == "0") || (sectionCode == "00"))
            {
                // �S�Ђ̏ꍇ
                sectionCode = "";
            }
            else
            {
                // �e���_�̏ꍇ
                sectionCode = sectionCode.PadLeft(2, '0');
            }

            int status;

            try
            {
                status = this._totalDayCalculator.GetHisTotalDayDmdC(sectionCode, out lastCAddUpUpdDate, out currentCAddUpUpdDate, out convertProcessDivCd);
            }
            catch
            {
                lastCAddUpUpdDate = new DateTime();
                currentCAddUpUpdDate = new DateTime();
                convertProcessDivCd = 0;

                status = -1;
            }

            return (status);
        }

        /// <summary>
        /// �����ݒ菈��
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <remarks>
        /// <br>Note       : �O������A���������ݒ肵�܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private void SetHisTotalDayDmdC(string sectionCode)
        {
            DateTime lastCAddUpUpdDate;
            DateTime currentCAddUpUpdDate;
            int convertProcessDivCd;

            int status = GetHisTotalDayDmdC(sectionCode, out lastCAddUpUpdDate, out currentCAddUpUpdDate, out convertProcessDivCd);
            if (status == 0)
            {
                // �O������ݒ�
                this.tDateEdit_LastCAddUpUpdDate.SetDateTime(lastCAddUpUpdDate);

                // ��������ݒ�
                this.tDateEdit_CAddUpUpdDate.SetDateTime(currentCAddUpUpdDate);

                // �Ώے���(������������̓���28���ȍ~�́A�Ώے���31���������\��)
                if (currentCAddUpUpdDate.Day >= 28)
                {
                    this.tNedit_TotalDay.SetInt(31);
                }
                else
                {
                    this.tNedit_TotalDay.SetInt(this.tDateEdit_CAddUpUpdDate.GetDateDay());
                }

                // �R���o�[�g�����敪
                this._convertProcessDivCd = convertProcessDivCd;
            }
            else
            {
                // �O������ݒ�
                this.tDateEdit_LastCAddUpUpdDate.SetDateTime(new DateTime());

                // ��������ݒ�
                this.tDateEdit_CAddUpUpdDate.SetDateTime(new DateTime());

                // �Ώے���
                this.tNedit_TotalDay.Clear();

                // �R���o�[�g�����敪
                this._convertProcessDivCd = 0;
            }
        }

        /// <summary>
        /// �����S�̐ݒ�}�X�^�Ǎ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����S�̐ݒ�}�X�^���擾���܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
        private int LoadBillAllSt()
        {
            int status = 0;

            try
            {
                ArrayList retList;

                status = this._billAllStAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (BillAllSt billAllSt in retList)
                    {
                        this._billAllStDic.Add(billAllSt.SectionCode.Trim(), billAllSt);
                    }
                }
            }
            catch
            {
                status = -1;
            }

            return (status);
        }
        // --- ADD 2008/08/08 ---------------------------------------------------------------------<<<<<

        #region DEL 2008/08/08 Partsman�p�ɕύX
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
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

            ClearEmployee();

            ChangeEnableCustomer(false);

            LastDay_CheckEditor.Checked = false;

            Target_uOptionSet.CheckedIndex = 0;

            tDateEdit_CAddUpUpdDate.Clear();
            tDateEdit_CAddUpUpdDate.SetDateTime(DateTime.Now);
        }
        
        /// <summary>
        /// ���Ӑ���͉ې���
        /// </summary>
        /// <param name="enable"></param>
        private void ChangeEnableCustomer(bool enable)
        {
            CustomerCode1_tNedit.Enabled = enable;
            CustomerCode2_tNedit.Enabled = enable;
            CustomerCode3_tNedit.Enabled = enable;
            CustomerCode4_tNedit.Enabled = enable;
            CustomerCode5_tNedit.Enabled = enable;
            CustomerCode6_tNedit.Enabled = enable;
            CustomerCode7_tNedit.Enabled = enable;
            CustomerCode8_tNedit.Enabled = enable;
            CustomerCode9_tNedit.Enabled = enable;
            CustomerCode10_tNedit.Enabled = enable;

            Customer01_uButton.Enabled = enable;
            Customer02_uButton.Enabled = enable;
            Customer03_uButton.Enabled = enable;
            Customer04_uButton.Enabled = enable;
            Customer05_uButton.Enabled = enable;
            Customer06_uButton.Enabled = enable;
            Customer07_uButton.Enabled = enable;
            Customer08_uButton.Enabled = enable;
            Customer09_uButton.Enabled = enable;
            Customer10_uButton.Enabled = enable;
        }
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 Partsman�p�ɕύX

        #endregion

        #region DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
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
            _pushBtn = (UltraButton)sender;
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
                //if (custSuppli == null)
                //{
                //    TMsgDisp.Show(
                //        this,
                //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //        this.Name,
                //        "�I�������d����͎d��������͂��s���Ă��Ȃ��ׁA�g�p�o���܂���B",
                //        status,
                //        MessageBoxButtons.OK);

                //    return;
                //}
  

                //if (customerInfo.SupplierDiv == 1)
                //{
                //    TMsgDisp.Show(
                //        this,
                //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                //        this.Name,
                //        "�I���������Ӑ�͎d����ɐݒ肳��Ă��܂��B",
                //        status,
                //        MessageBoxButtons.OK);

                //    return;
                //}
  
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
                if (_pushBtn == Customer01_uButton)
                {
                    CustomerCode1_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm1_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[0] = customerInfo.TotalDay;
                }
                else if (_pushBtn == Customer02_uButton)
                {
                    CustomerCode2_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm2_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[1] = customerInfo.TotalDay;
                }
                else if (_pushBtn == Customer03_uButton)
                {
                    CustomerCode3_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm3_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[2] = customerInfo.TotalDay;
                }
                else if (_pushBtn == Customer04_uButton)
                {
                    CustomerCode4_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm4_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[3] = customerInfo.TotalDay;
                }
                else if (_pushBtn == Customer05_uButton)
                {
                    CustomerCode5_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm5_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[4] = customerInfo.TotalDay;
                }
                else if (_pushBtn == Customer06_uButton)
                {
                    CustomerCode6_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm6_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[5] = customerInfo.TotalDay;
                }
                else if (_pushBtn == Customer07_uButton)
                {
                    CustomerCode7_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm7_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[6] = customerInfo.TotalDay;
                }
                else if (_pushBtn == Customer08_uButton)
                {
                    CustomerCode8_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm8_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[7] = customerInfo.TotalDay;
                }
                else if (_pushBtn == Customer09_uButton)
                {
                    CustomerCode9_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm9_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[8] = customerInfo.TotalDay;
                }
                else if (_pushBtn == Customer10_uButton)
                {
                    CustomerCode10_tNedit.Text = customerInfo.CustomerCode.ToString().Trim();
                    CustomerNm10_tEdit.Text = customerInfo.Name;
                    _customerTotalDay[9] = customerInfo.TotalDay;
                }
            }

            _pushBtn = null;
            
//            StockSlip stockSlip = this._stockSlipInputAcs.StockSlip;
//            stockSlip.CustomerCode = customerSearchRet.CustomerCode;
//            stockSlip.CustomerName = customerSearchRet.Name;
//            stockSlip.CustomerName2 = customerSearchRet.Name2;

            // �d���f�[�^�N���X����ʊi�[����
//            this.SetDisplay(stockSlip);
            

            // �d���f�[�^�L���b�V������
//            this._stockSlipInputAcs.Cache(stockSlip);
        }

        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {

        }

        private bool CheckValue(ref object sender,ref int setCode)
        {
            bool exist = false;
            
            if (sender == CustomerCode1_tNedit)
            {
                if ((CustomerCode1_tNedit.Text.Trim() != "") && (CustomerCode1_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode1_tNedit.Text.Trim());
                    exist = true;
                }
            }
            else if (sender == CustomerCode2_tNedit) 
            {
                if ((CustomerCode2_tNedit.Text.Trim() != "") && (CustomerCode2_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode2_tNedit.Text.Trim());
                    exist = true;
                }
            }
            else if (sender == CustomerCode3_tNedit)
            {
                if ((CustomerCode3_tNedit.Text.Trim() != "") && (CustomerCode3_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode3_tNedit.Text.Trim());
                    exist = true;
                }
            }
            else if (sender == CustomerCode4_tNedit)
            {
                if ((CustomerCode4_tNedit.Text.Trim() != "") && (CustomerCode4_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode4_tNedit.Text.Trim());
                    exist = true;
                }
            }
            else if (sender == CustomerCode5_tNedit)
            {
                if ((CustomerCode5_tNedit.Text.Trim() != "") && (CustomerCode5_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode5_tNedit.Text.Trim());
                    exist = true;
                }                
            }
            else if (sender == CustomerCode6_tNedit)
            {
                if ((CustomerCode6_tNedit.Text.Trim() != "") && (CustomerCode6_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode6_tNedit.Text.Trim());
                    exist = true;
                }                
            }
            else if (sender == CustomerCode7_tNedit)
            {
                if ((CustomerCode7_tNedit.Text.Trim() != "") && (CustomerCode7_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode7_tNedit.Text.Trim());
                    exist = true;
                }
            }
            else if (sender == CustomerCode8_tNedit)
            {
                if ((CustomerCode8_tNedit.Text.Trim() != "") && (CustomerCode8_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode8_tNedit.Text.Trim());
                    exist = true;
                }
            }
            else if (sender == CustomerCode9_tNedit)
            {
                if ((CustomerCode9_tNedit.Text.Trim() != "") && (CustomerCode9_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode9_tNedit.Text.Trim());
                    exist = true;
                }
            }
            else if (sender == CustomerCode10_tNedit)
            {
                if ((CustomerCode10_tNedit.Text.Trim() != "") && (CustomerCode10_tNedit.Text.Trim() != "0"))
                {
                    setCode = Int32.Parse(CustomerCode10_tNedit.Text.Trim());
                    exist = true;
                }
            }
            return exist;
        }

        private void TotalDay_tNedit_AfterExitEditMode(object sender, EventArgs e)
        {
            //�������t��ύX���܂��B
            int setDay = tNedit_TotalDay.GetInt();
            if (setDay != 0)
            {
                ChangeDate(setDay);
            }
        }

        /// <summary>
        /// �����X�V���ύX
        /// </summary>
        /// <param name="totalday"></param>
        private void ChangeDate(int totalday)
        {
            int year = tDateEdit_CAddUpUpdDate.GetDateYear();
            int month = tDateEdit_CAddUpUpdDate.GetDateMonth();
            int day = tDateEdit_CAddUpUpdDate.GetDateDay();
            if (day == 0)
            {
                day = totalday;
            }
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
            DateTime setDate = new DateTime(year,month,day);
            tDateEdit_CAddUpUpdDate.SetDateTime(setDate);
        }

        /// <summary>
        /// �����擾
        /// </summary>
        /// <param name="targetDay"></param>
        /// <returns></returns>
        private int SetMaxDay(int year,int month)
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

        /// <summary>
        /// ������v�`�F�b�N
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerCode_tNedit_BeforeExitEditMode(object sender, Infragistics.Win.BeforeExitEditModeEventArgs e)
        {
            CustomerInfo customerInfo = new CustomerInfo();

            int setCode = 0;
            bool exist = false;

            exist = CheckValue(ref sender, ref setCode);

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
                    else if ((totalDay > 28) && (LastDay_CheckEditor.Checked != true))
                    {
                        chkTarget = true;
                    }
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

                    //if (customerInfo.SupplierDiv == 1)
                    //{
                    //    TMsgDisp.Show(
                    //        this,
                    //        emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    //        this.Name,
                    //        "�I���������Ӑ���͎d����ɐݒ肳��Ă��܂��B",
                    //        status,
                    //        MessageBoxButtons.OK);

                    //    ((TNedit)sender).Focus();

                    //    return;
                    //}
  
                    if (sender == CustomerCode1_tNedit)
                    {
                        CustomerNm1_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[0] = customerInfo.TotalDay;
                    }
                    else if (sender == CustomerCode2_tNedit)
                    {
                        CustomerNm2_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[1] = customerInfo.TotalDay;
                    }
                    else if (sender == CustomerCode3_tNedit)
                    {
                        CustomerNm3_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[2] = customerInfo.TotalDay;
                    }
                    else if (sender == CustomerCode4_tNedit)
                    {
                        CustomerNm4_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[3] = customerInfo.TotalDay;
                    }
                    else if (sender == CustomerCode5_tNedit)
                    {
                        CustomerNm5_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[4] = customerInfo.TotalDay;
                    }
                    else if (sender == CustomerCode6_tNedit)
                    {
                        CustomerNm6_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[5] = customerInfo.TotalDay;
                    }
                    else if (sender == CustomerCode7_tNedit)
                    {
                        CustomerNm7_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[6] = customerInfo.TotalDay;
                    }
                    else if (sender == CustomerCode8_tNedit)
                    {
                        CustomerNm8_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[7] = customerInfo.TotalDay;
                    }
                    else if (sender == CustomerCode9_tNedit)
                    {
                        CustomerNm9_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[8] = customerInfo.TotalDay;
                    }
                    else if (sender == CustomerCode10_tNedit)
                    {
                        CustomerNm10_tEdit.Text = customerInfo.Name;
                        _customerTotalDay[9] = customerInfo.TotalDay;
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
                    if (sender == CustomerCode1_tNedit)
                    {
                        CustomerNm1_tEdit.Text = "";
                        _customerTotalDay[0] = 0;
                        CustomerCode1_tNedit.Focus();
                    }
                    else if (sender == CustomerCode2_tNedit)
                    {
                        CustomerNm2_tEdit.Text = "";
                        _customerTotalDay[1] = 1;
                        CustomerCode2_tNedit.Focus();
                    }
                    else if (sender == CustomerCode3_tNedit)
                    {
                        CustomerNm3_tEdit.Text = "";
                        _customerTotalDay[2] = 2;
                        CustomerCode3_tNedit.Focus();
                    }
                    else if (sender == CustomerCode4_tNedit)
                    {
                        CustomerNm4_tEdit.Text = "";
                        _customerTotalDay[3] = 3;
                        CustomerCode4_tNedit.Focus();
                    }
                    else if (sender == CustomerCode5_tNedit)
                    {
                        CustomerNm5_tEdit.Text = "";
                        _customerTotalDay[4] = 4;
                        CustomerCode5_tNedit.Focus();
                    }
                    else if (sender == CustomerCode6_tNedit)
                    {
                        CustomerNm6_tEdit.Text = "";
                        _customerTotalDay[5] = 5;
                        CustomerCode6_tNedit.Focus();
                    }
                    else if (sender == CustomerCode7_tNedit)
                    {
                        CustomerNm7_tEdit.Text = "";
                        _customerTotalDay[6] = 6;
                        CustomerCode7_tNedit.Focus();
                    }
                    else if (sender == CustomerCode8_tNedit)
                    {
                        CustomerNm8_tEdit.Text = "";
                        _customerTotalDay[7] = 7;
                        CustomerCode8_tNedit.Focus();
                    }
                    else if (sender == CustomerCode9_tNedit)
                    {
                        CustomerNm9_tEdit.Text = "";
                        _customerTotalDay[8] = 8;
                        CustomerCode9_tNedit.Focus();
                    }
                    else if (sender == CustomerCode10_tNedit)
                    {
                        CustomerNm10_tEdit.Text = "";
                        _customerTotalDay[9] = 9;
                        CustomerCode10_tNedit.Focus();
                    }
                }
            }
            else
            {
                //���̕����̂݃N���A���Ă���
                if (sender == CustomerCode1_tNedit)
                {
                    CustomerNm1_tEdit.Text = "";
                    _customerTotalDay[0] = 0;
                }
                else if (sender == CustomerCode2_tNedit)
                {
                    CustomerNm2_tEdit.Text = "";
                    _customerTotalDay[1] = 1;
                }
                else if (sender == CustomerCode3_tNedit)
                {
                    CustomerNm3_tEdit.Text = "";
                    _customerTotalDay[2] = 2;
                }
                else if (sender == CustomerCode4_tNedit)
                {
                    CustomerNm4_tEdit.Text = "";
                    _customerTotalDay[3] = 3;
                }
                else if (sender == CustomerCode5_tNedit)
                {
                    CustomerNm5_tEdit.Text = "";
                    _customerTotalDay[4] = 4;
                }
                else if (sender == CustomerCode6_tNedit)
                {
                    CustomerNm6_tEdit.Text = "";
                    _customerTotalDay[5] = 5;
                }
                else if (sender == CustomerCode7_tNedit)
                {
                    CustomerNm7_tEdit.Text = "";
                    _customerTotalDay[6] = 6;
                }
                else if (sender == CustomerCode8_tNedit)
                {
                    CustomerNm8_tEdit.Text = "";
                    _customerTotalDay[7] = 7;
                }
                else if (sender == CustomerCode9_tNedit)
                {
                    CustomerNm9_tEdit.Text = "";
                    _customerTotalDay[8] = 8;
                }
                else if (sender == CustomerCode10_tNedit)
                {
                    CustomerNm10_tEdit.Text = "";
                    _customerTotalDay[9] = 9;
                }
            }           
        }

        private void Target_uOptionSet_ValueChanged(object sender, EventArgs e)
        {
            switch ((int)Target_uOptionSet.CheckedItem.DataValue)
            {
                case 1: ChangeEnableCustomer(false);
                    ClearEmployee();
                    break;
                case 2: ChangeEnableCustomer(true);
                    break;
                case 3: ChangeEnableCustomer(true);
                    break;
            }
        }

        /// <summary>
        /// �S���ҏ��N���A
        /// </summary>
        private void ClearEmployee()
        {
            CustomerCode1_tNedit.Text = "";
            CustomerCode2_tNedit.Text = "";
            CustomerCode3_tNedit.Text = "";
            CustomerCode4_tNedit.Text = "";
            CustomerCode5_tNedit.Text = "";
            CustomerCode6_tNedit.Text = "";
            CustomerCode7_tNedit.Text = "";
            CustomerCode8_tNedit.Text = "";
            CustomerCode9_tNedit.Text = "";
            CustomerCode10_tNedit.Text = "";

            CustomerNm1_tEdit.Text = "";
            CustomerNm2_tEdit.Text = "";
            CustomerNm3_tEdit.Text = "";
            CustomerNm4_tEdit.Text = "";
            CustomerNm5_tEdit.Text = "";
            CustomerNm6_tEdit.Text = "";
            CustomerNm7_tEdit.Text = "";
            CustomerNm8_tEdit.Text = "";
            CustomerNm9_tEdit.Text = "";
            CustomerNm10_tEdit.Text = "";
        }

        private void LastDay_CheckEditor_CheckedValueChanged(object sender, EventArgs e)
        {
            if (LastDay_CheckEditor.Checked != true)
            {
                TotalDay_tNedit.Enabled = true;
            }
            else
            {
                TotalDay_tNedit.Value = 99;
                TotalDay_tNedit.Text = "";
                TotalDay_tNedit.Enabled = false;
                SetLastdate();
            }
        }
        
        private void SetLastdate()
        {
            DateTime datetime = tDateEdit_CAddUpUpdDate.GetDateTime();
            //            string sEndDate = DateTime.Parse(datetime.AddMonths(1).ToString("yyyy/MM/01")).AddDays(-1).ToShortDateString();
            datetime = DateTime.Parse(datetime.AddMonths(1).ToString("yyyy/MM/01")).AddDays(-1);
            tDateEdit_CAddUpUpdDate.SetDateTime(datetime);
        }
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        // --- ADD 2008/08/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// Click �C�x���g(���_�K�C�h)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note       : ���_�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programer  : 30414 �E �K�j</br>
        /// <br>Date       : 2008/08/08</br>
        /// </remarks>
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

                    // �����ݒ�
                    SetHisTotalDayDmdC(secInfoSet.SectionCode.Trim());

                    // �t�H�[�J�X�ݒ�
                    this.tDateEdit_CAddUpUpdDate.Focus();
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void tRetKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
        {
            if (e.PrevCtrl == null)
            {
                return;
            }

            if (e.PrevCtrl == this.tEdit_SectionCode)
            {
                if (this.tEdit_SectionCode.DataText.Trim() == "")
                {
                    this.tEdit_SectionName.Clear();
                    this.tDateEdit_CAddUpUpdDate.SetDateTime(new DateTime());
                    this.tDateEdit_LastCAddUpUpdDate.SetDateTime(new DateTime());
                    this.tNedit_TotalDay.Clear();
                    this._prevSectionCode = "";
                    return;
                }

                string sectionCode = this.tEdit_SectionCode.DataText.Trim();
                if (sectionCode != this._prevSectionCode)
                {
                    // ���_���̎擾
                    this.tEdit_SectionName.DataText = GetSectionName(sectionCode);

                    if (this.tEdit_SectionName.DataText.Trim() == "")
                    {
                        TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO,
                                      ASSEMBLY_ID,
                                      "�}�X�^�ɓo�^����Ă��܂���B",
                                      0,
                                      MessageBoxButtons.OK);

                        this.tEdit_SectionCode.Clear();
                        this.tDateEdit_LastCAddUpUpdDate.SetDateTime(new DateTime());
                        this.tDateEdit_CAddUpUpdDate.SetDateTime(new DateTime());
                        this.tNedit_TotalDay.Clear();
                        this._prevSectionCode = "";

                        e.NextCtrl = e.PrevCtrl;
                        return;
                    }

                    // �����ݒ�
                    SetHisTotalDayDmdC(sectionCode);

                    // �o�b�t�@�ɑO��l��ۑ�
                    this._prevSectionCode = sectionCode;
                }

                if (e.ShiftKey == false)
                {
                    if ((e.Key == Keys.Tab) || (e.Key == Keys.Enter))
                    {
                        if (this.tEdit_SectionName.DataText.Trim() != "")
                        {
                            // �t�H�[�J�X�ݒ�
                            e.NextCtrl = this.tDateEdit_CAddUpUpdDate;
                        }
                    }
                }
            }
            else if (e.PrevCtrl == this.tDateEdit_CAddUpUpdDate)
            {
                // DEL 2009/04/06 ------>>>
                //if (e.ShiftKey == true)
                //{
                //    if (e.Key == Keys.Tab)
                //    {
                //        if (this.tEdit_SectionName.DataText.Trim() != "")
                //        {
                //            e.NextCtrl = this.tEdit_SectionCode;
                //            return;
                //        }
                //    }
                //}
                // DEL 2009/04/06 ------<<<
            }
        }
        // --- ADD 2008/08/08 ---------------------------------------------------------------------<<<<<
    }
}