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
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Library.Windows.Forms;

using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.Misc;
using Infragistics.Win;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �x�������t�H�[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �x���������s���t�H�[���N���X�ł��B</br>
	/// <br>Programer  : 19077 �n糋M�T</br>
	/// <br>Date       : 2007.05.18</br>
	/// </remarks>
	public partial class MAKAU00148UA : Form
	{
		//==================================================================
		//  �R���X�g���N�^
		//==================================================================
		#region �R���X�g���N�^
		/// <summary>
		/// �f�t�H���g�R���X�g���N�^
		/// </summary>
		public MAKAU00148UA()
		{
			InitializeComponent();

            /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
            //SuplierPayAcs = SuplierPayAcs.GetInstance();

            if (LoginInfoAcquisition.EnterpriseCode != null)
            {
                this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            }
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
            this._customerInfoAcs = new CustomerInfoAcs();
            this._suplierPayAcs = new SuplierPayAcs();                        

            //------ �A�C�R���ݒ� ------
            this.Customer01_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.Customer02_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.Customer03_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.Customer04_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.Customer05_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.Customer06_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.Customer07_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.Customer08_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.Customer09_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            this.Customer10_uButton.Appearance.Image = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            
            // ��ʏ�����
            AllDispClear(false);
            
            // �t�H�[�J�X�ݒ�
            TotalDay_tNedit.Focus();    
                --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        }
		#endregion

        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
		//--------------------------------------------------------
		//  �v���C�x�[�g�ϐ�
		//--------------------------------------------------------
		#region �v���C�x�[�g�ϐ�

        private ArrayList _stockRet = new ArrayList();

        /// <summary>
        /// ���ԍ݌ɃA�N�Z�X�N���X
        /// </summary>
        private SuplierPayAcs _suplierPayAcs;

		/// <summary>
		/// �`�[���ח�\���X�e�[�^�X
		/// </summary>
//		private ProductStockDisplayStatus _colDispInfo = null;
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
		private string _enterpriseCode;

		/// <summary>
		/// �C�x���g����t���O
		/// </summary>
		private bool _localEventBlockFlg = false;

        private UltraButton _pushBtn = null;
        private int[] _customerTotalDay;

        private CustomerInfoAcs _customerInfoAcs;

		#endregion

		//--------------------------------------------------------
		//  �v���C�x�[�g�萔
		//--------------------------------------------------------
		#region �v���C�x�[�g�萔
		/// <summary>���ח�\���X�e�[�^�X�t�@�C������</summary>
		private const string ctFILE_ColDispInfo = "MAKAU00148U.DAT";
		
		/// <summary>PGID</summary>
		private const string ctPGID = "MAKAU00148U";
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
//			SuplierPayAcs.SlipDtlColChanged += PtSuplSlipAcs_SlipDtlColChanged;

			// ���ԍ݌ɃA�N�Z�X�N���X�̖��׃e�[�u���s�ύX�C�x���g�Ƀn���h����ǉ�
//			SuplierPayAcs.SlipDtlRowChanged += SlipDtlDataTable_SlipDtlRowChanged;

            // �t�H�[�J�X�ݒ�
            TotalDay_tNedit.Focus();
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
                int year = tDateEdit1.GetDateYear();
                int month = tDateEdit1.GetDateMonth();
                int day = tDateEdit1.GetDateDay();
                DateTime datetime = new DateTime(year, month, day);
            }
            catch
            {
                return 4;
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
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, "�X�V�Ɏ��s���܂����B"�@+  " : " + status.ToString(), 0, MessageBoxButtons.OK);
                }
                else
                {
                    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, msg + " : " + status.ToString() , 0, MessageBoxButtons.OK);
                }
            }
            else
            {
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, this.Name, "�X�V���܂���", 0, MessageBoxButtons.OK);
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

            int totalDay = 0;

            if (LastDay_CheckEditor.Checked)
            {
                //�`�F�b�N����=>����
                totalDay = 99;
            }
            else if (TotalDay_tNedit.Text.ToString().Trim() != "")
            {
                totalDay = Int32.Parse(this.TotalDay_tNedit.Text.ToString());
            }

            //�d����
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
                setCustomer.Add(System.Int32.Parse(CustomerCode7_tNedit.Text.ToString().Trim()));
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
                setCustomer.Add(System.Int32.Parse(CustomerCode9_tNedit.Text.ToString().Trim()));
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

            DateTime addUpdate = tDateEdit1.GetDateTime();
            DateTime addupYM = addUpdate;

            // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
            //return _suplierPayAcs.RegistDmdData(out retTotalCnt, this._enterpriseCode, this._sectionCd,addUpdate,addupYM, setCustomer, setTotalDay, totalDay, setOption,1,out msg);
            msg = "";
            return 0;
            // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<
        }
                
        /// <summary>
        /// ������
        /// </summary>
        public int ExecuteDelProc()
        {
            string msg ;
            int status = DelProc(out msg);
            if (status != 0)
            {
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
                    emErrorLevel.ERR_LEVEL_INFO,
                    this.Name,
                    "���������܂���",
                    status,
                    MessageBoxButtons.OK);
            }
            return status;
        }

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

            //�d����
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

            // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
            //return _suplierPayAcs.BanishDmdData(out retTotalCnt, _enterpriseCode, _sectionCd, setCustomer, setTotalDay, totalDay, setOption, 1, out msg);
            msg = "";
            return 0;
            // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<
        }

		#endregion

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

        /// <summary>
        /// �����t�H�[�J�X�Z�b�g
        /// </summary>
        public void SetFocus()
        {
            TotalDay_tNedit.Focus();
        }

        /// <summary>
        /// ��ʃN���A
        /// </summary>
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

            ClearEmployee();

            ChangeEnableCustomer(false);

            Target_uOptionSet.CheckedIndex = 0;

            LastDay_CheckEditor.Checked = false;

            tDateEdit1.Clear();
            tDateEdit1.SetDateTime(DateTime.Now);
        }

        /// <summary>
        /// �d������͉ې���
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
        /// �d������擾
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetCustomerInf(object sender, EventArgs e)
        {
//            SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY, SFTOK01370UA.EXECUTEMODE_GUIDE_AND_EDIT);
            _pushBtn = (UltraButton)sender;
            SFTOK01370UA customerSearchForm = new SFTOK01370UA(SFTOK01370UA.SEARCHMODE_SUPPLIER, SFTOK01370UA.EXECUTEMODE_GUIDE_ONLY);

            customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
            customerSearchForm.ShowDialog(this);
        }

        /// <summary>
        /// �d����I���������C�x���g
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="customerSearchRet">�d����ԗ������߂�l�N���X</param>
        private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
        {
            if (customerSearchRet == null) return;

            CustomerInfo customerInfo;
            CustSuppli custSuppli;
//            int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo);
            int status = this._customerInfoAcs.ReadDBDataWithCustSuppli(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode, customerSearchRet.CustomerCode, true, out customerInfo, out custSuppli);            
  
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
                    "�I�������d����͊��ɍ폜����Ă��܂��B",
                    status,
                    MessageBoxButtons.OK);

                return;
            }
            else if (customerInfo.SupplierDiv != 1)
            {
                TMsgDisp.Show(
                    this,
                    emErrorLevel.ERR_LEVEL_EXCLAMATION,
                    this.Name,
                    "�I���������Ӑ���́A�d����ɐݒ肳��Ă��܂���B",
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
                    "�d������̎擾�Ɏ��s���܂����B",
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
            int setDay = TotalDay_tNedit.GetInt();
            if (setDay != 0)
            {
                // �x�����ύX����
                ChangeDate(setDay);
            }
        }

        /// <summary>
        /// �x�����ύX
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
            DateTime setDate = new DateTime(year,month,day);
            tDateEdit1.SetDateTime(setDate);
        }

        /// <summary>
        /// �����擾
        /// </summary>
        /// <param name="targetDay"></param>
        /// <returns></returns>
        private int SetMaxDay(int year,int month)
        {
            int totalday = DateTime.Today.Day;

            // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
            //switch (month)
            //{
            //    case 1:
            //    case 3:
            //    case 5:
            //    case 7:
            //    case 8:
            //    case 10:
            //    case 12:
            //        {
            //            totalday = 31;
            //            break;
            //        }
            //    case 2:
            //        if (DateTime.IsLeapYear(year))
            //        {
            //            totalday = 29;
            //        }
            //        else
            //        {
            //            totalday = 28;
            //        }
            //        break;
            //    case 4:
            //    case 6:
            //    case 9:
            //    case 11:
            //        {
            //            totalday = 30;
            //            break;
            //        }
            //}
            try
            {
                totalday = DateTime.DaysInMonth(year, month);
            }
            catch
            {
                totalday = DateTime.Today.Day;
            }
            // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<

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
                                "�������قȂ�d����ł�",
                                status,
                                MessageBoxButtons.OK);

                            //Object���擾
                            TNedit errNedit = new TNedit();
                            errNedit = (TNedit)sender;

                            errNedit.Focus();

                            return;
                        }
                    }
                    if (customerInfo.SupplierDiv != 1)
                    {
                        TMsgDisp.Show(
                            this,
                            emErrorLevel.ERR_LEVEL_EXCLAMATION,
                            this.Name,
                            "�I���������Ӑ���́A�d����ɐݒ肳��Ă��܂���B",
                            status,
                            MessageBoxButtons.OK);
                        ((TNedit)sender).Focus();
                        return;
                    }


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
                        "�Y������d����͂���܂���B",
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
                SetLastDay();
            }
        }

        /// <summary>
        /// �������Z�b�g
        /// </summary>
        private void SetLastDay()
        {
            DateTime datetime = tDateEdit1.GetDateTime();
//            string sEndDate = DateTime.Parse(datetime.AddMonths(1).ToString("yyyy/MM/01")).AddDays(-1).ToShortDateString();
            datetime = DateTime.Parse(datetime.AddMonths(1).ToString("yyyy/MM/01")).AddDays(-1);
            tDateEdit1.SetDateTime(datetime);
        }
            --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
    }
}