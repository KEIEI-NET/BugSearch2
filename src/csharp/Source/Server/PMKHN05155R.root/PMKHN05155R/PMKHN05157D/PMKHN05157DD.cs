//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[�� �`�[�ԍ��ϊ�XML�f�[�^�i�[�N���X
// �v���O�����T�v   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//=====================================================================================//
// ����
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470153-00 �쐬�S�� : �q��
// �C �� ��  2018/09/07  �C�����e : �V�K�쐬
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS�����c�[�� woleCompanyCvtListXML�f�[�^�i�[�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[�� woleCompanyCvtListXML�f�[�^�i�[�N���X�ł��B</br>
    /// <br>Programmer : 30175 �q��</br>
    /// <br>Date       : 2018/09/12</br>
    /// </remarks>
    [XmlRoot("ArrayOfWholeCompanyList")]
    public class ArrayOfWholeCompanyList
    {
        #region -- Member --

        /// <summary>�Ώۃe�[�u�����ꗗ</summary>
        private List<WholeCompanyCvtList> woleCompanyCvtList;

        #endregion

        #region -- Property --

        /// <summary>�Ώۃe�[�u�����ꗗ�v���p�e�B</summary>
        [XmlElement("WholeCompanyList")]

        public List<WholeCompanyCvtList> WoleCompanyCvtList
        {
            get { return woleCompanyCvtList; }
            set { woleCompanyCvtList = value; }
        }

        #endregion
    }
}
