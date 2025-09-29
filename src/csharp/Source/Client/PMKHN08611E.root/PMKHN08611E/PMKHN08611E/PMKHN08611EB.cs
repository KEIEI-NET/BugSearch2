using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsSet
    /// <summary>
    ///                      ���i�}�X�^�i����j���ʃN���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�}�X�^�i����j���ʃN���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks> 
    public class GoodsSet 
    {
        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerShortName = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�d���旪��</summary>
        private string _supplierSnm = "";

        /// <summary>�W�����i</summary>
        /// <remarks>�艿�i�����j</remarks>
        private Double _listPrice;

        /// <summary>�d����</summary>
        private Double _stockRate;

        /// <summary>�����P��</summary>
        private Double _salesUnitCost;

        /// <summary>�w��</summary>
        /// <remarks>���i�|�������N</remarks>
        private string _goodsRateRank = "";

        /// <summary>�������b�g</summary>
        private Int32 _supplierLot;

        /// <summary>���i�K�i�E���L����</summary>
        private string _goodsSpecialNote = "";

        /// <summary>���i���l�P</summary>
        private string _goodsNote1 = "";

        /// <summary>���i���l�Q</summary>
        private string _goodsNote2 = "";

        /// <summary>�K�p��</summary>
        /// <remarks>���i�J�n�� YYYYMMDD</remarks>
        private DateTime _priceStartDate;

        /// <summary>�V�K�p���i</summary>
        /// <remarks>�艿�i�����j</remarks>
        private Double _newListPrice;

        /// <summary>���D�敪</summary>
        /// <remarks>���i���� 0:���� 1:���̑�</remarks>
        private Int32 _goodsKindCode;

        /// <summary>�ېŋ敪</summary>
        /// <remarks>0:�ې� 1:��ې� 2:�ېŁi���Łj</remarks>
        private Int32 _taxationDivCd;

        /// <summary>���i�敪</summary>
        /// <remarks>���Е��ރR�[�h</remarks>
        private Int32 _enterpriseGanreCode;

        /// <summary>���i�敪����</summary>
        /// <remarks>���[�U�[�K�C�h�敪����(���Е��ރR�[�h)</remarks>
        private string _enterpriseGanreCodeName = "";

        /// <summary>�񋟃f�[�^�敪</summary>
        /// <remarks>0:���[�U�f�[�^ 1:�񋟃f�[�^</remarks>
        private Int32 _offerDataDiv;

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

        /// public propaty name  :  MakerShortName
        /// <summary>���[�J�[���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MakerShortName
        {
            get { return _makerShortName; }
            set { _makerShortName = value; }
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

        /// public propaty name  :  SupplierSnm
        /// <summary>�d���旪�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���旪�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierSnm
        {
            get { return _supplierSnm; }
            set { _supplierSnm = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>�W�����i�v���p�e�B</summary>
        /// <value>�艿�i�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�����i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  StockRate
        /// <summary>�d�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockRate
        {
            get { return _stockRate; }
            set { _stockRate = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>�����P���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����P���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  GoodsRateRank
        /// <summary>�w�ʃv���p�e�B</summary>
        /// <value>���i�|�������N</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �w�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsRateRank
        {
            get { return _goodsRateRank; }
            set { _goodsRateRank = value; }
        }

        /// public propaty name  :  SupplierLot
        /// <summary>�������b�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������b�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierLot
        {
            get { return _supplierLot; }
            set { _supplierLot = value; }
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

        /// public propaty name  :  PriceStartDate
        /// <summary>�K�p���v���p�e�B</summary>
        /// <value>���i�J�n�� YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  NewListPrice
        /// <summary>�V�K�p���i�v���p�e�B</summary>
        /// <value>�艿�i�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �V�K�p���i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double NewListPrice
        {
            get { return _newListPrice; }
            set { _newListPrice = value; }
        }

        /// public propaty name  :  GoodsKindCode
        /// <summary>���D�敪�v���p�e�B</summary>
        /// <value>���i���� 0:���� 1:���̑�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���D�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsKindCode
        {
            get { return _goodsKindCode; }
            set { _goodsKindCode = value; }
        }

        /// public propaty name  :  TaxationDivCd
        /// <summary>�ېŋ敪�v���p�e�B</summary>
        /// <value>0:�ې� 1:��ې� 2:�ېŁi���Łj</value>
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

        /// public propaty name  :  EnterpriseGanreCode
        /// <summary>���i�敪�v���p�e�B</summary>
        /// <value>���Е��ރR�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EnterpriseGanreCode
        {
            get { return _enterpriseGanreCode; }
            set { _enterpriseGanreCode = value; }
        }

        /// public propaty name  :  EnterpriseGanreCodeName
        /// <summary>���i�敪���̃v���p�e�B</summary>
        /// <value>���[�U�[�K�C�h�敪����(���Е��ރR�[�h)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�敪���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseGanreCodeName
        {
            get { return _enterpriseGanreCodeName; }
            set { _enterpriseGanreCodeName = value; }
        }

        /// public propaty name  :  OfferDataDiv
        /// <summary>�񋟃f�[�^�敪�v���p�e�B</summary>
        /// <value>0:���[�U�f�[�^ 1:�񋟃f�[�^</value>
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

        /// <summary>
        /// ���i�i����j�f�[�^�N���X��������
        /// </summary>
        /// <returns>SecInfoSet�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����SecInfoSet�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsSet Clone()
        {
            return new GoodsSet(this._updateDateTime, this._goodsMakerCd, this._makerShortName, this._goodsNo, this._bLGoodsCode, this._goodsName, this._supplierCd, this._supplierSnm, this._listPrice, this._stockRate, this._salesUnitCost, this._goodsRateRank, this._supplierLot, this._goodsSpecialNote, this._goodsNote1, this._goodsNote2, this._priceStartDate, this._newListPrice, this._goodsKindCode, this._taxationDivCd, this._enterpriseGanreCode, this._enterpriseGanreCodeName, this._offerDataDiv);
        }

        /// <summary>
		/// ���i�i����j�f�[�^�N���X���[�N�R���X�g���N�^
		/// </summary>
		/// <returns>EmployeeSetWork�N���X�̃C���X�^���X</returns>
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   EmployeeSetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
		/// <br>Programer        :   ��������</br>
		/// </remarks>
		public GoodsSet()
		{
		}

        
        /// <summary>
        /// ���i�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="UpdateDateTime"></param>
        /// <param name="GoodsMakerCd"></param>
        /// <param name="MakerShortName"></param>
        /// <param name="GoodsNo"></param>
        /// <param name="BLGoodsCode"></param>
        /// <param name="GoodsName"></param>
        /// <param name="SupplierCd"></param>
        /// <param name="SupplierSnm"></param>
        /// <param name="ListPrice"></param>
        /// <param name="StockRate"></param>
        /// <param name="SalesUnitCost"></param>
        /// <param name="GoodsRateRank"></param>
        /// <param name="SupplierLot"></param>
        /// <param name="GoodsSpecialNote"></param>
        /// <param name="GoodsNote1"></param>
        /// <param name="GoodsNote2"></param>
        /// <param name="PriceStartDate"></param>
        /// <param name="NewListPrice"></param>
        /// <param name="GoodsKindCode"></param>
        /// <param name="TaxationDivCd"></param>
        /// <param name="EnterpriseGanreCode"></param>
        /// <param name="EnterpriseGanreCodeName"></param>
        /// <param name="OfferDataDiv"></param>
        public GoodsSet(DateTime UpdateDateTime, Int32 GoodsMakerCd, string MakerShortName, string GoodsNo, Int32 BLGoodsCode, string GoodsName, Int32 SupplierCd, string SupplierSnm, Double ListPrice, Double StockRate, Double SalesUnitCost, string GoodsRateRank, Int32 SupplierLot, string GoodsSpecialNote, string GoodsNote1, string GoodsNote2, DateTime PriceStartDate, Double NewListPrice, Int32 GoodsKindCode, Int32 TaxationDivCd, Int32 EnterpriseGanreCode, string EnterpriseGanreCodeName, Int32 OfferDataDiv)
        {
            this._updateDateTime = UpdateDateTime;
            this._goodsMakerCd = GoodsMakerCd;
            this._makerShortName = MakerShortName;
            this._goodsNo = GoodsNo;
            this._bLGoodsCode = BLGoodsCode;
            this._goodsName = GoodsName;
            this._supplierCd = SupplierCd;
            this._supplierSnm = SupplierSnm;
            this._listPrice = ListPrice;
            this._stockRate = StockRate;
            this._salesUnitCost = SalesUnitCost;
            this._goodsRateRank = GoodsRateRank;
            this._supplierLot = SupplierLot;
            this._goodsSpecialNote = GoodsSpecialNote;
            this._goodsNote1 = GoodsNote1;
            this._goodsNote2 = GoodsNote2;
            this._priceStartDate = PriceStartDate;
            this._newListPrice = NewListPrice;
            this._goodsKindCode = GoodsKindCode;
            this._taxationDivCd = TaxationDivCd;
            this._enterpriseGanreCode = EnterpriseGanreCode;
            this._enterpriseGanreCodeName = EnterpriseGanreCodeName;
            this._offerDataDiv = OfferDataDiv;
        }
    }
}
