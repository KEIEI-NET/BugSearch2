//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����_�ݒ菈��
// �v���O�����T�v   : �����_�ݒ菈�����o�����N���X���[�N
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/04/28  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   ExtrInfo_StockMasterTblWork
    /// <summary>
    ///                      �����_�ݒ菈�����o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����_�ݒ菈�����o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/12/25  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class ExtrInfo_OrderPointStSimulationWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�ݒ�R�[�h</summary>
        private Int32 _settingCode;

        /// <summary>�J�n�q�ɃR�[�h</summary>
        private string _st_WarehouseCode = "";

        /// <summary>�I���q�ɃR�[�h</summary>
        private string _ed_WarehouseCode = "";

        /// <summary>�J�n�d����R�[�h</summary>
        private Int32 _st_SupplierCd;

        /// <summary>�I���d����R�[�h</summary>
        private Int32 _ed_SupplierCd;

        /// <summary>�J�n���[�J�[�R�[�h</summary>
        private Int32 _st_GoodsMakerCd;

        /// <summary>�I�����[�J�[�R�[�h</summary>
        private Int32 _ed_GoodsMakerCd;

        /// <summary>�J�n���i������</summary>
        private Int32 _st_GoodsMGroup;

        /// <summary>�I�����i������</summary>
        private Int32 _ed_GoodsMGroup;

        /// <summary>�J�n�O���[�v�R�[�h</summary>
        private Int32 _st_BLGroupCode;

        /// <summary>�I���O���[�v�R�[�h</summary>
        private Int32 _ed_BLGroupCode;

        /// <summary>�J�nBL���i�R�[�h</summary>
        private Int32 _st_BLGoodsCode;

        /// <summary>�I��BL���i�R�[�h</summary>
        private Int32 _ed_BLGoodsCode;

        /// <summary>�W�v���@</summary>
        private Int32 _sumMethod;

        /// <summary>�o�͏�</summary>
        private Int32 _outPutDiv;

        /// <summary>�݌ɏo�בΏۊJ�n��</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _stckShipMonthSt;

        /// <summary>�݌ɏo�בΏۏI����</summary>
        /// <remarks>YYYYMMDD</remarks>
        private Int32 _stckShipMonthEd;

        /// <summary>�Ǘ��敪�P</summary>
        private string[] _managementDivide1;

        /// <summary>�Ǘ��敪�Q</summary>
        private string[] _managementDivide2;

        /// <summary>�����K�p�敪</summary>
        private Int32 _orderApplyDiv;

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

        /// public propaty name  :  St_WarehouseCode
        /// <summary>�J�n�q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_WarehouseCode
        {
            get { return _st_WarehouseCode; }
            set { _st_WarehouseCode = value; }
        }

        /// public propaty name  :  Ed_WarehouseCode
        /// <summary>�I���q�ɃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���q�ɃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_WarehouseCode
        {
            get { return _ed_WarehouseCode; }
            set { _ed_WarehouseCode = value; }
        }

        /// public propaty name  :  SettingCode
        /// <summary>�ݒ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ݒ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SettingCode
        {
            get { return _settingCode; }
            set { _settingCode = value; }
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
        /// <summary>�J�n���[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_GoodsMakerCd
        {
            get { return _st_GoodsMakerCd; }
            set { _st_GoodsMakerCd = value; }
        }

        /// public propaty name  :  Ed_GoodsMakerCd
        /// <summary>�I�����[�J�[�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����[�J�[�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_GoodsMakerCd
        {
            get { return _ed_GoodsMakerCd; }
            set { _ed_GoodsMakerCd = value; }
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

        /// public propaty name  :  St_GoodsMGroup
        /// <summary>�J�n���i�����ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���i�����ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_GoodsMGroup
        {
            get { return _st_GoodsMGroup; }
            set { _st_GoodsMGroup = value; }
        }

        /// public propaty name  :  Ed_GoodsMGroup
        /// <summary>�I�����i�����ރv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����i�����ރv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_GoodsMGroup
        {
            get { return _ed_GoodsMGroup; }
            set { _ed_GoodsMGroup = value; }
        }

        /// public propaty name  :  St_BLGroupCode
        /// <summary>�J�n�O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_BLGroupCode
        {
            get { return _st_BLGroupCode; }
            set { _st_BLGroupCode = value; }
        }

        /// public propaty name  :  Ed_BLGroupCode
        /// <summary>�I���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_BLGroupCode
        {
            get { return _ed_BLGroupCode; }
            set { _ed_BLGroupCode = value; }
        }

        /// public propaty name  :  SumMethod
        /// <summary>�W�v���@</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SumMethod
        {
            get { return _sumMethod; }
            set { _sumMethod = value; }
        }

        /// public propaty name  :  OutPutDiv
        /// <summary>�o�͏�</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OutPutDiv
        {
            get { return _outPutDiv; }
            set { _outPutDiv = value; }
        }

        /// public propaty name  :  StckShipMonthSt
        /// <summary>�݌ɏo�בΏۊJ�n���v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏo�בΏۊJ�n���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StckShipMonthSt
        {
            get { return _stckShipMonthSt; }
            set { _stckShipMonthSt = value; }
        }

        /// public propaty name  :  StckShipMonthEd
        /// <summary>�݌ɏo�בΏۏI�����v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �݌ɏo�בΏۏI�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StckShipMonthEd
        {
            get { return _stckShipMonthEd; }
            set { _stckShipMonthEd = value; }
        }

        /// public propaty name  :  ManagementDivide1
        /// <summary>�Ǘ��敪�P</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ��敪�P�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] ManagementDivide1
        {
            get { return _managementDivide1; }
            set { _managementDivide1 = value; }
        }

        /// public propaty name  :  ManagementDivide2
        /// <summary>�Ǘ��敪�Q</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ��敪�Q�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] ManagementDivide2
        {
            get { return _managementDivide2; }
            set { _managementDivide2 = value; }
        }

        /// public propaty name  :  FractionProcCd
        /// <summary>�����K�p�敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����K�p�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 OrderApplyDiv
        {
            get { return _orderApplyDiv; }
            set { _orderApplyDiv = value; }
        }

        /// <summary>
        /// �����_�ݒ菈�����o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>ExtrInfo_StockMasterTblWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ExtrInfo_StockMasterTblWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ExtrInfo_OrderPointStSimulationWork()
        {
        }

    }
}
