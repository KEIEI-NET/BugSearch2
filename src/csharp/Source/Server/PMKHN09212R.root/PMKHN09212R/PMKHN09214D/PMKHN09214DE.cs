using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;// ADD 2021/07/20 3H ���r �u�񋟃f�[�^�X�V�����v�@�\���V���A���C�Y��Q�Ή�

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GetUsrGoodsUnitDataWork
    /// <summary>
    ///                      �񋟃f�[�^���[�U�[���i�擾�N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �񋟃f�[�^���[�U�[���i�擾�N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/02/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GetUsrGoodsUnitDataWork : IFileHeader
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
        /// <remarks>�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h</remarks>
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
        private DateTime _offerDate;

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
        private DateTime _updateDate;

        /// <summary>�񋟃f�[�^�敪</summary>
        /// <remarks>0:���[�U�f�[�^,1:�񋟃f�[�^</remarks>
        private Int32 _offerDataDiv;

        /// <summary>�쐬����(���i)</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _priceCreateDateTime;

        /// <summary>�X�V����(���i)</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _priceUpdateDateTime;

        /// <summary>��ƃR�[�h(���i)</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _priceEnterpriseCode = "";

        /// <summary>GUID(���i)</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _priceFileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h(���i)</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _priceUpdEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1(���i)</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _priceUpdAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2(���i)</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _priceUpdAssemblyId2 = "";

        /// <summary>�_���폜�敪(���i)</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _priceLogicalDeleteCode;

        /// <summary>���i���[�J�[�R�[�h(���i)</summary>
        private Int32 _priceGoodsMakerCd;

        /// <summary>���i�ԍ�(���i)</summary>
        private string _priceGoodsNo = "";

        /// <summary>���i�J�n��(���i)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _pricePriceStartDate;

        /// <summary>�艿�i�����j</summary>
        private Double _priceListPrice;

        /// <summary>�����P��</summary>
        /// <remarks>�d���P�� �� ���㌴���œ���</remarks>
        private Double _priceSalesUnitCost;

        /// <summary>�d����</summary>
        private Double _priceStockRate;

        /// <summary>�I�[�v�����i�敪</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i</remarks>
        private Int32 _priceOpenPriceDiv;

        /// <summary>�񋟓��t(���i)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _priceOfferDate;

        /// <summary>�X�V�N����(���i)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _priceUpdateDate;

        /// <summary>�Ώی���</summary>
        private Int32 _priceCount;


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
        /// <value>�W���^�C�v13���܂��͒Z�k�^�C�v8����JAN�R�[�h</value>
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
        public DateTime OfferDate
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
        public DateTime UpdateDate
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

        /// public propaty name  :  PriceCreateDateTime
        /// <summary>�쐬����(���i)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬����(���i)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PriceCreateDateTime
        {
            get { return _priceCreateDateTime; }
            set { _priceCreateDateTime = value; }
        }

        /// public propaty name  :  PriceUpdateDateTime
        /// <summary>�X�V����(���i)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V����(���i)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PriceUpdateDateTime
        {
            get { return _priceUpdateDateTime; }
            set { _priceUpdateDateTime = value; }
        }

        /// public propaty name  :  PriceEnterpriseCode
        /// <summary>��ƃR�[�h(���i)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h(���i)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriceEnterpriseCode
        {
            get { return _priceEnterpriseCode; }
            set { _priceEnterpriseCode = value; }
        }

        /// public propaty name  :  PriceFileHeaderGuid
        /// <summary>GUID(���i)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID(���i)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid PriceFileHeaderGuid
        {
            get { return _priceFileHeaderGuid; }
            set { _priceFileHeaderGuid = value; }
        }

        /// public propaty name  :  PriceUpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h(���i)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h(���i)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriceUpdEmployeeCode
        {
            get { return _priceUpdEmployeeCode; }
            set { _priceUpdEmployeeCode = value; }
        }

        /// public propaty name  :  PriceUpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1(���i)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1(���i)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriceUpdAssemblyId1
        {
            get { return _priceUpdAssemblyId1; }
            set { _priceUpdAssemblyId1 = value; }
        }

        /// public propaty name  :  PriceUpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2(���i)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2(���i)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriceUpdAssemblyId2
        {
            get { return _priceUpdAssemblyId2; }
            set { _priceUpdAssemblyId2 = value; }
        }

        /// public propaty name  :  PriceLogicalDeleteCode
        /// <summary>�_���폜�敪(���i)�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪(���i)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceLogicalDeleteCode
        {
            get { return _priceLogicalDeleteCode; }
            set { _priceLogicalDeleteCode = value; }
        }

        /// public propaty name  :  PriceGoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h(���i)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���[�J�[�R�[�h(���i)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceGoodsMakerCd
        {
            get { return _priceGoodsMakerCd; }
            set { _priceGoodsMakerCd = value; }
        }

        /// public propaty name  :  PriceGoodsNo
        /// <summary>���i�ԍ�(���i)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�ԍ�(���i)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriceGoodsNo
        {
            get { return _priceGoodsNo; }
            set { _priceGoodsNo = value; }
        }

        /// public propaty name  :  PricePriceStartDate
        /// <summary>���i�J�n��(���i)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n��(���i)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PricePriceStartDate
        {
            get { return _pricePriceStartDate; }
            set { _pricePriceStartDate = value; }
        }

        /// public propaty name  :  PriceListPrice
        /// <summary>�艿�i�����j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PriceListPrice
        {
            get { return _priceListPrice; }
            set { _priceListPrice = value; }
        }

        /// public propaty name  :  PriceSalesUnitCost
        /// <summary>�����P���v���p�e�B</summary>
        /// <value>�d���P�� �� ���㌴���œ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PriceSalesUnitCost
        {
            get { return _priceSalesUnitCost; }
            set { _priceSalesUnitCost = value; }
        }

        /// public propaty name  :  PriceStockRate
        /// <summary>�d�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PriceStockRate
        {
            get { return _priceStockRate; }
            set { _priceStockRate = value; }
        }

        /// public propaty name  :  PriceOpenPriceDiv
        /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
        /// <value>0:�ʏ�^1:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceOpenPriceDiv
        {
            get { return _priceOpenPriceDiv; }
            set { _priceOpenPriceDiv = value; }
        }

        /// public propaty name  :  PriceOfferDate
        /// <summary>�񋟓��t(���i)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t(���i)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceOfferDate
        {
            get { return _priceOfferDate; }
            set { _priceOfferDate = value; }
        }

        /// public propaty name  :  PriceUpdateDate
        /// <summary>�X�V�N����(���i)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N����(���i)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceUpdateDate
        {
            get { return _priceUpdateDate; }
            set { _priceUpdateDate = value; }
        }

        /// public propaty name  :  PriceCount
        /// <summary>�Ώی����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ώی����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceCount
        {
            get { return _priceCount; }
            set { _priceCount = value; }
        }


        /// <summary>
        /// �񋟃f�[�^���[�U�[���i�擾�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>GetUsrGoodsUnitDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GetUsrGoodsUnitDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GetUsrGoodsUnitDataWork()
        {
        }

    }

    // --- ADD 2021/07/20 3H ���r �u�񋟃f�[�^�X�V�����v�@�\���V���A���C�Y��Q�Ή�----->>>>>
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>GetUsrGoodsUnitDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   GetUsrGoodsUnitDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class GetUsrGoodsUnitDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GetUsrGoodsUnitDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  GetUsrGoodsUnitDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is GetUsrGoodsUnitDataWork || graph is ArrayList || graph is GetUsrGoodsUnitDataWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(GetUsrGoodsUnitDataWork).FullName));

            if (graph != null && graph is GetUsrGoodsUnitDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GetUsrGoodsUnitDataWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is GetUsrGoodsUnitDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((GetUsrGoodsUnitDataWork[])graph).Length;
            }
            else if (graph is GetUsrGoodsUnitDataWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //�_���폜�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //���i���̃J�i
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNameKana
            //JAN�R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //Jan
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //�\������
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
            //���i�|�������N
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //�ېŋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //�n�C�t�������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoNoneHyphen
            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int64)); //OfferDate
            //���i����
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //���i���l�P
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNote1
            //���i���l�Q
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNote2
            //���i�K�i�E���L����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsSpecialNote
            //���Е��ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //�X�V�N����
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDate
            //�񋟃f�[�^�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDataDiv
            //�쐬����(���i)
            serInfo.MemberInfo.Add(typeof(Int64)); //PriceCreateDateTime
            //�X�V����(���i)
            serInfo.MemberInfo.Add(typeof(Int64)); //PriceUpdateDateTime
            //��ƃR�[�h(���i)
            serInfo.MemberInfo.Add(typeof(string)); //PriceEnterpriseCode
            //GUID(���i)
            serInfo.MemberInfo.Add(typeof(byte[]));  //PriceFileHeaderGuid
            //�X�V�]�ƈ��R�[�h(���i)
            serInfo.MemberInfo.Add(typeof(string)); //PriceUpdEmployeeCode
            //�X�V�A�Z���u��ID1(���i)
            serInfo.MemberInfo.Add(typeof(string)); //PriceUpdAssemblyId1
            //�X�V�A�Z���u��ID2(���i)
            serInfo.MemberInfo.Add(typeof(string)); //PriceUpdAssemblyId2
            //�_���폜�敪(���i)
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceLogicalDeleteCode
            //���i���[�J�[�R�[�h(���i)
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceGoodsMakerCd
            //���i�ԍ�(���i)
            serInfo.MemberInfo.Add(typeof(string)); //PriceGoodsNo
            //���i�J�n��(���i)
            serInfo.MemberInfo.Add(typeof(Int32)); //PricePriceStartDate
            //�艿�i�����j
            serInfo.MemberInfo.Add(typeof(Double)); //PriceListPrice
            //�����P��
            serInfo.MemberInfo.Add(typeof(Double)); //PriceSalesUnitCost
            //�d����
            serInfo.MemberInfo.Add(typeof(Double)); //PriceStockRate
            //�I�[�v�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceOpenPriceDiv
            //�񋟓��t(���i)
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceOfferDate
            //�X�V�N����(���i)
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceUpdateDate
            //�Ώی���
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCount


            serInfo.Serialize(writer, serInfo);
            if (graph is GetUsrGoodsUnitDataWork)
            {
                GetUsrGoodsUnitDataWork temp = (GetUsrGoodsUnitDataWork)graph;

                SetGetUsrGoodsUnitDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is GetUsrGoodsUnitDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((GetUsrGoodsUnitDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (GetUsrGoodsUnitDataWork temp in lst)
                {
                    SetGetUsrGoodsUnitDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// GetUsrGoodsUnitDataWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 44;

        /// <summary>
        ///  GetUsrGoodsUnitDataWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GetUsrGoodsUnitDataWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetGetUsrGoodsUnitDataWork(System.IO.BinaryWriter writer, GetUsrGoodsUnitDataWork temp)
        {
            //�쐬����
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.UpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.UpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.UpdAssemblyId2);
            //�_���폜�敪
            writer.Write(temp.LogicalDeleteCode);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i����
            writer.Write(temp.GoodsName);
            //���i���̃J�i
            writer.Write(temp.GoodsNameKana);
            //JAN�R�[�h
            writer.Write(temp.Jan);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //�\������
            writer.Write(temp.DisplayOrder);
            //���i�|�������N
            writer.Write(temp.GoodsRateRank);
            //�ېŋ敪
            writer.Write(temp.TaxationDivCd);
            //�n�C�t�������i�ԍ�
            writer.Write(temp.GoodsNoNoneHyphen);
            //�񋟓��t
            writer.Write((Int64)temp.OfferDate.Ticks);
            //���i����
            writer.Write(temp.GoodsKindCode);
            //���i���l�P
            writer.Write(temp.GoodsNote1);
            //���i���l�Q
            writer.Write(temp.GoodsNote2);
            //���i�K�i�E���L����
            writer.Write(temp.GoodsSpecialNote);
            //���Е��ރR�[�h
            writer.Write(temp.EnterpriseGanreCode);
            //�X�V�N����
            writer.Write((Int64)temp.UpdateDate.Ticks);
            //�񋟃f�[�^�敪
            writer.Write(temp.OfferDataDiv);
            //�쐬����(���i)
            writer.Write((Int64)temp.PriceCreateDateTime.Ticks);
            //�X�V����(���i)
            writer.Write((Int64)temp.PriceUpdateDateTime.Ticks);
            //��ƃR�[�h(���i)
            writer.Write(temp.PriceEnterpriseCode);
            //GUID(���i)
            byte[] priceFileHeaderGuidArray = temp.PriceFileHeaderGuid.ToByteArray();
            writer.Write(priceFileHeaderGuidArray.Length);
            writer.Write(temp.PriceFileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h(���i)
            writer.Write(temp.PriceUpdEmployeeCode);
            //�X�V�A�Z���u��ID1(���i)
            writer.Write(temp.PriceUpdAssemblyId1);
            //�X�V�A�Z���u��ID2(���i)
            writer.Write(temp.PriceUpdAssemblyId2);
            //�_���폜�敪(���i)
            writer.Write(temp.PriceLogicalDeleteCode);
            //���i���[�J�[�R�[�h(���i)
            writer.Write(temp.PriceGoodsMakerCd);
            //���i�ԍ�(���i)
            writer.Write(temp.PriceGoodsNo);
            //���i�J�n��(���i)
            writer.Write(temp.PricePriceStartDate);
            //�艿�i�����j
            writer.Write(temp.PriceListPrice);
            //�����P��
            writer.Write(temp.PriceSalesUnitCost);
            //�d����
            writer.Write(temp.PriceStockRate);
            //�I�[�v�����i�敪
            writer.Write(temp.PriceOpenPriceDiv);
            //�񋟓��t(���i)
            writer.Write(temp.PriceOfferDate);
            //�X�V�N����(���i)
            writer.Write(temp.PriceUpdateDate);
            //�Ώی���
            writer.Write(temp.PriceCount);

        }

        /// <summary>
        ///  GetUsrGoodsUnitDataWork�C���X�^���X�擾
        /// </summary>
        /// <returns>GetUsrGoodsUnitDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GetUsrGoodsUnitDataWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private GetUsrGoodsUnitDataWork GetGetUsrGoodsUnitDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            GetUsrGoodsUnitDataWork temp = new GetUsrGoodsUnitDataWork();

            //�쐬����
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.UpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪
            temp.LogicalDeleteCode = reader.ReadInt32();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i����
            temp.GoodsName = reader.ReadString();
            //���i���̃J�i
            temp.GoodsNameKana = reader.ReadString();
            //JAN�R�[�h
            temp.Jan = reader.ReadString();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //�\������
            temp.DisplayOrder = reader.ReadInt32();
            //���i�|�������N
            temp.GoodsRateRank = reader.ReadString();
            //�ېŋ敪
            temp.TaxationDivCd = reader.ReadInt32();
            //�n�C�t�������i�ԍ�
            temp.GoodsNoNoneHyphen = reader.ReadString();
            //�񋟓��t
            temp.OfferDate = new DateTime(reader.ReadInt64());
            //���i����
            temp.GoodsKindCode = reader.ReadInt32();
            //���i���l�P
            temp.GoodsNote1 = reader.ReadString();
            //���i���l�Q
            temp.GoodsNote2 = reader.ReadString();
            //���i�K�i�E���L����
            temp.GoodsSpecialNote = reader.ReadString();
            //���Е��ރR�[�h
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //�X�V�N����
            temp.UpdateDate = new DateTime(reader.ReadInt64());
            //�񋟃f�[�^�敪
            temp.OfferDataDiv = reader.ReadInt32();
            //�쐬����(���i)
            temp.PriceCreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����(���i)
            temp.PriceUpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h(���i)
            temp.PriceEnterpriseCode = reader.ReadString();
            //GUID(���i)
            int lenOfPriceFileHeaderGuidArray = reader.ReadInt32();
            byte[] priceFileHeaderGuidArray = reader.ReadBytes(lenOfPriceFileHeaderGuidArray);
            temp.PriceFileHeaderGuid = new Guid(priceFileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h(���i)
            temp.PriceUpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1(���i)
            temp.PriceUpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2(���i)
            temp.PriceUpdAssemblyId2 = reader.ReadString();
            //�_���폜�敪(���i)
            temp.PriceLogicalDeleteCode = reader.ReadInt32();
            //���i���[�J�[�R�[�h(���i)
            temp.PriceGoodsMakerCd = reader.ReadInt32();
            //���i�ԍ�(���i)
            temp.PriceGoodsNo = reader.ReadString();
            //���i�J�n��(���i)
            temp.PricePriceStartDate = reader.ReadInt32();
            //�艿�i�����j
            temp.PriceListPrice = reader.ReadDouble();
            //�����P��
            temp.PriceSalesUnitCost = reader.ReadDouble();
            //�d����
            temp.PriceStockRate = reader.ReadDouble();
            //�I�[�v�����i�敪
            temp.PriceOpenPriceDiv = reader.ReadInt32();
            //�񋟓��t(���i)
            temp.PriceOfferDate = reader.ReadInt32();
            //�X�V�N����(���i)
            temp.PriceUpdateDate = reader.ReadInt32();
            //�Ώی���
            temp.PriceCount = reader.ReadInt32();


            //�ȉ��͓ǂݔ�΂��ł��B���̃o�[�W�������z�肷�� EmployeeWork�^�ȍ~�̃o�[�W������
            //�f�[�^���f�V���A���C�Y����ꍇ�A�V���A���C�Y�����t�H�[�}�b�^���L�q����
            //�^���ɂ��������āA�X�g���[���������ǂݏo���܂�...�Ƃ����Ă�
            //�ǂݏo���Ď̂Ă邱�ƂɂȂ�܂��B
            for (int k = currentMemberCount; k < serInfo.MemberInfo.Count; ++k)
            {
                //byte[],char[]���f�V���A���C�Y���钼�O�ɁA����length��
                //�f�V���A���C�Y����Ă���P�[�X������Abyte[],char[]��
                //�f�V���A���C�Y�ɂ�length���K�v�Ȃ̂�int�^�̃f�[�^���f
                //�V���A���C�Y�����ꍇ�́A���̒l�����̕ϐ��ɑޔ����܂��B
                int optCount = 0;
                object oMemberType = serInfo.MemberInfo[k];
                if (oMemberType is Type)
                {
                    Type t = (Type)oMemberType;
                    object oData = TypeDeserializer.DeserializePrimitiveType(reader, t, optCount);
                    if (t.Equals(typeof(int)))
                    {
                        optCount = Convert.ToInt32(oData);
                    }
                    else
                    {
                        optCount = 0;
                    }
                }
                else if (oMemberType is string)
                {
                    Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate((string)oMemberType);
                    object userData = formatter.Deserialize(reader);  //�ǂݔ�΂�
                }
            }
            return temp;
        }

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���f�V���A���C�U�ł�
        /// </summary>
        /// <returns>GetUsrGoodsUnitDataWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GetUsrGoodsUnitDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                GetUsrGoodsUnitDataWork temp = GetGetUsrGoodsUnitDataWork(reader, serInfo);
                lst.Add(temp);
            }
            switch (serInfo.RetTypeInfo)
            {
                case 0:
                    retValue = lst;
                    break;
                case 1:
                    retValue = lst[0];
                    break;
                case 2:
                    retValue = (GetUsrGoodsUnitDataWork[])lst.ToArray(typeof(GetUsrGoodsUnitDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
    // --- ADD 2021/07/20 3H ���r �u�񋟃f�[�^�X�V�����v�@�\���V���A���C�Y��Q�Ή�-----<<<<<
}
