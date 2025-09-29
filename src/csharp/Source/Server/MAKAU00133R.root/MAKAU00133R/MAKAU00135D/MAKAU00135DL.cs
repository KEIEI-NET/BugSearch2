using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockHistoryWork2
    /// <summary>
    ///                      �݌ɗ����f�[�^���[�N2
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌ɗ����f�[�^���[�N�w�b�_�t�@�C��</br>
    /// <br>Date             :   </br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class StockHistoryWork2 : System.IComparable
    {
        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        /// <remarks>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</remarks>
        private Int32 _goodsMakerCd;

        /// <summary>�q�ɖ���</summary>
        private string _warehouseName = "";

        /// <summary>���i����</summary>
        private string _goodsName = "";

        /// <summary>���[�J�[����</summary>
        private string _makerName = "";

        /// <summary>�d���P���i�Ŕ��C�����j</summary>
        /// <remarks>�I���]���P��</remarks>
        private Double _stockUnitPriceFl;

        /// <summary>�݌ɑ���</summary>
        /// <remarks>���ׁA�o�ׂ��܂ލ݌ɐ��i���o�ד��x�[�X�j</remarks>
        private Double _stockTotal;

        /// <summary>�}�V���݌Ɋz</summary>
        /// <remarks>���ׁA�o�ׂ��܂ލ݌ɋ��z</remarks>
        private Int64 _stockMashinePrice;

        /// <summary>���Ѝ݌ɐ�</summary>
        /// <remarks>���Ђ̎��Y�̍݌ɐ��i�v����x�[�X�j</remarks>
        private Double _propertyStockCnt;

        /// <summary>���Ѝ݌ɋ��z</summary>
        /// <remarks>���Ђ̎��Y�̍݌ɋ��z</remarks>
        private Int64 _propertyStockPrice;

        /// <summary>�}�b�`���O���</summary>
        /// <remarks>0:unmatched�A1:matched</remarks>
        private Int32 _matchingStatus;


        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  GoodsMakerCd
        /// <summary>���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// <value>�߯���ޖ���հ�ް�o�^�͈͂��قȂ�</value>
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

        /// public propaty name  :  StockUnitPriceFl
        /// <summary>�d���P���i�Ŕ��C�����j�v���p�e�B</summary>
        /// <value>�I���]���P��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���P���i�Ŕ��C�����j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockUnitPriceFl
        {
            get { return _stockUnitPriceFl; }
            set { _stockUnitPriceFl = value; }
        }

        /// public propaty name  :  StockTotal
        /// <summary>�݌ɑ����v���p�e�B</summary>
        /// <value>���ׁA�o�ׂ��܂ލ݌ɐ��i���o�ד��x�[�X�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɑ����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double StockTotal
        {
            get { return _stockTotal; }
            set { _stockTotal = value; }
        }

        /// public propaty name  :  StockMashinePrice
        /// <summary>�}�V���݌Ɋz�v���p�e�B</summary>
        /// <value>���ׁA�o�ׂ��܂ލ݌ɋ��z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �}�V���݌Ɋz�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 StockMashinePrice
        {
            get { return _stockMashinePrice; }
            set { _stockMashinePrice = value; }
        }

        /// public propaty name  :  PropertyStockCnt
        /// <summary>���Ѝ݌ɐ��v���p�e�B</summary>
        /// <value>���Ђ̎��Y�̍݌ɐ��i�v����x�[�X�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ѝ݌ɐ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PropertyStockCnt
        {
            get { return _propertyStockCnt; }
            set { _propertyStockCnt = value; }
        }

        /// public propaty name  :  PropertyStockPrice
        /// <summary>���Ѝ݌ɋ��z�v���p�e�B</summary>
        /// <value>���Ђ̎��Y�̍݌ɋ��z</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ѝ݌ɋ��z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 PropertyStockPrice
        {
            get { return _propertyStockPrice; }
            set { _propertyStockPrice = value; }
        }

        /// public propaty name  :  MatchingStatus
        /// <summary>�}�b�`���O��ԃv���p�e�B</summary>
        /// <value>0:unmatched�A1:matched</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �}�b�`���O��ԃv���p�e�B</br>
        /// </remarks>
        public Int32 MatchingStatus
        {
            get { return _matchingStatus; }
            set { _matchingStatus = value; }
        }

        /// <summary>
        /// �݌ɗ����f�[�^���[�N2�R���X�g���N�^
        /// </summary>
        /// <returns>StockHistoryWork2�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockHistoryWork2�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// </remarks>
        public StockHistoryWork2()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        /// <remarks>
        /// System.IComparable��CompareTo���\�b�h�̎���
        /// </remarks>
        public int CompareTo(object obj)
        {
            // this > object	:	���̒l��Ԃ��B
            // this == object	:	0��Ԃ��B
            // this < object	:	���̒l��Ԃ�
            int result;
            if ((result = this.WarehouseCode.CompareTo(((StockHistoryWork2)obj).WarehouseCode)) != 0) return result;
            if ((result = this.SectionCode.CompareTo(((StockHistoryWork2)obj).SectionCode)) != 0) return result;
            if ((result = this.GoodsNo.CompareTo(((StockHistoryWork2)obj).GoodsNo)) != 0) return result;
            return this.GoodsMakerCd - ((StockHistoryWork2)obj).GoodsMakerCd;
        }
    }
}

