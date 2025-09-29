using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ����E�d�����䃊���[�g�I�u�W�F�N�gDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����E�d�����䃊���[�g�I�u�W�F�N�gDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc�@��</br>
    /// <br>Date       : 2008.02.13</br>
    /// <br></br>
    /// <br>UpdateNote : K2011/12/09 ���N�n��</br>
    /// <br>�Ǘ��ԍ�   : 10703874-00</br>
    /// <br>�쐬���e   : �C�X�R�ʑΉ�</br>
    /// <br>Update Note: </br>
    /// <br></br>
    /// <br>UpdateNote : 2012/11/30 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>�쐬���e   : ����d���������͂Ŕ���`�[��ʁX�œ��͂��d���`�[�ԍ��𓯈�ō쐬���A</br>
    /// <br>�@�@�@�@   �@�쐬��������`�[�̕Е���`�[�폜�����ꍇ�A�d���`�[���Ăяo���Ȃ��Ȃ錏�̏C��</br>
    /// <br></br>
    /// <br>Update Note: 2014/05/01 �{�{ ����</br>
    /// <br>�Ǘ��ԍ�   : 11070071-00�@�d�|�ꗗ ��2257</br>
    /// <br>             �v����܂ޑݏo�f�[�^�̓`�[�폜���\�ɂ���</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IIOWriteControlDB
    {
        /// <summary>
        /// �G���g���Ǎ�
        /// </summary>
        /// <param name="paraList">�Ǎ����I�u�W�F�N�g���X�g</param>
        /// <param name="retList">�Ǎ����ʃI�u�W�F�N�g</param>
        /// <param name="retRelationList">�֘A�f�[�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Read([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                 ref object paraList,
                 [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                 out object retList,
                 [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                 out object retRelationList);

        /// <summary>
        /// �����`�[�Ǎ�
        /// </summary>
        /// <param name="paraList">�Ǎ����I�u�W�F�N�g���X�g</param>
        /// <param name="retList">�Ǎ����ʃI�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int ReadMore([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                 ref object paraList,
                 [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                 out object retList);

        /// <summary>
        /// ���׃f�[�^�Ǎ�
        /// </summary>
        /// <param name="paraList">�Ǎ����I�u�W�F�N�g���X�g</param>
        /// <param name="retList">�Ǎ����ʃI�u�W�F�N�g</param>
        /// <param name="retSynchroList">�֘A�f�[�^�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int ReadDetail([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                       ref object paraList,
                       [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                       out object retList,
                       [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                       out object retSynchroList);

        /// <summary>
        /// �G���g���X�V
        /// </summary>
        /// <param name="paraList">�X�V���I�u�W�F�N�g���X�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                  ref object paraList,
                  out string retMsg, out string retItemInfo);

        /// <summary>
        /// �G���g�������폜
        /// </summary>
        /// <param name="paraList">�����폜���I�u�W�F�N�g���X�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Delete([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                   ref object paraList,
                   out string retMsg, out string retItemInfo);

        // --- ADD 2012/11/30 Y.Wakita ---------->>>>>
        /// <summary>
        /// �G���g�������폜
        /// </summary>
        /// <param name="paraList">�����폜���I�u�W�F�N�g���X�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int DeleteA([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                   ref object paraList,
                   out string retMsg, out string retItemInfo);
        // --- ADD 2012/11/30 Y.Wakita ----------<<<<<

        /// <summary>
        /// �ԓ`�쐬(�ԓ`�쐬�f�[�^��S�ăp�����[�^�ŖႤ)
        /// </summary>
        /// <param name="orgList">����List</param>
        /// <param name="redList">�ԓ`List</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="retItemInfo">���ڏ��</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int RedWrite([CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                     ref object orgList,
                     [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
                     ref object redList,
                     out string retMsg, out string retItemInfo);

        // ----- ADD K2011/08/12 --------------------------->>>>>
        /// <summary>
        /// �T�[�o�[�V�X�e�����t�擾��߂��܂�		
        /// </summary>
        /// <returns>DateTime.now</returns>
        /// <br>Note        : �T�[�o�[�V�X�e�����t�擾��߂��܂�	</br>
        /// <br>Programmer  : ���N�n��</br>
        /// <br>Date        : K2011/12/09</br>
        /// <br>�Ǘ��ԍ�    : 10703874-00 �C�X�R�ʑΉ�</br>
        DateTime GetServerNowTime();
        // ----- ADD K2011/08/12 ---------------------------<<<<<

        // --- ADD 2014/05/01 T.Miyamoto �d�|�ꗗ��2257 ------------------------------>>>>>
        /// <summary>
        /// �ԕi���݃`�F�b�N
        /// </summary>
        /// <param name="paraList">���㖾�׃f�[�^���X�g</param>
        /// <returns>STATUS</returns>
        //[MustCustomSerialization]
        bool CheckReturnData(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            object paraList);
        // --- ADD 2014/05/01 T.Miyamoto �d�|�ꗗ��2257 ------------------------------<<<<<

# if DEBUG
        int ShLock(
            ref object param, int timeout, int retry, int interval);
# endif
    }
}
