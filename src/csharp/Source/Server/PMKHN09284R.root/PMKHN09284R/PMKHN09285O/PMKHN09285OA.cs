//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �a�k�R�[�h�w�ʕϊ�����
// �v���O�����T�v   : �a�k�R�[�h�w�ʕϊ�����DB RemoteObject�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2010/01/12  �C�����e : �V�K�쐬
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
    /// �a�k�R�[�h�w�ʕϊ�����DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �a�k�R�[�h�w�ʕϊ�����DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2010/01/12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IDataBLGoodsRateRankConvertDB
    {
        #region �a�k�R�[�h�w�ʕϊ������̎��s����
        /// <summary>
        /// �a�k�R�[�h�w�ʕϊ��������s��
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="excellentSetFile_A">�D�ǐݒ�p�����[�^���X�g�`</param>
        /// <param name="excellentSetFile_B">�D�ǐݒ�p�����[�^���X�g�a</param>
        /// <param name="excellentSetFile_C">�D�ǐݒ�p�����[�^���X�g�b</param>
        /// <param name="goodsFile_A">���i�p�����[�^���X�g�`</param>
        /// <param name="goodsFile_B">���i�p�����[�^���X�g�a</param>
        /// <param name="goodsFile_C">���i�p�����[�^���X�g�b</param>
        /// <param name="partsFile">���ʃp�����[�^�̃��X�g</param>
        /// <param name="rateFile_A">�|���p�����[�^���X�g�`</param>
        /// <param name="rateFile_B">�|���p�����[�^���X�g�a</param>
        /// <param name="rateFile_C">�|���p�����[�^���X�g�b</param>
        /// <param name="retList">�������ʃ��X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2010/01/12</br>
        [MustCustomSerialization]
        int Update(
            [CustomSerializationMethodParameterAttribute("PMKHN09286D", "Broadleaf.Application.Remoting.ParamData.ResultListWork")]
            string enterpriseCode, 
            object rateFile_A,
            object rateFile_B,
            object rateFile_C,
            object goodsFile_A,
            object goodsFile_B,
            object goodsFile_C,
            object partsFile,
            object excellentSetFile_A,
            object excellentSetFile_B,
            object excellentSetFile_C,
            out object retList,
            out string errMsg);
        #endregion
    }
}
