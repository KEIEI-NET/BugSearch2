//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(���s)�N���X
// �v���O�����T�v   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// ����
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/02/18  �C�����e : �V�K�쐬
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(���s)�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̑q�Ƀ}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(���s)�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    [Serializable]
    [CustomSerializationData]
    public class WarehouseConvertPrmWork
    {
        #region -- Member --

        /// <summary>�ϊ��O�q�ɃR�[�h</summary>
        private string bfWarehouseCode = String.Empty;
        /// <summary>�ϊ���q�ɃR�[�h</summary>
        private string afWarehouseCode = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>
        /// �ύX�O�q�ɃR�[�h
        /// </summary>
        public string BfWarehouseCode
        {
            get { return this.bfWarehouseCode; }
            set { this.bfWarehouseCode = value; }
        }

        /// <summary>
        /// �ύX��q�ɃR�[�h
        /// </summary>
        public string AfWarehouseCode
        {
            get { return this.afWarehouseCode; }
            set { this.afWarehouseCode = value; }
        }

        #endregion
    }
}
