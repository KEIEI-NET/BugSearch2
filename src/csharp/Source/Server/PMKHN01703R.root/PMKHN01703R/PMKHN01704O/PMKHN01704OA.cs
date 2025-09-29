//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Y�ƕi�ԕϊ�����DB RemoteObject Interface
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00 �쐬�S�� : �i�N
// �� �� ��  2015/01/26  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : �i�N
// �� �� ��  2015/02/27   �C�����e : Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : ���V��
// �� �� ��  2015/03/02   �C�����e : Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : ���V��
// �� �� ��  2015/03/16   �C�����e : Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using System.Collections.Generic;// ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
using Broadleaf.Application.Remoting.ParamData;// ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�

namespace Broadleaf.Application.Remoting
{
	/// <summary>
    /// �i�ԕϊ�����DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
    /// <br>Note       : �i�ԕϊ�����DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : �i�N</br>
    /// <br>Date       : 2015/01/26</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IMeijiGoodsChgAllDB
	{
        /// <summary>
        /// �i�ԕϊ������i�C���|�[�g�j�̃C���|�[�g�����B
        /// </summary>
        /// <param name="importGoodsWorkList">�i�ԕϊ������C���|�[�g�f�[�^���X�g</param>
        /// <param name="addUpdWorkObj">�o�^�����f�[�^</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="addCnt">�ǉ�����</param>
        /// <param name="errCnt">�G���[����</param>
        /// <param name="dataList">�G���[�e�[�u��</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �i�ԕϊ������i�C���|�[�g�j�̃C���|�[�g�������s���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int GoodsChangeMst(
            object importGoodsWorkList,
            [CustomSerializationMethodParameterAttribute("PMKHN09767D", "Broadleaf.Application.Remoting.ParamData.GoodsNoChangeWork")]
            out object addUpdWorkObj,
            [CustomSerializationMethodParameterAttribute("PMKHN09767D", "Broadleaf.Application.Remoting.ParamData.GoodsNoChangeWork")]
            out object dataList,
            out Int32 readCnt,
            out Int32 addCnt,
            out Int32 errCnt,
            out string errMsg);

        /// <summary>
        /// ���i�݌Ƀ}�X�^�̕ϊ������B
        /// </summary>
        /// <param name="importGoodsWorkList">�i�ԕϊ��}�X�^�C���|�[�g�f�[�^���X�g</param>
        /// <param name="goodsStockSucObj">���i�݌ɕϊ��������X�g</param>
        /// <param name="goodsStockErrObj">���i�݌ɕϊ��G���[���X�g</param>
        /// <param name="goodsReadCnt">���i�Ǎ�����</param>
        /// <param name="priceReadCnt">���i�捞����</param>
        /// <param name="stockReadCnt">�݌Ɏ捞����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�݌Ƀ}�X�^�̕ϊ��������s���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        [MustCustomSerialization]
        //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�----->>>>>
        //int GoodsChangeGoodsStock(
        //    object importGoodsWorkList,
        //    [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiGoodsStockWork")]
        //    out object goodsSucObj,
        //    [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiGoodsStockWork")]
        //    out object goodsErrObj,
        //    [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiGoodsStockWork")]
        //    out object priceSucObj,
        //    [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiGoodsStockWork")]
        //    out object priceErrObj,
        //    [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiGoodsStockWork")]
        //    out object stockSucObj,
        //    [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiGoodsStockWork")]
        //    out object stockErrObj,
        //    out Int32 goodsReadCnt,
        //    out Int32 priceReadCnt,
        //    out Int32 stockReadCnt);
        //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
        //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
        int GoodsChangeGoodsStock(
            object importGoodsWorkList,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiGoodsStockWork")]
            out object goodsStockSucObj,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiGoodsStockWork")]
            out object goodsStockErrObj,
            out Int32 goodsReadCnt,
            out Int32 priceReadCnt,
            out Int32 stockReadCnt);
        //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<

        /// <summary>
        /// ���i�Ǘ����}�X�^�̕ϊ������B
        /// </summary>
        /// <param name="importGoodsWorkList">�i�ԕϊ��}�X�^�C���|�[�g�f�[�^���X�g</param>
        /// <param name="addUpdWorkObj">�o�^�����f�[�^</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="dataList">�G���[�e�[�u��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�Ǘ����}�X�^�̕ϊ��������s���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int GoodsChangeGoodsMng(
            object importGoodsWorkList,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeiJiGoodsMngWork")]
            out object addUpdWorkObj,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeiJiGoodsMngWork")]
            out object dataList,
            out Int32 readCnt);

        /// <summary>
        /// �|���}�X�^�̕ϊ������B
        /// </summary>
        /// <param name="importGoodsWorkList">�i�ԕϊ��}�X�^�C���|�[�g�f�[�^���X�g</param>
        /// <param name="addUpdWorkObj">�o�^�����f�[�^</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="dataList">�G���[�e�[�u��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�̕ϊ��������s���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int GoodsChangeRate(
            object importGoodsWorkList,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiRateWork")]
            out object addUpdWorkObj,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiRateWork")]
            out object dataList,
            out Int32 readCnt);

        /// <summary>
        /// �����}�X�^�̕ϊ������B
        /// </summary>
        /// <param name="importGoodsWorkList">�i�ԕϊ��}�X�^�C���|�[�g�f�[�^���X�g</param>
        /// <param name="addUpdWorkObj">�o�^�����f�[�^</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="dataList">�G���[�e�[�u��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �����}�X�^�̕ϊ��������s���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int GoodsChangeJoin(
            object importGoodsWorkList,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.NewJoinPartsWork")]
            out object addUpdWorkObj,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.NewJoinPartsWork")]
            out object dataList,
            out Int32 readCnt);

        /// <summary>
        /// ��փ}�X�^�̕ϊ������B
        /// </summary>
        /// <param name="importGoodsWorkList">�i�ԕϊ��}�X�^�C���|�[�g�f�[�^���X�g</param>
        /// <param name="addUpdWorkObj">�o�^�����f�[�^</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="dataList">�G���[�e�[�u��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ��փ}�X�^�̕ϊ��������s���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int GoodsChangeParts(
            object importGoodsWorkList,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiPartsSubstWork")]
            out object addUpdWorkObj,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.MeijiPartsSubstWork")]
            out object dataList,
            out Int32 readCnt);

        /// <summary>
        /// �Z�b�g�}�X�^�̕ϊ������B
        /// </summary>
        /// <param name="importGoodsWorkList">�i�ԕϊ��}�X�^�C���|�[�g�f�[�^���X�g</param>
        /// <param name="addUpdWorkObj">�o�^�����f�[�^</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="dataList">�G���[�e�[�u��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �Z�b�g�}�X�^�̕ϊ��������s���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int GoodsChangeSet(
            object importGoodsWorkList,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.GoodsSetChgWork")]
            out object addUpdWorkObj,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.GoodsSetChgWork")]
            out object dataList,
            out Int32 readCnt);

        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
        /// <summary>
        /// �D�ǐݒ�}�X�^�̕ϊ������B
        /// </summary>
        /// <param name="cndWork">�i�ԕϊ��}�X�^�C���|�[�g�f�[�^���X�g</param>
        /// <param name="offerPrmDic">�񋟕��D�ǐݒ�f�[�^</param>
        /// <param name="addUpdWorkObj">�o�^�����f�[�^</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="loginCnt">�X�V����</param>
        /// <param name="dataList">�G���[�e�[�u��</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="csvErr"></param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �D�ǐݒ�}�X�^�̕ϊ��������s���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int PrmSettingChange(
            object cndWork,
            Dictionary<string, PrmSettingWork> offerPrmDic,// ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.NewPrmSettingUWork")]
            out object addUpdWorkObj,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.NewPrmSettingUWork")]
            out object dataList,
            out Int32 readCnt,
            out Int32 loginCnt,
            out string errMsg,
            out bool csvErr);
        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<

        /// <summary>
        /// �ݏo�f�[�^�X�V����
        /// </summary>
        /// <param name="cndWork">�i�ԕϊ��}�X�^�C���|�[�g�f�[�^���X�g</param>
        /// <param name="sucObjectList">�o�^�����f�[�^</param>
        /// <param name="errObjectList">�G���[�e�[�u��</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �ݏo�f�[�^�̕ϊ��������s���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        [MustCustomSerialization]
        int ShipmentChange(
            object cndWork,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.ShipmentChangeWork")]
            out object sucObjectList,
            [CustomSerializationMethodParameterAttribute("PMKHN01705D", "Broadleaf.Application.Remoting.ParamData.ShipmentChangeWork")]
            out object errObjectList,
            out Int32 readCnt);
	}
}
