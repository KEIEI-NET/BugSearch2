//**********************************************************************//
// System           :   PM.NS
// Sub System       :
// Program name     :   �����X�VDB RemoteObject�C���^�[�t�F�[�X
//                  :   SFUKK01363O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programer        :   ���i�@��
// Date             :   2005.08.08
//----------------------------------------------------------------------//
// Update Note      :
// ---------------------------------------------------------------------
// 2007.01.23 T.Kimura : MA.NS�p�ɕύX
// 2008.01.11 A.Yamada : �_���폜�@�\��ǉ�(LogicalDelete)
// 2008.04.25 21112    : PM.NS�p�ɕύX
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co,. Ltd
//**********************************************************************//
using System;
using System.Collections;
using System.Data.SqlClient;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// �����X�VDB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       :�����X�VDB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 95089�@���i�@��</br>
	/// <br>Date       : 2005.08.08</br>
    /// <br>Update Note : 2010.05.06 gejun</br>
    /// <br>              M1007A-�x����`�f�[�^�X�V�ǉ�</br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface IDepsitMainDB
	{
		/// <summary>
        /// �����A��`�X�V����
		/// </summary>
		/// <param name="depsitDataWorkByte">������񃏁[�N</param>
		/// <param name="depositAlwWorkListByte">����������񃏁[�N</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �������E�����������E��`�f�[�^�����Ƀf�[�^�X�V���s���܂�</br>
        /// <br>           : �����ԍ������̎��A�V�K�����E��`�f�[�^�쐬�Ƃ��܂�</br>
		/// <br>           : �_���폜�𗧂Ă��ꍇ�A�폜�������s���܂�</br>
		/// <br>           : ���������̍폜���s���ꍇ�͍폜�������������R�[�h�̂ݘ_���폜�𗧂Ă܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		int Write(ref byte[] depsitDataWorkByte, ref byte[] depositAlwWorkListByte);
        // --------------- ADD START 2010.05.06 gejun FOR M1007A-M1007A-�x����`�f�[�^�X�V�ǉ�------->>>>
        /// <summary>
        /// �����A��`�X�V����
        /// </summary>
        /// <param name="depsitDataWorkByte">������񃏁[�N</param>
        /// <param name="depositAlwWorkListByte">����������񃏁[�N</param>
        /// <param name="rcvDraftDataWorkUpdByte">��`�f�[�^�i�X�V�p�j���[�N</param>
        /// <param name="rcvDraftDataWorkDelByte">��`�f�[�^�i�폜�p�j���[�N</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �������E�����������E��`�������Ƀf�[�^�X�V���s���܂�</br>
        /// <br>           : �����ԍ������̎��A�V�K�����쐬�Ƃ��܂�</br>
        /// <br>           : �_���폜�𗧂Ă��ꍇ�A�폜�������s���܂�</br>
        /// <br>           : ���������̍폜���s���ꍇ�͍폜�������������R�[�h�̂ݘ_���폜�𗧂Ă܂�</br>
        /// <br>Note�@�@�@  : ��`���̍X�V�������s���܂��B</br>
        /// <br>Programmer  : ���R</br>
        /// <br>Date        : 2010/05/06</br>
        /// </remarks>
        int WriteWithDraftData(ref byte[] depsitDataWorkByte, ref byte[] depositAlwWorkListByte, byte[] rcvDraftDataWorkUpdByte, byte[] rcvDraftDataWorkDelByte);
        // --------------- ADD END 2010.05.06 gejun FOR M1007A-M1007A-�x����`�f�[�^�X�V�ǉ�------->>>>
		/// <summary>
		/// �����Ǎ�����
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
		/// <param name="depsitDataWorkByte">�������</param>
		/// <param name="depositAlwWorkListByte">�����������</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������E����������������ԍ������Ƀf�[�^�擾���s���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		//int Read(string EnterpriseCode, int DepositSlipNo, out byte[] depsitDataWorkByte, out byte[] depositAlwWorkListByte);  //DEL 2008/04/25 M.Kubota
        int Read(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out byte[] depsitDataWorkByte, out byte[] depositAlwWorkListByte);  //ADD 2008/04/25 M.Kubota

        // �� 2008.01.11 980081 a
        /// <summary>
        /// �����_���폜����
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵�������ԍ��̓������E�����������_���폜���s���܂�</br>
        /// <br>           : ���������f�[�^�̍폜�Ɏg�p���܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        //int LogicalDelete(string EnterpriseCode, int DepositSlipNo);  //DEL 2008/04/25 M.Kubota
        int LogicalDelete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus);  //ADD 2008/04/25 M.Kubota

        /// <summary>
        /// �����_���폜����
        /// </summary>
        /// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="RetDepsitDataWorkByte">�X�V�����f�[�^(�ԍ폜���̌������R�[�h)</param>
        /// <param name="RetDepositAlwWorkListByte">�X�V���������f�[�^(�ԍ폜���̌����������R�[�h)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肵�������ԍ��̓������E�����������_���폜���s���܂�</br>
        /// <br>           : ���������f�[�^�̍폜�Ɏg�p���܂�</br>
        /// <br>Programmer : 980081 �R�c ���F</br>
        /// <br>Date       : 2008.01.11</br>
        /// </remarks>
        //int LogicalDelete(string EnterpriseCode, int DepositSlipNo, out byte[] RetDepsitDataWorkByte, out byte[] RetDepositAlwWorkListByte);  //DEL 2008/04/25 M.Kubota
        int LogicalDelete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out byte[] RetDepsitDataWorkByte, out byte[] RetDepositAlwWorkListByte);  //ADD 2008/04/25 M.Kubota
        // �� 2008.01.11 980081 a

		/// <summary>
		/// �����폜����
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�������ԍ��̓������E�����������폜���s���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		//int Delete(string EnterpriseCode, int DepositSlipNo);                     //DEL 2008/04/25 M.Kubota
        int Delete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus);  //ADD 2008/04/25 M.Kubota
        

		/// <summary>
		/// �����폜����
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
		/// <param name="RetDepsitDataWorkByte">�X�V�����f�[�^(�ԍ폜���̌������R�[�h)</param>
		/// <param name="RetDepositAlwWorkListByte">�X�V���������f�[�^(�ԍ폜���̌����������R�[�h)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�������ԍ��̓������E�����������폜���s���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		//int Delete(string EnterpriseCode, int DepositSlipNo, out byte[] RetDepsitDataWorkByte, out byte[] RetDepositAlwWorkListByte);  //DEL 2008/04/25 M.Kubota
        int Delete(string EnterpriseCode, int DepositSlipNo, int AcptAnOdrStatus, out byte[] RetDepsitDataWorkByte, out byte[] RetDepositAlwWorkListByte);  //ADD 2008/04/25 M.Kubota

		/// <summary>
		/// �����ꊇ�쐬�����i�󒍎w��^�j
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
        /// <param name="createDepsitMainWorkListByte">�����X�V�f�[�^�p�����[�^(�󒍎w��^)</param>
		/// <param name="depositSlipNoList">�X�V���������f�[�^�̓����ԍ��z��</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �ꊇ�쐬�p�p�����[�^����w��󒍂ւ̈����X�V�E�����V�K�쐬�������s���܂�</br>
		/// <br>           : �󒍎w��^��p�ł���A�V�K�����E�����̂ݍs���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.11</br>
		/// </remarks>
		int Write(string EnterpriseCode, byte[] createDepsitMainWorkListByte, out int[] depositSlipNoList);

        // �� 20070124 18322 c MA.NS�p�ɕύX
		//int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo );
		//int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, DateTime AddUpADate, int DepositSlipNo, out byte[] RetDepsitDataWorkListByte, out byte[] RetDepositAlwWorkListByte);

		/// <summary>
		/// �ԓ����쐬����
		/// </summary>
		/// <param name="mode">0:�ԓ����쐬 1:�ԓ����E�V�������쐬</param>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="UpdateSecCd">�X�V���_�R�[�h</param>
		/// <param name="DepositAgentCode">�����S���҃R�[�h</param>
		/// <param name="DepositAgentNm">�����S���Җ�</param>
		/// <param name="AddUpADate">�v���</param>
		/// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�������ԍ��̐ԓ����쐬�������s���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.26</br>
        /// <br></br>
        /// <br>Update Note: 2007.01.24 18322 T.Kimura MA.NS�p�ɕύX</br>
        /// <br></br>
		/// </remarks>
		//int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo );     //DEL 2008/04/25 M.Kubota
        int RedCreate(int mode, string EnterpriseCode, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, int AcptAnOdrStatus);  //ADD 2008/04/25 M.Kubota

		/// <summary>
		/// �ԓ����쐬����
		/// </summary>
		/// <param name="mode">0:�ԓ����쐬 1:�ԓ����E�V�������쐬</param>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="UpdateSecCd">�X�V���_�R�[�h</param>
		/// <param name="DepositAgentCode">�����S���҃R�[�h</param>
		/// <param name="DepositAgentNm">�����S���Җ�</param>
		/// <param name="AddUpADate">�v���</param>
		/// <param name="DepositSlipNo">�����ԍ�</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
		/// <param name="RetDepsitDataWorkListByte">�X�V����MT���R�[�h</param>
		/// <param name="RetDepositAlwWorkListByte">�X�V��������MT���R�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�������ԍ��̐ԓ����쐬�������s���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.26</br>
        /// <br></br>
        /// <br>Update Note: 2007.01.24 18322 T.Kimura MA.NS�p�ɕύX</br>
        /// <br></br>
		/// </remarks>
        //int RedCreate(int mode, string EnterpriseCode, int DepositCd, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, out byte[] RetDepsitDataWorkListByte, out byte[] RetDepositAlwWorkListByte);  //DEL 2008/04/25 M.Kubota
        int RedCreate(int mode, string EnterpriseCode, string UpdateSecCd, string DepositAgentCode, string DepositAgentNm, DateTime AddUpADate, int DepositSlipNo, int AcptAnOdrStatus, out byte[] RetDepsitDataWorkListByte, out byte[] RetDepositAlwWorkListByte);                   //ADD 2008/04/25 M.Kubota
        // �� 20070124 18322 c

        // �� 20070518 18322 d �e�X�g�p���W�b�N�̈׍폜
		//int ReadDmdSalesRec(string EnterpriseCode, int ClaimCode, out byte[] dmdSalesWorkListByte);	// ��
        // �� 20070518 18322 d
	}
}
