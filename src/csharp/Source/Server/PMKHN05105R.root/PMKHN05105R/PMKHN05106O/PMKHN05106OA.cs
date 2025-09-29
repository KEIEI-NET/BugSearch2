//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ��C���^�[�t�F�[�X
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
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ��C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̑q�Ƀ}�X�^�R�[�h�ϊ��C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IWarehouseConvertDB
    {
        /// <summary>
        /// �q�Ƀ}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="warehousePrmObj">��������</param>
        /// <param name="warehouseRetObjList">��������</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������ɑq�Ƀ}�X�^�̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN05107D", "Broadleaf.Application.Remoting.ParamData.WarehouseSearchParamWork")]
            object warehousePrmObj,
            [CustomSerializationMethodParameterAttribute("PMKHN05107D", "Broadleaf.Application.Remoting.ParamData.WarehouseSearchWork")]
            ref object warehouseRetObjList
            );

        /// <summary>
        /// �R�[�h�ϊ�����
        /// </summary>
        /// <param name="warehouseConvertPrmObj">�ϊ�����</param>
        /// <param name="numberOfTransactions">�����������i�[�����ϐ�</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������ɑq�ɃR�[�h��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        int Convert(
            [CustomSerializationMethodParameterAttribute("PMKHN05107D", "Broadleaf.Application.Remoting.ParamData.WarehouseConvertPrmInfoList")]
            object warehouseConvertPrmObj,
            ref long numberOfTransactions
            );

        /// <summary>
        /// �R�[�h�ϊ��Ώۃe�[�u�����X�g�擾����
        /// </summary>
        /// <param name="targetTableList">�R�[�h�ϊ��Ώۃe�[�u�����X�g</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �R�[�h�ϊ��Ώۂ̃e�[�u���̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        int GetConvertTableList(
            ref object targetTableList
            );
    }
}
