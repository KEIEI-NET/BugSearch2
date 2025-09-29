using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SupplierCheckResult
    /// <summary>
    ///                      �d���`�F�b�N�������o���ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���`�F�b�N�������o���ʃN���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :  2012/08/30 ������</br>
    /// <br>                    Redmine#31879�̑Ή� UOE�d���f�[�^�̋敪���擾</br>
    /// <br>Update Note      :  2012/10/09 �� ��</br>
    /// <br>                    Redmine#31879�̑Ή� �ԓ`�敪���擾</br>
    /// </remarks>
    public class SupplierCheckResult
    {
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

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�d���`�F�b�N�敪�i�����j</summary>
        /// <remarks>0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j</remarks>
        private Int32 _stockCheckDivCAddUp;

        /// <summary>�d���`�F�b�N�敪�i�����j</summary>
        /// <remarks>0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j</remarks>
        private Int32 _stockCheckDivDaily;

        /// <summary>�d����</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _stockDate;

        /// <summary>���͓�</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private DateTime _inputDay;

        /// <summary>�d���`�[�ԍ�</summary>
        /// <remarks>�����`�[�ԍ��A�d���`�[�ԍ��A���ד`�[�ԍ������˂�</remarks>
        private Int32 _supplierSlipNo;

        /// <summary>�����`�[�ԍ�</summary>
        /// <remarks>�d����`�[�ԍ��Ɏg�p����</remarks>
        private string _partySaleSlipNum = "";

        /// <summary>�d�����z�i�ō��݁j</summary>
        private Int64 _stockPriceTaxInc;

        /// <summary>�d�����z�i�Ŕ����j</summary>
        private Int64 _stockPriceTaxExc;

        /// <summary>�d�����z����Ŋz</summary>
        /// <remarks>�d�����z�i�ō��݁j- �d�����z�i�Ŕ����j������Œ����z�����˂�</remarks>
        private Int64 _stockPriceConsTax;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>�d����</summary>
        private Double _stockCount;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>�d���P���i�Ŕ��C�����j</summary>
        /// <remarks>�Ŕ���</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>�艿�i�Ŕ��C�����j</summary>
        /// <remarks>�Ŕ���</remarks>
        private Double _listPriceTaxExcFl;

        /// <summary>����P���i�Ŕ��C�����j</summary>
        private Double _salesUnPrcTaxExcFl;

        /// <summary>������z�i�Ŕ����j</summary>
        private Int64 _salesMoneyTaxExc;

        /// <summary>������t</summary>
        /// <remarks>(YYYYMMDD)</remarks>
        private DateTime _salesDate;

        /// <summary>����`�[�ԍ�</summary>
        private string _salesSlipNum = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�̔��]�ƈ�����</summary>
        private string _salesEmployeeNm = "";

        /// <summary>��t�]�ƈ�����</summary>
        private string _frontEmployeeNm = "";

        /// <summary>������͎Җ���</summary>
        private string _salesInputName = "";

        /// <summary>�t�n�d���}�[�N�P</summary>
        /// <remarks>UserOrderEntory</remarks>
        private string _uoeRemark1 = "";

        /// <summary>�t�n�d���}�[�N�Q</summary>
        private string _uoeRemark2 = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>�d���`��</summary>
        /// <remarks>0:�d���@�i�󒍃X�e�[�^�X�j</remarks>
        private Int32 _supplierFormal;

        /// <summary>�d�����גʔ�</summary>
        private Int64 _stockSlipDtlNum;

        /// <summary>�ύX�O�d���P���i�����j</summary>
        /// <remarks>�Ŕ����A�|���Z�o����</remarks>
        private Double _bfStockUnitPriceFl;

        /// <summary>�d���`�[�敪</summary>
        /// <remarks>10:�d��,20:�ԕi</remarks>
        private Int32 _supplierSlipCd;

        /// <summary>�d�����i�敪</summary>
        /// <remarks>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����</remarks>
        private Int32 _stockGoodsCd;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>BL���i�R�[�h����</summary>
        private string _bLGoodsName = "";

        //------ADD BY �� �� on 2012/10/09 for Redmine#31879------->>>>>>>
        /// <summary> �ԓ`�敪</summary>
        /// <remarks>0:���`,1:�ԓ`,2:����</remarks>
        private Int32 _debitNoteDiv;
        //------ADD BY �� �� on 2012/10/09 for Redmine#31879-------<<<<<<<<

        //------ADD BY ������ on 2012/08/30 for Redmine#31879------->>>>>>>
        /// <summary> �������@</summary>
        /// <remarks>0:����������,1:FAX���M,2:�I�����C������,4:�����ώ���o�^</remarks>
        private Int32 _wayToOrder;

        /// public propaty name  :  WayToOrder
        /// <summary>�������@�v���p�e�B</summary>
        /// <value>0:����������,1:FAX���M,2:�I�����C������,4:�����ώ���o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������@�v���p�e�B</br>
        /// <br>Programer        :   �ǉ�</br>
        /// </remarks>
        public Int32 WayToOrder
        {
            get { return _wayToOrder; }
            set { _wayToOrder = value; }
        }
        //------ADD BY ������ on 2012/08/30 for Redmine#31879-------<<<<<<<<

        //------ADD BY �� �� on 2012/10/09 for Redmine#31879------->>>>>>>
        /// public propaty name  :  DebitNoteDiv
        /// <summary>�ԓ`�敪�v���p�e�B</summary>
        /// <value>0:���`,1:�ԓ`,2:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ԓ`�敪�v���p�e�B</br>
        /// <br>Programer        :   �ǉ�</br>
        /// </remarks>
        public Int32 DebitNoteDiv
        {
            get { return _debitNoteDiv; }
            set { _debitNoteDiv = value; }
        }
        //------ADD BY �� �� on 2012/10/09 for Redmine#31879-------<<<<<<<<

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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
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

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  StockCheckDivCAddUp
        /// <summary>�d���`�F�b�N�敪�i�����j�v���p�e�B</summary>
        /// <value>0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�F�b�N�敪�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockCheckDivCAddUp
        {
            get { return _stockCheckDivCAddUp; }
            set { _stockCheckDivCAddUp = value; }
        }

        /// public propaty name  :  StockCheckDivDaily
        /// <summary>�d���`�F�b�N�敪�i�����j�v���p�e�B</summary>
        /// <value>0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�F�b�N�敪�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockCheckDivDaily
        {
            get { return _stockCheckDivDaily; }
            set { _stockCheckDivDaily = value; }
        }

        /// public propaty name  :  StockDate
        /// <summary>�d�����v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime StockDate
        {
            get { return _stockDate; }
            set { _stockDate = value; }
        }

        /// public propaty name  :  StockDateJpFormal
        /// <summary>�d���� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _stockDate); }
            set { }
        }

        /// public propaty name  :  StockDateJpInFormal
        /// <summary>�d���� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _stockDate); }
            set { }
        }

        /// public propaty name  :  StockDateAdFormal
        /// <summary>�d���� ����v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _stockDate); }
            set { }
        }

        /// public propaty name  :  StockDateAdInFormal
        /// <summary>�d���� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _stockDate); }
            set { }
        }

        /// public propaty name  :  InputDay
        /// <summary>���͓��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InputDay
        {
            get { return _inputDay; }
            set { _inputDay = value; }
        }

        /// public propaty name  :  InputDayJpFormal
        /// <summary>���͓� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputDayJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _inputDay); }
            set { }
        }

        /// public propaty name  :  InputDayJpInFormal
        /// <summary>���͓� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputDayJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _inputDay); }
            set { }
        }

        /// public propaty name  :  InputDayAdFormal
        /// <summary>���͓� ����v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputDayAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _inputDay); }
            set { }
        }

        /// public propaty name  :  InputDayAdInFormal
        /// <summary>���͓� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string InputDayAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _inputDay); }
            set { }
        }

        /// public propaty name  :  SupplierSlipNo
        /// <summary>�d���`�[�ԍ��v���p�e�B</summary>
        /// <value>�����`�[�ԍ��A�d���`�[�ԍ��A���ד`�[�ԍ������˂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipNo
        {
            get { return _supplierSlipNo; }
            set { _supplierSlipNo = value; }
        }

        /// public propaty name  :  PartySaleSlipNum
        /// <summary>�����`�[�ԍ��v���p�e�B</summary>
        /// <value>�d����`�[�ԍ��Ɏg�p����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PartySaleSlipNum
        {
            get { return _partySaleSlipNum; }
            set { _partySaleSlipNum = value; }
        }

        /// public propaty name  :  StockPriceTaxInc
        /// <summary>�d�����z�i�ō��݁j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�i�ō��݁j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceTaxInc
        {
            get { return _stockPriceTaxInc; }
            set { _stockPriceTaxInc = value; }
        }

        /// public propaty name  :  StockPriceTaxExc
        /// <summary>�d�����z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceTaxExc
        {
            get { return _stockPriceTaxExc; }
            set { _stockPriceTaxExc = value; }
        }

        /// public propaty name  :  StockPriceConsTax
        /// <summary>�d�����z����Ŋz�v���p�e�B</summary>
        /// <value>�d�����z�i�ō��݁j- �d�����z�i�Ŕ����j������Œ����z�����˂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����z����Ŋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockPriceConsTax
        {
            get { return _stockPriceConsTax; }
            set { _stockPriceConsTax = value; }
        }

        /// public propaty name  :  GoodsNo
        /// <summary>���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }

        /// public propaty name  :  StockCount
        /// <summary>�d�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockCount
        {
            get { return _stockCount; }
            set { _stockCount = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>�d���P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�Ŕ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  ListPriceTaxExcFl
        /// <summary>�艿�i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�Ŕ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPriceTaxExcFl
        {
            get { return _listPriceTaxExcFl; }
            set { _listPriceTaxExcFl = value; }
        }

        /// public propaty name  :  SalesUnPrcTaxExcFl
        /// <summary>����P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnPrcTaxExcFl
        {
            get { return _salesUnPrcTaxExcFl; }
            set { _salesUnPrcTaxExcFl = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>������z�i�Ŕ����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������z�i�Ŕ����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>������t�v���p�e�B</summary>
        /// <value>(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  SalesDateJpFormal
        /// <summary>������t �a��v���p�e�B</summary>
        /// <value>(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateJpInFormal
        /// <summary>������t �a��(��)�v���p�e�B</summary>
        /// <value>(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateAdFormal
        /// <summary>������t ����v���p�e�B</summary>
        /// <value>(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesDateAdInFormal
        /// <summary>������t ����(��)�v���p�e�B</summary>
        /// <value>(YYYYMMDD)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _salesDate); }
            set { }
        }

        /// public propaty name  :  SalesSlipNum
        /// <summary>����`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesSlipNum
        {
            get { return _salesSlipNum; }
            set { _salesSlipNum = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>���Ӑ旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  SalesEmployeeNm
        /// <summary>�̔��]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesEmployeeNm
        {
            get { return _salesEmployeeNm; }
            set { _salesEmployeeNm = value; }
        }

        /// public propaty name  :  FrontEmployeeNm
        /// <summary>��t�]�ƈ����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��t�]�ƈ����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FrontEmployeeNm
        {
            get { return _frontEmployeeNm; }
            set { _frontEmployeeNm = value; }
        }

        /// public propaty name  :  SalesInputName
        /// <summary>������͎Җ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������͎Җ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesInputName
        {
            get { return _salesInputName; }
            set { _salesInputName = value; }
        }

        /// public propaty name  :  UoeRemark1
        /// <summary>�t�n�d���}�[�N�P�v���p�e�B</summary>
        /// <value>UserOrderEntory</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark1
        {
            get { return _uoeRemark1; }
            set { _uoeRemark1 = value; }
        }

        /// public propaty name  :  UoeRemark2
        /// <summary>�t�n�d���}�[�N�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�n�d���}�[�N�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UoeRemark2
        {
            get { return _uoeRemark2; }
            set { _uoeRemark2 = value; }
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

        /// public propaty name  :  SupplierFormal
        /// <summary>�d���`���v���p�e�B</summary>
        /// <value>0:�d���@�i�󒍃X�e�[�^�X�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierFormal
        {
            get { return _supplierFormal; }
            set { _supplierFormal = value; }
        }

        /// public propaty name  :  StockSlipDtlNum
        /// <summary>�d�����גʔԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����גʔԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockSlipDtlNum
        {
            get { return _stockSlipDtlNum; }
            set { _stockSlipDtlNum = value; }
        }

        /// public propaty name  :  BfStockUnitPriceFl
        /// <summary>�ύX�O�d���P���i�����j�v���p�e�B</summary>
        /// <value>�Ŕ����A�|���Z�o����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ύX�O�d���P���i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double BfStockUnitPriceFl
        {
            get { return _bfStockUnitPriceFl; }
            set { _bfStockUnitPriceFl = value; }
        }

        /// public propaty name  :  SupplierSlipCd
        /// <summary>�d���`�[�敪�v���p�e�B</summary>
        /// <value>10:�d��,20:�ԕi</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierSlipCd
        {
            get { return _supplierSlipCd; }
            set { _supplierSlipCd = value; }
        }

        /// public propaty name  :  StockGoodsCd
        /// <summary>�d�����i�敪�v���p�e�B</summary>
        /// <value>0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockGoodsCd
        {
            get { return _stockGoodsCd; }
            set { _stockGoodsCd = value; }
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

        /// public propaty name  :  BLGoodsName
        /// <summary>BL���i�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }


        /// <summary>
        /// �d���`�F�b�N�������o���ʃN���X�R���X�g���N�^
        /// </summary>
        /// <returns>SupplierCheckResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierCheckResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SupplierCheckResult()
        {
        }

        /// <summary>
        /// �d���`�F�b�N�������o���ʃN���X�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="stockCheckDivCAddUp">�d���`�F�b�N�敪�i�����j(0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j)</param>
        /// <param name="stockCheckDivDaily">�d���`�F�b�N�敪�i�����j(0:������,1:�����ρ@�i���׃f�[�^�Ǝd����`�[���ׂ̔�r�j)</param>
        /// <param name="stockDate">�d����(YYYYMMDD�@�i�X�V�N�����j)</param>
        /// <param name="inputDay">���͓�(YYYYMMDD�@�i�X�V�N�����j)</param>
        /// <param name="supplierSlipNo">�d���`�[�ԍ�(�����`�[�ԍ��A�d���`�[�ԍ��A���ד`�[�ԍ������˂�)</param>
        /// <param name="partySaleSlipNum">�����`�[�ԍ�(�d����`�[�ԍ��Ɏg�p����)</param>
        /// <param name="stockPriceTaxInc">�d�����z�i�ō��݁j</param>
        /// <param name="stockPriceTaxExc">�d�����z�i�Ŕ����j</param>
        /// <param name="stockPriceConsTax">�d�����z����Ŋz(�d�����z�i�ō��݁j- �d�����z�i�Ŕ����j������Œ����z�����˂�)</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="stockCount">�d����</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="goodsName">���i����</param>
        /// <param name="stockUnitPriceFl">�d���P���i�Ŕ��C�����j(�Ŕ���)</param>
        /// <param name="listPriceTaxExcFl">�艿�i�Ŕ��C�����j(�Ŕ���)</param>
        /// <param name="salesUnPrcTaxExcFl">����P���i�Ŕ��C�����j</param>
        /// <param name="salesMoneyTaxExc">������z�i�Ŕ����j</param>
        /// <param name="salesDate">������t((YYYYMMDD))</param>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="customerSnm">���Ӑ旪��</param>
        /// <param name="salesEmployeeNm">�̔��]�ƈ�����</param>
        /// <param name="frontEmployeeNm">��t�]�ƈ�����</param>
        /// <param name="salesInputName">������͎Җ���</param>
        /// <param name="uoeRemark1">�t�n�d���}�[�N�P(UserOrderEntory)</param>
        /// <param name="uoeRemark2">�t�n�d���}�[�N�Q</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="supplierSnm">�d���旪��</param>
        /// <param name="supplierFormal">�d���`��(0:�d���@�i�󒍃X�e�[�^�X�j)</param>
        /// <param name="stockSlipDtlNum">�d�����גʔ�</param>
        /// <param name="bfStockUnitPriceFl">�ύX�O�d���P���i�����j(�Ŕ����A�|���Z�o����)</param>
        /// <param name="supplierSlipCd">�d���`�[�敪(10:�d��,20:�ԕi)</param>
        /// <param name="stockGoodsCd">�d�����i�敪(0:���i,1:���i�O,2:����Œ���,3:�c������,4:���|�p����Œ���,5:���|�p�c������,6:���v����)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="bLGoodsName">BL���i�R�[�h����</param>
        /// <returns>SupplierCheckResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierCheckResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SupplierCheckResult(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 stockCheckDivCAddUp, Int32 stockCheckDivDaily, DateTime stockDate, DateTime inputDay, Int32 supplierSlipNo, string partySaleSlipNum, Int64 stockPriceTaxInc, Int64 stockPriceTaxExc, Int64 stockPriceConsTax, string goodsNo, Double stockCount, Int32 bLGoodsCode, string goodsName, Double stockUnitPriceFl, Double listPriceTaxExcFl, Double salesUnPrcTaxExcFl, Int64 salesMoneyTaxExc, DateTime salesDate, string salesSlipNum, Int32 customerCode, string customerSnm, string salesEmployeeNm, string frontEmployeeNm, string salesInputName, string uoeRemark1, string uoeRemark2, Int32 supplierCd, string supplierSnm, Int32 supplierFormal, Int64 stockSlipDtlNum, Double bfStockUnitPriceFl, Int32 supplierSlipCd, Int32 stockGoodsCd, string enterpriseName, string updEmployeeName, string bLGoodsName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;
            this._stockCheckDivCAddUp = stockCheckDivCAddUp;
            this._stockCheckDivDaily = stockCheckDivDaily;
            this.StockDate = stockDate;
            this.InputDay = inputDay;
            this._supplierSlipNo = supplierSlipNo;
            this._partySaleSlipNum = partySaleSlipNum;
            this._stockPriceTaxInc = stockPriceTaxInc;
            this._stockPriceTaxExc = stockPriceTaxExc;
            this._stockPriceConsTax = stockPriceConsTax;
            this._goodsNo = goodsNo;
            this._stockCount = stockCount;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsName = goodsName;
            this._stockUnitPriceFl = stockUnitPriceFl;
            this._listPriceTaxExcFl = listPriceTaxExcFl;
            this._salesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
            this._salesMoneyTaxExc = salesMoneyTaxExc;
            this.SalesDate = salesDate;
            this._salesSlipNum = salesSlipNum;
            this._customerCode = customerCode;
            this._customerSnm = customerSnm;
            this._salesEmployeeNm = salesEmployeeNm;
            this._frontEmployeeNm = frontEmployeeNm;
            this._salesInputName = salesInputName;
            this._uoeRemark1 = uoeRemark1;
            this._uoeRemark2 = uoeRemark2;
            this._supplierCd = supplierCd;
            this._supplierSnm = supplierSnm;
            this._supplierFormal = supplierFormal;
            this._stockSlipDtlNum = stockSlipDtlNum;
            this._bfStockUnitPriceFl = bfStockUnitPriceFl;
            this._supplierSlipCd = supplierSlipCd;
            this._stockGoodsCd = stockGoodsCd;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._bLGoodsName = bLGoodsName;

        }

        /// <summary>
        /// �d���`�F�b�N�������o���ʃN���X��������
        /// </summary>
        /// <returns>SupplierCheckResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SupplierCheckResult�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SupplierCheckResult Clone()
        {
            return new SupplierCheckResult(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._stockCheckDivCAddUp, this._stockCheckDivDaily, this._stockDate, this._inputDay, this._supplierSlipNo, this._partySaleSlipNum, this._stockPriceTaxInc, this._stockPriceTaxExc, this._stockPriceConsTax, this._goodsNo, this._stockCount, this._bLGoodsCode, this._goodsName, this._stockUnitPriceFl, this._listPriceTaxExcFl, this._salesUnPrcTaxExcFl, this._salesMoneyTaxExc, this._salesDate, this._salesSlipNum, this._customerCode, this._customerSnm, this._salesEmployeeNm, this._frontEmployeeNm, this._salesInputName, this._uoeRemark1, this._uoeRemark2, this._supplierCd, this._supplierSnm, this._supplierFormal, this._stockSlipDtlNum, this._bfStockUnitPriceFl, this._supplierSlipCd, this._stockGoodsCd, this._enterpriseName, this._updEmployeeName, this._bLGoodsName);
        }

        /// <summary>
        /// �d���`�F�b�N�������o���ʃN���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SupplierCheckResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierCheckResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(SupplierCheckResult target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.StockCheckDivCAddUp == target.StockCheckDivCAddUp)
                 && (this.StockCheckDivDaily == target.StockCheckDivDaily)
                 && (this.StockDate == target.StockDate)
                 && (this.InputDay == target.InputDay)
                 && (this.SupplierSlipNo == target.SupplierSlipNo)
                 && (this.PartySaleSlipNum == target.PartySaleSlipNum)
                 && (this.StockPriceTaxInc == target.StockPriceTaxInc)
                 && (this.StockPriceTaxExc == target.StockPriceTaxExc)
                 && (this.StockPriceConsTax == target.StockPriceConsTax)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.StockCount == target.StockCount)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.GoodsName == target.GoodsName)
                 && (this.StockUnitPriceFl == target.StockUnitPriceFl)
                 && (this.ListPriceTaxExcFl == target.ListPriceTaxExcFl)
                 && (this.SalesUnPrcTaxExcFl == target.SalesUnPrcTaxExcFl)
                 && (this.SalesMoneyTaxExc == target.SalesMoneyTaxExc)
                 && (this.SalesDate == target.SalesDate)
                 && (this.SalesSlipNum == target.SalesSlipNum)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.SalesEmployeeNm == target.SalesEmployeeNm)
                 && (this.FrontEmployeeNm == target.FrontEmployeeNm)
                 && (this.SalesInputName == target.SalesInputName)
                 && (this.UoeRemark1 == target.UoeRemark1)
                 && (this.UoeRemark2 == target.UoeRemark2)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.SupplierSnm == target.SupplierSnm)
                 && (this.SupplierFormal == target.SupplierFormal)
                 && (this.StockSlipDtlNum == target.StockSlipDtlNum)
                 && (this.BfStockUnitPriceFl == target.BfStockUnitPriceFl)
                 && (this.SupplierSlipCd == target.SupplierSlipCd)
                 && (this.StockGoodsCd == target.StockGoodsCd)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.BLGoodsName == target.BLGoodsName));
        }

        /// <summary>
        /// �d���`�F�b�N�������o���ʃN���X��r����
        /// </summary>
        /// <param name="supplierCheckResult1">
        ///                    ��r����SupplierCheckResult�N���X�̃C���X�^���X
        /// </param>
        /// <param name="supplierCheckResult2">��r����SupplierCheckResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierCheckResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(SupplierCheckResult supplierCheckResult1, SupplierCheckResult supplierCheckResult2)
        {
            return ((supplierCheckResult1.CreateDateTime == supplierCheckResult2.CreateDateTime)
                 && (supplierCheckResult1.UpdateDateTime == supplierCheckResult2.UpdateDateTime)
                 && (supplierCheckResult1.EnterpriseCode == supplierCheckResult2.EnterpriseCode)
                 && (supplierCheckResult1.FileHeaderGuid == supplierCheckResult2.FileHeaderGuid)
                 && (supplierCheckResult1.UpdEmployeeCode == supplierCheckResult2.UpdEmployeeCode)
                 && (supplierCheckResult1.UpdAssemblyId1 == supplierCheckResult2.UpdAssemblyId1)
                 && (supplierCheckResult1.UpdAssemblyId2 == supplierCheckResult2.UpdAssemblyId2)
                 && (supplierCheckResult1.LogicalDeleteCode == supplierCheckResult2.LogicalDeleteCode)
                 && (supplierCheckResult1.SectionCode == supplierCheckResult2.SectionCode)
                 && (supplierCheckResult1.StockCheckDivCAddUp == supplierCheckResult2.StockCheckDivCAddUp)
                 && (supplierCheckResult1.StockCheckDivDaily == supplierCheckResult2.StockCheckDivDaily)
                 && (supplierCheckResult1.StockDate == supplierCheckResult2.StockDate)
                 && (supplierCheckResult1.InputDay == supplierCheckResult2.InputDay)
                 && (supplierCheckResult1.SupplierSlipNo == supplierCheckResult2.SupplierSlipNo)
                 && (supplierCheckResult1.PartySaleSlipNum == supplierCheckResult2.PartySaleSlipNum)
                 && (supplierCheckResult1.StockPriceTaxInc == supplierCheckResult2.StockPriceTaxInc)
                 && (supplierCheckResult1.StockPriceTaxExc == supplierCheckResult2.StockPriceTaxExc)
                 && (supplierCheckResult1.StockPriceConsTax == supplierCheckResult2.StockPriceConsTax)
                 && (supplierCheckResult1.GoodsNo == supplierCheckResult2.GoodsNo)
                 && (supplierCheckResult1.StockCount == supplierCheckResult2.StockCount)
                 && (supplierCheckResult1.BLGoodsCode == supplierCheckResult2.BLGoodsCode)
                 && (supplierCheckResult1.GoodsName == supplierCheckResult2.GoodsName)
                 && (supplierCheckResult1.StockUnitPriceFl == supplierCheckResult2.StockUnitPriceFl)
                 && (supplierCheckResult1.ListPriceTaxExcFl == supplierCheckResult2.ListPriceTaxExcFl)
                 && (supplierCheckResult1.SalesUnPrcTaxExcFl == supplierCheckResult2.SalesUnPrcTaxExcFl)
                 && (supplierCheckResult1.SalesMoneyTaxExc == supplierCheckResult2.SalesMoneyTaxExc)
                 && (supplierCheckResult1.SalesDate == supplierCheckResult2.SalesDate)
                 && (supplierCheckResult1.SalesSlipNum == supplierCheckResult2.SalesSlipNum)
                 && (supplierCheckResult1.CustomerCode == supplierCheckResult2.CustomerCode)
                 && (supplierCheckResult1.CustomerSnm == supplierCheckResult2.CustomerSnm)
                 && (supplierCheckResult1.SalesEmployeeNm == supplierCheckResult2.SalesEmployeeNm)
                 && (supplierCheckResult1.FrontEmployeeNm == supplierCheckResult2.FrontEmployeeNm)
                 && (supplierCheckResult1.SalesInputName == supplierCheckResult2.SalesInputName)
                 && (supplierCheckResult1.UoeRemark1 == supplierCheckResult2.UoeRemark1)
                 && (supplierCheckResult1.UoeRemark2 == supplierCheckResult2.UoeRemark2)
                 && (supplierCheckResult1.SupplierCd == supplierCheckResult2.SupplierCd)
                 && (supplierCheckResult1.SupplierSnm == supplierCheckResult2.SupplierSnm)
                 && (supplierCheckResult1.SupplierFormal == supplierCheckResult2.SupplierFormal)
                 && (supplierCheckResult1.StockSlipDtlNum == supplierCheckResult2.StockSlipDtlNum)
                 && (supplierCheckResult1.BfStockUnitPriceFl == supplierCheckResult2.BfStockUnitPriceFl)
                 && (supplierCheckResult1.SupplierSlipCd == supplierCheckResult2.SupplierSlipCd)
                 && (supplierCheckResult1.StockGoodsCd == supplierCheckResult2.StockGoodsCd)
                 && (supplierCheckResult1.EnterpriseName == supplierCheckResult2.EnterpriseName)
                 && (supplierCheckResult1.UpdEmployeeName == supplierCheckResult2.UpdEmployeeName)
                 && (supplierCheckResult1.BLGoodsName == supplierCheckResult2.BLGoodsName));
        }
        /// <summary>
        /// �d���`�F�b�N�������o���ʃN���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�SupplierCheckResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierCheckResult�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(SupplierCheckResult target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.StockCheckDivCAddUp != target.StockCheckDivCAddUp) resList.Add("StockCheckDivCAddUp");
            if (this.StockCheckDivDaily != target.StockCheckDivDaily) resList.Add("StockCheckDivDaily");
            if (this.StockDate != target.StockDate) resList.Add("StockDate");
            if (this.InputDay != target.InputDay) resList.Add("InputDay");
            if (this.SupplierSlipNo != target.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (this.PartySaleSlipNum != target.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (this.StockPriceTaxInc != target.StockPriceTaxInc) resList.Add("StockPriceTaxInc");
            if (this.StockPriceTaxExc != target.StockPriceTaxExc) resList.Add("StockPriceTaxExc");
            if (this.StockPriceConsTax != target.StockPriceConsTax) resList.Add("StockPriceConsTax");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.StockCount != target.StockCount) resList.Add("StockCount");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.StockUnitPriceFl != target.StockUnitPriceFl) resList.Add("StockUnitPriceFl");
            if (this.ListPriceTaxExcFl != target.ListPriceTaxExcFl) resList.Add("ListPriceTaxExcFl");
            if (this.SalesUnPrcTaxExcFl != target.SalesUnPrcTaxExcFl) resList.Add("SalesUnPrcTaxExcFl");
            if (this.SalesMoneyTaxExc != target.SalesMoneyTaxExc) resList.Add("SalesMoneyTaxExc");
            if (this.SalesDate != target.SalesDate) resList.Add("SalesDate");
            if (this.SalesSlipNum != target.SalesSlipNum) resList.Add("SalesSlipNum");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.SalesEmployeeNm != target.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (this.FrontEmployeeNm != target.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
            if (this.SalesInputName != target.SalesInputName) resList.Add("SalesInputName");
            if (this.UoeRemark1 != target.UoeRemark1) resList.Add("UoeRemark1");
            if (this.UoeRemark2 != target.UoeRemark2) resList.Add("UoeRemark2");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.SupplierSnm != target.SupplierSnm) resList.Add("SupplierSnm");
            if (this.SupplierFormal != target.SupplierFormal) resList.Add("SupplierFormal");
            if (this.StockSlipDtlNum != target.StockSlipDtlNum) resList.Add("StockSlipDtlNum");
            if (this.BfStockUnitPriceFl != target.BfStockUnitPriceFl) resList.Add("BfStockUnitPriceFl");
            if (this.SupplierSlipCd != target.SupplierSlipCd) resList.Add("SupplierSlipCd");
            if (this.StockGoodsCd != target.StockGoodsCd) resList.Add("StockGoodsCd");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.BLGoodsName != target.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }

        /// <summary>
        /// �d���`�F�b�N�������o���ʃN���X��r����
        /// </summary>
        /// <param name="supplierCheckResult1">��r����SupplierCheckResult�N���X�̃C���X�^���X</param>
        /// <param name="supplierCheckResult2">��r����SupplierCheckResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierCheckResult�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(SupplierCheckResult supplierCheckResult1, SupplierCheckResult supplierCheckResult2)
        {
            ArrayList resList = new ArrayList();
            if (supplierCheckResult1.CreateDateTime != supplierCheckResult2.CreateDateTime) resList.Add("CreateDateTime");
            if (supplierCheckResult1.UpdateDateTime != supplierCheckResult2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (supplierCheckResult1.EnterpriseCode != supplierCheckResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (supplierCheckResult1.FileHeaderGuid != supplierCheckResult2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (supplierCheckResult1.UpdEmployeeCode != supplierCheckResult2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (supplierCheckResult1.UpdAssemblyId1 != supplierCheckResult2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (supplierCheckResult1.UpdAssemblyId2 != supplierCheckResult2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (supplierCheckResult1.LogicalDeleteCode != supplierCheckResult2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (supplierCheckResult1.SectionCode != supplierCheckResult2.SectionCode) resList.Add("SectionCode");
            if (supplierCheckResult1.StockCheckDivCAddUp != supplierCheckResult2.StockCheckDivCAddUp) resList.Add("StockCheckDivCAddUp");
            if (supplierCheckResult1.StockCheckDivDaily != supplierCheckResult2.StockCheckDivDaily) resList.Add("StockCheckDivDaily");
            if (supplierCheckResult1.StockDate != supplierCheckResult2.StockDate) resList.Add("StockDate");
            if (supplierCheckResult1.InputDay != supplierCheckResult2.InputDay) resList.Add("InputDay");
            if (supplierCheckResult1.SupplierSlipNo != supplierCheckResult2.SupplierSlipNo) resList.Add("SupplierSlipNo");
            if (supplierCheckResult1.PartySaleSlipNum != supplierCheckResult2.PartySaleSlipNum) resList.Add("PartySaleSlipNum");
            if (supplierCheckResult1.StockPriceTaxInc != supplierCheckResult2.StockPriceTaxInc) resList.Add("StockPriceTaxInc");
            if (supplierCheckResult1.StockPriceTaxExc != supplierCheckResult2.StockPriceTaxExc) resList.Add("StockPriceTaxExc");
            if (supplierCheckResult1.StockPriceConsTax != supplierCheckResult2.StockPriceConsTax) resList.Add("StockPriceConsTax");
            if (supplierCheckResult1.GoodsNo != supplierCheckResult2.GoodsNo) resList.Add("GoodsNo");
            if (supplierCheckResult1.StockCount != supplierCheckResult2.StockCount) resList.Add("StockCount");
            if (supplierCheckResult1.BLGoodsCode != supplierCheckResult2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (supplierCheckResult1.GoodsName != supplierCheckResult2.GoodsName) resList.Add("GoodsName");
            if (supplierCheckResult1.StockUnitPriceFl != supplierCheckResult2.StockUnitPriceFl) resList.Add("StockUnitPriceFl");
            if (supplierCheckResult1.ListPriceTaxExcFl != supplierCheckResult2.ListPriceTaxExcFl) resList.Add("ListPriceTaxExcFl");
            if (supplierCheckResult1.SalesUnPrcTaxExcFl != supplierCheckResult2.SalesUnPrcTaxExcFl) resList.Add("SalesUnPrcTaxExcFl");
            if (supplierCheckResult1.SalesMoneyTaxExc != supplierCheckResult2.SalesMoneyTaxExc) resList.Add("SalesMoneyTaxExc");
            if (supplierCheckResult1.SalesDate != supplierCheckResult2.SalesDate) resList.Add("SalesDate");
            if (supplierCheckResult1.SalesSlipNum != supplierCheckResult2.SalesSlipNum) resList.Add("SalesSlipNum");
            if (supplierCheckResult1.CustomerCode != supplierCheckResult2.CustomerCode) resList.Add("CustomerCode");
            if (supplierCheckResult1.CustomerSnm != supplierCheckResult2.CustomerSnm) resList.Add("CustomerSnm");
            if (supplierCheckResult1.SalesEmployeeNm != supplierCheckResult2.SalesEmployeeNm) resList.Add("SalesEmployeeNm");
            if (supplierCheckResult1.FrontEmployeeNm != supplierCheckResult2.FrontEmployeeNm) resList.Add("FrontEmployeeNm");
            if (supplierCheckResult1.SalesInputName != supplierCheckResult2.SalesInputName) resList.Add("SalesInputName");
            if (supplierCheckResult1.UoeRemark1 != supplierCheckResult2.UoeRemark1) resList.Add("UoeRemark1");
            if (supplierCheckResult1.UoeRemark2 != supplierCheckResult2.UoeRemark2) resList.Add("UoeRemark2");
            if (supplierCheckResult1.SupplierCd != supplierCheckResult2.SupplierCd) resList.Add("SupplierCd");
            if (supplierCheckResult1.SupplierSnm != supplierCheckResult2.SupplierSnm) resList.Add("SupplierSnm");
            if (supplierCheckResult1.SupplierFormal != supplierCheckResult2.SupplierFormal) resList.Add("SupplierFormal");
            if (supplierCheckResult1.StockSlipDtlNum != supplierCheckResult2.StockSlipDtlNum) resList.Add("StockSlipDtlNum");
            if (supplierCheckResult1.BfStockUnitPriceFl != supplierCheckResult2.BfStockUnitPriceFl) resList.Add("BfStockUnitPriceFl");
            if (supplierCheckResult1.SupplierSlipCd != supplierCheckResult2.SupplierSlipCd) resList.Add("SupplierSlipCd");
            if (supplierCheckResult1.StockGoodsCd != supplierCheckResult2.StockGoodsCd) resList.Add("StockGoodsCd");
            if (supplierCheckResult1.EnterpriseName != supplierCheckResult2.EnterpriseName) resList.Add("EnterpriseName");
            if (supplierCheckResult1.UpdEmployeeName != supplierCheckResult2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (supplierCheckResult1.BLGoodsName != supplierCheckResult2.BLGoodsName) resList.Add("BLGoodsName");

            return resList;
        }
    }
}
