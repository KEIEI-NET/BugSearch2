using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

//******************************************************************************//
// System           :   �o�l�D�m�r�@                                             //
// Sub System       :                                                           //
// Program name     :   �d����d�q���� �����[�g�I�u�W�F�N�g                       //
//                  :   PMKOU04014R.DLL									        //
// Name Space       :   Broadleaf.Application.Remoting.Adapter			        //
// Programmer       :   23015 �X�{ ��P	                          �@�@          //
// Date             :   2008.08.18                                              //
//------------------------------------------------------------------------------//
// Update Note      :	2009/09/08 ���̕�                                       //
//                  :   PM.NS-2-B�E�o�l�D�m�r�ێ�˗��@
//                  :               �ߋ����\���Ή�                              
// Update Note      :	2010/07/20 chenyd                                       //
//                  :   �e�L�X�g�o�͑Ή�                                        //
// Update Note      :	2011/03/22 ������                                       //
//                  :   �Ɖ�v���O�����̃��O�o�͑Ή�                            //
// Update Note      :	2012/08/09 wangf                                        //
//                  :   10801804-00�A9/12�z�M���ARedmine#31533 �d����d�q���� �i�Ԏw�莞�̒��o�s���̑Ή�//
//                  :   �i�Ԃ��n�C�t�������œ��͂����ꍇ�A�d����d�q�����͓��Ӑ�d�q�����Ɠ����悤�ɒ��o�\�ɂȂ�܂��B//
// Update Note      :	2015/08/21 �c�v�t                                       //
//                  :   11170129-00�ARedmine#47007�F���|������ł��s���̏�Q�Ή�//
//------------------------------------------------------------------------------//
// Update Note      :	2015/12/22 �ړ�                                         //
//                  :   11170204-00 2016�N1���z�M��                             //
//                  :   Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�P�A�Q�̑Ή�//
//------------------------------------------------------------------------------//
// Update Note      :   2015/12/25 �ړ�                                         //
//                  :   11170204-00 2016�N1���z�M��                             //
//                  :   Redmine#48327 �d���d�q�����c���e�L�X�g�o�͕s����Q�R�̑Ή�//
//------------------------------------------------------------------------------//
// Update Note      :   2016/02/02 �ړ�                                         //
//                  :   11200002-00 2016�N2���z�M��                             //
//                  :   Redmine#48327 �d�������I�v�V�������L���̏ꍇ�ɑS���_����//
//                  :   ���R�[�h���o�͂����т��Ȃ����̂�ALL�[���ɂ���B�@�@�@�@ //
//------------------------------------------------------------------------------//
// Update Note      :�@ 2020/03/11 ���V�� PMKOBETSU-2912 �y���ŗ��Ή�           //
//------------------------------------------------------------------------------//
//                   (c)Copyright  2008 Broadleaf Co.,Ltd.                      //
//******************************************************************************//

//
// �A�Z���u���Ɋւ����ʏ��͈ȉ��� 
// �����Z�b�g��ʂ��Đ��䂳��܂��B�A�Z���u���Ɋ֘A�t�����Ă��� 
// ����ύX����ɂ́A�����̑����l��ύX���Ă��������B
//
[assembly: AssemblyTitle("PMKOU04014R")]
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
