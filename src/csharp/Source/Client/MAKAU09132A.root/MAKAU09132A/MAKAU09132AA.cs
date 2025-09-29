using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
    ///�d���攃�|���z�}�X�^�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �d���攃�|���z�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 30154 ���� ���m</br>
    /// <br>Date       : 2007.04.20</br>
    /// <br></br>
    /// <br>Note       : ����.NS�p�ɕύX</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2007.09.27</br>
    /// <br></br>
    /// <br>Note       : PM.NS�p�ɕύX</br>
    /// <br>Programmer : 21024 ���X�� ��</br>
    /// <br>Date       : 2009.01.14</br>
    /// <br></br>
    /// <br>Note       : ��QID:10605�Ή�</br>
    /// <br>Programmer : 30414 �E �K�j</br>
    /// <br>Date       : 2009.01.30</br>
    /// </remarks>
	public class SuplAccPayAcs
	{
		// --------------------------------------------------
		#region Private Members

        // ��ƃR�[�h
        private string              _enterpriseCode         = "";

        /// <summary>�d���攃�|���z�}�X�^�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private ISuppRsltUpdDB _iSuppRsltUpdDB = null;

        // �f�[�^�Z�b�g
        private DataSet             _bindDataSet        = null;
        private DataTable           _custAccRecTable    = null;
        private DataTable           _custDmdPrcTable    = null;

        // 2009.01.14 Add >>>
        private DataTable _custAccRecTotalTable = null;
        private DataTable _custDmdPrcTotalTable = null;
        // 2009.01.14 Add <<<

        // �}�X�^�N���X�i�[���X�g
        private Dictionary<Guid, SuplAccPayWork>  _custAccRecDic  = null;               // �d���攃�|���z�}�X�^�i�[�p
        private Dictionary<Guid, SuplierPayWork>  _custDmdPrcDic  = null;               // �d����x�����z�}�X�^�i�[�p

        // �}�X�^�擾�p���X�g
        // 2009.01.14 >>>
        //private ArrayList           _custAccRecList     = null;                         // �d���攃�|���z�}�X�^�擾�p
        //private ArrayList           _custDmdPrcList     = null;                         // �d����x�����z�}�X�^�擾�p
        private CustomSerializeArrayList _custAccRecList = null;                          // �d���攃�|���z�}�X�^�擾�p
        private CustomSerializeArrayList _custDmdPrcList = null;                          // �d����x�����z�}�X�^�擾�p

        MoneyKindAcs _moneyKindAcs = null;
        // 2009.01.14 <<<

        #endregion

        // --------------------------------------------------
        #region Public Members

        // Frem��View�pGrid���KEY��� (�w�b�_�̃^�C�g�����ƂȂ�܂�)
        public static readonly string TBL_CUSTACCREC_TITLE           = "CUSTACCREC_TABLE";
        public static readonly string TBL_CUSTDMDPRC_TITLE           = "CUSTDMDPRC_TABLE";
        // 2009.01.14 Add >>>
        public static readonly string TBL_CUSTACCRECTOTAL_TITLE = "CUSTACCRECTOTAL_TABLE";
        public static readonly string TBL_CUSTDMDPRCTOTAL_TITLE = "CUSTDMDPRCTOTAL_TABLE";
        // 2009.01.14 Add <<<
        public static readonly string COL_DELETEDATE_TITLE           = "�폜��";
        public static readonly string COL_ADDUPSECCODE_TITLE         = "�v�㋒�_�R�[�h";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
        public static readonly string COL_SUPPLIERCODE_TITLE = "�d����R�[�h";
        public static readonly string COL_SUPPLIERNAME_TITLE = "�d���於��";
        public static readonly string COL_SUPPLIERNAME2_TITLE = "�d���於��2";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        public static readonly string COL_SUPPLIERSNM_TITLE = "�d���旪��";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA ADD START
        public static readonly string COL_RESULTSECCODE_TITLE = "���ы��_�R�[�h";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA ADD END

        public static readonly string COL_PAYEECODE_TITLE = "�x����R�[�h";
        public static readonly string COL_PAYEENAME_TITLE            = "�x���於��";
        public static readonly string COL_PAYEENAME2_TITLE           = "�x���於��2";
        public static readonly string COL_PAYEESNM_TITLE             = "�x���旪��";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_ADDUPDATEJP_TITLE          = "�v���";
        public static readonly string COL_ADDUPYEARMONTHJP_TITLE     = "�v��N��";
		public static readonly string COL_ADDUPYEARMONTH_TITLE       = "_�v��N��";
		public static readonly string COL_ADDUPDATE_TITLE            = "_�v���";
        public static readonly string COL_LASTTIMEACCPAY_TITLE       = "�O��c��";                  // �O�񔃊|���z
        public static readonly string COL_LASTTIMEDEMAND_TITLE       = "�O��c��";                  // �O��x�����z
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //public static readonly string COL_THISTIMEPAYNRML_TITLE      = "����x�����z�i�ʏ�x���j";
        //public static readonly string COL_THISTIMEFEEPAYNRML_TITLE   = "����萔���z�i�ʏ�x���j";
        //public static readonly string COL_THISTIMEDISPAYNRML_TITLE   = "����l���z�i�ʏ�x���j";
        //public static readonly string COL_THISTIMERBTDMDNRML_TITLE   = "���񃊃x�[�g�z�i�ʏ�x���j";
        //public static readonly string COL_THISTIMEDMDDEPO_TITLE      = "����x�����z�i�a����j";
        //public static readonly string COL_THISTIMEFEEDMDDEPO_TITLE   = "����萔���z�i�a����j";
        //public static readonly string COL_THISTIMEDISDMDDEPO_TITLE   = "����l���z�i�a����j";
        //public static readonly string COL_THISTIMERBTDMDDEPO_TITLE   = "���񃊃x�[�g�z�i�a����j";
        public static readonly string COL_THISTIMEPAYNRML_TITLE      = "����x�����z";
        public static readonly string COL_THISTIMEFEEPAYNRML_TITLE   = "����萔���z";
        public static readonly string COL_THISTIMEDISPAYNRML_TITLE   = "����l���z";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_THISTIMEPAYMENT_TITLE      = "����x��";
        public static readonly string COL_THISTIMETTLBLCACPAY_TITLE    = "����J�z�c���i���|�v�j";
        public static readonly string COL_THISTIMETTLBLCDMD_TITLE    = "����J�z�c���i�x���v�j";
        public static readonly string COL_THISTIMESTOCKPRICE_TITLE        = "����d�����z";                  // ����d�����z
        public static readonly string COL_THISSTCPRCTAX_TITLE         = "����d�������";                    // ����d�������
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        //public static readonly string COL_TTLINCDTBTTAXEXC_TITLE     = "����x��";                  // �x���C���Z���e�B�u�z���v�i�Ŕ����j
        //public static readonly string COL_TTLINCDTBTTAX_TITLE        = "�x�������";                // �x���C���Z���e�B�u�z���v�i�Łj
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_OFSTHISTIMESTOCK_TITLE     = "����d��";  // ���d�����z
        public static readonly string COL_OFSTHISSTOCKTAX_TITLE      = "�����";   // ���d�������
        public static readonly string COL_ITDEDOFFSETOUTTAX_TITLE    = "���E��O�őΏۊz";
        public static readonly string COL_ITDEDOFFSETINTAX_TITLE     = "���E����őΏۊz";
        public static readonly string COL_ITDEDOFFSETTAXFREE_TITLE   = "���E���ېőΏۊz";
        public static readonly string COL_OFFSETOUTTAX_TITLE         = "���E��O�ŏ����";
        public static readonly string COL_OFFSETINTAX_TITLE          = "���E����ŏ����";
        public static readonly string COL_ITDEDSTCOUTTAX_TITLE     = "�d���O�őΏۊz";
        public static readonly string COL_ITDEDSTCINTAX_TITLE      = "�d�����őΏۊz";
        public static readonly string COL_ITDEDSTCTAXFREE_TITLE    = "�d����ېőΏۊz";
        public static readonly string COL_TTLSTOCKOUTERTAX_TITLE          = "�d���O�Ŋz";
        public static readonly string COL_TTLSTOCKINNERTAX_TITLE           = "�d�����Ŋz";
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
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_BALANCEADJUST_TITLE        = "�c�������z";

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
        public static readonly string COL_TAXADJUST_TITLE = "����Œ����z";
        public static readonly string COL_TOTALADJUST_TITLE = "�c�������z�\��";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

        // ���|�e�[�u������͍폜���ꂽ���A�x���e�[�u���Ɏc�����܂܂Ȃ̂ō폜���Ȃ�
        public static readonly string COL_NONSTMNTAPPEARANCE_TITLE   = "�����ϋ��z�i���U�j";
        public static readonly string COL_NONSTMNTISDONE_TITLE       = "�����ϋ��z�i�􂵁j";
        public static readonly string COL_STMNTAPPEARANCE_TITLE      = "���ϋ��z�i���U�j";
        public static readonly string COL_STMNTISDONE_TITLE          = "���ϋ��z�i�􂵁j";
        
        //public static readonly string COL_THISCASHSTOCKPRICE          = "���񌻋��d���z";
        //public static readonly string COL_THISCASHSTOCKTAX            = "���񌻋��d������Ŋz";
        public static readonly string COL_STOCKSLIPCOUNT             = "�d���`�[����";
        public static readonly string COL_BILLPRINTDATE              = "�x�������s��";
        public static readonly string COL_PAYMENTSCHEDULE        = "�x���\���";
        public static readonly string COL_PAYMENTCOND                = "�������";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_SUPPCTAXLAYCD_TITLE     = "����œ]�ŕ���";
        public static readonly string COL_SUPPLIERCONSTAXRATE_TITLE          = "����ŗ�";
        public static readonly string COL_FRACTIONPROCCD_TITLE       = "�[�������敪";
        public static readonly string COL_STCKTTLACCPAYBALANCE_TITLE    = "���|�c��";                  // �v�Z�㓖�����|���z
        public static readonly string COL_AFCALDEMANDPRICE_TITLE     = "���|�c��";                  // �v�Z��x�����z
        public static readonly string COL_STCKTTL2TMBFBLACCPAY_TITLE = "�O�X��c��";              // ��2��O�c��(���|�v)
        public static readonly string COL_ACPODRTTL2TMBFBLDMD_TITLE = "�O�X��c��";              // ��2��O�c��(�x���v)
        public static readonly string COL_STCKTTL3TMBFBLACCPAY_TITLE = "�O�X�X��c��";              // ��3��O�c��(���|�v)
        public static readonly string COL_ACPODRTTL3TMBFBLDMD_TITLE = "�O�X�X��c��";              // ��3��O�c��(�x���v)
        public static readonly string COL_MONTHADDUPEXPDATE_TITLE    = "�����X�V���s�N����";
        public static readonly string COL_CADDUPUPDEXECDATE_TITLE    = "�����X�V���s�N����";
        public static readonly string COL_DMDPROCNUM_TITLE           = "�x�������ʔ�";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
        //public static readonly string COL_THISRECVOFFSET_TITLE = "�����摊�E���z";
        //public static readonly string COL_THISRECVOFFSETTAX_TITLE = "�����摊�E����Ŋz";
        //public static readonly string COL_THISRECVOUTTAX_TITLE = "���O�őΏۊz";
        //public static readonly string COL_THISRECVINTAX_TITLE = "�����őΏۊz";
        //public static readonly string COL_THISRECVTAXFREE_TITLE = "����ېőΏۊz";
        //public static readonly string COL_THISRECVOUTERTAX_TITLE = "���O�ŏ����";
        //public static readonly string COL_THISRECVINNERTAX_TITLE = "�����ŏ����";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END
        
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
        public static readonly string COL_GUID_TITLE                 = "GUID";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
        public static readonly string COL_CREATEDATETIME = "�쐬����";
        public static readonly string COL_UPDATEDATETIME = "�X�V����";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

        // 2009.01.14 Add >>>
        public static readonly string COL_STMONCADDUPUPDDATE_TITLE = "�����X�V�J�n�N����";
        public static readonly string COL_LAMONCADDUPUPDDATE_TITLE = "�O�񌎎��X�V�N����";
        public static readonly string COL_STARTCADDUPUPDDATE_TITLE = "�����X�V�J�n�N����";
        public static readonly string COL_LASTCADDUPUPDDATE_TITLE = "�O������X�V�N����";

        public static readonly string COL_PAYTOTAL = "�x���W�v�f�[�^";
        public static readonly string ALL_SECTION = "00";
        // 2009.01.14 Add <<<

        #endregion

        // --------------------------------------------------
		#region Constructor

		/// <summary>�d���攃�|���z�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^</summary>
		/// <remarks>
        /// <br>Note       : �d���攃�|���z�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        public SuplAccPayAcs ()
		{
			try {
				// ��ƃR�[�h�擾
				this._enterpriseCode          = LoginInfoAcquisition.EnterpriseCode;

				// �����[�g�I�u�W�F�N�g�擾
                this._iSuppRsltUpdDB          = (ISuppRsltUpdDB)MediationSuppRsltUpdDB.GetSuppRsltUpdDB();

                // �}�X�^�N���X�i�[���X�g������
                this._custAccRecDic       = new Dictionary<Guid, SuplAccPayWork>();
                this._custDmdPrcDic       = new Dictionary<Guid, SuplierPayWork>();

                // �}�X�^�擾�p���X�g������
                // 2009.01.14 >>>
                //this._custAccRecList      = new ArrayList();
                //this._custDmdPrcList      = new ArrayList();
                this._custAccRecList = new CustomSerializeArrayList();
                this._custDmdPrcList = new CustomSerializeArrayList();
                this._moneyKindAcs = new MoneyKindAcs();
                // 2009.01.14 <<<

                // �f�[�^�Z�b�g������
                this._bindDataSet             = new DataSet();
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).BeginInit();
                this._bindDataSet.DataSetName = "NewDataSet";
                ((System.ComponentModel.ISupportInitialize)(this._bindDataSet)).EndInit();

                // �f�[�^�Z�b�g����\�z
                this.DataSetColumnConstruction();
			}
			catch( Exception ) {
				// �I�t���C������null���Z�b�g
                this._iSuppRsltUpdDB = null;
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
			// �d���攃�|���z�}�X�^�e�[�u��
            this._custAccRecTable = new DataTable(TBL_CUSTACCREC_TITLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custAccRecTable.Columns.Add( COL_CREATEDATETIME, typeof( DateTime ) );  // �쐬����
            this._custAccRecTable.Columns.Add( COL_UPDATEDATETIME, typeof( DateTime ) );  // �X�V����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add( COL_DELETEDATE_TITLE, typeof( string ) );  // �폜��
            this._custAccRecTable.Columns.Add(COL_ADDUPSECCODE_TITLE,         typeof(string));  // �v�㋒�_�R�[�h

            
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
            this._custAccRecTable.Columns.Add(COL_SUPPLIERCODE_TITLE, typeof(Int32));   // �d����R�[�h
            this._custAccRecTable.Columns.Add(COL_SUPPLIERNAME_TITLE, typeof(string));  // �d���於��
            this._custAccRecTable.Columns.Add(COL_SUPPLIERNAME2_TITLE, typeof(string));  // �d���於��2
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custAccRecTable.Columns.Add(COL_SUPPLIERSNM_TITLE, typeof(string));  // �d���旪��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END

            this._custAccRecTable.Columns.Add(COL_PAYEECODE_TITLE,            typeof(Int32));   // �x����R�[�h
            this._custAccRecTable.Columns.Add(COL_PAYEENAME_TITLE,            typeof(string));  // �x���於��
            this._custAccRecTable.Columns.Add(COL_PAYEENAME2_TITLE,           typeof(string));  // �x���於��2
            this._custAccRecTable.Columns.Add(COL_PAYEESNM_TITLE,             typeof(string));  // �x���旪��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_ADDUPDATEJP_TITLE,          typeof(string));  // �v��N����
            // 2009.01.14 Add >>>
            this._custAccRecTable.Columns[COL_ADDUPDATEJP_TITLE].Caption = "�����X�V��";
            // 2009.01.14 Add <<<
            this._custAccRecTable.Columns.Add(COL_ADDUPYEARMONTHJP_TITLE,     typeof(string));  // �v��N��
            this._custAccRecTable.Columns.Add(COL_ADDUPDATE_TITLE,            typeof(Int32));   // _�v��N��
            this._custAccRecTable.Columns.Add(COL_ADDUPYEARMONTH_TITLE,       typeof(Int32));   // _�v��N����
            this._custAccRecTable.Columns.Add(COL_THISTIMEPAYNRML_TITLE,      typeof(Int64));   // ����x�����z�i�ʏ�x���j
            this._custAccRecTable.Columns.Add(COL_THISTIMEFEEPAYNRML_TITLE,   typeof(Int64));   // ����萔���z�i�ʏ�x���j
            this._custAccRecTable.Columns.Add(COL_THISTIMEDISPAYNRML_TITLE,   typeof(Int64));   // ����l���z�i�ʏ�x���j
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custAccRecTable.Columns.Add(COL_THISTIMERBTDMDNRML_TITLE,   typeof(Int64));   // ���񃊃x�[�g�z�i�ʏ�x���j
            //this._custAccRecTable.Columns.Add(COL_THISTIMEDMDDEPO_TITLE,      typeof(Int64));   // ����x�����z�i�a����j
            //this._custAccRecTable.Columns.Add(COL_THISTIMEFEEDMDDEPO_TITLE,   typeof(Int64));   // ����萔���z�i�a����j
            //this._custAccRecTable.Columns.Add(COL_THISTIMEDISDMDDEPO_TITLE,   typeof(Int64));   // ����l���z�i�a����j
            //this._custAccRecTable.Columns.Add(COL_THISTIMERBTDMDDEPO_TITLE,   typeof(Int64));   // ���񃊃x�[�g�z�i�a����j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_THISTIMETTLBLCACPAY_TITLE,    typeof(Int64));   // ����J�z�c���i���|�v�j
            //this._custAccRecTable.Columns.Add(COL_THISNETSTCKPRICE_TITLE,     typeof(Int64));   // ���E�㍡��d�����z
            //this._custAccRecTable.Columns.Add(COL_THISNETSTCPRCTAX_TITLE,      typeof(Int64));   // ���E�㍡��d�������
            this._custAccRecTable.Columns.Add(COL_ITDEDOFFSETOUTTAX_TITLE,    typeof(Int64));   // ���E��O�őΏۊz
            this._custAccRecTable.Columns.Add(COL_ITDEDOFFSETINTAX_TITLE,     typeof(Int64));   // ���E����őΏۊz
            this._custAccRecTable.Columns.Add(COL_ITDEDOFFSETTAXFREE_TITLE,   typeof(Int64));   // ���E���ېőΏۊz
            this._custAccRecTable.Columns.Add(COL_OFFSETOUTTAX_TITLE,         typeof(Int64));   // ���E��O�ŏ����
            this._custAccRecTable.Columns.Add(COL_OFFSETINTAX_TITLE,          typeof(Int64));   // ���E����ŏ����
            this._custAccRecTable.Columns.Add(COL_ITDEDSTCOUTTAX_TITLE,     typeof(Int64));   // �d���O�őΏۊz
            this._custAccRecTable.Columns.Add(COL_ITDEDSTCINTAX_TITLE,      typeof(Int64));   // �d�����őΏۊz
            this._custAccRecTable.Columns.Add(COL_ITDEDSTCTAXFREE_TITLE,    typeof(Int64));   // �d����ېőΏۊz
            this._custAccRecTable.Columns.Add(COL_TTLSTOCKOUTERTAX_TITLE,          typeof(Int64));   // �d���O�Ŋz
            this._custAccRecTable.Columns.Add(COL_TTLSTOCKINNERTAX_TITLE,           typeof(Int64));   // �d�����Ŋz
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custAccRecTable.Columns.Add(COL_ITDEDPAYMOUTTAX_TITLE,      typeof(Int64));   // �x���O�őΏۊz
            //this._custAccRecTable.Columns.Add(COL_ITDEDPAYMINTAX_TITLE,       typeof(Int64));   // �x�����őΏۊz
            //this._custAccRecTable.Columns.Add(COL_ITDEDPAYMTAXFREE_TITLE,     typeof(Int64));   // �x����ېőΏۊz
            //this._custAccRecTable.Columns.Add(COL_PAYMENTOUTTAX_TITLE,        typeof(Int64));   // �x���O�ŏ����
            //this._custAccRecTable.Columns.Add(COL_PAYMENTINTAX_TITLE,         typeof(Int64));   // �x�����ŏ����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_SUPPCTAXLAYCD_TITLE,     typeof(Int32));   // ����œ]�ŕ���
            this._custAccRecTable.Columns.Add(COL_SUPPLIERCONSTAXRATE_TITLE,          typeof(Double));  // ����ŗ�
            this._custAccRecTable.Columns.Add(COL_FRACTIONPROCCD_TITLE,       typeof(Int32));   // �[�������敪
            this._custAccRecTable.Columns.Add(COL_MONTHADDUPEXPDATE_TITLE,    typeof(Int32));   // �����X�V���s�N����
            this._custAccRecTable.Columns.Add(COL_GUID_TITLE,                 typeof(Guid));    // GUID
            this._custAccRecTable.Columns.Add(COL_STCKTTL3TMBFBLACCPAY_TITLE, typeof(Int64));   // ��3��O�c���i���|�v�j
            this._custAccRecTable.Columns.Add(COL_STCKTTL2TMBFBLACCPAY_TITLE, typeof(Int64));   // ��2��O�c���i���|�v�j
            this._custAccRecTable.Columns.Add(COL_LASTTIMEACCPAY_TITLE,       typeof(Int64));   // �O�񔃊|���z
            this._custAccRecTable.Columns.Add(COL_THISTIMESTOCKPRICE_TITLE,        typeof(Int64));   // ����d�����z
            this._custAccRecTable.Columns.Add(COL_THISSTCPRCTAX_TITLE,         typeof(Int64));   // ����d�������
            this._custAccRecTable.Columns.Add(COL_OFSTHISTIMESTOCK_TITLE, typeof(Int64));   // ���E�㍡��d�����z
            this._custAccRecTable.Columns.Add(COL_OFSTHISSTOCKTAX_TITLE, typeof(Int64));   // ���E�㍡��d�������
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custAccRecTable.Columns.Add(COL_TTLINCDTBTTAXEXC_TITLE,     typeof(Int64));   // �x���C���Z���e�B�u�z���v�i�Ŕ����j
            //this._custAccRecTable.Columns.Add(COL_TTLINCDTBTTAX_TITLE,        typeof(Int64));   // �x���C���Z���e�B�u�z���v�i�Łj
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_THISTIMEPAYMENT_TITLE,      typeof(Int64));   // ����x��
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
            this._custAccRecTable.Columns.Add(COL_TAXADJUST_TITLE, typeof(Int64));   // ����Œ����z
            this._custAccRecTable.Columns.Add(COL_TOTALADJUST_TITLE, typeof(Int64));   // �c�������z�\��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //this._custAccRecTable.Columns.Add(COL_NONSTMNTAPPEARANCE_TITLE,   typeof(Int64));   // �����ϋ��z�i���U�j
            //this._custAccRecTable.Columns.Add(COL_NONSTMNTISDONE_TITLE,       typeof(Int64));   // �����ϋ��z�i�􂵁j
            //this._custAccRecTable.Columns.Add(COL_STMNTAPPEARANCE_TITLE,      typeof(Int64));   // ���ϋ��z�i���U�j
            //this._custAccRecTable.Columns.Add(COL_STMNTISDONE_TITLE,          typeof(Int64));   // ���ϋ��z�i�􂵁j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            //this._custAccRecTable.Columns.Add(COL_THISCASHSTOCKPRICE,          typeof(Int64));   // ����d�����z
            //this._custAccRecTable.Columns.Add(COL_THISCASHSTOCKTAX,            typeof(Int64));   // ����d�x������Ŋz
            this._custAccRecTable.Columns.Add(COL_STOCKSLIPCOUNT,             typeof(Int64));   // �d���`�[����
            this._custAccRecTable.Columns.Add(COL_BILLPRINTDATE,              typeof(Int64));   // �x�������s��
            this._custAccRecTable.Columns.Add(COL_PAYMENTSCHEDULE,        typeof(Int64));   // �x���\���
            this._custAccRecTable.Columns.Add(COL_PAYMENTCOND,                typeof(Int64));   // �������
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custAccRecTable.Columns.Add(COL_STCKTTLACCPAYBALANCE_TITLE,    typeof(Int64));   // �v�Z�㓖�����|���z
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //this._custAccRecTable.Columns.Add( COL_THISRECVINNERTAX_TITLE, typeof( Int64 ) );   // �����ŏ���� 
            //this._custAccRecTable.Columns.Add( COL_THISRECVINTAX_TITLE, typeof( Int64 ) );   // �����őΏۊz
            //this._custAccRecTable.Columns.Add( COL_THISRECVOFFSET_TITLE, typeof( Int64 ) );   // �����摊�E���z
            //this._custAccRecTable.Columns.Add( COL_THISRECVOFFSETTAX_TITLE, typeof( Int64 ) );   // �����摊�E�����
            //this._custAccRecTable.Columns.Add( COL_THISRECVOUTERTAX_TITLE, typeof( Int64 ) );   // ���O�ŏ����
            //this._custAccRecTable.Columns.Add( COL_THISRECVOUTTAX_TITLE, typeof( Int64 ) );   // ���O�őΏۊz
            //this._custAccRecTable.Columns.Add( COL_THISRECVTAXFREE_TITLE, typeof( Int64 ) );   // ����ېőΏۊz
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // 2009.01.14 Add >>>
            this._custAccRecTable.Columns.Add(COL_STMONCADDUPUPDDATE_TITLE, typeof(Int32));     // �����X�V�J�n�N����
            this._custAccRecTable.Columns.Add(COL_LAMONCADDUPUPDDATE_TITLE, typeof(Int32));     // �O�񌎎��X�V�N����
            this._custAccRecTable.Columns.Add(COL_PAYTOTAL, typeof(List<ACalcPayTotal>));      // �x���W�v�f�[�^
            // 2009.01.14 Add <<<

            // PrimaryKey�ݒ�
            this._custAccRecTable.PrimaryKey = new DataColumn[] { this._custAccRecTable.Columns[COL_ADDUPSECCODE_TITLE],    // �v�㋒�_�R�[�h
                                                                  this._custAccRecTable.Columns[COL_PAYEECODE_TITLE],       // �x����R�[�h
                                                                  this._custAccRecTable.Columns[COL_SUPPLIERCODE_TITLE],    // �d����R�[�h
                                                                  this._custAccRecTable.Columns[COL_ADDUPDATE_TITLE]};      // �v��N����

            this._bindDataSet.Tables.Add(this._custAccRecTable);

            // 2009.01.14 Add >>>
            this._custAccRecTotalTable = new DataTable(TBL_CUSTACCRECTOTAL_TITLE);
            this._custAccRecTotalTable = this._custAccRecTable.Clone();
            this._custAccRecTotalTable.TableName = TBL_CUSTACCRECTOTAL_TITLE;
            this._bindDataSet.Tables.Add(this._custAccRecTotalTable);
            // 2009.01.14 Add <<<

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA MODIFY START
            // x�d���攃�|���z�}�X�^�e�[�u��
            // �d���搿�����z�}�X�^�e�[�u�� (���e�[�u�����ԈႢ)
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA MODIFY END
            this._custDmdPrcTable = new DataTable(TBL_CUSTDMDPRC_TITLE);

			// Add���s�����Ԃ��A��̕\�����ʂƂȂ�܂��B
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custDmdPrcTable.Columns.Add( COL_CREATEDATETIME, typeof( DateTime ) );  // �쐬����
            this._custDmdPrcTable.Columns.Add( COL_UPDATEDATETIME, typeof( DateTime ) );  // �X�V����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add( COL_DELETEDATE_TITLE, typeof( string ) );  // �폜��
            this._custDmdPrcTable.Columns.Add(COL_ADDUPSECCODE_TITLE,         typeof(string));  // �v�㋒�_�R�[�h

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
            this._custDmdPrcTable.Columns.Add(COL_SUPPLIERCODE_TITLE, typeof(Int32));   // �d����R�[�h
            this._custDmdPrcTable.Columns.Add(COL_SUPPLIERNAME_TITLE, typeof(string));  // �d���於��
            this._custDmdPrcTable.Columns.Add(COL_SUPPLIERNAME2_TITLE, typeof(string));  // �d���於��2
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_SUPPLIERSNM_TITLE, typeof(string));  // 
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA ADD START
            this._custDmdPrcTable.Columns.Add(COL_RESULTSECCODE_TITLE, typeof(string));     // ���ы��_�R�[�h
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA ADD END

            this._custDmdPrcTable.Columns.Add(COL_PAYEECODE_TITLE, typeof(Int32));   // �x����R�[�h
            this._custDmdPrcTable.Columns.Add(COL_PAYEENAME_TITLE,            typeof(string));  // �x���於��
            this._custDmdPrcTable.Columns.Add(COL_PAYEENAME2_TITLE,           typeof(string));  // �x���於��2
            this._custDmdPrcTable.Columns.Add(COL_PAYEESNM_TITLE,             typeof(string));  // �x���旪��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_ADDUPDATEJP_TITLE,          typeof(string));  // �v��N����
            // 2009.01.14 Add >>>
            this._custDmdPrcTable.Columns[COL_ADDUPDATEJP_TITLE].Caption = "��������";  // �v��N����
            // 2009.01.14 Add <<<
            this._custDmdPrcTable.Columns.Add(COL_ADDUPYEARMONTHJP_TITLE,     typeof(string));  // �v��N��
            this._custDmdPrcTable.Columns.Add(COL_ADDUPDATE_TITLE,            typeof(Int32));   // _�v��N��
            this._custDmdPrcTable.Columns.Add(COL_ADDUPYEARMONTH_TITLE,       typeof(Int32));   // _�v��N����
            this._custDmdPrcTable.Columns.Add(COL_THISTIMEPAYNRML_TITLE,      typeof(Int64));   // ����x�����z�i�ʏ�x���j
            this._custDmdPrcTable.Columns.Add(COL_THISTIMEFEEPAYNRML_TITLE,   typeof(Int64));   // ����萔���z�i�ʏ�x���j
            this._custDmdPrcTable.Columns.Add(COL_THISTIMEDISPAYNRML_TITLE,   typeof(Int64));   // ����l���z�i�ʏ�x���j
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMERBTDMDNRML_TITLE,   typeof(Int64));   // ���񃊃x�[�g�z�i�ʏ�x���j
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMEDMDDEPO_TITLE,      typeof(Int64));   // ����x�����z�i�a����j
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMEFEEDMDDEPO_TITLE,   typeof(Int64));   // ����萔���z�i�a����j
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMEDISDMDDEPO_TITLE,   typeof(Int64));   // ����l���z�i�a����j
            //this._custDmdPrcTable.Columns.Add(COL_THISTIMERBTDMDDEPO_TITLE,   typeof(Int64));   // ���񃊃x�[�g�z�i�a����j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_THISTIMETTLBLCDMD_TITLE,    typeof(Int64));   // ����J�z�c���i�x���v�j
            //this._custDmdPrcTable.Columns.Add(COL_THISNETSTCKPRICE_TITLE,     typeof(Int64));   // ���E�㍡��d�����z
            //this._custDmdPrcTable.Columns.Add(COL_THISNETSTCPRCTAX_TITLE,      typeof(Int64));   // ���E�㍡��d�������
            this._custDmdPrcTable.Columns.Add(COL_ITDEDOFFSETOUTTAX_TITLE,    typeof(Int64));   // ���E��O�őΏۊz
            this._custDmdPrcTable.Columns.Add(COL_ITDEDOFFSETINTAX_TITLE,     typeof(Int64));   // ���E����őΏۊz
            this._custDmdPrcTable.Columns.Add(COL_ITDEDOFFSETTAXFREE_TITLE,   typeof(Int64));   // ���E���ېőΏۊz
            this._custDmdPrcTable.Columns.Add(COL_OFFSETOUTTAX_TITLE,         typeof(Int64));   // ���E��O�ŏ����
            this._custDmdPrcTable.Columns.Add(COL_OFFSETINTAX_TITLE,          typeof(Int64));   // ���E����ŏ����
            this._custDmdPrcTable.Columns.Add(COL_ITDEDSTCOUTTAX_TITLE,     typeof(Int64));   // �d���O�őΏۊz
            this._custDmdPrcTable.Columns.Add(COL_ITDEDSTCINTAX_TITLE,      typeof(Int64));   // �d�����őΏۊz
            this._custDmdPrcTable.Columns.Add(COL_ITDEDSTCTAXFREE_TITLE,    typeof(Int64));   // �d����ېőΏۊz
            this._custDmdPrcTable.Columns.Add(COL_TTLSTOCKOUTERTAX_TITLE,          typeof(Int64));   // �d���O�Ŋz
            this._custDmdPrcTable.Columns.Add(COL_TTLSTOCKINNERTAX_TITLE,           typeof(Int64));   // �d�����Ŋz
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custDmdPrcTable.Columns.Add(COL_ITDEDPAYMOUTTAX_TITLE,      typeof(Int64));   // �x���O�őΏۊz
            //this._custDmdPrcTable.Columns.Add(COL_ITDEDPAYMINTAX_TITLE,       typeof(Int64));   // �x�����őΏۊz
            //this._custDmdPrcTable.Columns.Add(COL_ITDEDPAYMTAXFREE_TITLE,     typeof(Int64));   // �x����ېőΏۊz
            //this._custDmdPrcTable.Columns.Add(COL_PAYMENTOUTTAX_TITLE,        typeof(Int64));   // �x���O�ŏ����
            //this._custDmdPrcTable.Columns.Add(COL_PAYMENTINTAX_TITLE,         typeof(Int64));   // �x�����ŏ����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_SUPPCTAXLAYCD_TITLE,     typeof(Int32));   // ����œ]�ŕ���
            this._custDmdPrcTable.Columns.Add(COL_SUPPLIERCONSTAXRATE_TITLE,          typeof(Double));  // ����ŗ�
            this._custDmdPrcTable.Columns.Add(COL_FRACTIONPROCCD_TITLE,       typeof(Int32));   // �[�������敪
            this._custDmdPrcTable.Columns.Add(COL_CADDUPUPDEXECDATE_TITLE,    typeof(Int32));   // �����X�V���s�N����
            this._custDmdPrcTable.Columns.Add(COL_DMDPROCNUM_TITLE,           typeof(Int32));   // �x�������ʔ�
            this._custDmdPrcTable.Columns.Add(COL_GUID_TITLE,                 typeof(Guid));    // GUID
            this._custDmdPrcTable.Columns.Add(COL_ACPODRTTL3TMBFBLDMD_TITLE,  typeof(Int64));   // ��3��O�c���i�x���v�j
            this._custDmdPrcTable.Columns.Add(COL_ACPODRTTL2TMBFBLDMD_TITLE,  typeof(Int64));   // ��2��O�c���i�x���v�j
            this._custDmdPrcTable.Columns.Add(COL_LASTTIMEDEMAND_TITLE,       typeof(Int64));   // �O��x�����z
            this._custDmdPrcTable.Columns.Add(COL_THISTIMESTOCKPRICE_TITLE,        typeof(Int64));   // ����d�����z
            this._custDmdPrcTable.Columns.Add(COL_THISSTCPRCTAX_TITLE,         typeof(Int64));   // ����d�������
            this._custDmdPrcTable.Columns.Add(COL_OFSTHISTIMESTOCK_TITLE,     typeof(Int64));   // ���E�㍡��d�����z
            this._custDmdPrcTable.Columns.Add(COL_OFSTHISSTOCKTAX_TITLE,      typeof(Int64));   // ���E�㍡��d�������
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custDmdPrcTable.Columns.Add(COL_TTLINCDTBTTAXEXC_TITLE,     typeof(Int64));   // �x���C���Z���e�B�u�z���v�i�Ŕ����j
            //this._custDmdPrcTable.Columns.Add(COL_TTLINCDTBTTAX_TITLE,        typeof(Int64));   // �x���C���Z���e�B�u�z���v�i�Łj
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_THISTIMEPAYMENT_TITLE,      typeof(Int64));   // ����x��
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
            this._custDmdPrcTable.Columns.Add(COL_TAXADJUST_TITLE, typeof(Int64));   // ����Œ����z
            this._custDmdPrcTable.Columns.Add(COL_TOTALADJUST_TITLE, typeof(Int64));   // �c�������z�\��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            this._custDmdPrcTable.Columns.Add(COL_NONSTMNTAPPEARANCE_TITLE,   typeof(Int64));   // �����ϋ��z�i���U�j
            this._custDmdPrcTable.Columns.Add(COL_NONSTMNTISDONE_TITLE,       typeof(Int64));   // �����ϋ��z�i�􂵁j
            this._custDmdPrcTable.Columns.Add(COL_STMNTAPPEARANCE_TITLE,      typeof(Int64));   // ���ϋ��z�i���U�j
            this._custDmdPrcTable.Columns.Add(COL_STMNTISDONE_TITLE,          typeof(Int64));   // ���ϋ��z�i�􂵁j

            //this._custDmdPrcTable.Columns.Add(COL_THISCASHSTOCKPRICE,          typeof(Int64));   // ���񌻋��d�����z
            //this._custDmdPrcTable.Columns.Add(COL_THISCASHSTOCKTAX,            typeof(Int64));   // ���񌻋��d�x������Ŋz
            this._custDmdPrcTable.Columns.Add(COL_STOCKSLIPCOUNT,             typeof(Int64));   // �d���`�[����
            this._custDmdPrcTable.Columns.Add(COL_BILLPRINTDATE,              typeof(Int64));   // �x�������s��
            this._custDmdPrcTable.Columns.Add(COL_PAYMENTSCHEDULE,        typeof(Int64));   // �x���\���
            this._custDmdPrcTable.Columns.Add(COL_PAYMENTCOND,                typeof(Int64));   // �������
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            this._custDmdPrcTable.Columns.Add(COL_AFCALDEMANDPRICE_TITLE,     typeof(Int64));   // �v�Z��x�����z

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //this._custDmdPrcTable.Columns.Add( COL_THISRECVINNERTAX_TITLE, typeof( Int64 ) );   // �����ŏ���� 
            //this._custDmdPrcTable.Columns.Add( COL_THISRECVINTAX_TITLE, typeof( Int64 ) );   // �����őΏۊz
            //this._custDmdPrcTable.Columns.Add( COL_THISRECVOFFSET_TITLE, typeof( Int64 ) );   // �����摊�E���z
            //this._custDmdPrcTable.Columns.Add( COL_THISRECVOFFSETTAX_TITLE, typeof( Int64 ) );   // �����摊�E�����
            //this._custDmdPrcTable.Columns.Add( COL_THISRECVOUTERTAX_TITLE, typeof( Int64 ) );   // ���O�ŏ����
            //this._custDmdPrcTable.Columns.Add( COL_THISRECVOUTTAX_TITLE, typeof( Int64 ) );   // ���O�őΏۊz
            //this._custDmdPrcTable.Columns.Add( COL_THISRECVTAXFREE_TITLE, typeof( Int64 ) );   // ����ېőΏۊz
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            // 2009.01.14 Add >>>
            this._custDmdPrcTable.Columns.Add(COL_STARTCADDUPUPDDATE_TITLE, typeof(Int32));     // �����X�V�J�n�N����
            this._custDmdPrcTable.Columns.Add(COL_LASTCADDUPUPDDATE_TITLE, typeof(Int32));      // �O������X�V�N����
            this._custDmdPrcTable.Columns.Add(COL_PAYTOTAL, typeof(List<AccPayTotal>));        // �x���W�v�f�[�^
            // 2009.01.14 Add <<<

            // PrimaryKey�ݒ�
            this._custDmdPrcTable.PrimaryKey = new DataColumn[] { this._custDmdPrcTable.Columns[COL_ADDUPSECCODE_TITLE],    // �v�㋒�_�R�[�h
                                                                  this._custDmdPrcTable.Columns[COL_PAYEECODE_TITLE],       // �x����R�[�h
                                                                  this._custDmdPrcTable.Columns[COL_SUPPLIERCODE_TITLE],    // �d����R�[�h
                                                                  // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA ADD START
                                                                  this._custDmdPrcTable.Columns[COL_RESULTSECCODE_TITLE],
                                                                  // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA ADD END
                                                                  this._custDmdPrcTable.Columns[COL_ADDUPDATE_TITLE]};            // �v��N����

            this._bindDataSet.Tables.Add(this._custDmdPrcTable);

            // 2009.01.14 Add >>>
            this._custDmdPrcTotalTable = new DataTable(TBL_CUSTDMDPRCTOTAL_TITLE);
            this._custDmdPrcTotalTable = this._custDmdPrcTable.Clone();
            this._custDmdPrcTotalTable.TableName = TBL_CUSTDMDPRCTOTAL_TITLE;
            this._bindDataSet.Tables.Add(this._custDmdPrcTotalTable);
            // 2009.01.14 Add <<<
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
            if (this._iSuppRsltUpdDB == null)
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
        /// <param name="suplAccPay">�d���攃�|���z�}�X�^�I�u�W�F�N�g</param>
        /// <param name="aCalcPayTotalList">���|�x���W�v�f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^�̏������ݏ������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        // 2009.01.14 >>>
        //public int WriteSuplAccPay(SuplAccPay suplAccPay, out string errMsg)
        public int WriteSuplAccPay(SuplAccPay suplAccPay, List<ACalcPayTotal> aCalcPayTotalList, out string errMsg)
        // 2009.01.14 <<<
        {
            // �d���攃�|���z�}�X�^�X�V
            // 2009.01.14 >>>
            //return this.WriteSuplAccPayProc(suplAccPay, out errMsg);
            return this.WriteSuplAccPayProc(suplAccPay, aCalcPayTotalList, out errMsg);
            // 2009.01.14 <<<
        }

		/// <summary>�d���攃�|���z�}�X�^�������ݏ���(���|)</summary>
        /// <param name="suplAccPay">�d���攃�|���z�}�X�^�I�u�W�F�N�g</param>
        /// <param name="aCalcPayTotalList">���|�x���W�v�f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �d���攃�|���z�}�X�^�̏������ݏ������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        // 2009.01.14 >>>
        //private int WriteSuplAccPayProc(SuplAccPay suplAccPay, out string errMsg)
        private int WriteSuplAccPayProc(SuplAccPay suplAccPay, List<ACalcPayTotal> aCalcPayTotalList, out string errMsg)
        // 2009.01.14 <<<
		{
			int status = 0;
            errMsg     = "";

			try {
                SuplAccPayWork suplAccPayWork = new SuplAccPayWork();

                // �ҏW�O���擾
                if (this._custAccRecDic.ContainsKey(suplAccPay.FileHeaderGuid) == true)
                {
                    suplAccPayWork = (this._custAccRecDic[suplAccPay.FileHeaderGuid] as SuplAccPayWork);
                }

                // �ҏW���擾
                //if ( suplAccPayWork.SupplierCd == suplAccPayWork.PayeeCode ) {
                //    suplAccPayWork.SupplierCd = 0;
                //}
                CopyToSuplAccPayWorkFromSuplAccPay(ref suplAccPayWork, suplAccPay);

                // 2009.01.14 >>>
                //object retObj = (object)suplAccPayWork;

                // �����W�v�f�[�^�̎擾
                ArrayList aCalcPayTotalWorkArrayList = new ArrayList();

                foreach (ACalcPayTotal aCalcPayTotal in aCalcPayTotalList)
                {
                    ACalcPayTotalWork aCalcPayTotalWork = ParamDataFromUIData(aCalcPayTotal);
                    aCalcPayTotalWork.EnterpriseCode = suplAccPayWork.EnterpriseCode;     // ��ƃR�[�h
                    aCalcPayTotalWork.AddUpSecCode = suplAccPayWork.AddUpSecCode;         // �v�㋒�_�R�[�h
                    aCalcPayTotalWork.PayeeCode = suplAccPayWork.PayeeCode;               // �x����R�[�h
                    aCalcPayTotalWork.SupplierCd = suplAccPayWork.PayeeCode;              // �d����R�[�h�i�x������Z�b�g�j
                    aCalcPayTotalWork.AddUpDate = suplAccPayWork.AddUpDate;               // �v��N����
                    aCalcPayTotalWorkArrayList.Add(aCalcPayTotalWork);
                }
                CustomSerializeArrayList dataList = new CustomSerializeArrayList();
                dataList.Add(suplAccPayWork);

                // --- CHG 2009/01/30 ��QID:10605�Ή�------------------------------------------------------>>>>>
                //if (aCalcPayTotalWorkArrayList.Count > 0)
                //{
                //    dataList.Add(aCalcPayTotalWorkArrayList);
                //}
                dataList.Add(aCalcPayTotalWorkArrayList);
                // --- CHG 2009/01/30 ��QID:10605�Ή�------------------------------------------------------<<<<<

                object retObj = (object)dataList;
                // 2009.01.14 <<<

                //�d���攃�|���z�}�X�^��������
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.30 TOKUNAGA MODIFY START
                //status = this._iSuppRsltUpdDB.WriteAccPay(ref retObj, out errMsg);
                status = this._iSuppRsltUpdDB.WriteTotalAccPay(ref retObj, out errMsg);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.30 TOKUNAGA MODIFY END

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �f�[�^�Z�b�g�ɒǉ�
                    // 2009.01.14 >>>
                    //suplAccPayWork = (SuplAccPayWork)retObj;
                    //this.SuplAccPayWorkToDataSet(suplAccPayWork);
                    aCalcPayTotalWorkArrayList = null;

                    if (retObj is CustomSerializeArrayList)
                    {
                        CustomSerializeArrayList retDataList = (CustomSerializeArrayList)retObj;

                        for (int i = 0; i < retDataList.Count; i++)
                        {
                            if (retDataList[i] is SuplAccPayWork)
                            {
                                suplAccPayWork = (SuplAccPayWork)retDataList[i];
                            }
                            if (retDataList[i] is ArrayList)
                            {
                                aCalcPayTotalWorkArrayList = (ArrayList)retDataList[i];
                            }
                        }
                    }

                    this.SuplAccPayWorkToDataSet(suplAccPayWork, aCalcPayTotalWorkArrayList);

                    // ������w��̏ꍇ�͏W�v���R�[�h�֔��f
                    if (suplAccPayWork.SupplierCd == 0)
                    {
                        this.SuplAccPayWorkTotalToDataSet(suplAccPayWork, aCalcPayTotalWorkArrayList);
                    }

                    // 2009.01.14 <<<
                }
			}
			catch(Exception) {
				// �I�t���C������null���Z�b�g
                this._iSuppRsltUpdDB = null;

				// �ʐM�G���[��-1��Ԃ�
				status = -1;
			}

			return status;
		}

        /// <summary>�������ݏ���(�x��)</summary>
        /// <param name="suplierPay">�d����x�����z�}�X�^�I�u�W�F�N�g</param>
        /// <param name="accPayTotalList">���Z�x���W�v�f�[�^���X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�̏������ݏ������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.14 >>>
        //public int WriteSuplierPay(SuplierPay suplierPay, out string errMsg)
        public int WriteSuplierPay(SuplierPay suplierPay, List<AccPayTotal> accPayTotalList, out string errMsg)
        // 2009.01.14 <<<
        {
            // �d����x�����z�}�X�^�X�V
            // 2009.01.14 >>>
            //return this.WriteSuplierPayProc(suplierPay, out errMsg);
            return this.WriteSuplierPayProc(suplierPay, accPayTotalList, out errMsg);
            // 2009.01.14 <<<
        }

        /// <summary>�d����x�����z�}�X�^�������ݏ���(���|)</summary>
        /// <param name="suplierPay">�d����x�����z�}�X�^�I�u�W�F�N�g</param>
        /// <param name="accPayTotalList">���Z�x���W�v�f�[�^���X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d����x�����z�}�X�^�̏������ݏ������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.14 >>>
        //private int WriteSuplierPayProc(SuplierPay suplierPay, out string errMsg)
        private int WriteSuplierPayProc(SuplierPay suplierPay, List<AccPayTotal> accPayTotalList, out string errMsg)
        // 2009.01.14 <<<
        {
			int status = 0;
            errMsg     = "";

            try
            {
                SuplierPayWork suplierPayWork = new SuplierPayWork();

                // �ҏW�O���擾
                if (this._custDmdPrcDic.ContainsKey(suplierPay.FileHeaderGuid) == true)
                {
                    suplierPayWork = (this._custDmdPrcDic[suplierPay.FileHeaderGuid] as SuplierPayWork);
                }

                // �ҏW���擾
                //if (suplierPayWork.SupplierCd == suplierPayWork.PayeeCode)
                //{
                //    suplierPayWork.SupplierCd = 0;
                //}
                CopyToSuplierPayWorkFromSuplierPay(ref suplierPayWork, suplierPay);

                // 2009.01.14 >>>
                //object retObj = (object)suplierPayWork;
                // �����W�v�f�[�^�̎擾
                ArrayList accPayTotalWorkArrayList = new ArrayList();

                foreach (AccPayTotal accPayTotal in accPayTotalList)
                {
                    AccPayTotalWork accPayTotalWork = ParamDataFromUIData(accPayTotal);
                    accPayTotalWork.EnterpriseCode = suplierPayWork.EnterpriseCode;     // ��ƃR�[�h
                    accPayTotalWork.AddUpSecCode = suplierPayWork.AddUpSecCode;         // �v�㋒�_�R�[�h
                    accPayTotalWork.PayeeCode = suplierPayWork.PayeeCode;               // �x����R�[�h
                    accPayTotalWork.SupplierCd = suplierPayWork.PayeeCode;              // �d����R�[�h�i�x������Z�b�g�j
                    accPayTotalWork.AddUpDate = suplierPayWork.AddUpDate;               // �v��N����
                    accPayTotalWorkArrayList.Add(accPayTotalWork);
                }
                CustomSerializeArrayList dataList = new CustomSerializeArrayList();
                dataList.Add(suplierPayWork);

                // --- ADD 2009/01/30 ��QID:10605�Ή�------------------------------------------------------>>>>>
                //if (accPayTotalWorkArrayList.Count > 0)
                //{
                //    dataList.Add(accPayTotalWorkArrayList);
                //}
                dataList.Add(accPayTotalWorkArrayList);
                // --- ADD 2009/01/30 ��QID:10605�Ή�------------------------------------------------------<<<<<

                object retObj = (object)dataList;
                // 2009.01.14 <<<

                //�d����x�����z�}�X�^��������
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.30 TOKUNAGA MODIFY START
                //status = this._iSuppRsltUpdDB.WriteSuplierPay(ref retObj, out errMsg);
                //System.Windows.Forms.MessageBox.Show(suplierPayWork.AddUpSecCode);
                status = this._iSuppRsltUpdDB.WriteTotalSuplierPay(ref retObj, out errMsg);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.30 TOKUNAGA MODIFY END
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 2009.01.14 >>>
                    //// �f�[�^�Z�b�g�ɒǉ�
                    //suplierPayWork = (SuplierPayWork)retObj;
                    //this.SuplierPayWorkToDataSet(suplierPayWork);

                    accPayTotalWorkArrayList = null;

                    if (retObj is CustomSerializeArrayList)
                    {
                        CustomSerializeArrayList retDataList = (CustomSerializeArrayList)retObj;

                        for (int i = 0; i < retDataList.Count; i++)
                        {
                            if (retDataList[i] is SuplierPayWork)
                            {
                                suplierPayWork = (SuplierPayWork)retDataList[i];
                            }
                            if (retDataList[i] is ArrayList)
                            {
                                accPayTotalWorkArrayList = (ArrayList)retDataList[i];
                            }
                        }
                    }

                    this.SuplierPayWorkToDataSet(suplierPayWork, accPayTotalWorkArrayList);

                    // ������w��̏ꍇ�͏W�v���R�[�h�֔��f
                    if (suplierPayWork.SupplierCd == 0)
                    {
                        this.SuplierPayWorkTotalToDataSet(suplierPayWork, accPayTotalWorkArrayList);
                    }
                    // 2009.01.14 <<<
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iSuppRsltUpdDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
		#region Delete Methods

		/// <summary>�����폜����</summary>
        /// <param name="suplAccPay">�d���攃�|���z�}�X�^�N���X</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^���̕����폜�������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        public int DeleteSuplAccPay(SuplAccPay suplAccPay)
        {
            // �d���攃�|���z�}�X�^�����폜
            return this.DeleteSuplAccPayProc(suplAccPay);
        }

		/// <summary>�d���攃�|���z�}�X�^�����폜����</summary>
        /// <param name="suplAccPay">�d���攃�|���z�}�X�^�N���X</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �d���攃�|���z�}�X�^�̕����폜�������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        private int DeleteSuplAccPayProc(SuplAccPay suplAccPay)
        {
            int status = 0;

            try
            {
                // �ҏW�O���擾
                SuplAccPayWork suplAccPayWork = new SuplAccPayWork();

                // �ҏW�O���擾
                if (this._custAccRecDic.ContainsKey(suplAccPay.FileHeaderGuid) == true)
                {
                    suplAccPayWork = (this._custAccRecDic[suplAccPay.FileHeaderGuid] as SuplAccPayWork);
                }

                CopyToSuplAccPayWorkFromSuplAccPay(ref suplAccPayWork, suplAccPay);

                // 2009.01.14 >>>
                //object paraObj = (object)suplAccPayWork;
                CustomSerializeArrayList dataList = new CustomSerializeArrayList();
                dataList.Add(suplAccPayWork);
                object paraObj = (object)dataList;
                // 2009.01.14 <<<

                // �d���攃�|���z�}�X�^�����폜
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.30 TOKUNAGA MODIFY START
                //status = this._iSuppRsltUpdDB.DeleteAccPay(paraObj);
                status = this._iSuppRsltUpdDB.DeleteTotalAccPay(paraObj);
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.30 TOKUNAGA MODIFY END

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �ڍ׃O���b�h�p�L���b�V���e�[�u������폜
                    this._custAccRecDic.Remove(suplAccPay.FileHeaderGuid);
                    // �f�[�^�e�[�u������폜
                    object[] key = { suplAccPay.AddUpSecCode, suplAccPay.PayeeCode, suplAccPay.SupplierCd, TDateTime.DateTimeToLongDate(suplAccPay.AddUpDate) };
                    DataRow dr = this._custAccRecTable.Rows.Find(key);
                    dr.Delete();
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iSuppRsltUpdDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }

        /// <summary>�����폜����</summary>
        /// <param name="suplierPay">�d����x�����z</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̕����폜�������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public int DeleteSuplierPay(SuplierPay suplierPay)
        {
            // �d����x�����z�}�X�^�����폜
            return this.DeleteSuplierPayProc(suplierPay);
        }

        /// <summary>�d����x�����z�}�X�^�����폜����</summary>
        /// <param name="suplierPay">�d����x�����z�}�X�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d����x�����z�}�X�^�̕����폜�������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int DeleteSuplierPayProc(SuplierPay suplierPay)
        {
            int status = 0;

            try
            {
                // �ҏW�O���擾
                SuplierPayWork suplierPayWork = new SuplierPayWork();

                // �ҏW�O���擾
                if (this._custDmdPrcDic.ContainsKey(suplierPay.FileHeaderGuid) == true)
                {
                    suplierPayWork = (this._custDmdPrcDic[suplierPay.FileHeaderGuid] as SuplierPayWork);
                }

                CopyToSuplierPayWorkFromSuplierPay(ref suplierPayWork, suplierPay);

                // �d����x�����z�}�X�^�����폜
                // 2009.01.14 >>>
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.30 TOKUNAGA MODIFY START
                ////status = this._iSuppRsltUpdDB.DeleteSuplierPay(suplierPayWork);
                //status = this._iSuppRsltUpdDB.DeleteTotalSuplierPay(suplierPayWork);
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.30 TOKUNAGA MODIFY END

                CustomSerializeArrayList dataList = new CustomSerializeArrayList();
                dataList.Add(suplierPayWork);
                object paraObj = (object)dataList;
                status = this._iSuppRsltUpdDB.DeleteTotalSuplierPay(paraObj);
                // 2009.01.14 <<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �ڍ׃O���b�h�p�L���b�V���e�[�u������폜
                    this._custDmdPrcDic.Remove(suplierPay.FileHeaderGuid);
                    // �f�[�^�e�[�u������폜
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA MODIFY START
                    // ResultSectCd���L�[�ɑ��������ߒǉ�
                    object[] key = { suplierPay.AddUpSecCode, suplierPay.PayeeCode, suplierPay.SupplierCd, suplierPay.ResultsSectCd, TDateTime.DateTimeToLongDate(suplierPay.AddUpDate) };
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA MODIFY END

                    DataRow dr = this._custDmdPrcTable.Rows.Find(key);
                    dr.Delete();
                }
            }
            catch (Exception ex)
            {

                // �I�t���C������null���Z�b�g
                this._iSuppRsltUpdDB = null;

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
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�͌����ΏۊO�ł��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        public int SearchSuplAccPay(out int totalCount, string enterpriseCode, string sectionCode, Int32 payeeCode, Int32 customerCode)
        {
            // �d���攃�|���z�}�X�^����
            return this.SearchSuplAccPayProc(out totalCount, enterpriseCode, sectionCode, payeeCode, customerCode, ConstantManagement.LogicalMode.GetData0);
        }

        /// <summary>��������(�_���폜�܂�)(���|)</summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�������ΏۂɊ܂݂܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public int SearchSuplAccPayAll(out int totalCount, string enterpriseCode, string sectionCode, Int32 payeeCode, Int32 customerCode)
        {
            // �d���攃�|���z�}�X�^����
            return this.SearchSuplAccPayProc(out totalCount, enterpriseCode, sectionCode, payeeCode, customerCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>��������(���|)</summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <param name="payeeCode">�x����R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        private int SearchSuplAccPayProc(out int totalCount, string enterpriseCode, string sectionCode, Int32 payeeCode, Int32 supplierCd, ConstantManagement.LogicalMode logicalMode)
        {
            int status1 = 0;
            int status2 = 0;

            // �d���攃�|���z�}�X�^����
            status1 = this.SearchSuplAccPayProc2(out totalCount, enterpriseCode, sectionCode, payeeCode, supplierCd, logicalMode);
            if (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status1;
            }

            // �L���b�V������
            // 2009.01.14 >>>
            //status2 = this.CacheSuplAccPay(this._custAccRecList);
            status2 = this.CacheSuplAccPay(this._custAccRecList, sectionCode, payeeCode, supplierCd);
            // 2009.01.14 <<<
            if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status2;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>�d���攃�|���z�}�X�^��������(���|)</summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d���攃�|���z�}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.03.08</br>
        /// </remarks>
        private int SearchSuplAccPayProc2(out int totalCount, string enterpriseCode, string sectionCode, Int32 payeeCode, Int32 customerCode, ConstantManagement.LogicalMode logicalMode)
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

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.30 TOKUNAGA DEL START
                // �f�[�^�̊Ǘ��͐e�q�ɕύX���ꂽ���߂��̕����͕s�v
                // �d���攃�|���z�}�X�^����
                //if ( customerCode == payeeCode ) {
                //    customerCode = 0;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.30 TOKUNAGA DEL END

                status = this._iSuppRsltUpdDB.SearchAccPay(enterpriseCode,sectionCode,payeeCode,customerCode,0,out retobj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 2009.01.14 >>>
                    //this._custAccRecList = retobj as ArrayList;
                    this._custAccRecList = retobj as CustomSerializeArrayList;
                    // 2009.01.14 <<<

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
                this._iSuppRsltUpdDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }

        /// <summary>��������(�_���폜����)(�x��)</summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�͌����ΏۊO�ł��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// <br>-------------------------</br>
        /// <br>Note       : �����Ɏ��ы��_�R�[�h��ǉ�</br>
        /// <br>Modifier   : ���i �r��</br>
        /// <br>Date       : 2008.06.24</br>
        /// </remarks>
        public int SearchSuplierPay(out int totalCount, string enterpriseCode, string sectionCode, Int32 payeeCode, string resultSectCode, Int32 supplierCode)
        {
            // �d����x�����z�}�X�^����
            return this.SearchSuplierPayProc(out totalCount, enterpriseCode, sectionCode, payeeCode, resultSectCode, supplierCode, ConstantManagement.LogicalMode.GetData0);
        }

        /// <summary>��������(�_���폜�܂�)(�x��)</summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <param name="payeeCode">�d����R�[�h</param>
        /// <param name="resultSectCode">���ы��_�R�[�h</param>
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
        public int SearchSuplierPayAll(out int totalCount, string enterpriseCode, string sectionCode, Int32 payeeCode, string resultSectCode, Int32 supplierCode)
        {
            // �d����x�����z�}�X�^����
            return this.SearchSuplierPayProc(out totalCount, enterpriseCode, sectionCode, payeeCode, resultSectCode, supplierCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>��������(�x��)</summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <param name="payeeCode">�x����R�[�h</param>
        /// <param name="resultSectCode">���ы��_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
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
        private int SearchSuplierPayProc(out int totalCount, string enterpriseCode, string sectionCode, Int32 payeeCode, string resultSectCode, Int32 supplierCd, ConstantManagement.LogicalMode logicalMode)
        {
            int status1 = 0;
            int status2 = 0;

            // �d����x�����z�}�X�^����
            status1 = this.SearchSuplierPayProc2(out totalCount, enterpriseCode, sectionCode, payeeCode, resultSectCode, supplierCd, logicalMode);
            if (status1 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status1;
            }

            // �L���b�V������
            // 2009.01.14 >>>
            //status2 = this.CacheSuplierPay(this._custDmdPrcList);
            status2 = this.CacheSuplierPay(this._custDmdPrcList, sectionCode, resultSectCode, payeeCode, supplierCd);
            // 2009.01.14 <<<
            if (status2 != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status2;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>�d����x�����z�}�X�^��������</summary>
        /// <param name="totalCount">�擾����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <param name="payeeCode">�d����R�[�h</param>
        /// <param name="resultSectCode">���ы��_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d����x�����z�}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.03.08</br>
        /// <br>-------------------------</br>
        /// <br>Note       : �����Ɏ��ы��_�R�[�h��ǉ�</br>
        /// <br>Modifier   : ���i �r��</br>
        /// <br>Date       : 2008.06.24</br>
        /// </remarks>
        private int SearchSuplierPayProc2(out int totalCount, string enterpriseCode, string sectionCode, Int32 payeeCode, string resultSectCode, Int32 customerCode, ConstantManagement.LogicalMode logicalMode)
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

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.30 TOKUNAGA DEL START
                // �f�[�^�̊Ǘ����e�q�X�V�ɕς�������s�v
                // �d����x�����z�}�X�^����
                //if ( customerCode == payeeCode ) {
                //    customerCode = 0;
                //}
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.30 TOKUNAGA DEL END
                status = this._iSuppRsltUpdDB.SearchSuplierPay(enterpriseCode, sectionCode, payeeCode, resultSectCode, customerCode, 0, out retobj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 2009.01.14 >>>
                    //this._custDmdPrcList = retobj as ArrayList;
                    this._custDmdPrcList = retobj as CustomSerializeArrayList;
                    // 2009.01.14 <<<

                    // �Y�������i�[
                    totalCount = this._custDmdPrcList.Count;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_EOF)
                {
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iSuppRsltUpdDB = null;

                // �ʐM�G���[��-1��Ԃ�
                status = -1;
            }

            return status;
        }

        #endregion

        // --------------------------------------------------
        #region Cache Methods

        /// <summary>�}�X�^�L���b�V������(���|)</summary>
        /// <param name="custAccRecList">�d���攃�|���z�}�X�^�擾���ʃ��X�g</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="payeeCode">�x����R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̃L���b�V���������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.14 >>>
        //public int CacheSuplAccPay(ArrayList custAccRecList)
        public int CacheSuplAccPay(ArrayList custAccRecList, string sectionCode, Int32 payeeCode, Int32 supplierCd)
        // 2009.01.14 <<<
        {
            try
            {
                try
                {
                    // �X�V�����J�n
                    this._custAccRecTable.BeginLoadData();
                    this._custAccRecTotalTable.BeginLoadData(); // 2009.01.14 Add

                    // �e�[�u�����N���A
                    this._custAccRecTable.Clear();
                    this._custAccRecTotalTable.Clear(); // 2009.01.14 Add

                    // 2009.01.14 >>>
                    //// �d���攃�|���z�}�X�^�f�[�^��DataSet�Ɋi�[
                    //foreach (SuplAccPayWork suplAccPayWork in custAccRecList)
                    //{
                    //    // ���o�^�̎�
                    //    if (this._custAccRecDic.ContainsKey(suplAccPayWork.FileHeaderGuid) == false)
                    //    {
                    //        // �f�[�^�Z�b�g�ɒǉ�
                    //        this.SuplAccPayWorkToDataSet(suplAccPayWork);
                    //    }
                    //}

                    for (int i = 0; i < custAccRecList.Count; i++)
                    {
                        if (custAccRecList[i] is ArrayList)
                        {
                            ArrayList accDataArrayList = (ArrayList)custAccRecList[i];

                            SuplAccPayWork suplAccPayWork = null;
                            SuplAccPayWork suplAccPayWorkTotal = null;
                            ArrayList aCalcPayTotalWorkArrayList = null;

                            for (int n = 0; n < accDataArrayList.Count; n++)
                            {
                                if (accDataArrayList[n] is ArrayList)
                                {
                                    ArrayList data = (ArrayList)accDataArrayList[n];
                                    if (data.Count > 0)
                                    {
                                        if (data[0] is SuplAccPayWork)
                                        {
                                            if (data.Count > 0)
                                            {
                                                foreach (SuplAccPayWork suplAccPayWorkWk in data)
                                                {
                                                    if (suplAccPayWorkWk.SupplierCd == 0)
                                                    {
                                                        suplAccPayWorkTotal = suplAccPayWorkWk;
                                                    }

                                                    if (( suplAccPayWorkWk.AddUpSecCode.Trim() == sectionCode.Trim() ) &&
                                                        ( suplAccPayWorkWk.PayeeCode == payeeCode ) &&
                                                        ( suplAccPayWorkWk.SupplierCd == supplierCd ))
                                                    {
                                                        suplAccPayWork = suplAccPayWorkWk;
                                                    }
                                                }
                                            }
                                        }
                                        else if (data[0] is ACalcPayTotalWork)
                                        {
                                            // �����f�[�^�̃��X�g
                                            aCalcPayTotalWorkArrayList = data;
                                        }
                                    }
                                }
                            }
                            // �W�v���R�[�h�ƃp�����[�^������Ȃ��\��������(���_)�̂ŔO�̂���
                            if (( supplierCd == 0 ) && ( suplAccPayWorkTotal != null ))
                            {
                                if (suplAccPayWork == null) suplAccPayWork = suplAccPayWorkTotal;
                            }
                            if (suplAccPayWork != null)
                            {
                                // ���o�^�̎�
                                if (this._custAccRecDic.ContainsKey(suplAccPayWork.FileHeaderGuid) == false)
                                {
                                    // �f�[�^�Z�b�g�ɒǉ�
                                    this.SuplAccPayWorkToDataSet(suplAccPayWork, ( suplAccPayWork.SupplierCd == 0 ) ? aCalcPayTotalWorkArrayList : null);
                                }
                            }
                            if (suplAccPayWorkTotal != null)
                            {
                                this.SuplAccPayWorkTotalToDataSet(suplAccPayWorkTotal, aCalcPayTotalWorkArrayList);
                            }
                        }
                    }
                    // 2009.01.14 <<<
                }
                finally
                {
                    // �X�V�����I��
                    this._custAccRecTable.EndLoadData();
                    this._custAccRecTotalTable.EndLoadData();   // 2009.01.14 Add
                }
            }
            catch (Exception)
            {
                return -1;
            }

            return 0;
        }

        /// <summary>�}�X�^�L���b�V������(�x��)</summary>
        /// <param name="custDmdPrcList">�d����x�����z�}�X�^�擾���ʃ��X�g</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="resultSecCode">���ьv�㋒�_�R�[�h</param>
        /// <param name="payeeCode">�x����R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^���̃L���b�V���������s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.14 >>>
        //public int CacheSuplierPay(ArrayList custDmdPrcList)
        public int CacheSuplierPay(ArrayList custDmdPrcList, string sectionCode, string resultSecCode, Int32 payeeCode, Int32 supplierCd)
        //string sectionCode, string resultSecCode, Int32 claimCode, Int32 customerCode
        // 2009.01.14 <<<
        {
            try
            {
                try
                {
                    // �X�V�����J�n
                    this._custDmdPrcTable.BeginLoadData();
                    this._custDmdPrcTotalTable.BeginLoadData(); // 2009.01.14 Add

                    // �e�[�u�����N���A
                    this._custDmdPrcTable.Clear();
                    this._custDmdPrcTotalTable.Clear();     // 2009.01.14 Add

                    // 2009.01.14 >>>
                    //// �d����x�����z�}�X�^�f�[�^��DataSet�Ɋi�[
                    //foreach (SuplierPayWork suplierPayWork in custDmdPrcList)
                    //{
                    //    // ���o�^�̎�
                    //    if (this._custDmdPrcDic.ContainsKey(suplierPayWork.FileHeaderGuid) == false)
                    //    {
                    //        // �f�[�^�Z�b�g�ɒǉ�
                    //        this.SuplierPayWorkToDataSet(suplierPayWork);
                    //    }
                    //}

                    for (int i = 0; i < custDmdPrcList.Count; i++)
                    {
                        if (custDmdPrcList[i] is ArrayList)
                        {
                            ArrayList dmdDataArrayList = (ArrayList)custDmdPrcList[i];

                            SuplierPayWork suplierPayWork = null;
                            SuplierPayWork suplierPayWorkTotal = null;
                            ArrayList accPayTotalWorkArrayList = null;

                            for (int n = 0; n < dmdDataArrayList.Count; n++)
                            {
                                if (dmdDataArrayList[n] is ArrayList)
                                {
                                    ArrayList data = (ArrayList)dmdDataArrayList[n];
                                    if (data.Count > 0)
                                    {
                                        if (data[0] is SuplierPayWork)
                                        {
                                            if (data.Count > 0)
                                            {
                                                foreach (SuplierPayWork suplierPayWorkWk in data)
                                                {
                                                    if (( suplierPayWorkWk.ResultsSectCd.Trim() == ALL_SECTION ) && ( suplierPayWorkWk.SupplierCd == 0 ))
                                                    {
                                                        suplierPayWorkTotal = suplierPayWorkWk;
                                                    }

                                                    if (( suplierPayWorkWk.AddUpSecCode.Trim() == sectionCode.Trim() ) &&
                                                        ( suplierPayWorkWk.ResultsSectCd.Trim() == resultSecCode.Trim() ) &&
                                                        ( suplierPayWorkWk.PayeeCode == payeeCode ) &&
                                                        ( suplierPayWorkWk.SupplierCd == supplierCd ))
                                                    {
                                                        suplierPayWork = suplierPayWorkWk;
                                                    }
                                                }
                                            }
                                        }
                                        else if (data[0] is AccPayTotalWork)
                                        {
                                            // �����f�[�^�̃��X�g
                                            accPayTotalWorkArrayList = data;
                                        }
                                    }
                                }
                            }

                            // �W�v���R�[�h�ƃp�����[�^������Ȃ��\��������(���_)�̂ŔO�̂���
                            if (( supplierCd == 0 ) && ( suplierPayWorkTotal != null ))
                            {
                                if (suplierPayWork == null) suplierPayWork = suplierPayWorkTotal;
                            }
                            if (suplierPayWork != null)
                            {
                                // ���o�^�̎�
                                if (this._custDmdPrcDic.ContainsKey(suplierPayWork.FileHeaderGuid) == false)
                                {
                                    // �f�[�^�Z�b�g�ɒǉ�
                                    this.SuplierPayWorkToDataSet(suplierPayWork, ( suplierPayWork.SupplierCd == 0 ) ? accPayTotalWorkArrayList : null);
                                }
                            }
                            if (suplierPayWorkTotal != null)
                            {
                                this.SuplierPayWorkTotalToDataSet(suplierPayWorkTotal, accPayTotalWorkArrayList);
                            }
                        }
                    }
                    // 2009.01.14 <<<
                }
                finally
                {
                    // �X�V�����I��
                    this._custDmdPrcTable.EndLoadData();
                    this._custDmdPrcTotalTable.EndLoadData();   // 2009.01.14 Add
                }
            }
            catch (Exception)
            {
                return -1;
            }

            return 0;
        }

        #endregion

        // --------------------------------------------------
        #region MemberCopy Methods

        /// <summary>�N���X�����o�R�s�[���� (��ʕύX�d���攃�|���z�}�X�^�N���X�ˎd���攃�|���z�}�X�^���[�N�N���X)</summary>
        /// <param name="suplAccPayWork">�d���攃�|���z�}�X�^���[�N�N���X</param>
        /// <param name="suplAccPay">�d���攃�|���z�}�X�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ��ʕύX�d���攃�|���z�}�X�^�N���X����
        ///                  �d���攃�|���z�}�X�^���[�N�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        private void CopyToSuplAccPayWorkFromSuplAccPay(ref SuplAccPayWork suplAccPayWork, SuplAccPay suplAccPay)
        {
            # region // �폜
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplAccPayWork.EnterpriseCode       = suplAccPay.EnterpriseCode;
            //suplAccPayWork.AddUpSecCode         = suplAccPay.AddUpSecCode;
            //suplAccPayWork.CustomerCode         = suplAccPay.CustomerCode;
            //suplAccPayWork.CustomerName         = suplAccPay.CustomerName;
            //suplAccPayWork.CustomerName2        = suplAccPay.CustomerName2;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplAccPayWork.CustomerSnm          = suplAccPay.CustomerSnm;
            //suplAccPayWork.PayeeCode            = suplAccPay.PayeeCode;
            //suplAccPayWork.PayeeName            = suplAccPay.PayeeName;
            //suplAccPayWork.PayeeName2           = suplAccPay.PayeeName2;
            //suplAccPayWork.PayeeSnm             = suplAccPay.PayeeSnm;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplAccPayWork.AddUpDate            = TDateTime.LongDateToDateTime(suplAccPay.AddUpDate);
            ////suplAccPayWork.AddUpYearMonth       = TDateTime.LongDateToDateTime(suplAccPay.AddUpYearMonth);
            //suplAccPayWork.AddUpDate = suplAccPay.AddUpDate;
            //suplAccPayWork.AddUpYearMonth = suplAccPay.AddUpYearMonth;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //suplAccPayWork.LastTimeAccPay       = suplAccPay.LastTimeAccPay;
            //suplAccPayWork.ThisTimePayNrml      = suplAccPay.ThisTimePayNrml;
            //suplAccPayWork.ThisTimeFeePayNrml   = suplAccPay.ThisTimeFeePayNrml;
            //suplAccPayWork.ThisTimeDisPayNrml   = suplAccPay.ThisTimeDisPayNrml;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplAccPayWork.ThisTimeRbtDmdNrml   = suplAccPay.ThisTimeRbtDmdNrml;
            ////suplAccPayWork.ThisTimeDmdDepo      = suplAccPay.ThisTimeDmdDepo;
            ////suplAccPayWork.ThisTimeFeeDmdDepo   = suplAccPay.ThisTimeFeeDmdDepo;
            ////suplAccPayWork.ThisTimeDisDmdDepo   = suplAccPay.ThisTimeDisDmdDepo;
            ////suplAccPayWork.ThisTimeRbtDmdDepo   = suplAccPay.ThisTimeRbtDmdDepo;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //suplAccPayWork.ThisTimeTtlBlcAcPay    = suplAccPay.ThisTimeTtlBlcAcPay;
            //suplAccPayWork.ThisTimeStockPrice        = suplAccPay.ThisTimeStockPrice;
            //suplAccPayWork.ThisStcPrcTax         = suplAccPay.ThisStcPrcTax;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplAccPayWork.TtlIncDtbtTaxExc     = suplAccPay.TtlIncDtbtTaxExc;
            ////suplAccPayWork.TtlIncDtbtTax        = suplAccPay.TtlIncDtbtTax;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //suplAccPayWork.ThisNetStckPrice     = suplAccPay.ThisNetStckPrice;
            //suplAccPayWork.ThisNetStcPrcTax      = suplAccPay.ThisNetStcPrcTax;
            //suplAccPayWork.ItdedOffsetOutTax    = suplAccPay.ItdedOffsetOutTax;
            //suplAccPayWork.ItdedOffsetInTax     = suplAccPay.ItdedOffsetInTax;
            //suplAccPayWork.ItdedOffsetTaxFree   = suplAccPay.ItdedOffsetTaxFree;
            //suplAccPayWork.OffsetOutTax         = suplAccPay.OffsetOutTax;
            //suplAccPayWork.OffsetInTax          = suplAccPay.OffsetInTax;
            //suplAccPayWork.TtlItdedStcOutTax = suplAccPay.TtlItdedStcOutTax;
            //suplAccPayWork.TtlItdedStcInTax = suplAccPay.TtlItdedStcInTax;
            //suplAccPayWork.TtlItdedStcTaxFree = suplAccPay.TtlItdedStcTaxFree;
            //suplAccPayWork.TtlStockOuterTax = suplAccPay.TtlStockOuterTax;
            //suplAccPayWork.TtlStockInnerTax = suplAccPay.TtlStockInnerTax;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplAccPayWork.ItdedPaymOutTax      = suplAccPay.ItdedPaymOutTax;
            ////suplAccPayWork.ItdedPaymInTax       = suplAccPay.ItdedPaymInTax;
            ////suplAccPayWork.ItdedPaymTaxFree     = suplAccPay.ItdedPaymTaxFree;
            ////suplAccPayWork.PaymentOutTax        = suplAccPay.PaymentOutTax;
            ////suplAccPayWork.PaymentInTax         = suplAccPay.PaymentInTax;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplAccPayWork.TtlItdedRetOutTax    = suplAccPay.TtlItdedRetOutTax;
            //suplAccPayWork.TtlItdedRetInTax     = suplAccPay.TtlItdedRetInTax;
            //suplAccPayWork.TtlItdedRetTaxFree   = suplAccPay.TtlItdedRetTaxFree;
            //suplAccPayWork.TtlRetOuterTax       = suplAccPay.TtlRetOuterTax;
            //suplAccPayWork.TtlRetInnerTax       = suplAccPay.TtlRetInnerTax;
            //suplAccPayWork.TtlItdedDisOutTax    = suplAccPay.TtlItdedDisOutTax;
            //suplAccPayWork.TtlItdedDisInTax     = suplAccPay.TtlItdedDisInTax;
            //suplAccPayWork.TtlItdedDisTaxFree   = suplAccPay.TtlItdedDisTaxFree;
            //suplAccPayWork.TtlDisOuterTax       = suplAccPay.TtlDisOuterTax;
            //suplAccPayWork.TtlDisInnerTax       = suplAccPay.TtlDisInnerTax;
            //suplAccPayWork.BalanceAdjust        = suplAccPay.BalanceAdjust;
            //suplAccPayWork.ThisCashStockPrice    = suplAccPay.ThisCashStockPrice;
            //suplAccPayWork.ThisCashStockTax      = suplAccPay.ThisCashStockTax;
            //suplAccPayWork.ThisStckPricRgds    = suplAccPay.ThisStckPricRgds;
            //suplAccPayWork.ThisStckPricDis     = suplAccPay.ThisStckPricDis;
            //suplAccPayWork.ThisStcPrcTaxRgds  = suplAccPay.ThisStcPrcTaxRgds;
            //suplAccPayWork.ThisStcPrcTaxDis   = suplAccPay.ThisStcPrcTaxDis;
            //suplAccPayWork.NonStmntAppearance   = suplAccPay.NonStmntAppearance;
            //suplAccPayWork.NonStmntIsdone       = suplAccPay.NonStmntIsdone;
            //suplAccPayWork.StmntAppearance      = suplAccPay.StmntAppearance;
            //suplAccPayWork.StmntIsdone          = suplAccPay.StmntIsdone;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //suplAccPayWork.SuppCTaxLayCd     = suplAccPay.SuppCTaxLayCd;
            //suplAccPayWork.SupplierConsTaxRate          = suplAccPay.SupplierConsTaxRate;
            //suplAccPayWork.FractionProcCd       = suplAccPay.FractionProcCd;
            //suplAccPayWork.StckTtlAccPayBalance    = suplAccPay.StckTtlAccPayBalance;
            //suplAccPayWork.StckTtl2TmBfBlAccPay = suplAccPay.StckTtl2TmBfBlAccPay;
            //suplAccPayWork.StckTtl3TmBfBlAccPay = suplAccPay.StckTtl3TmBfBlAccPay;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplAccPayWork.MonthAddUpExpDate    = TDateTime.LongDateToDateTime(suplAccPay.MonthAddUpExpDate);
            //suplAccPayWork.MonthAddUpExpDate = suplAccPay.MonthAddUpExpDate;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            # endregion

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            suplAccPayWork.CreateDateTime = suplAccPay.CreateDateTime; // �쐬����
            suplAccPayWork.UpdateDateTime = suplAccPay.UpdateDateTime; // �X�V����
            suplAccPayWork.EnterpriseCode = suplAccPay.EnterpriseCode; // ��ƃR�[�h
            suplAccPayWork.FileHeaderGuid = suplAccPay.FileHeaderGuid; // GUID
            suplAccPayWork.UpdEmployeeCode = suplAccPay.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            suplAccPayWork.UpdAssemblyId1 = suplAccPay.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            suplAccPayWork.UpdAssemblyId2 = suplAccPay.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            suplAccPayWork.LogicalDeleteCode = suplAccPay.LogicalDeleteCode; // �_���폜�敪
            suplAccPayWork.AddUpSecCode = suplAccPay.AddUpSecCode; // �v�㋒�_�R�[�h
            suplAccPayWork.PayeeCode = suplAccPay.PayeeCode; // �x����R�[�h
            suplAccPayWork.PayeeName = suplAccPay.PayeeName; // �x���於��
            suplAccPayWork.PayeeName2 = suplAccPay.PayeeName2; // �x���於��2
            suplAccPayWork.PayeeSnm = suplAccPay.PayeeSnm; // �x���旪��
            suplAccPayWork.SupplierCd = suplAccPay.SupplierCd; // ���Ӑ�R�[�h
            suplAccPayWork.SupplierNm1 = suplAccPay.SupplierNm1; // ���Ӑ於��
            suplAccPayWork.SupplierNm2 = suplAccPay.SupplierNm2; // ���Ӑ於��2
            suplAccPayWork.SupplierSnm = suplAccPay.SupplierSnm; // ���Ӑ旪��
            suplAccPayWork.AddUpDate = suplAccPay.AddUpDate; // �v��N����
            suplAccPayWork.AddUpYearMonth = suplAccPay.AddUpYearMonth; // �v��N��
            suplAccPayWork.LastTimeAccPay = suplAccPay.LastTimeAccPay; // �O�񔃊|���z
            suplAccPayWork.ThisTimeFeePayNrml = suplAccPay.ThisTimeFeePayNrml; // ����萔���z�i�ʏ�x���j
            suplAccPayWork.ThisTimeDisPayNrml = suplAccPay.ThisTimeDisPayNrml; // ����l���z�i�ʏ�x���j
            suplAccPayWork.ThisTimePayNrml = suplAccPay.ThisTimePayNrml; // ����x�����z�i�ʏ�x���j
            suplAccPayWork.ThisTimeTtlBlcAcPay = suplAccPay.ThisTimeTtlBlcAcPay; // ����J�z�c���i���|�v�j
            suplAccPayWork.OfsThisTimeStock = suplAccPay.OfsThisTimeStock; // ���E�㍡��d�����z
            suplAccPayWork.OfsThisStockTax = suplAccPay.OfsThisStockTax; // ���E�㍡��d�������
            suplAccPayWork.ItdedOffsetOutTax = suplAccPay.ItdedOffsetOutTax; // ���E��O�őΏۊz
            suplAccPayWork.ItdedOffsetInTax = suplAccPay.ItdedOffsetInTax; // ���E����őΏۊz
            suplAccPayWork.ItdedOffsetTaxFree = suplAccPay.ItdedOffsetTaxFree; // ���E���ېőΏۊz
            suplAccPayWork.OffsetOutTax = suplAccPay.OffsetOutTax; // ���E��O�ŏ����
            suplAccPayWork.OffsetInTax = suplAccPay.OffsetInTax; // ���E����ŏ����
            suplAccPayWork.ThisTimeStockPrice = suplAccPay.ThisTimeStockPrice; // ����d�����z
            suplAccPayWork.ThisStcPrcTax = suplAccPay.ThisStcPrcTax; // ����d�������
            suplAccPayWork.TtlItdedStcOutTax = suplAccPay.TtlItdedStcOutTax; // �d���O�őΏۊz���v
            suplAccPayWork.TtlItdedStcInTax = suplAccPay.TtlItdedStcInTax; // �d�����őΏۊz���v
            suplAccPayWork.TtlItdedStcTaxFree = suplAccPay.TtlItdedStcTaxFree; // �d����ېőΏۊz���v
            suplAccPayWork.TtlStockOuterTax = suplAccPay.TtlStockOuterTax; // �d���O�Ŋz���v
            suplAccPayWork.TtlStockInnerTax = suplAccPay.TtlStockInnerTax; // �d�����Ŋz���v
            suplAccPayWork.ThisStckPricRgds = suplAccPay.ThisStckPricRgds; // ����ԕi���z
            suplAccPayWork.ThisStcPrcTaxRgds = suplAccPay.ThisStcPrcTaxRgds; // ����ԕi�����
            suplAccPayWork.TtlItdedRetOutTax = suplAccPay.TtlItdedRetOutTax; // �ԕi�O�őΏۊz���v
            suplAccPayWork.TtlItdedRetInTax = suplAccPay.TtlItdedRetInTax; // �ԕi���őΏۊz���v
            suplAccPayWork.TtlItdedRetTaxFree = suplAccPay.TtlItdedRetTaxFree; // �ԕi��ېőΏۊz���v
            suplAccPayWork.TtlRetOuterTax = suplAccPay.TtlRetOuterTax; // �ԕi�O�Ŋz���v
            suplAccPayWork.TtlRetInnerTax = suplAccPay.TtlRetInnerTax; // �ԕi���Ŋz���v
            suplAccPayWork.ThisStckPricDis = suplAccPay.ThisStckPricDis; // ����l�����z
            suplAccPayWork.ThisStcPrcTaxDis = suplAccPay.ThisStcPrcTaxDis; // ����l�������
            suplAccPayWork.TtlItdedDisOutTax = suplAccPay.TtlItdedDisOutTax; // �l���O�őΏۊz���v
            suplAccPayWork.TtlItdedDisInTax = suplAccPay.TtlItdedDisInTax; // �l�����őΏۊz���v
            suplAccPayWork.TtlItdedDisTaxFree = suplAccPay.TtlItdedDisTaxFree; // �l����ېőΏۊz���v
            suplAccPayWork.TtlDisOuterTax = suplAccPay.TtlDisOuterTax; // �l���O�Ŋz���v
            suplAccPayWork.TtlDisInnerTax = suplAccPay.TtlDisInnerTax; // �l�����Ŋz���v
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //suplAccPayWork.ThisRecvOffset = suplAccPay.ThisRecvOffset; // ��������z
            //suplAccPayWork.ThisRecvOffsetTax = suplAccPay.ThisRecvOffsetTax; // �����摊�E�����
            //suplAccPayWork.ThisRecvOutTax = suplAccPay.ThisRecvOutTax; // ������O�őΏۊz���v
            //suplAccPayWork.ThisRecvInTax = suplAccPay.ThisRecvInTax; // ��������őΏۊz���v
            //suplAccPayWork.ThisRecvTaxFree = suplAccPay.ThisRecvTaxFree; // �������ېőΏۊz���v
            //suplAccPayWork.ThisRecvOuterTax = suplAccPay.ThisRecvOuterTax; // ������O�Ŋz���v
            //suplAccPayWork.ThisRecvInnerTax = suplAccPay.ThisRecvInnerTax; // ��������Ŋz���v
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END
            suplAccPayWork.TaxAdjust = suplAccPay.TaxAdjust; // ����Œ����z
            suplAccPayWork.BalanceAdjust = suplAccPay.BalanceAdjust; // �c�������z
            //suplAccPayWork.StckTtlAccPayBalance = suplAccPay.StckTtlAccPayBalance - suplAccPay.BalanceAdjust - suplAccPay.TaxAdjust; // �d�����v�c���i���|�v�j
            suplAccPayWork.StckTtlAccPayBalance = suplAccPay.StckTtlAccPayBalance; // �d�����v�c���i���|�v�j
            suplAccPayWork.StckTtl2TmBfBlAccPay = suplAccPay.StckTtl2TmBfBlAccPay; // �d��2��O�c���i���|�v�j
            suplAccPayWork.StckTtl3TmBfBlAccPay = suplAccPay.StckTtl3TmBfBlAccPay; // �d��3��O�c���i���|�v�j
            suplAccPayWork.MonthAddUpExpDate = suplAccPay.MonthAddUpExpDate; // �����X�V���s�N����
            suplAccPayWork.StMonCAddUpUpdDate = suplAccPay.StMonCAddUpUpdDate; // �����X�V�J�n�N����
            suplAccPayWork.LaMonCAddUpUpdDate = suplAccPay.LaMonCAddUpUpdDate; // �O�񌎎��X�V�N����
            suplAccPayWork.StockSlipCount = suplAccPay.StockSlipCount; // �d���`�[����
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //suplAccPayWork.NonStmntAppearance = suplAccPay.NonStmntAppearance; // �����ϋ��z�i���U�j
            //suplAccPayWork.NonStmntIsdone = suplAccPay.NonStmntIsdone; // �����ϋ��z�i�􂵁j
            //suplAccPayWork.StmntAppearance = suplAccPay.StmntAppearance; // ���ϋ��z�i���U�j
            //suplAccPayWork.StmntIsdone = suplAccPay.StmntIsdone; // ���ϋ��z�i�􂵁j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END            suplAccPayWork.SuppCTaxLayCd = suplAccPay.SuppCTaxLayCd; // �d�������œ]�ŕ����R�[�h
            suplAccPayWork.SupplierConsTaxRate = suplAccPay.SupplierConsTaxRate; // �d�������Őŗ�
            suplAccPayWork.FractionProcCd = suplAccPay.FractionProcCd; // �[�������敪
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            //if (suplAccPayWork.SupplierCd == suplAccPayWork.PayeeCode)
            //{
            //    suplAccPayWork.SupplierCd = 0;
            //}
        }

        /// <summary>�N���X�����o�R�s�[���� (��ʕύX�d����x�����z�}�X�^�N���X�ˎd����x�����z�}�X�^���[�N�N���X)</summary>
        /// <param name="suplierPayWork">�d����x�����z�}�X�^���[�N�N���X</param>
        /// <param name="suplierPay">�d����x�����z�}�X�^�N���X</param>
        /// <remarks>
        /// <br>Note       : ��ʕύX�d����x�����z�}�X�^�N���X����
        ///                  �d����x�����z�}�X�^���[�N�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        private void CopyToSuplierPayWorkFromSuplierPay(ref SuplierPayWork suplierPayWork, SuplierPay suplierPay)
        {
            # region // �폜
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplierPayWork.EnterpriseCode       = suplierPay.EnterpriseCode;
            //suplierPayWork.AddUpSecCode         = suplierPay.AddUpSecCode;
            //suplierPayWork.CustomerCode         = suplierPay.CustomerCode;
            //suplierPayWork.CustomerName         = suplierPay.CustomerName;
            //suplierPayWork.CustomerName2        = suplierPay.CustomerName2;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplierPayWork.CustomerSnm          = suplierPay.CustomerSnm;
            //suplierPayWork.PayeeCode            = suplierPay.PayeeCode;
            //suplierPayWork.PayeeName            = suplierPay.PayeeName;
            //suplierPayWork.PayeeName2           = suplierPay.PayeeName2;
            //suplierPayWork.PayeeSnm             = suplierPay.PayeeSnm;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplierPayWork.AddUpDate            = TDateTime.LongDateToDateTime(suplierPay.AddUpDate);
            ////suplierPayWork.AddUpYearMonth       = TDateTime.LongDateToDateTime(suplierPay.AddUpYearMonth);
            //suplierPayWork.AddUpDate = suplierPay.AddUpDate;
            //suplierPayWork.AddUpYearMonth = suplierPay.AddUpYearMonth;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //suplierPayWork.LastTimePayment       = suplierPay.LastTimePayment;
            //suplierPayWork.ThisTimePayNrml      = suplierPay.ThisTimePayNrml;
            //suplierPayWork.ThisTimeFeePayNrml   = suplierPay.ThisTimeFeePayNrml;
            //suplierPayWork.ThisTimeDisPayNrml   = suplierPay.ThisTimeDisPayNrml;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplierPayWork.ThisTimeRbtDmdNrml   = suplierPay.ThisTimeRbtDmdNrml;
            ////suplierPayWork.ThisTimeDmdDepo      = suplierPay.ThisTimeDmdDepo;
            ////suplierPayWork.ThisTimeFeeDmdDepo   = suplierPay.ThisTimeFeeDmdDepo;
            ////suplierPayWork.ThisTimeDisDmdDepo   = suplierPay.ThisTimeDisDmdDepo;
            ////suplierPayWork.ThisTimeRbtDmdDepo   = suplierPay.ThisTimeRbtDmdDepo;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //suplierPayWork.ThisTimeTtlBlcPay    = suplierPay.ThisTimeTtlBlcPay;
            //suplierPayWork.ThisTimeStockPrice        = suplierPay.ThisTimeStockPrice;
            //suplierPayWork.ThisStcPrcTax         = suplierPay.ThisStcPrcTax;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplierPayWork.TtlIncDtbtTaxExc     = suplierPay.TtlIncDtbtTaxExc;
            ////suplierPayWork.TtlIncDtbtTax        = suplierPay.TtlIncDtbtTax;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //suplierPayWork.ThisNetStckPrice     = suplierPay.ThisNetStckPrice;
            //suplierPayWork.ThisNetStcPrcTax      = suplierPay.ThisNetStcPrcTax;
            //suplierPayWork.ItdedOffsetOutTax    = suplierPay.ItdedOffsetOutTax;
            //suplierPayWork.ItdedOffsetInTax     = suplierPay.ItdedOffsetInTax;
            //suplierPayWork.ItdedOffsetTaxFree   = suplierPay.ItdedOffsetTaxFree;
            //suplierPayWork.OffsetOutTax         = suplierPay.OffsetOutTax;
            //suplierPayWork.OffsetInTax          = suplierPay.OffsetInTax;
            //suplierPayWork.TtlItdedStcOutTax     = suplierPay.TtlItdedStcOutTax;
            //suplierPayWork.TtlItdedStcInTax      = suplierPay.TtlItdedStcInTax;
            //suplierPayWork.TtlItdedStcTaxFree    = suplierPay.TtlItdedStcTaxFree;
            //suplierPayWork.TtlStockOuterTax          = suplierPay.TtlStockOuterTax;
            //suplierPayWork.TtlStockInnerTax           = suplierPay.TtlStockInnerTax;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplierPayWork.ItdedPaymOutTax      = suplierPay.ItdedPaymOutTax;
            ////suplierPayWork.ItdedPaymInTax       = suplierPay.ItdedPaymInTax;
            ////suplierPayWork.ItdedPaymTaxFree     = suplierPay.ItdedPaymTaxFree;
            ////suplierPayWork.PaymentOutTax        = suplierPay.PaymentOutTax;
            ////suplierPayWork.PaymentInTax         = suplierPay.PaymentInTax;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //suplierPayWork.TtlItdedRetOutTax    = suplierPay.TtlItdedRetOutTax;
            //suplierPayWork.TtlItdedRetInTax     = suplierPay.TtlItdedRetInTax;
            //suplierPayWork.TtlItdedRetTaxFree   = suplierPay.TtlItdedRetTaxFree;
            //suplierPayWork.TtlRetOuterTax       = suplierPay.TtlRetOuterTax;
            //suplierPayWork.TtlRetInnerTax       = suplierPay.TtlRetInnerTax;
            //suplierPayWork.TtlItdedDisOutTax    = suplierPay.TtlItdedDisOutTax;
            //suplierPayWork.TtlItdedDisInTax     = suplierPay.TtlItdedDisInTax;
            //suplierPayWork.TtlItdedDisTaxFree   = suplierPay.TtlItdedDisTaxFree;
            //suplierPayWork.TtlDisOuterTax       = suplierPay.TtlDisOuterTax;
            //suplierPayWork.TtlDisInnerTax       = suplierPay.TtlDisInnerTax;
            //suplierPayWork.BalanceAdjust        = suplierPay.BalanceAdjust;
            //suplierPayWork.ThisStckPricRgds    = suplierPay.ThisStckPricRgds;
            //suplierPayWork.ThisStckPricDis     = suplierPay.ThisStckPricDis;
            //suplierPayWork.ThisStcPrcTaxRgds  = suplierPay.ThisStcPrcTaxRgds;
            //suplierPayWork.ThisStcPrcTaxDis   = suplierPay.ThisStcPrcTaxDis;
            //suplierPayWork.StockSlipCount      = suplierPay.StockSlipCount;
            //suplierPayWork.PaymentSchedule  = suplierPay.PaymentSchedule;
            //suplierPayWork.PaymentCond          = suplierPay.PaymentCond;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //suplierPayWork.SuppCTaxLayCd     = suplierPay.SuppCTaxLayCd;
            //suplierPayWork.SupplierConsTaxRate          = suplierPay.SupplierConsTaxRate;
            //suplierPayWork.FractionProcCd       = suplierPay.FractionProcCd;
            //suplierPayWork.StockTotalPayBalance     = suplierPay.StockTotalPayBalance;
            //suplierPayWork.StockTtl2TmBfBlPay  = suplierPay.StockTtl2TmBfBlPay;
            //suplierPayWork.StockTtl3TmBfBlPay  = suplierPay.StockTtl3TmBfBlPay;
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplierPayWork.CAddUpUpdExecDate    = TDateTime.LongDateToDateTime(suplierPay.CAddUpUpdExecDate);
            //suplierPayWork.CAddUpUpdExecDate = suplierPay.CAddUpUpdExecDate;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            ////suplierPayWork.DmdProcNum           = suplierPay.DmdProcNum;
            //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            # endregion

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            suplierPayWork.CreateDateTime = suplierPay.CreateDateTime; // �쐬����
            suplierPayWork.UpdateDateTime = suplierPay.UpdateDateTime; // �X�V����
            suplierPayWork.EnterpriseCode = suplierPay.EnterpriseCode; // ��ƃR�[�h
            suplierPayWork.FileHeaderGuid = suplierPay.FileHeaderGuid; // GUID
            suplierPayWork.UpdEmployeeCode = suplierPay.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            suplierPayWork.UpdAssemblyId1 = suplierPay.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            suplierPayWork.UpdAssemblyId2 = suplierPay.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            suplierPayWork.LogicalDeleteCode = suplierPay.LogicalDeleteCode; // �_���폜�敪
            suplierPayWork.AddUpSecCode = suplierPay.AddUpSecCode; // �v�㋒�_�R�[�h
            suplierPayWork.PayeeCode = suplierPay.PayeeCode; // �x����R�[�h
            suplierPayWork.PayeeName = suplierPay.PayeeName; // �x���於��
            suplierPayWork.PayeeName2 = suplierPay.PayeeName2; // �x���於��2
            suplierPayWork.PayeeSnm = suplierPay.PayeeSnm; // �x���旪��
            suplierPayWork.SupplierCd = suplierPay.SupplierCd; // ���Ӑ�R�[�h
            suplierPayWork.SupplierNm1 = suplierPay.SupplierNm1; // ���Ӑ於��
            suplierPayWork.SupplierNm2 = suplierPay.SupplierNm2; // ���Ӑ於��2
            suplierPayWork.SupplierSnm = suplierPay.SupplierSnm; // ���Ӑ旪��

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA ADD START
            suplierPayWork.ResultsSectCd = suplierPay.ResultsSectCd;    // ���ы��_�R�[�h
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA ADD END

            suplierPayWork.AddUpDate = suplierPay.AddUpDate; // �v��N����
            suplierPayWork.AddUpYearMonth = suplierPay.AddUpYearMonth; // �v��N��
            suplierPayWork.LastTimePayment = suplierPay.LastTimePayment; // �O��x�����z
            suplierPayWork.ThisTimeFeePayNrml = suplierPay.ThisTimeFeePayNrml; // ����萔���z�i�ʏ�x���j
            suplierPayWork.ThisTimeDisPayNrml = suplierPay.ThisTimeDisPayNrml; // ����l���z�i�ʏ�x���j
            suplierPayWork.ThisTimePayNrml = suplierPay.ThisTimePayNrml; // ����x�����z�i�ʏ�x���j
            suplierPayWork.ThisTimeTtlBlcPay = suplierPay.ThisTimeTtlBlcPay; // ����J�z�c���i�x���v�j
            suplierPayWork.OfsThisTimeStock = suplierPay.OfsThisTimeStock; // ���E�㍡��d�����z
            suplierPayWork.OfsThisStockTax = suplierPay.OfsThisStockTax; // ���E�㍡��d�������
            suplierPayWork.ItdedOffsetOutTax = suplierPay.ItdedOffsetOutTax; // ���E��O�őΏۊz
            suplierPayWork.ItdedOffsetInTax = suplierPay.ItdedOffsetInTax; // ���E����őΏۊz
            suplierPayWork.ItdedOffsetTaxFree = suplierPay.ItdedOffsetTaxFree; // ���E���ېőΏۊz
            suplierPayWork.OffsetOutTax = suplierPay.OffsetOutTax; // ���E��O�ŏ����
            suplierPayWork.OffsetInTax = suplierPay.OffsetInTax; // ���E����ŏ����
            suplierPayWork.ThisTimeStockPrice = suplierPay.ThisTimeStockPrice; // ����d�����z
            suplierPayWork.ThisStcPrcTax = suplierPay.ThisStcPrcTax; // ����d�������
            suplierPayWork.TtlItdedStcOutTax = suplierPay.TtlItdedStcOutTax; // �d���O�őΏۊz���v
            suplierPayWork.TtlItdedStcInTax = suplierPay.TtlItdedStcInTax; // �d�����őΏۊz���v
            suplierPayWork.TtlItdedStcTaxFree = suplierPay.TtlItdedStcTaxFree; // �d����ېőΏۊz���v
            suplierPayWork.TtlStockOuterTax = suplierPay.TtlStockOuterTax; // �d���O�Ŋz���v
            suplierPayWork.TtlStockInnerTax = suplierPay.TtlStockInnerTax; // �d�����Ŋz���v
            suplierPayWork.ThisStckPricRgds = suplierPay.ThisStckPricRgds; // ����ԕi���z
            suplierPayWork.ThisStcPrcTaxRgds = suplierPay.ThisStcPrcTaxRgds; // ����ԕi�����
            suplierPayWork.TtlItdedRetOutTax = suplierPay.TtlItdedRetOutTax; // �ԕi�O�őΏۊz���v
            suplierPayWork.TtlItdedRetInTax = suplierPay.TtlItdedRetInTax; // �ԕi���őΏۊz���v
            suplierPayWork.TtlItdedRetTaxFree = suplierPay.TtlItdedRetTaxFree; // �ԕi��ېőΏۊz���v
            suplierPayWork.TtlRetOuterTax = suplierPay.TtlRetOuterTax; // �ԕi�O�Ŋz���v
            suplierPayWork.TtlRetInnerTax = suplierPay.TtlRetInnerTax; // �ԕi���Ŋz���v
            suplierPayWork.ThisStckPricDis = suplierPay.ThisStckPricDis; // ����l�����z
            suplierPayWork.ThisStcPrcTaxDis = suplierPay.ThisStcPrcTaxDis; // ����l�������
            suplierPayWork.TtlItdedDisOutTax = suplierPay.TtlItdedDisOutTax; // �l���O�őΏۊz���v
            suplierPayWork.TtlItdedDisInTax = suplierPay.TtlItdedDisInTax; // �l�����őΏۊz���v
            suplierPayWork.TtlItdedDisTaxFree = suplierPay.TtlItdedDisTaxFree; // �l����ېőΏۊz���v
            suplierPayWork.TtlDisOuterTax = suplierPay.TtlDisOuterTax; // �l���O�Ŋz���v
            suplierPayWork.TtlDisInnerTax = suplierPay.TtlDisInnerTax; // �l�����Ŋz���v
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //suplierPayWork.ThisRecvOffset = suplierPay.ThisRecvOffset; // ��������z
            //suplierPayWork.ThisRecvOffsetTax = suplierPay.ThisRecvOffsetTax; // �����摊�E�����
            //suplierPayWork.ThisRecvOutTax = suplierPay.ThisRecvOutTax; // ������O�őΏۊz���v
            //suplierPayWork.ThisRecvInTax = suplierPay.ThisRecvInTax; // ��������őΏۊz���v
            //suplierPayWork.ThisRecvTaxFree = suplierPay.ThisRecvTaxFree; // �������ېőΏۊz���v
            //suplierPayWork.ThisRecvOuterTax = suplierPay.ThisRecvOuterTax; // ������O�Ŋz���v
            //suplierPayWork.ThisRecvInnerTax = suplierPay.ThisRecvInnerTax; // ��������Ŋz���v
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END
            suplierPayWork.TaxAdjust = suplierPay.TaxAdjust; // ����Œ����z
            suplierPayWork.BalanceAdjust = suplierPay.BalanceAdjust; // �c�������z
            suplierPayWork.StockTotalPayBalance = suplierPay.StockTotalPayBalance - suplierPay.BalanceAdjust - suplierPay.TaxAdjust; // �d�����v�c���i�x���v�j
            suplierPayWork.StockTtl2TmBfBlPay = suplierPay.StockTtl2TmBfBlPay; // �d��2��O�c���i�x���v�j
            suplierPayWork.StockTtl3TmBfBlPay = suplierPay.StockTtl3TmBfBlPay; // �d��3��O�c���i�x���v�j
            suplierPayWork.CAddUpUpdExecDate = suplierPay.CAddUpUpdExecDate; // �����X�V���s�N����
            suplierPayWork.StartCAddUpUpdDate = suplierPay.StartCAddUpUpdDate; // �����X�V�J�n�N����
            suplierPayWork.LastCAddUpUpdDate = suplierPay.LastCAddUpUpdDate; // �O������X�V�N����
            suplierPayWork.StockSlipCount = suplierPay.StockSlipCount; // �d���`�[����
            suplierPayWork.PaymentSchedule = suplierPay.PaymentSchedule; // �x���\���
            suplierPayWork.PaymentCond = suplierPay.PaymentCond; // �x������
            suplierPayWork.SuppCTaxLayCd = suplierPay.SuppCTaxLayCd; // �d�������œ]�ŕ����R�[�h
            suplierPayWork.SupplierConsTaxRate = suplierPay.SupplierConsTaxRate; // �d�������Őŗ�
            suplierPayWork.FractionProcCd = suplierPay.FractionProcCd; // �[�������敪
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki

            //if ( suplierPayWork.SupplierCd == suplierPayWork.PayeeCode ) {
            //    suplierPayWork.SupplierCd = 0;
            //}
        }

        #region    ********** �s�v **********
        /// <summary>�N���X�����o�R�s�[���� (�d���攃�|���z�}�X�^���[�N�N���X�ˎd���攃�|���z�}�X�^�N���X)
		/// </summary>
        /// <param name="financStmntOutWork">�d���攃�|���z�}�X�^���[�N�N���X</param>
        /// <returns>�d���攃�|���z�}�X�^�N���X</returns>
		/// <remarks>
        /// <br>Note       : �d���攃�|���z�}�X�^���[�N�N���X����
        ///                  �d���攃�|���z�}�X�^�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
		/// </remarks>
        //private SuplAccPay CopyToFinancStmntOutFromFinancStmntOutWork(SuplAccPayWork suplAccPayWork)
        //{
        //    FinancStmntOut financStmntOut = new FinancStmntOut();

        //    suplAccPay.CreateDateTime       = suplAccPayWork.CreateDateTime;       // �쐬����
        //    suplAccPay.UpdateDateTime       = suplAccPayWork.UpdateDateTime;       // �X�V����
        //    suplAccPay.EnterpriseCode       = suplAccPayWork.EnterpriseCode;       // ��ƃR�[�h
        //    suplAccPay.FileHeaderGuid       = suplAccPayWork.FileHeaderGuid;       // GUID
        //    suplAccPay.UpdEmployeeCode      = suplAccPayWork.UpdEmployeeCode;      // �X�V�]�ƈ��R�[�h
        //    suplAccPay.UpdAssemblyId1       = suplAccPayWork.UpdAssemblyId1;       // �X�V�A�Z���u��ID1
        //    suplAccPay.UpdAssemblyId2       = suplAccPayWork.UpdAssemblyId2;       // �X�V�A�Z���u��ID2
        //    suplAccPay.LogicalDeleteCode    = suplAccPayWork.LogicalDeleteCode;    // �_���폜�敪
        //    suplAccPay.EnterpriseCode       = suplAccPayWork.EnterpriseCode;
        //    suplAccPay.AddUpSecCode         = suplAccPayWork.AddUpSecCode;
        //    suplAccPay.CustomerCode         = suplAccPayWork.CustomerCode;
        //    suplAccPay.CustomerName         = suplAccPayWork.CustomerName;
        //    suplAccPay.CustomerName2        = suplAccPayWork.CustomerName2;
        //    suplAccPay.AddUpDate            = suplAccPayWork.AddUpDate;
        //    suplAccPay.AddUpYearMonth       = suplAccPayWork.AddUpYearMonth;
        //    suplAccPay.LastTimeAccPay       = suplAccPayWork.LastTimeAccPay;
        //    suplAccPay.ThisTimePayNrml      = suplAccPayWork.ThisTimePayNrml;
        //    suplAccPay.ThisTimeFeePayNrml   = suplAccPayWork.ThisTimeFeePayNrml;
        //    suplAccPay.ThisTimeDisPayNrml   = suplAccPayWork.ThisTimeDisPayNrml;
        //    suplAccPay.ThisTimeRbtDmdNrml   = suplAccPayWork.ThisTimeRbtDmdNrml;
        //    suplAccPay.ThisTimeDmdDepo      = suplAccPayWork.ThisTimeDmdDepo;
        //    suplAccPay.ThisTimeFeeDmdDepo   = suplAccPayWork.ThisTimeFeeDmdDepo;
        //    suplAccPay.ThisTimeDisDmdDepo   = suplAccPayWork.ThisTimeDisDmdDepo;
        //    suplAccPay.ThisTimeRbtDmdDepo   = suplAccPayWork.ThisTimeRbtDmdDepo;
        //    suplAccPay.ThisTimeTtlBlcAcPay    = suplAccPayWork.ThisTimeTtlBlcAcPay;
        //    suplAccPay.ThisTimeStockPrice        = suplAccPayWork.ThisTimeStockPrice;
        //    suplAccPay.ThisStcPrcTax         = suplAccPayWork.ThisStcPrcTax;
        //    suplAccPay.TtlIncDtbtTaxExc     = suplAccPayWork.TtlIncDtbtTaxExc;
        //    suplAccPay.TtlIncDtbtTax        = suplAccPayWork.TtlIncDtbtTax;
        //    suplAccPay.ThisNetStckPrice     = suplAccPayWork.ThisNetStckPrice;
        //    suplAccPay.ThisNetStcPrcTax      = suplAccPayWork.ThisNetStcPrcTax;
        //    suplAccPay.ItdedOffsetOutTax    = suplAccPayWork.ItdedOffsetOutTax;
        //    suplAccPay.ItdedOffsetInTax     = suplAccPayWork.ItdedOffsetInTax;
        //    suplAccPay.ItdedOffsetTaxFree   = suplAccPayWork.ItdedOffsetTaxFree;
        //    suplAccPay.OffsetOutTax         = suplAccPayWork.OffsetOutTax;
        //    suplAccPay.OffsetInTax          = suplAccPayWork.OffsetInTax;
        //    suplAccPay.TtlItdedStcOutTax     = suplAccPayWork.TtlItdedStcOutTax;
        //    suplAccPay.TtlItdedStcInTax      = suplAccPayWork.TtlItdedStcInTax;
        //    suplAccPay.TtlItdedStcTaxFree    = suplAccPayWork.TtlItdedStcTaxFree;
        //    suplAccPay.TtlStockOuterTax          = suplAccPayWork.TtlStockOuterTax;
        //    suplAccPay.TtlStockInnerTax           = suplAccPayWork.TtlStockInnerTax;
        //    suplAccPay.ItdedPaymOutTax      = suplAccPayWork.ItdedPaymOutTax;
        //    suplAccPay.ItdedPaymInTax       = suplAccPayWork.ItdedPaymInTax;
        //    suplAccPay.ItdedPaymTaxFree     = suplAccPayWork.ItdedPaymTaxFree;
        //    suplAccPay.PaymentOutTax        = suplAccPayWork.PaymentOutTax;
        //    suplAccPay.PaymentInTax         = suplAccPayWork.PaymentInTax;
        //    suplAccPay.SuppCTaxLayCd     = suplAccPayWork.SuppCTaxLayCd;
        //    suplAccPay.SupplierConsTaxRate          = suplAccPayWork.SupplierConsTaxRate;
        //    suplAccPay.FractionProcCd       = suplAccPayWork.FractionProcCd;
        //    suplAccPay.StckTtlAccPayBalance    = suplAccPayWork.StckTtlAccPayBalance;
        //    suplAccPay.StckTtl2TmBfBlAccPay = suplAccPayWork.StckTtl2TmBfBlAccPay;
        //    suplAccPay.StckTtl3TmBfBlAccPay = suplAccPayWork.StckTtl3TmBfBlAccPay;
        //    suplAccPay.MonthAddUpExpDate    = suplAccPayWork.MonthAddUpExpDate;

        //    // �e�[�u���X�V
        //    this._custAccRecDic[suplAccPayWork.FileHeaderGuid] = suplAccPayWork;

        //    return suplAccPay;
        //}
        #endregion ********** �s�v **********

        /// <summary>�d���攃�|���z�}�X�^�I�u�W�F�N�g���C��DataSet�W�J����</summary>
        /// <param name="suplAccPayWork">�d���攃�|���z�}�X�^�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �d���攃�|���z�}�X�^�I�u�W�F�N�g���A���C��DataSet�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.14 >>>
        //private void SuplAccPayWorkToDataSet(SuplAccPayWork suplAccPayWork)
        private void SuplAccPayWorkToDataSet(SuplAccPayWork suplAccPayWork, ArrayList aCalcPayTotalWorkArrayList)
        // 2009.01.14 <<<
        {
            // 2009.01.14 Del >>>
            //// �e���R�[�h�̏ꍇ�͓��Ӑ�R�[�h�Ɏx����R�[�h�Ɠ����l���ăZ�b�g
            //if (suplAccPayWork.SupplierCd == 0)
            //{
            //    suplAccPayWork.SupplierCd = suplAccPayWork.PayeeCode;
            //}
            // 2009.01.14 Del <<<

            bool newFlg = false;    // �V�K�E�����t���O

            // �X�V�Ώۍs�̎擾
            object[] primryKey = new object[] { suplAccPayWork.AddUpSecCode, 
                                                suplAccPayWork.PayeeCode,
                                                suplAccPayWork.SupplierCd, 
                                                TDateTime.DateTimeToLongDate(suplAccPayWork.AddUpDate) };
            DataRow dr = this._custAccRecTable.Rows.Find(primryKey);
            if (dr == null)
            {
                // �V�K�ɍs���쐬
                dr = this._custAccRecTable.NewRow();

                // �V�K���R�[�h�`�F�b�N
                newFlg = true;
            }

            // 2009.01.14 Del >>>
            // ���ۂ̃f�[�^�Z�b�g�͕ʃ��\�b�h�ōs�����߃R�����g�A�E�g
#if false
            // �폜��
            if (suplAccPayWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", suplAccPayWork.UpdateDateTime);
            }
            dr[COL_ADDUPSECCODE_TITLE]         = suplAccPayWork.AddUpSecCode;                                           // �v�㋒�_�R�[�h

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
            dr[COL_SUPPLIERCODE_TITLE] = suplAccPayWork.SupplierCd;                                           // �d����R�[�h
            dr[COL_SUPPLIERNAME_TITLE]         = suplAccPayWork.SupplierNm1;                                           // �d���於��
            dr[COL_SUPPLIERNAME2_TITLE] = suplAccPayWork.SupplierNm2;                                          // �d���於��2
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_SUPPLIERSNM_TITLE] = suplAccPayWork.SupplierSnm;                                            // �d���旪��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END

            dr[COL_PAYEECODE_TITLE]            = suplAccPayWork.PayeeCode;                                              // �x����R�[�h
            dr[COL_PAYEENAME_TITLE]            = suplAccPayWork.PayeeName;                                              // �x���於��
            dr[COL_PAYEENAME2_TITLE]           = suplAccPayWork.PayeeName2;                                             // �x���於��2
            dr[COL_PAYEESNM_TITLE]             = suplAccPayWork.PayeeSnm;                                               // �x���旪��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_ADDUPDATEJP_TITLE]          = TDateTime.DateTimeToString("YYYY/MM/DD", suplAccPayWork.AddUpDate);    // �v��N����
            dr[COL_ADDUPYEARMONTHJP_TITLE]     = TDateTime.DateTimeToString("ggYY.MM", suplAccPayWork.AddUpYearMonth);  // �v��N��
            dr[COL_ADDUPDATE_TITLE]            = TDateTime.DateTimeToLongDate(suplAccPayWork.AddUpDate);                // _�v��N����
            dr[COL_ADDUPYEARMONTH_TITLE]       = TDateTime.DateTimeToLongDate(suplAccPayWork.AddUpYearMonth);           // _�v��N��
            dr[COL_LASTTIMEACCPAY_TITLE]       = suplAccPayWork.LastTimeAccPay;                                         // �O�񔃊|���z
            dr[COL_THISTIMEPAYNRML_TITLE]      = suplAccPayWork.ThisTimePayNrml;                                        // ����x�����z�i�ʏ�x���j
            dr[COL_THISTIMEFEEPAYNRML_TITLE]   = suplAccPayWork.ThisTimeFeePayNrml;                                     // ����萔���z�i�ʏ�x���j
            dr[COL_THISTIMEDISPAYNRML_TITLE]   = suplAccPayWork.ThisTimeDisPayNrml;                                     // ����l���z�i�ʏ�x���j
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISTIMERBTDMDNRML_TITLE]   = suplAccPayWork.ThisTimeRbtDmdNrml;                                     // ���񃊃x�[�g�z�i�ʏ�x���j
            //dr[COL_THISTIMEDMDDEPO_TITLE]      = suplAccPayWork.ThisTimeDmdDepo;                                        // ����x�����z�i�a����j
            //dr[COL_THISTIMEFEEDMDDEPO_TITLE]   = suplAccPayWork.ThisTimeFeeDmdDepo;                                     // ����萔���z�i�a����j
            //dr[COL_THISTIMEDISDMDDEPO_TITLE]   = suplAccPayWork.ThisTimeDisDmdDepo;                                     // ����l���z�i�a����j
            //dr[COL_THISTIMERBTDMDDEPO_TITLE]   = suplAccPayWork.ThisTimeRbtDmdDepo;                                     // ���񃊃x�[�g�z�i�a����j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISTIMEPAYMENT_TITLE]      = suplAccPayWork.ThisTimePayNrml    +                                    // ����x�����z�i�ʏ�x���j
            //                                     suplAccPayWork.ThisTimeFeePayNrml +                                    // ����萔���z�i�ʏ�x���j
            //                                     suplAccPayWork.ThisTimeDisPayNrml +                                    // ����l���z�i�ʏ�x���j
            //                                     suplAccPayWork.ThisTimeRbtDmdNrml +                                    // ���񃊃x�[�g�z�i�ʏ�x���j
            //                                     suplAccPayWork.ThisTimeDmdDepo    +                                    // ����x�����z�i�a����j
            //                                     suplAccPayWork.ThisTimeFeeDmdDepo +                                    // ����萔���z�i�a����j
            //                                     suplAccPayWork.ThisTimeDisDmdDepo +                                    // ����l���z�i�a����j
            //                                     suplAccPayWork.ThisTimeRbtDmdDepo;                                     // ���񃊃x�[�g�z�i�a����j
            dr[COL_THISTIMEPAYMENT_TITLE] = suplAccPayWork.ThisTimePayNrml +                                    // ����x�����z�i�ʏ�x���j
                                                 suplAccPayWork.ThisTimeFeePayNrml +                                    // ����萔���z�i�ʏ�x���j
                                                 suplAccPayWork.ThisTimeDisPayNrml ;                                    // ����l���z�i�ʏ�x���j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_THISTIMETTLBLCACPAY_TITLE]    = suplAccPayWork.ThisTimeTtlBlcAcPay;                                      // ����J�z�c���i���|�v�j
            dr[COL_THISTIMESTOCKPRICE_TITLE]        = suplAccPayWork.ThisTimeStockPrice;                                          // ����d�����z
            dr[COL_THISSTCPRCTAX_TITLE]         = suplAccPayWork.ThisStcPrcTax;                                           // ����d�������
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_TTLINCDTBTTAXEXC_TITLE]     = suplAccPayWork.TtlIncDtbtTaxExc;                                       // �x���C���Z���e�B�u�z���v�i�Ŕ����j
            //dr[COL_TTLINCDTBTTAX_TITLE]        = suplAccPayWork.TtlIncDtbtTax;                                          // �x���C���Z���e�B�u�z���v�i�Łj
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISNETSTCKPRICE_TITLE]     = suplAccPayWork.ThisNetStckPrice;                                       // ���E�㍡��d�����z
            //dr[COL_THISNETSTCPRCTAX_TITLE]      = suplAccPayWork.ThisNetStcPrcTax;                                        // ���E�㍡��d�������
            dr[COL_OFSTHISTIMESTOCK_TITLE] = suplAccPayWork.OfsThisTimeStock;                                       // ���E�㍡��d�����z
            dr[COL_OFSTHISSTOCKTAX_TITLE] = suplAccPayWork.OfsThisStockTax;                                        // ���E�㍡��d�������
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_ITDEDOFFSETOUTTAX_TITLE]    = suplAccPayWork.ItdedOffsetOutTax;                                      // ���E��O�őΏۊz
            dr[COL_ITDEDOFFSETINTAX_TITLE]     = suplAccPayWork.ItdedOffsetInTax;                                       // ���E����őΏۊz
            dr[COL_ITDEDOFFSETTAXFREE_TITLE]   = suplAccPayWork.ItdedOffsetTaxFree;                                     // ���E���ېőΏۊz
            dr[COL_OFFSETOUTTAX_TITLE]         = suplAccPayWork.OffsetOutTax;                                           // ���E��O�ŏ����
            dr[COL_OFFSETINTAX_TITLE]          = suplAccPayWork.OffsetInTax;                                            // ���E����ŏ����
            dr[COL_ITDEDSTCOUTTAX_TITLE]     = suplAccPayWork.TtlItdedStcOutTax;                                       // �d���O�őΏۊz
            dr[COL_ITDEDSTCINTAX_TITLE]      = suplAccPayWork.TtlItdedStcInTax;                                        // �d�����őΏۊz
            dr[COL_ITDEDSTCTAXFREE_TITLE]    = suplAccPayWork.TtlItdedStcTaxFree;                                      // �d����ېőΏۊz
            dr[COL_TTLSTOCKOUTERTAX_TITLE]          = suplAccPayWork.TtlStockOuterTax;                                            // �d���O�Ŋz
            dr[COL_TTLSTOCKINNERTAX_TITLE]           = suplAccPayWork.TtlStockInnerTax;                                             // �d�����Ŋz
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_ITDEDPAYMOUTTAX_TITLE]      = suplAccPayWork.ItdedPaymOutTax;                                        // �x���O�őΏۊz
            //dr[COL_ITDEDPAYMINTAX_TITLE]       = suplAccPayWork.ItdedPaymInTax;                                         // �x�����őΏۊz
            //dr[COL_ITDEDPAYMTAXFREE_TITLE]     = suplAccPayWork.ItdedPaymTaxFree;                                       // �x����ېőΏۊz
            //dr[COL_PAYMENTOUTTAX_TITLE]        = suplAccPayWork.PaymentOutTax;                                          // �x���O�ŏ����
            //dr[COL_PAYMENTINTAX_TITLE]         = suplAccPayWork.PaymentInTax;                                           // �x�����ŏ����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_TTLITDEDRETOUTTAX_TITLE]    = suplAccPayWork.TtlItdedRetOutTax;                                       // �ԕi�O�őΏۊz
            dr[COL_TTLITDEDRETINTAX_TITLE]     = suplAccPayWork.TtlItdedRetInTax;                                        // �ԕi���őΏۊz
            dr[COL_TTLITDEDRETTAXFREE_TITLE]   = suplAccPayWork.TtlItdedRetTaxFree;                                      // �ԕi��ېőΏۊz
            dr[COL_TTLRETOUTERTAX_TITLE]       = suplAccPayWork.TtlRetOuterTax;                                            // �ԕi�O�Ŋz
            dr[COL_TTLRETINNERTAX_TITLE]       = suplAccPayWork.TtlRetInnerTax;                                             // �ԕi���Ŋz
            dr[COL_TTLITDEDDISOUTTAX_TITLE]    = suplAccPayWork.TtlItdedDisOutTax;                                       // �l���O�őΏۊz
            dr[COL_TTLITDEDDISINTAX_TITLE]     = suplAccPayWork.TtlItdedDisInTax;                                        // �l�����őΏۊz
            dr[COL_TTLITDEDDISTAXFREE_TITLE]   = suplAccPayWork.TtlItdedDisTaxFree;                                      // �l����ېőΏۊz
            dr[COL_TTLDISOUTERTAX_TITLE]       = suplAccPayWork.TtlDisOuterTax;                                            // �l���O�Ŋz
            dr[COL_TTLDISINNERTAX_TITLE]       = suplAccPayWork.TtlDisInnerTax;                                             // �l�����Ŋz
            dr[COL_BALANCEADJUST_TITLE]        = suplAccPayWork.BalanceAdjust;                                          // �c�������z

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            dr[COL_TAXADJUST_TITLE] = suplAccPayWork.TaxAdjust;                                                         // ����Œ����z
            dr[COL_TOTALADJUST_TITLE] = suplAccPayWork.BalanceAdjust + suplAccPayWork.TaxAdjust;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //dr[COL_NONSTMNTAPPEARANCE_TITLE]   = suplAccPayWork.NonStmntAppearance;                                     // �����ϋ��z�i���U�j
            //dr[COL_NONSTMNTISDONE_TITLE]       = suplAccPayWork.NonStmntIsdone;                                         // �����ϋ��z�i�􂵁j 
            //dr[COL_STMNTAPPEARANCE_TITLE]      = suplAccPayWork.StmntAppearance;                                        // ���ϋ��z�i���U�j
            //dr[COL_STMNTISDONE_TITLE]          = suplAccPayWork.StmntIsdone;                                            // ���ϋ��z�i�􂵁j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            //dr[COL_THISCASHSTOCKPRICE]          = suplAccPayWork.ThisCashStockPrice;                                      // �����d�����z
            //dr[COL_THISCASHSTOCKTAX]            = suplAccPayWork.ThisCashStockTax;                                        // �����d������Ŋz
            //dr[COL_STOCKSLIPCOUNT]             = 0;                                                                     // �i�`�[�����j
            dr[COL_PAYMENTSCHEDULE]        = 0;                                                                     // �i�x���\����j
            dr[COL_PAYMENTCOND]                = 0;                                                                     // �i��������j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_SUPPCTAXLAYCD_TITLE]     = suplAccPayWork.SuppCTaxLayCd;                                       // ����œ]�ŕ���
            dr[COL_SUPPLIERCONSTAXRATE_TITLE]          = suplAccPayWork.SupplierConsTaxRate;                                            // ����ŗ�
            dr[COL_FRACTIONPROCCD_TITLE]       = suplAccPayWork.FractionProcCd;                                         // �[�������敪
            dr[COL_STCKTTLACCPAYBALANCE_TITLE] = suplAccPayWork.StckTtlAccPayBalance +suplAccPayWork.BalanceAdjust + suplAccPayWork.TaxAdjust;                                      // �v�Z�㓖�����|���z
            //dr[COL_STCKTTLACCPAYBALANCE_TITLE] = suplAccPayWork.StckTtlAccPayBalance;                                      // �v�Z�㓖�����|���z
            dr[COL_STCKTTL2TMBFBLACCPAY_TITLE] = suplAccPayWork.StckTtl2TmBfBlAccPay;                                   // ��2��O�c���i���|�v�j
            dr[COL_STCKTTL3TMBFBLACCPAY_TITLE] = suplAccPayWork.StckTtl3TmBfBlAccPay;                                   // ��3��O�c���i���|�v�j
            dr[COL_MONTHADDUPEXPDATE_TITLE]    = TDateTime.DateTimeToLongDate(suplAccPayWork.MonthAddUpExpDate);        // �����X�V���s�N����

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISRECVINNERTAX_TITLE] = suplAccPayWork.ThisRecvInnerTax;
            //dr[COL_THISRECVINTAX_TITLE] = suplAccPayWork.ThisRecvInTax;
            //dr[COL_THISRECVOFFSET_TITLE] = suplAccPayWork.ThisRecvOffset;
            //dr[COL_THISRECVOFFSETTAX_TITLE] = suplAccPayWork.ThisRecvOffsetTax;
            //dr[COL_THISRECVOUTERTAX_TITLE] = suplAccPayWork.ThisRecvOuterTax;
            //dr[COL_THISRECVOUTTAX_TITLE] = suplAccPayWork.ThisRecvOutTax;
            //dr[COL_THISRECVTAXFREE_TITLE] = suplAccPayWork.ThisRecvTaxFree;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            dr[COL_GUID_TITLE] = suplAccPayWork.FileHeaderGuid;                                         // GUID
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_CREATEDATETIME] = suplAccPayWork.CreateDateTime; // �쐬����
            dr[COL_UPDATEDATETIME] = suplAccPayWork.UpdateDateTime; // �X�V����
            dr[COL_STOCKSLIPCOUNT] = suplAccPayWork.StockSlipCount; // [5047]
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
#endif
            this.DataRowFromParamData(ref dr, suplAccPayWork, aCalcPayTotalWorkArrayList);
            // 2009.01.14 Del <<<

            // �V�K���R�[�h�̏ꍇ�̂�
            if (newFlg == true)
            {
                // �V�K�s�̒ǉ�
                this._custAccRecTable.Rows.Add(dr);
            }

            // �e�[�u���Ɋi�[
            if (this._custAccRecDic.ContainsKey(suplAccPayWork.FileHeaderGuid) == true)
            {
                this._custAccRecDic.Remove(suplAccPayWork.FileHeaderGuid);
            }
            this._custAccRecDic.Add(suplAccPayWork.FileHeaderGuid, suplAccPayWork);
        }

        /// <summary>�d����x�����z�}�X�^�I�u�W�F�N�g���C��DataSet�W�J����</summary>
        /// <param name="suplAccPayWork">�d����x�����z�}�X�^�I�u�W�F�N�g</param>
        /// <param name="accPayTotalWorkArrayList">���Z�x���W�v�f�[�^�I�u�W�F�N�g���X�g</param>
        /// <remarks>
        /// <br>Note       : �d����x�����z�}�X�^�I�u�W�F�N�g���A���C��DataSet�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        // 2009.01.14 >>>
        //private void SuplierPayWorkToDataSet(SuplierPayWork suplierPayWork)
        private void SuplierPayWorkToDataSet(SuplierPayWork suplierPayWork, ArrayList accPayTotalWorkArrayList)
        // 2009.01.14 <<<
        {
            // 2009.01.14 Del >>>
            //// �e���R�[�h�̏ꍇ�͓��Ӑ�R�[�h�Ɏx����R�[�h�Ɠ����l���ăZ�b�g
            //if (suplierPayWork.SupplierCd == 0)
            //{
            //    suplierPayWork.SupplierCd = suplierPayWork.PayeeCode;
            //}
            // 2009.01.14 Del <<<

            bool newFlg = false;    // �V�K�E�����t���O

            // �X�V�Ώۍs�̎擾
            object[] primryKey = new object[] { suplierPayWork.AddUpSecCode,
                                                suplierPayWork.PayeeCode,
                                                suplierPayWork.SupplierCd, 
                                                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA ADD START
                                                suplierPayWork.ResultsSectCd,
                                                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA ADD END
                                                TDateTime.DateTimeToLongDate(suplierPayWork.AddUpDate) };
            DataRow dr = this._custDmdPrcTable.Rows.Find(primryKey);
            if (dr == null)
            {
                // �V�K�ɍs���쐬
                dr = this._custDmdPrcTable.NewRow();

                // �V�K���R�[�h�`�F�b�N
                newFlg = true;
            }

            // 2009.01.14 Del >>>
#if false
            // �폜��
            if (suplierPayWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", suplierPayWork.UpdateDateTime);
            }
            dr[COL_ADDUPSECCODE_TITLE]         = suplierPayWork.AddUpSecCode;                                           // �v�㋒�_�R�[�h

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA MODIFY START
            dr[COL_SUPPLIERCODE_TITLE] = suplierPayWork.SupplierCd;                                           // �d����R�[�h
            dr[COL_SUPPLIERNAME_TITLE] = suplierPayWork.SupplierNm1;                                           // �d���於��
            dr[COL_SUPPLIERNAME2_TITLE] = suplierPayWork.SupplierNm2;                                          // �d���於��2
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_SUPPLIERSNM_TITLE] = suplierPayWork.SupplierSnm;                                            // �d���旪��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA MODIFY END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.24 TOKUNAGA ADD START
            dr[COL_RESULTSECCODE_TITLE] = suplierPayWork.ResultsSectCd;                                                 // ���ы��_�R�[�h
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.24 TOKUNAGA ADD END


            dr[COL_PAYEECODE_TITLE]            = suplierPayWork.PayeeCode;                                              // �x����R�[�h
            dr[COL_PAYEENAME_TITLE]            = suplierPayWork.PayeeName;                                              // �x���於��
            dr[COL_PAYEENAME2_TITLE]           = suplierPayWork.PayeeName2;                                             // �x���於��2
            dr[COL_PAYEESNM_TITLE]             = suplierPayWork.PayeeSnm;                                               // �x���旪��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_ADDUPDATEJP_TITLE] = TDateTime.DateTimeToString("YYYY/MM/DD", suplierPayWork.AddUpDate);    // �v��N����
            dr[COL_ADDUPYEARMONTHJP_TITLE]     = TDateTime.DateTimeToString("ggYY.MM", suplierPayWork.AddUpYearMonth);  // �v��N��
            dr[COL_ADDUPDATE_TITLE]            = TDateTime.DateTimeToLongDate(suplierPayWork.AddUpDate);                // _�v��N����
            dr[COL_ADDUPYEARMONTH_TITLE]       = TDateTime.DateTimeToLongDate(suplierPayWork.AddUpYearMonth);           // _�v��N��
            dr[COL_LASTTIMEDEMAND_TITLE]       = suplierPayWork.LastTimePayment;                                         // �O��x�����z
            dr[COL_THISTIMEPAYNRML_TITLE]      = suplierPayWork.ThisTimePayNrml;                                        // ����x�����z�i�ʏ�x���j
            dr[COL_THISTIMEFEEPAYNRML_TITLE]   = suplierPayWork.ThisTimeFeePayNrml;                                     // ����萔���z�i�ʏ�x���j
            dr[COL_THISTIMEDISPAYNRML_TITLE]   = suplierPayWork.ThisTimeDisPayNrml;                                     // ����l���z�i�ʏ�x���j
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISTIMERBTDMDNRML_TITLE]   = suplierPayWork.ThisTimeRbtDmdNrml;                                     // ���񃊃x�[�g�z�i�ʏ�x���j
            //dr[COL_THISTIMEDMDDEPO_TITLE]      = suplierPayWork.ThisTimeDmdDepo;                                        // ����x�����z�i�a����j
            //dr[COL_THISTIMEFEEDMDDEPO_TITLE]   = suplierPayWork.ThisTimeFeeDmdDepo;                                     // ����萔���z�i�a����j
            //dr[COL_THISTIMEDISDMDDEPO_TITLE]   = suplierPayWork.ThisTimeDisDmdDepo;                                     // ����l���z�i�a����j
            //dr[COL_THISTIMERBTDMDDEPO_TITLE]   = suplierPayWork.ThisTimeRbtDmdDepo;                                     // ���񃊃x�[�g�z�i�a����j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISTIMEPAYMENT_TITLE]      = suplierPayWork.ThisTimePayNrml    +                                    // ����x�����z�i�ʏ�x���j
            //                                     suplierPayWork.ThisTimeFeePayNrml +                                    // ����萔���z�i�ʏ�x���j
            //                                     suplierPayWork.ThisTimeDisPayNrml +                                    // ����l���z�i�ʏ�x���j
            //                                     suplierPayWork.ThisTimeRbtDmdNrml +                                    // ���񃊃x�[�g�z�i�ʏ�x���j
            //                                     suplierPayWork.ThisTimeDmdDepo    +                                    // ����x�����z�i�a����j
            //                                     suplierPayWork.ThisTimeFeeDmdDepo +                                    // ����萔���z�i�a����j
            //                                     suplierPayWork.ThisTimeDisDmdDepo +                                    // ����l���z�i�a����j
            //                                     suplierPayWork.ThisTimeRbtDmdDepo;                                     // ���񃊃x�[�g�z�i�a����j
            dr[COL_THISTIMEPAYMENT_TITLE] = suplierPayWork.ThisTimePayNrml +                                    // ����x�����z�i�ʏ�x���j
                                                 suplierPayWork.ThisTimeFeePayNrml +                                    // ����萔���z�i�ʏ�x���j
                                                 suplierPayWork.ThisTimeDisPayNrml ;                                    // ����l���z�i�ʏ�x���j
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_THISTIMETTLBLCDMD_TITLE]    = suplierPayWork.ThisTimeTtlBlcPay;                                      // ����J�z�c���i�x���v�j
            dr[COL_THISTIMESTOCKPRICE_TITLE]        = suplierPayWork.ThisTimeStockPrice;                                          // ����d�����z
            dr[COL_THISSTCPRCTAX_TITLE]         = suplierPayWork.ThisStcPrcTax;                                           // ����d�������
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_TTLINCDTBTTAXEXC_TITLE]     = suplierPayWork.TtlIncDtbtTaxExc;                                       // �x���C���Z���e�B�u�z���v�i�Ŕ����j
            //dr[COL_TTLINCDTBTTAX_TITLE]        = suplierPayWork.TtlIncDtbtTax;                                          // �x���C���Z���e�B�u�z���v�i�Łj
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_THISNETSTCKPRICE_TITLE]     = suplierPayWork.ThisNetStckPrice;                                       // ���E�㍡��d�����z
            //dr[COL_THISNETSTCPRCTAX_TITLE]      = suplierPayWork.ThisNetStcPrcTax;                                        // ���E�㍡��d�������
            dr[COL_OFSTHISTIMESTOCK_TITLE] = suplierPayWork.OfsThisTimeStock;                                       // ���E�㍡��d�����z
            dr[COL_OFSTHISSTOCKTAX_TITLE] = suplierPayWork.OfsThisStockTax;                                        // ���E�㍡��d�������
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_ITDEDOFFSETOUTTAX_TITLE]    = suplierPayWork.ItdedOffsetOutTax;                                      // ���E��O�őΏۊz
            dr[COL_ITDEDOFFSETINTAX_TITLE]     = suplierPayWork.ItdedOffsetInTax;                                       // ���E����őΏۊz
            dr[COL_ITDEDOFFSETTAXFREE_TITLE]   = suplierPayWork.ItdedOffsetTaxFree;                                     // ���E���ېőΏۊz
            dr[COL_OFFSETOUTTAX_TITLE]         = suplierPayWork.OffsetOutTax;                                           // ���E��O�ŏ����
            dr[COL_OFFSETINTAX_TITLE]          = suplierPayWork.OffsetInTax;                                            // ���E����ŏ����
            dr[COL_ITDEDSTCOUTTAX_TITLE]     = suplierPayWork.TtlItdedStcOutTax;                                       // �d���O�őΏۊz
            dr[COL_ITDEDSTCINTAX_TITLE]      = suplierPayWork.TtlItdedStcInTax;                                        // �d�����őΏۊz
            dr[COL_ITDEDSTCTAXFREE_TITLE]    = suplierPayWork.TtlItdedStcTaxFree;                                      // �d����ېőΏۊz
            dr[COL_TTLSTOCKOUTERTAX_TITLE]          = suplierPayWork.TtlStockOuterTax;                                            // �d���O�Ŋz
            dr[COL_TTLSTOCKINNERTAX_TITLE]           = suplierPayWork.TtlStockInnerTax;                                             // �d�����Ŋz
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_ITDEDPAYMOUTTAX_TITLE]      = suplierPayWork.ItdedPaymOutTax;                                        // �x���O�őΏۊz
            //dr[COL_ITDEDPAYMINTAX_TITLE]       = suplierPayWork.ItdedPaymInTax;                                         // �x�����őΏۊz
            //dr[COL_ITDEDPAYMTAXFREE_TITLE]     = suplierPayWork.ItdedPaymTaxFree;                                       // �x����ېőΏۊz
            //dr[COL_PAYMENTOUTTAX_TITLE]        = suplierPayWork.PaymentOutTax;                                          // �x���O�ŏ����
            //dr[COL_PAYMENTINTAX_TITLE]         = suplierPayWork.PaymentInTax;                                           // �x�����ŏ����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_TTLITDEDRETOUTTAX_TITLE]    = suplierPayWork.TtlItdedRetOutTax;                                       // �ԕi�O�őΏۊz
            dr[COL_TTLITDEDRETINTAX_TITLE]     = suplierPayWork.TtlItdedRetInTax;                                        // �ԕi���őΏۊz
            dr[COL_TTLITDEDRETTAXFREE_TITLE]   = suplierPayWork.TtlItdedRetTaxFree;                                      // �ԕi��ېőΏۊz
            dr[COL_TTLRETOUTERTAX_TITLE]       = suplierPayWork.TtlRetOuterTax;                                            // �ԕi�O�Ŋz
            dr[COL_TTLRETINNERTAX_TITLE]       = suplierPayWork.TtlRetInnerTax;                                             // �ԕi���Ŋz
            dr[COL_TTLITDEDDISOUTTAX_TITLE]    = suplierPayWork.TtlItdedDisOutTax;                                       // �l���O�őΏۊz
            dr[COL_TTLITDEDDISINTAX_TITLE]     = suplierPayWork.TtlItdedDisInTax;                                        // �l�����őΏۊz
            dr[COL_TTLITDEDDISTAXFREE_TITLE]   = suplierPayWork.TtlItdedDisTaxFree;                                      // �l����ېőΏۊz
            dr[COL_TTLDISOUTERTAX_TITLE]       = suplierPayWork.TtlDisOuterTax;                                            // �l���O�Ŋz
            dr[COL_TTLDISINNERTAX_TITLE]       = suplierPayWork.TtlDisInnerTax;                                             // �l�����Ŋz
            dr[COL_BALANCEADJUST_TITLE]        = suplierPayWork.BalanceAdjust;                                          // �c�������z

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.07.01 TOKUNAGA ADD START
            dr[COL_TAXADJUST_TITLE] = suplierPayWork.TaxAdjust;                                                         // ����Œ����z
            dr[COL_TOTALADJUST_TITLE] = suplierPayWork.BalanceAdjust + suplierPayWork.TaxAdjust;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.07.01 TOKUNAGA ADD END

            dr[COL_NONSTMNTAPPEARANCE_TITLE]   = 0;                                                                     // �����ϋ��z�i���U�j
            dr[COL_NONSTMNTISDONE_TITLE]       = 0;                                                                     // �����ϋ��z�i�􂵁j 
            dr[COL_STMNTAPPEARANCE_TITLE]      = 0;                                                                     // ���ϋ��z�i���U�j
            dr[COL_STMNTISDONE_TITLE]          = 0;                                                                     // ���ϋ��z�i�􂵁j

            //dr[COL_THISCASHSTOCKPRICE]          = 0;                                                                     // �����d�����z
            //dr[COL_THISCASHSTOCKTAX]            = 0;                                                                     // �����d������Ŋz
            dr[COL_STOCKSLIPCOUNT]             = suplierPayWork.StockSlipCount;                                        // �`�[����
            dr[COL_PAYMENTSCHEDULE]        = TDateTime.DateTimeToLongDate(suplierPayWork.PaymentSchedule);      // �x���\���
            dr[COL_PAYMENTCOND]                = suplierPayWork.PaymentCond;                                            // �������

            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_SUPPCTAXLAYCD_TITLE]     = suplierPayWork.SuppCTaxLayCd;                                       // ����œ]�ŕ���
            dr[COL_SUPPLIERCONSTAXRATE_TITLE]          = suplierPayWork.SupplierConsTaxRate;                                            // ����ŗ�
            dr[COL_FRACTIONPROCCD_TITLE]       = suplierPayWork.FractionProcCd;                                         // �[�������敪
            dr[COL_AFCALDEMANDPRICE_TITLE] = suplierPayWork.StockTotalPayBalance + suplierPayWork.BalanceAdjust + suplierPayWork.TaxAdjust;                                       // �v�Z��x�����z
            //dr[COL_AFCALDEMANDPRICE_TITLE] = suplierPayWork.StockTotalPayBalance;                                       // �v�Z��x�����z
            dr[COL_ACPODRTTL2TMBFBLDMD_TITLE]  = suplierPayWork.StockTtl2TmBfBlPay;                                    // ��2��O�c���i�x���v�j
            dr[COL_ACPODRTTL3TMBFBLDMD_TITLE]  = suplierPayWork.StockTtl3TmBfBlPay;                                    // ��3��O�c���i�x���v�j
            dr[COL_CADDUPUPDEXECDATE_TITLE]    = TDateTime.DateTimeToLongDate(suplierPayWork.CAddUpUpdExecDate);        // �����X�V���s�N����
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2008.06.19 TOKUNAGA DEL START
            //dr[COL_THISRECVINNERTAX_TITLE] = suplierPayWork.ThisRecvInnerTax;
            //dr[COL_THISRECVINTAX_TITLE] = suplierPayWork.ThisRecvInTax;
            //dr[COL_THISRECVOFFSET_TITLE] = suplierPayWork.ThisRecvOffset;
            //dr[COL_THISRECVOFFSETTAX_TITLE] = suplierPayWork.ThisRecvOffsetTax;
            //dr[COL_THISRECVOUTERTAX_TITLE] = suplierPayWork.ThisRecvOuterTax;
            //dr[COL_THISRECVOUTTAX_TITLE] = suplierPayWork.ThisRecvOutTax;
            //dr[COL_THISRECVTAXFREE_TITLE] = suplierPayWork.ThisRecvTaxFree;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2008.06.19 TOKUNAGA DEL END

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            //dr[COL_DMDPROCNUM_TITLE]           = suplierPayWork.DmdProcNum;                                             // �x�������ʔ�
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
            dr[COL_GUID_TITLE]                 = suplierPayWork.FileHeaderGuid;                                         // GUID
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
            dr[COL_CREATEDATETIME] = suplierPayWork.CreateDateTime; // �쐬����
            dr[COL_UPDATEDATETIME] = suplierPayWork.UpdateDateTime; // �X�V����
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
#endif
            this.DataRowFromParamData(ref dr, suplierPayWork, accPayTotalWorkArrayList);
            // 2009.01.14 Del <<<

            // �V�K���R�[�h�̏ꍇ�̂�
            if (newFlg == true)
            {
                // �V�K�s�̒ǉ�
                this._custDmdPrcTable.Rows.Add(dr);
            }

            // �e�[�u���Ɋi�[
            if (this._custDmdPrcDic.ContainsKey(suplierPayWork.FileHeaderGuid) == true)
            {
                this._custDmdPrcDic.Remove(suplierPayWork.FileHeaderGuid);
            }
            this._custDmdPrcDic.Add(suplierPayWork.FileHeaderGuid, suplierPayWork);
        }

        // 2009.01.14 Add >>>

        /// <summary>�d���攃�|���z�}�X�^�I�u�W�F�N�g(�W�v���R�[�h)���C��DataSet�W�J����</summary>
        /// <param name="suplAccPayWork">�d���攃�|���z�}�X�^�I�u�W�F�N�g</param>
        /// <param name="aCalcPayTotalWorkArrayList">���|�x���W�v�f�[�^�I�u�W�F�N�g���X�g</param>
        /// <remarks>
        /// <br>Note       : �d���攃�|���z�}�X�^�I�u�W�F�N�g���A���C��DataSet�Ɋi�[���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2009.01.14</br>
        /// </remarks>
        private void SuplAccPayWorkTotalToDataSet(SuplAccPayWork suplAccPayWork, ArrayList aCalcPayTotalWorkArrayList)
        {
            try
            {
                this._custAccRecTotalTable.BeginLoadData();
                // �X�V�Ώۍs�̎擾
                object[] primryKey = new object[] { suplAccPayWork.AddUpSecCode, 
                                                suplAccPayWork.PayeeCode,
                                                suplAccPayWork.SupplierCd, 
                                                TDateTime.DateTimeToLongDate(suplAccPayWork.AddUpDate) };

                DataRow dr = this._custAccRecTotalTable.Rows.Find(primryKey);
                if (dr == null)
                {
                    // �V�K�ɍs���쐬
                    dr = this._custAccRecTotalTable.NewRow();
                    this._custAccRecTotalTable.Rows.Add(dr);
                }

                this.DataRowFromParamData(ref dr, suplAccPayWork, aCalcPayTotalWorkArrayList);
            }
            finally
            {
                this._custAccRecTotalTable.EndLoadData();
            }
        }

        /// <summary>�d����x�����z�}�X�^�I�u�W�F�N�g���C��DataSet�W�J����</summary>
        /// <param name="suplAccPayWork">�d����x�����z�}�X�^�I�u�W�F�N�g</param>
        /// <param name="accPayTotalWorkArrayList">���Z�x���W�v�f�[�^�I�u�W�F�N�g���X�g</param>
        /// <remarks>
        /// <br>Note       : �d����x�����z�}�X�^�I�u�W�F�N�g���A���C��DataSet�Ɋi�[���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2009.01.14</br>
        /// </remarks>
        private void SuplierPayWorkTotalToDataSet(SuplierPayWork suplierPayWork, ArrayList accPayTotalWorkArrayList)
        {
            try
            {
                this._custDmdPrcTotalTable.BeginLoadData();

                // �X�V�Ώۍs�̎擾
                object[] primryKey = new object[] { suplierPayWork.AddUpSecCode,
                                                suplierPayWork.PayeeCode,
                                                suplierPayWork.SupplierCd, 
                                                suplierPayWork.ResultsSectCd,
                                                TDateTime.DateTimeToLongDate(suplierPayWork.AddUpDate) };
                DataRow dr = this._custDmdPrcTotalTable.Rows.Find(primryKey);
                if (dr == null)
                {
                    // �V�K�ɍs���쐬
                    dr = this._custDmdPrcTotalTable.NewRow();
                    this._custDmdPrcTotalTable.Rows.Add(dr);
                }

                this.DataRowFromParamData(ref dr, suplierPayWork, accPayTotalWorkArrayList);
            }
            finally
            {
                this._custDmdPrcTotalTable.EndLoadData();
            }
        }

        /// <summary>
        /// �d���攃�|���z�}�X�^���[�N�A���|�x���W�v�f�[�^���[�N���X�g��DataRow�ڍ�����
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="custAccRecWork">�d���攃�|���z�}�X�^���[�N</param>
        /// <param name="accRecDepoTotalArrayList">���|�x���W�v�f�[�^���[�N���X�g</param>
        private void DataRowFromParamData(ref DataRow dr, SuplAccPayWork suplAccPayWork, ArrayList aCalcPayTotalWorkArrayList)
        {
            // �폜��
            if (suplAccPayWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", suplAccPayWork.UpdateDateTime);
            }
            dr[COL_ADDUPSECCODE_TITLE] = suplAccPayWork.AddUpSecCode;                                           // �v�㋒�_�R�[�h

            dr[COL_SUPPLIERCODE_TITLE] = suplAccPayWork.SupplierCd;                                             // �d����R�[�h
            dr[COL_SUPPLIERNAME_TITLE] = suplAccPayWork.SupplierNm1;                                            // �d���於��
            dr[COL_SUPPLIERNAME2_TITLE] = suplAccPayWork.SupplierNm2;                                           // �d���於��2
            dr[COL_SUPPLIERSNM_TITLE] = suplAccPayWork.SupplierSnm;                                             // �d���旪��

            dr[COL_PAYEECODE_TITLE] = suplAccPayWork.PayeeCode;                                                 // �x����R�[�h
            dr[COL_PAYEENAME_TITLE] = suplAccPayWork.PayeeName;                                                 // �x���於��
            dr[COL_PAYEENAME2_TITLE] = suplAccPayWork.PayeeName2;                                               // �x���於��2
            dr[COL_PAYEESNM_TITLE] = suplAccPayWork.PayeeSnm;                                                   // �x���旪��
            dr[COL_ADDUPDATEJP_TITLE] = TDateTime.DateTimeToString("YYYY/MM/DD", suplAccPayWork.AddUpDate);     // �v��N����
            dr[COL_ADDUPYEARMONTHJP_TITLE] = TDateTime.DateTimeToString("ggYY.MM", suplAccPayWork.AddUpYearMonth);  // �v��N��
            dr[COL_ADDUPDATE_TITLE] = TDateTime.DateTimeToLongDate(suplAccPayWork.AddUpDate);                   // _�v��N����
            dr[COL_ADDUPYEARMONTH_TITLE] = TDateTime.DateTimeToLongDate(suplAccPayWork.AddUpYearMonth);         // _�v��N��
            dr[COL_LASTTIMEACCPAY_TITLE] = suplAccPayWork.LastTimeAccPay;                                       // �O�񔃊|���z
            dr[COL_THISTIMEPAYNRML_TITLE] = suplAccPayWork.ThisTimePayNrml;                                     // ����x�����z�i�ʏ�x���j
            dr[COL_THISTIMEFEEPAYNRML_TITLE] = suplAccPayWork.ThisTimeFeePayNrml;                               // ����萔���z�i�ʏ�x���j
            dr[COL_THISTIMEDISPAYNRML_TITLE] = suplAccPayWork.ThisTimeDisPayNrml;                               // ����l���z�i�ʏ�x���j
            dr[COL_THISTIMEPAYMENT_TITLE] = suplAccPayWork.ThisTimePayNrml;                                     // ����x�����z�i�ʏ�x���j
            dr[COL_THISTIMETTLBLCACPAY_TITLE] = suplAccPayWork.ThisTimeTtlBlcAcPay;                             // ����J�z�c���i���|�v�j
            dr[COL_THISTIMESTOCKPRICE_TITLE] = suplAccPayWork.ThisTimeStockPrice;                               // ����d�����z
            dr[COL_THISSTCPRCTAX_TITLE] = suplAccPayWork.ThisStcPrcTax;                                         // ����d�������
            dr[COL_OFSTHISTIMESTOCK_TITLE] = suplAccPayWork.OfsThisTimeStock;                                   // ���E�㍡��d�����z
            dr[COL_OFSTHISSTOCKTAX_TITLE] = suplAccPayWork.OfsThisStockTax;                                     // ���E�㍡��d�������
            dr[COL_ITDEDOFFSETOUTTAX_TITLE] = suplAccPayWork.ItdedOffsetOutTax;                                 // ���E��O�őΏۊz
            dr[COL_ITDEDOFFSETINTAX_TITLE] = suplAccPayWork.ItdedOffsetInTax;                                   // ���E����őΏۊz
            dr[COL_ITDEDOFFSETTAXFREE_TITLE] = suplAccPayWork.ItdedOffsetTaxFree;                               // ���E���ېőΏۊz
            dr[COL_OFFSETOUTTAX_TITLE] = suplAccPayWork.OffsetOutTax;                                           // ���E��O�ŏ����
            dr[COL_OFFSETINTAX_TITLE] = suplAccPayWork.OffsetInTax;                                             // ���E����ŏ����
            dr[COL_ITDEDSTCOUTTAX_TITLE] = suplAccPayWork.TtlItdedStcOutTax;                                    // �d���O�őΏۊz
            dr[COL_ITDEDSTCINTAX_TITLE] = suplAccPayWork.TtlItdedStcInTax;                                      // �d�����őΏۊz
            dr[COL_ITDEDSTCTAXFREE_TITLE] = suplAccPayWork.TtlItdedStcTaxFree;                                  // �d����ېőΏۊz
            dr[COL_TTLSTOCKOUTERTAX_TITLE] = suplAccPayWork.TtlStockOuterTax;                                   // �d���O�Ŋz
            dr[COL_TTLSTOCKINNERTAX_TITLE] = suplAccPayWork.TtlStockInnerTax;                                   // �d�����Ŋz
            dr[COL_TTLITDEDRETOUTTAX_TITLE] = suplAccPayWork.TtlItdedRetOutTax;                                 // �ԕi�O�őΏۊz
            dr[COL_TTLITDEDRETINTAX_TITLE] = suplAccPayWork.TtlItdedRetInTax;                                   // �ԕi���őΏۊz
            dr[COL_TTLITDEDRETTAXFREE_TITLE] = suplAccPayWork.TtlItdedRetTaxFree;                               // �ԕi��ېőΏۊz
            dr[COL_TTLRETOUTERTAX_TITLE] = suplAccPayWork.TtlRetOuterTax;                                       // �ԕi�O�Ŋz
            dr[COL_TTLRETINNERTAX_TITLE] = suplAccPayWork.TtlRetInnerTax;                                       // �ԕi���Ŋz
            dr[COL_TTLITDEDDISOUTTAX_TITLE] = suplAccPayWork.TtlItdedDisOutTax;                                 // �l���O�őΏۊz
            dr[COL_TTLITDEDDISINTAX_TITLE] = suplAccPayWork.TtlItdedDisInTax;                                   // �l�����őΏۊz
            dr[COL_TTLITDEDDISTAXFREE_TITLE] = suplAccPayWork.TtlItdedDisTaxFree;                               // �l����ېőΏۊz
            dr[COL_TTLDISOUTERTAX_TITLE] = suplAccPayWork.TtlDisOuterTax;                                       // �l���O�Ŋz
            dr[COL_TTLDISINNERTAX_TITLE] = suplAccPayWork.TtlDisInnerTax;                                       // �l�����Ŋz
            dr[COL_BALANCEADJUST_TITLE] = suplAccPayWork.BalanceAdjust;                                         // �c�������z
            dr[COL_TAXADJUST_TITLE] = suplAccPayWork.TaxAdjust;                                                 // ����Œ����z

            dr[COL_TOTALADJUST_TITLE] = suplAccPayWork.BalanceAdjust + suplAccPayWork.TaxAdjust;

            dr[COL_PAYMENTSCHEDULE] = 0;                                                                        // �i�x���\����j
            dr[COL_PAYMENTCOND] = 0;                                                                            // �i��������j
            dr[COL_SUPPCTAXLAYCD_TITLE] = suplAccPayWork.SuppCTaxLayCd;                                         // ����œ]�ŕ���
            dr[COL_SUPPLIERCONSTAXRATE_TITLE] = suplAccPayWork.SupplierConsTaxRate;                             // ����ŗ�
            dr[COL_FRACTIONPROCCD_TITLE] = suplAccPayWork.FractionProcCd;                                       // �[�������敪
            dr[COL_STCKTTLACCPAYBALANCE_TITLE] = suplAccPayWork.StckTtlAccPayBalance + suplAccPayWork.BalanceAdjust + suplAccPayWork.TaxAdjust;                                      // �v�Z�㓖�����|���z
            dr[COL_STCKTTL2TMBFBLACCPAY_TITLE] = suplAccPayWork.StckTtl2TmBfBlAccPay;                           // ��2��O�c���i���|�v�j
            dr[COL_STCKTTL3TMBFBLACCPAY_TITLE] = suplAccPayWork.StckTtl3TmBfBlAccPay;                           // ��3��O�c���i���|�v�j
            dr[COL_MONTHADDUPEXPDATE_TITLE] = TDateTime.DateTimeToLongDate(suplAccPayWork.MonthAddUpExpDate);   // �����X�V���s�N����
            dr[COL_GUID_TITLE] = suplAccPayWork.FileHeaderGuid;                                                 // GUID
            dr[COL_CREATEDATETIME] = suplAccPayWork.CreateDateTime;                                             // �쐬����
            dr[COL_UPDATEDATETIME] = suplAccPayWork.UpdateDateTime;                                             // �X�V����
            dr[COL_STOCKSLIPCOUNT] = suplAccPayWork.StockSlipCount;                                             // [5047]

            dr[COL_STMONCADDUPUPDDATE_TITLE] = TDateTime.DateTimeToLongDate(suplAccPayWork.StMonCAddUpUpdDate); // �����X�V�J�n�N����
            dr[COL_LAMONCADDUPUPDDATE_TITLE] = TDateTime.DateTimeToLongDate(suplAccPayWork.LaMonCAddUpUpdDate); // �O�񌎎��X�V�N����

            List<ACalcPayTotal> aCalcPayTotalList = new List<ACalcPayTotal>();
            if (aCalcPayTotalWorkArrayList != null)
            {
                foreach (ACalcPayTotalWork aCalcPayTotalWork in aCalcPayTotalWorkArrayList)
                {
                    aCalcPayTotalList.Add(UIDataFromParamData(aCalcPayTotalWork));
                }
            }
            dr[COL_PAYTOTAL] = aCalcPayTotalList;
        }

        /// <summary>
        /// �d����x�����z�}�X�^���[�N�A���Z�x���W�v�f�[�^���[�N���X�g��DataRow�ڍ�����
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="suplierPayWork">�d����x�����z�}�X�^���[�N</param>
        /// <param name="accPayTotalWorkArrayList">���Z�x���W�v�f�[�^���[�N���X�g</param>
        private void DataRowFromParamData(ref DataRow dr, SuplierPayWork suplierPayWork, ArrayList accPayTotalWorkArrayList)
        {
            // �폜��
            if (suplierPayWork.LogicalDeleteCode == 0)
            {
                dr[COL_DELETEDATE_TITLE] = "";
            }
            else
            {
                dr[COL_DELETEDATE_TITLE] = TDateTime.DateTimeToString("ggYY/MM/DD", suplierPayWork.UpdateDateTime);
            }
            dr[COL_ADDUPSECCODE_TITLE] = suplierPayWork.AddUpSecCode;                                           // �v�㋒�_�R�[�h

            dr[COL_SUPPLIERCODE_TITLE] = suplierPayWork.SupplierCd;                                             // �d����R�[�h
            dr[COL_SUPPLIERNAME_TITLE] = suplierPayWork.SupplierNm1;                                            // �d���於��
            dr[COL_SUPPLIERNAME2_TITLE] = suplierPayWork.SupplierNm2;                                           // �d���於��2
            dr[COL_SUPPLIERSNM_TITLE] = suplierPayWork.SupplierSnm;                                             // �d���旪��

            dr[COL_RESULTSECCODE_TITLE] = suplierPayWork.ResultsSectCd;                                         // ���ы��_�R�[�h


            dr[COL_PAYEECODE_TITLE] = suplierPayWork.PayeeCode;                                                 // �x����R�[�h
            dr[COL_PAYEENAME_TITLE] = suplierPayWork.PayeeName;                                                 // �x���於��
            dr[COL_PAYEENAME2_TITLE] = suplierPayWork.PayeeName2;                                               // �x���於��2
            dr[COL_PAYEESNM_TITLE] = suplierPayWork.PayeeSnm;                                                   // �x���旪��
            dr[COL_ADDUPDATEJP_TITLE] = TDateTime.DateTimeToString("YYYY/MM/DD", suplierPayWork.AddUpDate);     // �v��N����
            dr[COL_ADDUPYEARMONTHJP_TITLE] = TDateTime.DateTimeToString("ggYY.MM", suplierPayWork.AddUpYearMonth);  // �v��N��
            dr[COL_ADDUPDATE_TITLE] = TDateTime.DateTimeToLongDate(suplierPayWork.AddUpDate);                   // _�v��N����
            dr[COL_ADDUPYEARMONTH_TITLE] = TDateTime.DateTimeToLongDate(suplierPayWork.AddUpYearMonth);         // _�v��N��
            dr[COL_LASTTIMEDEMAND_TITLE] = suplierPayWork.LastTimePayment;                                      // �O��x�����z
            dr[COL_THISTIMEPAYNRML_TITLE] = suplierPayWork.ThisTimePayNrml;                                     // ����x�����z�i�ʏ�x���j
            dr[COL_THISTIMEFEEPAYNRML_TITLE] = suplierPayWork.ThisTimeFeePayNrml;                               // ����萔���z�i�ʏ�x���j
            dr[COL_THISTIMEDISPAYNRML_TITLE] = suplierPayWork.ThisTimeDisPayNrml;                               // ����l���z�i�ʏ�x���j
            dr[COL_THISTIMEPAYMENT_TITLE] = suplierPayWork.ThisTimePayNrml;                                     // ����x�����z�i�ʏ�x���j
            dr[COL_THISTIMETTLBLCDMD_TITLE] = suplierPayWork.ThisTimeTtlBlcPay;                                 // ����J�z�c���i�x���v�j
            dr[COL_THISTIMESTOCKPRICE_TITLE] = suplierPayWork.ThisTimeStockPrice;                               // ����d�����z
            dr[COL_THISSTCPRCTAX_TITLE] = suplierPayWork.ThisStcPrcTax;                                         // ����d�������
            dr[COL_OFSTHISTIMESTOCK_TITLE] = suplierPayWork.OfsThisTimeStock;                                   // ���E�㍡��d�����z
            dr[COL_OFSTHISSTOCKTAX_TITLE] = suplierPayWork.OfsThisStockTax;                                     // ���E�㍡��d�������
            dr[COL_ITDEDOFFSETOUTTAX_TITLE] = suplierPayWork.ItdedOffsetOutTax;                                 // ���E��O�őΏۊz
            dr[COL_ITDEDOFFSETINTAX_TITLE] = suplierPayWork.ItdedOffsetInTax;                                   // ���E����őΏۊz
            dr[COL_ITDEDOFFSETTAXFREE_TITLE] = suplierPayWork.ItdedOffsetTaxFree;                               // ���E���ېőΏۊz
            dr[COL_OFFSETOUTTAX_TITLE] = suplierPayWork.OffsetOutTax;                                           // ���E��O�ŏ����
            dr[COL_OFFSETINTAX_TITLE] = suplierPayWork.OffsetInTax;                                             // ���E����ŏ����
            dr[COL_ITDEDSTCOUTTAX_TITLE] = suplierPayWork.TtlItdedStcOutTax;                                    // �d���O�őΏۊz
            dr[COL_ITDEDSTCINTAX_TITLE] = suplierPayWork.TtlItdedStcInTax;                                      // �d�����őΏۊz
            dr[COL_ITDEDSTCTAXFREE_TITLE] = suplierPayWork.TtlItdedStcTaxFree;                                  // �d����ېőΏۊz
            dr[COL_TTLSTOCKOUTERTAX_TITLE] = suplierPayWork.TtlStockOuterTax;                                   // �d���O�Ŋz
            dr[COL_TTLSTOCKINNERTAX_TITLE] = suplierPayWork.TtlStockInnerTax;                                   // �d�����Ŋz
            dr[COL_TTLITDEDRETOUTTAX_TITLE] = suplierPayWork.TtlItdedRetOutTax;                                 // �ԕi�O�őΏۊz
            dr[COL_TTLITDEDRETINTAX_TITLE] = suplierPayWork.TtlItdedRetInTax;                                   // �ԕi���őΏۊz
            dr[COL_TTLITDEDRETTAXFREE_TITLE] = suplierPayWork.TtlItdedRetTaxFree;                               // �ԕi��ېőΏۊz
            dr[COL_TTLRETOUTERTAX_TITLE] = suplierPayWork.TtlRetOuterTax;                                       // �ԕi�O�Ŋz
            dr[COL_TTLRETINNERTAX_TITLE] = suplierPayWork.TtlRetInnerTax;                                       // �ԕi���Ŋz
            dr[COL_TTLITDEDDISOUTTAX_TITLE] = suplierPayWork.TtlItdedDisOutTax;                                 // �l���O�őΏۊz
            dr[COL_TTLITDEDDISINTAX_TITLE] = suplierPayWork.TtlItdedDisInTax;                                   // �l�����őΏۊz
            dr[COL_TTLITDEDDISTAXFREE_TITLE] = suplierPayWork.TtlItdedDisTaxFree;                               // �l����ېőΏۊz
            dr[COL_TTLDISOUTERTAX_TITLE] = suplierPayWork.TtlDisOuterTax;                                       // �l���O�Ŋz
            dr[COL_TTLDISINNERTAX_TITLE] = suplierPayWork.TtlDisInnerTax;                                       // �l�����Ŋz
            dr[COL_BALANCEADJUST_TITLE] = suplierPayWork.BalanceAdjust;                                         // �c�������z

            dr[COL_TAXADJUST_TITLE] = suplierPayWork.TaxAdjust;                                                 // ����Œ����z
            dr[COL_TOTALADJUST_TITLE] = suplierPayWork.BalanceAdjust + suplierPayWork.TaxAdjust;

            dr[COL_NONSTMNTAPPEARANCE_TITLE] = 0;                                                               // �����ϋ��z�i���U�j
            dr[COL_NONSTMNTISDONE_TITLE] = 0;                                                                   // �����ϋ��z�i�􂵁j 
            dr[COL_STMNTAPPEARANCE_TITLE] = 0;                                                                  // ���ϋ��z�i���U�j
            dr[COL_STMNTISDONE_TITLE] = 0;                                                                      // ���ϋ��z�i�􂵁j

            dr[COL_STOCKSLIPCOUNT] = suplierPayWork.StockSlipCount;                                             // �`�[����
            dr[COL_PAYMENTSCHEDULE] = TDateTime.DateTimeToLongDate(suplierPayWork.PaymentSchedule);             // �x���\���
            dr[COL_PAYMENTCOND] = suplierPayWork.PaymentCond;                                                   // �������

            dr[COL_SUPPCTAXLAYCD_TITLE] = suplierPayWork.SuppCTaxLayCd;                                         // ����œ]�ŕ���
            dr[COL_SUPPLIERCONSTAXRATE_TITLE] = suplierPayWork.SupplierConsTaxRate;                             // ����ŗ�
            dr[COL_FRACTIONPROCCD_TITLE] = suplierPayWork.FractionProcCd;                                       // �[�������敪
            dr[COL_AFCALDEMANDPRICE_TITLE] = suplierPayWork.StockTotalPayBalance + suplierPayWork.BalanceAdjust + suplierPayWork.TaxAdjust;                                       // �v�Z��x�����z
            dr[COL_ACPODRTTL2TMBFBLDMD_TITLE] = suplierPayWork.StockTtl2TmBfBlPay;                              // ��2��O�c���i�x���v�j
            dr[COL_ACPODRTTL3TMBFBLDMD_TITLE] = suplierPayWork.StockTtl3TmBfBlPay;                              // ��3��O�c���i�x���v�j
            dr[COL_CADDUPUPDEXECDATE_TITLE] = TDateTime.DateTimeToLongDate(suplierPayWork.CAddUpUpdExecDate);   // �����X�V���s�N����

            dr[COL_GUID_TITLE] = suplierPayWork.FileHeaderGuid;                                                 // GUID
            dr[COL_CREATEDATETIME] = suplierPayWork.CreateDateTime;                                             // �쐬����
            dr[COL_UPDATEDATETIME] = suplierPayWork.UpdateDateTime;                                             // �X�V����

            dr[COL_STARTCADDUPUPDDATE_TITLE] = TDateTime.DateTimeToLongDate(suplierPayWork.StartCAddUpUpdDate); // �����X�V�J�n�N����
            dr[COL_LASTCADDUPUPDDATE_TITLE] = TDateTime.DateTimeToLongDate(suplierPayWork.LastCAddUpUpdDate);   // �O������X�V�N����

            List<AccPayTotal> accPayTotalList = new List<AccPayTotal>();
            if (accPayTotalWorkArrayList != null)
            {
                foreach (AccPayTotalWork accPayTotalWork in accPayTotalWorkArrayList)
                {
                    accPayTotalList.Add(UIDataFromParamData(accPayTotalWork));
                }
            }
            dr[COL_PAYTOTAL] = accPayTotalList;
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="aCalcPayTotalWork">���|�x���W�v�f�[�^���[�N</param>
        /// <returns>���|�x���W�v�f�[�^</returns>
        private ACalcPayTotal UIDataFromParamData(ACalcPayTotalWork aCalcPayTotalWork)
        {
            ACalcPayTotal aCalcPayTotal = new ACalcPayTotal();

            aCalcPayTotal.CreateDateTime = aCalcPayTotalWork.CreateDateTime; // �쐬����
            aCalcPayTotal.UpdateDateTime = aCalcPayTotalWork.UpdateDateTime; // �X�V����
            aCalcPayTotal.EnterpriseCode = aCalcPayTotalWork.EnterpriseCode; // ��ƃR�[�h
            aCalcPayTotal.FileHeaderGuid = aCalcPayTotalWork.FileHeaderGuid; // GUID
            aCalcPayTotal.UpdEmployeeCode = aCalcPayTotalWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            aCalcPayTotal.UpdAssemblyId1 = aCalcPayTotalWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            aCalcPayTotal.UpdAssemblyId2 = aCalcPayTotalWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            aCalcPayTotal.LogicalDeleteCode = aCalcPayTotalWork.LogicalDeleteCode; // �_���폜�敪
            aCalcPayTotal.AddUpSecCode = aCalcPayTotalWork.AddUpSecCode; // �v�㋒�_�R�[�h
            aCalcPayTotal.PayeeCode = aCalcPayTotalWork.PayeeCode; // �x����R�[�h
            aCalcPayTotal.SupplierCd = aCalcPayTotalWork.SupplierCd; // �d����R�[�h
            aCalcPayTotal.AddUpDate = aCalcPayTotalWork.AddUpDate; // �v��N����
            aCalcPayTotal.MoneyKindCode = aCalcPayTotalWork.MoneyKindCode; // ����R�[�h
            aCalcPayTotal.MoneyKindName = aCalcPayTotalWork.MoneyKindName; // ���햼��
            aCalcPayTotal.MoneyKindDiv = aCalcPayTotalWork.MoneyKindDiv; // ����敪
            aCalcPayTotal.Payment = aCalcPayTotalWork.Payment; // �x�����z

            return aCalcPayTotal;
        }

        /// <summary>
        /// PramData��UIData�ڍ�����
        /// </summary>
        /// <param name="aCalcPayTotalWork">���Z�x���W�v�f�[�^���[�N</param>
        /// <returns>���Z�x���W�v�f�[�^</returns>
        private AccPayTotal UIDataFromParamData(AccPayTotalWork accPayTotalWork)
        {
            AccPayTotal accPayTotal = new AccPayTotal();

            accPayTotal.CreateDateTime = accPayTotalWork.CreateDateTime; // �쐬����
            accPayTotal.UpdateDateTime = accPayTotalWork.UpdateDateTime; // �X�V����
            accPayTotal.EnterpriseCode = accPayTotalWork.EnterpriseCode; // ��ƃR�[�h
            accPayTotal.FileHeaderGuid = accPayTotalWork.FileHeaderGuid; // GUID
            accPayTotal.UpdEmployeeCode = accPayTotalWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            accPayTotal.UpdAssemblyId1 = accPayTotalWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            accPayTotal.UpdAssemblyId2 = accPayTotalWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            accPayTotal.LogicalDeleteCode = accPayTotalWork.LogicalDeleteCode; // �_���폜�敪
            accPayTotal.AddUpSecCode = accPayTotalWork.AddUpSecCode; // �v�㋒�_�R�[�h
            accPayTotal.PayeeCode = accPayTotalWork.PayeeCode; // �x����R�[�h
            accPayTotal.SupplierCd = accPayTotalWork.SupplierCd; // �d����R�[�h
            accPayTotal.AddUpDate = accPayTotalWork.AddUpDate; // �v��N����
            accPayTotal.MoneyKindCode = accPayTotalWork.MoneyKindCode; // ����R�[�h
            accPayTotal.MoneyKindName = accPayTotalWork.MoneyKindName; // ���햼��
            accPayTotal.MoneyKindDiv = accPayTotalWork.MoneyKindDiv; // ����敪
            accPayTotal.Payment = accPayTotalWork.Payment; // �x�����z

            return accPayTotal;
        }

        /// <summary>
        /// UIData��PramData�ڍ�����
        /// </summary>
        /// <param name="source">���|�x���W�v�f�[�^</param>
        /// <returns>���|�x���W�v�f�[�^���[�N</returns>
        private static ACalcPayTotalWork ParamDataFromUIData(ACalcPayTotal aCalcPayTotal)
        {
            ACalcPayTotalWork aCalcPayTotalWork = new ACalcPayTotalWork();

            aCalcPayTotalWork.CreateDateTime = aCalcPayTotal.CreateDateTime; // �쐬����
            aCalcPayTotalWork.UpdateDateTime = aCalcPayTotal.UpdateDateTime; // �X�V����
            aCalcPayTotalWork.EnterpriseCode = aCalcPayTotal.EnterpriseCode; // ��ƃR�[�h
            aCalcPayTotalWork.FileHeaderGuid = aCalcPayTotal.FileHeaderGuid; // GUID
            aCalcPayTotalWork.UpdEmployeeCode = aCalcPayTotal.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            aCalcPayTotalWork.UpdAssemblyId1 = aCalcPayTotal.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            aCalcPayTotalWork.UpdAssemblyId2 = aCalcPayTotal.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            aCalcPayTotalWork.LogicalDeleteCode = aCalcPayTotal.LogicalDeleteCode; // �_���폜�敪
            aCalcPayTotalWork.AddUpSecCode = aCalcPayTotal.AddUpSecCode; // �v�㋒�_�R�[�h
            aCalcPayTotalWork.PayeeCode = aCalcPayTotal.PayeeCode; // �x����R�[�h
            aCalcPayTotalWork.SupplierCd = aCalcPayTotal.SupplierCd; // �d����R�[�h
            aCalcPayTotalWork.AddUpDate = aCalcPayTotal.AddUpDate; // �v��N����
            aCalcPayTotalWork.MoneyKindCode = aCalcPayTotal.MoneyKindCode; // ����R�[�h
            aCalcPayTotalWork.MoneyKindName = aCalcPayTotal.MoneyKindName; // ���햼��
            aCalcPayTotalWork.MoneyKindDiv = aCalcPayTotal.MoneyKindDiv; // ����敪
            aCalcPayTotalWork.Payment = aCalcPayTotal.Payment; // �x�����z


            return aCalcPayTotalWork;
        }

        /// <summary>
        /// UIData��PramData�ڍ�����
        /// </summary>
        /// <param name="source">���Z�x���W�v�f�[�^</param>
        /// <returns>���Z�x���W�v�f�[�^���[�N</returns>
        private static AccPayTotalWork ParamDataFromUIData(AccPayTotal accPayTotal)
        {
            AccPayTotalWork accPayTotalWork = new AccPayTotalWork();

            accPayTotalWork.CreateDateTime = accPayTotal.CreateDateTime; // �쐬����
            accPayTotalWork.UpdateDateTime = accPayTotal.UpdateDateTime; // �X�V����
            accPayTotalWork.EnterpriseCode = accPayTotal.EnterpriseCode; // ��ƃR�[�h
            accPayTotalWork.FileHeaderGuid = accPayTotal.FileHeaderGuid; // GUID
            accPayTotalWork.UpdEmployeeCode = accPayTotal.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            accPayTotalWork.UpdAssemblyId1 = accPayTotal.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            accPayTotalWork.UpdAssemblyId2 = accPayTotal.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            accPayTotalWork.LogicalDeleteCode = accPayTotal.LogicalDeleteCode; // �_���폜�敪
            accPayTotalWork.AddUpSecCode = accPayTotal.AddUpSecCode; // �v�㋒�_�R�[�h
            accPayTotalWork.PayeeCode = accPayTotal.PayeeCode; // �x����R�[�h
            accPayTotalWork.SupplierCd = accPayTotal.SupplierCd; // �d����R�[�h
            accPayTotalWork.AddUpDate = accPayTotal.AddUpDate; // �v��N����
            accPayTotalWork.MoneyKindCode = accPayTotal.MoneyKindCode; // ����R�[�h
            accPayTotalWork.MoneyKindName = accPayTotal.MoneyKindName; // ���햼��
            accPayTotalWork.MoneyKindDiv = accPayTotal.MoneyKindDiv; // ����敪
            accPayTotalWork.Payment = accPayTotal.Payment; // �x�����z

            return accPayTotalWork;
        }
        // 2009.01.14 Add <<<


        #endregion

        // 2009.01.14 Add >>>
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
        // 2009.01.14 Add <<<

        // --------------------------------------------------
		#region ��r�p�N���X

        /// <summary>�d���攃�|���z�}�X�^��r�N���X</summary>
        /// <remarks>
        /// <br>Note       : �d���攃�|���z�}�X�^�I�u�W�F�N�g�̔�r���s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public class SuplAccPayCompare : IComparer
        {
            #region IComparer �����o

            /// <summary>��r�p���\�b�h</summary>
            /// <param name="x">��r�ΏۃI�u�W�F�N�g</param>
            /// <param name="y">��r�ΏۃI�u�W�F�N�g</param>
            /// <returns>��r����(x �� y : 0���傫������, x �� y : 0��菬��������, x �� y : 0)</returns>
            /// <remarks>
            /// <br>Note       : �d���攃�|���z�}�X�^�I�u�W�F�N�g�̔�r���s���܂��B</br>
            /// <br>Programmer : 30154 ���� ���m</br>
            /// <br>Date       : 2007.04.20</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                SuplAccPay obj1 = x as SuplAccPay;
                SuplAccPay obj2 = y as SuplAccPay;

                // �L�[���Ŕ�r����
                string searchKey1 = obj1.AddUpSecCode + "_" + obj1.SupplierCd + "_" + obj1.AddUpDate;
                string searchKey2 = obj2.AddUpSecCode + "_" + obj2.SupplierCd + "_" + obj2.AddUpDate;
                // �d���攃�|���z�o�̓}�X�^�̃L�[�Ŕ�r
                return searchKey1.CompareTo(searchKey2);
            }

            #endregion
        }

        /// <summary>�d����x�����z�}�X�^��r�N���X</summary>
        /// <remarks>
        /// <br>Note       : �d����x�����z�}�X�^�I�u�W�F�N�g�̔�r���s���܂��B</br>
        /// <br>Programmer : 30154 ���� ���m</br>
        /// <br>Date       : 2007.04.20</br>
        /// </remarks>
        public class SuplierPayCompare : IComparer
        {
            #region IComparer �����o

            /// <summary>��r�p���\�b�h</summary>
            /// <param name="x">��r�ΏۃI�u�W�F�N�g</param>
            /// <param name="y">��r�ΏۃI�u�W�F�N�g</param>
            /// <returns>��r����(x �� y : 0���傫������, x �� y : 0��菬��������, x �� y : 0)</returns>
            /// <remarks>
            /// <br>Note       : �d����x�����z�}�X�^�I�u�W�F�N�g�̔�r���s���܂��B</br>
            /// <br>Programmer : 30154 ���� ���m</br>
            /// <br>Date       : 2007.04.20</br>
            /// </remarks>
            public int Compare(object x, object y)
            {
                SuplierPay obj1 = x as SuplierPay;
                SuplierPay obj2 = y as SuplierPay;

                // �L�[���Ŕ�r����
                string searchKey1 = obj1.AddUpSecCode + "_" + obj1.SupplierCd + "_" + obj1.AddUpDate;
                string searchKey2 = obj2.AddUpSecCode + "_" + obj2.SupplierCd + "_" + obj2.AddUpDate;
                // �d����x�����z�o�̓}�X�^�̃L�[�Ŕ�r
                return searchKey1.CompareTo(searchKey2);
            }

            #endregion
        }

        #endregion

    }
}
