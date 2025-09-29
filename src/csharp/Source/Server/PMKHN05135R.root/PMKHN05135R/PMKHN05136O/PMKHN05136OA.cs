//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���_�R�[�h�ϊ��C���^�[�t�F�[�X
// �v���O�����T�v   : 
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//=====================================================================================//
// ����
//-------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2017/12/15  �C�����e : �V�K�쐬
//-------------------------------------------------------------------------------------//
using System;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PM.NS�����c�[���@���_�R�[�h�ϊ��C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̋��_�R�[�h�ϊ��C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2017/12/15</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISectionConvertDB
    {
        /// <summary>
        /// ���_�̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="sectionPrmObj">��������</param>
        /// <param name="sectionRetObjList">��������</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������ɋ��_�̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKHN05137D", "Broadleaf.Application.Remoting.ParamData.SectionSearchParamWork")]
            object sectionPrmObj,
            [CustomSerializationMethodParameterAttribute("PMKHN05137D", "Broadleaf.Application.Remoting.ParamData.SectionSearchWork")]
            ref object sectionRetObjList
            );

        /// <summary>
        /// �R�[�h�ϊ�����
        /// </summary>
        /// <param name="sectionConvertPrmObj">�ϊ�����</param>
        /// <param name="numberOfTransactions">�����������i�[�����ϐ�</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ��ʂŎw�肵�����������ɋ��_�R�[�h��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        int Convert(
            [CustomSerializationMethodParameterAttribute("PMKHN05137D", "Broadleaf.Application.Remoting.ParamData.SectionConvertPrmInfoList")]
            object sectionConvertPrmObj,
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
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        int GetConvertTableList(
            ref object targetTableList
            );
    }
}
