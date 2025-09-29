//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �R���o�[�g���� DBRemoteObject�C���^�[�t�F�[�X
//                  :   PMKHN08004O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   30290
// Date             :   2008.09.22
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �R���o�[�g���� DBRemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �R���o�[�g���� DBRemoteObject�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.22</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IConvertProcessDB
    {
        /// <summary>
        /// �g�����U�N�V�������J�n���܂��B
        /// </summary>
        /// <returns>STATUS</returns>
        /// <br>Note       : �g�����U�N�V�������J�n���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        int BeginTransaction();

        /// <summary>
        /// �g�����U�N�V�������I�����܂��B
        /// </summary>
        /// <param name="commitFlg">true : �R�~�b�g�@false : ���[���o�b�N</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �g�����U�N�V�������I�����܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        int EndTransaction(bool commitFlg);

        /// <summary>
        /// �R���o�[�g�f�[�^��PM.NS�̃��[�U�[DB�ɓW�J���܂��B
        /// </summary>
        /// <param name="tableID">�Ώۂ̃e�[�u��ID</param>
        /// <param name="truncateFlg">�폜�t���O</param>
        /// <param name="deployDataList">�f�[�^�̃��X�g(CustomSerializeArrayList)</param>
        /// <param name="errList"></param>
        /// <param name="result">�R���o�[�g����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �R���o�[�g�f�[�^��PM.NS�̃��[�U�[DB�ɓW�J���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.22</br>
        [MustCustomSerialization]
        int DeployConvertData(
            string tableID,
            bool truncateFlg,
            CustomSerializeArrayList deployDataList,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref CustomSerializeArrayList errList,
            [CustomSerializationMethodParameter("PMKHN08005D", "Broadleaf.Application.Remoting.ParamData.ConvertResultWork")]
            out ConvertResultWork result
            );

        /// <summary>
        /// �݌Ɏ󕥐ݒ菈��
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="lstSource">�݌Ɏ󕥐ݒ�̌��f�[�^[0:����/1:���㗚��/2:�d��/3:�d������/4:�݌Ɉړ�/5:�݌ɒ���]</param>
        /// <param name="resultCnt">�����f�[�^����</param>
        /// <returns></returns>
        int SetStockAcPayHist(string enterpriseCode, List<int> lstSource, out int resultCnt);

        /// <summary>
        /// �����J�n
        /// </summary>        
        /// <returns></returns>
        int StartProcess();

        /// <summary>
        /// �������~
        /// </summary>        
        /// <returns></returns>
        int StopProcess();
    }
}
