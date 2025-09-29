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
    public class EmployeeSearchParamWork
    {
        #region -- Member --

        /// <summary>��ƃR�[�h</summary>
        private string enterpriseCode = String.Empty;
        /// <summary>�S���҃R�[�h(�J�n)</summary>
        private string employeeCdSt = String.Empty;
        /// <summary>�S���҃R�[�h(�I��)</summary>
        private string employeeCdEd = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        public string EnterpriseCode
        {
            get { return this.enterpriseCode; }
            set { this.enterpriseCode = value; }
        }

        /// <summary>�S���҃R�[�h(�J�n)�v���p�e�B</summary>
        public string EmployeeCodeStart
        {
            get { return this.employeeCdSt; }
            set { this.employeeCdSt = value; }
        }

        /// <summary>�S���҃R�[�h(�I��)�v���p�e�B</summary>
        public string EmployeeCodeEnd
        {
            get { return this.employeeCdEd; }
            set { this.employeeCdEd = value; }
        }

        #endregion
    }
}
