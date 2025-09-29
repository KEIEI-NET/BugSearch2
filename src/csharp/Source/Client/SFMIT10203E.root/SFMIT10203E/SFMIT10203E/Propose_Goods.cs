using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   Propose_Goods
    /// <summary>
    ///                      ��ď��i�N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ��ď��i�N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2016/5/24</br>
    /// <br>Genarated Date   :   2016/06/02  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2016/6/2  �����m</br>
    /// <br>                 :   �݌ɐ�</br>
    /// <br>                 :   BL���i�R�[�h</br>
    /// <br>                 :   BL���i�R�[�h�}��</br>
    /// <br>                 :   ��ǉ�</br>
    /// </remarks>
    public class Propose_Goods
    {
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���i�J�e�S��</summary>
        /// <remarks>1:�^�C��,2:�o�b�e���[,3:�I�C��,</remarks>
        private long _goodsCategory;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i���i�J�i�j</summary>
        private string _goodsName = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>������</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _releaseDate;

        /// <summary>�݌ɏ󋵋敪</summary>
        /// <remarks>0:���ב҂�,1:�݌ɕs��,2:�݌Ɏc��,3:�݌ɖL�x,4:���ב҂�(�ϑ�),5:�݌ɕs��(�ϑ�),6:�݌Ɏc��(�ϑ�),7:�݌ɖL�x(�ϑ�),8:�Y���Ȃ�</remarks>
        private Int16 _stockStatusDiv;

        /// <summary>���i����</summary>
        /// <remarks>���s�R�[�h��\n�ɒu��</remarks>
        private string _goodsNote = "";

        /// <summary>���iPR</summary>
        /// <remarks>���s�R�[�h��\n�ɒu��</remarks>
        private string _goodsPR = "";

        /// <summary>��]�������i</summary>
        private Double _suggestPrice;

        /// <summary>�X�����i</summary>
        private Double _shopPrice;

        /// <summary>���l</summary>
        private Double _tradePrice;

        /// <summary>�d������</summary>
        private Double _purchaseCost;

        /// <summary>PM�X�V����</summary>
        /// <remarks>�iDateTime:���x��100�i�m�b�j</remarks>
        private Int64 _pMUpdateTime;

        /// <summary>�����^�O1</summary>
        private string _searchTag1 = "";

        /// <summary>�����^�O2</summary>
        private string _searchTag2 = "";

        /// <summary>�����^�O3</summary>
        private string _searchTag3 = "";

        /// <summary>�����^�O4</summary>
        private string _searchTag4 = "";

        /// <summary>�����^�O5</summary>
        private string _searchTag5 = "";

        /// <summary>�����^�O6</summary>
        private string _searchTag6 = "";

        /// <summary>�����^�O7</summary>
        private string _searchTag7 = "";

        /// <summary>�����^�O8</summary>
        private string _searchTag8 = "";

        /// <summary>�����^�O9</summary>
        private string _searchTag9 = "";

        /// <summary>�����^�O10</summary>
        private string _searchTag10 = "";

        /// <summary>�݌ɐ�</summary>
        private Double _stockCnt;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h�}��</summary>
        private Int32 _bLGoodsDrCode;

        /// <summary>���J</summary>
        public int release;

        /// <summary>�I�X�X��</summary>
        public int recommend;

        /// <summary>���J�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _shopSaleBeginDate;

        /// <summary>���J�I����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _shopSaleEndDate;


        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  GoodsCategory
        /// <summary>���i�J�e�S���v���p�e�B</summary>
        /// <value>1:�^�C��,2:�o�b�e���[,3:�I�C��,</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�e�S���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public long GoodsCategory
        {
            get { return _goodsCategory; }
            set { _goodsCategory = value; }
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
        /// <summary>���i���i�J�i�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���i�J�i�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
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

        /// public propaty name  :  ReleaseDate
        /// <summary>�������v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ReleaseDate
        {
            get { return _releaseDate; }
            set { _releaseDate = value; }
        }

        /// public propaty name  :  StockStatusDiv
        /// <summary>�݌ɏ󋵋敪�v���p�e�B</summary>
        /// <value>0:���ב҂�,1:�݌ɕs��,2:�݌Ɏc��,3:�݌ɖL�x,4:���ב҂�(�ϑ�),5:�݌ɕs��(�ϑ�),6:�݌Ɏc��(�ϑ�),7:�݌ɖL�x(�ϑ�),8:�Y���Ȃ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏ󋵋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int16 StockStatusDiv
        {
            get { return _stockStatusDiv; }
            set { _stockStatusDiv = value; }
        }

        /// public propaty name  :  GoodsNote
        /// <summary>���i�����v���p�e�B</summary>
        /// <value>���s�R�[�h��\n�ɒu��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNote
        {
            get { return _goodsNote; }
            set { _goodsNote = value; }
        }

        /// public propaty name  :  GoodsPR
        /// <summary>���iPR�v���p�e�B</summary>
        /// <value>���s�R�[�h��\n�ɒu��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���iPR�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsPR
        {
            get { return _goodsPR; }
            set { _goodsPR = value; }
        }

        /// public propaty name  :  SuggestPrice
        /// <summary>��]�������i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��]�������i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SuggestPrice
        {
            get { return _suggestPrice; }
            set { _suggestPrice = value; }
        }

        /// public propaty name  :  ShopPrice
        /// <summary>�X�����i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�����i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ShopPrice
        {
            get { return _shopPrice; }
            set { _shopPrice = value; }
        }

        /// public propaty name  :  TradePrice
        /// <summary>���l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double TradePrice
        {
            get { return _tradePrice; }
            set { _tradePrice = value; }
        }

        /// public propaty name  :  PurchaseCost
        /// <summary>�d�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PurchaseCost
        {
            get { return _purchaseCost; }
            set { _purchaseCost = value; }
        }

        /// public propaty name  :  PMUpdateTime
        /// <summary>PM�X�V�����v���p�e�B</summary>
        /// <value>�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM�X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PMUpdateTime
        {
            get { return _pMUpdateTime; }
            set { _pMUpdateTime = value; }
        }

        /// public propaty name  :  SearchTag1
        /// <summary>�����^�O1�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag1
        {
            get { return _searchTag1; }
            set { _searchTag1 = value; }
        }

        /// public propaty name  :  SearchTag2
        /// <summary>�����^�O2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag2
        {
            get { return _searchTag2; }
            set { _searchTag2 = value; }
        }

        /// public propaty name  :  SearchTag3
        /// <summary>�����^�O3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag3
        {
            get { return _searchTag3; }
            set { _searchTag3 = value; }
        }

        /// public propaty name  :  SearchTag4
        /// <summary>�����^�O4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag4
        {
            get { return _searchTag4; }
            set { _searchTag4 = value; }
        }

        /// public propaty name  :  SearchTag5
        /// <summary>�����^�O5�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O5�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag5
        {
            get { return _searchTag5; }
            set { _searchTag5 = value; }
        }

        /// public propaty name  :  SearchTag6
        /// <summary>�����^�O6�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O6�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag6
        {
            get { return _searchTag6; }
            set { _searchTag6 = value; }
        }

        /// public propaty name  :  SearchTag7
        /// <summary>�����^�O7�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O7�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag7
        {
            get { return _searchTag7; }
            set { _searchTag7 = value; }
        }

        /// public propaty name  :  SearchTag8
        /// <summary>�����^�O8�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O8�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag8
        {
            get { return _searchTag8; }
            set { _searchTag8 = value; }
        }

        /// public propaty name  :  SearchTag9
        /// <summary>�����^�O9�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O9�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag9
        {
            get { return _searchTag9; }
            set { _searchTag9 = value; }
        }

        /// public propaty name  :  SearchTag10
        /// <summary>�����^�O10�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����^�O10�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchTag10
        {
            get { return _searchTag10; }
            set { _searchTag10 = value; }
        }

        /// public propaty name  :  StockCnt
        /// <summary>�݌ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockCnt
        {
            get { return _stockCnt; }
            set { _stockCnt = value; }
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

        /// public propaty name  :  BLGoodsDrCode
        /// <summary>BL���i�R�[�h�}�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�}�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsDrCode
        {
            get { return _bLGoodsDrCode; }
            set { _bLGoodsDrCode = value; }
        }

        /// public propaty name  :  ShopSaleBeginDate
        /// <summary>B���J�J�n���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���J�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShopSaleBeginDate
        {
            get { return _shopSaleBeginDate; }
            set { _shopSaleBeginDate = value; }
        }

        /// public propaty name  :  ShopSaleEndDate
        /// <summary>���J�I����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���J�I�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ShopSaleEndDate
        {
            get { return _shopSaleEndDate; }
            set { _shopSaleEndDate = value; }
        }

        /// <summary>
        /// ��ď��i�N���X�R���X�g���N�^
        /// </summary>
        /// <returns>Propose_Goods�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Propose_Goods�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Propose_Goods()
        {
        }

        /// <summary>
        /// ��ď��i�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsCategory">���i�J�e�S��(1:�^�C��,2:�o�b�e���[,3:�I�C��,)</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsName">���i���i�J�i�j</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="makerName">���[�J�[����</param>
        /// <param name="releaseDate">������(YYYYMM)</param>
        /// <param name="stockStatusDiv">�݌ɏ󋵋敪(0:���ב҂�,1:�݌ɕs��,2:�݌Ɏc��,3:�݌ɖL�x,4:���ב҂�(�ϑ�),5:�݌ɕs��(�ϑ�),6:�݌Ɏc��(�ϑ�),7:�݌ɖL�x(�ϑ�),8:�Y���Ȃ�)</param>
        /// <param name="goodsNote">���i����(���s�R�[�h��\n�ɒu��)</param>
        /// <param name="goodsPR">���iPR(���s�R�[�h��\n�ɒu��)</param>
        /// <param name="suggestPrice">��]�������i</param>
        /// <param name="shopPrice">�X�����i</param>
        /// <param name="tradePrice">���l</param>
        /// <param name="purchaseCost">�d������</param>
        /// <param name="pMUpdateTime">PM�X�V����(�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="searchTag1">�����^�O1</param>
        /// <param name="searchTag2">�����^�O2</param>
        /// <param name="searchTag3">�����^�O3</param>
        /// <param name="searchTag4">�����^�O4</param>
        /// <param name="searchTag5">�����^�O5</param>
        /// <param name="searchTag6">�����^�O6</param>
        /// <param name="searchTag7">�����^�O7</param>
        /// <param name="searchTag8">�����^�O8</param>
        /// <param name="searchTag9">�����^�O9</param>
        /// <param name="searchTag10">�����^�O10</param>
        /// <param name="stockCnt">�݌ɐ�</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="bLGoodsDrCode">BL���i�R�[�h�}��</param>
        /// <param name="shopSaleBeginDate">���J�J�n��</param>
        /// <param name="shopSaleEndDate">���J�I����</param>
        /// 
        /// <returns>Propose_Goods�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Propose_Goods�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Propose_Goods(string sectionCode, long goodsCategory, string goodsNo, string goodsName, Int32 goodsMakerCd, string makerName, Int32 releaseDate, Int16 stockStatusDiv, string goodsNote, string goodsPR, Double suggestPrice, Double shopPrice, Double tradePrice, Double purchaseCost, Int64 pMUpdateTime, string searchTag1, string searchTag2, string searchTag3, string searchTag4, string searchTag5, string searchTag6, string searchTag7, string searchTag8, string searchTag9, string searchTag10, Double stockCnt, Int32 bLGoodsCode, Int32 bLGoodsDrCode, Int32 shopSaleBeginDate, Int32 shopSaleEndDate)
        {
            this._sectionCode = sectionCode;
            this._goodsCategory = goodsCategory;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._goodsMakerCd = goodsMakerCd;
            this._makerName = makerName;
            this._releaseDate = releaseDate;
            this._stockStatusDiv = stockStatusDiv;
            this._goodsNote = goodsNote;
            this._goodsPR = goodsPR;
            this._suggestPrice = suggestPrice;
            this._shopPrice = shopPrice;
            this._tradePrice = tradePrice;
            this._purchaseCost = purchaseCost;
            this._pMUpdateTime = pMUpdateTime;
            this._searchTag1 = searchTag1;
            this._searchTag2 = searchTag2;
            this._searchTag3 = searchTag3;
            this._searchTag4 = searchTag4;
            this._searchTag5 = searchTag5;
            this._searchTag6 = searchTag6;
            this._searchTag7 = searchTag7;
            this._searchTag8 = searchTag8;
            this._searchTag9 = searchTag9;
            this._searchTag10 = searchTag10;
            this._stockCnt = stockCnt;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsDrCode = bLGoodsDrCode;
            this._shopSaleBeginDate = shopSaleBeginDate;
            this._shopSaleEndDate = shopSaleEndDate;
        }

        /// <summary>
        /// ��ď��i�N���X��������
        /// </summary>
        /// <returns>Propose_Goods�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����Propose_Goods�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Propose_Goods Clone()
        {
            return new Propose_Goods(this._sectionCode, this._goodsCategory, this._goodsNo, this._goodsName, this._goodsMakerCd, this._makerName, this._releaseDate, this._stockStatusDiv, this._goodsNote, this._goodsPR, this._suggestPrice, this._shopPrice, this._tradePrice, this._purchaseCost, this._pMUpdateTime, this._searchTag1, this._searchTag2, this._searchTag3, this._searchTag4, this._searchTag5, this._searchTag6, this._searchTag7, this._searchTag8, this._searchTag9, this._searchTag10, this._stockCnt, this._bLGoodsCode, this._bLGoodsDrCode, this._shopSaleBeginDate, this._shopSaleEndDate);
        }

        /// <summary>
        /// ��ď��i�N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�Propose_Goods�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Propose_Goods�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(Propose_Goods target)
        {
            return ((this.SectionCode == target.SectionCode)
                 && (this.GoodsCategory == target.GoodsCategory)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsName == target.GoodsName)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.MakerName == target.MakerName)
                 && (this.ReleaseDate == target.ReleaseDate)
                 && (this.StockStatusDiv == target.StockStatusDiv)
                 && (this.GoodsNote == target.GoodsNote)
                 && (this.GoodsPR == target.GoodsPR)
                 && (this.SuggestPrice == target.SuggestPrice)
                 && (this.ShopPrice == target.ShopPrice)
                 && (this.TradePrice == target.TradePrice)
                 && (this.PurchaseCost == target.PurchaseCost)
                 && (this.PMUpdateTime == target.PMUpdateTime)
                 && (this.SearchTag1 == target.SearchTag1)
                 && (this.SearchTag2 == target.SearchTag2)
                 && (this.SearchTag3 == target.SearchTag3)
                 && (this.SearchTag4 == target.SearchTag4)
                 && (this.SearchTag5 == target.SearchTag5)
                 && (this.SearchTag6 == target.SearchTag6)
                 && (this.SearchTag7 == target.SearchTag7)
                 && (this.SearchTag8 == target.SearchTag8)
                 && (this.SearchTag9 == target.SearchTag9)
                 && (this.SearchTag10 == target.SearchTag10)
                 && (this.StockCnt == target.StockCnt)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.ShopSaleBeginDate == target.ShopSaleBeginDate)
                 && (this.ShopSaleEndDate == target.ShopSaleEndDate)
                 && (this.BLGoodsDrCode == target.BLGoodsDrCode));
        }

        /// <summary>
        /// ��ď��i�N���X��r����
        /// </summary>
        /// <param name="propose_Goods1">
        ///                    ��r����Propose_Goods�N���X�̃C���X�^���X
        /// </param>
        /// <param name="propose_Goods2">��r����Propose_Goods�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Propose_Goods�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(Propose_Goods propose_Goods1, Propose_Goods propose_Goods2)
        {
            return ((propose_Goods1.SectionCode == propose_Goods2.SectionCode)
                 && (propose_Goods1.GoodsCategory == propose_Goods2.GoodsCategory)
                 && (propose_Goods1.GoodsNo == propose_Goods2.GoodsNo)
                 && (propose_Goods1.GoodsName == propose_Goods2.GoodsName)
                 && (propose_Goods1.GoodsMakerCd == propose_Goods2.GoodsMakerCd)
                 && (propose_Goods1.MakerName == propose_Goods2.MakerName)
                 && (propose_Goods1.ReleaseDate == propose_Goods2.ReleaseDate)
                 && (propose_Goods1.StockStatusDiv == propose_Goods2.StockStatusDiv)
                 && (propose_Goods1.GoodsNote == propose_Goods2.GoodsNote)
                 && (propose_Goods1.GoodsPR == propose_Goods2.GoodsPR)
                 && (propose_Goods1.SuggestPrice == propose_Goods2.SuggestPrice)
                 && (propose_Goods1.ShopPrice == propose_Goods2.ShopPrice)
                 && (propose_Goods1.TradePrice == propose_Goods2.TradePrice)
                 && (propose_Goods1.PurchaseCost == propose_Goods2.PurchaseCost)
                 && (propose_Goods1.PMUpdateTime == propose_Goods2.PMUpdateTime)
                 && (propose_Goods1.SearchTag1 == propose_Goods2.SearchTag1)
                 && (propose_Goods1.SearchTag2 == propose_Goods2.SearchTag2)
                 && (propose_Goods1.SearchTag3 == propose_Goods2.SearchTag3)
                 && (propose_Goods1.SearchTag4 == propose_Goods2.SearchTag4)
                 && (propose_Goods1.SearchTag5 == propose_Goods2.SearchTag5)
                 && (propose_Goods1.SearchTag6 == propose_Goods2.SearchTag6)
                 && (propose_Goods1.SearchTag7 == propose_Goods2.SearchTag7)
                 && (propose_Goods1.SearchTag8 == propose_Goods2.SearchTag8)
                 && (propose_Goods1.SearchTag9 == propose_Goods2.SearchTag9)
                 && (propose_Goods1.SearchTag10 == propose_Goods2.SearchTag10)
                 && (propose_Goods1.StockCnt == propose_Goods2.StockCnt)
                 && (propose_Goods1.BLGoodsCode == propose_Goods2.BLGoodsCode)
                 && (propose_Goods1.ShopSaleBeginDate == propose_Goods2.ShopSaleBeginDate)
                 && (propose_Goods1.ShopSaleEndDate == propose_Goods2.ShopSaleEndDate)
                 && (propose_Goods1.BLGoodsDrCode == propose_Goods2.BLGoodsDrCode));
        }
        /// <summary>
        /// ��ď��i�N���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�Propose_Goods�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Propose_Goods�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(Propose_Goods target)
        {
            ArrayList resList = new ArrayList();
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.GoodsCategory != target.GoodsCategory) resList.Add("GoodsCategory");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.MakerName != target.MakerName) resList.Add("MakerName");
            if (this.ReleaseDate != target.ReleaseDate) resList.Add("ReleaseDate");
            if (this.StockStatusDiv != target.StockStatusDiv) resList.Add("StockStatusDiv");
            if (this.GoodsNote != target.GoodsNote) resList.Add("GoodsNote");
            if (this.GoodsPR != target.GoodsPR) resList.Add("GoodsPR");
            if (this.SuggestPrice != target.SuggestPrice) resList.Add("SuggestPrice");
            if (this.ShopPrice != target.ShopPrice) resList.Add("ShopPrice");
            if (this.TradePrice != target.TradePrice) resList.Add("TradePrice");
            if (this.PurchaseCost != target.PurchaseCost) resList.Add("PurchaseCost");
            if (this.PMUpdateTime != target.PMUpdateTime) resList.Add("PMUpdateTime");
            if (this.SearchTag1 != target.SearchTag1) resList.Add("SearchTag1");
            if (this.SearchTag2 != target.SearchTag2) resList.Add("SearchTag2");
            if (this.SearchTag3 != target.SearchTag3) resList.Add("SearchTag3");
            if (this.SearchTag4 != target.SearchTag4) resList.Add("SearchTag4");
            if (this.SearchTag5 != target.SearchTag5) resList.Add("SearchTag5");
            if (this.SearchTag6 != target.SearchTag6) resList.Add("SearchTag6");
            if (this.SearchTag7 != target.SearchTag7) resList.Add("SearchTag7");
            if (this.SearchTag8 != target.SearchTag8) resList.Add("SearchTag8");
            if (this.SearchTag9 != target.SearchTag9) resList.Add("SearchTag9");
            if (this.SearchTag10 != target.SearchTag10) resList.Add("SearchTag10");
            if (this.StockCnt != target.StockCnt) resList.Add("StockCnt");
            if (this.ShopSaleBeginDate != target.ShopSaleBeginDate) resList.Add("ShopSaleBeginDate");
            if (this.ShopSaleEndDate != target.ShopSaleEndDate) resList.Add("ShopSaleEndDate");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsDrCode != target.BLGoodsDrCode) resList.Add("BLGoodsDrCode");

            return resList;
        }

        /// <summary>
        /// ��ď��i�N���X��r����
        /// </summary>
        /// <param name="propose_Goods1">��r����Propose_Goods�N���X�̃C���X�^���X</param>
        /// <param name="propose_Goods2">��r����Propose_Goods�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   Propose_Goods�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(Propose_Goods propose_Goods1, Propose_Goods propose_Goods2)
        {
            ArrayList resList = new ArrayList();
            if (propose_Goods1.SectionCode != propose_Goods2.SectionCode) resList.Add("SectionCode");
            if (propose_Goods1.GoodsCategory != propose_Goods2.GoodsCategory) resList.Add("GoodsCategory");
            if (propose_Goods1.GoodsNo != propose_Goods2.GoodsNo) resList.Add("GoodsNo");
            if (propose_Goods1.GoodsName != propose_Goods2.GoodsName) resList.Add("GoodsName");
            if (propose_Goods1.GoodsMakerCd != propose_Goods2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (propose_Goods1.MakerName != propose_Goods2.MakerName) resList.Add("MakerName");
            if (propose_Goods1.ReleaseDate != propose_Goods2.ReleaseDate) resList.Add("ReleaseDate");
            if (propose_Goods1.StockStatusDiv != propose_Goods2.StockStatusDiv) resList.Add("StockStatusDiv");
            if (propose_Goods1.GoodsNote != propose_Goods2.GoodsNote) resList.Add("GoodsNote");
            if (propose_Goods1.GoodsPR != propose_Goods2.GoodsPR) resList.Add("GoodsPR");
            if (propose_Goods1.SuggestPrice != propose_Goods2.SuggestPrice) resList.Add("SuggestPrice");
            if (propose_Goods1.ShopPrice != propose_Goods2.ShopPrice) resList.Add("ShopPrice");
            if (propose_Goods1.TradePrice != propose_Goods2.TradePrice) resList.Add("TradePrice");
            if (propose_Goods1.PurchaseCost != propose_Goods2.PurchaseCost) resList.Add("PurchaseCost");
            if (propose_Goods1.PMUpdateTime != propose_Goods2.PMUpdateTime) resList.Add("PMUpdateTime");
            if (propose_Goods1.SearchTag1 != propose_Goods2.SearchTag1) resList.Add("SearchTag1");
            if (propose_Goods1.SearchTag2 != propose_Goods2.SearchTag2) resList.Add("SearchTag2");
            if (propose_Goods1.SearchTag3 != propose_Goods2.SearchTag3) resList.Add("SearchTag3");
            if (propose_Goods1.SearchTag4 != propose_Goods2.SearchTag4) resList.Add("SearchTag4");
            if (propose_Goods1.SearchTag5 != propose_Goods2.SearchTag5) resList.Add("SearchTag5");
            if (propose_Goods1.SearchTag6 != propose_Goods2.SearchTag6) resList.Add("SearchTag6");
            if (propose_Goods1.SearchTag7 != propose_Goods2.SearchTag7) resList.Add("SearchTag7");
            if (propose_Goods1.SearchTag8 != propose_Goods2.SearchTag8) resList.Add("SearchTag8");
            if (propose_Goods1.SearchTag9 != propose_Goods2.SearchTag9) resList.Add("SearchTag9");
            if (propose_Goods1.SearchTag10 != propose_Goods2.SearchTag10) resList.Add("SearchTag10");
            if (propose_Goods1.StockCnt != propose_Goods2.StockCnt) resList.Add("StockCnt");
            if (propose_Goods1.ShopSaleBeginDate != propose_Goods2.ShopSaleBeginDate) resList.Add("ShopSaleBeginDate");
            if (propose_Goods1.ShopSaleEndDate != propose_Goods2.ShopSaleEndDate) resList.Add("ShopSaleEndDate");
            if (propose_Goods1.BLGoodsCode != propose_Goods2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (propose_Goods1.BLGoodsDrCode != propose_Goods2.BLGoodsDrCode) resList.Add("BLGoodsDrCode");

            return resList;
        }
    }
}
