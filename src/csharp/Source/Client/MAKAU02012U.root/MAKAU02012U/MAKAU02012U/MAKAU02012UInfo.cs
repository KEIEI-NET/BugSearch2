//**********************************************************************//
// System           :   �l�`�D�m�d�s                                    //
// Sub System       :                                                   //
// Program name     :   ���������(�ꗗ�E���v�E����)�����t�H�[���N���X  //
//                  :   MAKAU02012U.DLL                                 //
// Name Space       :   Broadleaf.Windows.Forms                         //
// Programmer       :   Y.Sasaki                                        //
// Date             :   2006.08.01                                      //
//----------------------------------------------------------------------//
// Update Note      :   2006.08.01  Y.Sasaki                            //
//                  :   �P.�w�b�_�R�����g�ǉ�                           //
// Update Note      :   2006.08.18  Y.Sasaki                            //
//                  :   �P.�u���b�V���A�b�v�Ή�                         //
//                  :      ���o����ʋ��ʕ��i���ɔ����C��               //
// Update Note      :   2006.08.31  Y.Sasaki                            //
//                  :   �P.�e�L�X�g�o�͑Ή�                             //
//                  :   �Q.DataView�̃t�B���^�����Čv�Z�����R��ǉ�     //
// Update Note      :   2006.09.05  Y.Sasaki                            //
//                  :   �P.���������s����v�Ƀf�t�H���g�Ń`�F�b�N��     //
//                  :      ���悤�ɏC��                               //
//                  :   �Q.���b�Z�[�W�o�̓^�C�~���O�̕ύX               //
// Update Note      :   2006.10.24 Y.Sasaki                             //
//                  :   �P.�i�ǑΉ� No.02204357-11-2-001060-01          //
//                  :      ���o����ʂ����C���t�H�[���̃Z���^�[��       //
//                  :      ����悤�ɏC��                               //
// Update Note      :   2007.01.19  ����_�u                            //
//                  :   �P.WindowsVista�ł̓E�C���h�E�̍�����771�ׁ̈A  //
//                  :      �G�N�X�v���[���[�o�[�̕\����Ԋ�l��ύX   //
// Update Note      :   20081 �D�c �E�l                                 //
//                  :   2007.10.15 DC.NS�p�ɕύX                        //
//----------------------------------------------------------------------//
// Update Note      :   2008.09.04 30413 ����                           //
//   		        :	PM.NS�Ή�									    //
//----------------------------------------------------------------------//
// Update Note      :   2011/02/16 ���N�n��                             //
//   		        :	��������̑��x�A�b�v�Ή�						//
//----------------------------------------------------------------------//
// Update Note      :   2011/03/14 yangmj                               //
//   		        :	�󎚐���̋敪�̒ǉ��Ή�						//
//----------------------------------------------------------------------//
// Update Note      :   2011/03/23 ������                               //
//   		        :	�d�l�A�� #20083         						//
//----------------------------------------------------------------------//
// Update Note      :   2011/12/27 �����H�@�@ 	                        //
// �Ǘ��ԍ�         :   10707327-00 2012/01/25�z�M��                    //
//----------------------------------------------------------------------//
// Update Note      :   2020/04/13 ���O                               //
//   		        :	11570208-00 �y���ŗ��Ή�                        //
//----------------------------------------------------------------------//
//                Copyright(c)2006 Broadleaf Co.,Ltd.                   //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;

//
// �A�Z���u���Ɋւ����ʏ��͈ȉ��� 
// �����Z�b�g��ʂ��Đ��䂳��܂��B�A�Z���u���Ɋ֘A�t�����Ă��� 
// ����ύX����ɂ́A�����̑����l��ύX���Ă��������B
//
[assembly: AssemblyTitle("MAKAU02012U")]
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
