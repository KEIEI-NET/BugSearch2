//*************************************************************************************//
// System			:	PM.NS		 							                       //
// Sub System       :							�@�@�@�@�@�@			               //
// Program name     :	���_�Ǘ����O�Q�ƃc�[���@�@�@�@�@                               //
//					:	PMKYO09505R.DLL								                   //
// Name Space		:	Broadleaf.Application.Remoting						           //
// Programmer		:	����									                       //
// Date				:	2012/07/23										               //
//-------------------------------------------------------------------------------------//
// Update Note      :   2012/10/08 �������@�@                                          //  
//                      Redmine#31026 �\�[�X�̃R�����g��PG���̂̏C��                   //
//-------------------------------------------------------------------------------------//
// Update Note      :   2012/10/16 �������@�@                                          //  
//                      Redmine#31026 ���_�Ǘ����O�Q�ƃc�[���s��̑Ή�               //
//-------------------------------------------------------------------------------------//
// Update Note      :   2012/12/18 ���j�ā@�@                                          //  
//                      Redmine#33961 ���_�Ǘ����O�Q�ƃc�[���ɂāA����M�敪��         //
//�@�@�@�@�@�@�@�@�@�@�u�S�āv���w�肵�����s���̑Ή�                                   //
//-------------------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.                                //
//*************************************************************************************//

using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

// �A�Z���u���Ɋւ����ʏ��͈ȉ��̑����Z�b�g���Ƃ����Đ��䂳��܂��B 
// �A�Z���u���Ɋ֘A�t�����Ă������ύX����ɂ́A
// �����̑����l��ύX���Ă��������B
[assembly: AssemblyTitle("PMKYO09505R")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2012 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Server, ConstantManagement_SF_PRO.ServerCode_Center_UserAP)]

// ComVisible �� false �ɐݒ肷��ƁA���̃A�Z���u�����̌^�� COM �R���|�[�l���g�ɂ� 
// �Q�ƕs�\�ɂȂ�܂��BCOM ���炱�̃A�Z���u�����̌^�ɃA�N�Z�X����ꍇ�́A 
// ���̌^�� ComVisible ������ true �ɐݒ肵�Ă��������B
[assembly: ComVisible(false)]

// �A�Z���u���̃o�[�W�������́A�ȉ��� 4 �̒l�ō\������Ă��܂�:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// ���ׂĂ̒l���w�肷�邩�A���̂悤�� '*' ���g���ă��r�W��������уr���h�ԍ��� 
// ����l�ɂ��邱�Ƃ��ł��܂�:
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