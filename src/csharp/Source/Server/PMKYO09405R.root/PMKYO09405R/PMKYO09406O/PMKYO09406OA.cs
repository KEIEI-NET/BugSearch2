using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ����M�������ODB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����M�������ODB RemoteObject Interface�ł��B</br>
    /// <br>Programmer  : lushan</br>
    /// <br>Date        : 2011/07/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_Center_UserAP)] // �A�v���P�[�V�����̐ڑ���𑮐��Ŏw��
    public interface ISndRcvHisDB
    {
        /// <summary>
        /// ����M�������O����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="paraList">����M�������O�u�W�F�N�g���X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�������O����o�^�A�X�V���܂�</br>
        /// <br>Programmer  : lushan</br>
        /// <br>Date        : 2011/07/25</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                  ref object paraList);

        /// <summary>
        /// ����M�������O����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="sndRcvHisWorkList">pList�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����M�������O����o�^�A�X�V���܂�</br>
        /// <br>Programmer : lushan</br>
        /// <br>Date       : 2011/07/25</br>
        [MustCustomSerialization]
        int WriteRcvHisWork(
            [CustomSerializationMethodParameterAttribute("PMKYO09407D", "Broadleaf.Application.Remoting.ParamData.SndRcvHisWork")]
            ref ArrayList sndRcvHisWorkList);


        /// <summary>
        /// ����M�������O�f�[�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="SndRcvHisCondWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer  : lushan</br>
        /// <br>Date        : 2011/07/25</br>
        [MustCustomSerialization]
        int Search(
            SndRcvHisCondWork SndRcvHisCondWork,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retList);


        /// <summary>
        /// ����M�������O���𕨗��폜
        /// </summary>
        /// <param name="paraList">�����폜���I�u�W�F�N�g���X�g</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                   ref object paraList);

        /// <summary>
        /// ����M�������O���𕨗��폜
        /// </summary>
        /// <param name="paraList">�����폜���I�u�W�F�N�g���X�g</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int LogicDelete([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                    ref object paraList);
    }
}
