//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌Ƀ}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : �݌Ƀ}�X�^�i�C���|�[�g�jDB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : zhangy3
// �� �� ��  2012/06/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10801804-00  �쐬�S�� : zhangy3 
// �C �� �� 2012/07/03   �C�����e : Redmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : zhangy3
// �C �� ��  2012/07/20  �C�����e : ��z�Č��ARedmine#30387 �݌Ƀ}�X�^�C���{�[�g�d�l�ύX�̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using System.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �݌Ƀ}�X�^�i�C���|�[�g�jDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌Ƀ}�X�^�i�C���|�[�g�jDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : zhangy3</br>
    /// <br>Date       : 2012/06/12</br>
    /// <br></br>
    /// <br>Update Note: 2012/07/03 zhangy3 </br>
    /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
    /// <br>Update Note: 2012/07/20 zhangy3 </br>
    /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 �݌Ƀ}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IStockImportDB
    {
        /// <summary>
        /// �݌Ƀ}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="processKbn">�����敪</param>
        /// <param name="dataCheckKbn">�`�F�b�N�敪</param>
        /// <param name="importStockWorkList">�݌Ƀ}�X�^���X�g</param>
        /// <param name="importStockWorkCheckList">�݌Ƀ}�X�^�`�F�b�N���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="loginSectionCode">���O�C�����_�R�[�h</param>
        /// <param name="loginSectionGuideNm">���O�C�����_����</param>
        /// <param name="employeeCode">���O�C���]�ƈ��R�[�h</param>
        /// <param name="employeeName">���O�C���]�ƈ�����</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="errCnt">�G���[����</param>
        /// <param name="errStockCheckWorks">�G���[�݌Ƀ}�X�^�`�F�b�N���X�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>Status</returns>
        /// <br>Update Note: 2012/07/03 zhangy3 </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// <br>Update Note: 2012/07/20 zhangy3 </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 �݌Ƀ}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
        [MustCustomSerialization]
        int Import(
            Int32 processKbn,
            int dataCheckKbn,//ADD ZHANGY3 2012/07/20 FOR REDMINE#30387
            [CustomSerializationMethodParameterAttribute("MAZAI04136D", "Broadleaf.Application.Remoting.ParamData.StockWork")]
            ref object importStockWorkList,
            [CustomSerializationMethodParameterAttribute("PMKHN07606D", "Broadleaf.Application.Remoting.ParamData.StockCheckWork")]
            ref object importStockWorkCheckList,
            string enterpriseCode,
            string loginSectionCode,
            string loginSectionGuideNm,
            string employeeCode,
            string employeeName,
            out Int32 readCnt,
            out Int32 addCnt,
            out Int32 updCnt, 
            out int errCnt, 
            //out DataTable errTable,
           [CustomSerializationMethodParameterAttribute("PMKHN07606D", "Broadleaf.Application.Remoting.ParamData.StockCheckWork")]
            out object errStockCheckWorks,
            out string errMsg);
    }
}
