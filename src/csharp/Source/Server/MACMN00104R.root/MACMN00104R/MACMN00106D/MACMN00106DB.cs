using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsUnitDataWork
    /// <summary>
    ///                      ���i�A���f�[�^�N���X���[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�A���f�[�^�N���X���[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/06/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsUnitDataWork : IFileHeader
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

        /// <summary>���[�J�[����</summary>
        /// <remarks>���[�J�}�X�^���擾</remarks>
        private string _makerName = "";

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

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        /// <remarks>BL���i�R�[�h�}�X�^���擾</remarks>
        private string _bLGoodsFullName = "";

        /// <summary>�\������</summary>
        private Int32 _displayOrder;

        /// <summary>���i�啪�ރR�[�h</summary>
        /// <remarks>���啪�ށi���[�U�[�K�C�h�j</remarks>
        private Int32 _goodsLGroup;

        /// <summary>���i�啪�ޖ���</summary>
        private string _goodsLGroupName = "";

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>�������ށi�}�X�^�L�j</remarks>
        private Int32 _goodsMGroup;

        /// <summary>���i�����ޖ���</summary>
        private string _goodsMGroupName = "";

        /// <summary>BL�O���[�v�R�[�h</summary>
        /// <remarks>���O���[�v�R�[�h</remarks>
        private Int32 _bLGroupCode;

        /// <summary>BL�O���[�v�R�[�h����</summary>
        private string _bLGroupName = "";

        /// <summary>���i�|�������N</summary>
        /// <remarks>�w��</remarks>
        private string _goodsRateRank = "";

        /// <summary>�ېŋ敪</summary>
        private Int32 _taxationDivCd;

        /// <summary>�n�C�t�������i�ԍ�</summary>
        private string _goodsNoNoneHyphen = "";

        /// <summary>�񋟓��t</summary>
        private DateTime _offerDate;

        /// <summary>���i����</summary>
        private Int32 _goodsKindCode;

        /// <summary>���i���l�P</summary>
        private string _goodsNote1 = "";

        /// <summary>���i���l�Q</summary>
        private string _goodsNote2 = "";

        /// <summary>���i�K�i�E���L����</summary>
        private string _goodsSpecialNote = "";

        /// <summary>���Е��ރR�[�h</summary>
        private Int32 _enterpriseGanreCode;

        /// <summary>���Е��ޖ���</summary>
        /// <remarks>���[�U�[�K�C�h���擾</remarks>
        private string _enterpriseGanreName = "";

        /// <summary>�X�V�N����</summary>
        private DateTime _updateDate;

        /// <summary>���i�|���O���[�v�R�[�h</summary>
        /// <remarks>BL�R�[�h�}�X�^���擾</remarks>
        private Int32 _goodsRateGrpCode;

        /// <summary>�̔��敪�R�[�h</summary>
        /// <remarks>BL�O���[�v�}�X�^���擾</remarks>
        private Int32 _salesCode;

        /// <summary>�쐬����</summary>
        /// <remarks>���i�}�X�^���擾</remarks>
        private DateTime _goodsPriceCreateDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���i�}�X�^���擾</remarks>
        private DateTime _goodsPriceUpdateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���i�}�X�^���擾</remarks>
        private string _goodsPriceEnterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���i�}�X�^���擾</remarks>
        private Guid _goodsPriceFileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���i�}�X�^���擾</remarks>
        private string _goodsPriceUpdEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���i�}�X�^���擾</remarks>
        private string _goodsPriceUpdAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���i�}�X�^���擾</remarks>
        private string _goodsPriceUpdAssemblyId2 = "";

        /// <summary>���i�J�n��</summary>
        /// <remarks>YYYYMMDD ���i�}�X�^���擾</remarks>
        private DateTime _goodsPricePriceStartDate;

        /// <summary>�艿�i�����j</summary>
        /// <remarks>���i�}�X�^���擾</remarks>
        private Double _goodsPriceListPrice;

        /// <summary>�����P��</summary>
        /// <remarks>�d���P�� �� ���㌴���œ��� ���i�}�X�^���擾</remarks>
        private Double _goodsPriceSalesUnitCost;

        /// <summary>�d����</summary>
        /// <remarks>���i�}�X�^���擾</remarks>
        private Double _goodsPriceStockRate;

        /// <summary>�I�[�v�����i�敪</summary>
        /// <remarks>0:�ʏ�^1:�I�[�v�����i ���i�}�X�^���擾</remarks>
        private Int32 _goodsPriceOpenPriceDiv;

        /// <summary>�񋟓��t</summary>
        /// <remarks>YYYYMMDD ���i�}�X�^���擾</remarks>
        private DateTime _goodsPriceOfferDate;

        /// <summary>�X�V�N����</summary>
        /// <remarks>YYYYMMDD ���i�}�X�^���擾</remarks>
        private DateTime _goodsPriceUpdateDate;

        /// <summary>�q�ɃR�[�h</summary>
        /// <remarks>�݌Ƀ}�X�^���擾</remarks>
        private string _warehouseCode = "";

        /// <summary>�q�ɖ���</summary>
        /// <remarks>�q�Ƀ}�X�^���擾</remarks>
        private string _warehouseName = "";

        /// <summary>�o�׉\��</summary>
        /// <remarks>�݌Ƀ}�X�^���擾</remarks>
        private Double _shipmentPosCnt;

        /// <summary>�q�ɒI��</summary>
        /// <remarks>�݌Ƀ}�X�^���擾</remarks>
        private string _warehouseShelfNo = "";


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

        /// public propaty name  :  MakerName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// <value>���[�J�}�X�^���擾</value>
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

        /// public propaty name  :  BLGoodsFullName
        /// <summary>BL���i�R�[�h���́i�S�p�j�v���p�e�B</summary>
        /// <value>BL���i�R�[�h�}�X�^���擾</value>
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

        /// public propaty name  :  GoodsLGroup
        /// <summary>���i�啪�ރR�[�h�v���p�e�B</summary>
        /// <value>���啪�ށi���[�U�[�K�C�h�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsLGroup
        {
            get { return _goodsLGroup; }
            set { _goodsLGroup = value; }
        }

        /// public propaty name  :  GoodsLGroupName
        /// <summary>���i�啪�ޖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�啪�ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsLGroupName
        {
            get { return _goodsLGroupName; }
            set { _goodsLGroupName = value; }
        }

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// <value>�������ށi�}�X�^�L�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMGroup
        {
            get { return _goodsMGroup; }
            set { _goodsMGroup = value; }
        }

        /// public propaty name  :  GoodsMGroupName
        /// <summary>���i�����ޖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMGroupName
        {
            get { return _goodsMGroupName; }
            set { _goodsMGroupName = value; }
        }

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
        /// <value>���O���[�v�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCode
        {
            get { return _bLGroupCode; }
            set { _bLGroupCode = value; }
        }

        /// public propaty name  :  BLGroupName
        /// <summary>BL�O���[�v�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGroupName
        {
            get { return _bLGroupName; }
            set { _bLGroupName = value; }
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

        /// public propaty name  :  EnterpriseGanreName
        /// <summary>���Е��ޖ��̃v���p�e�B</summary>
        /// <value>���[�U�[�K�C�h���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Е��ޖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseGanreName
        {
            get { return _enterpriseGanreName; }
            set { _enterpriseGanreName = value; }
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

        /// public propaty name  :  GoodsRateGrpCode
        /// <summary>���i�|���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�|���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsRateGrpCode
        {
            get { return _goodsRateGrpCode; }
            set { _goodsRateGrpCode = value; }
        }

        /// public propaty name  :  SalesCode
        /// <summary>�̔��敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCode
        {
            get { return _salesCode; }
            set { _salesCode = value; }
        }

        /// public propaty name  :  GoodsPriceCreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���i�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime GoodsPriceCreateDateTime
        {
            get { return _goodsPriceCreateDateTime; }
            set { _goodsPriceCreateDateTime = value; }
        }

        /// public propaty name  :  GoodsPriceUpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���i�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime GoodsPriceUpdateDateTime
        {
            get { return _goodsPriceUpdateDateTime; }
            set { _goodsPriceUpdateDateTime = value; }
        }

        /// public propaty name  :  GoodsPriceEnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���i�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsPriceEnterpriseCode
        {
            get { return _goodsPriceEnterpriseCode; }
            set { _goodsPriceEnterpriseCode = value; }
        }

        /// public propaty name  :  GoodsPriceFileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���i�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid GoodsPriceFileHeaderGuid
        {
            get { return _goodsPriceFileHeaderGuid; }
            set { _goodsPriceFileHeaderGuid = value; }
        }

        /// public propaty name  :  GoodsPriceUpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���i�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsPriceUpdEmployeeCode
        {
            get { return _goodsPriceUpdEmployeeCode; }
            set { _goodsPriceUpdEmployeeCode = value; }
        }

        /// public propaty name  :  GoodsPriceUpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���i�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsPriceUpdAssemblyId1
        {
            get { return _goodsPriceUpdAssemblyId1; }
            set { _goodsPriceUpdAssemblyId1 = value; }
        }

        /// public propaty name  :  GoodsPriceUpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���i�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsPriceUpdAssemblyId2
        {
            get { return _goodsPriceUpdAssemblyId2; }
            set { _goodsPriceUpdAssemblyId2 = value; }
        }

        /// public propaty name  :  GoodsPricePriceStartDate
        /// <summary>���i�J�n���v���p�e�B</summary>
        /// <value>YYYYMMDD ���i�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime GoodsPricePriceStartDate
        {
            get { return _goodsPricePriceStartDate; }
            set { _goodsPricePriceStartDate = value; }
        }

        /// public propaty name  :  GoodsPriceListPrice
        /// <summary>�艿�i�����j�v���p�e�B</summary>
        /// <value>���i�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�i�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double GoodsPriceListPrice
        {
            get { return _goodsPriceListPrice; }
            set { _goodsPriceListPrice = value; }
        }

        /// public propaty name  :  GoodsPriceSalesUnitCost
        /// <summary>�����P���v���p�e�B</summary>
        /// <value>�d���P�� �� ���㌴���œ��� ���i�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double GoodsPriceSalesUnitCost
        {
            get { return _goodsPriceSalesUnitCost; }
            set { _goodsPriceSalesUnitCost = value; }
        }

        /// public propaty name  :  GoodsPriceStockRate
        /// <summary>�d�����v���p�e�B</summary>
        /// <value>���i�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double GoodsPriceStockRate
        {
            get { return _goodsPriceStockRate; }
            set { _goodsPriceStockRate = value; }
        }

        /// public propaty name  :  GoodsPriceOpenPriceDiv
        /// <summary>�I�[�v�����i�敪�v���p�e�B</summary>
        /// <value>0:�ʏ�^1:�I�[�v�����i ���i�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�[�v�����i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsPriceOpenPriceDiv
        {
            get { return _goodsPriceOpenPriceDiv; }
            set { _goodsPriceOpenPriceDiv = value; }
        }

        /// public propaty name  :  GoodsPriceOfferDate
        /// <summary>�񋟓��t�v���p�e�B</summary>
        /// <value>YYYYMMDD ���i�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �񋟓��t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime GoodsPriceOfferDate
        {
            get { return _goodsPriceOfferDate; }
            set { _goodsPriceOfferDate = value; }
        }

        /// public propaty name  :  GoodsPriceUpdateDate
        /// <summary>�X�V�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD ���i�}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime GoodsPriceUpdateDate
        {
            get { return _goodsPriceUpdateDate; }
            set { _goodsPriceUpdateDate = value; }
        }

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// <value>�݌Ƀ}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCode
        {
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }

        /// public propaty name  :  WarehouseName
        /// <summary>�q�ɖ��̃v���p�e�B</summary>
        /// <value>�q�Ƀ}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  ShipmentPosCnt
        /// <summary>�o�׉\���v���p�e�B</summary>
        /// <value>�݌Ƀ}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׉\���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShipmentPosCnt
        {
            get { return _shipmentPosCnt; }
            set { _shipmentPosCnt = value; }
        }

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>�q�ɒI�ԃv���p�e�B</summary>
        /// <value>�݌Ƀ}�X�^���擾</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }


        /// <summary>
        /// ���i�A���f�[�^�N���X���[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>GoodsUnitDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUnitDataWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsUnitDataWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>GoodsUnitDataWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   GoodsUnitDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class GoodsUnitDataWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUnitDataWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  GoodsUnitDataWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is GoodsUnitDataWork || graph is ArrayList || graph is GoodsUnitDataWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(GoodsUnitDataWork).FullName));

            if (graph != null && graph is GoodsUnitDataWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GoodsUnitDataWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is GoodsUnitDataWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((GoodsUnitDataWork[])graph).Length;
            }
            else if (graph is GoodsUnitDataWork)
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
            //���[�J�[����
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
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
            //BL���i�R�[�h���́i�S�p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //�\������
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
            //���i�啪�ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsLGroup
            //���i�啪�ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //GoodsLGroupName
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //���i�����ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMGroupName
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BL�O���[�v�R�[�h����
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupName
            //���i�|�������N
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //�ېŋ敪
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //�n�C�t�������i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNoNoneHyphen
            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int32)); //OfferDate
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
            //���Е��ޖ���
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseGanreName
            //�X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //���i�|���O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsRateGrpCode
            //�̔��敪�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCode
            //�쐬����
            serInfo.MemberInfo.Add(typeof(Int64)); //GoodsPriceCreateDateTime
            //�X�V����
            serInfo.MemberInfo.Add(typeof(Int64)); //GoodsPriceUpdateDateTime
            //��ƃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //GoodsPriceEnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //GoodsPriceFileHeaderGuid
            //�X�V�]�ƈ��R�[�h
            serInfo.MemberInfo.Add(typeof(string)); //GoodsPriceUpdEmployeeCode
            //�X�V�A�Z���u��ID1
            serInfo.MemberInfo.Add(typeof(string)); //GoodsPriceUpdAssemblyId1
            //�X�V�A�Z���u��ID2
            serInfo.MemberInfo.Add(typeof(string)); //GoodsPriceUpdAssemblyId2
            //���i�J�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsPricePriceStartDate
            //�艿�i�����j
            serInfo.MemberInfo.Add(typeof(Double)); //GoodsPriceListPrice
            //�����P��
            serInfo.MemberInfo.Add(typeof(Double)); //GoodsPriceSalesUnitCost
            //�d����
            serInfo.MemberInfo.Add(typeof(Double)); //GoodsPriceStockRate
            //�I�[�v�����i�敪
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsPriceOpenPriceDiv
            //�񋟓��t
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsPriceOfferDate
            //�X�V�N����
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsPriceUpdateDate
            //�q�ɃR�[�h
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //�q�ɖ���
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //�o�׉\��
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentPosCnt
            //�q�ɒI��
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo


            serInfo.Serialize(writer, serInfo);
            if (graph is GoodsUnitDataWork)
            {
                GoodsUnitDataWork temp = (GoodsUnitDataWork)graph;

                SetGoodsUnitDataWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is GoodsUnitDataWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((GoodsUnitDataWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (GoodsUnitDataWork temp in lst)
                {
                    SetGoodsUnitDataWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// GoodsUnitDataWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 51;

        /// <summary>
        ///  GoodsUnitDataWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUnitDataWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetGoodsUnitDataWork(System.IO.BinaryWriter writer, GoodsUnitDataWork temp)
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
            //���[�J�[����
            writer.Write(temp.MakerName);
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
            //BL���i�R�[�h���́i�S�p�j
            writer.Write(temp.BLGoodsFullName);
            //�\������
            writer.Write(temp.DisplayOrder);
            //���i�啪�ރR�[�h
            writer.Write(temp.GoodsLGroup);
            //���i�啪�ޖ���
            writer.Write(temp.GoodsLGroupName);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //���i�����ޖ���
            writer.Write(temp.GoodsMGroupName);
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //BL�O���[�v�R�[�h����
            writer.Write(temp.BLGroupName);
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
            //���Е��ޖ���
            writer.Write(temp.EnterpriseGanreName);
            //�X�V�N����
            writer.Write((Int64)temp.UpdateDate.Ticks);
            //���i�|���O���[�v�R�[�h
            writer.Write(temp.GoodsRateGrpCode);
            //�̔��敪�R�[�h
            writer.Write(temp.SalesCode);
            //�쐬����
            writer.Write((Int64)temp.GoodsPriceCreateDateTime.Ticks);
            //�X�V����
            writer.Write((Int64)temp.GoodsPriceUpdateDateTime.Ticks);
            //��ƃR�[�h
            writer.Write(temp.GoodsPriceEnterpriseCode);
            //GUID
            byte[] goodsPriceFileHeaderGuidArray = temp.GoodsPriceFileHeaderGuid.ToByteArray();
            writer.Write(goodsPriceFileHeaderGuidArray.Length);
            writer.Write(temp.GoodsPriceFileHeaderGuid.ToByteArray());
            //�X�V�]�ƈ��R�[�h
            writer.Write(temp.GoodsPriceUpdEmployeeCode);
            //�X�V�A�Z���u��ID1
            writer.Write(temp.GoodsPriceUpdAssemblyId1);
            //�X�V�A�Z���u��ID2
            writer.Write(temp.GoodsPriceUpdAssemblyId2);
            //���i�J�n��
            writer.Write((Int64)temp.GoodsPricePriceStartDate.Ticks);
            //�艿�i�����j
            writer.Write(temp.GoodsPriceListPrice);
            //�����P��
            writer.Write(temp.GoodsPriceSalesUnitCost);
            //�d����
            writer.Write(temp.GoodsPriceStockRate);
            //�I�[�v�����i�敪
            writer.Write(temp.GoodsPriceOpenPriceDiv);
            //�񋟓��t
            writer.Write((Int64)temp.GoodsPriceOfferDate.Ticks);
            //�X�V�N����
            writer.Write((Int64)temp.GoodsPriceUpdateDate.Ticks);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //�o�׉\��
            writer.Write(temp.ShipmentPosCnt);
            //�q�ɒI��
            writer.Write(temp.WarehouseShelfNo);

        }

        /// <summary>
        ///  GoodsUnitDataWork�C���X�^���X�擾
        /// </summary>
        /// <returns>GoodsUnitDataWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUnitDataWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private GoodsUnitDataWork GetGoodsUnitDataWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            GoodsUnitDataWork temp = new GoodsUnitDataWork();

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
            //���[�J�[����
            temp.MakerName = reader.ReadString();
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
            //BL���i�R�[�h���́i�S�p�j
            temp.BLGoodsFullName = reader.ReadString();
            //�\������
            temp.DisplayOrder = reader.ReadInt32();
            //���i�啪�ރR�[�h
            temp.GoodsLGroup = reader.ReadInt32();
            //���i�啪�ޖ���
            temp.GoodsLGroupName = reader.ReadString();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //���i�����ޖ���
            temp.GoodsMGroupName = reader.ReadString();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //BL�O���[�v�R�[�h����
            temp.BLGroupName = reader.ReadString();
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
            //���Е��ޖ���
            temp.EnterpriseGanreName = reader.ReadString();
            //�X�V�N����
            temp.UpdateDate = new DateTime(reader.ReadInt64());
            //���i�|���O���[�v�R�[�h
            temp.GoodsRateGrpCode = reader.ReadInt32();
            //�̔��敪�R�[�h
            temp.SalesCode = reader.ReadInt32();
            //�쐬����
            temp.GoodsPriceCreateDateTime = new DateTime(reader.ReadInt64());
            //�X�V����
            temp.GoodsPriceUpdateDateTime = new DateTime(reader.ReadInt64());
            //��ƃR�[�h
            temp.GoodsPriceEnterpriseCode = reader.ReadString();
            //GUID
            int lenOfGoodsPriceFileHeaderGuidArray = reader.ReadInt32();
            byte[] goodsPriceFileHeaderGuidArray = reader.ReadBytes(lenOfGoodsPriceFileHeaderGuidArray);
            temp.GoodsPriceFileHeaderGuid = new Guid(goodsPriceFileHeaderGuidArray);
            //�X�V�]�ƈ��R�[�h
            temp.GoodsPriceUpdEmployeeCode = reader.ReadString();
            //�X�V�A�Z���u��ID1
            temp.GoodsPriceUpdAssemblyId1 = reader.ReadString();
            //�X�V�A�Z���u��ID2
            temp.GoodsPriceUpdAssemblyId2 = reader.ReadString();
            //���i�J�n��
            temp.GoodsPricePriceStartDate = new DateTime(reader.ReadInt64());
            //�艿�i�����j
            temp.GoodsPriceListPrice = reader.ReadDouble();
            //�����P��
            temp.GoodsPriceSalesUnitCost = reader.ReadDouble();
            //�d����
            temp.GoodsPriceStockRate = reader.ReadDouble();
            //�I�[�v�����i�敪
            temp.GoodsPriceOpenPriceDiv = reader.ReadInt32();
            //�񋟓��t
            temp.GoodsPriceOfferDate = new DateTime(reader.ReadInt64());
            //�X�V�N����
            temp.GoodsPriceUpdateDate = new DateTime(reader.ReadInt64());
            //�q�ɃR�[�h
            temp.WarehouseCode = reader.ReadString();
            //�q�ɖ���
            temp.WarehouseName = reader.ReadString();
            //�o�׉\��
            temp.ShipmentPosCnt = reader.ReadDouble();
            //�q�ɒI��
            temp.WarehouseShelfNo = reader.ReadString();


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
        /// <returns>GoodsUnitDataWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsUnitDataWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                GoodsUnitDataWork temp = GetGoodsUnitDataWork(reader, serInfo);
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
                    retValue = (GoodsUnitDataWork[])lst.ToArray(typeof(GoodsUnitDataWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
