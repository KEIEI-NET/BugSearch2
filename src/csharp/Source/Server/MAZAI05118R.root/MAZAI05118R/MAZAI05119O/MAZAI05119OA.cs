using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �I����������DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �I����������DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22035 �O�� �O��</br>
	/// <br>Date       : 2007.04.04</br>
	/// <br></br>
    /// <br>Update Note : 2009/11/30 ���M �ێ�˗��B�Ή�</br>
    /// <br>             �����f�[�^���ݎ��̏������e��ύX</br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
    public interface IInventoryExtDB
	{
		/// <summary>
		/// �I����������(������������)LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retobj">��������(������������)</param>
		/// <param name="paraobj">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2007.04.04</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("MAZAI05116D", "Broadleaf.Application.Remoting.ParamData.InventDataPreWork")]
			out object retobj,
			object paraobj,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

		/// <summary>
		/// �I���f�[�^���������A���̏���o�^�E�X�V�ƁA�I����������LIST(������������)��S�Ė߂��܂�
		/// </summary>
        /// <param name="retobj">��������(������������)</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="statusMSG">status�ɑ΂��郁�b�Z�[�W</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �I���f�[�^���������A���̏���o�^�E�X�V�ƁA�I����������LIST(������������)��S�Ė߂��܂�</br>
		/// <br>Programmer : 22035 �O�� �O��</br>
		/// <br>Date       : 2007.04.04</br>
        [MustCustomSerialization]
		int SearchWrite(
            [CustomSerializationMethodParameterAttribute("MAZAI05116D", "Broadleaf.Application.Remoting.ParamData.InventDataPreWork")]
            out object retobj,
			object paraobj,
			int readMode,
            ConstantManagement.LogicalMode logicalMode,
            out string statusMSG);

        // --- ADD 2009/11/30 ---------->>>>>
        /// <summary>
        /// �I���f�[�^���������A�I���f�[�^���݃`�F�b�Nflag��߂��܂�
        /// </summary>
        /// <param name="retobj">���݃`�F�b�Nflag</param>
        /// <param name="parabyte">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="statusMSG">status�ɑ΂��郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^���������A�I���f�[�^���݃`�F�b�Nflag��߂��܂�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.11.30</br>
        [MustCustomSerialization]
        int SearchRepateDate(
            out object retobj,
            object paraobj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode,
            out string statusMSG);
        // --- ADD 2009/11/30 ----------<<<<<

        /// <summary>
        /// �݌Ƀ}�X�^���������A�I����������LIST(�I���f�[�^)��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������(�I���f�[�^)</param>
        /// <param name="parabyte">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="statusMSG">status�ɑ΂��郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ƀ}�X�^���������A�I����������LIST(�I���f�[�^)��S�Ė߂��܂�
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        [MustCustomSerialization]
        int SearchInventoryDate(
            [CustomSerializationMethodParameterAttribute("MAZAI05116D", "Broadleaf.Application.Remoting.ParamData.InventoryDataWork")]
            out object retobj,
            object paraobj,
            ConstantManagement.LogicalMode logicalMode,
            out string statusMSG);

        /// <summary>
        /// �I���f�[�^���������A���̏���o�^�E�X�V�ƁA�I����������LIST(������������)��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������(������������)</param>
        /// <param name="parabyte">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="statusMSG">status�ɑ΂��郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^���������A���̏���o�^�E�X�V�ƁA�I����������LIST(������������)��S�Ė߂��܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        [MustCustomSerialization]
        int WriteInventoryDate(
            [CustomSerializationMethodParameterAttribute("MAZAI05116D", "Broadleaf.Application.Remoting.ParamData.InventDataPreWork")]
            out object retobj,
            object paraobj,
            object paraobj2,
            ConstantManagement.LogicalMode logicalMode,
            out string statusMSG);

        /// <summary>
        /// �I���f�[�^(������������)��o�^�A�X�V���܂�
        /// </summary>
        /// <param name="parabyte">PrtIvntHisWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^(������������)��o�^�A�X�V���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        int Write(ref byte[] parabyte);

        /// <summary>
        /// �I���f�[�^(������������)�𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">PrtIvntHisWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^(������������)�𕨗��폜���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        int Delete(byte[] parabyte);

        /// <summary>
        /// �I���f�[�^(�݌ɁA���ԍ݌�)�𕨗��폜���܂�
        /// </summary>
        /// <param name="parabyte">InventoryDataWork�I�u�W�F�N�g</param>
        /// <param name="parabyte">PrtIvntHisWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^(������������)�𕨗��폜���܂�</br>
        /// <br>Programmer : 22035 �O�� �O��</br>
        /// <br>Date       : 2007.04.04</br>
        int DeleteInvent(byte[] parabyte, out byte[] retbyte);

        // ADD yangyi 2012/06/08 Redmine#30282 ------------->>>>>
        /// <summary>
        /// �I���f�[�^���������܂�
        /// </summary>
        /// <param name="retobj">���݃`�F�b�Nflag</param>
        /// <param name="parabyte">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="statusMSG">status�ɑ΂��郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �I���f�[�^���������A�I���f�[�^���݃`�F�b�Nflag��߂��܂�</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009.11.30</br>
        [MustCustomSerialization]
        int SearchInventoryData(
            [CustomSerializationMethodParameterAttribute("MAZAI05116D", "Broadleaf.Application.Remoting.ParamData.InventoryDataWork")]
            out object retobj,
            object paraobj,
            ConstantManagement.LogicalMode logicalMode);
        // ADD yangyi 2012/06/08 Redmine#30282 -------------<<<<<
	}
}
