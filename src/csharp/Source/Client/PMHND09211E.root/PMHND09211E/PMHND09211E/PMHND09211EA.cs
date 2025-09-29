//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�o�[�R�[�h�֘A�t���}�X�^
// �v���O�����T�v   : ���i�o�[�R�[�h�֘A�t���e�[�u���ɑ΂��Ċe���쏈�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : 3H ������
// �� �� ��  2017/06/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsBarCodeRevn
    /// <summary>
    ///                      ���i�o�[�R�[�h�֘A�t���}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�o�[�R�[�h�֘A�t���}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2017/06/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class GoodsBarCodeRevn
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

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i�o�[�R�[�h</summary>
        private string _goodsBarCode;

        /// <summary>���i�o�[�R�[�h���</summary>
        private Int32 _goodsBarCodeKind;

        /// <summary>�`�F�b�N�f�W�b�g�敪</summary>
        private Int32 _checkdigitCode;

        /// <summary>�񋟓��t</summary>
        private Int32 _offerDate;

        /// <summary>�񋟃f�[�^�敪</summary>
        private Int32 _offerDataDiv;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

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

        /// public propaty name  :  GoodsBarCode
        /// <summary>���i�o�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�o�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsBarCode
        {
            get { return _goodsBarCode; }
            set { _goodsBarCode = value; }
        }

        /// public propaty name  :  GoodsBarCodeKind
        /// <summary>���i�o�[�R�[�h��ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�o�[�R�[�h��ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsBarCodeKind
        {
            get { return _goodsBarCodeKind; }
            set { _goodsBarCodeKind = value; }
        }

        /// public propaty name  :  CheckdigitCode
        /// <summary>�`�F�b�N�f�W�b�g�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�F�b�N�f�W�b�g�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CheckdigitCode
        {
            get { return _checkdigitCode; }
            set { _checkdigitCode = value; }
        }

        /// public propaty name  :  OfferDate
        /// <summary>�񋟓��t�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OfferDate
        {
            get { return _offerDate; }
            set { _offerDate = value; }
        }

        /// public propaty name  :  OfferDataDiv
        /// <summary>�񋟃f�[�^�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟃f�[�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OfferDataDiv
        {
            get { return _offerDataDiv; }
            set { _offerDataDiv = value; }
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

        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>GoodsBarCodeRevn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsBarCodeRevn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsBarCodeRevn()
        {
        }

        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsBarCode">���i�o�[�R�[�h</param>
        /// <param name="goodsBarCodeKind">���i�o�[�R�[�h���</param>
        /// <param name="checkdigitCode">�`�F�b�N�f�W�b�g�敪</param>
        /// <param name="offerDate">�񋟓��t</param>
        /// <param name="offerDataDiv">�񋟃f�[�^�敪</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <param name="goodsName">���i����</param>
        /// <returns>GoodsBarCodeRevn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsBarCodeRevn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsBarCodeRevn(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string goodsNo, string goodsBarCode, Int32 goodsBarCodeKind, Int32 checkdigitCode, Int32 offerDate, Int32 offerDataDiv, string makerName, string goodsName)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._goodsMakerCd = goodsMakerCd;
            this._goodsNo = goodsNo;
            this._goodsBarCode = goodsBarCode;
            this._goodsBarCodeKind = goodsBarCodeKind;
            this._checkdigitCode = checkdigitCode;
            this._offerDate = offerDate;
            this._offerDataDiv = offerDataDiv;
            this._makerName = makerName;
            this._goodsName = goodsName;
        }

        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���}�X�^��������
        /// </summary>
        /// <returns>GoodsBarCodeRevn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����GoodsBarCodeRevn�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsBarCodeRevn Clone()
        {
            return new GoodsBarCodeRevn(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._goodsNo, this._goodsBarCode, this._goodsBarCodeKind, this._checkdigitCode, this._offerDate, this._offerDataDiv, this._makerName, this._goodsName);
        }

        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�GoodsBarCodeRevn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsBarCodeRevn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(GoodsBarCodeRevn target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsBarCode == target.GoodsBarCode)
                 && (this.GoodsBarCodeKind == target.GoodsBarCodeKind)
                 && (this.CheckdigitCode == target.CheckdigitCode)
                 && (this.OfferDate == target.OfferDate)
                 && (this.OfferDataDiv == target.OfferDataDiv)
                 && (this.MakerName == target.MakerName)
                 && (this.GoodsName == target.GoodsName));
        }

        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���}�X�^��r����
        /// </summary>
        /// <param name="goodsBarCodeRevn1">
        ///                    ��r����GoodsBarCodeRevn�N���X�̃C���X�^���X
        /// </param>
        /// <param name="goodsBarCodeRevn2">��r����GoodsBarCodeRevn�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsBarCodeRevn�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(GoodsBarCodeRevn goodsBarCodeRevn1, GoodsBarCodeRevn goodsBarCodeRevn2)
        {
            return ((goodsBarCodeRevn1.CreateDateTime == goodsBarCodeRevn2.CreateDateTime)
                 && (goodsBarCodeRevn1.UpdateDateTime == goodsBarCodeRevn2.UpdateDateTime)
                 && (goodsBarCodeRevn1.EnterpriseCode == goodsBarCodeRevn2.EnterpriseCode)
                 && (goodsBarCodeRevn1.FileHeaderGuid == goodsBarCodeRevn2.FileHeaderGuid)
                 && (goodsBarCodeRevn1.UpdEmployeeCode == goodsBarCodeRevn2.UpdEmployeeCode)
                 && (goodsBarCodeRevn1.UpdAssemblyId1 == goodsBarCodeRevn2.UpdAssemblyId1)
                 && (goodsBarCodeRevn1.UpdAssemblyId2 == goodsBarCodeRevn2.UpdAssemblyId2)
                 && (goodsBarCodeRevn1.LogicalDeleteCode == goodsBarCodeRevn2.LogicalDeleteCode)
                 && (goodsBarCodeRevn1.GoodsMakerCd == goodsBarCodeRevn2.GoodsMakerCd)
                 && (goodsBarCodeRevn1.GoodsNo == goodsBarCodeRevn2.GoodsNo)
                 && (goodsBarCodeRevn1.GoodsBarCode == goodsBarCodeRevn2.GoodsBarCode)
                 && (goodsBarCodeRevn1.GoodsBarCodeKind == goodsBarCodeRevn2.GoodsBarCodeKind)
                 && (goodsBarCodeRevn1.CheckdigitCode == goodsBarCodeRevn2.CheckdigitCode)
                 && (goodsBarCodeRevn1.OfferDate == goodsBarCodeRevn2.OfferDate)
                 && (goodsBarCodeRevn1.OfferDataDiv == goodsBarCodeRevn2.OfferDataDiv)
                 && (goodsBarCodeRevn1.MakerName == goodsBarCodeRevn2.MakerName)
                 && (goodsBarCodeRevn1.GoodsName == goodsBarCodeRevn2.GoodsName));
        }
        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�GoodsBarCode�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsBarCode�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(GoodsBarCodeRevn target)
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
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsBarCode != target.GoodsBarCode) resList.Add("GoodsBarCode");
            if (this.GoodsBarCodeKind != target.GoodsBarCodeKind) resList.Add("GoodsBarCodeKind");
            if (this.CheckdigitCode != target.CheckdigitCode) resList.Add("CheckdigitCode");
            if (this.OfferDate != target.OfferDate) resList.Add("OfferDate");
            if (this.OfferDataDiv != target.OfferDataDiv) resList.Add("OfferDataDiv");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            return resList;
        }

        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���}�X�^��r����
        /// </summary>
        /// <param name="goodsBarCodeRevn1">��r����GoodsBarCode�N���X�̃C���X�^���X</param>
        /// <param name="goodsBarCodeRevn2">��r����GoodsBarCode�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsBarCode�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(GoodsBarCodeRevn goodsBarCodeRevn1, GoodsBarCodeRevn goodsBarCodeRevn2)
        {
            ArrayList resList = new ArrayList();
            if (goodsBarCodeRevn1.CreateDateTime != goodsBarCodeRevn2.CreateDateTime) resList.Add("CreateDateTime");
            if (goodsBarCodeRevn1.UpdateDateTime != goodsBarCodeRevn2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (goodsBarCodeRevn1.EnterpriseCode != goodsBarCodeRevn2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (goodsBarCodeRevn1.FileHeaderGuid != goodsBarCodeRevn2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (goodsBarCodeRevn1.UpdEmployeeCode != goodsBarCodeRevn2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (goodsBarCodeRevn1.UpdAssemblyId1 != goodsBarCodeRevn2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (goodsBarCodeRevn1.UpdAssemblyId2 != goodsBarCodeRevn2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (goodsBarCodeRevn1.LogicalDeleteCode != goodsBarCodeRevn2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (goodsBarCodeRevn1.GoodsMakerCd != goodsBarCodeRevn2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (goodsBarCodeRevn1.GoodsNo != goodsBarCodeRevn2.GoodsNo) resList.Add("GoodsNo");
            if (goodsBarCodeRevn1.GoodsBarCode != goodsBarCodeRevn2.GoodsBarCode) resList.Add("GoodsBarCode");
            if (goodsBarCodeRevn1.GoodsBarCodeKind != goodsBarCodeRevn2.GoodsBarCodeKind) resList.Add("GoodsBarCodeKind");
            if (goodsBarCodeRevn1.CheckdigitCode != goodsBarCodeRevn2.CheckdigitCode) resList.Add("CheckdigitCode");
            if (goodsBarCodeRevn1.OfferDate != goodsBarCodeRevn2.OfferDate) resList.Add("OfferDate");
            if (goodsBarCodeRevn1.OfferDataDiv != goodsBarCodeRevn2.OfferDataDiv) resList.Add("OfferDataDiv");
            if (goodsBarCodeRevn1.MakerName != goodsBarCodeRevn2.MakerName) resList.Add("MakerName");
            if (goodsBarCodeRevn1.GoodsName != goodsBarCodeRevn2.GoodsName) resList.Add("GoodsName");
            return resList;
        }
    }
}
