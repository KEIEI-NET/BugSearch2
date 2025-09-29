//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �d�������W�v�f�[�^�X�VDB�C���^�[�t�F�[�X
//                  :   PMKOU01112O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   30290
// Date             :   2008.12.12
//----------------------------------------------------------------------
// Update Note      :�@ 2009/12/24 杍^ �o�l�D�m�r�ێ�˗��C
//                             �E�ꊇ���A���X�V�̐V�K��Ή�
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Collections;

using System.Data.SqlClient;    // ADD 2009/12/24

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d�������W�v�f�[�^�X�VDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d�������W�v�f�[�^�X�VDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.12.12</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IMonthlyTtlStockUpdDB
    {
        /// <summary>
        /// �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^�𕨗��폜���܂��B
        /// </summary>
        /// <param name="MTtlStockUpdParaWork">MTtlStockUpdParaWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^�𕨗��폜���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        int Delete([CustomSerializationMethodParameterAttribute("PMKOU01113D", "Broadleaf.Application.Remoting.ParamData.MTtlStockUpdParaWork")]
            MTtlStockUpdParaWork MTtlStockUpdParaWork);

        /// <summary>
        /// �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^���ďW�v���܂��B
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlStockUpdParaWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^���ďW�v���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        int ReCount([CustomSerializationMethodParameterAttribute("PMKOU01113D", "Broadleaf.Application.Remoting.ParamData.MTtlStockUpdParaWork")]
            MTtlStockUpdParaWork mTtlStockUpdParaWork);

        // ---ADD 2009/12/24 -------->>>
        /// <summary>
        /// �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^���ďW�v���܂��B
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlStockUpdParaWork�I�u�W�F�N�g</param>
        /// <param name="connection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^���ďW�v���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/24</br>
        int ReCountProc([CustomSerializationMethodParameterAttribute("PMKOU01113D", "Broadleaf.Application.Remoting.ParamData.MTtlStockUpdParaWork")]
            MTtlStockUpdParaWork mTtlStockUpdParaWork, ref SqlConnection connection, ref SqlTransaction transaction);
        // ---ADD 2009/12/24 --------<<<
    }
}
