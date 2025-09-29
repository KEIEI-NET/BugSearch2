using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SupplierCheckOrderCndtnWork
    /// <summary>
    ///                      �d���`�F�b�N����(����)���o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �d���`�F�b�N����(����)���o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class SupplierCheckOrderCndtnWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�����敪</summary>
        /// <remarks>0:���� 1:����</remarks>
        private Int32 _procDiv;

        /// <summary>�`�[�敪</summary>
        /// <remarks>0:�S�� 1:�d�� 2:�ԕi</remarks>
        private Int32 _slipDiv;

        /// <summary>�`�F�b�N�敪</summary>
        /// <remarks>0:���`�F�b�N 1:�`�F�b�N�ς�</remarks>
        private Int32 _checkDiv;

        /// <summary>�J�n�d����</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private Int32 _st_StockDate;

        /// <summary>�I���d����</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private Int32 _ed_StockDate;

        /// <summary>�J�n���͓�</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private Int32 _st_InputDay;

        /// <summary>�I�����͓�</summary>
        /// <remarks>YYYYMMDD�@�i�X�V�N�����j</remarks>
        private Int32 _ed_InputDay;

        /// <summary>�J�n�d���`�[�ԍ�</summary>
        /// <remarks>�����`�[�ԍ��A�d���`�[�ԍ��A���ד`�[�ԍ������˂�</remarks>
        private Int32 _st_SupplierSlipNo;

        /// <summary>�I���d���`�[�ԍ�</summary>
        /// <remarks>�����`�[�ԍ��A�d���`�[�ԍ��A���ד`�[�ԍ������˂�</remarks>
        private Int32 _ed_SupplierSlipNo;

        /// <summary>�J�n�����`�[�ԍ�</summary>
        /// <remarks>�d����`�[�ԍ��Ɏg�p����</remarks>
        private string _st_PartySaleSlipNum = "";

        /// <summary>�I�������`�[�ԍ�</summary>
        /// <remarks>�d����`�[�ԍ��Ɏg�p����</remarks>
        private string _ed_PartySaleSlipNum = "";


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

        /// public propaty name  :  SupplierCd
        /// <summary>�d����R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �d����R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SupplierCd
        {
            get { return _supplierCd; }
            set { _supplierCd = value; }
        }

        /// public propaty name  :  ProcDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:���� 1:����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ProcDiv
        {
            get { return _procDiv; }
            set { _procDiv = value; }
        }

        /// public propaty name  :  SlipDiv
        /// <summary>�`�[�敪�v���p�e�B</summary>
        /// <value>0:�S�� 1:�d�� 2:�ԕi</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�[�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SlipDiv
        {
            get { return _slipDiv; }
            set { _slipDiv = value; }
        }

        /// public propaty name  :  CheckDiv
        /// <summary>�`�F�b�N�敪�v���p�e�B</summary>
        /// <value>0:���`�F�b�N 1:�`�F�b�N�ς�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �`�F�b�N�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 CheckDiv
        {
            get { return _checkDiv; }
            set { _checkDiv = value; }
        }

        /// public propaty name  :  St_StockDate
        /// <summary>�J�n�d�����v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_StockDate
        {
            get { return _st_StockDate; }
            set { _st_StockDate = value; }
        }

        /// public propaty name  :  Ed_StockDate
        /// <summary>�I���d�����v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���d�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_StockDate
        {
            get { return _ed_StockDate; }
            set { _ed_StockDate = value; }
        }

        /// public propaty name  :  St_InputDay
        /// <summary>�J�n���͓��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_InputDay
        {
            get { return _st_InputDay; }
            set { _st_InputDay = value; }
        }

        /// public propaty name  :  Ed_InputDay
        /// <summary>�I�����͓��v���p�e�B</summary>
        /// <value>YYYYMMDD�@�i�X�V�N�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����͓��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_InputDay
        {
            get { return _ed_InputDay; }
            set { _ed_InputDay = value; }
        }

        /// public propaty name  :  St_SupplierSlipNo
        /// <summary>�J�n�d���`�[�ԍ��v���p�e�B</summary>
        /// <value>�����`�[�ԍ��A�d���`�[�ԍ��A���ד`�[�ԍ������˂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_SupplierSlipNo
        {
            get { return _st_SupplierSlipNo; }
            set { _st_SupplierSlipNo = value; }
        }

        /// public propaty name  :  Ed_SupplierSlipNo
        /// <summary>�I���d���`�[�ԍ��v���p�e�B</summary>
        /// <value>�����`�[�ԍ��A�d���`�[�ԍ��A���ד`�[�ԍ������˂�</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���d���`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_SupplierSlipNo
        {
            get { return _ed_SupplierSlipNo; }
            set { _ed_SupplierSlipNo = value; }
        }

        /// public propaty name  :  St_PartySaleSlipNum
        /// <summary>�J�n�����`�[�ԍ��v���p�e�B</summary>
        /// <value>�d����`�[�ԍ��Ɏg�p����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�����`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_PartySaleSlipNum
        {
            get { return _st_PartySaleSlipNum; }
            set { _st_PartySaleSlipNum = value; }
        }

        /// public propaty name  :  Ed_PartySaleSlipNum
        /// <summary>�I�������`�[�ԍ��v���p�e�B</summary>
        /// <value>�d����`�[�ԍ��Ɏg�p����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�������`�[�ԍ��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_PartySaleSlipNum
        {
            get { return _ed_PartySaleSlipNum; }
            set { _ed_PartySaleSlipNum = value; }
        }


        /// <summary>
        /// �d���`�F�b�N����(����)���o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>SupplierCheckOrderCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   SupplierCheckOrderCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public SupplierCheckOrderCndtnWork()
        {
        }

    }
}




