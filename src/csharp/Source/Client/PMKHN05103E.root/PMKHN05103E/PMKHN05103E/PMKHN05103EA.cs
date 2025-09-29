//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ��f�[�^�N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/02/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ���ʃf�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̑q�Ƀ}�X�^�R�[�h�ϊ���ʃf�[�^�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    public class WarehouseConvertDispInfo
    {
        #region -- Member --

        /// <summary>��ƃR�[�h</summary>
        private string enterpriseCode = String.Empty;
        /// <summary>�q�ɃR�[�h(�J�n)</summary>
        private string warehouseCdStart = String.Empty;
        /// <summary>�q�ɃR�[�h(�I��)</summary>
        private string warehouseCdEnd = String.Empty;        

        #endregion

        #region -- Property --

        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        public string EnterpriseCode
        {
            get { return this.enterpriseCode; }
            set { this.enterpriseCode = value; }
        }

        /// <summary>�q�ɃR�[�h(�J�n)�v���p�e�B</summary>
        public string WarehouseCdStart
        {
            get { return this.warehouseCdStart; }
            set { this.warehouseCdStart = value; }
        }

        /// <summary>�q�ɃR�[�h(�I��)�v���p�e�B</summary>
        public string WarehouseCdEnd
        {
            get { return this.warehouseCdEnd; }
            set { this.warehouseCdEnd = value; }
        }

        #endregion
    }
}
