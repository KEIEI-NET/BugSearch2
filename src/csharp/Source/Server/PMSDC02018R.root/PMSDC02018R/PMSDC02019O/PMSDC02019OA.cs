//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ����A�g�e�L�X�g�o��
// �v���O�����T�v   : ����A�g�e�L�X�g�o�͒��[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2019 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 11570219-00     �쐬�S�� : �c����
// �� �� �� 2019/12/02      �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary> ����f�[�^�e�L�X�gDB�C���^�[�t�F�[�X</summary>
    /// <br>Note       : ����f�[�^�e�L�X�gDB�C���^�[�t�F�[�X�ł�.</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date       : 2019/12/02</br>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalesCprtWorkDB
    {
        /// <summary>
        /// ����f�[�^�e�L�X�g��񃊃X�g�̎擾�����B
        /// </summary>
        /// <param name="salesCprtResultWork">��������</param>
        /// <param name="salesCprtCndtnWork">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ����A�g�e�L�X�g�̃L�[�l����v����A�S�Ă̔���A�g�e�L�X�g�����擾���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMSDC02016D", "Broadleaf.Application.Remoting.ParamData.SalesCprtWork")]
            out object salesCprtResultWork,
           object salesCprtCndtnWork);

        /// <summary>
        /// ����A�g�e�L�X�g���̒ǉ��E�X�V�����B
        /// </summary>
        /// <param name="objectSalesCprtWork">�ǉ��E�X�V���锄��A�g�e�L�X�g���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SalesCprtResultWork �Ɋi�[����Ă��锄��A�g�e�L�X�g����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMSDC02016D", "Broadleaf.Application.Remoting.ParamData.SalesCprtWork")]
            ref object objectSalesCprtWork);

        /// <summary>
        /// ����A�g�e�L�X�g���M���O���̓o�^�����B
        /// </summary>
        /// <param name="objectSalCprtSndLogWork">�o�^���锄��A�g�e�L�X�g���M���O���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : objectSalCprtSndLogWork �Ɋi�[����Ă��锄��A�g�e�L�X�g���M���O����o�^���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2019/12/02</br>
        [MustCustomSerialization]
        int WriteLog([CustomSerializationMethodParameterAttribute("PMSDC04007D", "Broadleaf.Application.Remoting.ParamData.SalCprtSndLogListResultWork")]
            ref object objectSalCprtSndLogWork);

    }
}
