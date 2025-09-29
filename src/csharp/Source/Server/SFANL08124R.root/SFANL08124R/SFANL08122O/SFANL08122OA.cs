using System;
using System.Text;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���R���[�󎚍���DBRemoteObject�C���^�[�t�F�[�X	
	/// </summary>
	/// <remarks>
	/// <br>Note		: ���R���[�󎚍��� RemoteObject Interface�ł��B</br>
	/// <br>Programmer	: 22024 ����@�_�u</br>
	/// <br>Date		: 2007.05.10</br>
	/// <br></br>
	/// <br>Update Note	: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface IFrePrtPSetDB
	{
		/// <summary>
		/// ���O�o�͏���
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="employeeCode">�]�ƈ��R�[�h</param>
		/// <param name="logMessage">���O���b�Z�[�W</param>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ���O���b�Z�[�W��ۑ����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		void WriteLog(string enterpriseCode, string employeeCode, string logMessage);

		/// <summary>
		/// �ŏI���[�U�[���[ID�}�ԍ��擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="outputFormFileName">�o�̓t�@�C����</param>
		/// <returns>�ŏI���[�U�[���[ID�}�ԍ�</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ���R���[�󎚈ʒu���̍ŏI�}�ԍ����擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		int GetLastUserPrtPprIdDerivNo(string enterpriseCode, string outputFormFileName);

			/// <summary>
		/// ���R���[���o�������׃}�X�^�擾�����i�S���j
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="frePExCndDWorkArray">���R���[���o�������׃��[�N�}�X�^�z��</param>
		/// <param name="msgDiv">���b�Z�[�W�敪</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: ���R���[���o�������׃��[�N�}�X�^�z���S���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		[MustCustomSerialization]
		int SearchFrePExCndD(
			string enterpriseCode,
			ConstantManagement.LogicalMode logicalMode,
			[CustomSerializationMethodParameterAttribute("SFANL08123D", "Broadleaf.Application.Remoting.ParamData.FrePExCndDWork")]
			out object frePExCndDWorkArray,
			out bool msgDiv,
			out string errMsg
			);

		/// <summary>
		/// ���R���[�󎚈ʒu���擾����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="outputFormFileName">�o�̓t�@�C����</param>
		/// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
		/// <param name="retCustomSerializeArrayList">���R���[�󎚈ʒu���J�X�^���V���A���C�YLIST</param>
		/// <param name="printPosClassData">�󎚈ʒu�f�[�^</param>
		/// <param name="msgDiv">���b�Z�[�W�敪</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ���R���[�󎚈ʒu�����擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		[MustCustomSerialization]
		int Read(
			string enterpriseCode,
			string outputFormFileName,
			int userPrtPprIdDerivNo,
			[CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object retCustomSerializeArrayList,
			out byte[] printPosClassData,
			out bool msgDiv,
			out string errMsg
			);

		/// <summary>
		/// ���R���[���ڐݒ�}�X�^��������
		/// </summary>
		/// <param name="saveCustomSerializeArrayList">���R���[�󎚈ʒu���J�X�^���V���A���C�YLIST</param>
		/// <param name="printPosClassData">�󎚈ʒu�f�[�^</param>
		/// <param name="isNewWrite">�V�K�o�^</param>
		/// <param name="msgDiv">���b�Z�[�W�敪</param>
		/// <param name="errMsg">�G���[���b�Z�[�W</param>
		/// <returns>�X�e�[�^�X</returns>
		/// <remarks>
		/// <br>Note		: �w�肳�ꂽ���R���[�󎚈ʒu����o�^���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2007.05.10</br>
		/// </remarks>
		[MustCustomSerialization]
		int Write(
			[CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object saveCustomSerializeArrayList,
			byte[] printPosClassData,
			bool isNewWrite,
			out bool msgDiv,
			out string errMsg
			);
	}
}
