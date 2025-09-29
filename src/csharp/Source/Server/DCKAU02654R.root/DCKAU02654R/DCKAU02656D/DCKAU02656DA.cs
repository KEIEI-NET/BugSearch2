using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CreditMngListCndtnWork
    /// <summary>
    ///                      �^�M�Ǘ��\���o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   �^�M�Ǘ��\���o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2007/11/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CreditMngListCndtnWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���_�R�[�h�i�����w��j</summary>
        /// <remarks>�i�z��j</remarks>
        private string[] _sectionCodes;

        /// <summary>�^�M�g�p��</summary>
        private Double _creditRate;

        /// <summary>�^�M���x�z</summary>
        private Int64 _creditMoney;

        /// <summary>�J�n�S����</summary>
        private string _st_AgentCd = "";

        /// <summary>�I���S����</summary>
        private string _ed_AgentCd = "";


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

        /// public propaty name  :  SectionCodes
        /// <summary>���_�R�[�h�i�����w��j�v���p�e�B</summary>
        /// <value>�i�z��j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���_�R�[�h�i�����w��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string[] SectionCodes
        {
            get { return _sectionCodes; }
            set { _sectionCodes = value; }
        }

        /// public propaty name  :  CreditRate
        /// <summary>�^�M�g�p���v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�M�g�p���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Double CreditRate
        {
            get { return _creditRate; }
            set { _creditRate = value; }
        }

        /// public propaty name  :  CreditMoney
        /// <summary>�^�M���x�z�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�M���x�z�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 CreditMoney
        {
            get { return _creditMoney; }
            set { _creditMoney = value; }
        }

        /// public propaty name  :  St_AgentCd
        /// <summary>�J�n�S���҃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�S���҃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string St_AgentCd
        {
            get { return _st_AgentCd; }
            set { _st_AgentCd = value; }
        }

        /// public propaty name  :  Ed_AgentCd
        /// <summary>�I���S���҃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I���S���҃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string Ed_AgentCd
        {
            get { return _ed_AgentCd; }
            set { _ed_AgentCd = value; }
        }


        /// <summary>
        /// �^�M�Ǘ��\���o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CreditMngListCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CreditMngListCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CreditMngListCndtnWork()
        {
        }

    }
}
