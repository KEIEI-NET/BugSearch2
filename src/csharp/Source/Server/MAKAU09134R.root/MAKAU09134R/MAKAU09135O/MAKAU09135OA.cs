using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d������яC��DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d������яC��DB RemoteObject�C���^�[�t�F�[�X</br>
    /// <br>Programmer : 20036�@�ē��@�떾</br>
    /// <br>Date       : 2007.04.25</br>
    /// <br></br>
    /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISuppRsltUpdDB
    {
        /// <summary>
        /// �w�肳�ꂽ�d���攃�|���z�}�X�^�̃f�[�^��߂��܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="payeeCode">�x����R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="retObj">�d���攃�|���z�}�X�^List</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�d���攃�|���z�}�X�^�̃f�[�^��߂��܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        int SearchAccPay(string enterpriseCode, string sectionCode, int payeeCode, int supplierCd, int readMode,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retObj);

        /// <summary>
        /// �w�肳�ꂽ�d����x�����z�}�X�^�̃f�[�^��߂��܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="payeeCode">�x����R�[�h</param>
        /// <param name="resultsSectCd">���ы��_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="retObj">�d����x�����z�}�X�^List</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�d����x�����z�}�X�^�̃f�[�^��߂��܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        /// <br></br>
        /// <br>UpDateNote : 2007.09.26 ���� DC.NS�p�ɏC��</br>
        int SearchSuplierPay(string enterpriseCode, string sectionCode, int payeeCode, string resultsSectCd, int supplierCd, int readMode,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retObj);

        /// <summary>
        /// �d���攃�|���z�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="suplAccPayWork">SuplAccPayWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d���攃�|���z�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        [MustCustomSerialization]
        int WriteAccPay(
            [CustomSerializationMethodParameterAttribute("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.SuplAccPayWork")]
            ref object suplAccPayWork, out string retMsg);

        /// <summary>
        /// �d����x�����z�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="suplierPayWork">SuplierPayWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d����x�����z�}�X�^����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.25</br>
        [MustCustomSerialization]
        int WriteSuplierPay(
            [CustomSerializationMethodParameterAttribute("MAKAU00145D", "Broadleaf.Application.Remoting.ParamData.SuplierPayWork")]
            ref object suplierPayWork, out string retMsg);


        /// <summary>
        /// �d���攃�|���z�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="suplAccPayWork">SuplAccPayWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �q���R�[�h�ƏW�v���R�[�h�̍X�V���s��</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.25</br>
        [MustCustomSerialization]
        int WriteTotalAccPay(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object suplAccPayWork, out string retMsg);

        /// <summary>
        /// �d����x�����z�}�X�^����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="suplierPayWork">SuplierPayWork�I�u�W�F�N�g</param>
        /// <param name="retMsg">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �q���R�[�h�ƏW�v���R�[�h�̍X�V���s��</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.25</br>
        [MustCustomSerialization]
        int WriteTotalSuplierPay(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object suplierPayWork, out string retMsg);

        /// <summary>
        /// �d���攃�|���z�}�X�^�����폜���܂�
        /// </summary>
        /// <param name="suplAccPayWork">SuplAccPayWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d���攃�|���z�}�X�^�����폜���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.26</br>
        int DeleteAccPay(
            [CustomSerializationMethodParameterAttribute("MAKAU00135D", "Broadleaf.Application.Remoting.ParamData.SuplAccPayWork")]
            object suplAccPayWork);

        /// <summary>
        /// �d����x�����z�}�X�^�����폜���܂�
        /// </summary>
        /// <param name="suplierPayWork">SuplierPayWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d����x�����z�}�X�^�����폜���܂�</br>
        /// <br>Programmer : 20036�@�ē��@�떾</br>
        /// <br>Date       : 2007.04.26</br>
        int DeleteSuplierPay(
            [CustomSerializationMethodParameterAttribute("MAKAU00145D", "Broadleaf.Application.Remoting.ParamData.SuplierPayWork")]
            object suplierPayWork);

        /// <summary>
        /// �d���攃�|���z�}�X�^�����폜��A�W�v���R�[�h���X�V���܂��B
        /// </summary>
        /// <param name="suplAccPayWork">SuplAccPayWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d���攃�|���z�}�X�^�����폜��A�W�v���R�[�h���X�V���܂�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.25</br>
        int DeleteTotalAccPay(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            object suplAccPayWork);

        /// <summary>
        /// �d����x�����z�}�X�^�����폜��A�W�v���R�[�h���X�V���܂��B
        /// </summary>
        /// <param name="suplierPayWork">SuplierPayWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d����x�����z�}�X�^�����폜��A�W�v���R�[�h���X�V���܂�</br>
        /// <br>Programmer : 22008�@�����@���n</br>
        /// <br>Date       : 2008.06.25</br>
        int DeleteTotalSuplierPay(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            object suplierPayWork);
        
    }
}
