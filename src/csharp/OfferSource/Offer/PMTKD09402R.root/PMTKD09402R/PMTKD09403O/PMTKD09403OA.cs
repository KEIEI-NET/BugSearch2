//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �D�Ǖ��i�o�[�R�[�h��񒊏o�����[�g
// �v���O�����T�v   : �D�Ǖ��i�o�[�R�[�h��񒊏oRemoteObject�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00  �쐬�S�� : 30757 ���X�؋M�p
// �� �� ��  2017/09/20   �C�����e : �n���f�B�^�[�~�i���񎟑Ή��i�V�K�쐬�j
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using System.Runtime.Remoting.Messaging;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;
using System.Collections.Generic;

namespace Broadleaf.Application.Remoting
{

    /// <summary>
    /// �D�Ǖ��i�o�[�R�[�h��񒊏oRemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �D�Ǖ��i�o�[�R�[�h��񒊏oRemoteObject�C���^�[�t�F�[�X�̒�`</br>
    /// <br>Programmer : 30757�@���X�؁@�M�p</br>
    /// <br>Date       : 2017/09/20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
    public interface IOfferPrmPartsBrcdInfo
    {
        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h��񒊏o�����擾
        /// </summary>
        /// <param name="selectParam">���o�p�����[�^</param>
        /// <param name="retCnt">���o����</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���o�p�����[�^�̏����ɍ��v����D�Ǖ��i�o�[�R�[�h�����擾�����ꍇ�̌������擾����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int GetSearchCount(
            [CustomSerializationMethodParameterAttribute( "PMTKD09404D", "Broadleaf.Application.Remoting.ParamData.GetPrmPartsBrcdParaWork" )]
                ref object selectParam,
                out int retCnt
            );

        /// <summary>
        /// �D�Ǖ��i�o�[�R�[�h��񒊏o
        /// </summary>
        /// <param name="selectParam">���o�p�����[�^</param>
        /// <param name="prmPartsBrcdInfoList">���o����</param>
        /// <returns>��������</returns>
        /// <remarks>
        /// <br>Note       : ���o�p�����[�^�̏����ɍ��v����D�Ǖ��i�o�[�R�[�h�����擾�擾����</br>
        /// <br>Programmer : 30757�@���X�؁@�M�p</br>
        /// <br>Date       : 2017/09/20</br>
        /// <br></br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute( "PMTKD09404D", "Broadleaf.Application.Remoting.ParamData.GetPrmPartsBrcdParaWork" )]
                ref object selectParam,
            [CustomSerializationMethodParameterAttribute( "PMTKD09404D", "Broadleaf.Application.Remoting.ParamData.RettPrmPartsBrcdInfoWork" )]
                out object prmPartsBrcdInfoList
            );
    }
}
