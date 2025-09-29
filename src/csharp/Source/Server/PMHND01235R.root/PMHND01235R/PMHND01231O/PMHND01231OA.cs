//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�J�[�i�ԃp�^�[���}�X�^
// �v���O�����T�v   : ���[�J�[�i�ԃp�^�[���}�X�^ DBRemoteObject�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright 2020 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570249-00   �쐬�S�� : ���O
// �� �� ��  2020/03/09    �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ���[�J�[�i�ԃp�^�[���}�X�^DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���[�J�[�i�ԃp�^�[���}�X�^DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : ���O</br>
	/// <br>Date       : 2020/03/09</br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IHandyMakerGoodsPtrnDB
	{
		#region �J�X�^���V���A���C�Y�Ή����\�b�h
        /// <summary>
        /// ���[�J�[�i�ԃp�^�[���}�X�^���𕨗��폜���܂�
        /// </summary>
        /// <param name="paraMakerGoodsPtrnWork">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�J�[�i�ԃp�^�[���}�X�^���𕨗��폜���܂�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        int Delete(object paraMakerGoodsPtrnWork);

		/// <summary>
		/// ���[�J�[�i�ԃp�^�[���}�X�^LIST��S�Ė߂��܂��i�_���폜�����j:�J�X�^���V���A���C�Y
		/// </summary>
		/// <param name="makerGoodsPtrnWork">��������</param>
        /// <param name="paraMakerGoodsPtrnWork">�����p�����[�^</param>
		/// <param name="readMode">�����敪</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
		/// <returns>STATUS</returns>
        /// <br>Note       : ���[�J�[�i�ԃp�^�[���}�X�^LIST��S�Ė߂��܂��i�_���폜�����j</br>
		/// <br>Programmer : ���O</br>
		/// <br>Date       : 2020/03/09</br>
		[MustCustomSerialization]
		int Search(
            [CustomSerializationMethodParameterAttribute("PMHND01234D", "Broadleaf.Application.Remoting.ParamData.HandyMakerGoodsPtrnWork")]
			out object makerGoodsPtrnWork,
            HandyMakerGoodsPtrnWork paraMakerGoodsPtrnWork, int readMode, ConstantManagement.LogicalMode logicalMode);

        /// <summary>
        /// �w�肳�ꂽ�����̃��[�J�[�i�ԃp�^�[���}�X�^����߂��܂�
        /// </summary>
        /// <param name="parabyte">HandyMakerGoodsPtrnWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃��[�J�[�i�ԃp�^�[���}�X�^����߂��܂�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        int Read(ref byte[] parabyte, int readMode);

        /// <summary>
        /// �w�肳�ꂽ�����̃��[�J�[�i�ԃp�^�[���}�X�^����߂��܂�
        /// </summary>
        /// <param name="makerGoodsPtrnWorkList">makerGoodsPtrnWorkList�I�u�W�F�N�g</param>
        /// <param name="paraMakerGoodsPtrnWork">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="mode">0�F�}�X�^�p�G1�F���i����p</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����̃��[�J�[�i�ԃp�^�[���}�X�^����߂��܂�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        int ReadByMakerAndBarCodeLength(
            [CustomSerializationMethodParameterAttribute("PMHND01234D", "Broadleaf.Application.Remoting.ParamData.HandyMakerGoodsPtrnWork")]
			out object makerGoodsPtrnWorkList,
           HandyMakerGoodsPtrnWork paraMakerGoodsPtrnWork, 
            int readMode, int mode);

		/// <summary>
		/// ���[�J�[�i�ԃp�^�[���}�X�^����o�^�A�X�V���܂�
		/// </summary>
        /// <param name="parabyte">HandyMakerGoodsPtrnWork�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�J�[�i�ԃp�^�[���}�X�^����o�^�A�X�V���܂�</br>
		/// <br>Programmer : ���O</br>
		/// <br>Date       : 2020/03/09</br>
        int Write(ref byte[] parabyte);

		/// <summary>
		/// ���[�J�[�i�ԃp�^�[���}�X�^����_���폜���܂�
		/// </summary>
        /// <param name="paraMakerGoodsPtrnWork">��������</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : ���[�J�[�i�ԃp�^�[���}�X�^����_���폜���܂�</br>
		/// <br>Programmer : ���O</br>
		/// <br>Date       : 2020/03/09</br>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMHND01234D", "Broadleaf.Application.Remoting.ParamData.HandyMakerGoodsPtrnWork")]
            ref object paraMakerGoodsPtrnWork
			);

		/// <summary>
		/// �_���폜���[�J�[�i�ԃp�^�[���}�X�^���𕜊����܂�
		/// </summary>
        /// <param name="paraMakerGoodsPtrnWork">��������</param>
		/// <returns>STATUS</returns>
		/// <br>Note       : �_���폜���[�J�[�i�ԃp�^�[���}�X�^���𕜊����܂�</br>
		/// <br>Programmer : ���O</br>
		/// <br>Date       : 2020/03/09</br>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMHND01234D", "Broadleaf.Application.Remoting.ParamData.HandyMakerGoodsPtrnWork")]
            ref object paraMakerGoodsPtrnWork
			);
		#endregion

        #region  [���[�J�[�i�ԃp�^�[���}�X�^���������Ɖ�]
        /// <summary>
        /// ���[�J�[�i�ԃp�^�[���}�X�^�������𒊏o����
        /// </summary>
        /// <param name="condObj">��������</param>
        /// <param name="retObj">���[�J�[�i�ԃp�^�[���}�X�^�����������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�i�ԃp�^�[���}�X�^�������𒊏o�������s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchHis(object condObj, out object retObj);
        #endregion

        #region  [���i�o�[�R�[�h�֘A�t���}�X�^����]
        /// <summary>
        /// ���i�o�[�R�[�h�֘A�t���}�X�^��������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsBarCode">�p�[�R�[�h</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="retObj">���i�o�[�R�[�h�֘A�t���}�X�^���</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�o�[�R�[�h�֘A�t���}�X�^�����������s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchGoodsBarCodeRevn(string enterpriseCode, string goodsBarCode, int goodsMakerCd, out object retObj);
        #endregion

        #region  [�n���f�B�݌ɓo�^�Ǘ��f�[�^�o�^]
        /// <summary>
        /// �n���f�B�݌ɓo�^�Ǘ��f�[�^�o�^����
        /// </summary>
        /// <param name="condObj">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �n���f�B�݌ɓo�^�Ǘ��f�[�^�o�^�������s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        [MustCustomSerialization]
        int WriteMng(object condObj);
        #endregion
        
        #region  [UOE�����f�[�^���݃`�F�b�N]
        /// <summary>
        /// UOE�����f�[�^���݃`�F�b�N����
        /// </summary>
        /// <param name="condObj">��������</param>
        /// <param name="count">�߂茏��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : UOE�����f�[�^���݃`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchHandyUOEOrder(ref object condObj, out int count);
        #endregion

        #region  [�݌Ɉꊇ�폜�Ώی�������]
        /// <summary>
        /// �݌Ɉꊇ�폜�Ώی�������
        /// </summary>
        /// <param name="condObj">��������</param>
        /// <param name="retObj">�݌Ɉꊇ�폜�Ώۏ��</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �݌Ɉꊇ�폜�Ώی����������s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchDeleteStockWithMng(object condObj,
             [CustomSerializationMethodParameterAttribute("PMHND01234D", "Broadleaf.Application.Remoting.ParamData.HandyDeleteStockRsltWork")]
             out object retObj);

        /// <summary>
        /// �݌Ɉꊇ�폜�Ώۍ폜����
        /// </summary>
        /// <param name="handyDeleteStockRsltWork">�폜����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �݌Ɉꊇ�폜�Ώۍ폜���܂�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        int DeleteStockWithMng(object handyDeleteStockRsltWork, string enterpriseCode);
        #endregion

        #region [���[�J�[�i�ԃp�^�[�����������f�[�^�o�^]
        /// <summary>
        /// ���[�J�[�i�ԃp�^�[�����������f�[�^��o�^�A�X�V���܂�
        /// </summary>
        /// <param name="parabyte">HandyMakerGoodsPtrnHisResultWork�I�u�W�F�N�g</param>
        /// <param name="mode">0:�V�K�o�^�G1�F�X�V</param>
        /// <param name="callMode">0�F�p�^�[�����������G1�F�p�^�[�����������ȊO</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���[�J�[�i�ԃp�^�[�����������f�[�^��o�^�A�X�V���܂�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2020/03/09</br>
        int WriteHis(ref byte[] parabyte, int mode, int callMode);
        #endregion
	}
}
