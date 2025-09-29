using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

//**********************************************************************//
// System           :   �o�l�D�m�r�@                                    //
// Sub System       :                                                   //
// Program name     :   �݌Ɉړ������[�g�I�u�W�F�N�g			    	//
//                  :   MAZAI04124R.DLL									//
// Name Space       :   Broadleaf.Application.Remoting					//
// Programmer       :   22008�@�����@���n	                            //
// Date             :   2008.04.23                                      //
//----------------------------------------------------------------------//
// Update Note      :	2010/11/15 ������ ��Q���ǑΉ������u�Q�v�̑Ή��@//
//----------------------------------------------------------------------//
// Update Note      : �@2012/05/22 wangf                                //
// �@�@�@�@         : �@10801804-00�A06/27�z�M���ARedmine#29881 �݌Ɉړ����͒��o�����ɓ��t���w�肵�Ă����f����Ȃ��̑Ή�//
//----------------------------------------------------------------------//
// Update Note      :   K2013/12/10  wangl2 �@�@�@�@                    //
//                  :   �t�^�o�ʑΉ�     ���_�Ԕ�������               //
//----------------------------------------------------------------------//
// Update Note      :   K2013/12/25  ���N�n�� �@�@�@�@                  //
//                  :   �t�^�o�ʑΉ�                                  //
//----------------------------------------------------------------------//
// Update Note      :    2016/04/26  ����     �@�@�@�@                  //
//                  :   Redmine#48729 �݌Ɉړ����͂̓��׎����Q�̑Ή�  //
//----------------------------------------------------------------------//
// Update Note      :   2017/08/02  ���O �@�@�@�@                     //
//                  :   �n���f�B�^�[�~�i���񎟊J���̑Ή�                //
//----------------------------------------------------------------------//
// Update Note      :   K2020/03/25 ���O                              //
//                  :   PMKOBETSU-3622�Ή� UOE�������M�s��̑Ή�      //
// Update Note      :   K2021/02/02 ������                              //
//                  :   PMKOBETSU-4114 ���׏������O�ǉ��Ή�            //
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

//
// �A�Z���u���Ɋւ����ʏ��͈ȉ��� 
// �����Z�b�g��ʂ��Đ��䂳��܂��B�A�Z���u���Ɋ֘A�t�����Ă��� 
// ����ύX����ɂ́A�����̑����l��ύX���Ă��������B
//
[assembly: AssemblyTitle("MAZAI04124R.DLL")]
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
