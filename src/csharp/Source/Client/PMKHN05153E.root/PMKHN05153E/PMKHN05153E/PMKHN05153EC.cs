//****************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�`�[�ԍ��ϊ��e�[�u�����ۑ��N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//========================================================================================//
// ����
//----------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470153-00 �쐬�S�� : �q��
// �C �� ��  2018/09/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// PM.NS�����c�[���@�`�[�ԍ��ϊ��e�[�u�����ۑ��N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PPM.NS�����c�[�� �`�[�ԍ��ϊ��e�[�u�����ۑ��N���X�ł��B</br>
    /// <br>Programmer : 30175 �q��</br>
    /// <br>Date       : 2018/9/10</br>
    /// </remarks>
    public class SlpNoTargetTableListResult
    {
        #region -- Member --

        /// <summary>�ԍ��R�[�h(�����Ώ۔ԍ�)</summary>
        private int targetNo = 0;
        /// <summary>�e�[�u��ID(������)</summary>
        private string targetTable = String.Empty;
        /// <summary>�e�[�u����(�_����)</summary>
        private string targetTableName = String.Empty;
        /// <summary>�J������(������)</summary>
        private string targetColum = String.Empty;
        /// <summary>�J������(�_����)</summary>
        private string targetColumName = String.Empty;
        /// <summary>�󒍃X�e�[�^�XID</summary>
        private string targetAcptStatusId = String.Empty;
        /// <summary>�󒍃X�e�[�^�X�R�[�h</summary>
        private int targetAcptStatus = 0;

        
        #endregion



        #region -- Property --

        /// <summary>�ԍ��R�[�h(�����Ώ۔ԍ�)</summary>
        public int TargetNo
        {
            get { return targetNo; }
            set { targetNo = value; }
        }

        /// <summary>�Ώۃe�[�u��(������)�v���p�e�B</summary>
        public string TargetTable
        {
            get { return this.targetTable; }
            set { targetTable = value; }
        }

        /// <summary>�Ώۃe�[�u��(�_����)�v���p�e�B</summary>
        public string TargetTableName
        {
            get { return this.targetTableName; }
            set { targetTableName = value; }
        }

        /// <summary>�J������(������)</summary>
        public string TargetColum
        {
            get { return targetColum; }
            set { targetColum = value; }
        }

        /// <summary>�J������(�_����)</summary>
        public string TargetColumName
        {
            get { return targetColumName; }
            set { targetColumName = value; }
        }

        /// <summary>�󒍃X�e�[�^�XID</summary>
        public string TargetAcptStatusId
        {
            get { return targetAcptStatusId; }
            set { targetAcptStatusId = value; }
        }

        /// <summary>�󒍃X�e�[�^�X�R�[�h</summary>
        public int TargetAcptStatus
        {
            get { return targetAcptStatus; }
            set { targetAcptStatus = value; }
        }
        
        #endregion
    }
}
