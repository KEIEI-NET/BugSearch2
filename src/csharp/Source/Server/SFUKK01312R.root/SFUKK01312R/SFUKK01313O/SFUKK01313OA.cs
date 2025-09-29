using System;
using System.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ����KINGET���oDB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����KINGET���oDB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 18023 ����@����</br>
    /// <br>Date       : 2005.07.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface ISeiKingetDB
    {
		#region �������z���擾Read
		/// <summary>
		/// �������z���擾����
		/// </summary>
		/// <param name="objKingetCustDmdPrcWorkList">KINGET�p���Ӑ搿�����z��񃊃X�g</param>
		/// <param name="enterpriceCode">��ƃR�[�h</param>
		/// <param name="addUpSecCode">�v�㋒�_�R�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <param name="readDate">�擾���t</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���Ӑ搿�����z�}�X�^DB���p�����[�^�̏����Ńf�[�^���擾���Ԃ��܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		[MustCustomSerialization]
		int Read(
			[CustomSerializationMethodParameterAttribute("SFUKK01314D","Broadleaf.Application.Remoting.ParamData.KingetCustDmdPrcWork")]
			out object objKingetCustDmdPrcWorkList,
			string enterpriceCode,
			string addUpSecCode,
			int customerCode,
			int readDate);
		#endregion
		
		#region �������z���擾Search
		/// <summary>
		/// �������z���擾����
		/// </summary>
		/// <param name="objKingetCustDmdPrcWorkList">KINGET�p���Ӑ搿�����z��񃊃X�g</param>
		/// <param name="objSeiKingetParameter">�����p�����[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���Ӑ搿�����z�}�X�^DB��茟���p�����[�^�̏����Ńf�[�^���擾���Ԃ��܂��B
		///					 �܂��A�Ώ۔͈͂Ńf�[�^�����݂��Ȃ��ꍇ�͉��z�ō쐬������ŕԂ��܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFUKK01314D","Broadleaf.Application.Remoting.ParamData.KingetCustDmdPrcWork")]
			out object objKingetCustDmdPrcWorkList,
			object objSeiKingetParameter);
		#endregion
		
		#region �������z���擾�i�����j
		/// <summary>
		/// �������z���擾����
		/// </summary>
		/// <param name="objKingetCustDmdPrcWorkList">KINGET�p���Ӑ搿�����z��񃊃X�g</param>
		/// <param name="objDmdSalesWorkList">���������񃊃X�g</param>
		/// <param name="objDepsitMainWorkList">������񃊃X�g</param>
		/// <param name="objSeiKingetParameter">�����p�����[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���Ӑ搿�����z�}�X�^DB��茟���p�����[�^�̏����Ńf�[�^���擾���Ԃ��܂��B
		///					 �܂��A�Ώ۔͈͂Ńf�[�^�����݂��Ȃ��ꍇ�͉��z�ō쐬������ŕԂ��܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFUKK01314D","Broadleaf.Application.Remoting.ParamData.KingetCustDmdPrcWork")]
			out object objKingetCustDmdPrcWorkList,
			[CustomSerializationMethodParameterAttribute("SFUKK01342D","Broadleaf.Application.Remoting.ParamData.DmdSalesWork")]
			out object objDmdSalesWorkList,
			[CustomSerializationMethodParameterAttribute("SFUKK01343D","Broadleaf.Application.Remoting.ParamData.DepsitMainWork")]
			out object objDepsitMainWorkList,
			object objSeiKingetParameter);
		#endregion
		
		#region �������z���擾�i�����ꊇ�j
		/// <summary>
		/// �������z���擾����(�����ꊇ����p)
		/// </summary>
		/// <param name="objKingetCustDmdPrcWorkList">KINGET�p���Ӑ搿�����z��񃊃X�g</param>
		/// <param name="objDmdSalesWorkList">���������񃊃X�g</param>
		/// <param name="objDepsitMainWorkList">������񃊃X�g</param>
		/// <param name="objSeiKingetParameter">�����p�����[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���Ӑ搿�����z�}�X�^DB��茟���p�����[�^�̏����Ńf�[�^���擾���Ԃ��܂��B
		///					 �܂��A�Ώ۔͈͂Ńf�[�^�����݂��Ȃ��ꍇ�͉��z�ō쐬������ŕԂ��܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		[MustCustomSerialization]
		int SearchMotoAll(
			[CustomSerializationMethodParameterAttribute("SFUKK01314D","Broadleaf.Application.Remoting.ParamData.KingetCustDmdPrcWork")]
			out object objKingetCustDmdPrcWorkList,
			[CustomSerializationMethodParameterAttribute("SFUKK01342D","Broadleaf.Application.Remoting.ParamData.DmdSalesWork")]
			out object objDmdSalesWorkList,
			[CustomSerializationMethodParameterAttribute("SFUKK01343D","Broadleaf.Application.Remoting.ParamData.DepsitMainWork")]
			out object objDepsitMainWorkList,
			object objSeiKingetParameter);
		#endregion
		
		#region �������z���擾�i���ׁj
		/// <summary>
		/// �������z���׏��擾����
		/// </summary>
		/// <param name="objDmdSalesWorkList">���������񃊃X�g</param>
		/// <param name="objDepsitMainWorkList">������񃊃X�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="objSeiKingetDetailParameterList">���׌����p�����[�^���X�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���׌����p�����[�^���X�g�̏����Ő�������f�[�^�Ɠ����f�[�^���擾���Ԃ��܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		[MustCustomSerialization]
		int SearchDetails(
			[CustomSerializationMethodParameterAttribute("SFUKK01342D","Broadleaf.Application.Remoting.ParamData.DmdSalesWork")]
			out object objDmdSalesWorkList,
			[CustomSerializationMethodParameterAttribute("SFUKK01343D","Broadleaf.Application.Remoting.ParamData.DepsitMainWork")]
			out object objDepsitMainWorkList,
			string enterpriseCode,
			object objSeiKingetDetailParameterList);
		#endregion
		
		#region ���Ӑ搿�����v�c���`�F�b�N
		/// <summary>
		/// ���Ӑ搿�����v�c���`�F�b�N����
		/// </summary>
		/// <param name="enterpriceCode">��ƃR�[�h</param>
		/// <param name="customerCode">���Ӑ�R�[�h</param>
		/// <returns>0:�������v�c�����O�~�������͎������, 1:�������v�c�����O�~</returns>
		/// <br>Note       : �w�蓾�Ӑ�R�[�h�̓��Ӑ搿�����z�}�X�^�̍ŏI���R�[�h�̐������v�c�����`�F�b�N���܂��B</br>
		/// <br>Programmer : 18023 ����@����</br>
		/// <br>Date       : 2005.07.21</br>
		int CheckDemandPrice(string enterpriceCode, int customerCode);
		#endregion
	}
}

