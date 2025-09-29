//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�X�^����M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/07/26  �C�����e : SCM�Ή�-���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/26  �C�����e : DC�������O��DC�e�f�[�^�̃N���A������ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Library.Collections;
using System.Collections;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// DC�R���g���[��DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : DC�R���g���[��DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_Center_UserAP)]
    public interface IMstDCControlDB
    {
        /// <summary>
        /// �f�[�^���擾���܂��B
        /// </summary>
        /// <param name="masterDivList">�}�X�^�敪</param>
        /// <param name="pmEnterpriseCodes">PM��ƃR�[�h</param>
        /// <param name="BeginningDate">��������</param>
        /// <param name="EndingDate">��������</param>
        /// <param name="retCSAList">�X�V�f�[�^</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�擾</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchCustomSerializeArrayList(
            ArrayList masterDivList,
            string pmEnterpriseCodes,
            Int64 BeginningDate,
            Int64 EndingDate,
            ref CustomSerializeArrayList retCSAList,
            out string retMessage);

        /// <summary>
        /// DC�R���g���[�������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="retCSAList">�X�V�f�[�^</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        int Update(ref CustomSerializeArrayList retCSAList, string enterpriseCode, out string retMessage);

        #region ADD 2011/07/26 ������  SCM�Ή�-���_�Ǘ��i10704767-00�j
        /// <summary>
        /// �}�X�^��M�̃f�[�^��������
        /// </summary>
        /// <param name="masterDivList">�}�X�^�敪</param>
        /// <param name="pmEnterpriseCodes">PM��ƃR�[�h</param>
        /// <param name="paramList">�}�X�^���o�����N���X</param>
        /// <param name="retCSAList">�X�V�f�[�^</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^���M����READ�̎��f�[�^�������s���N���X�ł��B</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.07.26</br>
        int SearchCustomSerializeArrayList(ArrayList masterDivList, string pmEnterpriseCodes, ArrayList paramList, ref CustomSerializeArrayList retCSAList, out string retMessage);

        /// <summary>
        /// DC�R���g���[�������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.07.30</br>
        /// </remarks>
        int Update(ref CustomSerializeArrayList retCSAList, string enterpriseCode, ArrayList logList, out string retMessage);

        /// <summary>
        /// �}�X�^��M�̃f�[�^��������
        /// </summary>
        /// <param name="pmEnterpriseCodes">PM��ƃR�[�h</param>
        /// <param name="secMngSndRcvWork">�}�X�^�敪</param>
        /// <param name="param">�}�X�^���o�����N���X</param>
        /// <param name="count">�߂錏��</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^���M����READ�̎��f�[�^�������s���N���X�ł��B</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.07.26</br>
        int GetObjCount(string pmEnterpriseCodes, DCSecMngSndRcvWork secMngSndRcvWork, object param, ref int count, out string retMessage);
        #endregion ADD 2011/07/26 ������  SCM�Ή�-���_�Ǘ��i10704767-00�j

		// ADD 2011.08.26 ���� ---------->>>>>
		/// <summary>
		/// DC�������O��DC�e�f�[�^�̃N���A������ǉ�
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <remarks>
		/// <br>Note       : ���ɂȂ�</br>
		/// <br>Programmer : ����</br>
		/// <br>Date       : 2011.08.26</br>
		/// </remarks>
        //int DCMSDataClear(string enterpriseCode);//DEL by Liangsd     2011/09/06
		// ADD 2011.08.26 ���� ----------<<<<<
    }
}
