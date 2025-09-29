using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockTransListCndtnWork
    /// <summary>
    ///                      �d�����ڕ\���o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d�����ڕ\���o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/30  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockTransListCndtnWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�ʏW�v�敪</summary>
        /// <remarks>0:�S�ЏW�v�^1:���_�ʏW�v</remarks>
        private Int32 _groupBySectionDiv;

        /// <summary>���[�W�v�敪</summary>
        /// <remarks>�i�\�����ځj0:���i�ʁ^1:�d����ʁ^2:�S���ҕ�</remarks>
        private Int32 _printSelectDiv;

        /// <summary>�v�㋒�_�R�[�h�i�����w��j</summary>
        /// <remarks>�i���z��j</remarks>
        private string[] _addUpSecCodes;

        /// <summary>�J�n������</summary>
        /// <remarks>YYYYMM�@�����v�@�Z�o�͈͊J�n</remarks>
        private Int32 _st_ThisYearMonth;

        /// <summary>�I��������</summary>
        /// <remarks>YYYYMM�@�����v�@�Z�o�͈͏I��</remarks>
        private Int32 _ed_ThisYearMonth;

        /// <summary>�W�v�P��</summary>
        /// <remarks>0:���i�R�[�h  1:BL�R�[�h  2:���Е��ރR�[�h  3:���i�敪�ڍ׃R�[�h  4:�ڍ׋敪�R�[�h  5:���i�敪�O���[�v�R�[�h  6:���[�J�[�R�[�h</remarks>
        private Int32 _summaryUnit;

        /// <summary>�݌Ɏ��敪</summary>
        /// <remarks>0:���v 1:�݌� 2:���</remarks>
        private Int32 _stockOrderDiv;

        /// <summary>�J�n����R�[�h</summary>
        private Int32 _st_SubSectionCode;

        /// <summary>�I������R�[�h</summary>
        private Int32 _ed_SubSectionCode;

        /// <summary>�J�n�ۃR�[�h</summary>
        private Int32 _st_MinSectionCode;

        /// <summary>�I���ۃR�[�h</summary>
        private Int32 _ed_MinSectionCode;

        /// <summary>�J�n�]�ƈ��R�[�h</summary>
        private string _st_EmployeeCode = "";

        /// <summary>�I���]�ƈ��R�[�h</summary>
        private string _ed_EmployeeCode = "";

        /// <summary>�J�n�d����R�[�h</summary>
        private Int32 _st_SupplierCd;

        /// <summary>�I���d����R�[�h</summary>
        private Int32 _ed_SupplierCd;

        /// <summary>�J�n���i���[�J�[�R�[�h</summary>
        private Int32 _st_GoodsMakerCd;

        /// <summary>�I�����i���[�J�[�R�[�h</summary>
        private Int32 _ed_GoodsMakerCd;

        /// <summary>�J�n���i�ԍ�</summary>
        private string _st_GoodsNo = "";

        /// <summary>�I�����i�ԍ�</summary>
        private string _ed_GoodsNo = "";

        /// <summary>�J�nBL���i�R�[�h</summary>
        private Int32 _st_BLGoodsCode;

        /// <summary>�I��BL���i�R�[�h</summary>
        private Int32 _ed_BLGoodsCode;

        /// <summary>�J�n���i�敪�O���[�v�R�[�h</summary>
        private string _st_LargeGoodsGanreCode = "";

        /// <summary>�I�����i�敪�O���[�v�R�[�h</summary>
        private string _ed_LargeGoodsGanreCode = "";

        /// <summary>�J�n���i�敪�R�[�h</summary>
        private string _st_MediumGoodsGanreCode = "";

        /// <summary>�I�����i�敪�R�[�h</summary>
        private string _ed_MediumGoodsGanreCode = "";

        /// <summary>�J�n���i�敪�ڍ׃R�[�h</summary>
        private string _st_DetailGoodsGanreCode = "";

        /// <summary>�I�����i�敪�ڍ׃R�[�h</summary>
        private string _ed_DetailGoodsGanreCode = "";

        /// <summary>�J�n���Е��ރR�[�h</summary>
        /// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _st_EnterpriseGanreCode;

        /// <summary>�I�����Е��ރR�[�h</summary>
        /// <remarks>1�`899:�񋟕�, 900�`���[�U�[�o�^</remarks>
        private Int32 _ed_EnterpriseGanreCode;

        /// <summary>�J�n�o�א�</summary>
        private Double _st_TotalStockCount;

        /// <summary>�I���o�א�</summary>
        private Double _ed_TotalStockCount;


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

        /// public propaty name  :  GroupBySectionDiv
        /// <summary>���_�ʏW�v�敪�v���p�e�B</summary>
        /// <value>0:�S�ЏW�v�^1:���_�ʏW�v</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�ʏW�v�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GroupBySectionDiv
        {
            get { return _groupBySectionDiv; }
            set { _groupBySectionDiv = value; }
        }

        /// public propaty name  :  PrintSelectDiv
        /// <summary>���[�W�v�敪�v���p�e�B</summary>
        /// <value>�i�\�����ځj0:���i�ʁ^1:�d����ʁ^2:�S���ҕ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�W�v�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 PrintSelectDiv
        {
            get { return _printSelectDiv; }
            set { _printSelectDiv = value; }
        }

        /// public propaty name  :  AddUpSecCodes
        /// <summary>�v�㋒�_�R�[�h�i�����w��j�v���p�e�B</summary>
        /// <value>�i���z��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �v�㋒�_�R�[�h�i�����w��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] AddUpSecCodes
        {
            get { return _addUpSecCodes; }
            set { _addUpSecCodes = value; }
        }

        /// public propaty name  :  St_ThisYearMonth
        /// <summary>�J�n�������v���p�e�B</summary>
        /// <value>YYYYMM�@�����v�@�Z�o�͈͊J�n</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_ThisYearMonth
        {
            get { return _st_ThisYearMonth; }
            set { _st_ThisYearMonth = value; }
        }

        /// public propaty name  :  Ed_ThisYearMonth
        /// <summary>�I���������v���p�e�B</summary>
        /// <value>YYYYMM�@�����v�@�Z�o�͈͏I��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_ThisYearMonth
        {
            get { return _ed_ThisYearMonth; }
            set { _ed_ThisYearMonth = value; }
        }

        /// public propaty name  :  SummaryUnit
        /// <summary>�W�v�P�ʃv���p�e�B</summary>
        /// <value>0:���i�R�[�h  1:BL�R�[�h  2:���Е��ރR�[�h  3:���i�敪�ڍ׃R�[�h  4:�ڍ׋敪�R�[�h  5:���i�敪�O���[�v�R�[�h  6:���[�J�[�R�[�h</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �W�v�P�ʃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SummaryUnit
        {
            get { return _summaryUnit; }
            set { _summaryUnit = value; }
        }

        /// public propaty name  :  StockOrderDiv
        /// <summary>�݌Ɏ��敪�v���p�e�B</summary>
        /// <value>0:���v 1:�݌� 2:���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌Ɏ��敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockOrderDiv
        {
            get { return _stockOrderDiv; }
            set { _stockOrderDiv = value; }
        }

        /// public propaty name  :  St_SubSectionCode
        /// <summary>�J�n����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_SubSectionCode
        {
            get { return _st_SubSectionCode; }
            set { _st_SubSectionCode = value; }
        }

        /// public propaty name  :  Ed_SubSectionCode
        /// <summary>�I������R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I������R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_SubSectionCode
        {
            get { return _ed_SubSectionCode; }
            set { _ed_SubSectionCode = value; }
        }

        /// public propaty name  :  St_MinSectionCode
        /// <summary>�J�n�ۃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�ۃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_MinSectionCode
        {
            get { return _st_MinSectionCode; }
            set { _st_MinSectionCode = value; }
        }

        /// public propaty name  :  Ed_MinSectionCode
        /// <summary>�I���ۃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���ۃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_MinSectionCode
        {
            get { return _ed_MinSectionCode; }
            set { _ed_MinSectionCode = value; }
        }

        /// public propaty name  :  St_EmployeeCode
        /// <summary>�J�n�]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_EmployeeCode
        {
            get { return _st_EmployeeCode; }
            set { _st_EmployeeCode = value; }
        }

        /// public propaty name  :  Ed_EmployeeCode
        /// <summary>�I���]�ƈ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_EmployeeCode
        {
            get { return _ed_EmployeeCode; }
            set { _ed_EmployeeCode = value; }
        }

        /// public propaty name  :  St_SupplierCd
        /// <summary>�J�n�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_SupplierCd
        {
            get { return _st_SupplierCd; }
            set { _st_SupplierCd = value; }
        }

        /// public propaty name  :  Ed_SupplierCd
        /// <summary>�I���d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_SupplierCd
        {
            get { return _ed_SupplierCd; }
            set { _ed_SupplierCd = value; }
        }

        /// public propaty name  :  St_GoodsMakerCd
        /// <summary>�J�n���i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_GoodsMakerCd
        {
            get { return _st_GoodsMakerCd; }
            set { _st_GoodsMakerCd = value; }
        }

        /// public propaty name  :  Ed_GoodsMakerCd
        /// <summary>�I�����i���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_GoodsMakerCd
        {
            get { return _ed_GoodsMakerCd; }
            set { _ed_GoodsMakerCd = value; }
        }

        /// public propaty name  :  St_GoodsNo
        /// <summary>�J�n���i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_GoodsNo
        {
            get { return _st_GoodsNo; }
            set { _st_GoodsNo = value; }
        }

        /// public propaty name  :  Ed_GoodsNo
        /// <summary>�I�����i�ԍ��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_GoodsNo
        {
            get { return _ed_GoodsNo; }
            set { _ed_GoodsNo = value; }
        }

        /// public propaty name  :  St_BLGoodsCode
        /// <summary>�J�nBL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�nBL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_BLGoodsCode
        {
            get { return _st_BLGoodsCode; }
            set { _st_BLGoodsCode = value; }
        }

        /// public propaty name  :  Ed_BLGoodsCode
        /// <summary>�I��BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_BLGoodsCode
        {
            get { return _ed_BLGoodsCode; }
            set { _ed_BLGoodsCode = value; }
        }

        /// public propaty name  :  St_LargeGoodsGanreCode
        /// <summary>�J�n���i�敪�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�敪�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_LargeGoodsGanreCode
        {
            get { return _st_LargeGoodsGanreCode; }
            set { _st_LargeGoodsGanreCode = value; }
        }

        /// public propaty name  :  Ed_LargeGoodsGanreCode
        /// <summary>�I�����i�敪�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�敪�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_LargeGoodsGanreCode
        {
            get { return _ed_LargeGoodsGanreCode; }
            set { _ed_LargeGoodsGanreCode = value; }
        }

        /// public propaty name  :  St_MediumGoodsGanreCode
        /// <summary>�J�n���i�敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_MediumGoodsGanreCode
        {
            get { return _st_MediumGoodsGanreCode; }
            set { _st_MediumGoodsGanreCode = value; }
        }

        /// public propaty name  :  Ed_MediumGoodsGanreCode
        /// <summary>�I�����i�敪�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�敪�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_MediumGoodsGanreCode
        {
            get { return _ed_MediumGoodsGanreCode; }
            set { _ed_MediumGoodsGanreCode = value; }
        }

        /// public propaty name  :  St_DetailGoodsGanreCode
        /// <summary>�J�n���i�敪�ڍ׃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�敪�ڍ׃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_DetailGoodsGanreCode
        {
            get { return _st_DetailGoodsGanreCode; }
            set { _st_DetailGoodsGanreCode = value; }
        }

        /// public propaty name  :  Ed_DetailGoodsGanreCode
        /// <summary>�I�����i�敪�ڍ׃R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�敪�ڍ׃R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_DetailGoodsGanreCode
        {
            get { return _ed_DetailGoodsGanreCode; }
            set { _ed_DetailGoodsGanreCode = value; }
        }

        /// public propaty name  :  St_EnterpriseGanreCode
        /// <summary>�J�n���Е��ރR�[�h�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Е��ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_EnterpriseGanreCode
        {
            get { return _st_EnterpriseGanreCode; }
            set { _st_EnterpriseGanreCode = value; }
        }

        /// public propaty name  :  Ed_EnterpriseGanreCode
        /// <summary>�I�����Е��ރR�[�h�v���p�e�B</summary>
        /// <value>1�`899:�񋟕�, 900�`���[�U�[�o�^</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Е��ރR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_EnterpriseGanreCode
        {
            get { return _ed_EnterpriseGanreCode; }
            set { _ed_EnterpriseGanreCode = value; }
        }

        /// public propaty name  :  St_TotalStockCount
        /// <summary>�J�n�o�א��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double St_TotalStockCount
        {
            get { return _st_TotalStockCount; }
            set { _st_TotalStockCount = value; }
        }

        /// public propaty name  :  Ed_TotalStockCount
        /// <summary>�I���o�א��v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���o�א��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double Ed_TotalStockCount
        {
            get { return _ed_TotalStockCount; }
            set { _ed_TotalStockCount = value; }
        }


        /// <summary>
        /// �d�����ڕ\���o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockTransListCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockTransListCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockTransListCndtnWork()
        {
        }

    }
}
