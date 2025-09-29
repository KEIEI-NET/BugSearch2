using System;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

//using Broadleaf.Library.Runtime.Serialization; // DEL caohh 2011/08/17
using Broadleaf.Application.Resources;
//using Broadleaf.Library.Resources;
//using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// ���R���[�i����`�[�j�@DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���R���[�i����`�[�jDB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22018�@��؁@���b</br>
	/// <br>Date       : 2008.05.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		// �A�v���P�[�V�����T�[�o�[�̐ڑ���
    public interface IFrePSalesSlipDB
	{
        /// <summary>
        /// ���R���[�i����`�[�j��񌟍�����
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork">���R���[���ʒ��o�����p�����[�^</param>
        /// <param name="frePSalesSlipRetWorkList">���R���[�i����`�[�j���o���ʃ��X�g</param>
        /// <param name="frePMasterList">���R���[�i����`�[�j�֘A�}�X�^���X�g</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note         : �w�肳�ꂽ���R���[�i����`�[�j���ʃN���X���[�NLIST���擾���܂��B</br>
        /// <br>Programmer   : 22018 ��� ���b</br>
        /// <br>Date         : 2008.05.28</br>
        /// </remarks>
        int Search(
            object frePrtCmnExtPrmWork,
            out object frePSalesSlipRetWorkList,
            out object frePMasterList,
            out bool msgDiv,
            out string errMsg
            );
        /// <summary>
        /// ���R���[�i���Ϗ��j�֘A��񌟍�����
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork">���R���[���ʒ��o�����p�����[�^</param>
        /// <param name="frePSalesSlipRetWorkList">���R���[�i����`�[�j���o���ʃ��X�g</param>
        /// <param name="frePMasterList">���R���[�i���Ϗ��j�֘A�}�X�^���X�g</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note         : �w�肳�ꂽ���R���[�i���Ϗ��j�֘A��񌋉ʃN���X���[�NLIST���擾���܂��B</br>
        /// <br>Programmer   : 22018 ��� ���b</br>
        /// <br>Date         : 2008.10.04</br>
        /// </remarks>
        int SearchForEstFm(
            object frePrtCmnExtPrmWork,
            out object frePEstFmRetWorkList,
            out object frePMasterList,
            out bool msgDiv,
            out string errMsg
            );

        /// <summary>
        /// ���R���[�i�t�n�d�`�[�j�֘A��񌟍�����
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork"></param>
        /// <param name="frePSalesSlipRetWorkList"></param>
        /// <param name="frePMasterList"></param>
        /// <param name="msgDiv"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note         : �w�肳�ꂽ���R���[�i�t�n�d�`�[�j�֘A��񌋉ʃN���X���[�NLIST���擾���܂��B</br>
        /// <br>               �x�[�X�ɂȂ�󎚏��͂t�h����w�肳���ׁA�����[�g�ł͊֘A����s�����̏����Z�b�g���܂��B</br>
        /// <br>Programmer   : 22018 ��� ���b</br>
        /// <br>Date         : 2008.11.25</br>
        /// </remarks>
        int SearchForUOE(
            object frePrtCmnExtPrmWork,
            out object frePSalesSlipRetWorkList,
            out object frePMasterList,
            out bool msgDiv,
            out string errMsg
            );
   }
}
