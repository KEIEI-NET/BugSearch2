using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   TrustStockResult
    /// <summary>
    ///                      �ϑ��݌ɕ�[�������o���ʃN���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �ϑ��݌ɕ�[�������o���ʃN���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class TrustStockResult
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�q�ɃR�[�h(�ϑ�)</summary>
        /// <remarks>�q�Ƀ}�X�^</remarks>
        private string _tru_WarehouseCode = "";

        /// <summary>�q�ɖ���(�ϑ�)</summary>
        private string _tru_WarehouseName = "";

        /// <summary>�q�ɃR�[�h(��[��)</summary>
        /// <remarks>�݌Ƀ}�X�^ </remarks>
        private string _rep_WarehouseCode = "";

        /// <summary>�q�ɖ���(��[��)</summary>
        private string _rep_WarehouseName = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���[�J�[����</summary>
        private string _makerShortName = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>�q�ɒI��(�ϑ�)</summary>
        private string _tru_WarehouseShelfNo = "";

        /// <summary>�ō��݌ɐ�</summary>
        private Double _maximumStockCnt;

        /// <summary>�o�׉\��(�ϑ�)</summary>
        /// <remarks>�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</remarks>
        private Double _tru_ShipmentPosCnt;

        /// <summary>��[��</summary>
        /// <remarks>�ϑ��q�ɍō����|�ϑ��q�Ɍ��݌ɐ�</remarks>
        private Double _replenishCount;

        /// <summary>��[�㌻�݌�</summary>
        /// <remarks>�o�׉\���|��[��</remarks>
        private Double _replenishNStockCount;

        /// <summary>�q�ɒI��(��[��)</summary>
        private string _rep_WarehouseShelfNo = "";

        /// <summary>�o�׉\��(��[��)</summary>
        /// <remarks>�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</remarks>
        private Double _rep_ShipmentPosCnt;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>���i���݃t���O</summary>
        /// <remarks>0:�o�^��  1:���o�^</remarks>
        private Int32 _goodsFlg;


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

        /// public propaty name  :  Tru_WarehouseCode
        /// <summary>�q�ɃR�[�h(�ϑ�)�v���p�e�B</summary>
        /// <value>�q�Ƀ}�X�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h(�ϑ�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Tru_WarehouseCode
        {
            get { return _tru_WarehouseCode; }
            set { _tru_WarehouseCode = value; }
        }

        /// public propaty name  :  Tru_WarehouseName
        /// <summary>�q�ɖ���(�ϑ�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ���(�ϑ�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Tru_WarehouseName
        {
            get { return _tru_WarehouseName; }
            set { _tru_WarehouseName = value; }
        }

        /// public propaty name  :  Rep_WarehouseCode
        /// <summary>�q�ɃR�[�h(��[��)�v���p�e�B</summary>
        /// <value>�݌Ƀ}�X�^ </value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h(��[��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Rep_WarehouseCode
        {
            get { return _rep_WarehouseCode; }
            set { _rep_WarehouseCode = value; }
        }

        /// public propaty name  :  Rep_WarehouseName
        /// <summary>�q�ɖ���(��[��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ���(��[��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Rep_WarehouseName
        {
            get { return _rep_WarehouseName; }
            set { _rep_WarehouseName = value; }
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

        /// public propaty name  :  Tru_WarehouseShelfNo
        /// <summary>�q�ɒI��(�ϑ�)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI��(�ϑ�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Tru_WarehouseShelfNo
        {
            get { return _tru_WarehouseShelfNo; }
            set { _tru_WarehouseShelfNo = value; }
        }

        /// public propaty name  :  MaximumStockCnt
        /// <summary>�ō��݌ɐ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ō��݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double MaximumStockCnt
        {
            get { return _maximumStockCnt; }
            set { _maximumStockCnt = value; }
        }

        /// public propaty name  :  Tru_ShipmentPosCnt
        /// <summary>�o�׉\��(�ϑ�)�v���p�e�B</summary>
        /// <value>�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׉\��(�ϑ�)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double Tru_ShipmentPosCnt
        {
            get { return _tru_ShipmentPosCnt; }
            set { _tru_ShipmentPosCnt = value; }
        }

        /// public propaty name  :  ReplenishCount
        /// <summary>��[���v���p�e�B</summary>
        /// <value>�ϑ��q�ɍō����|�ϑ��q�Ɍ��݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ReplenishCount
        {
            get { return _replenishCount; }
            set { _replenishCount = value; }
        }

        /// public propaty name  :  ReplenishNStockCount
        /// <summary>��[�㌻�݌��v���p�e�B</summary>
        /// <value>�o�׉\���|��[��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��[�㌻�݌��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ReplenishNStockCount
        {
            get { return _replenishNStockCount; }
            set { _replenishNStockCount = value; }
        }

        /// public propaty name  :  Rep_WarehouseShelfNo
        /// <summary>�q�ɒI��(��[��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI��(��[��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Rep_WarehouseShelfNo
        {
            get { return _rep_WarehouseShelfNo; }
            set { _rep_WarehouseShelfNo = value; }
        }

        /// public propaty name  :  Rep_ShipmentPosCnt
        /// <summary>�o�׉\��(��[��)�v���p�e�B</summary>
        /// <value>�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�׉\��(��[��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double Rep_ShipmentPosCnt
        {
            get { return _rep_ShipmentPosCnt; }
            set { _rep_ShipmentPosCnt = value; }
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

        /// public propaty name  :  GoodsFlg
        /// <summary>���i���݃t���O�v���p�e�B</summary>
        /// <value>0:�o�^��  1:���o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���݃t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsFlg
        {
            get { return _goodsFlg; }
            set { _goodsFlg = value; }
        }


        /// <summary>
        /// �ϑ��݌ɕ�[�������o���ʃN���X�R���X�g���N�^
        /// </summary>
        /// <returns>TrustStockResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TrustStockResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TrustStockResult()
        {
        }

        /// <summary>
        /// �ϑ��݌ɕ�[�������o���ʃN���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="tru_WarehouseCode">�q�ɃR�[�h(�ϑ�)(�q�Ƀ}�X�^)</param>
        /// <param name="tru_WarehouseName">�q�ɖ���(�ϑ�)</param>
        /// <param name="rep_WarehouseCode">�q�ɃR�[�h(��[��)(�݌Ƀ}�X�^ )</param>
        /// <param name="rep_WarehouseName">�q�ɖ���(��[��)</param>
        /// <param name="goodsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="makerShortName">���[�J�[����</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="goodsName">���i����</param>
        /// <param name="tru_WarehouseShelfNo">�q�ɒI��(�ϑ�)</param>
        /// <param name="maximumStockCnt">�ō��݌ɐ�</param>
        /// <param name="tru_ShipmentPosCnt">�o�׉\��(�ϑ�)(�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�)</param>
        /// <param name="replenishCount">��[��(�ϑ��q�ɍō����|�ϑ��q�Ɍ��݌ɐ�)</param>
        /// <param name="replenishNStockCount">��[�㌻�݌�(�o�׉\���|��[��)</param>
        /// <param name="rep_WarehouseShelfNo">�q�ɒI��(��[��)</param>
        /// <param name="rep_ShipmentPosCnt">�o�׉\��(��[��)(�o�׉\�����d���݌ɐ� �{ ���א��i���v��j�| �o�א��i���v��j�|�󒍐� �| �ړ����d���݌ɐ�)</param>
        /// <param name="enterpriseName">��Ɩ���</param>
        /// <param name="goodsFlg">���i���݃t���O</param>
        /// <returns>TrustStockResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TrustStockResult�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TrustStockResult(string enterpriseCode, string tru_WarehouseCode, string tru_WarehouseName, string rep_WarehouseCode, string rep_WarehouseName, Int32 goodsMakerCd, string makerShortName, string goodsNo, string goodsName, string tru_WarehouseShelfNo, Double maximumStockCnt, Double tru_ShipmentPosCnt, Double replenishCount, Double replenishNStockCount, string rep_WarehouseShelfNo, Double rep_ShipmentPosCnt, string enterpriseName, Int32 goodsFlg)
        {
            this._enterpriseCode = enterpriseCode;
            this._tru_WarehouseCode = tru_WarehouseCode;
            this._tru_WarehouseName = tru_WarehouseName;
            this._rep_WarehouseCode = rep_WarehouseCode;
            this._rep_WarehouseName = rep_WarehouseName;
            this._goodsMakerCd = goodsMakerCd;
            this._makerShortName = makerShortName;
            this._goodsNo = goodsNo;
            this._goodsName = goodsName;
            this._tru_WarehouseShelfNo = tru_WarehouseShelfNo;
            this._maximumStockCnt = maximumStockCnt;
            this._tru_ShipmentPosCnt = tru_ShipmentPosCnt;
            this._replenishCount = replenishCount;
            this._replenishNStockCount = replenishNStockCount;
            this._rep_WarehouseShelfNo = rep_WarehouseShelfNo;
            this._rep_ShipmentPosCnt = rep_ShipmentPosCnt;
            this._enterpriseName = enterpriseName;
            this._goodsFlg = goodsFlg;
        }

        /// <summary>
        /// �ϑ��݌ɕ�[�������o���ʃN���X��������
        /// </summary>
        /// <returns>TrustStockResult�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����TrustStockResult�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TrustStockResult Clone()
        {
            return new TrustStockResult(this._enterpriseCode, this._tru_WarehouseCode, this._tru_WarehouseName, this._rep_WarehouseCode, this._rep_WarehouseName, this._goodsMakerCd, this._makerShortName, this._goodsNo, this._goodsName, this._tru_WarehouseShelfNo, this._maximumStockCnt, this._tru_ShipmentPosCnt, this._replenishCount, this._replenishNStockCount, this._rep_WarehouseShelfNo, this._rep_ShipmentPosCnt, this._enterpriseName, this._goodsFlg);
        }

        /// <summary>
        /// �ϑ��݌ɕ�[�������o���ʃN���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�TrustStockResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TrustStockResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(TrustStockResult target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 && (this.Tru_WarehouseCode == target.Tru_WarehouseCode)
                 && (this.Tru_WarehouseName == target.Tru_WarehouseName)
                 && (this.Rep_WarehouseCode == target.Rep_WarehouseCode)
                 && (this.Rep_WarehouseName == target.Rep_WarehouseName)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.MakerShortName == target.MakerShortName)
                 && (this.GoodsNo == target.GoodsNo)
                 && (this.GoodsName == target.GoodsName)
                 && (this.Tru_WarehouseShelfNo == target.Tru_WarehouseShelfNo)
                 && (this.MaximumStockCnt == target.MaximumStockCnt)
                 && (this.Tru_ShipmentPosCnt == target.Tru_ShipmentPosCnt)
                 && (this.ReplenishCount == target.ReplenishCount)
                 && (this.ReplenishNStockCount == target.ReplenishNStockCount)
                 && (this.Rep_WarehouseShelfNo == target.Rep_WarehouseShelfNo)
                 && (this.Rep_ShipmentPosCnt == target.Rep_ShipmentPosCnt)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.GoodsFlg == target.GoodsFlg));
        }

        /// <summary>
        /// �ϑ��݌ɕ�[�������o���ʃN���X��r����
        /// </summary>
        /// <param name="trustStockResult1">
        ///                    ��r����TrustStockResult�N���X�̃C���X�^���X
        /// </param>
        /// <param name="trustStockResult2">��r����TrustStockResult�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TrustStockResult�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(TrustStockResult trustStockResult1, TrustStockResult trustStockResult2)
        {
            return ((trustStockResult1.EnterpriseCode == trustStockResult2.EnterpriseCode)
                 && (trustStockResult1.Tru_WarehouseCode == trustStockResult2.Tru_WarehouseCode)
                 && (trustStockResult1.Tru_WarehouseName == trustStockResult2.Tru_WarehouseName)
                 && (trustStockResult1.Rep_WarehouseCode == trustStockResult2.Rep_WarehouseCode)
                 && (trustStockResult1.Rep_WarehouseName == trustStockResult2.Rep_WarehouseName)
                 && (trustStockResult1.GoodsMakerCd == trustStockResult2.GoodsMakerCd)
                 && (trustStockResult1.MakerShortName == trustStockResult2.MakerShortName)
                 && (trustStockResult1.GoodsNo == trustStockResult2.GoodsNo)
                 && (trustStockResult1.GoodsName == trustStockResult2.GoodsName)
                 && (trustStockResult1.Tru_WarehouseShelfNo == trustStockResult2.Tru_WarehouseShelfNo)
                 && (trustStockResult1.MaximumStockCnt == trustStockResult2.MaximumStockCnt)
                 && (trustStockResult1.Tru_ShipmentPosCnt == trustStockResult2.Tru_ShipmentPosCnt)
                 && (trustStockResult1.ReplenishCount == trustStockResult2.ReplenishCount)
                 && (trustStockResult1.ReplenishNStockCount == trustStockResult2.ReplenishNStockCount)
                 && (trustStockResult1.Rep_WarehouseShelfNo == trustStockResult2.Rep_WarehouseShelfNo)
                 && (trustStockResult1.Rep_ShipmentPosCnt == trustStockResult2.Rep_ShipmentPosCnt)
                 && (trustStockResult1.EnterpriseName == trustStockResult2.EnterpriseName)
                 && (trustStockResult1.GoodsFlg == trustStockResult2.GoodsFlg));
        }
        /// <summary>
        /// �ϑ��݌ɕ�[�������o���ʃN���X��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�TrustStockResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TrustStockResult�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(TrustStockResult target)
        {
            ArrayList resList = new ArrayList();
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.Tru_WarehouseCode != target.Tru_WarehouseCode) resList.Add("Tru_WarehouseCode");
            if (this.Tru_WarehouseName != target.Tru_WarehouseName) resList.Add("Tru_WarehouseName");
            if (this.Rep_WarehouseCode != target.Rep_WarehouseCode) resList.Add("Rep_WarehouseCode");
            if (this.Rep_WarehouseName != target.Rep_WarehouseName) resList.Add("Rep_WarehouseName");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.MakerShortName != target.MakerShortName) resList.Add("MakerShortName");
            if (this.GoodsNo != target.GoodsNo) resList.Add("GoodsNo");
            if (this.GoodsName != target.GoodsName) resList.Add("GoodsName");
            if (this.Tru_WarehouseShelfNo != target.Tru_WarehouseShelfNo) resList.Add("Tru_WarehouseShelfNo");
            if (this.MaximumStockCnt != target.MaximumStockCnt) resList.Add("MaximumStockCnt");
            if (this.Tru_ShipmentPosCnt != target.Tru_ShipmentPosCnt) resList.Add("Tru_ShipmentPosCnt");
            if (this.ReplenishCount != target.ReplenishCount) resList.Add("ReplenishCount");
            if (this.ReplenishNStockCount != target.ReplenishNStockCount) resList.Add("ReplenishNStockCount");
            if (this.Rep_WarehouseShelfNo != target.Rep_WarehouseShelfNo) resList.Add("Rep_WarehouseShelfNo");
            if (this.Rep_ShipmentPosCnt != target.Rep_ShipmentPosCnt) resList.Add("Rep_ShipmentPosCnt");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.GoodsFlg != target.GoodsFlg) resList.Add("GoodsFlg");

            return resList;
        }

        /// <summary>
        /// �ϑ��݌ɕ�[�������o���ʃN���X��r����
        /// </summary>
        /// <param name="trustStockResult1">��r����TrustStockResult�N���X�̃C���X�^���X</param>
        /// <param name="trustStockResult2">��r����TrustStockResult�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TrustStockResult�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(TrustStockResult trustStockResult1, TrustStockResult trustStockResult2)
        {
            ArrayList resList = new ArrayList();
            if (trustStockResult1.EnterpriseCode != trustStockResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (trustStockResult1.Tru_WarehouseCode != trustStockResult2.Tru_WarehouseCode) resList.Add("Tru_WarehouseCode");
            if (trustStockResult1.Tru_WarehouseName != trustStockResult2.Tru_WarehouseName) resList.Add("Tru_WarehouseName");
            if (trustStockResult1.Rep_WarehouseCode != trustStockResult2.Rep_WarehouseCode) resList.Add("Rep_WarehouseCode");
            if (trustStockResult1.Rep_WarehouseName != trustStockResult2.Rep_WarehouseName) resList.Add("Rep_WarehouseName");
            if (trustStockResult1.GoodsMakerCd != trustStockResult2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (trustStockResult1.MakerShortName != trustStockResult2.MakerShortName) resList.Add("MakerShortName");
            if (trustStockResult1.GoodsNo != trustStockResult2.GoodsNo) resList.Add("GoodsNo");
            if (trustStockResult1.GoodsName != trustStockResult2.GoodsName) resList.Add("GoodsName");
            if (trustStockResult1.Tru_WarehouseShelfNo != trustStockResult2.Tru_WarehouseShelfNo) resList.Add("Tru_WarehouseShelfNo");
            if (trustStockResult1.MaximumStockCnt != trustStockResult2.MaximumStockCnt) resList.Add("MaximumStockCnt");
            if (trustStockResult1.Tru_ShipmentPosCnt != trustStockResult2.Tru_ShipmentPosCnt) resList.Add("Tru_ShipmentPosCnt");
            if (trustStockResult1.ReplenishCount != trustStockResult2.ReplenishCount) resList.Add("ReplenishCount");
            if (trustStockResult1.ReplenishNStockCount != trustStockResult2.ReplenishNStockCount) resList.Add("ReplenishNStockCount");
            if (trustStockResult1.Rep_WarehouseShelfNo != trustStockResult2.Rep_WarehouseShelfNo) resList.Add("Rep_WarehouseShelfNo");
            if (trustStockResult1.Rep_ShipmentPosCnt != trustStockResult2.Rep_ShipmentPosCnt) resList.Add("Rep_ShipmentPosCnt");
            if (trustStockResult1.EnterpriseName != trustStockResult2.EnterpriseName) resList.Add("EnterpriseName");
            if (trustStockResult1.GoodsFlg != trustStockResult2.GoodsFlg) resList.Add("GoodsFlg");

            return resList;
        }
    }
}
