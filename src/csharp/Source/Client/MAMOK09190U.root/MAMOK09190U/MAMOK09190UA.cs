using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

using Infragistics.Win;
using Infragistics.Win.UltraWinToolbars;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �ڕW�����K�C�h���
	/// </summary>
	/// <remarks>
	/// <br>Note			 : �ڕW�������s���K�C�h��ʂł��B</br>
	/// <br>Programmer		 : NEPCO</br>
	/// <br>Date			 : 2007.04.23</br>
	/// <br>Update Note		 : 2007.11.21 ��� �O�M</br>
	/// <br>                   ����.DC�p�ɕύX�i���ڒǉ��E�폜�j</br>
	/// </remarks>
	public partial class MAMOK09190UA : Form
	{
		# region Private Constants

		// ��ʏ�ԕۑ��p�t�@�C����
		private const string XML_FILE_INITIAL_DATA = "MAMOK09190U.dat";

		// PG����
		private const string ctPGNM = "�ʊ��ԖڕW�K�C�h";

		private const string SALESTARGET = "SALESTARGET";

		private const string COL_SALESTARGET_APPLYMONTH = "applyMonth";
		private const string COL_SALESTARGET_APPLYSTADATE = "applyStaDate";
		private const string COL_SALESTARGET_APPLYENDDATE = "applyEndDate";
		private const string COL_SALESTARGET_TARGETDIVIDECODE = "targetDivideCode";
		private const string COL_SALESTARGET_TARGETDIVIDENAME = "targetDivideName";
		private const string COL_SALESTARGET_SECTION = "section";
		private const string COL_SALESTARGET_EMPLOYEE = "employee";
		private const string COL_SALESTARGET_GOODS = "goods";
//----- ueno add---------- start 2007.11.21
		private const string COL_SALESTARGET_CUSTOMER = "customer";
//----- ueno add---------- end   2007.11.21
		//----- ueno del---------- start 2007.11.21
		//private const string COL_SALESTARGET_SALESFORMAL = "salesFormal";
		//private const string COL_SALESTARGET_SALESFORM = "salesForm";
		//----- ueno del---------- end   2007.11.21
		private const string VIEW_SALESTARGET_APPLYMONTH = "�K�p��";
		private const string VIEW_SALESTARGET_APPLYSTADATE = "���ԁi�J�n�j";
		private const string VIEW_SALESTARGET_APPLYENDDATE = "���ԁi�I���j";
		private const string VIEW_SALESTARGET_TARGETDIVIDECODE = "�ڕW�敪�R�[�h";
		private const string VIEW_SALESTARGET_TARGETDIVIDENAME = "�ڕW�敪����";
		private const string VIEW_SALESTARGET_SECTION = "���_�ڕW";
		private const string VIEW_SALESTARGET_EMPLOYEE = "�]�ƈ��ڕW";
		private const string VIEW_SALESTARGET_GOODS = "���i�ڕW";
//----- ueno add---------- start 2007.11.21
		private const string VIEW_SALESTARGET_CUSTOMER = "���Ӑ�ڕW";
//----- ueno add---------- end   2007.11.21
		//----- ueno del---------- start 2007.11.21
		//private const string VIEW_SALESTARGET_SALESFORMAL = "����`���ڕW";
		//private const string VIEW_SALESTARGET_SALESFORM = "�̔��`�ԖڕW";
		//----- ueno del---------- end   2007.11.21
		private const int WIDTH_SALESTARGET_APPLYMONTH = 105;
		private const int WIDTH_SALESTARGET_APPLYSTADATE = 105;
		private const int WIDTH_SALESTARGET_APPLYENDDATE = 105;
		private const int WIDTH_SALESTARGET_TARGETDIVIDECODE = 118;
		private const int WIDTH_SALESTARGET_TARGETDIVIDENAME = 240;
		private const int WIDTH_SALESTARGET_SECTION = 95;
		private const int WIDTH_SALESTARGET_EMPLOYEE = 95;
		private const int WIDTH_SALESTARGET_GOODS = 95;
//----- ueno add---------- start 2007.11.21
		private const int WIDTH_SALESTARGET_CUSTOMER = 95;
//----- ueno add---------- end   2007.11.21
		//----- ueno del---------- start 2007.11.21
		//private const int WIDTH_SALESTARGET_SALESFORMAL = 105;
		//private const int WIDTH_SALESTARGET_SALESFORM = 105;
		//----- ueno del---------- end   2007.11.21

		# endregion Private Constants

		# region Private Members

		// ��ƃR�[�h
		private string _enterpriseCode;
		// ���_�R�[�h
		private string _sectionCode;

		private List<SalesTarget> _sectionSalesTargetList;
		private List<SalesTarget> _employeeSalesTargetList;
		private List<SalesTarget> _goodsSalesTargetList;
//----- ueno add---------- start 2007.11.21
		private List<SalesTarget> _customerSalesTargetList;
//----- ueno add---------- end   2007.11.21
		//----- ueno del---------- start 2007.11.21
		//private List<SalesTarget> _salesFormalSalesTargetList;
		//private List<SalesTarget> _salesFormSalesTargetList;
		//----- ueno del---------- end   2007.11.21

		// �ڕW�}�X�^�A�N�Z�X�N���X
		private SalesTargetAcs _salesTargetAcs;

		// �ڕW�ݒ�敪
		private int _targetSetCd;

		// �O���b�h�ݒ萧��N���X
		private GridStateController _gridStateController;

		// ���_�I���t���O
		private bool _selectedSectionFlg;

		/// <summary>��ʃf�U�C���ύX�N���X</summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		# endregion Private Members

		# region Constructor

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public MAMOK09190UA()
		{
			InitializeComponent();

			// ��ƃR�[�h���擾
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // ���_���擾
            SecInfoAcs secInfoAcs = new SecInfoAcs();
            SecInfoSet secInfoSet;
            secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
            this._sectionCode = secInfoSet.SectionCode.TrimEnd();

			this._gridStateController = new GridStateController();

			this._salesTargetAcs = new SalesTargetAcs();
			this._sectionSalesTargetList = new List<SalesTarget>();
			this._employeeSalesTargetList = new List<SalesTarget>();
			this._goodsSalesTargetList = new List<SalesTarget>();
//----- ueno add---------- start 2007.11.21
			this._customerSalesTargetList = new List<SalesTarget>();
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//this._salesFormalSalesTargetList = new List<SalesTarget>();
			//this._salesFormSalesTargetList = new List<SalesTarget>();
			//----- ueno del---------- end   2007.11.21

			// �c�[���o�[�ɃC���[�W���X�g��ݒ肷��
			Main_ToolbarsManager.ImageListSmall = IconResourceManagement.ImageList16;
			// �A�C�R���摜�̐ݒ�
			ButtonTool workButton;
			// �߂�{�^���̃A�C�R���ݒ�
			workButton = (ButtonTool)Main_ToolbarsManager.Tools["Return_ButtonTool"];
			if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.BEFORE;
			// �m��{�^���̃A�C�R���ݒ�
			workButton = (ButtonTool)Main_ToolbarsManager.Tools["Decision_ButtonTool"];
			if (workButton != null) workButton.SharedProps.AppearancesSmall.Appearance.Image = Size16_Index.DECISION;
			// �m��{�^���̐���
			if (workButton != null) workButton.SharedProps.Enabled = false;
			// �����{�^��
			this.Search_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.SEARCH];
		}

		# endregion Constructor

		# region Public Propaties

		/// public propaty name  :	TargetSetCd
		/// <summary>�ڕW�ݒ�敪�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �ڕW�ݒ�敪�v���p�e�B</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public int TargetSetCd
		{
			get
			{
				return this._targetSetCd;
			}
			set
			{
				this._targetSetCd = value;
			}
		}

		# endregion

		# region Public Methods

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �K�C�h�\������
		/// </summary>
		/// <param name="owner">�t�H�[��</param>
		/// <param name="salesTarget">�ڕW�f�[�^</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="selectedSectionFlag">���_�I���t���O</param>
		/// <remarks>
		/// <br>Note		: �ڕW�����K�C�h��ʂ�\�����A�I�������f�[�^��Ԃ��܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		public DialogResult ShowGuide(IWin32Window owner, out SalesTarget salesTarget, string[] sectionCode, bool selectedSectionFlag)
		{
			salesTarget = new SalesTarget();

            SecInfoAcs secInfoAcs = new SecInfoAcs();

            // ���_�R���{�{�b�N�X�ɋ��_���X�g��ݒ肷��
            if (sectionCode[0] == "0")
            {
                //
                // �S�БI���̎�
                //
                foreach (SecInfoSet secInfoSetWk in secInfoAcs.SecInfoSetList)
                {
                    this.SectionName_tComboEditor.Items.Add(secInfoSetWk.SectionCode.TrimEnd(), secInfoSetWk.SectionGuideNm.TrimEnd());
                }
            }
            else
            {
                for (int i = 0; i < sectionCode.Length; i++)
                {
                    foreach (SecInfoSet secInfoSetWk in secInfoAcs.SecInfoSetList)
                    {
                        if (sectionCode[i] == secInfoSetWk.SectionCode.TrimEnd())
                        {
                            this.SectionName_tComboEditor.Items.Add(secInfoSetWk.SectionCode.TrimEnd(), secInfoSetWk.SectionGuideNm.TrimEnd());
                            continue;
                        }
                    }
                }
                //this.SectionName_tComboEditor.Value = sectionCode[0];
            }
            this.SectionName_tComboEditor.SelectedIndex = 0;

			// ���_�I���t���O
			this._selectedSectionFlg = selectedSectionFlag;

			this.ShowDialog(owner);

			// �ڕW�f�[�^���ꌏ�������ꍇ
			if (this.SalesTarget_uGrid.ActiveRow == null)
			{
				this.DialogResult = DialogResult.Cancel;
			}

			if (this.DialogResult == DialogResult.OK)
			{
				string targetDate;
				int days;

				// ���ԖڕW
				if ((int)this.TargetSetCd_uOptionSet.Value == 10)
				{
					targetDate = this.SalesTarget_uGrid.ActiveRow.Cells[COL_SALESTARGET_APPLYMONTH].Value.ToString();
					// �J�n����
					salesTarget.ApplyStaDate = new DateTime(int.Parse(targetDate.Substring(0, 4)), int.Parse(targetDate.Substring(5, 2)), 1);
					// �I������
					days = DateTime.DaysInMonth(salesTarget.ApplyStaDate.Year, salesTarget.ApplyStaDate.Month);
					salesTarget.ApplyEndDate = new DateTime(salesTarget.ApplyStaDate.Year, salesTarget.ApplyStaDate.Month, days);
					salesTarget.TargetDivideName = "";
				}
				// �ʊ��ԖڕW
				else
				{
					// �J�n����
					salesTarget.ApplyStaDate = (DateTime)this.SalesTarget_uGrid.ActiveRow.Cells[COL_SALESTARGET_APPLYSTADATE].Value;
					// �I������
					salesTarget.ApplyEndDate = (DateTime)this.SalesTarget_uGrid.ActiveRow.Cells[COL_SALESTARGET_APPLYENDDATE].Value;
					// �ڕW�敪����
					salesTarget.TargetDivideName = (string)this.SalesTarget_uGrid.ActiveRow.Cells[COL_SALESTARGET_TARGETDIVIDENAME].Value;
				}

				// �ڕW�敪�R�[�h
				salesTarget.TargetDivideCode = (string)this.SalesTarget_uGrid.ActiveRow.Cells[COL_SALESTARGET_TARGETDIVIDECODE].Value;
				// �ڕW�ݒ�敪
				salesTarget.TargetSetCd = (int)this.TargetSetCd_uOptionSet.Value;
			}

			return (this.DialogResult);
		}

		# endregion Public Methods

		# region Private Methods

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �w�l�k�f�[�^�̕ۑ�����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ��ʏ�ԕێ��p�̂w�l�k�̕ۑ��������s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.27</br>
		/// </remarks>
		private void SaveStateXmlData()
		{
			// �O���b�h����ۑ�
			_gridStateController.SaveGridState(XML_FILE_INITIAL_DATA, ref this.SalesTarget_uGrid);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �w�l�k�f�[�^�̓Ǎ�����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ��ʏ�ԕێ��p�̂w�l�k�̓Ǎ��������s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.27</br>
		/// </remarks>
		private void LoadStateXmlData()
		{
			int status = _gridStateController.LoadGridState(XML_FILE_INITIAL_DATA, ref this.SalesTarget_uGrid);
			if (status == 0)
			{
				GridStateController.GridStateInfo gridStateInfo = _gridStateController.GetGridStateInfo(ref this.SalesTarget_uGrid);
				if (gridStateInfo != null)
				{
					// �t�H���g�T�C�Y
					this.cmbFontSize.Value = (int)gridStateInfo.FontSize;
					// ��̎�������
					this.uceAutoFitCol.Checked = gridStateInfo.AutoFit;
				}
				else
				{
					status = 4;
				}
			}
			if (status != 0)
			{
				// �t�H���g�T�C�Y
				this.cmbFontSize.Value = 10;
				// ��̎�������
				this.uceAutoFitCol.Checked = false;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW�f�[�^��������
		/// </summary>
		/// <param name="extrInfo">��������</param>
		/// <remarks>
		/// <br>Note		: �ڕW�f�[�^���������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.23</br>
		/// </remarks>
		private bool SearchSalesTarget(ExtrInfo_MAMOK09197EA extrInfo)
		{
			// ���_�ڕW����
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.Section;
			bool bStatus = SearchSalesTarget(out this._sectionSalesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}
			// �]�ƈ��ڕW����
			//----- ueno upd---------- start 2007.11.21
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndEmp;
			//----- ueno upd---------- end   2007.11.21
			bStatus = SearchSalesTarget(out this._employeeSalesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}

			// ���i�ڕW����
			//----- ueno upd---------- start 2007.11.21
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndMaker;
			//----- ueno upd---------- end   2007.11.21
			bStatus = SearchSalesTarget(out this._goodsSalesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}

//----- ueno add---------- start 2007.11.21
			// ���Ӑ�ڕW����
			extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SecAndCust;
			bStatus = SearchSalesTarget(out this._customerSalesTargetList, extrInfo);
			if (!bStatus)
			{
				return (false);
			}
//----- ueno add---------- end   2007.11.21

			//----- ueno del---------- start 2007.11.21
			//// ����`���ڕW����
			//extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesFormal;
			//bStatus = SearchSalesTarget(out this._salesFormalSalesTargetList, extrInfo);
			//if (!bStatus)
			//{
			//    return (false);
			//}
			//// �̔��`�ԖڕW����
			//extrInfo.TargetContrastCd = (int)SalesTarget.ConstrastCd.SalesForm;
			//bStatus = SearchSalesTarget(out this._salesFormSalesTargetList, extrInfo);
			//if (!bStatus)
			//{
			//    return (false);
			//}
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
		/// ���������ݒ菈��
		/// </summary>
		/// <param name="extrInfo">��������</param>
		/// <remarks>
		/// <br>Note		: ���������̐ݒ���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.17</br>
		/// </remarks>
		private void GetExtrInfo(out ExtrInfo_MAMOK09197EA extrInfo)
		{
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
			// �ڕW�敪����
			extrInfo.TargetDivideName = this.TargetDivideName_tEdit.DataText;

			if ((int)this.TargetSetCd_uOptionSet.Value == 10)
			{
				// ���ԖڕW
				extrInfo.ApplyStaDateSt = DateTime.MinValue;
				if (this.ApplyEndMonth_tDateEdit.GetDateYear() != 0 &&
					this.ApplyEndMonth_tDateEdit.GetDateMonth() != 0)
				{
					extrInfo.ApplyStaDateEd = new DateTime(this.ApplyEndMonth_tDateEdit.GetDateYear(), this.ApplyEndMonth_tDateEdit.GetDateMonth(), 1);
				}
				else
				{
					extrInfo.ApplyStaDateEd = DateTime.MinValue;
				}

				if (this.ApplyStaMonth_tDateEdit.GetDateYear() != 0 &&
					this.ApplyStaMonth_tDateEdit.GetDateMonth() != 0)
				{
					extrInfo.ApplyEndDateSt = new DateTime(this.ApplyStaMonth_tDateEdit.GetDateYear(), this.ApplyStaMonth_tDateEdit.GetDateMonth(), 1);
				}
				else
				{
					extrInfo.ApplyEndDateSt = DateTime.MinValue;
				}

				extrInfo.ApplyEndDateEd = DateTime.MinValue;
			}
			else
			{
				// �ʊ��ԖڕW
				extrInfo.ApplyStaDateSt = DateTime.MinValue;
				extrInfo.ApplyStaDateEd = this.ApplyEndDate_tDateEdit.GetDateTime();
				extrInfo.ApplyEndDateSt = this.ApplyStaDate_tDateEdit.GetDateTime();
				extrInfo.ApplyEndDateEd = DateTime.MinValue;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �O���b�h�\������
		/// </summary>
		/// <remarks>
		/// <br>Note		: �ݒ�ς݂̖ڕW�f�[�^���O���b�h�ɕ\�����܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		private void DispScreen()
		{
			this.SalesTarget_uGrid.DataSource = null;
			this.SalesTarget_uGrid.DataBind();

			// �e�[�u���̒�`
			DataTable dataTable = new DataTable(SALESTARGET);

			// ���ԖڕW
			if ((int)this.TargetSetCd_uOptionSet.Value == 10)
			{
				dataTable.Columns.Add(COL_SALESTARGET_APPLYMONTH, typeof(string));
				dataTable.Columns.Add(COL_SALESTARGET_TARGETDIVIDECODE, typeof(string));
			}
			// �ʊ��ԖڕW
			else
			{
				dataTable.Columns.Add(COL_SALESTARGET_APPLYSTADATE, typeof(DateTime));
				dataTable.Columns.Add(COL_SALESTARGET_APPLYENDDATE, typeof(DateTime));
				dataTable.Columns.Add(COL_SALESTARGET_TARGETDIVIDECODE, typeof(string));
				dataTable.Columns.Add(COL_SALESTARGET_TARGETDIVIDENAME, typeof(string));
			}
			dataTable.Columns.Add(COL_SALESTARGET_SECTION, typeof(string));
			dataTable.Columns.Add(COL_SALESTARGET_EMPLOYEE, typeof(string));
			dataTable.Columns.Add(COL_SALESTARGET_GOODS, typeof(string));
//----- ueno add---------- start 2007.11.21
			dataTable.Columns.Add(COL_SALESTARGET_CUSTOMER, typeof(string));
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//dataTable.Columns.Add(COL_SALESTARGET_SALESFORMAL, typeof(string));
			//dataTable.Columns.Add(COL_SALESTARGET_SALESFORM, typeof(string));
			//----- ueno del---------- end   2007.11.21

			//--------------------------------------------------------
			// �ڕW�敪�R�[�h���X�g�쐬
			//--------------------------------------------------------
			List<string> sectionDivideCodeList = new List<string>();
			List<string> employeeDivideCodeList = new List<string>();
			List<string> goodsDivideCodeList = new List<string>();
//----- ueno add---------- start 2007.11.21
			List<string> customerDivideCodeList = new List<string>();
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//List<string> salesFormalDivideCodeList = new List<string>();
			//List<string> salesFormDivideCodeList = new List<string>();
			//----- ueno del---------- end   2007.11.21

			// ���_�ڕW
			foreach (SalesTarget sectionSalesTarget in this._sectionSalesTargetList)
			{
				sectionDivideCodeList.Add(sectionSalesTarget.TargetDivideCode.TrimEnd());
			}
			// �]�ƈ��ڕW
			foreach (SalesTarget employeeSalesTarget in this._employeeSalesTargetList)
			{
				employeeDivideCodeList.Add(employeeSalesTarget.TargetDivideCode.TrimEnd());
			}
			// ���i�ڕW
			foreach (SalesTarget goodsSalesTarget in this._goodsSalesTargetList)
			{
				goodsDivideCodeList.Add(goodsSalesTarget.TargetDivideCode.TrimEnd());
			}
//----- ueno add---------- start 2007.11.21
			// ���Ӑ�ڕW
			foreach (SalesTarget customerSalesTarget in this._customerSalesTargetList)
			{
				customerDivideCodeList.Add(customerSalesTarget.TargetDivideCode.TrimEnd());
			}
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//// ����`���ڕW
			//foreach (SalesTarget salesFormalSalesTarget in this._salesFormalSalesTargetList)
			//{
			//    salesFormalDivideCodeList.Add(salesFormalSalesTarget.TargetDivideCode.TrimEnd());
			//}
			//// �̔��`�ԖڕW
			//foreach (SalesTarget salesFormSalesTarget in this._salesFormSalesTargetList)
			//{
			//    salesFormDivideCodeList.Add(salesFormSalesTarget.TargetDivideCode.TrimEnd());
			//}
			//----- ueno del---------- end   2007.11.21

			//--------------------------------------------------------
			// �ǉ����X�g�쐬
			//--------------------------------------------------------
			List<string> createdDivideCodeList = new List<string>();

			// ���_�ڕW
			AddSalesTargetTableData(this._sectionSalesTargetList, ref dataTable, ref createdDivideCodeList);
			// �]�ƈ��ڕW
			AddSalesTargetTableData(this._employeeSalesTargetList, ref dataTable, ref createdDivideCodeList);
			// ���i�ڕW
			AddSalesTargetTableData(this._goodsSalesTargetList, ref dataTable,ref createdDivideCodeList);
//----- ueno add---------- start 2007.11.21
			// ���Ӑ�ڕW
			AddSalesTargetTableData(this._customerSalesTargetList, ref dataTable, ref createdDivideCodeList);			
//----- ueno add---------- end   2007.11.21
			//----- ueno del---------- start 2007.11.21
			//// ����`���ڕW
			//AddSalesTargetTableData(this._salesFormalSalesTargetList, ref dataTable, ref createdDivideCodeList);
			//// �̔��`�ԖڕW
			//AddSalesTargetTableData(this._salesFormSalesTargetList, ref dataTable, ref createdDivideCodeList);
			//----- ueno del---------- end   2007.11.21

			// �ڕW�L���擾
			string targetDivideCode;
			foreach (DataRow dataRow in dataTable.Rows)
			{
				targetDivideCode = (string)dataRow[COL_SALESTARGET_TARGETDIVIDECODE];
				targetDivideCode = targetDivideCode.TrimEnd();

				// ���_�ڕW
				if (sectionDivideCodeList.Contains(targetDivideCode))
				{
					dataRow[COL_SALESTARGET_SECTION] = "�L";
				}
				// �]�ƈ��ڕW
				if (employeeDivideCodeList.Contains(targetDivideCode))
				{
					dataRow[COL_SALESTARGET_EMPLOYEE] = "�L";
				}
				// ���i�ڕW
				if (goodsDivideCodeList.Contains(targetDivideCode))
				{
					dataRow[COL_SALESTARGET_GOODS] = "�L";
				}
//----- ueno add---------- start 2007.11.21
				// ���Ӑ�ڕW
				if (customerDivideCodeList.Contains(targetDivideCode))
				{
					dataRow[COL_SALESTARGET_CUSTOMER] = "�L";
				}
//----- ueno add---------- end   2007.11.21
				//----- ueno del---------- start 2007.11.21
				//// ����`���ڕW
				//if (salesFormalDivideCodeList.Contains(targetDivideCode))
				//{
				//    dataRow[COL_SALESTARGET_SALESFORMAL] = "�L";
				//}
				//// �̔��`�ԖڕW
				//if (salesFormDivideCodeList.Contains(targetDivideCode))
				//{
				//    dataRow[COL_SALESTARGET_SALESFORM] = "�L";
				//}
				//----- ueno del---------- end   2007.11.21
			}

			if ((int)this.TargetSetCd_uOptionSet.Value == 10)
			{
				// ���ԖڕW
				dataTable.DefaultView.Sort = COL_SALESTARGET_APPLYMONTH + " DESC";
			}
			else
			{
				// �ʊ��ԖڕW
				dataTable.DefaultView.Sort = COL_SALESTARGET_APPLYSTADATE + " DESC";
			}

			this.SalesTarget_uGrid.DataSource = dataTable.DefaultView;
			this.SalesTarget_uGrid.DataBind();

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �e�[�u���f�[�^�ǉ�����
		/// </summary>
		/// <param name="salesTargetList">�ڕW�f�[�^���X�g</param>
		/// <param name="salesTargetTable">�f�[�^��ǉ�����e�[�u��</param>
		/// <param name="addedDivideCodeList">�ǉ��ςݖڕW�敪�R�[�h���X�g</param>
		/// <remarks>
		/// <br>Note		: �ڕW�e�[�u���Ƀf�[�^��ǉ����܂�</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.14</br>
		/// </remarks>
		private void AddSalesTargetTableData(
			List<SalesTarget> salesTargetList,
			ref DataTable salesTargetTable,
			ref List<string> addedDivideCodeList)
		{
			DataRow dataRow;

			foreach (SalesTarget salesTarget in salesTargetList)
			{
				if (addedDivideCodeList.Contains(salesTarget.TargetDivideCode.TrimEnd()))
				{
					// ���ɍ쐬�ς�
					continue;
				}

				// �쐬�ς݃��X�g�ɒǉ�
				addedDivideCodeList.Add(salesTarget.TargetDivideCode.TrimEnd());

				// �f�[�^�ݒ�
				dataRow = salesTargetTable.NewRow();

				// ���ԖڕW
				if ((int)this.TargetSetCd_uOptionSet.Value == 10)
				{
					dataRow[COL_SALESTARGET_APPLYMONTH] = salesTarget.ApplyStaDate.Year.ToString() + "�N" + salesTarget.ApplyStaDate.Month.ToString("00") + "��";
					dataRow[COL_SALESTARGET_TARGETDIVIDECODE] = salesTarget.TargetDivideCode;
				}
				// �ʊ��ԖڕW
				else
				{
					dataRow[COL_SALESTARGET_APPLYSTADATE] = salesTarget.ApplyStaDate;
					dataRow[COL_SALESTARGET_APPLYENDDATE] = salesTarget.ApplyEndDate;
					dataRow[COL_SALESTARGET_TARGETDIVIDECODE] = salesTarget.TargetDivideCode;
					dataRow[COL_SALESTARGET_TARGETDIVIDENAME] = salesTarget.TargetDivideName;
				}

				salesTargetTable.Rows.Add(dataRow);

			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �O���b�h���C�A�E�g�ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �O���b�h�̃��C�A�E�g�ݒ���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		private void InitializeLayout()
		{
			// ���ԖڕW
			if ((int)this.TargetSetCd_uOptionSet.Value == 10)
			{
				// �Ώی�
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYMONTH].Width = WIDTH_SALESTARGET_APPLYMONTH;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYMONTH].Header.Caption = VIEW_SALESTARGET_APPLYMONTH;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYMONTH].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYMONTH].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYMONTH].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYMONTH].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYMONTH].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYMONTH].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			}
			// �ʊ��ԖڕW
			else
			{
				// �K�p���ԁi�J�n�j
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYSTADATE].Width = WIDTH_SALESTARGET_APPLYSTADATE;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYSTADATE].Header.Caption = VIEW_SALESTARGET_APPLYSTADATE;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYSTADATE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYSTADATE].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYSTADATE].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYSTADATE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYSTADATE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYSTADATE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

				// �K�p���ԁi�I���j
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYENDDATE].Width = WIDTH_SALESTARGET_APPLYENDDATE;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYENDDATE].Header.Caption = VIEW_SALESTARGET_APPLYENDDATE;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYENDDATE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYENDDATE].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYENDDATE].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYENDDATE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYENDDATE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_APPLYENDDATE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

				// �ڕW�敪����
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDENAME].Width = WIDTH_SALESTARGET_TARGETDIVIDENAME;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDENAME].Header.Caption = VIEW_SALESTARGET_TARGETDIVIDENAME;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDENAME].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDENAME].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDENAME].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDENAME].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDENAME].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
				this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDENAME].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			}
			// �ڕW�敪�R�[�h
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDECODE].Width = WIDTH_SALESTARGET_TARGETDIVIDECODE;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDECODE].Header.Caption = VIEW_SALESTARGET_TARGETDIVIDECODE;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDECODE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDECODE].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDECODE].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDECODE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDECODE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Left;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_TARGETDIVIDECODE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

			// ���_�ڕW
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTION].Width = WIDTH_SALESTARGET_SECTION;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTION].Header.Caption = VIEW_SALESTARGET_SECTION;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTION].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTION].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTION].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTION].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTION].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SECTION].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

			// �]�ƈ��ڕW
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEE].Width = WIDTH_SALESTARGET_EMPLOYEE;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEE].Header.Caption = VIEW_SALESTARGET_EMPLOYEE;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEE].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEE].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEE].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEE].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEE].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_EMPLOYEE].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

			// ���i�ڕW
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODS].Width = WIDTH_SALESTARGET_GOODS;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODS].Header.Caption = VIEW_SALESTARGET_GOODS;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODS].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODS].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODS].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODS].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODS].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_GOODS].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

//----- ueno add---------- start 2007.11.21
			// ���Ӑ�ڕW
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMER].Width = WIDTH_SALESTARGET_CUSTOMER;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMER].Header.Caption = VIEW_SALESTARGET_CUSTOMER;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMER].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMER].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMER].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMER].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMER].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_CUSTOMER].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
//----- ueno add---------- end   2007.11.21

			//----- ueno del---------- start 2007.11.21
			//// ����`���ڕW
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].Width = WIDTH_SALESTARGET_SALESFORMAL;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].Header.Caption = VIEW_SALESTARGET_SALESFORMAL;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORMAL].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;

			//// �̔��`�ԖڕW
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].Width = WIDTH_SALESTARGET_SALESFORM;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].Header.Caption = VIEW_SALESTARGET_SALESFORM;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].Header.Appearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].Header.Appearance.FontData.Bold = DefaultableBoolean.True;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
			//this.SalesTarget_uGrid.DisplayLayout.Bands[0].Columns[COL_SALESTARGET_SALESFORM].CellAppearance.TextVAlign = Infragistics.Win.VAlign.Middle;
			//----- ueno del---------- end   2007.11.21
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���͓��t�`�F�b�N����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���͓��t�̃`�F�b�N���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.25</br>
		/// </remarks>
		private bool CheckInputDate()
		{
			string errMsg = "";

			try
			{
				// ���ԖڕW
				if ((int)this.TargetSetCd_uOptionSet.Value == 10)
				{
					// �K�p���i�J�n�j
					if (this.ApplyStaMonth_tDateEdit.GetDateYear() != 0 ||
						this.ApplyStaMonth_tDateEdit.GetDateMonth() != 0)
					{
						if (this.ApplyStaMonth_tDateEdit.GetDateYear() == 0 ||
							this.ApplyStaMonth_tDateEdit.GetDateMonth() == 0)
						{
							errMsg = "���t�𐳂������͂��Ă�������";
							this.ApplyStaMonth_tDateEdit.Focus();
							return (false);
						}
					}

					if (this.ApplyStaMonth_tDateEdit.GetDateYear() != 0 &&
						this.ApplyStaMonth_tDateEdit.GetDateMonth() != 0)
					{
						try
						{
							DateTime dummyDateTime = new DateTime(
								this.ApplyStaMonth_tDateEdit.GetDateYear(),
								this.ApplyStaMonth_tDateEdit.GetDateMonth(),
								1);
						}
						catch (ArgumentOutOfRangeException)
						{
							errMsg = "���t�𐳂������͂��Ă�������";
							this.ApplyStaMonth_tDateEdit.Focus();
							return (false);
						}
					}

					// �K�p��(�I��)
					if (this.ApplyEndMonth_tDateEdit.GetDateYear() != 0 ||
						this.ApplyEndMonth_tDateEdit.GetDateMonth() != 0)
					{
						if (this.ApplyEndMonth_tDateEdit.GetDateYear() == 0 ||
							this.ApplyEndMonth_tDateEdit.GetDateMonth() == 0)
						{
							errMsg = "���t�𐳂������͂��Ă�������";
							this.ApplyEndMonth_tDateEdit.Focus();
							return (false);
						}
					}

					if (this.ApplyEndMonth_tDateEdit.GetDateYear() != 0 &&
						this.ApplyEndMonth_tDateEdit.GetDateMonth() != 0)
					{
						try
						{
							DateTime dummyDateTime = new DateTime(
								this.ApplyEndMonth_tDateEdit.GetDateYear(),
								this.ApplyEndMonth_tDateEdit.GetDateMonth(),
								1);
						}
						catch (ArgumentOutOfRangeException)
						{
							errMsg = "���t�𐳂������͂��Ă�������";
							this.ApplyEndMonth_tDateEdit.Focus();
							return (false);
						}
					}

					if (this.ApplyStaDate_tDateEdit.GetLongDate() > this.ApplyEndDate_tDateEdit.GetLongDate())
					{
						errMsg = "�J�n�@<  �I���@�Ŏw�肵�Ă�������";
						this.ApplyStaDate_tDateEdit.Focus();
						return (false);
					}
				}
				// �ʊ��ԖڕW
				else
				{
					// �K�p���ԁi�J�n�j
					if (this.ApplyStaDate_tDateEdit.GetDateYear() != 0 ||
						this.ApplyStaDate_tDateEdit.GetDateMonth() != 0 ||
						this.ApplyStaDate_tDateEdit.GetDateDay() != 0)
					{
						if (this.ApplyStaDate_tDateEdit.GetDateYear() == 0 ||
							this.ApplyStaDate_tDateEdit.GetDateMonth() == 0 ||
							this.ApplyStaDate_tDateEdit.GetDateDay() == 0)
						{
							errMsg = "���t�𐳂������͂��Ă�������";
							this.ApplyStaDate_tDateEdit.Focus();
							return (false);
						}
					}

					if (this.ApplyStaDate_tDateEdit.GetDateYear() != 0 &&
						this.ApplyStaDate_tDateEdit.GetDateMonth() != 0 &&
						this.ApplyStaDate_tDateEdit.GetDateDay() != 0)
					{
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
					}

					// �K�p���ԁi�I���j
					if (this.ApplyEndDate_tDateEdit.GetDateYear() != 0 ||
						this.ApplyEndDate_tDateEdit.GetDateMonth() != 0 ||
						this.ApplyEndDate_tDateEdit.GetDateDay() != 0)
					{
						if (this.ApplyEndDate_tDateEdit.GetDateYear() == 0 ||
							this.ApplyEndDate_tDateEdit.GetDateMonth() == 0 ||
							this.ApplyEndDate_tDateEdit.GetDateDay() == 0)
						{
							errMsg = "���t�𐳂������͂��Ă�������";
							this.ApplyEndDate_tDateEdit.Focus();
							return (false);
						}
					}

					if (this.ApplyEndDate_tDateEdit.GetDateYear() != 0 &&
						this.ApplyEndDate_tDateEdit.GetDateMonth() != 0 &&
						this.ApplyEndDate_tDateEdit.GetDateDay() != 0)
					{
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
					}

					if (this.ApplyStaDate_tDateEdit.GetDateTime() != DateTime.MinValue &&
						this.ApplyEndMonth_tDateEdit.GetDateTime() != DateTime.MinValue)
					{
						if (this.ApplyStaDate_tDateEdit.GetLongDate() > this.ApplyEndDate_tDateEdit.GetLongDate())
						{
							errMsg = "�J�n�@<=  �I���@�Ŏw�肵�Ă�������";
							this.ApplyStaDate_tDateEdit.Focus();
							return (false);
						}
					}
				}
			}
			finally
			{
				if (errMsg.Length > 0)
				{
					TMsgDisp.Show(
							this, 									// �e�E�B���h�E�t�H�[��
							emErrorLevel.ERR_LEVEL_EXCLAMATION, 	// �G���[���x��
							this.Name,								// �A�Z���u��ID
							errMsg, 								// �\�����郁�b�Z�[�W
							0,										// �X�e�[�^�X�l
							MessageBoxButtons.OK);					// �\������{�^��
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
		/// <br>Date		: 2007.04.17</br>
		/// </remarks>
		private void SetControlSize()
		{
			this.TargetDivideName_tEdit.Size = new Size(306, 24);
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �R���g���[�����͌����ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �R���g���[���̓��͌����̐ݒ���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.17</br>
		/// </remarks>
		private void SetNumberOfControlChar()
		{
			this.TargetDivideName_tEdit.MaxLength = 30;
		}

		# endregion Private Methods

		# region Control Events

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Form_Load �C�x���g����(MAMOK09190UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �t�H�[�����[�h�������s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		private void MAMOK09190UA_Load(object sender, EventArgs e)
		{
			// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
			this._controlScreenSkin.LoadSkin();

			// ��ʃX�L���ύX
			this._controlScreenSkin.SettingScreenSkin(this);

			// ���t�̔w�i�F�ݒ�
			this.ApplyStaMonth_tDateEdit.BackColor = Color.FromArgb(220, 230, 230);
			this.ApplyEndMonth_tDateEdit.BackColor = Color.FromArgb(220, 230, 230);
			this.ApplyStaDate_tDateEdit.BackColor = Color.FromArgb(220, 230, 230);
			this.ApplyEndDate_tDateEdit.BackColor = Color.FromArgb(220, 230, 230);

			// �R���g���[���T�C�Y�ݒ�
			SetControlSize();

			// �R���g���[�����͌����ݒ�
			SetNumberOfControlChar();

			// �I�𒆋��_
			this.SectionName_tComboEditor.Value = this._sectionCode;
			// ���_�I���\
			if (this._selectedSectionFlg == true)
			{
				this.SectionName_tComboEditor.Enabled = true;
			}
			// ���_�I��s��
			else
			{
				this.SectionName_tComboEditor.Enabled = false;
			}

			this.TargetSetCd_uOptionSet.Value = this._targetSetCd;

			// XML�f�[�^�Ǎ�
			LoadStateXmlData();

			// �O���b�h�\��
			DispScreen();
			// �O���b�h�X�^�C���ݒ�
			InitializeLayout();

//----- ueno add---------- start 2007.11.21
			// ���ԖڕW
			if ((int)this.TargetSetCd_uOptionSet.Value == 10)
			{
				// �ڕW�敪���͓̂��͕s��
				this.TargetDivideName_tEdit.Enabled = false;
				this.TargetDivideName_tEdit.Clear();
			}
			// �ʊ��ԖڕW
			else
			{
				// �ڕW�敪���͓̂��͉�
				this.TargetDivideName_tEdit.Enabled = true;
			}
//----- ueno add---------- end   2007.11.21

		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click �C�x���g����(Search_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �����{�^�����N���b�N�������ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		private void Search_Button_Click(object sender, EventArgs e)
		{
			// ���̓`�F�b�N
			bool status = CheckInputDate();
			if (!status)
			{
				return;
			}

			// ���������擾
			ExtrInfo_MAMOK09197EA extrInfo;
			GetExtrInfo(out extrInfo);

			// �ڕW�f�[�^����
			status = SearchSalesTarget(extrInfo);
			if (!status)
			{
				return;
			}

			// �m��{�^��
			ButtonTool workButton = Main_ToolbarsManager.Tools["Decision_ButtonTool"] as ButtonTool;

			// �ڕW�f�[�^��1���������ꍇ
			if (this._sectionSalesTargetList.Count < 1 &&
				this._employeeSalesTargetList.Count < 1 &&
				this._goodsSalesTargetList.Count < 1 &&
//----- ueno add---------- start 2007.11.21
				this._customerSalesTargetList.Count < 1)			
//----- ueno add---------- start 2007.11.21
				//----- ueno del---------- start 2007.11.21
				//this._salesFormalSalesTargetList.Count < 1 &&
				//this._salesFormSalesTargetList.Count < 1)
				//----- ueno del---------- end   2007.11.21
			{
				if (workButton != null) workButton.SharedProps.Enabled = false;
			}
			// �ڕW�f�[�^������ꍇ
			else
			{
				if (workButton != null) workButton.SharedProps.Enabled = true;
			}

			// �O���b�h�\��
			DispScreen();
			// �O���b�h�X�^�C���ݒ�
			InitializeLayout();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ToolClick �C�x���g����(Main_ToolbarsManager)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �c�[���o�[�{�^�����N���b�N�������ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.27</br>
		/// </remarks>
		private void Main_ToolbarsManager_ToolClick(object sender, ToolClickEventArgs e)
		{
			switch (e.Tool.Key)
			{
				case "Return_ButtonTool":
					// XML�f�[�^�ۑ�
					SaveStateXmlData();
					this.DialogResult = DialogResult.Cancel;
					this.Close();
					break;
				case "Decision_ButtonTool":
					// XML�f�[�^�ۑ�
					SaveStateXmlData();
					this.DialogResult = DialogResult.OK;
					this.Close();
					break;
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ValueChanged �C�x���g����(SectionName_tComboEditor)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �h���b�v�_�E�����X�g�̑I�����ύX�������ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.08</br>
		/// </remarks>
		private void SectionName_tComboEditor_ValueChanged(object sender, EventArgs e)
		{
			this._sectionCode = (string)this.SectionName_tComboEditor.Value;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ValueChanged �C�x���g����(TargetSetCd_uOptionSet)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: ���W�I�{�^���̃`�F�b�N���ύX�������ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.23</br>
		/// </remarks>
		private void TargetSetCd_uOptionSet_ValueChanged(object sender, EventArgs e)
		{
			this.ApplyStaMonth_tDateEdit.SetDateTime(new DateTime());
			this.ApplyEndMonth_tDateEdit.SetDateTime(new DateTime());
			this.ApplyStaDate_tDateEdit.SetDateTime(new DateTime());
			this.ApplyEndDate_tDateEdit.SetDateTime(new DateTime());

			// ���ԖڕW
			if ((int)this.TargetSetCd_uOptionSet.Value == 10)
			{
				this.ApplyStaMonth_tDateEdit.Enabled = true;
				this.ApplyEndMonth_tDateEdit.Enabled = true;
				this.ApplyStaDate_tDateEdit.Enabled = false;
				this.ApplyEndDate_tDateEdit.Enabled = false;

//----- ueno add---------- start 2007.11.21
				// �ڕW�敪���͓̂��͕s��
				this.TargetDivideName_tEdit.Enabled = false;
				this.TargetDivideName_tEdit.Clear();
//----- ueno add---------- end   2007.11.21

			}
			// �ʊ��ԖڕW
			else
			{
				this.ApplyStaDate_tDateEdit.Enabled = true;
				this.ApplyEndDate_tDateEdit.Enabled = true;
				this.ApplyStaMonth_tDateEdit.Enabled = false;
				this.ApplyEndMonth_tDateEdit.Enabled = false;

//----- ueno add---------- start 2007.11.21
				// �ڕW�敪���͓̂��͉�
				this.TargetDivideName_tEdit.Enabled = true;
//----- ueno add---------- end   2007.11.21

			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// DoubleClickRow �C�x���g����(SalesTarget_uGrid)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �O���b�h�̍s���_�u���N���b�N�������ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		private void SalesTarget_uGrid_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �t�H���g�T�C�Y�ύX�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �t�H���g�T�C�Y�̒l���ύX���ꂽ��ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		private void cmbFontSize_ValueChanged(object sender, EventArgs e)
		{
			// �t�H���g�T�C�Y��ύX
			this.SalesTarget_uGrid.DisplayLayout.Appearance.FontData.SizeInPoints
				= (int)cmbFontSize.Value;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ��T�C�Y�̎��������`�F�b�N�`�F���W�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �`�F�b�N�{�b�N�X�̃`�F�b�N��Ԃ��ύX���ꂽ�^�C�~���O�Ŕ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.27</br>
		/// </remarks>
		private void uceAutoFitCol_CheckedChanged(object sender, EventArgs e)
		{
			if (this.SalesTarget_uGrid.DataSource != null)
			{
				if (this.uceAutoFitCol.Checked)
				{
					this.SalesTarget_uGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns;
				}
				else
				{
					this.SalesTarget_uGrid.DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.None;
					InitializeLayout();
				}
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// tArrowKeyControlChangeFocus�C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �R���g���[���̃t�H�[�J�X���ς��^�C�~���O�Ŕ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			int rowCount = this.SalesTarget_uGrid.Rows.Count;

			// Next�t�H�[�J�X���O���b�h�̏ꍇ
			if (e.NextCtrl == this.SalesTarget_uGrid)
			{
				if (this.SalesTarget_uGrid.Rows.Count > 0)
				{
					if (this.SalesTarget_uGrid.ActiveRow != null)
					{
						if (!this.SalesTarget_uGrid.ActiveRow.Selected)
						{
							this.SalesTarget_uGrid.ActiveRow.Selected = true;
						}
					}
					else
					{
						this.SalesTarget_uGrid.Rows[0].Activate();
						this.SalesTarget_uGrid.Rows[0].Selected = true;
					}
					return;
				}
				else
				{
					if (e.Key == Keys.Up)
					{
						e.NextCtrl = this.TargetSetCd_uOptionSet;
					}
					else if (e.Key == Keys.Down)
					{
						e.NextCtrl = this.cmbFontSize;
					}
					else if (e.Key == Keys.Tab || e.Key == Keys.Enter)
					{
						e.NextCtrl = this.cmbFontSize;
					}
				}
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// KeyDown �C�x���g(SalesTarget_uGrid)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �J�[�\���{�^�������������ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.28</br>
		/// </remarks>
		private void SalesTarget_uGrid_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.SalesTarget_uGrid.Rows.Count < 1)
			{
				return;
			}

			int rowCount = this.SalesTarget_uGrid.Rows.Count;
			int rowIndex = this.SalesTarget_uGrid.ActiveRow.Index;

			if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Left)
			{
				if (rowIndex == 0)
				{
					this.TargetSetCd_uOptionSet.Focus();
				}
			}
			else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Right)
			{
				if (rowIndex + 1 == rowCount)
				{
					this.cmbFontSize.Focus();
				}
			}
		}

		# endregion Control Events
	}

	/// <summary>
	/// �ڕW�f�[�^��r�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note		: �ڕW�f�[�^�̔�r���s���܂��B</br>
	/// <br>Programmer	: NEPCO</br>
	/// <br>Date		: 2007.04.27</br>
	/// </remarks>
	public class SalesTargetDataCompApplyStaDate : IComparer<SalesTarget>
	{
		#region IComparer<SalesTarget> �����o

		/// <summary>
		/// �ڕW�f�[�^��r����
		/// </summary>
		/// <param name="x">��r�p�ڕW�f�[�^</param>
		/// <param name="y">��r�p�ڕW�f�[�^</param>
		/// <remarks>
		/// <br>Note		: �K�p���ԁi�J�n�j�̔�r���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.27</br>
		/// </remarks>
		public int Compare(SalesTarget x, SalesTarget y)
		{
			if (x.ApplyStaDate > y.ApplyStaDate)
			{
				return (-1);
			}
			else if (x.ApplyStaDate == y.ApplyStaDate)
			{
				if (x.ApplyEndDate > y.ApplyEndDate)
				{
					return (-1);
				}
				else if (x.ApplyEndDate == y.ApplyEndDate)
				{
					return (0);
				}
				else
				{
					return (1);
				}
			}
			else
			{
				return (1);
			}
		}

		#endregion
	}
}