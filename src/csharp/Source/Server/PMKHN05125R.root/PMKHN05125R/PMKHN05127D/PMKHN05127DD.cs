//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(���s)�N���X
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
    /// PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(���s)�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̓��Ӑ�}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(���s)�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/23</br>
    /// </remarks>
    [Serializable]
    [CustomSerializationData]
    public class CustomerConvertParamWork
    {
        #region -- Member --

        /// <summary>�ύX�O���Ӑ�R�[�h</summary>
        private int bfCustomerCd = 0;
        /// <summary>�ύX�㓾�Ӑ�R�[�h</summary>
        private int afCustomerCd = 0;

        #endregion

        #region -- Property --

        /// <summary>�ύX�O���Ӑ�R�[�h�v���p�e�B</summary>
        public int BfCustomerCode
        {
            get { return this.bfCustomerCd; }
            set { this.bfCustomerCd = value; }
        }

        /// <summary>�ύX�㓾�Ӑ�R�[�h�v���p�e�B</summary>
        public int AfCustomerCode
        {
            get { return this.afCustomerCd; }
            set { this.afCustomerCd = value; }
        }

        #endregion
    }
}
