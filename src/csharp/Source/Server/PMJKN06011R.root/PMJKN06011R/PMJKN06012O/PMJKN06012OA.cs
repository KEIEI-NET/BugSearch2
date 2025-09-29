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
    /// ���R�������i�擾DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�������i�擾 RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 22018�@��� ���b</br>
    /// <br>Date       : 2010/04/26</br>
    /// <br></br>
    /// <br>Update Note: 2014/02/06 ���� ����q</br>
    /// <br>�Ǘ��ԍ�   : </br>
    /// <br>           : SCM�d�|�ꗗ��10632�Ή�</br>
    /// </remarks>
    [APServerTarget( ConstantManagement_SF_PRO.ServerCode_UserAP )]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
    public interface IFreeSearchPartsSearchDB
    {
        /// <summary>
        /// ���R�������i�}�X�^����
        /// </summary>
        /// <param name="inPara"></param>
        /// <param name="retInf"></param>
        /// <param name="retCnt"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int Search(
                FreeSearchPartsSParaWork inPara,
                [CustomSerializationMethodParameterAttribute( "PMJKN06013D", "Broadleaf.Application.Remoting.ParamData.FreeSearchPartsSRetWork" )]
                ref object retInf,
                out long retCnt );
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ���R�������i�}�X�^����
        /// </summary>
        /// <param name="inPara"></param>
        /// <param name="retInf"></param>
        /// <param name="retCnt"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int Search(
                ArrayList inPara,
                ref object retInf,
                out long retCnt);
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<
    }
}
