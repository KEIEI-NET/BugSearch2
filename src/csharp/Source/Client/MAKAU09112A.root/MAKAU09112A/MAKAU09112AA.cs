//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F���Ӑ���яC��
// �v���O�����T�v   �F���Ӑ���яC���̓o�^�E�ύX�E�폜���s��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F21024 ���X�� ��
// �C����    2009/01/06     �C�����e�FPartsman�p�ɕύX
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E �K�j
// �C����    2009/01/30     �C�����e�F��QID:10603�Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30413 ����
// �C����    2009/06/23     �C�����e�FMantis�y13484�z������No��ǉ�
// ---------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    ///���Ӑ攄�|���z�}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���Ӑ攄�|���z�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 30154 ���� ���m</br>
    /// <br>Date       : 2007.04.20</br>
    /// <br></br>
    /// <br>Note       : ����.NS�p�ɕύX</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2007.09.27</br>
    /// <br></br>
    /// <br>Note       : PM.NS�p�ɕύX</br>
    /// <br>Programmer : 21024 ���X�� ��</br>
    /// <br>Date       : 2009.01.06</br>
    /// <br></br>
    /// <br>Note       : ��QID:10603�Ή�</br>
    /// <br>Programmer : 30414 �E �K�j</br>
    /// <br>Date       : 2009.01.30</br>
    /// </remarks>
	public class CustAccRecDmdPrcAcs
	{
		// --------------------------------------------------
		#region Private Members

        // ��ƃR�[�h
        private string              _enterpriseCode         = "";

        /// <summary>���Ӑ攄�|���z�}�X�^�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private ICustRsltUpdDB _iCustRsltUpdDB = null;

        // �f�[�^�Z�b�g
        private DataSet             _bindDataSet        = null;
        private DataTable           _custAccRecTable    = null;
        private DataTable           _custDmdPrcTable    = null;
        // 2009.01.06 Add >>>
        private DataTable _custAccRecTotalTable = null;
        private DataTable _custDmdPrcTotalTable = null;
        // 2009.01.06 Add <<<
        

        // �}�X�^�N���X�i�[���X�g
        private Dictionary<Guid, CustAccRecWork>  _custAccRecDic  = null;               // ���Ӑ攄�|���z�}�X�^�i�[�p
        private Dictionary<Guid, CustDmdPrcWork>  _custDmdPrcDic  = null;               // ���Ӑ搿�����z�}�X�^�i�[�p

        // �}�X�^�擾�p���X�g
        // 2009.01.06 >>>
        //private ArrayList           _custAccRecList     = null;                         // ���Ӑ攄�|���z�}�X�^�擾�p
        //private ArrayList           _custDmdPrcList     = null;                         // ���Ӑ搿�����z�}�X�^�擾�p
        private CustomSerializeArrayList _custAccRecList = null;                         // ���Ӑ攄�|���z�}�X�^�擾�p
        private CustomSerializeArrayList _custDmdPrcList = null;                         // ���Ӑ搿�����z�}�X�^�擾�p

        MoneyKindAcs _moneyKindAcs = null;
        // 2009.01.06 <<<

        #endregion

        // --------------------------------------------------
        #region Public Members

        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        public static readonly string TBL_CUSTACCREC_TITLE           = "CUSTACCREC_TABLE";
        public static readonly string TBL_CUSTDMDPRC_TITLE           = "CUSTDMDPRC_TABLE";
        //public static readonly string TBL_CUSTACCREC_TITLE           = "campanyTab";
        //public static readonly string TBL_CUSTDMDPRC_TITLE           = "customerTab";

        // 2009.01.06 Add >>>
        public static readonly string TBL_CUSTACCRECTOTAL_TITLE = "CUSTACCRECTOTAL_TABLE";
        public static readonly string TBL_CUSTDMDPRCTOTAL_TITLE = "CUSTDMDPRCTOTAL_TABLE";
        // 2009.01.06 Add <<<
        
        public static readonly string COL_DELETEDATE_TITLE           = "�폜��";
        public static readonly string COL_ADDUPSECCODE_TITLE         = "�v�㋒�_�R�[�h";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
        public static readonly string COL_RESULTSECCODE_TITLE       = "���ы��_�R�[�h";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END
        
        public static readonly string COL_CUSTOMERCODE_TITLE         = "���Ӑ�R�[�h";
        public static readonly string COL_CUSTOMERNAME_TITLE         = "���Ӑ於��";
        public static readonly string COL_CUSTOMERNAME2_TITLE        = "���Ӑ於��2";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        public static readonly string COL_CUSTOMERSNM_TITLE          = "���Ӑ旪��";
        public static readonly string COL_CLAIMCODE_TITLE            = "������R�[�h";
        public static readonly string COL_CLAIMNAME_TITLE            = "�����於��";
        public static readonly string COL_CLAIMNAME2_TITLE           = "�����於��2";
        public static readonly string COL_CLAIMSNM_TITLE             = "�����旪��";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_ADDUPDATEJP_TITLE          = "�v���";
        public static readonly string COL_ADDUPYEARMONTHJP_TITLE     = "�v��N��";
		public static readonly string COL_ADDUPYEARMONTH_TITLE       = "_�v��N��";
		public static readonly string COL_ADDUPDATE_TITLE            = "_�v��N����";
        public static readonly string COL_LASTTIMEACCREC_TITLE       = "�O��c��";                  // �O�񔄊|���z
        public static readonly string COL_LASTTIMEDEMAND_TITLE       = "�O��c��";                  // �O�񐿋����z
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //public static readonly string COL_THISTIMEDMDNRML_TITLE      = "����������z�i�ʏ�����j";
        //public static readonly string COL_THISTIMEFEEDMDNRML_TITLE   = "����萔���z�i�ʏ�����j";
        //public static readonly string COL_THISTIMEDISDMDNRML_TITLE   = "����l���z�i�ʏ�����j";
        //public static readonly string COL_THISTIMERBTDMDNRML_TITLE   = "���񃊃x�[�g�z�i�ʏ�����j";
        //public static readonly string COL_THISTIMEDMDDEPO_TITLE      = "����������z�i�a����j";
        //public static readonly string COL_THISTIMEFEEDMDDEPO_TITLE   = "����萔���z�i�a����j";
        //public static readonly string COL_THISTIMEDISDMDDEPO_TITLE   = "����l���z�i�a����j";
        //public static readonly string COL_THISTIMERBTDMDDEPO_TITLE   = "���񃊃x�[�g�z�i�a����j";
        public static readonly string COL_THISTIMEDMDNRML_TITLE      = "����������z";
        public static readonly string COL_THISTIMEFEEDMDNRML_TITLE   = "����萔���z";
        public static readonly string COL_THISTIMEDISDMDNRML_TITLE   = "����l���z";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_THISTIMEDEPODMD_TITLE      = "�������";
        public static readonly string COL_THISTIMETTLBLCACC_TITLE    = "����J�z�c���i���|�v�j";
        public static readonly string COL_THISTIMETTLBLCDMD_TITLE    = "����J�z�c���i�����v�j";
        public static readonly string COL_THISTIMESALES_TITLE        = "���񔄏���z";                  // ���񔄏���z
        public static readonly string COL_THISSALESTAX_TITLE         = "���񔄏�����";                    // ���񔄏�����
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //public static readonly string COL_TTLINCDTBTTAXEXC_TITLE     = "����x��";                  // �x���C���Z���e�B�u�z���v�i�Ŕ����j
        //public static readonly string COL_TTLINCDTBTTAX_TITLE        = "�x�������";                // �x���C���Z���e�B�u�z���v�i�Łj
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_OFSTHISTIMESALES_TITLE     = "���񔄏�";  // ��������z
        public static readonly string COL_OFSTHISSALESTAX_TITLE      = "�����";    // ����������
        public static readonly string COL_ITDEDOFFSETOUTTAX_TITLE    = "���E��O�őΏۊz";
        public static readonly string COL_ITDEDOFFSETINTAX_TITLE     = "���E����őΏۊz";
        public static readonly string COL_ITDEDOFFSETTAXFREE_TITLE   = "���E���ېőΏۊz";
        public static readonly string COL_OFFSETOUTTAX_TITLE         = "���E��O�ŏ����";
        public static readonly string COL_OFFSETINTAX_TITLE          = "���E����ŏ����";
        public static readonly string COL_ITDEDSALESOUTTAX_TITLE     = "����O�őΏۊz";
        public static readonly string COL_ITDEDSALESINTAX_TITLE      = "������őΏۊz";
        public static readonly string COL_ITDEDSALESTAXFREE_TITLE    = "�����ېőΏۊz";
        public static readonly string COL_SALESOUTTAX_TITLE          = "����O�Ŋz";
        public static readonly string COL_SALESINTAX_TITLE           = "������Ŋz";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //public static readonly string COL_ITDEDPAYMOUTTAX_TITLE      = "�x���O�őΏۊz";
        //public static readonly string COL_ITDEDPAYMINTAX_TITLE       = "�x�����őΏۊz";
        //public static readonly string COL_ITDEDPAYMTAXFREE_TITLE     = "�x����ېőΏۊz";
        //public static readonly string COL_PAYMENTOUTTAX_TITLE        = "�x���O�ŏ����";
        //public static readonly string COL_PAYMENTINTAX_TITLE         = "�x�����ŏ����";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        public static readonly string COL_TTLITDEDRETOUTTAX_TITLE    = "�ԕi�O�őΏۊz";
        public static readonly string COL_TTLITDEDRETINTAX_TITLE     = "�ԕi���őΏۊz";
        public static readonly string COL_TTLITDEDRETTAXFREE_TITLE   = "�ԕi��ېőΏۊz";
        public static readonly string COL_TTLRETOUTERTAX_TITLE       = "�ԕi�O�Ŋz";
        public static readonly string COL_TTLRETINNERTAX_TITLE       = "�ԕi���Ŋz";
        public static readonly string COL_TTLITDEDDISOUTTAX_TITLE    = "�l���O�őΏۊz";
        public static readonly string COL_TTLITDEDDISINTAX_TITLE     = "�l�����őΏۊz";
        public static readonly string COL_TTLITDEDDISTAXFREE_TITLE   = "�l����ېőΏۊz";
        public static readonly string COL_TTLDISOUTERTAX_TITLE       = "�l���O�Ŋz";
        public static readonly string COL_TTLDISINNERTAX_TITLE       = "�l�����Ŋz";
        public static readonly string COL_BALANCEADJUST_TITLE        = "�c�������z";

        public static readonly string COL_NONSTMNTAPPEARANCE_TITLE   = "�����ϋ��z�i���U�j";
        public static readonly string COL_NONSTMNTISDONE_TITLE       = "�����ϋ��z�i�􂵁j";
        public static readonly string COL_STMNTAPPEARANCE_TITLE      = "���ϋ��z�i���U�j";
        public static readonly string COL_STMNTISDONE_TITLE          = "���ϋ��z�i�􂵁j";

        //public static readonly string COL_THISCASHSALEPRICE          = "���񌻋�����z";
        //public static readonly string COL_THISCASHSALETAX            = "���񌻋��������Ŋz";
        public static readonly string COL_SALESSLIPCOUNT_TITLE             = "����`�[����";
        public static readonly string COL_BILLPRINTDATE_TITLE              = "���������s��";
        public static readonly string COL_EXPECTEDDEPOSITDATE_TITLE        = "�����\���";
        public static readonly string COL_COLLECTCOND_TITLE                = "�������";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_CONSTAXLAYMETHOD_TITLE     = "����œ]�ŕ���";
        public static readonly string COL_CONSTAXRATE_TITLE          = "����ŗ�";
        public static readonly string COL_FRACTIONPROCCD_TITLE       = "�[�������敪";
        public static readonly string COL_AFCALTMONTHACCREC_TITLE    = "���|�c��";                  // �v�Z�㓖�����|���z
        public static readonly string COL_AFCALDEMANDPRICE_TITLE     = "���|�c��";                  // �v�Z�㐿�����z
        public static readonly string COL_ACPODRTTL2TMBFACCREC_TITLE = "�O�X��c��";              // ��2��O�c��(���|�v)
        public static readonly string COL_ACPODRTTL2TMBFBLDMD_TITLE  = "�O�X��c��";              // ��2��O�c��(�����v)
        public static readonly string COL_ACPODRTTL3TMBFACCREC_TITLE = "�O�X�X��c��";              // ��3��O�c��(���|�v)
        public static readonly string COL_ACPODRTTL3TMBFBLDMD_TITLE  = "�O�X�X��c��";              // ��3��O�c��(�����v)
        public static readonly string COL_MONTHADDUPEXPDATE_TITLE    = "�����X�V���s�N����";
        public static readonly string COL_CADDUPUPDEXECDATE_TITLE    = "�����X�V���s�N����";
        // 2009.01.06 Add >>>
        public static readonly string COL_STMONCADDUPUPDDATE_TITLE = "�����X�V�J�n�N����";
        public static readonly string COL_LAMONCADDUPUPDDATE_TITLE = "�O�񌎎��X�V�N����";
        public static readonly string COL_STARTCADDUPUPDDATE_TITLE = "�����X�V�J�n�N����";
        public static readonly string COL_LASTCADDUPUPDDATE_TITLE = "�O������X�V�N����";
        // 2009.01.06 Add <<<
        public static readonly string COL_DMDPROCNUM_TITLE           = "���������ʔ�";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //public static readonly string COL_THISPAYOFFSET_TITLE        = "����x�����E���z";
        //public static readonly string COL_THISPAYOFFSETTAX_TITLE     = "����x�����E�����";
        //public static readonly string COL_ITDEDPAYMOUTTAX_TITLE      = "�x���O�őΏۊz";
        //public static readonly string COL_ITDEDPAYMINTAX_TITLE       = "�x�����őΏۊz";
        //public static readonly string COL_ITDEDPAYMTAXFREE_TITLE     = "�x����ېőΏۊz";
        //public static readonly string COL_PAYMENTOUTTAX_TITLE        = "�x���O�ŏ����";
        //public static readonly string COL_PAYMENTINTAX_TITLE         = "�x�����ŏ����";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

        public static readonly string COL_TAXADJUST_TITLE = "����Œ����z";
        public static readonly string COL_TOTALADJUST_TITLE = "�c�������z�\��";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        public static readonly string COL_GUID_TITLE                 = "GUID";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        public static readonly string COL_CREATEDATETIME             = "�쐬����";
        public static readonly string COL_UPDATEDATETIME             = "�X�V����";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // ADD 2009/06/23 ------>>>
        public static readonly string COL_BILLNO_TITLE = "������No";
        // ADD 2009/06/23 ------<<<
        
        // 2009.01.06 Add >>>
        public static readonly string COL_DEPOTOTAL = "�����W�v�f�[�^";
        public static readonly string ALL_SECTION = "00";
        // 2009.01.06 Add <<<

        #endregion

        // --------------------------------------------------
		#region Constructor

		/// <summary>���Ӑ攄�|���z�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^</summary>
		/// <remarks>
        /// <br>Note       : ���Ӑ攄�|���z�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        public CustAccRecDmdPrcAcs()
		{
			try {
				// ��ƃR�[�h�擾
				this._enterpriseCode          = LoginInfoAcquisition.EnterpriseCode;

				// �����[�g�I�u�W�F�N�g�擾
                this._iCustRsltUpdDB          = (ICustRsltUpdDB)MediationCustRsltUpdDB.GetCustRsltUpdDB();

                // �}�X�^�N���X�i�[���X�g������
                this._custAccRecDic       = new Dictionary<Guid, CustAccRecWork>();
                this._custDmdPrcDic       = new Dictionary<Guid, CustDmdPrcWork>();

                // �}�X�^�擾�p���X�g������
                // 2009.01.06 >>>
                //this._custAccRecList      = new ArrayList();
                //this._custDmdPrcList      = new ArrayList();
                this._custAccRecList = new CustomSerializeArrayList();
                this._custDmdPrcList = new CustomSerializeArrayList();

                this._moneyKindAcs = new MoneyKindAcs();
                // 2009.01.06 <<<

                // �f�[�^�Z�b�g������
                this._bindDataSet             = new DataSet();
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).BeginInit();
                this._bindDataSet.DataSetName = "NewDataSet";
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).EndInit();

                // �f�[�^�Z�b�g����\�z
                this.DataSetColumnConstruction();
			}
            catch ( Exception )
            {
                // �I�t���C������null���Z�b�g
                this._iCustRsltUpdDB = null;
            }
        }

		/// <summary>�f�[�^�Z�b�g����\�z����</summary>
		/// <remarks>
		/// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B
        ///                  �f�[�^�Z�b�g�̗��񂪃t���[���̃r���[�p�O���b�h�̗�ɂȂ�܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
		private void DataSetColumnConstruction()
		{
			// ���Ӑ攄�|���z�}�X�^�e�[�u��
            this._custAccRecTable = new DataTable(TBL_CUSTACCREC_TITLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custAccRecTable.Columns.Add(COL_CREATEDATETIME,             typeof( DateTime ) );    // �쐬����
            this._custAccRecTable.Columns.Add(COL_UPDATEDATETIME,             typeof( DateTime ) );    // �X�V����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_DELETEDATE_TITLE,           typeof(string));  // �폜��
            this._custAccRecTable.Columns.Add(COL_ADDUPSECCODE_TITLE,         typeof(string));  // �v�㋒�_�R�[�h
            this._custAccRecTable.Columns.Add(COL_CUSTOMERCODE_TITLE,         typeof(Int32));   // ���Ӑ�R�[�h
            this._custAccRecTable.Columns.Add(COL_CUSTOMERNAME_TITLE,         typeof(string));  // ���Ӑ於��
            this._custAccRecTable.Columns.Add(COL_CUSTOMERNAME2_TITLE,        typeof(string));  // ���Ӑ於��2
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custAccRecTable.Columns.Add(COL_CUSTOMERSNM_TITLE,          typeof(string));  // ���Ӑ旪��
            this._custAccRecTable.Columns.Add(COL_CLAIMCODE_TITLE,            typeof(Int32));   // ������R�[�h
            this._custAccRecTable.Columns.Add(COL_CLAIMNAME_TITLE,            typeof(string));  // �����於��
            this._custAccRecTable.Columns.Add(COL_CLAIMNAME2_TITLE,           typeof(string));  // �����於��2
            this._custAccRecTable.Columns.Add(COL_CLAIMSNM_TITLE,             typeof(string));  // �����旪��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_ADDUPDATEJP_TITLE,          typeof(string));  // �v��N����
            // 2009.01.06 Add >>>
            this._custAccRecTable.Columns[COL_ADDUPDATEJP_TITLE].Caption = "�����X�V��";        // �v��N�����̃L���v�V����
            // 2009.01.06 Add <<<
            this._custAccRecTable.Columns.Add(COL_ADDUPYEARMONTHJP_TITLE,     typeof(string));  // �v��N��
            this._custAccRecTable.Columns.Add(COL_ADDUPDATE_TITLE,            typeof(Int32));   // _�v��N��
            this._custAccRecTable.Columns.Add(COL_ADDUPYEARMONTH_TITLE,       typeof(Int32));   // _�v��N����
            this._custAccRecTable.Columns.Add(COL_THISTIMEDMDNRML_TITLE,      typeof(Int64));   // ����������z�i�ʏ�����j
            this._custAccRecTable.Columns.Add(COL_THISTIMEFEEDMDNRML_TITLE,   typeof(Int64));   // ����萔���z�i�ʏ�����j
            this._custAccRecTable.Columns.Add(COL_THISTIMEDISDMDNRML_TITLE,   typeof(Int64));   // ����l���z�i�ʏ�����j
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custAccRecTable.Columns.Add(COL_THISTIMERBTDMDNRML_TITLE,   typeof(Int64));   // ���񃊃x�[�g�z�i�ʏ�����j
            //this._custAccRecTable.Columns.Add(COL_THISTIMEDMDDEPO_TITLE,      typeof(Int64));   // ����������z�i�a����j
            //this._custAccRecTable.Columns.Add(COL_THISTIMEFEEDMDDEPO_TITLE,   typeof(Int64));   // ����萔���z�i�a����j
            //this._custAccRecTable.Columns.Add(COL_THISTIMEDISDMDDEPO_TITLE,   typeof(Int64));   // ����l���z�i�a����j
            //this._custAccRecTable.Columns.Add(COL_THISTIMERBTDMDDEPO_TITLE,   typeof(Int64));   // ���񃊃x�[�g�z�i�a����j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_THISTIMETTLBLCACC_TITLE,    typeof(Int64));   // ����J�z�c���i���|�v�j
            //this._custAccRecTable.Columns.Add(COL_OFSTHISTIMESALES_TITLE,     typeof(Int64));   // ���E�㍡�񔄏���z
            //this._custAccRecTable.Columns.Add(COL_OFSTHISSALESTAX_TITLE,      typeof(Int64));   // ���E�㍡�񔄏�����
            this._custAccRecTable.Columns.Add(COL_ITDEDOFFSETOUTTAX_TITLE,    typeof(Int64));   // ���E��O�őΏۊz
            this._custAccRecTable.Columns.Add(COL_ITDEDOFFSETINTAX_TITLE,     typeof(Int64));   // ���E����őΏۊz
            this._custAccRecTable.Columns.Add(COL_ITDEDOFFSETTAXFREE_TITLE,   typeof(Int64));   // ���E���ېőΏۊz
            this._custAccRecTable.Columns.Add(COL_OFFSETOUTTAX_TITLE,         typeof(Int64));   // ���E��O�ŏ����
            this._custAccRecTable.Columns.Add(COL_OFFSETINTAX_TITLE,          typeof(Int64));   // ���E����ŏ����
            this._custAccRecTable.Columns.Add(COL_ITDEDSALESOUTTAX_TITLE,     typeof(Int64));   // ����O�őΏۊz
            this._custAccRecTable.Columns.Add(COL_ITDEDSALESINTAX_TITLE,      typeof(Int64));   // ������őΏۊz
            this._custAccRecTable.Columns.Add(COL_ITDEDSALESTAXFREE_TITLE,    typeof(Int64));   // �����ېőΏۊz
            this._custAccRecTable.Columns.Add(COL_SALESOUTTAX_TITLE,          typeof(Int64));   // ����O�Ŋz
            this._custAccRecTable.Columns.Add(COL_SALESINTAX_TITLE,           typeof(Int64));   // ������Ŋz
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custAccRecTable.Columns.Add(COL_ITDEDPAYMOUTTAX_TITLE,      typeof(Int64));   // �x���O�őΏۊz
            //this._custAccRecTable.Columns.Add(COL_ITDEDPAYMINTAX_TITLE,       typeof(Int64));   // �x�����őΏۊz
            //this._custAccRecTable.Columns.Add(COL_ITDEDPAYMTAXFREE_TITLE,     typeof(Int64));   // �x����ېőΏۊz
            //this._custAccRecTable.Columns.Add(COL_PAYMENTOUTTAX_TITLE,        typeof(Int64));   // �x���O�ŏ����
            //this._custAccRecTable.Columns.Add(COL_PAYMENTINTAX_TITLE,         typeof(Int64));   // �x�����ŏ����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_CONSTAXLAYMETHOD_TITLE,     typeof(Int32));   // ����œ]�ŕ���
            this._custAccRecTable.Columns.Add(COL_CONSTAXRATE_TITLE,          typeof(Double));  // ����ŗ�
            this._custAccRecTable.Columns.Add(COL_FRACTIONPROCCD_TITLE,       typeof(Int32));   // �[�������敪
            this._custAccRecTable.Columns.Add(COL_MONTHADDUPEXPDATE_TITLE,    typeof(Int32));   // �����X�V���s�N����
            this._custAccRecTable.Columns.Add(COL_GUID_TITLE,                 typeof(Guid));    // GUID
            this._custAccRecTable.Columns.Add(COL_ACPODRTTL3TMBFACCREC_TITLE, typeof(Int64));   // ��3��O�c���i���|�v�j
            this._custAccRecTable.Columns.Add(COL_ACPODRTTL2TMBFACCREC_TITLE, typeof(Int64));   // ��2��O�c���i���|�v�j
            this._custAccRecTable.Columns.Add(COL_LASTTIMEACCREC_TITLE,       typeof(Int64));   // �O�񔄊|���z
            this._custAccRecTable.Columns.Add(COL_THISTIMESALES_TITLE,        typeof(Int64));   // ���񔄏���z
            this._custAccRecTable.Columns.Add(COL_THISSALESTAX_TITLE,         typeof(Int64));   // ���񔄏�����
            this._custAccRecTable.Columns.Add(COL_OFSTHISTIMESALES_TITLE,     typeof(Int64));   // ���E�㍡�񔄏���z
            this._custAccRecTable.Columns.Add(COL_OFSTHISSALESTAX_TITLE,      typeof(Int64));   // ���E�㍡�񔄏�����
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custAccRecTable.Columns.Add(COL_TTLINCDTBTTAXEXC_TITLE,     typeof(Int64));   // �x���C���Z���e�B�u�z���v�i�Ŕ����j
            //this._custAccRecTable.Columns.Add(COL_TTLINCDTBTTAX_TITLE,        typeof(Int64));   // �x���C���Z���e�B�u�z���v�i�Łj
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_THISTIMEDEPODMD_TITLE,      typeof(Int64));   // �������
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custAccRecTable.Columns.Add(COL_TTLITDEDRETOUTTAX_TITLE,    typeof(Int64));   // �ԕi�O�őΏۊz
            this._custAccRecTable.Columns.Add(COL_TTLITDEDRETINTAX_TITLE,     typeof(Int64));   // �ԕi���őΏۊz
            this._custAccRecTable.Columns.Add(COL_TTLITDEDRETTAXFREE_TITLE,   typeof(Int64));   // �ԕi��ېőΏۊz
            this._custAccRecTable.Columns.Add(COL_TTLRETOUTERTAX_TITLE,       typeof(Int64));   // �ԕi�O�Ŋz
            this._custAccRecTable.Columns.Add(COL_TTLRETINNERTAX_TITLE,       typeof(Int64));   // �ԕi���Ŋz
            this._custAccRecTable.Columns.Add(COL_TTLITDEDDISOUTTAX_TITLE,    typeof(Int64));   // �l���O�őΏۊz
            this._custAccRecTable.Columns.Add(COL_TTLITDEDDISINTAX_TITLE,     typeof(Int64));   // �l�����őΏۊz
            this._custAccRecTable.Columns.Add(COL_TTLITDEDDISTAXFREE_TITLE,   typeof(Int64));   // �l����ېőΏۊz
            this._custAccRecTable.Columns.Add(COL_TTLDISOUTERTAX_TITLE,       typeof(Int64));   // �l���O�Ŋz
            this._custAccRecTable.Columns.Add(COL_TTLDISINNERTAX_TITLE,       typeof(Int64));   // �l�����Ŋz
            this._custAccRecTable.Columns.Add(COL_BALANCEADJUST_TITLE,        typeof(Int64));   // �c�������z

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            this._custAccRecTable.Columns.Add(COL_TOTALADJUST_TITLE,          typeof(Int64));   // �c�������z�W���p
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //this._custAccRecTable.Columns.Add(COL_NONSTMNTAPPEARANCE_TITLE,   typeof(Int64));   // �����ϋ��z�i���U�j
            //this._custAccRecTable.Columns.Add(COL_NONSTMNTISDONE_TITLE,       typeof(Int64));   // �����ϋ��z�i�􂵁j
            //this._custAccRecTable.Columns.Add(COL_STMNTAPPEARANCE_TITLE,      typeof(Int64));   // ���ϋ��z�i���U�j
            //this._custAccRecTable.Columns.Add(COL_STMNTISDONE_TITLE,          typeof(Int64));   // ���ϋ��z�i�􂵁j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            //this._custAccRecTable.Columns.Add(COL_THISCASHSALEPRICE,          typeof(Int64));   // ���񔄏���z
            //this._custAccRecTable.Columns.Add(COL_THISCASHSALETAX,            typeof(Int64));   // ���񔄏������Ŋz
            this._custAccRecTable.Columns.Add(COL_SALESSLIPCOUNT_TITLE,             typeof(Int64));   // ����`�[����
            this._custAccRecTable.Columns.Add(COL_BILLPRINTDATE_TITLE,              typeof(Int64));   // ���������s��
            this._custAccRecTable.Columns.Add(COL_EXPECTEDDEPOSITDATE_TITLE,        typeof(Int64));   // �����\���
            this._custAccRecTable.Columns.Add(COL_COLLECTCOND_TITLE,                typeof(Int64));   // �������
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_AFCALTMONTHACCREC_TITLE,    typeof(Int64));   // �v�Z�㓖�����|���z

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custAccRecTable.Columns.Add( COL_THISPAYOFFSET_TITLE, typeof( Int64 ) ); // ����x�����E���z
            //this._custAccRecTable.Columns.Add( COL_THISPAYOFFSETTAX_TITLE, typeof( Int64 ) ); // ����x�����E�����
            //this._custAccRecTable.Columns.Add( COL_ITDEDPAYMOUTTAX_TITLE, typeof( Int64 ) ); // �x���O�őΏۊz
            //this._custAccRecTable.Columns.Add( COL_ITDEDPAYMINTAX_TITLE, typeof( Int64 ) ); // �x�����őΏۊz
            //this._custAccRecTable.Columns.Add( COL_ITDEDPAYMTAXFREE_TITLE, typeof( Int64 ) ); // �x����ېőΏۊz
            //this._custAccRecTable.Columns.Add( COL_PAYMENTOUTTAX_TITLE, typeof( Int64 ) ); // �x���O�ŏ����
            //this._custAccRecTable.Columns.Add( COL_PAYMENTINTAX_TITLE, typeof( Int64 ) ); // �x�����ŏ����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            this._custAccRecTable.Columns.Add( COL_TAXADJUST_TITLE, typeof( Int64 ) ); // ����Œ����z
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009.01.06 Add >>>
            this._custAccRecTable.Columns.Add(COL_STMONCADDUPUPDDATE_TITLE, typeof(Int32));     // �����X�V�J�n�N����
            this._custAccRecTable.Columns.Add(COL_LAMONCADDUPUPDDATE_TITLE, typeof(Int32));     // �O�񌎎��X�V�N����
            this._custAccRecTable.Columns.Add(COL_DEPOTOTAL, typeof(List<AccRecDepoTotal>));    // �����W�v�f�[�^
            // 2009.01.06 Add <<<
            
            // PrimaryKey�ݒ�
            this._custAccRecTable.PrimaryKey = new DataColumn[] { this._custAccRecTable.Columns[COL_ADDUPSECCODE_TITLE],    // �v�㋒�_�R�[�h
                                                                  this._custAccRecTable.Columns[COL_CLAIMCODE_TITLE],       // ������R�[�h
                                                                  this._custAccRecTable.Columns[COL_CUSTOMERCODE_TITLE],    // ���Ӑ�R�[�h
                                                                  this._custAccRecTable.Columns[COL_ADDUPDATE_TITLE]};            // �v��N����

            this._bindDataSet.Tables.Add(this._custAccRecTable);

            // 2009.01.06 Add >>>
            this._custAccRecTotalTable = new DataTable(TBL_CUSTACCRECTOTAL_TITLE);
            this._custAccRecTotalTable = this._custAccRecTable.Clone();
            this._custAccRecTotalTable.TableName = TBL_CUSTACCRECTOTAL_TITLE;
            this._bindDataSet.Tables.Add(this._custAccRecTotalTable);
            // 2009.01.06 Add <<<

        			// ���Ӑ攄�|���z�}�X�^�e�[�u��
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
            // ���Ӑ搿�����z�}�X�^�e�[�u��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END
            this._custDmdPrcTable = new DataTable(TBL_CUSTDMDPRC_TITLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_CREATEDATETIME,             typeof( DateTime ) );    // �쐬����
            this._custDmdPrcTable.Columns.Add(COL_UPDATEDATETIME,             typeof( DateTime ) );    // �X�V����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add( COL_DELETEDATE_TITLE,          typeof( string ) );  // �폜��
            this._custDmdPrcTable.Columns.Add(COL_ADDUPSECCODE_TITLE,         typeof(string));  // �v�㋒�_�R�[�h

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
            this._custDmdPrcTable.Columns.Add(COL_RESULTSECCODE_TITLE,        typeof(string));  // ���ы��_�R�[�h
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END

            this._custDmdPrcTable.Columns.Add(COL_CUSTOMERCODE_TITLE,         typeof(Int32));   // ���Ӑ�R�[�h
            this._custDmdPrcTable.Columns.Add(COL_CUSTOMERNAME_TITLE,         typeof(string));  // ���Ӑ於��
            this._custDmdPrcTable.Columns.Add(COL_CUSTOMERNAME2_TITLE,        typeof(string));  // ���Ӑ於��2
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_CUSTOMERSNM_TITLE,          typeof(string));  // ���Ӑ旪��
            this._custDmdPrcTable.Columns.Add(COL_CLAIMCODE_TITLE,            typeof(Int32));   // ������R�[�h
            this._custDmdPrcTable.Columns.Add(COL_CLAIMNAME_TITLE,            typeof(string));  // �����於��
            this._custDmdPrcTable.Columns.Add(COL_CLAIMNAME2_TITLE,           typeof(string));  // �����於��2
            this._custDmdPrcTable.Columns.Add(COL_CLAIMSNM_TITLE,             typeof(string));  // �����旪��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_ADDUPDATEJP_TITLE,          typeof(string));  // �v��N����
            // 2009.01.06 Add >>>
            this._custDmdPrcTable.Columns[COL_ADDUPDATEJP_TITLE].Caption = "��������";          // �v��N�����̃L���v�V����
            // 2009.01.06 Add <<<
            this._custDmdPrcTable.Columns.Add(COL_ADDUPYEARMONTHJP_TITLE,     typeof(string));  // �v��N��
            this._custDmdPrcTable.Columns.Add(COL_ADDUPDATE_TITLE,            typeof(Int32));   // _�v��N��
            this._custDmdPrcTable.Columns.Add(COL_ADDUPYEARMONTH_TITLE,       typeof(Int32));   // _�v��N����
            this._custDmdPrcTable.Columns.Add(COL_THISTIMEDMDNRML_TITLE,      typeof(Int64));   // ����������z�i�ʏ�����j
            this._custDmdPrcTable.Columns.Add(COL_THISTIMEFEEDMDNRML_TITLE,   typeof(Int64));   // ����萔���z�i�ʏ�����j
            this._custDmdPrcTable.Columns.Add(COL_THISTIMEDISDMDNRML_TITLE,   typeof(Int64));   // ����l���z�i�ʏ�����j
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMERBTDMDNRML_TITLE,   typeof(Int64));   // ���񃊃x�[�g�z�i�ʏ�����j
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMEDMDDEPO_TITLE,      typeof(Int64));   // ����������z�i�a����j
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMEFEEDMDDEPO_TITLE,   typeof(Int64));   // ����萔���z�i�a����j
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMEDISDMDDEPO_TITLE,   typeof(Int64));   // ����l���z�i�a����j
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMERBTDMDDEPO_TITLE,   typeof(Int64));   // ���񃊃x�[�g�z�i�a����j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_THISTIMETTLBLCDMD_TITLE,    typeof(Int64));   // ����J�z�c���i�����v�j
            //this._custDmdPrcTable.Columns.Add(COL_OFSTHISTIMESALES_TITLE,     typeof(Int64));   // ���E�㍡�񔄏���z
            //this._custDmdPrcTable.Columns.Add(COL_OFSTHISSALESTAX_TITLE,      typeof(Int64));   // ���E�㍡�񔄏�����
            this._custDmdPrcTable.Columns.Add(COL_ITDEDOFFSETOUTTAX_TITLE,    typeof(Int64));   // ���E��O�őΏۊz
            this._custDmdPrcTable.Columns.Add(COL_ITDEDOFFSETINTAX_TITLE,     typeof(Int64));   // ���E����őΏۊz
            this._custDmdPrcTable.Columns.Add(COL_ITDEDOFFSETTAXFREE_TITLE,   typeof(Int64));   // ���E���ېőΏۊz
            this._custDmdPrcTable.Columns.Add(COL_OFFSETOUTTAX_TITLE,         typeof(Int64));   // ���E��O�ŏ����
            this._custDmdPrcTable.Columns.Add(COL_OFFSETINTAX_TITLE,          typeof(Int64));   // ���E����ŏ����
            this._custDmdPrcTable.Columns.Add(COL_ITDEDSALESOUTTAX_TITLE,     typeof(Int64));   // ����O�őΏۊz
            this._custDmdPrcTable.Columns.Add(COL_ITDEDSALESINTAX_TITLE,      typeof(Int64));   // ������őΏۊz
            this._custDmdPrcTable.Columns.Add(COL_ITDEDSALESTAXFREE_TITLE,    typeof(Int64));   // �����ېőΏۊz
            this._custDmdPrcTable.Columns.Add(COL_SALESOUTTAX_TITLE,          typeof(Int64));   // ����O�Ŋz
            this._custDmdPrcTable.Columns.Add(COL_SALESINTAX_TITLE,           typeof(Int64));   // ������Ŋz
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custDmdPrcTable.Columns.Add(COL_ITDEDPAYMOUTTAX_TITLE,      typeof(Int64));   // �x���O�őΏۊz
            //this._custDmdPrcTable.Columns.Add(COL_ITDEDPAYMINTAX_TITLE,       typeof(Int64));   // �x�����őΏۊz
            //this._custDmdPrcTable.Columns.Add(COL_ITDEDPAYMTAXFREE_TITLE,     typeof(Int64));   // �x����ېőΏۊz
            //this._custDmdPrcTable.Columns.Add(COL_PAYMENTOUTTAX_TITLE,        typeof(Int64));   // �x���O�ŏ����
            //this._custDmdPrcTable.Columns.Add(COL_PAYMENTINTAX_TITLE,         typeof(Int64));   // �x�����ŏ����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_CONSTAXLAYMETHOD_TITLE,     typeof(Int32));   // ����œ]�ŕ���
            this._custDmdPrcTable.Columns.Add(COL_CONSTAXRATE_TITLE,          typeof(Double));  // ����ŗ�
            this._custDmdPrcTable.Columns.Add(COL_FRACTIONPROCCD_TITLE,       typeof(Int32));   // �[�������敪
            this._custDmdPrcTable.Columns.Add(COL_CADDUPUPDEXECDATE_TITLE,    typeof(Int32));   // �����X�V���s�N����
            this._custDmdPrcTable.Columns.Add(COL_DMDPROCNUM_TITLE,           typeof(Int32));   // ���������ʔ�
            this._custDmdPrcTable.Columns.Add(COL_GUID_TITLE,                 typeof(Guid));    // GUID
            this._custDmdPrcTable.Columns.Add(COL_ACPODRTTL3TMBFBLDMD_TITLE,  typeof(Int64));   // ��3��O�c���i�����v�j
            this._custDmdPrcTable.Columns.Add(COL_ACPODRTTL2TMBFBLDMD_TITLE,  typeof(Int64));   // ��2��O�c���i�����v�j
            this._custDmdPrcTable.Columns.Add(COL_LASTTIMEDEMAND_TITLE,       typeof(Int64));   // �O�񐿋����z
            this._custDmdPrcTable.Columns.Add(COL_THISTIMESALES_TITLE,        typeof(Int64));   // ���񔄏���z
            this._custDmdPrcTable.Columns.Add(COL_THISSALESTAX_TITLE,         typeof(Int64));   // ���񔄏�����
            this._custDmdPrcTable.Columns.Add(COL_OFSTHISTIMESALES_TITLE,     typeof(Int64));   // ���E�㍡�񔄏���z
            this._custDmdPrcTable.Columns.Add(COL_OFSTHISSALESTAX_TITLE,      typeof(Int64));   // ���E�㍡�񔄏�����
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custDmdPrcTable.Columns.Add(COL_TTLINCDTBTTAXEXC_TITLE,     typeof(Int64));   // �x���C���Z���e�B�u�z���v�i�Ŕ����j
            //this._custDmdPrcTable.Columns.Add(COL_TTLINCDTBTTAX_TITLE,        typeof(Int64));   // �x���C���Z���e�B�u�z���v�i�Łj
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_THISTIMEDEPODMD_TITLE,      typeof(Int64));   // �������
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_TTLITDEDRETOUTTAX_TITLE,    typeof(Int64));   // �ԕi�O�őΏۊz
            this._custDmdPrcTable.Columns.Add(COL_TTLITDEDRETINTAX_TITLE,     typeof(Int64));   // �ԕi���őΏۊz
            this._custDmdPrcTable.Columns.Add(COL_TTLITDEDRETTAXFREE_TITLE,   typeof(Int64));   // �ԕi��ېőΏۊz
            this._custDmdPrcTable.Columns.Add(COL_TTLRETOUTERTAX_TITLE,       typeof(Int64));   // �ԕi�O�Ŋz
            this._custDmdPrcTable.Columns.Add(COL_TTLRETINNERTAX_TITLE,       typeof(Int64));   // �ԕi���Ŋz
            this._custDmdPrcTable.Columns.Add(COL_TTLITDEDDISOUTTAX_TITLE,    typeof(Int64));   // �l���O�őΏۊz
            this._custDmdPrcTable.Columns.Add(COL_TTLITDEDDISINTAX_TITLE,     typeof(Int64));   // �l�����őΏۊz
            this._custDmdPrcTable.Columns.Add(COL_TTLITDEDDISTAXFREE_TITLE,   typeof(Int64));   // �l����ېőΏۊz
            this._custDmdPrcTable.Columns.Add(COL_TTLDISOUTERTAX_TITLE,       typeof(Int64));   // �l���O�Ŋz
            this._custDmdPrcTable.Columns.Add(COL_TTLDISINNERTAX_TITLE,       typeof(Int64));   // �l�����Ŋz
            this._custDmdPrcTable.Columns.Add(COL_BALANCEADJUST_TITLE,        typeof(Int64));   // �c�������z

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            this._custDmdPrcTable.Columns.Add(COL_TOTALADJUST_TITLE, typeof(Int64));   // �c�������z�W���p
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            this._custDmdPrcTable.Columns.Add(COL_NONSTMNTAPPEARANCE_TITLE,   typeof(Int64));   // �����ϋ��z�i���U�j
            this._custDmdPrcTable.Columns.Add(COL_NONSTMNTISDONE_TITLE,       typeof(Int64));   // �����ϋ��z�i�􂵁j
            this._custDmdPrcTable.Columns.Add(COL_STMNTAPPEARANCE_TITLE,      typeof(Int64));   // ���ϋ��z�i���U�j
            this._custDmdPrcTable.Columns.Add(COL_STMNTISDONE_TITLE,          typeof(Int64));   // ���ϋ��z�i�􂵁j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            //this._custDmdPrcTable.Columns.Add(COL_THISCASHSALEPRICE,          typeof(Int64));   // ���񌻋�������z
            //this._custDmdPrcTable.Columns.Add(COL_THISCASHSALETAX,            typeof(Int64));   // ���񌻋����������Ŋz
            this._custDmdPrcTable.Columns.Add(COL_SALESSLIPCOUNT_TITLE,             typeof(Int64));   // ����`�[����
            this._custDmdPrcTable.Columns.Add(COL_BILLPRINTDATE_TITLE,              typeof(Int64));   // ���������s��
            this._custDmdPrcTable.Columns.Add(COL_EXPECTEDDEPOSITDATE_TITLE,        typeof(Int64));   // �����\���
            this._custDmdPrcTable.Columns.Add(COL_COLLECTCOND_TITLE,                typeof(Int64));   // �������
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_AFCALDEMANDPRICE_TITLE,     typeof(Int64));   // �v�Z�㐿�����z

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custDmdPrcTable.Columns.Add( COL_THISPAYOFFSET_TITLE, typeof( Int64 ) ); // ����x�����E���z
            //this._custDmdPrcTable.Columns.Add( COL_THISPAYOFFSETTAX_TITLE, typeof( Int64 ) ); // ����x�����E�����
            //this._custDmdPrcTable.Columns.Add( COL_ITDEDPAYMOUTTAX_TITLE, typeof( Int64 ) ); // �x���O�őΏۊz
            //this._custDmdPrcTable.Columns.Add( COL_ITDEDPAYMINTAX_TITLE, typeof( Int64 ) ); // �x�����őΏۊz
            //this._custDmdPrcTable.Columns.Add( COL_ITDEDPAYMTAXFREE_TITLE, typeof( Int64 ) ); // �x����ېőΏۊz
            //this._custDmdPrcTable.Columns.Add( COL_PAYMENTOUTTAX_TITLE, typeof( Int64 ) ); // �x���O�ŏ����
            //this._custDmdPrcTable.Columns.Add( COL_PAYMENTINTAX_TITLE, typeof( Int64 ) ); // �x�����ŏ����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            this._custDmdPrcTable.Columns.Add( COL_TAXADJUST_TITLE, typeof( Int64 ) ); // ����Œ����z
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009.01.06 Add >>>
            this._custDmdPrcTable.Columns.Add(COL_STARTCADDUPUPDDATE_TITLE, typeof(Int32));     // �����X�V�J�n�N����
            this._custDmdPrcTable.Columns.Add(COL_LASTCADDUPUPDDATE_TITLE, typeof(Int32));      // �O������X�V�N����
            this._custDmdPrcTable.Columns.Add(COL_DEPOTOTAL, typeof(List<DmdDepoTotal>));       // �����W�v�f�[�^
            // 2009.01.06 Add <<<

            // ADD 2009/06/23 ------>>>
            this._custDmdPrcTable.Columns.Add(COL_BILLNO_TITLE, typeof(Int32));                 // ������No
            // ADD 2009/06/23 ------<<<
            
            // PrimaryKey�ݒ�
            this._custDmdPrcTable.PrimaryKey = new DataColumn[] { this._custDmdPrcTable.Columns[COL_ADDUPSECCODE_TITLE],    // �v�㋒�_�R�[�h
                                                                  this._custDmdPrcTable.Columns[COL_CLAIMCODE_TITLE],       // ������R�[�h
                                                                  this._custDmdPrcTable.Columns[COL_CUSTOMERCODE_TITLE],    // ���Ӑ�R�[�h
                                                                  // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
                                                                  this._custDmdPrcTable.Columns[COL_RESULTSECCODE_TITLE],  // ���ы��_�R�[�h
                                                                  // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END
                                                                  this._custDmdPrcTable.Columns[COL_ADDUPDATE_TITLE]};            // �v��N����
            this._bindDataSet.Tables.Add(this._custDmdPrcTable);

            // 2009.01.06 Add >>>
            this._custDmdPrcTotalTable = new DataTable(TBL_CUSTDMDPRCTOTAL_TITLE);
            this._custDmdPrcTotalTable = this._custDmdPrcTable.Clone();
            this._custDmdPrcTotalTable.TableName = TBL_CUSTDMDPRCTOTAL_TITLE;
            this._bindDataSet.Tables.Add(this._custDmdPrcTotalTable);
            // 2009.01.06 Add <<<
        }

		#endregion

        // --------------------------------------------------
        #region Properties

        /// <summary>�f�[�^�Z�b�g�v���p�e�B</summary>
        /// <value>�f�[�^�Z�b�g���擾���܂��B</value>
        public DataSet BindDataSet
        {
            get { return this._bindDataSet; }
        }

        #endregion

		// --------------------------------------------------
		#region GetOnlineMode

		/// <summary>�I�����C�����[�h�擾����</summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : �I�����C�����[�h�̎擾���s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			// �I�����C�����[�h���擾
            if (this._iCustRsltUpdDB == null)
            {
				// �I�t���C��
				return ( int )ConstantManagement.OnlineMode.Offline;
			}
			else {
				// �I�����C��
				return ( int )ConstantManagement.OnlineMode.Online;
			}
		}

		#endregion

        // --------------------------------------------------
		#region Write Methods

		/// <summary>�������ݏ���(���|)</summary>
        /// <param name="custAccRec">���Ӑ攄�|���z�}�X�^�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^�̏������ݏ������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        // 2009.01.06 >>>
        //public int WriteCustAccRec(CustAccRec custAccRec, out string errMsg)
        public int WriteCustAccRec(CustAccRec custAccRec, List<AccRecDepoTotal> accRecDepoTotalList, out string errMsg)
        // 2009.01.06 <<<
        {
            // ���Ӑ攄�|���z�}�X�^�X�V
            // 2009.01.06 >>>
            //return this.WriteCustAccRecProc(custAccRec, out errMsg);
            return this.WriteCustAccRecProc(custAccRec, accRecDepoTotalList, out errMsg);
            // 2009.01.06 <<<
        }

		/// <summary>���Ӑ攄�|���z�}�X�^�������ݏ���(���|)</summary>
        /// <param name="custAccRec">���Ӑ攄�|���z�}�X�^�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ӑ攄�|���z�}�X�^�̏������ݏ������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        // 2009.01.06 >>>
        //private int WriteCustAccRecProc(CustAccRec custAccRec, out string errMsg)
        private int WriteCustAccRecProc(CustAccRec custAccRec, List<AccRecDepoTotal> accRecDepoTotalList, out string errMsg)
        // 2009.01.06 <<<
        {
			int status = 0;
            errMsg     = "";

			try {
                CustAccRecWork custAccRecWork = new CustAccRecWork();

                // �ҏW�O���擾
                if (this._custAccRecDic.ContainsKey(custAccRec.FileHeaderGuid) == true)
                {
                    custAccRecWork = (this._custAccRecDic[custAccRec.FileHeaderGuid] as CustAccRecWork);
                }

                // �ҏW���擾
                CopyToCustAccRecWorkFromCustAccRec(ref custAccRecWork, custAccRec);

                // 2009.01.06 >>>
                //object retObj = (object)custAccRecWork;

                // �����W�v�f�[�^�̎擾
                ArrayList accRecDepoTotalWorkArrayList = new ArrayList();

                foreach (AccRecDepoTotal dmdDepoTotal in accRecDepoTotalList)
                {
                    AccRecDepoTotalWork accRecDepoTotalWork = ParamDataFromUIData(dmdDepoTotal);
                    accRecDepoTotalWork.EnterpriseCode = custAccRecWork.EnterpriseCode;     // ��ƃR�[�h
                    accRecDepoTotalWork.AddUpSecCode = custAccRecWork.AddUpSecCode;         // �v�㋒�_�R�[�h
                    accRecDepoTotalWork.ClaimCode = custAccRecWork.ClaimCode;               // ������R�[�h
                    accRecDepoTotalWork.CustomerCode = custAccRecWork.ClaimCode;            // ���Ӑ�R�[�h�i��������Z�b�g�j
                    accRecDepoTotalWork.AddUpDate = custAccRecWork.AddUpDate;               // �v��N����
                    accRecDepoTotalWorkArrayList.Add(accRecDepoTotalWork);
                }
                CustomSerializeArrayList dataList = new CustomSerializeArrayList();
                dataList.Add(custAccRecWork);

                // --- CHG 2009/01/30 ��QID:10603�Ή�------------------------------------------------------>>>>>
                //if (accRecDepoTotalWorkArrayList.Count > 0)
                //{
                //    dataList.Add(accRecDepoTotalWorkArrayList);
                //}
                dataList.Add(accRecDepoTotalWorkArrayList);
                // --- CHG 2009/01/30 ��QID:10603�Ή�------------------------------------------------------<<<<<

                object retObj = (object)dataList;
                // 2009.01.06 <<<

                //���Ӑ攄�|���z�}�X�^��������
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
                //status = this._iCustRsltUpdDB.WriteAccRec(ref retObj, out errMsg);
                status = this._iCustRsltUpdDB.WriteTotalAccRec(ref retObj, out errMsg);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) {

                    // �f�[�^�Z�b�g�ɒǉ�
                    // 2009.01.06 >>>
                    //custAccRecWork = (CustAccRecWork)retObj;
                    //this.CustAccRecWorkToDataSet(custAccRecWork);
                    accRecDepoTotalWorkArrayList = null;

                    if (retObj is CustomSerializeArrayList)
                    {
                        CustomSerializeArrayList retDataList = (CustomSerializeArrayList)retObj;

                        for (int i = 0; i < retDataList.Count; i++)
                        {
                            if (retDataList[i] is CustAccRecWork)
                            {
                                custAccRecWork = (CustAccRecWork)retDataList[i];
                            }
                            if (retDataList[i] is ArrayList)
                            {
                                accRecDepoTotalWorkArrayList = (ArrayList)retDataList[i];
                            }
                        }
                    }

                    this.CustAccRecWorkToDataSet(custAccRecWork, accRecDepoTotalWorkArrayList);

                    // ������w��̏ꍇ�͏W�v���R�[�h�֔��f
                    if (custAccRecWork.CustomerCode == 0)
                    {
                        this.CustAccRecWorkTotalToDataSet(custAccRecWork, accRecDepoTotalWorkArrayList);
                    }
                    // 2009.01.06 <<<
                }
			}
			catch(Exception) {
				// �I�t���C������null���Z�b�g
                this._iCustRsltUpdDB = null;

				// �ʐM�G���[��-1��Ԃ�
				status = -1;
			}

			return status;
		}

        /// <summary>�������ݏ���(����)</summary>
        /// <param name="custDmdPrc">���Ӑ搿�����z�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�̏������ݏ������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.06 >>>
        //public int WriteCustDmdPrc(CustDmdPrc custDmdPrc, out string errMsg)
        public int WriteCustDmdPrc(CustDmdPrc custDmdPrc, List<DmdDepoTotal> dmdDepoTotalList, out string errMsg)
        // 2009.01.06 <<<
        {
            // ���Ӑ搿�����z�}�X�^�X�V
            // 2009.01.06 >>>
            //return this.WriteCustDmdPrcProc(custDmdPrc, out errMsg);
            return this.WriteCustDmdPrcProc(custDmdPrc, dmdDepoTotalList, out errMsg);
            // 2009.01.06 <<<
        }

        /// <summary>���Ӑ搿�����z�}�X�^�������ݏ���(���|)</summary>
        /// <param name="custDmdPrc">���Ӑ搿�����z�}�X�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ搿�����z�}�X�^�̏������ݏ������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.06 >>>
        //private int WriteCustDmdPrcProc(CustDmdPrc custDmdPrc, out string errMsg)
        private int WriteCustDmdPrcProc(CustDmdPrc custDmdPrc, List<DmdDepoTotal> dmdDepoTotalList, out string errMsg)
        // 2009.01.06 <<<
        {
			int status = 0;
            errMsg     = "";

            try
            {
                CustDmdPrcWork custDmdPrcWork = new CustDmdPrcWork();

                // �ҏW�O���擾
                if (this._custDmdPrcDic.ContainsKey(custDmdPrc.FileHeaderGuid) == true)
                {
                    custDmdPrcWork = (this._custDmdPrcDic[custDmdPrc.FileHeaderGuid] as CustDmdPrcWork);
                }

                // �ҏW���擾
                CopyToCustDmdPrcWorkFromCustDmdPrc(ref custDmdPrcWork, custDmdPrc);

                // 2009.01.06 >>>
                //object retObj = (object)custDmdPrcWork;

                // �����W�v�f�[�^�̎擾
                ArrayList dmdDepoTotalWorkArrayList = new ArrayList();

                foreach (DmdDepoTotal dmdDepoTotal in dmdDepoTotalList)
                {
                    DmdDepoTotalWork dmdDepoTotalWork = ParamDataFromUIData(dmdDepoTotal);
                    dmdDepoTotalWork.EnterpriseCode = custDmdPrcWork.EnterpriseCode;    // ��ƃR�[�h
                    dmdDepoTotalWork.AddUpSecCode = custDmdPrcWork.AddUpSecCode;        // �v�㋒�_�R�[�h
                    dmdDepoTotalWork.ClaimCode = custDmdPrcWork.ClaimCode;              // ������R�[�h
                    dmdDepoTotalWork.CustomerCode = custDmdPrcWork.ClaimCode;           // ���Ӑ�R�[�h�i��������Z�b�g�j
                    dmdDepoTotalWork.AddUpDate = custDmdPrcWork.AddUpDate;              // �v��N����
                    dmdDepoTotalWorkArrayList.Add(dmdDepoTotalWork);
                }
                CustomSerializeArrayList dataList = new CustomSerializeArrayList();
                dataList.Add(custDmdPrcWork);

                // --- CHG 2009/01/30 ��QID:10603�Ή�------------------------------------------------------>>>>>
                //if (dmdDepoTotalWorkArrayList.Count > 0)
                //{
                //    dataList.Add(dmdDepoTotalWorkArrayList);
                //}
                dataList.Add(dmdDepoTotalWorkArrayList);
                // --- CHG 2009/01/30 ��QID:10603�Ή�------------------------------------------------------<<<<<

                object retObj = (object)dataList;
                // 2009.01.06 <<<

                //���Ӑ攄�|���z�}�X�^��������
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
                //status = this._iCustRsltUpdDB.WriteDmdPrc(ref retObj, out errMsg);
                status = this._iCustRsltUpdDB.WriteTotalDmdPrc(ref retObj, out errMsg);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 2009.01.06 >>>
                    //// �f�[�^�Z�b�g�ɒǉ�
                    //custDmdPrcWork = (CustDmdPrcWork)retObj;
                    //this.CustDmdPrcWorkToDataSet(custDmdPrcWork);

                    dmdDepoTotalWorkArrayList = null;

                    if (retObj is CustomSerializeArrayList)
                    {
                        CustomSerializeArrayList retDataList = (CustomSerializeArrayList)retObj;

                        for (int i = 0;i < retDataList.Count;i++)
                        {
                            if (retDataList[i] is CustAccRecWork)
                            {
                                custDmdPrcWork = (CustDmdPrcWork)retDataList[i];
                            }
                            if (retDataList[i] is ArrayList)
                            {
                                dmdDepoTotalWorkArrayList = (ArrayList)retDataList[i];
                            }
                        }
                    }

                    this.CustDmdPrcWorkToDataSet(custDmdPrcWork, dmdDepoTotalWorkArrayList);

                    // ������w��̏ꍇ�͏W�v���R�[�h�֔��f
                    if (custDmdPrcWork.CustomerCode == 0)
                    {
                        this.CustDmdPrcWorkTotalToDataSet(custDmdPrcWork, dmdDepoTotalWorkArrayList);
                    }
                    // 2009.01.06 <<<
                }
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show( ex.Message );

                // �I�t���C������null���Z�b�g
                this._iCustRsltUpdDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
		#region Delete Methods

		/// <summary>�����폜����</summary>
        /// <param name="custAccRec">���Ӑ攄�|���z�}�X�^�N���X</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^���̕����폜�������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        public int DeleteCustAccRec(CustAccRec custAccRec)
        {
            // ���Ӑ攄�|���z�}�X�^�����폜
            return this.DeleteCustAccRecProc(custAccRec);
        }

		/// <summary>���Ӑ攄�|���z�}�X�^�����폜����</summary>
        /// <param name="custAccRec">���Ӑ攄�|���z�}�X�^�N���X</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : ���Ӑ攄�|���z�}�X�^�̕����폜�������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        private int DeleteCustAccRecProc(CustAccRec custAccRec)
        {
            int status = 0;

            try
            {
                // �ҏW�O���擾
                CustAccRecWork custAccRecWork = new CustAccRecWork();

                // �ҏW�O���擾
                if (this._custAccRecDic.ContainsKey(custAccRec.FileHeaderGuid) == true)
                {
                    custAccRecWork = (this._custAccRecDic[custAccRec.FileHeaderGuid] as CustAccRecWork);
                }

                CopyToCustAccRecWorkFromCustAccRec(ref custAccRecWork, custAccRec);

                // 2009.01.06 Add >>>
                //object paraObj = (object)custAccRecWork;
                CustomSerializeArrayList dataList = new CustomSerializeArrayList();
                dataList.Add(custAccRecWork);
                object paraObj = (object)dataList;
                // 2009.01.06 Add <<<

                // ���Ӑ攄�|���z�}�X�^�����폜
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
                //status = this._iCustRsltUpdDB.DeleteAccRec(paraObj);
                status = this._iCustRsltUpdDB.DeleteTotalAccRec(paraObj);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �ڍ׃O���b�h�p�L���b�V���e�[�u������폜
                    this._custAccRecDic.Remove(custAccRec.FileHeaderGuid);
                    // �f�[�^�e�[�u������폜
                    object[] key = { custAccRec.AddUpSecCode, custAccRec.ClaimCode, custAccRec.CustomerCode, TDateTime.DateTimeToLongDate(custAccRec.AddUpDate) };
                    DataRow dr = this._custAccRecTable.Rows.Find(key);
                    dr.Delete();
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iCustRsltUpdDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }

        /// <summary>�����폜����</summary>
        /// <param name="custDmdPrc">���Ӑ搿�����z</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̕����폜�������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public int DeleteCustDmdPrc(CustDmdPrc custDmdPrc)
        {
            // ���Ӑ搿�����z�}�X�^�����폜
            return this.DeleteCustDmdPrcProc(custDmdPrc);
        }

        /// <summary>���Ӑ搿�����z�}�X�^�����폜����</summary>
        /// <param name="custDmdPrc">���Ӑ搿�����z�}�X�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ搿�����z�}�X�^�̕����폜�������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int DeleteCustDmdPrcProc(CustDmdPrc custDmdPrc)
        {
            int status = 0;

            try
            {
                // �ҏW�O���擾
                CustDmdPrcWork custDmdPrcWork = new CustDmdPrcWork();

                // �ҏW�O���擾
                if (this._custDmdPrcDic.ContainsKey(custDmdPrc.FileHeaderGuid) == true)
                {
                    custDmdPrcWork = (this._custDmdPrcDic[custDmdPrc.FileHeaderGuid] as CustDmdPrcWork);
                }

                CopyToCustDmdPrcWorkFromCustDmdPrc(ref custDmdPrcWork, custDmdPrc);

                // ���Ӑ搿�����z�}�X�^�����폜
                // 2009.01.06 >>>
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
                ////status = this._iCustRsltUpdDB.DeleteDmdPrc(custDmdPrcWork);
                //status = this._iCustRsltUpdDB.DeleteTotalDmdPrc(custDmdPrcWork);
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END

                CustomSerializeArrayList dataList = new CustomSerializeArrayList();
                dataList.Add(custDmdPrcWork);
                object paraObj = (object)dataList;
                status = this._iCustRsltUpdDB.DeleteTotalDmdPrc(paraObj);
                // 2009.01.06 <<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �ڍ׃O���b�h�p�L���b�V���e�[�u������폜
                    this._custDmdPrcDic.Remove(custDmdPrc.FileHeaderGuid);
                    // �f�[�^�e�[�u������폜
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
                    //object[] key = { custDmdPrc.AddUpSecCode, custDmdPrc.ClaimCode, custDmdPrc.CustomerCode, custDmdPrc. TDateTime.DateTimeToLongDate(custDmdPrc.AddUpDate) };
                    object[] key = { custDmdPrc.AddUpSecCode, custDmdPrc.ClaimCode, custDmdPrc.CustomerCode, custDmdPrc.ResultsSectCd, TDateTime.DateTimeToLongDate(custDmdPrc.AddUpDate) };
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END
                    DataRow dr = this._custDmdPrcTable.Rows.Find(key);
                    dr.Delete();
                }
            }
            catch (Exception ex)
            {
                
                // �I�t���C������null���Z�b�g
                this._iCustRsltUpdDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
		#region Search Methods

		/// <summary>��������(�_���폜����)(���|)</summary>
        /// <param name="totalCount">�擾����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�͌����ΏۊO�ł��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        public int SearchCustAccRec(out int totalCount, string enterpriseCode, string sectionCode, Int32 claimCode, Int32 customerCode)
        {
            // ���Ӑ攄�|���z�}�X�^����
            return this.SearchCustAccRecProc(out totalCount, enterpriseCode, sectionCode, claimCode, customerCode, ConstantManagement.LogicalMode.GetData0);
        }

        /// <summary>��������(�_���폜�܂�)(���|)</summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�������ΏۂɊ܂݂܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public int SearchCustAccRecAll(out int totalCount, string enterpriseCode, string sectionCode, Int32 claimCode, Int32 customerCode)
        {
            // ���Ӑ攄�|���z�}�X�^����
            return this.SearchCustAccRecProc(out totalCount, enterpriseCode, sectionCode, claimCode, customerCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>��������(���|)</summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int SearchCustAccRecProc(out int totalCount, string enterpriseCode, string sectionCode, Int32 claimCode, Int32 customerCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status1 = 0;
            int status2 = 0;

            // ���Ӑ攄�|���z�}�X�^����
            status1 = this.SearchCustAccRecProc2(out totalCount, enterpriseCode, sectionCode, claimCode, customerCode, logicalMode);
            if (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status1;
            }

            // �L���b�V������
            // 2009.01.06 >>>
            //status2 = this.CacheCustAccRec(this._custAccRecList);
            status2 = this.CacheCustAccRec(this._custAccRecList, sectionCode, claimCode, customerCode);
            // 2009.01.06 <<<
            
            if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status2;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>���Ӑ攄�|���z�}�X�^��������(���|)</summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ攄�|���z�}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.03.08</br>
        /// </remarks>
        private int SearchCustAccRecProc2(out int totalCount, string enterpriseCode, string sectionCode, Int32 claimCode, Int32 customerCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;
            totalCount = 0;

            try
            {
                // �擾���X�g������
                this._custAccRecList.Clear();

                // �L���b�V���p�e�[�u�����N���A
                this._custAccRecDic.Clear();

                object retobj = null;

                // ���Ӑ攄�|���z�}�X�^����
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA DEL START
                //if (customerCode == claimCode) {
                //    customerCode = 0;   // �e���R�[�h�̏ꍇ�͓��Ӑ�R�[�h���O�ɂ��ēǂݍ���
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA DEL END
                status = this._iCustRsltUpdDB.SearchAccRec(enterpriseCode,sectionCode,claimCode,customerCode,0,out retobj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 2009.01.06 >>>
                    //this._custAccRecList = retobj as ArrayList;
                    this._custAccRecList = retobj as CustomSerializeArrayList;
                    // 2009.01.06 <<<

                    // �Y�������i�[
                    totalCount = this._custAccRecList.Count;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iCustRsltUpdDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }

        /// <summary>��������(�_���폜����)(����)</summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�͌����ΏۊO�ł��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public int SearchCustDmdPrc(out int totalCount, string enterpriseCode, string sectionCode, string resultSecCode, Int32 claimCode, Int32 customerCode)
        {
            // ���Ӑ搿�����z�}�X�^����
            return this.SearchCustDmdPrcProc(out totalCount, enterpriseCode, sectionCode, resultSecCode, claimCode, customerCode, ConstantManagement.LogicalMode.GetData0);
        }

        /// <summary>��������(�_���폜�܂�)(����)</summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <param name="resultSecCode">���ы��_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�������ΏۂɊ܂݂܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// <br>-------------------------</br>
        /// <br>Note       : �����Ɏ��ы��_�R�[�h��ǉ�</br>
        /// <br>Modifier   : ���i �r��</br>
        /// <br>Date       : 2008.06.24</br>
        /// </remarks>
        public int SearchCustDmdPrcAll(out int totalCount, string enterpriseCode, string sectionCode, string resultSecCode, Int32 claimCode, Int32 customerCode)
        {
            // ���Ӑ搿�����z�}�X�^����
            return this.SearchCustDmdPrcProc(out totalCount, enterpriseCode, sectionCode, resultSecCode, claimCode, customerCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>��������(����)</summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <param name="resultSecCode">���ы��_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// <br>-------------------------</br>
        /// <br>Note       : �����Ɏ��ы��_�R�[�h��ǉ�</br>
        /// <br>Modifier   : ���i �r��</br>
        /// <br>Date       : 2008.06.24</br>
        /// </remarks>
        private int SearchCustDmdPrcProc(out int totalCount, string enterpriseCode, string sectionCode, string resultSecCode, Int32 claimCode, Int32 customerCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status1 = 0;
            int status2 = 0;

            // ���Ӑ搿�����z�}�X�^����
            status1 = this.SearchCustDmdPrcProc2(out totalCount, enterpriseCode, sectionCode, resultSecCode, claimCode, customerCode, logicalMode);
            if (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status1;
            }

            // �L���b�V������
            // 2009.01.06 >>>
            //status2 = this.CacheCustDmdPrc(this._custDmdPrcList);
            status2 = this.CacheCustDmdPrc(this._custDmdPrcList, sectionCode, resultSecCode, claimCode, customerCode);
            // 2009.01.06 <<<
            if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status2;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>���Ӑ搿�����z�}�X�^��������</summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <param name="resultSecCode">���ы��_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���Ӑ搿�����z�}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.03.08</br>
        /// <br>-------------------------</br>
        /// <br>Note       : �����Ɏ��ы��_�R�[�h��ǉ�</br>
        /// <br>Modifier   : ���i �r��</br>
        /// <br>Date       : 2008.06.24</br>
        /// </remarks>
        private int SearchCustDmdPrcProc2(out int totalCount, string enterpriseCode, string sectionCode, string resultSecCode, Int32 claimCode, Int32 customerCode, ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;
            totalCount = 0;

            try
            {
                // �擾���X�g������
                this._custDmdPrcList.Clear();

                // �L���b�V���p�e�[�u�����N���A
                this._custDmdPrcDic.Clear();

                object retobj = null;

                // ���Ӑ搿�����z�}�X�^����
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA DEL START
                //if (customerCode == claimCode) {
                //    customerCode = 0;   // �e���R�[�h�̏ꍇ�͓��Ӑ�R�[�h���O�œǂݍ���
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA DEL END
                status = this._iCustRsltUpdDB.SearchDmdPrc(enterpriseCode, sectionCode, claimCode, resultSecCode, customerCode, 0, out retobj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 2009.01.06 >>>
                    //this._custDmdPrcList = retobj as ArrayList;
                    this._custDmdPrcList = retobj as CustomSerializeArrayList;
                    // 2009.01.06 <<<

                    // �Y�������i�[
                    totalCount = this._custDmdPrcList.Count;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                }
            }
            catch (Exception)
            {
                //..debug
                //System.Windows.Forms.MessageBox.Show( ex.Message );

                // �I�t���C������null���Z�b�g
                this._iCustRsltUpdDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region Cache Methods

        /// <summary>�}�X�^�L���b�V������(���|)</summary>
        /// <param name="custAccRecList">���Ӑ攄�|���z�}�X�^�擾���ʃ��X�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̃L���b�V���������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.06 >>>
        //public int CacheCustAccRec(ArrayList custAccRecList)
        public int CacheCustAccRec(CustomSerializeArrayList custAccRecList, string sectionCode, Int32 claimCode, Int32 customerCode)
        // 2009.01.06 <<<
        {
            try
            {
                try
                {
                    // �X�V�����J�n
                    this._custAccRecTable.BeginLoadData();
                    this._custAccRecTotalTable.BeginLoadData(); // 2009.01.06 Add

                    // �e�[�u�����N���A
                    this._custAccRecTable.Clear();
                    this._custAccRecTotalTable.Clear();         // 2009.01.06 Add
                    // 2009.01.06 >>>
                    //// ���Ӑ攄�|���z�}�X�^�f�[�^��DataSet�Ɋi�[
                    //foreach (CustAccRecWork custAccRecWork in custAccRecList)
                    //{
                    //    // ���o�^�̎�
                    //    if (this._custAccRecDic.ContainsKey(custAccRecWork.FileHeaderGuid) == false)
                    //    {
                    //        // �f�[�^�Z�b�g�ɒǉ�
                    //        this.CustAccRecWorkToDataSet(custAccRecWork);
                    //    }
                    //}

                    for (int i = 0; i < custAccRecList.Count; i++)
                    {
                        if (custAccRecList[i] is ArrayList)
                        {
                            ArrayList accDataArrayList = (ArrayList)custAccRecList[i];

                            CustAccRecWork custAccRecWork = null;
                            CustAccRecWork custAccRecWorkTotal = null;
                            ArrayList accRecDepoTotalWorkArrayList = null;

                            for (int n = 0; n < accDataArrayList.Count; n++)
                            {
                                if (accDataArrayList[n] is ArrayList)
                                {
                                    ArrayList data = (ArrayList)accDataArrayList[n];
                                    if (data.Count > 0)
                                    {
                                        if (data[0] is CustAccRecWork)
                                        {
                                            if (data.Count > 0)
                                            {
                                                foreach (CustAccRecWork custAccRecWorkWk in data)
                                                {
                                                    if (custAccRecWorkWk.CustomerCode == 0)
                                                    {
                                                        custAccRecWorkTotal = custAccRecWorkWk;
                                                    }

                                                    if (( custAccRecWorkWk.AddUpSecCode.Trim() == sectionCode.Trim() ) &&
                                                        ( custAccRecWorkWk.ClaimCode == claimCode ) &&
                                                        ( custAccRecWorkWk.CustomerCode == customerCode ))
                                                    {
                                                        custAccRecWork = custAccRecWorkWk;
                                                    }
                                                }
                                            }
                                        }
                                        else if (data[0] is AccRecDepoTotalWork)
                                        {
                                            // �����f�[�^�̃��X�g
                                            accRecDepoTotalWorkArrayList = data;
                                        }
                                    }
                                }
                            }
                            // �W�v���R�[�h�ƃp�����[�^������Ȃ��\��������(���_)�̂ŔO�̂���
                            if (( customerCode == 0 ) && ( custAccRecWorkTotal != null ))
                            {
                                if (custAccRecWork == null) custAccRecWork = custAccRecWorkTotal;
                            }
                            if (custAccRecWork != null)
                            {
                                // ���o�^�̎�
                                if (this._custAccRecDic.ContainsKey(custAccRecWork.FileHeaderGuid) == false)
                                {
                                    // �f�[�^�Z�b�g�ɒǉ�
                                    this.CustAccRecWorkToDataSet(custAccRecWork, ( custAccRecWork.CustomerCode == 0 ) ? accRecDepoTotalWorkArrayList : null);
                                }
                            }
                            if (custAccRecWorkTotal != null)
                            {
                                this.CustAccRecWorkTotalToDataSet(custAccRecWorkTotal, accRecDepoTotalWorkArrayList);
                            }
                        }
                    }
                    // 2009.01.06 <<<
                }
                finally
                {
                    // �X�V�����I��
                    this._custAccRecTable.EndLoadData();
                    this._custAccRecTotalTable.EndLoadData();   // 2009.01.06 Add
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return -1;
            }

            return 0;
        }

        /// <summary>�}�X�^�L���b�V������(����)</summary>
        /// <param name="custDmdPrcList">���Ӑ搿�����z�}�X�^�擾���ʃ��X�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̃L���b�V���������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.06 >>>
        //public int CacheCustDmdPrc(ArrayList custDmdPrcList)
        private int CacheCustDmdPrc(CustomSerializeArrayList custDmdPrcList, string sectionCode, string resultSecCode, Int32 claimCode, Int32 customerCode)
        // 2009.01.06 <<<
        {
            try
            {
                try
                {
                    // �X�V�����J�n
                    this._custDmdPrcTable.BeginLoadData();
                    this._custDmdPrcTotalTable.BeginLoadData();     // 2009.01.06 Add

                    // �e�[�u�����N���A
                    this._custDmdPrcTable.Clear();
                    this._custDmdPrcTotalTable.Clear();     // 2009.01.06 Add

                    // 2009.01.06 >>>
                    //// ���Ӑ搿�����z�}�X�^�f�[�^��DataSet�Ɋi�[
                    //foreach (CustDmdPrcWork custDmdPrcWork in custDmdPrcList)
                    //{
                    //    // ���o�^�̎�
                    //    if (this._custDmdPrcDic.ContainsKey(custDmdPrcWork.FileHeaderGuid) == false)
                    //    {
                    //        // �f�[�^�Z�b�g�ɒǉ�
                    //        this.CustDmdPrcWorkToDataSet(custDmdPrcWork);
                    //    }
                    //}

                    for (int i = 0; i < custDmdPrcList.Count; i++)
                    {
                        if (custDmdPrcList[i] is ArrayList)
                        {
                            ArrayList dmdDataArrayList = (ArrayList)custDmdPrcList[i];

                            CustDmdPrcWork custDmdPrcWork = null;
                            CustDmdPrcWork custDmdPrcWorkTotal = null;
                            ArrayList dmdDepoTotalWorkArrayList = null;

                            for (int n = 0; n < dmdDataArrayList.Count; n++)
                            {
                                if (dmdDataArrayList[n] is ArrayList)
                                {
                                    ArrayList data = (ArrayList)dmdDataArrayList[n];
                                    if (data.Count > 0)
                                    {
                                        if (data[0] is CustDmdPrcWork)
                                        {
                                            if (data.Count > 0)
                                            {
                                                foreach (CustDmdPrcWork custDmdPrcWorkWk in data)
                                                {
                                                    if (( custDmdPrcWorkWk.ResultsSectCd.Trim() == ALL_SECTION ) && ( custDmdPrcWorkWk.CustomerCode == 0 ))
                                                    {
                                                        custDmdPrcWorkTotal = custDmdPrcWorkWk;
                                                    }

                                                    if (( custDmdPrcWorkWk.AddUpSecCode.Trim() == sectionCode.Trim() ) &&
                                                        ( custDmdPrcWorkWk.ResultsSectCd.Trim() == resultSecCode.Trim() ) &&
                                                        ( custDmdPrcWorkWk.ClaimCode == claimCode ) &&
                                                        ( custDmdPrcWorkWk.CustomerCode == customerCode ))
                                                    {
                                                        custDmdPrcWork = custDmdPrcWorkWk;
                                                    }
                                                }
                                            }
                                        }
                                        else if (data[0] is DmdDepoTotalWork)
                                        {
                                            // �����f�[�^�̃��X�g
                                            dmdDepoTotalWorkArrayList = data;
                                        }
                                    }
                                }
                            }

                            // �W�v���R�[�h�ƃp�����[�^������Ȃ��\��������(���_)�̂ŔO�̂���
                            if (( customerCode == 0 ) && ( custDmdPrcWorkTotal != null ))
                            {
                                if (custDmdPrcWork == null) custDmdPrcWork = custDmdPrcWorkTotal;
                            }
                            if (custDmdPrcWork != null)
                            {
                                // ���o�^�̎�
                                if (this._custDmdPrcDic.ContainsKey(custDmdPrcWork.FileHeaderGuid) == false)
                                {
                                    // �f�[�^�Z�b�g�ɒǉ�
                                    this.CustDmdPrcWorkToDataSet(custDmdPrcWork, ( custDmdPrcWork.CustomerCode == 0 ) ? dmdDepoTotalWorkArrayList : null);
                                }
                            }
                            if (custDmdPrcWorkTotal != null)
                            {
                                this.CustDmdPrcWorkTotalToDataSet(custDmdPrcWorkTotal, dmdDepoTotalWorkArrayList);
                            }
                        }
                    }
                    // 2009.01.06 <<<
                }
                finally
                {
                    // �X�V�����I��
                    this._custDmdPrcTable.EndLoadData();
                    this._custDmdPrcTotalTable.EndLoadData();   // 2009.01.06 Add
                }
            }
            catch (Exception ex)
            {
                return -1;
            }

            return 0;
        }

        #endregion

        // --------------------------------------------------
        #region MemberCopy Methods

        /// <summary>�N���X�����o�R�s�[���� (��ʕύX���Ӑ攄�|���z�}�X�^�N���X�˓��Ӑ攄�|���z�}�X�^���[�N�N���X)</summary>
        /// <param name="custAccRecWork">���Ӑ攄�|���z�}�X�^���[�N�N���X</param>
        /// <param name="custAccRec">���Ӑ攄�|���z�}�X�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ��ʕύX���Ӑ攄�|���z�}�X�^�N���X����
        ///                  ���Ӑ攄�|���z�}�X�^���[�N�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        private void CopyToCustAccRecWorkFromCustAccRec(ref CustAccRecWork custAccRecWork, CustAccRec custAccRec)
        {
            # region delete
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custAccRecWork.EnterpriseCode       = custAccRec.EnterpriseCode;
            //custAccRecWork.AddUpSecCode         = custAccRec.AddUpSecCode;
            //custAccRecWork.CustomerCode         = custAccRec.CustomerCode;
            //custAccRecWork.CustomerName         = custAccRec.CustomerName;
            //custAccRecWork.CustomerName2        = custAccRec.CustomerName2;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custAccRecWork.CustomerSnm          = custAccRec.CustomerSnm;
            //custAccRecWork.ClaimCode            = custAccRec.ClaimCode;
            //custAccRecWork.ClaimName            = custAccRec.ClaimName;
            //custAccRecWork.ClaimName2           = custAccRec.ClaimName2;
            //custAccRecWork.ClaimSnm             = custAccRec.ClaimSnm;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custAccRecWork.AddUpDate            = TDateTime.LongDateToDateTime(custAccRec.AddUpDate);
            ////custAccRecWork.AddUpYearMonth       = TDateTime.LongDateToDateTime(custAccRec.AddUpYearMonth);
            //custAccRecWork.AddUpDate = custAccRec.AddUpDate;
            //custAccRecWork.AddUpYearMonth = custAccRec.AddUpYearMonth;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //custAccRecWork.LastTimeAccRec       = custAccRec.LastTimeAccRec;
            //custAccRecWork.ThisTimeDmdNrml      = custAccRec.ThisTimeDmdNrml;
            //custAccRecWork.ThisTimeFeeDmdNrml   = custAccRec.ThisTimeFeeDmdNrml;
            //custAccRecWork.ThisTimeDisDmdNrml   = custAccRec.ThisTimeDisDmdNrml;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custAccRecWork.ThisTimeRbtDmdNrml   = custAccRec.ThisTimeRbtDmdNrml;
            ////custAccRecWork.ThisTimeDmdDepo      = custAccRec.ThisTimeDmdDepo;
            ////custAccRecWork.ThisTimeFeeDmdDepo   = custAccRec.ThisTimeFeeDmdDepo;
            ////custAccRecWork.ThisTimeDisDmdDepo   = custAccRec.ThisTimeDisDmdDepo;
            ////custAccRecWork.ThisTimeRbtDmdDepo   = custAccRec.ThisTimeRbtDmdDepo;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //custAccRecWork.ThisTimeTtlBlcAcc    = custAccRec.ThisTimeTtlBlcAcc;
            //custAccRecWork.ThisTimeSales        = custAccRec.ThisTimeSales;
            //custAccRecWork.ThisSalesTax         = custAccRec.ThisSalesTax;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custAccRecWork.TtlIncDtbtTaxExc     = custAccRec.TtlIncDtbtTaxExc;
            ////custAccRecWork.TtlIncDtbtTax        = custAccRec.TtlIncDtbtTax;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //custAccRecWork.OfsThisTimeSales     = custAccRec.OfsThisTimeSales;
            //custAccRecWork.OfsThisSalesTax      = custAccRec.OfsThisSalesTax;
            //custAccRecWork.ItdedOffsetOutTax    = custAccRec.ItdedOffsetOutTax;
            //custAccRecWork.ItdedOffsetInTax     = custAccRec.ItdedOffsetInTax;
            //custAccRecWork.ItdedOffsetTaxFree   = custAccRec.ItdedOffsetTaxFree;
            //custAccRecWork.OffsetOutTax         = custAccRec.OffsetOutTax;
            //custAccRecWork.OffsetInTax          = custAccRec.OffsetInTax;
            //custAccRecWork.ItdedSalesOutTax = custAccRec.ItdedSalesOutTax;
            //custAccRecWork.ItdedSalesInTax = custAccRec.ItdedSalesInTax;
            //custAccRecWork.ItdedSalesTaxFree = custAccRec.ItdedSalesTaxFree;
            //custAccRecWork.SalesOutTax = custAccRec.SalesOutTax;
            //custAccRecWork.SalesInTax = custAccRec.SalesInTax;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custAccRecWork.ItdedPaymOutTax      = custAccRec.ItdedPaymOutTax;
            ////custAccRecWork.ItdedPaymInTax       = custAccRec.ItdedPaymInTax;
            ////custAccRecWork.ItdedPaymTaxFree     = custAccRec.ItdedPaymTaxFree;
            ////custAccRecWork.PaymentOutTax        = custAccRec.PaymentOutTax;
            ////custAccRecWork.PaymentInTax         = custAccRec.PaymentInTax;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custAccRecWork.TtlItdedRetOutTax    = custAccRec.TtlItdedRetOutTax;
            //custAccRecWork.TtlItdedRetInTax     = custAccRec.TtlItdedRetInTax;
            //custAccRecWork.TtlItdedRetTaxFree   = custAccRec.TtlItdedRetTaxFree;
            //custAccRecWork.TtlRetOuterTax       = custAccRec.TtlRetOuterTax;
            //custAccRecWork.TtlRetInnerTax       = custAccRec.TtlRetInnerTax;
            //custAccRecWork.TtlItdedDisOutTax    = custAccRec.TtlItdedDisOutTax;
            //custAccRecWork.TtlItdedDisInTax     = custAccRec.TtlItdedDisInTax;
            //custAccRecWork.TtlItdedDisTaxFree   = custAccRec.TtlItdedDisTaxFree;
            //custAccRecWork.TtlDisOuterTax       = custAccRec.TtlDisOuterTax;
            //custAccRecWork.TtlDisInnerTax       = custAccRec.TtlDisInnerTax;
            //custAccRecWork.BalanceAdjust        = custAccRec.BalanceAdjust;
            //custAccRecWork.ThisCashSalePrice    = custAccRec.ThisCashSalePrice;
            //custAccRecWork.ThisCashSaleTax      = custAccRec.ThisCashSaleTax;
            //custAccRecWork.ThisSalesPricRgds    = custAccRec.ThisSalesPricRgds;
            //custAccRecWork.ThisSalesPricDis     = custAccRec.ThisSalesPricDis;
            //custAccRecWork.ThisSalesPrcTaxRgds  = custAccRec.ThisSalesPrcTaxRgds;
            //custAccRecWork.ThisSalesPrcTaxDis   = custAccRec.ThisSalesPrcTaxDis;
            //custAccRecWork.NonStmntAppearance   = custAccRec.NonStmntAppearance;
            //custAccRecWork.NonStmntIsdone       = custAccRec.NonStmntIsdone;
            //custAccRecWork.StmntAppearance      = custAccRec.StmntAppearance;
            //custAccRecWork.StmntIsdone          = custAccRec.StmntIsdone;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //custAccRecWork.ConsTaxLayMethod     = custAccRec.ConsTaxLayMethod;
            //custAccRecWork.ConsTaxRate          = custAccRec.ConsTaxRate;
            //custAccRecWork.FractionProcCd       = custAccRec.FractionProcCd;
            //custAccRecWork.AfCalTMonthAccRec    = custAccRec.AfCalTMonthAccRec;
            //custAccRecWork.AcpOdrTtl2TmBfAccRec = custAccRec.AcpOdrTtl2TmBfAccRec;
            //custAccRecWork.AcpOdrTtl3TmBfAccRec = custAccRec.AcpOdrTtl3TmBfAccRec;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custAccRecWork.MonthAddUpExpDate    = TDateTime.LongDateToDateTime(custAccRec.MonthAddUpExpDate);
            //custAccRecWork.MonthAddUpExpDate = custAccRec.MonthAddUpExpDate;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            # endregion

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            custAccRecWork.CreateDateTime = custAccRec.CreateDateTime; // �쐬����
            custAccRecWork.UpdateDateTime = custAccRec.UpdateDateTime; // �X�V����
            custAccRecWork.EnterpriseCode = custAccRec.EnterpriseCode; // ��ƃR�[�h
            custAccRecWork.FileHeaderGuid = custAccRec.FileHeaderGuid; // GUID
            custAccRecWork.UpdEmployeeCode = custAccRec.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            custAccRecWork.UpdAssemblyId1 = custAccRec.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            custAccRecWork.UpdAssemblyId2 = custAccRec.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            custAccRecWork.LogicalDeleteCode = custAccRec.LogicalDeleteCode; // �_���폜�敪
            custAccRecWork.AddUpSecCode = custAccRec.AddUpSecCode; // �v�㋒�_�R�[�h
            custAccRecWork.ClaimCode = custAccRec.ClaimCode; // ������R�[�h
            custAccRecWork.ClaimName = custAccRec.ClaimName; // �����於��
            custAccRecWork.ClaimName2 = custAccRec.ClaimName2; // �����於��2
            custAccRecWork.ClaimSnm = custAccRec.ClaimSnm; // �����旪��
            custAccRecWork.CustomerCode = custAccRec.CustomerCode; // ���Ӑ�R�[�h
            custAccRecWork.CustomerName = custAccRec.CustomerName; // ���Ӑ於��
            custAccRecWork.CustomerName2 = custAccRec.CustomerName2; // ���Ӑ於��2
            custAccRecWork.CustomerSnm = custAccRec.CustomerSnm; // ���Ӑ旪��
            custAccRecWork.AddUpDate = custAccRec.AddUpDate; // �v��N����
            custAccRecWork.AddUpYearMonth = custAccRec.AddUpYearMonth; // �v��N��
            custAccRecWork.LastTimeAccRec = custAccRec.LastTimeAccRec; // �O�񔄊|���z
            custAccRecWork.ThisTimeFeeDmdNrml = custAccRec.ThisTimeFeeDmdNrml; // ����萔���z�i�ʏ�����j
            custAccRecWork.ThisTimeDisDmdNrml = custAccRec.ThisTimeDisDmdNrml; // ����l���z�i�ʏ�����j
            custAccRecWork.ThisTimeDmdNrml = custAccRec.ThisTimeDmdNrml; // ����������z�i�ʏ�����j
            custAccRecWork.ThisTimeTtlBlcAcc = custAccRec.ThisTimeTtlBlcAcc; // ����J�z�c���i���|�v�j
            custAccRecWork.OfsThisTimeSales = custAccRec.OfsThisTimeSales; // ���E�㍡�񔄏���z
            custAccRecWork.OfsThisSalesTax = custAccRec.OfsThisSalesTax; // ���E�㍡�񔄏�����
            custAccRecWork.ItdedOffsetOutTax = custAccRec.ItdedOffsetOutTax; // ���E��O�őΏۊz
            custAccRecWork.ItdedOffsetInTax = custAccRec.ItdedOffsetInTax; // ���E����őΏۊz
            custAccRecWork.ItdedOffsetTaxFree = custAccRec.ItdedOffsetTaxFree; // ���E���ېőΏۊz
            custAccRecWork.OffsetOutTax = custAccRec.OffsetOutTax; // ���E��O�ŏ����
            custAccRecWork.OffsetInTax = custAccRec.OffsetInTax; // ���E����ŏ����
            custAccRecWork.ThisTimeSales = custAccRec.ThisTimeSales; // ���񔄏���z
            custAccRecWork.ThisSalesTax = custAccRec.ThisSalesTax; // ���񔄏�����
            custAccRecWork.ItdedSalesOutTax = custAccRec.ItdedSalesOutTax; // ����O�őΏۊz
            custAccRecWork.ItdedSalesInTax = custAccRec.ItdedSalesInTax; // ������őΏۊz
            custAccRecWork.ItdedSalesTaxFree = custAccRec.ItdedSalesTaxFree; // �����ېőΏۊz
            custAccRecWork.SalesOutTax = custAccRec.SalesOutTax; // ����O�Ŋz
            custAccRecWork.SalesInTax = custAccRec.SalesInTax; // ������Ŋz
            custAccRecWork.ThisSalesPricRgds = custAccRec.ThisSalesPricRgds; // ���񔄏�ԕi���z
            custAccRecWork.ThisSalesPrcTaxRgds = custAccRec.ThisSalesPrcTaxRgds; // ���񔄏�ԕi�����
            custAccRecWork.TtlItdedRetOutTax = custAccRec.TtlItdedRetOutTax; // �ԕi�O�őΏۊz���v
            custAccRecWork.TtlItdedRetInTax = custAccRec.TtlItdedRetInTax; // �ԕi���őΏۊz���v
            custAccRecWork.TtlItdedRetTaxFree = custAccRec.TtlItdedRetTaxFree; // �ԕi��ېőΏۊz���v
            custAccRecWork.TtlRetOuterTax = custAccRec.TtlRetOuterTax; // �ԕi�O�Ŋz���v
            custAccRecWork.TtlRetInnerTax = custAccRec.TtlRetInnerTax; // �ԕi���Ŋz���v
            custAccRecWork.ThisSalesPricDis = custAccRec.ThisSalesPricDis; // ���񔄏�l�����z
            custAccRecWork.ThisSalesPrcTaxDis = custAccRec.ThisSalesPrcTaxDis; // ���񔄏�l�������
            custAccRecWork.TtlItdedDisOutTax = custAccRec.TtlItdedDisOutTax; // �l���O�őΏۊz���v
            custAccRecWork.TtlItdedDisInTax = custAccRec.TtlItdedDisInTax; // �l�����őΏۊz���v
            custAccRecWork.TtlItdedDisTaxFree = custAccRec.TtlItdedDisTaxFree; // �l����ېőΏۊz���v
            custAccRecWork.TtlDisOuterTax = custAccRec.TtlDisOuterTax; // �l���O�Ŋz���v
            custAccRecWork.TtlDisInnerTax = custAccRec.TtlDisInnerTax; // �l�����Ŋz���v

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //custAccRecWork.ThisPayOffset = custAccRec.ThisPayOffset; // ����x�����E���z
            //custAccRecWork.ThisPayOffsetTax = custAccRec.ThisPayOffsetTax; // ����x�����E�����
            //custAccRecWork.ItdedPaymOutTax = custAccRec.ItdedPaymOutTax; // �x���O�őΏۊz
            //custAccRecWork.ItdedPaymInTax = custAccRec.ItdedPaymInTax; // �x�����őΏۊz
            //custAccRecWork.ItdedPaymTaxFree = custAccRec.ItdedPaymTaxFree; // �x����ېőΏۊz
            //custAccRecWork.PaymentOutTax = custAccRec.PaymentOutTax; // �x���O�ŏ����
            //custAccRecWork.PaymentInTax = custAccRec.PaymentInTax; // �x�����ŏ����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            custAccRecWork.TaxAdjust = custAccRec.TaxAdjust; // ����Œ����z
            custAccRecWork.BalanceAdjust = custAccRec.BalanceAdjust; // �c�������z
            custAccRecWork.AfCalTMonthAccRec = custAccRec.AfCalTMonthAccRec; // �v�Z�㓖�����|���z
            custAccRecWork.AcpOdrTtl2TmBfAccRec = custAccRec.AcpOdrTtl2TmBfAccRec; // ��2��O�c���i���|�v�j
            custAccRecWork.AcpOdrTtl3TmBfAccRec = custAccRec.AcpOdrTtl3TmBfAccRec; // ��3��O�c���i���|�v�j
            custAccRecWork.MonthAddUpExpDate = custAccRec.MonthAddUpExpDate; // �����X�V���s�N����
            custAccRecWork.StMonCAddUpUpdDate = custAccRec.StMonCAddUpUpdDate; // �����X�V�J�n�N����
            custAccRecWork.LaMonCAddUpUpdDate = custAccRec.LaMonCAddUpUpdDate; // �O�񌎎��X�V�N����
            custAccRecWork.SalesSlipCount = custAccRec.SalesSlipCount; // ����`�[����

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //custAccRecWork.NonStmntAppearance = custAccRec.NonStmntAppearance; // �����ϋ��z�i���U�j
            //custAccRecWork.NonStmntIsdone = custAccRec.NonStmntIsdone; // �����ϋ��z�i�􂵁j
            //custAccRecWork.StmntAppearance = custAccRec.StmntAppearance; // ���ϋ��z�i���U�j
            //custAccRecWork.StmntIsdone = custAccRec.StmntIsdone; // ���ϋ��z�i�􂵁j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            custAccRecWork.ConsTaxLayMethod = custAccRec.ConsTaxLayMethod; // ����œ]�ŕ���
            custAccRecWork.ConsTaxRate = custAccRec.ConsTaxRate; // ����ŗ�
            custAccRecWork.FractionProcCd = custAccRec.FractionProcCd; // �[�������敪
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if ( custAccRecWork.CustomerCode == custAccRecWork.ClaimCode )
            //{
            //    custAccRecWork.CustomerCode = 0;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA DEL END
        }

        /// <summary>�N���X�����o�R�s�[���� (��ʕύX���Ӑ搿�����z�}�X�^�N���X�˓��Ӑ搿�����z�}�X�^���[�N�N���X)</summary>
        /// <param name="custDmdPrcWork">���Ӑ搿�����z�}�X�^���[�N�N���X</param>
        /// <param name="custDmdPrc">���Ӑ搿�����z�}�X�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ��ʕύX���Ӑ搿�����z�}�X�^�N���X����
        ///                  ���Ӑ搿�����z�}�X�^���[�N�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        private void CopyToCustDmdPrcWorkFromCustDmdPrc(ref CustDmdPrcWork custDmdPrcWork, CustDmdPrc custDmdPrc)
        {
            # region delete
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custDmdPrcWork.EnterpriseCode       = custDmdPrc.EnterpriseCode;
            //custDmdPrcWork.AddUpSecCode         = custDmdPrc.AddUpSecCode;
            //custDmdPrcWork.CustomerCode         = custDmdPrc.CustomerCode;
            //custDmdPrcWork.CustomerName         = custDmdPrc.CustomerName;
            //custDmdPrcWork.CustomerName2        = custDmdPrc.CustomerName2;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custDmdPrcWork.CustomerSnm          = custDmdPrc.CustomerSnm;
            //custDmdPrcWork.ClaimCode            = custDmdPrc.ClaimCode;
            //custDmdPrcWork.ClaimName            = custDmdPrc.ClaimName;
            //custDmdPrcWork.ClaimName2           = custDmdPrc.ClaimName2;
            //custDmdPrcWork.ClaimSnm             = custDmdPrc.ClaimSnm;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custDmdPrcWork.AddUpDate            = TDateTime.LongDateToDateTime(custDmdPrc.AddUpDate);
            ////custDmdPrcWork.AddUpYearMonth       = TDateTime.LongDateToDateTime(custDmdPrc.AddUpYearMonth);
            //custDmdPrcWork.AddUpDate = custDmdPrc.AddUpDate;
            //custDmdPrcWork.AddUpYearMonth = custDmdPrc.AddUpYearMonth;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //custDmdPrcWork.LastTimeDemand       = custDmdPrc.LastTimeDemand;
            //custDmdPrcWork.ThisTimeDmdNrml      = custDmdPrc.ThisTimeDmdNrml;
            //custDmdPrcWork.ThisTimeFeeDmdNrml   = custDmdPrc.ThisTimeFeeDmdNrml;
            //custDmdPrcWork.ThisTimeDisDmdNrml   = custDmdPrc.ThisTimeDisDmdNrml;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custDmdPrcWork.ThisTimeRbtDmdNrml   = custDmdPrc.ThisTimeRbtDmdNrml;
            ////custDmdPrcWork.ThisTimeDmdDepo      = custDmdPrc.ThisTimeDmdDepo;
            ////custDmdPrcWork.ThisTimeFeeDmdDepo   = custDmdPrc.ThisTimeFeeDmdDepo;
            ////custDmdPrcWork.ThisTimeDisDmdDepo   = custDmdPrc.ThisTimeDisDmdDepo;
            ////custDmdPrcWork.ThisTimeRbtDmdDepo   = custDmdPrc.ThisTimeRbtDmdDepo;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //custDmdPrcWork.ThisTimeTtlBlcDmd    = custDmdPrc.ThisTimeTtlBlcDmd;
            //custDmdPrcWork.ThisTimeSales        = custDmdPrc.ThisTimeSales;
            //custDmdPrcWork.ThisSalesTax         = custDmdPrc.ThisSalesTax;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custDmdPrcWork.TtlIncDtbtTaxExc     = custDmdPrc.TtlIncDtbtTaxExc;
            ////custDmdPrcWork.TtlIncDtbtTax        = custDmdPrc.TtlIncDtbtTax;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //custDmdPrcWork.OfsThisTimeSales     = custDmdPrc.OfsThisTimeSales;
            //custDmdPrcWork.OfsThisSalesTax      = custDmdPrc.OfsThisSalesTax;
            //custDmdPrcWork.ItdedOffsetOutTax    = custDmdPrc.ItdedOffsetOutTax;
            //custDmdPrcWork.ItdedOffsetInTax     = custDmdPrc.ItdedOffsetInTax;
            //custDmdPrcWork.ItdedOffsetTaxFree   = custDmdPrc.ItdedOffsetTaxFree;
            //custDmdPrcWork.OffsetOutTax         = custDmdPrc.OffsetOutTax;
            //custDmdPrcWork.OffsetInTax          = custDmdPrc.OffsetInTax;
            //custDmdPrcWork.ItdedSalesOutTax     = custDmdPrc.ItdedSalesOutTax;
            //custDmdPrcWork.ItdedSalesInTax      = custDmdPrc.ItdedSalesInTax;
            //custDmdPrcWork.ItdedSalesTaxFree    = custDmdPrc.ItdedSalesTaxFree;
            //custDmdPrcWork.SalesOutTax          = custDmdPrc.SalesOutTax;
            //custDmdPrcWork.SalesInTax           = custDmdPrc.SalesInTax;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custDmdPrcWork.ItdedPaymOutTax      = custDmdPrc.ItdedPaymOutTax;
            ////custDmdPrcWork.ItdedPaymInTax       = custDmdPrc.ItdedPaymInTax;
            ////custDmdPrcWork.ItdedPaymTaxFree     = custDmdPrc.ItdedPaymTaxFree;
            ////custDmdPrcWork.PaymentOutTax        = custDmdPrc.PaymentOutTax;
            ////custDmdPrcWork.PaymentInTax         = custDmdPrc.PaymentInTax;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //custDmdPrcWork.TtlItdedRetOutTax    = custDmdPrc.TtlItdedRetOutTax;
            //custDmdPrcWork.TtlItdedRetInTax     = custDmdPrc.TtlItdedRetInTax;
            //custDmdPrcWork.TtlItdedRetTaxFree   = custDmdPrc.TtlItdedRetTaxFree;
            //custDmdPrcWork.TtlRetOuterTax       = custDmdPrc.TtlRetOuterTax;
            //custDmdPrcWork.TtlRetInnerTax       = custDmdPrc.TtlRetInnerTax;
            //custDmdPrcWork.TtlItdedDisOutTax    = custDmdPrc.TtlItdedDisOutTax;
            //custDmdPrcWork.TtlItdedDisInTax     = custDmdPrc.TtlItdedDisInTax;
            //custDmdPrcWork.TtlItdedDisTaxFree   = custDmdPrc.TtlItdedDisTaxFree;
            //custDmdPrcWork.TtlDisOuterTax       = custDmdPrc.TtlDisOuterTax;
            //custDmdPrcWork.TtlDisInnerTax       = custDmdPrc.TtlDisInnerTax;
            //custDmdPrcWork.BalanceAdjust        = custDmdPrc.BalanceAdjust;
            //custDmdPrcWork.ThisSalesPricRgds    = custDmdPrc.ThisSalesPricRgds;
            //custDmdPrcWork.ThisSalesPricDis     = custDmdPrc.ThisSalesPricDis;
            //custDmdPrcWork.ThisSalesPrcTaxRgds  = custDmdPrc.ThisSalesPrcTaxRgds;
            //custDmdPrcWork.ThisSalesPrcTaxDis   = custDmdPrc.ThisSalesPrcTaxDis;
            //custDmdPrcWork.SaleslSlipCount      = custDmdPrc.SaleslSlipCount;
            //custDmdPrcWork.BillPrintDate        = custDmdPrc.BillPrintDate;
            //custDmdPrcWork.ExpectedDepositDate  = custDmdPrc.ExpectedDepositDate;
            //custDmdPrcWork.CollectCond          = custDmdPrc.CollectCond;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //custDmdPrcWork.ConsTaxLayMethod     = custDmdPrc.ConsTaxLayMethod;
            //custDmdPrcWork.ConsTaxRate          = custDmdPrc.ConsTaxRate;
            //custDmdPrcWork.FractionProcCd       = custDmdPrc.FractionProcCd;
            //custDmdPrcWork.AfCalDemandPrice     = custDmdPrc.AfCalDemandPrice;
            //custDmdPrcWork.AcpOdrTtl2TmBfBlDmd  = custDmdPrc.AcpOdrTtl2TmBfBlDmd;
            //custDmdPrcWork.AcpOdrTtl3TmBfBlDmd  = custDmdPrc.AcpOdrTtl3TmBfBlDmd;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custDmdPrcWork.CAddUpUpdExecDate    = TDateTime.LongDateToDateTime(custDmdPrc.CAddUpUpdExecDate);
            //custDmdPrcWork.CAddUpUpdExecDate = custDmdPrc.CAddUpUpdExecDate;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////custDmdPrcWork.DmdProcNum           = custDmdPrc.DmdProcNum;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            # endregion

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            custDmdPrcWork.CreateDateTime = custDmdPrc.CreateDateTime; // �쐬����
            custDmdPrcWork.UpdateDateTime = custDmdPrc.UpdateDateTime; // �X�V����
            custDmdPrcWork.EnterpriseCode = custDmdPrc.EnterpriseCode; // ��ƃR�[�h
            custDmdPrcWork.FileHeaderGuid = custDmdPrc.FileHeaderGuid; // GUID
            custDmdPrcWork.UpdEmployeeCode = custDmdPrc.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            custDmdPrcWork.UpdAssemblyId1 = custDmdPrc.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            custDmdPrcWork.UpdAssemblyId2 = custDmdPrc.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            custDmdPrcWork.LogicalDeleteCode = custDmdPrc.LogicalDeleteCode; // �_���폜�敪
            custDmdPrcWork.AddUpSecCode = custDmdPrc.AddUpSecCode; // �v�㋒�_�R�[�h

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
            custDmdPrcWork.ResultsSectCd = custDmdPrc.ResultsSectCd;    // ���ы��_�R�[�h
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END

            custDmdPrcWork.ClaimCode = custDmdPrc.ClaimCode; // ������R�[�h
            custDmdPrcWork.ClaimName = custDmdPrc.ClaimName; // �����於��
            custDmdPrcWork.ClaimName2 = custDmdPrc.ClaimName2; // �����於��2
            custDmdPrcWork.ClaimSnm = custDmdPrc.ClaimSnm; // �����旪��
            custDmdPrcWork.CustomerCode = custDmdPrc.CustomerCode; // ���Ӑ�R�[�h
            custDmdPrcWork.CustomerName = custDmdPrc.CustomerName; // ���Ӑ於��
            custDmdPrcWork.CustomerName2 = custDmdPrc.CustomerName2; // ���Ӑ於��2
            custDmdPrcWork.CustomerSnm = custDmdPrc.CustomerSnm; // ���Ӑ旪��
            custDmdPrcWork.AddUpDate = custDmdPrc.AddUpDate; // �v��N����
            custDmdPrcWork.AddUpYearMonth = custDmdPrc.AddUpYearMonth; // �v��N��
            custDmdPrcWork.LastTimeDemand = custDmdPrc.LastTimeDemand; // �O�񐿋����z
            custDmdPrcWork.ThisTimeFeeDmdNrml = custDmdPrc.ThisTimeFeeDmdNrml; // ����萔���z�i�ʏ�����j
            custDmdPrcWork.ThisTimeDisDmdNrml = custDmdPrc.ThisTimeDisDmdNrml; // ����l���z�i�ʏ�����j
            custDmdPrcWork.ThisTimeDmdNrml = custDmdPrc.ThisTimeDmdNrml; // ����������z�i�ʏ�����j
            custDmdPrcWork.ThisTimeTtlBlcDmd = custDmdPrc.ThisTimeTtlBlcDmd; // ����J�z�c���i�����v�j
            custDmdPrcWork.OfsThisTimeSales = custDmdPrc.OfsThisTimeSales; // ���E�㍡�񔄏���z
            custDmdPrcWork.OfsThisSalesTax = custDmdPrc.OfsThisSalesTax; // ���E�㍡�񔄏�����
            custDmdPrcWork.ItdedOffsetOutTax = custDmdPrc.ItdedOffsetOutTax; // ���E��O�őΏۊz
            custDmdPrcWork.ItdedOffsetInTax = custDmdPrc.ItdedOffsetInTax; // ���E����őΏۊz
            custDmdPrcWork.ItdedOffsetTaxFree = custDmdPrc.ItdedOffsetTaxFree; // ���E���ېőΏۊz
            custDmdPrcWork.OffsetOutTax = custDmdPrc.OffsetOutTax; // ���E��O�ŏ����
            custDmdPrcWork.OffsetInTax = custDmdPrc.OffsetInTax; // ���E����ŏ����
            custDmdPrcWork.ThisTimeSales = custDmdPrc.ThisTimeSales; // ���񔄏���z
            custDmdPrcWork.ThisSalesTax = custDmdPrc.ThisSalesTax; // ���񔄏�����
            custDmdPrcWork.ItdedSalesOutTax = custDmdPrc.ItdedSalesOutTax; // ����O�őΏۊz
            custDmdPrcWork.ItdedSalesInTax = custDmdPrc.ItdedSalesInTax; // ������őΏۊz
            custDmdPrcWork.ItdedSalesTaxFree = custDmdPrc.ItdedSalesTaxFree; // �����ېőΏۊz
            custDmdPrcWork.SalesOutTax = custDmdPrc.SalesOutTax; // ����O�Ŋz
            custDmdPrcWork.SalesInTax = custDmdPrc.SalesInTax; // ������Ŋz
            custDmdPrcWork.ThisSalesPricRgds = custDmdPrc.ThisSalesPricRgds; // ���񔄏�ԕi���z
            custDmdPrcWork.ThisSalesPrcTaxRgds = custDmdPrc.ThisSalesPrcTaxRgds; // ���񔄏�ԕi�����
            custDmdPrcWork.TtlItdedRetOutTax = custDmdPrc.TtlItdedRetOutTax; // �ԕi�O�őΏۊz���v
            custDmdPrcWork.TtlItdedRetInTax = custDmdPrc.TtlItdedRetInTax; // �ԕi���őΏۊz���v
            custDmdPrcWork.TtlItdedRetTaxFree = custDmdPrc.TtlItdedRetTaxFree; // �ԕi��ېőΏۊz���v
            custDmdPrcWork.TtlRetOuterTax = custDmdPrc.TtlRetOuterTax; // �ԕi�O�Ŋz���v
            custDmdPrcWork.TtlRetInnerTax = custDmdPrc.TtlRetInnerTax; // �ԕi���Ŋz���v
            custDmdPrcWork.ThisSalesPricDis = custDmdPrc.ThisSalesPricDis; // ���񔄏�l�����z
            custDmdPrcWork.ThisSalesPrcTaxDis = custDmdPrc.ThisSalesPrcTaxDis; // ���񔄏�l�������
            custDmdPrcWork.TtlItdedDisOutTax = custDmdPrc.TtlItdedDisOutTax; // �l���O�őΏۊz���v
            custDmdPrcWork.TtlItdedDisInTax = custDmdPrc.TtlItdedDisInTax; // �l�����őΏۊz���v
            custDmdPrcWork.TtlItdedDisTaxFree = custDmdPrc.TtlItdedDisTaxFree; // �l����ېőΏۊz���v
            custDmdPrcWork.TtlDisOuterTax = custDmdPrc.TtlDisOuterTax; // �l���O�Ŋz���v
            custDmdPrcWork.TtlDisInnerTax = custDmdPrc.TtlDisInnerTax; // �l�����Ŋz���v

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //custDmdPrcWork.ThisPayOffset = custDmdPrc.ThisPayOffset; // ����x�����E���z
            //custDmdPrcWork.ThisPayOffsetTax = custDmdPrc.ThisPayOffsetTax; // ����x�����E�����
            //custDmdPrcWork.ItdedPaymOutTax = custDmdPrc.ItdedPaymOutTax; // �x���O�őΏۊz
            //custDmdPrcWork.ItdedPaymInTax = custDmdPrc.ItdedPaymInTax; // �x�����őΏۊz
            //custDmdPrcWork.ItdedPaymTaxFree = custDmdPrc.ItdedPaymTaxFree; // �x����ېőΏۊz
            //custDmdPrcWork.PaymentOutTax = custDmdPrc.PaymentOutTax; // �x���O�ŏ����
            //custDmdPrcWork.PaymentInTax = custDmdPrc.PaymentInTax; // �x�����ŏ����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            custDmdPrcWork.TaxAdjust = custDmdPrc.TaxAdjust; // ����Œ����z
            custDmdPrcWork.BalanceAdjust = custDmdPrc.BalanceAdjust; // �c�������z
            custDmdPrcWork.AfCalDemandPrice = custDmdPrc.AfCalDemandPrice; // �v�Z�㐿�����z
            custDmdPrcWork.AcpOdrTtl2TmBfBlDmd = custDmdPrc.AcpOdrTtl2TmBfBlDmd; // ��2��O�c���i�����v�j
            custDmdPrcWork.AcpOdrTtl3TmBfBlDmd = custDmdPrc.AcpOdrTtl3TmBfBlDmd; // ��3��O�c���i�����v�j
            custDmdPrcWork.CAddUpUpdExecDate = custDmdPrc.CAddUpUpdExecDate; // �����X�V���s�N����
            custDmdPrcWork.StartCAddUpUpdDate = custDmdPrc.StartCAddUpUpdDate; // �����X�V�J�n�N����
            custDmdPrcWork.LastCAddUpUpdDate = custDmdPrc.LastCAddUpUpdDate; // �O������X�V�N����
            custDmdPrcWork.SalesSlipCount = custDmdPrc.SalesSlipCount; // ����`�[����
            custDmdPrcWork.BillPrintDate = custDmdPrc.BillPrintDate; // ���������s��
            custDmdPrcWork.ExpectedDepositDate = custDmdPrc.ExpectedDepositDate; // �����\���
            custDmdPrcWork.CollectCond = custDmdPrc.CollectCond; // �������
            custDmdPrcWork.ConsTaxLayMethod = custDmdPrc.ConsTaxLayMethod; // ����œ]�ŕ���
            custDmdPrcWork.ConsTaxRate = custDmdPrc.ConsTaxRate; // ����ŗ�
            custDmdPrcWork.FractionProcCd = custDmdPrc.FractionProcCd; // �[�������敪
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // ADD 2009/06/23 ------>>>
            custDmdPrcWork.BillNo = custDmdPrc.BillNo; // ������No
            // ADD 2009/06/23 ------<<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //if ( custDmdPrcWork.CustomerCode == custDmdPrcWork.ClaimCode )
            //{
            //    custDmdPrcWork.CustomerCode = 0;
            //}
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA DEL END
        }

        #region    ********** �s�v **********
        /// <summary>�N���X�����o�R�s�[���� (���Ӑ攄�|���z�}�X�^���[�N�N���X�˓��Ӑ攄�|���z�}�X�^�N���X)
		/// </summary>
        /// <param name="financStmntOutWork">���Ӑ攄�|���z�}�X�^���[�N�N���X</param>
        /// <returns>���Ӑ攄�|���z�}�X�^�N���X</returns>
		/// <remarks>
        /// <br>Note       : ���Ӑ攄�|���z�}�X�^���[�N�N���X����
        ///                  ���Ӑ攄�|���z�}�X�^�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        //private CustAccRec CopyToFinancStmntOutFromFinancStmntOutWork(CustAccRecWork custAccRecWork)
        //{
        //    FinancStmntOut financStmntOut = new FinancStmntOut();

        //    custAccRec.CreateDateTime       = custAccRecWork.CreateDateTime;       // �쐬����
        //    custAccRec.UpdateDateTime       = custAccRecWork.UpdateDateTime;       // �X�V����
        //    custAccRec.EnterpriseCode       = custAccRecWork.EnterpriseCode;       // ��ƃR�[�h
        //    custAccRec.FileHeaderGuid       = custAccRecWork.FileHeaderGuid;       // GUID
        //    custAccRec.UpdEmployeeCode      = custAccRecWork.UpdEmployeeCode;      // �X�V�]�ƈ��R�[�h
        //    custAccRec.UpdAssemblyId1       = custAccRecWork.UpdAssemblyId1;       // �X�V�A�Z���u��ID1
        //    custAccRec.UpdAssemblyId2       = custAccRecWork.UpdAssemblyId2;       // �X�V�A�Z���u��ID2
        //    custAccRec.LogicalDeleteCode    = custAccRecWork.LogicalDeleteCode;    // �_���폜�敪
        //    custAccRec.EnterpriseCode       = custAccRecWork.EnterpriseCode;
        //    custAccRec.AddUpSecCode         = custAccRecWork.AddUpSecCode;
        //    custAccRec.CustomerCode         = custAccRecWork.CustomerCode;
        //    custAccRec.CustomerName         = custAccRecWork.CustomerName;
        //    custAccRec.CustomerName2        = custAccRecWork.CustomerName2;
        //    custAccRec.AddUpDate            = custAccRecWork.AddUpDate;
        //    custAccRec.AddUpYearMonth       = custAccRecWork.AddUpYearMonth;
        //    custAccRec.LastTimeAccRec       = custAccRecWork.LastTimeAccRec;
        //    custAccRec.ThisTimeDmdNrml      = custAccRecWork.ThisTimeDmdNrml;
        //    custAccRec.ThisTimeFeeDmdNrml   = custAccRecWork.ThisTimeFeeDmdNrml;
        //    custAccRec.ThisTimeDisDmdNrml   = custAccRecWork.ThisTimeDisDmdNrml;
        //    custAccRec.ThisTimeRbtDmdNrml   = custAccRecWork.ThisTimeRbtDmdNrml;
        //    custAccRec.ThisTimeDmdDepo      = custAccRecWork.ThisTimeDmdDepo;
        //    custAccRec.ThisTimeFeeDmdDepo   = custAccRecWork.ThisTimeFeeDmdDepo;
        //    custAccRec.ThisTimeDisDmdDepo   = custAccRecWork.ThisTimeDisDmdDepo;
        //    custAccRec.ThisTimeRbtDmdDepo   = custAccRecWork.ThisTimeRbtDmdDepo;
        //    custAccRec.ThisTimeTtlBlcAcc    = custAccRecWork.ThisTimeTtlBlcAcc;
        //    custAccRec.ThisTimeSales        = custAccRecWork.ThisTimeSales;
        //    custAccRec.ThisSalesTax         = custAccRecWork.ThisSalesTax;
        //    custAccRec.TtlIncDtbtTaxExc     = custAccRecWork.TtlIncDtbtTaxExc;
        //    custAccRec.TtlIncDtbtTax        = custAccRecWork.TtlIncDtbtTax;
        //    custAccRec.OfsThisTimeSales     = custAccRecWork.OfsThisTimeSales;
        //    custAccRec.OfsThisSalesTax      = custAccRecWork.OfsThisSalesTax;
        //    custAccRec.ItdedOffsetOutTax    = custAccRecWork.ItdedOffsetOutTax;
        //    custAccRec.ItdedOffsetInTax     = custAccRecWork.ItdedOffsetInTax;
        //    custAccRec.ItdedOffsetTaxFree   = custAccRecWork.ItdedOffsetTaxFree;
        //    custAccRec.OffsetOutTax         = custAccRecWork.OffsetOutTax;
        //    custAccRec.OffsetInTax          = custAccRecWork.OffsetInTax;
        //    custAccRec.ItdedSalesOutTax     = custAccRecWork.ItdedSalesOutTax;
        //    custAccRec.ItdedSalesInTax      = custAccRecWork.ItdedSalesInTax;
        //    custAccRec.ItdedSalesTaxFree    = custAccRecWork.ItdedSalesTaxFree;
        //    custAccRec.SalesOutTax          = custAccRecWork.SalesOutTax;
        //    custAccRec.SalesInTax           = custAccRecWork.SalesInTax;
        //    custAccRec.ItdedPaymOutTax      = custAccRecWork.ItdedPaymOutTax;
        //    custAccRec.ItdedPaymInTax       = custAccRecWork.ItdedPaymInTax;
        //    custAccRec.ItdedPaymTaxFree     = custAccRecWork.ItdedPaymTaxFree;
        //    custAccRec.PaymentOutTax        = custAccRecWork.PaymentOutTax;
        //    custAccRec.PaymentInTax         = custAccRecWork.PaymentInTax;
        //    custAccRec.ConsTaxLayMethod     = custAccRecWork.ConsTaxLayMethod;
        //    custAccRec.ConsTaxRate          = custAccRecWork.ConsTaxRate;
        //    custAccRec.FractionProcCd       = custAccRecWork.FractionProcCd;
        //    custAccRec.AfCalTMonthAccRec    = custAccRecWork.AfCalTMonthAccRec;
        //    custAccRec.AcpOdrTtl2TmBfAccRec = custAccRecWork.AcpOdrTtl2TmBfAccRec;
        //    custAccRec.AcpOdrTtl3TmBfAccRec = custAccRecWork.AcpOdrTtl3TmBfAccRec;
        //    custAccRec.MonthAddUpExpDate    = custAccRecWork.MonthAddUpExpDate;

        //    // �e�[�u���X�V
        //    this._custAccRecDic[custAccRecWork.FileHeaderGuid] = custAccRecWork;

        //    return custAccRec;
        //}
        #endregion ********** �s�v **********

        /// <summary>���Ӑ攄�|���z�}�X�^�I�u�W�F�N�g���C��DataSet�W�J����</summary>
        /// <param name="custAccRecWork">���Ӑ攄�|���z�}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ攄�|���z�}�X�^�I�u�W�F�N�g���A���C��DataSet�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.06 >>>
        //private void CustAccRecWorkToDataSet(CustAccRecWork custAccRecWork)
        private void CustAccRecWorkToDataSet(CustAccRecWork custAccRecWork, ArrayList accRecDepoTotalWorkArrayList)
        // 2009.01.06 <<<
        {
            // 2009.01.06 Del >>>
            //// �e���R�[�h�̏ꍇ�͓��Ӑ�R�[�h�ɐ�����R�[�h�Ɠ��l���Đݒ�
            //if (custAccRecWork.CustomerCode == 0) {
            //    custAccRecWork.CustomerCode = custAccRecWork.ClaimCode;
            //}
            // 2009.01.06 Del <<<

            bool newFlg = false;    // �V�K�E�����t���O

            // �X�V�Ώۍs�̎擾
            object[] primryKey = new object[] { custAccRecWork.AddUpSecCode, 
                                                custAccRecWork.ClaimCode,
                                                custAccRecWork.CustomerCode, 
                                                TDateTime.DateTimeToLongDate(custAccRecWork.AddUpDate) };
            DataRow dr = this._custAccRecTable.Rows.Find(primryKey);
            if (dr == null)
            {
                // �V�K�ɍs���쐬
                dr = this._custAccRecTable.NewRow();

                // �V�K���R�[�h�`�F�b�N
                newFlg = true;
            }

            // 2009.01.06 >>>
            // ���ۂ̃f�[�^�Z�b�g�͕ʃ��\�b�h�ōs�����߃R�����g�A�E�g
#if false
            // �폜��
            if (custAccRecWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", custAccRecWork.UpdateDateTime);
            }
            dr[COL_ADDUPSECCODE_TITLE]         = custAccRecWork.AddUpSecCode;                                           // �v�㋒�_�R�[�h
            dr[COL_CUSTOMERCODE_TITLE]         = custAccRecWork.CustomerCode;                                           // ���Ӑ�R�[�h

            dr[COL_CUSTOMERNAME_TITLE]         = custAccRecWork.CustomerName;                                           // ���Ӑ於��
            dr[COL_CUSTOMERNAME2_TITLE]        = custAccRecWork.CustomerName2;                                          // ���Ӑ於��2
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_CUSTOMERSNM_TITLE]          = custAccRecWork.CustomerSnm;                                            // ���Ӑ旪��
            dr[COL_CLAIMCODE_TITLE]            = custAccRecWork.ClaimCode;                                              // ������R�[�h
            dr[COL_CLAIMNAME_TITLE]            = custAccRecWork.ClaimName;                                              // �����於��
            dr[COL_CLAIMNAME2_TITLE]           = custAccRecWork.ClaimName2;                                             // �����於��2
            dr[COL_CLAIMSNM_TITLE]             = custAccRecWork.ClaimSnm;                                               // �����旪��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_ADDUPDATEJP_TITLE]          = TDateTime.DateTimeToString("YYYY/MM/DD", custAccRecWork.AddUpDate);    // �v��N����
            dr[COL_ADDUPYEARMONTHJP_TITLE]     = TDateTime.DateTimeToString("ggYY.MM", custAccRecWork.AddUpYearMonth);  // �v��N��
            dr[COL_ADDUPDATE_TITLE]            = TDateTime.DateTimeToLongDate(custAccRecWork.AddUpDate);                // _�v��N����
            dr[COL_ADDUPYEARMONTH_TITLE]       = TDateTime.DateTimeToLongDate(custAccRecWork.AddUpYearMonth);           // _�v��N��
            dr[COL_LASTTIMEACCREC_TITLE]       = custAccRecWork.LastTimeAccRec;                                         // �O�񔄊|���z
            dr[COL_THISTIMEDMDNRML_TITLE]      = custAccRecWork.ThisTimeDmdNrml;                                        // ����������z�i�ʏ�����j
            dr[COL_THISTIMEFEEDMDNRML_TITLE]   = custAccRecWork.ThisTimeFeeDmdNrml;                                     // ����萔���z�i�ʏ�����j
            dr[COL_THISTIMEDISDMDNRML_TITLE]   = custAccRecWork.ThisTimeDisDmdNrml;                                     // ����l���z�i�ʏ�����j
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISTIMERBTDMDNRML_TITLE]   = custAccRecWork.ThisTimeRbtDmdNrml;                                     // ���񃊃x�[�g�z�i�ʏ�����j
            //dr[COL_THISTIMEDMDDEPO_TITLE]      = custAccRecWork.ThisTimeDmdDepo;                                        // ����������z�i�a����j
            //dr[COL_THISTIMEFEEDMDDEPO_TITLE]   = custAccRecWork.ThisTimeFeeDmdDepo;                                     // ����萔���z�i�a����j
            //dr[COL_THISTIMEDISDMDDEPO_TITLE]   = custAccRecWork.ThisTimeDisDmdDepo;                                     // ����l���z�i�a����j
            //dr[COL_THISTIMERBTDMDDEPO_TITLE]   = custAccRecWork.ThisTimeRbtDmdDepo;                                     // ���񃊃x�[�g�z�i�a����j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISTIMEDEPODMD_TITLE]      = custAccRecWork.ThisTimeDmdNrml    +                                    // ����������z�i�ʏ�����j
            //                                     custAccRecWork.ThisTimeFeeDmdNrml +                                    // ����萔���z�i�ʏ�����j
            //                                     custAccRecWork.ThisTimeDisDmdNrml +                                    // ����l���z�i�ʏ�����j
            //                                     custAccRecWork.ThisTimeRbtDmdNrml +                                    // ���񃊃x�[�g�z�i�ʏ�����j
            //                                     custAccRecWork.ThisTimeDmdDepo    +                                    // ����������z�i�a����j
            //                                     custAccRecWork.ThisTimeFeeDmdDepo +                                    // ����萔���z�i�a����j
            //                                     custAccRecWork.ThisTimeDisDmdDepo +                                    // ����l���z�i�a����j
            //                                     custAccRecWork.ThisTimeRbtDmdDepo;                                     // ���񃊃x�[�g�z�i�a����j
            dr[COL_THISTIMEDEPODMD_TITLE] = custAccRecWork.ThisTimeDmdNrml +                                    // ����������z�i�ʏ�����j
                                                 custAccRecWork.ThisTimeFeeDmdNrml +                                    // ����萔���z�i�ʏ�����j
                                                 custAccRecWork.ThisTimeDisDmdNrml ;                                    // ����l���z�i�ʏ�����j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_THISTIMETTLBLCACC_TITLE]    = custAccRecWork.ThisTimeTtlBlcAcc;                                      // ����J�z�c���i���|�v�j
            dr[COL_THISTIMESALES_TITLE]        = custAccRecWork.ThisTimeSales;                                          // ���񔄏���z
            dr[COL_THISSALESTAX_TITLE]         = custAccRecWork.ThisSalesTax;                                           // ���񔄏�����
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_TTLINCDTBTTAXEXC_TITLE]     = custAccRecWork.TtlIncDtbtTaxExc;                                       // �x���C���Z���e�B�u�z���v�i�Ŕ����j
            //dr[COL_TTLINCDTBTTAX_TITLE]        = custAccRecWork.TtlIncDtbtTax;                                          // �x���C���Z���e�B�u�z���v�i�Łj
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_OFSTHISTIMESALES_TITLE]     = custAccRecWork.OfsThisTimeSales;                                       // ���E�㍡�񔄏���z
            dr[COL_OFSTHISSALESTAX_TITLE]      = custAccRecWork.OfsThisSalesTax;                                        // ���E�㍡�񔄏�����
            dr[COL_ITDEDOFFSETOUTTAX_TITLE]    = custAccRecWork.ItdedOffsetOutTax;                                      // ���E��O�őΏۊz
            dr[COL_ITDEDOFFSETINTAX_TITLE]     = custAccRecWork.ItdedOffsetInTax;                                       // ���E����őΏۊz
            dr[COL_ITDEDOFFSETTAXFREE_TITLE]   = custAccRecWork.ItdedOffsetTaxFree;                                     // ���E���ېőΏۊz
            dr[COL_OFFSETOUTTAX_TITLE]         = custAccRecWork.OffsetOutTax;                                           // ���E��O�ŏ����
            dr[COL_OFFSETINTAX_TITLE]          = custAccRecWork.OffsetInTax;                                            // ���E����ŏ����
            dr[COL_ITDEDSALESOUTTAX_TITLE]     = custAccRecWork.ItdedSalesOutTax;                                       // ����O�őΏۊz
            dr[COL_ITDEDSALESINTAX_TITLE]      = custAccRecWork.ItdedSalesInTax;                                        // ������őΏۊz
            dr[COL_ITDEDSALESTAXFREE_TITLE]    = custAccRecWork.ItdedSalesTaxFree;                                      // �����ېőΏۊz
            dr[COL_SALESOUTTAX_TITLE]          = custAccRecWork.SalesOutTax;                                            // ����O�Ŋz
            dr[COL_SALESINTAX_TITLE]           = custAccRecWork.SalesInTax;                                             // ������Ŋz
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_ITDEDPAYMOUTTAX_TITLE]      = custAccRecWork.ItdedPaymOutTax;                                        // �x���O�őΏۊz
            //dr[COL_ITDEDPAYMINTAX_TITLE]       = custAccRecWork.ItdedPaymInTax;                                         // �x�����őΏۊz
            //dr[COL_ITDEDPAYMTAXFREE_TITLE]     = custAccRecWork.ItdedPaymTaxFree;                                       // �x����ېőΏۊz
            //dr[COL_PAYMENTOUTTAX_TITLE]        = custAccRecWork.PaymentOutTax;                                          // �x���O�ŏ����
            //dr[COL_PAYMENTINTAX_TITLE]         = custAccRecWork.PaymentInTax;                                           // �x�����ŏ����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_TTLITDEDRETOUTTAX_TITLE]    = custAccRecWork.TtlItdedRetOutTax;                                       // �ԕi�O�őΏۊz
            dr[COL_TTLITDEDRETINTAX_TITLE]     = custAccRecWork.TtlItdedRetInTax;                                        // �ԕi���őΏۊz
            dr[COL_TTLITDEDRETTAXFREE_TITLE]   = custAccRecWork.TtlItdedRetTaxFree;                                      // �ԕi��ېőΏۊz
            dr[COL_TTLRETOUTERTAX_TITLE]       = custAccRecWork.TtlRetOuterTax;                                            // �ԕi�O�Ŋz
            dr[COL_TTLRETINNERTAX_TITLE]       = custAccRecWork.TtlRetInnerTax;                                             // �ԕi���Ŋz
            dr[COL_TTLITDEDDISOUTTAX_TITLE]    = custAccRecWork.TtlItdedDisOutTax;                                       // �l���O�őΏۊz
            dr[COL_TTLITDEDDISINTAX_TITLE]     = custAccRecWork.TtlItdedDisInTax;                                        // �l�����őΏۊz
            dr[COL_TTLITDEDDISTAXFREE_TITLE]   = custAccRecWork.TtlItdedDisTaxFree;                                      // �l����ېőΏۊz
            dr[COL_TTLDISOUTERTAX_TITLE]       = custAccRecWork.TtlDisOuterTax;                                            // �l���O�Ŋz
            dr[COL_TTLDISINNERTAX_TITLE]       = custAccRecWork.TtlDisInnerTax;                                             // �l�����Ŋz
            dr[COL_BALANCEADJUST_TITLE] = custAccRecWork.BalanceAdjust;                                          // �c�������z
            dr[COL_TAXADJUST_TITLE] = custAccRecWork.TaxAdjust;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            // �����z(�\���̂�)
            dr[COL_TOTALADJUST_TITLE] = custAccRecWork.BalanceAdjust + custAccRecWork.TaxAdjust;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //dr[COL_NONSTMNTAPPEARANCE_TITLE]   = custAccRecWork.NonStmntAppearance;                                     // �����ϋ��z�i���U�j
            //dr[COL_NONSTMNTISDONE_TITLE]       = custAccRecWork.NonStmntIsdone;                                         // �����ϋ��z�i�􂵁j 
            //dr[COL_STMNTAPPEARANCE_TITLE]      = custAccRecWork.StmntAppearance;                                        // ���ϋ��z�i���U�j
            //dr[COL_STMNTISDONE_TITLE]          = custAccRecWork.StmntIsdone;                                            // ���ϋ��z�i�􂵁j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            //dr[COL_THISCASHSALEPRICE]          = custAccRecWork.ThisCashSalePrice;                                      // ����������z
            //dr[COL_THISCASHSALETAX]            = custAccRecWork.ThisCashSaleTax;                                        // �����������Ŋz
            //dr[COL_SALESSLIPCOUNT]             = 0;                                                                     // �i�`�[�����j
            dr[COL_BILLPRINTDATE_TITLE]              = 0;                                                                     // �i���������s���j
            dr[COL_EXPECTEDDEPOSITDATE_TITLE]        = 0;                                                                     // �i�����\����j
            dr[COL_COLLECTCOND_TITLE]                = 0;                                                                     // �i��������j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_CONSTAXLAYMETHOD_TITLE]     = custAccRecWork.ConsTaxLayMethod;                                       // ����œ]�ŕ���
            dr[COL_CONSTAXRATE_TITLE]          = custAccRecWork.ConsTaxRate;                                            // ����ŗ�
            dr[COL_FRACTIONPROCCD_TITLE]       = custAccRecWork.FractionProcCd;                                         // �[�������敪
            dr[COL_AFCALTMONTHACCREC_TITLE]    = custAccRecWork.AfCalTMonthAccRec;                                      // �v�Z�㓖�����|���z
            //dr[COL_AFCALTMONTHACCREC_TITLE] = custAccRecWork.AfCalTMonthAccRec + custAccRecWork.BalanceAdjust + custAccRecWork.TaxAdjust;  // �v�Z�㓖�����|���z
            dr[COL_ACPODRTTL2TMBFACCREC_TITLE] = custAccRecWork.AcpOdrTtl2TmBfAccRec;                                   // ��2��O�c���i���|�v�j
            dr[COL_ACPODRTTL3TMBFACCREC_TITLE] = custAccRecWork.AcpOdrTtl3TmBfAccRec;                                   // ��3��O�c���i���|�v�j
            dr[COL_MONTHADDUPEXPDATE_TITLE]    = TDateTime.DateTimeToLongDate(custAccRecWork.MonthAddUpExpDate);        // �����X�V���s�N����
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_SALESSLIPCOUNT_TITLE] = custAccRecWork.SalesSlipCount;  // �i�`�[�����j

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //dr[COL_THISPAYOFFSET_TITLE] = custAccRecWork.ThisPayOffset; // ����x�����E���z
            //dr[COL_THISPAYOFFSETTAX_TITLE] = custAccRecWork.ThisPayOffsetTax; // ����x�����E�����
            //dr[COL_ITDEDPAYMOUTTAX_TITLE] = custAccRecWork.ItdedPaymOutTax; // �x���O�őΏۊz
            //dr[COL_ITDEDPAYMINTAX_TITLE] = custAccRecWork.ItdedPaymInTax; // �x�����őΏۊz
            //dr[COL_ITDEDPAYMTAXFREE_TITLE] = custAccRecWork.ItdedPaymTaxFree; // �x����ېőΏۊz
            //dr[COL_PAYMENTOUTTAX_TITLE] = custAccRecWork.PaymentOutTax; // �x���O�ŏ����
            //dr[COL_PAYMENTINTAX_TITLE] = custAccRecWork.PaymentInTax; // �x�����ŏ����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
            dr[COL_TAXADJUST_TITLE] = custAccRecWork.TaxAdjust; // ����Œ����z
            //dr[COL_TAXADJUST_TITLE] = custAccRecWork.TaxAdjust + custAccRecWork.BalanceAdjust; // ����Œ����z + �c�������z
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_GUID_TITLE]                 = custAccRecWork.FileHeaderGuid;                                         // GUID
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_CREATEDATETIME] = custAccRecWork.CreateDateTime; // �쐬����
            dr[COL_UPDATEDATETIME] = custAccRecWork.UpdateDateTime; // �X�V����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
#endif
            this.DataRowFromParamData(ref dr, custAccRecWork, accRecDepoTotalWorkArrayList);
            // 2009.01.06 <<<

            // �V�K���R�[�h�̏ꍇ�̂�
            if (newFlg == true)
            {
                // �V�K�s�̒ǉ�
                this._custAccRecTable.Rows.Add(dr);
            }

            // �e�[�u���Ɋi�[
            if (this._custAccRecDic.ContainsKey(custAccRecWork.FileHeaderGuid) == true)
            {
                this._custAccRecDic.Remove(custAccRecWork.FileHeaderGuid);
            }
            this._custAccRecDic.Add(custAccRecWork.FileHeaderGuid, custAccRecWork);
        }

        /// <summary>���Ӑ搿�����z�}�X�^�I�u�W�F�N�g���C��DataSet�W�J����</summary>
        /// <param name="custDmdPrcWork">���Ӑ搿�����z�}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ搿�����z�}�X�^�I�u�W�F�N�g���A���C��DataSet�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.06 >>>
        //private void CustDmdPrcWorkToDataSet(CustDmdPrcWork custDmdPrcWork)
        private void CustDmdPrcWorkToDataSet(CustDmdPrcWork custDmdPrcWork, ArrayList dmdDepoTotalWorkArrayList)
        // 2009.01.06 <<<
        {
            // 2009.01.06 Del >>>
            //// �e���R�[�h�̏ꍇ�͓��Ӑ�R�[�h�ɐ�����R�[�h�Ɠ��l���Đݒ�
            //if ( custDmdPrcWork.CustomerCode == 0 ) {
            //    custDmdPrcWork.CustomerCode = custDmdPrcWork.ClaimCode;
            //}
            // 2009.01.06 Del <<<


            bool newFlg = false;    // �V�K�E�����t���O

            // �X�V�Ώۍs�̎擾
            object[] primryKey = new object[] { custDmdPrcWork.AddUpSecCode,
                                                custDmdPrcWork.ClaimCode,
                                                custDmdPrcWork.CustomerCode, 
                                                custDmdPrcWork.ResultsSectCd, //���ы��_�R�[�h
                                                TDateTime.DateTimeToLongDate(custDmdPrcWork.AddUpDate) };
            DataRow dr = this._custDmdPrcTable.Rows.Find(primryKey);
            if (dr == null)
            {
                // �V�K�ɍs���쐬
                dr = this._custDmdPrcTable.NewRow();

                // �V�K���R�[�h�`�F�b�N
                newFlg = true;
            }

            // 2009.01.06 >>>

            // ���ۂ̃f�[�^�Z�b�g�͕ʃ��\�b�h�ōs�����߃R�����g�A�E�g
#if false
            // �폜��
            if (custDmdPrcWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", custDmdPrcWork.UpdateDateTime);
            }
            dr[COL_ADDUPSECCODE_TITLE]         = custDmdPrcWork.AddUpSecCode;                                           // �v�㋒�_�R�[�h

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA ADD START
            dr[COL_RESULTSECCODE_TITLE]        = custDmdPrcWork.ResultsSectCd;                                          // ���ы��_�R�[�h
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA ADD END

            dr[COL_CUSTOMERCODE_TITLE]         = custDmdPrcWork.CustomerCode;                                           // ���Ӑ�R�[�h
            dr[COL_CUSTOMERNAME_TITLE]         = custDmdPrcWork.CustomerName;                                           // ���Ӑ於��
            dr[COL_CUSTOMERNAME2_TITLE]        = custDmdPrcWork.CustomerName2;                                          // ���Ӑ於��2
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_CUSTOMERSNM_TITLE]          = custDmdPrcWork.CustomerSnm;                                            // ���Ӑ旪��
            dr[COL_CLAIMCODE_TITLE]            = custDmdPrcWork.ClaimCode;                                              // ���Ӑ�R�[�h
            dr[COL_CLAIMNAME_TITLE]            = custDmdPrcWork.ClaimName;                                              // ���Ӑ於��
            dr[COL_CLAIMNAME2_TITLE]           = custDmdPrcWork.ClaimName2;                                             // ���Ӑ於��2
            dr[COL_CLAIMSNM_TITLE]             = custDmdPrcWork.ClaimSnm;                                               // ���Ӑ旪��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_ADDUPDATEJP_TITLE] = TDateTime.DateTimeToString("YYYY/MM/DD", custDmdPrcWork.AddUpDate);    // �v��N����
            dr[COL_ADDUPYEARMONTHJP_TITLE]     = TDateTime.DateTimeToString("ggYY.MM", custDmdPrcWork.AddUpYearMonth);  // �v��N��
            dr[COL_ADDUPDATE_TITLE]            = TDateTime.DateTimeToLongDate(custDmdPrcWork.AddUpDate);                // _�v��N����
            dr[COL_ADDUPYEARMONTH_TITLE]       = TDateTime.DateTimeToLongDate(custDmdPrcWork.AddUpYearMonth);           // _�v��N��
            dr[COL_LASTTIMEDEMAND_TITLE]       = custDmdPrcWork.LastTimeDemand;                                         // �O�񐿋����z
            dr[COL_THISTIMEDMDNRML_TITLE]      = custDmdPrcWork.ThisTimeDmdNrml;                                        // ����������z�i�ʏ�����j
            dr[COL_THISTIMEFEEDMDNRML_TITLE]   = custDmdPrcWork.ThisTimeFeeDmdNrml;                                     // ����萔���z�i�ʏ�����j
            dr[COL_THISTIMEDISDMDNRML_TITLE]   = custDmdPrcWork.ThisTimeDisDmdNrml;                                     // ����l���z�i�ʏ�����j
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISTIMERBTDMDNRML_TITLE]   = custDmdPrcWork.ThisTimeRbtDmdNrml;                                     // ���񃊃x�[�g�z�i�ʏ�����j
            //dr[COL_THISTIMEDMDDEPO_TITLE]      = custDmdPrcWork.ThisTimeDmdDepo;                                        // ����������z�i�a����j
            //dr[COL_THISTIMEFEEDMDDEPO_TITLE]   = custDmdPrcWork.ThisTimeFeeDmdDepo;                                     // ����萔���z�i�a����j
            //dr[COL_THISTIMEDISDMDDEPO_TITLE]   = custDmdPrcWork.ThisTimeDisDmdDepo;                                     // ����l���z�i�a����j
            //dr[COL_THISTIMERBTDMDDEPO_TITLE]   = custDmdPrcWork.ThisTimeRbtDmdDepo;                                     // ���񃊃x�[�g�z�i�a����j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISTIMEDEPODMD_TITLE]      = custDmdPrcWork.ThisTimeDmdNrml    +                                    // ����������z�i�ʏ�����j
            //                                     custDmdPrcWork.ThisTimeFeeDmdNrml +                                    // ����萔���z�i�ʏ�����j
            //                                     custDmdPrcWork.ThisTimeDisDmdNrml +                                    // ����l���z�i�ʏ�����j
            //                                     custDmdPrcWork.ThisTimeRbtDmdNrml +                                    // ���񃊃x�[�g�z�i�ʏ�����j
            //                                     custDmdPrcWork.ThisTimeDmdDepo    +                                    // ����������z�i�a����j
            //                                     custDmdPrcWork.ThisTimeFeeDmdDepo +                                    // ����萔���z�i�a����j
            //                                     custDmdPrcWork.ThisTimeDisDmdDepo +                                    // ����l���z�i�a����j
            //                                     custDmdPrcWork.ThisTimeRbtDmdDepo;                                     // ���񃊃x�[�g�z�i�a����j
            dr[COL_THISTIMEDEPODMD_TITLE] = custDmdPrcWork.ThisTimeDmdNrml +                                    // ����������z�i�ʏ�����j
                                                 custDmdPrcWork.ThisTimeFeeDmdNrml +                                    // ����萔���z�i�ʏ�����j
                                                 custDmdPrcWork.ThisTimeDisDmdNrml ;                                    // ����l���z�i�ʏ�����j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_THISTIMETTLBLCDMD_TITLE]    = custDmdPrcWork.ThisTimeTtlBlcDmd;                                      // ����J�z�c���i�����v�j
            dr[COL_THISTIMESALES_TITLE]        = custDmdPrcWork.ThisTimeSales;                                          // ���񔄏���z
            dr[COL_THISSALESTAX_TITLE]         = custDmdPrcWork.ThisSalesTax;                                           // ���񔄏�����
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_TTLINCDTBTTAXEXC_TITLE]     = custDmdPrcWork.TtlIncDtbtTaxExc;                                       // �x���C���Z���e�B�u�z���v�i�Ŕ����j
            //dr[COL_TTLINCDTBTTAX_TITLE]        = custDmdPrcWork.TtlIncDtbtTax;                                          // �x���C���Z���e�B�u�z���v�i�Łj
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_OFSTHISTIMESALES_TITLE]     = custDmdPrcWork.OfsThisTimeSales;                                       // ���E�㍡�񔄏���z
            dr[COL_OFSTHISSALESTAX_TITLE]      = custDmdPrcWork.OfsThisSalesTax;                                        // ���E�㍡�񔄏�����
            dr[COL_ITDEDOFFSETOUTTAX_TITLE]    = custDmdPrcWork.ItdedOffsetOutTax;                                      // ���E��O�őΏۊz
            dr[COL_ITDEDOFFSETINTAX_TITLE]     = custDmdPrcWork.ItdedOffsetInTax;                                       // ���E����őΏۊz
            dr[COL_ITDEDOFFSETTAXFREE_TITLE]   = custDmdPrcWork.ItdedOffsetTaxFree;                                     // ���E���ېőΏۊz
            dr[COL_OFFSETOUTTAX_TITLE]         = custDmdPrcWork.OffsetOutTax;                                           // ���E��O�ŏ����
            dr[COL_OFFSETINTAX_TITLE]          = custDmdPrcWork.OffsetInTax;                                            // ���E����ŏ����
            dr[COL_ITDEDSALESOUTTAX_TITLE]     = custDmdPrcWork.ItdedSalesOutTax;                                       // ����O�őΏۊz
            dr[COL_ITDEDSALESINTAX_TITLE]      = custDmdPrcWork.ItdedSalesInTax;                                        // ������őΏۊz
            dr[COL_ITDEDSALESTAXFREE_TITLE]    = custDmdPrcWork.ItdedSalesTaxFree;                                      // �����ېőΏۊz
            dr[COL_SALESOUTTAX_TITLE]          = custDmdPrcWork.SalesOutTax;                                            // ����O�Ŋz
            dr[COL_SALESINTAX_TITLE]           = custDmdPrcWork.SalesInTax;                                             // ������Ŋz
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_ITDEDPAYMOUTTAX_TITLE]      = custDmdPrcWork.ItdedPaymOutTax;                                        // �x���O�őΏۊz
            //dr[COL_ITDEDPAYMINTAX_TITLE]       = custDmdPrcWork.ItdedPaymInTax;                                         // �x�����őΏۊz
            //dr[COL_ITDEDPAYMTAXFREE_TITLE]     = custDmdPrcWork.ItdedPaymTaxFree;                                       // �x����ېőΏۊz
            //dr[COL_PAYMENTOUTTAX_TITLE]        = custDmdPrcWork.PaymentOutTax;                                          // �x���O�ŏ����
            //dr[COL_PAYMENTINTAX_TITLE]         = custDmdPrcWork.PaymentInTax;                                           // �x�����ŏ����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_TTLITDEDRETOUTTAX_TITLE]    = custDmdPrcWork.TtlItdedRetOutTax;                                       // �ԕi�O�őΏۊz
            dr[COL_TTLITDEDRETINTAX_TITLE]     = custDmdPrcWork.TtlItdedRetInTax;                                        // �ԕi���őΏۊz
            dr[COL_TTLITDEDRETTAXFREE_TITLE]   = custDmdPrcWork.TtlItdedRetTaxFree;                                      // �ԕi��ېőΏۊz
            dr[COL_TTLRETOUTERTAX_TITLE]       = custDmdPrcWork.TtlRetOuterTax;                                            // �ԕi�O�Ŋz
            dr[COL_TTLRETINNERTAX_TITLE]       = custDmdPrcWork.TtlRetInnerTax;                                             // �ԕi���Ŋz
            dr[COL_TTLITDEDDISOUTTAX_TITLE]    = custDmdPrcWork.TtlItdedDisOutTax;                                       // �l���O�őΏۊz
            dr[COL_TTLITDEDDISINTAX_TITLE]     = custDmdPrcWork.TtlItdedDisInTax;                                        // �l�����őΏۊz
            dr[COL_TTLITDEDDISTAXFREE_TITLE]   = custDmdPrcWork.TtlItdedDisTaxFree;                                      // �l����ېőΏۊz
            dr[COL_TTLDISOUTERTAX_TITLE]       = custDmdPrcWork.TtlDisOuterTax;                                            // �l���O�Ŋz
            dr[COL_TTLDISINNERTAX_TITLE]       = custDmdPrcWork.TtlDisInnerTax;                                             // �l�����Ŋz

            dr[COL_BALANCEADJUST_TITLE] = custDmdPrcWork.BalanceAdjust;                          // �c�������z
            dr[COL_TAXADJUST_TITLE] = custDmdPrcWork.TaxAdjust;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            // �����z(�W���p�̂�)
            dr[COL_TOTALADJUST_TITLE] = custDmdPrcWork.BalanceAdjust + custDmdPrcWork.TaxAdjust;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            dr[COL_NONSTMNTAPPEARANCE_TITLE]   = 0;                                                                     // �����ϋ��z�i���U�j
            dr[COL_NONSTMNTISDONE_TITLE]       = 0;                                                                     // �����ϋ��z�i�􂵁j 
            dr[COL_STMNTAPPEARANCE_TITLE]      = 0;                                                                     // ���ϋ��z�i���U�j
            dr[COL_STMNTISDONE_TITLE]          = 0;                                                                     // ���ϋ��z�i�􂵁j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            //dr[COL_THISCASHSALEPRICE]          = 0;                                                                     // ����������z
            //dr[COL_THISCASHSALETAX]            = 0;                                                                     // �����������Ŋz
            dr[COL_SALESSLIPCOUNT_TITLE]             = custDmdPrcWork.SalesSlipCount;                                         // �`�[����
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_BILLPRINTDATE_TITLE] = custDmdPrcWork.BillPrintDate;                                          // ���������s��
            dr[COL_BILLPRINTDATE_TITLE] = TDateTime.DateTimeToLongDate( custDmdPrcWork.BillPrintDate );                                          // ���������s��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki            
            dr[COL_EXPECTEDDEPOSITDATE_TITLE]        = TDateTime.DateTimeToLongDate(custDmdPrcWork.ExpectedDepositDate);      // �����\���
            dr[COL_COLLECTCOND_TITLE]                = custDmdPrcWork.CollectCond;                                            // �������
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_CONSTAXLAYMETHOD_TITLE]     = custDmdPrcWork.ConsTaxLayMethod;                                       // ����œ]�ŕ���
            dr[COL_CONSTAXRATE_TITLE]          = custDmdPrcWork.ConsTaxRate;                                            // ����ŗ�
            dr[COL_FRACTIONPROCCD_TITLE]       = custDmdPrcWork.FractionProcCd;                                         // �[�������敪
            dr[COL_AFCALDEMANDPRICE_TITLE]     = custDmdPrcWork.AfCalDemandPrice;                                       // �v�Z�㐿�����z
            //dr[COL_AFCALDEMANDPRICE_TITLE] = custDmdPrcWork.AfCalDemandPrice + custDmdPrcWork.BalanceAdjust + custDmdPrcWork.TaxAdjust;     // �v�Z�㐿�����z
            dr[COL_ACPODRTTL2TMBFBLDMD_TITLE]  = custDmdPrcWork.AcpOdrTtl2TmBfBlDmd;                                    // ��2��O�c���i�����v�j
            dr[COL_ACPODRTTL3TMBFBLDMD_TITLE]  = custDmdPrcWork.AcpOdrTtl3TmBfBlDmd;                                    // ��3��O�c���i�����v�j
            dr[COL_CADDUPUPDEXECDATE_TITLE]    = TDateTime.DateTimeToLongDate(custDmdPrcWork.CAddUpUpdExecDate);        // �����X�V���s�N����
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_DMDPROCNUM_TITLE]           = custDmdPrcWork.DmdProcNum;                                             // ���������ʔ�
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END
            //dr[COL_THISPAYOFFSET_TITLE] = custDmdPrcWork.ThisPayOffset; // ����x�����E���z
            //dr[COL_THISPAYOFFSETTAX_TITLE] = custDmdPrcWork.ThisPayOffsetTax; // ����x�����E�����
            //dr[COL_ITDEDPAYMOUTTAX_TITLE] = custDmdPrcWork.ItdedPaymOutTax; // �x���O�őΏۊz
            //dr[COL_ITDEDPAYMINTAX_TITLE] = custDmdPrcWork.ItdedPaymInTax; // �x�����őΏۊz
            //dr[COL_ITDEDPAYMTAXFREE_TITLE] = custDmdPrcWork.ItdedPaymTaxFree; // �x����ېőΏۊz
            //dr[COL_PAYMENTOUTTAX_TITLE] = custDmdPrcWork.PaymentOutTax; // �x���O�ŏ����
            //dr[COL_PAYMENTINTAX_TITLE] = custDmdPrcWork.PaymentInTax; // �x�����ŏ����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END
            dr[COL_TAXADJUST_TITLE] = custDmdPrcWork.TaxAdjust; // ����Œ����z
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_GUID_TITLE]                 = custDmdPrcWork.FileHeaderGuid;                                         // GUID
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_CREATEDATETIME] = custDmdPrcWork.CreateDateTime; // �쐬����
            dr[COL_UPDATEDATETIME] = custDmdPrcWork.UpdateDateTime; // �X�V����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
#endif
            this.DataRowFromParamData(ref dr, custDmdPrcWork, dmdDepoTotalWorkArrayList);

            // 2009.01.06 <<<

            // �V�K���R�[�h�̏ꍇ�̂�
            if (newFlg == true)
            {
                // �V�K�s�̒ǉ�
                this._custDmdPrcTable.Rows.Add(dr);
            }

            // �e�[�u���Ɋi�[
            if (this._custDmdPrcDic.ContainsKey(custDmdPrcWork.FileHeaderGuid) == true)
            {
                this._custDmdPrcDic.Remove(custDmdPrcWork.FileHeaderGuid);
            }
            this._custDmdPrcDic.Add(custDmdPrcWork.FileHeaderGuid, custDmdPrcWork);
        }

        // 2009.01.06 Add >>>
        /// <summary>
        /// ���Ӑ攄�|���z�}�X�^�I�u�W�F�N�g(�W�v���R�[�h)���C��DataSet�W�J����
        /// </summary>
        /// <param name="custAccRecWork">���Ӑ攄�|���z�}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ攄�|���z�}�X�^�I�u�W�F�N�g���A���C��DataSet�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private void CustAccRecWorkTotalToDataSet(CustAccRecWork custAccRecWork, ArrayList accRecDepoTotalWorkArrayList)
        {
            try
            {
                this._custAccRecTotalTable.BeginLoadData();
                // �X�V�Ώۍs�̎擾
                object[] primryKey = new object[] { custAccRecWork.AddUpSecCode, 
                                                custAccRecWork.ClaimCode,
                                                custAccRecWork.CustomerCode, 
                                                TDateTime.DateTimeToLongDate(custAccRecWork.AddUpDate) };
                DataRow dr = this._custAccRecTotalTable.Rows.Find(primryKey);
                if (dr == null)
                {
                    // �V�K�ɍs���쐬�E�ǉ�
                    dr = this._custAccRecTotalTable.NewRow();
                    this._custAccRecTotalTable.Rows.Add(dr);
                }
                this.DataRowFromParamData(ref dr, custAccRecWork, accRecDepoTotalWorkArrayList);
            }
            finally
            {
                this._custAccRecTotalTable.EndLoadData();
            }
        }

        /// <summary>
        /// ���|���z�}�X�^���[�N�A���|�����W�v�f�[�^���[�N��DataRow�ڍ�����
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="custAccRecWork"></param>
        /// <param name="accRecDepoTotalArrayList"></param>
        private void DataRowFromParamData(ref DataRow dr, CustAccRecWork custAccRecWork, ArrayList accRecDepoTotalArrayList)
        {
            // �폜��
            if (custAccRecWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", custAccRecWork.UpdateDateTime);
            }
            dr[COL_ADDUPSECCODE_TITLE] = custAccRecWork.AddUpSecCode;                                               // �v�㋒�_�R�[�h
            dr[COL_CUSTOMERCODE_TITLE] = custAccRecWork.CustomerCode;                                               // ���Ӑ�R�[�h

            dr[COL_CUSTOMERNAME_TITLE] = custAccRecWork.CustomerName;                                               // ���Ӑ於��
            dr[COL_CUSTOMERNAME2_TITLE] = custAccRecWork.CustomerName2;                                             // ���Ӑ於��2
            dr[COL_CUSTOMERSNM_TITLE] = custAccRecWork.CustomerSnm;                                                 // ���Ӑ旪��
            dr[COL_CLAIMCODE_TITLE] = custAccRecWork.ClaimCode;                                                     // ������R�[�h
            dr[COL_CLAIMNAME_TITLE] = custAccRecWork.ClaimName;                                                     // �����於��
            dr[COL_CLAIMNAME2_TITLE] = custAccRecWork.ClaimName2;                                                   // �����於��2
            dr[COL_CLAIMSNM_TITLE] = custAccRecWork.ClaimSnm;                                                       // �����旪��
            dr[COL_ADDUPDATEJP_TITLE] = TDateTime.DateTimeToString("YYYY/MM/DD", custAccRecWork.AddUpDate);         // �v��N����
            dr[COL_ADDUPYEARMONTHJP_TITLE] = TDateTime.DateTimeToString("ggYY.MM", custAccRecWork.AddUpYearMonth);  // �v��N��
            dr[COL_ADDUPDATE_TITLE] = TDateTime.DateTimeToLongDate(custAccRecWork.AddUpDate);                       // _�v��N����
            dr[COL_ADDUPYEARMONTH_TITLE] = TDateTime.DateTimeToLongDate(custAccRecWork.AddUpYearMonth);             // _�v��N��
            dr[COL_LASTTIMEACCREC_TITLE] = custAccRecWork.LastTimeAccRec;                                           // �O�񔄊|���z
            dr[COL_THISTIMEDMDNRML_TITLE] = custAccRecWork.ThisTimeDmdNrml;                                         // ����������z�i�ʏ�����j
            dr[COL_THISTIMEFEEDMDNRML_TITLE] = custAccRecWork.ThisTimeFeeDmdNrml;                                   // ����萔���z�i�ʏ�����j
            dr[COL_THISTIMEDISDMDNRML_TITLE] = custAccRecWork.ThisTimeDisDmdNrml;                                   // ����l���z�i�ʏ�����j
            dr[COL_THISTIMEDEPODMD_TITLE] = custAccRecWork.ThisTimeDmdNrml;                                         // ����������z�i�ʏ�����j

            dr[COL_THISTIMETTLBLCACC_TITLE] = custAccRecWork.ThisTimeTtlBlcAcc;                                     // ����J�z�c���i���|�v�j
            dr[COL_THISTIMESALES_TITLE] = custAccRecWork.ThisTimeSales;                                             // ���񔄏���z
            dr[COL_THISSALESTAX_TITLE] = custAccRecWork.ThisSalesTax;                                               // ���񔄏�����
            dr[COL_OFSTHISTIMESALES_TITLE] = custAccRecWork.OfsThisTimeSales;                                       // ���E�㍡�񔄏���z
            dr[COL_OFSTHISSALESTAX_TITLE] = custAccRecWork.OfsThisSalesTax;                                         // ���E�㍡�񔄏�����
            dr[COL_ITDEDOFFSETOUTTAX_TITLE] = custAccRecWork.ItdedOffsetOutTax;                                     // ���E��O�őΏۊz
            dr[COL_ITDEDOFFSETINTAX_TITLE] = custAccRecWork.ItdedOffsetInTax;                                       // ���E����őΏۊz
            dr[COL_ITDEDOFFSETTAXFREE_TITLE] = custAccRecWork.ItdedOffsetTaxFree;                                   // ���E���ېőΏۊz
            dr[COL_OFFSETOUTTAX_TITLE] = custAccRecWork.OffsetOutTax;                                               // ���E��O�ŏ����
            dr[COL_OFFSETINTAX_TITLE] = custAccRecWork.OffsetInTax;                                                 // ���E����ŏ����
            dr[COL_ITDEDSALESOUTTAX_TITLE] = custAccRecWork.ItdedSalesOutTax;                                       // ����O�őΏۊz
            dr[COL_ITDEDSALESINTAX_TITLE] = custAccRecWork.ItdedSalesInTax;                                         // ������őΏۊz
            dr[COL_ITDEDSALESTAXFREE_TITLE] = custAccRecWork.ItdedSalesTaxFree;                                     // �����ېőΏۊz
            dr[COL_SALESOUTTAX_TITLE] = custAccRecWork.SalesOutTax;                                                 // ����O�Ŋz
            dr[COL_SALESINTAX_TITLE] = custAccRecWork.SalesInTax;                                                   // ������Ŋz
            dr[COL_TTLITDEDRETOUTTAX_TITLE] = custAccRecWork.TtlItdedRetOutTax;                                     // �ԕi�O�őΏۊz
            dr[COL_TTLITDEDRETINTAX_TITLE] = custAccRecWork.TtlItdedRetInTax;                                       // �ԕi���őΏۊz
            dr[COL_TTLITDEDRETTAXFREE_TITLE] = custAccRecWork.TtlItdedRetTaxFree;                                   // �ԕi��ېőΏۊz
            dr[COL_TTLRETOUTERTAX_TITLE] = custAccRecWork.TtlRetOuterTax;                                           // �ԕi�O�Ŋz
            dr[COL_TTLRETINNERTAX_TITLE] = custAccRecWork.TtlRetInnerTax;                                           // �ԕi���Ŋz
            dr[COL_TTLITDEDDISOUTTAX_TITLE] = custAccRecWork.TtlItdedDisOutTax;                                     // �l���O�őΏۊz
            dr[COL_TTLITDEDDISINTAX_TITLE] = custAccRecWork.TtlItdedDisInTax;                                       // �l�����őΏۊz
            dr[COL_TTLITDEDDISTAXFREE_TITLE] = custAccRecWork.TtlItdedDisTaxFree;                                   // �l����ېőΏۊz
            dr[COL_TTLDISOUTERTAX_TITLE] = custAccRecWork.TtlDisOuterTax;                                           // �l���O�Ŋz
            dr[COL_TTLDISINNERTAX_TITLE] = custAccRecWork.TtlDisInnerTax;                                           // �l�����Ŋz
            dr[COL_BALANCEADJUST_TITLE] = custAccRecWork.BalanceAdjust;                                             // �c�������z
            dr[COL_TAXADJUST_TITLE] = custAccRecWork.TaxAdjust;

            // �����z(�\���̂�)
            dr[COL_TOTALADJUST_TITLE] = custAccRecWork.BalanceAdjust + custAccRecWork.TaxAdjust;

            dr[COL_BILLPRINTDATE_TITLE] = 0;                                                                        // �i���������s���j
            dr[COL_EXPECTEDDEPOSITDATE_TITLE] = 0;                                                                  // �i�����\����j
            dr[COL_COLLECTCOND_TITLE] = 0;                                                                          // �i��������j
            dr[COL_CONSTAXLAYMETHOD_TITLE] = custAccRecWork.ConsTaxLayMethod;                                       // ����œ]�ŕ���
            dr[COL_CONSTAXRATE_TITLE] = custAccRecWork.ConsTaxRate;                                                 // ����ŗ�
            dr[COL_FRACTIONPROCCD_TITLE] = custAccRecWork.FractionProcCd;                                           // �[�������敪
            dr[COL_AFCALTMONTHACCREC_TITLE] = custAccRecWork.AfCalTMonthAccRec;                                     // �v�Z�㓖�����|���z
            dr[COL_ACPODRTTL2TMBFACCREC_TITLE] = custAccRecWork.AcpOdrTtl2TmBfAccRec;                               // ��2��O�c���i���|�v�j
            dr[COL_ACPODRTTL3TMBFACCREC_TITLE] = custAccRecWork.AcpOdrTtl3TmBfAccRec;                               // ��3��O�c���i���|�v�j
            dr[COL_MONTHADDUPEXPDATE_TITLE] = TDateTime.DateTimeToLongDate(custAccRecWork.MonthAddUpExpDate);       // �����X�V���s�N����
            dr[COL_STMONCADDUPUPDDATE_TITLE] = TDateTime.DateTimeToLongDate(custAccRecWork.StMonCAddUpUpdDate);     // �����X�V�J�n�N����
            dr[COL_LAMONCADDUPUPDDATE_TITLE] = TDateTime.DateTimeToLongDate(custAccRecWork.LaMonCAddUpUpdDate);     // �O�񌎎��X�V�N����
            dr[COL_SALESSLIPCOUNT_TITLE] = custAccRecWork.SalesSlipCount;                                           // �i�`�[�����j

            dr[COL_TAXADJUST_TITLE] = custAccRecWork.TaxAdjust;                                                     // ����Œ����z

            dr[COL_GUID_TITLE] = custAccRecWork.FileHeaderGuid;                                                     // GUID
            dr[COL_CREATEDATETIME] = custAccRecWork.CreateDateTime;                                                 // �쐬����
            dr[COL_UPDATEDATETIME] = custAccRecWork.UpdateDateTime;                                                 // �X�V����



            List<AccRecDepoTotal> accRecDepoTotalList = new List<AccRecDepoTotal>();
            if (accRecDepoTotalArrayList != null)
            {
                foreach (AccRecDepoTotalWork accRecDepoTotalWork in accRecDepoTotalArrayList)
                {
                    accRecDepoTotalList.Add(UIDataFromParamData(accRecDepoTotalWork));
                }
            }
            dr[COL_DEPOTOTAL] = accRecDepoTotalList;
        }

        /// <summary>
        /// ���Ӑ搿�����z�}�X�^�I�u�W�F�N�g(�W�v���R�[�h)���C��DataSet�W�J����
        /// </summary>
        /// <param name="custDmdPrcWork">���Ӑ搿�����z�}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ搿�����z�}�X�^�I�u�W�F�N�g���A���C��DataSet�Ɋi�[���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2009.01.06</br>
        /// </remarks>
        private void CustDmdPrcWorkTotalToDataSet(CustDmdPrcWork custDmdPrcWork, ArrayList dmdDepoTotalWorkArrayList)
        {

            try
            {
                this._custDmdPrcTotalTable.BeginLoadData();
                // �X�V�Ώۍs�̎擾
                object[] primryKey = new object[] { custDmdPrcWork.AddUpSecCode,
                                                custDmdPrcWork.ClaimCode,
                                                custDmdPrcWork.CustomerCode, 
                                                custDmdPrcWork.ResultsSectCd, //���ы��_�R�[�h
                                                TDateTime.DateTimeToLongDate(custDmdPrcWork.AddUpDate) };
                DataRow dr = this._custDmdPrcTotalTable.Rows.Find(primryKey);


                if (dr == null)
                {
                    // �V�K�ɍs���쐬�E�ǉ�
                    dr = this._custDmdPrcTotalTable.NewRow();
                    this._custDmdPrcTotalTable.Rows.Add(dr);
                }

                this.DataRowFromParamData(ref dr, custDmdPrcWork, dmdDepoTotalWorkArrayList);
            }
            finally
            {
                this._custDmdPrcTotalTable.EndLoadData();
            }
        }

        /// <summary>
        /// �������z�}�X�^���[�N�A���������W�v�f�[�^���[�N��DataRow�ڍ�����
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="custDmdPrcWork"></param>
        /// <param name="dmdDepoTotalArrayList"></param>
        private void DataRowFromParamData(ref DataRow dr, CustDmdPrcWork custDmdPrcWork, ArrayList dmdDepoTotalArrayList)
        {
            // �폜��
            if (custDmdPrcWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", custDmdPrcWork.UpdateDateTime);
            }
            dr[COL_ADDUPSECCODE_TITLE] = custDmdPrcWork.AddUpSecCode;                                               // �v�㋒�_�R�[�h

            dr[COL_RESULTSECCODE_TITLE] = custDmdPrcWork.ResultsSectCd;                                             // ���ы��_�R�[�h

            dr[COL_CUSTOMERCODE_TITLE] = custDmdPrcWork.CustomerCode;                                               // ���Ӑ�R�[�h
            dr[COL_CUSTOMERNAME_TITLE] = custDmdPrcWork.CustomerName;                                               // ���Ӑ於��
            dr[COL_CUSTOMERNAME2_TITLE] = custDmdPrcWork.CustomerName2;                                             // ���Ӑ於��2
            dr[COL_CUSTOMERSNM_TITLE] = custDmdPrcWork.CustomerSnm;                                                 // ���Ӑ旪��
            dr[COL_CLAIMCODE_TITLE] = custDmdPrcWork.ClaimCode;                                                     // ���Ӑ�R�[�h
            dr[COL_CLAIMNAME_TITLE] = custDmdPrcWork.ClaimName;                                                     // ���Ӑ於��
            dr[COL_CLAIMNAME2_TITLE] = custDmdPrcWork.ClaimName2;                                                   // ���Ӑ於��2
            dr[COL_CLAIMSNM_TITLE] = custDmdPrcWork.ClaimSnm;                                                       // ���Ӑ旪��
            dr[COL_ADDUPDATEJP_TITLE] = TDateTime.DateTimeToString("YYYY/MM/DD", custDmdPrcWork.AddUpDate);         // �v��N����
            dr[COL_ADDUPYEARMONTHJP_TITLE] = TDateTime.DateTimeToString("ggYY.MM", custDmdPrcWork.AddUpYearMonth);  // �v��N��
            dr[COL_ADDUPDATE_TITLE] = TDateTime.DateTimeToLongDate(custDmdPrcWork.AddUpDate);                       // _�v��N����
            dr[COL_ADDUPYEARMONTH_TITLE] = TDateTime.DateTimeToLongDate(custDmdPrcWork.AddUpYearMonth);             // _�v��N��
            dr[COL_LASTTIMEDEMAND_TITLE] = custDmdPrcWork.LastTimeDemand;                                           // �O�񐿋����z
            dr[COL_THISTIMEDMDNRML_TITLE] = custDmdPrcWork.ThisTimeDmdNrml;                                         // ����������z�i�ʏ�����j
            dr[COL_THISTIMEFEEDMDNRML_TITLE] = custDmdPrcWork.ThisTimeFeeDmdNrml;                                   // ����萔���z�i�ʏ�����j
            dr[COL_THISTIMEDISDMDNRML_TITLE] = custDmdPrcWork.ThisTimeDisDmdNrml;                                   // ����l���z�i�ʏ�����j
            dr[COL_THISTIMEDEPODMD_TITLE] = custDmdPrcWork.ThisTimeDmdNrml;                                         // ����������z�i�ʏ�����j
            dr[COL_THISTIMETTLBLCDMD_TITLE] = custDmdPrcWork.ThisTimeTtlBlcDmd;                                     // ����J�z�c���i�����v�j
            dr[COL_THISTIMESALES_TITLE] = custDmdPrcWork.ThisTimeSales;                                             // ���񔄏���z
            dr[COL_THISSALESTAX_TITLE] = custDmdPrcWork.ThisSalesTax;                                               // ���񔄏�����
            dr[COL_OFSTHISTIMESALES_TITLE] = custDmdPrcWork.OfsThisTimeSales;                                       // ���E�㍡�񔄏���z
            dr[COL_OFSTHISSALESTAX_TITLE] = custDmdPrcWork.OfsThisSalesTax;                                         // ���E�㍡�񔄏�����
            dr[COL_ITDEDOFFSETOUTTAX_TITLE] = custDmdPrcWork.ItdedOffsetOutTax;                                     // ���E��O�őΏۊz
            dr[COL_ITDEDOFFSETINTAX_TITLE] = custDmdPrcWork.ItdedOffsetInTax;                                       // ���E����őΏۊz
            dr[COL_ITDEDOFFSETTAXFREE_TITLE] = custDmdPrcWork.ItdedOffsetTaxFree;                                   // ���E���ېőΏۊz
            dr[COL_OFFSETOUTTAX_TITLE] = custDmdPrcWork.OffsetOutTax;                                               // ���E��O�ŏ����
            dr[COL_OFFSETINTAX_TITLE] = custDmdPrcWork.OffsetInTax;                                                 // ���E����ŏ����
            dr[COL_ITDEDSALESOUTTAX_TITLE] = custDmdPrcWork.ItdedSalesOutTax;                                       // ����O�őΏۊz
            dr[COL_ITDEDSALESINTAX_TITLE] = custDmdPrcWork.ItdedSalesInTax;                                         // ������őΏۊz
            dr[COL_ITDEDSALESTAXFREE_TITLE] = custDmdPrcWork.ItdedSalesTaxFree;                                     // �����ېőΏۊz
            dr[COL_SALESOUTTAX_TITLE] = custDmdPrcWork.SalesOutTax;                                                 // ����O�Ŋz
            dr[COL_SALESINTAX_TITLE] = custDmdPrcWork.SalesInTax;                                                   // ������Ŋz
            dr[COL_TTLITDEDRETOUTTAX_TITLE] = custDmdPrcWork.TtlItdedRetOutTax;                                     // �ԕi�O�őΏۊz
            dr[COL_TTLITDEDRETINTAX_TITLE] = custDmdPrcWork.TtlItdedRetInTax;                                       // �ԕi���őΏۊz
            dr[COL_TTLITDEDRETTAXFREE_TITLE] = custDmdPrcWork.TtlItdedRetTaxFree;                                   // �ԕi��ېőΏۊz
            dr[COL_TTLRETOUTERTAX_TITLE] = custDmdPrcWork.TtlRetOuterTax;                                           // �ԕi�O�Ŋz
            dr[COL_TTLRETINNERTAX_TITLE] = custDmdPrcWork.TtlRetInnerTax;                                           // �ԕi���Ŋz
            dr[COL_TTLITDEDDISOUTTAX_TITLE] = custDmdPrcWork.TtlItdedDisOutTax;                                     // �l���O�őΏۊz
            dr[COL_TTLITDEDDISINTAX_TITLE] = custDmdPrcWork.TtlItdedDisInTax;                                       // �l�����őΏۊz
            dr[COL_TTLITDEDDISTAXFREE_TITLE] = custDmdPrcWork.TtlItdedDisTaxFree;                                   // �l����ېőΏۊz
            dr[COL_TTLDISOUTERTAX_TITLE] = custDmdPrcWork.TtlDisOuterTax;                                           // �l���O�Ŋz
            dr[COL_TTLDISINNERTAX_TITLE] = custDmdPrcWork.TtlDisInnerTax;                                           // �l�����Ŋz

            dr[COL_BALANCEADJUST_TITLE] = custDmdPrcWork.BalanceAdjust;                                             // �c�������z
            dr[COL_TAXADJUST_TITLE] = custDmdPrcWork.TaxAdjust;
            // �����z(�W���p�̂�)
            dr[COL_TOTALADJUST_TITLE] = custDmdPrcWork.BalanceAdjust + custDmdPrcWork.TaxAdjust;
            dr[COL_NONSTMNTAPPEARANCE_TITLE] = 0;                                                                   // �����ϋ��z�i���U�j
            dr[COL_NONSTMNTISDONE_TITLE] = 0;                                                                       // �����ϋ��z�i�􂵁j 
            dr[COL_STMNTAPPEARANCE_TITLE] = 0;                                                                      // ���ϋ��z�i���U�j
            dr[COL_STMNTISDONE_TITLE] = 0;                                                                          // ���ϋ��z�i�􂵁j

            dr[COL_SALESSLIPCOUNT_TITLE] = custDmdPrcWork.SalesSlipCount;                                           // �`�[����
            dr[COL_BILLPRINTDATE_TITLE] = TDateTime.DateTimeToLongDate(custDmdPrcWork.BillPrintDate);                                          // ���������s��
            dr[COL_EXPECTEDDEPOSITDATE_TITLE] = TDateTime.DateTimeToLongDate(custDmdPrcWork.ExpectedDepositDate);   // �����\���
            dr[COL_COLLECTCOND_TITLE] = custDmdPrcWork.CollectCond;                                                 // �������
            dr[COL_CONSTAXLAYMETHOD_TITLE] = custDmdPrcWork.ConsTaxLayMethod;                                       // ����œ]�ŕ���
            dr[COL_CONSTAXRATE_TITLE] = custDmdPrcWork.ConsTaxRate;                                                 // ����ŗ�
            dr[COL_FRACTIONPROCCD_TITLE] = custDmdPrcWork.FractionProcCd;                                           // �[�������敪
            dr[COL_AFCALDEMANDPRICE_TITLE] = custDmdPrcWork.AfCalDemandPrice;                                       // �v�Z�㐿�����z
            dr[COL_ACPODRTTL2TMBFBLDMD_TITLE] = custDmdPrcWork.AcpOdrTtl2TmBfBlDmd;                                 // ��2��O�c���i�����v�j
            dr[COL_ACPODRTTL3TMBFBLDMD_TITLE] = custDmdPrcWork.AcpOdrTtl3TmBfBlDmd;                                 // ��3��O�c���i�����v�j
            dr[COL_CADDUPUPDEXECDATE_TITLE] = TDateTime.DateTimeToLongDate(custDmdPrcWork.CAddUpUpdExecDate);       // �����X�V���s�N����
            dr[COL_STARTCADDUPUPDDATE_TITLE] = TDateTime.DateTimeToLongDate(custDmdPrcWork.StartCAddUpUpdDate);     // �����X�V�J�n�N����
            dr[COL_LASTCADDUPUPDDATE_TITLE] = TDateTime.DateTimeToLongDate(custDmdPrcWork.LastCAddUpUpdDate);       // �O������X�V�N����

            dr[COL_TAXADJUST_TITLE] = custDmdPrcWork.TaxAdjust;                                                     // ����Œ����z
            dr[COL_GUID_TITLE] = custDmdPrcWork.FileHeaderGuid;                                                     // GUID
            dr[COL_CREATEDATETIME] = custDmdPrcWork.CreateDateTime;                                                 // �쐬����
            dr[COL_UPDATEDATETIME] = custDmdPrcWork.UpdateDateTime;                                                 // �X�V����

            List<DmdDepoTotal> dmdDepoTotalList = new List<DmdDepoTotal>();
            if ( dmdDepoTotalArrayList != null )
            {
                foreach (DmdDepoTotalWork dmdDepoTotalWork in dmdDepoTotalArrayList)
                {
                    dmdDepoTotalList.Add(UIDataFromParamData(dmdDepoTotalWork));
                }
            }
            dr[COL_DEPOTOTAL] = dmdDepoTotalList;

            // ADD 2009/06/23 ------>>>
            dr[COL_BILLNO_TITLE] = custDmdPrcWork.BillNo;                                                           // ������No
            // ADD 2009/06/23 ------<<<
            
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="accRecDepoTotalWork">���|�����W�v�f�[�^���[�N</param>
        /// <returns>���|�����W�v�f�[�^</returns>
        private static AccRecDepoTotal UIDataFromParamData(AccRecDepoTotalWork accRecDepoTotalWork)
        {
            AccRecDepoTotal accRecDepoTotal = new AccRecDepoTotal();

            accRecDepoTotal.CreateDateTime = accRecDepoTotalWork.CreateDateTime;        // �쐬����
            accRecDepoTotal.UpdateDateTime = accRecDepoTotalWork.UpdateDateTime;        // �X�V����
            accRecDepoTotal.EnterpriseCode = accRecDepoTotalWork.EnterpriseCode;        // ��ƃR�[�h
            accRecDepoTotal.FileHeaderGuid = accRecDepoTotalWork.FileHeaderGuid;        // GUID
            accRecDepoTotal.UpdEmployeeCode = accRecDepoTotalWork.UpdEmployeeCode;      // �X�V�]�ƈ��R�[�h
            accRecDepoTotal.UpdAssemblyId1 = accRecDepoTotalWork.UpdAssemblyId1;        // �X�V�A�Z���u��ID1
            accRecDepoTotal.UpdAssemblyId2 = accRecDepoTotalWork.UpdAssemblyId2;        // �X�V�A�Z���u��ID2
            accRecDepoTotal.LogicalDeleteCode = accRecDepoTotalWork.LogicalDeleteCode;  // �_���폜�敪
            accRecDepoTotal.AddUpSecCode = accRecDepoTotalWork.AddUpSecCode;            // �v�㋒�_�R�[�h
            accRecDepoTotal.ClaimCode = accRecDepoTotalWork.ClaimCode;                  // ������R�[�h
            accRecDepoTotal.CustomerCode = accRecDepoTotalWork.CustomerCode;            // ���Ӑ�R�[�h
            accRecDepoTotal.AddUpDate = accRecDepoTotalWork.AddUpDate;                  // �v��N����
            accRecDepoTotal.MoneyKindCode = accRecDepoTotalWork.MoneyKindCode;          // ����R�[�h
            accRecDepoTotal.MoneyKindName = accRecDepoTotalWork.MoneyKindName;          // ���햼��
            accRecDepoTotal.MoneyKindDiv = accRecDepoTotalWork.MoneyKindDiv;            // ����敪
            accRecDepoTotal.Deposit = accRecDepoTotalWork.Deposit;                      // �������z

            return accRecDepoTotal;
        }

        /// <summary>
        /// UIData��PramData�ڍ�����
        /// </summary>
        /// <param name="accRecDepoTotal">���|�����W�v�f�[�^</param>
        /// <returns>���|�����W�v�f�[�^���[�N</returns>
        private static AccRecDepoTotalWork ParamDataFromUIData(AccRecDepoTotal accRecDepoTotal)
        {
            AccRecDepoTotalWork accRecDepoTotalWork = new AccRecDepoTotalWork();

            accRecDepoTotalWork.CreateDateTime = accRecDepoTotal.CreateDateTime;        // �쐬����
            accRecDepoTotalWork.UpdateDateTime = accRecDepoTotal.UpdateDateTime;        // �X�V����
            accRecDepoTotalWork.EnterpriseCode = accRecDepoTotal.EnterpriseCode;        // ��ƃR�[�h
            accRecDepoTotalWork.FileHeaderGuid = accRecDepoTotal.FileHeaderGuid;        // GUID
            accRecDepoTotalWork.UpdEmployeeCode = accRecDepoTotal.UpdEmployeeCode;      // �X�V�]�ƈ��R�[�h
            accRecDepoTotalWork.UpdAssemblyId1 = accRecDepoTotal.UpdAssemblyId1;        // �X�V�A�Z���u��ID1
            accRecDepoTotalWork.UpdAssemblyId2 = accRecDepoTotal.UpdAssemblyId2;        // �X�V�A�Z���u��ID2
            accRecDepoTotalWork.LogicalDeleteCode = accRecDepoTotal.LogicalDeleteCode;  // �_���폜�敪
            accRecDepoTotalWork.AddUpSecCode = accRecDepoTotal.AddUpSecCode;            // �v�㋒�_�R�[�h
            accRecDepoTotalWork.ClaimCode = accRecDepoTotal.ClaimCode;                  // ������R�[�h
            accRecDepoTotalWork.CustomerCode = accRecDepoTotal.CustomerCode;            // ���Ӑ�R�[�h
            accRecDepoTotalWork.AddUpDate = accRecDepoTotal.AddUpDate;                  // �v��N����
            accRecDepoTotalWork.MoneyKindCode = accRecDepoTotal.MoneyKindCode;          // ����R�[�h
            accRecDepoTotalWork.MoneyKindName = accRecDepoTotal.MoneyKindName;          // ���햼��
            accRecDepoTotalWork.MoneyKindDiv = accRecDepoTotal.MoneyKindDiv;            // ����敪
            accRecDepoTotalWork.Deposit = accRecDepoTotal.Deposit;                      // �������z

            return accRecDepoTotalWork;
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="dmdDepoTotalWork">���������W�v�f�[�^���[�N</param>
        /// <returns>���������W�v�f�[�^</returns>
        private static DmdDepoTotal UIDataFromParamData(DmdDepoTotalWork dmdDepoTotalWork)
        {
            DmdDepoTotal dmdDepoTotal = new DmdDepoTotal();

            dmdDepoTotal.CreateDateTime = dmdDepoTotalWork.CreateDateTime;          // �쐬����
            dmdDepoTotal.UpdateDateTime = dmdDepoTotalWork.UpdateDateTime;          // �X�V����
            dmdDepoTotal.EnterpriseCode = dmdDepoTotalWork.EnterpriseCode;          // ��ƃR�[�h
            dmdDepoTotal.FileHeaderGuid = dmdDepoTotalWork.FileHeaderGuid;          // GUID
            dmdDepoTotal.UpdEmployeeCode = dmdDepoTotalWork.UpdEmployeeCode;        // �X�V�]�ƈ��R�[�h
            dmdDepoTotal.UpdAssemblyId1 = dmdDepoTotalWork.UpdAssemblyId1;          // �X�V�A�Z���u��ID1
            dmdDepoTotal.UpdAssemblyId2 = dmdDepoTotalWork.UpdAssemblyId2;          // �X�V�A�Z���u��ID2
            dmdDepoTotal.LogicalDeleteCode = dmdDepoTotalWork.LogicalDeleteCode;    // �_���폜�敪
            dmdDepoTotal.AddUpSecCode = dmdDepoTotalWork.AddUpSecCode;              // �v�㋒�_�R�[�h
            dmdDepoTotal.ClaimCode = dmdDepoTotalWork.ClaimCode;                    // ������R�[�h
            dmdDepoTotal.CustomerCode = dmdDepoTotalWork.CustomerCode;              // ���Ӑ�R�[�h
            dmdDepoTotal.AddUpDate = dmdDepoTotalWork.AddUpDate;                    // �v��N����
            dmdDepoTotal.MoneyKindCode = dmdDepoTotalWork.MoneyKindCode;            // ����R�[�h
            dmdDepoTotal.MoneyKindName = dmdDepoTotalWork.MoneyKindName;            // ���햼��
            dmdDepoTotal.MoneyKindDiv = dmdDepoTotalWork.MoneyKindDiv;              // ����敪
            dmdDepoTotal.Deposit = dmdDepoTotalWork.Deposit;                        // �������z

            return dmdDepoTotal;
        }

        /// <summary>
        /// UIData��PramData�ڍ�����
        /// </summary>
        /// <param name="source">���������W�v�f�[�^</param>
        /// <returns>���������W�v�f�[�^���[�N</returns>
        private static DmdDepoTotalWork ParamDataFromUIData(DmdDepoTotal dmdDepoTotal)
        {
            DmdDepoTotalWork dmdDepoTotalWork = new DmdDepoTotalWork();

            dmdDepoTotalWork.CreateDateTime = dmdDepoTotal.CreateDateTime;          // �쐬����
            dmdDepoTotalWork.UpdateDateTime = dmdDepoTotal.UpdateDateTime;          // �X�V����
            dmdDepoTotalWork.EnterpriseCode = dmdDepoTotal.EnterpriseCode;          // ��ƃR�[�h
            dmdDepoTotalWork.FileHeaderGuid = dmdDepoTotal.FileHeaderGuid;          // GUID
            dmdDepoTotalWork.UpdEmployeeCode = dmdDepoTotal.UpdEmployeeCode;        // �X�V�]�ƈ��R�[�h
            dmdDepoTotalWork.UpdAssemblyId1 = dmdDepoTotal.UpdAssemblyId1;          // �X�V�A�Z���u��ID1
            dmdDepoTotalWork.UpdAssemblyId2 = dmdDepoTotal.UpdAssemblyId2;          // �X�V�A�Z���u��ID2
            dmdDepoTotalWork.LogicalDeleteCode = dmdDepoTotal.LogicalDeleteCode;    // �_���폜�敪
            dmdDepoTotalWork.AddUpSecCode = dmdDepoTotal.AddUpSecCode;              // �v�㋒�_�R�[�h
            dmdDepoTotalWork.ClaimCode = dmdDepoTotal.ClaimCode;                    // ������R�[�h
            dmdDepoTotalWork.CustomerCode = dmdDepoTotal.CustomerCode;              // ���Ӑ�R�[�h
            dmdDepoTotalWork.AddUpDate = dmdDepoTotal.AddUpDate;                    // �v��N����
            dmdDepoTotalWork.MoneyKindCode = dmdDepoTotal.MoneyKindCode;            // ����R�[�h
            dmdDepoTotalWork.MoneyKindName = dmdDepoTotal.MoneyKindName;            // ���햼��
            dmdDepoTotalWork.MoneyKindDiv = dmdDepoTotal.MoneyKindDiv;              // ����敪
            dmdDepoTotalWork.Deposit = dmdDepoTotal.Deposit;                        // �������z

            return dmdDepoTotalWork;
        }
        // 2009.01.06 Add <<<

        #endregion

        // 2009.01.06 Add >>>
        // --------------------------------------------------
        #region ���햼�̎擾�p����

        /// <summary>
        /// ���햼�̎擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="depositStKindCd">����R�[�h</param>   
        /// <remarks>
        /// <br>Update Note : ���햼�̂��擾���܂��B</br>
        /// <br>Programmer  : 21024  ���X�� ��</br>
        /// <br>Date        : 2009.01.14</br>
        /// </remarks>
        public string GetDepsitStKindNm(string enterpriseCode, int depositStKindCd)
        {
            int status = 0;
            int moneyKindMode = 1;

            ArrayList allMoneyKindList = new ArrayList();
            Hashtable moneyKindTable = new Hashtable();

            // ���z��ʃ}�X�^���A�_���폜�����܂ރf�[�^���擾
            status = this._moneyKindAcs.GetBuff(out allMoneyKindList, enterpriseCode, moneyKindMode);

            if (status == 0)
            {
                foreach (MoneyKind moneyKindInfo in allMoneyKindList)
                {
                    // ���z�ݒ�敪���u0:�����v�̏ꍇ�A��r
                    if (( moneyKindInfo.PriceStCode == 0 ) && ( moneyKindInfo.MoneyKindCode == depositStKindCd ))
                    {
                        if (moneyKindInfo.LogicalDeleteCode == 0)
                        {
                            return moneyKindInfo.MoneyKindName;
                        }
                        else
                        {
                            return "�폜��";
                        }
                    }
                }

                return "���o�^";
            }
            else
            {
                return "";
            }
        }
        #endregion
        // 2009.01.06 Add <<<


        // --------------------------------------------------
		#region ��r�p�N���X

        /// <summary>���Ӑ攄�|���z�}�X�^��r�N���X</summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ攄�|���z�}�X�^�I�u�W�F�N�g�̔�r���s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public class CustAccRecCompare : IComparer
        {
            #region IComparer �����o

            /// <summary>��r�p���\�b�h</summary>
            /// <param name="x">��r�ΏۃI�u�W�F�N�g</param>
            /// <param name="y">��r�ΏۃI�u�W�F�N�g</param>
            /// <returns>��r����(x �� y : 0���傫������, x �� y : 0��菬��������, x �� y : 0)</returns>
            /// <remarks>
            /// <br>Note       : ���Ӑ攄�|���z�}�X�^�I�u�W�F�N�g�̔�r���s���܂��B</br>
            /// <br>Programmer : 30154 ���� ���m</br>
            /// <br>Date       : 2007.04.20</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                CustAccRec obj1 = x as CustAccRec;
                CustAccRec obj2 = y as CustAccRec;

                // �L�[���Ŕ�r����
                string searchKey1 = obj1.AddUpSecCode + "_" + obj1.CustomerCode + "_" + obj1.AddUpDate;
                string searchKey2 = obj2.AddUpSecCode + "_" + obj2.CustomerCode + "_" + obj2.AddUpDate;
                // ���Ӑ攄�|���z�o�̓}�X�^�̃L�[�Ŕ�r
                return searchKey1.CompareTo(searchKey2);
            }

            #endregion
        }

        /// <summary>���Ӑ搿�����z�}�X�^��r�N���X</summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ搿�����z�}�X�^�I�u�W�F�N�g�̔�r���s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public class CustDmdPrcCompare : IComparer
        {
            #region IComparer �����o

            /// <summary>��r�p���\�b�h</summary>
            /// <param name="x">��r�ΏۃI�u�W�F�N�g</param>
            /// <param name="y">��r�ΏۃI�u�W�F�N�g</param>
            /// <returns>��r����(x �� y : 0���傫������, x �� y : 0��菬��������, x �� y : 0)</returns>
            /// <remarks>
            /// <br>Note       : ���Ӑ搿�����z�}�X�^�I�u�W�F�N�g�̔�r���s���܂��B</br>
            /// <br>Programmer : 30154 ���� ���m</br>
            /// <br>Date       : 2007.04.20</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                CustDmdPrc obj1 = x as CustDmdPrc;
                CustDmdPrc obj2 = y as CustDmdPrc;

                // �L�[���Ŕ�r����
                string searchKey1 = obj1.AddUpSecCode + "_" + obj1.CustomerCode + "_" + obj1.AddUpDate;
                string searchKey2 = obj2.AddUpSecCode + "_" + obj2.CustomerCode + "_" + obj2.AddUpDate;
                // ���Ӑ搿�����z�o�̓}�X�^�̃L�[�Ŕ�r
                return searchKey1.CompareTo(searchKey2);
            }

            #endregion
        }

        #endregion

    }
}
