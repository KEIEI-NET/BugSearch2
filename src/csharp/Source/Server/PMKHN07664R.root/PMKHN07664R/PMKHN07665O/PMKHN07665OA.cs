//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�Ǘ����}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : ���i�Ǘ����}�X�^�i�C���|�[�g�jDB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ����
// �� �� ��  2012/06/04  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ����
// �C �� ��  2012/07/03  �C�����e : ���q�l�̎w�E�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ����
// �C �� ��  2012/07/13  �C�����e : ���q�l�̎w�E�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �L�w��
// �C �� ��  2012/07/19  �C�����e : ��Q�ꗗ�̎w�ENO.110�̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using System.Data;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�Ǘ����}�X�^�i�C���|�[�g�jDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�Ǘ����}�X�^�i�C���|�[�g�jDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2012/06/04</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsMngImportDB
    {
        /// <summary>
        /// ���i�Ǘ����}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="processKbn">�����敪</param>
        /// <param name="checkKbn">�`�F�b�N�敪</param>
        /// <param name="importGoodsWorkList">���i�Ǘ����}�X�^�C���|�[�g�f�[�^���X�g</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="errCnt">�G���[����</param>
        /// <param name="dataList">�G���[�e�[�u��</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�Ǘ����}�X�^�i�C���|�[�g�j�̃C���|�[�g�������s���B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2012/06/04</br>
        /// <br>Update Note: 2012/07/03</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A��z�Č��A���q�l�̎w�E�̑Ή�</br>
        /// <br>Update Note: 2012/07/13 ����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00�A��z�Č��A���q�l�̎w�E�̑Ή�</br>
        /// <br>Update Note : 2012/07/19 �L�w�� </br>
        /// <br>            : 10801804-00�ARedmine#30388 ��Q�ꗗ�̎w�ENO.110�̑Ή�</br>
        /// </remarks>
        [MustCustomSerialization]
        int Import(
            Int32 processKbn,
            Int32 checkKbn, // ADD �L�w�� 2012/07/19 FOR REDMINE#30388
            //[CustomSerializationMethodParameterAttribute("PMKHN07666D", "Broadleaf.Application.Remoting.ParamData.GoodsMngWork")]
            [CustomSerializationMethodParameterAttribute("PMKHN07666D", "Broadleaf.Application.Remoting.ParamData.ImportGoodsMngWork")] // ---ADD 2012/07/13 ����
            ref object importGoodsWorkList,
            out Int32 readCnt,
            out Int32 addCnt,
            out Int32 updCnt,
            out Int32 errCnt,
            //out DataTable dataTable,// ---DEL 2012/07/03 ����
            //out ArrayList dataList,   // ---ADD 2012/07/03 ���� // ---DEL 2012/07/13 ����
            // --- ADD 2012/07/13 ���� ----->>>>>
            [CustomSerializationMethodParameterAttribute("PMKHN07666D", "Broadleaf.Application.Remoting.ParamData.ImportGoodsMngWork")]
            out object dataList,
            // --- ADD 2012/07/13 ���� -----<<<<<
            out string errMsg);

    }
}
