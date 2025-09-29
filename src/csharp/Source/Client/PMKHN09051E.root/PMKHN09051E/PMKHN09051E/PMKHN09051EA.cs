using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PartsPosCodeU
    /// <summary>
    ///                      ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/5/28</br>
    /// <br>Genarated Date   :   2008/06/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PartsPosCodeU
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
        /// <remarks>�����g�p</remarks>
        private string _sectionCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        /// <remarks>�[����̏ꍇ�̎g�p�\����</remarks>
        private Int32 _customerCode;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>�������ʃR�[�h</summary>
        private Int32 _searchPartsPosCode;

        /// <summary>�������ʃR�[�h����</summary>
        /// <remarks>�\������0�ABL�R�[�h0�̏ꍇ���ʖ��̂��Z�b�g</remarks>
        private string _searchPartsPosName = "";

        /// <summary>�������ʕ\������</summary>
        private Int32 _posDispOrder;

        /// <summary>BL�R�[�h</summary>
        /// <remarks>�O�̏ꍇ�A���ʖ��̗p���R�[�h</remarks>
        private Int32 _tbsPartsCode;

        /// <summary>BL�R�[�h�}��</summary>
        /// <remarks>�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j</remarks>
        private Int32 _tbsPartsCdDerivedNo;

        /// <summary>BL����</summary>
        private string _tbsPartsName = "";

        /// <summary>�\���敪</summary>
        private Int32 _division;

        /// <summary>�\���敪����</summary>
        private string _divisionName = "";

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
        /// <value>�����g�p</value>
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
        /// <value>�[����̏ꍇ�̎g�p�\����</value>
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

        /// public propaty name  :  SearchPartsPosCode
        /// <summary>�������ʃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ʃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchPartsPosCode
        {
            get { return _searchPartsPosCode; }
            set { _searchPartsPosCode = value; }
        }

        /// public propaty name  :  SearchPartsPosName
        /// <summary>�������ʃR�[�h���̃v���p�e�B</summary>
        /// <value>�\������0�ABL�R�[�h0�̏ꍇ���ʖ��̂��Z�b�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ʃR�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchPartsPosName
        {
            get { return _searchPartsPosName; }
            set { _searchPartsPosName = value; }
        }

        /// public propaty name  :  PosDispOrder
        /// <summary>�������ʕ\�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������ʕ\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PosDispOrder
        {
            get { return _posDispOrder; }
            set { _posDispOrder = value; }
        }

        /// public propaty name  :  TbsPartsCode
        /// <summary>BL�R�[�h�v���p�e�B</summary>
        /// <value>�O�̏ꍇ�A���ʖ��̗p���R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// public propaty name  :  TbsPartsCdDerivedNo
        /// <summary>BL�R�[�h�}�ԃv���p�e�B</summary>
        /// <value>�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }

        /// public propaty name  :  TbsPartsName
        /// <summary>BL���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string TbsPartsName
        {
            get { return _tbsPartsName; }
            set { _tbsPartsName = value; }
        }

        /// public propaty name  :  Division
        /// <summary>�\���敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Division
        {
            get { return _division; }
            set { _division = value; }
        }

        /// public propaty name  :  DivisionName
        /// <summary>�\���敪���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\���敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string DivisionName
        {
            get { return _divisionName; }
            set { _divisionName = value; }
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
        /// ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�R���X�g���N�^
        /// </summary>
        /// <returns>PartsPosCodeU�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsPosCodeU�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PartsPosCodeU()
        {
        }

        /// <summary>
        /// ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="sectionCode">���_�R�[�h(�����g�p)</param>
        /// <param name="customerCode">���Ӑ�R�[�h(�[����̏ꍇ�̎g�p�\����)</param>
        /// <param name="customerSnm">���Ӑ旪��</param>
        /// <param name="searchPartsPosCode">�������ʃR�[�h</param>
        /// <param name="searchPartsPosName">�������ʃR�[�h����(�\������0�ABL�R�[�h0�̏ꍇ���ʖ��̂��Z�b�g)</param>
        /// <param name="posDispOrder">�������ʕ\������</param>
        /// <param name="tbsPartsCode">BL�R�[�h(�O�̏ꍇ�A���ʖ��̗p���R�[�h)</param>
        /// <param name="tbsPartsCdDerivedNo">BL�R�[�h�}��(�����g�p���ځi���C�A�E�g�ɂ͓���Ă����j)</param>
        /// <param name="tbsPartsName">BL����</param>
        /// <param name="division">�\���敪</param>
        /// <param name="divisionName">�\���敪����</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>PartsPosCodeU�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsPosCodeU�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PartsPosCodeU(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 customerCode, string customerSnm, Int32 searchPartsPosCode, string searchPartsPosName, Int32 posDispOrder, Int32 tbsPartsCode, Int32 tbsPartsCdDerivedNo, string tbsPartsName, Int32 division, string divisionName, string enterpriseName, string updEmployeeName)
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
            this._customerSnm = customerSnm;
            this._searchPartsPosCode = searchPartsPosCode;
            this._searchPartsPosName = searchPartsPosName;
            this._posDispOrder = posDispOrder;
            this._tbsPartsCode = tbsPartsCode;
            this._tbsPartsCdDerivedNo = tbsPartsCdDerivedNo;
            this._tbsPartsName = tbsPartsName;
            this._division = division;
            this._divisionName = divisionName;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j��������
        /// </summary>
        /// <returns>PartsPosCodeU�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PartsPosCodeU�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PartsPosCodeU Clone()
        {
            return new PartsPosCodeU(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._customerCode, this._customerSnm, this._searchPartsPosCode, this._searchPartsPosName, this._posDispOrder, this._tbsPartsCode, this._tbsPartsCdDerivedNo, this._tbsPartsName, this._division, this._divisionName, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PartsPosCodeU�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsPosCodeU�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PartsPosCodeU target)
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
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.SearchPartsPosCode == target.SearchPartsPosCode)
                 && (this.SearchPartsPosName == target.SearchPartsPosName)
                 && (this.PosDispOrder == target.PosDispOrder)
                 && (this.TbsPartsCode == target.TbsPartsCode)
                 && (this.TbsPartsCdDerivedNo == target.TbsPartsCdDerivedNo)
                 && (this.TbsPartsName == target.TbsPartsName)
                 && (this.Division == target.Division)
                 && (this.DivisionName == target.DivisionName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j��r����
        /// </summary>
        /// <param name="partsPosCodeU1">
        ///                    ��r����PartsPosCodeU�N���X�̃C���X�^���X
        /// </param>
        /// <param name="partsPosCodeU2">��r����PartsPosCodeU�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsPosCodeU�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PartsPosCodeU partsPosCodeU1, PartsPosCodeU partsPosCodeU2)
        {
            return ((partsPosCodeU1.CreateDateTime == partsPosCodeU2.CreateDateTime)
                 && (partsPosCodeU1.UpdateDateTime == partsPosCodeU2.UpdateDateTime)
                 && (partsPosCodeU1.EnterpriseCode == partsPosCodeU2.EnterpriseCode)
                 && (partsPosCodeU1.FileHeaderGuid == partsPosCodeU2.FileHeaderGuid)
                 && (partsPosCodeU1.UpdEmployeeCode == partsPosCodeU2.UpdEmployeeCode)
                 && (partsPosCodeU1.UpdAssemblyId1 == partsPosCodeU2.UpdAssemblyId1)
                 && (partsPosCodeU1.UpdAssemblyId2 == partsPosCodeU2.UpdAssemblyId2)
                 && (partsPosCodeU1.LogicalDeleteCode == partsPosCodeU2.LogicalDeleteCode)
                 && (partsPosCodeU1.SectionCode == partsPosCodeU2.SectionCode)
                 && (partsPosCodeU1.CustomerCode == partsPosCodeU2.CustomerCode)
                 && (partsPosCodeU1.CustomerSnm == partsPosCodeU2.CustomerSnm)
                 && (partsPosCodeU1.SearchPartsPosCode == partsPosCodeU2.SearchPartsPosCode)
                 && (partsPosCodeU1.SearchPartsPosName == partsPosCodeU2.SearchPartsPosName)
                 && (partsPosCodeU1.PosDispOrder == partsPosCodeU2.PosDispOrder)
                 && (partsPosCodeU1.TbsPartsCode == partsPosCodeU2.TbsPartsCode)
                 && (partsPosCodeU1.TbsPartsCdDerivedNo == partsPosCodeU2.TbsPartsCdDerivedNo)
                 && (partsPosCodeU1.TbsPartsName == partsPosCodeU2.TbsPartsName)
                 && (partsPosCodeU1.Division == partsPosCodeU2.Division)
                 && (partsPosCodeU1.DivisionName == partsPosCodeU2.DivisionName)
                 && (partsPosCodeU1.EnterpriseName == partsPosCodeU2.EnterpriseName)
                 && (partsPosCodeU1.UpdEmployeeName == partsPosCodeU2.UpdEmployeeName));
        }
        /// <summary>
        /// ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PartsPosCodeU�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsPosCodeU�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PartsPosCodeU target)
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
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.SearchPartsPosCode != target.SearchPartsPosCode) resList.Add("SearchPartsPosCode");
            if (this.SearchPartsPosName != target.SearchPartsPosName) resList.Add("SearchPartsPosName");
            if (this.PosDispOrder != target.PosDispOrder) resList.Add("PosDispOrder");
            if (this.TbsPartsCode != target.TbsPartsCode) resList.Add("TbsPartsCode");
            if (this.TbsPartsCdDerivedNo != target.TbsPartsCdDerivedNo) resList.Add("TbsPartsCdDerivedNo");
            if (this.TbsPartsName != target.TbsPartsName) resList.Add("TbsPartsName");
            if (this.Division != target.Division) resList.Add("Division");
            if (this.DivisionName != target.DivisionName) resList.Add("DivisionName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// ���ʃR�[�h�}�X�^�i���[�U�[�o�^�j��r����
        /// </summary>
        /// <param name="partsPosCodeU1">��r����PartsPosCodeU�N���X�̃C���X�^���X</param>
        /// <param name="partsPosCodeU2">��r����PartsPosCodeU�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsPosCodeU�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PartsPosCodeU partsPosCodeU1, PartsPosCodeU partsPosCodeU2)
        {
            ArrayList resList = new ArrayList();
            if (partsPosCodeU1.CreateDateTime != partsPosCodeU2.CreateDateTime) resList.Add("CreateDateTime");
            if (partsPosCodeU1.UpdateDateTime != partsPosCodeU2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (partsPosCodeU1.EnterpriseCode != partsPosCodeU2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (partsPosCodeU1.FileHeaderGuid != partsPosCodeU2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (partsPosCodeU1.UpdEmployeeCode != partsPosCodeU2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (partsPosCodeU1.UpdAssemblyId1 != partsPosCodeU2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (partsPosCodeU1.UpdAssemblyId2 != partsPosCodeU2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (partsPosCodeU1.LogicalDeleteCode != partsPosCodeU2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (partsPosCodeU1.SectionCode != partsPosCodeU2.SectionCode) resList.Add("SectionCode");
            if (partsPosCodeU1.CustomerCode != partsPosCodeU2.CustomerCode) resList.Add("CustomerCode");
            if (partsPosCodeU1.CustomerSnm != partsPosCodeU2.CustomerSnm) resList.Add("CustomerSnm");
            if (partsPosCodeU1.SearchPartsPosCode != partsPosCodeU2.SearchPartsPosCode) resList.Add("SearchPartsPosCode");
            if (partsPosCodeU1.SearchPartsPosName != partsPosCodeU2.SearchPartsPosName) resList.Add("SearchPartsPosName");
            if (partsPosCodeU1.PosDispOrder != partsPosCodeU2.PosDispOrder) resList.Add("PosDispOrder");
            if (partsPosCodeU1.TbsPartsCode != partsPosCodeU2.TbsPartsCode) resList.Add("TbsPartsCode");
            if (partsPosCodeU1.TbsPartsCdDerivedNo != partsPosCodeU2.TbsPartsCdDerivedNo) resList.Add("TbsPartsCdDerivedNo");
            if (partsPosCodeU1.TbsPartsName != partsPosCodeU2.TbsPartsName) resList.Add("TbsPartsName");
            if (partsPosCodeU1.Division != partsPosCodeU2.Division) resList.Add("Division");
            if (partsPosCodeU1.DivisionName != partsPosCodeU2.DivisionName) resList.Add("DivisionName");
            if (partsPosCodeU1.EnterpriseName != partsPosCodeU2.EnterpriseName) resList.Add("EnterpriseName");
            if (partsPosCodeU1.UpdEmployeeName != partsPosCodeU2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
