using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d���N�Ԏ���DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���N�Ԏ���DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ���� ���n</br>
    /// <br>Date       : 2008.11.20</br>
    /// <br>Update Note: 2012/09/18 FSI���� ���T</br>
    /// <br>             �d���摍���Ή�</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISuppYearResultDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �d���N�Ԏ��т�S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="suppYearResultAccPayWork">�c���Ɖ�����ʃN���X</param>
        /// <param name="suppYearResultSuppResultWorkList">���яƉ�����ʃ��X�g</param>
        /// <param name="suppYearResultCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���� ���n</br>
        /// <br>Date       : 2008.11.20</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKOU04126D", "Broadleaf.Application.Remoting.ParamData.SuppYearResultAccPayWork")]
			out object suppYearResultAccPayWork,
            [CustomSerializationMethodParameterAttribute("PMKOU04126D", "Broadleaf.Application.Remoting.ParamData.SuppYearResultSuppResultWork")]
			out object suppYearResultSuppResultWorkList,
            object suppYearResultCndtnWork);

        // --- ADD 2012/09/18 ---------->>>>>
        #region �d���摍��
        /// <summary>
        /// �d���N�Ԏ��т�S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="suppYearResultAccPayWork">�c���Ɖ�����ʃN���X</param>
        /// <param name="suppYearResultSuppResultWorkList">���яƉ�����ʃ��X�g</param>
        /// <param name="suppYearResultCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI���� ���T</br>
        /// <br>Date       : 2012/09/18</br>
        [MustCustomSerialization]
        int SearchSuppSum(
            [CustomSerializationMethodParameterAttribute("PMKOU04126D", "Broadleaf.Application.Remoting.ParamData.SuppYearResultAccPayWork")]
			out object suppYearResultAccPayWork,
            [CustomSerializationMethodParameterAttribute("PMKOU04126D", "Broadleaf.Application.Remoting.ParamData.SuppYearResultSuppResultWork")]
			out object suppYearResultSuppResultWorkList,
            object suppYearResultCndtnWork);
        #endregion �d���摍��
        // --- ADD 2012/09/18 ----------<<<<<

        #endregion

        // --- ADD 2012/11/08 ---------->>>>>
        /// <summary>
        /// ���_�ʎd���攃�|���z�}�X�^�����擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">�v�㋒�_�R�[�h</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="prevTotalDay">�v��N����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : FSI���� ���T</br>
        /// <br>Date       : 2012/11/08</br>
        int SearchMonthlyAccPay(string enterpriseCode, string sectionCode, int supplierCd, out DateTime prevTotalDay);
        // --- ADD 2012/11/08 ----------<<<<<
    }
}
