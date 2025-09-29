//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���㌎���W�v�f�[�^�X�VDB�C���^�[�t�F�[�X
//                  :   PMHNB01102O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112�@�v�ۓc�@��
// Date             :   2008.05.19
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
    /// ���㌎���W�v�f�[�^�X�VDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���㌎���W�v�f�[�^�X�VDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc�@��</br>
    /// <br>Date       : 2008.05.19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IMonthlyTtlSalesUpdDB
    {
        /// <summary>
        /// �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^�𕨗��폜���܂��B
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^�𕨗��폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2008.05.19</br>
        int Delete([CustomSerializationMethodParameterAttribute("PMHNB01103D", "Broadleaf.Application.Remoting.ParamData.MTtlSalesUpdParaWork")]
            MTtlSalesUpdParaWork mTtlSalesUpdParaWork);

        /// <summary>
        /// �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^���ďW�v���܂��B
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^���ďW�v���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2008.05.19</br>
        int ReCount([CustomSerializationMethodParameterAttribute("PMHNB01103D", "Broadleaf.Application.Remoting.ParamData.MTtlSalesUpdParaWork")]
            MTtlSalesUpdParaWork mTtlSalesUpdParaWork);


        // ---ADD 2009/12/24 -------->>>
        /// <summary>
        /// �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^���ďW�v���܂��B
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWork�I�u�W�F�N�g</param>
        /// <param name="connection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^���ďW�v���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/24</br>
        int ReCountProc([CustomSerializationMethodParameterAttribute("PMHNB01103D", "Broadleaf.Application.Remoting.ParamData.MTtlSalesUpdParaWork")]
            MTtlSalesUpdParaWork mTtlSalesUpdParaWork, ref SqlConnection connection, ref SqlTransaction transaction);
        // ---ADD 2009/12/24 --------<<<
    }
}
