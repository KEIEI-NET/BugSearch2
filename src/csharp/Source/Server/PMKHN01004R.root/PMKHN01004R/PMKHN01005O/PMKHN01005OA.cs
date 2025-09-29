//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^�N���A����
// �v���O�����T�v   : �f�[�^�N���A����DB RemoteObject�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/06/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �f�[�^�N���A����DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �f�[�^�N���A����DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.06.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IDataClearDB
    {
        #region �f�[�^�N���A�����̎��s����
        /// <summary>
        /// �f�[�^�N���A�������s��
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="delYM">�폜�N��</param>
        /// <param name="delYMD">�폜�N���J�n��</param>
        /// <param name="dataClearList">�f�[�^�N���A���X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.16</br>
        [MustCustomSerialization]
        int Clear(
            string enterpriseCode,
            Int32 delYM,
            Int32 delYMD,
            [CustomSerializationMethodParameterAttribute("PMKHN01006D", "Broadleaf.Application.Remoting.ParamData.DataClearWork")]
            ref object dataClearList,
            out string errMsg);
        #endregion

        #region �����R�[�h��9�F���i���������f�[�^�N���A�i�񋟃f�[�^�폜�����p�j
        /// <summary>
        /// �����R�[�h��9�F���i���������f�[�^�N���A�i�񋟃f�[�^�폜�����p�j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����R�[�h��9�F���i���������f�[�^�N���A�̏����i�񋟃f�[�^�폜�����p�j</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.06.18</br>
        int ClearDataByCode9(string enterpriseCode);
        #endregion
    }
}
