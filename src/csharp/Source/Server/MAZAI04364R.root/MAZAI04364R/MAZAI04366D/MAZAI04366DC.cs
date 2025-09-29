using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   InventInputUpdateCndtnWork
    /// <summary>
    ///                      �I���ߕs���X�V�������[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �I���ߕs���X�V�������[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2015/08/21  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class InventInputUpdateCndtnWork
    {
        /// <summary>�I���^�p�敪</summary>
        private Int32 _inventoryMngDiv;
        /// <summary>�[�������敪</summary>
        private Int32 _fractionProcCd;
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode;
        /// <summary>�]�ƈ��R�[�h</summary>
        private string _employeeCode;
        /// <summary>�]�ƈ�����</summary>
        private string _employeeName;
        /// <summary>�I�ԍX�V�敪</summary>
        private int _shelfNoDiv;

        /// public propaty name  :  InventoryMngDiv
        /// <summary>�I���^�p�敪</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 InventoryMngDiv
        {
            get { return _inventoryMngDiv; }
            set { _inventoryMngDiv = value; }
        }

        /// public propaty name  :  FractionProcCd
        /// <summary>�[�������敪</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �[�������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 FractionProcCd
        {
            get { return _fractionProcCd; }
            set { _fractionProcCd = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>��ƃR�[�h</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>���_�R�[�h</summary>
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
        /// public propaty name  :  EmployeeCode
        /// <summary>�]�ƈ��R�[�h</summary>
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
        /// public propaty name  :  Name
        /// <summary>�]�ƈ�����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EmployeeName
        {
            get { return _employeeName; }
            set { _employeeName = value; }
        }

        /// public propaty name  :  ShelfNoDiv
        /// <summary>�I�ԍX�V�敪</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�ԍX�V�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public int ShelfNoDiv
        {
            get { return _shelfNoDiv; }
            set { _shelfNoDiv = value; }
        }

        /// <summary>
        /// �I���ߕs���X�V�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>InventInputUpdateCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   InventInputUpdateCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public InventInputUpdateCndtnWork()
        {
        }

    }
}
