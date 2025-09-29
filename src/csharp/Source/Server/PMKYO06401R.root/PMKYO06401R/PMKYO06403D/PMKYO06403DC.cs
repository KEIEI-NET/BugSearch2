using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   GoodsProcParamWork
    /// <summary>
    ///                      ���i�}�X�^���o�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���i�}�X�^���o�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2011/08/01  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class GoodsProcParamWork
    {
        /// <summary>�J�n����</summary>
        private Int64 _beginningDate;

        /// <summary>�I������</summary>
        private Int64 _endingDate;

        /// <summary>�d����(�J�n)</summary>
        private Int32 _supplierCdBegin;

        /// <summary>�d����(�I��)</summary>
        private Int32 _supplierCdEnd;

        /// <summary>���[�J�[(�J�n)</summary>
        private Int32 _goodsMakerCdBegin;

        /// <summary>���[�J�[(�I��)</summary>
        private Int32 _goodsMakerCdEnd;

        /// <summary>BL�R�[�h(�J�n)</summary>
        private Int32 _blGoodsCodeBegin;

        /// <summary>BL�R�[�h(�I��)</summary>
        private Int32 _blGoodsCodeEnd;

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

        /// public propaty name  :  BlGoodsCodeBegin
        /// <summary>BL�R�[�h(�J�n)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h(�J�n)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeBeginRF
        {
            get { return _blGoodsCodeBegin; }
            set { _blGoodsCodeBegin = value; }
        }

        /// public propaty name  :  BlGoodsCodeEnd
        /// <summary>BL�R�[�h(�I��)�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL�R�[�h(�I��)�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCodeEndRF
        {
            get { return _blGoodsCodeEnd; }
            set { _blGoodsCodeEnd = value; }
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
        /// ���i�}�X�^���o�������[�N�R���X�g���N�^
        /// </summary>
        /// <returns>GoodsProcParamWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   GoodsProcParamWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public GoodsProcParamWork()
        {
        }

    }
}
