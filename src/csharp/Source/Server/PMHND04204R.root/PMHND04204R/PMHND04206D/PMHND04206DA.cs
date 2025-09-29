//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�Ɖ�������[�N
// �v���O�����T�v   : ���i�Ɖ�������[�N�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : ���O
// �� �� ��  2017/07/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : 3H ������                               
// �C �� ��  2017/09/07  �C�����e : ���i�Ɖ�̕ύX�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;

using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   HandyInspectParamWork
    /// <summary>
    ///                      ���i�Ɖ�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�Ɖ�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2017/07/20</br>
    /// <br>Genarated Date   :   2017/07/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2017/09/07 3H ������</br>
    /// <br>�@�@�@�@�@       :   ���i�Ɖ�̕ύX�Ή�</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyInspectParamWork
    {
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode = "";

        /// <summary>���敪</summary>
        /// <remarks>�܂�/�܂܂Ȃ�</remarks>
        private Int32 _orderDivCd;

        /// <summary>�����</summary>
        /// <remarks>�o�Ɍ��i/���Ɍ��i/������/���i�̂�</remarks>
        private Int32 _pattern;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>���i�ԍ�</summary>
        private string _goodsNo = "";

        /// <summary>�q�ɃR�[�h</summary>
        /// <remarks>�݌ɊǗ��Ȃ���"0"</remarks>
        private string _warehouseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>������t(�J�n)</summary>
        /// <remarks>�����/�o�ד�</remarks>
        private DateTime _st_SalesDate;

        /// <summary>������t(�I��)</summary>
        /// <remarks>�����/�o�ד�</remarks>
        private DateTime _ed_SalesDate;

        /// <summary>���i��(�J�n)</summary>
        private DateTime _st_InspectDate;

        /// <summary>���i��(�I��)</summary>
        private DateTime _ed_InspectDate;

        /// <summary>�����t�B�[���h</summary>
        private string _searchStr = "";

        /// <summary>�]�ƈ��R�[�h</summary>
        /// <remarks>���i�]�ƈ�</remarks>
        private string _employeeCode = "";

        /// <summary>�i�Ԍ����^�C�v</summary>
        /// <remarks>0:���S��v,1:�O����v����,2:�����v����,3:�B������</remarks>
        private Int32 _goodsNoSrchTyp;

        /// <summary>����Ώ�_����</summary>
        /// <remarks>0�F�I�𖳂��A1�F�I��L��</remarks>
        private Int32 _transSales;

        /// <summary>����Ώ�_�ݏo</summary>
        /// <remarks>0�F�I�𖳂��A1�F�I��L��</remarks>
        private Int32 _transLend;

        // --- ADD 3H ������ 2017/09/07---------->>>>>
        /// <summary>�ϑ���q�ɃR�[�h</summary>        
        private string _afWarehouseCd = "";     

        /// <summary>����Ώ�_�ړ��o��</summary>
        /// <remarks>0�F�I�𖳂��A1�F�I��L��</remarks>
        private Int32 _transMoveOutWarehouse;

        /// <summary>����Ώ�_��[�o��</summary>
        /// <remarks>0�F�I�𖳂��A1�F�I��L��</remarks>
        private Int32 _transReplenishOutWarehouse;

        /// <summary>����Ώ�_�݌Ɏd��</summary>
        /// <remarks>0�F�I�𖳂��A1�F�I��L��</remarks>
        private Int32 _transStockStockSlip;

        /// <summary>����Ώ�_�d��</summary>
        /// <remarks>0�F�I�𖳂��A1�F�I��L��</remarks>
        private Int32 _transStockSlip;

        /// <summary>����Ώ�_�ړ�����</summary>
        /// <remarks>0�F�I�𖳂��A1�F�I��L��</remarks>
        private Int32 _transMoveInWarehouse;
        // --- ADD 3H ������ 2017/09/07----------<<<<<

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
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

        /// public propaty name  :  OrderDivCd
        /// <summary>���敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OrderDivCd
        {
            get { return _orderDivCd; }
            set { _orderDivCd = value; }
        }

        /// public propaty name  :  Pattern
        /// <summary>����݃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����݃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Pattern
        {
            get { return _pattern; }
            set { _pattern = value; }
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

        /// public propaty name  :  WarehouseCode
        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        /// <value>�݌ɊǗ��Ȃ���"0"</value>
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

        /// public propaty name  :  St_SalesDate
        /// <summary>������t(�J�n)�v���p�e�B</summary>
        /// <value>�󒍓�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_SalesDate
        {
            get { return _st_SalesDate; }
            set { _st_SalesDate = value; }
        }

        /// public propaty name  :  Ed_SalesDate
        /// <summary>������t(�I��)�v���p�e�B</summary>
        /// <value>�󒍓�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ������t(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_SalesDate
        {
            get { return _ed_SalesDate; }
            set { _ed_SalesDate = value; }
        }

        /// public propaty name  :  St_InspectDate
        /// <summary>���i��(�J�n)�v���p�e�B</summary>
        /// <value>���i��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i��(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime St_InspectDate
        {
            get { return _st_InspectDate; }
            set { _st_InspectDate = value; }
        }

        /// public propaty name  :  Ed_InspectDate
        /// <summary>���i��(�I��)�v���p�e�B</summary>
        /// <value>���i��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���t(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime Ed_InspectDate
        {
            get { return _ed_InspectDate; }
            set { _ed_InspectDate = value; }
        }

        /// public propaty name  :  SearchStr
        /// <summary>�����t�B�[���h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����t�B�[���h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string SearchStr
        {
            get { return _searchStr; }
            set { _searchStr = value; }
        }

        /// public propaty name  :  EmployeeCode
        /// <summary>�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���i�]�ƈ�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        // public propaty name  :  GoodsNoSrchTyp
        /// <summary>�i�Ԍ����^�C�v�v���p�e�B</summary>
        /// <value>0:���S��v,1:�O����v����,2:�����v����,3:�B������</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i�Ԍ����^�C�v�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsNoSrchTyp
        {
            get { return _goodsNoSrchTyp; }
            set { _goodsNoSrchTyp = value; }
        }

        // public propaty name  :  TransSales
        /// <summary>����Ώ�_����v���p�e�B</summary>
        /// <value>0�F�I�𖳂��A1�F�I��L��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Ώ�_����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TransSales
        {
            get { return _transSales; }
            set { _transSales = value; }
        }

        // public propaty name  :  TransLend
        /// <summary>����Ώ�_�ݏo�v���p�e�B</summary>
        /// <value>0�F�I�𖳂��A1�F�I��L��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Ώ�_�ݏo�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TransLend
        {
            get { return _transLend; }
            set { _transLend = value; }
        }

        // --- ADD 3H ������ 2017/09/07---------->>>>>
        /// public propaty name  :  Mainmngwarehousecd
        /// <summary>�ϑ���q�ɃR�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ϑ���q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfWarehouseCd
        {
            get { return _afWarehouseCd; }
            set { _afWarehouseCd = value; }
        }

        /// public propaty name  :  TransMoveOutWarehouse
        /// <summary>����Ώ�_�ړ��o�Ƀv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Ώ�_�ړ��o�Ƀv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TransMoveOutWarehouse
        {
            get { return _transMoveOutWarehouse; }
            set { _transMoveOutWarehouse = value; }
        }

        /// public propaty name  :  TransReplenishOutWarehouse
        /// <summary>����Ώ�_��[�o�Ƀv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Ώ�_��[�o�Ƀv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TransReplenishOutWarehouse
        {
            get { return _transReplenishOutWarehouse; }
            set { _transReplenishOutWarehouse = value; }
        }

        /// public propaty name  :  TransStockStockSlip
        /// <summary>����Ώ�_�݌Ɏd���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Ώ�_�݌Ɏd���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TransStockStockSlip
        {
            get { return _transStockStockSlip; }
            set { _transStockStockSlip = value; }
        }

        /// public propaty name  :  TransStockSlip
        /// <summary>����Ώ�_�d���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Ώ�_�d���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TransStockSlip
        {
            get { return _transStockSlip; }
            set { _transStockSlip = value; }
        }

        /// public propaty name  :  TransMoveInWarehouse
        /// <summary>����Ώ�_�ړ����Ƀv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Ώ�_�ړ����Ƀv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TransMoveInWarehouse
        {
            get { return _transMoveInWarehouse; }
            set { _transMoveInWarehouse = value; }
        }
        // --- ADD 3H ������ 2017/09/07----------<<<<<

        /// <summary>
        /// ���i�Ɖ�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>HandyInspectParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyInspectParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public HandyInspectParamWork()
        {
        }

    }
}
