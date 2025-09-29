using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �ԗ��^������ RemoteObject �C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ԗ��^������ RemoteObject Interface �ł��B</br>
    /// <br>Programmer : 96186�@���ԁ@�T��</br>
    /// <br>Date       : 2007.03.09</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]  // �A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
    public interface ICarModelSearchDB
    {
        /// <summary>
        /// �Ԏ팟���������^��������
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="KindList">��������(�Ԏ탊�X�g)</param>
        /// <returns>DB Status</returns>
		[MustCustomSerialization]
		int GetCarKindModel(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork")]
			out ArrayList KindList);

        /// <summary>
        /// �Ԏ팟���������G���W���^��������
        /// </summary>
        /// <param name="carModelCondWork"></param>
        /// <param name="KindList">��������(�Ԏ탊�X�g)</param>
        /// <returns>DB Status</returns>
		[MustCustomSerialization]
		int GetCarKindEngine(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork")]
			out ArrayList KindList);

        /// <summary>
        /// �Ԏ팟���������ޕʌ^��������
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="KindList">��������(�^�����X�g)</param>
        /// <returns>DB Status</returns>
		[MustCustomSerialization]
		int GetCarKindCtgyMdl(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork")]
			out ArrayList KindList);

        /// <summary>
        /// �Ԏ팟���������v���[�g������
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="KindList">��������(�Ԏ탊�X�g)</param>
        /// <returns>DB Status</returns>
		[MustCustomSerialization]
		int GetCarKindlPlate(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork")]
			out ArrayList KindList);

        /// <summary>
        /// �G���W���^����������
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <returns>DB Status</returns>
		[MustCustomSerialization]
		int GetCarEngineSearch(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarModelRetWork")]
			out ArrayList carModelRetList);

        /// <summary>
        /// �^����������
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <returns>DB Status</returns>
		[MustCustomSerialization]
		int GetCarModelSearch(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarModelRetWork")]
			out ArrayList carModelRetList);

        /// <summary>
        /// �ޕʌ^����������
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <returns>DB Status</returns>
		[MustCustomSerialization]
		int GetCarCtgyMdlSearch(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarModelRetWork")]
			out ArrayList carModelRetList);

        /// <summary>
        /// �v���[�g��������
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <returns>DB Status</returns>
		[MustCustomSerialization]
		int GetCarPlateSearch(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarModelRetWork")]
			out ArrayList carModelRetList);
	}
}
