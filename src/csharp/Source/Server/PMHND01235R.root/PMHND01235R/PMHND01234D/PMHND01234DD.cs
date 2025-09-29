//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ɉꊇ�폜�f�[�^�������[�N
// �v���O�����T�v   : �݌Ɉꊇ�폜�f�[�^�������[�N�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright 2020 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570249-00   �쐬�S�� : ���O
// �� �� ��  2020/03/09    �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   HandyDeleteStockCondWork
    /// <summary>
    ///                      �݌Ɉꊇ�폜�f�[�^�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌Ɉꊇ�폜�f�[�^�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2020/03/13  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class HandyDeleteStockCondWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

         /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode = "";

        /// <summary>���i���[�J�[�R�[�h</summary>
        private Int32 _goodsMakerCd;

        /// <summary>�݌ɋ敪</summary>
        /// <remarks>0:�w��Ȃ� 1:�݌ɐ���0</remarks>
        private Int32 _stockDiv;

        /// <summary>�q�ɒI��</summary>
        private string _warehouseShelfNo = "";

        /// <summary>�ŏI�����</summary>
        private Int64 _lastSalesDate;

        /// <summary>�g�p��</summary>
        /// <remarks>���[�J�[�A�o�[�R�[�h�A�����i�ԁA�o�^�i�Ԗ��̎g�p��</remarks>
        private Int32 _useCount;

        /// <summary>�������t�J�n</summary>
        private Int32 _searchDateSt;

        /// <summary>�������t�I��</summary>
        private Int32 _searchDateEd;


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

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
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

        /// public propaty name  :  StockDiv
        /// <summary>�ŏI������v���p�e�B</summary>
        /// <value>0:�w��Ȃ� 1:�݌ɐ���0</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 StockDiv
        {
            get { return _stockDiv; }
            set { _stockDiv = value; }
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

        /// public propaty name  :  WarehouseShelfNo
        /// <summary>�q�ɒI�ԃv���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q�ɒI�ԃv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNo
        {
            get { return _warehouseShelfNo; }
            set { _warehouseShelfNo = value; }
        }

        /// public propaty name  :  LastSalesDate
        /// <summary>�ŏI������v���p�e�B</summary>
        /// <value>�݌Ɍ��������s�������t</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �ŏI������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 LastSalesDate
        {
            get { return _lastSalesDate; }
            set { _lastSalesDate = value; }
        }

        /// public propaty name  :  UseCount
        /// <summary>�g�p�񐔃v���p�e�B</summary>
        /// <value>���[�J�[�A�o�[�R�[�h�A�����i�ԁA�o�^�i�Ԗ��̎g�p��</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �g�p�񐔃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 UseCount
        {
            get { return _useCount; }
            set { _useCount = value; }
        }

        /// public propaty name  :  SearchDateSt
        /// <summary>�������t�J�n�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t�J�n�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchDateSt
        {
            get { return _searchDateSt; }
            set { _searchDateSt = value; }
        }

        /// public propaty name  :  SearchDateEd
        /// <summary>�������t�I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������t�I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SearchDateEd
        {
            get { return _searchDateEd; }
            set { _searchDateEd = value; }
        }

        /// <summary>
        /// ���[�J�[�i�ԃp�^�[�������������ʃ��[�N�R���X�g���N�^
        /// </summary>
        /// <returns>HandyDeleteStockCondWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   HandyDeleteStockCondWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public HandyDeleteStockCondWork()
        {
        }

    }

}
