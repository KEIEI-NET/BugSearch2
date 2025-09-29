using System;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
//using Broadleaf.Library.Resources;
//using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// ���R���[�i�݌Ɉړ��`�[�j�@DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���R���[�i�݌Ɉړ��`�[�jDB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22018�@��؁@���b</br>
	/// <br>Date       : 2008.05.28</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		// �A�v���P�[�V�����T�[�o�[�̐ڑ���
    public interface IFrePStockMoveSlipDB
	{
        /// <summary>
        /// ���R���[�i�݌Ɉړ��`�[�j��񌟍�����
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork">���R���[���ʒ��o�����p�����[�^</param>
        /// <param name="frePStockMoveSlipRetWorkList">���R���[�i�݌Ɉړ��`�[�j���o���ʃ��X�g</param>
        /// <param name="frePMasterList">���R���[�i�݌Ɉړ��`�[�j�֘A�}�X�^���X�g</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note         : �w�肳�ꂽ���R���[�i�݌Ɉړ��`�[�j���ʃN���X���[�NLIST���擾���܂��B</br>
        /// <br>Programmer   : 22018 ��� ���b</br>
        /// <br>Date         : 2008.05.28</br>
        /// </remarks>
        int Search(
            object frePrtCmnExtPrmWork,
            out object frePStockMoveSlipRetWorkList,
            out object frePMasterList,
            out bool msgDiv,
            out string errMsg
            ); 
   }
}