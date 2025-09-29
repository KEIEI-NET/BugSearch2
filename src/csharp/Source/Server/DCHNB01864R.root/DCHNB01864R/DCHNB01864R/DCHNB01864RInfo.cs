using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ����E�d�����䃊���[�g�I�u�W�F�N�g              //
//                  :   DCHNB01864R.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting                  //
// Programmer       :   21112�@�v�ۓc�@��                               //
// Date             :   2008.02.13                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : wangf                               //
// �C �� ��  2012/11/09  �C�����e : Redmine#33215 12��12���z�M���APM.NS��Q�ꗗNo.1582�̑Ή�//
//                                : ����`�[���� ���������̎�����̔r���̑Ή�//
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  11370016-00 �쐬�S�� : ���O                               //
// �C �� ��  2017/03/30  �C�����e : Redmine#49164                        //
//                                : Tablet�`�[������Z�b�V����ID�̏ꍇ�ɏd���o�^���Ȃ��悤�ɏC��//
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  11600006-00 �쐬�S�� : ���O                              //
// �C �� ��  2020/03/25  �C�����e : PMKOBETSU-3622�Ή�                  //
//                                : UOE�������M�s��̑Ή��i�A�v���P�[�V�������b�N�s��Ή��j//
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

//
// �A�Z���u���Ɋւ����ʏ��͈ȉ���
// �����Z�b�g��ʂ��Đ��䂳��܂��B�A�Z���u���Ɋ֘A�t�����Ă���
// ����ύX����ɂ́A�����̑����l��ύX���Ă��������B
//
[assembly: AssemblyTitle("DCHNB01864R.DLL")]
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
