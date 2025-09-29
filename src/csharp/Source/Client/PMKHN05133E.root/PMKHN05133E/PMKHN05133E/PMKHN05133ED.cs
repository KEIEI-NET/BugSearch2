//****************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���_�R�[�h�ϊ��e�[�u�����ۑ��N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//========================================================================================//
// ����
//----------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2017/12/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS�����c�[���@���_�R�[�h�ϊ��e�[�u�����ۑ��N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̋��_�R�[�h�ϊ��e�[�u�����ۑ��N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2017/12/15</br>
    /// </remarks>
    public class TargetTableListResult
    {
        #region -- Member --

        /// <summary>�e�[�u����(������)</summary>
        private string targetTable = String.Empty;
        /// <summary>�e�[�u����(�_����)</summary>
        private string targetTableName = String.Empty;
        /// <summary>�J������(������)�̃��X�g</summary>
        private IList<string> columnList = null;

        #endregion

        #region -- Property --

        /// <summary>�Ώۃe�[�u��(������)�v���p�e�B</summary>
        public string TargetTable
        {
            get { return this.targetTable; }
            set { this.targetTable = value; }
        }

        /// <summary>�Ώۃe�[�u��(�_����)�v���p�e�B</summary>
        public string TargetTableName
        {
            get { return this.targetTableName; }
            set { this.targetTableName = value; }
        }

        /// <summary>�J������(������)�̃v���p�e�B</summary>
        public IList<string> ColumnList
        {
            get { return this.columnList; }
            set { this.columnList = value; }
        }

        #endregion
    }
}
