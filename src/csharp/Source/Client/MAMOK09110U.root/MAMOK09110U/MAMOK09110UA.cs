using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using System.Collections;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �]�ƈ��ڕW���͉��
	/// </summary>
	/// <remarks>
	/// <br>Note		: �]�ƈ��ڕW���͂��s����ʂł��B</br>
	/// <br>Programmer	: NEPCO</br>
	/// <br>Date		: 2007.04.23</br>
	/// <br>Update Note : 2007.11.21 30167 ���@�O�M</br>
	/// <br> 			  ����.DC�p�ɕύX�i���ڒǉ��E�폜�j</br>
	/// <br>Update Note : 2008.03.03 30167 ���@�O�M</br>
	/// <br>			  ���ڃ[�����ߑΉ��i��ʃf�U�C���ɃR���|�[�l���g�ǉ��A
	///					  Tedit�ATNedit�̐ݒ�ύX�j</br>
	/// <br>Update Note : 2008.03.06 30167 ���@�O�M</br>
	///	<br>		 	  �V���[�g�J�b�g�L�[�G���[�`�F�b�N�Ή��ǉ�</br>
	/// <br>Update Note: 2008.03.07 30167 ���@�O�M</br>
	///					�E���ڃN���A��G���^�[�L�[�Ŏ����ڂֈړ�����悤�C��</br>
	/// <br>Update Note: 2008.03.12 30167 ���@�O�M</br>
	///					�E�ۃK�C�h�A����K�C�h���_�i�荞�ݘR��C��</br>
	/// </remarks>
	public partial class MAMOK09110UA : Form
	{
		# region Private Constants

		// PG����
		private const string ctPGNM = "�]�ƈ��ڕW����";

		//----- ueno del---------- start 2007.11.21
		// �䗦
        //private const string RATIO_DEFAULT = "1.00";
		//----- ueno del---------- end   2007.11.21

        // ����
        private const string FORMAT_NUM = "###,##0";
        private const string FORMAT_NUM_DECIMAL = "N1";

		// ���_�ڕW�p�]�ƈ��R�[�h
		private const string EMPLOYEECODE_SECTION = "SECTION";

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
		// �ڕW�f�[�^���X�g
		private List<SalesTarget> _salesTargetList;

//----- ueno add---------- start 2007.11.21
		// ����R�[�h�i���[�N�j
		private int _subSectionCodeWork = 0;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
		// �ۃR�[�h�i���[�N�j
		//private int _minSectionCodeWork = 0;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
		
		// �]�ƈ��R�[�h�i���[�N�j
		private string _employeeCodeWork = "";

		// �ڕW�Δ�敪���[�N
		private int _targetContrastCd_tComboEditorValue = -1;

//----- ueno add---------- end   2007.11.21

		//----- ueno add---------- start 2008.03.06
		// �����񌋍��p
		private StringBuilder _stringBuilder = null;

		// ����A�N�Z�X�N���X
		SubSectionAcs _subSectionAcs = null;
		
		// �ۃA�N�Z�X�N���X
		MinSectionAcs _minSectionAcs = null;
		
		// �]�ƈ��A�N�Z�X�N���X
		EmployeeAcs _employeeAcs = null;
		//----- ueno add---------- end 2008.03.06

		//----- ueno del---------- start 2007.11.21
		//// �x�Ɠ��ݒ�}�X�^
		//private Dictionary<SectionAndDate, HolidaySetting> _holidaySettingDic;

		//// ���n�v�Z�䗦���X�g
		//private List<LdgCalcRatioMng> _ldgCalcRatioMngList;
		//----- ueno del---------- end   2007.11.21

		// �ڕW�ݒ�敪
		private int _targetSetCd;
		// �ڕW�Δ�敪
		private int _targetContrastCd;

		// ���ԁi�J�n�j
		private DateTime _targetStaDate;
		// ���ԁi�I���j
		private DateTime _targetEndDate;

		// ���[�h(�V�K or �ҏW)
		private int _mode;

		private bool _searchFlag;

		/// <summary>��ʃf�U�C���ύX�N���X</summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		# endregion Private Members

		# region Constructor

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public MAMOK09110UA()
		{
			InitializeComponent();

			// ��ƃR�[�h���擾
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA DEL START
            // _Load�Ɉڍs
			// ���_���̎擾
            //SecInfoSet secInfoSet;
            //SecInfoAcs secInfoAcs = new SecInfoAcs();
            //secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
            //this._sectionCode = secInfoSet.SectionCode;
            //this._sectionName = secInfoSet.SectionGuideNm.TrimEnd();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA DEL END

			this._salesTargetAcs = new SalesTargetAcs();

			//----- ueno add---------- start 2008.03.06
			// ����A�N�Z�X�N���X
			this._subSectionAcs = new SubSectionAcs();

			// �ۃA�N�Z�X�N���X
			this._minSectionAcs = new MinSectionAcs();

			// �]�ƈ��A�N�Z�X�N���X
			this._employeeAcs = new EmployeeAcs();

			// �����񌋍��p
			this._stringBuilder = new StringBuilder();
			//----- ueno add---------- end 2008.03.06

			// �A�C�R���摜�̐ݒ�
//----- ueno add---------- start 2007.11.21		
			// ����R�[�h�K�C�h�{�^��
			this.SubSectionCodeGuide_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA DEL START
            //// �ۃR�[�h�K�C�h�{�^��
            //this.MinSectionCodeGuide_Button.Appearance.Image
            //    = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA DEL END

//----- ueno add---------- end   2007.11.21

			// �]�ƈ��K�C�h�{�^��
			this.EmployeeCodeGuide_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
			// �I���{�^��
			this.Close_Button.Appearance.Image
				= IconResourceManagement.ImageList24.Images[(int)Size24_Index.CLOSE];
			// �ۑ��{�^��
			this.Save_Button.Appearance.Image
				= IconResourceManagement.ImageList24.Images[(int)Size24_Index.SAVE];
		}

		# endregion Constructor

		#region enum
		//----- ueno upd ---------- start 2008.03.06
		/// <summary>
		/// ���̓G���[�`�F�b�N�X�e�[�^�X
		/// </summary>
		private enum InputChkStatus
		{
			// ������
			NotInput = -1,
			// ���݂��Ȃ�
			NotExist = -2,
			// ���̓~�X
			InputErr = -3,
			// ����
			Normal = 0,
			// �L�����Z��
			Cancel = 1
		}
		///// <summary>
		///// ���̓G���[�`�F�b�N�t���O
		///// </summary>
		//private enum InputChk
		//{
		//    // ���݂��Ȃ�
		//    None = 0,
		//    // �X�V
		//    Update = 1,
		//    // ���ɖ߂�
		//    Back = 2
		//}
		//----- ueno upd ---------- end 2008.03.06

		//----- ueno add---------- start 2008.03.06
		/// <summary>
		/// ��ʃf�[�^�ݒ�X�e�[�^�X
		/// </summary>
		private enum DispSetStatus
		{
			// �N���A
			Clear = 0,
			// �X�V
			Update = 1,
			// ���ɖ߂�
			Back = 2
		}
		//----- ueno add---------- end 2008.03.06

		#endregion

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

		/// public propaty name  :	Mode
		/// <summary>���[�h�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 ���[�h�v���p�e�B</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public int Mode
		{
			get
			{
				return this._mode;
			}
			set
			{
				this._mode = value;
			}
		}

		/// public propaty name  :	SearchFlag
		/// <summary>�����t���O�v���p�e�B</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note			 :	 �����t���O�v���p�e�B</br>
		/// <br>Programer		 :	 NEPCO</br>
		/// </remarks>
		public bool SearchFlag
		{
			get
			{
				return this._searchFlag;
			}
			set
			{
				this._searchFlag = value;
			}
		}

		# endregion Public Propaties

		# region Private Methods

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �}�X�^�Ǎ�����
		///// </summary>
		///// <remarks>
		///// <br>Note		: �e�}�X�^��ǂݍ��݂܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.24</br>
		///// </remarks>
		//private bool LoadMasterTable()
		//{
		//    int status;

		//    // �x�Ɠ��ݒ�}�X�^
		//    status = LoadHolidaySettingTable(this._salesTarget.SectionCode);
		//    if (status != 0)
		//    {
		//        return (false);
		//    }


		//    // ���n�v�Z�䗦�Ǘ��}�X�^
		//    status = LoadLdgCalcRatioMngTable(this._sectionCode);

		//    if (status != 0)
		//    {
		//        return (false);
		//    }

		//    return (true);
		//}

		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �x�Ɠ��ݒ�}�X�^�ǂݍ��ݏ���
		///// </summary>
		///// <param name="sectionCode">���_�R�[�h</param>
		///// <remarks>
		///// <br>Note		: �x�Ɠ��ݒ�}�X�^��ǂݍ��݋x�Ɠ��K�p�敪���擾���܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.07.11</br>
		///// </remarks>
		//private int LoadHolidaySettingTable(string sectionCode)
		//{
		//    int status;
		//    ArrayList retList;

		//    _holidaySettingDic = new Dictionary<SectionAndDate, HolidaySetting>();

		//    // �x�Ɠ��ݒ�}�X�^����f�[�^���擾
		//    HolidaySettingAcs holidaySettingAcs = new HolidaySettingAcs();
		//    status = holidaySettingAcs.Search(
		//        out retList,
		//        this._enterpriseCode,
		//        sectionCode,
		//        DateTime.MinValue,
		//        DateTime.MaxValue);
		//    switch (status)
		//    {
		//        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
		//        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
		//        case (int)ConstantManagement.DB_Status.ctDB_EOF:
		//            break;
		//        default:
		//            TMsgDisp.Show(
		//                this,										// �e�E�B���h�E�t�H�[��
		//                emErrorLevel.ERR_LEVEL_STOP,				// �G���[���x��
		//                this.Name,									// �A�Z���u��ID
		//                ctPGNM,  �@�@								// �v���O��������
		//                "LoadHolidaySettingTable",					// ��������
		//                TMsgDisp.OPE_GET,							// �I�y���[�V����
		//                "�x�Ɠ��ݒ�}�X�^�̓ǂݍ��݂Ɏ��s���܂���",					// �\�����郁�b�Z�[�W
		//                status,										// �X�e�[�^�X�l
		//                holidaySettingAcs,							// �G���[�����������I�u�W�F�N�g
		//                MessageBoxButtons.OK,			  			// �\������{�^��
		//                MessageBoxDefaultButton.Button1);			// �����\���{�^��
		//            return (status);
		//    }

		//    // ���X�g�쐬
		//    SectionAndDate sectionAndDate;
		//    foreach (HolidaySetting holidaySetting in retList)
		//    {
		//        sectionAndDate.SectionCode = holidaySetting.SectionCode;
		//        sectionAndDate.Date = holidaySetting.ApplyDate;
		//        _holidaySettingDic.Add(sectionAndDate, holidaySetting);
		//    }

		//    return (0);

		//}

		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// ���n�v�Z�䗦�Ǘ��}�X�^�ǂݍ��ݏ���
		///// </summary>
		///// <param name="sectionCode">���_�R�[�h</param>
		///// <remarks>
		///// <br>Note		: ���n�v�Z�䗦�Ǘ��}�X�^��ǂݍ��݊e�j���̔䗦���擾���܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.07.12</br>
		///// </remarks>
		//private int LoadLdgCalcRatioMngTable(string sectionCode)
		//{
		//    LdgCalcRatioMngAcs ldgCalcRatioMngAcs = new LdgCalcRatioMngAcs();
		//    this._ldgCalcRatioMngList = new List<LdgCalcRatioMng>();

		//    string[] sectionCodeList = new string[1];
		//    sectionCodeList[0] = sectionCode;

		//    // ���n�v�Z�䗦�Ǘ��}�X�^�擾
		//    int status = ldgCalcRatioMngAcs.Search(out this._ldgCalcRatioMngList, this._enterpriseCode, sectionCodeList);
		//    switch (status)
		//    {
		//        case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
		//        case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
		//        case (int)ConstantManagement.DB_Status.ctDB_EOF:
		//            // ����
		//            break;
		//        default:
		//            // �G���[
		//            return (status);
		//    }

		//    return (0);
		//}

		/////*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �䗦����v�Z����
		///// </summary>
		///// <remarks>
		///// <br>Note		: ����P�ʂ̖ڕW��䗦����v�Z���܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.02</br>
		///// </remarks>
		//private void CalcFromRatio()
		//{
		//    // ���ԖڕW
		//    if (this._targetSetCd == 10)
		//    {
		//        if (this.ApplyStaDate_tDateEdit.GetDateTime() == DateTime.MinValue)
		//        {
		//            return;
		//        }
		//    }
		//    // �ʊ��ԖڕW
		//    else
		//    {
		//        if (this.ApplyStaDate_tDateEdit.GetDateTime() == DateTime.MinValue ||
		//        this.ApplyEndDate_tDateEdit.GetDateTime() == DateTime.MinValue)
		//        {
		//            return;
		//        }
		//    }

		//    if (this.ApplyStaDate_tDateEdit.GetDateTime() > this.ApplyEndDate_tDateEdit.GetDateTime())
		//    {
		//        ClearRatioControl();
		//        return;
		//    }

		//    this._targetStaDate = this.ApplyStaDate_tDateEdit.GetDateTime();
		//    this._targetEndDate = this.ApplyEndDate_tDateEdit.GetDateTime();

		//    double salesTarget;
		//    double[] salesTargetDayOfWeek;

		//    // �v�Z���ĕ\��
		//    if (this.SalesTargetMoney_tNedit.DataText != "")
		//    {
		//        salesTarget = double.Parse(this.SalesTargetMoney_tNedit.DataText);
		//        // �䗦�v�Z
		//        SalesLandingAcs.CalcDaySalesTargetFromRatio(
		//            out salesTargetDayOfWeek,
		//            salesTarget,
		//            0,
		//            this._targetStaDate,
		//            this._targetEndDate,
		//            this._sectionCode,
		//            this._ldgCalcRatioMngList,
		//            this._holidaySettingDic);

		//        // ���j����
		//        this.SalesTargetMoneySunday_tNedit.Value = salesTargetDayOfWeek[0].ToString(FORMAT_NUM);
		//        // ���j����
		//        this.SalesTargetMoneyMonday_tNedit.Value = salesTargetDayOfWeek[1].ToString(FORMAT_NUM);
		//        // �Ηj����
		//        this.SalesTargetMoneyTuesday_tNedit.Value = salesTargetDayOfWeek[2].ToString(FORMAT_NUM);
		//        // ���j����
		//        this.SalesTargetMoneyWednesday_tNedit.Value = salesTargetDayOfWeek[3].ToString(FORMAT_NUM);
		//        // �ؗj����
		//        this.SalesTargetMoneyThursday_tNedit.Value = salesTargetDayOfWeek[4].ToString(FORMAT_NUM);
		//        // ���j����
		//        this.SalesTargetMoneyFriday_tNedit.Value = salesTargetDayOfWeek[5].ToString(FORMAT_NUM);
		//        // �y�j����
		//        this.SalesTargetMoneySaturday_tNedit.Value = salesTargetDayOfWeek[6].ToString(FORMAT_NUM);
		//        // �j�Փ�����
		//        this.SalesTargetMoneyHoliday_tNedit.Value = salesTargetDayOfWeek[7].ToString(FORMAT_NUM);
		//    }
		//    else
		//    {
		//        this.SalesTargetMoneySunday_tNedit.DataText = "";
		//        this.SalesTargetMoneyMonday_tNedit.DataText = "";
		//        this.SalesTargetMoneyTuesday_tNedit.DataText = "";
		//        this.SalesTargetMoneyWednesday_tNedit.DataText = "";
		//        this.SalesTargetMoneyThursday_tNedit.DataText = "";
		//        this.SalesTargetMoneyFriday_tNedit.DataText = "";
		//        this.SalesTargetMoneySaturday_tNedit.DataText = "";
		//        this.SalesTargetMoneyHoliday_tNedit.DataText = "";
		//    }
		//    if (this.SalesTargetProfit_tNedit.DataText != "")
		//    {
		//        salesTarget = double.Parse(this.SalesTargetProfit_tNedit.DataText);
		//        // �䗦�v�Z
		//        SalesLandingAcs.CalcDaySalesTargetFromRatio(
		//            out salesTargetDayOfWeek,
		//            salesTarget,
		//            0,
		//            this._targetStaDate,
		//            this._targetEndDate,
		//            this._sectionCode,
		//            this._ldgCalcRatioMngList,
		//            this._holidaySettingDic);

		//        // ���j�e��
		//        this.SalesTargetProfitSunday_tNedit.Value = salesTargetDayOfWeek[0].ToString(FORMAT_NUM);
		//        // ���j�e��
		//        this.SalesTargetProfitMonday_tNedit.Value = salesTargetDayOfWeek[1].ToString(FORMAT_NUM);
		//        // �Ηj�e��
		//        this.SalesTargetProfitTuesday_tNedit.Value = salesTargetDayOfWeek[2].ToString(FORMAT_NUM);
		//        // ���j�e��
		//        this.SalesTargetProfitWednesday_tNedit.Value = salesTargetDayOfWeek[3].ToString(FORMAT_NUM);
		//        // �ؗj�e��
		//        this.SalesTargetProfitThursday_tNedit.Value = salesTargetDayOfWeek[4].ToString(FORMAT_NUM);
		//        // ���j�e��
		//        this.SalesTargetProfitFriday_tNedit.Value = salesTargetDayOfWeek[5].ToString(FORMAT_NUM);
		//        // �y�j�e��
		//        this.SalesTargetProfitSaturday_tNedit.Value = salesTargetDayOfWeek[6].ToString(FORMAT_NUM);
		//        // �j�Փ��e��
		//        this.SalesTargetProfitHoliday_tNedit.Value = salesTargetDayOfWeek[7].ToString(FORMAT_NUM);
		//    }
		//    else
		//    {
		//        this.SalesTargetProfitSunday_tNedit.DataText = "";
		//        this.SalesTargetProfitMonday_tNedit.DataText = "";
		//        this.SalesTargetProfitTuesday_tNedit.DataText = "";
		//        this.SalesTargetProfitWednesday_tNedit.DataText = "";
		//        this.SalesTargetProfitThursday_tNedit.DataText = "";
		//        this.SalesTargetProfitFriday_tNedit.DataText = "";
		//        this.SalesTargetProfitSaturday_tNedit.DataText = "";
		//        this.SalesTargetProfitHoliday_tNedit.DataText = "";
		//    }
		//    if (this.SalesTargetCount_tNedit.DataText != "")
		//    {
		//        salesTarget = double.Parse(this.SalesTargetCount_tNedit.DataText);
		//        // �䗦�v�Z
		//        SalesLandingAcs.CalcDaySalesTargetFromRatio(
		//            out salesTargetDayOfWeek,
		//            salesTarget,
		//            1,
		//            this._targetStaDate,
		//            this._targetEndDate,
		//            this._sectionCode,
		//            this._ldgCalcRatioMngList,
		//            this._holidaySettingDic);

		//        // ���j����
		//        this.SalesTargetCountSunday_tNedit.Value = salesTargetDayOfWeek[0].ToString(FORMAT_NUM_DECIMAL);
		//        // ���j����
		//        this.SalesTargetCou��tMonday_tNedit.Value = salesTargetDayOfWeek[1].ToString(FORMAT_NUM_DECIMAL);
		//        // �Ηj����
		//        this.SalesTargetCountTuesday_tNedit.Value = salesTargetDayOfWeek[2].ToString(FORMAT_NUM_DECIMAL);
		//        // ���j����
		//        this.SalesTargetCountWednesday_tNedit.Value = salesTargetDayOfWeek[3].ToString(FORMAT_NUM_DECIMAL);
		//        // �ؗj����
		//        this.SalesTargetCountThursday_tNedit.Value = salesTargetDayOfWeek[4].ToString(FORMAT_NUM_DECIMAL);
		//        // ���j����
		//        this.SalesTargetCountFriday_tNedit.Value = salesTargetDayOfWeek[5].ToString(FORMAT_NUM_DECIMAL);
		//        // �y�j����
		//        this.SalesTargetCountSaturday_tNedit.Value = salesTargetDayOfWeek[6].ToString(FORMAT_NUM_DECIMAL);
		//        // �j�Փ�����
		//        this.SalesTargetCountHoliday_tNedit.Value = salesTargetDayOfWeek[7].ToString(FORMAT_NUM_DECIMAL);
		//    }
		//    else
		//    {
		//        this.SalesTargetCountSunday_tNedit.DataText = "";
		//        this.SalesTargetCou��tMonday_tNedit.DataText = "";
		//        this.SalesTargetCountTuesday_tNedit.DataText = "";
		//        this.SalesTargetCountWednesday_tNedit.DataText = "";
		//        this.SalesTargetCountThursday_tNedit.DataText = "";
		//        this.SalesTargetCountFriday_tNedit.DataText = "";
		//        this.SalesTargetCountSaturday_tNedit.DataText = "";
		//        this.SalesTargetCountHoliday_tNedit.DataText = "";
		//    }
		//}
		#endregion del
		//----- ueno del---------- end   2007.11.21

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
//----- ueno add---------- start 2007.11.21
			// �ڕW�Δ�敪
			if (salesTarget.TargetContrastCd != 0)
			{
				this.TargetContrastCd_tComboEditor.Value = (int)salesTarget.TargetContrastCd;
			}
//----- ueno add---------- end   2007.11.21

			// �ڕW�ݒ�敪
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
			//this.TargetSetCd_uOptionSet.Value = salesTarget.TargetSetCd;
            //this.TargetSetCd_tComboEditor.SelectedItem.DataValue = salesTarget.TargetSetCd;
            if (salesTarget.TargetSetCd == 10)
            {
                this.TargetSetCd_tComboEditor.SelectedIndex = 0;
            }
            else
            {
                this.TargetSetCd_tComboEditor.SelectedIndex = 1;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
			// ���_����
			this.SectionName_tEdit.DataText = this._sectionName;
			// �K�p���ԁi�J�n�j
			this.ApplyStaDate_tDateEdit.SetDateTime(salesTarget.ApplyStaDate.Date);
			// �K�p���ԁi�I���j
			this.ApplyEndDate_tDateEdit.SetDateTime(salesTarget.ApplyEndDate.Date);
			// �ڕW�敪�R�[�h
			this.TargetDivideCode_tEdit.DataText = salesTarget.TargetDivideCode;
			// �ڕW�敪����
			this.TargetDivideName_tEdit.DataText = salesTarget.TargetDivideName;

//----- ueno add---------- start 2007.11.21

			// �]�ƈ��敪
			if (salesTarget.EmployeeDivCd != 0)
			{
				// 0�ȊO�̏ꍇ�͐V�K�ȊO�Ȃ̂ŁA�擾�����f�[�^��ݒ肷��
				this.EmployeeDivCd_tComboEditor.Value = salesTarget.EmployeeDivCd; 
			}
			else
			{
				// 0�̏ꍇ�͐V�K�Ȃ̂ŃR���{�{�b�N�X�f�t�H���g�l��ݒ肷��
				salesTarget.EmployeeDivCd = (int)this.EmployeeDivCd_tComboEditor.Value;
			}

			// ����R�[�h
			this.SubSectionCode_tNedit.SetInt(salesTarget.SubSectionCode);
			
			// ���喼��
			this.SubSectionCodeNm_tEdit.DataText = GetSubSectionName(salesTarget.SubSectionCode);
			
			// �ۃR�[�h
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
			//this.MinSectionCode_tNedit.SetInt(salesTarget.MinSectionCode);

            // �ۖ���
			//this.MinSectionCodeNm_tEdit.DataText = GetMinSectionName(salesTarget.SubSectionCode, salesTarget.MinSectionCode);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA DEL END

			
//----- ueno add---------- end   2007.11.21

			// �]�ƈ��R�[�h
			this.EmployeeCode_tEdit.DataText = salesTarget.EmployeeCode;
			// �]�ƈ�����
			this.EmployeeName_tEdit.DataText = salesTarget.EmployeeName;
			// ����ڕW
			if (salesTarget.SalesTargetMoney != 0)
			{
				this.SalesTargetMoney_tNedit.DataText = salesTarget.SalesTargetMoney.ToString();
			}
			else
			{
				this.SalesTargetMoney_tNedit.DataText = "";
			}
			// �e���ڕW
			if (salesTarget.SalesTargetProfit != 0)
			{
				this.SalesTargetProfit_tNedit.DataText = salesTarget.SalesTargetProfit.ToString();
			}
			else
			{
				this.SalesTargetProfit_tNedit.DataText = "";
			}
			// ���ʖڕW
			if (salesTarget.SalesTargetCount != 0)
			{
				this.SalesTargetCount_tNedit.DataText = salesTarget.SalesTargetCount.ToString();
			}
			else
			{
				this.SalesTargetCount_tNedit.DataText = "";
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �C���ڕW�f�[�^�o�b�t�@�ۑ�����
		/// </summary>
		/// <param name="salesTarget">�ڕW�f�[�^</param>
		/// <remarks>
		/// Note	   : �C���Ώۂ̖ڕW�f�[�^���o�b�t�@�ɕۑ����܂��B<br />
		/// Programmer : NEPCO<br />
		/// Date	   : 2007.04.03<br />
		/// </remarks>
		private void ScreenToSalesTarget(out SalesTarget salesTarget)
		{
			salesTarget = this._salesTarget.Clone();

//----- ueno add---------- start 2007.11.21
			// �ڕW�Δ�敪
			if (this.TargetContrastCd_tComboEditor.Value != null)
			{
				salesTarget.TargetContrastCd = (int)this.TargetContrastCd_tComboEditor.Value;
			}
//----- ueno add---------- end   2007.11.21

			// �ڕW�ݒ�敪
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
			//salesTarget.TargetSetCd = (int)TargetSetCd_uOptionSet.Value;
            salesTarget.TargetSetCd = int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString());
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
			// ���ԁi�J�n�j
            //salesTarget.ApplyStaDate = this._targetStaDate.Date;
            salesTarget.ApplyStaDate = this.ApplyStaDate_tDateEdit.GetDateTime();
			// ���ԁi�I���j
            //salesTarget.ApplyEndDate = this._targetEndDate.Date;
            salesTarget.ApplyEndDate = this.ApplyEndDate_tDateEdit.GetDateTime();
			// �ڕW�敪�R�[�h
			salesTarget.TargetDivideCode = this.TargetDivideCode_tEdit.DataText;
			// �ڕW�敪����
			salesTarget.TargetDivideName = this.TargetDivideName_tEdit.DataText;

//----- ueno add---------- start 2007.11.21
			// �]�ƈ��敪
			salesTarget.EmployeeDivCd = (int)this.EmployeeDivCd_tComboEditor.Value;
			
			// ����R�[�h
			salesTarget.SubSectionCode = this.SubSectionCode_tNedit.GetInt();
			
			// �ۃR�[�h
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
			//salesTarget.MinSectionCode = this.MinSectionCode_tNedit.GetInt();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
//----- ueno add---------- end   2007.11.21

			// �]�ƈ��R�[�h
			if (this._targetContrastCd == (int)SalesTarget.ConstrastCd.Section)
			{
				// ���_�ڕW
				salesTarget.EmployeeCode = EMPLOYEECODE_SECTION;
			}
			else
			{
				// �]�ƈ��ڕW
				salesTarget.EmployeeCode = this.EmployeeCode_tEdit.DataText;
			}
			// �]�ƈ�����
			salesTarget.EmployeeName = this.EmployeeName_tEdit.DataText;
			// ����ڕW
			if (this.SalesTargetMoney_tNedit.DataText != "")
			{
				salesTarget.SalesTargetMoney = long.Parse(this.SalesTargetMoney_tNedit.DataText);
			}
			else
			{
				salesTarget.SalesTargetMoney = new long();
			}
			// �e���ڕW
			if (this.SalesTargetProfit_tNedit.DataText != "")
			{
				salesTarget.SalesTargetProfit = long.Parse(this.SalesTargetProfit_tNedit.DataText);
			}
			else
			{
				salesTarget.SalesTargetProfit = new long();
			}
			// ���ʖڕW
			if (this.SalesTargetCount_tNedit.DataText != "")
			{
				salesTarget.SalesTargetCount = double.Parse(this.SalesTargetCount_tNedit.DataText);
			}
			else
			{
				salesTarget.SalesTargetCount = new double();
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �C���ڕW�f�[�^�`�F�b�N����
		/// </summary>
		/// <remarks>
		/// Note	   : �C���ڕW�f�[�^���`�F�b�N���܂��B<br />
		/// Programmer : NEPCO<br />
		/// Date	   : 2007.04.03<br />
		/// </remarks>
		private bool CheckInputData()
		{
			string errMsg = "";
			try
			{
				// ���ԖڕW
				if (this._targetSetCd == 10)
				{
					if (this.ApplyStaDate_tDateEdit.GetDateYear() == 0 ||
						this.ApplyStaDate_tDateEdit.GetDateMonth() == 0)
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
								1);
					}
					catch (ArgumentOutOfRangeException)
					{
						errMsg = "���t�𐳂������͂��Ă�������";
						this.ApplyStaDate_tDateEdit.Focus();
						return (false);
					}

                    
				}
				// �ʖڕW
				else
				{
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

					if (this.ApplyStaDate_tDateEdit.GetDateTime() > this.ApplyEndDate_tDateEdit.GetDateTime())
					{
						errMsg = "�J�n�@<=  �I���Ŏw�肵�Ă�������";
						this.ApplyStaDate_tDateEdit.Focus();
						return (false);
					}

					if (this.TargetDivideCode_tEdit.DataText == "")
					{
						errMsg = "�ڕW�敪�R�[�h����͂��Ă�������";
						this.TargetDivideCode_tEdit.Focus();
						return (false);
					}
					if (this.TargetDivideName_tEdit.DataText == "")
					{
						errMsg = "�ڕW�敪���̂���͂��Ă�������";
						this.TargetDivideName_tEdit.Focus();
						return (false);
					}
				}

				// �]�ƈ��ڕW�i20:���_+����, 21:���_+����+��, 22:���_+�]�ƈ��j
				//----- ueno upd---------- start 2007.11.21
				if ((this._targetContrastCd == (int)SalesTarget.ConstrastCd.SecAndSubSec)
					//|| (this._targetContrastCd == (int)SalesTarget.ConstrastCd.SecAndSubSecAndMinSec)
					|| (this._targetContrastCd == (int)SalesTarget.ConstrastCd.SecAndEmp))
				//----- ueno upd---------- end   2007.11.21
				{
//----- ueno add---------- start 2007.11.21�@
					
					// �ڕW�Δ�敪�ɂ��`�F�b�N�ύX
					switch((int)this.TargetContrastCd_tComboEditor.Value)
					{
						case (int)SalesTarget.ConstrastCd.SecAndSubSec:				// 20:���_�{����
							{
								// ����R�[�h
								if ((this.SubSectionCode_tNedit.DataText == "") || (this.SubSectionCode_tNedit.GetInt() == 0))
								{
									errMsg = "����R�[�h����͂��Ă�������";
									this.SubSectionCode_tNedit.Focus();

									//----- ueno add ---------- start 2008.03.06
									this.SubSectionCodeNm_tEdit.Clear();	// ���喼�̃N���A
									this._subSectionCodeWork = 0;			// ����R�[�h���[�N�N���A

                                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
									//this.MinSectionCode_tNedit.Clear();		// �ۃR�[�h�N���A
									//this.MinSectionCodeNm_tEdit.Clear();	// �ۖ��̃N���A
									//this._minSectionCodeWork = 0;			// �ۃR�[�h���[�N�N���A
                                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
									//----- ueno add ---------- end 2008.03.06
									
									return (false);
								}
								break;
							}
                        //case (int)SalesTarget.ConstrastCd.SecAndSubSecAndMinSec:	// 21:���_�{����{��
                        //    {
                        //        // ����R�[�h
                        //        if ((this.SubSectionCode_tNedit.DataText == "") || (this.SubSectionCode_tNedit.GetInt() == 0))
                        //        {
                        //            errMsg = "����R�[�h����͂��Ă�������";
                        //            this.SubSectionCode_tNedit.Focus();

                        //            //----- ueno add ---------- start 2008.03.06
                        //            this.SubSectionCodeNm_tEdit.Clear();	// ���喼�̃N���A
                        //            this._subSectionCodeWork = 0;			// ����R�[�h���[�N�N���A

                        //            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
                        //            //this.MinSectionCode_tNedit.Clear();		// �ۃR�[�h�N���A
                        //            //this.MinSectionCodeNm_tEdit.Clear();	// �ۖ��̃N���A
                        //            //this._minSectionCodeWork = 0;			// �ۃR�[�h���[�N�N���A
                        //            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
                        //            //----- ueno add ---------- end 2008.03.06

                        //            return (false);
                        //        }
                        //        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
                        //        //// �ۃR�[�h
                        //        //if ((this.MinSectionCode_tNedit.DataText == "") || (this.MinSectionCode_tNedit.GetInt() == 0))
                        //        //{
                        //        //    errMsg = "�ۃR�[�h����͂��Ă�������";
                        //        //    this.MinSectionCode_tNedit.Focus();

                        //        //    //----- ueno add ---------- start 2008.03.06
                        //        //    this.MinSectionCodeNm_tEdit.Clear();	// �ۖ��̃N���A
                        //        //    this._minSectionCodeWork = 0;			// �ۃR�[�h���[�N�N���A
                        //        //    //----- ueno add ---------- end 2008.03.06

                        //        //    return (false);
                        //        //}
                        //        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
                        //        break;
                        //    }
						case (int)SalesTarget.ConstrastCd.SecAndEmp:	// 22:���_�{�]�ƈ�
							{
								if (this.EmployeeCode_tEdit.DataText == "")
								{
									errMsg = "�]�ƈ��R�[�h����͂��Ă�������";
									this.EmployeeCode_tEdit.Focus();

									//----- ueno add ---------- start 2008.03.06
									this.EmployeeName_tEdit.Clear();	// �]�ƈ����̃N���A
									this._employeeCodeWork = "";		// �]�ƈ��R�[�h���[�N�N���A
									//----- ueno add ---------- end 2008.03.06

									return (false);
								}

								#region del 2008.03.06
								//----- ueno del ---------- start 2008.03.06
								//--- �]�ƈ��`�F�b�N�͂��̉��ֈړ������̂ŁA�����͍폜����
								//Employee employee;
								//EmployeeAcs employeeAcs = new EmployeeAcs();
								//string employeeCode = this.EmployeeCode_tEdit.DataText;

								//employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);
								//if (employee == null)
								//{
								//    errMsg = "�]�ƈ��R�[�h [" + employeeCode + "] �ɊY������f�[�^�����݂��܂���";
								//    this.EmployeeCode_tEdit.Focus();
								//    return (false);
								//}

								//if (employee.BelongSectionCode.TrimEnd() != this._salesTarget.SectionCode.TrimEnd())
								//{
								//    errMsg = employee.Name.TrimEnd() + "����" + "[" + employeeCode + "] �́A" + this._sectionName + "�ɏ������Ă���܂���";
								//    this.EmployeeCode_tEdit.Focus();
								//    return (false);
								//}
								//----- ueno del ---------- end 2008.03.06
								#endregion del 2008.03.06

								break;
							}
					}

//----- ueno add---------- end   2007.11.21

					#region mov 2007.11.21
					//----- ueno mov---------- start 2007.11.21
					// ��L�̖ڕW�Δ�敪�̏����ɒǉ�����
					//if (this.EmployeeCode_tEdit.DataText == "")
					//{
					//    errMsg = "�]�ƈ��R�[�h����͂��Ă�������";
					//    this.EmployeeCode_tEdit.Focus();
					//    return (false);
					//}
					//Employee employee;
					//EmployeeAcs employeeAcs = new EmployeeAcs();
					//string employeeCode = this.EmployeeCode_tEdit.DataText;

					//employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);
					//if (employee == null)
					//{
					//    errMsg = "�]�ƈ��R�[�h [" + employeeCode + "] �ɊY������f�[�^�����݂��܂���";
					//    this.EmployeeCode_tEdit.Focus();
					//    return (false);
					//}

					//if (employee.BelongSectionCode.TrimEnd() != this._salesTarget.SectionCode.TrimEnd())
					//{
					//    errMsg = employee.Name.TrimEnd() + "����" + "[" + employeeCode + "] �́A" + this._sectionName + "�ɏ������Ă���܂���";
					//    this.EmployeeCode_tEdit.Focus();
					//    return (false);
					//}
					//----- ueno mov---------- end   2007.11.21
					#endregion mov 2007.11.21
				}

				//----- ueno add ---------- start 2008.03.06
				DispSetStatus dispSetStatus = DispSetStatus.Clear;

				bool canChangeFocus = true;
				object inParamObj = null;
				object outParamObj = null;
				ArrayList inParamList = null;

				//------------------------
				// ����R�[�h�`�F�b�N
				//------------------------
				if (this.SubSectionCode_tNedit.Enabled == true)
				{
					// �����ݒ�N���A
					inParamObj = null;
					outParamObj = null;
					inParamList = new ArrayList();

					dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p
					
					// �����ݒ�
					inParamList.Add(this._sectionCode);
					inParamList.Add(this.SubSectionCode_tNedit.GetInt());
					inParamObj = inParamList;

					// ���݃`�F�b�N
					switch (CheckSubSectionCode(inParamObj, out outParamObj))
					{
						case (int)InputChkStatus.Normal:
							{
								dispSetStatus = DispSetStatus.Update;
								break;
							}
						case (int)InputChkStatus.NotInput:
							{
								dispSetStatus = DispSetStatus.Clear;
								break;
							}
						default:
							{
								errMsg = ShowNotFoundErrMsg("����R�[�h");
								dispSetStatus = this._subSectionCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
								break;
							}
					}
					// �f�[�^�ݒ�
					DispSetSubSectionCode(dispSetStatus, ref canChangeFocus, outParamObj);

					if (dispSetStatus != DispSetStatus.Update)
					{
						this.SubSectionCode_tNedit.Focus();
						return false;
					}
                }

                #region del 2008.07.03
                //------------------------
				// �ۃR�[�h�`�F�b�N
				//------------------------
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
                //if (this.MinSectionCode_tNedit.Enabled == true)
                //{
                //    // �����ݒ�N���A
                //    inParamObj = null;
                //    outParamObj = null;
                //    inParamList = new ArrayList();

                //    dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p
					
                //    // �����ݒ�
                //    inParamList.Add(this._sectionCode);
                //    inParamList.Add(this.SubSectionCode_tNedit.GetInt());
                //    inParamList.Add(this.MinSectionCode_tNedit.GetInt());
                //    inParamObj = inParamList;

                //    // ���݃`�F�b�N
                //    switch (CheckMinSectionCode(inParamObj, out outParamObj))
                //    {
                //        case (int)InputChkStatus.Normal:
                //            {
                //                dispSetStatus = DispSetStatus.Update;
                //                break;
                //            }
                //        case (int)InputChkStatus.NotInput:
                //            {
                //                dispSetStatus = DispSetStatus.Clear;
                //                break;
                //            }
                //        default:
                //            {
                //                errMsg = ShowNotFoundErrMsg("�ۃR�[�h");
                //                dispSetStatus = this._minSectionCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                //                break;
                //            }
                //    }
                //    // �f�[�^�ݒ�
                //    DispSetMinSectionCode(dispSetStatus, ref canChangeFocus, outParamObj);

                //    if (dispSetStatus != DispSetStatus.Update)
                //    {
                //        this.MinSectionCode_tNedit.Focus();
                //        return false;
                //    }
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
                #endregion // del 2008.07.03

                //------------------------
				// �]�ƈ��R�[�h�`�F�b�N
				//------------------------
				if (this.EmployeeCode_tEdit.Enabled == true)
				{
					// �����ݒ�N���A
					inParamObj = null;
					outParamObj = null;
					inParamList = new ArrayList();

					dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p

					// �����ݒ�
					inParamObj = this.EmployeeCode_tEdit.Text;

					// ���݃`�F�b�N
					switch (CheckEmployeeCode(inParamObj, out outParamObj))
					{
						case (int)InputChkStatus.Normal:
							{
								dispSetStatus = DispSetStatus.Update;
								break;
							}
						case (int)InputChkStatus.NotInput:
							{
								dispSetStatus = DispSetStatus.Clear;
								break;
							}
						default:
							{
								errMsg = ShowNotFoundErrMsg("�]�ƈ��R�[�h");
								dispSetStatus = this._employeeCodeWork == "" ? DispSetStatus.Clear : DispSetStatus.Back;
								break;
							}
					}
					// �f�[�^�ݒ�
					DispSetEmployeeCode(dispSetStatus, ref canChangeFocus, outParamObj);

					if (dispSetStatus != DispSetStatus.Update)
					{
						this.EmployeeCode_tEdit.Focus();
						return false;
					}
				}
				//----- ueno add ---------- end 2008.03.06
				
                if ((this.SalesTargetMoney_tNedit.DataText == "" || long.Parse(this.SalesTargetMoney_tNedit.DataText) == 0) &&
                    (this.SalesTargetProfit_tNedit.DataText == "" || long.Parse(this.SalesTargetProfit_tNedit.DataText) == 0) &&
                    (this.SalesTargetCount_tNedit.DataText == "" || double.Parse(this.SalesTargetCount_tNedit.DataText) == 0))
                {
                    errMsg = "�ڕW���z�܂��͐��ʂ���͂��Ă�������";
                    this.SalesTargetMoney_tNedit.Focus();
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
		/// ���t�`�F�b�N����
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���͓��t�̃`�F�b�N���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.23</br>
		/// </remarks>
		private bool CheckDate()
		{
			string errMsg = "";

			try
			{
				// ���ԖڕW
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
                if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
                //if ((int)this.TargetSetCd_uOptionSet.Value == 10)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
				{
					if (this.ApplyStaDate_tDateEdit.GetDateYear() != 0 &&
						this.ApplyStaDate_tDateEdit.GetDateMonth() != 0)
					{
						try
						{
							DateTime dummyDateTime = new DateTime(
								this.ApplyStaDate_tDateEdit.GetDateYear(),
								this.ApplyStaDate_tDateEdit.GetDateMonth(),
								1);
						}
						catch (ArgumentOutOfRangeException)
						{
							errMsg = "���t�𐳂������͂��Ă�������";
							this.ApplyStaDate_tDateEdit.Focus();
							return (false);
						}
					}

                    if (this.ApplyStaDate_tDateEdit.GetDateYear() == 1 &&
                        this.ApplyStaDate_tDateEdit.GetDateMonth() == 1)
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
				}
				// �ʊ��ԖڕW
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
                else if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 20)
                //else if ((int)this.TargetSetCd_uOptionSet.Value == 20)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
				{
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

                        if (this.ApplyStaDate_tDateEdit.GetDateYear() < 1900)
                        {
                            errMsg = "���t�𐳂������͂��Ă�������";
                            this.ApplyStaDate_tDateEdit.Focus();
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

                        if (this.ApplyEndDate_tDateEdit.GetDateYear() < 1900)
                        {
                            errMsg = "���t�𐳂������͂��Ă�������";
                            this.ApplyEndDate_tDateEdit.Focus();
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
		/// �C���ڕW�f�[�^�ۑ�����
		/// </summary>
		/// <param name="salesTarget">�ڕW�f�[�^</param>
		/// <remarks>
		/// Note	   : �C���ڕW�f�[�^��ۑ����܂��B<br />
		/// Programmer : NEPCO<br />
		/// Date	   : 2007.04.11<br />
		/// </remarks>
		private bool SaveSalesTarget(ref SalesTarget salesTarget)
		{
			//----- ueno mov---------- start 2007.11.21
			//-----�f�[�^�i�[�����̓��\�b�h�O���ōs���悤�C��
			//bool retResult;

			//// �`�F�b�N����
			//retResult = CheckInputData();
			//if (!retResult)
			//{
			//    return (false);
			//}
			
			//SalesTarget salesTarget;

			//// �C����ڕW�f�[�^���o�b�t�@�ɕۑ�
			//ScreenToSalesTarget(out salesTarget);
			//----- ueno mov---------- end   2007.11.21

			List<SalesTarget> salesTargetList = new List<SalesTarget>();
			salesTargetList.Add(salesTarget);

			int status;
            string checkMessage = "";

			// �ڕW�f�[�^�X�V
			status = this._salesTargetAcs.Write(ref salesTargetList);
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
                case (int)ConstantManagement.DB_Status.ctDB_DUPLICATE:
                    checkMessage = "���ɓo�^����Ă���ڕW�f�[�^�ł�";
                    TMsgDisp.Show(
                        this,									// �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_EXCLAMATION, 	// �G���[���x��
                        this.Name,								// �A�Z���u��ID
                        checkMessage,							// �\�����郁�b�Z�[�W
                        status,									// �X�e�[�^�X�l
                        MessageBoxButtons.OK);					// �\������{�^��
                    return (false);
                default:
                    checkMessage = "�ڕW�f�[�^�ۑ����ɃG���[���������܂���";
                    TMsgDisp.Show(
                        this, 						                // �e�E�B���h�E�t�H�[��
                        emErrorLevel.ERR_LEVEL_STOP,			    // �G���[���x��
                        this.Name,								    // �A�Z���u��ID
                        ctPGNM, 		  �@�@					    // �v���O��������
                        "SaveSalesTarget",						            // ��������
                        TMsgDisp.OPE_UPDATE,					    // �I�y���[�V����
                        checkMessage,	                            // �\�����郁�b�Z�[�W
                        status,									    // �X�e�[�^�X�l
                        this._salesTargetAcs,					    // �G���[�����������I�u�W�F�N�g
                        MessageBoxButtons.OK,			  		    // �\������{�^��
                        MessageBoxDefaultButton.Button1);		    // �����\���{�^��
                    return (false);
            }

			this._salesTarget = salesTarget;
			this._salesTargetList = salesTargetList;

			return (true);
		}

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �]�ƈ���������
		///// </summary>
		///// <param name="employeeCode">�]�ƈ��R�[�h</param>
		///// <remarks>
		///// <br>Note		: �]�ƈ����������܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.04.18</br>
		///// </remarks>
		//private int SearchEmployee(string employeeCode)
		//{
		//    Employee employee;
		//    EmployeeAcs employeeAcs = new EmployeeAcs();

		//    employeeAcs.Read(out employee, this._enterpriseCode, employeeCode);

		//    if (employee == null)
		//    {
		//        this.EmployeeName_tEdit.DataText = "";
		//        return (1);
		//    }

		//    this.EmployeeName_tEdit.DataText = employee.Name;
		//    return (0);
		//}

		////*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �j���ʔ䗦�\������
		///// </summary>
		///// <remarks>
		///// <br>Note		: �j���ʂ̔䗦����ʂɕ\�����܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.07.12</br>
		///// </remarks>
		//private void DispRatioDayOfWeek()
		//{
		//    // �䗦�����������܂�
		//    this.RatioSunday_tNedit.Value = RATIO_DEFAULT;
		//    this.RatioMonday_tNedit.Value = RATIO_DEFAULT;
		//    this.RatioTuesday_tNedit.Value = RATIO_DEFAULT;
		//    this.RatioWednesday_tNedit.Value = RATIO_DEFAULT;
		//    this.RatioThursday_tNedit.Value = RATIO_DEFAULT;
		//    this.RatioFriday_tNedit.Value = RATIO_DEFAULT;
		//    this.RatioSaturday_tNedit.Value = RATIO_DEFAULT;
		//    this.RatioHoliday_tNedit.Value = RATIO_DEFAULT;

		//    foreach (LdgCalcRatioMng ldgCalcRatioMng in this._ldgCalcRatioMngList)
		//    {
		//        if (ldgCalcRatioMng.SectionCode == this._salesTarget.SectionCode)
		//        {
		//            switch (ldgCalcRatioMng.DivisionAtDate)
		//            {
		//                case 0:
		//                    // ���j
		//                    this.RatioSunday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
		//                    break;
		//                case 1:
		//                    // ���j
		//                    this.RatioMonday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
		//                    break;
		//                case 2:
		//                    // �Ηj
		//                    this.RatioTuesday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
		//                    break;
		//                case 3:
		//                    // ���j
		//                    this.RatioWednesday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
		//                    break;
		//                case 4:
		//                    // �ؗj
		//                    this.RatioThursday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
		//                    break;
		//                case 5:
		//                    // ���j
		//                    this.RatioFriday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
		//                    break;
		//                case 6:
		//                    // �y�j
		//                    this.RatioSaturday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
		//                    break;
		//                case 7:
		//                    // �j�Փ�
		//                    this.RatioHoliday_tNedit.Value = ldgCalcRatioMng.Ratio.ToString("F");
		//                    break;
		//            }
		//        }
		//    }
		//}
		#endregion del
		//----- ueno del---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �R���g���[���T�C�Y�ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �R���g���[���T�C�Y�̐ݒ���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private void SetControlSize()
		{
			//----- ueno del ---------- start 2008.03.06
			//-- ��ʂ̐ݒ�͑S�ĉ�ʃf�U�C���ōs���̂ňȉ��폜
			//this.SectionName_tEdit.Size = new Size(179, 24);
			//this.TargetDivideCode_tEdit.Size = new Size(84, 24);
			//this.TargetDivideName_tEdit.Size = new Size(290, 24);
			//this.EmployeeCode_tEdit.Size = new Size(84, 24);
			//this.EmployeeName_tEdit.Size = new Size(290, 24);
			//this.SalesTargetMoney_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfit_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCount_tNedit.Size = new Size(108, 24);
			//----- ueno del ---------- end 2008.03.06

			//----- ueno del---------- start 2007.11.21
			#region del
			//this.RatioSunday_tNedit.Size = new Size(84, 24);
			//this.RatioMonday_tNedit.Size = new Size(84, 24);
			//this.RatioTuesday_tNedit.Size = new Size(84, 24);
			//this.RatioWednesday_tNedit.Size = new Size(84, 24);
			//this.RatioThursday_tNedit.Size = new Size(84, 24);
			//this.RatioFriday_tNedit.Size = new Size(84, 24);
			//this.RatioSaturday_tNedit.Size = new Size(84, 24);
			//this.RatioHoliday_tNedit.Size = new Size(84, 24);
			//this.SalesTargetMoneySunday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfitSunday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCountSunday_tNedit.Size = new Size(108, 24);
			//this.SalesTargetMoneyMonday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfitMonday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCou��tMonday_tNedit.Size = new Size(108, 24);
			//this.SalesTargetMoneyTuesday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfitTuesday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCountTuesday_tNedit.Size = new Size(108, 24);
			//this.SalesTargetMoneyWednesday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfitWednesday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCountWednesday_tNedit.Size = new Size(108, 24);
			//this.SalesTargetMoneyThursday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfitThursday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCountThursday_tNedit.Size = new Size(108, 24);
			//this.SalesTargetMoneyFriday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfitFriday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCountFriday_tNedit.Size = new Size(108, 24);
			//this.SalesTargetMoneySaturday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfitSaturday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCountSaturday_tNedit.Size = new Size(108, 24);
			//this.SalesTargetMoneyHoliday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfitHoliday_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCountHoliday_tNedit.Size = new Size(108, 24);
			#endregion del
			//----- ueno del---------- end   2007.11.21
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Nedit�X�^�C���ݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: Nedit�̃X�^�C����ݒ肵�܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private void SetNeditStyle()
		{
            this.SalesTargetCount_tNedit.NumEdit.DecLen = 1;

			this.SalesTargetMoney_tNedit.NumEdit.CommaEdit = true;
			this.SalesTargetProfit_tNedit.NumEdit.CommaEdit = true;
			this.SalesTargetCount_tNedit.NumEdit.CommaEdit = true;
            this.SalesTargetMoney_tNedit.NumEdit.MinusSupp = true;
            this.SalesTargetProfit_tNedit.NumEdit.MinusSupp = true;
            this.SalesTargetCount_tNedit.NumEdit.MinusSupp = true;
            this.SalesTargetMoney_tNedit.ExtEdit.Column = 15;
            this.SalesTargetProfit_tNedit.ExtEdit.Column = 15;
            this.SalesTargetCount_tNedit.ExtEdit.Column = 10;

			//----- ueno del ---------- start 2008.03.06
			// ���ڂ̍ő���͉\�����͉�ʃf�U�C���Őݒ肷��
			//this.TargetDivideCode_tEdit.MaxLength = 9;
			//this.TargetDivideName_tEdit.MaxLength = 30;
			//this.EmployeeCode_tEdit.MaxLength = 9;
			//this.EmployeeName_tEdit.MaxLength = 30;
			//----- ueno del ---------- end 2008.03.06

			//----- ueno del---------- start 2007.11.21
			#region del
			//this.RatioSunday_tNedit.ExtEdit.Column = 6;
			//this.RatioMonday_tNedit.ExtEdit.Column = 6;
			//this.RatioTuesday_tNedit.ExtEdit.Column = 6;
			//this.RatioWednesday_tNedit.ExtEdit.Column = 6;
			//this.RatioThursday_tNedit.ExtEdit.Column = 6;
			//this.RatioFriday_tNedit.ExtEdit.Column = 6;
			//this.RatioSaturday_tNedit.ExtEdit.Column = 6;
			//this.RatioHoliday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetMoneySunday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetProfitSunday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetCountSunday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetMoneyMonday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetProfitMonday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetCou��tMonday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetMoneyTuesday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetProfitTuesday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetCountTuesday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetMoneyWednesday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetProfitWednesday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetCountWednesday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetMoneyThursday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetProfitThursday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetCountThursday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetMoneyFriday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetProfitFriday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetCountFriday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetMoneySaturday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetProfitSaturday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetCountSaturday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetMoneyHoliday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetProfitHoliday_tNedit.ExtEdit.Column = 6;
			//this.SalesTargetCountHoliday_tNedit.ExtEdit.Column = 6;

			//this.RatioSunday_tNedit.NumEdit.DecLen = 2;
			//this.RatioMonday_tNedit.NumEdit.DecLen = 2;
			//this.RatioTuesday_tNedit.NumEdit.DecLen = 2;
			//this.RatioWednesday_tNedit.NumEdit.DecLen = 2;
			//this.RatioThursday_tNedit.NumEdit.DecLen = 2;
			//this.RatioFriday_tNedit.NumEdit.DecLen = 2;
			//this.RatioSaturday_tNedit.NumEdit.DecLen = 2;
			//this.RatioHoliday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetMoneySunday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetProfitSunday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetCountSunday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetMoneyMonday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetProfitMonday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetCou��tMonday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetMoneyTuesday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetProfitTuesday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetCountTuesday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetMoneyWednesday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetProfitWednesday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetCountWednesday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetMoneyThursday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetProfitThursday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetCountThursday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetMoneyFriday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetProfitFriday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetCountFriday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetMoneySaturday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetProfitSaturday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetCountSaturday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetMoneyHoliday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetProfitHoliday_tNedit.NumEdit.DecLen = 2;
			//this.SalesTargetCountHoliday_tNedit.NumEdit.DecLen = 2;

			//this.RatioSunday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.RatioMonday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.RatioTuesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.RatioWednesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.RatioThursday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.RatioFriday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.RatioSaturday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.RatioHoliday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetMoneySunday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetProfitSunday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetCountSunday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetMoneyMonday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetProfitMonday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetCou��tMonday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetMoneyTuesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetProfitTuesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetCountTuesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetMoneyWednesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetProfitWednesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetCountWednesday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetMoneyThursday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetProfitThursday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetCountThursday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetMoneyFriday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetProfitFriday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetCountFriday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetMoneySaturday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetProfitSaturday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetCountSaturday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetMoneyHoliday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetProfitHoliday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;
			//this.SalesTargetCountHoliday_tNedit.NumEdit.ZeroSupp = emZeroSupp.zsON;

			//this.RatioSunday_tNedit.NumEdit.MinusSupp = true;
			//this.RatioMonday_tNedit.NumEdit.MinusSupp = true;
			//this.RatioTuesday_tNedit.NumEdit.MinusSupp = true;
			//this.RatioWednesday_tNedit.NumEdit.MinusSupp = true;
			//this.RatioThursday_tNedit.NumEdit.MinusSupp = true;
			//this.RatioFriday_tNedit.NumEdit.MinusSupp = true;
			//this.RatioSaturday_tNedit.NumEdit.MinusSupp = true;
			//this.RatioHoliday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetMoneySunday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetProfitSunday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetCountSunday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetMoneyMonday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetProfitMonday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetCou��tMonday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetMoneyTuesday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetProfitTuesday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetCountTuesday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetMoneyWednesday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetProfitWednesday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetCountWednesday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetMoneyThursday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetProfitThursday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetCountThursday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetMoneyFriday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetProfitFriday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetCountFriday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetMoneySaturday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetProfitSaturday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetCountSaturday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetMoneyHoliday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetProfitHoliday_tNedit.NumEdit.MinusSupp = true;
			//this.SalesTargetCountHoliday_tNedit.NumEdit.MinusSupp = true;

			//this.RatioSunday_tNedit.NumEdit.ZeroDisp = true;
			//this.RatioMonday_tNedit.NumEdit.ZeroDisp = true;
			//this.RatioTuesday_tNedit.NumEdit.ZeroDisp = true;
			//this.RatioWednesday_tNedit.NumEdit.ZeroDisp = true;
			//this.RatioThursday_tNedit.NumEdit.ZeroDisp = true;
			//this.RatioFriday_tNedit.NumEdit.ZeroDisp = true;
			//this.RatioSaturday_tNedit.NumEdit.ZeroDisp = true;
			//this.RatioHoliday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetMoneySunday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetProfitSunday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetCountSunday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetMoneyMonday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetProfitMonday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetCou��tMonday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetMoneyTuesday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetProfitTuesday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetCountTuesday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetMoneyWednesday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetProfitWednesday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetCountWednesday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetMoneyThursday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetProfitThursday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetCountThursday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetMoneyFriday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetProfitFriday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetCountFriday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetMoneySaturday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetProfitSaturday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetCountSaturday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetMoneyHoliday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetProfitHoliday_tNedit.NumEdit.ZeroDisp = true;
			//this.SalesTargetCountHoliday_tNedit.NumEdit.ZeroDisp = true;

			//this.SalesTargetMoneySunday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetProfitSunday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetCountSunday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetMoneyMonday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetProfitMonday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetCou��tMonday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetMoneyTuesday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetProfitTuesday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetCountTuesday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetMoneyWednesday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetProfitWednesday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetCountWednesday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetMoneyThursday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetProfitThursday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetCountThursday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetMoneyFriday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetProfitFriday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetCountFriday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetMoneySaturday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetProfitSaturday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetCountSaturday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetMoneyHoliday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetProfitHoliday_tNedit.NumEdit.CommaEdit = true;
			//this.SalesTargetCountHoliday_tNedit.NumEdit.CommaEdit = true;
			#endregion del
			//----- ueno del---------- end   2007.11.21
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �R���g���[�����䏈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �R���g���[���̐���̐ݒ���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private void ControlEnabled()
		{
			// �R���g���[��Visible����
			// ���_�ڕW
			if (this._targetContrastCd == (int)SalesTarget.ConstrastCd.Section)
			{
				this.Text = "���_�ڕW";
//----- ueno add---------- start 2007.11.21
				this.TargetContrastCd_uLabel.Visible = false;
				this.TargetContrastCd_tComboEditor.Visible = false;
				this.EmployeeDivCd_uLabel.Visible = false;
				this.EmployeeDivCd_tComboEditor.Visible = false;
				this.SubSectionCode_uLabel.Visible = false;
				this.SubSectionCode_tNedit.Visible = false;
				this.SubSectionCodeNm_tEdit.Visible = false;
				this.SubSectionCodeGuide_Button.Visible = false;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
				//this.MinSectionCode_uLabel.Visible = false;
				//this.MinSectionCode_tNedit.Visible = false;
				//this.MinSectionCodeNm_tEdit.Visible = false;
				//this.MinSectionCodeGuide_Button.Visible = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
//----- ueno add---------- end   2007.11.21
				this.EmployeeCode_uLabel.Visible = false;
				this.EmployeeCode_tEdit.Visible = false;
				this.EmployeeName_tEdit.Visible = false;
				this.EmployeeCodeGuide_Button.Visible = false;
			}
			// �]�ƈ��ڕW
			else
			{
//----- ueno add---------- start 2007.11.21
				this.TargetContrastCd_uLabel.Visible = true;
				this.TargetContrastCd_tComboEditor.Visible = true;
				this.EmployeeDivCd_uLabel.Visible = true;
				this.EmployeeDivCd_tComboEditor.Visible = true;
				this.SubSectionCode_uLabel.Visible = true;
				this.SubSectionCode_tNedit.Visible = true;
				this.SubSectionCodeNm_tEdit.Visible = true;
				this.SubSectionCodeGuide_Button.Visible = true;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
				//this.MinSectionCode_uLabel.Visible = true;
				//this.MinSectionCode_tNedit.Visible = true;
				//this.MinSectionCodeNm_tEdit.Visible = true;
				//this.MinSectionCodeGuide_Button.Visible = true;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
//----- ueno add---------- end   2007.11.21
				this.Text = "�]�ƈ��ڕW";
				this.EmployeeCode_uLabel.Visible = true;
				this.EmployeeCode_tEdit.Visible = true;
				this.EmployeeName_tEdit.Visible = true;
				this.EmployeeCodeGuide_Button.Visible = true;
			}

			// ���ԖڕW
			if (this._targetSetCd == 10)
			{
				this.ApplyDate_uLabel.Text = "�K�p�N��";
				this.ApplyStaDate_tDateEdit.DateFormat = emDateFormat.df4Y2M;
				this.Range_uLabel.Visible = false;
				this.ApplyEndDate_tDateEdit.Visible = false;
//----- ueno add---------- start 2007.11.21
				this.TargetDivideCode_uLabel.Visible = false;
				this.TargetDivideCode_tEdit.Visible = false;
				this.TargetDivideName_uLabel.Visible = false;
				this.TargetDivideName_tEdit.Visible = false;
//----- ueno add---------- end   2007.11.21
			}
			// �ʊ��ԖڕW
			else
			{
				this.ApplyDate_uLabel.Text = "�K�p����";
				this.ApplyStaDate_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
				this.Range_uLabel.Visible = true;
				this.ApplyEndDate_tDateEdit.Visible = true;
//----- ueno add---------- start 2007.11.21
				this.TargetDivideCode_uLabel.Visible = true;
				this.TargetDivideCode_tEdit.Visible = true;
				this.TargetDivideName_uLabel.Visible = true;
				this.TargetDivideName_tEdit.Visible = true;
//----- ueno add---------- end   2007.11.21
			}

			// �R���g���[��Enabled����
			// �V�K���[�h
			if (this._mode == 0)
			{
				this.Mode_Label.Text = "�V�K";
//----- ueno upd---------- start 2007.11.21
				this.TargetContrastCd_tComboEditor.Enabled = true;
				this.EmployeeDivCd_tComboEditor.Enabled = true;
				
				// �ڕW�Δ�敪�R���{�{�b�N�X�l�Ŕ��肷��
				if (this.TargetContrastCd_tComboEditor.Value != null)
				{
					TargetContrastCdChange((Int32)this.TargetContrastCd_tComboEditor.Value);
				}
				//this.SubSectionCode_tNedit.Enabled = false;
				//this.SubSectionCodeGuide_Button.Enabled = false;
				//this.MinSectionCode_tNedit.Enabled = false;
				//this.MinSectionCodeGuide_Button.Enabled = false;
				//this.EmployeeCode_tEdit.Enabled = true;
				//this.EmployeeCodeGuide_Button.Enabled = true;
//----- ueno upd---------- end   2007.11.21
				this.ApplyStaDate_tDateEdit.Enabled = true;
				this.ApplyEndDate_tDateEdit.Enabled = true;

				// ���ԖڕW
				if (this._targetSetCd == 10)
				{
					this.TargetDivideCode_tEdit.Enabled = false;
					this.TargetDivideName_tEdit.Enabled = false;
				}
				// �ʊ��ԖڕW
				else
				{
					this.TargetDivideCode_tEdit.Enabled = true;
					this.TargetDivideName_tEdit.Enabled = true;
				}

                // ������̐V�K���[�h�������ꍇ
                if (this._searchFlag == true)
                {
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
                    //this.TargetSetCd_uOptionSet.Enabled = false;
                    this.TargetSetCd_tComboEditor.Enabled = false;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
                    this.ApplyStaDate_tDateEdit.Enabled = false;
                    this.ApplyEndDate_tDateEdit.Enabled = false;
                    this.TargetDivideCode_tEdit.Enabled = false;
                    this.TargetDivideName_tEdit.Enabled = false;
                }
                // �����O�̐V�K���[�h�������ꍇ
                else
                {
					this.ApplyStaDate_tDateEdit.Enabled = true;
					this.ApplyEndDate_tDateEdit.Enabled = true;
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
					//this.TargetSetCd_uOptionSet.Enabled = true;
                    this.TargetSetCd_tComboEditor.Enabled = true;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
				}

				if (this._targetContrastCd == (int)SalesTarget.ConstrastCd.Section)
				{
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
                    this.TargetSetCd_tComboEditor.Enabled = false;
                    //this.TargetSetCd_uOptionSet.Enabled = false;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
				}
			}
			// �ҏW���[�h
			else if (this._mode == 1)
			{
				this.Mode_Label.Text = "�ҏW";
				this.ApplyStaDate_tDateEdit.Enabled = false;
				this.ApplyEndDate_tDateEdit.Enabled = false;
//----- ueno add---------- start 2007.11.21
				this.TargetContrastCd_tComboEditor.Enabled = false;
				this.EmployeeDivCd_tComboEditor.Enabled = false;
				this.SubSectionCode_tNedit.Enabled = false;
				this.SubSectionCodeGuide_Button.Enabled = false;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
				//this.MinSectionCode_tNedit.Enabled = false;
				//this.MinSectionCodeGuide_Button.Enabled = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
//----- ueno add---------- end   2007.11.21
				this.EmployeeCode_tEdit.Enabled = false;
				this.EmployeeCodeGuide_Button.Enabled = false;
				this.TargetDivideCode_tEdit.Enabled = false;
				this.TargetDivideName_tEdit.Enabled = false;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
                this.TargetSetCd_tComboEditor.Enabled = false;
                //this.TargetSetCd_uOptionSet.Enabled = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
			}
			else
			{
				this.Mode_Label.Text = "�Q��";
				this.ApplyStaDate_tDateEdit.Enabled = false;
				this.ApplyEndDate_tDateEdit.Enabled = false;
				this.TargetDivideCode_tEdit.Enabled = false;
				this.TargetDivideName_tEdit.Enabled = false;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
                this.TargetSetCd_tComboEditor.Enabled = false;
                //this.TargetSetCd_uOptionSet.Enabled = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
				this.SalesTargetMoney_tNedit.Enabled = false;
				this.SalesTargetProfit_tNedit.Enabled = false;
				this.SalesTargetCount_tNedit.Enabled = false;
				this.Save_Button.Visible = false;
			}
		}

		//----- ueno del---------- start 2007.11.21
		#region del
		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// ��ʏ���������
		///// </summary>
		///// <remarks>
		///// <br>Note		: ��ʂ̏��������s���܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.07.23</br>
		///// </remarks>
		//private void ClearRatioControl()
		//{
		//    this.SalesTargetMoneySunday_tNedit.DataText = "";
		//    this.SalesTargetProfitSunday_tNedit.DataText = "";
		//    this.SalesTargetCountSunday_tNedit.DataText = "";
		//    this.SalesTargetMoneyMonday_tNedit.DataText = "";
		//    this.SalesTargetProfitMonday_tNedit.DataText = "";
		//    this.SalesTargetCou��tMonday_tNedit.DataText = "";
		//    this.SalesTargetMoneyTuesday_tNedit.DataText = "";
		//    this.SalesTargetProfitTuesday_tNedit.DataText = "";
		//    this.SalesTargetCountTuesday_tNedit.DataText = "";
		//    this.SalesTargetMoneyWednesday_tNedit.DataText = "";
		//    this.SalesTargetProfitWednesday_tNedit.DataText = "";
		//    this.SalesTargetCountWednesday_tNedit.DataText = "";
		//    this.SalesTargetMoneyThursday_tNedit.DataText = "";
		//    this.SalesTargetProfitThursday_tNedit.DataText = "";
		//    this.SalesTargetCountThursday_tNedit.DataText = "";
		//    this.SalesTargetMoneyFriday_tNedit.DataText = "";
		//    this.SalesTargetProfitFriday_tNedit.DataText = "";
		//    this.SalesTargetCountFriday_tNedit.DataText = "";
		//    this.SalesTargetMoneySaturday_tNedit.DataText = "";
		//    this.SalesTargetProfitSaturday_tNedit.DataText = "";
		//    this.SalesTargetCountSaturday_tNedit.DataText = "";
		//    this.SalesTargetMoneyHoliday_tNedit.DataText = "";
		//    this.SalesTargetProfitHoliday_tNedit.DataText = "";
		//    this.SalesTargetCountHoliday_tNedit.DataText = "";
		//}
		#endregion del
		//----- ueno del---------- end   2007.11.21

//----- ueno add---------- start 2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ���喼�̎擾����
		/// </summary>
		/// <param name="subSectionCode">����R�[�h</param>
		/// <return>���喼��</return>
		/// <remarks>
		/// Note	   : ���喼�̂��擾���܂��B<br />
		/// Programmer : 30167 ���@�O�M<br />
		/// Date	   : 2007.11.21<br />
		/// </remarks>
		private string GetSubSectionName(int subSectionCode)
		{
			SubSection subSection = null;
			string subSectionName = "";

			SubSectionAcs subSectionAcs = new SubSectionAcs();

			// �f�[�^���݃`�F�b�N
			int ret = subSectionAcs.Read(out subSection, this._enterpriseCode, this._sectionCode, subSectionCode);
			if (ret == 0)
			{
				subSectionName = subSection.SubSectionName;
			}
			return subSectionName;
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ۖ��̎擾����
		/// </summary>
		/// <param name="subSectionCode">����R�[�h</param>
		/// <param name="minSectionCode">�ۃR�[�h</param>
		/// <return>�ۖ���</return>
		/// <remarks>
		/// Note	   : �ۖ��̂��擾���܂��B<br />
		/// Programmer : 30167 ���@�O�M<br />
		/// Date	   : 2007.11.21<br />
		/// </remarks>
		private string GetMinSectionName(int subSectionCode, int minSectionCode)
		{
			MinSection minSection = null;
			string minSectionName = "";

			MinSectionAcs minSectionAcs = new MinSectionAcs();

			// �f�[�^���݃`�F�b�N
			int ret = minSectionAcs.Read(out minSection, this._enterpriseCode, this._sectionCode, subSectionCode, minSectionCode);
			if (ret == 0)
			{
				minSectionName = minSection.MinSectionName;
			}
			return minSectionName;
		}

		/// <summary>
		/// �ڕW�Δ�敪�ύX
		/// </summary>
		/// <param name="targetContrastCd">�ڕW�Δ�敪</param>
		/// <remarks>
		/// <br>Note�@     : �ڕW�Δ�敪�̑I����ύX�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.31</br>
		/// </remarks>
		private void TargetContrastCdChange(int targetContrastCd)
		{
			if (this._targetContrastCd_tComboEditorValue == targetContrastCd) return;
			
			switch(targetContrastCd)
			{
				case (int)SalesTarget.ConstrastCd.SecAndSubSec:					// 20:���_�{����
					{
						this.SubSectionCode_tNedit.Enabled			= true;		// ����R�[�h
						this.SubSectionCodeGuide_Button.Enabled		= true;		// ����K�C�h
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
						//this.MinSectionCode_tNedit.Enabled			= false;	// ��
						//this.MinSectionCodeGuide_Button.Enabled		= false;	// �ۃK�C�h
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
						this.EmployeeCode_tEdit.Enabled				= false;	// �]�ƈ��R�[�h
						this.EmployeeCodeGuide_Button.Enabled		= false;	// �]�ƈ��K�C�h
						
						// ���͕s���ڃN���A
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
						//this.MinSectionCode_tNedit.Clear();
						//this.MinSectionCodeNm_tEdit.Clear();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
						this.EmployeeCode_tEdit.Clear();
						this.EmployeeName_tEdit.Clear();
						break;
					}
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
                //case (int)SalesTarget.ConstrastCd.SecAndSubSecAndMinSec:		// 21:���_�{����{��
                //    {
                //        this.SubSectionCode_tNedit.Enabled			= true;		// ����R�[�h
                //        this.SubSectionCodeGuide_Button.Enabled		= true;		// ����K�C�h
                //        this.MinSectionCode_tNedit.Enabled			= true;		// ��
                //        this.MinSectionCodeGuide_Button.Enabled		= true;		// �ۃK�C�h
                //        this.EmployeeCode_tEdit.Enabled				= false;	// �]�ƈ��R�[�h
                //        this.EmployeeCodeGuide_Button.Enabled		= false;	// �]�ƈ��K�C�h

                //        // ���͕s���ڃN���A
                //        this.EmployeeCode_tEdit.Clear();
                //        this.EmployeeName_tEdit.Clear();
                //        break;
                //    }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
				case (int)SalesTarget.ConstrastCd.SecAndEmp:					// 22:���_�{�]�ƈ�
					{
						this.SubSectionCode_tNedit.Enabled			= false;	// ����R�[�h
						this.SubSectionCodeGuide_Button.Enabled		= false;	// ����K�C�h
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
						//this.MinSectionCode_tNedit.Enabled			= false;	// ��
						//this.MinSectionCodeGuide_Button.Enabled		= false;	// �ۃK�C�h
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
						this.EmployeeCode_tEdit.Enabled				= true;		// �]�ƈ��R�[�h
						this.EmployeeCodeGuide_Button.Enabled		= true;		// �]�ƈ��K�C�h

						// ���͕s���ڃN���A
						this.SubSectionCode_tNedit.Clear();
						this.SubSectionCodeNm_tEdit.Clear();
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
						//this.MinSectionCode_tNedit.Clear();
						//this.MinSectionCodeNm_tEdit.Clear();
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
						break;
					}
			}
			// �I�������ԍ���ێ�
			this._targetContrastCd_tComboEditorValue = targetContrastCd;
		}

//----- ueno add---------- end   2007.11.21

		//----- ueno add---------- start 2008.03.06
		#region �f�[�^�����G���[���b�Z�[�W�o�͏���
		/// <summary>
		/// �f�[�^�����G���[���b�Z�[�W�o�͏���
		/// </summary>
		/// <param name="errMsg">�G���[�����ӏ�</param>
		/// <returns>�쐬���ꂽ�G���[���b�Z�[�W</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�����̃G���[���b�Z�[�W���o�͂��܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.03.06</br>
		/// </remarks>
		private string ShowNotFoundErrMsg(string errMsg)
		{
			_stringBuilder.Remove(0, _stringBuilder.Length);
			_stringBuilder.Append("�w�肳�ꂽ�����ŁA");
			_stringBuilder.Append(errMsg);
			_stringBuilder.Append("�͑��݂��܂���ł����B");
			errMsg = _stringBuilder.ToString();

			return errMsg;
		}
		#endregion �f�[�^�����G���[���b�Z�[�W�o�͏���

		#region ����R�[�h�G���[�`�F�b�N����
		/// <summary>
		/// ����R�[�h�G���[�`�F�b�N����
		/// </summary>
		/// <param name="inParamObj">�����I�u�W�F�N�g</param>
		/// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
		/// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
		/// <remarks>
		/// <br>Note       : ����R�[�h�G���[�`�F�b�N���s���܂��B
		///					 �����I�u�W�F�N�g:���_�R�[�h, ����R�[�h
		///					 ���ʃI�u�W�F�N�g:����}�X�^�������ʃX�e�[�^�X, ���喼��</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.03.06</br>
		/// </remarks>
		private int CheckSubSectionCode(object inParamObj, out object outParamObj)
		{
			outParamObj = null;
			ArrayList outParamList = new ArrayList();
			int ret = (int)InputChkStatus.NotInput;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			ArrayList inParamList = null;
			
			try
			{
				//------------------
				// �K�{���̓`�F�b�N
				//------------------
				if (inParamObj == null)									return ret;
				if ((inParamObj is ArrayList) == false)					return ret;

				inParamList = inParamObj as ArrayList;	// ArrayList�փL���X�g

				if ((inParamList == null) || (inParamList.Count != 2))	return ret;
				if ((inParamList[0] is string) == false)				return ret;
				if ((inParamList[1] is int) == false)					return ret;
				if ((int)inParamList[1] == 0)							return ret;
				
				//--------------
				// ���݃`�F�b�N
				//--------------
				SubSection subSection = null;
						
				this.Cursor = Cursors.WaitCursor;
				status = this._subSectionAcs.Read(out subSection, this._enterpriseCode, (string)inParamList[0], (int)inParamList[1]);
				this.Cursor = Cursors.Default;
				
				outParamList.Add(status);	// ����}�X�^�X�e�[�^�X�ݒ�
				
				if(subSection == null)
				{
					ret = (int)InputChkStatus.NotExist;
				}
				else
				{
					ret = (int)InputChkStatus.Normal;
					outParamList.Add(subSection.SubSectionName);	// ���喼�̐ݒ�
				}
			}
			catch (Exception)
			{
			}
			outParamObj = outParamList;

			return ret;
		}
		#endregion ����R�[�h�G���[�`�F�b�N����

		#region �ۃR�[�h�G���[�`�F�b�N����
		/// <summary>
		/// �ۃR�[�h�G���[�`�F�b�N����
		/// </summary>
		/// <param name="inParamObj">�����I�u�W�F�N�g</param>
		/// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
		/// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
		/// <remarks>
		/// <br>Note       : �ۃR�[�h�̃G���[�`�F�b�N���s���܂��B
		///					 �����I�u�W�F�N�g:���_�R�[�h, ����R�[�h, �ۃR�[�h
		///					 ���ʃI�u�W�F�N�g:�ۃ}�X�^�������ʃX�e�[�^�X, �ۃR�[�h, �ۖ���, ����R�[�h, ���喼��</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.03.06</br>
		/// </remarks>
		private int CheckMinSectionCode(object inParamObj, out object outParamObj)
		{
			outParamObj = null;
			ArrayList outParamList = new ArrayList();
			int ret = (int)InputChkStatus.NotInput;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			ArrayList inParamList = null;

			try
			{
				//------------------
				// �K�{���̓`�F�b�N
				//------------------
				if (inParamObj == null)									return ret;
				if ((inParamObj is ArrayList) == false)					return ret;

				inParamList = inParamObj as ArrayList;	// ArrayList�փL���X�g

				if ((inParamList == null) || (inParamList.Count != 3))	return ret;
				if ((inParamList[0] is string) == false)				return ret;
				if ((inParamList[1] is int) == false)					return ret;
				if ((inParamList[2] is int) == false)					return ret;
				if ((int)inParamList[2] == 0)							return ret;

				//--------------
				// ���݃`�F�b�N
				//--------------
				MinSection minSection = null;

				this.Cursor = Cursors.WaitCursor;
				status = this._minSectionAcs.Read(out minSection, this._enterpriseCode, (string)inParamList[0],
												(int)inParamList[1], (int)inParamList[2]);
				this.Cursor = Cursors.Default;

				outParamList.Add(status);	// �ۃ}�X�^�X�e�[�^�X�ݒ�

				if (minSection == null)
				{
					ret = (int)InputChkStatus.NotExist;
				}
				else
				{
					ret = (int)InputChkStatus.Normal;

					outParamList.Add(minSection.MinSectionCode);	// �ۃR�[�h�ݒ�
					outParamList.Add(minSection.MinSectionName);	// �ۖ��̐ݒ�
					outParamList.Add(minSection.SubSectionCode);	// ����R�[�h�ݒ�
					outParamList.Add(minSection.SubSectionName);	// ���喼�̐ݒ�
				}
			}
			catch (Exception)
			{
			}
			outParamObj = outParamList;

			return ret;
		}
		#endregion �ۃR�[�h�G���[�`�F�b�N����

		#region �]�ƈ��R�[�h�G���[�`�F�b�N����
		/// <summary>
		/// �]�ƈ��R�[�h�G���[�`�F�b�N����
		/// </summary>
		/// <param name="inParamObj">�����I�u�W�F�N�g</param>
		/// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
		/// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
		/// <remarks>
		/// <br>Note       : ���[�J�[�R�[�h�̃G���[�`�F�b�N���s���܂��B
		///					 �����I�u�W�F�N�g:�]�ƈ��R�[�h
		///					 ���ʃI�u�W�F�N�g:�]�ƈ��}�X�^�������ʃX�e�[�^�X, �]�ƈ�����</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.03.06</br>
		/// </remarks>
		private int CheckEmployeeCode(object inParamObj, out object outParamObj)
		{
			outParamObj = null;
			ArrayList outParamList = new ArrayList();
			int ret = (int)InputChkStatus.NotInput;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
			
			try
			{
				//------------------
				// �K�{���̓`�F�b�N
				//------------------
				if (inParamObj == null)					return ret;
				if ((inParamObj is string) == false)	return ret;
				if ((string)inParamObj == "")			return ret;
				
				//--------------
				// ���݃`�F�b�N
				//--------------
				Employee employee = null;

			    this.Cursor = Cursors.WaitCursor;
				status = this._employeeAcs.Read(out employee, this._enterpriseCode, (string)inParamObj);
			    this.Cursor = Cursors.Default;

				outParamList.Add(status);	// �]�ƈ��}�X�^�X�e�[�^�X�ݒ�

				if (employee == null)
				{
					ret = (int)InputChkStatus.NotExist;
				}
				else
				{
					//----- ueno upd ---------- start 2008.03.06
					// �]�ƈ������_�ɏ������Ă��邩�`�F�b�N
					if (employee.BelongSectionCode.TrimEnd() == this._salesTarget.SectionCode.TrimEnd())
					{
						ret = (int)InputChkStatus.Normal;
						outParamList.Add(employee.Name);	// �]�ƈ����̐ݒ�
					}
					else
					{
						ret = (int)InputChkStatus.NotExist;
					}
					//----- ueno upd ---------- end 2008.03.06
				}
			}
			catch(Exception)
			{
			}
			outParamObj = outParamList;
			
			return ret;
		}
		#endregion �]�ƈ��R�[�h�G���[�`�F�b�N����

		#region ����R�[�h�ݒ菈��
		/// <summary>
		/// ����R�[�h�ݒ菈��
		/// </summary>
		/// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
		/// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
		/// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ����R�[�h����ʂɐݒ肵�܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.03.06</br>
		/// </remarks>
		private void DispSetSubSectionCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// �f�[�^�N���A
						{
							this.SubSectionCode_tNedit.Clear();
							this.SubSectionCodeNm_tEdit.Clear();

							// ���݃f�[�^�N���A
							this._subSectionCodeWork = 0;
							
							// �ۃR�[�h�N���A
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
							//this.MinSectionCode_tNedit.Clear();
							//this.MinSectionCodeNm_tEdit.Clear();
							//this._minSectionCodeWork = 0;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END

							//----- ueno upd ---------- start 2008.03.07
							// �t�H�[�J�X
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:		// ���ɖ߂�
						{
							this.SubSectionCode_tNedit.SetInt(this._subSectionCodeWork);

							//----- ueno add ---------- start 2008.03.07
							// �t�H�[�J�X�ړ����Ȃ�
							canChangeFocus = false;
							//----- ueno add ---------- end 2008.03.07
							break;
						}
					case DispSetStatus.Update:	// �X�V
						{
							if ((outParamObj != null) && (outParamObj is ArrayList))
							{
								outParamList = outParamObj as ArrayList;

								if ((outParamList != null)
									&& (outParamList.Count == 2)
									&& (outParamList[1] is string))
								{
									this.SubSectionCodeNm_tEdit.Text = (string)outParamList[1];	// ���喼��
									
									//----------------------------
									// ����R�[�h�ύX�`�F�b�N
									//----------------------------
									if (this._subSectionCodeWork != this.SubSectionCode_tNedit.GetInt())
									{
										// ����R�[�h�ύX���́A�ۃR�[�h�N���A
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
										//this.MinSectionCode_tNedit.Clear();
										//this.MinSectionCodeNm_tEdit.Clear();
										//this._minSectionCodeWork = 0;
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
									}

									// ���݃f�[�^�ۑ�
									this._subSectionCodeWork = this.SubSectionCode_tNedit.GetInt();
								}
							}
							break;
						}
				}
			}
			catch (Exception)
			{
			}
		}
		#endregion ����R�[�h�ݒ菈��

        #region del 2008.07.03
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
        //#region �ۃR�[�h�ݒ菈��
        ///// <summary>
        ///// �ۃR�[�h�ݒ菈��
        ///// </summary>
        ///// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
        ///// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
        ///// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
        ///// <remarks>
        ///// <br>Note       : �ۃR�[�h����ʂɐݒ肵�܂��B</br>
        ///// <br>Programmer : 30167 ���@�O�M</br>
        ///// <br>Date       : 2008.03.06</br>
        ///// </remarks>
        //private void DispSetMinSectionCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
        //{
        //    ArrayList outParamList = null;

        //    try
        //    {
        //        switch (dispSetStatus)
        //        {
        //            case DispSetStatus.Clear:	// �f�[�^�N���A
        //                {
        //                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
        //                    //this.MinSectionCode_tNedit.Clear();
        //                    //this.MinSectionCodeNm_tEdit.Clear();
        //                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END

        //                    // ���݃f�[�^�N���A
        //                    this._minSectionCodeWork = 0;

        //                    //----- ueno upd ---------- start 2008.03.07
        //                    // �t�H�[�J�X
        //                    canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
        //                    //----- ueno upd ---------- end 2008.03.07

        //                    break;
        //                }
        //            case DispSetStatus.Back:		// ���ɖ߂�
        //                {
        //                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
        //                    //this.MinSectionCode_tNedit.SetInt(this._minSectionCodeWork);
        //                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
							
        //                    //----- ueno add ---------- start 2008.03.07
        //                    // �t�H�[�J�X�ړ����Ȃ�
        //                    canChangeFocus = false;
        //                    //----- ueno add ---------- end 2008.03.07
        //                    break;
        //                }
        //            case DispSetStatus.Update:	// �X�V
        //                {
        //                    if ((outParamObj != null) && (outParamObj is ArrayList))
        //                    {
        //                        outParamList = outParamObj as ArrayList;

        //                        if ((outParamList != null)
        //                            && (outParamList.Count == 5)
        //                            && (outParamList[1] is int)
        //                            && (outParamList[2] is string)
        //                            && (outParamList[3] is int)
        //                            && (outParamList[4] is string))
        //                        {
        //                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
        //                            //this.MinSectionCode_tNedit.SetInt((int)outParamList[1]);	// �ۃR�[�h
        //                            //this.MinSectionCodeNm_tEdit.Text = (string)outParamList[2];	// �ۖ���
        //                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
        //                            this.SubSectionCode_tNedit.SetInt((int)outParamList[3]);	// ����R�[�h
        //                            this.SubSectionCodeNm_tEdit.Text = (string)outParamList[4];	// ���喼��

        //                            // ���݃f�[�^�ۑ�
        //                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
        //                            //this._minSectionCodeWork = this.MinSectionCode_tNedit.GetInt();
        //                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
        //                            this._subSectionCodeWork = this.SubSectionCode_tNedit.GetInt();
        //                        }
        //                    }
        //                    break;
        //                }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //    }
        //}
        //#endregion �ۃR�[�h�ݒ菈��
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
        #endregion // del 2008.07.03

        #region �]�ƈ��R�[�h�ݒ菈��
        /// <summary>
		/// �]�ƈ��R�[�h�ݒ菈��
		/// </summary>
		/// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
		/// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
		/// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : �]�ƈ��R�[�h����ʂɐݒ肵�܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.03.06</br>
		/// </remarks>
		private void DispSetEmployeeCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// �f�[�^�N���A
						{
							this.EmployeeCode_tEdit.Clear();
							this.EmployeeName_tEdit.Clear();

							// ���݃f�[�^�N���A
							this._employeeCodeWork = "";

							//----- ueno upd ---------- start 2008.03.07
							// �t�H�[�J�X
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:		// ���ɖ߂�
						{
							this.EmployeeCode_tEdit.DataText = this._employeeCodeWork;

							//----- ueno add ---------- start 2008.03.07
							// �t�H�[�J�X�ړ����Ȃ�
							canChangeFocus = false;
							//----- ueno add ---------- end 2008.03.07
							break;
						}
					case DispSetStatus.Update:	// �X�V
						{
							if ((outParamObj != null) && (outParamObj is ArrayList))
							{
								outParamList = outParamObj as ArrayList;

								if ((outParamList != null)
									&& (outParamList.Count == 2)
									&& (outParamList[1] is string))
								{
									this.EmployeeName_tEdit.DataText = (string)outParamList[1];

									// ���݃f�[�^�ۑ�
									this._employeeCodeWork = this.EmployeeCode_tEdit.DataText;
								}
							}
							break;
						}
				}
			}
			catch (Exception)
			{
			}
		}
		#endregion �]�ƈ��R�[�h�ݒ菈��
		//----- ueno add---------- end 2008.03.06

		# endregion Private Methods

		# region Control Events

//----- ueno add---------- start   2007.11.21

		/// <summary>Control.ChangeFocus �C�x���g</summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note       : �t�H�[�J�X�ړ����ɔ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		private void tArrowKeyControl1_ChangeFocus(object sender, ChangeFocusEventArgs e)
		{
			if ((e.PrevCtrl == null) || (e.NextCtrl == null)) return;

			//----- ueno add---------- start 2008.03.06
			//InputChk inputChk = InputChk.None;

			bool canChangeFocus = true;
			DispSetStatus dispSetStatus = DispSetStatus.Clear;

			object inParamObj = null;
			object outParamObj = null;
			ArrayList inParamList = new ArrayList();
			//----- ueno add---------- end 2008.03.06
			
			switch(e.PrevCtrl.Name)
			{
				#region case �ڕW�ݒ�敪
				case "TargetContrastCd_tComboEditor":
					{
						if (this.TargetContrastCd_tComboEditor.Value != null)
						{
							TargetContrastCdChange((Int32)this.TargetContrastCd_tComboEditor.Value);
						}
						break;
					}
				#endregion
				
				#region case ����R�[�h
				case "SubSectionCode_tNedit":
					{
						// �ύX��������Ώ������Ȃ�
						if (this.SubSectionCode_tNedit.GetInt() == this._subSectionCodeWork)
						{
							break;
						}

						//--------------
						// ���݃`�F�b�N
						//--------------
						//----- ueno add ---------- start 2008.03.06
						// �����ݒ�
						inParamList.Add(this._sectionCode);
						inParamList.Add(this.SubSectionCode_tNedit.GetInt());
						inParamObj = inParamList;
						
						// ���݃`�F�b�N
						switch (CheckSubSectionCode(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
								{
									dispSetStatus = DispSetStatus.Update;
									break;
								}
							case (int)InputChkStatus.NotInput:
								{
									dispSetStatus = DispSetStatus.Clear;
									break;
								}
							default:
								{
									TMsgDisp.Show(
											this, 									// �e�E�B���h�E�t�H�[��
											emErrorLevel.ERR_LEVEL_INFO, 			// �G���[���x��
											this.Name,								// �A�Z���u��ID
											ShowNotFoundErrMsg("����R�[�h"),		// �\�����郁�b�Z�[�W
											0,										// �X�e�[�^�X�l
											MessageBoxButtons.OK);					// �\������{�^��

									dispSetStatus = this._subSectionCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// �f�[�^�ݒ�
						DispSetSubSectionCode(dispSetStatus,  ref canChangeFocus, outParamObj);
						//----- ueno add ---------- end 2008.03.06
						
						#region del 2008.03.06
						//----- ueno del ---------- start 2008.03.06
						//SubSection subSection = null;
						
						//if (this.SubSectionCode_tNedit.DataText != "")
						//{
						//    SubSectionAcs subSectionAcs = new SubSectionAcs();
							
						//    // �f�[�^���݃`�F�b�N
						//    this.Cursor = Cursors.WaitCursor;
						//    int ret = subSectionAcs.Read(out subSection, this._enterpriseCode, this._sectionCode,
						//                    this.SubSectionCode_tNedit.GetInt());
						//    this.Cursor = Cursors.Default;
							
						//    if (ret != 0)
						//    {
						//        string errMessage = "�w�肳�ꂽ�����ŁA����R�[�h�͑��݂��܂���ł����B";
						//        TMsgDisp.Show(
						//                this, 							// �e�E�B���h�E�t�H�[��
						//                emErrorLevel.ERR_LEVEL_INFO, 	// �G���[���x��
						//                this.Name,						// �A�Z���u��ID
						//                errMessage, 					// �\�����郁�b�Z�[�W
						//                0,								// �X�e�[�^�X�l
						//                MessageBoxButtons.OK);			// �\������{�^��

						//        inputChk = this._subSectionCodeWork == 0 ? InputChk.None : InputChk.Back;
						//    }
						//    else
						//    {
						//        inputChk = InputChk.Update;
						//    }
						//}
						//else
						//{
						//    inputChk = InputChk.None;
						//}

						////----------
						//// ���ʐݒ�
						////----------
						//switch (inputChk)
						//{
						//    case InputChk.None:		// �����́A�܂��́A���݂��Ȃ�
						//        {
						//            this.SubSectionCode_tNedit.Clear();
						//            this.SubSectionCodeNm_tEdit.Clear();

						//            // ���݃f�[�^�N���A
						//            this._subSectionCodeWork = 0;

						//            // �t�H�[�J�X
						//            e.NextCtrl = e.PrevCtrl;
						//            break;
						//        }
						//    case InputChk.Back:		// ���ɖ߂�
						//        {
						//            this.SubSectionCode_tNedit.SetInt(this._subSectionCodeWork);
						//            break;
						//        }
						//    case InputChk.Update:	// �X�V
						//        {
						//            this.SubSectionCodeNm_tEdit.DataText = subSection.SubSectionName;

						//            // ���݃f�[�^�ۑ�
						//            this._subSectionCodeWork = this.SubSectionCode_tNedit.GetInt();

						//            // ����R�[�h�ɕR�Â��ۃR�[�h���N���A����
						//            this.MinSectionCode_tNedit.Clear();
						//            this.MinSectionCodeNm_tEdit.Clear();
						//            this._minSectionCodeWork = 0;
						//            break;
						//        }
						//}
						//----- ueno del ---------- start 2008.03.06
						#endregion del 2008.03.06

						break;
					}
				#endregion

                #region del 2008.07.03
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
                //#region case �ۃR�[�h
                //case "MinSectionCode_tNedit":
                //    {
                //        // �ύX��������Ώ������Ȃ�
                //        if (this.MinSectionCode_tNedit.GetInt() == this._minSectionCodeWork)
                //        {
                //            break;
                //        }

                //        //--------------
                //        // ���݃`�F�b�N
                //        //--------------
                //        //----- ueno add ---------- start 2008.03.06
                //        // �����ݒ�
                //        inParamList.Add(this._sectionCode);
                //        inParamList.Add(this.SubSectionCode_tNedit.GetInt());
                //        inParamList.Add(this.MinSectionCode_tNedit.GetInt());
                //        inParamObj = inParamList;

                //        // ���݃`�F�b�N
                //        switch (CheckMinSectionCode(inParamObj, out outParamObj))
                //        {
                //            case (int)InputChkStatus.Normal:
                //                {
                //                    dispSetStatus = DispSetStatus.Update;
                //                    break;
                //                }
                //            case (int)InputChkStatus.NotInput:
                //                {
                //                    dispSetStatus = DispSetStatus.Clear;
                //                    break;
                //                }
                //            default:
                //                {
                //                    TMsgDisp.Show(
                //                            this, 									// �e�E�B���h�E�t�H�[��
                //                            emErrorLevel.ERR_LEVEL_INFO, 			// �G���[���x��
                //                            this.Name,								// �A�Z���u��ID
                //                            ShowNotFoundErrMsg("�ۃR�[�h"), 		// �\�����郁�b�Z�[�W
                //                            0,										// �X�e�[�^�X�l
                //                            MessageBoxButtons.OK);					// �\������{�^��

                //                    dispSetStatus = this._minSectionCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
                //                    break;
                //                }
                //        }
                //        // �f�[�^�ݒ�
                //        DispSetMinSectionCode(dispSetStatus, ref canChangeFocus, outParamObj);
                //        break;
                //        //----- ueno add ---------- end 2008.03.06

                //        #region del 2008.03.06
                //        //----- ueno del ---------- start 2008.03.06
                //        //MinSection minSection = null;

                //        //if (this.MinSectionCode_tNedit.DataText != "")
                //        //{
                //        //    MinSectionAcs minSectionAcs = new MinSectionAcs();

                //        //    // �f�[�^���݃`�F�b�N
                //        //    this.Cursor = Cursors.WaitCursor;
                //        //    int ret = minSectionAcs.Read(out minSection, this._enterpriseCode, this._sectionCode,
                //        //                this.SubSectionCode_tNedit.GetInt(), this.MinSectionCode_tNedit.GetInt());
                //        //    this.Cursor = Cursors.Default;

                //        //    if (ret != 0)
                //        //    {
                //        //        string errMessage = "�w�肳�ꂽ�����ŁA�ۃR�[�h�͑��݂��܂���ł����B";
                //        //        TMsgDisp.Show(
                //        //                this, 							// �e�E�B���h�E�t�H�[��
                //        //                emErrorLevel.ERR_LEVEL_INFO, 	// �G���[���x��
                //        //                this.Name,						// �A�Z���u��ID
                //        //                errMessage, 					// �\�����郁�b�Z�[�W
                //        //                0,								// �X�e�[�^�X�l
                //        //                MessageBoxButtons.OK);			// �\������{�^��

                //        //        inputChk = this._minSectionCodeWork == 0 ? InputChk.None : InputChk.Back;
                //        //    }
                //        //    else
                //        //    {
                //        //        inputChk = InputChk.Update;
                //        //    }
                //        //}
                //        //else
                //        //{
                //        //    inputChk = InputChk.None;
                //        //}

                //        ////----------
                //        //// ���ʐݒ�
                //        ////----------
                //        //switch (inputChk)
                //        //{
                //        //    case InputChk.None:		// �����́A�܂��́A���݂��Ȃ�
                //        //        {
                //        //            this.MinSectionCode_tNedit.Clear();
                //        //            this.MinSectionCodeNm_tEdit.Clear();

                //        //            // ���݃f�[�^�N���A
                //        //            this._minSectionCodeWork = 0;

                //        //            // �t�H�[�J�X
                //        //            e.NextCtrl = e.PrevCtrl;
                //        //            break;
                //        //        }
                //        //    case InputChk.Back:		// ���ɖ߂�
                //        //        {
                //        //            this.MinSectionCode_tNedit.SetInt(this._minSectionCodeWork);
                //        //            break;
                //        //        }
                //        //    case InputChk.Update:	// �X�V
                //        //        {
                //        //            this.MinSectionCodeNm_tEdit.DataText = minSection.MinSectionName;

                //        //            // ���݃f�[�^�ۑ�
                //        //            this._minSectionCodeWork = this.MinSectionCode_tNedit.GetInt();
                //        //            break;
                //        //        }
                //        //}
                //        //----- ueno del ---------- start 2008.03.06
                //        #endregion del 2008.03.06
                //    }
                //#endregion
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
                #endregion // del 2008.07.03

                #region case �]�ƈ��R�[�h
                case "EmployeeCode_tEdit":
					{
						// �ύX��������Ώ������Ȃ�
						if (string.Equals(this.EmployeeCode_tEdit.DataText.TrimEnd(), this._employeeCodeWork) == true)
						{
							break;
						}

						//--------------
						// ���݃`�F�b�N
						//--------------
						//----- ueno add ---------- start 2008.03.06
						// �����ݒ�
						inParamObj = this.EmployeeCode_tEdit.Text;

						// ���݃`�F�b�N
						switch (CheckEmployeeCode(inParamObj, out outParamObj))
						{
							case (int)InputChkStatus.Normal:
								{
									dispSetStatus = DispSetStatus.Update;
									break;
								}
							case (int)InputChkStatus.NotInput:
								{
									dispSetStatus = DispSetStatus.Clear;
									break;
								}
							default:
								{
									TMsgDisp.Show(
											this, 									// �e�E�B���h�E�t�H�[��
											emErrorLevel.ERR_LEVEL_INFO, 			// �G���[���x��
											this.Name,								// �A�Z���u��ID
											ShowNotFoundErrMsg("�]�ƈ��R�[�h"),		// �\�����郁�b�Z�[�W
											0,										// �X�e�[�^�X�l
											MessageBoxButtons.OK);					// �\������{�^��

									dispSetStatus = this._employeeCodeWork == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// �f�[�^�ݒ�
						DispSetEmployeeCode(dispSetStatus, ref canChangeFocus, outParamObj);
						break;
						//----- ueno add ---------- end 2008.03.06
						
						#region del 2008.03.06
						//----- ueno del ---------- start 2008.03.06					
						//Employee employee = null;

						//if (this.EmployeeCode_tEdit.DataText.TrimEnd() != "")
						//{
						//    EmployeeAcs employeeAcs = new EmployeeAcs();

						//    // �f�[�^���݃`�F�b�N
						//    this.Cursor = Cursors.WaitCursor;
						//    int ret = employeeAcs.Read(out employee, this._enterpriseCode, this.EmployeeCode_tEdit.DataText);
						//    this.Cursor = Cursors.Default;

						//    if (ret != 0)
						//    {
						//        string errMessage = "�w�肳�ꂽ�����ŁA�]�ƈ��R�[�h�͑��݂��܂���ł����B";
						//        TMsgDisp.Show(
						//                this, 							// �e�E�B���h�E�t�H�[��
						//                emErrorLevel.ERR_LEVEL_INFO, 	// �G���[���x��
						//                this.Name,						// �A�Z���u��ID
						//                errMessage, 					// �\�����郁�b�Z�[�W
						//                0,								// �X�e�[�^�X�l
						//                MessageBoxButtons.OK);			// �\������{�^��

						//        inputChk = this._employeeCodeWork == "" ? InputChk.None : InputChk.Back;
						//    }
						//    else
						//    {
						//        inputChk = InputChk.Update;
						//    }
						//}
						//else
						//{
						//    inputChk = InputChk.None;
						//}

						////----------
						//// ���ʐݒ�
						////----------
						//switch (inputChk)
						//{
						//    case InputChk.None:		// �����́A�܂��́A���݂��Ȃ�
						//        {
						//            this.EmployeeCode_tEdit.Clear();
						//            this.EmployeeName_tEdit.Clear();

						//            // ���݃f�[�^�N���A
						//            this._employeeCodeWork = "";

						//            // �t�H�[�J�X
						//            e.NextCtrl = e.PrevCtrl;
						//            break;
						//        }
						//    case InputChk.Back:		// ���ɖ߂�
						//        {
						//            this.EmployeeCode_tEdit.DataText = this._employeeCodeWork;
						//            break;
						//        }
						//    case InputChk.Update:	// �X�V
						//        {
						//            this.EmployeeName_tEdit.DataText = employee.Name;

						//            // ���݃f�[�^�ۑ�
						//            this._employeeCodeWork = this.EmployeeCode_tEdit.DataText;
						//            break;
						//        }
						//}
						//----- ueno del ---------- end 2008.03.06
						#endregion del 2008.03.06
					}
				#endregion
			}

			//----- ueno add ---------- start 2008.03.06
			// �t�H�[�J�X����
			if (canChangeFocus == false)
			{
				e.NextCtrl = e.PrevCtrl;

				//----- ueno add ---------- start 2008.03.07
				// ���݂̍��ڂ���ړ������A�e�L�X�g�S�I����ԂƂ���
				e.NextCtrl.Select();
				//----- ueno add ---------- end 2008.03.07
			}
			//----- ueno add ---------- end 2008.03.06
		}
//----- ueno add---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Form_Load �C�x���g����(MAMOK09110UA)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �t�H�[�����[�h�������s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private void MAMOK09110UA_Load(object sender, EventArgs e)
		{
			// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
			this._controlScreenSkin.LoadSkin();

			// ��ʃX�L���ύX
			this._controlScreenSkin.SettingScreenSkin(this);

			// �R���g���[���T�C�Y�ݒ�
			SetControlSize();

			// Nedit�X�^�C���ݒ�
			SetNeditStyle();

//----- ueno add---------- start 2007.11.21

			// �ڕW�Δ�敪�R���{�{�b�N�X�ݒ�
			this.TargetContrastCd_tComboEditor.Items.Clear();
			
			if(SalesTarget._targetContrastCdEmpSList.Count > 0)
			{
				foreach (DictionaryEntry de in SalesTarget._targetContrastCdEmpSList)
				{
					this.TargetContrastCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
				}
				this.TargetContrastCd_tComboEditor.Value = SalesTarget._targetContrastCdEmpSList.GetKey(0);
			}

			// �]�ƈ��敪�R���{�{�b�N�X�ݒ�
			this.EmployeeDivCd_tComboEditor.Items.Clear();

			if (EmpSalesTarget._employeeDivCdSList.Count > 0)
			{
				foreach (DictionaryEntry de in EmpSalesTarget._employeeDivCdSList)
				{
					this.EmployeeDivCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
				}
				this.EmployeeDivCd_tComboEditor.Value = EmpSalesTarget._employeeDivCdSList.GetKey(0);
			}		
//----- ueno add---------- end   2007.11.21

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
            // ���_���̎擾
            SecInfoSet secInfoSet;
            //SecInfoAcs secInfoAcs = new SecInfoAcs();
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();

            // ���_���̂��󂯎����salesTarget�I�u�W�F�N�g�̋��_�R�[�h����擾
            this._sectionCode = this._salesTarget.SectionCode;
            int status = secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, _sectionCode);

            if (secInfoSet != null)
            {
                this._sectionName = secInfoSet.SectionGuideNm.TrimEnd();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

            // �ڕW�ݒ�敪
            this._targetSetCd = this._salesTarget.TargetSetCd;
            // �ڕW�Δ�敪
            this._targetContrastCd = this._salesTarget.TargetContrastCd;

            // �ڕW�f�[�^��ʓW�J
            SalesTargetToScreen(this._salesTarget);

			//----- ueno del---------- start 2007.11.21
			//// �}�X�^�ǂݍ���
			//bool result = LoadMasterTable();
			//if (!result)
			//{
			//    this.Close();
			//    return;
			//}

			// �j���ʔ䗦�\��
            //DispRatioDayOfWeek();
			//----- ueno del---------- end   2007.11.21

			// �R���g���[������
			ControlEnabled();

//----- ueno add---------- start 2007.11.21
			this._targetContrastCd_tComboEditorValue = -1;	// ������
//----- ueno add---------- end   2007.11.21

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
            this.TargetSetCd_tComboEditor.SelectedIndex = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END

			this._targetStaDate = this._salesTarget.ApplyStaDate.Date;
			this._targetEndDate = this._salesTarget.ApplyEndDate.Date;

			//----- ueno del---------- start 2007.11.21		
			// �䗦�v�Z
			//CalcFromRatio();
			//----- ueno del---------- end   2007.11.21
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// FormClosing �C�x���g����(MAMOK09110UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �t�H�[���́~�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.07.31</br>
        /// </remarks>
        private void MAMOK09110UA_FormClosing(object sender, FormClosingEventArgs e)
        {
            SalesTarget salesTarget;
            bool retResult;

            // �C���ڕW�f�[�^�o�b�t�@�ۑ�
            ScreenToSalesTarget(out salesTarget);

            if (salesTarget.Equals(this._salesTarget))
            {
            }
            else
            {
                // ��ʏ�񂪕ύX����Ă����ꍇ�́A�ۑ��m�F���b�Z�[�W��\��
                DialogResult res = TMsgDisp.Show(this,					  // �e�E�B���h�E�t�H�[��
                    emErrorLevel.ERR_LEVEL_SAVECONFIRM, 				  // �G���[���x��
                    this.Name, 											  // �A�Z���u���h�c
                    null, 												  // �\�����郁�b�Z�[�W
                    0, 													  // �X�e�[�^�X�l
                    MessageBoxButtons.YesNoCancel);						  // �\������{�^��

                switch (res)
                {
                    case DialogResult.Yes:
                        {
                            bool bStatus;

                            bStatus = CheckInputData();
                            if (!bStatus)
                            {
                                e.Cancel = true;
                                return;
                            }

							//----- ueno del---------- start 2007.11.21		
							// ���\�b�h�擪�Ŋi�[���Ă���̂ŕs�v
							//// �C����̖ڕW�f�[�^��ۑ�
                            //ScreenToSalesTarget(out salesTarget);
							//----- ueno del---------- end   2007.11.21		

							retResult = SaveSalesTarget(ref salesTarget);
                            if (!retResult)
                            {
                                this.Close_Button.Focus();
                                e.Cancel = true;
                                break;
                            }
                            this.DialogResult = DialogResult.OK;
                            break;
                        }

                    case DialogResult.No:
                        {
                            this.DialogResult = DialogResult.Cancel;
                            break;
                        }

                    case DialogResult.Cancel:
                        {
                            this.Close_Button.Focus();
                            e.Cancel = true;
                            break;
                        }
                }
            }
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
		/// <br>Date		: 2007.04.03</br>
		/// </remarks>
		private void Save_Button_Click(object sender, EventArgs e)
		{

//----- ueno add---------- start 2007.11.21
			SalesTarget salesTarget;

			// �C����ڕW�f�[�^���o�b�t�@�ɕۑ�
			ScreenToSalesTarget(out salesTarget);

			// �ύX�_�`�F�b�N
			if (salesTarget.Equals(this._salesTarget))
			{
				return;
			}
			
			// �`�F�b�N����
			if(!CheckInputData())
			{
				return;
			}
			
//----- ueno add---------- end   2007.11.21

			// �ڕW�f�[�^�ۑ�����
			bool status = SaveSalesTarget(ref salesTarget);
			if (!status)
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
		/// <br>Date		: 2007.04.03</br>
		/// </remarks>
		private void Close_Button_Click(object sender, EventArgs e)
		{
            this.Close();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click �C�x���g����(EmployeeCodeGuide_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �]�ƈ��K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private void EmployeeCodeGuide_Button_Click(object sender, EventArgs e)
		{
			Employee employee;
            
            int status = this._employeeAcs.ExecuteGuid(this._enterpriseCode, false, this._sectionCode, out employee);
			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				this.EmployeeCode_tEdit.DataText = employee.EmployeeCode.TrimEnd();
				this.EmployeeName_tEdit.DataText = employee.Name;
			}
		}

//----- ueno add---------- start 2007.11.21
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click �C�x���g����(SubSectionCodeGuide_Button_Click)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: ����R�[�h�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.11.21</br>
		/// </remarks>
		private void SubSectionCodeGuide_Button_Click(object sender, EventArgs e)
		{
			//----- ueno del ---------- start 2008.03.12
			//string belongSectionCode = "";
			//----- ueno del ---------- end 2008.03.12

			SubSection subSection = new SubSection();

			//----- ueno upd ---------- start 2008.03.12
			int status = this._subSectionAcs.ExecuteGuid(out subSection, this._enterpriseCode, this._sectionCode);
			//----- ueno upd ---------- end 2008.03.12

			if (status != 0) return;

			// �擾�f�[�^�\��
			this.SubSectionCode_tNedit.SetInt(subSection.SubSectionCode);
			this.SubSectionCodeNm_tEdit.DataText = subSection.SubSectionName;
			
			// �O�̕���R�[�h�ƑI����������R�[�h���قȂ�ꍇ
			if (subSection.SubSectionCode != this._subSectionCodeWork)
			{
				// �ۃR�[�h���N���A����
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
				//this.MinSectionCode_tNedit.Clear();
				//this.MinSectionCodeNm_tEdit.Clear();
				//this._minSectionCodeWork = 0;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
			}
			
			// ���݃f�[�^�ۑ�
			this._subSectionCodeWork = this.SubSectionCode_tNedit.GetInt();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click �C�x���g����(MinSectionCodeGuide_Button_Click)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �ۃR�[�h�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.11.21</br>
		/// </remarks>
		private void MinSectionCodeGuide_Button_Click(object sender, EventArgs e)
		{
			//----- ueno del ---------- start 2008.03.12
			//string belongSectionCode = "";
			//----- ueno del ---------- end 2008.03.12

			MinSection minSection = new MinSection();

			//----- ueno upd ---------- start 2008.03.12
			int status = this._minSectionAcs.ExecuteGuid(out minSection, this._enterpriseCode, this._sectionCode);
			//----- ueno upd ---------- end 2008.03.12			
			
			if (status != 0) return;

			// �擾�f�[�^�\��
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
			//this.MinSectionCode_tNedit.SetInt(minSection.MinSectionCode);
			//this.MinSectionCodeNm_tEdit.DataText = minSection.MinSectionName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
			
			this.SubSectionCode_tNedit.SetInt(minSection.SubSectionCode);
			this.SubSectionCodeNm_tEdit.DataText = minSection.SubSectionName;
			
			// ���݃f�[�^�ۑ�
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA DEL START
			//this._minSectionCodeWork = this.MinSectionCode_tNedit.GetInt();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA DEL END
			this._subSectionCodeWork = this.SubSectionCode_tNedit.GetInt();
		}

		/// <summary>
		/// TargetContrastCd_tComboEditor_SelectionChangeCommitted �C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�p�����[�^</param>
		/// <remarks>
		/// <br>Note�@�@�@  : �ڕW�Δ�敪���ω����ꂽ�Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		private void TargetContrastCd_tComboEditor_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.TargetContrastCd_tComboEditor.Value != null)
			{
				TargetContrastCdChange((Int32)this.TargetContrastCd_tComboEditor.Value);
			}
		}
//----- ueno add---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Leave �C�x���g(SalesTarget_tNedit)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �R���g���[���̃t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.05</br>
		/// </remarks>
		private void SalesTarget_tNedit_Leave(object sender, EventArgs e)
		{
            TNedit salesTargetNedit = (TNedit)sender;

            // ���ʖڕW�̏ꍇ
            if (salesTargetNedit == this.SalesTargetCount_tNedit)
            {
                // �����_�����ݒ�
                salesTargetNedit.NumEdit.DecLen = 1;
                if (salesTargetNedit.DataText != "")
                {
                    double salesTargetCount = double.Parse(salesTargetNedit.DataText);
                    salesTargetNedit.DataText = salesTargetCount.ToString();
                }
            }

			//----- ueno del---------- start 2007.11.21		
			// �䗦�v�Z
			//CalcFromRatio();
			//----- ueno del---------- end   2007.11.21
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// Enter �C�x���g(SalesTargetCount_tNedit)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �R���g���[���Ƀt�H�[�J�X�������������ɔ������܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.08.03</br>
        /// </remarks>
        private void SalesTargetCount_tNedit_Enter(object sender, EventArgs e)
        {
            // �����_�����ݒ�
            this.SalesTargetCount_tNedit.NumEdit.DecLen = 0;
            if (this.SalesTargetCount_tNedit.DataText != "")
            {
                double salesTargetCount = double.Parse(this.SalesTargetCount_tNedit.DataText);
                this.SalesTargetCount_tNedit.DataText = salesTargetCount.ToString(FORMAT_NUM);
            }
        }

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Leave �C�x���g(ApplyStaDate_tDateEdit)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �R���g���[���̃t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.17</br>
		/// </remarks>
		private void ApplyStaDate_tDateEdit_Leave(object sender, EventArgs e)
		{
			bool bStatus;

			// ���ԖڕW
			if (this._targetSetCd == 10)
			{
				if (this.ApplyStaDate_tDateEdit.GetDateYear() == 0 ||
					this.ApplyStaDate_tDateEdit.GetDateMonth() == 0)
				{
					this.TargetDivideCode_tEdit.DataText = "";

					//----- ueno del---------- start 2007.11.21
					//ClearRatioControl();
					//----- ueno del---------- end   2007.11.21
					return;
				}

				// ���t�`�F�b�N
				bStatus = CheckDate();
				if (!bStatus)
				{
					return;
				}

                this._targetStaDate = new DateTime(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth(), 1);
                this.ApplyStaDate_tDateEdit.SetDateTime(this._targetStaDate);

				this.TargetDivideCode_tEdit.DataText = this.ApplyStaDate_tDateEdit.GetDateYear().ToString("0000") +
													   this.ApplyStaDate_tDateEdit.GetDateMonth().ToString("00");

				int days = DateTime.DaysInMonth(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth());
				this._targetEndDate = new DateTime(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth(), days);
				this.ApplyEndDate_tDateEdit.SetDateTime(this._targetEndDate);
			}
			// �ʊ��ԖڕW
			else
			{
                if (this.ApplyStaDate_tDateEdit.GetDateYear() == 0 ||
                    this.ApplyStaDate_tDateEdit.GetDateMonth() == 0 ||
                    this.ApplyStaDate_tDateEdit.GetDateDay() == 0)
                {
					//----- ueno del---------- start 2007.11.21
					//ClearRatioControl();
					//----- ueno del---------- end   2007.11.21
                    return;
                }

				// ���t�`�F�b�N
				bStatus = CheckDate();
				if (!bStatus)
				{
					return;
				}

				this._targetStaDate = this.ApplyStaDate_tDateEdit.GetDateTime();
			}

			//----- ueno del---------- start 2007.11.21		
			// �䗦�v�Z
			//CalcFromRatio();
			//----- ueno del---------- end   2007.11.21
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Leave �C�x���g(ApplyEndDate_tDateEdit)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �R���g���[���̃t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.17</br>
		/// </remarks>
		private void ApplyEndDate_tDateEdit_Leave(object sender, EventArgs e)
		{
			bool bStatus;
            if (this.ApplyEndDate_tDateEdit.GetDateYear() == 0 ||
                this.ApplyEndDate_tDateEdit.GetDateMonth() == 0 ||
                this.ApplyEndDate_tDateEdit.GetDateDay() == 0)
            {
				//----- ueno del---------- start 2007.11.21
				//ClearRatioControl();
				//----- ueno del---------- end   2007.11.21
                return;
            }

			// ���t�`�F�b�N
			bStatus = CheckDate();
			if (!bStatus)
			{
				return;
			}

			this._targetEndDate = this.ApplyEndDate_tDateEdit.GetDateTime();

			//----- ueno del---------- start 2007.11.21		
			// �䗦�v�Z
			//CalcFromRatio();
			//----- ueno del---------- end   2007.11.21
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Leave �C�x���g(EmployeeCode_tEdit)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �R���g���[���̃t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.18</br>
		/// </remarks>
		private void EmployeeCode_tEdit_Leave(object sender, EventArgs e)
		{
			//----- ueno del---------- start 2007.11.21
			//string employeeCode = this.EmployeeCode_tEdit.DataText.TrimEnd();
			//if (employeeCode == "")
			//{
			//    this.EmployeeName_tEdit.DataText = "";
			//    return;
			//}
			
			//int status = SearchEmployee(employeeCode);
			//----- ueno del---------- end   2007.11.21
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// ValueChanged �C�x���g����(TargetDivideCode_uOptionSet)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �ڕW�ݒ�敪�̃`�F�b�N��ύX�������ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.16</br>
		/// </remarks>
		private void TargetDivideCode_uOptionSet_ValueChanged(object sender, EventArgs e)
		{
			// ���ԖڕW
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
            if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
            //if ((int)this.TargetSetCd_uOptionSet.Value == 10)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
			{
				this._targetSetCd = 10;
			}
			// �ʖڕW
			else
			{
				this._targetSetCd = 20;
			}

			// �R���g���[������
			ControlEnabled();

			this.ApplyStaDate_tDateEdit.SetDateTime(new DateTime());
			this.ApplyEndDate_tDateEdit.SetDateTime(new DateTime());
			this.TargetDivideCode_tEdit.DataText = "";
			this.TargetDivideName_tEdit.DataText = "";
			this._targetStaDate = new DateTime();
			this._targetEndDate = new DateTime();
            this.SalesTargetMoney_tNedit.DataText = "";
            this.SalesTargetProfit_tNedit.DataText = "";
            this.SalesTargetCount_tNedit.DataText = "";

			//----- ueno del---------- start 2007.11.21
			//ClearRatioControl();
			//----- ueno del---------- end   2007.11.21
		}

		# endregion Control Events

	}
}