using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �ʖڕW�ҏW���
	/// </summary>
	/// <remarks>
	/// <br>Note			 : �ʖڕW�̕ҏW���s����ʂł��B</br>
	/// <br>Programmer		 : NEPCO</br>
	/// <br>Date			 : 2007.05.21</br>
	/// <br>Update Note		 : 2007.11.21 ��� �O�M</br>
	/// <br>                   ����.DC�p�ɕύX�i���ڒǉ��E�폜�j</br>
	/// </remarks>
	public partial class MAMOK09190UB : Form
	{
		# region Private Constants

		// PG����
		private const string ctPGNM = "�ʖڕW�ҏW";

		# endregion Private Constants

		# region Private Members

		// ��ƃR�[�h
		private string _enterpriseCode;
		// ���_�R�[�h
		private string _sectionCode;
		// ���_��
		private string _sectionName;
		// �ڕW�f�[�^
		private SalesTarget _salesTarget;

		// �ڕW�}�X�^�A�N�Z�X�N���X
		private SalesTargetAcs _salesTargetAcs;

        /// <summary>��ʃf�U�C���ύX�N���X</summary>
        private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		# endregion Private Members

		# region Constructor

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public MAMOK09190UB()
		{
			InitializeComponent();

			// ��ƃR�[�h���擾
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// ���_���̎擾
			SecInfoSet secInfoSet;
			SecInfoAcs secInfoAcs = new SecInfoAcs();
			secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
			this._sectionCode = secInfoSet.SectionCode.TrimEnd();
			this._sectionName = secInfoSet.SectionGuideNm.TrimEnd();

			// �ڕW�}�X�^�A�N�Z�X�N���X������
			this._salesTargetAcs = new SalesTargetAcs();

			// �A�C�R���摜�̐ݒ�
			// �I���{�^��
			this.Close_Button.Appearance.Image
				= IconResourceManagement.ImageList24.Images[(int)Size24_Index.CLOSE];
			// �ۑ��{�^��
			this.Save_Button.Appearance.Image
				= IconResourceManagement.ImageList24.Images[(int)Size24_Index.SAVE];

		}

		# endregion Constructor

		# region Public Propaties

		/// public propaty name  :	SalesTarget
		/// <summary>�ڕW�f�[�^�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �ڕW�f�[�^�v���p�e�B</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public SalesTarget SalesTarget
		{
			get
			{
				return this._salesTarget;
			}
			set
			{
				this._salesTarget = value;
			}
		}

		# endregion Public Propaties

		# region Private Methods

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW�f�[�^��ʓW�J����
		/// </summary>
		/// <param name="salesTarget">�ڕW�f�[�^</param>
		/// <remarks>
		/// Note	   : �C���Ώۂ̖ڕW�f�[�^����ʂɓW�J���܂��B<br />
		/// Programmer : NEPCO<br />
		/// Date	   : 2007.04.03<br />
		/// </remarks>
		private void SalesTargetToScreen(SalesTarget salesTarget)
		{
			// �ڕW�ݒ�敪
			this.TargetSetCd_uOptionSet.Value = salesTarget.TargetSetCd;
			// ���_����
			this.SectionName_tEdit.DataText = this._sectionName;
			// �K�p���ԁi�J�n�j
			this.ApplyStaDate_tDateEdit.SetDateTime(salesTarget.ApplyStaDate);
			// �K�p���ԁi�I���j
			this.ApplyEndDate_tDateEdit.SetDateTime(salesTarget.ApplyEndDate);
			// �ڕW�敪�R�[�h
			this.TargetDivideCode_tEdit.DataText = salesTarget.TargetDivideCode;
			// �ڕW�敪����
			this.TargetDivideName_tEdit.DataText = salesTarget.TargetDivideName;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���̓f�[�^�`�F�b�N����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���̓f�[�^�̃`�F�b�N���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private bool CheckInputData()
		{
			string errMsg = "";

			try
			{
				// �K�p���ԁi�J�n�j
				if (this.ApplyStaDate_tDateEdit.GetDateYear() == 0 ||
					this.ApplyStaDate_tDateEdit.GetDateMonth() == 0 ||
					this.ApplyStaDate_tDateEdit.GetDateDay() == 0)
				{
                    errMsg = "���t�𐳂������͂��Ă�������";
					this.ApplyStaDate_tDateEdit.Focus();
					return (false);
				}
				try
				{
					DateTime dummyDateTime = new DateTime(
						this.ApplyStaDate_tDateEdit.GetDateYear(),
						this.ApplyStaDate_tDateEdit.GetDateMonth(),
						this.ApplyStaDate_tDateEdit.GetDateDay());
				}
				catch (ArgumentOutOfRangeException)
				{
					errMsg = "���t�𐳂������͂��Ă�������";
					this.ApplyStaDate_tDateEdit.Focus();
					return (false);
				}

                if (this.ApplyStaDate_tDateEdit.GetDateYear() < 1900)
                {
                    errMsg = "���t�𐳂������͂��Ă�������";
                    this.ApplyStaDate_tDateEdit.Focus();
                    return (false);
                }

				// �K�p���ԁi�I���j
				if (this.ApplyEndDate_tDateEdit.GetDateYear() == 0 ||
					this.ApplyEndDate_tDateEdit.GetDateMonth() == 0 ||
					this.ApplyEndDate_tDateEdit.GetDateDay() == 0)
				{
                    errMsg = "���t�𐳂������͂��Ă�������";
					this.ApplyEndDate_tDateEdit.Focus();
					return (false);
				}
				try
				{
					DateTime dummyDateTime = new DateTime(
						this.ApplyEndDate_tDateEdit.GetDateYear(),
						this.ApplyEndDate_tDateEdit.GetDateMonth(),
						this.ApplyEndDate_tDateEdit.GetDateDay());
				}
				catch (ArgumentOutOfRangeException)
				{
					errMsg = "���t�𐳂������͂��Ă�������";
					this.ApplyEndDate_tDateEdit.Focus();
					return (false);
				}

                if (this.ApplyEndDate_tDateEdit.GetDateYear() < 1900)
                {
                    errMsg = "���t�𐳂������͂��Ă�������";
                    this.ApplyEndDate_tDateEdit.Focus();
                    return (false);
                }

				if (this.ApplyStaDate_tDateEdit.GetDateTime() > this.ApplyEndDate_tDateEdit.GetDateTime())
				{
					errMsg = "�J�n�@<=  �I���Ŏw�肵�Ă�������";
					this.ApplyStaDate_tDateEdit.Focus();
					return (false);
				}
				// �ڕW�敪����
				if (this.TargetDivideName_tEdit.DataText == "")
				{
					errMsg = "�ڕW�敪���̂���͂��Ă�������";
					this.TargetDivideName_tEdit.Focus();
					return (false);
				}

			}
			finally
			{
				if (errMsg.Length > 0)
				{
					TMsgDisp.Show(
							this, 							// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_INFO, 	// �G���[���x��
							this.Name,						// �A�Z���u��ID
							errMsg, 						// �\�����郁�b�Z�[�W
							0,								// �X�e�[�^�X�l
							MessageBoxButtons.OK);			// �\������{�^��
				}
			}

			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �R���g���[���T�C�Y�ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �R���g���[���T�C�Y�̐ݒ���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private void SetControlSize()
		{
			this.TargetDivideCode_tEdit.Size = new Size(84, 24);
			this.TargetDivideName_tEdit.Size = new Size(290, 24);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �R���g���[�����͌����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �R���g���[���̓��͌����̐ݒ���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private void SetNumberOfControlChar()
		{
			this.TargetDivideCode_tEdit.MaxLength = 9;
			this.TargetDivideName_tEdit.MaxLength = 30;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW�f�[�^�ۑ�
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note		: �ڕW�ݒ�敪����іڕW�敪�R�[�h�������ڕW�f�[�^��ۑ����܂�</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private bool SaveTargetData()
		{
			DateTime applyStaDate;
			DateTime applyEndDate;
			string targetDivideName;
			bool retResult;

			// ��ʂ���f�[�^���擾
			GetScreenData(out applyStaDate, out applyEndDate, out targetDivideName);

			// �ڕW�f�[�^����
			List<List<SalesTarget>> salesTargetLists;
			retResult = SearchSalesTargetMain(out salesTargetLists);
			if (!retResult)
			{
				return (false);
			}

			// �ڕW�f�[�^�X�V
			List<SalesTarget> saveSalesTargetList;
			foreach (List<SalesTarget> salesTargetList in salesTargetLists)
			{
				saveSalesTargetList = new List<SalesTarget>();
				foreach (SalesTarget salesTarget in salesTargetList)
				{
					salesTarget.ApplyStaDate = applyStaDate;
					salesTarget.ApplyEndDate = applyEndDate;
					salesTarget.TargetDivideName = targetDivideName;

					saveSalesTargetList.Add(salesTarget);
				}
				retResult = UpdateSalesTarget(saveSalesTargetList);
				if (!retResult)
				{
					return (false);
				}
			}

			this._salesTarget.ApplyStaDate = applyStaDate;
			this._salesTarget.ApplyEndDate = applyEndDate;
			this._salesTarget.TargetDivideName = targetDivideName;

			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ��ʂ�����̓f�[�^���擾����
		/// </summary>
		/// <param name="applyStaDate">�K�p�J�n��</param>
		/// <param name="applyEndDate">�K�p�I����</param>
		/// <param name="targetDivideName">�ڕW�敪����</param>
		/// <remarks>
		/// <br>Note		: ��ʂ�����͂��ꂽ�f�[�^���擾���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private void GetScreenData(out DateTime applyStaDate, out DateTime applyEndDate, out string targetDivideName)
		{
			// �K�p���ԁi�J�n�j
			applyStaDate = this.ApplyStaDate_tDateEdit.GetDateTime();

			// �K�p���ԁi�I���j
			applyEndDate = this.ApplyEndDate_tDateEdit.GetDateTime();

			// �ڕW�敪����
			targetDivideName = this.TargetDivideName_tEdit.DataText;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW�f�[�^��������
		/// </summary>
		/// <param name="salesTargetLists">�ڕW�f�[�^���X�g</param>
		/// <remarks>
		/// <br>Note		: �ڕW�f�[�^���������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private bool SearchSalesTargetMain(out List<List<SalesTarget>> salesTargetLists)
		{
			ExtrInfo_MAMOK09197EA extrInfo;
			extrInfo = new ExtrInfo_MAMOK09197EA();

			// ��ƃR�[�h
			extrInfo.EnterpriseCode = this._enterpriseCode;
			// ���_�R�[�h
			extrInfo.SelectSectCd = new string[1];
			extrInfo.SelectSectCd[0] = this._sectionCode;
			// �ڕW�ݒ�敪
			extrInfo.TargetSetCd = (int)this.TargetSetCd_uOptionSet.Value;
			// �ڕW�敪�R�[�h
			extrInfo.TargetDivideCode = this.TargetDivideCode_tEdit.DataText;

			salesTargetLists = new List<List<SalesTarget>>();
			List<SalesTarget> salesTargetList;

			// ���_�ڕW����
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.Section;
			bool bStatus = SearchSalesTarget(out salesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}
			salesTargetLists.Add(salesTargetList);

			// �]�ƈ��ڕW����
			//----- ueno upd---------- start 2007.11.21
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndEmp;
			//----- ueno upd---------- end   2007.11.21
			bStatus = SearchSalesTarget(out salesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}
			salesTargetLists.Add(salesTargetList);

			// ���i�ڕW����
			//----- ueno upd---------- start 2007.11.21
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndMakerAndGoods;
			//----- ueno upd---------- end   2007.11.21
			bStatus = SearchSalesTarget(out salesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}
			salesTargetLists.Add(salesTargetList);

//----- ueno add---------- start 2007.11.21

			// ���Ӑ�ڕW����
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndCust;
			bStatus = SearchSalesTarget(out salesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}
			salesTargetLists.Add(salesTargetList);

//----- ueno add---------- end   2007.11.21

			//----- ueno del---------- start 2007.11.21
			//// ����`���ڕW����
			//extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesFormal;
			//bStatus = SearchSalesTarget(out salesTargetList, extrInfo);
			//if (!bStatus)
			//{
			//    return (false);
			//}
			//salesTargetLists.Add(salesTargetList);

			//// �̔��`�ԖڕW����
			//extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesForm;
			//bStatus = SearchSalesTarget(out salesTargetList, extrInfo);
			//if (!bStatus)
			//{
			//    return (false);
			//}
			//salesTargetLists.Add(salesTargetList);
			//----- ueno del---------- end   2007.11.21

			return (true);

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW�f�[�^�擾����
		/// </summary>
		/// <param name="salesTargetList">�ڕW�f�[�^���X�g</param>
		/// <param name="extrInfo">��������</param>
		/// <remarks>
		/// <br>Note		: �ڕW�f�[�^���擾���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.17</br>
		/// </remarks>
		private bool SearchSalesTarget(out List<SalesTarget> salesTargetList, ExtrInfo_MAMOK09197EA extrInfo)
		{
			int status = this._salesTargetAcs.Search(out salesTargetList, extrInfo, ConstantManagement.LogicalMode.GetData0);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
				case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
					break;
				default:
					TMsgDisp.Show(this, 						// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_STOP,			// �G���[���x��
						this.Name,								// �A�Z���u��ID
						ctPGNM, 			 �@�@				// �v���O��������
						"Search",								// ��������
						TMsgDisp.OPE_GET,						// �I�y���[�V����
						"�ڕW�f�[�^�̓ǂݍ��݂Ɏ��s���܂���",	// �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						this._salesTargetAcs,					// �G���[�����������I�u�W�F�N�g
						MessageBoxButtons.OK,					// �\������{�^��
						MessageBoxDefaultButton.Button1);		// �����\���{�^��
					return (false);
			}
			return (true);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW�f�[�^�X�V����
		/// </summary>
		/// <param name="saveSalesTargetList">�X�V�f�[�^</param>
		/// <remarks>
		/// <br>Note		: �ڕW�f�[�^���X�V���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private bool UpdateSalesTarget(List<SalesTarget> saveSalesTargetList)
		{
			string checkMessage;

			// �ڕW�f�[�^�X�V
			int status = this._salesTargetAcs.Write(ref saveSalesTargetList);
			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					break;
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_UPDATE:
                    checkMessage = "���ɑ��[�����X�V����Ă��܂�";
                    TMsgDisp.Show(
                        this,									// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	// �G���[���x��
                        this.Name,								// �A�Z���u��ID
                        checkMessage,							// �\�����郁�b�Z�[�W
                        status,									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��
                    return (false);
				case (int)ConstantManagement.DB_Status.ctDB_ALRDY_DELETE:
                    checkMessage = "���ɑ��[�����폜����Ă��܂�";
                    TMsgDisp.Show(
                        this, 						                // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	    // �G���[���x��
                        this.Name,								    // �A�Z���u��ID
                        checkMessage,		                        // �\�����郁�b�Z�[�W
                        status,									    // �X�e�[�^�X�l
                        MessageBoxButtons.OK);					    // �\������{�^��
                    return (false);
				default:
					checkMessage = "�ڕW�f�[�^�C�����ɃG���[���������܂���";
                    TMsgDisp.Show(
                        this, 						                // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOP,			    // �G���[���x��
                        this.Name,								    // �A�Z���u��ID
                        ctPGNM, 		  �@�@					    // �v���O��������
                        "UpdateSalesTarget",						            // ��������
                        TMsgDisp.OPE_UPDATE,					    // �I�y���[�V����
                        checkMessage,	                            // �\�����郁�b�Z�[�W
                        status,									    // �X�e�[�^�X�l
                        this._salesTargetAcs,					    // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,			  		    // �\������{�^��
                        MessageBoxDefaultButton.Button1);		    // �����\���{�^��
                    return (false);
			}

			return (true);

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �I���O����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ��ʂ̏I���O�ɏ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private bool BeforeClose()
		{
			bool retResult;
			DateTime applyStaDate;
			DateTime applyEndDate;
			string targetDivideName;

			// ��ʂ���f�[�^���擾
			GetScreenData(out applyStaDate, out applyEndDate, out targetDivideName);

			if (this._salesTarget.ApplyStaDate.Date != applyStaDate ||
				this._salesTarget.ApplyEndDate.Date != applyEndDate ||
				this._salesTarget.TargetDivideName != targetDivideName)
			{
				DialogResult res = TMsgDisp.Show(
							this, 								// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_SAVECONFIRM, // �G���[���x��
							this.Name,							// �A�Z���u��ID
							"", 								// �\�����郁�b�Z�[�W
							0,									// �X�e�[�^�X�l
							MessageBoxButtons.YesNoCancel);		// �\������{�^��
				switch (res)
				{
					case DialogResult.Yes:
						// �ۑ�
						retResult = SaveTargetData();
						if (!retResult)
						{
							return (false);
						}
						this.DialogResult = DialogResult.OK;
						return (true);
					case DialogResult.No:
						return (true);
					case DialogResult.Cancel:
						return (false);
				}
			}
			return (true);
		}

		# endregion Private Methods

		# region Control Events

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Form_Load �C�x���g����(MAMOK09190UB)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �t�H�[�����[�h�������s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private void MAMOK09190UB_Load(object sender, EventArgs e)
		{
            // ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
            this._controlScreenSkin.LoadSkin();

            // ��ʃX�L���ύX
            this._controlScreenSkin.SettingScreenSkin(this);

			this.SectionName_tEdit.DataText = this._sectionName;

			SetControlSize();
			SetNumberOfControlChar();

			// �ڕW�f�[�^��ʓW�J
			SalesTargetToScreen(this._salesTarget);

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click �C�x���g����(Save_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �ۑ��{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private void Save_Button_Click(object sender, EventArgs e)
		{
			// ���̓`�F�b�N
			bool retResult = CheckInputData();
			if (!retResult)
			{
				return;
			}

			// �ۑ�
			retResult = SaveTargetData();
			if (!retResult)
			{
				return;
			}

			this.DialogResult = DialogResult.OK;

			this.Close();

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click �C�x���g����(Close_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: ����{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.21</br>
		/// </remarks>
		private void Close_Button_Click(object sender, EventArgs e)
		{
			bool retResult = BeforeClose();
			if (!retResult)
			{
				return;
			}

			this.Close();
		}

		# endregion Control Events
	}
}