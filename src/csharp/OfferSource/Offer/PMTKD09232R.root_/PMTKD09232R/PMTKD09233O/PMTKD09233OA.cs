//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j
// �v���O�����T�v   : ���R�����h���i�֘A�ݒ�}�X�^�i�񋟁jDB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� �B
// �� �� ��  2015.01.16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���R�����h���i�֘A�ݒ�}�X�^�i�񋟁jDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�����h���i�֘A�ݒ�}�X�^�i�񋟁jDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : �� �B</br>
    /// <br>Date       : 2015.01.16</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]
    public interface IRecGoodsLkODB
    {
        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j��������
        /// </summary>
        /// <param name="RecGoodsLkOWorkList">���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j�f�[�^���X�g</param>
        /// <param name="parseRecGoodsLkOWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        //[MustCustomSerialization]
        int Search(
            //[CustomSerializationMethodParameterAttribute("PMTKD09234D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkOWork")]
            out object RecGoodsLkOWorkList, 
            RecGoodsLkOWork parseRecGoodsLkOWork, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j��������
        /// </summary>
        /// <param name="RecGoodsLkOWorkList">���R�����h���i�֘A�ݒ�}�X�^�i�񋟁j�f�[�^���X�g</param>
        /// <param name="readMode">�����敪(���ݖ��g�p)</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : �� �B</br>
        /// <br>Date       : 2015.01.16</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMTKD09234D", "Broadleaf.Application.Remoting.ParamData.RecGoodsLkOWork")]
            ref object RecGoodsLkOWorkList, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode);
    }
}