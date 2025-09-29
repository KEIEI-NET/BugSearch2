using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
	#region ���ʉ����\�b�h
	/// <summary>
	/// ���z��ʐݒ�DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���z��ʐݒ�DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 21052�@�R�c�@�\</br>
	/// <br>Date       : 2005.05.09</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface IMoneyKindDB
	{
		/// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̋��z��ʐݒ�LIST�̌�����߂��܂�
		/// </summary>
		/// <param name="retCnt">�Y���f�[�^����</param>
		/// <param name="parabyte">�����p�����[�^</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="getdatatype">�擾�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		int SearchCnt(out int retCnt, byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode, GetMoneyKindDataType getdatatype);
		
		/// <summary>
		/// ���z��ʐݒ�LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="parabyte">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="getdatatype">�擾�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		int Search(
            out byte[] retbyte,
            byte[] parabyte,
            int readMode,
            ConstantManagement.LogicalMode logicalMode,
            GetMoneyKindDataType getdatatype);

        /// <summary>
        /// ���z��ʐݒ�LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retList">��������</param>
        /// <param name="paraWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="getdatatype">�擾�Ώۃf�[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 21052�@�R�c�@�\</br>
        /// <br>Date       : 2005.05.09</br>
        int Search(
            [CustomSerializationMethodParameterAttribute("SFUKK09046D", "Broadleaf.Application.Remoting.ParamData.MoneyKindWork")]
            out object retList,
            object paraWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode,
            GetMoneyKindDataType getdatatype);
        
        /// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̋��z��ʐݒ�LIST���w�茏�����S�Ė߂��܂��i�_���폜�����j
		/// </summary>
		/// <param name="retbyte">��������</param>
		/// <param name="retTotalCnt">�����Ώۑ�����</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="parabyte">�����p�����[�^�iNextRead���͑O��ŏI���R�[�h�N���X�j</param>		
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="readCnt">��������</param>		
		/// <param name="getdatatype">�擾�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		int SearchSpecification(out byte[] retbyte,out int retTotalCnt,out bool nextData,byte[] parabyte, int readMode,ConstantManagement.LogicalMode logicalMode,int readCnt, GetMoneyKindDataType getdatatype);

		/// <summary>
		/// �w�肳�ꂽ���z��ʐݒ�Guid�̋��z��ʐݒ��߂��܂�
		/// </summary>
		/// <param name="parabyte">MoneyKindWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="getdatatype">�擾�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �w�肳�ꂽ���z��ʐݒ�Guid�̋��z��ʐݒ��߂��܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		int Read(ref byte[] parabyte , int readMode, GetMoneyKindDataType getdatatype);

		/// <summary>
		/// ���z��ʐݒ����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">MoneyKindWork�I�u�W�F�N�g</param>
		/// <param name="getdatatype">�擾�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���z��ʐݒ����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		int Write(ref byte[] parabyte, GetMoneyKindDataType getdatatype);

		/// <summary>
		/// ���z��ʐݒ���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte">MoneyKindWork�I�u�W�F�N�g</param>
		/// <param name="getdatatype">�擾�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���z��ʐݒ���𕨗��폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		int Delete(byte[] parabyte, GetMoneyKindDataType getdatatype);

		/// <summary>
		/// ���z��ʐݒ����_���폜���܂�
		/// </summary>
		/// <param name="parabyte">MoneyKindWork�I�u�W�F�N�g</param>
		/// <param name="getdatatype">�擾�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���z��ʐݒ����_���폜���܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		int LogicalDelete(ref byte[] parabyte, GetMoneyKindDataType getdatatype);

		/// <summary>
		/// �_���폜���z��ʐݒ���𕜊����܂�
		/// </summary>
		/// <param name="parabyte">MoneyKindWork�I�u�W�F�N�g</param>
		/// <param name="getdatatype">�擾�Ώۃf�[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���z��ʐݒ���𕜊����܂�</br>
		/// <br>Programmer : 21052�@�R�c�@�\</br>
		/// <br>Date       : 2005.05.09</br>
		int RevivalLogicalDelete(ref byte[] parabyte, GetMoneyKindDataType getdatatype);
	}
	#endregion

	#region �擾�Ώۃf�[�^�萔
	/// <summary>
	/// �擾�Ώۃf�[�^�萔
	/// </summary>
	/// <br>Note       : �K�C�h�n�}�X�^�̎擾�Ώۃf�[�^�萔�ł��B</br>
	/// <br>Programmer : 21052�@�R�c�@�\</br>
	/// <br>Date       : 2005.05.09</br>
	public enum GetMoneyKindDataType
	{
		/// <summary>
		/// �{�f�B�f�[�^(���[�U�[�ύX��)
		/// </summary>
		UserMoneyKindData = 1,
		/// <summary>
		/// �{�f�B�f�[�^(�񋟕�)
		/// </summary>
		OfferMoneyKindData
	}
	#endregion
}
