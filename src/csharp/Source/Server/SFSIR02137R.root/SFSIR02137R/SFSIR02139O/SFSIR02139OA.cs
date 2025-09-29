using System;
using System.Collections;
using System.Data.SqlClient;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �x���X�VDB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       :�x���X�VDB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 99033�@��{�@�E</br>
	/// <br>Date       : 2005.08.08</br>
	/// <br></br>
	/// <br>Update Note: 2006.12.22 �ؑ� ����</br>
	/// <br>             �g��.NS�p�ɐԓ`�̃C���^�[�t�F�[�X��ǉ�</br>
    /// <br></br>
    /// <br>Update Note: 2008.01.11 �R�c ���F</br>
    /// <br>             �_���폜�@�\��ǉ�(LogicalDelete)</br>
    /// <br>Update Note : 2010.04.27 gejun</br>
    /// <br>              M1007A-�x����`�f�[�^�X�V�ǉ�</br>
    //  <br>Update Note : 2013/02/21 �e�c ���V 
    //                    �x���`�[�폜���A��`�f�[�^�R�t�������Ή�
    //----------------------------------------------------------------------//
    /// <br></br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
    public interface IPaymentSlpDB
	{
		/// <summary>
		/// �x���X�V����
		/// </summary>
		/// <param name="paymentSlpWorkByte">�x����񃏁[�N</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �x�����E�x�������������Ƀf�[�^�X�V���s���܂�</br>
		/// <br>           : �x���ԍ������̎��A�V�K�x���쐬�Ƃ��܂�</br>
		/// <br>           : �_���폜�𗧂Ă��ꍇ�A�폜�������s���܂�</br>
		/// <br>           : �x�������̍폜���s���ꍇ�͍폜�������������R�[�h�̂ݘ_���폜�𗧂Ă܂�</br>
		/// <br>Programmer : 95089 ��{�@�E</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
        int Write(ref byte[] paymentSlpWorkByte);
        // --- ADD 2012/10/11 -------------------------------------------------->>>>>
        /// <summary>
        /// �x���A��`(�x���E���)�X�V����
        /// </summary>
        /// <param name="paymentSlpWorkByte">�x����񃏁[�N</param>
        /// <param name="payDraftDataWorkByte">�x����`�f�[�^���[�N</param>
        /// <param name="payDraftDataDelWorkByte">�x����`�f�[�^���[�N(�폜�p)</param>
        /// <param name="rcvDraftDataWorkByte">����`�f�[�^���[�N</param>
        /// <param name="rcvDraftDataDelWorkByte">����`�f�[�^���[�N(�폜�p)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �x�����E�x���������E��`�f�[�^�����Ƀf�[�^�X�V���s���܂�</br>
        /// <br>           : �x���ԍ������̎��A�V�K�x���E��`�f�[�^�쐬�Ƃ��܂�</br>
        /// <br>           : �_���폜�𗧂Ă��ꍇ�A�폜�������s���܂�</br>
        /// <br>           : �x�������̍폜���s���ꍇ�͍폜�������������R�[�h�̂ݘ_���폜�𗧂Ă܂�</br>
        /// <br>Programmer : �{�{</br>
        /// <br>Date       : 2012.10.11</br>
        /// </remarks>
        int WriteWithDraft(ref byte[] paymentSlpWorkByte, byte[] payDraftDataWorkByte, byte[] payDraftDataDelWorkByte
                                                        , byte[] rcvDraftDataWorkByte, byte[] rcvDraftDataDelWorkByte);
        // --- ADD 2012/10/11 --------------------------------------------------<<<<<
        // --------------- ADD START 2010.04.27 gejun FOR M1007A-M1007A-�x����`�f�[�^�X�V�ǉ�------->>>>
        /// <summary>
        /// �x���A��`�X�V����
        /// </summary>
        /// <param name="paymentSlpWorkByte">�x����񃏁[�N</param>
        /// <param name="payDraftDataWorkByte">�x����`�f�[�^���[�N</param>
        /// <param name="payDraftDataDelWorkByte">�x����`�f�[�^���[�N(�폜�p)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �x�����E�x���������E��`�f�[�^�����Ƀf�[�^�X�V���s���܂�</br>
        /// <br>           : �x���ԍ������̎��A�V�K�x���E��`�f�[�^�쐬�Ƃ��܂�</br>
        /// <br>           : �_���폜�𗧂Ă��ꍇ�A�폜�������s���܂�</br>
        /// <br>           : �x�������̍폜���s���ꍇ�͍폜�������������R�[�h�̂ݘ_���폜�𗧂Ă܂�</br>
        /// <br>Programmer : gejun</br>
        /// <br>Date       : 2010.04.27</br>
        /// </remarks>
        int WriteWithPayDraft(ref byte[] paymentSlpWorkByte, byte[] payDraftDataWorkByte, byte[] payDraftDataDelWorkByte);
        // --------------- END START 2010.04.27 gejun FOR M1007A-M1007A-�x����`�f�[�^�X�V�ǉ�-------->>>>
		/// <summary>
		/// �x���Ǎ�����
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="paymentSlipNo">�x���ԍ�</param>
		/// <param name="paymentSlpWorkByte">�x�����</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �x�������x���ԍ������Ƀf�[�^�擾���s���܂�</br>
		/// <br>Programmer : 95089 ��{�@�E</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		int Read(string EnterpriseCode, int paymentSlipNo, out byte[] paymentSlpWorkByte);

        // �� 2008.01.11 980081 a
        ///// <summary>
        ///// �x���_���폜����
        ///// </summary>
        ///// <param name="EnterpriseCode">��ƃR�[�h</param>
        ///// <param name="DepositSlipNo">�x���ԍ�</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : �w�肵���x���ԍ��̎x�����_���폜���s���܂�</br>
        ///// <br>Programmer : 980081 �R�c ���F</br>
        ///// <br>Date       : 2008.01.11</br>
        ///// </remarks>
        //int LogicalDelete(string EnterpriseCode, int DepositSlipNo);

        ///// <summary>
        ///// �x���_���폜����
        ///// </summary>
        ///// <param name="EnterpriseCode">��ƃR�[�h</param>
        ///// <param name="paymentSlipNo">�x���ԍ�</param>
        ///// <param name="RetPaymentSlpWorkByte">�X�V�x���f�[�^(�ԍ폜���̌������R�[�h)</param>
        ///// <returns>STATUS</returns>
        ///// <remarks>
        ///// <br>Note       : �w�肵���x���ԍ��̎x�����_���폜���s���܂�</br>
        ///// <br>Programmer : 980081 �R�c ���F</br>
        ///// <br>Date       : 2008.01.11</br>
        ///// </remarks>
        //int LogicalDelete(string EnterpriseCode, int paymentSlipNo, out byte[] RetPaymentSlpWorkByte);
        // �� 2008.01.11 980081 a

		/// <summary>
		/// �x���폜����
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="PaymentSlipNo">�x���ԍ�</param>
        /// <param name="payDraftDataWorkByte">�x����`���</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵���x���ԍ��̎x�����폜���s���܂�</br>
		/// <br>Programmer : 95089 ��{�@�E</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
        // --- UPD 2013/02/21 Y.Wakita ---------->>>>>
        //int Delete(string EnterpriseCode, int PaymentSlipNo);
        int Delete(string EnterpriseCode, int PaymentSlipNo, byte[] payDraftDataWorkByte);
        // --- UPD 2013/02/21 Y.Wakita ----------<<<<<


		/// <summary>
		/// �x���폜����
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="PaymentSlipNo">�x���ԍ�</param>
        /// <param name="payDraftDataWorkByte">�x����`���</param>
        /// <param name="RetPaymentSlpWorkByte">�X�V�x���f�[�^(�ԍ폜���̌������R�[�h)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵���x���ԍ��̎x�����폜���s���܂�</br>
		/// <br>Programmer : 95089 ��{�@�E</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
        // --- UPD 2013/02/21 Y.Wakita ---------->>>>>
        //int Delete(string EnterpriseCode, int PaymentSlipNo, out byte[] RetPaymentSlpWorkByte);
        int Delete(string EnterpriseCode, int PaymentSlipNo, byte[] payDraftDataWorkByte, out byte[] RetPaymentSlpWorkByte);
        // --- UPD 2013/02/21 Y.Wakita ----------<<<<<

        // �� 20061222 18322 c �ԓ`�ׂ̈̃C���^�[�t�F�[�X��ǉ�
        /// <summary>
        /// �x���`�[�ԓ`����
        /// </summary>
        /// <param name="Mode">�ԓ`�쐬���[�h 0:�ԓ����쐬</param>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="UpdateSecCd">�X�V���_�R�[�h</param>
        /// <param name="PaymentAgentCode">�x���S���҃R�[�h</param>
        /// <param name="PaymentAgentNm">�x���S���Җ�</param>
        /// <param name="AddUpADate">�v���</param>
        /// <param name="PaymentSlipNo">�x���`�[�ԍ�(�ԓ`���s�����`)</param>
        /// <param name="RetPaymentSlpWorkList">�x���`�[�}�X�^(�X�V����)</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���x���`�[�ԍ��̐Ԏx���쐬�������s���܂�</br>
        /// <br>Programmer : 18322 �ؑ� ����</br>
        /// <br>Date       : 2006.12.22</br>
        /// </remarks>
        [MustCustomSerialization]
        int RedCreate(int Mode,
                      string EnterpriseCode,
                      string UpdateSecCd,
                      string PaymentAgentCode,
                      string PaymentAgentNm,
                      DateTime AddUpADate,
                      int PaymentSlipNo,
                      [CustomSerializationMethodParameterAttribute("SFSIR02140D", "Broadleaf.Application.Remoting.ParamData.PaymentDataWork")]
                      out object RetPaymentSlpWorkList);
        // �� 20061222 18322 c

		//int Write(string EnterpriseCode, byte[] createDepsitMainWorkListByte);
		//int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo );
		//int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo, out byte[] RetDepsitMainWorkListByte, out byte[] RetDepositAlwWorkListByte);
		//int ReadDmdSalesRec(string EnterpriseCode, int ClaimCode, out byte[] dmdSalesWorkListByte);	// ��
	}
}
