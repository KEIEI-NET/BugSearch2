//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �������i���i����
// �v���O�����T�v   : �������i���i�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/27  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   GoodsInfoData
    /// <summary>
    ///                      ���i�ǉ��f�[�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   �o�׎w���f�[�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/9/29</br>
    /// <br>Genarated Date   :   2008/12/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class GoodsInfoStringData
    {
        #region �� Private Member
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�d���溰��</summary>
        private string _supplierCd;


        /// <summary>Ұ������</summary>
        private string _goodsMakerCd;


        /// <summary>���޺���</summary>
        private string _kindCd = string.Empty;

        /// <summary>������</summary>
        private string _bLGoodsCode;

        /// <summary>�i�@��</summary>
        private string _goodsNo = string.Empty;


        /// <summary>�i�@��</summary>
        private string _goodsName = string.Empty;

        /// <summary>��@��	</summary>
        private string _price;


        /// <summary>���i�������P</summary>
        private string _price1;

        /// <summary>���i�������Q</summary>
        private string _price2;

        /// <summary>���i�������R</summary>
        private string _price3;

        /// <summary>���i���{��</summary>
        private string _priceStartDate;

        /// <summary>�o�^�敪</summary>
        private string _loginFlg = string.Empty;


        /// <summary>������</summary>
        private string _stockRate;

        /// <summary>���@��</summary>
        private string _salesUnitCost;

        /// <summary>���i������</summary>
        private string _goodsTraderCd;


        /// <summary>�t�@�C���쐬���t</summary>
        /// <remarks>�쐬���t</remarks>
        private string _fileCreateDateTime;


        /// <summary>pdf���</summary>
        private string _pdfStatus = "";

        /// <summary>�`�F�b�N���b�Z�[�W</summary>
        private string _checkMessage = "";

        /// <summary>�󎚏�</summary>
        private Int32 _orderby ;

        #endregion


        #region �� Public Propaty
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


        /// public propaty name  :  SupplierCd
        /// <summary>�d���溰�ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d���溰�ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }


        /// public propaty name  :  GoodsMakerCd
        /// <summary>Ұ�����ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   Ұ�����ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  KindCd
        /// <summary>���޺��ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���޺��ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string KindCd
        {
            get { return _kindCd; }
            set { _kindCd = value; }
        }



        /// public propaty name  :  BLGoodsCode
        /// <summary>�����ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }


        /// public propaty name  :  GoodsNo
        /// <summary>�i�@�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�@�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNo
        {
            get { return _goodsNo; }
            set { _goodsNo = value; }
        }


        /// public propaty name  :  GoodsName
        /// <summary>�i�@���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�@���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsName
        {
            get { return _goodsName; }
            set { _goodsName = value; }
        }

        /// public propaty name  :  Price
        /// <summary>��@���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��@���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Price
        {
            get { return _price; }
            set { _price = value; }
        }



        /// public propaty name  :  Price1
        /// <summary>���i�������P�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�������P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Price1
        {
            get { return _price1; }
            set { _price1 = value; }
        }


        /// public propaty name  :  Price2
        /// <summary>���i������2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i������2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Price2
        {
            get { return _price2; }
            set { _price2 = value; }
        }


        /// public propaty name  :  Price3
        /// <summary>���i������3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i������3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Price3
        {
            get { return _price3; }
            set { _price3 = value; }
        }


        /// public propaty name  :  PriceStartDate
        /// <summary>���i���{���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���{���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PriceStartDate
        {
            get { return _priceStartDate; }
            set { _priceStartDate = value; }
        }

        /// public propaty name  :  LoginFlg
        /// <summary>�o�^�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�^�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string LoginFlg
        {
            get { return _loginFlg; }
            set { _loginFlg = value; }
        }

        /// public propaty name  :  StockRate
        /// <summary>�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockRate
        {
            get { return _stockRate; }
            set { _stockRate = value; }
        }


        /// public propaty name  :  SalesUnitCost
        /// <summary>���@���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���@���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesUnitCost
        {
            get { return _salesUnitCost; }
            set { _salesUnitCost = value; }
        }



        /// public propaty name  :  GoodsTraderCd
        /// <summary>���i�����ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i�����ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsTraderCd
        {
            get { return _goodsTraderCd; }
            set { _goodsTraderCd = value; }
        }


        /// public propaty name  :  FileCreateDateTime
        /// <summary>�t�@�C���쐬���t�v���p�e�B</summary>
        /// <value>�쐬���t</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �t�@�C���쐬���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string FileCreateDateTime
        {
            get { return _fileCreateDateTime; }
            set { _fileCreateDateTime = value; }
        }


        /// public propaty name  :  CheckMessage
        /// <summary>pdf��ԃv���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   pdf��ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string PdfStatus
        {
            get { return _pdfStatus; }
            set { _pdfStatus = value; }
        }

        /// public propaty name  :  CheckMessage
        /// <summary>�`�F�b�N���b�Z�[�W�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  �`�F�b�N���b�Z�[�W�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CheckMessage
        {
            get { return _checkMessage; }
            set { _checkMessage = value; }
        }


        /// public propaty name  :  CheckMessage
        /// <summary>�󎚏��v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  �󎚏��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Orderby
        {
            get { return _orderby; }
            set { _orderby = value; }
        }
        #endregion


        #region �� Constructor
        /// <summary>
        /// ���i�ǉ��f�[�^�R���X�g���N�^
        /// </summary>
        /// <returns>DispatchInsts�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   DispatchInsts�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsInfoStringData()
        {
        }
        #endregion
    }
}
