// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki
/*
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockMoveExp
    /// <summary>
    ///                      �݌Ɉړ��ڍ׃f�[�^
    /// </summary>
    /// <remarks>
    /// note             :   �݌Ɉړ��ڍ׃f�[�^�w�b�_�t�@�C��<br />
    /// Programmer       :   ��������<br />
    /// Date             :   <br />
    /// Genarated Date   :   2007/02/05  (CSharp File Generated Date)<br />
    /// Update Note      :   <br />
    /// </remarks>
    public class StockMoveExp
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

        /// <summary>�݌Ɉړ��`��</summary>
        /// <remarks>1:���_�Ԉړ��A2�F�q�Ɉړ�</remarks>
        private Int32 _stockMoveFormal;

        /// <summary>�݌Ɉړ��`�[�ԍ�</summary>
        private Int32 _stockMoveSlipNo;

        /// <summary>�݌Ɉړ��s�ԍ�</summary>
        private Int32 _stockMoveRowNo;

        /// <summary>�݌Ɉړ��s�ڍהԍ�</summary>
        private Int32 _stockMoveExpNum;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�ړ������_�R�[�h</summary>
        private string _bfSectionCode = "";

        /// <summary>�ړ������_�K�C�h����</summary>
        private string _bfSectionGuideNm = "";

        /// <summary>�ړ����q�ɃR�[�h</summary>
        private string _bfEnterWarehCode = "";

        /// <summary>�ړ����q�ɖ���</summary>
        private string _bfEnterWarehName = "";

        /// <summary>�ړ��拒�_�R�[�h</summary>
        private string _afSectionCode = "";

        /// <summary>�ړ��拒�_�K�C�h����</summary>
        private string _afSectionGuideNm = "";

        /// <summary>�ړ���q�ɃR�[�h</summary>
        private string _afEnterWarehCode = "";

        /// <summary>�ړ���q�ɖ���</summary>
        private string _afEnterWarehName = "";

        /// <summary>���Ǝ҃R�[�h</summary>
        private Int32 _carrierEpCode;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>���[�J�[�R�[�h</summary>
        /// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _makerCode;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>���i�R�[�h</summary>
        private string _goodsCode = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>�����ԍ�</summary>
        /// <remarks>���u���ԂȂ��v�̏ꍇ�Anull</remarks>
        private string _productNumber = "";

        /// <summary>���ԍ݌Ƀ}�X�^GUID</summary>
        private Guid _productStockGuid;

        /// <summary>�݌ɋ敪</summary>
        /// <remarks>0:���ЁA1:���</remarks>
        private Int32 _stockDiv;

        /// <summary>�d���P��</summary>
        /// <remarks>�݌Ɉړ�����݌ɂ̎d�����i�����Z�b�g</remarks>
        private Int64 _stockUnitPrice;

        /// <summary>�d�����z</summary>
        /// <remarks>�@�V</remarks>
        private Int64 _stockPrice;

        /// <summary>�d�����z����Ŋz</summary>
        /// <remarks>�@�V</remarks>
        private Int64 _stockPriceConsTax;

        /// <summary>�d���O�őΏۊz</summary>
        /// <remarks>�@�V</remarks>
        private Int64 _itdedStckOutTax;

        /// <summary>�d�����őΏۊz</summary>
        /// <remarks>�@�V</remarks>
        private Int64 _itdedStckInTax;

        /// <summary>�d����ېőΏۊz</summary>
        /// <remarks>�@�V</remarks>
        private Int64 _itdedStckTaxFree;

        /// <summary>�d���O�Ŋz</summary>
        /// <remarks>�@�V</remarks>
        private Int64 _stckOuterTax;

        /// <summary>�d�����Ŋz</summary>
        /// <remarks>�@�V</remarks>
        private Int64 _stckInnerTax;

        /// <summary>�ېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _taxationCode;

        /// <summary>���i�d�b�ԍ�1</summary>
        private string _stockTelNo1 = "";

        /// <summary>���i�d�b�ԍ�2</summary>
        private string _stockTelNo2 = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>���ƎҖ���</summary>
        private string _carrierEpName = "";


        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �쐬�����v���p�e�B<br />
        /// Programer        :   ��������<br />
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
        /// note             :   �쐬���� �a��v���p�e�B<br />
        /// Programer        :   ��������<br />
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
        /// note             :   �쐬���� �a��(��)�v���p�e�B<br />
        /// Programer        :   ��������<br />
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
        /// note             :   �쐬���� ����v���p�e�B<br />
        /// Programer        :   ��������<br />
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
        /// note             :   �쐬���� ����(��)�v���p�e�B<br />
        /// Programer        :   ��������<br />
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
        /// note             :   �X�V�����v���p�e�B<br />
        /// Programer        :   ��������<br />
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
        /// note             :   �X�V���� �a��v���p�e�B<br />
        /// Programer        :   ��������<br />
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
        /// note             :   �X�V���� �a��(��)�v���p�e�B<br />
        /// Programer        :   ��������<br />
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
        /// note             :   �X�V���� ����v���p�e�B<br />
        /// Programer        :   ��������<br />
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
        /// note             :   �X�V���� ����(��)�v���p�e�B<br />
        /// Programer        :   ��������<br />
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
        /// note             :   ��ƃR�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
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
        /// note             :   GUID�v���p�e�B<br />
        /// Programer        :   ��������<br />
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
        /// note             :   �X�V�]�ƈ��R�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
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
        /// note             :   �X�V�A�Z���u��ID1�v���p�e�B<br />
        /// Programer        :   ��������<br />
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
        /// note             :   �X�V�A�Z���u��ID2�v���p�e�B<br />
        /// Programer        :   ��������<br />
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
        /// note             :   �_���폜�敪�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  StockMoveFormal
        /// <summary>�݌Ɉړ��`���v���p�e�B</summary>
        /// <value>1:���_�Ԉړ��A2�F�q�Ɉړ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �݌Ɉړ��`���v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int32 StockMoveFormal
        {
            get { return _stockMoveFormal; }
            set { _stockMoveFormal = value; }
        }

        /// public propaty name  :  StockMoveSlipNo
        /// <summary>�݌Ɉړ��`�[�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �݌Ɉړ��`�[�ԍ��v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int32 StockMoveSlipNo
        {
            get { return _stockMoveSlipNo; }
            set { _stockMoveSlipNo = value; }
        }

        /// public propaty name  :  StockMoveRowNo
        /// <summary>�݌Ɉړ��s�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �݌Ɉړ��s�ԍ��v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int32 StockMoveRowNo
        {
            get { return _stockMoveRowNo; }
            set { _stockMoveRowNo = value; }
        }

        /// public propaty name  :  StockMoveExpNum
        /// <summary>�݌Ɉړ��s�ڍהԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �݌Ɉړ��s�ڍהԍ��v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int32 StockMoveExpNum
        {
            get { return _stockMoveExpNum; }
            set { _stockMoveExpNum = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ���_�R�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  BfSectionCode
        /// <summary>�ړ������_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ������_�R�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// public propaty name  :  BfSectionGuideNm
        /// <summary>�ړ������_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ������_�K�C�h���̃v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string BfSectionGuideNm
        {
            get { return _bfSectionGuideNm; }
            set { _bfSectionGuideNm = value; }
        }

        /// public propaty name  :  BfEnterWarehCode
        /// <summary>�ړ����q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ����q�ɃR�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string BfEnterWarehCode
        {
            get { return _bfEnterWarehCode; }
            set { _bfEnterWarehCode = value; }
        }

        /// public propaty name  :  BfEnterWarehName
        /// <summary>�ړ����q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ����q�ɖ��̃v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string BfEnterWarehName
        {
            get { return _bfEnterWarehName; }
            set { _bfEnterWarehName = value; }
        }

        /// public propaty name  :  AfSectionCode
        /// <summary>�ړ��拒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ��拒�_�R�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// public propaty name  :  AfSectionGuideNm
        /// <summary>�ړ��拒�_�K�C�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ��拒�_�K�C�h���̃v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string AfSectionGuideNm
        {
            get { return _afSectionGuideNm; }
            set { _afSectionGuideNm = value; }
        }

        /// public propaty name  :  AfEnterWarehCode
        /// <summary>�ړ���q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ���q�ɃR�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string AfEnterWarehCode
        {
            get { return _afEnterWarehCode; }
            set { _afEnterWarehCode = value; }
        }

        /// public propaty name  :  AfEnterWarehName
        /// <summary>�ړ���q�ɖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ړ���q�ɖ��̃v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string AfEnterWarehName
        {
            get { return _afEnterWarehName; }
            set { _afEnterWarehName = value; }
        }

        /// public propaty name  :  CarrierEpCode
        /// <summary>���Ǝ҃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ���Ǝ҃R�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int32 CarrierEpCode
        {
            get { return _carrierEpCode; }
            set { _carrierEpCode = value; }
        }

        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ���Ӑ�R�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  MakerCode
        /// <summary>���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ���[�J�[�R�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int32 MakerCode
        {
            get { return _makerCode; }
            set { _makerCode = value; }
        }

        /// public propaty name  :  MakerName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ���[�J�[���̃v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
        }

        /// public propaty name  :  GoodsCode
        /// <summary>���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ���i�R�[�h�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string GoodsCode
        {
            get { return _goodsCode; }
            set { _goodsCode = value; }
        }

        /// public propaty name  :  GoodsName
        /// <summary>���i���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ���i���̃v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  ProductNumber
        /// <summary>�����ԍ��v���p�e�B</summary>
        /// <value>���u���ԂȂ��v�̏ꍇ�Anull</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �����ԍ��v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string ProductNumber
        {
            get { return _productNumber; }
            set { _productNumber = value; }
        }

        /// public propaty name  :  ProductStockGuid
        /// <summary>���ԍ݌Ƀ}�X�^GUID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ���ԍ݌Ƀ}�X�^GUID�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Guid ProductStockGuid
        {
            get { return _productStockGuid; }
            set { _productStockGuid = value; }
        }

        /// public propaty name  :  StockDiv
        /// <summary>�݌ɋ敪�v���p�e�B</summary>
        /// <value>0:���ЁA1:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �݌ɋ敪�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int32 StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
        }

        /// public propaty name  :  StockUnitPrice
        /// <summary>�d���P���v���p�e�B</summary>
        /// <value>�݌Ɉړ�����݌ɂ̎d�����i�����Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �d���P���v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int64 StockUnitPrice
        {
            get { return _stockUnitPrice; }
            set { _stockUnitPrice = value; }
        }

        /// public propaty name  :  StockPrice
        /// <summary>�d�����z�v���p�e�B</summary>
        /// <value>�@�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �d�����z�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int64 StockPrice
        {
            get { return _stockPrice; }
            set { _stockPrice = value; }
        }

        /// public propaty name  :  StockPriceConsTax
        /// <summary>�d�����z����Ŋz�v���p�e�B</summary>
        /// <value>�@�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �d�����z����Ŋz�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int64 StockPriceConsTax
        {
            get { return _stockPriceConsTax; }
            set { _stockPriceConsTax = value; }
        }

        /// public propaty name  :  ItdedStckOutTax
        /// <summary>�d���O�őΏۊz�v���p�e�B</summary>
        /// <value>�@�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �d���O�őΏۊz�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int64 ItdedStckOutTax
        {
            get { return _itdedStckOutTax; }
            set { _itdedStckOutTax = value; }
        }

        /// public propaty name  :  ItdedStckInTax
        /// <summary>�d�����őΏۊz�v���p�e�B</summary>
        /// <value>�@�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �d�����őΏۊz�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int64 ItdedStckInTax
        {
            get { return _itdedStckInTax; }
            set { _itdedStckInTax = value; }
        }

        /// public propaty name  :  ItdedStckTaxFree
        /// <summary>�d����ېőΏۊz�v���p�e�B</summary>
        /// <value>�@�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �d����ېőΏۊz�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int64 ItdedStckTaxFree
        {
            get { return _itdedStckTaxFree; }
            set { _itdedStckTaxFree = value; }
        }

        /// public propaty name  :  StckOuterTax
        /// <summary>�d���O�Ŋz�v���p�e�B</summary>
        /// <value>�@�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �d���O�Ŋz�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int64 StckOuterTax
        {
            get { return _stckOuterTax; }
            set { _stckOuterTax = value; }
        }

        /// public propaty name  :  StckInnerTax
        /// <summary>�d�����Ŋz�v���p�e�B</summary>
        /// <value>�@�V</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �d�����Ŋz�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int64 StckInnerTax
        {
            get { return _stckInnerTax; }
            set { _stckInnerTax = value; }
        }

        /// public propaty name  :  TaxationCode
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   �ېŋ敪�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public Int32 TaxationCode
        {
            get { return _taxationCode; }
            set { _taxationCode = value; }
        }

        /// public propaty name  :  StockTelNo1
        /// <summary>���i�d�b�ԍ�1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ���i�d�b�ԍ�1�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string StockTelNo1
        {
            get { return _stockTelNo1; }
            set { _stockTelNo1 = value; }
        }

        /// public propaty name  :  StockTelNo2
        /// <summary>���i�d�b�ԍ�2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ���i�d�b�ԍ�2�v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string StockTelNo2
        {
            get { return _stockTelNo2; }
            set { _stockTelNo2 = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ��Ɩ��̃v���p�e�B<br />
        /// Programer        :   ��������<br />
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
        /// note             :   �X�V�]�ƈ����̃v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string UpdEmployeeName
        {
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
        }

        /// public propaty name  :  CarrierEpName
        /// <summary>���ƎҖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// note             :   ���ƎҖ��̃v���p�e�B<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public string CarrierEpName
        {
            get { return _carrierEpName; }
            set { _carrierEpName = value; }
        }


        /// <summary>
        /// �݌Ɉړ��ڍ׃f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>StockMoveExp�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   StockMoveExp�N���X�̐V�����C���X�^���X�𐶐����܂�<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public StockMoveExp()
        {
        }

        /// <summary>
        /// �݌Ɉړ��ڍ׃f�[�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="stockMoveFormal">�݌Ɉړ��`��(1:���_�Ԉړ��A2�F�q�Ɉړ�)</param>
        /// <param name="stockMoveSlipNo">�݌Ɉړ��`�[�ԍ�</param>
        /// <param name="stockMoveRowNo">�݌Ɉړ��s�ԍ�</param>
        /// <param name="stockMoveExpNum">�݌Ɉړ��s�ڍהԍ�</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="bfSectionCode">�ړ������_�R�[�h</param>
        /// <param name="bfSectionGuideNm">�ړ������_�K�C�h����</param>
        /// <param name="bfEnterWarehCode">�ړ����q�ɃR�[�h</param>
        /// <param name="bfEnterWarehName">�ړ����q�ɖ���</param>
        /// <param name="afSectionCode">�ړ��拒�_�R�[�h</param>
        /// <param name="afSectionGuideNm">�ړ��拒�_�K�C�h����</param>
        /// <param name="afEnterWarehCode">�ړ���q�ɃR�[�h</param>
        /// <param name="afEnterWarehName">�ړ���q�ɖ���</param>
        /// <param name="carrierEpCode">���Ǝ҃R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="makerCode">���[�J�[�R�[�h(1�`899:�񋟕�, 900�`���[�U�[�o�^)</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <param name="goodsCode">���i�R�[�h</param>
        /// <param name="goodsName">���i����</param>
        /// <param name="productNumber">�����ԍ�(���u���ԂȂ��v�̏ꍇ�Anull)</param>
        /// <param name="productStockGuid">���ԍ݌Ƀ}�X�^GUID</param>
        /// <param name="stockDiv">�݌ɋ敪(0:���ЁA1:���)</param>
        /// <param name="stockUnitPrice">�d���P��(�݌Ɉړ�����݌ɂ̎d�����i�����Z�b�g)</param>
        /// <param name="stockPrice">�d�����z(�@�V)</param>
        /// <param name="stockPriceConsTax">�d�����z����Ŋz(�@�V)</param>
        /// <param name="itdedStckOutTax">�d���O�őΏۊz(�@�V)</param>
        /// <param name="itdedStckInTax">�d�����őΏۊz(�@�V)</param>
        /// <param name="itdedStckTaxFree">�d����ېőΏۊz(�@�V)</param>
        /// <param name="stckOuterTax">�d���O�Ŋz(�@�V)</param>
        /// <param name="stckInnerTax">�d�����Ŋz(�@�V)</param>
        /// <param name="taxationCode">�ېŋ敪(0:�ې�,1:��ې�,2:�ېŁi���Łj)</param>
        /// <param name="stockTelNo1">���i�d�b�ԍ�1</param>
        /// <param name="stockTelNo2">���i�d�b�ԍ�2</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <param name="carrierEpName">���ƎҖ���</param>
        /// <returns>StockMoveExp�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   StockMoveExp�N���X�̐V�����C���X�^���X�𐶐����܂�<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public StockMoveExp(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 stockMoveFormal, Int32 stockMoveSlipNo, Int32 stockMoveRowNo, Int32 stockMoveExpNum, string sectionCode, string bfSectionCode, string bfSectionGuideNm, string bfEnterWarehCode, string bfEnterWarehName, string afSectionCode, string afSectionGuideNm, string afEnterWarehCode, string afEnterWarehName, Int32 carrierEpCode, Int32 customerCode, Int32 makerCode, string makerName, string goodsCode, string goodsName, string productNumber, Guid productStockGuid, Int32 stockDiv, Int64 stockUnitPrice, Int64 stockPrice, Int64 stockPriceConsTax, Int64 itdedStckOutTax, Int64 itdedStckInTax, Int64 itdedStckTaxFree, Int64 stckOuterTax, Int64 stckInnerTax, Int32 taxationCode, string stockTelNo1, string stockTelNo2, string enterpriseName, string updEmployeeName, string carrierEpName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._stockMoveFormal = stockMoveFormal;
            this._stockMoveSlipNo = stockMoveSlipNo;
            this._stockMoveRowNo = stockMoveRowNo;
            this._stockMoveExpNum = stockMoveExpNum;
            this._sectionCode = sectionCode;
            this._bfSectionCode = bfSectionCode;
            this._bfSectionGuideNm = bfSectionGuideNm;
            this._bfEnterWarehCode = bfEnterWarehCode;
            this._bfEnterWarehName = bfEnterWarehName;
            this._afSectionCode = afSectionCode;
            this._afSectionGuideNm = afSectionGuideNm;
            this._afEnterWarehCode = afEnterWarehCode;
            this._afEnterWarehName = afEnterWarehName;
            this._carrierEpCode = carrierEpCode;
            this._customerCode = customerCode;
            this._makerCode = makerCode;
            this._makerName = makerName;
            this._goodsCode = goodsCode;
            this._goodsName = goodsName;
            this._productNumber = productNumber;
            this._productStockGuid = productStockGuid;
            this._stockDiv = stockDiv;
            this._stockUnitPrice = stockUnitPrice;
            this._stockPrice = stockPrice;
            this._stockPriceConsTax = stockPriceConsTax;
            this._itdedStckOutTax = itdedStckOutTax;
            this._itdedStckInTax = itdedStckInTax;
            this._itdedStckTaxFree = itdedStckTaxFree;
            this._stckOuterTax = stckOuterTax;
            this._stckInnerTax = stckInnerTax;
            this._taxationCode = taxationCode;
            this._stockTelNo1 = stockTelNo1;
            this._stockTelNo2 = stockTelNo2;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._carrierEpName = carrierEpName;

        }

        /// <summary>
        /// �݌Ɉړ��ڍ׃f�[�^��������
        /// </summary>
        /// <returns>StockMoveExp�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����StockMoveExp�N���X�̃C���X�^���X��Ԃ��܂�<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public StockMoveExp Clone()
        {
            return new StockMoveExp(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._stockMoveFormal, this._stockMoveSlipNo, this._stockMoveRowNo, this._stockMoveExpNum, this._sectionCode, this._bfSectionCode, this._bfSectionGuideNm, this._bfEnterWarehCode, this._bfEnterWarehName, this._afSectionCode, this._afSectionGuideNm, this._afEnterWarehCode, this._afEnterWarehName, this._carrierEpCode, this._customerCode, this._makerCode, this._makerName, this._goodsCode, this._goodsName, this._productNumber, this._productStockGuid, this._stockDiv, this._stockUnitPrice, this._stockPrice, this._stockPriceConsTax, this._itdedStckOutTax, this._itdedStckInTax, this._itdedStckTaxFree, this._stckOuterTax, this._stckInnerTax, this._taxationCode, this._stockTelNo1, this._stockTelNo2, this._enterpriseName, this._updEmployeeName, this._carrierEpName);
        }

        /// <summary>
        /// �݌Ɉړ��ڍ׃f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockMoveExp�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   StockMoveExp�N���X�̓��e����v���邩��r���܂�<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public bool Equals(StockMoveExp target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.StockMoveFormal == target.StockMoveFormal)
                 && (this.StockMoveSlipNo == target.StockMoveSlipNo)
                 && (this.StockMoveRowNo == target.StockMoveRowNo)
                 && (this.StockMoveExpNum == target.StockMoveExpNum)
                 && (this.SectionCode == target.SectionCode)
                 && (this.BfSectionCode == target.BfSectionCode)
                 && (this.BfSectionGuideNm == target.BfSectionGuideNm)
                 && (this.BfEnterWarehCode == target.BfEnterWarehCode)
                 && (this.BfEnterWarehName == target.BfEnterWarehName)
                 && (this.AfSectionCode == target.AfSectionCode)
                 && (this.AfSectionGuideNm == target.AfSectionGuideNm)
                 && (this.AfEnterWarehCode == target.AfEnterWarehCode)
                 && (this.AfEnterWarehName == target.AfEnterWarehName)
                 && (this.CarrierEpCode == target.CarrierEpCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.MakerCode == target.MakerCode)
                 && (this.MakerName == target.MakerName)
                 && (this.GoodsCode == target.GoodsCode)
                 && (this.GoodsName == target.GoodsName)
                 && (this.ProductNumber == target.ProductNumber)
                 && (this.ProductStockGuid == target.ProductStockGuid)
                 && (this.StockDiv == target.StockDiv)
                 && (this.StockUnitPrice == target.StockUnitPrice)
                 && (this.StockPrice == target.StockPrice)
                 && (this.StockPriceConsTax == target.StockPriceConsTax)
                 && (this.ItdedStckOutTax == target.ItdedStckOutTax)
                 && (this.ItdedStckInTax == target.ItdedStckInTax)
                 && (this.ItdedStckTaxFree == target.ItdedStckTaxFree)
                 && (this.StckOuterTax == target.StckOuterTax)
                 && (this.StckInnerTax == target.StckInnerTax)
                 && (this.TaxationCode == target.TaxationCode)
                 && (this.StockTelNo1 == target.StockTelNo1)
                 && (this.StockTelNo2 == target.StockTelNo2)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.CarrierEpName == target.CarrierEpName));
        }

        /// <summary>
        /// �݌Ɉړ��ڍ׃f�[�^��r����
        /// </summary>
        /// <param name="stockMoveExp1">
        ///                    ��r����StockMoveExp�N���X�̃C���X�^���X
        /// </param>
        /// <param name="stockMoveExp2">��r����StockMoveExp�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   StockMoveExp�N���X�̓��e����v���邩��r���܂�<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public static bool Equals(StockMoveExp stockMoveExp1, StockMoveExp stockMoveExp2)
        {
            return ((stockMoveExp1.CreateDateTime == stockMoveExp2.CreateDateTime)
                 && (stockMoveExp1.UpdateDateTime == stockMoveExp2.UpdateDateTime)
                 && (stockMoveExp1.EnterpriseCode == stockMoveExp2.EnterpriseCode)
                 && (stockMoveExp1.FileHeaderGuid == stockMoveExp2.FileHeaderGuid)
                 && (stockMoveExp1.UpdEmployeeCode == stockMoveExp2.UpdEmployeeCode)
                 && (stockMoveExp1.UpdAssemblyId1 == stockMoveExp2.UpdAssemblyId1)
                 && (stockMoveExp1.UpdAssemblyId2 == stockMoveExp2.UpdAssemblyId2)
                 && (stockMoveExp1.LogicalDeleteCode == stockMoveExp2.LogicalDeleteCode)
                 && (stockMoveExp1.StockMoveFormal == stockMoveExp2.StockMoveFormal)
                 && (stockMoveExp1.StockMoveSlipNo == stockMoveExp2.StockMoveSlipNo)
                 && (stockMoveExp1.StockMoveRowNo == stockMoveExp2.StockMoveRowNo)
                 && (stockMoveExp1.StockMoveExpNum == stockMoveExp2.StockMoveExpNum)
                 && (stockMoveExp1.SectionCode == stockMoveExp2.SectionCode)
                 && (stockMoveExp1.BfSectionCode == stockMoveExp2.BfSectionCode)
                 && (stockMoveExp1.BfSectionGuideNm == stockMoveExp2.BfSectionGuideNm)
                 && (stockMoveExp1.BfEnterWarehCode == stockMoveExp2.BfEnterWarehCode)
                 && (stockMoveExp1.BfEnterWarehName == stockMoveExp2.BfEnterWarehName)
                 && (stockMoveExp1.AfSectionCode == stockMoveExp2.AfSectionCode)
                 && (stockMoveExp1.AfSectionGuideNm == stockMoveExp2.AfSectionGuideNm)
                 && (stockMoveExp1.AfEnterWarehCode == stockMoveExp2.AfEnterWarehCode)
                 && (stockMoveExp1.AfEnterWarehName == stockMoveExp2.AfEnterWarehName)
                 && (stockMoveExp1.CarrierEpCode == stockMoveExp2.CarrierEpCode)
                 && (stockMoveExp1.CustomerCode == stockMoveExp2.CustomerCode)
                 && (stockMoveExp1.MakerCode == stockMoveExp2.MakerCode)
                 && (stockMoveExp1.MakerName == stockMoveExp2.MakerName)
                 && (stockMoveExp1.GoodsCode == stockMoveExp2.GoodsCode)
                 && (stockMoveExp1.GoodsName == stockMoveExp2.GoodsName)
                 && (stockMoveExp1.ProductNumber == stockMoveExp2.ProductNumber)
                 && (stockMoveExp1.ProductStockGuid == stockMoveExp2.ProductStockGuid)
                 && (stockMoveExp1.StockDiv == stockMoveExp2.StockDiv)
                 && (stockMoveExp1.StockUnitPrice == stockMoveExp2.StockUnitPrice)
                 && (stockMoveExp1.StockPrice == stockMoveExp2.StockPrice)
                 && (stockMoveExp1.StockPriceConsTax == stockMoveExp2.StockPriceConsTax)
                 && (stockMoveExp1.ItdedStckOutTax == stockMoveExp2.ItdedStckOutTax)
                 && (stockMoveExp1.ItdedStckInTax == stockMoveExp2.ItdedStckInTax)
                 && (stockMoveExp1.ItdedStckTaxFree == stockMoveExp2.ItdedStckTaxFree)
                 && (stockMoveExp1.StckOuterTax == stockMoveExp2.StckOuterTax)
                 && (stockMoveExp1.StckInnerTax == stockMoveExp2.StckInnerTax)
                 && (stockMoveExp1.TaxationCode == stockMoveExp2.TaxationCode)
                 && (stockMoveExp1.StockTelNo1 == stockMoveExp2.StockTelNo1)
                 && (stockMoveExp1.StockTelNo2 == stockMoveExp2.StockTelNo2)
                 && (stockMoveExp1.EnterpriseName == stockMoveExp2.EnterpriseName)
                 && (stockMoveExp1.UpdEmployeeName == stockMoveExp2.UpdEmployeeName)
                 && (stockMoveExp1.CarrierEpName == stockMoveExp2.CarrierEpName));
        }
        /// <summary>
        /// �݌Ɉړ��ڍ׃f�[�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�StockMoveExp�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   StockMoveExp�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public ArrayList Compare(StockMoveExp target)
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
            if (this.StockMoveFormal != target.StockMoveFormal) resList.Add("StockMoveFormal");
            if (this.StockMoveSlipNo != target.StockMoveSlipNo) resList.Add("StockMoveSlipNo");
            if (this.StockMoveRowNo != target.StockMoveRowNo) resList.Add("StockMoveRowNo");
            if (this.StockMoveExpNum != target.StockMoveExpNum) resList.Add("StockMoveExpNum");
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.BfSectionCode != target.BfSectionCode) resList.Add("BfSectionCode");
            if (this.BfSectionGuideNm != target.BfSectionGuideNm) resList.Add("BfSectionGuideNm");
            if (this.BfEnterWarehCode != target.BfEnterWarehCode) resList.Add("BfEnterWarehCode");
            if (this.BfEnterWarehName != target.BfEnterWarehName) resList.Add("BfEnterWarehName");
            if (this.AfSectionCode != target.AfSectionCode) resList.Add("AfSectionCode");
            if (this.AfSectionGuideNm != target.AfSectionGuideNm) resList.Add("AfSectionGuideNm");
            if (this.AfEnterWarehCode != target.AfEnterWarehCode) resList.Add("AfEnterWarehCode");
            if (this.AfEnterWarehName != target.AfEnterWarehName) resList.Add("AfEnterWarehName");
            if (this.CarrierEpCode != target.CarrierEpCode) resList.Add("CarrierEpCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.MakerCode != target.MakerCode) resList.Add("MakerCode");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GoodsCode != target.GoodsCode) resList.Add("GoodsCode");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.ProductNumber != target.ProductNumber) resList.Add("ProductNumber");
            if (this.ProductStockGuid != target.ProductStockGuid) resList.Add("ProductStockGuid");
            if (this.StockDiv != target.StockDiv) resList.Add("StockDiv");
            if (this.StockUnitPrice != target.StockUnitPrice) resList.Add("StockUnitPrice");
            if (this.StockPrice != target.StockPrice) resList.Add("StockPrice");
            if (this.StockPriceConsTax != target.StockPriceConsTax) resList.Add("StockPriceConsTax");
            if (this.ItdedStckOutTax != target.ItdedStckOutTax) resList.Add("ItdedStckOutTax");
            if (this.ItdedStckInTax != target.ItdedStckInTax) resList.Add("ItdedStckInTax");
            if (this.ItdedStckTaxFree != target.ItdedStckTaxFree) resList.Add("ItdedStckTaxFree");
            if (this.StckOuterTax != target.StckOuterTax) resList.Add("StckOuterTax");
            if (this.StckInnerTax != target.StckInnerTax) resList.Add("StckInnerTax");
            if (this.TaxationCode != target.TaxationCode) resList.Add("TaxationCode");
            if (this.StockTelNo1 != target.StockTelNo1) resList.Add("StockTelNo1");
            if (this.StockTelNo2 != target.StockTelNo2) resList.Add("StockTelNo2");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.CarrierEpName != target.CarrierEpName) resList.Add("CarrierEpName");

            return resList;
        }

        /// <summary>
        /// �݌Ɉړ��ڍ׃f�[�^��r����
        /// </summary>
        /// <param name="stockMoveExp1">��r����StockMoveExp�N���X�̃C���X�^���X</param>
        /// <param name="stockMoveExp2">��r����StockMoveExp�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// Note�@�@�@�@�@�@ :   StockMoveExp�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�<br />
        /// Programer        :   ��������<br />
        /// </remarks>
        public static ArrayList Compare(StockMoveExp stockMoveExp1, StockMoveExp stockMoveExp2)
        {
            ArrayList resList = new ArrayList();
            if (stockMoveExp1.CreateDateTime != stockMoveExp2.CreateDateTime) resList.Add("CreateDateTime");
            if (stockMoveExp1.UpdateDateTime != stockMoveExp2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (stockMoveExp1.EnterpriseCode != stockMoveExp2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (stockMoveExp1.FileHeaderGuid != stockMoveExp2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (stockMoveExp1.UpdEmployeeCode != stockMoveExp2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (stockMoveExp1.UpdAssemblyId1 != stockMoveExp2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (stockMoveExp1.UpdAssemblyId2 != stockMoveExp2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (stockMoveExp1.LogicalDeleteCode != stockMoveExp2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (stockMoveExp1.StockMoveFormal != stockMoveExp2.StockMoveFormal) resList.Add("StockMoveFormal");
            if (stockMoveExp1.StockMoveSlipNo != stockMoveExp2.StockMoveSlipNo) resList.Add("StockMoveSlipNo");
            if (stockMoveExp1.StockMoveRowNo != stockMoveExp2.StockMoveRowNo) resList.Add("StockMoveRowNo");
            if (stockMoveExp1.StockMoveExpNum != stockMoveExp2.StockMoveExpNum) resList.Add("StockMoveExpNum");
            if (stockMoveExp1.SectionCode != stockMoveExp2.SectionCode) resList.Add("SectionCode");
            if (stockMoveExp1.BfSectionCode != stockMoveExp2.BfSectionCode) resList.Add("BfSectionCode");
            if (stockMoveExp1.BfSectionGuideNm != stockMoveExp2.BfSectionGuideNm) resList.Add("BfSectionGuideNm");
            if (stockMoveExp1.BfEnterWarehCode != stockMoveExp2.BfEnterWarehCode) resList.Add("BfEnterWarehCode");
            if (stockMoveExp1.BfEnterWarehName != stockMoveExp2.BfEnterWarehName) resList.Add("BfEnterWarehName");
            if (stockMoveExp1.AfSectionCode != stockMoveExp2.AfSectionCode) resList.Add("AfSectionCode");
            if (stockMoveExp1.AfSectionGuideNm != stockMoveExp2.AfSectionGuideNm) resList.Add("AfSectionGuideNm");
            if (stockMoveExp1.AfEnterWarehCode != stockMoveExp2.AfEnterWarehCode) resList.Add("AfEnterWarehCode");
            if (stockMoveExp1.AfEnterWarehName != stockMoveExp2.AfEnterWarehName) resList.Add("AfEnterWarehName");
            if (stockMoveExp1.CarrierEpCode != stockMoveExp2.CarrierEpCode) resList.Add("CarrierEpCode");
            if (stockMoveExp1.CustomerCode != stockMoveExp2.CustomerCode) resList.Add("CustomerCode");
            if (stockMoveExp1.MakerCode != stockMoveExp2.MakerCode) resList.Add("MakerCode");
            if (stockMoveExp1.MakerName != stockMoveExp2.MakerName) resList.Add("MakerName");
            if (stockMoveExp1.GoodsCode != stockMoveExp2.GoodsCode) resList.Add("GoodsCode");
            if (stockMoveExp1.GoodsName != stockMoveExp2.GoodsName) resList.Add("GoodsName");
            if (stockMoveExp1.ProductNumber != stockMoveExp2.ProductNumber) resList.Add("ProductNumber");
            if (stockMoveExp1.ProductStockGuid != stockMoveExp2.ProductStockGuid) resList.Add("ProductStockGuid");
            if (stockMoveExp1.StockDiv != stockMoveExp2.StockDiv) resList.Add("StockDiv");
            if (stockMoveExp1.StockUnitPrice != stockMoveExp2.StockUnitPrice) resList.Add("StockUnitPrice");
            if (stockMoveExp1.StockPrice != stockMoveExp2.StockPrice) resList.Add("StockPrice");
            if (stockMoveExp1.StockPriceConsTax != stockMoveExp2.StockPriceConsTax) resList.Add("StockPriceConsTax");
            if (stockMoveExp1.ItdedStckOutTax != stockMoveExp2.ItdedStckOutTax) resList.Add("ItdedStckOutTax");
            if (stockMoveExp1.ItdedStckInTax != stockMoveExp2.ItdedStckInTax) resList.Add("ItdedStckInTax");
            if (stockMoveExp1.ItdedStckTaxFree != stockMoveExp2.ItdedStckTaxFree) resList.Add("ItdedStckTaxFree");
            if (stockMoveExp1.StckOuterTax != stockMoveExp2.StckOuterTax) resList.Add("StckOuterTax");
            if (stockMoveExp1.StckInnerTax != stockMoveExp2.StckInnerTax) resList.Add("StckInnerTax");
            if (stockMoveExp1.TaxationCode != stockMoveExp2.TaxationCode) resList.Add("TaxationCode");
            if (stockMoveExp1.StockTelNo1 != stockMoveExp2.StockTelNo1) resList.Add("StockTelNo1");
            if (stockMoveExp1.StockTelNo2 != stockMoveExp2.StockTelNo2) resList.Add("StockTelNo2");
            if (stockMoveExp1.EnterpriseName != stockMoveExp2.EnterpriseName) resList.Add("EnterpriseName");
            if (stockMoveExp1.UpdEmployeeName != stockMoveExp2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (stockMoveExp1.CarrierEpName != stockMoveExp2.CarrierEpName) resList.Add("CarrierEpName");

            return resList;
        }
    }
}
*/
// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki
