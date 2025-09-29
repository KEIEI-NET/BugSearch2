//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�}�X�^�i�C���|�[�g�j
// �v���O�����T�v   : ���i�}�X�^�i�C���|�[�g�jDB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/05/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30517 �Ė� �x��
// �C �� ��  2010/03/31  �C�����e : Mantis.15256 ���i�}�X�^�C���|�[�g�̑Ώۍ��ڐݒ�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/06/12  �C�����e : ��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/07/03  �C�����e : ��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/07/20  �C�����e : ��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�d�l�ύX�̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using System.Data; // ADD wangf 2012/06/12 FOR Redmine#30387

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�}�X�^�i�C���|�[�g�jDB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�}�X�^�i�C���|�[�g�jDB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsUImportDB
    {
        /// <summary>
        /// ���i�}�X�^�i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="processKbn">�����敪</param>
        /// <param name="dataCheckKbn">�`�F�b�N�敪</param>
        /// <param name="importGoodsWorkList">���i�}�X�^�C���|�[�g�f�[�^���X�g</param>
        /// <param name="importGoodsPriceWorkList">���i�}�X�^�C���|�[�g�f�[�^���X�g</param>
        /// <param name="importGoodsUGoodsPriceUWorkList">���i�E���i�C���|�[�g�f�[�^���X�g</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="updCnt">��������</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="importSetUpInfoList">�C���|�[�g�Ώېݒ胊�X�g</param>
        /// <param name="paraPriceStartDate">���i�J�n�N����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���i�}�X�^�i�C���|�[�g�j�̃C���|�[�g�������s���B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009.05.15</br>
        /// <br>Update Note: 2012/06/12 wangf </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// <br>Update Note: 2012/07/03 wangf </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ��̑Ή�</br>
        /// <br>Update Note: 2012/07/20 wangf </br>
        /// <br>           : 10801804-00�A��z�Č��ARedmine#30387 ���i�}�X�^�C���{�[�g�d�l�ύX�̑Ή�</br>
        [MustCustomSerialization]
        // 2010/03/31 >>>
        //int Import(
        //    Int32 processKbn,
        //    [CustomSerializationMethodParameterAttribute("MAKHN09286D", "Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
        //    ref object importGoodsWorkList,
        //    [CustomSerializationMethodParameterAttribute("MAKHN09176D", "Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
        //    ref object importGoodsPriceWorkList,
        //    out Int32 readCnt,
        //    out Int32 addCnt,
        //    out Int32 updCnt,
        //    out string errMsg);
        int Import(
            Int32 processKbn,
            Int32 dataCheckKbn, // ADD wangf 2012/07/20 FOR Redmine#30387
            [CustomSerializationMethodParameterAttribute("MAKHN09286D", "Broadleaf.Application.Remoting.ParamData.GoodsUWork")]
            ref object importGoodsWorkList,
            [CustomSerializationMethodParameterAttribute("MAKHN09176D", "Broadleaf.Application.Remoting.ParamData.GoodsPriceUWork")]
            ref object importGoodsPriceWorkList,
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
            [CustomSerializationMethodParameterAttribute("PMKHN07636D", "Broadleaf.Application.Remoting.ParamData.GoodsUGoodsPriceUWork")]
            ref object importGoodsUGoodsPriceUWorkList,
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<<
            out Int32 readCnt,
            out Int32 addCnt,
            out Int32 updCnt,
            out string errMsg,
            //object importSetUpInfoList); // DEL wangf 2012/06/12 FOR Redmine#30387
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387--------->>>>
            object importSetUpInfoList,
            //ref DataTable table, // DEL wangf 2012/07/03 FOR Redmine#30387
            DateTime paraPriceStartDate);
            // ------------ADD wangf 2012/06/12 FOR Redmine#30387---------<<<<<
        // 2010/03/31 <<<

    }
}
