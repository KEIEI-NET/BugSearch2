//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�`�[�ԍ��ϊ�XML�f�[�^�i�[�N���X
// �v���O�����T�v   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2018Broadleaf Co.,Ltd.
//=====================================================================================//
// ����
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470153-00 �쐬�S�� : �q��
// �C �� ��  2018/09/11  �C�����e : �V�K�쐬
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS�����c�[���@WholeCompanyXML�f�[�^�i�[�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���@WholeCompanyXML�f�[�^�i�[�N���X�ł��B</br>
    /// <br>Programmer : 30175 �q��</br>
    /// <br>Date       : 2018/09/11</br>
    /// </remarks>
    [Serializable]
    [CustomSerializationData]
    public class WholeCompanyCvtList
    {
        #region -- Member --
        /// <summary>�e�[�u����(�_����)</summary>
        private string tableName = String.Empty;
        /// <summary>�e�[�u��ID(������)</summary>
        private string table = String.Empty;
        /// <summary>�ԍ��R�[�h(�����Ώ۔ԍ�)</summary>
        private string targetNo = String.Empty;
        /// <summary>�J������(������)</summary>
        private string targetColum = String.Empty;
        /// <summary>�J������(�_����)</summary>
        private string targetColumName = String.Empty;
        /// <summary>�󒍃X�e�[�^�XID</summary>
        private string acptStatusId = String.Empty;
        /// <summary>�󒍃X�e�[�^�X�R�[�h</summary>
        private string acptStatus = String.Empty;

        #endregion

        #region -- Property --

        /// <summary>�Ώۃe�[�u��(�_����)�v���p�e�B</summary>
        public string TABLENAME
        {
            get { return this.tableName; }
            set { this.tableName = value; }
        }

        /// <summary>�Ώۃe�[�u��(������)�v���p�e�B</summary>
        public string TABLE
        {
            get { return this.table; }
            set { this.table = value; }
        }

        /// <summary>�J������(�_����)</summary>
        public string TARGETCOLUMNNAME
        {
            get { return targetColumName; }
            set { targetColumName = value; }
        }

        /// <summary>�J������(������)</summary>
        public string TARGETCOLUM
        {
            get { return targetColum; }
            set { targetColum = value; }
        }

        /// <summary>�ԍ��R�[�h(�����Ώ۔ԍ�)</summary>
        public string TARGETNO
        {
            get { return targetNo; }
            set { targetNo = value; }
        }

        /// <summary>�󒍃X�e�[�^�XID</summary>
        public string ACPTSTATUSID
        {
            get { return acptStatusId; }
            set { acptStatusId = value; }
        }

        /// <summary>�󒍃X�e�[�^�X�R�[�h</summary>
        public string ACPTSTATUS
        {
            get { return acptStatus; }
            set { acptStatus = value; }
        }

        #endregion
    }
}
