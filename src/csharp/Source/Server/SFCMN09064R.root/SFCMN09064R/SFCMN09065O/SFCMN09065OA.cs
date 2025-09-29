using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���[�U�[�K�C�hDB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���[�U�[�K�C�hDB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2005.03.24</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface IUserGdBdUDB
	{
		#region ���ʉ����\�b�h
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̃��[�U�[�K�C�h���LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode);
		
		/// <summary>
		/// ���[�U�[�K�C�h���LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		[MustCustomSerialization]
		int Search(
			[CustomSerializationMethodParameterAttribute("SFCMN09066D","Broadleaf.Application.Remoting.ParamData.UserGdBdUWork")]
			out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �w�肳�ꂽGuideDivCode�̃��[�U�[�K�C�h���LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		[MustCustomSerialization]
		int SearchGuideDivCode(
			[CustomSerializationMethodParameterAttribute("SFCMN09066D","Broadleaf.Application.Remoting.ParamData.UserGdBdUWork")]
			out object retobj, object paraobj, int readMode,ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �w�肳�ꂽ���[�U�[�K�C�hGuid�̃��[�U�[�K�C�h����߂��܂�
		/// </summary>
		/// <param name="parabyte">OcrDefSetWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ���[�U�[�K�C�hGuid�̃��[�U�[�K�C�h��߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		int Read(ref byte[] parabyte , int readMode);

		/// <summary>
		/// ���[�U�[�K�C�h����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">OcrDefSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�U�[�K�C�h����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		int Write(ref byte[] parabyte);

		/// <summary>
		/// ���[�U�[�K�C�h���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">OcrDefSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�U�[�K�C�h���𕨗��폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		int Delete(byte[] parabyte);

		/// <summary>
		/// ���[�U�[�K�C�h����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">OcrDefSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�U�[�K�C�h����_���폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		int LogicalDelete(ref byte[] parabyte);

		/// <summary>
		/// �_���폜���[�U�[�K�C�h���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">OcrDefSetWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���[�U�[�K�C�h���𕜊����܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2005.03.24</br>
		int RevivalLogicalDelete(ref byte[] parabyte);

              /// <summary>
        /// ���[�U�[�K�C�h�}�X�^(�w�b�_)(���[�U�ύX��)���LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">��������</param>
        /// <param name="readMode">���[�h</param>
        /// <param name="logicalMode">�_���폜�敪</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^(�w�b�_)(���[�U�ύX��)���LIST��S�Ė߂��܂�</br>
        /// <br>Programmer : xueqi</br>
        /// <br>Date       : 2009.06.01</br>
        [MustCustomSerialization]
        int SearchHeader(            
            [CustomSerializationMethodParameterAttribute("SFCMN09066D", "Broadleaf.Application.Remoting.ParamData.UserGdHdUWork")]
            out object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode,
            out bool msgDiv, out string errMsg);

        /// <summary>
        /// ���[�U�[�K�C�h�}�X�^(�w�b�_)(���[�U�ύX��)����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="paraObj">�X�V�Ώ�</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�U�[�K�C�h�}�X�^(�w�b�_)(���[�U�ύX��)�̍X�V����</br>
        /// <br>Programmer : xueqi</br>
        /// <br>Date       : 2009.06.01</br>
        int WriteHeader(ref object paraObj, out bool msgDiv, out string errMsg);
		#endregion
	}

}
