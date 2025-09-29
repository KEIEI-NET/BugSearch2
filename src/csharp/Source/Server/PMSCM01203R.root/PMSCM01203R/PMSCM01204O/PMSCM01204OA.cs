//********************************************************************//
// System           :   PM.NS                                         //
// Sub System       :                                                 //
// Program name     :   ��������M�o�b�`�����N���X                    //
//                  :   PMSCM01203R.DLL                               //
// Name Space       :   Broadleaf.Application.Remoting                //
// Programmer       :   qianl                                         //
// Date             :   2011.07.21                                    //
//--------------------------------------------------------------------//
// Update Note      :                                                 //
//--------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.               //
//********************************************************************//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ��������M�o�b�`�����N���XDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ��������M�o�b�`�����N���XDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : qianl</br>
    /// <br>Date       : 2011.07.21</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface ISndAndRcvCSVDB
    {
        /// <summary>
        /// ����f�[�^���o����
        /// </summary>
        /// <param name="salesSlipArray">����f�[�^�̃��X�g</param>
        /// <param name="salesDetailArray">���㖾�׃f�[�^�̃��X�g</param>
        /// <param name="acceptOdrCarArray">�󒍃}�X�^�i�ԗ��j�̃��X�g</param>
        /// <param name="minUpdateDateTime">���M�J�n���t</param>
        /// <param name="maxUpdateDateTime">���M�I�����t</param>
        /// <param name="startModeCode">���[�h</param>
        /// <param name="salesDateStart">������tFrom</param>
        /// <param name="salesDateEnd">������tTo</param>
        /// <param name="addUpADateStart">���͓�From</param>
        /// <param name="addUpADateEnd">���͓�To</param>
        /// <param name="sectionCodeStart">���_�R�[�hFrom</param>
        /// <param name="sectionCodeEnd">���_�R�[�hTo</param>
        /// <param name="customerCodeStart">���Ӑ�R�[�hFrom</param>
        /// <param name="customerCodeEnd">���Ӑ�R�[�hTo</param>
        /// <param name="custSlipNoStart">�`�[�ԍ�From</param>
        /// <param name="custSlipNoEnd">�`�[�ԍ�To</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="outSalesTotal">�o�͌���</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X��������(0:����,9:�f�[�^����,����ȊO:�e�L�X�g�o�̓G���[)</returns>
        /// <remarks>
        /// <br>Note       : ����f�[�^���o�����B</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMSCM01205D", "Broadleaf.Application.Remoting.ParamData.SalesSlipWork")]
            ref ArrayList salesSlipArray,
            [CustomSerializationMethodParameterAttribute("PMSCM01205D", "Broadleaf.Application.Remoting.ParamData.SalesDetailWork")]
            ref ArrayList salesDetailArray,
            [CustomSerializationMethodParameterAttribute("PMSCM01205D", "Broadleaf.Application.Remoting.ParamData.AcceptOdrCarWork")]
            ref ArrayList acceptOdrCarArray,
            ref Int64 minUpdateDateTime, ref Int64 maxUpdateDateTime, Int32 startModeCode, Int32 salesDateStart, Int32 salesDateEnd,
            Int32 addUpADateStart, Int32 addUpADateEnd, Int32 sectionCodeStart, Int32 sectionCodeEnd, Int32 customerCodeStart, Int32 customerCodeEnd,
          Int32 custSlipNoStart, Int32 custSlipNoEnd, string enterpriseCode, string sectionCode,ref Int32 outSalesTotal, ref string errMsg);

        /// <summary>
        /// �}�X�^�捞����
        /// </summary>
        /// <param name="tableID">�e�[�u��ID</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="deployDataList">�f�[�_List</param>
        /// <param name="errList">�G���[List</param>
        /// <param name="result">�R���o�[�g���ʃ��[�N</param>
        /// <returns>�X�e�[�^�X��������</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�捞����</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            string tableID,
            string enterpriseCode,
            CustomSerializeArrayList deployDataList,
            [CustomSerializationMethodParameter("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref CustomSerializeArrayList errList,
            [CustomSerializationMethodParameter("PMKHN08005D", "Broadleaf.Application.Remoting.ParamData.ConvertResultWork")]
            ref ConvertResultWork result
            );

        /// <summary>
        /// PM7�A�g����M�������O�f�[�^��o�^
        /// </summary>
        /// <param name="pM7RkSRHistWork">PM7�A�g����M�������O�f�[�^���[�N</param>
        /// <param name="SectionCode">�����_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="pM7RkHistCode">PM7�A�g�����敪(1�F���M�@2�F��M)</param>
        /// <param name="pM7RkAutoCode">PM7�A�g�����敪(0�F�蓮�@1�F����)</param>
        /// <returns>�X�e�[�^�X��������</returns>
        /// <remarks>
        /// <br>Note       : PM7�A�g����M�������O�f�[�^��o�^</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        int WritePM7RkSRHistDB(
            PM7RkSRHistWork pM7RkSRHistWork,
            string SectionCode,
            string enterpriseCode,
            int pM7RkHistCode,
            int pM7RkAutoCode);

        /// <summary>
        /// �������M�����f�[�^����������(�}�X�^�捞����)
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="pM7RkHistCode">PM7�A�g�����敪(1�F���M�@2�F��M)</param>
        /// <param name="rcvFileNm">��M�t�@�C������</param>
        /// <param name="returnBL">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �������M�����f�[�^����������(�}�X�^�捞����)</br>
        /// <br>Programmer : qianl</br>
        /// <br>Date       : 2011.07.21</br>
        /// </remarks>
        int SeachRcvFileNm(
            string sectionCode,
            Int32 pM7RkHistCode,
            string rcvFileNm,
            ref bool returnBL);
    }
}