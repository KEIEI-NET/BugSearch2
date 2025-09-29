//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ��f�[�^�N���X(�q�ɃR�[�h�A�q�ɖ���)
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
    /// PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ���ʃf�[�^�N���X(�q�ɃR�[�h�A�q�ɖ���)
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̑q�Ƀ}�X�^�R�[�h�ϊ���ʃf�[�^�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    public class WarehouseDispInfo
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

        /// <summary>�_���폜�t���O�v���p�e�B</summary>
        public int LogicalDelete
        {
            get { return this.logicalDelete; }
            set { this.logicalDelete = value; }
        }

        /// <summary>�q�ɃR�[�h�v���p�e�B</summary>
        public string WarehouseCode
        {
            get { return this.warehouseCd; }
            set { this.warehouseCd = value; }
        }

        /// <summary>�q�ɖ���</summary>
        public string WarehouseName
        {
            get { return this.warehouseNm; }
            set { this.warehouseNm = value; }
        }

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ���ʃf�[�^�N���X(�q�ɃR�[�h�A�q�ɖ���)�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS�����c�[���A�q�Ƀ}�X�^�R�[�h�ϊ���ʃf�[�^�N���X(�q�ɃR�[�h�A�q�ɖ���)�̏����������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>   
        public WarehouseDispInfo()
        {
            // �����Ȃ�
        }

        /// <summary>
        /// PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ���ʃf�[�^�]���N���X(�q�ɃR�[�h�A�q�ɖ���)�R���X�g���N�^
        /// </summary>
        /// <param name="code">�q�ɃR�[�h</param>
        /// <param name="name">�q�ɖ���</param>
        /// <param name="logicalDel">�_���폜�t���O</param>
        /// <remarks>
        /// <br>Note       : PM.NS�����c�[���A�q�Ƀ}�X�^�R�[�h�ϊ���ʃf�[�^�]���N���X(�q�ɃR�[�h�A�q�ɖ���)�̏����������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>   
        public WarehouseDispInfo(string code, string name, int logicalDel)
        {
            this.WarehouseCode = code;
            this.WarehouseName = name;
            this.logicalDelete = logicalDel;
        }

        #endregion
    }
}
