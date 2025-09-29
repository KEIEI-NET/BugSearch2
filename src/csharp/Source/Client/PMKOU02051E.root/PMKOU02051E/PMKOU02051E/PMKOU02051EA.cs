//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���`�F�b�N���X�g
// �v���O�����T�v   : �d���`�F�b�N���X�g���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2009/05/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   StockSlipCndtn
    /// <summary>
    ///                      �d���f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2009/03/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class StockSlipCndtn
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

        /// <summary>�I�����_�R�[�h</summary>
        private string[] _sectionCodeList;

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

        /// <summary>����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _totalDay;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���於</summary>
        private string _supplierNm;

        /// <summary>�`�F�b�N�敪</summary>
        /// <remarks>�`�F�b�N�敪(0:PM/�d����,1:�d���f�[�^�d��)</remarks>
        private CheckSectionDivState _checkSectionDiv;

        /// <summary>�J�n�Ώۓ��t</summary>
        private DateTime _st_addUpDate;

        /// <summary>�I���Ώۓ��t</summary>
        private DateTime _ed_addUpDate;

        /// <summary>�J�n�Ώۓ��t</summary>
        private DateTime _st_addUpDateShow;

        /// <summary>�I���Ώۓ��t</summary>
        private DateTime _ed_addUpDateShow;

        /// <summary>�e�L�X�g�`��</summary>
        /// <remarks>�e�L�X�g�`��(0:CSV,1:TAB)</remarks>
        private TextTypeDivState _txtStyle;

        /// <summary>�d�����`�F�b�N</summary>
        /// <remarks>�d�����`�F�b�N(0:�Ȃ�,1:����)</remarks>
        private SupDayCheckDivState _supDayCheckDiv;

        /// <summary>���_�`�F�b�N</summary>
        /// <remarks>���_�`�F�b�N(0:�Ȃ�,1:����)</remarks>
        private SectionCdCheckDivState _sectionCdCheckDiv;

        /// <summary>�`�[�ԍ��`�F�b�N</summary>
        /// <remarks>�`�[�ԍ��`�F�b�N(0:�ʏ�,1:��6���̂�,2:��6���̂�)</remarks>
        private SlipNumCheckDivState _slipNumCheckDiv;

        /// <summary>����敪</summary>
        /// <remarks>����敪(0:�S��,1:�s��v��,2:��v��)</remarks>
        private PrintDivState _printDiv;

        /// <summary>�e�L�X�g�t�@�C����</summary>
        private string _filePath = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";

        /// <summary>CSV�̃f�[�^</summary>
        private ArrayList _csvData;

        /// <summary>
        /// ���_�I�v�V�����敪
        /// </summary>
        private bool _isOptSection = false;

        /// <summary>
        /// �S���_�I���敪
        /// </summary>
        private bool _isSelectAllSection = false;

        /// <summary>��v��PM���z���v</summary>
        private long _samePmPrice = 0;
        /// <summary>�s��v��PM���z���v</summary>
        private long _diffPmPrice = 0;
        /// <summary>��v��CSV���z���v</summary>
        private long _sameCsvPrice = 0;
        /// <summary>�s��v��CSV���z���v</summary>
        private long _diffCsvPrice = 0;
        /// <summary>PM���z�����v</summary>
        private long _totalPmPrice = 0;
        /// <summary>CSV���z�����v</summary>
        private long _totalCsvPrice = 0;
        /// <summary>��v�f�[�^FLG</summary>
        private bool _sameFlg = false;
        /// <summary>�s��v�f�[�^FLG</summary>
        private bool _diffFlg = false;


        /// <summary>
        /// ��v�f�[�^FLG�v���p�e�B
        /// </summary>
        public bool SameFlg
        {
            get { return this._sameFlg; }
            set { this._sameFlg = value; }
        }

        /// <summary>
        /// �s��v�f�[�^FLG�v���p�e�B
        /// </summary>
        public bool DiffFlg
        {
            get { return this._diffFlg; }
            set { this._diffFlg = value; }
        }

        /// <summary>
        /// ��v��PM���z���v�v���p�e�B
        /// </summary>
        public long SamePmPrice
        {
            get { return this._samePmPrice; }
            set { this._samePmPrice = value; }
        }

        /// <summary>
        /// �s��v��PM���z���v�v���p�e�B
        /// </summary>
        public long DiffPmPrice
        {
            get { return this._diffPmPrice; }
            set { this._diffPmPrice = value; }
        }

        /// <summary>
        /// ��v��CSV���z���v�v���p�e�B
        /// </summary>
        public long SameCsvPrice
        {
            get { return this._sameCsvPrice; }
            set { this._sameCsvPrice = value; }
        }

        /// <summary>
        /// �s��v��CSV���z���v�v���p�e�B
        /// </summary>
        public long DiffCsvPrice
        {
            get { return this._diffCsvPrice; }
            set { this._diffCsvPrice = value; }
        }

        /// <summary>
        /// PM�����z���v�v���p�e�B
        /// </summary>
        public long TotalCsvPrice
        {
            get { return this._totalCsvPrice; }
            set { this._totalCsvPrice = value; }
        }

        /// <summary>
        /// CSV�����z���v�v���p�e�B
        /// </summary>
        public long TotalPmPrice
        {
            get { return this._totalPmPrice; }
            set { this._totalPmPrice = value; }
        }


        /// <summary>
        /// �d���於�v���p�e�B
        /// </summary>
        public string SupplierNm
        {
            get { return this._supplierNm; }
            set { this._supplierNm = value; }
        }

        /// <summary>
        /// CSV�̃f�[�^�v���p�e�B
        /// </summary>
        public ArrayList CsvData
        {
            get { return this._csvData; }
            set { this._csvData = value; }
        }


        /// <summary>
        /// ���_�I�v�V�����敪�v���p�e�B
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }
        /// <summary>
        /// �S���_�I���敪�v���p�e�B
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }

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

        /// public propaty name  :  SectionCodeList
        /// <summary>�I�����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCodeList
        {
            get { return _sectionCodeList; }
            set { _sectionCodeList = value; }
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

        /// public propaty name  :  TotalDay
        /// <summary>�d�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  StockDateJpFormal
        /// <summary>�d���� �a��v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���� �a��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _totalDay); }
            set { }
        }

        /// public propaty name  :  StockDateJpInFormal
        /// <summary>�d���� �a��(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���� �a��(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _totalDay); }
            set { }
        }

        /// public propaty name  :  StockDateAdFormal
        /// <summary>�d���� ����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���� ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _totalDay); }
            set { }
        }

        /// public propaty name  :  StockDateAdInFormal
        /// <summary>�d���� ����(��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���� ����(��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _totalDay); }
            set { }
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

        /// public propaty name  :  CheckSectionDiv
        /// <summary>�`�F�b�N�敪�v���p�e�B</summary>
        /// <value>�`�F�b�N�敪(0:�d����,1:�d���f�[�^�d��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�F�b�N�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CheckSectionDivState CheckSectionDiv
        {
            get { return _checkSectionDiv; }
            set { _checkSectionDiv = value; }
        }

        /// public propaty name  :  St_addUpDate
        /// <summary>�J�n�Ώۓ��t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�Ώۓ��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_addUpDate
        {
            get { return _st_addUpDate; }
            set { _st_addUpDate = value; }
        }

        /// public propaty name  :  Ed_addUpDate
        /// <summary>�I���Ώۓ��t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���Ώۓ��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_addUpDate
        {
            get { return _ed_addUpDate; }
            set { _ed_addUpDate = value; }
        }

        /// public propaty name  :  St_addUpDateShow
        /// <summary>�J�n�Ώۓ��t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�Ώۓ��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_addUpDateShow
        {
            get { return _st_addUpDateShow; }
            set { _st_addUpDateShow = value; }
        }

        /// public propaty name  :  Ed_addUpDateShow
        /// <summary>�I���Ώۓ��t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���Ώۓ��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_addUpDateShow
        {
            get { return _ed_addUpDateShow; }
            set { _ed_addUpDateShow = value; }
        }

        /// public propaty name  :  TxtStyle
        /// <summary>�e�L�X�g�`���v���p�e�B</summary>
        /// <value>�e�L�X�g�`��(0:CSV,1:TAB)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�L�X�g�`���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TextTypeDivState TxtStyle
        {
            get { return _txtStyle; }
            set { _txtStyle = value; }
        }

        /// public propaty name  :  SupDayCheckDiv
        /// <summary>�d�����`�F�b�N�v���p�e�B</summary>
        /// <value>�d�����`�F�b�N(0:�Ȃ�,1:����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����`�F�b�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SupDayCheckDivState SupDayCheckDiv
        {
            get { return _supDayCheckDiv; }
            set { _supDayCheckDiv = value; }
        }

        /// public propaty name  :  SectionCdCheckDiv
        /// <summary>���_�`�F�b�N�v���p�e�B</summary>
        /// <value>���_�`�F�b�N(0:�Ȃ�,1:����)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�`�F�b�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SectionCdCheckDivState SectionCdCheckDiv
        {
            get { return _sectionCdCheckDiv; }
            set { _sectionCdCheckDiv = value; }
        }

        /// public propaty name  :  SlipNumCheckDiv
        /// <summary>�`�[�ԍ��`�F�b�N�v���p�e�B</summary>
        /// <value>�`�[�ԍ��`�F�b�N(0:�ʏ�,1:��6���̂�,2:��6���̂�)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�ԍ��`�F�b�N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SlipNumCheckDivState SlipNumCheckDiv
        {
            get { return _slipNumCheckDiv; }
            set { _slipNumCheckDiv = value; }
        }

        /// public propaty name  :  PrintDiv
        /// <summary>����敪�v���p�e�B</summary>
        /// <value>����敪(0:�S��,1:�s��v��,2:��v��)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PrintDivState PrintDiv
        {
            get { return _printDiv; }
            set { _printDiv = value; }
        }

        /// public propaty name  :  FilePath
        /// <summary>�e�L�X�g�t�@�C�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e�L�X�g�t�@�C�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
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


        /// <summary>
        /// �d���f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>StockSlip�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockSlip�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockSlipCndtn()
        {
        }

        /// <summary>�`�F�b�N�敪 PM/�d����</summary>
        public const string ct_CheckSectionDiv_PMSupplier = "�o�l�^�d����";
        /// <summary>�`�F�b�N�敪 �d����f�[�^�d��</summary>
        public const string ct_CheckSectionDiv_SupplierDataRep = "�d���f�[�^�d��";

        /// <summary>
        /// �`�F�b�N�敪�@�񋓌^
        /// </summary>
        public enum CheckSectionDivState
        {
            /// <summary>PM/�d����</summary>
            PMSupplier = 0,
            /// <summary>�d����f�[�^�d��</summary>
            SupplierDataRep = 1,
        }

        /// <summary>
        /// �`�F�b�N�敪�@���̎擾
        /// </summary>
        public string CheckSectionDivName
        {
            get
            {
                switch (this._checkSectionDiv)
                {
                    case CheckSectionDivState.PMSupplier:
                        return ct_CheckSectionDiv_PMSupplier;
                    case CheckSectionDivState.SupplierDataRep:
                        return ct_CheckSectionDiv_SupplierDataRep;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>�e�L�X�g�`�� CSV</summary>
        public const string ct_TextTypeDiv_CSV = "CSV";
        /// <summary>�e�L�X�g�`�� TAB</summary>
        public const string ct_TextTypeDiv_TAB = "TAB";

        /// <summary>
        /// �e�L�X�g�`���@�񋓌^
        /// </summary>
        public enum TextTypeDivState
        {
            /// <summary>CSV</summary>
            CSV = 0,
            /// <summary>TAB</summary>
            TAB = 1,
        }

        /// <summary>
        /// �e�L�X�g�`���@���̎擾
        /// </summary>
        public string TextTypeDivName
        {
            get
            {
                switch (this._txtStyle)
                {
                    case TextTypeDivState.CSV:
                        return ct_TextTypeDiv_CSV;
                    case TextTypeDivState.TAB:
                        return ct_TextTypeDiv_TAB;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>�`�F�b�N ����</summary>
        public const string ct_CheckDiv_Check = "����";
        /// <summary>�e�L�X�g�`�� �Ȃ�</summary>
        public const string ct_CheckDiv_None = "�Ȃ�";

        /// <summary>
        /// �d�����`�F�b�N�@�񋓌^
        /// </summary>
        public enum SupDayCheckDivState
        {
            /// <summary>����</summary>
            Check = 1,
            /// <summary>�Ȃ�</summary>
            None = 0,
        }

        /// <summary>
        /// �d�����`�F�b�N�@���̎擾
        /// </summary>
        public string SupDayCheckDivName
        {
            get
            {
                switch (this._supDayCheckDiv)
                {
                    case SupDayCheckDivState.Check:
                        return ct_CheckDiv_Check;
                    case SupDayCheckDivState.None:
                        return ct_CheckDiv_None;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// ���_�`�F�b�N�@�񋓌^
        /// </summary>
        public enum SectionCdCheckDivState
        {
            /// <summary>����</summary>
            Check = 1,
            /// <summary>�Ȃ�</summary>
            None = 0,
        }

        /// <summary>
        /// ���_�`�F�b�N�@���̎擾
        /// </summary>
        public string SectionCdCheckDivName
        {
            get
            {
                switch (this._sectionCdCheckDiv)
                {
                    case SectionCdCheckDivState.Check:
                        return ct_CheckDiv_Check;
                    case SectionCdCheckDivState.None:
                        return ct_CheckDiv_None;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>�`�[�ԍ��`�F�b�N �ʏ�</summary>
        public const string ct_SlipNumCheckDiv_Normal = "�ʏ�";
        /// <summary>�`�[�ԍ��`�F�b�N ��6���̂�</summary>
        public const string ct_SlipNumCheckDiv_First6 = "��6���̂�";
        /// <summary>�`�[�ԍ��`�F�b�N ��6���̂�</summary>
        public const string ct_SlipNumCheckDiv_Last6 = "��6���̂�";

        /// <summary>
        /// �`�[�ԍ��`�F�b�N�@�񋓌^
        /// </summary>
        public enum SlipNumCheckDivState
        {
            /// <summary>�ʏ�</summary>
            Normal = 0,
            /// <summary>��6���̂�</summary>
            First6 = 1,
            /// <summary>��6���̂�</summary>
            Last6 = 2,
        }

        /// <summary>
        /// ���_�`�F�b�N�@���̎擾
        /// </summary>
        public string SlipNumCheckDivName
        {
            get
            {
                switch (this._slipNumCheckDiv)
                {
                    case SlipNumCheckDivState.Normal:
                        return ct_SlipNumCheckDiv_Normal;
                    case SlipNumCheckDivState.First6:
                        return ct_SlipNumCheckDiv_First6;
                    case SlipNumCheckDivState.Last6:
                        return ct_SlipNumCheckDiv_Last6;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>����敪 �S��</summary>
        public const string ct_PrintDiv_All = "�S��";
        /// <summary>����敪 �s��v��</summary>
        public const string ct_PrintDiv_Different = "�s��v��";
        /// <summary>����敪 ��v��</summary>
        public const string ct_PrintDiv_Same = "��v��";

        /// <summary>
        /// ����敪�@�񋓌^
        /// </summary>
        public enum PrintDivState
        {
            /// <summary>�S��</summary>
            All = 0,
            /// <summary>�s��v��</summary>
            Different = 1,
            /// <summary>��v��</summary>
            Same = 2,
        }

        /// <summary>
        /// ����敪�@���̎擾
        /// </summary>
        public string PrintDivName
        {
            get
            {
                switch (this._printDiv)
                {
                    case PrintDivState.All:
                        return ct_PrintDiv_All;
                    case PrintDivState.Different:
                        return ct_PrintDiv_Different;
                    case PrintDivState.Same:
                        return ct_PrintDiv_Same;
                    default:
                        return string.Empty;
                }
            }
        }


    }
}
