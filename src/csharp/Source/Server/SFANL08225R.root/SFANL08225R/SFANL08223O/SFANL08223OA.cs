using System;
using System.Collections;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���R���[�O���[�vDB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���R���[�O���[�vDB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22011 �����@���l</br>
	/// <br>Date       : 2007.05.22</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��

    public interface IFreePprGrpDB
	{
		#region ���R���[�O���[�v
        /// <summary>
        /// ���R���[�O���[�vLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchFreePprGrp(
            [CustomSerializationMethodParameterAttribute("SFANL08224D", "Broadleaf.Application.Remoting.ParamData.FreePprGrpWork")]
            out object retObj, object paraObj, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg);

        /// <summary>
		/// �w�肳�ꂽ��ƃR�[�h�̎��R���[�O���[�vLIST��S�Ė߂��܂�
		/// </summary>
		/// <param name="retList">��������</param>
		/// <param name="freePprGrpWork">��������</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        int SearchFreePprGrp(out ArrayList retList, FreePprGrpWork freePprGrpWork, int readMode, ConstantManagement.LogicalMode logicalMode, ref SqlConnection sqlConnection, out bool msgDiv, out string errMsg);
		
        /// <summary>
		/// �w�肳�ꂽ���R���[�O���[�vGuid�̎��R���[�O���[�v��߂��܂�
		/// </summary>
		/// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        int ReadFreePprGrp(ref byte[] parabyte, int readMode, out bool msgDiv, out string errMsg);

		/// <summary>
		/// ���R���[�O���[�v����o�^�A�X�V���܂�
		/// </summary>
		/// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        int WriteFreePprGrp(ref byte[] parabyte, out bool msgDiv, out string errMsg);

        /// <summary>
		/// ���R���[�O���[�v���𕨗��폜���܂�
		/// </summary>
		/// <param name="parabyte1">���R���[�O���[�v�I�u�W�F�N�g</param>
		/// <param name="parabyte2">���R���[�O���[�v�U�փI�u�W�F�N�g</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STASUS</returns>
        int DeleteFreePprGrpAll(ref byte[] parabyte1, ref byte[] parabyte2, out bool msgDiv, out string errMsg);

		/// <summary>
		/// ���R���[�O���[�v�}�X�^�폜�`�F�b�N����
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="freePrtPprGroupCd">���R���[�O���[�v�R�[�h</param>
		/// <param name="message">���b�Z�[�W</param>
		/// <param name="checkFlg">�`�F�b�N����[true:�폜�n�j][false:�폜�m�f]</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        int DeleteCheck(string enterpriseCode, Int32 freePrtPprGroupCd, out string message, out bool checkFlg, out bool msgDiv, out string errMsg);
		
		#endregion

		#region ���R���[�O���[�v�U��

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�����R���[�O���[�v�R�[�h�̎��R���[�O���[�vLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retbyte">��������(FrePprGrTrWork�̔z��)</param>
        /// <param name="parabyte">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        int SearchFrePprGrTr(out byte[] retbyte, byte[] parabyte, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg);

        /// <summary>
        /// �w�肳�ꂽ��ƃR�[�h�����R���[�O���[�v�R�[�h�̎��R���[�O���[�v�U��LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="enterpriseCode">�����p��ƃR�[�h</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int SearchFrePprGrTrAll(
            [CustomSerializationMethodParameterAttribute("SFANL08224D", "Broadleaf.Application.Remoting.ParamData.FrePprGrTrWork")]
            out object retObj, string enterpriseCode, int readMode, ConstantManagement.LogicalMode logicalMode, out bool msgDiv, out string errMsg);

        /// <summary>
        /// �w�肳�ꂽ���R���[�O���[�v�U��Guid�̎��R���[�O���[�v�U�ւ�߂��܂�
        /// </summary>
        /// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        int ReadFrePprGrTr(ref byte[] parabyte, int readMode, out bool msgDiv, out string errMsg);

        /// <summary>
        /// ���R���[�O���[�v�U�֏���o�^�A�X�V���܂�
        /// </summary>
        /// <param name="paraobj">FrePprGrTrWork���X�g�̃I�u�W�F�N�g</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        int WriteFrePprGrTr(ref object paraobj, out bool msgDiv, out string errMsg);

        /// <summary>
        /// ���R���[�O���[�v�U�֏���S�O���[�v�ɓo�^���܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="displayName">�o�͖���</param>
        /// <param name="outputFormFileName">�o�̓t�@�C����</param>
        /// <param name="userPrtPprIdDerivNo">���[�U�[���[ID�}�ԍ�</param>
        /// <param name="sqlConnection">�R�l�N�V�������</param>
        /// <param name="Sqltrance">�g�����U�N�V�������</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>�X�e�[�^�X</returns>
        int EntryFrePprGrTr(string enterpriseCode, string displayName, string outputFormFileName, Int32 userPrtPprIdDerivNo, SqlConnection sqlConnection, SqlTransaction Sqltrance,out bool msgDiv, out string errMsg);
        
        // DEL 2007.06.08
        ///// <summary>
        ///// ���R���[�O���[�v���Ǝ��R���[�O���[�v�U�֑S�Ă�o�^�A�X�V���܂�
        ///// </summary>
        ///// <param name="parabyte1">FreePprGrpWork  �I�u�W�F�N�g</param>
        ///// <param name="parabyte2">FrePprGrTrWork�I�u�W�F�N�g</param>
        ///// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W������</param>
        ///// <returns>STATUS</returns>
        //int WriteFreePprGrpAndDtl(ref byte[] parabyte1, ref byte[] parabyte2, out bool msgDiv, out string errMsg);

        ///// <summary>
        ///// ���R���[�O���[�v�U�ւ��폜���o�^���܂�
        ///// </summary>
        ///// <param name="parabyte1">�폜���鎩�R���[�O���[�v�U��LIST</param>
        ///// <param name="parabyte2">�o�^���鎩�R���[�O���[�v�U��LIST</param>
        ///// <returns>STATUS</returns>
        //int DtlDeleteAndWrite(ref byte[] parabyte1, ref byte[] parabyte2);

        /// <summary>
        /// ���R���[�O���[�v�U�֏��𕨗��폜���܂��i�������R�[�h���R�[�h�j
        /// </summary>
        /// <param name="parabyte">FrePprGrTrWork�I�u�W�F�N�g</param>
        /// <param name="msgDiv">���b�Z�[�W�L���敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W������</param>
        /// <returns>STATUS</returns>
        int DtlDelete(byte[] parabyte, out bool msgDiv, out string errMsg);

        #endregion
    }
}
