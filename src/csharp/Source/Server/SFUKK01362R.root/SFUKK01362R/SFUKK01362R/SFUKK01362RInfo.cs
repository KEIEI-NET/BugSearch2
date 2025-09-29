//**********************************************************************//
// System           :   PM.NS
// Sub System       :
// Program name     :   �����X�V���������[�e�B���O
//                  :   SFUKK01362R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programer        :   ���i�@��
// Date             :   2005.08.11
//----------------------------------------------------------------------//
// Update Note      :
// 2006.02.20 toku  : ����p�ʓ����Ή�
// 2006.10.18 toku	: �g�����U�N�V�����������x����ύX
// ---------------------------------------------------------------------
// 2007.01.23       : 18322 T.Kimura MA.NS�p�ɕύX
// 2007.03.27 �ؑ�  : ���Ӑ搿��(���|)���z�}�X�^�̍X�V�͏���������
//                    �s���悤�ɕύX���ꂽ�ׁA�X�V�������폜
//----------------------------------------------------------------------//
// 2007.10.11       :  980081 A.Yamada DC.NS�p�ɕύX
// 2007.12.10       :  EdiTakeInDate(EDI�捞��)��Int32��DateTime�ɕύX
// 2008.01.11       :  �_���폜�@�\��ǉ�(LogicalDelete)
//----------------------------------------------------------------------//
// 2008.04.25       :  21112  PM.NS�p�ɕύX
//----------------------------------------------------------------------//
// Update Note		:  2010/12/20 ����� PM.NS��Q���ǑΉ�(12����)	    //
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/10/17  �C�����e : Redmine#32870�A2012/11/14�z�M�� PM.NS��Q�ꗗNo.1516 �����`�[����/���|�c�����قȂ�̑Ή��B
//                                : �����`�[�ۑ�����֘A�̓��Ӑ�i�ϓ����j�̌��ݔ��|�c���̒l�̑Ή��B
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/10/29  �C�����e : Redmine#32870�A2012/11/14�z�M�� PM.NS��Q�ꗗNo.1516 �����`�[����/���|�c�����قȂ�̍đΉ��B
//                                : �����`�[�ۑ�����֘A�̓��Ӑ�i�ϓ����j�̌��ݔ��|�c���̒l�̍đΉ��B
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf
// �C �� ��  2012/11/06  �C�����e : Redmine#32870�A2012/11/14�z�M�� PM.NS��Q�ꗗNo.1516 �����`�[����/���|�c�����قȂ�̍đΉ��B
//                                : �����`�[�ۑ�����֘A�̓��Ӑ�i�ϓ����j�̌��ݔ��|�c���̒l�̍đΉ��B
//                                : �������v�̓}�C�i�X�l��ݒ肷��΁A���ݔ��|�c���̍X�V�̑Ή��B
//----------------------------------------------------------------------//
// Update Note      :   2013/01/10 zhuhh                                //
// �Ǘ��ԍ�         :   10806793-00�@2013/03/13�z�M��                   //
//                  :   Redmine #34123 ��`�f�[�^�d�������`�[�ԍ��̓o�^ //
//                                                      ���o����l�ɂ���//
//--------------------------------------------------------------------  //
//                (c)Copyright  2008 Broadleaf Co,. Ltd
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;

using Broadleaf.Library;
using Broadleaf.Application.Resources;

//
// �A�Z���u���Ɋւ����ʏ��͈ȉ��� 
// �����Z�b�g��ʂ��Đ��䂳��܂��B�A�Z���u���Ɋ֘A�t�����Ă��� 
// ����ύX����ɂ́A�����̑����l��ύX���Ă��������B
//
[assembly: AssemblyTitle("SFUKK01362R")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2008 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Server, ConstantManagement_SF_PRO.ServerCode_UserAP)]		

//
// �A�Z���u���̃o�[�W�������́A�ȉ��� 4 �̑����ō\������܂� :
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// ���ɂ���悤�ɁA'*' ���g���āA���ׂĂ̒l���w�肷�邩�A
// �r���h����у��r�W�����ԍ�������l�ɂ��邱�Ƃ��ł��܂��B

[assembly: AssemblyVersion("8.10.1.0")]
[assembly: AssemblyFileVersion("8.10.1.0")]

//
// �A�Z���u���ɏ�������ɂ́A�g�p����L�[���w�肵�Ȃ���΂Ȃ�܂���B 
// �A�Z���u�������Ɋւ���ڍׂɂ��ẮAMicrosoft .NET Framework �h�L�������g���Q�Ƃ��Ă��������B
//
// ���L�̑������g���āA�����Ɏg���L�[�𐧌䂵�܂��B 
//
// ���� : 
//   (*) �L�[���w�肳��Ȃ��ƁA�A�Z���u���͏�������܂���B
//   (*) KeyName �́A�R���s���[�^�ɃC���X�g�[������Ă���
//        �Í��T�[�r�X �v���o�C�_ (CSP) �̃L�[��\���܂��BKeyFile �́A
//       �L�[���܂ރt�@�C���ł��B
//   (*) KeyFile ����� KeyName �̒l�����Ɏw�肳��Ă���ꍇ�́A 
//       �ȉ��̏������s���܂� :
//       (1) KeyName �� CSP �Ɍ��������ꍇ�A���̃L�[���g���܂��B
//       (2) KeyName �����݂����AKeyFile �����݂���ꍇ�A 
//           KeyFile �ɂ���L�[�� CSP �ɃC���X�g�[������A�g���܂��B
//   (*) KeyFile ���쐬����ɂ́Asn.exe (�����Ȗ��O) ���[�e�B���e�B���g���Ă��������B
//       KeyFile ���w�肷��Ƃ��AKeyFile �̏ꏊ�́A
//       �v���W�F�N�g�o�� �f�B���N�g���ւ̑��΃p�X�łȂ���΂Ȃ�܂���B
//       �p�X�́A%Project Directory%\obj\<configuration> �ł��B���Ƃ��΁AKeyFile ���v���W�F�N�g �f�B���N�g���ɂ���ꍇ�A
//       AssemblyKeyFile ������ 
//       [assembly: AssemblyKeyFile("..\\..\\mykey.snk")] �Ƃ��Ďw�肵�܂��B
//   (*) �x�������͍��x�ȃI�v�V�����ł��B
//       �ڍׂɂ��Ă� Microsoft .NET Framework �h�L�������g���Q�Ƃ��Ă��������B
//
[assembly: AssemblyDelaySign(false)]
[assembly: AssemblyKeyFile("")]
[assembly: AssemblyKeyName("")]
