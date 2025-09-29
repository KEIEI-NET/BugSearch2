//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �s�a�n���o��
// �v���O�����T�v   : �s�a�n���o�� RemoteObject�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270029-00   �쐬�S�� : ������
// �� �� �� : 2016/05/20    �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary> 
    /// �s�a�n���o��DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �s�a�n���o��DB�C���^�[�t�F�[�X�ł�.</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2016/05/20</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ITBODataExportDB
    {
        /// <summary>
        /// �s�a�n���o�͏�񃊃X�g�̎擾����
        /// </summary>
        /// <param name="TBOExportResultWork">TBO�f�[�^����</param>
        /// <param name="TBODataExportCond">�����p�����[�^</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �s�a�n���o�͏�񃊃X�g(TBO�f�[�^)���擾���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2016/05/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchTBOData(
            [CustomSerializationMethodParameterAttribute("PMKHN09518D", "Broadleaf.Application.Remoting.ParamData.TBODataExportResultWork")]
            out object TBOExportResultWork,
            object TBODataExportCond,
            out string errMessage);
    }
}
