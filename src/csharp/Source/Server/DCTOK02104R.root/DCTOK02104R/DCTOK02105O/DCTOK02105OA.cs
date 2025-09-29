using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �O�N�Δ�\DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �O�N�Δ�\DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 980081 �R�c ���F</br>
    /// <br>Date       : 2007.11.29</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPrevYearComparisonDB
    {

        /// <summary>
        /// �O�N�Δ�\��߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̑O�N�Δ�\��߂��܂�</br>
        /// <br>           : 12�����𒴂���͈͂��w�肳�ꂽ��Y���f�[�^�����Ƃ��܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.11.29</br>
        [MustCustomSerialization]
        int SearchPrevYearComparison([CustomSerializationMethodParameterAttribute("DCTOK02106D", "Broadleaf.Application.Remoting.ParamData.RsltInfo_PrevYearComparisonWork")]out object retObj, object paraObj);

    }
}
