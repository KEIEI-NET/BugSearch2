//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���Ӑ�}�X�^�i�^�M�ݒ�j�f�[�^�p�����[�^
//                  :   PMKHN09267D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2008.10.14
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   CustCreditCndtnWork
    /// <summary>
    ///                      ���Ӑ�(�^�M�ݒ�)���o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���Ӑ�(�^�M�ݒ�)���o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/10/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class CustCreditCndtnWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>���Ӑ�R�[�h�i�����w��j</summary>
        /// <remarks>�i�z��jnull�̏ꍇ�A�J�n�I���Ŕ���</remarks>
        private Int32[] _customerCodes;

        /// <summary>�J�n���Ӑ�R�[�h</summary>
        private Int32 _st_CustomerCode;

        /// <summary>�I�����Ӑ�R�[�h</summary>
        private Int32 _ed_CustomerCode;

        /// <summary>����</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>�����敪</summary>
        /// <remarks>0:���ݔ��|�c���ݒ�,1:�^�M�z�N���A</remarks>
        private Int32 _procDiv;

        /// <summary>�^�M�z�t���O</summary>
        /// <remarks>True�ŏ���</remarks>
        private Boolean _creditMoneyFlg;

        /// <summary>�x���^�M�z�t���O</summary>
        /// <remarks>True�ŏ���</remarks>
        private Boolean _warningCrdMnyFrg;

        /// <summary>���ݔ��|�c���t���O</summary>
        /// <remarks>True�ŏ���</remarks>
        private Boolean _accRecDiv;


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

        /// public propaty name  :  CustomerCodes
        /// <summary>���Ӑ�R�[�h�i�����w��j�v���p�e�B</summary>
        /// <value>�i�z��jnull�̏ꍇ�A�J�n�I���Ŕ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ӑ�R�[�h�i�����w��j�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32[] CustomerCodes
        {
            get { return _customerCodes; }
            set { _customerCodes = value; }
        }

        /// public propaty name  :  St_CustomerCode
        /// <summary>�J�n���Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n���Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 St_CustomerCode
        {
            get { return _st_CustomerCode; }
            set { _st_CustomerCode = value; }
        }

        /// public propaty name  :  Ed_CustomerCode
        /// <summary>�I�����Ӑ�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I�����Ӑ�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 Ed_CustomerCode
        {
            get { return _ed_CustomerCode; }
            set { _ed_CustomerCode = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>�����v���p�e�B</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  ProcDiv
        /// <summary>�����敪�v���p�e�B</summary>
        /// <value>0:���ݔ��|�c���ݒ�,1:�^�M�z�N���A</value>
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

        /// public propaty name  :  CreditMoneyFlg
        /// <summary>�^�M�z�t���O�v���p�e�B</summary>
        /// <value>True�ŏ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �^�M�z�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean CreditMoneyFlg
        {
            get { return _creditMoneyFlg; }
            set { _creditMoneyFlg = value; }
        }

        /// public propaty name  :  WarningCrdMnyFrg
        /// <summary>�x���^�M�z�t���O�v���p�e�B</summary>
        /// <value>True�ŏ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �x���^�M�z�t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean WarningCrdMnyFrg
        {
            get { return _warningCrdMnyFrg; }
            set { _warningCrdMnyFrg = value; }
        }

        /// public propaty name  :  AccRecDiv
        /// <summary>���ݔ��|�c���t���O�v���p�e�B</summary>
        /// <value>True�ŏ���</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ݔ��|�c���t���O�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Boolean AccRecDiv
        {
            get { return _accRecDiv; }
            set { _accRecDiv = value; }
        }


        /// <summary>
        /// ���Ӑ�(�^�M�ݒ�)���o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>CustCreditCndtnWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   CustCreditCndtnWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public CustCreditCndtnWork()
        {
        }

    }
}
