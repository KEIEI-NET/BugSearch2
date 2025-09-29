//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : S&E����f�[�^�e�L�X�g�o��
// �v���O�����T�v   : S&E����f�[�^�e�L�X�g�o�͒��[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���M
// �� �� ��  2009/08/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �c����  
// �C �� ��  2013/06/26  �C�����e : ���M���O�̓o�^
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
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
    /// <br>Programmer : ���M</br>
    /// <br>Date       : 2009.08.05</br>
    /// <br></br>
    /// <br>UpdateNote : 2013/06/26 �c����</br>
    /// <br>           : ���M���O�̓o�^</br>
    /// <br>Update Note: </br>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalesHistoryJoinWorkDB
    {
        /// <summary>
        /// ����f�[�^�e�L�X�g��񃊃X�g�̎擾�����B
        /// </summary>
        /// <param name="salesHistoryResultWork">��������</param>
        /// <param name="salesHistoryCndtnWork">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SE����f�[�^�e�L�X�g�̃L�[�l����v����A�S�Ă�SE����f�[�^�e�L�X�g�����擾���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMSAE02016D", "Broadleaf.Application.Remoting.ParamData.SalesHistoryJoinWork")]
            out object salesHistoryResultWork,
            object salesHistoryCndtnWork);

        /// <summary>
        /// SE����f�[�^�e�L�X�g���̒ǉ��E�X�V�����B
        /// </summary>
        /// <param name="objectsalesHistoryJoinWork">�ǉ��E�X�V����SE����f�[�^�e�L�X�g���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SAndEGoodsCdChgWork �Ɋi�[����Ă���SE����f�[�^�e�L�X�g����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.08.05</br>
        [MustCustomSerialization]
        int Write([CustomSerializationMethodParameterAttribute("PMSAE02016D", "Broadleaf.Application.Remoting.ParamData.SalesHistoryJoinWork")]
            ref object objectsalesHistoryJoinWork);

        // ----- ADD �c���� 2013/06/26 ----->>>>>
        /// <summary>
        /// SE����f�[�^�e�L�X�g���M���O���̓o�^�����B
        /// </summary>
        /// <param name="objectSAndESalSndLogWork">�o�^����SE����f�[�^�e�L�X�g���M���O���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : objectSAndESalSndLogWork �Ɋi�[����Ă���SE����f�[�^�e�L�X�g���M���O����o�^���܂��B</br>
        /// <br>Programmer : �c����</br>
        /// <br>Date       : 2013/06/26</br>
        [MustCustomSerialization]
        int WriteLog([CustomSerializationMethodParameterAttribute("PMSAE04007D", "Broadleaf.Application.Remoting.ParamData.SAndESalSndLogListResultWork")]
            ref object objectSAndESalSndLogWork);
        // ----- ADD �c���� 2013/06/26 -----<<<<<

    }
}
