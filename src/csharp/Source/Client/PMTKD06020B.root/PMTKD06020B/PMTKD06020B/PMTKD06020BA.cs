//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�����R���g���[���[
// �v���O�����T�v   : ���i���̌���/�擾���s���R���g���[���[
//----------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� :              �쐬�S�� : 30290
// �� �� �� : 2008/05/15   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11470007-00  �쐬�S�� : 30757 ���X�؁@�M�p
// �� �� �� : 2018/04/05   �C�����e : NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Runtime.Remoting;
using System.Threading;
using System.Reflection;
using System.IO;  // ADD 2010/07/07
using WinForms = System.Windows.Forms; // ADD 2010/07/07

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Resources; // 2010/03/29
// --- ADD m.suzuki 2010/04/28 ---------->>>>>
using Broadleaf.Library.Globarization; // SFCMN00002C TDateTime���g�p�B
// --- ADD m.suzuki 2010/04/28 ----------<<<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�����R���g���[���[
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�����R���g���[���[�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br> ############################## ���� ############################## </br>
    /// <br>�P�D�R���p�C���V���{��PrimeSet���O���ƗD�ǐݒ菈���������ɂȂ�܂��B</br>
    /// <br> ################################################################### </br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note: �ԑ�ԍ��ˎԑ�ԍ��A�ԑ�ԍ��i�����p�j�ɏC��</br>
    /// <br>Programmer : 21024 ���X�� ��</br>
    /// <br>Date       : 2009.01.28</br>    
    /// <br></br>
    /// <br>Update Note: �D�ǐݒ�̃p�����[�^�ύX�Ή�</br>
    /// <br>Programmer : 21024 ���X�� ��</br>
    /// <br>Date       : 2009.02.12</br>    
    /// <br></br>
    /// <br>Update Note: �D�ǐݒ�̍i�荞�݂��C��</br>
    /// <br>Programmer : 21024 ���X�� ��</br>
    /// <br>Date       : 2009.02.17</br>    
    /// <br></br>
    /// <br>Update Note: �����A�Z�b�g���񋟂ƃ��[�U�[�ŏd������ꍇ�Ƀ��[�U�[</br>
    /// <br>Programmer : 21024 ���X�� ��</br>
    /// <br>Date       : 2009.02.19</br>    
    /// <br></br>
    /// <br>Update Note: �������i���f�����ǉ�</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2009.02.24</br>    
    /// <br></br>
    /// <br>Update Note: �������i���f�����C��(��ւ��ꂽ�ꍇ���K�p)</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2009.03.04</br>    
    /// <br></br>
    /// <br>Update Note: �@�D�Ǖ��i�̑w�ʂ��Z�b�g����悤�C��(�������R��Ă���)</br>
    /// <br>             �A�D�Ǖ��i�ŃZ���N�g�R�[�h�ʂ�����ꍇ�̉��i�擾���C��</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2009.03.18</br>    
    /// <br></br>
    /// <br>Update Note: �@���i�ꊇ�o�^�������D�Ǖ��i�����ɖ��Ή��������̂ŏC��</br>
    /// <br>           : �A�D�ǐݒ胊�X�g��null�̏ꍇ�̏������C��</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2009.04.01</br>    
    /// <br></br>
    /// <br>Update Note: ���i���擾���\�b�h�ǉ�</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2009.04.14</br>    
    /// <br></br>
    /// <br>Update Note: �@���[�U�[DB�ƒ�DB�̉��i��񂪌������Ƀ}�[�W����Ă��܂��̂ŁA</br>
    /// <br>           : �@���[�U�[DB�ɉ��i��񂪂���Β�DB�̉��i�����q�b�g�����Ȃ��悤�C���B(Mantis ID=13491)</br>
    /// <br>           : �AInitializeSearch�X���b�h�ł̏���������������O�ɁA�����������Ă΂���</br>
    /// <br>           :   �I�u�W�F�N�g�Q�ƃG���[����������̂ŏC���B(Mantis ID=13491 (4.))</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2009.06.16</br>    
    /// <br></br>
    /// <br>Update Note: ���i�I���̃\�[�g����ύX����ׁA���ڂ�ǉ��B</br>
    /// <br>Programmer : 22018�@��� ���b</br>
    /// <br>Date       : 2009.07.23</br>
    /// <br></br>
    /// <br>Update Note: MANTIS[0012224] �������A�_���폜���������ΏۂƂ���B</br>
    /// <br>             MANTIS[0014250] TBO�������Ɍ����������p�����[�^�Ƃ��ăZ�b�g����(�������ς�TBO��������ƃG���[�ƂȂ�Ή�)</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2009/09/07</br>
    /// <br></br>
    /// <br>Update Note: MANTIS[0014373] ���[�U�[�o�^���̌�����BL�R�[�h�����擾�ł��Ȃ��s��̑Ή�</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2009/10/06</br>
    /// <br></br>
    /// <br>Update Note: �D�ǌ����Ή�</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2009/10/19</br>
    /// <br></br>
    /// <br>Update Note: �i���\���Ή�</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2009/10/27</br>
    /// <br></br>
    /// <br>Update Note: �\���敪�Ή��F�������������A�񋟉��i���擾���郁�\�b�h�ǉ�</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2009/11/04</br>
    /// <br></br>
    /// <br>Update Note: MANTIS[0014574] ������֕i�̉��i������񂪎擾�ł��Ă��Ȃ��s��̏C��</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2009/11/09</br>
    /// <br></br>
    /// <br>Update Note: �D�ǃZ�b�g���i�Ɋւ��āA�D�Ǖ��i��BL�R�[�h���������ʂƂȂ�悤�ɏC��(MANTIS[0013603])</br>
    /// <br>             �������i�������ʂŁA�����i���擾���[�J�[�R�[�h���Z�b�g����悤�ɏC��(MANTIS[0014671])</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2009/11/24</br>
    /// <br></br>
    /// <br>Update Note: �񋟏������i�ɂ��āA���t�ɏ]���đw�ʁABL�R�[�h�A�i�����擾����悤�ɏC��(MANTIS[0014767])</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2009/12/09</br>
    /// <br></br>
    /// <br>Update Note: �G���g�����ł̌������A���[�U�[���i�Ř_���폜�̏����������Ȃ��悤�ɏC��(MANTIS[0014767])</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2009/12/17</br>
    /// <br></br>
    /// <br>Update Note: �r�b�l���̑g����</br>
    /// <br>             �@BL�R�[�h�}�ԍ��Ή�</br>
    /// <br>             �A�񋟋敪�̃Z�b�g���@�C��(���̏C���������͕s��)</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/02/25</br>    
    /// <br></br>
    /// <br>Update Note: ��^�����̃I�v�V�����t���O���ݒ肳��Ă��Ȃ��ꍇ�A��^���q�ɊY�����錟���͊Y���f�[�^�����Ƃ���(MANTIS[0015168])</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2010/03/29</br>
    /// <br></br>
    /// <br>Update Note: �i���擾���\�b�h���C��</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2010/04/06</br>
    /// <br></br>
    /// <br>Update Note: LoadAsm�폜(delphi�t�H�[�����c#�t�H�[�����N�������Ƃ���retKeyControl,arrowKeyControl���L���ɂȂ�Ȃ���)</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2010/04/24</br>
    /// <br></br>
    /// <br>Update Note: ���R�����I�v�V�����Ή�</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2010/04/28</br>
    /// <br></br>
    /// <br>Update Note: �I�t���C���Ή�</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2010/05/25</br>
    /// <br></br>
    /// <br>Update Note: ���ʕ�����</br>
    /// <br>               ���R���� 2010/04/28 �g�ݍ���</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2010/06/04</br>
    /// <br></br>
    /// <br>Update Note: ���ʕ�����</br>
    /// <br>               �Q�փI�v�V�����Ή�</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2010/06/12</br>
    /// <br></br>
    /// <br>Update Note: ���ʕ�����</br>
    /// <br>               �I�t���C���Ή� 2010/05/25 �g�ݍ���</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2010/06/16</br>
    /// <br></br>
    /// <br>Update Note: ���ʕ�����</br>
    /// <br>               ����`�[���͋N���������Ή� 2010/04/24 �g�ݍ���</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2010/06/21</br>
    /// <br></br>
    /// <br>Update Note: MANTIS�Ή� 15716</br>
    /// <br>           :   �I�t���C�������Ɋւ��āASCM���l����������Ƃ���悤�ɏC��</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2010/07/07</br>
    /// <br></br>
    /// <br>Update Note: ���ʕ������Q</br>
    /// <br>               �Z�b�g�q�i�Ԃɑ΂��Ē񋟃f�[�^�̃Z�b�g�i����ݒ肷��悤�C��</br>
    /// <br>               (�������_�ł͂c�a��͑S�p�������Ȃ��̂ŁA�o�f�ɂ�蔼�p�ϊ����ăZ�b�g����)</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2010/07/14</br>
    /// <br></br>
    /// <br>Update Note: SCM����</br>
    /// <br>               BL�R�[�h�}�ԑΉ��i�}�Ԃɂ��i�荞�݂Ǝ}�Ԗ��̂̓K�p(�c�E,�c���Ȃ�)�j</br>
    /// <br>Programmer : 22018 ��� ���b</br>
    /// <br>Date       : 2011/05/18</br>
    /// <br></br>
    /// <br>Update Note: 2011/08/24  �A��980 ���X��</br>
    /// <br>            : REDMINE#23417�̑Ή�</br>
    /// <br>Update Note: 2011/08/31  �A��980 ���X��</br>
    /// <br>            : REDMINE#23417�̑Ή�</br>
    /// <br>Update Note: SCM����</br>
    /// <br>             �������ϕ��i�R�[�h�擾�����̒ǉ�</br>
    /// <br>Programmer : 20073 �� �B</br>
    /// <br>Date       : 2012/05/30</br>
    /// <br>Update Note: ��Q��1004</br>
    /// <br>             �i�ԑ啶���������ϊ������̒ǉ�</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2012/06/18</br>
    /// <br>Update Note: SPK�O��TBO�����Ή�</br>
    /// <br>             TBO������A�Y�����Ȃ������ꍇ�́A�ʏ�̏���BL�R�[�h��������������悤�ɏC��</br>
    /// <br>Programmer : 22008 ���� ���n</br>
    /// <br>Date       : 2012/11/15</br>
    /// <br>Update Note: BL�R�[�h�����Ή�</br>
    /// <br>             �񋟃f�[�^�œo�^����Ă��錋�����i�ɑ΂��āA���[�U�[�o�^�����Z�b�g���i���R�t���悤�ɏC��</br>
    /// <br>Programmer : �e�c ���V</br>
    /// <br>Date       : 2012/12/10</br>
    /// <br>Update Note: BL�R�[�h�����Ή�</br>
    /// <br>             �񋟃f�[�^�œo�^����Ă��錋�����i�ɑ΂��āA���[�U�[�o�^�����Z�b�g���i���R�t���悤�ɏC��</br>
    /// <br>             �i�i�Ԍ����Ή��R��j</br>
    /// <br>Programmer : �e�c ���V</br>
    /// <br>Date       : 2012/12/20</br>
    /// <br>Update Note: SCM��Q��169�Ή�</br>
    /// <br>             2013/03/06�z�M �� ���L���� �ǉ��B����ɔ��������ǉ�</br>
    /// <br>Programmer : 30745 �g���F��</br>
    /// <br>Date       : 2013/02/12</br>
    /// <br>Update Note: BL�R�[�h�����Ή�</br>
    /// <br>             �N���E�ԑ�ԍ����͎��ɍi���݂̌��������ɒǉ�����C��</br>
    /// <br>             SCM��Q��10354�Ή� 2013/03/06�z�M</br>
    /// <br>Programmer : 30744 ���� ����q</br>
    /// <br>Date       : 2013/02/14</br>
    /// <br>Update Note: 2013/03/13�z�M�V�X�e���e�X�g��Q��121�Ή�</br>
    /// <br>Programmer : 30744 ���� ����q</br>
    /// <br>Date       : 2013/02/22</br>
    /// <br>Update Note: �_�~�[�i�ԑΉ�</br>
    /// <br>             SCM��Q��10355�Ή� 2013/04/10�z�M</br>
    /// <br>Programmer : 30744 ���� ����q</br>
    /// <br>Date       : 2013/02/17</br>
    /// <br></br>
    /// <br>UpdateNote : 2013/03/15�@dpp</br>
    /// <br>          �@ 10901273-00 5��15���z�M���i��Q�ȊO�j Redmine#34377 �i�Ԍ������ʕs��̏C��</br>
    /// <br></br>
    /// <br>Update Note: 10900269-00 SPK�ԑ�ԍ�������Ή�</br>
    /// <br>Programmer : FSI�֓� �a�G</br>
    /// <br>Date       : 2013/03/27</br>
    /// <br></br>
    /// <br>Update Note: SCM�d�|�ꗗ��10632�Ή�</br>
    /// <br>Programmer : 30744 ���� ����q</br>
    /// <br>Date       : 2014/02/06</br>
    /// <br></br>
    /// <br>Update Note: SCM�����񓚑��x���P ����ýď�Q��77�Ή�</br>
    /// <br>Programmer : 30744 ���� ����q</br>
    /// <br>Date       : 2014/04/17</br>
    /// <br></br>
    /// <br>Update Note: ���x���P�t�F�[�Y�Q��11,��12 �i���^�C�~���O�ύX</br>
    /// <br>Programmer : 30745 �g��</br>
    /// <br>Date       : 2014/05/09</br>
    /// <br></br>
    /// <br>Update Note: �Ǘ��ԍ�  11070076-00  PM-SCM���x���� �t�F�[�Y�Q�Ή�</br>
    /// <br>                                    13.�t���^���Œ�ԍ�����̂a�k�R�[�h�����񐔉��ǑΉ�</br>
    /// <br>                                    14.���׎捞�敪�̍X�V���@�����ǑΉ�</br>
    /// <br>                                    15.SCM�󔭒��f�[�^�i�ԗ����j�擾���@���ǑΉ�</br>
    /// <br>                                    16.�����i�������ǑΉ�</br>
    /// <br>                                    17.�D�Ǖi�������ǑΉ�</br>
    /// <br>Programmer : 30744 ���� ����q</br>
    /// <br>Date       : 2014/05/13</br>
    /// <br></br>
    /// <br>Update Note: �Ǘ��ԍ�  11070076-00  PM-SCM���x���� �t�F�[�Y�Q�Ή�</br>
    /// <br>                                    ��Q�Ή�</br>
    /// <br>Programmer : 30744 ���� ����q</br>
    /// <br>Date       : 2014/06/12</br>
    /// <br></br>
    /// <br>Update Note: SCM�d�|�ꗗ��10659�Ή�</br>
    /// <br>Programmer : 30744 ���� ����q</br>
    /// <br>Date       : 2014/06/04</br>
    /// <br>Update Note: 11070147-00 �V�X�e���e�X�g��Q��5�Ή�</br>
    /// <br>Programmer : 30744 ���� ����q</br>
    /// <br>Date       : 2014/08/13</br>
    /// <br>Update Note: 11070147-00 �V�X�e���e�X�g��Q��20�Ή�</br>
    /// <br>Programmer : 30744 ���� ����q</br>
    /// <br>Date       : 2014/08/13</br>    
    /// <br></br>
    /// <br>Update Note: �Ǘ��ԍ�  11070076-00  PM-SCM���x���� �t�F�[�Y�Q�Ή�</br>
    /// <br>             �D�Ǖ��i���擾�����[�g�̕ύX(�p�u���b�N�ϐ����v���C�x�[�g�ϐ�)�ɔ����C��</br>
    /// <br>Programmer : �{�{ ����</br>
    /// <br>Date       : 2014/08/14</br>
    /// <br>Update Note: ��10679 ��10681</br>
    /// <br>Programmer : 30745 �g��</br>
    /// <br>Date       : 2014/09/09</br>
    /// <br>Update Note: SCM�Г���Q�ꗗ��53�Ή�</br>
    /// <br>           : PM-SCM���x���� �t�F�[�Y�Q ����ýď�Q�Ή�</br>
    /// <br>           : �����񓚂̖⍇���ŗD�Ǖi���񓚂����BL�R�[�h�Ŗ⍇������Ə����i�����񓚂���Ȃ���Q�Ή�</br>
    /// <br>Programmer : 30744 ����</br>
    /// <br>Date       : 2014/10/16</br>
    /// <br></br>
    /// <br>Update Note: SCM������ C������ʑΉ�</br>
    /// <br>Programmer : 31065 �L��</br>
    /// <br>Date       : 2015/02/20</br>
    /// <br></br>
    /// <br>Update Note: SCM������Redmine#317�Ή�</br>
    /// <br>Programmer : 30744 ����</br>
    /// <br>Date       : 2015/03/04</br>
    /// <br></br>
    /// <br>Update Note: SCM�d�|�ꗗ��10715�Ή�</br>
    /// <br>           : �⍇��(BL����)�̉񓚎��ɈقȂ�BL�R�[�h�}�Ԃ̕��i���V�i�Ԃɐݒ肳��Ă���ꍇ�ɃG���[�ɂȂ��Q�̑Ή�</br>
    /// <br>Programmer : �{�{ ����</br>
    /// <br>Date       : 2015/04/03</br>
    /// <br></br>
    /// <br>Update Note: SCM�d�|�ꗗ��10716�Ή�</br>
    /// <br>Programmer : 30744 ����</br>
    /// <br>Date       : 2015/04/03</br>
    /// <br></br>
    /// <br>Update Note: SCM���������[�J�[��]�������i�Ή�</br>
    /// <br>Programmer : 30744 ����</br>
    /// <br>Date       : 2015/03/18</br>
    /// <br></br>
    /// <br>Update Note: �S�̔z�M�V�X�e���e�X�g��Q��60�Ή�</br>
    /// <br>Programmer : 30744 ����</br>
    /// <br>Date       : 2015/03/30</br>
    /// <br></br>
    /// <br>Update Note: �\�[�X�`�F�b�N�w�E�Ή�</br>
    /// <br>           : �@���R�������i�Œ񋟗D�Ǐ��擾���̉��i���ǉ������Ή�</br>
    /// <br>           : �A�񋟉��i��񏉊����s�v�̂��ߏC��</br>
    /// <br>Programmer : 30744 ����</br>
    /// <br>Date       : 2015/03/31</br>
    /// <br></br>
    /// <br>Update Note: NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
    /// <br>           : ���������ւ�BL���ꕔ�i�R�[�h�̒ǉ�</br>
    /// <br>Programmer : 30757 ���X�؁@�M�p</br>
    /// <br>Date       : 2018/04/05</br>
    /// <br>�Ǘ��ԍ�   : 11470007-00</br>
    /// <br></br>
    /// </remarks>
    public class PartsSearchController
    {
        # region Private Members
        /// <summary>�g���^���[�J�[�R�[�h</summary>
        private const int ct_ToyotaCd = 1;
        /// <summary>�^�N�e�B�[���[�J�[�R�[�h</summary>
        private const int ct_TactiCd = 1396;
        /// <summary>���i���[�J�[���X�g</summary>
        private Dictionary<int, MakerUMnt> _PartsMakerList;
        /// <summary>BL�R�[�h���X�g</summary>
        private Dictionary<int, BLGoodsCdUMnt> blList;
        // 2010/02/25 Add >>>
        /// <summary>��BL�R�[�h���X�g</summary>
        private List<TbsPartsCodeWork> _ofrBLList;
        // 2010/02/25 Add <<<
        /// <summary>�������i�L�[���X�g</summary>
        private List<string> lstClgParts; // �D�Ǖ��i�������d�����Ȃ����X�g�쐬�̂��߁A

        // �ԗ��^�����f�[�^�Z�b�g
        private PMKEN01010E carInfoDataSet;
        private PMKEN01010E.CarModelInfoDataTable customerCarInfo;

        private BLInfoDataTable ofrBLInfo;
        private BLInfoDataTable bLInfo;

        /// <summary>�D�ǐݒ���i�[�o�b�t�@(VALUE:�D�ǐݒ���I�u�W�F�N�g)</summary>
        // 2009.02.12 >>>
        //private Dictionary<PrmSettingKey, PrmSettingUWork> _drPrmSettingWork;
        private List<PrmSettingUWork> _drPrmSettingWork;
        // 2009.02.12 <<<

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode;

        private SearchPrtCtlAcs searchPrtCtlAcs;

        /// <summary>2�֕��i���[�J�[���X�g�i2�֌_��ɂ��i�Ԍ�������p�j</summary>
        private List<int> bikePMakerList = new List<int>(new int[] { 21, 22, 23, 24 });

        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        /// <summary>0:���R�����Ȃ� 1:���R��������</summary>
        private int _freeSearchDiv;

        /// <summary>�ʏ��BL�R�[�h�����̏�������STATUS�i���R�������o���ʂƋ�ʂ���j</summary>
        private int _normalSearchStatus;

        /// <summary>���R�������i ���o���ʃo�b�t�@</summary>
        private Dictionary<string, List<FreeSearchPartsSRetWork>> _freeSearchPartsSRetDic;
        /// <summary>���R�������i ���o���ʁi�擪�j</summary>
        private FreeSearchPartsSRetWork _freeSearchPartsSRetWork;

        /// <summary>���R���� �񋟏��� ���o���ʃf�B�N�V���i��</summary>
        private Dictionary<string, RetPartsInf> _retPartsInfDic;
        /// <summary>���R���� �񋟗D�� ���o���ʃf�B�N�V���i��</summary>
        private Dictionary<string, OfferJoinPartsRetWork> _primPartsRetDic;
        /// <summary>���R���� �񋟗D�ǉ��i ���o���ʃf�B�N�V���i��</summary>
        private Dictionary<string, List<OfferJoinPriceRetWork>> _primPriceRetDic;
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<

        /// <summary>BL�R�[�h���X�g</summary>
        public Dictionary<int, BLGoodsCdUMnt> BLGoodsCdUMntList
        {
            get { return blList; }
            set { blList = value; }
        }

        // 2010/02/25 Add >>>
        /// <summary>��BL�R�[�h���X�g</summary>
        public List<TbsPartsCodeWork> OfrBLList
        {
            get { return _ofrBLList; }
            set { _ofrBLList = value; }
        }
        // 2010/02/25 Add <<<

        /// <summary>���i���[�J�[���X�g</summary>
        public Dictionary<int, MakerUMnt> PartsMakerList
        {
            get { return _PartsMakerList; }
            set { _PartsMakerList = value; }
        }

        /// <summary>
        /// �ԗ����ݒ�
        /// </summary>
        public PMKEN01010E CarInfo
        {
            set
            {
                carInfoDataSet = value;
                // --- UPD m.suzuki 2010/04/28 ---------->>>>>
                //GetCarBlInf();
                GetCarBlInf( 0 );
                // --- UPD m.suzuki 2010/04/28 ----------<<<<<
            }
        }
        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        /// <summary>
        /// ���q���ݒ菈���i���q�a�k�R�[�h�����̂a�k�R�[�h������j
        /// </summary>
        /// <param name="value"></param>
        /// <param name="blCode"></param>
        public void SetCarInfo( PMKEN01010E value, int blCode )
        {
            carInfoDataSet = value;
            GetCarBlInf( blCode );
        }
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ���q���ݒ菈���i���q�a�k�R�[�h�����̂a�k�R�[�h������j
        /// </summary>
        /// <param name="value"></param>
        /// <param name="blCodeList"></param>
        public void SetCarInfo(PMKEN01010E value, List<int> blCodeList)
        {
            carInfoDataSet = value;
            GetCarBlInf(blCodeList);
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        // ADD 2014/05/09 ���x���P�t�F�[�Y�Q��11,��12 �g��  -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary> �����񓚕i�ڐݒ胊�X�g�i�����񓚐�p�j </summary>
        private List<AutoAnsItemSt> _foundAutoAnsItemStList = new List<AutoAnsItemSt>();
        /// <summary> �����񓚕i�ڐݒ胊�X�g�i�����񓚐�p�j </summary>
        public List<AutoAnsItemSt> FoundAutoAnsItemStList
        {
            get { return _foundAutoAnsItemStList; }
            set { _foundAutoAnsItemStList = value; }
        }

        /// <summary> ���_�R�[�h�i�����񓚐�p�j </summary>
        private string _sectionCodeAutoAnswer = string.Empty;
        /// <summary> ���_�R�[�h(�����񓚐�p) </summary>
        public string SectionCode
        {
            get { return _sectionCodeAutoAnswer; }
            set { _sectionCodeAutoAnswer = value; }
        }

        /// <summary> ���Ӑ�R�[�h�i�����񓚐�p�j </summary>
        private int _customerCode = 0;
        /// <summary> ���Ӑ�R�[�h�i�����񓚐�p�j </summary>
        public int CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }
        // ADD 2014/05/09 ���x���P�t�F�[�Y�Q��11,��12 �g��  --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// �ԗ�BL���擾
        /// </summary>
        public BLInfoDataTable BLInfo
        {
            get { return bLInfo; }
        }

        # region �����[�g�R���g���[���[
        //private IPrimeSettingDB iPrimeSettingSearchDB;
        private static IPrimePartsInfo iPrimePartsInfoDB;
        private static ITBOSearchInfDB iTBOSearchInfDB;
        private static ITBOSearchUDB iTBOSearchUDB;
        private static IUsrJoinPartsSearchDB iUsrJoinPartsSearchDB;
        //private IClgPrmPartsInfoSearchDB iClgPrmPartsInfoSearchDB = null;
        private static IOfferPartsInfo iOfferPartsInfo;
        // --- ADD T.Nishi 2012/05/30 ---------->>>>>
        private static IAutoEstmPtNoChgDB iAutoEstmPtNoChgDB;
        // --- ADD T.Nishi 2012/05/30 ----------<<<<<

        /// <summary>�D�ǂa�k�������擾�����[�g���񋟁�</summary>
        private static IOfferPrimeBlSearchDB iOfferPrimeBlSearchDB;

        private static ITbsPartsCodeDB iBlGoodsCdDB;

        ///// <summary>���i�݌Ɍ���DB�����[�g</summary>
        //private IGoodsStockSearchDB iGoodsStockSearchDB;
        # endregion

        //>>>2010/03/29
        // ��^�����I�v�V�����p��^���[�J�[���X�g
        private List<int> bigMakerList = new List<int>(new int[] { 10, 12, 13, 16 });
        //<<<2010/03/29

        // --- ADD 2015/04/03 T.Miyamoto SCM�d�|�ꗗ��10715 ------------------------------>>>>>
        private struct NewKey
        {
            private int MakerCd;
            private string PrtsNo;

            public NewKey(int CatalogPartsMakerCd, string NewPrtsNoWithHyphen)
            {
                MakerCd = CatalogPartsMakerCd;
                PrtsNo = NewPrtsNoWithHyphen;
            }
        }
        // --- ADD 2015/04/03 T.Miyamoto SCM�d�|�ꗗ��10715 ------------------------------<<<<<
        # endregion

        #region [ Delegate ]
        // 2009.02.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �������i���f�f���Q�[�g
        /// </summary>
        /// <param name="taxationCode"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="offerKubun"></param>
        /// <param name="price"></param>
        public delegate void ReflectIsolIslandCallback(int taxationCode, int goodsMakerCd, int offerKubun, ref double price);
        // 2009.02.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

        #region [ Events ]
        // 2009.02.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���i�v�Z�p�C�x���g
        /// </summary>
        public ReflectIsolIslandCallback ReflectIsolIsland;
        // 2009.02.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

        # region �f�[�^�e�[�u��
        private PartsInfoDataSet partsInfo;
        /// <summary> �S�Ă̕��i�E���i���e�[�u��[PartsInfoDataSet��UsrGoodsInfoDataTable] </summary>
        private PartsInfoDataSet.UsrGoodsInfoDataTable goodsTable;

        /// <summary> �S�Ă̕��i�E���i�̉��i�e�[�u��[PartsInfoDataSet��UsrGoodsPriceDataTable] </summary>
        private PartsInfoDataSet.UsrGoodsPriceDataTable priceTable;

        private PartsInfoDataSet.StockDataTable stockTable;

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        private Dictionary<int, PartsInfoDataSet> partsInfoDic;
        /// <summary> �S�Ă̕��i�E���i���e�[�u��[PartsInfoDataSet��UsrGoodsInfoDataTable] </summary>
        private Dictionary<int, PartsInfoDataSet.UsrGoodsInfoDataTable> goodsTableDic;

        /// <summary> �S�Ă̕��i�E���i�̉��i�e�[�u��[PartsInfoDataSet��UsrGoodsPriceDataTable] </summary>
        private Dictionary<int, PartsInfoDataSet.UsrGoodsPriceDataTable> priceTableDic;

        private Dictionary<int, PartsInfoDataSet.StockDataTable> stockTableDic;
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
        /// <summary> �S�Ă̕��i�E���i�̒񋟃f�[�^���i�e�[�u��[PartsInfoDataSet��UsrGoodsPriceDataTable] </summary>
        private PartsInfoDataSet.UsrGoodsPriceDataTable ofrPriceTable;
        /// <summary> �S�Ă̕��i�E���i�̒񋟃f�[�^���i�e�[�u��[PartsInfoDataSet��UsrGoodsPriceDataTable] </summary>
        private Dictionary<int, PartsInfoDataSet.UsrGoodsPriceDataTable> ofrPriceTableDic;
        // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<

        # endregion

        # region �R���X�g���N�^�[
        /// <summary>
        ///	���i�����R���g���[���[ �R���X�g���N�^�[
        /// </summary>
        public PartsSearchController()
        {
            try
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/16 DEL
                ////RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
                //Thread threadInit = new Thread( InitializeSearch );
                //Thread threadLoad = new Thread( LoadAsm );
                //threadInit.Start();
                //threadLoad.Start();
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/16 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/16 ADD InitializeSearch����ꕔ�ړ�

                //>>>2010/04/24
                //// �A�Z���u�����[�h�X���b�h�J�n
                //Thread threadLoad = new Thread( LoadAsm );
                //threadLoad.Start();
                //<<<2010/04/24

                
                // ������
                iOfferPartsInfo = null;
                iPrimePartsInfoDB = null;
                iTBOSearchInfDB = null;
                iUsrJoinPartsSearchDB = null;
                iOfferPrimeBlSearchDB = null;
                iBlGoodsCdDB = null;

                _PartsMakerList = null;

                partsInfo = new PartsInfoDataSet();
                goodsTable = partsInfo.UsrGoodsInfo;
                priceTable = partsInfo.UsrGoodsPrice;
                stockTable = partsInfo.Stock;
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                // DEL 2015/03/31 SCM������ ���[�J�[��]�������i�Ή��A�񋟉��i��񏉊����s�v�̂��ߏC��-------------->>>>>
                //ofrPriceTable = new PartsInfoDataSet.UsrGoodsPriceDataTable();
                // DEL 2015/03/31 SCM������ ���[�J�[��]�������i�Ή��A�񋟉��i��񏉊����s�v�̂��ߏC��--------------<<<<<
                ofrPriceTable = partsInfo.OfrPriceDataTable;
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<

                ofrBLInfo = new BLInfoDataTable();
                bLInfo = new BLInfoDataTable();

                searchPrtCtlAcs = new SearchPrtCtlAcs();


                // 2010/02/25 >>>
                // ���������X���b�h�J�n
                //Thread threadInit = new Thread( InitializeSearch );
                //threadInit.Start();

                InitializeSearch();
                // 2010/02/25 <<<

                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/16 ADD

                // --- ADD m.suzuki 2010/04/28 ---------->>>>>
                // ���R�����I�v�V�����`�F�b�N
                PurchaseStatus psFreeSearch = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany( ConstantManagement_SF_PRO.SoftwareCode_OPT_PM_FreeSearch );
                if ( psFreeSearch == PurchaseStatus.Contract || psFreeSearch == PurchaseStatus.Trial_Contract )
                {
                    // ���R��������
                    _freeSearchDiv = 1;
                }
                else
                {
                    // ���R�����Ȃ�
                    _freeSearchDiv = 0;
                }
                // --- ADD m.suzuki 2010/04/28 ----------<<<<<

            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
            }
        }

        private void InitializeSearch()
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/16 DEL �ꕔ���R���X�g���N�^�ֈړ�
            ////�����[�g�����̐ݒ�
            //iOfferPartsInfo = null;
            //iPrimePartsInfoDB = null;
            //iTBOSearchInfDB = null;
            //iUsrJoinPartsSearchDB = null;
            //iOfferPrimeBlSearchDB = null;
            //iBlGoodsCdDB = null;

            //_PartsMakerList = null;

            //partsInfo = new PartsInfoDataSet();
            //goodsTable = partsInfo.UsrGoodsInfo;
            //priceTable = partsInfo.UsrGoodsPrice;
            //stockTable = partsInfo.Stock;

            //ofrBLInfo = new BLInfoDataTable();
            //bLInfo = new BLInfoDataTable();

            //ISearchPrtCtlDB iSearchPrtCtlDb = MediationSearchPrtCtlDB.GetSearchPrtCtlDB();
            //object lstClgParts;
            //int status = iSearchPrtCtlDb.Search( out lstClgParts, null );
            //ArrayList lst = lstClgParts as ArrayList;
            //searchPrtCtlAcs = new SearchPrtCtlAcs();
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/16 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/16 ADD
            ISearchPrtCtlDB iSearchPrtCtlDb = MediationSearchPrtCtlDB.GetSearchPrtCtlDB();
            object lstClgParts;
            int status = iSearchPrtCtlDb.Search( out lstClgParts, null );
            ArrayList lst = lstClgParts as ArrayList;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/16 ADD

            if (lst != null)
            {
                searchPrtCtlAcs.AddList(lst);
            }

            // �SBL�R�[�h�擾
            GetOfrBlInf();
        }

        private void LoadAsm()
        {
            string path = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            path = path.Remove(path.LastIndexOf('\\') + 1);
            Assembly asm1 = Assembly.LoadFile(path + "PMKEN01010E.dll");
            Assembly asm2 = Assembly.LoadFile(path + "PMKEN01020E.dll");
            Assembly asm3 = Assembly.LoadFile(path + "PMKEN08010U.dll");
            Assembly asm4 = Assembly.LoadFile(path + "PMKEN08020U.dll");
            Assembly asm5 = Assembly.LoadFile(path + "PMKEN08060U.dll");
            Assembly asm6 = Assembly.LoadFile(path + "PMKEN08070U.dll");
            Assembly asm7 = Assembly.LoadFile(path + "PMKEN08140U.dll");
            Assembly asm8 = Assembly.LoadFile(path + "PMKEN08080U.dll");
            Assembly asm9 = Assembly.LoadFile(path + "PMKEN08090U.dll");
            Assembly asm10 = Assembly.LoadFile(path + "PMKEN08100U.dll");
            try
            {
                object obj = asm5.CreateInstance("Broadleaf.Library.Windows.Forms.SelectionParts", false, BindingFlags.Default, null,
                    new object[0], null, null);
                obj = asm6.CreateInstance("Broadleaf.Library.Windows.Forms.SelectionSamePartsNoParts", false, BindingFlags.Default, null,
                    new object[0], null, null);
                obj = asm6.CreateInstance("Broadleaf.Library.Windows.Forms.SelectionSamePartsNoParts", false, BindingFlags.Default, null,
                    new object[0], null, null);
            }
            catch
            {
            }
        }
        # endregion

        /// <summary>
        /// �i���擾(�S�p)
        /// </summary>
        /// <param name="makerCd">���[�J�R�[�h</param>
        /// <param name="partsNo">�n�C�t���t�i��</param>
        /// <param name="name">�i��</param>
        /// <returns></returns>
        public static int GetPartsName(int makerCd, string partsNo, out string name)
        {
            return GetPartsNameProc(makerCd, partsNo, out name, 0);
        }

        /// <summary>
        /// �i���擾(���p)
        /// </summary>
        /// <param name="makerCd">���[�J�R�[�h</param>
        /// <param name="partsNo">�n�C�t���t�i��</param>
        /// <param name="name">�i��</param>
        /// <returns></returns>
        public static int GetPartsNameKana(int makerCd, string partsNo, out string name)
        {
            return GetPartsNameProc(makerCd, partsNo, out name , 1);
        }

        /// <summary>
        /// �i���擾
        /// </summary>
        /// <param name="makerCd">���[�J�R�[�h</param>
        /// <param name="partsNo">�n�C�t���t�i��</param>
        /// <param name="name">�i��</param>
        /// <param name="mode">0:�S�p,1:���p</param>
        /// <returns></returns>
        private static int GetPartsNameProc(int makerCd, string partsNo, out string name, int mode)
        {
            int status = 0;
            string offerName = string.Empty;
            string userName = string.Empty;
            name = string.Empty;

            // -- ADD 2010/05/25 ---------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return 0;
            }
            // -- ADD 2010/05/25 ----------------------<<<
            try
            {
                if (iOfferPartsInfo == null)
                    iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();
                if (mode == 0)
                {
                    //�S�p����
                    status = iOfferPartsInfo.GetPartsName(makerCd, partsNo, out offerName);
                }
                else
                {
                    //���p����
                    status = iOfferPartsInfo.GetPartsNameKana(makerCd, partsNo, out offerName);
                }

                if (status != 0)
                {
                    if (iPrimePartsInfoDB == null)
                        iPrimePartsInfoDB = MediationPrimePartsInfo.GetRemoteObject();
                    if (mode == 0)
                    {
                        //�S�p����
                        status = iPrimePartsInfoDB.GetPartsName(makerCd, partsNo, out offerName);
                    }
                    else
                    {
                        //���p����
                        status = iPrimePartsInfoDB.GetPartsNameKana(makerCd, partsNo, out offerName);
                    }
                }

                // -- DEL 2010/04/06 --------------------------->>>
                //if (iUsrJoinPartsSearchDB == null)
                //    iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();

                //if (mode == 0)
                //{
                //    //�S�p����
                //    status = iUsrJoinPartsSearchDB.GetPartsName(makerCd, partsNo, out userName);
                //}
                //else
                //{
                //    //���p����
                //    status = iUsrJoinPartsSearchDB.GetPartsNameKana(makerCd, partsNo, out userName);
                //}
                //if (userName != string.Empty)
                //{
                //    name = userName;
                //}
                //else
                //{
                //    if (offerName != string.Empty)
                //    {
                //        name = offerName;
                //        status = 0; // �񋟂̂݃f�[�^������ꍇ���[�U�[DB������status��0�ȊO�ɂȂ邽�߁A0�ɐݒ肷��B
                //    }
                //    else
                //    {
                //        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //    }
                //}
                // -- DEL 2010/04/06 ---------------------------<<<
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        # region �������C���i�a�k�R�[�h�����E�i�Ԍ����E�����������j
        /// <summary>
        /// �������C���i�a�k�R�[�h�����E�i�Ԍ����j
        /// </summary>
        /// <param name="dsCarModelInfo">�ԗ��^���f�[�^�Z�b�g�i�^������̂Ƃ���null��ݒ肷�邱�Ɓj</param>
        /// <param name="PartsSearchUIData">���i�������o����</param>
        /// <param name="retPartsInfo">���i��������</param>
        /// <returns></returns>
        public int GetPartsInfoMain(PMKEN01010E dsCarModelInfo, PartsSearchUIData PartsSearchUIData, out PartsInfoDataSet retPartsInfo)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            partsInfo.Clear();
            partsInfo.SearchCondition = PartsSearchUIData;
            _sectionCode = PartsSearchUIData.SectionCode;
            _drPrmSettingWork = PartsSearchUIData.PrmSettingWork;

            if (dsCarModelInfo != null)
            {
                carInfoDataSet = dsCarModelInfo;
                customerCarInfo = dsCarModelInfo.CarModelInfoSummarized;

                // �ԗ�BL�R�[�h�擾
                //GetCarBlInf();
            }
            else
            {
                carInfoDataSet = null;
                customerCarInfo = null;
            }

            // --- ADD m.suzuki 2010/04/28 ---------->>>>>
            if ( _freeSearchDiv != 0 )
            {
                // ������
                _freeSearchPartsSRetDic = null;
                _freeSearchPartsSRetWork = null;
            }
            // --- ADD m.suzuki 2010/04/28 ----------<<<<<

            //�a�k�R�[�h����
            if (PartsSearchUIData.TbsPartsCode != 0)
            {
                partsInfo.SearchMethod = 0; // �������@�FBL����[�i���\�������f�̂��ߎg�p]
                //�����a�k�R�[�h����
                switch (Blkind(PartsSearchUIData.TbsPartsCode, (int)PartsSearchUIData.SearchFlg))
                {
                    // �����a�k�R�[�h����
                    case 0:
                        // --- UPD m.suzuki 2010/04/28 ---------->>>>>
                        //status = BlSearchMain( PartsSearchUIData );
                        if ( _freeSearchDiv != 0 )
                        {
                            // ���R�������i����
                            FreeSearchPartsSearchMain( dsCarModelInfo, PartsSearchUIData );
                        }
                        status = BlSearchMain( PartsSearchUIData, false );
                        // --- UPD m.suzuki 2010/04/28 ----------<<<<<
                        break;

                    // �D�ǂa�k�R�[�h����
                    case 1:
                        // --- UPD m.suzuki 2010/04/28 ---------->>>>>
                        //status = PrimeBlSearchMain( PartsSearchUIData );
                        //if ( status == 4 || partsInfo.UsrGoodsInfo.Count == 0 ) // �������킾���A�q�b�g�Ȃ���
                        //    status = BlSearchMain( PartsSearchUIData );

                        if ( _freeSearchDiv != 0 )
                        {
                            // ���R�������i����
                            FreeSearchPartsSearchMain( dsCarModelInfo, PartsSearchUIData );

                            // �D�ǂa�k�R�[�h����
                            status = PrimeBlSearchMain( PartsSearchUIData );
                            if ( status == 4 || partsInfo.UsrGoodsInfo.Count == 0 )
                            {
                                // �������킾���A�q�b�g�Ȃ����ˏ����a�k�R�[�h����
                                status = BlSearchMain( PartsSearchUIData, false );
                            }
                            else
                            {
                                // ���R�������i�W�J�i���\�b�h�����Œʏ�̏����a�k�R�[�h�����͎��s���Ȃ��j
                                status = BlSearchMain( PartsSearchUIData, true );
                            }
                        }
                        else
                        {
                            // �D�ǂa�k�R�[�h����
                            status = PrimeBlSearchMain( PartsSearchUIData );
                            if ( status == 4 || partsInfo.UsrGoodsInfo.Count == 0 )
                            {
                                // �������킾���A�q�b�g�Ȃ���
                                status = BlSearchMain( PartsSearchUIData, false );
                            }
                        }
                        // --- UPD m.suzuki 2010/04/28 ----------<<<<<
                        break;
                    // TBO����
                    case 2:
                        status = TBOSearchMain(PartsSearchUIData);

                        // -- ADD 2012/11/15 ---------------------------->>>
                        //TBO������A�q�b�g�����Ȃ�A����BL�R�[�h����
                        if (status == 4 || partsInfo.UsrGoodsInfo.Count == 0)  // �������i�������s���͌�������Ńq�b�g�Ȃ���
                        {
                            status = BlSearchMain(PartsSearchUIData, false);
                        }
                        // -- ADD 2012/11/15 ----------------------------<<<
                        break;

                    // ����������q�b�g�Ȃ��Ȃ�D�ǌ���
                    case 3:
                        // --- UPD m.suzuki 2010/04/28 ---------->>>>>
                        //status = BlSearchMain(PartsSearchUIData);
                        //if (status == 4 || partsInfo.UsrGoodsInfo.Count == 0)  // �������i�������s���͌�������Ńq�b�g�Ȃ���
                        //    status = PrimeBlSearchMain(PartsSearchUIData);

                        if ( _freeSearchDiv != 0 )
                        {
                            // ���R�������i����
                            FreeSearchPartsSearchMain( dsCarModelInfo, PartsSearchUIData );

                            status = BlSearchMain( PartsSearchUIData, false );
                            if ( _normalSearchStatus == 4 || partsInfo.UsrGoodsInfo.Count == 0 )  // �������i�������s���͌�������Ńq�b�g�Ȃ���
                                status = PrimeBlSearchMain( PartsSearchUIData );
                        }
                        else
                        {
                            status = BlSearchMain( PartsSearchUIData, false );
                            if ( status == 4 || partsInfo.UsrGoodsInfo.Count == 0 )  // �������i�������s���͌�������Ńq�b�g�Ȃ���
                                status = PrimeBlSearchMain( PartsSearchUIData );
                        }

                        // --- UPD m.suzuki 2010/04/28 ----------<<<<<
                        break;

                    default:
                        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
                        // BLKind���Y���Ȃ��̏ꍇ�́A���R�������o�̂ݍs���B
                        if ( _freeSearchDiv != 0 )
                        {
                            // ���R�������i����
                            FreeSearchPartsSearchMain( dsCarModelInfo, PartsSearchUIData );

                            // ���R�������i�W�J
                            status = BlSearchMain( PartsSearchUIData, true );
                        }
                        // --- ADD m.suzuki 2010/04/28 ----------<<<<<
                        break;
                }
            }
            //�i�Ԍ���
            else
            {
                partsInfo.SearchMethod = 1; // �������@�F�i�Ԍ���[�i���\�������f�̂��ߎg�p]
                status = PartsNoSearchMain(PartsSearchUIData);
            }
            SetUsrGoodsKind();
            partsInfo.AcceptChanges();
            retPartsInfo = partsInfo;
            retPartsInfo.SearchCondition = PartsSearchUIData;
            return status;
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// �������C���i�a�k�R�[�h�����E�i�Ԍ����j
        /// </summary>
        /// <param name="dsCarModelInfo">�ԗ��^���f�[�^�Z�b�g�i�^������̂Ƃ���null��ݒ肷�邱�Ɓj</param>
        /// <param name="partsSearchUIDataList">���i�������o����</param>
        /// <param name="retPartsInfoList">���i��������</param>
        /// <returns></returns>
        public int GetPartsInfoMain(PMKEN01010E dsCarModelInfo, List<PartsSearchUIData> partsSearchUIDataList, out List<PartsInfoDataSet> retPartsInfoList)
        {

            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // PartsInfoDataSet�̃N���A�A���������̐ݒ�
            partsInfoDic = new Dictionary<int, PartsInfoDataSet>();
            goodsTableDic = new Dictionary<int, PartsInfoDataSet.UsrGoodsInfoDataTable>();
            priceTableDic = new Dictionary<int, PartsInfoDataSet.UsrGoodsPriceDataTable>();
            stockTableDic = new Dictionary<int, PartsInfoDataSet.StockDataTable>();
            // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
            ofrPriceTableDic = new Dictionary<int, PartsInfoDataSet.UsrGoodsPriceDataTable>();
            // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<

            for (int i = 0; i < partsSearchUIDataList.Count; i++)
            {
                PartsInfoDataSet partsInfoDataSet = new PartsInfoDataSet();
                partsInfoDataSet.SearchCondition = partsSearchUIDataList[i].Clone();
                partsInfoDic.Add(i, partsInfoDataSet);

                PartsInfoDataSet.UsrGoodsInfoDataTable goodsTableTemp = new PartsInfoDataSet.UsrGoodsInfoDataTable();
                goodsTableTemp = partsInfoDic[i].UsrGoodsInfo;
                goodsTableDic.Add(i, goodsTableTemp);

                PartsInfoDataSet.UsrGoodsPriceDataTable priceTableTemp = new PartsInfoDataSet.UsrGoodsPriceDataTable();
                priceTableTemp = partsInfoDic[i].UsrGoodsPrice;
                priceTableDic.Add(i, priceTableTemp);

                PartsInfoDataSet.StockDataTable stockTableTemp = new PartsInfoDataSet.StockDataTable();
                stockTableTemp = partsInfoDic[i].Stock;
                stockTableDic.Add(i, stockTableTemp);

                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                // UPD 2015/03/31 SCM������ ���[�J�[��]�������i�Ή��A�񋟉��i��񏉊����s�v�̂��ߏC��-------------->>>>>
                //PartsInfoDataSet.UsrGoodsPriceDataTable ofrPriceTableTemp = new PartsInfoDataSet.UsrGoodsPriceDataTable();
                //ofrPriceTableTemp = partsInfoDic[i].OfrPriceDataTable;
                //ofrPriceTableDic.Add(i, ofrPriceTableTemp);
                ofrPriceTableDic.Add(i, partsInfoDic[i].OfrPriceDataTable);
                // UPD 2015/03/31 SCM������ ���[�J�[��]�������i�Ή��A�񋟉��i��񏉊����s�v�̂��ߏC��--------------<<<<<
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
            }
            _sectionCode = partsSearchUIDataList[0].SectionCode;
            _drPrmSettingWork = partsSearchUIDataList[0].PrmSettingWork;

            if (dsCarModelInfo != null)
            {
                carInfoDataSet = dsCarModelInfo;
                customerCarInfo = dsCarModelInfo.CarModelInfoSummarized;
            }
            else
            {
                carInfoDataSet = null;
                customerCarInfo = null;
            }

            if (_freeSearchDiv != 0)
            {
                // ������
                _freeSearchPartsSRetDic = null;
                _freeSearchPartsSRetWork = null;
            }

            // ������ޖ��Ƀ��X�g����
            // ����BL�R�[�h�����p
            Dictionary<int, PartsSearchUIData> searchBLCodeList = new Dictionary<int, PartsSearchUIData>();
            // �D��BL�R�[�h�����p
            Dictionary<int, PartsSearchUIData> searchPrimeBLCodeList = new Dictionary<int, PartsSearchUIData>();
            // TBO�����p
            Dictionary<int, PartsSearchUIData> searchTBOList = new Dictionary<int, PartsSearchUIData>();
            // ��BL�R�[�h�Ȃ������p
            Dictionary<int, PartsSearchUIData> searchNoBLCodeList = new Dictionary<int, PartsSearchUIData>();
            // ���R�������i�����p
            Dictionary<int, PartsSearchUIData> searchFreeSerachList = new Dictionary<int, PartsSearchUIData>();
            // �i�Ԍ����p
            Dictionary<int, PartsSearchUIData> searchGoodsNoList = new Dictionary<int, PartsSearchUIData>();

            for (int i = 0; i < partsSearchUIDataList.Count; i++)
            {
                // BL�R�[�h����
                if (partsSearchUIDataList[i].TbsPartsCode != 0)
                {
                    partsInfoDic[i].SearchMethod = 0; // �������@�F�i�Ԍ���[�i���\�������f�̂��ߎg�p]
                    // BL�R�[�h������ޔ���
                    switch (Blkind(partsSearchUIDataList[i].TbsPartsCode, (int)partsSearchUIDataList[i].SearchFlg))
                    {
                        // ����BL�R�[�h����
                        case 0:
                            searchBLCodeList.Add(i, partsSearchUIDataList[i]);
                            break;
                        // �D��BL�R�[�h����
                        case 1:
                            searchPrimeBLCodeList.Add(i, partsSearchUIDataList[i]);
                            break;
                        // TBO����
                        case 2:
                            searchTBOList.Add(i, partsSearchUIDataList[i]);
                            break;
                        // ��BL�R�[�h�Ȃ������p
                        case 3:
                            searchNoBLCodeList.Add(i, partsSearchUIDataList[i]);
                            break;
                        // ���R�������i�����p
                        default:
                            searchFreeSerachList.Add(i, partsSearchUIDataList[i]);
                            break;
                    }
                }
                // �i�Ԍ���
                else
                {
                    partsInfoDic[i].SearchMethod = 1; // �������@�F�i�Ԍ���[�i���\�������f�̂��ߎg�p]
                    searchGoodsNoList.Add(i, partsSearchUIDataList[i]);
                }
            }

            // ����BL�R�[�h����
            if (searchBLCodeList != null && searchBLCodeList.Count != 0)
            {
                if (_freeSearchDiv != 0)
                {
                    // ���R�������i����
                    FreeSearchPartsSearchMain(dsCarModelInfo, searchBLCodeList);
                }
                status = BlSearchMain(searchBLCodeList, false);
            }

            // �D��BL�R�[�h����
            if (searchPrimeBLCodeList != null && searchPrimeBLCodeList.Count != 0)
            {

                if (_freeSearchDiv != 0)
                {
                    // ���R�������i����
                    FreeSearchPartsSearchMain(dsCarModelInfo, searchPrimeBLCodeList);

                    // �D�ǂa�k�R�[�h����
                    status = PrimeBlSearchMain(searchPrimeBLCodeList);
                    if (status == 4 || partsInfo.UsrGoodsInfo.Count == 0)
                    {
                        // �������킾���A�q�b�g�Ȃ����ˏ����a�k�R�[�h����
                        status = BlSearchMain(searchPrimeBLCodeList, false);
                    }
                    else
                    {
                        // ���R�������i�W�J�i���\�b�h�����Œʏ�̏����a�k�R�[�h�����͎��s���Ȃ��j
                        status = BlSearchMain(searchPrimeBLCodeList, true);
                    }
                }
                else
                {
                    // �D�ǂa�k�R�[�h����
                    status = PrimeBlSearchMain(searchPrimeBLCodeList);
                    if (status == 4 || partsInfo.UsrGoodsInfo.Count == 0)
                    {
                        // �������킾���A�q�b�g�Ȃ���
                        status = BlSearchMain(searchPrimeBLCodeList, false);
                    }
                }
            }

            // TBO����
            if (searchTBOList != null && searchTBOList.Count != 0)
            {
                status = TBOSearchMain(searchTBOList);

                //TBO������A�q�b�g�����Ȃ�A����BL�R�[�h����
                if (status == 4 || partsInfo.UsrGoodsInfo.Count == 0)  // �������i�������s���͌�������Ńq�b�g�Ȃ���
                {
                    status = BlSearchMain(searchTBOList, false);
                }
            }

            // ����BL�R�[�h�Ȃ��̎�
            if (searchNoBLCodeList != null && searchNoBLCodeList.Count != 0)
            {
                // UPD ��10681 2014/09/09 �g�� -------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                #region ���\�[�X
                //status = TBOSearchMain(searchNoBLCodeList);

                ////TBO������A�q�b�g�����Ȃ�A����BL�R�[�h����
                //if (status == 4 || partsInfo.UsrGoodsInfo.Count == 0)  // �������i�������s���͌�������Ńq�b�g�Ȃ���
                //{
                //    status = BlSearchMain(searchNoBLCodeList, false);
                //}
                #endregion

                if (_freeSearchDiv != 0)
                {
                    // ���R�������i����
                    FreeSearchPartsSearchMain(dsCarModelInfo, searchNoBLCodeList);

                    status = BlSearchMain(searchNoBLCodeList, false);
                    if (_normalSearchStatus == 4 || partsInfo.UsrGoodsInfo.Count == 0)  // �������i�������s���͌�������Ńq�b�g�Ȃ���
                        status = PrimeBlSearchMain(searchNoBLCodeList);
                }
                else
                {
                    status = BlSearchMain(searchNoBLCodeList, false);
                    if (status == 4 || partsInfo.UsrGoodsInfo.Count == 0)  // �������i�������s���͌�������Ńq�b�g�Ȃ���
                        status = PrimeBlSearchMain(searchNoBLCodeList);
                }
                // UPD ��10681 2014/09/09 �g�� ------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }

            // ���R�������i�����̂�
            if (searchFreeSerachList != null && searchFreeSerachList.Count != 0)
            {
                // BLKind���Y���Ȃ��̏ꍇ�́A���R�������o�̂ݍs���B
                if (_freeSearchDiv != 0)
                {
                    // ���R�������i����
                    FreeSearchPartsSearchMain(dsCarModelInfo, searchFreeSerachList);

                    // ���R�������i�W�J
                    status = BlSearchMain(searchFreeSerachList, true);
                }
            }

            // �i�Ԍ���
            if (searchGoodsNoList != null && searchGoodsNoList.Count != 0)
            {
                status = PartsNoSearchMain(searchGoodsNoList);
            }

            retPartsInfoList = new List<PartsInfoDataSet>();
            for (int key = 0; key < partsSearchUIDataList.Count; key++)
            {
                if (partsInfoDic.ContainsKey(key))
                {
                    SetUsrGoodsKind(key);
                    partsInfoDic[key].AcceptChanges();
                    partsInfoDic[key].SearchCondition = partsSearchUIDataList[key];
                    retPartsInfoList.Add(partsInfoDic[key]);
                }
            }
            return status;
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        // --- ADD m.suzuki 2010/04/28 ---------->>>>>
        /// <summary>
        /// ���R�������i�}�X�^���o����
        /// </summary>
        /// <param name="dsCarModelInfo"></param>
        /// <param name="PartsSearchUIData"></param>
        private void FreeSearchPartsSearchMain( PMKEN01010E dsCarModelInfo, PartsSearchUIData PartsSearchUIData )
        {
            // ���o���ʊi�[�f�B�N�V���i���i���i���s��������ŕ₤�ׁA�ޔ����Ă����j
            _freeSearchPartsSRetDic = new Dictionary<string, List<FreeSearchPartsSRetWork>>();

            // �����[�g�I�u�W�F�N�g�擾
            IFreeSearchPartsSearchDB iFreeSearchPartsSearchDB = MediationFreeSearchPartsSearchDB.GetRemoteObject();

            # region [���o����]
            FreeSearchPartsSParaWork paraWork = new FreeSearchPartsSParaWork();

            paraWork.EnterpriseCode = PartsSearchUIData.EnterpriseCode; // ��ƃR�[�h
            paraWork.PriceStartDate = PartsSearchUIData.PriceDate; // ���i�J�n�� 
            paraWork.TbsPartsCode = PartsSearchUIData.TbsPartsCode; // �a�k�R�[�h
            paraWork.TbsPartsCdDerivedNo = 0; // �a�k�R�[�h�}��

            List<FreeSearchPartsSMdlParaWork> mdlList = new List<FreeSearchPartsSMdlParaWork>();
            foreach ( PMKEN01010E.CarModelInfoRow carRow in dsCarModelInfo.CarModelInfo.Rows )
            {
                // �I���t���O�`�F�b�N
                if ( carRow.SelectionState != true )
                {
                    continue;
                }

                // ���i�����̏����Ƃ��āA�^�������Z�b�g����
                FreeSearchPartsSMdlParaWork mdlParaWork = new FreeSearchPartsSMdlParaWork();

                //--------------------------------------------------
                // �^�����
                //--------------------------------------------------
                mdlParaWork.MakerCode = carRow.MakerCode; // ���[�J�[�R�[�h
                mdlParaWork.ModelCode = carRow.ModelCode; // �Ԏ�R�[�h
                mdlParaWork.ModelSubCode = carRow.ModelSubCode; // �Ԏ�T�u�R�[�h

                mdlParaWork.ExhaustGasSign = carRow.ExhaustGasSign; // �r�K�X�L���i�^���O�j
                mdlParaWork.SeriesModel = carRow.SeriesModel; // �V���[�Y�^���i�^���P�j
                mdlParaWork.CategorySignModel = carRow.CategorySignModel; // �^���i�ޕʋL���j�i�^���Q�j

                mdlParaWork.FullModel = carRow.FullModel; // �^���i�t���^�j

                if ( carInfoDataSet.CarModelUIData.Count > 0 )
                {
                    // �N��
                    if ( carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput > 0 )
                    {
                        mdlParaWork.ProduceTypeOfYear = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
                    }
                    // �ԑ�ԍ�
                    if ( carInfoDataSet.CarModelUIData[0].SearchFrameNo > 0 )
                    {
                        try
                        {
                            mdlParaWork.ProduceFrameNo = Convert.ToInt32( carInfoDataSet.CarModelUIData[0].FrameNo );
                        }
                        catch
                        {
                            mdlParaWork.ProduceFrameNo = 0;
                        }
                    }
                }

                //--------------------------------------------------
                // �������
                //--------------------------------------------------
                mdlParaWork.ModelGradeNm = carRow.ModelGradeNm; // �^���O���[�h����
                mdlParaWork.BodyName = carRow.BodyName; // �{�f�B�[����
                mdlParaWork.DoorCount = carRow.DoorCount; // �h�A��
                mdlParaWork.EngineModelNm = carRow.EngineModelNm; // �G���W���^������
                mdlParaWork.EngineDisplaceNm = carRow.EngineDisplaceNm; // �r�C�ʖ���
                mdlParaWork.EDivNm = carRow.EDivNm; // E�敪����
                mdlParaWork.TransmissionNm = carRow.TransmissionNm; // �~�b�V��������
                mdlParaWork.WheelDriveMethodNm = carRow.WheelDriveMethodNm; // �쓮��������
                mdlParaWork.ShiftNm = carRow.ShiftNm; // �V�t�g����

                mdlList.Add( mdlParaWork );
            }

            paraWork.FSPartsSModels = mdlList.ToArray();
            # endregion

            object retObj = null;
            Int64 retCount;

            // ���R�������i�}�X�^�擾�����[�g�Ăяo��
            iFreeSearchPartsSearchDB.Search( paraWork, ref retObj, out retCount );

            // �f�[�^�i�[�����i���̎��_�ł̓f�B�N�V���i���ւ̑ޔ��̂݁j
            if ( retCount > 0 )
            {
                ArrayList retArray = (retObj as ArrayList);

                foreach ( FreeSearchPartsSRetWork obj in retArray )
                {
                    string key = CreateFreeSearchRetDicKey( obj.GoodsMakerCd, obj.GoodsNo );
                    if ( !_freeSearchPartsSRetDic.ContainsKey( key ) )
                    {
                        _freeSearchPartsSRetDic.Add( key, new List<FreeSearchPartsSRetWork>() );
                    }
                    _freeSearchPartsSRetDic[key].Add( obj );
                }

                // �ŏ��̂P����ޔ����Ă���
                _freeSearchPartsSRetWork = (FreeSearchPartsSRetWork)retArray[0];
            }
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ���R�������i�}�X�^���o����
        /// </summary>
        /// <param name="dsCarModelInfo"></param>
        /// <param name="partsSearchUIDataDic"></param>
        private void FreeSearchPartsSearchMain(PMKEN01010E dsCarModelInfo, Dictionary<int,PartsSearchUIData> partsSearchUIDataDic)
        {
            // ���o���ʊi�[�f�B�N�V���i���i���i���s��������ŕ₤�ׁA�ޔ����Ă����j
            _freeSearchPartsSRetDic = new Dictionary<string, List<FreeSearchPartsSRetWork>>();

            // �����[�g�I�u�W�F�N�g�擾
            IFreeSearchPartsSearchDB iFreeSearchPartsSearchDB = MediationFreeSearchPartsSearchDB.GetRemoteObject();

            # region [���o����]
            ArrayList paraWorkList = new ArrayList();

            foreach (PartsSearchUIData partsSearchUIData in partsSearchUIDataDic.Values)
            {
                FreeSearchPartsSParaWork paraWork = new FreeSearchPartsSParaWork();

                paraWork.EnterpriseCode = partsSearchUIData.EnterpriseCode; // ��ƃR�[�h
                paraWork.PriceStartDate = partsSearchUIData.PriceDate; // ���i�J�n�� 
                paraWork.TbsPartsCode = partsSearchUIData.TbsPartsCode; // �a�k�R�[�h
                paraWork.TbsPartsCdDerivedNo = 0; // �a�k�R�[�h�}��

                List<FreeSearchPartsSMdlParaWork> mdlList = new List<FreeSearchPartsSMdlParaWork>();
                foreach (PMKEN01010E.CarModelInfoRow carRow in dsCarModelInfo.CarModelInfo.Rows)
                {
                    // �I���t���O�`�F�b�N
                    if (carRow.SelectionState != true)
                    {
                        continue;
                    }

                    // ���i�����̏����Ƃ��āA�^�������Z�b�g����
                    FreeSearchPartsSMdlParaWork mdlParaWork = new FreeSearchPartsSMdlParaWork();

                    //--------------------------------------------------
                    // �^�����
                    //--------------------------------------------------
                    mdlParaWork.MakerCode = carRow.MakerCode; // ���[�J�[�R�[�h
                    mdlParaWork.ModelCode = carRow.ModelCode; // �Ԏ�R�[�h
                    mdlParaWork.ModelSubCode = carRow.ModelSubCode; // �Ԏ�T�u�R�[�h

                    mdlParaWork.ExhaustGasSign = carRow.ExhaustGasSign; // �r�K�X�L���i�^���O�j
                    mdlParaWork.SeriesModel = carRow.SeriesModel; // �V���[�Y�^���i�^���P�j
                    mdlParaWork.CategorySignModel = carRow.CategorySignModel; // �^���i�ޕʋL���j�i�^���Q�j

                    mdlParaWork.FullModel = carRow.FullModel; // �^���i�t���^�j

                    if (carInfoDataSet.CarModelUIData.Count > 0)
                    {
                        // �N��
                        if (carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput > 0)
                        {
                            mdlParaWork.ProduceTypeOfYear = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
                        }
                        // �ԑ�ԍ�
                        if (carInfoDataSet.CarModelUIData[0].SearchFrameNo > 0)
                        {
                            try
                            {
                                mdlParaWork.ProduceFrameNo = Convert.ToInt32(carInfoDataSet.CarModelUIData[0].FrameNo);
                            }
                            catch
                            {
                                mdlParaWork.ProduceFrameNo = 0;
                            }
                        }
                    }

                    //--------------------------------------------------
                    // �������
                    //--------------------------------------------------
                    mdlParaWork.ModelGradeNm = carRow.ModelGradeNm; // �^���O���[�h����
                    mdlParaWork.BodyName = carRow.BodyName; // �{�f�B�[����
                    mdlParaWork.DoorCount = carRow.DoorCount; // �h�A��
                    mdlParaWork.EngineModelNm = carRow.EngineModelNm; // �G���W���^������
                    mdlParaWork.EngineDisplaceNm = carRow.EngineDisplaceNm; // �r�C�ʖ���
                    mdlParaWork.EDivNm = carRow.EDivNm; // E�敪����
                    mdlParaWork.TransmissionNm = carRow.TransmissionNm; // �~�b�V��������
                    mdlParaWork.WheelDriveMethodNm = carRow.WheelDriveMethodNm; // �쓮��������
                    mdlParaWork.ShiftNm = carRow.ShiftNm; // �V�t�g����

                    mdlList.Add(mdlParaWork);
                }

                paraWork.FSPartsSModels = mdlList.ToArray();

                paraWorkList.Add(paraWork);

            }
            # endregion

            ArrayList para = paraWorkList;
            object retObj = null;
            Int64 retCount;

            // ���R�������i�}�X�^�擾�����[�g�Ăяo��
            iFreeSearchPartsSearchDB.Search(para, ref retObj, out retCount);

            // �f�[�^�i�[�����i���̎��_�ł̓f�B�N�V���i���ւ̑ޔ��̂݁j
            if (retCount > 0)
            {
                List<int> partsSearchKeyList = new List<int>(partsSearchUIDataDic.Keys);
                 
                ArrayList retArray = retObj as ArrayList;
                bool firstRec = false;

                for (int i = 0; i < retArray.Count; i++)
                {
                    ArrayList retArray2 = retArray[i] as ArrayList;
                    if (retArray2.Count > 0)
                    {
                        FreeSearchPartsSRetWork[] FreeSearchPartsSRetWorkList = (FreeSearchPartsSRetWork[])retArray2.ToArray(typeof(FreeSearchPartsSRetWork));

                        // �ŏ��̂P����ޔ����Ă���
                        if (!firstRec)
                        {
                            _freeSearchPartsSRetWork = FreeSearchPartsSRetWorkList[0];
                            firstRec = true;
                        }

                        foreach (FreeSearchPartsSRetWork obj in FreeSearchPartsSRetWorkList)
                        {
                            string key = CreateFreeSearchRetDicKey(partsSearchKeyList[i], obj.GoodsMakerCd, obj.GoodsNo);
                            if (!_freeSearchPartsSRetDic.ContainsKey(key))
                            {
                                _freeSearchPartsSRetDic.Add(key, new List<FreeSearchPartsSRetWork>());
                            }
                            _freeSearchPartsSRetDic[key].Add(obj);
                        }
                    }
                }
            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        /// <summary>
        /// ���R�������i����DataTable�ւ̊i�[����
        /// </summary>
        /// <param name="retPartsInfListDic"></param>
        private void FillFreeSearchPartsInfo( Dictionary<string, List<FreeSearchPartsSRetWork>> retPartsInfListDic )
        {
            foreach ( string key in retPartsInfListDic.Keys )
            {
                List<FreeSearchPartsSRetWork> retPartsInfList = retPartsInfListDic[key];
                foreach ( FreeSearchPartsSRetWork retWork in retPartsInfList )
                {
                    // BL�R�[�h�EBL�R�[�h�}��
                    int tbsPartsCode = retWork.BLGoodsCodeFromGoods;
                    int tbsPartsCdDerivedNo = 0;

                    // �񋟏���
                    RetPartsInf retPartsInf = null;
                    if ( _retPartsInfDic.ContainsKey( key ) )
                    {
                        retPartsInf = _retPartsInfDic[key];
                    }

                    // �񋟗D��
                    OfferJoinPartsRetWork retPrimParts = null;
                    if ( _primPartsRetDic.ContainsKey( key ) )
                    {
                        retPrimParts = _primPartsRetDic[key];
                    }

                    // �񋟗D�ǉ��i
                    OfferJoinPriceRetWork retPrimPrice = null;
                    if ( _primPriceRetDic.ContainsKey( key ) )
                    {
                        retPrimPrice = GetPrimePrice( _primPriceRetDic[key] );
                    }

                    //--------------------------------------------------
                    // ���i���e�[�u���ւ̊i�[
                    //--------------------------------------------------

                    // ���i�}�X�^�̊Y�������������ꍇ�͂a�k�R�[�h�}�X�^�̕i�����Z�b�g����B
                    if ( string.IsNullOrEmpty( retWork.GoodsName.Trim() ) && string.IsNullOrEmpty( retWork.GoodsNoFromGoods.Trim() ) )
                    {
                        retWork.GoodsName = retWork.BLGoodsFullName;
                        retWork.GoodsNameKana = retWork.BLGoodsHalfName;
                        tbsPartsCode = retWork.TbsPartsCode;
                        tbsPartsCdDerivedNo = retWork.TbsPartsCdDerivedNo;
                    }

                    # region [���R�������i���]

                    PartsInfoDataSet.PartsInfoRow partsInfoRow = partsInfo.PartsInfo.NewPartsInfoRow();

                    # region [�񋟏���or�񋟗D�ǂ���Z�b�g]
                    if ( !string.IsNullOrEmpty( retWork.GoodsNoFromGoods ) )
                    {
                        // ���[�U�[���i

                    }
                    else if ( retPartsInf != null )
                    {
                        //----------------------------------------
                        // �񋟏�������Z�b�g
                        //----------------------------------------
                        // Row�ɃZ�b�g
                        partsInfoRow.OfferDate = retPartsInf.OfferDate;
                        partsInfoRow.FigshapeNo = retPartsInf.FigShapeNo;
                        partsInfoRow.StandardName = retPartsInf.StandardName;
                        partsInfoRow.ColdDistrictsFlag = retPartsInf.ColdDistrictsFlag;
                        partsInfoRow.ColorNarrowingFlag = retPartsInf.ColorNarrowingFlag;
                        partsInfoRow.TrimNarrowingFlag = retPartsInf.TrimNarrowingFlag;
                        partsInfoRow.EquipNarrowingFlag = retPartsInf.EquipNarrowingFlag;
                        partsInfoRow.NewPrtsNoNoneHyphen = retPartsInf.NewPrtsNoWithHyphen;
                        partsInfoRow.MakerOfferPartsName = retPartsInf.MakerOfferPartsName;
                        partsInfoRow.PartsSearchCode = retPartsInf.PartsSearchCode;
                        partsInfoRow.PartsCode = retPartsInf.PartsCode;

                        // ���̌�̏����ł��g�p����̂ŁAretWork������������
                        retWork.GoodsName = retPartsInf.PartsName;
                        retWork.GoodsNameKana = retPartsInf.PartsNameKana;
                        retWork.ListPrice = retPartsInf.PartsPrice;
                        retWork.OpenPriceDiv = retPartsInf.OpenPriceDiv;
                        retWork.PriceStartDate = retPartsInf.PartsPriceStDate;
                        retWork.GoodsRateRank = retPartsInf.PartsLayerCd;
                    }
                    else if ( retPrimParts != null )
                    {
                        //----------------------------------------
                        // �񋟗D�ǂ���Z�b�g
                        //----------------------------------------
                        // Row�ɃZ�b�g
                        partsInfoRow.OfferDate = retPrimParts.OfferDate;

                        // ���̌�̏����ł��g�p����̂ŁAretWork������������
                        retWork.GoodsName = retPrimParts.PrimePartsName;
                        retWork.GoodsNameKana = retPrimParts.PrimePartsKanaName;
                        retWork.GoodsRateRank = retPrimParts.PartsLayerCd;

                        if ( retPrimPrice != null )
                        {
                            retWork.ListPrice = retPrimPrice.NewPrice;
                            retWork.OpenPriceDiv = retPrimPrice.OpenPriceDiv;
                            retWork.PriceStartDate = retPrimPrice.PriceStartDate;
                        }
                    }
                    # endregion

                    partsInfoRow.PartsName = retWork.GoodsName;
                    partsInfoRow.PartsNameKana = retWork.GoodsNameKana;
                    partsInfoRow.TbsPartsCode = tbsPartsCode;
                    partsInfoRow.TbsPartsCdDerivedNo = tbsPartsCdDerivedNo;
                    partsInfoRow.TbsPartsCodeFS = retWork.TbsPartsCode;
                    partsInfoRow.ModelPrtsAdptYm = GetLongDateYM( retWork.ModelPrtsAdptYm );
                    partsInfoRow.ModelPrtsAblsYm = GetLongDateYM( retWork.ModelPrtsAblsYm );
                    partsInfoRow.ModelPrtsAdptFrameNo = retWork.ModelPrtsAdptFrameNo;
                    partsInfoRow.ModelPrtsAblsFrameNo = retWork.ModelPrtsAblsFrameNo;
                    partsInfoRow.PartsQty = retWork.PartsQty;
                    partsInfoRow.PartsOpNm = string.Format( "���R�����F{0}", retWork.PartsOpNm );
                    partsInfoRow.CatalogPartsMakerCd = retWork.GoodsMakerCd;
                    partsInfoRow.CatalogPartsMakerNm = GetPartsMakerName( retWork.GoodsMakerCd );
                    partsInfoRow.ClgPrtsNoWithHyphen = retWork.GoodsNo.Trim();
                    partsInfoRow.MakerOfferPartsName = retWork.GoodsName;
                    partsInfoRow.PartsLayerCd = retWork.GoodsRateRank;
                    partsInfoRow.SeriesModel = retWork.SeriesModel;
                    partsInfoRow.CategorySignModel = retWork.CategorySignModel;
                    partsInfoRow.ExhaustGasSign = retWork.ExhaustGasSign;

                    partsInfoRow.NewPrtsNoWithHyphen = retWork.GoodsNo;
                    partsInfoRow.NewPrtsNoNoneHyphen = retWork.GoodsNoNoneHyphen;

                    partsInfoRow.FreSrchPrtPropNo = retWork.FreSrchPrtPropNo; // ���R�������i�ŗL�ԍ�

                    partsInfo.PartsInfo.AddPartsInfoRow( partsInfoRow );
                    # endregion

                    //--------------------------------------------------
                    // ���i�}�X�^�e�[�u���֊i�[
                    //--------------------------------------------------

                    #region ���i�}�X�^�e�[�u���ɐݒ�
                    string partsNo = retWork.GoodsNo;
                    PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                        goodsTable.FindByGoodsMakerCdGoodsNo( retWork.GoodsMakerCd, partsNo );
                    if ( usrGoodsRow == null )
                    {
                        usrGoodsRow = goodsTable.NewUsrGoodsInfoRow();

                        usrGoodsRow.BlGoodsCode = tbsPartsCode;
                        usrGoodsRow.GoodsKindCode = 0; // 0 : ����
                        usrGoodsRow.GoodsKind = (int)GoodsKind.Parent; // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                        usrGoodsRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        usrGoodsRow.GoodsMakerNm = partsInfoRow.CatalogPartsMakerNm;
                        //usrGoodsRow.GoodsMGroup = 0;
                        usrGoodsRow.GoodsRateRank = retWork.GoodsRateRank;
                        usrGoodsRow.GoodsNoNoneHyphen = partsInfoRow.ClgPrtsNoWithHyphen.Replace( "-", "" );
                        usrGoodsRow.QTY = retWork.PartsQty;
                        usrGoodsRow.GoodsNote1 = string.Empty;//retWork.StandardName; //�K�i
                        //usrGoodsRow.GoodsNote2 = "";
                        usrGoodsRow.GoodsSpecialNote = retWork.PartsOpNm;
                        usrGoodsRow.OfferDate = DateTime.MinValue; //retWork.OfferDate;

                        usrGoodsRow.OfferKubun = 0; // (0:���[�U�[�o�^�^1:�񋟏����ҏW�^2:�񋟗D�ǕҏW�^3:�񋟏����^4:�񋟗D�ǁj

                        //usrGoodsRow.TaxationDivCd = 0;
                        usrGoodsRow.GoodsNo = partsInfoRow.ClgPrtsNoWithHyphen;
                        usrGoodsRow.OfferDataDiv = 0; //1;

                        usrGoodsRow.GoodsName = retWork.GoodsName;
                        usrGoodsRow.GoodsNameKana = retWork.GoodsNameKana;
                        usrGoodsRow.GoodsOfrName = retWork.GoodsName; // ���i��
                        usrGoodsRow.GoodsOfrNameKana = retWork.GoodsNameKana;
                        usrGoodsRow.SearchPartsFullName = retWork.GoodsName;
                        usrGoodsRow.SearchPartsHalfName = retWork.GoodsNameKana;
                        usrGoodsRow.SrchPNmAcqrCarMkrCd = 0; //retWork.SrchPNmAcqrCarMkrCd;   // �����i���擾���[�J�[�R�[�h
                        usrGoodsRow.PartsPriceStDate = retWork.PriceStartDate;


                        # region [�񋟏���/�񋟗D�ǂ���Z�b�g]
                        if ( !string.IsNullOrEmpty( retWork.GoodsNoFromGoods ) )
                        {
                            // ���[�U�[���i

                            if ( retPartsInf != null )
                            {
                                // �����i�����X�V
                                usrGoodsRow.SearchPartsFullName = retPartsInf.PartsName;
                                usrGoodsRow.SearchPartsHalfName = retPartsInf.PartsNameKana;
                                usrGoodsRow.SrchPNmAcqrCarMkrCd = retPartsInf.SrchPNmAcqrCarMkrCd;
                            }
                            else if ( retPrimParts != null )
                            {
                                usrGoodsRow.SearchPartsFullName = retPrimParts.SearchPartsFullName;
                                usrGoodsRow.SearchPartsHalfName = retPrimParts.SearchPartsHalfName;
                                usrGoodsRow.SrchPNmAcqrCarMkrCd = retPrimParts.JoinDestMakerCd;   // �����i���擾���[�J�[�R�[�h
                            }
                        }
                        else if ( retPartsInf != null )
                        {
                            // ����
                            usrGoodsRow.GoodsNote1 = retPartsInf.StandardName; //�K�i
                            usrGoodsRow.OfferDate = retPartsInf.OfferDate; // �񋟓�
                            usrGoodsRow.SearchPartsFullName = retPartsInf.PartsName;
                            usrGoodsRow.SearchPartsHalfName = retPartsInf.PartsNameKana;
                            usrGoodsRow.SrchPNmAcqrCarMkrCd = retPartsInf.SrchPNmAcqrCarMkrCd;   // �����i���擾���[�J�[�R�[�h
                            usrGoodsRow.OfferKubun = 3; // (0:���[�U�[�o�^�^1:�񋟏����ҏW�^2:�񋟗D�ǕҏW�^3:�񋟏����^4:�񋟗D�ǁj
                        }
                        else if ( retPrimParts != null )
                        {
                            // �D��
                            usrGoodsRow.OfferDate = retPrimParts.OfferDate; // �񋟓�
                            usrGoodsRow.SearchPartsFullName = retPrimParts.SearchPartsFullName;
                            usrGoodsRow.SearchPartsHalfName = retPrimParts.SearchPartsHalfName;
                            usrGoodsRow.SrchPNmAcqrCarMkrCd = retPrimParts.JoinDestMakerCd;   // �����i���擾���[�J�[�R�[�h
                            usrGoodsRow.OfferKubun = 4; // (0:���[�U�[�o�^�^1:�񋟏����ҏW�^2:�񋟗D�ǕҏW�^3:�񋟏����^4:�񋟗D�ǁj
                        }
                        # endregion

                        usrGoodsRow.FreSrchPrtPropNo = retWork.FreSrchPrtPropNo; // ���R�������i�ŗL�ԍ�

                        partsInfoRow.UsrGoodsInfoRowParentByUsrGoodsInfo_PartsInfo = usrGoodsRow;
                        goodsTable.AddUsrGoodsInfoRow( usrGoodsRow );
                    }
                    # endregion

                    //--------------------------------------------------
                    // ���i�e�[�u���֊i�[
                    //--------------------------------------------------

                    # region [���i�e�[�u���ɐݒ�]
                    if ( priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo( retWork.GoodsMakerCd,
                        retWork.PriceStartDate, retWork.GoodsNo ) == null )
                    {
                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTable.NewUsrGoodsPriceRow();

                        usrPriceRow.GoodsNo = retWork.GoodsNo;
                        usrPriceRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        double listPrice = retWork.ListPrice;
                        this.ReflectIsolIslandCall( 0, retWork.GoodsMakerCd, 3, ref listPrice );
                        usrPriceRow.ListPrice = listPrice;
                        usrPriceRow.OpenPriceDiv = retWork.OpenPriceDiv;
                        usrPriceRow.PriceStartDate = retWork.PriceStartDate;
                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                        # region [�񋟏�������Z�b�g]
                        if ( retPartsInf != null )
                        {
                            usrPriceRow.OfferDate = retPartsInf.PriceOfferDate;
                        }
                        # endregion

                        priceTable.AddUsrGoodsPriceRow( usrPriceRow );
                    }
                    // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                    // UPD 2015/03/30 �S�̔z�M�V�X�e���e�X�g��Q��60�Ή� ------------------------------------>>>>>
                    //if (ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(retWork.GoodsMakerCd,
                    //    retWork.PriceStartDate, retWork.GoodsNo) == null)
                    // �񋟃f�[�^���擾�ł������A���񋟃f�[�^���i���f�[�^�e�[�u���ɑΏۂ̉��i���R�[�h�����݂��Ȃ����ǉ�
                    // UPD 2015/03/31 SCM������ ���[�J�[��]�������i�Ή��@���R�������i���i���Ή�------------>>>>>
                    //if ((retPartsInf != null) && 
                    //    (ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(retWork.GoodsMakerCd,retWork.PriceStartDate, retWork.GoodsNo) == null))
                    if ((retPartsInf != null) && 
                        (ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(retWork.GoodsMakerCd,retPartsInf.PartsPriceStDate, retWork.GoodsNo) == null))
                    // UPD 2015/03/31 SCM������ ���[�J�[��]�������i�Ή��@���R�������i���i���Ή�------------<<<<<
                    // UPD 2015/03/30 �S�̔z�M�V�X�e���e�X�g��Q��60�Ή� ------------------------------------<<<<<
                    {
                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTable.NewUsrGoodsPriceRow();

                        // UPD 2015/03/30 �S�̔z�M�V�X�e���e�X�g��Q��60�Ή� ------------------------------------>>>>>
                        #region �폜
                        //usrPriceRow.GoodsNo = retWork.GoodsNo;
                        //usrPriceRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        //double listPrice = retWork.ListPrice;
                        //this.ReflectIsolIslandCall(0, retWork.GoodsMakerCd, 3, ref listPrice);
                        //usrPriceRow.ListPrice = listPrice;
                        //usrPriceRow.OpenPriceDiv = retWork.OpenPriceDiv;
                        //usrPriceRow.PriceStartDate = retWork.PriceStartDate;
                        //usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                        //# region [�񋟏�������Z�b�g]
                        //if (retPartsInf != null)
                        //{
                        //    usrPriceRow.OfferDate = retPartsInf.PriceOfferDate;
                        //}
                        //# endregion
                        #endregion
                        usrPriceRow.GoodsNo = retWork.GoodsNo;
                        usrPriceRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                        // �񋟏�������Z�b�g
                        usrPriceRow.OpenPriceDiv = retPartsInf.OpenPriceDiv;
                        usrPriceRow.PriceStartDate = retPartsInf.PartsPriceStDate;
                        double listPrice = retPartsInf.PartsPrice;
                        this.ReflectIsolIslandCall(0, retWork.GoodsMakerCd, 3, ref listPrice);
                        usrPriceRow.ListPrice = listPrice;
                        usrPriceRow.OfferDate = retPartsInf.PriceOfferDate;
                        // UPD 2015/03/30 �S�̔z�M�V�X�e���e�X�g��Q��60�Ή� ------------------------------------<<<<<

                        ofrPriceTable.AddUsrGoodsPriceRow(usrPriceRow);
                    }
                    // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
                    // ADD 2015/03/31 SCM������ ���[�J�[��]�������i�Ή��@���R�������i���i���Ή�------------->>>>>
                    // �񋟗D�ǃf�[�^�A�񋟗D�ǉ��i��񂪎擾�ł��鎞�A���񋟃f�[�^���i���e�[�u���ɊY�����鉿�i���f�[�^�����݂��Ȃ����ǉ�
                    if ((retPrimParts != null && retPrimPrice != null) &&
                        (ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(retWork.GoodsMakerCd, retPrimPrice.PriceStartDate, retWork.GoodsNo) == null))
                    {
                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTable.NewUsrGoodsPriceRow();

                        usrPriceRow.GoodsNo = retWork.GoodsNo;
                        usrPriceRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                        // �񋟗D�ǂ���Z�b�g
                        usrPriceRow.OpenPriceDiv = retPrimPrice.OpenPriceDiv;
                        usrPriceRow.PriceStartDate = retPrimPrice.PriceStartDate;
                        usrPriceRow.ListPrice = retPrimPrice.NewPrice;
                        usrPriceRow.OfferDate = retPrimPrice.OfferDate;

                        ofrPriceTable.AddUsrGoodsPriceRow(usrPriceRow);
                    }
                    // ADD 2015/03/31 SCM������ ���[�J�[��]�������i�Ή��@���R�������i���i���Ή�-------------<<<<<
                    # endregion

                    //--------------------------------------------------
                    // ���i�֘A�^�����e�[�u���֊i�[
                    //--------------------------------------------------

                    #region ���i�֘A�^�����ݒ�
                    PartsInfoDataSet.ModelPartsDetailDataTable modelInfo = partsInfo.ModelPartsDetail;

                    string select = string.Format( "{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}' AND {6} = '{7}' ",
                                                   carInfoDataSet.CarModelInfo.MakerCodeColumn.ColumnName, retWork.MakerCode,
                                                   carInfoDataSet.CarModelInfo.ModelCodeColumn.ColumnName, retWork.ModelCode,
                                                   carInfoDataSet.CarModelInfo.ModelSubCodeColumn.ColumnName, retWork.ModelSubCode,
                                                   carInfoDataSet.CarModelInfo.FullModelColumn.ColumnName, retWork.FullModel );

                    PMKEN01010E.CarModelInfoRow[] carModelInfoRows = (PMKEN01010E.CarModelInfoRow[])carInfoDataSet.CarModelInfo.Select( select );

                    //���q��񁨕��i�ڍׁi�^�����j�ݒ�
                    for ( int ix = 0; ix < carModelInfoRows.Length; ix++ )
                    {
                        PartsInfoDataSet.ModelPartsDetailRow modelPartsDetailRow = modelInfo.NewModelPartsDetailRow();

                        modelPartsDetailRow.PartsUniqueNo = 0;
                        modelPartsDetailRow.PartsMakerCd = retWork.GoodsMakerCd;
                        modelPartsDetailRow.PartsNo = retWork.GoodsNo;

                        modelPartsDetailRow.FullModelFixedNo = carModelInfoRows[ix].FullModelFixedNo;
                        modelPartsDetailRow.DoorCount = carModelInfoRows[ix].DoorCount;
                        modelPartsDetailRow.BodyName = carModelInfoRows[ix].BodyName;
                        modelPartsDetailRow.ModelGradeNm = carModelInfoRows[ix].ModelGradeNm;
                        modelPartsDetailRow.EngineModelNm = carModelInfoRows[ix].EngineModelNm;
                        modelPartsDetailRow.EngineDisplaceNm = carModelInfoRows[ix].EngineDisplaceNm;
                        modelPartsDetailRow.EDivNm = carModelInfoRows[ix].EDivNm;
                        modelPartsDetailRow.TransmissionNm = carModelInfoRows[ix].TransmissionNm;
                        modelPartsDetailRow.ShiftNm = carModelInfoRows[ix].ShiftNm;
                        modelPartsDetailRow.WheelDriveMethodNm = carModelInfoRows[ix].WheelDriveMethodNm;
                        modelPartsDetailRow.AddiCarSpec1 = carModelInfoRows[ix].AddiCarSpec1;
                        modelPartsDetailRow.AddiCarSpec2 = carModelInfoRows[ix].AddiCarSpec2;
                        modelPartsDetailRow.AddiCarSpec3 = carModelInfoRows[ix].AddiCarSpec3;
                        modelPartsDetailRow.AddiCarSpec4 = carModelInfoRows[ix].AddiCarSpec4;
                        modelPartsDetailRow.AddiCarSpec5 = carModelInfoRows[ix].AddiCarSpec5;
                        modelPartsDetailRow.AddiCarSpec6 = carModelInfoRows[ix].AddiCarSpec6;

                        modelInfo.AddModelPartsDetailRow( modelPartsDetailRow );
                    }
                    if ( carModelInfoRows.Length > 0 )
                    {
                        modelInfo.Columns[modelInfo.AddiCarSpec1Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle1;
                        modelInfo.Columns[modelInfo.AddiCarSpec2Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle2;
                        modelInfo.Columns[modelInfo.AddiCarSpec3Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle3;
                        modelInfo.Columns[modelInfo.AddiCarSpec4Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle4;
                        modelInfo.Columns[modelInfo.AddiCarSpec5Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle5;
                        modelInfo.Columns[modelInfo.AddiCarSpec6Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle6;
                    }
                    #endregion
                }
            }
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ���R�������i����DataTable�ւ̊i�[����
        /// </summary>
        /// <param name="retPartsInfListDic"></param>
        /// <param name="dicKey"></param>
        private void FillFreeSearchPartsInfo(Dictionary<string, List<FreeSearchPartsSRetWork>> retPartsInfListDic, int dicKey)
        {
            foreach (string key in retPartsInfListDic.Keys)
            {
                // ���׍s�ԍ��ƈႤ���͎��̎��R�������i����
                if (key.Substring(0, 2) != dicKey.ToString("00")) continue;

                List<FreeSearchPartsSRetWork> retPartsInfList = retPartsInfListDic[key];
                foreach (FreeSearchPartsSRetWork retWork in retPartsInfList)
                {
                    // BL�R�[�h�EBL�R�[�h�}��
                    int tbsPartsCode = retWork.BLGoodsCodeFromGoods;
                    int tbsPartsCdDerivedNo = 0;

                    // �񋟏���
                    RetPartsInf retPartsInf = null;
                    if (_retPartsInfDic.ContainsKey(key))
                    {
                        retPartsInf = _retPartsInfDic[key];
                    }

                    // �񋟗D��
                    OfferJoinPartsRetWork retPrimParts = null;
                    if (_primPartsRetDic.ContainsKey(key))
                    {
                        retPrimParts = _primPartsRetDic[key];
                    }

                    // �񋟗D�ǉ��i
                    OfferJoinPriceRetWork retPrimPrice = null;
                    if (_primPriceRetDic.ContainsKey(key))
                    {
                        retPrimPrice = GetPrimePrice(_primPriceRetDic[key]);
                    }

                    //--------------------------------------------------
                    // ���i���e�[�u���ւ̊i�[
                    //--------------------------------------------------

                    // ���i�}�X�^�̊Y�������������ꍇ�͂a�k�R�[�h�}�X�^�̕i�����Z�b�g����B
                    if (string.IsNullOrEmpty(retWork.GoodsName.Trim()) && string.IsNullOrEmpty(retWork.GoodsNoFromGoods.Trim()))
                    {
                        retWork.GoodsName = retWork.BLGoodsFullName;
                        retWork.GoodsNameKana = retWork.BLGoodsHalfName;
                        tbsPartsCode = retWork.TbsPartsCode;
                        tbsPartsCdDerivedNo = retWork.TbsPartsCdDerivedNo;
                    }

                    # region [���R�������i���]

                    PartsInfoDataSet.PartsInfoRow partsInfoRow = partsInfoDic[dicKey].PartsInfo.NewPartsInfoRow();

                    # region [�񋟏���or�񋟗D�ǂ���Z�b�g]
                    if (!string.IsNullOrEmpty(retWork.GoodsNoFromGoods))
                    {
                        // ���[�U�[���i

                    }
                    else if (retPartsInf != null)
                    {
                        //----------------------------------------
                        // �񋟏�������Z�b�g
                        //----------------------------------------
                        // Row�ɃZ�b�g
                        partsInfoRow.OfferDate = retPartsInf.OfferDate;
                        partsInfoRow.FigshapeNo = retPartsInf.FigShapeNo;
                        partsInfoRow.StandardName = retPartsInf.StandardName;
                        partsInfoRow.ColdDistrictsFlag = retPartsInf.ColdDistrictsFlag;
                        partsInfoRow.ColorNarrowingFlag = retPartsInf.ColorNarrowingFlag;
                        partsInfoRow.TrimNarrowingFlag = retPartsInf.TrimNarrowingFlag;
                        partsInfoRow.EquipNarrowingFlag = retPartsInf.EquipNarrowingFlag;
                        partsInfoRow.NewPrtsNoNoneHyphen = retPartsInf.NewPrtsNoWithHyphen;
                        partsInfoRow.MakerOfferPartsName = retPartsInf.MakerOfferPartsName;
                        partsInfoRow.PartsSearchCode = retPartsInf.PartsSearchCode;
                        partsInfoRow.PartsCode = retPartsInf.PartsCode;

                        // ���̌�̏����ł��g�p����̂ŁAretWork������������
                        retWork.GoodsName = retPartsInf.PartsName;
                        retWork.GoodsNameKana = retPartsInf.PartsNameKana;
                        retWork.ListPrice = retPartsInf.PartsPrice;
                        retWork.OpenPriceDiv = retPartsInf.OpenPriceDiv;
                        retWork.PriceStartDate = retPartsInf.PartsPriceStDate;
                        retWork.GoodsRateRank = retPartsInf.PartsLayerCd;
                    }
                    else if (retPrimParts != null)
                    {
                        //----------------------------------------
                        // �񋟗D�ǂ���Z�b�g
                        //----------------------------------------
                        // Row�ɃZ�b�g
                        partsInfoRow.OfferDate = retPrimParts.OfferDate;

                        // ���̌�̏����ł��g�p����̂ŁAretWork������������
                        retWork.GoodsName = retPrimParts.PrimePartsName;
                        retWork.GoodsNameKana = retPrimParts.PrimePartsKanaName;
                        retWork.GoodsRateRank = retPrimParts.PartsLayerCd;

                        if (retPrimPrice != null)
                        {
                            retWork.ListPrice = retPrimPrice.NewPrice;
                            retWork.OpenPriceDiv = retPrimPrice.OpenPriceDiv;
                            retWork.PriceStartDate = retPrimPrice.PriceStartDate;
                        }
                    }
                    # endregion

                    partsInfoRow.PartsName = retWork.GoodsName;
                    partsInfoRow.PartsNameKana = retWork.GoodsNameKana;
                    partsInfoRow.TbsPartsCode = tbsPartsCode;
                    partsInfoRow.TbsPartsCdDerivedNo = tbsPartsCdDerivedNo;
                    partsInfoRow.TbsPartsCodeFS = retWork.TbsPartsCode;
                    partsInfoRow.ModelPrtsAdptYm = GetLongDateYM(retWork.ModelPrtsAdptYm);
                    partsInfoRow.ModelPrtsAblsYm = GetLongDateYM(retWork.ModelPrtsAblsYm);
                    partsInfoRow.ModelPrtsAdptFrameNo = retWork.ModelPrtsAdptFrameNo;
                    partsInfoRow.ModelPrtsAblsFrameNo = retWork.ModelPrtsAblsFrameNo;
                    partsInfoRow.PartsQty = retWork.PartsQty;
                    partsInfoRow.PartsOpNm = string.Format("���R�����F{0}", retWork.PartsOpNm);
                    partsInfoRow.CatalogPartsMakerCd = retWork.GoodsMakerCd;
                    partsInfoRow.CatalogPartsMakerNm = GetPartsMakerName(retWork.GoodsMakerCd);
                    partsInfoRow.ClgPrtsNoWithHyphen = retWork.GoodsNo.Trim();
                    partsInfoRow.MakerOfferPartsName = retWork.GoodsName;
                    partsInfoRow.PartsLayerCd = retWork.GoodsRateRank;
                    partsInfoRow.SeriesModel = retWork.SeriesModel;
                    partsInfoRow.CategorySignModel = retWork.CategorySignModel;
                    partsInfoRow.ExhaustGasSign = retWork.ExhaustGasSign;

                    partsInfoRow.NewPrtsNoWithHyphen = retWork.GoodsNo;
                    partsInfoRow.NewPrtsNoNoneHyphen = retWork.GoodsNoNoneHyphen;

                    partsInfoRow.FreSrchPrtPropNo = retWork.FreSrchPrtPropNo; // ���R�������i�ŗL�ԍ�

                    partsInfoDic[dicKey].PartsInfo.AddPartsInfoRow(partsInfoRow);
                    # endregion

                    //--------------------------------------------------
                    // ���i�}�X�^�e�[�u���֊i�[
                    //--------------------------------------------------

                    #region ���i�}�X�^�e�[�u���ɐݒ�
                    string partsNo = retWork.GoodsNo;
                    PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                        goodsTableDic[dicKey].FindByGoodsMakerCdGoodsNo(retWork.GoodsMakerCd, partsNo);
                    if (usrGoodsRow == null)
                    {
                        usrGoodsRow = goodsTableDic[dicKey].NewUsrGoodsInfoRow();

                        usrGoodsRow.BlGoodsCode = tbsPartsCode;
                        usrGoodsRow.GoodsKindCode = 0; // 0 : ����
                        usrGoodsRow.GoodsKind = (int)GoodsKind.Parent; // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                        usrGoodsRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        usrGoodsRow.GoodsMakerNm = partsInfoRow.CatalogPartsMakerNm;
                        //usrGoodsRow.GoodsMGroup = 0;
                        usrGoodsRow.GoodsRateRank = retWork.GoodsRateRank;
                        usrGoodsRow.GoodsNoNoneHyphen = partsInfoRow.ClgPrtsNoWithHyphen.Replace("-", "");
                        usrGoodsRow.QTY = retWork.PartsQty;
                        usrGoodsRow.GoodsNote1 = string.Empty;//retWork.StandardName; //�K�i
                        //usrGoodsRow.GoodsNote2 = "";
                        usrGoodsRow.GoodsSpecialNote = retWork.PartsOpNm;
                        usrGoodsRow.OfferDate = DateTime.MinValue; //retWork.OfferDate;

                        usrGoodsRow.OfferKubun = 0; // (0:���[�U�[�o�^�^1:�񋟏����ҏW�^2:�񋟗D�ǕҏW�^3:�񋟏����^4:�񋟗D�ǁj

                        //usrGoodsRow.TaxationDivCd = 0;
                        usrGoodsRow.GoodsNo = partsInfoRow.ClgPrtsNoWithHyphen;
                        usrGoodsRow.OfferDataDiv = 0; //1;

                        usrGoodsRow.GoodsName = retWork.GoodsName;
                        usrGoodsRow.GoodsNameKana = retWork.GoodsNameKana;
                        usrGoodsRow.GoodsOfrName = retWork.GoodsName; // ���i��
                        usrGoodsRow.GoodsOfrNameKana = retWork.GoodsNameKana;
                        usrGoodsRow.SearchPartsFullName = retWork.GoodsName;
                        usrGoodsRow.SearchPartsHalfName = retWork.GoodsNameKana;
                        usrGoodsRow.SrchPNmAcqrCarMkrCd = 0; //retWork.SrchPNmAcqrCarMkrCd;   // �����i���擾���[�J�[�R�[�h
                        usrGoodsRow.PartsPriceStDate = retWork.PriceStartDate;


                        # region [�񋟏���/�񋟗D�ǂ���Z�b�g]
                        if (!string.IsNullOrEmpty(retWork.GoodsNoFromGoods))
                        {
                            // ���[�U�[���i

                            if (retPartsInf != null)
                            {
                                // �����i�����X�V
                                usrGoodsRow.SearchPartsFullName = retPartsInf.PartsName;
                                usrGoodsRow.SearchPartsHalfName = retPartsInf.PartsNameKana;
                                usrGoodsRow.SrchPNmAcqrCarMkrCd = retPartsInf.SrchPNmAcqrCarMkrCd;
                            }
                            else if (retPrimParts != null)
                            {
                                usrGoodsRow.SearchPartsFullName = retPrimParts.SearchPartsFullName;
                                usrGoodsRow.SearchPartsHalfName = retPrimParts.SearchPartsHalfName;
                                usrGoodsRow.SrchPNmAcqrCarMkrCd = retPrimParts.JoinDestMakerCd;   // �����i���擾���[�J�[�R�[�h
                            }
                        }
                        else if (retPartsInf != null)
                        {
                            // ����
                            usrGoodsRow.GoodsNote1 = retPartsInf.StandardName; //�K�i
                            usrGoodsRow.OfferDate = retPartsInf.OfferDate; // �񋟓�
                            usrGoodsRow.SearchPartsFullName = retPartsInf.PartsName;
                            usrGoodsRow.SearchPartsHalfName = retPartsInf.PartsNameKana;
                            usrGoodsRow.SrchPNmAcqrCarMkrCd = retPartsInf.SrchPNmAcqrCarMkrCd;   // �����i���擾���[�J�[�R�[�h
                            usrGoodsRow.OfferKubun = 3; // (0:���[�U�[�o�^�^1:�񋟏����ҏW�^2:�񋟗D�ǕҏW�^3:�񋟏����^4:�񋟗D�ǁj
                        }
                        else if (retPrimParts != null)
                        {
                            // �D��
                            usrGoodsRow.OfferDate = retPrimParts.OfferDate; // �񋟓�
                            usrGoodsRow.SearchPartsFullName = retPrimParts.SearchPartsFullName;
                            usrGoodsRow.SearchPartsHalfName = retPrimParts.SearchPartsHalfName;
                            usrGoodsRow.SrchPNmAcqrCarMkrCd = retPrimParts.JoinDestMakerCd;   // �����i���擾���[�J�[�R�[�h
                            usrGoodsRow.OfferKubun = 4; // (0:���[�U�[�o�^�^1:�񋟏����ҏW�^2:�񋟗D�ǕҏW�^3:�񋟏����^4:�񋟗D�ǁj
                        }
                        # endregion

                        usrGoodsRow.FreSrchPrtPropNo = retWork.FreSrchPrtPropNo; // ���R�������i�ŗL�ԍ�

                        partsInfoRow.UsrGoodsInfoRowParentByUsrGoodsInfo_PartsInfo = usrGoodsRow;
                        goodsTableDic[dicKey].AddUsrGoodsInfoRow(usrGoodsRow);
                    }
                    # endregion

                    //--------------------------------------------------
                    // ���i�e�[�u���֊i�[
                    //--------------------------------------------------

                    # region [���i�e�[�u���ɐݒ�]
                    if (priceTableDic[dicKey].FindByGoodsMakerCdPriceStartDateGoodsNo(retWork.GoodsMakerCd,
                        retWork.PriceStartDate, retWork.GoodsNo) == null)
                    {
                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTableDic[dicKey].NewUsrGoodsPriceRow();

                        usrPriceRow.GoodsNo = retWork.GoodsNo;
                        usrPriceRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        double listPrice = retWork.ListPrice;
                        this.ReflectIsolIslandCall(0, retWork.GoodsMakerCd, 3, ref listPrice);
                        usrPriceRow.ListPrice = listPrice;
                        usrPriceRow.OpenPriceDiv = retWork.OpenPriceDiv;
                        usrPriceRow.PriceStartDate = retWork.PriceStartDate;
                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                        # region [�񋟏�������Z�b�g]
                        if (retPartsInf != null)
                        {
                            usrPriceRow.OfferDate = retPartsInf.PriceOfferDate;
                        }
                        # endregion

                        priceTableDic[dicKey].AddUsrGoodsPriceRow(usrPriceRow);
                    }
                    // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                    // UPD 2015/03/30 �S�̔z�M�V�X�e���e�X�g��Q��60�Ή� ----------------------------->>>>>
                    //if (ofrPriceTableDic[dicKey].FindByGoodsMakerCdPriceStartDateGoodsNo(retWork.GoodsMakerCd,
                    //    retWork.PriceStartDate, retWork.GoodsNo) == null)
                    // �񋟃f�[�^���擾�ł��鎞�A���񋟃f�[�^���i���e�[�u���ɊY�����鉿�i���f�[�^�����݂��Ȃ����ǉ�
                    // UPD 2015/03/31 SCM������ ���[�J�[��]�������i�Ή��@���R�������i���i���Ή�------------->>>>>
                    //if ((retPartsInf != null) && 
                    //    (ofrPriceTableDic[dicKey].FindByGoodsMakerCdPriceStartDateGoodsNo(retWork.GoodsMakerCd, retWork.PriceStartDate, retWork.GoodsNo) == null))
                    if ((retPartsInf != null) &&
                        (ofrPriceTableDic[dicKey].FindByGoodsMakerCdPriceStartDateGoodsNo(retWork.GoodsMakerCd, retPartsInf.PartsPriceStDate, retWork.GoodsNo) == null))
                    // UPD 2015/03/31 SCM������ ���[�J�[��]�������i�Ή��@���R�������i���i���Ή�-------------<<<<<
                    // UPD 2015/03/30 �S�̔z�M�V�X�e���e�X�g��Q��60�Ή� -----------------------------<<<<<
                    {
                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTableDic[dicKey].NewUsrGoodsPriceRow();

                        // UPD 2015/03/30 �S�̔z�M�V�X�e���e�X�g��Q��60�Ή� ----------------------------->>>>>
                        #region �폜
                        //usrPriceRow.GoodsNo = retWork.GoodsNo;
                        //usrPriceRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        //double listPrice = retWork.ListPrice;
                        //this.ReflectIsolIslandCall(0, retWork.GoodsMakerCd, 3, ref listPrice);
                        //usrPriceRow.ListPrice = listPrice;
                        //usrPriceRow.OpenPriceDiv = retWork.OpenPriceDiv;
                        //usrPriceRow.PriceStartDate = retWork.PriceStartDate;
                        //usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                        //# region [�񋟏�������Z�b�g]
                        //if (retPartsInf != null)
                        //{
                        //    usrPriceRow.OfferDate = retPartsInf.PriceOfferDate;
                        //}
                        //# endregion
                        #endregion

                        usrPriceRow.GoodsNo = retWork.GoodsNo;
                        usrPriceRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                        // �񋟏�������Z�b�g
                        usrPriceRow.OpenPriceDiv = retPartsInf.OpenPriceDiv;
                        usrPriceRow.PriceStartDate = retPartsInf.PartsPriceStDate;
                        double listPrice = retPartsInf.PartsPrice;
                        this.ReflectIsolIslandCall(0, retWork.GoodsMakerCd, 3, ref listPrice);
                        usrPriceRow.ListPrice = listPrice;
                        usrPriceRow.OfferDate = retPartsInf.PriceOfferDate;

                        ofrPriceTableDic[dicKey].AddUsrGoodsPriceRow(usrPriceRow);
                    }
                    // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
                    // ADD 2015/03/31 SCM������ ���[�J�[��]�������i�Ή��@���R�������i���i���Ή�------------->>>>>
                    // �񋟗D�ǃf�[�^�A�񋟗D�ǉ��i��񂪎擾�ł��鎞�A���񋟃f�[�^���i���e�[�u���ɊY�����鉿�i���f�[�^�����݂��Ȃ����ǉ�
                    if ((retPrimParts != null && retPrimPrice != null) &&
                        (ofrPriceTableDic[dicKey].FindByGoodsMakerCdPriceStartDateGoodsNo(retWork.GoodsMakerCd, retPrimPrice.PriceStartDate, retWork.GoodsNo) == null))
                    {

                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTableDic[dicKey].NewUsrGoodsPriceRow();
                        
                        usrPriceRow.GoodsNo = retWork.GoodsNo;
                        usrPriceRow.GoodsMakerCd = retWork.GoodsMakerCd;
                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                        // �񋟗D�ǂ���Z�b�g
                        usrPriceRow.OpenPriceDiv = retPrimPrice.OpenPriceDiv;
                        usrPriceRow.PriceStartDate = retPrimPrice.PriceStartDate;
                        usrPriceRow.ListPrice = retPrimPrice.NewPrice;
                        usrPriceRow.OfferDate = retPrimPrice.OfferDate;

                        ofrPriceTableDic[dicKey].AddUsrGoodsPriceRow(usrPriceRow);
                    }
                    // ADD 2015/03/31 SCM������ ���[�J�[��]�������i�Ή��@���R�������i���i���Ή�-------------<<<<<
                    # endregion

                    //--------------------------------------------------
                    // ���i�֘A�^�����e�[�u���֊i�[
                    //--------------------------------------------------

                    #region ���i�֘A�^�����ݒ�
                    PartsInfoDataSet.ModelPartsDetailDataTable modelInfo = partsInfoDic[dicKey].ModelPartsDetail;

                    string select = string.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}' AND {6} = '{7}' ",
                                                   carInfoDataSet.CarModelInfo.MakerCodeColumn.ColumnName, retWork.MakerCode,
                                                   carInfoDataSet.CarModelInfo.ModelCodeColumn.ColumnName, retWork.ModelCode,
                                                   carInfoDataSet.CarModelInfo.ModelSubCodeColumn.ColumnName, retWork.ModelSubCode,
                                                   carInfoDataSet.CarModelInfo.FullModelColumn.ColumnName, retWork.FullModel);

                    PMKEN01010E.CarModelInfoRow[] carModelInfoRows = (PMKEN01010E.CarModelInfoRow[])carInfoDataSet.CarModelInfo.Select(select);

                    //���q��񁨕��i�ڍׁi�^�����j�ݒ�
                    for (int ix = 0; ix < carModelInfoRows.Length; ix++)
                    {
                        PartsInfoDataSet.ModelPartsDetailRow modelPartsDetailRow = modelInfo.NewModelPartsDetailRow();

                        modelPartsDetailRow.PartsUniqueNo = 0;
                        modelPartsDetailRow.PartsMakerCd = retWork.GoodsMakerCd;
                        modelPartsDetailRow.PartsNo = retWork.GoodsNo;

                        modelPartsDetailRow.FullModelFixedNo = carModelInfoRows[ix].FullModelFixedNo;
                        modelPartsDetailRow.DoorCount = carModelInfoRows[ix].DoorCount;
                        modelPartsDetailRow.BodyName = carModelInfoRows[ix].BodyName;
                        modelPartsDetailRow.ModelGradeNm = carModelInfoRows[ix].ModelGradeNm;
                        modelPartsDetailRow.EngineModelNm = carModelInfoRows[ix].EngineModelNm;
                        modelPartsDetailRow.EngineDisplaceNm = carModelInfoRows[ix].EngineDisplaceNm;
                        modelPartsDetailRow.EDivNm = carModelInfoRows[ix].EDivNm;
                        modelPartsDetailRow.TransmissionNm = carModelInfoRows[ix].TransmissionNm;
                        modelPartsDetailRow.ShiftNm = carModelInfoRows[ix].ShiftNm;
                        modelPartsDetailRow.WheelDriveMethodNm = carModelInfoRows[ix].WheelDriveMethodNm;
                        modelPartsDetailRow.AddiCarSpec1 = carModelInfoRows[ix].AddiCarSpec1;
                        modelPartsDetailRow.AddiCarSpec2 = carModelInfoRows[ix].AddiCarSpec2;
                        modelPartsDetailRow.AddiCarSpec3 = carModelInfoRows[ix].AddiCarSpec3;
                        modelPartsDetailRow.AddiCarSpec4 = carModelInfoRows[ix].AddiCarSpec4;
                        modelPartsDetailRow.AddiCarSpec5 = carModelInfoRows[ix].AddiCarSpec5;
                        modelPartsDetailRow.AddiCarSpec6 = carModelInfoRows[ix].AddiCarSpec6;

                        modelInfo.AddModelPartsDetailRow(modelPartsDetailRow);
                    }
                    if (carModelInfoRows.Length > 0)
                    {
                        modelInfo.Columns[modelInfo.AddiCarSpec1Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle1;
                        modelInfo.Columns[modelInfo.AddiCarSpec2Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle2;
                        modelInfo.Columns[modelInfo.AddiCarSpec3Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle3;
                        modelInfo.Columns[modelInfo.AddiCarSpec4Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle4;
                        modelInfo.Columns[modelInfo.AddiCarSpec5Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle5;
                        modelInfo.Columns[modelInfo.AddiCarSpec6Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle6;
                    }
                    #endregion
                }
            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        /// <summary>
        /// ��֏��ɂ��f�[�^�e�[�u���X�V����
        /// </summary>
        /// <param name="list"></param>
        private void ReflectTableByPartsSubst( ArrayList list )
        {
            foreach ( PartsSubstWork wkInf in list )
            {
                // ��֌����R�[�h�i�X�V�Ώہj
                PartsInfoDataSet.PartsInfoRow row = partsInfo.PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen( wkInf.CatalogPartsMakerCd, wkInf.OldPartsNoWithHyphen );

                if ( row != null )
                {
                    // ��֐�i�Ԃ�����������
                    row.NewPrtsNoWithHyphen = wkInf.NewPartsNoWithHyphen;
                    row.NewPrtsNoNoneHyphen = wkInf.NewPrtsNoNoneHyphen;
                }
            }
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ��֏��ɂ��f�[�^�e�[�u���X�V����
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        private void ReflectTableByPartsSubst(ArrayList list, int key)
        {
            foreach (PartsSubstWork wkInf in list)
            {
                // ��֌����R�[�h�i�X�V�Ώہj
                PartsInfoDataSet.PartsInfoRow row = partsInfoDic[key].PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(wkInf.CatalogPartsMakerCd, wkInf.OldPartsNoWithHyphen);

                if (row != null)
                {
                    // ��֐�i�Ԃ�����������
                    row.NewPrtsNoWithHyphen = wkInf.NewPartsNoWithHyphen;
                    row.NewPrtsNoNoneHyphen = wkInf.NewPrtsNoNoneHyphen;
                }
            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        /// <summary>
        /// ���R�������i�������ʃf�B�N�V���i���p�L�[��������
        /// </summary>
        /// <param name="makerCode"></param>
        /// <param name="goodsNo"></param>
        /// <returns></returns>
        private string CreateFreeSearchRetDicKey( int makerCode, string goodsNo )
        {
            // ���\���̓����g���ƒᑬ�Ȃ̂ŁA������ŃL�[�Ƃ���B
            //   ���R�������i����񋟕��ior���i�}�X�^�ւ̌��ѕt���͕i�ԁEҰ�����ނ̂݁B
            return makerCode.ToString( "0000" ) + "," + goodsNo.TrimEnd();
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ���R�������i�������ʃf�B�N�V���i���p�L�[��������
        /// </summary>
        /// <param name="key"></param>
        /// <param name="makerCode"></param>
        /// <param name="goodsNo"></param>
        /// <returns></returns>
        private string CreateFreeSearchRetDicKey(int key, int makerCode, string goodsNo)
        {
            // ���\���̓����g���ƒᑬ�Ȃ̂ŁA������ŃL�[�Ƃ���B
            //   ���R�������i����񋟕��ior���i�}�X�^�ւ̌��ѕt���͌���key�E�i�ԁEҰ�����ނ̂݁B
            return key.ToString("00") + makerCode.ToString("0000") + "," + goodsNo.TrimEnd();
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        /// <summary>
        /// 
        /// </summary>
        /// <param name="retObj"></param>
        /// <returns></returns>
        private ArrayList GetRetList( object retObj )
        {
            ArrayList result = null;

            try
            {
                if ( retObj != null )
                {
                    CustomSerializeArrayList retCustList = (retObj as CustomSerializeArrayList);

                    if ( retCustList.Count != 0 )
                    {
                        result = (ArrayList)retCustList[0];
                    }
                }
            }
            catch
            {
            }

            return result;
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        ///  �z��擾
        /// </summary>
        /// <param name="retObj"></param>
        /// <param name="listIndex"></param>
        /// <returns></returns>
        private ArrayList GetRetList(object retObj, int listIndex)
        {
            ArrayList result = null;

            try
            {
                if (retObj != null)
                {
                    CustomSerializeArrayList retCustList = (retObj as CustomSerializeArrayList);

                    if (retCustList.Count != 0)
                    {
                        result = (ArrayList)retCustList[listIndex];
                    }
                }
            }
            catch
            {
            }

            return result;
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        /// <summary>
        /// ���i�擾����
        /// </summary>
        /// <param name="priceList"></param>
        /// <returns></returns>
        /// <remarks>���i���X�g����Y���P���𒊏o����</remarks>
        private OfferJoinPriceRetWork GetPrimePrice( List<OfferJoinPriceRetWork> priceList )
        {
            // ���t�~���Ń\�[�g
            priceList.Sort( new OfferJoinPriceRetWorkDescComparer() );

            if ( priceList.Count > 0 )
            {
                // �擪�P����Ԃ�
                return priceList[0];
            }

            return null;
        }

        /// <summary>
        /// �񋟌������i�@��r�N���X�i�~���\�[�g�p�j
        /// </summary>
        private class OfferJoinPriceRetWorkDescComparer : Comparer<OfferJoinPriceRetWork>
        {
            /// <summary>
            /// �񋟌������i�@��r����
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public override int Compare( OfferJoinPriceRetWork x, OfferJoinPriceRetWork y )
            {
                return y.PriceStartDate.CompareTo( x.PriceStartDate );
            }
        }

        /// <summary>
        /// ���t����yyyymm�擾
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private int GetLongDateYM( DateTime dateTime )
        {
            if ( dateTime != DateTime.MinValue )
            {
                // YYYYMM
                return (dateTime.Year * 100) + (dateTime.Month);
            }
            else
            {
                return 0;
            }
        }
        // --- ADD m.suzuki 2010/04/28 ----------<<<<<
        
        // 2009/11/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        ///// <summary>
        ///// ����������
        ///// </summary>
        ///// <param name="enterpriseCd">��ƃR�[�h</param>
        ///// <param name="makerCd">�D�Ǖ��i���[�J�[�R�[�h</param>
        ///// <param name="partsNo">�D�Ǖ��i�i��</param>
        ///// <param name="retPartsInfo">���i��������</param>
        ///// <returns></returns>
        //public int GetJoinSrcParts(string enterpriseCd, int makerCd, string partsNo, out PartsInfoDataSet retPartsInfo)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

        //    partsInfo.Clear();
        //    carInfoDataSet = null;
        //    customerCarInfo = null;

        //    status = GetJoinSrcPartsProc(enterpriseCd, makerCd, partsNo);

        //    SetUsrGoodsKind();
        //    partsInfo.AcceptChanges();
        //    retPartsInfo = partsInfo;
        //    return status;
        //}

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="enterpriseCd">��ƃR�[�h</param>
        /// <param name="makerCd">�D�Ǖ��i���[�J�[�R�[�h</param>
        /// <param name="partsNo">�D�Ǖ��i�i��</param>
        /// <param name="retPartsInfo">���i��������</param>
        /// <returns></returns>
        public int GetJoinSrcParts(string enterpriseCd, int makerCd, string partsNo, out PartsInfoDataSet retPartsInfo)
        {
            return GetJoinSrcParts(0, enterpriseCd, makerCd, partsNo, out retPartsInfo);
        }

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="mode">���[�h(0:�񋟉��i�擾���� 1:�񋟉��i�擾�L��)</param>
        /// <param name="enterpriseCd">��ƃR�[�h</param>
        /// <param name="makerCd">�D�Ǖ��i���[�J�[�R�[�h</param>
        /// <param name="partsNo">�D�Ǖ��i�i��</param>
        /// <param name="retPartsInfo">���i��������</param>
        /// <returns></returns>
        public int GetJoinSrcParts(int mode, string enterpriseCd, int makerCd, string partsNo, out PartsInfoDataSet retPartsInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            partsInfo.Clear();
            carInfoDataSet = null;
            customerCarInfo = null;

            status = GetJoinSrcPartsProc(mode, enterpriseCd, makerCd, partsNo);

            SetUsrGoodsKind();
            partsInfo.AcceptChanges();
            retPartsInfo = partsInfo;
            return status;
        }
        // 2009/11/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// ���i�ꊇ�o�^����
        /// </summary>
        /// <param name="makerCd">���[�J�[�R�[�h�i�K�{�j</param>
        /// <param name="partsNo">�i��(BL���i�Ԃ����ꂩ�K�{)</param>
        /// <param name="bl">BL�R�[�h(BL���i�Ԃ����ꂩ�K�{)</param>
        /// <param name="maxCnt">�擾����</param>
        /// <param name="sectionCode">���_�R�[�h(�D�ǐݒ�p)</param>
        /// <param name="prmSettingUWorkList">�D�ǐݒ胊�X�g</param>
        /// <param name="retPartsInfo"></param>
        /// <returns></returns>
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 DEL
        //public int SearchOfrParts(int makerCd, string partsNo, int bl, int maxCnt, out PartsInfoDataSet retPartsInfo)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
        public int SearchOfrParts( int makerCd, string partsNo, int bl, int maxCnt, string sectionCode, List<PrmSettingUWork> prmSettingUWorkList, out PartsInfoDataSet retPartsInfo )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            partsInfo.Clear();
            carInfoDataSet = null;
            customerCarInfo = null;

            PrtsSrchCndWork InPara = new PrtsSrchCndWork();
            InPara.MakerCode = makerCd;
            InPara.BLCode = bl;
            InPara.PrtsNo = partsNo;
            InPara.MaxCnt = maxCnt;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 DEL
            //status = SearchOfrPartsProc(InPara);
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
            status = SearchOfrPartsProc( InPara, sectionCode, prmSettingUWorkList );
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD

            partsInfo.AcceptChanges();
            retPartsInfo = partsInfo;
            return status;
        }
        # endregion

        # region [ 1. �a�k�������C�� ]
        /// <summary>
        /// �a�k�������C��
        /// </summary>
        /// <param name="partsSearchUIData">��������</param>
        /// <param name="normalSearchExclude"></param>
        /// <returns></returns>
        // --- UPD m.suzuki 2010/04/28 ---------->>>>>
        //private int BlSearchMain(PartsSearchUIData partsSearchUIData)
        private int BlSearchMain( PartsSearchUIData partsSearchUIData, bool normalSearchExclude )
        // --- UPD m.suzuki 2010/04/28 ----------<<<<<
        {
            //>>>2010/03/29
            #region ��^��������
            // --- UPD m.suzuki 2010/04/28 ---------->>>>>
            //// ��^�_��Ȃ��Ŏw��̃��[�J�[����^�̏ꍇ�͌��������A0���Ƃ���B
            //if ((customerCarInfo != null) && (customerCarInfo.Count != 0))
            //{
            //    if (customerCarInfo[0].MakerCode != 0 && searchPrtCtlAcs.BigCarOfferDiv == 0 && bigMakerList.Contains(customerCarInfo[0].MakerCode))
            //        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            //}

            bool blSearchFlag = true;

            // ��^�_��Ȃ��Ŏw��̃��[�J�[����^�̏ꍇ�͌��������A0���Ƃ���B
            if ( (customerCarInfo != null) && (customerCarInfo.Count != 0) )
            {
                if ( customerCarInfo[0].MakerCode != 0 && searchPrtCtlAcs.BigCarOfferDiv == 0 && bigMakerList.Contains( customerCarInfo[0].MakerCode ) )
                {
                    if ( _freeSearchPartsSRetDic == null || _freeSearchPartsSRetDic.Count == 0 )
                    {
                        // ���R�������Y��������΁A�����ŏI��
                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    else
                    {
                        // ���R�����͊Y�������菃���a�k�͊Y������������
                        blSearchFlag = false;
                    }
                }
            }
            // --- UPD m.suzuki 2010/04/28 ----------<<<<<            
            #endregion
            //<<<2010/03/29

            # region �ϐ��̏�����
            int status = 0;

            GetPartsInfPara para = new GetPartsInfPara();
            # endregion

            // --- ADD m.suzuki 2010/04/28 ---------->>>>>
            if ( !blSearchFlag || normalSearchExclude )
            {
                para.NormalSearchExclude = true; // �ʏ�̂a�k�������s��Ȃ�
            }
            // --- ADD m.suzuki 2010/04/28 ----------<<<<<


            # region [ �����E��� ] �a�k�R�[�h����
            //�a�k�R�[�h�ݒ�
            para.TbsPartsCode = partsSearchUIData.TbsPartsCode;

            //�t���^���Œ�ԍ�
            // UPD 2013/02/14 SCM��Q��10354�Ή� 2013/03/06�z�M--------------------------------------------------->>>>>
            //para.FullModelFixedNo = carInfoDataSet.CarModelInfo.GetFullModelFixedNoArray(true);
            // UPD 2013/02/22 2013/03/13�z�M �V�X�e���e�X�g��Q��121�Ή� ----------------------------->>>>>
            //para.FullModelFixedNo = carInfoDataSet.CarModelInfo.GetFullModelFixedNoArray(true, carInfoDataSet.CarModelUIData[0].FrameNo, carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput);

            string frameNo = "";
            int produceTypeOfYearInput = 0;

            if (carInfoDataSet != null && carInfoDataSet.CarModelUIData.Count != 0)
            {
                frameNo = carInfoDataSet.CarModelUIData[0].FrameNo;
                produceTypeOfYearInput = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
            }
            para.FullModelFixedNo = carInfoDataSet.CarModelInfo.GetFullModelFixedNoArray(true, frameNo, produceTypeOfYearInput);
            // UPD 2013/02/22 2013/03/13�z�M �V�X�e���e�X�g��Q��121�Ή� -----------------------------<<<<<
            // UPD 2013/02/14 SCM��Q��10354�Ή� ---------------------------------------------------<<<<<

            //�ޕʔԍ�
            para.CategoryNo = carInfoDataSet.CarModelUIData[0].CategoryNo;
            //�^���w��ԍ�
            para.ModelDesignationNo = carInfoDataSet.CarModelUIData[0].ModelDesignationNo;
            //���[�J�[�R�[�h
            para.MakerCode = customerCarInfo[0].MakerCode;
            //�Ԏ�R�[�h
            para.ModelCode = customerCarInfo[0].ModelCode;
            //�Ԏ�T�u�R�[�h
            para.ModelSubCode = customerCarInfo[0].ModelSubCode;

            if (carInfoDataSet.CarModelUIData.Count > 0)
            {
                // 2009.01.28 >>>
                //if (carInfoDataSet.CarModelUIData[0].ProduceFrameNoInput > 0)
                //    para.ChassisNo = carInfoDataSet.CarModelUIData[0].ProduceFrameNoInput.ToString();
                if (carInfoDataSet.CarModelUIData[0].SearchFrameNo > 0)
                    para.ChassisNo = carInfoDataSet.CarModelUIData[0].FrameNo;
                // 2009.01.28 <<<
                if (carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput > 0)
                    para.ProduceTypeOfYear = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
            }

            para.SearchType = (int)partsSearchUIData.SearchType;
            if (partsSearchUIData.SearchCntSetWork.SubstCondDivCd == 0) // ��ւȂ�
                para.NoSubst = 1;
            else                                                        // ��ւ���i�݌ɂ���E�݌ɖ����j
                para.NoSubst = 0;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/18 ADD
            para.PriceDate = partsSearchUIData.PriceDate;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/18 ADD
            // --- ADD m.suzuki 2011/05/18 ---------->>>>>
            para.TbsPartsCdDerivedNo = partsSearchUIData.TbsPartsCdDerivedNo; // BL�R�[�h�}��
            // --- ADD m.suzuki 2011/05/18 ----------<<<<<

            // --- ADD 2013/03/27 ---------->>>>>
            // ��ʂ�VIN������ƃ��[�J�R�[�h�ɉ����ĕ��i�i��������ǉ�
            AddPartsNarrowingInfoFromVinCode(ref para);
            // --- ADD 2013/03/27 ----------<<<<<

            //�������� [ �a�k�R�[�h���������[�g���� ]
            status = GetCatalogPartsInf(para);

            // --- UPD m.suzuki 2010/04/28 ---------->>>>>
            //if ( status != 0 )
            //{
            //    return (status);
            //}

            _normalSearchStatus = status;

            // ���R�������i�����������a�k���Y����������΂����ŏI��
            if ( _freeSearchPartsSRetDic == null || _freeSearchPartsSRetDic.Count == 0 )
            {
                if ( status != 0 )
                {
                    return (status);
                }
            }
            // --- UPD m.suzuki 2010/04/28 ----------<<<<<
            # endregion

            # region [ �����E�Z�b�g ] �D�Ǖ��i���������������i�Ԃ��j�d�x�ɂ��ėD�Ǖi�Ԃ�������
            bool primeSubstFlg = true;
            //if (partsSearchUIData.SearchCntSetWork.PrmSubstCondDivCd != 0) // �D�Ǒ�ւȂ��͍ŐV�i�Ԃɂ��邽�߁A��֎擾�K�v
            //    primeSubstFlg = true;
            // --- UPD m.suzuki 2011/05/18 ---------->>>>>
            //status = GetPrimePartsInf( primeSubstFlg );
            status = GetPrimePartsInf( primeSubstFlg, para );
            // --- UPD m.suzuki 2011/05/18 ----------<<<<<
            if (status != 0)
            {
                return (status);
            }
            # endregion

            #region [ ���[�U�[���� ]
            //���[�U�[��������
            // --- UPD m.suzuki 2011/05/18 ---------->>>>>
            //status = GetUsrGoodsJoinInf(partsSearchUIData);
            status = GetUsrGoodsJoinInf( partsSearchUIData, para );
            // --- UPD m.suzuki 2011/05/18 ----------<<<<<
            #endregion

            #region [ ���[�U�[OEM�Ή� ]
            if (partsSearchUIData.SearchCntSetWork.SubstApplyDivCd == 2) // ��֓K�p�S�āF���[�U�[�o�^�i�Ɋւ��čX�ɒ񋟌���
            {
                status = UserOEMSearch(partsSearchUIData);
            }
            #endregion

            // --- ADD 2012/12/10 Y.Wakita ---------->>>>>
            #region [ ���[�U�[���� ]
            // �񋟃f�[�^���܂߁A������x�쐬
            status = GetUsrGoodsJoinInf(partsSearchUIData, para);
            #endregion
            // --- ADD 2012/12/10 Y.Wakita ----------<<<<<

            if (partsInfo.UsrGoodsInfo.Count == 0)
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            return (status);
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// �a�k�������C��
        /// </summary>
        /// <param name="partsSearchUIDataDic">��������</param>
        /// <param name="normalSearchExclude"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : 2018/04/05  30757 ���X�؁@�M�p</br>
        /// <br>�Ǘ��ԍ�    : 11470007-00</br>
        /// <br>            : NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// <br>              ���������ւ�BL���ꕔ�i�R�[�h�̒ǉ�</br>
        /// </remarks>
        private int BlSearchMain( Dictionary<int, PartsSearchUIData> partsSearchUIDataDic, bool normalSearchExclude )
        {
            #region ��^��������

            bool blSearchFlag = true;

            // ��^�_��Ȃ��Ŏw��̃��[�J�[����^�̏ꍇ�͌��������A0���Ƃ���B
            if ((customerCarInfo != null) && (customerCarInfo.Count != 0))
            {
                if (customerCarInfo[0].MakerCode != 0 && searchPrtCtlAcs.BigCarOfferDiv == 0 && bigMakerList.Contains(customerCarInfo[0].MakerCode))
                {
                    if (_freeSearchPartsSRetDic == null || _freeSearchPartsSRetDic.Count == 0)
                    {
                        // ���R�������Y��������΁A�����ŏI��
                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    else
                    {
                        // ���R�����͊Y�������菃���a�k�͊Y������������
                        blSearchFlag = false;
                    }
                }
            }
            #endregion

            # region �ϐ��̏�����
            int status = 0;
            Dictionary<int, GetPartsInfPara> paraDic = new Dictionary<int, GetPartsInfPara>();
            # endregion


            foreach (int key in partsSearchUIDataDic.Keys)
            {
                GetPartsInfPara para = new GetPartsInfPara();
                if (!blSearchFlag || normalSearchExclude)
                {
                    para.NormalSearchExclude = true; // �ʏ�̂a�k�������s��Ȃ�
                }

            # region [ �����E��� ] �a�k�R�[�h����

                //�t���^���Œ�ԍ�
                string frameNo = "";
                int produceTypeOfYearInput = 0;

                if (carInfoDataSet != null && carInfoDataSet.CarModelUIData.Count != 0)
                {
                    frameNo = carInfoDataSet.CarModelUIData[0].FrameNo;
                    produceTypeOfYearInput = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
                    //�ޕʔԍ�
                    para.CategoryNo = carInfoDataSet.CarModelUIData[0].CategoryNo;
                    //�^���w��ԍ�
                    para.ModelDesignationNo = carInfoDataSet.CarModelUIData[0].ModelDesignationNo;
                }
                para.FullModelFixedNo = carInfoDataSet.CarModelInfo.GetFullModelFixedNoArray(true, frameNo, produceTypeOfYearInput);

                if (customerCarInfo != null && customerCarInfo.Count != 0)
                {
                    //���[�J�[�R�[�h
                    para.MakerCode = customerCarInfo[0].MakerCode;
                    //�Ԏ�R�[�h
                    para.ModelCode = customerCarInfo[0].ModelCode;
                    //�Ԏ�T�u�R�[�h
                    para.ModelSubCode = customerCarInfo[0].ModelSubCode;
                }

                if (carInfoDataSet.CarModelUIData.Count > 0)
                {
                    if (carInfoDataSet.CarModelUIData[0].SearchFrameNo > 0)
                        para.ChassisNo = carInfoDataSet.CarModelUIData[0].FrameNo;
                    if (carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput > 0)
                        para.ProduceTypeOfYear = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
                }

                //�a�k�R�[�h�ݒ�
                para.TbsPartsCode = partsSearchUIDataDic[key].TbsPartsCode;

                para.SearchType = (int)partsSearchUIDataDic[key].SearchType;
                if (partsSearchUIDataDic[key].SearchCntSetWork.SubstCondDivCd == 0) // ��ւȂ�
                    para.NoSubst = 1;
                else                                                        // ��ւ���i�݌ɂ���E�݌ɖ����j
                    para.NoSubst = 0;

                para.PriceDate = partsSearchUIDataDic[key].PriceDate;
                para.TbsPartsCdDerivedNo = partsSearchUIDataDic[key].TbsPartsCdDerivedNo; // BL�R�[�h�}��

                // ��ʂ�VIN������ƃ��[�J�R�[�h�ɉ����ĕ��i�i��������ǉ�
                AddPartsNarrowingInfoFromVinCode(ref para);

                // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
                // BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�̐ݒ�
                para.BlUtyPtThCd = partsSearchUIDataDic[key].BlUtyPtThCd;
                // BL���ꕔ�i�T�u�R�[�h�̐ݒ�
                para.BlUtyPtSbCd = partsSearchUIDataDic[key].BlUtyPtSbCd;
                // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<

                paraDic.Add(key, para);
            }

            //�������� [ �a�k�R�[�h���������[�g���� ]
            status = GetCatalogPartsInf(paraDic);

            _normalSearchStatus = status;

            // ���R�������i�����������a�k���Y����������΂����ŏI��
            if (_freeSearchPartsSRetDic == null || _freeSearchPartsSRetDic.Count == 0)
            {
                if (status != 0)
                {
                    return (status);
                }
            }

            # endregion

            # region [ �����E�Z�b�g ] �D�Ǖ��i���������������i�Ԃ��j�d�x�ɂ��ėD�Ǖi�Ԃ�������

            bool primeSubstFlg = true;

            status = GetPrimePartsInf(primeSubstFlg, paraDic);
            if (status != 0)
            {
                return (status);
            }
            # endregion

            #region [ ���[�U�[���� ]
            //���[�U�[��������
            status = GetUsrGoodsJoinInf(partsSearchUIDataDic, paraDic);
            #endregion

            #region [ ���[�U�[OEM�Ή� ]
            status = UserOEMSearch(partsSearchUIDataDic);
            #endregion

            #region [ ���[�U�[���� ]
            // �񋟃f�[�^���܂߁A������x�쐬
            status = GetUsrGoodsJoinInf(partsSearchUIDataDic, paraDic);
            #endregion

            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            foreach (PartsInfoDataSet partsInfo in partsInfoDic.Values)
            {
                if (partsInfo.UsrGoodsInfo.Count != 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }
            return (status);
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        # region [ 2. �D�ǂa�k�������C�� ]
        /// <summary>
        /// �D�ǂa�k�������C��
        /// </summary>
        /// <param name="partsSearchUIData">��������</param>
        /// <returns></returns>
        private int PrimeBlSearchMain(PartsSearchUIData partsSearchUIData)
        {
            //>>>2010/03/29
            // ��^�_��Ȃ��Ŏw��̃��[�J�[����^�̏ꍇ�͌��������A0���Ƃ���B
            if ((customerCarInfo != null) && (customerCarInfo.Count != 0))
            {
                if (customerCarInfo[0].MakerCode != 0 && searchPrtCtlAcs.BigCarOfferDiv == 0 && bigMakerList.Contains(customerCarInfo[0].MakerCode))
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            //<<<2010/03/29

            int status = 0;
            ArrayList RetParts;
            ArrayList retPartsPrice;
            ArrayList RetSetParts;
            ArrayList RetSetPartsPrice;

            OfferPrimeBlSearchCondWork para = new OfferPrimeBlSearchCondWork();

            //�a�k�R�[�h�ݒ�
            para.TbsPartsCode = partsSearchUIData.TbsPartsCode;
            // �I���W�i�����i�����ɂ̓t���^���Œ�ԍ��ł̌������o���Ȃ����߁A
            // �����Ă���Ԃ̏����o���邩����g���Č�������B
            if (customerCarInfo != null && customerCarInfo.Count > 0)
            {
                para.MakerCode = customerCarInfo[0].MakerCode;
                para.ModelCode = customerCarInfo[0].ModelCode;
                para.ModelSubCode = customerCarInfo[0].ModelSubCode;
                para.SeriesModel = customerCarInfo[0].SeriesModel;
                if (carInfoDataSet.CarModelUIData.Count > 0)
                {
                    // 2009.01.28 >>>
                    //para.ProduceFrameNo = carInfoDataSet.CarModelUIData[0].ProduceFrameNoInput;
                    para.ProduceFrameNo = carInfoDataSet.CarModelUIData[0].SearchFrameNo;
                    // 2009.01.28 <<<
                    para.ProduceTypeOfYear = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
                }
                // [�i���p] �^���N�����k����
                for (int i = 0; i < carInfoDataSet.CarModelInfo.Count; i++)
                {
                    if (para.CategorySignModel.Contains(carInfoDataSet.CarModelInfo[i].CategorySignModel) == false)
                        para.CategorySignModel.Add(carInfoDataSet.CarModelInfo[i].CategorySignModel);

                    //if (carInfoDataSet.CarModelInfo[i].StProduceTypeOfYear != 0
                    //    && carInfoDataSet.CarModelInfo[i].EdProduceTypeOfYear != 999999)
                    //{
                    //    bool flg = false;
                    //    for (int j = 0; j < para.StProduceTypeOfYear.Count; j++)
                    //    {
                    //        if (carInfoDataSet.CarModelInfo[i].StProduceTypeOfYear > para.EdProduceTypeOfYear[j]
                    //             || carInfoDataSet.CarModelInfo[i].EdProduceTypeOfYear < para.StProduceTypeOfYear[j])
                    //            continue; // �����͈͊O
                    //        if (carInfoDataSet.CarModelInfo[i].StProduceTypeOfYear >= para.StProduceTypeOfYear[j]) 
                    //        { // �N���͈͂��d�Ȃ镔���������āA
                    //            if (carInfoDataSet.CarModelInfo[i].EdProduceTypeOfYear > para.EdProduceTypeOfYear[j])
                    //            { // �I���������o������ꍇ�����͈͂�L�΂��B
                    //                para.EdProduceTypeOfYear[j] = carInfoDataSet.CarModelInfo[i].EdProduceTypeOfYear;
                    //            }
                    //            flg = true;
                    //            break;
                    //        }
                    //        if (carInfoDataSet.CarModelInfo[i].EdProduceTypeOfYear <= para.EdProduceTypeOfYear[j])
                    //        {
                    //            if (carInfoDataSet.CarModelInfo[i].StProduceTypeOfYear < para.StProduceTypeOfYear[j])
                    //            {
                    //                para.StProduceTypeOfYear[j] = carInfoDataSet.CarModelInfo[i].StProduceTypeOfYear;
                    //            }
                    //            flg = true;
                    //            break;
                    //        }
                    //    }
                    //    if (flg == false) // �����͈͂ň��k�ł��Ȃ��N���͈͂͐V���ɒǉ�����
                    //    {
                    //        para.StProduceTypeOfYear.Add(carInfoDataSet.CarModelInfo[i].StProduceTypeOfYear);
                    //        para.EdProduceTypeOfYear.Add(carInfoDataSet.CarModelInfo[i].EdProduceTypeOfYear);
                    //    }
                    //}

                    //if (carInfoDataSet.CarModelInfo[i].StProduceFrameNo != 0
                    //    && carInfoDataSet.CarModelInfo[i].EdProduceFrameNo != 99999999)
                    //{
                    //    bool flg = false;
                    //    for (int j = 0; j < para.StProduceFrameNo.Count; j++)
                    //    {
                    //        if (carInfoDataSet.CarModelInfo[i].StProduceFrameNo > para.EdProduceFrameNo[j]
                    //             || carInfoDataSet.CarModelInfo[i].EdProduceFrameNo < para.StProduceFrameNo[j])
                    //            continue; // �����͈͊O
                    //        if (carInfoDataSet.CarModelInfo[i].StProduceFrameNo >= para.StProduceFrameNo[j])
                    //        { // �ԑ�ԍ��͈͂��d�Ȃ镔���������āA
                    //            if (carInfoDataSet.CarModelInfo[i].EdProduceFrameNo > para.EdProduceFrameNo[j])
                    //            { // �I���������o������ꍇ�����͈͂�L�΂��B
                    //                para.EdProduceFrameNo[j] = carInfoDataSet.CarModelInfo[i].EdProduceFrameNo;
                    //            }
                    //            flg = true;
                    //            break;
                    //        }
                    //        if (carInfoDataSet.CarModelInfo[i].EdProduceFrameNo <= para.EdProduceFrameNo[j])
                    //        {
                    //            if (carInfoDataSet.CarModelInfo[i].StProduceFrameNo < para.StProduceFrameNo[j])
                    //            {
                    //                para.StProduceFrameNo[j] = carInfoDataSet.CarModelInfo[i].StProduceFrameNo;
                    //            }
                    //            flg = true;
                    //            break;
                    //        }
                    //    }
                    //    if (flg == false) // �����͈͂ň��k�ł��Ȃ��ԑ�ԍ��͈͂͐V���ɒǉ�����
                    //    {
                    //        para.StProduceFrameNo.Add(carInfoDataSet.CarModelInfo[i].StProduceFrameNo);
                    //        para.EdProduceFrameNo.Add(carInfoDataSet.CarModelInfo[i].EdProduceFrameNo);
                    //    }
                    //}

                    if (para.ModelGradeNm.Contains(carInfoDataSet.CarModelInfo[i].ModelGradeNm) == false)
                        para.ModelGradeNm.Add(carInfoDataSet.CarModelInfo[i].ModelGradeNm);

                    if (para.BodyName.Contains(carInfoDataSet.CarModelInfo[i].BodyName) == false)
                        para.BodyName.Add(carInfoDataSet.CarModelInfo[i].BodyName);

                    if (para.DoorCount.Contains(carInfoDataSet.CarModelInfo[i].DoorCount) == false)
                        para.DoorCount.Add(carInfoDataSet.CarModelInfo[i].DoorCount);

                    if (para.EDivNm.Contains(carInfoDataSet.CarModelInfo[i].EDivNm) == false)
                        para.EDivNm.Add(carInfoDataSet.CarModelInfo[i].EDivNm);

                    if (para.EngineDisplaceNm.Contains(carInfoDataSet.CarModelInfo[i].EngineDisplaceNm) == false)
                        para.EngineDisplaceNm.Add(carInfoDataSet.CarModelInfo[i].EngineDisplaceNm);

                    if (para.EngineModelNm.Contains(carInfoDataSet.CarModelInfo[i].EngineModelNm) == false)
                        para.EngineModelNm.Add(carInfoDataSet.CarModelInfo[i].EngineModelNm);

                    if (para.ShiftNm.Contains(carInfoDataSet.CarModelInfo[i].ShiftNm) == false)
                        para.ShiftNm.Add(carInfoDataSet.CarModelInfo[i].ShiftNm);

                    if (para.TransmissionNm.Contains(carInfoDataSet.CarModelInfo[i].TransmissionNm) == false)
                        para.TransmissionNm.Add(carInfoDataSet.CarModelInfo[i].TransmissionNm);

                    if (para.WheelDriveMethodNm.Contains(carInfoDataSet.CarModelInfo[i].WheelDriveMethodNm) == false)
                        para.WheelDriveMethodNm.Add(carInfoDataSet.CarModelInfo[i].WheelDriveMethodNm);
                }
            }

            //�D�ǂa�k�R�[�h���������[�g����
            iOfferPrimeBlSearchDB = MediationOfferPrimeBlSearchDB.GetOfferPrimeBlSearchDB();
            // �I���W�i�����i�i����ԗ����i�A����D�Ǖ��i�j����
            status = iOfferPrimeBlSearchDB.Search(para, out RetParts, out retPartsPrice, out RetSetParts, out RetSetPartsPrice);

            if (status != 0)
            {
                return (status);
            }

            //���i���ݒ�
            FillOfrPrimePartsTable(RetParts, retPartsPrice);
            // 2009/10/19 Add >>>
            // �f�[�^�����݂��Ă��D�ǐݒ�ɂ���ĊY���Ȃ��ɂȂ�p�^�[��������ׁA�f�[�^�Z�b�g�ɃZ�b�g��ɃX�e�[�^�X�ύX
            if (partsInfo.UsrGoodsInfo.Count == 0) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            // 2009/10/19 Add <<<
            FillOfrSetInfo(RetSetParts, RetSetPartsPrice);

            //���[�U�[��������
            // --- UPD m.suzuki 2011/05/18 ---------->>>>>
            //status = GetUsrGoodsJoinInf(partsSearchUIData);
            status = GetUsrGoodsJoinInf( partsSearchUIData, null );
            // --- UPD m.suzuki 2011/05/18 ----------<<<<<

            if (status != 0)
            {
                return (status);
            }

            //UI�p�F���i�ڍׁi�^�����j�ݒ�
            ListPrimePartsDetail_Tables(RetParts);

            return (status);
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// �D�ǂa�k�������C��
        /// </summary>
        /// <param name="partsSearchUIDataDic">��������</param>
        /// <returns></returns>
        private int PrimeBlSearchMain(Dictionary<int, PartsSearchUIData> partsSearchUIDataDic)
        {
            // ��^�_��Ȃ��Ŏw��̃��[�J�[����^�̏ꍇ�͌��������A0���Ƃ���B
            if ((customerCarInfo != null) && (customerCarInfo.Count != 0))
            {
                if (customerCarInfo[0].MakerCode != 0 && searchPrtCtlAcs.BigCarOfferDiv == 0 && bigMakerList.Contains(customerCarInfo[0].MakerCode))
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            int status = 0;
            ArrayList RetParts;
            ArrayList retPartsPrice;
            ArrayList RetSetParts;
            ArrayList RetSetPartsPrice;

            foreach (int key in partsSearchUIDataDic.Keys)
            {

                OfferPrimeBlSearchCondWork para = new OfferPrimeBlSearchCondWork();

                //�a�k�R�[�h�ݒ�
                para.TbsPartsCode = partsSearchUIDataDic[key].TbsPartsCode;
                // �I���W�i�����i�����ɂ̓t���^���Œ�ԍ��ł̌������o���Ȃ����߁A
                // �����Ă���Ԃ̏����o���邩����g���Č�������B
                if (customerCarInfo != null && customerCarInfo.Count > 0)
                {
                    para.MakerCode = customerCarInfo[0].MakerCode;
                    para.ModelCode = customerCarInfo[0].ModelCode;
                    para.ModelSubCode = customerCarInfo[0].ModelSubCode;
                    para.SeriesModel = customerCarInfo[0].SeriesModel;
                    if (carInfoDataSet.CarModelUIData.Count > 0)
                    {
                        para.ProduceFrameNo = carInfoDataSet.CarModelUIData[0].SearchFrameNo;
                        para.ProduceTypeOfYear = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
                    }
                    // [�i���p] �^���N�����k����
                    for (int i = 0; i < carInfoDataSet.CarModelInfo.Count; i++)
                    {
                        if (para.CategorySignModel.Contains(carInfoDataSet.CarModelInfo[i].CategorySignModel) == false)
                            para.CategorySignModel.Add(carInfoDataSet.CarModelInfo[i].CategorySignModel);

                        if (para.ModelGradeNm.Contains(carInfoDataSet.CarModelInfo[i].ModelGradeNm) == false)
                            para.ModelGradeNm.Add(carInfoDataSet.CarModelInfo[i].ModelGradeNm);

                        if (para.BodyName.Contains(carInfoDataSet.CarModelInfo[i].BodyName) == false)
                            para.BodyName.Add(carInfoDataSet.CarModelInfo[i].BodyName);

                        if (para.DoorCount.Contains(carInfoDataSet.CarModelInfo[i].DoorCount) == false)
                            para.DoorCount.Add(carInfoDataSet.CarModelInfo[i].DoorCount);

                        if (para.EDivNm.Contains(carInfoDataSet.CarModelInfo[i].EDivNm) == false)
                            para.EDivNm.Add(carInfoDataSet.CarModelInfo[i].EDivNm);

                        if (para.EngineDisplaceNm.Contains(carInfoDataSet.CarModelInfo[i].EngineDisplaceNm) == false)
                            para.EngineDisplaceNm.Add(carInfoDataSet.CarModelInfo[i].EngineDisplaceNm);

                        if (para.EngineModelNm.Contains(carInfoDataSet.CarModelInfo[i].EngineModelNm) == false)
                            para.EngineModelNm.Add(carInfoDataSet.CarModelInfo[i].EngineModelNm);

                        if (para.ShiftNm.Contains(carInfoDataSet.CarModelInfo[i].ShiftNm) == false)
                            para.ShiftNm.Add(carInfoDataSet.CarModelInfo[i].ShiftNm);

                        if (para.TransmissionNm.Contains(carInfoDataSet.CarModelInfo[i].TransmissionNm) == false)
                            para.TransmissionNm.Add(carInfoDataSet.CarModelInfo[i].TransmissionNm);

                        if (para.WheelDriveMethodNm.Contains(carInfoDataSet.CarModelInfo[i].WheelDriveMethodNm) == false)
                            para.WheelDriveMethodNm.Add(carInfoDataSet.CarModelInfo[i].WheelDriveMethodNm);
                    }
                }

                //�D�ǂa�k�R�[�h���������[�g����
                iOfferPrimeBlSearchDB = MediationOfferPrimeBlSearchDB.GetOfferPrimeBlSearchDB();
                // �I���W�i�����i�i����ԗ����i�A����D�Ǖ��i�j����
                status = iOfferPrimeBlSearchDB.Search(para, out RetParts, out retPartsPrice, out RetSetParts, out RetSetPartsPrice);

                if (status != 0)
                {
                    continue;
                }

                //���i���ݒ�
                FillOfrPrimePartsTable(RetParts, retPartsPrice, key);
                // �f�[�^�����݂��Ă��D�ǐݒ�ɂ���ĊY���Ȃ��ɂȂ�p�^�[��������ׁA�f�[�^�Z�b�g�ɃZ�b�g��ɃX�e�[�^�X�ύX
                if (partsInfoDic[key].UsrGoodsInfo.Count == 0) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                FillOfrSetInfo(RetSetParts, RetSetPartsPrice, key);

            }

            //���[�U�[��������
            status = GetUsrGoodsJoinInf(partsSearchUIDataDic, null);

            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            foreach (PartsInfoDataSet partsInfo in partsInfoDic.Values)
            {
                if (partsInfo.UsrGoodsInfo.Count != 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }

            return (status);
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        #region [ 3. TBO���� ]
        /// <summary>
        /// �s�a�n�������C��
        /// </summary>
        /// <param name="partsSearchUIData">��������</param>
        /// <returns></returns>
        private int TBOSearchMain(PartsSearchUIData partsSearchUIData)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/24 DEL
            //int status = 0;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/24 DEL
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/24 ADD
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/24 ADD

            #region [ TBO���� ]�@�񋟎��q��񌋍����������[�g����
            //�@[ TBO���� ]�@�񋟎��q��񌋍����������[�g����
            string filter = string.Format("{0} = {1}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, partsSearchUIData.TbsPartsCode);
            BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);

            if (rows.Length > 0)
            {
                int equipGenreCode = rows[0].EquipGenreCode;

                filter = String.Format("{0} = {1}", carInfoDataSet.CategoryEquipmentInfo.TbsPartsCodeColumn.ColumnName,
                        partsSearchUIData.TbsPartsCode);
                PMKEN01010E.CategoryEquipmentInfoRow[] cEIrows =
                    (PMKEN01010E.CategoryEquipmentInfoRow[])carInfoDataSet.CategoryEquipmentInfo.Select(filter);

                int tbl_idx = cEIrows.Length;
                if (tbl_idx > 0)
                {
                    List<string> list = new List<string>();

                    for (int i = 0; i < tbl_idx; i++)
                    {
                        if (list.Contains(cEIrows[i].EquipmentName) == false)
                            list.Add(cEIrows[i].EquipmentName);
                    }

                    status = GetOfrTBOInfo(partsSearchUIData, equipGenreCode, list.ToArray());
                    //status = GetUsrGoodsJoinInf(partsSearchUIData);

                }
            }
            return status;
            #endregion
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// �s�a�n�������C��
        /// </summary>
        /// <param name="partsSearchUIDataDic">��������</param>
        /// <returns></returns>
        private int TBOSearchMain(Dictionary<int, PartsSearchUIData> partsSearchUIDataDic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            List<string[]> ofrTBOList = new List<string[]>();
            List<string> list = new List<string>();
            List<int> equipGenreCodeList = new List<int>();
            
            #region [ TBO���� ]�@�񋟎��q��񌋍����������[�g����

            foreach (PartsSearchUIData partsSearchUIData in partsSearchUIDataDic.Values)
            {
                string filter = string.Format("{0} = {1}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, partsSearchUIData.TbsPartsCode);
                BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);

                if (rows.Length > 0)
                {
                    equipGenreCodeList.Add(rows[0].EquipGenreCode);
                                        
                    filter = String.Format("{0} = {1}", carInfoDataSet.CategoryEquipmentInfo.TbsPartsCodeColumn.ColumnName,
                            partsSearchUIData.TbsPartsCode);
                    PMKEN01010E.CategoryEquipmentInfoRow[] cEIrows =
                        (PMKEN01010E.CategoryEquipmentInfoRow[])carInfoDataSet.CategoryEquipmentInfo.Select(filter);

                    int tbl_idx = cEIrows.Length;
                    if (tbl_idx > 0)
                    {
                        list.Clear();
                        for (int i = 0; i < tbl_idx; i++)
                        {
                            if (list.Contains(cEIrows[i].EquipmentName) == false)
                                list.Add(cEIrows[i].EquipmentName);
                        }
                        ofrTBOList.Add(list.ToArray());
                    }
                    else
                    {
                        ofrTBOList.Add(new List<string>().ToArray());
                    }
                }
                else
                {
                    ofrTBOList.Add(new List<string>().ToArray());
                    equipGenreCodeList.Add(0);
                }
            }

            //�@[ TBO���� ]�@�񋟎��q��񌋍����������[�g����
            status = GetOfrTBOInfo(partsSearchUIDataDic, equipGenreCodeList, ofrTBOList);

            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            foreach (PartsInfoDataSet partsInfo in partsInfoDic.Values)
            {
                if (partsInfo.UsrGoodsInfo.Count != 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }

            return status;
            #endregion
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        /// <summary>
        /// TBO���擾[�s�v�F�D�ǐݒ�Ȃ��o�[�W����]
        /// </summary>
        /// <param name="retPartsInfo">TBO��������</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns></returns>
        public int GetTBOInfo(out PartsInfoDataSet retPartsInfo, string enterpriseCode)
        {
            // 2009.02.12 >>>
            //return GetTBOInfo(out retPartsInfo, enterpriseCode, string.Empty, new Dictionary<PrmSettingKey, PrmSettingUWork>());
            return GetTBOInfo(out retPartsInfo, enterpriseCode, string.Empty, new List<PrmSettingUWork>());
            // 2009.02.12 <<<
        }

        /// <summary>
        /// TBO���擾�Q[�G���g����TBO�{�^�������p]
        /// </summary>
        /// <param name="retPartsInfo">TBO��������</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="secCd">���O�C�����_�R�[�h�i�D�ǐݒ胊�X�g�̐ݒ�擾�p�j</param>
        /// <param name="drPrmSettingWork">�D�ǐݒ胊�X�g</param>
        /// <returns></returns>
        public int GetTBOInfo(out PartsInfoDataSet retPartsInfo, string enterpriseCode, string secCd,
                // 2009.02.12 >>>
                //Dictionary<PrmSettingKey, PrmSettingUWork> drPrmSettingWork)
                List<PrmSettingUWork> drPrmSettingWork)
                // 2009.02.12 <<<
        {
            //>>>2010/03/29
            partsInfo.Clear();

            int makerCode = 0;
            if (carInfoDataSet != null)
            {
                if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                    makerCode = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                    makerCode = carInfoDataSet.CarModelInfo[0].MakerCode;
            }

            // ��^�_��Ȃ��Ŏw��̃��[�J�[����^�̏ꍇ�͌��������A0���Ƃ���B
            if ((customerCarInfo != null) && (customerCarInfo.Count != 0))
            {
                if (makerCode != 0 && searchPrtCtlAcs.BigCarOfferDiv == 0 && bigMakerList.Contains(makerCode))
                {
                    retPartsInfo = partsInfo;
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            //<<<2010/03/29

            List<string> list = new List<string>();
            ArrayList lstCond = new ArrayList();
            for (int i = 0; i < carInfoDataSet.CategoryEquipmentInfo.Count; i++)
            {
                if (list.Contains(carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName) == false)
                {
                    list.Add(carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName);

                    TBOSearchUWork tBOSearchUWork = new TBOSearchUWork();
                    tBOSearchUWork.EnterpriseCode = enterpriseCode;
                    tBOSearchUWork.EquipGenreCode = carInfoDataSet.CategoryEquipmentInfo[i].EquipmentGenreCd;
                    tBOSearchUWork.EquipName = carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName;
                    lstCond.Add(tBOSearchUWork);
                }
            }
            ArrayList tboSearchRet = null;
            ArrayList tboSearchPriceRet = null;
            _sectionCode = secCd;
            _drPrmSettingWork = drPrmSettingWork;

            //partsInfo.Clear(); // 2010/03/29
            partsInfo.SearchMethod = 0; // �������@�FBL����[�i���\�������f�̂��ߎg�p]

            TBOSearchCondWork tBOSearchCondWork = new TBOSearchCondWork();
            if (carInfoDataSet != null)
            {
                if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                    tBOSearchCondWork.CarMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                    tBOSearchCondWork.CarMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
            }
            tBOSearchCondWork.TbsPartsCode = 0;
            tBOSearchCondWork.EquipName = list.ToArray();
            tBOSearchCondWork.EquipGenreCode = 0;

            // -- UPD 2010/05/25 --------------------------------->>>
            //if (iTBOSearchInfDB == null)
            //    iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

            //int status = iTBOSearchInfDB.Search(tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet);
            //if ((status == 0) && (tboSearchRet.Count > 0))
            //{
            //    FillTBOInfoTable(tboSearchRet, tboSearchPriceRet);
            //}

            int status = 0;
            //if (LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if (LoginInfoAcquisition.OnlineFlag || (!LoginInfoAcquisition.OnlineFlag && Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) == "PMSCM01000U")) // ADD 2010/07/07
            {
                if ( iTBOSearchInfDB == null )
                    iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

                status = iTBOSearchInfDB.Search( tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet );
                if ( (status == 0) && (tboSearchRet.Count > 0) )
                {
                    FillTBOInfoTable( tboSearchRet, tboSearchPriceRet );
                }
            }
            // -- UPD 2010/05/25 ---------------------------------<<<

            if (iTBOSearchUDB == null)
                iTBOSearchUDB = MediationTBOSearchUDB.GetTBOSearchUDB();
            ArrayList tboSearchURet = new ArrayList();
            object objTBOSearchUList = tboSearchURet;
            //status = iTBOSearchUDB.Search(ref objTBOSearchUList, lstCond, 0, ConstantManagement.LogicalMode.GetData0); // 2009/09/07 DEL
            status = iTBOSearchUDB.Search(ref objTBOSearchUList, lstCond, 0, ConstantManagement.LogicalMode.GetData01); // 2009/09/07 ADD

            tboSearchURet = objTBOSearchUList as ArrayList;

            PartsSearchUIData partsSearchUIDate = new PartsSearchUIData();
            partsSearchUIDate.EnterpriseCode = enterpriseCode;
            status = GetUsrGoodsInfForTBO(enterpriseCode, tboSearchURet);

            if ((status == 0) && (tboSearchURet.Count > 0))
            {
                FillTBOUInfoTable(tboSearchURet);
            }

            retPartsInfo = partsInfo;

            return 0;
        }

        // 2009/09/07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// TBO���擾[�G���g����TBO�{�^�������p]
        /// </summary>
        /// <param name="retPartsInfo">TBO��������</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="secCd">���_�R�[�h(�D�ǐݒ胊�X�g�̐ݒ�擾�p)</param>
        /// <param name="drPrmSettingWork">�D�ǐݒ胊�X�g</param>
        /// <param name="inputPartsSearchUIData">���������f�[�^�N���X</param>
        /// <returns></returns>
        public int GetTBOInfo(out PartsInfoDataSet retPartsInfo, string enterpriseCode, string secCd, List<PrmSettingUWork> drPrmSettingWork, PartsSearchUIData inputPartsSearchUIData)
        {
            //>>>2010/03/29
            partsInfo.Clear();

            int makerCode = 0;
            if (carInfoDataSet != null)
            {
                if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                    makerCode = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                    makerCode = carInfoDataSet.CarModelInfo[0].MakerCode;
            }

            // ��^�_��Ȃ��Ŏw��̃��[�J�[����^�̏ꍇ�͌��������A0���Ƃ���B
            if ((customerCarInfo != null) && (customerCarInfo.Count != 0))
            {
                if (makerCode != 0 && searchPrtCtlAcs.BigCarOfferDiv == 0 && bigMakerList.Contains(makerCode))
                {
                    retPartsInfo = partsInfo;
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            //<<<2010/03/29

            List<string> list = new List<string>();
            ArrayList lstCond = new ArrayList();
            for (int i = 0; i < carInfoDataSet.CategoryEquipmentInfo.Count; i++)
            {
                if (list.Contains(carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName) == false)
                {
                    list.Add(carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName);

                    TBOSearchUWork tBOSearchUWork = new TBOSearchUWork();
                    tBOSearchUWork.EnterpriseCode = enterpriseCode;
                    tBOSearchUWork.EquipGenreCode = carInfoDataSet.CategoryEquipmentInfo[i].EquipmentGenreCd;
                    tBOSearchUWork.EquipName = carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName;
                    lstCond.Add(tBOSearchUWork);
                }
            }
            ArrayList tboSearchRet = null;
            ArrayList tboSearchPriceRet = null;
            _sectionCode = secCd;
            _drPrmSettingWork = drPrmSettingWork;

            //partsInfo.Clear(); // 2010/03/29
            partsInfo.SearchCondition = inputPartsSearchUIData;
            partsInfo.SearchMethod = 0; // �������@�FBL����[�i���\�������f�̂��ߎg�p]

            TBOSearchCondWork tBOSearchCondWork = new TBOSearchCondWork();
            if (carInfoDataSet != null)
            {
                if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                    tBOSearchCondWork.CarMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                    tBOSearchCondWork.CarMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
            }
            tBOSearchCondWork.TbsPartsCode = 0;
            tBOSearchCondWork.EquipName = list.ToArray();
            tBOSearchCondWork.EquipGenreCode = 0;

            // -- UPD 2010/05/25 ---------------------------------->>>
            //if (iTBOSearchInfDB == null)
            //    iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

            //int status = iTBOSearchInfDB.Search(tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet);
            //if ((status == 0) && (tboSearchRet.Count > 0))
            //{
            //    FillTBOInfoTable(tboSearchRet, tboSearchPriceRet);
            //}

            int status = 0;
            //if (LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if (LoginInfoAcquisition.OnlineFlag || (!LoginInfoAcquisition.OnlineFlag && Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) == "PMSCM01000U")) // ADD 2010/07/07
            {
                if ( iTBOSearchInfDB == null )
                    iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

                status = iTBOSearchInfDB.Search( tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet );
                if ( (status == 0) && (tboSearchRet.Count > 0) )
                {
                    FillTBOInfoTable( tboSearchRet, tboSearchPriceRet );
                }
            }
            // -- UPD 2010/05/25 ----------------------------------<<<

            if (iTBOSearchUDB == null)
                iTBOSearchUDB = MediationTBOSearchUDB.GetTBOSearchUDB();
            ArrayList tboSearchURet = new ArrayList();
            object objTBOSearchUList = tboSearchURet;
            status = iTBOSearchUDB.Search(ref objTBOSearchUList, lstCond, 0, ConstantManagement.LogicalMode.GetData01);

            tboSearchURet = objTBOSearchUList as ArrayList;

            PartsSearchUIData partsSearchUIDate = new PartsSearchUIData();
            partsSearchUIDate.EnterpriseCode = enterpriseCode;
            status = GetUsrGoodsInfForTBO(enterpriseCode, tboSearchURet);

            if ((status == 0) && (tboSearchURet.Count > 0))
            {
                FillTBOUInfoTable(tboSearchURet);
            }

            retPartsInfo = partsInfo;

            return 0;
        }
        // 2009/09/07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// TBO���擾�R[TBO�}�X�^�p]
        /// </summary>
        /// <param name="retPartsInfo">TBO��������</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="equipGenreCd">�������ށi��������TBO�̑������ށj</param>
        /// <param name="equipNm">�������́i��������TBO�̑������́E�����܂������͕s�j</param>
        /// <param name="secCd">���O�C�����_�R�[�h�i�D�ǐݒ胊�X�g�̐ݒ�擾�p�j</param>
        /// <param name="drPrmSettingWork">�D�ǐݒ胊�X�g</param>
        /// <returns></returns>
        public int GetTBOInfo(out PartsInfoDataSet retPartsInfo, string enterpriseCode,
                int equipGenreCd, string equipNm,
                // 2009.02.12 >>>
                //string secCd, Dictionary<PrmSettingKey, PrmSettingUWork> drPrmSettingWork)
                string secCd, List<PrmSettingUWork> drPrmSettingWork)  
                // 2009.02.12 <<<
        {
            ArrayList tboSearchRet = null;
            ArrayList tboSearchURet = new ArrayList();
            ArrayList tboSearchPriceRet = null;
            _sectionCode = secCd;
            _drPrmSettingWork = drPrmSettingWork;

            partsInfo.Clear();
            partsInfo.SearchMethod = 0; // �������@�FBL����[�i���\�������f�̂��ߎg�p]

            TBOSearchCondWork tBOSearchCondWork = new TBOSearchCondWork();
            tBOSearchCondWork.TbsPartsCode = 0;
            tBOSearchCondWork.EquipName = new string[] { equipNm };
            tBOSearchCondWork.EquipGenreCode = equipGenreCd;

            // -- UPD 2010/05/25 ---------------------------->>>
            //if (iTBOSearchInfDB == null)
            //    iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

            //int status = iTBOSearchInfDB.Search(tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet);
            //if ((status == 0) && (tboSearchRet.Count > 0))
            //{
            //    FillTBOInfoTable(tboSearchRet, tboSearchPriceRet);
            //}

            int status = 0;
            //if (LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if (LoginInfoAcquisition.OnlineFlag || (!LoginInfoAcquisition.OnlineFlag && Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) == "PMSCM01000U")) // ADD 2010/07/07
            {
                if ( iTBOSearchInfDB == null )
                    iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

                status = iTBOSearchInfDB.Search( tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet );
                if ( (status == 0) && (tboSearchRet.Count > 0) )
                {
                    FillTBOInfoTable( tboSearchRet, tboSearchPriceRet );
                }
            }
            // -- UPD 2010/05/25 ----------------------------<<<
            if (iTBOSearchUDB == null)
                iTBOSearchUDB = MediationTBOSearchUDB.GetTBOSearchUDB();
            object objTBOSearchUList = tboSearchURet;
            TBOSearchUWork tBOSearchUWork = new TBOSearchUWork();
            tBOSearchUWork.EnterpriseCode = enterpriseCode;
            tBOSearchUWork.EquipGenreCode = equipGenreCd;
            tBOSearchUWork.EquipName = equipNm;

            ArrayList lstCond = new ArrayList();
            lstCond.Add(tBOSearchUWork);
            status = iTBOSearchUDB.Search(ref objTBOSearchUList, lstCond, 0, ConstantManagement.LogicalMode.GetData0);

            tboSearchURet = objTBOSearchUList as ArrayList;

            PartsSearchUIData partsSearchUIDate = new PartsSearchUIData();
            partsSearchUIDate.EnterpriseCode = enterpriseCode;
            status = GetUsrGoodsInfForTBO(enterpriseCode, tboSearchURet);

            if ((status == 0) && (tboSearchURet.Count > 0))
            {
                FillTBOUInfoTable(tboSearchURet);
            }

            retPartsInfo = partsInfo;

            return 0;
        }


        /// <summary>
        /// �������̞B������
        /// </summary>
        /// <param name="lstEquipNm">�������̞B�����ʃ��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="equipGenreCd">�������ށi��������TBO�̑������ށj</param>
        /// <param name="equipNm">�������́i��������TBO�̑������́E�����܂������̂݁j</param>
        /// <param name="secCd">���O�C�����_�R�[�h�i�D�ǐݒ胊�X�g�̐ݒ�擾�p�j</param>
        /// <param name="drPrmSettingWork">�D�ǐݒ胊�X�g</param>
        /// <returns></returns>
        public int SearchEquipName(out List<string> lstEquipNm, string enterpriseCode,
                int equipGenreCd, string equipNm,
                // 2009.02.12 >>>
                //string secCd, Dictionary<PrmSettingKey, PrmSettingUWork> drPrmSettingWork)
                string secCd, List<PrmSettingUWork> drPrmSettingWork)
                // 2009.02.12 <<<
        {
            int nmSearchFlg = 0; // 0:���S��v,1:�O����v����,2:�����v����,3:�B������
            ArrayList tboSearchRet = null;
            ArrayList tboSearchURet = new ArrayList();
            ArrayList tboSearchPriceRet = null;
            _sectionCode = secCd;
            _drPrmSettingWork = drPrmSettingWork;

            lstEquipNm = new List<string>();

            TBOSearchCondWork tBOSearchCondWork = new TBOSearchCondWork();
            tBOSearchCondWork.TbsPartsCode = 0;
            tBOSearchCondWork.EquipName = new string[] { equipNm };
            tBOSearchCondWork.EquipGenreCode = equipGenreCd;

            // -- ADD 2010/05/25 ------------------>>>
            int status = 0;
            //if (LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if (LoginInfoAcquisition.OnlineFlag || (!LoginInfoAcquisition.OnlineFlag && Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) == "PMSCM01000U")) // ADD 2010/07/07
            {
            // -- ADD 2010/05/25 ------------------<<<

                if ( iTBOSearchInfDB == null )
                    iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

                // -- UPD 2010/05/25 --------------------------->>>
                //int status = iTBOSearchInfDB.Search(tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet);
                status = iTBOSearchInfDB.Search( tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet );
                // -- UPD 2010/05/25 ---------------------------<<<
                if ( (status == 0) && (tboSearchRet.Count > 0) )
                {
                    foreach ( TBOSearchRetWork wkInf in tboSearchRet )
                    {
                        if ( searchPrtCtlAcs.TactiSearch == 0  // �^�N�e�B�����_��Ȃ�
                             && wkInf.JoinDestMakerCd == ct_TactiCd // ���i���[�J�[���^�N�e�B�[
                             && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd ) // �Ԃ̃��[�J�[���g���^�łȂ�
                        {
                            continue;
                        }
                        //�@�D�ǐݒ�i������
                        bool tboExcludeFlg = false;
                        // 2009.02.12 >>>
                        //PrmSettingUWork prmSetting = null;
                        //PrmSettingKey prmKey = new PrmSettingKey(_sectionCode, wkInf.GoodsMGroup,
                        //        wkInf.TbsPartsCode, wkInf.JoinDestMakerCd);
                        //if (_drPrmSettingWork.ContainsKey(prmKey) == false)
                        //{
                        //    tboExcludeFlg = true;
                        //}
                        //else
                        //{
                        //    prmSetting = _drPrmSettingWork[prmKey];
                        //    if (prmSetting.PrimeDisplayCode == 0) // �D�Ǖ\���敪��[�Ȃ�]�ȊO��\������B
                        //        tboExcludeFlg = true;
                        //}

                        PrmSettingUWork prmSetting = SearchPrmSettingUWork( _sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, _drPrmSettingWork );
                        if ( prmSetting == null )
                        {
                            tboExcludeFlg = true;
                        }
                        else
                        {
                            if ( prmSetting.PrimeDisplayCode == 0 ) // �D�Ǖ\���敪��[�Ȃ�]�ȊO��\������B
                                tboExcludeFlg = true;
                        }

                        // 2009.02.12 <<<
#if !PrimeSet
                    tboExcludeFlg = false;
#endif
                        if ( tboExcludeFlg == false && lstEquipNm.Contains( wkInf.EquipName ) == false )
                        {
                            lstEquipNm.Add( wkInf.EquipName );
                        }
                    }
                }
            }  // ADD 2010/05/25


            if (iTBOSearchUDB == null)
                iTBOSearchUDB = MediationTBOSearchUDB.GetTBOSearchUDB();
            object objTBOSearchUList = tboSearchURet;
            TBOSearchUWork tBOSearchUWork = new TBOSearchUWork();
            tBOSearchUWork.EnterpriseCode = enterpriseCode;
            tBOSearchUWork.EquipGenreCode = equipGenreCd;
            tBOSearchUWork.EquipName = equipNm;
            if (equipNm.EndsWith("*"))
            {
                tBOSearchUWork.EquipName = tBOSearchUWork.EquipName.Substring(0, equipNm.Length - 1);
                if (tBOSearchUWork.EquipName.StartsWith("*"))
                {
                    tBOSearchUWork.EquipName = tBOSearchUWork.EquipName.Remove(0, 1);
                    nmSearchFlg = 3;
                }
                else if (equipNm == "*")
                    nmSearchFlg = 3;
                else
                    nmSearchFlg = 1;
            }
            else if (equipNm.StartsWith("*"))
            {
                tBOSearchUWork.EquipName = tBOSearchUWork.EquipName.Remove(0, 1);
                nmSearchFlg = 2;
            }
            if (nmSearchFlg > 0) // �������̞B��������
            {
                status = iTBOSearchUDB.SearchEquipNameGuide(ref objTBOSearchUList, tBOSearchUWork, nmSearchFlg);
            }

            tboSearchURet = objTBOSearchUList as ArrayList;
            if ((status == 0) && (tboSearchURet.Count > 0))
            {
                foreach (TBOSearchUWork wkInf in tboSearchURet)
                {
                    if (searchPrtCtlAcs.TactiSearch == 0  // �^�N�e�B�����_��Ȃ�
                         && wkInf.JoinDestMakerCd == ct_TactiCd // ���i���[�J�[���^�N�e�B�[
                         && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd) // �Ԃ̃��[�J�[���g���^�łȂ�
                    {
                        continue;
                    }
                    if (lstEquipNm.Contains(wkInf.EquipName) == false)
                    {
                        lstEquipNm.Add(wkInf.EquipName);
                    }
                }
            }

            return 0;
        }

        #endregion

        # region [ 4. �i�Ԍ������C�� ]
        /// <summary>
        /// �i�Ԍ������C��
        /// </summary>
        /// <param name="partsSearchUIData">��������</param>
        /// 
        /// <br>Update Note: 2011/08/24  �A��980 ���X��</br>
        /// <br>            : REDMINE#23417�̑Ή�</br>
        /// <br>Update Note: 2011/08/31  �A��980 ���X��</br>
        /// <br>            : REDMINE#23417�̑Ή�</br>
        /// <br>Update Note: 2012/06/18  ��QNo.1004 ����</br>
        /// <returns></returns>
        private int PartsNoSearchMain(PartsSearchUIData partsSearchUIData)
        {
            # region �ϐ��̏�����
            int status = 0;

            GetPartsInfPara para = new GetPartsInfPara();
            # endregion

            # region ���������̐ݒ�
            string srcPrtsNo = partsSearchUIData.PartsNo;

            //�n�C�t���L������
            if (srcPrtsNo.IndexOf("-") != -1)
            {
                para.PrtsNoWithHyphen = srcPrtsNo;
            }
            else
            {
                para.PrtsNoNoneHyphen = srcPrtsNo;
            }
            para.MakerCode = partsSearchUIData.PartsMakerCode;
            para.SearchType = (int)partsSearchUIData.SearchType;
            if (partsSearchUIData.SearchFlg == SearchFlag.GoodsInfoOnly || partsSearchUIData.SearchFlg == SearchFlag.GoodsAndSetInfo)
                para.NoSubst = 1;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/18 ADD
            para.PriceDate = partsSearchUIData.PriceDate;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/18 ADD
            // --- ADD m.suzuki 2010/06/12 ---------->>>>>
            // 0:�Q�փI�v�V�����Ȃ�
            if ( searchPrtCtlAcs.BikeSearch == 0 )
            {
                // 2�֒񋟃f�[�^�͏��O
                SetParamForBikeSearch( ref para, false );
            }
            // --- ADD m.suzuki 2010/06/12 ----------<<<<<
            # endregion

            //ADD by Liangsd   2011/08/24----------------->>>>>>>>>>
            //DEL by Liangsd   2011/08/31----------------->>>>>>>>>>>
            //if (!srcPrtsNo.ToUpper().Equals(srcPrtsNo))
            //{
            //    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            //}
            //DEL by Liangsd   2011/08/31-----------------<<<<<<<<<<<
            //ADD by Liangsd   2011/08/24-----------------<<<<<<<<<<<
            # region �����i�Ԍ���
            //�����i�Ԍ���
            //status = GetCatalogPartsInf(para);//DEL by Liangsd   2011/08/31
            //ADD by Liangsd   2011/08/31----------------->>>>>>>>>>
            if (!srcPrtsNo.ToUpper().Equals(srcPrtsNo))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            else
            {
                status = GetCatalogPartsInf(para);            
            }
            //ADD by Liangsd   2011/08/31-----------------<<<<<<<<<<<
            if (status != 0 && status != 4)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            # endregion

            ArrayList searchCondList = new ArrayList();

            // �D�Ǖ��i�ɑ΂��i�Ԍ������s���B
            //status = GetPrimePartsInfFromPrimePartsNo(partsSearchUIData); // DEL 2012/06/18 ���� ��Q��1004
            // ----- ADD 2012/06/18 ���� ��Q��1004 ----->>>>>
            if (!srcPrtsNo.ToUpper().Equals(srcPrtsNo))
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            else
            {
                status = GetPrimePartsInfFromPrimePartsNo(partsSearchUIData);
            }
            // ----- ADD 2012/06/18 ���� ��Q��1004 -----<<<<<
            if (status != 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            if (partsInfo.UsrGoodsInfo.Count > 0)
            {
                if (partsSearchUIData.SearchFlg == SearchFlag.PartsNoJoinSearch)
                {// �i�Ԍ��������̏ꍇ�A�擾���������i�Ԃɑ΂��錋���������s���B  
                    bool primeSubstFlg = false; // �i�Ԍ����͗D�ǌ�������ւ��Ȃ��B
                    //if (partsSearchUIData.SearchCntSetWork.PrmSubstCondDivCd != 0)
                    //    primeSubstFlg = true;
                    // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                    //status = GetPrimePartsInf( primeSubstFlg );
                    status = GetPrimePartsInf( primeSubstFlg, para );
                    // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                }
            }
            #region [ Comment Out ]
            /* ���\�[�X�@�@�i�Ԍ������ǂ̂��߃R�����g�A�E�g����
            if (partsInfo.PartsInfo.Count > 0)
            {
                if (partsSearchUIData.SearchFlg == SearchFlag.PartsNoJoinSearch)
                {// �i�Ԍ��������̏ꍇ�A�擾���������i�Ԃɑ΂��錋���������s���B  
                    bool primeSubstFlg = false;
                    if (partsSearchUIData.SearchCntSetWork.PrmSubstCondDivCd != 0)
                        primeSubstFlg = true;
                    status = GetPrimePartsInf(primeSubstFlg);
                }
                if (partsSearchUIData.SearchFlg != SearchFlag.GoodsInfoOnly)
                {
                    GetUsrCondList(searchCondList, partsSearchUIData);
                }
            }
            else // �i�Ԍ����ŏ������i�ɊY���i�Ԃ��Ȃ������ꍇ�D�Ǖ��i����������B
            {
                status = GetPrimePartsInfFromPrimePartsNo(partsSearchUIData);
                if (status != 0)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }

                if (partsSearchUIData.SearchFlg != SearchFlag.GoodsInfoOnly)
                {
                    GetUsrCondList(searchCondList, partsSearchUIData);
                    //GetUsrCondListFromJoinParts(searchCondList);
                    //GetUsrCondListFromSet(searchCondList);
                    //GetUsrCondListFromSubst(searchCondList); 
                    //GetUsrCondListFromDSubst(searchCondList);
                }
            }*/
            #endregion

            // ��L�������ʂɊ֌W�Ȃ����[�U�[DB����������B[�񋟃f�[�^�C���������[�U�[DB�ɂ���\��������]
            if (partsSearchUIData.SearchFlg == SearchFlag.GoodsInfoOnly)
            {
                status = GetUsrPartsInfFromPartsNo(partsSearchUIData);
                if (status != 0)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
            else
            {
                // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                //status = GetUsrGoodsJoinInf(partsSearchUIData);
                status = GetUsrGoodsJoinInf( partsSearchUIData, para );
                // --- UPD m.suzuki 2011/05/18 ----------<<<<<
            }

            #region [ ���[�U�[OEM�Ή� ]
            if (partsSearchUIData.SearchCntSetWork.SubstApplyDivCd == 2) // ��֓K�p�S�āF���[�U�[�o�^�i�Ɋւ��čX�ɒ񋟌���
            {
                status = UserOEMSearch(partsSearchUIData);
            }
            #endregion

            // --- ADD 2012/12/20 Y.Wakita ---------->>>>>
            // ������x�쐬
            // ��L�������ʂɊ֌W�Ȃ����[�U�[DB����������B[�񋟃f�[�^�C���������[�U�[DB�ɂ���\��������]
            if (partsSearchUIData.SearchFlg == SearchFlag.GoodsInfoOnly)
            {
                status = GetUsrPartsInfFromPartsNo(partsSearchUIData);
                if (status != 0)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
            else
            {
                status = GetUsrGoodsJoinInf(partsSearchUIData, para);
            }
            // --- ADD 2012/12/20 Y.Wakita ----------<<<<<

            if (partsInfo.UsrGoodsInfo.Count == 0)
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            return status;
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// �i�Ԍ������C��
        /// </summary>
        /// <param name="inParaDic">��������</param>
        /// <returns></returns>
        private int PartsNoSearchMain(Dictionary<int, PartsSearchUIData> inParaDic)
        {
            # region �ϐ��̏�����
            int status = 0;

            GetPartsInfPara para;
            Dictionary<int, GetPartsInfPara> partsParaDic = new Dictionary<int, GetPartsInfPara>();             // �����i�Ԍ����p
            Dictionary<int, PartsSearchUIData> primeInParaDic = new Dictionary<int, PartsSearchUIData>();       // �D�Ǖi�Ԍ����p
            Dictionary<int, GetPartsInfPara> joinPartsParaDic = new Dictionary<int, GetPartsInfPara>();         // �i�Ԍ��������p
            Dictionary<int, PartsSearchUIData> goodsInfInParaDic = new Dictionary<int, PartsSearchUIData>();    // ���i���̂݌����p
            Dictionary<int, GetPartsInfPara> goodsPartsParaDic = new Dictionary<int, GetPartsInfPara>();        // ���i��񌟍��p
            Dictionary<int, PartsSearchUIData> goodsPartsInParaDic = new Dictionary<int, PartsSearchUIData>();  // ���i��񌟍��p
            # endregion

            # region ���������̐ݒ�

            foreach (int key in inParaDic.Keys)
            {
                para = new GetPartsInfPara();

                string srcPrtsNo = inParaDic[key].PartsNo;

                //�n�C�t���L������
                if (srcPrtsNo.IndexOf("-") != -1)
                {
                    para.PrtsNoWithHyphen = srcPrtsNo;
                }
                else
                {
                    para.PrtsNoNoneHyphen = srcPrtsNo;
                }
                para.MakerCode = inParaDic[key].PartsMakerCode;
                para.SearchType = (int)inParaDic[key].SearchType;
                if (inParaDic[key].SearchFlg == SearchFlag.GoodsInfoOnly || inParaDic[key].SearchFlg == SearchFlag.GoodsAndSetInfo)
                    para.NoSubst = 1;
                para.PriceDate = inParaDic[key].PriceDate;
                // 0:�Q�փI�v�V�����Ȃ�
                if (searchPrtCtlAcs.BikeSearch == 0)
                {
                    // 2�֒񋟃f�[�^�͏��O
                    SetParamForBikeSearch(ref para, false);
                }

                // �����i�ԁE�D�Ǖi�Ԍ����p���X�g����
                if (srcPrtsNo.ToUpper().Equals(srcPrtsNo))
                {
                    partsParaDic.Add(key, para);
                    primeInParaDic.Add(key, inParaDic[key]);
                }
                // ���������ʃ��X�g�̐���
                if (inParaDic[key].SearchFlg == SearchFlag.PartsNoJoinSearch)
                {
                    joinPartsParaDic.Add(key, para);
                }
                if (inParaDic[key].SearchFlg == SearchFlag.GoodsInfoOnly)
                {
                    goodsInfInParaDic.Add(key, inParaDic[key]);
                }
                else
                {
                    goodsPartsParaDic.Add(key, para);
                    goodsPartsInParaDic.Add(key, inParaDic[key]);
                }

            }

            # endregion

            # region �����i�Ԍ���
            //�����i�Ԍ���
            status = GetCatalogPartsInf(partsParaDic);

            if (status != 0 && status != 4)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            # endregion

            // �D�Ǖ��i�ɑ΂��i�Ԍ������s���B
            status = GetPrimePartsInfFromPrimePartsNo(primeInParaDic);

            if (status != 0)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            if (joinPartsParaDic != null && joinPartsParaDic.Count != 0)
            {
                // �i�Ԍ��������̏ꍇ�A�擾���������i�Ԃɑ΂��錋���������s���B  
                bool primeSubstFlg = false; // �i�Ԍ����͗D�ǌ�������ւ��Ȃ��B
                status = GetPrimePartsInf(primeSubstFlg, joinPartsParaDic);
            }

            // ��L�������ʂɊ֌W�Ȃ����[�U�[DB����������B[�񋟃f�[�^�C���������[�U�[DB�ɂ���\��������]
            if (goodsInfInParaDic != null && goodsInfInParaDic.Count != 0)
            {
                status = GetUsrPartsInfFromPartsNo(goodsInfInParaDic);
                if (status != 0)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
            if (goodsPartsInParaDic != null && goodsPartsInParaDic.Count != 0)
            {
                status = GetUsrGoodsJoinInf(goodsPartsInParaDic, goodsPartsParaDic);
            }

            #region [ ���[�U�[OEM�Ή� ]
            status = UserOEMSearch(inParaDic);
            #endregion

            // ������x�쐬
            // ��L�������ʂɊ֌W�Ȃ����[�U�[DB����������B[�񋟃f�[�^�C���������[�U�[DB�ɂ���\��������]
            if (goodsInfInParaDic != null && goodsInfInParaDic.Count != 0)
            {
                status = GetUsrPartsInfFromPartsNo(goodsInfInParaDic);
                if (status != 0)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
            if (goodsPartsInParaDic != null && goodsPartsInParaDic.Count != 0)
            {
                status = GetUsrGoodsJoinInf(goodsPartsInParaDic, goodsPartsParaDic);
            }

            status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            foreach (PartsInfoDataSet partsInfo in partsInfoDic.Values)
            {
                if (partsInfo.UsrGoodsInfo.Count != 0)
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }

            return status;

        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        // --- ADD m.suzuki 2010/06/12 ---------->>>>>
        /// <summary>
        /// �Q�֌����p�p�����[�^�ݒ�
        /// </summary>
        /// <param name="para">�ݒ�Ώۂ̃p�����[�^</param>
        /// <param name="bikeSearchEnable">true:�Q�ւ���^false:�Q�ւȂ�</param>
        private void SetParamForBikeSearch( ref GetPartsInfPara para, bool bikeSearchEnable )
        {
            if ( bikeSearchEnable )
            {
                // �Q�֏��O�t���O��false
                para.TwoWheelerMakerExclude = false;
                // �Q�փ��[�J�[�R�[�h���Z�b�g���Ȃ�
                para.TwoWheelerMakerCdSt = 0;
                para.TwoWheelerMakerCdEd = 0;
            }
            else
            {
                // �Q�֏��O�t���O��true
                para.TwoWheelerMakerExclude = true;
                // �Q�փ��[�J�[�R�[�h(21�`24)
                para.TwoWheelerMakerCdSt = 21;
                para.TwoWheelerMakerCdEd = 24;
            }
        }
        // --- ADD m.suzuki 2010/06/12 ----------<<<<<

        private int GetUsrPartsInfFromPartsNo(PartsSearchUIData partsSearchUIData)
        {
            int status = 0;

            ArrayList usrGoodsRet = new ArrayList();
            ArrayList usrGoodsPriceRet = new ArrayList();
            ArrayList usrGoodsStockRet = new ArrayList();

            UsrPartsNoSearchCondWork usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
            usrJoinPartsCondWork.EnterpriseCode = partsSearchUIData.EnterpriseCode;
            usrJoinPartsCondWork.MakerCode = partsSearchUIData.PartsMakerCode;
            usrJoinPartsCondWork.PrtsNo = partsSearchUIData.PartsNo;

            if (iUsrJoinPartsSearchDB == null)
                iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();

            // 2009/12/17 >>>
            //// 2009/09/07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            ////status = iUsrJoinPartsSearchDB.UserGoodsSearch(usrJoinPartsCondWork,
            ////                                        (int)partsSearchUIData.SearchType,
            ////                                        out usrGoodsRet,
            ////                                        out usrGoodsPriceRet,
            ////                                        out usrGoodsStockRet);
            //status = iUsrJoinPartsSearchDB.UserGoodsSearch(usrJoinPartsCondWork,
            //                                        (int)partsSearchUIData.SearchType,
            //                                        ConstantManagement.LogicalMode.GetData01,
            //                                        out usrGoodsRet,
            //                                        out usrGoodsPriceRet,
            //                                        out usrGoodsStockRet);
            //// 2009/09/07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            status = iUsrJoinPartsSearchDB.UserGoodsSearch(usrJoinPartsCondWork,
                                                    (int)partsSearchUIData.SearchType,
                                                    partsSearchUIData.LogicalMode,
                                                    out usrGoodsRet,
                                                    out usrGoodsPriceRet,
                                                    out usrGoodsStockRet);
            // 2009/12/17 <<<

            // --- UPD m.suzuki 2011/05/18 ---------->>>>>
            //FillUsrGoodsInfoTable(usrGoodsRet);
            FillUsrGoodsInfoTable( usrGoodsRet, null );
            // --- UPD m.suzuki 2011/05/18 ----------<<<<<
            FillUsrGoodsPriceTable(usrGoodsPriceRet);
            FillUsrGoodsStockTable(usrGoodsStockRet);
            return status;
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        ///  �i�Ԍ�������
        /// </summary>
        /// <param name="partsSearchUIDataDic"></param>
        /// <returns></returns>
        private int GetUsrPartsInfFromPartsNo(Dictionary<int, PartsSearchUIData> partsSearchUIDataDic)
        {
            int status = 0;

            ArrayList usrGoodsRet = new ArrayList();
            ArrayList usrGoodsPriceRet = new ArrayList();
            ArrayList usrGoodsStockRet = new ArrayList();

            ArrayList usrJoinPartsCond = new ArrayList();
            ArrayList searchType = new ArrayList();

            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;

            foreach (int key in partsSearchUIDataDic.Keys)
            {
                UsrPartsNoSearchCondWork usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                usrJoinPartsCondWork.EnterpriseCode = partsSearchUIDataDic[key].EnterpriseCode;
                usrJoinPartsCondWork.MakerCode = partsSearchUIDataDic[key].PartsMakerCode;
                usrJoinPartsCondWork.PrtsNo = partsSearchUIDataDic[key].PartsNo;
                usrJoinPartsCond.Add(usrJoinPartsCondWork as object);

                searchType.Add(partsSearchUIDataDic[key].SearchType as object);

                logicalMode = partsSearchUIDataDic[key].LogicalMode;
            }

            if (iUsrJoinPartsSearchDB == null)
                iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();


            status = iUsrJoinPartsSearchDB.UserGoodsSearch(usrJoinPartsCond,
                                                    searchType,
                                                    logicalMode,
                                                    out usrGoodsRet,
                                                    out usrGoodsPriceRet,
                                                    out usrGoodsStockRet);

            foreach (int key in partsSearchUIDataDic.Keys)
            {
                // ���[�U�[���������F���i���ݒ�
                FillUsrGoodsInfoTable(usrGoodsRet, null, key);
                // ���i���ݒ�
                FillUsrGoodsPriceTable(usrGoodsPriceRet);
                // �݌ɏ��ݒ�
                FillUsrGoodsStockTable(usrGoodsStockRet);
            }
            return status;
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        /// <summary>
        /// �i�ԁE���[�J�[��������[���S��v�����̂�]
        /// </summary>
        /// <param name="PartsSearchUIData">��������</param>
        /// <param name="lstSrchCond">�����������X�g</param>
        /// <param name="retPartsInfo">���ʃf�[�^�Z�b�g</param>
        /// <returns></returns>
        public int PrtNoListSearch(PartsSearchUIData PartsSearchUIData, ArrayList lstSrchCond, out PartsInfoDataSet retPartsInfo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            partsInfo.Clear();
            partsInfo.SearchCondition = PartsSearchUIData;
            _sectionCode = PartsSearchUIData.SectionCode;
            _drPrmSettingWork = PartsSearchUIData.PrmSettingWork;

            ArrayList lstCond = new ArrayList();
            ArrayList searchCondList = new ArrayList();
            ArrayList lstRst;
            ArrayList lstRstPrm;
            ArrayList lstPrmPrice;
            try
            {
                // �񋟕��i���擾
                int cnt = lstSrchCond.Count;
                for (int i = 0; i < cnt; i++)
                {
                    SrchCond con = lstSrchCond[i] as SrchCond;
                    OfrPrtsSrchCndWork work = new OfrPrtsSrchCndWork();
                    work.MakerCode = con.makerCd;
                    work.PrtsNo = con.partsNo;
                    lstCond.Add(work);

                    UsrPartsNoSearchCondWork usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                    usrJoinPartsCondWork.EnterpriseCode = PartsSearchUIData.EnterpriseCode;
                    usrJoinPartsCondWork.MakerCode = con.makerCd;
                    usrJoinPartsCondWork.PrtsNo = con.partsNo;
                    searchCondList.Add(usrJoinPartsCondWork);
                }

                // -- UPD 2010/05/25 -------------------------->>>
                //if (iOfferPartsInfo == null)
                //    iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();

                //status = iOfferPartsInfo.GetOfrPartsInf(lstCond, out lstRst, out lstRstPrm, out lstPrmPrice);
                //if (status == 0)
                //{
                //    // �������i���ݒ�
                //    FillPartsInfo(lstRst, null);
                //    // �D�Ǖ��i���ݒ�
                //    FillJoinSetParts(true, lstRstPrm, lstPrmPrice, null, null);
                //}

                //if (LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
                if (LoginInfoAcquisition.OnlineFlag || (!LoginInfoAcquisition.OnlineFlag && Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) == "PMSCM01000U")) // ADD 2010/07/07
                {
                    if ( iOfferPartsInfo == null )
                        iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();

                    status = iOfferPartsInfo.GetOfrPartsInf( lstCond, out lstRst, out lstRstPrm, out lstPrmPrice );
                    if ( status == 0 )
                    {
                        // �������i���ݒ�
                        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                        //FillPartsInfo( lstRst, null );
                        FillPartsInfo( lstRst, null, null );
                        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                        // �D�Ǖ��i���ݒ�
                        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                        //FillJoinSetParts( true, lstRstPrm, lstPrmPrice, null, null );
                        FillJoinSetParts( true, lstRstPrm, lstPrmPrice, null, null, null );
                        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                    }
                }
                // -- UPD 2010/05/25 --------------------------<<<

                // ���[�U�[���i���擾
                object retobj;
                if (iUsrJoinPartsSearchDB == null)
                    iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();

                status = iUsrJoinPartsSearchDB.UserGoodsJoinSearch(out retobj, UsrSearchFlg.UsrPartsOnly, (int)SearchType.WholeWord, searchCondList);
                if (status == 0)
                {
                    CustomSerializeArrayList arrList = retobj as CustomSerializeArrayList;

                    for (int i = 0; i < arrList.Count; i++)
                    {
                        ArrayList usrRet = arrList[i] as ArrayList;
                        switch (usrRet[0].GetType().Name)
                        {
                            case "UsrGoodsRetWork":
                                //���[�U�[��������:���i���
                                // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                                //FillUsrGoodsInfoTable(usrRet);
                                FillUsrGoodsInfoTable( usrRet, null );
                                // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                                break;
                            case "GoodsPriceUWork":
                                FillUsrGoodsPriceTable(usrRet);
                                break;
                            case "StockWork":
                                FillUsrGoodsStockTable(usrRet);
                                break;
                        }
                    }
                }
            }
            catch
            {

            }

            retPartsInfo = partsInfo;
            return status;
        }
        # endregion

        #region [ 5. ���������� ]
        // 2009/11/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        //private int GetJoinSrcPartsProc(string enterpriseCd, int makerCd, string partsNo)
        private int GetJoinSrcPartsProc(int mode, string enterpriseCd, int makerCd, string partsNo)
        // 2009/11/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        {
            int status = 0;
            object obRetparts = null;
            ArrayList RetPartsInf = null;
            ArrayList searchCondList = new ArrayList();

            // -- ADD 2010/05/25 ----------------------->>>
            //if (LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if (LoginInfoAcquisition.OnlineFlag || (!LoginInfoAcquisition.OnlineFlag && Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) == "PMSCM01000U")) // ADD 2010/07/07
            {
            // -- ADD 2010/05/25 -----------------------<<<

                if ( iOfferPartsInfo == null )
                    iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();
                status = iOfferPartsInfo.GetGenuineParts( makerCd, partsNo, out obRetparts );
                if ( status == 0 )
                {
                    partsInfo.Clear();
                    partsInfo.SearchMethod = 1; // �����������͕i�Ԍ��������Ƃ���B
                    RetPartsInf = obRetparts as ArrayList;
                    //���i���ݒ�
                    // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                    //FillPartsInfo( RetPartsInf, null );
                    FillPartsInfo( RetPartsInf, null, null );
                    // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                    for ( int i = 0; i < partsInfo.UsrGoodsInfo.Count; i++ )
                    {
                        UsrPartsNoSearchCondWork usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                        usrJoinPartsCondWork.EnterpriseCode = enterpriseCd;
                        usrJoinPartsCondWork.MakerCode = partsInfo.UsrGoodsInfo[i].GoodsMakerCd;
                        usrJoinPartsCondWork.PrtsNo = partsInfo.UsrGoodsInfo[i].GoodsNo;
                        searchCondList.Add( usrJoinPartsCondWork );
                    }

                    object retobj;
                    CustomSerializeArrayList arrList;
                    ArrayList usrRet = null;
                    if ( iUsrJoinPartsSearchDB == null )
                        iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();

                    status = iUsrJoinPartsSearchDB.UserGoodsJoinSearch( out retobj, UsrSearchFlg.UsrPartsOnly, (int)SearchType.WholeWord, searchCondList );
                    if ( status != 0 )
                    {
                        return (status);
                    }
                    arrList = retobj as CustomSerializeArrayList;
                    for ( int i = 0; i < arrList.Count; i++ )
                    {
                        usrRet = arrList[i] as ArrayList;
                        switch ( usrRet[0].GetType().Name )
                        {
                            case "UsrGoodsRetWork":
                                //���[�U�[��������:���i���
                                // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                                //FillUsrGoodsInfoTable( usrRet );
                                FillUsrGoodsInfoTable( usrRet, null );
                                // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                                break;
                            case "GoodsPriceUWork":
                                FillUsrGoodsPriceTable( usrRet );
                                break;
                            case "StockWork":
                                FillUsrGoodsStockTable( usrRet );
                                break;
                        }
                    }
                }
            }  // ADD 2010/05/25

            ArrayList retGoods;
            ArrayList retPrice;
            ArrayList retStock;
            UsrPartsNoSearchCondWork cond = new UsrPartsNoSearchCondWork();
            cond.EnterpriseCode = enterpriseCd;
            cond.MakerCode = makerCd;
            cond.PrtsNo = partsNo;
            if (iUsrJoinPartsSearchDB == null)
                iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();
            status = iUsrJoinPartsSearchDB.UserGoodsSearch(cond, 5, out retGoods, out retPrice, out retStock);
            if (status == 0)
            {
                //���[�U�[��������:���i���
                // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                //FillUsrGoodsInfoTable(retGoods);
                FillUsrGoodsInfoTable( retGoods, null );
                // --- UPD m.suzuki 2011/05/18 ----------<<<<<

                // 2009/11/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                if (mode == 1)
                {
                    foreach (UsrGoodsRetWork wkInf in retGoods)
                    {
                        # region �ϐ��̏�����
                        GetPartsInfPara para = new GetPartsInfPara();
                        # endregion

                        # region ���������̐ݒ�
                        string srcPrtsNo = wkInf.GoodsNo;

                        //�n�C�t���L������
                        if (srcPrtsNo.IndexOf("-") != -1)
                        {
                            para.PrtsNoWithHyphen = srcPrtsNo;
                            para.SearchType = (int)SearchType.WholeWord;
                        }
                        else
                        {
                            para.PrtsNoNoneHyphen = srcPrtsNo;
                            para.SearchType = (int)SearchType.WholeWordWithNoHyphen;
                        }
                        para.MakerCode = wkInf.GoodsMakerCd;
                        para.NoSubst = 1;
                        para.PriceDate = DateTime.Today;
                        # endregion

                        # region �����i�Ԍ���
                        //�����i�Ԍ���
                        status = GetCatalogPartsInf2(para);
                        if (status != 0 && status != 4)
                        {
                            return (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        }
                        # endregion
                    }
                }
                // 2009/11/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                FillUsrGoodsPriceTable(retPrice);
                FillUsrGoodsStockTable(retStock);
            }

            return status;
        }
        #endregion

        #region [ 6. ���i�ꊇ�o�^���� ]
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 DEL
        //private int SearchOfrPartsProc(PrtsSrchCndWork InPara)
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 DEL
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
        private int SearchOfrPartsProc( PrtsSrchCndWork InPara, string sectionCode, List<PrmSettingUWork> prmSettingUWorkList )
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD
        {
            // -- ADD 2010/05/25 ---------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return 0;
            }
            // -- ADD 2010/05/25 ----------------------<<<

            int status = 0;
            object obRetparts = null;
            ArrayList searchCondList = new ArrayList();
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
            // ���_�R�[�h�i�D�ǐݒ�p�j
            _sectionCode = sectionCode;
            // �D�ǐݒ胊�X�g
            _drPrmSettingWork = prmSettingUWorkList;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD

            if ( iOfferPartsInfo == null )
                iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();
            status = iOfferPartsInfo.SearchParts( InPara, ref obRetparts );
            if ( status == 0 )
            {
                partsInfo.Clear();
                partsInfo.SearchMethod = 1; // �����������͕i�Ԍ��������Ƃ���B
                CustomSerializeArrayList RetPartsSerializeArrayList = obRetparts as CustomSerializeArrayList;

                if ( RetPartsSerializeArrayList.Count == 1 )
                {
                    ArrayList lstRstPrm = RetPartsSerializeArrayList[0] as ArrayList;
                    //���i���ݒ�
                    // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                    //FillPartsInfo( lstRstPrm, null );
                    FillPartsInfo( lstRstPrm, null, null );
                    // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                }
                else if ( RetPartsSerializeArrayList.Count == 2 )
                {
                    ArrayList lstRstPrm = RetPartsSerializeArrayList[0] as ArrayList;
                    ArrayList lstPrmPrice = RetPartsSerializeArrayList[1] as ArrayList;
                    // �D�Ǖ��i���ݒ�
                    // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                    //FillJoinSetParts( true, lstRstPrm, lstPrmPrice, null, null );
                    FillJoinSetParts( true, lstRstPrm, lstPrmPrice, null, null, null );
                    // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }

            return status;
        }
        #endregion

        #region [ �������\�b�h(private) ]
        /// <summary>
        /// ���[�U�[OEM�����Ή�
        /// </summary>
        /// <param name="partsSearchUIData">��������</param>
        /// <returns></returns>
        private int UserOEMSearch(PartsSearchUIData partsSearchUIData)
        {
            // -- ADD 2010/05/25 ---------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return 0;
            }
            // -- ADD 2010/05/25 ----------------------<<<

            int status = 0;
            ArrayList PrimePartsInfoList = null;
            ArrayList SetPartsInfoList = null;
            ArrayList PrimePriceList = null;
            ArrayList SetPriceList = null;

            string query = string.Format("{0} = false", partsInfo.UsrSubstParts.OfferKubunColumn.ColumnName);
            PartsInfoDataSet.UsrSubstPartsRow[] rowUsrSubst =
                (PartsInfoDataSet.UsrSubstPartsRow[])partsInfo.UsrSubstParts.Select(query);

            ArrayList lst = new ArrayList();
            for (int i = 0; i < rowUsrSubst.Length; i++)
            {
                OfrPartsCondWork clsPrimeParts = new OfrPartsCondWork();
                clsPrimeParts.MakerCode = rowUsrSubst[i].ChgDestMakerCd;
                clsPrimeParts.PrtsNo = rowUsrSubst[i].ChgDestGoodsNo;
                lst.Add(clsPrimeParts);
            }
            if (lst.Count == 0) // �����p�������X�g��0�Ȃ�I��
                return status;

            //�����[�g�Ăяo��
            bool substFlg = true;
            if (partsSearchUIData.PartsNo != string.Empty) // �i�Ԍ����̏ꍇ
                substFlg = false; // �D�ǌ�������֌������Ȃ��B

            if (iPrimePartsInfoDB == null)
                iPrimePartsInfoDB = MediationPrimePartsInfo.GetRemoteObject();
            int carMakerCd = 0;
            if (carInfoDataSet != null)
            {
                if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                    carMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                    carMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
            }
            status = iPrimePartsInfoDB.GetPartsInfByCtlgPtNo( substFlg, carMakerCd, lst, out PrimePartsInfoList, out PrimePriceList,
                        out SetPartsInfoList, out SetPriceList );
            if (status == 0 && PrimePartsInfoList != null)
            {
                //�f�[�^�e�[�u���փ����[�g�擾���ݒ�
                // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                //FillJoinSetParts(false, PrimePartsInfoList, PrimePriceList, SetPartsInfoList, SetPriceList);
                FillJoinSetParts( false, PrimePartsInfoList, PrimePriceList, SetPartsInfoList, SetPriceList, null );
                // --- UPD m.suzuki 2011/05/18 ----------<<<<<
            }
            return status;
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ���[�U�[OEM�����Ή�
        /// </summary>
        /// <param name="partsSearchUIDataDic">��������</param>
        /// <returns></returns>
        private int UserOEMSearch(Dictionary<int, PartsSearchUIData> partsSearchUIDataDic)
        {
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  
            {
                return 0;
            }

            int status = 0;
            ArrayList PrimePartsInfoList = null;
            ArrayList SetPartsInfoList = null;
            ArrayList PrimePriceList = null;
            ArrayList SetPriceList = null;

            foreach (int key in partsSearchUIDataDic.Keys)
            {
                if (partsSearchUIDataDic[key].SearchCntSetWork.SubstApplyDivCd == 2) // ��֓K�p�S�āF���[�U�[�o�^�i�Ɋւ��čX�ɒ񋟌���
                {
                    string query = string.Format("{0} = false", partsInfoDic[key].UsrSubstParts.OfferKubunColumn.ColumnName);
                    PartsInfoDataSet.UsrSubstPartsRow[] rowUsrSubst =
                        (PartsInfoDataSet.UsrSubstPartsRow[])partsInfoDic[key].UsrSubstParts.Select(query);

                    ArrayList lst = new ArrayList();
                    for (int i = 0; i < rowUsrSubst.Length; i++)
                    {
                        OfrPartsCondWork clsPrimeParts = new OfrPartsCondWork();
                        clsPrimeParts.MakerCode = rowUsrSubst[i].ChgDestMakerCd;
                        clsPrimeParts.PrtsNo = rowUsrSubst[i].ChgDestGoodsNo;
                        lst.Add(clsPrimeParts);
                    }
                    if (lst.Count == 0) // �����p�������X�g��0�Ȃ�I��
                        continue;

                    //�����[�g�Ăяo��
                    bool substFlg = true;
                    if (partsSearchUIDataDic[key].PartsNo != string.Empty) // �i�Ԍ����̏ꍇ
                        substFlg = false; // �D�ǌ�������֌������Ȃ��B

                    if (iPrimePartsInfoDB == null)
                        iPrimePartsInfoDB = MediationPrimePartsInfo.GetRemoteObject();
                    int carMakerCd = 0;
                    if (carInfoDataSet != null)
                    {
                        if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                            carMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                        else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                            carMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
                    }
                    status = iPrimePartsInfoDB.GetPartsInfByCtlgPtNo(substFlg, carMakerCd, lst, out PrimePartsInfoList, out PrimePriceList,
                                out SetPartsInfoList, out SetPriceList);
                    if (status == 0 && PrimePartsInfoList != null)
                    {
                        //�f�[�^�e�[�u���փ����[�g�擾���ݒ�
                        FillJoinSetParts(false, PrimePartsInfoList, PrimePriceList, SetPartsInfoList, SetPriceList, null, key);
                    }
                }
            }
            return status;
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        /// <summary>
        /// ���i��ʐݒ�
        /// </summary>
        private void SetUsrGoodsKind()
        {
            int cnt = partsInfo.UsrGoodsInfo.Count;
            string filter = string.Empty;
            for (int i = 0; i < cnt; i++)
            {
                //if (partsInfo.UsrGoodsInfo[i].OfferKubun != 0)
                //    continue;
                int makerCd = partsInfo.UsrGoodsInfo[i].GoodsMakerCd;
                string goodsNo = partsInfo.UsrGoodsInfo[i].GoodsNo;

                //partsInfo.UsrGoodsInfo[i].GoodsKind = 0;
                filter = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfo.UsrJoinParts.JoinDestMakerCdColumn.ColumnName, makerCd,
                    partsInfo.UsrJoinParts.JoinDestPartsNoColumn.ColumnName, goodsNo);
                if (partsInfo.UsrJoinParts.Select(filter).Length > 0 && (partsInfo.UsrGoodsInfo[i].GoodsKind & (int)GoodsKind.Join) != (int)GoodsKind.Join)
                {
                    partsInfo.UsrGoodsInfo[i].GoodsKind += (int)GoodsKind.Join;
                }
                filter = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfo.UsrSetParts.SubGoodsMakerCdColumn.ColumnName, makerCd,
                    partsInfo.UsrSetParts.SubGoodsNoColumn.ColumnName, goodsNo);
                if (partsInfo.UsrSetParts.Select(filter).Length > 0 && (partsInfo.UsrGoodsInfo[i].GoodsKind & (int)GoodsKind.Set) != (int)GoodsKind.Set)
                {
                    partsInfo.UsrGoodsInfo[i].GoodsKind += (int)GoodsKind.Set;
                }
                filter = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfo.UsrSubstParts.ChgDestMakerCdColumn.ColumnName, makerCd,
                    partsInfo.UsrSubstParts.ChgDestGoodsNoColumn.ColumnName, goodsNo);
                if (partsInfo.UsrSubstParts.Select(filter).Length > 0 && (partsInfo.UsrGoodsInfo[i].GoodsKind & (int)GoodsKind.Subst) != (int)GoodsKind.Subst
                    && (partsInfo.UsrGoodsInfo[i].GoodsKind & (int)GoodsKind.SubstPlrl) != (int)GoodsKind.SubstPlrl)
                {
                    partsInfo.UsrGoodsInfo[i].GoodsKind += (int)GoodsKind.Subst;
                }
                if (partsInfo.UsrGoodsInfo[i].GoodsKind == 0)
                {
                    partsInfo.UsrGoodsInfo[i].GoodsKind = (int)GoodsKind.Parent;
                }
            }
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        ///  ���i��ʐݒ�
        /// </summary>
        /// <param name="key"></param>
        private void SetUsrGoodsKind(int key)
        {
            int cnt = partsInfoDic[key].UsrGoodsInfo.Count;
            string filter = string.Empty;
            for (int i = 0; i < cnt; i++)
            {
                int makerCd = partsInfoDic[key].UsrGoodsInfo[i].GoodsMakerCd;
                string goodsNo = partsInfoDic[key].UsrGoodsInfo[i].GoodsNo;

                filter = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfoDic[key].UsrJoinParts.JoinDestMakerCdColumn.ColumnName, makerCd,
                    partsInfoDic[key].UsrJoinParts.JoinDestPartsNoColumn.ColumnName, goodsNo);
                if (partsInfoDic[key].UsrJoinParts.Select(filter).Length > 0 && (partsInfoDic[key].UsrGoodsInfo[i].GoodsKind & (int)GoodsKind.Join) != (int)GoodsKind.Join)
                {
                    partsInfoDic[key].UsrGoodsInfo[i].GoodsKind += (int)GoodsKind.Join;
                }
                filter = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfoDic[key].UsrSetParts.SubGoodsMakerCdColumn.ColumnName, makerCd,
                    partsInfoDic[key].UsrSetParts.SubGoodsNoColumn.ColumnName, goodsNo);
                if (partsInfoDic[key].UsrSetParts.Select(filter).Length > 0 && (partsInfoDic[key].UsrGoodsInfo[i].GoodsKind & (int)GoodsKind.Set) != (int)GoodsKind.Set)
                {
                    partsInfoDic[key].UsrGoodsInfo[i].GoodsKind += (int)GoodsKind.Set;
                }
                filter = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfoDic[key].UsrSubstParts.ChgDestMakerCdColumn.ColumnName, makerCd,
                    partsInfoDic[key].UsrSubstParts.ChgDestGoodsNoColumn.ColumnName, goodsNo);
                if (partsInfoDic[key].UsrSubstParts.Select(filter).Length > 0 && (partsInfoDic[key].UsrGoodsInfo[i].GoodsKind & (int)GoodsKind.Subst) != (int)GoodsKind.Subst
                    && (partsInfoDic[key].UsrGoodsInfo[i].GoodsKind & (int)GoodsKind.SubstPlrl) != (int)GoodsKind.SubstPlrl)
                {
                    partsInfoDic[key].UsrGoodsInfo[i].GoodsKind += (int)GoodsKind.Subst;
                }
                if (partsInfoDic[key].UsrGoodsInfo[i].GoodsKind == 0)
                {
                    partsInfoDic[key].UsrGoodsInfo[i].GoodsKind = (int)GoodsKind.Parent;
                }
            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # region ���i���[�J�[���擾
        /// <summary>
        /// ���i���[�J�[���擾
        /// </summary>
        /// <param name="makerCode">���i���[�J�R�[�h</param>
        /// <returns>���i���[�J�[����</returns>
        private string GetPartsMakerName(int makerCode)
        {
            string makerName = string.Empty;
            if (_PartsMakerList != null && _PartsMakerList.ContainsKey(makerCode))
            {
                makerName = _PartsMakerList[makerCode].MakerName;// PartsMakerFullName;
            }
            return (makerName);
        }
        # endregion

        # region ���i���[�J�[���X�g�擾
        private void GetPrimePartsSet(ArrayList lstRet, int makerCd, string partsNo)
        {
            string primePartsListKey = makerCd.ToString("d4") + partsNo;

            if ((makerCd == 0) || (partsNo == string.Empty) || lstClgParts.Contains(primePartsListKey))
            {
                return;
            }

            OfrPartsCondWork clsPrimeParts = new OfrPartsCondWork();
            clsPrimeParts.MakerCode = makerCd;
            clsPrimeParts.PrtsNo = partsNo;

            lstClgParts.Add(primePartsListKey);
            lstRet.Add(clsPrimeParts);
        }
        # endregion

        # region �a�k�R�[�h��ʂ̔���
        /// <summary>
        /// �a�k�R�[�h��ʂ̔���
        /// </summary>
        /// <param name="BlCd"></param>
        /// <param name="primeSearchFlg">0:�����D��@1:�D�ǗD��</param>
        /// <returns>0:�������� 1:�D�ǌ�����q�b�g�Ȃ��Ȃ珃������ 2:TBO���� 
        /// 3:����������q�b�g�Ȃ��Ȃ�D�ǌ��� -1:BL���ފY���Ȃ�</returns>
        private int Blkind(int BlCd, int primeSearchFlg)
        {
            int retVal = -1; // 0:�������� 1:�D�ǌ�����q�b�g�Ȃ��Ȃ珃������ 2:TBO���� 3:��q�b�g�Ȃ��Ȃ�D�ǌ��� -1:BL���ފY���Ȃ�

            string filter = string.Empty;
            //if (primeSearchFlg == -1)
            //{
            filter = string.Format("{0} = {1}", bLInfo.TbsPartsCodeColumn.ColumnName, BlCd);
            //}
            //else
            //{
            //    filter = string.Format("{0} = {1} AND {2} = {3}",
            //        bLInfo.TbsPartsCodeColumn.ColumnName, BlCd,
            //        bLInfo.PrimeSearchFlgColumn.ColumnName, primeSearchFlg);
            //}
            BLInfoRow[] blInfoRow = (BLInfoRow[])bLInfo.Select(filter);

            //BL���ފY���Ȃ�
            if (blInfoRow.Length == 0)
            {
                BLInfoRow[] blRows = (BLInfoRow[])ofrBLInfo.Select(filter); // �S�񋟂a�k����
                if (blRows.Length > 0 && blRows[0].EquipGenreCode != 0)
                {
                    retVal = 2;
                }
                else if (blRows.Length > 0 && blRows[0].PrimeSearchFlg != 0)
                {
                    if (primeSearchFlg == 0)
                        retVal = 3;
                    else
                        retVal = 1;
                }
                else
                {
                    retVal = -1;
                }
            }
            //�D��BL
            else if (blInfoRow[0].PrimeSearchFlg != 0)
            {
                if (primeSearchFlg == 0)
                    retVal = 3;
                else
                    retVal = 1;
            }
            else if (blInfoRow[0].EquipGenreCode != 0)
            {
                retVal = 2;
            }
            //BL���ފY���Ȃ�
            else
            {
                retVal = 0;
            }

            return (retVal);
        }
        # endregion

        # region �������i���擾
        /// <summary>
        /// �������i���擾
        /// �w�肳�ꂽ���i�R�[�h�A�i�Ԃɑ΂��ĕ��i�����擾���܂��B
        /// </summary>
        /// <param name="InPara">���i�擾�p�����[�^</param>        
        /// <returns>STATUS</returns>
        private int GetCatalogPartsInf(GetPartsInfPara InPara)
        {
            // -- ADD 2010/05/25 -------------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return 0;
            }
            // -- ADD 2010/05/25 --------------------------<<<

            int status = 0;

            List<PartsModelLnkWork> partsModelLnkWork = null;
            ArrayList RetPartsInf = null;
            ArrayList Retcolor = null;
            ArrayList Rettrim = null;
            ArrayList Retequip = null;
            ArrayList RetPrtSubst = null;
            // --- ADD m.suzuki 2010/04/28 ---------->>>>>
            ArrayList RetPartsInfFS = null;
            ArrayList RetPrtSubstFS = null;
            ArrayList RetPrimPartsFS = null;
            ArrayList RetPrimPriceFS = null;
            ArrayList RetPrimSetFS = null;
            ArrayList RetPrimSetPriceFS = null;
            // --- ADD m.suzuki 2010/04/28 ----------<<<<<

            object obRetparts = null;
            object obcolor = null;
            object obtrim = null;
            object obequip = null;
            object obpartsSubst = null;
            // --- ADD m.suzuki 2010/04/28 ---------->>>>>
            object obRetpartsFS = null;
            object obpartsSubstFS = null;
            object obRetPrimPartsFS = null;
            object obRetPrimPriceFS = null;
            object obRetPrimSetFS = null;
            object obRetPrimSetPriceFS = null;
            // --- ADD m.suzuki 2010/04/28 ----------<<<<<
            long cnt = 0;
            
            #region �T�[�o�[�Z��
            try
            {
                if (iOfferPartsInfo == null)
                    iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();

                // --- UPD m.suzuki 2010/04/28 ---------->>>>>
                //status = iOfferPartsInfo.GetPartsInf(InPara, ref obRetparts, ref obcolor, ref obtrim, ref obequip, ref obpartsSubst, out partsModelLnkWork, out cnt);//20070327 iwa add

                # region [���R�����p �ǉ�����]
                // ���R�������i�̒��o���ʂ��L��ꍇ�̂݁A�ǉ��������Z�b�g����B
                // �i���ǉ��������Z�b�g���Ȃ������ꍇ�̓���͕ύX�O�Ɠ��l�j
                if ( _freeSearchPartsSRetDic != null && _freeSearchPartsSRetDic.Count > 0 )
                {
                    ArrayList fsParaList = new ArrayList();
                    foreach ( List<FreeSearchPartsSRetWork> retWorkList in _freeSearchPartsSRetDic.Values )
                    {
                        if ( retWorkList != null && retWorkList.Count > 0 )
                        {
                            // �i�ԁE���[�J�[�����Z�b�g(�P�P��)
                            // �@��List���͓���i�ԁE���[�J�[�Ŋi�[���Ă���̂�[0]�Ԗڂ�
                            //     �i�ԁE���[�J�[�����Z�b�g���Ď��̃��X�g�ɐi�ށB
                            OfrPrtsSrchCndWork ofrCndWork = new OfrPrtsSrchCndWork();
                            ofrCndWork.PrtsNo = retWorkList[0].GoodsNo;
                            ofrCndWork.MakerCode = retWorkList[0].GoodsMakerCd;
                            fsParaList.Add( ofrCndWork );
                        }
                    }
                    InPara.SearchKeyList = fsParaList;
                }
                # endregion

                status = iOfferPartsInfo.GetPartsInf( InPara, ref obRetparts, ref obcolor, ref obtrim, ref obequip, ref obpartsSubst, out partsModelLnkWork,
                                                      ref obRetpartsFS, ref obpartsSubstFS,
                                                      ref obRetPrimPartsFS, ref obRetPrimPriceFS, ref obRetPrimSetFS, ref obRetPrimSetPriceFS,
                                                      out cnt );
                // --- UPD m.suzuki 2010/04/28 ----------<<<<<
                if (status == 0)
                {
                    CustomSerializeArrayList RetPartsSerializeArrayList = obRetparts as CustomSerializeArrayList;
                    CustomSerializeArrayList colorSerializeArrayList = obcolor as CustomSerializeArrayList;
                    CustomSerializeArrayList trimSerializeArrayList = obtrim as CustomSerializeArrayList;
                    CustomSerializeArrayList equipSerializeArrayList = obequip as CustomSerializeArrayList;
                    CustomSerializeArrayList substSerializeArrayList = obpartsSubst as CustomSerializeArrayList;

                    if (RetPartsSerializeArrayList.Count != 0)
                        RetPartsInf = (ArrayList)RetPartsSerializeArrayList[0];
                    if (colorSerializeArrayList.Count != 0)
                        Retcolor = (ArrayList)colorSerializeArrayList[0];
                    if (trimSerializeArrayList.Count != 0)
                        Rettrim = (ArrayList)trimSerializeArrayList[0];
                    if (equipSerializeArrayList.Count != 0)
                        Retequip = (ArrayList)equipSerializeArrayList[0];
                    if (substSerializeArrayList.Count != 0)
                        RetPrtSubst = (ArrayList)substSerializeArrayList[0];

                    //���i���ݒ�
                    // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                    //FillPartsInfo(RetPartsInf, partsModelLnkWork);
                    FillPartsInfo( RetPartsInf, partsModelLnkWork, InPara );
                    // --- UPD m.suzuki 2011/05/18 ----------<<<<<

                    //�J���[���ݒ�
                    FillOfrColorTable(Retcolor);

                    //�g�������ݒ�
                    FillOfrTrimTable(Rettrim);

                    //�������ݒ�
                    FillOfrEquipTable(Retequip);

                    if (RetPrtSubst != null)
                    {
                        string partsName = partsInfo.PartsInfo[0].PartsName;
                        string partsNameKana = partsInfo.PartsInfo[0].PartsNameKana;
                        int tbsPartsCdDerivedNo = partsInfo.PartsInfo[0].TbsPartsCdDerivedNo; // 2010/02/25 Add
                        //��֏��ݒ�
                        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                        //FillOfrSubstTable(RetPrtSubst, partsName, partsNameKana);
                        FillOfrSubstTable( RetPrtSubst, partsName, partsNameKana, InPara );
                        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                    }
                }

                // --- UPD m.suzuki 2010/04/28 ---------->>>>>
                # region [���R�������o���ʂ̓W�J]
                // �f�B�N�V���i����null�E�����`�F�b�N�ŃI�v�V�����`�F�b�N�����˂�
                if ( _freeSearchPartsSRetDic != null && _freeSearchPartsSRetDic.Count > 0 )
                {
                    //--------------------------------------------------
                    // ���R�������i�{�񋟏���
                    //--------------------------------------------------
                    # region [�񋟏���]
                    _retPartsInfDic = new Dictionary<string, RetPartsInf>();

                    // �񋟏����̒��o���ʂ��f�B�N�V���i���Ɋi�[����B
                    RetPartsInfFS = GetRetList( obRetpartsFS );
                    if ( RetPartsInfFS != null )
                    {
                        foreach ( RetPartsInf partsInf in RetPartsInfFS )
                        {
                            string key = CreateFreeSearchRetDicKey( partsInf.CatalogPartsMakerCd, partsInf.ClgPrtsNoWithHyphen );
                            if ( !_retPartsInfDic.ContainsKey( key ) )
                            {
                                _retPartsInfDic.Add( key, partsInf );
                            }
                        }
                    }
                    # endregion

                    //--------------------------------------------------
                    // ���R�������i�{�񋟗D��
                    //--------------------------------------------------
                    # region [�񋟗D��]
                    _primPartsRetDic = new Dictionary<string, OfferJoinPartsRetWork>();

                    // �񋟗D�ǂ̒��o���ʂ��f�B�N�V���i���Ɋi�[����B
                    RetPrimPartsFS = GetRetList( obRetPrimPartsFS );
                    if ( RetPrimPartsFS != null )
                    {
                        foreach ( OfferJoinPartsRetWork partsInf in RetPrimPartsFS )
                        {
                            string key = CreateFreeSearchRetDicKey( partsInf.JoinDestMakerCd, partsInf.JoinDestPartsNo );
                            if ( !_primPartsRetDic.ContainsKey( key ) )
                            {
                                _primPartsRetDic.Add( key, partsInf );
                            }
                        }
                    }
                    # endregion

                    # region [�񋟗D�ǉ��i]
                    _primPriceRetDic = new Dictionary<string, List<OfferJoinPriceRetWork>>();

                    // �񋟗D�ǂ̒��o���ʂ��f�B�N�V���i���Ɋi�[����B
                    RetPrimPriceFS = GetRetList( obRetPrimPriceFS );
                    if ( RetPrimPriceFS != null )
                    {
                        foreach ( OfferJoinPriceRetWork partsInf in RetPrimPriceFS )
                        {
                            // ���̃^�C�~���O�ŉ��i�J�n�����`�F�b�N����i�����̓��t�̉��i�͏��O����ׁj
                            if ( partsInf.PriceStartDate > InPara.PriceDate )
                            {
                                continue;
                            }

                            string key = CreateFreeSearchRetDicKey( partsInf.PartsMakerCd, partsInf.PrimePartsNoWithH );
                            if ( !_primPriceRetDic.ContainsKey( key ) )
                            {
                                _primPriceRetDic.Add( key, new List<OfferJoinPriceRetWork>() );
                            }
                            _primPriceRetDic[key].Add( partsInf );
                        }
                    }
                    # endregion

                    //--------------------------------------------------
                    // ���R�������i���o���ʂ̓W�J
                    //--------------------------------------------------
                    FillFreeSearchPartsInfo( _freeSearchPartsSRetDic );

                    //--------------------------------------------------
                    // ���R�����{������ւ̓W�J
                    //--------------------------------------------------
                    # region [���R�����{�������]
                    RetPrtSubstFS = GetRetList( obpartsSubstFS );
                    if ( RetPrtSubstFS != null )
                    {
                        // ��֏��ݒ�
                        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                        //FillOfrSubstTable( RetPrtSubstFS, _freeSearchPartsSRetWork.BLGoodsFullName, _freeSearchPartsSRetWork.BLGoodsFullName );
                        FillOfrSubstTable( RetPrtSubstFS, _freeSearchPartsSRetWork.BLGoodsFullName, _freeSearchPartsSRetWork.BLGoodsFullName, InPara );
                        // --- UPD m.suzuki 2011/05/18 ----------<<<<<

                        // ��֏������ɕێ����Ă���f�[�^�e�[�u�����X�V����
                        ReflectTableByPartsSubst( RetPrtSubstFS );
                    }
                    # endregion

                    //--------------------------------------------------
                    // ���R�����{�Z�b�g�̓W�J
                    //--------------------------------------------------
                    # region [���R�����{�Z�b�g]
                    RetPrimSetFS = GetRetList( obRetPrimSetFS );
                    RetPrimSetPriceFS = GetRetList( obRetPrimSetPriceFS );

                    if ( RetPrimSetFS != null && RetPrimSetPriceFS != null )
                    {
                        // �Z�b�g�E�Z�b�g���i�W�J
                        FillOfrSetInfo( RetPrimSetFS, RetPrimSetPriceFS );
                    }
                    # endregion

                }
                # endregion
                // --- UPD m.suzuki 2010/04/28 ----------<<<<<

            }
            catch
            {

            }
            #endregion

            return status;
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// �������i���擾
        /// �w�肳�ꂽ���i�R�[�h�A�i�Ԃɑ΂��ĕ��i�����擾���܂��B
        /// </summary>
        /// <param name="InParaDic">���i�擾�p�����[�^</param>        
        /// <returns>STATUS</returns>
        private int GetCatalogPartsInf(Dictionary<int, GetPartsInfPara> InParaDic)
        {
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return 0;
            }

            int status = 0;
            // UPD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��16.�����i�������ǑΉ� ---------------------------------->>>>>
            //GetPartsInfPara InPara;
            ArrayList inParaList = new ArrayList();
            // UPD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��16.�����i�������ǑΉ� ----------------------------------<<<<<

            List<PartsModelLnkWork> partsModelLnkWork = null;
            ArrayList RetPartsInf = null;
            ArrayList Retcolor = null;
            ArrayList Rettrim = null;
            ArrayList Retequip = null;
            ArrayList RetPrtSubst = null;
            ArrayList RetPartsInfFS = null;
            ArrayList RetPrtSubstFS = null;
            ArrayList RetPrimPartsFS = null;
            ArrayList RetPrimPriceFS = null;
            ArrayList RetPrimSetFS = null;
            ArrayList RetPrimSetPriceFS = null;

            object obRetparts = null;
            object obcolor = null;
            object obtrim = null;
            object obequip = null;
            object obpartsSubst = null;
            object obRetpartsFS = null;
            object obpartsSubstFS = null;
            object obRetPrimPartsFS = null;
            object obRetPrimPriceFS = null;
            object obRetPrimSetFS = null;
            object obRetPrimSetPriceFS = null;
            long cnt = 0;

            #region �T�[�o�[�Z��
            try
            {
                if (iOfferPartsInfo == null)
                    iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();

                // UPD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��16.�����i�������ǑΉ� ---------------------------------->>>>>
                #region ���x���P�̂��ߍ폜
                //foreach (int dickey in InParaDic.Keys)
                //{
                //    InPara = InParaDic[dickey];

                //    # region [���R�����p �ǉ�����]
                //    // ���R�������i�̒��o���ʂ��L��ꍇ�̂݁A�ǉ��������Z�b�g����B
                //    // �i���ǉ��������Z�b�g���Ȃ������ꍇ�̓���͕ύX�O�Ɠ��l�j
                //    if (_freeSearchPartsSRetDic != null && _freeSearchPartsSRetDic.Count > 0)
                //    {
                //        ArrayList fsParaList = new ArrayList();
                //        foreach (KeyValuePair<string, List<FreeSearchPartsSRetWork>> retWorkList in _freeSearchPartsSRetDic)
                //        {
                //            if (retWorkList.Key.Substring(0,2) == dickey.ToString("00") &&
                //                retWorkList.Value != null && retWorkList.Value.Count > 0)
                //            {
                //                // �i�ԁE���[�J�[�����Z�b�g(�P�P��)
                //                // �@��List���͓���i�ԁE���[�J�[�Ŋi�[���Ă���̂�[0]�Ԗڂ�
                //                //     �i�ԁE���[�J�[�����Z�b�g���Ď��̃��X�g�ɐi�ށB
                //                OfrPrtsSrchCndWork ofrCndWork = new OfrPrtsSrchCndWork();
                //                List<FreeSearchPartsSRetWork> List = retWorkList.Value;
                //                ofrCndWork.PrtsNo = List[0].GoodsNo;
                //                ofrCndWork.MakerCode = List[0].GoodsMakerCd;
                //                fsParaList.Add(ofrCndWork);
                //            }
                //        }
                //        InPara.SearchKeyList = fsParaList;
                //    }
                //    # endregion

                //    status = iOfferPartsInfo.GetPartsInf(InPara, ref obRetparts, ref obcolor, ref obtrim, ref obequip, ref obpartsSubst, out partsModelLnkWork,
                //                                          ref obRetpartsFS, ref obpartsSubstFS,
                //                                          ref obRetPrimPartsFS, ref obRetPrimPriceFS, ref obRetPrimSetFS, ref obRetPrimSetPriceFS,
                //                                          out cnt);
                //    if (status == 0)
                //    {
                //        CustomSerializeArrayList RetPartsSerializeArrayList = obRetparts as CustomSerializeArrayList;
                //        CustomSerializeArrayList colorSerializeArrayList = obcolor as CustomSerializeArrayList;
                //        CustomSerializeArrayList trimSerializeArrayList = obtrim as CustomSerializeArrayList;
                //        CustomSerializeArrayList equipSerializeArrayList = obequip as CustomSerializeArrayList;
                //        CustomSerializeArrayList substSerializeArrayList = obpartsSubst as CustomSerializeArrayList;

                //        if (RetPartsSerializeArrayList.Count != 0)
                //            RetPartsInf = (ArrayList)RetPartsSerializeArrayList[0];
                //        if (colorSerializeArrayList.Count != 0)
                //            Retcolor = (ArrayList)colorSerializeArrayList[0];
                //        if (trimSerializeArrayList.Count != 0)
                //            Rettrim = (ArrayList)trimSerializeArrayList[0];
                //        if (equipSerializeArrayList.Count != 0)
                //            Retequip = (ArrayList)equipSerializeArrayList[0];
                //        if (substSerializeArrayList.Count != 0)
                //            RetPrtSubst = (ArrayList)substSerializeArrayList[0];

                //        // ADD 2014/04/17 SCM�����񓚏������x���P ����ýď�Q��77�Ή� -------------------------------->>>>>
                //        try
                //        {
                //        // ADD 2014/04/17 SCM�����񓚏������x���P ����ýď�Q��77�Ή� --------------------------------<<<<<
                //            //���i���ݒ�
                //            FillPartsInfo(RetPartsInf, partsModelLnkWork, InPara, dickey);

                //            //�J���[���ݒ�
                //            FillOfrColorTable(Retcolor, dickey);

                //            //�g�������ݒ�
                //            FillOfrTrimTable(Rettrim, dickey);

                //            //�������ݒ�
                //            FillOfrEquipTable(Retequip, dickey);

                //            if (RetPrtSubst != null)
                //            {
                //                string partsName = partsInfoDic[dickey].PartsInfo[0].PartsName;
                //                string partsNameKana = partsInfoDic[dickey].PartsInfo[0].PartsNameKana;
                //                int tbsPartsCdDerivedNo = partsInfoDic[dickey].PartsInfo[0].TbsPartsCdDerivedNo;
                //                //��֏��ݒ�
                //                FillOfrSubstTable(RetPrtSubst, partsName, partsNameKana, InPara, dickey);
                //            }
                //        // ADD 2014/04/17 SCM�����񓚏������x���P ����ýď�Q��77�Ή� -------------------------------->>>>>
                //        }
                //        catch
                //        {
                //            continue;
                //        }
                //        // ADD 2014/04/17 SCM�����񓚏������x���P ����ýď�Q��77�Ή� --------------------------------<<<<<
                //    }

                //    # region [���R�������o���ʂ̓W�J]
                //    // �f�B�N�V���i����null�E�����`�F�b�N�ŃI�v�V�����`�F�b�N�����˂�
                //    if (_freeSearchPartsSRetDic != null && _freeSearchPartsSRetDic.Count > 0 &&
                //        InPara.SearchKeyList != null && InPara.SearchKeyList.Count != 0)
                //    {
                //        //--------------------------------------------------
                //        // ���R�������i�{�񋟏���
                //        //--------------------------------------------------
                //        # region [�񋟏���]
                //        _retPartsInfDic = new Dictionary<string, RetPartsInf>();

                //        // �񋟏����̒��o���ʂ��f�B�N�V���i���Ɋi�[����B
                //        RetPartsInfFS = GetRetList(obRetpartsFS);
                //        if (RetPartsInfFS != null)
                //        {
                //            foreach (RetPartsInf partsInf in RetPartsInfFS)
                //            {
                //                string key = CreateFreeSearchRetDicKey(dickey, partsInf.CatalogPartsMakerCd, partsInf.ClgPrtsNoWithHyphen);
                //                if (!_retPartsInfDic.ContainsKey(key))
                //                {
                //                    _retPartsInfDic.Add(key, partsInf);
                //                }
                //            }
                //        }
                //        # endregion

                //        //--------------------------------------------------
                //        // ���R�������i�{�񋟗D��
                //        //--------------------------------------------------
                //        # region [�񋟗D��]
                //        _primPartsRetDic = new Dictionary<string, OfferJoinPartsRetWork>();

                //        // �񋟗D�ǂ̒��o���ʂ��f�B�N�V���i���Ɋi�[����B
                //        RetPrimPartsFS = GetRetList(obRetPrimPartsFS);
                //        if (RetPrimPartsFS != null)
                //        {
                //            foreach (OfferJoinPartsRetWork partsInf in RetPrimPartsFS)
                //            {
                //                string key = CreateFreeSearchRetDicKey(dickey, partsInf.JoinDestMakerCd, partsInf.JoinDestPartsNo);
                //                if (!_primPartsRetDic.ContainsKey(key))
                //                {
                //                    _primPartsRetDic.Add(key, partsInf);
                //                }
                //            }
                //        }
                //        # endregion

                //        # region [�񋟗D�ǉ��i]
                //        _primPriceRetDic = new Dictionary<string, List<OfferJoinPriceRetWork>>();

                //        // �񋟗D�ǂ̒��o���ʂ��f�B�N�V���i���Ɋi�[����B
                //        RetPrimPriceFS = GetRetList(obRetPrimPriceFS);
                //        if (RetPrimPriceFS != null)
                //        {
                //            foreach (OfferJoinPriceRetWork partsInf in RetPrimPriceFS)
                //            {
                //                // ���̃^�C�~���O�ŉ��i�J�n�����`�F�b�N����i�����̓��t�̉��i�͏��O����ׁj
                //                if (partsInf.PriceStartDate > InPara.PriceDate)
                //                {
                //                    continue;
                //                }

                //                string key = CreateFreeSearchRetDicKey(dickey, partsInf.PartsMakerCd, partsInf.PrimePartsNoWithH);
                //                if (!_primPriceRetDic.ContainsKey(key))
                //                {
                //                    _primPriceRetDic.Add(key, new List<OfferJoinPriceRetWork>());
                //                }
                //                _primPriceRetDic[key].Add(partsInf);
                //            }
                //        }
                //        # endregion

                //        //--------------------------------------------------
                //        // ���R�������i���o���ʂ̓W�J
                //        //--------------------------------------------------
                //        FillFreeSearchPartsInfo(_freeSearchPartsSRetDic, dickey);

                //        //--------------------------------------------------
                //        // ���R�����{������ւ̓W�J
                //        //--------------------------------------------------
                //        # region [���R�����{�������]
                //        RetPrtSubstFS = GetRetList(obpartsSubstFS);
                //        if (RetPrtSubstFS != null)
                //        {
                //            // ��֏��ݒ�
                //            FillOfrSubstTable(RetPrtSubstFS, _freeSearchPartsSRetWork.BLGoodsFullName, _freeSearchPartsSRetWork.BLGoodsFullName, InPara, dickey);

                //            // ��֏������ɕێ����Ă���f�[�^�e�[�u�����X�V����
                //            ReflectTableByPartsSubst(RetPrtSubstFS, dickey);
                //        }
                //        # endregion

                //        //--------------------------------------------------
                //        // ���R�����{�Z�b�g�̓W�J
                //        //--------------------------------------------------
                //        # region [���R�����{�Z�b�g]
                //        RetPrimSetFS = GetRetList(obRetPrimSetFS);
                //        RetPrimSetPriceFS = GetRetList(obRetPrimSetPriceFS);

                //        if (RetPrimSetFS != null && RetPrimSetPriceFS != null)
                //        {
                //            // �Z�b�g�E�Z�b�g���i�W�J
                //            FillOfrSetInfo(RetPrimSetFS, RetPrimSetPriceFS, dickey);
                //        }
                //        # endregion
                //    }
                //    # endregion
                //}
                //status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                #endregion //���x���P�̂��ߍ폜

                foreach (int dickey in InParaDic.Keys)
                {
                    GetPartsInfPara InPara = InParaDic[dickey];

                    # region [���R�����p �ǉ�����]
                    // ���R�������i�̒��o���ʂ��L��ꍇ�̂݁A�ǉ��������Z�b�g����B
                    // �i���ǉ��������Z�b�g���Ȃ������ꍇ�̓���͕ύX�O�Ɠ��l�j
                    if (_freeSearchPartsSRetDic != null && _freeSearchPartsSRetDic.Count > 0)
                    {
                        ArrayList fsParaList = new ArrayList();
                        foreach (KeyValuePair<string, List<FreeSearchPartsSRetWork>> retWorkList in _freeSearchPartsSRetDic)
                        {
                            if (retWorkList.Key.Substring(0, 2) == dickey.ToString("00") &&
                                retWorkList.Value != null && retWorkList.Value.Count > 0)
                            {
                                // �i�ԁE���[�J�[�����Z�b�g(�P�P��)
                                // �@��List���͓���i�ԁE���[�J�[�Ŋi�[���Ă���̂�[0]�Ԗڂ�
                                //     �i�ԁE���[�J�[�����Z�b�g���Ď��̃��X�g�ɐi�ށB
                                OfrPrtsSrchCndWork ofrCndWork = new OfrPrtsSrchCndWork();
                                List<FreeSearchPartsSRetWork> List = retWorkList.Value;
                                ofrCndWork.PrtsNo = List[0].GoodsNo;
                                ofrCndWork.MakerCode = List[0].GoodsMakerCd;
                                fsParaList.Add(ofrCndWork);
                            }
                        }
                        InPara.SearchKeyList = fsParaList;
                    }
                    # endregion
                    inParaList.Add(InPara);
                }

                status = iOfferPartsInfo.GetPartsInf(inParaList, ref obRetparts, ref obcolor, ref obtrim, ref obequip, ref obpartsSubst, out partsModelLnkWork,
                                                      ref obRetpartsFS, ref obpartsSubstFS,
                                                      ref obRetPrimPartsFS, ref obRetPrimPriceFS, ref obRetPrimSetFS, ref obRetPrimSetPriceFS,
                                                      out cnt);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    CustomSerializeArrayList RetPartsSerializeArrayList = obRetparts as CustomSerializeArrayList;
                    CustomSerializeArrayList colorSerializeArrayList = obcolor as CustomSerializeArrayList;
                    CustomSerializeArrayList trimSerializeArrayList = obtrim as CustomSerializeArrayList;
                    CustomSerializeArrayList equipSerializeArrayList = obequip as CustomSerializeArrayList;
                    CustomSerializeArrayList substSerializeArrayList = obpartsSubst as CustomSerializeArrayList;

                    List<int> dicKeyList = new List<int>(InParaDic.Keys);

                    if (RetPartsSerializeArrayList != null && RetPartsSerializeArrayList.Count != 0)
                    {
                        for (int i = 0; i < RetPartsSerializeArrayList.Count; i++)
                        {
                            if (RetPartsSerializeArrayList.Count != 0)
                            {
                                RetPartsInf = (ArrayList)RetPartsSerializeArrayList[i];
                                // ���X�g���̃f�[�^���P���ŃR�[�h�Ȃ��̎�null�l�Ƃ���
                                List<RetPartsInf> retPartsInfwkList = new List<RetPartsInf>((RetPartsInf[])RetPartsInf.ToArray(typeof(RetPartsInf)));
                                if (retPartsInfwkList.Count == 1 && retPartsInfwkList[0].ClgPrtsNoWithHyphen.Trim().Length == 0)
                                {
                                    RetPartsInf = null;
                                }
                            }
                            if (colorSerializeArrayList.Count != 0)
                            {
                                Retcolor = (ArrayList)colorSerializeArrayList[i];
                                // ���X�g���̃f�[�^���P���ŃR�[�h�Ȃ��̎�null�l�Ƃ���
                                List<PartsColorWork> retcolorwkList = new List<PartsColorWork>((PartsColorWork[])Retcolor.ToArray(typeof(PartsColorWork)));
                                if (retcolorwkList.Count == 1 && retcolorwkList[0].PartsProperNo == 0)
                                {
                                    Retcolor = null;
                                }
                            }
                            if (trimSerializeArrayList.Count != 0)
                            {
                                Rettrim = (ArrayList)trimSerializeArrayList[i];
                                // ���X�g���̃f�[�^���P���ŃR�[�h�Ȃ��̎�null�l�Ƃ���
                                List<PartsTrimWork> rettrimwkList = new List<PartsTrimWork>((PartsTrimWork[])Rettrim.ToArray(typeof(PartsTrimWork)));
                                if (rettrimwkList.Count == 1 && rettrimwkList[0].PartsProperNo == 0)
                                {
                                    Rettrim = null;
                                }
                            }
                            if (equipSerializeArrayList.Count != 0)
                            {
                                Retequip = (ArrayList)equipSerializeArrayList[i];
                                // ���X�g���̃f�[�^���P���ŃR�[�h�Ȃ��̎�null�l�Ƃ���
                                List<PartsEquipWork> retequipwkList = new List<PartsEquipWork>((PartsEquipWork[])Retequip.ToArray(typeof(PartsEquipWork)));
                                if (retequipwkList.Count == 1 && retequipwkList[0].PartsProperNo == 0)
                                {
                                    Retequip = null;
                                }
                            }
                            if (substSerializeArrayList.Count != 0)
                            {
                                RetPrtSubst = (ArrayList)substSerializeArrayList[i];
                                // ���X�g���̃f�[�^���P���ŃR�[�h�Ȃ��̎�null�l�Ƃ���
                                List<PartsSubstWork> retPrtSubstwkList = new List<PartsSubstWork>((PartsSubstWork[])RetPrtSubst.ToArray(typeof(PartsSubstWork)));
                                if (retPrtSubstwkList.Count == 1 && retPrtSubstwkList[0].NewPartsNoWithHyphen.Trim().Length == 0)
                                {
                                    RetPrtSubst = null;
                                }
                            }

                            GetPartsInfPara retInPara = (GetPartsInfPara)inParaList[i];

                            int retdicKey = dicKeyList[i];

                            try
                            {
                                //���i���ݒ�
                                FillPartsInfo(RetPartsInf, partsModelLnkWork, retInPara, retdicKey);

                                //�J���[���ݒ�
                                FillOfrColorTable(Retcolor, retdicKey);

                                //�g�������ݒ�
                                FillOfrTrimTable(Rettrim, retdicKey);

                                //�������ݒ�
                                FillOfrEquipTable(Retequip, retdicKey);

                                if (RetPrtSubst != null)
                                {
                                    string partsName = partsInfoDic[retdicKey].PartsInfo[0].PartsName;
                                    string partsNameKana = partsInfoDic[retdicKey].PartsInfo[0].PartsNameKana;
                                    int tbsPartsCdDerivedNo = partsInfoDic[retdicKey].PartsInfo[0].TbsPartsCdDerivedNo;
                                    //��֏��ݒ�
                                    FillOfrSubstTable(RetPrtSubst, partsName, partsNameKana, retInPara, retdicKey);
                                }
                            }
                            catch
                            {
                                continue;
                            }

                            # region [���R�������o���ʂ̓W�J]
                            // �f�B�N�V���i����null�E�����`�F�b�N�ŃI�v�V�����`�F�b�N�����˂�
                            if (_freeSearchPartsSRetDic != null && _freeSearchPartsSRetDic.Count > 0 &&
                                retInPara.SearchKeyList != null && retInPara.SearchKeyList.Count != 0)
                            {
                                //--------------------------------------------------
                                // ���R�������i�{�񋟏���
                                //--------------------------------------------------
                                # region [�񋟏���]
                                _retPartsInfDic = new Dictionary<string, RetPartsInf>();

                                // �񋟏����̒��o���ʂ��f�B�N�V���i���Ɋi�[����B
                                RetPartsInfFS = GetRetList(obRetpartsFS);
                                // ���X�g���̃f�[�^���P���ŃR�[�h�Ȃ��̎�null�l�Ƃ���
                                List<RetPartsInf> retPartsInfFSwkList = new List<RetPartsInf>((RetPartsInf[])RetPartsInfFS.ToArray(typeof(RetPartsInf)));
                                if (retPartsInfFSwkList.Count == 1 && retPartsInfFSwkList[0].NewPrtsNoWithHyphen.Trim().Length == 0)
                                {
                                    RetPartsInfFS = null;
                                }
                                if (RetPartsInfFS != null)
                                {
                                    foreach (RetPartsInf partsInf in RetPartsInfFS)
                                    {
                                        string key = CreateFreeSearchRetDicKey(retdicKey, partsInf.CatalogPartsMakerCd, partsInf.ClgPrtsNoWithHyphen);
                                        if (!_retPartsInfDic.ContainsKey(key))
                                        {
                                            _retPartsInfDic.Add(key, partsInf);
                                        }
                                    }
                                }
                                # endregion

                                //--------------------------------------------------
                                // ���R�������i�{�񋟗D��
                                //--------------------------------------------------
                                # region [�񋟗D��]
                                _primPartsRetDic = new Dictionary<string, OfferJoinPartsRetWork>();

                                // �񋟗D�ǂ̒��o���ʂ��f�B�N�V���i���Ɋi�[����B
                                RetPrimPartsFS = GetRetList(obRetPrimPartsFS);
                                // ���X�g���̃f�[�^���P���ŃR�[�h�Ȃ��̎�null�l�Ƃ���
                                List<OfferJoinPartsRetWork> retPrimPartsFSwkList = new List<OfferJoinPartsRetWork>((OfferJoinPartsRetWork[])RetPrimPartsFS.ToArray(typeof(OfferJoinPartsRetWork)));
                                if (retPrimPartsFSwkList.Count == 1 && retPrimPartsFSwkList[0].JoinSourPartsNoWithH.Trim().Length == 0)
                                {
                                    RetPrimPartsFS = null;
                                }
                                if (RetPrimPartsFS != null)
                                {
                                    foreach (OfferJoinPartsRetWork partsInf in RetPrimPartsFS)
                                    {
                                        string key = CreateFreeSearchRetDicKey(retdicKey, partsInf.JoinDestMakerCd, partsInf.JoinDestPartsNo);
                                        if (!_primPartsRetDic.ContainsKey(key))
                                        {
                                            _primPartsRetDic.Add(key, partsInf);
                                        }
                                    }
                                }
                                # endregion

                                # region [�񋟗D�ǉ��i]
                                _primPriceRetDic = new Dictionary<string, List<OfferJoinPriceRetWork>>();

                                // �񋟗D�ǂ̒��o���ʂ��f�B�N�V���i���Ɋi�[����B
                                RetPrimPriceFS = GetRetList(obRetPrimPriceFS);
                                // ���X�g���̃f�[�^���P���ŃR�[�h�Ȃ��̎�null�l�Ƃ���
                                List<OfferJoinPriceRetWork> retPrimPriceFSwkList = new List<OfferJoinPriceRetWork>((OfferJoinPriceRetWork[])RetPrimPriceFS.ToArray(typeof(OfferJoinPriceRetWork)));
                                if (retPrimPriceFSwkList.Count == 1 && retPrimPriceFSwkList[0].PrimePartsNoWithH.Trim().Length == 0)
                                {
                                    RetPrimPriceFS = null;
                                }
                                if (RetPrimPriceFS != null)
                                {
                                    foreach (OfferJoinPriceRetWork partsInf in RetPrimPriceFS)
                                    {
                                        // ���̃^�C�~���O�ŉ��i�J�n�����`�F�b�N����i�����̓��t�̉��i�͏��O����ׁj
                                        if (partsInf.PriceStartDate > retInPara.PriceDate)
                                        {
                                            continue;
                                        }

                                        string key = CreateFreeSearchRetDicKey(retdicKey, partsInf.PartsMakerCd, partsInf.PrimePartsNoWithH);
                                        if (!_primPriceRetDic.ContainsKey(key))
                                        {
                                            _primPriceRetDic.Add(key, new List<OfferJoinPriceRetWork>());
                                        }
                                        _primPriceRetDic[key].Add(partsInf);
                                    }
                                }
                                # endregion

                                //--------------------------------------------------
                                // ���R�������i���o���ʂ̓W�J
                                //--------------------------------------------------
                                FillFreeSearchPartsInfo(_freeSearchPartsSRetDic, retdicKey);

                                //--------------------------------------------------
                                // ���R�����{������ւ̓W�J
                                //--------------------------------------------------
                                # region [���R�����{�������]
                                RetPrtSubstFS = GetRetList(obpartsSubstFS);
                                // ���X�g���̃f�[�^���P���ŃR�[�h�Ȃ��̎�null�l�Ƃ���
                                List<PartsSubstWork> retPrtSubstFSwkList = new List<PartsSubstWork>((PartsSubstWork[])RetPrtSubstFS.ToArray(typeof(PartsSubstWork)));
                                if (retPrtSubstFSwkList.Count == 1 && retPrtSubstFSwkList[0].NewPartsNoWithHyphen.Trim().Length == 0)
                                {
                                    RetPrtSubstFS = null;
                                }
                                if (RetPrtSubstFS != null)
                                {
                                    // ��֏��ݒ�
                                    FillOfrSubstTable(RetPrtSubstFS, _freeSearchPartsSRetWork.BLGoodsFullName, _freeSearchPartsSRetWork.BLGoodsFullName, retInPara, retdicKey);

                                    // ��֏������ɕێ����Ă���f�[�^�e�[�u�����X�V����
                                    ReflectTableByPartsSubst(RetPrtSubstFS, retdicKey);
                                }
                                # endregion

                                //--------------------------------------------------
                                // ���R�����{�Z�b�g�̓W�J
                                //--------------------------------------------------
                                # region [���R�����{�Z�b�g]
                                RetPrimSetFS = GetRetList(obRetPrimSetFS);
                                // ���X�g���̃f�[�^���P���ŃR�[�h�Ȃ��̎�null�l�Ƃ���
                                List<OfferSetPartsRetWork> retPrimSetFSwkList = new List<OfferSetPartsRetWork>((OfferSetPartsRetWork[])RetPrimSetFS.ToArray(typeof(OfferSetPartsRetWork)));
                                if (retPrimSetFSwkList.Count == 1 && retPrimSetFSwkList[0].SetMainPartsNo.Trim().Length == 0)
                                {
                                    RetPrimSetFS = null;
                                }
                                RetPrimSetPriceFS = GetRetList(obRetPrimSetPriceFS);
                                // ���X�g���̃f�[�^���P���ŃR�[�h�Ȃ��̎�null�l�Ƃ���
                                List<OfferJoinPriceRetWork> retPrimSetPriceFSwkList = new List<OfferJoinPriceRetWork>((OfferJoinPriceRetWork[])RetPrimSetPriceFS.ToArray(typeof(OfferJoinPriceRetWork)));
                                if (retPrimSetPriceFSwkList.Count == 1 && retPrimSetPriceFSwkList[0].PrimePartsNoWithH.Trim().Length == 0)
                                {
                                    RetPrimSetPriceFS = null;
                                }

                                if (RetPrimSetFS != null && RetPrimSetPriceFS != null)
                                {
                                    // �Z�b�g�E�Z�b�g���i�W�J
                                    FillOfrSetInfo(RetPrimSetFS, RetPrimSetPriceFS, retdicKey);
                                }
                                # endregion
                            }
                            # endregion

                        }

                    }

                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                // UPD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��16.�����i�������ǑΉ� ----------------------------------<<<<<
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            #endregion

            return status;
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        // 2009/11/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �������i���擾
        /// �w�肳�ꂽ���i�R�[�h�A�i�Ԃɑ΂��ĕ��i�����擾���܂��B
        /// </summary>
        /// <param name="InPara">���i�擾�p�����[�^</param>        
        /// <returns>STATUS</returns>
        private int GetCatalogPartsInf2(GetPartsInfPara InPara)
        {
            // -- ADD 2010/05/25 ------------------------>>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return 0;
            }
            // -- ADD 2010/05/25 ------------------------<<<

            int status = 0;

            List<PartsModelLnkWork> partsModelLnkWork = null;
            ArrayList RetPartsInf = null;
            ArrayList Retcolor = null;
            ArrayList Rettrim = null;
            ArrayList Retequip = null;
            ArrayList RetPrtSubst = null;

            object obRetparts = null;
            object obcolor = null;
            object obtrim = null;
            object obequip = null;
            object obpartsSubst = null;
            long cnt = 0;

            #region �T�[�o�[�Z��
            try
            {
                if (iOfferPartsInfo == null)
                    iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();

                status = iOfferPartsInfo.GetPartsInf(InPara, ref obRetparts, ref obcolor, ref obtrim, ref obequip, ref obpartsSubst, out partsModelLnkWork, out cnt);//20070327 iwa add
                if (status == 0)
                {
                    CustomSerializeArrayList RetPartsSerializeArrayList = obRetparts as CustomSerializeArrayList;
                    CustomSerializeArrayList colorSerializeArrayList = obcolor as CustomSerializeArrayList;
                    CustomSerializeArrayList trimSerializeArrayList = obtrim as CustomSerializeArrayList;
                    CustomSerializeArrayList equipSerializeArrayList = obequip as CustomSerializeArrayList;
                    CustomSerializeArrayList substSerializeArrayList = obpartsSubst as CustomSerializeArrayList;

                    if (RetPartsSerializeArrayList.Count != 0)
                        RetPartsInf = (ArrayList)RetPartsSerializeArrayList[0];
                    if (colorSerializeArrayList.Count != 0)
                        Retcolor = (ArrayList)colorSerializeArrayList[0];
                    if (trimSerializeArrayList.Count != 0)
                        Rettrim = (ArrayList)trimSerializeArrayList[0];
                    if (equipSerializeArrayList.Count != 0)
                        Retequip = (ArrayList)equipSerializeArrayList[0];
                    if (substSerializeArrayList.Count != 0)
                        RetPrtSubst = (ArrayList)substSerializeArrayList[0];

                    if ((RetPartsInf != null) && (RetPartsInf.Count != 0))
                    {
                        foreach (RetPartsInf wkPartsInf in RetPartsInf)
                        {
                            PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow = goodsTable.FindByGoodsMakerCdGoodsNo(wkPartsInf.CatalogPartsMakerCd, wkPartsInf.ClgPrtsNoWithHyphen);

                            #region USR Price
                            if (wkPartsInf.PriceOfferDate != DateTime.MinValue &&
                                priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkPartsInf.CatalogPartsMakerCd,
                                wkPartsInf.PartsPriceStDate, wkPartsInf.ClgPrtsNoWithHyphen) == null)
                            {
                                PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTable.NewUsrGoodsPriceRow();
                                usrPriceRow.GoodsNo = wkPartsInf.ClgPrtsNoWithHyphen;
                                usrPriceRow.GoodsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                                // 2009.02.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                //usrPriceRow.ListPrice = wkPartsInf.PartsPrice;
                                double listPrice = wkPartsInf.PartsPrice;
                                this.ReflectIsolIslandCall(0, wkPartsInf.CatalogPartsMakerCd, 3, ref listPrice);
                                usrPriceRow.ListPrice = listPrice;
                                // 2009.02.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                usrPriceRow.OfferDate = wkPartsInf.PriceOfferDate;
                                usrPriceRow.OpenPriceDiv = wkPartsInf.OpenPriceDiv;
                                usrPriceRow.PriceStartDate = wkPartsInf.PartsPriceStDate;
                                //usrPriceRow.SalesUnitCost = 0;
                                //usrPriceRow.StockRate = 0;
                                usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                priceTable.AddUsrGoodsPriceRow(usrPriceRow);
                            }
                            // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                            if (wkPartsInf.PriceOfferDate != DateTime.MinValue &&
                                ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkPartsInf.CatalogPartsMakerCd,
                                wkPartsInf.PartsPriceStDate, wkPartsInf.ClgPrtsNoWithHyphen) == null)
                            {
                                PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTable.NewUsrGoodsPriceRow();
                                usrPriceRow.GoodsNo = wkPartsInf.ClgPrtsNoWithHyphen;
                                usrPriceRow.GoodsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                                double listPrice = wkPartsInf.PartsPrice;
                                this.ReflectIsolIslandCall(0, wkPartsInf.CatalogPartsMakerCd, 3, ref listPrice);
                                usrPriceRow.ListPrice = listPrice;
                                usrPriceRow.OfferDate = wkPartsInf.PriceOfferDate;
                                usrPriceRow.OpenPriceDiv = wkPartsInf.OpenPriceDiv;
                                usrPriceRow.PriceStartDate = wkPartsInf.PartsPriceStDate;
                                usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                ofrPriceTable.AddUsrGoodsPriceRow(usrPriceRow);
                            }
                            // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
                            #endregion
                        }
                    }
                }
            }
            catch
            {

            }
            #endregion

            return status;
        }
        // 2009/11/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        # endregion

        # region �񋟎��q��񌋍�����[TBO(Tire/Battery/Oil)���]
        /// <summary>
        /// �񋟎��q��񌋍�����
        /// </summary>
        /// <returns></returns>
        private int GetOfrTBOInfo(PartsSearchUIData partsSearchUIData, int equipGenreCode, string[] equipName)
        {
            ArrayList tboSearchRet = null;
            ArrayList tboSearchURet = new ArrayList();
            ArrayList tboSearchPriceRet = null;

            List<string> list = new List<string>();
            ArrayList lstCond = new ArrayList();
            for (int i = 0; i < carInfoDataSet.CategoryEquipmentInfo.Count; i++)
            {
                if (list.Contains(carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName) == false)
                {
                    list.Add(carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName);

                    TBOSearchUWork tBOSearchUWork = new TBOSearchUWork();
                    tBOSearchUWork.EnterpriseCode = partsSearchUIData.EnterpriseCode;
                    tBOSearchUWork.EquipGenreCode = carInfoDataSet.CategoryEquipmentInfo[i].EquipmentGenreCd;
                    tBOSearchUWork.EquipName = carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName;
                    lstCond.Add(tBOSearchUWork);
                }
            }

            TBOSearchCondWork tBOSearchCondWork = new TBOSearchCondWork();
            if (carInfoDataSet != null)
            {
                if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                    tBOSearchCondWork.CarMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                    tBOSearchCondWork.CarMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
            }
            tBOSearchCondWork.TbsPartsCode = partsSearchUIData.TbsPartsCode;
            tBOSearchCondWork.EquipName = equipName;
            tBOSearchCondWork.EquipGenreCode = equipGenreCode;


            // -- UPD 2010/05/25 -------------------------------->>>
            //iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

            //int status = iTBOSearchInfDB.Search(tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet);
            //if ((status == 0) && (tboSearchRet.Count > 0))
            //{
            //    FillTBOInfoTable(tboSearchRet, tboSearchPriceRet);
            //}

            int status = 0;
            //if (LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if (LoginInfoAcquisition.OnlineFlag || (!LoginInfoAcquisition.OnlineFlag && Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) == "PMSCM01000U")) // ADD 2010/07/07
            {
                iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

                status = iTBOSearchInfDB.Search( tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet );
                if ( (status == 0) && (tboSearchRet.Count > 0) )
                {
                    FillTBOInfoTable( tboSearchRet, tboSearchPriceRet );
                }
            }
            // -- UPD 2010/05/25 --------------------------------<<<

            if (iTBOSearchUDB == null)
                iTBOSearchUDB = MediationTBOSearchUDB.GetTBOSearchUDB();

            object objTBOSearchUList = tboSearchURet;

            status = iTBOSearchUDB.Search(ref objTBOSearchUList, lstCond, 0, ConstantManagement.LogicalMode.GetData0);

            tboSearchURet = objTBOSearchUList as ArrayList;

            PartsSearchUIData partsSearchUIDate = new PartsSearchUIData();
            partsSearchUIDate.EnterpriseCode = partsSearchUIData.EnterpriseCode;
            status = GetUsrGoodsInfForTBO(partsSearchUIData.EnterpriseCode, tboSearchURet);

            if ((status == 0) && (tboSearchURet.Count > 0))
            {
                FillTBOUInfoTable(tboSearchURet);
            }
            return (status);
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        ///  �񋟎��q��񌋍�����
        /// </summary>
        /// <param name="partsSearchUIDataDic"></param>
        /// <param name="equipGenreCodeList"></param>
        /// <param name="equipNameList"></param>
        /// <returns></returns>
        private int GetOfrTBOInfo(Dictionary<int, PartsSearchUIData> partsSearchUIDataDic, List<int> equipGenreCodeList, List<string[]> equipNameList)
        {
            ArrayList tboSearchRet = null;
            ArrayList tboSearchURet = new ArrayList();
            ArrayList tboSearchPriceRet = null;

            List<string> list = new List<string>();
            ArrayList lstCond = new ArrayList();
            ArrayList lstCondTemp = new ArrayList();
            List<int> dicKey = new List<int>(partsSearchUIDataDic.Keys);

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            for (int index = 0; index < partsSearchUIDataDic.Count; index++)
            {
                int key = dicKey[index];
                TBOSearchCondWork tBOSearchCondWork = new TBOSearchCondWork();
                if (carInfoDataSet != null)
                {
                    if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                        tBOSearchCondWork.CarMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                    else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                        tBOSearchCondWork.CarMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
                }
                tBOSearchCondWork.TbsPartsCode = partsSearchUIDataDic[key].TbsPartsCode;
                tBOSearchCondWork.EquipName = equipNameList[index];
                tBOSearchCondWork.EquipGenreCode = equipGenreCodeList[index];

                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                if (LoginInfoAcquisition.OnlineFlag || (!LoginInfoAcquisition.OnlineFlag && Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) == "PMSCM01000U"))
                {
                    iTBOSearchInfDB = MediationTBOSearchInfDB.GetTBOSearchInf();

                    status = iTBOSearchInfDB.Search(tBOSearchCondWork, out tboSearchRet, out tboSearchPriceRet);
                    if ((status == 0) && (tboSearchRet.Count > 0))
                    {
                        FillTBOInfoTable(tboSearchRet, tboSearchPriceRet, key);
                    }
                }

                lstCondTemp.Clear();
                for (int i = 0; i < carInfoDataSet.CategoryEquipmentInfo.Count; i++)
                {
                    if (list.Contains(carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName) == false)
                    {
                        list.Add(carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName);

                        TBOSearchUWork tBOSearchUWork = new TBOSearchUWork();
                        tBOSearchUWork.EnterpriseCode = partsSearchUIDataDic[key].EnterpriseCode;
                        tBOSearchUWork.EquipGenreCode = carInfoDataSet.CategoryEquipmentInfo[i].EquipmentGenreCd;
                        tBOSearchUWork.EquipName = carInfoDataSet.CategoryEquipmentInfo[i].EquipmentName;
                        lstCondTemp.Add(tBOSearchUWork);
                    }
                }
                lstCond.Add(lstCondTemp);
            }

            if (iTBOSearchUDB == null)
                iTBOSearchUDB = MediationTBOSearchUDB.GetTBOSearchUDB();

            object objTBOSearchUList = tboSearchURet;

            status = iTBOSearchUDB.Search(ref objTBOSearchUList, lstCond, 0, ConstantManagement.LogicalMode.GetData0);

            tboSearchURet = objTBOSearchUList as ArrayList;

            string enterpriseCode = partsSearchUIDataDic[dicKey[0]].EnterpriseCode;
            status = GetUsrGoodsInfForTBO(enterpriseCode, tboSearchURet, partsSearchUIDataDic);

            if ((status == 0) && (tboSearchURet.Count > 0))
            {
                FillTBOUInfoTable(tboSearchURet, partsSearchUIDataDic);
            }
            return (status);
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        # region �D�Ǖ��i���������������i�Ԃ��j�d�x�ɂ��ėD�Ǖi�Ԃ�������
        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
        ///// <summary>
        ///// �D�Ǖ��i���������������i�Ԃ��j�d�x�ɂ��ėD�Ǖi�Ԃ�������
        ///// </summary>
        ///// <param name="primeSubstFlg">�D�Ǒ�֌����t���O[true:��֌�������^false:��֌������Ȃ�]</param>
        //private int GetPrimePartsInf( bool primeSubstFlg )
        private int GetPrimePartsInf( bool primeSubstFlg, GetPartsInfPara inPara )
        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
        {
            // -- ADD 2010/05/25 ---------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return 0;
            }
            // -- ADD 2010/05/25 ----------------------<<<

            //�ϐ��̏�����
            int status = 0;
            ArrayList PrimePartsInfoList = null;
            ArrayList SetPartsInfoList = null;
            ArrayList PrimePriceList = null;
            ArrayList SetPriceList = null;

            ArrayList RetParts = new ArrayList();
            ArrayList RetSetParts = new ArrayList();
            PrimePartsInfoList = RetParts;
            SetPartsInfoList = RetSetParts;

            ArrayList conList = GetCatalogPartsList();
            if (conList == null || conList.Count == 0)
            {
                return (status);
            }

            //�����[�g�Ăяo��
            if (iPrimePartsInfoDB == null)
                iPrimePartsInfoDB = MediationPrimePartsInfo.GetRemoteObject();
            int carMakerCd = 0;
            if (carInfoDataSet != null)
            {
                if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                    carMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                    carMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
            }
            status = iPrimePartsInfoDB.GetPartsInfByCtlgPtNo( primeSubstFlg, carMakerCd, conList, out PrimePartsInfoList, out PrimePriceList,
                        out SetPartsInfoList, out SetPriceList );
            if (status == 0 && PrimePartsInfoList != null)
            {
                //�f�[�^�e�[�u���փ����[�g�擾���ݒ�
                // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                //FillJoinSetParts(false, PrimePartsInfoList, PrimePriceList, SetPartsInfoList, SetPriceList);
                FillJoinSetParts( false, PrimePartsInfoList, PrimePriceList, SetPartsInfoList, SetPriceList, inPara );
                // --- UPD m.suzuki 2011/05/18 ----------<<<<<
            }

            return (status);
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// �D�Ǖ��i���������������i�Ԃ��j�d�x�ɂ��ėD�Ǖi�Ԃ�������
        /// </summary>
        /// <param name="primeSubstFlg">�D�Ǒ�֌����t���O[true:��֌�������^false:��֌������Ȃ�]</param>
        /// <param name="inParaDic">��������</param>
        private int GetPrimePartsInf(bool primeSubstFlg, Dictionary<int, GetPartsInfPara> inParaDic)
        {
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  
            {
                return 0;
            }

            //�ϐ��̏�����
            int status = 0;
            // UPD 2014/06/12 PM-SCM���x���� �t�F�[�Y�Q��Q�Ή� -------------------------------------->>>>>
            //ArrayList PrimePartsInfoList = null;
            //ArrayList SetPartsInfoList = null;
            //ArrayList PrimePriceList = null;
            //ArrayList SetPriceList = null;

            //ArrayList RetParts = new ArrayList();
            //ArrayList RetSetParts = new ArrayList();
            //PrimePartsInfoList = RetParts;
            //SetPartsInfoList = RetSetParts;
            object objPrimePartsInfo = null;
            object objSetPartsInfo = null;
            object objPrimePrice = null;
            object objSetPrice = null;
            // UPD 2014/06/12 PM-SCM���x���� �t�F�[�Y�Q��Q�Ή� --------------------------------------<<<<<

            // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��17.�D�Ǖi�������ǑΉ� ---------------------------------->>>>>
            ArrayList retPrimePartsInfoList = new ArrayList();
            ArrayList retPrimePriceList = new ArrayList();
            ArrayList retSetPartsInfoList = new ArrayList();
            ArrayList retSetPriceList = new ArrayList();
            // ADD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��17.�D�Ǖi�������ǑΉ� ----------------------------------<<<<<

            // UPD 2014/05/09 ���x���P�t�F�[�Y�Q��11,��12 �g�� UPD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��17.�D�Ǖi�������ǑΉ�  -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            #region ���\�[�X
            //foreach (int key in inParaDic.Keys)
            //{
            //    ArrayList conList = GetCatalogPartsList(key);
            //    if (conList == null || conList.Count == 0)
            //    {
            //        continue;
            //    }

            //    //�����[�g�Ăяo��
            //    if (iPrimePartsInfoDB == null)
            //        iPrimePartsInfoDB = MediationPrimePartsInfo.GetRemoteObject();
            //    int carMakerCd = 0;
            //    if (carInfoDataSet != null)
            //    {
            //        if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
            //            carMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
            //        else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
            //            carMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
            //    }
            //    status = iPrimePartsInfoDB.GetPartsInfByCtlgPtNo(primeSubstFlg, carMakerCd, conList, out PrimePartsInfoList, out PrimePriceList,
            //                out SetPartsInfoList, out SetPriceList);
            //    if (status == 0 && PrimePartsInfoList != null)
            //    {
            //        //�f�[�^�e�[�u���փ����[�g�擾���ݒ�
            //        FillJoinSetParts(false, PrimePartsInfoList, PrimePriceList, SetPartsInfoList, SetPriceList, inParaDic[key], key);
            //    }
            //}
            #endregion
            // �I�t�@�[�p�����񓚕i�ڐݒ�̐���
            List<object> autoAnsItemStListObj = new List<object>();
            // ADD 2015/04/03 SCM�d�|�ꗗ��10716�Ή� ------------------------------>>>>>
            // �v���p�e�B�̎����񓚕i�ڐݒ�}�X�^�ɒl���ݒ肳��Ă��鎞�A�I�t�@�[�p�����񓚕i�ڐݒ�𐶐�����
            if (this._foundAutoAnsItemStList != null && this._foundAutoAnsItemStList.Count != 0)
            {
            // ADD 2015/04/03 SCM�d�|�ꗗ��10716�Ή� ------------------------------<<<<<
                foreach (AutoAnsItemSt tgt in _foundAutoAnsItemStList)
                {
                    if (tgt.LogicalDeleteCode.Equals(1)) continue;
                    List<object> autoAnsItemSt = new List<object>();
                    autoAnsItemSt.Add((object)tgt.SectionCode);     // ���_�R�[�h
                    autoAnsItemSt.Add((object)tgt.CustomerCode);    // ���Ӑ�R�[�h
                    autoAnsItemSt.Add((object)tgt.GoodsMGroup);     // ���i�����ރR�[�h
                    autoAnsItemSt.Add((object)tgt.BLGoodsCode);     // BL���i�R�[�h
                    autoAnsItemSt.Add((object)tgt.GoodsMakerCd);    // ���i���[�J�[�R�[�h
                    autoAnsItemSt.Add((object)tgt.PrmSetDtlNo2);    // �D�ǐݒ�ڍ׃R�[�h�Q
                    autoAnsItemSt.Add((object)tgt.AutoAnswerDiv);   // �����񓚋敪
                    autoAnsItemSt.Add((object)tgt.PriorityOrder);   // �D�揇��
                    autoAnsItemStListObj.Add(autoAnsItemSt);
                }
            } // ADD 2015/04/03 SCM�d�|�ꗗ��10716�Ή�

            // �I�t�@�[�p�D��ݒ�̐���
            List<object> prmSettingObj = new List<object>();
            // ADD 2015/04/03 SCM�d�|�ꗗ��10716�Ή� ------------------------------>>>>>
            // _drPrmSettingWork��null�l�Őݒ肳��邱�Ƃ͂���܂��񂪃R�[�f�B���O��Anull�`�F�b�N�ECount�`�F�b�N��ǉ����܂���
            if (this._drPrmSettingWork != null && this._drPrmSettingWork.Count != 0)
            {
            // ADD 2015/04/03 SCM�d�|�ꗗ��10716�Ή� ------------------------------<<<<<
                foreach (PrmSettingUWork tgt in _drPrmSettingWork)
                {
                    if (tgt.LogicalDeleteCode.Equals(1)) continue;
                    if (!tgt.SectionCode.Trim().Equals(_sectionCode)) continue;

                    List<object> prmSetting = new List<object>();
                    prmSetting.Add((object)tgt.GoodsMGroup);        // ���i�����ރR�[�h
                    prmSetting.Add((object)tgt.TbsPartsCode);       // BL�R�[�h
                    prmSetting.Add((object)tgt.PartsMakerCd);       // ���i���[�J�[�R�[�h
                    prmSetting.Add((object)tgt.PrmSetDtlNo1);       // �D�ǐݒ�ڍ׃R�[�h�P
                    prmSetting.Add((object)tgt.PrmSetDtlNo2);       // �D�ǐݒ�ڍ׃R�[�h�Q
                    prmSetting.Add((object)tgt.PrimeDisplayCode);   // �D�Ǖ\���敪�v���p�e�B
                    prmSettingObj.Add(prmSetting);
                }
            } // ADD 2015/04/03 SCM�d�|�ꗗ��10716�Ή�

            try
            {
                //�����[�g�Ăяo��
                if (iPrimePartsInfoDB == null)
                    iPrimePartsInfoDB = MediationPrimePartsInfo.GetRemoteObject();

                //--- DEL 2014/08/14 T.Miyamoto PM-SCM���x���� �t�F�[�Y�Q-------------------->>>>>
                //// �L���b�V������
                //iPrimePartsInfoDB.CacheAutoAnswer(this._sectionCodeAutoAnswer, this._customerCode, autoAnsItemStListObj, prmSettingObj);
                //--- DEL 2014/08/14 T.Miyamoto PM-SCM���x���� �t�F�[�Y�Q--------------------<<<<<

                ArrayList conList = new ArrayList();

                foreach (int key in inParaDic.Keys)
                {
                    ArrayList conListWork = GetCatalogPartsList(key);
                    if (conListWork == null || conListWork.Count == 0)
                    {
                        if (conListWork == null) conListWork = new ArrayList();
                        OfrPartsCondWork work = new OfrPartsCondWork();
                        work.MakerCode = 0;
                        work.PrtsNo = string.Empty;
                        work.PrtsNoOrg = string.Empty;
                        conListWork.Add(work);
                    }

                    conList.Add(conListWork);
                }

                int carMakerCd = 0;
                if (carInfoDataSet != null)
                {
                    if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
                        carMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
                    else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
                        carMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
                }

                // UPD 2014/06/12 PM-SCM���x���� �t�F�[�Y�Q��Q�Ή� -------------------------------------->>>>>
                #region ��Q�Ή��̂��ߍ폜
                //status = iPrimePartsInfoDB.GetPartsInfByCtlgPtNoAutoAnswer(primeSubstFlg, carMakerCd, conList, out PrimePartsInfoList, out PrimePriceList,
                //            out SetPartsInfoList, out SetPriceList);

                //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && PrimePartsInfoList != null)
                //{
                //    List<int> dicKeyList = new List<int>(inParaDic.Keys);

                //    for (int i = 0; i < dicKeyList.Count; i++)
                //    {
                //        if (PrimePartsInfoList.Count != 0)
                //        {
                //            retPrimePartsInfoList = (ArrayList)PrimePartsInfoList[i];
                //            // ���X�g���̃f�[�^���P���ŃR�[�h�Ȃ��̎�null�l�Ƃ���
                //            List<OfferJoinPartsRetWork> wkPrimePartsInfoList = new List<OfferJoinPartsRetWork>((OfferJoinPartsRetWork[])retPrimePartsInfoList.ToArray(typeof(OfferJoinPartsRetWork)));
                //            if (wkPrimePartsInfoList.Count == 1 && wkPrimePartsInfoList[0].JoinSourPartsNoWithH.Trim().Length == 0)
                //            {
                //                retPrimePartsInfoList = null;
                //            }
                //            retPrimePriceList = (ArrayList)PrimePriceList[i];
                //            // ���X�g���̃f�[�^���P���ŃR�[�h�Ȃ��̎�null�l�Ƃ���
                //            List<OfferJoinPriceRetWork> wkPrimePriceList = new List<OfferJoinPriceRetWork>((OfferJoinPriceRetWork[])retPrimePriceList.ToArray(typeof(OfferJoinPriceRetWork)));
                //            if (wkPrimePriceList.Count == 1 && wkPrimePriceList[0].PrimePartsNoWithH.Trim().Length == 0)
                //            {
                //                retPrimePriceList = null;
                //            }
                //            retSetPartsInfoList = (ArrayList)SetPartsInfoList[i];
                //            // ���X�g���̃f�[�^���P���ŃR�[�h�Ȃ��̎�null�l�Ƃ���
                //            List<OfferSetPartsRetWork> wkSetPartsInfoList = new List<OfferSetPartsRetWork>((OfferSetPartsRetWork[])retSetPartsInfoList.ToArray(typeof(OfferSetPartsRetWork)));
                //            if (wkSetPartsInfoList.Count == 1 && wkSetPartsInfoList[0].SetMainPartsNo.Trim().Length == 0)
                //            {
                //                retSetPartsInfoList = null;
                //            }
                //            retSetPriceList = (ArrayList)SetPriceList[i];
                //            // ���X�g���̃f�[�^���P���ŃR�[�h�Ȃ��̎�null�l�Ƃ���
                //            List<OfferJoinPriceRetWork> wkSetPriceList = new List<OfferJoinPriceRetWork>((OfferJoinPriceRetWork[])retSetPriceList.ToArray(typeof(OfferJoinPriceRetWork)));
                //            if (wkSetPriceList.Count == 1 && wkSetPriceList[0].PrimePartsNoWithH.Trim().Length == 0)
                //            {
                //                retSetPriceList = null;
                //            }
                //        }
                //        //�f�[�^�e�[�u���փ����[�g�擾���ݒ�
                //        FillJoinSetParts(false, retPrimePartsInfoList, retPrimePriceList, retSetPartsInfoList, retSetPriceList, inParaDic[i], i);
                //    }
                #endregion // ��Q�Ή��̂��ߍ폜

                //--- UPD 2014/08/14 T.Miyamoto PM-SCM���x���� �t�F�[�Y�Q-------------------->>>>>
                //status = iPrimePartsInfoDB.GetPartsInfByCtlgPtNoAutoAnswer(primeSubstFlg, carMakerCd, conList, out objPrimePartsInfo, out objPrimePrice,
                //            out objSetPartsInfo, out objSetPrice);
                status = iPrimePartsInfoDB.GetPartsInfByCtlgPtNoAutoAnswer(this._sectionCodeAutoAnswer, this._customerCode, autoAnsItemStListObj, prmSettingObj
                                                                          , primeSubstFlg, carMakerCd, conList
                                                                          , out objPrimePartsInfo, out objPrimePrice, out objSetPartsInfo, out objSetPrice);
                //--- UPD 2014/08/14 T.Miyamoto PM-SCM���x���� �t�F�[�Y�Q--------------------<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && objPrimePartsInfo != null)
                {
                    List<int> dicKeyList = new List<int>(inParaDic.Keys);

                    CustomSerializeArrayList PrimePartsInfoCustomSerializeArrayList = objPrimePartsInfo as CustomSerializeArrayList;
                    CustomSerializeArrayList PrimePriceCustomSerializeArrayList = objPrimePrice as CustomSerializeArrayList;
                    CustomSerializeArrayList SetPartsInfoCustomSerializeArrayList = objSetPartsInfo as CustomSerializeArrayList;
                    CustomSerializeArrayList SetPriceCustomSerializeArrayList = objSetPrice as CustomSerializeArrayList;

                    for (int i = 0; i < dicKeyList.Count; i++)
                    {
                        if (PrimePartsInfoCustomSerializeArrayList != null && PrimePartsInfoCustomSerializeArrayList.Count != 0)
                        {
                            retPrimePartsInfoList = (ArrayList)PrimePartsInfoCustomSerializeArrayList[i];
                            // ���X�g���̃f�[�^���P���ŃR�[�h�Ȃ��̎�null�l�Ƃ���
                            List<OfferJoinPartsRetWork> wkPrimePartsInfoList = new List<OfferJoinPartsRetWork>((OfferJoinPartsRetWork[])retPrimePartsInfoList.ToArray(typeof(OfferJoinPartsRetWork)));
                            if (wkPrimePartsInfoList.Count == 1 && wkPrimePartsInfoList[0].JoinSourPartsNoWithH.Trim().Length == 0)
                            {
                                retPrimePartsInfoList = null;
                            }
                            retPrimePriceList = (ArrayList)PrimePriceCustomSerializeArrayList[i];
                            // ���X�g���̃f�[�^���P���ŃR�[�h�Ȃ��̎�null�l�Ƃ���
                            List<OfferJoinPriceRetWork> wkPrimePriceList = new List<OfferJoinPriceRetWork>((OfferJoinPriceRetWork[])retPrimePriceList.ToArray(typeof(OfferJoinPriceRetWork)));
                            if (wkPrimePriceList.Count == 1 && wkPrimePriceList[0].PrimePartsNoWithH.Trim().Length == 0)
                            {
                                retPrimePriceList = null;
                            }
                            retSetPartsInfoList = (ArrayList)SetPartsInfoCustomSerializeArrayList[i];
                            // ���X�g���̃f�[�^���P���ŃR�[�h�Ȃ��̎�null�l�Ƃ���
                            List<OfferSetPartsRetWork> wkSetPartsInfoList = new List<OfferSetPartsRetWork>((OfferSetPartsRetWork[])retSetPartsInfoList.ToArray(typeof(OfferSetPartsRetWork)));
                            if (wkSetPartsInfoList.Count == 1 && wkSetPartsInfoList[0].SetMainPartsNo.Trim().Length == 0)
                            {
                                retSetPartsInfoList = null;
                            }
                            retSetPriceList = (ArrayList)SetPriceCustomSerializeArrayList[i];
                            // ���X�g���̃f�[�^���P���ŃR�[�h�Ȃ��̎�null�l�Ƃ���
                            List<OfferJoinPriceRetWork> wkSetPriceList = new List<OfferJoinPriceRetWork>((OfferJoinPriceRetWork[])retSetPriceList.ToArray(typeof(OfferJoinPriceRetWork)));
                            if (wkSetPriceList.Count == 1 && wkSetPriceList[0].PrimePartsNoWithH.Trim().Length == 0)
                            {
                                retSetPriceList = null;
                            }
                        }
                        //�f�[�^�e�[�u���փ����[�g�擾���ݒ�
                        // UPD 2014/10/16 SCM�Г���Q�ꗗ��53�Ή� -------------------------------->>>>>
                        //FillJoinSetParts(false, retPrimePartsInfoList, retPrimePriceList, retSetPartsInfoList, retSetPriceList, inParaDic[i], i);
                        FillJoinSetParts(false, retPrimePartsInfoList, retPrimePriceList, retSetPartsInfoList, retSetPriceList, inParaDic[dicKeyList[i]], dicKeyList[i]);
                        // UPD 2014/10/16 SCM�Г���Q�ꗗ��53�Ή� --------------------------------<<<<<
                    }
                }
                // UPD 2014/06/12 PM-SCM���x���� �t�F�[�Y�Q��Q�Ή� --------------------------------------<<<<<
            }
            catch
            {
            }
            finally
            {
                if (iPrimePartsInfoDB != null)
                {
                    //--- DEL 2014/08/14 T.Miyamoto PM-SCM���x���� �t�F�[�Y�Q-------------------->>>>>
                    //// �L���b�V���N���A����
                    //iPrimePartsInfoDB.CacheClearAutoAnswer();
                    //--- DEL 2014/08/14 T.Miyamoto PM-SCM���x���� �t�F�[�Y�Q--------------------<<<<<
                }
            }
            // UPD 2014/05/09 ���x���P�t�F�[�Y�Q��11,��12 �g�� UPD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��17.�D�Ǖi�������ǑΉ�  --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            return (status);
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        /// <summary>
        /// �D�Ǖ��i�������X�g�擾�������i�Ԃ��j�d�x�ɂ��ėD�Ǖi�Ԃ�������
        /// </summary>
        private ArrayList GetCatalogPartsList()
        {
            int partsInfoCnt, substPartsCnt, dSubstPartsCnt;
            int cntMax = 0;

            partsInfoCnt = partsInfo.PartsInfo.Count;
            substPartsCnt = partsInfo.SubstPartsInfo.Count;
            dSubstPartsCnt = partsInfo.DSubstPartsInfo.Count;
            cntMax = partsInfoCnt + substPartsCnt + dSubstPartsCnt;
            if (cntMax == 0)
            {
                return null;
            }

            lstClgParts = new List<string>();
            ArrayList lstRet = new ArrayList();

            //���i���
            for (int ix = 0; ix < partsInfoCnt; ix++)
            {
                //�ŐV�i��
                GetPrimePartsSet(lstRet, partsInfo.PartsInfo[ix].CatalogPartsMakerCd, partsInfo.PartsInfo[ix].NewPrtsNoWithHyphen);

                //�J�^���O�i��
                if (partsInfo.PartsInfo[ix].NewPrtsNoWithHyphen != partsInfo.PartsInfo[ix].ClgPrtsNoWithHyphen)
                    GetPrimePartsSet(lstRet, partsInfo.PartsInfo[ix].CatalogPartsMakerCd, partsInfo.PartsInfo[ix].ClgPrtsNoWithHyphen);
            }

            //��֏��
            for (int ix = 0; ix < substPartsCnt; ix++)
            {
                GetPrimePartsSet(lstRet, partsInfo.SubstPartsInfo[ix].CatalogPartsMakerCd, partsInfo.SubstPartsInfo[ix].NewPartsNoWithHyphen);
            }

            //������֏��
            for (int ix = 0; ix < dSubstPartsCnt; ix++)
            {
                GetPrimePartsSet(lstRet, partsInfo.DSubstPartsInfo[ix].CatalogPartsMakerCd, partsInfo.DSubstPartsInfo[ix].NewPartsNoWithHyphen);
            }
            return lstRet;
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        ///  �D�Ǖ��i�������X�g�擾�������i�Ԃ��j�d�x�ɂ��ėD�Ǖi�Ԃ�������
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private ArrayList GetCatalogPartsList(int key)
        {
            int partsInfoCnt, substPartsCnt, dSubstPartsCnt;
            int cntMax = 0;

            lstClgParts = new List<string>();
            ArrayList lstRet = new ArrayList();

            partsInfoCnt = partsInfoDic[key].PartsInfo.Count;
            substPartsCnt = partsInfoDic[key].SubstPartsInfo.Count;
            dSubstPartsCnt = partsInfoDic[key].DSubstPartsInfo.Count;
            cntMax = partsInfoCnt + substPartsCnt + dSubstPartsCnt;
            // ���i���E��֏��E������֏��̂Ȃ��ꍇ�͏I��
            if (cntMax == 0)
            {
                return null;
            }

            //���i���
            for (int ix = 0; ix < partsInfoCnt; ix++)
            {
                //�ŐV�i��
                GetPrimePartsSet(lstRet, partsInfoDic[key].PartsInfo[ix].CatalogPartsMakerCd, partsInfoDic[key].PartsInfo[ix].NewPrtsNoWithHyphen);

                //�J�^���O�i��
                if (partsInfoDic[key].PartsInfo[ix].NewPrtsNoWithHyphen != partsInfoDic[key].PartsInfo[ix].ClgPrtsNoWithHyphen)
                    GetPrimePartsSet(lstRet, partsInfoDic[key].PartsInfo[ix].CatalogPartsMakerCd, partsInfoDic[key].PartsInfo[ix].ClgPrtsNoWithHyphen);
            }

            //��֏��
            for (int ix = 0; ix < substPartsCnt; ix++)
            {
                GetPrimePartsSet(lstRet, partsInfoDic[key].SubstPartsInfo[ix].CatalogPartsMakerCd, partsInfoDic[key].SubstPartsInfo[ix].NewPartsNoWithHyphen);
            }

            //������֏��
            for (int ix = 0; ix < dSubstPartsCnt; ix++)
            {
                GetPrimePartsSet(lstRet, partsInfoDic[key].DSubstPartsInfo[ix].CatalogPartsMakerCd, partsInfoDic[key].DSubstPartsInfo[ix].NewPartsNoWithHyphen);
            }

            return lstRet;
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL �����g�p�̂悤�Ȃ̂ō폜
        //# region �D�Ǖ��i�_�t�����������������i�Ԃ��j�d�x�ɂ��ėD�Ǖi�Ԃ�������
        ///// <summary>
        ///// �D�Ǖ��i�_�t�����������������i�Ԃ��j�d�x�ɂ��ėD�Ǖi�Ԃ�������
        ///// </summary>
        ///// <param name="priceDate"></param>
        ///// <param name="primeSubstFlg">�D�Ǒ�֌����t���O</param>
        ///// <param name="MakerCode"></param>
        ///// <param name="PrtsNoWithHyphen"></param>
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
        ////private int GetPrimePartsInf(bool primeSubstFlg, int MakerCode, string PrtsNoWithHyphen)
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
        //// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
        //private int GetPrimePartsInf( DateTime priceDate, bool primeSubstFlg, int MakerCode, string PrtsNoWithHyphen )
        //// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
        //{
        //    int status = 0;
        //    ArrayList PrimePartsInfoList = null;
        //    ArrayList SetPartsInfoList = null;
        //    ArrayList PrimePriceList = null;
        //    ArrayList SetPriceList = null;

        //    //GetPrimePartsInfPara getPartsInfPara = new GetPrimePartsInfPara();
        //    ArrayList conList = new ArrayList();

        //    OfrPartsCondWork cond = new OfrPartsCondWork();
        //    //�i��
        //    cond.PrtsNo = PrtsNoWithHyphen;

        //    //���[�J�[�R�[�h
        //    cond.MakerCode = MakerCode;

        //    conList.Add(cond);

        //    //�����[�g�Ăяo��
        //    if (iPrimePartsInfoDB == null)
        //        iPrimePartsInfoDB = MediationPrimePartsInfo.GetRemoteObject();
        //    int carMakerCd = 0;
        //    if (carInfoDataSet != null)
        //    {
        //        if (carInfoDataSet.CarModelInfoSummarized.Rows.Count > 0)
        //            carMakerCd = carInfoDataSet.CarModelInfoSummarized[0].MakerCode;
        //        else if (carInfoDataSet.CarModelInfo.Rows.Count > 0)
        //            carMakerCd = carInfoDataSet.CarModelInfo[0].MakerCode;
        //    }
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
        //    //status = iPrimePartsInfoDB.GetPartsInfByCtlgPtNo(primeSubstFlg, carMakerCd, conList, out PrimePartsInfoList, out PrimePriceList,
        //    //    out SetPartsInfoList, out SetPriceList);
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
        //    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
        //    status = iPrimePartsInfoDB.GetPartsInfByCtlgPtNo( priceDate, primeSubstFlg, carMakerCd, conList, out PrimePartsInfoList, out PrimePriceList,
        //        out SetPartsInfoList, out SetPriceList );
        //    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
        //    if (status == 0 && PrimePartsInfoList != null)
        //    {
        //        FillJoinSetParts(false, PrimePartsInfoList, PrimePriceList, SetPartsInfoList, SetPriceList);
        //    }

        //    return (status);
        //}
        //# endregion
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL

        # region �D�Ǖi�Ԍ������D�Ǖi�Ԃ��j�d�x�ɂ��ėD�Ǖi�Ԃ�������
        /// <summary>
        /// �D�Ǖi�Ԍ������D�Ǖi�Ԃ��j�d�x�ɂ��ėD�Ǖi�Ԃ�������
        /// </summary>
        /// <returns></returns>
        private int GetPrimePartsInfFromPrimePartsNo(PartsSearchUIData partsNoSearchCond)
        {
            // -- ADD 2010/05/25 ---------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return 0;
            }
            // -- ADD 2010/05/25 ----------------------<<<

            ArrayList inRetInf;
            ArrayList inPrimePrice;
            ArrayList inRetSetParts;
            ArrayList SetPrice;
            GetPrimePartsInfPara getPartsInfPara = new GetPrimePartsInfPara();

            if (iPrimePartsInfoDB == null)
                iPrimePartsInfoDB = MediationPrimePartsInfo.GetRemoteObject();

            //���[�J�[�R�[�h
            getPartsInfPara.PartsMakerCode = partsNoSearchCond.PartsMakerCode;

            //�D�Ǖi��
            getPartsInfPara.PrtsNoNoneHyphen = partsNoSearchCond.PartsNo;

            if (partsNoSearchCond.SearchFlg == SearchFlag.GoodsAndSetInfo || partsNoSearchCond.SearchFlg == SearchFlag.PartsNoJoinSearch)
            {
                getPartsInfPara.SetSearchFlg = 1;
            }
            else
            {
                getPartsInfPara.SetSearchFlg = 0;
            }
            getPartsInfPara.SearchType = (int)partsNoSearchCond.SearchType;

            int status = iPrimePartsInfoDB.GetPartsInf(getPartsInfPara, out inRetInf, out inPrimePrice, out inRetSetParts, out SetPrice);
            if (status == 0 && inRetInf != null)
            {
                // �Z�b�g�t���O���O�̏ꍇ�̓Z�b�g���i���̃��X�g�͂O�̂��߁A���L�̃��\�b�h�ŏ������Ă��Z�b�g���i�͐ݒ肳��Ȃ��B
                // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                //FillJoinSetParts(true, inRetInf, inPrimePrice, inRetSetParts, SetPrice);
                FillJoinSetParts(true, inRetInf, inPrimePrice, inRetSetParts, SetPrice, null);
                // --- UPD m.suzuki 2011/05/18 ----------<<<<<
            }
            return (status);
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        ///  �D�Ǖi�Ԍ������D�Ǖi�Ԃ��j�d�x�ɂ��ėD�Ǖi�Ԃ�������
        /// </summary>
        /// <param name="partsNoSearchCondDic"></param>
        /// <returns></returns>
        private int GetPrimePartsInfFromPrimePartsNo(Dictionary<int, PartsSearchUIData> partsNoSearchCondDic)
        {
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return 0;
            }

            ArrayList inRetInf;
            ArrayList inPrimePrice;
            ArrayList inRetSetParts;
            ArrayList SetPrice;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                foreach (int key in partsNoSearchCondDic.Keys)
                {
                    GetPrimePartsInfPara getPartsInfPara = new GetPrimePartsInfPara();

                    if (iPrimePartsInfoDB == null)
                        iPrimePartsInfoDB = MediationPrimePartsInfo.GetRemoteObject();

                    //���[�J�[�R�[�h
                    getPartsInfPara.PartsMakerCode = partsNoSearchCondDic[key].PartsMakerCode;

                    //�D�Ǖi��
                    getPartsInfPara.PrtsNoNoneHyphen = partsNoSearchCondDic[key].PartsNo;

                    if (partsNoSearchCondDic[key].SearchFlg == SearchFlag.GoodsAndSetInfo || partsNoSearchCondDic[key].SearchFlg == SearchFlag.PartsNoJoinSearch)
                    {
                        getPartsInfPara.SetSearchFlg = 1;
                    }
                    else
                    {
                        getPartsInfPara.SetSearchFlg = 0;
                    }
                    getPartsInfPara.SearchType = (int)partsNoSearchCondDic[key].SearchType;

                    status = iPrimePartsInfoDB.GetPartsInf(getPartsInfPara, out inRetInf, out inPrimePrice, out inRetSetParts, out SetPrice);
                    if (status == 0 && inRetInf != null)
                    {
                        // �Z�b�g�t���O���O�̏ꍇ�̓Z�b�g���i���̃��X�g�͂O�̂��߁A���L�̃��\�b�h�ŏ������Ă��Z�b�g���i�͐ݒ肳��Ȃ��B
                        FillJoinSetParts(true, inRetInf, inPrimePrice, inRetSetParts, SetPrice, null, key);
                    }
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return (status);
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        # region ���[�U�[����
        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
        ///// <summary>
        ///// ���[�U�[��������
        ///// </summary>
        ///// <param name="partsSearchUIData"></param>
        ///// <returns></returns>
        //private int GetUsrGoodsJoinInf(PartsSearchUIData partsSearchUIData)
        /// <summary>
        /// ���[�U�[��������
        /// </summary>
        /// <param name="partsSearchUIData"></param>
        /// <param name="inPara"></param>
        /// <returns></returns>
        private int GetUsrGoodsJoinInf( PartsSearchUIData partsSearchUIData, GetPartsInfPara inPara )
        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
        {
            int status = 0;

            object retobj;
            CustomSerializeArrayList arrList;
            ArrayList usrRet = null;

            ArrayList searchCondList = new ArrayList();
            UsrSearchFlg usrSearchFlg;
            if (partsSearchUIData.PartsNo != string.Empty) // �i�Ԍ����̏ꍇ�̃��[�U�[���������ݒ�
            {
                switch (partsSearchUIData.SearchFlg)
                {
                    case SearchFlag.GoodsInfoOnly:
                        usrSearchFlg = UsrSearchFlg.UsrPartsOnly;
                        break;
                    case SearchFlag.GoodsAndSetInfo:
                        usrSearchFlg = UsrSearchFlg.UsrPartsAndSet;
                        break;
                    case SearchFlag.PartsNoJoinSearch:
                        if (partsSearchUIData.SearchCntSetWork.SubstApplyDivCd == 0)
                            usrSearchFlg = UsrSearchFlg.UsrPartsJoinSet;
                        else
                            usrSearchFlg = UsrSearchFlg.UsrPartsAndAll;
                        break;
                    default:
                        usrSearchFlg = UsrSearchFlg.UsrPartsJoinSet;
                        break;
                }
            }
            else    // �i�Ԍ����ȊO�̏ꍇ�̃��[�U�[���������ݒ�
            {
                if (partsSearchUIData.SearchCntSetWork.SubstApplyDivCd == 0)
                {
                    usrSearchFlg = UsrSearchFlg.UsrPartsJoinSet;
                }
                else
                {
                    usrSearchFlg = UsrSearchFlg.UsrPartsAndAll;
                }
            }
            GetUsrCondList(searchCondList, partsSearchUIData);

            if (iUsrJoinPartsSearchDB == null)
                iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();
            // 2009/12/17 >>>
            ////status = iUsrJoinPartsSearchDB.UserGoodsJoinSearch(out retobj, usrSearchFlg, (int)partsSearchUIData.SearchType, searchCondList); // 2009/09/07 DEL
            //status = iUsrJoinPartsSearchDB.UserGoodsJoinSearch(out retobj, usrSearchFlg, (int)partsSearchUIData.SearchType, ConstantManagement.LogicalMode.GetData01, searchCondList); // 2009/09/07 ADD
            status = iUsrJoinPartsSearchDB.UserGoodsJoinSearch(out retobj, usrSearchFlg, (int)partsSearchUIData.SearchType, partsSearchUIData.LogicalMode, searchCondList);
            // 2009/12/17 <<<
            if (status != 0)
            {
                return (status);
            }
            arrList = retobj as CustomSerializeArrayList;

            for (int i = 0; i < arrList.Count; i++)
            {
                usrRet = arrList[i] as ArrayList;
                switch (usrRet[0].GetType().Name)
                {
                    case "UsrPartsSubstRetWork":
                        //���[�U�[��������:��֏��
                        FillUsrSubstPartsTable(usrRet);
                        break;
                    case "UsrJoinPartsRetWork":
                        //���[�U�[��������:�������
                        FillUsrJoinPartsTable(usrRet);
                        break;
                    case "UsrSetPartsRetWork":
                        //���[�U�[��������:�Z�b�g���
                        FillUsrSetPartsTable(usrRet);
                        break;
                    case "UsrGoodsRetWork":
                        //���[�U�[��������:���i���
                        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                        //FillUsrGoodsInfoTable(usrRet);
                        FillUsrGoodsInfoTable( usrRet, inPara );
                        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                        break;
                    case "GoodsPriceUWork":
                        FillUsrGoodsPriceTable(usrRet);
                        break;
                    case "StockWork":
                        FillUsrGoodsStockTable(usrRet);
                        break;
                }
            }
            return (status);
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        ///  ���[�U�[��������
        /// </summary>
        /// <param name="partsSearchUIDataDic"></param>
        /// <param name="inParaDic"></param>
        /// <returns></returns>
        private int GetUsrGoodsJoinInf(Dictionary<int, PartsSearchUIData> partsSearchUIDataDic, Dictionary<int, GetPartsInfPara> inParaDic)
        {
            int status = 0;

            ArrayList retobj;
            ArrayList usrRet = null;
            ArrayList usrRetTemp = null;

            ArrayList searchCondList;
            ArrayList usrSearchFlgList;
            ArrayList searchTypeList;
            List<int> dicKeyList = new List<int>(partsSearchUIDataDic.Keys);
            ConstantManagement.LogicalMode logicalMode = partsSearchUIDataDic[dicKeyList[0]].LogicalMode;


            GetUsrCondList(partsSearchUIDataDic, out searchCondList, out usrSearchFlgList, out searchTypeList, out logicalMode);

            if (iUsrJoinPartsSearchDB == null)
                iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();

            status = iUsrJoinPartsSearchDB.UserGoodsJoinSearch(out retobj, usrSearchFlgList, searchTypeList, logicalMode, searchCondList);
            
            if (status != 0)
            {
                return (status);
            }

            for (int index = 0; index < searchCondList.Count; index++)
            {
                usrRetTemp = retobj[index] as CustomSerializeArrayList;
                int key = dicKeyList[index];

                for (int i = 0; i < usrRetTemp.Count; i++)
                {
                    usrRet = usrRetTemp[i] as ArrayList;

                    if (usrRet.Count != 0)
                    {
                        switch (usrRet[0].GetType().Name)
                        {
                            case "UsrPartsSubstRetWork":
                                //���[�U�[��������:��֏��
                                FillUsrSubstPartsTable(usrRet, key);
                                break;
                            case "UsrJoinPartsRetWork":
                                //���[�U�[��������:�������
                                FillUsrJoinPartsTable(usrRet, key);
                                break;
                            case "UsrSetPartsRetWork":
                                //���[�U�[��������:�Z�b�g���
                                FillUsrSetPartsTable(usrRet, key);
                                break;
                            case "UsrGoodsRetWork":
                                //���[�U�[��������:���i���
                                if (inParaDic == null)
                                    FillUsrGoodsInfoTable(usrRet, null, key);
                                else
                                    FillUsrGoodsInfoTable(usrRet, inParaDic[key], key);
                                break;
                            case "GoodsPriceUWork":
                                FillUsrGoodsPriceTable(usrRet, key);
                                break;
                            case "StockWork":
                                FillUsrGoodsStockTable(usrRet, key);
                                break;
                        }
                    }
                }

            }

            return (status);
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        /// <summary>
        /// ���[�U�[��������[TBO�p]
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="tboSearchURet">���[�U�[TBO�}�X�^���X�g</param>
        /// <returns></returns>
        private int GetUsrGoodsInfForTBO(string enterpriseCode, ArrayList tboSearchURet)
        {
            int status = 0;

            object retobj;
            CustomSerializeArrayList arrList;
            ArrayList usrRet = null;
            UsrPartsNoSearchCondWork usrJoinPartsCondWork;
            ArrayList searchCondList = new ArrayList();
            UsrSearchFlg usrSearchFlg;
            usrSearchFlg = UsrSearchFlg.UsrPartsOnly;

            for (int i = 0; i < partsInfo.UsrGoodsInfo.Count; i++)
            {
                usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                usrJoinPartsCondWork.EnterpriseCode = enterpriseCode;
                usrJoinPartsCondWork.MakerCode = partsInfo.UsrGoodsInfo[i].GoodsMakerCd;
                usrJoinPartsCondWork.PrtsNo = partsInfo.UsrGoodsInfo[i].GoodsNo;
                searchCondList.Add(usrJoinPartsCondWork);
            }
            for (int i = 0; i < tboSearchURet.Count; i++)
            {
                TBOSearchUWork work = tboSearchURet[i] as TBOSearchUWork;
                usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                usrJoinPartsCondWork.EnterpriseCode = enterpriseCode;
                usrJoinPartsCondWork.MakerCode = work.JoinDestMakerCd;
                usrJoinPartsCondWork.PrtsNo = work.JoinDestPartsNo;
                searchCondList.Add(usrJoinPartsCondWork);
            }

            if (iUsrJoinPartsSearchDB == null)
                iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();
            status = iUsrJoinPartsSearchDB.UserGoodsJoinSearch(out retobj, usrSearchFlg, (int)SearchType.WholeWord, searchCondList);
            if (status != 0)
            {
                return (status);
            }
            arrList = retobj as CustomSerializeArrayList;

            for (int i = 0; i < arrList.Count; i++)
            {
                usrRet = arrList[i] as ArrayList;
                switch (usrRet[0].GetType().Name)
                {
                    case "UsrGoodsRetWork":
                        //���[�U�[��������:���i���
                        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
                        //FillUsrGoodsInfoTable(usrRet);
                        FillUsrGoodsInfoTable( usrRet, null );
                        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
                        break;
                    case "GoodsPriceUWork":
                        FillUsrGoodsPriceTable(usrRet);
                        break;
                    case "StockWork":
                        FillUsrGoodsStockTable(usrRet);
                        break;
                    case "UsrPartsSubstRetWork":
                        //���[�U�[��������:��֏��
                        FillUsrSubstPartsTable(usrRet);
                        break;
                }
            }

            return (status);
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        ///  ���[�U�[��������[TBO�p]
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="tboSearchURet"></param>
        /// <param name="partsSearchUIDataDic"></param>
        /// <returns></returns>
        private int GetUsrGoodsInfForTBO(string enterpriseCode, ArrayList tboSearchURet, Dictionary<int, PartsSearchUIData> partsSearchUIDataDic)
        {
            int status = 0;

            object retobj;
            CustomSerializeArrayList arrList;
            ArrayList usrRet = null;
            UsrPartsNoSearchCondWork usrJoinPartsCondWork;
            ArrayList searchCondList = new ArrayList();
            ArrayList searchCondListTemp = new ArrayList();
            UsrSearchFlg usrSearchFlg;
            usrSearchFlg = UsrSearchFlg.UsrPartsOnly;
            List<int> dicKey = new List<int>(partsSearchUIDataDic.Keys);

            for (int index = 0; index < partsSearchUIDataDic.Count; index++)
            {
                int key = dicKey[index];
                for (int i = 0; i < partsInfoDic[key].UsrGoodsInfo.Count; i++)
                {
                    usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                    usrJoinPartsCondWork.EnterpriseCode = enterpriseCode;
                    usrJoinPartsCondWork.MakerCode = partsInfoDic[key].UsrGoodsInfo[i].GoodsMakerCd;
                    usrJoinPartsCondWork.PrtsNo = partsInfoDic[key].UsrGoodsInfo[i].GoodsNo;
                    searchCondListTemp.Add(usrJoinPartsCondWork);
                }
                ArrayList tboSearchURetTemp = tboSearchURet[index] as ArrayList;
                for (int i = 0; i < tboSearchURetTemp.Count; i++)
                {
                    TBOSearchUWork work = tboSearchURet[i] as TBOSearchUWork;
                    usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                    usrJoinPartsCondWork.EnterpriseCode = enterpriseCode;
                    usrJoinPartsCondWork.MakerCode = work.JoinDestMakerCd;
                    usrJoinPartsCondWork.PrtsNo = work.JoinDestPartsNo;
                    searchCondListTemp.Add(usrJoinPartsCondWork);
                }
                searchCondList.Add(searchCondListTemp);
            }

            if (iUsrJoinPartsSearchDB == null)
                iUsrJoinPartsSearchDB = MediationUsrJoinPartsSearchDB.GetRemoteObject();
            status = iUsrJoinPartsSearchDB.UserGoodsJoinSearch(out retobj, usrSearchFlg, (int)SearchType.WholeWord, searchCondList);
            if (status != 0)
            {
                return (status);
            }

            ArrayList retobjList = retobj as ArrayList;

            for (int index = 0; index < partsSearchUIDataDic.Count; index++)
            {
                arrList = retobjList[index] as CustomSerializeArrayList;
                int key = dicKey[index];

                for (int i = 0; i < arrList.Count; i++)
                {
                    usrRet = arrList[i] as ArrayList;
                    switch (usrRet[0].GetType().Name)
                    {
                        case "UsrGoodsRetWork":
                            //���[�U�[��������:���i���
                            FillUsrGoodsInfoTable(usrRet, null, key);
                            break;
                        case "GoodsPriceUWork":
                            FillUsrGoodsPriceTable(usrRet, key);
                            break;
                        case "StockWork":
                            FillUsrGoodsStockTable(usrRet, key);
                            break;
                        case "UsrPartsSubstRetWork":
                            //���[�U�[��������:��֏��
                            FillUsrSubstPartsTable(usrRet, key);
                            break;
                    }
                }
            }

            return (status);
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        /// <summary>
        /// ���[�U�[DB�����������X�g�쐬
        /// </summary>
        /// <param name="list"></param>
        /// <param name="partsSearchUIData"></param>
        private void GetUsrCondList(ArrayList list, PartsSearchUIData partsSearchUIData)
        {
            UsrPartsNoSearchCondWork usrJoinPartsCondWork = null;
            if (partsSearchUIData != null && partsSearchUIData.TbsPartsCode == 0) // �i�Ԍ����̏ꍇ
            {                                                                     // ���̕i�Ԃ݂̂̕i�Ԍ��������[�U�[DB�ł��s�����߁A
                usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                usrJoinPartsCondWork.EnterpriseCode = partsSearchUIData.EnterpriseCode;
                if (partsSearchUIData.PartsMakerCode != 0) // ���������[�J�R�[�h�w�肪�Ȃ��Ƃ�
                {
                    usrJoinPartsCondWork.MakerCode = partsSearchUIData.PartsMakerCode;
                }
                usrJoinPartsCondWork.PrtsNo = partsSearchUIData.PartsNo;
                if (partsSearchUIData.PartsNo != string.Empty
                    && partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(partsSearchUIData.PartsMakerCode, partsSearchUIData.PartsNo) == null)
                    list.Add(usrJoinPartsCondWork);
            }
            if (list.Count == 0) // BL�������̓��[�J�[�w��i�Ԍ����̏ꍇ�A���[�U�[DB�ł̕i�Ԍ����p�Ƀ_�~�[�����l��ݒ肷��
            {
                usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                usrJoinPartsCondWork.EnterpriseCode = partsSearchUIData.EnterpriseCode;
                usrJoinPartsCondWork.MakerCode = -1;
                usrJoinPartsCondWork.PrtsNo = string.Empty;
                list.Add(usrJoinPartsCondWork);
            }

            for (int i = 0; i < partsInfo.UsrGoodsInfo.Count; i++)
            {
                usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                usrJoinPartsCondWork.EnterpriseCode = partsSearchUIData.EnterpriseCode;
                usrJoinPartsCondWork.MakerCode = partsInfo.UsrGoodsInfo[i].GoodsMakerCd;
                usrJoinPartsCondWork.PrtsNo = partsInfo.UsrGoodsInfo[i].GoodsNo;
                list.Add(usrJoinPartsCondWork);
            }
            if (partsSearchUIData.TbsPartsCode != 0) // BL�����̏ꍇ
            {
                for (int i = 0; i < partsInfo.JoinParts.Count; i++)
                {
                    usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                    usrJoinPartsCondWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                    usrJoinPartsCondWork.MakerCode = partsInfo.JoinParts[i].JoinDestMakerCd;
                    usrJoinPartsCondWork.PrtsNo = partsInfo.JoinParts[i].JoinDestPartsNo;
                    if (list.Contains(usrJoinPartsCondWork) == false)
                        list.Add(usrJoinPartsCondWork);
                }
                for (int i = 0; i < partsInfo.GoodsSet.Count; i++)
                {
                    usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                    usrJoinPartsCondWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                    usrJoinPartsCondWork.MakerCode = partsInfo.GoodsSet[i].SetSubMakerCd;
                    usrJoinPartsCondWork.PrtsNo = partsInfo.GoodsSet[i].SetSubPartsNo;
                    if (list.Contains(usrJoinPartsCondWork) == false)
                        list.Add(usrJoinPartsCondWork);
                }
            }
        }
        //���[�U�[DB�ɂ��鏤�i�Ɋւ��Ă͒�DB�����Ȃ��悤�Ɏd�l���ύX����A���L�\�[�X�͕s�v�ɂȂ�B
        ///////////////////////////////////////////////////////////////////////////////////////////

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        ///  ���[�U�[DB�����������X�g�쐬
        /// </summary>
        /// <param name="partsSearchUIDataDic"></param>
        /// <param name="condList"></param>
        /// <param name="flgList"></param>
        /// <param name="typeList"></param>
        /// <param name="logicalMode"></param>
        private void GetUsrCondList(Dictionary<int, PartsSearchUIData> partsSearchUIDataDic, out ArrayList condList, out ArrayList flgList, out ArrayList typeList, out ConstantManagement.LogicalMode logicalMode)
        {
            condList = new ArrayList();
            flgList = new ArrayList();
            typeList = new ArrayList();
            UsrSearchFlg usrSearchFlg;
            logicalMode = ConstantManagement.LogicalMode.GetData0;

            foreach (int key in partsSearchUIDataDic.Keys)
            {
                logicalMode = partsSearchUIDataDic[key].LogicalMode;

                #region ���[�U�[���������ݒ�

                if (partsSearchUIDataDic[key].PartsNo != string.Empty) // �i�Ԍ����̏ꍇ�̃��[�U�[���������ݒ�
                {
                    switch (partsSearchUIDataDic[key].SearchFlg)
                    {
                        case SearchFlag.GoodsInfoOnly:
                            usrSearchFlg = UsrSearchFlg.UsrPartsOnly;
                            break;
                        case SearchFlag.GoodsAndSetInfo:
                            usrSearchFlg = UsrSearchFlg.UsrPartsAndSet;
                            break;
                        case SearchFlag.PartsNoJoinSearch:
                            if (partsSearchUIDataDic[key].SearchCntSetWork.SubstApplyDivCd == 0)
                                usrSearchFlg = UsrSearchFlg.UsrPartsJoinSet;
                            else
                                usrSearchFlg = UsrSearchFlg.UsrPartsAndAll;
                            break;
                        default:
                            usrSearchFlg = UsrSearchFlg.UsrPartsJoinSet;
                            break;
                    }
                }
                else    // �i�Ԍ����ȊO�̏ꍇ�̃��[�U�[���������ݒ�
                {
                    if (partsSearchUIDataDic[key].SearchCntSetWork.SubstApplyDivCd == 0)
                    {
                        usrSearchFlg = UsrSearchFlg.UsrPartsJoinSet;
                    }
                    else
                    {
                        usrSearchFlg = UsrSearchFlg.UsrPartsAndAll;
                    }
                }
                flgList.Add(usrSearchFlg);

                #endregion

                // �����^�C�v�ݒ�
                typeList.Add((object)partsSearchUIDataDic[key].SearchType);

                #region �����i�Ԑݒ�

                ArrayList condTempList = new ArrayList();

                UsrPartsNoSearchCondWork usrJoinPartsCondWork = null;
                if (partsSearchUIDataDic[key] != null && partsSearchUIDataDic[key].TbsPartsCode == 0) // �i�Ԍ����̏ꍇ
                {                                                                     // ���̕i�Ԃ݂̂̕i�Ԍ��������[�U�[DB�ł��s�����߁A
                    usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                    usrJoinPartsCondWork.EnterpriseCode = partsSearchUIDataDic[key].EnterpriseCode;
                    if (partsSearchUIDataDic[key].PartsMakerCode != 0) // ���������[�J�R�[�h�w�肪�Ȃ��Ƃ�
                    {
                        usrJoinPartsCondWork.MakerCode = partsSearchUIDataDic[key].PartsMakerCode;
                    }
                    usrJoinPartsCondWork.PrtsNo = partsSearchUIDataDic[key].PartsNo;
                    if (partsSearchUIDataDic[key].PartsNo != string.Empty
                        && partsInfoDic[key].UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(partsSearchUIDataDic[key].PartsMakerCode, partsSearchUIDataDic[key].PartsNo) == null)
                        condTempList.Add(usrJoinPartsCondWork);
                }
                if (condTempList.Count == 0) // BL�������̓��[�J�[�w��i�Ԍ����̏ꍇ�A���[�U�[DB�ł̕i�Ԍ����p�Ƀ_�~�[�����l��ݒ肷��
                {
                    usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                    usrJoinPartsCondWork.EnterpriseCode = partsSearchUIDataDic[key].EnterpriseCode;
                    usrJoinPartsCondWork.MakerCode = -1;
                    usrJoinPartsCondWork.PrtsNo = string.Empty;
                    condTempList.Add(usrJoinPartsCondWork);
                }

                for (int i = 0; i < partsInfoDic[key].UsrGoodsInfo.Count; i++)
                {
                    usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                    usrJoinPartsCondWork.EnterpriseCode = partsSearchUIDataDic[key].EnterpriseCode;
                    usrJoinPartsCondWork.MakerCode = partsInfoDic[key].UsrGoodsInfo[i].GoodsMakerCd;
                    usrJoinPartsCondWork.PrtsNo = partsInfoDic[key].UsrGoodsInfo[i].GoodsNo;
                    condTempList.Add(usrJoinPartsCondWork);
                }
                if (partsSearchUIDataDic[key].TbsPartsCode != 0) // BL�����̏ꍇ
                {
                    for (int i = 0; i < partsInfoDic[key].JoinParts.Count; i++)
                    {
                        usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                        usrJoinPartsCondWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        usrJoinPartsCondWork.MakerCode = partsInfoDic[key].JoinParts[i].JoinDestMakerCd;
                        usrJoinPartsCondWork.PrtsNo = partsInfoDic[key].JoinParts[i].JoinDestPartsNo;
                        if (condTempList.Contains(usrJoinPartsCondWork) == false)
                            condTempList.Add(usrJoinPartsCondWork);
                    }
                    for (int i = 0; i < partsInfoDic[key].GoodsSet.Count; i++)
                    {
                        usrJoinPartsCondWork = new UsrPartsNoSearchCondWork();
                        usrJoinPartsCondWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
                        usrJoinPartsCondWork.MakerCode = partsInfoDic[key].GoodsSet[i].SetSubMakerCd;
                        usrJoinPartsCondWork.PrtsNo = partsInfoDic[key].GoodsSet[i].SetSubPartsNo;
                        if (condTempList.Contains(usrJoinPartsCondWork) == false)
                            condTempList.Add(usrJoinPartsCondWork);
                    }
                }
                condList.Add(condTempList);
                #endregion 
            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        # region Datatable���ݒ胁�C��
        # region �ԗ���񌋍����ݒ�[TBO]
        /// <summary>
        /// �ԗ���񌋍����ݒ�
        /// </summary>
        /// <param name="tboSearchRet"></param>
        /// <param name="tboSearchPriceRet"></param>
        private void FillTBOInfoTable(ArrayList tboSearchRet, ArrayList tboSearchPriceRet)
        {
            if (partsInfo.TBOInfo.Count > 0)
                partsInfo.TBOInfo.Clear();
            if (tboSearchRet == null)
            {
                return;
            }

            foreach (TBOSearchRetWork wkInf in tboSearchRet)
            {
                if (searchPrtCtlAcs.TactiSearch == 0  // �^�N�e�B�����_��Ȃ�
                     && wkInf.JoinDestMakerCd == ct_TactiCd // ���i���[�J�[���^�N�e�B�[
                     && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd) // �Ԃ̃��[�J�[���g���^�łȂ�
                {
                    continue;
                }
                //�@�D�ǐݒ�i������
                bool tboExcludeFlg = false;
                // 2009.02.12 >>>
                //PrmSettingUWork prmSetting = null;
                //PrmSettingKey prmKey = new PrmSettingKey(_sectionCode, wkInf.GoodsMGroup,
                //        wkInf.TbsPartsCode, wkInf.JoinDestMakerCd);
                //if (_drPrmSettingWork.ContainsKey(prmKey) == false)
                //{
                //    tboExcludeFlg = true;
                //}
                //else
                //{
                //    prmSetting = _drPrmSettingWork[prmKey];
                //    if (prmSetting.PrimeDisplayCode == 0) // �D�Ǖ\���敪��[�Ȃ�]�ȊO��\������B
                //        tboExcludeFlg = true;
                //}
                PrmSettingUWork prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, _drPrmSettingWork);
                if (prmSetting == null)
                {
                    tboExcludeFlg = true;
                }
                else
                {
                    if (prmSetting.PrimeDisplayCode == 0) // �D�Ǖ\���敪��[�Ȃ�]�ȊO��\������B
                        tboExcludeFlg = true;
                }

                // 2009.02.12 <<<
#if !PrimeSet
                tboExcludeFlg = false;
#endif
                if (tboExcludeFlg == false)
                {
                    PartsInfoDataSet.TBOInfoRow row = partsInfo.TBOInfo.NewTBOInfoRow();

                    row.OfferDate = wkInf.OfferDate;
                    row.GoodsMGroup = wkInf.GoodsMGroup;
                    row.TbsPartsCode = wkInf.TbsPartsCode;
                    row.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                    row.EquipGenreCode = wkInf.EquipGenreCode;
                    row.EquipName = wkInf.EquipName;
                    row.EquipSpecialNote = wkInf.EquipSpecialNote;
                    row.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                    row.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                    row.JoinQty = wkInf.JoinQty;
                    row.PrimePartsName = wkInf.PrimePartsName;
                    row.PrimePartsKanaName = wkInf.PrimePartsKanaName;
                    row.PartsLayerCd = wkInf.PartsLayerCd;
                    row.PartsAttribute = wkInf.PartsAttribute;
                    row.PrimePartsSpecialNote = wkInf.PrimePartsSpecialNote;
                    row.CatalogDeleteFlag = wkInf.CatalogDelteFlag;
                    row.CarInfoJoinDispOrder = wkInf.CarInfoJoinDispOrder;
                    row.JoinDestMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                    row.OfferKubun = 1; // 0:���[�U�f�[�^,1:�񋟃f�[�^

                    partsInfo.TBOInfo.AddTBOInfoRow(row);

                    PartsInfoDataSet.UsrGoodsInfoRow usrRow = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                    if (usrRow == null)
                    {
                        usrRow = partsInfo.UsrGoodsInfo.NewUsrGoodsInfoRow();

                        usrRow.BlGoodsCode = wkInf.TbsPartsCode;
                        usrRow.GoodsKind = (int)GoodsKind.Parent;   // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                        usrRow.GoodsMakerCd = wkInf.JoinDestMakerCd;
                        usrRow.GoodsMakerNm = row.JoinDestMakerNm;
                        usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                        usrRow.GoodsNo = wkInf.JoinDestPartsNo;
                        usrRow.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-", "");
                        usrRow.GoodsSpecialNote = wkInf.PrimePartsSpecialNote;
                        // ADD 2013/02/12 T.Yoshioka 2013/03/06�z�M�\�� SCM��Q��169 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        usrRow.GoodsSpecialNoteOffer = wkInf.PrimePartsSpecialNote;   // ���i�K�i�E���L�����i�񋟁j
                        // ADD 2013/02/12 T.Yoshioka 2013/03/06�z�M�\�� SCM��Q��169 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        usrRow.LogicalDeleteCode = 0;
                        usrRow.OfferKubun = 5;
                        usrRow.DisplayOrder = wkInf.CarInfoJoinDispOrder;
                        usrRow.OfferDate = wkInf.OfferDate;
                        usrRow.OfferDataDiv = 1;
                        usrRow.GoodsName = wkInf.PrimePartsName; // ���i���F�f�t�H���g�͕��i��
                        usrRow.GoodsNameKana = wkInf.PrimePartsKanaName;
                        usrRow.GoodsOfrName = wkInf.PrimePartsName; // ���i��
                        usrRow.GoodsOfrNameKana = wkInf.PrimePartsKanaName;
                        usrRow.SearchPartsFullName = wkInf.SearchPartsFullName; // �����i��
                        usrRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
                        // 2010/02/25 Add >>>
                        if (wkInf.TbsPartsCdDerivedNo != 0)
                        {
                            string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                               ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                            BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                            if ((rows != null) && (rows.Length != 0))
                            {
                                usrRow.GoodsName = usrRow.GoodsName + rows[0].TbsPartsFullName;
                                usrRow.GoodsNameKana = usrRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                usrRow.GoodsOfrName = usrRow.GoodsOfrName + rows[0].TbsPartsFullName; // ���i��
                                usrRow.GoodsOfrNameKana = usrRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                usrRow.SearchPartsFullName = usrRow.SearchPartsFullName + rows[0].TbsPartsFullName; // �����i��
                                usrRow.SearchPartsHalfName = usrRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                            }
                        }
                        // 2010/02/25 Add <<<

                        partsInfo.UsrGoodsInfo.AddUsrGoodsInfoRow(usrRow);
                    }
                }
            }
            if (tboSearchPriceRet == null)
            {
                return;
            }
            foreach (TBOSearchPriceRetWork wkInf in tboSearchPriceRet)
            {
                //PartsInfoDataSet.PriceInfoRow row = partsInfo.PriceInfo.NewPriceInfoRow();
                PartsInfoDataSet.UsrGoodsPriceRow row = priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.PartsMakerCd,
                    wkInf.PriceStartDate, wkInf.PrimePartsNoWithH);

                if (row == null)
                {
                    row = priceTable.NewUsrGoodsPriceRow();

                    row.OfferDate = wkInf.OfferDate;
                    row.GoodsMakerCd = wkInf.PartsMakerCd;
                    row.GoodsNo = wkInf.PrimePartsNoWithH;
                    row.ListPrice = wkInf.NewPrice;
                    row.PriceStartDate = wkInf.PriceStartDate;
                    row.OpenPriceDiv = wkInf.OpenPriceDiv;

                    PartsInfoDataSet.UsrGoodsInfoRow parentRow = goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.PartsMakerCd, wkInf.PrimePartsNoWithH);
                    if (parentRow != null)
                    {
                        row.UsrGoodsInfoRowParent = parentRow;
                        priceTable.AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                row = null;
                row = ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.PartsMakerCd,
                    wkInf.PriceStartDate, wkInf.PrimePartsNoWithH);

                if (row == null)
                {
                    row = ofrPriceTable.NewUsrGoodsPriceRow();

                    row.OfferDate = wkInf.OfferDate;
                    row.GoodsMakerCd = wkInf.PartsMakerCd;
                    row.GoodsNo = wkInf.PrimePartsNoWithH;
                    row.ListPrice = wkInf.NewPrice;
                    row.PriceStartDate = wkInf.PriceStartDate;
                    row.OpenPriceDiv = wkInf.OpenPriceDiv;

                    PartsInfoDataSet.UsrGoodsInfoRow parentRow = goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.PartsMakerCd, wkInf.PrimePartsNoWithH);
                    if (parentRow != null)
                    {
                        row.UsrGoodsInfoRowParent = parentRow;
                        ofrPriceTable.AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
            }
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        ///  �ԗ���񌋍����ݒ�
        /// </summary>
        /// <param name="tboSearchRet"></param>
        /// <param name="tboSearchPriceRet"></param>
        /// <param name="key"></param>
        private void FillTBOInfoTable(ArrayList tboSearchRet, ArrayList tboSearchPriceRet, int key)
        {
            if (partsInfoDic[key].TBOInfo.Count > 0)
                partsInfoDic[key].TBOInfo.Clear();
            if (tboSearchRet == null)
            {
                return;
            }

            foreach (TBOSearchRetWork wkInf in tboSearchRet)
            {
                if (searchPrtCtlAcs.TactiSearch == 0  // �^�N�e�B�����_��Ȃ�
                     && wkInf.JoinDestMakerCd == ct_TactiCd // ���i���[�J�[���^�N�e�B�[
                     && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd) // �Ԃ̃��[�J�[���g���^�łȂ�
                {
                    continue;
                }
                //�@�D�ǐݒ�i������
                bool tboExcludeFlg = false;
                // 2009.02.12 >>>
                //PrmSettingUWork prmSetting = null;
                //PrmSettingKey prmKey = new PrmSettingKey(_sectionCode, wkInf.GoodsMGroup,
                //        wkInf.TbsPartsCode, wkInf.JoinDestMakerCd);
                //if (_drPrmSettingWork.ContainsKey(prmKey) == false)
                //{
                //    tboExcludeFlg = true;
                //}
                //else
                //{
                //    prmSetting = _drPrmSettingWork[prmKey];
                //    if (prmSetting.PrimeDisplayCode == 0) // �D�Ǖ\���敪��[�Ȃ�]�ȊO��\������B
                //        tboExcludeFlg = true;
                //}
                PrmSettingUWork prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, _drPrmSettingWork);
                if (prmSetting == null)
                {
                    tboExcludeFlg = true;
                }
                else
                {
                    if (prmSetting.PrimeDisplayCode == 0) // �D�Ǖ\���敪��[�Ȃ�]�ȊO��\������B
                        tboExcludeFlg = true;
                }

                // 2009.02.12 <<<
#if !PrimeSet
                tboExcludeFlg = false;
#endif
                if (tboExcludeFlg == false)
                {
                    PartsInfoDataSet.TBOInfoRow row = partsInfoDic[key].TBOInfo.NewTBOInfoRow();

                    row.OfferDate = wkInf.OfferDate;
                    row.GoodsMGroup = wkInf.GoodsMGroup;
                    row.TbsPartsCode = wkInf.TbsPartsCode;
                    row.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                    row.EquipGenreCode = wkInf.EquipGenreCode;
                    row.EquipName = wkInf.EquipName;
                    row.EquipSpecialNote = wkInf.EquipSpecialNote;
                    row.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                    row.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                    row.JoinQty = wkInf.JoinQty;
                    row.PrimePartsName = wkInf.PrimePartsName;
                    row.PrimePartsKanaName = wkInf.PrimePartsKanaName;
                    row.PartsLayerCd = wkInf.PartsLayerCd;
                    row.PartsAttribute = wkInf.PartsAttribute;
                    row.PrimePartsSpecialNote = wkInf.PrimePartsSpecialNote;
                    row.CatalogDeleteFlag = wkInf.CatalogDelteFlag;
                    row.CarInfoJoinDispOrder = wkInf.CarInfoJoinDispOrder;
                    row.JoinDestMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                    row.OfferKubun = 1; // 0:���[�U�f�[�^,1:�񋟃f�[�^

                    partsInfoDic[key].TBOInfo.AddTBOInfoRow(row);

                    PartsInfoDataSet.UsrGoodsInfoRow usrRow = partsInfoDic[key].UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                    if (usrRow == null)
                    {
                        usrRow = partsInfoDic[key].UsrGoodsInfo.NewUsrGoodsInfoRow();

                        usrRow.BlGoodsCode = wkInf.TbsPartsCode;
                        usrRow.GoodsKind = (int)GoodsKind.Parent;   // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                        usrRow.GoodsMakerCd = wkInf.JoinDestMakerCd;
                        usrRow.GoodsMakerNm = row.JoinDestMakerNm;
                        usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                        usrRow.GoodsNo = wkInf.JoinDestPartsNo;
                        usrRow.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-", "");
                        usrRow.GoodsSpecialNote = wkInf.PrimePartsSpecialNote;
                        // ADD 2013/02/12 T.Yoshioka 2013/03/06�z�M�\�� SCM��Q��169 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        usrRow.GoodsSpecialNoteOffer = wkInf.PrimePartsSpecialNote;   // ���i�K�i�E���L�����i�񋟁j
                        // ADD 2013/02/12 T.Yoshioka 2013/03/06�z�M�\�� SCM��Q��169 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        usrRow.LogicalDeleteCode = 0;
                        usrRow.OfferKubun = 5;
                        usrRow.DisplayOrder = wkInf.CarInfoJoinDispOrder;
                        usrRow.OfferDate = wkInf.OfferDate;
                        usrRow.OfferDataDiv = 1;
                        usrRow.GoodsName = wkInf.PrimePartsName; // ���i���F�f�t�H���g�͕��i��
                        usrRow.GoodsNameKana = wkInf.PrimePartsKanaName;
                        usrRow.GoodsOfrName = wkInf.PrimePartsName; // ���i��
                        usrRow.GoodsOfrNameKana = wkInf.PrimePartsKanaName;
                        usrRow.SearchPartsFullName = wkInf.SearchPartsFullName; // �����i��
                        usrRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
                        // 2010/02/25 Add >>>
                        if (wkInf.TbsPartsCdDerivedNo != 0)
                        {
                            string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                               ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                            BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                            if ((rows != null) && (rows.Length != 0))
                            {
                                usrRow.GoodsName = usrRow.GoodsName + rows[0].TbsPartsFullName;
                                usrRow.GoodsNameKana = usrRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                usrRow.GoodsOfrName = usrRow.GoodsOfrName + rows[0].TbsPartsFullName; // ���i��
                                usrRow.GoodsOfrNameKana = usrRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                usrRow.SearchPartsFullName = usrRow.SearchPartsFullName + rows[0].TbsPartsFullName; // �����i��
                                usrRow.SearchPartsHalfName = usrRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                            }
                        }
                        // 2010/02/25 Add <<<

                        partsInfoDic[key].UsrGoodsInfo.AddUsrGoodsInfoRow(usrRow);
                    }
                }
            }
            if (tboSearchPriceRet == null)
            {
                return;
            }
            foreach (TBOSearchPriceRetWork wkInf in tboSearchPriceRet)
            {
                //PartsInfoDataSet.PriceInfoRow row = partsInfo.PriceInfo.NewPriceInfoRow();
                PartsInfoDataSet.UsrGoodsPriceRow row = priceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.PartsMakerCd,
                    wkInf.PriceStartDate, wkInf.PrimePartsNoWithH);

                if (row == null)
                {
                    row = priceTableDic[key].NewUsrGoodsPriceRow();

                    row.OfferDate = wkInf.OfferDate;
                    row.GoodsMakerCd = wkInf.PartsMakerCd;
                    row.GoodsNo = wkInf.PrimePartsNoWithH;
                    row.ListPrice = wkInf.NewPrice;
                    row.PriceStartDate = wkInf.PriceStartDate;
                    row.OpenPriceDiv = wkInf.OpenPriceDiv;

                    PartsInfoDataSet.UsrGoodsInfoRow parentRow = goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkInf.PartsMakerCd, wkInf.PrimePartsNoWithH);
                    if (parentRow != null)
                    {
                        row.UsrGoodsInfoRowParent = parentRow;
                        priceTableDic[key].AddUsrGoodsPriceRow(row);
                    }
                }

                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                row = null;
                row = ofrPriceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.PartsMakerCd,
                    wkInf.PriceStartDate, wkInf.PrimePartsNoWithH);

                if (row == null)
                {
                    row = ofrPriceTableDic[key].NewUsrGoodsPriceRow();

                    row.OfferDate = wkInf.OfferDate;
                    row.GoodsMakerCd = wkInf.PartsMakerCd;
                    row.GoodsNo = wkInf.PrimePartsNoWithH;
                    row.ListPrice = wkInf.NewPrice;
                    row.PriceStartDate = wkInf.PriceStartDate;
                    row.OpenPriceDiv = wkInf.OpenPriceDiv;

                    PartsInfoDataSet.UsrGoodsInfoRow parentRow = goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkInf.PartsMakerCd, wkInf.PrimePartsNoWithH);
                    if (parentRow != null)
                    {
                        row.UsrGoodsInfoRowParent = parentRow;
                        ofrPriceTableDic[key].AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        /// <summary>
        /// �ԗ���񌋍����ݒ�(���[�U�[)
        /// ���[�U�[TBO���̕s�����͏��i�}�X�^����擾����
        /// </summary>
        /// <param name="tboSearchRet"></param>
        /// <br>UpdateNote : 2013/03/15�@dpp</br>
        /// <br>          �@ 10901273-00 5��15���z�M���i��Q�ȊO�j Redmine#34377 �i�Ԍ������ʕs��̏C��</br>
        private void FillTBOUInfoTable(ArrayList tboSearchRet)
        {
            if (tboSearchRet == null)
            {
                return;
            }

            foreach (TBOSearchUWork wkInf in tboSearchRet)
            {
                if (searchPrtCtlAcs.TactiSearch == 0  // �^�N�e�B�����_��Ȃ�
                     && wkInf.JoinDestMakerCd == ct_TactiCd // ���i���[�J�[���^�N�e�B�[
                     && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd) // �Ԃ̃��[�J�[���g���^�łȂ�
                {
                    continue;
                }
                PartsInfoDataSet.UsrGoodsInfoRow rowUsrGoods = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                    wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                // 2009/09/07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> DEL
                //if (rowUsrGoods == null) // TODO : TBO�}�X�^�ɓo�^����Ă�����̂����i�o�^����Ă��Ȃ��ꍇ�͂Ȃɂ����Ȃ��B
                //    continue;            //        �����d�l�ύX�̉\�������邽�߁A�Ď��ΏۂƂ���B
                // 2009/09/07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< DEL
                //�@�D�ǐݒ�i������
                // 2009.02.12 >>>
                //PrmSettingUWork prmSetting = null;
                //PrmSettingKey prmKey = new PrmSettingKey(_sectionCode, rowUsrGoods.GoodsMGroup,
                //        wkInf.BLGoodsCode, wkInf.JoinDestMakerCd);
                //if (_drPrmSettingWork.ContainsKey(prmKey))
                //{
                //    prmSetting = _drPrmSettingWork[prmKey];
                //}
                // 2009/09/07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> DELADD
                //PrmSettingUWork prmSetting = SearchPrmSettingUWork(_sectionCode, rowUsrGoods.GoodsMGroup, wkInf.BLGoodsCode, wkInf.JoinDestMakerCd, _drPrmSettingWork);
                PrmSettingUWork prmSetting; 
                if (rowUsrGoods != null)  prmSetting = SearchPrmSettingUWork(_sectionCode, rowUsrGoods.GoodsMGroup, wkInf.BLGoodsCode, wkInf.JoinDestMakerCd, _drPrmSettingWork);
                // 2009/09/07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< DELADD
                // 2009.02.12 <<<

                PartsInfoDataSet.TBOInfoRow row = partsInfo.TBOInfo.NewTBOInfoRow();

                //row.GoodsMGroup = rowUsrGoods.GoodsMGroup; // 2009/09/07 DEL
                if (rowUsrGoods != null) row.GoodsMGroup = rowUsrGoods.GoodsMGroup; // 2009/09/07 ADD
                row.TbsPartsCode = wkInf.BLGoodsCode;
                row.EquipGenreCode = wkInf.EquipGenreCode;
                row.EquipName = wkInf.EquipName;
                row.EquipSpecialNote = wkInf.EquipSpecialNote;
                row.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                row.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                row.JoinQty = wkInf.JoinQty;
                //row.PrimePartsName = rowUsrGoods.GoodsName; // 2009/09/07 DEL
                if (rowUsrGoods != null) row.PrimePartsName = rowUsrGoods.GoodsName; // 2009/09/07 ADD
                //row.PartsLayerCd = rowUsrGoods.GoodsRateRank;
                //row.PartsAttribute = wkInf.PartsAttribute;
                row.PrimePartsSpecialNote = wkInf.EquipSpecialNote;
                //row.CatalogDeleteFlag = wkInf.CatalogDeleteFlag;
                row.CarInfoJoinDispOrder = wkInf.CarInfoJoinDispOrder;
                row.JoinDestMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);

                partsInfo.TBOInfo.AddTBOInfoRow(row);

                // 2009/09/07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ADD
                if (rowUsrGoods != null) // ���ɓo�^����Ă���ꍇ�i�񋟂���̐ݒ肪����ꍇ�j
                {
                }
                else
                {
                    rowUsrGoods = goodsTable.NewUsrGoodsInfoRow();
                    //usrRow.EnterpriseCode = wkInf.EnterpriseCode;
                    //usrRow.FileHeaderGuid = wkInf.FileHeaderGuid;
                    //usrRow.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    //usrRow.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    //usrRow.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    //usrRow.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    //usrRow.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    //usrRow.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    rowUsrGoods.GoodsMakerCd = wkInf.JoinDestMakerCd;
                    rowUsrGoods.GoodsMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                    rowUsrGoods.GoodsNo = wkInf.JoinDestPartsNo;
                    //rowUsrGoods.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo;// DEL dpp 2013/03/15 Redmine#34377
                    rowUsrGoods.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-","");// ADD dpp 2013/03/15 Redmine#34377
                    //usrRow.GoodsName = "*";
                    //usrRow.GoodsNameKana = "*";
                    //usrRow.GoodsOfrName = wkInf.GoodsName;
                    //usrRow.GoodsOfrNameKana = wkInf.GoodsNameKana;
                    //usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    //usrRow.BlGoodsCode = wkInf..BLGoodsCode;
                    rowUsrGoods.DisplayOrder = wkInf.CarInfoJoinDispOrder;
                    //usrRow.GoodsNote1 = wkInf.GoodsNote1;
                    //usrRow.GoodsNote2 = wkInf.GoodsNote2;
                    //usrRow.GoodsSpecialNote = wkInf.JoinSpecialNote;
                    //usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                    //usrRow.OfferDate = DateTime.Today;
                    rowUsrGoods.GoodsKindCode = 0;
                    //usrRow.Jan = wkInf.Jan;
                    //usrRow.UpdateDate = wkInf.UpdateDate;
                    //usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                    //usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                    //usrRow.OfferDataDiv = wkInf.OfferDataDiv;

                    if (rowUsrGoods.OfferDate != DateTime.MinValue || rowUsrGoods.OfferDataDiv == 1)
                        rowUsrGoods.OfferKubun = 1; // ���[�U�[�o�^�̑�ցE�Z�b�g�E�������i�̏ꍇ�񋟏������D�ǂ��s���I
                    else
                        rowUsrGoods.OfferKubun = 0; // ���[�U�[�o�^
                    goodsTable.AddUsrGoodsInfoRow(rowUsrGoods);

                    string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfo.UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                        partsInfo.UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd);
                    partsInfo.UsrJoinParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfo.UsrJoinParts.DefaultView.Count; i++)
                    {
                        partsInfo.UsrJoinParts.DefaultView[i][partsInfo.UsrJoinParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                    rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfo.UsrSetParts.SubGoodsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                        partsInfo.UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd);
                    partsInfo.UsrSetParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfo.UsrSetParts.DefaultView.Count; i++)
                    {
                        partsInfo.UsrSetParts.DefaultView[i][partsInfo.UsrSetParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                }
                // 2009/09/07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< ADD
            }
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// �ԗ���񌋍����ݒ�(���[�U�[)
        /// ���[�U�[TBO���̕s�����͏��i�}�X�^����擾����
        /// </summary>
        /// <param name="tboSearchRet"></param>
        /// <param name="partsSearchUIDataDic"></param>
        private void FillTBOUInfoTable(ArrayList tboSearchRet, Dictionary<int, PartsSearchUIData> partsSearchUIDataDic)
        {
            if (tboSearchRet == null)
            {
                return;
            }

            List<int> dicKey = new List<int>(partsSearchUIDataDic.Keys);

            for (int index = 0; index < partsSearchUIDataDic.Count; index++)
            {
                // �P���ו��f�[�^�擾
                ArrayList tboSearchRetTemp = tboSearchRet[index] as ArrayList;
                int key = dicKey[index];

                foreach (TBOSearchUWork wkInf in tboSearchRet)
                {
                    if (searchPrtCtlAcs.TactiSearch == 0  // �^�N�e�B�����_��Ȃ�
                         && wkInf.JoinDestMakerCd == ct_TactiCd // ���i���[�J�[���^�N�e�B�[
                         && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd) // �Ԃ̃��[�J�[���g���^�łȂ�
                    {
                        continue;
                    }
                    PartsInfoDataSet.UsrGoodsInfoRow rowUsrGoods = partsInfoDic[key].UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                        wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                    PrmSettingUWork prmSetting;
                    if (rowUsrGoods != null) prmSetting = SearchPrmSettingUWork(_sectionCode, rowUsrGoods.GoodsMGroup, wkInf.BLGoodsCode, wkInf.JoinDestMakerCd, _drPrmSettingWork);

                    PartsInfoDataSet.TBOInfoRow row = partsInfoDic[key].TBOInfo.NewTBOInfoRow();

                    if (rowUsrGoods != null) row.GoodsMGroup = rowUsrGoods.GoodsMGroup;
                    row.TbsPartsCode = wkInf.BLGoodsCode;
                    row.EquipGenreCode = wkInf.EquipGenreCode;
                    row.EquipName = wkInf.EquipName;
                    row.EquipSpecialNote = wkInf.EquipSpecialNote;
                    row.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                    row.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                    row.JoinQty = wkInf.JoinQty;
                    if (rowUsrGoods != null) row.PrimePartsName = rowUsrGoods.GoodsName;
                    //row.PartsLayerCd = rowUsrGoods.GoodsRateRank;
                    //row.PartsAttribute = wkInf.PartsAttribute;
                    row.PrimePartsSpecialNote = wkInf.EquipSpecialNote;
                    //row.CatalogDeleteFlag = wkInf.CatalogDeleteFlag;
                    row.CarInfoJoinDispOrder = wkInf.CarInfoJoinDispOrder;
                    row.JoinDestMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);

                    partsInfoDic[key].TBOInfo.AddTBOInfoRow(row);

                    if (rowUsrGoods != null) // ���ɓo�^����Ă���ꍇ�i�񋟂���̐ݒ肪����ꍇ�j
                    {
                    }
                    else
                    {
                        rowUsrGoods = goodsTableDic[key].NewUsrGoodsInfoRow();
                        //usrRow.EnterpriseCode = wkInf.EnterpriseCode;
                        //usrRow.FileHeaderGuid = wkInf.FileHeaderGuid;
                        //usrRow.CreateDateTime = wkInf.CreateDateTime.Ticks;
                        //usrRow.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                        //usrRow.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                        //usrRow.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                        //usrRow.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                        //usrRow.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                        rowUsrGoods.GoodsMakerCd = wkInf.JoinDestMakerCd;
                        rowUsrGoods.GoodsMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                        rowUsrGoods.GoodsNo = wkInf.JoinDestPartsNo;
                        rowUsrGoods.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-", "");
                        //usrRow.GoodsName = "*";
                        //usrRow.GoodsNameKana = "*";
                        //usrRow.GoodsOfrName = wkInf.GoodsName;
                        //usrRow.GoodsOfrNameKana = wkInf.GoodsNameKana;
                        //usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                        //usrRow.BlGoodsCode = wkInf..BLGoodsCode;
                        rowUsrGoods.DisplayOrder = wkInf.CarInfoJoinDispOrder;
                        //usrRow.GoodsNote1 = wkInf.GoodsNote1;
                        //usrRow.GoodsNote2 = wkInf.GoodsNote2;
                        //usrRow.GoodsSpecialNote = wkInf.JoinSpecialNote;
                        //usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                        //usrRow.OfferDate = DateTime.Today;
                        rowUsrGoods.GoodsKindCode = 0;
                        //usrRow.Jan = wkInf.Jan;
                        //usrRow.UpdateDate = wkInf.UpdateDate;
                        //usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                        //usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                        //usrRow.OfferDataDiv = wkInf.OfferDataDiv;

                        if (rowUsrGoods.OfferDate != DateTime.MinValue || rowUsrGoods.OfferDataDiv == 1)
                            rowUsrGoods.OfferKubun = 1; // ���[�U�[�o�^�̑�ցE�Z�b�g�E�������i�̏ꍇ�񋟏������D�ǂ��s���I
                        else
                            rowUsrGoods.OfferKubun = 0; // ���[�U�[�o�^
                        goodsTableDic[key].AddUsrGoodsInfoRow(rowUsrGoods);

                        string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                            partsInfoDic[key].UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                            partsInfoDic[key].UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd);
                        partsInfoDic[key].UsrJoinParts.DefaultView.RowFilter = rowFilter;
                        for (int i = 0; i < partsInfoDic[key].UsrJoinParts.DefaultView.Count; i++)
                        {
                            partsInfoDic[key].UsrJoinParts.DefaultView[i][partsInfoDic[key].UsrJoinParts.PrmSettingFlgColumn.ColumnName] = true;
                        }
                        rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                            partsInfoDic[key].UsrSetParts.SubGoodsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                            partsInfoDic[key].UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd);
                        partsInfoDic[key].UsrSetParts.DefaultView.RowFilter = rowFilter;
                        for (int i = 0; i < partsInfoDic[key].UsrSetParts.DefaultView.Count; i++)
                        {
                            partsInfoDic[key].UsrSetParts.DefaultView[i][partsInfoDic[key].UsrSetParts.PrmSettingFlgColumn.ColumnName] = true;
                        }
                    }
                }
            }

        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        # region UI�p�F�D�Ǖ��i�ڍׁi�^�����j�ݒ�
        /// <summary>
        /// UI�p�F�D�Ǖ��i�ڍׁi�^�����j�ݒ�
        /// </summary>
        /// <param name="list"></param>
        private void ListPrimePartsDetail_Tables(ArrayList list)
        {
            // TODO : �D�ǌ^���d�l�m���
            //���q��񁨕��i�ڍׁi�^�����j�ݒ�
            if (list != null)
            {
                //DataView CustomView = new DataView(); //_CarSearchController.CarModelDataTable);
                //DataView PartsDetail_View = new DataView(PartsDetail_Table);
                //string stinf = "";

                foreach (OfferPrimeSearchRetWork wkInf in list)
                {
                    //CustomView.RowFilter = "";
                    // String.Format("{0} = " + wkInf.FullModelFixedNo, PartsDetailInfo.COL_PRTDTL_FULLMODELFIXEDNO);
                    //if (CustomView.Count == 0)
                    //{
                    //    continue;
                    //}
                    //stinf = string.Format("{0} = {1} AND {2} = {3} AND {4} = {5} AND {6} = {7} AND {8} = {9} AND {10} = {11} ", 
                    //    partsInfo.ModelPartsDetail.ModelGradeNmColumn.ColumnName, wkInf.model
                    PartsInfoDataSet.ModelPartsDetailRow[] modelDetailRow =
                        (PartsInfoDataSet.ModelPartsDetailRow[])partsInfo.ModelPartsDetail.Select();

                    ////���q��񁨕��i�ڍׁi�^�����j�ݒ�
                    //stinf = "{0} = '" + CustomView[0]["COL_MODELGRADENM"] + "'"
                    //    + "  AND {1} = '" + CustomView[0]["COL_BODYNAME"] + "'"
                    //    + "  AND {2} = " + CustomView[0]["COL_DOORCOUNT"]
                    //    + "  AND {3} = '" + CustomView[0]["COL_ENGINEMODELNM"] + "'"
                    //    + "  AND {4} = '" + CustomView[0]["COL_ENGINEDISPLACENM"] + "'"
                    //    + "  AND {5} = '" + CustomView[0]["COL_EDIVNM"] + "'"
                    //    + "  AND {6} = '" + CustomView[0]["COL_TRANSMISSIONNM"] + "'"
                    //    + "  AND {7} = '" + CustomView[0]["COL_SHIFTNM"] + "'"
                    //    + "  AND {8} = " + wkInf.PartsMakerCd
                    //    + "  AND {9} = '" + wkInf.PrimePartsNoWithH + "'"
                    //;

                    //PartsDetail_View.RowFilter = String.Format(stinf
                    //    , PartsDetailInfo.COL_PRTDTL_MODELGRADENM
                    //    , PartsDetailInfo.COL_PRTDTL_BODYNAME
                    //    , PartsDetailInfo.COL_PRTDTL_DOORCOUNT
                    //    , PartsDetailInfo.COL_PRTDTL_ENGINEMODELNM
                    //    , PartsDetailInfo.COL_PRTDTL_ENGINEDISPLACENM
                    //    , PartsDetailInfo.COL_PRTDTL_EDIVNM
                    //    , PartsDetailInfo.COL_PRTDTL_TRANSMISSIONNM
                    //    , PartsDetailInfo.COL_PRTDTL_SHIFTNM
                    //    , PartsDetailInfo.COL_PRTDTL_PARTSMAKERCD
                    //    , PartsDetailInfo.COL_PRTDTL_PARTSNO
                    //);
                    //if (PartsDetail_View.Count != 0)
                    //{
                    //    continue;
                    //}

                    //PartsDetail_View.RowFilter = "";

                    //DataRow srcRow = CustomView[0].Row;
                    //DataRow wkRow = PartsDetail_Table.NewRow();

                    //wkRow[PartsDetailInfo.COL_PRTDTL_PARTS_PARTSUNIQUENO] = 0;

                    //wkRow[PartsDetailInfo.COL_PRTDTL_FULLMODELFIXEDNO] = CustomView[0]["COL_FULLMODELFIXEDNO"]; // TODO
                    //wkRow[PartsDetailInfo.COL_PRTDTL_PARTSMAKERCD] = wkInf.PartsMakerCd;
                    //wkRow[PartsDetailInfo.COL_PRTDTL_PARTSNO] = wkInf.PrimePartsNoWithH;

                    //wkRow[PartsDetailInfo.COL_PRTDTL_DOORCOUNT] = CustomView[0]["COL_DOORCOUNT"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_BODYNAME] = CustomView[0]["COL_BODYNAME"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_MODELGRADENM] = CustomView[0]["COL_MODELGRADENM"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ENGINEMODELNM] = CustomView[0]["COL_ENGINEMODELNM"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ENGINEDISPLACENM] = CustomView[0]["COL_ENGINEDISPLACENM"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_EDIVNM] = CustomView[0]["COL_EDIVNM"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_TRANSMISSIONNM] = CustomView[0]["COL_TRANSMISSIONNM"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_SHIFTNM] = CustomView[0]["COL_SHIFTNM"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPEC1] = CustomView[0]["COL_ADDICARSPEC1"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPEC2] = CustomView[0]["COL_ADDICARSPEC2"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPEC3] = CustomView[0]["COL_ADDICARSPEC3"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPEC4] = CustomView[0]["COL_ADDICARSPEC4"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPEC5] = CustomView[0]["COL_ADDICARSPEC5"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPEC6] = CustomView[0]["COL_ADDICARSPEC6"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPECTITLE1] = CustomView[0]["COL_ADDICARSPECTITLE1"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPECTITLE2] = CustomView[0]["COL_ADDICARSPECTITLE2"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPECTITLE3] = CustomView[0]["COL_ADDICARSPECTITLE3"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPECTITLE4] = CustomView[0]["COL_ADDICARSPECTITLE4"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPECTITLE5] = CustomView[0]["COL_ADDICARSPECTITLE5"];
                    //wkRow[PartsDetailInfo.COL_PRTDTL_ADDICARSPECTITLE6] = CustomView[0]["COL_ADDICARSPECTITLE6"];

                    //PartsDetail_Table.Rows.Add(wkRow);
                }
            }
        }
        # endregion

        # region ���i���ݒ�
        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
        //private void FillPartsInfo(ArrayList retPartsInf, List<PartsModelLnkWork> partsModelLnkWork)
        private void FillPartsInfo( ArrayList retPartsInf, List<PartsModelLnkWork> partsModelLnkWork, GetPartsInfPara inPara )
        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
        {
            if (retPartsInf == null)
            {
                return;
            }
            // --- ADD 2015/04/03 T.Miyamoto SCM�d�|�ꗗ��10715 ------------------------------>>>>>
            Dictionary<NewKey, RetPartsInf> newPartsInfoDic;
            newPartsInfoDic = new Dictionary<NewKey, RetPartsInf>();
            bool setFlg;
            RetPartsInf newPartsInf;

            // �Y�����i�̐V�i�ԏ��i������BL�R�[�h�}�ԂƈقȂ�j�𒊏o
            if (inPara != null && inPara.TbsPartsCode != 0 && inPara.TbsPartsCdDerivedNo != 0) // BL�R�[�h�}�Ԃ������Ɋ܂܂�Ă���ꍇ
            {
                foreach (RetPartsInf wkPartsInf in retPartsInf)
                {
                    NewKey _newKey = new NewKey(wkPartsInf.CatalogPartsMakerCd, wkPartsInf.NewPrtsNoWithHyphen.Trim());
                    if ((inPara.TbsPartsCdDerivedNo == wkPartsInf.TbsPartsCdDerivedNo)                    // ���������Ŏw�肳�ꂽBL�R�[�h�}�ԂƓ���
                     && (wkPartsInf.NewPrtsNoWithHyphen.Trim() != wkPartsInf.ClgPrtsNoWithHyphen.Trim())  // �V�i�Ԃ��ݒ肳��Ă���
                     && (!newPartsInfoDic.ContainsKey(_newKey)))                                          // �V�i�ԏ�񖢌���
                    {
                        setFlg = false;
                        newPartsInf = null;
                        // �V�i�Ԃ�����
                        foreach (RetPartsInf chkPartsInf in retPartsInf)
                        {
                            if ((wkPartsInf.CatalogPartsMakerCd == chkPartsInf.CatalogPartsMakerCd) &&
                                (wkPartsInf.NewPrtsNoWithHyphen.Trim() == chkPartsInf.ClgPrtsNoWithHyphen.Trim()))
                            {
                                if (inPara.TbsPartsCdDerivedNo == chkPartsInf.TbsPartsCdDerivedNo)
                                {
                                    // BL�R�[�h�}�Ԃ������̎}�ԂƓ���̏ꍇ�����I���i�Y���i�Ƃ��Ē��o����邽�ߕs�v�j
                                    setFlg = false;
                                    break;
                                }
                                else
                                {
                                    // BL�R�[�h�}�Ԃ������̎}�ԂƈقȂ�ꍇ�A���o�ΏۂƂ��ĕێ�
                                    setFlg = true;
                                    newPartsInf = chkPartsInf;
                                }
                            }
                        }
                        if (setFlg)
                        {
                            // �V�i�ԏ���v���o�f�[�^�Ƃ��Ċi�[
                            if (!newPartsInfoDic.ContainsKey(_newKey))
                            {
                                newPartsInfoDic.Add(_newKey, newPartsInf);
                            }
                        }
                    }
                }
            }
            // --- ADD 2015/04/03 T.Miyamoto SCM�d�|�ꗗ��10715 ------------------------------<<<<<

            foreach (RetPartsInf wkPartsInf in retPartsInf)
            {
                // --- ADD m.suzuki 2011/05/18 ---------->>>>>
                bool derivedNmSetFlag = false;

                // BL�R�[�h�}�ԑΉ��i��BL�R�[�h�������̂݁j
                if ( inPara != null && inPara.TbsPartsCode != 0 && inPara.TbsPartsCdDerivedNo != 0 )
                {
                    // ���������Ŏw�肳�ꂽ�}�ԂƈقȂ�ꍇ�͉I��
                    if ( inPara.TbsPartsCdDerivedNo != wkPartsInf.TbsPartsCdDerivedNo )
                    {
                        // --- UPD 2015/04/03 T.Miyamoto SCM�d�|�ꗗ��10715 ------------------------------>>>>>
                        //continue;
                        // �Y�����i�̐V�i�ԂƂ��Đݒ肳��Ă��Ȃ���Έȍ~�̏������s��Ȃ�
                        NewKey _chkKey = new NewKey(wkPartsInf.CatalogPartsMakerCd, wkPartsInf.ClgPrtsNoWithHyphen.Trim());
                        if (!newPartsInfoDic.ContainsKey(_chkKey))
                        {
                            continue;
                        }
                        // --- UPD 2015/04/03 T.Miyamoto SCM�d�|�ꗗ��10715 ------------------------------<<<<<
                    }

                    // ���o������BL�R�[�h�}�Ԃ��ݒ肳��Ă���ꍇ�́A�}�ԗp���i���̂�t�^����B
                    if ( !string.IsNullOrEmpty( wkPartsInf.PartsName ) ) wkPartsInf.PartsName = wkPartsInf.PartsName + wkPartsInf.TbsPartsCdDerivedNm;
                    if ( !string.IsNullOrEmpty( wkPartsInf.PartsNameKana ) ) wkPartsInf.PartsNameKana = wkPartsInf.PartsNameKana + wkPartsInf.TbsPartsCdDerivedNm;
                    if ( !string.IsNullOrEmpty( wkPartsInf.MakerOfferPartsName ) ) wkPartsInf.MakerOfferPartsName = wkPartsInf.MakerOfferPartsName + wkPartsInf.TbsPartsCdDerivedNm;
                    if ( !string.IsNullOrEmpty( wkPartsInf.MakerOfferPartsKana ) ) wkPartsInf.MakerOfferPartsKana = wkPartsInf.MakerOfferPartsKana + wkPartsInf.TbsPartsCdDerivedNm;
                    derivedNmSetFlag = true;
                }
                // --- ADD m.suzuki 2011/05/18 ----------<<<<<

                #region ���i���ݒ�
                PartsInfoDataSet.PartsInfoRow partsInfoRow = partsInfo.PartsInfo.NewPartsInfoRow();

                partsInfoRow.OfferDate = wkPartsInf.OfferDate;
                partsInfoRow.PartsSearchCode = wkPartsInf.PartsSearchCode;
                partsInfoRow.PartsNarrowingCode = wkPartsInf.PartsNarrowingCode;
                partsInfoRow.PartsName = wkPartsInf.PartsName;
                partsInfoRow.PartsNameKana = wkPartsInf.PartsNameKana;
                partsInfoRow.PartsCode = wkPartsInf.PartsCode;
                partsInfoRow.WorkOrPartsDivNm = wkPartsInf.WorkOrPartsDivNm;
                partsInfoRow.FullModelFixedNo = wkPartsInf.FullModelFixedNo;
                partsInfoRow.TbsPartsCode = wkPartsInf.TbsPartsCode;
                partsInfoRow.TbsPartsCdDerivedNo = wkPartsInf.TbsPartsCdDerivedNo;
                partsInfoRow.FigshapeNo = wkPartsInf.FigShapeNo;
                partsInfoRow.ModelPrtsAdptYm = wkPartsInf.ModelPrtsAdptYm;
                partsInfoRow.ModelPrtsAblsYm = wkPartsInf.ModelPrtsAblsYm;
                partsInfoRow.ModelPrtsAdptFrameNo = wkPartsInf.ModelPrtsAdptFrameNo;
                partsInfoRow.ModelPrtsAblsFrameNo = wkPartsInf.ModelPrtsAblsFrameNo;
                partsInfoRow.PartsQty = wkPartsInf.PartsQty;
                partsInfoRow.PartsOpNm = wkPartsInf.PartsOpNm;
                partsInfoRow.StandardName = wkPartsInf.StandardName;
                partsInfoRow.CatalogPartsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                partsInfoRow.CatalogPartsMakerNm = GetPartsMakerName(wkPartsInf.CatalogPartsMakerCd);

                partsInfoRow.ClgPrtsNoWithHyphen = wkPartsInf.ClgPrtsNoWithHyphen.Trim();
                if (partsInfoRow.ClgPrtsNoWithHyphen == string.Empty)                   // �{���͂����Ă͂����Ȃ��P�[�X�����A�f�[�^�̐������̖���
                    partsInfoRow.ClgPrtsNoWithHyphen = wkPartsInf.NewPrtsNoWithHyphen;  // ��Q��h���ړI�ł��̏�����ǉ�
                partsInfoRow.ColdDistrictsFlag = wkPartsInf.ColdDistrictsFlag;
                partsInfoRow.ColorNarrowingFlag = wkPartsInf.ColorNarrowingFlag;
                partsInfoRow.TrimNarrowingFlag = wkPartsInf.TrimNarrowingFlag;
                partsInfoRow.EquipNarrowingFlag = wkPartsInf.EquipNarrowingFlag;
                partsInfoRow.MakerOfferPartsName = wkPartsInf.MakerOfferPartsName;
                partsInfoRow.PartsLayerCd = wkPartsInf.PartsLayerCd;
                partsInfoRow.PartsUniqueNo = wkPartsInf.PartsUniqueNo;

                partsInfoRow.NewPrtsNoWithHyphen = wkPartsInf.NewPrtsNoWithHyphen;
                partsInfoRow.NewPrtsNoNoneHyphen = wkPartsInf.NewPrtsNoNoneHyphen;
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009.07.23 ADD
                partsInfoRow.SeriesModel = wkPartsInf.SeriesModel;
                partsInfoRow.CategorySignModel = wkPartsInf.CategorySignModel;
                partsInfoRow.ExhaustGasSign = wkPartsInf.ExhaustGasSign;
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009.07.23 ADD

                // --- ADD m.suzuki 2011/05/18 ---------->>>>>
                // �������ϕ��i�R�[�h
                partsInfoRow.AutoEstimatePartsCd = wkPartsInf.AutoEstimatePartsCd;
                // BL�R�[�h�}�ԗp���i����
                if ( derivedNmSetFlag )
                {
                    partsInfoRow.TbsPartsCdDerivedNm = wkPartsInf.TbsPartsCdDerivedNm;
                }
                // --- ADD m.suzuki 2011/05/18 ----------<<<<<
                	
                // ADD 2013/02/17 2013/04/10�z�M SCM��Q��10355�Ή� ------------------------------->>>>>
                partsInfoRow.PrimeJoinLnkFlg = wkPartsInf.PrimeJoinLnkFlg;
                // ADD 2013/02/17 2013/04/10�z�M SCM��Q��10355�Ή� -------------------------------<<<<<

                // --- ADD 2013/03/27 ---------->>>>>
                // VIN���YNo.(�n��)��VIN���YNo.(�I��)���i�[����
                partsInfoRow.VinProduceStartNo = wkPartsInf.VinProduceStartNo.ToString("000000");
                partsInfoRow.VinProduceEndNo = wkPartsInf.VinProduceEndNo.ToString("000000");
                // --- ADD 2013/03/27 ----------<<<<<

                partsInfo.PartsInfo.AddPartsInfoRow(partsInfoRow);
                #endregion

                #region ���i�}�X�^�e�[�u���ɐݒ�
                string partsNo = wkPartsInf.ClgPrtsNoWithHyphen;
                PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                    goodsTable.FindByGoodsMakerCdGoodsNo(wkPartsInf.CatalogPartsMakerCd, partsNo);
                if (usrGoodsRow == null)
                {
                    usrGoodsRow = goodsTable.NewUsrGoodsInfoRow();
                    usrGoodsRow.BlGoodsCode = wkPartsInf.TbsPartsCode;
                    usrGoodsRow.GoodsKindCode = 0; // 0 : ����
                    usrGoodsRow.GoodsKind = (int)GoodsKind.Parent; // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                    usrGoodsRow.GoodsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                    usrGoodsRow.GoodsMakerNm = partsInfoRow.CatalogPartsMakerNm;
                    //usrGoodsRow.GoodsMGroup = 0;
                    usrGoodsRow.GoodsRateRank = wkPartsInf.PartsLayerCd;
                    usrGoodsRow.GoodsNoNoneHyphen = partsInfoRow.ClgPrtsNoWithHyphen.Replace("-", "");
                    usrGoodsRow.QTY = wkPartsInf.PartsQty;
                    usrGoodsRow.GoodsNote1 = wkPartsInf.StandardName; //�K�i
                    //usrGoodsRow.GoodsNote2 = "";
                    usrGoodsRow.GoodsSpecialNote = wkPartsInf.PartsOpNm;
                    // ADD 2013/02/12 T.Yoshioka 2013/03/06�z�M�\�� SCM��Q��169 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                    usrGoodsRow.GoodsSpecialNoteOffer = wkPartsInf.PartsOpNm;   // ���i�K�i�E���L�����i�񋟁j
                    // ADD 2013/02/12 T.Yoshioka 2013/03/06�z�M�\�� SCM��Q��169 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    usrGoodsRow.OfferDate = wkPartsInf.OfferDate;
                    usrGoodsRow.OfferKubun = 3; // �񋟏��� (0:���[�U�[�o�^�^1:�񋟏����ҏW�^2:�񋟗D�ǕҏW�^3:�񋟏����^4:�񋟗D�ǁj
                    //usrGoodsRow.TaxationDivCd = 0;
                    usrGoodsRow.GoodsNo = partsInfoRow.ClgPrtsNoWithHyphen;
                    usrGoodsRow.OfferDataDiv = 1;

                    if (wkPartsInf.MakerOfferPartsName != string.Empty)
                    {
                        usrGoodsRow.GoodsName = wkPartsInf.MakerOfferPartsName; // ���i���F�f�t�H���g�͕��i��
                        usrGoodsRow.GoodsNameKana = wkPartsInf.MakerOfferPartsKana;
                    }
                    else // �Â����i�͖��̂����Ȃ��̂�
                    {
                        usrGoodsRow.GoodsName = wkPartsInf.PartsName; // �����i��
                        usrGoodsRow.GoodsNameKana = wkPartsInf.PartsNameKana;
                    }
                    usrGoodsRow.GoodsOfrName = wkPartsInf.MakerOfferPartsName; // ���i��
                    usrGoodsRow.GoodsOfrNameKana = wkPartsInf.MakerOfferPartsKana;
                    usrGoodsRow.SearchPartsFullName = wkPartsInf.PartsName; // �����i��
                    usrGoodsRow.SearchPartsHalfName = wkPartsInf.PartsNameKana;
                    usrGoodsRow.SrchPNmAcqrCarMkrCd = wkPartsInf.SrchPNmAcqrCarMkrCd;   // �����i���擾���[�J�[�R�[�h   // 2009/11/24 Add   
                    // 2009/12/09 Add >>>
                    usrGoodsRow.PartsPriceStDate = wkPartsInf.PartsPriceStDate;
                    // 2009/12/09 Add <<<
                    
                    // 2010/02/25 Add >>>
                    if (wkPartsInf.TbsPartsCdDerivedNo != 0)
                    {
                        string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkPartsInf.TbsPartsCode,
                                                                           ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkPartsInf.TbsPartsCdDerivedNo);
                        BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                        if ((rows != null) && (rows.Length != 0))
                        {
                            usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                            usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                            usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // ���i��
                            usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                            usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // �����i��
                            usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                        }
                    }
                    // 2010/02/25 Add <<<
                    partsInfoRow.UsrGoodsInfoRowParentByUsrGoodsInfo_PartsInfo = usrGoodsRow;
                    goodsTable.AddUsrGoodsInfoRow(usrGoodsRow);
                }


                // 2009/12/09 Add >>>
                // BL�R�[�h�A�i���A�w�ʂ͏�ɍŐV�̃f�[�^���g�p����
                if (usrGoodsRow.PartsPriceStDate < wkPartsInf.PartsPriceStDate)
                {
                    // �i���̍X�V
                    if (!string.IsNullOrEmpty(wkPartsInf.MakerOfferPartsName))
                    {
                        usrGoodsRow.GoodsName = wkPartsInf.MakerOfferPartsName;     // ���i��
                        usrGoodsRow.GoodsNameKana = wkPartsInf.MakerOfferPartsKana;

                        usrGoodsRow.GoodsOfrName = wkPartsInf.MakerOfferPartsName;  // ���i��
                        usrGoodsRow.GoodsOfrNameKana = wkPartsInf.MakerOfferPartsKana;
                    }

                    // BL�R�[�h�̍X�V
                    if (wkPartsInf.TbsPartsCode != 0)
                    {
                        usrGoodsRow.BlGoodsCode = wkPartsInf.TbsPartsCode;
                    }

                    usrGoodsRow.GoodsRateRank = wkPartsInf.PartsLayerCd;            // �w��

                    usrGoodsRow.PartsPriceStDate = wkPartsInf.PartsPriceStDate;     // �񋟂̉��i�擾�����X�V
                }
                // 2009/12/09 Add <<<

                #region USR Price
                if (wkPartsInf.PriceOfferDate != DateTime.MinValue &&
                    priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkPartsInf.CatalogPartsMakerCd,
                    wkPartsInf.PartsPriceStDate, wkPartsInf.ClgPrtsNoWithHyphen) == null)
                {
                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTable.NewUsrGoodsPriceRow();
                    usrPriceRow.GoodsNo = wkPartsInf.ClgPrtsNoWithHyphen;
                    usrPriceRow.GoodsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                    // 2009.02.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //usrPriceRow.ListPrice = wkPartsInf.PartsPrice;
                    double listPrice = wkPartsInf.PartsPrice;
                    this.ReflectIsolIslandCall(0, wkPartsInf.CatalogPartsMakerCd, 3, ref listPrice);
                    usrPriceRow.ListPrice = listPrice;
                    // 2009.02.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    usrPriceRow.OfferDate = wkPartsInf.PriceOfferDate;
                    usrPriceRow.OpenPriceDiv = wkPartsInf.OpenPriceDiv;
                    usrPriceRow.PriceStartDate = wkPartsInf.PartsPriceStDate;
                    //usrPriceRow.SalesUnitCost = 0;
                    //usrPriceRow.StockRate = 0;
                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                    priceTable.AddUsrGoodsPriceRow(usrPriceRow);
                }
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                if (wkPartsInf.PriceOfferDate != DateTime.MinValue &&
                    ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkPartsInf.CatalogPartsMakerCd,
                    wkPartsInf.PartsPriceStDate, wkPartsInf.ClgPrtsNoWithHyphen) == null)
                {
                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTable.NewUsrGoodsPriceRow();
                    usrPriceRow.GoodsNo = wkPartsInf.ClgPrtsNoWithHyphen;
                    usrPriceRow.GoodsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                    double listPrice = wkPartsInf.PartsPrice;
                    this.ReflectIsolIslandCall(0, wkPartsInf.CatalogPartsMakerCd, 3, ref listPrice);
                    usrPriceRow.ListPrice = listPrice;
                    usrPriceRow.OfferDate = wkPartsInf.PriceOfferDate;
                    usrPriceRow.OpenPriceDiv = wkPartsInf.OpenPriceDiv;
                    usrPriceRow.PriceStartDate = wkPartsInf.PartsPriceStDate;
                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                    ofrPriceTable.AddUsrGoodsPriceRow(usrPriceRow);
                }
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
                #endregion
                #endregion

                #region ���i�֘A�^�����ݒ�
                if (carInfoDataSet != null && partsModelLnkWork != null)
                {
                    PartsInfoDataSet.ModelPartsDetailDataTable modelInfo = partsInfo.ModelPartsDetail;
                    foreach (PartsModelLnkWork wkModelInf in partsModelLnkWork)
                    {
                        if (wkModelInf.PartsProperNo != wkPartsInf.PartsUniqueNo)
                            continue;

                        string select = "FullModelFixedNo in (";
                        for (int i = 0; i < wkModelInf.FullModelFixedNos.Count; i++)
                        {
                            select += wkModelInf.FullModelFixedNos[i].ToString() + ", ";
                        }
                        select.Remove(select.Length - 2);
                        select += ")";

                        PMKEN01010E.CarModelInfoRow[] carModelInfoRows = (PMKEN01010E.CarModelInfoRow[])carInfoDataSet.CarModelInfo.Select(select);

                        //���q��񁨕��i�ڍׁi�^�����j�ݒ�
                        for (int ix = 0; ix < carModelInfoRows.Length; ix++)
                        {
                            string filter = string.Format("{0} = {1} AND {2} = {3}",
                                modelInfo.PartsUniqueNoColumn.ColumnName, wkModelInf.PartsProperNo,
                                modelInfo.FullModelFixedNoColumn.ColumnName, carModelInfoRows[ix].FullModelFixedNo);
                            PartsInfoDataSet.ModelPartsDetailRow[] row = (PartsInfoDataSet.ModelPartsDetailRow[])modelInfo.Select(filter);
                            if (row.Length > 0)
                                continue;
                            PartsInfoDataSet.ModelPartsDetailRow modelPartsDetailRow = modelInfo.NewModelPartsDetailRow();

                            modelPartsDetailRow.PartsUniqueNo = wkModelInf.PartsProperNo;
                            modelPartsDetailRow.PartsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                            modelPartsDetailRow.PartsNo = wkPartsInf.ClgPrtsNoWithHyphen;

                            modelPartsDetailRow.FullModelFixedNo = carModelInfoRows[ix].FullModelFixedNo;
                            modelPartsDetailRow.DoorCount = carModelInfoRows[ix].DoorCount;
                            modelPartsDetailRow.BodyName = carModelInfoRows[ix].BodyName;
                            modelPartsDetailRow.ModelGradeNm = carModelInfoRows[ix].ModelGradeNm;
                            modelPartsDetailRow.EngineModelNm = carModelInfoRows[ix].EngineModelNm;
                            modelPartsDetailRow.EngineDisplaceNm = carModelInfoRows[ix].EngineDisplaceNm;
                            modelPartsDetailRow.EDivNm = carModelInfoRows[ix].EDivNm;
                            modelPartsDetailRow.TransmissionNm = carModelInfoRows[ix].TransmissionNm;
                            modelPartsDetailRow.ShiftNm = carModelInfoRows[ix].ShiftNm;
                            modelPartsDetailRow.WheelDriveMethodNm = carModelInfoRows[ix].WheelDriveMethodNm;
                            modelPartsDetailRow.AddiCarSpec1 = carModelInfoRows[ix].AddiCarSpec1;
                            modelPartsDetailRow.AddiCarSpec2 = carModelInfoRows[ix].AddiCarSpec2;
                            modelPartsDetailRow.AddiCarSpec3 = carModelInfoRows[ix].AddiCarSpec3;
                            modelPartsDetailRow.AddiCarSpec4 = carModelInfoRows[ix].AddiCarSpec4;
                            modelPartsDetailRow.AddiCarSpec5 = carModelInfoRows[ix].AddiCarSpec5;
                            modelPartsDetailRow.AddiCarSpec6 = carModelInfoRows[ix].AddiCarSpec6;
                            //modelPartsDetailRow.AddiCarSpecTitle1 = carModelInfoRows[ix].AddiCarSpecTitle1;
                            //modelPartsDetailRow.AddiCarSpecTitle2 = carModelInfoRows[ix].AddiCarSpecTitle2;
                            //modelPartsDetailRow.AddiCarSpecTitle3 = carModelInfoRows[ix].AddiCarSpecTitle3;
                            //modelPartsDetailRow.AddiCarSpecTitle4 = carModelInfoRows[ix].AddiCarSpecTitle4;
                            //modelPartsDetailRow.AddiCarSpecTitle5 = carModelInfoRows[ix].AddiCarSpecTitle5;
                            //modelPartsDetailRow.AddiCarSpecTitle6 = carModelInfoRows[ix].AddiCarSpecTitle6;

                            modelInfo.AddModelPartsDetailRow(modelPartsDetailRow);
                        }
                        if (carModelInfoRows.Length > 0)
                        {
                            modelInfo.Columns[modelInfo.AddiCarSpec1Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle1;
                            modelInfo.Columns[modelInfo.AddiCarSpec2Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle2;
                            modelInfo.Columns[modelInfo.AddiCarSpec3Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle3;
                            modelInfo.Columns[modelInfo.AddiCarSpec4Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle4;
                            modelInfo.Columns[modelInfo.AddiCarSpec5Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle5;
                            modelInfo.Columns[modelInfo.AddiCarSpec6Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle6;
                        }
                    }
                }
                #endregion
            }
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        ///  ���i���ݒ�
        /// </summary>
        /// <param name="retPartsInf"></param>
        /// <param name="partsModelLnkWork"></param>
        /// <param name="inPara"></param>
        /// <param name="key"></param>
        private void FillPartsInfo(ArrayList retPartsInf, List<PartsModelLnkWork> partsModelLnkWork, GetPartsInfPara inPara, int key)
        {
            if (retPartsInf == null)
            {
                return;
            }

            // --- ADD 2015/04/03 T.Miyamoto SCM�d�|�ꗗ��10715 ------------------------------>>>>>
            Dictionary<NewKey, RetPartsInf> newPartsInfoDic;
            newPartsInfoDic = new Dictionary<NewKey, RetPartsInf>();
            bool setFlg;
            RetPartsInf newPartsInf;

            // �Y�����i�̐V�i�ԏ��i������BL�R�[�h�}�ԂƈقȂ�j�𒊏o
            if (inPara != null && inPara.TbsPartsCode != 0 && inPara.TbsPartsCdDerivedNo != 0) // BL�R�[�h�}�Ԃ������Ɋ܂܂�Ă���ꍇ
            {
                foreach (RetPartsInf wkPartsInf in retPartsInf)
                {
                    NewKey _newKey = new NewKey(wkPartsInf.CatalogPartsMakerCd, wkPartsInf.NewPrtsNoWithHyphen.Trim());
                    if ((inPara.TbsPartsCdDerivedNo == wkPartsInf.TbsPartsCdDerivedNo)                    // ���������Ŏw�肳�ꂽBL�R�[�h�}�ԂƓ���
                     && (wkPartsInf.NewPrtsNoWithHyphen.Trim() != wkPartsInf.ClgPrtsNoWithHyphen.Trim())  // �V�i�Ԃ��ݒ肳��Ă���
                     && (!newPartsInfoDic.ContainsKey(_newKey)))                                          // �V�i�ԏ�񖢌���
                    {
                        setFlg = false;
                        newPartsInf = null;
                        // �V�i�Ԃ�����
                        foreach (RetPartsInf chkPartsInf in retPartsInf)
                        {
                            if ((wkPartsInf.CatalogPartsMakerCd == chkPartsInf.CatalogPartsMakerCd) &&
                                (wkPartsInf.NewPrtsNoWithHyphen.Trim() == chkPartsInf.ClgPrtsNoWithHyphen.Trim()))
                            {
                                if (inPara.TbsPartsCdDerivedNo == chkPartsInf.TbsPartsCdDerivedNo)
                                {
                                    // BL�R�[�h�}�Ԃ������̎}�ԂƓ���̏ꍇ�����I���i�Y���i�Ƃ��Ē��o����邽�ߕs�v�j
                                    setFlg = false;
                                    break;
                                }
                                else
                                {
                                    // BL�R�[�h�}�Ԃ������̎}�ԂƈقȂ�ꍇ�A���o�ΏۂƂ��ĕێ�
                                    setFlg = true;
                                    newPartsInf = chkPartsInf;
                                }
                            }
                        }
                        if (setFlg)
                        {
                            // �V�i�ԏ���v���o�f�[�^�Ƃ��Ċi�[
                            if (!newPartsInfoDic.ContainsKey(_newKey))
                            {
                                newPartsInfoDic.Add(_newKey, newPartsInf);
                            }
                        }
                    }
                }
            }
            // --- ADD 2015/04/03 T.Miyamoto SCM�d�|�ꗗ��10715 ------------------------------<<<<<

            foreach (RetPartsInf wkPartsInf in retPartsInf)
            {
                bool derivedNmSetFlag = false;

                // BL�R�[�h�}�ԑΉ��i��BL�R�[�h�������̂݁j
                if (inPara != null && inPara.TbsPartsCode != 0 && inPara.TbsPartsCdDerivedNo != 0)
                {
                    // ���������Ŏw�肳�ꂽ�}�ԂƈقȂ�ꍇ�͉I��
                    if (inPara.TbsPartsCdDerivedNo != wkPartsInf.TbsPartsCdDerivedNo)
                    {
                        // --- UPD 2015/04/03 T.Miyamoto SCM�d�|�ꗗ��10715 ------------------------------>>>>>
                        //continue;
                        // �Y�����i�̐V�i�ԂƂ��Đݒ肳��Ă��Ȃ���Έȍ~�̏������s��Ȃ�
                        NewKey _chkKey = new NewKey(wkPartsInf.CatalogPartsMakerCd, wkPartsInf.ClgPrtsNoWithHyphen.Trim());
                        if (!newPartsInfoDic.ContainsKey(_chkKey))
                        {
                            continue;
                        }
                        // --- UPD 2015/04/03 T.Miyamoto SCM�d�|�ꗗ��10715 ------------------------------<<<<<
                    }

                    // ���o������BL�R�[�h�}�Ԃ��ݒ肳��Ă���ꍇ�́A�}�ԗp���i���̂�t�^����B
                    if (!string.IsNullOrEmpty(wkPartsInf.PartsName)) wkPartsInf.PartsName = wkPartsInf.PartsName + wkPartsInf.TbsPartsCdDerivedNm;
                    if (!string.IsNullOrEmpty(wkPartsInf.PartsNameKana)) wkPartsInf.PartsNameKana = wkPartsInf.PartsNameKana + wkPartsInf.TbsPartsCdDerivedNm;
                    if (!string.IsNullOrEmpty(wkPartsInf.MakerOfferPartsName)) wkPartsInf.MakerOfferPartsName = wkPartsInf.MakerOfferPartsName + wkPartsInf.TbsPartsCdDerivedNm;
                    if (!string.IsNullOrEmpty(wkPartsInf.MakerOfferPartsKana)) wkPartsInf.MakerOfferPartsKana = wkPartsInf.MakerOfferPartsKana + wkPartsInf.TbsPartsCdDerivedNm;
                    derivedNmSetFlag = true;
                }

                #region ���i���ݒ�
                PartsInfoDataSet.PartsInfoRow partsInfoRow = partsInfoDic[key].PartsInfo.NewPartsInfoRow();

                partsInfoRow.OfferDate = wkPartsInf.OfferDate;
                partsInfoRow.PartsSearchCode = wkPartsInf.PartsSearchCode;
                partsInfoRow.PartsNarrowingCode = wkPartsInf.PartsNarrowingCode;
                partsInfoRow.PartsName = wkPartsInf.PartsName;
                partsInfoRow.PartsNameKana = wkPartsInf.PartsNameKana;
                partsInfoRow.PartsCode = wkPartsInf.PartsCode;
                partsInfoRow.WorkOrPartsDivNm = wkPartsInf.WorkOrPartsDivNm;
                partsInfoRow.FullModelFixedNo = wkPartsInf.FullModelFixedNo;
                partsInfoRow.TbsPartsCode = wkPartsInf.TbsPartsCode;
                partsInfoRow.TbsPartsCdDerivedNo = wkPartsInf.TbsPartsCdDerivedNo;
                partsInfoRow.FigshapeNo = wkPartsInf.FigShapeNo;
                partsInfoRow.ModelPrtsAdptYm = wkPartsInf.ModelPrtsAdptYm;
                partsInfoRow.ModelPrtsAblsYm = wkPartsInf.ModelPrtsAblsYm;
                partsInfoRow.ModelPrtsAdptFrameNo = wkPartsInf.ModelPrtsAdptFrameNo;
                partsInfoRow.ModelPrtsAblsFrameNo = wkPartsInf.ModelPrtsAblsFrameNo;
                partsInfoRow.PartsQty = wkPartsInf.PartsQty;
                partsInfoRow.PartsOpNm = wkPartsInf.PartsOpNm;
                partsInfoRow.StandardName = wkPartsInf.StandardName;
                partsInfoRow.CatalogPartsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                partsInfoRow.CatalogPartsMakerNm = GetPartsMakerName(wkPartsInf.CatalogPartsMakerCd);

                partsInfoRow.ClgPrtsNoWithHyphen = wkPartsInf.ClgPrtsNoWithHyphen.Trim();
                if (partsInfoRow.ClgPrtsNoWithHyphen == string.Empty)                   // �{���͂����Ă͂����Ȃ��P�[�X�����A�f�[�^�̐������̖���
                    partsInfoRow.ClgPrtsNoWithHyphen = wkPartsInf.NewPrtsNoWithHyphen;  // ��Q��h���ړI�ł��̏�����ǉ�
                partsInfoRow.ColdDistrictsFlag = wkPartsInf.ColdDistrictsFlag;
                partsInfoRow.ColorNarrowingFlag = wkPartsInf.ColorNarrowingFlag;
                partsInfoRow.TrimNarrowingFlag = wkPartsInf.TrimNarrowingFlag;
                partsInfoRow.EquipNarrowingFlag = wkPartsInf.EquipNarrowingFlag;
                partsInfoRow.MakerOfferPartsName = wkPartsInf.MakerOfferPartsName;
                partsInfoRow.PartsLayerCd = wkPartsInf.PartsLayerCd;
                partsInfoRow.PartsUniqueNo = wkPartsInf.PartsUniqueNo;

                partsInfoRow.NewPrtsNoWithHyphen = wkPartsInf.NewPrtsNoWithHyphen;
                partsInfoRow.NewPrtsNoNoneHyphen = wkPartsInf.NewPrtsNoNoneHyphen;
                partsInfoRow.SeriesModel = wkPartsInf.SeriesModel;
                partsInfoRow.CategorySignModel = wkPartsInf.CategorySignModel;
                partsInfoRow.ExhaustGasSign = wkPartsInf.ExhaustGasSign;

                // �������ϕ��i�R�[�h
                partsInfoRow.AutoEstimatePartsCd = wkPartsInf.AutoEstimatePartsCd;
                // BL�R�[�h�}�ԗp���i����
                if (derivedNmSetFlag)
                {
                    partsInfoRow.TbsPartsCdDerivedNm = wkPartsInf.TbsPartsCdDerivedNm;
                }

                partsInfoRow.PrimeJoinLnkFlg = wkPartsInf.PrimeJoinLnkFlg;

                // VIN���YNo.(�n��)��VIN���YNo.(�I��)���i�[����
                partsInfoRow.VinProduceStartNo = wkPartsInf.VinProduceStartNo.ToString("000000");
                partsInfoRow.VinProduceEndNo = wkPartsInf.VinProduceEndNo.ToString("000000");

                partsInfoDic[key].PartsInfo.AddPartsInfoRow(partsInfoRow);
                #endregion

                #region ���i�}�X�^�e�[�u���ɐݒ�
                string partsNo = wkPartsInf.ClgPrtsNoWithHyphen;
                PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                    goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkPartsInf.CatalogPartsMakerCd, partsNo);
                if (usrGoodsRow == null)
                {
                    usrGoodsRow = goodsTableDic[key].NewUsrGoodsInfoRow();
                    usrGoodsRow.BlGoodsCode = wkPartsInf.TbsPartsCode;
                    usrGoodsRow.GoodsKindCode = 0; // 0 : ����
                    usrGoodsRow.GoodsKind = (int)GoodsKind.Parent; // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                    usrGoodsRow.GoodsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                    usrGoodsRow.GoodsMakerNm = partsInfoRow.CatalogPartsMakerNm;
                    //usrGoodsRow.GoodsMGroup = 0;
                    usrGoodsRow.GoodsRateRank = wkPartsInf.PartsLayerCd;
                    usrGoodsRow.GoodsNoNoneHyphen = partsInfoRow.ClgPrtsNoWithHyphen.Replace("-", "");
                    usrGoodsRow.QTY = wkPartsInf.PartsQty;
                    usrGoodsRow.GoodsNote1 = wkPartsInf.StandardName; //�K�i
                    //usrGoodsRow.GoodsNote2 = "";
                    usrGoodsRow.GoodsSpecialNote = wkPartsInf.PartsOpNm;
                    usrGoodsRow.GoodsSpecialNoteOffer = wkPartsInf.PartsOpNm;   // ���i�K�i�E���L�����i�񋟁j
                    usrGoodsRow.OfferDate = wkPartsInf.OfferDate;
                    usrGoodsRow.OfferKubun = 3; // �񋟏��� (0:���[�U�[�o�^�^1:�񋟏����ҏW�^2:�񋟗D�ǕҏW�^3:�񋟏����^4:�񋟗D�ǁj
                    //usrGoodsRow.TaxationDivCd = 0;
                    usrGoodsRow.GoodsNo = partsInfoRow.ClgPrtsNoWithHyphen;
                    usrGoodsRow.OfferDataDiv = 1;

                    if (wkPartsInf.MakerOfferPartsName != string.Empty)
                    {
                        usrGoodsRow.GoodsName = wkPartsInf.MakerOfferPartsName; // ���i���F�f�t�H���g�͕��i��
                        usrGoodsRow.GoodsNameKana = wkPartsInf.MakerOfferPartsKana;
                    }
                    else // �Â����i�͖��̂����Ȃ��̂�
                    {
                        usrGoodsRow.GoodsName = wkPartsInf.PartsName; // �����i��
                        usrGoodsRow.GoodsNameKana = wkPartsInf.PartsNameKana;
                    }
                    usrGoodsRow.GoodsOfrName = wkPartsInf.MakerOfferPartsName; // ���i��
                    usrGoodsRow.GoodsOfrNameKana = wkPartsInf.MakerOfferPartsKana;
                    usrGoodsRow.SearchPartsFullName = wkPartsInf.PartsName; // �����i��
                    usrGoodsRow.SearchPartsHalfName = wkPartsInf.PartsNameKana;
                    usrGoodsRow.SrchPNmAcqrCarMkrCd = wkPartsInf.SrchPNmAcqrCarMkrCd;   // �����i���擾���[�J�[�R�[�h    
                    usrGoodsRow.PartsPriceStDate = wkPartsInf.PartsPriceStDate;

                    if (wkPartsInf.TbsPartsCdDerivedNo != 0)
                    {
                        string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkPartsInf.TbsPartsCode,
                                                                           ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkPartsInf.TbsPartsCdDerivedNo);
                        BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                        if ((rows != null) && (rows.Length != 0))
                        {
                            usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                            usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                            usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // ���i��
                            usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                            usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // �����i��
                            usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                        }
                    }

                    partsInfoRow.UsrGoodsInfoRowParentByUsrGoodsInfo_PartsInfo = usrGoodsRow;
                    goodsTableDic[key].AddUsrGoodsInfoRow(usrGoodsRow);
                }

                // BL�R�[�h�A�i���A�w�ʂ͏�ɍŐV�̃f�[�^���g�p����
                if (usrGoodsRow.PartsPriceStDate < wkPartsInf.PartsPriceStDate)
                {
                    // �i���̍X�V
                    if (!string.IsNullOrEmpty(wkPartsInf.MakerOfferPartsName))
                    {
                        usrGoodsRow.GoodsName = wkPartsInf.MakerOfferPartsName;     // ���i��
                        usrGoodsRow.GoodsNameKana = wkPartsInf.MakerOfferPartsKana;

                        usrGoodsRow.GoodsOfrName = wkPartsInf.MakerOfferPartsName;  // ���i��
                        usrGoodsRow.GoodsOfrNameKana = wkPartsInf.MakerOfferPartsKana;
                    }

                    // BL�R�[�h�̍X�V
                    if (wkPartsInf.TbsPartsCode != 0)
                    {
                        usrGoodsRow.BlGoodsCode = wkPartsInf.TbsPartsCode;
                    }

                    usrGoodsRow.GoodsRateRank = wkPartsInf.PartsLayerCd;            // �w��

                    usrGoodsRow.PartsPriceStDate = wkPartsInf.PartsPriceStDate;     // �񋟂̉��i�擾�����X�V
                }

                #region USR Price
                if (wkPartsInf.PriceOfferDate != DateTime.MinValue &&
                    priceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkPartsInf.CatalogPartsMakerCd,
                    wkPartsInf.PartsPriceStDate, wkPartsInf.ClgPrtsNoWithHyphen) == null)
                {
                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTableDic[key].NewUsrGoodsPriceRow();
                    usrPriceRow.GoodsNo = wkPartsInf.ClgPrtsNoWithHyphen;
                    usrPriceRow.GoodsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                    double listPrice = wkPartsInf.PartsPrice;
                    this.ReflectIsolIslandCall(0, wkPartsInf.CatalogPartsMakerCd, 3, ref listPrice);
                    usrPriceRow.ListPrice = listPrice;
                    usrPriceRow.OfferDate = wkPartsInf.PriceOfferDate;
                    usrPriceRow.OpenPriceDiv = wkPartsInf.OpenPriceDiv;
                    usrPriceRow.PriceStartDate = wkPartsInf.PartsPriceStDate;
                    //usrPriceRow.SalesUnitCost = 0;
                    //usrPriceRow.StockRate = 0;
                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                    priceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                }
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                if (wkPartsInf.PriceOfferDate != DateTime.MinValue &&
                    ofrPriceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkPartsInf.CatalogPartsMakerCd,
                    wkPartsInf.PartsPriceStDate, wkPartsInf.ClgPrtsNoWithHyphen) == null)
                {
                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTableDic[key].NewUsrGoodsPriceRow();
                    usrPriceRow.GoodsNo = wkPartsInf.ClgPrtsNoWithHyphen;
                    usrPriceRow.GoodsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                    double listPrice = wkPartsInf.PartsPrice;
                    this.ReflectIsolIslandCall(0, wkPartsInf.CatalogPartsMakerCd, 3, ref listPrice);
                    usrPriceRow.ListPrice = listPrice;
                    usrPriceRow.OfferDate = wkPartsInf.PriceOfferDate;
                    usrPriceRow.OpenPriceDiv = wkPartsInf.OpenPriceDiv;
                    usrPriceRow.PriceStartDate = wkPartsInf.PartsPriceStDate;
                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                    ofrPriceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                }
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
                #endregion
                #endregion

                #region ���i�֘A�^�����ݒ�
                if (carInfoDataSet != null && partsModelLnkWork != null)
                {
                    PartsInfoDataSet.ModelPartsDetailDataTable modelInfo = partsInfoDic[key].ModelPartsDetail;
                    foreach (PartsModelLnkWork wkModelInf in partsModelLnkWork)
                    {
                        if (wkModelInf.PartsProperNo != wkPartsInf.PartsUniqueNo)
                            continue;

                        string select = "FullModelFixedNo in (";
                        for (int i = 0; i < wkModelInf.FullModelFixedNos.Count; i++)
                        {
                            select += wkModelInf.FullModelFixedNos[i].ToString() + ", ";
                        }
                        select.Remove(select.Length - 2);
                        select += ")";

                        PMKEN01010E.CarModelInfoRow[] carModelInfoRows = (PMKEN01010E.CarModelInfoRow[])carInfoDataSet.CarModelInfo.Select(select);

                        //���q��񁨕��i�ڍׁi�^�����j�ݒ�
                        for (int ix = 0; ix < carModelInfoRows.Length; ix++)
                        {
                            string filter = string.Format("{0} = {1} AND {2} = {3}",
                                modelInfo.PartsUniqueNoColumn.ColumnName, wkModelInf.PartsProperNo,
                                modelInfo.FullModelFixedNoColumn.ColumnName, carModelInfoRows[ix].FullModelFixedNo);
                            PartsInfoDataSet.ModelPartsDetailRow[] row = (PartsInfoDataSet.ModelPartsDetailRow[])modelInfo.Select(filter);
                            if (row.Length > 0)
                                continue;
                            PartsInfoDataSet.ModelPartsDetailRow modelPartsDetailRow = modelInfo.NewModelPartsDetailRow();

                            modelPartsDetailRow.PartsUniqueNo = wkModelInf.PartsProperNo;
                            modelPartsDetailRow.PartsMakerCd = wkPartsInf.CatalogPartsMakerCd;
                            modelPartsDetailRow.PartsNo = wkPartsInf.ClgPrtsNoWithHyphen;

                            modelPartsDetailRow.FullModelFixedNo = carModelInfoRows[ix].FullModelFixedNo;
                            modelPartsDetailRow.DoorCount = carModelInfoRows[ix].DoorCount;
                            modelPartsDetailRow.BodyName = carModelInfoRows[ix].BodyName;
                            modelPartsDetailRow.ModelGradeNm = carModelInfoRows[ix].ModelGradeNm;
                            modelPartsDetailRow.EngineModelNm = carModelInfoRows[ix].EngineModelNm;
                            modelPartsDetailRow.EngineDisplaceNm = carModelInfoRows[ix].EngineDisplaceNm;
                            modelPartsDetailRow.EDivNm = carModelInfoRows[ix].EDivNm;
                            modelPartsDetailRow.TransmissionNm = carModelInfoRows[ix].TransmissionNm;
                            modelPartsDetailRow.ShiftNm = carModelInfoRows[ix].ShiftNm;
                            modelPartsDetailRow.WheelDriveMethodNm = carModelInfoRows[ix].WheelDriveMethodNm;
                            modelPartsDetailRow.AddiCarSpec1 = carModelInfoRows[ix].AddiCarSpec1;
                            modelPartsDetailRow.AddiCarSpec2 = carModelInfoRows[ix].AddiCarSpec2;
                            modelPartsDetailRow.AddiCarSpec3 = carModelInfoRows[ix].AddiCarSpec3;
                            modelPartsDetailRow.AddiCarSpec4 = carModelInfoRows[ix].AddiCarSpec4;
                            modelPartsDetailRow.AddiCarSpec5 = carModelInfoRows[ix].AddiCarSpec5;
                            modelPartsDetailRow.AddiCarSpec6 = carModelInfoRows[ix].AddiCarSpec6;
                            //modelPartsDetailRow.AddiCarSpecTitle1 = carModelInfoRows[ix].AddiCarSpecTitle1;
                            //modelPartsDetailRow.AddiCarSpecTitle2 = carModelInfoRows[ix].AddiCarSpecTitle2;
                            //modelPartsDetailRow.AddiCarSpecTitle3 = carModelInfoRows[ix].AddiCarSpecTitle3;
                            //modelPartsDetailRow.AddiCarSpecTitle4 = carModelInfoRows[ix].AddiCarSpecTitle4;
                            //modelPartsDetailRow.AddiCarSpecTitle5 = carModelInfoRows[ix].AddiCarSpecTitle5;
                            //modelPartsDetailRow.AddiCarSpecTitle6 = carModelInfoRows[ix].AddiCarSpecTitle6;

                            modelInfo.AddModelPartsDetailRow(modelPartsDetailRow);
                        }
                        if (carModelInfoRows.Length > 0)
                        {
                            modelInfo.Columns[modelInfo.AddiCarSpec1Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle1;
                            modelInfo.Columns[modelInfo.AddiCarSpec2Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle2;
                            modelInfo.Columns[modelInfo.AddiCarSpec3Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle3;
                            modelInfo.Columns[modelInfo.AddiCarSpec4Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle4;
                            modelInfo.Columns[modelInfo.AddiCarSpec5Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle5;
                            modelInfo.Columns[modelInfo.AddiCarSpec6Column.ColumnName].Caption = carModelInfoRows[0].AddiCarSpecTitle6;
                        }
                    }
                }
                #endregion
            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<
        # endregion

        # region �J���[���ݒ�
        /// <summary>
        /// �J���[���ݒ�
        /// </summary>
        /// <param name="list"></param>
        private void FillOfrColorTable(ArrayList list)
        {
            if (list == null)
            {
                return;
            }
            foreach (PartsColorWork wkInf in list)
            {
                PartsInfoDataSet.OfrColorInfoRow row = partsInfo.OfrColorInfo.NewOfrColorInfoRow();
                row.PartsProperNo = wkInf.PartsProperNo;
                row.ColorCdInfoNo = wkInf.ColorCdInfoNo;

                string filter = string.Format("{0} = '{1}'", carInfoDataSet.ColorCdInfo.ColorCodeColumn.ColumnName, wkInf.ColorCdInfoNo);
                PMKEN01010E.ColorCdInfoRow[] carColorInfoRows = (PMKEN01010E.ColorCdInfoRow[])carInfoDataSet.ColorCdInfo.Select(filter);
                if (carColorInfoRows.Length > 0)
                {
                    row.ColorName = carColorInfoRows[0].ColorName1;
                }

                partsInfo.OfrColorInfo.AddOfrColorInfoRow(row);
            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        ///  �J���[���ݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        private void FillOfrColorTable(ArrayList list, int key)
        {
            if (list == null)
            {
                return;
            }
            foreach (PartsColorWork wkInf in list)
            {
                PartsInfoDataSet.OfrColorInfoRow row = partsInfoDic[key].OfrColorInfo.NewOfrColorInfoRow();
                row.PartsProperNo = wkInf.PartsProperNo;
                row.ColorCdInfoNo = wkInf.ColorCdInfoNo;

                string filter = string.Format("{0} = '{1}'", carInfoDataSet.ColorCdInfo.ColorCodeColumn.ColumnName, wkInf.ColorCdInfoNo);
                PMKEN01010E.ColorCdInfoRow[] carColorInfoRows = (PMKEN01010E.ColorCdInfoRow[])carInfoDataSet.ColorCdInfo.Select(filter);
                if (carColorInfoRows.Length > 0)
                {
                    row.ColorName = carColorInfoRows[0].ColorName1;
                }

                partsInfoDic[key].OfrColorInfo.AddOfrColorInfoRow(row);
            }
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        # region �g�������ݒ�
        /// <summary>
        /// �g�������ݒ�
        /// </summary>
        /// <param name="list"></param>
        private void FillOfrTrimTable(ArrayList list)
        {
            if (list == null)
            {
                return;
            }
            foreach (PartsTrimWork wkInf in list)
            {
                PartsInfoDataSet.OfrTrimInfoRow row = partsInfo.OfrTrimInfo.NewOfrTrimInfoRow();
                row.PartsProperNo = wkInf.PartsProperNo;
                row.TrimCode = wkInf.TrimCode;

                string filter = string.Format("{0} = '{1}'", carInfoDataSet.TrimCdInfo.TrimCodeColumn.ColumnName, wkInf.TrimCode);
                PMKEN01010E.TrimCdInfoRow[] carTrimInfoRows = (PMKEN01010E.TrimCdInfoRow[])carInfoDataSet.TrimCdInfo.Select(filter);
                if (carTrimInfoRows.Length > 0)
                {
                    row.TrimName = carTrimInfoRows[0].TrimName;
                }

                partsInfo.OfrTrimInfo.AddOfrTrimInfoRow(row);
            }
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        ///  �g�������ݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        private void FillOfrTrimTable(ArrayList list, int key)
        {
            if (list == null)
            {
                return;
            }
            foreach (PartsTrimWork wkInf in list)
            {
                PartsInfoDataSet.OfrTrimInfoRow row = partsInfoDic[key].OfrTrimInfo.NewOfrTrimInfoRow();
                row.PartsProperNo = wkInf.PartsProperNo;
                row.TrimCode = wkInf.TrimCode;

                string filter = string.Format("{0} = '{1}'", carInfoDataSet.TrimCdInfo.TrimCodeColumn.ColumnName, wkInf.TrimCode);
                PMKEN01010E.TrimCdInfoRow[] carTrimInfoRows = (PMKEN01010E.TrimCdInfoRow[])carInfoDataSet.TrimCdInfo.Select(filter);
                if (carTrimInfoRows.Length > 0)
                {
                    row.TrimName = carTrimInfoRows[0].TrimName;
                }

                partsInfoDic[key].OfrTrimInfo.AddOfrTrimInfoRow(row);
            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        # region �������ݒ�
        /// <summary>
        /// �������ݒ�
        /// </summary>
        /// <param name="list"></param>
        private void FillOfrEquipTable(ArrayList list)
        {
            if (list == null)
            {
                return;
            }
            foreach (PartsEquipWork wkInf in list)
            {
                PartsInfoDataSet.OfrEquipInfoRow row = partsInfo.OfrEquipInfo.NewOfrEquipInfoRow();
                row.PartsProperNo = wkInf.PartsProperNo;
                row.EquipmentGenreCd = wkInf.EquipmentGenreCd;
                row.EquipmentCode = wkInf.EquipmentCode;

                string filter = string.Format("{0} = {1} AND {2} = {3}",
                    carInfoDataSet.CEqpDefDspInfo.EquipmentGenreCdColumn.ColumnName,
                    wkInf.EquipmentGenreCd,
                    carInfoDataSet.CEqpDefDspInfo.EquipmentCodeColumn.ColumnName,
                    wkInf.EquipmentCode);
                PMKEN01010E.CEqpDefDspInfoRow[] carEqpInfoRows = (PMKEN01010E.CEqpDefDspInfoRow[])carInfoDataSet.CEqpDefDspInfo.Select(filter);
                if (carEqpInfoRows.Length > 0)
                {
                    row.EquipmentDispOrder = carEqpInfoRows[0].EquipmentDispOrder;
                    row.EquipmentGenreNm = carEqpInfoRows[0].EquipmentGenreNm;
                    row.EquipmentName = carEqpInfoRows[0].EquipmentName;
                    row.EquipmentIconCode = carEqpInfoRows[0].EquipmentIconCode;
                    row.EquipmentShortName = carEqpInfoRows[0].EquipmentShortName;
                }

                partsInfo.OfrEquipInfo.AddOfrEquipInfoRow(row);
            }
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// �������ݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        private void FillOfrEquipTable(ArrayList list, int key)
        {
            if (list == null)
            {
                return;
            }
            foreach (PartsEquipWork wkInf in list)
            {
                PartsInfoDataSet.OfrEquipInfoRow row = partsInfoDic[key].OfrEquipInfo.NewOfrEquipInfoRow();
                row.PartsProperNo = wkInf.PartsProperNo;
                row.EquipmentGenreCd = wkInf.EquipmentGenreCd;
                row.EquipmentCode = wkInf.EquipmentCode;

                string filter = string.Format("{0} = {1} AND {2} = {3}",
                    carInfoDataSet.CEqpDefDspInfo.EquipmentGenreCdColumn.ColumnName,
                    wkInf.EquipmentGenreCd,
                    carInfoDataSet.CEqpDefDspInfo.EquipmentCodeColumn.ColumnName,
                    wkInf.EquipmentCode);
                PMKEN01010E.CEqpDefDspInfoRow[] carEqpInfoRows = (PMKEN01010E.CEqpDefDspInfoRow[])carInfoDataSet.CEqpDefDspInfo.Select(filter);
                if (carEqpInfoRows.Length > 0)
                {
                    row.EquipmentDispOrder = carEqpInfoRows[0].EquipmentDispOrder;
                    row.EquipmentGenreNm = carEqpInfoRows[0].EquipmentGenreNm;
                    row.EquipmentName = carEqpInfoRows[0].EquipmentName;
                    row.EquipmentIconCode = carEqpInfoRows[0].EquipmentIconCode;
                    row.EquipmentShortName = carEqpInfoRows[0].EquipmentShortName;
                }

                partsInfoDic[key].OfrEquipInfo.AddOfrEquipInfoRow(row);
            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        # region ��֏��ݒ�
        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
        ///// <summary>
        ///// ��֏��ݒ�
        ///// </summary>
        ///// <param name="list"></param>
        ///// <param name="partsName"></param>
        ///// <param name="partsNameKana"></param>
        //private void FillOfrSubstTable(ArrayList list, string partsName, string partsNameKana)
        /// <summary>
        /// ��֏��ݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <param name="partsName"></param>
        /// <param name="partsNameKana"></param>
        /// <param name="inPara"></param>
        private void FillOfrSubstTable( ArrayList list, string partsName, string partsNameKana, GetPartsInfPara inPara )
        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
        {
            foreach (PartsSubstWork wkInf in list)
            {
                string partsMakerNm = string.Empty;
                //��֏��
                if (wkInf.MainOrSubPartsDivCd == 0)
                {
                    if (partsInfo.SubstPartsInfo.FindByNewPartsNoWithHyphenCatalogPartsMakerCdOldPartsNoWithHyphen(
                        wkInf.NewPartsNoWithHyphen, wkInf.CatalogPartsMakerCd, wkInf.OldPartsNoWithHyphen) == null)
                    {
                        PartsInfoDataSet.SubstPartsInfoRow row = partsInfo.SubstPartsInfo.NewSubstPartsInfoRow();

                        row.CatalogPartsMakerCd = wkInf.CatalogPartsMakerCd;
                        row.CatalogPartsMakerNm = GetPartsMakerName(wkInf.CatalogPartsMakerCd);
                        partsMakerNm = row.CatalogPartsMakerNm;

                        row.OldPartsNoWithHyphen = wkInf.OldPartsNoWithHyphen;
                        row.NewPartsNoWithHyphen = wkInf.NewPartsNoWithHyphen;
                        row.NPrtNoWithHypnDspOdr = wkInf.NPrtNoWithHypnDspOdr;
                        row.PartsPluralSubstFlg = wkInf.PartsPluralSubstFlg;
                        row.MainOrSubPartsDivCd = wkInf.MainOrSubPartsDivCd;
                        row.PartsQty = wkInf.PartsQty;
                        row.PartsPluralSubstCmnt = wkInf.PartsPluralSubstCmnt;
                        row.PlrlSubNewPrtNoHypn = wkInf.PlrlSubNewPrtNoHypn;
                        row.NewPrtsNoNoneHyphen = wkInf.NewPrtsNoNoneHyphen;
                        row.TbsPartsCode = wkInf.TbsPartsCode;
                        row.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                        row.MakerOfferPartsName = wkInf.MakerOfferPartsName;
                        row.PartsLayerCd = wkInf.PartsLayerCd;
                        row.PartsInfoCtrlFlg = wkInf.PartsInfoCtrlFlg;
                        row.PartsName = partsName;
                        row.PartsNameKana = partsNameKana;
                        row.PartsCode = wkInf.PartsCode;
                        row.PartsSearchCode = wkInf.PartsSearchCode;

                        partsInfo.SubstPartsInfo.AddSubstPartsInfoRow(row);
                    }
                }
                //������֏��
                else
                {
                    if (partsInfo.DSubstPartsInfo.FindByCatalogPartsMakerCdOldPartsNoWithHyphenNewPartsNoWithHyphenPlrlSubNewPrtNoHypn(
                        wkInf.CatalogPartsMakerCd, wkInf.OldPartsNoWithHyphen, wkInf.NewPartsNoWithHyphen, wkInf.PlrlSubNewPrtNoHypn) == null)
                    {
                        PartsInfoDataSet.DSubstPartsInfoRow row = partsInfo.DSubstPartsInfo.NewDSubstPartsInfoRow();

                        row.CatalogPartsMakerCd = wkInf.CatalogPartsMakerCd;
                        row.CatalogPartsMakerNm = GetPartsMakerName(wkInf.CatalogPartsMakerCd);
                        partsMakerNm = row.CatalogPartsMakerNm;

                        row.OldPartsNoWithHyphen = wkInf.OldPartsNoWithHyphen;
                        row.NewPartsNoWithHyphen = wkInf.NewPartsNoWithHyphen;
                        row.NPrtNoWithHypnDspOdr = wkInf.NPrtNoWithHypnDspOdr;
                        row.PartsPluralSubstFlg = wkInf.PartsPluralSubstFlg;
                        row.MainOrSubPartsDivCd = wkInf.MainOrSubPartsDivCd;
                        row.PartsQty = wkInf.PartsQty;
                        row.PartsPluralSubstCmnt = wkInf.PartsPluralSubstCmnt;
                        row.PlrlSubNewPrtNoHypn = wkInf.PlrlSubNewPrtNoHypn;
                        row.NewPrtsNoNoneHyphen = wkInf.NewPrtsNoNoneHyphen;
                        row.TbsPartsCode = wkInf.TbsPartsCode;
                        row.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                        row.MakerOfferPartsName = wkInf.MakerOfferPartsName;
                        row.PartsLayerCd = wkInf.PartsLayerCd;
                        row.PartsInfoCtrlFlg = wkInf.PartsInfoCtrlFlg;
                        row.PartsName = wkInf.MakerOfferPartsName; //partsName;
                        row.PartsNameKana = wkInf.MakerOfferPartsKana; //partsNameKana;
                        row.PartsCode = wkInf.PartsCode;
                        row.PartsSearchCode = wkInf.PartsSearchCode;

                        partsInfo.DSubstPartsInfo.AddDSubstPartsInfoRow(row);
                    }
                }

                PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                        goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.CatalogPartsMakerCd, wkInf.NewPartsNoWithHyphen);
                if (usrGoodsRow == null)
                {
                    usrGoodsRow = goodsTable.NewUsrGoodsInfoRow();
                    usrGoodsRow.BlGoodsCode = wkInf.TbsPartsCode;
                    usrGoodsRow.GoodsKindCode = 0; // 0 : ����
                    usrGoodsRow.GoodsMakerCd = wkInf.CatalogPartsMakerCd;
                    usrGoodsRow.GoodsMakerNm = partsMakerNm;
                    //usrGoodsRow.GoodsMGroup = 0;
                    usrGoodsRow.GoodsRateRank = wkInf.PartsLayerCd;
                    usrGoodsRow.GoodsNo = wkInf.NewPartsNoWithHyphen;
                    usrGoodsRow.GoodsNoNoneHyphen = wkInf.NewPrtsNoNoneHyphen;
                    //usrGoodsRow.GoodsNote1 = "";
                    //usrGoodsRow.GoodsNote2 = "";
                    usrGoodsRow.GoodsSpecialNote = wkInf.PartsPluralSubstCmnt;
                    usrGoodsRow.QTY = wkInf.PartsQty;
                    usrGoodsRow.OfferDate = wkInf.OfferDate;
                    usrGoodsRow.OfferKubun = 3; // �񋟏��� (0:���[�U�[�o�^�^1:�񋟏����ҏW�^2:�񋟗D�ǕҏW�^3:�񋟏����^4:�񋟗D�ǁj
                    //usrGoodsRow.TaxationDivCd = 0;
                    usrGoodsRow.OfferDataDiv = 1;
                    if (wkInf.MakerOfferPartsName != string.Empty)
                    {
                        usrGoodsRow.GoodsName = wkInf.MakerOfferPartsName; // ���i���F�f�t�H���g�͕��i��
                        usrGoodsRow.GoodsNameKana = wkInf.MakerOfferPartsKana;
                    }
                    else
                    {
                        usrGoodsRow.GoodsName = partsName; // �����i���i�Â���֕i�̏ꍇ�i�������Ȃ��ꍇ������̂Łj
                        usrGoodsRow.GoodsNameKana = partsNameKana; // �i��։�ʂŕi���\���̂��߂��̏��������Ă����j
                    }
                    usrGoodsRow.GoodsOfrName = wkInf.MakerOfferPartsName; // ���i��
                    usrGoodsRow.GoodsOfrNameKana = wkInf.MakerOfferPartsKana;
                    // 2009/10/27 >>>
                    //usrGoodsRow.SearchPartsFullName = partsName; // �����i��
                    //usrGoodsRow.SearchPartsHalfName = partsNameKana;

                    // �����݊��̃T�u���i�͌����i�����Z�b�g���Ȃ�
                    if (wkInf.MainOrSubPartsDivCd == 0)
                    {
                        usrGoodsRow.SearchPartsFullName = partsName; // �����i��
                        usrGoodsRow.SearchPartsHalfName = partsNameKana;
                    }
                    // 2009/10/27 <<<
                    
                    // 2010/02/25 Add >>>
                    if (wkInf.TbsPartsCdDerivedNo != 0)
                    {
                        string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                           ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                        BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                        if ((rows != null) && (rows.Length != 0))
                        {
                            usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                            usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                            usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // ���i��
                            usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                            usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // �����i��
                            usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                        }
                    }
                    // 2010/02/25 Add <<<

                    goodsTable.AddUsrGoodsInfoRow(usrGoodsRow);

                    // 2009/11/09 Del >>>
                    //if (priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.CatalogPartsMakerCd, wkInf.PartsPriceStDate, wkInf.NewPartsNoWithHyphen)
                    //    == null)
                    //{
                    //    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTable.NewUsrGoodsPriceRow();
                    //    usrPriceRow.GoodsNo = wkInf.NewPartsNoWithHyphen;
                    //    usrPriceRow.GoodsMakerCd = wkInf.CatalogPartsMakerCd;
                    //    // 2009.03.04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    //    usrPriceRow.ListPrice = wkInf.PartsPrice;
                    //    double listPrice = wkInf.PartsPrice;
                    //    this.ReflectIsolIslandCall(0, wkInf.CatalogPartsMakerCd, 3, ref listPrice);
                    //    usrPriceRow.ListPrice = listPrice;
                    //    // 2009.03.04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    //    usrPriceRow.OfferDate = wkInf.PriceOfferDate;
                    //    usrPriceRow.OpenPriceDiv = wkInf.OpenPriceDiv;
                    //    usrPriceRow.PriceStartDate = wkInf.PartsPriceStDate;
                    //    //usrPriceRow.SalesUnitCost = 0;
                    //    //usrPriceRow.StockRate = 0;
                    //    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                    //    priceTable.AddUsrGoodsPriceRow(usrPriceRow);
                    //}
                    // 2009/11/09 Del <<<
                }
                // 2009/11/09 Add >>>
                // ���ɓo�^���ꂽ���i�Ɋւ��Ă����i���̍X�V���s���B
                if (priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.CatalogPartsMakerCd, wkInf.PartsPriceStDate, wkInf.NewPartsNoWithHyphen) == null)
                {
                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTable.NewUsrGoodsPriceRow();
                    usrPriceRow.GoodsNo = wkInf.NewPartsNoWithHyphen;
                    usrPriceRow.GoodsMakerCd = wkInf.CatalogPartsMakerCd;
                    usrPriceRow.ListPrice = wkInf.PartsPrice;
                    double listPrice = wkInf.PartsPrice;
                    this.ReflectIsolIslandCall(0, wkInf.CatalogPartsMakerCd, 3, ref listPrice);
                    usrPriceRow.ListPrice = listPrice;
                    usrPriceRow.OfferDate = wkInf.PriceOfferDate;
                    usrPriceRow.OpenPriceDiv = wkInf.OpenPriceDiv;
                    usrPriceRow.PriceStartDate = wkInf.PartsPriceStDate;
                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                    priceTable.AddUsrGoodsPriceRow(usrPriceRow);
                }
                // 2009/11/09 Add <<<
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                // ���ɓo�^���ꂽ���i�Ɋւ��Ă��񋟃f�[�^�p���i���̍X�V���s���B
                if (ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.CatalogPartsMakerCd, wkInf.PartsPriceStDate, wkInf.NewPartsNoWithHyphen) == null)
                {
                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTable.NewUsrGoodsPriceRow();
                    usrPriceRow.GoodsNo = wkInf.NewPartsNoWithHyphen;
                    usrPriceRow.GoodsMakerCd = wkInf.CatalogPartsMakerCd;
                    usrPriceRow.ListPrice = wkInf.PartsPrice;
                    double listPrice = wkInf.PartsPrice;
                    this.ReflectIsolIslandCall(0, wkInf.CatalogPartsMakerCd, 3, ref listPrice);
                    usrPriceRow.ListPrice = listPrice;
                    usrPriceRow.OfferDate = wkInf.PriceOfferDate;
                    usrPriceRow.OpenPriceDiv = wkInf.OpenPriceDiv;
                    usrPriceRow.PriceStartDate = wkInf.PartsPriceStDate;
                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                    ofrPriceTable.AddUsrGoodsPriceRow(usrPriceRow);
                }
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<

                //���ɓo�^���ꂽ���i�Ɋւ��Ă����i�敪�̍X�V���s���B
                if (wkInf.MainOrSubPartsDivCd == 0)// || wkInf.MainOrSubPartsDivCd == 1)
                {
                    if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Subst) != (int)GoodsKind.Subst)
                        usrGoodsRow.GoodsKind += (int)GoodsKind.Subst; // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                }
                else
                {
                    if ((usrGoodsRow.GoodsKind & (int)GoodsKind.SubstPlrl) != (int)GoodsKind.SubstPlrl)
                        usrGoodsRow.GoodsKind += (int)GoodsKind.SubstPlrl; // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                }

                if (partsInfo.UsrSubstParts.FindByChgDestGoodsNoChgSrcGoodsNoChgSrcMakerCd(
                        wkInf.NewPartsNoWithHyphen, wkInf.OldPartsNoWithHyphen, wkInf.CatalogPartsMakerCd)
                    == null)
                {
                    PartsInfoDataSet.UsrSubstPartsRow usrSubstRow = partsInfo.UsrSubstParts.NewUsrSubstPartsRow();
                    usrSubstRow.ChgDestGoodsNo = wkInf.NewPartsNoWithHyphen;
                    usrSubstRow.ChgDestMakerCd = wkInf.CatalogPartsMakerCd;
                    usrSubstRow.ChgSrcGoodsNo = wkInf.OldPartsNoWithHyphen;
                    usrSubstRow.ChgSrcMakerCd = wkInf.CatalogPartsMakerCd;
                    partsInfo.UsrSubstParts.AddUsrSubstPartsRow(usrSubstRow);
                }

            }
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ��֏��ݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <param name="partsName"></param>
        /// <param name="partsNameKana"></param>
        /// <param name="inPara"></param>
        /// <param name="key"></param>
        private void FillOfrSubstTable(ArrayList list, string partsName, string partsNameKana, GetPartsInfPara inPara, int key)
        {
            foreach (PartsSubstWork wkInf in list)
            {
                string partsMakerNm = string.Empty;
                //��֏��
                if (wkInf.MainOrSubPartsDivCd == 0)
                {
                    if (partsInfoDic[key].SubstPartsInfo.FindByNewPartsNoWithHyphenCatalogPartsMakerCdOldPartsNoWithHyphen(
                        wkInf.NewPartsNoWithHyphen, wkInf.CatalogPartsMakerCd, wkInf.OldPartsNoWithHyphen) == null)
                    {
                        PartsInfoDataSet.SubstPartsInfoRow row = partsInfoDic[key].SubstPartsInfo.NewSubstPartsInfoRow();

                        row.CatalogPartsMakerCd = wkInf.CatalogPartsMakerCd;
                        row.CatalogPartsMakerNm = GetPartsMakerName(wkInf.CatalogPartsMakerCd);
                        partsMakerNm = row.CatalogPartsMakerNm;

                        row.OldPartsNoWithHyphen = wkInf.OldPartsNoWithHyphen;
                        row.NewPartsNoWithHyphen = wkInf.NewPartsNoWithHyphen;
                        row.NPrtNoWithHypnDspOdr = wkInf.NPrtNoWithHypnDspOdr;
                        row.PartsPluralSubstFlg = wkInf.PartsPluralSubstFlg;
                        row.MainOrSubPartsDivCd = wkInf.MainOrSubPartsDivCd;
                        row.PartsQty = wkInf.PartsQty;
                        row.PartsPluralSubstCmnt = wkInf.PartsPluralSubstCmnt;
                        row.PlrlSubNewPrtNoHypn = wkInf.PlrlSubNewPrtNoHypn;
                        row.NewPrtsNoNoneHyphen = wkInf.NewPrtsNoNoneHyphen;
                        row.TbsPartsCode = wkInf.TbsPartsCode;
                        row.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                        row.MakerOfferPartsName = wkInf.MakerOfferPartsName;
                        row.PartsLayerCd = wkInf.PartsLayerCd;
                        row.PartsInfoCtrlFlg = wkInf.PartsInfoCtrlFlg;
                        row.PartsName = partsName;
                        row.PartsNameKana = partsNameKana;
                        row.PartsCode = wkInf.PartsCode;
                        row.PartsSearchCode = wkInf.PartsSearchCode;

                        partsInfoDic[key].SubstPartsInfo.AddSubstPartsInfoRow(row);
                    }
                }
                //������֏��
                else
                {
                    if (partsInfoDic[key].DSubstPartsInfo.FindByCatalogPartsMakerCdOldPartsNoWithHyphenNewPartsNoWithHyphenPlrlSubNewPrtNoHypn(
                        wkInf.CatalogPartsMakerCd, wkInf.OldPartsNoWithHyphen, wkInf.NewPartsNoWithHyphen, wkInf.PlrlSubNewPrtNoHypn) == null)
                    {
                        PartsInfoDataSet.DSubstPartsInfoRow row = partsInfoDic[key].DSubstPartsInfo.NewDSubstPartsInfoRow();

                        row.CatalogPartsMakerCd = wkInf.CatalogPartsMakerCd;
                        row.CatalogPartsMakerNm = GetPartsMakerName(wkInf.CatalogPartsMakerCd);
                        partsMakerNm = row.CatalogPartsMakerNm;

                        row.OldPartsNoWithHyphen = wkInf.OldPartsNoWithHyphen;
                        row.NewPartsNoWithHyphen = wkInf.NewPartsNoWithHyphen;
                        row.NPrtNoWithHypnDspOdr = wkInf.NPrtNoWithHypnDspOdr;
                        row.PartsPluralSubstFlg = wkInf.PartsPluralSubstFlg;
                        row.MainOrSubPartsDivCd = wkInf.MainOrSubPartsDivCd;
                        row.PartsQty = wkInf.PartsQty;
                        row.PartsPluralSubstCmnt = wkInf.PartsPluralSubstCmnt;
                        row.PlrlSubNewPrtNoHypn = wkInf.PlrlSubNewPrtNoHypn;
                        row.NewPrtsNoNoneHyphen = wkInf.NewPrtsNoNoneHyphen;
                        row.TbsPartsCode = wkInf.TbsPartsCode;
                        row.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                        row.MakerOfferPartsName = wkInf.MakerOfferPartsName;
                        row.PartsLayerCd = wkInf.PartsLayerCd;
                        row.PartsInfoCtrlFlg = wkInf.PartsInfoCtrlFlg;
                        row.PartsName = wkInf.MakerOfferPartsName; //partsName;
                        row.PartsNameKana = wkInf.MakerOfferPartsKana; //partsNameKana;
                        row.PartsCode = wkInf.PartsCode;
                        row.PartsSearchCode = wkInf.PartsSearchCode;

                        partsInfoDic[key].DSubstPartsInfo.AddDSubstPartsInfoRow(row);
                    }
                }

                PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                        goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkInf.CatalogPartsMakerCd, wkInf.NewPartsNoWithHyphen);
                if (usrGoodsRow == null)
                {
                    usrGoodsRow = goodsTableDic[key].NewUsrGoodsInfoRow();
                    usrGoodsRow.BlGoodsCode = wkInf.TbsPartsCode;
                    usrGoodsRow.GoodsKindCode = 0; // 0 : ����
                    usrGoodsRow.GoodsMakerCd = wkInf.CatalogPartsMakerCd;
                    usrGoodsRow.GoodsMakerNm = partsMakerNm;
                    //usrGoodsRow.GoodsMGroup = 0;
                    usrGoodsRow.GoodsRateRank = wkInf.PartsLayerCd;
                    usrGoodsRow.GoodsNo = wkInf.NewPartsNoWithHyphen;
                    usrGoodsRow.GoodsNoNoneHyphen = wkInf.NewPrtsNoNoneHyphen;
                    //usrGoodsRow.GoodsNote1 = "";
                    //usrGoodsRow.GoodsNote2 = "";
                    usrGoodsRow.GoodsSpecialNote = wkInf.PartsPluralSubstCmnt;
                    usrGoodsRow.QTY = wkInf.PartsQty;
                    usrGoodsRow.OfferDate = wkInf.OfferDate;
                    usrGoodsRow.OfferKubun = 3; // �񋟏��� (0:���[�U�[�o�^�^1:�񋟏����ҏW�^2:�񋟗D�ǕҏW�^3:�񋟏����^4:�񋟗D�ǁj
                    //usrGoodsRow.TaxationDivCd = 0;
                    usrGoodsRow.OfferDataDiv = 1;
                    if (wkInf.MakerOfferPartsName != string.Empty)
                    {
                        usrGoodsRow.GoodsName = wkInf.MakerOfferPartsName; // ���i���F�f�t�H���g�͕��i��
                        usrGoodsRow.GoodsNameKana = wkInf.MakerOfferPartsKana;
                    }
                    else
                    {
                        usrGoodsRow.GoodsName = partsName; // �����i���i�Â���֕i�̏ꍇ�i�������Ȃ��ꍇ������̂Łj
                        usrGoodsRow.GoodsNameKana = partsNameKana; // �i��։�ʂŕi���\���̂��߂��̏��������Ă����j
                    }
                    usrGoodsRow.GoodsOfrName = wkInf.MakerOfferPartsName; // ���i��
                    usrGoodsRow.GoodsOfrNameKana = wkInf.MakerOfferPartsKana;

                    // �����݊��̃T�u���i�͌����i�����Z�b�g���Ȃ�
                    if (wkInf.MainOrSubPartsDivCd == 0)
                    {
                        usrGoodsRow.SearchPartsFullName = partsName; // �����i��
                        usrGoodsRow.SearchPartsHalfName = partsNameKana;
                    }
                    if (wkInf.TbsPartsCdDerivedNo != 0)
                    {
                        string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                           ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                        BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                        if ((rows != null) && (rows.Length != 0))
                        {
                            usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                            usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                            usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // ���i��
                            usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                            usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // �����i��
                            usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                        }
                    }

                    goodsTableDic[key].AddUsrGoodsInfoRow(usrGoodsRow);

                }
                // ���ɓo�^���ꂽ���i�Ɋւ��Ă����i���̍X�V���s���B
                if (priceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.CatalogPartsMakerCd, wkInf.PartsPriceStDate, wkInf.NewPartsNoWithHyphen) == null)
                {
                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTableDic[key].NewUsrGoodsPriceRow();
                    usrPriceRow.GoodsNo = wkInf.NewPartsNoWithHyphen;
                    usrPriceRow.GoodsMakerCd = wkInf.CatalogPartsMakerCd;
                    usrPriceRow.ListPrice = wkInf.PartsPrice;
                    double listPrice = wkInf.PartsPrice;
                    this.ReflectIsolIslandCall(0, wkInf.CatalogPartsMakerCd, 3, ref listPrice);
                    usrPriceRow.ListPrice = listPrice;
                    usrPriceRow.OfferDate = wkInf.PriceOfferDate;
                    usrPriceRow.OpenPriceDiv = wkInf.OpenPriceDiv;
                    usrPriceRow.PriceStartDate = wkInf.PartsPriceStDate;
                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                    priceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                }
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                // ���ɓo�^���ꂽ���i�Ɋւ��Ă��񋟃f�[�^�p���i���̍X�V���s���B
                if (ofrPriceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.CatalogPartsMakerCd, wkInf.PartsPriceStDate, wkInf.NewPartsNoWithHyphen) == null)
                {
                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTableDic[key].NewUsrGoodsPriceRow();
                    usrPriceRow.GoodsNo = wkInf.NewPartsNoWithHyphen;
                    usrPriceRow.GoodsMakerCd = wkInf.CatalogPartsMakerCd;
                    usrPriceRow.ListPrice = wkInf.PartsPrice;
                    double listPrice = wkInf.PartsPrice;
                    this.ReflectIsolIslandCall(0, wkInf.CatalogPartsMakerCd, 3, ref listPrice);
                    usrPriceRow.ListPrice = listPrice;
                    usrPriceRow.OfferDate = wkInf.PriceOfferDate;
                    usrPriceRow.OpenPriceDiv = wkInf.OpenPriceDiv;
                    usrPriceRow.PriceStartDate = wkInf.PartsPriceStDate;
                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                    ofrPriceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                }
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<

                //���ɓo�^���ꂽ���i�Ɋւ��Ă����i�敪�̍X�V���s���B
                if (wkInf.MainOrSubPartsDivCd == 0)
                {
                    if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Subst) != (int)GoodsKind.Subst)
                        usrGoodsRow.GoodsKind += (int)GoodsKind.Subst; // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                }
                else
                {
                    if ((usrGoodsRow.GoodsKind & (int)GoodsKind.SubstPlrl) != (int)GoodsKind.SubstPlrl)
                        usrGoodsRow.GoodsKind += (int)GoodsKind.SubstPlrl; // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                }

                if (partsInfoDic[key].UsrSubstParts.FindByChgDestGoodsNoChgSrcGoodsNoChgSrcMakerCd(
                        wkInf.NewPartsNoWithHyphen, wkInf.OldPartsNoWithHyphen, wkInf.CatalogPartsMakerCd)
                    == null)
                {
                    PartsInfoDataSet.UsrSubstPartsRow usrSubstRow = partsInfoDic[key].UsrSubstParts.NewUsrSubstPartsRow();
                    usrSubstRow.ChgDestGoodsNo = wkInf.NewPartsNoWithHyphen;
                    usrSubstRow.ChgDestMakerCd = wkInf.CatalogPartsMakerCd;
                    usrSubstRow.ChgSrcGoodsNo = wkInf.OldPartsNoWithHyphen;
                    usrSubstRow.ChgSrcMakerCd = wkInf.CatalogPartsMakerCd;
                    partsInfoDic[key].UsrSubstParts.AddUsrSubstPartsRow(usrSubstRow);
                }

            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        # region �D�Ǖ��i���ݒ�
        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
        ///// <summary>
        ///// �D�Ǖ��i���ݒ�
        ///// </summary>
        ///// <param name="flg">true:�D�Ǖi�Ԍ����ɂ��P�[�X�^false:���������ɂ��P�[�X</param>
        ///// <param name="JoinPartsList"></param>
        ///// <param name="PrimePriceList"></param>
        ///// <param name="SetPartsInfoList"></param>
        ///// <param name="SetPriceList"></param>
        //private void FillJoinSetParts(bool flg, ArrayList JoinPartsList, ArrayList PrimePriceList,
        //                ArrayList SetPartsInfoList, ArrayList SetPriceList)
        /// <summary>
        /// �D�Ǖ��i���ݒ�
        /// </summary>
        /// <param name="flg">true:�D�Ǖi�Ԍ����ɂ��P�[�X�^false:���������ɂ��P�[�X</param>
        /// <param name="JoinPartsList"></param>
        /// <param name="PrimePriceList"></param>
        /// <param name="SetPartsInfoList"></param>
        /// <param name="SetPriceList"></param>
        /// <param name="inPara"></param>
        private void FillJoinSetParts( bool flg, ArrayList JoinPartsList, ArrayList PrimePriceList,
                        ArrayList SetPartsInfoList, ArrayList SetPriceList, GetPartsInfPara inPara )
        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
        {
            foreach (OfferJoinPartsRetWork wkInf in JoinPartsList)
            {
                if (flg && searchPrtCtlAcs.BikeSearch == 0 && bikePMakerList.Contains(wkInf.JoinDestMakerCd))
                { // �D�Ǖi�Ԍ����@���@2�֌����_��Ȃ��@���@2�֕��i���[�J�[�̏ꍇ
                    continue;
                }
                if (searchPrtCtlAcs.TactiSearch == 0  // �^�N�e�B�����_��Ȃ�
                     && wkInf.JoinDestMakerCd == ct_TactiCd // ���i���[�J�[���^�N�e�B�[
                     && (carInfoDataSet != null && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd)) // �Ԃ̃��[�J�[���g���^�łȂ�
                {
                    continue;
                }
                #region �������i�ݒ�
                if (wkInf.SubstKubun == 0)
                {
                    // --- ADD m.suzuki 2011/05/18 ---------->>>>>
                    // BL�R�[�h�}�ԑΉ�(��BL�R�[�h�������̂�)
                    if ( inPara != null && inPara.TbsPartsCode != 0 && inPara.TbsPartsCdDerivedNo != 0 )
                    {
                        // ���������R�[�h��T��
                        PartsInfoDataSet.PartsInfoRow joinSourceRow =
                            partsInfo.PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen( wkInf.JoinSourceMakerCode, wkInf.JoinSourPartsNoWithH );
                        if ( joinSourceRow != null )
                        {
                            // ���������R�[�h��BL�R�[�h�}�Ԗ��̂�t�^����B
                            if ( !string.IsNullOrEmpty( wkInf.PrimePartsName ) ) wkInf.PrimePartsName = wkInf.PrimePartsName + joinSourceRow.TbsPartsCdDerivedNm;
                            if ( !string.IsNullOrEmpty( wkInf.PrimePartsKanaName ) ) wkInf.PrimePartsKanaName = wkInf.PrimePartsKanaName + joinSourceRow.TbsPartsCdDerivedNm;
                            if ( !string.IsNullOrEmpty( wkInf.SearchPartsFullName  ) ) wkInf.SearchPartsFullName = wkInf.SearchPartsFullName + joinSourceRow.TbsPartsCdDerivedNm;
                            if ( !string.IsNullOrEmpty( wkInf.SearchPartsHalfName ) ) wkInf.SearchPartsHalfName = wkInf.SearchPartsHalfName + joinSourceRow.TbsPartsCdDerivedNm;
                        }
                    }
                    // --- ADD m.suzuki 2011/05/18 ----------<<<<<

                    PartsInfoDataSet.JoinPartsRow joinPartRow = partsInfo.JoinParts.NewJoinPartsRow();

                    joinPartRow.OfferDate = wkInf.OfferDate;
                    joinPartRow.GoodsMGroup = wkInf.GoodsMGroup;
                    joinPartRow.TbsPartsCode = wkInf.TbsPartsCode;
                    joinPartRow.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                    joinPartRow.PrmSetDtlNo1 = wkInf.PrmSetDtlNo1;
                    joinPartRow.PrmSetDtlNo2 = wkInf.PrmSetDtlNo2;
                    joinPartRow.JoinDispOrder = wkInf.JoinDispOrder;
                    joinPartRow.JoinSourceMakerCode = wkInf.JoinSourceMakerCode;
                    joinPartRow.JoinSourPartsNoWithH = wkInf.JoinSourPartsNoWithH;
                    joinPartRow.JoinSourPartsNoNoneH = wkInf.JoinSourPartsNoNoneH;
                    joinPartRow.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                    joinPartRow.JoinDestMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                    joinPartRow.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                    joinPartRow.PrimePartsName = wkInf.PrimePartsName;
                    joinPartRow.PrimePartsKanaName = wkInf.PrimePartsKanaName;
                    joinPartRow.JoinQty = wkInf.JoinQty;
                    joinPartRow.SetPartsFlg = wkInf.SetPartsFlg;
                    joinPartRow.JoinSpecialNote = wkInf.JoinSpecialNote;

                    partsInfo.JoinParts.AddJoinPartsRow(joinPartRow);

                    #region USR
                    //�@�D�ǐݒ�i������
                    bool joinExcludeFlg = false;
                    // 2009.02.12 >>>
                    //PrmSettingUWork prmSetting = null;
                    //PrmSettingKey prmKey = new PrmSettingKey(_sectionCode, wkInf.GoodsMGroup,
                    //        wkInf.TbsPartsCode, wkInf.JoinDestMakerCd);
                    //if (_drPrmSettingWork.ContainsKey(prmKey) == false)
                    //{
                    //    joinExcludeFlg = true;
                    //}
                    //else
                    //{
                    //    prmSetting = _drPrmSettingWork[prmKey];
                    //    if ((flg == false && prmSetting.PrimeDisplayCode != 1)
                    //        || (flg && prmSetting.PrimeDisplayCode == 0)) // �D�Ǖ\���敪��[�D�Ǖ\���敪]�ȊO�͕\�����Ȃ��B
                    //        joinExcludeFlg = true;
                    //}

                    // 2009.02.17 >>>
                    //PrmSettingUWork prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, wkInf.PrmSetDtlNo1, wkInf.PrmSetDtlNo2, _drPrmSettingWork);
                    PrmSettingUWork prmSetting = null;

                    // �������ƌ����悪��v����ꍇ�͕i�Ԍ����ł̌��ʂׁ̈A�Z���N�g�܂łœ��Ă�
                    if (wkInf.JoinSourPartsNoWithH == wkInf.JoinDestPartsNo && wkInf.JoinSourceMakerCode == wkInf.JoinDestMakerCd)
                    {
                        prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, wkInf.PrmSetDtlNo1, _drPrmSettingWork);
                    }
                    else
                    {
                        prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, wkInf.PrmSetDtlNo1, wkInf.PrmSetDtlNo2, _drPrmSettingWork);
                    }
                    
                    // 2009.02.17 <<<
                    if (prmSetting == null)
                    {
                        joinExcludeFlg = true;
                    }
                    else
                    {
                        if (wkInf.JoinSourPartsNoWithH == wkInf.JoinDestPartsNo && wkInf.JoinSourceMakerCode == wkInf.JoinDestMakerCd)
                        {
                            // �Z�b�g�i�́A�D�Ǖ\���敪���u�\�����Ȃ��v�ȊO�͕\������
                            if (prmSetting.PrimeDisplayCode == 0) 
                                joinExcludeFlg = true;
                        }
                        else
                        {
                            if (( flg == false && prmSetting.PrimeDisplayCode != 1 )
                                || ( flg && prmSetting.PrimeDisplayCode == 0 )) // �D�Ǖ\���敪��[�D�Ǖ\���敪]�ȊO�͕\�����Ȃ��B
                                joinExcludeFlg = true;
                        }
                    }

                    // 2009.02.12 <<<
#if !PrimeSet
                    joinExcludeFlg = false;
#endif
                    if (joinExcludeFlg == false)
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                            goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                        if (usrGoodsRow == null)
                        {
                            usrGoodsRow = goodsTable.NewUsrGoodsInfoRow();
                            usrGoodsRow.BlGoodsCode = wkInf.TbsPartsCode;
                            usrGoodsRow.GoodsMakerCd = wkInf.JoinDestMakerCd;
                            usrGoodsRow.GoodsMakerNm = joinPartRow.JoinDestMakerNm;
                            usrGoodsRow.GoodsMGroup = wkInf.GoodsMGroup;
                            usrGoodsRow.GoodsNo = wkInf.JoinDestPartsNo;
                            usrGoodsRow.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-", "");
                            //usrGoodsRow.GoodsNote1 = "";
                            //usrGoodsRow.GoodsNote2 = "";
                            usrGoodsRow.GoodsSpecialNote = wkInf.JoinSpecialNote;
                            // ADD 2013/02/12 T.Yoshioka 2013/03/06�z�M�\�� SCM��Q��169 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                            usrGoodsRow.GoodsSpecialNoteOffer = wkInf.JoinSpecialNote;   // ���i�K�i�E���L�����i�񋟁j
                            // ADD 2013/02/12 T.Yoshioka 2013/03/06�z�M�\�� SCM��Q��169 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                            usrGoodsRow.QTY = wkInf.JoinQty;
                            usrGoodsRow.OfferDate = wkInf.OfferDate;
                            usrGoodsRow.OfferKubun = 4; // �񋟏��� (0:���[�U�[�o�^�^1:�񋟏����ҏW�^2:�񋟗D�ǕҏW�^3:�񋟏����^4:�񋟗D�ǁj
                            //usrGoodsRow.TaxationDivCd = 0;
                            usrGoodsRow.OfferDataDiv = 1;

                            usrGoodsRow.GoodsName = wkInf.PrimePartsName; // ���i���F�f�t�H���g�͕��i��
                            usrGoodsRow.GoodsNameKana = wkInf.PrimePartsKanaName;
                            usrGoodsRow.GoodsOfrName = wkInf.PrimePartsName; // ���i��
                            usrGoodsRow.GoodsOfrNameKana = wkInf.PrimePartsKanaName;
                            usrGoodsRow.SearchPartsFullName = wkInf.SearchPartsFullName; // �����i��
                            usrGoodsRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                            usrGoodsRow.GoodsRateRank = wkInf.PartsLayerCd;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD

                            // �D�ǐݒ�̐ݒ�l
#if PrimeSet
                            usrGoodsRow.PrmSetDtlName2 = prmSetting.PrmSetDtlName2;
                            usrGoodsRow.DisplayOrder = prmSetting.MakerDispOrder;
                            usrGoodsRow.PrimeDispOrder = prmSetting.PrimeDispOrder;     // 2009.02.17 Add
                            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------->>>>>
                            usrGoodsRow.PrmSetDtlNo2 = prmSetting.PrmSetDtlNo2;
                            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� -------------------------------------------<<<<<
                            // ADD 2015/02/23 �L�� SCM������ C������ʑΉ� ---------->>>>>
                            usrGoodsRow.PrmSetDtlName2ForFac = prmSetting.PrmSetDtlName2ForFac; // �D�ǐݒ�ڍז��̂Q(�H�����)
                            usrGoodsRow.PrmSetDtlName2ForCOw = prmSetting.PrmSetDtlName2ForCOw; // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
                            // ADD 2015/02/23 �L�� SCM������ C������ʑΉ� ----------<<<<<
#endif
                            // 2010/02/25 Add >>>
                            if (wkInf.TbsPartsCdDerivedNo != 0)
                            {
                                string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                                   ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                                BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                                if ((rows != null) && (rows.Length != 0))
                                {
                                    usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                                    usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                    usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // ���i��
                                    usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                    usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // �����i��
                                    usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                                }
                            }
                            // 2010/02/25 Add <<<

                            goodsTable.AddUsrGoodsInfoRow(usrGoodsRow);
                        }

                        foreach (OfferJoinPriceRetWork wkJoinPriceInf in PrimePriceList)
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
                            //if (wkJoinPriceInf.PartsMakerCd == wkInf.JoinDestMakerCd
                            //       && wkJoinPriceInf.PrimePartsNoWithH == wkInf.JoinDestPartsNo)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                            if ( wkJoinPriceInf.PartsMakerCd == wkInf.JoinDestMakerCd
                                   && wkJoinPriceInf.PrimePartsNoWithH == wkInf.JoinDestPartsNo 
                                   && wkJoinPriceInf.PrmSetDtlNo1 == wkInf.PrmSetDtlNo1 )
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                            {
                                #region USR Price
                                if (priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.JoinDestMakerCd,
                                                wkJoinPriceInf.PriceStartDate, wkInf.JoinDestPartsNo) == null)
                                {
                                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTable.NewUsrGoodsPriceRow();
                                    usrPriceRow.GoodsNo = wkJoinPriceInf.PrimePartsNoWithH;
                                    usrPriceRow.GoodsMakerCd = wkJoinPriceInf.PartsMakerCd;
                                    usrPriceRow.ListPrice = wkJoinPriceInf.NewPrice;
                                    usrPriceRow.OfferDate = wkJoinPriceInf.OfferDate;
                                    usrPriceRow.OpenPriceDiv = wkJoinPriceInf.OpenPriceDiv;
                                    usrPriceRow.PriceStartDate = wkJoinPriceInf.PriceStartDate;
                                    //usrPriceRow.SalesUnitCost = 0;
                                    //usrPriceRow.StockRate = 0;
                                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                    priceTable.AddUsrGoodsPriceRow(usrPriceRow);
                                }
                                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                                if (ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.JoinDestMakerCd,
                                                wkJoinPriceInf.PriceStartDate, wkInf.JoinDestPartsNo) == null)
                                {
                                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTable.NewUsrGoodsPriceRow();
                                    usrPriceRow.GoodsNo = wkJoinPriceInf.PrimePartsNoWithH;
                                    usrPriceRow.GoodsMakerCd = wkJoinPriceInf.PartsMakerCd;
                                    usrPriceRow.ListPrice = wkJoinPriceInf.NewPrice;
                                    usrPriceRow.OfferDate = wkJoinPriceInf.OfferDate;
                                    usrPriceRow.OpenPriceDiv = wkJoinPriceInf.OpenPriceDiv;
                                    usrPriceRow.PriceStartDate = wkJoinPriceInf.PriceStartDate;
                                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                    ofrPriceTable.AddUsrGoodsPriceRow(usrPriceRow);
                                }
                                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
                                #endregion
                            }
                        }
                        /////////////////
                        joinPartRow.UsrGoodsInfoRowParent = usrGoodsRow;
                        if (flg) // �i�Ԍ����ɂ��ꍇ
                        {
                            if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Parent) != (int)GoodsKind.Parent)
                                usrGoodsRow.GoodsKind += (int)GoodsKind.Parent;
                        }
                        else     // ���������ɂ��ꍇ
                        {
                            if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Join) != (int)GoodsKind.Join)
                                usrGoodsRow.GoodsKind += (int)GoodsKind.Join; // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                        }
                    }
                    // 2009.02.17 >>>
                    //if (flg == false) // ������񂪂���Ƃ��A�����e�[�u���ݒ�
                    if (flg == false && joinExcludeFlg == false) // ������񂪂���Ƃ��A�����e�[�u���ݒ�
                    // 2009.02.17 <<<
                    {
                        string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}='{5}' AND {6}={7}",
                            partsInfo.UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                            partsInfo.UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd,
                            partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, wkInf.JoinSourPartsNoWithH,
                            partsInfo.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, wkInf.JoinSourceMakerCode);
                        if (partsInfo.UsrJoinParts.Select(rowFilter).Length == 0)
                        {
                            PartsInfoDataSet.UsrJoinPartsRow usrJoinRow = partsInfo.UsrJoinParts.NewUsrJoinPartsRow();
                            usrJoinRow.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                            usrJoinRow.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                            usrJoinRow.JoinDispOrder = wkInf.JoinDispOrder;
                            usrJoinRow.JoinOfferDate = wkInf.OfferDate;
                            usrJoinRow.JoinQty = wkInf.JoinQty;
                            usrJoinRow.JoinSourceMakerCode = wkInf.JoinSourceMakerCode;
                            usrJoinRow.JoinSpecialNote = wkInf.JoinSpecialNote;
                            usrJoinRow.JoinSrcPartsNoNoneH = wkInf.JoinSourPartsNoNoneH;
                            usrJoinRow.JoinSrcPartsNoWithH = wkInf.JoinSourPartsNoWithH;
                            usrJoinRow.PrmSettingFlg = !joinExcludeFlg;
                            // 2009.02.17 Add >>>
                            // �D�ǐݒ�L��̏ꍇ�͌������ʁA�D�Ǖ\�������Đݒ�
                            if (prmSetting != null)
                            {
                                usrJoinRow.JoinDispOrder += ( prmSetting.MakerDispOrder * 1000000 + prmSetting.PrimeDispOrder * 100 );
                                //usrJoinRow.PrimeDispOrder = prmSetting.PrimeDispOrder;
                            }
                            // 2009.02.17 Add <<<
                            partsInfo.UsrJoinParts.AddUsrJoinPartsRow(usrJoinRow);
                        }
                    }

                    #endregion

                    #region �Z�b�g���i�ݒ�
                    if (SetPartsInfoList != null)
                    {
                        foreach (OfferSetPartsRetWork wkSetPartsInf in SetPartsInfoList)
                        {
                            if (wkSetPartsInf.SubstKubun == 0)
                            {
                                PartsInfoDataSet.GoodsSetRow goodSetRow = null;
                                if (wkSetPartsInf.SetMainMakerCd == wkInf.JoinDestMakerCd
                                    && wkSetPartsInf.SetMainPartsNo == wkInf.JoinDestPartsNo)
                                {
                                    goodSetRow = partsInfo.GoodsSet.NewGoodsSetRow();
                                    goodSetRow.OfferDate = wkSetPartsInf.OfferDate;
                                    goodSetRow.GoodsMGroup = wkSetPartsInf.GoodsMGroup;
                                    goodSetRow.TbsPartsCode = wkSetPartsInf.TbsPartsCode;
                                    goodSetRow.TbsPartsCdDerivedNo = wkSetPartsInf.TbsPartsCdDerivedNo;
                                    goodSetRow.SetMainMakerCd = wkSetPartsInf.SetMainMakerCd;
                                    goodSetRow.SetMainPartsNo = wkSetPartsInf.SetMainPartsNo;
                                    goodSetRow.SetSubMakerCd = wkSetPartsInf.SetSubMakerCd;
                                    goodSetRow.SetSubPartsNo = wkSetPartsInf.SetSubPartsNo;
                                    goodSetRow.SetName = wkSetPartsInf.SetName;
                                    goodSetRow.SetQty = wkSetPartsInf.SetQty;
                                    goodSetRow.SetSpecialNote = wkSetPartsInf.SetSpecialNote;
                                    goodSetRow.SubGoodsName = wkSetPartsInf.PrimePartsName;
                                    goodSetRow.PrimePartsKanaName = wkSetPartsInf.PrimePartsKanaName;
                                    goodSetRow.SetSubMakerName = GetPartsMakerName(wkSetPartsInf.SetSubMakerCd);
                                    goodSetRow.SetDisplayOrder = wkSetPartsInf.SetDispOrder;
                                    goodSetRow.CatalogShapeNo = wkSetPartsInf.CatalogShapeNo;
                                    goodSetRow.JoinPartsRowParent = joinPartRow;
                                    partsInfo.GoodsSet.AddGoodsSetRow(goodSetRow);

                                    #region USR
                                    //�@�D�ǐݒ�i������
                                    bool setExcludeFlg = false;
                                    // 2009.02.12 >>>
                                    //PrmSettingUWork prmSetting2 = null;
                                    //PrmSettingKey prmKey2 = new PrmSettingKey(_sectionCode, wkSetPartsInf.GoodsMGroup,
                                    //        wkSetPartsInf.TbsPartsCode, wkSetPartsInf.SetSubMakerCd);
                                    //if (_drPrmSettingWork.ContainsKey(prmKey2) == false)
                                    //{
                                    //    setExcludeFlg = true;
                                    //}
                                    //else
                                    //{
                                    //    prmSetting2 = _drPrmSettingWork[prmKey2];
                                    //    if ((flg == false && prmSetting2.PrimeDisplayCode != 1)
                                    //        || (flg && prmSetting2.PrimeDisplayCode == 0)) // �D�Ǖ\���敪��[�D�Ǖ\���敪]�ȊO�͕\�����Ȃ��B                                        
                                    //        setExcludeFlg = true;
                                    //}

                                    PrmSettingUWork prmSetting2 = SearchPrmSettingUWork(_sectionCode, wkSetPartsInf.GoodsMGroup, wkSetPartsInf.TbsPartsCode, wkSetPartsInf.SetSubMakerCd, wkInf.PrmSetDtlNo1, _drPrmSettingWork);
                                    if (prmSetting2 == null)
                                    {
                                        setExcludeFlg = true;
                                    }
                                    else
                                    {
                                        if (prmSetting2.PrimeDisplayCode == 0 ) // �D�Ǖ\���敪��[�D�Ǖ\���敪]�ȊO�͕\�����Ȃ��B                                        
                                            setExcludeFlg = true;
                                    }

                                    // 2009.02.12 <<<
#if !PrimeSet
                                    setExcludeFlg = false;
#endif
                                    if (setExcludeFlg == false)
                                    {
                                        PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                                            goodsTable.FindByGoodsMakerCdGoodsNo(wkSetPartsInf.SetSubMakerCd, wkSetPartsInf.SetSubPartsNo);
                                        if ( usrGoodsRow == null )
                                        {
                                            usrGoodsRow = goodsTable.NewUsrGoodsInfoRow();
                                            // 2009/11/24 >>>
                                            //usrGoodsRow.BlGoodsCode = wkSetPartsInf.TbsPartsCode;
                                            usrGoodsRow.BlGoodsCode = wkSetPartsInf.PrmPrtTbsPrtCd;
                                            // 2009/11/24 <<<
                                            usrGoodsRow.GoodsMakerCd = wkSetPartsInf.SetSubMakerCd;
                                            usrGoodsRow.GoodsMakerNm = GetPartsMakerName( wkSetPartsInf.SetSubMakerCd );
                                            usrGoodsRow.GoodsMGroup = wkSetPartsInf.GoodsMGroup;
                                            usrGoodsRow.GoodsNo = wkSetPartsInf.SetSubPartsNo;
                                            usrGoodsRow.GoodsNoNoneHyphen = wkSetPartsInf.SetSubPartsNo.Replace( "-", "" );
                                            //usrGoodsRow.GoodsNote1 = "";
                                            //usrGoodsRow.GoodsNote2 = "";
                                            //usrGoodsRow.GoodsSpecialNote = "";
                                            usrGoodsRow.QTY = wkSetPartsInf.SetQty;
                                            usrGoodsRow.OfferDate = wkSetPartsInf.OfferDate;
                                            usrGoodsRow.OfferKubun = 4; // �񋟏��� (0:���[�U�[�o�^�^1:�񋟏����ҏW�^2:�񋟗D�ǕҏW�^3:�񋟏����^4:�񋟗D�ǁj
                                            //usrGoodsRow.TaxationDivCd = 0;
                                            usrGoodsRow.OfferDataDiv = 1;

                                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 DEL
                                            //usrGoodsRow.GoodsName = wkSetPartsInf.PrimePartsName; // ���i���F�f�t�H���g�͕��i��
                                            //usrGoodsRow.GoodsNameKana = wkSetPartsInf.PrimePartsKanaName;
                                            //usrGoodsRow.GoodsOfrName = wkSetPartsInf.PrimePartsName; // ���i��
                                            //usrGoodsRow.GoodsOfrNameKana = wkSetPartsInf.PrimePartsKanaName;
                                            //usrGoodsRow.SearchPartsFullName = wkInf.SearchPartsFullName; // �����i��
                                            //usrGoodsRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
                                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 DEL
#if PrimeSet
                                            // �D�ǐݒ�̐ݒ�l
                                            usrGoodsRow.PrmSetDtlName2 = prmSetting2.PrmSetDtlName2;
                                            usrGoodsRow.DisplayOrder = prmSetting2.MakerDispOrder;
                                            // UPD 2015/03/04 SCM������Remine#317�Ή� -------------------------->>>>>
                                            //// ADD 2015/02/23 �L�� SCM������ C������ʑΉ� ---------->>>>>
                                            //usrGoodsRow.PrmSetDtlName2ForFac = prmSetting.PrmSetDtlName2ForFac; // �D�ǐݒ�ڍז��̂Q(�H�����)
                                            //usrGoodsRow.PrmSetDtlName2ForCOw = prmSetting.PrmSetDtlName2ForCOw; // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
                                            //// ADD 2015/02/23 �L�� SCM������ C������ʑΉ� ----------<<<<<
                                            usrGoodsRow.PrmSetDtlName2ForFac = prmSetting2.PrmSetDtlName2ForFac; // �D�ǐݒ�ڍז��̂Q(�H�����)
                                            usrGoodsRow.PrmSetDtlName2ForCOw = prmSetting2.PrmSetDtlName2ForCOw; // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
                                            // UPD 2015/03/04 SCM������Remine#317�Ή� --------------------------<<<<<

#endif
                                            goodsTable.AddUsrGoodsInfoRow( usrGoodsRow );
                                        }
                                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
                                        // �Z�b�g���̂�ݒ�
                                        usrGoodsRow.GoodsName = wkSetPartsInf.SetName; // �Z�b�g����
                                        // --- ADD m.suzuki 2010/07/14 ---------->>>>>
                                        //usrGoodsRow.GoodsNameKana = wkSetPartsInf.PrimePartsKanaName;
                                        usrGoodsRow.GoodsNameKana = GetKanaString( wkSetPartsInf.SetName ); // �Z�b�g����(���p�ϊ����ăZ�b�g)
                                        // --- ADD m.suzuki 2010/07/14 ----------<<<<<
                                        usrGoodsRow.GoodsOfrName = wkSetPartsInf.SetName; // �Z�b�g����
                                        // --- ADD m.suzuki 2010/07/14 ---------->>>>>
                                        //usrGoodsRow.GoodsOfrNameKana = wkSetPartsInf.PrimePartsKanaName;
                                        usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsNameKana;
                                        // --- ADD m.suzuki 2010/07/14 ----------<<<<<
                                        usrGoodsRow.SearchPartsFullName = wkInf.SearchPartsFullName; // �����i��
                                        usrGoodsRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
                                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD

                                        // 2010/02/25 Add >>>
                                        if (wkSetPartsInf.TbsPartsCdDerivedNo != 0)
                                        {
                                            string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkSetPartsInf.TbsPartsCode,
                                                                                               ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkSetPartsInf.TbsPartsCdDerivedNo);
                                            BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                                            if ((rows != null) && (rows.Length != 0))
                                            {
                                                usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                                                usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                                usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // �Z�b�g����
                                                usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                                usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // �����i��
                                                usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                                            }
                                        }
                                        // 2010/02/25 Add <<<

                                        foreach (OfferJoinPriceRetWork wkSetPriceInf in SetPriceList)
                                        {
                                            if ( wkSetPartsInf.SetSubMakerCd == wkSetPriceInf.PartsMakerCd
                                                   && wkSetPartsInf.SetSubPartsNo == wkSetPriceInf.PrimePartsNoWithH )
                                            {
                                                #region USR Price
                                                if (priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd,
                                                    wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH) == null)
                                                {
                                                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTable.NewUsrGoodsPriceRow();
                                                    usrPriceRow.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                                                    usrPriceRow.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                                                    usrPriceRow.ListPrice = wkSetPriceInf.NewPrice;
                                                    usrPriceRow.OfferDate = wkSetPriceInf.OfferDate;
                                                    usrPriceRow.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;
                                                    usrPriceRow.PriceStartDate = wkSetPriceInf.PriceStartDate;
                                                    //usrPriceRow.SalesUnitCost = 0;
                                                    //usrPriceRow.StockRate = 0;
                                                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                                    priceTable.AddUsrGoodsPriceRow(usrPriceRow);
                                                }
                                                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                                                if (ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd,
                                                    wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH) == null)
                                                {
                                                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTable.NewUsrGoodsPriceRow();
                                                    usrPriceRow.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                                                    usrPriceRow.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                                                    usrPriceRow.ListPrice = wkSetPriceInf.NewPrice;
                                                    usrPriceRow.OfferDate = wkSetPriceInf.OfferDate;
                                                    usrPriceRow.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;
                                                    usrPriceRow.PriceStartDate = wkSetPriceInf.PriceStartDate;
                                                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                                    ofrPriceTable.AddUsrGoodsPriceRow(usrPriceRow);
                                                }
                                                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
                                                #endregion
                                            }
                                        }
                                        ///////////////
                                        goodSetRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                        if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Set) != (int)GoodsKind.Set)
                                            usrGoodsRow.GoodsKind += (int)GoodsKind.Set; // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                                    }
                                    string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}='{5}' AND {6}={7}",
                                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, wkSetPartsInf.SetMainPartsNo,
                                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, wkSetPartsInf.SetMainMakerCd,
                                        partsInfo.UsrSetParts.SubGoodsNoColumn.ColumnName, wkSetPartsInf.SetSubPartsNo,
                                        partsInfo.UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkSetPartsInf.SetSubMakerCd);
                                    if (partsInfo.UsrSetParts.Select(rowFilter).Length == 0)
                                    {
                                        // �Z�b�g��񂪂���Ƃ��A�Z�b�g�e�[�u���ݒ�
                                        PartsInfoDataSet.UsrSetPartsRow usrSetRow = partsInfo.UsrSetParts.NewUsrSetPartsRow();
                                        usrSetRow.CatalogShapeNo = wkSetPartsInf.CatalogShapeNo;
                                        usrSetRow.CntFl = (double)wkSetPartsInf.SetQty;
                                        usrSetRow.DisplayOrder = wkSetPartsInf.SetDispOrder;
                                        usrSetRow.ParentGoodsMakerCd = wkSetPartsInf.SetMainMakerCd;
                                        usrSetRow.ParentGoodsNo = wkSetPartsInf.SetMainPartsNo;
                                        usrSetRow.SubGoodsMakerCd = wkSetPartsInf.SetSubMakerCd;
                                        usrSetRow.SubGoodsNo = wkSetPartsInf.SetSubPartsNo;
                                        usrSetRow.SetSpecialNote = wkSetPartsInf.SetSpecialNote;
                                        usrSetRow.PrmSettingFlg = !setExcludeFlg;
                                        partsInfo.UsrSetParts.AddUsrSetPartsRow(usrSetRow);
                                    }
                                    #endregion
                                }
                            }
                        }
                    }
                    #endregion
                }
                else // ������ւ̏ꍇ  [ ������ւ̃Z�b�g�͂Ȃ� ]
                {
                    #region USR
                    bool excludeFlg = false;
                    // 2009.02.12 >>>
                    //PrmSettingUWork prmSetting = null;
                    //PrmSettingKey prmKey = new PrmSettingKey(_sectionCode, wkInf.GoodsMGroup,
                    //        wkInf.TbsPartsCode, wkInf.JoinDestMakerCd);
                    //if (_drPrmSettingWork.ContainsKey(prmKey) == false)
                    //{
                    //    excludeFlg = true;
                    //}
                    //else
                    //{
                    //    prmSetting = _drPrmSettingWork[prmKey];
                    //    if ((flg == false && prmSetting.PrimeDisplayCode != 1)
                    //            || (flg && prmSetting.PrimeDisplayCode == 0)) // �D�Ǖ\���敪��[�D�Ǖ\���敪]�ȊO�͕\�����Ȃ��B
                    //        excludeFlg = true;
                    //}

                    PrmSettingUWork prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, wkInf.PrmSetDtlNo1, wkInf.PrmSetDtlNo2, _drPrmSettingWork);
                    if (prmSetting == null)
                    {
                        excludeFlg = true;
                    }
                    else
                    {
                        if (( flg == false && prmSetting.PrimeDisplayCode != 1 )
                                || ( flg && prmSetting.PrimeDisplayCode == 0 )) // �D�Ǖ\���敪��[�D�Ǖ\���敪]�ȊO�͕\�����Ȃ��B
                            excludeFlg = true;
                    }

                    // 2009.02.12 <<<
#if !PrimeSet
                    excludeFlg = false;
#endif
                    if (excludeFlg == false)
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                            goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                        if (usrGoodsRow == null)
                        {
                            usrGoodsRow = goodsTable.NewUsrGoodsInfoRow();
                            usrGoodsRow.BlGoodsCode = wkInf.TbsPartsCode;
                            usrGoodsRow.GoodsMakerCd = wkInf.JoinDestMakerCd;
                            usrGoodsRow.GoodsMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                            usrGoodsRow.GoodsMGroup = wkInf.GoodsMGroup;
                            usrGoodsRow.GoodsNo = wkInf.JoinDestPartsNo;
                            usrGoodsRow.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-", "");
                            //usrGoodsRow.GoodsNote1 = "";
                            //usrGoodsRow.GoodsNote2 = "";
                            usrGoodsRow.GoodsSpecialNote = wkInf.JoinSpecialNote;
                            usrGoodsRow.QTY = wkInf.JoinQty;
                            usrGoodsRow.OfferDate = wkInf.OfferDate;
                            usrGoodsRow.OfferKubun = 4; // �񋟏��� (0:���[�U�[�o�^�^1:�񋟏����ҏW�^2:�񋟗D�ǕҏW�^3:�񋟏����^4:�񋟗D�ǁj
                            //usrGoodsRow.TaxationDivCd = 0;
                            usrGoodsRow.OfferDataDiv = 1;

                            usrGoodsRow.GoodsName = wkInf.PrimePartsName; // ���i���F�f�t�H���g�͕��i��
                            usrGoodsRow.GoodsNameKana = wkInf.PrimePartsKanaName;
                            usrGoodsRow.GoodsOfrName = wkInf.PrimePartsName; // ���i��
                            usrGoodsRow.GoodsOfrNameKana = wkInf.PrimePartsKanaName;
                            usrGoodsRow.SearchPartsFullName = wkInf.SearchPartsFullName; // �����i��
                            usrGoodsRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
#if PrimeSet
                            // �D�ǐݒ�̐ݒ�l
                            usrGoodsRow.PrmSetDtlName2 = prmSetting.PrmSetDtlName2;
                            usrGoodsRow.DisplayOrder = prmSetting.MakerDispOrder;
                            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------>>>>>
                            usrGoodsRow.PrmSetDtlNo2 = prmSetting.PrmSetDtlNo2;
                            // ADD 2014/06/04 SCM�d�|�ꗗ��10659�Ή� ------------------------------------------<<<<<
                            // ADD 2015/02/23 �L�� SCM������ C������ʑΉ� ---------->>>>>
                            usrGoodsRow.PrmSetDtlName2ForFac = prmSetting.PrmSetDtlName2ForFac; // �D�ǐݒ�ڍז��̂Q(�H�����)
                            usrGoodsRow.PrmSetDtlName2ForCOw = prmSetting.PrmSetDtlName2ForCOw; // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
                            // ADD 2015/02/23 �L�� SCM������ C������ʑΉ� ----------<<<<<
#endif
                            goodsTable.AddUsrGoodsInfoRow(usrGoodsRow);

                            PartsInfoDataSet.UsrSubstPartsRow usrSubstRow = partsInfo.UsrSubstParts.NewUsrSubstPartsRow();
                            usrSubstRow.ChgDestGoodsNo = wkInf.JoinDestPartsNo;
                            usrSubstRow.ChgDestMakerCd = wkInf.JoinDestMakerCd;
                            usrSubstRow.ChgSrcGoodsNo = wkInf.JoinSourPartsNoWithH;
                            usrSubstRow.ChgSrcMakerCd = wkInf.JoinDestMakerCd;
                            partsInfo.UsrSubstParts.AddUsrSubstPartsRow(usrSubstRow);
                        }

                        // 2010/02/25 Add >>>
                        if (wkInf.TbsPartsCdDerivedNo != 0)
                        {
                            string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                               ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                            BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                            if ((rows != null) && (rows.Length != 0))
                            {
                                usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                                usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // ���i��
                                usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // �����i��
                                usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                            }
                        }
                        // 2010/02/25 Add <<<

                        foreach (OfferJoinPriceRetWork wkJoinPriceInf in PrimePriceList)
                        {
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 DEL
                            //if (wkJoinPriceInf.PartsMakerCd == wkInf.JoinDestMakerCd
                            //       && wkJoinPriceInf.PrimePartsNoWithH == wkInf.JoinDestPartsNo)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 DEL
                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
                            if ( wkJoinPriceInf.PartsMakerCd == wkInf.JoinDestMakerCd
                                   && wkJoinPriceInf.PrimePartsNoWithH == wkInf.JoinDestPartsNo 
                                   && wkJoinPriceInf.PrmSetDtlNo1 == wkInf.PrmSetDtlNo1)
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD
                            {
                                #region USR Price
                                if (priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.JoinDestMakerCd,
                                    wkJoinPriceInf.PriceStartDate, wkInf.JoinDestPartsNo) == null)
                                {
                                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTable.NewUsrGoodsPriceRow();
                                    usrPriceRow.GoodsNo = wkJoinPriceInf.PrimePartsNoWithH;
                                    usrPriceRow.GoodsMakerCd = wkJoinPriceInf.PartsMakerCd;
                                    usrPriceRow.ListPrice = wkJoinPriceInf.NewPrice;
                                    usrPriceRow.OfferDate = wkJoinPriceInf.OfferDate;
                                    usrPriceRow.OpenPriceDiv = wkJoinPriceInf.OpenPriceDiv;
                                    usrPriceRow.PriceStartDate = wkJoinPriceInf.PriceStartDate;
                                    //usrPriceRow.SalesUnitCost = 0;
                                    //usrPriceRow.StockRate = 0;
                                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                                    priceTable.AddUsrGoodsPriceRow(usrPriceRow);
                                }
                                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                                if (ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.JoinDestMakerCd,
                                    wkJoinPriceInf.PriceStartDate, wkInf.JoinDestPartsNo) == null)
                                {
                                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTable.NewUsrGoodsPriceRow();
                                    usrPriceRow.GoodsNo = wkJoinPriceInf.PrimePartsNoWithH;
                                    usrPriceRow.GoodsMakerCd = wkJoinPriceInf.PartsMakerCd;
                                    usrPriceRow.ListPrice = wkJoinPriceInf.NewPrice;
                                    usrPriceRow.OfferDate = wkJoinPriceInf.OfferDate;
                                    usrPriceRow.OpenPriceDiv = wkJoinPriceInf.OpenPriceDiv;
                                    usrPriceRow.PriceStartDate = wkJoinPriceInf.PriceStartDate;
                                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                                    ofrPriceTable.AddUsrGoodsPriceRow(usrPriceRow);
                                }
                                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
                                #endregion
                            }
                        }
                        if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Subst) != (int)GoodsKind.Subst)
                            usrGoodsRow.GoodsKind += (int)GoodsKind.Subst; // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                    }
                    #endregion
                }
                #endregion
            }
            if (SetPartsInfoList != null)
            {
                foreach (OfferSetPartsRetWork wkSetPartsInf in SetPartsInfoList)
                {
                    if (flg && searchPrtCtlAcs.BikeSearch == 0 && bikePMakerList.Contains(wkSetPartsInf.SetSubMakerCd))
                    { // �D�Ǖi�Ԍ����@���@2�֌����_��Ȃ��@���@2�֕��i���[�J�[�̏ꍇ
                        continue;
                    }
                    if (searchPrtCtlAcs.TactiSearch == 0  // �^�N�e�B�����_��Ȃ�
                         && wkSetPartsInf.SetSubMakerCd == ct_TactiCd // ���i���[�J�[���^�N�e�B�[
                         && (carInfoDataSet != null && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd)) // �Ԃ̃��[�J�[���g���^�łȂ�
                    {
                        continue;
                    }

                    bool excludeFlg = false;
                    // 2009.02.12 >>>
                    //PrmSettingUWork prmSetting = null;
                    //PrmSettingKey prmKey = new PrmSettingKey(_sectionCode, wkSetPartsInf.GoodsMGroup,
                    //        wkSetPartsInf.TbsPartsCode, wkSetPartsInf.SetSubMakerCd);
                    //if (_drPrmSettingWork.ContainsKey(prmKey) == false)
                    //{
                    //    excludeFlg = true;
                    //}
                    //else
                    //{
                    //    prmSetting = _drPrmSettingWork[prmKey];
                    //    if ((flg == false && prmSetting.PrimeDisplayCode != 1)
                    //            || (flg && prmSetting.PrimeDisplayCode == 0)) // �D�Ǖ\���敪��[�D�Ǖ\���敪]�ȊO�͕\�����Ȃ��B
                    //        excludeFlg = true;
                    //}

                    PrmSettingUWork prmSetting = SearchPrmSettingUWork(_sectionCode, wkSetPartsInf.GoodsMGroup, wkSetPartsInf.TbsPartsCode, wkSetPartsInf.SetSubMakerCd, _drPrmSettingWork);
                    if (prmSetting == null)
                    {
                        excludeFlg = true;
                    }
                    else
                    {
                        if (prmSetting.PrimeDisplayCode == 0 ) // �D�Ǖ\���敪��[�D�Ǖ\���敪]�ȊO�͕\�����Ȃ��B
                            excludeFlg = true;
                    }

                    // 2009.02.12 <<<
#if !PrimeSet
                    excludeFlg = false;
#endif
                    //if (excludeFlg == false)
                    if ( excludeFlg == false && wkSetPartsInf.SubstKubun == 1 ) // �Z�b�g��ւ̏ꍇ
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                            goodsTable.FindByGoodsMakerCdGoodsNo( wkSetPartsInf.SetSubMakerCd, wkSetPartsInf.SetSubPartsNo );
                        if ( usrGoodsRow == null )
                        {
                            usrGoodsRow = goodsTable.NewUsrGoodsInfoRow();
                            usrGoodsRow.BlGoodsCode = wkSetPartsInf.TbsPartsCode;
                            usrGoodsRow.GoodsMakerCd = wkSetPartsInf.SetSubMakerCd;
                            usrGoodsRow.GoodsMakerNm = GetPartsMakerName( wkSetPartsInf.SetSubMakerCd );
                            usrGoodsRow.GoodsMGroup = wkSetPartsInf.GoodsMGroup;
                            usrGoodsRow.GoodsNo = wkSetPartsInf.SetSubPartsNo;
                            usrGoodsRow.GoodsNoNoneHyphen = wkSetPartsInf.SetSubPartsNo.Replace( "-", "" );
                            //usrGoodsRow.GoodsNote1 = "";
                            //usrGoodsRow.GoodsNote2 = "";
                            //usrGoodsRow.GoodsSpecialNote = "";
                            usrGoodsRow.QTY = wkSetPartsInf.SetQty;
                            usrGoodsRow.OfferDate = wkSetPartsInf.OfferDate;
                            usrGoodsRow.OfferKubun = 4; // �񋟏��� (0:���[�U�[�o�^�^1:�񋟏����ҏW�^2:�񋟗D�ǕҏW�^3:�񋟏����^4:�񋟗D�ǁj
                            //usrGoodsRow.TaxationDivCd = 0;
                            usrGoodsRow.OfferDataDiv = 1;

                            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 DEL
                            //usrGoodsRow.GoodsName = wkSetPartsInf.PrimePartsName; // ���i���F�f�t�H���g�͕��i��
                            //usrGoodsRow.GoodsNameKana = wkSetPartsInf.PrimePartsKanaName;
                            //usrGoodsRow.GoodsOfrName = wkSetPartsInf.PrimePartsName; // ���i��
                            //usrGoodsRow.GoodsOfrNameKana = wkSetPartsInf.PrimePartsKanaName;
                            //usrGoodsRow.SearchPartsFullName = wkSetPartsInf.SearchPartsFullName; // �����i��
                            //usrGoodsRow.SearchPartsHalfName = wkSetPartsInf.SearchPartsHalfName;
                            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 DEL
                            goodsTable.AddUsrGoodsInfoRow( usrGoodsRow );

                            PartsInfoDataSet.UsrSubstPartsRow usrSubstRow = partsInfo.UsrSubstParts.NewUsrSubstPartsRow();
                            usrSubstRow.ChgDestGoodsNo = wkSetPartsInf.SetSubPartsNo;
                            usrSubstRow.ChgDestMakerCd = wkSetPartsInf.SetSubMakerCd;
                            usrSubstRow.ChgSrcGoodsNo = wkSetPartsInf.SetMainPartsNo;
                            usrSubstRow.ChgSrcMakerCd = wkSetPartsInf.SetMainMakerCd;
                            partsInfo.UsrSubstParts.AddUsrSubstPartsRow( usrSubstRow );
                        }
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
                        // �Z�b�g���̂�ݒ�
                        usrGoodsRow.GoodsName = wkSetPartsInf.SetName; // �Z�b�g����
                        // --- UPD m.suzuki 2010/07/14 ---------->>>>>
                        //usrGoodsRow.GoodsNameKana = wkSetPartsInf.PrimePartsKanaName;
                        usrGoodsRow.GoodsNameKana = GetKanaString( wkSetPartsInf.SetName ); // �Z�b�g����(���p�ϊ���ɃZ�b�g)
                        // --- UPD m.suzuki 2010/07/14 ----------<<<<<
                        usrGoodsRow.GoodsOfrName = wkSetPartsInf.SetName; // �Z�b�g����
                        // --- UPD m.suzuki 2010/07/14 ---------->>>>>
                        //usrGoodsRow.GoodsOfrNameKana = wkSetPartsInf.PrimePartsKanaName;
                        usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsNameKana;
                        // --- UPD m.suzuki 2010/07/14 ----------<<<<<
                        usrGoodsRow.SearchPartsFullName = wkSetPartsInf.SearchPartsFullName; // �����i��
                        usrGoodsRow.SearchPartsHalfName = wkSetPartsInf.SearchPartsHalfName;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD

                        // 2010/02/25 Add >>>
                        if (wkSetPartsInf.TbsPartsCdDerivedNo != 0)
                        {
                            string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkSetPartsInf.TbsPartsCode,
                                                                               ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkSetPartsInf.TbsPartsCdDerivedNo);
                            BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                            if ((rows != null) && (rows.Length != 0))
                            {
                                usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                                usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // �Z�b�g����
                                usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; ; // �����i��
                                usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                            }
                        }
                        // 2010/02/25 Add <<<

                        foreach (OfferJoinPriceRetWork wkSetPriceInf in SetPriceList)
                        {
                            if ( wkSetPartsInf.SetSubMakerCd == wkSetPriceInf.PartsMakerCd
                                   && wkSetPartsInf.SetSubPartsNo == wkSetPriceInf.PrimePartsNoWithH )
                            {
                                #region USR Price
                                if ( priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo( wkSetPriceInf.PartsMakerCd,
                                    wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH ) == null )
                                {
                                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTable.NewUsrGoodsPriceRow();
                                    usrPriceRow.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                                    usrPriceRow.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                                    usrPriceRow.ListPrice = wkSetPriceInf.NewPrice;
                                    usrPriceRow.OfferDate = wkSetPriceInf.OfferDate;
                                    usrPriceRow.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;
                                    usrPriceRow.PriceStartDate = wkSetPriceInf.PriceStartDate;
                                    //usrPriceRow.SalesUnitCost = 0;
                                    //usrPriceRow.StockRate = 0;
                                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                    priceTable.AddUsrGoodsPriceRow( usrPriceRow );
                                }
                                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                                if (ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd,
                                    wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH) == null)
                                {
                                    PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTable.NewUsrGoodsPriceRow();
                                    usrPriceRow.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                                    usrPriceRow.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                                    usrPriceRow.ListPrice = wkSetPriceInf.NewPrice;
                                    usrPriceRow.OfferDate = wkSetPriceInf.OfferDate;
                                    usrPriceRow.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;
                                    usrPriceRow.PriceStartDate = wkSetPriceInf.PriceStartDate;
                                    usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                    ofrPriceTable.AddUsrGoodsPriceRow(usrPriceRow);
                                }
                                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
                                #endregion
                            }
                        }
                        if ( (usrGoodsRow.GoodsKind & (int)GoodsKind.Subst) != (int)GoodsKind.Subst )
                            usrGoodsRow.GoodsKind += (int)GoodsKind.Subst; // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                    }
                }
            }
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// �D�Ǖ��i���ݒ�
        /// </summary>
        /// <param name="flg">true:�D�Ǖi�Ԍ����ɂ��P�[�X�^false:���������ɂ��P�[�X</param>
        /// <param name="JoinPartsList"></param>
        /// <param name="PrimePriceList"></param>
        /// <param name="SetPartsInfoList"></param>
        /// <param name="SetPriceList"></param>
        /// <param name="inPara"></param>
        /// <param name="key"></param>
        private void FillJoinSetParts(bool flg, ArrayList JoinPartsList, ArrayList PrimePriceList,
                        ArrayList SetPartsInfoList, ArrayList SetPriceList, GetPartsInfPara inPara, int key)
        {
            // ���i��񂪑��݂��鎞
            if (JoinPartsList != null && JoinPartsList.Count != 0)
            {
                foreach (OfferJoinPartsRetWork wkInf in JoinPartsList)
                {
                    if (flg && searchPrtCtlAcs.BikeSearch == 0 && bikePMakerList.Contains(wkInf.JoinDestMakerCd))
                    { // �D�Ǖi�Ԍ����@���@2�֌����_��Ȃ��@���@2�֕��i���[�J�[�̏ꍇ
                        continue;
                    }
                    if (searchPrtCtlAcs.TactiSearch == 0  // �^�N�e�B�����_��Ȃ�
                         && wkInf.JoinDestMakerCd == ct_TactiCd // ���i���[�J�[���^�N�e�B�[
                         && (carInfoDataSet != null && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd)) // �Ԃ̃��[�J�[���g���^�łȂ�
                    {
                        continue;
                    }
                    #region �������i�ݒ�
                    if (wkInf.SubstKubun == 0)
                    {
                        // BL�R�[�h�}�ԑΉ�(��BL�R�[�h�������̂�)
                        if (inPara != null && inPara.TbsPartsCode != 0 && inPara.TbsPartsCdDerivedNo != 0)
                        {
                            // ���������R�[�h��T��
                            PartsInfoDataSet.PartsInfoRow joinSourceRow =
                                partsInfoDic[key].PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(wkInf.JoinSourceMakerCode, wkInf.JoinSourPartsNoWithH);
                            if (joinSourceRow != null)
                            {
                                // ���������R�[�h��BL�R�[�h�}�Ԗ��̂�t�^����B
                                if (!string.IsNullOrEmpty(wkInf.PrimePartsName)) wkInf.PrimePartsName = wkInf.PrimePartsName + joinSourceRow.TbsPartsCdDerivedNm;
                                if (!string.IsNullOrEmpty(wkInf.PrimePartsKanaName)) wkInf.PrimePartsKanaName = wkInf.PrimePartsKanaName + joinSourceRow.TbsPartsCdDerivedNm;
                                if (!string.IsNullOrEmpty(wkInf.SearchPartsFullName)) wkInf.SearchPartsFullName = wkInf.SearchPartsFullName + joinSourceRow.TbsPartsCdDerivedNm;
                                if (!string.IsNullOrEmpty(wkInf.SearchPartsHalfName)) wkInf.SearchPartsHalfName = wkInf.SearchPartsHalfName + joinSourceRow.TbsPartsCdDerivedNm;
                            }
                        }

                        PartsInfoDataSet.JoinPartsRow joinPartRow = partsInfoDic[key].JoinParts.NewJoinPartsRow();

                        joinPartRow.OfferDate = wkInf.OfferDate;
                        joinPartRow.GoodsMGroup = wkInf.GoodsMGroup;
                        joinPartRow.TbsPartsCode = wkInf.TbsPartsCode;
                        joinPartRow.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                        joinPartRow.PrmSetDtlNo1 = wkInf.PrmSetDtlNo1;
                        joinPartRow.PrmSetDtlNo2 = wkInf.PrmSetDtlNo2;
                        joinPartRow.JoinDispOrder = wkInf.JoinDispOrder;
                        joinPartRow.JoinSourceMakerCode = wkInf.JoinSourceMakerCode;
                        joinPartRow.JoinSourPartsNoWithH = wkInf.JoinSourPartsNoWithH;
                        joinPartRow.JoinSourPartsNoNoneH = wkInf.JoinSourPartsNoNoneH;
                        joinPartRow.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                        joinPartRow.JoinDestMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                        joinPartRow.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                        joinPartRow.PrimePartsName = wkInf.PrimePartsName;
                        joinPartRow.PrimePartsKanaName = wkInf.PrimePartsKanaName;
                        joinPartRow.JoinQty = wkInf.JoinQty;
                        joinPartRow.SetPartsFlg = wkInf.SetPartsFlg;
                        joinPartRow.JoinSpecialNote = wkInf.JoinSpecialNote;

                        partsInfoDic[key].JoinParts.AddJoinPartsRow(joinPartRow);

                        #region USR
                        //�@�D�ǐݒ�i������
                        bool joinExcludeFlg = false;
                        PrmSettingUWork prmSetting = null;

                        // UPD 2014/05/09 ���x���P�t�F�[�Y�Q��11,��12 �g��  -------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        #region ���\�[�X
                        //// �������ƌ����悪��v����ꍇ�͕i�Ԍ����ł̌��ʂׁ̈A�Z���N�g�܂łœ��Ă�
                        //if (wkInf.JoinSourPartsNoWithH == wkInf.JoinDestPartsNo && wkInf.JoinSourceMakerCode == wkInf.JoinDestMakerCd)
                        //{
                        //    prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, wkInf.PrmSetDtlNo1, _drPrmSettingWork);
                        //}
                        //else
                        //{
                        //    prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, wkInf.PrmSetDtlNo1, wkInf.PrmSetDtlNo2, _drPrmSettingWork);
                        //}

                        //if (prmSetting == null)
                        //{
                        //    joinExcludeFlg = true;
                        //}
                        //else
                        //{
                        //    if (wkInf.JoinSourPartsNoWithH == wkInf.JoinDestPartsNo && wkInf.JoinSourceMakerCode == wkInf.JoinDestMakerCd)
                        //    {
                        //        // �Z�b�g�i�́A�D�Ǖ\���敪���u�\�����Ȃ��v�ȊO�͕\������
                        //        if (prmSetting.PrimeDisplayCode == 0)
                        //            joinExcludeFlg = true;
                        //    }
                        //    else
                        //    {
                        //        if ((flg == false && prmSetting.PrimeDisplayCode != 1)
                        //            || (flg && prmSetting.PrimeDisplayCode == 0)) // �D�Ǖ\���敪��[�D�Ǖ\���敪]�ȊO�͕\�����Ȃ��B
                        //            joinExcludeFlg = true;
                        //    }
                        //}
                        #endregion

                        if (wkInf.JoinSourPartsNoWithH == wkInf.JoinDestPartsNo && wkInf.JoinSourceMakerCode == wkInf.JoinDestMakerCd)
                        {
                            // �i�Ԍ����̏ꍇ�E�E�E�������ƌ����悪��v����ꍇ�͕i�Ԍ����ł̌��ʂׁ̈A�Z���N�g�܂łœ��Ă�
                            prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, wkInf.PrmSetDtlNo1, _drPrmSettingWork);

                            if (prmSetting == null)
                            {
                                joinExcludeFlg = true;
                            }
                            else
                            {
                                if (wkInf.JoinSourPartsNoWithH == wkInf.JoinDestPartsNo && wkInf.JoinSourceMakerCode == wkInf.JoinDestMakerCd)
                                {
                                    // �Z�b�g�i�́A�D�Ǖ\���敪���u�\�����Ȃ��v�ȊO�͕\������
                                    if (prmSetting.PrimeDisplayCode == 0)
                                        joinExcludeFlg = true;
                                }
                                else
                                {
                                    if ((flg == false && prmSetting.PrimeDisplayCode != 1)
                                        || (flg && prmSetting.PrimeDisplayCode == 0)) // �D�Ǖ\���敪��[�D�Ǖ\���敪]�ȊO�͕\�����Ȃ��B
                                        joinExcludeFlg = true;
                                }
                            }
                        }
                        else
                        {
                            // BL�R�[�h�����̏ꍇ�E�E�EOFFER_AP �̗D�Ǖ��i�����ŗD�ǐݒ�i�������{�ς݂Ȃ̂ŁA�����ł͗D�ǐݒ�̓Ǎ��݂̂ݎ��{
                            prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, wkInf.PrmSetDtlNo1, wkInf.PrmSetDtlNo2, _drPrmSettingWork);
                            if (prmSetting == null)
                            {
                                joinExcludeFlg = true;
                            }
                        }
                        // UPD 2014/05/09 ���x���P�t�F�[�Y�Q��11,��12 �g��  --------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

#if !PrimeSet
                joinExcludeFlg = false;
#endif
                        if (joinExcludeFlg == false)
                        {
                            PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                                goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                            if (usrGoodsRow == null)
                            {
                                usrGoodsRow = goodsTableDic[key].NewUsrGoodsInfoRow();
                                usrGoodsRow.BlGoodsCode = wkInf.TbsPartsCode;
                                usrGoodsRow.GoodsMakerCd = wkInf.JoinDestMakerCd;
                                usrGoodsRow.GoodsMakerNm = joinPartRow.JoinDestMakerNm;
                                usrGoodsRow.GoodsMGroup = wkInf.GoodsMGroup;
                                usrGoodsRow.GoodsNo = wkInf.JoinDestPartsNo;
                                usrGoodsRow.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-", "");
                                //usrGoodsRow.GoodsNote1 = "";
                                //usrGoodsRow.GoodsNote2 = "";
                                usrGoodsRow.GoodsSpecialNote = wkInf.JoinSpecialNote;
                                usrGoodsRow.GoodsSpecialNoteOffer = wkInf.JoinSpecialNote;   // ���i�K�i�E���L�����i�񋟁j
                                usrGoodsRow.QTY = wkInf.JoinQty;
                                usrGoodsRow.OfferDate = wkInf.OfferDate;
                                usrGoodsRow.OfferKubun = 4; // �񋟏��� (0:���[�U�[�o�^�^1:�񋟏����ҏW�^2:�񋟗D�ǕҏW�^3:�񋟏����^4:�񋟗D�ǁj
                                //usrGoodsRow.TaxationDivCd = 0;
                                usrGoodsRow.OfferDataDiv = 1;

                                usrGoodsRow.GoodsName = wkInf.PrimePartsName; // ���i���F�f�t�H���g�͕��i��
                                usrGoodsRow.GoodsNameKana = wkInf.PrimePartsKanaName;
                                usrGoodsRow.GoodsOfrName = wkInf.PrimePartsName; // ���i��
                                usrGoodsRow.GoodsOfrNameKana = wkInf.PrimePartsKanaName;
                                usrGoodsRow.SearchPartsFullName = wkInf.SearchPartsFullName; // �����i��
                                usrGoodsRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;

                                usrGoodsRow.GoodsRateRank = wkInf.PartsLayerCd;

                                // �D�ǐݒ�̐ݒ�l
#if PrimeSet
                                usrGoodsRow.PrmSetDtlName2 = prmSetting.PrmSetDtlName2;
                                usrGoodsRow.DisplayOrder = prmSetting.MakerDispOrder;
                                usrGoodsRow.PrimeDispOrder = prmSetting.PrimeDispOrder;
                                // ADD 2014/08/13 11070147-00 �V�X�e���e�X�g��Q��5�Ή� ------------------------------------------->>>>>
                                usrGoodsRow.PrmSetDtlNo2 = prmSetting.PrmSetDtlNo2;
                                // ADD 2014/08/13 11070147-00 �V�X�e���e�X�g��Q��5�Ή� -------------------------------------------<<<<<
                                // ADD 2015/02/23 �L�� SCM������ C������ʑΉ� ---------->>>>>
                                usrGoodsRow.PrmSetDtlName2ForFac = prmSetting.PrmSetDtlName2ForFac; // �D�ǐݒ�ڍז��̂Q(�H�����)
                                usrGoodsRow.PrmSetDtlName2ForCOw = prmSetting.PrmSetDtlName2ForCOw; // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
                                // ADD 2015/02/23 �L�� SCM������ C������ʑΉ� ----------<<<<<
#endif
                                if (wkInf.TbsPartsCdDerivedNo != 0)
                                {
                                    string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                                       ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                                    BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                                    if ((rows != null) && (rows.Length != 0))
                                    {
                                        usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                                        usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                        usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // ���i��
                                        usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                        usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // �����i��
                                        usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                                    }
                                }

                                goodsTableDic[key].AddUsrGoodsInfoRow(usrGoodsRow);
                            }

                            foreach (OfferJoinPriceRetWork wkJoinPriceInf in PrimePriceList)
                            {
                                if (wkJoinPriceInf.PartsMakerCd == wkInf.JoinDestMakerCd
                                       && wkJoinPriceInf.PrimePartsNoWithH == wkInf.JoinDestPartsNo
                                       && wkJoinPriceInf.PrmSetDtlNo1 == wkInf.PrmSetDtlNo1)
                                {
                                    #region USR Price
                                    if (priceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.JoinDestMakerCd,
                                                    wkJoinPriceInf.PriceStartDate, wkInf.JoinDestPartsNo) == null)
                                    {
                                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTableDic[key].NewUsrGoodsPriceRow();
                                        usrPriceRow.GoodsNo = wkJoinPriceInf.PrimePartsNoWithH;
                                        usrPriceRow.GoodsMakerCd = wkJoinPriceInf.PartsMakerCd;
                                        usrPriceRow.ListPrice = wkJoinPriceInf.NewPrice;
                                        usrPriceRow.OfferDate = wkJoinPriceInf.OfferDate;
                                        usrPriceRow.OpenPriceDiv = wkJoinPriceInf.OpenPriceDiv;
                                        usrPriceRow.PriceStartDate = wkJoinPriceInf.PriceStartDate;
                                        //usrPriceRow.SalesUnitCost = 0;
                                        //usrPriceRow.StockRate = 0;
                                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                                        priceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                                    }
                                    // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                                    if (ofrPriceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.JoinDestMakerCd,
                                                    wkJoinPriceInf.PriceStartDate, wkInf.JoinDestPartsNo) == null)
                                    {
                                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTableDic[key].NewUsrGoodsPriceRow();
                                        usrPriceRow.GoodsNo = wkJoinPriceInf.PrimePartsNoWithH;
                                        usrPriceRow.GoodsMakerCd = wkJoinPriceInf.PartsMakerCd;
                                        usrPriceRow.ListPrice = wkJoinPriceInf.NewPrice;
                                        usrPriceRow.OfferDate = wkJoinPriceInf.OfferDate;
                                        usrPriceRow.OpenPriceDiv = wkJoinPriceInf.OpenPriceDiv;
                                        usrPriceRow.PriceStartDate = wkJoinPriceInf.PriceStartDate;
                                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                                        ofrPriceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                                    }
                                    // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
                                    #endregion
                                }
                            }
                            joinPartRow.UsrGoodsInfoRowParent = usrGoodsRow;
                            if (flg) // �i�Ԍ����ɂ��ꍇ
                            {
                                if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Parent) != (int)GoodsKind.Parent)
                                    usrGoodsRow.GoodsKind += (int)GoodsKind.Parent;
                            }
                            else     // ���������ɂ��ꍇ
                            {
                                if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Join) != (int)GoodsKind.Join)
                                    usrGoodsRow.GoodsKind += (int)GoodsKind.Join; // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                            }
                        }
                        if (flg == false && joinExcludeFlg == false) // ������񂪂���Ƃ��A�����e�[�u���ݒ�
                        {
                            string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}='{5}' AND {6}={7}",
                                partsInfoDic[key].UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                                partsInfoDic[key].UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd,
                                partsInfoDic[key].UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, wkInf.JoinSourPartsNoWithH,
                                partsInfoDic[key].UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, wkInf.JoinSourceMakerCode);
                            if (partsInfoDic[key].UsrJoinParts.Select(rowFilter).Length == 0)
                            {
                                PartsInfoDataSet.UsrJoinPartsRow usrJoinRow = partsInfoDic[key].UsrJoinParts.NewUsrJoinPartsRow();
                                usrJoinRow.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                                usrJoinRow.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                                usrJoinRow.JoinDispOrder = wkInf.JoinDispOrder;
                                usrJoinRow.JoinOfferDate = wkInf.OfferDate;
                                usrJoinRow.JoinQty = wkInf.JoinQty;
                                usrJoinRow.JoinSourceMakerCode = wkInf.JoinSourceMakerCode;
                                usrJoinRow.JoinSpecialNote = wkInf.JoinSpecialNote;
                                usrJoinRow.JoinSrcPartsNoNoneH = wkInf.JoinSourPartsNoNoneH;
                                usrJoinRow.JoinSrcPartsNoWithH = wkInf.JoinSourPartsNoWithH;
                                usrJoinRow.PrmSettingFlg = !joinExcludeFlg;
                                // �D�ǐݒ�L��̏ꍇ�͌������ʁA�D�Ǖ\�������Đݒ�
                                if (prmSetting != null)
                                {
                                    usrJoinRow.JoinDispOrder += (prmSetting.MakerDispOrder * 1000000 + prmSetting.PrimeDispOrder * 100);
                                }
                                partsInfoDic[key].UsrJoinParts.AddUsrJoinPartsRow(usrJoinRow);
                            }
                        }

                        #endregion

                        #region �Z�b�g���i�ݒ�
                        if (SetPartsInfoList != null)
                        {
                            foreach (OfferSetPartsRetWork wkSetPartsInf in SetPartsInfoList)
                            {
                                if (wkSetPartsInf.SubstKubun == 0)
                                {
                                    PartsInfoDataSet.GoodsSetRow goodSetRow = null;
                                    if (wkSetPartsInf.SetMainMakerCd == wkInf.JoinDestMakerCd
                                        && wkSetPartsInf.SetMainPartsNo == wkInf.JoinDestPartsNo)
                                    {
                                        goodSetRow = partsInfoDic[key].GoodsSet.NewGoodsSetRow();
                                        goodSetRow.OfferDate = wkSetPartsInf.OfferDate;
                                        goodSetRow.GoodsMGroup = wkSetPartsInf.GoodsMGroup;
                                        goodSetRow.TbsPartsCode = wkSetPartsInf.TbsPartsCode;
                                        goodSetRow.TbsPartsCdDerivedNo = wkSetPartsInf.TbsPartsCdDerivedNo;
                                        goodSetRow.SetMainMakerCd = wkSetPartsInf.SetMainMakerCd;
                                        goodSetRow.SetMainPartsNo = wkSetPartsInf.SetMainPartsNo;
                                        goodSetRow.SetSubMakerCd = wkSetPartsInf.SetSubMakerCd;
                                        goodSetRow.SetSubPartsNo = wkSetPartsInf.SetSubPartsNo;
                                        goodSetRow.SetName = wkSetPartsInf.SetName;
                                        goodSetRow.SetQty = wkSetPartsInf.SetQty;
                                        goodSetRow.SetSpecialNote = wkSetPartsInf.SetSpecialNote;
                                        goodSetRow.SubGoodsName = wkSetPartsInf.PrimePartsName;
                                        goodSetRow.PrimePartsKanaName = wkSetPartsInf.PrimePartsKanaName;
                                        goodSetRow.SetSubMakerName = GetPartsMakerName(wkSetPartsInf.SetSubMakerCd);
                                        goodSetRow.SetDisplayOrder = wkSetPartsInf.SetDispOrder;
                                        goodSetRow.CatalogShapeNo = wkSetPartsInf.CatalogShapeNo;
                                        goodSetRow.JoinPartsRowParent = joinPartRow;
                                        partsInfoDic[key].GoodsSet.AddGoodsSetRow(goodSetRow);

                                        #region USR
                                        //�@�D�ǐݒ�i������
                                        bool setExcludeFlg = false;

                                        PrmSettingUWork prmSetting2 = SearchPrmSettingUWork(_sectionCode, wkSetPartsInf.GoodsMGroup, wkSetPartsInf.TbsPartsCode, wkSetPartsInf.SetSubMakerCd, wkInf.PrmSetDtlNo1, _drPrmSettingWork);
                                        if (prmSetting2 == null)
                                        {
                                            setExcludeFlg = true;
                                        }
                                        else
                                        {
                                            if (prmSetting2.PrimeDisplayCode == 0) // �D�Ǖ\���敪��[�D�Ǖ\���敪]�ȊO�͕\�����Ȃ��B                                        
                                                setExcludeFlg = true;
                                        }

#if !PrimeSet
                                setExcludeFlg = false;
#endif
                                        if (setExcludeFlg == false)
                                        {
                                            PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                                                goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkSetPartsInf.SetSubMakerCd, wkSetPartsInf.SetSubPartsNo);
                                            if (usrGoodsRow == null)
                                            {
                                                usrGoodsRow = goodsTableDic[key].NewUsrGoodsInfoRow();
                                                usrGoodsRow.BlGoodsCode = wkSetPartsInf.PrmPrtTbsPrtCd;
                                                usrGoodsRow.GoodsMakerCd = wkSetPartsInf.SetSubMakerCd;
                                                usrGoodsRow.GoodsMakerNm = GetPartsMakerName(wkSetPartsInf.SetSubMakerCd);
                                                usrGoodsRow.GoodsMGroup = wkSetPartsInf.GoodsMGroup;
                                                usrGoodsRow.GoodsNo = wkSetPartsInf.SetSubPartsNo;
                                                usrGoodsRow.GoodsNoNoneHyphen = wkSetPartsInf.SetSubPartsNo.Replace("-", "");
                                                //usrGoodsRow.GoodsNote1 = "";
                                                //usrGoodsRow.GoodsNote2 = "";
                                                //usrGoodsRow.GoodsSpecialNote = "";
                                                usrGoodsRow.QTY = wkSetPartsInf.SetQty;
                                                usrGoodsRow.OfferDate = wkSetPartsInf.OfferDate;
                                                usrGoodsRow.OfferKubun = 4; // �񋟏��� (0:���[�U�[�o�^�^1:�񋟏����ҏW�^2:�񋟗D�ǕҏW�^3:�񋟏����^4:�񋟗D�ǁj
                                                //usrGoodsRow.TaxationDivCd = 0;
                                                usrGoodsRow.OfferDataDiv = 1;

#if PrimeSet
                                                // �D�ǐݒ�̐ݒ�l
                                                usrGoodsRow.PrmSetDtlName2 = prmSetting2.PrmSetDtlName2;
                                                usrGoodsRow.DisplayOrder = prmSetting2.MakerDispOrder;
                                                // ADD 2014/08/13 11070147-00 �V�X�e���e�X�g��Q��5�Ή� ------------------------------------------->>>>>
                                                usrGoodsRow.PrmSetDtlNo2 = prmSetting.PrmSetDtlNo2;
                                                // ADD 2014/08/13 11070147-00 �V�X�e���e�X�g��Q��5�Ή� -------------------------------------------<<<<<
                                                // UPD 2015/03/04 SCM������Redmine#317�Ή� ---------------------------->>>>>
                                                //// ADD 2015/02/23 �L�� SCM������ C������ʑΉ� ---------->>>>>
                                                //usrGoodsRow.PrmSetDtlName2ForFac = prmSetting.PrmSetDtlName2ForFac; // �D�ǐݒ�ڍז��̂Q(�H�����)
                                                //usrGoodsRow.PrmSetDtlName2ForCOw = prmSetting.PrmSetDtlName2ForCOw; // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
                                                //// ADD 2015/02/23 �L�� SCM������ C������ʑΉ� ----------<<<<<
                                                usrGoodsRow.PrmSetDtlName2ForFac = prmSetting2.PrmSetDtlName2ForFac; // �D�ǐݒ�ڍז��̂Q(�H�����)
                                                usrGoodsRow.PrmSetDtlName2ForCOw = prmSetting2.PrmSetDtlName2ForCOw; // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
                                                // UPD 2015/03/04 SCM������Redmine#317�Ή� ----------------------------<<<<<
#endif
                                                goodsTableDic[key].AddUsrGoodsInfoRow(usrGoodsRow);
                                            }
                                            // �Z�b�g���̂�ݒ�
                                            usrGoodsRow.GoodsName = wkSetPartsInf.SetName; // �Z�b�g����
                                            usrGoodsRow.GoodsNameKana = GetKanaString(wkSetPartsInf.SetName); // �Z�b�g����(���p�ϊ����ăZ�b�g)
                                            usrGoodsRow.GoodsOfrName = wkSetPartsInf.SetName; // �Z�b�g����
                                            usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsNameKana;
                                            usrGoodsRow.SearchPartsFullName = wkInf.SearchPartsFullName; // �����i��
                                            usrGoodsRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;

                                            if (wkSetPartsInf.TbsPartsCdDerivedNo != 0)
                                            {
                                                string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkSetPartsInf.TbsPartsCode,
                                                                                                   ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkSetPartsInf.TbsPartsCdDerivedNo);
                                                BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                                                if ((rows != null) && (rows.Length != 0))
                                                {
                                                    usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                                                    usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                                    usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // �Z�b�g����
                                                    usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                                    usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // �����i��
                                                    usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                                                }
                                            }

                                            foreach (OfferJoinPriceRetWork wkSetPriceInf in SetPriceList)
                                            {
                                                if (wkSetPartsInf.SetSubMakerCd == wkSetPriceInf.PartsMakerCd
                                                       && wkSetPartsInf.SetSubPartsNo == wkSetPriceInf.PrimePartsNoWithH)
                                                {
                                                    #region USR Price
                                                    if (priceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd,
                                                        wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH) == null)
                                                    {
                                                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTableDic[key].NewUsrGoodsPriceRow();
                                                        usrPriceRow.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                                                        usrPriceRow.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                                                        usrPriceRow.ListPrice = wkSetPriceInf.NewPrice;
                                                        usrPriceRow.OfferDate = wkSetPriceInf.OfferDate;
                                                        usrPriceRow.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;
                                                        usrPriceRow.PriceStartDate = wkSetPriceInf.PriceStartDate;
                                                        //usrPriceRow.SalesUnitCost = 0;
                                                        //usrPriceRow.StockRate = 0;
                                                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                                        priceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                                                    }
                                                    // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                                                    if (ofrPriceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd,
                                                        wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH) == null)
                                                    {
                                                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTableDic[key].NewUsrGoodsPriceRow();
                                                        usrPriceRow.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                                                        usrPriceRow.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                                                        usrPriceRow.ListPrice = wkSetPriceInf.NewPrice;
                                                        usrPriceRow.OfferDate = wkSetPriceInf.OfferDate;
                                                        usrPriceRow.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;
                                                        usrPriceRow.PriceStartDate = wkSetPriceInf.PriceStartDate;
                                                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                                        ofrPriceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                                                    }
                                                    // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
                                                    #endregion
                                                }
                                            }
                                            goodSetRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                            if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Set) != (int)GoodsKind.Set)
                                                usrGoodsRow.GoodsKind += (int)GoodsKind.Set; // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                                        }
                                        string rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4}='{5}' AND {6}={7}",
                                            partsInfoDic[key].UsrSetParts.ParentGoodsNoColumn.ColumnName, wkSetPartsInf.SetMainPartsNo,
                                            partsInfoDic[key].UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, wkSetPartsInf.SetMainMakerCd,
                                            partsInfoDic[key].UsrSetParts.SubGoodsNoColumn.ColumnName, wkSetPartsInf.SetSubPartsNo,
                                            partsInfoDic[key].UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkSetPartsInf.SetSubMakerCd);
                                        if (partsInfoDic[key].UsrSetParts.Select(rowFilter).Length == 0)
                                        {
                                            // �Z�b�g��񂪂���Ƃ��A�Z�b�g�e�[�u���ݒ�
                                            PartsInfoDataSet.UsrSetPartsRow usrSetRow = partsInfoDic[key].UsrSetParts.NewUsrSetPartsRow();
                                            usrSetRow.CatalogShapeNo = wkSetPartsInf.CatalogShapeNo;
                                            usrSetRow.CntFl = (double)wkSetPartsInf.SetQty;
                                            usrSetRow.DisplayOrder = wkSetPartsInf.SetDispOrder;
                                            usrSetRow.ParentGoodsMakerCd = wkSetPartsInf.SetMainMakerCd;
                                            usrSetRow.ParentGoodsNo = wkSetPartsInf.SetMainPartsNo;
                                            usrSetRow.SubGoodsMakerCd = wkSetPartsInf.SetSubMakerCd;
                                            usrSetRow.SubGoodsNo = wkSetPartsInf.SetSubPartsNo;
                                            usrSetRow.SetSpecialNote = wkSetPartsInf.SetSpecialNote;
                                            usrSetRow.PrmSettingFlg = !setExcludeFlg;
                                            partsInfoDic[key].UsrSetParts.AddUsrSetPartsRow(usrSetRow);
                                        }
                                        #endregion
                                    }
                                }
                            }
                        }
                        #endregion
                    }
                    else // ������ւ̏ꍇ  [ ������ւ̃Z�b�g�͂Ȃ� ]
                    {
                        #region USR
                        bool excludeFlg = false;

                        PrmSettingUWork prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.JoinDestMakerCd, wkInf.PrmSetDtlNo1, wkInf.PrmSetDtlNo2, _drPrmSettingWork);
                        if (prmSetting == null)
                        {
                            excludeFlg = true;
                        }
                        else
                        {
                            if ((flg == false && prmSetting.PrimeDisplayCode != 1)
                                    || (flg && prmSetting.PrimeDisplayCode == 0)) // �D�Ǖ\���敪��[�D�Ǖ\���敪]�ȊO�͕\�����Ȃ��B
                                excludeFlg = true;
                        }

#if !PrimeSet
                excludeFlg = false;
#endif
                        if (excludeFlg == false)
                        {
                            PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                                goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                            if (usrGoodsRow == null)
                            {
                                usrGoodsRow = goodsTableDic[key].NewUsrGoodsInfoRow();
                                usrGoodsRow.BlGoodsCode = wkInf.TbsPartsCode;
                                usrGoodsRow.GoodsMakerCd = wkInf.JoinDestMakerCd;
                                usrGoodsRow.GoodsMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                                usrGoodsRow.GoodsMGroup = wkInf.GoodsMGroup;
                                usrGoodsRow.GoodsNo = wkInf.JoinDestPartsNo;
                                usrGoodsRow.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-", "");
                                //usrGoodsRow.GoodsNote1 = "";
                                //usrGoodsRow.GoodsNote2 = "";
                                usrGoodsRow.GoodsSpecialNote = wkInf.JoinSpecialNote;
                                usrGoodsRow.QTY = wkInf.JoinQty;
                                usrGoodsRow.OfferDate = wkInf.OfferDate;
                                usrGoodsRow.OfferKubun = 4; // �񋟏��� (0:���[�U�[�o�^�^1:�񋟏����ҏW�^2:�񋟗D�ǕҏW�^3:�񋟏����^4:�񋟗D�ǁj
                                //usrGoodsRow.TaxationDivCd = 0;
                                usrGoodsRow.OfferDataDiv = 1;

                                usrGoodsRow.GoodsName = wkInf.PrimePartsName; // ���i���F�f�t�H���g�͕��i��
                                usrGoodsRow.GoodsNameKana = wkInf.PrimePartsKanaName;
                                usrGoodsRow.GoodsOfrName = wkInf.PrimePartsName; // ���i��
                                usrGoodsRow.GoodsOfrNameKana = wkInf.PrimePartsKanaName;
                                usrGoodsRow.SearchPartsFullName = wkInf.SearchPartsFullName; // �����i��
                                usrGoodsRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
#if PrimeSet
                                // �D�ǐݒ�̐ݒ�l
                                usrGoodsRow.PrmSetDtlName2 = prmSetting.PrmSetDtlName2;
                                usrGoodsRow.DisplayOrder = prmSetting.MakerDispOrder;
                                // ADD 2014/08/13 11070147-00 �V�X�e���e�X�g��Q��5�Ή� ------------------------------------------->>>>>
                                usrGoodsRow.PrmSetDtlNo2 = prmSetting.PrmSetDtlNo2;
                                // ADD 2014/08/13 11070147-00 �V�X�e���e�X�g��Q��5�Ή� -------------------------------------------<<<<<
                                // ADD 2015/02/23 �L�� SCM������ C������ʑΉ� ---------->>>>>
                                usrGoodsRow.PrmSetDtlName2ForFac = prmSetting.PrmSetDtlName2ForFac; // �D�ǐݒ�ڍז��̂Q(�H�����)
                                usrGoodsRow.PrmSetDtlName2ForCOw = prmSetting.PrmSetDtlName2ForCOw; // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
                                // ADD 2015/02/23 �L�� SCM������ C������ʑΉ� ----------<<<<<
#endif
                                goodsTableDic[key].AddUsrGoodsInfoRow(usrGoodsRow);

                                PartsInfoDataSet.UsrSubstPartsRow usrSubstRow = partsInfoDic[key].UsrSubstParts.NewUsrSubstPartsRow();
                                usrSubstRow.ChgDestGoodsNo = wkInf.JoinDestPartsNo;
                                usrSubstRow.ChgDestMakerCd = wkInf.JoinDestMakerCd;
                                usrSubstRow.ChgSrcGoodsNo = wkInf.JoinSourPartsNoWithH;
                                usrSubstRow.ChgSrcMakerCd = wkInf.JoinDestMakerCd;
                                partsInfoDic[key].UsrSubstParts.AddUsrSubstPartsRow(usrSubstRow);
                            }

                            if (wkInf.TbsPartsCdDerivedNo != 0)
                            {
                                string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                                   ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                                BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                                if ((rows != null) && (rows.Length != 0))
                                {
                                    usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                                    usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                    usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // ���i��
                                    usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                    usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; // �����i��
                                    usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                                }
                            }

                            foreach (OfferJoinPriceRetWork wkJoinPriceInf in PrimePriceList)
                            {
                                if (wkJoinPriceInf.PartsMakerCd == wkInf.JoinDestMakerCd
                                       && wkJoinPriceInf.PrimePartsNoWithH == wkInf.JoinDestPartsNo
                                       && wkJoinPriceInf.PrmSetDtlNo1 == wkInf.PrmSetDtlNo1)
                                {
                                    #region USR Price
                                    if (priceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.JoinDestMakerCd,
                                        wkJoinPriceInf.PriceStartDate, wkInf.JoinDestPartsNo) == null)
                                    {
                                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTableDic[key].NewUsrGoodsPriceRow();
                                        usrPriceRow.GoodsNo = wkJoinPriceInf.PrimePartsNoWithH;
                                        usrPriceRow.GoodsMakerCd = wkJoinPriceInf.PartsMakerCd;
                                        usrPriceRow.ListPrice = wkJoinPriceInf.NewPrice;
                                        usrPriceRow.OfferDate = wkJoinPriceInf.OfferDate;
                                        usrPriceRow.OpenPriceDiv = wkJoinPriceInf.OpenPriceDiv;
                                        usrPriceRow.PriceStartDate = wkJoinPriceInf.PriceStartDate;
                                        //usrPriceRow.SalesUnitCost = 0;
                                        //usrPriceRow.StockRate = 0;
                                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                        priceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                                    }
                                    // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                                    if (ofrPriceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.JoinDestMakerCd,
                                        wkJoinPriceInf.PriceStartDate, wkInf.JoinDestPartsNo) == null)
                                    {
                                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTableDic[key].NewUsrGoodsPriceRow();
                                        usrPriceRow.GoodsNo = wkJoinPriceInf.PrimePartsNoWithH;
                                        usrPriceRow.GoodsMakerCd = wkJoinPriceInf.PartsMakerCd;
                                        usrPriceRow.ListPrice = wkJoinPriceInf.NewPrice;
                                        usrPriceRow.OfferDate = wkJoinPriceInf.OfferDate;
                                        usrPriceRow.OpenPriceDiv = wkJoinPriceInf.OpenPriceDiv;
                                        usrPriceRow.PriceStartDate = wkJoinPriceInf.PriceStartDate;
                                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                        ofrPriceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                                    }
                                    // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
                                    #endregion
                                }
                            }
                            if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Subst) != (int)GoodsKind.Subst)
                                usrGoodsRow.GoodsKind += (int)GoodsKind.Subst; // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                        }
                        #endregion
                    }
                    #endregion
                }
                if (SetPartsInfoList != null)
                {
                    foreach (OfferSetPartsRetWork wkSetPartsInf in SetPartsInfoList)
                    {
                        if (flg && searchPrtCtlAcs.BikeSearch == 0 && bikePMakerList.Contains(wkSetPartsInf.SetSubMakerCd))
                        { // �D�Ǖi�Ԍ����@���@2�֌����_��Ȃ��@���@2�֕��i���[�J�[�̏ꍇ
                            continue;
                        }
                        if (searchPrtCtlAcs.TactiSearch == 0  // �^�N�e�B�����_��Ȃ�
                             && wkSetPartsInf.SetSubMakerCd == ct_TactiCd // ���i���[�J�[���^�N�e�B�[
                             && (carInfoDataSet != null && carInfoDataSet.CarModelInfo[0].MakerCode != ct_ToyotaCd)) // �Ԃ̃��[�J�[���g���^�łȂ�
                        {
                            continue;
                        }

                        bool excludeFlg = false;

                        PrmSettingUWork prmSetting = SearchPrmSettingUWork(_sectionCode, wkSetPartsInf.GoodsMGroup, wkSetPartsInf.TbsPartsCode, wkSetPartsInf.SetSubMakerCd, _drPrmSettingWork);
                        if (prmSetting == null)
                        {
                            excludeFlg = true;
                        }
                        else
                        {
                            if (prmSetting.PrimeDisplayCode == 0) // �D�Ǖ\���敪��[�D�Ǖ\���敪]�ȊO�͕\�����Ȃ��B
                                excludeFlg = true;
                        }

#if !PrimeSet
                excludeFlg = false;
#endif
                        if (excludeFlg == false && wkSetPartsInf.SubstKubun == 1) // �Z�b�g��ւ̏ꍇ
                        {
                            PartsInfoDataSet.UsrGoodsInfoRow usrGoodsRow =
                                goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkSetPartsInf.SetSubMakerCd, wkSetPartsInf.SetSubPartsNo);
                            if (usrGoodsRow == null)
                            {
                                usrGoodsRow = goodsTableDic[key].NewUsrGoodsInfoRow();
                                usrGoodsRow.BlGoodsCode = wkSetPartsInf.TbsPartsCode;
                                usrGoodsRow.GoodsMakerCd = wkSetPartsInf.SetSubMakerCd;
                                usrGoodsRow.GoodsMakerNm = GetPartsMakerName(wkSetPartsInf.SetSubMakerCd);
                                usrGoodsRow.GoodsMGroup = wkSetPartsInf.GoodsMGroup;
                                usrGoodsRow.GoodsNo = wkSetPartsInf.SetSubPartsNo;
                                usrGoodsRow.GoodsNoNoneHyphen = wkSetPartsInf.SetSubPartsNo.Replace("-", "");
                                //usrGoodsRow.GoodsNote1 = "";
                                //usrGoodsRow.GoodsNote2 = "";
                                //usrGoodsRow.GoodsSpecialNote = "";
                                usrGoodsRow.QTY = wkSetPartsInf.SetQty;
                                usrGoodsRow.OfferDate = wkSetPartsInf.OfferDate;
                                usrGoodsRow.OfferKubun = 4; // �񋟏��� (0:���[�U�[�o�^�^1:�񋟏����ҏW�^2:�񋟗D�ǕҏW�^3:�񋟏����^4:�񋟗D�ǁj
                                //usrGoodsRow.TaxationDivCd = 0;
                                usrGoodsRow.OfferDataDiv = 1;

                                goodsTableDic[key].AddUsrGoodsInfoRow(usrGoodsRow);

                                PartsInfoDataSet.UsrSubstPartsRow usrSubstRow = partsInfoDic[key].UsrSubstParts.NewUsrSubstPartsRow();
                                usrSubstRow.ChgDestGoodsNo = wkSetPartsInf.SetSubPartsNo;
                                usrSubstRow.ChgDestMakerCd = wkSetPartsInf.SetSubMakerCd;
                                usrSubstRow.ChgSrcGoodsNo = wkSetPartsInf.SetMainPartsNo;
                                usrSubstRow.ChgSrcMakerCd = wkSetPartsInf.SetMainMakerCd;
                                partsInfoDic[key].UsrSubstParts.AddUsrSubstPartsRow(usrSubstRow);
                            }
                            // �Z�b�g���̂�ݒ�
                            usrGoodsRow.GoodsName = wkSetPartsInf.SetName; // �Z�b�g����
                            usrGoodsRow.GoodsNameKana = GetKanaString(wkSetPartsInf.SetName); // �Z�b�g����(���p�ϊ���ɃZ�b�g)
                            usrGoodsRow.GoodsOfrName = wkSetPartsInf.SetName; // �Z�b�g����
                            usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsNameKana;
                            usrGoodsRow.SearchPartsFullName = wkSetPartsInf.SearchPartsFullName; // �����i��
                            usrGoodsRow.SearchPartsHalfName = wkSetPartsInf.SearchPartsHalfName;

                            if (wkSetPartsInf.TbsPartsCdDerivedNo != 0)
                            {
                                string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkSetPartsInf.TbsPartsCode,
                                                                                   ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkSetPartsInf.TbsPartsCdDerivedNo);
                                BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                                if ((rows != null) && (rows.Length != 0))
                                {
                                    usrGoodsRow.GoodsName = usrGoodsRow.GoodsName + rows[0].TbsPartsFullName;
                                    usrGoodsRow.GoodsNameKana = usrGoodsRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                                    usrGoodsRow.GoodsOfrName = usrGoodsRow.GoodsOfrName + rows[0].TbsPartsFullName; // �Z�b�g����
                                    usrGoodsRow.GoodsOfrNameKana = usrGoodsRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                                    usrGoodsRow.SearchPartsFullName = usrGoodsRow.SearchPartsFullName + rows[0].TbsPartsFullName; ; // �����i��
                                    usrGoodsRow.SearchPartsHalfName = usrGoodsRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                                }
                            }

                            foreach (OfferJoinPriceRetWork wkSetPriceInf in SetPriceList)
                            {
                                if (wkSetPartsInf.SetSubMakerCd == wkSetPriceInf.PartsMakerCd
                                       && wkSetPartsInf.SetSubPartsNo == wkSetPriceInf.PrimePartsNoWithH)
                                {
                                    #region USR Price
                                    if (priceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd,
                                        wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH) == null)
                                    {
                                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = priceTableDic[key].NewUsrGoodsPriceRow();
                                        usrPriceRow.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                                        usrPriceRow.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                                        usrPriceRow.ListPrice = wkSetPriceInf.NewPrice;
                                        usrPriceRow.OfferDate = wkSetPriceInf.OfferDate;
                                        usrPriceRow.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;
                                        usrPriceRow.PriceStartDate = wkSetPriceInf.PriceStartDate;
                                        //usrPriceRow.SalesUnitCost = 0;
                                        //usrPriceRow.StockRate = 0;
                                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                        priceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                                    }
                                    // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                                    if (ofrPriceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd,
                                        wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH) == null)
                                    {
                                        PartsInfoDataSet.UsrGoodsPriceRow usrPriceRow = ofrPriceTableDic[key].NewUsrGoodsPriceRow();
                                        usrPriceRow.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                                        usrPriceRow.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                                        usrPriceRow.ListPrice = wkSetPriceInf.NewPrice;
                                        usrPriceRow.OfferDate = wkSetPriceInf.OfferDate;
                                        usrPriceRow.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;
                                        usrPriceRow.PriceStartDate = wkSetPriceInf.PriceStartDate;
                                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;
                                        ofrPriceTableDic[key].AddUsrGoodsPriceRow(usrPriceRow);
                                    }
                                    // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
                                    #endregion
                                }
                            }
                            if ((usrGoodsRow.GoodsKind & (int)GoodsKind.Subst) != (int)GoodsKind.Subst)
                                usrGoodsRow.GoodsKind += (int)GoodsKind.Subst; // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                        }
                    }
                }
            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        # region �D�ǂa�k�������ʂ̐ݒ�
        /// <summary>
        /// �D�ǂa�k�������ʂ̐ݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <param name="lstPrice"></param>
        private void FillOfrPrimePartsTable(ArrayList list, ArrayList lstPrice)
        {
            long prmPartsProperNo = 0;
            if (list == null)
            {
                return;
            }
            foreach (OfferPrimeSearchRetWork wkInf in list)
            {
                // 2009/10/19 Add >>>
                //�@�D�ǐݒ�i������
                bool excludeFlg = false;
                PrmSettingUWork prmSetting = null;

                // �������ƌ����悪��v����ꍇ�͕i�Ԍ����ł̌��ʂׁ̈A�Z���N�g�܂łœ��Ă�
                prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.PartsMakerCd, wkInf.PrmSetDtlNo1, wkInf.PrmSetDtlNo2, _drPrmSettingWork);
                
                if (prmSetting == null)
                {
                    excludeFlg = true;
                }
                else
                {
                    // �D�Ǖ\���敪���u�\�����Ȃ��v�ȊO�͕\������
                    if (prmSetting.PrimeDisplayCode == 0) excludeFlg = true;
                }
#if !PrimeSet
                    excludeFlg = false;
#endif
                if (excludeFlg) continue;
                // 2009/10/19 Add <<<

                bool compressFlg = false;
                string query = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfo.OfrPrimeParts.PartsMakerCdColumn.ColumnName, wkInf.PartsMakerCd,
                    partsInfo.OfrPrimeParts.PrimeOldPartsNoColumn.ColumnName, wkInf.PrimePartsNoWithH);
                PartsInfoDataSet.OfrPrimePartsRow[] rows = (PartsInfoDataSet.OfrPrimePartsRow[])partsInfo.OfrPrimeParts.Select(query);
                if (rows.Length > 0) // �^���Ⴂ�̏d����h�����߁B�i�����[�g�̈��k�͌^���܂Ō���j
                {
                    if (rows[0].StProduceTypeOfYear <= wkInf.StProduceTypeOfYear && rows[0].EdProduceTypeOfYear >= wkInf.StProduceTypeOfYear)
                    {
                        if (rows[0].EdProduceTypeOfYear < wkInf.EdProduceTypeOfYear)
                        {
                            rows[0].EdProduceTypeOfYear = wkInf.EdProduceTypeOfYear;
                        }
                        compressFlg = true;
                    }
                    if (rows[0].StProduceTypeOfYear <= wkInf.EdProduceTypeOfYear && rows[0].EdProduceTypeOfYear >= wkInf.EdProduceTypeOfYear)
                    {
                        if (rows[0].StProduceTypeOfYear > wkInf.StProduceTypeOfYear)
                        {
                            rows[0].StProduceTypeOfYear = wkInf.StProduceTypeOfYear;
                        }
                        compressFlg = true;
                    }
                }
                if (rows.Length == 0 || compressFlg == false)
                {
                    // 2009/10/19 >>>
                    //if (wkInf.PrimePartsNo != string.Empty) // ��֓o�^
                    if (( wkInf.PrimePartsNo != string.Empty ) && ( wkInf.PrimePartsNo != wkInf.PrimePartsNoWithH )) // ��֓o�^
                    // 2009/10/19 <<<
                    {
                        if (partsInfo.UsrSubstParts.FindByChgDestGoodsNoChgSrcGoodsNoChgSrcMakerCd(
                                wkInf.PrimePartsNo, wkInf.PrimePartsNoWithH, wkInf.PartsMakerCd) == null)
                        {
                            PartsInfoDataSet.UsrSubstPartsRow substRow = partsInfo.UsrSubstParts.NewUsrSubstPartsRow();
                            // 2009/10/19 >>>
                            //substRow.ChgSrcGoodsNo = wkInf.PrimePartsNoWithH;
                            //substRow.ChgSrcMakerCd = wkInf.PartsMakerCd;
                            //substRow.ChgDestGoodsNo = wkInf.PrimePartsNo;
                            //substRow.ChgDestMakerCd = wkInf.PartsMakerCd;

                            substRow.ChgSrcGoodsNo = wkInf.PrimePartsNo;
                            substRow.ChgSrcMakerCd = wkInf.PartsMakerCd;
                            substRow.ChgDestGoodsNo = wkInf.PrimePartsNoWithH;
                            substRow.ChgDestMakerCd = wkInf.PartsMakerCd;
                            // 2009/10/19 <<<
                            partsInfo.UsrSubstParts.AddUsrSubstPartsRow(substRow);
                        }
                    }
                    if (wkInf.SubstFlag == 0) // ��֕i�͂����ɂ͓o�^���Ȃ��B
                    {
                        PartsInfoDataSet.OfrPrimePartsRow row = partsInfo.OfrPrimeParts.NewOfrPrimePartsRow();

                        row.OfferDate = wkInf.OfferDate;
                        prmPartsProperNo = wkInf.PrmPartsProperNo; ;
                        row.PrmPartsProperNo = prmPartsProperNo;
                        row.GoodsMGroup = wkInf.GoodsMGroup;
                        row.TbsPartsCode = wkInf.TbsPartsCode;
                        row.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                        row.PartsMakerCd = wkInf.PartsMakerCd;
                        row.PartsMakerName = GetPartsMakerName(wkInf.PartsMakerCd);
                        row.PrmSetDtlNo1 = wkInf.PrmSetDtlNo1;      // SelectCode
                        row.PrmSetDtlNo2 = wkInf.PrmSetDtlNo2;      // PrimeKindCode
                        row.PrimeSearchDispOrder = wkInf.PartsDispOrder; // PrimeSearchDispOrder
                        // 2009/10/19 >>>
                        //row.PrimePartsNo = wkInf.PrimePartsNo;
                        row.PrimePartsNo = wkInf.PrimePartsNoWithH;
                        // 2009/10/19 <<<
                        row.PrimePartsName = wkInf.PrimePartsName;
                        row.PrimePartsKanaName = wkInf.PrimePartsKanaNm;
                        // 2009/10/19 >>>
                        //row.PrimeOldPartsNo = wkInf.PrimePartsNoWithH;
                        row.PrimeOldPartsNo = wkInf.PrimePartsNo;
                        // 2009/10/19 <<<
                        row.SetPartsFlg = wkInf.SetPartsFlg;
                        row.PrimeQty = wkInf.PrimeQty;
                        row.PrimeSpecialNote = wkInf.PrimeSpecialNote;
                        //row.MakerDispOrder = 0; // �D�ǐݒ��񂩂�UI���Őݒ肷��B
                        //row.PrimeDispOrder = 0; // �D�ǐݒ��񂩂�UI���Őݒ肷��B
                        row.StProduceTypeOfYear = wkInf.StProduceTypeOfYear;
                        row.EdProduceTypeOfYear = wkInf.EdProduceTypeOfYear;
                        row.StProduceFrameNo = wkInf.StProduceFrameNo;
                        row.EdProduceFrameNo = wkInf.EdProduceFrameNo;

                        partsInfo.OfrPrimeParts.AddOfrPrimePartsRow(row);
                    }
                }

                // 2009/10/19 >>>
                if (wkInf.DoorCount != 0 || wkInf.BodyName != string.Empty || wkInf.ModelGradeNm != string.Empty ||
                    wkInf.EngineModelNm != string.Empty || wkInf.EngineDisplaceNm != string.Empty || wkInf.EDivNm != string.Empty ||
                    wkInf.TransmissionNm != string.Empty || wkInf.ShiftNm != string.Empty ||
                    wkInf.WheelDriveMethodNm != string.Empty)
                {
                // 2009/10/19 <<<
                    PartsInfoDataSet.ModelPartsDetailRow modelPartsDetailRow = partsInfo.ModelPartsDetail.NewModelPartsDetailRow();

                    modelPartsDetailRow.PartsUniqueNo = prmPartsProperNo;
                    modelPartsDetailRow.PartsMakerCd = wkInf.PartsMakerCd;
                    modelPartsDetailRow.PartsNo = wkInf.PrimePartsNoWithH;

                    //modelPartsDetailRow.FullModelFixedNo = carModelInfoRows[ix].FullModelFixedNo;
                    modelPartsDetailRow.DoorCount = wkInf.DoorCount;
                    modelPartsDetailRow.BodyName = wkInf.BodyName;
                    modelPartsDetailRow.ModelGradeNm = wkInf.ModelGradeNm;
                    modelPartsDetailRow.EngineModelNm = wkInf.EngineModelNm;
                    modelPartsDetailRow.EngineDisplaceNm = wkInf.EngineDisplaceNm;
                    modelPartsDetailRow.EDivNm = wkInf.EDivNm;
                    modelPartsDetailRow.TransmissionNm = wkInf.TransmissionNm;
                    modelPartsDetailRow.ShiftNm = wkInf.ShiftNm;
                    modelPartsDetailRow.WheelDriveMethodNm = wkInf.WheelDriveMethodNm;

                    partsInfo.ModelPartsDetail.AddModelPartsDetailRow(modelPartsDetailRow);
                }     // 2009/10/19 Del
                    
                if (partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkInf.PartsMakerCd, wkInf.PrimePartsNoWithH) == null)
                {
                    PartsInfoDataSet.UsrGoodsInfoRow usrRow = partsInfo.UsrGoodsInfo.NewUsrGoodsInfoRow();
                    usrRow.BlGoodsCode = wkInf.TbsPartsCode;
                    usrRow.DisplayOrder = wkInf.PartsDispOrder;
                    usrRow.GoodsKind = (int)GoodsKind.Parent;   // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                    usrRow.OfferKubun = 7; // �I���W�i�����i
                    usrRow.GoodsMakerCd = wkInf.PartsMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.PartsMakerCd);
                    usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    usrRow.GoodsNo = wkInf.PrimePartsNoWithH;
                    usrRow.GoodsNoNoneHyphen = wkInf.PrimePartsNoNoneH;
                    usrRow.GoodsSpecialNote = wkInf.PrimePartsSpecialNote;
                    usrRow.QTY = wkInf.PrimeQty;
                    usrRow.GoodsSpecialNote = wkInf.PrimeSpecialNote;
                    usrRow.GoodsRateRank = wkInf.PartsLayerCd;
                    usrRow.OfferDataDiv = 1;
                    usrRow.OfferDate = wkInf.OfferDate;

                    usrRow.GoodsName = wkInf.PrimePartsName; // ���i���F�f�t�H���g�͕��i��
                    usrRow.GoodsNameKana = wkInf.PrimePartsKanaNm;
                    usrRow.GoodsOfrName = wkInf.PrimePartsName; // ���i��
                    usrRow.GoodsOfrNameKana = wkInf.PrimePartsKanaNm;
                    usrRow.SearchPartsFullName = wkInf.SearchPartsFullName; // �����i��
                    usrRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
                    // 2010/02/25 Add >>>
                    if (wkInf.TbsPartsCdDerivedNo != 0)
                    {
                        string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                           ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                        BLInfoRow[] blrows = (BLInfoRow[])ofrBLInfo.Select(filter);
                        if ((rows != null) && (rows.Length != 0))
                        {
                            usrRow.GoodsName = usrRow.GoodsName + blrows[0].TbsPartsFullName;
                            usrRow.GoodsNameKana = usrRow.GoodsNameKana + blrows[0].TbsPartsHalfName;
                            usrRow.GoodsOfrName = usrRow.GoodsOfrName + blrows[0].TbsPartsFullName; // ���i��
                            usrRow.GoodsOfrNameKana = usrRow.GoodsOfrNameKana + blrows[0].TbsPartsHalfName;
                            usrRow.SearchPartsFullName = usrRow.SearchPartsFullName + blrows[0].TbsPartsFullName; // �����i��
                            usrRow.SearchPartsHalfName = usrRow.SearchPartsHalfName + blrows[0].TbsPartsHalfName;
                        }
                    }
                    // 2010/02/25 Add <<<

                    partsInfo.UsrGoodsInfo.AddUsrGoodsInfoRow(usrRow);
                }
            }
            foreach (OfferJoinPriceRetWork priceWork in lstPrice)
            {
                PartsInfoDataSet.UsrGoodsPriceRow row =
                    priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(priceWork.PartsMakerCd, priceWork.PriceStartDate, priceWork.PrimePartsNoWithH);

                if (row == null)
                {
                    row = priceTable.NewUsrGoodsPriceRow();
                    row.OfferDate = priceWork.OfferDate;
                    row.GoodsMakerCd = priceWork.PartsMakerCd;
                    row.GoodsNo = priceWork.PrimePartsNoWithH;
                    row.ListPrice = priceWork.NewPrice;
                    row.PriceStartDate = priceWork.PriceStartDate;
                    row.OpenPriceDiv = priceWork.OpenPriceDiv;
                    PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                        partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(priceWork.PartsMakerCd, priceWork.PrimePartsNoWithH);
                    if (usrRow != null)
                    {
                        row.UsrGoodsInfoRowParent = usrRow;
                        priceTable.AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                row = null;
                row = ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(priceWork.PartsMakerCd, priceWork.PriceStartDate, priceWork.PrimePartsNoWithH);

                if (row == null)
                {
                    row = ofrPriceTable.NewUsrGoodsPriceRow();
                    row.OfferDate = priceWork.OfferDate;
                    row.GoodsMakerCd = priceWork.PartsMakerCd;
                    row.GoodsNo = priceWork.PrimePartsNoWithH;
                    row.ListPrice = priceWork.NewPrice;
                    row.PriceStartDate = priceWork.PriceStartDate;
                    row.OpenPriceDiv = priceWork.OpenPriceDiv;
                    PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                        partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(priceWork.PartsMakerCd, priceWork.PrimePartsNoWithH);
                    if (usrRow != null)
                    {
                        row.UsrGoodsInfoRowParent = usrRow;
                        ofrPriceTable.AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
            }
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// �D�ǂa�k�������ʂ̐ݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <param name="lstPrice"></param>
        /// <param name="key"></param>
        private void FillOfrPrimePartsTable(ArrayList list, ArrayList lstPrice, int key)
        {
            long prmPartsProperNo = 0;
            if (list == null)
            {
                return;
            }
            foreach (OfferPrimeSearchRetWork wkInf in list)
            {
                //�@�D�ǐݒ�i������
                bool excludeFlg = false;
                PrmSettingUWork prmSetting = null;

                // �������ƌ����悪��v����ꍇ�͕i�Ԍ����ł̌��ʂׁ̈A�Z���N�g�܂łœ��Ă�
                prmSetting = SearchPrmSettingUWork(_sectionCode, wkInf.GoodsMGroup, wkInf.TbsPartsCode, wkInf.PartsMakerCd, wkInf.PrmSetDtlNo1, wkInf.PrmSetDtlNo2, _drPrmSettingWork);

                if (prmSetting == null)
                {
                    excludeFlg = true;
                }
                else
                {
                    // �D�Ǖ\���敪���u�\�����Ȃ��v�ȊO�͕\������
                    if (prmSetting.PrimeDisplayCode == 0) excludeFlg = true;
                }
#if !PrimeSet
                    excludeFlg = false;
#endif
                if (excludeFlg) continue;
                // 2009/10/19 Add <<<

                bool compressFlg = false;
                string query = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfoDic[key].OfrPrimeParts.PartsMakerCdColumn.ColumnName, wkInf.PartsMakerCd,
                    partsInfoDic[key].OfrPrimeParts.PrimeOldPartsNoColumn.ColumnName, wkInf.PrimePartsNoWithH);
                PartsInfoDataSet.OfrPrimePartsRow[] rows = (PartsInfoDataSet.OfrPrimePartsRow[])partsInfoDic[key].OfrPrimeParts.Select(query);
                if (rows.Length > 0) // �^���Ⴂ�̏d����h�����߁B�i�����[�g�̈��k�͌^���܂Ō���j
                {
                    if (rows[0].StProduceTypeOfYear <= wkInf.StProduceTypeOfYear && rows[0].EdProduceTypeOfYear >= wkInf.StProduceTypeOfYear)
                    {
                        if (rows[0].EdProduceTypeOfYear < wkInf.EdProduceTypeOfYear)
                        {
                            rows[0].EdProduceTypeOfYear = wkInf.EdProduceTypeOfYear;
                        }
                        compressFlg = true;
                    }
                    if (rows[0].StProduceTypeOfYear <= wkInf.EdProduceTypeOfYear && rows[0].EdProduceTypeOfYear >= wkInf.EdProduceTypeOfYear)
                    {
                        if (rows[0].StProduceTypeOfYear > wkInf.StProduceTypeOfYear)
                        {
                            rows[0].StProduceTypeOfYear = wkInf.StProduceTypeOfYear;
                        }
                        compressFlg = true;
                    }
                }
                if (rows.Length == 0 || compressFlg == false)
                {
                    if ((wkInf.PrimePartsNo != string.Empty) && (wkInf.PrimePartsNo != wkInf.PrimePartsNoWithH)) // ��֓o�^
                    {
                        if (partsInfoDic[key].UsrSubstParts.FindByChgDestGoodsNoChgSrcGoodsNoChgSrcMakerCd(
                                wkInf.PrimePartsNo, wkInf.PrimePartsNoWithH, wkInf.PartsMakerCd) == null)
                        {
                            PartsInfoDataSet.UsrSubstPartsRow substRow = partsInfoDic[key].UsrSubstParts.NewUsrSubstPartsRow();
                            substRow.ChgSrcGoodsNo = wkInf.PrimePartsNo;
                            substRow.ChgSrcMakerCd = wkInf.PartsMakerCd;
                            substRow.ChgDestGoodsNo = wkInf.PrimePartsNoWithH;
                            substRow.ChgDestMakerCd = wkInf.PartsMakerCd;
                            partsInfoDic[key].UsrSubstParts.AddUsrSubstPartsRow(substRow);
                        }
                    }
                    if (wkInf.SubstFlag == 0) // ��֕i�͂����ɂ͓o�^���Ȃ��B
                    {
                        PartsInfoDataSet.OfrPrimePartsRow row = partsInfoDic[key].OfrPrimeParts.NewOfrPrimePartsRow();

                        row.OfferDate = wkInf.OfferDate;
                        prmPartsProperNo = wkInf.PrmPartsProperNo; ;
                        row.PrmPartsProperNo = prmPartsProperNo;
                        row.GoodsMGroup = wkInf.GoodsMGroup;
                        row.TbsPartsCode = wkInf.TbsPartsCode;
                        row.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                        row.PartsMakerCd = wkInf.PartsMakerCd;
                        row.PartsMakerName = GetPartsMakerName(wkInf.PartsMakerCd);
                        row.PrmSetDtlNo1 = wkInf.PrmSetDtlNo1;      // SelectCode
                        row.PrmSetDtlNo2 = wkInf.PrmSetDtlNo2;      // PrimeKindCode
                        row.PrimeSearchDispOrder = wkInf.PartsDispOrder; // PrimeSearchDispOrder
                        row.PrimePartsNo = wkInf.PrimePartsNoWithH;
                        row.PrimePartsName = wkInf.PrimePartsName;
                        row.PrimePartsKanaName = wkInf.PrimePartsKanaNm;
                        row.PrimeOldPartsNo = wkInf.PrimePartsNo;
                        row.SetPartsFlg = wkInf.SetPartsFlg;
                        row.PrimeQty = wkInf.PrimeQty;
                        row.PrimeSpecialNote = wkInf.PrimeSpecialNote;
                        //row.MakerDispOrder = 0; // �D�ǐݒ��񂩂�UI���Őݒ肷��B
                        //row.PrimeDispOrder = 0; // �D�ǐݒ��񂩂�UI���Őݒ肷��B
                        row.StProduceTypeOfYear = wkInf.StProduceTypeOfYear;
                        row.EdProduceTypeOfYear = wkInf.EdProduceTypeOfYear;
                        row.StProduceFrameNo = wkInf.StProduceFrameNo;
                        row.EdProduceFrameNo = wkInf.EdProduceFrameNo;

                        partsInfoDic[key].OfrPrimeParts.AddOfrPrimePartsRow(row);
                    }
                }

                if (wkInf.DoorCount != 0 || wkInf.BodyName != string.Empty || wkInf.ModelGradeNm != string.Empty ||
                    wkInf.EngineModelNm != string.Empty || wkInf.EngineDisplaceNm != string.Empty || wkInf.EDivNm != string.Empty ||
                    wkInf.TransmissionNm != string.Empty || wkInf.ShiftNm != string.Empty ||
                    wkInf.WheelDriveMethodNm != string.Empty)
                {
                    PartsInfoDataSet.ModelPartsDetailRow modelPartsDetailRow = partsInfoDic[key].ModelPartsDetail.NewModelPartsDetailRow();

                    modelPartsDetailRow.PartsUniqueNo = prmPartsProperNo;
                    modelPartsDetailRow.PartsMakerCd = wkInf.PartsMakerCd;
                    modelPartsDetailRow.PartsNo = wkInf.PrimePartsNoWithH;

                    //modelPartsDetailRow.FullModelFixedNo = carModelInfoRows[ix].FullModelFixedNo;
                    modelPartsDetailRow.DoorCount = wkInf.DoorCount;
                    modelPartsDetailRow.BodyName = wkInf.BodyName;
                    modelPartsDetailRow.ModelGradeNm = wkInf.ModelGradeNm;
                    modelPartsDetailRow.EngineModelNm = wkInf.EngineModelNm;
                    modelPartsDetailRow.EngineDisplaceNm = wkInf.EngineDisplaceNm;
                    modelPartsDetailRow.EDivNm = wkInf.EDivNm;
                    modelPartsDetailRow.TransmissionNm = wkInf.TransmissionNm;
                    modelPartsDetailRow.ShiftNm = wkInf.ShiftNm;
                    modelPartsDetailRow.WheelDriveMethodNm = wkInf.WheelDriveMethodNm;

                    partsInfoDic[key].ModelPartsDetail.AddModelPartsDetailRow(modelPartsDetailRow);
                }

                if (partsInfoDic[key].UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkInf.PartsMakerCd, wkInf.PrimePartsNoWithH) == null)
                {
                    PartsInfoDataSet.UsrGoodsInfoRow usrRow = partsInfoDic[key].UsrGoodsInfo.NewUsrGoodsInfoRow();
                    usrRow.BlGoodsCode = wkInf.TbsPartsCode;
                    usrRow.DisplayOrder = wkInf.PartsDispOrder;
                    usrRow.GoodsKind = (int)GoodsKind.Parent;   // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
                    usrRow.OfferKubun = 7; // �I���W�i�����i
                    usrRow.GoodsMakerCd = wkInf.PartsMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.PartsMakerCd);
                    usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    usrRow.GoodsNo = wkInf.PrimePartsNoWithH;
                    usrRow.GoodsNoNoneHyphen = wkInf.PrimePartsNoNoneH;
                    usrRow.GoodsSpecialNote = wkInf.PrimePartsSpecialNote;
                    usrRow.QTY = wkInf.PrimeQty;
                    usrRow.GoodsSpecialNote = wkInf.PrimeSpecialNote;
                    usrRow.GoodsRateRank = wkInf.PartsLayerCd;
                    usrRow.OfferDataDiv = 1;
                    usrRow.OfferDate = wkInf.OfferDate;

                    usrRow.GoodsName = wkInf.PrimePartsName; // ���i���F�f�t�H���g�͕��i��
                    usrRow.GoodsNameKana = wkInf.PrimePartsKanaNm;
                    usrRow.GoodsOfrName = wkInf.PrimePartsName; // ���i��
                    usrRow.GoodsOfrNameKana = wkInf.PrimePartsKanaNm;
                    usrRow.SearchPartsFullName = wkInf.SearchPartsFullName; // �����i��
                    usrRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
                    if (wkInf.TbsPartsCdDerivedNo != 0)
                    {
                        string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                           ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                        BLInfoRow[] blrows = (BLInfoRow[])ofrBLInfo.Select(filter);
                        if ((rows != null) && (rows.Length != 0))
                        {
                            usrRow.GoodsName = usrRow.GoodsName + blrows[0].TbsPartsFullName;
                            usrRow.GoodsNameKana = usrRow.GoodsNameKana + blrows[0].TbsPartsHalfName;
                            usrRow.GoodsOfrName = usrRow.GoodsOfrName + blrows[0].TbsPartsFullName; // ���i��
                            usrRow.GoodsOfrNameKana = usrRow.GoodsOfrNameKana + blrows[0].TbsPartsHalfName;
                            usrRow.SearchPartsFullName = usrRow.SearchPartsFullName + blrows[0].TbsPartsFullName; // �����i��
                            usrRow.SearchPartsHalfName = usrRow.SearchPartsHalfName + blrows[0].TbsPartsHalfName;
                        }
                    }

                    partsInfoDic[key].UsrGoodsInfo.AddUsrGoodsInfoRow(usrRow);
                }
            }
            foreach (OfferJoinPriceRetWork priceWork in lstPrice)
            {
                PartsInfoDataSet.UsrGoodsPriceRow row =
                    priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(priceWork.PartsMakerCd, priceWork.PriceStartDate, priceWork.PrimePartsNoWithH);

                if (row == null)
                {
                    row = priceTable.NewUsrGoodsPriceRow();
                    row.OfferDate = priceWork.OfferDate;
                    row.GoodsMakerCd = priceWork.PartsMakerCd;
                    row.GoodsNo = priceWork.PrimePartsNoWithH;
                    row.ListPrice = priceWork.NewPrice;
                    row.PriceStartDate = priceWork.PriceStartDate;
                    row.OpenPriceDiv = priceWork.OpenPriceDiv;
                    PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                        partsInfoDic[key].UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(priceWork.PartsMakerCd, priceWork.PrimePartsNoWithH);
                    if (usrRow != null)
                    {
                        row.UsrGoodsInfoRowParent = usrRow;
                        priceTable.AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                row = null;
                row = ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(priceWork.PartsMakerCd, priceWork.PriceStartDate, priceWork.PrimePartsNoWithH);

                if (row == null)
                {
                    row = ofrPriceTable.NewUsrGoodsPriceRow();
                    row.OfferDate = priceWork.OfferDate;
                    row.GoodsMakerCd = priceWork.PartsMakerCd;
                    row.GoodsNo = priceWork.PrimePartsNoWithH;
                    row.ListPrice = priceWork.NewPrice;
                    row.PriceStartDate = priceWork.PriceStartDate;
                    row.OpenPriceDiv = priceWork.OpenPriceDiv;
                    PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                        partsInfoDic[key].UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(priceWork.PartsMakerCd, priceWork.PrimePartsNoWithH);
                    if (usrRow != null)
                    {
                        row.UsrGoodsInfoRowParent = usrRow;
                        ofrPriceTable.AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        # region �Z�b�g���ݒ聃�D�ǂa�k��
        /// <summary>
        /// �Z�b�g���ݒ聃�D�ǂa�k��
        /// </summary>
        /// <param name="list"></param>
        /// <param name="priceList"></param>
        private void FillOfrSetInfo(ArrayList list, ArrayList priceList)
        {
            if (list == null)
            {
                return;
            }
            foreach (OfferSetPartsRetWork wkInf in list)
            {
                PartsInfoDataSet.GoodsSetRow goodSetRow = partsInfo.GoodsSet.NewGoodsSetRow();

                goodSetRow.GoodsMGroup = wkInf.GoodsMGroup;
                goodSetRow.TbsPartsCode = wkInf.TbsPartsCode;
                goodSetRow.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                goodSetRow.SetMainMakerCd = wkInf.SetMainMakerCd;
                goodSetRow.SetMainPartsNo = wkInf.SetMainPartsNo;
                goodSetRow.SetSubMakerCd = wkInf.SetSubMakerCd;
                goodSetRow.SetSubPartsNo = wkInf.SetSubPartsNo;
                goodSetRow.SetName = wkInf.SetName;
                goodSetRow.SetQty = wkInf.SetQty;
                goodSetRow.SetSpecialNote = wkInf.SetSpecialNote;

                partsInfo.GoodsSet.AddGoodsSetRow(goodSetRow);

                PartsInfoDataSet.UsrSetPartsRow usrSetRow = partsInfo.UsrSetParts.NewUsrSetPartsRow();

                usrSetRow.ParentGoodsMakerCd = wkInf.SetMainMakerCd;
                usrSetRow.ParentGoodsNo = wkInf.SetMainPartsNo;
                usrSetRow.SubGoodsMakerCd = wkInf.SetSubMakerCd;
                usrSetRow.SubGoodsNo = wkInf.SetSubPartsNo;
                usrSetRow.CntFl = wkInf.SetQty;
                usrSetRow.SetSpecialNote = wkInf.SetSpecialNote;

                partsInfo.UsrSetParts.AddUsrSetPartsRow(usrSetRow);

                PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                    partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkInf.SetSubMakerCd, wkInf.SetSubPartsNo);
                if (usrRow == null)
                {
                    usrRow = partsInfo.UsrGoodsInfo.NewUsrGoodsInfoRow();
                    usrRow.BlGoodsCode = wkInf.TbsPartsCode;
                    usrRow.DisplayOrder = wkInf.SetDispOrder;
                    usrRow.OfferKubun = 4;
                    usrRow.GoodsMakerCd = wkInf.SetSubMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.SetSubMakerCd);
                    usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    usrRow.GoodsNo = wkInf.SetSubPartsNo;
                    usrRow.GoodsNoNoneHyphen = wkInf.SetSubPartsNo.Replace("-", "");
                    usrRow.GoodsSpecialNote = wkInf.SetSpecialNote;
                    usrRow.OfferDate = wkInf.OfferDate;
                    // --- UPD m.suzuki 2010/07/14 ---------->>>>>
                    //usrRow.GoodsName = wkInf.PrimePartsName; // ���i���F�f�t�H���g�͕��i��
                    //usrRow.GoodsNameKana = wkInf.PrimePartsKanaName;
                    //usrRow.GoodsOfrName = wkInf.PrimePartsName; // ���i��
                    //usrRow.GoodsOfrNameKana = wkInf.PrimePartsKanaName;
                    usrRow.GoodsName = wkInf.SetName; // �Z�b�g����
                    usrRow.GoodsNameKana = GetKanaString( wkInf.SetName ); // �Z�b�g����(���p�ϊ���ɃZ�b�g)
                    usrRow.GoodsOfrName = usrRow.GoodsName; // �Z�b�g����
                    usrRow.GoodsOfrNameKana = usrRow.GoodsNameKana; // �Z�b�g����
                    // --- UPD m.suzuki 2010/07/14 ----------<<<<<
                    usrRow.SearchPartsFullName = wkInf.SearchPartsFullName; // �����i��
                    usrRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
                    // 2010/02/25 Add >>>
                    if (wkInf.TbsPartsCdDerivedNo != 0)
                    {
                        string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                           ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                        BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                        if ((rows != null) && (rows.Length != 0))
                        {
                            usrRow.GoodsName = usrRow.GoodsName + rows[0].TbsPartsFullName;
                            usrRow.GoodsNameKana = usrRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                            usrRow.GoodsOfrName = usrRow.GoodsOfrName + rows[0].TbsPartsFullName; // ���i��
                            usrRow.GoodsOfrNameKana = usrRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                            usrRow.SearchPartsFullName = usrRow.SearchPartsFullName + rows[0].TbsPartsFullName; // �����i��
                            usrRow.SearchPartsHalfName = usrRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                        }
                    }
                    // 2010/02/25 Add <<<
                    partsInfo.UsrGoodsInfo.AddUsrGoodsInfoRow(usrRow);
                }
                if ((usrRow.GoodsKind & (int)GoodsKind.Set) != (int)GoodsKind.Set)
                    usrRow.GoodsKind += (int)GoodsKind.Set; // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
            }
            foreach (OfferJoinPriceRetWork wkSetPriceInf in priceList)
            {
                PartsInfoDataSet.UsrGoodsPriceRow row =
                    priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd, wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH);
                if (row == null)
                {
                    row = priceTable.NewUsrGoodsPriceRow();
                    row.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                    row.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                    row.PriceStartDate = wkSetPriceInf.PriceStartDate;
                    row.ListPrice = wkSetPriceInf.NewPrice;
                    row.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;

                    PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                        partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkSetPriceInf.PartsMakerCd, wkSetPriceInf.PrimePartsNoWithH);
                    if (usrRow != null)
                    {
                        row.UsrGoodsInfoRowParent = usrRow;
                        priceTable.AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                row = null;
                row = ofrPriceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd, wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH);

                if (row == null)
                {
                    row = ofrPriceTable.NewUsrGoodsPriceRow();
                    row.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                    row.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                    row.PriceStartDate = wkSetPriceInf.PriceStartDate;
                    row.ListPrice = wkSetPriceInf.NewPrice;
                    row.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;

                    PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                        partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkSetPriceInf.PartsMakerCd, wkSetPriceInf.PrimePartsNoWithH);
                    if (usrRow != null)
                    {
                        row.UsrGoodsInfoRowParent = usrRow;
                        ofrPriceTable.AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
            }
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// �Z�b�g���ݒ聃�D�ǂa�k��
        /// </summary>
        /// <param name="list"></param>
        /// <param name="priceList"></param>
        /// <param name="dicKey"></param>
        private void FillOfrSetInfo(ArrayList list, ArrayList priceList, int dicKey)
        {
            if (list == null)
            {
                return;
            }
            foreach (OfferSetPartsRetWork wkInf in list)
            {
                PartsInfoDataSet.GoodsSetRow goodSetRow = partsInfoDic[dicKey].GoodsSet.NewGoodsSetRow();

                goodSetRow.GoodsMGroup = wkInf.GoodsMGroup;
                goodSetRow.TbsPartsCode = wkInf.TbsPartsCode;
                goodSetRow.TbsPartsCdDerivedNo = wkInf.TbsPartsCdDerivedNo;
                goodSetRow.SetMainMakerCd = wkInf.SetMainMakerCd;
                goodSetRow.SetMainPartsNo = wkInf.SetMainPartsNo;
                goodSetRow.SetSubMakerCd = wkInf.SetSubMakerCd;
                goodSetRow.SetSubPartsNo = wkInf.SetSubPartsNo;
                goodSetRow.SetName = wkInf.SetName;
                goodSetRow.SetQty = wkInf.SetQty;
                goodSetRow.SetSpecialNote = wkInf.SetSpecialNote;

                partsInfoDic[dicKey].GoodsSet.AddGoodsSetRow(goodSetRow);

                PartsInfoDataSet.UsrSetPartsRow usrSetRow = partsInfoDic[dicKey].UsrSetParts.NewUsrSetPartsRow();

                usrSetRow.ParentGoodsMakerCd = wkInf.SetMainMakerCd;
                usrSetRow.ParentGoodsNo = wkInf.SetMainPartsNo;
                usrSetRow.SubGoodsMakerCd = wkInf.SetSubMakerCd;
                usrSetRow.SubGoodsNo = wkInf.SetSubPartsNo;
                usrSetRow.CntFl = wkInf.SetQty;
                usrSetRow.SetSpecialNote = wkInf.SetSpecialNote;

                partsInfoDic[dicKey].UsrSetParts.AddUsrSetPartsRow(usrSetRow);

                PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                    partsInfoDic[dicKey].UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkInf.SetSubMakerCd, wkInf.SetSubPartsNo);
                if (usrRow == null)
                {
                    usrRow = partsInfoDic[dicKey].UsrGoodsInfo.NewUsrGoodsInfoRow();
                    usrRow.BlGoodsCode = wkInf.TbsPartsCode;
                    usrRow.DisplayOrder = wkInf.SetDispOrder;
                    usrRow.OfferKubun = 4;
                    usrRow.GoodsMakerCd = wkInf.SetSubMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.SetSubMakerCd);
                    usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    usrRow.GoodsNo = wkInf.SetSubPartsNo;
                    usrRow.GoodsNoNoneHyphen = wkInf.SetSubPartsNo.Replace("-", "");
                    usrRow.GoodsSpecialNote = wkInf.SetSpecialNote;
                    usrRow.OfferDate = wkInf.OfferDate;
                    usrRow.GoodsName = wkInf.SetName; // �Z�b�g����
                    usrRow.GoodsNameKana = GetKanaString(wkInf.SetName); // �Z�b�g����(���p�ϊ���ɃZ�b�g)
                    usrRow.GoodsOfrName = usrRow.GoodsName; // �Z�b�g����
                    usrRow.GoodsOfrNameKana = usrRow.GoodsNameKana; // �Z�b�g����
                    usrRow.SearchPartsFullName = wkInf.SearchPartsFullName; // �����i��
                    usrRow.SearchPartsHalfName = wkInf.SearchPartsHalfName;
                    if (wkInf.TbsPartsCdDerivedNo != 0)
                    {
                        string filter = string.Format("{0}={1} AND {2}={3}", ofrBLInfo.TbsPartsCodeColumn.ColumnName, wkInf.TbsPartsCode,
                                                                           ofrBLInfo.TbsPartsCdDerivedNoColumn.ColumnName, wkInf.TbsPartsCdDerivedNo);
                        BLInfoRow[] rows = (BLInfoRow[])ofrBLInfo.Select(filter);
                        if ((rows != null) && (rows.Length != 0))
                        {
                            usrRow.GoodsName = usrRow.GoodsName + rows[0].TbsPartsFullName;
                            usrRow.GoodsNameKana = usrRow.GoodsNameKana + rows[0].TbsPartsHalfName;
                            usrRow.GoodsOfrName = usrRow.GoodsOfrName + rows[0].TbsPartsFullName; // ���i��
                            usrRow.GoodsOfrNameKana = usrRow.GoodsOfrNameKana + rows[0].TbsPartsHalfName;
                            usrRow.SearchPartsFullName = usrRow.SearchPartsFullName + rows[0].TbsPartsFullName; // �����i��
                            usrRow.SearchPartsHalfName = usrRow.SearchPartsHalfName + rows[0].TbsPartsHalfName;
                        }
                    }
                    partsInfoDic[dicKey].UsrGoodsInfo.AddUsrGoodsInfoRow(usrRow);
                }
                if ((usrRow.GoodsKind & (int)GoodsKind.Set) != (int)GoodsKind.Set)
                    usrRow.GoodsKind += (int)GoodsKind.Set; // 1:�e�^2:�����^4:�Z�b�g�q�^8:��ց^16:��֌݊�
            }
            foreach (OfferJoinPriceRetWork wkSetPriceInf in priceList)
            {
                PartsInfoDataSet.UsrGoodsPriceRow row =
                    priceTableDic[dicKey].FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd, wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH);
                if (row == null)
                {
                    row = priceTableDic[dicKey].NewUsrGoodsPriceRow();
                    row.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                    row.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                    row.PriceStartDate = wkSetPriceInf.PriceStartDate;
                    row.ListPrice = wkSetPriceInf.NewPrice;
                    row.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;

                    PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                        partsInfoDic[dicKey].UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkSetPriceInf.PartsMakerCd, wkSetPriceInf.PrimePartsNoWithH);
                    if (usrRow != null)
                    {
                        row.UsrGoodsInfoRowParent = usrRow;
                        priceTableDic[dicKey].AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� ------------------------------------->>>>>
                row = null;
                row = ofrPriceTableDic[dicKey].FindByGoodsMakerCdPriceStartDateGoodsNo(wkSetPriceInf.PartsMakerCd, wkSetPriceInf.PriceStartDate, wkSetPriceInf.PrimePartsNoWithH);
                if (row == null)
                {
                    row = ofrPriceTableDic[dicKey].NewUsrGoodsPriceRow();
                    row.GoodsMakerCd = wkSetPriceInf.PartsMakerCd;
                    row.GoodsNo = wkSetPriceInf.PrimePartsNoWithH;
                    row.PriceStartDate = wkSetPriceInf.PriceStartDate;
                    row.ListPrice = wkSetPriceInf.NewPrice;
                    row.OpenPriceDiv = wkSetPriceInf.OpenPriceDiv;

                    PartsInfoDataSet.UsrGoodsInfoRow usrRow =
                        partsInfoDic[dicKey].UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(wkSetPriceInf.PartsMakerCd, wkSetPriceInf.PrimePartsNoWithH);
                    if (usrRow != null)
                    {
                        row.UsrGoodsInfoRowParent = usrRow;
                        ofrPriceTableDic[dicKey].AddUsrGoodsPriceRow(row);
                    }
                }
                // ADD 2015/03/18 SCM������ ���[�J�[��]�������i�Ή� -------------------------------------<<<<<
            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        # region ���[�U�[��������:��֏��ݒ�
        /// <summary>
        /// ���[�U�[��������:��֏��ݒ�
        /// </summary>
        /// <param name="list"></param>
        private void FillUsrSubstPartsTable(ArrayList list)
        {
            if (list == null)
            {
                return;
            }
            foreach (UsrPartsSubstRetWork wkInf in list)
            {
                PartsInfoDataSet.UsrSubstPartsRow row =
                    partsInfo.UsrSubstParts.FindByChgDestGoodsNoChgSrcGoodsNoChgSrcMakerCd(wkInf.SubstDestPartsNo,
                        wkInf.SubstSorPartsNo, wkInf.SubstSorMakerCd);
                if (row == null)
                {
                    row = partsInfo.UsrSubstParts.NewUsrSubstPartsRow();

                    row.ChgSrcMakerCd = wkInf.SubstSorMakerCd;
                    row.ChgSrcGoodsNo = wkInf.SubstSorPartsNo;
                    row.ChgDestMakerCd = wkInf.SubstDestMakerCd;
                    row.ChgDestGoodsNo = wkInf.SubstDestPartsNo;
                    row.ApplyStDate = wkInf.ApplyStDate;
                    row.ApplyEdDate = wkInf.ApplyEdDate;
                    row.OfferKubun = false; // false:���[�U�[��� true:�񋟑��[�f�t�H���g]

                    partsInfo.UsrSubstParts.AddUsrSubstPartsRow(row);
                }
            }
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ���[�U�[��������:��֏��ݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        private void FillUsrSubstPartsTable(ArrayList list, int key)
        {
            if (list == null)
            {
                return;
            }
            foreach (UsrPartsSubstRetWork wkInf in list)
            {
                PartsInfoDataSet.UsrSubstPartsRow row =
                    partsInfoDic[key].UsrSubstParts.FindByChgDestGoodsNoChgSrcGoodsNoChgSrcMakerCd(wkInf.SubstDestPartsNo,
                        wkInf.SubstSorPartsNo, wkInf.SubstSorMakerCd);
                if (row == null)
                {
                    row = partsInfoDic[key].UsrSubstParts.NewUsrSubstPartsRow();

                    row.ChgSrcMakerCd = wkInf.SubstSorMakerCd;
                    row.ChgSrcGoodsNo = wkInf.SubstSorPartsNo;
                    row.ChgDestMakerCd = wkInf.SubstDestMakerCd;
                    row.ChgDestGoodsNo = wkInf.SubstDestPartsNo;
                    row.ApplyStDate = wkInf.ApplyStDate;
                    row.ApplyEdDate = wkInf.ApplyEdDate;
                    row.OfferKubun = false; // false:���[�U�[��� true:�񋟑��[�f�t�H���g]

                    partsInfoDic[key].UsrSubstParts.AddUsrSubstPartsRow(row);
                }
            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        # region ���[�U�[��������:�������ݒ�
        /// <summary>
        /// ���[�U�[��������:�������ݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <br>UpdateNote : 2013/03/15�@dpp</br>
        /// <br>          �@ 10901273-00 5��15���z�M���i��Q�ȊO�j Redmine#34377 �i�Ԍ������ʕs��̏C��</br>
        private void FillUsrJoinPartsTable(ArrayList list)
        {
            if (list == null)
            {
                return;
            }
            foreach (UsrJoinPartsRetWork wkInf in list)
            {
                // 2009.02.19 >>>
                //PartsInfoDataSet.UsrJoinPartsRow row = partsInfo.UsrJoinParts.NewUsrJoinPartsRow();
                string filter = string.Format("{0}='{1}' AND {2}={3} AND {4} ='{5}' AND {6}={7}", 
                                partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName,
                                wkInf.JoinSourPartsNoWithH,
                                partsInfo.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName,
                                wkInf.JoinSourceMakerCode,
                                partsInfo.UsrJoinParts.JoinDestPartsNoColumn.ColumnName,
                                wkInf.JoinDestPartsNo,
                                partsInfo.UsrJoinParts.JoinDestMakerCdColumn.ColumnName,
                                wkInf.JoinDestMakerCd);
                PartsInfoDataSet.UsrJoinPartsRow[] rows = (PartsInfoDataSet.UsrJoinPartsRow[])partsInfo.UsrJoinParts.Select(filter);
                PartsInfoDataSet.UsrJoinPartsRow row;

                if (rows != null && rows.Length > 0)
                {
                    row = rows[0];
                    
                }
                else
                {
                    row = partsInfo.UsrJoinParts.NewUsrJoinPartsRow();
                    partsInfo.UsrJoinParts.AddUsrJoinPartsRow(row);
                }
                // 2009.02.19 <<<

                row.JoinDispOrder = wkInf.JoinDispOrder;
                row.JoinSourceMakerCode = wkInf.JoinSourceMakerCode;
                row.JoinSrcPartsNoWithH = wkInf.JoinSourPartsNoWithH;
                row.JoinSrcPartsNoNoneH = wkInf.JoinSourPartsNoNoneH;
                row.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                row.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                row.JoinQty = wkInf.JoinQty;
                row.JoinSpecialNote = wkInf.JoinSpecialNote;
                //row.JoinOfferDate = sourcedr.JoinOfferDate;  // �񋟌����͏C���s�̂��߁A�񋟓��͕s�v�ɂȂ����B

                // 2009/09/07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                PartsInfoDataSet.UsrGoodsInfoRow usrRow = goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                if (usrRow != null) // ���ɓo�^����Ă���ꍇ�i�񋟂���̐ݒ肪����ꍇ�j
                {
                }
                else
                {
                    usrRow = goodsTable.NewUsrGoodsInfoRow();
                    //usrRow.EnterpriseCode = wkInf.EnterpriseCode;
                    //usrRow.FileHeaderGuid = wkInf.FileHeaderGuid;
                    //usrRow.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    //usrRow.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    //usrRow.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    //usrRow.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    //usrRow.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    //usrRow.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    usrRow.GoodsMakerCd = wkInf.JoinDestMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                    usrRow.GoodsNo = wkInf.JoinDestPartsNo;
                    //usrRow.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo;// DEL dpp 2013/03/15 Redmine#34377
                    usrRow.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-","");// ADD dpp 2013/03/15 Redmine#34377
                    //usrRow.GoodsName = "*";
                    //usrRow.GoodsNameKana = "*";
                    //usrRow.GoodsOfrName = wkInf.GoodsName;
                    //usrRow.GoodsOfrNameKana = wkInf.GoodsNameKana;
                    //usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    //usrRow.BlGoodsCode = wkInf..BLGoodsCode;
                    usrRow.DisplayOrder = wkInf.JoinDispOrder;
                    //usrRow.GoodsNote1 = wkInf.GoodsNote1;
                    //usrRow.GoodsNote2 = wkInf.GoodsNote2;
                    usrRow.GoodsSpecialNote = wkInf.JoinSpecialNote;
                    //usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                    //usrRow.OfferDate = DateTime.Today;
                    usrRow.GoodsKindCode = 0;
                    //usrRow.Jan = wkInf.Jan;
                    //usrRow.UpdateDate = wkInf.UpdateDate;
                    //usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                    //usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                    //usrRow.OfferDataDiv = wkInf.OfferDataDiv;

                    if (usrRow.OfferDate != DateTime.MinValue || usrRow.OfferDataDiv == 1)
                        usrRow.OfferKubun = 1; // ���[�U�[�o�^�̑�ցE�Z�b�g�E�������i�̏ꍇ�񋟏������D�ǂ��s���I
                    else
                        usrRow.OfferKubun = 0; // ���[�U�[�o�^
                    goodsTable.AddUsrGoodsInfoRow(usrRow);
                } // ADD 2012/12/10 Y.Wakita
                    string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfo.UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                        partsInfo.UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd);
                    partsInfo.UsrJoinParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfo.UsrJoinParts.DefaultView.Count; i++)
                    {
                        partsInfo.UsrJoinParts.DefaultView[i][partsInfo.UsrJoinParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                    rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfo.UsrSetParts.SubGoodsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                        partsInfo.UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd);
                    partsInfo.UsrSetParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfo.UsrSetParts.DefaultView.Count; i++)
                    {
                        partsInfo.UsrSetParts.DefaultView[i][partsInfo.UsrSetParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                    //} // DEL 2012/12/10 Y.Wakita
                // 2009/09/07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                //partsInfo.UsrJoinParts.AddUsrJoinPartsRow(row);       // 2009.02.19 Del
            }
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ���[�U�[��������:�������ݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        private void FillUsrJoinPartsTable(ArrayList list, int key)
        {
            if (list == null)
            {
                return;
            }
            foreach (UsrJoinPartsRetWork wkInf in list)
            {
                string filter = string.Format("{0}='{1}' AND {2}={3} AND {4} ='{5}' AND {6}={7}",
                                partsInfoDic[key].UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName,
                                wkInf.JoinSourPartsNoWithH,
                                partsInfoDic[key].UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName,
                                wkInf.JoinSourceMakerCode,
                                partsInfoDic[key].UsrJoinParts.JoinDestPartsNoColumn.ColumnName,
                                wkInf.JoinDestPartsNo,
                                partsInfoDic[key].UsrJoinParts.JoinDestMakerCdColumn.ColumnName,
                                wkInf.JoinDestMakerCd);
                PartsInfoDataSet.UsrJoinPartsRow[] rows = (PartsInfoDataSet.UsrJoinPartsRow[])partsInfoDic[key].UsrJoinParts.Select(filter);
                PartsInfoDataSet.UsrJoinPartsRow row;

                if (rows != null && rows.Length > 0)
                {
                    row = rows[0];

                }
                else
                {
                    row = partsInfoDic[key].UsrJoinParts.NewUsrJoinPartsRow();
                    partsInfoDic[key].UsrJoinParts.AddUsrJoinPartsRow(row);
                }
                // 2009.02.19 <<<

                row.JoinDispOrder = wkInf.JoinDispOrder;
                row.JoinSourceMakerCode = wkInf.JoinSourceMakerCode;
                row.JoinSrcPartsNoWithH = wkInf.JoinSourPartsNoWithH;
                row.JoinSrcPartsNoNoneH = wkInf.JoinSourPartsNoNoneH;
                row.JoinDestMakerCd = wkInf.JoinDestMakerCd;
                row.JoinDestPartsNo = wkInf.JoinDestPartsNo;
                row.JoinQty = wkInf.JoinQty;
                row.JoinSpecialNote = wkInf.JoinSpecialNote;

                PartsInfoDataSet.UsrGoodsInfoRow usrRow = goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkInf.JoinDestMakerCd, wkInf.JoinDestPartsNo);
                if (usrRow != null) // ���ɓo�^����Ă���ꍇ�i�񋟂���̐ݒ肪����ꍇ�j
                {
                }
                else
                {
                    usrRow = goodsTableDic[key].NewUsrGoodsInfoRow();

                    usrRow.GoodsMakerCd = wkInf.JoinDestMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.JoinDestMakerCd);
                    usrRow.GoodsNo = wkInf.JoinDestPartsNo;
                    usrRow.GoodsNoNoneHyphen = wkInf.JoinDestPartsNo.Replace("-", "");
                    //usrRow.GoodsName = "*";
                    //usrRow.GoodsNameKana = "*";
                    //usrRow.GoodsOfrName = wkInf.GoodsName;
                    //usrRow.GoodsOfrNameKana = wkInf.GoodsNameKana;
                    //usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    //usrRow.BlGoodsCode = wkInf..BLGoodsCode;
                    usrRow.DisplayOrder = wkInf.JoinDispOrder;
                    //usrRow.GoodsNote1 = wkInf.GoodsNote1;
                    //usrRow.GoodsNote2 = wkInf.GoodsNote2;
                    usrRow.GoodsSpecialNote = wkInf.JoinSpecialNote;
                    //usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                    //usrRow.OfferDate = DateTime.Today;
                    usrRow.GoodsKindCode = 0;
                    //usrRow.Jan = wkInf.Jan;
                    //usrRow.UpdateDate = wkInf.UpdateDate;
                    //usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                    //usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                    //usrRow.OfferDataDiv = wkInf.OfferDataDiv;

                    if (usrRow.OfferDate != DateTime.MinValue || usrRow.OfferDataDiv == 1)
                        usrRow.OfferKubun = 1; // ���[�U�[�o�^�̑�ցE�Z�b�g�E�������i�̏ꍇ�񋟏������D�ǂ��s���I
                    else
                        usrRow.OfferKubun = 0; // ���[�U�[�o�^
                    goodsTableDic[key].AddUsrGoodsInfoRow(usrRow);
                } // ADD 2012/12/10 Y.Wakita
                string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                    partsInfoDic[key].UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                    partsInfoDic[key].UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd);
                partsInfoDic[key].UsrJoinParts.DefaultView.RowFilter = rowFilter;
                for (int i = 0; i < partsInfoDic[key].UsrJoinParts.DefaultView.Count; i++)
                {
                    partsInfoDic[key].UsrJoinParts.DefaultView[i][partsInfoDic[key].UsrJoinParts.PrmSettingFlgColumn.ColumnName] = true;
                }
                rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                    partsInfoDic[key].UsrSetParts.SubGoodsNoColumn.ColumnName, wkInf.JoinDestPartsNo,
                    partsInfoDic[key].UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkInf.JoinDestMakerCd);
                partsInfoDic[key].UsrSetParts.DefaultView.RowFilter = rowFilter;
                for (int i = 0; i < partsInfoDic[key].UsrSetParts.DefaultView.Count; i++)
                {
                    partsInfoDic[key].UsrSetParts.DefaultView[i][partsInfoDic[key].UsrSetParts.PrmSettingFlgColumn.ColumnName] = true;
                }
            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        internal DateTime GetDateTimeFromInt(int time)
        {
            if (time == 0)
                return DateTime.MinValue;
            int year = time / 10000;
            int month = (time / 100) - (year * 100);
            int day = time % 100;
            if (day == 0) // �f�[�^���΂����A�N�����̓���0�̏ꍇ������̂ŁA�G���[��h������
                day = 1;
            return new DateTime(year, month, day);
        }

        # region ���[�U�[��������:���i���ݒ�
        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
        ///// <summary>
        ///// ���[�U�[��������:���i���ݒ�
        ///// </summary>
        ///// <param name="list"></param>
        //private void FillUsrGoodsInfoTable(ArrayList list)
        /// <summary>
        /// ���[�U�[��������:���i���ݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <param name="inPara"></param>
        private void FillUsrGoodsInfoTable( ArrayList list, GetPartsInfPara inPara )
        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
        {
            if (list == null)
            {
                return;
            }
            foreach (UsrGoodsRetWork wkInf in list)
            {
                // --- ADD m.suzuki 2011/05/18 ---------->>>>>
                // BL�R�[�h�}�ԑΉ�(��BL�R�[�h�������̂�)
                if ( inPara != null && inPara.TbsPartsCode != 0 && inPara.TbsPartsCdDerivedNo != 0 )
                {
                    try
                    {
                        // �}�Ԗ��̓K�p�ς݃t���O
                        bool reflectDerivedNmFlag = false;

                        # region [��������BL�R�[�h�}�Ԗ��̂�K�p]
                        // ���[�U�[�����}�X�^���R�[�h��T��
                        DataRow[] joinRows = partsInfo.UsrJoinParts.Select(
                                string.Format( "{0}='{1}' AND {2}='{3}'",
                                    partsInfo.UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.GoodsNo,
                                    partsInfo.UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.GoodsMakerCd ) );

                        if ( joinRows != null && joinRows.Length > 0 )
                        {
                            # region [�������̕��i���R�[�h��T��]
                            // ���������i���R�[�h��T��
                            int joinSourceMakerCode = (int)joinRows[0][partsInfo.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName];
                            string joinSrcPartsNoWithH = (string)joinRows[0][partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName];
                            PartsInfoDataSet.PartsInfoRow joinSourceRow = partsInfo.PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen( joinSourceMakerCode, joinSrcPartsNoWithH );

                            // �ŐV�i�Ԃōēx��������T��
                            if ( joinSourceRow == null )
                            {
                                DataRow[] newJoinSourceRows =
                                    partsInfo.PartsInfo.Select(
                                        string.Format( "{0}='{1}' AND {2}='{3}'",
                                            partsInfo.PartsInfo.NewPrtsNoWithHyphenColumn.ColumnName, joinSrcPartsNoWithH,
                                            partsInfo.PartsInfo.CatalogPartsMakerCdColumn.ColumnName, joinSourceMakerCode ) );

                                if ( newJoinSourceRows != null && newJoinSourceRows.Length > 0 )
                                {
                                    joinSourceRow = (PartsInfoDataSet.PartsInfoRow)newJoinSourceRows[0];
                                }
                            }
                            # endregion

                            if ( joinSourceRow != null )
                            {
                                // ���������R�[�h��BL�R�[�h�}�Ԗ��̂�t�^����B
                                if ( !string.IsNullOrEmpty( wkInf.GoodsName ) ) wkInf.GoodsName = wkInf.GoodsName + joinSourceRow.TbsPartsCdDerivedNm;
                                if ( !string.IsNullOrEmpty( wkInf.GoodsNameKana ) ) wkInf.GoodsNameKana = wkInf.GoodsNameKana + joinSourceRow.TbsPartsCdDerivedNm;
                                reflectDerivedNmFlag = true;
                            }
                        }
                        # endregion

                        # region [��֌���BL�R�[�h�}�Ԗ��̂�K�p]
                        if ( !reflectDerivedNmFlag )
                        {
                            // ���[�U�[��փ}�X�^���R�[�h��T��
                            DataRow[] substRows = partsInfo.UsrSubstParts.Select(
                                    string.Format( "{0}='{1}' AND {2}='{3}'",
                                        partsInfo.UsrSubstParts.ChgDestGoodsNoColumn.ColumnName, wkInf.GoodsNo,
                                        partsInfo.UsrSubstParts.ChgDestMakerCdColumn.ColumnName, wkInf.GoodsMakerCd ) );

                            if ( substRows != null && substRows.Length > 0 )
                            {
                                # region [��֌��̕��i���R�[�h��T��]
                                // ��֌����i���R�[�h��T��
                                int chgSrcMakerCd = (int)substRows[0][partsInfo.UsrSubstParts.ChgSrcMakerCdColumn.ColumnName];
                                string chgSrcGoodsNo = (string)substRows[0][partsInfo.UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName];
                                PartsInfoDataSet.PartsInfoRow substSourceRow = partsInfo.PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen( chgSrcMakerCd, chgSrcGoodsNo );

                                // �ŐV�i�Ԃōēx��֌���T��
                                if ( substSourceRow == null )
                                {
                                    DataRow[] newSubstSourceRows =
                                        partsInfo.PartsInfo.Select(
                                            string.Format( "{0}='{1}' AND {2}='{3}'",
                                                partsInfo.PartsInfo.NewPrtsNoWithHyphenColumn.ColumnName, chgSrcGoodsNo,
                                                partsInfo.PartsInfo.CatalogPartsMakerCdColumn.ColumnName, chgSrcMakerCd ) );

                                    if ( newSubstSourceRows != null && newSubstSourceRows.Length > 0 )
                                    {
                                        substSourceRow = (PartsInfoDataSet.PartsInfoRow)newSubstSourceRows[0];
                                    }
                                }
                                # endregion

                                if ( substSourceRow != null )
                                {
                                    // ���������R�[�h��BL�R�[�h�}�Ԗ��̂�t�^����B
                                    if ( !string.IsNullOrEmpty( wkInf.GoodsName ) ) wkInf.GoodsName = wkInf.GoodsName + substSourceRow.TbsPartsCdDerivedNm;
                                    if ( !string.IsNullOrEmpty( wkInf.GoodsNameKana ) ) wkInf.GoodsNameKana = wkInf.GoodsNameKana + substSourceRow.TbsPartsCdDerivedNm;
                                    reflectDerivedNmFlag = true;
                                }
                            }
                        }
                        # endregion
                    }
                    catch
                    {
                    }
                }
                // --- ADD m.suzuki 2011/05/18 ----------<<<<<

                PartsInfoDataSet.UsrGoodsInfoRow usrRow = goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.GoodsMakerCd, wkInf.GoodsNo);
                if (usrRow != null) // ���ɓo�^����Ă���ꍇ�i�񋟂���̐ݒ肪����ꍇ�j
                {
                    //usrRow.GoodsKind += (int)GoodsKind.Parent;
                    usrRow.EnterpriseCode = wkInf.EnterpriseCode;
                    usrRow.FileHeaderGuid = wkInf.FileHeaderGuid;
                    usrRow.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    usrRow.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    usrRow.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    usrRow.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    usrRow.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    usrRow.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    // --- UPD m.suzuki 2010/07/14 ---------->>>>>
                    //usrRow.GoodsName = wkInf.GoodsName;
                    //usrRow.GoodsNameKana = wkInf.GoodsNameKana;
                    if ( usrRow.GoodsKind == (int)GoodsKind.Set )
                    {
                        // �Z�b�g�q�i�ԂȂ�΁A���������Ȃ� (���ɃZ�b�g�i����ݒ肵�Ă����)
                    }
                    else
                    {
                        usrRow.GoodsName = wkInf.GoodsName;
                        usrRow.GoodsNameKana = wkInf.GoodsNameKana;
                    }
                    // --- UPD m.suzuki 2010/07/14 ----------<<<<<
                    usrRow.GoodsNote1 = wkInf.GoodsNote1;
                    usrRow.GoodsNote2 = wkInf.GoodsNote2;
                    usrRow.DisplayOrder = wkInf.DisplayOrder;
                    usrRow.GoodsSpecialNote = wkInf.GoodsSpecialNote;
                    if (usrRow.OfferKubun == 3)
                    {
                        usrRow.OfferKubun = 1; // �񋟏����ҏW
                    }
                    else if (usrRow.OfferKubun == 4)
                    {
                        usrRow.OfferKubun = 2; // �񋟗D�ǕҏW
                    }
                    // 2009/10/06 Add >>>
                    // ���[�U�[�����������\�ȏ��̓Z�b�g����
                    usrRow.GoodsMGroup = wkInf.GoodsMGroup;         
                    usrRow.BlGoodsCode = wkInf.BLGoodsCode;         
                    usrRow.GoodsKindCode = wkInf.GoodsKindCode;
                    usrRow.Jan = wkInf.Jan;
                    usrRow.UpdateDate = wkInf.UpdateDate;
                    usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                    usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                    // 2009/10/06 Add <<<
                    usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                    usrRow.OfferDataDiv = wkInf.OfferDataDiv; // TODO : �����ŌŒ�l1��ݒ肷��Ɩ�����̃f�[�^�s����h�����Ƃ��\�B
                }
                else
                {
                    usrRow = goodsTable.NewUsrGoodsInfoRow();
                    usrRow.EnterpriseCode = wkInf.EnterpriseCode;
                    usrRow.FileHeaderGuid = wkInf.FileHeaderGuid;
                    usrRow.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    usrRow.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    usrRow.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    usrRow.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    usrRow.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    usrRow.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    usrRow.GoodsMakerCd = wkInf.GoodsMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.GoodsMakerCd);
                    usrRow.GoodsNo = wkInf.GoodsNo;
                    usrRow.GoodsNoNoneHyphen = wkInf.GoodsNoNoneHyphen;
                    usrRow.GoodsName = wkInf.GoodsName;
                    usrRow.GoodsNameKana = wkInf.GoodsNameKana;
                    //usrRow.GoodsOfrName = wkInf.GoodsName;
                    //usrRow.GoodsOfrNameKana = wkInf.GoodsNameKana;
                    usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    usrRow.BlGoodsCode = wkInf.BLGoodsCode;
                    usrRow.DisplayOrder = wkInf.DisplayOrder;
                    usrRow.GoodsNote1 = wkInf.GoodsNote1;
                    usrRow.GoodsNote2 = wkInf.GoodsNote2;
                    usrRow.GoodsSpecialNote = wkInf.GoodsSpecialNote;
                    usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                    usrRow.OfferDate = GetDateTimeFromInt(wkInf.OfferDate);
                    usrRow.GoodsKindCode = wkInf.GoodsKindCode;
                    usrRow.Jan = wkInf.Jan;
                    usrRow.UpdateDate = wkInf.UpdateDate;
                    usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                    usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                    usrRow.OfferDataDiv = wkInf.OfferDataDiv;

                    // 2010/02/25 >>>
                    //if (usrRow.OfferDate != DateTime.MinValue || usrRow.OfferDataDiv == 1)
                    //    usrRow.OfferKubun = 1; // ���[�U�[�o�^�̑�ցE�Z�b�g�E�������i�̏ꍇ�񋟏������D�ǂ��s���I
                    //else
                    //    usrRow.OfferKubun = 0; // ���[�U�[�o�^

                    if (usrRow.OfferDate != DateTime.MinValue || usrRow.OfferDataDiv == 1)
                    {
                        if (wkInf.GoodsKindCode == 0)
                        {
                            usrRow.OfferKubun = 1; // ���[�U�[�o�^�̑�ցE�Z�b�g�E�������i�̏ꍇ�񋟏������D�ǂ��s���I
                        }
                        else
                        {
                            usrRow.OfferKubun = 2; // ���[�U�[�o�^�̑�ցE�Z�b�g�E�������i�̏ꍇ�񋟏������D�ǂ��s���I
                        }
                    }
                    else
                    {
                        usrRow.OfferKubun = 0; // ���[�U�[�o�^
                    }
                    // 2010/02/25 <<<

                    //row.GoodsKind = (int)GoodsKind.Parent;
                    goodsTable.AddUsrGoodsInfoRow(usrRow);

                    string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfo.UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.GoodsNo,
                        partsInfo.UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.GoodsMakerCd);
                    partsInfo.UsrJoinParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfo.UsrJoinParts.DefaultView.Count; i++)
                    {
                        partsInfo.UsrJoinParts.DefaultView[i][partsInfo.UsrJoinParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                    //PartsInfoDataSet.UsrJoinPartsRow[] rowJoins =
                    //    (PartsInfoDataSet.UsrJoinPartsRow[])partsInfo.UsrJoinParts.Select(rowFilter);
                    //for (int i = 0; i < rowJoins.Length; i++)
                    //{
                    //    rowJoins[i].PrmSettingFlg = true;
                    //}
                    rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfo.UsrSetParts.SubGoodsNoColumn.ColumnName, wkInf.GoodsNo,
                        partsInfo.UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkInf.GoodsMakerCd);
                    partsInfo.UsrSetParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfo.UsrSetParts.DefaultView.Count; i++)
                    {
                        partsInfo.UsrSetParts.DefaultView[i][partsInfo.UsrSetParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                    //PartsInfoDataSet.UsrSetPartsRow[] rowSets =
                    //    (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetPartsRow.Select(rowFilter);
                    //for (int i = 0; i < rowSets.Length; i++)
                    //{
                    //    rowSets[i].PrmSettingFlg = true;
                    //}
                }
            }
            partsInfo.UsrJoinParts.DefaultView.RowFilter = string.Empty;
            partsInfo.UsrSetParts.DefaultView.RowFilter = string.Empty;
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ���[�U�[��������:���i���ݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <param name="inPara"></param>
        /// <param name="key"></param>
        private void FillUsrGoodsInfoTable(ArrayList list, GetPartsInfPara inPara, int key)
        {
            if (list == null)
            {
                return;
            }
            foreach (UsrGoodsRetWork wkInf in list)
            {
                // BL�R�[�h�}�ԑΉ�(��BL�R�[�h�������̂�)
                if (inPara != null && inPara.TbsPartsCode != 0 && inPara.TbsPartsCdDerivedNo != 0)
                {
                    try
                    {
                        // �}�Ԗ��̓K�p�ς݃t���O
                        bool reflectDerivedNmFlag = false;

                        # region [��������BL�R�[�h�}�Ԗ��̂�K�p]
                        // ���[�U�[�����}�X�^���R�[�h��T��
                        DataRow[] joinRows = partsInfoDic[key].UsrJoinParts.Select(
                                string.Format("{0}='{1}' AND {2}='{3}'",
                                    partsInfoDic[key].UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.GoodsNo,
                                    partsInfoDic[key].UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.GoodsMakerCd));

                        if (joinRows != null && joinRows.Length > 0)
                        {
                            # region [�������̕��i���R�[�h��T��]
                            // ���������i���R�[�h��T��
                            int joinSourceMakerCode = (int)joinRows[0][partsInfoDic[key].UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName];
                            string joinSrcPartsNoWithH = (string)joinRows[0][partsInfoDic[key].UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName];
                            PartsInfoDataSet.PartsInfoRow joinSourceRow = partsInfoDic[key].PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(joinSourceMakerCode, joinSrcPartsNoWithH);

                            // �ŐV�i�Ԃōēx��������T��
                            if (joinSourceRow == null)
                            {
                                DataRow[] newJoinSourceRows =
                                    partsInfoDic[key].PartsInfo.Select(
                                        string.Format("{0}='{1}' AND {2}='{3}'",
                                            partsInfoDic[key].PartsInfo.NewPrtsNoWithHyphenColumn.ColumnName, joinSrcPartsNoWithH,
                                            partsInfoDic[key].PartsInfo.CatalogPartsMakerCdColumn.ColumnName, joinSourceMakerCode));

                                if (newJoinSourceRows != null && newJoinSourceRows.Length > 0)
                                {
                                    joinSourceRow = (PartsInfoDataSet.PartsInfoRow)newJoinSourceRows[0];
                                }
                            }
                            # endregion

                            if (joinSourceRow != null)
                            {
                                // ���������R�[�h��BL�R�[�h�}�Ԗ��̂�t�^����B
                                if (!string.IsNullOrEmpty(wkInf.GoodsName)) wkInf.GoodsName = wkInf.GoodsName + joinSourceRow.TbsPartsCdDerivedNm;
                                if (!string.IsNullOrEmpty(wkInf.GoodsNameKana)) wkInf.GoodsNameKana = wkInf.GoodsNameKana + joinSourceRow.TbsPartsCdDerivedNm;
                                reflectDerivedNmFlag = true;
                            }
                        }
                        # endregion

                        # region [��֌���BL�R�[�h�}�Ԗ��̂�K�p]
                        if (!reflectDerivedNmFlag)
                        {
                            // ���[�U�[��փ}�X�^���R�[�h��T��
                            DataRow[] substRows = partsInfoDic[key].UsrSubstParts.Select(
                                    string.Format("{0}='{1}' AND {2}='{3}'",
                                        partsInfoDic[key].UsrSubstParts.ChgDestGoodsNoColumn.ColumnName, wkInf.GoodsNo,
                                        partsInfoDic[key].UsrSubstParts.ChgDestMakerCdColumn.ColumnName, wkInf.GoodsMakerCd));

                            if (substRows != null && substRows.Length > 0)
                            {
                                # region [��֌��̕��i���R�[�h��T��]
                                // ��֌����i���R�[�h��T��
                                int chgSrcMakerCd = (int)substRows[0][partsInfoDic[key].UsrSubstParts.ChgSrcMakerCdColumn.ColumnName];
                                string chgSrcGoodsNo = (string)substRows[0][partsInfoDic[key].UsrSubstParts.ChgSrcGoodsNoColumn.ColumnName];
                                PartsInfoDataSet.PartsInfoRow substSourceRow = partsInfoDic[key].PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(chgSrcMakerCd, chgSrcGoodsNo);

                                // �ŐV�i�Ԃōēx��֌���T��
                                if (substSourceRow == null)
                                {
                                    DataRow[] newSubstSourceRows =
                                        partsInfoDic[key].PartsInfo.Select(
                                            string.Format("{0}='{1}' AND {2}='{3}'",
                                                partsInfoDic[key].PartsInfo.NewPrtsNoWithHyphenColumn.ColumnName, chgSrcGoodsNo,
                                                partsInfoDic[key].PartsInfo.CatalogPartsMakerCdColumn.ColumnName, chgSrcMakerCd));

                                    if (newSubstSourceRows != null && newSubstSourceRows.Length > 0)
                                    {
                                        substSourceRow = (PartsInfoDataSet.PartsInfoRow)newSubstSourceRows[0];
                                    }
                                }
                                # endregion

                                if (substSourceRow != null)
                                {
                                    // ���������R�[�h��BL�R�[�h�}�Ԗ��̂�t�^����B
                                    if (!string.IsNullOrEmpty(wkInf.GoodsName)) wkInf.GoodsName = wkInf.GoodsName + substSourceRow.TbsPartsCdDerivedNm;
                                    if (!string.IsNullOrEmpty(wkInf.GoodsNameKana)) wkInf.GoodsNameKana = wkInf.GoodsNameKana + substSourceRow.TbsPartsCdDerivedNm;
                                    reflectDerivedNmFlag = true;
                                }
                            }
                        }
                        # endregion
                    }
                    catch
                    {
                    }
                }

                PartsInfoDataSet.UsrGoodsInfoRow usrRow = goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkInf.GoodsMakerCd, wkInf.GoodsNo);
                if (usrRow != null) // ���ɓo�^����Ă���ꍇ�i�񋟂���̐ݒ肪����ꍇ�j
                {
                    //usrRow.GoodsKind += (int)GoodsKind.Parent;
                    usrRow.EnterpriseCode = wkInf.EnterpriseCode;
                    usrRow.FileHeaderGuid = wkInf.FileHeaderGuid;
                    usrRow.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    usrRow.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    usrRow.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    usrRow.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    usrRow.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    usrRow.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    if (usrRow.GoodsKind == (int)GoodsKind.Set)
                    {
                        // �Z�b�g�q�i�ԂȂ�΁A���������Ȃ� (���ɃZ�b�g�i����ݒ肵�Ă����)
                    }
                    else
                    {
                        usrRow.GoodsName = wkInf.GoodsName;
                        usrRow.GoodsNameKana = wkInf.GoodsNameKana;
                    }
                    usrRow.GoodsNote1 = wkInf.GoodsNote1;
                    usrRow.GoodsNote2 = wkInf.GoodsNote2;
                    usrRow.DisplayOrder = wkInf.DisplayOrder;
                    usrRow.GoodsSpecialNote = wkInf.GoodsSpecialNote;
                    if (usrRow.OfferKubun == 3)
                    {
                        usrRow.OfferKubun = 1; // �񋟏����ҏW
                    }
                    else if (usrRow.OfferKubun == 4)
                    {
                        usrRow.OfferKubun = 2; // �񋟗D�ǕҏW
                    }
                    // ���[�U�[�����������\�ȏ��̓Z�b�g����
                    usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    usrRow.BlGoodsCode = wkInf.BLGoodsCode;
                    usrRow.GoodsKindCode = wkInf.GoodsKindCode;
                    usrRow.Jan = wkInf.Jan;
                    usrRow.UpdateDate = wkInf.UpdateDate;
                    usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                    usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                    usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                    usrRow.OfferDataDiv = wkInf.OfferDataDiv; // TODO : �����ŌŒ�l1��ݒ肷��Ɩ�����̃f�[�^�s����h�����Ƃ��\�B
                }
                else
                {
                    usrRow = goodsTableDic[key].NewUsrGoodsInfoRow();
                    usrRow.EnterpriseCode = wkInf.EnterpriseCode;
                    usrRow.FileHeaderGuid = wkInf.FileHeaderGuid;
                    usrRow.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    usrRow.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    usrRow.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    usrRow.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    usrRow.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    usrRow.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    usrRow.GoodsMakerCd = wkInf.GoodsMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.GoodsMakerCd);
                    usrRow.GoodsNo = wkInf.GoodsNo;
                    usrRow.GoodsNoNoneHyphen = wkInf.GoodsNoNoneHyphen;
                    usrRow.GoodsName = wkInf.GoodsName;
                    usrRow.GoodsNameKana = wkInf.GoodsNameKana;
                    //usrRow.GoodsOfrName = wkInf.GoodsName;
                    //usrRow.GoodsOfrNameKana = wkInf.GoodsNameKana;
                    usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    usrRow.BlGoodsCode = wkInf.BLGoodsCode;
                    usrRow.DisplayOrder = wkInf.DisplayOrder;
                    usrRow.GoodsNote1 = wkInf.GoodsNote1;
                    usrRow.GoodsNote2 = wkInf.GoodsNote2;
                    usrRow.GoodsSpecialNote = wkInf.GoodsSpecialNote;
                    usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                    usrRow.OfferDate = GetDateTimeFromInt(wkInf.OfferDate);
                    usrRow.GoodsKindCode = wkInf.GoodsKindCode;
                    usrRow.Jan = wkInf.Jan;
                    usrRow.UpdateDate = wkInf.UpdateDate;
                    usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                    usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                    usrRow.OfferDataDiv = wkInf.OfferDataDiv;

                    if (usrRow.OfferDate != DateTime.MinValue || usrRow.OfferDataDiv == 1)
                    {
                        if (wkInf.GoodsKindCode == 0)
                        {
                            usrRow.OfferKubun = 1; // ���[�U�[�o�^�̑�ցE�Z�b�g�E�������i�̏ꍇ�񋟏������D�ǂ��s���I
                        }
                        else
                        {
                            usrRow.OfferKubun = 2; // ���[�U�[�o�^�̑�ցE�Z�b�g�E�������i�̏ꍇ�񋟏������D�ǂ��s���I
                        }
                    }
                    else
                    {
                        usrRow.OfferKubun = 0; // ���[�U�[�o�^
                    }
                    goodsTableDic[key].AddUsrGoodsInfoRow(usrRow);

                    string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfoDic[key].UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.GoodsNo,
                        partsInfoDic[key].UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.GoodsMakerCd);
                    partsInfoDic[key].UsrJoinParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfoDic[key].UsrJoinParts.DefaultView.Count; i++)
                    {
                        partsInfoDic[key].UsrJoinParts.DefaultView[i][partsInfoDic[key].UsrJoinParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                    rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfoDic[key].UsrSetParts.SubGoodsNoColumn.ColumnName, wkInf.GoodsNo,
                        partsInfoDic[key].UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkInf.GoodsMakerCd);
                    partsInfoDic[key].UsrSetParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfoDic[key].UsrSetParts.DefaultView.Count; i++)
                    {
                        partsInfoDic[key].UsrSetParts.DefaultView[i][partsInfoDic[key].UsrSetParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                }
            }
            partsInfoDic[key].UsrJoinParts.DefaultView.RowFilter = string.Empty;
            partsInfoDic[key].UsrSetParts.DefaultView.RowFilter = string.Empty;
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        private void FillUsrGoodsPriceTable(ArrayList list)
        {
            if (list == null)
            {
                return;
            }
            foreach (GoodsPriceUWork wkInf in list)
            {
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/06/16 ADD
                // �񋟃f�[�^�������ʂ�����΍폜����B�i��ƃR�[�h=��, ���[�J�[�E�i�Ԃ���v�j
                DataRow[] deleteRows = priceTable.Select(string.Format("EnterpriseCode = '{0}' AND GoodsMakerCd = '{1}' AND GoodsNo = '{2}'",
                                                                  string.Empty,
                                                                  wkInf.GoodsMakerCd,
                                                                  wkInf.GoodsNo));
                foreach (DataRow deleteRow in deleteRows)
                {
                    priceTable.Rows.Remove(deleteRow);
                }
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/06/16 ADD

                PartsInfoDataSet.UsrGoodsPriceRow row =
                    priceTable.FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.GoodsMakerCd, wkInf.PriceStartDate, wkInf.GoodsNo);
                if (row == null)
                {
                    row = priceTable.NewUsrGoodsPriceRow();

                    row.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    row.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    row.EnterpriseCode = wkInf.EnterpriseCode;
                    row.FileHeaderGuid = wkInf.FileHeaderGuid;
                    row.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    row.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    row.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    row.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    row.GoodsMakerCd = wkInf.GoodsMakerCd;
                    row.GoodsNo = wkInf.GoodsNo;
                    row.ListPrice = wkInf.ListPrice;
                    row.OpenPriceDiv = wkInf.OpenPriceDiv;
                    row.PriceStartDate = wkInf.PriceStartDate;
                    row.SalesUnitCost = wkInf.SalesUnitCost;
                    row.StockRate = wkInf.StockRate;
                    row.OfferDate = wkInf.OfferDate;
                    row.UpdateDate = wkInf.UpdateDate;

                    PartsInfoDataSet.UsrGoodsInfoRow parentRow =
                        goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.GoodsMakerCd, wkInf.GoodsNo);
                    if (parentRow != null)
                    {
                        row.UsrGoodsInfoRowParent = parentRow;
                        priceTable.AddUsrGoodsPriceRow(row);
                    }
                }
                else
                {
                    row.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    row.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    row.EnterpriseCode = wkInf.EnterpriseCode;
                    row.FileHeaderGuid = wkInf.FileHeaderGuid;
                    row.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    row.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    row.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    row.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    row.ListPrice = wkInf.ListPrice;
                    row.OpenPriceDiv = wkInf.OpenPriceDiv;
                    row.SalesUnitCost = wkInf.SalesUnitCost;
                    row.StockRate = wkInf.StockRate;
                }
            }
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        ///  ���[�U�[���i���i�ݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        private void FillUsrGoodsPriceTable(ArrayList list, int key)
        {
            if (list == null)
            {
                return;
            }
            foreach (GoodsPriceUWork wkInf in list)
            {
                // �񋟃f�[�^�������ʂ�����΍폜����B�i��ƃR�[�h=��, ���[�J�[�E�i�Ԃ���v�j
                DataRow[] deleteRows = priceTableDic[key].Select(string.Format("EnterpriseCode = '{0}' AND GoodsMakerCd = '{1}' AND GoodsNo = '{2}'",
                                                                  string.Empty,
                                                                  wkInf.GoodsMakerCd,
                                                                  wkInf.GoodsNo));
                foreach (DataRow deleteRow in deleteRows)
                {
                    priceTableDic[key].Rows.Remove(deleteRow);
                }

                PartsInfoDataSet.UsrGoodsPriceRow row =
                    priceTableDic[key].FindByGoodsMakerCdPriceStartDateGoodsNo(wkInf.GoodsMakerCd, wkInf.PriceStartDate, wkInf.GoodsNo);
                if (row == null)
                {
                    row = priceTableDic[key].NewUsrGoodsPriceRow();

                    row.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    row.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    row.EnterpriseCode = wkInf.EnterpriseCode;
                    row.FileHeaderGuid = wkInf.FileHeaderGuid;
                    row.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    row.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    row.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    row.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    row.GoodsMakerCd = wkInf.GoodsMakerCd;
                    row.GoodsNo = wkInf.GoodsNo;
                    row.ListPrice = wkInf.ListPrice;
                    row.OpenPriceDiv = wkInf.OpenPriceDiv;
                    row.PriceStartDate = wkInf.PriceStartDate;
                    row.SalesUnitCost = wkInf.SalesUnitCost;
                    row.StockRate = wkInf.StockRate;
                    row.OfferDate = wkInf.OfferDate;
                    row.UpdateDate = wkInf.UpdateDate;

                    PartsInfoDataSet.UsrGoodsInfoRow parentRow =
                        goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkInf.GoodsMakerCd, wkInf.GoodsNo);
                    if (parentRow != null)
                    {
                        row.UsrGoodsInfoRowParent = parentRow;
                        priceTableDic[key].AddUsrGoodsPriceRow(row);
                    }
                }
                else
                {
                    row.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    row.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    row.EnterpriseCode = wkInf.EnterpriseCode;
                    row.FileHeaderGuid = wkInf.FileHeaderGuid;
                    row.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    row.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    row.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    row.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    row.ListPrice = wkInf.ListPrice;
                    row.OpenPriceDiv = wkInf.OpenPriceDiv;
                    row.SalesUnitCost = wkInf.SalesUnitCost;
                    row.StockRate = wkInf.StockRate;
                }
            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<


        private void FillUsrGoodsStockTable(ArrayList list)
        {
            if (list == null)
                return;
            foreach (StockWork stock in list)
            {
                PartsInfoDataSet.StockRow row =
                    stockTable.FindByWarehouseCodeGoodsNoGoodsMakerCd(stock.WarehouseCode, stock.GoodsNo, stock.GoodsMakerCd);
                if (row == null)
                {
                    row = stockTable.NewStockRow();

                    row.EnterpriseCode = stock.EnterpriseCode;
                    row.AcpOdrCount = stock.AcpOdrCount;
                    row.ArrivalCnt = stock.ArrivalCnt;
                    row.CreateDateTime = stock.CreateDateTime;
                    row.DuplicationShelfNo1 = stock.DuplicationShelfNo1;
                    row.DuplicationShelfNo2 = stock.DuplicationShelfNo2;
                    row.FileHeaderGuid = stock.FileHeaderGuid;
                    row.GoodsMakerCd = stock.GoodsMakerCd;
                    row.GoodsNo = stock.GoodsNo;
                    row.GoodsNoNoneHyphen = stock.GoodsNoNoneHyphen;
                    row.LastInventoryUpdate = stock.LastInventoryUpdate;
                    row.LastSalesDate = stock.LastSalesDate;
                    row.LastStockDate = stock.LastStockDate;
                    row.LogicalDeleteCode = stock.LogicalDeleteCode;
                    row.MaximumStockCnt = stock.MaximumStockCnt;
                    row.MinimumStockCnt = stock.MinimumStockCnt;
                    row.MonthOrderCount = stock.MonthOrderCount;
                    row.MovingSupliStock = stock.MovingSupliStock;
                    row.NmlSalOdrCount = stock.NmlSalOdrCount;
                    row.PartsManagementDivide1 = stock.PartsManagementDivide1;
                    row.PartsManagementDivide2 = stock.PartsManagementDivide2;
                    row.SalesOrderCount = stock.SalesOrderCount;
                    row.SalesOrderUnit = stock.SalesOrderUnit;
                    row.SectionCode = stock.SectionCode;
                    row.SectionGuideNm = stock.SectionGuideNm;
                    row.ShipmentCnt = stock.ShipmentCnt;
                    row.ShipmentPosCnt = stock.ShipmentPosCnt;
                    row.StockCreateDate = stock.StockCreateDate;
                    row.StockDiv = stock.StockDiv;
                    row.StockNote1 = stock.StockNote1;
                    row.StockNote2 = stock.StockNote2;
                    row.StockSupplierCode = stock.StockSupplierCode;
                    row.StockTotalPrice = stock.StockTotalPrice;
                    row.StockUnitPriceFl = stock.StockUnitPriceFl;
                    row.SupplierStock = stock.SupplierStock;
                    row.UpdAssemblyId1 = stock.UpdAssemblyId1;
                    row.UpdAssemblyId2 = stock.UpdAssemblyId2;
                    row.UpdateDate = stock.UpdateDate;
                    row.UpdateDateTime = stock.UpdateDateTime;
                    row.UpdEmployeeCode = stock.UpdEmployeeCode;
                    row.WarehouseCode = stock.WarehouseCode.Trim();
                    row.WarehouseName = stock.WarehouseName;
                    row.WarehouseShelfNo = stock.WarehouseShelfNo;

                    PartsInfoDataSet.UsrGoodsInfoRow parentRow =
                        goodsTable.FindByGoodsMakerCdGoodsNo(stock.GoodsMakerCd, stock.GoodsNo);
                    if (parentRow != null)
                    {
                        row.UsrGoodsInfoRowParent = parentRow;

                        stockTable.AddStockRow(row);
                    }

                }
            }
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        ///  ���[�U�[���i�݌ɐݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        private void FillUsrGoodsStockTable(ArrayList list, int key)
        {
            if (list == null)
                return;
            foreach (StockWork stock in list)
            {
                PartsInfoDataSet.StockRow row =
                    stockTableDic[key].FindByWarehouseCodeGoodsNoGoodsMakerCd(stock.WarehouseCode, stock.GoodsNo, stock.GoodsMakerCd);
                if (row == null)
                {
                    row = stockTableDic[key].NewStockRow();

                    row.EnterpriseCode = stock.EnterpriseCode;
                    row.AcpOdrCount = stock.AcpOdrCount;
                    row.ArrivalCnt = stock.ArrivalCnt;
                    row.CreateDateTime = stock.CreateDateTime;
                    row.DuplicationShelfNo1 = stock.DuplicationShelfNo1;
                    row.DuplicationShelfNo2 = stock.DuplicationShelfNo2;
                    row.FileHeaderGuid = stock.FileHeaderGuid;
                    row.GoodsMakerCd = stock.GoodsMakerCd;
                    row.GoodsNo = stock.GoodsNo;
                    row.GoodsNoNoneHyphen = stock.GoodsNoNoneHyphen;
                    row.LastInventoryUpdate = stock.LastInventoryUpdate;
                    row.LastSalesDate = stock.LastSalesDate;
                    row.LastStockDate = stock.LastStockDate;
                    row.LogicalDeleteCode = stock.LogicalDeleteCode;
                    row.MaximumStockCnt = stock.MaximumStockCnt;
                    row.MinimumStockCnt = stock.MinimumStockCnt;
                    row.MonthOrderCount = stock.MonthOrderCount;
                    row.MovingSupliStock = stock.MovingSupliStock;
                    row.NmlSalOdrCount = stock.NmlSalOdrCount;
                    row.PartsManagementDivide1 = stock.PartsManagementDivide1;
                    row.PartsManagementDivide2 = stock.PartsManagementDivide2;
                    row.SalesOrderCount = stock.SalesOrderCount;
                    row.SalesOrderUnit = stock.SalesOrderUnit;
                    row.SectionCode = stock.SectionCode;
                    row.SectionGuideNm = stock.SectionGuideNm;
                    row.ShipmentCnt = stock.ShipmentCnt;
                    row.ShipmentPosCnt = stock.ShipmentPosCnt;
                    row.StockCreateDate = stock.StockCreateDate;
                    row.StockDiv = stock.StockDiv;
                    row.StockNote1 = stock.StockNote1;
                    row.StockNote2 = stock.StockNote2;
                    row.StockSupplierCode = stock.StockSupplierCode;
                    row.StockTotalPrice = stock.StockTotalPrice;
                    row.StockUnitPriceFl = stock.StockUnitPriceFl;
                    row.SupplierStock = stock.SupplierStock;
                    row.UpdAssemblyId1 = stock.UpdAssemblyId1;
                    row.UpdAssemblyId2 = stock.UpdAssemblyId2;
                    row.UpdateDate = stock.UpdateDate;
                    row.UpdateDateTime = stock.UpdateDateTime;
                    row.UpdEmployeeCode = stock.UpdEmployeeCode;
                    row.WarehouseCode = stock.WarehouseCode.Trim();
                    row.WarehouseName = stock.WarehouseName;
                    row.WarehouseShelfNo = stock.WarehouseShelfNo;

                    PartsInfoDataSet.UsrGoodsInfoRow parentRow =
                        goodsTableDic[key].FindByGoodsMakerCdGoodsNo(stock.GoodsMakerCd, stock.GoodsNo);
                    if (parentRow != null)
                    {
                        row.UsrGoodsInfoRowParent = parentRow;

                        stockTableDic[key].AddStockRow(row);
                    }

                }
            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        # region ���[�U�[��������:�Z�b�g���ݒ�
        /// <summary>
        /// ���[�U�[��������:�Z�b�g���ݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <br>UpdateNote : 2013/03/15�@dpp</br>
        /// <br>          �@ 10901273-00 5��15���z�M���i��Q�ȊO�j Redmine#34377 �i�Ԍ������ʕs��̏C��</br>
        private void FillUsrSetPartsTable(ArrayList list)
        {
            if (list == null)
            {
                return;
            }
            foreach (UsrSetPartsRetWork wkInf in list)
            {
                // 2009.02.19 >>>
                //PartsInfoDataSet.UsrSetPartsRow row = partsInfo.UsrSetParts.NewUsrSetPartsRow();
                string filter = string.Format("{0}='{1}' AND {2}={3} AND {4} ='{5}' AND {6}={7}",
                                partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName,
                                wkInf.SetMainPartsNo,
                                partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName,
                                wkInf.SetMainMakerCd,
                                partsInfo.UsrSetParts.SubGoodsNoColumn.ColumnName,
                                wkInf.SetSubPartsNo,
                                partsInfo.UsrSetParts.SubGoodsMakerCdColumn.ColumnName,
                                wkInf.SetSubMakerCd);
                PartsInfoDataSet.UsrSetPartsRow[] rows = (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(filter);
                PartsInfoDataSet.UsrSetPartsRow row;

                if (rows != null && rows.Length > 0)
                {
                    row = rows[0];

                }
                else
                {
                    row = partsInfo.UsrSetParts.NewUsrSetPartsRow();
                    partsInfo.UsrSetParts.AddUsrSetPartsRow(row);
                }
                // 2009.02.19 <<<

                row.ParentGoodsMakerCd = wkInf.SetMainMakerCd;
                row.ParentGoodsNo = wkInf.SetMainPartsNo;
                row.SubGoodsMakerCd = wkInf.SetSubMakerCd;
                row.SubGoodsNo = wkInf.SetSubPartsNo;
                row.SetSpecialNote = wkInf.SetSpecialNote;
                row.DisplayOrder = wkInf.SetDispOrder;
                row.CatalogShapeNo = wkInf.CatalogShapeNo;
                row.CntFl = wkInf.SetQty;
                row.SetSpecialNote = wkInf.SetSpecialNote;

                // 2009/09/07 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                PartsInfoDataSet.UsrGoodsInfoRow usrRow = goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.SetSubMakerCd, wkInf.SetSubPartsNo);
                if (usrRow != null) // ���ɓo�^����Ă���ꍇ�i�񋟂���̐ݒ肪����ꍇ�j
                {
                }
                else
                {
                    usrRow = goodsTable.NewUsrGoodsInfoRow();
                    //usrRow.EnterpriseCode = wkInf.EnterpriseCode;
                    //usrRow.FileHeaderGuid = wkInf.FileHeaderGuid;
                    //usrRow.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    //usrRow.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    //usrRow.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    //usrRow.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    //usrRow.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    //usrRow.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    usrRow.GoodsMakerCd = wkInf.SetSubMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.SetSubMakerCd);
                    usrRow.GoodsNo = wkInf.SetSubPartsNo;
                    //usrRow.GoodsNoNoneHyphen = wkInf.SetSubPartsNo; // DEL dpp 2013/03/15 Redmine#34377
                    usrRow.GoodsNoNoneHyphen = wkInf.SetSubPartsNo.Replace("-",""); // ADD dpp 2013/03/15 Redmine#34377
                    //usrRow.GoodsName = "*";
                    //usrRow.GoodsNameKana = "*";
                    //usrRow.GoodsOfrName = wkInf.GoodsName;
                    //usrRow.GoodsOfrNameKana = wkInf.GoodsNameKana;
                    //usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    //usrRow.BlGoodsCode = wkInf..BLGoodsCode;
                    usrRow.DisplayOrder = wkInf.SetDispOrder;
                    //usrRow.GoodsNote1 = wkInf.GoodsNote1;
                    //usrRow.GoodsNote2 = wkInf.GoodsNote2;
                    usrRow.GoodsSpecialNote = wkInf.SetSpecialNote;
                    //usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                    //usrRow.OfferDate = DateTime.Today;
                    usrRow.GoodsKindCode = 0;
                    //usrRow.Jan = wkInf.Jan;
                    //usrRow.UpdateDate = wkInf.UpdateDate;
                    //usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                    //usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                    //usrRow.OfferDataDiv = wkInf.OfferDataDiv;

                    if (usrRow.OfferDate != DateTime.MinValue || usrRow.OfferDataDiv == 1)
                        usrRow.OfferKubun = 1; // ���[�U�[�o�^�̑�ցE�Z�b�g�E�������i�̏ꍇ�񋟏������D�ǂ��s���I
                    else
                        usrRow.OfferKubun = 0; // ���[�U�[�o�^
                    goodsTable.AddUsrGoodsInfoRow(usrRow);
                } // ADD 2012/12/10 Y.Wakita
                    string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfo.UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.SetSubPartsNo,
                        partsInfo.UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.SetSubMakerCd);
                    partsInfo.UsrJoinParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfo.UsrJoinParts.DefaultView.Count; i++)
                    {
                        partsInfo.UsrJoinParts.DefaultView[i][partsInfo.UsrJoinParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                    rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        partsInfo.UsrSetParts.SubGoodsNoColumn.ColumnName, wkInf.SetSubPartsNo,
                        partsInfo.UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkInf.SetSubMakerCd);
                    partsInfo.UsrSetParts.DefaultView.RowFilter = rowFilter;
                    for (int i = 0; i < partsInfo.UsrSetParts.DefaultView.Count; i++)
                    {
                        partsInfo.UsrSetParts.DefaultView[i][partsInfo.UsrSetParts.PrmSettingFlgColumn.ColumnName] = true;
                    }
                    //} // DEL 2012/12/10 Y.Wakita
                // 2009/09/07 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                //partsInfo.UsrSetParts.AddUsrSetPartsRow(row); // 2009.02.19 Del
            }
        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// ���[�U�[��������:�Z�b�g���ݒ�
        /// </summary>
        /// <param name="list"></param>
        /// <param name="key"></param>
        private void FillUsrSetPartsTable(ArrayList list, int key)
        {
            if (list == null)
            {
                return;
            }
            foreach (UsrSetPartsRetWork wkInf in list)
            {
                string filter = string.Format("{0}='{1}' AND {2}={3} AND {4} ='{5}' AND {6}={7}",
                                partsInfoDic[key].UsrSetParts.ParentGoodsNoColumn.ColumnName,
                                wkInf.SetMainPartsNo,
                                partsInfoDic[key].UsrSetParts.ParentGoodsMakerCdColumn.ColumnName,
                                wkInf.SetMainMakerCd,
                                partsInfoDic[key].UsrSetParts.SubGoodsNoColumn.ColumnName,
                                wkInf.SetSubPartsNo,
                                partsInfoDic[key].UsrSetParts.SubGoodsMakerCdColumn.ColumnName,
                                wkInf.SetSubMakerCd);
                PartsInfoDataSet.UsrSetPartsRow[] rows = (PartsInfoDataSet.UsrSetPartsRow[])partsInfoDic[key].UsrSetParts.Select(filter);
                PartsInfoDataSet.UsrSetPartsRow row;

                if (rows != null && rows.Length > 0)
                {
                    row = rows[0];

                }
                else
                {
                    row = partsInfoDic[key].UsrSetParts.NewUsrSetPartsRow();
                    partsInfoDic[key].UsrSetParts.AddUsrSetPartsRow(row);
                }
                // 2009.02.19 <<<

                row.ParentGoodsMakerCd = wkInf.SetMainMakerCd;
                row.ParentGoodsNo = wkInf.SetMainPartsNo;
                row.SubGoodsMakerCd = wkInf.SetSubMakerCd;
                row.SubGoodsNo = wkInf.SetSubPartsNo;
                row.SetSpecialNote = wkInf.SetSpecialNote;
                row.DisplayOrder = wkInf.SetDispOrder;
                row.CatalogShapeNo = wkInf.CatalogShapeNo;
                row.CntFl = wkInf.SetQty;
                row.SetSpecialNote = wkInf.SetSpecialNote;

                PartsInfoDataSet.UsrGoodsInfoRow usrRow = goodsTableDic[key].FindByGoodsMakerCdGoodsNo(wkInf.SetSubMakerCd, wkInf.SetSubPartsNo);
                if (usrRow != null) // ���ɓo�^����Ă���ꍇ�i�񋟂���̐ݒ肪����ꍇ�j
                {
                }
                else
                {
                    usrRow = goodsTableDic[key].NewUsrGoodsInfoRow();
                    //usrRow.EnterpriseCode = wkInf.EnterpriseCode;
                    //usrRow.FileHeaderGuid = wkInf.FileHeaderGuid;
                    //usrRow.CreateDateTime = wkInf.CreateDateTime.Ticks;
                    //usrRow.UpdateDateTime = wkInf.UpdateDateTime.Ticks;
                    //usrRow.UpdAssemblyId1 = wkInf.UpdAssemblyId1;
                    //usrRow.UpdAssemblyId2 = wkInf.UpdAssemblyId2;
                    //usrRow.UpdEmployeeCode = wkInf.UpdEmployeeCode;
                    //usrRow.LogicalDeleteCode = wkInf.LogicalDeleteCode;

                    usrRow.GoodsMakerCd = wkInf.SetSubMakerCd;
                    usrRow.GoodsMakerNm = GetPartsMakerName(wkInf.SetSubMakerCd);
                    usrRow.GoodsNo = wkInf.SetSubPartsNo;
                    usrRow.GoodsNoNoneHyphen = wkInf.SetSubPartsNo.Replace("-", ""); 
                    //usrRow.GoodsName = "*";
                    //usrRow.GoodsNameKana = "*";
                    //usrRow.GoodsOfrName = wkInf.GoodsName;
                    //usrRow.GoodsOfrNameKana = wkInf.GoodsNameKana;
                    //usrRow.GoodsMGroup = wkInf.GoodsMGroup;
                    //usrRow.BlGoodsCode = wkInf..BLGoodsCode;
                    usrRow.DisplayOrder = wkInf.SetDispOrder;
                    //usrRow.GoodsNote1 = wkInf.GoodsNote1;
                    //usrRow.GoodsNote2 = wkInf.GoodsNote2;
                    usrRow.GoodsSpecialNote = wkInf.SetSpecialNote;
                    //usrRow.TaxationDivCd = wkInf.TaxationDivCd;
                    //usrRow.OfferDate = DateTime.Today;
                    usrRow.GoodsKindCode = 0;
                    //usrRow.Jan = wkInf.Jan;
                    //usrRow.UpdateDate = wkInf.UpdateDate;
                    //usrRow.GoodsRateRank = wkInf.GoodsRateRank;
                    //usrRow.EnterpriseGanreCode = wkInf.EnterpriseGanreCode;
                    //usrRow.OfferDataDiv = wkInf.OfferDataDiv;

                    if (usrRow.OfferDate != DateTime.MinValue || usrRow.OfferDataDiv == 1)
                        usrRow.OfferKubun = 1; // ���[�U�[�o�^�̑�ցE�Z�b�g�E�������i�̏ꍇ�񋟏������D�ǂ��s���I
                    else
                        usrRow.OfferKubun = 0; // ���[�U�[�o�^
                    goodsTableDic[key].AddUsrGoodsInfoRow(usrRow);
                } 
                string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                    partsInfoDic[key].UsrJoinParts.JoinDestPartsNoColumn.ColumnName, wkInf.SetSubPartsNo,
                    partsInfoDic[key].UsrJoinParts.JoinDestMakerCdColumn.ColumnName, wkInf.SetSubMakerCd);
                partsInfoDic[key].UsrJoinParts.DefaultView.RowFilter = rowFilter;
                for (int i = 0; i < partsInfoDic[key].UsrJoinParts.DefaultView.Count; i++)
                {
                    partsInfoDic[key].UsrJoinParts.DefaultView[i][partsInfoDic[key].UsrJoinParts.PrmSettingFlgColumn.ColumnName] = true;
                }
                rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                    partsInfoDic[key].UsrSetParts.SubGoodsNoColumn.ColumnName, wkInf.SetSubPartsNo,
                    partsInfoDic[key].UsrSetParts.SubGoodsMakerCdColumn.ColumnName, wkInf.SetSubMakerCd);
                partsInfoDic[key].UsrSetParts.DefaultView.RowFilter = rowFilter;
                for (int i = 0; i < partsInfoDic[key].UsrSetParts.DefaultView.Count; i++)
                {
                    partsInfoDic[key].UsrSetParts.DefaultView[i][partsInfoDic[key].UsrSetParts.PrmSettingFlgColumn.ColumnName] = true;
                }
            }
        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        # endregion

        # region ���[�U�[�i�Ԍ����F�t�h�e�[�u����񁃃J�^���O�E�D�ǁ��ݒ�
#if old
        /// <summary>
        /// ���[�U�[�i�Ԍ����F�t�h�e�[�u����񁃃J�^���O�E�D�ǁ��ݒ�
        /// ���݁@�g���Ă��Ȃ�
        /// </summary>
        /// <param name="list"></param>
        private void SetUsrGoodsInfoTableFromOfferData(ArrayList list)
        {
            if (list == null)
            {
                return;
            }
            foreach (OfrPartsRetWork wkInf in list)
            {
                PartsInfoDataSet.UsrGoodsInfoRow row = goodsTable.NewUsrGoodsInfoRow();
                row.GoodsMakerCd = wkInf.MakerCode;
                row.GoodsNo = wkInf.PartsNoWithHyphen;
                row.GoodsNoNoneHyphen = wkInf.PartsNoNoneHyphen;
                row.GoodsName = wkInf.PartsName;
                row.GoodsMGroup = wkInf.GoodsMGroup;
                row.BlGoodsCode = wkInf.TbsPartsCode;
                row.GoodsNote1 = string.Empty; // �Y�����ڂȂ� // wkInf.GoodsNote1;
                row.GoodsNote2 = string.Empty; // �Y�����ڂȂ� // wkInf.GoodsNote2;
                row.GoodsSpecialNote = wkInf.PrimePartsSpecialNote;
                row.TaxationDivCd = 0; // �Y�����ڂȂ� // wkInf.TaxationCode;
                row.OfferDate = GetDateTimeFromInt(wkInf.OfferDate);

                goodsTable.AddUsrGoodsInfoRow(row);
            }
        }

        private void SetUsrGoodsPriceTableFromOfferData(ArrayList list)
        {
            if (list == null)
            {
                return;
            }
            foreach (OfrPartsPriceRetWork wkInf in list)
            {
                PartsInfoDataSet.UsrGoodsPriceRow row = priceTable.NewUsrGoodsPriceRow();

                row.GoodsMakerCd = wkInf.PartsMakerCd;
                row.GoodsNo = wkInf.PrimePartsNoWithH;
                row.ListPrice = wkInf.NewPrice;
                row.OpenPriceDiv = wkInf.OpenPriceDiv;
                row.PriceStartDate = GetDateTimeFromInt(wkInf.PriceStartDate);
                row.SalesUnitCost = 0; // �Y�����ڂȂ�
                row.StockRate = 0; // �Y�����ڂȂ�
                row.OfferDate = GetDateTimeFromInt(wkInf.OfferDate);

                PartsInfoDataSet.UsrGoodsInfoRow parentRow = goodsTable.FindByGoodsMakerCdGoodsNo(wkInf.PartsMakerCd, wkInf.PrimePartsNoWithH);
                if (parentRow != null)
                {
                    row.UsrGoodsInfoRowParent = parentRow;
                    priceTable.AddUsrGoodsPriceRow(row);
                }
            }
        }
#endif
        # endregion
        # endregion

        #region BL�R�[�h�擾
        /// <summary>
        /// �a�k���̎擾���񋟁�
        /// </summary>
        private void GetOfrBlInf()
        {
            //�����e�[�u���̃N���A
            ofrBLInfo.Clear();
            _ofrBLList = new List<TbsPartsCodeWork>(); // 2010/02/25 Add

            TbsPartsCodeWork tbsPartsCodeWork = new TbsPartsCodeWork();
            tbsPartsCodeWork.TbsPartsCode = 0; // BL�R�[�h�S���擾

            object objret = null;
            try
            {
                iBlGoodsCdDB = MediationTbsPartsCodeDB.GetTbsPartsCodeDB();

                // 2010/02/25 >>>
                //int status = iBlGoodsCdDB.Search(out objret, tbsPartsCodeWork);
                int status = iBlGoodsCdDB.SearchDerived(out objret, tbsPartsCodeWork);
                // 2010/02/25 <<<
                ArrayList list = objret as ArrayList;

                foreach (TbsPartsCodeWork wktbsPartsCodeWork in list)
                //BL���i�R�[�h���ʃN���X
                {
                    BLInfoRow row = ofrBLInfo.NewBLInfoRow();

                    row.SelectionState = false;
                    row.TbsPartsCode = wktbsPartsCodeWork.TbsPartsCode;
                    row.TbsPartsFullName = wktbsPartsCodeWork.TbsPartsFullName;
                    row.TbsPartsHalfName = wktbsPartsCodeWork.TbsPartsHalfName;
                    row.EquipGenreCode = wktbsPartsCodeWork.EquipGenre;
                    row.BLGroupCode = wktbsPartsCodeWork.BLGroupCode;
                    row.GoodsMGroup = wktbsPartsCodeWork.GoodsMGroup;
                    row.TbsPartsCdDerivedNo = wktbsPartsCodeWork.TbsPartsCdDerivedNo;
                    row.PrimeSearchFlg = wktbsPartsCodeWork.PrimeSearchFlg;
                    ofrBLInfo.AddBLInfoRow(row);

                    _ofrBLList.Add(wktbsPartsCodeWork); // 2010/02/25 Add

                }
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// �t�[���^���Œ�ԍ�����BL�R�[�h�擾���܂��B
        /// </summary>
        // --- UPD m.suzuki 2010/04/28 ---------->>>>>
        //private void GetCarBlInf()
        private void GetCarBlInf( int blCode )
        // --- UPD m.suzuki 2010/04/28 ----------<<<<<
        {
            // -- ADD 2010/05/25 ------------------------>>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return;
            }
            // -- ADD 2010/05/25 ------------------------<<<

            int[] fullModelFixedNos;
            object retob = new object();
            ArrayList retInt;

            //�����e�[�u���̃N���A
            bLInfo.Clear();

            // UPD 2013/02/14 SCM��Q��10354�Ή� 2013/03/06�z�M --------------------------------------------------->>>>>
            //fullModelFixedNos = carInfoDataSet.CarModelInfo.GetFullModelFixedNoArray(true);
            // UPD 2013/02/15 2013/03/06�z�M �V�X�e���e�X�g��Q��xxx�Ή� ----------------------------->>>>>
            //fullModelFixedNos = carInfoDataSet.CarModelInfo.GetFullModelFixedNoArray(true, carInfoDataSet.CarModelUIData[0].FrameNo, carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput);

            string frameNo = "";
            int produceTypeOfYearInput = 0;

            if (carInfoDataSet != null && carInfoDataSet.CarModelUIData.Count != 0)
            {
                frameNo = carInfoDataSet.CarModelUIData[0].FrameNo;
                produceTypeOfYearInput = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
            }
            fullModelFixedNos = carInfoDataSet.CarModelInfo.GetFullModelFixedNoArray(true, frameNo, produceTypeOfYearInput);
            // UPD 2013/02/15 2013/03/06�z�M �V�X�e���e�X�g��Q��xxx�Ή� -----------------------------<<<<<
            // UPD 2013/02/14 SCM��Q��10354�Ή� ---------------------------------------------------<<<<<

            try
            {
                if (iOfferPartsInfo == null)
                    iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();

                // --- UPD m.suzuki 2010/04/28 ---------->>>>>
                //int status = iOfferPartsInfo.SearchTbsCodeInfo(fullModelFixedNos, ref retob);
                int status = iOfferPartsInfo.SearchTbsCodeInfo( fullModelFixedNos, blCode, ref retob );
                // --- UPD m.suzuki 2010/04/28 ----------<<<<<
                
                retInt = (ArrayList)((CustomSerializeArrayList)retob)[0];

                if (status == 0 && retInt != null && retInt.Count > 0)
                {
                    FillBLInfoTable(retInt);
                }

            }
            catch
            {
                //throw;
            }

        }

        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� ------------------------------------------------->>>>>
        /// <summary>
        /// �t���^���Œ�ԍ�����BL�R�[�h�擾���܂��B
        /// </summary>
        private void GetCarBlInf(List<int> blCodeList)
        {
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                return;
            }

            int[] fullModelFixedNos;
            object retob = new object();
            ArrayList retInt;

            //�����e�[�u���̃N���A
            bLInfo.Clear();

            string frameNo = "";
            int produceTypeOfYearInput = 0;

            if (carInfoDataSet != null && carInfoDataSet.CarModelUIData.Count != 0)
            {
                frameNo = carInfoDataSet.CarModelUIData[0].FrameNo;
                produceTypeOfYearInput = carInfoDataSet.CarModelUIData[0].ProduceTypeOfYearInput;
            }
            fullModelFixedNos = carInfoDataSet.CarModelInfo.GetFullModelFixedNoArray(true, frameNo, produceTypeOfYearInput);

            try
            {
                if (iOfferPartsInfo == null)
                    iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();

                // BL�R�[�h���񋟃f�[�^�擾
                if (blCodeList != null && blCodeList.Count != 0)
                {
                    // UPD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��13.�t���^���Œ�ԍ�����̂a�k�R�[�h�����񐔉��ǑΉ� ---------------------------------->>>>>
                    //foreach (int blCode in blCodeList)
                    //{
                    //    int status = iOfferPartsInfo.SearchTbsCodeInfo(fullModelFixedNos, blCode, ref retob);

                    //    retInt = (ArrayList)((CustomSerializeArrayList)retob)[0];

                    //    if (status == 0 && retInt != null && retInt.Count > 0)
                    //    {
                    //        FillBLInfoTable(retInt);
                    //    }
                    //}
                    ArrayList paraList = new ArrayList();
                    paraList.AddRange(blCodeList);

                    int status = iOfferPartsInfo.SearchTbsCodeInfo(fullModelFixedNos, paraList, ref retob);

                    // UPD 2014/08/13 11070147-00 �V�X�e���e�X�g��Q��20�Ή� -------------------------->>>>>
                    retInt = (ArrayList)((CustomSerializeArrayList)retob)[0];
                    CustomSerializeArrayList tempInt = (CustomSerializeArrayList)retob;
                    if (tempInt != null && tempInt.Count != 0)
                    {
                        retInt = (ArrayList)((CustomSerializeArrayList)retob)[0];
                    }
                    else
                    {
                        retInt = null;
                    }
                    // UPD 2014/08/13 11070147-00 �V�X�e���e�X�g��Q��20�Ή� --------------------------<<<<<

                    if (status == 0 && retInt != null && retInt.Count > 0)
                    {
                        FillBLInfoTable(retInt);
                    }
                    // UPD 2014/05/13 PM-SCM���x���� �t�F�[�Y�Q��13.�t���^���Œ�ԍ�����̂a�k�R�[�h�����񐔉��ǑΉ� ----------------------------------<<<<<
                }
            }
            catch
            {
                //throw;
            }

        }
        // ADD 2014/02/06 SCM�d�|�ꗗ��10632�Ή� -------------------------------------------------<<<<<

        /// <summary>
        /// �a�k���ݒ聃���q��
        /// </summary>
        /// <param name="list"></param>
        private void FillBLInfoTable(ArrayList list)
        {
            foreach (RetTbsPartsCodeWork wkInf in list)
            {
                if (searchPrtCtlAcs.IsBLEnabled(wkInf.TbsPartsCode))
                {
                    BLInfoRow row = bLInfo.NewBLInfoRow();

                    row.SelectionState = false;
                    row.TbsPartsCode = wkInf.TbsPartsCode;
                    row.TbsPartsFullName = wkInf.TbsPartsFullName;
                    row.TbsPartsHalfName = wkInf.TbsPartsHalfName;
                    row.PrimeSearchFlg = wkInf.PrimeSearchFlg;
                    row.EquipGenreCode = wkInf.EquipGenre;
                    row.BLGroupCode = 0;////////////////////////////////
                    row.GoodsMGroup = 0;////////////////////////////////
                    row.TbsPartsCdDerivedNo = 0;

                    bLInfo.AddBLInfoRow(row);
                }
            }

        }
        #endregion

        // 2009.02.12 Add >>>
        #region �D�ǐݒ�̌���
        /// <summary>
        /// �D�ǐݒ胊�X�g����A�Ώۂ̗D�ǐݒ���擾���܂��B
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsMGroup">���i�����ރR�[�h</param>
        /// <param name="tbsPartsCode">BL�R�[�h</param>
        /// <param name="partsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="prmSetDtlNo1">�D�ǐݒ�ڍ׃R�[�h�P�i�Z���N�g�R�[�h�j</param>
        /// <param name="prmSetDtlNo2">�D�ǐݒ�ڍ׃R�[�h�Q�i��ʃR�[�h�j</param>
        /// <param name="prmSettingUWorkList">�D�ǐݒ胊�X�g</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.02.12</br>
        /// </remarks>
        private static PrmSettingUWork SearchPrmSettingUWork(string sectionCode, int goodsMGroup, int tbsPartsCode, int partsMakerCd, int prmSetDtlNo1, int prmSetDtlNo2, List<PrmSettingUWork> prmSettingUWorkList)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
            if ( prmSettingUWorkList == null )
            {
                return null;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD

            return prmSettingUWorkList.Find(
                        delegate(PrmSettingUWork prmSettingUWork)
                        {
                            if (( prmSettingUWork.PrmSetDtlNo2 == prmSetDtlNo2 ) &&
                                ( prmSettingUWork.PrmSetDtlNo1 == prmSetDtlNo1 ) &&
                                ( prmSettingUWork.PartsMakerCd == partsMakerCd ) &&
                                ( prmSettingUWork.TbsPartsCode == tbsPartsCode ) &&
                                ( prmSettingUWork.GoodsMGroup == goodsMGroup ) &&
                                ( prmSettingUWork.SectionCode.Trim() == sectionCode.Trim() ))
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        });
        }

        /// <summary>
        /// �D�ǐݒ胊�X�g����A�Ώۂ̗D�ǐݒ���擾���܂��B�i�Z�b�g��p�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsMGroup">���i�����ރR�[�h</param>
        /// <param name="tbsPartsCode">BL�R�[�h</param>
        /// <param name="partsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="prmSetDtlNo1">�D�ǐݒ�ڍ׃R�[�h�P�i�Z���N�g�R�[�h�j</param>
        /// <param name="prmSettingUWorkList">�D�ǐݒ胊�X�g</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.02.17</br>
        /// </remarks>
        private static PrmSettingUWork SearchPrmSettingUWork(string sectionCode, int goodsMGroup, int tbsPartsCode, int partsMakerCd, int prmSetDtlNo1, List<PrmSettingUWork> prmSettingUWorkList)
        {
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/04/01 ADD
            if ( prmSettingUWorkList == null )
            {
                return null;
            }
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/04/01 ADD

            PrmSettingUWork retPrmSettingUWork = null;
            List<PrmSettingUWork> list = prmSettingUWorkList.FindAll(
                                            delegate(PrmSettingUWork prmSettingUWork)
                                            {
                                                if (( prmSettingUWork.PrmSetDtlNo1 == prmSetDtlNo1 ) &&
                                                    ( prmSettingUWork.PartsMakerCd == partsMakerCd ) &&
                                                    ( prmSettingUWork.TbsPartsCode == tbsPartsCode ) &&
                                                    ( prmSettingUWork.GoodsMGroup == goodsMGroup ) &&
                                                    ( prmSettingUWork.SectionCode.Trim() == sectionCode.Trim() ))
                                                {
                                                    return true;
                                                }
                                                else
                                                {
                                                    return false;
                                                }
                                            });
            if (list != null && list.Count > 0)
            {
                foreach (PrmSettingUWork prmSettingUWork in list)
                {
                    if (retPrmSettingUWork == null) retPrmSettingUWork = prmSettingUWork;

                    // ���i�ɂȂ��Ă���ꍇ�͏I��
                    if (retPrmSettingUWork.PrimeDisplayCode != 0) break;

                    // �߂�l���u�\�������v�̏ꍇ�͒u��
                    if (retPrmSettingUWork.PrimeDisplayCode == 0)
                    {
                        retPrmSettingUWork = prmSettingUWork;
                    }
                }
            }
            return retPrmSettingUWork;
        }

        /// <summary>
        /// �D�ǐݒ胊�X�g����A�Ώۂ̗D�ǐݒ���擾���܂��B
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsMGroup">���i�����ރR�[�h</param>
        /// <param name="tbsPartsCode">BL�R�[�h</param>
        /// <param name="partsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="prmSettingUWorkList">�D�ǐݒ胊�X�g</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.02.12</br>
        /// </remarks>
        private static PrmSettingUWork SearchPrmSettingUWork(string sectionCode, int goodsMGroup, int tbsPartsCode, int partsMakerCd, List<PrmSettingUWork> prmSettingUWorkList)
        {
            return SearchPrmSettingUWork(sectionCode, goodsMGroup, tbsPartsCode, partsMakerCd, 0, 0, prmSettingUWorkList);
        }
        #endregion
        // 2009.02.12 Add <<<

        // 2009.02.24 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        #region �������i���f
        /// <summary>
        /// �������i���f�C�x���g�R�[��
        /// </summary>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="offerKubun">�񋟋敪</param>
        /// <param name="listPrice">�W�����i</param>
        private void ReflectIsolIslandCall(int taxationCode, int goodsMakerCd, int offerKubun, ref double listPrice)
        {
            if (this.ReflectIsolIsland != null) this.ReflectIsolIsland(taxationCode, goodsMakerCd, offerKubun, ref listPrice);
        }
        #endregion
        // 2009.02.24 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        #endregion

        #region ���i���擾����
        // 2009.04.14 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ���i���擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="goodsMGroup">�����ރR�[�h</param>
        /// <param name="blCode">�a�k�R�[�h</param>
        /// <param name="goodsPriceUWorkList">���i��񃊃X�g</param>
        /// <returns></returns>
        public int GetGoodsPrice(string sectionCode, int goodsMakerCd, string goodsNo, int goodsMGroup, int blCode, out ArrayList goodsPriceUWorkList)
        {
            // -- ADD 2010/05/25 ------------------------>>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                goodsPriceUWorkList = null;
                return 0;
            }
            // -- ADD 2010/05/25 ------------------------<<<

            goodsPriceUWorkList = null;
            GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();
            ArrayList lstCond = new ArrayList();
            ArrayList lstRst;
            ArrayList lstRstPrm;
            ArrayList lstPrmPrice;

            OfrPrtsSrchCndWork work = new OfrPrtsSrchCndWork();
            work.MakerCode = goodsMakerCd;
            work.PrtsNo = goodsNo;
            lstCond.Add(work);

            if (iOfferPartsInfo == null) iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();
            int status = iOfferPartsInfo.GetOfrPartsInf(lstCond, out lstRst, out lstRstPrm, out lstPrmPrice);
            if (status == 0)
            {
                PrmSettingUWork prmSetting = SearchPrmSettingUWork(sectionCode, goodsMGroup, blCode, goodsMakerCd, _drPrmSettingWork);
                if (prmSetting != null)
                {
                    if ((lstPrmPrice != null) && (lstPrmPrice.Count != 0))
                    {
                        // �D�ǉ��i
                        foreach (OfferJoinPriceRetWork retWork in lstPrmPrice)
                        {
                            goodsPriceUWork = new GoodsPriceUWork();
                            goodsPriceUWork.GoodsMakerCd = retWork.PartsMakerCd;
                            goodsPriceUWork.GoodsNo = retWork.PrimePartsNoWithH;
                            goodsPriceUWork.ListPrice = retWork.NewPrice;
                            goodsPriceUWork.OfferDate = retWork.OfferDate;
                            goodsPriceUWork.OpenPriceDiv = retWork.OpenPriceDiv;
                            goodsPriceUWork.PriceStartDate = retWork.PriceStartDate;

                            goodsPriceUWorkList.Add(goodsPriceUWork);
                        }
                    }
                }
                else
                {
                    if ((lstRst != null) && (lstRst.Count != 0))
                    {
                        // �������i
                        foreach (RetPartsInf retWork in lstRst)
                        {
                            goodsPriceUWork = new GoodsPriceUWork();
                            goodsPriceUWork.GoodsMakerCd = retWork.CatalogPartsMakerCd;
                            goodsPriceUWork.GoodsNo = retWork.ClgPrtsNoWithHyphen;
                            goodsPriceUWork.ListPrice = retWork.PartsPrice;
                            goodsPriceUWork.OfferDate = retWork.OfferDate;
                            goodsPriceUWork.OpenPriceDiv = retWork.OpenPriceDiv;
                            goodsPriceUWork.PriceStartDate = retWork.PartsPriceStDate;

                            goodsPriceUWorkList.Add(goodsPriceUWork);
                        }
                    }
                }

            }

            return status;

        }

        /// <summary>
        /// �w�ʏ��擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="goodsMGroup">�����ރR�[�h</param>
        /// <param name="blCode">�a�k�R�[�h</param>
        /// <param name="goodsRateRank">�w��</param>
        /// <returns></returns>
        public int GetGoodsRateRank(string sectionCode, int goodsMakerCd, string goodsNo, int goodsMGroup, int blCode, out string goodsRateRank)
        {
            // -- ADD 2010/05/25 -------------------->>>
            //if (!LoginInfoAcquisition.OnlineFlag)  // DEL 2010/07/07
            if ((!LoginInfoAcquisition.OnlineFlag) && (Path.GetFileNameWithoutExtension(WinForms.Application.ExecutablePath) != "PMSCM01000U"))  // ADD 2010/07/07
            {
                goodsRateRank = string.Empty;
                return 0;
            }
            // -- ADD 2010/05/25 --------------------<<<

            goodsRateRank = string.Empty;
            ArrayList lstCond = new ArrayList();
            ArrayList lstRst;
            ArrayList lstRstPrm;
            ArrayList lstPrmPrice;

            OfrPrtsSrchCndWork work = new OfrPrtsSrchCndWork();
            work.MakerCode = goodsMakerCd;
            work.PrtsNo = goodsNo;
            lstCond.Add(work);

            if (iOfferPartsInfo == null) iOfferPartsInfo = MediationOfferPartsInfo.GetOfferPartsInfo();
            int status = iOfferPartsInfo.GetOfrPartsInf(lstCond, out lstRst, out lstRstPrm, out lstPrmPrice);
            if (status == 0)
            {
                PrmSettingUWork prmSetting = SearchPrmSettingUWork(sectionCode, goodsMGroup, blCode, goodsMakerCd, _drPrmSettingWork);
                if (prmSetting != null)
                {
                    // �D�Ǐ��
                    if ((lstRstPrm != null) && (lstRstPrm.Count != 0))
                    {
                        goodsRateRank = ((OfferJoinPartsRetWork)lstRstPrm[0]).PartsLayerCd;
                    }
                }
                else
                {
                    // �������
                    if ((lstRst != null) && (lstRst.Count != 0))
                    {
                        goodsRateRank = ((RetPartsInf)lstRst[0]).PartsLayerCd;
                    }
                }

            }

            return status;

        }
        // 2009.04.14 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        #endregion

        // --- ADD m.suzuki 2010/07/14 ---------->>>>>
        /// <summary>
        /// �S�p�˔��p�ϊ�
        /// </summary>
        /// <param name="orgString"></param>
        /// <returns></returns>
        private static string GetKanaString( string orgString )
        {
            // �S�p�˔��p�ϊ��i�r���Ɋ܂܂��ϊ��ł��Ȃ������͂��̂܂܁j
            return Microsoft.VisualBasic.Strings.StrConv( orgString, Microsoft.VisualBasic.VbStrConv.Narrow, 0 );
        }
        // --- ADD m.suzuki 2010/07/14 ----------<<<<<
        #region �������ϕ��i�ԍ��ϊ��}�X�^�擾����
        // --- ADD T.Nishi 2012/05/30 ---------->>>>>
        /// <summary>
        /// �������ϕ��i�R�[�h�擾
        /// </summary>
        /// <param name="AutoEstimatePartsCd">�������ϕ��i�R�[�h</param>
        /// <param name="TbsPartsCode">BL�R�[�h</param>
        /// <param name="CompoMainFlag">�\�����C���t���O</param>
        /// <param name="PartsPosMainFlag">���ʃ��C���t���O</param>
        /// <returns></returns>
        public int GetAutoEstimatePartsCd(out string AutoEstimatePartsCd, int TbsPartsCode, int CompoMainFlag, int PartsPosMainFlag)
        {

            AutoEstimatePartsCd = string.Empty;
            if (iAutoEstmPtNoChgDB == null) iAutoEstmPtNoChgDB = MediationAutoEstmPtNoChgDB.GetAutoEstmPtNoChgDB();
            AutoEstmPtNoChgWork paraAutoEstmPtNoChgWork = new AutoEstmPtNoChgWork();
            paraAutoEstmPtNoChgWork.TbsPartsCode = TbsPartsCode;
            paraAutoEstmPtNoChgWork.CompoMainFlag = CompoMainFlag;
            paraAutoEstmPtNoChgWork.PartsPosMainFlag = PartsPosMainFlag;

            object autoEstmPtNoChgDB;
            int status = iAutoEstmPtNoChgDB.Search(out autoEstmPtNoChgDB, paraAutoEstmPtNoChgWork);
            ArrayList lst = autoEstmPtNoChgDB as ArrayList;

            if (status == 0) // ����̏ꍇ
            {
                lst.Add(autoEstmPtNoChgDB);
                AutoEstimatePartsCd = ((AutoEstmPtNoChgWork)lst[0]).AutoEstimatePartsCd;
            }
            return status;

        }
        // --- ADD T.Nishi 2012/05/30 ----------<<<<<
        #endregion

        // --- ADD 2013/03/27 ---------->>>>>
        /// <summary>
        /// ��ʂ�VIN������ƃ��[�J�R�[�h�ɉ����ĕ��i�i��������ǉ�
        /// </summary>
        /// <param name="para">���i�擾�p�����[�^</param>
        /// <remarks>
        /// <br>Note: 2013/03/27�@FSI�֓� �a�G</br>
        /// <br>    : 10900269-00 SPK�ԑ�ԍ�������Ή�</br>
        /// <br>    :   ���������Ɋi�[����Ă���VIN�R�[�h�ƃ��[�J�����</br>
        /// <br>    :   �n���h���ʒu���E���Y�H��R�[�h��ǉ�</br>
        /// </remarks>
        private void AddPartsNarrowingInfoFromVinCode(ref GetPartsInfPara para)
        {
            // �p�����[�^�`�F�b�N
            if (para == null)
                return;

            para.VinCode = 0;   // VIN�R�[�h�i���L���͂��̒l��0����0���ōs���B

            if (carInfoDataSet == null || carInfoDataSet.CarModelUIData.Count == 0)
                return;

            try
            {
                // VIN�R�[�h�𒊏o�����Ƃ��邩�ǂ����`�F�b�N
                // �ȉ��̂ǂꂩ�𖞂����ꍇ��VIN�R�[�h�i�����s��Ȃ�
                // �E���Y/�O�ԋ敪���u�O�ԁv�ł͂Ȃ�
                // �E��ʂ���擾�����ԑ�ԍ������񂪋�
                // �E�ԑ�ԍ�(�����p)�ɒl���i�[����Ă���(���蓾�Ȃ�)
                if (carInfoDataSet.CarModelUIData[0].DomesticForeignCode != 2 ||
                     string.IsNullOrEmpty(carInfoDataSet.CarModelUIData[0].FrameNo) ||
                     carInfoDataSet.CarModelUIData[0].SearchFrameNo != 0)
                {
                    return;
                }

                // VIN�R�[�h�̕�����擾
                string orgVinCode = carInfoDataSet.CarModelUIData[0].FrameNo.Trim();
                string productNostr = string.Empty;         // �����ԍ�(������)
                int productNonum = -1;                      // �����ԍ�(���l)
                int vinHandleInfoCd = -1;                   // VIN�R�[�h����擾�����n���h���ʒu���
                string productionFactoryCd = string.Empty;  // ���Y�H��R�[�h

                // ������/�S�p���p�`�F�b�N
                System.Text.Encoding Sjis_enc = System.Text.Encoding.GetEncoding("Shift_JIS");
                if (orgVinCode.Length != 17 || Sjis_enc.GetByteCount(orgVinCode) != 17)
                    return;     // ��������17Byte�łȂ��B

                // 12Byte�ځ`17Byte�ڂ����l���`�F�b�N�̏�A�����ԍ��Ƃ��ĕێ�
                productNostr = orgVinCode.Substring(11, 6);
                if (!int.TryParse(productNostr, out productNonum))
                    return;

                // ���[�J�R�[�h���̃p�����[�^�Z�b�g����
                if (para.MakerCode == 80)
                {
                    // �u80(BENZ)�v�̏ꍇ �n���h���ʒu�����擾
                    if (int.TryParse(orgVinCode.Substring(9, 1), out vinHandleInfoCd))
                    {
                        // �n���h�����擾�𐔒l�Ƃ��Ď擾�ł���ꍇ�ɍi�������ǉ�
                        para.VinCode = productNonum;
                        para.HandleInfoCd = vinHandleInfoCd;
                        para.ProductionFactoryCd = string.Empty;

                        // VIN�R�[�h�Ǝԗ��^���}�X�^�̃n���h���ʒu���l��
                        // �ꗂ�����̂ŕ␳����B
                        // �EVIN�R�[�h
                        //  ���n���h����1
                        //  �E�n���h����2
                        // �E�ԗ��^���}�X�^
                        //  ���n���h����2
                        //  �E�n���h����1
                        if (vinHandleInfoCd == 1 || vinHandleInfoCd == 2)
                        {
                            // VIN�R�[�h�̃n���h���ʒu��ݒ�(VIN�R�[�h�ƃ}�X�^�̒l���قȂ邽��)
                            HandleInfoCdRet posVin = vinHandleInfoCd == 1 ? HandleInfoCdRet.PositionLeft : HandleInfoCdRet.PositionRight;
                            para.HandleInfoCd = (int)posVin;

                            // �^�������őI������Ă��邷�ׂĂ̍s���r����
                            int pos = carInfoDataSet.CarModelInfo.HandleInfoCdColumn.Ordinal;
                            int state = carInfoDataSet.CarModelInfo.SelectionStateColumn.Ordinal;
                            HandleInfoCdRet posModel = HandleInfoCdRet.PositionError;
                            foreach (DataRow row in carInfoDataSet.CarModelInfo.Rows)
                            {
                                // �I������Ă��Ȃ��s�̓X�L�b�v����
                                if ((bool)row[state] != true)
                                    continue;

                                // �n���h���ʒu�����`�F�b�N����
                                HandleInfoCdRet posKind = (HandleInfoCdRet)row[pos];
                                if (posKind != HandleInfoCdRet.PositionRight && posKind != HandleInfoCdRet.PositionLeft)
                                    continue;

                                // �n���h���ʒu���r����
                                if (posModel == HandleInfoCdRet.PositionError)
                                {
                                    // �n���h���ʒu�����Z�b�g
                                    posModel = posKind;
                                }
                                else if ((posModel == HandleInfoCdRet.PositionRight && posKind == HandleInfoCdRet.PositionLeft) ||
                                    (posModel == HandleInfoCdRet.PositionLeft && posKind == HandleInfoCdRet.PositionRight))
                                {
                                    // �I�������ԗ����ɉE/���n���h�������݂��Ă����ꍇ
                                    // �����l�Ƃ��ăn���h�����i�����s��Ȃ��Ӗ���-1���Z�b�g
                                    // �����[�g����-1�̏ꍇ��WHERE��ɔ��f���Ȃ��悤�ɂȂ�
                                    para.HandleInfoCd = -1;
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (para.MakerCode == 81)
                {
                    // �u81(VW)�v�̏ꍇ 11Byte�ڂ𐶎Y�H��R�[�h�Ƃ��či�������ɒǉ�
                    para.VinCode = productNonum;
                    para.HandleInfoCd = 0;
                    para.ProductionFactoryCd = orgVinCode.Substring(10, 1);
                }
                else
                {
                    // �u80(BENZ)�v�E�u81(VW)�v�ȊO��VIN�R�[�h�i�����s��Ȃ�
                    // �u83(BMW)�v���܂߂���L�ȊO�̊O�Ԃ͂��̃��[�g
                    return;
                }
            }
            catch
            {
                // ��O��������VIN�R�[�h�i���s��Ȃ�
                para.VinCode = 0;
            }
            return;
        }
        // --- ADD 2013/03/27 ----------<<<<<
    }
}
