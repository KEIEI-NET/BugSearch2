using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{

	/// <summary>
    /// �x���m�F�\DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �x���m�F�\DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 980081 �R�c ���F</br>
	/// <br>Date       : 2007.09.20</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IPaymentListWorkDB
	{
		/// <summary>
        /// �x���m�F�\(�����E�ڍ�)LIST��߂��܂�
		/// </summary>
        /// <param name="paymentSlpListResultWork">��������(�����E�ڍ�)</param>
        /// <param name="paymentSlpCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : </br>
		/// <br>Programmer : 980081 �R�c ���F</br>
		/// <br>Date       : 2007.09.20</br>
        [MustCustomSerialization]
		int SearchDepsitOnly(
            [CustomSerializationMethodParameterAttribute("DCKAK02536D", "Broadleaf.Application.Remoting.ParamData.PaymentSlpListResultWork")]
            out object paymentSlpListResultWork,
            object paymentSlpCndtnWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);


        /// <summary>
        /// �x���m�F�\(����ʏW�v)LIST��߂��܂�
        /// </summary>
        /// <param name="paymentSlpListResultWork">��������(����ʏW�v)</param>
        /// <param name="paymentSlpCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.09.20</br>
        [MustCustomSerialization]
        int SearchDepsitKind(
            [CustomSerializationMethodParameterAttribute("DCKAK02536D", "Broadleaf.Application.Remoting.ParamData.PaymentSlpListResultWork")]
            out object paymentSlpListResultWork,
            object paymentSlpCndtnWork,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);

        // 2008/07/07 DEL-Start ��7/8���r���[�ő����v�͕s�v�ƂȂ��� -------------- >>>>>
        #region �����v�^�C�v�͍폜
        /*
        /// <summary>
        /// �x���m�F�\(�����v)LIST��߂��܂�
        /// </summary>
        /// <param name="paymentSlpListResultWork">��������(�����v)</param>
        /// <param name="paymentSlpListCndtnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="sectionDepositDiv">sectionDepositDiv</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2007.09.20</br>
        [MustCustomSerialization]
        int SearchAllTotal(
            [CustomSerializationMethodParameterAttribute("DCKAK02536D", "Broadleaf.Application.Remoting.ParamData.PaymentSlpListResultWork")]
			out object paymentSlpListResultWork,
            object paymentSlpListCndtnWork,
            int readMode,
            int sectionDepositDiv,
            ConstantManagement.LogicalMode logicalMode);
         */
        #endregion
        // 2008/07/07 DEL-End ---------------------------------------------------- <<<<<
    }
}
