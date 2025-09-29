//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(����)�N���X
// �v���O�����T�v   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// ����
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/03/23  �C�����e : �V�K�쐬
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(����)�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̓��Ӑ�}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(����)�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/10</br>
    /// </remarks>
    [Serializable]
    [CustomSerializationData]
    public class CustomerSearchParamWork
    {
        #region -- Member --

        /// <summary>��ƃR�[�h</summary>
        private string enterpriseCode = String.Empty;
        /// <summary>���Ӑ�R�[�h(�J�n)</summary>
        private int customerCdSt = 0;
        /// <summary>���Ӑ�R�[�h(�I��)</summary>
        private int customerCdEd = 0;

        #endregion

        #region -- Property --

        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        public string EnterpriseCode
        {
            get { return this.enterpriseCode; }
            set { this.enterpriseCode = value; }
        }

        /// <summary>���Ӑ�R�[�h(�I��)�v���p�e�B</summary>
        public int CustomerCodeStart
        {
            get { return this.customerCdSt; }
            set { this.customerCdSt = value; }
        }

        /// <summary>���Ӑ�R�[�h(�I��)�v���p�e�B</summary>
        public int CustomerCodeEnd
        {
            get { return this.customerCdEd; }
            set { this.customerCdEd = value; }
        }

        #endregion
    }
}
