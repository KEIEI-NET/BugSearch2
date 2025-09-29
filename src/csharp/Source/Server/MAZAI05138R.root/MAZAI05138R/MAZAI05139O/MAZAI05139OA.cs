using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �I��������DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �I��������DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22035 �O�� �O���@  </br>
	/// <br>Date       : 2007.04.07</br>
	/// <br></br>
    /// <br>Update Note: 2013/03/01 yangyi</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 2013/03/06�z�M���ً̋}�Ή�</br>
    /// <br>           : Redmine#34175 �@�I���Ɩ��̃T�[�o�[���׌y���΍�</br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface IInventoryDataUpdateDB
	{		
		/// <summary>
		/// �I�������͏���o�^�A�X�V���܂�
		/// </summary>
        /// <param name="paraList">InventoryDataUpdateWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �I�������͏���o�^�A�X�V���܂�</br>
		/// <br>Programmer : 22035 �O�� �O���@  </br>
		/// <br>Date       : 2007.04.07</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("MAZAI05136D", "Broadleaf.Application.Remoting.ParamData.InventoryDataUpdateWork")]
			ref object paraList);

        // --- ADD 2009/12/03 ---------->>>>>
        /// <summary>
        /// �݌ɑ����擾����
        /// </summary>
        /// <param name="objIvtDataWork">�I���f�[�^�X�V���[�N</param>
        /// <param name="stockTotal">�݌ɑ���</param>
        /// <param name="arrivalCnt">���א�</param>
        /// <param name="shipmentCnt">�o�א�</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note       : �݌ɑ����擾�������s���܂�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/12/03</br>
        /// </remarks>
        int GetStockTotal(object objIvtDataWork, ref double stockTotal, ref double arrivalCnt, ref double shipmentCnt);
        // --- ADD 2009/12/03 ----------<<<<<

        // --- ADD yangyi 2013/03/01 for Redmine#34175 ------->>>>>>>>>>>
        /// <summary>
        /// �I�����͌������ʃN���XLIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retobj">��������</param>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : yangyi</br>
        /// <br>Date       : 2013/02/19</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retobj,
            object paraobj,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);
        // --- ADD yangyi 2013/03/01 for Redmine#34175 -------<<<<<<<<<<<
	}
}
