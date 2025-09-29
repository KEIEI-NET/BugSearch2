//****************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ��R�[�h�ύX���ێ��f�[�^�N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//========================================================================================//
// ����
//----------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/03/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ���ʕύX���ێ��f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̒S���҃}�X�^�R�[�h�ϊ���ʕύX���ێ��f�[�^�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/10</br>
    /// </remarks>
    public class EmployeeConvertData
    {
        #region -- Member --

        /// <summary>�ϊ��O�S���҃R�[�h</summary>
        private string bfEmployeeCd = String.Empty;
        /// <summary>�ϊ���S���҃R�[�h</summary>
        private string afEmployeeCd = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>�ύX�O�S���҃R�[�h</summary>
        public string BfEmployeeCd
        {
            get { return this.bfEmployeeCd; }
            set { this.bfEmployeeCd = value; }
        }

        /// <summary>�ύX��S���҃R�[�h</summary>
        public string AfEmployeeCd
        {
            get { return this.afEmployeeCd; }
            set { this.afEmployeeCd = value; }
        }

        #endregion
    }
}
