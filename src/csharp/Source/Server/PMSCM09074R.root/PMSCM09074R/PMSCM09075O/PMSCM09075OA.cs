//********************************************************************//
// System           :   PM.NS                                         //
// Sub System       :                                                 //
// Program name     :   ����A�g�ݒ�RemoteObject�C���^�[�t�F�[�X      //
//                  :   PMSCM09075O.DLL                               //
// Name Space       :   Broadleaf.Application.Remoting                //
// Programmer       :   gaoy                                          //
// Date             :   2011.07.23                                    //
//--------------------------------------------------------------------//
// Update Note      :                                                 //
//--------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.               //
//********************************************************************//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ����A�g�ݒ�RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����A�g�ݒ�RemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : gaoy</br>
    /// <br>Date       : 2011.07.25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPM7RkSettingDB
    {

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̔���A�g�ݒ��߂��܂�
        /// </summary>
        /// <param name="pm7RkSettingWork">PM7RkSettingWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̔���A�g�ݒ��߂��܂�</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.25</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMSCM09076D", "Broadleaf.Application.Remoting.ParamData.PM7RkSettingWork")]
            ref ArrayList pm7RkSettingWork,
            Int32 readMode);

        /// <summary>
        /// ����A�g�ݒ���̓o�^�A�X�V
        /// </summary>
        /// <param name="parabyte">PM7RkSettingWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ����A�g�ݒ����o�^�A�X�V���܂�</br>
        /// <br>Programmer : gaoy</br>
        /// <br>Date       : 2011.07.25</br>
        /// </remarks>
        int Write(ref byte[] parabyte);

    }
}