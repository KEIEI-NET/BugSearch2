using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �ԍ��Ǘ��ݒ�DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �ԍ��Ǘ��ݒ�DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 95016�@���c���@���F</br>
	/// <br>Date       : 2005.04.27</br>
	/// <br></br>
    /// <br>Update Note: 2008.05.28 20081 �D�c �E�l</br>
    /// <br>           : PM.NS�p�ɕύX</br>
	/// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��

	public interface INoMngSetDB
	{
		/// <summary>
		/// �w�肳�ꂽ�ԍ��Ǘ��ݒ�Guid�̔ԍ��Ǘ��ݒ��߂��܂�
		/// </summary>
		/// <param name="parabyte">NoMngSetWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		int ReadNoMngSet(ref byte[] parabyte , int readMode);

		/// <summary>
		/// �ԍ��Ǘ��ݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="paraobj">NoMngSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		[MustCustomSerialization]
		int WriteNoMngSet(
			[CustomSerializationMethodParameterAttribute("SFCMN09106D","Broadleaf.Application.Remoting.ParamData.NoMngSetWork")]
			ref object paraobj);

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̔ԍ��^�C�v�Ǘ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		[MustCustomSerialization]
		int SearchNoTypeMng(
			[CustomSerializationMethodParameterAttribute("SFCMN09106D","Broadleaf.Application.Remoting.ParamData.NoTypeMngWork")]
			out object retobj,object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�A�ԍ��R�[�h�̔ԍ��^�C�v�ݒ��߂��܂�
		/// </summary>
		/// <param name="parabyte">NoTypeMngWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		int ReadNoTypeMng(ref byte[] parabyte , int readMode);

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�A�ԍ��R�[�h�̔ԍ��^�C�v�ݒ��o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">NoTypeMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		int WriteNoTypeMng(ref byte[] parabyte);

		/// <summary>
		/// �ԍ��^�C�v�Ǘ�����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">NoTypeMngWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		int LogicalDeleteNoTypeMng(ref byte[] parabyte);

		/// <summary>
		/// �_���폜�ԍ��^�C�v�Ǘ����𕜊����܂�
		/// </summary>
		/// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		int RevivalLogicalDeleteNoTypeMng(ref byte[] parabyte);

		/// <summary>
		/// �ԍ��^�C�v�Ǘ����𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">�ԍ��^�C�v�Ǘ��ݒ�I�u�W�F�N�g</param>
		/// <returns></returns>
		int DeleteNoTypeMng(byte[] parabyte);

        // 2008.05.28 del start -------------------------->>
        ///// <summary>
        ///// �w�肳�ꂽ��ƃR�[�h�A�ԍ��v�f�R�[�h�̔ԍ��v�f�Ǘ�����߂��܂�
        ///// </summary>
        ///// <param name="parabyte">NoElmntMngWork�I�u�W�F�N�g</param>
        ///// <param name="readMode">�����敪</param>
        ///// <returns>STATUS</returns>
        //int ReadNoElmntMng(ref byte[] parabyte , int readMode);
        
        ///// <summary>
        ///// �ԍ��v�f�Ǘ�����o�^�A�X�V���܂�
        ///// </summary>
        ///// <param name="parabyte">NoElmntMngWork�I�u�W�F�N�g</param>
        ///// <returns>STATUS</returns>
        //int WriteNoElmntMng(ref byte[] parabyte);
        
        ///// <summary>
        ///// �w�肳�ꂽ��ƃR�[�h�̔ԍ��Ǘ��ݒ�LIST�A�ԍ��^�C�v�Ǘ�LIST�A�ԍ��v�f�Ǘ�LIST��S�Ė߂��܂��B
        ///// </summary>
        ///// <param name="retNoMngSet">�������ʁi�ԍ��Ǘ��ݒ�j</param>
        ///// <param name="retNoTypeMng">�������ʁi�ԍ��^�C�v�Ǘ��j</param>
        ///// <param name="retNoElmntMng">�������ʁi�ԍ��v�f�Ǘ��j</param> 
        ///// <param name="enterpriseCode">�����p�����[�^(��ƃR�[�h)</param>
        ///// <param name="searchMode">�����敪(0:ALL�A1:�����̔ԗL��̃f�[�^�̂�)</param>
        ///// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        ///// <returns>STATUS</returns>
        //[MustCustomSerialization]
        //int Search(
        //    [CustomSerializationMethodParameterAttribute("SFCMN09106D","Broadleaf.Application.Remoting.ParamData.NoMngSetWork")]
        //    out object retNoMngSet, 
        //    [CustomSerializationMethodParameterAttribute("SFCMN09106D","Broadleaf.Application.Remoting.ParamData.NoTypeMngWork")]
        //    out object retNoTypeMng, 
        //    [CustomSerializationMethodParameterAttribute("SFCMN09106D","Broadleaf.Application.Remoting.ParamData.NoElmntMngWork")]
        //    out object retNoElmntMng,                                                                                             
        //    string enterpriseCode, int searchMode,ConstantManagement.LogicalMode logicalMode);
        // 2008.05.28 del end ----------------------------<<

		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̔ԍ��Ǘ��ݒ�LIST�A�ԍ��^�C�v�Ǘ�LIST�A�ԍ��v�f�Ǘ�LIST��S�Ė߂��܂��B
		/// </summary>
		/// <param name="retNoMngSet">�������ʁi�ԍ��Ǘ��ݒ�j</param>
		/// <param name="retNoTypeMng">�������ʁi�ԍ��^�C�v�Ǘ��j</param>
		/// <param name="enterpriseCode">�����p�����[�^(��ƃR�[�h)</param>
		/// <param name="searchMode">�����敪(0:ALL�A1:�����̔ԗL��̃f�[�^�̂�)</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFCMN09106D","Broadleaf.Application.Remoting.ParamData.NoMngSetWork")]
			out object retNoMngSet, 
			[CustomSerializationMethodParameterAttribute("SFCMN09106D","Broadleaf.Application.Remoting.ParamData.NoTypeMngWork")]
			out object retNoTypeMng, 
			string enterpriseCode, int searchMode,ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �ԍ��Ǘ��ݒ���A�ԍ��v�f�Ǘ���񓯎��������ݗp���\�b�h
        /// </summary>
        /// <param name="paraNoMngSet">�ԍ��Ǘ��ݒ�I�u�W�F�N�g</param>
        /// <param name="paraNoElmntMng">�ԍ��v�f�Ǘ��I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        int Write(ref byte[] paraNoMngSet, ref byte[] paraNoElmntMng);
   	}
}
