//**********************************************************************//
// System			:	MA.NS					    				    //
// Sub System       :													//
// Program name     :	�I���֘A�ꗗ�\UI�N���X	                        //
//					:	MAZAI02110U.DLL					        	    //
// Name Space		:	Broadleaf.Application.UIData       				//
// Programmer		:	23010 �����@�m								    //
// Date				:	2007.04.09										//
//----------------------------------------------------------------------//
// Update Note      :   2008.10.07 30413 ����                           //
//   		        :	PM.NS�Ή�									    //
//----------------------------------------------------------------------//
// Update Note          2009.12.04 ������                               //
//                      �s��Ή�(PM.NS�ێ�˗��B�Ή�)                 //
//----------------------------------------------------------------------//
// Update Note      :   2011.01.11 liyp                                 //
//                      �s��Ή�(PM1101B)                             //
//----------------------------------------------------------------------//
// Update Note          2011/01/11 �c����                               //
//                      �I����Q�Ή�                 �@                 //
//----------------------------------------------------------------------//
// Update Note          2011/02/17 �c����                               //
//                      �I�������\�̒I�ԃu���C�N�敪�̗L�������̃`�F�b�N�ɂ���//
//----------------------------------------------------------------------//
// Update Note      :   2012/11/14 ������                               //
//   		        :	2013/01/16�z�M���ARedmine#33271 				//
//                      �󎚐���̋敪�̒ǉ�                            //
//----------------------------------------------------------------------//
// Update Note	    :	2012/12/25	���j��							    //
//                  :   2013/01/16�z�M���ARedmine#33271                 //
//                      ���[�̌r���󎚁i����E���Ȃ��j��O��w�肵����  //
//                      �̂��L�������邱�Ƃ̐ݒ��ǉ�����              //
//----------------------------------------------------------------------//
// Update Note	    :	K2014/03/10	licb							    //
//                  :   �M�z�����ԏ���ʊJ��                 �@�@�@�@ //
//                      �e�L�X�g�o�͋@�\��ǉ����� �@�@�@�@�@�@�@�@�@�@ //
//----------------------------------------------------------------------//
//				  (c)Copyright  2007 Broadleaf Co.,Ltd.                	//
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using System.Runtime.InteropServices;

// �A�Z���u���Ɋւ����ʏ��͈ȉ��̑����Z�b�g���Ƃ����Đ��䂳��܂��B 
// �A�Z���u���Ɋ֘A�t�����Ă������ύX����ɂ́A
// �����̑����l��ύX���Ă��������B
[assembly: AssemblyTitle("MAZAI02110U")]
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