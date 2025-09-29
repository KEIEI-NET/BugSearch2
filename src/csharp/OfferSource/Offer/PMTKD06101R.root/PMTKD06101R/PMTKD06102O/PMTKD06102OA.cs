using System;
using System.Collections;
using Broadleaf.Library.Resources;
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
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_OfferAP)]  // �A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
    public interface ICarModelCtlDB
    {

		/// <summary>
		/// �G���W���^������
		/// </summary>
        /// <param name="carModelCondWork"></param>
        /// <param name="carModelRetList"></param>
        /// <param name="KindList"></param>
        /// <param name="colorCdRetWork"></param>
        /// <param name="trimCdRetWork"></param>
        /// <param name="cEqpDefDspRetWork"></param>
        /// <param name="prdTypYearRetWork"></param>
		/// <returns></returns>
		[MustCustomSerialization]
		int GetCarEngine(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarModelRetWork")]
			out ArrayList carModelRetList,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork")]
			out ArrayList KindList,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.ColorCdRetWork")]
			out ArrayList colorCdRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.TrimCdRetWork")]
			out ArrayList trimCdRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CEqpDefDspRetWork")]
			out ArrayList cEqpDefDspRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.PrdTypYearRetWork")]
			out ArrayList prdTypYearRetWork
			);

        /// <summary>
        /// �^���������\�b�h
        /// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <param name="KindList"></param>
        /// <param name="colorCdRetWork"></param>
        /// <param name="trimCdRetWork"></param>
        /// <param name="cEqpDefDspRetWork"></param>
        /// <param name="prdTypYearRetWork"></param>
        /// <param name="ctgyMdlLnkRetWork"></param>
        /// <returns></returns>
		[MustCustomSerialization]
		int GetCarModel(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarModelRetWork")]
			out ArrayList carModelRetList,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork")]
			out ArrayList KindList,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.ColorCdRetWork")]
			out ArrayList colorCdRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.TrimCdRetWork")]
			out ArrayList trimCdRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CEqpDefDspRetWork")]
			out ArrayList cEqpDefDspRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.PrdTypYearRetWork")]
			out ArrayList prdTypYearRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CtgyMdlLnkRetWork")]
			out ArrayList ctgyMdlLnkRetWork
			);

		/// <summary>
		/// �ޕʌ^���������\�b�h
		/// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <param name="KindList"></param>
        /// <param name="colorCdRetWork"></param>
        /// <param name="trimCdRetWork"></param>
        /// <param name="cEqpDefDspRetWork"></param>
        /// <param name="prdTypYearRetWork"></param>
        /// <param name="categoryEquipmentRetWork"></param>
        /// <param name="equipmentRetWork"></param>
		/// <returns></returns>
		[MustCustomSerialization]
		int GetCarCtgyMdl(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarModelRetWork")]
			out ArrayList carModelRetList,
		    [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork")]
			out ArrayList KindList,
		    [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.ColorCdRetWork")]
			out ArrayList colorCdRetWork,
		    [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.TrimCdRetWork")]
			out ArrayList trimCdRetWork,
		    [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CEqpDefDspRetWork")]
			out ArrayList cEqpDefDspRetWork,
		    [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.PrdTypYearRetWork")]
			out ArrayList prdTypYearRetWork,
		    [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CategoryEquipmentRetWork")]
			out ArrayList categoryEquipmentRetWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CtgryEquipWork")]
            out ArrayList equipmentRetWork
			);

		/// <summary>
		/// �R�[�V�����v���[�g�������\�b�h
		/// </summary>
        /// <param name="carModelCondWork">�ԗ���������</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <param name="KindList"></param>
        /// <param name="colorCdRetWork"></param>
        /// <param name="trimCdRetWork"></param>
        /// <param name="cEqpDefDspRetWork"></param>
        /// <param name="prdTypYearRetWork"></param>
		/// <returns></returns>
		[MustCustomSerialization]
		int GetCarPlate(CarModelCondWork carModelCondWork,
			[CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarModelRetWork")]
			out ArrayList carModelRetList,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork")]
			out ArrayList KindList,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.ColorCdRetWork")]
			out ArrayList colorCdRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.TrimCdRetWork")]
			out ArrayList trimCdRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CEqpDefDspRetWork")]
			out ArrayList cEqpDefDspRetWork,
		   [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.PrdTypYearRetWork")]
			out ArrayList prdTypYearRetWork
			);

        /// <summary>
        /// �t���^���Œ�ԍ��������\�b�h
        /// </summary>
        /// <param name="carModelCondWork">��������</param>
        /// <param name="carModelRetList">��������(�^�����X�g)</param>
        /// <param name="kindList">�ԗ��^��</param>
        /// <param name="colorCdRetWork">�J���[�R�[�h</param>
        /// <param name="trimCdRetWork">�g�����R�[�h</param>
        /// <param name="cEqpDefDspRetWork">�����R�[�h</param>
        /// <param name="prdTypYearRetWork">�N��</param>
        /// <param name="ctgyMdlLnkRetWork">�s�a�n</param>
        /// <param name="categoryEquipmentRetWork"></param>
        /// <param name="equipmentRetWork"></param>
        /// <returns></returns>
        [MustCustomSerialization]
        int GetCarFullModelNo(CarModelCondWork carModelCondWork,
            [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarModelRetWork")]
            out ArrayList carModelRetList,
           [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CarKindInfoWork")]
            out ArrayList kindList,
            [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.ColorCdRetWork")]
			out ArrayList colorCdRetWork,
           [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.TrimCdRetWork")]
			out ArrayList trimCdRetWork,
           [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CEqpDefDspRetWork")]
			out ArrayList cEqpDefDspRetWork,
           [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.PrdTypYearRetWork")]
			out ArrayList prdTypYearRetWork,
           [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CtgyMdlLnkRetWork")]
			out ArrayList ctgyMdlLnkRetWork,
           [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CategoryEquipmentRetWork")]
			out ArrayList categoryEquipmentRetWork,
           [CustomSerializationMethodParameterAttribute("PMTKD06103D", "Broadleaf.Application.Remoting.ParamData.CtgryEquipWork")]
            out ArrayList equipmentRetWork
            );
	}
}
