//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :	UOE���ɍX�V�A�N�Z�X�N���X						//
//                  :   PMUOE01203A.DLL                                 //
// Name Space		:	Broadleaf.Application.Controller				//
// Programmer       :   �Ɠc �M�u										// 
// Date             :   2008/09/04                                      // 
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ���N�n���@�@�@�@�@�@�@�@�@�@�@�@�@�@//
// �C �� ��  2012/08/30  �C�����e : 2012/09/12�z�M���A                  //
//                                  redmine #31885:�g�c����@�@�@�@�@�@ //
//                                  �݌ɓ��ɍX�V�����̑Ή��B            //
// �Ǘ��ԍ�              �쐬�S�� : chenw   �@�@�@�@�@�@�@�@�@�@�@�@�@�@//
// �C �� ��  2013/03/07  �C�����e : 2013/04/03�z�M��                    //
//                                  Redmine#34989�̑Ή����YUOEWEB��     //
//                                  ����(�n�o�d�m���i�Ή�)              //
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �����    �@�@�@�@�@�@�@�@�@�@�@�@�@//
// �C �� ��  2013/05/16  �C�����e : 2013/06/18�z�M��                    //
//                                  Redmine#35459 #42�̑Ή��@�@�@�@�@�@ //
// �Ǘ��ԍ�  11070149-00 �쐬�S�� : ���t    �@�@�@�@�@�@�@�@�@�@�@�@    //
// �C �� ��  2015/01/21  �C�����e : 2015/01/21�z�M��                    //
//                                  Redmine#44056 �݌ɓ��ɍX�V�Ł@�@�@�@//
//                                  �������`�F�b�N�̏C���̑Ή�          //
// �Ǘ��ԍ�  11170129-00 �쐬�S�� : �v��    �@�@�@�@�@�@�@�@�@�@�@�@    //
// �C �� ��  2015/08/26  �C�����e : Redmine#47030 �y��332�z�݌ɓ��ɍX�V //
//                                  �̏�Q�Ή�                    �@�@�@//
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : 杍^    �@�@�@�@�@�@�@�@�@�@�@�@    //
// �C �� ��  2017/08/11  �C�����e : �n���f�B�^�[�~�i���݌Ɏd���o�^�̑Ή�//
//----------------------------------------------------------------------//
//                 Copyright(c)2008 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;


// �A�Z���u���Ɋւ����ʏ��͈ȉ��� 
// �����Z�b�g��ʂ��Đ��䂳��܂��B�A�Z���u���Ɋ֘A�t�����Ă��� 
// ����ύX����ɂ́A�����̑����l��ύX���Ă��������B
[assembly: AssemblyTitle("PMUOE01203A")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("DistributionCore")]
[assembly: AssemblyCopyright("(c)2008 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("DistributionCore")]
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

[assembly: AssemblyVersion("1.10.1.0")]
[assembly: AssemblyFileVersion("1.10.1.0")]

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
