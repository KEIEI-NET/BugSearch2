using System;
using System.Collections;
using System.Data.SqlClient;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ������������DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       :������������DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 95089�@���i�@��</br>
	/// <br>Date       : 2005.08.08</br>
	/// <br></br>
    /// <br>Update Note: 2008.03.07 980081 �R�c ���F ���ʊ�Ή�</br>
    /// <br>Update Note: K2014/05/28 11001635-00 zhujw ���J�g�\�ʑΉ�</br>
    /// <br>Update Note: K2014/06/19 11001635-00 zhujw RedMine#42902</br>
    /// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface IControlDepsitAlwDB
	{
        // --- ADD zhujw K2014/05/28 ���J�g�\�ʑΉ� ------->>>>> 
        /// <summary>
        /// �����`�[����(����w��^)���X�g�̎擾�����B
        /// </summary>
        /// <param name="ControlKaToDepsitAlwResultWork">��������</param>
        /// <param name="ControlKaToDepsitAlwCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note        : �����`�[����(����w��^)�̃L�[�l����v����A�S�Ă̔���f�[�^�e�L�X�g�����擾���܂��B</br>
        /// <br>Programmer	: zhujw</br>
        /// <br>Date		: K2014/05/28</br>
        [MustCustomSerialization]
        int Search(
            //[CustomSerializationMethodParameterAttribute("SFUKK01484DC", "Broadleaf.Application.Remoting.ParamData.ControlKaToDepsitAlwWork")] // DEL zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p����
            [CustomSerializationMethodParameterAttribute("SFUKK01346D", "Broadleaf.Application.Remoting.ParamData.DepositAlwWork")] // ADD zhujw K2014/06/19 RedMine#42902 �����̃f�[�^�p�����[�^���g�p����
            out object ControlKaToDepsitAlwResultWork,
            object ControlKaToDepsitAlwCndtnWork);
        // --- ADD zhujw K2014/05/28 ���J�g�\�ʑΉ� -------<<<<<

		/// <summary>
		/// ���������폜
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="CustomerCode">���Ӑ�R�[�h</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="SalesSlipNum">����`�[�ԍ�</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note       : �w�肵�����Ӑ�R�[�h�E�󒍃X�e�[�^�X�E����`�[�ԍ��Ɉ������Ă����������MT���폜���A����MT�̈����z�����Z�X�V���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 �R�c ���F ���ʊ�Ή�</br>
        /// </remarks>
        // �� 2008.03.07 980081 c 
        //int DeleteDB(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo);
        int DeleteDB(string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum);
        // �� 2008.03.07 980081 c

		/// <summary>
		/// �����������擾
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="CustomerCode">���Ӑ�R�[�h</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="SalesSlipNum">����`�[�ԍ�</param>
        /// <param name="depositAlwWorkListByte">�����������z��</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�����Ӑ�R�[�h�E�󒍔ԍ��Ɉ������Ă����������MT���擾���Ԃ��܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 �R�c ���F ���ʊ�Ή�</br>
        /// </remarks>
        // �� 2008.03.07 980081 c
        //int ReadDB(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, out byte[] depositAlwWorkListByte);
        int ReadDB(string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum, out byte[] depositAlwWorkListByte);
        // �� 2008.03.07 980081 c

		/// <summary>
		/// ���������`�F�b�N����
		/// </summary>
		/// <param name="mode">�ԍ����������擾�敪 0:�J�E���g���� 1:�J�E���g���Ȃ�</param>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="CustomerCode">���Ӑ�R�[�h</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="SalesSlipNum">����`�[�ԍ�</param>
        /// <param name="count">����������</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�����Ӑ�R�[�h�E�󒍔ԍ��Ɉ������Ă���������������擾���Ԃ��܂�</br>
		///	<br>           : mode��1���w�肷�邱�ƂŁA�ԓ����E���E�ςݍ������ւ̈������𖢃J�E���g�ɂ��邱�Ƃ��ł��܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2005.08.18</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 �R�c ���F ���ʊ�Ή�</br>
        /// </remarks>
        // �� 2008.03.07 980081 c
        //int GetCountDB(int mode, string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, out int count);
        int GetCountDB(int mode, string EnterpriseCode, int CustomerCode, int AcptAnOdrStatus, string SalesSlipNum, out int count);
        // �� 2008.03.07 980081 c

        // �� 20070131 18322 c MA.NS�p�ɕύX
		//int CreateRedDepositAllowance(string EnterpriseCode, int CustomerCode, int AcceptAnOrderNo, int NewAcceptAnOrderNo);

		/// <summary>
		/// ���ԓ`�쐬�����������ԍ쐬����
		/// </summary>
		/// <param name="EnterpriseCode">��ƃR�[�h</param>
		/// <param name="CustomerCode">���Ӑ�R�[�h</param>
        /// <param name="AcptAnOdrStatus">�󒍃X�e�[�^�X</param>
        /// <param name="SalesSlipNum">����`�[�ԍ�</param>
        /// <param name="depositAgentCode">�����S���҃R�[�h</param>
		/// <param name="depositAgentNm">�����S���Җ�</param>
		/// <param name="akaAddUpADate">�ԓ`�v���</param>
        /// <param name="NewSalesSlipNum">�ԓ`����`�[�ԍ�</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �w�肵�����Ӑ�R�[�h�E�󒍔ԍ��Ɉ������Ă����������MT����Ԏ󒍂ɑ΂���Ԉ����쐬���A����MT�̈����z�����Z�X�V���܂�</br>
		/// <br>Programmer : 95089 ���i�@��</br>
		/// <br>Date       : 2006.03.07</br>
        /// <br></br>
        /// <br>Update Note: 2008.03.07 980081 �R�c ���F ���ʊ�Ή�</br>
        /// </remarks>
        // ���ԓ`�쐬�����������ԍ쐬����
        // �� 2008.03.07 980081 c
        //int CreateRedDepositAllowance(string EnterpriseCode
        //                             , int CustomerCode
        //                             , int AcceptAnOrderNo
        //                             , string depositAgentCode
        //                             , string depositAgentNm
        //                             , DateTime akaAddUpADate
        //                             , int NewAcceptAnOrderNo);
        int CreateRedDepositAllowance(string EnterpriseCode
                                     , int CustomerCode
                                     , int AcptAnOdrStatus
                                     , string SalesSlipNum
                                     , string depositAgentCode
                                     , string depositAgentNm
                                     , DateTime akaAddUpADate
                                     , string NewSalesSlipNum);
        // �� 2008.03.07 980081 c
        // �� 20070131 18322 c
	}
}
