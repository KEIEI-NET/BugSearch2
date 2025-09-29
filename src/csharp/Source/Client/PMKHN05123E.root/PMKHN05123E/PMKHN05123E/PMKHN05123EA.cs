//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ��f�[�^�N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/03/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ���ʃf�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̓��Ӑ�}�X�^�R�[�h�ϊ���ʃf�[�^�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/23</br>
    /// </remarks>
    public class CustomerSearchDispWork
    {
        #region -- Member --

        /// <summary>��ƃR�[�h</summary>
        private string enterpriseCd = String.Empty;
        /// <summary>���Ӑ�R�[�h(�J�n)</summary>
        private int customerCdStart = 0;
        /// <summary>���Ӑ�R�[�h(�I��)</summary>
        private int customerCdEnd = 0;

        #endregion

        #region -- Property --

        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        public string EnterpriseCode
        {
            get { return this.enterpriseCd; }
            set { this.enterpriseCd = value; }
        }

        /// <summary>���Ӑ�R�[�h(�J�n)�v���p�e�B</summary>
        public int CustomerCodeStart
        {
            get { return this.customerCdStart; }
            set { this.customerCdStart = value; }
        }

        /// <summary>���Ӑ�R�[�h(�I��)�v���p�e�B</summary>
        public int CustomerCodeEnd
        {
            get { return this.customerCdEnd; }
            set { this.customerCdEnd = value; }
        }

        #endregion
    }
}
