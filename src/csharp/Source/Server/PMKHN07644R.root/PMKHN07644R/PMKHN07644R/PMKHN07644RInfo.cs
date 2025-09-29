//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���Ӑ�}�X�^�i�C���|�[�g�jDB�����[�g�I�u�W�F�N�g
//                  :   PMKHN07644R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   ���w�q
// Date             :   2009.05.15
//----------------------------------------------------------------------
// Update Note      :   2012/06/12 �������@�@                           
//   		        :	10801804-00   ��z�Č� Redmine#30393              
//                      ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g            
//                      ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ�               
//----------------------------------------------------------------------
// Update Note      :   2012/07/03 �������@�@                           
//   		        :	10801804-00   ��z�Č� Redmine#30393              
//                      ���Ӑ�}�X�^�C���|�[�g�E�G�N�X�|�[�g            
//                      ���Ӑ�|���O���[�v�ƃ`�F�b�N��ǉ��̉���                
//----------------------------------------------------------------------
// Update Note      :   2012/07/05 �������@�@                           
//   		        :	10801804-00   ��z�Č� Redmine#30387              
//                      ��Q�ꗗ�̎w�ENO.30�̑Ή�
//----------------------------------------------------------------------
// Update Note      :   2012/07/09 �������@�@                           
//   		        :	10801804-00   ��z�Č� Redmine#30387              
//                      ��Q�ꗗ�̎w�ENO.39�ANO.46�ANO.47�ANO.48�ANO.49�ANO.51�̑Ή�
//----------------------------------------------------------------------
// Update Note      :   2012/07/11 �������@�@                           
//   		        :	10801804-00   ��z�Č� Redmine#30387              
//                      ��Q�ꗗ�̎w�ENO.30�ANO.48�ANO.56�ANO.59�ANO.60�ANO.61�ANO.62�̑Ή�
//----------------------------------------------------------------------
// Update Note      :   2012/07/13 �������@�@                           
//   		        :	10801804-00   ��z�Č� Redmine#30387              
//                      ��Q�ꗗ�̎w�ENO.7�ANO.48�ANO.94�ANO.95�̑Ή�
//----------------------------------------------------------------------
// Update Note      :   2012/07/20 �������@�@                           
//   		        :	10801804-00   ��z�Č� Redmine#30387              
//                      ��Q�ꗗ�̎w�ENO.94�ANO.106�ANO.107�ANO.108�̑Ή�
//----------------------------------------------------------------------
// Update Note      :   2012/07/24 �������@�@                           
//   		        :	10801804-00   ��z�Č� Redmine#30387              
//                      ���쌟�؁A��Q�ꗗ�̎w�ENO.61�ANO.106�̑Ή�
//----------------------------------------------------------------------
//Update Note       :   2013/03/25 wangl2</br>
//                      10801804-00�@Redmine#35047�@�@
//                      No.1841���Ӑ�C���|�[�g�̑Ή�
//----------------------------------------------------------------------
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************

using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

//
// �A�Z���u���Ɋւ����ʏ��͈ȉ���
// �����Z�b�g��ʂ��Đ��䂳��܂��B�A�Z���u���Ɋ֘A�t�����Ă���
// ����ύX����ɂ́A�����̑����l��ύX���Ă��������B
//
[assembly: AssemblyTitle("PMKHN07644R.DLL")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Broadleaf Co.,Ltd.")]
[assembly: AssemblyProduct("Partsman")]
[assembly: AssemblyCopyright("(c)2009 Broadleaf Co.,Ltd.")]
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
