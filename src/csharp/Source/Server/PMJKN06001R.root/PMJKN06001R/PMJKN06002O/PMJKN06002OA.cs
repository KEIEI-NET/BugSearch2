using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���R�����^������ RemoteObject �C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���R�����^������ RemoteObject Interface �ł��B</br>
    /// <br>Programmer : 22018�@��ؐ��b</br>
    /// <br>Date       : 2010/04/19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]  // �A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
    public interface IFreeSearchModelSearchDB
    {
        /// <summary>
        /// �^����������
        /// </summary>
        /// <param name="FreeSearchModelSCndtnWork">�ԗ���������</param>
        /// <param name="KindList">��������(�Ԏ탊�X�g)</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <returns>DB Status</returns>
        [MustCustomSerialization]
        int GetCarModel( FreeSearchModelSCndtnWork FreeSearchModelSCndtnWork,
			[CustomSerializationMethodParameterAttribute("PMJKN06003D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelSCarKindInfoWork")]
			out ArrayList KindList,
            [CustomSerializationMethodParameterAttribute( "PMJKN06003D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelSRetWork" )]
			out ArrayList carModelRetList );

        /// <summary>
        /// �ޕʌ^����������
        /// </summary>
        /// <param name="FreeSearchModelSCndtnWork">�ԗ���������</param>
        /// <param name="KindList">��������(�Ԏ탊�X�g)</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <returns>DB Status</returns>
        [MustCustomSerialization]
        int GetCarCtgyMdl( FreeSearchModelSCndtnWork FreeSearchModelSCndtnWork,
            [CustomSerializationMethodParameterAttribute( "PMJKN06003D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelSCarKindInfoWork" )]
			out ArrayList KindList,
            [CustomSerializationMethodParameterAttribute( "PMJKN06003D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelSRetWork" )]
			out ArrayList carModelRetList );

        /// <summary>
        /// �G���W���^����������
        /// </summary>
        /// <param name="FreeSearchModelSCndtnWork">�ԗ���������</param>
        /// <param name="KindList">��������(�Ԏ탊�X�g)</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <returns>DB Status</returns>
        [MustCustomSerialization]
        int GetCarEngine( FreeSearchModelSCndtnWork FreeSearchModelSCndtnWork,
            [CustomSerializationMethodParameterAttribute( "PMJKN06003D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelSCarKindInfoWork" )]
			out ArrayList KindList,
            [CustomSerializationMethodParameterAttribute( "PMJKN06003D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelSRetWork" )]
			out ArrayList carModelRetList );

        /// <summary>
        /// ���R�����^���Œ�ԍ���������
        /// </summary>
        /// <param name="FreeSearchModelSCndtnWork">�ԗ���������</param>
        /// <param name="KindList">��������(�Ԏ탊�X�g)</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <returns>DB Status</returns>
        [MustCustomSerialization]
        int GetCarFullModelNo( FreeSearchModelSCndtnWork FreeSearchModelSCndtnWork,
            [CustomSerializationMethodParameterAttribute( "PMJKN06003D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelSCarKindInfoWork" )]
			out ArrayList KindList,
            [CustomSerializationMethodParameterAttribute( "PMJKN06003D", "Broadleaf.Application.Remoting.ParamData.FreeSearchModelSRetWork" )]
			out ArrayList carModelRetList );
    }
}
