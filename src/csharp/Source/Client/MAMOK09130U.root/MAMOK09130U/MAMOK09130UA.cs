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
	/// ���i�ڕW���͉��
	/// </summary>
	/// <remarks>
	/// <br>Note			 : ���i�ڕW���͂��s����ʂł��B</br>
	/// <br>Programmer		 : NEPCO</br>
	/// <br>Date			 : 2007.04.23</br>
	/// <br>Update Note		 : 2007.11.21 ��� �O�M</br>
	/// <br>                   ����.DC�p�ɕύX�i���ڒǉ��E�폜�j</br>
	/// <br>Update Note		 : 2008.03.03 30167 ���@�O�M</br>
	/// <br>				   ���ڃ[�����ߑΉ��i��ʃf�U�C���ɃR���|�[�l���g�ǉ��A
	///						   Tedit�ATNedit�̐ݒ�ύX�j</br>
	/// <br>Update Note      : 2008.03.05 30167 ���@�O�M</br>
	/// <br>			       �E���i������ʂɃ��[�J�[�R�[�h�������p���悤�C��
	///					       �E���i�B�������Ń��[�J�[�R�[�h�ɑΉ������f�[�^����������悤�C��
	///					       �E��ʃR���|�[�l���g�̔z�u�ύX
	///					       �E���[�J�[�R�[�h�ݒ莞�̏��i�R�[�h�����C��
	///					 	   �E���[�J�[�R�[�h�Ə��i�R�[�h�̐������`�F�b�N�ǉ�
	///					 	   �E�V���[�g�J�b�g�L�[�G���[�`�F�b�N�Ή��ǉ�
	/// <br>Update Note		 : 2008.03.07 30167 ���@�O�M</br>
	///						   ���ڃN���A��G���^�[�L�[�Ŏ����ڂֈړ�����悤�C��</br>
	/// </remarks>
	public partial class MAMOK09130UA : Form
	{
		# region Private Constants

		// PG����
		private const string ctPGNM = "���i�ڕW����";

		//----- ueno del---------- start 2007.11.21
		// �䗦
        //private const string RATIO_DEFAULT = "1.00";
		//----- ueno del---------- end   2007.11.21

        // ����
        private const string FORMAT_NUM = "###,##0";
        private const string FORMAT_NUM_DECIMAL = "N1";

		// �@��R�[�h�Ȃ�
		private const string CELLPHONEMODELCODE_NONE = "none";

		# endregion Private Constants

		# region Private Members

		// ��ƃR�[�h
		private string _enterpriseCode;
		// ���_��
		private string _sectionName;

		//----- ueno add---------- start 2008.03.05
		// ���_�R�[�h
		private string _sectionCode;
		//----- ueno add---------- end 2008.03.05

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.03 TOKUNAGA ADD START
        // BL�O���[�v�K�C�h�A�N�Z�X�N���X
        private BLGroupUAcs _blGroupUAcs = null;

        // BL�R�[�h�K�C�h�A�N�Z�X�N���X
        private BLGoodsCdAcs _blGoodsCdAcs = null;

        // ���[�U�[�K�C�h�A�N�Z�X�N���X�K�C�h�萔
        private int SALES_TYPE_GUIDE = 71;      // �̔��敪
        private int ITEM_TYPE_GUIDE = 41;       // ���i�敪(���F���Ћ敪)

        // ���[�U�[�K�C�h�A�N�Z�X�N���X
        private UserGuideAcs _userGuideAcs = null;

        // ���[�U�[�K�C�h�f�[�^�i�[�p�i�̔��敪�j
        private SortedList _salesTypeCodeSList = null;

        // ���[�U�[�K�C�h�f�[�^�i�[�p�i���i�敪�j
        private SortedList _itemTypeCodeSList = null;

        // CONST
        private const int BL_GROUP_SELECTED = 42;       // ���_+BL�O���[�v
        private const int BL_CODE_SELECTED = 43;        // ���_+BL�R�[�h
        private const int BL_SALES_TYPE_SELECTED = 44;  // ���_+�̔��敪
        private const int BL_ITEM_TYPE_SELECTED = 45;   // ���_+���i�敪

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.03 TOKUNAGA ADD END

		// �ڕW�f�[�^
		private SalesTarget _salesTarget;
		// �ڕW�}�X�^�A�N�Z�X�N���X
		private SalesTargetAcs _salesTargetAcs;
		// �ڕW�f�[�^���X�g
		private List<SalesTarget> _salesTargetList;

		//----- ueno add ---------- start 2008.03.05
		// ���[�J�[�A�N�Z�X�N���X
		private MakerAcs _makerAcs = null;
		//----- ueno add ---------- end 2008.03.05

//----- ueno add---------- start 2007.11.21
		// ���i�A�N�Z�X�N���X
		private GoodsAcs _goodsAcs;
		
		// ���[�J�[�R�[�h�i���[�N�j
		private int _goodsMakerCdWork = 0;
		
		// ���i�R�[�h�i���[�N�j
		private string _goodsCodeWork = "";

		// �ڕW�Δ�敪���[�N
		private int _targetContrastCd_tComboEditorValue = -1;
		
//----- ueno add---------- start 2007.11.21

		//----- ueno add---------- start 2008.03.05
		// �����񌋍��p
		private StringBuilder _stringBuilder = null;
		//----- ueno add---------- end 2008.03.05

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

		// ���[�h(�V�K�E�ҏW)
		private int _mode;

		private bool _searchFlag;

		/// <summary>��ʃf�U�C���ύX�N���X</summary>
		private ControlScreenSkin _controlScreenSkin = new ControlScreenSkin();

		# endregion Private Members

		# region Constructor

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public MAMOK09130UA()
		{
			InitializeComponent();

			//�@��ƃR�[�h�擾
			this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA DEL START
            //// ���_���̎擾
            //SecInfoSet secInfoSet;
            //SecInfoAcs secInfoAcs = new SecInfoAcs();
            //secInfoAcs.GetSecInfo(SecInfoAcs.CompanyNameCd.CompanyNameCd1, out secInfoSet);
            //this._sectionName = secInfoSet.SectionGuideNm.TrimEnd();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA DEL END

			this._salesTargetAcs = new SalesTargetAcs();

			//----- ueno add ---------- start 2008.03.05
			// ���[�J�[�A�N�Z�X�N���X
			this._makerAcs = new MakerAcs();
			//----- ueno add ---------- end 2008.03.05

//----- ueno add---------- start 2007.11.21
			// ���i�A�N�Z�X�N���X
			this._goodsAcs = new GoodsAcs();
//----- ueno add---------- start 2007.11.21

			// �A�C�R���摜�̐ݒ�
			// ���i�R�[�h�K�C�h�{�^��
			this.GoodsCodeGuide_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

//----- ueno add---------- start 2007.11.21
			// ���[�J�[�R�[�h�K�C�h�{�^��
			this.GoodsMakerCdGuide_Button.Appearance.Image
				= IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
//----- ueno add---------- end   2007.11.21

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            this._blGroupUAcs = new BLGroupUAcs();

            // BL�R�[�h�K�C�h�A�N�Z�X�N���X
            this._blGoodsCdAcs = new BLGoodsCdAcs();

            // ���[�U�[�K�C�h�A�N�Z�X�N���X
            this._userGuideAcs = new UserGuideAcs();

            // ���[�U�[�K�C�h�f�[�^�i�[�p�i�Ǝ�R�[�h�j
            this._salesTypeCodeSList = new SortedList();

            // ���[�U�[�K�C�h�f�[�^�i�[�p�i�̔��G���A�R�[�h�j
            this._itemTypeCodeSList = new SortedList();

            // BL�O���[�v�K�C�h�{�^��
            this.BLGroupGuide_ultraButton.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            // BL�R�[�h�K�C�h�{�^��
            this.BLCodeGuide_ultraButton.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            // �̔��敪�K�C�h�{�^��
            this.SalesTypeGuide_ultraButton.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];

            // ���i�敪�K�C�h�{�^��
            this.ItemTypeGuide_ultraButton.Appearance.Image
                = IconResourceManagement.ImageList16.Images[(int)Size16_Index.STAR1];
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END

			// �I���{�^��
			this.Close_Button.Appearance.Image
				= IconResourceManagement.ImageList24.Images[(int)Size24_Index.CLOSE];
			// �ۑ��{�^��
			this.Save_Button.Appearance.Image
				= IconResourceManagement.ImageList24.Images[(int)Size24_Index.SAVE];

			//----- ueno add---------- start 2008.03.05
			// �����񌋍��p
			this._stringBuilder = new StringBuilder();
			//----- ueno add---------- end 2008.03.05
		}

		# endregion Constructor

		#region enum

		//----- ueno upd ---------- start 2008.03.05	
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
		//----- ueno upd ---------- end 2008.03.05	

		//----- ueno add---------- start 2008.03.05
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
		//----- ueno add---------- end 2008.03.05
		
		#endregion enum

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
		//    status = LoadLdgCalcRatioMngTable(this._salesTarget.SectionCode);

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

		///*----------------------------------------------------------------------------------*/
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
		//            this._salesTarget.SectionCode,
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
		//            this._salesTarget.SectionCode,
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
		//            this._salesTarget.SectionCode,
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
		//----- ueno del---------- start 2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �Ώۊ��Ԑݒ菈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: ���Ԃ̐ݒ���s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.17</br>
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
			//this.TargetSetCd_uOptionSet.Value = salesTarget.TargetSetCd;
            if (salesTarget.TargetSetCd == 10)
            {
                this.TargetSetCd_tComboEditor.SelectedIndex = 0;
            }
            else
            {
                this.TargetSetCd_tComboEditor.SelectedIndex = 1;
            }
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
			// ���i�R�[�h
			this.GoodsCode_tEdit.DataText = salesTarget.GoodsCode;
			// ���i����
			this.GoodsName_tEdit.DataText = salesTarget.GoodsName;
//----- ueno upd---------- start 2007.11.21
			// ���[�J�[�R�[�h
			this.GoodsMakerCd_tNedit.SetInt(salesTarget.MakerCode);
//----- ueno upd---------- end   2007.11.21
			// ���[�J�[����
			this.GoodsMakerCdNm_tEdit.DataText = salesTarget.MakerName;

			//----- ueno del---------- start 2007.11.21
			//// �L�����A�R�[�h
			//this.CarrierName_tEdit.Tag = salesTarget.CarrierCode;
			//// �L�����A����
			//this.CarrierName_tEdit.DataText = salesTarget.CarrierName;
			//// �@��R�[�h
			//this.CellphoneModelName_tEdit.Tag = salesTarget.CellphoneModelCode;
			//// �@�햼��
			//this.CellphoneModelName_tEdit.DataText = salesTarget.CellphoneModelName;
			//----- ueno del---------- end   2007.11.21

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            // BL�O���[�v�R�[�h
            this.BLGroupCode_tNedit.SetInt(salesTarget.BLGroupCode);
            // BL�O���[�v����
            this.BLGroupName_tEdit.DataText = salesTarget.BLGroupName;
            // BL�R�[�h
            this.BLCode_tNedit.SetInt(salesTarget.BLCode);
            // BL�R�[�h����
            this.BLCodeName_tEdit.DataText = salesTarget.BLCodeName;
            // �̔��敪�R�[�h
            this.SalesTypeCode_tNedit.SetInt(salesTarget.SalesTypeCode);
            // �̔��敪����
            this.SalesTypeName_tEdit.DataText = salesTarget.SalesTypeName;
            // ���i�敪�R�[�h
            this.ItemTypeCode_tNedit.SetInt(salesTarget.ItemTypeCode);
            // ���i�敪����
            this.ItemTypeName_tEdit.DataText = salesTarget.ItemTypeName;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END

			// ����ڕW
			if (salesTarget.SalesTargetMoney == 0)
			{
				this.SalesTargetMoney_tNedit.DataText = "";
			}
			else
			{
				this.SalesTargetMoney_tNedit.DataText = salesTarget.SalesTargetMoney.ToString();
			}
			// �e���ڕW
			if (salesTarget.SalesTargetProfit == 0)
			{
				this.SalesTargetProfit_tNedit.DataText = "";
			}
			else
			{
				this.SalesTargetProfit_tNedit.DataText = salesTarget.SalesTargetProfit.ToString();
			}
			// ���ʖڕW
			if (salesTarget.SalesTargetCount == 0)
			{
				this.SalesTargetCount_tNedit.DataText = "";
			}
			else
			{
				this.SalesTargetCount_tNedit.DataText = salesTarget.SalesTargetCount.ToString();
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
			//salesTarget.TargetSetCd = (int)TargetSetCd_uOptionSet.Value;
            salesTarget.TargetSetCd = int.Parse(TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString());
			// ���ԁi�J�n�j
            //salesTarget.ApplyStaDate = this._targetStaDate;
            salesTarget.ApplyStaDate = this.ApplyStaDate_tDateEdit.GetDateTime();
			// ���ԁi�I���j
            //salesTarget.ApplyEndDate = this._targetEndDate;
            salesTarget.ApplyEndDate = this.ApplyEndDate_tDateEdit.GetDateTime();
			// �ڕW�敪�R�[�h
			salesTarget.TargetDivideCode = this.TargetDivideCode_tEdit.DataText;
			// �ڕW�敪����
			salesTarget.TargetDivideName = this.TargetDivideName_tEdit.DataText;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA MODIFY START
            // ���i�R�[�h
            if (this.GoodsCode_tEdit.DataText == null)
            {
                salesTarget.GoodsCode = string.Empty;
            }
            else
            {
                salesTarget.GoodsCode = this.GoodsCode_tEdit.DataText;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA MODIFY END

			// ���i����
			salesTarget.GoodsName = this.GoodsName_tEdit.DataText;
//----- ueno upd---------- start 2007.11.21
			// ���[�J�[�R�[�h
			salesTarget.MakerCode = this.GoodsMakerCd_tNedit.GetInt();
//----- ueno upd---------- end   2007.11.21
			// ���[�J�[����
			salesTarget.MakerName = this.GoodsMakerCdNm_tEdit.DataText;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
            salesTarget.BLGroupCode = this.BLGroupCode_tNedit.GetInt();
            salesTarget.BLGroupName = this.BLGroupName_tEdit.DataText;
            salesTarget.BLCode = this.BLCode_tNedit.GetInt();
            salesTarget.BLCodeName = this.BLCodeName_tEdit.DataText;
            salesTarget.SalesTypeCode = this.SalesTypeCode_tNedit.GetInt();
            salesTarget.SalesTypeName = this.SalesTypeName_tEdit.DataText;
            salesTarget.ItemTypeCode = this.ItemTypeCode_tNedit.GetInt();
            salesTarget.ItemTypeName = this.ItemTypeName_tEdit.DataText;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END


			//----- ueno del---------- start 2007.11.21
			//// �L�����A�R�[�h
			//salesTarget.CarrierCode = (int)this.CarrierName_tEdit.Tag;
			//// �L�����A����
			//salesTarget.CarrierName = this.CarrierName_tEdit.DataText;
			//// �@��R�[�h
			//salesTarget.CellphoneModelCode = (string)this.CellphoneModelName_tEdit.Tag;
			//if (salesTarget.CellphoneModelCode == "")
			//{
			//    salesTarget.CellphoneModelCode = CELLPHONEMODELCODE_NONE;
			//}
			//// �@�햼��
			//salesTarget.CellphoneModelName = this.CellphoneModelName_tEdit.DataText;
			//----- ueno del---------- end   2007.11.21

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

//----- ueno add---------- start 2007.11.21

				// �ڕW�Δ�敪�ɂ��`�F�b�N�ύX
				switch((int)this.TargetContrastCd_tComboEditor.Value)
				{
					case (int)SalesTarget.ConstrastCd.SecAndMaker:				// 40:���_�{���[�J�[
						{
							if ((this.GoodsMakerCd_tNedit.DataText == "") || (this.GoodsMakerCd_tNedit.GetInt() == 0))
							{
								errMsg = "���[�J�[�R�[�h����͂��Ă�������";
								this.GoodsMakerCd_tNedit.Focus();

								//----- ueno add---------- start 2008.03.05
								this.GoodsMakerCdNm_tEdit.Clear();	// ���[�J�[���̃N���A
								this._goodsMakerCdWork = 0;			// ���[�J�[�R�[�h���[�N�N���A

								this.GoodsCode_tEdit.Clear();		// ���i�R�[�h�N���A
								this.GoodsName_tEdit.Clear();		// ���i���̃N���A
								this._goodsCodeWork = "";			// ���i�R�[�h���[�N�N���A
								//----- ueno add---------- end 2008.03.05

								return (false);
							}
							break;
						}
					case (int)SalesTarget.ConstrastCd.SecAndMakerAndGoods:		// 41:���_�{���[�J�[�{���i
						{
							if ((this.GoodsMakerCd_tNedit.DataText == "") || (this.GoodsMakerCd_tNedit.GetInt() == 0))
							{
								errMsg = "���[�J�[�R�[�h����͂��Ă�������";
								this.GoodsMakerCd_tNedit.Focus();

								//----- ueno add---------- start 2008.03.05
								this.GoodsMakerCdNm_tEdit.Clear();	// ���[�J�[���̃N���A
								this._goodsMakerCdWork = 0;			// ���[�J�[�R�[�h���[�N�N���A

								this.GoodsCode_tEdit.Clear();		// ���i�R�[�h�N���A
								this.GoodsName_tEdit.Clear();		// ���i���̃N���A
								this._goodsCodeWork = "";			// ���i�R�[�h���[�N�N���A
								//----- ueno add---------- end 2008.03.05

								return (false);
							}
							if (this.GoodsCode_tEdit.DataText == "")
							{
								errMsg = "���i�R�[�h����͂��Ă�������";
								this.GoodsCode_tEdit.Focus();

								//----- ueno add---------- start 2008.03.05
								this.GoodsName_tEdit.Clear();	// ���i���̃N���A
								this._goodsCodeWork = "";		// ���i�R�[�h���[�N�N���A
								//----- ueno add---------- end 2008.03.05

								return (false);
							}
							break;
						}
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
                    case (int)SalesTarget.ConstrastCd.SecAndBLGroup:		// 42:���_�{BL�O���[�v
                        {
                            if ((this.BLGroupCode_tNedit.DataText == "") || (this.BLGroupCode_tNedit.GetInt() == 0))
                            {
                                errMsg = "BL�O���[�v�R�[�h����͂��Ă�������";
                                this.BLGroupCode_tNedit.Focus();

                                return (false);
                            }
                            break;
                        }
                    case (int)SalesTarget.ConstrastCd.SecAndBlCode:		// 43:���_�{BL�R�[�h
                        {
                            if ((this.BLCode_tNedit.DataText == "") || (this.BLCode_tNedit.GetInt() == 0))
                            {
                                errMsg = "BL�R�[�h����͂��Ă�������";
                                this.BLCode_tNedit.Focus();

                                return (false);
                            }
                            break;
                        }
                    case (int)SalesTarget.ConstrastCd.SecAndSalesType:		// 44:���_�{�̔��敪
                        {
                            if ((this.SalesTypeCode_tNedit.DataText == "") || (this.SalesTypeCode_tNedit.GetInt() == 0))
                            {
                                errMsg = "�̔��敪����͂��Ă�������";
                                this.SalesTypeCode_tNedit.Focus();

                                return (false);
                            }
                            break;
                        }
                    case (int)SalesTarget.ConstrastCd.SecAndItemType:		// 45:���_�{���i�敪
                        {
                            if ((this.ItemTypeCode_tNedit.DataText == "") || (this.ItemTypeCode_tNedit.GetInt() == 0))
                            {
                                errMsg = "���i�敪����͂��Ă�������";
                                this.ItemTypeCode_tNedit.Focus();

                                return (false);
                            }
                            break;
                        }
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
				}
//----- ueno add---------- end   2007.11.21

				//----- ueno add---------- start 2008.03.05
				DispSetStatus dispSetStatus = DispSetStatus.Clear;

				bool canChangeFocus = true;
				object inParamObj = null;
				object outParamObj = null;
				ArrayList inParamList = null;
				
				//------------------------
				// ���[�J�[�R�[�h�`�F�b�N
				//------------------------
				if (this.GoodsMakerCd_tNedit.Enabled == true)
				{
					// �����ݒ�N���A
					inParamObj = null;
					outParamObj = null;
					inParamList = new ArrayList();

					dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p

					// �����ݒ�
					inParamObj = this.GoodsMakerCd_tNedit.GetInt();

					// ���݃`�F�b�N
					switch (CheckGoodsMakerCd(inParamObj, out outParamObj))
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
								errMsg = ShowNotFoundErrMsg("���[�J�[�R�[�h");
								dispSetStatus = this._goodsMakerCdWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
								break;
							}
					}
					// �f�[�^�ݒ�
					DispSetGoodsMakerCd(dispSetStatus, ref canChangeFocus, outParamObj);

					if (dispSetStatus != DispSetStatus.Update)
					{
						this.GoodsMakerCd_tNedit.Focus();
						return false;
					}
				}
				
				//------------------------
				// ���i�R�[�h�`�F�b�N
				//------------------------
				if (this.GoodsCode_tEdit.Enabled == true)
				{
					// �����ݒ�N���A
					inParamObj = null;
					outParamObj = null;
					inParamList = new ArrayList();

					dispSetStatus = DispSetStatus.Back;	// �l���ύX����Ă��Ȃ��Ƃ����Ӗ������Ŏg�p

					// �����ݒ�
					inParamList.Add(this.GoodsMakerCd_tNedit.GetInt());
					inParamList.Add(this.GoodsCode_tEdit.Text);
					inParamObj = inParamList;

					// ���݃`�F�b�N
					switch (CheckGoodsNoCd(inParamObj, out outParamObj))
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
						case (int)InputChkStatus.Cancel:
							{
								dispSetStatus = DispSetStatus.Clear;
								break;
							}
						default:
							{
								errMsg = ShowNotFoundErrMsg("���i�R�[�h");
								dispSetStatus = this._goodsCodeWork == "" ? DispSetStatus.Clear : DispSetStatus.Back;
								break;
							}
					}
					// �f�[�^�ݒ�
					DispSetGoodsNoCd(dispSetStatus, ref canChangeFocus, outParamObj);

					if (dispSetStatus != DispSetStatus.Update)
					{
						this.GoodsCode_tEdit.Focus();
						return false;
					}
				}
				//----- ueno add---------- end 2008.03.05

				//----- ueno mov---------- start 2007.11.21
				// ��L�ڕW�Δ�敪�̏����ɒǉ�
				//if (this.GoodsCode_tEdit.DataText == "")
				//{
				//    errMsg = "���i�R�[�h����͂��Ă�������";
				//    this.GoodsCode_tEdit.Focus();
				//    return (false);
				//}
				//----- ueno mov---------- end   2007.11.21

                if ((this.SalesTargetMoney_tNedit.DataText == "" || long.Parse(this.SalesTargetMoney_tNedit.DataText) == 0) &&
                    (this.SalesTargetProfit_tNedit.DataText == "" || long.Parse(this.SalesTargetProfit_tNedit.DataText) == 0) &&
                    (this.SalesTargetCount_tNedit.DataText == "" || double.Parse(this.SalesTargetCount_tNedit.DataText) == 0))
                {
                    errMsg = "�ڕW���z�܂��͐��ʂ���͂��Ă�������";
                    this.SalesTargetMoney_tNedit.Focus();
                    return (false);
                }

				//----- ueno del---------- start 2007.11.21
				// �������`�F�b�N�͓��͈�𗣂ꂽ��s��(Change_focus�ōs���Ă���)
				//string searchCode;
				//string goodsCode = this.GoodsCode_tEdit.Text.Trim();
				//int searchType = StockSlipInputInitDataAcs.GetSearchType(goodsCode, out searchCode);

				//List<GoodsUnitData> goodsUnitDataList;
				//string message;
				//MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
				//int status = goodsSelectGuide.ReadGoods(this, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
				//if (!((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0)))
				//{
				//    errMsg = "���i�R�[�h [" + searchCode + "] �ɊY������f�[�^�����݂��܂���";
				//    this.GoodsCode_tEdit.Focus();
				//    return (false);
				//}
				//----- ueno del---------- end   2007.11.21
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
		///// ���i��������
		///// </summary>
		///// <param name="goodsCode">���i�R�[�h</param>
		///// <remarks>
		///// <br>Note		: ���i���������܂��B</br>
		///// <br>Programmer	: NEPCO</br>
		///// <br>Date		: 2007.02.22</br>
		///// </remarks>
		//private int SearchGoods(string goodsCode)
		//{
		//    string searchCode;
		//    int searchType = StockSlipInputInitDataAcs.GetSearchType(goodsCode, out searchCode);

		//    List<GoodsUnitData> goodsUnitDataList;
		//    string message;
		//    MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
		//    int status = goodsSelectGuide.ReadGoods(this, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
		//    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
		//    {
		//        GoodsUnitData goodsUnitData;
		//        goodsUnitData = goodsUnitDataList[0];

		//        // ���[�J�[
		//        this.GoodsMakerCd_tNedit.SetInt(goodsUnitData.GoodsMakerCd);

		//        // ���i
		//        this.GoodsCode_tEdit.DataText = goodsUnitData.GoodsNo;
		//        this.GoodsName_tEdit.DataText = goodsUnitData.GoodsName;
				
		//        //// �L�����A
		//        //this.CarrierName_tEdit.Tag = goodsUnitData.CarrierCode;
		//        //this.CarrierName_tEdit.DataText = goodsUnitData.CarrierName;

		//        //// �@��
		//        //this.CellphoneModelName_tEdit.Tag = goodsUnitData.CellphoneModelCode;
		//        //this.CellphoneModelName_tEdit.DataText = goodsUnitData.CellphoneModelName;

		//        //// �n���F
		//        //this.SystematicColorNm_tEdit.Tag = goodsUnitData.SystematicColorCd;
		//        //this.SystematicColorNm_tEdit.DataText = goodsUnitData.SystematicColorNm;

		//        return (0);

		//    }
		//    else
		//    {
		//        //this.GoodsCode_tEdit.DataText = "";
		//        this.GoodsName_tEdit.DataText = "";
		//        this.GoodsMakerCdNm_tEdit.DataText = "";

		//        //----- ueno del---------- start 2007.11.21
		//        //this.GoodsMakerCdNm_tEdit.Tag = -1;
		//        //this.CarrierName_tEdit.DataText = "";
		//        //this.CarrierName_tEdit.Tag = -1;
		//        //this.CellphoneModelName_tEdit.DataText = "";
		//        //this.CellphoneModelName_tEdit.Tag = "";
		//        //----- ueno del---------- end   2007.11.21

		//        return (1);
		//    }
		//}
		#endregion del
		//----- ueno del---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// �R���g���[�����䏈��
		/// </summary>
		/// <remarks>
		/// <br>Note		: �R���g���[���̐�����s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.16</br>
		/// </remarks>
		private void ControlEnabled()
		{
			// ���ԖڕW
			if (this._targetSetCd == 10)
			{
				this.ApplyStaDate_tDateEdit.DateFormat = emDateFormat.df4Y2M;
				this.Range_uLabel.Visible = false;
				this.ApplyEndDate_tDateEdit.Visible = false;
				this.ApplyDate_uLabel.Text = "�K�p�N��";
//----- ueno add---------- start 2007.11.21
				this.TargetDivideCode_uLabel.Visible = false;
				this.TargetDivideCode_tEdit.Visible = false;
				this.TargetDivideName_uLabel.Visible = false;
				this.TargetDivideName_tEdit.Visible = false;
//----- ueno add---------- end   2007.11.21
			}
			// �ʖڕW
			else
			{
				this.ApplyStaDate_tDateEdit.DateFormat = emDateFormat.df4Y2M2D;
				this.Range_uLabel.Visible = true;
				this.ApplyEndDate_tDateEdit.Visible = true;
				this.ApplyDate_uLabel.Text = "�K�p����";
//----- ueno add---------- start 2007.11.21
				this.TargetDivideCode_uLabel.Visible = true;
				this.TargetDivideCode_tEdit.Visible = true;
				this.TargetDivideName_uLabel.Visible = true;
				this.TargetDivideName_tEdit.Visible = true;
//----- ueno add---------- end   2007.11.21
			}

			// �V�K���[�h
			if (this._mode == 0)
			{
				this.Mode_Label.Text = "�V�K";

//----- ueno upd---------- start 2007.11.21
				// �ڕW�Δ�敪�R���{�{�b�N�X�l�Ŕ��肷��
				if (this.TargetContrastCd_tComboEditor.Value != null)
				{
					TargetContrastCdChange((Int32)this.TargetContrastCd_tComboEditor.Value);
				}
				//this.GoodsCode_tEdit.Enabled = true;
				//this.GoodsCodeGuide_Button.Enabled = true;
//----- ueno upd---------- end   2007.11.21

				// ����
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA MODIFY START
                if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
				//if ((int)this.TargetSetCd_uOptionSet.Value == 10)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA MODIFY END
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
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA MODIFY START
                    this.TargetSetCd_tComboEditor.Enabled = false;
				    //this.TargetSetCd_uOptionSet.Enabled = false;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA MODIFY END
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
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA MODIFY START
                    this.TargetSetCd_tComboEditor.Enabled = true;
					//this.TargetSetCd_uOptionSet.Enabled = true;
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA MODIFY END				
                }
			}
			// �ҏW���[�h
			else
			{
				this.Mode_Label.Text = "�ҏW";
				this.GoodsCode_tEdit.Enabled = false;
				this.GoodsCodeGuide_Button.Enabled = false;
//----- ueno add---------- start 2007.11.21
				this.TargetContrastCd_tComboEditor.Enabled = false;
				this.GoodsMakerCd_tNedit.Enabled = false;
				this.GoodsMakerCdGuide_Button.Enabled = false;
//----- ueno add---------- end   2007.11.21
			}

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
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA MODIFY START
				if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
                //if ((int)this.TargetSetCd_uOptionSet.Value == 10)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA MODIFY END
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
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA MODIFY START
				else if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 20)
                //else if ((int)this.TargetSetCd_uOptionSet.Value == 20)
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA MODIFY END
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

		//----- ueno del---------- start 2007.11.21
		#region del
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
			//----- ueno del ---------- start 2008.03.05
			//-- ��ʂ̐ݒ�͑S�ĉ�ʃf�U�C���ōs���̂ňȉ��폜
			//this.SectionName_tEdit.Size = new Size(179, 24);
			//this.TargetDivideCode_tEdit.Size = new Size(84, 24);
			//this.TargetDivideName_tEdit.Size = new Size(290, 24);
			////----- ueno upd---------- start   2007.11.21
			//this.GoodsCode_tEdit.Size = new Size(115, 24);
			//this.GoodsName_tEdit.Size = new Size(252, 24);
			//this.GoodsMakerCd_tNedit.Size = new Size(115, 24);
			//this.GoodsMakerCdNm_tEdit.Size = new Size(252, 24);
			////----- ueno upd---------- end   2007.11.21
			//this.SalesTargetMoney_tNedit.Size = new Size(131, 24);
			//this.SalesTargetProfit_tNedit.Size = new Size(131, 24);
			//this.SalesTargetCount_tNedit.Size = new Size(108, 24);
			//----- ueno del ---------- end 2008.03.05


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

			//----- ueno del ---------- start 2008.03.05
            // ���ڂ̍ő���͉\�����͉�ʃf�U�C���Őݒ肷��
			//this.TargetDivideCode_tEdit.MaxLength = 9;
			//this.TargetDivideName_tEdit.MaxLength = 30;
			//this.GoodsCode_tEdit.MaxLength = 15;
			//this.GoodsName_tEdit.MaxLength = 100;
			//----- ueno del ---------- end 2008.03.05
			
			//----- ueno del---------- start 2007.11.21
			#region del
			//this.GoodsMakerCdNm_tEdit.MaxLength = 30;
			//this.CarrierName_tEdit.MaxLength = 20;
            //this.CellphoneModelName_tEdit.MaxLength = 60;
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

		/// <summary>
		/// �����^�C�v�擾����
		/// </summary>
		/// <param name="inputCode">���͂��ꂽ�R�[�h</param>
		/// <param name="searchCode">�����p�R�[�h�i*�������j</param>
		/// <returns>0:���S��v���� 1:�O����v���� 2:�����v���� 3:�B������</returns>
		/// <remarks>
		/// Note			:	����������@���擾���鏈�����s���܂��B<br />
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		public int GetSearchType(string inputCode, out string searchCode)
		{
			searchCode = inputCode;
			if (String.IsNullOrEmpty(inputCode)) return 0;

			if (inputCode.Contains("*"))
			{
				searchCode = inputCode.Replace("*", "");
				string firstString = inputCode.Substring(0, 1);
				string lastString = inputCode.Substring(inputCode.Length - 1, 1);

				if ((firstString == "*") && (lastString == "*"))
				{
					return 3;
				}
				else if (firstString == "*")
				{
					return 2;
				}
				else if (lastString == "*")
				{
					return 1;
				}
				else
				{
					return 3;
				}
			}
			else
			{
				// *�����݂��Ȃ����ߊ��S��v����
				return 0;
			}
		}

		/// <summary>
		/// ���i���[�J�[�R�[�h�K�C�h�N������
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���i���[�J�[�R�[�h�K�C�h���N�����܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.11.21</br>
		/// </remarks>
		private void GoodsNoGuide(TNedit goodsMakerCd_tNedit)
		{
			MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
			GoodsUnitData goodsUnitData = null;
			GoodsCndtn goodsCndtn = new GoodsCndtn();
			goodsCndtn.EnterpriseCode = this._enterpriseCode;

			//----- ueno add ---------- start 2008.03.05
			bool autoSearch = false;
			//----- ueno add ---------- end 2008.03.05			

			//------------------
			// ���i�R�[�h�K�C�h
			//------------------
			if (goodsMakerCd_tNedit.Text != "")
			{
				// ���[�J�[�R�[�h�ݒ�
				goodsCndtn.GoodsMakerCd = goodsMakerCd_tNedit.GetInt();

				//----- ueno add ---------- start 2008.03.05
				// ���[�J�[���̐ݒ�
				goodsCndtn.MakerName = GoodsMakerCdNm_tEdit.Text.TrimEnd();
				autoSearch = true;
				//----- ueno add ---------- end 2008.03.05
			}

			//----- ueno upd ---------- start 2008.03.05
			// ���������̓��[�J�[�R�[�h�����݂���ꍇ�݂̂Ƃ���
			DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, autoSearch, goodsCndtn, out goodsUnitData);
			//DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, true, goodsCndtn, out goodsUnitData);
			//----- ueno upd ---------- end 2008.03.05

			if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
			{
				this.GoodsCode_tEdit.DataText = goodsUnitData.GoodsNo;
				this.GoodsName_tEdit.DataText = goodsUnitData.GoodsName;

				// ���݃f�[�^�ۑ�
				this._goodsCodeWork = this.GoodsCode_tEdit.DataText;

				//--------------------------------------
				// ���i�R�[�h�ɑ΂��郁�[�J�[�R�[�h�ݒ�
				//--------------------------------------
				MakerUMnt makerUMnt = null;
				GoodsAcs goodsAcs = new GoodsAcs();

				// �f�[�^���݃`�F�b�N
				int ret = goodsAcs.GetMaker(this._enterpriseCode, goodsUnitData.GoodsMakerCd, out makerUMnt);

				if (ret == 0)
				{
					// ���[�J�[�R�[�h���ݒ�
					this.GoodsMakerCd_tNedit.SetInt(goodsUnitData.GoodsMakerCd);
					this.GoodsMakerCdNm_tEdit.Text = makerUMnt.MakerName;

					// ���݃f�[�^�ۑ�
					this._goodsMakerCdWork = this.GoodsMakerCd_tNedit.GetInt();
				}
			}
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

			switch (targetContrastCd)
			{
				case (int)SalesTarget.ConstrastCd.SecAndMaker:			// 40:���_�{���[�J�[
					{
						this.GoodsMakerCd_tNedit.Enabled = true;		// ���[�J�[�R�[�h
						this.GoodsMakerCdGuide_Button.Enabled = true;	// ���[�J�[�K�C�h
						this.GoodsCode_tEdit.Enabled = false;			// ���i�R�[�h
						this.GoodsCodeGuide_Button.Enabled = false;		// ���i�K�C�h

                        this.BLGroupCode_tNedit.Enabled = false;        // BL�O���[�v
                        this.BLGroupGuide_ultraButton.Enabled = false;  // BL�O���[�v�K�C�h
                        this.BLCode_tNedit.Enabled = false;             // BL�R�[�h
                        this.BLCodeGuide_ultraButton.Enabled = false;   // BL�R�[�h�K�C�h
                        this.SalesTypeCode_tNedit.Enabled = false;      // �̔��敪
                        this.SalesTypeGuide_ultraButton.Enabled = false;// �̔��敪�K�C�h
                        this.ItemTypeCode_tNedit.Enabled = false;       // ���i�敪
                        this.ItemTypeGuide_ultraButton.Enabled = false; // ���i�敪�K�C�h
						
						// ���͕s���ڃN���A
						this.GoodsCode_tEdit.Clear();
						this.GoodsName_tEdit.Clear();

                        this.BLGroupCode_tNedit.Clear();
                        this.BLGroupName_tEdit.Clear();
                        this.BLCode_tNedit.Clear();
                        this.BLCodeName_tEdit.Clear();
                        this.SalesTypeCode_tNedit.Clear();
                        this.SalesTypeName_tEdit.Clear();
                        this.ItemTypeCode_tNedit.Clear();
                        this.ItemTypeName_tEdit.Clear();
						break;
					}
				case (int)SalesTarget.ConstrastCd.SecAndMakerAndGoods:	// 41:���_�{���[�J�[�{���i
					{
						this.GoodsMakerCd_tNedit.Enabled = true;		// ���[�J�[�R�[�h
						this.GoodsMakerCdGuide_Button.Enabled = true;	// ���[�J�[�K�C�h
						this.GoodsCode_tEdit.Enabled = true;			// ���i�R�[�h
						this.GoodsCodeGuide_Button.Enabled = true;		// ���i�K�C�h

                        this.BLGroupCode_tNedit.Enabled = false;        // BL�O���[�v
                        this.BLGroupGuide_ultraButton.Enabled = false;  // BL�O���[�v�K�C�h
                        this.BLCode_tNedit.Enabled = false;             // BL�R�[�h
                        this.BLCodeGuide_ultraButton.Enabled = false;   // BL�R�[�h�K�C�h
                        this.SalesTypeCode_tNedit.Enabled = false;      // �̔��敪
                        this.SalesTypeGuide_ultraButton.Enabled = false;// �̔��敪�K�C�h
                        this.ItemTypeCode_tNedit.Enabled = false;       // ���i�敪
                        this.ItemTypeGuide_ultraButton.Enabled = false; // ���i�敪�K�C�h

                        // ���͕t�����ڃN���A
                        this.BLGroupCode_tNedit.Clear();
                        this.BLGroupName_tEdit.Clear();
                        this.BLCode_tNedit.Clear();
                        this.BLCodeName_tEdit.Clear();
                        this.SalesTypeCode_tNedit.Clear();
                        this.SalesTypeName_tEdit.Clear();
                        this.ItemTypeCode_tNedit.Clear();
                        this.ItemTypeName_tEdit.Clear();

						break;
					}
                case (int)SalesTarget.ConstrastCd.SecAndBLGroup:        // 42:���_�{BL�O���[�v
                    {
                        // BL�O���[�v���g�p�\��
                        this.BLGroupCode_tNedit.Enabled = true;         // BL�O���[�v
                        this.BLGroupGuide_ultraButton.Enabled = true;   // BL�O���[�v�K�C�h
                        // ����ȊO�͎g�p�s�\��
                        this.BLCode_tNedit.Enabled = false;             // BL�R�[�h
                        this.BLCodeGuide_ultraButton.Enabled = false;   // BL�R�[�h�K�C�h
                        this.SalesTypeCode_tNedit.Enabled = false;      // �̔��敪
                        this.SalesTypeGuide_ultraButton.Enabled = false;// �̔��敪�K�C�h
                        this.ItemTypeCode_tNedit.Enabled = false;       // ���i�敪
                        this.ItemTypeGuide_ultraButton.Enabled = false; // ���i�敪�K�C�h

                        this.GoodsMakerCd_tNedit.Enabled = false;		// ���[�J�[�R�[�h
                        this.GoodsMakerCdGuide_Button.Enabled = false;	// ���[�J�[�K�C�h
                        this.GoodsCode_tEdit.Enabled = false;			// ���i�R�[�h
                        this.GoodsCodeGuide_Button.Enabled = false;		// ���i�K�C�h

                        // ���͕s���ڃN���A
                        this.BLCode_tNedit.Clear();
                        this.BLCodeName_tEdit.Clear();
                        this.SalesTypeCode_tNedit.Clear();
                        this.SalesTypeName_tEdit.Clear();
                        this.ItemTypeCode_tNedit.Clear();
                        this.ItemTypeName_tEdit.Clear();

                        this.GoodsMakerCd_tNedit.Clear();
                        this.GoodsMakerCdNm_tEdit.Clear();
                        this.GoodsCode_tEdit.Clear();
                        this.GoodsName_tEdit.Clear();
                        break;
                    }
                case (int)SalesTarget.ConstrastCd.SecAndBlCode:         // 43:���_�{BL�R�[�h
                    {
                        // BL�R�[�h���g�p�\��
                        this.BLCode_tNedit.Enabled = true;              // BL�R�[�h
                        this.BLCodeGuide_ultraButton.Enabled = true;    // BL�R�[�h�K�C�h
                        // ����ȊO�͎g�p�s�\��
                        this.BLGroupCode_tNedit.Enabled = false;        // BL�O���[�v
                        this.BLGroupGuide_ultraButton.Enabled = false;  // BL�O���[�v�K�C�h
                        this.SalesTypeCode_tNedit.Enabled = false;      // �̔��敪
                        this.SalesTypeGuide_ultraButton.Enabled = false;// �̔��敪�K�C�h
                        this.ItemTypeCode_tNedit.Enabled = false;       // ���i�敪
                        this.ItemTypeGuide_ultraButton.Enabled = false; // ���i�敪�K�C�h

                        this.GoodsMakerCd_tNedit.Enabled = false;		// ���[�J�[�R�[�h
                        this.GoodsMakerCdGuide_Button.Enabled = false;	// ���[�J�[�K�C�h
                        this.GoodsCode_tEdit.Enabled = false;			// ���i�R�[�h
                        this.GoodsCodeGuide_Button.Enabled = false;		// ���i�K�C�h

                        // ���͕s���ڃN���A
                        this.BLGroupCode_tNedit.Clear();
                        this.BLGroupName_tEdit.Clear();
                        this.SalesTypeCode_tNedit.Clear();
                        this.SalesTypeName_tEdit.Clear();
                        this.ItemTypeCode_tNedit.Clear();
                        this.ItemTypeName_tEdit.Clear();

                        this.GoodsMakerCd_tNedit.Clear();
                        this.GoodsMakerCdNm_tEdit.Clear();
                        this.GoodsCode_tEdit.Clear();
                        this.GoodsName_tEdit.Clear();
                        break;
                    }
                case (int)SalesTarget.ConstrastCd.SecAndSalesType:      // 44:���_�{�̔��敪
                    {
                        // �̔��敪���g�p�\��
                        this.SalesTypeCode_tNedit.Enabled = true;       // �̔��敪
                        this.SalesTypeGuide_ultraButton.Enabled = true; // �̔��敪�K�C�h
                        // ����ȊO�͎g�p�s�\��
                        this.BLGroupCode_tNedit.Enabled = false;        // BL�O���[�v
                        this.BLGroupGuide_ultraButton.Enabled = false;  // BL�O���[�v�K�C�h
                        this.BLCode_tNedit.Enabled = false;             // BL�R�[�h
                        this.BLCodeGuide_ultraButton.Enabled = false;   // BL�R�[�h�K�C�h
                        this.ItemTypeCode_tNedit.Enabled = false;       // ���i�敪
                        this.ItemTypeGuide_ultraButton.Enabled = false; // ���i�敪�K�C�h

                        this.GoodsMakerCd_tNedit.Enabled = false;		// ���[�J�[�R�[�h
                        this.GoodsMakerCdGuide_Button.Enabled = false;	// ���[�J�[�K�C�h
                        this.GoodsCode_tEdit.Enabled = false;			// ���i�R�[�h
                        this.GoodsCodeGuide_Button.Enabled = false;		// ���i�K�C�h

                        // ���͕s���ڃN���A
                        this.BLGroupCode_tNedit.Clear();
                        this.BLGroupName_tEdit.Clear();
                        this.BLCode_tNedit.Clear();
                        this.BLCodeName_tEdit.Clear();
                        this.ItemTypeCode_tNedit.Clear();
                        this.ItemTypeName_tEdit.Clear();

                        this.GoodsMakerCd_tNedit.Clear();
                        this.GoodsMakerCdNm_tEdit.Clear();
                        this.GoodsCode_tEdit.Clear();
                        this.GoodsName_tEdit.Clear();
                        break;
                    }
                case (int)SalesTarget.ConstrastCd.SecAndItemType:       // 45:���_�{���i�敪
                    {
                        // ���i�敪���g�p�\��
                        this.ItemTypeCode_tNedit.Enabled = true;        // ���i�敪
                        this.ItemTypeGuide_ultraButton.Enabled = true;  // ���i�敪�K�C�h
                        // ����ȊO�͎g�p�s�\��
                        this.BLGroupCode_tNedit.Enabled = false;        // BL�O���[�v
                        this.BLGroupGuide_ultraButton.Enabled = false;  // BL�O���[�v�K�C�h
                        this.BLCode_tNedit.Enabled = false;             // BL�R�[�h
                        this.BLCodeGuide_ultraButton.Enabled = false;   // BL�R�[�h�K�C�h
                        this.SalesTypeCode_tNedit.Enabled = false;      // �̔��敪
                        this.SalesTypeGuide_ultraButton.Enabled = false;// �̔��敪�K�C�h

                        this.GoodsMakerCd_tNedit.Enabled = false;		// ���[�J�[�R�[�h
                        this.GoodsMakerCdGuide_Button.Enabled = false;	// ���[�J�[�K�C�h
                        this.GoodsCode_tEdit.Enabled = false;			// ���i�R�[�h
                        this.GoodsCodeGuide_Button.Enabled = false;		// ���i�K�C�h

                        // ���͕s���ڃN���A
                        this.BLGroupCode_tNedit.Clear();
                        this.BLGroupName_tEdit.Clear();
                        this.BLCode_tNedit.Clear();
                        this.BLCodeName_tEdit.Clear();
                        this.SalesTypeCode_tNedit.Clear();
                        this.SalesTypeName_tEdit.Clear();

                        this.GoodsMakerCd_tNedit.Clear();
                        this.GoodsMakerCdNm_tEdit.Clear();
                        this.GoodsCode_tEdit.Clear();
                        this.GoodsName_tEdit.Clear();
                        break;
                    }
			}
			// �I�������ԍ���ێ�
			this._targetContrastCd_tComboEditorValue = targetContrastCd;
		}

//----- ueno add---------- end   2007.11.21

		//----- ueno add---------- start 2008.03.05
		#region ���[�J�[�R�[�h�G���[�`�F�b�N����
		/// <summary>
		/// ���[�J�[�R�[�h�G���[�`�F�b�N����
		/// </summary>
		/// <param name="inParamObj">�����I�u�W�F�N�g</param>
		/// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
		/// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
		/// <remarks>
		/// <br>Note       : ���[�J�[�R�[�h�̃G���[�`�F�b�N���s���܂��B
		///					 �����I�u�W�F�N�g:���[�J�[�R�[�h
		///					 ���ʃI�u�W�F�N�g:���[�J�[�}�X�^�������ʃX�e�[�^�X, ���[�J�[����</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.03.05</br>
		/// </remarks>
		private int CheckGoodsMakerCd(object inParamObj, out object outParamObj)
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
				MakerUMnt makerUMnt = null;

				this.Cursor = Cursors.WaitCursor;
				status = this._makerAcs.Read(out makerUMnt, this._enterpriseCode, (int)inParamObj);
				this.Cursor = Cursors.Default;

				outParamList.Add(status);	// ���[�J�[�}�X�^�X�e�[�^�X�ݒ�

				if (makerUMnt == null)
				{
					ret = (int)InputChkStatus.NotExist;
				}
				else
				{
					ret = (int)InputChkStatus.Normal;
					outParamList.Add(makerUMnt.MakerName);	// ���[�J�[���̐ݒ�
				}
			}
			catch (Exception)
			{
			}
			outParamObj = outParamList;

			return ret;
		}
		#endregion ���[�J�[�R�[�h�G���[�`�F�b�N����

		#region ���i�R�[�h�G���[�`�F�b�N����
		/// <summary>
		/// ���i�R�[�h�G���[�`�F�b�N����
		/// </summary>
		/// <param name="inParamObj">�����I�u�W�F�N�g</param>
		/// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
		/// <returns>�`�F�b�N���ʁi0:����, 0�ȊO:�G���[�j</returns>
		/// <remarks>
		/// <br>Note       : ���i�R�[�h�̃G���[�`�F�b�N���s���܂��B
		///					 �����I�u�W�F�N�g:���[�J�[�R�[�h, ���i�R�[�h
		///					 ���ʃI�u�W�F�N�g:���i�}�X�^�������ʃX�e�[�^�X, ���i�R�[�h, ���i����, ���[�J�[�R�[�h, ���[�J�[����</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.03.05</br>
		/// </remarks>
		private int CheckGoodsNoCd(object inParamObj, out object outParamObj)
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
				if (inParamObj == null) return ret;
				if ((inParamObj is ArrayList) == false) return ret;

				inParamList = inParamObj as ArrayList;	// ArrayList�փL���X�g

				if ((inParamList == null) || (inParamList.Count != 2)) return ret;
				if ((inParamList[0] is int) == false) return ret;
				if ((inParamList[1] is string) == false) return ret;
				if ((string)inParamList[1] == "") return ret;

				//--------------
				// ���݃`�F�b�N
				//--------------
				List<GoodsUnitData> goodsUnitDataList = null;

				// �����̎�ނ��擾
				string searchCode;
				int searchType = GetSearchType((string)inParamList[1], out searchCode);

				MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();
				GoodsCndtn goodsCndtn = new GoodsCndtn();

				// ���i���������ݒ�
				goodsCndtn.EnterpriseCode = this._enterpriseCode;
				goodsCndtn.SectionCode = this._sectionCode;
				goodsCndtn.GoodsMakerCd = this.GoodsMakerCd_tNedit.GetInt();
				goodsCndtn.MakerName = this.GoodsMakerCdNm_tEdit.Text;
				goodsCndtn.GoodsNo = searchCode.TrimEnd();
				goodsCndtn.GoodsNoSrchTyp = searchType;

				string message;
				this.Cursor = Cursors.WaitCursor;
				// �ǂݍ���
				status = goodsSelectGuide.ReadGoods(this, false, goodsCndtn, out goodsUnitDataList, out message);
				this.Cursor = Cursors.Default;

				outParamList.Add(status);	// ���i�}�X�^�X�e�[�^�X�ݒ�

				if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
				{
					// ���i�}�X�^�f�[�^�N���X
					GoodsUnitData goodsUnitData = new GoodsUnitData();
					goodsUnitData = goodsUnitDataList[0];

					outParamList.Add(goodsUnitData.GoodsNo);		// ���i�R�[�h
					outParamList.Add(goodsUnitData.GoodsName);		// ���i���̐ݒ�
					outParamList.Add(goodsUnitData.GoodsMakerCd);	// ���[�J�[�R�[�h�ݒ�
					outParamList.Add(goodsUnitData.MakerName);		// ���[�J�[���̐ݒ�

					ret = (int)InputChkStatus.Normal;
				}
				else if (status == -1)
				{
					// �I���_�C�A���O�ŃL�����Z��
					ret = (int)InputChkStatus.Cancel;
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
		#endregion ���i�R�[�h�G���[�`�F�b�N����

		#region ���[�J�[�R�[�h�ݒ菈��
		/// <summary>
		/// ���[�J�[�R�[�h�ݒ菈��
		/// </summary>
		/// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
		/// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
		/// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ���[�J�[�R�[�h�i�P�i�j����ʂɐݒ肵�܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.03.05</br>
		/// </remarks>
		private void DispSetGoodsMakerCd(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// �f�[�^�N���A
						{
							this.GoodsMakerCd_tNedit.Clear();
							this.GoodsMakerCdNm_tEdit.Clear();

							// ���݃f�[�^�N���A
							this._goodsMakerCdWork = 0;

							// ���i�R�[�h�N���A
							this.GoodsCode_tEdit.Clear();
							this.GoodsName_tEdit.Clear();
							this._goodsCodeWork = "";

							//----- ueno upd ---------- start 2008.03.07
							// �t�H�[�J�X
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:		// ���ɖ߂�
						{
							this.GoodsMakerCd_tNedit.SetInt(this._goodsMakerCdWork);

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
									this.GoodsMakerCdNm_tEdit.Text = (string)outParamList[1];	// ���[�J�[����

									//----------------------------
									// ���[�J�[�R�[�h�ύX�`�F�b�N
									//----------------------------
									if (this._goodsMakerCdWork != this.GoodsMakerCd_tNedit.GetInt())
									{
										// ���[�J�[�R�[�h�ύX���́A���i�R�[�h�N���A
										this.GoodsCode_tEdit.Clear();
										this.GoodsName_tEdit.Clear();
										this._goodsCodeWork = "";
									}

									// ���݃f�[�^�ۑ�
									this._goodsMakerCdWork = this.GoodsMakerCd_tNedit.GetInt();
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
		#endregion ���[�J�[�R�[�h�ݒ菈��

		#region ���i�R�[�h�ݒ菈��
		/// <summary>
		/// ���i�R�[�h�ݒ菈��
		/// </summary>
		/// <param name="dispSetStatus">���̓`�F�b�N�t���O</param>
		/// <param name="canChangeFocus">�t�H�[�J�X�t���O</param>
		/// <param name="outParamObj">���ʃI�u�W�F�N�g</param>
		/// <remarks>
		/// <br>Note       : ���i�R�[�h����ʂɐݒ肵�܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.03.05</br>
		/// </remarks>
		private void DispSetGoodsNoCd(DispSetStatus dispSetStatus, ref bool canChangeFocus, object outParamObj)
		{
			ArrayList outParamList = null;

			try
			{
				switch (dispSetStatus)
				{
					case DispSetStatus.Clear:	// �f�[�^�N���A
						{
							this.GoodsCode_tEdit.Clear();
							this.GoodsName_tEdit.Clear();

							// ���݃f�[�^�N���A
							this._goodsCodeWork = "";

							//----- ueno upd ---------- start 2008.03.07
							// �t�H�[�J�X
							canChangeFocus = ((outParamObj != null) && (outParamObj is ArrayList)) ? false : true;
							//----- ueno upd ---------- end 2008.03.07

							break;
						}
					case DispSetStatus.Back:		// ���ɖ߂�
						{
							this.GoodsCode_tEdit.DataText = this._goodsCodeWork;

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
									&& (outParamList.Count == 5)
									&& (outParamList[1] is string)
									&& (outParamList[2] is string)
									&& (outParamList[3] is int)
									&& (outParamList[4] is string))
								{
									this.GoodsCode_tEdit.Text = (string)outParamList[1];		// ���i�R�[�h
									this.GoodsName_tEdit.Text = (string)outParamList[2];		// ���i����
									this.GoodsMakerCd_tNedit.SetInt((int)outParamList[3]);		// ���[�J�[�R�[�h
									this.GoodsMakerCdNm_tEdit.Text = (string)outParamList[4];	// ���[�J�[����

									// ���݃f�[�^�ۑ�
									this._goodsCodeWork = this.GoodsCode_tEdit.DataText;
									this._goodsMakerCdWork = this.GoodsMakerCd_tNedit.GetInt();
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
		#endregion ���i�R�[�h�ݒ菈��

		#region �f�[�^�����G���[���b�Z�[�W�o�͏���
		/// <summary>
		/// �f�[�^�����G���[���b�Z�[�W�o�͏���
		/// </summary>
		/// <param name="errMsg">�G���[�����ӏ�</param>
		/// <returns>�쐬���ꂽ�G���[���b�Z�[�W</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�����̃G���[���b�Z�[�W���o�͂��܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.03.05</br>
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

		//----- ueno add---------- end 2008.03.05

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

			//----- ueno add---------- start 2008.03.05
			//InputChk inputChk = InputChk.None;
			
			bool canChangeFocus = true;
			DispSetStatus dispSetStatus = DispSetStatus.Clear;
			
			object inParamObj = null;
			object outParamObj = null;
			ArrayList inParamList = new ArrayList();
			//----- ueno add---------- end 2008.03.05
			
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
			
				#region case ���[�J�[�R�[�h�i�P�i�j
				case "GoodsMakerCd_tNedit":
					{
						// �ύX��������Ώ������Ȃ�
						if (this.GoodsMakerCd_tNedit.GetInt() == this._goodsMakerCdWork)
						{
							break;
						}

						//--------------
						// ���݃`�F�b�N
						//--------------
						//----- ueno add ---------- start 2008.03.05
						// �����ݒ�
						inParamObj = this.GoodsMakerCd_tNedit.GetInt();

						// ���݃`�F�b�N
						switch (CheckGoodsMakerCd(inParamObj, out outParamObj))
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
											ShowNotFoundErrMsg("���[�J�[�R�[�h"), 	// �\�����郁�b�Z�[�W
											0,										// �X�e�[�^�X�l
											MessageBoxButtons.OK);					// �\������{�^��
									
									dispSetStatus = this._goodsMakerCdWork == 0 ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// �f�[�^�ݒ�
						DispSetGoodsMakerCd(dispSetStatus,  ref canChangeFocus, outParamObj);
						//----- ueno add ---------- end 2008.03.05

						#region del 2008.03.05
						//----- ueno del ---------- start 2008.03.05
						//MakerUMnt makerUMnt = null;
						//if (this.GoodsMakerCd_tNedit.DataText != "")
						//{
						//    MakerAcs makerAcs = new MakerAcs();

						//    // �f�[�^���݃`�F�b�N
						//    this.Cursor = Cursors.WaitCursor;
						//    int ret = makerAcs.Read(out makerUMnt, this._enterpriseCode, this.GoodsMakerCd_tNedit.GetInt());
						//    this.Cursor = Cursors.Default;

						//    if (ret != 0)
						//    {
						//        string errMessage = "�w�肳�ꂽ�����ŁA���[�J�[�R�[�h�͑��݂��܂���ł����B";
						//        TMsgDisp.Show(
						//                this, 							// �e�E�B���h�E�t�H�[��
						//                emErrorLevel.ERR_LEVEL_INFO, 	// �G���[���x��
						//                this.Name,						// �A�Z���u��ID
						//                errMessage, 					// �\�����郁�b�Z�[�W
						//                0,								// �X�e�[�^�X�l
						//                MessageBoxButtons.OK);			// �\������{�^��

						//        inputChk = this._goodsMakerCdWork == 0 ? InputChk.None : InputChk.Back;
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
						//            this.GoodsMakerCd_tNedit.Clear();
						//            this.GoodsMakerCdNm_tEdit.Clear();

						//            // ���݃f�[�^�N���A
						//            this._goodsMakerCdWork = 0;

						//            // �t�H�[�J�X
						//            e.NextCtrl = e.PrevCtrl;
						//            break;
						//        }
						//    case InputChk.Back:		// ���ɖ߂�
						//        {
						//            this.GoodsMakerCd_tNedit.SetInt(this._goodsMakerCdWork);
						//            break;
						//        }
						//    case InputChk.Update:	// �X�V
						//        {
						//            this.GoodsMakerCdNm_tEdit.DataText = makerUMnt.MakerShortName;

						//            // ���݃f�[�^�ۑ�
						//            this._goodsMakerCdWork = this.GoodsMakerCd_tNedit.GetInt();

						//            // ���[�J�[�ɕR�Â����i�R�[�h, ���i���̃N���A
						//            this.GoodsCode_tEdit.Clear();
						//            this.GoodsName_tEdit.Clear();
						//            this._goodsCodeWork = "";
						//            break;
						//        }
						//}
						//----- ueno del ---------- end 2008.03.05
						#endregion del 2008.03.05

						break;
					}
				#endregion

				#region case ���i�R�[�h
				case "GoodsCode_tEdit":
					{
						// �ύX��������Ώ������Ȃ�
						if (string.Equals(this.GoodsCode_tEdit.DataText, this._goodsCodeWork) == true)
						{
							break;
						}

						//--------------
						// ���݃`�F�b�N
						//--------------
						//----- ueno add ---------- start 2008.03.05
						// �����ݒ�
						inParamList.Add(this.GoodsMakerCd_tNedit.GetInt());
						inParamList.Add(this.GoodsCode_tEdit.Text);
						inParamObj = inParamList;

						// ���݃`�F�b�N
						switch (CheckGoodsNoCd(inParamObj, out outParamObj))
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
							case (int)InputChkStatus.Cancel:
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
											ShowNotFoundErrMsg("���i�R�[�h"), 		// �\�����郁�b�Z�[�W
											0,										// �X�e�[�^�X�l
											MessageBoxButtons.OK);					// �\������{�^��

									dispSetStatus = this._goodsCodeWork == "" ? DispSetStatus.Clear : DispSetStatus.Back;
									break;
								}
						}
						// �f�[�^�ݒ�
						DispSetGoodsNoCd(dispSetStatus,  ref canChangeFocus, outParamObj);
						break;
						//----- ueno add ---------- end 2008.03.05
						
						#region del 2008.03.05
						//----- ueno del ---------- start 2008.03.05
						//List<GoodsUnitData> goodsUnitDataList = null;
						//if (this.GoodsCode_tEdit.DataText != "")
						//{
						//    int ret = -1;

						//    // �����̎�ނ��擾
						//    string searchCode;
						//    int searchType = this.GetSearchType(this.GoodsCode_tEdit.DataText, out searchCode);

						//    // �ʏ팟��
						//    if (searchType == 0)
						//    {
						//        this.Cursor = Cursors.WaitCursor;
						//        ret = this._goodsAcs.Read(this._enterpriseCode, searchCode, out goodsUnitDataList);
						//        this.Cursor = Cursors.Default;
						//    }
						//    // �B������
						//    else
						//    {
						//        MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

						//        string message;
						//        this.Cursor = Cursors.WaitCursor;
						//        int status = goodsSelectGuide.ReadGoods(this, this._enterpriseCode, searchType, searchCode, out goodsUnitDataList, out message);
						//        this.Cursor = Cursors.Default;

						//        if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
						//        {
						//            ret = 0;
						//        }
						//    }

						//    if ((goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
						//    {
						//        inputChk = InputChk.Update;
						//    }
						//    else
						//    {
						//        string errMessage = "�w�肳�ꂽ�����ŁA���i�R�[�h�͑��݂��܂���ł����B";
						//        TMsgDisp.Show(
						//                this, 							// �e�E�B���h�E�t�H�[��
						//                emErrorLevel.ERR_LEVEL_INFO, 	// �G���[���x��
						//                this.Name,						// �A�Z���u��ID
						//                errMessage, 					// �\�����郁�b�Z�[�W
						//                0,								// �X�e�[�^�X�l
						//                MessageBoxButtons.OK);			// �\������{�^��

						//        inputChk = this._goodsCodeWork == "" ? InputChk.None : InputChk.Back;
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
						//            this.GoodsCode_tEdit.Clear();
						//            this.GoodsName_tEdit.Clear();

						//            // ���݃f�[�^�N���A
						//            this._goodsCodeWork = "";

						//            // �t�H�[�J�X
						//            e.NextCtrl = e.PrevCtrl;
						//            break;
						//        }
						//    case InputChk.Back:		// ���ɖ߂�
						//        {
						//            this.GoodsCode_tEdit.DataText = this._goodsCodeWork;
						//            break;
						//        }
						//    case InputChk.Update:	// �X�V
						//        {
						//            if ((goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
						//            {
						//                // ���i�}�X�^�f�[�^�N���X
						//                GoodsUnitData wkGoodsUnitData = new GoodsUnitData();
						//                wkGoodsUnitData = goodsUnitDataList[0];

						//                this.GoodsCode_tEdit.DataText = wkGoodsUnitData.GoodsNo;			// ���i�R�[�h�ݒ�
						//                this.GoodsName_tEdit.DataText = wkGoodsUnitData.GoodsName;			// ���i���̐ݒ�
						//                this.GoodsMakerCd_tNedit.SetInt(wkGoodsUnitData.GoodsMakerCd);		// ���[�J�[�R�[�h�ݒ�
						//                this.GoodsMakerCdNm_tEdit.DataText = wkGoodsUnitData.MakerName;		// ���[�J�[���̐ݒ�

						//                // ���݃f�[�^�ۑ�
						//                this._goodsCodeWork = this.GoodsCode_tEdit.DataText;
						//                this._goodsMakerCdWork = this.GoodsMakerCd_tNedit.GetInt();
						//            }
						//            break;
						//        }
						//}
						//----- ueno del ---------- end 2008.03.05
						#endregion del 2008.03.05
					}
				#endregion
			}

			//----- ueno add ---------- start 2008.03.05
			// �t�H�[�J�X����
			if (canChangeFocus == false)
			{
				e.NextCtrl = e.PrevCtrl;

				//----- ueno add ---------- start 2008.03.07
				// ���݂̍��ڂ���ړ������A�e�L�X�g�S�I����ԂƂ���
				e.NextCtrl.Select();
				//----- ueno add ---------- end 2008.03.07
			}
			//----- ueno add ---------- end 2008.03.05
		}
//----- ueno add---------- end   2007.11.21

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Form_Load �C�x���g����(MAMOK09130U)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �t�H�[�����[�h�������s���܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.02</br>
		/// </remarks>
		private void MAMOK09130UA_Load(object sender, EventArgs e)
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
			
			if (SalesTarget._targetContrastCdGoodsSList.Count > 0)
			{
				foreach (DictionaryEntry de in SalesTarget._targetContrastCdGoodsSList)
				{
					this.TargetContrastCd_tComboEditor.Items.Add(de.Key, de.Value.ToString());
				}
				this.TargetContrastCd_tComboEditor.Value = SalesTarget._targetContrastCdGoodsSList.GetKey(0);
			}
//----- ueno add---------- end   2007.11.21

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA ADD START
            // ���_���̎擾
            SecInfoSet secInfoSet;
            //SecInfoAcs secInfoAcs = new SecInfoAcs();
            SecInfoSetAcs secInfoSetAcs = new SecInfoSetAcs();

            // ���_���̂��󂯎����salesTarget�I�u�W�F�N�g�̋��_�R�[�h����擾
            this._sectionCode = this._salesTarget.SectionCode;

            //----- ueno add---------- start 2008.03.05
            // ���_�R�[�h�擾
            //this._sectionCode = secInfoSet.SectionCode.TrimEnd();
            //----- ueno add---------- end 2008.03.05

            int status = secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, _sectionCode);

            if (secInfoSet != null)
            {
                this._sectionName = secInfoSet.SectionGuideNm.TrimEnd();
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA ADD END

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

            // �ڕW�Δ�敪�̒l�ɂ����͂ł��鍀�ڂ𐧌�
            // �N�����͎g�p�s�\��
            this.SalesTypeCode_tNedit.Enabled = false;      // �̔��敪
            this.SalesTypeGuide_ultraButton.Enabled = false;// �̔��敪�K�C�h
            this.BLGroupCode_tNedit.Enabled = false;        // BL�O���[�v
            this.BLGroupGuide_ultraButton.Enabled = false;  // BL�O���[�v�K�C�h
            this.BLCode_tNedit.Enabled = false;             // BL�R�[�h
            this.BLCodeGuide_ultraButton.Enabled = false;   // BL�R�[�h�K�C�h
            this.ItemTypeCode_tNedit.Enabled = false;       // ���i�敪
            this.ItemTypeGuide_ultraButton.Enabled = false; // ���i�敪�K�C�h

            this.BLGroupCode_tNedit.Clear();
            this.BLCode_tNedit.Clear();
            this.SalesTypeCode_tNedit.Clear();
            this.ItemTypeCode_tNedit.Clear();

//----- ueno add---------- start 2007.11.21
			this._targetContrastCd_tComboEditorValue = -1;	// ������
//----- ueno add---------- end   2007.11.21

            // �R���g���[������
            ControlEnabled();

			// ���Ԑݒ�
			SetTargetDate();

			//----- ueno del---------- start 2007.11.21
			// �䗦�v�Z
			//CalcFromRatio();
			//----- ueno del---------- end   2007.11.21
		}

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// FormClosing �C�x���g����(MAMOK09130UA)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �t�H�[���́~�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.07.31</br>
        /// </remarks>
        private void MAMOK09130UA_FormClosing(object sender, FormClosingEventArgs e)
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
							//// ���\�b�h�擪�Ŋi�[���Ă���̂ŕs�v
							//// �C����̖ڕW�f�[�^��ۑ�
							//ScreenToSalesTarget(out salesTarget);
							//----- ueno del---------- end   2007.11.21		

							retResult = SaveSalesTarget(ref salesTarget);
                            if (!retResult)
                            {
                                e.Cancel = true;
                                this.Close_Button.Focus();
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
                            //SalesTargetToScreen(salesTarget);
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
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.03</br>
		/// </remarks>
		private void Close_Button_Click(object sender, EventArgs e)
		{
            this.Close();
		}

		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click �C�x���g����(GoodsCodeGuide_Button)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: ���i�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.12</br>
		/// </remarks>
		private void GoodsCodeGuide_Button_Click(object sender, EventArgs e)
		{
			//----- ueno upd---------- start 2007.11.21
			GoodsNoGuide(this.GoodsMakerCd_tNedit);
			//----- ueno upd---------- end   2007.11.21

			////----- ueno del---------- start 2007.11.21
			#region del
			//MAKHN04110UA goodsSelectGuide = new MAKHN04110UA();

			//GoodsUnitData goodsUnitData;
			//DialogResult dialogResult = goodsSelectGuide.ShowGuide(this, this._enterpriseCode, out goodsUnitData);

			//if ((dialogResult == DialogResult.OK) && (goodsUnitData != null))
			//{
			//    // ���i
			//    this.GoodsCode_tEdit.DataText = goodsUnitData.GoodsNo;
			//    this.GoodsName_tEdit.DataText = goodsUnitData.GoodsName;

				//// �L�����A
				//this.CarrierName_tEdit.Tag = goodsUnitData.CarrierCode;
				//this.CarrierName_tEdit.DataText = goodsUnitData.CarrierName;

				//// �@��
				//this.CellphoneModelName_tEdit.Tag = goodsUnitData.CellphoneModelCode;
				//this.CellphoneModelName_tEdit.DataText = goodsUnitData.CellphoneModelName;

				//// �n���F
				//this.SystematicColorNm_tEdit.Tag = goodsUnitData.SystematicColorCd;
				//this.SystematicColorNm_tEdit.DataText = goodsUnitData.SystematicColorNm;
			//}
			#endregion del
			//----- ueno del---------- end   2007.11.21
		}

//----- ueno add---------- start 2007.11.21
		/*----------------------------------------------------------------------------------*/
		/// <summary>
		/// Button_Click �C�x���g����(GoodsMakerCdGuide_Button_Click)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: ���[�J�[�K�C�h�{�^�����N���b�N���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: 30167 ���@�O�M</br>
		/// <br>Date		: 2007.11.22</br>
		/// </remarks>
		private void GoodsMakerCdGuide_Button_Click(object sender, EventArgs e)
		{
			MakerUMnt makerUMnt = null;
			
			if (this._makerAcs.ExecuteGuid(this._enterpriseCode, out makerUMnt) == 0)
			{
				this.GoodsMakerCd_tNedit.SetInt(makerUMnt.GoodsMakerCd);
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.08 TOKUNAGA MODIFY START
				this.GoodsMakerCdNm_tEdit.DataText = makerUMnt.MakerName;//.MakerShortName;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.08 TOKUNAGA MODIFY END

				// ���݃f�[�^�ۑ�
				this._goodsMakerCdWork = this.GoodsMakerCd_tNedit.GetInt();
				
				// ���i�R�[�h�����͉̂Ƃ��̂�
				if(this.GoodsCode_tEdit.Enabled == true)
				{
					// ���i�R�[�h�K�C�h
					GoodsNoGuide(this.GoodsMakerCd_tNedit);
				}
			}
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
		/// Leave �C�x���g(GoodsCode_tEdit)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: �R���g���[���̃t�H�[�J�X�����ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.04.17</br>
		/// </remarks>
		private void GoodsCode_tEdit_Leave(object sender, EventArgs e)
		{
			//----- ueno del---------- start 2007.11.21
			//string goodsCode = this.GoodsCode_tEdit.Text.Trim();
			//if (goodsCode == "")
			//{
			//    this.GoodsCode_tEdit.DataText = "";
			//    this.GoodsName_tEdit.DataText = "";
			//    this.GoodsMakerCdNm_tEdit.DataText = "";

			//    //----- ueno del---------- start 2007.11.21
			//    //this.GoodsMakerCdNm_tEdit.Tag = -1;
			//    //this.CarrierName_tEdit.DataText = "";
			//    //this.CarrierName_tEdit.Tag = -1;
			//    //this.CellphoneModelName_tEdit.DataText = "";
			//    //this.CellphoneModelName_tEdit.Tag = "";
			//    //----- ueno del---------- end   2007.11.21

			//    return;
			//}
			//int status = SearchGoods(goodsCode);
			//----- ueno del---------- end   2007.11.21
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
		/// <br>Date		: 2007.05.16</br>
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
			bool bStatus = CheckDate();
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
		/// ValueChanged �C�x���g(TargetSetCd_uOptionSet)
		/// </summary>
		/// <param name="sender">�ΏۃI�u�W�F�N�g</param>
		/// <param name="e">�C�x���g�n���h��</param>
		/// <remarks>
		/// <br>Note		: ���W�I�{�^���̃`�F�b�N���ύX���ꂽ���ɔ������܂��B</br>
		/// <br>Programmer	: NEPCO</br>
		/// <br>Date		: 2007.05.16</br>
		/// </remarks>
		private void TargetSetCd_uOptionSet_ValueChanged(object sender, EventArgs e)
		{
			// ���ԖڕW
            //if ((int)this.TargetSetCd_uOptionSet.Value == 10)
			if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
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

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.07 TOKUNAGA ADD START
        /// <summary>
        /// ValueChanged �C�x���g(TargetSetCd_tComboEditor)
        /// </summary>
        /// <param name="sender">�ΏۃI�u�W�F�N�g</param>
        /// <param name="e">�C�x���g�n���h��</param>
        /// <remarks>
        /// <br>Note		: �v���_�E���̒l���ύX���ꂽ���ɔ������܂��B</br>
        /// <br>Programmer	: NEPCO</br>
        /// <br>Date		: 2007.05.16</br>
        /// </remarks>
        private void TargetSetCd_tComboEditor_ValueChanged(object sender, EventArgs e)
        {
            // ���ԖڕW
            if ((int.Parse(this.TargetSetCd_tComboEditor.SelectedItem.DataValue.ToString())) == 10)
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

        /// <summary>
        /// BL�O���[�v�K�C�h�{�^���N���b�N����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLGroupGuide_ultraButton_Click(object sender, EventArgs e)
        {
            BLGroupU blGroupUnit;
            int status = this._blGroupUAcs.ExecuteGuid(this._enterpriseCode, out blGroupUnit);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.BLGroupCode_tNedit.DataText = blGroupUnit.BLGroupCode.ToString();
                this.BLGroupName_tEdit.DataText = blGroupUnit.BLGroupName;

                // �f�[�^�ɃZ�b�g
                this._salesTarget.BLGroupCode = blGroupUnit.BLGroupCode;
            }
        }

        /// <summary>
        /// BL�O���[�v���͗�Leave�C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLGroupCode_tNedit_Leave(object sender, EventArgs e)
        {
            // �������͂���Ă���Εϊ�
            if (!string.IsNullOrEmpty(this.BLGroupCode_tNedit.Text))
            {
                try
                {
                    int blGroupCode = int.Parse(this.BLGroupCode_tNedit.Text);

                    BLGroupU blGroupUnit;
                    int status = this._blGroupUAcs.Search(out blGroupUnit, this._enterpriseCode, blGroupCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.BLGroupCode_tNedit.DataText = blGroupUnit.BLGroupCode.ToString();
                        this.BLGroupName_tEdit.DataText = blGroupUnit.BLGroupName;

                        // �f�[�^�ɃZ�b�g
                        this._salesTarget.BLGroupCode = blGroupUnit.BLGroupCode;
                    }
                }
                catch (Exception)
                {
                    // �ϊ����s
                }
            }
        }

        /// <summary>
        /// BL�R�[�h�K�C�h�{�^���N���b�N����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLCodeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            BLGoodsCdUMnt blGoodsUnit;
            int status = _blGoodsCdAcs.ExecuteGuid(this._enterpriseCode, out blGoodsUnit);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.BLCode_tNedit.DataText = blGoodsUnit.BLGoodsCode.ToString();
                this.BLCodeName_tEdit.DataText = blGoodsUnit.BLGoodsFullName;

                // �f�[�^�ɃZ�b�g
                this._salesTarget.BLCode = blGoodsUnit.BLGoodsCode;
            }
        }

        /// <summary>
        /// BL�R�[�h���͗�Leave�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BLCode_tNedit_Leave(object sender, EventArgs e)
        {
            // �������͂���Ă���Εϊ�
            if (!string.IsNullOrEmpty(this.BLCode_tNedit.Text))
            {
                try
                {
                    int blGoodsCode = int.Parse(this.BLCode_tNedit.Text);

                    BLGoodsCdUMnt blGoodsUnit;
                    int status = this._blGoodsCdAcs.Read(out blGoodsUnit, this._enterpriseCode, blGoodsCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.BLCode_tNedit.DataText = blGoodsUnit.BLGoodsCode.ToString();
                        this.BLCodeName_tEdit.DataText = blGoodsUnit.BLGoodsFullName;

                        // �f�[�^�ɃZ�b�g
                        this._salesTarget.BLCode = blGoodsUnit.BLGoodsCode;
                    }
                }
                catch (Exception)
                {
                    // �ϊ����s
                }
            }
        }


        /// <summary>
        /// �̔��敪�K�C�h�{�^���N���b�N����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesTypeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            UserGdBd userGuideBdInfo;
            UserGdHd userGuideHdInfo;
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGuideHdInfo, out userGuideBdInfo, SALES_TYPE_GUIDE);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.SalesTypeCode_tNedit.DataText = userGuideBdInfo.GuideCode.ToString();
                this.SalesTypeName_tEdit.DataText = userGuideBdInfo.GuideName;

                // �f�[�^�ɃZ�b�g
                this._salesTarget.SalesTypeCode = userGuideBdInfo.GuideCode;
            }
        }

        /// <summary>
        /// �̔��敪���͗�Leave�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SalesTypeCode_tNedit_Leave(object sender, EventArgs e)
        {
            // �������͂���Ă���Εϊ�
            if (!string.IsNullOrEmpty(this.SalesTypeCode_tNedit.Text))
            {
                try
                {
                    int salesTypeCode = int.Parse(this.SalesTypeCode_tNedit.Text);

                    UserGdBd userGuideBdInfo;
                    int status = this._userGuideAcs.ReadStaticMemory(out userGuideBdInfo, SALES_TYPE_GUIDE, salesTypeCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.SalesTypeCode_tNedit.DataText = userGuideBdInfo.GuideCode.ToString();
                        this.SalesTypeName_tEdit.DataText = userGuideBdInfo.GuideName;

                        // �f�[�^�ɃZ�b�g
                        this._salesTarget.SalesTypeCode = userGuideBdInfo.GuideCode;
                    }
                }
                catch (Exception)
                {
                    // �ϊ����s
                    // �����I�����[�Ŕ����Ă��邩����v�Ȃ͂������ǁc
                }
            }
        }

        /// <summary>
        /// ���i�敪�K�C�h�{�^���N���b�N����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemTypeGuide_ultraButton_Click(object sender, EventArgs e)
        {
            UserGdBd userGuideBdInfo;
            UserGdHd userGuideHdInfo;
            int status = this._userGuideAcs.ExecuteGuid(this._enterpriseCode, out userGuideHdInfo, out userGuideBdInfo, ITEM_TYPE_GUIDE);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this.ItemTypeCode_tNedit.DataText = userGuideBdInfo.GuideCode.ToString();
                this.ItemTypeName_tEdit.DataText = userGuideBdInfo.GuideName;

                // �f�[�^�ɃZ�b�g
                this._salesTarget.ItemTypeCode = userGuideBdInfo.GuideCode;
            }
        }

        /// <summary>
        /// ���i�敪���͗�Leave�C�x���g����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ItemTypeCode_tNedit_Leave(object sender, EventArgs e)
        {
            // �������͂���Ă���Εϊ�
            if (!string.IsNullOrEmpty(this.ItemTypeCode_tNedit.Text))
            {
                try
                {
                    int itemTypeCode = int.Parse(this.ItemTypeCode_tNedit.Text);

                    UserGdBd userGuideBdInfo;
                    int status = this._userGuideAcs.ReadStaticMemory(out userGuideBdInfo, ITEM_TYPE_GUIDE, itemTypeCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this.ItemTypeCode_tNedit.DataText = userGuideBdInfo.GuideCode.ToString();
                        this.ItemTypeName_tEdit.DataText = userGuideBdInfo.GuideName;

                        // �f�[�^�ɃZ�b�g
                        this._salesTarget.ItemTypeCode = userGuideBdInfo.GuideCode;
                    }
                }
                catch (Exception)
                {
                    // �ϊ����s
                }
            }
        }




        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.07 TOKUNAGA ADD END
	}
}