//****************************************************************************************//
// System			:	PM.NS                                                             //
// Sub System       :	                                                                  //
// Program name     :	UOE�����m�F�p�A�N�Z�X�N���X					                      //
//					:	PMUOE04104A.DLL									                  //
// Name Space		:	Broadleaf.Application.Controller				                  //
// Programmer		:	�Ɠc �M�u    									                  //
// Date				:	2008/08/07										                  //
//----------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : �k���r                                                //
// �C �� ��  2010/03/08  �C�����e : PM1006                                                //
//                                  �O���b�h�^�C�g���̕\������Ή�                        //
//----------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  10601190-00 �쐬�S�� : ������                                                //
// �C �� ��  2010/05/14  �C�����e : PM1008                                                //
//                                  �O���b�h�^�C�g���̕\������̑Ή�(����UOEWeb)          //
//----------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-00 �쐬�S�� : ������                                                //
// �C �� ��  2010/12/31  �C�����e : UOE����������                                         //
//----------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-00 �쐬�S�� : �� ��                                                 //
// �C �� ��  2011/01/30  �C�����e : UOE����������                                         //
//----------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  10607734-01 �쐬�S�� : liyp                                                  //
// �C �� ��  2011/03/01  �C�����e : ���YUOE������B�Ή�                                    //
//----------------------------------------------------------------------------------------//
// �Ǘ��ԍ�  10702591-00 �쐬�S�� : �{�z��                                                 //
// �C �� ��  2011/05/10  �C�����e : �O���b�h�w�b�_�[HashTable�֘A�̕ύX                    //
//----------------------------------------------------------------------------------------//
//                 Copyright(c)2008 Broadleaf Co.,Ltd.                                    //
//****************************************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;

//
// �A�Z���u���Ɋւ����ʏ��͈ȉ��� 
// �����Z�b�g��ʂ��Đ��䂳��܂��B�A�Z���u���Ɋ֘A�t�����Ă��� 
// ����ύX����ɂ́A�����̑����l��ύX���Ă��������B
//
[assembly: AssemblyTitle("PMUOE04104A")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2008 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Client)]		

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
