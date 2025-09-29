//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�ʏo�׎��ѕ\
// �v���O�����T�v   : ���q�ʏo�׎��ѕ\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2009/09/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CarShipRsltListCndtn
    /// <summary>
    ///                      ���q�ʏo�׎��ѕ\���o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���q�ʏo�׎��ѕ\���o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2009/9/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CarShipRsltListCndtn
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�I�����_�R�[�h</summary>
        private string[] _sectionCodeList;

        /// <summary>�W�v���@</summary>
        /// <remarks>0:���ѕ\ 1:���X�g</remarks>
        private GroupBySectionDivState _groupBySectionDiv;

        /// <summary>�����(�J�n)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _salesDateSt;

        /// <summary>�����(�I��)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _salesDateEd;

        /// <summary>���͓�(�J�n)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inputDateSt;

        /// <summary>���͓�(�I��)</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inputDateEd;
        
        /// <summary>�݌Ɏ�񂹋敪</summary>
        /// <remarks>0:�S�� 1:�݌�, 2:���</remarks>
        private RsltTtlDivState _rsltTtlDiv;

        /// <summary>�i�ԏo��</summary>
        /// <remarks>0:�Ȃ� 1:����</remarks>
        private GoodsNoPrintState _goodsNoPrint;

        /// <summary>�����E�e���o��</summary>
        /// <remarks>0:�Ȃ� 1:����</remarks>
        private CostGrossPrintState _costGrossPrint;

        /// <summary>����</summary>
        /// <remarks>0:�Ȃ� 1:���q</remarks>
        private NewPageDivState _newPageDiv;

        /// <summary>���גP��</summary>
        /// <remarks>0�F�i�� 1�FBL�R�[�h 2�F�O���[�v�R�[�h </remarks>
        private DetailDataValueState _detailDataValue;

        /// <summary>�J�n���Ӑ�R�[�h</summary>
        private Int32 _customerCodeSt;

        /// <summary>�I�����Ӑ�R�[�h</summary>
        private Int32 _customerCodeEd;
   
        /// <summary>�J�n�Ǘ��ԍ��R�[�h</summary>
        private string _carMngCodeSt;

        /// <summary>�I���Ǘ��ԍ��R�[�h</summary>
        private string _carMngCodeEd;

        /// <summary>�J�nBL�O���[�v�R�[�h</summary>
        private Int32 _bLGroupCodeSt;

        /// <summary>�I��BL�O���[�v�R�[�h</summary>
        private Int32 _bLGroupCodeEd;

        /// <summary>�J�nBL���i�R�[�h</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>�I��BL���i�R�[�h</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>�J�n�i��</summary>
        private string _goodsNoSt = "";

        /// <summary>�I���i��</summary>
        private string _goodsNoEd = "";

        /// <summary>���q���l</summary>
        private string _slipNoteCar = "";

        /// <summary>���q���o�敪</summary>
        /// <remarks>0:�ƈ�v 1:�Ŏn�܂� 2:���܂� 3:�ŏI��� </remarks>
        private CarOutDivState _carOutDiv;

        /// <summary>���_�I�v�V�����敪</summary>
        private bool _isOptSection = false;

        /// <summary>�S���_�I���敪</summary>
        private bool _isSelectAllSection = false;

        /// <summary>
        /// ���_�I�v�V�����敪�v���p�e�B
        /// </summary>
        public bool IsOptSection
        {
            get { return this._isOptSection; }
            set { this._isOptSection = value; }
        }
        /// <summary>
        /// �S���_�I���敪�v���p�e�B
        /// </summary>
        public bool IsSelectAllSection
        {
            get { return this._isSelectAllSection; }
            set { this._isSelectAllSection = value; }
        }

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

        /// public propaty name  :  SectionCodeList
        /// <summary>�I�����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCodeList
        {
            get { return _sectionCodeList; }
            set { _sectionCodeList = value; }
        }

        /// public propaty name  :  GroupBySectionDiv
        /// <summary>�W�v���@�v���p�e�B</summary>
        /// <value>0:���ѕ\ 1:���X�g</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�v���@�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GroupBySectionDivState GroupBySectionDiv
        {
            get { return _groupBySectionDiv; }
            set { _groupBySectionDiv = value; }
        }

        /// public propaty name  :  SalesDateSt
        /// <summary>�����(�J�n)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDateSt
        {
            get { return _salesDateSt; }
            set { _salesDateSt = value; }
        }

        /// public propaty name  :  SalesDateEd
        /// <summary>�����(�I��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDateEd
        {
            get { return _salesDateEd; }
            set { _salesDateEd = value; }
        }

        /// public propaty name  :  InputDateSt
        /// <summary>���͓�(�J�n)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓�(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InputDateSt
        {
            get { return _inputDateSt; }
            set { _inputDateSt = value; }
        }

        /// public propaty name  :  InputDateEd
        /// <summary>���͓�(�I��)�v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���͓�(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InputDateEd
        {
            get { return _inputDateEd; }
            set { _inputDateEd = value; }
        }

        /// public propaty name  :  RsltTtlDivCd
        /// <summary>�݌Ɏ�񂹋敪�v���p�e�B</summary>
        /// <value>0:�S�� 1:�݌�, 2:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɏ�񂹋敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RsltTtlDivState RsltTtlDiv
        {
            get { return _rsltTtlDiv; }
            set { _rsltTtlDiv = value; }
        }

        /// public propaty name  :  GoodsNoPrint
        /// <summary>�i�ԏo�̓v���p�e�B</summary>
        /// <value>0:�Ȃ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�ԏo�̓v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsNoPrintState GoodsNoPrint
        {
            get { return _goodsNoPrint; }
            set { _goodsNoPrint = value; }
        }

        /// public propaty name  :  CostGrossPrint
        /// <summary>�����E�e���o�̓v���p�e�B</summary>
        /// <value>0:�Ȃ� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����E�e���o�̓v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CostGrossPrintState CostGrossPrint
        {
            get { return _costGrossPrint; }
            set { _costGrossPrint = value; }
        }

        /// public propaty name  :  NewPageDiv
        /// <summary>���Ńv���p�e�B</summary>
        /// <value>0:�Ȃ� 1:���q</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public NewPageDivState NewPageDiv
        {
            get { return _newPageDiv; }
            set { _newPageDiv = value; }
        }

        /// public propaty name  :  DetailDataValue
        /// <summary>���גP�ʃv���p�e�B</summary>
        /// <value>0�F�i�� 1�FBL�R�[�h 2�F�O���[�v�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���גP�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DetailDataValueState DetailDataValue
        {
            get { return _detailDataValue; }
            set { _detailDataValue = value; }
        }

        /// public propaty name  :  CustomerCodeSt
        /// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeSt
        {
            get { return _customerCodeSt; }
            set { _customerCodeSt = value; }
        }

        /// public propaty name  :  CustomerCodeEd
        /// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCodeEd
        {
            get { return _customerCodeEd; }
            set { _customerCodeEd = value; }
        }

        /// public propaty name  :  CarMngCodeSt
        /// <summary>�J�n�Ǘ��ԍ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�Ǘ��ԍ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarMngCodeSt
        {
            get { return _carMngCodeSt; }
            set { _carMngCodeSt = value; }
        }

        /// public propaty name  :  CarMngCodeEd
        /// <summary>�I���Ǘ��ԍ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���Ǘ��ԍ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string CarMngCodeEd
        {
            get { return _carMngCodeEd; }
            set { _carMngCodeEd = value; }
        }

        /// public propaty name  :  BLGroupCodeSt
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

        /// public propaty name  :  BLGroupCodeEd
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
        /// <summary>�J�nBL�R�[�h�v���p�e�B</summary>
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
        /// <summary>�I��BL�R�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  SlipNoteCar
        /// <summary>���q���l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q���l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SlipNoteCar
        {
            get { return _slipNoteCar; }
            set { _slipNoteCar = value; }
        }

        /// public propaty name  :  CarOutDiv
        /// <summary>���q���o�敪�v���p�e�B</summary>
        /// <value>0:�ƈ�v 1:�Ŏn�܂� 2:���܂� 3:�ŏI���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���q���o�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CarOutDivState CarOutDiv
        {
            get { return _carOutDiv; }
            set { _carOutDiv = value; }
        }

        /// <summary>
        /// �W�v���@�@�񋓌^
        /// </summary>
        public enum GroupBySectionDivState
        {
            /// <summary>���ѕ\</summary>
            ByRslt = 0,
            /// <summary>���X�g</summary>
            ByList = 1,
        }

        /// <summary>
        /// �݌Ɏ�񂹋敪�@�񋓌^
        /// </summary>
        public enum RsltTtlDivState
        {
            /// <summary>�S��</summary>
            Sum = 0,
            /// <summary>�݌�</summary>
            Stock = 1,
            /// <summary>���</summary>
            Order = 2,
        }

        /// <summary>
        /// �i�ԏo�́@�񋓌^
        /// </summary>
        public enum GoodsNoPrintState
        {
            /// <summary>�Ȃ�</summary>
            No = 0,
            /// <summary>����</summary>
            Yes = 1,
        }
        
 �@�@�@ /// <summary>
        /// �����E�e���o�́@�񋓌^
        /// </summary>
        public enum CostGrossPrintState
        {
            /// <summary>�Ȃ�</summary>
            No = 0,
            /// <summary>����</summary>
            Yes = 1,
        }

        /// <summary>
        /// ���Ł@�񋓌^
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>�Ȃ�</summary>
            No = 0,
            /// <summary>���q</summary>
            Car = 1,
        }

        /// <summary>
        /// ���גP�ʁ@�񋓌^
        /// </summary>
        public enum DetailDataValueState
        {
            /// <summary>�i��</summary>
            GoodsNo = 0,
            /// <summary>BL�R�[�h</summary>
            BLCode = 1,
            /// <summary>�O���[�v�R�[�h</summary>
            GroupCode = 2,
        }

        /// <summary>
        /// ���q���o�敪�@�񋓌^
        /// </summary>
        public enum CarOutDivState
        {
            /// <summary>�ƈ�v</summary>
            Same = 0,
            /// <summary>�Ŏn�܂�</summary>
            First = 1,
            /// <summary>���܂�</summary>
            Middle = 2,
            /// <summary>�ŏI���</summary>
            Last = 3,
        }

        /// <summary>
        /// �W�v���@�@���̎擾
        /// </summary>
        public string GroupBySectionDivName
        {
            get
            {
                switch (this._groupBySectionDiv)
                {
                    case GroupBySectionDivState.ByRslt:
                        return ct_groupBySectionDivState_ByRslt;
                    case GroupBySectionDivState.ByList:
                        return ct_groupBySectionDivState_ByList;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// �݌Ɏ��敪�@���̎擾
        /// </summary>
        public string RsltTtlDivName
        {
            get
            {
                switch (this._rsltTtlDiv)
                {
                    case RsltTtlDivState.Sum:
                        return ct_rsltTtlDivState_Sum;
                    case RsltTtlDivState.Stock:
                        return ct_rsltTtlDivState_Stock;
                    case RsltTtlDivState.Order:
                        return ct_rsltTtlDivState_Order;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// �i�ԏo�́@���̎擾
        /// </summary>
        public string GoodsNoPrintName
        {
            get
            {
                switch (this._goodsNoPrint)
                {
                    case GoodsNoPrintState.No:
                        return ct_comm_No;
                    case GoodsNoPrintState.Yes:
                        return ct_comm_Yes;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// �����E�e���o�́@���̎擾
        /// </summary>
        public string CostGrossPrintName
        {
            get
            {
                switch (this._costGrossPrint)
                {
                    case CostGrossPrintState.No:
                        return ct_comm_No;
                    case CostGrossPrintState.Yes:
                        return ct_comm_Yes;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// ���Ł@���̎擾
        /// </summary>
        public string NewPageDivName
        {
            get
            {
                switch (this._newPageDiv)
                {
                    case NewPageDivState.No:
                        return ct_comm_No;
                    case NewPageDivState.Car:
                        return ct_comm_Car;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// ���q���o�敪�@���̎擾
        /// </summary>
        public string CarOutDivName
        {
            get
            {
                switch (this._carOutDiv)
                {
                    case CarOutDivState.Same:
                        return ct_carOutDivState_Same;
                    case CarOutDivState.First:
                        return ct_carOutDivState_First;
                    case CarOutDivState.Middle:
                        return ct_carOutDivState_Middle;
                    case CarOutDivState.Last:
                        return ct_carOutDivState_Last;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// ���גP�ʁ@���̎擾
        /// </summary>
        public string DetailDataValueName
        {
            get
            {
                switch (this._detailDataValue)
                {
                    case DetailDataValueState.GoodsNo:
                        return ct_detailDataValue_GoodsNo;
                    case DetailDataValueState.BLCode:
                        return ct_detailDataValue_BLCode;
                    case DetailDataValueState.GroupCode:
                        return ct_detailDataValue_GroupCode;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>line number</summary>
        public const int ct_Line_Num = 25;
        /// <summary>�W�v���@�@���ѕ\</summary>
        public const string ct_groupBySectionDivState_ByRslt = "���ѕ\";
        /// <summary>�W�v���@�@���X�g</summary>
        public const string ct_groupBySectionDivState_ByList = "���X�g";
        /// <summary>�݌Ɏ��w��敪�@���v</summary>
        public const string ct_rsltTtlDivState_Sum = "�S��";
        /// <summary>�݌Ɏ��w��敪�@�݌�</summary>
        public const string ct_rsltTtlDivState_Stock = "�݌�";
        /// <summary>�݌Ɏ��w��敪�@���</summary>
        public const string ct_rsltTtlDivState_Order = "���";
        /// <summary>���q���o�敪�@�ƈ�v </summary>
        public const string ct_carOutDivState_Same = "�ƈ�v";
        /// <summary>���q���o�敪�@�Ŏn�܂� </summary>
        public const string ct_carOutDivState_First = "�Ŏn�܂�";
        /// <summary>���q���o�敪�@���܂� </summary>
        public const string ct_carOutDivState_Middle = "���܂�";
        /// <summary>���q���o�敪�@�ŏI���</summary>
        public const string ct_carOutDivState_Last = "�ŏI���";
        /// <summary>�Ȃ�</summary>
        public const string ct_comm_No = "�Ȃ�";
        /// <summary>����</summary>
        public const string ct_comm_Yes = "����";
        /// <summary>���q</summary>
        public const string ct_comm_Car = "���q";
        /// <summary>���גP�� �i��</summary>
        public const string ct_detailDataValue_GoodsNo = "�i��";
        /// <summary>���גP�� BL�R�[�h</summary>
        public const string ct_detailDataValue_BLCode = "BL�R�[�h";
        /// <summary>���גP�� �O���[�v�R�[�h</summary>
        public const string ct_detailDataValue_GroupCode = "�O���[�v�R�[�h";


        # region �� Constructor ��
        /// <summary>
        /// ������ѕ\���o�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>SalesRsltListCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesRsltListCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CarShipRsltListCndtn()
        {
        }
        # endregion �� Constructor ��
    }
}
