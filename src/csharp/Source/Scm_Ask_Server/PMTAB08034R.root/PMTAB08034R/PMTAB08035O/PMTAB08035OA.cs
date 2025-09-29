//**********************************************************************
// System           : PM.NS
// Sub System       :
// Program name     : PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^ RemoteObject Interface
//                  : PMTAB08035O.DLL
// Name Space       : Broadleaf.Application.Remoting
// Programmer       : 30746 ���� ��
// Date             : 2014/09/26
//----------------------------------------------------------------------
//                  (c)Copyright  2014 Broadleaf Co.,Ltd.
//**********************************************************************
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using System.Data.SqlClient;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�}�X�^ RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�}�X�^ RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 30746 ���� ��</br>
    /// <br>Date       : 2014/09/26</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    public interface IPmtGeneralSrRstDB
    {
        #region �f�[�^�敪�P
        /// <summary>
        /// �w�肳�ꂽ������PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^�����������܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2014/09/26</br>
        [MustCustomSerialization]
        int SearchForLinkDataCode1(
            [CustomSerializationMethodParameterAttribute("PMTAB08036D", "Broadleaf.Application.Remoting.ParamData.PmtGeneralSrRstWork")]
			out object retObj,
            object paraObj);

        /// <summary>
        /// �w�肳�ꂽ������PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">�R�l�N�V����</param>
        /// <param name="msgDiv">���b�Z�[�W�敪�@[True:���b�Z�[�W�L]</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^���������܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2014/09/26</br>
        [MustCustomSerialization]
        int SearchForLinkDataCode1(
            [CustomSerializationMethodParameterAttribute("PMTAB08036D", "Broadleaf.Application.Remoting.ParamData.PmtGeneralSrRstWork")]
			out object retObj,
            object paraObj,
            ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection,
            out bool msgDiv,
            out string errMsg);

        /// <summary>
        /// PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^��ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="PmtGeneralSrRstWork">�ǉ��E�X�V����PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^</param>
        /// <param name="msgDiv">���b�Z�[�W�敪�@[True:���b�Z�[�W�L]</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^��ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2014/09/26</br>
        [MustCustomSerialization]
        int WriteForLinkDataCode1(
            [CustomSerializationMethodParameterAttribute("PMTAB08036D", "Broadleaf.Application.Remoting.ParamData.PmtGeneralSrRstWork")]
            ref object paraList,
            out bool msgDiv,
            out string errMsg);

        /// <summary>
        /// PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^���폜���܂��B
        /// </summary>
        /// <param name="PmtGeneralSrRstWork">�폜����PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^</param>
        /// <param name="msgDiv">���b�Z�[�W�敪�@[True:���b�Z�[�W�L]</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�ėp�������ʃZ�b�V�����Ǘ��g�����U�N�V�����f�[�^���폜���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2014/09/26</br>
        [MustCustomSerialization]
        int DeleteForLinkDataCode1(
            [CustomSerializationMethodParameterAttribute("PMTAB08036D", "Broadleaf.Application.Remoting.ParamData.PmtGeneralSrRstWork")]
            ref object paraList,
            out bool msgDiv,
            out string errMsg);
    }
    #endregion �f�[�^�敪�P
}
