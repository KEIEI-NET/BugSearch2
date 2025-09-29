//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(����)�N���X
// �v���O�����T�v   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// ����
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/03/10  �C�����e : �V�K�쐬
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(����)�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̒S���҃}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(����)�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/10</br>
    /// </remarks>
    [Serializable]
    [CustomSerializationData]
    public class EmployeeSearchWork
    {
        #region -- Member --

        /// <summary>�_���폜�t���O</summary>
        private int logicalDelete = 0;
        /// <summary>�S���҃R�[�h</summary>
        private string employeeCd = String.Empty;
        /// <summary>�S���Җ���</summary>
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

        /// <summary>�S���Җ��̃v���p�e�B</summary>
        public string EmployeeName
        {
            get { return this.employeeNm; }
            set { this.employeeNm = value; }
        }

        #endregion
    }
}
