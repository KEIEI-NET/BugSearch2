//**********************************************************************//
// �V�X�e��         �FPM.NS
// �v���O��������   �FPMTAB �����񓚏���(����) �e�[�u���A�N�Z�X�N���X
// �v���O�����T�v   �FPMTAB�풓�������p�����[�^�Ŏԗ��A���i�����������n�����
//                    �ԗ��A���i�����������ԗ��A���i�̌������s���A
//                    �擾��������SCM_DB�̌������ʊ֘A�̃e�[�u���ɏ�����
// ---------------------------------------------------------------------//
//					Copyright(c) 2013 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10902622-01  �쐬�S�� : songg
// �� �� ��  2013/05/29   �쐬���e : PMTAB �����񓚏���(����)
//----------------------------------------------------------------------//
// �C�����e�@�\�[�X�`�F�b�N�m�F�����ꗗ��No.35�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg                                    
// �� �� ��  2013/06/18  �쐬���e : BL�O���[�v�R�[�h�J�i���̂��ݒ肳��Ă��܂���B
//----------------------------------------------------------------------//
// �C�����e�@�\�[�X�`�F�b�N�m�F�����ꗗ��No.36�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg                                    
// �� �� ��  2013/06/18  �쐬���e : �ԗ��������A�S�I���̃��W�b�N��ǉ�����
//----------------------------------------------------------------------//
// �C�����e�@�\�[�X�`�F�b�N�m�F�����ꗗ��No.39�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg                                    
// �� �� ��  2013/06/18  �쐬���e : ���Ӑ��񂪑��݂��Ȃ��ɂ��ւ�炸�A����œ]�ŕ����͏���Őݒ�̏���œ]�ŕ����ɐݒ肵�܂��B
//----------------------------------------------------------------------//
// �C�����e�@�\�[�X�`�F�b�N�m�F�����ꗗ��No.42�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg                                    
// �� �� ��  2013/06/18  �쐬���e : BL�R�[�h�����^�i�Ԍ����Ńq�b�g���Ȃ������ꍇ�A����ɓ��삵�܂���B
//----------------------------------------------------------------------//
// �C�����e�@�\�[�X�`�F�b�N�m�F�����ꗗ��No.44�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : huangt                                    
// �� �� ��  2013/06/20  �쐬���e : BL�R�[�h�����^�i�Ԍ�����̖߂�l�̑Ή�
//----------------------------------------------------------------------//
// �C�����e�@�\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : licb                                   
// �� �� ��  2013/06/20  �쐬���e : PMTAB���Ӑ�}�X�^(�|���O���[�v)�APMTAB���i�Ǘ����}�X�^�@�̏�����ǉ����ĉ������B
//----------------------------------------------------------------------//
// �C�����e�@�\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg                                   
// �� �� ��  2013/06/20  �쐬���e : PMTAB���Ӑ�}�X�^(�|���O���[�v)�APMTAB���i�Ǘ����}�X�^�@�̏�����ǉ����ĉ������B
//----------------------------------------------------------------------//
// �C�����e�@�\�[�X�`�F�b�N�m�F�����ꗗ��No.43�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : huangt                                    
// �� �� ��  2013/06/20  �쐬���e : �ԗ��������SCM-DB��PMTAB����(�ԗ����)�Z�b�V�����Ǘ��g�����U�N�V�����f�[�^���X�V���܂��B
//----------------------------------------------------------------------//
// �C�����e�@�\�[�X�`�F�b�N�m�F�����ꗗ��No.48�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : huangt                                    
// �� �� ��  2013/06/21  �쐬���e : ���q�������ɁA�J���[��ԑ�ԍ����w�肵�Ă��i���݂��s���Ȃ��B
//----------------------------------------------------------------------//
// �C�����e�@�d�l�A�� #37004�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg                                    
// �� �� ��  2013/06/20  �쐬���e : �y�����񓚏���(����)(�o�l�{�̑�)�z�^������̎ԗ��������\�ɂ���
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #37128�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : huangt                                    
// �� �� ��  2013/06/24  �쐬���e : �����񓚏���(����) �\�[�X���C�����ĉ�����
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #36972�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : huangt                                    
// �� �� ��  2013/06/24  �쐬���e : ���i�������ɋ󔒃��b�Z�[�W���\�������
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #37127�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg                                    
// �� �� ��  2013/06/24  �쐬���e : �ԗ��m���� �����񓚏����i�����j�ŃG���[�ɂȂ�܂�
//                                  �ԗ��������A�^���w��ԍ��E�ޕʋ敪�ԍ��E�^���ɒl���ݒ肳��Ă��Ȃ����A
//                                  �w�E�E�m�F�����ꗗ��No.42�̑Ή��Ɠ������i�������ʂ݂̂�SCM-DB�֏������݂��鏈��
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #37172�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg                                    
// �� �� ��  2013/06/24  �쐬���e : �����񓚏���(����) �@�ԗ������ŃJ���[�E�g�����̍i���݂��ł��܂���
//                                  �����ԗ������݂��鎞�͍i���݉\�B�P��ԗ��̎��͍i���݂ł��܂���B
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #37187�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg                                    
// �� �� ��  2013/06/25  �쐬���e : ����S�̐ݒ�}�X�^���擾���A���_�R�[�h�̒��o�ŊY���f�[�^�����݂��Ȃ����́A"00"�i�S�Ћ��ʁj�ōēx���o���s���A
//                                �@�Y���f�[�^���ݎ��͑S�Ћ��ʂ̃f�[�^��ΏۂƂ���
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #37010�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg                                    
// �� �� ��  2013/06/25  �쐬���e : �y���i���́z����̎ԗ���I�������ꍇ�A���i�����Ɏ��s����B
//                                �@�N����999999�̏ꍇ�ADateTime.MaxValue��ݒ肷��
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #37231�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : huangt                                    
// �� �� ��  2013/06/25  �쐬���e : �^�u���b�g���O�Ή�
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #37360�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg                                    
// �� �� ��  2013/06/27  �쐬���e : �y�����񓚏���(����)�z�ԗ��m���ʂŌ^���̂ݓ��͂���BL�R�[�h�������s���Ǝԗ������ŃG���[�ɂȂ�܂�
//                                   �ԗ������Ŗ߂�lsearchedCarResult�̒l��retMultipleCarKind�Ŗ߂��Ă����ꍇ�A�G���[����������B
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #37738�̑Ή��@               �@      
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : licb                                    
// �� �� ��  2013/07/02  �쐬���e : �y�����񓚏���(����)�z�J���[�R�[�h���\������Ȃ��B
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #37755�̑Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : huangt
// �� �� ��  2013/07/03  �쐬���e : ���x���P
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #37983�̑Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg
// �� �� ��  2013/07/08  �쐬���e : �ԗ����̔r�C�ʂ��G���W���^���ɃZ�b�g����Ă��܂��܂��B
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #38046�̑Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg
// �� �� ��  2013/07/09  �쐬���e : �i�Ԍ������̎ԗ��S�I�������ǉ�
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #38106�̑Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg
// �� �� ��  2013/07/10  �쐬���e : �D�Ǖi�ԓ_�t����
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #38120�̑Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : licb
// �� �� ��  2013/07/10  �쐬���e : �����i�ԓ_�t����
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #38220�̑Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : huangt
// �� �� ��  2013/07/11  �쐬���e : �s�K�v�ȃ��O�o�͂̍폜
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #38116�̑Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : huangt
// �� �� ��  2013/07/12  �쐬���e : �L�����y�[�������D��ݒ�}�X�^�ǉ�
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #38573�̑Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg
// �� �� ��  2013/07/18  �쐬���e : �y�����񓚓o�^�i�����j�z�󒍃}�X�^�i�ԗ��j�A�����I�u�W�F�N�g�z��^���R�����^���Œ�ԍ��z��
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #38511�̑Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : wangl2
// �� �� ��  2013/07/18  �쐬���e : �y���i���́z�ʂ̊Ǘ����_�̓��Ӑ��I�����āA���͂����ۂɁA�|���������͋��_�ŎZ�o����Ă��܂�
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #38106��#13�Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg
// �� �� ��  2013/07/18  �쐬���e : �i�[����Ă��錋�����`�F�b�N�����ǉ�
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #38628�Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg
// �� �� ��  2013/07/19  �쐬���e : ���C�A�E�g�ύX�Ή��˗�, �n���R�[�h�A���Y�N���R�[�h��ǉ�����B
//----------------------------------------------------------------------//
// �C�����e�@�w�E�E�m�F�����ꗗ_�Г��m�F�p��376
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �g��
// �� �� ��  2013/07/22  �쐬���e : �����i�Ԍ������A�����I����ʂ��\��������Q�̑Ή��i�i�Ԍ����A�_�t���������̌��������C���j
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #38992�Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �A����
// �� �� ��  2013/07/23  �쐬���e : �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #39039�Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : huangt
// �� �� ��  2013/07/24  �쐬���e : ���i���� �g�p���鋒�_�R�[�h�̏C��
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #39168�Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg
// �� �� ��  2013/07/25  �쐬���e : �i�Ԍ������s���ƌ������ʂ̃��[�U�[���i�������ʂ̒񋟃f�[�^�敪���K��97�ɂȂ�
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #39055�Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �g��
// �� �� ��  2013/07/24  ���P���v�Z�ɂ��Ă̏C��
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #39203�Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �g��
// �� �� ��  2013/07/26  �̔��敪�͉�ʂ���ύX�\�Ȃ̂ŁA�S���o�^����
//----------------------------------------------------------------------//
// �C�����e�@���O������
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �g��
// �� �� ��  2013/07/29  �쐬���e : ���O������
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #39386�Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : songg
// �� �� ��  2013/07/30  �쐬���e : ���Џ��}�X�^�ǉ�
//----------------------------------------------------------------------//
// �C�����e�@���������� ���f�ǉ� 
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �g��
// �� �� ��  2013/07/30  �쐬���e : ���������� ���f �ǉ�
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #39386�Ή� 
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : ����
// �� �� ��  2013/07/31  �쐬���e : �P���Z�o�N���X�ďo���̃v���p�e�B�ݒ�ǉ�
//----------------------------------------------------------------------//
// �C�����e�@���i���������@���Ӑ�Ǘ����_�Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �g��
// �� �� ��  2013/07/31  �쐬���e : ���i���������@���Ӑ�Ǘ����_�Ή�
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #39451�Ή� 
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : ����
// �� �� ��  2013/07/31  �쐬���e : ���i�Ǘ��}�X�^�擾���@�ύX
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #39451�Ή� 
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �O��
// �� �� ��  2013/08/01  �쐬���e : ���g�p�e�[�u���S�{�폜
//----------------------------------------------------------------------//
// �C�����e�@��Q�� #39487�Ή� 
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : ����
// �� �� ��  2013/08/01  �쐬���e : �i�Ԍ�����SCM-DB�ԗ����X�V�����ǉ�
//----------------------------------------------------------------------//
// �C�����e�@Rdmine#39496�Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �g��
// �� �� ��  2013/08/01  �쐬���e : Rdmine#39496�Ή�
//----------------------------------------------------------------------//
// �C�����e�@Rdmine#39451�Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : ����
// �� �� ��  2013/08/02  �쐬���e : �����������x���P
//----------------------------------------------------------------------//
// �C�����e�@Rdmine#39451�Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : ����
// �� �� ��  2013/08/05  �쐬���e : �����������x���P�F�d�����z�����敪�}�X�^���o�����ǉ�
//----------------------------------------------------------------------//
// �C�����e�@Rdmine#39564�Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : ����
// �� �� ��  2013/08/05  �쐬���e : Redmine#39564�Ή�
//----------------------------------------------------------------------//
// �C�����e�@Rdmine#39600�Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : ����
// �� �� ��  2013/08/05  �쐬���e : ������(����) �W�����i�I���̑Ή�
//----------------------------------------------------------------------//
// �C�����e�@Rdmine#39694�Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : ����
// �� �� ��  2013/08/07  �쐬���e : �d�����z�����敪�}�X�^���o�����C��
//----------------------------------------------------------------------//
// �C�����e�@Rdmine#39759�Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : ����
// �� �� ��  2013/08/08  �쐬���e : �d�����z�����敪�}�X�^���o�����C��
//----------------------------------------------------------------------//
// �C�����e�@Redmine#40185�Ή�
// �Ǘ��ԍ�  10902622-01 �쐬�S�� : �O��
// �� �� ��  2013/08/28  �쐬���e : �����I�u�W�F�N�g�z��擾�C��
//----------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g��
// �� �� ��  2013/10/08  �C�����e : �R�`���i���x�x���Ή� SCM�d�|�ꗗ��10579
//----------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2013/10/08  �C�����e : �R�`���i���x�x���Ή� SCM�d�|�ꗗ��10579
//----------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2013/12/13  �C�����e : SCM��Q�ꗗ��10609�Ή�
//----------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g��
// �� �� ��  2013/12/19  �C�����e : VSS[020_10] ����ýď�Q��4(SCM��Q�ꗗ��10609�Ή��Ɗ֘A)
//----------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �g��
// �� �� ��  2014/01/16  �C�����e : VSS[020_10] Redmine#979(SCM��Q�ꗗ��10609�Ή��Ɗ֘A)
//----------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using SalesTtlStServer = SingletonInstanceForTablet<SalesTtlStAgentForTablet>;
    using Broadleaf.Library.Resources;
    using System.Collections;
    using Broadleaf.Application.Remoting.ParamData;
    using Broadleaf.Application.Remoting;
    using Broadleaf.Application.Remoting.Adapter;
    using Broadleaf.Library.Collections;
    using Broadleaf.Library.Text;   

    /// <summary>
    /// PMTAB �����񓚏���(��������) �e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����������s���܂��B
    ///                  �擾��������SCM_DB�̌������ʊ֘A�̃e�[�u���ɏ�����</br>
    /// <br>Programmer : songg</br>
    /// <br>Date       : 2013/05/29</br>
    /// </remarks>
    public class PMTAB00142AB
    {
        #region ��Private �����o�[
        /// <summary>�������[�J�[�ő�R�[�h</summary>
        private static readonly Int32 ctPureGoodsMakerCode = 999;

        // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----->>>>>
        private const string CLASS_NAME = "PMTAB00142AB";
        // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� -----<<<<<

        //-----ADD songg 2013/06/27 ��Q�� #37360�̑Ή� ---->>>>>
        // �ԗ������A�N�Z�X
        CarSearchController _carAccesser = null;
        //-----ADD songg 2013/06/27 ��Q�� #37360�̑Ή� ----<<<<<

        // ----- ADD huangt 2013/07/03 Redmine#37755 ���x���P�Ή� ----->>>>>
        GoodsAcs _goodsAcs = null;
        // ----- ADD huangt 2013/07/03 Redmine#37755 ���x���P�Ή� -----<<<<<

        // ----- ADD huangt 2013/07/24 Redmine#39039 ���i���� �g�p���鋒�_�R�[�h�̏C�� ----->>>>>
        // �Ǘ����_�R�[�h
        private string _mngSectionCode = "";
        // ----- ADD huangt 2013/07/24 Redmine#39039 ���i���� �g�p���鋒�_�R�[�h�̏C�� -----<<<<<
        // ADD 2013/07/24 �g�� Redmine#39055 --------------->>>>>>>>>>>>>>>>>>>>>>
        ArrayList allStockProcMoneyList;
        // ADD 2013/07/24 �g�� Redmine#39055 ---------------<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2013/07/31 �g�� ���Ӑ�Ǘ����_�Ή� ----------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private CustomerInfoAcs _customerDB = null;
        private CustomerInfo _customerInfo = null;
        // ADD 2013/07/31 �g�� ���Ӑ�Ǘ����_�Ή� -----------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2013/07/31 yugami Redmine#39451�Ή� ----------------------------------->>>>>
        private List<GoodsMngWork> _goodsMngList = null;
        // ADD 2013/07/31 yugami Redmine#39451�Ή� -----------------------------------<<<<<

        // ADD 2013/08/01 �g�� Redmine#39496 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        private string _enterpriseCode = string.Empty;
        private int _customerCode = 0;
        // ADD 2013/08/01 �g�� Redmine#39496 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2013/08/02 Redmine#39451 ���x���P3 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ����S�̐ݒ�}�X�^�A�N�Z�X�N���X
        /// </summary>
        SalesTtlStAcs _salesTtlStAcs = new SalesTtlStAcs();          // ����S�̐ݒ�}�X�^
        /// <summary>
        /// ����S�̐ݒ�}�X�^�@�L���b�V���p�ϐ�
        /// </summary>
        SalesTtlSt _salesTtlSt = null;
        /// <summary>
        /// ����S�̐ݒ�}�X�^���L���b�V�����ꂽ�ۂ̌������_�R�[�h�@
        /// �L���b�V������S�̐ݒ�}�X�^���S�Ђ̏ꍇ���l�����A�������̋��_�R�[�h��ۊ�
        /// </summary>
        string _saveSectionCode = string.Empty;
        // 2013/08/02 Redmine#39451 ���x���P3 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2013/08/05 Redmine#39451 --------------->>>>>>>>>>>>>>>>>>>>>>
        private List<StockProcMoney> _stockProcMoneyList;
        // ADD 2013/08/05 Redmine#39451 ---------------<<<<<<<<<<<<<<<<<<<<<<


        #endregion ��Private �����o�[

        // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� ------------------------------->>>>>
        private GoodsAcs _goodsAccesser;
        public GoodsAcs GoodsAccesser
        {
            get { return _goodsAccesser; }
            set { _goodsAccesser = value; }
        }
        // �L�����y�[�������D��ݒ胊�X�g
        private ArrayList _campaignPrcPrStList;
        public ArrayList CampaignPrcPrStList
        {
            get { return _campaignPrcPrStList; }
            set { _campaignPrcPrStList = value; }
        }
        // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� -------------------------------<<<<<


        #region ��BL�R�[�h��������
        /// <summary>
        /// BL�R�[�h��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : BL�R�[�h���������ƍs���܂�</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsNo">�i�ԃR�[�h</param>
        /// <param name="blGoodsCode">�a�k���i�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="modelCode">�Ԏ�R�[�h</param>
        /// <param name="modelSubCode">�Ԏ�T�u�R�[�h</param>
        /// <param name="modelDesignationNo">�^���w��ԍ�</param>
        /// <param name="categoryNo">�ޕʋ敪�ԍ�</param>
        /// <param name="fullModel">�^��(�t���^)</param>
        /// <param name="carInspectCertModel">�Ԍ��،^��</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V�����R�[�h</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="pmTabSalesDtCarWork">PMTAB����(�ԗ����)�Z�b�V�����Ǘ��g�����U�N�V�����f�[�^</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        public int SearchByCarAndBLCodeForTablet(string enterpriseCode, string sectionCode,
            string goodsNo, int blGoodsCode, int customerCode,
            int makerCode, int modelCode, int modelSubCode, int modelDesignationNo,
            int categoryNo, string fullModel, string carInspectCertModel,
            string businessSessionId, string pmTabSearchGuid,
            out string message
            ,PmTabSalesDtCarWork pmTabSalesDtCarWork)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----->>>>>
            const string methodName = "SearchByCarAndBLCodeForTablet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            // ���b�Z�[�W
            message = string.Empty;

            #region <�ԗ�����>
            // �ԗ����̌�������
            CarSearchResultReport searchedCarResult = CarSearchResultReport.retError;
            PMKEN01010E searchedCarInfo = null;

            // 1�p���ځF��������
            CarSearchCondition searchingCarCondition = this.CreateSearchingCarCondition(makerCode, modelCode,
                modelSubCode, modelDesignationNo, categoryNo, fullModel, carInspectCertModel);

            if (searchingCarCondition.ModelDesignationNo == 0 &&             // �^���w��ԍ�
                searchingCarCondition.CategoryNo == 0 &&                     // �ޕʋ敪�ԍ�
                searchingCarCondition.CarModel.FullModel == string.Empty)    // �^��(�t���^)
            {
                // �ԗ������̏����������̂ŁA�ԗ��������Ȃ�
                searchedCarResult = CarSearchResultReport.retFailed;
                searchedCarInfo = new PMKEN01010E();
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "�ԗ������̏����i�^���w��ԍ��A�ޕʋ敪�ԍ��A�^��(�t���^)�j�������̂ŁA�ԗ��������܂���ł����B");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

                //-----ADD songg 2013/06/24 ��Q�� #37127�̑Ή�  ---->>>>>
                try
                {
                    int status2 = NotCarInfoPro(enterpriseCode, sectionCode, goodsNo, blGoodsCode,
                       businessSessionId, pmTabSearchGuid, out message);

                    if (status2 == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        return status2;
                    }
                }
                catch (Exception ex)
                {
                    message = ex.ToString();
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                    return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

                message = "�ԗ��f�[�^������܂���B";

                // UPD 2013/08/02 #Redmine39451 ���x���P6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region ���\�[�X
                //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                //EasyLogger.Write(CLASS_NAME, methodName, message);
                //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                #endregion
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I���@" + message);
                // UPD 2013/08/02 #Redmine39451 ���x���P6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //-----ADD songg 2013/06/24 ��Q�� #37127�̑Ή�  ----<<<<<
            }
            else
            {

                // 2�p���ځF��������
                searchedCarInfo = new PMKEN01010E();

                if (this.CheckCarSearchCondition(searchingCarCondition))
                {
                    // �ԗ�����
                    searchedCarResult = SearchCar(searchingCarCondition, ref searchedCarInfo);
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, "�ԗ��������ʁ@searchedCarResult�F" + searchedCarResult.ToString());
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

                    // �ԗ���������0���̏ꍇ
                    if (!searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel)
                        &&
                       !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel)    // �S�I���̍ۂ̌���
                        &&
                       !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind))
                    {
                        // BL�R�[�h�����̎ԗ������Ńq�b�g���Ȃ������ꍇ�A���i�������ʂ̂�SCM-DB�֏������݂܂�
                        //-----DEL huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.44�̑Ή� ---->>>>> 
                        //NotCarInfoPro(enterpriseCode, sectionCode, goodsNo, blGoodsCode,
                        //    businessSessionId, pmTabSearchGuid, out message);
                        //-----DEL huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.44�̑Ή� ----<<<<<

                        //-----ADD huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.44�̑Ή� ---->>>>>
                        try
                        {
                            int status2 = NotCarInfoPro(enterpriseCode, sectionCode, goodsNo, blGoodsCode,
                               businessSessionId, pmTabSearchGuid, out message);

                            if (status2 == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                            {
                                return status2;
                            }
                        }
                        catch (Exception ex)
                        {
                            message = ex.ToString();
                            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                            EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
                            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                            return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                        }
                        //-----ADD huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.44�̑Ή� ----<<<<<

                        message = "�ԗ��f�[�^������܂���B";

                        // UPD 2013/08/02 #Redmine39451 ���x���P6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        #region ���\�[�X
                        //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                        //EasyLogger.Write(CLASS_NAME, methodName, message);
                        //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                        //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                        #endregion
                        EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I���@" + message);
                        // UPD 2013/08/02 #Redmine39451 ���x���P6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                        //return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;     // DEL huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.44�̑Ή�
                        return (int)ConstantManagement.DB_Status.ctDB_NORMAL;          // ADD huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.44�̑Ή�
                    }

                    // �������ʂ�ێ� ��1�⍇���Ŏԗ��͓����ł��邽�߁A�����ԗ����������x���s��Ȃ�
                    if (searchedCarInfo != null)
                    {
                        if (searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind))
                        {
                            if (searchedCarInfo.CarKindInfo != null &&
                                searchedCarInfo.CarKindInfo.Count > 0)
                            {
                                searchedCarInfo.CarKindInfo[0].SelectionState = true;
                                searchedCarResult = SearchCar(searchingCarCondition, ref searchedCarInfo);
                            }
                        }
                        //-----ADD songg 2013/06/18 �\�[�X�`�F�b�N�m�F�����ꗗ��No.36�̑Ή� ---->>>>>
                        //-----DEL songg 2013/06/24 ��Q�� #37172�̑Ή� �P��ԗ��̎��͍i���݂ł��܂��� ---->>>>>
                        // �^�������������̏ꍇ�A�������ʂ̎ԗ����S�I���������s���܂�
                        //else if (searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel))
                        //{                                                                            
                        //    SearchCarByMultipleCarModel(searchingCarCondition, ref searchedCarInfo, pmTabSalesDtCarWork);
                        //}
                        //-----DEL songg 2013/06/24 ��Q�� #37172�̑Ή� �P��ԗ��̎��͍i���݂ł��܂��� ----<<<<<
                        //-----ADD songg 2013/06/24 ��Q�� #37172�̑Ή� �P��ԗ��̎��͍i���݂ł��܂��� ---->>>>>
                        // �ԗ������ŃJ���[�E�g�����̍i����
                        SearchCarByMultipleCarModel(searchingCarCondition, ref searchedCarInfo, pmTabSalesDtCarWork);
                        //-----ADD songg 2013/06/24 ��Q�� #37172�̑Ή� �P��ԗ��̎��͍i���݂ł��܂��� ----<<<<<
                        //-----ADD songg 2013/06/18 �\�[�X�`�F�b�N�m�F�����ꗗ��No.36�̑Ή� ----<<<<<
                    }
                }
                else
                {
                    searchedCarResult = CarSearchResultReport.retFailed;
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, "���q���������ݒ�`�F�b�N�@�m�f");
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                }
            }

            // �ԗ��������ʂ�1���̏ꍇ�̂ݐ��� ���S�I�������ꍇ��1���Ƃ݂Ȃ�
            if (
                !searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel)
                    &&
                !searchedCarResult.Equals(CarSearchResultReport.retFailed)              // ��������0����������
                    &&
                !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel)    // �S�I���̍ۂ̌���
                    &&
                !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind)
            )
            {
                message = "�ԗ��f�[�^������܂���B";
                // UPD 2013/08/02 #Redmine39451 ���x���P6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region ���\�[�X
                //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                //EasyLogger.Write(CLASS_NAME, methodName, message);
                //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                #endregion
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I���@" + message);
                // UPD 2013/08/02 #Redmine39451 ���x���P6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                //return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;     // DEL huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.44�̑Ή�
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;          // ADD huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.44�̑Ή�
            }


            #endregion // </�ԗ�����>

            #region <BL����>
            // �������ʂ�1���ł���΁ABL�������J�n
            // 1�p���ځF��������
            GoodsCndtn searchingGoodsCondition = EditSearchingGoodsCondition(
                // UPD 2013/07/31 �g�� ���Ӑ�Ǘ����_�Ή� ----------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //CreateSearchingGoodsCondition(enterpriseCode, sectionCode,
                //                              goodsNo, blGoodsCode, searchedCarInfo)
                CreateSearchingGoodsCondition(enterpriseCode, sectionCode,
                                              goodsNo, blGoodsCode, searchedCarInfo,customerCode)
                // UPD 2013/07/31 �g�� ���Ӑ�Ǘ����_�Ή� -----------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                      );

            // 2�p���ځF���i���
            PartsInfoDataSet partsInfoDB = null;

            // 3�p���ځF���i�A���f�[�^
            List<GoodsUnitData> goodsUnitDataList = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            List<Rate> rateList = new List<Rate>();
            try
            {
                // ���q�f�[�^�����BL�R�[�h����
                // BL����
                status = SearchPartsFromBLCodeCarInfo(enterpriseCode, sectionCode, customerCode,
                    searchingGoodsCondition,
                    out partsInfoDB,
                    out goodsUnitDataList,
                    out message,
                    searchedCarInfo,
                    out unitPriceCalcRetList,
                    out rateList);
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "BL�R�[�h�����@status�F" + status.ToString() + " " + message);
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            }
            catch(Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                message = ex.ToString();
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

                return status;// ADD huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.44�̑Ή�
            }

            // �����Ȃ��̏ꍇ�A�܂��̓G���[��������ꍇ�A�X�e�[�^�X��߂�܂��B
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.42�̑Ή� ---->>>>>
                // ���i�������ʂȂ��̏ꍇ�APMTAB���[�U�[���i�������ʂ�SCM DB�ɓo�^����
                try
                {
                    status = NotUrGoodsInfoPro(partsInfoDB, enterpriseCode, sectionCode,
                        goodsNo, blGoodsCode, businessSessionId, pmTabSearchGuid,
                        out message);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        return status;
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    message = "���i�f�[�^������܂���B";
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    message = ex.ToString();
                }
                //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.42�̑Ή� ----<<<<<
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return status;
            }
            #endregion // </BL����>

            // �ۑ��p���X�g������
            CustomSerializeArrayList pmtPartsSearchWorkList = new CustomSerializeArrayList();

            // �ԗ�����USER DB�ɏ�����																							
            // PMTAB�󒍃}�X�^�i�ԗ��j
            // UPD 2013/12/19 VSS[020_10] ����ýď�Q��4 �g�� ------------------->>>>>>>>>>>>>>>
            #region ���\�[�X
            //// UPD 2013/12/12 SCM�d�|�ꗗ��10609�Ή� -------------------------->>>>>
            ////status = WritePmTabAcpOdrCar(searchedCarInfo,enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid);
            //status = WritePmTabAcpOdrCar(searchedCarInfo, enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid, pmTabSalesDtCarWork);
            //// UPD 2013/12/12 SCM�d�|�ꗗ��10609�Ή� --------------------------<<<<<
            #endregion
            status = WritePmTabAcpOdrCar(searchedCarInfo, enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid);
            // UPD 2013/12/19 VSS[020_10] ����ýď�Q��4 �g�� -------------------<<<<<<<<<<<<<<<
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "PMTAB�󒍃}�X�^�i�ԗ��j�o�^�����@status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return status;
            }

            //-----ADD huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.43�̑Ή� ---->>>>>
            // �ԗ�����SCM DB�ɍX�V����
            status = WritePmTabSalDCar(searchedCarInfo, pmTabSalesDtCarWork, enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid);
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "���i�������ʂȂ��̏ꍇ�APMTAB���[�U�[���i�������ʂ�SCM DB�o�^�����@status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return status;
            }
            //-----ADD huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.43�̑Ή� ----<<<<<

            //-----DEL songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.42�̑Ή� ---->>>>>
            //// ���i�������ʂȂ��̏ꍇ�APMTAB���[�U�[���i�������ʂ�SCM DB�ɓo�^����
            //status = NotUrGoodsInfoPro(partsInfoDB, ref pmtPartsSearchWorkList, 
            //    enterpriseCode, sectionCode, goodsNo, blGoodsCode, 
            //    businessSessionId, pmTabSearchGuid, out message);
            //if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) || 
            //    (status == (int)ConstantManagement.DB_Status.ctDB_ERROR))
            //{
            //    return status;
            //}
            //-----DEL songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.42�̑Ή� ----<<<<<

            // ���i�A���f�[�^�s�����ݒ�
            this.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true, sectionCode);

            //-----DEL songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ---->>>>>
            //// �P���v�Z
            //SetCalculator(partsInfoDB, ref goodsUnitDataList, enterpriseCode,
            //    sectionCode, customerCode, out unitPriceCalcRetList, out rateList);
            //-----DEL songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ----<<<<<

            //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ---->>>>>
            // ���Ӑ�|���O���[�v���X�g
            List<CustRateGroup> custRateGroupList = new List<CustRateGroup>();
            // �P���v�Z
            SetCalculator(partsInfoDB, ref goodsUnitDataList, enterpriseCode,
                sectionCode, customerCode, out unitPriceCalcRetList, out custRateGroupList, out rateList);
            //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ----<<<<<

            // (17�e�[�u��)���i�������ʂ�SCM DB�ɏ�����
            GetPartsInfoToScmDBDataList(partsInfoDB, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid, ref pmtPartsSearchWorkList);
																			
            // PMTAB�|���������ʃf�[�^�i�ꎞ�j
            GetRateToScmDBDataList(rateList,
                enterpriseCode,
                sectionCode,
                businessSessionId,
                pmTabSearchGuid,
                ref pmtPartsSearchWorkList);

            //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ---->>>>>
            // ���Ӑ�}�X�^�i�|���O���[�v�j�}�X�^�f�[�^�o�^
            GetCustRateGroupToScmDBDataList(custRateGroupList,
                enterpriseCode,
                sectionCode,
                businessSessionId,
                pmTabSearchGuid,
                ref pmtPartsSearchWorkList);
            //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ----<<<<<

            // �}�X�^�f�[�^���֏���
            status = GetMastDataToScmDBDataList(enterpriseCode, 
                sectionCode, 
                businessSessionId, 
                pmTabSearchGuid, 
                ref pmtPartsSearchWorkList, 
                goodsUnitDataList, out message,
                customerCode);

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "�}�X�^�f�[�^���֏����@status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return status;
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            //return status;      // DEL huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.44�̑Ή� 
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // ADD huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.44�̑Ή� 
        }

        //-----ADD songg 2013/06/18 �\�[�X�`�F�b�N�m�F�����ꗗ��No.36�̑Ή� ---->>>>>
        #region �^�������������̏ꍇ�A�������ʂ̎ԗ����S�I������
        /// <summary>
        /// �^�������������̏ꍇ�A�������ʂ̎ԗ����S�I������
        /// </summary>
        /// <param name="searchingCarCondition">��������</param>
        /// <param name="searchedCarInfo">��������</param>
        /// <param name="carRecord">PMTAB����(�ԗ����)�Z�b�V�����Ǘ��g�����U�N�V�����f�[�^</param>
        private void SearchCarByMultipleCarModel(CarSearchCondition searchingCarCondition,
            ref PMKEN01010E searchedCarInfo,
            PmTabSalesDtCarWork carRecord)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "SearchCarByMultipleCarModel";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            string frameModel = string.Empty;
            string chassisNo = string.Empty;
            int status = -1;
            int searchFrameNo = 0;
            if (!String.IsNullOrEmpty(carRecord.FrameNo))
            {
                status = GenerateChassisNoFrameFromFrameNo(carRecord.FrameNo, out frameModel, out chassisNo);
                if (status.Equals(0))
                {
                    searchFrameNo = TStrConv.StrToIntDef(chassisNo, 0);
                }
                else
                {
                    searchFrameNo = 0;
                }
            }

            int produceTypeOfYearNum = 0;
            if (carRecord.ProduceTypeOfYearNum != 0)
            {
                produceTypeOfYearNum = carRecord.ProduceTypeOfYearNum;
            }
            else if (0 != searchFrameNo)
            {
                produceTypeOfYearNum = searchedCarInfo.GetProduceTypeOfYear(searchFrameNo); 
            }

            // �^���I���c�^���I���E�B���h�E�\���ΏۂƂȂ����ꍇ�A�^���I���E�B���h�E�\�����s�킸�A
            // �S�I���Ƃ��ď������ʂ�߂�
            // �N���A�ԑ�ԍ��ōi�荞��
            int selectedCnt = 0;
            if (produceTypeOfYearNum > 0)
            {
                selectedCnt = searchedCarInfo.SelectCarModelProduceTypeOfYear(produceTypeOfYearNum);
            }
            else if (searchFrameNo > 0)
            {
                selectedCnt = searchedCarInfo.SelectCarModelSearchFrameNo(searchFrameNo);
            }

            if (selectedCnt == 0)
            {
                searchedCarInfo.AllSelect();
            }
            CarSearchController carAccesser = new CarSearchController();
            carAccesser.Search(searchingCarCondition, ref searchedCarInfo);


            if (searchedCarInfo.CarModelInfoSummarized != null && searchedCarInfo.CarModelInfoSummarized.Rows.Count > 0)
            {
                PMKEN01010E.CarModelInfoRow row = searchedCarInfo.CarModelInfoSummarized[0];

                // �N���̍i����
                if (produceTypeOfYearNum != 0)
                {
                    int stDate = (((row.StProduceTypeOfYear / 100) == 9999) || ((row.StProduceTypeOfYear % 100) == 99)) ? 0 : row.StProduceTypeOfYear;
                    int edDate = (((row.EdProduceTypeOfYear / 100) == 9999) || ((row.EdProduceTypeOfYear % 100) == 99)) ? 0 : row.EdProduceTypeOfYear;

                    if (stDate != 0 || edDate != 0)
                    {
                        edDate = (edDate == 0) ? 999999 : edDate;

                        if (stDate <= produceTypeOfYearNum && produceTypeOfYearNum <= edDate)
                        {
                            searchedCarInfo.CarModelUIData[0].ProduceTypeOfYearInput = produceTypeOfYearNum;
                        }
                    }
                }

                // UPD 2014/01/16 �g�� 2014/01/22�z�M�\�� VSS[020_10] Redmine#979 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // if (searchFrameNo != 0)
                if (chassisNo != null && chassisNo.Length > 0)
                // UPD 2014/01/16 �g�� 2014/01/22�z�M�\�� VSS[020_10] Redmine#979 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                {
                    if ((row.StProduceFrameNo != 0 && row.StProduceFrameNo > searchFrameNo) ||
                        (row.EdProduceFrameNo != 0 && row.EdProduceFrameNo < searchFrameNo))
                    {
                    }
                    else
                    {
                        // UPD 2013/12/19 VSS[020_10] ����ýď�Q��4 �g�� ------------------->>>>>>>>>>>>>>>
                        // searchedCarInfo.CarModelUIData[0].FrameNo = searchFrameNo.ToString();
                        searchedCarInfo.CarModelUIData[0].FrameNo = chassisNo;
                        // UPD 2013/12/19 VSS[020_10] ����ýď�Q��4 �g�� -------------------<<<<<<<<<<<<<<<
                        searchedCarInfo.CarModelUIData[0].SearchFrameNo = searchFrameNo;
                    }
                }
            }

            // �J���[�̍i����
            if (!string.IsNullOrEmpty(carRecord.RpColorCode))
            {
                PMKEN01010E.ColorCdInfoRow[] colorRows = (PMKEN01010E.ColorCdInfoRow[])searchedCarInfo.ColorCdInfo.Select(string.Format("{0}='{1}'", searchedCarInfo.ColorCdInfo.ColorCodeColumn.ColumnName, carRecord.RpColorCode));
                if (colorRows.Length > 0)
                {
                    colorRows[0].SelectionState = true;
                }
            }

            // �g�����̍i����
            if (!string.IsNullOrEmpty(carRecord.TrimCode))
            {
                PMKEN01010E.TrimCdInfoRow[] trimRows = (PMKEN01010E.TrimCdInfoRow[])searchedCarInfo.TrimCdInfo.Select(string.Format("{0}='{1}'", searchedCarInfo.TrimCdInfo.TrimCodeColumn.ColumnName, carRecord.TrimCode));
                if (trimRows.Length > 0)
                {
                    trimRows[0].SelectionState = true;
                }
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
        }

        /// <summary>
        /// �ԑ�ԍ����V���V�[����������
        /// </summary>
        /// <param name="frameNo">�ԑ�ԍ�</param>
        /// <param name="frameModel">�ԑ�^��</param>
        /// <param name="chassisNo">�V���VNo</param>
        /// <returns>STATUS [0:�������� 0�ȊO:�������s]</returns>
        public static int GenerateChassisNoFrameFromFrameNo(string frameNo, out string frameModel, out string chassisNo)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "GenerateChassisNoFrameFromFrameNo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            frameModel = "";
            chassisNo = "";

            if (frameNo == "")
            {
                frameModel = "";
                chassisNo = "";
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return 0;
            }

            // �S�p�����񂪊܂܂�Ă���ꍇ�͐����s�\
            if (!IsOneByteChar(frameNo.Trim()))
            {
                frameModel = "";
                chassisNo = "";
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� �ԑ�ԍ��ɑS�p������L��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return 0;
            }

            int length = frameNo.Length;
            int chassisNoCache = 0;
            string[] split = frameNo.Split(new Char[] { '-' });

            if (split.Length < 0)
            {
                // �����������ʂ̔z�񐔂�1�ȉ��̏ꍇ�͎Z��s�\
                return 1;
            }
            else if (split.Length == 1)
            {
                frameModel = split[0];					// �ԑ�^��
                chassisNo = split[0];
                if (!int.TryParse(chassisNo, out chassisNoCache))
                {
                    chassisNo = "";
                }

            }
            else if (split.Length == 2)
            {
                frameModel = split[0];					// �ԑ�^��
                chassisNo = split[1];					// �V���V�[No

                if (!int.TryParse(chassisNo, out chassisNoCache))
                {
                    chassisNo = "";
                }
            }
            else
            {
                chassisNo = "";

                frameModel = split[0];					// �ԑ�^��
            }

            // �����`�F�b�N
            if (frameModel.Length > 16)
            {
                frameModel = frameModel.Remove(16, frameModel.Length - 16);
            }
            if (chassisNo.Length > 18)
            {
                chassisNo = chassisNo.Remove(18, chassisNo.Length - 18);
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return 0;
        }

        /// <summary>
        /// 1�o�C�g�����ō\�����ꂽ������ł��邩���� 
        /// 1�o�C�g�����݂̂ō\�����ꂽ������ : True 
        /// 2�o�C�g�������܂܂�Ă��镶���� : False
        /// </summary>
        /// <param name="str"></param>
        /// <returns>status</returns>
        private static bool IsOneByteChar(string str)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "IsOneByteChar";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            byte[] byte_data = System.Text.Encoding.GetEncoding(932).GetBytes(str);
            if (byte_data.Length == str.Length)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return true;
            }
            else
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return false;
            }
        }
        #endregion �^�������������̏ꍇ�A�������ʂ̎ԗ����S�I������
        //-----ADD songg 2013/06/18 �\�[�X�`�F�b�N�m�F�����ꗗ��No.36�̑Ή� ----<<<<<

        /// <summary>
        /// BL�R�[�h�����̎ԗ������Ńq�b�g���Ȃ������ꍇ�APMTAB���[�U�[���i�������ʂ�SCM DB�ɓo�^����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="blGoodsCode">�a�k���i�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int NotCarInfoPro(
            string enterpriseCode,
            string sectionCode,
            string goodsNo,
            int blGoodsCode,
            string businessSessionId,
            string pmTabSearchGuid,
            out string message)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "NotCarInfoPro";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            CustomSerializeArrayList pmtPartsSearchWorkList = new CustomSerializeArrayList();

            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            DateTime now = DateTime.Now;
            PmtUrGdsInfTmpWork tempPmtUrGdsInfTmpWork = new PmtUrGdsInfTmpWork();
            tempPmtUrGdsInfTmpWork.CreateDateTime = now;// �쐬����
            tempPmtUrGdsInfTmpWork.UpdateDateTime = now;// �X�V����
            tempPmtUrGdsInfTmpWork.EnterpriseCode = enterpriseCode;// ��ƃR�[�h
            tempPmtUrGdsInfTmpWork.LogicalDeleteCode = 0;// �_���폜�敪
            tempPmtUrGdsInfTmpWork.BusinessSessionId = businessSessionId;// �Ɩ��Z�b�V����ID
            tempPmtUrGdsInfTmpWork.PmTabDtlDiscGuid = pmTabSearchGuid;// PMTAB���׎���GUID
            //tempPmtUrGdsInfTmpWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));// �f�[�^�폜�\���  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
            tempPmtUrGdsInfTmpWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));//�f�[�^�폜�\���  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
            tempPmtUrGdsInfTmpWork.SearchSectionCode = sectionCode;// �������_�R�[�h
            tempPmtUrGdsInfTmpWork.PmTabSearchRowNum = 1;// PMTAB�����s�ԍ�
            tempPmtUrGdsInfTmpWork.GoodsNo = goodsNo;// ���i�ԍ�
            tempPmtUrGdsInfTmpWork.BlGoodsCode = blGoodsCode;// BL���i�R�[�h
            tempPmtUrGdsInfTmpWork.OfferDataDiv = 98;// �񋟃f�[�^�敪

            List<PmtUrGdsInfTmpWork> pmtUrGdsInfoTmpList = new List<PmtUrGdsInfTmpWork>();
            pmtUrGdsInfoTmpList.Add(tempPmtUrGdsInfTmpWork);

            // �ǉ����i�������ʏ��
            pmtPartsSearchWorkList.Add(pmtUrGdsInfoTmpList);

            // �����������S��USER DB�̃f�[�^��SCM DB�ɕۑ��������s���܂�������
            IPmtPartsSearchDB iPmtPartsSearchDB = MediationPmtPartsSearchDB.GetPmtPartsSearchDB();
            object objList = pmtPartsSearchWorkList;
            iPmtPartsSearchDB.Write(ref objList);

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// ���i�������ʂȂ��̏ꍇ�APMTAB���[�U�[���i�������ʂ�SCM DB�ɓo�^����
        /// </summary>
        /// <param name="partsInfoDB">���i���</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="blGoodsCode">�a�k���i�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        private int NotUrGoodsInfoPro(PartsInfoDataSet partsInfoDB,
            // ref CustomSerializeArrayList pmtPartsSearchWorkList, //-----DEL songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.42�̑Ή�
            string enterpriseCode, 
            string sectionCode,
            string goodsNo, 
            int blGoodsCode,
            string businessSessionId, 
            string pmTabSearchGuid, 
            out string message)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "NotUrGoodsInfoPro";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";


            // ���i�������ʃt���O�iTrue: ����; False�F�Ȃ��j
            Boolean hasUrGdsInfoData = false;
            // BL�R�[�h�����^�i�Ԍ����Ńq�b�g���Ȃ������ꍇ�̏����Ɋւ���
            // �ȉ��̕��i�������ʂ̂�SCM-DB�֏������݂܂��B

            if ((partsInfoDB.UsrGoodsInfo != null) && (partsInfoDB.UsrGoodsInfo.Count > 0))
            {
                hasUrGdsInfoData = true;

            }

            // �f�[�^�Ȃ��̏ꍇ
            if (!hasUrGdsInfoData)
            {
                // �N���A���̑��e�[�u�����
                //pmtPartsSearchWorkList.Clear();//-----DEL songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.42�̑Ή�

                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                DateTime now = DateTime.Now;
                PmtUrGdsInfTmpWork tempPmtUrGdsInfTmpWork = new PmtUrGdsInfTmpWork();
                tempPmtUrGdsInfTmpWork.CreateDateTime = now;// �쐬����
                tempPmtUrGdsInfTmpWork.UpdateDateTime = now;// �X�V����
                tempPmtUrGdsInfTmpWork.EnterpriseCode = enterpriseCode;// ��ƃR�[�h
                tempPmtUrGdsInfTmpWork.LogicalDeleteCode = 0;// �_���폜�敪
                tempPmtUrGdsInfTmpWork.BusinessSessionId = businessSessionId;// �Ɩ��Z�b�V����ID
                tempPmtUrGdsInfTmpWork.PmTabDtlDiscGuid = pmTabSearchGuid;// PMTAB���׎���GUID
                //tempPmtUrGdsInfTmpWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));// �f�[�^�폜�\���  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempPmtUrGdsInfTmpWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));// �f�[�^�폜�\���  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempPmtUrGdsInfTmpWork.SearchSectionCode = sectionCode;// �������_�R�[�h
                tempPmtUrGdsInfTmpWork.PmTabSearchRowNum = 1;// PMTAB�����s�ԍ�
                tempPmtUrGdsInfTmpWork.GoodsNo = goodsNo;// ���i�ԍ�
                tempPmtUrGdsInfTmpWork.BlGoodsCode = blGoodsCode;// BL���i�R�[�h
                tempPmtUrGdsInfTmpWork.OfferDataDiv = 99;// �񋟃f�[�^�敪

                List<PmtUrGdsInfTmpWork> pmtUrGdsInfoTmpList = new List<PmtUrGdsInfTmpWork>();
                pmtUrGdsInfoTmpList.Add(tempPmtUrGdsInfTmpWork);

                CustomSerializeArrayList pmtPartsSearchWorkList = new CustomSerializeArrayList();//-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.42�̑Ή�

                // �ǉ����i�������ʏ��
                pmtPartsSearchWorkList.Add(pmtUrGdsInfoTmpList);

                // �����������S��USER DB�̃f�[�^��SCM DB�ɕۑ��������s���܂�������
                IPmtPartsSearchDB iPmtPartsSearchDB = MediationPmtPartsSearchDB.GetPmtPartsSearchDB();
                object objList = pmtPartsSearchWorkList;
                iPmtPartsSearchDB.Write(ref objList);
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// BL��������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="searchingGoodsCondition">��������</param>
        /// <param name="partsInfoDB">���i���</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="carInfo">�ԗ����</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        /// <param name="rateList">�|�����X�g</param>
        /// <returns>���ʃR�[�h</returns>
        protected int SearchPartsFromBLCodeCarInfo(
            string enterpriseCode,
            string sectionCode,
            int customerCode,
            GoodsCndtn searchingGoodsCondition,
            out PartsInfoDataSet partsInfoDB,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg, PMKEN01010E carInfo,
            out List<UnitPriceCalcRet> unitPriceCalcRetList,
            out List<Rate> rateList)
        {
            return SearchPartsFromBLCode(enterpriseCode, sectionCode, customerCode,
                searchingGoodsCondition, out partsInfoDB, out goodsUnitDataList, out msg,
                out unitPriceCalcRetList,
                out rateList);
        }

        #region <BL����>
        /// <summary>
        /// BL��������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="searchingGoodsCondition">��������</param>
        /// <param name="partsInfoDB">���i���</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        /// <param name="rateList">�|�����X�g</param>
        /// <returns>���ʃR�[�h</returns>
        protected int SearchPartsFromBLCode(
            string enterpriseCode,
            string sectionCode,
            int customerCode,
            GoodsCndtn searchingGoodsCondition,
            out PartsInfoDataSet partsInfoDB,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg,
            out List<UnitPriceCalcRet> unitPriceCalcRetList,
            out List<Rate> rateList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "SearchPartsFromBLCode";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            rateList = new List<Rate>();

            // UPD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� ------------------------------->>>>>
            //GoodsAcs _goodsAccesser = new GoodsAcs(sectionCode);
            //_goodsAccesser.SearchInitial(enterpriseCode, sectionCode, out msg);//-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή�
            if (_goodsAccesser == null)
            {
                _goodsAccesser = new GoodsAcs(sectionCode);
                _goodsAccesser.SearchInitial(enterpriseCode, sectionCode, out msg);//-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή�
            }
            // UPD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� -------------------------------<<<<<

            int status = _goodsAccesser.SearchPartsFromBLCodeForAutoSearch(
                searchingGoodsCondition,
                out partsInfoDB,
                out goodsUnitDataList,
                out msg
            );
            if (!status.Equals((int)ResultUtil.ResultCode.Normal)) return status;

            if (partsInfoDB != null)
            {
                // �i���\���敪
                //-----DEL songg 2013/06/25 ��Q�� #37187�̑Ή� ����S�̐ݒ�}�X�^�擾 ---->>>>>
                //SalesTtlSt foundSalesTtlSt = SalesTtlStDB.Find(
                //    searchingGoodsCondition.EnterpriseCode,
                //    searchingGoodsCondition.SectionCode
                //);
                //-----DEL songg 2013/06/25 ��Q�� #37187�̑Ή� ����S�̐ݒ�}�X�^�擾 ----<<<<<
                //-----ADD songg 2013/06/25 ��Q�� #37187�̑Ή� ����S�̐ݒ�}�X�^�擾 ---->>>>>
                SalesTtlSt foundSalesTtlSt = GetSalesTtlStInfo(
                    searchingGoodsCondition.EnterpriseCode,
                    searchingGoodsCondition.SectionCode);
                //-----ADD songg 2013/06/25 ��Q�� #37187�̑Ή� ����S�̐ݒ�}�X�^�擾 ----<<<<<
                if (foundSalesTtlSt != null)
                {
                    partsInfoDB.SetPartsNameDisplayPattern(foundSalesTtlSt);
                    partsInfoDB.PriceSelectDispDiv = foundSalesTtlSt.PriceSelectDispDiv;
                    partsInfoDB.UnPrcNonSettingDiv = foundSalesTtlSt.UnPrcNonSettingDiv;
                }
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        #endregion // </BL����>
        #endregion ��BL�R�[�h��������

        #region ���i�Ԍ�������
        /// <summary>
        /// �i�Ԍ�������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �i�Ԍ��������ƍs���܂�</br>
        /// <br>Programmer : songg</br>
        /// <br>Date       : 2013/05/29</br>
        /// </remarks>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsNo">�i�ԃR�[�h</param>
        /// <param name="blGoodsCode">�a�k���i�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="modelCode">�Ԏ�R�[�h</param>
        /// <param name="modelSubCode">�Ԏ�T�u�R�[�h</param>
        /// <param name="modelDesignationNo">�^���w��ԍ�</param>
        /// <param name="categoryNo">�ޕʋ敪�ԍ�</param>
        /// <param name="fullModel">�^��(�t���^)</param>
        /// <param name="carInspectCertModel">�Ԍ��،^��</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V�����R�[�h</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="pmTabSalesDtCarWork">PMTAB����(�ԗ����)�Z�b�V�����Ǘ��g�����U�N�V�����f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        public int SearchByGoodsNoForTablet(string enterpriseCode, string sectionCode,
            string goodsNo, int blGoodsCode, int customerCode,
            int makerCode, int modelCode, int modelSubCode, int modelDesignationNo,
            int categoryNo, string fullModel, string carInspectCertModel,
            string businessSessionId, string pmTabSearchGuid, out string message
            , PmTabSalesDtCarWork pmTabSalesDtCarWork)     // ADD huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.43�̑Ή� 
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "SearchByGoodsNoForTablet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            // ���b�Z�[�W
            message = string.Empty;

            #region <�ԗ�����>

            // �ԗ����̌�������
            CarSearchResultReport searchedCarResult = CarSearchResultReport.retError;
            PMKEN01010E searchedCarInfo = null;

            // 1�p���ځF��������
            CarSearchCondition searchingCarCondition = this.CreateSearchingCarCondition(makerCode, modelCode,
                modelSubCode, modelDesignationNo, categoryNo, fullModel, carInspectCertModel);

            if (searchingCarCondition.ModelDesignationNo == 0 &&             // �^���w��ԍ�
                searchingCarCondition.CategoryNo == 0 &&                     // �ޕʋ敪�ԍ�
                searchingCarCondition.CarModel.FullModel == string.Empty)    // �^��(�t���^)
            {
                // �ԗ������̏����������̂ŁA�ԗ��������Ȃ�
                searchedCarResult = CarSearchResultReport.retFailed;
                searchedCarInfo = new PMKEN01010E();
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "�ԗ������̏����i�^���w��ԍ��A�ޕʋ敪�ԍ��A�^��(�t���^)�j�������̂ŁA�ԗ��������܂���ł����B");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            }
            else
            {
                // 2�p���ځF��������
                searchedCarInfo = new PMKEN01010E();

                if (this.CheckCarSearchCondition(searchingCarCondition))
                {
                    // �ԗ�����
                    searchedCarResult = SearchCar(searchingCarCondition, ref searchedCarInfo);
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, "�ԗ��������ʁ@searchedCarResult�F" + searchedCarResult.ToString());
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

                    // �������ʂ�ێ� ��1�⍇���Ŏԗ��͓����ł��邽�߁A�����ԗ����������x���s��Ȃ�
                    if (searchedCarInfo != null)
                    {
                        if (searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind))
                        {
                            if (searchedCarInfo.CarKindInfo != null &&
                                searchedCarInfo.CarKindInfo.Count > 0)
                            {
                                searchedCarInfo.CarKindInfo[0].SelectionState = true;
                                searchedCarResult = SearchCar(searchingCarCondition, ref searchedCarInfo);
                            }
                        }

                        // ADD songg 2013/07/09 Redmine#38046 �i�Ԍ������̎ԗ��S�I�������ǉ�-------------------------------------------->>>>>
                        // �ԗ������ŃJ���[�E�g�����̍i����
                        SearchCarByMultipleCarModel(searchingCarCondition, ref searchedCarInfo, pmTabSalesDtCarWork);
                        // ADD songg 2013/07/09 Redmine#38046 �i�Ԍ������̎ԗ��S�I�������ǉ�--------------------------------------------<<<<<
                    }
                }
                else
                {
                    searchedCarResult = CarSearchResultReport.retFailed;
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, "���q���������ݒ�`�F�b�N�@�m�f");
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                }
            }
            #endregion // </�ԗ�����>

            // �ԗ��������ʂ�1���̏ꍇ�̂ݐ��� ���S�I�������ꍇ��1���Ƃ݂Ȃ�
            if (
                !searchedCarResult.Equals(CarSearchResultReport.retSingleCarModel)
                    &&
                !searchedCarResult.Equals(CarSearchResultReport.retFailed)              // ��������0����������
                    &&
                !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarModel)    // �S�I���̍ۂ̌���
                    &&
                !searchedCarResult.Equals(CarSearchResultReport.retMultipleCarKind)
            )
            {
                message = "�ԗ��f�[�^������܂���B";
                // UPD 2013/08/02 #Redmine39451 ���x���P6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region ���\�[�X
                //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                //EasyLogger.Write(CLASS_NAME, methodName, message);
                //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                #endregion
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I���@" + message);
                // UPD 2013/08/02 #Redmine39451 ���x���P6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                //return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;      // DEL huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.44�̑Ή�
                return (int)ConstantManagement.DB_Status.ctDB_NORMAL;           // ADD huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.44�̑Ή�
            }

            #region <�i�Ԍ���>
            // 1�p���ځF��������
            GoodsCndtn searchingCondition = EditSearchingGoodsCondition(
                // UPD 2013/07/31 �g�� ���Ӑ�Ǘ����_�Ή� ----------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //CreateSearchingGoodsCondition(enterpriseCode, sectionCode,
                //                              goodsNo, blGoodsCode, searchedCarInfo)
                CreateSearchingGoodsCondition(enterpriseCode, sectionCode,
                                              goodsNo, blGoodsCode, searchedCarInfo, customerCode)
                // UPD 2013/07/31 �g�� ���Ӑ�Ǘ����_�Ή� -----------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                );

            // DEL 2013/07/22 �g�� �w�E�E�m�F�����ꗗ_�Г��m�F�p��376-------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            #region
            //// ----- ADD licb 2013/07/10 Redmine#38120 �����i�ԓ_�t���� ----- >>>>>
            //if (!(string.IsNullOrEmpty(searchingCondition.GoodsNo)) && (searchingCondition.GoodsNo.Length > 1)
            //    && (searchingCondition.GoodsNo.LastIndexOf(".") == searchingCondition.GoodsNo.Length - 1))
            //{
            //    //���i�ԍ����h�b�g(�D)�t�̎��̓h�b�g(�D)���Œ�ŃZ�b�g
            //    searchingCondition.PartsJoinCntDivCd = ".";
            //    // ----- ADD songg 2013/07/10 Redmine#38106 �D�Ǖi�ԓ_�t���� ----- >>>>>
            //    // ���i�ԍ����h�b�g�i�D�j�t�̎��̓h�b�g������
            //    searchingCondition.GoodsNo = searchingCondition.GoodsNo.Substring(0, searchingCondition.GoodsNo.Length - 1);
            //    // ----- ADD songg 2013/07/10 Redmine#38106 �D�Ǖi�ԓ_�t���� ----- <<<<<
            //}
            //// ----- ADD licb 2013/07/10 Redmine#38120 �����i�ԓ_�t���� ----- <<<<<
            #endregion
            // DEL 2013/07/22 �g�� �w�E�E�m�F�����ꗗ_�Г��m�F�p��376--------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // 2�p���ځF���i���
            PartsInfoDataSet partsInfoDB = null;

            // 3�p���ځF���i�A���f�[�^
            List<GoodsUnitData> goodsUnitDataList = null;

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            List<Rate> rateList = new List<Rate>();

            // �i�Ԍ���
            try
            {
                status = SearchPartsFromGoodsNo(
                    enterpriseCode,
                    sectionCode,
                    customerCode,
                    searchingCondition,
                    out partsInfoDB,
                    out goodsUnitDataList,
                    out message,
                    out unitPriceCalcRetList,
                    out rateList);
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "�i�Ԍ����@status�F" + status.ToString() + " " + message);
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                string errMsg = ex.ToString();
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

                return status;// ADD huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.44�̑Ή�
            }

            // �����Ȃ��̏ꍇ�A�܂��̓G���[��������ꍇ�A�X�e�[�^�X��߂�܂��B
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.42�̑Ή� ---->>>>>
                // ���i�������ʂȂ��̏ꍇ�APMTAB���[�U�[���i�������ʂ�SCM DB�ɓo�^����
                try
                {
                    status = NotUrGoodsInfoPro(partsInfoDB, enterpriseCode, sectionCode,
                        goodsNo, blGoodsCode, businessSessionId, pmTabSearchGuid,
                        out message);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
                    {
                        return status;
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    message = "���i�f�[�^������܂���B";
                }
                catch (Exception ex)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    message = ex.ToString();
                }
                //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.42�̑Ή� ----<<<<<
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return status;
            }
            #endregion �i�Ԍ���

            // ----- ADD songg 2013/07/10 Redmine#38106 �D�Ǖi�ԓ_�t���� ----- >>>>>
            #region ��������񌟍�
            // ���i�ԍ����h�b�g�i�D�j�t�̎��A�擾�����i�Ԍ�����茋�������������s����
            //if (searchingCondition.PartsJoinCntDivCd == ".") // DEL huangt 2013/07/25 Redmine#39168 �i�Ԍ������s���ƌ������ʂ̃��[�U�[���i�������ʂ̒񋟃f�[�^�敪���K��97�ɂȂ�
            // ----- ADD huangt 2013/07/25 Redmine#39168 �i�Ԍ������s���ƌ������ʂ̃��[�U�[���i�������ʂ̒񋟃f�[�^�敪���K��97�ɂȂ� ----->>>>>
            // UPD 2013/08/05 TAKAGAWA Redmine#39600�Ή� ---------->>>>>>>>>>
            //if (!(string.IsNullOrEmpty(searchingCondition.GoodsNo)) && (searchingCondition.GoodsNo.Length > 1)
            //    && (searchingCondition.GoodsNo.LastIndexOf(".") == searchingCondition.GoodsNo.Length - 1))
            if (!(string.IsNullOrEmpty(searchingCondition.GoodsNo)) && (searchingCondition.GoodsNo.Length > 1))
            // UPD 2013/08/05 TAKAGAWA Redmine#39600�Ή� ----------<<<<<<<<<<
            // ----- ADD huangt 2013/07/25 Redmine#39168 �i�Ԍ������s���ƌ������ʂ̃��[�U�[���i�������ʂ̒񋟃f�[�^�敪���K��97�ɂȂ� -----<<<<<
            {
                // DEL 2013/07/30 �g�� ���������� ���f ----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //SearchPartsForSrcPartsProc(enterpriseCode, sectionCode,
                //    ref partsInfoDB, ref goodsUnitDataList);
                // DEL 2013/07/30 �g�� ���������� ���f -----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2013/07/30 �g�� ���������� ���f ----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // �������i�������ꍇ�Ɍ��������������{
                string gdscd = searchingCondition.GoodsNo.Trim();
                gdscd = gdscd.Remove(gdscd.Length - 1);
                string query = string.Format("{0}='{1}' ",
                                partsInfoDB.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, gdscd);
                PartsInfoDataSet.UsrJoinPartsRow[] rowGoodsJoin =
                    (PartsInfoDataSet.UsrJoinPartsRow[])partsInfoDB.UsrJoinParts.Select(query);
                if (rowGoodsJoin.Length == 0)
                {
                    // ����������
                    // UPD 2013/08/05 TAKAGAWA Redmine#39600�Ή� ---------->>>>>>>>>>
                    //SearchPartsForSrcPartsProc(enterpriseCode, sectionCode,
                    //    ref partsInfoDB, ref goodsUnitDataList);
                    SearchPartsForSrcPartsProc(enterpriseCode, sectionCode,
                        ref partsInfoDB, ref goodsUnitDataList, searchingCondition.GoodsNo);
                    // UPD 2013/08/05 TAKAGAWA Redmine#39600�Ή� ---------->>>>>>>>>>
                }
                // ADD 2013/07/30 �g�� ���������� ���f -----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            }
            #endregion ��������񌟍�
            // ----- ADD songg 2013/07/10 Redmine#38106 �D�Ǖi�ԓ_�t���� ----- <<<<<

            // �ۑ��p���X�g������
            CustomSerializeArrayList pmtPartsSearchWorkList = new CustomSerializeArrayList();

            // �ԗ�����USER DB�ɏ�����																							
            // PMTAB�󒍃}�X�^�i�ԗ��j	
            // UPD 2013/08/01 yugami Redmine#39487 ------------------------------------------->>>>>
            //status = WritePmTabAcpOdrCar(searchedCarInfo, enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid);

            if (!searchedCarResult.Equals(CarSearchResultReport.retFailed))
            {
                // UPD 2013/12/19 VSS[020_10] ����ýď�Q��4 �g�� ------------------->>>>>>>>>>>>>>>
                #region ���\�[�X
                //// UPD 2013/12/12 SCM�d�|�ꗗ��10609�Ή� ---------------------------------->>>>>
                ////status = WritePmTabAcpOdrCar(searchedCarInfo, enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid);
                //status = WritePmTabAcpOdrCar(searchedCarInfo, enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid, pmTabSalesDtCarWork);
                //// UPD 2013/12/12 SCM�d�|�ꗗ��10609�Ή� ----------------------------------<<<<<
                #endregion
                status = WritePmTabAcpOdrCar(searchedCarInfo, enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid);
                // UPD 2013/12/19 VSS[020_10] ����ýď�Q��4 �g�� -------------------<<<<<<<<<<<<<<<
            }
            // �Y���f�[�^�Ȃ��̎���SCM-DB����f�[�^�i�ԗ����j�̓��e���X�V����
            else
            {
                status = WritePmTabAcpOdrCar(pmTabSalesDtCarWork, enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid);
            }
            // UPD 2013/08/01 yugami Redmine#39487 -------------------------------------------<<<<<
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "PMTAB�󒍃}�X�^�i�ԗ��j�o�^�����@status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return status;
            }

            //-----ADD huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.43�̑Ή� ---->>>>>
            // �ԗ�����SCM DB�ɍX�V����
            // ADD 2013/08/01 yugami Redmine#39487 ------------------------------------------->>>>>
            // �ԗ��������ʂ�0���̎���SCM-DB�ɍX�V���Ȃ�
            if (!searchedCarResult.Equals(CarSearchResultReport.retFailed))
            {
            // ADD 2013/08/01 yugami Redmine#39487 -------------------------------------------<<<<<
                status = WritePmTabSalDCar(searchedCarInfo, pmTabSalesDtCarWork, enterpriseCode, businessSessionId, sectionCode, pmTabSearchGuid);
            } // ADD 2013/08/01 yugami Redmine#39487 

             // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "���i�������ʂȂ��̏ꍇ�APMTAB���[�U�[���i�������ʂ�SCM DB�o�^�����@status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return status;
            }
            //-----ADD huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.43�̑Ή� ----<<<<<

            //-----DEL songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.42�̑Ή� ---->>>>>
            //// ���i�������ʂȂ��̏ꍇ�APMTAB���[�U�[���i�������ʂ�SCM DB�ɓo�^����
            //status = NotUrGoodsInfoPro(partsInfoDB, ref pmtPartsSearchWorkList,
            //    enterpriseCode, sectionCode, goodsNo, blGoodsCode,
            //    businessSessionId, pmTabSearchGuid, out message);
            //if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) ||
            //    (status == (int)ConstantManagement.DB_Status.ctDB_ERROR))
            //{
            //    return status;
            //}
            //-----DEL songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.42�̑Ή� ----<<<<<

            // ���i�A���f�[�^�s�����ݒ�
            this.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true, sectionCode);

            //-----DEL songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ---->>>>>
            //// �P���v�Z
            //SetCalculator(partsInfoDB, ref goodsUnitDataList, enterpriseCode,
            //    sectionCode, customerCode, out unitPriceCalcRetList, out rateList);
            //-----DEL songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ----<<<<<

            //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ---->>>>>
            // ���Ӑ�|���O���[�v���X�g
            List<CustRateGroup> custRateGroupList = new List<CustRateGroup>();
            // �P���v�Z
            SetCalculator(partsInfoDB, ref goodsUnitDataList, enterpriseCode,
                sectionCode, customerCode, out unitPriceCalcRetList, out custRateGroupList, out rateList);
            //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ----<<<<<

            // (17�e�[�u��)���i�������ʂ�SCM DB�ɏ�����
            GetPartsInfoToScmDBDataList(partsInfoDB, 
                enterpriseCode, 
                sectionCode, 
                businessSessionId, 
                pmTabSearchGuid, 
                ref pmtPartsSearchWorkList);

            // PMTAB�|���������ʃf�[�^�i�ꎞ�j
            GetRateToScmDBDataList(rateList,
                enterpriseCode,
                sectionCode,
                businessSessionId,
                pmTabSearchGuid,
                ref pmtPartsSearchWorkList);

            //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ---->>>>>
            // ���Ӑ�}�X�^�i�|���O���[�v�j�}�X�^�f�[�^�o�^
            GetCustRateGroupToScmDBDataList(custRateGroupList,
                enterpriseCode,
                sectionCode,
                businessSessionId,
                pmTabSearchGuid,
                ref pmtPartsSearchWorkList);
            //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ----<<<<<


            // �}�X�^�f�[�^���֏���
            status = GetMastDataToScmDBDataList(enterpriseCode,
                sectionCode,
                businessSessionId,
                pmTabSearchGuid,
                ref pmtPartsSearchWorkList,
                goodsUnitDataList, out message,
                customerCode);

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "�}�X�^�f�[�^���֏����@status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return status;
            }

             // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            //return status;    // DEL huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.44�̑Ή� 
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;   // ADD huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.44�̑Ή� 
        }

        // ----- ADD songg 2013/07/10 Redmine#38106 �D�Ǖi�ԓ_�t���� ----- >>>>>
        /// <summary>
        /// ��������������
        /// ��MAHNB01001U MAHNB01012AB.cs �� SearchPartsFromGoodsNo ���\�b�h���ɂ���	
        /// partsInfoDataSet.SearchPartsForSrcParts ���Q�l�Ɍ������������s���܂�	
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="partsInfoDB">���i���</param>
        /// <param name="goodsUnitDataList">���i��񃊃X�g</param>
        /// <param name="goodsNo">���i�ԍ�</param>  // ADD 2013/08/05 TAKAGAWA Redmine#39600�Ή�
        // UPD 2013/08/05 TAKAGAWA Redmine#39600�Ή� ---------->>>>>>>>>>
        //private void SearchPartsForSrcPartsProc(string enterpriseCode, string sectionCode,
        //    ref PartsInfoDataSet partsInfoDB, ref List<GoodsUnitData> goodsUnitDataList)
        private void SearchPartsForSrcPartsProc(string enterpriseCode, string sectionCode,
            ref PartsInfoDataSet partsInfoDB, ref List<GoodsUnitData> goodsUnitDataList, string goodsNo)
        // UPD 2013/08/05 TAKAGAWA Redmine#39600�Ή� ----------<<<<<<<<<<
        {
            // �����p��������
            PartsInfoDataSet.UsrGoodsInfoDataTable usrGoodsInfoTable = partsInfoDB.UsrGoodsInfo;

            const string methodName = "SearchPartsForSrcPartsProc";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n ����������");

            // ���i���e�[�u��
            PartsInfoDataSet.UsrGoodsInfoDataTable tempUsrGoodsInfoDataTable = partsInfoDB.UsrGoodsInfo;
            // ���i���i���e�[�u��
            PartsInfoDataSet.UsrGoodsPriceDataTable tempUsrGoodsPriceDataTable = partsInfoDB.UsrGoodsPrice;
            // �������e�[�u��
            PartsInfoDataSet.UsrJoinPartsDataTable tempUsrJoinPartsDataTable = partsInfoDB.UsrJoinParts;

            Dictionary<string, GoodsUnitData> goodsUnitDataDic = new Dictionary<string, GoodsUnitData>();
            foreach (GoodsUnitData tempData in goodsUnitDataList)
            {
                string key = tempData.GoodsNo + ":" + tempData.GoodsMakerCd;
                if (!goodsUnitDataDic.ContainsKey(key))
                {
                    goodsUnitDataDic.Add(key, tempData);
                }
            }

            #region ���X�V������̒񋟃f�[�^�敪�Ɋi�[������
            // �X�V������̒񋟃f�[�^�敪
            // ADD 2013/08/05 TAKAGAWA Redmine#39600�Ή� ---------->>>>>>>>>>
            if (goodsNo.LastIndexOf(".") == goodsNo.Length - 1)
            {
            // ADD 2013/08/05 TAKAGAWA Redmine#39600�Ή� ----------<<<<<<<<<<
                for (int i = 0; i < partsInfoDB.UsrGoodsInfo.Count; i++)
                {
                    partsInfoDB.UsrGoodsInfo[i].OfferDataDiv = 97;
                }
            // ADD 2013/08/05 TAKAGAWA Redmine#39600�Ή� ---------->>>>>>>>>>
            }
            // ADD 2013/08/05 TAKAGAWA Redmine#39600�Ή� ----------<<<<<<<<<<
            #endregion ���X�V������̒񋟃f�[�^�敪�Ɋi�[������

            PartsInfoDataSet.UsrGoodsInfoRow[] usrGoodsInfoRows = usrGoodsInfoTable.Select() as PartsInfoDataSet.UsrGoodsInfoRow[];
            // �����悸�A���ւ������������擾�������s��
            for (int i = 0; i < usrGoodsInfoRows.Length; i++)
            {
                // ��������擾
                PartsInfoDataSet.UsrGoodsInfoRow tempUsrGoodsInfo = usrGoodsInfoRows[i] as PartsInfoDataSet.UsrGoodsInfoRow;

                // �������i�̌�����񌟍����܂���B
                if (tempUsrGoodsInfo.GoodsMakerCd < 1000)
                {
                    continue;
                }

                // �����������p�������ݒ�
                GoodsCndtn cndtn = new GoodsCndtn();
                cndtn.EnterpriseCode = enterpriseCode;
                cndtn.SectionCode = sectionCode;
                cndtn.GoodsMakerCd = tempUsrGoodsInfo.GoodsMakerCd;
                cndtn.GoodsNo = tempUsrGoodsInfo.GoodsNo;
                cndtn.PartsJoinCntDivCd = ".";
                cndtn.IsSettingSupplier = 1;

                if (null == _goodsAcs)
                {
                    _goodsAcs = new GoodsAcs();
                }

                // �������������ʃN���X
                PartsInfoDataSet partsInfoDataSet; 
                List<GoodsUnitData> tempGoodsUnitDataList;
                string msg;

                // �������f�[�^����
                int status = _goodsAcs.SearchPartsForSrcParts(0, cndtn, out partsInfoDataSet, out tempGoodsUnitDataList, out msg);


                // ADD songg 2013/07/18 Redmine38106��#13 �i�[����Ă��錋�����`�F�b�N�����ǉ� ---->>>>>
                // ���i���i���ݒ�
                if ((status == 0) && (partsInfoDataSet.UsrGoodsPrice.Count > 0))
                {
                    for (int j = 0; j < partsInfoDataSet.UsrGoodsPrice.Count; j++)
                    {
                        #region �����i���i�����i�[��
                        PartsInfoDataSet.UsrGoodsPriceRow tempUsrGoodsPriceFrom = partsInfoDataSet.UsrGoodsPrice[j] as PartsInfoDataSet.UsrGoodsPriceRow;
                        PartsInfoDataSet.UsrGoodsPriceRow tempUsrGoodsPriceTo = tempUsrGoodsPriceDataTable.NewUsrGoodsPriceRow();

                        tempUsrGoodsPriceTo.CreateDateTime = tempUsrGoodsPriceFrom.CreateDateTime;
                        tempUsrGoodsPriceTo.EnterpriseCode = tempUsrGoodsPriceFrom.EnterpriseCode;
                        // �񋟃f�[�^�̏ꍇ�AtempUsrGoodsPriceFrom.FileHeaderGuid��DBNull�̏ꍇ������̂ŁA
                        // ���̍ۂ̗�O�͖�������
                        try
                        {
                            tempUsrGoodsPriceTo.FileHeaderGuid = tempUsrGoodsPriceFrom.FileHeaderGuid;
                        }
                        catch
                        {
                        }
                        tempUsrGoodsPriceTo.GoodsMakerCd = tempUsrGoodsPriceFrom.GoodsMakerCd;
                        tempUsrGoodsPriceTo.GoodsNo = tempUsrGoodsPriceFrom.GoodsNo;
                        tempUsrGoodsPriceTo.ListPrice = tempUsrGoodsPriceFrom.ListPrice;
                        tempUsrGoodsPriceTo.LogicalDeleteCode = tempUsrGoodsPriceFrom.LogicalDeleteCode;
                        tempUsrGoodsPriceTo.OfferDate = tempUsrGoodsPriceFrom.OfferDate;
                        tempUsrGoodsPriceTo.OpenPriceDiv = tempUsrGoodsPriceFrom.OpenPriceDiv;
                        tempUsrGoodsPriceTo.PriceStartDate = tempUsrGoodsPriceFrom.PriceStartDate;
                        tempUsrGoodsPriceTo.SalesUnitCost = tempUsrGoodsPriceFrom.SalesUnitCost;
                        tempUsrGoodsPriceTo.StockRate = tempUsrGoodsPriceFrom.StockRate;
                        tempUsrGoodsPriceTo.UpdAssemblyId1 = tempUsrGoodsPriceFrom.UpdAssemblyId1;
                        tempUsrGoodsPriceTo.UpdAssemblyId2 = tempUsrGoodsPriceFrom.UpdAssemblyId2;
                        tempUsrGoodsPriceTo.UpdateDate = tempUsrGoodsPriceFrom.UpdateDate;
                        tempUsrGoodsPriceTo.UpdateDateTime = tempUsrGoodsPriceFrom.UpdateDateTime;
                        tempUsrGoodsPriceTo.UpdEmployeeCode = tempUsrGoodsPriceFrom.UpdEmployeeCode;

                        // ���������������f�[�^�̏��i���i����V�K��
                        try
                        {
                            tempUsrGoodsPriceDataTable.AddUsrGoodsPriceRow(tempUsrGoodsPriceTo);
                        }
                        catch
                        {
                            continue;
                        }

                        #endregion �����i���i�����i�[��
                    }
                }
                // ADD songg 2013/07/18 Redmine38106��#13 �i�[����Ă��錋�����`�F�b�N�����ǉ� ----<<<<<

                #region ��GoodsUnitData���i�[������
                foreach (GoodsUnitData tempData in tempGoodsUnitDataList)
                {
                    // ADD songg 2013/07/18 Redmine38106��#13 �i�[����Ă��錋�����`�F�b�N�����ǉ� ---->>>>>
                    // tempGoodsUnitDataList�ɒ艿��GoodsPriceList���i�[����Ă���i�Ԃ�ΏۂƂ���
                    if (tempUsrGoodsPriceDataTable.Select(string.Format("GoodsMakerCd = {0} and GoodsNo= '{1}'", tempData.GoodsMakerCd, tempData.GoodsNo)).Length == 0)
                    {
                        continue;
                    }
                    // ADD songg 2013/07/18 Redmine38106��#13 �i�[����Ă��錋�����`�F�b�N�����ǉ� ----<<<<<

                    string key = tempData.GoodsNo + ":" + tempData.GoodsMakerCd;
                    //if ((tempData.CreateDateTime > DateTime.MinValue) && (!goodsUnitDataDic.ContainsKey(key)))// DEL songg 2013/07/18 Redmine38106��#13 �i�[����Ă��錋�����`�F�b�N�����ǉ�
                    if (!goodsUnitDataDic.ContainsKey(key))// ADD songg 2013/07/18 Redmine38106��#13 �i�[����Ă��錋�����`�F�b�N�����ǉ�
                    {
                        goodsUnitDataDic.Add(key, tempData);
                        goodsUnitDataList.Add(tempData);
                    }
                }
                #endregion ��GoodsUnitData���i�[������

                // DEL 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //// ���O�L�^
                //EasyLogger.Write(CLASS_NAME, methodName, "��������񌟍������@status�F" + status.ToString());
                // DEL 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // �����������������ݒ�
                if ((status == 0) && (partsInfoDataSet.UsrGoodsInfo.Count > 0))
                {
                    for (int j = 0; j < partsInfoDataSet.UsrGoodsInfo.Count; j++)
                    {
                        
                        #region �����������i�[��
                        // ���������������f�[�^�̏��i����ݒ肷�遚
                        // ���������擾
                        PartsInfoDataSet.UsrGoodsInfoRow tempUsrGoodsInfoFrom = partsInfoDataSet.UsrGoodsInfo[j] as PartsInfoDataSet.UsrGoodsInfoRow;
                        PartsInfoDataSet.UsrGoodsInfoRow tempUsrGoodsInfoTo = tempUsrGoodsInfoDataTable.NewUsrGoodsInfoRow();

                        // DEL songg 2013/07/18 Redmine38106��#13 �i�[����Ă��錋�����`�F�b�N�����ǉ� ---->>>>>
                        //if (tempUsrGoodsInfoFrom.CreateDateTime == 0)
                        //{
                        //    continue;
                        //}
                        // DEL songg 2013/07/18 Redmine38106��#13 �i�[����Ă��錋�����`�F�b�N�����ǉ� ----<<<<<
                        // ADD songg 2013/07/18 Redmine38106��#13 �i�[����Ă��錋�����`�F�b�N�����ǉ� ---->>>>>
                        if (!goodsUnitDataDic.ContainsKey(tempUsrGoodsInfoFrom.GoodsNo + ":" + tempUsrGoodsInfoFrom.GoodsMakerCd))
                        {
                            continue;
                        }
                        // ADD songg 2013/07/18 Redmine38106��#13 �i�[����Ă��錋�����`�F�b�N�����ǉ� ----<<<<<


                        tempUsrGoodsInfoTo.BlGoodsCode = tempUsrGoodsInfoFrom.BlGoodsCode;
                        tempUsrGoodsInfoTo.CalcPrice = tempUsrGoodsInfoFrom.CalcPrice;
                        tempUsrGoodsInfoTo.CreateDateTime = tempUsrGoodsInfoFrom.CreateDateTime;
                        tempUsrGoodsInfoTo.CustRateGrpCode = tempUsrGoodsInfoFrom.CustRateGrpCode;
                        tempUsrGoodsInfoTo.DisplayOrder = tempUsrGoodsInfoFrom.DisplayOrder;
                        tempUsrGoodsInfoTo.EnterpriseCode = tempUsrGoodsInfoFrom.EnterpriseCode;
                        tempUsrGoodsInfoTo.EnterpriseGanreCode = tempUsrGoodsInfoFrom.EnterpriseGanreCode;

                        // tempUsrGoodsInfoTo.FileHeaderGuid = tempUsrGoodsInfoFrom.FileHeaderGuid;// DEL songg 2013/07/18 Redmine38106��#13 �i�[����Ă��錋�����`�F�b�N�����ǉ�
                        // ADD songg 2013/07/18 Redmine38106��#13 �i�[����Ă��錋�����`�F�b�N�����ǉ� ---->>>>>
                        try
                        {
                            // �񋟃f�[�^�̏ꍇ�AtempUsrGoodsPriceFrom.FileHeaderGuid��DBNull�̏ꍇ������̂ŁA
                            // ���̍ۂ̗�O�͖�������
                            tempUsrGoodsInfoTo.FileHeaderGuid = tempUsrGoodsInfoFrom.FileHeaderGuid;
                        }
                        catch
                        {

                        }
                        // ADD songg 2013/07/18 Redmine38106��#13 �i�[����Ă��錋�����`�F�b�N�����ǉ� ----<<<<<
                        tempUsrGoodsInfoTo.FreSrchPrtPropNo = tempUsrGoodsInfoFrom.FreSrchPrtPropNo;
                        tempUsrGoodsInfoTo.GoodsKind = tempUsrGoodsInfoFrom.GoodsKind;
                        tempUsrGoodsInfoTo.GoodsKindCode = tempUsrGoodsInfoFrom.GoodsKindCode;
                        tempUsrGoodsInfoTo.GoodsKindResolved = tempUsrGoodsInfoFrom.GoodsKindResolved;
                        tempUsrGoodsInfoTo.GoodsMakerCd = tempUsrGoodsInfoFrom.GoodsMakerCd;
        
                        string key = tempUsrGoodsInfoFrom.GoodsNo + ":" + tempUsrGoodsInfoFrom.GoodsMakerCd;
                        if (goodsUnitDataDic.ContainsKey(key))
                        {
                            GoodsUnitData tempData = goodsUnitDataDic[key] as GoodsUnitData;
                            tempUsrGoodsInfoTo.GoodsMakerNm = tempData.MakerName;
                        }

                        tempUsrGoodsInfoTo.GoodsMGroup = tempUsrGoodsInfoFrom.GoodsMGroup;
                        tempUsrGoodsInfoTo.GoodsName = tempUsrGoodsInfoFrom.GoodsName;
                        tempUsrGoodsInfoTo.GoodsNameKana = tempUsrGoodsInfoFrom.GoodsNameKana;
                        tempUsrGoodsInfoTo.GoodsNo = tempUsrGoodsInfoFrom.GoodsNo;
                        tempUsrGoodsInfoTo.GoodsNoNoneHyphen = tempUsrGoodsInfoFrom.GoodsNoNoneHyphen;
                        tempUsrGoodsInfoTo.GoodsNote1 = tempUsrGoodsInfoFrom.GoodsNote1;
                        tempUsrGoodsInfoTo.GoodsNote2 = tempUsrGoodsInfoFrom.GoodsNote2;
                        tempUsrGoodsInfoTo.GoodsOfrName = tempUsrGoodsInfoFrom.GoodsOfrName;
                        tempUsrGoodsInfoTo.GoodsOfrNameKana = tempUsrGoodsInfoFrom.GoodsOfrNameKana;
                        tempUsrGoodsInfoTo.GoodsRateRank = tempUsrGoodsInfoFrom.GoodsRateRank;
                        tempUsrGoodsInfoTo.GoodsSpecialNote = tempUsrGoodsInfoFrom.GoodsSpecialNote;
                        tempUsrGoodsInfoTo.GoodsSpecialNoteOffer = tempUsrGoodsInfoFrom.GoodsSpecialNoteOffer;
                        tempUsrGoodsInfoTo.Jan = tempUsrGoodsInfoFrom.Jan;
                        tempUsrGoodsInfoTo.JoinSrcPrtsNo = tempUsrGoodsInfoFrom.JoinSrcPrtsNo;
                        tempUsrGoodsInfoTo.LogicalDeleteCode = tempUsrGoodsInfoFrom.LogicalDeleteCode;
                        tempUsrGoodsInfoTo.NewGoodsNo = tempUsrGoodsInfoFrom.NewGoodsNo;
                        tempUsrGoodsInfoTo.OfferDataDiv = 97;
                        tempUsrGoodsInfoTo.OfferDate = tempUsrGoodsInfoFrom.OfferDate;
                        tempUsrGoodsInfoTo.OfferKubun = tempUsrGoodsInfoFrom.OfferKubun;
                        tempUsrGoodsInfoTo.PartsPriceStDate = tempUsrGoodsInfoFrom.PartsPriceStDate;
                        tempUsrGoodsInfoTo.PriceSelectDiv = tempUsrGoodsInfoFrom.PriceSelectDiv;
                        tempUsrGoodsInfoTo.PriceTaxExc = tempUsrGoodsInfoFrom.PriceTaxExc;
                        tempUsrGoodsInfoTo.PriceTaxInc = tempUsrGoodsInfoFrom.PriceTaxInc;
                        tempUsrGoodsInfoTo.PrimeDisplayCode = tempUsrGoodsInfoFrom.PrimeDisplayCode;
                        tempUsrGoodsInfoTo.PrimeDispOrder = tempUsrGoodsInfoFrom.PrimeDispOrder;
                        tempUsrGoodsInfoTo.PrmSetDtlName2 = tempUsrGoodsInfoFrom.PrmSetDtlName2;
                        tempUsrGoodsInfoTo.PrtGoodsNo = tempUsrGoodsInfoFrom.PrtGoodsNo;
                        tempUsrGoodsInfoTo.PrtMakerCode = tempUsrGoodsInfoFrom.PrtMakerCode;
                        tempUsrGoodsInfoTo.PrtMakerName = tempUsrGoodsInfoFrom.PrtMakerName;
                        tempUsrGoodsInfoTo.QTY = tempUsrGoodsInfoFrom.QTY;
                        tempUsrGoodsInfoTo.RateDivLPrice = tempUsrGoodsInfoFrom.RateDivLPrice;
                        tempUsrGoodsInfoTo.RateDivSalUnPrc = tempUsrGoodsInfoFrom.RateDivSalUnPrc;
                        tempUsrGoodsInfoTo.RateDivUnCst = tempUsrGoodsInfoFrom.RateDivUnCst;
                        tempUsrGoodsInfoTo.SalesUnitPriceTaxExc = tempUsrGoodsInfoFrom.SalesUnitPriceTaxExc;
                        tempUsrGoodsInfoTo.SalesUnitPriceTaxInc = tempUsrGoodsInfoFrom.SalesUnitPriceTaxInc;
                        tempUsrGoodsInfoTo.SearchPartsFullName = tempUsrGoodsInfoFrom.SearchPartsFullName;
                        tempUsrGoodsInfoTo.SearchPartsHalfName = tempUsrGoodsInfoFrom.SearchPartsHalfName;
                        tempUsrGoodsInfoTo.SelectedGoodsNoDiv = tempUsrGoodsInfoFrom.SelectedGoodsNoDiv;
                        tempUsrGoodsInfoTo.SelectedListPrice = tempUsrGoodsInfoFrom.SelectedListPrice;
                        tempUsrGoodsInfoTo.SelectedListPriceDiv = tempUsrGoodsInfoFrom.SelectedListPriceDiv;
                        tempUsrGoodsInfoTo.SelectionComplete = tempUsrGoodsInfoFrom.SelectionComplete;
                        tempUsrGoodsInfoTo.SelectionState = tempUsrGoodsInfoFrom.SelectionState;
                        tempUsrGoodsInfoTo.SrchPNmAcqrCarMkrCd = tempUsrGoodsInfoFrom.SrchPNmAcqrCarMkrCd;
                        tempUsrGoodsInfoTo.TaxationDivCd = tempUsrGoodsInfoFrom.TaxationDivCd;
                        tempUsrGoodsInfoTo.UnitCostTaxExc = tempUsrGoodsInfoFrom.UnitCostTaxExc;
                        tempUsrGoodsInfoTo.UnitCostTaxInc = tempUsrGoodsInfoFrom.UnitCostTaxInc;
                        tempUsrGoodsInfoTo.UpdAssemblyId1 = tempUsrGoodsInfoFrom.UpdAssemblyId1;
                        tempUsrGoodsInfoTo.UpdAssemblyId2 = tempUsrGoodsInfoFrom.UpdAssemblyId2;
                        tempUsrGoodsInfoTo.UpdateDate = tempUsrGoodsInfoFrom.UpdateDate;
                        tempUsrGoodsInfoTo.UpdateDateTime = tempUsrGoodsInfoFrom.UpdateDateTime;
                        tempUsrGoodsInfoTo.UpdEmployeeCode = tempUsrGoodsInfoFrom.UpdEmployeeCode;

                        // ���������������f�[�^�̏��i����V�K��
                        if (tempUsrGoodsInfoDataTable.Select(string.Format("GoodsMakerCd = {0} and GoodsNo = '{1}'", tempUsrGoodsInfoTo.GoodsMakerCd, tempUsrGoodsInfoTo.GoodsNo)).Length == 0)
                        {
                            tempUsrGoodsInfoDataTable.AddUsrGoodsInfoRow(tempUsrGoodsInfoTo);
                        }
                        #endregion �����������i�[��

                        #region ���������i�[��
                        // �����������i�[��
                        PartsInfoDataSet.UsrJoinPartsRow tempUsrJoinPartsRowTo = tempUsrJoinPartsDataTable.NewUsrJoinPartsRow();
                        tempUsrJoinPartsRowTo.JoinDestMakerCd =	tempUsrGoodsInfo.GoodsMakerCd; //�����惁�[�J�[�R�[�h
                        tempUsrJoinPartsRowTo.JoinDestPartsNo =	tempUsrGoodsInfo.GoodsNo;//������i��(�|�t���i��)
                        tempUsrJoinPartsRowTo.JoinDispOrder = tempUsrGoodsInfo.DisplayOrder;//�����\������
                        tempUsrJoinPartsRowTo.JoinOfferDate = tempUsrGoodsInfo.OfferDate;//�񋟓�
                        tempUsrJoinPartsRowTo.JoinQty =	tempUsrGoodsInfo.QTY;//����QTY
                        tempUsrJoinPartsRowTo.JoinSourceMakerCode =	tempUsrGoodsInfoTo.GoodsMakerCd;//���������[�J�[�R�[�h
                        tempUsrJoinPartsRowTo.JoinSpecialNote =	tempUsrGoodsInfo.GoodsSpecialNote;//�����K�i�E���L����
                        tempUsrJoinPartsRowTo.JoinSrcPartsNoNoneH = tempUsrGoodsInfoTo.GoodsNoNoneHyphen;//�������i��(�|�����i��)
                        tempUsrJoinPartsRowTo.JoinSrcPartsNoWithH =	tempUsrGoodsInfoTo.GoodsNo;//�������i��(�|�t���i��)
                        tempUsrJoinPartsRowTo.PrimeDispOrder = tempUsrGoodsInfo.DisplayOrder;//�\������
                        if(tempUsrGoodsInfo.GoodsMakerCd >= 1000)
                        {
                            tempUsrJoinPartsRowTo.PrmSettingFlg	=	true;//�D�ǐݒ�敪 // TODO
                        }
                        else
                        {
                            tempUsrJoinPartsRowTo.PrmSettingFlg = false;//�D�ǐݒ�敪 // TODO
                        }
                        tempUsrJoinPartsRowTo.SelectionState	=	false;

                        // ��������ԗ�V�K��
                        if (tempUsrJoinPartsDataTable.Select(string.Format("JoinDestMakerCd = {0} and JoinDestPartsNo = '{1}' and JoinSourceMakerCode = {2} and JoinSrcPartsNoWithH = '{3}'",
                            tempUsrGoodsInfo.GoodsMakerCd,
                            tempUsrGoodsInfo.GoodsNo,
                            tempUsrGoodsInfoTo.GoodsMakerCd,
                            tempUsrGoodsInfoTo.GoodsNo)).Length == 0)
                        {
                            tempUsrJoinPartsDataTable.AddUsrJoinPartsRow(tempUsrJoinPartsRowTo);
                        }
                        #endregion ���������i�[��
                    }
                }

                // DEL songg 2013/07/18 Redmine38106��#13 �i�[����Ă��錋�����`�F�b�N�����ǉ� ---->>>>>
                // ���������������f�[�^�̏��i���i����ݒ肷�遚
                //if ((status == 0) && (partsInfoDataSet.UsrGoodsPrice.Count > 0))
                //{
                //    for (int j = 0; j < partsInfoDataSet.UsrGoodsPrice.Count; j++)
                //    {
                //        #region �����i���i�����i�[��
                //        PartsInfoDataSet.UsrGoodsPriceRow tempUsrGoodsPriceFrom = partsInfoDataSet.UsrGoodsPrice[j] as PartsInfoDataSet.UsrGoodsPriceRow;
                //        PartsInfoDataSet.UsrGoodsPriceRow tempUsrGoodsPriceTo = tempUsrGoodsPriceDataTable.NewUsrGoodsPriceRow();

                //        tempUsrGoodsPriceTo.CreateDateTime = tempUsrGoodsPriceFrom.CreateDateTime;
                //        tempUsrGoodsPriceTo.EnterpriseCode = tempUsrGoodsPriceFrom.EnterpriseCode;
                //        // �񋟃f�[�^�̏ꍇ�AtempUsrGoodsPriceFrom.FileHeaderGuid��DBNull�̏ꍇ������̂ŁA
                //        // ���̍ۂ̗�O�͖�������
                //        try
                //        {
                //        tempUsrGoodsPriceTo.FileHeaderGuid = tempUsrGoodsPriceFrom.FileHeaderGuid;
                //        }
                //        catch
                //        {
                //        }
                //        tempUsrGoodsPriceTo.GoodsMakerCd = tempUsrGoodsPriceFrom.GoodsMakerCd;
                //        tempUsrGoodsPriceTo.GoodsNo = tempUsrGoodsPriceFrom.GoodsNo;
                //        tempUsrGoodsPriceTo.ListPrice = tempUsrGoodsPriceFrom.ListPrice;
                //        tempUsrGoodsPriceTo.LogicalDeleteCode = tempUsrGoodsPriceFrom.LogicalDeleteCode;
                //        tempUsrGoodsPriceTo.OfferDate = tempUsrGoodsPriceFrom.OfferDate;
                //        tempUsrGoodsPriceTo.OpenPriceDiv = tempUsrGoodsPriceFrom.OpenPriceDiv;
                //        tempUsrGoodsPriceTo.PriceStartDate = tempUsrGoodsPriceFrom.PriceStartDate;
                //        tempUsrGoodsPriceTo.SalesUnitCost = tempUsrGoodsPriceFrom.SalesUnitCost;
                //        tempUsrGoodsPriceTo.StockRate = tempUsrGoodsPriceFrom.StockRate;
                //        tempUsrGoodsPriceTo.UpdAssemblyId1 = tempUsrGoodsPriceFrom.UpdAssemblyId1;
                //        tempUsrGoodsPriceTo.UpdAssemblyId2 = tempUsrGoodsPriceFrom.UpdAssemblyId2;
                //        tempUsrGoodsPriceTo.UpdateDate = tempUsrGoodsPriceFrom.UpdateDate;
                //        tempUsrGoodsPriceTo.UpdateDateTime = tempUsrGoodsPriceFrom.UpdateDateTime;
                //        tempUsrGoodsPriceTo.UpdEmployeeCode = tempUsrGoodsPriceFrom.UpdEmployeeCode;

                //        // ���������������f�[�^�̏��i���i����V�K��
                //        try
                //        {
                //            tempUsrGoodsPriceDataTable.AddUsrGoodsPriceRow(tempUsrGoodsPriceTo);
                //        }
                //        catch
                //        {
                //            continue;
                //        }

                //        #endregion �����i���i�����i�[��
                //    }
                //}
                // DEL songg 2013/07/18 Redmine38106��#13 �i�[����Ă��錋�����`�F�b�N�����ǉ� ----<<<<<
            }

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� ����������");
        }
        // ----- ADD songg 2013/07/10 Redmine#38106 �D�Ǖi�ԓ_�t���� ----- <<<<<

        /// <summary>
        /// �i�Ԍ����A�N�Z�T��p���ĕi�Ԍ������s���܂��B
        /// </summary>
        /// <remarks>MAHNB01012AB.cs SalesSlipInputAcs.SearchPartsFromGoodsNo() 1445�s�ڂ��ڐA</remarks>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="searchingCondition">��������</param>
        /// <param name="partsInfoDB">���i���</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        /// <param name="rateList">�|�����X�g</param>
        /// <returns>���ʃR�[�h</returns>
        protected int SearchPartsFromGoodsNo(
            string enterpriseCode,
            string sectionCode,
            int customerCode,
            GoodsCndtn searchingCondition,
            out PartsInfoDataSet partsInfoDB,
            out List<GoodsUnitData> goodsUnitDataList,
            out string msg,
            out List<UnitPriceCalcRet> unitPriceCalcRetList,
            out List<Rate> rateList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "SearchPartsFromGoodsNo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ResultUtil.ResultCode.Normal;

            unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            rateList = new List<Rate>();

            // UPD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� ------------------------------->>>>>
            //GoodsAcs _goodsAccesser = new GoodsAcs(sectionCode);
            //_goodsAccesser.SearchInitial(enterpriseCode, sectionCode, out msg);//-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή�
            if (_goodsAccesser == null)
            {
                _goodsAccesser = new GoodsAcs(sectionCode);
                _goodsAccesser.SearchInitial(enterpriseCode, sectionCode, out msg);//-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή�
            }
            // UPD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� -------------------------------<<<<<

            if (searchingCondition.GoodsMakerCd == 0)
            {
                status = _goodsAccesser.SearchPartsFromGoodsNo(
                    searchingCondition,
                    out partsInfoDB,
                    out goodsUnitDataList,
                    out msg);
            }
            else
            {
                searchingCondition.PartsNoSearchDivCd = 0;
                searchingCondition.JoinSearchDiv = 0;
                searchingCondition.PartsJoinCntDivCd = ".";
                status = _goodsAccesser.SearchPartsFromGoodsNo(
                    searchingCondition,
                    out partsInfoDB,
                    out goodsUnitDataList,
                    out msg);
            }

            if (!status.Equals((int)ResultUtil.ResultCode.Normal))
            {
                // ��������Ȃ������ꍇ�A�蓮�񓚂ł�
                // SCM�󒍖��׃f�[�^(�⍇���E����)��蔄��f�[�^���쐬����̂ŁA
                // 1�������������ꂽ���Ƃɂ���
                if ((goodsUnitDataList == null) || (goodsUnitDataList.Count == 0))
                {
                    goodsUnitDataList = new List<GoodsUnitData>();
                    goodsUnitDataList.Add(new GoodsUnitData());
                    //status = (int)ResultUtil.ResultCode.Normal;     // DEL huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.44�̑Ή� 
                    status = (int)ResultUtil.ResultCode.NotFound;     // ADD huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.44�̑Ή� 
                }
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� �i�Ԍ����Fstatus:" + status.ToString());
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return status;
            }
            if (partsInfoDB != null)
            {
                // �i���\���敪
                //-----DEL songg 2013/06/25 ��Q�� #37187�̑Ή� ����S�̐ݒ�}�X�^�擾 ---->>>>>
                //SalesTtlSt foundSalesTtlSt = SalesTtlStDB.Find(
                //    searchingCondition.EnterpriseCode,
                //    searchingCondition.SectionCode
                //);
                //-----DEL songg 2013/06/25 ��Q�� #37187�̑Ή� ����S�̐ݒ�}�X�^�擾 ----<<<<<
                //-----ADD songg 2013/06/25 ��Q�� #37187�̑Ή� ����S�̐ݒ�}�X�^�擾 ---->>>>>
                SalesTtlSt foundSalesTtlSt = GetSalesTtlStInfo(
                    searchingCondition.EnterpriseCode,
                    searchingCondition.SectionCode);
                //-----ADD songg 2013/06/25 ��Q�� #37187�̑Ή� ����S�̐ݒ�}�X�^�擾 ---->>>>>
                if (foundSalesTtlSt != null)
                {
                    partsInfoDB.SetPartsNameDisplayPattern(foundSalesTtlSt);
                    partsInfoDB.PriceSelectDispDiv = foundSalesTtlSt.PriceSelectDispDiv;
                    partsInfoDB.UnPrcNonSettingDiv = foundSalesTtlSt.UnPrcNonSettingDiv;
                }
            }
            

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }
        #endregion ���i�Ԍ�������

        #region �����ʃ��\�b�h
        #region �� �ԗ���������
        /// <summary>
        /// �ԗ����������𐶐����܂��B
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="modelCode">�Ԏ�R�[�h</param>
        /// <param name="modelSubCode">�Ԏ�T�u�R�[�h</param>
        /// <param name="modelDesignationNo">�^���w��ԍ�</param>
        /// <param name="categoryNo">�ޕʋ敪�ԍ�</param>
        /// <param name="fullModel">�^��(�t���^)</param>
        /// <param name="carInspectCertModel">�Ԍ��،^��</param>
        /// <returns>�ԗ���������</returns>
        private CarSearchCondition CreateSearchingCarCondition(int makerCode, int modelCode,
            int modelSubCode, int modelDesignationNo, int categoryNo, string fullModel, string carInspectCertModel)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "CreateSearchingCarCondition";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            CarSearchCondition consition = new CarSearchCondition();
            {
                consition.MakerCode = makerCode;          // ���[�J�[�R�[�h
                consition.ModelCode = modelCode;          // �Ԏ�R�[�h
                if (makerCode == 0)
                {
                    // ���[�J�[�R�[�h�������l�i0�j�̏ꍇ�́A�Ԏ�T�u�R�[�h�ɖ����l�i-1�j��ݒ肷��
                    consition.ModelSubCode = -1;
                }
                else
                {
                    consition.ModelSubCode = modelSubCode;       // �Ԏ�T�u�R�[�h
                }

                consition.ModelDesignationNo = modelDesignationNo; // �^���w��ԍ�

                consition.CategoryNo = categoryNo;         // �ޕʋ敪�ԍ�

                if (consition.ModelDesignationNo.Equals(0) || consition.CategoryNo.Equals(0))
                {
                    consition.ModelDesignationNo = 0;                   // �^���w��ԍ�
                    consition.CategoryNo = 0;                           // �ޕʋ敪�ԍ�

                    consition.CarModel.FullModel = string.IsNullOrEmpty(fullModel) ? carInspectCertModel : fullModel;// �^��(�t���^)
                }

                //-----DEL songg 2013/06/20 �d�l�A�� #37004�̑Ή� �^������̎ԗ��������\�ɂ���---->>>>>
                //// �ԗ������^�C�v�i�Œ�łP�j
                //consition.Type = CarSearchType.csCategory;  // �ޕʌ���
                //-----DEL songg 2013/06/20 �d�l�A�� #37004�̑Ή� �^������̎ԗ��������\�ɂ���----<<<<<
                //-----ADD songg 2013/06/20 �d�l�A�� #37004�̑Ή� �^������̎ԗ��������\�ɂ���---->>>>>
                // �ԗ������^�C�v(Type)
                // �ޕʋ敪�ԍ��E�^���w��ԍ������鎞�A�P�F�ޕʌ�����ݒ�
                if ((consition.ModelDesignationNo != 0) || (consition.ModelDesignationNo != 0))
                {
                    consition.Type = CarSearchType.csCategory;
                }
                // �ޕʋ敪�ԍ��E�^���w��ԍ����Ȃ��^���i�t���j�����鎞�A�Q�F�^���I����ݒ�
                else if (!string.IsNullOrEmpty(consition.CarModel.FullModel))
                {
                    consition.Type = CarSearchType.csModel;
                }
                else
                {
                    consition.Type = CarSearchType.csCategory;
                }
                																										

                //-----ADD songg 2013/06/20 �d�l�A�� #37004�̑Ή� �^������̎ԗ��������\�ɂ���----<<<<<
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return consition;
        }

        /// <summary>
        /// ���q���������ݒ�`�F�b�N����
        /// </summary>
        /// <param name="searchingCarCondition">���q��������</param>
        /// <returns>true: �ݒ肠��, false: ���ݒ�</returns>
        private bool CheckCarSearchCondition(CarSearchCondition searchingCarCondition)
        {
            return (searchingCarCondition.ModelDesignationNo != 0 ||                         
                    searchingCarCondition.CategoryNo != 0 ||                                 
                    searchingCarCondition.CarModel.FullModel != string.Empty ||               
                    searchingCarCondition.MakerCode != 0 ||                                   
                    searchingCarCondition.ModelCode != 0 ||                                   
                    searchingCarCondition.ModelSubCode != 0);                                 
        }

        /// <summary>
        /// �ԗ����������܂��B
        /// </summary>
        /// <param name="searchingCarCondition">��������</param>
        /// <param name="searchedCarInfo">��������</param>
        /// <returns>�����X�e�[�^�X</returns>
        private CarSearchResultReport SearchCar(
            CarSearchCondition searchingCarCondition,
            ref PMKEN01010E searchedCarInfo
        )
        {
            // CarSearchController�@_carAccesser = new CarSearchController();//-----DEL songg 2013/06/27 ��Q�� #37360�̑Ή�
            //-----ADD songg 2013/06/27 ��Q�� #37360�̑Ή� ---->>>>>
            if (null == _carAccesser)
            {
                _carAccesser = new CarSearchController();
            }
            //-----ADD songg 2013/06/27 ��Q�� #37360�̑Ή� ----<<<<<
            return _carAccesser.Search(searchingCarCondition, ref searchedCarInfo);
        }
        #endregion �� �ԗ���������

        #region �� ����S�̐ݒ�}�X�^�擾
        /// <summary>
        /// ����S�̐ݒ�}�X�^���擾���܂��B
        /// </summary>
        protected static SalesTtlStAgentForTablet SalesTtlStDB
        {
            get { return SalesTtlStServer.Singleton.Instance; }
        }
        #endregion �� ����S�̐ݒ�}�X�^�擾

        #region �� ���������ݒ菈��
        /// <summary>
        /// �i�Ԍ��������𐶐����܂��B(�i�Ԃ��Ȃ��ꍇ�ABL�R�[�h�����BL�R�[�h�}�Ԃ��w�肵�܂�)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="blGoodsCode">�a�k�R�[�h</param>
        /// <param name="searchedCarInfo">�ԗ���������</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>�i�Ԍ�������</returns>
        // UPD 2013/07/31 �g�� ���Ӑ�Ǘ����_�Ή� ----------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
        #region ���\�[�X
        //protected GoodsCndtn CreateSearchingGoodsCondition(
        //    string enterpriseCode, string sectionCode, string goodsNo, int blGoodsCode,
        //    PMKEN01010E searchedCarInfo
        //)
        #endregion
        protected GoodsCndtn CreateSearchingGoodsCondition(
            string enterpriseCode, string sectionCode, string goodsNo, int blGoodsCode,
            PMKEN01010E searchedCarInfo, int customerCode
        )
        // UPD 2013/07/31 �g�� ���Ӑ�Ǘ����_�Ή� -----------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "CreateSearchingGoodsCondition";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            GoodsCndtn condition = new GoodsCndtn();
            {
                // ��ƃR�[�h
                condition.EnterpriseCode = enterpriseCode;

                // ���_�R�[�h
                // UPD 2013/08/01 �g�� Redmine#39496 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region ���\�[�X
                //// UPD 2013/07/31 �g�� ���Ӑ�Ǘ����_�Ή� ----------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //// condition.SectionCode = sectionCode;
                //condition.SectionCode = this.CustomerInfo(enterpriseCode, customerCode).MngSectionCode.Trim();
                //// UPD 2013/07/31 �g�� ���Ӑ�Ǘ����_�Ή� -----------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                #endregion
                condition.SectionCode = this.CustomerInfo().MngSectionCode.Trim();
                // UPD 2013/08/01 �g�� Redmine#39496 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                // ���i�ԍ�
                condition.GoodsNo = goodsNo;
                {
                    // �i�Ԃ��Ȃ��ꍇ�ABL�R�[�h�����BL�R�[�h�}�Ԃ��w��
                    if (string.IsNullOrEmpty(goodsNo.Trim()))
                    {
                        // BL�R�[�h
                        condition.BLGoodsCode = blGoodsCode;
                    }
                }

                // ����S�̐ݒ���擾
                //-----DEL songg 2013/06/25 ��Q�� #37187�̑Ή� ����S�̐ݒ�}�X�^�擾 ---->>>>>
                //SalesTtlSt salesTtlSt = SalesTtlStDB.Find(enterpriseCode, sectionCode);
                //-----DEL songg 2013/06/25 ��Q�� #37187�̑Ή� ����S�̐ݒ�}�X�^�擾 ----<<<<<
                //-----ADD songg 2013/06/25 ��Q�� #37187�̑Ή� ����S�̐ݒ�}�X�^�擾 ---->>>>>
                SalesTtlSt salesTtlSt = GetSalesTtlStInfo(enterpriseCode, sectionCode);
                //-----ADD songg 2013/06/25 ��Q�� #37187�̑Ή� ����S�̐ݒ�}�X�^�擾 ----<<<<<
                if (salesTtlSt != null)
                {
                    // ��֏����敪�c0:��ւ��Ȃ�, 1:��ւ���(�݌ɖ�), 2:��ւ���(�݌ɖ���) �G���g������̕��i�������̂ݗL��
                    condition.SubstCondDivCd = salesTtlSt.SubstCondDivCd;

                    // �D�Ǒ�֏����敪�c0:���Ȃ�, 1:����(�����A�Z�b�g), 2:�S��(�����A�Z�b�g�A�����j �G���g������̕��i�������̂ݗL��
                    condition.PrmSubstCondDivCd = salesTtlSt.PrmSubstCondDivCd;

                    // ��֓K�p�敪�c0:���Ȃ�, 1:����(�����A�Z�b�g), 2:�S��(�����A�Z�b�g�A����) �G���g������̕��i�������̂ݗL��
                    condition.SubstApplyDivCd = salesTtlSt.SubstApplyDivCd;

                    // ���i�����D�揇�敪�c0:����, 1:�D��
                    condition.PartsSearchPriDivCd = salesTtlSt.PartsSearchPriDivCd;

                    // ���������\���敪�c0:�\����, 1:�݌ɏ�
                    condition.JoinInitDispDiv = salesTtlSt.JoinInitDispDiv;
                }

                // ������ʐ���敪�c0:PM7, 1:PM.NS �G���g������̕��i�������̂ݗL��
                condition.SearchUICntDivCd = 1; // ������1 �蓮�͈������� 

                // �G���^�[�L�[�����敪�c0:PM7(�Z�b�g�̂�), 1:�I��, 2:����� �G���g������̕��i�������̂ݗL��
                condition.EnterProcDivCd = 0;   // ������0 �蓮�͈�������

                // UPD 2013/07/22 �g�� �w�E�E�m�F�����ꗗ_�Г��m�F�p��376-------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // �i�Ԍ����敪�c0:PM7(�Z�b�g�̂�), 1:�����E�Z�b�g�E��ւ��� �G���g������̕��i�������̂ݗL��
                // condition.PartsNoSearchDivCd = 1;   // ������1 �蓮�͈�������
                condition.PartsNoSearchDivCd = 0;   // ���`�ł͌Œ��0���Z�b�g
                // UPD 2013/07/22 �g�� �w�E�E�m�F�����ꗗ_�Г��m�F�p��376--------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // �����\���敪1�c0:����, 1:�a��(�N��) �G���g������̕��i�������̂ݗL��
                condition.EraNameDispCd1 = 0;

                // ���i�K�p��
                condition.PriceApplyDate = DateTime.Now;    // �V�X�e�����t

                // �d������擾�敪�c0:�ݒ肠��, �ݒ�Ȃ�
                condition.IsSettingSupplier = 0;

                // ���������敪�c0:���������Ȃ�, 1:������������
                condition.JoinSearchDiv = 1;

                // �ԗ��������ʁcBL�R�[�h�������̂ݎg�p
                // UPD 2013/12/19 VSS[020_10] ����ýď�Q��4 �g�� ------------------->>>>>>>>>>>>>>>
                // condition.SearchCarInfo = searchedCarInfo;
                condition.SearchCarInfo = (PMKEN01010E)searchedCarInfo.Copy();
                // UPD 2013/12/19 VSS[020_10] ����ýď�Q��4 �g�� -------------------<<<<<<<<<<<<<<<
                
                // ADD 2013/12/19 VSS[020_10] ����ýď�Q��4 �g�� ------------------->>>>>>>>>>>>>>>
                // ���i�����̎��́A�ԑ�ԍ��̐擪0���폜
                // SearchCarByMultipleCarModel�Ɠ������@�Ő��l�ɕϊ���A������
                foreach(PMKEN01010E.CarModelUIRow row in condition.SearchCarInfo.CarModelUIData.Rows)
                {
                    if (row.FrameNo != null && !row.FrameNo.Equals(string.Empty))
                    {
                        row.FrameNo = TStrConv.StrToIntDef(row.FrameNo, 0).ToString();
                    }
                }
                // ADD 2013/12/19 VSS[020_10] ����ýď�Q��4 �g�� -------------------<<<<<<<<<<<<<<<

                // ADD 2013/07/22 �g�� �w�E�E�m�F�����ꗗ_�Г��m�F�p��376-------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // �i�Ԍ�������敪
                condition.PartsJoinCntDivCd = "." ;  
                // ADD 2013/07/22 �g�� �w�E�E�m�F�����ꗗ_�Г��m�F�p��376--------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return condition;
        }

        /// <summary>
        /// �i�Ԍ���������ҏW���܂��B
        /// </summary>
        /// <param name="searchingCondition">�i�Ԍ�������</param>
        /// <returns>�ҏW�����i�Ԍ�������</returns>
        protected virtual GoodsCndtn EditSearchingGoodsCondition(GoodsCndtn searchingCondition)
        {
            return searchingCondition;
        }
        #endregion �� ���������ݒ菈��

        #region �� �P���v�Z
        /// <summary>
        /// ���i�Z�o�n�f���Q�[�g��ݒ肵�܂��B
        /// </summary>
        /// <param name="partsInfoDB">���i���</param>
        /// <param name="goodsUnitDataList">���i�A����񃊃X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        /// <param name="custRateGroupList">���Ӑ�|���O���[�v���X�g</param>
        /// <param name="rateList">�|�����X�g</param>
        private void SetCalculator(PartsInfoDataSet partsInfoDB, ref List<GoodsUnitData> goodsUnitDataList, 
            string enterpriseCode, string sectionCode, int customerCode,
            out List<UnitPriceCalcRet> unitPriceCalcRetList,
            out List<CustRateGroup> custRateGroupList,//-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή�
            out List<Rate> rateList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "SetCalculator";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            //-----DEL songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ---->>>>>
            //// �P���Z�o����
            //CalculateUnitPrice(partsInfoDB, ref goodsUnitDataList, enterpriseCode, 
            //    sectionCode, customerCode, out unitPriceCalcRetList, out rateList);
            //-----DEL songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ----<<<<<

            //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ---->>>>>
            // �P���Z�o����
            CalculateUnitPrice(partsInfoDB, ref goodsUnitDataList, enterpriseCode,
                sectionCode, customerCode, out unitPriceCalcRetList, out custRateGroupList, out rateList);
            //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ----<<<<<

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
        }

        /// <summary>
        ///  ���Ӑ�|���O���[�v�R�[�h�擾����
        /// </summary>
        /// <param name="custRateGroupList">���Ӑ�|���O���[�v��񃊃X�g</param>
        /// <param name="goodsMakerCode">���i���[�J�[�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetCustRateGroupCode(ref List<CustRateGroup> custRateGroupList, int goodsMakerCode)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "GetCustRateGroupCode";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int pureCode = (goodsMakerCode <= ctPureGoodsMakerCode) ? 0 : 1; // 0:���� 1:�D��

            // �P�ƃL�[
            CustRateGroup custRateGroup = custRateGroupList.Find(
                delegate(CustRateGroup custRate)
                {
                    if ((custRate.GoodsMakerCd == goodsMakerCode) &&
                        (custRate.PureCode == pureCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            // if (custRateGroup != null) return custRateGroup.CustRateGrpCode;
            if (custRateGroup != null)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                return custRateGroup.CustRateGrpCode;
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            // ���ʃL�[
            custRateGroup = custRateGroupList.Find(
                delegate(CustRateGroup custRate)
                {
                    if ((custRate.GoodsMakerCd == 0) &&
                        (custRate.PureCode == pureCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            // if (custRateGroup != null) return custRateGroup.CustRateGrpCode;
            if (custRateGroup != null)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                return custRateGroup.CustRateGrpCode;
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� custRateGroup null");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return -1;
        }

        //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ---->>>>>
        /// <summary>
        ///  ���Ӑ�|���O���[�v�擾����
        /// </summary>
        /// <param name="custRateGroupList">���Ӑ�|���O���[�v��񃊃X�g</param>
        /// <param name="goodsMakerCode">���i���[�J�[�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        private CustRateGroup GetCustRateGroup(ref List<CustRateGroup> custRateGroupList, int goodsMakerCode)
        {
            // DEL 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            //const string methodName = "GetCustRateGroup";
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            // DEL 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<


            int pureCode = (goodsMakerCode <= ctPureGoodsMakerCode) ? 0 : 1; // 0:���� 1:�D��

            // �P�ƃL�[
            CustRateGroup custRateGroup = custRateGroupList.Find(
                delegate(CustRateGroup custRate)
                {
                    if ((custRate.GoodsMakerCd == goodsMakerCode) &&
                        (custRate.PureCode == pureCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            if (custRateGroup != null) return custRateGroup;

            // ���ʃL�[
            custRateGroup = custRateGroupList.Find(
                delegate(CustRateGroup custRate)
                {
                    if ((custRate.GoodsMakerCd == 0) &&
                        (custRate.PureCode == pureCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            //if (custRateGroup != null) return custRateGroup;
            if (custRateGroup != null)
            {
                // DEL 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // DEL 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                return custRateGroup;
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            // DEL 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� custRateGroup null");
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            // DEL 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return null;
        }
        //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ----<<<<<

        /// <summary>
        /// �ŗ��ݒ�����擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�ŗ��ݒ���</returns>
        private static TaxRateSet GetTaxRateSet(string enterpriseCode)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "GetTaxRateSet";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            // TaxRateSet taxRateSet = new TaxRateSet(); //-----DEL songg 2013/06/19 �\�[�X�`�F�b�N�m�F�����ꗗ��No.39�̑Ή�
            TaxRateSet taxRateSet = null;                //-----ADD songg 2013/06/19 �\�[�X�`�F�b�N�m�F�����ꗗ��No.39�̑Ή�
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            {
                if (taxRateSet == null)
                {
                    int status = taxRateSetAcs.Read(out taxRateSet, enterpriseCode, 0);
                }

                if (taxRateSet == null)
                {
                    taxRateSet = new TaxRateSet();
                }
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return taxRateSet;
            }
        }


        /// <summary>
        /// �ŗ����擾���܂��B
        /// </summary>
        /// <param name="taxRateSet">�ŗ��ݒ���</param>
        /// <param name="targetDate">�ŗ��K�p��</param>
        /// <returns>�ŗ�</returns>
        private static double GetTaxRate(
            TaxRateSet taxRateSet,
            DateTime targetDate
        )
        {
            return TaxRateSetAcs.GetTaxRate(taxRateSet, targetDate);
        }

        /// <summary>
        /// �P���Z�o����
        /// </summary>
        /// <param name="partsInfoDB">�݌ɏ��</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="unitPriceCalcRetList">�P���v�Z���ʃ��X�g</param>
        /// <param name="customRateGroupList">���Ӑ�|���O���[�v���X�g</param>
        /// <param name="rateList">�|�����X�g</param>
        private void CalculateUnitPrice(PartsInfoDataSet partsInfoDB, ref List<GoodsUnitData> goodsUnitDataList, 
            string enterpriseCode, string sectionCode, int customerCode,
            out List<UnitPriceCalcRet> unitPriceCalcRetList,
            out List<CustRateGroup> customRateGroupList,//-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή�
            out List<Rate> rateList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "CalculateUnitPrice";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ---->>>>>
            // ���Ӑ�|���O���[�v���X�g
            customRateGroupList = new List<CustRateGroup>();

            // ���Ӑ�|���O���[�v�L�[���X�g�ikey = ���Ӑ�R�[�h�F�����敪�F���i���[�J�[�R�[�h�j
            ArrayList customRateGroupKeyList = new ArrayList();
            //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ----<<<<<
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();

            // ���Ӑ�|���O���[�v���
            ArrayList custRateGroupList;
            List<CustRateGroup> _custRateGroupList = new List<CustRateGroup>();
            if (customerCode != 0)
            {
                CustRateGroupAcs custRateGroupAcs = new CustRateGroupAcs();
                custRateGroupAcs.Search(out custRateGroupList, enterpriseCode, customerCode, 
                    ConstantManagement.LogicalMode.GetData0);
                if ((custRateGroupList != null) && (custRateGroupList.Count != 0))
                {
                    _custRateGroupList = new List<CustRateGroup>(
                        (CustRateGroup[])custRateGroupList.ToArray(typeof(CustRateGroup)));
                }
            }

            // ����P���[�������R�[�h(���Ӑ�}�X�^���擾)
            CustomerInfoAcs customerDB = new CustomerInfoAcs();
            SupplierAcs supplierDB = new SupplierAcs();
            //-----DEL songg 2013/06/19 �\�[�X�`�F�b�N�m�F�����ꗗ��No.39�̑Ή� ---->>>>>
            //int salesUnPrcFrcProcCd = customerDB.GetSalesFractionProcCd(
            //    enterpriseCode,
            //    customerCode,
            //    CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd
            //);


            //// �������Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            //int salesCnsTaxFrcProcCd = customerDB.GetSalesFractionProcCd(
            //    enterpriseCode,
            //    customerCode,
            //    CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
            //);
            //-----DEL songg 2013/06/19 �\�[�X�`�F�b�N�m�F�����ꗗ��No.39�̑Ή� ----<<<<<
            //-----ADD songg 2013/06/19 �\�[�X�`�F�b�N�m�F�����ꗗ��No.39�̑Ή� ---->>>>>
            // ����P���[�������R�[�h
            int salesUnPrcFrcProcCd = 0;

            // �������Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = 0;

            if (customerCode != 0)
            {
                salesUnPrcFrcProcCd = customerDB.GetSalesFractionProcCd(
                    enterpriseCode,
                    customerCode,
                    CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd
                    );


                // �������Œ[�������R�[�h(���Ӑ�}�X�^���擾)
                salesCnsTaxFrcProcCd = customerDB.GetSalesFractionProcCd(
                    enterpriseCode,
                    customerCode,
                    CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd
                    );
            }
            //-----ADD songg 2013/06/19 �\�[�X�`�F�b�N�m�F�����ꗗ��No.39�̑Ή� ---->>>>>

            // �d���P���[�������R�[�h�f�B�N�V���i��
            Dictionary<int, int> stockUnPrcFrcProcCdDic = new Dictionary<int, int>();

            // �d������Œ[�������R�[�h�f�B�N�V���i��
            Dictionary<int, int> stockCnsTaxFrcProcCdDic = new Dictionary<int, int>();

            // �d���P���[�������R�[�h
            int stockUnPrcFrcProcCd = 0;

            // �d������Œ[�������R�[�h
            int stockCnsTaxFrcProcCd = 0;

            // �ŗ��ݒ���擾
            TaxRateSet taxRateSet = GetTaxRateSet(enterpriseCode);

            // �ŗ����擾
            double taxRateOfNow = GetTaxRate(taxRateSet, DateTime.Now);


            // ���Ӑ���
            CustomerInfo customerInfo = new CustomerInfo();
            // customerDB.ReadDBData(enterpriseCode, customerCode, out customerInfo); //-----DEL songg 2013/06/19 �\�[�X�`�F�b�N�m�F�����ꗗ��No.39�̑Ή�

            //-----ADD songg 2013/06/19 �\�[�X�`�F�b�N�m�F�����ꗗ��No.39�̑Ή� ---->>>>>
            CustomerInfo claimInfo = new CustomerInfo();
            if (customerCode != 0)
            {
                // ���Ӑ���擾
                customerDB.ReadDBData(enterpriseCode, customerCode, out customerInfo);
                _mngSectionCode = customerInfo.MngSectionCode; // ADD huangt 2013/07/24 Redmine#39039 ���i���� �g�p���鋒�_�R�[�h�̏C��

                // ��������擾
                if (customerCode == customerInfo.ClaimCode)
                {
                    claimInfo = customerInfo;
                }
                else
                {
                    customerDB.ReadDBData(enterpriseCode, customerInfo.ClaimCode, out claimInfo);
                }

            }
            //-----ADD songg 2013/06/19 �\�[�X�`�F�b�N�m�F�����ꗗ��No.39�̑Ή� ----<<<<<
            // ADD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "goodsUnitDataList���[�v�����@�J�n�@�����F" + goodsUnitDataList.Count.ToString() + " ���[�v�������ďo�����\�b�h�FGetCustRateGroup");
            // ADD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            foreach (GoodsUnitData tempGoodsUnitData in goodsUnitDataList)
            {
                UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

                unitPriceCalcParam.BLGoodsCode           = tempGoodsUnitData.BLGoodsCode;    // BL�R�[�h��������.BL�R�[�h                 // BL�R�[�h    																																																																																															
                unitPriceCalcParam.BLGroupCode           = tempGoodsUnitData.BLGroupCode;    // BL�R�[�h��������.BL�O���[�v�R�[�h         // BL�O���[�v�R�[�h    																																																																																															
                unitPriceCalcParam.CountFl               = 0;                                // BL�R�[�h��������.����                     // ����    																																																																																															
                unitPriceCalcParam.CustomerCode          = customerCode;                     // WebSync.���Ӑ�R�[�h                      // ���Ӑ�R�[�h    																																																																																															
                //unitPriceCalcParam.CustRateGrpCode       = this.GetCustRateGroupCode(ref _custRateGroupList, tempGoodsUnitData.GoodsMakerCd);      //MAHNB01012AB.GetCustRateGroupCode(BL�R�[�h��������.���[�J�[�R�[�h)  // ���Ӑ�|���O���[�v�R�[�h //-----DEL songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή�
                //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ---->>>>>
                // ���Ӑ�|���O���[�v�f�[�^�擾
                CustRateGroup tempCustRateGroup = this.GetCustRateGroup(ref _custRateGroupList, tempGoodsUnitData.GoodsMakerCd);
                if (null == tempCustRateGroup)
                {
                    // ���Ӑ�|���O���[�v�R�[�h
                    unitPriceCalcParam.CustRateGrpCode = -1;      
                }
                else
                {
                    // ���Ӑ�|���O���[�v�R�[�h
                    unitPriceCalcParam.CustRateGrpCode = tempCustRateGroup.CustRateGrpCode;
                    // ���Ӑ�R�[�h  :  �����敪 : ���i���[�J�[�R�[�h

                    string key = tempCustRateGroup.CustomerCode.ToString() + ":" + 
                        tempCustRateGroup.PureCode.ToString() + ":" + 
                        tempCustRateGroup.GoodsMakerCd.ToString();
                    if(!customRateGroupKeyList.Contains(key))
                    {
                        customRateGroupKeyList.Add(key);

                        // �Y�����Ӑ�|���O���[�v�f�[�^�ǉ�
                        customRateGroupList.Add(tempCustRateGroup);
                    }
                }

                //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ----<<<<<
                unitPriceCalcParam.GoodsMakerCd          = tempGoodsUnitData.GoodsMakerCd;   //BL�R�[�h��������.���[�J�[�R�[�h           // ���[�J�[�R�[�h    																																																																																															
                unitPriceCalcParam.GoodsNo               = tempGoodsUnitData.GoodsNo;        //BL�R�[�h��������.�i��                     // �i��    																																																																																															
                unitPriceCalcParam.GoodsRateGrpCode      = tempGoodsUnitData.GoodsRateGrpCode;//BL�R�[�h��������.���i�|���O���[�v�R�[�h   // ���i�|���O���[�v�R�[�h    																																																																																															
                unitPriceCalcParam.GoodsRateRank         = tempGoodsUnitData.GoodsRateRank;                    // BL�R�[�h��������.���i�|�������N           // ���i�|�������N    																																																																																															
                unitPriceCalcParam.PriceApplyDate        = DateTime.Today;                      //�V�X�e�����t                            // �K�p��    																																																																																															
                unitPriceCalcParam.SalesCnsTaxFrcProcCd  = salesCnsTaxFrcProcCd;                     // �������Œ[�������R�[�h    																																																																																															
                unitPriceCalcParam.SalesUnPrcFrcProcCd   = salesUnPrcFrcProcCd;                      // ����P���[�������R�[�h    																																																																																															
                //unitPriceCalcParam.SectionCode           = sectionCode;                              //WebSync.���_�R�[�h                        // ���_�R�[�h  //DEL 2013/07/18  wangl2 FOR #38511
                unitPriceCalcParam.SectionCode           = customerInfo.MngSectionCode;                         // ���_�R�[�h  //ADD 2013/07/18  wangl2 FOR #38511
				
				if (stockCnsTaxFrcProcCdDic.ContainsKey(tempGoodsUnitData.SupplierCd))
                {
                    stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCdDic[tempGoodsUnitData.SupplierCd];   // �d������Œ[�������R�[�h(�f�B�N�V���i�����d����}�X�^����擾)
                }
                else
                {
                    stockCnsTaxFrcProcCd = supplierDB.GetStockFractionProcCd(
                        enterpriseCode,
                        tempGoodsUnitData.SupplierCd,
                        SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd
                    );
                    stockCnsTaxFrcProcCdDic.Add(tempGoodsUnitData.SupplierCd, stockCnsTaxFrcProcCd);
                }
                unitPriceCalcParam.StockCnsTaxFrcProcCd  = stockCnsTaxFrcProcCd;                     // �d������Œ[�������R�[�h   
 																																																																																															
                if (stockUnPrcFrcProcCdDic.ContainsKey(tempGoodsUnitData.SupplierCd))
                {
                    stockUnPrcFrcProcCd = stockUnPrcFrcProcCdDic[tempGoodsUnitData.SupplierCd];     // �d���P���[�������R�[�h(�f�B�N�V���i�����d����}�X�^����擾)
                }
                else
                {
                    stockUnPrcFrcProcCd = supplierDB.GetStockFractionProcCd(
                        enterpriseCode,
                        tempGoodsUnitData.SupplierCd,
                        SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd
                    );
                    stockUnPrcFrcProcCdDic.Add(tempGoodsUnitData.SupplierCd, stockUnPrcFrcProcCd);
                }
                unitPriceCalcParam.StockUnPrcFrcProcCd   = stockUnPrcFrcProcCd;                      // �d���P���[�������R�[�h    
																																																																																															
                unitPriceCalcParam.SupplierCd            = tempGoodsUnitData.SupplierCd;                 // BL�R�[�h�������ʂ��                      // �d����R�[�h    																																																																																															
                unitPriceCalcParam.TaxationDivCd         = tempGoodsUnitData.TaxationDivCd;              // BL�R�[�h�������ʂ��                      // �ېŋ敪    																																																																																																																																																																																												
                unitPriceCalcParam.TaxRate               = taxRateOfNow;                   // �ŗ�    																																																																																															
                unitPriceCalcParam.TotalAmountDispWayCd  = 0;// �Œ�                                     // ���z�\�����@�敪    																																																																																															
                unitPriceCalcParam.TtlAmntDspRateDivCd   = 0; //�Œ�                                     // ���z�\���|���K�p�敪 0:(�ō����z�~�|��) 1:(�Ŕ����z�~�|��)�������ł����ߍ��Z(����ŎZ�o������ł̒[������������)    																																																																																															
                //unitPriceCalcParam.ConsTaxLayMethod = customerInfo.ConsTaxLayMethod; //���Ӑ���.ConsTaxLayMethod               // ����œ]�ŕ���    ���Ӑ���͓��Ӑ�R�[�h���擾 //-----DEL songg 2013/06/19 �\�[�X�`�F�b�N�m�F�����ꗗ��No.39�̑Ή�
                //-----ADD songg 2013/06/19 �\�[�X�`�F�b�N�m�F�����ꗗ��No.39�̑Ή� ---->>>>>
                // ����œ]�ŕ���
                if(customerCode == 0)
                {
                    // ����Őݒ�̏���œ]�ŕ���
                    unitPriceCalcParam.ConsTaxLayMethod = taxRateSet.ConsTaxLayMethod;
                }
                else
                {
                    // ������̏���œ]�ŕ���
                    unitPriceCalcParam.ConsTaxLayMethod = (claimInfo.CustCTaXLayRefCd == 0) ? taxRateSet.ConsTaxLayMethod : claimInfo.ConsTaxLayMethod;

                }
                //-----ADD songg 2013/06/19 �\�[�X�`�F�b�N�m�F�����ꗗ��No.39�̑Ή� ----<<<<<

                unitPriceCalcParamList.Add(unitPriceCalcParam);
            }
            // ADD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "goodsUnitDataList���[�v�����@�I��");
            // ADD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // �P���Z�o�N���X�𗘗p���܂��B
            // DCKHN01060CA.CalculateSalesRelevanceUnitPrice���Q�Ƃ���
            UnitPriceCalculation unitPriceCalculation = new UnitPriceCalculation();
            // ADD 2013/07/24 �g�� Redmine#39055 --------------->>>>>>>>>>>>>>>>>>>>>>
            // ���ׂĎd�����z�����敪���擾
            string msg = string.Empty;
            int status = SearchInitial_StockProcMoneyProc(enterpriseCode, out msg, out allStockProcMoneyList);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� �d�����z�����敪���擾 status�F" + status.ToString());
                allStockProcMoneyList = null;
            }
            List<StockProcMoney> stockProcMoneyList = null;
            if (allStockProcMoneyList != null)
            {
                stockProcMoneyList = new List<StockProcMoney>((StockProcMoney[])allStockProcMoneyList.ToArray(typeof(StockProcMoney)));
                unitPriceCalculation.CacheStockProcMoneyList(stockProcMoneyList);
            }
            // ADD 2013/07/24 �g�� Redmine#39055 ---------------<<<<<<<<<<<<<<<<<<<<<<

            // ADD 2013/07/31 yugami Redmine#39386 ----------------------------->>>>>
            // ���Џ��擾
            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CompanyInf companyInf;
            status = GetCompanyInf(out companyInf, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && companyInf != null)
            {
                unitPriceCalculation.RatePriorityDiv = companyInf.RatePriorityDiv;
            }
            // ADD 2013/07/31 yugami Redmine#39386 -----------------------------<<<<<
            
            unitPriceCalculation.CalculateSalesRelevanceUnitPriceForTablet(unitPriceCalcParamList, 
                goodsUnitDataList, out unitPriceCalcRetList, out rateList);


            // �P���v�Z���Ă���A�P���ݒ肷��
            SetUnitPriceInfo(ref partsInfoDB, unitPriceCalcRetList);

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
        }

        /// <summary>
        /// �P���ݒ�
        /// </summary>
        /// <param name="partsInfoDB">partsInfoDB</param>
        /// <param name="lstUnitPrice">�P�����X�g</param>
        private void SetUnitPriceInfo(ref PartsInfoDataSet partsInfoDB, List<UnitPriceCalcRet> lstUnitPrice)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "SetUnitPriceInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int cnt = lstUnitPrice.Count;
            for (int i = 0; i < cnt; i++)
            {
                UnitPriceCalcRet unitPriceInfo = lstUnitPrice[i];
                PartsInfoDataSet.UsrGoodsInfoRow row = partsInfoDB.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(unitPriceInfo.GoodsMakerCd, unitPriceInfo.GoodsNo);
                if (row != null)
                {
                    switch (unitPriceInfo.UnitPriceKind)
                    {
                        case UnitPriceCalculation.ctUnitPriceKind_ListPrice: // �艿
                            row.PriceTaxExc = unitPriceInfo.UnitPriceTaxExcFl;
                            row.PriceTaxInc = unitPriceInfo.UnitPriceTaxIncFl; // ���z�\���p
                            row.RateDivLPrice = unitPriceInfo.RateSettingDivide; // �|���ݒ�敪(�艿) 

                            break;
                        case UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice: // ����P��
                            row.SalesUnitPriceTaxExc = unitPriceInfo.UnitPriceTaxExcFl;
                            row.SalesUnitPriceTaxInc = unitPriceInfo.UnitPriceTaxIncFl; // ���z�\���p
                            row.RateDivSalUnPrc = unitPriceInfo.RateSettingDivide; // �|���ݒ�敪�i����P���j 
                            break;
                        case UnitPriceCalculation.ctUnitPriceKind_UnitCost: // �����P��
                            row.UnitCostTaxExc = unitPriceInfo.UnitPriceTaxExcFl;
                            row.UnitCostTaxInc = unitPriceInfo.UnitPriceTaxIncFl; // ���z�\���p
                            row.RateDivUnCst = unitPriceInfo.RateSettingDivide; // �|���ݒ�敪�i�����P���j  
                            break;
                    }
                }
            }

            // �������ݒ莞�u�艿���g�p����v�ꍇ
            if (partsInfoDB.UnPrcNonSettingDiv == 1)
            {
                foreach (PartsInfoDataSet.UsrGoodsInfoRow row in partsInfoDB.UsrGoodsInfo)
                {
                    // �������Z�b�g����Ȃ������ꍇ
                    if (string.IsNullOrEmpty(row.RateDivSalUnPrc))
                    {
                        row.SalesUnitPriceTaxExc = row.PriceTaxExc; // �Ŕ����P��
                        row.SalesUnitPriceTaxInc = row.PriceTaxInc; // �ō��ݒP��
                    }
                }
            }

            partsInfoDB.UsrGoodsInfo.AcceptChanges();
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
        }
        #endregion �� �P���v�Z

        #region �� �}�X�^���փf�[�^����
        /// <summary>
        /// �}�X�^���փf�[�^����(�d����}�X�^�A�d�����z�����敪�}�X�^�A�L�����y�[���Ǘ��}�X�^�ABL�O���[�v�}�X�^)
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="pmtPartsSearchWorkList">���i�������ʃ��X�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetMastDataToScmDBDataList(string enterpriseCode, 
            string sectionCode, 
            string businessSessionId, 
            string pmTabSearchGuid, 
            ref CustomSerializeArrayList pmtPartsSearchWorkList, 
            List<GoodsUnitData> goodsUnitDataList, 
            out string message,
            int customerCode)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "GetMastDataToScmDBDataList";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            // ����������
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            message = string.Empty;

            // �f�[�^�`�F�b�N
            if((null == goodsUnitDataList) || (goodsUnitDataList.Count == 0))
            {
                // UPD 2013/08/02 #Redmine39451 ���x���P6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region ���\�[�X
                //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                //EasyLogger.Write(CLASS_NAME, methodName, "goodsUnitDataList null or Count=0");
                //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                #endregion
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I���@goodsUnitDataList null or Count=0");
                // UPD 2013/08/02 #Redmine39451 ���x���P6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            message = "";

            #region �d����f�[�^����
            // �d����f�[�^����
            List<PmtSupplierTmpWork> pmtSupplierTmpList = new List<PmtSupplierTmpWork>();
            // ADD 2013/08/05 Redmine#39451 ------------------------------>>>>>
            this._stockProcMoneyList = new List<StockProcMoney>();
            // ADD 2013/08/05 Redmine#39451 ------------------------------<<<<<
            status = SupplierMastDataOpr(enterpriseCode, 
                sectionCode, 
                businessSessionId, 
                pmTabSearchGuid, 
                out message, 
                goodsUnitDataList, 
                ref pmtSupplierTmpList);

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "�d����}�X�^ �f�[�^�쐬���� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) 
                && (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return status;
            }

            // �d������͑S�ă��X�g�ɒǉ�����
            pmtPartsSearchWorkList.Add(pmtSupplierTmpList);
            #endregion �d����f�[�^����

            #region �d�����z�����敪�}�X�^����
            List<PmtStkPrcMnyTmpWork> pmtStkPrcMnyTmpList = new List<PmtStkPrcMnyTmpWork>();
            // �d�����z�����敪�}�X�^
            status = StockProcMoneyDataOpr(enterpriseCode, 
                sectionCode, 
                businessSessionId, 
                pmTabSearchGuid,
                out message, 
                ref pmtStkPrcMnyTmpList);
            
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "�d�����z�����敪�}�X�^ �f�[�^�쐬���� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return status;
            }

            // �d�����z�����敪�}�X�^���͑S�ă��X�g�ɒǉ�����
            pmtPartsSearchWorkList.Add(pmtStkPrcMnyTmpList);
            #endregion �d�����z�����敪�}�X�^����

            #region �L�����y�[������
            List<PmtCmpMngTmpWork> pmtCmpMngTmpList = new List<PmtCmpMngTmpWork>();
            // �L�����y�[������
            status = CompaignMngMastDataOpr(enterpriseCode, 
                sectionCode, 
                businessSessionId, 
                pmTabSearchGuid, 
                out message, 
                goodsUnitDataList, 
                ref pmtCmpMngTmpList);

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "�L�����y�[���}�X�^ �f�[�^�쐬���� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return status;
            }
            pmtPartsSearchWorkList.Add(pmtCmpMngTmpList);
            #endregion �L�����y�[������

            #region BL�O���[�v�f�[�^����
            List<PmtBLGroupUTmpWork> pmtBLGroupUTmpList = new List<PmtBLGroupUTmpWork>();
            // BL�O���[�v�f�[�^����
            status = BLGroupMastDataOpr(enterpriseCode, 
                sectionCode, 
                businessSessionId, 
                pmTabSearchGuid, 
                out message, 
                goodsUnitDataList, 
                ref pmtBLGroupUTmpList);

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "BL�O���[�v�}�X�^ �f�[�^�쐬���� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return status;
            }
            pmtPartsSearchWorkList.Add(pmtBLGroupUTmpList);
            #endregion BL�O���[�v�f�[�^����

            #region �W�����i�I��ݒ�}�X�^����
            List<PmtPriSelSetTmpWork> pmtPriSelSetDataList = new List<PmtPriSelSetTmpWork>();
            status = PmtPriSelSetDataOpr(enterpriseCode,
                sectionCode,
                businessSessionId,
                pmTabSearchGuid,
                out message,
                goodsUnitDataList,
                ref pmtPriSelSetDataList,
                customerCode);

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "�W�����i�I��ݒ�}�X�^ �f�[�^�쐬���� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return status;
            }

            pmtPartsSearchWorkList.Add(pmtPriSelSetDataList);

            #endregion �W�����i�I��ݒ�}�X�^����

            //-----ADD licb 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ---->>>>>  
  
            #region ���i�Ǘ����擾
            
            List<PmtGoodsMngTmpWork> pmtGoodsMngTmpList = new List<PmtGoodsMngTmpWork>();

            // UPD 2013/07/31 yugami Redmine#39451�Ή� ----------------------------------->>>>>
            //status = GetGoodsMngInfoProc(goodsUnitDataList,
            //    enterpriseCode,
            //    out pmtGoodsMngTmpList,
            //    out message,
            //    sectionCode,
            //    businessSessionId,
            //    pmTabSearchGuid);

            //�ۑ����i�Ǘ����
            status = WritePmtGoodsMngTmp(enterpriseCode,
                 sectionCode,
                 businessSessionId,
                 pmTabSearchGuid,
                 this._goodsMngList,
                 out pmtGoodsMngTmpList);
            // UPD 2013/07/31 yugami Redmine#39451�Ή� -----------------------------------<<<<<

            if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return status;
            }
             pmtPartsSearchWorkList.Add(pmtGoodsMngTmpList); 
            #endregion ���i�Ǘ����擾

            //-----ADD licb 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ----<<<<<  

            // ----- ADD huangt 2013/07/12 Redmine#38116 �L�����y�[�������D��ݒ�}�X�^�ǉ� ----- >>>>>
            List<PmtCmpPrcPrStWork> pmtCmpPrcPrStList = new List<PmtCmpPrcPrStWork>();
            status = SetCampaignPrcPrSt(enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid, ref pmtCmpPrcPrStList);
            EasyLogger.Write(CLASS_NAME, methodName, "�L�����y�[�������D��ݒ�}�X�^ �f�[�^�쐬���� status�F" + status.ToString());
            if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                return status;
            }
            pmtPartsSearchWorkList.Add(pmtCmpPrcPrStList);
            // ----- ADD huangt 2013/07/12 Redmine#38116 �L�����y�[�������D��ݒ�}�X�^�ǉ� ----- <<<<<

            // ----- ADD songg 2013/07/30 Redmine#39386 ���Џ��}�X�^�ǉ� ----- >>>>>
            List<PmtCompanyInfWork> pmtCompanyInfList = new List<PmtCompanyInfWork>();
            status = SetCompanyInf(enterpriseCode, businessSessionId, pmTabSearchGuid, ref pmtCompanyInfList);
            EasyLogger.Write(CLASS_NAME, methodName, "���Џ��}�X�^ �f�[�^�쐬���� status�F" + status.ToString());
            if ((status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                && (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL))
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                return status;
            }
            pmtPartsSearchWorkList.Add(pmtCompanyInfList);
            // ----- ADD songg 2013/07/30 Redmine#39386 ���Џ��}�X�^�ǉ� ----- <<<<<

            // �����������S��USER DB�̃f�[�^��SCM DB�ɕۑ��������s���܂�������
            IPmtPartsSearchDB iPmtPartsSearchDB = MediationPmtPartsSearchDB.GetPmtPartsSearchDB();
            object objList = pmtPartsSearchWorkList;
            status = iPmtPartsSearchDB.Write(ref objList);
            // UPD 2013/08/02 #Redmine39451 ���x���P6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region ���\�[�X
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            //EasyLogger.Write(CLASS_NAME, methodName, "�}�X�^�f�[�^�o�^�����@status�F" + status.ToString());
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            #endregion
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I���@�}�X�^�f�[�^�o�^�����@status�F" + status.ToString());
            // UPD 2013/08/02 #Redmine39451 ���x���P6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            return status;

        }

        //-----ADD licb 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ---->>>>>    

        #region ���i�Ǘ����擾

        // DEL 2013/07/31 Redmine#39451 ---------------------------------------------------->>>>>
        #region ���x���P�̂��ߍ폜
        /// <summary>
        /// ���i�Ǘ����擾
        /// </summary>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="pmtGoodsMngTmpList"> ���i�Ǘ����X�g</param>
        /// <param name="message"></param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        //private int GetGoodsMngInfoProc(List<GoodsUnitData> goodsUnitDataList, string enterpriseCode, out List<PmtGoodsMngTmpWork> pmtGoodsMngTmpList, out string message,
        //    string sectionCode, string businessSessionId, string pmTabSearchGuid)
        //{
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
        //    const string methodName = "GetGoodsMngInfoProc";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    message = string.Empty;
        //    List<GoodsMngWork> goodsMngList = new List<GoodsMngWork>();
        //    pmtGoodsMngTmpList = new List<PmtGoodsMngTmpWork>();
        //    GoodsMngWork retGoodsMng = null;
        //    //���i�Ǘ����擾�p�i�[�o�b�t�@(VALUE:���i�Ǘ����I�u�W�F�N�g)
        //    Dictionary<string, GoodsMngWork> goodsMngDic1;      //���_(�S�Ћ��ʊ܂�)�{���[�J�[�{�i��
        //    Dictionary<string, GoodsMngWork> goodsMngDic2;      //���_(�S�Ћ��ʊ܂�)�{�����ށ{���[�J�[�{�a�k
        //    Dictionary<string, GoodsMngWork> goodsMngDic3;      //���_(�S�Ћ��ʊ܂�)�{�����ށ{���[�J�[
        //    Dictionary<string, GoodsMngWork> goodsMngDic4;      //���_(�S�Ћ��ʊ܂�)�{���[�J�[
        //    Dictionary<string, GoodsMngWork> goodsMngDic = new Dictionary<string, GoodsMngWork>();
        //    string key = string.Empty;

        //    //�S�Ўw�苒�_�R�[�h
        //    string ctAllDefSectionCode = "00";

        //    status = this.SearchMngGoodsInfo(enterpriseCode, out goodsMngDic1, out goodsMngDic2, out goodsMngDic3, out goodsMngDic4);
        //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
        //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
        //        // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
        //        return status;
        //    }
        //    try
        //    {
        //        foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
        //        {
        //            //���_�{���[�J�[
        //            StringBuilder goodsMngDic4key = new StringBuilder();
        //            goodsMngDic4key.Append(goodsUnitData.SectionCode.Trim().PadLeft(2, '0'));
        //            goodsMngDic4key.Append(goodsUnitData.GoodsMakerCd.ToString("0000"));
        //            //�y���_�{���[�J�[�z�{�i��
        //            StringBuilder goodsMngDic1key = new StringBuilder();
        //            goodsMngDic1key.Append(goodsMngDic4key.ToString());
        //            goodsMngDic1key.Append(goodsUnitData.GoodsNo.Trim());

        //            //1.���_�{���[�J�[�{�i��
        //            if (goodsMngDic1.ContainsKey(goodsMngDic1key.ToString()))
        //            {
        //                retGoodsMng = goodsMngDic1[goodsMngDic1key.ToString()];
        //                key = retGoodsMng.EnterpriseCode.Trim() + retGoodsMng.SectionCode.Trim() + Convert.ToString(retGoodsMng.GoodsMGroup)
        //                    + Convert.ToString(retGoodsMng.GoodsMakerCd) + Convert.ToString(retGoodsMng.BLGoodsCode) + retGoodsMng.GoodsNo.Trim();
        //                if (!goodsMngDic.ContainsKey(key))
        //                {
        //                    goodsMngDic.Add(key, retGoodsMng);
        //                }
        //                continue;

        //            }

        //            //�S�Ё{���[�J�[
        //            StringBuilder goodsMngDic8key = new StringBuilder();
        //            goodsMngDic8key.Append(ctAllDefSectionCode);
        //            goodsMngDic8key.Append(goodsUnitData.GoodsMakerCd.ToString("0000"));
        //            //�y�S�Ё{���[�J�[�z�{�i��
        //            StringBuilder goodsMngDic5key = new StringBuilder();
        //            goodsMngDic5key.Append(goodsMngDic8key.ToString());
        //            goodsMngDic5key.Append(goodsUnitData.GoodsNo.Trim());

        //            //2.�S�Ё{���[�J�[�{�i��
        //            if (goodsMngDic1.ContainsKey(goodsMngDic5key.ToString()))
        //            {
        //                retGoodsMng = goodsMngDic1[goodsMngDic5key.ToString()];
        //                key = retGoodsMng.EnterpriseCode.Trim() + retGoodsMng.SectionCode.Trim() + Convert.ToString(retGoodsMng.GoodsMGroup)
        //                   + Convert.ToString(retGoodsMng.GoodsMakerCd) + Convert.ToString(retGoodsMng.BLGoodsCode) + retGoodsMng.GoodsNo.Trim();
        //                if (!goodsMngDic.ContainsKey(key))
        //                {
        //                    goodsMngDic.Add(key, retGoodsMng);
        //                }
        //                continue;
        //            }

        //            //�y���_�{���[�J�[�z�{������
        //            StringBuilder goodsMngDic3key = new StringBuilder();
        //            goodsMngDic3key.Append(goodsMngDic4key.ToString());
        //            goodsMngDic3key.Append(goodsUnitData.GoodsMGroup.ToString("0000"));
        //            //�y���_�{���[�J�[�{�����ށz�{�a�k
        //            StringBuilder goodsMngDic2key = new StringBuilder();
        //            goodsMngDic2key.Append(goodsMngDic3key.ToString());
        //            goodsMngDic2key.Append(goodsUnitData.BLGoodsCode.ToString("00000"));

        //            //3.���_�{�����ށ{���[�J�[�{�a�k
        //            if (goodsMngDic2.ContainsKey(goodsMngDic2key.ToString()))
        //            {
        //                retGoodsMng = goodsMngDic2[goodsMngDic2key.ToString()];
        //                key = retGoodsMng.EnterpriseCode.Trim() + retGoodsMng.SectionCode.Trim() + Convert.ToString(retGoodsMng.GoodsMGroup)
        //                   + Convert.ToString(retGoodsMng.GoodsMakerCd) + Convert.ToString(retGoodsMng.BLGoodsCode) + retGoodsMng.GoodsNo.Trim();
        //                if (!goodsMngDic.ContainsKey(key))
        //                {
        //                    goodsMngDic.Add(key, retGoodsMng);
        //                }
        //                continue;

        //            }

        //            //�y�S�Ё{���[�J�[�z�{������
        //            StringBuilder goodsMngDic7key = new StringBuilder();
        //            goodsMngDic7key.Append(goodsMngDic8key.ToString());
        //            goodsMngDic7key.Append(goodsUnitData.GoodsMGroup.ToString("0000"));
        //            //�y�S�Ё{���[�J�[�{�����ށz�{�a�k
        //            StringBuilder goodsMngDic6key = new StringBuilder();
        //            goodsMngDic6key.Append(goodsMngDic7key.ToString());
        //            goodsMngDic6key.Append(goodsUnitData.BLGoodsCode.ToString("00000"));

        //            //4.�S�Ё{�����ށ{���[�J�[�{�a�k
        //            if (goodsMngDic2.ContainsKey(goodsMngDic6key.ToString()))
        //            {
        //                retGoodsMng = goodsMngDic2[goodsMngDic6key.ToString()];
        //                key = retGoodsMng.EnterpriseCode.Trim() + retGoodsMng.SectionCode.Trim() + Convert.ToString(retGoodsMng.GoodsMGroup)
        //                   + Convert.ToString(retGoodsMng.GoodsMakerCd) + Convert.ToString(retGoodsMng.BLGoodsCode) + retGoodsMng.GoodsNo.Trim();
        //                if (!goodsMngDic.ContainsKey(key))
        //                {
        //                    goodsMngDic.Add(key, retGoodsMng);
        //                }
        //                continue;
        //            }

        //            //5.���_�{�����ށ{���[�J�[
        //            if (goodsMngDic3.ContainsKey(goodsMngDic3key.ToString()))
        //            {
        //                retGoodsMng = goodsMngDic3[goodsMngDic3key.ToString()];
        //                key = retGoodsMng.EnterpriseCode.Trim() + retGoodsMng.SectionCode.Trim() + Convert.ToString(retGoodsMng.GoodsMGroup)
        //                   + Convert.ToString(retGoodsMng.GoodsMakerCd) + Convert.ToString(retGoodsMng.BLGoodsCode) + retGoodsMng.GoodsNo.Trim();
        //                if (!goodsMngDic.ContainsKey(key))
        //                {
        //                    goodsMngDic.Add(key, retGoodsMng);
        //                }
        //                continue;
        //            }

        //            //6.�S�Ё{�����ށ{���[�J�[
        //            if (goodsMngDic3.ContainsKey(goodsMngDic7key.ToString()))
        //            {
        //                retGoodsMng = goodsMngDic3[goodsMngDic7key.ToString()];
        //                key = retGoodsMng.EnterpriseCode.Trim() + retGoodsMng.SectionCode.Trim() + Convert.ToString(retGoodsMng.GoodsMGroup)
        //                   + Convert.ToString(retGoodsMng.GoodsMakerCd) + Convert.ToString(retGoodsMng.BLGoodsCode) + retGoodsMng.GoodsNo.Trim();
        //                if (!goodsMngDic.ContainsKey(key))
        //                {
        //                    goodsMngDic.Add(key, retGoodsMng);
        //                }
        //                continue;
        //            }

        //            //7.���_�{���[�J�[
        //            if (goodsMngDic4.ContainsKey(goodsMngDic4key.ToString()))
        //            {
        //                retGoodsMng = goodsMngDic4[goodsMngDic4key.ToString()];
        //                key = retGoodsMng.EnterpriseCode.Trim() + retGoodsMng.SectionCode.Trim() + Convert.ToString(retGoodsMng.GoodsMGroup)
        //                   + Convert.ToString(retGoodsMng.GoodsMakerCd) + Convert.ToString(retGoodsMng.BLGoodsCode) + retGoodsMng.GoodsNo.Trim();
        //                if (!goodsMngDic.ContainsKey(key))
        //                {
        //                    goodsMngDic.Add(key, retGoodsMng);
        //                }
        //                continue;
        //            }

        //            //8.�S�Ё{���[�J�[
        //            if (goodsMngDic4.ContainsKey(goodsMngDic8key.ToString()))
        //            {
        //                retGoodsMng = goodsMngDic4[goodsMngDic8key.ToString()];
        //                key = retGoodsMng.EnterpriseCode.Trim() + retGoodsMng.SectionCode.Trim() + Convert.ToString(retGoodsMng.GoodsMGroup)
        //                   + Convert.ToString(retGoodsMng.GoodsMakerCd) + Convert.ToString(retGoodsMng.BLGoodsCode) + retGoodsMng.GoodsNo.Trim();
        //                if (!goodsMngDic.ContainsKey(key))
        //                {
        //                    goodsMngDic.Add(key, retGoodsMng);
        //                }
        //                continue;

        //            }

        //        }
        //        if (goodsMngDic != null && goodsMngDic.Count != 0)
        //        {

        //            foreach (GoodsMngWork goodsMng in goodsMngDic.Values)
        //            {
        //                goodsMngList.Add(goodsMng);

        //            }

        //            #region  �ۑ��L�����y�[���f�[�^
        //            //�ۑ����i�Ǘ����
        //            status = WritePmtGoodsMngTmp(enterpriseCode, 
        //                 sectionCode,
        //                 businessSessionId,
        //                 pmTabSearchGuid,
        //                 goodsMngList,
        //                 out pmtGoodsMngTmpList);
        //            #endregion
        //        }
        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }
        //    catch (Exception ex)
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //        message = "���i�Ǘ����擾�ŗ�O���������܂���[" + ex.Message + "]";
        //        message = ex.Message;

        //    }
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
        //    EasyLogger.Write(CLASS_NAME, methodName, "���i�Ǘ����擾�@status�F" + status.ToString());
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

        //    return status;

        //}

        #endregion // ���x���P�̂��ߍ폜
        // DEL 2013/07/31 Redmine#39451 ----------------------------------------------------<<<<<

        #region ���i�Ǘ����ۑ�����
        /// <summary>
        /// ���i�Ǘ����ۑ�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="goodsMngList">���i�Ǘ����f�[�^��񃊃X�g</param>
        /// <param name="pmtGoodsMngTmpList">SCMDB�̏��i�Ǘ����f�[�^��񃊃X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WritePmtGoodsMngTmp(string enterpriseCode,
                string sectionCode,
                string businessSessionId,
                string pmTabSearchGuid,
                List<GoodsMngWork> goodsMngList,
            out List<PmtGoodsMngTmpWork> pmtGoodsMngTmpList)
        {
            // ������
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            pmtGoodsMngTmpList = new List<PmtGoodsMngTmpWork>();

            for (int i = 0; i < goodsMngList.Count; i++)
            {
                GoodsMngWork goodsMng = goodsMngList[i] as GoodsMngWork;

                PmtGoodsMngTmpWork tempWork = new PmtGoodsMngTmpWork();

                tempWork.CreateDateTime = goodsMng.CreateDateTime;
                tempWork.UpdateDateTime = goodsMng.UpdateDateTime;
                tempWork.EnterpriseCode = goodsMng.EnterpriseCode;
                tempWork.FileHeaderGuid = goodsMng.FileHeaderGuid;
                tempWork.UpdEmployeeCode = goodsMng.UpdEmployeeCode;
                tempWork.UpdAssemblyId1 = goodsMng.UpdAssemblyId1;
                tempWork.UpdAssemblyId2 = goodsMng.UpdAssemblyId2;
                tempWork.LogicalDeleteCode = goodsMng.LogicalDeleteCode;
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.PmTabSearchRowNum = i + 1;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.SectionCode = goodsMng.SectionCode;
                tempWork.GoodsMGroup = goodsMng.GoodsMGroup;
                tempWork.GoodsMakerCd = goodsMng.GoodsMakerCd;
                tempWork.BLGoodsCode = goodsMng.BLGoodsCode;
                tempWork.GoodsNo = goodsMng.GoodsNo;
                tempWork.SupplierCd = goodsMng.SupplierCd;
                tempWork.SupplierLot = goodsMng.SupplierLot;

                pmtGoodsMngTmpList.Add(tempWork);
            }
            // ADD 2013/07/31 yugami Redmine#39451�Ή� ----------------------------------->>>>>
            if (pmtGoodsMngTmpList != null) status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            // ADD 2013/07/31 yugami Redmine#39451�Ή� -----------------------------------<<<<<
            return status;
        }
        #endregion 

        // DEL 2013/07/31 Redmine#39451 ---------------------------------------------------->>>>>
        #region ���x���P�̂��ߍ폜
        /// <summary>
        /// ���i�Ǘ����̌���
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsMngDic1"></param>
        /// <param name="goodsMngDic2"></param>
        /// <param name="goodsMngDic3"></param>
        /// <param name="goodsMngDic4"></param>
        /// <remarks>
        /// <br>Note       : ���i�Ǘ����̍Č���</br>
        /// <br>Programmer : zhangy3</br>
        /// <br>Date       : 2012/12/01</br>
        /// </remarks>
        //private int SearchMngGoodsInfo(string enterpriseCode, out Dictionary<string, GoodsMngWork> goodsMngDic1,
        //    out Dictionary<string, GoodsMngWork> goodsMngDic2, out Dictionary<string, GoodsMngWork> goodsMngDic3, out Dictionary<string, GoodsMngWork> goodsMngDic4)
        //{
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
        //    const string methodName = "SearchMngGoodsInfo";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    goodsMngDic1 = new Dictionary<string, GoodsMngWork>();
        //    goodsMngDic2 = new Dictionary<string, GoodsMngWork>();
        //    goodsMngDic3 = new Dictionary<string, GoodsMngWork>();
        //    goodsMngDic4 = new Dictionary<string, GoodsMngWork>();


        //    // ���i�Ǘ����
        //    List<GoodsMngWork> goodsMngList = new List<GoodsMngWork>();
        //    // ���[�U�[�o�^�����o����
        //    GoodsUCndtnWork goodsUCndtnWork = new GoodsUCndtnWork();
        //    goodsUCndtnWork.EnterpriseCode = enterpriseCode;
        //    // ���i�Ǘ����
        //    GoodsMngWork goodsMngWork = new GoodsMngWork();
        //    goodsMngWork.EnterpriseCode = enterpriseCode;
        //    CustomSerializeArrayList workList = new CustomSerializeArrayList();
        //    workList.Add(goodsMngWork);
        //    // �I�u�W�F�N�g�փZ�b�g
        //    object retObj;
        //    retObj = workList;
        //    try
        //    {
        //        //���i�\�������[�g�I�u�W�F�N�g(���[�U�[)�i�[�o�b�t�@
        //        IUsrJoinPartsSearchDB iGoodsURelationDataDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();
        //        // ����
        //        status = iGoodsURelationDataDB.Search(ref retObj, goodsUCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

        //        #region ���i�Ǘ����
        //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
        //            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
        //            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
        //            return status;
        //        }
        //        // ���i�Ǘ����
        //        workList = retObj as CustomSerializeArrayList;

        //        if (workList == null)
        //        {
        //            return status;
        //        }
        //        if (workList[0] is ArrayList)
        //        {

        //            foreach (ArrayList arList in workList)
        //            {
        //                if (arList != null && arList.Count > 0)
        //                {
        //                    if (arList[0] is GoodsMngWork)
        //                    {
        //                        goodsMngList = new List<GoodsMngWork>((GoodsMngWork[])arList.ToArray(typeof(GoodsMngWork)));
        //                        goodsMngDic1 = new Dictionary<string, GoodsMngWork>();     //���_�{���[�J�[�{�i��
        //                        goodsMngDic2 = new Dictionary<string, GoodsMngWork>();     //���_�{�����ށ{���[�J�[�{�a�k
        //                        goodsMngDic3 = new Dictionary<string, GoodsMngWork>();     //���_�{�����ށ{���[�J�[
        //                        goodsMngDic4 = new Dictionary<string, GoodsMngWork>();     //���_�{���[�J�[

        //                        for (int i = 0; i <= goodsMngList.Count - 1; i++)
        //                        {
        //                            goodsMngDic1Key = new StringBuilder();
        //                            goodsMngDic2Key = new StringBuilder();
        //                            goodsMngDic3Key = new StringBuilder();
        //                            goodsMngDic4Key = new StringBuilder();
        //                            goodsMngDic1Key.Length = 0;
        //                            goodsMngDic2Key.Length = 0;
        //                            goodsMngDic3Key.Length = 0;
        //                            goodsMngDic4Key.Length = 0;

        //                            goodsMngDic4Key.Append(goodsMngList[i].SectionCode.Trim().PadLeft(2, '0'));     //���_
        //                            goodsMngDic4Key.Append(goodsMngList[i].GoodsMakerCd.ToString("0000"));         //���[�J�[

        //                            if (goodsMngList[i].GoodsNo.Trim() != string.Empty)
        //                            {
        //                                goodsMngDic1Key.Append(goodsMngDic4Key.ToString());                         //���_�{���[�J�[
        //                                goodsMngDic1Key.Append(goodsMngList[i].GoodsNo.Trim());                    //�i��

        //                                //���_�{���[�J�[�{�i��
        //                                if (!goodsMngDic1.ContainsKey(goodsMngDic1Key.ToString()))
        //                                {
        //                                    goodsMngDic1.Add(goodsMngDic1Key.ToString(), goodsMngList[i]);
        //                                }
        //                            }
        //                            else
        //                            {
        //                                goodsMngDic3Key.Append(goodsMngDic4Key.ToString());                         //���_�{���[�J�[
        //                                goodsMngDic3Key.Append(goodsMngList[i].GoodsMGroup.ToString("0000"));      //������

        //                                goodsMngDic2Key.Append(goodsMngDic3Key.ToString());                         //���_�{���[�J�[�{������
        //                                goodsMngDic2Key.Append(goodsMngList[i].BLGoodsCode.ToString("00000"));     //�a�k

        //                                if (goodsMngList[i].BLGoodsCode != 0)
        //                                {
        //                                    //���_�{�����ށ{���[�J�[�{�a�k
        //                                    if (!goodsMngDic2.ContainsKey(goodsMngDic2Key.ToString()))
        //                                    {
        //                                        goodsMngDic2.Add(goodsMngDic2Key.ToString(), goodsMngList[i]);
        //                                    }
        //                                }
        //                                else if (goodsMngList[i].GoodsMGroup != 0)
        //                                {
        //                                    //���_�{�����ށ{���[�J�[
        //                                    if (!goodsMngDic3.ContainsKey(goodsMngDic3Key.ToString()))
        //                                    {
        //                                        goodsMngDic3.Add(goodsMngDic3Key.ToString(), goodsMngList[i]);
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    //���_�{���[�J�[
        //                                    if (!goodsMngDic4.ContainsKey(goodsMngDic4Key.ToString()))
        //                                    {
        //                                        goodsMngDic4.Add(goodsMngDic4Key.ToString(), goodsMngList[i]);
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        #endregion
        //    }
        //    catch
        //    {

        //    }
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
        //    EasyLogger.Write(CLASS_NAME, methodName, "���i�Ǘ���񌟍��@status�F" + status.ToString());
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

        //    return status;
        //}
        #endregion // ���x���P�̂��ߍ폜
        // DEL 2013/07/31 Redmine#39451 ----------------------------------------------------<<<<<

        #endregion

        //-----ADD licb 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ----<<<<<

        #region �W�����i�I��ݒ�}�X�^����
        /// <summary>
        /// �W�����i�I��ݒ�}�X�^��������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="goodsUnitDataList">���i�A����񃊃X�g</param>
        /// <param name="pmtPriSelSetTmpList">�W�����i�I��ݒ�}�X�^��񃊃X�g</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        private int PmtPriSelSetDataOpr(string enterpriseCode,
                string sectionCode,
                string businessSessionId,
                string pmTabSearchGuid,
                out string msg,
                List<GoodsUnitData> goodsUnitDataList,
                ref List<PmtPriSelSetTmpWork> pmtPriSelSetTmpList,
                int customerCode)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "PmtPriSelSetDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            // ������
            msg = "";

            // ���i�A���f�[�^���X�g�`�F�b�N����
            if (null == goodsUnitDataList || goodsUnitDataList.Count == 0)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� goodsUnitDataList null or Count=0");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msg = "";

            // �W�����i�I��ݒ�}�X�^�f�[�^���X�g
            ArrayList priSelSetTmpList = new ArrayList();

            // ��񃊃X�g
            status = SearchInitial_PmtPriSelSetDataProc(enterpriseCode, sectionCode, customerCode, 
                goodsUnitDataList, out msg, out priSelSetTmpList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �ۑ��W�����i�I��ݒ�}�X�^�f�[�^
                WritePmtPriSelSetDataOpr(enterpriseCode,
                    sectionCode,
                    businessSessionId,
                    pmTabSearchGuid,
                    priSelSetTmpList,
                    ref pmtPriSelSetTmpList);
            }

            
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            return status;
        }

        private int WritePmtPriSelSetDataOpr(string enterpriseCode,
                string sectionCode,
                string businessSessionId,
                string pmTabSearchGuid,
                ArrayList priSelSetTmpList,
            ref List<PmtPriSelSetTmpWork> pmtPriSelSetTmpList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WritePmtPriSelSetDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            // ������
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            for (int i = 0; i < priSelSetTmpList.Count; i++)
            {
                PriceSelectSet priceSelectSet = priSelSetTmpList[i] as PriceSelectSet;

                PmtPriSelSetTmpWork tempWork = new PmtPriSelSetTmpWork();

                tempWork.BLGoodsCode = priceSelectSet.BLGoodsCode;
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.CreateDateTime = priceSelectSet.CreateDateTime;
                tempWork.CustomerCode = priceSelectSet.CustomerCode;
                tempWork.CustRateGrpCode = priceSelectSet.CustRateGrpCode;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.EnterpriseCode = priceSelectSet.EnterpriseCode;
                tempWork.FileHeaderGuid = priceSelectSet.FileHeaderGuid;
                tempWork.GoodsMakerCd = priceSelectSet.GoodsMakerCd;
                tempWork.LogicalDeleteCode = priceSelectSet.LogicalDeleteCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                tempWork.PmTabSearchRowNum = i + 1;
                tempWork.PriceSelectDiv = priceSelectSet.PriceSelectDiv;
                tempWork.PriceSelectPtn = priceSelectSet.PriceSelectPtn;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.UpdAssemblyId1 = priceSelectSet.UpdAssemblyId1;
                tempWork.UpdAssemblyId2 = priceSelectSet.UpdAssemblyId2;
                tempWork.UpdateDateTime = priceSelectSet.UpdateDateTime;
                tempWork.UpdEmployeeCode = priceSelectSet.UpdEmployeeCode;



                pmtPriSelSetTmpList.Add(tempWork);
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// �W�����i�I��ݒ�}�X�^���擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <param name="priSelSetList">�W�����i�I��ݒ�}�X�^��񃊃X�g</param>
        /// <param name="goodsUnitDataList">���i�A����񃊃X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchInitial_PmtPriSelSetDataProc(string enterpriseCode, string sectionCode,
            int customerCode,
            List<GoodsUnitData> goodsUnitDataList,
            out string msg, 
            out ArrayList priSelSetList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "SearchInitial_PmtPriSelSetDataProc";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            priSelSetList = new ArrayList();

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            msg = "";

            // DEL 2013/08/02 #Redmine39451 ���x���P6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region ���\�[�X
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            //EasyLogger.Write(CLASS_NAME, methodName, "���Ӑ�}�X�^�@��������"
            //    + "�@��ƃR�[�h�F" + enterpriseCode
            //    + "�@���Ӑ�R�[�h�F" + customerCode.ToString()
            //);
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            #endregion
            // DEL 2013/08/02 #Redmine39451 ���x���P6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            // DEL 2013/07/31 �g�� ���Ӑ�Ǘ����_�Ή� ----------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            #region �擾�������Ӑ�����g�p���Ă��Ȃ������̂ŁA�폜
            // ���Ӑ���擾
            //CustomerInfo customerInfo = new CustomerInfo();
            //CustomerInfoAcs customerDB = new CustomerInfoAcs();
            //customerDB.ReadDBData(enterpriseCode, customerCode, out customerInfo);
            #endregion
            // DEL 2013/07/31 �g�� ���Ӑ�Ǘ����_�Ή� -----------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "����S�̐ݒ�}�X�^�@��������"
                + "�@��ƃR�[�h�F" + enterpriseCode
            );
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            // �\���敪�v���Z�X��1:����
            //-----DEL songg 2013/06/25 ��Q�� #37187�̑Ή� ����S�̐ݒ�}�X�^�擾 ---->>>>>
            //SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();          // ����S�̐ݒ�}�X�^
            //ArrayList allSalesTtlStList = new ArrayList();
            //salesTtlStAcs.Search(out allSalesTtlStList, enterpriseCode);
            //SalesTtlSt onlySalesTtlSt = null;
            //foreach(SalesTtlSt tempSalesTtlSt in allSalesTtlStList)
            //{
            //    if (tempSalesTtlSt.SectionCode.Trim() == sectionCode.Trim())
            //    {
            //        onlySalesTtlSt = tempSalesTtlSt;
            //        break;
            //    }
            //}
            //-----DEL songg 2013/06/25 ��Q�� #37187�̑Ή� ����S�̐ݒ�}�X�^�擾 ----<<<<<
            //-----ADD songg 2013/06/25 ��Q�� #37187�̑Ή� ����S�̐ݒ�}�X�^�擾 ---->>>>>
            SalesTtlSt onlySalesTtlSt = GetSalesTtlStInfo(enterpriseCode, sectionCode);
            //-----ADD songg 2013/06/25 ��Q�� #37187�̑Ή� ����S�̐ݒ�}�X�^�擾 ----<<<<<
            if ((onlySalesTtlSt == null) || (1 != onlySalesTtlSt.PriceSelectDispDiv))
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� SalesTtlSt null or SalesTtlSt.PriceSelectDispDiv��1");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "���Ӑ�|���O���[�v�}�X�^�@��������"
                + "�@��ƃR�[�h�F" + enterpriseCode
                + "�@���Ӑ�R�[�h�F" + customerCode.ToString()
            );
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            // ���Ӑ�|���O���[�v�擾
            ArrayList custRategrouList = new ArrayList();
            CustRateGroupAcs custRateGroupAcs = new CustRateGroupAcs();
            custRateGroupAcs.Search(out custRategrouList, enterpriseCode,customerCode, ConstantManagement.LogicalMode.GetData0);

            try
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "�W�����i�I��ݒ�}�X�^�@��������"
                    + "�@��ƃR�[�h�F" + enterpriseCode
                );
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                PriceSelectSetAcs priceSelectSetAcs = new PriceSelectSetAcs();
                // �S�ăf�[�^�擾
                ArrayList allPriSelSetList = new ArrayList();
                status = priceSelectSetAcs.Search(out allPriSelSetList, enterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && (ArrayList)allPriSelSetList != null)
                {
                    //0:Ұ�����ށEBL���ށE���Ӑ溰��
                    List<string> keyList0 = new List<string>();
                    //1:Ұ�����ށE���Ӑ溰��
                    List<string> keyList1 = new List<string>();
                    //2:BL���ށE���Ӑ溰��
                    List<string> keyList2 = new List<string>();
                    //3:Ұ�����ށEBL���ށE���Ӑ�|����ٰ��
                    List<string> keyList3 = new List<string>();
                    //4:Ұ�����ށE���Ӑ�|����ٰ��
                    List<string> keyList4 = new List<string>();
                    //5:BL���ށE���Ӑ�|����ٰ��
                    List<string> keyList5 = new List<string>();
                    //6:Ұ�����ށEBL����
                    List<string> keyList6 = new List<string>();
                    //7:Ұ������
                    List<string> keyList7 = new List<string>();
                    //8:BL����
                    List<string> keyList8 = new List<string>();


                    foreach (GoodsUnitData tempGoodsUnitData in goodsUnitDataList)
                    {
                        // �����i�i���[�J�[�R�[�h < 1000�j�̏ꍇ�A�W�����i�I��ݒ�}�X�^�͕K�v�Ȃ�
                        if (tempGoodsUnitData.GoodsMakerCd < 1000)
                        {
                            continue;
                        }

                        //0:Ұ�����ށEBL���ށE���Ӑ溰��
                        string key0 = tempGoodsUnitData.GoodsMakerCd.ToString() + ":"
                            + tempGoodsUnitData.BLGoodsCode.ToString() + ":"
                            + customerCode.ToString();
                        if (!keyList0.Contains(key0))
                        {
                            keyList0.Add(key0);
                        }

                        //1:Ұ�����ށE���Ӑ溰��
                        string key1 = tempGoodsUnitData.GoodsMakerCd.ToString() + ":"
                            + customerCode.ToString();
                        if (!keyList1.Contains(key1))
                        {
                            keyList1.Add(key1);
                        }

                        //2:BL���ށE���Ӑ溰��
                        string key2 = tempGoodsUnitData.BLGoodsCode.ToString() + ":"
                            + customerCode.ToString();
                        if (!keyList2.Contains(key2))
                        {
                            keyList2.Add(key2);
                        }

                        foreach(CustRateGroup tempCustRateGroup in custRategrouList)
                        {
                            //3:Ұ�����ށEBL���ށE���Ӑ�|����ٰ��
                            string key3 = tempGoodsUnitData.GoodsMakerCd.ToString() + ":"
                                + tempGoodsUnitData.BLGoodsCode.ToString() + ":"
                                + tempCustRateGroup.CustRateGrpCode.ToString();

                            if (!keyList3.Contains(key3))
                            {
                                keyList3.Add(key3);
                            }

                            //4:Ұ�����ށE���Ӑ�|����ٰ��
                            string key4 = tempGoodsUnitData.GoodsMakerCd.ToString() + ":"
                                 + tempCustRateGroup.CustRateGrpCode.ToString();
                            if (!keyList4.Contains(key4))
                            {
                                keyList4.Add(key4);
                            }

                            //5:BL���ށE���Ӑ�|����ٰ��
                            string key5 = tempGoodsUnitData.BLGoodsCode.ToString() + ":"
                                + tempCustRateGroup.CustRateGrpCode.ToString();
                            if (!keyList5.Contains(key5))
                            {
                                keyList5.Add(key5);
                            }
                        }
                            
                        
                        //6:Ұ�����ށEBL����
                        string key6 = tempGoodsUnitData.GoodsMakerCd.ToString() + ":"
                            + tempGoodsUnitData.BLGoodsCode.ToString();
                        if (!keyList6.Contains(key6))
                        {
                            keyList6.Add(key6);
                        }

                        //7:Ұ������
                        string key7 = tempGoodsUnitData.GoodsMakerCd.ToString();
                        if (!keyList7.Contains(key7))
                        {
                            keyList7.Add(key7);
                        }

                        //8:BL����
                        string key8 = tempGoodsUnitData.BLGoodsCode.ToString();
                        if (!keyList8.Contains(key8))
                        {
                            keyList8.Add(key8);
                        }
                    }

                    foreach (PriceSelectSet tempPriceSelectSet in allPriSelSetList)
                    {
                        //0:Ұ�����ށEBL���ށE���Ӑ溰��
                        string key0 = tempPriceSelectSet.GoodsMakerCd.ToString() + ":"
                            + tempPriceSelectSet.BLGoodsCode.ToString() + ":"
                            + tempPriceSelectSet.CustomerCode.ToString();


                        //1:Ұ�����ށE���Ӑ溰��
                        string key1 = tempPriceSelectSet.GoodsMakerCd.ToString() + ":"
                            + tempPriceSelectSet.CustomerCode.ToString();


                        //2:BL���ށE���Ӑ溰��
                        string key2 = tempPriceSelectSet.BLGoodsCode.ToString() + ":"
                            + tempPriceSelectSet.CustomerCode.ToString();


                        //3:Ұ�����ށEBL���ށE���Ӑ�|����ٰ��
                        string key3 = tempPriceSelectSet.GoodsMakerCd.ToString() + ":"
                            + tempPriceSelectSet.BLGoodsCode.ToString() + ":"
                            + tempPriceSelectSet.CustRateGrpCode.ToString();


                        //4:Ұ�����ށE���Ӑ�|����ٰ��
                        string key4 = tempPriceSelectSet.GoodsMakerCd.ToString() + ":"
                             + tempPriceSelectSet.CustRateGrpCode.ToString();


                        //5:BL���ށE���Ӑ�|����ٰ��
                        string key5 = tempPriceSelectSet.BLGoodsCode.ToString() + ":"
                            + tempPriceSelectSet.CustRateGrpCode.ToString();


                        //6:Ұ�����ށEBL����
                        string key6 = tempPriceSelectSet.GoodsMakerCd.ToString() + ":"
                            + tempPriceSelectSet.BLGoodsCode.ToString();

                        //7:Ұ������
                        string key7 = tempPriceSelectSet.GoodsMakerCd.ToString();


                        //8:BL����
                        string key8 = tempPriceSelectSet.BLGoodsCode.ToString();


                        switch (tempPriceSelectSet.PriceSelectPtn)
                        {
                            case 0:
                                if (keyList0.Contains(key0))
                                {
                                    // �l���Z�b�g
                                    priSelSetList.Add(tempPriceSelectSet);
                                }
                                break;
                            case 1:
                                if (keyList1.Contains(key1))
                                {
                                    // �l���Z�b�g
                                    priSelSetList.Add(tempPriceSelectSet);
                                }
                                break;
                            case 2:
                                if (keyList2.Contains(key2))
                                {
                                    // �l���Z�b�g
                                    priSelSetList.Add(tempPriceSelectSet);
                                }
                                break;
                            case 3:
                                if (keyList3.Contains(key3))
                                {
                                    // �l���Z�b�g
                                    priSelSetList.Add(tempPriceSelectSet);
                                }
                                break;
                            case 4:
                                if (keyList4.Contains(key4))
                                {
                                    // �l���Z�b�g
                                    priSelSetList.Add(tempPriceSelectSet);
                                }
                                break;
                            case 5:
                                if (keyList5.Contains(key5))
                                {
                                    // �l���Z�b�g
                                    priSelSetList.Add(tempPriceSelectSet);
                                }
                                break;
                            case 6:
                                if (keyList6.Contains(key6))
                                {
                                    // �l���Z�b�g
                                    priSelSetList.Add(tempPriceSelectSet);
                                }
                                break;
                            case 7:
                                if (keyList7.Contains(key7))
                                {
                                    // �l���Z�b�g
                                    priSelSetList.Add(tempPriceSelectSet);
                                }
                                break;
                            case 8:
                                if (keyList8.Contains(key8))
                                {
                                    // �l���Z�b�g
                                    priSelSetList.Add(tempPriceSelectSet);
                                }
                                break;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                msg = "�W�����i�I��ݒ�}�X�^���擾�ŗ�O���������܂���[" + ex.Message + "]";
                msg = ex.Message;

                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, msg);
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            }

            if ((priSelSetList != null) && (priSelSetList.Count > 0))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            return status;
        }
        #endregion �W�����i�I��ݒ�}�X�^����

        #region �L�����y�[������
        /// <summary>
        /// �L�����y�[���f�[�^�쐬����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="goodsUnitDataList">���i�A�����f�[�^���X�g</param>
        /// <param name="pmtCmpMngTmpList">�L�����y�[���Ǘ��f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private int CompaignMngMastDataOpr(string enterpriseCode, 
                string sectionCode, 
                string businessSessionId,
                string pmTabSearchGuid, 
                out string msg, 
            List<GoodsUnitData> goodsUnitDataList, 
            ref List<PmtCmpMngTmpWork> pmtCmpMngTmpList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "CompaignMngMastDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // UPD 2013/08/02 Redmine#39451 ���x���P9 --------------------------------------------------->>>>>
            //List<CampaignObjGoodsStWork> campaignMngList = new List<CampaignObjGoodsStWork>();
            List<CampaignObjGoodsStWork> campaignMngList;
            // UPD 2013/08/02 Redmine#39451 ���x���P9 ---------------------------------------------------<<<<<

            // �����L�����y�[���f�[�^
            status = SearchInitial_CompaignMngMastDataProc(enterpriseCode, sectionCode, out msg, goodsUnitDataList, out campaignMngList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �ۑ��L�����y�[���f�[�^
                WriteCompaignMngMastDataOpr(enterpriseCode, 
                    sectionCode, 
                    businessSessionId,
                    pmTabSearchGuid, 
                    campaignMngList, 
                    ref pmtCmpMngTmpList);
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// �L�����y�[���f�[�^�ۑ�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="campaignMngList">�L�����y�[���f�[�^��񃊃X�g</param>
        /// <param name="pmtCmpMngTmpList">USER DB�̃L�����y�[���f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteCompaignMngMastDataOpr(string enterpriseCode,
                string sectionCode,
                string businessSessionId,
                string pmTabSearchGuid, 
                List<CampaignObjGoodsStWork> campaignMngList, 
            ref List<PmtCmpMngTmpWork> pmtCmpMngTmpList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WriteCompaignMngMastDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            // ������
            //int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;       // DEL huangt 2013/06/24 ��Q�� #37128�̑Ή� �����񓚏���(����) �\�[�X���C�����ĉ�����
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;        // ADD huangt 2013/06/24 ��Q�� #37128�̑Ή� �����񓚏���(����) �\�[�X���C�����ĉ�����

            for (int i = 0; i < campaignMngList.Count; i++)
            {
                CampaignObjGoodsStWork campaignMng = campaignMngList[i] as CampaignObjGoodsStWork;

                PmtCmpMngTmpWork tempWork = new PmtCmpMngTmpWork();

                tempWork.BLGoodsCode = campaignMng.BLGoodsCode;
                tempWork.BLGroupCode = campaignMng.BLGroupCode;
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.CampaignCode = campaignMng.CampaignCode;
                tempWork.CampaignSettingKind = campaignMng.CampaignSettingKind; 
                tempWork.CreateDateTime = campaignMng.CreateDateTime;
                tempWork.CustomerCode = campaignMng.CustomerCode;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", "")); //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DiscountRate = campaignMng.DiscountRate;               
                tempWork.EnterpriseCode = campaignMng.EnterpriseCode;
                tempWork.FileHeaderGuid = campaignMng.FileHeaderGuid;
                tempWork.GoodsMakerCd = campaignMng.GoodsMakerCd;
                tempWork.GoodsMGroup = campaignMng.GoodsMGroup;
                tempWork.GoodsNo = campaignMng.GoodsNo;
                tempWork.LogicalDeleteCode = campaignMng.LogicalDeleteCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                tempWork.PmTabSearchRowNum = i + 1;
                tempWork.PriceEndDate = GetDate(campaignMng.PriceEndDate);
                tempWork.PriceFl = campaignMng.PriceFl;
                tempWork.PriceStartDate = GetDate(campaignMng.PriceStartDate); 
                tempWork.RateVal = campaignMng.RateVal;
                tempWork.SalesCode = campaignMng.SalesCode; 
                tempWork.SalesPriceSetDiv = campaignMng.SalesPriceSetDiv;
                tempWork.SalesTargetCount = campaignMng.SalesTargetCount;
                tempWork.SalesTargetMoney = campaignMng.SalesTargetMoney;
                tempWork.SalesTargetProfit = campaignMng.SalesTargetProfit;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.SectionCode = campaignMng.SectionCode;
                tempWork.UpdAssemblyId1 = campaignMng.UpdAssemblyId1;
                tempWork.UpdAssemblyId2 = campaignMng.UpdAssemblyId2;
                tempWork.UpdateDateTime = campaignMng.UpdateDateTime;
                tempWork.UpdEmployeeCode = campaignMng.UpdEmployeeCode;


                pmtCmpMngTmpList.Add(tempWork);
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// �L�����y�[���f�[�^��������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
        /// <param name="campaignMngList">�L�����y�[����񃊃X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchInitial_CompaignMngMastDataProc(string enterpriseCode, string sectionCode, out string msg, List<GoodsUnitData> goodsUnitDataList, out  List<CampaignObjGoodsStWork> campaignMngList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "SearchInitial_CompaignMngMastDataProc";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            msg = "";

            // �L�����y�[�����������ݒ�
            CampaignMngOrderWork paraWork = SetCompaignCond(enterpriseCode, sectionCode, goodsUnitDataList);


            ICampaignObjGoodsStDB iCampaignObjGoodsStDB = (ICampaignObjGoodsStDB)MediationCampaignObjGoodsStDB.GetCampaignObjGoodsStDB();

            // �����[�g�߂胊�X�g
            object campaignMngWorkList = null;

            // �L�����y�[���Ǘ��}�X�^����
            status = iCampaignObjGoodsStDB.Search(out campaignMngWorkList, paraWork.EnterpriseCode, 0, ConstantManagement.LogicalMode.GetData0, ref msg);

            // ���ʊi�[
            campaignMngList = new List<CampaignObjGoodsStWork>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && (ArrayList)campaignMngWorkList != null)
            {
                List<string> keyList1 = new List<string>();// 1�FҰ��+�i��
                List<string> keyList2 = new List<string>();// 2�FҰ��+BL����
                List<string> keyList3 = new List<string>();// 3�FҰ��+��ٰ��
                List<string> keyList4 = new List<string>();// 4�FҰ��
                List<string> keyList5 = new List<string>();// 5�FBL����
                // DEL 2013/07/26 �g�� Redmine#39203 �̔��敪�͉�ʂ���ύX�\�Ȃ̂ŁA�S���o�^����----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                // List<string> keyList6 = new List<string>();// 6�F�̔��敪
                // DEL 2013/07/26 �g�� Redmine#39203 -----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                foreach(GoodsUnitData tempGoodsUnitData in goodsUnitDataList)
                {
                    // 1�FҰ��+�i��
                    string key1 = tempGoodsUnitData.GoodsMakerCd.ToString() + ":" + tempGoodsUnitData.GoodsNo.Trim();
                    if (!keyList1.Contains(key1))
                    {
                        keyList1.Add(key1);
                    }

                    // 2�FҰ��+BL����
                    string key2 = tempGoodsUnitData.GoodsMakerCd.ToString() + ":" + tempGoodsUnitData.BLGoodsCode.ToString();
                    if(!keyList2.Contains(key2))
                    {
                        keyList2.Add(key2);
                    }

                    // 3�FҰ��+��ٰ��
                    string key3 = tempGoodsUnitData.GoodsMakerCd.ToString() + ":" + tempGoodsUnitData.BLGroupCode.ToString();
                    if (!keyList3.Contains(key3))
                    {
                        keyList3.Add(key3);
                    }

                    // 4�FҰ��
                    string key4 = tempGoodsUnitData.GoodsMakerCd.ToString();
                    if (!keyList4.Contains(key4))
                    {
                        keyList4.Add(key4);
                    }

                    // 5�FBL����
                    string key5 = tempGoodsUnitData.BLGoodsCode.ToString();
                    if (!keyList5.Contains(key5))
                    {
                        keyList5.Add(key5);
                    }

                    // DEL 2013/07/26 �g�� Redmine#39203 �̔��敪�͉�ʂ���ύX�\�Ȃ̂ŁA�S���o�^����----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    #region ���\�[�X
                    //// 6�F�̔��敪
                    //string key6 = tempGoodsUnitData.SalesCode.ToString();
                    //if (!keyList6.Contains(key6))
                    //{
                    //    keyList6.Add(key6);
                    //}
                    #endregion
                    // DEL 2013/07/26 �g�� Redmine#39203 -----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                }

                foreach (object obj in (ArrayList)campaignMngWorkList)
                {
                    if (obj is CampaignObjGoodsStWork)
                    {
                        CampaignObjGoodsStWork retWork = (obj as CampaignObjGoodsStWork);

                        // ADD 2013/07/26 �g�� Redmine#39203 �̔��敪�͉�ʂ���ύX�\�Ȃ̂ŁA�S���o�^����----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        // �����_�A���͑S�ЈȊO�͑ΏۊO
                        if (!(retWork.SectionCode.Trim().Equals(sectionCode.Trim()) || retWork.SectionCode.Trim().Equals("00"))) continue;
                        // ADD 2013/07/26 �g�� Redmine#39203 -----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                        // 1�FҰ��+�i��
                        string key1 = retWork.GoodsMakerCd.ToString() + ":" + retWork.GoodsNo.Trim();
                        // 2�FҰ��+BL����
                        string key2 = retWork.GoodsMakerCd.ToString() + ":" + retWork.BLGoodsCode.ToString();
                        // 3�FҰ��+��ٰ��
                        string key3 = retWork.GoodsMakerCd.ToString() + ":" + retWork.BLGroupCode.ToString();
                        // 4�FҰ��
                        string key4 = retWork.GoodsMakerCd.ToString();
                        // 5�FBL����
                        string key5 = retWork.BLGoodsCode.ToString();
                        // DEL 2013/07/26 �g�� Redmine#39203 �̔��敪�͉�ʂ���ύX�\�Ȃ̂ŁA�S���o�^����----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        //// 6�F�̔��敪
                        // string key6 = retWork.SalesCode.ToString();
                        // DEL 2013/07/26 �g�� Redmine#39203 -----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                        // �L�����y�[���ݒ���:1:Ұ��+�i��,2:Ұ��+BL,3:Ұ��+��ٰ��,4:Ұ��,5:BL����,6:�̔��敪
                        switch(retWork.CampaignSettingKind)
                        {
                            case 1:
                                if (keyList1.Contains(key1))
                                {
                                    // �l���Z�b�g
                                    campaignMngList.Add(retWork);
                                }
                                break;
                            case 2:
                                if (keyList2.Contains(key2))
                                {
                                    // �l���Z�b�g
                                    campaignMngList.Add(retWork);
                                }
                                break;
                            case 3:
                                if (keyList3.Contains(key3))
                                {
                                    // �l���Z�b�g
                                    campaignMngList.Add(retWork);
                                }
                                break;
                            case 4:
                                if (keyList4.Contains(key4))
                                {
                                    // �l���Z�b�g
                                    campaignMngList.Add(retWork);
                                }
                                break;
                            case 5:
                                if (keyList5.Contains(key5))
                                {
                                    // �l���Z�b�g
                                    campaignMngList.Add(retWork);
                                }
                                break;
                            // UPD 2013/07/26 �g�� Redmine#39203 �̔��敪�͉�ʂ���ύX�\�Ȃ̂ŁA�S���o�^����----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            #region ���\�[�X
                            //case 6:
                            //    if (keyList6.Contains(key6))
                            //    {
                            //        // �l���Z�b�g
                            //        campaignMngList.Add(retWork);
                            //    }
                            //    break;
                            #endregion
                            case 6:
                                // �l���Z�b�g
                                campaignMngList.Add(retWork);
                                break;
                            // UPD 2013/07/26 �g�� Redmine#39203 -----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        }
                    }
                }
            }

            if ((campaignMngList != null) && (campaignMngList.Count > 0))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }


            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// �L�����y�[�����������ݒ�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsUnitDataList">���i�A����񃊃X�g</param>
        /// <returns>�L�����y�[����������</returns>
        private CampaignMngOrderWork SetCompaignCond(string enterpriseCode, string sectionCode, List<GoodsUnitData> goodsUnitDataList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "SetCompaignCond";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            CampaignMngOrderWork campaignMngOrder = new CampaignMngOrderWork();
            campaignMngOrder.EnterpriseCode = enterpriseCode;      // ��ƃR�[�h
            campaignMngOrder.SectionCode = sectionCode;            // ���_�R�[�h

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "�L�����y�[���}�X�^�@��������"
                + "�@��ƃR�[�h�F" + enterpriseCode
                + "�@���_�R�[�h�F" + sectionCode
            );
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return campaignMngOrder;
        }
        #endregion

        #region �d�����z�����敪�ݒ菈��
        /// <summary>
        /// ���ׂĎd�����z�����敪�ݒ菈��
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="pmtStkPrcMnyTmpList">USER DB�̎d�����z�����敪���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private int StockProcMoneyDataOpr(string enterpriseCode,
            string sectionCode,
            string businessSessionId,
            string pmTabSearchGuid, 
            out string msg, 
            ref List<PmtStkPrcMnyTmpWork> pmtStkPrcMnyTmpList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "StockProcMoneyDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            // ������
            msg = "";

            // DEL 2013/07/24 �g�� Redmine#39055 --------------->>>>>>>>>>>>>>>>>>>>>>
            #region ���\�[�X
            // ArrayList allStockProcMoneyList;

            //int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            //// ���ׂĎd�����z�����敪���擾
            //status = SearchInitial_StockProcMoneyProc(enterpriseCode, out msg, out allStockProcMoneyList);

            //if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //{
            //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� �d�����z�����敪���擾 status�F" + status.ToString());
            //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            //    return status;
            //}
            #endregion
            // DEL 2013/07/24 �g�� Redmine#39055 ---------------<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/07/24 �g�� Redmine#39055 --------------->>>>>>>>>>>>>>>>>>>>>>
            // allStockProcMoneyList�̎擾�͒P���Z�o(CalculateUnitPrice)�̍ۂɎ��{ 
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            if (allStockProcMoneyList == null)
            {
                msg = "�P���Z�o(CalculateUnitPrice) �̎��_�ŁA�d�����z�����敪���̎擾�̎擾�Ɏ��s���Ă��܂��B";
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� " + msg + " status�F" + status.ToString());
                return status;
            }
            // ADD 2013/07/24 �g�� Redmine#39055 ---------------<<<<<<<<<<<<<<<<<<<<<<

            // �d�����z�����敪�ݒ�ݒ菈��
            status = WriteStockProcMoneyMastDataOpr(enterpriseCode,
                sectionCode,
                businessSessionId,
                pmTabSearchGuid,
                // UPD 2013/08/05 Redmine#39451 ------------------------------->>>>>
                //allStockProcMoneyList,
                this._stockProcMoneyList,
                // UPD 2013/08/05 Redmine#39451 -------------------------------<<<<<
                ref pmtStkPrcMnyTmpList);

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� �d�����z�����敪��񏑍��� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }


        // ADD 2013/08/05 Redmine#39451 ------------------------------------------->>>>>
        /// <summary>
        ///  �d�����z�����敪���X�g�쐬
        /// </summary>
        /// <param name="supplierWork"></param>
        /// <param name="allStockProcMoneyList"></param>
        private void GetStockProcMoneyList(SupplierWork supplierWork, ArrayList allStockProcMoneyList)
        {
            // DEL 2013/08/08 Redmine#39759 ------------------------------>>>>>
            //bool stockUnPrcFrcProcCdFlag = false;
            //bool stockMoneyFrcProcCdFlag = false;
            //bool stockCnsTaxFrcProcCdFlag = false;
            // DEL 2013/08/08 Redmine#39759 ------------------------------<<<<<

            if (allStockProcMoneyList == null || allStockProcMoneyList.Count == 0) return;

            for (int i = 0; i < allStockProcMoneyList.Count; i++)
            {

                StockProcMoney stockProcMoneyWork = allStockProcMoneyList[i] as StockProcMoney;

                // �d���P���[�������敪
                // UPD 2013/08/07 Redmine#39694 ------------------------------>>>>>
                //if (stockProcMoneyWork.FracProcMoneyDiv == (int)SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd &&
                if (stockProcMoneyWork.FracProcMoneyDiv == 2 &&
                // UPD 2013/08/07 Redmine#39694 ------------------------------<<<<<
                    stockProcMoneyWork.FractionProcCode == supplierWork.StockUnPrcFrcProcCd)
                {
                    if (!this._stockProcMoneyList.Contains(stockProcMoneyWork))
                    {
                        this._stockProcMoneyList.Add(stockProcMoneyWork);
                        // DEL 2013/08/08 Redmine#39759 ------------------------------>>>>>
                        //stockUnPrcFrcProcCdFlag = true;
                        // DEL 2013/08/08 Redmine#39759 ------------------------------<<<<<
                    }
                }
                // �d�����z�[�������敪
                // UPD 2013/08/07 Redmine#39694 ------------------------------>>>>>
                //if (stockProcMoneyWork.FracProcMoneyDiv == (int)SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd &&
                if (stockProcMoneyWork.FracProcMoneyDiv == 0 &&
                // UPD 2013/08/07 Redmine#39694 ------------------------------<<<<<
                    stockProcMoneyWork.FractionProcCode == supplierWork.StockMoneyFrcProcCd)
                {
                    if (!this._stockProcMoneyList.Contains(stockProcMoneyWork))
                    {
                        this._stockProcMoneyList.Add(stockProcMoneyWork);
                        // DEL 2013/08/08 Redmine#39759 ------------------------------>>>>>
                        //stockMoneyFrcProcCdFlag = true;
                        // DEL 2013/08/08 Redmine#39759 ------------------------------<<<<<
                    }
                }
                // �d������Œ[�������敪
                // UPD 2013/08/07 Redmine#39694 ------------------------------>>>>>
                //if (stockProcMoneyWork.FracProcMoneyDiv == (int)SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd &&
                if (stockProcMoneyWork.FracProcMoneyDiv == 1 &&
                // UPD 2013/08/07 Redmine#39694 ------------------------------<<<<<
                    stockProcMoneyWork.FractionProcCode == supplierWork.StockCnsTaxFrcProcCd)
                {
                    if (!this._stockProcMoneyList.Contains(stockProcMoneyWork))
                    {
                        this._stockProcMoneyList.Add(stockProcMoneyWork);
                        // DEL 2013/08/08 Redmine#39759 ------------------------------>>>>>
                        //stockCnsTaxFrcProcCdFlag = true;
                        // DEL 2013/08/08 Redmine#39759 ------------------------------<<<<<
                    }
                }
                // DEL 2013/08/08 Redmine#39759 ------------------------------>>>>>
                //if (stockUnPrcFrcProcCdFlag && stockMoneyFrcProcCdFlag && stockCnsTaxFrcProcCdFlag) break;
                // DEL 2013/08/08 Redmine#39759 ------------------------------<<<<<
            }
        }
        // ADD 2013/08/05 Redmine#39451 -------------------------------------------<<<<<

        /// <summary>
        /// ���ׂĎd�����z�����敪���擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="allStockProcMoneyList">���ׂĎd�����z�����敪��񃊃X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchInitial_StockProcMoneyProc(string enterpriseCode, out string msg, out ArrayList allStockProcMoneyList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "SearchInitial_StockProcMoneyProc";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            // ������
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            msg = "";
            allStockProcMoneyList = new ArrayList();

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "�d�����z�����敪�}�X�^�@��������"
                        + "�@��ƃR�[�h�F" + enterpriseCode
            );
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            StockProcMoneyAcs stockProcMoneyAcs = new StockProcMoneyAcs();
            status = stockProcMoneyAcs.Search(out allStockProcMoneyList, enterpriseCode);

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// �d�����z�����敪�ݒ�ݒ菈��
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="stockProcMoneyList">�d�����z�����敪�ݒ胊�X�g</param>
        /// <param name="pmtStkPrcMnyTmpList">USER DB�̎d�����z�����敪���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteStockProcMoneyMastDataOpr(string enterpriseCode,
            string sectionCode,
            string businessSessionId,
            string pmTabSearchGuid, 
            // UPD 2013/08/05 Redmine#39451 ------------------------->>>>>
            //ArrayList stockProcMoneyList,
            List<StockProcMoney> stockProcMoneyList,
            // UPD 2013/08/05 Redmine#39451 -------------------------<<<<<
            ref List<PmtStkPrcMnyTmpWork> pmtStkPrcMnyTmpList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WriteStockProcMoneyMastDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            // ������
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // UPD 2013/08/05 Redmine#39451
            for (int i = 0; i < stockProcMoneyList.Count; i++)
            {
                // UPD 2013/08/05 Redmine#39451 -------------------------------------->>>>>
                //StockProcMoney stockProcMoneyWork = stockProcMoneyList[i] as StockProcMoney;
                StockProcMoney stockProcMoneyWork = stockProcMoneyList[i];
                // UPD 2013/08/05 Redmine#39451 --------------------------------------<<<<<
                PmtStkPrcMnyTmpWork tempWork = new PmtStkPrcMnyTmpWork();
               
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.CreateDateTime = stockProcMoneyWork.CreateDateTime;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.FileHeaderGuid = stockProcMoneyWork.FileHeaderGuid;
                tempWork.FracProcMoneyDiv = stockProcMoneyWork.FracProcMoneyDiv;
                tempWork.FractionProcCd = stockProcMoneyWork.FractionProcCd;
                tempWork.FractionProcCode = stockProcMoneyWork.FractionProcCode;
                tempWork.FractionProcUnit = stockProcMoneyWork.FractionProcUnit;
                tempWork.LogicalDeleteCode = stockProcMoneyWork.LogicalDeleteCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                tempWork.PmTabSearchRowNum = i + 1;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.UpdAssemblyId1 = stockProcMoneyWork.UpdAssemblyId1;
                tempWork.UpdAssemblyId2 = stockProcMoneyWork.UpdAssemblyId2;
                tempWork.UpdateDateTime = stockProcMoneyWork.UpdateDateTime;
                tempWork.UpdEmployeeCode = stockProcMoneyWork.UpdEmployeeCode;
                tempWork.UpperLimitPrice = stockProcMoneyWork.UpperLimitPrice;

                pmtStkPrcMnyTmpList.Add(tempWork);
            }

            if (pmtStkPrcMnyTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }
        #endregion

        #region BL�O���[�v�f�[�^
        /// <summary>
        /// BL�O���[�v�f�[�^����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
        /// <param name="pmtBLGroupUTmpList">BL�O���[�v�f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private int BLGroupMastDataOpr(string enterpriseCode, 
                string sectionCode, 
                string businessSessionId,
                string pmTabSearchGuid, 
                out string msg, 
                List<GoodsUnitData> goodsUnitDataList, 
                ref List<PmtBLGroupUTmpWork> pmtBLGroupUTmpList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "BLGroupMastDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            // ������
            msg = "";

            // ���i�A���f�[�^���X�g�`�F�b�N����
            if (null == goodsUnitDataList || goodsUnitDataList.Count == 0)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� goodsUnitDataList null or Count=0");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msg = "";
            // ���ׂ�BL�O���[�v��񃊃X�g
            Dictionary<int, BLGroupU> allBLGroupWorkList;
            // �d�����񃊃X�g
            Dictionary<int, BLGroupU> blGroupWorkList;

            // ���ׂ�BL�O���[�v����
            status = SearchInitial_BLGroupProc(enterpriseCode, out msg, out allBLGroupWorkList);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� BL�O���[�v���� status�F" + status.ToString());
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return status;
            }
            else
            {
                // �O���[�v��񃊃X�g�擾
                status = GetBLGroupList(enterpriseCode, goodsUnitDataList, allBLGroupWorkList,
                            out blGroupWorkList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� �O���[�v��񃊃X�g�擾 status�F" + status.ToString());
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                    return status;
                }

                status = WriteBLGroupMastDataOpr(enterpriseCode, 
                    sectionCode, 
                    businessSessionId,
                    pmTabSearchGuid, 
                    blGroupWorkList, 
                    ref pmtBLGroupUTmpList);
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// �a�k�O���[�v���擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsUnitDataList">���i�A����񃊃X�g</param>
        /// <param name="allBLGroupWorkList">���ׂ�BL�O���[�v��񃊃X�g</param>
        /// <param name="blGroupWorkList">BL�O���[�v��񃊃X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetBLGroupList(string enterpriseCode, List<GoodsUnitData> goodsUnitDataList, Dictionary<int, BLGroupU> allBLGroupWorkList,
            out Dictionary<int, BLGroupU> blGroupWorkList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "GetBLGroupList";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            blGroupWorkList = new Dictionary<int, BLGroupU>();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            // if (allBLGroupWorkList == null || allBLGroupWorkList.Count == 0) return status;
            if (allBLGroupWorkList == null || allBLGroupWorkList.Count == 0)
            {
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� BLGroupWorkList null or Count=0");
                return status;
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            try
            {
                foreach (GoodsUnitData tempGoodsUnitData in goodsUnitDataList)
                {
                    if (allBLGroupWorkList.ContainsKey(tempGoodsUnitData.BLGroupCode))
                    {
                        BLGroupU blGroupU = null;

                        blGroupU = allBLGroupWorkList[tempGoodsUnitData.BLGroupCode] as BLGroupU;

                        if (!blGroupWorkList.ContainsKey(tempGoodsUnitData.BLGroupCode))
                        {
                            blGroupWorkList.Add(tempGoodsUnitData.BLGroupCode, blGroupU);
                        }
                    }
                }
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            // catch
            catch (Exception ex)
            {
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            }

            // �X�e�[�^�X�ݒ�
            if (blGroupWorkList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// BL�O���[�v�V�K����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="blGroupWorkList">�a�k�O���[�v��񃊃X�g</param>
        /// <param name="pmtBLGroupUTmpList">USER DB��BL�O���[�v���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteBLGroupMastDataOpr(string enterpriseCode,
                string sectionCode,
                string businessSessionId,
                string pmTabSearchGuid, 
                Dictionary<int, BLGroupU> blGroupWorkList, 
                ref List<PmtBLGroupUTmpWork> pmtBLGroupUTmpList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WriteBLGroupMastDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            int i = 0;
            foreach (BLGroupU blGroupU in blGroupWorkList.Values)
            {
                PmtBLGroupUTmpWork tempWork = new PmtBLGroupUTmpWork();

                tempWork.BLGroupCode = blGroupU.BLGroupCode;
                tempWork.BLGroupKanaName = blGroupU.BLGroupKanaName;
                tempWork.BLGroupName = blGroupU.BLGroupName;
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.CreateDateTime = blGroupU.CreateDateTime;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.FileHeaderGuid = blGroupU.FileHeaderGuid;
                tempWork.GoodsLGroup = blGroupU.GoodsLGroup;
                tempWork.GoodsMGroup = blGroupU.GoodsMGroup;
                tempWork.LogicalDeleteCode = blGroupU.LogicalDeleteCode;
                tempWork.OfferDataDiv = blGroupU.OfferDataDiv;
                tempWork.OfferDate = blGroupU.OfferDate;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                tempWork.PmTabSearchRowNum = ++i;
                tempWork.SalesCode = blGroupU.SalesCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.UpdAssemblyId1 = blGroupU.UpdAssemblyId1;
                tempWork.UpdAssemblyId2 = blGroupU.UpdAssemblyId2;
                tempWork.UpdateDateTime = blGroupU.UpdateDateTime;
                tempWork.UpdEmployeeCode = blGroupU.UpdEmployeeCode;

                pmtBLGroupUTmpList.Add(tempWork);
            }

            if (pmtBLGroupUTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// BL�O���[�v���擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <param name="allBLGroupWorkList">�S��</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchInitial_BLGroupProc(string enterpriseCode, out string msg, out Dictionary<int, BLGroupU> allBLGroupWorkList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "SearchInitial_BLGroupProc";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            allBLGroupWorkList = new Dictionary<int, BLGroupU>();

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            int status2 = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            msg = "";

            try
            {
                // �T�[�o�[���[�U�[�f�[�^
                IUsrJoinPartsSearchDB iGoodsURelationDataDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();

                #region BL�O���[�v���(���[�U�[)
                //---------------------------------------------------------------------
                // BL�O���[�v���(���[�U�[)
                //---------------------------------------------------------------------
                // ���[�U�[�o�^�����o����
                GoodsUCndtnWork goodsUCndtnWork = new GoodsUCndtnWork();
                goodsUCndtnWork.EnterpriseCode = enterpriseCode;

                // �擾�������������ʃf�[�^�N���X��ݒ�
                CustomSerializeArrayList workList;

                workList = new CustomSerializeArrayList();

                // BL�O���[�v���
                BLGroupUWork bLGroupUWork = new BLGroupUWork();
                bLGroupUWork.EnterpriseCode = enterpriseCode;
                workList.Add(bLGroupUWork);

                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "BL�O���[�v�}�X�^�@��������"
                    + "�@��ƃR�[�h�F" + enterpriseCode
                );
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

                // �I�u�W�F�N�g�^��

                object retObj;

                retObj = workList;

                // ����
                status = iGoodsURelationDataDB.Search(ref retObj, goodsUCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        {
                            workList = retObj as CustomSerializeArrayList;

                            // �擾�f�[�^��ϊ�
                            if (workList == null)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� BL�O���[�v���擾 status�F" + status.ToString());
                                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                                return status;
                            }

                            #region BL�O���[�v���
                            //---------------------------------------------------------------------
                            // BL�O���[�v���擾
                            //---------------------------------------------------------------------
                            List<BLGroupU> bLGroupUList;
                            status2 = GetBLGroupUWorkToUIdata(workList, out bLGroupUList);

                            if ((null != bLGroupUList) && (bLGroupUList.Count > 0))
                            {
                                foreach (BLGroupU tempBLGroupU in bLGroupUList)
                                {
                                    if (!allBLGroupWorkList.ContainsKey(tempBLGroupU.BLGroupCode))
                                    {
                                        allBLGroupWorkList.Add(tempBLGroupU.BLGroupCode, tempBLGroupU);
                                    }
                                }
                            }
                            #endregion

                            break;
                        }
                    default:
                        msg = "BL�O���[�v���̎擾�Ɏ��s���܂���";
                        break;
                }
                #endregion
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                msg = "BL�O���[�v���̎擾�ŗ�O���������܂���[" + ex.Message + "]";
                msg = ex.Message;
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, msg);
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString() + " " + msg);
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return 0;
        }

        /// <summary>
        /// CustomSerializeArrayList ���@BL�O���[�v�R�[�h�}�X�^(���[�U�[)���X�g�擾
        /// </summary>
        /// <param name="workList">WORK�^�f�[�^���X�g</param>
        /// <param name="uiList">���i�敪�ڍ�(���[�U�[�o�^)�N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetBLGroupUWorkToUIdata(CustomSerializeArrayList workList, out List<BLGroupU> uiList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "GetBLGroupUWorkToUIdata";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            uiList = null;

            try
            {
                //---------------------------------------------------------------------
                // �T�[�o�[�f�[�^�擾
                //---------------------------------------------------------------------
                if ((workList.Count > 0) && (workList[0] is ArrayList))
                {
                    foreach (ArrayList arList in workList)
                    {
                        if (arList != null && arList.Count > 0)
                        {
                            if (arList[0] is BLGroupUWork)
                            {
                                // �N���X�����o�[�R�s�[����
                                uiList = this.CopyToBLGroupUFromBLGroupUWork(arList);

                                status = (uiList.Count != 0) ? (int)ConstantManagement.DB_Status.ctDB_NORMAL : (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                // ��O�𔭐�������
                string message = "BL�O���[�v�R�[�h�}�X�^(���[�U�[)�擾�ŗ�O���������܂���[" + ex.Message + "]";
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, message);
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[����
        /// </summary>
        /// <param name="bLGroupUWorkList">BL�O���[�v�R�[�h�}�X�^(���[�U�[)���[�N�I�u�W�F�N�g���X�g</param>
        /// <returns>BL�O���[�v�R�[�h�}�X�^(���[�U�[)�I�u�W�F�N�g���X�g</returns>
        private List<BLGroupU> CopyToBLGroupUFromBLGroupUWork(ArrayList bLGroupUWorkList)
        {
            List<BLGroupU> bLGroupUList = null;

            if (bLGroupUWorkList != null)
            {
                bLGroupUList = new List<BLGroupU>();

                foreach (BLGroupUWork wrk in bLGroupUWorkList)
                {
                    bLGroupUList.Add(CopyToBLGroupUFromBLGroupUWork(wrk));
                }
            }
            return bLGroupUList;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[����
        /// </summary>
        /// <param name="bLGroupUWork">BL�O���[�v�R�[�h�}�X�^(���[�U�[)���[�N�I�u�W�F�N�g</param>
        /// <returns>BL�O���[�v�R�[�h�}�X�^(���[�U�[)�I�u�W�F�N�g</returns>
        private BLGroupU CopyToBLGroupUFromBLGroupUWork(BLGroupUWork bLGroupUWork)
        {
            BLGroupU bLGroupU = null;

            if (bLGroupUWork != null)
            {
                bLGroupU = new BLGroupU();

                bLGroupU.CreateDateTime = bLGroupUWork.CreateDateTime; // �쐬����
                bLGroupU.UpdateDateTime = bLGroupUWork.UpdateDateTime; // �X�V����
                bLGroupU.EnterpriseCode = bLGroupUWork.EnterpriseCode; // ��ƃR�[�h
                bLGroupU.FileHeaderGuid = bLGroupUWork.FileHeaderGuid; // GUID
                bLGroupU.UpdEmployeeCode = bLGroupUWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                bLGroupU.UpdAssemblyId1 = bLGroupUWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                bLGroupU.UpdAssemblyId2 = bLGroupUWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                bLGroupU.LogicalDeleteCode = bLGroupUWork.LogicalDeleteCode; // �_���폜�敪
                bLGroupU.GoodsLGroup = bLGroupUWork.GoodsLGroup; // ���i�啪�ރR�[�h
                bLGroupU.GoodsMGroup = bLGroupUWork.GoodsMGroup; // ���i�����ރR�[�h
                bLGroupU.BLGroupCode = bLGroupUWork.BLGroupCode; // BL�O���[�v�R�[�h
                bLGroupU.BLGroupName = bLGroupUWork.BLGroupName; // BL�O���[�v�R�[�h����
                bLGroupU.SalesCode = bLGroupUWork.SalesCode; // �̔��敪�R�[�h

                //-----ADD songg 2013/06/18 �\�[�X�`�F�b�N�m�F�����ꗗ��No.35�̑Ή� ---->>>>>
                bLGroupU.BLGroupKanaName = bLGroupUWork.BLGroupKanaName; // BL�O���[�v�R�[�h�J�i���� 
                bLGroupU.OfferDataDiv = bLGroupUWork.OfferDataDiv;
                bLGroupU.OfferDate = bLGroupUWork.OfferDate;
                //-----ADD songg 2013/06/18 �\�[�X�`�F�b�N�m�F�����ꗗ��No.35�̑Ή� ----<<<<<
                
            }

            return bLGroupU;
        }
        #endregion

        #region �d����}�X�^����
        /// <summary>
        /// �d����}�X�^�f�[�^�쐬����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="goodsUnitDataList">���i�A�����f�[�^���X�g</param>
        /// <param name="pmtSupplierTmpList">�d����}�X�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SupplierMastDataOpr(string enterpriseCode,
            string sectionCode,
            string businessSessionId,
            string pmTabSearchGuid, 
            out string msg, 
            List<GoodsUnitData> goodsUnitDataList, 
            ref List<PmtSupplierTmpWork> pmtSupplierTmpList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "SupplierMastDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            // ������
            msg = "";

            // ���i�A���f�[�^���X�g�`�F�b�N����
            if (null == goodsUnitDataList || goodsUnitDataList.Count == 0)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� goodsUnitDataList null or Coutn=0");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msg = "";
            // ���ׂĎd�����񃊃X�g
            // UPD 2013/08/02 Redmine#39451 ���x���P8 ------------------------------------------->>>>>
            //Dictionary<int, SupplierWork> allSupplierWorkList = new Dictionary<int, SupplierWork>();
            Dictionary<int, SupplierWork> allSupplierWorkList;
            // UPD 2013/08/02 Redmine#39451 ���x���P8 -------------------------------------------<<<<<
            // �d�����񃊃X�g
            Dictionary<int, SupplierWork> supplierWorkList;

            // ���ׂĎd���挟��
            status = SearchInitial_SupplierProc(enterpriseCode, out msg, out allSupplierWorkList);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� �d���挟�� status�F" + status.ToString() + " " + msg);
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return status;
            }
            else
            {
                // �d�����񃊃X�g�擾
                status = GetSupplierList(goodsUnitDataList, allSupplierWorkList,
                            out supplierWorkList);
                
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� �d�����񃊃X�g�擾 status�F" + status.ToString());
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                    return status;
                }

                // �d������ۑ����܂�
                status = WriteSupplierMastDataOpr(enterpriseCode,
                    sectionCode,
                    businessSessionId,
                    pmTabSearchGuid, 
                    supplierWorkList, 
                    ref pmtSupplierTmpList);
             }

             // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
             EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
             // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// ���ׂĎd�����񌟍�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="supplierWorkList">�d���惊�X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private int SearchInitial_SupplierProc(string enterpriseCode, out string msg, out Dictionary<int, SupplierWork> supplierWorkList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "SearchInitial_SupplierProc";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            supplierWorkList = new Dictionary<int, SupplierWork>();
            List<SupplierWork> tempSupplierWorkList = new List<SupplierWork>();

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            msg = "";

            try
            {
                IUsrJoinPartsSearchDB�@_iGoodsURelationDataDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();

                #region �d������(���[�U�[)
                //---------------------------------------------------------------------
                // �d������(���[�U�[)
                //---------------------------------------------------------------------
                // ���[�U�[�o�^�����o����
                GoodsUCndtnWork goodsUCndtnWork = new GoodsUCndtnWork();
                goodsUCndtnWork.EnterpriseCode = enterpriseCode;

                // �擾�������������ʃf�[�^�N���X��ݒ�
                CustomSerializeArrayList workList = new CustomSerializeArrayList();

                // �d������(���[�U�[)
                SupplierWork supplierWork = new SupplierWork();
                supplierWork.EnterpriseCode = enterpriseCode;

                workList.Add(supplierWork);
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, "�d����}�X�^�@��������"
                    + "�@��ƃR�[�h�F" + enterpriseCode
                );
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

                // �I�u�W�F�N�g�^��
                object retObj = workList;

                // �����[�g����f�[�^����
                status = _iGoodsURelationDataDB.Search(ref retObj, goodsUCndtnWork, 0, ConstantManagement.LogicalMode.GetData0);


                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        {
                            workList = retObj as CustomSerializeArrayList;

                            // �擾�f�[�^��ϊ�
                            if (workList == null)
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� �d�����񌟍� status�F" + status.ToString());
                                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                                return status;
                            }

                            #region �d������
                            //---------------------------------------------------------------------
                            // �d������
                            //---------------------------------------------------------------------
                            if (workList.Count > 0)
                            {
                                if ((workList.Count > 0) && (workList[0] is ArrayList))
                                {
                                    foreach (ArrayList arList in workList)
                                    {
                                        if (arList != null && arList.Count > 0)
                                        {
                                            if (arList[0] is SupplierWork)
                                            {
                                                tempSupplierWorkList = new List<SupplierWork>((SupplierWork[])arList.ToArray(typeof(SupplierWork)));
                                            }
                                        }
                                    }

                                    foreach (SupplierWork tempSupplierWork in tempSupplierWorkList)
                                    {
                                        if (!supplierWorkList.ContainsKey(tempSupplierWork.SupplierCd))
                                        {
                                            supplierWorkList.Add(tempSupplierWork.SupplierCd, tempSupplierWork);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� �d�����񌟍� status�F" + status.ToString());
                                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                                return status;
                            }
                            #endregion
                            break;
                        }
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        msg = "�d������(���[�U�[)�̎擾�Ɏ��s���܂���";
                        break;
                }
                #endregion
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                msg = "�d������(���[�U�[)�̎擾�ŗ�O���������܂���[" + ex.Message + "]";
                msg = ex.Message;
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, msg);
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString() + " " + msg);
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return 0;
        }

        /// <summary>
        /// ���i�A���f�[�^���X�g����A�d���惊�X�g�擾����
        /// </summary>
        /// <param name="goodsUnitDataList">���i�A���f�[�^���X�g</param>
        /// <param name="allSupplierWorkList">���ׂĎd���惊�X�g</param>
        /// <param name="supplierWorkList">�d���惊�X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetSupplierList(List<GoodsUnitData> goodsUnitDataList, Dictionary<int, SupplierWork> allSupplierWorkList,
            out Dictionary<int, SupplierWork> supplierWorkList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "GetSupplierList";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            supplierWorkList = new Dictionary<int, SupplierWork>();

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            if (allSupplierWorkList == null || allSupplierWorkList.Count == 0) return status;

            try
            {
                foreach (GoodsUnitData tempGoodsUnitData in goodsUnitDataList)
                {
                    if (allSupplierWorkList.ContainsKey(tempGoodsUnitData.SupplierCd))
                    {
                        SupplierWork supplierWork = null;

                        supplierWork = allSupplierWorkList[tempGoodsUnitData.SupplierCd] as SupplierWork;

                        if (!supplierWorkList.ContainsKey(tempGoodsUnitData.SupplierCd))
                        {
                            supplierWorkList.Add(tempGoodsUnitData.SupplierCd, supplierWork);
                            // ADD 2013/08/05 Redmine#39451 ------------------------------------>>>>>
                            // �d�����z�����敪����
                            if (allStockProcMoneyList != null && allStockProcMoneyList.Count != 0)
                            {
                                GetStockProcMoneyList(supplierWork, allStockProcMoneyList);
                            }
                            // ADD 2013/08/05 Redmine#39451 ------------------------------------<<<<<
                        }
                    }
                }
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            // catch 
            catch (Exception ex)
            {
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            }

            if (supplierWorkList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// �ۑ������d����f�[�^���X�g
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="supplierWorkList">�d�����񃊃X�g</param>
        /// <param name="pmtSupplierTmpList">USER DB�̎d����f�[�^���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteSupplierMastDataOpr(string enterpriseCode,
            string sectionCode,
            string businessSessionId,
            string pmTabSearchGuid, 
            Dictionary<int, SupplierWork> supplierWorkList, 
            ref List<PmtSupplierTmpWork> pmtSupplierTmpList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WriteSupplierMastDataOpr";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            int i = 0;
            foreach(SupplierWork supplierWork in supplierWorkList.Values)
            {
                PmtSupplierTmpWork tempWork = new PmtSupplierTmpWork();

                tempWork.BusinessSessionId = businessSessionId;
                tempWork.BusinessTypeCode = supplierWork.BusinessTypeCode;
                tempWork.CreateDateTime = supplierWork.CreateDateTime;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", "")); //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.FileHeaderGuid = supplierWork.FileHeaderGuid;
                tempWork.InpSectionCode = supplierWork.InpSectionCode;
                tempWork.LogicalDeleteCode = supplierWork.LogicalDeleteCode;
                tempWork.MngSectionCode = supplierWork.MngSectionCode;
                tempWork.NTimeCalcStDate = supplierWork.NTimeCalcStDate;
                tempWork.OrderHonorificTtl = supplierWork.OrderHonorificTtl;
                tempWork.PayeeCode = supplierWork.PayeeCode;
                tempWork.PaymentCond = supplierWork.PaymentCond;
                tempWork.PaymentDay = supplierWork.PaymentDay;
                tempWork.PaymentMonthCode = supplierWork.PaymentMonthCode;
                tempWork.PaymentMonthName = supplierWork.PaymentMonthName;
                tempWork.PaymentSectionCode = supplierWork.PaymentSectionCode;
                tempWork.PaymentSight = supplierWork.PaymentSight;
                tempWork.PaymentTotalDay = supplierWork.PaymentTotalDay;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                tempWork.PmTabSearchRowNum = ++i;
                tempWork.PureCode = supplierWork.PureCode;
                tempWork.SalesAreaCode = supplierWork.SalesAreaCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.StckTtlAmntDspWayRef = supplierWork.StckTtlAmntDspWayRef;
                tempWork.StockAgentCode = supplierWork.StockAgentCode;
                tempWork.StockCnsTaxFrcProcCd = supplierWork.StockCnsTaxFrcProcCd;
                tempWork.StockMoneyFrcProcCd = supplierWork.StockMoneyFrcProcCd;
                tempWork.StockUnPrcFrcProcCd = supplierWork.StockUnPrcFrcProcCd;
                tempWork.SuppCTaxationCd = supplierWork.SuppCTaxationCd;
                tempWork.SuppCTaxLayCd = supplierWork.SuppCTaxLayCd;
                tempWork.SuppCTaxLayRefCd = supplierWork.SuppCTaxLayRefCd;
                tempWork.SuppEnterpriseCd = supplierWork.SuppEnterpriseCd;
                tempWork.SuppHonorificTitle = supplierWork.SuppHonorificTitle;
                tempWork.SupplierAddr1 = supplierWork.SupplierAddr1;
                tempWork.SupplierAddr3 = supplierWork.SupplierAddr3;
                tempWork.SupplierAddr4 = supplierWork.SupplierAddr4;
                tempWork.SupplierAttributeDiv = supplierWork.SupplierAttributeDiv;
                tempWork.SupplierCd = supplierWork.SupplierCd;
                tempWork.SupplierKana = supplierWork.SupplierKana;
                tempWork.SupplierNm1 = supplierWork.SupplierNm1;
                tempWork.SupplierNm2 = supplierWork.SupplierNm2;
                tempWork.SupplierNote1 = supplierWork.SupplierNote1;
                tempWork.SupplierNote2 = supplierWork.SupplierNote2;
                tempWork.SupplierNote3 = supplierWork.SupplierNote3;
                tempWork.SupplierNote4 = supplierWork.SupplierNote4;
                tempWork.SupplierPostNo = supplierWork.SupplierPostNo;
                tempWork.SupplierSnm = supplierWork.SupplierSnm;
                tempWork.SupplierTelNo = supplierWork.SupplierTelNo;
                tempWork.SupplierTelNo1 = supplierWork.SupplierTelNo1;
                tempWork.SupplierTelNo2 = supplierWork.SupplierTelNo2;
                tempWork.SuppTtlAmntDspWayCd = supplierWork.SuppTtlAmntDspWayCd;
                tempWork.UpdAssemblyId1 = supplierWork.UpdAssemblyId1;
                tempWork.UpdAssemblyId2 = supplierWork.UpdAssemblyId2;
                tempWork.UpdateDateTime = supplierWork.UpdateDateTime;
                tempWork.UpdEmployeeCode = supplierWork.UpdEmployeeCode;

                pmtSupplierTmpList.Add(tempWork);
            }

            if (pmtSupplierTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }
        #endregion

        // ---- ADD SONGG 2013/07/30 Redmine#39386 ���Џ��}�X�^�ǉ� ----- >>>>>
        #region ���Џ��}�X�^�ǉ�
        /// <summary>
        /// ���Џ��}�X�^�ǉ�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="pmtCompanyInfList">���Џ�񃊃X�g</param>
        /// <returns></returns>
        private int SetCompanyInf(string enterpriseCode,
                string businessSessionId,
                string pmTabSearchGuid,
                ref List<PmtCompanyInfWork> pmtCompanyInfList)
        {
            const string methodName = "SetCompanyInf";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CompanyInf companyInf;
            status = GetCompanyInf(out companyInf, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && companyInf != null)
            {
                WriteCompanyInf(enterpriseCode, businessSessionId, pmTabSearchGuid, companyInf, ref pmtCompanyInfList);
            }

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            return status;
        }

        /// <summary>
        /// ������莩�Џ��ݒ�}�X�^�擾����
        /// </summary>
        /// <param name="companyInf">���Џ��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        private int GetCompanyInf(out CompanyInf companyInf, string enterpriseCode)
        {
            const string methodName = "GetCompanyInf";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            CompanyInfAcs companyInfAcs = new CompanyInfAcs();

            status = companyInfAcs.Read(out companyInf, enterpriseCode);

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            return status;
        }

        /// <summary>
        /// ���Џ��}�X�^���ۑ�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="companyInf">���Џ��</param>
        /// <param name="pmtCompanyInfList">���Џ�񃊃X�g</param>
        private void WriteCompanyInf(string enterpriseCode,
                string businessSessionId,
                string pmTabSearchGuid,
                CompanyInf companyInf,
                ref List<PmtCompanyInfWork> pmtCompanyInfList)
        {
            const string methodName = "WriteCompanyInf";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            PmtCompanyInfWork tempWork = new PmtCompanyInfWork();

            tempWork.CreateDateTime = companyInf.CreateDateTime;
            tempWork.UpdateDateTime = companyInf.UpdateDateTime;
            tempWork.EnterpriseCode = companyInf.EnterpriseCode;
            tempWork.FileHeaderGuid = companyInf.FileHeaderGuid;
            tempWork.UpdEmployeeCode = companyInf.UpdEmployeeCode;
            tempWork.UpdAssemblyId1 = companyInf.UpdAssemblyId1;
            tempWork.UpdAssemblyId2 = companyInf.UpdAssemblyId2;
            tempWork.LogicalDeleteCode = companyInf.LogicalDeleteCode;
            tempWork.BusinessSessionId = businessSessionId;
            tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
            tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));
            tempWork.CompanyCode = companyInf.CompanyCode;
            tempWork.CompanyTotalDay = companyInf.CompanyTotalDay;
            tempWork.FinancialYear = companyInf.FinancialYear;
            tempWork.CompanyBiginMonth = companyInf.CompanyBiginMonth;
            tempWork.CompanyBiginMonth2 = companyInf.CompanyBiginMonth2;
            tempWork.CompanyBiginDate = GetDate(companyInf.CompanyBiginDate);
            tempWork.StartYearDiv = companyInf.StartYearDiv;
            tempWork.StartMonthDiv = companyInf.StartMonthDiv;
            tempWork.CompanyName1 = companyInf.CompanyName1;
            tempWork.CompanyName2 = companyInf.CompanyName2;
            tempWork.PostNo = companyInf.PostNo;
            tempWork.Address1 = companyInf.Address1;
            tempWork.Address3 = companyInf.Address3;
            tempWork.Address4 = companyInf.Address4;
            tempWork.CompanyTelNo1 = companyInf.CompanyTelNo1;
            tempWork.CompanyTelNo2 = companyInf.CompanyTelNo2;
            tempWork.CompanyTelNo3 = companyInf.CompanyTelNo3;
            tempWork.CompanyTelTitle1 = companyInf.CompanyTelTitle1;
            tempWork.CompanyTelTitle2 = companyInf.CompanyTelTitle2;
            tempWork.CompanyTelTitle3 = companyInf.CompanyTelTitle3;
            tempWork.SecMngDiv = companyInf.SecMngDiv;
            tempWork.DataClrExecDate = GetDate(companyInf.DataClrExecDate);
            tempWork.DataClrExecTime = companyInf.DataClrExecTime;
            tempWork.DataSaveMonths = companyInf.DataSaveMonths;
            tempWork.DataCompressDt = GetDate(companyInf.DataCompressDt);
            tempWork.ResultDtSaveMonths = companyInf.ResultDtSaveMonths;
            tempWork.ResultDtCompressDt = GetDate(companyInf.ResultDtCompressDt);
            tempWork.CaPrtsDtSaveMonths = companyInf.CaPrtsDtSaveMonths;
            tempWork.CaPrtsDtCompressDt = GetDate(companyInf.CaPrtsDtCompressDt);
            tempWork.MasterSaveMonths = companyInf.MasterSaveMonths;
            tempWork.MasterCompressDt = GetDate(companyInf.MasterCompressDt);
            tempWork.RatePriorityDiv = companyInf.RatePriorityDiv;

            pmtCompanyInfList.Add(tempWork);
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
        }
        #endregion ���Џ��}�X�^�ǉ�
        // ---- ADD SONGG 2013/07/30 Redmine#39386 ���Џ��}�X�^�ǉ� ----- <<<<<

        #region �L�����y�[�������D��ݒ�}�X�^�̎擾

        /// <summary>
        /// �L�����y�[�������D��ݒ�}�X�^�̎擾
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="pmtCmpPrcPrStList">�����D��ݒ�}�X�^��񃊃X�g</param>
        /// <returns></returns>
        private int SetCampaignPrcPrSt(string enterpriseCode,
                string sectionCode,
                string businessSessionId,
                string pmTabSearchGuid,
                ref List<PmtCmpPrcPrStWork> pmtCmpPrcPrStList)
        {
            const string methodName = "SetCampaignPrcPrSt";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            CampaignPrcPrSt campaignPrcPrSt;
            status = GetCampaignPrcPrSt(out campaignPrcPrSt, enterpriseCode, sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && campaignPrcPrSt != null)
            {
                WritePmtCmpPrcPrSt(enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid, campaignPrcPrSt, ref pmtCmpPrcPrStList);
            }

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            return status;
 
        }

        /// <summary>
        /// �������L�����y�[�������D��ݒ�}�X�^�����擾�B
        /// </summary>
        /// <param name="campaignPrcPrSt">�����D��ݒ�}�X�^���</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        private int GetCampaignPrcPrSt(out CampaignPrcPrSt campaignPrcPrSt, string enterpriseCode, string sectionCode)
        {
            const string methodName = "GetCampaignPrcPrSt";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region �폜
            // DEL 2013/10/08 SCM�d�|�ꗗ��10579�Ή� ------------------------------->>>>>
            //CampaignPrcPrStAcs campaignPrcPrStAcs = new CampaignPrcPrStAcs();

            //int sectionCd = 0;
            //int.TryParse(sectionCode, out sectionCd);
            //CampaignPrcPrSt campaignPrcPrStRead = new CampaignPrcPrSt();
            //ArrayList campaignPrcPrStList = null;
            //if (campaignPrcPrStList == null)
            //{
            //    status = campaignPrcPrStAcs.SearchAll(out campaignPrcPrStList, enterpriseCode);
            //}
            //foreach (CampaignPrcPrSt campaignPrcPr in campaignPrcPrStList)
            //{
            //    // ----- DEL huangt 2013/07/24 Redmine#39039 ���i���� �g�p���鋒�_�R�[�h�̏C�� ----->>>>>
            //    //if (campaignPrcPr.SectionCode.Trim() == sectionCode.Trim())
            //    //{
            //    //    // ���_�R�[�h
            //    //    campaignPrcPrStRead.SectionCode = campaignPrcPr.SectionCode;
            //    //    // �D��ݒ�R�[�h
            //    //    campaignPrcPrStRead.PrioritySettingCd1 = campaignPrcPr.PrioritySettingCd1;
            //    //    campaignPrcPrStRead.PrioritySettingCd2 = campaignPrcPr.PrioritySettingCd2;
            //    //    campaignPrcPrStRead.PrioritySettingCd3 = campaignPrcPr.PrioritySettingCd3;
            //    //    campaignPrcPrStRead.PrioritySettingCd4 = campaignPrcPr.PrioritySettingCd4;
            //    //    campaignPrcPrStRead.PrioritySettingCd5 = campaignPrcPr.PrioritySettingCd5;
            //    //    campaignPrcPrStRead.PrioritySettingCd6 = campaignPrcPr.PrioritySettingCd6;
            //    //    break;
            //    //}
            //    // ----- DEL huangt 2013/07/24 Redmine#39039 ���i���� �g�p���鋒�_�R�[�h�̏C�� -----<<<<<

            //    if (campaignPrcPr.SectionCode.Trim() == "00")
            //    {
            //        // ���_�R�[�h
            //        campaignPrcPrStRead.SectionCode = campaignPrcPr.SectionCode;
            //        // �D��ݒ�R�[�h
            //        campaignPrcPrStRead.PrioritySettingCd1 = campaignPrcPr.PrioritySettingCd1;
            //        campaignPrcPrStRead.PrioritySettingCd2 = campaignPrcPr.PrioritySettingCd2;
            //        campaignPrcPrStRead.PrioritySettingCd3 = campaignPrcPr.PrioritySettingCd3;
            //        campaignPrcPrStRead.PrioritySettingCd4 = campaignPrcPr.PrioritySettingCd4;
            //        campaignPrcPrStRead.PrioritySettingCd5 = campaignPrcPr.PrioritySettingCd5;
            //        campaignPrcPrStRead.PrioritySettingCd6 = campaignPrcPr.PrioritySettingCd6;
            //    }

            //    // ----- ADD huangt 2013/07/24 Redmine#39039 ���i���� �g�p���鋒�_�R�[�h�̏C�� ----->>>>>
            //    if (campaignPrcPr.SectionCode.Trim() == this._mngSectionCode.Trim())
            //    {
            //        // ���_�R�[�h	
            //        campaignPrcPrStRead.SectionCode = campaignPrcPr.SectionCode;
            //        // �D��ݒ�R�[�h	
            //        campaignPrcPrStRead.PrioritySettingCd1 = campaignPrcPr.PrioritySettingCd1;
            //        campaignPrcPrStRead.PrioritySettingCd2 = campaignPrcPr.PrioritySettingCd2;
            //        campaignPrcPrStRead.PrioritySettingCd3 = campaignPrcPr.PrioritySettingCd3;
            //        campaignPrcPrStRead.PrioritySettingCd4 = campaignPrcPr.PrioritySettingCd4;
            //        campaignPrcPrStRead.PrioritySettingCd5 = campaignPrcPr.PrioritySettingCd5;
            //        campaignPrcPrStRead.PrioritySettingCd6 = campaignPrcPr.PrioritySettingCd6;
            //        break;
            //    }
            //    // ----- ADD huangt 2013/07/24 Redmine#39039 ���i���� �g�p���鋒�_�R�[�h�̏C�� -----<<<<<

            //}

            //campaignPrcPrSt = campaignPrcPrStRead;

            //if (status == 0)
            //{
            //    if (campaignPrcPrSt != null)
            //    {
            //        if (campaignPrcPrSt.LogicalDeleteCode != 0)
            //        {
            //            status = -1;
            //        }
            //    }
            //}

            //if (status == 0)
            //{
            //    if (campaignPrcPrSt != null)
            //    {
            //        if (campaignPrcPrSt.PrioritySettingCd1 == 0
            //            && campaignPrcPrSt.PrioritySettingCd2 == 0
            //            && campaignPrcPrSt.PrioritySettingCd3 == 0
            //            && campaignPrcPrSt.PrioritySettingCd4 == 0
            //            && campaignPrcPrSt.PrioritySettingCd5 == 0
            //            && campaignPrcPrSt.PrioritySettingCd6 == 0)
            //        {
            //            campaignPrcPrSt = null;
            //        }
            //    }
            //    else
            //    {
            //        campaignPrcPrSt = null;
            //    }
            //}
            //else
            //{
            //    if (sectionCd != 0)
            //    {
            //        // �����̋��_�Ɉ�v���郌�R�[�h�����݂��Ȃ��ꍇ�́A00�S�Ѓ��R�[�h���g�p����B
            //        campaignPrcPrSt = null;
            //        status = campaignPrcPrStAcs.Read(out campaignPrcPrSt, enterpriseCode, "00");
            //        if (status == 0)
            //        {
            //            if (campaignPrcPrSt != null)
            //            {
            //                if (campaignPrcPrSt.LogicalDeleteCode != 0)
            //                {
            //                    campaignPrcPrSt = null;
            //                    return status;
            //                }

            //                if (campaignPrcPrSt.PrioritySettingCd1 == 0
            //                    && campaignPrcPrSt.PrioritySettingCd2 == 0
            //                    && campaignPrcPrSt.PrioritySettingCd3 == 0
            //                    && campaignPrcPrSt.PrioritySettingCd4 == 0
            //                    && campaignPrcPrSt.PrioritySettingCd5 == 0
            //                    && campaignPrcPrSt.PrioritySettingCd6 == 0)
            //                {
            //                    campaignPrcPrSt = null;
            //                }
            //            }
            //            else
            //            {
            //                campaignPrcPrSt = null;
            //            }
            //        }
            //        else
            //        {
            //            campaignPrcPrSt = null;
            //        }
            //    }
            //    else
            //    {
            //        campaignPrcPrSt = null;
            //    }
            //}
            // DEL 2013/10/08 SCM�d�|�ꗗ��10579�Ή� -------------------------------<<<<<
            #endregion // �폜

            // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� ------------------------------->>>>>
            int sectionCd = 0;
            int.TryParse(sectionCode, out sectionCd);
            campaignPrcPrSt = null;

            // �풓��������擾�����f�[�^�����݂��Ȃ����͊Y�������ŏI��
            if (this._campaignPrcPrStList == null) return status;

            CampaignPrcPrSt campaignPrcPrStRead = new CampaignPrcPrSt();

            foreach (CampaignPrcPrSt campaignPrcPr in this._campaignPrcPrStList)
            {
                if (campaignPrcPr.SectionCode.Trim() == "00")
                {
                    campaignPrcPrStRead.LogicalDeleteCode = campaignPrcPr.LogicalDeleteCode;
                    // ���_�R�[�h
                    campaignPrcPrStRead.SectionCode = campaignPrcPr.SectionCode;
                    // �D��ݒ�R�[�h
                    campaignPrcPrStRead.PrioritySettingCd1 = campaignPrcPr.PrioritySettingCd1;
                    campaignPrcPrStRead.PrioritySettingCd2 = campaignPrcPr.PrioritySettingCd2;
                    campaignPrcPrStRead.PrioritySettingCd3 = campaignPrcPr.PrioritySettingCd3;
                    campaignPrcPrStRead.PrioritySettingCd4 = campaignPrcPr.PrioritySettingCd4;
                    campaignPrcPrStRead.PrioritySettingCd5 = campaignPrcPr.PrioritySettingCd5;
                    campaignPrcPrStRead.PrioritySettingCd6 = campaignPrcPr.PrioritySettingCd6;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                if (campaignPrcPr.SectionCode.Trim() == this._mngSectionCode.Trim())
                {
                    campaignPrcPrStRead.LogicalDeleteCode = campaignPrcPr.LogicalDeleteCode;
                    // ���_�R�[�h	
                    campaignPrcPrStRead.SectionCode = campaignPrcPr.SectionCode;
                    // �D��ݒ�R�[�h	
                    campaignPrcPrStRead.PrioritySettingCd1 = campaignPrcPr.PrioritySettingCd1;
                    campaignPrcPrStRead.PrioritySettingCd2 = campaignPrcPr.PrioritySettingCd2;
                    campaignPrcPrStRead.PrioritySettingCd3 = campaignPrcPr.PrioritySettingCd3;
                    campaignPrcPrStRead.PrioritySettingCd4 = campaignPrcPr.PrioritySettingCd4;
                    campaignPrcPrStRead.PrioritySettingCd5 = campaignPrcPr.PrioritySettingCd5;
                    campaignPrcPrStRead.PrioritySettingCd6 = campaignPrcPr.PrioritySettingCd6;
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }

            campaignPrcPrSt = campaignPrcPrStRead;

            if (status == 0)
            {
                if (campaignPrcPrSt != null)
                {
                    if (campaignPrcPrSt.LogicalDeleteCode != 0)
                    {
                        status = -1;
                    }
                }
            }

            if (status == 0)
            {
                if (campaignPrcPrSt != null)
                {
                    if (campaignPrcPrSt.PrioritySettingCd1 == 0
                        && campaignPrcPrSt.PrioritySettingCd2 == 0
                        && campaignPrcPrSt.PrioritySettingCd3 == 0
                        && campaignPrcPrSt.PrioritySettingCd4 == 0
                        && campaignPrcPrSt.PrioritySettingCd5 == 0
                        && campaignPrcPrSt.PrioritySettingCd6 == 0)
                    {
                        campaignPrcPrSt = null;
                    }
                }
                else
                {
                    campaignPrcPrSt = null;
                }
            }
            else
            {
                if (sectionCd != 0)
                {
                    // �����̋��_�Ɉ�v���郌�R�[�h�����݂��Ȃ��ꍇ�́A00�S�Ѓ��R�[�h���g�p����B
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    campaignPrcPrSt = null;
                    foreach (CampaignPrcPrSt campaignPrcPr in this._campaignPrcPrStList)
                    {
                        if (campaignPrcPr.SectionCode.Trim() == "00")
                        {
                            campaignPrcPrSt = new CampaignPrcPrSt();
                            campaignPrcPrSt.LogicalDeleteCode = campaignPrcPr.LogicalDeleteCode;
                            // ���_�R�[�h
                            campaignPrcPrSt.SectionCode = campaignPrcPr.SectionCode;
                            // �D��ݒ�R�[�h
                            campaignPrcPrSt.PrioritySettingCd1 = campaignPrcPr.PrioritySettingCd1;
                            campaignPrcPrSt.PrioritySettingCd2 = campaignPrcPr.PrioritySettingCd2;
                            campaignPrcPrSt.PrioritySettingCd3 = campaignPrcPr.PrioritySettingCd3;
                            campaignPrcPrSt.PrioritySettingCd4 = campaignPrcPr.PrioritySettingCd4;
                            campaignPrcPrSt.PrioritySettingCd5 = campaignPrcPr.PrioritySettingCd5;
                            campaignPrcPrSt.PrioritySettingCd6 = campaignPrcPr.PrioritySettingCd6;
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            break;
                        }
                    }
                    if (campaignPrcPrSt != null)
                    {
                        if (campaignPrcPrSt.LogicalDeleteCode != 0)
                        {
                            campaignPrcPrSt = null;
                            return status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }

                        if (campaignPrcPrSt.PrioritySettingCd1 == 0
                            && campaignPrcPrSt.PrioritySettingCd2 == 0
                            && campaignPrcPrSt.PrioritySettingCd3 == 0
                            && campaignPrcPrSt.PrioritySettingCd4 == 0
                            && campaignPrcPrSt.PrioritySettingCd5 == 0
                            && campaignPrcPrSt.PrioritySettingCd6 == 0)
                        {
                            campaignPrcPrSt = null;
                        }
                    }
                    else
                    {
                        campaignPrcPrSt = null;
                    }
                }
                else
                {
                    campaignPrcPrSt = null;
                }
            }
            // ADD 2013/10/08 SCM�d�|�ꗗ��10579�Ή� -------------------------------<<<<<

            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            return status;
        }

        /// <summary>
        /// �����D��ݒ�}�X�^���ۑ�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="campaignPrcPrSt">�����D��ݒ�}�X�^���</param>
        /// <param name="pmtCmpPrcPrStList">�����D��ݒ�}�X�^��񃊃X�g</param>
        private void WritePmtCmpPrcPrSt(string enterpriseCode,
                string sectionCode,
                string businessSessionId,
                string pmTabSearchGuid,
                CampaignPrcPrSt campaignPrcPrSt,
                ref List<PmtCmpPrcPrStWork> pmtCmpPrcPrStList)
        {
            const string methodName = "WritePmtCmpPrcPrSt";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");

            PmtCmpPrcPrStWork tempWork = new PmtCmpPrcPrStWork();

            tempWork.CreateDateTime = campaignPrcPrSt.CreateDateTime;
            tempWork.UpdateDateTime = campaignPrcPrSt.UpdateDateTime;
            tempWork.EnterpriseCode = enterpriseCode;
            tempWork.FileHeaderGuid = campaignPrcPrSt.FileHeaderGuid;
            tempWork.UpdEmployeeCode = campaignPrcPrSt.UpdEmployeeCode;
            tempWork.UpdAssemblyId1 = campaignPrcPrSt.UpdAssemblyId1;
            tempWork.UpdAssemblyId2 = campaignPrcPrSt.UpdAssemblyId2;
            tempWork.LogicalDeleteCode = campaignPrcPrSt.LogicalDeleteCode;
            tempWork.BusinessSessionId = businessSessionId;
            tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
            //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", "")); //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
            tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
            tempWork.PmTabSearchRowNum = 1;
            tempWork.SearchSectionCode = sectionCode;
            tempWork.SectionCode = campaignPrcPrSt.SectionCode;
            tempWork.PrioritySettingCd1 = campaignPrcPrSt.PrioritySettingCd1;
            tempWork.PrioritySettingCd2 = campaignPrcPrSt.PrioritySettingCd2;
            tempWork.PrioritySettingCd3 = campaignPrcPrSt.PrioritySettingCd3;
            tempWork.PrioritySettingCd4 = campaignPrcPrSt.PrioritySettingCd4;
            tempWork.PrioritySettingCd5 = campaignPrcPrSt.PrioritySettingCd5;
            tempWork.PrioritySettingCd6 = campaignPrcPrSt.PrioritySettingCd6;

            pmtCmpPrcPrStList.Add(tempWork);
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
        }
        #endregion
        // ----- ADD huangt 2013/07/12 Redmine#38116 �L�����y�[�������D��ݒ�}�X�^�ǉ� ----- <<<<<

        #endregion �� �}�X�^���փf�[�^����

        #region �� ���i��������17�e�[�u���ۑ�����
        /// <summary>
        /// ���i�������ʂ�SCM DB�ɏ����ޏ���
        /// </summary>
        /// <param name="partsInfoDB">���i���@�Ώ�</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="pmtPartsSearchWorkList">�S�ĕۑ��p���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private void GetPartsInfoToScmDBDataList(PartsInfoDataSet partsInfoDB, 
            string enterpriseCode, 
            string sectionCode, 
            string businessSessionId, 
            string pmTabSearchGuid, 
            ref CustomSerializeArrayList pmtPartsSearchWorkList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "GetPartsInfoToScmDBDataList";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            try
            {
                List<PmtUrSubPtsTmpWork> pmtUrSubPtsTmpList = new List<PmtUrSubPtsTmpWork>();
                WriteUsrSubstParts(partsInfoDB.UsrSubstParts, ref pmtUrSubPtsTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtUrSubPtsTmpList);

                List<PmtDSbPtInfoTmpWork> pmtDSbPtInfoTmpList = new List<PmtDSbPtInfoTmpWork>();
                WriteDSubstPartsInfo(partsInfoDB.DSubstPartsInfo, ref pmtDSbPtInfoTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtDSbPtInfoTmpList);

                // --- DEL 2013/08/01 �O�� Redmine#39451 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //List<PmtGoodsSetTmpWork> pmtGoodsSetTmpList = new List<PmtGoodsSetTmpWork>();
                //WriteGoodsSet(partsInfoDB.GoodsSet, ref pmtGoodsSetTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                //pmtPartsSearchWorkList.Add(pmtGoodsSetTmpList);

                //List<PmtJoinPartsTmpWork> pmtJoinPartsTmpList = new List<PmtJoinPartsTmpWork>();
                //WriteJoinParts(partsInfoDB.JoinParts, ref pmtJoinPartsTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                //pmtPartsSearchWorkList.Add(pmtJoinPartsTmpList);
                // --- DEL 2013/08/01 �O�� Redmine#39451 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                List<PmtMdlPtDtlTmpWork> pmtMdlPtDtlTmpList = new List<PmtMdlPtDtlTmpWork>();
                WriteModelPartsDetail(partsInfoDB.ModelPartsDetail, ref pmtMdlPtDtlTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtMdlPtDtlTmpList);

                List<PmtOfrColInfTmpWork> pmtOfrColInfTmpList = new List<PmtOfrColInfTmpWork>();
                WriteOfrColorInfo(partsInfoDB.OfrColorInfo, ref pmtOfrColInfTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtOfrColInfTmpList);

                List<PmtOfrEqpInfTmpWork> pmtOfrEqpInfTmpList = new List<PmtOfrEqpInfTmpWork>();
                WriteOfrEquipInfo(partsInfoDB.OfrEquipInfo, ref pmtOfrEqpInfTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtOfrEqpInfTmpList);

                // --- DEL 2013/08/01 �O�� Redmine#39451 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //List<PmtOfrPrmPtsTmpWork> pmtOfrPrmPtsTmpList = new List<PmtOfrPrmPtsTmpWork>();
                //WriteOfrPrimeParts(partsInfoDB.OfrPrimeParts, ref pmtOfrPrmPtsTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                //pmtPartsSearchWorkList.Add(pmtOfrPrmPtsTmpList);
                // --- DEL 2013/08/01 �O�� Redmine#39451 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                List<PmtOfrTrmInfTmpWork> pmtOfrTrmInfTmpList = new List<PmtOfrTrmInfTmpWork>();
                WriteOfrTrimInfo(partsInfoDB.OfrTrimInfo, ref pmtOfrTrmInfTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtOfrTrmInfTmpList);

                List<PmtPartsInfoTmpWork> pmtPartsInfoTmpList = new List<PmtPartsInfoTmpWork>();
                WritePartsInfo(partsInfoDB.PartsInfo, ref pmtPartsInfoTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtPartsInfoTmpList);

                List<PmtStockTmpWork> pmtStockTmpList = new List<PmtStockTmpWork>();
                WriteStock(partsInfoDB.Stock, ref pmtStockTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtStockTmpList);

                // --- DEL 2013/08/01 �O�� Redmine#39451 --------->>>>>>>>>>>>>>>>>>>>>>>>
                //List<PmtSbPtsInfoTmpWork> pmtSbPtsInfoTmpList = new List<PmtSbPtsInfoTmpWork>();
                //WriteSubstPartsInfo(partsInfoDB.SubstPartsInfo, ref pmtSbPtsInfoTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                //pmtPartsSearchWorkList.Add(pmtSbPtsInfoTmpList);
                // --- DEL 2013/08/01 �O�� Redmine#39451 ---------<<<<<<<<<<<<<<<<<<<<<<<<

                List<PmtTBOInfoTmpWork> pmtTBOInfoTmpList = new List<PmtTBOInfoTmpWork>();
                WriteTBOInfo(partsInfoDB.TBOInfo, ref pmtTBOInfoTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtTBOInfoTmpList);

                List<PmtUrGdsInfTmpWork> pmtUrGdsInfTmpList = new List<PmtUrGdsInfTmpWork>();
                WriteUsrGoodsInfo(partsInfoDB.UsrGoodsInfo, ref pmtUrGdsInfTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtUrGdsInfTmpList);

                List<PmtUrGdsPriTmpWork> pmtUrGdsPriTmpList = new List<PmtUrGdsPriTmpWork>();
                WriteUsrGoodsPrice(partsInfoDB.UsrGoodsPrice, ref pmtUrGdsPriTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtUrGdsPriTmpList);

                List<PmtUrJinPtsTmpWork> pmtUrJinPtsTmpList = new List<PmtUrJinPtsTmpWork>();
                WriteUsrJoinParts(partsInfoDB.UsrJoinParts, ref pmtUrJinPtsTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtUrJinPtsTmpList);

                List<PmtUrSetPtsTmpWork> pmtUrSetPtsTmpList = new List<PmtUrSetPtsTmpWork>();
                WriteUsrSetParts(partsInfoDB.UsrSetParts, ref pmtUrSetPtsTmpList, enterpriseCode, sectionCode, businessSessionId, pmTabSearchGuid);
                pmtPartsSearchWorkList.Add(pmtUrSetPtsTmpList);
            }
            catch (Exception ex)
            {
                string errMsg = ex.ToString();
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, ex.Message);
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
        }
        /// <summary>
        /// ���[�U�[��֌����f�[�^�V�K����
        /// </summary>
        /// <param name="usrSubstParts">���[�U�[��֌�������</param>
        /// <param name="pmtUrSubPtsTmpList">SCM DB�p���[�U�[��֌������ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteUsrSubstParts(PartsInfoDataSet.UsrSubstPartsDataTable usrSubstParts, 
            ref List<PmtUrSubPtsTmpWork> pmtUrSubPtsTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WriteUsrSubstParts";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < usrSubstParts.Count; i++)
            {
                PartsInfoDataSet.UsrSubstPartsRow tempUsrSubstParts = usrSubstParts[i] as PartsInfoDataSet.UsrSubstPartsRow;

                PmtUrSubPtsTmpWork tempWork = new PmtUrSubPtsTmpWork();

                tempWork.ChgSrcMakerCd = (int)tempUsrSubstParts[usrSubstParts.ChgSrcMakerCdColumn.ColumnName];
                if ((Boolean)tempUsrSubstParts[usrSubstParts.OfferKubunColumn.ColumnName])
                {
                    tempWork.OfferKubun = 1;             
                }
                else
                {
                    tempWork.OfferKubun = 0;          
                }
                tempWork.ApplyEdDate = (int)tempUsrSubstParts[usrSubstParts.ApplyEdDateColumn.ColumnName];
                if ((Boolean)tempUsrSubstParts[usrSubstParts.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;    
                }
                else
                {
                    tempWork.SelectionState = 0;   
                }

                tempWork.ApplyStDate = (int)tempUsrSubstParts[usrSubstParts.ApplyStDateColumn.ColumnName];

                if (!(tempUsrSubstParts[usrSubstParts.ChgDestGoodsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.ChgDestGoodsNo = (string)tempUsrSubstParts[usrSubstParts.ChgDestGoodsNoColumn.ColumnName];
                }

                tempWork.ChgDestMakerCd = (int)tempUsrSubstParts[usrSubstParts.ChgDestMakerCdColumn.ColumnName];

                if (!(tempUsrSubstParts[usrSubstParts.ChgSrcGoodsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.ChgSrcGoodsNo = (string)tempUsrSubstParts[usrSubstParts.ChgSrcGoodsNoColumn.ColumnName];
                }

                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.PmTabSearchRowNum = i + 1;

                pmtUrSubPtsTmpList.Add(tempWork);
            }

            if (pmtUrSubPtsTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// ������֕��i�������ʏ��V�K����
        /// </summary>
        /// <param name="dSubstPartsInfo">������֕��i�������ʏ��</param>
        /// <param name="pmtDSbPtInfoTmpList">SCM DB�p������֕��i�������ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteDSubstPartsInfo(PartsInfoDataSet.DSubstPartsInfoDataTable dSubstPartsInfo, 
            ref List<PmtDSbPtInfoTmpWork> pmtDSbPtInfoTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WriteDSubstPartsInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < dSubstPartsInfo.Count; i++)
            {
                PartsInfoDataSet.DSubstPartsInfoRow tempDSubstPartsInfo = dSubstPartsInfo[i] as PartsInfoDataSet.DSubstPartsInfoRow;

                PmtDSbPtInfoTmpWork tempWork = new PmtDSbPtInfoTmpWork();

                tempWork.CatalogPartsMakerCd = (int)tempDSubstPartsInfo[dSubstPartsInfo.CatalogPartsMakerCdColumn.ColumnName];

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.PartsNameKanaColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PartsNameKana = (string)tempDSubstPartsInfo[dSubstPartsInfo.PartsNameKanaColumn.ColumnName];
                }

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.NewPrtsNoNoneHyphenColumn.ColumnName] is System.DBNull))
                {
                    tempWork.NewPrtsNoNoneHyphen = (string)tempDSubstPartsInfo[dSubstPartsInfo.NewPrtsNoNoneHyphenColumn.ColumnName];
                }

                if ((Boolean)tempDSubstPartsInfo[dSubstPartsInfo.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;
                }
                else
                {
                    tempWork.SelectionState = 0;
                }

                tempWork.PartsSearchCode = (int)tempDSubstPartsInfo[dSubstPartsInfo.PartsSearchCodeColumn.ColumnName];
                tempWork.PartsCode = (int)tempDSubstPartsInfo[dSubstPartsInfo.PartsCodeColumn.ColumnName];

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.PartsNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PartsName = (string)tempDSubstPartsInfo[dSubstPartsInfo.PartsNameColumn.ColumnName];
                }
                tempWork.PartsInfoCtrlFlg = (int)tempDSubstPartsInfo[dSubstPartsInfo.PartsInfoCtrlFlgColumn.ColumnName];

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.PartsLayerCdColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PartsLayerCd = (string)tempDSubstPartsInfo[dSubstPartsInfo.PartsLayerCdColumn.ColumnName];
                }

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.MakerOfferPartsNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.MakerOfferPartsName = (string)tempDSubstPartsInfo[dSubstPartsInfo.MakerOfferPartsNameColumn.ColumnName];
                }
                tempWork.TbsPartsCdDerivedNo = (int)tempDSubstPartsInfo[dSubstPartsInfo.TbsPartsCdDerivedNoColumn.ColumnName];
                tempWork.TbsPartsCode = (int)tempDSubstPartsInfo[dSubstPartsInfo.TbsPartsCodeColumn.ColumnName];

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.PlrlSubNewPrtNoHypnColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PlrlSubNewPrtNoHypn = (string)tempDSubstPartsInfo[dSubstPartsInfo.PlrlSubNewPrtNoHypnColumn.ColumnName];
                }

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.PartsPluralSubstCmntColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PartsPluralSubstCmnt = (string)tempDSubstPartsInfo[dSubstPartsInfo.PartsPluralSubstCmntColumn.ColumnName];
                }
                tempWork.PartsQty = (double)tempDSubstPartsInfo[dSubstPartsInfo.PartsQtyColumn.ColumnName];
                tempWork.MainOrSubPartsDivCd = (int)tempDSubstPartsInfo[dSubstPartsInfo.MainOrSubPartsDivCdColumn.ColumnName];
                tempWork.PartsPluralSubstFlg = (int)tempDSubstPartsInfo[dSubstPartsInfo.PartsPluralSubstFlgColumn.ColumnName];
                tempWork.NPrtNoWithHypnDspOdr = (int)tempDSubstPartsInfo[dSubstPartsInfo.NPrtNoWithHypnDspOdrColumn.ColumnName];

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.NewPartsNoWithHyphenColumn.ColumnName] is System.DBNull))
                {
                    tempWork.NewPartsNoWithHyphen = (string)tempDSubstPartsInfo[dSubstPartsInfo.NewPartsNoWithHyphenColumn.ColumnName];
                }

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.OldPartsNoWithHyphenColumn.ColumnName] is System.DBNull))
                {
                    tempWork.OldPartsNoWithHyphen = (string)tempDSubstPartsInfo[dSubstPartsInfo.OldPartsNoWithHyphenColumn.ColumnName];
                }

                if (!(tempDSubstPartsInfo[dSubstPartsInfo.CatalogPartsMakerNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.CatalogPartsMakerNm = (string)tempDSubstPartsInfo[dSubstPartsInfo.CatalogPartsMakerNmColumn.ColumnName];
                }
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.PmTabSearchRowNum = i + 1;

                pmtDSbPtInfoTmpList.Add(tempWork);
            }

            if (pmtDSbPtInfoTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        #region 2013/08/01 �O�� �폜
        // --- DEL 2013/08/01 �O�� Redmine#39451 --------->>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// �Z�b�g���i�������ʏ��V�K����
        ///// </summary>
        ///// <param name="goodsSet">�Z�b�g���i�������ʏ��</param>
        ///// <param name="pmtGoodsSetTmpList">SCM DB�p�Z�b�g���i�������ʃ��X�g</param>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="sectionCode">���_�R�[�h</param>
        ///// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        ///// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        ///// <returns>�X�e�[�^�X</returns>
        //private int WriteGoodsSet(PartsInfoDataSet.GoodsSetDataTable goodsSet, 
        //    ref List<PmtGoodsSetTmpWork> pmtGoodsSetTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        //{
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
        //    const string methodName = "WriteGoodsSet";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

        //    for (int i = 0; i < goodsSet.Count; i++)
        //    {
        //        PartsInfoDataSet.GoodsSetRow tempGoodsSet = goodsSet[i] as PartsInfoDataSet.GoodsSetRow;

        //        PmtGoodsSetTmpWork tempWork = new PmtGoodsSetTmpWork();

        //        tempWork.GoodsMGroup = (int)tempGoodsSet[goodsSet.GoodsMGroupColumn.ColumnName];

        //        if (!(tempGoodsSet[goodsSet.PrimePartsKanaNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PrimePartsKanaName = (string)tempGoodsSet[goodsSet.PrimePartsKanaNameColumn.ColumnName];
        //        }

        //        if (!(tempGoodsSet[goodsSet.OfferDateColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.OfferDate = (DateTime)tempGoodsSet[goodsSet.OfferDateColumn.ColumnName];
        //        }

        //        if ((Boolean)tempGoodsSet[goodsSet.SelectionStateColumn.ColumnName])
        //        {
        //            tempWork.SelectionState = 1;
        //        }
        //        else
        //        {
        //            tempWork.SelectionState = 0;
        //        }

        //        if (!(tempGoodsSet[goodsSet.SetSubMakerNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.SetSubMakerName = (string)tempGoodsSet[goodsSet.SetSubMakerNameColumn.ColumnName];
        //        }

        //        if (!(tempGoodsSet[goodsSet.SetSubPartsNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.SetSubPartsName = (string)tempGoodsSet[goodsSet.SetSubPartsNameColumn.ColumnName];
        //        }

        //        if (!(tempGoodsSet[goodsSet.SubGoodsNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.SubGoodsName = (string)tempGoodsSet[goodsSet.SubGoodsNameColumn.ColumnName];
        //        }

        //        if (!(tempGoodsSet[goodsSet.ParentGoodsNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.ParentGoodsName = (string)tempGoodsSet[goodsSet.ParentGoodsNameColumn.ColumnName];
        //        }

        //        if (!(tempGoodsSet[goodsSet.CatalogShapeNoColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.CatalogShapeNo = (string)tempGoodsSet[goodsSet.CatalogShapeNoColumn.ColumnName];
        //        }

        //        if (!(tempGoodsSet[goodsSet.SetSpecialNoteColumn.ColumnName] is System.DBNull))
        //        {
        //            //tempWork.SetSpecialNote = (string)tempGoodsSet[goodsSet.SetSpecialNoteColumn.ColumnName];    // DEL huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\�������               
        //            tempWork.SetSpecialNote = GetSubString((string)tempGoodsSet[goodsSet.SetSpecialNoteColumn.ColumnName], 40);     // ADD huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
        //        }

        //        if (!(tempGoodsSet[goodsSet.SetNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.SetName = (string)tempGoodsSet[goodsSet.SetNameColumn.ColumnName];
        //        }
        //        tempWork.SetQty = (double)tempGoodsSet[goodsSet.SetQtyColumn.ColumnName];
        //        tempWork.SetDisplayOrder = (int)tempGoodsSet[goodsSet.SetDisplayOrderColumn.ColumnName];

        //        if (!(tempGoodsSet[goodsSet.SetSubPartsNoColumn.ColumnName] is System.DBNull))
        //        {
        //            //tempWork.SetSubPartsNo = (string)tempGoodsSet[goodsSet.SetSubPartsNoColumn.ColumnName];   // DEL huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
        //            tempWork.SetSubPartsNo = GetSubString((string)tempGoodsSet[goodsSet.SetSubPartsNoColumn.ColumnName], 24);      // ADD huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
        //        }
        //        tempWork.SetSubMakerCd = (int)tempGoodsSet[goodsSet.SetSubMakerCdColumn.ColumnName];

        //        if (!(tempGoodsSet[goodsSet.SetMainPartsNoColumn.ColumnName] is System.DBNull))
        //        {
        //            //tempWork.SetMainPartsNo = (string)tempGoodsSet[goodsSet.SetMainPartsNoColumn.ColumnName];    // DEL huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
        //            tempWork.SetMainPartsNo = GetSubString((string)tempGoodsSet[goodsSet.SetMainPartsNoColumn.ColumnName], 24);      // ADD huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
        //        }

        //        tempWork.SetMainMakerCd = (int)tempGoodsSet[goodsSet.SetMainMakerCdColumn.ColumnName];
        //        tempWork.TbsPartsCdDerivedNo = (int)tempGoodsSet[goodsSet.TbsPartsCdDerivedNoColumn.ColumnName];
        //        tempWork.TbsPartsCode = (int)tempGoodsSet[goodsSet.TbsPartsCodeColumn.ColumnName];
        //        tempWork.BusinessSessionId = businessSessionId;
        //        tempWork.EnterpriseCode = enterpriseCode;
        //        tempWork.SearchSectionCode = sectionCode;
        //        tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
        //        //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
        //        tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
        //        tempWork.PmTabSearchRowNum = i + 1;

        //        pmtGoodsSetTmpList.Add(tempWork);
        //    }

        //    if (pmtGoodsSetTmpList.Count > 0)
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }

        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
        //    return status;
        //}

        ///// <summary>
        ///// �������i�������ʏ��V�K����
        ///// </summary>
        ///// <param name="joinParts">�������i�������ʏ��</param>
        ///// <param name="pmtJoinPartsTmpList">SCM DB�p�������i��������</param>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="sectionCode">���_�R�[�h</param>
        ///// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        ///// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        ///// <returns>�X�e�[�^�X</returns>
        //private int WriteJoinParts(PartsInfoDataSet.JoinPartsDataTable joinParts,
        //    ref List<PmtJoinPartsTmpWork> pmtJoinPartsTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        //{
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
        //    const string methodName = "WriteJoinParts";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

        //    for (int i = 0; i < joinParts.Count; i++)
        //    {
        //        PartsInfoDataSet.JoinPartsRow tempJoinParts = joinParts[i] as PartsInfoDataSet.JoinPartsRow;

        //        PmtJoinPartsTmpWork tempWork = new PmtJoinPartsTmpWork();

        //        tempWork.GoodsMGroup = (int)tempJoinParts[joinParts.GoodsMGroupColumn.ColumnName];

        //        if (!(tempJoinParts[joinParts.PrimePartsKanaNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PrimePartsKanaName = (string)tempJoinParts[joinParts.PrimePartsKanaNameColumn.ColumnName];
        //        }

        //        if (!(tempJoinParts[joinParts.OfferDateColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.OfferDate = (DateTime)tempJoinParts[joinParts.OfferDateColumn.ColumnName];
        //        }

        //        if (!(tempJoinParts[joinParts.JoinDestMakerNmColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.JoinDestMakerNm = (string)tempJoinParts[joinParts.JoinDestMakerNmColumn.ColumnName];
        //        }

        //        if (!(tempJoinParts[joinParts.PrimePartsNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PrimePartsName = (string)tempJoinParts[joinParts.PrimePartsNameColumn.ColumnName];
        //        }
        //        tempWork.SetPartsFlg = (int)tempJoinParts[joinParts.SetPartsFlgColumn.ColumnName];

        //        if ((Boolean)tempJoinParts[joinParts.SelectionStateColumn.ColumnName])
        //        {
        //            tempWork.SelectionState = 1;
        //        }
        //        else
        //        {
        //            tempWork.SelectionState = 0; 
        //        }

        //        if (!(tempJoinParts[joinParts.JoinSpecialNoteColumn.ColumnName] is System.DBNull))
        //        {
        //            //tempWork.JoinSpecialNote = (string)tempJoinParts[joinParts.JoinSpecialNoteColumn.ColumnName];     // DEL huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
        //            tempWork.JoinSpecialNote = GetSubString((string)tempJoinParts[joinParts.JoinSpecialNoteColumn.ColumnName], 40);      // ADD huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
        //        }

        //        tempWork.JoinQty = (double)tempJoinParts[joinParts.JoinQtyColumn.ColumnName];

        //        if (!(tempJoinParts[joinParts.JoinDestPartsNoColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.JoinDestPartsNo = (string)tempJoinParts[joinParts.JoinDestPartsNoColumn.ColumnName];
        //        }

        //        tempWork.JoinDestMakerCd = (int)tempJoinParts[joinParts.JoinDestMakerCdColumn.ColumnName];

        //        if (!(tempJoinParts[joinParts.JoinSourPartsNoNoneHColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.JoinSourPartsNoNoneH = (string)tempJoinParts[joinParts.JoinSourPartsNoNoneHColumn.ColumnName];
        //        }

        //        if (!(tempJoinParts[joinParts.JoinSourPartsNoWithHColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.JoinSourPartsNoWithH = (string)tempJoinParts[joinParts.JoinSourPartsNoWithHColumn.ColumnName];
        //        }

        //        tempWork.JoinSourceMakerCode = (int)tempJoinParts[joinParts.JoinSourceMakerCodeColumn.ColumnName];
        //        tempWork.JoinDispOrder = (int)tempJoinParts[joinParts.JoinDispOrderColumn.ColumnName];
        //        tempWork.PrmSetDtlNo2 = (int)tempJoinParts[joinParts.PrmSetDtlNo2Column.ColumnName];
        //        tempWork.PrmSetDtlNo1 = (int)tempJoinParts[joinParts.PrmSetDtlNo1Column.ColumnName];
        //        tempWork.TbsPartsCdDerivedNo = (int)tempJoinParts[joinParts.TbsPartsCdDerivedNoColumn.ColumnName];
        //        tempWork.TbsPartsCode = (int)tempJoinParts[joinParts.TbsPartsCodeColumn.ColumnName];
        //        tempWork.BusinessSessionId = businessSessionId;
        //        tempWork.EnterpriseCode = enterpriseCode;
        //        tempWork.SearchSectionCode = sectionCode;
        //        tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
        //        //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
        //        tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
        //        tempWork.PmTabSearchRowNum = i + 1;

        //        pmtJoinPartsTmpList.Add(tempWork);
        //    }

        //    if (pmtJoinPartsTmpList.Count > 0)
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }

        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
        //    return status;
        //}
        // --- DEL 2013/08/01 �O�� Redmine#39451 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion 2013/08/01 �O�� �폜

        /// <summary>
        /// ���i�֘A�^���������ʏ��V�K����
        /// </summary>
        /// <param name="modelPartsDetail">���i�֘A�^���������ʏ��</param>
        /// <param name="pmtMdlPtDtlTmpList">SCM DB�p���i�֘A�^���������ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteModelPartsDetail(PartsInfoDataSet.ModelPartsDetailDataTable modelPartsDetail,
            ref List<PmtMdlPtDtlTmpWork> pmtMdlPtDtlTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WriteModelPartsDetail";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < modelPartsDetail.Count; i++)
            {
                PartsInfoDataSet.ModelPartsDetailRow tempModelPartsDetail = modelPartsDetail[i] as PartsInfoDataSet.ModelPartsDetailRow;

                PmtMdlPtDtlTmpWork tempWork = new PmtMdlPtDtlTmpWork();

                tempWork.FullModelFixedNo = (int)tempModelPartsDetail[modelPartsDetail.FullModelFixedNoColumn.ColumnName];
                if (!(tempModelPartsDetail[modelPartsDetail.WheelDriveMethodNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.WheelDriveMethodNm = (string)tempModelPartsDetail[modelPartsDetail.WheelDriveMethodNmColumn.ColumnName];
                }

                if ((Boolean)tempModelPartsDetail[modelPartsDetail.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1; 
                }
                else
                {
                    tempWork.SelectionState = 0;
                }

                if (!(tempModelPartsDetail[modelPartsDetail.PartsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PartsNo = (string)tempModelPartsDetail[modelPartsDetail.PartsNoColumn.ColumnName];
                }
                tempWork.PartsMakerCd = (int)tempModelPartsDetail[modelPartsDetail.PartsMakerCdColumn.ColumnName];
                tempWork.PartsUniqueNo = (long)tempModelPartsDetail[modelPartsDetail.PartsUniqueNoColumn.ColumnName];

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle6Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpecTitle6 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle6Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle5Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpecTitle5 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle5Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle4Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpecTitle4 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle4Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle3Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpecTitle3 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle3Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle2Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpecTitle2 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle2Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle1Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpecTitle1 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpecTitle1Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpec6Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpec6 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpec6Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpec5Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpec5 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpec5Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpec4Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpec4 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpec4Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpec3Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpec3 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpec3Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpec2Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpec2 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpec2Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.AddiCarSpec1Column.ColumnName] is System.DBNull))
                {
                    tempWork.AddiCarSpec1 = (string)tempModelPartsDetail[modelPartsDetail.AddiCarSpec1Column.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.ShiftNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.ShiftNm = (string)tempModelPartsDetail[modelPartsDetail.ShiftNmColumn.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.TransmissionNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.TransmissionNm = (string)tempModelPartsDetail[modelPartsDetail.TransmissionNmColumn.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.EDivNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.EDivNm = (string)tempModelPartsDetail[modelPartsDetail.EDivNmColumn.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.EngineDisplaceNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.EngineDisplaceNm = (string)tempModelPartsDetail[modelPartsDetail.EngineDisplaceNmColumn.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.EngineModelNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.EngineModelNmRD = (string)tempModelPartsDetail[modelPartsDetail.EngineModelNmColumn.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.ModelGradeNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.ModelGradeNm = (string)tempModelPartsDetail[modelPartsDetail.ModelGradeNmColumn.ColumnName];
                }

                if (!(tempModelPartsDetail[modelPartsDetail.BodyNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.BodyName = (string)tempModelPartsDetail[modelPartsDetail.BodyNameColumn.ColumnName];
                }

                tempWork.DoorCount = (int)tempModelPartsDetail[modelPartsDetail.DoorCountColumn.ColumnName];
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.PmTabSearchRowNum = i + 1;

                pmtMdlPtDtlTmpList.Add(tempWork);
            }

            if (pmtMdlPtDtlTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// �񋟃J���[�������ʏ��V�K����
        /// </summary>
        /// <param name="ofrColorInfo">�񋟃J���[�������ʏ��</param>
        /// <param name="pmtOfrColInfTmpList">SCM DB�p�񋟃J���[�������ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteOfrColorInfo(PartsInfoDataSet.OfrColorInfoDataTable ofrColorInfo,
            ref List<PmtOfrColInfTmpWork> pmtOfrColInfTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WriteOfrColorInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < ofrColorInfo.Count; i++)
            {
                PartsInfoDataSet.OfrColorInfoRow tempOfrColorInfo = ofrColorInfo[i] as PartsInfoDataSet.OfrColorInfoRow;

                PmtOfrColInfTmpWork tempWork = new PmtOfrColInfTmpWork();

                tempWork.PartsProperNo = (long)tempOfrColorInfo[ofrColorInfo.PartsProperNoColumn.ColumnName];

                if (!(tempOfrColorInfo[ofrColorInfo.ColorNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.ColorName = (string)tempOfrColorInfo[ofrColorInfo.ColorNameColumn.ColumnName];
                }

                if ((Boolean)tempOfrColorInfo[ofrColorInfo.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;
                }
                else
                {
                    tempWork.SelectionState = 0;
                }

                if (!(tempOfrColorInfo[ofrColorInfo.ColorCdInfoNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.ColorCdInfoNo = (string)tempOfrColorInfo[ofrColorInfo.ColorCdInfoNoColumn.ColumnName];
                }
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.PmTabSearchRowNum = i + 1;

                pmtOfrColInfTmpList.Add(tempWork);
            }

            if (pmtOfrColInfTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// �񋟑����������ʏ��V�K����
        /// </summary>
        /// <param name="ofrEquipInfo">�񋟑����������ʏ��</param>
        /// <param name="pmtOfrEqpInfTmpList">SCM DB�p�񋟑����������ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteOfrEquipInfo(PartsInfoDataSet.OfrEquipInfoDataTable ofrEquipInfo,
            ref List<PmtOfrEqpInfTmpWork> pmtOfrEqpInfTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WriteOfrEquipInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < ofrEquipInfo.Count; i++)
            {
                PartsInfoDataSet.OfrEquipInfoRow tempOfrEquipInfo = ofrEquipInfo[i] as PartsInfoDataSet.OfrEquipInfoRow;

                PmtOfrEqpInfTmpWork tempWork = new PmtOfrEqpInfTmpWork();

                tempWork.PartsProperNo = (long)tempOfrEquipInfo[ofrEquipInfo.PartsProperNoColumn.ColumnName];

                if (!(tempOfrEquipInfo[ofrEquipInfo.EquipmentShortNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.EquipmentShortName = (string)tempOfrEquipInfo[ofrEquipInfo.EquipmentShortNameColumn.ColumnName];
                }
                tempWork.EquipmentDispOrder = (int)tempOfrEquipInfo[ofrEquipInfo.EquipmentDispOrderColumn.ColumnName];
                tempWork.EquipmentIconCode = (int)tempOfrEquipInfo[ofrEquipInfo.EquipmentIconCodeColumn.ColumnName];

                if (!(tempOfrEquipInfo[ofrEquipInfo.EquipmentNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.EquipmentName = (string)tempOfrEquipInfo[ofrEquipInfo.EquipmentNameColumn.ColumnName];
                }

                if (!(tempOfrEquipInfo[ofrEquipInfo.EquipmentGenreNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.EquipmentGenreNm = (string)tempOfrEquipInfo[ofrEquipInfo.EquipmentGenreNmColumn.ColumnName];
                }

                if ((Boolean)tempOfrEquipInfo[ofrEquipInfo.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;
                }
                else
                {
                    tempWork.SelectionState = 0;
                }
                tempWork.EquipmentCode = (int)tempOfrEquipInfo[ofrEquipInfo.EquipmentCodeColumn.ColumnName];
                tempWork.EquipmentGenreCd = (int)tempOfrEquipInfo[ofrEquipInfo.EquipmentGenreCdColumn.ColumnName];
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.PmTabSearchRowNum = i + 1;

                pmtOfrEqpInfTmpList.Add(tempWork);
            }

            if (pmtOfrEqpInfTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        #region 2013/08/01 �O�� �폜
        // --- DEL 2013/08/01 �O�� Redmine#39451 --------->>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// �񋟗D�Ǖ��i�������ʏ��V�K����
        ///// </summary>
        ///// <param name="ofrPrimeParts">�񋟗D�Ǖ��i�������ʏ��</param>
        ///// <param name="pmtOfrPrmPtsTmpList">SCM DB�p�񋟗D�Ǖ��i�������ʃ��X�g</param>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="sectionCode">���_�R�[�h</param>
        ///// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        ///// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        ///// <returns>�X�e�[�^�X</returns>
        //private int WriteOfrPrimeParts(PartsInfoDataSet.OfrPrimePartsDataTable ofrPrimeParts,
        //    ref List<PmtOfrPrmPtsTmpWork> pmtOfrPrmPtsTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        //{
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
        //    const string methodName = "WriteOfrPrimeParts";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

        //    for (int i = 0; i < ofrPrimeParts.Count; i++)
        //    {
        //        PmtOfrPrmPtsTmpWork tempWork = new PmtOfrPrmPtsTmpWork();

        //        PartsInfoDataSet.OfrPrimePartsRow tempOfrPrimeParts = ofrPrimeParts[i] as PartsInfoDataSet.OfrPrimePartsRow;

        //        tempWork.GoodsMGroup = (int)tempOfrPrimeParts[ofrPrimeParts.GoodsMGroupColumn.ColumnName];

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.PrimePartsKanaNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PrimePartsKanaName = (string)tempOfrPrimeParts[ofrPrimeParts.PrimePartsKanaNameColumn.ColumnName];
        //        }
        //        tempWork.PrmPartsProperNo = (long)tempOfrPrimeParts[ofrPrimeParts.PrmPartsProperNoColumn.ColumnName];

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.OfferDateColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.OfferDate = (DateTime)tempOfrPrimeParts[ofrPrimeParts.OfferDateColumn.ColumnName];
        //        }
        //        tempWork.PrimeSearchDispOrder = (int)tempOfrPrimeParts[ofrPrimeParts.PrimeSearchDispOrderColumn.ColumnName];
        //        tempWork.PrimeDispOrder = (int)tempOfrPrimeParts[ofrPrimeParts.PrimeDispOrderColumn.ColumnName];
        //        tempWork.MakerDispOrder = (int)tempOfrPrimeParts[ofrPrimeParts.MakerDispOrderColumn.ColumnName];

        //        if ((Boolean)tempOfrPrimeParts[ofrPrimeParts.SelectionStateColumn.ColumnName])
        //        {
        //            tempWork.SelectionState = 1; 
        //        }
        //        else
        //        {
        //            tempWork.SelectionState = 0; 
        //        }

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.PartsMakerNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PartsMakerName = (string)tempOfrPrimeParts[ofrPrimeParts.PartsMakerNameColumn.ColumnName];
        //        }
        //        tempWork.EdProduceFrameNo = (int)tempOfrPrimeParts[ofrPrimeParts.EdProduceFrameNoColumn.ColumnName];
        //        tempWork.StProduceFrameNo = (int)tempOfrPrimeParts[ofrPrimeParts.StProduceFrameNoColumn.ColumnName];

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.EdProduceTypeOfYearColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.EdProduceTypeOfYear = (DateTime)tempOfrPrimeParts[ofrPrimeParts.EdProduceTypeOfYearColumn.ColumnName];
        //        }

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.StProduceTypeOfYearColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.StProduceTypeOfYear = (DateTime)tempOfrPrimeParts[ofrPrimeParts.StProduceTypeOfYearColumn.ColumnName];
        //        }

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.PrimeSpecialNoteColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PrimeSpecialNote = (string)tempOfrPrimeParts[ofrPrimeParts.PrimeSpecialNoteColumn.ColumnName];
        //        }
        //        tempWork.PrimeQty = (double)tempOfrPrimeParts[ofrPrimeParts.PrimeQtyColumn.ColumnName];
        //        tempWork.SetPartsFlg = (int)tempOfrPrimeParts[ofrPrimeParts.SetPartsFlgColumn.ColumnName];

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.PrimeOldPartsNoColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PrimeOldPartsNo = (string)tempOfrPrimeParts[ofrPrimeParts.PrimeOldPartsNoColumn.ColumnName];
        //        }

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.PrimePartsNoColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PrimePartsNo = (string)tempOfrPrimeParts[ofrPrimeParts.PrimePartsNoColumn.ColumnName];
        //        }

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.PrimePartsNameColumn.ColumnName] is System.DBNull))
        //        {
        //            //tempWork.PrimePartsName = (string)tempOfrPrimeParts[ofrPrimeParts.PrimePartsNameColumn.ColumnName];       // DEL huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
        //            tempWork.PrimePartsName = GetSubString((string)tempOfrPrimeParts[ofrPrimeParts.PrimePartsNameColumn.ColumnName], 40);     // ADD huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
        //        }

        //        tempWork.PrmSetDtlNo2 = (int)tempOfrPrimeParts[ofrPrimeParts.PrmSetDtlNo2Column.ColumnName];
        //        tempWork.PrmSetDtlNo1 = (int)tempOfrPrimeParts[ofrPrimeParts.PrmSetDtlNo1Column.ColumnName];

        //        if (!(tempOfrPrimeParts[ofrPrimeParts.PartsMakerCdColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PartsMakerCd = (string)tempOfrPrimeParts[ofrPrimeParts.PartsMakerCdColumn.ColumnName];
        //        }

        //        tempWork.TbsPartsCdDerivedNo = (int)tempOfrPrimeParts[ofrPrimeParts.TbsPartsCdDerivedNoColumn.ColumnName];
        //        tempWork.TbsPartsCode = (int)tempOfrPrimeParts[ofrPrimeParts.TbsPartsCodeColumn.ColumnName];
        //        tempWork.BusinessSessionId = businessSessionId;
        //        tempWork.EnterpriseCode = enterpriseCode;
        //        tempWork.SearchSectionCode = sectionCode;
        //        tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
        //        //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
        //        tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
        //        tempWork.PmTabSearchRowNum = i + 1;

        //        pmtOfrPrmPtsTmpList.Add(tempWork);
        //    }

        //    if (pmtOfrPrmPtsTmpList.Count > 0)
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }

        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
        //    return status;
        //}
        // --- DEL 2013/08/01 �O�� Redmine#39451 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion 2013/08/01 �O�� �폜

        /// <summary>
        /// �񋟃g�����������ʏ��V�K����
        /// </summary>
        /// <param name="ofrTrimInfo">�񋟃g�����������ʏ��</param>
        /// <param name="pmtOfrTrmInfTmpList">SCM DB�p�񋟃g�����������ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteOfrTrimInfo(PartsInfoDataSet.OfrTrimInfoDataTable ofrTrimInfo,
            ref List<PmtOfrTrmInfTmpWork> pmtOfrTrmInfTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WriteOfrTrimInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < ofrTrimInfo.Count; i++)
            {
                PmtOfrTrmInfTmpWork tempWork = new PmtOfrTrmInfTmpWork();

                PartsInfoDataSet.OfrTrimInfoRow tempOfrTrimInfo = ofrTrimInfo[i] as PartsInfoDataSet.OfrTrimInfoRow;

                tempWork.PartsProperNo = (long)tempOfrTrimInfo[ofrTrimInfo.PartsProperNoColumn.ColumnName];

                if (!(tempOfrTrimInfo[ofrTrimInfo.TrimNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.TrimName = (string)tempOfrTrimInfo[ofrTrimInfo.TrimNameColumn.ColumnName];
                }

                if ((Boolean)tempOfrTrimInfo[ofrTrimInfo.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;  
                }
                else
                {
                    tempWork.SelectionState = 0; 
                }

                if (!(tempOfrTrimInfo[ofrTrimInfo.TrimCodeColumn.ColumnName] is System.DBNull))
                {
                    tempWork.TrimCode = (string)tempOfrTrimInfo[ofrTrimInfo.TrimCodeColumn.ColumnName];
                }
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.PmTabSearchRowNum = i + 1;

                pmtOfrTrmInfTmpList.Add(tempWork);
            }

            if (pmtOfrTrmInfTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// �������i�������ʏ��V�K����
        /// </summary>
        /// <param name="partsInfo">�������i�������ʏ��</param>
        /// <param name="pmtPartsInfoTmpList">SCM DB �������i�������ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WritePartsInfo(PartsInfoDataSet.PartsInfoDataTable partsInfo,
            ref List<PmtPartsInfoTmpWork> pmtPartsInfoTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WritePartsInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < partsInfo.Count; i++)
            {
                PmtPartsInfoTmpWork tempWork = new PmtPartsInfoTmpWork();

                PartsInfoDataSet.PartsInfoRow tempPartsInfo = partsInfo[i] as PartsInfoDataSet.PartsInfoRow;

                tempWork.PartsSearchCode = (int)tempPartsInfo[partsInfo.PartsSearchCodeColumn.ColumnName];
                if (!(tempPartsInfo[partsInfo.TbsPartsCdDerivedNmColumn.ColumnName] is System.DBNull)) 
                {
                    tempWork.AutoEstimatePartsCd = (string)tempPartsInfo[partsInfo.AutoEstimatePartsCdColumn.ColumnName];
                }
                tempWork.TbsPartsCodeFS = (int)tempPartsInfo[partsInfo.TbsPartsCodeFSColumn.ColumnName];

                if (!(tempPartsInfo[partsInfo.FreSrchPrtPropNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.FreSrchPrtPropNo = (string)tempPartsInfo[partsInfo.FreSrchPrtPropNoColumn.ColumnName];
                }

                if (!(tempPartsInfo[partsInfo.ExhaustGasSignColumn.ColumnName] is System.DBNull))
                {
                    tempWork.ExhaustGasSign = (string)tempPartsInfo[partsInfo.ExhaustGasSignColumn.ColumnName];
                }

                if (!(tempPartsInfo[partsInfo.CategorySignModelColumn.ColumnName] is System.DBNull))
                {
                    tempWork.CategorySignModel = (string)tempPartsInfo[partsInfo.CategorySignModelColumn.ColumnName];
                }

                if (!(tempPartsInfo[partsInfo.SeriesModelColumn.ColumnName] is System.DBNull))
                {
                    tempWork.SeriesModel = (string)tempPartsInfo[partsInfo.SeriesModelColumn.ColumnName];
                }

                if (!(tempPartsInfo[partsInfo.PartsNameKanaColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PartsNameKana = (string)tempPartsInfo[partsInfo.PartsNameKanaColumn.ColumnName];
                }

                if (!(tempPartsInfo[partsInfo.OfferDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.OfferDate = (DateTime)tempPartsInfo[partsInfo.OfferDateColumn.ColumnName];
                }

                if (!(tempPartsInfo[partsInfo.NewPrtsNoNoneHyphenColumn.ColumnName] is System.DBNull))
                {
                    tempWork.NewPrtsNoNoneHyphen = (string)tempPartsInfo[partsInfo.NewPrtsNoNoneHyphenColumn.ColumnName];
                }

                if (!(tempPartsInfo[partsInfo.NewPrtsNoWithHyphenColumn.ColumnName] is System.DBNull))
                {
                    tempWork.NewPrtsNoWithHyphen = (string)tempPartsInfo[partsInfo.NewPrtsNoWithHyphenColumn.ColumnName];
                }

                if ((Boolean)tempPartsInfo[partsInfo.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;
                }
                else
                {
                    tempWork.SelectionState = 0;
                }

                tempWork.PartsUniqueNo = (long)tempPartsInfo[partsInfo.PartsUniqueNoColumn.ColumnName];

                if (!(tempPartsInfo[partsInfo.PartsLayerCdColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PartsLayerCd = (string)tempPartsInfo[partsInfo.PartsLayerCdColumn.ColumnName];
                }

                if (!(tempPartsInfo[partsInfo.MakerOfferPartsNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.MakerOfferPartsName = (string)tempPartsInfo[partsInfo.MakerOfferPartsNameColumn.ColumnName];
                }

                tempWork.EquipNarrowingFlag = (int)tempPartsInfo[partsInfo.EquipNarrowingFlagColumn.ColumnName];
                tempWork.TrimNarrowingFlag = (int)tempPartsInfo[partsInfo.TrimNarrowingFlagColumn.ColumnName];
                tempWork.ColorNarrowingFlag = (int)tempPartsInfo[partsInfo.ColorNarrowingFlagColumn.ColumnName];
                tempWork.ColdDistrictsFlag = (int)tempPartsInfo[partsInfo.ColdDistrictsFlagColumn.ColumnName];

                if (!(tempPartsInfo[partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName] is System.DBNull))
                {
                    tempWork.ClgPrtsNoWithHyphen = (string)tempPartsInfo[partsInfo.ClgPrtsNoWithHyphenColumn.ColumnName];
                }

                if (!(tempPartsInfo[partsInfo.CatalogPartsMakerNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.CatalogPartsMakerNm = (string)tempPartsInfo[partsInfo.CatalogPartsMakerNmColumn.ColumnName];
                }

                tempWork.CatalogPartsMakerCd = (int)tempPartsInfo[partsInfo.CatalogPartsMakerCdColumn.ColumnName];

                if (!(tempPartsInfo[partsInfo.StandardNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.StandardName = (string)tempPartsInfo[partsInfo.StandardNameColumn.ColumnName];
                }


                if (!(tempPartsInfo[partsInfo.PartsOpNmColumn.ColumnName] is System.DBNull))
                {
                    //tempWork.PartsOpNm = (string)tempPartsInfo[partsInfo.PartsOpNmColumn.ColumnName];    // DEL huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
                    tempWork.PartsOpNm = GetSubString((string)tempPartsInfo[partsInfo.PartsOpNmColumn.ColumnName], 60);    // ADD huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
                }
                tempWork.PartsQty = (double)tempPartsInfo[partsInfo.PartsQtyColumn.ColumnName];
                tempWork.ModelPrtsAblsFrameNo = (int)tempPartsInfo[partsInfo.ModelPrtsAblsFrameNoColumn.ColumnName];
                tempWork.ModelPrtsAdptFrameNo = (int)tempPartsInfo[partsInfo.ModelPrtsAdptFrameNoColumn.ColumnName];

                //-----DEL songg 2013/06/25 ��Q�� #37010�̑Ή� �N����999999�̏ꍇ�ADateTime.MaxValue��ݒ肷��---->>>>>
                //if (0 != (int)tempPartsInfo[partsInfo.ModelPrtsAblsYmColumn.ColumnName])
                //{
                //    string modelPrtsAblsYm = tempPartsInfo[partsInfo.ModelPrtsAblsYmColumn.ColumnName].ToString();
                //    string year = modelPrtsAblsYm.Substring(0, 4);
                //    string month = modelPrtsAblsYm.Substring(4, 2);
                //    DateTime tempModelPrtsAblsYm = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1);
                //    tempWork.ModelPrtsAblsYm = tempModelPrtsAblsYm;
                //}
                //-----DEL songg 2013/06/25 ��Q�� #37010�̑Ή� �N����999999�̏ꍇ�ADateTime.MaxValue��ݒ肷��----<<<<<
                //-----ADD songg 2013/06/25 ��Q�� #37010�̑Ή� �N����999999�̏ꍇ�ADateTime.MaxValue��ݒ肷��---->>>>>
                if (999999 == (int)tempPartsInfo[partsInfo.ModelPrtsAblsYmColumn.ColumnName])
                {
                    tempWork.ModelPrtsAblsYm = DateTime.MaxValue;
                }
                else if (0 != (int)tempPartsInfo[partsInfo.ModelPrtsAblsYmColumn.ColumnName])
                {
                    string modelPrtsAblsYm = tempPartsInfo[partsInfo.ModelPrtsAblsYmColumn.ColumnName].ToString();
                    string year = modelPrtsAblsYm.Substring(0, 4);
                    string month = modelPrtsAblsYm.Substring(4, 2);
                    DateTime tempModelPrtsAblsYm = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1);
                    tempWork.ModelPrtsAblsYm = tempModelPrtsAblsYm;
                }
                //-----ADD songg 2013/06/25 ��Q�� #37010�̑Ή� �N����999999�̏ꍇ�ADateTime.MaxValue��ݒ肷��----<<<<<

                //-----DEL songg 2013/06/25 ��Q�� #37010�̑Ή� �N����999999�̏ꍇ�ADateTime.MaxValue��ݒ肷��---->>>>>
                //if (0 != (int)tempPartsInfo[partsInfo.ModelPrtsAdptYmColumn.ColumnName])
                //{
                //    string modelPrtsAdptYm = tempPartsInfo[partsInfo.ModelPrtsAdptYmColumn.ColumnName].ToString();
                //    string year = modelPrtsAdptYm.Substring(0, 4);
                //    string month = modelPrtsAdptYm.Substring(4, 2);
                //    DateTime tempModelPrtsAdptYm = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1);
                //    tempWork.ModelPrtsAdptYm = tempModelPrtsAdptYm;
                //}
                //-----DEL songg 2013/06/25 ��Q�� #37010�̑Ή� �N����999999�̏ꍇ�ADateTime.MaxValue��ݒ肷��----<<<<<
                //-----ADD songg 2013/06/25 ��Q�� #37010�̑Ή� �N����999999�̏ꍇ�ADateTime.MaxValue��ݒ肷��---->>>>>
                if (999999 == (int)tempPartsInfo[partsInfo.ModelPrtsAdptYmColumn.ColumnName])
                {
                    tempWork.ModelPrtsAdptYm = DateTime.MaxValue;
                }
                else if (0 != (int)tempPartsInfo[partsInfo.ModelPrtsAdptYmColumn.ColumnName])
                {
                    string modelPrtsAdptYm = tempPartsInfo[partsInfo.ModelPrtsAdptYmColumn.ColumnName].ToString();
                    string year = modelPrtsAdptYm.Substring(0, 4);
                    string month = modelPrtsAdptYm.Substring(4, 2);
                    DateTime tempModelPrtsAdptYm = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1);
                    tempWork.ModelPrtsAdptYm = tempModelPrtsAdptYm;
                }
                //-----ADD songg 2013/06/25 ��Q�� #37010�̑Ή� �N����999999�̏ꍇ�ADateTime.MaxValue��ݒ肷��----<<<<<

                if (!(tempPartsInfo[partsInfo.FigshapeNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.FigshapeNo = (string)tempPartsInfo[partsInfo.FigshapeNoColumn.ColumnName];
                }
                tempWork.TbsPartsCdDerivedNo = (int)tempPartsInfo[partsInfo.TbsPartsCdDerivedNoColumn.ColumnName];
                tempWork.TbsPartsCode = (int)tempPartsInfo[partsInfo.TbsPartsCodeColumn.ColumnName];
                tempWork.FullModelFixedNo = (int)tempPartsInfo[partsInfo.FullModelFixedNoColumn.ColumnName];

                if (!(tempPartsInfo[partsInfo.WorkOrPartsDivNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.WorkOrPartsDivNm = (string)tempPartsInfo[partsInfo.WorkOrPartsDivNmColumn.ColumnName];
                }
                tempWork.PartsCode = (int)tempPartsInfo[partsInfo.PartsCodeColumn.ColumnName];

                if (!(tempPartsInfo[partsInfo.PartsNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PartsName = (string)tempPartsInfo[partsInfo.PartsNameColumn.ColumnName];
                }

                tempWork.PartsNarrowingCode = (int)tempPartsInfo[partsInfo.PartsNarrowingCodeColumn.ColumnName];
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.PmTabSearchRowNum = i + 1;

                pmtPartsInfoTmpList.Add(tempWork);
            }

            if (pmtPartsInfoTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// �݌Ɍ������ʏ��V�K����
        /// </summary>
        /// <param name="stock">�݌Ɍ������ʏ��</param>
        /// <param name="pmtStockTmpList">SCM DB�p�݌Ɍ������ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteStock(PartsInfoDataSet.StockDataTable stock,
            ref List<PmtStockTmpWork> pmtStockTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WriteStock";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < stock.Count; i++)
            {
                PmtStockTmpWork tempWork = new PmtStockTmpWork();

                PartsInfoDataSet.StockRow tempPartsInfo = stock[i] as PartsInfoDataSet.StockRow;

                tempWork.AcpOdrCount = (double)tempPartsInfo[stock.AcpOdrCountColumn.ColumnName];
                tempWork.ArrivalCnt = (double)tempPartsInfo[stock.ArrivalCntColumn.ColumnName];
                if (!(tempPartsInfo[stock.DuplicationShelfNo1Column.ColumnName] is System.DBNull))
                {
                    tempWork.DuplicationShelfNo1 = (string)tempPartsInfo[stock.DuplicationShelfNo1Column.ColumnName];
                }
                if (!(tempPartsInfo[stock.DuplicationShelfNo2Column.ColumnName] is System.DBNull))
                {
                    tempWork.DuplicationShelfNo2 = (string)tempPartsInfo[stock.DuplicationShelfNo2Column.ColumnName];
                }
                if (!(tempPartsInfo[stock.EnterpriseCodeColumn.ColumnName] is System.DBNull))
                {
                    tempWork.EnterpriseCode = (string)tempPartsInfo[stock.EnterpriseCodeColumn.ColumnName];
                }
                tempWork.GoodsMakerCd = (int)tempPartsInfo[stock.GoodsMakerCdColumn.ColumnName];
                if (!(tempPartsInfo[stock.GoodsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsNo = (string)tempPartsInfo[stock.GoodsNoColumn.ColumnName];
                }
                if (!(tempPartsInfo[stock.GoodsNoNoneHyphenColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsNoNoneHyphen = (string)tempPartsInfo[stock.GoodsNoNoneHyphenColumn.ColumnName];
                }
                if (!(tempPartsInfo[stock.LastInventoryUpdateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.LastInventoryUpdate = (DateTime)tempPartsInfo[stock.LastInventoryUpdateColumn.ColumnName];
                }
                if (!(tempPartsInfo[stock.LastSalesDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.LastSalesDate = (DateTime)tempPartsInfo[stock.LastSalesDateColumn.ColumnName];
                }
                if (!(tempPartsInfo[stock.LastStockDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.LastStockDate = (DateTime)tempPartsInfo[stock.LastStockDateColumn.ColumnName];
                }
                tempWork.MaximumStockCnt = (double)tempPartsInfo[stock.MaximumStockCntColumn.ColumnName];
                tempWork.MinimumStockCnt = (double)tempPartsInfo[stock.MinimumStockCntColumn.ColumnName];
                tempWork.MonthOrderCount = (double)tempPartsInfo[stock.MonthOrderCountColumn.ColumnName];
                tempWork.MovingSupliStock = (double)tempPartsInfo[stock.MovingSupliStockColumn.ColumnName];
                tempWork.NmlSalOdrCount = (double)tempPartsInfo[stock.NmlSalOdrCountColumn.ColumnName];
                if (!(tempPartsInfo[stock.PartsManagementDivide1Column.ColumnName] is System.DBNull))
                {
                    tempWork.PartsManagementDivide1 = (string)tempPartsInfo[stock.PartsManagementDivide1Column.ColumnName];
                }
                if (!(tempPartsInfo[stock.PartsManagementDivide2Column.ColumnName] is System.DBNull))
                {
                    tempWork.PartsManagementDivide2 = (string)tempPartsInfo[stock.PartsManagementDivide2Column.ColumnName];
                }
                tempWork.SalesOrderCount = (double)tempPartsInfo[stock.SalesOrderCountColumn.ColumnName];
                tempWork.SalesOrderUnit = (int)tempPartsInfo[stock.SalesOrderUnitColumn.ColumnName];
                if (!(tempPartsInfo[stock.SectionGuideNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.SectionGuideNm = (string)tempPartsInfo[stock.SectionGuideNmColumn.ColumnName];
                }

                if ((Boolean)tempPartsInfo[stock.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;
                }
                else
                {
                    tempWork.SelectionState = 0;
                }

                tempWork.ShipmentCnt = (double)tempPartsInfo[stock.ShipmentCntColumn.ColumnName];
                tempWork.ShipmentPosCnt = (double)tempPartsInfo[stock.ShipmentPosCntColumn.ColumnName];
                if (!(tempPartsInfo[stock.StockCreateDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.StockCreateDate = (DateTime)tempPartsInfo[stock.StockCreateDateColumn.ColumnName];
                }
                tempWork.StockDiv = (int)tempPartsInfo[stock.StockDivColumn.ColumnName];
                if (!(tempPartsInfo[stock.StockNote1Column.ColumnName] is System.DBNull))
                {
                    tempWork.StockNote1 = (string)tempPartsInfo[stock.StockNote1Column.ColumnName];
                }
                if (!(tempPartsInfo[stock.StockNote2Column.ColumnName] is System.DBNull))
                {
                    tempWork.StockNote2 = (string)tempPartsInfo[stock.StockNote2Column.ColumnName];
                }
                tempWork.StockSupplierCode = (int)tempPartsInfo[stock.StockSupplierCodeColumn.ColumnName];
                tempWork.StockTotalPrice = (long)tempPartsInfo[stock.StockTotalPriceColumn.ColumnName];
                tempWork.StockUnitPriceFl = (double)tempPartsInfo[stock.StockUnitPriceFlColumn.ColumnName];
                tempWork.SupplierStock = (double)tempPartsInfo[stock.SupplierStockColumn.ColumnName];
                if (!(tempPartsInfo[stock.UpdateDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.UpdateDate = (DateTime)tempPartsInfo[stock.UpdateDateColumn.ColumnName];
                }
                if (!(tempPartsInfo[stock.WarehouseCodeColumn.ColumnName] is System.DBNull))
                {
                    tempWork.WarehouseCode = (string)tempPartsInfo[stock.WarehouseCodeColumn.ColumnName];
                }
                if (!(tempPartsInfo[stock.WarehouseNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.WarehouseName = (string)tempPartsInfo[stock.WarehouseNameColumn.ColumnName];
                }
                if (!(tempPartsInfo[stock.WarehouseShelfNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.WarehouseShelfNo = (string)tempPartsInfo[stock.WarehouseShelfNoColumn.ColumnName];
                }
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.PmTabSearchRowNum = i + 1;

                pmtStockTmpList.Add(tempWork);
            }

            if (pmtStockTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        #region 2013/08/01 �O�� �폜
        // --- DEL 2013/08/01 �O�� Redmine#39451 --------->>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// ��֕��i�������ʏ��V�K����
        ///// </summary>
        ///// <param name="substPartsInfo">��֕��i�������ʏ��</param>
        ///// <param name="pmtSbPtsInfoTmpList">SCM DB�p��֕��i�������ʃ��X�g</param>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="sectionCode">���_�R�[�h</param>
        ///// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        ///// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        ///// <returns>�X�e�[�^�X</returns>
        //private int WriteSubstPartsInfo(PartsInfoDataSet.SubstPartsInfoDataTable substPartsInfo,
        //    ref List<PmtSbPtsInfoTmpWork> pmtSbPtsInfoTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        //{
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
        //    const string methodName = "WriteSubstPartsInfo";
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

        //    for (int i = 0; i < substPartsInfo.Count; i++)
        //    {
        //        PmtSbPtsInfoTmpWork tempWork = new PmtSbPtsInfoTmpWork();

        //        PartsInfoDataSet.SubstPartsInfoRow tempSubstPartsInfo = substPartsInfo[i] as PartsInfoDataSet.SubstPartsInfoRow;

        //        tempWork.CatalogPartsMakerCd = (int)tempSubstPartsInfo[substPartsInfo.CatalogPartsMakerCdColumn.ColumnName];
        //        if (!(tempSubstPartsInfo[substPartsInfo.PartsNameKanaColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PartsNameKana = (string)tempSubstPartsInfo[substPartsInfo.PartsNameKanaColumn.ColumnName];
        //        }
        //        if (!(tempSubstPartsInfo[substPartsInfo.NewPrtsNoNoneHyphenColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.NewPrtsNoNoneHyphen = (string)tempSubstPartsInfo[substPartsInfo.NewPrtsNoNoneHyphenColumn.ColumnName];
        //        }

        //        if ((Boolean)tempSubstPartsInfo[substPartsInfo.SelectionStateColumn.ColumnName])
        //        {
        //            tempWork.SelectionState = 1; 
        //        }
        //        else
        //        {
        //            tempWork.SelectionState = 0;
        //        }

        //        tempWork.PartsSearchCode = (int)tempSubstPartsInfo[substPartsInfo.PartsSearchCodeColumn.ColumnName];
        //        tempWork.PartsCode = (int)tempSubstPartsInfo[substPartsInfo.PartsCodeColumn.ColumnName];
        //        if (!(tempSubstPartsInfo[substPartsInfo.PartsNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PartsName = (string)tempSubstPartsInfo[substPartsInfo.PartsNameColumn.ColumnName];
        //        }
        //        tempWork.PartsInfoCtrlFlg = (int)tempSubstPartsInfo[substPartsInfo.PartsInfoCtrlFlgColumn.ColumnName];
        //        if (!(tempSubstPartsInfo[substPartsInfo.PartsLayerCdColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PartsLayerCd = (string)tempSubstPartsInfo[substPartsInfo.PartsLayerCdColumn.ColumnName];
        //        }
        //        if (!(tempSubstPartsInfo[substPartsInfo.MakerOfferPartsNameColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.MakerOfferPartsName = (string)tempSubstPartsInfo[substPartsInfo.MakerOfferPartsNameColumn.ColumnName];
        //        }
        //        tempWork.TbsPartsCdDerivedNo = (int)tempSubstPartsInfo[substPartsInfo.TbsPartsCdDerivedNoColumn.ColumnName];
        //        tempWork.TbsPartsCode = (int)tempSubstPartsInfo[substPartsInfo.TbsPartsCodeColumn.ColumnName];
        //        if (!(tempSubstPartsInfo[substPartsInfo.PlrlSubNewPrtNoHypnColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PlrlSubNewPrtNoHypn = (string)tempSubstPartsInfo[substPartsInfo.PlrlSubNewPrtNoHypnColumn.ColumnName];
        //        }
        //        if (!(tempSubstPartsInfo[substPartsInfo.PartsPluralSubstCmntColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.PartsPluralSubstCmnt = (string)tempSubstPartsInfo[substPartsInfo.PartsPluralSubstCmntColumn.ColumnName];
        //        }
        //        tempWork.PartsQty = (double)tempSubstPartsInfo[substPartsInfo.PartsQtyColumn.ColumnName];
        //        tempWork.MainOrSubPartsDivCd = (int)tempSubstPartsInfo[substPartsInfo.MainOrSubPartsDivCdColumn.ColumnName];
        //        tempWork.PartsPluralSubstFlg = (int)tempSubstPartsInfo[substPartsInfo.PartsPluralSubstFlgColumn.ColumnName];
        //        tempWork.NPrtNoWithHypnDspOdr = (int)tempSubstPartsInfo[substPartsInfo.NPrtNoWithHypnDspOdrColumn.ColumnName];
        //        if (!(tempSubstPartsInfo[substPartsInfo.NewPartsNoWithHyphenColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.NewPartsNoWithHyphen = (string)tempSubstPartsInfo[substPartsInfo.NewPartsNoWithHyphenColumn.ColumnName];
        //        }
        //        if (!(tempSubstPartsInfo[substPartsInfo.OldPartsNoWithHyphenColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.OldPartsNoWithHyphen = (string)tempSubstPartsInfo[substPartsInfo.OldPartsNoWithHyphenColumn.ColumnName];
        //        }
        //        if (!(tempSubstPartsInfo[substPartsInfo.CatalogPartsMakerNmColumn.ColumnName] is System.DBNull))
        //        {
        //            tempWork.CatalogPartsMakerNm = (string)tempSubstPartsInfo[substPartsInfo.CatalogPartsMakerNmColumn.ColumnName];
        //        }
        //        tempWork.BusinessSessionId = businessSessionId;
        //        tempWork.EnterpriseCode = enterpriseCode;
        //        tempWork.SearchSectionCode = sectionCode;
        //        tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
        //        //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
        //        tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
        //        tempWork.PmTabSearchRowNum = i + 1;

        //        pmtSbPtsInfoTmpList.Add(tempWork);
        //    }

        //    if (pmtSbPtsInfoTmpList.Count > 0)
        //    {
        //        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    }

        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
        //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
        //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
        //    return status;
        //}
        // --- DEL 2013/08/01 �O�� Redmine#39451 ---------<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion 2013/08/01 �O�� �폜

        /// <summary>
        /// TBO��񌟍����ʏ��V�K����
        /// </summary>
        /// <param name="tboInfo">TBO��񌟍����ʏ��</param>
        /// <param name="pmtTBOInfoTmpList">SCM DB�pTBO��񌟍����ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteTBOInfo(PartsInfoDataSet.TBOInfoDataTable tboInfo,
            ref List<PmtTBOInfoTmpWork> pmtTBOInfoTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WriteTBOInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < tboInfo.Count; i++)
            {
                PmtTBOInfoTmpWork tempWork = new PmtTBOInfoTmpWork();

                PartsInfoDataSet.TBOInfoRow tempTBOInfo = tboInfo[i] as PartsInfoDataSet.TBOInfoRow;

                tempWork.GoodsMGroup = (int)tempTBOInfo[tboInfo.GoodsMGroupColumn.ColumnName];
                tempWork.OfferKubun = (int)tempTBOInfo[tboInfo.OfferKubunColumn.ColumnName];
                if (!(tempTBOInfo[tboInfo.PrimePartsKanaNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PrimePartsKanaName = (string)tempTBOInfo[tboInfo.PrimePartsKanaNameColumn.ColumnName];
                }
                if (!(tempTBOInfo[tboInfo.OfferDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.OfferDate = (DateTime)tempTBOInfo[tboInfo.OfferDateColumn.ColumnName];
                }
                if (!(tempTBOInfo[tboInfo.JoinDestMakerNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.JoinDestMakerNm = (string)tempTBOInfo[tboInfo.JoinDestMakerNmColumn.ColumnName];
                }

                if ((Boolean)tempTBOInfo[tboInfo.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1; 
                }
                else
                {
                    tempWork.SelectionState = 0;  
                }

                tempWork.CatalogDeleteFlag = (int)tempTBOInfo[tboInfo.CatalogDeleteFlagColumn.ColumnName];
                tempWork.PartsAttribute = (int)tempTBOInfo[tboInfo.PartsAttributeColumn.ColumnName];
                if (!(tempTBOInfo[tboInfo.PrimePartsSpecialNoteColumn.ColumnName] is System.DBNull))
                {
                    //tempWork.PrimePartsSpecialNote = (string)tempTBOInfo[tboInfo.PrimePartsSpecialNoteColumn.ColumnName];     // DEL huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
                    tempWork.PrimePartsSpecialNote = GetSubString((string)tempTBOInfo[tboInfo.PrimePartsSpecialNoteColumn.ColumnName], 40);    // ADD huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
                }
                if (!(tempTBOInfo[tboInfo.PartsLayerCdColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PartsLayerCd = (string)tempTBOInfo[tboInfo.PartsLayerCdColumn.ColumnName];
                }
                if (!(tempTBOInfo[tboInfo.PrimePartsNameColumn.ColumnName] is System.DBNull))
                {
                    //tempWork.PrimePartsName = (string)tempTBOInfo[tboInfo.PrimePartsNameColumn.ColumnName];    // DEL huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
                    tempWork.PrimePartsName = GetSubString((string)tempTBOInfo[tboInfo.PrimePartsNameColumn.ColumnName], 40);     // ADD huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
                }
                if (!(tempTBOInfo[tboInfo.EquipSpecialNoteColumn.ColumnName] is System.DBNull))
                {
                    tempWork.EquipSpecialNote = (string)tempTBOInfo[tboInfo.EquipSpecialNoteColumn.ColumnName];
                }
                tempWork.JoinQty = (double)tempTBOInfo[tboInfo.JoinQtyColumn.ColumnName];
                if (!(tempTBOInfo[tboInfo.JoinDestPartsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.JoinDestPartsNo = (string)tempTBOInfo[tboInfo.JoinDestPartsNoColumn.ColumnName];
                }
                tempWork.JoinDestMakerCd = (int)tempTBOInfo[tboInfo.JoinDestMakerCdColumn.ColumnName];
                tempWork.CarInfoJoinDispOrder = (int)tempTBOInfo[tboInfo.CarInfoJoinDispOrderColumn.ColumnName];
                if (!(tempTBOInfo[tboInfo.CarInfoJoinDispOrderColumn.ColumnName] is System.DBNull))
                {
                    //tempWork.EquipName = (string)tempTBOInfo[tboInfo.EquipNameColumn.ColumnName];    // DEL huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
                    tempWork.EquipName = GetSubString((string)tempTBOInfo[tboInfo.EquipNameColumn.ColumnName], 30);     // ADD huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
                }
                tempWork.EquipGenreCode = (int)tempTBOInfo[tboInfo.EquipGenreCodeColumn.ColumnName];
                tempWork.TbsPartsCdDerivedNo = (int)tempTBOInfo[tboInfo.TbsPartsCdDerivedNoColumn.ColumnName];
                tempWork.TbsPartsCode = (int)tempTBOInfo[tboInfo.TbsPartsCodeColumn.ColumnName];
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.PmTabSearchRowNum = i + 1;

                pmtTBOInfoTmpList.Add(tempWork);
            }

            if (pmtTBOInfoTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// ���[�U�[���i�������ʏ��V�K����
        /// </summary>
        /// <param name="usrGoodsInfo">���[�U�[���i�������ʏ��</param>
        /// <param name="pmtUrGdsInfTmpList">SCM DB�p���[�U�[���i�������ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteUsrGoodsInfo(PartsInfoDataSet.UsrGoodsInfoDataTable usrGoodsInfo,
            ref List<PmtUrGdsInfTmpWork> pmtUrGdsInfTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WriteUsrGoodsInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < usrGoodsInfo.Count; i++)
            {
                PmtUrGdsInfTmpWork tempWork = new PmtUrGdsInfTmpWork();

                PartsInfoDataSet.UsrGoodsInfoRow tempUsrGoodsInfo = usrGoodsInfo[i] as PartsInfoDataSet.UsrGoodsInfoRow;
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsSpecialNoteOfferColumn.ColumnName] is System.DBNull))
                {
                    //tempWork.GoodsSpecialNoteOffer = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsSpecialNoteOfferColumn.ColumnName];    // DEL huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
                    tempWork.GoodsSpecialNoteOffer = GetSubString((string)tempUsrGoodsInfo[usrGoodsInfo.GoodsSpecialNoteOfferColumn.ColumnName], 40);    // ADD huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.FreSrchPrtPropNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.FreSrchPrtPropNo = (string)tempUsrGoodsInfo[usrGoodsInfo.FreSrchPrtPropNoColumn.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.RateDivUnCstColumn.ColumnName] is System.DBNull))
                {
                    tempWork.RateDivUnCst = (string)tempUsrGoodsInfo[usrGoodsInfo.RateDivUnCstColumn.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.RateDivSalUnPrcColumn.ColumnName] is System.DBNull))
                {
                    tempWork.RateDivSalUnPrc = (string)tempUsrGoodsInfo[usrGoodsInfo.RateDivSalUnPrcColumn.ColumnName];
                }

                if (!(tempUsrGoodsInfo[usrGoodsInfo.PartsPriceStDateColumn.ColumnName] is System.DBNull))
                {
                    DateTime dt = (DateTime)tempUsrGoodsInfo[usrGoodsInfo.PartsPriceStDateColumn.ColumnName];

                    if (!dt.Equals(DateTime.MinValue))
                    {
                        //tempWork.PartsPriceStDate = Convert.ToInt32(dt.ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                        tempWork.PartsPriceStDate = Convert.ToInt32(dt.ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                    }
                    else
                    {
                        tempWork.PartsPriceStDate = 0;
                    }
                }
                tempWork.SelectedGoodsNoDiv = (int)tempUsrGoodsInfo[usrGoodsInfo.SelectedGoodsNoDivColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.PrtMakerNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PrtMakerName = (string)tempUsrGoodsInfo[usrGoodsInfo.PrtMakerNameColumn.ColumnName];
                }
                tempWork.PrtMakerCode = (int)tempUsrGoodsInfo[usrGoodsInfo.PrtMakerCodeColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.PrtGoodsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PrtGoodsNo = (string)tempUsrGoodsInfo[usrGoodsInfo.PrtGoodsNoColumn.ColumnName];
                }
                tempWork.SelectedListPriceDiv = (int)tempUsrGoodsInfo[usrGoodsInfo.SelectedListPriceDivColumn.ColumnName];
                tempWork.PriceSelectDiv = (int)tempUsrGoodsInfo[usrGoodsInfo.PriceSelectDivColumn.ColumnName];
                tempWork.CustRateGrpCode = (int)tempUsrGoodsInfo[usrGoodsInfo.CustRateGrpCodeColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.RateDivLPriceColumn.ColumnName] is System.DBNull))
                {
                    tempWork.RateDivLPrice = (string)tempUsrGoodsInfo[usrGoodsInfo.RateDivLPriceColumn.ColumnName];
                }
                tempWork.SelectedListPrice = (double)tempUsrGoodsInfo[usrGoodsInfo.SelectedListPriceColumn.ColumnName];
                tempWork.PrimeDispOrder = (int)tempUsrGoodsInfo[usrGoodsInfo.PrimeDispOrderColumn.ColumnName];

                if ((Boolean)tempUsrGoodsInfo[usrGoodsInfo.CalcPriceColumn.ColumnName])
                {
                    tempWork.CalcPrice = 1;  
                }
                else
                {
                    tempWork.CalcPrice = 0;  
                }


                if (!(tempUsrGoodsInfo[usrGoodsInfo.JoinSrcPrtsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.JoinSrcPrtsNo = (string)tempUsrGoodsInfo[usrGoodsInfo.JoinSrcPrtsNoColumn.ColumnName];
                }
                tempWork.SrchPNmAcqrCarMkrCd = (int)tempUsrGoodsInfo[usrGoodsInfo.SrchPNmAcqrCarMkrCdColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.SearchPartsHalfNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.SearchPartsHalfName = (string)tempUsrGoodsInfo[usrGoodsInfo.SearchPartsHalfNameColumn.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.SearchPartsFullNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.SearchPartsFullName = (string)tempUsrGoodsInfo[usrGoodsInfo.SearchPartsFullNameColumn.ColumnName];
                }
                //UPD 2013/08/05 TAKAGAWA Redmine#39564�Ή� ---------->>>>>>>>>>
                //tempWork.SalesUnitPriceTaxInc = Convert.ToInt64(tempUsrGoodsInfo[usrGoodsInfo.SalesUnitPriceTaxIncColumn.ColumnName]);
                tempWork.SalesUnPrcTaxIncFl = (double)tempUsrGoodsInfo[usrGoodsInfo.SalesUnitPriceTaxIncColumn.ColumnName];
                //UPD 2013/08/05 TAKAGAWA Redmine#39564�Ή� ----------<<<<<<<<<<
                tempWork.UnitCostTaxInc = (double)tempUsrGoodsInfo[usrGoodsInfo.UnitCostTaxIncColumn.ColumnName];
                tempWork.PriceTaxInc = (double)tempUsrGoodsInfo[usrGoodsInfo.PriceTaxIncColumn.ColumnName];
                tempWork.PrimeDisplayCode = (int)tempUsrGoodsInfo[usrGoodsInfo.PrimeDisplayCodeColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.PrmSetDtlName2Column.ColumnName] is System.DBNull))
                {
                    tempWork.PrmSetDtlName2 = (string)tempUsrGoodsInfo[usrGoodsInfo.PrmSetDtlName2Column.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsOfrNameKanaColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsOfrNameKana = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsOfrNameKanaColumn.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsOfrNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsOfrName = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsOfrNameColumn.ColumnName];
                }
                tempWork.GoodsKindResolved = (int)tempUsrGoodsInfo[usrGoodsInfo.GoodsKindResolvedColumn.ColumnName];
                tempWork.QTY = (double)tempUsrGoodsInfo[usrGoodsInfo.QTYColumn.ColumnName];
                //UPD 2013/08/05 TAKAGAWA Redmine#39564�Ή� ---------->>>>>>>>>>
                //tempWork.SalesUnitPriceTaxExc = Convert.ToInt64(tempUsrGoodsInfo[usrGoodsInfo.SalesUnitPriceTaxExcColumn.ColumnName]);
                tempWork.SalesUnPrcTaxExcFl = (double)tempUsrGoodsInfo[usrGoodsInfo.SalesUnitPriceTaxExcColumn.ColumnName];
                //UPD 2013/08/05 TAKAGAWA Redmine#39564�Ή� ----------<<<<<<<<<<
                tempWork.UnitCostTaxExc = (double)tempUsrGoodsInfo[usrGoodsInfo.UnitCostTaxExcColumn.ColumnName];
                tempWork.PriceTaxExc = (double)tempUsrGoodsInfo[usrGoodsInfo.PriceTaxExcColumn.ColumnName];
                tempWork.GoodsKindCode = (int)tempUsrGoodsInfo[usrGoodsInfo.GoodsKindCodeColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.NewGoodsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.NewGoodsNo = (string)tempUsrGoodsInfo[usrGoodsInfo.NewGoodsNoColumn.ColumnName];
                }

                if ((Boolean)tempUsrGoodsInfo[usrGoodsInfo.SelectionCompleteColumn.ColumnName])
                {
                    tempWork.SelectionComplete = 1; 
                }
                else
                {
                    tempWork.SelectionComplete = 0; 
                }

                tempWork.OfferKubun = (int)tempUsrGoodsInfo[usrGoodsInfo.OfferKubunColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsMakerNmColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsMakerNm = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsMakerNmColumn.ColumnName];
                }

                if ((Boolean)tempUsrGoodsInfo[usrGoodsInfo.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;   
                }
                else
                {
                    tempWork.SelectionState = 0;  
                }

                tempWork.GoodsMGroup = (int)tempUsrGoodsInfo[usrGoodsInfo.GoodsMGroupColumn.ColumnName];
                tempWork.OfferDataDiv = (int)tempUsrGoodsInfo[usrGoodsInfo.OfferDataDivColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.UpdateDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.UpdateDate = (DateTime)tempUsrGoodsInfo[usrGoodsInfo.UpdateDateColumn.ColumnName];
                }
                tempWork.EnterpriseGanreCode = (int)tempUsrGoodsInfo[usrGoodsInfo.EnterpriseGanreCodeColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsSpecialNoteColumn.ColumnName] is System.DBNull))
                {
                    //tempWork.GoodsSpecialNote = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsSpecialNoteColumn.ColumnName];    // DEL huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
                    tempWork.GoodsSpecialNote = GetSubString((string)tempUsrGoodsInfo[usrGoodsInfo.GoodsSpecialNoteColumn.ColumnName], 40);    // ADD huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsNote2Column.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsNote2 = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsNote2Column.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsNote1Column.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsNote1 = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsNote1Column.ColumnName];
                }
                tempWork.GoodsKind = (int)tempUsrGoodsInfo[usrGoodsInfo.GoodsKindColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.OfferDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.OfferDate = (DateTime)tempUsrGoodsInfo[usrGoodsInfo.OfferDateColumn.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsNoNoneHyphenColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsNoNoneHyphen = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsNoNoneHyphenColumn.ColumnName];
                }
                tempWork.TaxationDivCd = (int)tempUsrGoodsInfo[usrGoodsInfo.TaxationDivCdColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsRateRankColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsRateRank = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsRateRankColumn.ColumnName];
                }
                tempWork.DisplayOrder = (int)tempUsrGoodsInfo[usrGoodsInfo.DisplayOrderColumn.ColumnName];
                tempWork.BlGoodsCode = (int)tempUsrGoodsInfo[usrGoodsInfo.BlGoodsCodeColumn.ColumnName];
                if (!(tempUsrGoodsInfo[usrGoodsInfo.JanColumn.ColumnName] is System.DBNull))
                {
                    tempWork.Jan = (string)tempUsrGoodsInfo[usrGoodsInfo.JanColumn.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsNameKanaColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsNameKana = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsNameKanaColumn.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsNameColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsName = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsNameColumn.ColumnName];
                }
                if (!(tempUsrGoodsInfo[usrGoodsInfo.GoodsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsNo = (string)tempUsrGoodsInfo[usrGoodsInfo.GoodsNoColumn.ColumnName];
                }
                tempWork.GoodsMakerCd = (int)tempUsrGoodsInfo[usrGoodsInfo.GoodsMakerCdColumn.ColumnName];
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.PmTabSearchRowNum = i + 1;

                pmtUrGdsInfTmpList.Add(tempWork);
            }

            if (pmtUrGdsInfTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// ���[�U�[���i�������ʏ��V�K����
        /// </summary>
        /// <param name="usrGoodsPrice">���[�U�[���i�������ʏ��</param>
        /// <param name="pmtUrGdsPriTmpList">SCM DB�p���[�U�[���i�������ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteUsrGoodsPrice(PartsInfoDataSet.UsrGoodsPriceDataTable usrGoodsPrice,
            ref List<PmtUrGdsPriTmpWork> pmtUrGdsPriTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WriteUsrGoodsPrice";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < usrGoodsPrice.Count; i++)
            {
                PmtUrGdsPriTmpWork tempWork = new PmtUrGdsPriTmpWork();

                PartsInfoDataSet.UsrGoodsPriceRow tempUsrGoodsPrice = usrGoodsPrice[i] as PartsInfoDataSet.UsrGoodsPriceRow;

                tempWork.GoodsMakerCd = (int)tempUsrGoodsPrice[usrGoodsPrice.GoodsMakerCdColumn.ColumnName];
                if (!(tempUsrGoodsPrice[usrGoodsPrice.UpdateDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.UpdateDate = (DateTime)tempUsrGoodsPrice[usrGoodsPrice.UpdateDateColumn.ColumnName];
                }
                if (!(tempUsrGoodsPrice[usrGoodsPrice.EnterpriseCodeColumn.ColumnName] is System.DBNull))
                {
                    tempWork.EnterpriseCode = (string)tempUsrGoodsPrice[usrGoodsPrice.EnterpriseCodeColumn.ColumnName];
                }
                if (!(tempUsrGoodsPrice[usrGoodsPrice.OfferDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.OfferDate = (DateTime)tempUsrGoodsPrice[usrGoodsPrice.OfferDateColumn.ColumnName];
                }
                tempWork.OpenPriceDiv = (int)tempUsrGoodsPrice[usrGoodsPrice.OpenPriceDivColumn.ColumnName];
                tempWork.StockRate = (double)tempUsrGoodsPrice[usrGoodsPrice.StockRateColumn.ColumnName];
                tempWork.SalesUnitCost = (double)tempUsrGoodsPrice[usrGoodsPrice.SalesUnitCostColumn.ColumnName];
                tempWork.ListPrice = Convert.ToInt64(tempUsrGoodsPrice[usrGoodsPrice.ListPriceColumn.ColumnName]); 
                if (!(tempUsrGoodsPrice[usrGoodsPrice.PriceStartDateColumn.ColumnName] is System.DBNull))
                {
                    tempWork.PriceStartDate = (DateTime)tempUsrGoodsPrice[usrGoodsPrice.PriceStartDateColumn.ColumnName];
                }
                if (!(tempUsrGoodsPrice[usrGoodsPrice.GoodsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.GoodsNo = (string)tempUsrGoodsPrice[usrGoodsPrice.GoodsNoColumn.ColumnName];
                }
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.PmTabSearchRowNum = i + 1;

                pmtUrGdsPriTmpList.Add(tempWork);
            }

            if (pmtUrGdsPriTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// ���[�U�[�����������ʏ��V�K����
        /// </summary>
        /// <param name="usrJoinParts">���[�U�[�����������ʏ��</param>
        /// <param name="pmtUrJinPtsTmpList">SCM DB�p���[�U�[�����������ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteUsrJoinParts(PartsInfoDataSet.UsrJoinPartsDataTable usrJoinParts,
            ref List<PmtUrJinPtsTmpWork> pmtUrJinPtsTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WriteUsrJoinParts";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < usrJoinParts.Count; i++)
            {
                PmtUrJinPtsTmpWork tempWork = new PmtUrJinPtsTmpWork();

                PartsInfoDataSet.UsrJoinPartsRow tempUsrJoinParts = usrJoinParts[i] as PartsInfoDataSet.UsrJoinPartsRow;

                tempWork.JoinDispOrder = (int)tempUsrJoinParts[usrJoinParts.JoinDispOrderColumn.ColumnName];
                tempWork.PrimeDispOrder = (int)tempUsrJoinParts[usrJoinParts.PrimeDispOrderColumn.ColumnName];

                if ((Boolean)tempUsrJoinParts[usrJoinParts.PrmSettingFlgColumn.ColumnName])
                {
                    tempWork.PrmSettingFlg = 1;  
                }
                else
                {
                    tempWork.PrmSettingFlg = 0;    
                }

                if (!(tempUsrJoinParts[usrJoinParts.JoinOfferDateColumn.ColumnName] is System.DBNull))
                {
                    DateTime tempDate = (DateTime)tempUsrJoinParts[usrJoinParts.JoinOfferDateColumn.ColumnName];

                    if (!tempDate.Equals(DateTime.MinValue))
                    {
                        //tempWork.JoinOfferDate = Convert.ToInt32(tempDate.ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                        tempWork.JoinOfferDate = Convert.ToInt32(tempDate.ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                    }
                    else
                    {
                        tempWork.JoinOfferDate = 0;
                    }
                }

                if ((Boolean)tempUsrJoinParts[usrJoinParts.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;  
                }
                else
                {
                    tempWork.SelectionState = 0; 
                }

                if (!(tempUsrJoinParts[usrJoinParts.JoinSpecialNoteColumn.ColumnName] is System.DBNull))
                {
                    tempWork.JoinSpecialNote = (string)tempUsrJoinParts[usrJoinParts.JoinSpecialNoteColumn.ColumnName];    // DEL huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
                    tempWork.JoinSpecialNote = GetSubString((string)tempUsrJoinParts[usrJoinParts.JoinSpecialNoteColumn.ColumnName], 40);    // ADD huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
                }
                tempWork.JoinQty = (double)tempUsrJoinParts[usrJoinParts.JoinQtyColumn.ColumnName];
                if (!(tempUsrJoinParts[usrJoinParts.JoinDestPartsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.JoinDestPartsNo = (string)tempUsrJoinParts[usrJoinParts.JoinDestPartsNoColumn.ColumnName];
                }
                tempWork.JoinDestMakerCd = (int)tempUsrJoinParts[usrJoinParts.JoinDestMakerCdColumn.ColumnName];
                if (!(tempUsrJoinParts[usrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName] is System.DBNull))
                {
                    tempWork.JoinSrcPartsNoWithH = (string)tempUsrJoinParts[usrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName];
                }
                if (!(tempUsrJoinParts[usrJoinParts.JoinSrcPartsNoNoneHColumn.ColumnName] is System.DBNull))
                {
                    tempWork.JoinSrcPartsNoNoneH = (string)tempUsrJoinParts[usrJoinParts.JoinSrcPartsNoNoneHColumn.ColumnName];
                }
                tempWork.JoinSourceMakerCode = (int)tempUsrJoinParts[usrJoinParts.JoinSourceMakerCodeColumn.ColumnName];
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.PmTabSearchRowNum = i + 1;

                pmtUrJinPtsTmpList.Add(tempWork);
            }


            if (pmtUrJinPtsTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        /// <summary>
        /// UsrSetParts���V�K����
        /// </summary>
        /// <param name="usrSetParts">UsrSetParts���</param>
        /// <param name="pmtUrSetPtsTmpList">pmtUrSetPtsTmpList</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WriteUsrSetParts(PartsInfoDataSet.UsrSetPartsDataTable usrSetParts,
            ref List<PmtUrSetPtsTmpWork> pmtUrSetPtsTmpList, string enterpriseCode, string sectionCode, string businessSessionId, string pmTabSearchGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WriteUsrSetParts";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            for (int i = 0; i < usrSetParts.Count; i++)
            {
                PmtUrSetPtsTmpWork tempWork = new PmtUrSetPtsTmpWork();

                PartsInfoDataSet.UsrSetPartsRow tempUsrSetParts = usrSetParts[i] as PartsInfoDataSet.UsrSetPartsRow;

                tempWork.ParentGoodsMakerCd = (int)tempUsrSetParts[usrSetParts.ParentGoodsMakerCdColumn.ColumnName];

                if ((Boolean)tempUsrSetParts[usrSetParts.PrmSettingFlgColumn.ColumnName])
                {
                    tempWork.PrmSettingFlg = 1;     
                }
                else
                {
                    tempWork.PrmSettingFlg = 0;     
                }

                if ((Boolean)tempUsrSetParts[usrSetParts.SelectionStateColumn.ColumnName])
                {
                    tempWork.SelectionState = 1;    
                }
                else
                {
                    tempWork.SelectionState = 0;   
                }

                if (!(tempUsrSetParts[usrSetParts.CatalogShapeNoColumn.ColumnName] is System.DBNull))
                {
                 tempWork.CatalogShapeNo = (string)tempUsrSetParts[usrSetParts.CatalogShapeNoColumn.ColumnName];   
                }
                if (!(tempUsrSetParts[usrSetParts.SetSpecialNoteColumn.ColumnName] is System.DBNull))
                {
                    //tempWork.SetSpecialNote = (string)tempUsrSetParts[usrSetParts.SetSpecialNoteColumn.ColumnName];    // DEL huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
                    tempWork.SetSpecialNote = GetSubString((string)tempUsrSetParts[usrSetParts.SetSpecialNoteColumn.ColumnName], 40);    // ADD huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� 
                }
                tempWork.DisplayOrder = (int)tempUsrSetParts[usrSetParts.DisplayOrderColumn.ColumnName];
                tempWork.CntFl = (double)tempUsrSetParts[usrSetParts.CntFlColumn.ColumnName];
                if (!(tempUsrSetParts[usrSetParts.SubGoodsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.SubGoodsNo = (string)tempUsrSetParts[usrSetParts.SubGoodsNoColumn.ColumnName];
                }
                tempWork.SubGoodsMakerCd = (int)tempUsrSetParts[usrSetParts.SubGoodsMakerCdColumn.ColumnName];
                if (!(tempUsrSetParts[usrSetParts.ParentGoodsNoColumn.ColumnName] is System.DBNull))
                {
                    tempWork.ParentGoodsNo = (string)tempUsrSetParts[usrSetParts.ParentGoodsNoColumn.ColumnName];
                }
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.PmTabSearchRowNum = i + 1;

                pmtUrSetPtsTmpList.Add(tempWork);
            }


            if (pmtUrSetPtsTmpList.Count > 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }
        #endregion �� ���i��������17�e�[�u���ۑ�����

        #region �� �󒍃}�X�^�i�ԗ��j�o�^
        /// <summary>
        /// �󒍃}�X�^�i�ԗ��j�o�^
        /// </summary>
        /// <param name="searchedCarInfo">�ԗ��f�[�^</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabDtlDiscGuid">PMTAB���׎���GUID</param>
        /// <param name="searchSectionCode">�������_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        // UPD 2013/12/19 VSS[020_10] ����ýď�Q��4 �g�� ------------------->>>>>>>>>>>>>>>
        #region ���\�[�X
        //// UPD 2013/12/12 SCM�d�|�ꗗ��10609�Ή� ------------------------------>>>>>
        ////private int WritePmTabAcpOdrCar(PMKEN01010E searchedCarInfo, string enterpriseCode, string businessSessionId, string searchSectionCode, string pmTabDtlDiscGuid)
        //private int WritePmTabAcpOdrCar(PMKEN01010E searchedCarInfo, string enterpriseCode, string businessSessionId, string searchSectionCode, string pmTabDtlDiscGuid, PmTabSalesDtCarWork pmTabSalesDtCarWork)
        //// UPD 2013/12/12 SCM�d�|�ꗗ��10609�Ή� ------------------------------<<<<<
        #endregion
        private int WritePmTabAcpOdrCar(PMKEN01010E searchedCarInfo, string enterpriseCode, string businessSessionId, string searchSectionCode, string pmTabDtlDiscGuid)
        // UPD 2013/12/19 VSS[020_10] ����ýď�Q��4 �g�� -------------------<<<<<<<<<<<<<<<
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WritePmTabAcpOdrCar";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            IPmTabAcpOdrCarDB iPmTabAcpOdrCarDB = MediationPmTabAcpOdrCarDB.GetPmTabAcpOdrCarDB();
            ArrayList acceptOdrCarList = new ArrayList();

            // �^�����
            //PMKEN01010E.CarModelInfoDataTable carModelInfoDataTable = searchedCarInfo.CarModelInfo;            // DEL huangt 2013/06/21 �\�[�X�`�F�b�N�m�F�����ꗗ��No.48�̑Ή�
            PMKEN01010E.CarModelInfoDataTable carModelInfoDataTable = searchedCarInfo.CarModelInfoSummarized;    // ADD huangt 2013/06/21 �\�[�X�`�F�b�N�m�F�����ꗗ��No.48�̑Ή�
            // ��ʗp�^�����
            PMKEN01010E.CarModelUIDataTable carModelUIDataTable = searchedCarInfo.CarModelUIData;
            // �J���[���
            PMKEN01010E.ColorCdInfoDataTable colorCdInfoDataTable = searchedCarInfo.ColorCdInfo;
            // �g�������
            PMKEN01010E.TrimCdInfoDataTable trimCdInfoDataTable = searchedCarInfo.TrimCdInfo;


            // �󒍃}�X�^�i�ԗ��j �f�[�^���N���X�֊i�[����
            PmTabAcpOdrCarWork pmTabAcpOdrCarWork = new PmTabAcpOdrCarWork();


            if (carModelInfoDataTable.Rows.Count > 0)
            {
                PMKEN01010E.CarModelInfoRow carModelInfoRow = carModelInfoDataTable[0] as PMKEN01010E.CarModelInfoRow;

                pmTabAcpOdrCarWork.MakerCode = carModelInfoRow.MakerCode;              // ���[�J�[�R�[�h
                pmTabAcpOdrCarWork.MakerFullName = carModelInfoRow.MakerFullName;      // ���[�J�[�S�p����
                pmTabAcpOdrCarWork.MakerHalfName = carModelInfoRow.MakerHalfName;      // ���[�J�[���p����
                pmTabAcpOdrCarWork.ModelCode = carModelInfoRow.ModelCode;              // �Ԏ�R�[�h
                pmTabAcpOdrCarWork.ModelSubCode = carModelInfoRow.ModelSubCode;        // �Ԏ�T�u�R�[�h

                // �Ԏ�S�p����
                if (carModelInfoRow.ModelFullName.Length > 15)
                {
                    pmTabAcpOdrCarWork.ModelFullName = carModelInfoRow.ModelFullName.Substring(0, 15);
                }
                else
                {
                    pmTabAcpOdrCarWork.ModelFullName = carModelInfoRow.ModelFullName;
                }

                // �Ԏ피�p����
                if (carModelInfoRow.ModelHalfName.Length > 15)
                {
                    pmTabAcpOdrCarWork.ModelHalfName = carModelInfoRow.ModelHalfName.Substring(0, 15);
                }
                else
                {
                    pmTabAcpOdrCarWork.ModelHalfName = carModelInfoRow.ModelHalfName;
                }

                pmTabAcpOdrCarWork.ExhaustGasSign = carModelInfoRow.ExhaustGasSign;              // �r�K�X�L��
                pmTabAcpOdrCarWork.SeriesModel = carModelInfoRow.SeriesModel;                    // �V���[�Y�^��
                pmTabAcpOdrCarWork.CategorySignModel = carModelInfoRow.CategorySignModel;        // �^���i�ޕʋL���j
                pmTabAcpOdrCarWork.FullModel = carModelInfoRow.FullModel;                        // �^���i�t���^�j

                pmTabAcpOdrCarWork.FrameModel = carModelInfoRow.FrameModel;                      // �ԑ�^��
                //pmTabAcpOdrCarWork.EngineModelNm = carModelInfoRow.EngineDisplaceNm;             // �G���W���^������// DEL songg 2013/07/08 ��Q�� #37983�̑Ή�
                pmTabAcpOdrCarWork.EngineModelNm = carModelInfoRow.EngineModelNm;             // �G���W���^������  // ADD songg 2013/07/08 ��Q�� #37983�̑Ή�
                pmTabAcpOdrCarWork.RelevanceModel = carModelInfoRow.RelevanceModel;              // �֘A�^��
                pmTabAcpOdrCarWork.SubCarNmCd = carModelInfoRow.SubCarNmCd;                      // �T�u�Ԗ��R�[�h
                pmTabAcpOdrCarWork.ModelGradeSname = carModelInfoRow.ModelGradeSname;            // �^���O���[�h����
                pmTabAcpOdrCarWork.DomesticForeignCode = carModelInfoRow.DomesticForeignCode;           // ���Y�^�O�ԋ敪
            }


            if (carModelUIDataTable.Rows.Count > 0)
            {
                PMKEN01010E.CarModelUIRow carModelUIRow = carModelUIDataTable[0] as PMKEN01010E.CarModelUIRow;

                pmTabAcpOdrCarWork.ModelDesignationNo = carModelUIRow.ModelDesignationNo;        // �^���w��ԍ�
                pmTabAcpOdrCarWork.CategoryNo = carModelUIRow.CategoryNo;                        // �ޕʔԍ�

                // UPD 2013/12/19 VSS[020_10] ����ýď�Q��4 �g�� ------------------->>>>>>>>>>>>>>>
                #region ���\�[�X
                //// UPD 2013/12/12 SCM�d�|�ꗗ��10609�Ή� ----------------------->>>>>
                ////pmTabAcpOdrCarWork.FrameNo = carModelUIRow.FrameNo;                              // �ԑ�ԍ�
                //pmTabAcpOdrCarWork.FrameNo = pmTabSalesDtCarWork.FrameNo;                          // �ԑ�ԍ�
                //// UPD 2013/12/12 SCM�d�|�ꗗ��10609�Ή� -----------------------<<<<<
                #endregion
                pmTabAcpOdrCarWork.FrameNo = carModelUIRow.FrameNo;                              // �ԑ�ԍ�
                // UPD 2013/12/19 VSS[020_10] ����ýď�Q��4 �g�� -------------------<<<<<<<<<<<<<<<

                pmTabAcpOdrCarWork.SearchFrameNo = carModelUIRow.SearchFrameNo;                  // �ԑ�ԍ��i�����p�j
            }

            //-----DEL huangt 2013/06/21 �\�[�X�`�F�b�N�m�F�����ꗗ��No.48�̑Ή� ---->>>>> 
            //if (colorCdInfoDataTable.Rows.Count > 0)
            //{
            //    PMKEN01010E.ColorCdInfoRow colorCdInfoRow = colorCdInfoDataTable[0] as PMKEN01010E.ColorCdInfoRow;

            //    pmTabAcpOdrCarWork.ColorCode = colorCdInfoRow.ColorCode;                         // �J���[�R�[�h
            //    pmTabAcpOdrCarWork.ColorName1 = colorCdInfoRow.ColorName1;                       // �J���[����1
            //}

            //if (trimCdInfoDataTable.Rows.Count > 0)
            //{
            //    PMKEN01010E.TrimCdInfoRow trimCdInfoRow = trimCdInfoDataTable[0] as PMKEN01010E.TrimCdInfoRow;

            //    pmTabAcpOdrCarWork.TrimCode = trimCdInfoRow.TrimCode;                            // �g�����R�[�h
            //    pmTabAcpOdrCarWork.TrimName = trimCdInfoRow.TrimName;                            // �g��������
            //}
            //-----DEL huangt 2013/06/21 �\�[�X�`�F�b�N�m�F�����ꗗ��No.48�̑Ή� ----<<<<<

            //-----ADD huangt 2013/06/21 �\�[�X�`�F�b�N�m�F�����ꗗ��No.48�̑Ή� ---->>>>>
            if (colorCdInfoDataTable.Rows.Count > 0)
            {
                for (int i = 0; i < colorCdInfoDataTable.Rows.Count; i++)
                {
                    PMKEN01010E.ColorCdInfoRow colorCdInfoRow = colorCdInfoDataTable[i] as PMKEN01010E.ColorCdInfoRow;
                    if (colorCdInfoRow.SelectionState == true)
                    {
                        pmTabAcpOdrCarWork.ColorCode = colorCdInfoRow.ColorCode;                         // �J���[�R�[�h
                        pmTabAcpOdrCarWork.ColorName1 = colorCdInfoRow.ColorName1;                       // �J���[����1
                        break;
                    }

                }
            }

            if (trimCdInfoDataTable.Rows.Count > 0)
            {
                for (int i = 0; i < trimCdInfoDataTable.Rows.Count; i++)
                {
                    PMKEN01010E.TrimCdInfoRow trimCdInfoRow = trimCdInfoDataTable[i] as PMKEN01010E.TrimCdInfoRow;

                    if (trimCdInfoRow.SelectionState == true)
                    {
                        pmTabAcpOdrCarWork.TrimCode = trimCdInfoRow.TrimCode;                            // �g�����R�[�h
                        pmTabAcpOdrCarWork.TrimName = trimCdInfoRow.TrimName;                            // �g��������
                        break;
                    }
                }
            }
            //-----ADD huangt 2013/06/21 �\�[�X�`�F�b�N�m�F�����ꗗ��No.48�̑Ή� ----<<<<<

            pmTabAcpOdrCarWork.EnterpriseCode = enterpriseCode;
            pmTabAcpOdrCarWork.DataInputSystem = 10;                               // �f�[�^���̓V�X�e��
            pmTabAcpOdrCarWork.LogicalDeleteCode = 0;                              // �_���폜�敪
            pmTabAcpOdrCarWork.BusinessSessionId = businessSessionId;              // �Ɩ��Z�b�V����ID
            pmTabAcpOdrCarWork.SearchSectionCode = searchSectionCode;              // �������_�R�[�h
            pmTabAcpOdrCarWork.PmTabDtlDiscGuid = pmTabDtlDiscGuid;                // PMTAB���׎���GUID
            //pmTabAcpOdrCarWork.DataDeleteDate = Convert.ToInt32(
            //    DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));     // �f�[�^�폜�\��� //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
            pmTabAcpOdrCarWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));     // �f�[�^�폜�\��� //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX



            int[] fullModelFixedNoAry = new int[0];
            string[] freeSrchMdlFxdNoAry = new string[0];

            CarSearchController carSearcher = new CarSearchController();
            {
                carSearcher.GetFullModelFixedNoArrayWithFreeSrchMdlFxdNo(searchedCarInfo.CarModelInfo, out fullModelFixedNoAry, out freeSrchMdlFxdNoAry);
            }
            pmTabAcpOdrCarWork.FullModelFixedNoAry = fullModelFixedNoAry;                    // �t���^���Œ�ԍ��z��

            // ���R�����^���Œ�ԍ��z��
            // DEL songg 2013/07/18 Redmine#38573 �����I�u�W�F�N�g�z��^���R�����^���Œ�ԍ��z�� ---->>>>>
            //if (null == freeSrchMdlFxdNoAry || freeSrchMdlFxdNoAry.Length == 0)
            //{
            //    pmTabAcpOdrCarWork.FreeSrchMdlFxdNoAry = new byte[0];
            //}
            //else
            //{
            //    string[] temp = freeSrchMdlFxdNoAry;
            //    byte[] freeAry = new byte[temp.Length];
            //    for (int i = 0; i < temp.Length; i++)
            //    {
            //        freeAry[i] = Convert.ToByte(temp[i]);
            //    }
            //    pmTabAcpOdrCarWork.FreeSrchMdlFxdNoAry = freeAry;
            //}
            // DEL songg 2013/07/18 Redmine#38573 �����I�u�W�F�N�g�z��^���R�����^���Œ�ԍ��z�� ----<<<<<
            // ADD songg 2013/07/18 Redmine#38573 �����I�u�W�F�N�g�z��^���R�����^���Œ�ԍ��z�� ---->>>>>
            // �����񓚏���(PMSCM01010U) SCMSalesDataMaker.cs CreateCarManagementWork ���\�b�h���Q�l����
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            try
            {
                formatter.Serialize(ms, freeSrchMdlFxdNoAry);
                byte[] verbinary = ms.GetBuffer();
                pmTabAcpOdrCarWork.FreeSrchMdlFxdNoAry = verbinary; // ���R�����^���Œ�ԍ��z��
            }
            finally
            {
                ms.Close();
            }
            // ADD songg 2013/07/18 Redmine#38573 �����I�u�W�F�N�g�z��^���R�����^���Œ�ԍ��z�� ----<<<<<


            //pmTabAcpOdrCarWork.CategoryObjAry = new byte[0];                                        // �����I�u�W�F�N�g�z�� // DEL songg 2013/07/18 Redmine#38573 �����I�u�W�F�N�g�z��^���R�����^���Œ�ԍ��z��
            pmTabAcpOdrCarWork.CategoryObjAry = this.GetCategoryObjAry(searchedCarInfo);              // �����I�u�W�F�N�g�z�� // ADD songg 2013/07/18 Redmine#38573 �����I�u�W�F�N�g�z��^���R�����^���Œ�ԍ��z��
            

            acceptOdrCarList.Add(pmTabAcpOdrCarWork);

            if (acceptOdrCarList != null)
            {
                object paraList = acceptOdrCarList as object;

                // �ԗ�����USER DB�ɏ�����
                status = iPmTabAcpOdrCarDB.Write(ref paraList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                    return status;
                }
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }

        // ADD 2013/08/01 yugami Redmine#39487 ------------------------------------------->>>>>
        /// <summary>
        /// �󒍃}�X�^�i�ԗ��j�o�^
        /// </summary>
        /// <param name="pmTabSalesDtCarWork">�ԗ��f�[�^</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabDtlDiscGuid">PMTAB���׎���GUID</param>
        /// <param name="searchSectionCode">�������_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WritePmTabAcpOdrCar(PmTabSalesDtCarWork pmTabSalesDtCarWork, string enterpriseCode, string businessSessionId, string searchSectionCode, string pmTabDtlDiscGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WritePmTabAcpOdrCar";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            IPmTabAcpOdrCarDB iPmTabAcpOdrCarDB = MediationPmTabAcpOdrCarDB.GetPmTabAcpOdrCarDB();
            ArrayList acceptOdrCarList = new ArrayList();

            // �󒍃}�X�^�i�ԗ��j �f�[�^���N���X�֊i�[����
            PmTabAcpOdrCarWork pmTabAcpOdrCarWork = new PmTabAcpOdrCarWork();

            pmTabAcpOdrCarWork.MakerCode = pmTabSalesDtCarWork.MakerCode;              // ���[�J�[�R�[�h
            pmTabAcpOdrCarWork.MakerFullName = pmTabSalesDtCarWork.MakerName;      // ���[�J�[�S�p����
            pmTabAcpOdrCarWork.MakerHalfName = string.Empty;      // ���[�J�[���p����
            pmTabAcpOdrCarWork.ModelCode = pmTabSalesDtCarWork.ModelCode;              // �Ԏ�R�[�h
            pmTabAcpOdrCarWork.ModelSubCode = pmTabSalesDtCarWork.ModelSubCode;        // �Ԏ�T�u�R�[�h

            // �Ԏ�S�p����
            if (pmTabSalesDtCarWork.ModelName.Length > 15)
            {
                pmTabAcpOdrCarWork.ModelFullName = pmTabSalesDtCarWork.ModelName.Substring(0, 15);
            }
            else
            {
                pmTabAcpOdrCarWork.ModelFullName = pmTabSalesDtCarWork.ModelName;
            }


            pmTabAcpOdrCarWork.ModelHalfName = string.Empty;                                // �Ԏ피�p����
            pmTabAcpOdrCarWork.ExhaustGasSign = string.Empty;              // �r�K�X�L��
            pmTabAcpOdrCarWork.SeriesModel = string.Empty;                    // �V���[�Y�^��
            pmTabAcpOdrCarWork.CategorySignModel = string.Empty;        // �^���i�ޕʋL���j
            pmTabAcpOdrCarWork.FullModel = pmTabSalesDtCarWork.FullModel;                        // �^���i�t���^�j

            pmTabAcpOdrCarWork.FrameModel = pmTabSalesDtCarWork.FrameModel;                      // �ԑ�^��
            pmTabAcpOdrCarWork.EngineModelNm = pmTabSalesDtCarWork.EngineModelNm;             // �G���W���^������  // ADD songg 2013/07/08 ��Q�� #37983�̑Ή�
            pmTabAcpOdrCarWork.RelevanceModel = string.Empty;              // �֘A�^��
            pmTabAcpOdrCarWork.SubCarNmCd = 0;                      // �T�u�Ԗ��R�[�h
            pmTabAcpOdrCarWork.ModelGradeSname = string.Empty;            // �^���O���[�h����
            pmTabAcpOdrCarWork.DomesticForeignCode = 0;           // ���Y�^�O�ԋ敪

            pmTabAcpOdrCarWork.ModelDesignationNo = pmTabSalesDtCarWork.ModelDesignationNo;        // �^���w��ԍ�
            pmTabAcpOdrCarWork.CategoryNo = pmTabSalesDtCarWork.CategoryNo;                        // �ޕʔԍ�

            pmTabAcpOdrCarWork.FrameNo = pmTabSalesDtCarWork.FrameNo;                              // �ԑ�ԍ�
            //pmTabAcpOdrCarWork.SearchFrameNo = pmTabSalesDtCarWork.FrameNo;                  // �ԑ�ԍ��i�����p�j

            pmTabAcpOdrCarWork.ColorCode = pmTabSalesDtCarWork.RpColorCode;                         // �J���[�R�[�h
            pmTabAcpOdrCarWork.ColorName1 = pmTabSalesDtCarWork.ColorName1;                       // �J���[����1

            pmTabAcpOdrCarWork.TrimCode = pmTabSalesDtCarWork.TrimCode;                            // �g�����R�[�h
            pmTabAcpOdrCarWork.TrimName = pmTabSalesDtCarWork.TrimName;                            // �g��������

            pmTabAcpOdrCarWork.EnterpriseCode = enterpriseCode;
            pmTabAcpOdrCarWork.DataInputSystem = 10;                               // �f�[�^���̓V�X�e��
            pmTabAcpOdrCarWork.LogicalDeleteCode = 0;                              // �_���폜�敪
            pmTabAcpOdrCarWork.BusinessSessionId = businessSessionId;              // �Ɩ��Z�b�V����ID
            pmTabAcpOdrCarWork.SearchSectionCode = searchSectionCode;              // �������_�R�[�h
            pmTabAcpOdrCarWork.PmTabDtlDiscGuid = pmTabDtlDiscGuid;                // PMTAB���׎���GUID
            pmTabAcpOdrCarWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));     // �f�[�^�폜�\��� 

            if (null == pmTabAcpOdrCarWork.FullModelFixedNoAry)
                pmTabAcpOdrCarWork.FullModelFixedNoAry = new int[0];
            if (null == pmTabAcpOdrCarWork.CategoryObjAry)
                pmTabAcpOdrCarWork.CategoryObjAry = new byte[0];
            if (null == pmTabAcpOdrCarWork.FreeSrchMdlFxdNoAry)
                pmTabAcpOdrCarWork.FreeSrchMdlFxdNoAry = new byte[0];

            acceptOdrCarList.Add(pmTabAcpOdrCarWork);

            if (acceptOdrCarList != null)
            {
                object paraList = acceptOdrCarList as object;

                // �ԗ�����USER DB�ɏ�����
                status = iPmTabAcpOdrCarDB.Write(ref paraList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                    return status;
                }
            }

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }
        // ADD 2013/08/01 yugami Redmine#39487 -------------------------------------------<<<<<

        #endregion �� �󒍃}�X�^�i�ԗ��j�o�^

        // ADD songg 2013/07/18 Redmine#38573 �����I�u�W�F�N�g�z��^���R�����^���Œ�ԍ��z�� ---->>>>>
        #region �� �����I�u�W�F�N�g�z��擾
        /// <summary>
        /// ������z����擾���܂��B
        /// ����`�[����(MAHNB01001U) MAHNB01012AC.cs GetEquipInfoRows ���\�b�h���Q�l����
        /// </summary>
        /// <param name="seachedCarInfo">�ԗ���������</param>
        /// <returns>�������z��</returns>
        private byte[] GetCategoryObjAry(PMKEN01010E seachedCarInfo)
        {
            if (seachedCarInfo.CEqpDefDspInfo == null) return new byte[0];

            // --- ADD 2013/08/28 �O�� 2013/09/99�z�M�� Redmine#40185�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>
            //return seachedCarInfo.CEqpDefDspInfo.GetByteArray(false);
            return seachedCarInfo.CEqpDefDspInfo.GetByteArray(true);
            // --- ADD 2013/08/28 �O�� 2013/09/99�z�M�� Redmine#40185�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<
        }
        #endregion �� �����I�u�W�F�N�g�z��擾
        // ADD songg 2013/07/18 Redmine#38573 �����I�u�W�F�N�g�z��^���R�����^���Œ�ԍ��z�� ----<<<<<

        //-----ADD huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.43�̑Ή� ---->>>>>
        #region �� �ԗ�����SCM DB�ɍX�V����
        /// <summary>
        /// �ԗ�����SCM DB�ɍX�V����
        /// </summary>
        /// <param name="searchedCarInfo">�ԗ��f�[�^</param>
        /// <param name="pmTabSalesDtCar">PMTAB����(�ԗ����)�Z�b�V�����Ǘ��g�����U�N�V�����f�[�^���</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabDtlDiscGuid">PMTAB���׎���GUID</param>
        /// <param name="searchSectionCode">�������_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�X�e�[�^�X</returns>
        private int WritePmTabSalDCar(PMKEN01010E searchedCarInfo, PmTabSalesDtCarWork pmTabSalesDtCar, string enterpriseCode, string businessSessionId, string searchSectionCode, string pmTabDtlDiscGuid)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "WritePmTabSalDCar";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            IPmTabSalDCarTmpDB iPmTabSalDCarTmpDB = MediationPmTabSalDCarTmpDB.GetPmTabSalDCarTmpDB();
            ArrayList pmTabSalDCarList = new ArrayList();

            // �^�����
            PMKEN01010E.CarModelInfoDataTable carModelInfoDataTable = searchedCarInfo.CarModelInfoSummarized;
            // ��ʗp�^�����
            PMKEN01010E.CarModelUIDataTable carModelUIDataTable = searchedCarInfo.CarModelUIData;
            // �J���[���
            PMKEN01010E.ColorCdInfoDataTable colorCdInfoDataTable = searchedCarInfo.ColorCdInfo;
            // �g�������
            PMKEN01010E.TrimCdInfoDataTable trimCdInfoDataTable = searchedCarInfo.TrimCdInfo;

            // PMTAB����(�ԗ����)�Z�b�V�����Ǘ��g�����U�N�V�����f�[�^���
            PmTabSalesDtCarWork pmTabSalesDtCarWork = new PmTabSalesDtCarWork();

            if (carModelInfoDataTable.Rows.Count > 0)
            {
                PMKEN01010E.CarModelInfoRow carModelInfoRow = carModelInfoDataTable[0] as PMKEN01010E.CarModelInfoRow;

                pmTabSalesDtCarWork.MakerCode = carModelInfoRow.MakerCode;                        // ���[�J�[�R�[�h
                pmTabSalesDtCarWork.ModelCode = carModelInfoRow.ModelCode;                        // �Ԏ�R�[�h
                pmTabSalesDtCarWork.ModelSubCode = carModelInfoRow.ModelSubCode;                  // �Ԏ�T�u�R�[�h
                pmTabSalesDtCarWork.FullModel = carModelInfoRow.FullModel;                        // �^���i�t���^�j
                pmTabSalesDtCarWork.FrameModel = carModelInfoRow.FrameModel;                      // �ԑ�^��
                pmTabSalesDtCarWork.ModelName = carModelInfoRow.ModelFullName;                    // �Ԏ햼
                // pmTabSalesDtCarWork.EngineModelNm = carModelInfoRow.EngineDisplaceNm;             // �G���W���^������// DEL songg 2013/07/08 ��Q�� #37983�̑Ή�
                pmTabSalesDtCarWork.EngineModelNm = carModelInfoRow.EngineModelNm;             // �G���W���^������// ADD songg 2013/07/08 ��Q�� #37983�̑Ή�
                pmTabSalesDtCarWork.MakerName = carModelInfoRow.MakerFullName;                    // ���[�J�[����
                pmTabSalesDtCarWork.GradeName = carModelInfoRow.ModelGradeNm;                     // �O���[�h����
                pmTabSalesDtCarWork.BodyName = carModelInfoRow.BodyName;                          // �{�f�B�[����
                pmTabSalesDtCarWork.DoorCount = carModelInfoRow.DoorCount;                        // �h�A��
                pmTabSalesDtCarWork.EDivNm = carModelInfoRow.EDivNm;                              // E�敪����
                pmTabSalesDtCarWork.TransmissionNm = carModelInfoRow.TransmissionNm;              // �~�b�V��������
                pmTabSalesDtCarWork.ShiftNm = carModelInfoRow.ShiftNm;                            // �V�t�g����
                pmTabSalesDtCarWork.FrameNoSt = carModelInfoRow.StProduceFrameNo.ToString();      // �ԑ�ԍ��J�n
                pmTabSalesDtCarWork.FrameNoEd = carModelInfoRow.EdProduceFrameNo.ToString();      // �ԑ�ԍ��I��
                pmTabSalesDtCarWork.ProdTypeOfYearNumSt = carModelInfoRow.StProduceTypeOfYear;    // ���Y�N���J�n
                pmTabSalesDtCarWork.ProdTypeOfYearNumEd = carModelInfoRow.EdProduceTypeOfYear;    // ���Y�N���I��
                // ADD songg 2013/07/19 Redmine38628 ���C�A�E�g�ύX�Ή��˗� ---->>>>>
                pmTabSalesDtCarWork.SystematicCode = carModelInfoRow.SystematicCode; // �n���R�[�h
                pmTabSalesDtCarWork.ProduceTypeOfYearCd = carModelInfoRow.ProduceTypeOfYearCd; // ���Y�N���R�[�h
                // ADD songg 2013/07/19 Redmine38628 ���C�A�E�g�ύX�Ή��˗� ----<<<<<
            }

            if (carModelUIDataTable.Rows.Count > 0)
            {
                PMKEN01010E.CarModelUIRow carModelUIRow = carModelUIDataTable[0] as PMKEN01010E.CarModelUIRow;

                pmTabSalesDtCarWork.ModelDesignationNo = carModelUIRow.ModelDesignationNo;        // �^���w��ԍ�
                pmTabSalesDtCarWork.CategoryNo = carModelUIRow.CategoryNo;                        // �ޕʔԍ�


                // UPD 2013/12/19 VSS[020_10] ����ýď�Q��4 �g�� ------------------->>>>>>>>>>>>>>>
                #region ���\�[�X
                //// UPD 2013/12/12 SCM�d�|�ꗗ��10609�Ή� ------------------------------------->>>>>
                ////pmTabSalesDtCarWork.FrameNo = carModelUIRow.FrameNo;                              // �ԑ�ԍ�
                //pmTabSalesDtCarWork.FrameNo = pmTabSalesDtCar.FrameNo;                              // �ԑ�ԍ�
                //// UPD 2013/12/12 SCM�d�|�ꗗ��10609�Ή� -------------------------------------<<<<<
                pmTabSalesDtCarWork.FrameNo = carModelUIRow.FrameNo;                              // �ԑ�ԍ�
                #endregion
                // UPD 2013/12/19 VSS[020_10] ����ýď�Q��4 �g�� -------------------<<<<<<<<<<<<<<<

            }

            //-----DEL huangt 2013/06/21 �\�[�X�`�F�b�N�m�F�����ꗗ��No.48�̑Ή� ---->>>>> 
            //if (colorCdInfoDataTable.Rows.Count > 0)
            //{
            //    PMKEN01010E.ColorCdInfoRow colorCdInfoRow = colorCdInfoDataTable[0] as PMKEN01010E.ColorCdInfoRow;

            //    pmTabSalesDtCarWork.ColorName1 = colorCdInfoRow.ColorName1;                       // �J���[����1
            //}

            //if (trimCdInfoDataTable.Rows.Count > 0)
            //{
            //    PMKEN01010E.TrimCdInfoRow trimCdInfoRow = trimCdInfoDataTable[0] as PMKEN01010E.TrimCdInfoRow;

            //    pmTabSalesDtCarWork.TrimCode = trimCdInfoRow.TrimCode;                            // �g�����R�[�h
            //    pmTabSalesDtCarWork.TrimName = trimCdInfoRow.TrimName;                            // �g��������
            //}
            //-----DEL huangt 2013/06/21 �\�[�X�`�F�b�N�m�F�����ꗗ��No.48�̑Ή� ----<<<<<

            //-----ADD huangt 2013/06/21 �\�[�X�`�F�b�N�m�F�����ꗗ��No.48�̑Ή� ---->>>>>
            if (colorCdInfoDataTable.Rows.Count > 0)
            {
                for (int i = 0; i < colorCdInfoDataTable.Rows.Count; i++)
                {
                    PMKEN01010E.ColorCdInfoRow colorCdInfoRow = colorCdInfoDataTable[i] as PMKEN01010E.ColorCdInfoRow;
                    if (colorCdInfoRow.SelectionState == true)
                    {
                        pmTabSalesDtCarWork.ColorName1 = colorCdInfoRow.ColorName1;                       // �J���[����1
                        //-----ADD 2013/07/02 licb #Redmine37738�Ή� -------------->>>>>
                        pmTabSalesDtCarWork.RpColorCode = colorCdInfoRow.ColorCode; // ���y�A�J���[�R�[�h
                        //-----ADD 2013/07/02 licb #Redmine37738�Ή� --------------<<<<<
                        break;
                    }

                }
            }

            if (trimCdInfoDataTable.Rows.Count > 0)
            {
                for (int i = 0; i < trimCdInfoDataTable.Rows.Count; i++)
                {
                    PMKEN01010E.TrimCdInfoRow trimCdInfoRow = trimCdInfoDataTable[i] as PMKEN01010E.TrimCdInfoRow;

                    if (trimCdInfoRow.SelectionState == true)
                    {
                        pmTabSalesDtCarWork.TrimCode = trimCdInfoRow.TrimCode;                            // �g�����R�[�h
                        pmTabSalesDtCarWork.TrimName = trimCdInfoRow.TrimName;                            // �g��������
                        break;
                    }
                }
            }
            //-----ADD huangt 2013/06/21 �\�[�X�`�F�b�N�m�F�����ꗗ��No.48�̑Ή� ----<<<<<

            pmTabSalesDtCarWork.CreateDateTime = pmTabSalesDtCar.CreateDateTime;    // �쐬����
            pmTabSalesDtCarWork.FileHeaderGuid = pmTabSalesDtCar.FileHeaderGuid;    // GUID
            pmTabSalesDtCarWork.UpdateDateTime = pmTabSalesDtCar.UpdateDateTime;
            pmTabSalesDtCarWork.EnterpriseCode = enterpriseCode;                    // ��ƃR�[�h
            pmTabSalesDtCarWork.LogicalDeleteCode = 0;                              // �_���폜�敪
            pmTabSalesDtCarWork.BusinessSessionId = businessSessionId;              // �Ɩ��Z�b�V����ID
            pmTabSalesDtCarWork.SearchSectionCode = searchSectionCode;              // �������_�R�[�h
            pmTabSalesDtCarWork.PmTabDtlDiscGuid = pmTabDtlDiscGuid;                // PMTAB���׎���GUID
            //pmTabSalesDtCarWork.DataDeleteDate = Convert.ToInt32(
            //    DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));      // �f�[�^�폜�\���  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
            pmTabSalesDtCarWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));      // �f�[�^�폜�\���  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX

            pmTabSalDCarList.Add(pmTabSalesDtCarWork);

            if (pmTabSalDCarList != null)
            {
                object paraList = pmTabSalDCarList as object;

                // �ԗ�����SCM DB�ɏ�����
                status = iPmTabSalDCarTmpDB.Write(ref paraList);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
                    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

                    return status;
                }
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            return status;
        }
        #endregion
        //-----ADD huangt 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.43�̑Ή� ----<<<<<

        #region �� ����f�[�^(�ԗ����) ����
        /// <summary>
        /// ����f�[�^(�ԗ����) ����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSalesDtCarList">����f�[�^(�ԗ����)</param>
        /// <returns>�X�e�[�^�X</returns>
        public int ReadPmTabSalesDtCar(string enterpriseCode, string businessSessionId, ref ArrayList pmTabSalesDtCarList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "ReadPmTabSalesDtCar";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            // PMTAB����f�[�^(�ԗ����)�C���^�[�t�F�[�X���擾
            IPmTabSalDCarTmpDB _iPmTabSalDCarTmpDB = MediationPmTabSalDCarTmpDB.GetPmTabSalDCarTmpDB();

            // ����������ݒ�
            PmTabSalesDtCarWork pmTabSalesDtCarWork = new PmTabSalesDtCarWork();

            pmTabSalesDtCarWork.EnterpriseCode = enterpriseCode;
            pmTabSalesDtCarWork.BusinessSessionId = businessSessionId;

            object parapmTabSalesDtCarObj = pmTabSalesDtCarWork as object;
            object pmTabSalesDtCarObj = pmTabSalesDtCarList as object;

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, "�ԗ���񌟍��@���������@"
                + "�@��ƃR�[�h�F" + enterpriseCode
                + "�@�Ɩ��Z�b�V����ID�F" + businessSessionId
                );
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            // ����f�[�^(�ԗ����) ��������
            status = _iPmTabSalDCarTmpDB.Search(out pmTabSalesDtCarObj, parapmTabSalesDtCarObj, 0, 0);
            pmTabSalesDtCarList = pmTabSalesDtCarObj as ArrayList;

            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I�� status�F" + status.ToString());
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            return status;
        }
        #endregion �� ����f�[�^(�ԗ����) ����

        #region �� �|���}�X�^��SCM DB�ɏ����ޏ���
        /// <summary>
        /// �|���}�X�^��SCM DB�ɏ����ޏ���
        /// </summary>
        /// <param name="rateList">�|���f�[�^���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="pmtPartsSearchWorkList">�S�ĕۑ��p���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private void GetRateToScmDBDataList(List<Rate> rateList,
            string enterpriseCode,
            string sectionCode,
            string businessSessionId,
            string pmTabSearchGuid,
            ref CustomSerializeArrayList pmtPartsSearchWorkList)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "GetRateToScmDBDataList";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            List<PmtRateRsltTmpWork> pmtRateRsltTmpList = new List<PmtRateRsltTmpWork>();

            if (null == rateList)
            {
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
                return;
            }

            for (int i = 0; i < rateList.Count; i++)
            {
                Rate rate = rateList[i] as Rate;
                PmtRateRsltTmpWork tempWork = new PmtRateRsltTmpWork();
                tempWork.BLGoodsCode = rate.BLGoodsCode;
                tempWork.BLGroupCode = rate.BLGroupCode;
                tempWork.BusinessSessionId = businessSessionId;
                tempWork.CreateDateTime = rate.CreateDateTime;
                tempWork.CustomerCode = rate.CustomerCode;
                tempWork.CustRateGrpCode = rate.CustRateGrpCode;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));  //ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.EnterpriseCode = enterpriseCode;
                tempWork.FileHeaderGuid = rate.FileHeaderGuid;
                tempWork.GoodsMakerCd = rate.GoodsMakerCd;
                tempWork.GoodsNo = rate.GoodsNo;
                tempWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;
                tempWork.GoodsRateRank = rate.GoodsRateRank;
                tempWork.GrsProfitSecureRate = rate.GrsProfitSecureRate;
                tempWork.LogicalDeleteCode = rate.LogicalDeleteCode;
                tempWork.LotCount = rate.LotCount;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                tempWork.PmTabSearchRowNum = i + 1;
                tempWork.PriceFl = rate.PriceFl;
                tempWork.RateMngCustCd = rate.RateMngCustCd;
                tempWork.RateMngCustNm = rate.RateMngCustNm;
                tempWork.RateMngGoodsCd = rate.RateMngGoodsCd;
                tempWork.RateMngGoodsNm = rate.RateMngGoodsNm;
                tempWork.RateSettingDivide = rate.RateSettingDivide;
                tempWork.RateVal = rate.RateVal;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.SectionCode = rate.SectionCode;
                tempWork.SupplierCd = rate.SupplierCd;
                tempWork.UnitPriceKind = rate.UnitPriceKind;
                tempWork.UnitRateSetDivCd = rate.UnitRateSetDivCd;
                tempWork.UnPrcFracProcDiv = rate.UnPrcFracProcDiv;
                tempWork.UnPrcFracProcUnit = rate.UnPrcFracProcUnit;
                tempWork.UpdAssemblyId1 = rate.UpdAssemblyId1;
                tempWork.UpdAssemblyId2 = rate.UpdAssemblyId2;
                tempWork.UpdateDateTime = rate.UpdateDateTime;
                tempWork.UpdEmployeeCode = rate.UpdEmployeeCode;
                tempWork.UpRate = rate.UpRate;

                pmtRateRsltTmpList.Add(tempWork);
            }

            if (pmtRateRsltTmpList.Count > 0)
            {
                pmtPartsSearchWorkList.Add(pmtRateRsltTmpList);
            }
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
        }
        #endregion �� �|���}�X�^��SCM DB�ɏ����ޏ���

        //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ---->>>>>
        #region �� ���Ӑ�|���O���[�v�}�X�^��SCM DB�ɏ����ޏ���
        /// <summary>
        /// ���Ӑ�|���O���[�v�}�X�^��SCM DB�ɏ����ޏ���
        /// </summary>
        /// <param name="custRateGroupList">���Ӑ�|���O���[�v�f�[�^���X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="businessSessionId">�Ɩ��Z�b�V����ID</param>
        /// <param name="pmTabSearchGuid">PMTAB���׎���GUID</param>
        /// <param name="pmtPartsSearchWorkList">�S�ĕۑ��p���X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        private void GetCustRateGroupToScmDBDataList(List<CustRateGroup> custRateGroupList,
            string enterpriseCode,
            string sectionCode,
            string businessSessionId,
            string pmTabSearchGuid,
            ref CustomSerializeArrayList pmtPartsSearchWorkList)
        {
            if (null == custRateGroupList)
            {
                return;
            }

            List<PmtCustRtGrpTmpWork> tmpList = new List<PmtCustRtGrpTmpWork>();

            for (int i = 0; i < custRateGroupList.Count; i++)
            {
                CustRateGroup rate = custRateGroupList[i] as CustRateGroup;
                PmtCustRtGrpTmpWork tempWork = new PmtCustRtGrpTmpWork();

                tempWork.BusinessSessionId = businessSessionId;
                tempWork.CreateDateTime = rate.CreateDateTime;
                tempWork.CustomerCode = rate.CustomerCode;
                tempWork.CustRateGrpCode = rate.CustRateGrpCode;
                //tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToShortDateString().Replace("/", ""));// �f�[�^�폜�\���  //DEL  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.DataDeleteDate = Convert.ToInt32(DateTime.Now.AddDays(7).ToString("yyyyMMdd"));//�f�[�^�폜�\���//ADD  �A���� 2013/07/23 Redmine#38992 �f�[�^�폜�\����̃t�H�[�}�b�g�ύX
                tempWork.EnterpriseCode = rate.EnterpriseCode;
                tempWork.FileHeaderGuid = rate.FileHeaderGuid;
                tempWork.GoodsMakerCd = rate.GoodsMakerCd;
                tempWork.LogicalDeleteCode = rate.LogicalDeleteCode;
                tempWork.PmTabDtlDiscGuid = pmTabSearchGuid;
                tempWork.PmTabSearchRowNum = i + 1;
                tempWork.PureCode = rate.PureCode;
                tempWork.SearchSectionCode = sectionCode;
                tempWork.UpdAssemblyId1 = rate.UpdAssemblyId1;
                tempWork.UpdAssemblyId2 = rate.UpdAssemblyId2;
                tempWork.UpdateDateTime = rate.UpdateDateTime;
                tempWork.UpdEmployeeCode = rate.UpdEmployeeCode;

                tmpList.Add(tempWork);
            }

            if (tmpList.Count > 0)
            {
                pmtPartsSearchWorkList.Add(tmpList);
            }
        }
        #endregion �� ���Ӑ�|���O���[�v�}�X�^��SCM DB�ɏ����ޏ���
        //-----ADD songg 2013/06/20 �\�[�X�`�F�b�N�m�F�����ꗗ��No.46�̑Ή� ----<<<<<
        

        #region �� ���i�A���f�[�^�s�����ݒ�p���\�b�h
        /// <summary>
        /// ���i�A���f�[�^�s�����ݒ�
        /// MAHNB01012AB.cs SettingGoodsUnitDataListFromVariousMst���Q�Ƃ���
        /// </summary>
        /// <param name="goodsUnitDataList">���i�A����񃊃X�g</param>
        /// <param name="isSettingSupplier">�d����ݒ�t���O</param>
        /// <param name="sectionCode">���_���</param>
        private  void SettingGoodsUnitDataListFromVariousMst(ref List<GoodsUnitData> goodsUnitDataList, bool isSettingSupplier, string sectionCode)
        {
            // ----- DEL huangt 2013/07/11 Redmine#38220 �s�K�v�ȃ��O�o�͂̍폜 ----- >>>>>
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            //const string methodName = "SettingGoodsUnitDataListFromVariousMst";
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            // ----- DEL huangt 2013/07/11 Redmine#38220 �s�K�v�ȃ��O�o�͂̍폜 ----- <<<<<
            // ADD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            const string methodName = "SettingGoodsUnitDataListFromVariousMst";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ADD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            //this._goodsAcs = new GoodsAcs(); // ADD huangt 2013/07/03 Redmine#37755 ���x���P�Ή�//DEL songg 2013/07/10 Redmine#38106 �D�Ǖi�ԓ_�t���� ----- >>>>>
            //DEL songg 2013/07/10 Redmine#38106 �D�Ǖi�ԓ_�t���� ----- >>>>>
            if (null == this._goodsAcs)
            {
                this._goodsAcs = new GoodsAcs();
            }
            //DEL songg 2013/07/10 Redmine#38106 �D�Ǖi�ԓ_�t���� ----- <<<<<

            // ADD 2013/07/31 yugami Redmine#39451�Ή� ----------------------------------->>>>>
            // ���i�Ǘ���񃊃X�g
            this._goodsMngList = new List<GoodsMngWork>();
            // ADD 2013/07/31 yugami Redmine#39451�Ή� -----------------------------------<<<<<

            List<GoodsUnitData> retGoodsUnitDataList = new List<GoodsUnitData>();
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                GoodsUnitData retGoodsUnitData = goodsUnitData.Clone();
                // UPD 2013/08/01 �g�� Redmine#39496 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                // retGoodsUnitData.SectionCode = sectionCode;
                retGoodsUnitData.SectionCode = this.CustomerInfo().MngSectionCode;
                // UPD 2013/08/01 �g�� Redmine#39496 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                this.SettingGoodsUnitDataListFromVariousMst(ref retGoodsUnitData, isSettingSupplier);
                retGoodsUnitDataList.Add(retGoodsUnitData);
            }
            goodsUnitDataList = retGoodsUnitDataList;
            // ----- DEL huangt 2013/07/11 Redmine#38220 �s�K�v�ȃ��O�o�͂̍폜 ----- >>>>>
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            // ----- DEL huangt 2013/07/11 Redmine#38220 �s�K�v�ȃ��O�o�͂̍폜 ----- <<<<<
            // ADD 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            // ADD 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// ���i�A���f�[�^�s�����ݒ�
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="isSettingSupplier">�d����ݒ�t���O</param>
        private void SettingGoodsUnitDataListFromVariousMst(ref GoodsUnitData goodsUnitData, bool isSettingSupplier)
        {
            // DEL 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            //const string methodName = "SettingGoodsUnitDataListFromVariousMst";
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            // DEL 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            
            // ----- ADD huangt 2013/07/03 Redmine#37755 ���x���P�Ή� ----->>>>>
            //GoodsAcs goodsAcs = new GoodsAcs();
            //goodsAcs.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, (isSettingSupplier) ? 0 : 1);
            this._goodsAcs.SettingGoodsUnitDataFromVariousMstForTablet(ref goodsUnitData, (isSettingSupplier) ? 0 : 1);
            // ----- ADD huangt 2013/07/03 Redmine#37755 ���x���P�Ή� -----<<<<<

            // ADD 2013/07/31 yugami Redmine#39451�Ή� ----------------------------------->>>>>
            // ���i�Ǘ���񃊃X�g�ǉ�
            if (this._goodsAcs.GoodsMngWorkForTablet != null)
            {
                if (!this._goodsMngList.Contains(this._goodsAcs.GoodsMngWorkForTablet))
                {
                    this._goodsMngList.Add(this._goodsAcs.GoodsMngWorkForTablet);
                }
            }
            // ADD 2013/07/31 yugami Redmine#39451�Ή� -----------------------------------<<<<<

            // DEL 2013/07/29 �g�� ���O������----------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            // DEL 2013/07/29 �g�� ���O������-----------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }
        #endregion �� ���i�A���f�[�^�s�����ݒ�p���\�b�h
        

        #region ���t�t�H�[�}�b�g����
        /// <summary>
        /// ���t�t�H�[�}�b�g����
        /// </summary>
        /// <param name="baseDate">yyyyMMdd�̓��t</param>
        /// <returns>yyyyMMdd�̎��Ԃ�߂�</returns>
        /// <remarks>
        /// </remarks>
        private DateTime GetDate(int baseDate)
        {
            // DEL 2013/07/31 �g�� ���x���P --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region ���\�[�X
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            //const string methodName = "GetDate";
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            #endregion
            // DEL 2013/07/31 �g�� ���x���P ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            if (baseDate == 0)
            {
                return DateTime.MinValue;

            }

            string datetime = Convert.ToString(baseDate);

            if(datetime.Length != 8)
            {
                return DateTime.MinValue;
            }

            int year, month, day = 0;
            //�N�����ɕ���
            year = int.Parse(datetime.Substring(0, 4));
            month = int.Parse(datetime.Substring(4, 2));
            day = int.Parse(datetime.Substring(6, 2));

            DateTime date = new DateTime(year, month, day);

            // DEL 2013/07/31 �g�� ���x���P --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region ���\�[�X
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            //// ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            #endregion
            // DEL 2013/07/31 �g�� ���x���P ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            return date;
        }
        #endregion

        // ----- ADD huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� ----- >>>>>
        #region ������t�H�[�}�b�g����
        /// <summary>
        /// ������t�H�[�}�b�g����
        /// </summary>
        /// <param name="baseString">���͕�����</param>
        /// <param name="count">����</param>
        /// <returns>�����㕶����</returns>
        private string GetSubString(string baseString, int count)
        {
            string retString = baseString;
            if (!string.IsNullOrEmpty(retString) && retString.Length > count)
            {
                retString = retString.Substring(0, count);
            }

            return retString;
        }
        #endregion
        // ----- ADD huangt 2013/06/24 ��Q�� #36972�̑Ή� ���i�������ɋ󔒃��b�Z�[�W���\������� ----- <<<<<

        //-----ADD songg 2013/06/25 ��Q�� #37187�̑Ή� ����S�̐ݒ�}�X�^�擾 ---->>>>>
        /// <summary>
        /// ����S�̐ݒ�擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns></returns>
        private SalesTtlSt GetSalesTtlStInfo(string enterpriseCode, string sectionCode)
        {
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            const string methodName = "GetSalesTtlStInfo";
            EasyLogger.Write(CLASS_NAME, methodName, methodName + " �J�n");
            // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<

            // UPD 2013/08/02 #Redmine39451 ���x���P3 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region ���\�[�X
            //SalesTtlStAcs salesTtlStAcs = new SalesTtlStAcs();          // ����S�̐ݒ�}�X�^
            //SalesTtlSt tempSalesTtlSt = null;

            //int status = salesTtlStAcs.Read(out tempSalesTtlSt, enterpriseCode, sectionCode);

            //if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //    && (tempSalesTtlSt.LogicalDeleteCode == 0))
            //{
            //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            //    EasyLogger.Write(CLASS_NAME, methodName, "���_���A����S�̐ݒ���擾�@status�F" + status.ToString());
            //    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            //    // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            //    return tempSalesTtlSt;
            //}
            //else
            //{
            //    // �S�Ћ��_���A����S�̐ݒ���擾
            //    status = salesTtlStAcs.Read(out tempSalesTtlSt, enterpriseCode, "00");

            //    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //        && (tempSalesTtlSt.LogicalDeleteCode == 0))
            //    {
            //        // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            //        EasyLogger.Write(CLASS_NAME, methodName, "�S�Ћ��_���A����S�̐ݒ���擾�@status�F" + status.ToString());
            //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            //        // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            //        return tempSalesTtlSt;
            //    }
            //    else
            //    {
            //        // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- >>>>>
            //        EasyLogger.Write(CLASS_NAME, methodName, "�S�Ћ��_���A����S�̐ݒ���擾�@status�F" + status.ToString());
            //        EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
            //        // ----- ADD huangt 2013/06/25 Redmine#37231 �^�u���b�g���O�Ή� ----- <<<<<
            //        return null;
            //    }
            //}
            #endregion

            // ��x�Ǎ��ς݂ł���΁A�ēǂݍ��݂��Ȃ�
            if (this._salesTtlSt != null)
            {
                if (this._salesTtlSt.EnterpriseCode.Equals(enterpriseCode)
                && sectionCode.Trim().Equals(_saveSectionCode))
                {
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I���@����S�̐ݒ�}�X�^�Ǎ��ς݁i��ƁF" + enterpriseCode + "�@���_�F " + _saveSectionCode + "�j");
                    return this._salesTtlSt;
                }
            }
            // �������Ɏg�p���ꂽ���_�R�[�h��ۊ�
            _saveSectionCode = sectionCode.Trim();

            int status = _salesTtlStAcs.Read(out _salesTtlSt, enterpriseCode, sectionCode);


            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                && (_salesTtlSt.LogicalDeleteCode == 0))
            {

                // UPD 2013/08/02 #Redmine39451 ���x���P6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                #region ���\�[�X
                //EasyLogger.Write(CLASS_NAME, methodName, "���_���A����S�̐ݒ���擾�@status�F" + status.ToString());
                //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                #endregion
                EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I���@���_���A����S�̐ݒ���擾�@status�F" + status.ToString());
                // UPD 2013/08/02 #Redmine39451 ���x���P6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                return _salesTtlSt;
            }
            else
            {
                // �S�Ћ��_���A����S�̐ݒ���擾
                status = _salesTtlStAcs.Read(out _salesTtlSt, enterpriseCode, "00");

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    && (_salesTtlSt.LogicalDeleteCode == 0))
                {
                    // UPD 2013/08/02 #Redmine39451 ���x���P6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    #region ���\�[�X
                    //EasyLogger.Write(CLASS_NAME, methodName, "�S�Ћ��_���A����S�̐ݒ���擾�@status�F" + status.ToString());
                    //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                    #endregion
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I���@�S�Ћ��_���A����S�̐ݒ���擾�@status�F" + status.ToString());
                    // UPD 2013/08/02 #Redmine39451 ���x���P6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

                    return _salesTtlSt;
                }
                else
                {
                    // UPD 2013/08/02 #Redmine39451 ���x���P6 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    #region ���\�[�X
                    //EasyLogger.Write(CLASS_NAME, methodName, "�S�Ћ��_���A����S�̐ݒ���擾�@status�F" + status.ToString());
                    //EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I��");
                    #endregion
                    EasyLogger.Write(CLASS_NAME, methodName, methodName + " �I���@�S�Ћ��_���A����S�̐ݒ���擾�@status�F" + status.ToString());
                    // UPD 2013/08/02 #Redmine39451 ���x���P6 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    return null;
                }
            }
            // UPD 2013/08/02 #Redmine39451 ���x���P3 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }
        //-----ADD songg 2013/06/25 ��Q�� #37187�̑Ή� ����S�̐ݒ�}�X�^�擾 ----<<<<<

        // UPD 2013/08/01 �g�� Redmine#39496 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        #region ���\�[�X
        //// ADD 2013/07/31 �g�� ���Ӑ�Ǘ����_�Ή� ----------->>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// ���Ӑ���̎擾
        ///// </summary>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="customerCode">���Ӑ�R�[�h</param>
        ///// <returns>���Ӑ���</returns>
        //private CustomerInfo CustomerInfo(string enterpriseCode, int customerCode)
        //{
        //    if (_customerDB == null)
        //    {
        //        _customerDB = new CustomerInfoAcs();
        //    }

        //    if (_customerInfo == null || !_customerInfo.CustomerCode.Equals(customerCode))
        //    {
        //        _customerDB.ReadDBData(enterpriseCode, customerCode, out _customerInfo);
        //    }

        //    return _customerInfo;
        //}
        //// ADD 2013/07/31 �g�� ���Ӑ�Ǘ����_�Ή� -----------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion
        /// <summary>
        /// ���Ӑ���̎擾
        /// </summary>
        /// <returns>���Ӑ���</returns>
        private CustomerInfo CustomerInfo()
        {
            if (_customerDB == null)
            {
                _customerDB = new CustomerInfoAcs();
            }

            if (_customerInfo == null || !_customerInfo.CustomerCode.Equals(this._customerCode))
            {
                _customerDB.ReadDBData(this._enterpriseCode, this._customerCode, out _customerInfo);
            }

            return _customerInfo;
        }
        // UPD 2013/08/01 �g�� Redmine#39496 ---------<<<<<<<<<<<<<<<<<<<<<<<<<


        #endregion �����ʃ��\�b�h

        // ADD 2013/08/01 �g�� Redmine#39496 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �������ɕK�v�Ȋe�l�̃Z�b�g
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        public void SetDataInit(string enterpriseCode, int customerCode)
        {
            this._enterpriseCode = enterpriseCode;
            this._customerCode = customerCode;
        }
        // ADD 2013/08/01 �g�� Redmine#39496 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        
    }
}
