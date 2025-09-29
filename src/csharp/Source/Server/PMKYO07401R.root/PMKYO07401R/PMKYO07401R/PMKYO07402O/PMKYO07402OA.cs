//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �f�[�^��M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/07/21  �C�����e : SCM�Ή��]���_�Ǘ��i10704767-00�j
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� ��  2011/08/26  �C�����e : DC�������O��DC�e�f�[�^�̃N���A������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : Liangsd
// �C �� ��  2011/09/06 �C�����e :  Redmine#23918���_�Ǘ�����PG�ύX�ǉ��˗���ǉ�
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
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_Center_UserAP)]
    public interface IDCControlDB
    {
		// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
        /*
        /// <summary>
        /// �f�[�^���擾���܂��B
        /// </summary>
        /// <param name="outreceiveList">��������</param>
        /// <param name="parareceiveWork">��������</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="fileIds">�����f�[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�擾</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        int Search(out object outreceiveList, DCReceiveDataWork parareceiveWork, string sectionCode, string[] fileIds);
		*/
		// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

		/// <summary>
		/// �f�[�^���擾���܂��B
		/// </summary>
		/// <param name="outreceiveList">��������</param>
		/// <param name="parareceiveWork">��������</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <param name="fileIds">�����f�[�^</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �f�[�^�擾</br>
		/// <br>Programmer : ����</br>
		/// <br>Date       : 2011.07.21</br>
		int SearchSCM(out object outreceiveList, DCReceiveDataWork parareceiveWork, string sectionCode, string[] fileIds);

		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
        /// <summary>
        /// ���߃`�F�b�N���܂��B
        /// </summary>
        /// <param name="outErrorList">��������</param>
        /// <param name="parareceiveWorkList">��������</param>
        /// <param name="salesSimeDate">������ߓ�</param>
        /// <param name="StockSimeDate">�d�����ߓ�</param>
        /// <param name="saleCheckFlg">����`�F�b�N�t���O</param>
        /// <param name="depsitCheckFlg">�����`�F�b�N�t���O</param>
        /// <param name="stockCheckFlg">�d���`�F�b�N�t���O</param>
        /// <param name="paymentCheckFlg">�x�����`�F�b�N�t���O</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���߃`�F�b�N</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2011.07.21</br>
        int SimeCheckSCM(out ArrayList outErrorList, ArrayList parareceiveWorkList,
            Int64 salesSimeDate, Int64 StockSimeDate, bool saleCheckFlg, bool depsitCheckFlg, bool stockCheckFlg, bool paymentCheckFlg);

		/// <summary>
		/// ���߃`�F�b�N���܂��B
		/// </summary>
        /// <param name="outErrorList">��������</param>
		/// <param name="parareceiveWork">��������</param>
		/// <param name="salesSimeDate">������ߓ�</param>
		/// <param name="StockSimeDate">�d�����ߓ�</param>
		/// <param name="saleCheckFlg">����`�F�b�N�t���O</param>
		/// <param name="depsitCheckFlg">�����`�F�b�N�t���O</param>
		/// <param name="stockCheckFlg">�d���`�F�b�N�t���O</param>
		/// <param name="paymentCheckFlg">�x�����`�F�b�N�t���O</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���߃`�F�b�N</br>
		/// <br>Programmer : ����</br>
		/// <br>Date       : 2011.07.21</br>
		int SimeCheckSCM(out ArrayList outErrorList, DCReceiveDataWork parareceiveWork,
			Int64 salesSimeDate, Int64 StockSimeDate, bool saleCheckFlg, bool depsitCheckFlg, bool stockCheckFlg, bool paymentCheckFlg);
		// ADD 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

		// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j------->>>>>>>
        /*
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
		*/
		// DEL 2011/07/21 ���仁@SCM�Ή��]���_�Ǘ��i10704767-00�j-------<<<<<<<

		/// <summary>
		/// DC�R���g���[�������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���ɂȂ�</br>
		/// <br>Programmer : ����</br>
		/// <br>Date       : 2011.07.30</br>
		/// </remarks>
		int UpdateSCM(ref CustomSerializeArrayList retCSAList, string enterpriseCode, ArrayList logList, out string retMessage);

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
        //int DCDataClear(string enterpriseCode);                                  //DEL by Liangsd     2011/09/06
        int DCDataClear(string sectionCode, string enterpriseCode);//ADD by Liangsd    2011/09/06
		// ADD 2011.08.26 ���� ----------<<<<<
    }
}
