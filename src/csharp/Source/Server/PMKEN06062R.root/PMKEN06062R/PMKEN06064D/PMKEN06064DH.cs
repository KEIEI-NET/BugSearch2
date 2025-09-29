using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsUnitDataWork
    /// <summary>
    ///                      ���i�A���f�[�^�N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�A���f�[�^�N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :    </br>
    /// <br>Genarated Date   :   2008/07/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2014/02/10 Redmine#41976 ���z ���i�}�X�^�U�̒ǉ�</br>
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
        private Int32 _offerDataDiv;

        /// <summary>���i���X�g</summary>
        private ArrayList _priceList;

        /// <summary>�݌Ƀ��X�g</summary>
        private ArrayList _stockList;

        // -------- ADD START 2014/02/10 ���z -------->>>>>
        /// <summary>���i�}�X�^�\���p�I�v�V����</summary>
        private Int32 _optKonmanGoodsMstCtl;

        /// <summary>�K�i</summary>
        private string _standard = "";

        /// <summary>�׎p</summary>
        private string _packing = "";

        /// <summary>�o�n�rNo.</summary>
        private string _posNo = "";

        /// <summary>���[�J�[�i��</summary>
        private string _makerGoodsNo = "";

        /// <summary>�쐬�����U</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTimeA;

        /// <summary>�X�V�����U</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTimeA;

        /// <summary>GUID�U</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuidA;
        // -------- ADD END 2014/02/10 ���z --------<<<<<


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

        /// public propaty name  :  PriceList
        /// <summary>���i���X�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList PriceList
        {
            get { return _priceList; }
            set { _priceList = value; }
        }

        /// public propaty name  :  StockList
        /// <summary>�݌Ƀ��X�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ƀ��X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList StockList
        {
            get { return _stockList; }
            set { _stockList = value; }
        }

        // -------- ADD START 2014/02/10 ���z -------->>>>>
        /// public propaty name  :  OptKonmanGoodsMstCtl
        /// <summary>���i�}�X�^�\���p�I�v�V�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�}�X�^�\���p�I�v�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OptKonmanGoodsMstCtl
        {
            get { return _optKonmanGoodsMstCtl; }
            set { _optKonmanGoodsMstCtl = value; }
        }

        /// public propaty name  :  Standard
        /// <summary>�K�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Standard
        {
            get { return _standard; }
            set { _standard = value; }
        }

        /// public propaty name  :  Packing
        /// <summary>�׎p�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �׎p�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Packing
        {
            get { return _packing; }
            set { _packing = value; }
        }

        /// public propaty name  :  PosNo
        /// <summary>�o�n�rNo.�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�n�rNo.�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PosNo
        {
            get { return _posNo; }
            set { _posNo = value; }
        }

        /// public propaty name  :  MakerGoodsNo
        /// <summary>���[�J�[�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerGoodsNo
        {
            get { return _makerGoodsNo; }
            set { _makerGoodsNo = value; }
        }

        /// public propaty name  :  CreateDateTimeA
        /// <summary>�쐬�����U�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTimeA
        {
            get { return _createDateTimeA; }
            set { _createDateTimeA = value; }
        }

        /// public propaty name  :  UpdateDateTimeA
        /// <summary>�X�V�����U�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����U�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTimeA
        {
            get { return _updateDateTimeA; }
            set { _updateDateTimeA = value; }
        }

        /// public propaty name  :  FileHeaderGuidA
        /// <summary>GUID�U�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuidA
        {
            get { return _fileHeaderGuidA; }
            set { _fileHeaderGuidA = value; }
        }
        // -------- ADD END 2014/02/10 ���z --------<<<<<

        /// <summary>
        /// ���i�A���f�[�^�N���X���[�N�R���X�g���N�^
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
            //���i���X�g
            serInfo.MemberInfo.Add(typeof(ArrayList)); //PriceList
            //�݌Ƀ��X�g
            serInfo.MemberInfo.Add(typeof(ArrayList)); //StockList
            // -------- ADD START 2014/02/10 ���z -------->>>>>
            //���i�}�X�^�\���p�I�v�V����
            serInfo.MemberInfo.Add(typeof(Int32)); //OptKonmanGoodsMstCtl
            //�K�i
            serInfo.MemberInfo.Add(typeof(string)); //Standard
            //�׎p
            serInfo.MemberInfo.Add(typeof(string)); //Packing
            //�o�n�rNo.
            serInfo.MemberInfo.Add(typeof(string)); //PosNo
            //���[�J�[�i��
            serInfo.MemberInfo.Add(typeof(string)); //MakerGoodsNo
            //�쐬�����U
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTimeA
            //�X�V�����U
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTimeA
            //GUID�U
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuidA
            // -------- ADD END 2014/02/10 ���z --------<<<<<


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
        //private const int currentMemberCount = 30;// DEL 2014/02/10 ���z
        private const int currentMemberCount = 38;// ADD 2014/02/10 ���z

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
            // -------- ADD START 2014/02/10 ���z -------->>>>>
            //���i�}�X�^�\���p�I�v�V����
            writer.Write(temp.OptKonmanGoodsMstCtl);
            //�K�i
            writer.Write(temp.Standard);
            //�׎p
            writer.Write(temp.Packing);
            //�o�n�rNo.
            writer.Write(temp.PosNo);
            //���[�J�[�i��
            writer.Write(temp.MakerGoodsNo);
            //�쐬�����U
            writer.Write((Int64)temp.CreateDateTimeA.Ticks);
            //�X�V�����U
            writer.Write((Int64)temp.UpdateDateTimeA.Ticks);
            //GUID�U
            byte[] fileHeaderGuidArrayA = temp.FileHeaderGuidA.ToByteArray();
            writer.Write(fileHeaderGuidArrayA.Length);
            writer.Write(temp.FileHeaderGuidA.ToByteArray());
            // -------- ADD END 2014/02/10 ���z --------<<<<<
            //���i���X�g
            if (temp.PriceList == null)
            {
                writer.Write(0);
            }
            else
            {
                writer.Write(temp.PriceList.Count);
                for (int i = 0; i < temp.PriceList.Count; i++)
                {
                    SetUsrGoodsPriceWork(writer, temp.PriceList[i] as GoodsPriceUWork);
                }
            }
            //�݌Ƀ��X�g
            if (temp.StockList == null)
            {
                writer.Write(0);
            }
            else
            {
                writer.Write(temp.StockList.Count);
                for (int i = 0; i < temp.StockList.Count; i++)
                {
                    SetStockWork(writer, temp.StockList[i] as StockWork);
                }
            }
        }

        /// <summary>
        ///  GoodsPriceUWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsPriceUWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetUsrGoodsPriceWork(System.IO.BinaryWriter writer, GoodsPriceUWork temp)
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
            //���i�J�n��
            writer.Write((Int64)temp.PriceStartDate.Ticks);
            //�艿�i�����j
            writer.Write(temp.ListPrice);
            //�����P��
            writer.Write(temp.SalesUnitCost);
            //�d����
            writer.Write(temp.StockRate);
            //�I�[�v�����i�敪
            writer.Write(temp.OpenPriceDiv);
            //�񋟓��t
            writer.Write((Int64)temp.OfferDate.Ticks);
            //�X�V�N����
            writer.Write((Int64)temp.UpdateDate.Ticks);

        }

        /// <summary>
        ///  StockWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetStockWork(System.IO.BinaryWriter writer, StockWork temp)
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
            //���_�R�[�h
            writer.Write(temp.SectionCode);
            //���_�K�C�h����
            writer.Write(temp.SectionGuideNm);
            //�q�ɃR�[�h
            writer.Write(temp.WarehouseCode);
            //�q�ɖ���
            writer.Write(temp.WarehouseName);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //�d���P���i�Ŕ�,�����j
            writer.Write(temp.StockUnitPriceFl);
            //�d���݌ɐ�
            writer.Write(temp.SupplierStock);
            //�󒍐�
            writer.Write(temp.AcpOdrCount);
            //M/O������
            writer.Write(temp.MonthOrderCount);
            //������
            writer.Write(temp.SalesOrderCount);
            //�݌ɋ敪
            writer.Write(temp.StockDiv);
            //�ړ����d���݌ɐ�
            writer.Write(temp.MovingSupliStock);
            //�o�׉\��
            writer.Write(temp.ShipmentPosCnt);
            //�݌ɕۗL���z
            writer.Write(temp.StockTotalPrice);
            //�ŏI�d���N����
            writer.Write((Int64)temp.LastStockDate.Ticks);
            //�ŏI�����
            writer.Write((Int64)temp.LastSalesDate.Ticks);
            //�ŏI�I���X�V��
            writer.Write((Int64)temp.LastInventoryUpdate.Ticks);
            //�Œ�݌ɐ�
            writer.Write(temp.MinimumStockCnt);
            //�ō��݌ɐ�
            writer.Write(temp.MaximumStockCnt);
            //�������
            writer.Write(temp.NmlSalOdrCount);
            //�����P��
            writer.Write(temp.SalesOrderUnit);
            //�݌ɔ�����R�[�h
            writer.Write(temp.StockSupplierCode);
            //�n�C�t�������i�ԍ�
            writer.Write(temp.GoodsNoNoneHyphen);
            //�q�ɒI��
            writer.Write(temp.WarehouseShelfNo);
            //�d���I�ԂP
            writer.Write(temp.DuplicationShelfNo1);
            //�d���I�ԂQ
            writer.Write(temp.DuplicationShelfNo2);
            //���i�Ǘ��敪�P
            writer.Write(temp.PartsManagementDivide1);
            //���i�Ǘ��敪�Q
            writer.Write(temp.PartsManagementDivide2);
            //�݌ɔ��l�P
            writer.Write(temp.StockNote1);
            //�݌ɔ��l�Q
            writer.Write(temp.StockNote2);
            //�o�א��i���v��j
            writer.Write(temp.ShipmentCnt);
            //���א��i���v��j
            writer.Write(temp.ArrivalCnt);
            //�݌ɓo�^��
            writer.Write((Int64)temp.StockCreateDate.Ticks);
            //�X�V�N����
            writer.Write((Int64)temp.UpdateDate.Ticks);

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
            // -------- ADD START 2014/02/10 ���z -------->>>>>
            //���i�}�X�^�\���p�I�v�V����
            temp.OptKonmanGoodsMstCtl = reader.ReadInt32();
            //�K�i
            temp.Standard = reader.ReadString();
            //�׎p
            temp.Packing = reader.ReadString();
            //�o�n�rNo.
            temp.PosNo = reader.ReadString();
            //���[�J�[�i��
            temp.MakerGoodsNo = reader.ReadString();
            //�쐬�����U
            temp.CreateDateTimeA = new DateTime(reader.ReadInt64());
            //�X�V�����U
            temp.UpdateDateTimeA = new DateTime(reader.ReadInt64());
            //GUID�U
            int lenOfFileHeaderGuidArrayA = reader.ReadInt32();
            byte[] fileHeaderGuidArrayA = reader.ReadBytes(lenOfFileHeaderGuidArrayA);
            temp.FileHeaderGuidA = new Guid(fileHeaderGuidArrayA);
            // -------- ADD END 2014/02/10 ���z --------<<<<<
            //���i���X�g
            int priceCnt = reader.ReadInt32();
            temp.PriceList = new ArrayList();
            for (int i = 0; i < priceCnt; i++)
            {
                GoodsPriceUWork tempPrice = new GoodsPriceUWork();

                //�쐬����
                tempPrice.CreateDateTime = new DateTime(reader.ReadInt64());
                //�X�V����
                tempPrice.UpdateDateTime = new DateTime(reader.ReadInt64());
                //��ƃR�[�h
                tempPrice.EnterpriseCode = reader.ReadString();
                //GUID
                lenOfFileHeaderGuidArray = reader.ReadInt32();
                fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
                tempPrice.FileHeaderGuid = new Guid(fileHeaderGuidArray);
                //�X�V�]�ƈ��R�[�h
                tempPrice.UpdEmployeeCode = reader.ReadString();
                //�X�V�A�Z���u��ID1
                tempPrice.UpdAssemblyId1 = reader.ReadString();
                //�X�V�A�Z���u��ID2
                tempPrice.UpdAssemblyId2 = reader.ReadString();
                //�_���폜�敪
                tempPrice.LogicalDeleteCode = reader.ReadInt32();
                //���i���[�J�[�R�[�h
                tempPrice.GoodsMakerCd = reader.ReadInt32();
                //���i�ԍ�
                tempPrice.GoodsNo = reader.ReadString();
                //���i�J�n��
                tempPrice.PriceStartDate = new DateTime(reader.ReadInt64());
                //�艿�i�����j
                tempPrice.ListPrice = reader.ReadDouble();
                //�����P��
                tempPrice.SalesUnitCost = reader.ReadDouble();
                //�d����
                tempPrice.StockRate = reader.ReadDouble();
                //�I�[�v�����i�敪
                tempPrice.OpenPriceDiv = reader.ReadInt32();
                //�񋟓��t
                tempPrice.OfferDate = new DateTime(reader.ReadInt64());
                //�X�V�N����
                tempPrice.UpdateDate = new DateTime(reader.ReadInt64());

                temp.PriceList.Add(tempPrice);
            }
            //�݌Ƀ��X�g
            int stockCnt = reader.ReadInt32();
            temp.StockList = new ArrayList();
            for (int i = 0; i < stockCnt; i++)
            {
                StockWork tempStock = new StockWork();

                //�쐬����
                tempStock.CreateDateTime = new DateTime(reader.ReadInt64());
                //�X�V����
                tempStock.UpdateDateTime = new DateTime(reader.ReadInt64());
                //��ƃR�[�h
                tempStock.EnterpriseCode = reader.ReadString();
                //GUID
                lenOfFileHeaderGuidArray = reader.ReadInt32();
                fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
                tempStock.FileHeaderGuid = new Guid(fileHeaderGuidArray);
                //�X�V�]�ƈ��R�[�h
                tempStock.UpdEmployeeCode = reader.ReadString();
                //�X�V�A�Z���u��ID1
                tempStock.UpdAssemblyId1 = reader.ReadString();
                //�X�V�A�Z���u��ID2
                tempStock.UpdAssemblyId2 = reader.ReadString();
                //�_���폜�敪
                tempStock.LogicalDeleteCode = reader.ReadInt32();
                //���_�R�[�h
                tempStock.SectionCode = reader.ReadString();
                //���_�K�C�h����
                tempStock.SectionGuideNm = reader.ReadString();
                //�q�ɃR�[�h
                tempStock.WarehouseCode = reader.ReadString();
                //�q�ɖ���
                tempStock.WarehouseName = reader.ReadString();
                //���i���[�J�[�R�[�h
                tempStock.GoodsMakerCd = reader.ReadInt32();
                //���i�ԍ�
                tempStock.GoodsNo = reader.ReadString();
                //�d���P���i�Ŕ�,�����j
                tempStock.StockUnitPriceFl = reader.ReadDouble();
                //�d���݌ɐ�
                tempStock.SupplierStock = reader.ReadDouble();
                //�󒍐�
                tempStock.AcpOdrCount = reader.ReadDouble();
                //M/O������
                tempStock.MonthOrderCount = reader.ReadDouble();
                //������
                tempStock.SalesOrderCount = reader.ReadDouble();
                //�݌ɋ敪
                tempStock.StockDiv = reader.ReadInt32();
                //�ړ����d���݌ɐ�
                tempStock.MovingSupliStock = reader.ReadDouble();
                //�o�׉\��
                tempStock.ShipmentPosCnt = reader.ReadDouble();
                //�݌ɕۗL���z
                tempStock.StockTotalPrice = reader.ReadInt64();
                //�ŏI�d���N����
                tempStock.LastStockDate = new DateTime(reader.ReadInt64());
                //�ŏI�����
                tempStock.LastSalesDate = new DateTime(reader.ReadInt64());
                //�ŏI�I���X�V��
                tempStock.LastInventoryUpdate = new DateTime(reader.ReadInt64());
                //�Œ�݌ɐ�
                tempStock.MinimumStockCnt = reader.ReadDouble();
                //�ō��݌ɐ�
                tempStock.MaximumStockCnt = reader.ReadDouble();
                //�������
                tempStock.NmlSalOdrCount = reader.ReadDouble();
                //�����P��
                tempStock.SalesOrderUnit = reader.ReadInt32();
                //�݌ɔ�����R�[�h
                tempStock.StockSupplierCode = reader.ReadInt32();
                //�n�C�t�������i�ԍ�
                tempStock.GoodsNoNoneHyphen = reader.ReadString();
                //�q�ɒI��
                tempStock.WarehouseShelfNo = reader.ReadString();
                //�d���I�ԂP
                tempStock.DuplicationShelfNo1 = reader.ReadString();
                //�d���I�ԂQ
                tempStock.DuplicationShelfNo2 = reader.ReadString();
                //���i�Ǘ��敪�P
                tempStock.PartsManagementDivide1 = reader.ReadString();
                //���i�Ǘ��敪�Q
                tempStock.PartsManagementDivide2 = reader.ReadString();
                //�݌ɔ��l�P
                tempStock.StockNote1 = reader.ReadString();
                //�݌ɔ��l�Q
                tempStock.StockNote2 = reader.ReadString();
                //�o�א��i���v��j
                tempStock.ShipmentCnt = reader.ReadDouble();
                //���א��i���v��j
                tempStock.ArrivalCnt = reader.ReadDouble();
                //�݌ɓo�^��
                tempStock.StockCreateDate = new DateTime(reader.ReadInt64());
                //�X�V�N����
                tempStock.UpdateDate = new DateTime(reader.ReadInt64());

                temp.StockList.Add(tempStock);
            }

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
