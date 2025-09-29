using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

//**********************************************************************//
// System           :   DC.NS                                           //
// Sub System       :                                                   //
// Program name     :   ���㗚���Ɖ���[�g�I�u�W�F�N�g		        //
//                  :   DCHNB04114R.DLL									//
// Name Space       :   Broadleaf.Application.Remoting					//
// Programmer       :   980081 �R�c ���F	                            //
// Date             :   2007.10.03                                      //
//----------------------------------------------------------------------//
// Update Note      :   2007.12.13  980081  �R�c ���F                   //
// Date             :   �_���폜�敪�̃`�F�b�N��ǉ�                    //
//----------------------------------------------------------------------//
// Update Note      :   2008.01.21  980081  �R�c ���F                   //
// Date             :   ���o�����E���o���ʂ̃��C�A�E�g���ꕔ�ύX        //
//----------------------------------------------------------------------//
// Update Note      :   2008.01.24  980081  �R�c ���F                   //
// Date             :   ���i�ԍ��̐擪��v�����Ή�                      //
//                  :   ���i���̂̂����܂������Ή�                      //
//----------------------------------------------------------------------//
// Update Note      :	�o�l.�m�r�p�ɕύX       						//
// Update Date      :   2008.06.23                                      //
//                  :   20081 �D�c �E�l�@                               //
//----------------------------------------------------------------------//
// Update Note      :   2011/03/22  ���N�n��                            //
// Date             :   �Ɖ�v���O�����̃��O�o�͑Ή�                    //
//----------------------------------------------------------------------//
// Update Note      :	Redmine 26539�Ή�      						    //
// Update Date      :   2011/11/11 ���N�n��                             //�@  
//----------------------------------------------------------------------//
// Update Note      :   2023/11/07 3H ����                            //
//   		        :	11900025-00 READUNCOMMITTED�Ή�                 //
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

//
// �A�Z���u���Ɋւ����ʏ��͈ȉ��� 
// �����Z�b�g��ʂ��Đ��䂳��܂��B�A�Z���u���Ɋ֘A�t�����Ă��� 
// ����ύX����ɂ́A�����̑����l��ύX���Ă��������B
//
[assembly: AssemblyTitle("DCHNB04114R.DLL")]
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
