using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   BLGoodsCdChgU
    /// <summary>
    ///                      BL�R�[�h�ϊ��}�X�^�i���[�U�[�o�^�j
    /// </summary>
    /// <remarks>
    /// <br>note             :   BL�R�[�h�ϊ��}�X�^�i���[�U�[�o�^�j�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2012/7/25</br>
    /// <br>Genarated Date   :   2012/07/31  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class BLGoodsCdChgU
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
        /// <remarks>00�͑S��</remarks>
        private string _sectionCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>PM��BL���i�R�[�h</summary>
        private Int32 _pMBLGoodsCode;

        /// <summary>PM��BL���i�R�[�h�}��</summary>
        private Int32 _pMBLGoodsCodeDerivNo;

        /// <summary>SF��BL���i�R�[�h</summary>
        private Int32 _sFBLGoodsCode;

        /// <summary>SF��BL���i�R�[�h�}��</summary>
        private Int32 _sFBLGoodsCodeDerivNo;

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        private string _bLGoodsFullName = "";

        /// <summary>BL���i�R�[�h���́i���p�j</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>�X�V�]�ƈ�����</summary>
        private string _updEmployeeName = "";


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
        /// <value>00�͑S��</value>
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

        /// public propaty name  :  PMBLGoodsCode
        /// <summary>PM��BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PMBLGoodsCode
        {
            get { return _pMBLGoodsCode; }
            set { _pMBLGoodsCode = value; }
        }

        /// public propaty name  :  PMBLGoodsCodeDerivNo
        /// <summary>PM��BL���i�R�[�h�}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM��BL���i�R�[�h�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PMBLGoodsCodeDerivNo
        {
            get { return _pMBLGoodsCodeDerivNo; }
            set { _pMBLGoodsCodeDerivNo = value; }
        }

        /// public propaty name  :  SFBLGoodsCode
        /// <summary>SF��BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SF��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SFBLGoodsCode
        {
            get { return _sFBLGoodsCode; }
            set { _sFBLGoodsCode = value; }
        }

        /// public propaty name  :  SFBLGoodsCodeDerivNo
        /// <summary>SF��BL���i�R�[�h�}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SF��BL���i�R�[�h�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SFBLGoodsCodeDerivNo
        {
            get { return _sFBLGoodsCodeDerivNo; }
            set { _sFBLGoodsCodeDerivNo = value; }
        }

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL���i�R�[�h���́i�S�p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i�S�p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsFullName
        {
            get { return _bLGoodsFullName; }
            set { _bLGoodsFullName = value; }
        }

        /// public propaty name  :  BLGoodsHalfName
        /// <summary>BL���i�R�[�h���́i���p�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���́i���p�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsHalfName
        {
            get { return _bLGoodsHalfName; }
            set { _bLGoodsHalfName = value; }
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
        /// BL�R�[�h�ϊ��}�X�^�i���[�U�[�o�^�j�R���X�g���N�^
        /// </summary>
        /// <returns>BLGoodsCdChgU�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGoodsCdChgU�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public BLGoodsCdChgU()
        {
        }

        /// <summary>
        /// BL�R�[�h�ϊ��}�X�^�i���[�U�[�o�^�j�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sectionCode">���_�R�[�h(00�͑S��)</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="pMBLGoodsCode">PM��BL���i�R�[�h</param>
        /// <param name="pMBLGoodsCodeDerivNo">PM��BL���i�R�[�h�}��</param>
        /// <param name="sFBLGoodsCode">SF��BL���i�R�[�h</param>
        /// <param name="sFBLGoodsCodeDerivNo">SF��BL���i�R�[�h�}��</param>
        /// <param name="bLGoodsFullName">BL���i�R�[�h���́i�S�p�j</param>
        /// <param name="bLGoodsHalfName">BL���i�R�[�h���́i���p�j</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>BLGoodsCdChgU�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGoodsCdChgU�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public BLGoodsCdChgU(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 customerCode, Int32 pMBLGoodsCode, Int32 pMBLGoodsCodeDerivNo, Int32 sFBLGoodsCode, Int32 sFBLGoodsCodeDerivNo, string bLGoodsFullName, string bLGoodsHalfName, string enterpriseName, string updEmployeeName)
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
            this._customerCode = customerCode;
            this._pMBLGoodsCode = pMBLGoodsCode;
            this._pMBLGoodsCodeDerivNo = pMBLGoodsCodeDerivNo;
            this._sFBLGoodsCode = sFBLGoodsCode;
            this._sFBLGoodsCodeDerivNo = sFBLGoodsCodeDerivNo;
            this._bLGoodsFullName = bLGoodsFullName;
            this._bLGoodsHalfName = bLGoodsHalfName;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// BL�R�[�h�ϊ��}�X�^�i���[�U�[�o�^�j��������
        /// </summary>
        /// <returns>BLGoodsCdChgU�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����BLGoodsCdChgU�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public BLGoodsCdChgU Clone()
        {
            return new BLGoodsCdChgU(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._customerCode, this._pMBLGoodsCode, this._pMBLGoodsCodeDerivNo, this._sFBLGoodsCode, this._sFBLGoodsCodeDerivNo, this._bLGoodsFullName, this._bLGoodsHalfName, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// BL�R�[�h�ϊ��}�X�^�i���[�U�[�o�^�j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�BLGoodsCdChgU�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGoodsCdChgU�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(BLGoodsCdChgU target)
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
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.PMBLGoodsCode == target.PMBLGoodsCode)
                 && (this.PMBLGoodsCodeDerivNo == target.PMBLGoodsCodeDerivNo)
                 && (this.SFBLGoodsCode == target.SFBLGoodsCode)
                 && (this.SFBLGoodsCodeDerivNo == target.SFBLGoodsCodeDerivNo)
                 && (this.BLGoodsFullName == target.BLGoodsFullName)
                 && (this.BLGoodsHalfName == target.BLGoodsHalfName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// BL�R�[�h�ϊ��}�X�^�i���[�U�[�o�^�j��r����
        /// </summary>
        /// <param name="bLGoodsCdChgU1">
        ///                    ��r����BLGoodsCdChgU�N���X�̃C���X�^���X
        /// </param>
        /// <param name="bLGoodsCdChgU2">��r����BLGoodsCdChgU�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGoodsCdChgU�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(BLGoodsCdChgU bLGoodsCdChgU1, BLGoodsCdChgU bLGoodsCdChgU2)
        {
            return ((bLGoodsCdChgU1.CreateDateTime == bLGoodsCdChgU2.CreateDateTime)
                 && (bLGoodsCdChgU1.UpdateDateTime == bLGoodsCdChgU2.UpdateDateTime)
                 && (bLGoodsCdChgU1.EnterpriseCode == bLGoodsCdChgU2.EnterpriseCode)
                 && (bLGoodsCdChgU1.FileHeaderGuid == bLGoodsCdChgU2.FileHeaderGuid)
                 && (bLGoodsCdChgU1.UpdEmployeeCode == bLGoodsCdChgU2.UpdEmployeeCode)
                 && (bLGoodsCdChgU1.UpdAssemblyId1 == bLGoodsCdChgU2.UpdAssemblyId1)
                 && (bLGoodsCdChgU1.UpdAssemblyId2 == bLGoodsCdChgU2.UpdAssemblyId2)
                 && (bLGoodsCdChgU1.LogicalDeleteCode == bLGoodsCdChgU2.LogicalDeleteCode)
                 && (bLGoodsCdChgU1.SectionCode == bLGoodsCdChgU2.SectionCode)
                 && (bLGoodsCdChgU1.CustomerCode == bLGoodsCdChgU2.CustomerCode)
                 && (bLGoodsCdChgU1.PMBLGoodsCode == bLGoodsCdChgU2.PMBLGoodsCode)
                 && (bLGoodsCdChgU1.PMBLGoodsCodeDerivNo == bLGoodsCdChgU2.PMBLGoodsCodeDerivNo)
                 && (bLGoodsCdChgU1.SFBLGoodsCode == bLGoodsCdChgU2.SFBLGoodsCode)
                 && (bLGoodsCdChgU1.SFBLGoodsCodeDerivNo == bLGoodsCdChgU2.SFBLGoodsCodeDerivNo)
                 && (bLGoodsCdChgU1.BLGoodsFullName == bLGoodsCdChgU2.BLGoodsFullName)
                 && (bLGoodsCdChgU1.BLGoodsHalfName == bLGoodsCdChgU2.BLGoodsHalfName)
                 && (bLGoodsCdChgU1.EnterpriseName == bLGoodsCdChgU2.EnterpriseName)
                 && (bLGoodsCdChgU1.UpdEmployeeName == bLGoodsCdChgU2.UpdEmployeeName));
        }
        /// <summary>
        /// BL�R�[�h�ϊ��}�X�^�i���[�U�[�o�^�j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�BLGoodsCdChgU�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGoodsCdChgU�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(BLGoodsCdChgU target)
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
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.PMBLGoodsCode != target.PMBLGoodsCode) resList.Add("PMBLGoodsCode");
            if (this.PMBLGoodsCodeDerivNo != target.PMBLGoodsCodeDerivNo) resList.Add("PMBLGoodsCodeDerivNo");
            if (this.SFBLGoodsCode != target.SFBLGoodsCode) resList.Add("SFBLGoodsCode");
            if (this.SFBLGoodsCodeDerivNo != target.SFBLGoodsCodeDerivNo) resList.Add("SFBLGoodsCodeDerivNo");
            if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (this.BLGoodsHalfName != target.BLGoodsHalfName) resList.Add("BLGoodsHalfName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// BL�R�[�h�ϊ��}�X�^�i���[�U�[�o�^�j��r����
        /// </summary>
        /// <param name="bLGoodsCdChgU1">��r����BLGoodsCdChgU�N���X�̃C���X�^���X</param>
        /// <param name="bLGoodsCdChgU2">��r����BLGoodsCdChgU�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   BLGoodsCdChgU�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(BLGoodsCdChgU bLGoodsCdChgU1, BLGoodsCdChgU bLGoodsCdChgU2)
        {
            ArrayList resList = new ArrayList();
            if (bLGoodsCdChgU1.CreateDateTime != bLGoodsCdChgU2.CreateDateTime) resList.Add("CreateDateTime");
            if (bLGoodsCdChgU1.UpdateDateTime != bLGoodsCdChgU2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (bLGoodsCdChgU1.EnterpriseCode != bLGoodsCdChgU2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (bLGoodsCdChgU1.FileHeaderGuid != bLGoodsCdChgU2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (bLGoodsCdChgU1.UpdEmployeeCode != bLGoodsCdChgU2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (bLGoodsCdChgU1.UpdAssemblyId1 != bLGoodsCdChgU2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (bLGoodsCdChgU1.UpdAssemblyId2 != bLGoodsCdChgU2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (bLGoodsCdChgU1.LogicalDeleteCode != bLGoodsCdChgU2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (bLGoodsCdChgU1.SectionCode != bLGoodsCdChgU2.SectionCode) resList.Add("SectionCode");
            if (bLGoodsCdChgU1.CustomerCode != bLGoodsCdChgU2.CustomerCode) resList.Add("CustomerCode");
            if (bLGoodsCdChgU1.PMBLGoodsCode != bLGoodsCdChgU2.PMBLGoodsCode) resList.Add("PMBLGoodsCode");
            if (bLGoodsCdChgU1.PMBLGoodsCodeDerivNo != bLGoodsCdChgU2.PMBLGoodsCodeDerivNo) resList.Add("PMBLGoodsCodeDerivNo");
            if (bLGoodsCdChgU1.SFBLGoodsCode != bLGoodsCdChgU2.SFBLGoodsCode) resList.Add("SFBLGoodsCode");
            if (bLGoodsCdChgU1.SFBLGoodsCodeDerivNo != bLGoodsCdChgU2.SFBLGoodsCodeDerivNo) resList.Add("SFBLGoodsCodeDerivNo");
            if (bLGoodsCdChgU1.BLGoodsFullName != bLGoodsCdChgU2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (bLGoodsCdChgU1.BLGoodsHalfName != bLGoodsCdChgU2.BLGoodsHalfName) resList.Add("BLGoodsHalfName");
            if (bLGoodsCdChgU1.EnterpriseName != bLGoodsCdChgU2.EnterpriseName) resList.Add("EnterpriseName");
            if (bLGoodsCdChgU1.UpdEmployeeName != bLGoodsCdChgU2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
