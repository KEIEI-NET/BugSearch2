using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsPrintParamWork
    /// <summary>
    ///                      ���i������o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i������o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/11  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsPrintParamWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        /// <remarks>(�z��)�@�S�Ўw���null</remarks>
        private string[] _sectionCode;

        /// <summary>�J�n�d����R�[�h</summary>
        private Int32 _supplierCdSt;

        /// <summary>�I���d����R�[�h</summary>
        private Int32 _supplierCdEd;

        /// <summary>�J�n���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCdSt;

        /// <summary>�I�����i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCdEd;

        /// <summary>�J�nBL���i�R�[�h</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>�I��BL���i�R�[�h</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>�J�n���i�ԍ�</summary>
        private string _goodsNoSt = "";

        /// <summary>�I�����i�ԍ�</summary>
        private string _goodsNoEd = "";

        /// <summary>�艿�w��</summary>
        /// <remarks>0:�I�[�v�����i</remarks>
        private Double _listPrice;

        /// <summary>�艿�w��敪</summary>
        /// <remarks>0:���� 1:�ȏ� 2:�ȉ�</remarks>
        private Int32 _listPriceDiv;

        /// <summary>�����w��</summary>
        private Double _salesUnitCost;

        /// <summary>�����w��敪</summary>
        /// <remarks>0:���� 1:�ȏ� 2:�ȉ�</remarks>
        private Int32 _salesUnitCostDiv;


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

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h�v���p�e�B</summary>
        /// <value>(�z��)�@�S�Ўw���null</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// public propaty name  :  SupplierCdSt
        /// <summary>�J�n�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCdSt
        {
            get { return _supplierCdSt; }
            set { _supplierCdSt = value; }
        }

        /// public propaty name  :  SupplierCdEd
        /// <summary>�I���d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCdEd
        {
            get { return _supplierCdEd; }
            set { _supplierCdEd = value; }
        }

        /// public propaty name  :  GoodsMakerCdSt
        /// <summary>�J�n���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdSt
        {
            get { return _goodsMakerCdSt; }
            set { _goodsMakerCdSt = value; }
        }

        /// public propaty name  :  GoodsMakerCdEd
        /// <summary>�I�����i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdEd
        {
            get { return _goodsMakerCdEd; }
            set { _goodsMakerCdEd = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>�J�nBL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�nBL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeSt
        {
            get { return _bLGoodsCodeSt; }
            set { _bLGoodsCodeSt = value; }
        }

        /// public propaty name  :  BLGoodsCodeEd
        /// <summary>�I��BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  GoodsNoSt
        /// <summary>�J�n���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoSt
        {
            get { return _goodsNoSt; }
            set { _goodsNoSt = value; }
        }

        /// public propaty name  :  GoodsNoEd
        /// <summary>�I�����i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoEd
        {
            get { return _goodsNoEd; }
            set { _goodsNoEd = value; }
        }

        /// public propaty name  :  ListPrice
        /// <summary>�艿�w��v���p�e�B</summary>
        /// <value>0:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�w��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double ListPrice
        {
            get { return _listPrice; }
            set { _listPrice = value; }
        }

        /// public propaty name  :  ListPriceDiv
        /// <summary>�艿�w��敪�v���p�e�B</summary>
        /// <value>0:���� 1:�ȏ� 2:�ȉ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �艿�w��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ListPriceDiv
        {
            get { return _listPriceDiv; }
            set { _listPriceDiv = value; }
        }

        /// public propaty name  :  SalesUnitCost
        /// <summary>�����w��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����w��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }

        /// public propaty name  :  SalesUnitCostDiv
        /// <summary>�����w��敪�v���p�e�B</summary>
        /// <value>0:���� 1:�ȏ� 2:�ȉ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����w��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesUnitCostDiv
        {
            get { return _salesUnitCostDiv; }
            set { _salesUnitCostDiv = value; }
        }


        /// <summary>
        /// ���i������o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>GoodsPrintParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsPrintParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsPrintParamWork()
        {
        }
	}
}
