//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �^���ʏo�׎��ѕ\
// �v���O�����T�v   : �^���ʏo�׎��ѕ\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhshh
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   ModelShipRsltListCndtn
    /// <summary>
    ///                      �^���ʏo�׎��ѕ\���o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �^���ʏo�׎��ѕ\���o�����N���X�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2010/04/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class ModelShipRsltListCndtn
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�I�����_�R�[�h</summary>
        private string[] _sectionCodeList;

        /// <summary>�W�v���@</summary>
        /// <remarks>0:�S�� 1:���_��</remarks>
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

        /// <summary>����</summary>
        /// <remarks>0:���Ȃ� 1:���_ 2:�^��</remarks>
        private NewPageDivState _newPageDiv;

        /// <summary>�Ԏ탁�[�J�[�R�[�h�i�J�n�j</summary>
        private Int32 _carMakerCodeSt;

        /// <summary>�Ԏ탁�[�J�[�R�[�h�i�I���j</summary>
        private Int32 _carMakerCodeEd;

        /// <summary>�Ԏ�R�[�h�i�J�n�j</summary>
        private Int32 _carModelCodeSt;

        /// <summary>�Ԏ�R�[�h�i�I���j</summary>
        private Int32 _carModelCodeEd;

        /// <summary>�Ԏ�T�u�R�[�h�i�J�n�j</summary>
        private Int32 _carModelSubCodeSt;

        /// <summary>�Ԏ�T�u�R�[�h�i�I���j</summary>
        private Int32 _carModelSubCodeEd;

        /// <summary>��\�^��</summary>
        private string _modelName;

        /// <summary>��\�^�����o�敪</summary>
        /// <remarks>0:�ƈ�v 1:�Ŏn�܂� 2:���܂� 3:�ŏI��� </remarks>
        private ModelOutDivState _modelOutDiv;

        /// <summary>���[�J�[�J�n</summary>
        private Int32 _makerCodeSt;

        /// <summary>���[�J�[�I��</summary>
        private Int32 _makerCodeEd;

        /// <summary>�J�nBL���i�R�[�h</summary>
        private Int32 _bLGoodsCodeSt;

        /// <summary>�I��BL���i�R�[�h</summary>
        private Int32 _bLGoodsCodeEd;

        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode;

        /// <summary>�q�ɖ�</summary>
        private string _warehouseName;
        
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

        /// public propaty name  :  CarMakerCodeSt
        /// <summary>�Ԏ탁�[�J�[�R�[�h�i�J�n�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ탁�[�J�[�R�[�h�i�J�n�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarMakerCodeSt
        {
            get { return _carMakerCodeSt; }
            set { _carMakerCodeSt = value; }
        }

        /// public propaty name  :  CarMakerCodeEd
        /// <summary>�Ԏ탁�[�J�[�R�[�h�i�I���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ탁�[�J�[�R�[�h�i�I���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarMakerCodeEd
        {
            get { return _carMakerCodeEd; }
            set { _carMakerCodeEd = value; }
        }

        /// public propaty name  :  CarModelCodeSt
        /// <summary>�Ԏ�R�[�h�i�J�n�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�R�[�h�i�J�n�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarModelCodeSt
        {
            get { return _carModelCodeSt; }
            set { _carModelCodeSt = value; }
        }

        /// public propaty name  :  CarModelCodeEd
        /// <summary>�Ԏ�R�[�h�i�I���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�R�[�h�i�I���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarModelCodeEd
        {
            get { return _carModelCodeEd; }
            set { _carModelCodeEd = value; }
        }

        /// public propaty name  :  CarModelSubCodeSt
        /// <summary>�Ԏ�T�u�R�[�h�i�J�n�j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�T�u�R�[�h�i�J�n�j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarModelSubCodeSt
        {
            get { return _carModelSubCodeSt; }
            set { _carModelSubCodeSt = value; }
        }

        /// public propaty name  :  CarModelSubCodeEd
        /// <summary>�Ԏ�T�u�R�[�h�i�I���j�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԏ�T�u�R�[�h�i�I���j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CarModelSubCodeEd
        {
            get { return _carModelSubCodeEd; }
            set { _carModelSubCodeEd = value; }
        }

        /// public propaty name  :  ModelName
        /// <summary>��\�^���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��\�^���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string ModelName
        {
            get { return _modelName; }
            set { _modelName = value; }
        }

        /// public propaty name  :  MakerCodeSt
        /// <summary>���[�J�[�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerCodeSt
        {
            get { return _makerCodeSt; }
            set { _makerCodeSt = value; }
        }

        /// public propaty name  :  MakerCodeEd
        /// <summary>���[�J�[�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MakerCodeEd
        {
            get { return _makerCodeEd; }
            set { _makerCodeEd = value; }
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

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɖ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɖ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseName
        {
            get { return _warehouseName; }
            set { _warehouseName = value; }
        }

        /// public propaty name  :  CarOutDiv
        /// <summary>��\�^�����o�敪�v���p�e�B</summary>
        /// <value>0:�ƈ�v 1:�Ŏn�܂� 2:���܂� 3:�ŏI���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��\�^�����o�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ModelOutDivState ModelOutDiv
        {
            get { return _modelOutDiv; }
            set { _modelOutDiv = value; }
        }

        /// <summary>
        /// �W�v���@�@�񋓌^
        /// </summary>
        public enum GroupBySectionDivState
        {
            /// <summary>�S��</summary>
            ByAllCompany = 0,
            /// <summary>���_��</summary>
            BySection = 1,
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
        /// ���Ł@�񋓌^
        /// </summary>
        public enum NewPageDivState
        {
            /// <summary>���Ȃ�</summary>
            No = 0,
            /// <summary>���_</summary>
            Section = 1,
            /// <summary>�^��</summary>
            Model = 2,
        }

        /// <summary>
        /// ��\�^�����o�敪�@�񋓌^
        /// </summary>
        public enum ModelOutDivState
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
                    case GroupBySectionDivState.ByAllCompany:
                        return ct_groupBySectionDivState_ByAllCompany;
                    case GroupBySectionDivState.BySection:
                        return ct_groupBySectionDivState_BySection;
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
                    case NewPageDivState.Section:
                        return ct_comm_Section;
                    case NewPageDivState.Model:
                        return ct_comm_Model;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// ��\�^�����o�敪�@���̎擾
        /// </summary>
        public string ModelOutDivName
        {
            get
            {
                switch (this._modelOutDiv)
                {
                    case ModelOutDivState.Same:
                        return ct_modelOutDivState_Same;
                    case ModelOutDivState.First:
                        return ct_modelOutDivState_First;
                    case ModelOutDivState.Middle:
                        return ct_modelOutDivState_Middle;
                    case ModelOutDivState.Last:
                        return ct_modelOutDivState_Last;
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>line number</summary>
        public const int ct_Line_Num = 25;
        /// <summary>�W�v���@�@�S��</summary>
        public const string ct_groupBySectionDivState_ByAllCompany = "�S��";
        /// <summary>�W�v���@�@���_��</summary>
        public const string ct_groupBySectionDivState_BySection = "���_��";
        /// <summary>�݌Ɏ��w��敪�@���v</summary>
        public const string ct_rsltTtlDivState_Sum = "�S��";
        /// <summary>�݌Ɏ��w��敪�@�݌�</summary>
        public const string ct_rsltTtlDivState_Stock = "�݌�";
        /// <summary>�݌Ɏ��w��敪�@���</summary>
        public const string ct_rsltTtlDivState_Order = "���";
        /// <summary>��\�^�����o�敪�@�ƈ�v </summary>
        public const string ct_modelOutDivState_Same = "�ƈ�v";
        /// <summary>��\�^�����o�敪�@�Ŏn�܂� </summary>
        public const string ct_modelOutDivState_First = "�Ŏn�܂�";
        /// <summary>��\�^�����o�敪�@���܂� </summary>
        public const string ct_modelOutDivState_Middle = "���܂�";
        /// <summary>��\�^�����o�敪�@�ŏI���</summary>
        public const string ct_modelOutDivState_Last = "�ŏI���";
        /// <summary>���Ȃ�</summary>
        public const string ct_comm_No = "���Ȃ�";
        /// <summary>���_</summary>
        public const string ct_comm_Section = "���_";
        /// <summary>�^��</summary>
        public const string ct_comm_Model = "�^��";

        # region �� Constructor ��
        /// <summary>
        /// ������ѕ\���o�����N���X�R���X�g���N�^
        /// </summary>
        /// <returns>SalesRsltListCndtn�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SalesRsltListCndtn�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ModelShipRsltListCndtn()
        {
        }
        # endregion �� Constructor ��
    }
}
