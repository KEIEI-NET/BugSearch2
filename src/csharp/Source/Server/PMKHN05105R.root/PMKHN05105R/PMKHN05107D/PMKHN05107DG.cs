//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ�XML�f�[�^�i�[�N���X
// �v���O�����T�v   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//=====================================================================================//
// ����
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/02/18  �C�����e : �V�K�쐬
//-------------------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// <summary>
    /// PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ�XML�f�[�^�i�[�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̑q�Ƀ}�X�^�R�[�h�ϊ�XML�f�[�^�i�[�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    [XmlRoot("ArrayOfWarehouseConvertList")]
    public class ArrayOfWarehouseConvertList
    {
        #region -- Member --

        /// <summary>�Ώۃe�[�u�����ꗗ</summary>
        private List<WarehouseConvertList> warehouseConvertList;

        #endregion

        #region -- Property --

        /// <summary>
        /// �Ώۃe�[�u�����ꗗ�v���p�e�B
        /// </summary>
        [XmlElement("WarehouseConvertList")]
        public List<WarehouseConvertList> WarehouseConvertList
        {
            get { return this.warehouseConvertList; }
            set { this.warehouseConvertList = value; }
        }

        #endregion
    }
}
