using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   StockProcParamWork
    /// <summary>
    ///                      �݌Ƀ}�X�^���o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �݌Ƀ}�X�^���o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class StockProcParamWork
    {
        /// <summary>�J�n����</summary>
        private Int64 _beginningDate;

        /// <summary>�I������</summary>
        private Int64 _endingDate;

        /// <summary>�q��(�J�n)</summary>
        private string _warehouseCodeBegin = "";

        /// <summary>�q��(�I��)</summary>
        private string _warehouseCodeEnd = "";

        /// <summary>�I��(�J�n)</summary>
        private string _warehouseShelfNoBegin = "";

        /// <summary>�I��(�I��)</summary>
        private string _warehouseShelfNoEnd = "";

        /// <summary>�d����(�J�n)</summary>
        private Int32 _supplierCdBegin;

        /// <summary>�d����(�I��)</summary>
        private Int32 _supplierCdEnd;

        /// <summary>���[�J�[(�J�n)</summary>
        private Int32 _goodsMakerCdBegin;

        /// <summary>���[�J�[(�I��)</summary>
        private Int32 _goodsMakerCdEnd;

        /// <summary>�O���[�v�R�[�h(�J�n)</summary>
        private Int32 _bLGloupCodeBegin;

        /// <summary>�O���[�v�R�[�h(�I��)</summary>
        private Int32 _bLGloupCodeEnd;

        /// <summary>�i��(�J�n)</summary>
        private string _goodsNoBegin = "";

        /// <summary>�i��(�I��)</summary>
        private string _goodsNoEnd = "";


        /// public propaty name  :  BeginningDate
        /// <summary>�J�n�����v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 UpdateDateTimeBegin
        {
            get { return _beginningDate; }
            set { _beginningDate = value; }
        }

        /// public propaty name  :  EndingDate
        /// <summary>�I�������v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 UpdateDateTimeEnd
        {
            get { return _endingDate; }
            set { _endingDate = value; }
        }

        /// public propaty name  :  WarehouseCodeBegin
        /// <summary>�q��(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q��(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCodeBeginRF
        {
            get { return _warehouseCodeBegin; }
            set { _warehouseCodeBegin = value; }
        }

        /// public propaty name  :  WarehouseCodeEnd
        /// <summary>�q��(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �q��(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseCodeEndRF
        {
            get { return _warehouseCodeEnd; }
            set { _warehouseCodeEnd = value; }
        }

        /// public propaty name  :  WarehouseShelfNoBegin
        /// <summary>�I��(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNoBeginRF
        {
            get { return _warehouseShelfNoBegin; }
            set { _warehouseShelfNoBegin = value; }
        }

        /// public propaty name  :  WarehouseShelfNoEnd
        /// <summary>�I��(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I��(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string WarehouseShelfNoEndRF
        {
            get { return _warehouseShelfNoEnd; }
            set { _warehouseShelfNoEnd = value; }
        }

        /// public propaty name  :  SupplierCdBegin
        /// <summary>�d����(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCdBeginRF
        {
            get { return _supplierCdBegin; }
            set { _supplierCdBegin = value; }
        }

        /// public propaty name  :  SupplierCdEnd
        /// <summary>�d����(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCdEndRF
        {
            get { return _supplierCdEnd; }
            set { _supplierCdEnd = value; }
        }

        /// public propaty name  :  GoodsMakerCdBegin
        /// <summary>���[�J�[(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdBeginRF
        {
            get { return _goodsMakerCdBegin; }
            set { _goodsMakerCdBegin = value; }
        }

        /// public propaty name  :  GoodsMakerCdEnd
        /// <summary>���[�J�[(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�J�[(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 GoodsMakerCdEndRF
        {
            get { return _goodsMakerCdEnd; }
            set { _goodsMakerCdEnd = value; }
        }

        /// public propaty name  :  BLGloupCodeBegin
        /// <summary>�O���[�v�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O���[�v�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGloupCodeBeginRF
        {
            get { return _bLGloupCodeBegin; }
            set { _bLGloupCodeBegin = value; }
        }

        /// public propaty name  :  BLGloupCodeEnd
        /// <summary>�O���[�v�R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �O���[�v�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGloupCodeEndRF
        {
            get { return _bLGloupCodeEnd; }
            set { _bLGloupCodeEnd = value; }
        }

        /// public propaty name  :  GoodsNoBegin
        /// <summary>�i��(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i��(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoBeginRF
        {
            get { return _goodsNoBegin; }
            set { _goodsNoBegin = value; }
        }

        /// public propaty name  :  GoodsNoEnd
        /// <summary>�i��(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �i��(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNoEndRF
        {
            get { return _goodsNoEnd; }
            set { _goodsNoEnd = value; }
        }


        /// <summary>
        /// �݌Ƀ}�X�^���o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>StockProcParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   StockProcParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public StockProcParamWork()
        {
        }

    }
}
