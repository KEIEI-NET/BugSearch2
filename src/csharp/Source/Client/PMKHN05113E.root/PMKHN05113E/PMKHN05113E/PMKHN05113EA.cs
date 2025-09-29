//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ��f�[�^�N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/03/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ���ʃf�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̒S���҃}�X�^�R�[�h�ϊ���ʃf�[�^�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/10</br>
    /// </remarks>
    public class EmployeeSearchDispWork
    {
        #region -- Member --

        /// <summary>��ƃR�[�h</summary>
        private string enterpriseCd = String.Empty;
        /// <summary>�S���҃R�[�h(�J�n)</summary>
        private string employeeCdStart = String.Empty;
        /// <summary>�S���҃R�[�h(�I��)</summary>
        private string employeeCdEnd = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        public string EnterpriseCode
        {
            get { return this.enterpriseCd; }
            set { this.enterpriseCd = value; }
        }

        /// <summary>�S���҃R�[�h(�J�n)�v���p�e�B</summary>
        public string EmployeeCodeStart
        {
            get { return this.employeeCdStart; }
            set { this.employeeCdStart = value; }
        }

        /// <summary>�S���҃R�[�h(�I��)�v���p�e�B</summary>
        public string EmployeeCodeEnd
        {
            get { return this.employeeCdEnd; }
            set { this.employeeCdEnd = value; }
        }

        #endregion
    }
}
