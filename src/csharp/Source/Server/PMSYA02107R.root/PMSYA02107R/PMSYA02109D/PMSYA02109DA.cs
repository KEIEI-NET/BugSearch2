//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Ԍ��ԗ��ꗗ�\���o�����N���X���[�N
// �v���O�����T�v   : �����Ԍ��ԗ��ꗗ�\���o�����N���X���[�N�w�b�_�t�@�C��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �L�Q
// �� �� ��  2010/04/21  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   MonthCarInspectListParaWork
    /// <summary>
    ///                      �����Ԍ��ԗ��ꗗ�\���o�����N���X���[�N���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �����Ԍ��ԗ��ꗗ�\���o�����N���X���[�N���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2010/04/21</br>
    /// <br>Genarated Date   :   2010/04/21  (CSharp File Generated Date)</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class MonthCarInspectListParaWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>�J�n���Ӑ�R�[�h</summary>
        private string _stCustomerCode;

        /// <summary>�I�����Ӑ�R�[�h</summary>
        private string _edCustomerCode;

        /// <summary>�Ǘ����_�R�[�h</summary>
        /// <remarks>�����^�@���z�񍀖�</remarks>
        private string[] _mngSectionCode;

        /// <summary>�J�n���q�Ǘ��R�[�h</summary>
        private string _stCarMngCode;

        /// <summary>�I�����q�Ǘ��R�[�h</summary>
        private string _edCarMngCode;

        /// <summary>�Ԍ�������</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _inspectMaturityDate;


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

        /// public propaty name  :  StCustomerCode
        /// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StCustomerCode
        {
            get { return _stCustomerCode; }
            set { _stCustomerCode = value; }
        }

        /// public propaty name  :  EdCustomerCode
        /// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdCustomerCode
        {
            get { return _edCustomerCode; }
            set { _edCustomerCode = value; }
        }

        /// public propaty name  :  MngSectionCode
        /// <summary>�Ǘ����_�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ǘ����_�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }

        /// public propaty name  :  StCarMngCode
        /// <summary>�J�n���q�Ǘ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���q�Ǘ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string StCarMngCode
        {
            get { return _stCarMngCode; }
            set { _stCarMngCode = value; }
        }

        /// public propaty name  :  EdCarMngCode
        /// <summary>�I�����q�Ǘ��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����q�Ǘ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EdCarMngCode
        {
            get { return _edCarMngCode; }
            set { _edCarMngCode = value; }
        }

        /// public propaty name  :  InspectMaturityDate
        /// <summary>�Ԍ��������v���p�e�B</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �Ԍ��������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime InspectMaturityDate
        {
            get { return _inspectMaturityDate; }
            set { _inspectMaturityDate = value; }
        }


        /// <summary>
        /// �����Ԍ��ԗ��ꗗ�\���o�����N���X���[�N���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>MonthCarInspectListParaWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MonthCarInspectListParaWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MonthCarInspectListParaWork()
        {
        }

    }
}
