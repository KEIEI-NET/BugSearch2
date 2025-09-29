//****************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ��R�[�h�ύX���ێ��f�[�^�N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//========================================================================================//
// ����
//----------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/03/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ���ʕύX���ێ��f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̓��Ӑ�}�X�^�R�[�h�ϊ���ʕύX���ێ��f�[�^�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/23</br>
    /// </remarks>
    public class CustomerConvertData
    {
        #region -- Member --

        /// <summary>�ϊ��O���Ӑ�R�[�h</summary>
        private int bfCustomerCd = 0;
        /// <summary>�ϊ��㓾�Ӑ�R�[�h</summary>
        private int afCustomerCd = 0;

        #endregion

        #region -- Property --

        /// <summary>�ύX�O���Ӑ�R�[�h</summary>
        public int BfCustomerCd
        {
            get { return this.bfCustomerCd; }
            set { this.bfCustomerCd = value; }
        }

        /// <summary>�ύX�㓾�Ӑ�R�[�h</summary>
        public int AfCustomerCd
        {
            get { return this.afCustomerCd; }
            set { this.afCustomerCd = value; }
        }

        #endregion
    }
}
