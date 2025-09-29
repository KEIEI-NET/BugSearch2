//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(����)�N���X
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
    /// PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(����)�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̑q�Ƀ}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(����)�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    [Serializable]
    [CustomSerializationData]
    public class WarehouseSearchWork
    {
        #region -- Member --

        /// <summary>�_���폜�t���O</summary>
        private int logicalDelete = 0;

        /// <summary>�q�ɃR�[�h</summary>
        private string warehouseCd = String.Empty;

        /// <summary>�q�ɖ���</summary>
        private string warehouseNm = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>
        /// �_���폜�t���O�v���p�e�B
        /// </summary>
        public int LogicalDelete
        {
            get { return this.logicalDelete; }
            set { this.logicalDelete = value; }
        }

        /// <summary>
        /// �q�ɃR�[�h(�J�n)�v���p�e�B
        /// </summary>
        public string WarehouseCd
        {
            get { return this.warehouseCd; }
            set { this.warehouseCd = value; }
        }

        /// <summary>
        /// �q�ɖ��̃v���p�e�B
        /// </summary>
        public string WarehouseNm
        {
            get { return this.warehouseNm; }
            set { this.warehouseNm = value; }
        }

        #endregion
    }
}
