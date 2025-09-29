//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d��������ѕ\
// �v���O�����T�v   : �d��������ѕ\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/05/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{

    /// <summary>
    /// �d��������ѕ\���o�����f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note             :   �d��������ѕ\���o�����f�[�^�N���X�̃C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer       :   ���痈</br>
    /// <br>Date             :   2009.05.13</br>
    /// </remarks>
    public class StockSalesResultInfoMainCndtn
    {

        #region �� Public Const
        /// <summary>���� ���t�t�H�[�}�b�g yyyyMMdd </summary>
        public const string ct_DateFomat = "yyyyMMdd";
        /// <summary>���� ���t�t�H�[�}�b�g yyyy/MM/dd</summary>
        public const string ct_DateFomatWithLine = "yyyy/MM/dd";
        #endregion

        #region �� Private Member
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>���_�I�v�V���������敪</summary>
        private bool _isOptSection;

        /// <summary>�{�Ћ@�\�v���p�e�B</summary>
        private bool _isMainOfficeFunc;

        /// <summary>�I���v�㋒�_�R�[�h</summary>
        private string[] _collectAddupSecCodeList;


        /// <summary>���͓�(�J�n)</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private Int32 _stInputDay;

        /// <summary>���͓�(�I��)</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private Int32 _edInputDay;

        /// <summary>�d����(�J�n)</summary>
        private Int32 _stStockDate;

        /// <summary>�d����(�I��)</summary>
        private Int32 _edStockDate;

        /// <summary>����</summary>
        /// <remarks>0:����(�����Ȃ�),1:����,2:�ė����c9:9������</remarks>
        private Int32 _newPageType;

        /// <summary>���Ŗ���</summary>
        /// <remarks>0:����(�����Ȃ�),1:����,2:�ė����c9:9������</remarks>
        private string _newPageTypeName;

        /// <summary>�o�͎w��</summary>
        /// <remarks>�x����(���Z��)�R�[�h�B�x�������͎x����P�ʂŏW�v�E�v�Z�B</remarks>
        private Int32 _wayToOrderType;

        /// <summary>�o�͎w�薼��</summary>
        /// <remarks>�o�͎w�薼��</remarks>
        private string _wayToOrderTypeName;

        /// <summary>�݌Ɏ��w��</summary>
        private Int32 _stockOrderDivCdType;

        /// <summary>�݌Ɏ��w�薼��</summary>
        private string _stockOrderDivCdTypeName;

        /// <summary>����`�[�w��</summary>
        private Int32 _salesType;

        /// <summary>����`�[�w�薼��</summary>
        private string _salesTypeName;

        /// <summary>�����w��</summary>
        private Int32 _stockUnitChngDivType;

        /// <summary>�����w�薼��</summary>
        private string _stockUnitChngDivTypeName;

        /// <summary>�d����R�[�h(�J�n)</summary>
        private Int32 _stSupplierCd;

        /// <summary>�d����R�[�h(�I��)</summary>
        private Int32 _edSupplierCd;

        /// <summary>�e���`�F�b�N����</summary>
        /// <remarks>�e���`�F�b�N�̉����l�i���œ��́j�@XX.X���@�ȏ�</remarks>
        private Double _grsProfitCheckLower;

        /// <summary>�e���`�F�b�N2</summary>
        private Double _grossMarginSt;

        /// <summary>�e���`�F�b�N3</summary>
        private Double _grossMargin2Ed;

        /// <summary>�e���`�F�b�N4</summary>
        private Double _grossMargin3Ed;

        /// <summary>�e���`�F�b�N�K��</summary>
        /// <remarks>�e���`�F�b�N�̓K���l�i���œ��́j�@XX.X���@�ȏ�</remarks>
        private Double _grsProfitCheckBest;

        /// <summary>�e���`�F�b�N���</summary>
        /// <remarks>�e���`�F�b�N�̏���l�i���œ��́j�@XX.X���@�ȏ�</remarks>
        private Double _grsProfitCheckUpper;

        /// <summary>�e���`�F�b�N1(�}�[�N)</summary>
        private string _grossMargin1Mark = "";

        /// <summary>�e���`�F�b�N2(�}�[�N)</summary>
        private string _grossMargin2Mark = "";

        /// <summary>�e���`�F�b�N3(�}�[�N)</summary>
        private string _grossMargin3Mark = "";

        /// <summary>�e���`�F�b�N4(�}�[�N)</summary>
        private string _grossMargin4Mark = "";

        #endregion �� Private Member

        #region �� Public Property
        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ��ƃR�[�h�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���痈</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  IsOptSection
        /// <summary>���_�I�v�V���������敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   ���_�I�v�V���������敪�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���痈</br>
        /// </remarks>
        public bool IsOptSection
        {
            get { return _isOptSection; }
            set { _isOptSection = value; }
        }

        /// public propaty name  :  IsMainOfficeFunc
        /// <summary>�{�Ћ@�\�v���p�e�B�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �{�Ћ@�\�v���p�e�B�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���痈</br>
        /// </remarks>
        public bool IsMainOfficeFunc
        {
            get { return _isMainOfficeFunc; }
            set { _isMainOfficeFunc = value; }
        }

        /// public propaty name  :  StInputDay
        /// <summary>���͓�(�J�n)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓�(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StInputDay
        {
            get { return _stInputDay; }
            set { _stInputDay = value; }
        }

        /// public propaty name  :  EdInputDay
        /// <summary>���͓�(�I��)�v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓�(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EdInputDay
        {
            get { return _edInputDay; }
            set { _edInputDay = value; }
        }

        /// public propaty name  :  StStockDate
        /// <summary>�d����(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StStockDate
        {
            get { return _stStockDate; }
            set { _stStockDate = value; }
        }

        /// public propaty name  :  EdStockDate
        /// <summary>�d����(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EdStockDate
        {
            get { return _edStockDate; }
            set { _edStockDate = value; }
        }

        /// public propaty name  :  NewPageType
        /// <summary>���Ńv���p�e�B</summary>
        /// <value>0:����(�����Ȃ�),1:����,2:�ė����c9:9������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 NewPageType
        {
            get { return _newPageType; }
            set { _newPageType = value; }
        }


        /// public propaty name  :  NewPageTypeName
        /// <summary>���Ŗ��̃v���p�e�B</summary>
        /// <value>0:����(�����Ȃ�),1:����,2:�ė����c9:9������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ŗ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string NewPageTypeName
        {
            get { return _newPageTypeName; }
            set { _newPageTypeName = value; }
        }

        /// public propaty name  :  WayToOrderType
        /// <summary>�o�͎w��v���p�e�B</summary>
        /// <value>�x����(���Z��)�R�[�h�B�x�������͎x����P�ʂŏW�v�E�v�Z�B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͎w��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 WayToOrderType
        {
            get { return _wayToOrderType; }
            set { _wayToOrderType = value; }
        }

        /// public propaty name  :  WayToOrderTypeName
        /// <summary>�o�͎w�薼�̃v���p�e�B</summary>
        /// <value>�x����(���Z��)�R�[�h�B�x�������͎x����P�ʂŏW�v�E�v�Z�B</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͎w�薼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WayToOrderTypeName
        {
            get { return _wayToOrderTypeName; }
            set { _wayToOrderTypeName = value; }
        }

        /// public propaty name  :  StockOrderDivCdType
        /// <summary>�݌Ɏ��w��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɏ��w��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockOrderDivCdType
        {
            get { return _stockOrderDivCdType; }
            set { _stockOrderDivCdType = value; }
        }

        /// public propaty name  :  StockOrderDivCdTypeName
        /// <summary>�݌Ɏ��w�薼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɏ��w�薼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockOrderDivCdTypeName
        {
            get { return _stockOrderDivCdTypeName; }
            set { _stockOrderDivCdTypeName = value; }
        }

        /// public propaty name  :  SalesType
        /// <summary>����`�[�w��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�w��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesType
        {
            get { return _salesType; }
            set { _salesType = value; }
        }

        /// public propaty name  :  SalesTypeName
        /// <summary>����`�[�w�薼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����`�[�w�薼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SalesTypeName
        {
            get { return _salesTypeName; }
            set { _salesTypeName = value; }
        }

        /// public propaty name  :  StockUnitChngDivType
        /// <summary>�����w��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����w��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockUnitChngDivType
        {
            get { return _stockUnitChngDivType; }
            set { _stockUnitChngDivType = value; }
        }

        /// public propaty name  :  StockUnitChngDivTypeName
        /// <summary>�����w�薼�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����w�薼�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StockUnitChngDivTypeName
        {
            get { return _stockUnitChngDivTypeName; }
            set { _stockUnitChngDivTypeName = value; }
        }

        /// public propaty name  :  StSupplierCd
        /// <summary>�d����R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StSupplierCd
        {
            get { return _stSupplierCd; }
            set { _stSupplierCd = value; }
        }

        /// public propaty name  :  EdSupplierCd
        /// <summary>�d����R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 EdSupplierCd
        {
            get { return _edSupplierCd; }
            set { _edSupplierCd = value; }
        }

        /// public propaty name  :  GrsProfitCheckLower
        /// <summary>�e���`�F�b�N�����v���p�e�B</summary>
        /// <value>�e���`�F�b�N�̉����l�i���œ��́j�@XX.X���@�ȏ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���`�F�b�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double GrsProfitCheckLower
        {
            get { return _grsProfitCheckLower; }
            set { _grsProfitCheckLower = value; }
        }

        /// public propaty name  :  GrsProfitCheckLower
        /// <summary>�e���`�F�b�N2�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���`�F�b�N2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public double GrossMarginSt
        {
            get { return _grossMarginSt; }
            set { _grossMarginSt = value; }
        }

        /// public propaty name  :  GrsProfitCheckLower
        /// <summary>�e���`�F�b�N3�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���`�F�b�N3�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public double GrossMargin2Ed
        {
            get { return _grossMargin2Ed; }
            set { _grossMargin2Ed = value; }
        }

        /// public propaty name  :  GrsProfitCheckLower
        /// <summary>�e���`�F�b�N4�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���`�F�b�N4�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public double GrossMargin3Ed
        {
            get { return _grossMargin3Ed; }
            set { _grossMargin3Ed = value; }
        }

        /// public propaty name  :  GrsProfitCheckBest
        /// <summary>�e���`�F�b�N�K���v���p�e�B</summary>
        /// <value>�e���`�F�b�N�̓K���l�i���œ��́j�@XX.X���@�ȏ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���`�F�b�N�K���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double GrsProfitCheckBest
        {
            get { return _grsProfitCheckBest; }
            set { _grsProfitCheckBest = value; }
        }

        /// public propaty name  :  GrsProfitCheckUpper
        /// <summary>�e���`�F�b�N����v���p�e�B</summary>
        /// <value>�e���`�F�b�N�̏���l�i���œ��́j�@XX.X���@�ȏ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���`�F�b�N����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double GrsProfitCheckUpper
        {
            get { return _grsProfitCheckUpper; }
            set { _grsProfitCheckUpper = value; }
        }

        /// public propaty name  :  GrossMargin1Mark
        /// <summary>�e���`�F�b�N1(�}�[�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���`�F�b�N1(�}�[�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GrossMargin1Mark
        {
            get { return _grossMargin1Mark; }
            set { _grossMargin1Mark = value; }
        }

        /// public propaty name  :  GrossMargin2Mark
        /// <summary>�e���`�F�b�N2(�}�[�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���`�F�b�N2(�}�[�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GrossMargin2Mark
        {
            get { return _grossMargin2Mark; }
            set { _grossMargin2Mark = value; }
        }

        /// public propaty name  :  GrossMargin3Mark
        /// <summary>�e���`�F�b�N3(�}�[�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���`�F�b�N3(�}�[�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GrossMargin3Mark
        {
            get { return _grossMargin3Mark; }
            set { _grossMargin3Mark = value; }
        }

        /// public propaty name  :  GrossMargin4Mark
        /// <summary>�e���`�F�b�N4(�}�[�N)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �e���`�F�b�N4(�}�[�N)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GrossMargin4Mark
        {
            get { return _grossMargin4Mark; }
            set { _grossMargin4Mark = value; }
        }

        /// public propaty name  :  IsSelectAllSection
        /// <summary>�S�БI���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �S�БI���v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���痈</br>
        /// </remarks>
        public bool IsSelectAllSection
        {
            get
            {
                bool isSelAlSec = false;
                if ((this._collectAddupSecCodeList.Length == 1) && (this._collectAddupSecCodeList[0].CompareTo("0") == 0))
                {
                    isSelAlSec = true;
                }
                return isSelAlSec;
            }
        }

        /// public propaty name  :  CollectAddupSecCodeList
        /// <summary>�I���v�㋒�_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>Note             :   �I���v�㋒�_�R�[�h�v���p�e�B���s���܂��B</br>
        /// <br>Programer        :   ���痈</br>
        /// </remarks>
        public string[] CollectAddupSecCodeList
        {
            get { return _collectAddupSecCodeList; }
            set { _collectAddupSecCodeList = value; }
        }


        #endregion �� Public Property


        #region �� Constructor
        /// <summary>
        /// ���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>PaymentMainCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PaymentMainCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ���痈</br>
        /// </remarks>
        public StockSalesResultInfoMainCndtn()
        {
            this._collectAddupSecCodeList = new string[0];	// �v�㋒�_�R�[�h���X�g 
        }
        #endregion �� Constructor

    }
}
