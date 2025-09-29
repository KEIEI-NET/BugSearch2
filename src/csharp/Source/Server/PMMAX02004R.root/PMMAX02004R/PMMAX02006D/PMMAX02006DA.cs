//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���iMAX���ח\��
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11270001-00  �쐬�S�� : ���O
// �� �� ��  2016/01/21   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   PartsMaxStockArrivalCondt
    /// <summary>
    ///                      ���iMAX���ח\�񒊏o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���iMAX���ח\�񒊏o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2016/01/21</br>
    /// <br>Genarated Date   :   2016/01/21  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class PartsMaxStockArrivalCondt
    {
        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�o�ɋ��_�R�[�h</summary>
        private string _bfSectionCode = "";

        /// <summary>���ɋ��_�R�[�h</summary>
        private string _afSectionCode = "";

        /// <summary>�o�ɋ��_����</summary>
        private string _bfSectionName = "";

        /// <summary>���ɋ��_����</summary>
        private string _afSectionName = "";

        /// <summary>�o�ד��t(�J�n)</summary>
        private DateTime _shipDateSt;

        /// <summary>�o�ד��t(�I��)</summary>
        private DateTime _shipDateEd;

        /// <summary>�o�ɑq�ɃR�[�h���X�g</summary>
        private string[] _bfWarehouseCodeList;

        /// <summary>���ɑq�ɃR�[�h���X�g</summary>
        private string[] _afWarehouseCodeList;

        /// <summary>������</summary>
        private Int32 _salesOrderCount;

        /// <summary>�����������l</summary>
        private Int32 _salesRate;

        /// <summary>�̔��P�������l</summary>
        private Int64 _salesPrice;

        /// <summary>�`�F�b�N���X�g�o�͑I��</summary>
        private Int32 _moveChecked;

        /// <summary>��Ɩ���</summary>
        private string _enterpriseName = "";

        /// <summary>����Size</summary>
        private Int32 _dataSize;


        /// public propaty name  :  CustomerCode
        /// <summary>���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
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

        /// public propaty name  :  BfSectionCode
        /// <summary>�o�ɋ��_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ɋ��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfSectionCode
        {
            get { return _bfSectionCode; }
            set { _bfSectionCode = value; }
        }

        /// public propaty name  :  AfSectionCode
        /// <summary>���ɋ��_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɋ��_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfSectionCode
        {
            get { return _afSectionCode; }
            set { _afSectionCode = value; }
        }

        /// public propaty name  :  BfSectionName
        /// <summary>�o�ɋ��_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ɋ��_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BfSectionName
        {
            get { return _bfSectionName; }
            set { _bfSectionName = value; }
        }

        /// public propaty name  :  AfSectionName
        /// <summary>���ɋ��_���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɋ��_���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string AfSectionName
        {
            get { return _afSectionName; }
            set { _afSectionName = value; }
        }

        /// public propaty name  :  ShipDateSt
        /// <summary>�o�ד��t(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ShipDateSt
        {
            get { return _shipDateSt; }
            set { _shipDateSt = value; }
        }

        /// public propaty name  :  ShipDateEd
        /// <summary>�o�ד��t(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ד��t(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime ShipDateEd
        {
            get { return _shipDateEd; }
            set { _shipDateEd = value; }
        }

        /// public propaty name  :  BfWarehouseCodeList
        /// <summary>�o�ɑq�ɃR�[�h���X�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�ɑq�ɃR�[�h���X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] BfWarehouseCodeList
        {
            get { return _bfWarehouseCodeList; }
            set { _bfWarehouseCodeList = value; }
        }

        /// public propaty name  :  AfWarehouseCodeList
        /// <summary>���ɑq�ɃR�[�h���X�g�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ɑq�ɃR�[�h���X�g�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] AfWarehouseCodeList
        {
            get { return _afWarehouseCodeList; }
            set { _afWarehouseCodeList = value; }
        }

        /// public propaty name  :  SalesOrderCount
        /// <summary>�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesOrderCount
        {
            get { return _salesOrderCount; }
            set { _salesOrderCount = value; }
        }

        /// public propaty name  :  SalesRate
        /// <summary>�����������l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����������l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SalesRate
        {
            get { return _salesRate; }
            set { _salesRate = value; }
        }

        /// public propaty name  :  SalesPrice
        /// <summary>�̔��P�������l�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �̔��P�������l�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 SalesPrice
        {
            get { return _salesPrice; }
            set { _salesPrice = value; }
        }

        /// public propaty name  :  MoveChecked
        /// <summary>�`�F�b�N���X�g�o�͑I���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�F�b�N���X�g�o�͑I���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MoveChecked
        {
            get { return _moveChecked; }
            set { _moveChecked = value; }
        }

        /// public propaty name  :  EnterpriseName
        /// <summary>��Ɩ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��Ɩ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseName
        {
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
        }

        /// public propaty name  :  DataSize
        /// <summary>����Index�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����Index�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DataSize
        {
            get { return _dataSize; }
            set { _dataSize = value; }
        }


        /// <summary>
        /// ���iMAX�o�ח\�蒊�o�����R���X�g���N�^
        /// </summary>
        /// <returns>PartsMaxStockArrivalCondt�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   PartsMaxStockArrivalCondt�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public PartsMaxStockArrivalCondt()
        {
        }
    }
}