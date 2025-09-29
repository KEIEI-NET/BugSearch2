//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(���s)�N���X
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
    /// PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(���s)�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̒S���҃}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(���s)�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/10</br>
    /// </remarks>
    [Serializable]
    [CustomSerializationData]
    public class EmployeeConvertParamWork
    {
        #region -- Member --

        /// <summary>�ύX�O�S���҃R�[�h</summary>
        private string bfEmployeeCd = String.Empty;
        /// <summary>�ύX��S���҃R�[�h</summary>
        private string afEmployeeCd = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>�ύX�O�S���҃R�[�h�v���p�e�B</summary>
        public string BfEmployeeCode
        {
            get { return this.bfEmployeeCd; }
            set { this.bfEmployeeCd = value; }
        }

        /// <summary>�ύX��S���҃R�[�h�v���p�e�B</summary>
        public string AfEmployeeCode
        {
            get { return this.afEmployeeCd; }
            set { this.afEmployeeCd = value; }
        }

        #endregion
    }
}
