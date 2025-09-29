//**************************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[�� �`�[�ԍ��ϊ��C���^�[�t�F�[�X
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
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PM.NS�����c�[���@�`�[�ԍ��ϊ��C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���`�[�ԍ��ϊ��C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 30175 �q��</br>
    /// <br>Date       : 2018/09/07</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISlipNoConvertDB
    {
        /// <summary>
        /// �`�[�ԍ��ϊ��Ώۃe�[�u�����X�g�擾����
        /// </summary>
        /// <param name="secDiv">���_�敪�i0�F�S�ЁA1�F���_�j</param>
        /// <param name="targetTableList">�`�[�ԍ��ϊ��Ώۃe�[�u�����X�g</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �`�[�ԍ��ϊ��Ώۂ̃e�[�u���̃��X�g���擾���܂��B</br>
        /// <br>Programmer : 30175 �q��</br>
        /// <br>Date       : 2018/09/07</br>
        /// </remarks>
        int GetTargetTableList(int secDiv, ref object targetTableList);

        
        /// <summary>
        /// �`�[�ԍ��ϊ��O�`�F�b�N����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="slipNoCnvPrm">�ύX�f�[�^</param>
        /// <param name="check">�`�F�b�N����</param>
        /// <returns>�����X�e�[�^�X</returns>
        int CheckConvertSlipNo(string enterpriseCode, 
            [CustomSerializationMethodParameterAttribute("PMKHN05157D", "Broadleaf.Application.Remoting.ParamData.SlipNoConvertPrmInfoList")] object slipNoCnvPrm,
            ref bool check
            );


        /// <summary>
        /// �`�[�ԍ��ϊ�����
        /// </summary>
        /// <param name="enterprise">��ƃR�[�h</param>
        /// <param name="slipNoCnvPrm">�ύX�f�[�^</param>
        /// <param name="numberOfTransactions">�����������i�[�����ϐ�</param>
        /// <returns></returns>
        int ConvertSlipNo(string enterprise,
            [CustomSerializationMethodParameterAttribute("PMKHN05157D", "Broadleaf.Application.Remoting.ParamData.SlipNoConvertPrmInfoList")] object slipNoCnvPrm,
            ref long numberOfTransactions
            );
    }
}
