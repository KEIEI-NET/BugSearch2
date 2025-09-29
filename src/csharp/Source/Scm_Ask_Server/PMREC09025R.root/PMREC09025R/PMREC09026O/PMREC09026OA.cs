//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����������i�ݒ�}�X�^�����e
// �v���O�����T�v   : �����������i�ݒ�}�X�^DB�C���^�[�t�F�[�X
//----------------------------------------------------------------------------//
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ��Y
// �� �� ��  2015/01/19  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���X�� �j
// �� �� ��  2015/02/23  �C�����e : ���C�A�E�g�ύX�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    ///  �����������i�ݒ�}�X�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����������i�ݒ�}�X�^DB�C���^�[�t�F�[�X</br>
    /// <br>Programmer : ���� ��Y</br>
    /// <br>Date       : 2015/01/19</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]
    //[APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IRecBgnGdsDB
    {
        //--- ADD  2015/02/23 ���X�� ----->>>>>

        #region Search�F��������
        /// <summary>
        /// �w���Ҍ������������B
        /// </summary>
        /// <param name="retobj">RecBgnGdsWork�������ʃf�[�^���X�g</param>
        /// <param name="paraobj">RecBgnGdsSearchParaWork�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜���[�h(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="count">����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������i�ݒ�}�X�^�����������ʃ��X�g��ԋp���܂��B�i�_���폜�����j</br>
        /// <br>Programmer : ���{ �G�I</br>
        /// <br>Date       : 2015/02/25</br>
        /// </remarks>
        [MustCustomSerialization]
        int SearchForBuyer(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
			out object retobj,
            object paraobj,
            ConstantManagement.LogicalMode logicalMode,
            out int count,
            ref string errmsg);

        /// <summary>
        /// ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�F���������i�_���폜�����j
        /// </summary>
        /// <param name="retobj">RecBgnGdsPMWork�������ʃf�[�^���X�g</param>
        /// <param name="retCustobj">RecBgnCustPMWork�������ʃf�[�^���X�g</param>
        /// <param name="paraobj">RecBgnGdsPMSearchParaWork�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜���[�h(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="count">����</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�����������ʃ��X�g��ԋp���܂��B�i�_���폜�����j</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork")]
			out object retobj,
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnCustPMWork")]
			out object retCustobj,
            object paraobj,
            ConstantManagement.LogicalMode logicalMode,
            out int count,
            ref string errmsg);

        /// <summary>
        /// ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�F���������i�_���폜�����j
        /// </summary>
        /// <param name="retobj">RecBgnGdsPMWork�������ʃf�[�^���X�g</param>
        /// <param name="retCustobj">RecBgnCustPMWork�������ʃf�[�^���X�g</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜���[�h(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <br>Note       : ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�����������ʃ��X�g��ԋp���܂��B�i�_���폜�����j</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        [MustCustomSerialization]
        int Search(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork")]
			out object retobj,
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnCustPMWork")]
			out object retCustobj,
            string inqOtherEpCd,
            ConstantManagement.LogicalMode logicalMode,
            ref string errMsg);

        #endregion

        #region Write

        /// <summary>
        /// ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�APM�������i�}�X�^�o�^�A�X�V����
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWork�o�^�f�[�^</param>
        /// <param name="paraCustobj">RecBgnCustPMWork�o�^�f�[�^</param>
        /// <param name="retIsolobj">PmISolPrcWork�o�^�f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�APM�������i�}�X�^��o�^�A�X�V���܂��B</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Write(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork")]
            ref object paraobj,
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnCustPMWork")]
            ref object paraCustobj,
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.PmIsolPrcWork")]
            ref object retIsolobj
           );

        #endregion

        #region Read

        /// <summary>
        /// ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�APM�������i�}�X�^ ��������
        /// </summary>
        /// <param name="retobj">RecBgnPMWork�������ʃ��X�g</param>
        /// <param name="retCustobj">RecBgnCustPMWork�������ʃ��X�g</param>
        /// <param name="paraobj">RecBgnGdsPMWork�����f�[�^</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^���������܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork")]
            ref object retobj,
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnCustPMWork")]
            ref object retCustobj,
            object paraobj,
            ref string errMsg);

        #endregion

        #region Delte

        /// <summary>
        /// ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^ ���S�폜����
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWork�f�[�^</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�𕨗��폜���܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int Delete(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork")]
            object paraobj);

        #endregion

        #region RevivalLogicalDelete

        /// <summary>
        /// ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^���S�폜�E���������i���X�g�����j
        /// </summary>
        /// <param name="paraDelObj">RecBgnGdsPMWork�폜�f�[�^���X�g</param>
        /// <param name="paraUpdObj">RecBgnGdsPMWork�����f�[�^���X�g</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <br>Note       : ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�����S�폜�A�������܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        [MustCustomSerialization]
        int DeleteAndRevival(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork")]
            object paraDelObj,
            ref object paraUpdObj);

        /// <summary>
        /// ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^ ��������
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWork�f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int RevivalLogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork")]
            ref object paraobj);

        #endregion

        /// <summary>
        /// ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�APM�������i�}�X�^ ���S�폜�E�_���폜�E�o�^�E�X�V�����i���X�g�����j
        /// </summary>
        /// <param name="paraDelObj">RecBgnGdsPMWork�폜�f�[�^���X�g</param>
        /// <param name="paraUpdObj">RecBgnGdsPMWork�o�^�E�X�V�f�[�^���X�g</param>
        /// <param name="paraCustUpdObj">RecBgnCustPMWork�o�^�E�X�V�f�[�^���X�g</param>
        /// <param name="paraIsolUpdObj">PmIsolPrcWork�o�^�E�X�V�f�[�^���X�g</param>
        /// <param name="errorObj">RecBgnGdsWork�G���[���X�g</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <br>Note       : ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�APM�������i�}�X�^�����S�폜�A�_���폜�A�o�^�E�X�V���܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        [MustCustomSerialization]
        int DeleteAndWrite(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork")]
            object paraDelObj,
            ref object paraUpdObj,
            ref object paraCustUpdObj,
            ref object paraIsolUpdObj,
            out object errorObj);

        #region LogicalDelete

        /// <summary>
        /// ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^�_���폜����
        /// </summary>
        /// <param name="paraobj">RecBgnGdsPMWork�f�[�^</param>
        /// <returns>���ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i�ݒ�}�X�^�A���������i���Ӑ�ʐݒ�}�X�^��_���폜���܂�</br>
        /// <br>Programmer : ���X�� �j</br>
        /// <br>Date       : 2015/02/23</br>
        /// </remarks>
        [MustCustomSerialization]
        int LogicalDelete(
            [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsPMWork")]
            ref object paraobj);

        #endregion

        //--- DEL  2015/02/23 ���X�� ----->>>>>
        #region ���C�A�E�g�ύX�O�R�����g
        //#region Search�F��������
        //
        ///// <summary>
        ///// ���������i�_���폜�����j
        ///// </summary>
        ///// <param name="retobj">RecBgnGdsWork�������ʃf�[�^���X�g</param>
        ///// <param name="paraobj">RecBgnGdsSearchParaWork�����p�����[�^</param>
        ///// <param name="logicalMode">�_���폜���[�h(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        ///// <param name="count">����</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>���ʃX�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note       : �����������i�ݒ�}�X�^�����������ʃ��X�g��ԋp���܂��B�i�_���폜�����j</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //[MustCustomSerialization]
        //int Search(
        //    [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
		//	out object retobj,
        //    object paraobj,
        //    ConstantManagement.LogicalMode logicalMode,
        //    out int count,
        //    ref string errmsg);
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^�F���������i�_���폜�����j
        ///// </summary>
        ///// <param name="retobj">RecBgnGdsWork�������ʃf�[�^���X�g</param>
        ///// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        ///// <param name="logicalMode">�_���폜���[�h(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>���ʃX�e�[�^�X</returns>
        ///// <br>Note       : �����������i�ݒ�}�X�^�����������ʃ��X�g��ԋp���܂��B�i�_���폜�����j</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        //[MustCustomSerialization]
        //int Search(
        //    [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
        //	out object retobj,
        //    string inqOtherEpCd,
        //    ConstantManagement.LogicalMode logicalMode,
        //    ref string errMsg);
        //
        //#endregion
        //
        //#region Write
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^�o�^�A�X�V����
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWork�o�^�f�[�^</param>
        ///// <returns>�X�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //[MustCustomSerialization]
        //int Write(
        //    [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
        //    ref object paraobj);
        //
        //#endregion
        //
        //#region Read
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^ ��������
        ///// </summary>
        ///// <param name="retobj">RecBgnGdsWork�������ʃ��X�g</param>
        ///// <param name="paraobj">RecBgnGdsWork�����f�[�^</param>
        ///// <param name="errMsg">�G���[���b�Z�[�W</param>
        ///// <returns>�X�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note       : �����������i�ݒ�}�X�^���������܂�</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //[MustCustomSerialization]
        //int Read(
        //    [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
        //    ref object retobj,
        //    object paraobj,
        //    ref string errMsg);
        //
        //#endregion
        //
        //#region Delte
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^ ���S�폜����
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWork�f�[�^</param>
        ///// <returns>���ʃX�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note       : �����������i�ݒ�}�X�^�𕨗��폜���܂�</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //[MustCustomSerialization]
        //int Delete(
        //    [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
        //    object paraobj);
        //
        //#endregion
        //
        //#region RevivalLogicalDelete
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^ ���S�폜�E���������i���X�g�����j
        ///// </summary>
        ///// <param name="paraDelObj">RecBgnGdsWork�폜�f�[�^���X�g</param>
        ///// <param name="paraUpdObj">RecBgnGdsWork�����f�[�^���X�g</param>
        ///// <returns>���ʃX�e�[�^�X</returns>
        ///// <br>Note       : �����������i�ݒ�}�X�^�����S�폜�A�������܂�</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        //[MustCustomSerialization]
        //int DeleteAndRevival(
        //    [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
        //    object paraDelObj,
        //    ref object paraUpdObj);
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^ ��������
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWork�f�[�^</param>
        ///// <returns>�X�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //[MustCustomSerialization]
        //int RevivalLogicalDelete(
        //    [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
        //    ref object paraobj);
        //
        //#endregion
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^ ���S�폜�E�_���폜�E�o�^�E�X�V�����i���X�g�����j
        ///// </summary>
        ///// <param name="paraDelObj">RecBgnGdsWork�폜�f�[�^���X�g</param>
        ///// <param name="paraUpdObj">RecBgnGdsWork�o�^�E�X�V�f�[�^���X�g</param>
        ///// <param name="errorObj">RecBgnGdsWork�G���[���X�g</param>
        ///// <returns>���ʃX�e�[�^�X</returns>
        ///// <br>Note       : �����������i�ݒ�}�X�^�����S�폜�A�_���폜�A�o�^�E�X�V���܂�</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        //[MustCustomSerialization]
        //int DeleteAndWrite(
        //    [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
        //    object paraDelObj,
        //    ref object paraUpdObj,
        //    out object errorObj);
        //
        //#region LogicalDelete
        //
        ///// <summary>
        ///// �����������i�ݒ�}�X�^ �_���폜����
        ///// </summary>
        ///// <param name="paraobj">RecBgnGdsWork�f�[�^</param>
        ///// <returns>���ʃX�e�[�^�X</returns>
        ///// <remarks>
        ///// <br>Note       : �����������i�ݒ�}�X�^��_���폜���܂�</br>
        ///// <br>Programmer : ���� ��Y</br>
        ///// <br>Date       : 2015/01/19</br>
        ///// </remarks>
        //[MustCustomSerialization]
        //int LogicalDelete(
        //    [CustomSerializationMethodParameterAttribute("PMREC09027D", "Broadleaf.Application.Remoting.ParamData.RecBgnGdsWork")]
        //    ref object paraobj);
        //
        //#endregion
        //
        #endregion
        //--- DEL  2015/02/23 ���X�� -----<<<<<

    }   
}