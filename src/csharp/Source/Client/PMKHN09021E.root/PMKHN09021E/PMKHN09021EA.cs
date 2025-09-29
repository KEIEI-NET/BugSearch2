using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   Supplier
    /// <summary>
    ///                      �d����}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d����}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/18</br>
    /// <br>Genarated Date   :   2008/04/23  (CSharp File Generated Date)</br>
    /// <br>------------------------------------------------------------------</br>
    /// <br>Update Note      :   2008/05/01 22018 ��ؐ��b</br>
    /// <br>                     �e��敪����(readonly string)��ǉ�</br>
    /// <br>Update Note      :   2008/06/19 22018 ��ؐ��b</br>
    /// <br>                     �e��敪���̎擾���\�b�h��ǉ�(static)</br>
    /// <br>Update Note      :   2009/01/29 30414 �E�K�j</br>
    /// <br>                     ��QID:10646�Ή�</br>
    /// </remarks>
    public class Supplier
    {
        # region [�i�蓮�ǉ��j]

        /// <summary>�h�́@�l</summary>
        public static readonly string CST_HonorificTitle_0 = "�l";
        /// <summary>�h�́@�a</summary>
        public static readonly string CST_HonorificTitle_1 = "�a";
        /// <summary>�h�́@�䒆</summary>
        public static readonly string CST_HonorificTitle_2 = "�䒆";

        /// <summary>�����敪�@����</summary>
        public static readonly string CST_PureCode_0 = "����";
        /// <summary>�����敪�@�D��</summary>
        public static readonly string CST_PureCode_1 = "�D��";

        /// <summary>�x�����敪�@����</summary>
        public static readonly string CST_PaymentMonthCode_0 = "����";
        /// <summary>�x�����敪�@����</summary>
        public static readonly string CST_PaymentMonthCode_1 = "����";
        /// <summary>�x�����敪�@���X��</summary>
        public static readonly string CST_PaymentMonthCode_2 = "���X��";
        /// <summary>�x�����敪�@���X�X</summary>
        // --- CHG 2009/01/28 ��QID:10646�Ή�------------------------------------------------------>>>>>
        //public static readonly string CST_PaymentMonthCode_3 = "���X�X";
        public static readonly string CST_PaymentMonthCode_3 = "���X�X��";
        // --- CHG 2009/01/28 ��QID:10646�Ή�------------------------------------------------------<<<<<

        // 2009.02.19 30413 ���� ���Ӑ�}�X�^�Ɠ��l�ɁA"�ŗ��ݒ�Q��"�ɏC�� >>>>>>START
        ///// <summary>����œ]�ŕ����Q�Ƌ敪�@�S�̐ݒ�Q��</summary>
        //public static readonly string CST_SuppCTaxLayRefCd_0 = "�S�̐ݒ�Q��";
        /// <summary>����œ]�ŕ����Q�Ƌ敪�@�ŗ��ݒ�Q��</summary>
        public static readonly string CST_SuppCTaxLayRefCd_0 = "�ŗ��ݒ�Q��";
        // 2009.02.19 30413 ���� ���Ӑ�}�X�^�Ɠ��l�ɁA"�ŗ��ݒ�Q��"�ɏC�� <<<<<<END
        /// <summary>����œ]�ŕ����Q�Ƌ敪�@�d����Q��</summary>
        public static readonly string CST_SuppCTaxLayRefCd_1 = "�d����Q��";

        /// <summary>����œ]�ŕ����敪�@�`�[�P��</summary>
        public static readonly string CST_SuppCTaxLayCd_0 = "�`�[�P��";
        /// <summary>����œ]�ŕ����敪�@���גP��</summary>
        public static readonly string CST_SuppCTaxLayCd_1 = "���גP��";
        /// <summary>����œ]�ŕ����敪�@�����P�ʁi������j</summary>
        public static readonly string CST_SuppCTaxLayCd_2 = "�����e";
        /// <summary>����œ]�ŕ����敪�@�����P�ʁi���Ӑ�j</summary>
        public static readonly string CST_SuppCTaxLayCd_3 = "�����q";
        /// <summary>����œ]�ŕ����敪�@��ې�</summary>
        public static readonly string CST_SuppCTaxLayCd_9 = "��ې�";

        /// <summary>�ېŕ����敪�@�ې�</summary>
        public static readonly string CST_SuppCTaxationCd_0 = "�ې�";
        /// <summary>�ېŕ����敪�@��ې�</summary>
        public static readonly string CST_SuppCTaxationCd_1 = "��ې�";

        /// <summary>�d���摮���敪�@���������</summary>
        public static readonly string CST_SupplierAttributeDiv_0 = "���������";
        /// <summary>�d���摮���敪�@�Г������</summary>
        public static readonly string CST_SupplierAttributeDiv_8 = "�Г������";
        /// <summary>�d���摮���敪�@��������</summary>
        public static readonly string CST_SupplierAttributeDiv_9 = "��������";

        /// <summary>���z�\���敪�@���Ȃ��i�Ŕ��j</summary>
        public static readonly string CST_SuppTtlAmntDspWayCd_0 = "���Ȃ��i�Ŕ��j";
        /// <summary>���z�\���敪�@����i�ō��j</summary>
        public static readonly string CST_SuppTtlAmntDspWayCd_1 = "����i�ō��j";

        /// <summary>���z�\���Q�Ƌ敪�@�S�̐ݒ�Q��</summary>
        public static readonly string CST_StckTtlAmntDspWayRef_0 = "�S�̐ݒ�Q��";
        /// <summary>���z�\���Q�Ƌ敪�@�d����Q��</summary>
        public static readonly string CST_StckTtlAmntDspWayRef_1 = "�d����Q��";

        /// <summary>�x�������@����</summary>
        public static readonly string CST_PaymentCond_10 = "����";
        /// <summary>�x�������@�U��</summary>
        public static readonly string CST_PaymentCond_20 = "�U��";
        /// <summary>�x�������@���؎�</summary>
        public static readonly string CST_PaymentCond_30 = "���؎�";
        /// <summary>�x�������@��`</summary>
        public static readonly string CST_PaymentCond_40 = "��`";
        /// <summary>�x�������@�萔��</summary>
        public static readonly string CST_PaymentCond_50 = "�萔��";
        /// <summary>�x�������@���E</summary>
        public static readonly string CST_PaymentCond_60 = "���E";
        /// <summary>�x�������@�l��</summary>
        public static readonly string CST_PaymentCond_70 = "�l��";
        /// <summary>�x�������@���̑�</summary>
        public static readonly string CST_PaymentCond_80 = "���̑�";

        # endregion

        # region [�i���������j]
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�Ǘ����_�R�[�h</summary>
        private string _mngSectionCode = "";

        /// <summary>���͋��_�R�[�h</summary>
        private string _inpSectionCode = "";

        /// <summary>�x�����_�R�[�h</summary>
        /// <remarks>�������s�����_</remarks>
        private string _paymentSectionCode = "";

        /// <summary>�d���於1</summary>
        private string _supplierNm1 = "";

        /// <summary>�d���於2</summary>
        private string _supplierNm2 = "";

        /// <summary>�d����h��</summary>
        private string _suppHonorificTitle = "";

        /// <summary>�d����J�i</summary>
        private string _supplierKana = "";

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>�������h��</summary>
        private string _orderHonorificTtl = "";

        /// <summary>�Ǝ�R�[�h</summary>
        private Int32 _businessTypeCode;

        /// <summary>�̔��G���A�R�[�h</summary>
        private Int32 _salesAreaCode;

        /// <summary>�d����X�֔ԍ�</summary>
        private string _supplierPostNo = "";

        /// <summary>�d����Z��1�i�s���{���s��S�E�����E���j</summary>
        private string _supplierAddr1 = "";

        /// <summary>�d����Z��3�i�Ԓn�j</summary>
        private string _supplierAddr3 = "";

        /// <summary>�d����Z��4�i�A�p�[�g���́j</summary>
        private string _supplierAddr4 = "";

        /// <summary>�d����d�b�ԍ�</summary>
        private string _supplierTelNo = "";

        /// <summary>�d����d�b�ԍ�1</summary>
        private string _supplierTelNo1 = "";

        /// <summary>�d����d�b�ԍ�2</summary>
        /// <remarks>FAX�Ŏg�p</remarks>
        private string _supplierTelNo2 = "";

        /// <summary>�����敪</summary>
        /// <remarks>0:�����A1:�D��</remarks>
        private Int32 _pureCode;

        /// <summary>�x�����敪�R�[�h</summary>
        /// <remarks>0:���� 1:���� 2:���X��</remarks>
        private Int32 _paymentMonthCode;

        /// <summary>�x�����敪����</summary>
        /// <remarks>�����A�����A���X��</remarks>
        private string _paymentMonthName = "";

        /// <summary>�x����</summary>
        /// <remarks>DD</remarks>
        private Int32 _paymentDay;

        /// <summary>�d�������œ]�ŕ����Q�Ƌ敪</summary>
        /// <remarks>0:�d���݌ɑS�̐ݒ�}�X�^�Q�Ɓ@1:���Ӑ�d�����}�X�^�Q��</remarks>
        private Int32 _suppCTaxLayRefCd;

        /// <summary>�d�������œ]�ŕ����R�[�h</summary>
        /// <remarks>0:�`�[�P�� 1:���גP�� 2:�����P�ʁi������j3:�����P�ʁi���Ӑ�j9:��ې�</remarks>
        private Int32 _suppCTaxLayCd;

        /// <summary>�d����ېŕ����R�[�h</summary>
        /// <remarks>0:�ې� 1:��ې�</remarks>
        private Int32 _suppCTaxationCd;

        /// <summary>�d�����ƃR�[�h</summary>
        private string _suppEnterpriseCd = "";

        /// <summary>�x����R�[�h</summary>
        private Int32 _payeeCode;

        /// <summary>�d���摮���敪</summary>
        /// <remarks>0:���������,8:�Г������,9:��������</remarks>
        private Int32 _supplierAttributeDiv;

        /// <summary>�d���摍�z�\�����@�敪</summary>
        /// <remarks>�O���z�\�����Ȃ��i�Ŕ����j 1:���z�\������i�ō��݁j</remarks>
        private Int32 _suppTtlAmntDspWayCd;

        /// <summary>�d�������z�\�����@�Q�Ƌ敪</summary>
        /// <remarks>0:�S�̐ݒ�Q�� 1:�d����Q��</remarks>
        private Int32 _stckTtlAmntDspWayRef;

        /// <summary>�x������</summary>
        /// <remarks>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</remarks>
        private Int32 _paymentCond;

        /// <summary>�x������</summary>
        private Int32 _paymentTotalDay;

        /// <summary>�x���T�C�g</summary>
        /// <remarks>��`�T�C�g�@180��</remarks>
        private Int32 _paymentSight;

        /// <summary>�d���S���҃R�[�h</summary>
        private string _stockAgentCode = "";

        /// <summary>�d���P���[�������R�[�h</summary>
        private Int32 _stockUnPrcFrcProcCd;

        /// <summary>�d�����z�[�������R�[�h</summary>
        private Int32 _stockMoneyFrcProcCd;

        /// <summary>�d������Œ[�������R�[�h</summary>
        private Int32 _stockCnsTaxFrcProcCd;

        /// <summary>���񊨒�J�n��</summary>
        /// <remarks>01�`31�܂Łi�ȗ��\�j</remarks>
        private Int32 _nTimeCalcStDate;

        /// <summary>�d������l1</summary>
        private string _supplierNote1 = "";

        /// <summary>�d������l2</summary>
        private string _supplierNote2 = "";

        /// <summary>�d������l3</summary>
        private string _supplierNote3 = "";

        /// <summary>�d������l4</summary>
        private string _supplierNote4 = "";

        /// <summary>�d���S���Җ���</summary>
        /// <remarks>�]�ƈ��}�X�^</remarks>
        private string _stockAgentName = "";

        /// <summary>�Ǘ����_����</summary>
        /// <remarks>���_�}�X�^</remarks>
        private string _mngSectionName = "";

        /// <summary>���͋��_����</summary>
        /// <remarks>���_�}�X�^</remarks>
        private string _inpSectionName = "";

        /// <summary>�x�����_����</summary>
        /// <remarks>���_�}�X�^</remarks>
        private string _paymentSectionName = "";

        /// <summary>�Ǝ햼��</summary>
        /// <remarks>���[�U�[�K�C�h�i33�j</remarks>
        private string _businessTypeName = "";

        /// <summary>�̔��G���A����</summary>
        /// <remarks>���[�U�[�K�C�h�i21�j</remarks>
        private string _salesAreaName = "";

        /// <summary>�x���於��</summary>
        /// <remarks>���Ȍ���</remarks>
        private string _payeeName = "";

        /// <summary>�x���於�̂Q</summary>
        /// <remarks>���Ȍ���</remarks>
        private string _payeeName2 = "";

        /// <summary>�x���旪��</summary>
        /// <remarks>���Ȍ���</remarks>
        private string _payeeSnm = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>�d�������œ]�ŕ�������</summary>
        /// <remarks>�`�[�P�ʁA���גP�ʁA�����P��</remarks>
        private string _suppCTaxLayMethodNm = "";


        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  CreateDateTimeJpFormal
        /// <summary>�쐬���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _createDateTime ); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeJpInFormal
        /// <summary>�쐬���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _createDateTime ); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdFormal
        /// <summary>�쐬���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _createDateTime ); }
            set { }
        }

        /// public propaty name  :  CreateDateTimeAdInFormal
        /// <summary>�쐬���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CreateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _createDateTime ); }
            set { }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTimeJpFormal
        /// <summary>�X�V���� �a��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpFormal
        {
            get { return TDateTime.DateTimeToString( "GGYYMMDD", _updateDateTime ); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeJpInFormal
        /// <summary>�X�V���� �a��(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeJpInFormal
        {
            get { return TDateTime.DateTimeToString( "ggYY/MM/DD", _updateDateTime ); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdFormal
        /// <summary>�X�V���� ����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdFormal
        {
            get { return TDateTime.DateTimeToString( "YYYY/MM/DD", _updateDateTime ); }
            set { }
        }

        /// public propaty name  :  UpdateDateTimeAdInFormal
        /// <summary>�X�V���� ����(��)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdateDateTimeAdInFormal
        {
            get { return TDateTime.DateTimeToString( "YY/MM/DD", _updateDateTime ); }
            set { }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  MngSectionCode
        /// <summary>�Ǘ����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }

        /// public propaty name  :  InpSectionCode
        /// <summary>���͋��_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͋��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InpSectionCode
        {
            get { return _inpSectionCode; }
            set { _inpSectionCode = value; }
        }

        /// public propaty name  :  PaymentSectionCode
        /// <summary>�x�����_�R�[�h�v���p�e�B</summary>
        /// <value>�������s�����_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentSectionCode
        {
            get { return _paymentSectionCode; }
            set { _paymentSectionCode = value; }
        }

        /// public propaty name  :  SupplierNm1
        /// <summary>�d���於1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm1
        {
            get { return _supplierNm1; }
            set { _supplierNm1 = value; }
        }

        /// public propaty name  :  SupplierNm2
        /// <summary>�d���於2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���於2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNm2
        {
            get { return _supplierNm2; }
            set { _supplierNm2 = value; }
        }

        /// public propaty name  :  SuppHonorificTitle
        /// <summary>�d����h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SuppHonorificTitle
        {
            get { return _suppHonorificTitle; }
            set { _suppHonorificTitle = value; }
        }

        /// public propaty name  :  SupplierKana
        /// <summary>�d����J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierKana
        {
            get { return _supplierKana; }
            set { _supplierKana = value; }
        }

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  OrderHonorificTtl
        /// <summary>�������h�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������h�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string OrderHonorificTtl
        {
            get { return _orderHonorificTtl; }
            set { _orderHonorificTtl = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>�Ǝ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>�̔��G���A�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SupplierPostNo
        /// <summary>�d����X�֔ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����X�֔ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierPostNo
        {
            get { return _supplierPostNo; }
            set { _supplierPostNo = value; }
        }

        /// public propaty name  :  SupplierAddr1
        /// <summary>�d����Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����Z��1�i�s���{���s��S�E�����E���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierAddr1
        {
            get { return _supplierAddr1; }
            set { _supplierAddr1 = value; }
        }

        /// public propaty name  :  SupplierAddr3
        /// <summary>�d����Z��3�i�Ԓn�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����Z��3�i�Ԓn�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierAddr3
        {
            get { return _supplierAddr3; }
            set { _supplierAddr3 = value; }
        }

        /// public propaty name  :  SupplierAddr4
        /// <summary>�d����Z��4�i�A�p�[�g���́j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����Z��4�i�A�p�[�g���́j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierAddr4
        {
            get { return _supplierAddr4; }
            set { _supplierAddr4 = value; }
        }

        /// public propaty name  :  SupplierTelNo
        /// <summary>�d����d�b�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����d�b�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierTelNo
        {
            get { return _supplierTelNo; }
            set { _supplierTelNo = value; }
        }

        /// public propaty name  :  SupplierTelNo1
        /// <summary>�d����d�b�ԍ�1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����d�b�ԍ�1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierTelNo1
        {
            get { return _supplierTelNo1; }
            set { _supplierTelNo1 = value; }
        }

        /// public propaty name  :  SupplierTelNo2
        /// <summary>�d����d�b�ԍ�2�v���p�e�B</summary>
        /// <value>FAX�Ŏg�p</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����d�b�ԍ�2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierTelNo2
        {
            get { return _supplierTelNo2; }
            set { _supplierTelNo2 = value; }
        }

        /// public propaty name  :  PureCode
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:�����A1:�D��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PureCode
        {
            get { return _pureCode; }
            set { _pureCode = value; }
        }

        /// public propaty name  :  PaymentMonthCode
        /// <summary>�x�����敪�R�[�h�v���p�e�B</summary>
        /// <value>0:���� 1:���� 2:���X��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentMonthCode
        {
            get { return _paymentMonthCode; }
            set { _paymentMonthCode = value; }
        }

        /// public propaty name  :  PaymentMonthName
        /// <summary>�x�����敪���̃v���p�e�B</summary>
        /// <value>�����A�����A���X��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentMonthName
        {
            get { return _paymentMonthName; }
            set { _paymentMonthName = value; }
        }

        /// public propaty name  :  PaymentDay
        /// <summary>�x�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentDay
        {
            get { return _paymentDay; }
            set { _paymentDay = value; }
        }

        /// public propaty name  :  SuppCTaxLayRefCd
        /// <summary>�d�������œ]�ŕ����Q�Ƌ敪�v���p�e�B</summary>
        /// <value>0:�d���݌ɑS�̐ݒ�}�X�^�Q�Ɓ@1:���Ӑ�d�����}�X�^�Q��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������œ]�ŕ����Q�Ƌ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppCTaxLayRefCd
        {
            get { return _suppCTaxLayRefCd; }
            set { _suppCTaxLayRefCd = value; }
        }

        /// public propaty name  :  SuppCTaxLayCd
        /// <summary>�d�������œ]�ŕ����R�[�h�v���p�e�B</summary>
        /// <value>0:�`�[�P�� 1:���גP�� 2:�����P�ʁi������j3:�����P�ʁi���Ӑ�j9:��ې�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������œ]�ŕ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppCTaxLayCd
        {
            get { return _suppCTaxLayCd; }
            set { _suppCTaxLayCd = value; }
        }

        /// public propaty name  :  SuppCTaxationCd
        /// <summary>�d����ېŕ����R�[�h�v���p�e�B</summary>
        /// <value>0:�ې� 1:��ې�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����ېŕ����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppCTaxationCd
        {
            get { return _suppCTaxationCd; }
            set { _suppCTaxationCd = value; }
        }

        /// public propaty name  :  SuppEnterpriseCd
        /// <summary>�d�����ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SuppEnterpriseCd
        {
            get { return _suppEnterpriseCd; }
            set { _suppEnterpriseCd = value; }
        }

        /// public propaty name  :  PayeeCode
        /// <summary>�x����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PayeeCode
        {
            get { return _payeeCode; }
            set { _payeeCode = value; }
        }

        /// public propaty name  :  SupplierAttributeDiv
        /// <summary>�d���摮���敪�v���p�e�B</summary>
        /// <value>0:���������,8:�Г������,9:��������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���摮���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierAttributeDiv
        {
            get { return _supplierAttributeDiv; }
            set { _supplierAttributeDiv = value; }
        }

        /// public propaty name  :  SuppTtlAmntDspWayCd
        /// <summary>�d���摍�z�\�����@�敪�v���p�e�B</summary>
        /// <value>�O���z�\�����Ȃ��i�Ŕ����j 1:���z�\������i�ō��݁j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���摍�z�\�����@�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SuppTtlAmntDspWayCd
        {
            get { return _suppTtlAmntDspWayCd; }
            set { _suppTtlAmntDspWayCd = value; }
        }

        /// public propaty name  :  StckTtlAmntDspWayRef
        /// <summary>�d�������z�\�����@�Q�Ƌ敪�v���p�e�B</summary>
        /// <value>0:�S�̐ݒ�Q�� 1:�d����Q��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������z�\�����@�Q�Ƌ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StckTtlAmntDspWayRef
        {
            get { return _stckTtlAmntDspWayRef; }
            set { _stckTtlAmntDspWayRef = value; }
        }

        /// public propaty name  :  PaymentCond
        /// <summary>�x�������v���p�e�B</summary>
        /// <value>10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentCond
        {
            get { return _paymentCond; }
            set { _paymentCond = value; }
        }

        /// public propaty name  :  PaymentTotalDay
        /// <summary>�x�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentTotalDay
        {
            get { return _paymentTotalDay; }
            set { _paymentTotalDay = value; }
        }

        /// public propaty name  :  PaymentSight
        /// <summary>�x���T�C�g�v���p�e�B</summary>
        /// <value>��`�T�C�g�@180��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���T�C�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PaymentSight
        {
            get { return _paymentSight; }
            set { _paymentSight = value; }
        }

        /// public propaty name  :  StockAgentCode
        /// <summary>�d���S���҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���҃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentCode
        {
            get { return _stockAgentCode; }
            set { _stockAgentCode = value; }
        }

        /// public propaty name  :  StockUnPrcFrcProcCd
        /// <summary>�d���P���[�������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockUnPrcFrcProcCd
        {
            get { return _stockUnPrcFrcProcCd; }
            set { _stockUnPrcFrcProcCd = value; }
        }

        /// public propaty name  :  StockMoneyFrcProcCd
        /// <summary>�d�����z�[�������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockMoneyFrcProcCd
        {
            get { return _stockMoneyFrcProcCd; }
            set { _stockMoneyFrcProcCd = value; }
        }

        /// public propaty name  :  StockCnsTaxFrcProcCd
        /// <summary>�d������Œ[�������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������Œ[�������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockCnsTaxFrcProcCd
        {
            get { return _stockCnsTaxFrcProcCd; }
            set { _stockCnsTaxFrcProcCd = value; }
        }

        /// public propaty name  :  NTimeCalcStDate
        /// <summary>���񊨒�J�n���v���p�e�B</summary>
        /// <value>01�`31�܂Łi�ȗ��\�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���񊨒�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NTimeCalcStDate
        {
            get { return _nTimeCalcStDate; }
            set { _nTimeCalcStDate = value; }
        }

        /// public propaty name  :  SupplierNote1
        /// <summary>�d������l1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������l1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNote1
        {
            get { return _supplierNote1; }
            set { _supplierNote1 = value; }
        }

        /// public propaty name  :  SupplierNote2
        /// <summary>�d������l2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������l2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNote2
        {
            get { return _supplierNote2; }
            set { _supplierNote2 = value; }
        }

        /// public propaty name  :  SupplierNote3
        /// <summary>�d������l3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������l3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNote3
        {
            get { return _supplierNote3; }
            set { _supplierNote3 = value; }
        }

        /// public propaty name  :  SupplierNote4
        /// <summary>�d������l4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d������l4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierNote4
        {
            get { return _supplierNote4; }
            set { _supplierNote4 = value; }
        }

        /// public propaty name  :  StockAgentName
        /// <summary>�d���S���Җ��̃v���p�e�B</summary>
        /// <value>�]�ƈ��}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���S���Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockAgentName
        {
            get { return _stockAgentName; }
            set { _stockAgentName = value; }
        }

        /// public propaty name  :  MngSectionName
        /// <summary>�Ǘ����_���̃v���p�e�B</summary>
        /// <value>���_�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MngSectionName
        {
            get { return _mngSectionName; }
            set { _mngSectionName = value; }
        }

        /// public propaty name  :  InpSectionName
        /// <summary>���͋��_���̃v���p�e�B</summary>
        /// <value>���_�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͋��_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InpSectionName
        {
            get { return _inpSectionName; }
            set { _inpSectionName = value; }
        }

        /// public propaty name  :  PaymentSectionName
        /// <summary>�x�����_���̃v���p�e�B</summary>
        /// <value>���_�}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x�����_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PaymentSectionName
        {
            get { return _paymentSectionName; }
            set { _paymentSectionName = value; }
        }

        /// public propaty name  :  BusinessTypeName
        /// <summary>�Ǝ햼�̃v���p�e�B</summary>
        /// <value>���[�U�[�K�C�h�i33�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǝ햼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }

        /// public propaty name  :  SalesAreaName
        /// <summary>�̔��G���A���̃v���p�e�B</summary>
        /// <value>���[�U�[�K�C�h�i21�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��G���A���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  PayeeName
        /// <summary>�x���於�̃v���p�e�B</summary>
        /// <value>���Ȍ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeName
        {
            get { return _payeeName; }
            set { _payeeName = value; }
        }

        /// public propaty name  :  PayeeName2
        /// <summary>�x���於�̂Q�v���p�e�B</summary>
        /// <value>���Ȍ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���於�̂Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeName2
        {
            get { return _payeeName2; }
            set { _payeeName2 = value; }
        }

        /// public propaty name  :  PayeeSnm
        /// <summary>�x���旪�̃v���p�e�B</summary>
        /// <value>���Ȍ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PayeeSnm
        {
            get { return _payeeSnm; }
            set { _payeeSnm = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  UpdEmployeeName
        /// <summary>�X�V�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        /// public propaty name  :  SuppCTaxLayMethodNm
        /// <summary>�d�������œ]�ŕ������̃v���p�e�B</summary>
        /// <value>�`�[�P�ʁA���גP�ʁA�����P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������œ]�ŕ������̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SuppCTaxLayMethodNm
        {
            get { return _suppCTaxLayMethodNm; }
            set { _suppCTaxLayMethodNm = value; }
        }


		/// <summary>
		/// �d����}�X�^�R���X�g���N�^
		/// </summary>
		/// <returns>Supplier�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Supplier�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Supplier()
		{
		}
		/// <summary>
		/// �d����}�X�^�R���X�g���N�^
		/// </summary>
		/// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
		/// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
		/// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
		/// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
		/// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
		/// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
		/// <param name="supplierCd">�d����R�[�h</param>
		/// <param name="mngSectionCode">�Ǘ����_�R�[�h</param>
		/// <param name="inpSectionCode">���͋��_�R�[�h</param>
		/// <param name="paymentSectionCode">�x�����_�R�[�h(�������s�����_)</param>
		/// <param name="supplierNm1">�d���於1</param>
		/// <param name="supplierNm2">�d���於2</param>
		/// <param name="suppHonorificTitle">�d����h��</param>
		/// <param name="supplierKana">�d����J�i</param>
		/// <param name="supplierSnm">�d���旪��</param>
		/// <param name="orderHonorificTtl">�������h��</param>
		/// <param name="businessTypeCode">�Ǝ�R�[�h</param>
		/// <param name="salesAreaCode">�̔��G���A�R�[�h</param>
		/// <param name="supplierPostNo">�d����X�֔ԍ�</param>
		/// <param name="supplierAddr1">�d����Z��1�i�s���{���s��S�E�����E���j</param>
		/// <param name="supplierAddr3">�d����Z��3�i�Ԓn�j</param>
		/// <param name="supplierAddr4">�d����Z��4�i�A�p�[�g���́j</param>
		/// <param name="supplierTelNo">�d����d�b�ԍ�</param>
		/// <param name="supplierTelNo1">�d����d�b�ԍ�1</param>
		/// <param name="supplierTelNo2">�d����d�b�ԍ�2(FAX�Ŏg�p)</param>
		/// <param name="pureCode">�����敪(0:�����A1:�D��)</param>
		/// <param name="paymentMonthCode">�x�����敪�R�[�h(0:���� 1:���� 2:���X��)</param>
		/// <param name="paymentMonthName">�x�����敪����(�����A�����A���X��)</param>
		/// <param name="paymentDay">�x����(DD)</param>
		/// <param name="suppCTaxLayRefCd">�d�������œ]�ŕ����Q�Ƌ敪(0:�d���݌ɑS�̐ݒ�}�X�^�Q�Ɓ@1:���Ӑ�d�����}�X�^�Q��)</param>
		/// <param name="suppCTaxLayCd">�d�������œ]�ŕ����R�[�h(0:�`�[�P�� 1:���גP�� 2:�����P�ʁi������j3:�����P�ʁi���Ӑ�j9:��ې�)</param>
		/// <param name="suppCTaxationCd">�d����ېŕ����R�[�h(0:�ې� 1:��ې�)</param>
		/// <param name="suppEnterpriseCd">�d�����ƃR�[�h</param>
		/// <param name="payeeCode">�x����R�[�h</param>
		/// <param name="supplierAttributeDiv">�d���摮���敪(0:���������,8:�Г������,9:��������)</param>
		/// <param name="suppTtlAmntDspWayCd">�d���摍�z�\�����@�敪(�O���z�\�����Ȃ��i�Ŕ����j 1:���z�\������i�ō��݁j)</param>
		/// <param name="stckTtlAmntDspWayRef">�d�������z�\�����@�Q�Ƌ敪(0:�S�̐ݒ�Q�� 1:�d����Q��)</param>
		/// <param name="paymentCond">�x������(10:����,20:�U��,30:���؎�,40:��`,50:�萔��,60:���E,70:�l��,80:���̑�)</param>
		/// <param name="paymentTotalDay">�x������</param>
		/// <param name="paymentSight">�x���T�C�g(��`�T�C�g�@180��)</param>
		/// <param name="stockAgentCode">�d���S���҃R�[�h</param>
		/// <param name="stockUnPrcFrcProcCd">�d���P���[�������R�[�h</param>
		/// <param name="stockMoneyFrcProcCd">�d�����z�[�������R�[�h</param>
		/// <param name="stockCnsTaxFrcProcCd">�d������Œ[�������R�[�h</param>
		/// <param name="nTimeCalcStDate">���񊨒�J�n��(01�`31�܂Łi�ȗ��\�j)</param>
		/// <param name="supplierNote1">�d������l1</param>
		/// <param name="supplierNote2">�d������l2</param>
		/// <param name="supplierNote3">�d������l3</param>
		/// <param name="supplierNote4">�d������l4</param>
		/// <param name="stockAgentName">�d���S���Җ���(�]�ƈ��}�X�^)</param>
		/// <param name="mngSectionName">�Ǘ����_����(���_�}�X�^)</param>
		/// <param name="inpSectionName">���͋��_����(���_�}�X�^)</param>
		/// <param name="paymentSectionName">�x�����_����(���_�}�X�^)</param>
		/// <param name="businessTypeName">�Ǝ햼��(���[�U�[�K�C�h�i33�j)</param>
		/// <param name="salesAreaName">�̔��G���A����(���[�U�[�K�C�h�i21�j)</param>
		/// <param name="payeeName">�x���於��(���Ȍ���)</param>
		/// <param name="payeeName2">�x���於�̂Q(���Ȍ���)</param>
		/// <param name="payeeSnm">�x���旪��(���Ȍ���)</param>
		/// <param name="enterpriseName">��Ɩ���</param>
		/// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
		/// <param name="suppCTaxLayMethodNm">�d�������œ]�ŕ�������(�`�[�P�ʁA���גP�ʁA�����P��)</param>
		/// <returns>Supplier�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Supplier�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Supplier(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 supplierCd,string mngSectionCode,string inpSectionCode,string paymentSectionCode,string supplierNm1,string supplierNm2,string suppHonorificTitle,string supplierKana,string supplierSnm,string orderHonorificTtl,Int32 businessTypeCode,Int32 salesAreaCode,string supplierPostNo,string supplierAddr1,string supplierAddr3,string supplierAddr4,string supplierTelNo,string supplierTelNo1,string supplierTelNo2,Int32 pureCode,Int32 paymentMonthCode,string paymentMonthName,Int32 paymentDay,Int32 suppCTaxLayRefCd,Int32 suppCTaxLayCd,Int32 suppCTaxationCd,string suppEnterpriseCd,Int32 payeeCode,Int32 supplierAttributeDiv,Int32 suppTtlAmntDspWayCd,Int32 stckTtlAmntDspWayRef,Int32 paymentCond,Int32 paymentTotalDay,Int32 paymentSight,string stockAgentCode,Int32 stockUnPrcFrcProcCd,Int32 stockMoneyFrcProcCd,Int32 stockCnsTaxFrcProcCd,Int32 nTimeCalcStDate,string supplierNote1,string supplierNote2,string supplierNote3,string supplierNote4,string stockAgentName,string mngSectionName,string inpSectionName,string paymentSectionName,string businessTypeName,string salesAreaName,string payeeName,string payeeName2,string payeeSnm,string enterpriseName,string updEmployeeName,string suppCTaxLayMethodNm)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._supplierCd = supplierCd;
			this._mngSectionCode = mngSectionCode;
			this._inpSectionCode = inpSectionCode;
			this._paymentSectionCode = paymentSectionCode;
			this._supplierNm1 = supplierNm1;
			this._supplierNm2 = supplierNm2;
			this._suppHonorificTitle = suppHonorificTitle;
			this._supplierKana = supplierKana;
			this._supplierSnm = supplierSnm;
			this._orderHonorificTtl = orderHonorificTtl;
			this._businessTypeCode = businessTypeCode;
			this._salesAreaCode = salesAreaCode;
			this._supplierPostNo = supplierPostNo;
			this._supplierAddr1 = supplierAddr1;
			this._supplierAddr3 = supplierAddr3;
			this._supplierAddr4 = supplierAddr4;
			this._supplierTelNo = supplierTelNo;
			this._supplierTelNo1 = supplierTelNo1;
			this._supplierTelNo2 = supplierTelNo2;
			this._pureCode = pureCode;
			this._paymentMonthCode = paymentMonthCode;
			this._paymentMonthName = paymentMonthName;
			this._paymentDay = paymentDay;
			this._suppCTaxLayRefCd = suppCTaxLayRefCd;
			this._suppCTaxLayCd = suppCTaxLayCd;
			this._suppCTaxationCd = suppCTaxationCd;
			this._suppEnterpriseCd = suppEnterpriseCd;
			this._payeeCode = payeeCode;
			this._supplierAttributeDiv = supplierAttributeDiv;
			this._suppTtlAmntDspWayCd = suppTtlAmntDspWayCd;
			this._stckTtlAmntDspWayRef = stckTtlAmntDspWayRef;
			this._paymentCond = paymentCond;
			this._paymentTotalDay = paymentTotalDay;
			this._paymentSight = paymentSight;
			this._stockAgentCode = stockAgentCode;
			this._stockUnPrcFrcProcCd = stockUnPrcFrcProcCd;
			this._stockMoneyFrcProcCd = stockMoneyFrcProcCd;
			this._stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;
			this._nTimeCalcStDate = nTimeCalcStDate;
			this._supplierNote1 = supplierNote1;
			this._supplierNote2 = supplierNote2;
			this._supplierNote3 = supplierNote3;
			this._supplierNote4 = supplierNote4;
			this._stockAgentName = stockAgentName;
			this._mngSectionName = mngSectionName;
			this._inpSectionName = inpSectionName;
			this._paymentSectionName = paymentSectionName;
			this._businessTypeName = businessTypeName;
			this._salesAreaName = salesAreaName;
			this._payeeName = payeeName;
			this._payeeName2 = payeeName2;
			this._payeeSnm = payeeSnm;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._suppCTaxLayMethodNm = suppCTaxLayMethodNm;

		}

		/// <summary>
		/// �d����}�X�^��������
		/// </summary>
		/// <returns>Supplier�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����Supplier�N���X�̃C���X�^���X��Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public Supplier Clone()
		{
			return new Supplier(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._supplierCd,this._mngSectionCode,this._inpSectionCode,this._paymentSectionCode,this._supplierNm1,this._supplierNm2,this._suppHonorificTitle,this._supplierKana,this._supplierSnm,this._orderHonorificTtl,this._businessTypeCode,this._salesAreaCode,this._supplierPostNo,this._supplierAddr1,this._supplierAddr3,this._supplierAddr4,this._supplierTelNo,this._supplierTelNo1,this._supplierTelNo2,this._pureCode,this._paymentMonthCode,this._paymentMonthName,this._paymentDay,this._suppCTaxLayRefCd,this._suppCTaxLayCd,this._suppCTaxationCd,this._suppEnterpriseCd,this._payeeCode,this._supplierAttributeDiv,this._suppTtlAmntDspWayCd,this._stckTtlAmntDspWayRef,this._paymentCond,this._paymentTotalDay,this._paymentSight,this._stockAgentCode,this._stockUnPrcFrcProcCd,this._stockMoneyFrcProcCd,this._stockCnsTaxFrcProcCd,this._nTimeCalcStDate,this._supplierNote1,this._supplierNote2,this._supplierNote3,this._supplierNote4,this._stockAgentName,this._mngSectionName,this._inpSectionName,this._paymentSectionName,this._businessTypeName,this._salesAreaName,this._payeeName,this._payeeName2,this._payeeSnm,this._enterpriseName,this._updEmployeeName,this._suppCTaxLayMethodNm);
		}

		/// <summary>
		/// �d����}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�Supplier�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Supplier�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public bool Equals(Supplier target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.MngSectionCode == target.MngSectionCode)
				 && (this.InpSectionCode == target.InpSectionCode)
				 && (this.PaymentSectionCode == target.PaymentSectionCode)
				 && (this.SupplierNm1 == target.SupplierNm1)
				 && (this.SupplierNm2 == target.SupplierNm2)
				 && (this.SuppHonorificTitle == target.SuppHonorificTitle)
				 && (this.SupplierKana == target.SupplierKana)
				 && (this.SupplierSnm == target.SupplierSnm)
				 && (this.OrderHonorificTtl == target.OrderHonorificTtl)
				 && (this.BusinessTypeCode == target.BusinessTypeCode)
				 && (this.SalesAreaCode == target.SalesAreaCode)
				 && (this.SupplierPostNo == target.SupplierPostNo)
				 && (this.SupplierAddr1 == target.SupplierAddr1)
				 && (this.SupplierAddr3 == target.SupplierAddr3)
				 && (this.SupplierAddr4 == target.SupplierAddr4)
				 && (this.SupplierTelNo == target.SupplierTelNo)
				 && (this.SupplierTelNo1 == target.SupplierTelNo1)
				 && (this.SupplierTelNo2 == target.SupplierTelNo2)
				 && (this.PureCode == target.PureCode)
				 && (this.PaymentMonthCode == target.PaymentMonthCode)
				 && (this.PaymentMonthName == target.PaymentMonthName)
				 && (this.PaymentDay == target.PaymentDay)
				 && (this.SuppCTaxLayRefCd == target.SuppCTaxLayRefCd)
				 && (this.SuppCTaxLayCd == target.SuppCTaxLayCd)
				 && (this.SuppCTaxationCd == target.SuppCTaxationCd)
				 && (this.SuppEnterpriseCd == target.SuppEnterpriseCd)
				 && (this.PayeeCode == target.PayeeCode)
				 && (this.SupplierAttributeDiv == target.SupplierAttributeDiv)
				 && (this.SuppTtlAmntDspWayCd == target.SuppTtlAmntDspWayCd)
				 && (this.StckTtlAmntDspWayRef == target.StckTtlAmntDspWayRef)
				 && (this.PaymentCond == target.PaymentCond)
				 && (this.PaymentTotalDay == target.PaymentTotalDay)
				 && (this.PaymentSight == target.PaymentSight)
				 && (this.StockAgentCode == target.StockAgentCode)
				 && (this.StockUnPrcFrcProcCd == target.StockUnPrcFrcProcCd)
				 && (this.StockMoneyFrcProcCd == target.StockMoneyFrcProcCd)
				 && (this.StockCnsTaxFrcProcCd == target.StockCnsTaxFrcProcCd)
				 && (this.NTimeCalcStDate == target.NTimeCalcStDate)
				 && (this.SupplierNote1 == target.SupplierNote1)
				 && (this.SupplierNote2 == target.SupplierNote2)
				 && (this.SupplierNote3 == target.SupplierNote3)
				 && (this.SupplierNote4 == target.SupplierNote4)
				 && (this.StockAgentName == target.StockAgentName)
				 && (this.MngSectionName == target.MngSectionName)
				 && (this.InpSectionName == target.InpSectionName)
				 && (this.PaymentSectionName == target.PaymentSectionName)
				 && (this.BusinessTypeName == target.BusinessTypeName)
				 && (this.SalesAreaName == target.SalesAreaName)
				 && (this.PayeeName == target.PayeeName)
				 && (this.PayeeName2 == target.PayeeName2)
				 && (this.PayeeSnm == target.PayeeSnm)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.SuppCTaxLayMethodNm == target.SuppCTaxLayMethodNm));
		}

		/// <summary>
		/// �d����}�X�^��r����
		/// </summary>
		/// <param name="supplier1">
		///                    ��r����Supplier�N���X�̃C���X�^���X
		/// </param>
		/// <param name="supplier2">��r����Supplier�N���X�̃C���X�^���X</param>
		/// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Supplier�N���X�̓��e����v���邩��r���܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static bool Equals(Supplier supplier1, Supplier supplier2)
		{
			return ((supplier1.CreateDateTime == supplier2.CreateDateTime)
				 && (supplier1.UpdateDateTime == supplier2.UpdateDateTime)
				 && (supplier1.EnterpriseCode == supplier2.EnterpriseCode)
				 && (supplier1.FileHeaderGuid == supplier2.FileHeaderGuid)
				 && (supplier1.UpdEmployeeCode == supplier2.UpdEmployeeCode)
				 && (supplier1.UpdAssemblyId1 == supplier2.UpdAssemblyId1)
				 && (supplier1.UpdAssemblyId2 == supplier2.UpdAssemblyId2)
				 && (supplier1.LogicalDeleteCode == supplier2.LogicalDeleteCode)
				 && (supplier1.SupplierCd == supplier2.SupplierCd)
				 && (supplier1.MngSectionCode == supplier2.MngSectionCode)
				 && (supplier1.InpSectionCode == supplier2.InpSectionCode)
				 && (supplier1.PaymentSectionCode == supplier2.PaymentSectionCode)
				 && (supplier1.SupplierNm1 == supplier2.SupplierNm1)
				 && (supplier1.SupplierNm2 == supplier2.SupplierNm2)
				 && (supplier1.SuppHonorificTitle == supplier2.SuppHonorificTitle)
				 && (supplier1.SupplierKana == supplier2.SupplierKana)
				 && (supplier1.SupplierSnm == supplier2.SupplierSnm)
				 && (supplier1.OrderHonorificTtl == supplier2.OrderHonorificTtl)
				 && (supplier1.BusinessTypeCode == supplier2.BusinessTypeCode)
				 && (supplier1.SalesAreaCode == supplier2.SalesAreaCode)
				 && (supplier1.SupplierPostNo == supplier2.SupplierPostNo)
				 && (supplier1.SupplierAddr1 == supplier2.SupplierAddr1)
				 && (supplier1.SupplierAddr3 == supplier2.SupplierAddr3)
				 && (supplier1.SupplierAddr4 == supplier2.SupplierAddr4)
				 && (supplier1.SupplierTelNo == supplier2.SupplierTelNo)
				 && (supplier1.SupplierTelNo1 == supplier2.SupplierTelNo1)
				 && (supplier1.SupplierTelNo2 == supplier2.SupplierTelNo2)
				 && (supplier1.PureCode == supplier2.PureCode)
				 && (supplier1.PaymentMonthCode == supplier2.PaymentMonthCode)
				 && (supplier1.PaymentMonthName == supplier2.PaymentMonthName)
				 && (supplier1.PaymentDay == supplier2.PaymentDay)
				 && (supplier1.SuppCTaxLayRefCd == supplier2.SuppCTaxLayRefCd)
				 && (supplier1.SuppCTaxLayCd == supplier2.SuppCTaxLayCd)
				 && (supplier1.SuppCTaxationCd == supplier2.SuppCTaxationCd)
				 && (supplier1.SuppEnterpriseCd == supplier2.SuppEnterpriseCd)
				 && (supplier1.PayeeCode == supplier2.PayeeCode)
				 && (supplier1.SupplierAttributeDiv == supplier2.SupplierAttributeDiv)
				 && (supplier1.SuppTtlAmntDspWayCd == supplier2.SuppTtlAmntDspWayCd)
				 && (supplier1.StckTtlAmntDspWayRef == supplier2.StckTtlAmntDspWayRef)
				 && (supplier1.PaymentCond == supplier2.PaymentCond)
				 && (supplier1.PaymentTotalDay == supplier2.PaymentTotalDay)
				 && (supplier1.PaymentSight == supplier2.PaymentSight)
				 && (supplier1.StockAgentCode == supplier2.StockAgentCode)
				 && (supplier1.StockUnPrcFrcProcCd == supplier2.StockUnPrcFrcProcCd)
				 && (supplier1.StockMoneyFrcProcCd == supplier2.StockMoneyFrcProcCd)
				 && (supplier1.StockCnsTaxFrcProcCd == supplier2.StockCnsTaxFrcProcCd)
				 && (supplier1.NTimeCalcStDate == supplier2.NTimeCalcStDate)
				 && (supplier1.SupplierNote1 == supplier2.SupplierNote1)
				 && (supplier1.SupplierNote2 == supplier2.SupplierNote2)
				 && (supplier1.SupplierNote3 == supplier2.SupplierNote3)
				 && (supplier1.SupplierNote4 == supplier2.SupplierNote4)
				 && (supplier1.StockAgentName == supplier2.StockAgentName)
				 && (supplier1.MngSectionName == supplier2.MngSectionName)
				 && (supplier1.InpSectionName == supplier2.InpSectionName)
				 && (supplier1.PaymentSectionName == supplier2.PaymentSectionName)
				 && (supplier1.BusinessTypeName == supplier2.BusinessTypeName)
				 && (supplier1.SalesAreaName == supplier2.SalesAreaName)
				 && (supplier1.PayeeName == supplier2.PayeeName)
				 && (supplier1.PayeeName2 == supplier2.PayeeName2)
				 && (supplier1.PayeeSnm == supplier2.PayeeSnm)
				 && (supplier1.EnterpriseName == supplier2.EnterpriseName)
				 && (supplier1.UpdEmployeeName == supplier2.UpdEmployeeName)
				 && (supplier1.SuppCTaxLayMethodNm == supplier2.SuppCTaxLayMethodNm));
		}
		/// <summary>
		/// �d����}�X�^��r����
		/// </summary>
		/// <param name="target">��r�Ώۂ�Supplier�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Supplier�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public ArrayList Compare(Supplier target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.FileHeaderGuid != target.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(this.UpdEmployeeCode != target.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(this.UpdAssemblyId1 != target.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(this.UpdAssemblyId2 != target.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.MngSectionCode != target.MngSectionCode)resList.Add("MngSectionCode");
			if(this.InpSectionCode != target.InpSectionCode)resList.Add("InpSectionCode");
			if(this.PaymentSectionCode != target.PaymentSectionCode)resList.Add("PaymentSectionCode");
			if(this.SupplierNm1 != target.SupplierNm1)resList.Add("SupplierNm1");
			if(this.SupplierNm2 != target.SupplierNm2)resList.Add("SupplierNm2");
			if(this.SuppHonorificTitle != target.SuppHonorificTitle)resList.Add("SuppHonorificTitle");
			if(this.SupplierKana != target.SupplierKana)resList.Add("SupplierKana");
			if(this.SupplierSnm != target.SupplierSnm)resList.Add("SupplierSnm");
			if(this.OrderHonorificTtl != target.OrderHonorificTtl)resList.Add("OrderHonorificTtl");
			if(this.BusinessTypeCode != target.BusinessTypeCode)resList.Add("BusinessTypeCode");
			if(this.SalesAreaCode != target.SalesAreaCode)resList.Add("SalesAreaCode");
			if(this.SupplierPostNo != target.SupplierPostNo)resList.Add("SupplierPostNo");
			if(this.SupplierAddr1 != target.SupplierAddr1)resList.Add("SupplierAddr1");
			if(this.SupplierAddr3 != target.SupplierAddr3)resList.Add("SupplierAddr3");
			if(this.SupplierAddr4 != target.SupplierAddr4)resList.Add("SupplierAddr4");
			if(this.SupplierTelNo != target.SupplierTelNo)resList.Add("SupplierTelNo");
			if(this.SupplierTelNo1 != target.SupplierTelNo1)resList.Add("SupplierTelNo1");
			if(this.SupplierTelNo2 != target.SupplierTelNo2)resList.Add("SupplierTelNo2");
			if(this.PureCode != target.PureCode)resList.Add("PureCode");
			if(this.PaymentMonthCode != target.PaymentMonthCode)resList.Add("PaymentMonthCode");
			if(this.PaymentMonthName != target.PaymentMonthName)resList.Add("PaymentMonthName");
			if(this.PaymentDay != target.PaymentDay)resList.Add("PaymentDay");
			if(this.SuppCTaxLayRefCd != target.SuppCTaxLayRefCd)resList.Add("SuppCTaxLayRefCd");
			if(this.SuppCTaxLayCd != target.SuppCTaxLayCd)resList.Add("SuppCTaxLayCd");
			if(this.SuppCTaxationCd != target.SuppCTaxationCd)resList.Add("SuppCTaxationCd");
			if(this.SuppEnterpriseCd != target.SuppEnterpriseCd)resList.Add("SuppEnterpriseCd");
			if(this.PayeeCode != target.PayeeCode)resList.Add("PayeeCode");
			if(this.SupplierAttributeDiv != target.SupplierAttributeDiv)resList.Add("SupplierAttributeDiv");
			if(this.SuppTtlAmntDspWayCd != target.SuppTtlAmntDspWayCd)resList.Add("SuppTtlAmntDspWayCd");
			if(this.StckTtlAmntDspWayRef != target.StckTtlAmntDspWayRef)resList.Add("StckTtlAmntDspWayRef");
			if(this.PaymentCond != target.PaymentCond)resList.Add("PaymentCond");
			if(this.PaymentTotalDay != target.PaymentTotalDay)resList.Add("PaymentTotalDay");
			if(this.PaymentSight != target.PaymentSight)resList.Add("PaymentSight");
			if(this.StockAgentCode != target.StockAgentCode)resList.Add("StockAgentCode");
			if(this.StockUnPrcFrcProcCd != target.StockUnPrcFrcProcCd)resList.Add("StockUnPrcFrcProcCd");
			if(this.StockMoneyFrcProcCd != target.StockMoneyFrcProcCd)resList.Add("StockMoneyFrcProcCd");
			if(this.StockCnsTaxFrcProcCd != target.StockCnsTaxFrcProcCd)resList.Add("StockCnsTaxFrcProcCd");
			if(this.NTimeCalcStDate != target.NTimeCalcStDate)resList.Add("NTimeCalcStDate");
			if(this.SupplierNote1 != target.SupplierNote1)resList.Add("SupplierNote1");
			if(this.SupplierNote2 != target.SupplierNote2)resList.Add("SupplierNote2");
			if(this.SupplierNote3 != target.SupplierNote3)resList.Add("SupplierNote3");
			if(this.SupplierNote4 != target.SupplierNote4)resList.Add("SupplierNote4");
			if(this.StockAgentName != target.StockAgentName)resList.Add("StockAgentName");
			if(this.MngSectionName != target.MngSectionName)resList.Add("MngSectionName");
			if(this.InpSectionName != target.InpSectionName)resList.Add("InpSectionName");
			if(this.PaymentSectionName != target.PaymentSectionName)resList.Add("PaymentSectionName");
			if(this.BusinessTypeName != target.BusinessTypeName)resList.Add("BusinessTypeName");
			if(this.SalesAreaName != target.SalesAreaName)resList.Add("SalesAreaName");
			if(this.PayeeName != target.PayeeName)resList.Add("PayeeName");
			if(this.PayeeName2 != target.PayeeName2)resList.Add("PayeeName2");
			if(this.PayeeSnm != target.PayeeSnm)resList.Add("PayeeSnm");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.SuppCTaxLayMethodNm != target.SuppCTaxLayMethodNm)resList.Add("SuppCTaxLayMethodNm");

			return resList;
		}

		/// <summary>
		/// �d����}�X�^��r����
		/// </summary>
		/// <param name="supplier1">��r����Supplier�N���X�̃C���X�^���X</param>
		/// <param name="supplier2">��r����Supplier�N���X�̃C���X�^���X</param>
		/// <returns>��v���Ȃ����ڂ̃��X�g</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   Supplier�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public static ArrayList Compare(Supplier supplier1, Supplier supplier2)
		{
			ArrayList resList = new ArrayList();
			if(supplier1.CreateDateTime != supplier2.CreateDateTime)resList.Add("CreateDateTime");
			if(supplier1.UpdateDateTime != supplier2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(supplier1.EnterpriseCode != supplier2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(supplier1.FileHeaderGuid != supplier2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(supplier1.UpdEmployeeCode != supplier2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(supplier1.UpdAssemblyId1 != supplier2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(supplier1.UpdAssemblyId2 != supplier2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(supplier1.LogicalDeleteCode != supplier2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(supplier1.SupplierCd != supplier2.SupplierCd)resList.Add("SupplierCd");
			if(supplier1.MngSectionCode != supplier2.MngSectionCode)resList.Add("MngSectionCode");
			if(supplier1.InpSectionCode != supplier2.InpSectionCode)resList.Add("InpSectionCode");
			if(supplier1.PaymentSectionCode != supplier2.PaymentSectionCode)resList.Add("PaymentSectionCode");
			if(supplier1.SupplierNm1 != supplier2.SupplierNm1)resList.Add("SupplierNm1");
			if(supplier1.SupplierNm2 != supplier2.SupplierNm2)resList.Add("SupplierNm2");
			if(supplier1.SuppHonorificTitle != supplier2.SuppHonorificTitle)resList.Add("SuppHonorificTitle");
			if(supplier1.SupplierKana != supplier2.SupplierKana)resList.Add("SupplierKana");
			if(supplier1.SupplierSnm != supplier2.SupplierSnm)resList.Add("SupplierSnm");
			if(supplier1.OrderHonorificTtl != supplier2.OrderHonorificTtl)resList.Add("OrderHonorificTtl");
			if(supplier1.BusinessTypeCode != supplier2.BusinessTypeCode)resList.Add("BusinessTypeCode");
			if(supplier1.SalesAreaCode != supplier2.SalesAreaCode)resList.Add("SalesAreaCode");
			if(supplier1.SupplierPostNo != supplier2.SupplierPostNo)resList.Add("SupplierPostNo");
			if(supplier1.SupplierAddr1 != supplier2.SupplierAddr1)resList.Add("SupplierAddr1");
			if(supplier1.SupplierAddr3 != supplier2.SupplierAddr3)resList.Add("SupplierAddr3");
			if(supplier1.SupplierAddr4 != supplier2.SupplierAddr4)resList.Add("SupplierAddr4");
			if(supplier1.SupplierTelNo != supplier2.SupplierTelNo)resList.Add("SupplierTelNo");
			if(supplier1.SupplierTelNo1 != supplier2.SupplierTelNo1)resList.Add("SupplierTelNo1");
			if(supplier1.SupplierTelNo2 != supplier2.SupplierTelNo2)resList.Add("SupplierTelNo2");
			if(supplier1.PureCode != supplier2.PureCode)resList.Add("PureCode");
			if(supplier1.PaymentMonthCode != supplier2.PaymentMonthCode)resList.Add("PaymentMonthCode");
			if(supplier1.PaymentMonthName != supplier2.PaymentMonthName)resList.Add("PaymentMonthName");
			if(supplier1.PaymentDay != supplier2.PaymentDay)resList.Add("PaymentDay");
			if(supplier1.SuppCTaxLayRefCd != supplier2.SuppCTaxLayRefCd)resList.Add("SuppCTaxLayRefCd");
			if(supplier1.SuppCTaxLayCd != supplier2.SuppCTaxLayCd)resList.Add("SuppCTaxLayCd");
			if(supplier1.SuppCTaxationCd != supplier2.SuppCTaxationCd)resList.Add("SuppCTaxationCd");
			if(supplier1.SuppEnterpriseCd != supplier2.SuppEnterpriseCd)resList.Add("SuppEnterpriseCd");
			if(supplier1.PayeeCode != supplier2.PayeeCode)resList.Add("PayeeCode");
			if(supplier1.SupplierAttributeDiv != supplier2.SupplierAttributeDiv)resList.Add("SupplierAttributeDiv");
			if(supplier1.SuppTtlAmntDspWayCd != supplier2.SuppTtlAmntDspWayCd)resList.Add("SuppTtlAmntDspWayCd");
			if(supplier1.StckTtlAmntDspWayRef != supplier2.StckTtlAmntDspWayRef)resList.Add("StckTtlAmntDspWayRef");
			if(supplier1.PaymentCond != supplier2.PaymentCond)resList.Add("PaymentCond");
			if(supplier1.PaymentTotalDay != supplier2.PaymentTotalDay)resList.Add("PaymentTotalDay");
			if(supplier1.PaymentSight != supplier2.PaymentSight)resList.Add("PaymentSight");
			if(supplier1.StockAgentCode != supplier2.StockAgentCode)resList.Add("StockAgentCode");
			if(supplier1.StockUnPrcFrcProcCd != supplier2.StockUnPrcFrcProcCd)resList.Add("StockUnPrcFrcProcCd");
			if(supplier1.StockMoneyFrcProcCd != supplier2.StockMoneyFrcProcCd)resList.Add("StockMoneyFrcProcCd");
			if(supplier1.StockCnsTaxFrcProcCd != supplier2.StockCnsTaxFrcProcCd)resList.Add("StockCnsTaxFrcProcCd");
			if(supplier1.NTimeCalcStDate != supplier2.NTimeCalcStDate)resList.Add("NTimeCalcStDate");
			if(supplier1.SupplierNote1 != supplier2.SupplierNote1)resList.Add("SupplierNote1");
			if(supplier1.SupplierNote2 != supplier2.SupplierNote2)resList.Add("SupplierNote2");
			if(supplier1.SupplierNote3 != supplier2.SupplierNote3)resList.Add("SupplierNote3");
			if(supplier1.SupplierNote4 != supplier2.SupplierNote4)resList.Add("SupplierNote4");
			if(supplier1.StockAgentName != supplier2.StockAgentName)resList.Add("StockAgentName");
			if(supplier1.MngSectionName != supplier2.MngSectionName)resList.Add("MngSectionName");
			if(supplier1.InpSectionName != supplier2.InpSectionName)resList.Add("InpSectionName");
			if(supplier1.PaymentSectionName != supplier2.PaymentSectionName)resList.Add("PaymentSectionName");
			if(supplier1.BusinessTypeName != supplier2.BusinessTypeName)resList.Add("BusinessTypeName");
			if(supplier1.SalesAreaName != supplier2.SalesAreaName)resList.Add("SalesAreaName");
			if(supplier1.PayeeName != supplier2.PayeeName)resList.Add("PayeeName");
			if(supplier1.PayeeName2 != supplier2.PayeeName2)resList.Add("PayeeName2");
			if(supplier1.PayeeSnm != supplier2.PayeeSnm)resList.Add("PayeeSnm");
			if(supplier1.EnterpriseName != supplier2.EnterpriseName)resList.Add("EnterpriseName");
			if(supplier1.UpdEmployeeName != supplier2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(supplier1.SuppCTaxLayMethodNm != supplier2.SuppCTaxLayMethodNm)resList.Add("SuppCTaxLayMethodNm");

			return resList;
        }
        # endregion

        # region [�i�蓮�ǉ��j]
        /// <summary>
        /// �h�́@�擾
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetHonorificTitle( int code )
        {
            switch ( code )
            {
                case 0:
                    return CST_HonorificTitle_0;
                case 1:
                    return CST_HonorificTitle_1;
                case 2:
                    return CST_HonorificTitle_2;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// �����敪�@���̎擾
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetPureCodeName( int code )
        {
            switch ( code )
            {
                case 0:
                    return CST_PureCode_0;
                case 1:
                    return CST_PureCode_1;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// �x�����敪�@���̎擾
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetPaymentMonthCodeName( int code )
        {
            switch ( code )
            {
                case 0:
                    return CST_PaymentMonthCode_0;
                case 1:
                    return CST_PaymentMonthCode_1;
                case 2:
                    return CST_PaymentMonthCode_2;
                case 3:
                    return CST_PaymentMonthCode_3;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// ����œ]�ŕ����Q�Ƌ敪�@���̎擾
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetSuppCTaxLayRefCdName( int code )
        {
            switch ( code )
            {
                case 0:
                    return CST_SuppCTaxLayRefCd_0;
                case 1:
                    return CST_SuppCTaxLayRefCd_1;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// ����œ]�ŕ����敪�@���̎擾
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetSuppCTaxLayCdName( int code )
        {
            switch ( code )
            {
                case 0:
                    return CST_SuppCTaxLayCd_0;
                case 1:
                    return CST_SuppCTaxLayCd_1;
                case 2:
                    return CST_SuppCTaxLayCd_2;
                case 3:
                    return CST_SuppCTaxLayCd_3;
                case 9:
                    return CST_SuppCTaxLayCd_9;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// �ېŕ����敪 ���̎擾
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetSuppCTaxationCdName( int code )
        {
            switch ( code )
            {
                case 0:
                    return CST_SuppCTaxationCd_0;
                case 1:
                    return CST_SuppCTaxationCd_1;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// �d���摮���敪 ���̎擾
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetSupplierAttributeDivName( int code )
        {
            switch ( code )
            {
                case 0:
                    return CST_SupplierAttributeDiv_0;
                case 8:
                    return CST_SupplierAttributeDiv_8;
                case 9:
                    return CST_SupplierAttributeDiv_9;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// ���z�\���敪 ���̎擾
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetSuppTtlAmntDspWayCdName( int code )
        {
            switch ( code )
            {
                case 0:
                    return CST_SuppTtlAmntDspWayCd_0;
                case 1:
                    return CST_SuppTtlAmntDspWayCd_1;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// ���z�\���Q�Ƌ敪 ���̎擾
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetStckTtlAmntDspWayRefName( int code )
        {
            switch ( code )
            {
                case 0:
                    return CST_StckTtlAmntDspWayRef_0;
                case 1:
                    return CST_StckTtlAmntDspWayRef_1;
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// �x������ ���̎擾
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetPaymentCondName( int code )
        {
            switch ( code )
            {
                case 10:
                    return CST_PaymentCond_10;
                case 20:
                    return CST_PaymentCond_20;
                case 30:
                    return CST_PaymentCond_30;
                case 40:
                    return CST_PaymentCond_40;
                case 50:
                    return CST_PaymentCond_50;
                case 60:
                    return CST_PaymentCond_60;
                case 70:
                    return CST_PaymentCond_70;
                case 80:
                    return CST_PaymentCond_80;
                default:
                    return string.Empty;
            }
        }
        # endregion
    }
}
