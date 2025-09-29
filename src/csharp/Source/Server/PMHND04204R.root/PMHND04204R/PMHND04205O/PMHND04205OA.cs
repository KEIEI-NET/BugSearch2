//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �n���f�B�^�[�~�i�����i�Ɖ���[�g�I�u�W�F�N�g �C���^�[�t�F�[�X
// �v���O�����T�v   : �n���f�B�^�[�~�i�����i�Ɖ�RemoteObject Interface�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : ���O
// �� �� ��  2017/07/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470154-00 �쐬�S�� : ���O                              
// �C �� ��  2018/10/16  �C�����e : �n���f�B�^�[�~�i���܎��Ή�
//                                  ����@�\�ƃe�L�X�g�o�͋@�\�̒ǉ�
//----------------------------------------------------------------------------//

using System;
using System.Collections;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �n���f�B�^�[�~�i�����i�Ɖ���[�g�I�u�W�F�N�g �C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       :�n���f�B�^�[�~�i�� ���i�Ɖ���[�g�I�u�W�F�N�g �C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2017/07/20</br>
    /// <br>Update Note: 2018/10/16 ���O</br>
    /// <br>�@�@�@�@�@ : �n���f�B�^�[�~�i���܎��Ή�</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IHandyInspectRefDataDB
    {
        #region [Search]
        /// <summary>
        /// �n���f�B�^�[�~�i�����i�Ɖ���̎擾����
        /// </summary>
        /// <param name="inspectRefDataObj">��������</param>
        /// <param name="searchCondtObj">��������</param>
        /// <param name="errMessage">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �n���f�B�^�[�~�i�����i�Ɖ�����������܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMHND04206D", "Broadleaf.Application.Remoting.ParamData.InspectRefDataWork")]
           out object inspectRefDataObj,
           object searchCondtObj,
           out string errMessage);
        #endregion

        #region [���i�K�C�h�f�[�^����]
        /// <summary>
        /// ���i�K�C�h�f�[�^����
        /// </summary>
        /// <param name="paraInspectDataWork">�����p�����[�^</param>
        /// <param name="inspectDataObj">��������</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�K�C�h�f�[�^���擾���܂�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchGuid(
            object paraInspectDataWork,
            [CustomSerializationMethodParameterAttribute("PMHND00213D", "Broadleaf.Application.Remoting.ParamData.HandyInspectDataWork")]
            out object inspectDataObj);
        #endregion

        #region [��������]
        /// <summary>
        /// �����f�[�^����
        /// </summary>
        /// <param name="deleteDataObj">��s���i�f�[�^�����폜�f�[�^</param>
        /// <param name="insertDataObj">���i�f�[�^</param>
        /// <param name="Type">0:�蓮���i�f�[�^�o�^����,1:��s���i�����o�^����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����f�[�^�������s���B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        [MustCustomSerialization]
         int WriteInspectData(
            object deleteDataObj,
            object insertDataObj,
            int Type);
        #endregion

        // --- ADD ���O 2018/10/16 �n���f�B�^�[�~�i���܎��Ή�---------->>>>>
        #region [�폜����]
        /// <summary>
        /// ���i�f�[�^�폜����
        /// </summary>
        /// <param name="delInspectDataObj">���i�f�[�^</param>
         /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�f�[�^�폜�������s���B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2019/10/16</br>
        /// </remarks>
        [MustCustomSerialization]
        int DeleteInspectData(
            object delInspectDataObj,
            out string retMessage);
        #endregion
        // --- ADD ���O 2018/10/16 �n���f�B�^�[�~�i���܎��Ή�----------<<<<<
    }
}