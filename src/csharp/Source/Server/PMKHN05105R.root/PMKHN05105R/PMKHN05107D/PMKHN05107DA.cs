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
    public class WarehouseSearchParamWork
    {
        #region -- Member --

        /// <summary>��ƃR�[�h</summary>
        private string enterPriseCode = String.Empty;

        /// <summary>�q�ɃR�[�h(�J�n)</summary>
        private string warehouseStCd = String.Empty;

        /// <summary>�q�ɃR�[�h(�I��)</summary>
        private string warehouseEdCd = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>
        /// ��ƃR�[�h�v���p�e�B
        /// </summary>
        public string EnterPriseCode
        {
            get { return this.enterPriseCode; }
            set { this.enterPriseCode = value; }
        }

        /// <summary>
        /// �q�ɃR�[�h(�J�n)�v���p�e�B
        /// </summary>
        public string WarehouseStCd
        {
            get { return this.warehouseStCd; }
            set { this.warehouseStCd = value; }
        }

        /// <summary>
        /// �q�ɃR�[�h(�I��)�v���p�e�B
        /// </summary>
        public string WarehouseEdCd
        {
            get { return this.warehouseEdCd; }
            set { this.warehouseEdCd = value; }
        }

        #endregion
    }
}
