//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �ԕi�s�ݒ�
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Collections;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    ///�ԕi�s�ݒ�pDB Access RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԕi�s�ݒ�pDB Access RemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.04.02</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsNotReturnProcDB
    {
        /// <summary>
        /// �ԕi�s�ݒ�f�[�^��������
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="salesSlipNum">�����p�����[�^</param>
        /// <param name="goodsNotReturnList">��������</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԕi�s�ݒ�f�[�^������������</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.20</br>
        [MustCustomSerialization]
        int ReadDBData(
            string enterpriseCodes,
            string salesSlipNum,
            [CustomSerializationMethodParameterAttribute("PMKHN09507D", "Broadleaf.Application.Remoting.ParamData.GoodsNotReturnWork")]
            out ArrayList goodsNotReturnList,
            out string retMessage);

        /// <summary>
        /// �ԕi�s�ݒ�f�[�^�X�V
        /// </summary>
        /// <param name="goodsNotReturnList">�X�V�f�[�^</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ԕi�s�ݒ�f�[�^�X�V����</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.20</br>
        [MustCustomSerialization]
        int UpdateReturnUpper(
            [CustomSerializationMethodParameterAttribute("PMKHN09507D", "Broadleaf.Application.Remoting.ParamData.GoodsNotReturnWork")]
            ref ArrayList goodsNotReturnList,
            out string retMessage);
    }
}
