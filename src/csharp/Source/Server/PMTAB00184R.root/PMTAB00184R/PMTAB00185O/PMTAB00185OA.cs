//****************************************************************************//
// �V�X�e��         �FPM.NS                                                   //
// �v���O��������   �FPMTAB�A�b�v���[�h�r�����䌟���}�X�^DBRemote  Interface  //
// �v���O�����T�v   �FPMTAB�A�b�v���[�h�r�����䌟���}�X�^DBRemote  Interface  //
// ---------------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				      //
// ===========================================================================//
// ����                                                                       //
// ---------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �A����                                    //
// �� �� ��  2013/06/24  �쐬���e : �V�K�쐬                                  //
// ---------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using System.Data.SqlClient;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// PMTAB�A�b�v���[�h�r�����䌟���}�X�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : PMTAB�A�b�v���[�h�r�����䌟���}�X�^DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : �A���� </br>
	/// <br>Date       : 2013/06/24</br>
    /// <br></br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPmTabUpldExclsvDB
	{
         /// <summary>
        /// �w�肳�ꂽPM�A�b�v���[�h�r������Guid��PM�A�b�v���[�h�r�������߂��܂�
        /// </summary>
        /// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : �A����</br>
        /// <br>Date       : 2013/06/24</br>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMTAB00186D", "Broadleaf.Application.Remoting.ParamData.PmTabUpldExclsvWork")]
			ref object parabyte,
            int readMode);

        /// <summary>
        /// �A�b�v���[�h�r���������o�^�A�X�V���܂�
        /// </summary>
        /// <param name="paraobj">WorkerWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : �A����</br>
        /// <br>Date       : 2013/06/24</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMTAB00186D", "Broadleaf.Application.Remoting.ParamData.PmTabUpldExclsvWork")]
            ref object paraobj);

        /// <summary>
        /// �A�b�v���[�h�r������𕨗��폜���܂�
        /// </summary>
        /// <param name="paraobj">PmTabTtlStSecWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �A�b�v���[�h�r������𕨗��폜���܂�</br>
        /// <br>Programmer : �A����</br>
        /// <br>Date       : 2013/06/24</br>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMTAB00186D", "Broadleaf.Application.Remoting.ParamData.PmTabUpldExclsvWork")]
            ref object paraobj);
	}
}
