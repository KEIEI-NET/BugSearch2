//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ��C���^�[�t�F�[�X
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

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ��C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̓��Ӑ�}�X�^�R�[�h�ϊ��C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/23</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustomerConvertDB
    {
        /// <summary>
        /// ���Ӑ�}�X�^�̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="customerPrmObj">��������</param>
        /// <param name="customerRetObjList">��������</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������ɓ��Ӑ�}�X�^�̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        int Search(
            [CustomSerializationMethodParameter("PMKHN05127D", "Broadleaf.Application.Remoting.ParamData.CustomerSearchParamWork")]
            object customerPrmObj,
            [CustomSerializationMethodParameter("PMKHN05127D", "Broadleaf.Application.Remoting.ParamData.CustomerSearchWork")]
            ref object customerRetObjList
            );

        /// <summary>
        /// �R�[�h�ϊ�����
        /// </summary>
        /// <param name="customerConvertPrmObj">�ϊ�����</param>
        /// <param name="numberOfTransactions">�����������i�[�����ϐ�</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������ɓ��Ӑ�R�[�h��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        int Convert(
            [CustomSerializationMethodParameter("PMKHN05127D", "Broadleaf.Application.Remoting.ParamData.CustomerConvertParamInfoList")]
            object customerConvertPrmObj,
            ref int numberOfTransactions
            );

        /// <summary>
        /// �R�[�h�ϊ��Ώۃe�[�u�����X�g�擾����
        /// </summary>
        /// <param name="targetTableList">�R�[�h�ϊ��Ώۃe�[�u�����X�g</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �R�[�h�ϊ��Ώۂ̃e�[�u���̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        int GetConvertTableList(
            ref object targetTableList
            );
    }
}
