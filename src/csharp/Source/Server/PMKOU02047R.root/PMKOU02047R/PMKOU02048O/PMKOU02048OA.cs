//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���s�����m�F�\
// �v���O�����T�v   : �d���s�����m�F�\���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���痈
// �� �� ��  2009/04/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
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
    /// �d���s�����m�F�\DBRemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���s�����m�F�\DBRemoteObject�C���^�[�t�F�[�X�̃C���X�^���X�̍쐬���s���B</br>
    /// <br>Programmer : ���痈</br>
    /// <br>Date       : 2009.04.10</br>
    /// <br></br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockSalesInfoTableDB
    {

        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// �d���s�����m�F�\�ꗗ�\LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
        /// </summary>
        /// <param name="stockSalesInfoWork">��������</param>
        /// <param name="paraStockSalesInfoCndtnWork">�����p�����[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �d���s�����m�F�\�ꗗ�\LIST��S�Ė߂��܂����Ƃ��s���܂��B</br>
        /// <br>Programmer : ���痈</br>
        /// <br>Date       : 2009.04.10</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMKOU02049D", "Broadleaf.Application.Remoting.ParamData.StockSalesInfoWork")]
			out object stockSalesInfoWork,
           object paraStockSalesInfoCndtnWork);


        #endregion
    }
}
