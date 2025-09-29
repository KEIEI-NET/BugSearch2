using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���㗚���Ɖ�DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���㗚���Ɖ�DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2007.10.04</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalHisRefDB
    {
        /// <summary>
        /// �w�肳�ꂽ�p�����[�^�̏����𖞂����S�Ă̔��㗚���Ɖ�LIST��߂��܂�
        /// </summary>
        /// <param name="salHisRefResultParam">��������</param>
        /// <param name="salHisRefExtraParamWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�ۗ��f�[�^�̂� 3:���S�폜�f�[�^�̂� 4:�S�� 5:���K�f�[�^+�폜�f�[�^ 6:���K�f�[�^+�폜�f�[�^+�ۗ��f�[�^)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����L�[��LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.10.04</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCHNB04116D", "Broadleaf.Application.Remoting.ParamData.SalHisRefResultParamWork")]
            out object salHisRefResultParam,
            object salHisRefExtraParamWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        #region �w�茏���ǂݍ��ݖ��g�p�ׁ̈A�폜
        /*
        /// <summary>
        /// �w�肳�ꂽ�p�����[�^�̏����𖞂����w�茏�����̔��㗚���Ɖ�LIST��߂��܂�
        /// </summary>
        /// <param name="salHisRefResultParam">��������</param>
        /// <param name="salHisRefExtraParamWork">���㌟���p�����[�^�iNextRead���͑O��ŏI���R�[�h�L�[�j</param>
        /// <param name="retTotalCnt">�����Ώۑ�����</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="readCnt">�����w�茏��</param>        
        /// <param name="readMode">�����敪(���g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�ۗ��f�[�^�̂� 3:���S�폜�f�[�^�̂� 4:�S�� 5:���K�f�[�^+�폜�f�[�^ 6:���K�f�[�^+�폜�f�[�^+�ۗ��f�[�^)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�p�����[�^�̏����𖞂����w�茏�����̔���f�[�^LIST��߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.10.04</br>
        [MustCustomSerialization]
        int TopSearch(
            [CustomSerializationMethodParameterAttribute("DCHNB04116D", "Broadleaf.Application.Remoting.ParamData.SalHisRefResultParamWork")]
            out object salHisRefResultParam,
            object salHisRefExtraParamWork, out int retTotalCnt, out bool nextData, int readCnt,
            int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �w�肳�ꂽ�p�����[�^�̏����𖞂������㗚���Ɖ����߂��܂�
        /// </summary>
        /// <param name="salHisRefExtraParamWork">�����p�����[�^</param>
        /// <param name="retTotalCnt">�����Ώۑ�����</param>
        /// <param name="readMode">�����敪(���g�p)</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�ۗ��f�[�^�̂� 3:���S�폜�f�[�^�̂� 4:�S�� 5:���K�f�[�^+�폜�f�[�^ 6:���K�f�[�^+�폜�f�[�^+�ۗ��f�[�^)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�p�����[�^�̏����𖞂�������f�[�^������߂��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.10.04</br>
        int SearchCount(object salHisRefExtraParamWork, out int retTotalCnt, int readMode, ConstantManagement.LogicalMode logicalMode);
        */
        #endregion
    }
}
