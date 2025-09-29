//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �d����}�X�^
// �v���O�����T�v   : �d����̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22018 ��ؐ��b
// �� �� ��  2008/05/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30452 ��� �r��
// �� �� ��  2008/11/07  �C�����e : �����[�g����0�����̏������C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 20056 ���n ���
// �� �� ��  2009/02/13  �C�����e : Read�Ŏd��������L���b�V������悤�ɏC��
//                       �C�����e : �s�v�����폜
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30413 ����
// �� �� ��  2009/05/27  �C�����e : MANTIS�y13319�z �q�d����̎x����񂪍X�V����Ȃ��s����C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 22008 ����
// �� �� ��  2010/04/06  �C�����e : �i�Ԍ������x�A�b�v�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 31739 ��
// �� �� ��  2020/02/27  �C�����e : �n���f�B�풓����̌ďo�p���\�b�h�ǉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
//using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
//----- ueno add---------- start 2008.01.31
using Broadleaf.Application.LocalAccess;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Library.Windows.Forms;
//----- ueno add---------- end 2008.01.31

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �d����e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d����e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 22018 ��ؐ��b</br>
    /// <br>Date       : 2008.05.08</br>
    /// <br>Update Note: 2008.11.07 30452 ��� �r��</br>
    /// <br>            �E�����[�g����0�����̏������C��</br>
    /// <br>Update Note: 2009.02.13 20056 ���n ���</br>
    /// <br>            �ERead�Ŏd��������L���b�V������悤�ɏC��</br>
    /// <br>            �E�s�v�����폜</br>
	/// <br>Update Note: 2012.04.11 30182 ���J ����</br>
	/// <br>            �E�d����R�[�h�t�H�[�}�b�g�擾�I�v�V�����t���̃R���X�g���N�^��ǉ��i���x�Ή��j</br>
	/// </remarks>
    public class SupplierAcs : IGeneralGuideData
    {
        # region [public Enum]
        /// <summary>
        /// �d�����z�[�������敪
        /// </summary>
        public enum StockFracProcMoneyDiv
        {
            /// <summary>�P��</summary>
            UnPrcFrcProcCd = 0,
            /// <summary>���z</summary>
            MoneyFrcProcCd = 1,
            /// <summary>�����</summary>
            CnsTaxFrcProcCd = 2,
        }
        /// <summary>
        /// �������[�h�񋓌^
        /// </summary>
        public enum SearchMode
        {
            /// <summary>0:�O����v����</summary>
            StartsWith = 0,
            /// <summary>1:�B������</summary>
            Contains = 1,
        }
        # endregion

        # region Private Member

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        ISupplierDB _isupplierDB = null;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki �ۗ� ���[�J���c�a
        //private SupplierLcDB _supplierLcDB = null;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki �ۗ� ���[�J���c�a

        // �K�C�h�ݒ�t�@�C����
        private const string GUIDE_XML_FILENAME = "SUPPLIERGUIDEPARENT.XML";   // XML�t�@�C����

        // �K�C�h�p�����[�^
        private const string GUIDE_ENTERPRISECODE_PARA = "EnterpriseCode";  // (�p�����[�^)��ƃR�[�h
        private const string GUIDE_MNGSECTIONCODE_PARA = "MngSectionCode";  // (�p�����[�^)�Ǘ����_�R�[�h

        // �K�C�h���ڃ^�C�v
        private const string GUIDE_TYPE_STR = "System.String";              // String�^

        // �K�C�h���ږ�
        # region [�K�C�h���ځi���������j]
        private const string GUIDE_SUPPLIERCD_TITLE = "SupplierCd"; // �d����R�[�h
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
        private const string GUIDE_SUPPLIERCD_ZERO_TITLE = "SupplierCdZero"; // �d����R�[�h(�[���l��)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
        private const string GUIDE_MNGSECTIONCODE_TITLE = "MngSectionCode"; // �Ǘ����_�R�[�h
        private const string GUIDE_INPSECTIONCODE_TITLE = "InpSectionCode"; // ���͋��_�R�[�h
        private const string GUIDE_PAYMENTSECTIONCODE_TITLE = "PaymentSectionCode"; // �x�����_�R�[�h
        private const string GUIDE_SUPPLIERNM1_TITLE = "SupplierNm1"; // �d���於1
        private const string GUIDE_SUPPLIERNM2_TITLE = "SupplierNm2"; // �d���於2
        private const string GUIDE_SUPPHONORIFICTITLE_TITLE = "SuppHonorificTitle"; // �d����h��
        private const string GUIDE_SUPPLIERKANA_TITLE = "SupplierKana"; // �d����J�i
        private const string GUIDE_SUPPLIERSNM_TITLE = "SupplierSnm"; // �d���旪��
        private const string GUIDE_ORDERHONORIFICTTL_TITLE = "OrderHonorificTtl"; // �������h��
        private const string GUIDE_BUSINESSTYPECODE_TITLE = "BusinessTypeCode"; // �Ǝ�R�[�h
        private const string GUIDE_SALESAREACODE_TITLE = "SalesAreaCode"; // �̔��G���A�R�[�h
        private const string GUIDE_SUPPLIERPOSTNO_TITLE = "SupplierPostNo"; // �d����X�֔ԍ�
        private const string GUIDE_SUPPLIERADDR1_TITLE = "SupplierAddr1"; // �d����Z��1�i�s���{���s��S�E�����E���j
        private const string GUIDE_SUPPLIERADDR3_TITLE = "SupplierAddr3"; // �d����Z��3�i�Ԓn�j
        private const string GUIDE_SUPPLIERADDR4_TITLE = "SupplierAddr4"; // �d����Z��4�i�A�p�[�g���́j
        private const string GUIDE_SUPPLIERTELNO_TITLE = "SupplierTelNo"; // �d����d�b�ԍ�
        private const string GUIDE_SUPPLIERTELNO1_TITLE = "SupplierTelNo1"; // �d����d�b�ԍ�1
        private const string GUIDE_SUPPLIERTELNO2_TITLE = "SupplierTelNo2"; // �d����d�b�ԍ�2
        private const string GUIDE_PURECODE_TITLE = "PureCode"; // �����敪
        private const string GUIDE_PAYMENTMONTHCODE_TITLE = "PaymentMonthCode"; // �x�����敪�R�[�h
        private const string GUIDE_PAYMENTMONTHNAME_TITLE = "PaymentMonthName"; // �x�����敪����
        private const string GUIDE_PAYMENTDAY_TITLE = "PaymentDay"; // �x����
        private const string GUIDE_SUPPCTAXLAYREFCD_TITLE = "SuppCTaxLayRefCd"; // �d�������œ]�ŕ����Q�Ƌ敪
        private const string GUIDE_SUPPCTAXLAYCD_TITLE = "SuppCTaxLayCd"; // �d�������œ]�ŕ����R�[�h
        private const string GUIDE_SUPPCTAXATIONCD_TITLE = "SuppCTaxationCd"; // �d����ېŕ����R�[�h
        private const string GUIDE_SUPPENTERPRISECD_TITLE = "SuppEnterpriseCd"; // �d�����ƃR�[�h
        private const string GUIDE_PAYEECODE_TITLE = "PayeeCode"; // �x����R�[�h
        private const string GUIDE_SUPPLIERATTRIBUTEDIV_TITLE = "SupplierAttributeDiv"; // �d���摮���敪
        private const string GUIDE_SUPPTTLAMNTDSPWAYCD_TITLE = "SuppTtlAmntDspWayCd"; // �d���摍�z�\�����@�敪
        private const string GUIDE_STCKTTLAMNTDSPWAYREF_TITLE = "StckTtlAmntDspWayRef"; // �d�������z�\�����@�Q�Ƌ敪
        private const string GUIDE_PAYMENTCOND_TITLE = "PaymentCond"; // �x������
        private const string GUIDE_PAYMENTTOTALDAY_TITLE = "PaymentTotalDay"; // �x������
        private const string GUIDE_PAYMENTSIGHT_TITLE = "PaymentSight"; // �x���T�C�g
        private const string GUIDE_STOCKAGENTCODE_TITLE = "StockAgentCode"; // �d���S���҃R�[�h
        private const string GUIDE_STOCKUNPRCFRCPROCCD_TITLE = "StockUnPrcFrcProcCd"; // �d���P���[�������R�[�h
        private const string GUIDE_STOCKMONEYFRCPROCCD_TITLE = "StockMoneyFrcProcCd"; // �d�����z�[�������R�[�h
        private const string GUIDE_STOCKCNSTAXFRCPROCCD_TITLE = "StockCnsTaxFrcProcCd"; // �d������Œ[�������R�[�h
        private const string GUIDE_SUPPRATEGRPCODE_TITLE = "SuppRateGrpCode"; // �d����|���O���[�v�R�[�h
        private const string GUIDE_NTIMECALCSTDATE_TITLE = "NTimeCalcStDate"; // ���񊨒�J�n��
        private const string GUIDE_SUPPLIERNOTE1_TITLE = "SupplierNote1"; // �d������l1
        private const string GUIDE_SUPPLIERNOTE2_TITLE = "SupplierNote2"; // �d������l2
        private const string GUIDE_SUPPLIERNOTE3_TITLE = "SupplierNote3"; // �d������l3
        private const string GUIDE_SUPPLIERNOTE4_TITLE = "SupplierNote4"; // �d������l4
        private const string GUIDE_STOCKAGENTNAME_TITLE = "StockAgentName"; // �d���S���Җ���
        private const string GUIDE_MNGSECTIONNAME_TITLE = "MngSectionName"; // �Ǘ����_����
        private const string GUIDE_INPSECTIONNAME_TITLE = "InpSectionName"; // ���͋��_����
        private const string GUIDE_PAYMENTSECTIONNAME_TITLE = "PaymentSectionName"; // �x�����_����
        private const string GUIDE_BUSINESSTYPENAME_TITLE = "BusinessTypeName"; // �Ǝ햼��
        private const string GUIDE_SALESAREANAME_TITLE = "SalesAreaName"; // �̔��G���A����
        private const string GUIDE_PAYEENAME_TITLE = "PayeeName"; // �x���於��
        private const string GUIDE_PAYEENAME2_TITLE = "PayeeName2"; // �x���於�̂Q
        private const string GUIDE_PAYEESNM_TITLE = "PayeeSnm"; // �x���旪��
        # endregion

        private static bool _isLocalDBRead = false;	// �f�t�H���g�̓����[�g

        // static���[�J���L���b�V��
        private static Dictionary<int, Supplier> _supplierDic;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
        private string _supplierCodeFormat; // �d����R�[�h�t�H�[�}�b�g
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD

        # endregion

        # region Constructor

        /// <summary>
        /// �d����e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d����e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public SupplierAcs()
        {
			// -- Add St 2012.04.11 30182 R.Tachiya --
			//���ʃR���X�g���N�^
			this.SupplierAcsProc(true);
			// -- Add Ed 2012.04.11 30182 R.Tachiya --

			#region // -- Del 2012.04.11 30182 R.Tachiya --
			//try
			//{
			//    // �����[�g�I�u�W�F�N�g�擾
			//    this._isupplierDB = (ISupplierDB)MediationSupplierDB.GetSupplierDB();
			//}
			//catch ( Exception )
			//{
			//    //�I�t���C������null���Z�b�g
			//    this._isupplierDB = null;
			//}

			//// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki �ۗ� ���[�J���c�a
			////// ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
			////this._supplierLcDB = new SupplierLcDB();
			//// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki �ۗ� ���[�J���c�a

			//// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
			//// �d����R�[�h�t�H�[�}�b�g�擾(�A�N�Z�X�N���X�p)
			//UiSetFileAcs uiSetFileAcs = new UiSetFileAcs();
			//uiSetFileAcs.ReadXML( string.Empty );
			//UiSet uiset = uiSetFileAcs.GetUiSet( string.Empty, "tNedit_SupplierCd" );
			//if ( uiset != null )
			//{
			//    _supplierCodeFormat = new string( '0', uiset.Column );
			//}
			//else
			//{
			//    _supplierCodeFormat = string.Empty;
			//}
			//// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
			#endregion
		}

		// -- Add St 2012.04.11 30182 R.Tachiya --
		/// <summary>
		/// �d����e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="getSupplierCodeFormatOpt">�d����R�[�h�t�H�[�}�b�g�擾�I�v�V����(�擾�����͍����j</param>
		/// <remarks>
		/// <br>Note       : �d����e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B�d����R�[�h�t�H�[�}�b�g�I�v�V�����t���B</br>
		/// <br>Programmer : 30182 ���J ����</br>
		/// <br>Date       : 2012.04.11</br>
		/// </remarks>
		public SupplierAcs(bool getSupplierCodeFormatOpt)
		{
			//���ʃR���X�g���N�^
			this.SupplierAcsProc(getSupplierCodeFormatOpt);
		}

		/// <summary>
		/// �d����e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <param name="getSupplierCodeFormatOpt">�d����R�[�h�t�H�[�}�b�g�擾�I�v�V����(�擾�����͍����j</param>
		/// <remarks>
		/// <br>Note       : �d����e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B���ʃ��\�b�h�B</br>
		/// <br>Programmer : 30182 ���J ����</br>
		/// <br>Date       : 2012.04.11</br>
		/// </remarks>
		private void SupplierAcsProc(bool getSupplierCodeFormatOpt)
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._isupplierDB = (ISupplierDB)MediationSupplierDB.GetSupplierDB();
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._isupplierDB = null;
			}

			// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki �ۗ� ���[�J���c�a
			//// ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
			//this._supplierLcDB = new SupplierLcDB();
			// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki �ۗ� ���[�J���c�a

			//�d����R�[�h�t�H�[�}�b�g�擾�I�v�V���� ON
			if (getSupplierCodeFormatOpt)
			{
				//0�l�̌������擾//

				// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
				// �d����R�[�h�t�H�[�}�b�g�擾(�A�N�Z�X�N���X�p)
				UiSetFileAcs uiSetFileAcs = new UiSetFileAcs();
				uiSetFileAcs.ReadXML(string.Empty);
				UiSet uiset = uiSetFileAcs.GetUiSet(string.Empty, "tNedit_SupplierCd");
				if (uiset != null)
				{
					_supplierCodeFormat = new string('0', uiset.Column);
				}
				else
				{
					_supplierCodeFormat = string.Empty;
				}
				// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
			}
			//�d����R�[�h�t�H�[�}�b�g�擾�I�v�V���� OFF
			else
			{
				//0�l�̌����擾��//
				_supplierCodeFormat = string.Empty;
			}

			return;
		}
		// -- Add Ed 2012.04.11 30182 R.Tachiya --

        # endregion

        #region Public Property

        //================================================================================
        //  �v���p�e�B
        //================================================================================
        /// <summary>
        /// ���[�J���c�aRead���[�h
        /// </summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }
        #endregion

        #region GetOnlineMode

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if ( this._isupplierDB == null )
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        #endregion

        #region Read Methods
        // -- ADD 2010/04/06 -------------------------->>>
        /// <summary>
        /// �d����ǂݍ��ݏ���(�L���b�V���@�\�L)
        /// </summary>
        /// <param name="supplier"></param>
        /// <param name="enterpriseCode"></param>
        /// <param name="supplierCode"></param>
        /// <returns></returns>
        public int ReadCache(out Supplier supplier, string enterpriseCode, int supplierCode)
        {
            supplier = null;

            //�p�����[�^���s���̏ꍇ�͎擾�����͍s��Ȃ�
            if (string.IsNullOrEmpty(enterpriseCode) || supplierCode == 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            
            // �L���b�V������擾
            supplier = this.GetFromCache(supplierCode);
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (supplier == null)
            {
                status = this.Read(out supplier, enterpriseCode, supplierCode);
            }

            return status;

        }
        // -- ADD 2010/04/06 --------------------------<<<

        // --- ADD 2020/02/27 ---------->>>>>
        /// <summary>
        /// �d����ǂݍ��ݏ����i�n���f�B�p�j
        /// </summary>
        /// <param name="retValue">�d����I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d�������ǂݍ��݂܂��B</br>
        /// <br>Programmer : 31739 ��</br>
        /// <br>Date       : 2020.04.08</br>
        /// </remarks>
        public int ReadHandy(out object retValue, object enterpriseCode, object supplierCode)
        {
            // �p�����[�^�ϊ�
            Supplier result = new Supplier();
            string paraEnterpriseCode = enterpriseCode as string;
            int paraSupplierCode = (int)supplierCode;
            SupplierWork convResult = new SupplierWork();

            // ���\�b�h�ďo
            int status = this.Read(out result, paraEnterpriseCode, paraSupplierCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
            	if (result != null)
            	{
                    convResult = CopyToSupplierWorkFromSupplier(result);
                }
            }

            // �p�����[�^�ϊ�
            retValue = (object)convResult;

            // �߂�l�ԋp
            return status;
        }
        // --- ADD 2020/02/27 ----------<<<<<

        /// <summary>
        /// �d����ǂݍ��ݏ���
        /// </summary>
        /// <param name="supplier">�d����I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d�������ǂݍ��݂܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int Read( out Supplier supplier, string enterpriseCode, int supplierCode )
        {
            try
            {
                //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 ADD
                //// �L���b�V������擾
                //supplier = GetFromCache( supplierCode );
                //if ( supplier != null )
                //{
                //    return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //}
                //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 ADD

                supplier = new Supplier();
                int status = 0;
                SupplierWork supplierWork = new SupplierWork();
                supplierWork.EnterpriseCode = enterpriseCode;
                supplierWork.SupplierCd = supplierCode;

                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki �ۗ��@���[�J���Ή�
                //if ( _isLocalDBRead )
                //{
                //    status = this._supplierLcDB.Read( ref supplierWork, 0 );
                //}
                //else
                //{
                //    // XML�֕ϊ����A������̃o�C�i����
                //    byte[] parabyte = XmlByteSerializer.Serialize( supplierWork );
                //    status = this._isupplierDB.Read( ref parabyte, 0 );

                //    if ( status == 0 )
                //    {
                //        // XML�̓ǂݍ���
                //        supplierWork = (SupplierWork)XmlByteSerializer.Deserialize( parabyte, typeof( SupplierWork ) );
                //        // �N���X�������o�R�s�[
                //        supplier = CopyToSupplierFromSupplierWork( supplierWork );
                //    }
                //}

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize( supplierWork );
                status = this._isupplierDB.Read( ref parabyte, 0 );

                if ( status == 0 )
                {
                    // XML�̓ǂݍ���
                    supplierWork = (SupplierWork)XmlByteSerializer.Deserialize( parabyte, typeof( SupplierWork ) );
                    // �N���X�������o�R�s�[
                    supplier = CopyToSupplierFromSupplierWork( supplierWork );
                    // 2009.02.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // �d������L���b�V��
                    this.UpdateCache(supplier);
                    // 2009.02.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki �ۗ��@���[�J���Ή�

                // 2009.02.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //if (status == 0)
                //{
                //    // �N���X�������o�R�s�[
                //    supplier = CopyToSupplierFromSupplierWork( supplierWork );
                //}
                // 2009.02.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                return status;
            }
            catch ( Exception )
            {
                //�ʐM�G���[��-1��߂�
                supplier = null;
                //�I�t���C������null���Z�b�g
                this._isupplierDB = null;
                return -1;
            }
        }
        #endregion

        #region Write Methods

        /// <summary>
        /// �d����o�^�E�X�V����
        /// </summary>
        /// <param name="supplierList">�d���惊�X�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d������̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        //public int Write( ref Supplier supplier )     // DEL 2009/05/27
        public int Write(ref ArrayList supplierList)    // ADD 2009/05/27
        {
            // �d����N���X����d���惏�[�J�[�N���X�Ƀ����o�R�s�[
            //SupplierWork supplierWork = CopyToSupplierWorkFromSupplier( supplier );   // DEL 2009/05/27
            SupplierWork supplierWork = CopyToSupplierWorkFromSupplier(supplierList[0] as Supplier);    // ADD 2009/05/27

            ArrayList paraList = new ArrayList();

            // �e�̎d������i�[
            paraList.Add( supplierWork );

            //object paraObj = paraList;    // DEL 2009/05/27
            int status = 0;
            try
            {
                // ADD 2009/05/27 ------>>>
                object paraSearchObj = supplierWork;
                object outSupplierList;
                // �q�̎d������擾
                status = this._isupplierDB.SearchWithChildren(out outSupplierList, paraSearchObj, 0, ConstantManagement.LogicalMode.GetDataAll);
                
                // �q�̎d��������X�V
                if (outSupplierList != null)
                {
                    ArrayList childrenList = outSupplierList as ArrayList;
                    for (int i = 0; i < childrenList.Count; i++)
                    {
                        SupplierWork childSupplierWork = childrenList[i] as SupplierWork;

                        if (childSupplierWork.SupplierCd == supplierWork.SupplierCd)
                        {
                            continue;
                        }
                        else
                        {
                            ReflectChildSupplierFromParent(ref childSupplierWork, supplierWork);
                            paraList.Add(childSupplierWork);
                        }
                    }
                }

                // �e�Ǝq�̎d��������i�[
                object paraObj = paraList;
                // ADD 2009/05/27 ------<<<

                //�d���揑������
                status = this._isupplierDB.Write(ref paraObj);

                if ( status == 0 )
                {
                    paraList = (ArrayList)paraObj;
                    // DEL 2009/05/27 ------>>>
                    //supplierWork = (SupplierWork)paraList[0];

                    //// ref�p�����[�^��ݒ�
                    //supplier = CopyToSupplierFromSupplierWork( supplierWork );
                    //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 ADD
                    //// �L���b�V���X�V
                    //UpdateCache( supplier );
                    //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 ADD
                    // DEL 2009/05/27 ------<<<
                    
                    // ADD 2009/05/27 ------>>>
                    supplierList = new ArrayList();
                    for (int i = 0; i < paraList.Count; i++)
                    {
                        supplierWork = (SupplierWork)paraList[i];

                        // ref�p�����[�^��ݒ�
                        Supplier supplier = CopyToSupplierFromSupplierWork(supplierWork);

                        // �L���b�V���X�V
                        UpdateCache(supplier);

                        supplierList.Add(supplier);
                    }
                    // ADD 2009/05/27 ------<<<
                }
            }
            catch ( Exception )
            {
                //�ʐM�G���[��-1��߂�
                status = -1;
            }
            return status;
        }

        #endregion

        #region LogicalDelete Methods

        /// <summary>
        /// �d����_���폜����
        /// </summary>
        /// <param name="supplier">�d����I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d������̘_���폜���s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int LogicalDelete( ref Supplier supplier )
        {
            int status = 0;

            try
            {
                // �d����ϊ�
                ArrayList paraLst = new ArrayList();
                SupplierWork supplierWork = CopyToSupplierWorkFromSupplier( supplier );
                paraLst.Add( supplierWork );
                object paraObj = paraLst;

                // �_���폜
                status = this._isupplierDB.LogicalDelete( ref paraObj );

                if ( status == 0 )
                {
                    paraLst = (ArrayList)paraObj;
                    supplierWork = (SupplierWork)paraLst[0];

                    // ref�p�����[�^��ݒ�
                    supplier = CopyToSupplierFromSupplierWork( supplierWork );
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 ADD
                    // �L���b�V������폜
                    DeleteFromCache( supplier.SupplierCd );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 ADD
                }

                return status;
            }
            catch ( Exception )
            {
                //�I�t���C������null���Z�b�g
                this._isupplierDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        #endregion

        #region Revival Methods

        /// <summary>
        /// �d����_���폜��������
        /// </summary>
        /// <param name="supplier">�d����I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d������̕������s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int Revival( ref Supplier supplier )
        {
            try
            {
                SupplierWork supplierWork = CopyToSupplierWorkFromSupplier( supplier );
                ArrayList paraLst = new ArrayList();

                paraLst.Add( supplierWork );

                object paraObj = paraLst;

                // ��������
                int status = this._isupplierDB.RevivalLogicalDelete( ref paraObj );

                if ( status == 0 )
                {
                    paraLst = (ArrayList)paraObj;
                    supplierWork = (SupplierWork)paraLst[0];
                    
                    // ref�p�����[�^��ݒ�
                    supplier = CopyToSupplierFromSupplierWork( supplierWork );
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 ADD
                    // �L���b�V���X�V
                    UpdateCache( supplier );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 ADD
                }
                return status;
            }
            catch ( Exception )
            {
                //�I�t���C������null���Z�b�g
                this._isupplierDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        #endregion

        #region Delete Methods

        /// <summary>
        /// �d���敨���폜����
        /// </summary>
        /// <param name="supplier">�d����I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d������̕����폜���s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int Delete( Supplier supplier )
        {
            try
            {
                SupplierWork supplierWork = CopyToSupplierWorkFromSupplier( supplier );

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize( supplierWork );

                // �d���敨���폜
                int status = this._isupplierDB.Delete( parabyte );
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/07 ADD
                // �L���b�V������폜
                DeleteFromCache( supplier.SupplierCd );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/07 ADD

                return status;
            }
            catch ( Exception )
            {
                //�I�t���C������null���Z�b�g
                this._isupplierDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        #endregion

        #region Search Methods

        /// <summary>
        /// �d����S���������i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d����̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int Search( out ArrayList retList, string enterpriseCode )
        {
            int retTotalCnt;
            return SearchProc( out retList, out retTotalCnt, enterpriseCode, "", 0, null );
        }

        /// <summary>
        /// �d����S��������(���_�i����)�i�_���폜�����j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <param name="sectionCode">���_�R�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �Y�����_�ł̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int Search( out ArrayList retList, string enterpriseCode, string sectionCode )
        {
            int retTotalCnt;
            return SearchProc( out retList, out retTotalCnt, enterpriseCode, sectionCode, 0, null );
        }

        // --- ADD 2020.02.27 ---------->>>>>
        /// <summary>
        /// �d���挟�������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d�������ǂݍ��݂܂��B</br>
        /// <br>Programmer : 31739 ��</br>br>
        /// <br>Date       : 2020.02.27</br>
        /// </remarks>
        public int SearchAll(out object retList, object enterpriseCode)
        {
            // �^�ϊ�
            ArrayList paraList = new ArrayList();
            string paraEnterpriseCode = enterpriseCode as string;

            // �������\�b�h�ďo
            int status = this.SearchAll(out paraList, paraEnterpriseCode);

            ArrayList resultList = new ArrayList();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                int count = 0;
                foreach (Supplier itm in paraList)
                {
                	if (itm != null)
                	{
                        if (itm.LogicalDeleteCode == 0)
                        {
                            SupplierWork convWk = CopyToSupplierWorkFromSupplier(itm);
                            resultList.Add(convWk);
                            count++;
                            if (count >= 999)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            // �o�̓p�����[�^���ďo�p�����[�^�֐ݒ�
            retList = (object)resultList;

            // �������\�b�h�ďo���ʃX�e�[�^�X��ԋp
            return status;
        }
        // --- ADD 2020.02.27 ----------<<<<<

        /// <summary>
        /// �d���挟�������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d����̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int SearchAll( out ArrayList retList, string enterpriseCode )
        {
            int retTotalCnt;
            return SearchProc( out retList, out retTotalCnt, enterpriseCode, "", ConstantManagement.LogicalMode.GetData01, null );
        }

        /// <summary>
        /// �d���挟������(���_�i�荞��)�i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <param name="sectionCode">�d����R�[�h</param>		        
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �Y�����_�ł̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int SearchAll( out ArrayList retList, string enterpriseCode, string sectionCode )
        {
            int retTotalCnt;
            return SearchProc( out retList, out retTotalCnt, enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetData01, null );
        }
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/05/22 ADD
        /// <summary>
        /// �d���挟�������i����"���Ӑ�K�C�h"�̋@�\�Ɋ�Â��@�\�ǉ��j
        /// </summary>
        /// <param name="retList"></param>
        /// <param name="searchParameter"></param>
        /// <param name="kanaSearchType">0:�O����v����,1:�B������</param>
        /// <returns></returns>
        public int Search( out ArrayList retList, Supplier searchParameter, int kanaSearchType )
        {
            retList = new ArrayList();

            ArrayList selectList;
            int retTotalCnt;
            // �Ǘ����_�i�荞�݂�SearchProc�̈����œK�p�ł���(MngSectionCode)
            int status = SearchProc( out selectList, out retTotalCnt, searchParameter.EnterpriseCode, searchParameter.MngSectionCode, 0, null );

            foreach ( object obj in selectList )
            {
                if ( obj is Supplier )
                {
                    Supplier targetSupplier = (obj as Supplier);

                    // �R�[�h
                    if ( searchParameter.SupplierCd != 0 && targetSupplier.SupplierCd != searchParameter.SupplierCd ) continue;
                    // �J�i(�O����v)
                    if ( searchParameter.SupplierKana != string.Empty && kanaSearchType == (int)SearchMode.StartsWith )
                    {
                        if ( !targetSupplier.SupplierKana.StartsWith( searchParameter.SupplierKana ) ) continue;
                    }
                    // �J�i(�����܂�)
                    if ( searchParameter.SupplierKana != string.Empty && kanaSearchType == (int)SearchMode.Contains )
                    {
                        if ( !targetSupplier.SupplierKana.Contains( searchParameter.SupplierKana ) ) continue;
                    }
                    //if ( searchParameter.SupplierCd != 0 && targetSupplier.SupplierCd != searchParameter.SupplierCd ) continue;
                    // �d���S���҃R�[�h
                    if ( searchParameter.StockAgentCode != string.Empty && targetSupplier.StockAgentCode != searchParameter.StockAgentCode ) continue;


                    retList.Add( targetSupplier );
                }
            }

            // �ԋp���X�g�ɊY���f�[�^��������΃f�[�^�Ȃ��ŕԂ�
            if ( status == 0 )
            {
                if ( retList.Count == 0 )
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                }
            }
            return status;
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/05/22 ADD

        /// <summary>
        /// �d���挟������(���_�i����)
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevSupplier��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="prevSupplier">�O��ŏI�S���҃f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d����̌����������s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        private int SearchProc( out ArrayList retList, out int retTotalCnt, string enterpriseCode, string sectionCode, ConstantManagement.LogicalMode logicalMode, Supplier prevSupplier )
        {
            // ������
            retList = new ArrayList();
            retTotalCnt = 0;

            // �߂�l���X�g
            ArrayList wkList = new ArrayList();

            // ���������Z�b�g
            SupplierWork supplierWork = new SupplierWork();
            if ( prevSupplier != null ) supplierWork = CopyToSupplierWorkFromSupplier( prevSupplier );

            supplierWork.EnterpriseCode = enterpriseCode;
            supplierWork.MngSectionCode = sectionCode;

            // Search�p�����[�^
            ArrayList paraList = new ArrayList();
            paraList.Add( supplierWork );
            object paraobj = paraList;

            // ����
            object retobj = null;

            int status_o = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki �ۗ� ���[�J���c�a
            //if ( _isLocalDBRead )
            //{
            //    // ���[�J��
            //    List<SupplierWork> supplierWorkList = new List<SupplierWork>();
            //    status_o = this._supplierLcDB.Search( out supplierWorkList, supplierWork, 0, logicalMode );

            //    if ( status_o == 0 )
            //    {
            //        ArrayList al = new ArrayList();
            //        al.AddRange( supplierWorkList );
            //        retobj = (object)al;
            //    }
            //}
            //else
            //{
            //    // �����[�g
            //    status_o = this._isupplierDB.Search( out retobj, paraobj, 0, logicalMode );
            //}

            // �����[�g
            status_o = this._isupplierDB.Search( out retobj, paraobj, 0, logicalMode );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki �ۗ� ���[�J���c�a

            // �������ʔ���
            switch ( status_o )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    wkList = retobj as ArrayList;

                    if ( wkList != null )
                    {
                        foreach ( SupplierWork wkLineupWork in wkList )
                        {
                            if ( (wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                ((sectionCode == "") || (wkLineupWork.MngSectionCode.TrimEnd() == sectionCode.TrimEnd()) || (wkLineupWork.MngSectionCode.TrimEnd() == "")) )
                            {
                                //�����o�R�s�[
                                retList.Add( CopyToSupplierFromSupplierWork( wkLineupWork ) );
                            }
                        }

                        retTotalCnt = retList.Count;
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND: // ADD 2008/11/07
                    status_o = (int)ConstantManagement.DB_Status.ctDB_EOF; // ADD 2008/11/07
                    break;
                default:
                    return status_o;
            }

            return status_o;
        }


        /// <summary>
        /// �d����}�X�^���������i���[�J��DB(�K�C�h)�p�j
        /// </summary>
        /// <param name="retList">�擾���ʊi�[�pArrayList</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d����}�X�^�̃��[�J��DB�����������s���A�擾���ʂ�ArryList�ŕԂ��܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int SearchLocalDB( out ArrayList retList, string enterpriseCode, string sectionCode )
        {
            SupplierWork supplierWork = new SupplierWork();
            supplierWork.EnterpriseCode = enterpriseCode;
            supplierWork.MngSectionCode = sectionCode;

            retList = new ArrayList();
            retList.Clear();

            int status = 0;

            List<SupplierWork> supplierWorkList = null;

            status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    if ( supplierWorkList != null )
                    {
                        foreach ( SupplierWork wkLineupWork in supplierWorkList )
                        {
                            if ( (wkLineupWork.EnterpriseCode == enterpriseCode) &&
                                ((sectionCode == "") || (wkLineupWork.MngSectionCode.TrimEnd() == sectionCode.TrimEnd()) || (wkLineupWork.MngSectionCode.TrimEnd() == "")) )
                            {
                                //�����o�R�s�[
                                retList.Add( CopyToSupplierFromSupplierWork( wkLineupWork ) );
                            }
                        }
                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:
                    return status;
            }

            return status;
        }


        #endregion

        #region MemberCopy Methods
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�d���惏�[�N�N���X�ˎd����j
        /// </summary>
        /// <param name="supplierWork">�d���惏�[�N�N���X</param>
        /// <returns>�d����</returns>
        /// <remarks>
        /// <br>Note       : �d���惏�[�N�N���X����d����փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        private Supplier CopyToSupplierFromSupplierWork( SupplierWork supplierWork )
        {
            Supplier supplier = new Supplier();

            # region [�����o�R�s�[�i���������j]
            supplier.CreateDateTime = supplierWork.CreateDateTime; // �쐬����
            supplier.UpdateDateTime = supplierWork.UpdateDateTime; // �X�V����
            supplier.EnterpriseCode = supplierWork.EnterpriseCode; // ��ƃR�[�h
            supplier.FileHeaderGuid = supplierWork.FileHeaderGuid; // GUID
            supplier.UpdEmployeeCode = supplierWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            supplier.UpdAssemblyId1 = supplierWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            supplier.UpdAssemblyId2 = supplierWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            supplier.LogicalDeleteCode = supplierWork.LogicalDeleteCode; // �_���폜�敪
            supplier.SupplierCd = supplierWork.SupplierCd; // �d����R�[�h
            supplier.MngSectionCode = supplierWork.MngSectionCode; // �Ǘ����_�R�[�h
            supplier.InpSectionCode = supplierWork.InpSectionCode; // ���͋��_�R�[�h
            supplier.PaymentSectionCode = supplierWork.PaymentSectionCode; // �x�����_�R�[�h
            supplier.SupplierNm1 = supplierWork.SupplierNm1; // �d���於1
            supplier.SupplierNm2 = supplierWork.SupplierNm2; // �d���於2
            supplier.SuppHonorificTitle = supplierWork.SuppHonorificTitle; // �d����h��
            supplier.SupplierKana = supplierWork.SupplierKana; // �d����J�i
            supplier.SupplierSnm = supplierWork.SupplierSnm; // �d���旪��
            supplier.OrderHonorificTtl = supplierWork.OrderHonorificTtl; // �������h��
            supplier.BusinessTypeCode = supplierWork.BusinessTypeCode; // �Ǝ�R�[�h
            supplier.SalesAreaCode = supplierWork.SalesAreaCode; // �̔��G���A�R�[�h
            supplier.SupplierPostNo = supplierWork.SupplierPostNo; // �d����X�֔ԍ�
            supplier.SupplierAddr1 = supplierWork.SupplierAddr1; // �d����Z��1�i�s���{���s��S�E�����E���j
            supplier.SupplierAddr3 = supplierWork.SupplierAddr3; // �d����Z��3�i�Ԓn�j
            supplier.SupplierAddr4 = supplierWork.SupplierAddr4; // �d����Z��4�i�A�p�[�g���́j
            supplier.SupplierTelNo = supplierWork.SupplierTelNo; // �d����d�b�ԍ�
            supplier.SupplierTelNo1 = supplierWork.SupplierTelNo1; // �d����d�b�ԍ�1
            supplier.SupplierTelNo2 = supplierWork.SupplierTelNo2; // �d����d�b�ԍ�2
            supplier.PureCode = supplierWork.PureCode; // �����敪
            supplier.PaymentMonthCode = supplierWork.PaymentMonthCode; // �x�����敪�R�[�h
            supplier.PaymentMonthName = supplierWork.PaymentMonthName; // �x�����敪����
            supplier.PaymentDay = supplierWork.PaymentDay; // �x����
            supplier.SuppCTaxLayRefCd = supplierWork.SuppCTaxLayRefCd; // �d�������œ]�ŕ����Q�Ƌ敪
            supplier.SuppCTaxLayCd = supplierWork.SuppCTaxLayCd; // �d�������œ]�ŕ����R�[�h
            supplier.SuppCTaxationCd = supplierWork.SuppCTaxationCd; // �d����ېŕ����R�[�h
            supplier.SuppEnterpriseCd = supplierWork.SuppEnterpriseCd; // �d�����ƃR�[�h
            supplier.PayeeCode = supplierWork.PayeeCode; // �x����R�[�h
            supplier.SupplierAttributeDiv = supplierWork.SupplierAttributeDiv; // �d���摮���敪
            supplier.SuppTtlAmntDspWayCd = supplierWork.SuppTtlAmntDspWayCd; // �d���摍�z�\�����@�敪
            supplier.StckTtlAmntDspWayRef = supplierWork.StckTtlAmntDspWayRef; // �d�������z�\�����@�Q�Ƌ敪
            supplier.PaymentCond = supplierWork.PaymentCond; // �x������
            supplier.PaymentTotalDay = supplierWork.PaymentTotalDay; // �x������
            supplier.PaymentSight = supplierWork.PaymentSight; // �x���T�C�g
            supplier.StockAgentCode = supplierWork.StockAgentCode; // �d���S���҃R�[�h
            supplier.StockUnPrcFrcProcCd = supplierWork.StockUnPrcFrcProcCd; // �d���P���[�������R�[�h
            supplier.StockMoneyFrcProcCd = supplierWork.StockMoneyFrcProcCd; // �d�����z�[�������R�[�h
            supplier.StockCnsTaxFrcProcCd = supplierWork.StockCnsTaxFrcProcCd; // �d������Œ[�������R�[�h
            supplier.NTimeCalcStDate = supplierWork.NTimeCalcStDate; // ���񊨒�J�n��
            supplier.SupplierNote1 = supplierWork.SupplierNote1; // �d������l1
            supplier.SupplierNote2 = supplierWork.SupplierNote2; // �d������l2
            supplier.SupplierNote3 = supplierWork.SupplierNote3; // �d������l3
            supplier.SupplierNote4 = supplierWork.SupplierNote4; // �d������l4
            supplier.StockAgentName = supplierWork.StockAgentName; // �d���S���Җ���
            supplier.MngSectionName = supplierWork.MngSectionName; // �Ǘ����_����
            supplier.InpSectionName = supplierWork.InpSectionName; // ���͋��_����
            supplier.PaymentSectionName = supplierWork.PaymentSectionName; // �x�����_����
            supplier.BusinessTypeName = supplierWork.BusinessTypeName; // �Ǝ햼��
            supplier.SalesAreaName = supplierWork.SalesAreaName; // �̔��G���A����
            supplier.PayeeName = supplierWork.PayeeName; // �x���於��
            supplier.PayeeName2 = supplierWork.PayeeName2; // �x���於�̂Q
            supplier.PayeeSnm = supplierWork.PayeeSnm; // �x���旪��
            # endregion

            return supplier;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�d����ˎd���惏�[�N�N���X�j
        /// </summary>
        /// <param name="supplier">�d����N���X</param>
        /// <returns>�d���惏�[�N</returns>
        /// <remarks>
        /// <br>Note       : �d���悩��d���惏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        private SupplierWork CopyToSupplierWorkFromSupplier( Supplier supplier )
        {
            SupplierWork supplierWork = new SupplierWork();

            # region [�����o�R�s�[�i���������j]
            supplierWork.CreateDateTime = supplier.CreateDateTime; // �쐬����
            supplierWork.UpdateDateTime = supplier.UpdateDateTime; // �X�V����
            supplierWork.EnterpriseCode = supplier.EnterpriseCode; // ��ƃR�[�h
            supplierWork.FileHeaderGuid = supplier.FileHeaderGuid; // GUID
            supplierWork.UpdEmployeeCode = supplier.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
            supplierWork.UpdAssemblyId1 = supplier.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            supplierWork.UpdAssemblyId2 = supplier.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            supplierWork.LogicalDeleteCode = supplier.LogicalDeleteCode; // �_���폜�敪
            supplierWork.SupplierCd = supplier.SupplierCd; // �d����R�[�h
            supplierWork.MngSectionCode = supplier.MngSectionCode; // �Ǘ����_�R�[�h
            supplierWork.InpSectionCode = supplier.InpSectionCode; // ���͋��_�R�[�h
            supplierWork.PaymentSectionCode = supplier.PaymentSectionCode; // �x�����_�R�[�h
            supplierWork.SupplierNm1 = supplier.SupplierNm1; // �d���於1
            supplierWork.SupplierNm2 = supplier.SupplierNm2; // �d���於2
            supplierWork.SuppHonorificTitle = supplier.SuppHonorificTitle; // �d����h��
            supplierWork.SupplierKana = supplier.SupplierKana; // �d����J�i
            supplierWork.SupplierSnm = supplier.SupplierSnm; // �d���旪��
            supplierWork.OrderHonorificTtl = supplier.OrderHonorificTtl; // �������h��
            supplierWork.BusinessTypeCode = supplier.BusinessTypeCode; // �Ǝ�R�[�h
            supplierWork.SalesAreaCode = supplier.SalesAreaCode; // �̔��G���A�R�[�h
            supplierWork.SupplierPostNo = supplier.SupplierPostNo; // �d����X�֔ԍ�
            supplierWork.SupplierAddr1 = supplier.SupplierAddr1; // �d����Z��1�i�s���{���s��S�E�����E���j
            supplierWork.SupplierAddr3 = supplier.SupplierAddr3; // �d����Z��3�i�Ԓn�j
            supplierWork.SupplierAddr4 = supplier.SupplierAddr4; // �d����Z��4�i�A�p�[�g���́j
            supplierWork.SupplierTelNo = supplier.SupplierTelNo; // �d����d�b�ԍ�
            supplierWork.SupplierTelNo1 = supplier.SupplierTelNo1; // �d����d�b�ԍ�1
            supplierWork.SupplierTelNo2 = supplier.SupplierTelNo2; // �d����d�b�ԍ�2
            supplierWork.PureCode = supplier.PureCode; // �����敪
            supplierWork.PaymentMonthCode = supplier.PaymentMonthCode; // �x�����敪�R�[�h
            supplierWork.PaymentMonthName = supplier.PaymentMonthName; // �x�����敪����
            supplierWork.PaymentDay = supplier.PaymentDay; // �x����
            supplierWork.SuppCTaxLayRefCd = supplier.SuppCTaxLayRefCd; // �d�������œ]�ŕ����Q�Ƌ敪
            supplierWork.SuppCTaxLayCd = supplier.SuppCTaxLayCd; // �d�������œ]�ŕ����R�[�h
            supplierWork.SuppCTaxationCd = supplier.SuppCTaxationCd; // �d����ېŕ����R�[�h
            supplierWork.SuppEnterpriseCd = supplier.SuppEnterpriseCd; // �d�����ƃR�[�h
            supplierWork.PayeeCode = supplier.PayeeCode; // �x����R�[�h
            supplierWork.SupplierAttributeDiv = supplier.SupplierAttributeDiv; // �d���摮���敪
            supplierWork.SuppTtlAmntDspWayCd = supplier.SuppTtlAmntDspWayCd; // �d���摍�z�\�����@�敪
            supplierWork.StckTtlAmntDspWayRef = supplier.StckTtlAmntDspWayRef; // �d�������z�\�����@�Q�Ƌ敪
            supplierWork.PaymentCond = supplier.PaymentCond; // �x������
            supplierWork.PaymentTotalDay = supplier.PaymentTotalDay; // �x������
            supplierWork.PaymentSight = supplier.PaymentSight; // �x���T�C�g
            supplierWork.StockAgentCode = supplier.StockAgentCode; // �d���S���҃R�[�h
            supplierWork.StockUnPrcFrcProcCd = supplier.StockUnPrcFrcProcCd; // �d���P���[�������R�[�h
            supplierWork.StockMoneyFrcProcCd = supplier.StockMoneyFrcProcCd; // �d�����z�[�������R�[�h
            supplierWork.StockCnsTaxFrcProcCd = supplier.StockCnsTaxFrcProcCd; // �d������Œ[�������R�[�h
            supplierWork.NTimeCalcStDate = supplier.NTimeCalcStDate; // ���񊨒�J�n��
            supplierWork.SupplierNote1 = supplier.SupplierNote1; // �d������l1
            supplierWork.SupplierNote2 = supplier.SupplierNote2; // �d������l2
            supplierWork.SupplierNote3 = supplier.SupplierNote3; // �d������l3
            supplierWork.SupplierNote4 = supplier.SupplierNote4; // �d������l4
            supplierWork.StockAgentName = supplier.StockAgentName; // �d���S���Җ���
            supplierWork.MngSectionName = supplier.MngSectionName; // �Ǘ����_����
            supplierWork.InpSectionName = supplier.InpSectionName; // ���͋��_����
            supplierWork.PaymentSectionName = supplier.PaymentSectionName; // �x�����_����
            supplierWork.BusinessTypeName = supplier.BusinessTypeName; // �Ǝ햼��
            supplierWork.SalesAreaName = supplier.SalesAreaName; // �̔��G���A����
            supplierWork.PayeeName = supplier.PayeeName; // �x���於��
            supplierWork.PayeeName2 = supplier.PayeeName2; // �x���於�̂Q
            supplierWork.PayeeSnm = supplier.PayeeSnm; // �x���旪��
            # endregion

            return supplierWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[���� (�K�C�h�I���f�[�^�ˎd��Ȗڐݒ�}�X�^�N���X)
        /// </summary>
        /// <param name="guideData">�K�C�h�I���f�[�^</param>
        /// <returns>�d��Ȗڐݒ�}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �K�C�h�I���f�[�^����d��Ȗڐݒ�}�X�^�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        private Supplier CopyToSupplierFromGuideData( Hashtable guideData )
        {
            Supplier supplier = new Supplier();

            # region [�K�C�h���ʂ���f�[�^�擾�i���������j]
            supplier.SupplierCd = (Int32)guideData[GUIDE_SUPPLIERCD_TITLE]; // �d����R�[�h
            supplier.MngSectionCode = (string)guideData[GUIDE_MNGSECTIONCODE_TITLE]; // �Ǘ����_�R�[�h
            supplier.InpSectionCode = (string)guideData[GUIDE_INPSECTIONCODE_TITLE]; // ���͋��_�R�[�h
            supplier.PaymentSectionCode = (string)guideData[GUIDE_PAYMENTSECTIONCODE_TITLE]; // �x�����_�R�[�h
            supplier.SupplierNm1 = (string)guideData[GUIDE_SUPPLIERNM1_TITLE]; // �d���於1
            supplier.SupplierNm2 = (string)guideData[GUIDE_SUPPLIERNM2_TITLE]; // �d���於2
            supplier.SuppHonorificTitle = (string)guideData[GUIDE_SUPPHONORIFICTITLE_TITLE]; // �d����h��
            supplier.SupplierKana = (string)guideData[GUIDE_SUPPLIERKANA_TITLE]; // �d����J�i
            supplier.SupplierSnm = (string)guideData[GUIDE_SUPPLIERSNM_TITLE]; // �d���旪��
            supplier.OrderHonorificTtl = (string)guideData[GUIDE_ORDERHONORIFICTTL_TITLE]; // �������h��
            supplier.BusinessTypeCode = (Int32)guideData[GUIDE_BUSINESSTYPECODE_TITLE]; // �Ǝ�R�[�h
            supplier.SalesAreaCode = (Int32)guideData[GUIDE_SALESAREACODE_TITLE]; // �̔��G���A�R�[�h
            supplier.SupplierPostNo = (string)guideData[GUIDE_SUPPLIERPOSTNO_TITLE]; // �d����X�֔ԍ�
            supplier.SupplierAddr1 = (string)guideData[GUIDE_SUPPLIERADDR1_TITLE]; // �d����Z��1�i�s���{���s��S�E�����E���j
            supplier.SupplierAddr3 = (string)guideData[GUIDE_SUPPLIERADDR3_TITLE]; // �d����Z��3�i�Ԓn�j
            supplier.SupplierAddr4 = (string)guideData[GUIDE_SUPPLIERADDR4_TITLE]; // �d����Z��4�i�A�p�[�g���́j
            supplier.SupplierTelNo = (string)guideData[GUIDE_SUPPLIERTELNO_TITLE]; // �d����d�b�ԍ�
            supplier.SupplierTelNo1 = (string)guideData[GUIDE_SUPPLIERTELNO1_TITLE]; // �d����d�b�ԍ�1
            supplier.SupplierTelNo2 = (string)guideData[GUIDE_SUPPLIERTELNO2_TITLE]; // �d����d�b�ԍ�2
            supplier.PureCode = (Int32)guideData[GUIDE_PURECODE_TITLE]; // �����敪
            supplier.PaymentMonthCode = (Int32)guideData[GUIDE_PAYMENTMONTHCODE_TITLE]; // �x�����敪�R�[�h
            supplier.PaymentMonthName = (string)guideData[GUIDE_PAYMENTMONTHNAME_TITLE]; // �x�����敪����
            supplier.PaymentDay = (Int32)guideData[GUIDE_PAYMENTDAY_TITLE]; // �x����
            supplier.SuppCTaxLayRefCd = (Int32)guideData[GUIDE_SUPPCTAXLAYREFCD_TITLE]; // �d�������œ]�ŕ����Q�Ƌ敪
            supplier.SuppCTaxLayCd = (Int32)guideData[GUIDE_SUPPCTAXLAYCD_TITLE]; // �d�������œ]�ŕ����R�[�h
            supplier.SuppCTaxationCd = (Int32)guideData[GUIDE_SUPPCTAXATIONCD_TITLE]; // �d����ېŕ����R�[�h
            supplier.SuppEnterpriseCd = (string)guideData[GUIDE_SUPPENTERPRISECD_TITLE]; // �d�����ƃR�[�h
            supplier.PayeeCode = (Int32)guideData[GUIDE_PAYEECODE_TITLE]; // �x����R�[�h
            supplier.SupplierAttributeDiv = (Int32)guideData[GUIDE_SUPPLIERATTRIBUTEDIV_TITLE]; // �d���摮���敪
            supplier.SuppTtlAmntDspWayCd = (Int32)guideData[GUIDE_SUPPTTLAMNTDSPWAYCD_TITLE]; // �d���摍�z�\�����@�敪
            supplier.StckTtlAmntDspWayRef = (Int32)guideData[GUIDE_STCKTTLAMNTDSPWAYREF_TITLE]; // �d�������z�\�����@�Q�Ƌ敪
            supplier.PaymentCond = (Int32)guideData[GUIDE_PAYMENTCOND_TITLE]; // �x������
            supplier.PaymentTotalDay = (Int32)guideData[GUIDE_PAYMENTTOTALDAY_TITLE]; // �x������
            supplier.PaymentSight = (Int32)guideData[GUIDE_PAYMENTSIGHT_TITLE]; // �x���T�C�g
            supplier.StockAgentCode = (string)guideData[GUIDE_STOCKAGENTCODE_TITLE]; // �d���S���҃R�[�h
            supplier.StockUnPrcFrcProcCd = (Int32)guideData[GUIDE_STOCKUNPRCFRCPROCCD_TITLE]; // �d���P���[�������R�[�h
            supplier.StockMoneyFrcProcCd = (Int32)guideData[GUIDE_STOCKMONEYFRCPROCCD_TITLE]; // �d�����z�[�������R�[�h
            supplier.StockCnsTaxFrcProcCd = (Int32)guideData[GUIDE_STOCKCNSTAXFRCPROCCD_TITLE]; // �d������Œ[�������R�[�h
            supplier.NTimeCalcStDate = (Int32)guideData[GUIDE_NTIMECALCSTDATE_TITLE]; // ���񊨒�J�n��
            supplier.SupplierNote1 = (string)guideData[GUIDE_SUPPLIERNOTE1_TITLE]; // �d������l1
            supplier.SupplierNote2 = (string)guideData[GUIDE_SUPPLIERNOTE2_TITLE]; // �d������l2
            supplier.SupplierNote3 = (string)guideData[GUIDE_SUPPLIERNOTE3_TITLE]; // �d������l3
            supplier.SupplierNote4 = (string)guideData[GUIDE_SUPPLIERNOTE4_TITLE]; // �d������l4
            supplier.StockAgentName = (string)guideData[GUIDE_STOCKAGENTNAME_TITLE]; // �d���S���Җ���
            supplier.MngSectionName = (string)guideData[GUIDE_MNGSECTIONNAME_TITLE]; // �Ǘ����_����
            supplier.InpSectionName = (string)guideData[GUIDE_INPSECTIONNAME_TITLE]; // ���͋��_����
            supplier.PaymentSectionName = (string)guideData[GUIDE_PAYMENTSECTIONNAME_TITLE]; // �x�����_����
            supplier.BusinessTypeName = (string)guideData[GUIDE_BUSINESSTYPENAME_TITLE]; // �Ǝ햼��
            supplier.SalesAreaName = (string)guideData[GUIDE_SALESAREANAME_TITLE]; // �̔��G���A����
            supplier.PayeeName = (string)guideData[GUIDE_PAYEENAME_TITLE]; // �x���於��
            supplier.PayeeName2 = (string)guideData[GUIDE_PAYEENAME2_TITLE]; // �x���於�̂Q
            supplier.PayeeSnm = (string)guideData[GUIDE_PAYEESNM_TITLE]; // �x���旪��            
            # endregion

            return supplier;
        }

        /// <summary>
        /// DataRow�R�s�[�����i�d����N���X�˃K�C�h�pDataRow�j
        /// </summary>
        /// <param name="guideRow">�K�C�h�pDataRow</param>
        /// <param name="supplier">�d����N���X</param>
        /// <remarks>
        /// <br>Note       : �d����N���X����K�C�h�pDataRow�փR�s�[���s���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        private void CopyToGuideRowFromSupplier( ref DataRow guideRow, Supplier supplier )
        {
            # region [�f�[�^����K�C�h�ɃZ�b�g�i���������j]
            guideRow[GUIDE_SUPPLIERCD_TITLE] = supplier.SupplierCd; // �d����R�[�h
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
            guideRow[GUIDE_SUPPLIERCD_ZERO_TITLE] = supplier.SupplierCd.ToString( _supplierCodeFormat ); // �d����R�[�h�[���l��
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
            guideRow[GUIDE_MNGSECTIONCODE_TITLE] = supplier.MngSectionCode; // �Ǘ����_�R�[�h
            guideRow[GUIDE_INPSECTIONCODE_TITLE] = supplier.InpSectionCode; // ���͋��_�R�[�h
            guideRow[GUIDE_PAYMENTSECTIONCODE_TITLE] = supplier.PaymentSectionCode; // �x�����_�R�[�h
            guideRow[GUIDE_SUPPLIERNM1_TITLE] = supplier.SupplierNm1; // �d���於1
            guideRow[GUIDE_SUPPLIERNM2_TITLE] = supplier.SupplierNm2; // �d���於2
            guideRow[GUIDE_SUPPHONORIFICTITLE_TITLE] = supplier.SuppHonorificTitle; // �d����h��
            guideRow[GUIDE_SUPPLIERKANA_TITLE] = supplier.SupplierKana; // �d����J�i
            guideRow[GUIDE_SUPPLIERSNM_TITLE] = supplier.SupplierSnm; // �d���旪��
            guideRow[GUIDE_ORDERHONORIFICTTL_TITLE] = supplier.OrderHonorificTtl; // �������h��
            guideRow[GUIDE_BUSINESSTYPECODE_TITLE] = supplier.BusinessTypeCode; // �Ǝ�R�[�h
            guideRow[GUIDE_SALESAREACODE_TITLE] = supplier.SalesAreaCode; // �̔��G���A�R�[�h
            guideRow[GUIDE_SUPPLIERPOSTNO_TITLE] = supplier.SupplierPostNo; // �d����X�֔ԍ�
            guideRow[GUIDE_SUPPLIERADDR1_TITLE] = supplier.SupplierAddr1; // �d����Z��1�i�s���{���s��S�E�����E���j
            guideRow[GUIDE_SUPPLIERADDR3_TITLE] = supplier.SupplierAddr3; // �d����Z��3�i�Ԓn�j
            guideRow[GUIDE_SUPPLIERADDR4_TITLE] = supplier.SupplierAddr4; // �d����Z��4�i�A�p�[�g���́j
            guideRow[GUIDE_SUPPLIERTELNO_TITLE] = supplier.SupplierTelNo; // �d����d�b�ԍ�
            guideRow[GUIDE_SUPPLIERTELNO1_TITLE] = supplier.SupplierTelNo1; // �d����d�b�ԍ�1
            guideRow[GUIDE_SUPPLIERTELNO2_TITLE] = supplier.SupplierTelNo2; // �d����d�b�ԍ�2
            guideRow[GUIDE_PURECODE_TITLE] = supplier.PureCode; // �����敪
            guideRow[GUIDE_PAYMENTMONTHCODE_TITLE] = supplier.PaymentMonthCode; // �x�����敪�R�[�h
            guideRow[GUIDE_PAYMENTMONTHNAME_TITLE] = supplier.PaymentMonthName; // �x�����敪����
            guideRow[GUIDE_PAYMENTDAY_TITLE] = supplier.PaymentDay; // �x����
            guideRow[GUIDE_SUPPCTAXLAYREFCD_TITLE] = supplier.SuppCTaxLayRefCd; // �d�������œ]�ŕ����Q�Ƌ敪
            guideRow[GUIDE_SUPPCTAXLAYCD_TITLE] = supplier.SuppCTaxLayCd; // �d�������œ]�ŕ����R�[�h
            guideRow[GUIDE_SUPPCTAXATIONCD_TITLE] = supplier.SuppCTaxationCd; // �d����ېŕ����R�[�h
            guideRow[GUIDE_SUPPENTERPRISECD_TITLE] = supplier.SuppEnterpriseCd; // �d�����ƃR�[�h
            guideRow[GUIDE_PAYEECODE_TITLE] = supplier.PayeeCode; // �x����R�[�h
            guideRow[GUIDE_SUPPLIERATTRIBUTEDIV_TITLE] = supplier.SupplierAttributeDiv; // �d���摮���敪
            guideRow[GUIDE_SUPPTTLAMNTDSPWAYCD_TITLE] = supplier.SuppTtlAmntDspWayCd; // �d���摍�z�\�����@�敪
            guideRow[GUIDE_STCKTTLAMNTDSPWAYREF_TITLE] = supplier.StckTtlAmntDspWayRef; // �d�������z�\�����@�Q�Ƌ敪
            guideRow[GUIDE_PAYMENTCOND_TITLE] = supplier.PaymentCond; // �x������
            guideRow[GUIDE_PAYMENTTOTALDAY_TITLE] = supplier.PaymentTotalDay; // �x������
            guideRow[GUIDE_PAYMENTSIGHT_TITLE] = supplier.PaymentSight; // �x���T�C�g
            guideRow[GUIDE_STOCKAGENTCODE_TITLE] = supplier.StockAgentCode; // �d���S���҃R�[�h
            guideRow[GUIDE_STOCKUNPRCFRCPROCCD_TITLE] = supplier.StockUnPrcFrcProcCd; // �d���P���[�������R�[�h
            guideRow[GUIDE_STOCKMONEYFRCPROCCD_TITLE] = supplier.StockMoneyFrcProcCd; // �d�����z�[�������R�[�h
            guideRow[GUIDE_STOCKCNSTAXFRCPROCCD_TITLE] = supplier.StockCnsTaxFrcProcCd; // �d������Œ[�������R�[�h
            guideRow[GUIDE_NTIMECALCSTDATE_TITLE] = supplier.NTimeCalcStDate; // ���񊨒�J�n��
            guideRow[GUIDE_SUPPLIERNOTE1_TITLE] = supplier.SupplierNote1; // �d������l1
            guideRow[GUIDE_SUPPLIERNOTE2_TITLE] = supplier.SupplierNote2; // �d������l2
            guideRow[GUIDE_SUPPLIERNOTE3_TITLE] = supplier.SupplierNote3; // �d������l3
            guideRow[GUIDE_SUPPLIERNOTE4_TITLE] = supplier.SupplierNote4; // �d������l4
            guideRow[GUIDE_STOCKAGENTNAME_TITLE] = supplier.StockAgentName; // �d���S���Җ���
            guideRow[GUIDE_MNGSECTIONNAME_TITLE] = supplier.MngSectionName; // �Ǘ����_����
            guideRow[GUIDE_INPSECTIONNAME_TITLE] = supplier.InpSectionName; // ���͋��_����
            guideRow[GUIDE_PAYMENTSECTIONNAME_TITLE] = supplier.PaymentSectionName; // �x�����_����
            guideRow[GUIDE_BUSINESSTYPENAME_TITLE] = supplier.BusinessTypeName; // �Ǝ햼��
            guideRow[GUIDE_SALESAREANAME_TITLE] = supplier.SalesAreaName; // �̔��G���A����
            guideRow[GUIDE_PAYEENAME_TITLE] = supplier.PayeeName; // �x���於��
            guideRow[GUIDE_PAYEENAME2_TITLE] = supplier.PayeeName2; // �x���於�̂Q
            guideRow[GUIDE_PAYEESNM_TITLE] = supplier.PayeeSnm; // �x���旪��
            # endregion
        }

        #endregion

        #region Guide Methods

        /// <summary>
        /// �}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="supplier">�擾�f�[�^</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int ExecuteGuid( out Supplier supplier, string enterpriseCode, string sectionCode )
        {
            int status = -1;
            supplier = new Supplier();

            TableGuideParent tableGuideParent = new TableGuideParent( GUIDE_XML_FILENAME );
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            inObj.Add( GUIDE_ENTERPRISECODE_PARA, enterpriseCode );   // ��ƃR�[�h
            inObj.Add( GUIDE_MNGSECTIONCODE_PARA, sectionCode );        // ���_�R�[�h

            // �K�C�h�N��
            if ( tableGuideParent.Execute( 0, inObj, ref retObj ) )
            {
                // �I���f�[�^�̎擾
                supplier = CopyToSupplierFromGuideData( retObj );
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
                supplier.EnterpriseCode = enterpriseCode;   // ��ƃR�[�h�Z�b�g
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
                status = 0;
            }
            else
            {
                // �L�����Z��
                status = 1;
            }

            return status;
        }

        /// <summary>
        /// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
        /// <remarks>
        /// <br>Note	   : �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        public int GetGuideData( int mode, Hashtable inParm, ref DataSet guideList )
        {
            int status = -1;
            string enterpriseCode = "";
            string sectionCode = "";

            if ( inParm.ContainsKey( GUIDE_ENTERPRISECODE_PARA ) )
            {
                // ��ƃR�[�h�ݒ�L��
                enterpriseCode = inParm[GUIDE_ENTERPRISECODE_PARA].ToString();
            }
            else
            {
                // ��ƃR�[�h�ݒ薳��
                // �L�蓾�Ȃ��̂ŃG���[
                return status;
            }

            // ���_�R�[�h�ݒ�L��
            if ( inParm.ContainsKey( GUIDE_MNGSECTIONCODE_PARA ) )
            {
                sectionCode = inParm[GUIDE_MNGSECTIONCODE_PARA].ToString();
            }

            // �}�X�^�e�[�u���Ǎ���(���[�J��DB�ɕύX)
            ArrayList retList;
            status = this.SearchAll( out retList, enterpriseCode, sectionCode );

            switch ( status )
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // �K�C�h�����N����
                    if ( guideList.Tables.Count == 0 )
                    {
                        // �K�C�h�p�f�[�^�Z�b�g����\�z
                        this.GuideDataSetColumnConstruction( ref guideList );
                    }

                    // �K�C�h�p�f�[�^�Z�b�g�̍쐬
                    this.GetGuideDataSet( ref guideList, retList, inParm );

                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    status = 4;
                    break;
                default:
                    status = -1;
                    break;
            }

            return status;
        }

        /// <summary>
        /// �K�C�h�p�f�[�^�Z�b�g�쐬����
        /// </summary>
        /// <param name="retDataSet">���ʎ擾�f�[�^�Z�b�g</param>>
        /// <param name="retList">���ʎ擾�A���C���X�g</param>>
        /// <param name="inParm">�i������</param>>
        /// <remarks>
        /// <br>Note	   : �K�C�h�p�f�[�^�Z�b�g�������s�Ȃ�</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        private void GetGuideDataSet( ref DataSet retDataSet, ArrayList retList, Hashtable inParm )
        {
            Supplier supplier = null;
            DataRow guideRow = null;

            // �s�����������ĐV�����f�[�^��ǉ�
            retDataSet.Tables[0].Rows.Clear();
            retDataSet.Tables[0].BeginLoadData();

            int dataCnt = 0;
            while ( dataCnt < retList.Count )
            {
                supplier = (Supplier)retList[dataCnt];
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/26 ADD
                if ( supplier.LogicalDeleteCode == 0 )
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/26 ADD
                {
                    guideRow = retDataSet.Tables[0].NewRow();
                    // �f�[�^�R�s�[����
                    CopyToGuideRowFromSupplier( ref guideRow, supplier );
                    // �f�[�^�ǉ�
                    retDataSet.Tables[0].Rows.Add( guideRow );
                }
                dataCnt++;
            }

            retDataSet.Tables[0].EndLoadData();
        }

        /// <summary>
        /// �K�C�h�p�f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <param name="guideList">�K�C�h�p�f�[�^�Z�b�g</param>>
        /// <remarks>
        /// <br>Note       : �K�C�h�p�f�[�^�Z�b�g�̗�����\�z���܂��B</br>
        /// <br>Programmer : 22018 ��ؐ��b</br>
        /// <br>Date       : 2008.05.08</br>
        /// </remarks>
        private void GuideDataSetColumnConstruction( ref DataSet guideList )
        {
            DataTable table = new DataTable();

            # region [�K�C�h�p�e�[�u�������i���������j]
            // �d����R�[�h
            table.Columns.Add( GUIDE_SUPPLIERCD_TITLE, typeof( Int32 ) );
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/10/21 ADD
            // �\���p�d����R�[�h(�[���l��)
            table.Columns.Add( GUIDE_SUPPLIERCD_ZERO_TITLE, typeof( string ) );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/10/21 ADD
            // �Ǘ����_�R�[�h
            table.Columns.Add( GUIDE_MNGSECTIONCODE_TITLE, typeof( string ) );
            // ���͋��_�R�[�h
            table.Columns.Add( GUIDE_INPSECTIONCODE_TITLE, typeof( string ) );
            // �x�����_�R�[�h
            table.Columns.Add( GUIDE_PAYMENTSECTIONCODE_TITLE, typeof( string ) );
            // �d���於1
            table.Columns.Add( GUIDE_SUPPLIERNM1_TITLE, typeof( string ) );
            // �d���於2
            table.Columns.Add( GUIDE_SUPPLIERNM2_TITLE, typeof( string ) );
            // �d����h��
            table.Columns.Add( GUIDE_SUPPHONORIFICTITLE_TITLE, typeof( string ) );
            // �d����J�i
            table.Columns.Add( GUIDE_SUPPLIERKANA_TITLE, typeof( string ) );
            // �d���旪��
            table.Columns.Add( GUIDE_SUPPLIERSNM_TITLE, typeof( string ) );
            // �������h��
            table.Columns.Add( GUIDE_ORDERHONORIFICTTL_TITLE, typeof( string ) );
            // �Ǝ�R�[�h
            table.Columns.Add( GUIDE_BUSINESSTYPECODE_TITLE, typeof( Int32 ) );
            // �̔��G���A�R�[�h
            table.Columns.Add( GUIDE_SALESAREACODE_TITLE, typeof( Int32 ) );
            // �d����X�֔ԍ�
            table.Columns.Add( GUIDE_SUPPLIERPOSTNO_TITLE, typeof( string ) );
            // �d����Z��1�i�s���{���s��S�E�����E���j
            table.Columns.Add( GUIDE_SUPPLIERADDR1_TITLE, typeof( string ) );
            // �d����Z��3�i�Ԓn�j
            table.Columns.Add( GUIDE_SUPPLIERADDR3_TITLE, typeof( string ) );
            // �d����Z��4�i�A�p�[�g���́j
            table.Columns.Add( GUIDE_SUPPLIERADDR4_TITLE, typeof( string ) );
            // �d����d�b�ԍ�
            table.Columns.Add( GUIDE_SUPPLIERTELNO_TITLE, typeof( string ) );
            // �d����d�b�ԍ�1
            table.Columns.Add( GUIDE_SUPPLIERTELNO1_TITLE, typeof( string ) );
            // �d����d�b�ԍ�2
            table.Columns.Add( GUIDE_SUPPLIERTELNO2_TITLE, typeof( string ) );
            // �����敪
            table.Columns.Add( GUIDE_PURECODE_TITLE, typeof( Int32 ) );
            // �x�����敪�R�[�h
            table.Columns.Add( GUIDE_PAYMENTMONTHCODE_TITLE, typeof( Int32 ) );
            // �x�����敪����
            table.Columns.Add( GUIDE_PAYMENTMONTHNAME_TITLE, typeof( string ) );
            // �x����
            table.Columns.Add( GUIDE_PAYMENTDAY_TITLE, typeof( Int32 ) );
            // �d�������œ]�ŕ����Q�Ƌ敪
            table.Columns.Add( GUIDE_SUPPCTAXLAYREFCD_TITLE, typeof( Int32 ) );
            // �d�������œ]�ŕ����R�[�h
            table.Columns.Add( GUIDE_SUPPCTAXLAYCD_TITLE, typeof( Int32 ) );
            // �d����ېŕ����R�[�h
            table.Columns.Add( GUIDE_SUPPCTAXATIONCD_TITLE, typeof( Int32 ) );
            // �d�����ƃR�[�h
            table.Columns.Add( GUIDE_SUPPENTERPRISECD_TITLE, typeof( string ) );
            // �x����R�[�h
            table.Columns.Add( GUIDE_PAYEECODE_TITLE, typeof( Int32 ) );
            // �d���摮���敪
            table.Columns.Add( GUIDE_SUPPLIERATTRIBUTEDIV_TITLE, typeof( Int32 ) );
            // �d���摍�z�\�����@�敪
            table.Columns.Add( GUIDE_SUPPTTLAMNTDSPWAYCD_TITLE, typeof( Int32 ) );
            // �d�������z�\�����@�Q�Ƌ敪
            table.Columns.Add( GUIDE_STCKTTLAMNTDSPWAYREF_TITLE, typeof( Int32 ) );
            // �x������
            table.Columns.Add( GUIDE_PAYMENTCOND_TITLE, typeof( Int32 ) );
            // �x������
            table.Columns.Add( GUIDE_PAYMENTTOTALDAY_TITLE, typeof( Int32 ) );
            // �x���T�C�g
            table.Columns.Add( GUIDE_PAYMENTSIGHT_TITLE, typeof( Int32 ) );
            // �d���S���҃R�[�h
            table.Columns.Add( GUIDE_STOCKAGENTCODE_TITLE, typeof( string ) );
            // �d���P���[�������R�[�h
            table.Columns.Add( GUIDE_STOCKUNPRCFRCPROCCD_TITLE, typeof( Int32 ) );
            // �d�����z�[�������R�[�h
            table.Columns.Add( GUIDE_STOCKMONEYFRCPROCCD_TITLE, typeof( Int32 ) );
            // �d������Œ[�������R�[�h
            table.Columns.Add( GUIDE_STOCKCNSTAXFRCPROCCD_TITLE, typeof( Int32 ) );
            // �d����|���O���[�v�R�[�h
            table.Columns.Add( GUIDE_SUPPRATEGRPCODE_TITLE, typeof( Int32 ) );
            // ���񊨒�J�n��
            table.Columns.Add( GUIDE_NTIMECALCSTDATE_TITLE, typeof( Int32 ) );
            // �d������l1
            table.Columns.Add( GUIDE_SUPPLIERNOTE1_TITLE, typeof( string ) );
            // �d������l2
            table.Columns.Add( GUIDE_SUPPLIERNOTE2_TITLE, typeof( string ) );
            // �d������l3
            table.Columns.Add( GUIDE_SUPPLIERNOTE3_TITLE, typeof( string ) );
            // �d������l4
            table.Columns.Add( GUIDE_SUPPLIERNOTE4_TITLE, typeof( string ) );
            // �d���S���Җ���
            table.Columns.Add( GUIDE_STOCKAGENTNAME_TITLE, typeof( string ) );
            // �Ǘ����_����
            table.Columns.Add( GUIDE_MNGSECTIONNAME_TITLE, typeof( string ) );
            // ���͋��_����
            table.Columns.Add( GUIDE_INPSECTIONNAME_TITLE, typeof( string ) );
            // �x�����_����
            table.Columns.Add( GUIDE_PAYMENTSECTIONNAME_TITLE, typeof( string ) );
            // �Ǝ햼��
            table.Columns.Add( GUIDE_BUSINESSTYPENAME_TITLE, typeof( string ) );
            // �̔��G���A����
            table.Columns.Add( GUIDE_SALESAREANAME_TITLE, typeof( string ) );
            // �x���於��
            table.Columns.Add( GUIDE_PAYEENAME_TITLE, typeof( string ) );
            // �x���於�̂Q
            table.Columns.Add( GUIDE_PAYEENAME2_TITLE, typeof( string ) );
            // �x���旪��
            table.Columns.Add( GUIDE_PAYEESNM_TITLE, typeof( string ) );
            # endregion

            // �e�[�u���R�s�[
            guideList.Tables.Add( table.Clone() );
        }
        #endregion

        # region [�L���b�V������]
        /// <summary>
        /// �L���b�V���X�V����
        /// </summary>
        /// <param name="supplier"></param>
        /// <remarks>���z�[�������擾���܂߂�Read�̗��p�p�x���l�����A�L���b�V��������s���܂��B</remarks>
        private void UpdateCache( Supplier supplier )
        {
            // static�f�B�N�V���i����������ΐ���
            if ( _supplierDic == null )
            {
                _supplierDic = new Dictionary<int, Supplier>();
            }
            // �����Ȃ�΍폜
            if ( _supplierDic.ContainsKey( supplier.SupplierCd ) )
            {
                _supplierDic.Remove( supplier.SupplierCd );
            }
            // �ǉ�
            _supplierDic.Add( supplier.SupplierCd, supplier );
        }
        /// <summary>
        /// �L���b�V���擾����
        /// </summary>
        /// <param name="supplierCode"></param>
        /// <remarks>���z�[�������擾���܂߂�Read�̗��p�p�x���l�����A�L���b�V��������s���܂��B</remarks>
        private Supplier GetFromCache( int supplierCode )
        {
            if ( _supplierDic != null )
            {
                // �L���b�V������擾
                if ( _supplierDic.ContainsKey( supplierCode ) )
                {
                    return _supplierDic[supplierCode];
                }
            }

            return null;
        }
        /// <summary>
        /// �L���b�V���폜����
        /// </summary>
        /// <param name="supplierCode"></param>
        /// <remarks>���z�[�������擾���܂߂�Read�̗��p�p�x���l�����A�L���b�V��������s���܂��B</remarks>
        private void DeleteFromCache(int supplierCode)
        {
            if (_supplierDic != null)
            {
                // �L���b�V������폜
                if (_supplierDic.ContainsKey(supplierCode))
                {
                    _supplierDic.Remove(supplierCode);
                }
            }
        }
        
        // -- ADD 2010/04/06 ------------------------------>>>
        /// <summary>
        /// �L���b�V���S�폜����
        /// </summary>
        public void DeleteAllFromCache()
        {
            _supplierDic = new Dictionary<int,Supplier>();
        }
        // -- ADD 2010/04/06 ------------------------------<<<
        # endregion

        # region [���z�[�������擾]
        /// <summary>
        /// �d�����z�[�������敪�擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <param name="fracProcMoneyDiv">0:����P��,1:������z,2:��������</param>
        /// <returns>�[�������敪</returns>
        public int GetStockFractionProcCd( string enterpriseCode, int supplierCode, StockFracProcMoneyDiv fracProcMoneyDiv )
        {
            int fractionProcCd = 0;
            // -- ADD 2010/04/06 --------------------------->>>
            //�p�����[�^���s���̏ꍇ�͎擾�����͍s��Ȃ�
            if (string.IsNullOrEmpty(enterpriseCode) || supplierCode == 0)
            {
                return fractionProcCd;
            }
            // -- ADD 2010/04/06 ---------------------------<<<
            
            Supplier supplier;

            // -- ADD 2010/04/06 --------------------------->>>
            //int status = Read(out supplier, enterpriseCode, supplierCode);
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            supplier = GetFromCache(supplierCode);
            if (supplier == null)
            {
                status = Read(out supplier, enterpriseCode, supplierCode);
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            // -- ADD 2010/04/06 ---------------------------<<<

            if ( (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (supplier != null) && (supplier.SupplierCd != 0) )
            {
                switch ( fracProcMoneyDiv )
                {
                    case StockFracProcMoneyDiv.UnPrcFrcProcCd:
                        fractionProcCd = supplier.StockUnPrcFrcProcCd;
                        break;
                    case StockFracProcMoneyDiv.MoneyFrcProcCd:
                        fractionProcCd = supplier.StockMoneyFrcProcCd;
                        break;
                    case StockFracProcMoneyDiv.CnsTaxFrcProcCd:
                        fractionProcCd = supplier.StockCnsTaxFrcProcCd;
                        break;
                }
            }
            return fractionProcCd;
        }
        # endregion

        # region [���ʏ���]
        /// <summary>
        /// �����񁨐��l�@�ϊ�
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private int ToInt( string text )
        {
            try
            {
                return Convert.ToInt32( text );
            }
            catch
            {
                return 0;
            }
        }
        # endregion

        // ADD 2009/05/27 ------>>>
        # region [�e�d������Ɋ�Â��q�d������̍X�V]
        /// <summary>
        /// �e�d������Ɋ�Â��q�d������̍X�V
        /// </summary>
        /// <param name="child"></param>
        /// <param name="parent"></param>
        private void ReflectChildSupplierFromParent( ref SupplierWork child, SupplierWork parent )
        {
            child.PaymentTotalDay = parent.PaymentTotalDay;             // �x������
            child.PaymentMonthCode = parent.PaymentMonthCode;           // �x�����敪�R�[�h
            child.PaymentMonthName = parent.PaymentMonthName;           // �x�����敪����
            child.PaymentDay = parent.PaymentDay;                       // �x����
            child.PaymentCond = parent.PaymentCond;                     // �x������
            child.PaymentSight = parent.PaymentSight;                   // �x���T�C�g
            child.NTimeCalcStDate = parent.NTimeCalcStDate;             // ���񊨒�J�n��
            child.SuppCTaxLayRefCd = parent.SuppCTaxLayRefCd;           // �d�������œ]�ŕ����Q�Ƌ敪
            child.SuppCTaxLayCd = parent.SuppCTaxLayCd;                 // ����œ]�ŕ���
            child.StockUnPrcFrcProcCd = parent.StockUnPrcFrcProcCd;     // �d���P���[�������R�[�h
            child.StockMoneyFrcProcCd = parent.StockMoneyFrcProcCd;     // �d�����z�[�������R�[�h
            child.StockCnsTaxFrcProcCd = parent.StockCnsTaxFrcProcCd;   // �d������Œ[�������R�[�h
        }
        # endregion
        // ADD 2009/05/27 ------<<<
    }
}
