//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ��f�[�^�N���X(�S���҃R�[�h�A�S���Җ���)
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
    /// PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ���ʃf�[�^�N���X(�S���҃R�[�h�A�S���Җ���)
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̒S���҃}�X�^�R�[�h�ϊ���ʃf�[�^�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/10</br>
    /// </remarks>
    public class EmployeeDispInfo
    {
        #region -- Member --

        /// <summary>�_���폜�t���O</summary>
        private int logicalDelete = 0;
        /// <summary>�S���҃R�[�h</summary>
        private string employeeCd = String.Empty;
        /// <summary>�S���Җ�</summary>
        private string employeeNm = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>�_���폜�t���O�v���p�e�B</summary>
        public int LogicalDelete
        {
            get { return this.logicalDelete; }
            set { this.logicalDelete = value; }
        }

        /// <summary>�S���҃R�[�h�v���p�e�B</summary>
        public string EmployeeCode
        {
            get { return this.employeeCd; }
            set { this.employeeCd = value; }
        }

        /// <summary>�S���Җ��v���p�e�B</summary>
        public string EmployeeName
        {
            get { return this.employeeNm; }
            set { this.employeeNm = value; }
        }

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ���ʃf�[�^�N���X(�S���҃R�[�h�A�S���Җ���)�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS�����c�[���A�S���҃}�X�^�R�[�h�ϊ���ʃf�[�^�N���X(�S���҃R�[�h�A�S���Җ���)�̏����������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks> 
        public EmployeeDispInfo()
        {
            // �����Ȃ�
        }

        /// <summary>
        /// PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ���ʃf�[�^�]���N���X(�S���҃R�[�h�A�S���Җ���)�R���X�g���N�^
        /// </summary>
        /// <param name="code">�S���҃R�[�h</param>
        /// <param name="name">�S���Җ���</param>
        /// <param name="logicalDel">�_���폜�t���O</param>
        /// <remarks>
        /// <br>Note       : PM.NS�����c�[���A�S���҃}�X�^�R�[�h�ϊ���ʃf�[�^�]���N���X(�S���҃R�[�h�A�S���Җ���)�̏����������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>  
        public EmployeeDispInfo(string code, string name, int logicalDel)
        {
            this.EmployeeCode = code;
            this.EmployeeName = name;
            this.LogicalDelete = logicalDel;
        }

        #endregion
    }
}
