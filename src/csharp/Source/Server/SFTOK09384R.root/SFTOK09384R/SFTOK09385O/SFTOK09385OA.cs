using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �]�ƈ�DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �]�ƈ�DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 96137�@�R�c�@�\</br>
	/// <br>Date       : 2005.03.17</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface IEmployeeDB
	{
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̏]�ƈ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�̏]�ƈ�LIST�̌�����߂��܂�
        /// </summary>
        /// <param name="retCnt">�Y���f�[�^����</param>
        /// <param name="paraobj">�����p�����[�^</param>		
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchCnt(
            out int retCnt,
            [CustomSerializationMethodParameterAttribute("SFTOK09386D", "Broadleaf.Application.Remoting.ParamData.EmployeeWork")]
			object paraobj, 
            int readMode, 
            ConstantManagement.LogicalMode logicalMode
            );
        
        /// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̏]�ƈ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="employeeWork">��������</param>
		/// <param name="paraemployeeWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
////20050705 yamada Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//		int Search(out byte[] retbyte, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFTOK09386D","Broadleaf.Application.Remoting.ParamData.EmployeeWork")]
			out object employeeWork, 
			object paraemployeeWork,
			int readMode,ConstantManagement.LogicalMode logicalMode);
////20050705 yamada End   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̏]�ƈ�LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="employeeWork">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="paraemployeeWork">�����p�����[�^�iNextRead���͑O��ŏI���R�[�h�N���X�j</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">��������</param>		
		/// <returns>STATUS</returns>
////20050705 yamada Start >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
//		int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt);
		[MustCustomSerialization]
		int SearchSpecification(
			[CustomSerializationMethodParameterAttribute("SFTOK09386D","Broadleaf.Application.Remoting.ParamData.EmployeeWork")]
			out object employeeWork,
			out int retTotalCnt,out bool nextData,
			object paraemployeeWork, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt);
////20050705 yamada End   <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

		/// <summary>
		/// �w�肳�ꂽ�]�ƈ�Guid�̏]�ƈ���߂��܂�
		/// </summary>
		/// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// �w�肳�ꂽ�]�ƈ�Guid�̏]�ƈ���߂��܂�
		/// </summary>
        /// <param name="paraobj">WorkerWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		[MustCustomSerialization]
		int Read(
			[CustomSerializationMethodParameterAttribute("SFTOK09386D","Broadleaf.Application.Remoting.ParamData.EmployeeWork")]
			ref object paraobj,
			int readMode);

		/// <summary>
		/// �]�ƈ�����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// �]�ƈ�����o�^�A�X�V���܂�
		/// </summary>
        /// <param name="paraobj">WorkerWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("SFTOK09386D", "Broadleaf.Application.Remoting.ParamData.EmployeeWork")]
			ref object paraobj
            );

        /// <summary>
		/// �]�ƈ����𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		int Delete(byte[] parabyte);

        /// <summary>
        /// �]�ƈ����𕨗��폜���܂�
        /// </summary>
        /// <param name="paraobj">WorkerWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("SFTOK09386D", "Broadleaf.Application.Remoting.ParamData.EmployeeWork")]
			object paraobj
            );

        /// <summary>
		/// �]�ƈ�����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		int LogicalDelete(ref byte[] parabyte);

        /// <summary>
        /// �]�ƈ�����_���폜���܂�
        /// </summary>
        /// <param name="paraobj">WorkerWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFTOK09386D", "Broadleaf.Application.Remoting.ParamData.EmployeeWork")]
			ref object paraobj
            );
        
        /// <summary>
		/// �_���폜�]�ƈ����𕜊����܂�
		/// </summary>
		/// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		int RevivalLogicalDelete(ref byte[] parabyte);
    
        /// <summary>
        /// �_���폜�]�ƈ����𕜊����܂�
        /// </summary>
        /// <param name="paraobj">WorkerWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFTOK09386D", "Broadleaf.Application.Remoting.ParamData.EmployeeWork")]
			ref object paraobj
            );
    }
}
