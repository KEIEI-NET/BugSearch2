//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   �݌Ƀ}�X�^�i�C���|�[�g�jDB�����[�g�I�u�W�F�N�g  //
//                  :   PMKHN07604R.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting                  //
// Programmer       :   zhangy3                                         //
// Date             :   2012/06/12                                      //
//----------------------------------------------------------------------//
// �Ǘ��ԍ� 10801804-00  �쐬�S�� : zhangy3 
// �C �� �� 2012/07/03   �C�����e : Redmine#30387 ���i�}�X�^�C���{�[�g�`�F�b�N�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10801804-00  �쐬�S�� : zhangy3 
// �C �� �� 2012/07/05   �C�����e : Redmine#30387��Q�ꗗ�̎w�ENO.30�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10801804-00  �쐬�S�� : ������ 
// �C �� �� 2012/07/11   �C�����e : Redmine#30387��Q�ꗗ�̎w�ENO.30�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10801804-00  �쐬�S�� : ������ 
// �C �� �� 2012/07/12   �C�����e : Redmine#30387��Q�ꗗ�̎w�ENO.93�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10801804-00  �쐬�S�� : ������ 
// �C �� �� 2012/07/13   �C�����e : Redmine#30387��Q�ꗗ�̎w�ENO.94�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : zhangy3
// �C �� ��  2012/07/20  �C�����e : ��z�Č��ARedmine#30387 �݌Ƀ}�X�^�C���{�[�g�d�l�ύX�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : zhangy3
// �C �� ��  2012/07/25  �C�����e : ��z�Č��ARedmine#30387 �d���`�F�b�N�̃��b�Z�[�W��ύX����
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

//
// �A�Z���u���Ɋւ����ʏ��͈ȉ���
// �����Z�b�g��ʂ��Đ��䂳��܂��B�A�Z���u���Ɋ֘A�t�����Ă���
// ����ύX����ɂ́A�����̑����l��ύX���Ă��������B
//
[assembly: AssemblyTitle("PMKHN07604R.DLL")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2012 Broadleaf Co.,Ltd.")]
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

