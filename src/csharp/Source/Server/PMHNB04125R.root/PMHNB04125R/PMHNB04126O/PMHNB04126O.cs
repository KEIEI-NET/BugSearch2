using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// ���Ӑ�ߔN�x���яƉ�DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : ���Ӑ�ߔN�x���яƉ�DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 30350 �N�� ����</br>
	/// <br>Date       : 2008.10.8</br>
	/// <br></br>
    /// <br>Update Note: 2010/08/02 chenyd</br>
    /// <br>             Excel�A�e�L�X�g�o�͑Ή�</br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ICustomInqOrderWorkDB
	{
        
        /// <summary>
        /// ���Ӑ�ߔN�x���яƉ��LIST��S�Ė߂��܂��i�_���폜�����j
		/// </summary>
        /// <param name="customInqResultWorkList">��������</param>
        /// <param name=" customInqOrderCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
        /// <br>Programmer : 30350 �N�� ����</br>
		/// <br>Date       : 2008.10.8</br>
        [MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMHNB04127D", "Broadleaf.Application.Remoting.ParamData.CustomInqResultWork")]
			out object customInqResultWorkList,
         object customInqOrderCndtnWork,
			int readMode,
            ConstantManagement.LogicalMode logicalMode);

        #region SearchAll
        // ---------------------- ADD 2010/08/02 --------------------------------->>>>>
        /// <summary>
        /// ���Ӑ�ߔN�x���яƉ��LIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name=" paraList">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2010/08/02</br>
        /// </remarks>
        //[MustCustomSerialization]
        int SearchAll(
			out object retObj,
        object paraList,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);
        // ---------------------- ADD 2010/08/02 ---------------------------------<<<<<
        #endregion

    }
}
