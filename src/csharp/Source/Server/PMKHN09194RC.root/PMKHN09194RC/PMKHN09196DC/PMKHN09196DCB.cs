//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�i�e�L�X�g�ϊ����ʁj
// �v���O�����T�v   : ���i�i�e�L�X�g�ϊ����ʁj���[�N
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902160-00  �쐬�S�� : ���z
// �� �� ��  K2013/08/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsTextExpRetWork
    /// <summary>
    ///                      ���i�i�e�L�X�g�ϊ����ʁj���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�i�e�L�X�g�ϊ����ʁj���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2013/8/9</br>
    /// <br>Genarated Date   :   2013/09/24  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsTextExpRetWork
    {
        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>BL���i�R�[�h���́i�S�p�j</summary>
        private string _bLGoodsFullName = "";

        /// <summary>BL���i�R�[�h���́i���p�j</summary>
        private string _bLGoodsHalfName = "";

        /// <summary>BL�O���[�v�R�[�h</summary>
        private Int32 _bLGroupCode;

        /// <summary>BL�O���[�v�R�[�h����</summary>
        private string _bLGroupName = "";

        /// <summary>BL�O���[�v�R�[�h�J�i����</summary>
        /// <remarks>���p�J�i</remarks>
        private string _bLGroupKanaName = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>�艿</summary>
        private Double _listPrice;

        /// <summary>�d����</summary>
        private Double _stockRate;

        /// <summary>�����P��</summary>
        /// <remarks>�d���P�� �� ���㌴���œ���</remarks>
        private Double _salesUnitCost;

        /// <summary>���i�����ރR�[�h</summary>
        /// <remarks>��������</remarks>
        private Int32 _goodsMGroup;

        /// <summary>���i�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _priceStartDate;

        /// <summary>�K�p�̉��i�J�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _setPriceStartDate;


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

        /// public propaty name  :  BLGroupCode
        /// <summary>BL�O���[�v�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  BLGroupKanaName
        /// <summary>BL�O���[�v�R�[�h�J�i���̃v���p�e�B</summary>
        /// <value>���p�J�i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�O���[�v�R�[�h�J�i���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGroupKanaName
        {
            get { return _bLGroupKanaName; }
            set { _bLGroupKanaName = value; }
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

        /// public propaty name  :  ListPrice
        /// <summary>�艿�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�v���p�e�B</br>
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
        /// <value>�d���P�� �� ���㌴���œ���</value>
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

        /// public propaty name  :  GoodsMGroup
        /// <summary>���i�����ރR�[�h�v���p�e�B</summary>
        /// <value>��������</value>
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

        /// public propaty name  :  PriceStartDate
        /// <summary>���i�J�n���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  SetPriceStartDate
        /// <summary>�K�p�̉��i�J�n���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �K�p�̉��i�J�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SetPriceStartDate
        {
            get { return _setPriceStartDate; }
            set { _setPriceStartDate = value; }
        }


        /// <summary>
        /// ���i�i�e�L�X�g�ϊ����ʁj���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>GoodsTextExpRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsTextExpRetWork()
        {
        }

        /// <summary>
        /// ���i�i�e�L�X�g�ϊ����ʁj���[�N�R���X�g���N�^
        /// </summary>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="bLGoodsFullName">BL���i�R�[�h���́i�S�p�j</param>
        /// <param name="bLGoodsHalfName">BL���i�R�[�h���́i���p�j</param>
        /// <param name="bLGroupCode">BL�O���[�v�R�[�h</param>
        /// <param name="bLGroupName">BL�O���[�v�R�[�h����</param>
        /// <param name="bLGroupKanaName">BL�O���[�v�R�[�h�J�i����(���p�J�i)</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="goodsName">���i����</param>
        /// <param name="listPrice">�艿</param>
        /// <param name="stockRate">�d����</param>
        /// <param name="salesUnitCost">�����P��(�d���P�� �� ���㌴���œ���)</param>
        /// <param name="goodsMGroup">���i�����ރR�[�h(��������)</param>
        /// <param name="priceStartDate">���i�J�n��(YYYYMMDD)</param>
        /// <param name="setPriceStartDate">�K�p�̉��i�J�n��(YYYYMMDD)</param>
        /// <returns>GoodsTextExpRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpRetWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsTextExpRetWork(string goodsNo, Int32 goodsMakerCd, Int32 bLGoodsCode, string bLGoodsFullName, string bLGoodsHalfName, Int32 bLGroupCode, string bLGroupName, string bLGroupKanaName, Int32 supplierCd, string goodsName, Double listPrice, Double stockRate, Double salesUnitCost, Int32 goodsMGroup, Int32 priceStartDate, Int32 setPriceStartDate)
        {
            this._goodsNo = goodsNo;
            this._goodsMakerCd = goodsMakerCd;
            this._bLGoodsCode = bLGoodsCode;
            this._bLGoodsFullName = bLGoodsFullName;
            this._bLGoodsHalfName = bLGoodsHalfName;
            this._bLGroupCode = bLGroupCode;
            this._bLGroupName = bLGroupName;
            this._bLGroupKanaName = bLGroupKanaName;
            this._supplierCd = supplierCd;
            this._goodsName = goodsName;
            this._listPrice = listPrice;
            this._stockRate = stockRate;
            this._salesUnitCost = salesUnitCost;
            this._goodsMGroup = goodsMGroup;
            this._priceStartDate = priceStartDate;
            this._setPriceStartDate = setPriceStartDate;

        }

        /// <summary>
        /// ���i�i�e�L�X�g�ϊ����ʁj���[�N��������
        /// </summary>
        /// <returns>GoodsTextExpRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����GoodsTextExpRetWork�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsTextExpRetWork Clone()
        {
            return new GoodsTextExpRetWork(this._goodsNo, this._goodsMakerCd, this._bLGoodsCode, this._bLGoodsFullName, this._bLGoodsHalfName, this._bLGroupCode, this._bLGroupName, this._bLGroupKanaName, this._supplierCd, this._goodsName, this._listPrice, this._stockRate, this._salesUnitCost, this._goodsMGroup, this._priceStartDate, this._setPriceStartDate);
        }

        /// <summary>
        /// ���i�i�e�L�X�g�ϊ����ʁj���[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�GoodsTextExpRetWork�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpRetWork�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(GoodsTextExpRetWork target)
        {
            return ((this.GoodsNo == target.GoodsNo)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.BLGoodsFullName == target.BLGoodsFullName)
                 && (this.BLGoodsHalfName == target.BLGoodsHalfName)
                 && (this.BLGroupCode == target.BLGroupCode)
                 && (this.BLGroupName == target.BLGroupName)
                 && (this.BLGroupKanaName == target.BLGroupKanaName)
                 && (this.SupplierCd == target.SupplierCd)
                 && (this.GoodsName == target.GoodsName)
                 && (this.ListPrice == target.ListPrice)
                 && (this.StockRate == target.StockRate)
                 && (this.SalesUnitCost == target.SalesUnitCost)
                 && (this.GoodsMGroup == target.GoodsMGroup)
                 && (this.PriceStartDate == target.PriceStartDate)
                 && (this.SetPriceStartDate == target.SetPriceStartDate));
        }

        /// <summary>
        /// ���i�i�e�L�X�g�ϊ����ʁj���[�N��r����
        /// </summary>
        /// <param name="goodsTextExpRet1">
        ///                    ��r����GoodsTextExpRetWork�N���X�̃C���X�^���X
        /// </param>
        /// <param name="goodsTextExpRet2">��r����GoodsTextExpRetWork�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpRetWork�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(GoodsTextExpRetWork goodsTextExpRet1, GoodsTextExpRetWork goodsTextExpRet2)
        {
            return ((goodsTextExpRet1.GoodsNo == goodsTextExpRet2.GoodsNo)
                 && (goodsTextExpRet1.GoodsMakerCd == goodsTextExpRet2.GoodsMakerCd)
                 && (goodsTextExpRet1.BLGoodsCode == goodsTextExpRet2.BLGoodsCode)
                 && (goodsTextExpRet1.BLGoodsFullName == goodsTextExpRet2.BLGoodsFullName)
                 && (goodsTextExpRet1.BLGoodsHalfName == goodsTextExpRet2.BLGoodsHalfName)
                 && (goodsTextExpRet1.BLGroupCode == goodsTextExpRet2.BLGroupCode)
                 && (goodsTextExpRet1.BLGroupName == goodsTextExpRet2.BLGroupName)
                 && (goodsTextExpRet1.BLGroupKanaName == goodsTextExpRet2.BLGroupKanaName)
                 && (goodsTextExpRet1.SupplierCd == goodsTextExpRet2.SupplierCd)
                 && (goodsTextExpRet1.GoodsName == goodsTextExpRet2.GoodsName)
                 && (goodsTextExpRet1.ListPrice == goodsTextExpRet2.ListPrice)
                 && (goodsTextExpRet1.StockRate == goodsTextExpRet2.StockRate)
                 && (goodsTextExpRet1.SalesUnitCost == goodsTextExpRet2.SalesUnitCost)
                 && (goodsTextExpRet1.GoodsMGroup == goodsTextExpRet2.GoodsMGroup)
                 && (goodsTextExpRet1.PriceStartDate == goodsTextExpRet2.PriceStartDate)
                 && (goodsTextExpRet1.SetPriceStartDate == goodsTextExpRet2.SetPriceStartDate));
        }
        /// <summary>
        /// ���i�i�e�L�X�g�ϊ����ʁj���[�N��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�GoodsTextExpRetWork�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpRetWork�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(GoodsTextExpRetWork target)
        {
            ArrayList resList = new ArrayList();
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.BLGoodsCode != target.BLGoodsCode) resList.Add("BLGoodsCode");
            if (this.BLGoodsFullName != target.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (this.BLGoodsHalfName != target.BLGoodsHalfName) resList.Add("BLGoodsHalfName");
            if (this.BLGroupCode != target.BLGroupCode) resList.Add("BLGroupCode");
            if (this.BLGroupName != target.BLGroupName) resList.Add("BLGroupName");
            if (this.BLGroupKanaName != target.BLGroupKanaName) resList.Add("BLGroupKanaName");
            if (this.SupplierCd != target.SupplierCd) resList.Add("SupplierCd");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.ListPrice != target.ListPrice) resList.Add("ListPrice");
            if (this.StockRate != target.StockRate) resList.Add("StockRate");
            if (this.SalesUnitCost != target.SalesUnitCost) resList.Add("SalesUnitCost");
            if (this.GoodsMGroup != target.GoodsMGroup) resList.Add("GoodsMGroup");
            if (this.PriceStartDate != target.PriceStartDate) resList.Add("PriceStartDate");
            if (this.SetPriceStartDate != target.SetPriceStartDate) resList.Add("SetPriceStartDate");

            return resList;
        }

        /// <summary>
        /// ���i�i�e�L�X�g�ϊ����ʁj���[�N��r����
        /// </summary>
        /// <param name="goodsTextExpRet1">��r����GoodsTextExpRetWork�N���X�̃C���X�^���X</param>
        /// <param name="goodsTextExpRet2">��r����GoodsTextExpRetWork�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpRetWork�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(GoodsTextExpRetWork goodsTextExpRet1, GoodsTextExpRetWork goodsTextExpRet2)
        {
            ArrayList resList = new ArrayList();
            if (goodsTextExpRet1.GoodsNo != goodsTextExpRet2.GoodsNo) resList.Add("GoodsNo");
            if (goodsTextExpRet1.GoodsMakerCd != goodsTextExpRet2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (goodsTextExpRet1.BLGoodsCode != goodsTextExpRet2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (goodsTextExpRet1.BLGoodsFullName != goodsTextExpRet2.BLGoodsFullName) resList.Add("BLGoodsFullName");
            if (goodsTextExpRet1.BLGoodsHalfName != goodsTextExpRet2.BLGoodsHalfName) resList.Add("BLGoodsHalfName");
            if (goodsTextExpRet1.BLGroupCode != goodsTextExpRet2.BLGroupCode) resList.Add("BLGroupCode");
            if (goodsTextExpRet1.BLGroupName != goodsTextExpRet2.BLGroupName) resList.Add("BLGroupName");
            if (goodsTextExpRet1.BLGroupKanaName != goodsTextExpRet2.BLGroupKanaName) resList.Add("BLGroupKanaName");
            if (goodsTextExpRet1.SupplierCd != goodsTextExpRet2.SupplierCd) resList.Add("SupplierCd");
            if (goodsTextExpRet1.GoodsName != goodsTextExpRet2.GoodsName) resList.Add("GoodsName");
            if (goodsTextExpRet1.ListPrice != goodsTextExpRet2.ListPrice) resList.Add("ListPrice");
            if (goodsTextExpRet1.StockRate != goodsTextExpRet2.StockRate) resList.Add("StockRate");
            if (goodsTextExpRet1.SalesUnitCost != goodsTextExpRet2.SalesUnitCost) resList.Add("SalesUnitCost");
            if (goodsTextExpRet1.GoodsMGroup != goodsTextExpRet2.GoodsMGroup) resList.Add("GoodsMGroup");
            if (goodsTextExpRet1.PriceStartDate != goodsTextExpRet2.PriceStartDate) resList.Add("PriceStartDate");
            if (goodsTextExpRet1.SetPriceStartDate != goodsTextExpRet2.SetPriceStartDate) resList.Add("SetPriceStartDate");

            return resList;
        }
    }
    /// <summary>
    ///  Ver5.10.1.0�p�̃J�X�^���V���C�A���C�U�ł��B
    /// </summary>
    /// <returns>GoodsTextExpRetWork�N���X�̃C���X�^���X(object)</returns>
    /// <remarks>
    /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
    /// <br>Programer        :   ��������</br>
    /// </remarks>
    public class GoodsTextExpRetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate �����o

        /// <summary>
        ///  Ver5.10.1.0�p�̃J�X�^���V���A���C�U�ł�
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpRetWork�N���X�̃J�X�^���V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  GoodsTextExpRetWork_SerializationSurrogate_For_V51010.Serialize ������ǉ����܂��B
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is GoodsTextExpRetWork || graph is ArrayList || graph is GoodsTextExpRetWork[]))
                throw new ArgumentException(string.Format("graph��{0}�̃C���X�^���X�ł���܂���", typeof(GoodsTextExpRetWork).FullName));

            if (graph != null && graph is GoodsTextExpRetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graph�̌^:{0}���J�X�^���V���A���C�Y�̑Ώۂł���܂���", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.GoodsTextExpRetWork");

            //�J��Ԃ����̔�����s���܂��B���̕����͓K�X�Ɩ��v���ɉ����čs���Ă��������B
            int occurrence = 0;     //��ʂɃ[���̏ꍇ�����肦�܂�
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is GoodsTextExpRetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((GoodsTextExpRetWork[])graph).Length;
            }
            else if (graph is GoodsTextExpRetWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //�J��Ԃ���	

            //���i�ԍ�
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //���i���[�J�[�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //BL���i�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL���i�R�[�h���́i�S�p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //BL���i�R�[�h���́i���p�j
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsHalfName
            //BL�O���[�v�R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BL�O���[�v�R�[�h����
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupName
            //BL�O���[�v�R�[�h�J�i����
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupKanaName
            //�d����R�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //���i����
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //�艿
            serInfo.MemberInfo.Add(typeof(Double)); //ListPrice
            //�d����
            serInfo.MemberInfo.Add(typeof(Double)); //StockRate
            //�����P��
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //���i�����ރR�[�h
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //���i�J�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceStartDate
            //�K�p�̉��i�J�n��
            serInfo.MemberInfo.Add(typeof(Int32)); //SetPriceStartDate


            serInfo.Serialize(writer, serInfo);
            if (graph is GoodsTextExpRetWork)
            {
                GoodsTextExpRetWork temp = (GoodsTextExpRetWork)graph;

                SetGoodsTextExpRetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is GoodsTextExpRetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((GoodsTextExpRetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (GoodsTextExpRetWork temp in lst)
                {
                    SetGoodsTextExpRetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// GoodsTextExpRetWork�����o��(public�v���p�e�B��)
        /// </summary>
        private const int currentMemberCount = 16;

        /// <summary>
        ///  GoodsTextExpRetWork�C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpRetWork�̃C���X�^���X����������</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private void SetGoodsTextExpRetWork(System.IO.BinaryWriter writer, GoodsTextExpRetWork temp)
        {
            //���i�ԍ�
            writer.Write(temp.GoodsNo);
            //���i���[�J�[�R�[�h
            writer.Write(temp.GoodsMakerCd);
            //BL���i�R�[�h
            writer.Write(temp.BLGoodsCode);
            //BL���i�R�[�h���́i�S�p�j
            writer.Write(temp.BLGoodsFullName);
            //BL���i�R�[�h���́i���p�j
            writer.Write(temp.BLGoodsHalfName);
            //BL�O���[�v�R�[�h
            writer.Write(temp.BLGroupCode);
            //BL�O���[�v�R�[�h����
            writer.Write(temp.BLGroupName);
            //BL�O���[�v�R�[�h�J�i����
            writer.Write(temp.BLGroupKanaName);
            //�d����R�[�h
            writer.Write(temp.SupplierCd);
            //���i����
            writer.Write(temp.GoodsName);
            //�艿
            writer.Write(temp.ListPrice);
            //�d����
            writer.Write(temp.StockRate);
            //�����P��
            writer.Write(temp.SalesUnitCost);
            //���i�����ރR�[�h
            writer.Write(temp.GoodsMGroup);
            //���i�J�n��
            writer.Write(temp.PriceStartDate);
            //�K�p�̉��i�J�n��
            writer.Write(temp.SetPriceStartDate);

        }

        /// <summary>
        ///  GoodsTextExpRetWork�C���X�^���X�擾
        /// </summary>
        /// <returns>GoodsTextExpRetWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpRetWork�̃C���X�^���X���擾���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        private GoodsTextExpRetWork GetGoodsTextExpRetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0�Ȃ̂ŕs�v�ł����AV5.1.0.1�ȍ~�ł�
            // serInfo.MemberInfo.Count < currentMemberCount
            // �̃P�[�X�ɂ��Ă̔z�����K�v�ɂȂ�܂��B

            GoodsTextExpRetWork temp = new GoodsTextExpRetWork();

            //���i�ԍ�
            temp.GoodsNo = reader.ReadString();
            //���i���[�J�[�R�[�h
            temp.GoodsMakerCd = reader.ReadInt32();
            //BL���i�R�[�h
            temp.BLGoodsCode = reader.ReadInt32();
            //BL���i�R�[�h���́i�S�p�j
            temp.BLGoodsFullName = reader.ReadString();
            //BL���i�R�[�h���́i���p�j
            temp.BLGoodsHalfName = reader.ReadString();
            //BL�O���[�v�R�[�h
            temp.BLGroupCode = reader.ReadInt32();
            //BL�O���[�v�R�[�h����
            temp.BLGroupName = reader.ReadString();
            //BL�O���[�v�R�[�h�J�i����
            temp.BLGroupKanaName = reader.ReadString();
            //�d����R�[�h
            temp.SupplierCd = reader.ReadInt32();
            //���i����
            temp.GoodsName = reader.ReadString();
            //�艿
            temp.ListPrice = reader.ReadDouble();
            //�d����
            temp.StockRate = reader.ReadDouble();
            //�����P��
            temp.SalesUnitCost = reader.ReadDouble();
            //���i�����ރR�[�h
            temp.GoodsMGroup = reader.ReadInt32();
            //���i�J�n��
            temp.PriceStartDate = reader.ReadInt32();
            //�K�p�̉��i�J�n��
            temp.SetPriceStartDate = reader.ReadInt32();


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
        /// <returns>GoodsTextExpRetWork�N���X�̃C���X�^���X(object)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsTextExpRetWork�N���X�̃J�X�^���f�V���A���C�U���`���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                GoodsTextExpRetWork temp = GetGoodsTextExpRetWork(reader, serInfo);
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
                    retValue = (GoodsTextExpRetWork[])lst.ToArray(typeof(GoodsTextExpRetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

