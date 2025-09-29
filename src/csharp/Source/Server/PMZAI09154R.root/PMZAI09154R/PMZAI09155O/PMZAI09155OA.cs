//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �݌ɗ������݌ɐ��ݒ�DB�C���^�[�t�F�[�X
//                  :   PMZAI09155O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   �����
// Date             :   2009/12/24
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌ɗ������݌ɐ��ݒ�DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɗ������݌ɐ��ݒ�DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009/12/24</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockHistoryUpdateDB
    {
        /// <summary>
        /// �w�肳�ꂽ�����Ɋ�Â��āA�݌ɗ������݌ɐ����ďW�v���܂��B
        /// </summary>
        /// <param name="stockHistoryUpdateWork">StockHistoryUpdateWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �w�肳�ꂽ�����Ɋ�Â��āA�݌ɗ������݌ɐ����ďW�v���܂��B</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2009/12/24</br>
        /// </remarks>
        int ReCount([CustomSerializationMethodParameterAttribute("PMZAI09156D", "Broadleaf.Application.Remoting.ParamData.StockHistoryUpdateWork")]
            StockHistoryUpdateWork stockHistoryUpdateWork);
    }
}
