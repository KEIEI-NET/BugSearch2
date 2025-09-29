using System;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.Generic;

using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// ���R���[�i�������j�@DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���R���[�i�������jDB RemoteObject Interface�ł��B</br>
    /// <br>Programmer  : ���O</br>
    /// <br>Date        : 2022/03/07</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		// �A�v���P�[�V�����T�[�o�[�̐ڑ���
    public interface IEBooksFrePBillDB
	{
        /// <summary>
        /// ���R���[�i�������j��񌟍�����
        /// </summary>
        /// <param name="frePrtCmnExtPrmWork">���o�����p�����[�^</param>
        /// <param name="frePSalesSlipRetWorkList">���R���[�i�������j���o���ʃ��X�g</param>
        /// <param name="frePMasterList">���R���[�i�������j�֘A�}�X�^���X�g</param>
        /// <param name="msgDiv">���b�Z�[�W�敪</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note         : �w�肳�ꂽ���R���[�i�������j���ʃN���X���[�NLIST���擾���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2022/03/07</br>
        /// </remarks>
        int Search(
            object frePBillParaWork,
            out object frePBillRetWorkList,
            out object frePMasterList,
            out bool msgDiv,
            out string errMsg
            ); 
   }
}