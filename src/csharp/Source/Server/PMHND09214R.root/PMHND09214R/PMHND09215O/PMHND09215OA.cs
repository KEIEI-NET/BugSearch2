//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�o�[�R�[�h�֘A�t��  DB RemoteObject�C���^�[�t�F�[�X
// �v���O�����T�v   : ���i�o�[�R�[�h�֘A�t���e�[�u���ɑ΂��Ċe���쏈�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : 3H ������
// �� �� ��  2017/06/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770181-00 �쐬�S�� : ������
// �C �� ��  2021/11/18  �C�����e : PJMIT-1499 OUT OF MEMORY�Ή�(4GB�Ή�) �P�v�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���i�o�[�R�[�h�֘A�t���}�X�^DB RemoteObject�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�o�[�R�[�h�֘A�t���}�X�^DB RemoteObject Interface�ł��B</br>
    /// <br>Programmer : 3H ������</br>
    /// <br>Date       : 2017/06/12</br>
    /// <br></br>
    /// <br>Update Note: 2021/11/18 ������</br>
    /// <br>�Ǘ��ԍ�   : 11770181-00</br>
    /// <br>             PJMIT-1499�@OUT OF MEMORY�Ή�(4GB�Ή�) �P�v�Ή�</br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IGoodsBarCodeRevnDB
    {
        #region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���}�X�^LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="objGoodsBarCodeRevnWork">��������</param>
        /// <param name="objGoodsBarCodeRevnSearchParaWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>������������ 0:����</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMHND09216D", "Broadleaf.Application.Remoting.ParamData.GoodsBarCodeRevnWork")]
			out object objGoodsBarCodeRevnWork,
           object objGoodsBarCodeRevnSearchParaWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t�����捞���܂�
        /// </summary>
        /// <param name="objGoodsBarCodeRevnWorkList">GoodsBarCodeRevnWork�I�u�W�F�N�gLIST</param>
        /// <returns>�捞�������� 0:����</returns>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        [MustCustomSerialization]
        int WriteByInput(
            [CustomSerializationMethodParameterAttribute("PMHND09216D", "Broadleaf.Application.Remoting.ParamData.GoodsBarCodeRevnWork")]
		    ref object objGoodsBarCodeRevnWorkList
            );

        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t��ۑ����܂�
        /// </summary>
        /// <param name="objSaveWorkList">�ۑ��p�f�[�^List</param>
        /// <param name="objDeleteWorkList">�폜�p�f�[�^List</param>
        /// <returns>�ۑ��������� 0:����</returns>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t����ۑ����܂�</br>
        /// <br>Programmer : 3H ������</br>
        /// <br>Date       : 2017/06/12</br>
        [MustCustomSerialization]
        int WriteBySave(
            [CustomSerializationMethodParameterAttribute("PMHND09216D", "Broadleaf.Application.Remoting.ParamData.GoodsBarCodeRevnWork")]
			ref object objSaveWorkList, ref object objDeleteWorkList
            );

        // --- ADD 2021/11/18 ������ PJMIT-1499�Ή� �P�v�Ή�------>>>>>
        /// <summary>
        /// ���[�U�[�݌ɏ��i��������
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="condObj">�����p�����[�^</param>
        /// <returns>������������  0:����</returns>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t���}�X�^�����������s���܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2021/11/18</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchStockGoods(out object retObj, object condObj);
        // --- ADD 2021/11/18 ������ PJMIT-1499�Ή� �P�v�Ή�------<<<<<
        #endregion
    }
}
