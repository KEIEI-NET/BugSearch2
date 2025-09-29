//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^���M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/21  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Collections;
using System.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �f�[�^���M�����pDB Access RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �f�[�^���M�����pDB Access RemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.04.02</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IAPSendMessageDB
    {
        /// <summary>
        /// �f�[�^�����ݒ�
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
		/// <param name="SecMngSetWorkList">��������</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�������ݒ肷��</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchLoadData(
            string enterpriseCodes,
            [CustomSerializationMethodParameterAttribute("PMKYO07003D", "Broadleaf.Application.Remoting.ParamData.APSecMngSetWork")]
			//out APSecMngSetWork SecMngSetWork,
			out ArrayList SecMngSetWorkList,
            out string retMessage);

        /// <summary>
        /// ���_�Ǘ��ݒ�}�X�^�̍X�V
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="updEmployeeCode">�]�ƈ��R�[�h</param>
        /// <param name="syncExecDt">�V���N���s���t</param>
		/// <param name="retMessage">�G���[���b�Z�[�W</param>
		/// <param name="baseCode">���M�Ώۋ��_�R�[�h</param>
		/// <param name="sendCode">���M�拒�_�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�Ǘ��ݒ�}�X�^�̍X�V����</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int UpdateSecMngSet(
            string enterpriseCodes,
            string updEmployeeCode,
            DateTime syncExecDt,
            out string retMessage
			,string baseCode
			,string sendCode);

		// DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
        /*
        /// <summary>
        /// �f�[�^���X�V���܂��B
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="BeginningDate">�J�n���t</param>
        /// <param name="EndingDate">�I�����t</param>
        /// <param name="retCSAList">��������</param>
        /// <param name="fileIds">�t�@�C��ID�z��</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�X�V</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchCustomSerializeArrayList(
            string enterpriseCodes,
            Int64 BeginningDate,
            Int64 EndingDate,
            ref CustomSerializeArrayList retCSAList,
            string[] fileIds,
            out string retMessage);
		*/
		// DEL 2011/07/28 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

        /// <summary>
        /// �f�[�^���X�V���܂��B
        /// </summary>
        /// <param name="enterPriseCode">��������</param>
        /// <param name="outreceiveList">��ƃR�[�h</param>
        /// <param name="sectionCodeList">���_���X�g</param>
        /// <param name="stockAcPayHistCount">����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�X�V</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        int UpdateCustomSerializeArrayList(string enterPriseCode, object outreceiveList, ArrayList sectionCodeList, ref int stockAcPayHistCount);

        /// <summary>
        /// �f�[�^���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCodes">���_�R�[�h</param>
        /// <param name="SecMngSetWorkList">���_�f�[�^</param>
        /// <param name="retMessage">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�擾</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchSecMngSetData(
            string enterpriseCodes,
            [CustomSerializationMethodParameterAttribute("PMKYO07003D", "Broadleaf.Application.Remoting.ParamData.APSecMngSetWork")]
            out ArrayList SecMngSetWorkList,
            out string retMessage);

        /// <summary>
        /// �f�[�^���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="secMngEpSetWorkList">���_���</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�擾</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        int SearchSecMngEpSetData(string enterpriseCode,
            [CustomSerializationMethodParameterAttribute("PMKYO07003D", "Broadleaf.Application.Remoting.ParamData.APSecMngEpSetWork")]
            out ArrayList secMngEpSetWorkList);

        /// <summary>
        /// ���_�����X�V���܂��B
        /// </summary>
        /// <param name="secMngSetWork">���_�}�X�^</param>
        /// <param name="newSyncExecDate">�V�b�N����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�擾</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        int UpdateSecMngSetData(APSecMngSetWork secMngSetWork, Int64 newSyncExecDate);

		/// <summary>
		/// �f�[�^���X�V���܂��B
		/// </summary>
		/// <param name="outreceiveList">��������</param>
		/// <param name="sendDataWork">��������</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="fileIds">�����f�[�^</param>
		/// <param name="errMsg">errMsg</param>
		/// <param name="sndRcvHisConsNo">sndRcvHisConsNo</param>
		/// <param name="updSectionCd">updSectionCd</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �f�[�^�X�V</br>
		/// <br>Programmer : ����</br>
		/// <br>Date       : 2011.7.21</br>
		[MustCustomSerialization]
		int SearchCustomSerializeArrayListSCM(out CustomSerializeArrayList outreceiveList, APSendDataWork sendDataWork,
			string sectionCode, string[] fileIds, out string errMsg, out int sndRcvHisConsNo, string updSectionCd);
    }
}
