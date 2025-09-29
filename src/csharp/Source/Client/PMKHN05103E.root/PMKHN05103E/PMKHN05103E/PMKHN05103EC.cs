//****************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ��R�[�h�ύX���ێ��f�[�^�N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//========================================================================================//
// ����
//----------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/02/18  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ���ʕύX���ێ��f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̑q�Ƀ}�X�^�R�[�h�ϊ���ʕύX���ێ��f�[�^�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    public class WarehouseConvertData
    {
        #region -- Member --

        /// <summary>�ϊ��O�q�ɃR�[�h</summary>
        private string bfwarehouseCd = String.Empty;
        /// <summary>�ϊ���q�ɃR�[�h</summary>
        private string afwarehouseCd = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>�ύX�O�q�ɃR�[�h</summary>
        public string BfWarehouseCd
        {
            get { return this.bfwarehouseCd; }
            set { this.bfwarehouseCd = value; }
        }

        /// <summary>�ύX��q�ɃR�[�h</summary>
        public string AfWarehouseCd
        {
            get { return this.afwarehouseCd; }
            set { this.afwarehouseCd = value; }
        }

        #endregion
    }
}
