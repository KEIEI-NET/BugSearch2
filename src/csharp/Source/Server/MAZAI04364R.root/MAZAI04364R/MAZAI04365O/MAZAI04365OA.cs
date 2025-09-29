using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �݌ɒ����f�[�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �݌ɒ����f�[�^DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 21015�@�����@�F��</br>
	/// <br>Date       : 2007.02.14</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
	public interface IStockAdjustDB
	{

        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
		/// �w�肳�ꂽ�݌ɒ����f�[�^Guid�̍݌ɒ����f�[�^��߂��܂�
		/// </summary>
		/// <param name="parabyte">StockAdjustWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ�݌ɒ����f�[�^Guid�̍݌ɒ����f�[�^��߂��܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.02.14</br>
		int Read(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object parabyte, int readMode);

		/// <summary>
		/// �݌ɒ����f�[�^���𕨗��폜���܂�
		/// </summary>
        /// <param name="parabyte">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
		/// <br>Note       : �݌ɒ����f�[�^���𕨗��폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.02.14</br>
		int Delete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object parabyte, out string retMsg);

		/// <summary>
		/// �݌ɒ����f�[�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
		/// <param name="stockAdjustWork">��������</param>
		/// <param name="parastockAdjustWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.02.14</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			out object stockAdjustWork,
			object parastockAdjustWork, int readMode,ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �݌ɒ����f�[�^�A�݌ɒ������׃f�[�^LIST��߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="stockAdjustSlipNo">�݌Ɏd���`�[�ԍ�</param>
        /// <param name="stockAdjustWork">�݌ɒ����f�[�^��������</param>
        /// <param name="stockAdjustDtlWork">�݌ɒ������׃f�[�^��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.09.02</br>
        [MustCustomSerialization]
        int SearchSlipAndDtl(
            string enterpriseCode,int stockAdjustSlipNo,
            [CustomSerializationMethodParameterAttribute("MAZAI04366D", "Broadleaf.Application.Remoting.ParamData.StockAdjustWork")]
			ref ArrayList stockAdjustWork,
            [CustomSerializationMethodParameterAttribute("MAZAI04366D", "Broadleaf.Application.Remoting.ParamData.StockAdjustDtlWork")]
			ref ArrayList stockAdjustDtlWork
            );
        
        /// <summary>
		/// �݌ɒ����f�[�^����o�^�A�X�V���܂�(�݌Ɏd�����͗p)
		/// </summary>
		/// <param name="stockAdjustWork">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
		/// <br>Note       : �݌ɒ����f�[�^����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.02.14</br>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockAdjustWork,
            out string retMsg
			);

        /// <summary>
        /// �݌ɒ����f�[�^����o�^�A�X�V���܂�(�݌Ɉꊇ�o�^�A���i�݌Ƀ}�X�����p)
        /// </summary>
        /// <param name="stockAdjustCustList">stockAdjustCustList�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        [MustCustomSerialization]
        int WriteBatch(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockAdjustCustList,
            out string retMsg
            );
        // --- DEL �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� ----->>>>>
        ///// <summary>
        ///// �I���f�[�^�����݌ɒ����f�[�^����o�^�A�X�V���܂�
        ///// </summary>
        ///// <param name="stockAdjustWork">StockAdjustWork�I�u�W�F�N�g</param>
        ///// <param name="retMsg">���b�Z�[�W</param>
        ///// <param name="shelfNoUpdateDiv">�I�ԍX�V�敪 (0:���� 1:���Ȃ�)</param>
        ///// <returns>STATUS</returns>
        ///// <br>Note       : �݌ɒ����f�[�^����o�^�A�X�V���܂�</br>
        ///// <br>Programmer : 21015�@�����@�F��</br>
        ///// <br>Date       : 2007.02.14</br>
        //[MustCustomSerialization]
        //int WriteInventory(
        //    [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
        //    ref object stockAdjustWork,
        //    out string retMsg,
        //    int shelfNoUpdateDiv  
        //    );
        // --- DEL �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� -----<<<<<

        // --- ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� ----->>>>>
        /// <summary>
        /// �I���f�[�^�����݌ɒ����f�[�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="shelfNoUpdateDiv">�I�ԍX�V�敪 (0:���� 1:���Ȃ�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : 2015/08/21</br>
        int WriteInventory(
            object stockAdjustWork,
            out string retMsg,
            int shelfNoUpdateDiv
            );

        /// <summary>
        /// �I������(�ߕs�����p)�@��
        /// </summary>
        /// <param name="paraobj">�����p�����[�^</param>
        /// <param name="inventInputUpdateCndtnWork">�X�V�p�����[�^</param>
        /// <param name="isSaved">isSaved</param>
        /// <param name="secInfoSetDic">���_�R�[�h�Ɩ���</param>
        /// <param name="warehouseDic">�q�ɃR�[�h�Ɩ���</param>
        /// <param name="makerUMntDic">���[�J�R�[�h�Ɩ���</param>
        /// <param name="blGoodsCdUMntDic">BL���i�R�[�h�Ɩ���</param>
        /// <param name="meaaage">meaaage</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : K2015/08/21</br>
        int SearchInventAndUpdate(
            object paraobj,
            object inventInputUpdateCndtnWork,
            out bool isSaved,
            object secInfoSetDic,
            object warehouseDic,
            object makerUMntDic,
            object blGoodsCdUMntDic,
            out string meaaage
            );
        // --- ADD �� K2015/08/21 Redmine#46790 �I���ߕs���X�V�@�������A�E�g�̏C�� -----<<<<<

        /// <summary>
        /// �݌ɒ����f�[�^����o�^�A�X�V���܂�(�ϑ���[�p)
        /// </summary>
        /// <param name="stockAdjustWork">StockAdjustWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <param name="warehouseList">�V�F�A�`�F�b�N�p�q�Ƀ��X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌ɒ����f�[�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 21015�@�����@�F��</br>
        /// <br>Date       : 2007.02.14</br>
        [MustCustomSerialization]
        int WriteEntrust(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockAdjustWork,
            out string retMsg,
            ref object warehouseList
            );

        /// <summary>
		/// �݌ɒ����f�[�^����_���폜���܂�
		/// </summary>
		/// <param name="stockAdjustWork">StockAdjustWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �݌ɒ����f�[�^����_���폜���܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.02.14</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockAdjustWork
			);

		/// <summary>
		/// �_���폜�݌ɒ����f�[�^���𕜊����܂�
		/// </summary>
		/// <param name="stockAdjustWork">StockAdjustWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜�݌ɒ����f�[�^���𕜊����܂�</br>
		/// <br>Programmer : 21015�@�����@�F��</br>
		/// <br>Date       : 2007.02.14</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
			ref object stockAdjustWork
			);
		#endregion
	}
}
