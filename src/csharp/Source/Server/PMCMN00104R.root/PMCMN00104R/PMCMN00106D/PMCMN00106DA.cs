using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TtlDayCalcParaWork
    /// <summary>
    ///                      �����Z�o���o�������[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����Z�o���o�������[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/25</br>
    /// <br>Genarated Date   :   2008/07/28  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TtlDayCalcParaWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�����敪</summary>
        /// <remarks>-1�F���ׂā@�O�F�������| �P�F�x�����|</remarks>
        private Int32 _procDiv;

        /// <summary>�}�X�^�����擾�敪</summary>
        /// <remarks>0:�}�X�^�擾���Ȃ��@1:�����Ƀ}�X�^���擾����</remarks>
        private Int32 _withMasterDiv;

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode = "";

        /// <summary>���Ӑ�R�[�h</summary>
        private Int32 _customerCode;

        /// <summary>�d����R�[�h</summary>
        private Int32 _supplierCd;

        /// <summary>�J�n�N����</summary>
        /// <remarks>"YYYYMMDD"</remarks>
        private Int32 _st_Date;

        /// <summary>�I���N����</summary>
        /// <remarks>"YYYYMMDD"</remarks>
        private Int32 _ed_Date;


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

        /// public propaty name  :  ProcDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>�O�F���ׂā@�P�F�������| �Q�F�x�����|</value>
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

        /// public propaty name  :  WithMasterDiv
        /// <summary>�}�X�^�����擾�敪�v���p�e�B</summary>
        /// <value>0:�}�X�^�擾���Ȃ��@1:�����Ƀ}�X�^���擾����</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �}�X�^�����擾�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 WithMasterDiv
        {
            get { return _withMasterDiv; }
            set { _withMasterDiv = value; }
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

        /// public propaty name  :  St_Date
        /// <summary>�J�n�N�����v���p�e�B</summary>
        /// <value>"YYYYMMDD"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_Date
        {
            get { return _st_Date; }
            set { _st_Date = value; }
        }

        /// public propaty name  :  Ed_Date
        /// <summary>�I���N�����v���p�e�B</summary>
        /// <value>"YYYYMMDD"</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���N�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_Date
        {
            get { return _ed_Date; }
            set { _ed_Date = value; }
        }


        /// <summary>
        /// �����Z�o���o�������[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>TtlDayCalcParaWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TtlDayCalcParaWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TtlDayCalcParaWork()
        {
        }

    }
}

