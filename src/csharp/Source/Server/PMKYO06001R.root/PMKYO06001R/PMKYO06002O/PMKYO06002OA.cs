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
// �Ǘ��ԍ�              �쐬�S�� : �g���Y
// �C �� ��  2011.09.06  �C�����e : SCM�Ή�-���_�Ǘ��i#23464�j
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using System.Collections;

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
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IAPMSTControlDB
    {
        /// <summary>
        /// ���M�}�X�^���̂��擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterNameList">�}�X�^���̃��X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���M�}�X�^���̎擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchMstName(string enterpriseCode,
            [CustomSerializationMethodParameterAttribute("PMKYO06003D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvWork")]
            out ArrayList masterNameList);

        /// <summary>
        /// ���M�}�X�^���̋敪���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterDivList">�}�X�^���̋敪���X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���M�}�X�^���̋敪�擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchMstDoDiv(string enterpriseCode,
            [CustomSerializationMethodParameterAttribute("PMKYO06003D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvWork")]
            out ArrayList masterDivList);

        /// <summary>
        /// ��M�}�X�^���̋敪���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterDivList">�}�X�^���̋敪���X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��M�}�X�^���̋敪�擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchReceMstDoDiv(string enterpriseCode,
            [CustomSerializationMethodParameterAttribute("PMKYO06003D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvWork")]
            out ArrayList masterDivList);

        /// <summary>
        /// ��M�}�X�^���̖��׋敪���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterDtlDivList">�}�X�^���̖��׋敪���X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��M�}�X�^���̖��׋敪�擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchReceMstDtlDoDiv(string enterpriseCode,
            [CustomSerializationMethodParameterAttribute("PMKYO06003D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvDtlWork")]
            out ArrayList masterDtlDivList);

        /// <summary>
        /// ��M�}�X�^���̂��擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterNameList">�}�X�^���̃��X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��M�}�X�^���̂��擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchReceMstName(string enterpriseCode,
            [CustomSerializationMethodParameterAttribute("PMKYO06003D", "Broadleaf.Application.Remoting.ParamData.SecMngSndRcvWork")]
            out ArrayList masterNameList);

        /// <summary>
        /// ���M�̃V���N�������擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="secMngSetArrList">�V���N�������X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���M�̃V���N�������擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchSyncExecDate(string enterpriseCode,
            out ArrayList secMngSetArrList);

        /// <summary>
        /// ��M�̃V���N�������擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="secMngSetArrList">�V���N�������X�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��M�̃V���N�������擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchReceSyncExecDate(string enterpriseCode,
            out ArrayList secMngSetArrList);

        /// <summary>
        /// PM��ƃR�[�h���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="pmCode">PM��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PM��ƃR�[�h���擾����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SeachPmCode(string enterpriseCode,
            string baseCode,
            out string pmCode);

        /// <summary>
        /// ���M�}�X�^�f�[�^���X�V���܂��B
        /// </summary>
        /// <param name="masterDivList">�}�X�^���̋敪</param>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="updSectionCode">���_�R�[�h</param>
        /// <param name="BeginningDate">�J�n���t</param>
        /// <param name="EndingDate">�I�����t</param>
        /// <param name="retCSAList">��������</param>
        /// <param name="sndRcvHisConsNo">���M�ԍ�</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���M�}�X�^�f�[�^���X�V����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int SearchCustomSerializeArrayList(
            ArrayList masterDivList,
            string enterpriseCodes,
            string updSectionCode,//ADD 2011/07/25
            Int64 BeginningDate,
            Int64 EndingDate,
            ref CustomSerializeArrayList retCSAList,
            out int sndRcvHisConsNo,//ADD 2011/07/25
            out string retMessage);

        /// <summary>
        /// ���M���_���X�V
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="updEmployeeCode">�]�ƈ��R�[�h</param>
        /// <param name="syncExecDt">�V���N����</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���_�����X�V����B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        int UpdateReceSecMngSet(
            string enterpriseCodes,
            string baseCode,
            string updEmployeeCode,
            DateTime syncExecDt,
            out string retMessage);

        /// <summary>
        /// ��M���_�Ǘ��ݒ�}�X�^�̍X�V
        /// </summary>
        /// <param name="enterpriseCodes">��ƃR�[�h</param>
        /// <param name="baseCode">���_�R�[�h</param>
        /// <param name="updEmployeeCode">�]�ƈ��R�[�h</param>
        /// <param name="syncExecDt">�V���N���s���t</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ��M���_�Ǘ��ݒ�}�X�^�̍X�V����</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.3.31</br>
        [MustCustomSerialization]
        int UpdateSecMngSet(
            string enterpriseCodes,
            string baseCode,
            string updEmployeeCode,
            DateTime syncExecDt,
            out string retMessage);

        /// <summary>
        /// DC�R���g���[�������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="masterDivList">�}�X�^���̋敪</param>
        /// <param name="masterDtlDivList">�}�X�^���̖��׋敪</param>
        /// <param name="retCSAList">�X�V�f�[�^</param>
        /// <param name="pmEnterpriseCode">PM��ƃR�[�h</param>
        /// <param name="isEmpty">��̔��f</param>
        /// <param name="searchCountWork">�����v��</param>
        /// <param name="retMessage">�G���[���b�Z�[�W</param>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.04.02</br>
        /// </remarks>
        int Update(string enterpriseCode, ArrayList masterDivList, ArrayList masterDtlDivList, 
            ref CustomSerializeArrayList retCSAList, string pmEnterpriseCode, out bool isEmpty, 
            out MstSearchCountWorkWork searchCountWork, out string retMessage);

        #region ADD 2011/07/26 ������  SCM�Ή�-���_�Ǘ��i10704767-00�j
        /// <summary>
        /// �}�X�^��M�̃f�[�^��������
        /// </summary>
        /// <param name="masterDivList">�}�X�^�敪</param>
        /// <param name="enterpriseCodes">PM��ƃR�[�h</param>
        /// <param name="updSectionCode">���_�R�[�h</param>
        /// <param name="paramList">�}�X�^���o�����N���X</param>
        /// <param name="retCSAList">�X�V�f�[�^</param>
        /// <param name="sndRcvHisConsNo">���M�ԍ�</param>
        /// <param name="retMessage">�߂郁�b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^���M����READ�̎��f�[�^�������s���N���X�ł��B</br>
        /// <br>Programmer : sundx</br>
        /// <br>Date       : 2011.07.26</br>
        int SearchCustomSerializeArrayList(ArrayList masterDivList, string enterpriseCodes, string updSectionCode,
            ArrayList paramList, ref CustomSerializeArrayList retCSAList, out int sndRcvHisConsNo, out string retMessage);

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
        //int GetObjCount(string pmEnterpriseCodes, SecMngSndRcvWork secMngSndRcvWork,
        //    object param, ref int count, out string retMessage); //DEL 2011.09.06 #24364
        int GetObjCount(ArrayList masterDivList, string enterpriseCodes, ArrayList paramList,
            out MstSearchCountWorkWork searchCountWork, out string retMessage);//ADD 2011.09.06 #24364
        #endregion ADD 2011/07/26 ������  SCM�Ή�-���_�Ǘ��i10704767-00�j

    }
}
