//**********************************************************************//
// System			:	PM.NS											//
// Sub System		:													//
// Program name		:	�d���ԕi�\��ꗗ�\�����[�g�I�u�W�F�N�g 			//
//					:	PMKAK02037R.DLL									//
// Name Space		:	Broadleaf.Windows.Forms							//
// Programmer		:	FSI���� ����									//
// Date				:	 2013/01/28	    								//
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//   		        :	        									    //
//----------------------------------------------------------------------//
//                 Copyright(c)2013 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;
using System.Runtime.InteropServices;

// �A�Z���u���Ɋւ����ʏ��͈ȉ��̑����Z�b�g���Ƃ����Đ��䂳��܂��B 
// �A�Z���u���Ɋ֘A�t�����Ă������ύX����ɂ́A
// �����̑����l��ύX���Ă��������B
[assembly: AssemblyTitle("PMKAK02037R")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2013 Broadleaf Co.,Ltd.")]
[assembly: AssemblyTrademark("Partsman")]
[assembly: AssemblyCulture("")]
[assembly: AssemblyDeployment(DeployPosition.Server, ConstantManagement_SF_PRO.ServerCode_UserAP)]

// ComVisible �� false �ɐݒ肷��ƁA���̃A�Z���u�����̌^�� COM �R���|�[�l���g�ɂ� 
// �Q�ƕs�\�ɂȂ�܂��BCOM ���炱�̃A�Z���u�����̌^�ɃA�N�Z�X����ꍇ�́A 
// ���̌^�� ComVisible ������ true �ɐݒ肵�Ă��������B
[assembly: ComVisible(false)]

// ���� GUID �́A���̃v���W�F�N�g�� COM �Ɍ��J�����ꍇ�́Atypelib �� ID �ł�
[assembly: Guid("de1f4775-5bef-484b-a7f6-069b7914fea6")]

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
