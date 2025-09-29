//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �L�����y�[���}�X�^���
// �v���O�����T�v   : ���o���ʂ��o�͌��ʃC���[�W�\���E�o�c�e�o�́E������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����
// �� �� ��  2011/04/25  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CampaignMasterPrintWork
    /// <summary>
    ///                      �L�����y�[���}�X�^�i����j�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �L�����y�[���}�X�^�i����j�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/04/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CampaignMasterPrintWork
    {
        # region �� private field ��
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���s�^�C�v</summary>
        /// <remarks>1:���[�J�[�{�i�� 2:���[�J�[�{�a�k�R�[�h 3:���[�J�[�{�O���[�v�R�[�h 4:���[�J�[ 5:�a�k�R�[�h 6:�̔��敪 7:�}�X�^���X�g</remarks>
        private Int32 _printType;

        /// <summary>����</summary>
        private Int32 _changePage;

        /// <summary>�J�n�L�����y�[���R�[�h</summary>
        private Int32 _campaignCodeSt;

        /// <summary>�I���L�����y�[���R�[�h</summary>
        private Int32 _campaignCodeEd;

        /// <summary>�J�n���_�R�[�h</summary>
        private string _sectionCodeSt = "";

        /// <summary>�I�����_�R�[�h</summary>
        private string _sectionCodeEd = "";

        /// <summary>�J�n���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCodeSt;

        /// <summary>�I�����i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCodeEd;

        /// <summary>�J�n�O���[�v�R�[�h</summary>
        private Int32 _bLGroupCodeSt;

        /// <summary>�I���O���[�v�R�[�h</summary>
        private Int32 _bLGroupCodeEd;

        /// <summary>�J�n�a�k�R�[�h�R�[�h</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>�I���a�k�R�[�h�R�[�h</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>�J�n�i��</summary>
        private string _goodsNoSt = "";

        /// <summary>�I���i��</summary>
        private string _goodsNoEd = "";

        /// <summary>�J�n�̔��敪�R�[�h</summary>
        private Int32 _salesCodeSt;

        /// <summary>�I���̔��敪�R�[�h</summary>
        private Int32 _salesCodeEd;

        /// <summary>������</summary>
        private Double _rateVal;

        /// <summary>�������w��敪</summary>
        /// <remarks>0:�w��Ȃ� 1:���� 2:�ȏ� 3:�ȉ�</remarks>
        private Int32 _rateValDiv;

        /// <summary>�����z</summary>
        private Double _priceFl;

        /// <summary>�����z�w��敪</summary>
        /// <remarks>0:�w��Ȃ� 1:���� 2:�ȏ� 3:�ȉ�</remarks>
        private Int32 _priceFlDiv;

        /// <summary>�l����</summary>
        private Double _discountRate;

        /// <summary>�l�����w��敪</summary>
        /// <remarks>0:�w��Ȃ� 1:���� 2:�ȏ� 3:�ȉ�</remarks>
        private Int32 _discountRateDiv;

        /// <summary>�폜�w��敪</summary>
        /// <remarks>0:�L��,1:�_���폜</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�J�n�폜���t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _deleteDateTimeSt;

        /// <summary>�I���폜���t</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _deleteDateTimeEd;

        # endregion  �� private field ��

        # region �� public propaty ��
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

        /// public propaty name  :  PrintType
        /// <summary>����p�^�[���v���p�e�B</summary>
        /// <value>0:���_ 1:���_-���� 2:���_-�S���� 3:���_-�󒍎� 4:���_-���s�� 5:���_-�̔��敪 6:���_-���i�敪 7:���_-���Ӑ� 8:���_-�Ǝ� 9:���_-�n��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����p�^�[���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintType
        {
            get { return _printType; }
            set { _printType = value; }
        }

        /// public propaty name  :  ChangePage
        /// <summary>���Ńv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ChangePage
        {
            get { return _changePage; }
            set { _changePage = value; }
        }

        /// public propaty name  :  CampaignCodeSt
        /// <summary>�J�n�L�����y�[���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�L�����y�[���R�[�h</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CampaignCodeSt
        {
            get { return _campaignCodeSt; }
            set { _campaignCodeSt = value; }
        }

        /// public propaty name  :  CampaignCodeEd
        /// <summary>�I���L�����y�[���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���L�����y�[���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CampaignCodeEd
        {
            get { return _campaignCodeEd; }
            set { _campaignCodeEd = value; }
        }

        /// public propaty name  :  SectionCodeSt
        /// <summary>�J�n���_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeSt
        {
            get { return _sectionCodeSt; }
            set { _sectionCodeSt = value; }
        }

        /// public propaty name  :  SectionCodeEd
        /// <summary>�I�����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SectionCodeEd
        {
            get { return _sectionCodeEd; }
            set { _sectionCodeEd = value; }
        }

        /// public propaty name  :  SubSectionCodeSt
        /// <summary>�J�n���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCodeSt
        {
            get { return _goodsMakerCodeSt; }
            set { _goodsMakerCodeSt = value; }
        }

        /// public propaty name  :  GoodsMakerCodeEd
        /// <summary>�I�����i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCodeEd
        {
            get { return _goodsMakerCodeEd; }
            set { _goodsMakerCodeEd = value; }
        }

        /// public propaty name  :  SubSectionCodeSt
        /// <summary>�J�n�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCodeSt
        {
            get { return _bLGroupCodeSt; }
            set { _bLGroupCodeSt = value; }
        }

        /// public propaty name  :  GoodsMakerCodeEd
        /// <summary>�I���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGroupCodeEd
        {
            get { return _bLGroupCodeEd; }
            set { _bLGroupCodeEd = value; }
        }

        /// public propaty name  :  BLGoodsCodeSt
        /// <summary>�J�n�a�k�R�[�h�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�a�k�R�[�h�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeSt
        {
            get { return _bLGoodsCodeSt; }
            set { _bLGoodsCodeSt = value; }
        }

        /// public propaty name  :  BLGoodsCodeEd
        /// <summary>�I���a�k�R�[�h�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���a�k�R�[�h�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeEd
        {
            get { return _bLGoodsCodeEd; }
            set { _bLGoodsCodeEd = value; }
        }

        /// public propaty name  :  GoodsNoSt
        /// <summary>�J�n�i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoSt
        {
            get { return _goodsNoSt; }
            set { _goodsNoSt = value; }
        }

        /// public propaty name  :  GoodsNoEd
        /// <summary>�I���i�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���i�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoEd
        {
            get { return _goodsNoEd; }
            set { _goodsNoEd = value; }
        }

        /// public propaty name  :  SalesCodeSt
        /// <summary>�J�n�̔��敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�̔��敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCodeSt
        {
            get { return _salesCodeSt; }
            set { _salesCodeSt = value; }
        }

        /// public propaty name  :  SalesCodeEd
        /// <summary>�I���̔��敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���̔��敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesCodeEd
        {
            get { return _salesCodeEd; }
            set { _salesCodeEd = value; }
        }

        /// public propaty name  :  RateVal
        /// <summary>�������v���p�e�B</summary>
        /// <value>0:�I�[�v�����i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double RateVal
        {
            get { return _rateVal; }
            set { _rateVal = value; }
        }

        /// public propaty name  :  RateValDiv
        /// <summary>�������w��敪�v���p�e�B</summary>
        /// <value>0:���� 1:�ȏ� 2:�ȉ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������w��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RateValDiv
        {
            get { return _rateValDiv; }
            set { _rateValDiv = value; }
        }

        /// public propaty name  :  PriceFl
        /// <summary>�����z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double PriceFl
        {
            get { return _priceFl; }
            set { _priceFl = value; }
        }

        /// public propaty name  :  PriceFlDiv
        /// <summary>�����z�w��敪�v���p�e�B</summary>
        /// <value>0:���� 1:�ȏ� 2:�ȉ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����z�w��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PriceFlDiv
        {
            get { return _priceFlDiv; }
            set { _priceFlDiv = value; }
        }

        /// public propaty name  :  PriceFl
        /// <summary>�l�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double DiscountRate
        {
            get { return _discountRate; }
            set { _discountRate = value; }
        }

        /// public propaty name  :  PriceFlDiv
        /// <summary>�l�����w��敪�v���p�e�B</summary>
        /// <value>0:���� 1:�ȏ� 2:�ȉ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �l�����w��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DiscountRateDiv
        {
            get { return _discountRateDiv; }
            set { _discountRateDiv = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�폜�w��敪�v���p�e�B</summary>
        /// <value>0:�L��,1:�_���폜</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �폜�w��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  DeleteDateTimeSt
        /// <summary>�J�n�폜���t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�폜���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeleteDateTimeSt
        {
            get { return _deleteDateTimeSt; }
            set { _deleteDateTimeSt = value; }
        }

        /// public propaty name  :  DeleteDateTimeEd
        /// <summary>�I���폜���t�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���폜���t�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DeleteDateTimeEd
        {
            get { return _deleteDateTimeEd; }
            set { _deleteDateTimeEd = value; }
        }
        # endregion �� public propaty ��

        # region �� Constructor ��
        /// <summary>
        /// �L�����y�[���}�X�^�i����j�f�[�^�N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CampaignMasterPrintWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CampaignMasterPrintWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CampaignMasterPrintWork()
        {
        }
        # endregion �� Constructor ��
    }
}
