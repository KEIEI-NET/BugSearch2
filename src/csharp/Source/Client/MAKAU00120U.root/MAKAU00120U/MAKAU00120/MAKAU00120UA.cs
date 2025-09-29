using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Infragistics.Win.UltraWinTabControl;

using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Infragistics.Win;
using System.Reflection;
using System.IO;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �����쐬���C���t���[��
	/// </summary>
	/// <remarks>
	/// <br>Note       : ������������/��������X�V�̊e�q��ʂ𐧌䂷�郁�C���t���[���ł��B</br>
	/// <br>Programer  : 19077 �n糋M�T</br>
	/// <br>Date       : 2007.03.07</br>
    /// <br>Update Note: 2008/08/08 30414 �E �K�j Partsman�p�ɕύX</br>
	/// </remarks>
	public partial class MAKAU00120UA : Form
	{
		//----------------------------------------------------------------------------------------------------
		//  �R���X�g���N�^
		//----------------------------------------------------------------------------------------------------
		# region �R���X�g���N�^
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public MAKAU00120UA()
		{
			InitializeComponent();

            /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
            if (Program.Param[0] == "1")
            {
                //�����X�V����
                MAKAU00128UA.GetSection += new MAKAU00128UA.GetSectionEventHandler(this.GetSection);
            }
            else if (Program.Param[0] == "2")
            {
                //������������
                MAKAU00129UA.GetSection += new MAKAU00129UA.GetSectionEventHandler(this.GetSection);
            }
            
            // ���ԍ݌ɃN���X������
            this._custDmdPrcAcs = new CustDmdPrcAcs();
               --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        }
		# endregion

		//----------------------------------------------------------------------------------------------------
		//  �v���C�x�C�g�����o
		//----------------------------------------------------------------------------------------------------
		# region �v���C�x�C�g�����o

        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
        /// ���ԍ݌Ƀf�[�^�A�N�Z�X�N���X
        private CustDmdPrcAcs _custDmdPrcAcs = null;
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        
        /// <summary>��ƃR�[�h</summary>
		private string _enterpriseCode;

        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
		/// <summary>�����_�R�[�h</summary>
		private string _ownSectionCode;
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/

        private Employee _employee;

        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
		/// <summary>���_�I�v�V�����L���t���O</summary>
		private bool _optSection = false;
        
        /// <summary>�\�����[�h</summary>
		private int _dispMode;
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/

        /// <summary>�X���C�_�[�p�l���N���X(Form�^)</summary>
		private SFCMN00221UA _superSlider;
		/// <summary>�q��ʐ���N���X</summary>
		private FormControlInfo _formControlInfo;

        private MAKAU00128UA _makau00128UA = new MAKAU00128UA();

        private MAKAU00129UA _makau00129UA = new MAKAU00129UA();
		# endregion

		//----------------------------------------------------------------------------------------------------
		//  �萔�錾
		//----------------------------------------------------------------------------------------------------
		# region �萔�錾
		/// <summary>�擪�^�uKEY����</summary>
		private const string NO0_TOP_TAB = "TOP_TAB";
		/// <summary>�^�u�Ȃ�</summary>
		private const string NO_TAB = "";
		/// <summary>PGID</summary>
		private const string ctPGID = "MAZAI04370U";
		# endregion

        /// <summary>
        /// �S���҃��X�g�擾
        /// </summary>
        /// <returns></returns>
        public Employee GetEmployee()
        {
            return _employee;
        }

        #region DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// ���_�擾
        /// </summary>
        public string GetSection()
        {
            Infragistics.Win.UltraWinToolbars.ComboBoxTool cmbOwnSection = this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
            return (string)cmbOwnSection.Value;
        }
        public string GetSectionNm()
        {
            Infragistics.Win.UltraWinToolbars.ComboBoxTool cmbOwnSection = this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
            return (string)cmbOwnSection.SelectedItem.ToString();
        }
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        //----------------------------------------------------------------------------------------------------
		//  �R���g���[���C�x���g�n���h��
		//----------------------------------------------------------------------------------------------------
		# region �R���g���[���C�x���g�n���h��
		/// <summary>
		/// �t�H�[�����[�h�C�x���g�n���h��
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�������[�h���ꂽ���ɔ������܂�</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private void MAKAU00120UA_Load(object sender, EventArgs e)
		{
			try
			{
				if (LoginInfoAcquisition.EnterpriseCode != null)
				{
					this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
				}

                /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
				// ���_���̎擾
				SecInfoSet secInfoSet;
				SecInfoAcs secInfoAcs = new SecInfoAcs();
                
				// ���Џ��擾
				secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);

				// ���_�R���{�{�b�N�X�ɋ��_���X�g��ݒ肷��
				Infragistics.Win.ValueList secInfoList = new Infragistics.Win.ValueList();
				foreach (SecInfoSet secInfoSetWk in secInfoAcs.SecInfoSetList)
				{
					Infragistics.Win.ValueListItem secInfoItem = new Infragistics.Win.ValueListItem();
					secInfoItem.DataValue = secInfoSetWk.SectionCode;
					secInfoItem.DisplayText = secInfoSetWk.SectionGuideNm;
					secInfoList.ValueListItems.Add(secInfoItem);
				}
				((Infragistics.Win.UltraWinToolbars.ComboBoxTool)ToolbarsManager_Main.Tools["ComboBoxTool_Section"]).ValueList = secInfoList;

				// �{�Ћ@�\����or���_�I�v�V���������Ȃ狒�_��ύX�ł��Ȃ��悤�ɂ���
				this._optSection = !((secInfoAcs.GetMainOfficeFuncFlag(secInfoSet.SectionCode) == 0) || (LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) <= 0));
				this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = this._optSection;
                   --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
                
                // �c�[���o�[�̗L�������ݒ�
				this.ToolbarEnableChange(0);

                // �c�[���o�[�̐ݒ�
                this.SettingToolbar();

                // ������L���E����
                if (Program.Param[0] == "1")
                {
                    //������������
                }
                else if (Program.Param[0] == "2")
                {
                    //������������ (����������)
                    ToolbarsManager_Main.Tools["ButtonTool_Bns"].SharedProps.Enabled = false;
                    ToolbarsManager_Main.Tools["ButtonTool_Bns"].SharedProps.Visible = false;
                }

                /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
                CustDmdPrcAcs CustDmdPrcAcs = new CustDmdPrcAcs();

                string sectionCode = "";
                Infragistics.Win.UltraWinToolbars.ComboBoxTool cmbOwnSection = (Infragistics.Win.UltraWinToolbars.ComboBoxTool)ToolbarsManager_Main.Tools["ComboBoxTool_Section"];
                if (cmbOwnSection.Value is string)
                {
                    sectionCode = (string)cmbOwnSection.Value;
                }

                // �����_����ݒ肷��
                cmbOwnSection.Value = secInfoSet.SectionCode;
                this._ownSectionCode = secInfoSet.SectionCode;
                // ���_����\������
                this.ShowToolBarSection();
                   --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/

                // �t�H�[������e�[�u���𐶐�����
				this.FormControlInfoCreate("");

				// �擪�^�u����
				this.TabCreate(NO0_TOP_TAB);

                /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
				// �擪�^�u�A�N�e�B�u��
				this.TabActivatedProc(this.TabControl_Main.SelectedTab.Tag as Form);

				// ��ʂɕ\���������e�������l�ɂ���
				this.StoreTabChild();
                   --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/

                if (_formControlInfo != null)
                {
                    if (Program.Param[0] == "1")
                    {
                        MAKAU00128UA makau00128UA = new MAKAU00128UA();
                        makau00128UA = (MAKAU00128UA)_formControlInfo.Form;
                        //                    makau00128UA.Section_tNedit.Text = GetSectionNm();

                        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
                        makau00128UA.Section_tEdit.Text = GetSectionNm();
                        makau00128UA._sectionCd = GetSection();
                           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/

                        makau00128UA.SetFocus();
                    }
                    else if (Program.Param[0] == "2")
                    {
                        MAKAU00129UA makau00129UA = new MAKAU00129UA();
                        makau00129UA = (MAKAU00129UA)_formControlInfo.Form;

                        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
                        makau00129UA.Section_tEdit.Text = GetSectionNm();
                        makau00129UA._sectionCd = GetSection();

                        makau00129UA.SetFocus();
                           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
                    }
                }
			}
			finally
			{
				// �N���p�X�v���b�V���E�B���h�E(Close)
				Program.SplashWindow.Close();
			}
		}

		/// <summary>
		/// �t�H�[��Close�O�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�����I������O�ɔ������܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private void MAKAU00120UA_FormClosing(object sender, FormClosingEventArgs e)
		{
			// TAB�q��ʂ��W�J����Ă��Ȃ���exit
			if (this.TabControl_Main.Tabs.Count <= 0) return;

            /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
			// �ҏW��ʂ̓��e��Static�̈�ɃX�g�A����
			this.StoreTabChild();
               --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
            
            // �X���C�_�[�����
			if (_superSlider != null) _superSlider.ClosePanel();
		}

		/// <summary>
		/// �c�[���o�[�N���b�N�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �c�[���o�[���N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private void ToolbarsManager_Main_ToolClick(object sender, ToolClickEventArgs e)
		{
            if (Program.Param[0] == "1")
            {
                MAKAU00128UA makau00128UA = new MAKAU00128UA();
                makau00128UA = (MAKAU00128UA)_formControlInfo.Form;
            
                int status = 0;
	    		switch (e.Tool.Key)
	    		{
    				case "ButtonTool_Close":
    					//--------------------------------------------------------------
    					// �I���{�^��
    					//--------------------------------------------------------------
    					// ���C����ʂ̃N���[�Y
    					this.Close();
    					break;
    				case "ButtonTool_Save":
    					//--------------------------------------------------------------
    					// �ۑ��{�^��
    					//--------------------------------------------------------------
                        //�o�^
                        // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
                        //int chkSt = makau00128UA.CheckInput();
                        //if (chkSt == 0)
                        //{
                        //    status = makau00128UA.ExecuteSaveProc();
                        //}
                        //else
                        //{       
                        //    string msg = "";
                        //    if (chkSt == 1)
                        //    {
                        //        msg = "�����̎w��Ɍ�肪����܂��B";
                        //    }
                        //    else if (chkSt == 2)
                        //    {
                        //        msg = "���Ӑ悪�w�肳��Ă��܂���B";
                        //    }

                        //    else if (chkSt == 3)
                        //    {
                        //        msg = "���Ӑ悪�d�����Ă��܂��B";
                        //    }
                        //    else if (chkSt == 4)
                        //    {
                        //        msg = "�����X�V�N�����̎w��Ɍ�肪����܂��B";
                        //    }
                               
                        //    TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.PGID, msg, 0, MessageBoxButtons.OK);
                        //}
                        status = makau00128UA.ExecuteSaveProc();
                        // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<

//                        MessageBox.Show(status.ToString());
                        break;
                    case "ButtonTool_Bns":
                        //--------------------------------------------------------------
                        // ������{�^��
                        //--------------------------------------------------------------
                        status = makau00128UA.ExecuteDelProc();
                        // ���b�Z�[�W�͏o�͍ς�
                        break;

    				case "ButtonTool_New":
	    				//--------------------------------------------------------------
		    			// �V�K�{�^��
			    		//--------------------------------------------------------------
				    	// �V�K����
					    this.NewEditTabChild(true);
                        makau00128UA.DispClear();
                        makau00128UA.SetFocus();
    					break;
                }			
			}else if (Program.Param[0] == "2")
            {
                ////������������
                //MAKAU00129UA makau00129UA = new MAKAU00129UA();
                //makau00129UA = (MAKAU00129UA)_formControlInfo.Form;
                
                //int status = 0;
                //switch (e.Tool.Key)
                //{
                //    case "ButtonTool_Close":
                //        //--------------------------------------------------------------
                //        // �I���{�^��
                //        //--------------------------------------------------------------
                //        // ���C����ʂ̃N���[�Y
                //        this.Close();
                //        break;
                //    case "ButtonTool_Save":
                //        //--------------------------------------------------------------
                //        // �ۑ��{�^��
                //        //--------------------------------------------------------------
                //        //�o�^
                //        int chkSt = makau00129UA.CheckInput();
                //        if (chkSt == 0)
                //        {
                //            status = makau00129UA.ExecuteSaveProc();
                //        }
                //        else
                //        {
                //            string msg = "";
                //            if (chkSt == 1)
                //            {
                //                msg = "�����̎w��Ɍ�肪����܂��B";
                //            }
                //            else if (chkSt == 2)
                //            {
                //                msg = "���Ӑ悪�w�肳��Ă��܂���B";
                //            }
                //            else if (chkSt == 3)
                //            {
                //                msg = "���Ӑ悪�d�����Ă��܂��B";
                //            }
                //            else if (chkSt == 4)
                //            {
                //                msg = "���������N�����̎w��Ɍ�肪����܂��B";
                //            }

                //            TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.PGID, msg, 0, MessageBoxButtons.OK);
                //        }
                        
                //        break;
                //    case "ButtonTool_Bns":
                //        //--------------------------------------------------------------
                //        // ������{�^��
                //        //--------------------------------------------------------------
                //        status = makau00129UA.ExecuteDelProc();
                //        break;

                //    case "ButtonTool_New":
                //        //--------------------------------------------------------------
                //        // �V�K�{�^��
                //        //--------------------------------------------------------------
                //        // �V�K����
                //        this.NewEditTabChild(true);
                //        makau00129UA.DispClear();
                //        makau00129UA.SetFocus();

                //        break;
                //}				
			}
        }

        #region DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �c�[���o�[�l�ύX���C�x���g�n���h��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ToolbarsManager_Main_ToolValueChanged(object sender, Infragistics.Win.UltraWinToolbars.ToolEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "ComboBoxTool_Section":
					//--------------------------------------------------------------
					// ���͋��_��ύX����
					//--------------------------------------------------------------
					Infragistics.Win.UltraWinToolbars.ComboBoxTool cmbOwnSection = this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"] as Infragistics.Win.UltraWinToolbars.ComboBoxTool;
					if (cmbOwnSection.Value is string)
					{

						// �I���������_�R�[�h���擾����
						string sectionCode = (string)cmbOwnSection.Value;			// ���_�R�[�h

                        if (_formControlInfo != null)
                        {
                            if (Program.Param[0] == "1")
                            {
                                MAKAU00128UA makau00128UA = new MAKAU00128UA();
                                makau00128UA = (MAKAU00128UA)_formControlInfo.Form;
                                //                            makau00128UA.Section_tNedit.Text = GetSectionNm();
                                makau00128UA.Section_tEdit.Text = GetSectionNm();
                                makau00128UA._sectionCd = GetSection();

                            }
                            else if (Program.Param[0] == "2")
                            {
                                MAKAU00129UA makau00129UA = new MAKAU00129UA();
                                makau00129UA = (MAKAU00129UA)_formControlInfo.Form;
                                //                            makau00128UA.Section_tNedit.Text = GetSectionNm();
                                makau00129UA.Section_tEdit.Text = GetSectionNm();
                                makau00129UA._sectionCd = GetSection();
                            }

                            // ���_����\������
                            this.ShowToolBarSection();
                        }
		
					}
					break;
			}
		}

        /// <summary>
		/// �o�[�R�[�h�ǂݎ��C�x���g�n���h��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tBarcodeReader1_BarcodeReaded(object sender, BarcodeReadedEventArgs e)
		{
		}
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        
        # endregion

        //----------------------------------------------------------------------------------------------------
		//  �v���C�x�[�g���\�b�h
		//----------------------------------------------------------------------------------------------------
		# region �v���C�x�[�g���\�b�h
		/// <summary>
		/// �V�K�쐬����
		/// </summary>
		/// <param name="comparer">�ҏW���`�F�b�N�L��</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note       : �V�K�{�^���������ꂽ���ɔ������āA�S�f�[�^�����������܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private int NewEditTabChild(bool comparer)
		{
			// �^�u�q��ʂ��W�J����Ă��Ȃ���exit
			if (this.TabControl_Main.Tabs.Count <= 0) return -1;

			// ���݂̃J�[�\����ޔ�����
			Cursor bufCursor = this.Cursor;
			try
			{
				// �J�[�\�����wWait�x�ɂ���
				this.Cursor = Cursors.WaitCursor;

                /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
				// �q��ʂɑ΂��čĕ\�������s������
				this.ShowTabChild();
                   --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
                
                //��������������������������������������������������������������������������
				// ��ʌn�̏��������s��
				//��������������������������������������������������������������������������
				try
				{
                    /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
					// ���_���\��
					this.ShowToolBarSection();
                       --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
                    
                    // �c�[���o�[����
					this.ToolbarEnableChange(0);
				}
				finally
				{
                    /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
					// ��ʂɕ\���������e�������l�ɂ���
					this.StoreTabChild();
                       --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
                }
			}
			finally // �}�E�X�J�[�\���ɑ΂���finally
			{
				// �}�E�X�J�[�\�������ɖ߂�
				this.Cursor = bufCursor;
			}

			return 0;
        }

        #region DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �q��ʂ̕ۑ�����
		/// </summary>
		/// <remarks>
		/// <br>Note       : �q��ʂɑ΂��āAStatic�ɕۑ������鏈�������s�����܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private int StoreTabChild()
		{
			int st = -1;

			if (_formControlInfo != null)
			{
			}

			return st;
		}

		/// <summary>
		/// �q��ʂ�Static����\��������
		/// </summary>
		/// <remarks>
		/// <br>Note       : �q��ʂɑ΂��āAStatic�ɕێ�����Ă���f�[�^��\������悤�ɗv�����܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private void ShowTabChild()
		{
			if (_formControlInfo != null)
			{
			}
		}
        
        /// <summary>
		/// �q��ʁi�ҏW��ʁj�̓��̓`�F�b�N����
		/// </summary>
		/// <returns>0=���̓G���[����,1=���̓G���[�L��</returns>
		/// <remarks>
		/// <br>Note       : MDI�t�H�[��(�ҏW��ʁj�̓��̓`�F�b�N����</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private int CheckEditTabChild()
		{
			if (_formControlInfo != null)
			{

			}

			return 0;
		}

        /// <summary>
		/// �^�u�A�N�e�B�u����
		/// </summary>
		/// <param name="form"></param>
		private void TabActivatedProc(Form form)
		{
			if (form != null)
			{
				if (this._formControlInfo == null) return;

				// �q��ʂ̕`���������
				this.RefreshTabChild(form);
			}
		}

		/// <summary>
		/// �^�u��A�N�e�B�u����
		/// </summary>
		/// <param name="form"></param>
		/// <returns></returns>
		private int TabDeactivattingProc(Form form)
		{
			if (form != null)
			{
			}

			return 0;
		}

		/// <summary>
		/// MDI�q��ʂ̍ĕ`��w���istatic�ȗ̈悩��f�[�^���擾���ĕ\���j
		/// </summary>
		/// <param name="form">MDI�q���(�ҏW���)</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : MDI�q��ʂ̍ĕ`��w���istatic�ȗ̈悩��f�[�^���擾���ĕ\���j</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private void RefreshTabChild(Form form)
		{
			if (form != null)
			{
			}
		}
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        
        # endregion

		//----------------------------------------------------------------------------------------------------
		//  �v���C�x�[�g���\�b�h(�^�u�\�z�֘A)
		//----------------------------------------------------------------------------------------------------
		# region �v���C�x�[�g���\�b�h(�^�u�\�z�֘A)
		/// <summary>
		/// �t�H�[���R���g���[���N���X�N���G�C�g����
		/// </summary>
		/// <param name="NexViewFormname">���ɕ\������t�H�[��</param>
		/// <remarks>
		/// <br>Note       : �t���[�����N������t�H�[���N���X�e�[�u���𐶐����܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private void FormControlInfoCreate(string NexViewFormname)
		{
			_formControlInfo = null;

            if (Program.Param[0] == "1")
            {
                _formControlInfo = new FormControlInfo(
                    NO0_TOP_TAB,
                    "MAKAU00128U",
                    "Broadleaf.Windows.Forms.MAKAU00128UA",
                    // --- CHG 2008/08/08 --------------------------------------------------------------------->>>>>
                    //"�����X�V����",
                    "��������X�V",
                    // --- CHG 2008/08/08 ---------------------------------------------------------------------<<<<<
                    IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS2],
                    NO_TAB,
                    NO_TAB);
            }
            else if (Program.Param[0] == "2")
            {
                _formControlInfo = new FormControlInfo(
                    NO0_TOP_TAB,
                    "MAKAU00129U",
                    "Broadleaf.Windows.Forms.MAKAU00129UA",
                    "������������",
                    IconResourceManagement.ImageList16.Images[(int)Size16_Index.DETAILS2],
                    NO_TAB,
                    NO_TAB);
            }
		}

		/// <summary>
		/// �^�u�N���G�C�g����
		/// </summary>
		/// <param name="key">�^�u�Ǘ��L�[</param>
		/// <remarks>
		/// <br>Note       : �t���[���̃^�u���N���G�C�g���܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private void TabCreate(string key)
		{
			Cursor localCursor = this.Cursor;
			try
			{
				this.Cursor = Cursors.WaitCursor;
				switch (key)
				{
					case NO0_TOP_TAB:
						// �擪��ʐ���
						if (_formControlInfo == null) return;

						this.CreateTabChildForm(_formControlInfo.AssemblyID, _formControlInfo.ClassID, _formControlInfo.Key, _formControlInfo.Name, _formControlInfo.Icon, _formControlInfo);
						break;
				}
			}
			finally
			{
				this.Cursor = localCursor;
			}
		}

		/// <summary>
		/// TAB�q��ʂ𐶐�����
		/// </summary>
		/// <param name="frmAssemblyName">�t�H�[���A�Z���u����</param>
		/// <param name="frmClassName">�t�H�[���N���X����</param>
		/// <param name="title">�\���^�C�g��</param>
		/// <param name="frmName">�t�H�[����</param>
		/// <param name="icon">�A�C�R���E�C���[�W</param>
		/// <param name="info">�t�H�[��������</param>
		/// <returns>none</returns>
		/// <remarks>
		/// <br>Note       : TAB�q��ʂ𐶐�����</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private Form CreateTabChildForm(string frmAssemblyName, string frmClassName, string frmName, string title, Image icon, FormControlInfo info)
		{
			Form form = null;
			form = (Form)this.LoadAssemblyFrom(frmAssemblyName, frmClassName, typeof(Form));

			if (form == null)
			{
			}
			else
			{
				// �t�H�[���v���p�e�B�ύX
				form.Name = frmName;

				// �^�u�y�[�W�R���g���[�����C���X�^���X
				UltraTabPageControl uTabPageControl = new UltraTabPageControl();

				// �^�u�̊O�ς�ݒ肵�A�^�u�R���g���[���Ƀ^�u��ǉ�����
				UltraTab uTab = new UltraTab();
				uTab.TabPage = uTabPageControl;
				uTab.Text = title;												// ����
				uTab.Key = frmName;												// Key
				uTab.Tag = form;												// �t�H�[���̃C���X�^���X
				uTab.Appearance.Image = icon;									// �A�C�R��
				uTab.Appearance.BackColor = Color.White;
				uTab.Appearance.BackColor2 = Color.Lavender;
				uTab.Appearance.BackGradientStyle = GradientStyle.Vertical;
            	uTab.ActiveAppearance.BackColor = Color.White;        		
				uTab.ActiveAppearance.BackColor2 = Color.LightPink;
				uTab.ActiveAppearance.BackGradientStyle = GradientStyle.Vertical;

				this.TabControl_Main.Controls.Add(uTabPageControl);
				this.TabControl_Main.Tabs.AddRange(new UltraTab[] { uTab });
				this.TabControl_Main.SelectedTab = uTab;

				form.TopLevel = false;
				form.FormBorderStyle = FormBorderStyle.None;

    			form.Show();

				uTabPageControl.Controls.Add(form);
				form.Dock = DockStyle.Fill;
			}

			info.Form = form;
			return form;
		}

		/// <summary>
		/// �w�肳�ꂽ�A�Z���u���y�уN���X�����A�N���X���C���X�^���X������
		/// </summary>
		/// <param name="asmname">�A�Z���u������</param>
		/// <param name="classname">�N���X����</param>
		/// <param name="type">��������N���X�^</param>
		/// <returns>�C���X�^���X�����ꂽ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �A�Z���u�������[�h���܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private object LoadAssemblyFrom(string asmname, string classname, Type type)
		{
			object obj = null;
			try
			{
				Assembly asm = Assembly.Load(asmname);
				Type objType = asm.GetType(classname);
				if (objType != null)
				{
					if ((objType == type) || (objType.IsSubclassOf(type) == true) || (objType.GetInterface(type.Name).Name == type.Name))
					{
						obj = Activator.CreateInstance(objType);
					}
				}
			}
			catch (FileNotFoundException ex)
			{
				// �ΏۃA�Z���u���Ȃ��i�x���j
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.PGID, ex.StackTrace, 0, MessageBoxButtons.OK);
			}
			catch (Exception ex)
			{
				// �ΏۃA�Z���u���Ȃ��i�x��)
				string _msg = "Message=" + ex.Message + "\r\n" + "Trace  =" + ex.StackTrace + "\r\n" + "Source =" + ex.Source;
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, Program.PGID, _msg, 0, MessageBoxButtons.OK);
			}
			return obj;
		}
		# endregion

		//----------------------------------------------------------------------------------------------------
		//  �v���C�x�[�g���\�b�h(��ʐݒ�֘A)
		//----------------------------------------------------------------------------------------------------
		# region �v���C�x�[�g���\�b�h(��ʐݒ�֘A)

        #region DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
		/// <summary>
		/// �c�[���o�[���_�\������
		/// </summary>
		private void ShowToolBarSection()
		{
			// �v�㋒�_���̂�\��
			SecInfoAcs secInfoAcs = new SecInfoAcs();	// ���_���擾�A�N�Z�X�N���X
        }
        
		/// <summary>
		/// ��ʕ\�����[�h�ݒ菈��
		/// </summary>
		/// <param name="dispMode">�\�����[�h</param>
		private void SettingDispMode(int dispMode)
		{
			this._dispMode = dispMode;

//            switch (dispMode)
//            {
//                case (int)ChildFormDispMode.Normal:
//                case (int)ChildFormDispMode.RefNormal:
////					this.DockManager_Main.Enabled = true;
//                    // ���_�ύX��
//                    this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = this._optSection;
//                    break;
//                case (int)ChildFormDispMode.ReadOnly:
////					this.DockManager_Main.Enabled = false;
//                    // ���_�ύX�s��
//                    this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = false;
//                    break;
//                case (int)ChildFormDispMode.RefNew:
////					this.DockManager_Main.Enabled = true;
//                    // ���_�ύX��
//                    this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = this._optSection;
//                    break;
//                case (int)ChildFormDispMode.RefRed:
////					this.DockManager_Main.Enabled = false;
//                    // ���_�ύX�s��
//                    this.ToolbarsManager_Main.Tools["ComboBoxTool_Section"].SharedProps.Enabled = false;
//                    break;
//            }

			// �X�e�[�^�X�o�[�\��
//			if (dispMode == (int)ChildFormDispMode.ReadOnly)
//			{
//				this.ultraStatusBar1.Panels["Text"].Text = "�ǂݎ���p";
//			}
//			else
//			{
//				this.ultraStatusBar1.Panels["Text"].Text = "";
//			}
		}
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g

        /// <summary>
		/// �c�[���o�[�̃A�C�R���ݒ�
		/// </summary>
		/// <remarks>
		/// <br>Note       : �t���[���̃c�[���o�[�̐ݒ���s���܂��B</br>
		/// <br>Programer  : 19077 �n糋M�T</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		private void SettingToolbar()
		{
			//--------------------------------------------------------------
			// ���C���c�[���o�[
			//--------------------------------------------------------------
			// �C���[�W���X�g��ݒ肷��
			this.ToolbarsManager_Main.ImageListSmall = IconResourceManagement.ImageList16;

			// ���_�̃A�C�R���ݒ�
			ToolbarsManager_Main.Tools["LabelTool_SectionTitle"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BASE;
			// ���O�C���S���҂̃A�C�R���ݒ�
			ToolbarsManager_Main.Tools["LabelTool_LoginNameTitle"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.EMPLOYEE;
			// �I���̃A�C�R���ݒ�
			ToolbarsManager_Main.Tools["ButtonTool_Close"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.CLOSE;
			// �ۑ��̃A�C�R���ݒ�
			ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.SAVE;
			// �V�K�̃A�C�R���ݒ�
			ToolbarsManager_Main.Tools["ButtonTool_New"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.NEW;
            // ���폜�̃A�C�R���ݒ�
            ToolbarsManager_Main.Tools["ButtonTool_Bns"].SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DELETE;
			// ���O�C����
			ToolBase LoginName = ToolbarsManager_Main.Tools["LabelTool_LoginName"];
			if (LoginName != null && LoginInfoAcquisition.Employee != null)
			{
				Employee employee = new Employee();
				employee = LoginInfoAcquisition.Employee;
				LoginName.SharedProps.Caption = employee.Name;
                this._employee = employee;
			}
		}

		/// <summary>
		/// �c�[���o�[�L�������ύX����
		/// </summary>
		/// <param name="mode">���[�h[0:�����\��, 1:�ďo��, 2:�ǂݎ���p]</param>
		private void ToolbarEnableChange(int mode)
		{
			switch (mode)
			{
				case 0:
					// �ۑ��{�^���L��
					ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
					// �폜�{�^������
//					ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
					break;
				case 1:
					// �ۑ��{�^���L��
					ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = true;
					// �폜�{�^���L��
//					ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = true;
					break;
				case 2:
					// �ۑ��{�^������
					ToolbarsManager_Main.Tools["ButtonTool_Save"].SharedProps.Enabled = false;
					// �폜�{�^������
//					ToolbarsManager_Main.Tools["ButtonTool_Delete"].SharedProps.Enabled = false;
					break;
			}
		}

		/// <summary>
		/// �h�b�L���O�E�B���h�E�ݒ�(�����X���C�_�[)
		/// </summary>
		private void SettingDockingWindow()
		{
			_superSlider = new SFCMN00221UA();
			Panel sldpanel = _superSlider.GetMainPanel(0, 13);

			sldpanel.Dock = DockStyle.Fill;
		}
		# endregion

        #region DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
        /* --- DEL 2008/08/08 --------------------------------------------------------------------->>>>>
        private void ultraTabSharedControlsPage1_Paint(object sender, PaintEventArgs e)
        {

        }
           --- DEL 2008/08/08 ---------------------------------------------------------------------<<<<<*/
        #endregion DEL 2008/08/08 �g�p���Ă��Ȃ��̂ŃR�����g�A�E�g
    }
}