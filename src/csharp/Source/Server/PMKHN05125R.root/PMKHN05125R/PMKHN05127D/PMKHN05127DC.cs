//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(���s)�N���X
// �v���O�����T�v   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// ����
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/03/23  �C�����e : �V�K�쐬
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(���s)�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̓��Ӑ�}�X�^�R�[�h�ϊ��f�[�^�p�����[�^(���s)�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/23</br>
    /// </remarks>
    [Serializable]
    [CustomSerializationData]
    public class CustomerConvertParamInfoList
    {
        #region -- Member --

        /// <summary>��ƃR�[�h</summary>
        private string enterpriseCode = String.Empty;
        /// <summary>�R�[�h�ϊ��Ώۃe�[�u��</summary>
        private string targetTable = String.Empty;
        /// <summary>�R�[�h�ϊ��ΏۃJ�����̃��X�g</summary>
        private IList<string> columnList = null;
        /// <summary>�R�[�h�ϊ��Ώۃf�[�^�̃��X�g</summary>
        private IList<CustomerConvertParamWork> cstmrCnvPrmWrkList = null;

        #endregion

        #region -- Property --

        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        public string EnterpriseCode
        {
            get { return this.enterpriseCode; }
            set { this.enterpriseCode = value; }
        }

        /// <summary>�R�[�h�ϊ��Ώۃe�[�u���v���p�e�B</summary>
        public string TargetTable
        {
            get { return this.targetTable; }
            set { this.targetTable = value; }
        }

        /// <summary>�R�[�h�ϊ��ΏۃJ�������X�g�v���p�e�B</summary>
        public IList<string> ColumnList
        {
            get { return this.columnList; }
            set { this.columnList = value; }
        }

        /// <summary>�R�[�h�ϊ��Ώۃf�[�^���X�g�v���p�e�B</summary>
        public IList<CustomerConvertParamWork> CustomerConvertParamWorkList
        {
            get { return this.cstmrCnvPrmWrkList; }
            set { this.cstmrCnvPrmWrkList = value; }
        }

        #endregion
    }
}
