//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d��������ѕ\
// �v���O�����T�v   : �d��������ѕ\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/05/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d��������ѕ\DBRemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d��������ѕ\DBRemoteObject�C���^�[�t�F�[�X�̃C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.05.10</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockSalesResultInfoTableDB
    {

        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �d��������ѕ\�ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="stockSalesInfoWork">��������</param>
        /// <param name="paraStockSalesInfoCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d��������ѕ\�ꗗ�\LIST��S�Ė߂��܂����Ƃ��s���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.05.10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKOU02069D", "Broadleaf.Application.Remoting.ParamData.StockSalesResultInfoWork")]
			out object stockSalesInfoWork,
           object paraStockSalesInfoCndtnWork);


        #endregion
    }
}
