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
	/// ���Ӑ�ڕW���͉��
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���Ӑ�ڕW���͂��s����ʂł��B</br>
	/// <br>Programmer	: 30167 ���@�O�M</br>
	/// <br>Date		: 2007.11.21</br>
	/// <br>Update Note : 2008.03.03 30167 ���@�O�M</br>
	/// <br>			  ���ڃ[�����ߑΉ��i��ʃf�U�C���ɃR���|�[�l���g�ǉ��A
	///					  Tedit�ATNedit�̐ݒ�ύX�j</br>
	/// <br>Update Note : 2008.03.06 30167 ���@�O�M</br>
	///	<br>		 	  �V���[�g�J�b�g�L�[�G���[�`�F�b�N�Ή��ǉ�</br>
	/// <br>Update Note: 2008.03.07 30167 ���@�O�M</br>
	///					  ���ڃN���A��G���^�[�L�[�Ŏ����ڂֈړ�����悤�C��</br>
	/// </remarks>
	public partial class DCKHN09190UA : Form
	{
		# region Private Constants

		// PG����
		private const string ctPGNM = "���Ӑ�ڕW����";

		//----- ueno del---------- start 2007.11.21
		// �䗦
        //private const string RATIO_DEFAULT = "1.00";
		//----- ueno del---------- end   2007.11.21

        // ����
        private const string FORMAT_NUM = "###,##0";
        private const string FORMAT_NUM_DECIMAL = "N1";

		// ���_�ڕW�p�]�ƈ��R�[�h
		private const string EMPLOYEECODE_SECTION = "SECTION";

		private const int GUIDEDIVCD_BUSINESSTYPECODE = 33;	// ���[�U�[�K�C�h�敪�i�Ǝ�R�[�h�j
		private const int GUIDEDIVCD_SALESAREACODE = 21;	// ���[�U�[�K�C�h�敪�i�̔��G���A�R�[�h�j

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

		// ���Ӑ�R�[�h�i���[�N�j
		private int _customerCodeWork = 0;

		// �ڕW�Δ�敪���[�N
		private int _targetContrastCd_tComboEditorValue = -1;

		//----- ueno add---------- start 2008.03.06
		// �����񌋍��p
		private StringBuilder _stringBuilder = null;
		//----- ueno add---------- end 2008.03.06

		//----- ueno del---------- start 2007.11.21
		//// �x�Ɠ��ݒ�}�X�^
		//private Dictionary<SectionAndDate, HolidaySetting> _holidaySettingDic;

		//// ���n�v�Z�䗦���X�g
		//private List<LdgCalcRatioMng> _ldgCalcRatioMngList;
		//----- ueno del---------- end   2007.11.21

		// �ڕW�ݒ�敪
		private int _targetSetCd;

		// ���ԁi�J�n�j
		private DateTime _targetStaDate;
		// ���ԁi�I���j
		private DateTime _targetEndDate;

		// ���[�h(�V�K or �ҏW)
		private int _mode;

		private bool _searchFlag;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
        // ���_�R�[�h�A�N�Z�X�N���X
        // ���_�A�N�Z�X�N���X
        private SecInfoSetAcs _secInfoSetAcs = null;

        // ���[�U�[�K�C�h�A�N�Z�X�N���X�K�C�h�萔
        private int BUSINESS_TYPE_GUIDE = 33;   // �Ǝ�R�[�h
        private int SALES_AREA_GUIDE = 21;      // �̔��G���A
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END

		//----- ueno add---------- start 2008.03.06
		// ���Ӑ�A�N�Z�X�N���X
		private CustomerInfoAcs _customerInfoAcs = null;
		//----- ueno add---------- end 2008.03.06

		// ���[�U�[�K�C�h�A�N�Z�X�N���X
		private UserGuideAcs _userGuideAcs = null;

		// ���[�U�[�K�C�h�f�[�^�i�[�p�i�Ǝ�R�[�h�j
		private SortedList _businessTypeCodeSList = null;

		// ���[�U�[�K�C�h�f�[�^�i�[�p�i�̔��G���A�R�[�h�j
		private SortedList _salesAreaCodeSList = null;
		
		/// <summary>��ʃf�U�C���ύX�N���X</summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		# endregion Private Members

		# region Constructor

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public DCKHN09190UA()
		{
			InitializeComponent();

			// ��ƃR�[�h���擾
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

			// ���_���̎擾
			//SecInfoSet secInfoSet;
			//SecInfoAcs secInfoAcs = new SecInfoAcs();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA MODIFY START
			//secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
            //this._sectionCode = secInfoSet.SectionCode;
            // ���_���̂��󂯎����salesTarget�I�u�W�F�N�g�̋��_�R�[�h����擾
            //this._sectionCode = this._salesTarget.SectionCode;
            //secInfoAcs.GetSecInfo(_sectionCode, out secInfoSet);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA MODIFY END

            //this._sectionName = secInfoSet.SectionGuideNm.TrimEnd();

			this._salesTargetAcs = new SalesTargetAcs();

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
            // ���_�A�N�Z�X�N���X
            this._secInfoSetAcs = new SecInfoSetAcs();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END

			//----- ueno add---------- start 2008.03.06
			this._customerInfoAcs = new CustomerInfoAcs();	// ���Ӑ�A�N�Z�X�N���X
			//----- ueno add---------- end 2008.03.06

			this._userGuideAcs = new UserGuideAcs();		// ���[�U�[�K�C�h�A�N�Z�X�N���X

			// ���[�U�[�K�C�h�f�[�^�i�[�p�i�Ǝ�R�[�h�j
			this._businessTypeCodeSList = new SortedList();

			// ���[�U�[�K�C�h�f�[�^�i�[�p�i�̔��G���A�R�[�h�j
			this._salesAreaCodeSList = new SortedList();

			// �A�C�R���摜�̐ݒ�

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
            // �Ǝ�R�[�h�K�C�h�{�^��
            this.BusinessTypeCodeGuide_ultraButton.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            // �̔��G���A�R�[�h�K�C�h�{�^��
            this.SalesAreaCodeGuide_ultraButton.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END

			// ���Ӑ�R�[�h�K�C�h�{�^��
			this.CustomerCodeGuide_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

			// �I���{�^��
			this.Close_Button.Appearance.Image
				= IconResourceManagement.ImageList24.Images[(int)Size24_Index.CLOSE];
			// �ۑ��{�^��
			this.Save_Button.Appearance.Image
				= IconResourceManagement.ImageList24.Images[(int)Size24_Index.SAVE];

			//----- ueno add---------- start 2008.03.06
			// �����񌋍��p
			this._stringBuilder = new StringBuilder();
			//----- ueno add---------- end 2008.03.06
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
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
		/// <br>Programer		 :	 30167 ���@�O�M</br>
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
		///// <br>Programmer	: 30167 ���@�O�M</br>
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
		///// <br>Programmer	: 30167 ���@�O�M</br>
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
		///// <br>Programmer	: 30167 ���@�O�M</br>
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

		///*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �䗦����v�Z����
		///// </summary>
		///// <remarks>
		///// <br>Note		: ����P�ʂ̖ڕW��䗦����v�Z���܂��B</br>
		///// <br>Programmer	: 30167 ���@�O�M</br>
		///// <br>Date		: 2007.11.21</br>
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
		/// �Ώۊ��Ԑݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���Ԃ̐ݒ���s���܂��B</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.11.21</br>
		/// </remarks>
		private void SetTargetDate()
		{
			// ���ԖڕW
			if (this._targetSetCd == 10)
			{
				if (this.ApplyStaDate_tDateEdit.GetDateTime() == DateTime.MinValue)
				{
					return;
				}

				this._targetStaDate = new DateTime(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth(), 1);
				int days = DateTime.DaysInMonth(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth());
				this._targetEndDate = new DateTime(ApplyStaDate_tDateEdit.GetDateYear(), ApplyStaDate_tDateEdit.GetDateMonth(), days);
			}
			// �ʊ��ԖڕW
			else
			{
				if (this.ApplyStaDate_tDateEdit.GetDateTime() == DateTime.MinValue ||
				this.ApplyEndDate_tDateEdit.GetDateTime() == DateTime.MinValue)
				{
					return;
				}

				this._targetStaDate = this.ApplyStaDate_tDateEdit.GetDateTime();
				this._targetEndDate = this.ApplyEndDate_tDateEdit.GetDateTime();
			}
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �ڕW�f�[�^��ʓW�J����
		/// </summary>
		/// <param name="salesTarget">�ڕW�f�[�^</param>
		/// <remarks>
		/// Note	   : �C���Ώۂ̖ڕW�f�[�^����ʂɓW�J���܂��B<br />
		/// Programmer : 30167 ���@�O�M<br />
		/// Date	   : 2007.04.03<br />
		/// </remarks>
		private void SalesTargetToScreen(SalesTarget salesTarget)
		{
			// �ڕW�Δ�敪
			if (salesTarget.TargetContrastCd != 0)
			{
				this.TargetContrastCd_tComboEditor.Value = (int)salesTarget.TargetContrastCd;
			}
		
			// �ڕW�ݒ�敪
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
            if (salesTarget.TargetSetCd == 10)
            {
                this.TargetSetCd_tComboEditor.SelectedIndex = 0;
            }
            else
            {   
                this.TargetSetCd_tComboEditor.SelectedIndex = 1;// salesTarget.TargetSetCd;
            }
            //this.TargetSetCd_uOptionSet.Value = salesTarget.TargetSetCd;
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
			
			// �Ǝ�R���{�{�b�N�X
			if (salesTarget.BusinessTypeCode != 0)
			{
				this.BusinessTypeCode_tNedit.SetInt(salesTarget.BusinessTypeCode);
                this.BusinessTypeName_tEdit.DataText = salesTarget.BusinessTypeName;
			}
			// �̔��G���A�R���{�{�b�N�X
			if (salesTarget.SalesAreaCode != 0)
			{
				this.SalesAreaCode_tNedit.SetInt(salesTarget.SalesAreaCode);
                this.SalesAreaName_tEdit.DataText = salesTarget.SalesAreaName;
			}
			// ���Ӑ�R�[�h
			this.CustomerCode_tNedit.SetInt(salesTarget.CustomerCode);

			// ���Ӑ於��
			this.CustomerCodeNm_tEdit.DataText = GetCustomerName(salesTarget.CustomerCode);

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
		/// Programmer : 30167 ���@�O�M<br />
		/// Date	   : 2007.11.21<br />
		/// </remarks>
		private void ScreenToSalesTarget(out SalesTarget salesTarget)
		{
			salesTarget = this._salesTarget.Clone();

            // �ڕW�Δ�敪
			if (this.TargetContrastCd_tComboEditor.Value != null)
			{
				salesTarget.TargetContrastCd = (int)this.TargetContrastCd_tComboEditor.Value;
			}

			// �ڕW�ݒ�敪
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
            salesTarget.TargetSetCd = int.Parse(TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString());
            //salesTarget.TargetSetCd = (int)TargetSetCd_uOptionSet.Value;
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

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
			// �Ǝ�R�[�h
            int businessTypeCode = this.BusinessTypeCode_tNedit.GetInt();
            if (businessTypeCode != 0)
            {
                salesTarget.BusinessTypeCode = businessTypeCode;
                salesTarget.BusinessTypeName = this.BusinessTypeName_tEdit.DataText;
            }
            //if (this.BusinessTypeCode_tComboEditor.Value != null)
            //{
            //    salesTarget.BusinessTypeCode = (int)this.BusinessTypeCode_tComboEditor.Value;
            //}

			// �̔��G���A�R�[�h
            int salesAreaCode = this.SalesAreaCode_tNedit.GetInt();
            if (salesAreaCode != 0)
            {
                salesTarget.SalesAreaCode = salesAreaCode;
                salesTarget.SalesAreaName = this.SalesAreaName_tEdit.DataText;
            }
            //if (this.SalesAreaCode_tComboEditor.Value != null)
            //{
            //    salesTarget.SalesAreaCode = (int)this.SalesAreaCode_tComboEditor.Value;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END

			
			// ���Ӑ�R�[�h
			if (this.CustomerCode_tNedit.DataText != "")
			{
				salesTarget.CustomerCode = Int32.Parse(this.CustomerCode_tNedit.DataText);
			}

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
		/// ���Ӑ於�̎擾����
		/// </summary>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <return>���Ӑ於��</return>
		/// <remarks>
		/// Note	   : ���Ӑ於�̂��擾���܂��B<br />
		/// Programmer : 30167 ���@�O�M<br />
		/// Date	   : 2007.11.21<br />
		/// </remarks>
		private string GetCustomerName(int customerCode)
		{
			CustomerInfo customerInfo = null;
			CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
			string customerName = "";

            if (customerCode != 0)
            {
                // �f�[�^���݃`�F�b�N
                int ret = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode,
                                customerCode, out customerInfo);
                if (ret == 0)
                {
                    customerName = customerInfo.Name;
                }
            }

			return customerName;
		}
		
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �C���ڕW�f�[�^�`�F�b�N����
		/// </summary>
		/// <remarks>
		/// Note	   : �C���ڕW�f�[�^���`�F�b�N���܂��B<br />
		/// Programmer : 30167 ���@�O�M<br />
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

				// �ڕW�Δ�敪�ɂ��`�F�b�N�ύX
				switch((int)this.TargetContrastCd_tComboEditor.Value)
				{
					case (int)SalesTarget.ConstrastCd.SecAndCust:				// 30:���_�{���Ӑ�
						{
							// ���Ӑ�R�[�h
							if ((this.CustomerCode_tNedit.DataText == "") || (this.CustomerCode_tNedit.GetInt() == 0))
							{
								errMsg = "���Ӑ�R�[�h����͂��Ă�������";
								this.CustomerCode_tNedit.Focus();

								//----- ueno add---------- start 2008.03.06
								this.CustomerCodeNm_tEdit.Clear();	// ���Ӑ於�̃N���A
								this._customerCodeWork = 0;			// ���Ӑ�R�[�h���[�N�N���A
								//----- ueno add---------- end 2008.03.06
								
								return (false);
							}
							break;
						}
					case (int)SalesTarget.ConstrastCd.SecAndBusinessType:		// 31:���_�{�Ǝ�
						{
							// �Ǝ�R�[�h
							if (this.BusinessTypeCode_tNedit.DataText != null)
							{
								if((int.Parse(this.BusinessTypeCode_tNedit.DataText)) == 0)
								{
									errMsg = "�Ǝ�R�[�h��I�����Ă�������";
                                    this.BusinessTypeCode_tNedit.Focus();
									return (false);
								}
							}
							else
							{
								errMsg = "�Ǝ�R�[�h�����݂��܂���";
                                this.BusinessTypeCode_tNedit.Focus();
								return (false);
							}
							break;
						}
					case (int)SalesTarget.ConstrastCd.SecAndSalesArea:			// 32:���_�{�̔��G���A
						{
							// �̔��G���A�R�[�h
							if (this.SalesAreaCode_tNedit.DataText != null)
							{
                                if ((int.Parse(this.SalesAreaCode_tNedit.DataText)) == 0)
								{
									errMsg = "�̔��G���A�R�[�h��I�����Ă�������";
                                    this.SalesAreaCode_tNedit.Focus();
									return (false);
								}
							}
							else
							{
								errMsg = "�̔��G���A�R�[�h�����݂��܂���";
                                this.SalesAreaCode_tNedit.Focus();
								return (false);
							}
							break;
						}
				}

				//----- ueno add---------- start 2008.03.06
				DispSetStatus dispSetStatus = DispSetStatus.Clear;

				bool canChangeFocus = true;
				object inParamObj = null;
				object outParamObj = null;
				ArrayList inParamList = null;

				//------------------------
				// ���Ӑ�R�[�h�`�F�b�N
				//------------------------
				if (this.CustomerCode_tNedit.Enabled == true)
				{
					// �����ݒ�N���A
					inParamObj = null;
					outParamObj = null;
					inParamList = new ArrayList();

					dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p
					
					// �����ݒ�
					inParamObj = this.CustomerCode_tNedit.GetInt();

					// ���݃`�F�b�N
					switch (CheckCustomerCode(inParamObj, out outParamObj))
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
								errMsg = ShowNotFoundErrMsg("���Ӑ�R�[�h");
								dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
								break;
							}
					}
					// �f�[�^�ݒ�
					DispSetCustomerCode(dispSetStatus, ref canChangeFocus, outParamObj);

					if (dispSetStatus != DispSetStatus.Update)
					{
						this.CustomerCode_tNedit.Focus();
						return false;
					}
				}
				//----- ueno add---------- end 2008.03.06
				
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
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.11.21</br>
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
		/// Programmer : 30167 ���@�O�M<br />
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

			//// �C����̃f�[�^���o�b�t�@�ɕۑ�
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
		////*----------------------------------------------------------------------------------*/
		///// <summary>
		///// �j���ʔ䗦�\������
		///// </summary>
		///// <remarks>
		///// <br>Note		: �j���ʂ̔䗦����ʂɕ\�����܂��B</br>
		///// <br>Programmer	: 30167 ���@�O�M</br>
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
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.11.22</br>
		/// </remarks>
		private void SetControlSize()
		{
			//----- ueno del ---------- start 2008.03.06
			//-- ��ʂ̐ݒ�͑S�ĉ�ʃf�U�C���ōs���̂ňȉ��폜
			//this.SectionName_tEdit.Size = new Size(179, 24);
			//this.TargetDivideCode_tEdit.Size = new Size(84, 24);
			//this.TargetDivideName_tEdit.Size = new Size(290, 24);
			//this.BusinessTypeCode_tComboEditor.Size = new Size(144, 24);
			//this.SalesAreaCode_tComboEditor.Size = new Size(144, 24);
			//this.CustomerCode_tNedit.Size = new Size(92, 24);
			//this.CustomerCodeNm_tEdit.Size = new Size(226, 24);
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
		/// <br>Programmer	: 30167 ���@�O�M</br>
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
			//this.CustomerCode_tNedit.MaxLength = 9;
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
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private void ControlEnabled()
		{
			// ���ԖڕW
			if (this._targetSetCd == 10)
			{
				this.ApplyDate_uLabel.Text = "�K�p�N��";
				this.ApplyStaDate_tDateEdit.DateFormat = emDateFormat.df4Y2M;
				this.Range_uLabel.Visible = false;
				this.ApplyEndDate_tDateEdit.Visible = false;
				this.TargetDivideCode_uLabel.Visible = false;
				this.TargetDivideCode_tEdit.Visible = false;
				this.TargetDivideName_uLabel.Visible = false;
				this.TargetDivideName_tEdit.Visible = false;
			}
			// �ʊ��ԖڕW
			else
			{
				this.ApplyDate_uLabel.Text = "�K�p����";
				this.ApplyStaDate_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
				this.Range_uLabel.Visible = true;
				this.ApplyEndDate_tDateEdit.Visible = true;
				this.TargetDivideCode_uLabel.Visible = true;
				this.TargetDivideCode_tEdit.Visible = true;
				this.TargetDivideName_uLabel.Visible = true;
				this.TargetDivideName_tEdit.Visible = true;
			}

			// �R���g���[��Enabled����
			// �V�K���[�h
			if (this._mode == 0)
			{
				this.Mode_Label.Text = "�V�K";

				// �ڕW�Δ�敪�R���{�{�b�N�X�l�Ŕ��肷��
				if (this.TargetContrastCd_tComboEditor.Value != null)
				{
					TargetContrastCdChange((Int32)this.TargetContrastCd_tComboEditor.Value);
				}

				// ����
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
                // ���ڃL���X�g�ł͂Ȃ��p�[�X�����Ȃ��ƃG���[�ƂȂ�
                if (int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString()) == 10)
                //if ((int)this.TargetSetCd_uOptionSet.Value == 10)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
				{
					this.TargetDivideCode_tEdit.Enabled = false;
					this.TargetDivideName_tEdit.Enabled = false;
				}
				// ��
				else
				{
					this.TargetDivideCode_tEdit.Enabled = true;
					this.TargetDivideName_tEdit.Enabled = true;
				}

				// ������̐V�K���[�h�������ꍇ
				if (this._searchFlag == true)
				{

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
                    this.TargetSetCd_tComboEditor.Enabled = false;
                    //this.TargetSetCd_uOptionSet.Enabled = false;
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
                    this.TargetSetCd_tComboEditor.Enabled = true;
                    //this.TargetSetCd_uOptionSet.Enabled = true;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA MODIFY END
				}
			}
			// �ҏW���[�h
			else
			{
				this.Mode_Label.Text = "�ҏW";
				this.TargetContrastCd_tComboEditor.Enabled = false;
				this.BusinessTypeCode_tNedit.Enabled = false;
                this.SalesAreaCode_tNedit.Enabled = false;
				this.CustomerCode_tNedit.Enabled = false;
				this.CustomerCodeGuide_Button.Enabled = false;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
                this.SalesAreaCodeGuide_ultraButton.Enabled = false;
                this.BusinessTypeCodeGuide_ultraButton.Enabled = false;
                this.TargetSetCd_tComboEditor.Enabled = false;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END
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
		///// <br>Programmer	: 30167 ���@�O�M</br>
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

				#region case ���Ӑ�R�[�h
				case "CustomerCode_tNedit":
					{
						// �ύX��������Ώ������Ȃ�
						if (this.CustomerCode_tNedit.GetInt() == this._customerCodeWork)
						{
							break;
						}

						//--------------
						// ���݃`�F�b�N
						//--------------
						//----- ueno add ---------- start 2008.03.06
						// �����ݒ�
						inParamObj = this.CustomerCode_tNedit.GetInt();

						// ���݃`�F�b�N
						switch (CheckCustomerCode(inParamObj, out outParamObj))
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
											ShowNotFoundErrMsg("���Ӑ�R�[�h"), 	// �\�����郁�b�Z�[�W
											0,										// �X�e�[�^�X�l
											MessageBoxButtons.OK);					// �\������{�^��
									
									dispSetStatus = this._customerCodeWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// �f�[�^�ݒ�
						DispSetCustomerCode(dispSetStatus, ref canChangeFocus, outParamObj);
						//----- ueno add ---------- end 2008.03.06

						#region del 2008.03.06
						//----- ueno del ---------- start 2008.03.06
						//CustomerInfo customerInfo = null;
						
						//if (this.CustomerCode_tNedit.DataText != "")
						//{
						//    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();
							
						//    // �f�[�^���݃`�F�b�N
						//    this.Cursor = Cursors.WaitCursor;
						//    int ret = customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode,
						//                    this.CustomerCode_tNedit.GetInt(), out customerInfo);
						//    this.Cursor = Cursors.Default;

						//    if(ret == 0)
						//    {
						//        // ���̓f�[�^�����Ӑ�łȂ��ꍇ
						//        if (customerInfo.IsCustomer == false)
						//        {
						//            // �G���[
						//            ret = -1;
						//        }
						//    }

						//    if (ret != 0)
						//    {
						//        string errMessage = "�w�肳�ꂽ�����ŁA���Ӑ�R�[�h�͑��݂��܂���ł����B";
						//        TMsgDisp.Show(
						//                this, 							// �e�E�B���h�E�t�H�[��
						//                emErrorLevel.ERR_LEVEL_INFO, 	// �G���[���x��
						//                this.Name,						// �A�Z���u��ID
						//                errMessage, 					// �\�����郁�b�Z�[�W
						//                0,								// �X�e�[�^�X�l
						//                MessageBoxButtons.OK);			// �\������{�^��

						//        inputChk = this._customerCodeWork == 0 ? InputChk.None : InputChk.Back;
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
						//            this.CustomerCode_tNedit.Clear();
						//            this.CustomerCodeNm_tEdit.Clear();
									
						//            // ���݃f�[�^�N���A
						//            this._customerCodeWork = 0;

						//            // �t�H�[�J�X
						//            e.NextCtrl = e.PrevCtrl;
						//            break;
						//        }
						//    case InputChk.Back:		// ���ɖ߂�
						//        {
						//            this.CustomerCode_tNedit.SetInt(this._customerCodeWork);
						//            break;
						//        }
						//    case InputChk.Update:	// �X�V
						//        {
						//            this.CustomerCodeNm_tEdit.DataText = customerInfo.Name;

						//            // ���݃f�[�^�ۑ�
						//            this._customerCodeWork = this.CustomerCode_tNedit.GetInt();
						//            break;
						//        }
						//}
						//----- ueno del ---------- end 2008.03.06
						#endregion del 2008.03.06

						break;
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

		/// <summary>
		/// ���[�U�[�K�C�h�}�X�^�{�f�B�����X�g�擾����
		/// </summary>
		/// <returns>STATUS [0:�擾 0�ȊO:�擾���s]</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�}�X�^�{�f�B���̃��X�g���擾���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		public int GetUserGdBdList(out ArrayList userGdBdList, int guideDivCode)
		{
			userGdBdList = null;
			int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

			try
			{
				status = this._userGuideAcs.SearchAllDivCodeBody(out userGdBdList, this._enterpriseCode, guideDivCode, UserGuideAcsData.UserBodyData);
			}
			catch (Exception e)
			{
				TMsgDisp.Show(
					emErrorLevel.ERR_LEVEL_STOPDISP,
					this.ToString(),
					"���[�U�[�K�C�h�i�w�b�_�j���̎擾�Ɏ��s���܂����B" + "\r\n" + e.Message,
					-1,
					MessageBoxButtons.OK);

				status = -1;
			}
			return status;
		}

		/// <summary>
		/// ���[�U�[�K�C�h�{�f�B�f�[�^�ݒ菈��
		/// </summary>
		/// <returns>STATUS [0:�擾 0�ȊO:�擾���s]</returns>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�{�f�B�f�[�^��ݒ肵�܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		public void SetUserGdBd(ref SortedList sList, ref ArrayList userGdBdList)
		{
			foreach (UserGdBd userGdBd in userGdBdList)
			{
				sList.Add(userGdBd.GuideCode, userGdBd.GuideName);
			}
		}

		/// <summary>
		/// ���[�U�[�K�C�h���̎擾����
		/// </summary>
		/// <param name="userGuideSList"></param>
		/// <param name="userGuideCode"></param>
		/// <remarks>
		/// <br>Note       : ���[�U�[�K�C�h�R�[�h���疼�̂��擾���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		public string GetUserGdBdNm(ref SortedList userGuideSList, int userGuideCode)
		{
			string retStr = "";

			if (userGuideSList.ContainsKey(userGuideCode) == true)
			{
				retStr = userGuideSList[userGuideCode].ToString();
			}
			return retStr;
		}

		/// <summary>
		/// �ڕW�Δ�敪�ύX
		/// </summary>
		/// <param name="targetContrastCd">�ڕW�Δ�敪</param>
		/// <remarks>
		/// <br>Note�@     : �ڕW�Δ�敪�̑I����ύX�����Ƃ��ɔ������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		private void TargetContrastCdChange(int targetContrastCd)
		{
			if (this._targetContrastCd_tComboEditorValue == targetContrastCd) return;

			switch (targetContrastCd)
			{
				case (int)SalesTarget.ConstrastCd.SecAndCust:				// 30:���_�{���Ӑ�
					{
						this.BusinessTypeCode_tNedit.Enabled = false;	    // �Ǝ�R�[�h
                        this.BusinessTypeCodeGuide_ultraButton.Enabled = false;
						this.SalesAreaCode_tNedit.Enabled = false;	        // �̔��G���A�R�[�h
                        this.SalesAreaCodeGuide_ultraButton.Enabled = false;
						this.CustomerCode_tNedit.Enabled = true;			// ���Ӑ�R�[�h
						this.CustomerCodeGuide_Button.Enabled = true;		// ���Ӑ�K�C�h
						
						// ���͕s���ڃN���A
                        this.BusinessTypeCode_tNedit.Clear();		        // ��
                        this.BusinessTypeName_tEdit.Clear();
                        this.SalesAreaCode_tNedit.Clear();			        // ��
                        this.SalesAreaName_tEdit.Clear();
						break;
					}
				case (int)SalesTarget.ConstrastCd.SecAndBusinessType:		// 31:���_�{�Ǝ�
					{
                        this.BusinessTypeCode_tNedit.Enabled = true;	    // �Ǝ�R�[�h
                        this.BusinessTypeCodeGuide_ultraButton.Enabled = true;
                        this.SalesAreaCode_tNedit.Enabled = false;	        // �̔��G���A�R�[�h
                        this.SalesAreaCodeGuide_ultraButton.Enabled = false;
						this.CustomerCode_tNedit.Enabled = false;			// ���Ӑ�R�[�h
						this.CustomerCodeGuide_Button.Enabled = false;		// ���Ӑ�K�C�h

						// ���͕s���ڃN���A
                        this.BusinessTypeCode_tNedit.Clear();   			// ��
                        this.BusinessTypeName_tEdit.Clear();
						this.CustomerCode_tNedit.Clear();
						this.CustomerCodeNm_tEdit.Clear();
						break;
					}

				case (int)SalesTarget.ConstrastCd.SecAndSalesArea:			// 32:���_�{�̔��G���A
					{
                        this.BusinessTypeCode_tNedit.Enabled = false;	    // �Ǝ�R�[�h
                        this.BusinessTypeCodeGuide_ultraButton.Enabled = false;
                        this.SalesAreaCode_tNedit.Enabled = true;		    // �̔��G���A�R�[�h
                        this.SalesAreaCodeGuide_ultraButton.Enabled = true;
						this.CustomerCode_tNedit.Enabled = false;			// ���Ӑ�R�[�h
						this.CustomerCodeGuide_Button.Enabled = false;		// ���Ӑ�K�C�h

						// ���͕s���ڃN���A
                        this.BusinessTypeCode_tNedit.Clear();			    // ��
                        this.BusinessTypeName_tEdit.Clear();
						this.CustomerCode_tNedit.Clear();
						this.CustomerCodeNm_tEdit.Clear();
						break;
					}
			}
			// �I�������ԍ���ێ�
			this._targetContrastCd_tComboEditorValue = targetContrastCd;
		}

		//----- ueno add---------- start 2008.03.06
		#region ���Ӑ�R�[�h�G���[�`�F�b�N����
		/// <summary>
		/// ���Ӑ�R�[�h�G���[�`�F�b�N����
		/// </summary>
		/// <param name="inParamObj">�����I�u�W�F�N�g</param>
		/// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
		/// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
		/// <remarks>
		/// <br>Note       : ���Ӑ�R�[�h�G���[�`�F�b�N���s���܂��B
		///					 �����I�u�W�F�N�g:���Ӑ�R�[�h
		///					 ���ʃI�u�W�F�N�g:���Ӑ�}�X�^�������ʃX�e�[�^�X, ���Ӑ於��</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.03.06</br>
		/// </remarks>
		private int CheckCustomerCode(object inParamObj, out object outParamObj)
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
				if (inParamObj == null) return ret;
				if ((inParamObj is int) == false) return ret;
				if ((int)inParamObj == 0) return ret;

				//--------------
				// ���݃`�F�b�N
				//--------------
				CustomerInfo customerInfo = null;

				this.Cursor = Cursors.WaitCursor;
				ret = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, (int)inParamObj, out customerInfo);
				this.Cursor = Cursors.Default;

				outParamList.Add(status);	// ���Ӑ�}�X�^�X�e�[�^�X�ݒ�

				// ���̓f�[�^�����Ӑ悩����
				if ((customerInfo != null) && (customerInfo.IsCustomer == true))
				{
					ret = (int)InputChkStatus.Normal;
					outParamList.Add(customerInfo.Name);	// ���Ӑ於�̐ݒ�
				}
				else
				{
					ret = (int)InputChkStatus.NotExist;
				}
			}
			catch (Exception)
			{
			}
			outParamObj = outParamList;

			return ret;
		}
		#endregion ���Ӑ�R�[�h�G���[�`�F�b�N����

		#region ���Ӑ�R�[�h�ݒ菈��
		/// <summary>
		/// ���Ӑ�R�[�h�ݒ菈��
		/// </summary>
		/// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
		/// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
		/// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ���Ӑ�R�[�h����ʂɐݒ肵�܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.03.06</br>
		/// </remarks>
		private void DispSetCustomerCode(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// �f�[�^�N���A
						{
							this.CustomerCode_tNedit.Clear();
							this.CustomerCodeNm_tEdit.Clear();

							// ���݃f�[�^�N���A
							this._customerCodeWork = 0;

							//----- ueno upd ---------- start 2008.03.07
							// �t�H�[�J�X
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:	// ���ɖ߂�
						{
							this.CustomerCode_tNedit.SetInt(this._customerCodeWork);

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
									this.CustomerCodeNm_tEdit.Text = (string)outParamList[1];

									// ���݃f�[�^�ۑ�
									this._customerCodeWork = this.CustomerCode_tNedit.GetInt();
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
		#endregion ���Ӑ�R�[�h�ݒ菈��

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
		//----- ueno add---------- end 2008.03.06

		# endregion Private Methods

		# region Control Events

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Form_Load �C�x���g����(DCKHN09190U)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �t�H�[�����[�h�������s���܂��B</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.11.21</br>
		/// </remarks>
		private void DCKHN09190UA_Load(object sender, EventArgs e)
		{
            this.TargetSetCd_tComboEditor.SelectedIndex = 0;


			// ��ʃX�L���t�@�C���̓Ǎ�(�f�t�H���g�X�L���w��)
			this._controlScreenSkin.LoadSkin();

			// ��ʃX�L���ύX
			this._controlScreenSkin.SettingScreenSkin(this);

			// �R���g���[���T�C�Y�ݒ�
			SetControlSize();

			// Nedit�X�^�C���ݒ�
			SetNeditStyle();

			// �ڕW�Δ�敪�R���{�{�b�N�X�ݒ�
			this.TargetContrastCd_tComboEditor.Items.Clear();

			if (SalesTarget._targetContrastCdCustSList.Count > 0)
			{
				foreach (DictionaryEntry de in SalesTarget._targetContrastCdCustSList)
				{
					this.TargetContrastCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
				}
				this.TargetContrastCd_tComboEditor.Value = SalesTarget._targetContrastCdCustSList.GetKey(0);
			}

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

			//--------------------------
			// ���[�U�[�K�C�h�f�[�^�擾
			//--------------------------
			ArrayList userGdBdList;
			
			// �Ǝ�R�[�h�擾
			userGdBdList = null;
			GetUserGdBdList(out userGdBdList, GUIDEDIVCD_BUSINESSTYPECODE);
			SetUserGdBd(ref this._businessTypeCodeSList, ref userGdBdList);
			
			// �̔��G���A�擾
			userGdBdList = null;
			GetUserGdBdList(out userGdBdList, GUIDEDIVCD_SALESAREACODE);
			SetUserGdBd(ref this._salesAreaCodeSList, ref userGdBdList);
			
            //// �Ǝ�R�[�h�R���{�{�b�N�X�ݒ�
            //this.BusinessTypeCode_tNedit.BusinessTypeCode_tComboEditor.Items.Clear();

            //if (this._businessTypeCodeSList.Count > 0)
            //{
            //    // �󔒐ݒ�
            //    this.BusinessTypeCode_tComboEditor.Items.Add(0, " ");
				
            //    foreach (DictionaryEntry de in this._businessTypeCodeSList)
            //    {
            //        this.BusinessTypeCode_tComboEditor.Items.Add(de.Key, de.Value.ToString());
            //    }
            //    this.BusinessTypeCode_tComboEditor.Value = 0;
            //}
			
            //// �̔��G���A�R�[�h�R���{�{�b�N�X�ݒ�
            //this.SalesAreaCode_tComboEditor.Items.Clear();

            //if (this._salesAreaCodeSList.Count > 0)
            //{
            //    // �󔒐ݒ�
            //    this.SalesAreaCode_tComboEditor.Items.Add(0, " ");
				
            //    foreach (DictionaryEntry de in this._salesAreaCodeSList)
            //    {
            //        this.SalesAreaCode_tComboEditor.Items.Add(de.Key, de.Value.ToString());
            //    }
            //    this.SalesAreaCode_tComboEditor.Value = 0;
            //}

            // �ڕW�f�[�^��ʓW�J
            SalesTargetToScreen(this._salesTarget);

			// �ڕW�ݒ�敪
			this._targetSetCd = this._salesTarget.TargetSetCd;

			//----- ueno del---------- start 2007.11.21
			//// �}�X�^�ǂݍ���
			//bool result = LoadMasterTable();
			//if (!result)
			//{
			//    this.Close();
			//    return;
			//}

			//// �j���ʔ䗦�\��
			//DispRatioDayOfWeek();
			//----- ueno del---------- end   2007.11.21

			// �R���g���[������
			ControlEnabled();

			this._targetContrastCd_tComboEditorValue = -1;	// ������

			// ���Ԑݒ�
			SetTargetDate();

			//----- ueno del---------- start 2007.11.21
			//// �䗦�v�Z
			//CalcFromRatio();
			//----- ueno del---------- end   2007.11.21
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// FormClosing �C�x���g����(DCKHN09190UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �t�H�[���́~�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: 30167 ���@�O�M</br>
        /// <br>Date		: 2007.07.31</br>
        /// </remarks>
        private void DCKHN09190UA_FormClosing(object sender, FormClosingEventArgs e)
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
							//----- ���\�b�h�擪�Ŋi�[���Ă���̂ŕs�v
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
		/// <br>Programmer	: 30167 ���@�O�M</br>
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
			if (!CheckInputData())
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
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.04.03</br>
		/// </remarks>
		private void Close_Button_Click(object sender, EventArgs e)
		{
            this.Close();
		}

		/*----------------------------------------------------------------------------------*/

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
        /// <summary>
        /// �Ǝ�R�[�h���͗�Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BusinessTypeCode_tNedit_Leave(object sender, EventArgs e)
        {
            // �Ǝ�R�[�h���͒l���擾
            int businessTypeCode = this.BusinessTypeCode_tNedit.GetInt();

            // ���͂���Ă���Εϊ�
            if (businessTypeCode != 0)
            {
                UserGdBd userGuideBdInfo;
                int status = this._userGuideAcs.ReadStaticMemory(out userGuideBdInfo, BUSINESS_TYPE_GUIDE, businessTypeCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.BusinessTypeName_tEdit.DataText = userGuideBdInfo.GuideName;
                }
            }
        }

        /// <summary>
        /// �Ǝ�R�[�h�K�C�h�{�^���N���b�N����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BusinessTypeCodeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            UserGdBd userGuideBdInfo;
            UserGdHd userGuideHdInfo;
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGuideHdInfo, out userGuideBdInfo, BUSINESS_TYPE_GUIDE);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.BusinessTypeCode_tNedit.DataText = userGuideBdInfo.GuideCode.ToString();
                this.BusinessTypeName_tEdit.DataText = userGuideBdInfo.GuideName;
            }
        }

        /// <summary>
        /// �̔��G���A�R�[�h���͗�Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesAreaCode_tNedit_Leave(object sender, EventArgs e)
        {
            // �̔��G���A�R�[�h���͒l���擾
            int businessTypeCode = this.SalesAreaCode_tNedit.GetInt();

            // ���͂���Ă���Εϊ�
            if (businessTypeCode != 0)
            {
                UserGdBd userGuideBdInfo;
                int status = this._userGuideAcs.ReadStaticMemory(out userGuideBdInfo, SALES_AREA_GUIDE, businessTypeCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this.SalesAreaName_tEdit.DataText = userGuideBdInfo.GuideName;
                }
            }
        }

        /// <summary>
        /// �̔��G���A�R�[�h�K�C�h�{�^���N���b�N����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesAreaCodeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            UserGdBd userGuideBdInfo;
            UserGdHd userGuideHdInfo;
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGuideHdInfo, out userGuideBdInfo, SALES_AREA_GUIDE);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.SalesAreaCode_tNedit.DataText = userGuideBdInfo.GuideCode.ToString();
                this.SalesAreaName_tEdit.DataText = userGuideBdInfo.GuideName;
            }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END
        
        /// <summary>
		/// Button_Click �C�x���g����(CustomerCodeGuide_Button_Click)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: ���Ӑ�R�[�h�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.11.21</br>
		/// </remarks>
		private void CustomerCodeGuide_Button_Click(object sender, EventArgs e)
		{
            PMKHN04005UA customerSearchForm = new PMKHN04005UA(PMKHN04005UA.SEARCHMODE_CUSTOMER_ONLY, PMKHN04005UA.EXECUTEMODE_GUIDE_ONLY);	// ���Ӑ挟���A�N�Z�X�N���X
            customerSearchForm.CustomerSelect += new PMKHN04005UA.CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
//			customerSearchForm.CustomerSelect += new CustomerSelectEventHandler(this.CustomerSearchForm_CustomerSelect);
			customerSearchForm.ShowDialog(this);
		}

		/// <summary>
		/// ���Ӑ�I���������C�x���g
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="customerSearchRet">���Ӑ挟���߂�l�N���X</param>
		/// <remarks>
		/// <br>Note       : ���Ӑ�I�����ɔ������܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		private void CustomerSearchForm_CustomerSelect(object sender, CustomerSearchRet customerSearchRet)
		{
			if (customerSearchRet == null) return;

			CustomerInfo customerInfo;

			//�I�����ꂽ���Ӑ�̏�Ԃ��`�F�b�N
			int status = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, customerSearchRet.EnterpriseCode,
									customerSearchRet.CustomerCode, out customerInfo);

			if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
			{
				// �I���f�[�^�����Ӑ�łȂ��ꍇ
				if (customerInfo.IsCustomer == false)
				{
					string errMessage = "�w�肳�ꂽ�����ŁA���Ӑ�͑��݂��܂���ł����B";

					// �G���[
					TMsgDisp.Show(
						this,									// �e�E�B���h�E�t�H�[��
						emErrorLevel.ERR_LEVEL_EXCLAMATION, 	// �G���[���x��
						this.Name,								// �A�Z���u��ID
						errMessage,								// �\�����郁�b�Z�[�W
						status,									// �X�e�[�^�X�l
						MessageBoxButtons.OK);					// �\������{�^��
					return;
				}
			}
			else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
			{
				string errMessage = "�I���������Ӑ�͊��ɍ폜����Ă��܂��B";

				// �G���[
				TMsgDisp.Show(
					this,									// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION, 	// �G���[���x��
					this.Name,								// �A�Z���u��ID
					errMessage,								// �\�����郁�b�Z�[�W
					status,									// �X�e�[�^�X�l
					MessageBoxButtons.OK);					// �\������{�^��
				return;
			}
			else
			{
				string errMessage = "���Ӑ���̎擾�Ɏ��s���܂����B";

				// �G���[
				TMsgDisp.Show(
					this,									// �e�E�B���h�E�t�H�[��
					emErrorLevel.ERR_LEVEL_EXCLAMATION, 	// �G���[���x��
					this.Name,								// �A�Z���u��ID
					errMessage,								// �\�����郁�b�Z�[�W
					status,									// �X�e�[�^�X�l
					MessageBoxButtons.OK);					// �\������{�^��
				return;
			}

			this.CustomerCode_tNedit.SetInt(customerSearchRet.CustomerCode);
			this.CustomerCodeNm_tEdit.Text = customerSearchRet.Name;

			// ���݃f�[�^�ۑ�
			this._customerCodeWork = this.CustomerCode_tNedit.GetInt();
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

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Leave �C�x���g(SalesTarget_tNedit)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �R���g���[���̃t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
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
			//// �䗦�v�Z
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
        /// <br>Programmer	: 30167 ���@�O�M</br>
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
		/// <br>Programmer	: 30167 ���@�O�M</br>
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
		/// <br>Programmer	: 30167 ���@�O�M</br>
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
		/// ValueChanged �C�x���g����(TargetDivideCode_uOptionSet)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �ڕW�ݒ�敪�̃`�F�b�N��ύX�������ɔ������܂��B</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.04.16</br>
		/// </remarks>
		private void TargetDivideCode_uOptionSet_ValueChanged(object sender, EventArgs e)
		{
			// ���ԖڕW
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA MODIFY START
            if ((int)this.TargetSetCd_tComboEditor.SelectedItem.DataValue == 10)
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD STA
        /// <summary>
        /// �ڕW�ݒ�敪�ύX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TargetSetCd_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // ���ԖڕW
            if (int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString()) == 10)
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
        }

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END

	}
}