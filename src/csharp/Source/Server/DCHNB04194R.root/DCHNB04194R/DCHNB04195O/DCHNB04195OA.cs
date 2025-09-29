using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
//using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ����N�Ԏ���DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����N�Ԏ���DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : ���쏹��</br>
    /// <br>Date       : 2007.10.26</br>
    /// <br></br>
    /// <br>Update Note: 2010/08/02 ����p  �e�L�X�g�o�͑Ή�</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISalesAnnualDataSelectResultDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// ����N�Ԏ��т�S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="salesAnnualDataSelectResultWork">��������</param>
        /// <param name="salesAnnualDataSelectParamWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���쏹��</br>
        /// <br>Date       : 2007.10.26</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("DCHNB04196D", "Broadleaf.Application.Remoting.ParamData.SalesAnnualDataSelectResultWork")]
			out object salesAnnualDataSelectResultWork,
           object salesAnnualDataSelectParamWork);

        /// <summary>
        /// �w�肳�ꂽ�����̎c���Ɖ�f�[�^��߂��܂�
        /// </summary>
        /// <param name="custsalesAnnualDataSelectResultWorkk">��������</param>
        /// <param name="paramWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̎c���Ɖ�f�[�^��߂��܂�</br>
        /// <br>Programmer : ���� �[���N</br>
        /// <br>Date       : 2008.09.22</br>
        [MustCustomSerialization]
        int CustSearch(
            [CustomSerializationMethodParameterAttribute("DCHNB04196D", "Broadleaf.Application.Remoting.ParamData.CustSalesAnnualDataSelectResultWork")]
            out object custsalesAnnualDataSelectResultWork,
          object salesAnnualDataSelectParamWork);

        // --- ADD 2010/08/02 -------------------------------->>>>>
        /// <summary>
        /// ����N�Ԏ��т�S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="retListObj">��������</param>
        /// <param name="paraList">�����p�����[�^���X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ����p</br>
        /// <br>Date       : 2010/08/02</br>
        int SearchAll(
			out object retListObj, object paraList);
        // --- ADD 2010/08/02 --------------------------------<<<<<

        #endregion
    }
}
