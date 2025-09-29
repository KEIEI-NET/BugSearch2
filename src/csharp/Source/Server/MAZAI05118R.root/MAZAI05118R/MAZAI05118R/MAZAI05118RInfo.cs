using System.Reflection;
using System.Runtime.CompilerServices;
using Broadleaf.Library;
using Broadleaf.Application.Resources;

//**********************************************************************//
// System           :   �o�l�D�m�r�@                                    //
// Sub System       :                                                   //
// Program name     :   �I���������������[�g�I�u�W�F�N�g	            //
//                  :   MAZAI05118R.DLL									//
// Name Space       :   Broadleaf.Application.Remoting					//
// Programmer       :   22008�@�����@���n	                            //
// Date             :   2008.04.23                                      //
//----------------------------------------------------------------------//
// Update Note		:	2009/11/30 ���M    �ێ�˗��B�Ή��ɕύX 		//
//----------------------------------------------------------------------//
// Update Note		:	2010/02/20 �����  �ێ�˗�PM1005�Ή��ɕύX 	//
//----------------------------------------------------------------------//
// Update Note		:	2011/01/11 yangmj  �I����Q�Ή�             	//
//----------------------------------------------------------------------//
// Update Note		:	2011/01/28 yangmj  readmine#18750�A18751�̏C��	//
//----------------------------------------------------------------------//
// Update Note		:	2011/01/30 yangmj  readmine#18780�̏C��     	//
//----------------------------------------------------------------------//
// Update Note		:	2011/02/10 �� ��   readmine#18863�̏C��     	//
//----------------------------------------------------------------------//
// Update Note		:	2011/02/11 �� ��   readmine#18876�̏C��     	//
//----------------------------------------------------------------------//
// Update Note		:	2012/03/23 wangf   readmine#29109�̏C��     	//
//----------------------------------------------------------------------//
// Update Note      :   2012/05/25 �����H  readmine#29996�̏C��         //
// �Ǘ��ԍ�         :   10801804-00 2012/06/27�z�M��                    //
//----------------------------------------------------------------------//
// Update Note      :   10901225-00 2013/5/15�z�M���ً̋}�Ή�           //
// �Ǘ��ԍ�         :   2013/03/06 zhoug�@                              //
//                  :   Redmine#34756�Ή��F�I����������                 //
//----------------------------------------------------------------------//
// Update Note      :   10801804-00    2013/06/18�z�M��                 //
// �Ǘ��ԍ�         :   2013/06/07     wangl2�@                         //
//                  :   Redmine#35788�F�u�I�����������v�̌����擾�Ŋ|�� //
//                                      �D�揇�ʂ��]������Ȃ��i��1949�j//
//                                      �G���[�������������o�^����Ȃ���//
//                                      �̑Ή��ŃG���[�����ǉ�(#8�̌�)  //   
//----------------------------------------------------------------------//
// Update Note      :   2015/03/06 caohh                                //
// �Ǘ��ԍ�         :   11070149-00          �@                         //
//                  :   Redmine#44951�F�I�����������̕s��ɂ��đΉ� //
//                      �@�����v�Z�̊|���O���[�v�̃p�����[�^�̐ݒ���C��//
//                       �i�O���[�v�R�[�h�}�X�^�̏��i������->BL�R�[�h�}�X�^�̏��i�����ނɕύX�j//
//                      �A�������擾����������C��                      //
//                       �i�I����>=���i�}�X�^�̉��i�J�n���̏�����ǉ��j //                               
//----------------------------------------------------------------------//
// Update Note      :	2020/06/18 杍^�@								//
// �@�@�@�@�@       :	PMKOBETSU-4005 �d�a�d�΍�@�@    				//
//----------------------------------------------------------------------//
// Update Note      :   2020/07/23                                      //
// �Ǘ��ԍ�         :   11675035-00   杍^�@                            //
//                  :   PMKOBETSU-3551 �I���������������s����Ə����Ɏ� //
//                                     �s���錻�ۂ̉���                 //
//----------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

//
// �A�Z���u���Ɋւ����ʏ��͈ȉ��� 
// �����Z�b�g��ʂ��Đ��䂳��܂��B�A�Z���u���Ɋ֘A�t�����Ă��� 
// ����ύX����ɂ́A�����̑����l��ύX���Ă��������B
//
[assembly: AssemblyTitle("MAZAI05118R")]
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
