//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ��`���ψꗗ�\���o�����N���X���[�N
// �v���O�����T�v   : ��`���ψꗗ�\���o�����N���X���[�N�w�b�_�t�@�C��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���R
// �� �� ��  2010/05/06  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   TegataKessaiReportParaWork
    /// <summary>
    ///                      ��`���ψꗗ�\���o�����N���X���[�N
    /// </summary>
    /// <remarks>
    /// <br>note             :   ��`���ψꗗ�\���o�����N���X���[�N�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2008/3/18</br>
    /// <br>Genarated Date   :   2010/05/06  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class TegataKessaiReportParaWork
    {
        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = string.Empty;

        /// <summary>��`�敪</summary>
        /// <remarks>0:���U 1:���U�@���������U�敪</remarks>
        private Int32 _draftDivide;

        /// <summary>����͈͔N��</summary>
        /// <remarks>YYYYMM</remarks>
        private DateTime _salesDate;

        /// <summary>����</summary>
        private Int32 _changePageDiv;

        /// <summary>�J�n��s�E�x�X�R�[�h</summary>
        private string _bankAndBranchCdSt;

        /// <summary>�I����s�E�x�X�R�[�h</summary>
        private string _bankAndBranchCdEd;

        /// <summary>�J�n������</summary>
        private DateTime _depositDateSt;

        /// <summary>�I��������</summary>
        private DateTime _depositDateEd;

        /// <summary>�J�n������</summary>
        private DateTime _maturityDateSt;

        /// <summary>�I��������</summary>
        private DateTime _maturityDateEd;

        /// <summary>�o�͏�</summary>
        private Int32 _sortOrder;

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

        /// public propaty name  :  DraftDivide
        /// <summary>��`�敪�v���p�e�B</summary>
        /// <value>0:���U 1:���U�@���������U�敪</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��`�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 DraftDivide
        {
            get { return _draftDivide; }
            set { _draftDivide = value; }
        }

        /// public propaty name  :  SalesDate
        /// <summary>����͈͔N��</summary>
        /// <value>YYYYMM</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ����͈͔N���v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime SalesDate
        {
            get { return _salesDate; }
            set { _salesDate = value; }
        }

        /// public propaty name  :  ChangePageDiv
        /// <summary>����</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���Ńv���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 ChangePageDiv
        {
            get { return _changePageDiv; }
            set { _changePageDiv = value; }
        }

        /// public propaty name  :  SortOrder
        /// <summary>�o�͏�</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �o�͏��v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 SortOrder
        {
            get { return _sortOrder; }
            set { _sortOrder = value; }
        }

        /// public propaty name  :  BankAndBranchCdSt
        /// <summary>�J�n��s�E�x�X�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n��s�E�x�X�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BankAndBranchCdSt
        {
            get { return _bankAndBranchCdSt; }
            set { _bankAndBranchCdSt = value; }
        }

        /// public propaty name  :  BankAndBranchCdEd
        /// <summary>�I����s�E�x�X�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �I����s�E�x�X�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BankAndBranchCdEd
        {
            get { return _bankAndBranchCdEd; }
            set { _bankAndBranchCdEd = value; }
        }

        /// public propaty name  :  DepositDateSt
        /// <summary>�J�n������</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime DepositDateSt
        {
            get { return _depositDateSt; }
            set { _depositDateSt = value; }
        }

        /// public propaty name  :  DepositDateEd
        /// <summary>�J�n������</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime DepositDateEd
        {
            get { return _depositDateEd; }
            set { _depositDateEd = value; }
        }

        /// public propaty name  :  MaturityDateSt
        /// <summary>�J�n������</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime MaturityDateSt
        {
            get { return _maturityDateSt; }
            set { _maturityDateSt = value; }
        }

        /// public propaty name  :  MaturityDateEd
        /// <summary>�J�n������</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �J�n�������v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime MaturityDateEd
        {
            get { return _maturityDateEd; }
            set { _maturityDateEd = value; }
        }

        /// <summary>
        /// ��`���ψꗗ�\���o�����N���X���[�N�R���X�g���N�^
        /// </summary>
        /// <returns>TegataKessaiReportParaWork�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   TegataKessaiReportParaWork�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public TegataKessaiReportParaWork()
        {
        }
    }
}
