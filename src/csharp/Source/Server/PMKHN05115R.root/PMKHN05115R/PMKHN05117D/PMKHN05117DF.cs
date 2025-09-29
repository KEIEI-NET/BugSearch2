//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ�XML�f�[�^�i�[�N���X
// �v���O�����T�v   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// ����
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/03/10  �C�����e : �V�K�쐬
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ�XML�f�[�^�i�[�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̒S���҃}�X�^�R�[�h�ϊ�XML�f�[�^�i�[�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/10</br>
    /// </remarks>
    public class EmployeeConvertList
    {
        #region -- Member --

        /// <summary>�Ώۃe�[�u����(������)</summary>
        private string targetTable = String.Empty;
        /// <summary>�Ώۃe�[�u����(�_����)</summary>
        private string targetTableName = String.Empty;
        /// <summary>�ΏۃJ������(������)</summary>
        private string targetColumn = String.Empty;
        /// <summary>�ΏۃJ������(�_����)</summary>
        private string targetColumnName = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>�Ώۃe�[�u����(������)�v���p�e�B</summary>
        public string TargetTable
        {
            get { return this.targetTable; }
            set { this.targetTable = value; }
        }

        /// <summary>�Ώۃe�[�u����(�_����)�v���p�e�B</summary>
        public string TargetTableName
        {
            get { return this.targetTableName; }
            set { this.targetTableName = value; }
        }

        /// <summary>�ΏۃJ������(������)�v���p�e�B</summary>
        public string TargetColumn
        {
            get { return this.targetColumn; }
            set { this.targetColumn = value; }
        }

        /// <summary>�ΏۃJ������(�_����)�v���p�e�B</summary>
        public string TargetColumnName
        {
            get { return this.targetColumnName; }
            set { this.targetColumnName = value; }
        }

        #endregion
    }
}
