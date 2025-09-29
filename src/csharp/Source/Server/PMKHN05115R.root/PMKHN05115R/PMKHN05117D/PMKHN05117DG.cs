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
using System.Xml.Serialization;

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
    [XmlRoot("ArrayOfEmployeeConvertList")]
    public class ArrayOfEmployeeConvertList
    {
        #region -- Member --

        /// <summary>�Ώۃe�[�u�����ꗗ</summary>
        private List<EmployeeConvertList> emplyCnvList = null;

        #endregion

        #region -- Property --

        /// <summary>�Ώۃe�[�u�����ꗗ�v���p�e�B</summary>
        [XmlElement("EmployeeConvertList")]
        public List<EmployeeConvertList> EmployeeConvertList
        {
            get { return this.emplyCnvList; }
            set { this.emplyCnvList = value; }
        }

        #endregion
    }
}
