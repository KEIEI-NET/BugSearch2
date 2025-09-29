using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���Ӑ���яC��DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���Ӑ���яC��DB RemoteObject�C���^�[�t�F�[�X</br>
	/// <br>Programmer : 20036�@�ē��@�떾</br>
	/// <br>Date       : 2007.04.20</br>
	/// <br></br>
	/// <br>Update Note: �o�l.�m�r�p�ɕύX</br>
    /// <br>Programmer : 20081�@�D�c�@�E�l</br>
    /// <br>Date       : 2008.06.02</br>
	    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustRsltUpdDB
	{
		/// <summary>
		/// �w�肳�ꂽ���Ӑ攄�|���z�}�X�^�̃f�[�^��߂��܂�
		/// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="retObj">���Ӑ攄�|���z�}�X�^List</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ���Ӑ攄�|���z�}�X�^�̃f�[�^��߂��܂�</br>
		/// <br>Programmer : 20036�@�ē��@�떾</br>
		/// <br>Date       : 2007.04.20</br>
		int SearchAccRec(string enterpriseCode, string sectionCode, int claimCode, int customerCode, int readMode,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retObj);

        /// <summary>
        /// �w�肳�ꂽ���Ӑ搿�����z�}�X�^�̃f�[�^��߂��܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="claimCode">������R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="retObj">���Ӑ搿�����z�}�X�^List</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ���Ӑ攄�|���z�}�X�^�̃f�[�^��߂��܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.20</br>
        int SearchDmdPrc(string enterpriseCode, string sectionCode, int claimCode, string resultsSectCd, int customerCode, int readMode,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retObj);

		/// <summary>
        /// ���Ӑ攄�|���z�}�X�^����o�^�A�X�V���܂�
		/// </summary>
        /// <param name="custAccRecWork">CustAccRecWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ攄�|���z�}�X�^����o�^�A�X�V���܂�</br>
		/// <br>Programmer : 20036�@�ē��@�떾</br>
		/// <br>Date       : 2007.04.20</br>
        [MustCustomSerialization]
        int WriteAccRec([CustomSerializationMethodParameterAttribute("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.CustAccRecWork")]ref object custAccRecWork, out string retMsg);

        /// <summary>
        /// ���Ӑ搿�����z�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="custDmdPrcWork">CustDmdPrcWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ搿�����z�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.20</br>
        [MustCustomSerialization]
        int WriteDmdPrc([CustomSerializationMethodParameterAttribute("MAKAU00125D", "Broadleaf.Application.Remoting.ParamData.CustDmdPrcWork")]ref object custDmdPrcWork, out string retMsg);

        /// <summary>
        /// ���Ӑ攄�|���z�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="custAccRecWork">CustAccRecWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �q���R�[�h�ƏW�v���R�[�h�̍X�V���s��</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.02</br>
        [MustCustomSerialization]
        int WriteTotalAccRec(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object custAccRecWork, out string retMsg);

        /// <summary>
        /// ���Ӑ搿�����z�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="custDmdPrcWork">CustDmdPrcWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �q���R�[�h�ƏW�v���R�[�h�̍X�V���s��</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.02</br>
        [MustCustomSerialization]
        int WriteTotalDmdPrc(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object custDmdPrcWork, out string retMsg);

        /// <summary>
        /// ���Ӑ攄�|���z�}�X�^�����폜���܂�
        /// </summary>
        /// <param name="custAccRecWork">CustAccRecWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ攄�|���z�}�X�^�����폜���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.26</br>
        int DeleteAccRec(
            [CustomSerializationMethodParameterAttribute("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.CustAccRecWork")]
            object custAccRecWork);

        /// <summary>
        /// ���Ӑ搿�����z�}�X�^�����폜���܂�
        /// </summary>
        /// <param name="custDmdPrcWork">CustDmdPrcWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ搿�����z�}�X�^�����폜���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.26</br>
        int DeleteDmdPrc(
            [CustomSerializationMethodParameterAttribute("MAKAU00125D", "Broadleaf.Application.Remoting.ParamData.CustDmdPrcWork")]
            object custDmdPrcWork);

        /// <summary>
        /// ���Ӑ攄�|���z�}�X�^�����폜��A�W�v���R�[�h���X�V���܂��B
        /// </summary>
        /// <param name="custAccRecWork">CustAccRecWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ攄�|���z�}�X�^�����폜��A�W�v���R�[�h���X�V���܂�</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.02</br>
        int DeleteTotalAccRec(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            object custAccRecWork);

        /// <summary>
        /// ���Ӑ搿�����z�}�X�^�����폜��A�W�v���R�[�h���X�V���܂��B
        /// </summary>
        /// <param name="custDmdPrcWork">CustDmdPrcWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���Ӑ搿�����z�}�X�^�����폜��A�W�v���R�[�h���X�V���܂�</br>
        /// <br>Programmer : 20081�@�D�c�@�E�l</br>
        /// <br>Date       : 2008.06.02</br>
        int DeleteTotalDmdPrc(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            object custDmdPrcWork);
   	}
}
