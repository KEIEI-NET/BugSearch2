using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockHistoryDspSearchParamWork
    /// <summary>
    ///                      �݌Ɏ��яƉ�o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌Ɏ��яƉ�o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/03  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockHistoryDspSearchParamWork 
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
        /// <summary>�I��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>BL�R�[�h</summary>
        private Int32 _blGoodsCode;
        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>�J�n�N��</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _stAddUpYearMonth;

        /// <summary>�I���N��</summary>
        /// <remarks>YYYYMM</remarks>
        private Int32 _edAddUpYearMonth;

        /// <summary>�J�n�N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _stAddUpADate;

        /// <summary>�I���N����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _edAddUpADate;

        /// <summary>���_�R�[�h</summary>
        private string[] _sectionCodes;

        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
        /// <summary>�q�ɃR�[�h���X�g</summary>
        private List<string> _warehouseCodeList = new List<string>();

        /// <summary>�I�ԃ��X�g</summary>
        private List<string> _warehouseShelfNoList = new List<string>();

        /// <summary>���[�J�[�R�[�h���X�g</summary>
        private List<Int32> _makerCodeList = new List<Int32>();

        /// <summary>BL�R�[�h���X�g</summary>
        private List<Int32> _blGoodsCodeList = new List<Int32>();

        /// <summary>�i�ԃ��X�g</summary>
        private List<string> _goodsNoList = new List<string>();
        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<


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

        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
        /// public propaty name  :  WarehouseShelfNo
        /// <summary>�I�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  BlGoodsCode
        /// <summary>BL�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BlGoodsCode
        {
            get { return _blGoodsCode; }
            set { _blGoodsCode = value; }
        }
        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<

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

        /// public propaty name  :  StAddUpYearMonth
        /// <summary>�J�n�N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StAddUpYearMonth
        {
            get { return _stAddUpYearMonth; }
            set { _stAddUpYearMonth = value; }
        }

        /// public propaty name  :  EdAddUpYearMonth
        /// <summary>�I���N���v���p�e�B</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EdAddUpYearMonth
        {
            get { return _edAddUpYearMonth; }
            set { _edAddUpYearMonth = value; }
        }

        /// public propaty name  :  StAddUpADate
        /// <summary>�J�n�N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StAddUpADate
        {
            get { return _stAddUpADate; }
            set { _stAddUpADate = value; }
        }

        /// public propaty name  :  EdAddUpADate
        /// <summary>�I���N�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EdAddUpADate
        {
            get { return _edAddUpADate; }
            set { _edAddUpADate = value; }
        }

        /// public propaty name  :  SectionCodes
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� -------------------->>>>>
        /// public propaty name  :  WarehouseCodeList
        /// <summary>�q�ɃR�[�h���X�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɃR�[�h���X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<string> WarehouseCodeList
        {
            get { return _warehouseCodeList; }
            set { _warehouseCodeList = value; }
        }

        /// public propaty name  :  WarehouseShelfNoList
        /// <summary>�I�ԃ��X�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԃ��X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<string> WarehouseShelfNoList
        {
            get { return _warehouseShelfNoList; }
            set { _warehouseShelfNoList = value; }
        }

        /// public propaty name  :  MakerCodeList
        /// <summary>���[�J�[�R�[�h���X�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�R�[�h���X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<Int32> MakerCodeList
        {
            get { return _makerCodeList; }
            set { _makerCodeList = value; }
        }

        /// public propaty name  :  BlGoodsCodeList
        /// <summary>BL�R�[�h���X�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h���X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<Int32> BlGoodsCodeList
        {
            get { return _blGoodsCodeList; }
            set { _blGoodsCodeList = value; }
        }

        /// public propaty name  :  GoodsNoList
        /// <summary>�i�ԃR�[�h���X�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԃR�[�h���X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public List<string> GoodsNoList
        {
            get { return _goodsNoList; }
            set { _goodsNoList = value; }
        }
        // ---ADD 2010/07/20 �e�L�X�g�o�͑Ή� --------------------<<<<<

        /// <summary>
        /// �݌Ɏ��яƉ�o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockHistoryDspSearchParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockHistoryDspSearchParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockHistoryDspSearchParamWork()
        {
        }

    }
}
