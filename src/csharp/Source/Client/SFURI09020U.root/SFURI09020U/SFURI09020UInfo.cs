//**********************************************************************//
// System			:	�r�e�D�m�d�s									//
// Sub System       :				     								//
// Program name     :	�`�[����ݒ���								//
//					:	SFURI09020U.DLL									//
// Name Space		:	Broadleaf.Windows.Forms							//
// Programmer		:	���� ���q										//
// Date				:	2005.08.31										//
//----------------------------------------------------------------------//
// Update Note		:	2006.01.24  22024 ���� �_�u						//
//					:		�E�t�@�C�����C�A�E�g�ύX�ɔ������ڒǉ�		//
//					:	2006.01.25  22024 ���� �_�u						//
//					:		�E�`�[�R�����g��\���ɕύX					//
//					:		�E�o�͊m�F���b�Z�[�W��\���ɕύX			//
//					:		�E�`�[������[ID���\���ɕύX				//
//					:	2006.05.09  22024 ���� �_�u						//
//					:		�E���ږ��̕ύX�F�t�H���g���́˃t�H���g		//
//                  :   2008.06.05 30413 ����                           //
//                  :         �EPM.NS�p�Ƀo�[�W��������ύX           //
//                  :   2009.12.31 ���M                                 //
//                  :         �EPM.NS�ێ�˗��C�Ή�                     //
//                  :   2010.08.06 caowj                                //
//                  :         �EPM.NS1012�Ή�                           //
//                  :   2011/02/16 ���N�n��                             //
//                  :         �E���Ж��̂P�C�Q���c�{�p�ɂȂ��Ă��Ȃ��s  //
//                             ��̑Ή�                               //
// Update Date      :   2011/07/19 chenyd                               //
//                  :         �E�񓚋敪�ǉ��̑Ή�  �@�@�@�@�@�@�@�@�@�@//
// Update Note      :  2011/08/08  �����g�@�@�@�@�@�@�@�@�@�@�@�@�@�@ �@//
//                            �E��Q�� #23459�Ή�   �@�@�@�@�@�@�@�@�@//
// Update Date      :   2011/08/11 zhubj                                //
//                  :         �E�u�ʏ�}�[�N�v�u�蓮�񓚁v�u�����񓚃}�[�N�v�G�f�b�g�������Ή�//
//                  :         �E�u����v�{�^���ŏI�������A�ۑ��m�F�_�C�A���O���\���Ή�//
//----------------------------------------------------------------------//
//				  (c)Copyright  2007 Broadleaf Co.,Ltd.		            //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;

//
// �A�Z���u���Ɋւ����ʏ��͈ȉ��� 
// �����Z�b�g��ʂ��Đ��䂳��܂��B�A�Z���u���Ɋ֘A�t�����Ă��� 
// ����ύX����ɂ́A�����̑����l��ύX���Ă��������B
//
[assembly: AssemblyTitle("SFURI09020U")]
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
