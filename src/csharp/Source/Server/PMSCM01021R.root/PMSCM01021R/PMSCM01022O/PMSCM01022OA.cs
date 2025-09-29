//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   SCM�֘A�f�[�^DB�C���^�[�t�F�[�X
//                  :   PMSCM01022O.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 ���� ���n
// Date             :   2009.05.13
//----------------------------------------------------------------------
// �Ǘ��ԍ� �@�@�@�@�@�@    �쐬�S���F杍^
// �C����    2011/08/10     �C�����e�FPMSCMXXXX2C.DLL�̓_�~�[���폜
// ---------------------------------------------------------------------//
// �Ǘ��ԍ� �@�@�@�@�@�@    �쐬�S���F30744 ���� ����q
// �C����    2014/03/11     �C�����e�FSCM�d�|�ꗗ��10639�Ή�
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�  11170130-00�@�@�쐬�S���F杍^
// �C����    2015/08/28    �C�����e�FRedmine#47284 SCM�d�|�ꗗ��10722�Ή�
//                         �O���M������ۊǂ���t�@�C�����j���h�~�Ή��iPM�̃��[�U�[DB�Ƀf�[�^��o�^����@�\�ƂȂ�j
// ---------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;
//using Broadleaf.Application.Common;  // ADD 2010/02/26  // DEL 2011/08/10

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// SCM�֘A�f�[�^DB�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : SCM�֘A�f�[�^DB�C���^�[�t�F�[�X�ł��B</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2009.05.13</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]
    public interface IIOWriteScmDB
    {
        // -- DEL 2010/04/15 �g��Ȃ��Ȃ����̂ō폜------------------>>>
        #region [�폜]
        //// -- ADD 2010/03/04 �h�`�`�d����@�\------------------------>>>
        ///// <summary>
        ///// �ǉ�
        ///// </summary>
        //void WriteCustDat(string acntId, int customerCode);

        ///// <summary>
        ///// �폜
        ///// </summary>
        //void DeleteCustDat(string account);

        ///// <summary>
        ///// �擾
        ///// </summary>
        //int ReadCustDat(string account);
        //// -- ADD 2010/03/04 �h�`�`�d����@�\------------------------<<<


        //// -- ADD 2010/02/26 ------------------------>>>
        ///// <summary>
        ///// �ڑ����̒ǉ�
        ///// </summary>
        ///// <param name="info">�ڑ����</param>
        //void AddConnectionInfo(CMTConnectionInfo info);

        ///// <summary>
        ///// �ڑ����̍폜
        ///// </summary>
        ///// <param name="info">�ڑ����</param>
        //void DeleteConnectionInfo(CMTConnectionInfo info);

        ///// <summary>
        ///// �ڑ����̍폜
        ///// </summary>
        ///// <param name="cashRegisterNo">�[���ԍ�</param>
        //void DeleteConnectionInfo(int cashRegisterNo);

        ///// <summary>
        ///// �ڑ����̃N���A�i�S�[���̏����N���A����j
        ///// </summary>
        //void ClearConnectionInfo();
        #endregion
        // -- DEL 2010/04/15 �g��Ȃ��Ȃ����̂ō폜------------------<<<

        /// <summary>
        /// �V�������擾�p
        /// </summary>
        /// <param name="retAcOdrDataObj">��������</param>
        /// <param name="paraSCMReadObj">���o�����p�����[�^���[�N</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : ���񓚂̂r�b�l�󒍃f�[�^���擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2010.02.26</br>
        [MustCustomSerialization]
        int GetOrderNewCount(
//            [CustomSerializationMethodParameterAttribute("PMSCM01023D", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork")]
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            out object retAcOdrDataObj,
            object paraSCMReadObj
            );
        // -- ADD 2010/02/26 ------------------------<<<

        /// <summary>
        /// SCM�֘A�f�[�^�����擾���܂��B
        /// </summary>
        /// <param name="retScmCsObj">SCM�֘A�f�[�^���ʃI�u�W�F�N�g</param>
        /// <param name="paraSCMReadObj">�ǂݍ��݃p�����[�^���[�N</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�֘A�f�[�^�̃L�[�l����v����SCM�֘A�f�[�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.05.13</br>
        [MustCustomSerialization]
        int ScmRead(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object retScmCsObj,
            object paraSCMReadObj
            );

        /// <summary>
        /// SCM�֘A�f�[�^�����擾���܂��B
        /// </summary>
        /// <param name="retScmCsObj">SCM�֘A�f�[�^���ʃI�u�W�F�N�g</param>
        /// <param name="paraSCMReadObj">�ǂݍ��݃p�����[�^���[�N</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�֘A�f�[�^�̃L�[�l����v����SCM�֘A�f�[�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.05.13</br>
        [MustCustomSerialization]
        int ScmSearch(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object retScmCsObj,
            object paraSCMReadObj
            );

        /// <summary>
        /// �����M��SCM�֘A�f�[�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="retScmCsObj">��������</param>
        /// <param name="paraSCMReadObj">���o�����p�����[�^���[�N</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����M��SCM�֘A�f�[�^�̃L�[�l����v����A�S�Ă�SCM�֘A�f�[�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.06.18</br>
        [MustCustomSerialization]
        int ScmZeroSearch(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object retScmCsObj, object paraSCMReadObj);

        // ADD 2014/03/11 SCM�d�|�ꗗ��10639�Ή� ---------------------------------------------------------->>>>>
        /// <summary>
        /// �����M��SCM�֘A�f�[�^���̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="retScmCsObj">��������</param>
        /// <param name="paraSCMReadObj">���o�����p�����[�^���[�N</param>
        /// <param name="paraSalesSlipNumList">���o�����p�����[�^���[�N</param>
        /// <param name="paraInquiryNumber">���o�����p�����[�^���[�N</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �����M��SCM�֘A�f�[�^�̃L�[�l����v����A�S�Ă�SCM�֘A�f�[�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.06.18</br>
        [MustCustomSerialization]
        int ScmZeroSearch(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object retScmCsObj, object paraSCMReadObj, object paraSalesSlipNumList, long paraInquiryNumber);
        // ADD 2014/03/11 SCM�d�|�ꗗ��10639�Ή� ----------------------------------------------------------<<<<<

        /// <summary>
        /// �r�b�l�󒍃f�[�^���擾���܂��B
        /// </summary>
        /// <param name="retAcOdrDataObj">��������(SCM�󒍃f�[�^�C���X�^���X)</param>
        /// <param name="paraSCMReadObj">���o�����p�����[�^���[�N</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �񓚋敪�ōi�荞�񂾍ŐV�̂r�b�l�󒍃f�[�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.05.26</br>
        [MustCustomSerialization]
        int ScmAnswerRead(
            [CustomSerializationMethodParameterAttribute("PMSCM01023D", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork")]
            out object retAcOdrDataObj,
            object paraSCMReadObj
            );

        /// <summary>
        /// �r�b�l�󒍖��׃f�[�^(�⍇���E����)�̍ŐV���R�[�h���P���̂ݎ擾���܂��B
        /// </summary>
        /// <param name="retAcOdrDtlIqObj">��������(SCM�󒍖��׃f�[�^(�⍇���E����)�C���X�^���X)</param>
        /// <param name="paraSCMReadObj">���o�����p�����[�^���[�N</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ŐV�̂r�b�l�󒍖��׃f�[�^(�⍇���E����)�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.06.16</br>
        [MustCustomSerialization]
        int ScmDtlIqRead(
            [CustomSerializationMethodParameterAttribute("PMSCM01023D", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlIqWork")]
            out object retAcOdrDtlIqObj,
            object paraSCMReadObj
            );

        // -- ADD 2010/04/15 ----------------------------------------->>>
        /// <summary>
        /// �r�b�l�󒍃f�[�^���擾���܂��B(CTI�Ŏg�p)
        /// </summary>
        /// <param name="retAcOdrDataObj">��������(SCM�󒍃f�[�^�C���X�^���X)</param>
        /// <param name="paraAcOdrDataObj">���o�����p�����[�^���[�N</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �r�b�l�󒍃f�[�^�����擾���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2010/04/15</br>
        [MustCustomSerialization]
        int GetSCMAcOdrData(
            // 2011/03/03 >>>
            //[CustomSerializationMethodParameterAttribute("PMSCM01023D", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork")]
            //out object retAcOdrDataObj,
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref CustomSerializeArrayList retAcOdrDataObj,
            // 2011/03/03 <<<
            object paraAcOdrDataObj
            );
        // -- ADD 2010/04/15 -----------------------------------------<<<

        //>>>2010/04/20
        /// <summary>
        /// �r�b�l�󒍃f�[�^���擾���܂��B
        /// </summary>
        /// <param name="retAcOdrDataObj">��������(SCM�󒍃f�[�^�C���X�^���X)</param>
        /// <param name="paraAcOdrDataObj">���o�����p�����[�^���[�N</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �r�b�l�󒍃f�[�^�����擾���܂��B</br>
        /// <br>Programmer : 20056 ���n ���</br>
        /// <br>Date       : 2010/04/20</br>
        [MustCustomSerialization]
        int ScmAcOdrDataSearch(
            [CustomSerializationMethodParameterAttribute("PMSCM01023D", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork")]
            out object retAcOdrDataObj,
            object paraAcOdrDataObj
            );
        //<<<2010/04/20

        /// <summary>
        /// SCM�֘A�f�[�^����ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="retScmCsObj">�ǉ��E�X�V����SCM�֘A�f�[�^�����܂� CustomSerializeArrayList</param>
        /// <param name="writemode">�X�V���[�h 0:Insert�̂�, 1:UpDateInsert</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : retScmCsList �Ɋi�[����Ă���SCM�֘A�f�[�^����ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.05.13</br>
        [MustCustomSerialization]
        int ScmWrite(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object retScmCsObj, int writemode);

        /// <summary>
        /// SCM�֘A�f�[�^����DeleteInsert���܂��B
        /// </summary>
        /// <param name="retScmCsObj">DeleteInsert����SCM�֘A�f�[�^�����܂� CustomSerializeArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : retScmCsObj �Ɋi�[����Ă���SCM�֘A�f�[�^����DeleteInsert���܂��B</br>
        /// <br>Programmer : 22008 ���� ���n</br>
        /// <br>Date       : 2009.06.18</br>
        [MustCustomSerialization]
        int ScmDeleteInsert(
            [CustomSerializationMethodParameterAttribute("SFCMN00021C", "Broadleaf.Library.Collections.CustomSerializeArrayList")]
            ref object retScmCsObj);

        // ADD 2015/08/28 杍^ Redmine#47284 SCM�d�|�ꗗ��10722�Ή�  --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �V���ŏI�擾�������擾���܂�
        /// </summary>
        /// <param name="scmTimeDataWork">���o�����p�����[�^���[�N</param>
        /// <param name="retscmTimeDataObj">��������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �V���ŏI�擾�������擾���܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2015/08/28</br>
        [MustCustomSerialization]
        int SearchScmTimeData(
            ScmTimeDataWork scmTimeDataWork,
            [CustomSerializationMethodParameterAttribute("PMSCM01023D", "Broadleaf.Application.Remoting.ParamData.ScmTimeDataWork")]
            out object retscmTimeDataObj
            );

        /// <summary>
        /// SCM�V���f�[�^�\���Ǘ�����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="scmReadWork">���o�����p�����[�^���[�N</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : SCM�V���f�[�^�\���Ǘ�����o�^�A�X�V���܂�</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2015/08/28</br>
        [MustCustomSerialization]
        int UpdateScmTimeData(
            ScmTimeDataWork scmReadWork
            );
        // ADD 2015/08/28 杍^ Redmine#47284 SCM�d�|�ꗗ��10722�Ή�  ---------<<<<<<<<<<<<<<<<<<<<<<<<<
    }
}
