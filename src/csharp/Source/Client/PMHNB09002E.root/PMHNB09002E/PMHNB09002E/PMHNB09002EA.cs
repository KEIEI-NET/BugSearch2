//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �\���敪�}�X�^�����e�i���X
// �v���O�����T�v   : �\���敪�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �� �� ��  2009/10/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   PriceSelectSet
    /// <summary>
    ///                      �W�����i�I��ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �W�����i�I��ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2009/09/15</br>
    /// <br>Genarated Date   :   2009/10/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class PriceSelectSet
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

        /// <summary>�W�����i�I��ݒ�p�^�[��</summary>
        /// <remarks>0:Ұ�����ށEBL���ށE���Ӑ溰��,1:Ұ�����ށE���Ӑ溰��,2:BL���ށE���Ӑ溰��,3:Ұ�����ށEBL���ށE���Ӑ�|����ٰ��,4:Ұ�����ށE���Ӑ�|����ٰ��,5:BL���ށE���Ӑ�|����ٰ��,6:Ұ�����ށEBL����,7:Ұ������,8:BL����</remarks>
        private Int32 _priceSelectPtn;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        private Int32 _custRateGrpCode;

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>�W�����i�I���敪</summary>
        /// <remarks>0:�D��,1:����,2:������(1:N),,3:������(1:1)</remarks>
        private Int32 _priceSelectDiv;

        /// <summary>���Ӑ旪��</summary>
        private string _customerSnm = "";

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        private string _bLGoodsFullName = "";

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

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

        /// public propaty name  :  PriceSelectPtn
        /// <summary>�W�����i�I��ݒ�p�^�[���v���p�e�B</summary>
        /// <value>0:Ұ�����ށEBL���ށE���Ӑ溰��,1:Ұ�����ށE���Ӑ溰��,2:BL���ށE���Ӑ溰��,3:Ұ�����ށEBL���ށE���Ӑ�|����ٰ��,4:Ұ�����ށE���Ӑ�|����ٰ��,5:BL���ށE���Ӑ�|����ٰ��,6:Ұ�����ށEBL����,7:Ұ������,8:BL����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�I��ݒ�p�^�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceSelectPtn
        {
            get { return _priceSelectPtn; }
            set { _priceSelectPtn = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
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

        /// public propaty name  :  CustRateGrpCode
        /// <summary>���Ӑ�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
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

        /// public propaty name  :  PriceSelectDiv
        /// <summary>�W�����i�I���敪�v���p�e�B</summary>
        /// <value>0:�D��,1:����,2:������(1:N),,3:������(1:1)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�I���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceSelectDiv
        {
            get { return _priceSelectDiv; }
            set { _priceSelectDiv = value; }
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

        /// public propaty name  :  MakerName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerName
        {
            get { return _makerName; }
            set { _makerName = value; }
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
        /// �W�����i�I��ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>PriceSelectSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceSelectSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PriceSelectSet()
        {
        }

        /// <summary>
        /// �W�����i�I��ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="priceSelectPtn">�W�����i�I��ݒ�p�^�[��(0:Ұ�����ށEBL���ށE���Ӑ溰��,1:Ұ�����ށE���Ӑ溰��,2:BL���ށE���Ӑ溰��,3:Ұ�����ށEBL���ށE���Ӑ�|����ٰ��,4:Ұ�����ށE���Ӑ�|����ٰ��,5:BL���ށE���Ӑ�|����ٰ��,6:Ұ�����ށEBL����,7:Ұ������,8:BL����)</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="priceSelectDiv">�W�����i�I���敪(0:�D��,1:����,2:������(1:N),,3:������(1:1))</param>
        /// <param name="customerSnm">���Ӑ旪��</param>
        /// <param name="bLGoodsFullName">BL���i�R�[�h���́i�S�p�j</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>PriceSelectSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceSelectSet�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PriceSelectSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 priceSelectPtn, Int32 goodsMakerCd, Int32 bLGoodsCode, Int32 custRateGrpCode, Int32 customerCode, Int32 priceSelectDiv, string customerSnm, string bLGoodsFullName, string makerName, string enterpriseName, string updEmployeeName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._priceSelectPtn = priceSelectPtn;
            this._goodsMakerCd = goodsMakerCd;
            this._bLGoodsCode = bLGoodsCode;
            this._custRateGrpCode = custRateGrpCode;
            this._customerCode = customerCode;
            this._priceSelectDiv = priceSelectDiv;
            this._customerSnm = customerSnm;
            this._bLGoodsFullName = bLGoodsFullName;
            this._makerName = makerName;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// �W�����i�I��ݒ�}�X�^��������
        /// </summary>
        /// <returns>PriceSelectSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����PriceSelectSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PriceSelectSet Clone()
        {
            return new PriceSelectSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._priceSelectPtn, this._goodsMakerCd, this._bLGoodsCode, this._custRateGrpCode, this._customerCode, this._priceSelectDiv, this._customerSnm, this._bLGoodsFullName, this._makerName, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// �W�����i�I��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PriceSelectSet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceSelectSet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(PriceSelectSet target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.PriceSelectPtn == target.PriceSelectPtn)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.CustRateGrpCode == target.CustRateGrpCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.PriceSelectDiv == target.PriceSelectDiv)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.BLGoodsFullName == target.BLGoodsFullName)
                 && (this.MakerName == target.MakerName)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// �W�����i�I��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="priceSelectSet1">
        ///                    ��r����PriceSelectSet�N���X�̃C���X�^���X
        /// </param>
        /// <param name="priceSelectSet2">��r����PriceSelectSet�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceSelectSet�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(PriceSelectSet priceSelectSet1, PriceSelectSet priceSelectSet2)
        {
            return ((priceSelectSet1.CreateDateTime == priceSelectSet2.CreateDateTime)
                 && (priceSelectSet1.UpdateDateTime == priceSelectSet2.UpdateDateTime)
                 && (priceSelectSet1.EnterpriseCode == priceSelectSet2.EnterpriseCode)
                 && (priceSelectSet1.FileHeaderGuid == priceSelectSet2.FileHeaderGuid)
                 && (priceSelectSet1.UpdEmployeeCode == priceSelectSet2.UpdEmployeeCode)
                 && (priceSelectSet1.UpdAssemblyId1 == priceSelectSet2.UpdAssemblyId1)
                 && (priceSelectSet1.UpdAssemblyId2 == priceSelectSet2.UpdAssemblyId2)
                 && (priceSelectSet1.LogicalDeleteCode == priceSelectSet2.LogicalDeleteCode)
                 && (priceSelectSet1.PriceSelectPtn == priceSelectSet2.PriceSelectPtn)
                 && (priceSelectSet1.GoodsMakerCd == priceSelectSet2.GoodsMakerCd)
                 && (priceSelectSet1.BLGoodsCode == priceSelectSet2.BLGoodsCode)
                 && (priceSelectSet1.CustRateGrpCode == priceSelectSet2.CustRateGrpCode)
                 && (priceSelectSet1.CustomerCode == priceSelectSet2.CustomerCode)
                 && (priceSelectSet1.PriceSelectDiv == priceSelectSet2.PriceSelectDiv)
                 && (priceSelectSet1.CustomerSnm == priceSelectSet2.CustomerSnm)
                 && (priceSelectSet1.BLGoodsFullName == priceSelectSet2.BLGoodsFullName)
                 && (priceSelectSet1.MakerName == priceSelectSet2.MakerName)
                 && (priceSelectSet1.EnterpriseName == priceSelectSet2.EnterpriseName)
                 && (priceSelectSet1.UpdEmployeeName == priceSelectSet2.UpdEmployeeName));
        }
        /// <summary>
        /// �W�����i�I��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�PriceSelectSet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceSelectSet�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(PriceSelectSet target)
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
            if (this.PriceSelectPtn != target.PriceSelectPtn) resList.Add("PriceSelectPtn");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.PriceSelectDiv != target.PriceSelectDiv) resList.Add("PriceSelectDiv");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// �W�����i�I��ݒ�}�X�^��r����
        /// </summary>
        /// <param name="priceSelectSet1">��r����PriceSelectSet�N���X�̃C���X�^���X</param>
        /// <param name="priceSelectSet2">��r����PriceSelectSet�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PriceSelectSet�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(PriceSelectSet priceSelectSet1, PriceSelectSet priceSelectSet2)
        {
            ArrayList resList = new ArrayList();
            if (priceSelectSet1.CreateDateTime != priceSelectSet2.CreateDateTime) resList.Add("CreateDateTime");
            if (priceSelectSet1.UpdateDateTime != priceSelectSet2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (priceSelectSet1.EnterpriseCode != priceSelectSet2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (priceSelectSet1.FileHeaderGuid != priceSelectSet2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (priceSelectSet1.UpdEmployeeCode != priceSelectSet2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (priceSelectSet1.UpdAssemblyId1 != priceSelectSet2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (priceSelectSet1.UpdAssemblyId2 != priceSelectSet2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (priceSelectSet1.LogicalDeleteCode != priceSelectSet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (priceSelectSet1.PriceSelectPtn != priceSelectSet2.PriceSelectPtn) resList.Add("PriceSelectPtn");
            if (priceSelectSet1.GoodsMakerCd != priceSelectSet2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (priceSelectSet1.BLGoodsCode != priceSelectSet2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (priceSelectSet1.CustRateGrpCode != priceSelectSet2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (priceSelectSet1.CustomerCode != priceSelectSet2.CustomerCode) resList.Add("CustomerCode");
            if (priceSelectSet1.PriceSelectDiv != priceSelectSet2.PriceSelectDiv) resList.Add("PriceSelectDiv");
            if (priceSelectSet1.CustomerSnm != priceSelectSet2.CustomerSnm) resList.Add("CustomerSnm");
            if (priceSelectSet1.BLGoodsFullName != priceSelectSet2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (priceSelectSet1.MakerName != priceSelectSet2.MakerName) resList.Add("MakerName");
            if (priceSelectSet1.EnterpriseName != priceSelectSet2.EnterpriseName) resList.Add("EnterpriseName");
            if (priceSelectSet1.UpdEmployeeName != priceSelectSet2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
