//****************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[�� �`�[�ԍ��ϊ����ێ��f�[�^�N���X
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
    /// PM.NS�����c�[�� �`�[�ԍ��ϊ��ێ��f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[�� �`�[�ԍ��ϊ����ێ��f�[�^�N���X�ł��B</br>
    /// <br>Programmer : 30175 �q��</br>
    /// <br>Date       : 2018/09/10</br>
    /// </remarks>
    public class SlpNoConvertData
    {
        #region -- Member --

        /// <summary>�ԍ��R�[�h(�����Ώ۔ԍ�)</summary>
        private int noCode = 0;

        /// <summary>�e�[�u��ID(������)</summary>
        private string table = String.Empty;

        /// <summary>�e�[�u����(�_����)</summary>
        private string tableName = String.Empty;
        
        /// <summary>�J������(������)</summary>
        private string colum = String.Empty;
        
        /// <summary>�J������(�_����)</summary>
        private string columName = String.Empty;
        
        /// <summary>�󒍃X�e�[�^�XID</summary>
        private string acptStatusId = String.Empty;
        /// <summary>�󒍃X�e�[�^�X�R�[�h</summary>
        private int acptStatus = 0;

        /// <summary>�ԍ����ݒl</summary>
        private Int64 noPresentVal = 0;

        /// <summary>�ݒ�J�n�ԍ�</summary>
        private Int64 settingStartNo = 0;
       
        /// <summary>�ݒ�I���ԍ�</summary>
        private Int64 settingEndNo = 0;
        
        /// <summary>�ԍ������l</summary>
        private Int64 noIncDecWidth = 0;
        
        

        #endregion

        #region -- Property --

        /// <summary>�ԍ��R�[�h(�����Ώ۔ԍ�)</summary>
        public int NoCode
        {
            get { return noCode; }
            set { noCode = value; }
        }

        /// <summary>�e�[�u��ID(������)</summary>
        public string Table
        {
            get { return table; }
            set { table = value; }
        }

        /// <summary>�e�[�u����(�_����)</summary>
        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        /// <summary>�󒍃X�e�[�^�X�R�[�h</summary>
        public int AcptStatus
        {
            get { return acptStatus; }
            set { acptStatus = value; }
        }

        /// <summary>�J������(������)</summary>
        public string Colum
        {
            get { return colum; }
            set { colum = value; }
        }

        /// <summary>�J������(�_����)</summary>
        public string ColumName
        {
            get { return columName; }
            set { columName = value; }
        }

        
        /// <summary>�󒍃X�e�[�^�XID</summary>
        public string AcptStatusId
        {
            get { return acptStatusId; }
            set { acptStatusId = value; }
        }

        /// <summary>�ԍ����ݒl</summary>
        public Int64 NoPresentVal
        {
            get { return noPresentVal; }
            set { noPresentVal = value; }
        }

        /// <summary>�ݒ�J�n�ԍ�</summary>
        public Int64 SettingStartNo
        {
            get { return settingStartNo; }
            set { settingStartNo = value; }
        }


        /// <summary>�ݒ�I���ԍ�</summary>
        public Int64 SettingEndNo
        {
            get { return settingEndNo; }
            set { settingEndNo = value; }
        }

        /// <summary>�ԍ������l</summary>
        public Int64 NoIncDecWidth
        {
            get { return noIncDecWidth; }
            set { noIncDecWidth = value; }
        }
        #endregion
    }
}
