using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsU
    /// <summary>
    ///                      ���i�}�X�^�i���[�U�[�o�^���j
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�}�X�^�i���[�U�[�o�^���j�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2011/07/22</br>
    /// <br>Genarated Date   :   2011/07/22  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   ����g</br>
    /// <br>                 :   �A��1029  �V�K</br>
    /// </remarks>
    public class GoodsU
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

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>���i���̃J�i</summary>
        private string _goodsNameKana = "";

        /// <summary>JAN�R�[�h</summary>
        private string _jan = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>�\������</summary>
        private Int32 _displayOrder;

        /// <summary>���i�|�������N</summary>
        /// <remarks>�w��</remarks>
        private string _goodsRateRank = "";

        /// <summary>�ېŋ敪</summary>
        /// <remarks>0:�ې�,1:��ې�,2:�ېŁi���Łj</remarks>
        private Int32 _taxationDivCd;

        /// <summary>�n�C�t�������i�ԍ�</summary>
        private string _goodsNoNoneHyphen = "";

        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _offerDate;

        /// <summary>���i����</summary>
        /// <remarks>0:�����@1:���̑�</remarks>
        private Int32 _goodsKindCode;

        /// <summary>���i���l�P</summary>
        private string _goodsNote1 = "";

        /// <summary>���i���l�Q</summary>
        private string _goodsNote2 = "";

        /// <summary>���i�K�i�E���L����</summary>
        private string _goodsSpecialNote = "";

        /// <summary>���Е��ރR�[�h</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>�X�V�N����</summary>
        private Int32 _updateDate;

        /// <summary>�񋟃f�[�^�敪</summary>
        /// <remarks>0:���[�U�f�[�^,1:�񋟃f�[�^</remarks>
        private Int32 _offerDataDiv;

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

        /// public propaty name  :  GoodsNameKana
        /// <summary>���i���̃J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  Jan
        /// <summary>JAN�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   JAN�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Jan
        {
            get { return _jan; }
            set { _jan = value; }
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

        /// public propaty name  :  DisplayOrder
        /// <summary>�\�����ʃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �\�����ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DisplayOrder
        {
            get { return _displayOrder; }
            set { _displayOrder = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>���i�|�������N�v���p�e�B</summary>
        /// <value>�w��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|�������N�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې�,1:��ې�,2:�ېŁi���Łj</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ېŋ敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TaxationDivCd
        {
            get { return _taxationDivCd; }
            set { _taxationDivCd = value; }
        }

        /// public propaty name  :  GoodsNoNoneHyphen
        /// <summary>�n�C�t�������i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �n�C�t�������i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoNoneHyphen
        {
            get { return _goodsNoNoneHyphen; }
            set { _goodsNoNoneHyphen = value; }
        }

        /// public propaty name  :  OfferDate
        /// <summary>�񋟓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
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

        /// public propaty name  :  GoodsKindCode
        /// <summary>���i�����v���p�e�B</summary>
        /// <value>0:�����@1:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        /// public propaty name  :  GoodsNote1
        /// <summary>���i���l�P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���l�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNote1
        {
            get { return _goodsNote1; }
            set { _goodsNote1 = value; }
        }

        /// public propaty name  :  GoodsNote2
        /// <summary>���i���l�Q�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���l�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNote2
        {
            get { return _goodsNote2; }
            set { _goodsNote2 = value; }
        }

        /// public propaty name  :  GoodsSpecialNote
        /// <summary>���i�K�i�E���L�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�K�i�E���L�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsSpecialNote
        {
            get { return _goodsSpecialNote; }
            set { _goodsSpecialNote = value; }
        }

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>���Е��ރR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Е��ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  UpdateDate
        /// <summary>�X�V�N�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UpdateDate
        {
            get { return _updateDate; }
            set { _updateDate = value; }
        }

        /// public propaty name  :  OfferDataDiv
        /// <summary>�񋟃f�[�^�敪�v���p�e�B</summary>
        /// <value>0:���[�U�f�[�^,1:�񋟃f�[�^</value>
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
        /// ���i�}�X�^�i���[�U�[�o�^���j�R���X�g���N�^
        /// </summary>
        /// <returns>GoodsU�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsU�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsU()
        {
        }

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j�R���X�g���N�^
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
        /// <param name="goodsName">���i����</param>
        /// <param name="goodsNameKana">���i���̃J�i</param>
        /// <param name="jan">JAN�R�[�h</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="displayOrder">�\������</param>
        /// <param name="goodsRateRank">���i�|�������N(�w��)</param>
        /// <param name="taxationDivCd">�ېŋ敪(0:�ې�,1:��ې�,2:�ېŁi���Łj)</param>
        /// <param name="goodsNoNoneHyphen">�n�C�t�������i�ԍ�</param>
        /// <param name="offerDate">�񋟓��t(YYYYMMDD)</param>
        /// <param name="goodsKindCode">���i����(0:�����@1:���̑�)</param>
        /// <param name="goodsNote1">���i���l�P</param>
        /// <param name="goodsNote2">���i���l�Q</param>
        /// <param name="goodsSpecialNote">���i�K�i�E���L����</param>
        /// <param name="enterpriseGanreCode">���Е��ރR�[�h</param>
        /// <param name="updateDate">�X�V�N����</param>
        /// <param name="offerDataDiv">�񋟃f�[�^�敪(0:���[�U�f�[�^,1:�񋟃f�[�^)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="updEmployeeName">�X�V�]�ƈ�����</param>
        /// <returns>GoodsU�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsU�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsU(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 goodsMakerCd, string goodsNo, string goodsName, string goodsNameKana, string jan, Int32 bLGoodsCode, Int32 displayOrder, string goodsRateRank, Int32 taxationDivCd, string goodsNoNoneHyphen, Int32 offerDate, Int32 goodsKindCode, string goodsNote1, string goodsNote2, string goodsSpecialNote, Int32 enterpriseGanreCode, Int32 updateDate, Int32 offerDataDiv, string enterpriseName, string updEmployeeName)
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
            this._goodsName = goodsName;
            this._goodsNameKana = goodsNameKana;
            this._jan = jan;
            this._bLGoodsCode = bLGoodsCode;
            this._displayOrder = displayOrder;
            this._goodsRateRank = goodsRateRank;
            this._taxationDivCd = taxationDivCd;
            this._goodsNoNoneHyphen = goodsNoNoneHyphen;
            this._offerDate = offerDate;
            this._goodsKindCode = goodsKindCode;
            this._goodsNote1 = goodsNote1;
            this._goodsNote2 = goodsNote2;
            this._goodsSpecialNote = goodsSpecialNote;
            this._enterpriseGanreCode = enterpriseGanreCode;
            this._updateDate = updateDate;
            this._offerDataDiv = offerDataDiv;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;

        }

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j��������
        /// </summary>
        /// <returns>GoodsU�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����GoodsU�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsU Clone()
        {
            return new GoodsU(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._goodsMakerCd, this._goodsNo, this._goodsName, this._goodsNameKana, this._jan, this._bLGoodsCode, this._displayOrder, this._goodsRateRank, this._taxationDivCd, this._goodsNoNoneHyphen, this._offerDate, this._goodsKindCode, this._goodsNote1, this._goodsNote2, this._goodsSpecialNote, this._enterpriseGanreCode, this._updateDate, this._offerDataDiv, this._enterpriseName, this._updEmployeeName);
        }

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�GoodsU�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsU�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(GoodsU target)
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
                 && (this.GoodsName == target.GoodsName)
                 && (this.GoodsNameKana == target.GoodsNameKana)
                 && (this.Jan == target.Jan)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.DisplayOrder == target.DisplayOrder)
                 && (this.GoodsRateRank == target.GoodsRateRank)
                 && (this.TaxationDivCd == target.TaxationDivCd)
                 && (this.GoodsNoNoneHyphen == target.GoodsNoNoneHyphen)
                 && (this.OfferDate == target.OfferDate)
                 && (this.GoodsKindCode == target.GoodsKindCode)
                 && (this.GoodsNote1 == target.GoodsNote1)
                 && (this.GoodsNote2 == target.GoodsNote2)
                 && (this.GoodsSpecialNote == target.GoodsSpecialNote)
                 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
                 && (this.UpdateDate == target.UpdateDate)
                 && (this.OfferDataDiv == target.OfferDataDiv)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName));
        }

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j��r����
        /// </summary>
        /// <param name="goodsU1">
        ///                    ��r����GoodsU�N���X�̃C���X�^���X
        /// </param>
        /// <param name="goodsU2">��r����GoodsU�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsU�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(GoodsU goodsU1, GoodsU goodsU2)
        {
            return ((goodsU1.CreateDateTime == goodsU2.CreateDateTime)
                 && (goodsU1.UpdateDateTime == goodsU2.UpdateDateTime)
                 && (goodsU1.EnterpriseCode == goodsU2.EnterpriseCode)
                 && (goodsU1.FileHeaderGuid == goodsU2.FileHeaderGuid)
                 && (goodsU1.UpdEmployeeCode == goodsU2.UpdEmployeeCode)
                 && (goodsU1.UpdAssemblyId1 == goodsU2.UpdAssemblyId1)
                 && (goodsU1.UpdAssemblyId2 == goodsU2.UpdAssemblyId2)
                 && (goodsU1.LogicalDeleteCode == goodsU2.LogicalDeleteCode)
                 && (goodsU1.GoodsMakerCd == goodsU2.GoodsMakerCd)
                 && (goodsU1.GoodsNo == goodsU2.GoodsNo)
                 && (goodsU1.GoodsName == goodsU2.GoodsName)
                 && (goodsU1.GoodsNameKana == goodsU2.GoodsNameKana)
                 && (goodsU1.Jan == goodsU2.Jan)
                 && (goodsU1.BLGoodsCode == goodsU2.BLGoodsCode)
                 && (goodsU1.DisplayOrder == goodsU2.DisplayOrder)
                 && (goodsU1.GoodsRateRank == goodsU2.GoodsRateRank)
                 && (goodsU1.TaxationDivCd == goodsU2.TaxationDivCd)
                 && (goodsU1.GoodsNoNoneHyphen == goodsU2.GoodsNoNoneHyphen)
                 && (goodsU1.OfferDate == goodsU2.OfferDate)
                 && (goodsU1.GoodsKindCode == goodsU2.GoodsKindCode)
                 && (goodsU1.GoodsNote1 == goodsU2.GoodsNote1)
                 && (goodsU1.GoodsNote2 == goodsU2.GoodsNote2)
                 && (goodsU1.GoodsSpecialNote == goodsU2.GoodsSpecialNote)
                 && (goodsU1.EnterpriseGanreCode == goodsU2.EnterpriseGanreCode)
                 && (goodsU1.UpdateDate == goodsU2.UpdateDate)
                 && (goodsU1.OfferDataDiv == goodsU2.OfferDataDiv)
                 && (goodsU1.EnterpriseName == goodsU2.EnterpriseName)
                 && (goodsU1.UpdEmployeeName == goodsU2.UpdEmployeeName));
        }
        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�GoodsU�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsU�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(GoodsU target)
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
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GoodsNameKana != target.GoodsNameKana) resList.Add("GoodsNameKana");
            if (this.Jan != target.Jan) resList.Add("Jan");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.DisplayOrder != target.DisplayOrder) resList.Add("DisplayOrder");
            if (this.GoodsRateRank != target.GoodsRateRank) resList.Add("GoodsRateRank");
            if (this.TaxationDivCd != target.TaxationDivCd) resList.Add("TaxationDivCd");
            if (this.GoodsNoNoneHyphen != target.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (this.OfferDate != target.OfferDate) resList.Add("OfferDate");
            if (this.GoodsKindCode != target.GoodsKindCode) resList.Add("GoodsKindCode");
            if (this.GoodsNote1 != target.GoodsNote1) resList.Add("GoodsNote1");
            if (this.GoodsNote2 != target.GoodsNote2) resList.Add("GoodsNote2");
            if (this.GoodsSpecialNote != target.GoodsSpecialNote) resList.Add("GoodsSpecialNote");
            if (this.EnterpriseGanreCode != target.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (this.UpdateDate != target.UpdateDate) resList.Add("UpdateDate");
            if (this.OfferDataDiv != target.OfferDataDiv) resList.Add("OfferDataDiv");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }

        /// <summary>
        /// ���i�}�X�^�i���[�U�[�o�^���j��r����
        /// </summary>
        /// <param name="goodsU1">��r����GoodsU�N���X�̃C���X�^���X</param>
        /// <param name="goodsU2">��r����GoodsU�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsU�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(GoodsU goodsU1, GoodsU goodsU2)
        {
            ArrayList resList = new ArrayList();
            if (goodsU1.CreateDateTime != goodsU2.CreateDateTime) resList.Add("CreateDateTime");
            if (goodsU1.UpdateDateTime != goodsU2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (goodsU1.EnterpriseCode != goodsU2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (goodsU1.FileHeaderGuid != goodsU2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (goodsU1.UpdEmployeeCode != goodsU2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (goodsU1.UpdAssemblyId1 != goodsU2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (goodsU1.UpdAssemblyId2 != goodsU2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (goodsU1.LogicalDeleteCode != goodsU2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (goodsU1.GoodsMakerCd != goodsU2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (goodsU1.GoodsNo != goodsU2.GoodsNo) resList.Add("GoodsNo");
            if (goodsU1.GoodsName != goodsU2.GoodsName) resList.Add("GoodsName");
            if (goodsU1.GoodsNameKana != goodsU2.GoodsNameKana) resList.Add("GoodsNameKana");
            if (goodsU1.Jan != goodsU2.Jan) resList.Add("Jan");
            if (goodsU1.BLGoodsCode != goodsU2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (goodsU1.DisplayOrder != goodsU2.DisplayOrder) resList.Add("DisplayOrder");
            if (goodsU1.GoodsRateRank != goodsU2.GoodsRateRank) resList.Add("GoodsRateRank");
            if (goodsU1.TaxationDivCd != goodsU2.TaxationDivCd) resList.Add("TaxationDivCd");
            if (goodsU1.GoodsNoNoneHyphen != goodsU2.GoodsNoNoneHyphen) resList.Add("GoodsNoNoneHyphen");
            if (goodsU1.OfferDate != goodsU2.OfferDate) resList.Add("OfferDate");
            if (goodsU1.GoodsKindCode != goodsU2.GoodsKindCode) resList.Add("GoodsKindCode");
            if (goodsU1.GoodsNote1 != goodsU2.GoodsNote1) resList.Add("GoodsNote1");
            if (goodsU1.GoodsNote2 != goodsU2.GoodsNote2) resList.Add("GoodsNote2");
            if (goodsU1.GoodsSpecialNote != goodsU2.GoodsSpecialNote) resList.Add("GoodsSpecialNote");
            if (goodsU1.EnterpriseGanreCode != goodsU2.EnterpriseGanreCode) resList.Add("EnterpriseGanreCode");
            if (goodsU1.UpdateDate != goodsU2.UpdateDate) resList.Add("UpdateDate");
            if (goodsU1.OfferDataDiv != goodsU2.OfferDataDiv) resList.Add("OfferDataDiv");
            if (goodsU1.EnterpriseName != goodsU2.EnterpriseName) resList.Add("EnterpriseName");
            if (goodsU1.UpdEmployeeName != goodsU2.UpdEmployeeName) resList.Add("UpdEmployeeName");

            return resList;
        }
    }
}
