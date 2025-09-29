using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

using System.Threading;  // ADD 杍^ 2014/09/01 FOR Redmine#43289

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ������̓A�N�Z�X�N���X(���i�^�݌Ɂ^�P���^���z�֌W)
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������͂̐���S�ʂ��s���܂��B</br>
    /// <br>Programmer : 20056 ���n ���</br>
    /// <br>Date       : 2007.09.10</br>
    /// <br></br>
    /// <br>UpDate</br>
    /// <br>2007.09.10 20056 ���n ��� �V�K�쐬</br>
    /// <br>2009.06.23 21024 ���X�� �� MANTIS[0013598] ���i��ʂ�PMKEN01020E�̒�`���Q�Ƃ���悤�ɏC��</br>
    /// <br>2009/09/08 20056 ���n ��� MANTIS[0013973] �D��q�ɂ̎擾���_�R�[�h����ʋ��_����擾����悤�ɏC��</br>
    /// <br></br>
    /// <br>Update Note : 2009/10/19 ���M</br>
    /// <br>              PM.NS-3-A�EPM.NS�ێ�˗��A</br>
    /// <br>              PM.NS�ێ�˗��A��ǉ�</br>
    /// <br></br>
    /// <br>Update Note : 2009/11/25 21024 ���X�� ��</br>
    /// <br>              �E�����a�k�R�[�h�𕡐��I���E�Z�b�g�q���i�I�������������擾�ł���悤�ɏC��(MANTIS[0014690])</br>
    /// <br>              �E���i�������ʂ̉�ʕ\������a�k�R�[�h���o�l�V���l�̎d�l�ɂȂ�悤�ɏC���iMANTIS[0014671]</br>
    /// <br>Update Note : 2009/12/17 ���n ��� �ێ�˗��B�Ή�</br>
    /// <br>             MANTIS[14785] BL�R�[�h�K�C�h����W�����i�I�����s�����ꍇ���I�������W�����i��L���ɂ���</br>
    /// <br>Update Note : 2009/12/23 ���M</br>
    /// <br>              PM.NS-5-A�EPM.NS�ێ�˗��C</br>
    /// <br>              PM.NS�ێ�˗��C��ǉ�</br>
    /// <br>Update Note : 2010/01/27 ���M �S�����ǑΉ�</br>
    /// <br>              PM.NS�ێ�˗��S�����ǑΉ���ǉ�</br>
    /// <br>Update Note : 2010/02/26 ���n ��� </br>
    /// <br>              SCM�Ή�</br>
    /// <br>Update Note : 2010/03/12 ����� redmine#3773</br>
    /// <br>              �����v�Z�����̕s��Ή�</br>
    /// <br>Update Note : 2010/03/22 ���� redmine#4075</br>
    /// <br>              �����v�Z�����̕s��Ή�</br>
    /// <br>Update Note : 2010/04/02 21024 ���X�� ��</br>
    /// <br>              �E�����I���őI���������i��BL�R�[�h���A����BL�R�[�h�ɂȂ�s��̏C��(MANTIS[0015247])</br>
    /// <br>Update Note : 2010/04/12 ��� ���b</br>
    /// <br>              �������ʂ�QTY���������o�א��ɃZ�b�g����Ȃ����̏C��(�f�O���ׁ̈A2010/03/17���̍đg�ݍ��݁B�R�����g��2010/04/12)</br>
    /// <br>Update Note : 2010/05/04 ���C�� PM1007�E6������</br>
    /// <br>              ���s�҃`�F�b�N�A���͑q�Ƀ`�F�b�N��������ǉ�</br>
    /// <br>Update Note : 2010/05/17 30434 �H�� �b�D</br>
    /// <br>              �i���\���Ή�</br>
    /// <br>Update Note : 2010/06/02 杍^ PM.NS��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
    /// <br>Update Note : 2010/06/26 ����� </br>
    /// <br>              BL�R�[�h�ϊ������̃��W�b�N�̍폜</br>
    /// <br>Update Note: 2010/07/21 20056 ���n ��� </br>
    /// <br>             �p�i���͂ŕi���E���[�J�[�ύX���̖��׏��N���A�����ύX(�ꕔ���e���N���A���Ȃ�)</br>
    /// <br>Update Note: 2010/07/28 20056 ���n ��� </br>
    /// <br>             �������A�������A���P�������͂��ꂽ��ԂŁA���i�Čv�Z���|���q�b�g���Ȃ������ꍇ�A�������A�������A���P�����N���A����Ȃ����̑Ή�</br>
    /// <br>Update Note: 2010/07/29 20056 ���n ��� </br>
    /// <br>             �@�������܂��͌��P�������i�}�X�^�Őݒ肳��Ă���ꍇ�A���i�����Ō������A���P�����\������Ȃ����̑Ή�</br>
    /// <br>             �A�������ύX���A������񂪃N���A����錏�̑Ή�</br>
    /// <br>             �B�󒍓`�[���C���ďo�ŁA�s�ǉ����������s���Ǝ󒍐����ݒ肳��Ȃ����̑Ή�</br>
    /// <br>Update Note: 2010/09/19 杍^ </br>
    /// <br>             PM.NS��Q�E���ǑΉ��i�X�������[�X�Č��j</br>
    /// <br>Update Note: 2010/10/01 ���n ���</br>
    /// <br>             �p�i���͖��ׂŊ|���Z�o���\�Ƃ���</br>
    /// <br>Update Note: 2010/11/19 20056 ���n ���</br>
    /// <br>             �@���������ݒ肳��Ă����ԂŒ艿��ύX�����ꍇ�A���P�����X�V����Ȃ����̑Ή�</br>
    /// <br>               ���������F�艿���|���Z�o����Ă��Ȃ���ԂŒ艿��ύX�����ꍇ</br>
    /// <br>Update Note: 2011/02/16 22018 ��� ���b</br>
    /// <br>             �@�W�����i�[���Ő��ʕύX���ɕW�����i���ăZ�b�g����錏�̑Ή��B�i�ˍăZ�b�g���Ȃ��j</br>
    /// <br>             �A����͂Ŕ�������ύX��A�P��ڂɐ��ʕύX���ɔ��������ăZ�b�g����Ȃ����̑Ή��B�i�˂Q��ڈȍ~�Ɠ��l�ɍăZ�b�g����j</br>
    /// <br>             �B�W�����i�[���E�������[���E���P���[���ȊO�̂Ƃ����ʕύX����Ɣ��P�����[���ɂȂ錏�̑Ή��B�i�˔��P���͂��̂܂܂ɂ���j</br>
    /// <br>             �C��������ύX��AF5:�K�C�h�Ŋ�艿���\������Ȃ����̑Ή��B�i�˔��������ύX����Ă���艿��\������j</br>
    /// <br>             �D�W�����i�[���E�������[���ȊO����͌�A���ʂ�ύX���Ă����������ăZ�b�g����Ȃ����̑Ή��B�i�˔��������ăZ�b�g����j</br>
    /// <br>Update Note: 2011/03/10 20056 ���n ���</br>
    /// <br>              1)���q�����͂���̓`�[���C���ďo���A�ǉ������ŃJ���[�A�g�����A�N���̍i�����L���ƂȂ�悤�ɏC��</br>
    /// <br>Update Note: 2011/03/16 20056 ���n ���</br>
    /// <br>             SCM�Ή�</br>
    /// <br>              1)BL�R�[�h�����s��BL�R�[�h�Ŗ⍇���^�����f�[�^��W�J��A���ד��͂���Ɖ񓚑��M����Ȃ����̑Ή�</br>
    /// <br>Update Note: 2011/05/30 ������</br>
    /// <br>             ��L�����y�[���������擾����悤�ɕύX</br>
    /// <br>UpdateNote : 2011/07/06 杍^ ����S�̐ݒ�̔������ݒ莞�̑Ή�</br>
    /// <br>UpdateNote : 2011/07/11 杍^ Redmine#22876 ���P���̒[�������Ɋւ��Ă̏C��</br>
    /// <br>UpdateNote : 2011/07/13 ������ Redmine#22953 �W�����i���O�A����`�[���͂łO���Z�̃G���[���b�Z�[�W���\�����܂���</br>
    /// <br>                               Redmine#22773 [�������ݒ莞�敪���[����\��]�A�|���Ȃ��A�L�����y�[���l������0�̏ꍇ�̕s��C��</br>
    /// <br>UpdateNote : 2011/07/14 杍^ Redmine#22876 ���P���̒[�������Ɋւ��Ă̏C��</br>
    /// <br>Update Note: 2011/07/20 �A��1028,Redmine#22936 ����g</br>
    /// <br>             �d���E�o�׌㐔�\���敪(���׎Z�o��݌ɐ��\���敪)�ɂ��ďC��</br>
    /// <br>UpdateNote : 2011/08/12 杍^ Redmine#23554 �L�����y�[���̔����u�������A�l�����A�����z�v���ݒ肳��Ă���ꍇ�́A�|���}�X�^�̔����̐ݒ���N���A����悤�Ɏd�l�ύX�̑Ή�</br>
    /// <br>Update Note: 2011/08/15 杍^ Redmine#23554 �|���}�X�^�̔������ݒ肠��Ŋ��A�L�����y�[���̔����z�ݒ肠��̏ꍇ�A�������̓N���A�̑Ή�</br>
    /// <br>Update Note: 2011/08/20 �A��882 ���юR 10704766-00 </br>
    /// <br>             ���艿���\���̂�ǉ�</br>
    /// <br>Update Note: 2011/08/31 �A��721 Redmine#23887 ����g 10704766-00 </br>
    /// <br>             �����艿�̗p������d����ύX���s���ƁA���i�̍Ď擾�̕s����C������</br>
    /// <br>Update Note: 2011/09/01 �A��681 yangmj 10704766-00 </br>
    /// <br>             Redmine#23723 �񋟒艿�ƃ��[�U�[�艿����v���Ȃ��ꍇ�A�����F�̉��C</br>
    /// <br>UpdateNote : 2011/09/05 杍^ Redmine#23965 �̔��敪��ύX���̉��i�Ď擾�̃��b�Z�[�W�\���̑Ή�</br>   
    /// <br>UpdateNote : 2011/09/05 yangmj Redmine#23554 �L�����y�[���̔����u�������A�l�����A�����z�v���ݒ肳��Ă���ꍇ�́A�|���}�X�^�̔����̐ݒ���N���A����悤�Ɏd�l�ύX�̑Ή�</br>
    /// <br>UpdateNote : 2011/09/14 杍^ Redmine#25016 �񋟂̏����i�ԂŁA���������o�^����Ă��違�L�����y�[���������o�^����Ă���ꍇ�A���P�����󔒂ɂȂ�s���̏C��</br>
    /// <br>UpdateNote : 2011/09/16 杍^ Redmine#25195 ����`�[���͂Ŕ��P�����N���A����Ă��܂��̑Ή�</br>
    /// <br>UpdateNote : 2011/09/21 yangmj Redmine#25261 ���`�[���w�肵�Ă̕ԕi������̏C��</br>
    /// <br>UpdateNote : 2011/10/27 ���� Redmine#26293 ����`�[���́^PM���炢���Ȃ�񓚂���ꍇ�̂a�k�R�[�h�̉񓚕��@�̑Ή�</br>
    /// <br>Update Note: 2011/10/29 20056 ���n ���</br>
    /// <br>             ��Q�Ή�</br>
    /// <br>               1)�󒍓`�[���C���ďo�����ꍇ�A���z��񂪍Čv�Z�����</br>
    /// <br>                 ���󒍓`�[�C���ďo���A���i�̍Čv�Z���s��Ȃ��悤�ɏC��</br>
    /// <br>               2)���P���A�������A���P���A��������ύX���Ă������󒍂ɔ��f����Ȃ�</br>
    /// <br>                 ���󒍃f�[�^�������A���i�Čv�Z���s��Ȃ��悤�ɏC��</br>
    /// <br>                 �����������͎��A�󒍏��̉��i�Čv�Z���s��Ȃ��悤�ɏC��</br>
    /// <br>                 �����������͎��A������̉��i�Čv�Z���s��Ȃ��悤�ɏC��</br>
    /// <br>               3)�����󒍂ɔ̔��敪�����f����Ȃ�</br>
    /// <br>                 ���̔��敪���͎��Ɏ󒍏����X�V</br>    
    /// <br>UpdateNote : 2011/11/08 yangmj Redmine#26316 BL�R�[�h������QTY�����f����Ȃ��̑Ή�</br>
    /// <br>Update Note: 2011/12/28 ������</br>
    /// <br>�Ǘ��ԍ�   �F10707327-00 2012/01/25�z�M��</br>
    /// <br>             Redmine#27385�@����i�̑Ή�</br>
    /// <br>UpdateNote : 2012/01/16 30517 �Ė� �x��</br>
    /// <br>             SCM���ǁE���L�����Ή�</br>
    /// <br>UpdateNote : 2012/02/07 20056 ���n ���</br>
    /// <br>             SCM���ǁE���L�����Ή� 40���ȏ�J�b�g�Ή�</br>
    /// <br>Update Note: 2012/02/28 ���N�n��</br>
    /// <br>�Ǘ��ԍ�   : 10707327-00 2012/03/28�z�M��</br>
    /// <br>             Redmine#27385 �����̋��z���s���ɂ��Ă̑Ή�</br>
    /// <br>Update Note: 2012/04/09 yangmj</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 2012/05/24�z�M��</br>
    /// <br>             Redmine#29313   ����`�[���� ���i���i�̍Ď擾�Ŕ̔��敪�������l�ɖ߂�</br>
    /// <br>Update Note: 2012/06/15 �g�� �F��</br>
    /// <br>             ��Q�Ή� ��90</br>
    /// <br>             SCM��Q��171�C�����̃o�O�Ή��B</br>
    /// <br>Update Note: 2012/08/30 �e�c ���V</br>
    /// <br>             �d����R�[�h���N���A����Ă��܂����̏C���B</br>
    /// <br>Update Note: 2012/08/30 30745 �g�� �F��</br>
    /// <br>             2012/10���z�M�\��SCM��Q��10345�Ή� </br>
    /// <br>Update Note: 2012/09/05 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 2012/09/12�z�M��</br>
    /// <br>             �󏤕i�����荀�ڍĐݒ��i�Ԃ��ύX���ꂽ�ꍇ�͍s��Ȃ��悤�ɏC��</br>
    /// <br>Update Note: 2012/10/11 �e�c ���V</br>
    /// <br>             ���[�J�[�A�d����ύX�ɂ�蔭�����񂪃N���A����Ă��܂����̏C���B</br>
    /// <br>Update Note: 2012/10/19 �e�c ���V</br>
    /// <br>             ���[�J�[�A�d����ύX�ɂ�蔭�����񂪃N���A����Ă��܂����̍ďC���B</br>
    /// <br>Update Note: 2012/11/21 �� �B</br>
    /// <br>             �󒍃f�[�^�쐬���A���P���Ɍ��P�����Z�b�g����Ă��܂���Q�̏C��</br>
    /// <br>Update Note: 2013/02/13 �e�c ���V</br>
    /// <br>             ���q���ɂ���Č������Ȃ����BL�R�[�h�����ł��Ȃ����Ƃ������Q�̏C��</br>
    /// <br>Update Note: 2013/02/20 �{�{ ����</br>
    /// <br>             �o�א�=0���󒍐�>0�̏ꍇ�͎󒍐��ŎZ�o</br>
    /// <br>Update Note: 2013/02/22 �g�� �F��</br>
    /// <br>             2013/03/06�z�M ��108�Ή����̕s��Ή� </br>
    /// <br>Update Note: 2013/04/04 30744 ���� ����q</br>
    /// <br>             SCM��Q��10504�Ή�</br>
    /// <br>Update Note: 2013/04/06 20056 ���n ���</br>
    /// <br>             SCM��Q��10504�Ή��ɂ��f�O���Ή�</br>
    /// <br>               1.�i�Ԍ����ɂĕ��i��񂪎擾�ł��Ȃ������ꍇ�����i���N���X���Q�Ƃ���ׁA�s���ȓ���ƂȂ�</br>
    /// <br>               2.���i�����͌�ABL�R�[�h��ύX����ƕύX���BL�R�[�h�ŉ񓚂���Ȃ����̑Ή�</br>
    /// <br>               3.���i�����͌�A�s������s���Ɛ����BL�R�[�h���񓚂���Ȃ����̑Ή�</br>
    /// <br>Update Note: 2013/04/10 �{�{ ����</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>             �q�ɐؑ�(F8)���Ɍ����̍Ď擾���s��</br>
    /// <br>Update Note: 2013/06/17 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 10902175-00</br>
    /// <br>             2013/06/18�z�M�@�V�X�e���e�X�g��Q��43</br>
    /// <br>Update Note: 2013/06/17 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 10902175-00</br>
    /// <br>             �V�K�o�^���O�o�͑Ή�</br>
    /// <br>Update Note: 2013/07/09 �{�{ ����</br>
    /// <br>�Ǘ��ԍ�   : 10902175-00 �d�|�ꗗ ��2000</br>
    /// <br>             �v�㖾�ׂ̏ꍇ�͒P���Čv�Z���̏��i�E�݌ɏ��̍Đݒ���s��Ȃ��悤�ɏC��</br>
    /// <br>Update Note: 2013/07/10 ���N</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>             Redmine#37769��BL�ύX��BL��ٰ�ߺ��ށA��E�����ނ̏����X�V����</br>
    /// <br>Update Note: 2013/07/25 liusy</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>             #34551 �󒍓`�[��`�[�ďo�����גǉ����ĉ��i���ڕۑ��s���̏C��</br>
    /// <br>Update Note: 2013/08/07 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 10902175-00</br>
    /// <br>             Redmine#39699 �s�l�����������ꍇ�̏���Œ[����������������</br>
    /// <br>Update Note: 2013/09/13 30744 ���� ����q</br>
    /// <br>             SCM�d�|�ꗗ��10571�Ή� PCC���Аݒ�}�X�^�̎Q�Ƒq�ɃR�[�h��ǉ�</br>
    /// <br>Update Note: K2013/09/20 �{�{ ����</br>
    /// <br>             ���t�^�o�� �{�Бq�ɗD�揇�ʑΉ�</br>
    /// <br>Update Note: K2013/10/11 �{�{ ����</br>
    /// <br>             ���t�^�o�� �{�ЊǗ��q�ɊY���`�F�b�N���őΏۑq�ɃR�[�h��Trim���ă`�F�b�N</br>
    /// <br>Update Note: 2013/11/05 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 10904597-00</br>
    /// <br>             �d�|�ꗗ��1492(��594)�Ή�</br>
    /// <br>             �u���i������̃t�H�[�J�X�ʒu�v���ڒǉ����A�󒍓`�[����͂��₷������</br>
    /// <br>Update Note: 2013/12/19 ��</br>
    /// <br>�Ǘ��ԍ�   : 10904597-00</br>
    /// <br>           : Redmine#41550 ����`�[���͏����8%���őΉ�</br>
    /// <br>Update Note: 2014/01/23 ��</br>
    /// <br>�Ǘ��ԍ�   : 10904597-00</br>
    /// <br>           : Redmine#41771 ����`�[���͏����8%���őΉ��B</br>
    /// <br>Update Note: 2014/04/02 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 10904597-00</br>
    /// <br>           : �d�|�ꗗ��2346�Ή�</br>
    /// <br>             ����ł̎Z�o�����������Ȃ��Q�B</br>
    /// <br>Update Note: 2013/12/10 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 10904597-00</br>
    /// <br>             �����艿�󎚑Ή�</br>
    /// <br>Update Note: 2014/01/15 �{�{ ����</br>
    /// <br>�Ǘ��ԍ�   : 10904597-00�@�����艿�󎚑Ή�</br>
    /// <br>             �������擾�������C��</br>
    /// <br>Update Note: 2014/01/29 �{�{ ����</br>
    /// <br>�Ǘ��ԍ�   : 10904597-00�@�����艿�󎚑Ή�</br>
    /// <br>             �Z�b�g�i�̏ꍇ���e�̏�������o�^</br>
    /// <br>Update Note: 2014/03/17 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 10904597-00</br>
    /// <br>             �d�|�ꗗ��2326�Ή�</br>
    /// <br>             �i�Ԍ����ŕi�ԓ��͂��󒍐����͌�A�i�Ԃ��C�����o�^���s���ƁA</br>
    /// <br>             �C�������s�̎󒍓`�[�̖��ׂ��o�^����Ȃ���Q�̑Ή��B</br>
    /// <br>Update Note: 2014/04/03 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 10904597-00</br>
    /// <br>             �i���ۏؕ�Redmine#1319</br>
    /// <br>             ����`�[�C�����A���גǉ���ɔ������ς���Əo�א����N���A�����</br>
    /// <br>Update Note: K2014/02/09 yangyi</br>
    /// <br>�Ǘ��ԍ�   : 10970681-00 �O�����a����ʌʑΉ�</br>
    /// <br>           : ����`�[���͂̉��ǑΉ�</br>
    /// <br>Update Note: 2014/03/20 ��</br>
    /// <br>�Ǘ��ԍ�   : Redmine#42174 �X�V���̕ύX</br>
    /// <br>           : ����`�[���͂̒P�������ǑΉ�</br>
    /// <br>Update Note: 2014/07/14 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 11070100-00</br>
    /// <br>             �d�|�ꗗ��2487�Ή�</br>
    /// <br>             ���i�̍ĎZ�o���s�����ۂɁA�����艿���N���A������Q�Ή�</br>
    /// <br>Update Note: 2014/09/01 杍^</br>
    /// <br>�Ǘ��ԍ�   : 11070184-00�@SCM��Q�Ή� ��190�@RedMine#43289</br>
    /// <br>         �@: SF����⍇���̎��q���E���l�𔄏�`�[���͂ɕ\������</br>
    /// <br>Update Note: 2015/01/30  30744 ���� ����q</br>
    /// <br>�Ǘ��ԍ�   : 11070266-00</br>
    /// <br>           : SCM������ ���Y�N���A�ԑ�ԍ��Ή�</br>
    /// <br>Update Note: 2015/02/10  30745 �g��</br>
    /// <br>�Ǘ��ԍ�   : 11070266-00</br>
    /// <br>           : SCM������ �񓚔[���敪�Ή�</br>
    /// <br>Update Note: 2015/03/18  31065 �L��</br>
    /// <br>�Ǘ��ԍ�   : 11070266-00</br>
    /// <br>           : SCM������ ���[�J�[��]�������i�Ή�</br>
    /// <br>Update Note: 2015/04/06 30757 ���X�� �M�p</br>
    /// <br>�Ǘ��ԍ�   : 11070149-00</br>
    /// <br>             �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή�</br>
    /// <br>Update Note: 2015/04/16 30757 ���X�� �M�p</br>
    /// <br>�Ǘ��ԍ�   : 11070149-00</br>
    /// <br>             �Г���Q��684 �̔��敪�A�q�ɃR�[�h��ύX����ƕ\���敪�Ɋւ�炸�D�Ǖi�̕W�����i���\��������Q�̑Ή�</br>
    /// <br>Update Note: 2015/09/03 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 11170139-00</br>
    /// <br>             �Г���Q��707 �̔��敪��ύX�����ꍇ�ɔ������Čv�Z����Ȃ���Q�̑Ή�</br>
    /// <br>             �Г���Q��711 �|���}�X�^���ݒ肳��Ă���ꍇ�ɁA�o�א��̕ύX�̎d���ŋ��z���ς��B</br>
    /// <br>Update Note: 2015/10/28 ����</br>
    /// <br>�Ǘ��ԍ�   : 11170187-00</br>
    /// <br>             Redmine#47537 �`�[�C�����[�h�A�[�i���̍ő喾�א��𒴂��Ēǉ����͂����</br>
    /// <br>             ��ʂƓ`�[�Ŗ��׌������s��v�̏�Q��Ή�����</br>
    /// <br>Update Note: 2015/12/09 �i�N</br>
    /// <br>�Ǘ��ԍ�   : 11170204-00</br>
    /// <br>           : Redmine#47787 �ő�s�𒴂��Ė��ׂ�ǉ�����ƁA��ʂɕ\������Ȃ����i���o�^������Q�̏C��</br>
    /// <br>Update Note: 2021/03/16 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11770032-00</br>
    /// <br>           : PMKOBETSU-4133 ����`�[���͌���0�~��Q�̑Ή�</br>
    /// <br>Update Note: K2021/07/22 ���O</br>
    /// <br>�Ǘ��ԍ�   : 11601223-00</br>
    /// <br>             PMKOBETSU-4148 ����0�~��Q�̑Ή�</br>  
    /// </remarks>
    public partial class SalesSlipInputAcs
    {
        // --- ADD m.suzuki 2011/02/16 ---------->>>>>
        // �W�����i�Đݒ�Ȃ��t���O
        private bool _noneResettingListPriceFlag = false;
        // ���P���Đݒ�Ȃ��t���O
        private bool _noneResettingUnitCostFlag = false;
        // --- ADD m.suzuki 2011/02/16 ----------<<<<<

        private IDictionary<int, int> _originalBLGoodsCodeMap = new Dictionary<int, int>(); // ADD 2011/10/27

        public double _salesUnitPriceForCheck; // ADD 2011/09/05
        public double _salesRateForCheck; // ADD 2011/09/05

        // 2012/06/15 ADD T.Yoshioka 90 ---------------->>>>>>>>>>>>>>>>>>>>>>>>> 
        /// <summary>
        /// ���i�������ʕۊǗp
        /// </summary>
        private PartsInfoDataSet _partsInfo = new PartsInfoDataSet();
        // 2012/06/15 ADD T.Yoshioka 90 ----------------<<<<<<<<<<<<<<<<<<<<<<<<<

        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        public Int32 _CustAnalysCode1 = 0; // ���Ӑ敪�̓R�[�h1
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<


        // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- >>>
        /// <summary>�ԗ�����\���p</summary>
        private const string PGID_XML = "MAHNB01001U";
        //Thread���A�ԗ����SOLT��
        private const string CARINFOSOLT = "CARINFOSOLT";
        private LocalDataStoreSlot carInfoSolt = null;
        // ADD 杍^ 2014/09/01 FOR Redmine#43289 --- <<<
        // ------ ADD 2021/03/16 ���O FOR PMKOBETSU-4133-------->>>>
        private const int CtZero = 0;
        /// <summary> ���O���e</summary> 
        private const string LogMessage = "{0} ==> {1}";
        /// <summary> ���\�b�h��</summary> 
        private const string MethodNameUnit = "CalculateUnitPrice";
        /// <summary>���[�J�[�R�[�h</summary>
        private const string CtMakeCode = "MakeCd={0},";
        /// <summary>�i��</summary>
        private const string CtGoodsNo = "GoodsNo={0},";
        /// <summary>�i��</summary>
        private const string CtGoodsName = "GoodsNm={0},";
        /// <summary>BL���i�R�[�h</summary>
        private const string CtBLGoodsCode = "BLGoodsCd={0},";
        /// <summary>���i�啪�ރR�[�h</summary>
        private const string CtGoodsLGroup = "GoodsLGp={0},";
        /// <summary>���i�����ރR�[�h</summary>
        private const string CtGoodsMGroup = "GoodsMGp={0},";
        /// <summary>BL�O���[�v�R�[�h</summary>
        private const string CtBLGroupCode = "BLGroupCd={0},";
        /// <summary>���i�|�������N(�w��)</summary>
        private const string CtGoodsRateRank = "GoodsRateRk={0},";
        /// <summary>���Е��ރR�[�h</summary>
        private const string CtEnterpriseGanreCode = "EntGanreCd={0},";
        /// <summary>���i�|���O���[�v�R�[�h</summary>
        private const string CtGoodsRateGrpCd = "GoodsRateGrpCd={0},";
        /// <summary>�d����R�[�h</summary>
        private const string CtSupplierCd = "SupplierCd={0},";
        /// <summary>���_</summary>
        private const string CtSectionCode = "SectionCd={0},";
        /// <summary>���Ӑ�R�[�h</summary>
        private const string CtCustomerCode = "CustomerCd={0},";
        /// <summary>�S���҃R�[�h</summary>
        private const string CtEmployeeCode = "EmployeeCd={0},";
        /// <summary>�����</summary>
        private const string CtSalesDate = "SalesDate={0}";
        /// <summary>Sleep���s���[�h(0:���s����� 1:���s����Ȃ�)</summary>
        private const int CtSleepMode = 1;
        // ���O�o�͕��i
        OutLogCommon LogCommon;
        // ------ ADD 2021/03/16 ���O FOR PMKOBETSU-4133--------<<<<<

        #region �����i���݌�
        /// <summary>
        /// �w�肵�����i�A�݌ɏ��̃��X�g�����ɁA���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i�A�݌ɏ����ꊇ�ݒ肵�܂��B�i�݌Ƀx�[�X�j
        /// </summary>
        /// <param name="activeSalesRowNo">�A�N�e�B�u����s�ԍ�</param>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="goodsUnitDataList">���i���I�u�W�F�N�g���X�g</param>
        /// <param name="stockList">�݌ɏ��I�u�W�F�N�g���X�g</param>
        /// <param name="settingSalesRowNoList">�ݒ肵������s�ԍ��̃��X�g</param>
        /// <param name="setDefaultRowCount">true:�o�א���1(�ԕi�̏ꍇ��-1)�������ݒ肷�� false:�o�א���0�Ƃ���</param>
        /// <param name="overWriteRow">true:�s�㏑������ false:�s�㏑���Ȃ�</param>
        /// <remarks>�R�[���F�݌Ɍ���</remarks>
        public void SalesDetailRowGoodsSetting_StockBase(int activeSalesRowNo, int salesRowNo, List<GoodsUnitData> goodsUnitDataList, List<Stock> stockList, out List<int> settingSalesRowNoList, bool setDefaultRowCount, bool overWriteRow)
        {
            settingSalesRowNoList = new List<int>();
            List<int> deletingSalesRowNoList = new List<int>();
            List<int> goodsDiscountRowList = new List<int>();
            SalesInputDataSet.SalesDetailRow activeRow = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, activeSalesRowNo);

            int settingCount = this._salesSlipInputConstructionAcs.DataInputCountValue - this.GetAlreadyInputRowCount();
            int iCount = 0;
            int iRowNo = 1;
            while (true)
            {
                if (iCount >= settingCount) break;

                SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, iRowNo);
                iRowNo++;

                if (row != null)
                {
                    if (overWriteRow == false)
                    {
                        // ���͍ςݍs�͐ݒ�ΏۊO
                        if (!string.IsNullOrEmpty(row.GoodsName))
                        {
                            continue;
                        }
                        else
                        {
                            settingSalesRowNoList.Add(row.SalesRowNo);
                            iCount++;
                        }
                    }
                    else
                    {
                        settingSalesRowNoList.Add(row.SalesRowNo);
                        iCount++;
                    }
                }
                else
                {
                    break;
                }
                
                if (activeRow.EditStatus == ctEDITSTATUS_GoodsDiscount) goodsDiscountRowList.Add(row.SalesRowNo);

                if (stockList.Count <= settingSalesRowNoList.Count) break;

                deletingSalesRowNoList.Add(row.SalesRowNo);

                row.AcceptChanges(); // �ύX���e�R�~�b�g
            }

            // ���㖾�׍s�N���A����
            this.ClearSalesDetailRow(deletingSalesRowNoList);
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            Stock stock = new Stock();

            for (int i = 0; i < settingSalesRowNoList.Count; i++)
            {
                if (stockList.Count <= i) break;

                stock = stockList[i];
                int targetStockRowNo = settingSalesRowNoList[i];
                goodsUnitData = this.GetGoodsUnitDataFromList(stock.GoodsNo, stock.GoodsMakerCd, goodsUnitDataList);
                int salesSlipCdDtl = (goodsDiscountRowList.Contains(settingSalesRowNoList[i])) ? (int)SalesSlipCdDtl.Discount : (int)SalesSlipCdDtl.Sales;
                // ���i�A�݌ɏ��ݒ菈��
                this.SalesDetailRowGoodsSetting(targetStockRowNo, goodsUnitData.Clone(), stock, setDefaultRowCount, salesSlipCdDtl, this._searchPartsMode);
            }
        }

        //>>>2010/07/21
        /// <summary>
        /// �w�肵�����i�A�݌ɏ��̃��X�g�����ɁA���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i�A�݌ɏ����ꊇ�ݒ肵�܂��B�i���i�x�[�X�j
        /// </summary>
        /// <param name="activeSalesRowNo">�A�N�e�B�u����s�ԍ�</param>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="goodsUnitDataList">���i���I�u�W�F�N�g���X�g</param>
        /// <param name="stockList">�݌ɏ��I�u�W�F�N�g���X�g</param>
        /// <param name="settingSalesRowNoList">�ݒ肵������s�ԍ��̃��X�g</param>
        /// <param name="setDefaultRowCount">true:�o�א���1(�ԕi�̏ꍇ��-1)�������ݒ肷�� false:�o�א���0�Ƃ���</param>
        /// <param name="overWriteRow">true:�s�㏑������ false:�s�㏑���Ȃ�</param>
        /// <param name="emptyInfoSetting">true:�󏤕i���Z�b�g false:�ʏ폤�i���Z�b�g</param>
        //>>>2010/07/21
        public void SalesDetailRowGoodsSetting_GoodsBase(int activeSalesRowNo, int salesRowNo, List<GoodsUnitData> goodsUnitDataList, List<Stock> stockList, out List<int> settingSalesRowNoList, bool setDefaultRowCount, bool overWriteRow)
        {
            // --- UPD 2012/09/05 Y.Wakita ---------->>>>>
            //this.SalesDetailRowGoodsSetting_GoodsBase(activeSalesRowNo, salesRowNo, goodsUnitDataList, stockList, out settingSalesRowNoList, setDefaultRowCount, overWriteRow, false);
            this.SalesDetailRowGoodsSetting_GoodsBase(activeSalesRowNo, salesRowNo, goodsUnitDataList, stockList, out settingSalesRowNoList, setDefaultRowCount, overWriteRow, false, false);
            // --- UPD 2012/09/05 Y.Wakita ----------<<<<<
        }
        //<<<2010/07/21

        /// <summary>
        /// �w�肵�����i�A�݌ɏ��̃��X�g�����ɁA���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i�A�݌ɏ����ꊇ�ݒ肵�܂��B�i���i�x�[�X�j
        /// </summary>
        /// <param name="activeSalesRowNo">�A�N�e�B�u����s�ԍ�</param>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="goodsUnitDataList">���i���I�u�W�F�N�g���X�g</param>
        /// <param name="stockList">�݌ɏ��I�u�W�F�N�g���X�g</param>
        /// <param name="settingSalesRowNoList">�ݒ肵������s�ԍ��̃��X�g</param>
        /// <param name="setDefaultRowCount">true:�o�א���1(�ԕi�̏ꍇ��-1)�������ݒ肷�� false:�o�א���0�Ƃ���</param>
        /// <param name="overWriteRow">true:�s�㏑������ false:�s�㏑���Ȃ�</param>
        /// <param name="emptyInfoSetting">true:�󏤕i���Z�b�g false:�ʏ폤�i���Z�b�g</param>
        /// <remarks>
        /// <br>Update Note: 2015/10/28 ����</br>
        /// <br>�Ǘ��ԍ�   : 11170187-00</br>
        /// <br>           : Redmine#47537 �`�[�C�����[�h�A�[�i���̍ő喾�א��𒴂��Ēǉ����͂����</br>
        /// <br>           : ��ʂƓ`�[�Ŗ��׌������s��v�̏�Q��Ή�����</br>
        /// <br>Update Note: 2015/12/09 �i�N</br>
        /// <br>�Ǘ��ԍ�   : 11170204-00</br>
        /// <br>           : Redmine#47787 �ő�s�𒴂��Ė��ׂ�ǉ�����ƁA��ʂɕ\������Ȃ����i���o�^������Q�̏C��</br>
        /// </remarks>
        //>>>2010/07/21
        //public void SalesDetailRowGoodsSetting_GoodsBase(int activeSalesRowNo, int salesRowNo, List<GoodsUnitData> goodsUnitDataList, List<Stock> stockList, out List<int> settingSalesRowNoList, bool setDefaultRowCount, bool overWriteRow)
        // --- UPD 2012/09/05 Y.Wakita ---------->>>>>
        //public void SalesDetailRowGoodsSetting_GoodsBase(int activeSalesRowNo, int salesRowNo, List<GoodsUnitData> goodsUnitDataList, List<Stock> stockList, out List<int> settingSalesRowNoList, bool setDefaultRowCount, bool overWriteRow, bool emptyInfoSetting)
        public void SalesDetailRowGoodsSetting_GoodsBase(int activeSalesRowNo, int salesRowNo, List<GoodsUnitData> goodsUnitDataList, List<Stock> stockList, out List<int> settingSalesRowNoList, bool setDefaultRowCount, bool overWriteRow, bool emptyInfoSetting, bool saveValueSetting)
        // --- UPD 2012/09/05 Y.Wakita ----------<<<<<
        //<<<2010/07/21
        {
            settingSalesRowNoList = new List<int>();
            List<int> deletingSalesRowNoList = new List<int>();
            List<int> goodsDiscountRowList = new List<int>();
            SalesInputDataSet.SalesDetailRow activeRow = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, activeSalesRowNo);

            int settingCount = this._salesSlipInputConstructionAcs.DataInputCountValue - this.GetAlreadyInputRowCount();
            for (int i = 0; i < settingCount; i++)
            {
                SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo + i);

                // �s�����݂��Ȃ��ꍇ�͐V�K�ɒǉ�����
                if (row == null)
                {
                    if (this._salesSlip.SalesSlipNum != ctDefaultSalesSlipNum) break;// ADD 2015/10/28 ���� For Redmine#47537

                    // --- ADD 2015/12/09 �i�N For Redmine#47787 �ő�s�𒴂��Ė��ׂ�ǉ�����ƁA��ʂɕ\������Ȃ����i���o�^������Q�̏C�� ---------->>>>>
                    //�󒍌v��A�ݏo�v��A���όv��ASCM�ԕi�̏ꍇ�A��ʕ\���̍ő喾�א��𒴂��Ēǉ����͂���ƁA������(���׃f�[�^)�ɒǉ����Ȃ��B
                    if ((this._salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ShipmentAddUp) ||
                       (this._salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AcceptAnOrderAddUp) ||
                       (this._salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_EstimateAddUp)||
                       (this._salesSlip.InquiryNumber != 0 && this._salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods))
                    {
                        break;
                    }
                    // --- ADD 2015/12/09 �i�N For Redmine#47787 �ő�s�𒴂��Ė��ׂ�ǉ�����ƁA��ʂɕ\������Ȃ����i���o�^������Q�̏C�� ----------<<<<<

                    this.AddSalesDetailRow();

                    row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo + i);

                    settingSalesRowNoList.Add(row.SalesRowNo);
                }
                else
                {
                    if (overWriteRow == false)
                    {
                        // ���͍ςݍs�͐ݒ�ΏۊO
                        if (!string.IsNullOrEmpty(row.GoodsName))
                        {
                            continue;
                        }
                        else
                        {
                            // ���׃N���A�ΏۊO
                            if (this.SearchPartsModeProperty == SearchPartsMode.GoodsNoSearch)
                            {
                                if (!string.IsNullOrEmpty(row.GoodsNo))
                                {
                                    settingSalesRowNoList.Add(row.SalesRowNo);
                                    continue;
                                }
                            }
                            else
                            {
                                if (row.BLGoodsCode != 0)
                                {
                                    settingSalesRowNoList.Add(row.SalesRowNo);
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        settingSalesRowNoList.Add(row.SalesRowNo);
                    }
                }
                if (activeRow.EditStatus == ctEDITSTATUS_GoodsDiscount) goodsDiscountRowList.Add(row.SalesRowNo);

                if (goodsUnitDataList.Count <= settingSalesRowNoList.Count) break;

                deletingSalesRowNoList.Add(row.SalesRowNo);

                row.AcceptChanges(); // �ύX���e�R�~�b�g
            }

            // ���㖾�׍s�N���A����
            this.ClearSalesDetailRow(deletingSalesRowNoList);
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            Stock stock = new Stock();

            for (int i = 0; i < settingCount; i++)
            {
                // UPD 2010/09/19 --- >>>
                //if (goodsUnitDataList.Count <= i) break;
                if (goodsUnitDataList.Count == 0 || goodsUnitDataList.Count <= i) break;
                if (settingSalesRowNoList.Count == 0 || settingSalesRowNoList.Count <= i) break;
                // UPD 2010/09/19 --- <<<

                goodsUnitData = goodsUnitDataList[i];
                stock = (goodsUnitData.SelectedWarehouseCode != null) ? this.GetStock(goodsUnitData, goodsUnitData.SelectedWarehouseCode.Trim()) : this.GetStock(goodsUnitData);

                int targetSalesRowNo = settingSalesRowNoList[i];
                int salesSlipCdDtl = (goodsDiscountRowList.Contains(settingSalesRowNoList[i])) ? (int)SalesSlipCdDtl.Discount : (int)SalesSlipCdDtl.Sales;
                // ���i�A�݌ɏ��ݒ菈��
                //>>>2010/07/21
                //this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, SearchPartsMode.GoodsNoSearch);
                // --- UPD 2013/11/05 Y.Wakita ---------->>>>>
                //// --- UPD 2012/09/05 Y.Wakita ---------->>>>>
                ////this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, SearchPartsMode.GoodsNoSearch, emptyInfoSetting);
                //this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, SearchPartsMode.GoodsNoSearch, emptyInfoSetting, saveValueSetting);
                //// --- UPD 2012/09/05 Y.Wakita ----------<<<<<
                //�����t�H�[�J�X�ʒu���󒍐��̏ꍇ�͏o�א��ɒl���Z�b�g���Ȃ�
                if (this.CheckFocusPositionAfterBLCodeSearch(targetSalesRowNo))
                {
                    this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, false, salesSlipCdDtl, SearchPartsMode.GoodsNoSearch, emptyInfoSetting, saveValueSetting);
                }
                else
                {
                    this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, SearchPartsMode.GoodsNoSearch, emptyInfoSetting, saveValueSetting);
                }
                // --- UPD 2013/11/05 Y.Wakita ----------<<<<<
                //<<<<2010/07/21
            }
        }

        /// <summary>
        /// �w�肵�����i�A�݌ɏ��̃��X�g�����ɁA���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i�A�݌ɏ����ꊇ�ݒ肵�܂��B�i���i�x�[�X��BL�R�[�h������p�j
        /// </summary>
        /// <param name="activeSalesRowNo">�A�N�e�B�u����s�ԍ�</param>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="stockList">�݌ɏ��I�u�W�F�N�g���X�g</param>
        /// <param name="settingSalesRowNoList">�ݒ肵������s�ԍ����X�g</param>
        /// <param name="setDefaultRowCount">true:�o�א���1(�ԕi�̏ꍇ��-1)�������ݒ肷�� false:�o�א���0�Ƃ���</param>
        /// <param name="overWriteRow">true:�s�㏑������ false:�s�㏑���Ȃ�</param>
        /// <remarks>
        /// <br>Update Note: 2015/10/28 ����</br>
        /// <br>�Ǘ��ԍ�   : 11170187-00</br>
        /// <br>             Redmine#47537 �`�[�C�����[�h�A�[�i���̍ő喾�א��𒴂��Ēǉ����͂����</br>
        /// <br>             ��ʂƓ`�[�Ŗ��׌������s��v�̏�Q��Ή�����</br>
        /// <br>Update Note: 2015/12/09 �i�N</br>
        /// <br>�Ǘ��ԍ�   : 11170204-00</br>
        /// <br>           : Redmine#47787 �ő�s�𒴂��Ė��ׂ�ǉ�����ƁA��ʂɕ\������Ȃ����i���o�^������Q�̏C��</br>
        /// </remarks>
        // 2009/11/25 >>>
        //public void SalesDetailRowGoodsSetting_GoodsBaseForBLCodeSearch(int activeSalesRowNo, int salesRowNo, List<GoodsUnitData> goodsUnitDataList, List<Stock> stockList, out List<int> settingSalesRowNoList, bool setDefaultRowCount, bool overWriteRow)
        public void SalesDetailRowGoodsSetting_GoodsBaseForBLCodeSearch(int activeSalesRowNo, int salesRowNo, List<GoodsUnitData> goodsUnitDataList, List<Stock> stockList, out List<int> settingSalesRowNoList, bool setDefaultRowCount, bool overWriteRow, int blGoodsCode)
        // 2009/11/25 <<<
        {
            settingSalesRowNoList = new List<int>();
            List<int> deletingSalesRowNoList = new List<int>();
            List<int> goodsDiscountRowList = new List<int>();
            SalesInputDataSet.SalesDetailRow activeRow = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, activeSalesRowNo);

            if (this._salesSlipInputConstructionAcs.DataInputCountValue < salesRowNo) return;

            int settingCount = this._salesSlipInputConstructionAcs.DataInputCountValue - this.GetAlreadyInputRowCount();
            for (int i = 0; i < this._salesSlipInputConstructionAcs.DataInputCountValue; i++)
            //for (int i = 0; i < settingCount; i++)
            //for (int i = 0; i < goodsUnitDataList.Count + this.GetAlreadyInputRowCount(); i++)
            {
                //if (this._salesSlipInputConstructionAcs.DataInputCountValue <= i) break;
                if (settingCount <= i) break;

                SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo + i);

                // �s�����݂��Ȃ��ꍇ�͐V�K�ɒǉ�����
                if (row == null)
                {
                    if (this._salesSlip.SalesSlipNum != ctDefaultSalesSlipNum) break;// ADD 2015/10/28 ���� For Redmine#47537

                    // --- ADD 2015/12/09 �i�N For Redmine#47787 �ő�s�𒴂��Ė��ׂ�ǉ�����ƁA��ʂɕ\������Ȃ����i���o�^������Q�̏C�� ---------->>>>>
                    //�󒍌v��A�ݏo�v��A���όv��ASCM�ԕi�̂̏ꍇ�A��ʕ\���̍ő喾�א��𒴂��Ēǉ����͂���ƁA������(���׃f�[�^)�ɒǉ����Ȃ��B
                    if ((this._salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_ShipmentAddUp) ||
                       (this._salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_AcceptAnOrderAddUp) ||
                       (this._salesSlip.InputMode == SalesSlipInputAcs.ctINPUTMODE_SalesSlip_EstimateAddUp) ||
                       (this._salesSlip.InquiryNumber != 0 && this._salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods))
                    {
                        break;
                    }
                    // --- ADD 2015/12/09 �i�N For Redmine#47787 �ő�s�𒴂��Ė��ׂ�ǉ�����ƁA��ʂɕ\������Ȃ����i���o�^������Q�̏C�� ----------<<<<<

                    this.AddSalesDetailRow();

                    row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo + i);

                    settingSalesRowNoList.Add(row.SalesRowNo);
                }
                else
                {
                    if (overWriteRow == false)
                    {
                        // ���͍ςݍs�͐ݒ�ΏۊO
                        if (!string.IsNullOrEmpty(row.GoodsName))
                        {
                            continue;
                        }
                        else
                        {
                            settingSalesRowNoList.Add(row.SalesRowNo);
                        }
                    }
                    else
                    {
                        settingSalesRowNoList.Add(row.SalesRowNo);
                    }
                }
                if (activeRow.EditStatus == ctEDITSTATUS_GoodsDiscount) goodsDiscountRowList.Add(row.SalesRowNo);

                if (goodsUnitDataList.Count <= settingSalesRowNoList.Count) break;

                deletingSalesRowNoList.Add(row.SalesRowNo);

                row.AcceptChanges(); // �ύX���e�R�~�b�g
            }

            // ���㖾�׍s�N���A����
            this.ClearSalesDetailRow(deletingSalesRowNoList);
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            Stock stock = new Stock();
            for (int i = 0; i < settingCount; i++)
            //for (int i = 0; i < goodsUnitDataList.Count; i++)
            {
                if (goodsUnitDataList.Count <= i) break;
                if (settingSalesRowNoList.Count <= i) break;// ADD 2015/10/28 ���� For Redmine#47537

                goodsUnitData = goodsUnitDataList[i];
                stock = (goodsUnitData.SelectedWarehouseCode != null) ? this.GetStock(goodsUnitData, goodsUnitData.SelectedWarehouseCode.Trim()) : this.GetStock(goodsUnitData);
                int targetSalesRowNo = settingSalesRowNoList[i];
                int salesSlipCdDtl = (goodsDiscountRowList.Contains(settingSalesRowNoList[i])) ? (int)SalesSlipCdDtl.Discount : (int)SalesSlipCdDtl.Sales;
                // ���i�A�݌ɏ��ݒ菈��
                // 2009/11/25 >>>
                //this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, SearchPartsMode.BLCodeSearch);
                this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, SearchPartsMode.BLCodeSearch, blGoodsCode);
                // 2009/11/25 <<<
            }
        }

        /// <summary>
        /// �w�肵�����i�E�݌ɏ��I�u�W�F�N�g�����ɁA���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i�E�݌ɏ���ݒ肵�܂��B
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="goodsUnitData">���i���I�u�W�F�N�g</param>
        /// <param name="stock">�݌ɏ��I�u�W�F�N�g</param>
        /// <param name="setDefaultRowCount">true:�o�א���1(�ԕi�̏ꍇ��-1)�������ݒ肷�� false:�o�א���0�Ƃ���</param>
        public void SalesDetailRowGoodsSetting(int salesRowNo, GoodsUnitData goodsUnitData, Stock stock, bool setDefaultRowCount)
        {
            this.SalesDetailRowGoodsSetting(salesRowNo, goodsUnitData, stock, setDefaultRowCount, (int)SalesSlipCdDtl.Sales, this._searchPartsMode);
        }

        // 2009/11/25 Add >>>
        /// <summary>
        /// �w�肵�����i�E�݌ɏ��I�u�W�F�N�g�����ɁA���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i�E�݌ɏ���ݒ肵�܂��B
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="goodsUnitData">���i���I�u�W�F�N�g</param>
        /// <param name="stock">�݌ɏ��I�u�W�F�N�g</param>
        /// <param name="setDefaultRowCount">true:�o�א���1(�ԕi�̏ꍇ��-1)�������ݒ肷�� false:�o�א���0�Ƃ���</param>
        /// <param name="salesSlipCdDtl">����`�[�敪(����)</param>
        /// <param name="searchPartsMode">���i�������[�h</param>
        public void SalesDetailRowGoodsSetting(int salesRowNo, GoodsUnitData goodsUnitData, Stock stock, bool setDefaultRowCount, int salesSlipCdDtl, SearchPartsMode searchPartsMode)
        {
            this.SalesDetailRowGoodsSetting(salesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, searchPartsMode, 0);
        }
        // 2009/11/25 Add <<<

        //>>>2010/07/21
        /// <summary>
        /// �w�肵�����i�E�݌ɏ��I�u�W�F�N�g�����ɁA���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i�E�݌ɏ���ݒ肵�܂��B
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="goodsUnitData">���i���I�u�W�F�N�g</param>
        /// <param name="stock">�݌ɏ��I�u�W�F�N�g</param>
        /// <param name="setDefaultRowCount">true:�o�א���1(�ԕi�̏ꍇ��-1)�������ݒ肷�� false:�o�א���0�Ƃ���</param>
        /// <param name="salesSlipCdDtl">����`�[�敪(����)</param>
        /// <param name="searchPartsMode">���i�������[�h</param>
        // --- UPD 2012/09/05 Y.Wakita ---------->>>>>
        //public void SalesDetailRowGoodsSetting(int salesRowNo, GoodsUnitData goodsUnitData, Stock stock, bool setDefaultRowCount, int salesSlipCdDtl, SearchPartsMode searchPartsMode, bool emptyInfoSetting)
        public void SalesDetailRowGoodsSetting(int salesRowNo, GoodsUnitData goodsUnitData, Stock stock, bool setDefaultRowCount, int salesSlipCdDtl, SearchPartsMode searchPartsMode, bool emptyInfoSetting, bool saveValueSetting)
        // --- UPD 2012/09/05 Y.Wakita ----------<<<<<
        {
            // --- UPD 2012/09/05 Y.Wakita ---------->>>>>
            //this.SalesDetailRowGoodsSetting(salesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, searchPartsMode, 0, emptyInfoSetting);
            this.SalesDetailRowGoodsSetting(salesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, searchPartsMode, 0, emptyInfoSetting, saveValueSetting);
            // --- UPD 2012/09/05 Y.Wakita ----------<<<<<
        }
        //<<<2010/07/21

        //>>>2010/07/21
        /// <summary>
        /// �w�肵�����i�E�݌ɏ��I�u�W�F�N�g�����ɁA���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i�E�݌ɏ���ݒ肵�܂��B
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="goodsUnitData">���i���I�u�W�F�N�g</param>
        /// <param name="stock">�݌ɏ��I�u�W�F�N�g</param>
        /// <param name="setDefaultRowCount">true:�o�א���1(�ԕi�̏ꍇ��-1)�������ݒ肷�� false:�o�א���0�Ƃ���</param>
        /// <param name="salesSlipCdDtl">����`�[�敪(����)</param>
        /// <param name="searchPartsMode">���i�������[�h</param>
        /// <param name="blGoodsCode">�a�k�R�[�h</param>
        public void SalesDetailRowGoodsSetting(int salesRowNo, GoodsUnitData goodsUnitData, Stock stock, bool setDefaultRowCount, int salesSlipCdDtl, SearchPartsMode searchPartsMode, int blGoodsCode)
        {
            // --- UPD 2012/09/05 Y.Wakita ---------->>>>>
            //this.SalesDetailRowGoodsSetting(salesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, searchPartsMode, blGoodsCode, false);
            this.SalesDetailRowGoodsSetting(salesRowNo, goodsUnitData, stock, setDefaultRowCount, salesSlipCdDtl, searchPartsMode, blGoodsCode, false, false);
            // --- UPD 2012/09/05 Y.Wakita ----------<<<<<
        }
        //<<<2010/07/21
        
        //>>>2010/07/21
        ///// <summary>
        ///// �w�肵�����i�E�݌ɏ��I�u�W�F�N�g�����ɁA���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i�E�݌ɏ���ݒ肵�܂��B
        ///// </summary>
        ///// <param name="salesRowNo">����s�ԍ�</param>
        ///// <param name="goodsUnitData">���i���I�u�W�F�N�g</param>
        ///// <param name="stock">�݌ɏ��I�u�W�F�N�g</param>
        ///// <param name="setDefaultRowCount">true:�o�א���1(�ԕi�̏ꍇ��-1)�������ݒ肷�� false:�o�א���0�Ƃ���</param>
        ///// <param name="salesSlipCdDtl">����`�[�敪(����)</param>
        ///// <param name="searchPartsMode">���i�������[�h</param>
        //// 2009/11/25 >>>
        ////public void SalesDetailRowGoodsSetting(int salesRowNo, GoodsUnitData goodsUnitData, Stock stock, bool setDefaultRowCount, int salesSlipCdDtl, SearchPartsMode searchPartsMode)
        ///// <br>Update Note: 2010/01/27 ���� ������ύX�����ꍇ�̏��i���Ď擾���A�݌ɏ����X�V���Ȃ��悤�ɕύX����Ή�</br>
        //public void SalesDetailRowGoodsSetting(int salesRowNo, GoodsUnitData goodsUnitData, Stock stock, bool setDefaultRowCount, int salesSlipCdDtl, SearchPartsMode searchPartsMode, int blGoodsCode)
        //// 2009/11/25 <<<
        /// <summary>
        /// �w�肵�����i�E�݌ɏ��I�u�W�F�N�g�����ɁA���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i�E�݌ɏ���ݒ肵�܂��B
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="goodsUnitData">���i���I�u�W�F�N�g</param>
        /// <param name="stock">�݌ɏ��I�u�W�F�N�g</param>
        /// <param name="setDefaultRowCount">true:�o�א���1(�ԕi�̏ꍇ��-1)�������ݒ肷�� false:�o�א���0�Ƃ���</param>
        /// <param name="salesSlipCdDtl">����`�[�敪(����)</param>
        /// <param name="searchPartsMode">���i�������[�h</param>
        /// <param name="blGoodsCode">�a�k�R�[�h</param>
        /// <param name="emptyInfoSetting">�󏤕i���Z�b�g�敪(true:�󏤕i���Z�b�g false:�ʏ폤�i���Z�b�g)</param>
        // --- UPD 2012/09/05 Y.Wakita ---------->>>>>
        //public void SalesDetailRowGoodsSetting(int salesRowNo, GoodsUnitData goodsUnitData, Stock stock, bool setDefaultRowCount, int salesSlipCdDtl, SearchPartsMode searchPartsMode, int blGoodsCode, bool emptyInfoSetting)
        public void SalesDetailRowGoodsSetting(int salesRowNo, GoodsUnitData goodsUnitData, Stock stock, bool setDefaultRowCount, int salesSlipCdDtl, SearchPartsMode searchPartsMode, int blGoodsCode, bool emptyInfoSetting, bool saveValueSetting)
        // --- UPD 2012/09/05 Y.Wakita ----------<<<<<
        //<<<2010/07/21
        {
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row != null)
            {
                // ADD 2013/07/09 T.Miyamoto ------------------------------>>>>>
                if ((row.SalesSlipDtlNumSrc != 0) && (row.AcptAnOdrStatusSrc != row.AcptAnOdrStatus))
                {
                    return;
                }
                // ADD 2013/07/09 T.Miyamoto ------------------------------<<<<<
                #region �ޔ�
                // 2009/11/25 >>>
                //int svBLGoodsCode = ( row.BLGoodsCode != 0 ) ? row.BLGoodsCode : goodsUnitData.BLGoodsCode;
                int svBLGoodsCode = goodsUnitData.BLGoodsCode;
                if ((GoodsKind)goodsUnitData.GoodsKindResolved == GoodsKind.Parent || (GoodsKind)goodsUnitData.GoodsKindResolved == GoodsKind.Join)
                {
                    if (( blGoodsCode != 0 )) svBLGoodsCode = blGoodsCode;
                }
                // 2009/11/25 <<<
                BLGoodsCdUMnt blGoods = this._salesSlipInputInitDataAcs.GetBLGoodsInfo_FromBLGoods(svBLGoodsCode);
                string svBLGoodsFullName = string.Empty;
                if ((searchPartsMode == SearchPartsMode.BLCodeSearch) && (blGoods != null)) svBLGoodsFullName = blGoods.BLGoodsFullName;
                
                DateTime stockDate = row.StockDate;
                string partySalesSlipNum = row.PartySalesSlipNum;
                Guid dtlRelationGuid = row.DtlRelationGuid;

                double svAcceptAnOrderCntDisplay = row.AcceptAnOrderCntDisplay;
                double svAcceptAnOrderCnt = row.AcceptAnOrderCnt;
                double svAcceptAnOrderCntDefault = row.AcceptAnOrderCntDefault;
                double svAcptAnOdrAdjustCnt = row.AcptAnOdrAdjustCnt;
                double svAcptAnOdrRemainCnt = row.AcptAnOdrRemainCnt;
                double svShipmentCntDisplay = row.ShipmentCntDisplay;
                double svShipmentCnt = row.ShipmentCnt;

                //>>>2010/07/21
                string goodsNameKana = row.GoodsNameKana;
                string blGoodsFullName = row.BLGoodsFullName;
                string prtBLGoodsName = row.PrtBLGoodsName;
                int blGroupCode = row.BLGroupCode;
                string blGroupName = row.BLGroupName;
                int goodsMGroup = row.GoodsMGroup;
                string goodsMGroupName = row.GoodsMGroupName;
                int goodsLGroup = row.GoodsLGroup;
                string goodsLGroupName = row.GoodsLGroupName;
                string makerKanaName = row.MakerKanaName;
                int rateBLGoodsCode = row.RateBLGoodsCode;
                //<<<2010/07/21
                #endregion

                // --- ADD 2010/01/27 -------------->>>>>
                string warehouseCode = row.WarehouseCode; //�q�ɃR�[�h
                string warehouseName = row.WarehouseName; //�q�ɖ���
                string warehouseShelfNo = row.WarehouseShelfNo; //�I��
                double supplierStock = row.SupplierStock; //�݌ɐ�
                double supplierStockDisplay = row.SupplierStockDisplay; //�݌ɐ�(��ʕ\��)
                int salesOrderDivCd = row.SalesOrderDivCd; //����݌Ɏ��敪
                // --- ADD 2010/01/27 --------------<<<<<

                //>>>2011/03/16
                int inqRowNumber = row.InqRowNumber;
                int inqRowNumDerivedNo = row.InqRowNumDerivedNo;
                //<<<2011/03/16

                // --- ADD 2012/08/30 Y.Wakita ---------->>>>>
                int svSupplierCdForStock = row.SupplierCdForStock;  // �d����R�[�h(�d�����)
                string svSupplierSnm = row.SupplierSnm;             // �d���旪��
                // --- ADD 2012/08/30 Y.Wakita ----------<<<<<

                // --- DEL 2012/10/19 Y.Wakita ---------->>>>>
                //// --- ADD 2012/10/11 Y.Wakita ---------->>>>>
                //string svBoCode = row.BoCode;										// BO�敪
                //int svSupplierCdForOrder = row.SupplierCdForOrder; 					// ������
                //string svSupplierSnmForOrder = row.SupplierSnmForOrder; 			// �����於��
                //double svAcceptAnOrderCntForOrder = row.AcceptAnOrderCntForOrder; 	// ������
                //string svUOEDeliGoodsDiv = row.UOEDeliGoodsDiv; 					// �[�i�敪
                //string svDeliveredGoodsDivNm = row.DeliveredGoodsDivNm; 			// �[�i�敪����
                //string svDeliveredGoodsDivNmSave = row.DeliveredGoodsDivNmSave; 	// �[�i�敪���́i�ۑ��p�j
                //string svFollowDeliGoodsDiv = row.FollowDeliGoodsDiv; 				// H�[�i�敪
                //string svFollowDeliGoodsDivNm = row.FollowDeliGoodsDivNm; 			// H�[�i�敪����
                //string svFollowDeliGoodsDivNmSave = row.FollowDeliGoodsDivNmSave; 	// H�[�i�敪���́i�ۑ��p�j
                //string svUOEResvdSection = row.UOEResvdSection; 					// �w�苒�_
                //string svUOEResvdSectionNm = row.UOEResvdSectionNm; 				// �w�苒�_����
                //string svUOEResvdSectionNmSave = row.UOEResvdSectionNmSave; 		// �w�苒�_���́i�ۑ��p�j
                //// --- ADD 2012/10/11 Y.Wakita ----------<<<<<
                // --- DEL 2012/10/19 Y.Wakita ----------<<<<<

                // --- ADD 2013/12/10 Y.Wakita ---------->>>>>
                int svCmpltSalesRowNo = row.CmpltSalesRowNo;            // ����-BL���i�R�[�h
                int svCmpltGoodsMakerCd = row.CmpltGoodsMakerCd;        // ����-���[�J�[
                string svCmpltGoodsName = row.CmpltGoodsName;           // ����-���i�ԍ�
                double svCmpltSalesUnPrcFl = row.CmpltSalesUnPrcFl;     // ����-�艿
                // --- ADD 2013/12/10 Y.Wakita ----------<<<<<
                // --- ADD 2014/07/14 Y.Wakita ---------->>>>>
                string svGoodsNo = row.GoodsNo;             // ���i�ԍ�
                // --- ADD 2014/07/14 Y.Wakita ----------<<<<<

                // --- ADD 2014/04/03 Y.Wakita ---------->>>>>
                bool acceptAnOrderCntClearFlg = false;
                if (setDefaultRowCount == false)
                {
                    // �i�Ԃ��ύX���ꂽ�ꍇ
                    if (row.GoodsNo != goodsUnitData.GoodsNo)
                        acceptAnOrderCntClearFlg = true;
                }
                // --- ADD 2014/04/03 Y.Wakita ----------<<<<<

                this.ClearSalesDetailRow(row);

                row.SalesSlipCdDtl = salesSlipCdDtl;
                row.StockDate = stockDate;
                row.PartySalesSlipNum = partySalesSlipNum;
                row.DtlRelationGuid = dtlRelationGuid;
                
                //>>>2011/03/16
                row.InqRowNumber = inqRowNumber;
                row.InqRowNumDerivedNo = inqRowNumDerivedNo;
                //<<<2011/03/16

                if (goodsUnitData != null)
                {
                    #region ���i���
                    //--------------------------------------------
                    // ���i���
                    //--------------------------------------------
                    GoodsUnitData tempGoodsUnitData = goodsUnitData.Clone();
                    GoodsInfoKey goodsInfoKey = new GoodsInfoKey(tempGoodsUnitData.GoodsNo, tempGoodsUnitData.GoodsMakerCd);
                    if (!this._goodsUnitDataInfo.ContainsKey(goodsInfoKey))
                    {
                        this._goodsUnitDataInfo.Add(goodsInfoKey, tempGoodsUnitData);
                    }

                    row.GoodsMakerCd = goodsUnitData.GoodsMakerCd;					// ���[�J�[�R�[�h
                    row.MakerName = goodsUnitData.MakerName;						// ���[�J�[����
                    row.MakerKanaName = goodsUnitData.MakerKanaName;                // ���[�J�[�J�i����
                    row.GoodsNo = goodsUnitData.GoodsNo;						    // �i��
                    row.GoodsName = goodsUnitData.GoodsName;                        // �i��
                    row.GoodsNameKana = goodsUnitData.GoodsNameKana;                // �i���J�i
                    row.BLGoodsCode = goodsUnitData.BLGoodsCode;                    // BL�R�[�h
                    row.BLGoodsFullName = goodsUnitData.BLGoodsFullName;            // BL�R�[�h����(�S�p)
                    row.GoodsLGroup = goodsUnitData.GoodsLGroup;                    // ���i�啪�ރR�[�h
                    row.GoodsLGroupName = goodsUnitData.GoodsLGroupName;            // ���i�啪�ޖ���
                    row.GoodsMGroup = goodsUnitData.GoodsMGroup;                    // ���i�����ރR�[�h
                    row.GoodsMGroupName = goodsUnitData.GoodsMGroupName;            // ���i�����ޖ���
                    row.BLGroupCode = goodsUnitData.BLGroupCode;                    // BL�O���[�v�R�[�h
                    row.BLGroupName = goodsUnitData.BLGroupName;                    // BL�O���[�v�R�[�h����
                    row.GoodsRateRank = goodsUnitData.GoodsRateRank;                // ���i�|�������N
                    row.TaxationDivCd = goodsUnitData.TaxationDivCd;                // �ېŋ敪
                    //row.GoodsKindCode = goodsUnitData.GoodsKindCode;                // ���i����  // DEL 2010/09/19
                    row.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;    // ���Е��ރR�[�h
                    row.EnterpriseGanreName = goodsUnitData.EnterpriseGanreName;    // ���Е��ޖ���
                    //row.SalesCode = goodsUnitData.SalesCode;                      // �̔��敪�R�[�h// DEL 2012/04/09 yangmj redmine#29313
                    //row.SalesCdNm = goodsUnitData.SalesCodeName;                  // �̔��敪����// DEL 2012/04/09 yangmj redmine#29313
                    //--- ADD 2012/04/09 yangmj redmine#29313 ----->>>>>
                    if (!_salesCodeChgFlag)
                    {
                        row.SalesCode = goodsUnitData.SalesCode;                        // �̔��敪�R�[�h
                        row.SalesCdNm = goodsUnitData.SalesCodeName;                    // �̔��敪����
                    }
                    //--- ADD 2012/04/09 yangmj redmine#29313 -----<<<<<

                    //row.SupplierCd = goodsUnitData.SupplierCd;                      // �d����R�[�h  // DEL 2010/09/19
                    row.SupplierCdForStock = goodsUnitData.SupplierCd;              // �d����R�[�h(�d�����)
                    row.SupplierSnm = goodsUnitData.SupplierSnm;                    // �d���旪��

                    // ADD 2010/09/19 --- >>>
                    if (!this._clearFlgForMaker)
                    {
                        row.GoodsKindCode = goodsUnitData.GoodsKindCode;
                        row.SupplierCd = goodsUnitData.SupplierCd;
                    }
                    // ADD 2010/09/19 --- <<<

                    // ��������ݒ�(�������)
                    UOESupplier uoeSupplier;

                    // --- ADD 2012/10/19 Y.Wakita ---------->>>>>
                    int code = goodsUnitData.SupplierCd;
                    if (goodsUnitData.SupplierCd == 0)
                    {
                        code = row.SupplierCd;
                    }
                    // --- ADD 2012/10/19 Y.Wakita ----------<<<<<

                    // --- UPD 2012/10/19 Y.Wakita ---------->>>>>
                    ////>>>2010/07/01
                    ////int st = this._uoeSupplierAcs.Read(out uoeSupplier, this._enterpriseCode, goodsUnitData.SupplierCd, this._salesSlip.SectionCode);
                    //int st = this._uoeSupplierAcs.ReadCache(out uoeSupplier, this._enterpriseCode, goodsUnitData.SupplierCd, this._salesSlip.SectionCode);
                    ////<<<2010/07/01
                    int st = this._uoeSupplierAcs.ReadCache(out uoeSupplier, this._enterpriseCode, code, this._salesSlip.SectionCode);
                    // --- UPD 2012/10/19 Y.Wakita ----------<<<<<

                    if (st == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        row.SupplierCdForOrder = uoeSupplier.UOESupplierCd;         // ������R�[�h
                        row.SupplierSnmForOrder = uoeSupplier.UOESupplierName;      // �����於��
                        // --- ADD 2012/10/11 Y.Wakita ---------->>>>>
                        row.BoCode = uoeSupplier.BoCode; 										// BO�敪
                        row.UOEDeliGoodsDiv = uoeSupplier.UOEDeliGoodsDiv; 						// �[�i�敪
                        row.UOEResvdSection = uoeSupplier.UOEResvdSection; 						// �w�苒�_
                        // --- ADD 2012/10/11 Y.Wakita ----------<<<<<
                    }
                    // --- ADD 2012/10/19 Y.Wakita ---------->>>>>
                    else
                    {
                        // �L���b�V������Ă��Ȃ��ꍇ�́A�����l�ݒ�
                        uoeSupplier = new UOESupplier();
                        this.SettingUOEOrderDtlRowFromUOESupplier(salesRowNo, uoeSupplier);

                        row.SupplierCdForOrder = 0;
                        row.SupplierSnmForOrder = string.Empty;
                        row.BoCode = ctDefaultBoCode;
                        row.AcceptAnOrderCntForOrder = 0;
                        row.UOEDeliGoodsDiv = string.Empty;
                        row.DeliveredGoodsDivNm = string.Empty;
                        row.DeliveredGoodsDivNmSave = string.Empty;
                        row.FollowDeliGoodsDiv = string.Empty;
                        row.FollowDeliGoodsDivNm = string.Empty;
                        row.FollowDeliGoodsDivNmSave = string.Empty;
                        row.UOEResvdSection = string.Empty;
                        row.UOEResvdSectionNm = string.Empty;
                        row.UOEResvdSectionNmSave = string.Empty;
                    }
                    // --- ADD 2012/10/19 Y.Wakita ----------<<<<<
                    // 2009/11/25 Add >>>
                    // �����Ŏg�p�����R�[�h�ƕ��i��BL�R�[�h���قȂ�ꍇ

                    // 2010/04/02 Del >>>
                    //if ((blGoodsCode != 0)) goodsUnitData.SearchBLCode = blGoodsCode;�@//ADD 2009/12/23   

                    // goodsUnitData.SearchBLCode�́A�������i��I�������ꍇ�̂݃Z�b�g���ėǂ�
                    // �D�Ǖ��i��I�������ꍇ�́A���т��D�Ǖ��i�̂a�k�R�[�h�Ŏ��
                    // 2010/04/02 Del <<<
                    bool blGoodsCodeChanged = ((goodsUnitData.SearchBLCode != 0) && (goodsUnitData.BLGoodsCode != goodsUnitData.SearchBLCode));
                    if (blGoodsCodeChanged)
                    {
                        GoodsUnitData wkGoodsUnitData = goodsUnitData.Clone();

                        // ���т͌���BL�R�[�h�ŏW�v����
                        wkGoodsUnitData.BLGoodsCode = wkGoodsUnitData.SearchBLCode;
                        _salesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref wkGoodsUnitData, false);

                        row.BLGoodsCode = wkGoodsUnitData.BLGoodsCode;                    // BL�R�[�h
                        row.BLGoodsFullName = wkGoodsUnitData.BLGoodsFullName;            // BL�R�[�h����(�S�p)
                        row.GoodsLGroup = wkGoodsUnitData.GoodsLGroup;                    // ���i�啪�ރR�[�h
                        row.GoodsLGroupName = wkGoodsUnitData.GoodsLGroupName;            // ���i�啪�ޖ���
                        row.GoodsMGroup = wkGoodsUnitData.GoodsMGroup;                    // ���i�����ރR�[�h
                        row.GoodsMGroupName = wkGoodsUnitData.GoodsMGroupName;            // ���i�����ޖ���
                        row.BLGroupCode = wkGoodsUnitData.BLGroupCode;                    // BL�O���[�v�R�[�h
                        row.BLGroupName = wkGoodsUnitData.BLGroupName;                    // BL�O���[�v�R�[�h����
                        row.GoodsRateRank = wkGoodsUnitData.GoodsRateRank;                // ���i�|�������N
                        row.SalesCode = wkGoodsUnitData.SalesCode;                        // �̔��敪�R�[�h
                        row.SalesCdNm = wkGoodsUnitData.SalesCodeName;                    // �̔��敪����
                    }
                    // 2009/11/25 Add <<<
                    
                    row.RateBLGoodsCode = goodsUnitData.BLGoodsCode;                // BL���i�R�[�h�i�|���j
                    row.RateBLGoodsName = goodsUnitData.BLGoodsFullName;            // BL���i�R�[�h���́i�|���j
                    row.RateGoodsRateGrpCd = goodsUnitData.GoodsRateGrpCode;        // ���i�|���O���[�v�R�[�h�i�|���j
                    row.RateGoodsRateGrpNm = goodsUnitData.GoodsRateGrpName;        // ���i�|���O���[�v���́i�|���j
                    row.RateBLGroupCode = goodsUnitData.BLGroupCode;                // BL�O���[�v�R�[�h�i�|���j
                    row.RateBLGroupName = goodsUnitData.BLGroupName;                // BL�O���[�v���́i�|���j
                    row.CanTaxDivChange = false;									// �ېŔ�ېŋ敪�ύX�\�t���O

                    if ((this._salesSlipInputInitDataAcs.GetSalesTtlSt().PrtBLGoodsCodeDiv == 0) || // ����pBL�R�[�h�敪(0:���i 1:����)
                        (searchPartsMode == SearchPartsMode.GoodsNoSearch))
                    {
                        // 2009/11/25 >>>
                        //row.PrtBLGoodsCode = goodsUnitData.BLGoodsCode;
                        //row.PrtBLGoodsName = goodsUnitData.BLGoodsFullName;
                        row.PrtBLGoodsCode = row.BLGoodsCode;
                        row.PrtBLGoodsName = row.BLGoodsFullName;
                        // 2009/11/25 <<<
                    }
                    else
                    {
                        row.PrtBLGoodsCode = svBLGoodsCode;
                        row.PrtBLGoodsName = svBLGoodsFullName;
                    }

                    //>>>2010/06/26
                    ////>>>2010/02/26
                    //// BL�R�[�h�ϊ�
                    //if ((this._salesSlip.OnlineKindDiv == (int)SalesSlipInputAcs.OnlineKindDiv.SCM) &&
                    //    (goodsUnitData.BLGoodsCodeChange != 0))
                    //{
                    //    row.PrtBLGoodsCode = goodsUnitData.BLGoodsCodeChange;
                    //}
                    ////<<<2010/02/26
                    //<<<2010/06/26

                    if (salesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount)
                    {
                        row.EditStatus = ctEDITSTATUS_GoodsDiscount;					// �ύX�\�X�e�[�^�X
                    }
                    else
                    {
                        row.EditStatus = ctEDITSTATUS_AllOK;							// �ύX�\�X�e�[�^�X
                    }

                    double targetCount = 1;
                    double qty = this.GetQty(goodsUnitData);
                    if (qty != 0) targetCount = qty;

                    switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlip.AcptAnOdrStatus)
                    {
                        case SalesSlipInputAcs.AcptAnOdrStatusState.Estimate: // ����
                            {
                                if (this._salesSlip.EstimateDivide == (int)EstimateDivide.Estimate)
                                {
                                    // �ʏ팩��
                                    if (setDefaultRowCount)
                                    {
                                        int sign = (row.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount) ? -1 : 1;
                                        row.ShipmentCntDisplay = targetCount * sign;
                                        sign = (this._salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) ? -1 : 1;
                                        row.ShipmentCnt = row.ShipmentCntDisplay * sign; // �o�א�
                                    }
                                }
                                else
                                {
                                    // �P������
                                    row.ShipmentCntDisplay = 0;
                                    row.ShipmentCnt = row.ShipmentCntDisplay;
                                }
                                break;
                            }
                        case SalesSlipInputAcs.AcptAnOdrStatusState.Sales: // ����
                        case SalesSlipInputAcs.AcptAnOdrStatusState.Shipment: // �o��
                            {
                                if (setDefaultRowCount)
                                {
                                    int sign = (row.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount) ? -1 : 1;
                                    row.ShipmentCntDisplay = targetCount * sign;
                                    sign = (this._salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) ? -1 : 1;
                                    row.ShipmentCnt = row.ShipmentCntDisplay * sign; // �o�א�
                                }
                                // --- ADD 2014/03/17 Y.Wakita ---------->>>>>
                                else
                                {
                                    // --- ADD 2014/04/03 Y.Wakita ---------->>>>>
                                    if (acceptAnOrderCntClearFlg)
                                    {
                                        // �i�Ԃ��ύX���ꂽ�ꍇ�A�N���A����B
                                        // --- ADD 2014/04/03 Y.Wakita ----------<<<<<
                                    svAcceptAnOrderCntDisplay = 0;
                                    svAcceptAnOrderCnt = 0;
                                    svAcceptAnOrderCntDefault = 0;
                                    svAcptAnOdrAdjustCnt = 0;
                                    svAcptAnOdrRemainCnt = 0;
                                    svShipmentCntDisplay = 0;
                                    svShipmentCnt = 0;
                                        // --- ADD 2014/04/03 Y.Wakita ---------->>>>>
                                    }
                                    // --- ADD 2014/04/03 Y.Wakita ----------<<<<<
                                }
                                // --- ADD 2014/03/17 Y.Wakita ----------<<<<<
                                break;
                            }
                        //>>>2010/09/27
                        case SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder: // ��
                            {
                                if (setDefaultRowCount)
                                {
                                    int sign = (row.SalesSlipCdDtl == (int)SalesSlipInputAcs.SalesSlipCdDtl.Discount) ? -1 : 1;
                                    row.AcceptAnOrderCntDisplay = targetCount * sign;
                                    sign = (this._salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) ? -1 : 1;
                                    row.AcceptAnOrderCnt = row.AcceptAnOrderCntDisplay * sign; // �o�א�

                                    // �󒍏��ݒ�
                                    this.SettingSalesDetailAcceptAnOrder(row.SalesRowNo);

                                    SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = this._salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);
                                    acptAnOdrRow.ShipmentCntDisplay = row.AcceptAnOrderCntDisplay;

                                    // ���ʐݒ菈��
                                    this.SettingAcptAnOdrDetailRowShipmentCnt(row.SalesRowNo);
                                }
                                break;
                            }
                        //<<<2010/09/27
                    }

                    if ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlip.AcptAnOdrStatus != SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder) // 2010/09/27
                    { // 2010/09/27
                        if (setDefaultRowCount)
                        {
                            row.AcceptAnOrderCntDisplay = 0; // �󒍐�
                            row.AcceptAnOrderCnt = 0; // �󒍐�
                            row.AcceptAnOrderCntDefault = 0;
                            row.AcptAnOdrAdjustCnt = 0; // �󒍒�����
                            row.AcptAnOdrRemainCnt = 0; // �󒍎c��
                        }
                        else
                        {
                            row.AcceptAnOrderCntDisplay = svAcceptAnOrderCntDisplay;
                            row.AcceptAnOrderCnt = svAcceptAnOrderCnt;
                            row.AcceptAnOrderCntDefault = svAcceptAnOrderCntDefault;
                            row.AcptAnOdrAdjustCnt = svAcptAnOdrAdjustCnt;
                            row.AcptAnOdrRemainCnt = svAcptAnOdrRemainCnt;
                            row.ShipmentCntDisplay = svShipmentCntDisplay;
                            row.ShipmentCnt = svShipmentCnt;
                        }
                    } //<<<2010/09/27
                    // --- ADD 2014/04/03 Y.Wakita ---------->>>>>
                    else
                    {
                        if (setDefaultRowCount == false)
                        {
                            row.AcceptAnOrderCntDisplay = svAcceptAnOrderCntDisplay;
                            row.AcceptAnOrderCnt = svAcceptAnOrderCnt;
                            row.AcceptAnOrderCntDefault = svAcceptAnOrderCntDefault;
                            row.AcptAnOdrAdjustCnt = svAcptAnOdrAdjustCnt;
                            row.AcptAnOdrRemainCnt = svAcptAnOdrRemainCnt;
                            row.ShipmentCntDisplay = svShipmentCntDisplay;
                            row.ShipmentCnt = svShipmentCnt;
                        }
                    }
                    // --- ADD 2014/04/03 Y.Wakita ----------<<<<<

                    row.ShipmentCntDefForChk = row.ShipmentCnt; // �o�א������l�i�ύX�`�F�b�N�p�j
                    row.AcceptAnOrderCntDefForChk = row.AcceptAnOrderCnt; // �󒍐������l�i�ύX�`�F�b�N�p�j

                    //>>>2012/02/07
                    //// 2012/01/16 Add >>>
                    //row.GoodsSpecialNote = goodsUnitData.GoodsSpecialNote;
                    //// 2012/01/16 Add <<<
                    row.GoodsSpecialNote = goodsUnitData.GoodsSpecialNote;
                    // --- UPD 2013/06/17 Y.Wakita ---------->>>>>
                    //if (goodsUnitData.GoodsSpecialNote.Length > 40) row.GoodsSpecialNote = goodsUnitData.GoodsSpecialNote.Substring(0, 40);
                    if (goodsUnitData.SetSpecialNote.Length != 0)
                        // �Z�b�g�i
                        row.GoodsSpecialNote = goodsUnitData.SetSpecialNote;
                    if (row.GoodsSpecialNote.Length > 40) row.GoodsSpecialNote = row.GoodsSpecialNote.Substring(0, 40);
                    // --- UPD 2013/06/17 Y.Wakita ----------<<<<<
                    //<<<2012/02/07
                    #endregion

                    #region �݌ɏ��
                    //--------------------------------------------
                    // �݌ɏ��
                    //--------------------------------------------
                    //List<string> warehouseList = new List<string>();
                    //warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.SectWarehouseCd, this._salesSlip.CustWarehouseCd, 0);
                    //if ((stock != null) && (warehouseList.Contains(stock.WarehouseCode)))
                    // ---------- UPD 2010/01/27 ---------->>>>>>>>>>
                    //������ύX�����ꍇ�̏��i���Ď擾���A�݌ɏ����X�V���Ȃ�
                    if (!this._salesSlip.StockUpdateFlag) // ADD 2010/01/27
                    {
                        if (stock != null)
                        {
                            this.CacheStockInfo(stock);

                            row.WarehouseCode = stock.WarehouseCode;
                            row.WarehouseName = stock.WarehouseName;
                            row.WarehouseShelfNo = stock.WarehouseShelfNo;
                            row.SupplierStock = stock.ShipmentPosCnt;
                            row.SalesOrderDivCd = (int)SalesOrderDivCd.Stock; // ����݌Ɏ��敪(0:��� 1:�݌�)
                            //row.SupplierStockDisplay = row.SupplierStock - row.ShipmentCntDisplay;   //DEL 2011/07/20
                            row.SupplierStockDisplay = row.SupplierStock;          //ADD 2011/07020
                        }
                        else
                        {
                            row.SupplierStock = 0;
                            row.SalesOrderDivCd = (int)SalesOrderDivCd.NonStock; // ����݌Ɏ��敪(0:��� 1:�݌�)
                            row.SupplierStockDisplay = 0;
                        }
                    }
                    else
                    {
                        // --- ADD 2010/01/27 -------------->>>>>
                        row.WarehouseCode = warehouseCode;
                        row.WarehouseName = warehouseName;
                        row.WarehouseShelfNo = warehouseShelfNo;
                        row.SupplierStock = supplierStock;
                        row.SalesOrderDivCd = salesOrderDivCd;
                        row.SupplierStockDisplay = supplierStockDisplay;
                        // --- ADD 2010/01/27 --------------<<<<<
                    }
                    // ---------- UPD 2010/01/27 ----------<<<<<<<<<<
                    #endregion

                    #region ���Ӑ�|���O���[�v�R�[�h
                    row.CustRateGrpCode = this.GetCustRateGroupCode(row.GoodsMakerCd); // ���Ӑ�|���O���[�v�R�[�h
                    #endregion

                    #region ���i���i���
                    //--------------------------------------------
                    // ���i���i���
                    //--------------------------------------------
                    DateTime targetDate = new DateTime();
                    switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlip.AcptAnOdrStatus)
                    {
                        case AcptAnOdrStatusState.Estimate:
                        case AcptAnOdrStatusState.UnitPriceEstimate:
                            targetDate = this._salesSlip.SalesDate;
                            break;
                        case AcptAnOdrStatusState.AcceptAnOrder:
                            targetDate = this._salesSlip.SalesDate;
                            break;
                        case AcptAnOdrStatusState.Sales:
                            targetDate = this._salesSlip.SalesDate;
                            break;
                        case AcptAnOdrStatusState.Shipment:
                            targetDate = this._salesSlip.ShipmentDay;
                            break;
                    }
                    GoodsPrice goodsPrice = this._salesSlipInputInitDataAcs.GetGoodsPrice(targetDate, goodsUnitData.GoodsPriceList);
                    if (goodsPrice != null)
                    {
                        row.OpenPriceDiv = goodsPrice.OpenPriceDiv; // �I�[�v�����i�敪
                    }

                    if ((goodsUnitData.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(goodsUnitData.GoodsNo)))
                    {
                        this.SalesDetailRowGoodsPriceSetting(ref row, goodsUnitData, true); // �P���Z�o����
                        // --- ADD liusy 2013/07/25 for Redemine34551 ------------>>>>>>>>>>>>>
                        if (setDefaultRowCount)
                        {
                            //�󒍃f�[�^�P���ȂǍ��ڂ̕␳
                            SettingAcceptAnOrderforPrice(row);
                        }
                        // --- ADD liusy 2013/07/25 for Redemine#34551 ------------<<<<<<<<<<<<<
                    }
                    #endregion

                    #region ���̑�
                    //--------------------------------------------
                    // ���̑�
                    //--------------------------------------------
                    //>>>2010/02/26
                    //row.DeliGdsCmpltDueDate = DateTime.Today; // �[�i�����\���
                    row.DeliGdsCmpltDueDate = string.Empty; // �[�i�����\���
                    //<<<2010/02/26

                    double detailGrossProfitRate = 0;
                    int signn = (this._salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) ? -1 : 1;
                    if ((row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc) ||
                       (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone))
                    {
                        // �O�� ��ې� �� �Ŕ��艿����Z�o
                        this.GetRate((row.SalesMoneyTaxExc - row.Cost * signn), row.SalesMoneyTaxExc, out detailGrossProfitRate); // ������R�ʂ��l�̌ܓ��Œ�
                    }
                    else if (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                    {
                        // ���� �� �ō��艿����Z�o
                        this.GetRate((row.SalesMoneyTaxInc - row.Cost * signn), row.SalesMoneyTaxInc, out detailGrossProfitRate); // ������R�ʂ��l�̌ܓ��Œ�
                    }
                    row.DetailGrossProfitRate = detailGrossProfitRate; // ���בe����

                    if (this._partySaleSlipDiv == (int)SalesSlipInputConstructionAcs.PartySaleSlipDiv.On) row.PartySlipNumDtl = SalesSlip.PartySaleSlipNum; // ���Ӑ撍��
                    
                    this.SettingSearchPartsMode(row, searchPartsMode); // ���i�������

                    //>>>2010/02/26
                    // �񓚔[��
                    if ((this._salesSlip.OnlineKindDiv == (int)SalesSlipInputAcs.OnlineKindDiv.SCM) &&
                        ((this._salesSlip.AcptAnOdrStatusDisplay == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Estimate) ||
                        // 2011/01/31 >>>
                        ( this._salesSlip.AcptAnOdrStatusDisplay == (int)SalesSlipInputAcs.AcptAnOdrStatusState.Sales ) ||
                        // 2011/01/31 <<<
                         ( this._salesSlip.AcptAnOdrStatusDisplay == (int)SalesSlipInputAcs.AcptAnOdrStatusState.UnitPriceEstimate ) ))
                    {
                        // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        #region ���\�[�X
                        //// 2012/08/30 UPD T.Yoshioka 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                        //// row.DeliGdsCmpltDueDate = this.GetAnswerDeliveryDate(this._salesSlip, row.WarehouseCode, row.WarehouseName, row.WarehouseShelfNo);
                        //row.DeliGdsCmpltDueDate = this.GetAnswerDeliveryDate(this._salesSlip, row.WarehouseCode, row.WarehouseName, row.WarehouseShelfNo, stock, row.ShipmentCnt);
                        //// 2012/08/30 UPD T.Yoshioka 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                        #endregion
                        Int16 ansDeliDateDiv;
                        row.DeliGdsCmpltDueDate = this.GetAnswerDeliveryDate(this._salesSlip, row.WarehouseCode, row.WarehouseName, row.WarehouseShelfNo, stock, row.ShipmentCnt, out ansDeliDateDiv);
                        row.AnsDeliDateDiv = ansDeliDateDiv;
                        // UPD 2015/02/10 �g�� SCM������ �񓚔[���敪�Ή� ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                    //<<<2010/02/26

                    // --- ADD 2014/07/14 Y.Wakita ---------->>>>>
                    // ���i�ԍ��ɕύX���Ȃ��ꍇ�A���������Đݒ肷��B
                    if (row.GoodsNo.Trim() == svGoodsNo.Trim())
                    {
                        // --- ADD 2014/07/14 Y.Wakita ----------<<<<<

                    // --- ADD 2013/12/10 Y.Wakita ---------->>>>>
                    row.CmpltSalesRowNo = svCmpltSalesRowNo;        // ����-BL���i�R�[�h
                    row.CmpltGoodsMakerCd = svCmpltGoodsMakerCd;    // ����-���[�J�[
                    row.CmpltGoodsName = svCmpltGoodsName;          // ����-���i�ԍ�
                    row.CmpltSalesUnPrcFl = svCmpltSalesUnPrcFl;    // ����-�艿
                    // --- ADD 2013/12/10 Y.Wakita ----------<<<<<

                        // --- ADD 2014/07/14 Y.Wakita ---------->>>>>
                    }
                    // --- ADD 2014/07/14 Y.Wakita ----------<<<<<
                    #endregion
                }

                //>>>2010/07/21
                if (emptyInfoSetting)
                {
                    // --- ADD 2012/09/05 Y.Wakita ---------->>>>>
                    if (saveValueSetting)
                    {
                        // --- ADD 2012/09/05 Y.Wakita ----------<<<<<
		                    // �󏤕i���ݒ�A���荀�ڂ��Đݒ肷��
		                    row.GoodsNameKana = goodsNameKana;
		                    row.BLGoodsFullName = blGoodsFullName;
		                    row.PrtBLGoodsName = prtBLGoodsName;
		                    row.MakerKanaName = makerKanaName;
		                    row.RateBLGoodsCode = rateBLGoodsCode;
		                    row.BLGroupCode = blGroupCode;
		                    row.BLGroupName = blGroupName;
		                    row.GoodsMGroup = goodsMGroup;
		                    row.GoodsMGroupName = goodsMGroupName;
		                    row.GoodsLGroup = goodsLGroup;
		                    row.GoodsLGroupName = goodsLGroupName;
		                    // --- ADD 2012/08/30 Y.Wakita ---------->>>>>
		                    row.SupplierCdForStock = svSupplierCdForStock;  // �d����R�[�h(�d�����)
		                    row.SupplierSnm = svSupplierSnm;                // �d���旪��
		                    // --- ADD 2012/08/30 Y.Wakita ----------<<<<<
                            // --- DEL 2012/10/19 Y.Wakita ---------->>>>>
                            //// --- ADD 2012/10/11 Y.Wakita ---------->>>>>
                            //row.BoCode = svBoCode;                                      // BO�敪
                            //row.SupplierCdForOrder = svSupplierCdForOrder; 				// ������
                            //row.SupplierSnmForOrder = svSupplierSnmForOrder; 			// �����於��
                            //row.AcceptAnOrderCntForOrder = svAcceptAnOrderCntForOrder; 	// ������
                            //row.UOEDeliGoodsDiv = svUOEDeliGoodsDiv; 					// �[�i�敪
                            //row.DeliveredGoodsDivNm = svDeliveredGoodsDivNm; 			// �[�i�敪����
                            //row.DeliveredGoodsDivNmSave = svDeliveredGoodsDivNmSave; 	// �[�i�敪���́i�ۑ��p�j
                            //row.FollowDeliGoodsDiv = svFollowDeliGoodsDiv; 				// H�[�i�敪
                            //row.FollowDeliGoodsDivNm = svFollowDeliGoodsDivNm; 			// H�[�i�敪����
                            //row.FollowDeliGoodsDivNmSave = svFollowDeliGoodsDivNmSave; 	// H�[�i�敪���́i�ۑ��p�j
                            //row.UOEResvdSection = svUOEResvdSection; 					// �w�苒�_
                            //row.UOEResvdSectionNm = svUOEResvdSectionNm; 				// �w�苒�_����
                            //row.UOEResvdSectionNmSave = svUOEResvdSectionNmSave; 		// �w�苒�_���́i�ۑ��p�j
                            //// --- ADD 2012/10/11 Y.Wakita ----------<<<<<
                            // --- DEL 2012/10/19 Y.Wakita ----------<<<<<
                            // --- ADD 2012/09/05 Y.Wakita ---------->>>>>
                    }
                    // --- ADD 2012/09/05 Y.Wakita ----------<<<<<
                }
                //<<<2010/07/21

                // 2012/06/15 ADD T.Yoshioka 90 ---------------->>>>>>>>>>>>>>>>>>>>>>>>> 
                int ansPureGoodsNo = 0;
                string pureGoodsMakerCd = string.Empty;
                // �D�Ǐ��i�̏ꍇ�A�񓚏������i�ԍ��Ə������i���[�J�[�R�[�h�̎擾
                // �������i�̏ꍇ�́A0�A�󕶎����Ԃ��Ă���
                GetPureInfo(_partsInfo, goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, 0, out ansPureGoodsNo, out pureGoodsMakerCd);

                // �񓚏������i�ԍ��Ə������i���[�J�[�R�[�h�̐ݒ�
                if (ansPureGoodsNo.Equals(0))
                {
                    // �������i�̏ꍇ ���i�ԍ��Ə��i���[�J�[�R�[�h��ݒ�
                    row.AnsPureGoodsNo = row.GoodsNo;
                    row.PureGoodsMakerCd = row.GoodsMakerCd;
                }
                else
                {
                    // �D�Ǐ��i�̏ꍇ
                    row.AnsPureGoodsNo = pureGoodsMakerCd;    // �񓚏������i�ԍ�
                    row.PureGoodsMakerCd = ansPureGoodsNo;    // �������i���[�J�[�R�[�h
                }
                // 2012/06/15 ADD T.Yoshioka 90 ----------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                // --- ADD 2014/01/15 T.Miyamoto ------------------------------>>>>>
                // --- DEL 2014/07/14 Y.Wakita ---------->>>>>
                //row.CmpltSalesRowNo = 0;
                //row.CmpltGoodsMakerCd = 0;
                //row.CmpltGoodsName = string.Empty;
                //row.CmpltSalesUnPrcFl = 0;
                // --- DEL 2014/07/14 Y.Wakita ----------<<<<<

                //---DEL 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ---------------->>>>>
                //// --- UPD 2014/01/29 T.Miyamoto ------------------------------>>>>>
                ////// ���i�������u1:�D�ǁv�̏ꍇ�ɏ����艿���̎擾���s��
                ////if (goodsUnitData.GoodsKindCode == (int)GoodsKindCode.PrimeGoods)
                //// �e���(�����E�Z�b�g)�����݂���ꍇ�ɏ����艿���̎擾���s��
                //if ((goodsUnitData.JoinSourceMakerCode != 0) && (goodsUnitData.JoinSrcPartsNoWithH != ""))
                //// --- UPD 2014/01/29 T.Miyamoto ------------------------------<<<<<
                //---DEL 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ----------------<<<<<
                //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ---------------->>>>>
                // �e���(�����E�Z�b�g)�ɏ����i���ݒ肳��Ă���ꍇ�ɏ����艿���̎擾���s��
                if (   (0 < goodsUnitData.JoinSourceMakerCode && SalesSlipInputAcs.ctPureGoodsMakerCode >= goodsUnitData.JoinSourceMakerCode)
                    && (!string.IsNullOrEmpty(goodsUnitData.JoinSrcPartsNoWithH)))
                //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ----------------<<<<<
                {
                    PartsInfoDataSet.UsrGoodsInfoRow PureGoodsInfoRow = GetPurePriceInfo(_partsInfo, goodsUnitData);
                    if (PureGoodsInfoRow != null)
                    {
                        row.CmpltSalesRowNo = PureGoodsInfoRow.BlGoodsCode;    // ����-BL���i�R�[�h
                        row.CmpltGoodsMakerCd = PureGoodsInfoRow.GoodsMakerCd; // ����-���[�J�[
                        row.CmpltGoodsName = PureGoodsInfoRow.GoodsNo;         // ����-���i�ԍ�
                        row.CmpltSalesUnPrcFl = PureGoodsInfoRow.PriceTaxExc;  // ����-�艿
                    }
                }
                // --- ADD 2014/01/15 T.Miyamoto ------------------------------<<<<<

            }
        }

        // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� ----------------------------->>>>>
        /// <summary>
        ///  �񋟃f�[�^�������i���擾
        /// </summary>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        /// <param name="retPartsInfo"></param>
        private void GetPartsInfo(int goodsMakerCd, string goodsNo, out PartsInfoDataSet.PartsInfoRow retPartsInfo)
        {
            retPartsInfo = null;

            if (goodsMakerCd == 0 || string.IsNullOrEmpty(goodsNo)) return;
            if (this._partsInfo == null || this._partsInfo.PartsInfo == null || this._partsInfo.PartsInfo.Count == 0) return;

            foreach (PartsInfoDataSet.PartsInfoRow row in this._partsInfo.PartsInfo)
            {
                if (row.CatalogPartsMakerCd == goodsMakerCd && (row.ClgPrtsNoWithHyphen.Trim() == goodsNo.Trim() || row.NewPrtsNoWithHyphen.Trim() == goodsNo.Trim()))
                {
                    retPartsInfo = row;
                    return;
                }
            }
        }
        // ADD 2015/01/30 SCM������ ���Y�N���A�ԑ�ԍ��Ή� -----------------------------<<<<<

        // --- ADD liusy 2013/07/25 for Redemine34551 ------------>>>>>>>>>>>>>
        /// <summary>
        /// �󒍃f�[�^�P���ȂǍ��ڂ̕␳
        /// </summary>
        /// <param name="row">���㖾�׃f�[�^�e�[�u���s�I�u�W�F�N�g</param>
        private void SettingAcceptAnOrderforPrice(SalesInputDataSet.SalesDetailRow row)
        {
            switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlip.AcptAnOdrStatus)
            {
                case SalesSlipInputAcs.AcptAnOdrStatusState.AcceptAnOrder: // ��
                    {

                        // �󒍏��ݒ�
                        this.SettingSalesDetailAcceptAnOrder(row.SalesRowNo);

                        SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = this._salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);
                        acptAnOdrRow.ShipmentCntDisplay = row.AcceptAnOrderCntDisplay;

                        // ���ʐݒ菈���y�ъ|������P���Čv�Z�̕␳
                        this.SettingAcptAnOdrDetailRowShipmentCnt(row.SalesRowNo);
                        break;
                    }
            }
        }
        // --- ADD liusy 2013/07/25 for Redemine#34551 ------------<<<<<<<<<<<<<
        /// <summary>
        /// ���i������Ԑݒ菈��
        /// </summary>
        /// <param name="row">���㖾�׃f�[�^�e�[�u���s�I�u�W�F�N�g</param>
        /// <param name="searchPartsMode">���i�������[�h</param>
        private void SettingSearchPartsMode(SalesInputDataSet.SalesDetailRow row, SearchPartsMode searchPartsMode)
        {
            if (row != null)
            {
                switch (searchPartsMode)
                {
                    case SearchPartsMode.BLCodeSearch:
                        if (row.BLGoodsCode != 0)
                        {
                            row.SearchPartsModeState = (int)SearchPartsModeState.BLCodeSearch;
                        }
                        else
                        {
                            row.SearchPartsModeState = (int)SearchPartsModeState.NonSearch;
                        }
                        break;
                    case SearchPartsMode.GoodsNoSearch:
                        if (!string.IsNullOrEmpty(row.GoodsNo))
                        {
                            row.SearchPartsModeState = (int)SearchPartsModeState.GoodsNoSearch;
                        }
                        else
                        {
                            row.SearchPartsModeState = (int)SearchPartsModeState.NonSearch;
                        }
                        break;
                }
            }
        }

        /// <summary>
        /// ���i������Ԏ擾����
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <returns></returns>
        public SearchPartsModeState GetSearchPartsMode(int salesRowNo)
        {
            SearchPartsModeState retState = SearchPartsModeState.NonSearch;
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (row != null)
            {
                retState = (SearchPartsModeState)row.SearchPartsModeState;
            }
            return retState;
        }

        /// <summary>
        /// QTY�擾����
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <returns></returns>
        private double GetQty(GoodsUnitData goodsUnitData)
        {
            switch ((GoodsKind)goodsUnitData.GoodsKindResolved)
            {
                case GoodsKind.Parent:
                    //-----UPD 2011/11/08----->>>>>
                    //return goodsUnitData.PartsQty;
                    if ((GoodsKind)goodsUnitData.GoodsKind == GoodsKind.Join)
                    {
                        return goodsUnitData.JoinQty;
                    }
                    else
                    {
                        return goodsUnitData.PartsQty;
                    } 
                    //-----UPD 2011/11/08-----<<<<<
                case GoodsKind.Join:
                    return goodsUnitData.JoinQty;
                case GoodsKind.Set:
                    return goodsUnitData.SetQty;
                case GoodsKind.Subst:
                    return goodsUnitData.PartsQty;
                // 2009.06.23 >>>
                //case GoodsKind.PluralSubst:
                case GoodsKind.SubstPlrl:
                // 2009.06.23 <<<
                    return goodsUnitData.PartsQty;
                default:
                    // --- UPD m.suzuki 2010/04/12 ---------->>>>>
                    //return 0;
                    return goodsUnitData.PartsQty;
                // --- UPD m.suzuki 2010/04/12 ----------<<<<<
            }
        }

        /// <summary>
        /// �w�肵�����㏤�i�敪�����ɁA���㖾�׃f�[�^�s�I�u�W�F�N�g�Ɋ֘A���鍀�ڂ�ݒ肵�܂��B
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="salesGoodsCd">���㏤�i�敪</param>
        /// <param name="salesRateClearFlag">�P�����N���A�elag</param>
        // --- UPD 2009/12/23 ---------->>>>>
        //public void SalesDetailRowSalesGoodsCdSetting(int salesRowNo, int salesGoodsCd)
        public void SalesDetailRowSalesGoodsCdSetting(int salesRowNo, int salesGoodsCd, bool salesRateClearFlag)
        // --- UPD 2009/12/23 ----------<<<<<
        {
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
			int taxFracProcCd = 0;
			double taxFracProcUnit = 0;
            //this._salesSlipInputInitDataAcs.GetFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            // --- UPD 2013/08/07 Y.Wakita ---------->>>>>
            //this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, 0, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            // --- UPD 2013/08/07 Y.Wakita ----------<<<<<

            if (row != null)
            {
                switch ((SalesGoodsCd)salesGoodsCd)
                {
                    case SalesGoodsCd.Goods:
                        {
                            #region ���s�l����
                            if (row.EditStatus == ctEDITSTATUS_RowDiscount)    // �s�l����
                            {
                                row.SalesGoodsCd = salesGoodsCd;
                                row.CanTaxDivChange = false;
                                row.EditStatus = ctEDITSTATUS_RowDiscount;

                                int sign = (this._salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) ? -1 : 1;
                                // ��ې�
                                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                                {
                                    row.SalesMoneyTaxExc = row.SalesMoneyDisplay * sign;
                                    row.SalesMoneyTaxInc = row.SalesMoneyDisplay * sign;
                                    row.TaxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;
                                }
                                // ���z�\�����Ȃ�
                                else if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
                                {
                                    row.SalesMoneyTaxExc = row.SalesMoneyDisplay * sign;
                                    row.SalesMoneyTaxInc = (row.SalesMoneyDisplay + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesMoneyDisplay)) * sign;
                                    row.TaxationDivCd = (int)CalculateTax.TaxationCode.TaxExc;
                                }
                                // ���z�\������
                                else
                                {
                                    row.SalesMoneyTaxExc = (row.SalesMoneyDisplay - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesMoneyDisplay)) * sign;
                                    row.SalesMoneyTaxInc = row.SalesMoneyDisplay * sign;
                                    row.TaxationDivCd = (int)CalculateTax.TaxationCode.TaxInc;
                                }
                                row.SalesPriceConsTax = (long)((decimal)row.SalesMoneyTaxInc - (decimal)row.SalesMoneyTaxExc);
                            }
                            #endregion

                            #region �����i�l����
                            else if (row.EditStatus == ctEDITSTATUS_GoodsDiscount)
                            {
                                row.SalesGoodsCd = salesGoodsCd;
                                row.EditStatus = ctEDITSTATUS_GoodsDiscount;
                                row.CanTaxDivChange = true;

                                #region ���ʏ�
                                // --- UPD 2009/12/23 ---------->>>>>
                                //this.SalesDetailRowSalesMoneySetting(salesRowNo, row.SalesMoneyDisplay);
                                this.SalesDetailRowSalesMoneySetting(salesRowNo, row.SalesMoneyDisplay, salesRateClearFlag);
                                // --- UPD 2009/12/23 ----------<<<<<

                                // ���z����͋敪
                                if ((row.SalesUnPrcDisplay == 0) && (row.SalesMoneyDisplay != 0))
                                {
                                    row.SalesMoneyInputDiv = (int)SalesMoneyInputDiv.Input;
                                }
                                else
                                {
                                    row.SalesMoneyInputDiv = (int)SalesMoneyInputDiv.Calculate;
                                }
                                #endregion
                            }
                            #endregion

                            #region ������
                            else if (row.SalesSlipCdDtl == 3)
                            {
                                row.ShipmentCnt = 0;
                                row.SalesGoodsCd = salesGoodsCd;
                                row.CanTaxDivChange = false;
                                row.EditStatus = ctEDITSTATUS_Annotation;
                            }
                            #endregion

                            else
                            {
                                #region ���i�ԕK�{���[�h
                                // �i�ԕK�{���[�h
                                if ((this._salesSlipInputInitDataAcs.InputMode != SalesSlipInputInitDataAcs.ctINPUTMODE_NecessaryGoodsNo) && (string.IsNullOrEmpty(row.GoodsNo)))
                                {
                                    if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
                                    {
                                        row.TaxationDivCd = (int)CalculateTax.TaxationCode.TaxExc;
                                    }
                                    else
                                    {
                                        row.TaxationDivCd = (int)CalculateTax.TaxationCode.TaxInc;
                                    }
                                    row.SalesGoodsCd = salesGoodsCd;
                                    row.EditStatus = ctEDITSTATUS_AllOK;
                                    row.CanTaxDivChange = true;
                                }
                                #endregion

                                #region ���ʏ�
                                // --- UPD 2009/12/23 ---------->>>>>
                                //this.SalesDetailRowSalesMoneySetting(salesRowNo, row.SalesMoneyDisplay);
                                this.SalesDetailRowSalesMoneySetting(salesRowNo, row.SalesMoneyDisplay, salesRateClearFlag);
                                // --- UPD 2009/12/23 ----------<<<<<

                                // ���z����͋敪
                                if ((row.SalesUnPrcDisplay == 0) && (row.SalesMoneyDisplay != 0))
                                {
                                    row.SalesMoneyInputDiv = (int)SalesMoneyInputDiv.Input;
                                }
                                else
                                {
                                    row.SalesMoneyInputDiv = (int)SalesMoneyInputDiv.Calculate;
                                }
                                #endregion
                            }
                            break;
                        }
                    case SalesGoodsCd.ConsTaxAdjust:								// ���㏤�i�敪 = 2:����Œ���
                    case SalesGoodsCd.AccRecConsTaxAdjust:								// ���㏤�i�敪 = 4:���|�p����Œ���
                        {
                            if (row.SalesMoneyDisplay == 0)
                            {
                                this.ClearSalesDetailRow(row.SalesRowNo);
                            }
                            else
                            {
                                row.GoodsName = "����Œ���";
                                row.GoodsNameKana = "����Œ���";
                                row.TaxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;
                                //if (this._salesSlip.SalesSlipCd == 1) // 0:���� 1:�ԕi
                                //{
                                //    row.ShipmentCnt = -1;
                                //}
                                //else
                                //{
                                //    row.ShipmentCnt = 1;
                                //}
                                row.ShipmentCnt = 1;
                                row.SalesGoodsCd = salesGoodsCd;
                                //row.SalesUnPrcTaxExcFl = row.SalesMoneyDisplay;
                                //row.SalesUnPrcTaxIncFl = row.SalesMoneyDisplay;
                                //row.SalesMoneyTaxExc = row.SalesMoneyDisplay; // ���z(�Ŕ�)
                                //row.SalesMoneyTaxInc = row.SalesMoneyDisplay; // ���z(�ō�)
                                row.SalesPriceConsTax = row.SalesMoneyDisplay;
                                row.CanTaxDivChange = false;
                                row.EditStatus = ctEDITSTATUS_AllOK;
                            }
                            break;
                        }
                    case SalesGoodsCd.BalanceAdjust:								// ���㏤�i�敪 = 3:�c������
                    case SalesGoodsCd.AccRecBalanceAdjust:								// ���㏤�i�敪 = 5:���|�p�c������
                        {
                            if (row.SalesMoneyDisplay == 0)
                            {
                                this.ClearSalesDetailRow(row.SalesRowNo);
                            }
                            else
                            {
                                row.GoodsName = "�c������";
                                row.GoodsNameKana = "�c������";
                                row.TaxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;
                                //if (this._salesSlip.SalesSlipCd == 1) // 0:���� 1:�ԕi
                                //{
                                //    row.ShipmentCnt = -1;
                                //}
                                //else
                                //{
                                //    row.ShipmentCnt = 1;
                                //}
                                row.ShipmentCnt = 1;
                                //row.SalesUnPrcTaxExcFl = row.SalesMoneyDisplay; // �P��(�Ŕ�)
                                //row.SalesUnPrcTaxIncFl = row.SalesMoneyDisplay; // �P��(�ō�)
                                //row.SalesMoneyTaxExc = row.SalesMoneyDisplay; // ���z(�Ŕ�)
                                row.SalesMoneyTaxInc = row.SalesMoneyDisplay; // ���z(�ō�)
                                row.SalesGoodsCd = salesGoodsCd;
                                row.CanTaxDivChange = false;
                                row.EditStatus = ctEDITSTATUS_AllOK;
                            }
                            break;
                        }
                }
            }
        }

        /// <summary>
        /// ���㖾�׍s�I�u�W�F�N�g�ɍ݌ɂ�薾�׏���ݒ肵�܂��B
        /// </summary>
        /// <param name="salesRowNo">�s�ԍ�</param>
        /// <param name="stockList">�݌ɏ��I�u�W�F�N�g���X�g</param>
        public void SalesDetailRowSettingFromStockSetting(int salesRowNo, List<Stock> stockList)
        {
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (stockList.Count != 0)
            {
                Stock stock = stockList[0];
                if (row != null)
                {
                    // �݌ɏ��
                    if (stock != null)
                    {
                        // �݌ɂ̃L���b�V��
                        this.CacheStockInfo(stock);

                        row.WarehouseCode = stock.WarehouseCode.Trim();
                        row.WarehouseName = stock.WarehouseName.Trim();
                        row.WarehouseShelfNo = stock.WarehouseShelfNo.Trim();
                        row.SupplierStock = stock.ShipmentPosCnt;
                        row.SupplierStockDisplay = stock.ShipmentPosCnt;
                        if (this.SupplierStockCountChangeCheck(row)) row.SupplierStockDisplay -= Math.Abs(row.ShipmentCntDisplay);
                    }
                }
            }
            else
            {
                row.WarehouseCode = string.Empty;
                row.WarehouseName = string.Empty;
                row.WarehouseShelfNo = string.Empty;
                row.SupplierStock = 0;
                row.SupplierStockDisplay = 0;
            }
        }

#if false
        ///// <summary>
        ///// ���i��񃊃X�g���݌Ƀ}�X�^���������A�݌ɏ�񃊃X�g���擾���܂��B
        ///// </summary>
        ///// <param name="goodsUnitDataList">���i��񃊃X�g</param>
        ///// <returns>�݌ɏ�񃊃X�g</returns>
        //public List<Stock> SearchStock(List<GoodsUnitData> goodsUnitDataList)
        //{
        //    List<Stock> retStockList = new List<Stock>();

        //    // �q�ɃR�[�h(���_���ݒ�}�X�^(�D��q��))
        //    string[] warehouseCodes = new string[_salesSlipInputInitDataAcs.SectWarehouseCd.Count];
        //    for (int i = 0; i < _salesSlipInputInitDataAcs.SectWarehouseCd.Count; i++)
        //    {
        //        warehouseCodes[i] = _salesSlipInputInitDataAcs.SectWarehouseCd[i];
        //    }

        //    // 1���i���A�D��q�Ɍ�������
        //    foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
        //    {
        //        StockSearchPara stockSearchPara = new StockSearchPara();
        //        stockSearchPara.EnterpriseCode = this._enterpriseCode;
        //        stockSearchPara.GoodsNo = goodsUnitData.GoodsNo;
        //        stockSearchPara.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
        //        stockSearchPara.WarehouseCodes = warehouseCodes;

        //        List<Stock> searchRetStockList = SearchStock(stockSearchPara);

        //        // �������ʂ��[�����̏ꍇ�͎��̏��i������
        //        if (searchRetStockList.Count == 0) continue;

        //        Stock searchRetStock = new Stock();

        //        // �������ʂ��������ꍇ�͍ŗD��̍݌ɏ������ʂƂ��ĕԂ�(���_�D��q�ɏ�)
        //        for (int cnt = 0; cnt < warehouseCodes.Length; cnt++)
        //        {
        //            bool hit = false;
        //            if (String.IsNullOrEmpty(warehouseCodes[cnt])) continue;

        //            foreach (Stock searchRetStockWk in searchRetStockList)
        //            {
        //                if (searchRetStockWk.WarehouseCode.Trim() == warehouseCodes[cnt].Trim())
        //                {
        //                    searchRetStock = searchRetStockWk;
        //                    hit = true;
        //                    break;
        //                }
        //            }
        //            if (hit) break;
        //        }

        //        retStockList.Add(searchRetStock);
        //    }
        //    return retStockList;
        //}
        
        ///// <summary>
        ///// ���i�����݌Ƀ}�X�^���������A�݌Ƀ��X�g���擾���܂��B
        ///// </summary>
        ///// <param name="goodsUnitDataList">���i���X�g</param>
        ///// <returns>�݌Ƀ��X�g</returns>
        //public List<Stock> SearchStock(GoodsUnitData goodsUnitData)
        //{
        //    //-------------------------------------------
        //    // �����R�[�h�ݒ�
        //    //-------------------------------------------
        //    string goodsNo = goodsUnitData.GoodsNo;
        //    int goodsMakerCd = goodsUnitData.GoodsMakerCd;

        //    //-------------------------------------------
        //    // �p�����[�^�Z�b�g
        //    //-------------------------------------------
        //    StockSearchPara stockSearchPara = new StockSearchPara();
        //    // ���_�R�[�h
        //    stockSearchPara.EnterpriseCode = this._enterpriseCode;
        //    // ���i�ԍ�
        //    stockSearchPara.GoodsNo = goodsNo;
        //    // ���[�J�[�R�[�h
        //    stockSearchPara.GoodsMakerCd = goodsMakerCd;
        //    // �q�ɃR�[�h(���_���ݒ�}�X�^(�D��q��))
        //    string[] warehouseCodes = new string[_salesSlipInputInitDataAcs.SectWarehouseCd.Count];
        //    for (int i = 0; i < _salesSlipInputInitDataAcs.SectWarehouseCd.Count; i++)
        //    {
        //        warehouseCodes[i] = _salesSlipInputInitDataAcs.SectWarehouseCd[i];
        //    }
        //    stockSearchPara.WarehouseCodes = warehouseCodes;

        //    //-------------------------------------------
        //    // �݌Ɍ���
        //    //-------------------------------------------
        //    List<Stock> stockList = new List<Stock>();
        //    string msg;
        //    // ����
        //    //int status = this._searchStockAcs.Search(stockSearchPara, out stockList, out msg);
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        stockList = new List<Stock>();
        //    }

        //    //-------------------------------------------
        //    // �������ʂ���D��q�ɂɏ]�����擾
        //    //-------------------------------------------
        //    List<Stock> retStockList = new List<Stock>();
        //    for (int i = 0; i < _salesSlipInputInitDataAcs.SectWarehouseCd.Count; i++)
        //    {
        //        int j = 0;
        //        foreach (Stock stock in stockList)
        //        {
        //            if (_salesSlipInputInitDataAcs.SectWarehouseCd[i].Trim() == stock.WarehouseCode.Trim())
        //            {
        //                retStockList.Add(stockList[j]);
        //                return retStockList;
        //            }
        //            j++;
        //        }
        //    }
        //    return retStockList;
        //}

        ///// <summary>
        ///// ���׏����݌Ƀ}�X�^���������A�݌Ƀ��X�g���擾���܂��B
        ///// </summary>
        ///// <param name="salesDetailList">���׏�񃊃X�g</param>
        ///// <returns>�݌Ƀ��X�g</returns>
        //public List<Stock> SearchStock(List<SalesDetail> salesDetailList)
        //{
        //    List<Stock> retStockList = new List<Stock>();

        //    foreach (SalesDetail salesDetail in salesDetailList)
        //    {
        //        List<Stock> stockList = SearchStock(salesDetail);
        //        if (stockList.Count != 0)
        //        {
        //            retStockList.Add(stockList[0]);
        //        }
        //    }

        //    return retStockList;
        //}

        ///// <summary>
        ///// ���׏����݌Ƀ}�X�^���������A�݌Ƀ��X�g���擾���܂��B
        ///// </summary>
        ///// <param name="salesDetailList">���׏�񃊃X�g</param>
        ///// <returns>�݌Ƀ��X�g</returns>
        //private List<Stock> SearchStock(SalesDetail salesDetail)
        //{
        //    //-------------------------------------------
        //    // �����R�[�h�ݒ�
        //    //-------------------------------------------
        //    string goodsNo = salesDetail.GoodsNo;
        //    int goodsMakerCd = salesDetail.GoodsMakerCd;

        //    //-------------------------------------------
        //    // �p�����[�^�Z�b�g
        //    //-------------------------------------------
        //    StockSearchPara stockSearchPara = new StockSearchPara();
        //    // ���_�R�[�h
        //    stockSearchPara.EnterpriseCode = this._enterpriseCode;
        //    // ���i�ԍ�
        //    stockSearchPara.GoodsNo = goodsNo;
        //    // ���[�J�[�R�[�h
        //    stockSearchPara.GoodsMakerCd = goodsMakerCd;

        //    // �q�ɃR�[�h(���׃f�[�^�q�� ���_���ݒ�}�X�^(�D��q��))
        //    string[] warehouseCodes = new string[_salesSlipInputInitDataAcs.SectWarehouseCd.Count + 1];
        //    int revise = 0;
        //    if (!string.IsNullOrEmpty(salesDetail.WarehouseCode.Trim()))
        //    {
        //        warehouseCodes[0] = salesDetail.WarehouseCode.Trim();
        //        revise++;
        //    }
        //    for (int i = 0; i < _salesSlipInputInitDataAcs.SectWarehouseCd.Count; i++)
        //    {
        //        warehouseCodes[i+revise] = _salesSlipInputInitDataAcs.SectWarehouseCd[i];
        //    }
        //    stockSearchPara.WarehouseCodes = warehouseCodes;

        //    //-------------------------------------------
        //    // �݌Ɍ���
        //    //-------------------------------------------
        //    List<Stock> stockList;
        //    stockList = this.SearchStock(stockSearchPara);

        //    //-------------------------------------------
        //    // �������ʂ��疾�׃f�[�^�q�ɁA�D��q�ɂɏ]�����擾
        //    //-------------------------------------------
        //    List<Stock> retStockList = new List<Stock>();
        //    for (int i = 0; i < warehouseCodes.Length; i++)
        //    {
        //        int j = 0;
        //        foreach (Stock stock in stockList)
        //        {
        //            if (warehouseCodes[i].Trim() == stock.WarehouseCode.Trim())
        //            {
        //                retStockList.Add(stockList[j]);
        //                return retStockList;
        //            }
        //            j++;
        //        }
        //    }
        //    return retStockList;

        //}

        ///// <summary>
        ///// ���׏����݌Ƀ}�X�^���������A�݌Ƀ��X�g���擾���܂��B
        ///// </summary>
        ///// <returns>�݌Ƀ��X�g</returns>
        //public List<Stock> SearchStock(int salesRowNo)
        //{
        //    SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

        //    //-------------------------------------------
        //    // �����R�[�h�ݒ�
        //    //-------------------------------------------
        //    string goodsNo = row.GoodsNo;
        //    int goodsMakerCd = row.GoodsMakerCd;
        //    string warehouseCode = row.WarehouseCode;

        //    //-------------------------------------------
        //    // �p�����[�^�Z�b�g
        //    //-------------------------------------------
        //    StockSearchPara stockSearchPara = new StockSearchPara();
        //    // ���_�R�[�h
        //    stockSearchPara.EnterpriseCode = this._enterpriseCode;
        //    // ���i�ԍ�
        //    stockSearchPara.GoodsNo = goodsNo;
        //    // ���[�J�[�R�[�h
        //    stockSearchPara.GoodsMakerCd = goodsMakerCd;
        //    // �q�ɃR�[�h
        //    stockSearchPara.WarehouseCode = warehouseCode;

        //    //-------------------------------------------
        //    // �݌Ɍ���
        //    //-------------------------------------------
        //    return this.SearchStock(stockSearchPara);
        //}

        ///// <summary>
        ///// �݌Ɍ����p�����[�^���݌Ɍ������s���A�݌Ƀ��X�g���擾���܂��B
        ///// </summary>
        ///// <param name="stockSearchPara">�݌Ɍ����p�����[�^</param>
        ///// <returns>�݌Ƀ��X�g</returns>
        //private List<Stock> SearchStock(StockSearchPara stockSearchPara)
        //{
        //    List<Stock> retStockList = new List<Stock>();

        //    string msg;
        //    // ����
        //    //int status = this._searchStockAcs.Search(stockSearchPara, out retStockList, out msg);
        //    int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //    {
        //        retStockList = new List<Stock>();
        //    }

        //    return retStockList;
        //}
#endif

        /// <summary>
        /// �݌Ƀ��X�g���݌ɏ��擾
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <returns></returns>
        public Stock GetStock(GoodsUnitData goodsUnitData)
        {
            List<string> warehouseList = new List<string>();
            //warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.SectWarehouseCd, this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 DEL
            warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.GetSectWarehouseCd(this._salesSlip.ResultsAddUpSecCd), this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 ADD

            if (goodsUnitData.StockList != null)
            {
                foreach (Stock stock in goodsUnitData.StockList)
                {
                    for (int i = 0; i < warehouseList.Count; i++)
                    {
                        Stock retStock = new Stock();
                        retStock = this._salesSlipInputInitDataAcs.GetStockFromStockList(warehouseList[i], goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, goodsUnitData.StockList);
                        if (retStock != null) return retStock;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// �݌Ƀ��X�g���݌ɏ��擾
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <returns></returns>
        public Stock GetStock(GoodsUnitData goodsUnitData, string warehouseCode)
        {
            if ((goodsUnitData != null) &&
                (goodsUnitData.StockList != null))
            {
                Stock retStock = new Stock();

                retStock = this._salesSlipInputInitDataAcs.GetStockFromStockList(warehouseCode, goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, goodsUnitData.StockList);
                if (retStock != null) return retStock;
            }
            return null;
        }

        /// <summary>
        /// �q�ɐؑ֏���
        /// </summary>
        /// <param name="rowNo"></param>
        public void ChangeWarehouse(int rowNo)
        {
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, rowNo);
            //>>>2010/10/01
            //GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo);
            GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo, row);
            //<<<2010/10/01

            if (row != null)
            {
                // ���q�Ɏ擾
                Stock stock = this.GetStockNext(row.WarehouseCode, goodsUnitData);

                // �݌ɏ��ݒ菈��
                this.SettingSalesDetailStockInfo(row, stock);
            }
        }
        
        // --- ADD 2010/05/04 ---------->>>>>
        /// <summary>
        /// �q�ɐؑ֏���
        /// </summary>
        /// <param name="rowNo"></param>
        /// <param name="msg"></param>
        /// <remarks>
        /// <br>Update Note: 2015/04/16 30757 ���X�� �M�p</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00</br>
        /// <br>             �Г���Q��684 �̔��敪�A�q�ɃR�[�h��ύX����ƕ\���敪�Ɋւ�炸�D�Ǖi�̕W�����i���\��������Q�̑Ή�</br>
        /// <br>Update Note: K2021/07/22 ���O</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// <br>             PMKOBETSU-4148 ����0�~��Q�̑Ή�</br> 
        /// </remarks>
        public void ChangeWarehouse(int rowNo, out string msg)
        {
            msg = "";

            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, rowNo);
            //>>>2010/10/01
            //GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo);
            GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo, row);
            //<<<2010/10/01

            if (row != null)
            {
                // ���q�Ɏ擾
                Stock stock = this.GetStockNext(row.WarehouseCode, goodsUnitData);

                if (stock != null && !string.IsNullOrEmpty(stock.SectionCode) && !string.IsNullOrEmpty(LoginInfoAcquisition.Employee.BelongSectionCode))
                {
                    if (!stock.SectionCode.Trim().Equals(LoginInfoAcquisition.Employee.BelongSectionCode.Trim()))
                    {
                        // ���͑q�Ƀ`�F�b�N�敪 0:���� 1:�ē��� 2:�x��
                        switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().InpWarehChkDiv)
                        {
                            case 0:
                                break;
                            case 1:
                                {
                                    msg = "�s���Ȓl�����݂��邽�߁A�o�^�ł��܂���B"
                                        + "\r\n"
                                        + "\r\n"
                                        + rowNo
                                        + "�s�ڂ̍݌ɊǗ����_�ƃ��O�C�����_���s��v�ł��B";

                                    return;
                                }
                            case 2:
                                {
                                    msg = "�݌ɊǗ����_�ƃ��O�C�����_���s��v�ł��B";

                                    break;
                                }
                        }
                    }
                }

                // �݌ɏ��ݒ菈��
                this.SettingSalesDetailStockInfo(row, stock);

                // ADD 2013/04/10 T.Miyamoto ------------------------------>>>>>
                if (this._salesSlipInputInitDataAcs.Opt_SalesCostCtrl == (int)SalesSlipInputInitDataAcs.Option.ON)
                {
                    //---ADD 30757 ���X�� �M�p 2015/04/16 �Г���Q��684 �̔��敪�A�q�ɃR�[�h��ύX����ƕ\���敪�Ɋւ�炸�D�Ǖi�̕W�����i���\��������Q�̑Ή� ---------------->>>>>
                    // ���㖾�׃f�[�^�Z�b�e�B���O�����i�艿�ݒ�j�p�Ɍ��݂̕\���艿���z���ꎞ�ޔ�
                    double tempReturnListPrice = row.ListPriceDisplay;
                    //---ADD 30757 ���X�� �M�p 2015/04/16 �Г���Q��684 �̔��敪�A�q�ɃR�[�h��ύX����ƕ\���敪�Ɋւ�炸�D�Ǖi�̕W�����i���\��������Q�̑Ή� ----------------<<<<<

                    // �����Ď擾
                    this.SalesDetailRowGoodsPriceReSetting(row);

                    //---ADD 30757 ���X�� �M�p 2015/04/16 �Г���Q��684 �̔��敪�A�q�ɃR�[�h��ύX����ƕ\���敪�Ɋւ�炸�D�Ǖi�̕W�����i���\��������Q�̑Ή� ---------------->>>>>
                    // ���׍��ڕύX���̕W�����i�y�є��P���ύX����
                    this.salesDetailRowSalesUnitPriceReSettingProc(rowNo, tempReturnListPrice);
                    //---ADD 30757 ���X�� �M�p 2015/04/16 �Г���Q��684 �̔��敪�A�q�ɃR�[�h��ύX����ƕ\���敪�Ɋւ�炸�D�Ǖi�̕W�����i���\��������Q�̑Ή� ----------------<<<<<

                    //-----ADD K2021/07/22 ���O PMKOBETSU-4148 ----->>>>>
                    // �������z�v�Z����
                    this.CalculationCost(rowNo - 1);
                    // ���בe�����ݒ菈��
                    this.SettingSalesDetailRowGrossProfitRate(row.SalesRowNo);
                    //-----ADD K2021/07/22 ���O PMKOBETSU-4148 -----<<<<<
                }
                // ADD 2013/04/10 T.Miyamoto ------------------------------<<<<<
            }
        }
        // --- ADD 2010/05/04 ----------<<<<<
        
        //---ADD 30757 ���X�� �M�p 2015/04/16 �Г���Q��684 �̔��敪�A�q�ɃR�[�h��ύX����ƕ\���敪�Ɋւ�炸�D�Ǖi�̕W�����i���\��������Q�̑Ή� ---------------->>>>>
        /// <summary>
        /// ���׍��ڕύX���̕W�����i�y�є��P���ύX����
        /// </summary>
        /// <param name="salesRowNo">���׍s�ԍ�</param>
        /// <param name="listPriceDisplay">�ݒ肷��W�����i</param>
        /// <param name="targetTable">�ύX�Ώ۔��㖾�׃f�[�^</param>
        /// <returns>0:�����A0�ȊO:���s</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// �p�����[�^salesRowNo�Őݒ肵���ԍ��̖��׍s�ԍ��̖��׃��R�[�h�����݂��Ȃ��ꍇ�ɔ������܂��B
        /// </exception>
        /// <remarks>
        /// <br>Note       : �Г���Q��684 �̔��敪�A�q�ɃR�[�h��ύX����ƕ\���敪�Ɋւ�炸�D�Ǖi�̕W�����i���\��������Q�̑Ή�</br>
        /// <br>Programmer : 30757 ���X�� �M�p</br>
        /// <br>Date       : 2015/04/16</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00</br>
        /// <br></br>
        /// <br>Update Note: </br>
        /// <br>           : </br>
        /// <br></br>
        /// </remarks>
        public int SalesDetailRowSalesUnitPriceReSetting(int salesRowNo, double listPriceDisplay)
        {
            return this.salesDetailRowSalesUnitPriceReSettingProc(salesRowNo, listPriceDisplay);
        }
        
        /// <summary>
        /// ���׍��ڕύX���̕W�����i�y�є��P���ύX�����i���́j
        /// </summary>
        /// <param name="salesRowNo">���׍s�ԍ�</param>
        /// <param name="listPriceDisplay">�ݒ肷��W�����i</param>
        /// <returns>0:�����A0�ȊO:���s</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// �p�����[�^salesRowNo�Őݒ肵���ԍ��̖��׍s�ԍ��̖��׃��R�[�h�����݂��Ȃ��ꍇ�ɔ������܂��B
        /// </exception>
        /// <remarks>
        /// <br>Note       : �Г���Q��684 �̔��敪�A�q�ɃR�[�h��ύX����ƕ\���敪�Ɋւ�炸�D�Ǖi�̕W�����i���\��������Q�̑Ή�</br>
        /// <br>Programmer : 30757 ���X�� �M�p</br>
        /// <br>Date       : 2015/04/16</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00</br>
        /// <br></br>
        /// <br>Update Note: �Г���Q��707 �̔��敪��ύX�����ꍇ�ɔ������Čv�Z����Ȃ���Q�̑Ή�</br>
        /// <br>Programmer : �e�c ���V</br>
        /// <br>Date       : 2015/09/03</br>
        /// <br>�Ǘ��ԍ�   : 11170139-00</br>
        /// <br></br>
        /// </remarks>
        private int salesDetailRowSalesUnitPriceReSettingProc(int salesRowNo, double listPriceDisplay)
        {
            int result = -1;
            int rowIndex = salesRowNo - 1;

            SalesInputDataSet.SalesDetailRow nowRow = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (null == nowRow)
            {
                throw new ArgumentOutOfRangeException("salesRowNo", "salesRowNo�Ŏw�肵�����׍s�ԍ��̃��R�[�h�͔��㖾�׃f�[�^�ɑ��݂��܂���B");
            }

            //�W�����i�ݒ�
            nowRow.ListPriceDisplay = listPriceDisplay;
            // ���㖾�׃f�[�^�Z�b�e�B���O�����i�艿�ݒ�j
            this.SalesDetailRowListPriceSetting(
                salesRowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPriceDisplay, listPriceDisplay, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);

            //���P���ݒ�
            if (nowRow.SalesRate != 0)
            {
                // ���㖾�׃f�[�^�Z�b�e�B���O�����i�P���ݒ�j
                this.SalesDetailRowSalesUnitPriceSettingbyRate(salesRowNo, nowRow.SalesRate, false);
            }
            else
            {
                if (string.IsNullOrEmpty(nowRow.RateDivSalUnPrc))
                {
                    if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv == 1) // �������艿
                    {
                        this.SalesDetailRowSalesUnitPriceSetting(
                            salesRowNo, SalesSlipInputAcs.SalesUnitPriceInputType.SalesUnitPrice, listPriceDisplay, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable, 0);
                    }

                    // --- ADD 2015/09/03 Y.Wakita �Г���Q��707 ---------->>>>>
                    //�L�����y�[���l����
                    if (nowRow.CampaignDiscountRate != 0)
                    {
                        GoodsUnitData goodsUnitData = new GoodsUnitData();
                        goodsUnitData = this.GetGoodsUnitDataDic(nowRow.GoodsMakerCd, nowRow.GoodsNo, nowRow);

                        if (goodsUnitData.GoodsPriceList != null && goodsUnitData.GoodsPriceList.Count > 0)
                        {
                            List<GoodsPrice> tempGoodsPriceList = new List<GoodsPrice>();
                            foreach (GoodsPrice goodsPrice in goodsUnitData.GoodsPriceList)
                            {
                                goodsPrice.ListPrice = nowRow.ListPriceDisplay;
                                tempGoodsPriceList.Add(goodsPrice);
                            }
                            goodsUnitData.GoodsPriceList = tempGoodsPriceList;
                        }
                        this.SettingSalesDetailGoodsCampaignPriceOnChange(nowRow.SalesRowNo, goodsUnitData);
                    }
                    // --- ADD 2015/09/03 Y.Wakita �Г���Q��707 ----------<<<<<
                }
            }
            // ������z�v�Z����
            this.CalculationSalesMoney(rowIndex, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
            
            result = 0;

            return result;
        }
        //---ADD 30757 ���X�� �M�p 2015/04/16 �Г���Q��684 �̔��敪�A�q�ɃR�[�h��ύX����ƕ\���敪�Ɋւ�炸�D�Ǖi�̕W�����i���\��������Q�̑Ή� ----------------<<<<<
        
        /// <summary>
        /// �݌Ƀ��X�g��莟�݌ɏ��擾
        /// </summary>
        /// <param name="warehouseCd">�q�ɃR�[�h</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <returns></returns>
        private Stock GetStockNext(string warehouseCd, GoodsUnitData goodsUnitData)
        {
            Stock retStock = null;

            // �D��q�Ƀ��X�g�쐬(���Ӑ�D��q�Ɂ{���_�D��q��)
            List<string> warehouseList = new List<string>();
            //warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.SectWarehouseCd, this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 DEL
            warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.GetSectWarehouseCd(this._salesSlip.ResultsAddUpSecCd), this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 ADD

            if ((goodsUnitData != null) && (goodsUnitData.StockList != null))
            {
                // �D��q�ɂ̂ݑΏ�
                foreach (Stock stock in goodsUnitData.StockList)
                {
                    if (retStock != null) break;

                    Stock tempStock = null;
                    for (int i = 0; i < warehouseList.Count; i++)
                    {
                        if (this.GetSectWarehousePriorityRank(warehouseList, warehouseCd.Trim()) < this.GetSectWarehousePriorityRank(warehouseList, warehouseList[i]))
                        {
                            tempStock = this._salesSlipInputInitDataAcs.GetStockFromStockList(warehouseList[i], goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, goodsUnitData.StockList);
                        }
                        if (tempStock != null)
                        {
                            retStock = tempStock;
                            break;
                        }
                    }
                }

                // �݌Ƀ}�X�^�̂ݑΏ�
                if (retStock == null)
                {
                    foreach (Stock stock in goodsUnitData.StockList)
                    {
                        if (this.GetSectWarehousePriorityRank(warehouseList, stock.WarehouseCode.Trim()) <= warehouseList.Count) continue;
                        if (!this.CheckSectWarehouse(warehouseList, warehouseCd.Trim()))
                        {
                            if (TStrConv.StrToIntDef(stock.WarehouseCode, 0) <= TStrConv.StrToIntDef(warehouseCd, 0)) continue;
                        }
                        retStock = stock;
                        break;
                    }
                }
            }

            return retStock;
        }

        /// <summary>
        /// �D��q�ɏ��ʈʒu�擾����
        /// </summary>
        /// <param name="warehouseList"></param>
        /// <param name="warehouseCd"></param>
        /// <returns></returns>
        private int GetSectWarehousePriorityRank(List<string>warehouseList, string warehouseCd)
        {
            if (string.IsNullOrEmpty(warehouseCd)) return 0;
            for (int i = 0; i < warehouseList.Count; i++)
            {
                if (warehouseCd.Trim() == warehouseList[i].Trim()) return i + 1;
            }
            return warehouseList.Count + 1;
        }

        /// <summary>
        /// �D��q�ɊY���`�F�b�N
        /// </summary>
        /// <param name="warehouseList"></param>
        /// <param name="warehouseCd"></param>
        /// <returns></returns>
        private bool CheckSectWarehouse(List<string> warehouseList, string warehouseCd)
        {
            bool ret = false;
            if (warehouseList.Contains(warehouseCd)) ret = true;
            return ret;
        }

        // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// �{�ЊǗ��q�ɊY���`�F�b�N(�c�Ə��ł̓��͎��͗D��ݒ肳��Ă��Ȃ��q�ɂ̓��͕͂s��)
        /// </summary>
        /// <param name="warehouseList"></param>
        /// <param name="warehouseCd"></param>
        /// <returns></returns>
        public bool CheckPriorWarehouse(string warehouseCd)
        {
            bool ret = false;

            List<string> warehouseList = new List<string>();
            warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.GetSectWarehouseCd(this._salesSlip.ResultsAddUpSecCd), this._salesSlip.CustWarehouseCd, 0);
            // --- UPD 2013/10/11 T.Miyamoto ------------------------------>>>>>
            //if (warehouseList.Contains(warehouseCd)) ret = true;
            if (warehouseList.Contains(warehouseCd.Trim())) ret = true;
            // --- UPD 2013/10/11 T.Miyamoto ------------------------------<<<<<
            return ret;
        }
        // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<

        /// <summary>
        /// �q�Ƀ��X�g�ʒu�w��ǉ�����
        /// </summary>
        /// <param name="sectWarehouseCdList"></param>
        /// <param name="targetCode"></param>
        /// <param name="index"></param>
        /// <remarks>index�����X�g�����𒴂���ꍇ�A�ŏI�ɒǉ�</remarks>
        private List<string> AddWarehouseList(List<string> sectWarehouseCdList, string targetCode, int index)
        {
            // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
            if (this._salesSlipInputInitDataAcs.Opt_Cpm_FutabaWarehAlloc == (int)SalesSlipInputInitDataAcs.Option.ON)
            {
                List<string> warehouseListC = new List<string>();

                // �{�ЊǗ��q�Ƀ}�X�^����q�Ƀ��X�g�擾
                List<string> WarehouseCdList = this._salesSlipInputInitDataAcs.GetPriorWarehouseInfo(this._enterpriseCode, this._sectionCode);

                // ���Ӑ敪�̓R�[�h�擾
                CustomerInfo customerInfoWrk;
                int custStatus = this._customerInfoAcs.ReadDBData(ConstantManagement.LogicalMode.GetData0, this._enterpriseCode, this._salesSlip.CustomerCode, true, false, out customerInfoWrk);
                if (custStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL) customerInfoWrk = new CustomerInfo();
                _CustAnalysCode1 = customerInfoWrk.CustAnalysCode1;

                // ���蓾�Ӑ�̏ꍇ
                if (customerInfoWrk.CustAnalysCode1 != 0)
                {
                    warehouseListC.AddRange(WarehouseCdList);
                    warehouseListC.Add(targetCode.Trim());
                }
                else
                {
                    warehouseListC.Add(targetCode.Trim());

                    // �w�苒�_���{�ЊǗ��q�Ƀ}�X�^�ɓo�^�ς̏ꍇ�A���_���{��
                    if (!this._salesSlipInputInitDataAcs.CheckMainSection(this._enterpriseCode, this.SectionCode))
                    {
                        // �c�Ə��̏ꍇ
                        warehouseListC.AddRange(sectWarehouseCdList);
                    }
                    warehouseListC.AddRange(WarehouseCdList);
                }
                return warehouseListC;
            }
            // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<

            // �ݒ�R�[�h�s���ȏꍇ
            if ((targetCode == null) || (targetCode.Trim() == string.Empty)) return sectWarehouseCdList;

            List<string> warehouseList = new List<string>();

            // �w��Index�����X�g�����𒴂����ꍇ
            if (sectWarehouseCdList.Count - 1 < index) 
            {
                warehouseList.AddRange(sectWarehouseCdList);
                warehouseList.Add(targetCode.Trim());
                return warehouseList;
            }

            int sectIndex = 0;

            for (int i = 0; i < sectWarehouseCdList.Count + 1; i++)
            {
                if (i == index)
                {
                    warehouseList.Add(targetCode.Trim());
                }
                else
                {
                    warehouseList.Add(sectWarehouseCdList[sectIndex]);
                    sectIndex++;
                }
            }
            return warehouseList;
        }

        // 2012/08/30 ADD T.Yoshioka 2012/10���z�M�\�� SCM��Q��10345 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �q�Ƀ��X�g�擾
        /// </summary>
        /// <param name="sectWarehouseCdList">���_�i�D��j</param>
        /// <param name="targetCode">�ϑ�</param>
        /// <remarks></remarks>
        private List<string> AddWarehouseList2(List<string> sectWarehouseCdList, string targetCode)
        {
            if ((targetCode == null) || (targetCode.Trim() == string.Empty))
            {
                targetCode = string.Empty;
            }

            List<string> warehouseList = new List<string>();

            // �ϑ��q�ɂ̒ǉ�
            warehouseList.Add(targetCode.Trim());

            for (int i = 0; i < sectWarehouseCdList.Count; i++)
            {
                warehouseList.Add(sectWarehouseCdList[i]);
            }
            return warehouseList;
        }

        /// <summary>
        /// �D��q�Ƀ��X�g(PCC���Аݒ�}�X�^�̗D��q��)�𐶐����܂��B
        /// </summary>
        /// <param name="headerRecord">SCM�󒍃f�[�^�̃��R�[�h</param>
        /// <returns>�D��q�Ƀ��X�g</returns>
        //
        /// <summary>
        /// �D��q�Ƀ��X�g(PCC���Аݒ�}�X�^�̗D��q��)�𐶐����܂��B
        /// </summary>
        /// <param name="InqOriginalEpCd">�⍇������ƃR�[�h</param>
        /// <param name="InqOriginalSecCd">�⍇�������_�R�[�h</param>
        /// <param name="InqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="InqOtherSecCd">�⍇���拒�_�R�[�h</param>
        /// <returns></returns>
        private List<string> CreatePriorWarehouseListForPccuoe(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd)
        {
            PccCmpnyStWork pccCmpnySt = searchPccCmpnyStList(inqOriginalEpCd.Trim(), inqOriginalSecCd, inqOtherEpCd, inqOtherSecCd);//@@@@20230303

            List<string> sectWarehouseCdList = new List<string>();
            if (pccCmpnySt != null)
            {
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccWarehouseCd) ? "" : pccCmpnySt.PccWarehouseCd.Trim());
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccPriWarehouseCd1) ? "" : pccCmpnySt.PccPriWarehouseCd1.Trim());
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccPriWarehouseCd2) ? "" : pccCmpnySt.PccPriWarehouseCd2.Trim());
                sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccPriWarehouseCd3) ? "" : pccCmpnySt.PccPriWarehouseCd3.Trim());
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------>>>>>
                int opt_BLPPriWarehouse = -1;
                this._salesSlipInputInitDataAcs.GetBLPPriWarehouseOptInfo(out opt_BLPPriWarehouse);
                if (opt_BLPPriWarehouse == (int)SalesSlipInputInitDataAcs.Option.ON)
                    sectWarehouseCdList.Add(string.IsNullOrEmpty(pccCmpnySt.PccPriWarehouseCd4) ? "" : pccCmpnySt.PccPriWarehouseCd4.Trim());
                // ADD 2013/09/13 SCM�d�|�ꗗ��10571�Ή� ------------------------------------------<<<<<

            }
            return sectWarehouseCdList;
        }
        /// <summary>
        /// ���Аݒ�}�X�g�f�[�^���擾����
        /// </summary>
        /// <param name="inqOriginalEpCd">�⍇������ƃR�[�h</param>
        /// <param name="inqOriginalSecCd">�⍇�������_�R�[�h</param>
        /// <param name="inqOtherEpCd">�⍇�����ƃR�[�h</param>
        /// <param name="inqOtherSecCd">�⍇���拒�_�R�[�h</param>
        /// <returns></returns>
        public static PccCmpnyStWork searchPccCmpnyStList(string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd)
        {
            IPccCmpnyStDB writer = MediationPccCmpnyStDB.GetPccCmpnyStDB();

            object pccCmpnyStObj = null;
            // �����p�����[�^
            PccCmpnyStWork parsePccCmpnyStWork = new PccCmpnyStWork();
            // �⍇������ƃR�[�h
            parsePccCmpnyStWork.InqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
            // �⍇�������_�R�[�h
            parsePccCmpnyStWork.InqOriginalSecCd = inqOriginalSecCd;
            // �⍇�����ƃR�[�h
            parsePccCmpnyStWork.InqOtherEpCd = inqOtherEpCd;
            // �⍇���拒�_�R�[�h
            parsePccCmpnyStWork.InqOtherSecCd = inqOtherSecCd;
            // �����敪(���ݖ��g�p)
            int readMode = 0;
            // �_���폜�L��
            ConstantManagement.LogicalMode logicalMode = ConstantManagement.LogicalMode.GetData0;

            int status = writer.Search(out pccCmpnyStObj, parsePccCmpnyStWork, readMode, logicalMode);

            if (status == (int)Broadleaf.Library.Resources.ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return (PccCmpnyStWork)((ArrayList)pccCmpnyStObj)[0];
            }
            else
            {
                #region <Log>

                string msg = string.Format(
                    "�D��q�Ƀ��X�g(PCC���Аݒ�}�X�^�̗D��q��)�𐶐���...PCC���Аݒ��񂪌����ł��܂���ł����B(�⍇������ƃR�[�h=�u{0}�v, �⍇�������_�R�[�h=�u{1}�v, �⍇�����ƃR�[�h=�u{2}�v, �⍇���拒�_�R�[�h=�u{3}�v)",
                    inqOriginalEpCd.Trim(),//@@@@20230303
                    inqOriginalSecCd,
                    inqOtherEpCd,
                    inqOtherSecCd
                );
                SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "searchPccCmpnyStList", msg);

                #endregion 
            }
            return null;
        }
        // 2012/08/30 ADD T.Yoshioka 2012/10���z�M�\�� SCM��Q��10345 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        //>>>2010/10/01
        ///// <summary>
        ///// ���i�A���f�[�^�I�u�W�F�N�g�擾(���iDictionary���擾)
        ///// </summary>
        ///// <param name="goodsMakerCode"></param>
        ///// <param name="goodsNo"></param>
        ///// <returns></returns>
        //public GoodsUnitData GetGoodsUnitDataDic(int goodsMakerCode, string goodsNo)
        //{
        //    GoodsUnitData goodsUnitData = null;
        //    GoodsInfoKey goodsInfoKey = new GoodsInfoKey(goodsNo, goodsMakerCode);
        //    if (this._goodsUnitDataInfo.ContainsKey(goodsInfoKey)) goodsUnitData = this._goodsUnitDataInfo[goodsInfoKey];
        //    GoodsUnitData retGoodsUnitData = (goodsUnitData != null) ? goodsUnitData.Clone() : null;
        //    return retGoodsUnitData;
        //}


        /// <summary>
        /// ���i�A���f�[�^�I�u�W�F�N�g�擾(���iDictionary���擾)
        /// </summary>
        /// <param name="goodsMakerCode"></param>
        /// <param name="goodsNo"></param>
        /// <returns></returns>
        public GoodsUnitData GetGoodsUnitDataDic(int goodsMakerCode, string goodsNo)
        {
            return this.GetGoodsUnitDataDic(goodsMakerCode, goodsNo, null);
        }

        /// <summary>
        /// ���i�A���f�[�^�I�u�W�F�N�g�擾(���iDictionary���擾)
        /// </summary>
        /// <param name="goodsMakerCode"></param>
        /// <param name="goodsNo"></param>
        /// <returns></returns>
        public GoodsUnitData GetGoodsUnitDataDic(int goodsMakerCode, string goodsNo, SalesInputDataSet.SalesDetailRow row)
        {
            GoodsUnitData goodsUnitData = null;
            GoodsInfoKey goodsInfoKey = new GoodsInfoKey(goodsNo, goodsMakerCode);
            if (this._goodsUnitDataInfo.ContainsKey(goodsInfoKey)) goodsUnitData = this._goodsUnitDataInfo[goodsInfoKey];
            GoodsUnitData retGoodsUnitData = (goodsUnitData != null) ? goodsUnitData.Clone() : null;

            if ((retGoodsUnitData != null) && (row != null))
            {
                if (retGoodsUnitData.GoodsPriceList == null)
                {
                    List<GoodsPrice> goodsPriceList = new List<GoodsPrice>();
                    GoodsPrice goodsPrice = new GoodsPrice();
                    goodsPrice.PriceStartDate = this._salesSlip.SalesDate;
                    goodsPriceList.Add(goodsPrice);
                    retGoodsUnitData.GoodsPriceList = goodsPriceList;
                }

                if (row.GoodsMakerCd != 0)
                {
                    retGoodsUnitData.GoodsMakerCd = row.GoodsMakerCd;
                }

                if (row.BLGoodsCode != 0)
                {
                    retGoodsUnitData.BLGoodsCode = row.BLGoodsCode;
                    retGoodsUnitData.BLGoodsFullName = row.BLGoodsFullName;
                }

                if (row.SupplierCd != 0)
                {
                    retGoodsUnitData.SupplierCd = row.SupplierCd;
                }
                // ----- ADD ���N�@2013/07/10 Redmine#37769 ----->>>>>
                if (row.BLGroupCode != 0)
                {
                    retGoodsUnitData.BLGroupCode = row.BLGroupCode;  //BL�O���[�v�R�[�h
                    retGoodsUnitData.BLGroupName = row.BLGroupName;  //BL�O���[�v�R�[�h��
                }
                if (row.GoodsMGroup != 0)
                {
                    retGoodsUnitData.GoodsMGroup = row.GoodsMGroup;�@//�����ރR�[�h
                    retGoodsUnitData.GoodsMGroupName = row.GoodsMGroupName;  //�����ޖ�
                }
                if (row.GoodsLGroup != 0)
                {
                    retGoodsUnitData.GoodsLGroup = row.GoodsLGroup; //�啪�ރR�[�h
                    retGoodsUnitData.GoodsLGroupName = row.GoodsLGroupName;�@//�啪�ޖ�
                }
                // ----- ADD ���N�@2013/07/10 Redmine#37769 -----<<<<<
            }

            return retGoodsUnitData;
        }
        //<<<2010/10/01

        /// <summary>
        /// ���i�A���f�[�^�I�u�W�F�N�g�̍݌ɃI�u�W�F�N�g�擾(���iDictionary���擾)
        /// </summary>
        /// <param name="goodsMakerCode"></param>
        /// <param name="goodsNo"></param>
        /// <param name="warehouseCode"></param>
        /// <returns></returns>
        public Stock GetGoodsUnitDataDicStock(int goodsMakerCode, string goodsNo, string warehouseCode)
        {
            GoodsUnitData goodsUnitData = null;
            GoodsInfoKey goodsInfoKey = new GoodsInfoKey(goodsNo, goodsMakerCode);
            if (this._goodsUnitDataInfo.ContainsKey(goodsInfoKey)) goodsUnitData = this._goodsUnitDataInfo[goodsInfoKey];

            Stock stock = null;
            if (goodsUnitData != null)
            {
                stock = this._salesSlipInputInitDataAcs.GetStockFromStockList(warehouseCode, goodsMakerCode, goodsNo, goodsUnitData.StockList);
            }
            return stock;

        }

        /// <summary>
        /// ���i�A���f�[�^�I�u�W�F�N�g�L���b�V��(���iDictionary)
        /// </summary>
        /// <param name="goodsUnitDataListList"></param>
        private void CacheGoodsUnitDataDic(List<List<GoodsUnitData>> goodsUnitDataListList)
        {
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            foreach (List<GoodsUnitData> goodsUnitDataList in goodsUnitDataListList)
            {
                if ((goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                {
                    goodsUnitData = goodsUnitDataList[0].Clone();
                    this.SettingGoodsUnitDataDic(goodsUnitData);
                }
            }
        }

        /// <summary>
        /// ���i�A���f�[�^�I�u�W�F�N�g�ݒ菈��(���iDictionary)
        /// </summary>
        /// <param name="goodsUnitData"></param>
        private void SettingGoodsUnitDataDic(GoodsUnitData goodsUnitData)
        {
            GoodsInfoKey goodsInfoKey = new GoodsInfoKey(goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd);
            if (this._goodsUnitDataInfo.ContainsKey(goodsInfoKey)) this._goodsUnitDataInfo.Remove(goodsInfoKey);
            this._goodsUnitDataInfo.Add(goodsInfoKey, goodsUnitData);
        }

        /// <summary>
        /// ���i�A���f�[�^�I�u�W�F�N�g�݌ɏ��ݒ菈��(���iDictionary)
        /// </summary>
        /// <param name="stock"></param>
        private void SettingGoodsUnitDataDicStockList(Stock stock)
        {
            GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(stock.GoodsMakerCd, stock.GoodsNo);
            this.SettingGoodsUnitDataDicStockList(ref goodsUnitData, stock);
            this.SettingGoodsUnitDataDic(goodsUnitData);
        }

        /// <summary>
        /// ���i�A���f�[�^�I�u�W�F�N�g�݌ɏ��ݒ菈��(���iDictionary)
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="stock"></param>
        private void SettingGoodsUnitDataDicStockList(ref GoodsUnitData goodsUnitData, Stock stock)
        {
            GoodsUnitData tempGoodsUnitData = goodsUnitData.Clone();
            if ((goodsUnitData != null) && (stock != null))
            {
                int index = 0;
                foreach (Stock checkStock in tempGoodsUnitData.StockList)
                {
                    if (checkStock.WarehouseCode == stock.WarehouseCode)
                    {
                        goodsUnitData.StockList[index] = stock;
                        return;
                    }
                    index++;
                }
                goodsUnitData.StockList.Add(stock);
            }
        }

        /// <summary>
        /// �i�Ԍ���
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="partsInfoDataSet">���i�����f�[�^�Z�b�g</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2009/10/19 ���M �ێ�˗��A�@�\�Ή�</br>
        /// <br></br>
        /// <br>Update Note: 2015/04/06 30757 ���X�� �M�p</br>
        /// <br>�Ǘ��ԍ�   : 11070149-00</br>
        /// <br>             �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή�</br>
        /// <br></br>
        /// </remarks>
        public int SearchPartsFromGoodsNo(string enterpriseCode, string sectionCode, int goodsMakerCode, string goodsNo, int salesRowNo, out List<GoodsUnitData> goodsUnitDataList)
        {
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SearchPartsFromGoodsNo", "�������O�������@�J�n");
            #region �������O������
            //-----------------------------------------------------------------------------
            // ������
            //-----------------------------------------------------------------------------
            string msg;
            PartsInfoDataSet partsInfoDataSet;
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            #endregion
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SearchPartsFromGoodsNo", "�������O�������I��");

            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SearchPartsFromGoodsNo", "�����o�����ݒ�@�J�n");
            #region �����o�����ݒ�
            //-----------------------------------------------------------------------------
            // ���o�����ݒ�
            //-----------------------------------------------------------------------------
            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;
            cndtn.GoodsMakerCd = goodsMakerCode;
            cndtn.GoodsNo = goodsNo;
            cndtn.SubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstCondDivCd;
            cndtn.PrmSubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PrmSubstCondDivCd;
            cndtn.SubstApplyDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstApplyDivCd;
            cndtn.SearchUICntDivCd = this._salesSlipInputConstructionAcs.SearchUICntDivCdValue;
            cndtn.EnterProcDivCd = this._salesSlipInputConstructionAcs.EnterProcDivCdValue;
            cndtn.PartsNoSearchDivCd = this._salesSlipInputConstructionAcs.PartsNoSearchDivCdValue;
            cndtn.PartsJoinCntDivCd = this._salesSlipInputConstructionAcs.PartsJoinCntDivCdValue;
            cndtn.EraNameDispCd1 = this._salesSlipInputInitDataAcs.GetAllDefSet().EraNameDispCd1;
            cndtn.PartsSearchPriDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsSearchPriDivCd;
            cndtn.JoinInitDispDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().JoinInitDispDiv;
            cndtn.PriceApplyDate = this._salesSlip.SalesDate;
            cndtn.IsSettingSupplier = 1;

            // --- ADD 2009/10/19 ---------->>>>>
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if ((row != null) && (row.CarRelationGuid != Guid.Empty))
            {
                cndtn.SearchCarInfo = this.GetCarInfoNew(row.CarRelationGuid);
            }
            else
            {
                cndtn.SearchCarInfo = this.GetCarInfoNew(this._beforeCarRelationGuid);
            }
            // --- ADD 2009/10/19 ----------<<<<<
            #endregion
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SearchPartsFromGoodsNo", "�����o�����ݒ�@�I��");

            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SearchPartsFromGoodsNo", "�������i�����@�J�n");
            #region �����i����
            //-----------------------------------------------------------------------------
            // ���i����
            //-----------------------------------------------------------------------------
            int status = this._salesSlipInputInitDataAcs.SearchPartsFromGoodsNo(cndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);
            // ADD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� --------------------->>>>>
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this.GetOfrPriceDataList(partsInfoDataSet, goodsUnitDataList);
            }
            // ADD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� ---------------------<<<<<

            #endregion
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SearchPartsFromGoodsNo", "�������i�����@�I��", "������:" + goodsUnitDataList.Count.ToString());

            switch ((ConstantManagement.MethodResult)status)
            {
                case ConstantManagement.MethodResult.ctFNC_CANCEL: // �I�𖳂�
                    break;
                case ConstantManagement.MethodResult.ctFNC_NORMAL: // �ʏ폈��
#if true
                    if (partsInfoDataSet.CalculateGoodsPrice == null)
                    {
                        partsInfoDataSet.CalculateGoodsPrice += new PartsInfoDataSet.CalculateGoodsPriceCallback(this.CalculateUnitPrice);
                    }
                    if (partsInfoDataSet.CalculatePrice == null)
                    {
                        partsInfoDataSet.CalculatePrice += new PartsInfoDataSet.CalculatePriceCallback(this.CalcPrice);
                    }

                    partsInfoDataSet.PriceApplyDate = this._salesSlip.SalesDate;
#else
                    SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "�����i�A���f�[�^�s�����ݒ�@�J�n");
                    #region �����i�A���f�[�^�s�����ݒ�
                    //-----------------------------------------------------------------------------
                    // ���i�A���f�[�^�s�����ݒ�
                    //-----------------------------------------------------------------------------
                    this._salesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true);
                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "�����i�A���f�[�^�s�����ݒ�@�I��", "��������:" + goodsUnitDataList.Count.ToString());

                    SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "CalclationUnitPrice", "���P�����擾�@�J�n");
                    #region ���P�����擾
                    //-----------------------------------------------------------------------------
                    // �P�����擾
                    //-----------------------------------------------------------------------------
                    unitPriceCalcRetList = this.CalclationUnitPrice(goodsUnitDataList);
                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "CalclationUnitPrice", "���P�����擾�@�I��", "�Ώۏ��i��:" + goodsUnitDataList.Count.ToString(), "�Y���P�����:" + unitPriceCalcRetList.Count);

                    SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "SetUnitPriceInfo", "���P�����𕔕i�����f�[�^�Z�b�g�֔��f�@�J�n");
                    #region ���P�����𕔕i�����f�[�^�Z�b�g�֔��f
                    //-----------------------------------------------------------------------------
                    // �P�����𕔕i�����f�[�^�Z�b�g�֔��f
                    //-----------------------------------------------------------------------------
                    if ((unitPriceCalcRetList != null) && (unitPriceCalcRetList.Count != 0)) partsInfoDataSet.SetUnitPriceInfo(unitPriceCalcRetList);
                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "SetUnitPriceInfo", "���P�����𕔕i�����f�[�^�Z�b�g�֔��f�@�I��", "�Ώۏ��i��:" + goodsUnitDataList.Count.ToString(), "�Y���P�����:" + unitPriceCalcRetList.Count);
#endif
                    //>>>2010/02/26
                    // �L�����y�[�����i�K�p�����ǉ�
                    partsInfoDataSet.CustomerCode = this._salesSlip.CustomerCode;
                    if (partsInfoDataSet.ReflectCampaign == null)
                    {
                        partsInfoDataSet.ReflectCampaign += new PartsInfoDataSet.ReflectCampaignCallback(this.ReflectCampaign);
                    }
                    //<<<2010/02/26

                    SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "", "���e��ݒ�@�J�n");
                    #region ���e��ݒ�
                    //-----------------------------------------------------------------------------
                    // �D��q�ɐݒ�
                    //-----------------------------------------------------------------------------
                    // �D��q�Ƀ��X�g�쐬(���Ӑ�D��q�Ɂ{���_�D��q��)
                    List<string> warehouseList = new List<string>();
                    //warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.SectWarehouseCd, this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 DEL
                    warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.GetSectWarehouseCd(this._salesSlip.ResultsAddUpSecCd), this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 ADD
                    partsInfoDataSet.ListPriorWarehouse = warehouseList;
                    
                    //-----------------------------------------------------------------------------
                    // �i���\���敪
                    //-----------------------------------------------------------------------------
                    // DEL 2010/05/17 �i���\���Ή� ---------->>>>>
                    //partsInfoDataSet.PartsNameDspDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd;
                    // DEL 2010/05/17 �i���\���Ή� ----------<<<<<
                    // ADD 2010/05/17 �i���\���Ή� ---------->>>>>
                    partsInfoDataSet.SetPartsNameDisplayPattern(this._salesSlipInputInitDataAcs.GetSalesTtlSt());
                    // ADD 2010/05/17 �i���\���Ή� ----------<<<<<

                    // --- ADD 2009/10/19 ---------->>>>>
                    //�\���敪��۾�
                    partsInfoDataSet.PriceSelectDispDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PriceSelectDispDiv;
                    //������������عް�
                    if (partsInfoDataSet.SearchPartsForSrcParts == null)
                    {
                        partsInfoDataSet.SearchPartsForSrcParts += new PartsInfoDataSet.SearchPartsForSrcPartsCallBack(this.SearchPartsForSrcPartsPrc);
                    }
                    //���Ӑ溰��
                    partsInfoDataSet.CustomerCode = this._salesSlip.CustomerCode;
                    //���Ӑ�|����ٰ�ߺ���ؽ�
                    partsInfoDataSet.CustRateGrpCodeList = this._salesSlipInputInitDataAcs.GetGetCustRateGrpAll();
                    //���Ӑ�|����ٰ�ߎ擾��عް�
                    if (partsInfoDataSet.GetCustRateGrp == null)
                    {
                        partsInfoDataSet.GetCustRateGrp += new PartsInfoDataSet.GetCustRateGrpCallBack(this.GetCustRateGrpCode);
                    }
                    //�\���敪ؽ�
                    partsInfoDataSet.PriceSelectDivList = this._salesSlipInputInitDataAcs.GetDisplayDivList();
                    //�\���敪�擾��عް�
                    if (partsInfoDataSet.GetDisplayDiv == null)
                    {
                        partsInfoDataSet.GetDisplayDiv += new PartsInfoDataSet.GetDisplayDivCallBack(this.GetDisplayDiv);
                    }
                    // --- ADD 2009/10/19 ----------<<<<<

                    // ADD 2010/05/17 �i���\���Ή� ---------->>>>>
                    // BL���i���
                    if (partsInfoDataSet.GetBLGoodsInfo == null)
                    {
                        partsInfoDataSet.GetBLGoodsInfo += new PartsInfoDataSet.GetBLGoodsInfoCallBack(this.GetBLGoodsInfo);
                    }
                    // ADD 2010/05/17 �i���\���Ή� ----------<<<<<

                    // 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // �������ݒ莞�敪
                    partsInfoDataSet.UnPrcNonSettingDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv;
                    // 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
                    // �݌ɏ��e�[�u����ޔ�
                    PartsInfoDataSet.StockDataTable StockBack = new PartsInfoDataSet.StockDataTable();
                    StockBack = (PartsInfoDataSet.StockDataTable)partsInfoDataSet.Stock.Copy();

                    if (this._salesSlipInputInitDataAcs.Opt_Cpm_FutabaWarehAlloc == (int)SalesSlipInputInitDataAcs.Option.ON)
                    {
                        string rowFilter = "";

                        // ���蓾�Ӑ�̏ꍇ����݌ɐ����O�ȉ��̈������Ă͕s��
                        if (_CustAnalysCode1 == 1)
                        {
                            // �݌ɐ����O�ȉ��̃f�[�^�𒊏o
                            rowFilter = String.Format("{0}<={1}", partsInfoDataSet.Stock.ShipmentPosCntColumn.ColumnName, 0);
                            PartsInfoDataSet.StockRow[] rowStock = (PartsInfoDataSet.StockRow[])partsInfoDataSet.Stock.Select(rowFilter);

                            foreach (PartsInfoDataSet.StockRow stock in rowStock)
                            {
                                for (int iRow = 0; iRow < partsInfoDataSet.Stock.Count; iRow++)
                                {
                                    if ((partsInfoDataSet.Stock[iRow].GoodsMakerCd == stock.GoodsMakerCd) &&
                                        (partsInfoDataSet.Stock[iRow].GoodsNo == stock.GoodsNo) &&
                                        (partsInfoDataSet.Stock[iRow].WarehouseCode == stock.WarehouseCode))
                                    {
                                        // �݌Ƀe�[�u������Y���f�[�^�����O
                                        partsInfoDataSet.Stock.RemoveStockRow(partsInfoDataSet.Stock[iRow]);
                                        break;
                                    }
                                }
                            }
                        }
                        // �c�Ə��̏ꍇ����{�ЁE�����_�Őݒ肳��Ă���q�ɈȊO�̈������Ă͕s��
                        if (!this._salesSlipInputInitDataAcs.CheckMainSection(this._enterpriseCode, this.SectionCode))
                        {
                            if (partsInfoDataSet.ListPriorWarehouse != null)
                            {
                                // �{�ЁE�����_�Őݒ肳��Ă��Ȃ��q�ɂ𒊏o
                                rowFilter = "";
                                foreach (string PriorWarehouse in partsInfoDataSet.ListPriorWarehouse)
                                {
                                    if (rowFilter != "") rowFilter += " AND ";
                                    rowFilter += String.Format("{0}<>'{1}'", partsInfoDataSet.Stock.WarehouseCodeColumn.ColumnName, PriorWarehouse);
                                }
                                PartsInfoDataSet.StockRow[] rowStock = (PartsInfoDataSet.StockRow[])partsInfoDataSet.Stock.Select(rowFilter);

                                foreach (PartsInfoDataSet.StockRow stock in rowStock)
                                {
                                    for (int iRow = 0; iRow < partsInfoDataSet.Stock.Count; iRow++)
                                    {
                                        if ((partsInfoDataSet.Stock[iRow].GoodsMakerCd == stock.GoodsMakerCd) &&
                                            (partsInfoDataSet.Stock[iRow].GoodsNo == stock.GoodsNo) &&
                                            (partsInfoDataSet.Stock[iRow].WarehouseCode == stock.WarehouseCode))
                                        {
                                            // �݌Ƀe�[�u������Y���f�[�^�����O
                                            partsInfoDataSet.Stock.RemoveStockRow(partsInfoDataSet.Stock[iRow]);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<
                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "", "���e��ݒ�@�I��");

                    // �ԗ����␳
                    #region �ԗ����␳
                    // --- ADD 杍^ 2014/09/01 ---------->>>>>
                    this.SetCarInfoToThread(cndtn);
                    // --- ADD 杍^ 2014/09/01 ----------<<<<<
                    #endregion

                    SalesSlipInputInitDataAcs.LogWrite("UIDisplayControl", "ProcessPartsSearch", "�����i�I�𐧌�N���@�J�n");
                    #region �����i�I�𐧌�N��
                    //-----------------------------------------------------------------------------
                    // ���i�I�𐧌�N��
                    //-----------------------------------------------------------------------------
                    //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ---------------->>>>>
                    // ���i�I��UI����N���X�̐ÓI�����o�[�I�������i�ԏ�񃊃X�g���N���A����B
                    UIDisplayControl.CrearSelectedSrcList();
                    //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ----------------<<<<<
                    // --- UPD 2009/10/19 ---------->>>>>
                    partsInfoDataSet.SearchCarInfo = cndtn.SearchCarInfo;
                    DialogResult retDialog = UIDisplayControl.ProcessPartsSearch(this._owner, null, partsInfoDataSet);
                    // --- UPD 2009/10/19 ----------<<<<<
                    // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
                    if (this._salesSlipInputInitDataAcs.Opt_Cpm_FutabaWarehAlloc == (int)SalesSlipInputInitDataAcs.Option.ON)
                    {
                        // �݌ɏ��e�[�u����߂�
                        partsInfoDataSet.Stock.Clear();
                        PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])StockBack.Select();
                        foreach (PartsInfoDataSet.StockRow stock in StockBack)
                        {
                            partsInfoDataSet.Stock.ImportRow(stock);
                        }
                    }
                    // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<

                    // --- ADD 2013/12/10 Y.Wakita ---------->>>>>
                    // ���i�����̌��ʂ�ۊ�
                    _partsInfo = partsInfoDataSet;
                    // --- ADD 2013/12/10 Y.Wakita ----------<<<<<

                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("UIDisplayControl", "ProcessPartsSearch", "�����i�I�𐧌�N���@�I��");

                    switch (retDialog)
                    {
                        case DialogResult.Abort:
                        case DialogResult.Cancel:
                            partsInfoDataSet.Clear();
                            goodsUnitDataList.Clear();
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                        case DialogResult.Ignore:
                            break;
                        case DialogResult.No:
                            break;
                        case DialogResult.None:
                            break;
                        case DialogResult.OK:
                        case DialogResult.Yes:
                            SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "GetGoodsList", "�����i�����f�[�^�Z�b�g���珤�i�A���f�[�^�I�u�W�F�N�g�擾�@�J�n");
                            #region �����i�����f�[�^�Z�b�g����I�����̏��i�A���f�[�^�I�u�W�F�N�g���擾
                            //-----------------------------------------------------------------------------
                            // ���i�����f�[�^�Z�b�g����I�����̏��i�A���f�[�^�I�u�W�F�N�g���擾
                            //-----------------------------------------------------------------------------
                            // --- UPD 2014/01/15 T.Miyamoto ------------------------------>>>>>
                            ////>>>2010/02/26
                            ////goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(true, this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd).ToArray(typeof(GoodsUnitData)));
                            //goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(true, this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd, false).ToArray(typeof(GoodsUnitData)));
                            ////<<<2010/02/26
                            goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsListWithSrc(true, this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd, false).ToArray(typeof(GoodsUnitData)));
                            // --- UPD 2014/01/15 T.Miyamoto ------------------------------<<<<<
                            //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ---------------->>>>>

                            // ���i�I��UI����N���X�̐ÓI�����o�[�I�������i�ԏ�񃊃X�g���擾
                            List<GoodsUnitData> selectedSrcList = UIDisplayControl.SelectedSrcList;

                            // �I�������i�ԏ�񃊃X�g��null�łȂ��A���v�f����1�ȏ�̏ꍇ�A
                            // �������i�����j�i���̃Z�b�g���s��
                            if ( null != selectedSrcList && 0 < selectedSrcList.Count )
                            {
                                //�I�����̏��i�A���f�[�^�I�u�W�F�N�g���X�g�̗v�f���Ɍ������������ʂ�ݒ�
                                foreach (GoodsUnitData nowUnit in goodsUnitDataList)
                                {
                                     //�I��������񃊃X�g�̊Y����񂩂猋�����������ʂ��擾���Đݒ�
                                    foreach (GoodsUnitData nowSrc in selectedSrcList)
                                    {
                                        if (0 != string.Compare(nowUnit.GoodsNo, nowSrc.GoodsNo))
                                        {
                                            // ������i�D�ǁj�i�Ԃ��قȂ�ꍇ�A�ΏۊO
                                            continue;
                                        }
                                        if (nowUnit.GoodsMakerCd != nowSrc.GoodsMakerCd)
                                        {
                                            // ������i�D�ǁj�i���[�J�[�R�[�h���قȂ�ꍇ�A�ΏۊO
                                            continue;
                                        }

                                        // �������i�����j�i�̃��[�J�[�R�[�h��ݒ�
                                        nowUnit.JoinSourceMakerCode = nowSrc.JoinSourceMakerCode;
                                        // �������i�����j�i�̕i�Ԃ�ݒ�
                                        nowUnit.JoinSrcPartsNoWithH = nowSrc.JoinSrcPartsNoWithH;

                                        //�Ώۂ̕i�Ԍ������ʂ��猋�����i�����j�i�̕��i�����擾
                                        PartsInfoDataSet.UsrGoodsInfoRow targetGoodsInfoRow = partsInfoDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                                            nowUnit.JoinSourceMakerCode, nowUnit.JoinSrcPartsNoWithH);

                                        //�������i�����j�i�̕��i�����擾�o���Ȃ������ꍇ�A�������i�����j�i�̕��i����ǉ�����
                                        if (null == targetGoodsInfoRow)
                                        {
                                            PartsInfoDataSet.UsrGoodsInfoRow newRow = partsInfoDataSet.UsrGoodsInfo.NewUsrGoodsInfoRow();
                                            newRow.BlGoodsCode = nowUnit.BLGoodsCode;
                                            newRow.GoodsMakerCd = nowUnit.JoinSourceMakerCode;
                                            newRow.GoodsNo = nowUnit.JoinSrcPartsNoWithH;
                                            partsInfoDataSet.UsrGoodsInfo.AddUsrGoodsInfoRow(newRow);
                                            partsInfoDataSet.UsrGoodsInfo.AcceptChanges();
                                        }

                                        break;
                                    }
                                }
                            }
                            //---ADD 30757 ���X�� �M�p 2015/04/06 �d�|��2405 ���Ӑ�ύX���\���敪�Ď擾�Ή� ----------------<<<<<
                            #endregion
                            SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "GetGoodsList", "�����i�����f�[�^�Z�b�g���珤�i�A���f�[�^�I�u�W�F�N�g�擾�@�I��", "���ʃf�[�^�Z�b�g�Ώی���:" + partsInfoDataSet.UsrGoodsInfo.Count.ToString(), "�Ώی���:" + goodsUnitDataList.Count.ToString());
                            
                            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "�����i�A���f�[�^�s�����ݒ�@�J�n");
                            #region �����i�A���f�[�^�s�����ݒ�
                            //-------------------------------------------------------------------------
                            // ���i�A���f�[�^�s�����ݒ�
                            //-------------------------------------------------------------------------
                            this._salesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true, this._salesSlip.ResultsAddUpSecCd);
                            #endregion
                            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "�����i�A���f�[�^�s�����ݒ�@�I��", "��������:" + goodsUnitDataList.Count.ToString());
                            break;
                        case DialogResult.Retry:
                            break;
                    }
                    break;
                case ConstantManagement.MethodResult.ctFNC_NO_RETURN: // �Y���f�[�^����
                    break;
            }
            
            //>>>2013/04/06
            if ((goodsUnitDataList != null) && (goodsUnitDataList.Count != 0))
            {
                //<<<2013/04/06
                // ADD 2013/04/04 SCM��Q��10504�Ή� --------------------------------------->>>>>
                if (this._originalBLGoodsCodeMap.ContainsKey(salesRowNo))
                {
                    this._originalBLGoodsCodeMap[salesRowNo] = goodsUnitDataList[0].BLGoodsCode;
                }
                else
                {
                    this._originalBLGoodsCodeMap.Add(salesRowNo, goodsUnitDataList[0].BLGoodsCode);
                }
                // ���i�I����2�i�ȏ�I�������ꍇ���l��
                int cnt = goodsUnitDataList.Count - 1;
                for (int i = 0; i < cnt; i++)
                {
                    if (this._originalBLGoodsCodeMap.ContainsKey(salesRowNo + i + 1))
                    {
                        this._originalBLGoodsCodeMap[salesRowNo] = goodsUnitDataList[i].BLGoodsCode;
                    }
                    else
                    {
                        this._originalBLGoodsCodeMap.Add(salesRowNo + i + 1, goodsUnitDataList[i].BLGoodsCode);
                    }
                }
                // ADD 2013/04/04 SCM��Q��10504�Ή� ---------------------------------------<<<<<
            //>>>2013/04/06
            }
            else
            {
                // �i�Ԍ����ŊY�����Ȃ������ꍇ�A�Q���i�ȏ�̑I���͑��݂��Ȃ��̂ňȉ����W�b�N�݂̂Ƃ���
                if (this._originalBLGoodsCodeMap.ContainsKey(salesRowNo))
                {
                    this._originalBLGoodsCodeMap[salesRowNo] = 0;
                }
                else
                {
                    this._originalBLGoodsCodeMap.Add(salesRowNo, 0);
                }
            }
            //<<<2013/04/06

            return status;
        }

        /// <summary>
        /// BL�R�[�h����
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="bLGoodsCode">BL�R�[�h</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <returns>ConstantManagement.MethodResult(-3:�ԗ���񖳂�)</returns>
        /// <br>Update Note: 2009/10/19 ���M �ێ�˗��A�@�\�Ή�</br>
        /// <br>UpdateNote : 2011/10/27 ���� Redmine#26293 ����`�[���́^PM���炢���Ȃ�񓚂���ꍇ�̂a�k�R�[�h�̉񓚕��@�̑Ή�</br>
        //>>>2010/02/26
        //public int SearchPartsFromBLCode(int salesRowNo, string enterpriseCode, string sectionCode, int bLGoodsCode, out List<GoodsUnitData> goodsUnitDataList)
        public int SearchPartsFromBLCode(int salesRowNo, string enterpriseCode, string sectionCode, int bLGoodsCode, int blGoodsDrCode, out List<GoodsUnitData> goodsUnitDataList)
        //<<<2010/02/26
        {
            // ----- ADD 2011/10/27 ----- >>>>>
            if (this._originalBLGoodsCodeMap.ContainsKey(salesRowNo))
            {
                this._originalBLGoodsCodeMap[salesRowNo] = bLGoodsCode;
            }
            else
            {
                this._originalBLGoodsCodeMap.Add(salesRowNo, bLGoodsCode);
            }
            // ----- ADD 2011/10/27 ----- <<<<<
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "", "���a�k�R�[�h�����O�������@�J�n");
            #region ��������
            //-----------------------------------------------------------------------------
            // ������
            //-----------------------------------------------------------------------------
            string msg;
            PartsInfoDataSet partsInfoDataSet;
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            goodsUnitDataList = new List<GoodsUnitData>();
            #endregion
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "", "���a�k�R�[�h�����O�������@�I��");

            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "", "�����o�����ݒ�@�J�n");
            #region �����o�����ݒ�
            //-----------------------------------------------------------------------------
            // ���o�����ݒ�
            //-----------------------------------------------------------------------------
            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;
            cndtn.BLGoodsCode = bLGoodsCode;
            cndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
            cndtn.SubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstCondDivCd;
            cndtn.PrmSubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PrmSubstCondDivCd;
            cndtn.SubstApplyDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstApplyDivCd;
            cndtn.SearchUICntDivCd = this._salesSlipInputConstructionAcs.SearchUICntDivCdValue;
            cndtn.EnterProcDivCd = this._salesSlipInputConstructionAcs.EnterProcDivCdValue;
            cndtn.PartsNoSearchDivCd = this._salesSlipInputConstructionAcs.PartsNoSearchDivCdValue;
            cndtn.PartsJoinCntDivCd = this._salesSlipInputConstructionAcs.PartsJoinCntDivCdValue;
            cndtn.EraNameDispCd1 = this._salesSlipInputInitDataAcs.GetAllDefSet().EraNameDispCd1;
            cndtn.PartsSearchPriDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsSearchPriDivCd;
            cndtn.JoinInitDispDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().JoinInitDispDiv;
            cndtn.PriceApplyDate = this._salesSlip.SalesDate;
            cndtn.IsSettingSupplier = 1;

            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            //>>>ddddd
            //if ((row != null) && (row.CarRelationGuid != Guid.Empty))
            //    cndtn.SearchCarInfo = this.GetCarInfoFromDic(row.CarRelationGuid);
            //else
            //    cndtn.SearchCarInfo = this.GetCarInfoFromDic(this._beforeCarRelationGuid);

            Guid carGuid = Guid.Empty;
            if ((row != null) && (row.CarRelationGuid != Guid.Empty))
            {
                carGuid = row.CarRelationGuid;
            }
            else
            {
                carGuid = this._beforeCarRelationGuid;
            }

            cndtn.SearchCarInfo = this.GetCarInfoFromDic(carGuid);

            // --- ADD 2013/02/13 Y.Wakita ---------->>>>>
            if (cndtn.SearchCarInfo.CarModelUIData[0].ProduceTypeOfYearInput > 0)
            {
                if ((cndtn.SearchCarInfo.CarModelUIData[0].ProduceTypeOfYearInput % 100) == 0)
                {
                    cndtn.SearchCarInfo.CarModelUIData[0].ProduceTypeOfYearInput = 0;
                }
            }
            // --- ADD 2013/02/13 Y.Wakita ----------<<<<<

            //>>>2011/03/10
            //PMKEN01010E.ColorCdInfoDataTable colorTable = this.GetColorInfo(row.CarRelationGuid);
            //if (colorTable != null)
            //{
            //    PMKEN01010E.ColorCdInfoRow colorRow = this.GetSelectColorInfo(row.CarRelationGuid);
            //    if (colorRow != null)
            //    {
            //        this.SelectColorInfo(row.CarRelationGuid, cndtn.SearchCarInfo.ColorCdInfo, colorRow.ColorCode);
            //    }
            //}
            //PMKEN01010E.TrimCdInfoDataTable trimTable = this.GetTrimInfo(row.CarRelationGuid);
            //if (trimTable != null)
            //{
            //    PMKEN01010E.TrimCdInfoRow trimRow = this.GetSelectTrimInfo(row.CarRelationGuid);
            //    if (trimRow != null)
            //    {
            //        this.SelectTrimInfo(row.CarRelationGuid, cndtn.SearchCarInfo.TrimCdInfo, trimRow.TrimCode);
            //    }
            //}
            PMKEN01010E.ColorCdInfoDataTable colorTable = this.GetColorInfo(carGuid);
            if (colorTable != null)
            {
                PMKEN01010E.ColorCdInfoRow colorRow = this.GetSelectColorInfo(carGuid);
                if (colorRow != null)
                {
                    this.SelectColorInfo(carGuid, cndtn.SearchCarInfo.ColorCdInfo, colorRow.ColorCode);
                }
            }
            PMKEN01010E.TrimCdInfoDataTable trimTable = this.GetTrimInfo(carGuid);
            if (trimTable != null)
            {
                PMKEN01010E.TrimCdInfoRow trimRow = this.GetSelectTrimInfo(carGuid);
                if (trimRow != null)
                {
                    this.SelectTrimInfo(carGuid, cndtn.SearchCarInfo.TrimCdInfo, trimRow.TrimCode);
                }
            }
            //<<<2011/03/10
            //<<<ddddd
            #endregion
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "", "�����o�����ݒ�@�I��");

            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "", "�����q��񑶍݃`�F�b�N�@�J�n");
            #region ���ԗ���񑶍݃`�F�b�N
            //-----------------------------------------------------------------------------
            // �ԗ���񑶍݃`�F�b�N
            //-----------------------------------------------------------------------------
            if (cndtn.SearchCarInfo == null) return -3;
            #endregion
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "", "�����q��񑶍݃`�F�b�N�@�I��");

            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SearchPartsFromBLCode", "���a�k�R�[�h�����@�J�n");
            #region ��BL�R�[�h����
            //-----------------------------------------------------------------------------
            // BL�R�[�h����
            //-----------------------------------------------------------------------------
            int status = this._salesSlipInputInitDataAcs.SearchPartsFromBLCode(cndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);
            // ADD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� --------------------->>>>>
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this.GetOfrPriceDataList(partsInfoDataSet, goodsUnitDataList);
            }
            // ADD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� ---------------------<<<<<
            #endregion
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SearchPartsFromBLCode", "���a�k�R�[�h�����@�I��", "������:" + goodsUnitDataList.Count.ToString());

            switch ((ConstantManagement.MethodResult)status)
            {
                case ConstantManagement.MethodResult.ctFNC_CANCEL: // �I�𖳂�
                    break;
                case ConstantManagement.MethodResult.ctFNC_NORMAL: // �ʏ폈��
#if true
                    if (partsInfoDataSet.CalculateGoodsPrice == null)
                    {
                        partsInfoDataSet.CalculateGoodsPrice += new PartsInfoDataSet.CalculateGoodsPriceCallback(this.CalculateUnitPrice);
                    }
                    if (partsInfoDataSet.CalculatePrice== null)
                    {
                        partsInfoDataSet.CalculatePrice += new PartsInfoDataSet.CalculatePriceCallback(this.CalcPrice);
                    }
                    partsInfoDataSet.PriceApplyDate = this._salesSlip.SalesDate;
#else
                    SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "�����i�A���f�[�^�s�����ݒ�@�J�n");
                    #region �����i�A���f�[�^�s�����ݒ�
                    //-----------------------------------------------------------------------------
                    // ���i�A���f�[�^�s�����ݒ�
                    //-----------------------------------------------------------------------------
                    this._salesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true);
                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "�����i�A���f�[�^�s�����ݒ�@�I��", "��������:" + goodsUnitDataList.Count.ToString());

                    SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "CalclationUnitPrice", "���P�����擾�@�J�n");
                    #region ���P�����擾
                    //-----------------------------------------------------------------------------
                    // �P�����擾
                    //-----------------------------------------------------------------------------
                    unitPriceCalcRetList = this.CalclationUnitPrice(goodsUnitDataList);
                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "CalclationUnitPrice", "���P�����擾�@�I��", "�Ώۏ��i��:" + goodsUnitDataList.Count.ToString(), "�Y���P�����:" + unitPriceCalcRetList.Count);

                    SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "SetUnitPriceInfo", "���P�����𕔕i�����f�[�^�Z�b�g�֔��f�@�J�n");
                    #region ���P�����𕔕i�����f�[�^�Z�b�g�֔��f
                    //-----------------------------------------------------------------------------
                    // �P�����𕔕i�����f�[�^�Z�b�g�֔��f
                    //-----------------------------------------------------------------------------
                    if ((unitPriceCalcRetList != null) && (unitPriceCalcRetList.Count != 0)) partsInfoDataSet.SetUnitPriceInfo(unitPriceCalcRetList);
                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "SetUnitPriceInfo", "���P�����𕔕i�����f�[�^�Z�b�g�֔��f�@�I��", "�Ώۏ��i��:" + goodsUnitDataList.Count.ToString(), "�Y���P�����:" + unitPriceCalcRetList.Count);
#endif
                    SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "", "���e��ݒ�@�J�n");
                    #region ���e��ݒ�
                    //-----------------------------------------------------------------------------
                    // �D��q�ɐݒ�
                    //-----------------------------------------------------------------------------
                    // �D��q�Ƀ��X�g�쐬(���Ӑ�D��q�Ɂ{���_�D��q��)
                    List<string> warehouseList = new List<string>();
                    //warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.SectWarehouseCd, this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 DEL
                    warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.GetSectWarehouseCd(this._salesSlip.ResultsAddUpSecCd), this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 ADD
                    
                    partsInfoDataSet.ListPriorWarehouse = warehouseList;

                    //-----------------------------------------------------------------------------
                    // �i���\���敪
                    //-----------------------------------------------------------------------------
                    // DEL 2010/05/17 �i���\���Ή� ---------->>>>>
                    //partsInfoDataSet.PartsNameDspDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd;
                    // DEL 2010/05/17 �i���\���Ή� ----------<<<<<
                    // ADD 2010/05/17 �i���\���Ή� ---------->>>>>
                    partsInfoDataSet.SetPartsNameDisplayPattern(this._salesSlipInputInitDataAcs.GetSalesTtlSt());
                    // ADD 2010/05/17 �i���\���Ή� ----------<<<<<

                    //>>>2010/02/26
                    //-----------------------------------------------------------------------------
                    // BL�R�[�h�}��
                    //-----------------------------------------------------------------------------
                    partsInfoDataSet.BLGoodsDrCode = blGoodsDrCode;
                    //<<<2010/02/26

                    // --- ADD 2009/10/19 ---------->>>>>
                    //�\���敪��۾�
                    partsInfoDataSet.PriceSelectDispDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PriceSelectDispDiv;
                    //������������عް�
                    if (partsInfoDataSet.SearchPartsForSrcParts == null)
                    {
                        partsInfoDataSet.SearchPartsForSrcParts += new PartsInfoDataSet.SearchPartsForSrcPartsCallBack(this.SearchPartsForSrcPartsPrc);
                    }
                    //���Ӑ溰��
                    partsInfoDataSet.CustomerCode = this._salesSlip.CustomerCode;
                    //���Ӑ�|����ٰ�ߺ���ؽ�
                    partsInfoDataSet.CustRateGrpCodeList = this._salesSlipInputInitDataAcs.GetGetCustRateGrpAll();
                    //���Ӑ�|����ٰ�ߎ擾��عް�
                    if (partsInfoDataSet.GetCustRateGrp == null)
                    {
                        partsInfoDataSet.GetCustRateGrp += new PartsInfoDataSet.GetCustRateGrpCallBack(this.GetCustRateGrpCode);
                    }
                    //�\���敪ؽ�
                    partsInfoDataSet.PriceSelectDivList = this._salesSlipInputInitDataAcs.GetDisplayDivList();
                    //�\���敪�擾��عް�
                    if (partsInfoDataSet.GetDisplayDiv == null)
                    {
                        partsInfoDataSet.GetDisplayDiv += new PartsInfoDataSet.GetDisplayDivCallBack(this.GetDisplayDiv);
                    }
                    // --- ADD 2009/10/19 ----------<<<<<

                    // ADD 2010/05/17 �i���\���Ή� ---------->>>>>
                    // BL���i���
                    if (partsInfoDataSet.GetBLGoodsInfo == null)
                    {
                        partsInfoDataSet.GetBLGoodsInfo += new PartsInfoDataSet.GetBLGoodsInfoCallBack(this.GetBLGoodsInfo);
                    }
                    // ADD 2010/05/17 �i���\���Ή� ----------<<<<<   

                    // 2009/12/17 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // �������ݒ莞�敪
                    partsInfoDataSet.UnPrcNonSettingDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv;
                    // 2009/12/17 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
                    // �݌ɏ��e�[�u����ޔ�
                    PartsInfoDataSet.StockDataTable StockBack = new PartsInfoDataSet.StockDataTable();
                    StockBack = (PartsInfoDataSet.StockDataTable)partsInfoDataSet.Stock.Copy();

                    if (this._salesSlipInputInitDataAcs.Opt_Cpm_FutabaWarehAlloc == (int)SalesSlipInputInitDataAcs.Option.ON)
                    {
                        string rowFilter = "";

                        // ���蓾�Ӑ�̏ꍇ����݌ɐ����O�ȉ��̈������Ă͕s��
                        if (_CustAnalysCode1 == 1)
                        {
                            // �݌ɐ����O�ȉ��̃f�[�^�𒊏o
                            rowFilter = String.Format("{0}<={1}", partsInfoDataSet.Stock.ShipmentPosCntColumn.ColumnName, 0);
                            PartsInfoDataSet.StockRow[] rowStock = (PartsInfoDataSet.StockRow[])partsInfoDataSet.Stock.Select(rowFilter);

                            foreach (PartsInfoDataSet.StockRow stock in rowStock)
                            {
                                for (int iRow = 0; iRow < partsInfoDataSet.Stock.Count; iRow++)
                                {
                                    if ((partsInfoDataSet.Stock[iRow].GoodsMakerCd == stock.GoodsMakerCd) &&
                                        (partsInfoDataSet.Stock[iRow].GoodsNo == stock.GoodsNo) &&
                                        (partsInfoDataSet.Stock[iRow].WarehouseCode == stock.WarehouseCode))
                                    {
                                        // �݌Ƀe�[�u������Y���f�[�^�����O
                                        partsInfoDataSet.Stock.RemoveStockRow(partsInfoDataSet.Stock[iRow]);
                                        break;
                                    }
                                }
                            }
                        }
                        // �c�Ə��̏ꍇ����{�ЁE�����_�Őݒ肳��Ă���q�ɈȊO�̈������Ă͕s��
                        if (!this._salesSlipInputInitDataAcs.CheckMainSection(this._enterpriseCode, this.SectionCode))
                        {
                            if (partsInfoDataSet.ListPriorWarehouse != null)
                            {
                                // �{�ЁE�����_�Őݒ肳��Ă��Ȃ��q�ɂ𒊏o
                                rowFilter = "";
                                foreach (string PriorWarehouse in partsInfoDataSet.ListPriorWarehouse)
                                {
                                    if (rowFilter != "") rowFilter += " AND ";
                                    rowFilter += String.Format("{0}<>'{1}'", partsInfoDataSet.Stock.WarehouseCodeColumn.ColumnName, PriorWarehouse);
                                }
                                PartsInfoDataSet.StockRow[] rowStock = (PartsInfoDataSet.StockRow[])partsInfoDataSet.Stock.Select(rowFilter);
                             
                                foreach (PartsInfoDataSet.StockRow stock in rowStock)
                                {
                                    for (int iRow = 0; iRow < partsInfoDataSet.Stock.Count; iRow++)
                                    {
                                        if ((partsInfoDataSet.Stock[iRow].GoodsMakerCd == stock.GoodsMakerCd) &&
                                            (partsInfoDataSet.Stock[iRow].GoodsNo == stock.GoodsNo) &&
                                            (partsInfoDataSet.Stock[iRow].WarehouseCode == stock.WarehouseCode))
                                        {
                                            // �݌Ƀe�[�u������Y���f�[�^�����O
                                            partsInfoDataSet.Stock.RemoveStockRow(partsInfoDataSet.Stock[iRow]);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<
                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "", "���e��ݒ�@�I��");

                    // �ԗ����␳
                    #region �ԗ����␳
                    // --- ADD 杍^ 2014/09/01 ---------->>>>>
                    this.SetCarInfoToThread(cndtn);
                    // --- ADD 杍^ 2014/09/01 ----------<<<<<
                    #endregion

                    SalesSlipInputInitDataAcs.LogWrite("UIDisplayControl", "ProcessPartsSearch", "�����i�I�𐧌�N���@�J�n");
                    #region �����i�I�𐧌�N��
                    //-----------------------------------------------------------------------------
                    // ���i�I�𐧌�N��
                    //-----------------------------------------------------------------------------
                    partsInfoDataSet.TBOInitializeFlg = 0;
                    DialogResult retDialog = UIDisplayControl.ProcessPartsSearch(this._owner, cndtn.SearchCarInfo, partsInfoDataSet);
                    // --- ADD K2013/09/20 T.Miyamoto ------------------------------>>>>>
                    if (this._salesSlipInputInitDataAcs.Opt_Cpm_FutabaWarehAlloc == (int)SalesSlipInputInitDataAcs.Option.ON)
                    {
                        // �݌ɏ��e�[�u����߂�
                        partsInfoDataSet.Stock.Clear();
                        PartsInfoDataSet.StockRow[] stockRows = (PartsInfoDataSet.StockRow[])StockBack.Select();
                        foreach (PartsInfoDataSet.StockRow stock in StockBack)
                        {
                            partsInfoDataSet.Stock.ImportRow(stock);
                        }
                    }
                    // --- ADD K2013/09/20 T.Miyamoto ------------------------------<<<<<

                    // 2012/06/15 ADD T.Yoshioka 90 ---------------->>>>>>>>>>>>>>>>>>>>>>>>>
                    // ���i�����̌��ʂ�ۊ�
                    _partsInfo = partsInfoDataSet;
                    // 2012/06/15 ADD T.Yoshioka 90 ----------------<<<<<<<<<<<<<<<<<<<<<<<<<
                    #endregion
                    SalesSlipInputInitDataAcs.LogWrite("UIDisplayControl", "ProcessPartsSearch", "�����i�I�𐧌�N���@�I��");

                    switch (retDialog)
                    {
                        case DialogResult.Abort:
                        case DialogResult.Cancel:
                            partsInfoDataSet.Clear();
                            goodsUnitDataList.Clear();
                            status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                            break;
                        case DialogResult.Ignore:
                            break;
                        case DialogResult.No:
                            break;
                        case DialogResult.None:
                            break;
                        case DialogResult.OK:
                        case DialogResult.Yes:
                            SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "GetGoodsList", "�����i�����f�[�^�Z�b�g���珤�i�A���f�[�^�I�u�W�F�N�g�擾�@�J�n");
                            #region �����i�����f�[�^�Z�b�g����I�����̏��i�A���f�[�^�I�u�W�F�N�g���擾
                            //-----------------------------------------------------------------------------
                            // ���i�����f�[�^�Z�b�g����I�����̏��i�A���f�[�^�I�u�W�F�N�g���擾
                            //-----------------------------------------------------------------------------
                            // --- UPD 2014/01/15 T.Miyamoto ------------------------------>>>>>
                            //goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(true, this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd).ToArray(typeof(GoodsUnitData)));
                            goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsListWithSrc(true, this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd).ToArray(typeof(GoodsUnitData)));
                            // --- UPD 2014/01/15 T.Miyamoto ------------------------------<<<<<
                            #endregion
                            SalesSlipInputInitDataAcs.LogWrite("partsInfoDataSet", "GetGoodsList", "�����i�����f�[�^�Z�b�g���珤�i�A���f�[�^�I�u�W�F�N�g�擾�@�I��", "���ʃf�[�^�Z�b�g�Ώی���:" + partsInfoDataSet.UsrGoodsInfo.Count.ToString(), "�Ώی���:" + goodsUnitDataList.Count.ToString());

                            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "�����i�A���f�[�^�s�����ݒ�@�J�n");
                            #region �����i�A���f�[�^�s�����ݒ�
                            //-------------------------------------------------------------------------
                            // ���i�A���f�[�^�s�����ݒ�
                            //-------------------------------------------------------------------------
                            this._salesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true, this._salesSlip.ResultsAddUpSecCd);
                            #endregion
                            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "�����i�A���f�[�^�s�����ݒ�@�I��", "��������:" + goodsUnitDataList.Count.ToString());
                            break;
                        case DialogResult.Retry:
                            break;
                    }
                    break;
                case ConstantManagement.MethodResult.ctFNC_NO_RETURN: // �Y���f�[�^����
                    break;
            }
            // ADD 2013/02/22 T.Yoshioka 2013/03/06�z�M�\�� SCM��Q��108 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // ���i�I����2�i�ȏ�I�������ꍇ���l��
            int cnt = goodsUnitDataList.Count - 1;
            for (int i = 0; i < cnt; i++)
            {
                if (this._originalBLGoodsCodeMap.ContainsKey(salesRowNo + i + 1))
                {
                    this._originalBLGoodsCodeMap[salesRowNo] = bLGoodsCode;
                }
                else
                {
                    this._originalBLGoodsCodeMap.Add(salesRowNo + i + 1, bLGoodsCode);
                }
            }
            // ADD 2013/02/22 T.Yoshioka 2013/03/06�z�M�\�� SCM��Q��108 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

            return status;
        }

        // 2012/06/15 ADD T.Yoshioka 90 ---------------->>>>>>>>>>>>>>>>>>>>>>>>> 
        /// <summary>
        /// �������擾����
        /// </summary>
        /// <param name="partsInfoDataSet"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        /// <param name="i"></param>
        /// <param name="pureGoodsMakerCd"></param>
        /// <param name="ansPureGoodsNo"></param>
        private bool GetPureInfo(PartsInfoDataSet partsInfoDataSet, int goodsMakerCd, string goodsNo, int i, out int pureGoodsMakerCd, out string ansPureGoodsNo)
        {
            bool ret = false;
            PartsInfoDataSet.UsrJoinPartsDataTable usrJoinPartsDataTable = (PartsInfoDataSet.UsrJoinPartsDataTable)partsInfoDataSet.UsrJoinParts.Copy();
            PartsInfoDataSet.UsrGoodsInfoDataTable usrGoodsInfoDataTable = (PartsInfoDataSet.UsrGoodsInfoDataTable)partsInfoDataSet.UsrGoodsInfo.Copy();
            pureGoodsMakerCd = 0;
            ansPureGoodsNo = string.Empty;

            if (usrJoinPartsDataTable == null) return ret;

            string filter = string.Format("{0}={1} AND {2}='{3}'", usrJoinPartsDataTable.JoinDestMakerCdColumn.ColumnName,
                                                                   goodsMakerCd,
                                                                   usrJoinPartsDataTable.JoinDestPartsNoColumn.ColumnName,
                                                                   goodsNo);
            PartsInfoDataSet.UsrJoinPartsRow[] usrJoinPartsRows = (PartsInfoDataSet.UsrJoinPartsRow[])usrJoinPartsDataTable.Select(filter);

            if ((usrJoinPartsRows != null) && (usrJoinPartsRows.Length >= i + 1) && (usrGoodsInfoDataTable != null))
            {
                filter = string.Format("{0}={1} AND {2}='{3}'", usrGoodsInfoDataTable.GoodsMakerCdColumn.ColumnName,
                                                                      usrJoinPartsRows[i].JoinSourceMakerCode,
                                                                      usrGoodsInfoDataTable.GoodsNoColumn.ColumnName,
                                                                      usrJoinPartsRows[i].JoinSrcPartsNoWithH);
                PartsInfoDataSet.UsrGoodsInfoRow[] usrGoodsInfoRows = (PartsInfoDataSet.UsrGoodsInfoRow[])usrGoodsInfoDataTable.Select(filter);

                if ((usrGoodsInfoRows != null) && (usrGoodsInfoRows.Length != 0))
                {
                    pureGoodsMakerCd = usrGoodsInfoRows[0].GoodsMakerCd;
                    if (usrGoodsInfoRows[0].NewGoodsNo.Trim() != string.Empty)
                    {
                        ansPureGoodsNo = usrGoodsInfoRows[0].NewGoodsNo;
                    }
                    else
                    {
                        ansPureGoodsNo = usrJoinPartsRows[0].JoinSrcPartsNoWithH;
                    }
                    ret = true;
                }
            }

            return ret;
        }
        // 2012/06/15 ADD T.Yoshioka 90 ----------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        // --- ADD 2014/01/15 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// �����艿���擾����
        /// </summary>
        /// <param name="partsInfoDataSet">���i�����f�[�^�Z�b�g</param>
        /// <param name="goodsMakerCd">���[�J�[</param>
        /// <param name="goodsNo">�i��</param>
        private PartsInfoDataSet.UsrGoodsInfoRow GetPurePriceInfo(PartsInfoDataSet partsInfoDataSet, GoodsUnitData goodsUnitData)
        {
            PartsInfoDataSet.UsrGoodsInfoRow retGoodsInfoRow = null;

            PartsInfoDataSet.UsrGoodsInfoDataTable usrGoodsInfoDataTable = (PartsInfoDataSet.UsrGoodsInfoDataTable)partsInfoDataSet.UsrGoodsInfo.Copy();

            // �I�������D�Ǖi�̌�����(����)���i��GoodsInfo���猟��
            retGoodsInfoRow = usrGoodsInfoDataTable.FindByGoodsMakerCdGoodsNo(goodsUnitData.JoinSourceMakerCode, goodsUnitData.JoinSrcPartsNoWithH);
            if (retGoodsInfoRow != null)
            {
                if (retGoodsInfoRow.NewGoodsNo.Trim() != string.Empty)
                {
                    // ����������ւ���Ă���ꍇ�͐V�i�Ԃ�GoodsInfo���Č���
                    retGoodsInfoRow = usrGoodsInfoDataTable.FindByGoodsMakerCdGoodsNo(retGoodsInfoRow.GoodsMakerCd, retGoodsInfoRow.NewGoodsNo);
                }
            }
            return retGoodsInfoRow;
        }
        // --- ADD 2014/01/15 T.Miyamoto ------------------------------<<<<<

        /// <summary>
        /// �P���Z�o�����i�f���Q�[�g�Ɏg�p�j
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        /// <param name="unitPriceCalcRetList"></param>
        private void CalculateUnitPrice(List<GoodsUnitData> goodsUnitDataList, out List<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            unitPriceCalcRetList = null;
            if ((goodsUnitDataList == null) || (goodsUnitDataList.Count == 0)) return;

            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "�����i�A���f�[�^�s�����ݒ�@�J�n");
            this._salesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, false, this._salesSlip.ResultsAddUpSecCd);
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputInitDataAcs", "SettingGoodsUnitDataListFromVariousMst", "�����i�A���f�[�^�s�����ݒ�@�I��", "��������:" + goodsUnitDataList.Count.ToString());

            //-----------------------------------------------------------------------------
            // �P�����擾
            //-----------------------------------------------------------------------------
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "CalclationUnitPrice", "���P�����擾�@�J�n");
            unitPriceCalcRetList = this.CalclationUnitPrice(goodsUnitDataList);
            SalesSlipInputInitDataAcs.LogWrite("SalesSlipInputAcs", "CalclationUnitPrice", "���P�����擾�@�I��", "�Ώۏ��i��:" + goodsUnitDataList.Count.ToString(), "�Y���P�����:" + unitPriceCalcRetList.Count);

            // ------ ADD 2021/03/16 ���O FOR PMKOBETSU-4133-------->>>>
            // �P���Z�o���i��菤�i���i���擾
            List<UnitPriceCalcRet> tempUnitPriceCalcRetList = new List<UnitPriceCalcRet>();
            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                // �����f�[�^�擾
                if (unitPriceCalcRet.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    tempUnitPriceCalcRetList.Add(unitPriceCalcRet);
                }
            }
            // �Đݒ�敪
            bool resettingDiv = false;
            // ����敪
            bool isFirst = false;
            bool isUnitData = false;
            string logMsg = string.Empty;
            // ���O�o��
            if (LogCommon == null)
            {
                LogCommon = new OutLogCommon();
            }
            // ���P�����Ď擾����
            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                isUnitData = false;
                foreach (UnitPriceCalcRet unitPriceCalcRet in tempUnitPriceCalcRetList)
                {
                    // ���i���Ď擾
                    if (unitPriceCalcRet.GoodsMakerCd == goodsUnitData.GoodsMakerCd &&
                        unitPriceCalcRet.GoodsNo == goodsUnitData.GoodsNo)
                    {
                        isUnitData = true;
                        // ���P����0�~�̏ꍇ�A���P�����Ď擾����
                        if (unitPriceCalcRet.UnitPriceTaxExcFl == CtZero &&       // ���P����0�~
                            goodsUnitData.GoodsMakerCd != CtZero &&               // ���[�J�[�R�[�h
                           (string.IsNullOrEmpty(goodsUnitData.MakerName) ||      // ���[�J�[��
                            string.IsNullOrEmpty(goodsUnitData.MakerKanaName)))   // ���[�J�[�J�i��
                        {
                            // ���O���e
                            logMsg = string.Format(LogMessage, MethodNameUnit, LogInfo(goodsUnitData));
                            // ���O�o��
                            LogCommon.OutputClientLogWithSettingSleep(PGID_XML, logMsg, this._enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, CtSleepMode);

                            // ����ɂa�k�R�[�h�֘A�}�X�^�擾����
                            if (!isFirst)
                            {
                                this._salesSlipInputInitDataAcs.SearchBLGoodsInfo(this._enterpriseCode);
                                isFirst = true;
                            }
                            // �Đݒ肷��
                            resettingDiv = true;
                            break;
                        }
                    }
                }
                // ���P�����擾���Ȃ��̏ꍇ�A���P�����Ď擾����
                if (!isUnitData)
                {
                    if (goodsUnitData.GoodsMakerCd != CtZero &&              // ���[�J�[�R�[�h
                        (string.IsNullOrEmpty(goodsUnitData.MakerName) ||    // ���[�J�[��
                        string.IsNullOrEmpty(goodsUnitData.MakerKanaName)))  // ���[�J�[�J�i��
                    {
                        // ���O���e
                        logMsg = string.Format(LogMessage, MethodNameUnit, LogInfo(goodsUnitData));
                        // ���O�o��
                        LogCommon.OutputClientLogWithSettingSleep(PGID_XML, logMsg, this._enterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode, CtSleepMode);

                        // ����ɂa�k�R�[�h�֘A�}�X�^�擾����
                        if (!isFirst)
                        {
                            this._salesSlipInputInitDataAcs.SearchBLGoodsInfo(this._enterpriseCode);
                            isFirst = true;
                        }
                        // �Đݒ肷��
                        resettingDiv = true;
                    }
                }
            }

            // �Đݒ�̏ꍇ�A���P�����Đݒ�
            if (resettingDiv)
            {
                // ���i�A���f�[�^�s�����ݒ�
                this._salesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, false, this._salesSlip.ResultsAddUpSecCd);
                
                // �P�����擾
                unitPriceCalcRetList = this.CalclationUnitPrice(goodsUnitDataList);
            }
            // ------ ADD 2021/03/16 ���O FOR PMKOBETSU-4133--------<<<<
        }

        // ------ ADD 2021/03/16 ���O FOR PMKOBETSU-4133-------->>>>>
        /// <summary>
        /// ���O���e��ݒ肵�܂��B
        /// </summary>
        /// <param name="goodsUnitData">���i���</param>
        /// <remarks>
        /// <br>Note       : ���O���e��ݒ肵�܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2021/03/16</br>
        /// </remarks>
        public string LogInfo(GoodsUnitData�@goodsUnitData)
        {
            StringBuilder logMsg = new StringBuilder();
            // ���i���擾�̏ꍇ�A���O���e���쐬
            if (goodsUnitData != null && this._salesSlip != null)
            {
                // ���[�J�[�R�[�h
                logMsg.Append(string.Format(CtMakeCode, goodsUnitData.GoodsMakerCd));
                // �i��
                logMsg.Append(string.Format(CtGoodsNo, goodsUnitData.GoodsNo));
                // �i��
                logMsg.Append(string.Format(CtGoodsName, goodsUnitData.GoodsName));
                // BL���i�R�[�h
                logMsg.Append(string.Format(CtBLGoodsCode, goodsUnitData.BLGoodsCode));
                // ���i�啪�ރR�[�h
                logMsg.Append(string.Format(CtGoodsLGroup, goodsUnitData.GoodsLGroup));
                // ���i�����ރR�[�h
                logMsg.Append(string.Format(CtGoodsMGroup, goodsUnitData.GoodsMGroup));
                // BL�O���[�v�R�[�h
                logMsg.Append(string.Format(CtBLGroupCode, goodsUnitData.BLGroupCode));
                // ���i�|�������N(�w��)
                logMsg.Append(string.Format(CtGoodsRateRank, goodsUnitData.GoodsRateRank));
                // ���Е��ރR�[�h
                logMsg.Append(string.Format(CtEnterpriseGanreCode, goodsUnitData.EnterpriseGanreCode));
                // ���i�|���O���[�v�R�[�h
                logMsg.Append(string.Format(CtGoodsRateGrpCd, goodsUnitData.GoodsRateGrpCode));
                // �d����R�[�h
                logMsg.Append(string.Format(CtSupplierCd, goodsUnitData.SupplierCd));
                // ���_
                logMsg.Append(string.Format(CtSectionCode, _salesSlip.SectionCode));
                // ���Ӑ�R�[�h
                logMsg.Append(string.Format(CtCustomerCode, _salesSlip.CustomerCode));
                // �S���҃R�[�h
                logMsg.Append(string.Format(CtEmployeeCode, _salesSlip.InputAgenCd));
                // �����
                logMsg.Append(string.Format(CtSalesDate, _salesSlip.SalesDate.ToString("yyyy/MM/dd")));
            }
            return logMsg.ToString();
        }
        // ------ ADD 2021/03/16 ���O FOR PMKOBETSU-4133--------<<<<

        /// <summary>
        /// ���i�v�Z�����i�f���Q�[�g�Ɏg�p�j
        /// </summary>
        /// <param name="taxationCode"></param>
        /// <param name="unitPrice"></param>
        /// <param name="priceTaxExc"></param>
        /// <param name="priceTaxInc"></param>
        private void CalcPrice(int taxationCode, double unitPrice, out double priceTaxExc, out double priceTaxInc)
        {
            // ����Œ[�������R�[�h
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            this.CalclatePrice(unitPrice, taxationCode, this._salesSlip.TotalAmountDispWayCd, this._salesSlip.ConsTaxLayMethod, this._salesSlip.ConsTaxRate, salesCnsTaxFrcProcCd, out priceTaxExc, out priceTaxInc);
        }

        /// <summary>
        /// ���������������i�f���Q�[�g�Ɏg�p�j
        /// </summary>
        /// <param name="mode">���[�h</param>
        /// <param name="goodsCndt"></param>
        /// <param name="partsInfoDataSe"></param>
        /// <param name="goodsUnitDataLis"></param>
        /// <param name="msg"></param>
        /// <br>Note       : �����������������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/10/19</br>
        private void SearchPartsForSrcPartsPrc(int mode, GoodsCndtn goodsCndt, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out string msg)
        {
            //-----------------------------------------------------------------------------
            // ������
            //-----------------------------------------------------------------------------
            partsInfoDataSet = new PartsInfoDataSet();
            goodsUnitDataList = new List<GoodsUnitData>();
            msg = string.Empty;

            //-----------------------------------------------------------------------------
            if (goodsCndt == null) return;
            // ����������
            //-----------------------------------------------------------------------------
            int status = this._salesSlipInputInitDataAcs.SearchPartsForSrcParts(mode, goodsCndt, out partsInfoDataSet, out goodsUnitDataList, out msg);
            // ADD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� --------------------->>>>>
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this.GetOfrPriceDataList(partsInfoDataSet, goodsUnitDataList);
            }
            // ADD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� ---------------------<<<<<

            if (partsInfoDataSet.CalculatePrice == null)
            {
                partsInfoDataSet.CalculatePrice += new PartsInfoDataSet.CalculatePriceCallback(this.CalcPrice);
            }

            partsInfoDataSet.PriceApplyDate = this._salesSlip.SalesDate;

            // ADD 2010/05/17 �i���\���Ή� ---------->>>>>
            if (partsInfoDataSet.GetBLGoodsInfo == null)
            {
                partsInfoDataSet.SetPartsNameDisplayPattern(this._salesSlipInputInitDataAcs.GetSalesTtlSt());

                // BL���i���
                if (partsInfoDataSet.GetBLGoodsInfo == null)
                {
                    partsInfoDataSet.GetBLGoodsInfo += new PartsInfoDataSet.GetBLGoodsInfoCallBack(this.GetBLGoodsInfo);
                }
            }
            // ADD 2010/05/17 �i���\���Ή� ----------<<<<<

        }

        /// <summary>
        /// ���Ӑ�|����ٰ�ߌ��������i�f���Q�[�g�Ɏg�p�j
        /// </summary>
        /// <param name="custRateGrpCodeList">���Ӑ�}�X�^(�|���O���[�v)���X�g</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <br>Note       : ���Ӑ�|����ٰ�ߏ����������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/10/19</br>
        private void GetCustRateGrpCode(ArrayList custRateGrpCodeList, int customerCode, int goodsMakerCode, out int custRateGrpCode)
        {
            custRateGrpCode = 0;
            if (custRateGrpCodeList == null) return;

            //-----------------------------------------------------------------------------
            // ���Ӑ�|����ٰ�ߌ���
            //-----------------------------------------------------------------------------
            this._custRateGroupAcs.GetCustRateGrp(custRateGrpCodeList, customerCode, goodsMakerCode, out custRateGrpCode);

        }

        /// <summary>
        /// �\���敪�擾���������i�f���Q�[�g�Ɏg�p�j
        /// </summary>
        /// <param name="custRateGrpCodeList">���Ӑ�}�X�^(�|���O���[�v)���X�g</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <param name="custRateGrpCode">���Ӑ�|���O���[�v�R�[�h</param>
        /// <br>Note       : ���Ӑ�|����ٰ�ߏ����������܂��B</br>
        /// <br>Programmer : ���M</br>
        /// <br>Date       : 2009/10/19</br>
        private void GetDisplayDiv(List<PriceSelectSet> displayDivList, Int32 goodsMakerCode, Int32 blGoodsCode, Int32 customerCode, Int32 custRateGrpCode, out Int32 priceSelectDiv)
        {
            priceSelectDiv = -1;
            if (displayDivList == null) return;

            //-----------------------------------------------------------------------------
            // �\���敪����
            //-----------------------------------------------------------------------------
            this._priceSelectSetAcs.GetDisplayDiv(displayDivList, goodsMakerCode, blGoodsCode, customerCode, custRateGrpCode, out priceSelectDiv);
        }

        /// <summary>
        /// �Ώۉ��i����A�Ŕ����z�A�ō����z�A�\�����z���v�Z���܂�
        /// </summary>
        /// <param name="targetPrice">�Ώۉ��i</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="totalAmountDispWayCd">���z�\���敪</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���</param>
        /// <param name="taxRate">�ŗ�</param>
        /// <param name="salesCnsTaxFrcProcCd">�������Œ[�������R�[�h</param>
        /// <param name="priceTaxExc">�Ŕ����z</param>
        /// <param name="priceTaxInc">�ō����z</param>
        private void CalclatePrice(double targetPrice, int taxationCode, int totalAmountDispWayCd, int consTaxLayMethod, double taxRate, int salesCnsTaxFrcProcCd, out  double priceTaxExc, out  double priceTaxInc)
        {
            priceTaxExc = 0;
            priceTaxInc = 0;

            if (targetPrice == 0) return;

            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo((int)SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            // ���z�\�����Ȃ�
            if (totalAmountDispWayCd == 0)
            {
                // �ېŋ敪�u��ېŁv�A�]�ŕ����F��ې�
                if ((taxationCode == (int)CalculateTax.TaxationCode.TaxNone) || (consTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt))
                {
                    priceTaxExc = targetPrice;
                    priceTaxInc = targetPrice;
                }
                // �ېŋ敪���u�ېŁi���Łj�v�̏ꍇ
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                {
                    priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                    priceTaxInc = targetPrice;
                }
                // �ېŋ敪���u�ېŁv�̏ꍇ
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    priceTaxExc = targetPrice;
                    priceTaxInc = targetPrice + CalculateTax.GetTaxFromPriceExc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                }
            }
            // ���z�\������
            else
            {
                // �ېŋ敪�u��ېŁv�A�]�ŕ����F��ې�
                if ((taxationCode == (int)CalculateTax.TaxationCode.TaxNone) || (consTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt))
                {
                    priceTaxExc = targetPrice;
                    priceTaxInc = targetPrice;
                }
                // �ېŋ敪���u�ېŁi���Łj�v�̏ꍇ
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
                {
                    priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                    priceTaxInc = targetPrice;
                }
                // �ېŋ敪���u�ېŁv�̏ꍇ
                else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    priceTaxExc = targetPrice - CalculateTax.GetTaxFromPriceInc(taxRate, taxFracProcUnit, taxFracProcCd, targetPrice);
                    priceTaxInc = targetPrice;
                }
            }
        }

        /// <summary>
        /// TBO����
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <returns>ConstantManagement.MethodResult</returns>
        public int SearchTBO(int salesRowNo, string enterpriseCode, string sectionCode, out List<GoodsUnitData> goodsUnitDataList)
        {
            //-----------------------------------------------------------------------------
            // ������
            //-----------------------------------------------------------------------------
            string msg;
            PartsInfoDataSet partsInfoDataSet;
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            goodsUnitDataList = new List<GoodsUnitData>();

            //-----------------------------------------------------------------------------
            // ���o�����ݒ�
            //-----------------------------------------------------------------------------
            GoodsCndtn cndtn = new GoodsCndtn();
            cndtn.EnterpriseCode = enterpriseCode;
            cndtn.SectionCode = sectionCode;
            cndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
            cndtn.SubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstCondDivCd;
            cndtn.PrmSubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PrmSubstCondDivCd;
            cndtn.SubstApplyDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstApplyDivCd;
            cndtn.SearchUICntDivCd = this._salesSlipInputConstructionAcs.SearchUICntDivCdValue;
            cndtn.EnterProcDivCd = this._salesSlipInputConstructionAcs.EnterProcDivCdValue;
            cndtn.PartsNoSearchDivCd = this._salesSlipInputConstructionAcs.PartsNoSearchDivCdValue;
            cndtn.PartsJoinCntDivCd = this._salesSlipInputConstructionAcs.PartsJoinCntDivCdValue;
            cndtn.EraNameDispCd1 = this._salesSlipInputInitDataAcs.GetAllDefSet().EraNameDispCd1;
            cndtn.PartsSearchPriDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsSearchPriDivCd;
            cndtn.JoinInitDispDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().JoinInitDispDiv;
            // �D��q�Ƀ��X�g�쐬(���Ӑ�D��q�Ɂ{���_�D��q��)
            List<string> warehouseList = new List<string>();
            //warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.SectWarehouseCd, this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 DEL
            warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.GetSectWarehouseCd(this._salesSlip.ResultsAddUpSecCd), this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 ADD
            cndtn.ListPriorWarehouse = warehouseList;

            cndtn.CustomerCode = this._salesSlip.CustomerCode;
            cndtn.PriceApplyDate = this._salesSlip.SalesDate; // �K�p��
            cndtn.SalesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
            cndtn.TaxRate = this._salesSlip.ConsTaxRate;
            cndtn.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd;
            cndtn.TtlAmntDspRateDivCd = this._salesSlipInputInitDataAcs.GetAllDefSet().TtlAmntDspRateDivCd;
            cndtn.SalesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            cndtn.IsSettingSupplier = 1;

            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (row != null)
            {
                cndtn.CustRateGrpCode = row.CustRateGrpCode;
                if (row.CarRelationGuid != Guid.Empty)
                {
                    cndtn.SearchCarInfo = this.GetCarInfoFromDic(row.CarRelationGuid);
                }
                else
                {
                    cndtn.SearchCarInfo = this.GetCarInfoFromDic(this._beforeCarRelationGuid);
                }
            }

            //-----------------------------------------------------------------------------
            // �ԗ���񑶍݃`�F�b�N
            //-----------------------------------------------------------------------------
            if (cndtn.SearchCarInfo == null) return -3;

            //-----------------------------------------------------------------------------
            // TBO����
            //-----------------------------------------------------------------------------
            int status = this._salesSlipInputInitDataAcs.SearchTBO(cndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);
            // ADD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� --------------------->>>>>
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                this.GetOfrPriceDataList(partsInfoDataSet, goodsUnitDataList);
            }
            // ADD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� ---------------------<<<<<

            switch ((ConstantManagement.MethodResult)status)
            {
                case ConstantManagement.MethodResult.ctFNC_CANCEL: // �I�𖳂�
                    break;
                case ConstantManagement.MethodResult.ctFNC_NORMAL: // �ʏ폈��
                    // ADD 2010/05/17 �i���\���Ή� ---------->>>>>
                    partsInfoDataSet.SetPartsNameDisplayPattern(this._salesSlipInputInitDataAcs.GetSalesTtlSt());

                    // BL���i���
                    if (partsInfoDataSet.GetBLGoodsInfo == null)
                    {
                        partsInfoDataSet.GetBLGoodsInfo += new PartsInfoDataSet.GetBLGoodsInfoCallBack(this.GetBLGoodsInfo);
                    }
                    // ADD 2010/05/17 �i���\���Ή� ----------<<<<<

                    //-----------------------------------------------------------------------------
                    // ���i�����f�[�^�Z�b�g����I�����̏��i�A���f�[�^�I�u�W�F�N�g���擾
                    //-----------------------------------------------------------------------------
                    goodsUnitDataList = new List<GoodsUnitData>((GoodsUnitData[])partsInfoDataSet.GetGoodsList(true, this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsNameDspDivCd).ToArray(typeof(GoodsUnitData)));

                    //-----------------------------------------------------------------------------
                    // ���i�A���f�[�^�s�����ݒ�
                    //-----------------------------------------------------------------------------
                    this._salesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst(ref goodsUnitDataList, true, this._salesSlip.ResultsAddUpSecCd);

                    break;
                case ConstantManagement.MethodResult.ctFNC_NO_RETURN: // �Y���f�[�^����
                    break;
            }
            return status;
        }

        /// <summary>
        /// �i�Ԍ���(���i���ꊇ�擾)
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesDetailList">���㖾�׃f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="goodsUnitDataListList">���i�A���f�[�^���X�g���X�g</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns></returns>
        public int SearchPartsFromGoodsNoNonVariousSearchWholeWord(SalesSlip salesSlip, List<SalesDetail> salesDetailList, out List<List<GoodsUnitData>> goodsUnitDataListList, out String msg)
        {
            //-----------------------------------------------------------------------------
            // ��������
            //-----------------------------------------------------------------------------
            goodsUnitDataListList = new List<List<GoodsUnitData>>();
            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();
            msg = string.Empty;

            //-----------------------------------------------------------------------------
            // ���i���������I�u�W�F�N�g���X�g�擾
            //-----------------------------------------------------------------------------
            this.GetGoodsCndtnList(salesSlip, salesDetailList, out goodsCndtnList);

            //-----------------------------------------------------------------------------
            // �i�Ԍ���(���i���ꊇ�擾)
            //-----------------------------------------------------------------------------
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            if ((goodsCndtnList != null) && (goodsCndtnList.Count != 0))
            {
                // UPD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� --------------------->>>>>
                //status = this._salesSlipInputInitDataAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out msg);
                PartsInfoDataSet partsInfoDataSet = null;
                status = this._salesSlipInputInitDataAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out partsInfoDataSet, out msg);
                // UPD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� ---------------------<<<<<

                switch ((ConstantManagement.MethodResult)status)
                {
                    case ConstantManagement.MethodResult.ctFNC_NORMAL: // �ʏ폈��
                        //-----------------------------------------------------------------------------
                        // ���i���L���b�V��
                        //-----------------------------------------------------------------------------
                        this.CacheGoodsUnitDataDic(goodsUnitDataListList);
                        // ADD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� --------------------->>>>>
                        this.GetOfrPriceDataList(partsInfoDataSet, goodsUnitDataListList);
                        // ADD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� ---------------------<<<<<
                        break;
                    default:
                        break;
                }
            }
            return status;
        }

        /// <summary>
        /// �i�Ԍ���(���i���ꊇ�擾)
        /// </summary>
        /// <param name="goodsUnitDataListList">���i�A���f�[�^���X�g���X�g</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <returns></returns>
        public int SearchPartsFromGoodsNoNonVariousSearchWholeWord(out List<List<GoodsUnitData>> goodsUnitDataListList, out String msg)
        {
            return this.SearchPartsFromGoodsNoNonVariousSearchWholeWord(this._salesSlip, this._salesDetailDataTable, out goodsUnitDataListList, out msg);
        }

        /// <summary>
        /// �i�Ԍ���(���i���ꊇ�擾)
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u��</param>
        /// <param name="goodsUnitDataListList">���i�A���f�[�^���X�g���X�g</param>
        /// <param name="msg">�G���[���b�Z�[�W</param>
        /// <br>Update Note: 2010/06/02 ���� PM.NS��Q�E���ǑΉ��i�V�������[�X�Č��jNo.2</br>
        /// <br>Update Note: 2012/04/09 yangmj Redmine#29313 ����`�[���� ���i���i�̍Ď擾�Ŕ̔��敪�������l�ɖ߂�</br>
        /// <returns></returns>
        public int SearchPartsFromGoodsNoNonVariousSearchWholeWord(SalesSlip salesSlip, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, out List<List<GoodsUnitData>> goodsUnitDataListList, out String msg)
        {
            //-----------------------------------------------------------------------------
            // ��������
            //-----------------------------------------------------------------------------
            goodsUnitDataListList = new List<List<GoodsUnitData>>();
            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();
            msg = string.Empty;

            //-----------------------------------------------------------------------------
            // ���i���������I�u�W�F�N�g���X�g�擾
            //-----------------------------------------------------------------------------
            this.GetGoodsCndtnList(salesSlip, salesDetailDataTable, out goodsCndtnList);

            //-----------------------------------------------------------------------------
            // �i�Ԍ���(���i���ꊇ�擾)
            //-----------------------------------------------------------------------------
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            if ((goodsCndtnList != null) && (goodsCndtnList.Count != 0))
            {
                // UPD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� --------------------->>>>>
                //status = this._salesSlipInputInitDataAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out msg);
                PartsInfoDataSet partsInfoDataSet = null;
                status = this._salesSlipInputInitDataAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out partsInfoDataSet, out msg);
                // UPD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� ---------------------<<<<<

                switch ((ConstantManagement.MethodResult)status)
                {
                    case ConstantManagement.MethodResult.ctFNC_NORMAL: // �ʏ폈��
                        //-----------------------------------------------------------------------------
                        // ���i���L���b�V��
                        //-----------------------------------------------------------------------------
                        this.CacheGoodsUnitDataDic(goodsUnitDataListList);
                        // ADD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� --------------------->>>>>
                        this.GetOfrPriceDataList(partsInfoDataSet, goodsUnitDataListList);
                        // ADD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� ---------------------<<<<<

                        //-----------------------------------------------------------------------------
                        // ���׏��X�V
                        //-----------------------------------------------------------------------------
                        foreach (SalesInputDataSet.SalesDetailRow row in salesDetailDataTable)
                        {
                            if ((row.GoodsMakerCd == 0) || (string.IsNullOrEmpty(row.GoodsNo))) continue;
                            //>>>2010/10/01
                            //GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo);
                            GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo, row);
                            //<<<2010/10/01
                            // --- ADD 2010/06/02 ---------->>>>>
                            goodsUnitData.GoodsName = row.GoodsName;
                            goodsUnitData.GoodsNameKana = row.GoodsName;
                            // --- ADD 2010/06/02 ----------<<<<<
                            //Stock stock = (goodsUnitData.SelectedWarehouseCode != null) ? this.GetStock(goodsUnitData, goodsUnitData.SelectedWarehouseCode.Trim()) : this.GetStock(goodsUnitData);
                            Stock stock = this.GetStock(goodsUnitData);
                            int targetSalesRowNo = row.SalesRowNo;
                            // ���i�A�݌ɏ��ݒ菈��
                            //this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, true, (int)SalesSlipCdDtl.Sales, SearchPartsMode.GoodsNoSearch);
                            //>>>2010/07/21
                            //this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, false, row.SalesSlipCdDtl, SearchPartsMode.GoodsNoSearch);
                            if ((goodsUnitData.OfferKubun == 0) && (goodsUnitData.FileHeaderGuid == Guid.Empty))
                            {
                                // �󏤕i
                                // --- UPD 2012/09/05 Y.Wakita ---------->>>>>
                                //this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, false, row.SalesSlipCdDtl, SearchPartsMode.GoodsNoSearch, true);
                                this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, false, row.SalesSlipCdDtl, SearchPartsMode.GoodsNoSearch, true, true);
                                // --- UPD 2012/09/05 Y.Wakita ----------<<<<<
                            }
                            else
                            {
                                // �ʏ폤�i
                                // --- UPD 2012/09/05 Y.Wakita ---------->>>>>
                                //this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, false, row.SalesSlipCdDtl, SearchPartsMode.GoodsNoSearch, false);
                                this.SalesDetailRowGoodsSetting(targetSalesRowNo, goodsUnitData, stock, false, row.SalesSlipCdDtl, SearchPartsMode.GoodsNoSearch, false, false);
                                // --- UPD 2012/09/05 Y.Wakita ----------<<<<<
                            }
                            //<<<2010/07/21

                            // �󒍏��Đݒ�
                            if (row.AcceptAnOrderCntDisplay != 0)
                            {
                                // �󒍏��ݒ�
                                this.SettingSalesDetailAcceptAnOrder(row.SalesRowNo);
                                // ���ʐݒ菈��
                                this.SettingAcptAnOdrDetailRowShipmentCnt(row.SalesRowNo);
                            }
                        }
                        //--- ADD 2012/04/09 yangmj redmine#29313 ----->>>>>
                        if (_salesCodeChgFlag)
                        {
                            _salesCodeChgFlag = false;
                        }
                        //--- ADD 2012/04/09 yangmj redmine#29313 -----<<<<<
                        break;
                    default:
                        break;
                }
            }
            return status;
        }

        /// <summary>
        /// �i�Ԍ���(���i���ꊇ�擾)
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="goodsMakerCdList">���[�J�[�R�[�h���X�g</param>
        /// <param name="goodsNoList">�i�ԃ��X�g</param>
        /// <param name="goodsUnitDataListList">���i�A���f�[�^���X�g���X�g</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <returns></returns>
        public int SearchPartsFromGoodsNoNonVariousSearchWholeWord(SalesSlip salesSlip, List<int> goodsMakerCdList, List<string> goodsNoList, out List<List<GoodsUnitData>> goodsUnitDataListList, out String msg)
        {
            //-----------------------------------------------------------------------------
            // ��������
            //-----------------------------------------------------------------------------
            goodsUnitDataListList = new List<List<GoodsUnitData>>();
            List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();
            msg = string.Empty;

            //-----------------------------------------------------------------------------
            // ���i���������I�u�W�F�N�g���X�g�擾
            //-----------------------------------------------------------------------------
            this.GetGoodsCndtnList(salesSlip, goodsMakerCdList, goodsNoList, out goodsCndtnList);

            //-----------------------------------------------------------------------------
            // �i�Ԍ���(���i���ꊇ�擾)
            //-----------------------------------------------------------------------------
            int status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            if ((goodsCndtnList != null) && (goodsCndtnList.Count != 0))
            {
                // UPD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� --------------------->>>>>
                //status = this._salesSlipInputInitDataAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out msg);
                PartsInfoDataSet partsInfoDataSet = null;
                status = this._salesSlipInputInitDataAcs.SearchPartsFromGoodsNoNonVariousSearchWholeWord(goodsCndtnList, out goodsUnitDataListList, out partsInfoDataSet, out msg);
                // UPD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� ---------------------<<<<<

                switch ((ConstantManagement.MethodResult)status)
                {
                    case ConstantManagement.MethodResult.ctFNC_NORMAL: // �ʏ폈��
                        //-----------------------------------------------------------------------------
                        // ���i���L���b�V��
                        //-----------------------------------------------------------------------------
                        this.CacheGoodsUnitDataDic(goodsUnitDataListList);
                        // ADD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� --------------------->>>>>
                        this.GetOfrPriceDataList(partsInfoDataSet, goodsUnitDataListList);
                        // ADD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� ---------------------<<<<<
                        break;
                    default:
                        break;
                }
            }
            return status;
        }

        /// <summary>
        /// ���i���������I�u�W�F�N�g���X�g�擾����
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesDetailList">���㖾�׃f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="goodsCndtnList">���i���������I�u�W�F�N�g���X�g</param>
        private void GetGoodsCndtnList(SalesSlip salesSlip, List<SalesDetail> salesDetailList, out List<GoodsCndtn> goodsCndtnList)
        {
            goodsCndtnList = new List<GoodsCndtn>();
            List<GoodsCndtn> retGoodsCndtnList = new List<GoodsCndtn>();

            foreach (SalesDetail salesDetail in salesDetailList)
            {
                if ((salesDetail.GoodsMakerCd == 0) || (string.IsNullOrEmpty(salesDetail.GoodsNo))) continue;

                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.SectionCode = salesSlip.ResultsAddUpSecCd;
                goodsCndtn.GoodsMakerCd = salesDetail.GoodsMakerCd;
                goodsCndtn.GoodsNo = salesDetail.GoodsNo;
                goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
                goodsCndtn.SubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstCondDivCd;
                goodsCndtn.PrmSubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PrmSubstCondDivCd;
                goodsCndtn.SubstApplyDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstApplyDivCd;
                goodsCndtn.SearchUICntDivCd = this._salesSlipInputConstructionAcs.SearchUICntDivCdValue;
                goodsCndtn.EnterProcDivCd = this._salesSlipInputConstructionAcs.EnterProcDivCdValue;
                goodsCndtn.EraNameDispCd1 = this._salesSlipInputInitDataAcs.GetAllDefSet().EraNameDispCd1;
                goodsCndtn.PartsSearchPriDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsSearchPriDivCd;
                goodsCndtn.JoinInitDispDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().JoinInitDispDiv;
                // �D��q�Ƀ��X�g�쐬(���Ӑ�D��q�Ɂ{���_�D��q��)
                List<string> warehouseList = new List<string>();
                //warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.SectWarehouseCd, this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 DEL
                warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.GetSectWarehouseCd(this._salesSlip.ResultsAddUpSecCd), this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 ADD
                goodsCndtn.ListPriorWarehouse = warehouseList;

                retGoodsCndtnList.Add(goodsCndtn);                
            }

            goodsCndtnList = retGoodsCndtnList;
        }

        /// <summary>
        /// ���i���������I�u�W�F�N�g���X�g�擾����
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u��</param>
        /// <param name="goodsCndtnList">���i���������I�u�W�F�N�g���X�g</param>
        private void GetGoodsCndtnList(SalesSlip salesSlip, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, out List<GoodsCndtn> goodsCndtnList)
        {
            goodsCndtnList = new List<GoodsCndtn>();
            List<GoodsCndtn> retGoodsCndtnList = new List<GoodsCndtn>();

            foreach (SalesInputDataSet.SalesDetailRow row in salesDetailDataTable)
            {
                if ((row.GoodsMakerCd == 0) || (string.IsNullOrEmpty(row.GoodsNo))) continue;

                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.SectionCode = salesSlip.ResultsAddUpSecCd;
                goodsCndtn.GoodsMakerCd = row.GoodsMakerCd;
                goodsCndtn.GoodsNo = row.GoodsNo;
                goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
                goodsCndtn.SubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstCondDivCd;
                goodsCndtn.PrmSubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PrmSubstCondDivCd;
                goodsCndtn.SubstApplyDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstApplyDivCd;
                goodsCndtn.SearchUICntDivCd = this._salesSlipInputConstructionAcs.SearchUICntDivCdValue;
                goodsCndtn.EnterProcDivCd = this._salesSlipInputConstructionAcs.EnterProcDivCdValue;
                goodsCndtn.EraNameDispCd1 = this._salesSlipInputInitDataAcs.GetAllDefSet().EraNameDispCd1;
                goodsCndtn.PartsSearchPriDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsSearchPriDivCd;
                goodsCndtn.JoinInitDispDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().JoinInitDispDiv;
                // �D��q�Ƀ��X�g�쐬(���Ӑ�D��q�Ɂ{���_�D��q��)
                List<string> warehouseList = new List<string>();
                //warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.SectWarehouseCd, this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 DEL
                warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.GetSectWarehouseCd(this._salesSlip.ResultsAddUpSecCd), this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 ADD
                goodsCndtn.ListPriorWarehouse = warehouseList;

                retGoodsCndtnList.Add(goodsCndtn);
            }

            goodsCndtnList = retGoodsCndtnList;
        }

        /// <summary>
        /// ���i���������I�u�W�F�N�g���X�g�擾����
        /// </summary>
        /// <param name="salesSlip"></param>
        /// <param name="goodsMakerCodeList"></param>
        /// <param name="goodsNoList"></param>
        /// <param name="goodsCndtnList"></param>
        private void GetGoodsCndtnList(SalesSlip salesSlip, List<int> goodsMakerCdList, List<string> goodsNoList, out List<GoodsCndtn> goodsCndtnList)
        {
            goodsCndtnList = new List<GoodsCndtn>();
            List<GoodsCndtn> retGoodsCndtnList = new List<GoodsCndtn>();

            for (int index = 0; index < goodsNoList.Count; index++)
            {
                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = this._enterpriseCode;
                goodsCndtn.SectionCode = salesSlip.ResultsAddUpSecCd;
                goodsCndtn.GoodsMakerCd = goodsMakerCdList[index];
                goodsCndtn.GoodsNo = goodsNoList[index];
                goodsCndtn.JoinSearchDiv = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
                goodsCndtn.SubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstCondDivCd;
                goodsCndtn.PrmSubstCondDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PrmSubstCondDivCd;
                goodsCndtn.SubstApplyDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().SubstApplyDivCd;
                goodsCndtn.SearchUICntDivCd = this._salesSlipInputConstructionAcs.SearchUICntDivCdValue;
                goodsCndtn.EnterProcDivCd = this._salesSlipInputConstructionAcs.EnterProcDivCdValue;
                goodsCndtn.EraNameDispCd1 = this._salesSlipInputInitDataAcs.GetAllDefSet().EraNameDispCd1;
                goodsCndtn.PartsSearchPriDivCd = this._salesSlipInputInitDataAcs.GetSalesTtlSt().PartsSearchPriDivCd;
                goodsCndtn.JoinInitDispDiv = this._salesSlipInputInitDataAcs.GetSalesTtlSt().JoinInitDispDiv;
                // �D��q�Ƀ��X�g�쐬(���Ӑ�D��q�Ɂ{���_�D��q��)
                List<string> warehouseList = new List<string>();
                //warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.SectWarehouseCd, this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 DEL
                warehouseList = this.AddWarehouseList(this._salesSlipInputInitDataAcs.GetSectWarehouseCd(this._salesSlip.ResultsAddUpSecCd), this._salesSlip.CustWarehouseCd, 0); // 2009/09/08 ADD
                goodsCndtn.ListPriorWarehouse = warehouseList;

                retGoodsCndtnList.Add(goodsCndtn);
            }
            goodsCndtnList = retGoodsCndtnList;
        }

        /// <summary>
        /// ���i�A�����X�g���X�g���珤�i�A�����X�g���擾
        /// </summary>
        /// <param name="goodsUnitDataListList"></param>
        /// <param name="goodsUnitDataList"></param>
        private void GetGoodsUnitDataListFromListList(List<List<GoodsUnitData>> goodsUnitDataListList, out List<GoodsUnitData> goodsUnitDataList)
        {
            goodsUnitDataList = new List<GoodsUnitData>();
            if (goodsUnitDataListList == null) return;
            foreach (List<GoodsUnitData> tempGoodsUnitDataList in goodsUnitDataListList)
            {
                goodsUnitDataList.Add(tempGoodsUnitDataList[0]);
            }
        }

        // ADD 2010/05/17 �i���\���Ή� ---------->>>>>
        /// <summary>
        /// BL���i�����擾���܂��B
        /// </summary>
        /// <param name="blGoodsCode">BL�R�[�h</param>
        /// <returns>BL���i���</returns>
        private BLGoodsCdUMnt GetBLGoodsInfo(int blGoodsCode)
        {
            return this._salesSlipInputInitDataAcs.GetBLGoodsInfo_FromBLGoods(blGoodsCode);
        }
        // ADD 2010/05/17 �i���\���Ή� ----------<<<<<
        #endregion

        public void SalesDetailRowSalesUnitPriceSetting(int salesRowNo)
        {
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
        }



        #region ���P�������z
        /// <summary>
        /// �w�肵�����P���̒l�����ɔ��㖾�׍s�I�u�W�F�N�g�̒P������ݒ肵�܂�
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="salesUnitPriceInputType">����P�����̓��[�h</param>
        /// <param name="salesUnitPrice">���P��</param>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">�󒍖��׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        /// <param name="inputPositionMode">���͈ʒu���[�h</param>
        public void SalesDetailRowSalesUnitPriceSetting(int salesRowNo, SalesUnitPriceInputType salesUnitPriceInputType, double salesUnitPrice, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable, int inputPositionMode)
        {
            #region ����������
            SalesInputDataSet.SalesDetailRow row = salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);

            // ����Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            // �ύX�O���ێ�
            double svUnitPriceTaxInc = row.SalesUnPrcTaxIncFl;
            double svUnitPriceTaxExc = row.SalesUnPrcTaxExcFl;
            #endregion


            #region ��������
            if (row != null)
            {
                // ��ې�
                int taxationDivCd = row.TaxationDivCd;
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt) taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;

                switch (salesUnitPriceInputType)
                {
                    // ���P��(�Ŕ���)--->>>���������͂��瑍�z�\�����Ȃ����̂݃R�[��
                    case SalesUnitPriceInputType.SalesUnitPrice:
                        {
                            switch ((CalculateTax.TaxationCode)taxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    row.SalesUnPrcDisplay = salesUnitPrice;
                                    row.SalesUnPrcTaxExcFl = salesUnitPrice;
                                    row.SalesUnPrcTaxIncFl = salesUnitPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    row.SalesUnPrcDisplay = salesUnitPrice;
                                    row.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                    row.SalesUnPrcTaxIncFl = salesUnitPrice;
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    row.SalesUnPrcDisplay = salesUnitPrice; // ���P��(�Ŕ�)�\��
                                    row.SalesUnPrcTaxExcFl = salesUnitPrice;// ���P���P��(�Ŕ�)
                                    row.SalesUnPrcTaxIncFl = salesUnitPrice;// ���P���P��(�ō�)
                                    break;
                            }
                            break;
                        }
                    // ���P��(�ō���)--->>>���������͂��瑍�z�\�����鎞�̂݃R�[��
                    case SalesUnitPriceInputType.SalesUnitTaxPrice:
                        {
                            switch ((CalculateTax.TaxationCode)taxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                case CalculateTax.TaxationCode.TaxInc:
                                    row.SalesUnPrcDisplay = salesUnitPrice;
                                    row.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                    row.SalesUnPrcTaxIncFl = salesUnitPrice;
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    row.SalesUnPrcDisplay = salesUnitPrice;
                                    row.SalesUnPrcTaxExcFl = salesUnitPrice;
                                    row.SalesUnPrcTaxIncFl = salesUnitPrice;
                                    break;
                            }
                            break;
                        }
                    // ���P��(�\���p)
                    case SalesUnitPriceInputType.SalesUnitPriceDisplay:
                        {

                            if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
                            {
                                //-----------------------------------------------------
                                // ���z�\�����Ȃ�
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)taxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnPrcTaxExcFl = salesUnitPrice;
                                        row.SalesUnPrcTaxIncFl = salesUnitPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        row.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnPrcTaxExcFl = salesUnitPrice;
                                        row.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                //-----------------------------------------------------
                                // ���z�\������
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)taxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        row.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        row.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnPrcTaxExcFl = salesUnitPrice;
                                        row.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                }
                            }

                            //----------------------------------------------------------------------------
                            // ���͂��ꂽ�P���ƕ\���P�����قȂ����ꍇ�A���������N���A
                            //----------------------------------------------------------------------------
                            // �|���Z�o����Ă���ꍇor���������ݒ肳��Ă���ꍇ
                            if (!(string.IsNullOrEmpty(row.RateDivSalUnPrc)) || (row.SalesRate != 0))
                            {
                                //if (row.SalesRate != 0)
                                //{
                                //    this.CalculateUnitPriceByRate(row, UnitPriceCalculation.UnitPriceKind.SalesUnitPrice, out svUnitPriceTaxInc, out svUnitPriceTaxExc, out svUnitPriceDisplay);
                                //}

                                if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
                                {
                                    //-----------------------------------------------------
                                    // ���z�\�����Ȃ�
                                    //-----------------------------------------------------
                                    switch ((CalculateTax.TaxationCode)taxationDivCd)
                                    {
                                        case CalculateTax.TaxationCode.TaxExc:
                                            if (svUnitPriceTaxExc != row.SalesUnPrcDisplay)
                                            {
                                                row.SalesRate = 0;
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxInc:
                                            if (svUnitPriceTaxInc != row.SalesUnPrcDisplay)
                                            {
                                                row.SalesRate = 0;
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxNone:
                                            if (svUnitPriceTaxExc != row.SalesUnPrcDisplay)
                                            {
                                                row.SalesRate = 0;
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    //-----------------------------------------------------
                                    // ���z�\������
                                    //-----------------------------------------------------
                                    switch ((CalculateTax.TaxationCode)taxationDivCd)
                                    {
                                        case CalculateTax.TaxationCode.TaxExc:
                                            if (svUnitPriceTaxInc != row.SalesUnPrcDisplay)
                                            {
                                                row.SalesRate = 0;
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxInc:
                                            if (svUnitPriceTaxInc != row.SalesUnPrcDisplay)
                                            {
                                                row.SalesRate = 0;
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxNone:
                                            if (svUnitPriceTaxInc != row.SalesUnPrcDisplay)
                                            {
                                                row.SalesRate = 0;
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                    }
                                }
                            }

                            break;
                        }
                }

                // ����P���ύX�敪�ݒ�
                if (row.SalesUnPrcTaxExcFl != row.BfSalesUnitPrice)
                {
                    row.SalesUnPrcChngCd = 1; // �ύX����
                }
                else
                {
                    row.SalesUnPrcChngCd = 0; // �ύX�Ȃ�
                }

                // ������z����͋敪
                if (inputPositionMode == 0) row.SalesMoneyInputDiv = (int)SalesMoneyInputDiv.Calculate;
            }
            #endregion

            #region ���󒍏��
            if (acptAnOdrRow != null)
            {
                // ��ې�
                int taxationDivCd = acptAnOdrRow.TaxationDivCd;
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt) taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;

                switch (salesUnitPriceInputType)
                {
                    // ���P��(�Ŕ���)--->>>���������͂��瑍�z�\�����Ȃ����̂݃R�[��
                    case SalesUnitPriceInputType.SalesUnitPrice:
                        {
                            switch ((CalculateTax.TaxationCode)taxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    acptAnOdrRow.SalesUnPrcDisplay = salesUnitPrice;
                                    acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice;
                                    acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    acptAnOdrRow.SalesUnPrcDisplay = salesUnitPrice;
                                    acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                    acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice;
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    acptAnOdrRow.SalesUnPrcDisplay = salesUnitPrice; // ���P��(�Ŕ�)�\��
                                    acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice;// ���P���P��(�Ŕ�)
                                    acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice;// ���P���P��(�ō�)
                                    break;
                            }
                            break;
                        }
                    // ���P��(�ō���)--->>>���������͂��瑍�z�\�����鎞�̂݃R�[��
                    case SalesUnitPriceInputType.SalesUnitTaxPrice:
                        {
                            switch ((CalculateTax.TaxationCode)taxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                case CalculateTax.TaxationCode.TaxInc:
                                    acptAnOdrRow.SalesUnPrcDisplay = salesUnitPrice;
                                    acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                    acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice;
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    acptAnOdrRow.SalesUnPrcDisplay = salesUnitPrice;
                                    acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice;
                                    acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice;
                                    break;
                            }
                            break;
                        }
                    // ���P��(�\���p)
                    case SalesUnitPriceInputType.SalesUnitPriceDisplay:
                        {

                            if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
                            {
                                //-----------------------------------------------------
                                // ���z�\�����Ȃ�
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)taxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice;
                                        acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice;
                                        acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                //-----------------------------------------------------
                                // ���z�\������
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)taxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitPrice);
                                        acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnitPrice;
                                        acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnitPrice;
                                        break;
                                }
                            }

                            //----------------------------------------------------------------------------
                            // �|���Z�o����Ă���ꍇ
                            //----------------------------------------------------------------------------
                            if (!(string.IsNullOrEmpty(acptAnOdrRow.RateDivSalUnPrc)) || (acptAnOdrRow.SalesRate != 0))
                            {
                                if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
                                {
                                    //-----------------------------------------------------
                                    // ���z�\�����Ȃ�
                                    //-----------------------------------------------------
                                    switch ((CalculateTax.TaxationCode)taxationDivCd)
                                    {
                                        case CalculateTax.TaxationCode.TaxExc:
                                            //>>>2011/10/29
                                            //if (svUnitPriceTaxExc != acptAnOdrRow.SalesUnPrcDisplay)
                                            if (svUnitPriceTaxExc != row.SalesUnPrcDisplay)
                                            //<<<2011/10/29
                                            {
                                                //>>>2010/07/29
                                                //row.SalesRate = 0;
                                                acptAnOdrRow.SalesRate = 0;
                                                //<<<2010/07/29
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxInc:
                                            //>>>2011/10/29
                                            //if (svUnitPriceTaxInc != acptAnOdrRow.SalesUnPrcDisplay)
                                            if (svUnitPriceTaxInc != row.SalesUnPrcDisplay)
                                            //<<<2011/10/29
                                            {
                                                acptAnOdrRow.SalesRate = 0;
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxNone:
                                            //>>>2011/10/29
                                            //if (svUnitPriceTaxExc != acptAnOdrRow.SalesUnPrcDisplay)
                                            if (svUnitPriceTaxExc != row.SalesUnPrcDisplay)
                                            //<<<2011/10/29
                                            {
                                                acptAnOdrRow.SalesRate = 0;
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    //-----------------------------------------------------
                                    // ���z�\������
                                    //-----------------------------------------------------
                                    switch ((CalculateTax.TaxationCode)taxationDivCd)
                                    {
                                        case CalculateTax.TaxationCode.TaxExc:
                                            //>>>2011/10/29
                                            //if (svUnitPriceTaxInc != acptAnOdrRow.SalesUnPrcDisplay)
                                            if (svUnitPriceTaxInc != row.SalesUnPrcDisplay)
                                            //<<<2011/10/29
                                            {
                                                acptAnOdrRow.SalesRate = 0;
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxInc:
                                            //>>>2011/10/29
                                            //if (svUnitPriceTaxInc != acptAnOdrRow.SalesUnPrcDisplay)
                                            if (svUnitPriceTaxInc != row.SalesUnPrcDisplay)
                                            //<<<2011/10/29
                                            {
                                                acptAnOdrRow.SalesRate = 0;
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxNone:
                                            //>>>2011/10/29
                                            //if (svUnitPriceTaxInc != acptAnOdrRow.SalesUnPrcDisplay)
                                            if (svUnitPriceTaxInc != row.SalesUnPrcDisplay)
                                            //<<<2011/10/29
                                            {
                                                acptAnOdrRow.SalesRate = 0;
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                                            }
                                            break;
                                    }
                                }
                            }

                            break;
                        }
                }

                // ����P���ύX�敪�ݒ�
                if (acptAnOdrRow.SalesUnPrcTaxExcFl != acptAnOdrRow.BfSalesUnitPrice)
                {
                    acptAnOdrRow.SalesUnPrcChngCd = 1; // �ύX����
                }
                else
                {
                    acptAnOdrRow.SalesUnPrcChngCd = 0; // �ύX�Ȃ�
                }

                // ������z����͋敪
                if (inputPositionMode == 0) acptAnOdrRow.SalesMoneyInputDiv = (int)SalesMoneyInputDiv.Calculate;
            }
            #endregion
        }

        /// <summary>
        /// �|�����g�p���ĒP�����Z�o���܂��B
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        /// <param name="unitPriceTaxInc"></param>
        /// <param name="unitPriceTaxExc"></param>
        /// <param name="unitPriceDisplay"></param>
        /// <br>Update Note: 2010/01/27 ���M �����v�Z�����̕s��Ή�(�S������)</br>
        /// <br>Update Note: 2010/03/12 ����� redmine#3773 �����v�Z�����̕s��Ή�</br>
        /// <br>Update Note: 2010/03/22 ���� redmine#4075 �����v�Z�����̕s��Ή�</br>
        private void CalculateUnitPriceByRate(SalesInputDataSet.SalesDetailRow row, UnitPriceCalculation.UnitPriceKind unitPriceKind, out double unitPriceTaxInc, out double unitPriceTaxExc, out double unitPriceDisplay)
        {
            int frcProcCd = 0;          // �[�������R�[�h
            int fracProcDiv = 0;        // �[�������敪
            double fracProcUnit = 0;    // �[�������P��
            double rate = 0;            // �|��
            double price = 0;           // ����i

            // ����Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            switch ((UnitPriceCalculation.UnitPriceKind)unitPriceKind)
            {
                #region �����P��
                //------------------------------------------------------
                // ���P��
                //------------------------------------------------------
                case UnitPriceCalculation.UnitPriceKind.UnitCost:
                    //------------------------------------------------------
                    // ����i�~�|��
                    //------------------------------------------------------
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdUnCst)
                    {
                        //------------------------------------------------------
                        // ����i�~�|��
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            frcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = row.FracProcUnitUnCst;
                            fracProcDiv = row.FracProcUnCst;
                            rate = row.CostRate;
                            price = row.StdUnPrcUnCst;
                            break;
                        default:
                            frcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                            this._salesSlipInputInitDataAcs.GetStockFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_SalesUnitCost, frcProcCd, 0, out fracProcUnit, out fracProcDiv);
                            rate = row.CostRate;
                            switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                            {
                                //------------------------------------------------------
                                // �O��
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxExc:
                                    // --- UPD 2010/01/27 -------------->>>>>
                                    //price = row.ListPriceTaxExcFl;
                                    // --- UPD 2010/03/12 -------------->>>>>
                                    //if (string.IsNullOrEmpty(row.RateDivLPrice))
                                    //{

                                    //    price = row.BfListPrice;
                                    //}
                                    //else
                                    //{
                                    //    price = row.StdUnPrcLPrice;
                                    //}

                                    // ListPriceChngCd ���u1:�ύX����v�̏ꍇ
                                    if (row.ListPriceChngCd == 1)
                                    {
                                        price = row.ListPriceTaxExcFl;
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(row.RateDivLPrice))
                                        {
                                            // --- UPD 2010/03/22-------------->>>>>
                                            //price = row.BfListPrice;

                                            //�ύX�O�艿BfListPrice���[���̏ꍇ�A�艿(�Ŕ�)(ListPriceTaxExcFl)���g�p����
                                            if (row.BfListPrice == 0)
                                            {
                                                price = row.ListPriceTaxExcFl;
                                            }
                                            else
                                            {
                                                //>>>2010/11/19
                                                //price = row.BfListPrice;
                                                if (row.SelectedListPriceDiv == 1)
                                                {
                                                    // �W�����i�I���Œ艿��I�������ꍇ�́A�D�ǒ艿�Ō��P�����Z�o
                                                    price = row.BfListPrice;
                                                }
                                                else
                                                {
                                                    // �W�����i�I���Œ艿��I�����Ă��Ȃ��ꍇ�́A��ʒ艿�Ō��P�����Z�o
                                                    price = row.ListPriceTaxExcFl;
                                                }
                                                //<<<2010/11/19
                                            }
                                            //--- UPD 2010/03/22 --------------<<<<<
                                        }
                                        else
                                        {
                                            // --- UPD 2010/03/22-------------->>>>>
                                            //price = row.StdUnPrcLPrice;

                                            //��P��(�艿)StdUnPrcLPrice���[���̏ꍇ�A��P��(����)StdUnPrcUnCst���g�p����
                                            if (row.StdUnPrcLPrice == 0)
                                            {
                                                if (row.StdUnPrcUnCst == 0)
                                                {
                                                    price = row.ListPriceTaxExcFl;
                                                }
                                                else
                                                {
                                                    price = row.StdUnPrcUnCst;
                                                }   
                                            }
                                            else
                                            {
                                                price = row.StdUnPrcLPrice;
                                            }
                                            //--- UPD 2010/03/22 --------------<<<<<
                                        }                                        
                                    }
                                    // --- UPD 2010/03/12 --------------<<<<<
                                    // --- UPD 2010/01/27 --------------<<<<<
                                    break;
                                //------------------------------------------------------
                                // ����
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxInc:
                                    price = row.ListPriceTaxIncFl;
                                    break;
                                //------------------------------------------------------
                                // ��ې�
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxNone:
                                    price = row.ListPriceTaxExcFl;
                                    break;
                            }
                            break;
                    }
                    break;
                #endregion

                #region �����P��
                //------------------------------------------------------
                // ���P��
                //------------------------------------------------------
                case UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc)
                    {
                        //------------------------------------------------------
                        // ����i�~�|��
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = row.FracProcUnitSalUnPrc;
                            fracProcDiv = row.FracProcSalUnPrc;
                            rate = row.SalesRate;
                            price = row.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // ���P���~�����t�o��
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                            frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = row.FracProcUnitSalUnPrc;
                            fracProcDiv = row.FracProcSalUnPrc;
                            rate = row.CostUpRate;
                            price = row.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // ���P���~(�P�|�e����)
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                            frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = row.FracProcUnitSalUnPrc;
                            fracProcDiv = row.FracProcSalUnPrc;
                            rate = row.GrossProfitSecureRate;
                            price = row.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // �P�����ڎw��
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                            frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                            fracProcUnit = row.FracProcUnitSalUnPrc;
                            fracProcDiv = row.FracProcSalUnPrc;
                            rate = row.SalesRate;
                            switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                            {
                                //------------------------------------------------------
                                // �O��
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxExc:
                                    price = row.ListPriceTaxExcFl;
                                    break;
                                //------------------------------------------------------
                                // ����
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxInc:
                                    price = row.ListPriceTaxIncFl;
                                    break;
                                //------------------------------------------------------
                                // ��ې�
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxNone:
                                    price = row.ListPriceTaxExcFl;
                                    break;
                            }
                            break;
                    }
                    break;
                #endregion
            }

            // ��ې�
            int taxationDivCd = row.TaxationDivCd;
            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt) taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;

            int unPrcCalcCd = 0;
            switch ((UnitPriceCalculation.UnitPriceKind)unitPriceKind)
            {
                case UnitPriceCalculation.UnitPriceKind.UnitCost:
                    unPrcCalcCd = row.UnPrcCalcCdUnCst;
                    break;
                case UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                    unPrcCalcCd = row.UnPrcCalcCdSalUnPrc;
                    break;
            }

            if (unPrcCalcCd != (int)UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate)
            {
                this._unitPriceCalculation.CalculateUnitPriceByRate(unitPriceKind,
                                                                    (UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc,
                                                                    this._salesSlip.TotalAmountDispWayCd,
                                                                    0,
                                                                    frcProcCd,
                                                                    taxationDivCd,
                                                                    price,
                                                                    this._salesSlip.ConsTaxRate,
                                                                    taxFracProcUnit,
                                                                    taxFracProcCd,
                                                                    rate,
                                                                    ref fracProcUnit,
                                                                    ref fracProcDiv,
                                                                    out unitPriceTaxExc,
                                                                    out unitPriceTaxInc);
            }
            else
            {
                this._unitPriceCalculation.CalculateUnitPriceByMarginRate(unitPriceKind,
                                                                    //(UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc,
                                                                    this._salesSlip.TotalAmountDispWayCd,
                                                                    0,
                                                                    frcProcCd,
                                                                    taxationDivCd,
                                                                    price,
                                                                    this._salesSlip.ConsTaxRate,
                                                                    taxFracProcUnit,
                                                                    taxFracProcCd,
                                                                    rate,
                                                                    ref fracProcUnit,
                                                                    ref fracProcDiv,
                                                                    out unitPriceTaxExc,
                                                                    out unitPriceTaxInc);
            }
            if ((UnitPriceCalculation.UnitPriceKind)unitPriceKind != UnitPriceCalculation.UnitPriceKind.UnitCost)
            {
                // �u���z�\������v���A�u���ŏ��i�v�̏ꍇ�͐ō��ݒP����\���P���ɐݒ�
                if ((this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount) || (taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc))
                {
                    unitPriceDisplay = unitPriceTaxInc;
                }
                else
                {
                    unitPriceDisplay = unitPriceTaxExc;
                }
            }
            else
            {
                if (taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc)
                {
                    unitPriceDisplay = unitPriceTaxInc;
                }
                else
                {
                    unitPriceDisplay = unitPriceTaxExc;
                }
            }

            switch ((UnitPriceCalculation.UnitPriceKind)unitPriceKind)
            {
                case UnitPriceCalculation.UnitPriceKind.UnitCost:
                    row.FracProcUnitUnCst = fracProcUnit;
                    row.FracProcUnCst = fracProcDiv;
                    break;
                case UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                    row.FracProcUnitSalUnPrc = fracProcUnit;
                    row.FracProcSalUnPrc = fracProcDiv;
                    break;
            }
        }

        /// <summary>
        /// �|�����g�p���ĒP�����Z�o���܂��B
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        /// <param name="fracProcDiv"></param>
        /// <param name="fracProcUnit"></param>
        /// <param name="unitPriceTaxInc"></param>
        /// <param name="unitPriceTaxExc"></param>
        /// <param name="unitPriceDisplay"></param>
        private void CalculateUnitPriceByRate(SalesInputDataSet.SalesDetailRow row, UnitPriceCalculation.UnitPriceKind unitPriceKind, ref int fracProcDiv, ref double fracProcUnit, out double unitPriceTaxInc, out double unitPriceTaxExc, out double unitPriceDisplay)
        {
            int frcProcCd = 0;          // �[�������R�[�h
            double rate = 0;            // �|��
            double price = 0;           // ����i

            // ����Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            switch ((UnitPriceCalculation.UnitPriceKind)unitPriceKind)
            {
                #region �����P��
                //------------------------------------------------------
                // ���P��
                //------------------------------------------------------
                case UnitPriceCalculation.UnitPriceKind.UnitCost:
                    //------------------------------------------------------
                    // �[�������敪�A�P�ʎ擾
                    //------------------------------------------------------
                    frcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                    //------------------------------------------------------
                    // ����i�~�|��
                    //------------------------------------------------------
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdUnCst)
                    {
                        //------------------------------------------------------
                        // ����i�~�|��
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            rate = row.CostRate;
                            price = row.StdUnPrcUnCst;
                            break;
                        default:
                            rate = row.CostRate;
                            price = row.ListPriceTaxExcFl;
                            break;
                    }
                    break;
                #endregion

                #region �����P��
                //------------------------------------------------------
                // ���P��
                //------------------------------------------------------
                case UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                    //------------------------------------------------------
                    // �[�������敪�A�P�ʎ擾
                    //------------------------------------------------------
                    frcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc)
                    {
                        //------------------------------------------------------
                        // ����i�~�|��
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            rate = row.SalesRate;
                            price = row.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // ���P���~�����t�o��
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                            rate = row.CostUpRate;
                            price = row.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // ���P���~(�P�|�e����)
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                            rate = row.GrossProfitSecureRate;
                            price = row.StdUnPrcSalUnPrc;
                            break;
                        //------------------------------------------------------
                        // �P�����ڎw��
                        //------------------------------------------------------
                        case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        //    rate = 0;
                        //    price = 0;
                        //    break;
                        //default:
                            rate = row.SalesRate;
                            switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                            {
                                //------------------------------------------------------
                                // �O��
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxExc:
                                    price = row.ListPriceTaxExcFl;
                                    break;
                                //------------------------------------------------------
                                // ����
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxInc:
                                    price = row.ListPriceTaxIncFl;
                                    break;
                                //------------------------------------------------------
                                // ��ې�
                                //------------------------------------------------------
                                case CalculateTax.TaxationCode.TaxNone:
                                    price = row.ListPriceTaxExcFl;
                                    break;
                            }
                            break;
                    }
                    break;
                #endregion
            }

            // ��ې�
            int taxationDivCd = row.TaxationDivCd;
            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt) taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;

            // --- ADD 2010/07/29 ---------->>>>>
            if ((UnitPriceCalculation.UnitPriceKind)unitPriceKind == UnitPriceCalculation.UnitPriceKind.SalesUnitPrice &&
                 (UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc == UnitPriceCalculation.UnitPrcCalcDiv.Price)
            {
                // �P�����ڎw��̏ꍇ�͂��̂܂܃Z�b�g
                unitPriceTaxInc = row.SalesUnPrcTaxIncFl;
                unitPriceTaxExc = row.SalesUnPrcTaxExcFl;
            }
            else
            {
            // --- ADD 2010/07/29 ----------<<<<<

                int unPrcCalcCd = 0;
                switch ((UnitPriceCalculation.UnitPriceKind)unitPriceKind)
                {
                    case UnitPriceCalculation.UnitPriceKind.UnitCost:
                        unPrcCalcCd = row.UnPrcCalcCdUnCst;
                        break;
                    case UnitPriceCalculation.UnitPriceKind.SalesUnitPrice:
                        unPrcCalcCd = row.UnPrcCalcCdSalUnPrc;
                        break;
                }

                if (unPrcCalcCd != (int)UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate)
                {
                    this._unitPriceCalculation.CalculateUnitPriceByRate(unitPriceKind,
                                                                        (UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc,
                                                                        this._salesSlip.TotalAmountDispWayCd,
                                                                        0,
                                                                        frcProcCd,
                                                                        taxationDivCd,
                                                                        price,
                                                                        this._salesSlip.ConsTaxRate,
                                                                        taxFracProcUnit,
                                                                        taxFracProcCd,
                                                                        rate,
                                                                        ref fracProcUnit,
                                                                        ref fracProcDiv,
                                                                        out unitPriceTaxExc,
                                                                        out unitPriceTaxInc);
                }
                else
                {
                    this._unitPriceCalculation.CalculateUnitPriceByMarginRate(unitPriceKind,
                        //(UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc,
                                                                        this._salesSlip.TotalAmountDispWayCd,
                                                                        0,
                                                                        frcProcCd,
                                                                        taxationDivCd,
                                                                        price,
                                                                        this._salesSlip.ConsTaxRate,
                                                                        taxFracProcUnit,
                                                                        taxFracProcCd,
                                                                        rate,
                                                                        ref fracProcUnit,
                                                                        ref fracProcDiv,
                                                                        out unitPriceTaxExc,
                                                                        out unitPriceTaxInc);
                }
            // --- 2010/07/29 ---------->>>>>
            }
            // --- 2010/07/29 ----------<<<<<

            // �u���z�\������v���A�u���ŏ��i�v�̏ꍇ�͐ō��ݒP����\���P���ɐݒ�
            if ((this._salesSlip.TotalAmountDispWayCd == 1) || (taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc))
            {
                unitPriceDisplay = unitPriceTaxInc;
            }
            else
            {
                unitPriceDisplay = unitPriceTaxExc;
            }
        }

        /// <summary>
        /// �|�����g�p���ĒP�����Z�o���܂��B�i�󒍏��p�j
        /// </summary>
        /// <param name="acptAnOdrRow"></param>
        /// <param name="unitPriceKind"></param>
        /// <param name="unitPriceTaxInc"></param>
        /// <param name="unitPriceTaxExc"></param>
        /// <param name="unitPriceDisplay"></param>
        private void CalculateUnitPriceByRate(SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow, UnitPriceCalculation.UnitPriceKind unitPriceKind, out double unitPriceTaxInc, out double unitPriceTaxExc, out double unitPriceDisplay)
        {
            SalesInputDataSet.SalesDetailRow newSalesDetailRow = this._salesDetailDataTable.NewSalesDetailRow();
            this.CopySalesDetailFromAcceptAnOrder(acptAnOdrRow, newSalesDetailRow);
            this.CalculateUnitPriceByRate(newSalesDetailRow, UnitPriceCalculation.UnitPriceKind.UnitCost, out unitPriceTaxInc, out unitPriceTaxExc, out unitPriceDisplay);
        }

        /// <summary>
        /// �|�����g�p���ĒP�����Z�o���܂��B�i�󒍏��p�j
        /// </summary>
        /// <param name="acptAnOdrRow"></param>
        /// <param name="unitPriceKind"></param>
        /// <param name="fracProcDiv"></param>
        /// <param name="fracProcUnit"></param>
        /// <param name="unitPriceTaxInc"></param>
        /// <param name="unitPriceTaxExc"></param>
        /// <param name="unitPriceDisplay"></param>
        private void CalculateUnitPriceByRate(SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow, UnitPriceCalculation.UnitPriceKind unitPriceKind, ref int fracProcDiv, ref double fracProcUnit, out double unitPriceTaxInc, out double unitPriceTaxExc, out double unitPriceDisplay)
        {
            SalesInputDataSet.SalesDetailRow newSalesDetailRow = this._salesDetailDataTable.NewSalesDetailRow();
            this.CopySalesDetailFromAcceptAnOrder(acptAnOdrRow, newSalesDetailRow);
            // --- UPD 2012/10/31 T.Nishi ---------->>>>>
            //this.CalculateUnitPriceByRate(newSalesDetailRow, UnitPriceCalculation.UnitPriceKind.UnitCost, ref fracProcDiv, ref fracProcUnit, out unitPriceTaxInc, out unitPriceTaxExc, out unitPriceDisplay);
            this.CalculateUnitPriceByRate(newSalesDetailRow, UnitPriceCalculation.UnitPriceKind.SalesUnitPrice, ref fracProcDiv, ref fracProcUnit, out unitPriceTaxInc, out unitPriceTaxExc, out unitPriceDisplay);
            // --- UPD 2012/10/31 T.Nishi ----------<<<<<
        }

        /// <summary>
        /// �w�肵�����P���̒l�����ɔ��㖾�׍s�I�u�W�F�N�g�̒P������ݒ肵�܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="salesUnitPriceInputType">����P�����̓��[�h</param>
        /// <param name="salesUnitPrice">���P��</param>
        /// <param name="inputPositionMode">���͈ʒu���[�h(0:���P�� 1:���̑�)</param>
        /// <remarks>
        /// <br>Call�F���i�����A���P���^���P���^������ �ύX��</br>
        /// </remarks>
        public void SalesDetailRowSalesUnitPriceSetting(int salesRowNo, SalesUnitPriceInputType salesUnitPriceInputType, double salesUnitPrice, int inputPositionMode)
        {
            this.SalesDetailRowSalesUnitPriceSetting(salesRowNo, salesUnitPriceInputType, salesUnitPrice, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable, inputPositionMode);
        }

        /// <summary>
        /// ��P���A�|�������ɔ��㖾�׍s�I�u�W�F�N�g����ю󒍖��׍s�I�u�W�F�N�g�̒P�������Đݒ肵�܂��B
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">�󒍖��׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Call�F�艿�^���P���^������ �ύX��(���P���Z�o�̊�P���ύX��)</br>
        /// <br>UpdateNote : 2011/08/12 杍^ Redmine#23554 �L�����y�[���̔����u�������A�l�����A�����z�v���ݒ肳��Ă���ꍇ�́A�|���}�X�^�̔����̐ݒ���N���A����悤�Ɏd�l�ύX�̑Ή�</br>
        /// </remarks>
        public void SalesDetailRowSalesUnitPriceReSetting(int salesRowNo, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        {
            #region ����������
            SalesInputDataSet.SalesDetailRow row = salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);

            // �[�������敪�A�[�������P��
            int fracProcSalUnPrc = 0;
            double fracProcUnitSalUnPrc = 0;

            // ����Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            int fracProcCd;
            double fracProcUnit;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);
            this._salesSlip.FractionProcCd = fracProcCd;

            double unitPriceTaxExc = 0;
            double unitPriceTaxInc = 0;
            double unitPriceDisplay = 0;
            #endregion

            #region ��������

            // �|���Z�o����Ă���ꍇ�A�Đݒ�
            // UPD 2011/08/12 ---- >>>>>>>
            //if ((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0))
            if (((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0)) && this._campaignObjGoodsSt == null)
            // UPD 2011/08/12 ---- <<<<<<<
            {
                fracProcSalUnPrc = row.FracProcSalUnPrc;
                fracProcUnitSalUnPrc = row.FracProcUnitSalUnPrc;

                this.CalculateUnitPriceByRate(row, UnitPriceCalculation.UnitPriceKind.SalesUnitPrice, ref fracProcSalUnPrc, ref fracProcUnitSalUnPrc, out unitPriceTaxInc, out unitPriceTaxExc, out unitPriceDisplay);

                row.FracProcUnitSalUnPrc = fracProcUnitSalUnPrc;
                row.FracProcSalUnPrc = fracProcSalUnPrc;
                row.SalesUnPrcTaxExcFl = unitPriceTaxExc;
                row.SalesUnPrcTaxIncFl = unitPriceTaxInc;
                row.SalesUnPrcDisplay = unitPriceDisplay;
            }

            #endregion

            #region ���󒍏��
            if (acptAnOdrRow != null)
            {
                // �|���Z�o����Ă���ꍇ�A�Đݒ�
                if ((!string.IsNullOrEmpty(acptAnOdrRow.RateDivSalUnPrc.Trim())) || (acptAnOdrRow.StdUnPrcSalUnPrc != 0))
                {
                    fracProcSalUnPrc = acptAnOdrRow.FracProcSalUnPrc;
                    fracProcUnitSalUnPrc = acptAnOdrRow.FracProcUnitSalUnPrc;
                    this.CalculateUnitPriceByRate(acptAnOdrRow, UnitPriceCalculation.UnitPriceKind.SalesUnitPrice, ref fracProcSalUnPrc, ref fracProcUnitSalUnPrc, out unitPriceTaxInc, out unitPriceTaxExc, out unitPriceDisplay);

                    acptAnOdrRow.FracProcUnitSalUnPrc = fracProcUnitSalUnPrc;
                    acptAnOdrRow.FracProcSalUnPrc = fracProcSalUnPrc;
                    acptAnOdrRow.SalesUnPrcTaxExcFl = unitPriceTaxExc;
                    acptAnOdrRow.SalesUnPrcTaxIncFl = unitPriceTaxInc;
                    acptAnOdrRow.SalesUnPrcDisplay = unitPriceDisplay;
                }
            }
            #endregion
        }

        /// <summary>
        /// ��P���A�|�������ɔ��㖾�׍s�I�u�W�F�N�g�̒P�������Đݒ肵�܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <remarks>
        /// <br>Call�F�艿�^���P���^������ �ύX��(���P���Z�o�̊�P���ύX��)</br>
        /// </remarks>
        public void SalesDetailRowSalesUnitPriceReSetting(int salesRowNo)
        {
            this.SalesDetailRowSalesUnitPriceReSetting(salesRowNo, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// �w�肵���������̒l�����ɔ��㖾�׍s�I�u�W�F�N�g�̔��P������ݒ肵�܂��B
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="salesRate">������</param>
        /// <param name="clearCalculateUnitInfoFlg">�|���Z�o���N���A�t���O(true:�N���A���� false:�N���A���Ȃ�)</param>
        /// <remarks>
        /// <br>Call�F�艿�^������ �ύX��</br>
        /// <br>Update Note: 2009/10/19 ���M �ێ�˗��A�@�\�Ή�</br>
        /// </remarks>
        public void SalesDetailRowSalesUnitPriceSettingbyRate(int salesRowNo, double salesRate, bool clearCalculateUnitInfoFlg)
        {

            double salesUnPrcTaxExcFl;
            double salesUnPrcTaxIncFl;
            double salesUnPrcDisplay;

            #region ��������
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (row == null) return;

            row.SalesRate = salesRate;

            if (clearCalculateUnitInfoFlg == true)
            {
                // �|���Z�o���N���A
                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
            }
            // --- UPD 2009/10/19 ---------->>>>>
            if (salesRate != 0)
            {
            this.CalclateSalesUnitPrice(row, out salesUnPrcDisplay, out salesUnPrcTaxIncFl, out salesUnPrcTaxExcFl);

            row.SalesUnPrcDisplay = salesUnPrcDisplay;
            row.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
            row.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl;

            // ����P���ύX�敪�ݒ�
            if (row.SalesUnPrcTaxExcFl != row.BfSalesUnitPrice)
            {
                row.SalesUnPrcChngCd = 1; // �ύX����
            }
            else
            {
                row.SalesUnPrcChngCd = 0; // �ύX�Ȃ�
            }
            }
            // --- UPD 2009/10/19 ----------<<<<<

            row.SalesMoneyInputDiv = (int)SalesMoneyInputDiv.Calculate;
            #endregion

            #region ���󒍏��
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = this._salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);
            if (acptAnOdrRow == null) return;

            acptAnOdrRow.SalesRate = salesRate;

            if (clearCalculateUnitInfoFlg == true)
            {
                // �|���Z�o���N���A
                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
            }

            // --- UPD 2009/10/19 ---------->>>>>
            if (salesRate != 0)
            {
            this.CalclateSalesUnitPrice(acptAnOdrRow, out salesUnPrcDisplay, out salesUnPrcTaxIncFl, out salesUnPrcTaxExcFl);

            acptAnOdrRow.SalesUnPrcDisplay = salesUnPrcDisplay;
            acptAnOdrRow.SalesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
            acptAnOdrRow.SalesUnPrcTaxIncFl = salesUnPrcTaxIncFl;

            // ����P���ύX�敪�ݒ�
            if (acptAnOdrRow.SalesUnPrcTaxExcFl != acptAnOdrRow.BfSalesUnitPrice)
            {
                acptAnOdrRow.SalesUnPrcChngCd = 1; // �ύX����
            }
            else
            {
                acptAnOdrRow.SalesUnPrcChngCd = 0; // �ύX�Ȃ�
            }
            }
            // --- UPD 2009/10/19 ----------<<<<<

            acptAnOdrRow.SalesMoneyInputDiv = (int)SalesMoneyInputDiv.Calculate;
            #endregion

        }

        /// <summary>
        /// ���������g�p���Ē艿���甄�P�������Z�o���܂��B
        /// </summary>
        /// <param name="row">���㖾�׍s�I�u�W�F�N�g</param>
        /// <param name="unitPriceDisplay">���P��(�\��)</param>
        /// <param name="unitPriceTaxInc">���P��(�ō�)</param>
        /// <param name="unitPriceTaxExc">���P��(�Ŕ�)</param>
        private void CalclateSalesUnitPrice(SalesInputDataSet.SalesDetailRow row, out double unitPriceDisplay, out double unitPriceTaxInc, out double unitPriceTaxExc)
        {
            unitPriceDisplay = 0;
            unitPriceTaxInc = 0;
            unitPriceTaxExc = 0;
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd); // �������Œ[�������R�[�h
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            this.CalculateUnitPriceByRate(row, UnitPriceCalculation.UnitPriceKind.SalesUnitPrice, out unitPriceTaxInc, out unitPriceTaxExc, out unitPriceDisplay);
        }

        /// <summary>
        /// ���������g�p���Ē艿���甄�P�������Z�o���܂��B�i�󒍏��p�j
        /// </summary>
        /// <param name="row">���㖾�׍s�I�u�W�F�N�g</param>
        /// <param name="unitPriceDisplay">���P��(�\��)</param>
        /// <param name="unitPriceTaxInc">���P��(�ō�)</param>
        /// <param name="unitPriceTaxExc">���P��(�Ŕ�)</param>
        private void CalclateSalesUnitPrice(SalesInputDataSet.SalesDetailAcceptAnOrderRow row, out double unitPriceDisplay, out double unitPriceTaxInc, out double unitPriceTaxExc)
        {
            SalesInputDataSet.SalesDetailRow newSalesDetailRow = this._salesDetailDataTable.NewSalesDetailRow();
            this.CopySalesDetailFromAcceptAnOrder(row, newSalesDetailRow);
            CalclateSalesUnitPrice(newSalesDetailRow, out unitPriceDisplay, out unitPriceTaxInc, out unitPriceTaxExc);
        }

        /// <summary>
        /// �w�肵�����P���̒l�����ɔ��㖾�׍s�I�u�W�F�N�g�̌��P������ݒ肵�܂��B
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="salesUnitPriceInputType">�P�����̓��[�h</param>
        /// <param name="salesUnitCost">���P��</param>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Call�F���i�����A���P���^�d���� �ύX��</br>
        /// </remarks>
        public void SalesDetailRowSalesUnitCostSetting(int salesRowNo, SalesUnitPriceInputType salesUnitPriceInputType, double salesUnitCost, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        {
            #region ����������
            SalesInputDataSet.SalesDetailRow row = salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);

            // ����Œ[�������R�[�h
            int taxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);

            // ����Œ[�������P�ʁA�敪�擾
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, taxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            double svUnitCostTaxInc = row.SalesUnitCostTaxInc;
            double svUnitCostTaxExc = row.SalesUnitCostTaxExc;
            #endregion

            #region ��������
            if (row != null)
            {
                switch (salesUnitPriceInputType)
                {
                    // ���P��(�Ŕ���)
                    case SalesUnitPriceInputType.SalesUnitPrice:
                        {
                            switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    row.SalesUnitCost = salesUnitCost;           // �����\��
                                    row.SalesUnitCostTaxExc = salesUnitCost;     // ����(�Ŕ�)
                                    row.SalesUnitCostTaxInc = salesUnitCost + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // ����(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    row.SalesUnitCost = salesUnitCost;           // �����\��
                                    row.SalesUnitCostTaxExc = salesUnitCost - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // ����(�Ŕ�)
                                    row.SalesUnitCostTaxInc = salesUnitCost;     // ����(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    row.SalesUnitCost = salesUnitCost;           // �����\��
                                    row.SalesUnitCostTaxExc = salesUnitCost;     // ����(�Ŕ�)
                                    row.SalesUnitCostTaxInc = salesUnitCost;     // ����(�ō�)
                                    break;
                            }
                            break;
                        }
                    // ���P��(�ō���)
                    case SalesUnitPriceInputType.SalesUnitTaxPrice:
                        {

                            switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                case CalculateTax.TaxationCode.TaxInc:
                                    row.SalesUnitCost = salesUnitCost;           // �����\��
                                    row.SalesUnitCostTaxExc = salesUnitCost - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // ����(�Ŕ�)
                                    row.SalesUnitCostTaxInc = salesUnitCost;     // ����(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    row.SalesUnitCost = salesUnitCost;           // �����\��
                                    row.SalesUnitCostTaxExc = salesUnitCost;     // ����(�Ŕ�)
                                    row.SalesUnitCostTaxInc = salesUnitCost;     // ����(�ō�)
                                    break;
                            }
                            break;
                        }
                    // ���P��(�\���p)
                    case SalesUnitPriceInputType.SalesUnitPriceDisplay:
                        {

                            switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    row.SalesUnitCostTaxExc = salesUnitCost;     // ����(�Ŕ�)
                                    row.SalesUnitCostTaxInc = salesUnitCost + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // ����(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    row.SalesUnitCostTaxExc = salesUnitCost - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // ����(�Ŕ�)
                                    row.SalesUnitCostTaxInc = salesUnitCost;     // ����(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    row.SalesUnitCostTaxExc = salesUnitCost;     // ����(�Ŕ�)
                                    row.SalesUnitCostTaxInc = salesUnitCost;     // ����(�ō�)
                                    break;
                            }

                            //----------------------------------------------------------------------------
                            // �|���Z�o����Ă���ꍇ
                            //----------------------------------------------------------------------------
                            if ((!string.IsNullOrEmpty(row.RateDivUnCst)) || (row.CostRate != 0))
                            //if (((!string.IsNullOrEmpty(row.RateDivUnCst)) || (row.CostRate != 0)) && this._campaignObjGoodsSt == null)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        if (svUnitCostTaxExc != row.SalesUnitCost)
                                        {
                                            // �|���Z�o���N���A
                                            this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
                                            row.CostRate = 0;
                                        }
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        if (svUnitCostTaxInc != row.SalesUnitCost)
                                        {
                                            // �|���Z�o���N���A
                                            this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
                                            row.CostRate = 0;
                                        }
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        if (svUnitCostTaxExc != row.SalesUnitCost)
                                        {
                                            // �|���Z�o���N���A
                                            this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
                                            row.CostRate = 0;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        }
                }

                // ��P��(����P��)�ݒ�
                switch ((UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc)
                {
                    case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                        break;
                    case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                    case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                        row.StdUnPrcSalUnPrc = salesUnitCost; // ����i(���P��)
                        break;
                    case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        row.StdUnPrcSalUnPrc = 0;
                        break;
                }

                // �����P���ύX�敪�ݒ�
                if (salesUnitCost != row.BfUnitCost)
                {
                    row.SalesUnitCostChngDiv = 1; // �ύX����
                }
                else
                {
                    row.SalesUnitCostChngDiv = 0; // �ύX�Ȃ�
                }
            }
            #endregion

            #region ���󒍏��
            if (acptAnOdrRow != null)
            {
                switch (salesUnitPriceInputType)
                {
                    // ���P��(�Ŕ���)
                    case SalesUnitPriceInputType.SalesUnitPrice:
                        {
                            switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    acptAnOdrRow.SalesUnitCost = salesUnitCost;           // �����\��
                                    acptAnOdrRow.SalesUnitCostTaxExc = salesUnitCost;     // ����(�Ŕ�)
                                    acptAnOdrRow.SalesUnitCostTaxInc = salesUnitCost + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // ����(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    acptAnOdrRow.SalesUnitCost = salesUnitCost;           // �����\��
                                    acptAnOdrRow.SalesUnitCostTaxExc = salesUnitCost - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // ����(�Ŕ�)
                                    acptAnOdrRow.SalesUnitCostTaxInc = salesUnitCost;     // ����(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    acptAnOdrRow.SalesUnitCost = salesUnitCost;           // �����\��
                                    acptAnOdrRow.SalesUnitCostTaxExc = salesUnitCost;     // ����(�Ŕ�)
                                    acptAnOdrRow.SalesUnitCostTaxInc = salesUnitCost;     // ����(�ō�)
                                    break;
                            }
                            break;
                        }
                    // ���P��(�ō���)
                    case SalesUnitPriceInputType.SalesUnitTaxPrice:
                        {

                            switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                case CalculateTax.TaxationCode.TaxInc:
                                    acptAnOdrRow.SalesUnitCost = salesUnitCost;           // �����\��
                                    acptAnOdrRow.SalesUnitCostTaxExc = salesUnitCost - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // ����(�Ŕ�)
                                    acptAnOdrRow.SalesUnitCostTaxInc = salesUnitCost;     // ����(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    acptAnOdrRow.SalesUnitCost = salesUnitCost;           // �����\��
                                    acptAnOdrRow.SalesUnitCostTaxExc = salesUnitCost;     // ����(�Ŕ�)
                                    acptAnOdrRow.SalesUnitCostTaxInc = salesUnitCost;     // ����(�ō�)
                                    break;
                            }
                            break;
                        }
                    // ���P��(�\���p)
                    case SalesUnitPriceInputType.SalesUnitPriceDisplay:
                        {

                            switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    acptAnOdrRow.SalesUnitCost = salesUnitCost;           // �����\��
                                    acptAnOdrRow.SalesUnitCostTaxExc = salesUnitCost;     // ����(�Ŕ�)
                                    acptAnOdrRow.SalesUnitCostTaxInc = salesUnitCost + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // ����(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    acptAnOdrRow.SalesUnitCost = salesUnitCost;           // �����\��
                                    acptAnOdrRow.SalesUnitCostTaxExc = salesUnitCost - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesUnitCost);     // ����(�Ŕ�)
                                    acptAnOdrRow.SalesUnitCostTaxInc = salesUnitCost;     // ����(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    acptAnOdrRow.SalesUnitCost = salesUnitCost;           // �����\��
                                    acptAnOdrRow.SalesUnitCostTaxExc = salesUnitCost;     // ����(�Ŕ�)
                                    acptAnOdrRow.SalesUnitCostTaxInc = salesUnitCost;     // ����(�ō�)
                                    break;
                            }

                            //----------------------------------------------------------------------------
                            // �|���Z�o����Ă���ꍇ
                            //----------------------------------------------------------------------------
                            if ((!string.IsNullOrEmpty(acptAnOdrRow.RateDivUnCst)) || (acptAnOdrRow.CostRate != 0))
                            {
                                switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        if (svUnitCostTaxExc != acptAnOdrRow.SalesUnitCost)
                                        {
                                            // �|���Z�o���N���A
                                            this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
                                            acptAnOdrRow.CostRate = 0;
                                        }
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        if (svUnitCostTaxInc != acptAnOdrRow.SalesUnitCost)
                                        {
                                            // �|���Z�o���N���A
                                            this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
                                            acptAnOdrRow.CostRate = 0;
                                        }
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        if (svUnitCostTaxExc != acptAnOdrRow.SalesUnitCost)
                                        {
                                            // �|���Z�o���N���A
                                            this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
                                            acptAnOdrRow.CostRate = 0;
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            break;
                        }
                }

                // ��P��(����P��)�ݒ�
                switch ((UnitPriceCalculation.UnitPrcCalcDiv)acptAnOdrRow.UnPrcCalcCdSalUnPrc)
                {
                    case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                        break;
                    case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                    case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                        acptAnOdrRow.StdUnPrcSalUnPrc = salesUnitCost; // ����i(���P��)
                        break;
                    case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        acptAnOdrRow.StdUnPrcSalUnPrc = 0;
                        break;
                }

                // �����P���ύX�敪�ݒ�
                if (salesUnitCost != acptAnOdrRow.BfUnitCost)
                {
                    acptAnOdrRow.SalesUnitCostChngDiv = 1; // �ύX����
                }
                else
                {
                    acptAnOdrRow.SalesUnitCostChngDiv = 0; // �ύX�Ȃ�
                }
            }
            #endregion
        }

        /// <summary>
        /// �w�肵�����P���̒l�����ɔ��㖾�׍s�I�u�W�F�N�g�̌��P������ݒ肵�܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="salesUnitPriceInputType">���̓��[�h</param>
        /// <param name="salesUnitCost">���P��</param>
        /// <remarks>
        /// <br>Call�F���i�����A���P���^�d���� �ύX��</br>
        /// </remarks>
        public void SalesDetailRowSalesUnitCostSetting(int salesRowNo, SalesUnitPriceInputType salesUnitPriceInputType, double salesUnitCost)
        {
            this.SalesDetailRowSalesUnitCostSetting(salesRowNo, salesUnitPriceInputType, salesUnitCost, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// �w�肵���������̒l�����ɔ��㖾�׍s�I�u�W�F�N�g�̌�������ݒ肵�܂��B
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="costRate">������</param>
        /// <param name="clearCalculateUnitInfoFlg">�|���Z�o���N���A�t���O(true:�N���A���� false:�N���A���Ȃ�)</param>
        /// <remarks>
        /// <br>Call�F�艿�^������ �ύX��</br>
        /// <br>Update Note: 2009/10/19 ���M �ێ�˗��A�@�\�Ή�</br>
        /// </remarks>
        public void SalesDetailRowSalesUnitCostSettingbyRate(int salesRowNo, double costRate, bool clearCalculateUnitInfoFlg)
        {
            double salesUnitCost;
            double SalesUnitCostTaxInc;
            double SalesUnitCostTaxExc;

            #region ��������
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            row.CostRate = costRate;

            if (clearCalculateUnitInfoFlg == true)
            {
                // �|���Z�o���N���A
                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
            }

            // --- UPD 2009/10/19 ---------->>>>>
            if (costRate != 0)
            {
            this.CalclateSalesUnitCost(row, out salesUnitCost, out SalesUnitCostTaxInc, out SalesUnitCostTaxExc);

            row.SalesUnitCost = salesUnitCost;
            row.SalesUnitCostTaxExc = SalesUnitCostTaxExc;
            row.SalesUnitCostTaxInc = SalesUnitCostTaxInc;

            // �����P���ύX�敪�ݒ�
            if (row.SalesUnitCostTaxExc != row.BfUnitCost)
            {
                row.SalesUnitCostChngDiv = 1; // �ύX����
            }
            else
            {
                row.SalesUnitCostChngDiv = 0; // �ύX�Ȃ�
            }
            }
            // --- UPD 2009/10/19 ----------<<<<<
            #endregion

            #region ���󒍏��
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = this._salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);
            if (acptAnOdrRow != null)
            {
                acptAnOdrRow.CostRate = costRate;

                if (clearCalculateUnitInfoFlg == true)
                {
                    // �|���Z�o���N���A
                    this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_UnitCost);
                }

                // --- UPD 2009/10/19 ---------->>>>>
                if (costRate != 0)
                {
                this.CalclateSalesUnitCost(acptAnOdrRow, out salesUnitCost, out SalesUnitCostTaxInc, out SalesUnitCostTaxExc);

                acptAnOdrRow.SalesUnitCost = salesUnitCost;
                acptAnOdrRow.SalesUnitCostTaxExc = SalesUnitCostTaxExc;
                acptAnOdrRow.SalesUnitCostTaxInc = SalesUnitCostTaxInc;

                // �����P���ύX�敪�ݒ�
                if (acptAnOdrRow.SalesUnitCostTaxExc != acptAnOdrRow.BfUnitCost)
                {
                    acptAnOdrRow.SalesUnitCostChngDiv = 1; // �ύX����
                }
                else
                {
                    acptAnOdrRow.SalesUnitCostChngDiv = 0; // �ύX�Ȃ�
                }
            }
                // --- UPD 2009/10/19 ----------<<<<<
            }
            #endregion
        }

        /// <summary>
        /// ���������g�p���Ē艿���猴���������Z�o���܂��B
        /// </summary>
        /// <param name="row">���㖾�׍s�I�u�W�F�N�g</param>
        /// <param name="unitPriceDisplay">���P��(�\��)</param>
        /// <param name="unitPriceTaxInc">���P��(�ō�)</param>
        /// <param name="unitPriceTaxExc">���P��(�Ŕ�)</param>
        private void CalclateSalesUnitCost(SalesInputDataSet.SalesDetailRow row, out double unitCost, out double unitCostTaxInc, out double unitCostTaxExc)
        {
            unitCost = 0;
            unitCostTaxInc = 0;
            unitCostTaxExc = 0;

            // ����Œ[�������R�[�h(�[���Œ�)
            int taxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);

            // ����Œ[�������P�ʁA�敪�擾
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, taxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            CalculateUnitPriceByRate(row, UnitPriceCalculation.UnitPriceKind.UnitCost, out unitCostTaxInc, out unitCostTaxExc, out unitCost);
        }

        /// <summary>
        /// ���������g�p���Ē艿���猴���������Z�o���܂��B�i�󒍏��p�j
        /// </summary>
        /// <param name="row">���㖾�׍s�I�u�W�F�N�g</param>
        /// <param name="unitPriceDisplay">���P��(�\��)</param>
        /// <param name="unitPriceTaxInc">���P��(�ō�)</param>
        /// <param name="unitPriceTaxExc">���P��(�Ŕ�)</param>
        private void CalclateSalesUnitCost(SalesInputDataSet.SalesDetailAcceptAnOrderRow row, out double unitCost, out double unitCostTaxInc, out double unitCostTaxExc)
        {
            SalesInputDataSet.SalesDetailRow newSalesDetailRow = this._salesDetailDataTable.NewSalesDetailRow();
            this.CopySalesDetailFromAcceptAnOrder(row, newSalesDetailRow);
            CalclateSalesUnitCost(newSalesDetailRow, out unitCost, out unitCostTaxInc, out unitCostTaxExc);
        }

        /// <summary>
        /// �w�肵���艿�̒l�����ɔ��㖾�׍s�I�u�W�F�N�g�̒艿����ݒ肵�܂�
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="salesUnitPriceInputType">����P�����̓��[�h</param>
        /// <param name="listPrice">�艿</param>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        /// <br>Update Note: 2010/01/27 ���M �����v�Z�����̕s��Ή�(�S������)</br>
        /// <br>Update Note: 2010/03/22 ���� �W�����i�I���E�C���h�E���A�W�����i��I�������ꍇ�A�艿�ύX�敪(ListPriceChngCd)���u0:�ύX�����v���Z�b�g����</br>
        /// <br>Update Note: 2011/12/28 ������</br>
        /// <br>�Ǘ��ԍ�   : 10707327-00 2012/01/25�z�M��</br>
        /// <br>             Redmine#27385�@����i�̑Ή�</br>
        private void SalesDetailRowListPriceSetting(int salesRowNo, SalesUnitPriceInputType salesUnitPriceInputType, double listPrice, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable sales)
        {
            #region ����������
            SalesInputDataSet.SalesDetailRow row = salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = this._salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);

            // ����Œ[�������R�[�h(�[���Œ�)
            int salesCnsTaxFrcProcCd = 0;

            // ����Œ[�������P�ʁA�敪�擾
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            double svListPriceTaxInc = row.ListPriceTaxIncFl;
            double svListPriceTaxExc = row.ListPriceTaxExcFl;
            #endregion

            #region ��������
            if (row != null)
            {
                switch (salesUnitPriceInputType)
                {
                    // ���P��(�Ŕ���)
                    case SalesUnitPriceInputType.SalesUnitPrice:
                        {
                            switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    row.ListPriceDisplay = listPrice;      // �艿�\��
                                    row.ListPriceTaxExcFl = listPrice;     // �艿(�Ŕ�)
                                    row.ListPriceTaxIncFl = listPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    row.ListPriceDisplay = listPrice;      // �艿�\��
                                    row.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�Ŕ�)
                                    row.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    row.ListPriceDisplay = listPrice;      // �艿�\��
                                    row.ListPriceTaxExcFl = listPrice;     // �艿(�Ŕ�)
                                    row.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                    break;
                            }
                            break;
                        }
                    // ���P��(�ō���)
                    case SalesUnitPriceInputType.SalesUnitTaxPrice:
                        {
                            switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    row.ListPriceDisplay = listPrice;      // �艿�\��
                                    row.ListPriceTaxExcFl = listPrice;     // �艿(�Ŕ�)
                                    row.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    row.ListPriceDisplay = listPrice;      // �艿�\��
                                    row.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�Ŕ�)
                                    row.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    row.ListPriceDisplay = listPrice;      // �艿�\��
                                    row.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�Ŕ�)
                                    row.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                    break;
                            }
                            break;
                        }
                    // ���P��(�\���p)
                    case SalesUnitPriceInputType.SalesUnitPriceDisplay:
                        {

                            if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                //-----------------------------------------------------
                                // ���z�\�����Ȃ�
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.ListPriceTaxExcFl = listPrice;     // �艿(�Ŕ�)
                                        row.ListPriceTaxIncFl = listPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�ō�)
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�Ŕ�)
                                        row.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.ListPriceTaxExcFl = listPrice;     // �艿(�Ŕ�)
                                        row.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                        break;
                                }
                            }
                            else
                            {
                                //-----------------------------------------------------
                                // ���z�\������
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�Ŕ�)
                                        row.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�Ŕ�)
                                        row.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.ListPriceTaxExcFl = listPrice;     // �艿(�Ŕ�)
                                        row.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                        break;
                                }
                            }

                            //----------------------------------------------------------------------------
                            // �|���Z�o����Ă���ꍇ
                            //----------------------------------------------------------------------------
                            if (!(string.IsNullOrEmpty(row.RateDivLPrice)) || (row.ListPriceRate != 0))
                            {
                                if (this._salesSlip.TotalAmountDispWayCd == 0)
                                {
                                    //-----------------------------------------------------
                                    // ���z�\�����Ȃ�
                                    //-----------------------------------------------------
                                    switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                    {
                                        case CalculateTax.TaxationCode.TaxExc:
                                            if (svListPriceTaxExc != row.ListPriceDisplay)
                                            {
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                row.ListPriceRate = 0;
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxInc:
                                            if (svListPriceTaxInc != row.ListPriceDisplay)
                                            {
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                row.ListPriceRate = 0;
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxNone:
                                            if (svListPriceTaxExc != row.ListPriceDisplay)
                                            {
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                row.ListPriceRate = 0;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    //-----------------------------------------------------
                                    // ���z�\������
                                    //-----------------------------------------------------
                                    switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                    {
                                        case CalculateTax.TaxationCode.TaxExc:
                                            if (svListPriceTaxInc != row.ListPriceDisplay)
                                            {
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                row.ListPriceRate = 0;
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxInc:
                                            if (svListPriceTaxInc != row.ListPriceDisplay)
                                            {
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                row.ListPriceRate = 0;
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxNone:
                                            if (svListPriceTaxInc != row.ListPriceDisplay)
                                            {
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                row.ListPriceRate = 0;
                                            }
                                            break;
                                    }
                                }
                            }
                            break;
                        }
                }

                // ��P��(�艿)�ݒ�
                switch ((UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdLPrice)
                {
                    // �|��
                    case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                        row.StdUnPrcLPrice = listPrice;
                        break;
                    // �����t�o��
                    case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                        break;
                    // �e���m�ۗ�
                    case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                        break;
                    // �P�������or��ʎ����
                    case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        row.StdUnPrcLPrice = 0;
                        break;
                }

                // ��P��(����P��)�ݒ�
                switch ((UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdSalUnPrc)
                {
                    // �|��
                    case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                        row.StdUnPrcSalUnPrc = listPrice;
                        break;
                    // �����t�o��
                    case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                        break;
                    // �e���m�ۗ�
                    case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                        break;
                    // �P�������or��ʎ����
                    case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        row.StdUnPrcSalUnPrc = 0;
                        break;
                }

                // ��P��(�����P��)�ݒ�
                if (row.SelectedListPriceDiv == 0) //ADD BY ������ on 2011/12/28 for Redmine#27385
                {///ADD BY ������ on 2011/12/28 for Redmine#27385
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)row.UnPrcCalcCdUnCst)
                    {
                        // �|��
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            row.StdUnPrcUnCst = listPrice;
                            break;
                        // �����t�o��
                        case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                            break;
                        // �e���m�ۗ�
                        case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                            break;
                        // �P�������or��ʎ����
                        case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                            row.StdUnPrcUnCst = 0;
                            break;
                    }
                }//ADD BY ������ on 2011/12/28 for Redmine#27385

                // --- UPD 2010/03/22 ---------->>>>>
                // �W�����i�I���E�C���h�E���A�W�����i��I�������ꍇ�A�艿�ύX�敪(ListPriceChngCd)���u0:�ύX�����v���Z�b�g����
                if (row.SelectedListPriceDiv == 1)
                {
                    //// �艿�ύX�敪�ݒ�
                    //if (row.ListPriceTaxExcFl != row.BfListPrice)
                    //{
                    //    row.ListPriceChngCd = 1; // �ύX����
                    //}
                    //else
                    //{
                    //    row.ListPriceChngCd = 0; // �ύX�Ȃ�
                    //} 
                    row.ListPriceChngCd = 0; // �ύX�Ȃ�
                }
                // --- UPD 2010/03/22 ----------<<<<<

            }
            #endregion

            #region ���󒍏��
            if (acptAnOdrRow != null)
            {
                switch (salesUnitPriceInputType)
                {
                    // ���P��(�Ŕ���)
                    case SalesUnitPriceInputType.SalesUnitPrice:
                        {
                            switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    acptAnOdrRow.ListPriceDisplay = listPrice;      // �艿�\��
                                    acptAnOdrRow.ListPriceTaxExcFl = listPrice;     // �艿(�Ŕ�)
                                    acptAnOdrRow.ListPriceTaxIncFl = listPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    acptAnOdrRow.ListPriceDisplay = listPrice;      // �艿�\��
                                    acptAnOdrRow.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�Ŕ�)
                                    acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    acptAnOdrRow.ListPriceDisplay = listPrice;      // �艿�\��
                                    acptAnOdrRow.ListPriceTaxExcFl = listPrice;     // �艿(�Ŕ�)
                                    acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                    break;
                            }
                            break;
                        }
                    // ���P��(�ō���)
                    case SalesUnitPriceInputType.SalesUnitTaxPrice:
                        {
                            switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                            {
                                case CalculateTax.TaxationCode.TaxExc:
                                    acptAnOdrRow.ListPriceDisplay = listPrice;      // �艿�\��
                                    acptAnOdrRow.ListPriceTaxExcFl = listPrice;     // �艿(�Ŕ�)
                                    acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxInc:
                                    acptAnOdrRow.ListPriceDisplay = listPrice;      // �艿�\��
                                    acptAnOdrRow.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�Ŕ�)
                                    acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                    break;
                                case CalculateTax.TaxationCode.TaxNone:
                                    acptAnOdrRow.ListPriceDisplay = listPrice;      // �艿�\��
                                    acptAnOdrRow.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�Ŕ�)
                                    acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                    break;
                            }
                            break;
                        }
                    // ���P��(�\���p)
                    case SalesUnitPriceInputType.SalesUnitPriceDisplay:
                        {

                            if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                //-----------------------------------------------------
                                // ���z�\�����Ȃ�
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        acptAnOdrRow.ListPriceTaxExcFl = listPrice;     // �艿(�Ŕ�)
                                        acptAnOdrRow.ListPriceTaxIncFl = listPrice + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�ō�)
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        acptAnOdrRow.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�Ŕ�)
                                        acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        acptAnOdrRow.ListPriceTaxExcFl = listPrice;     // �艿(�Ŕ�)
                                        acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                        break;
                                }
                            }
                            else
                            {
                                //-----------------------------------------------------
                                // ���z�\������
                                //-----------------------------------------------------
                                switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        acptAnOdrRow.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�Ŕ�)
                                        acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        acptAnOdrRow.ListPriceTaxExcFl = listPrice - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPrice);     // �艿(�Ŕ�)
                                        acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        acptAnOdrRow.ListPriceTaxExcFl = listPrice;     // �艿(�Ŕ�)
                                        acptAnOdrRow.ListPriceTaxIncFl = listPrice;     // �艿(�ō�)
                                        break;
                                }
                            }

                            //----------------------------------------------------------------------------
                            // �|���Z�o����Ă���ꍇ
                            //----------------------------------------------------------------------------
                            if (!(string.IsNullOrEmpty(acptAnOdrRow.RateDivLPrice)) || (acptAnOdrRow.ListPriceRate != 0))
                            {
                                if (this._salesSlip.TotalAmountDispWayCd == 0)
                                {
                                    //-----------------------------------------------------
                                    // ���z�\�����Ȃ�
                                    //-----------------------------------------------------
                                    switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                                    {
                                        case CalculateTax.TaxationCode.TaxExc:
                                            //>>>2011/10/29
                                            //if (svListPriceTaxExc != acptAnOdrRow.ListPriceDisplay)
                                            if (svListPriceTaxExc != row.ListPriceDisplay)
                                            //<<<2011/10/29
                                            {
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                acptAnOdrRow.ListPriceRate = 0;
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxInc:
                                            //>>>2011/10/29
                                            //if (svListPriceTaxInc != acptAnOdrRow.ListPriceDisplay)
                                            if (svListPriceTaxInc != row.ListPriceDisplay)
                                            //<<<2011/10/29
                                            {
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                acptAnOdrRow.ListPriceRate = 0;
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxNone:
                                            //>>>2011/10/29
                                            //if (svListPriceTaxExc != acptAnOdrRow.ListPriceDisplay)
                                            if (svListPriceTaxExc != row.ListPriceDisplay)
                                            //<<<2011/10/29
                                            {
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                acptAnOdrRow.ListPriceRate = 0;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                else
                                {
                                    //-----------------------------------------------------
                                    // ���z�\������
                                    //-----------------------------------------------------
                                    switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                                    {
                                        case CalculateTax.TaxationCode.TaxExc:
                                            //>>>2011/10/29
                                            //if (svListPriceTaxInc != acptAnOdrRow.ListPriceDisplay)
                                            if (svListPriceTaxInc != row.ListPriceDisplay)
                                            //<<<2011/10/29
                                            {
                                                // �|���Z�o���N���A
                                                acptAnOdrRow.ListPriceRate = 0;
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxInc:
                                            //>>>2011/10/29
                                            //if (svListPriceTaxInc != acptAnOdrRow.ListPriceDisplay)
                                            if (svListPriceTaxInc != row.ListPriceDisplay)
                                            //<<<2011/10/29
                                            {
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                acptAnOdrRow.ListPriceRate = 0;
                                            }
                                            break;
                                        case CalculateTax.TaxationCode.TaxNone:
                                            //>>>2011/10/29
                                            //if (svListPriceTaxInc != acptAnOdrRow.ListPriceDisplay)
                                            if (svListPriceTaxInc != row.ListPriceDisplay)
                                            //<<<2011/10/29
                                            {
                                                // �|���Z�o���N���A
                                                this.ClearRateInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_ListPrice);
                                                acptAnOdrRow.ListPriceRate = 0;
                                            }
                                            break;
                                    }
                                }
                            }
                            break;
                        }
                }

                // ��P��(�艿)�ݒ�
                switch ((UnitPriceCalculation.UnitPrcCalcDiv)acptAnOdrRow.UnPrcCalcCdLPrice)
                {
                    // �|��
                    case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                        acptAnOdrRow.StdUnPrcLPrice = listPrice;
                        break;
                    // �����t�o��
                    case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                        break;
                    // �e���m�ۗ�
                    case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                        break;
                    // �P�������or��ʎ����
                    case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        acptAnOdrRow.StdUnPrcLPrice = 0;
                        break;
                }

                // ��P��(����P��)�ݒ�
                switch ((UnitPriceCalculation.UnitPrcCalcDiv)acptAnOdrRow.UnPrcCalcCdSalUnPrc)
                {
                    // �|��
                    case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                        acptAnOdrRow.StdUnPrcSalUnPrc = listPrice;
                        break;
                    // �����t�o��
                    case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                        break;
                    // �e���m�ۗ�
                    case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                        break;
                    // �P�������or��ʎ����
                    case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                        acptAnOdrRow.StdUnPrcSalUnPrc = 0;
                        break;
                }

                // ��P��(�����P��)�ݒ�
                if (row.SelectedListPriceDiv == 0) //ADD BY ������ on 2011/12/28 for Redmine#27385
                { //ADD BY ������ on 2011/12/28 for Redmine#27385
                    switch ((UnitPriceCalculation.UnitPrcCalcDiv)acptAnOdrRow.UnPrcCalcCdUnCst)
                    {
                        // �|��
                        case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                            acptAnOdrRow.StdUnPrcUnCst = listPrice;
                            break;
                        // �����t�o��
                        case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                            break;
                        // �e���m�ۗ�
                        case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                            break;
                        // �P�������or��ʎ����
                        case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                            acptAnOdrRow.StdUnPrcUnCst = 0;
                            break;
                    }
                } //ADD BY ������ on 2011/12/28 for Redmine#27385
                // �艿�ύX�敪�ݒ�
                if (acptAnOdrRow.ListPriceTaxExcFl != acptAnOdrRow.BfListPrice)
                {
                    acptAnOdrRow.ListPriceChngCd = 1; // �ύX����
                }
                else
                {
                    acptAnOdrRow.ListPriceChngCd = 0; // �ύX�Ȃ�
                }

            }
            #endregion
        }

        /// <summary>
        /// �w�肵���艿�̒l�����ɔ��㖾�׍s�I�u�W�F�N�g�̒艿����ݒ肵�܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="salesUnitPriceInputType">����P�����̓��[�h</param>
        /// <param name="listPrice">�艿</param>
        public void SalesDetailRowListPriceSetting(int salesRowNo, SalesUnitPriceInputType salesUnitPriceInputType, double listPrice)
        {
            this.SalesDetailRowListPriceSetting(salesRowNo, salesUnitPriceInputType, listPrice, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// ���㍇�v���z�ݒ菈��
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        public void TotalPriceSetting(ref SalesSlip salesSlip)
        {
            this.TotalPriceSetting(ref salesSlip, this._salesDetailDataTable);
        }

        /// <summary>
        /// ���㍇�v���z�ݒ菈��
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u��</param>
        public void TotalPriceSetting(ref SalesSlip salesSlip, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable)
        {
            if (salesSlip == null) return;
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// ����Œ[�������R�[�h

            long salesTotalTaxInc = 0;      // ����`�[���v�i�ō��j
            long salesTotalTaxExc = 0;      // ����`�[���v�i�Ŕ��j
            long salesSubtotalTax = 0;      // ���㏬�v�i�Łj
            long itdedSalesOutTax = 0;      // ����O�őΏۊz
            long itdedSalesInTax = 0;       // ������őΏۊz
            long salSubttlSubToTaxFre = 0;  // ���㏬�v��ېőΏۊz
            long salesOutTax = 0;           // ������z����Ŋz�i�O�Łj
            long salAmntConsTaxInclu = 0;   // ������z����Ŋz�i���Łj
            long salesDisTtlTaxExc = 0;     // ����l�����z�v�i�Ŕ��j
            long itdedSalesDisOutTax = 0;   // ����l���O�őΏۊz���v
            long itdedSalesDisInTax = 0;    // ����l�����őΏۊz���v
            long itdedSalesDisTaxFre = 0;   // ����l����ېőΏۊz���v
            long salesDisOutTax = 0;        // ����l������Ŋz�i�O�Łj
            long salesDisTtlTaxInclu = 0;   // ����l������Ŋz�i���Łj
            long totalCost = 0;             // �������z�v
            long stockGoodsTtlTaxExc = 0;   // �݌ɏ��i���v���z�i�Ŕ��j
            long pureGoodsTtlTaxExc = 0;    // �������i���v���z�i�Ŕ��j
            long taxAdjust = 0;             // ����Œ����z
            long balanceAdjust = 0;         // �c�������z
            long salesPrtTotalTaxInc = 0;   // ���㕔�i���v�i�ō��j
            long salesPrtTotalTaxExc = 0;   // ���㕔�i���v�i�Ŕ��j
            long salesPrtSubttlInc = 0;     // ���㕔�i���v�i�ō��j
            long salesPrtSubttlExc = 0;     // ���㕔�i���v�i�Ŕ��j
            long salesWorkSubttlInc = 0;    // �����Ə��v�i�ō��j
            long salesWorkSubttlExc = 0;    // �����Ə��v�i�Ŕ��j
            long itdedPartsDisInTax = 0;    // ���i�l���Ώۊz���v�i�ō��j
            long itdedPartsDisOutTax = 0;   // ���i�l���Ώۊz���v�i�Ŕ��j
            long itdedWorkDisInTax = 0;     // ��ƒl���Ώۊz���v�i�ō��j
            long itdedWorkDisOutTax = 0;    // ��ƒl���Ώۊz���v�i�Ŕ��j
            long totalMoneyForGrossProfit = 0; // �e���v�Z�p������z

            this.CalculationSalesTotalPrice(
                salesDetailDataTable,
                salesSlip.ConsTaxRate,
                salesTaxFrcProcCd,
                salesSlip.TotalAmountDispWayCd,
                salesSlip.ConsTaxLayMethod,
                out salesTotalTaxInc,
                out salesTotalTaxExc,
                out salesSubtotalTax,
                out itdedSalesOutTax,
                out itdedSalesInTax,
                out salSubttlSubToTaxFre,
                out salesOutTax,
                out salAmntConsTaxInclu,
                out salesDisTtlTaxExc,
                out itdedSalesDisOutTax,
                out itdedSalesDisInTax,
                out itdedSalesDisTaxFre,
                out salesDisOutTax,
                out salesDisTtlTaxInclu,
                out totalCost,
                out stockGoodsTtlTaxExc,
                out pureGoodsTtlTaxExc,
                out balanceAdjust,
                out taxAdjust,
                out salesPrtSubttlInc,
                out salesPrtSubttlExc,
                out salesWorkSubttlInc,
                out salesWorkSubttlExc,
                out itdedPartsDisInTax,
                out itdedPartsDisOutTax,
                out itdedWorkDisInTax,
                out itdedWorkDisOutTax,
                out totalMoneyForGrossProfit,
                out salesPrtTotalTaxInc,
                out salesPrtTotalTaxExc);

            switch ((SalesGoodsCd)salesSlip.SalesGoodsCd)
            {
                case SalesGoodsCd.ConsTaxAdjust:
                case SalesGoodsCd.AccRecConsTaxAdjust:
                    {

                        salesSlip.SalesSubtotalTaxInc = 0;              // ���㏬�v�i�ō��j
                        salesSlip.SalesSubtotalTaxExc = 0;              // ���㏬�v�i�Ŕ��j
                        salesSlip.SalesSubtotalTax = taxAdjust;         // ���㏬�v�i�Łj
                        salesSlip.ItdedSalesOutTax = 0;                 // ����O�őΏۊz
                        salesSlip.ItdedSalesInTax = 0;                  // ������őΏۊz
                        salesSlip.SalSubttlSubToTaxFre = 0;             // ���㏬�v��ېőΏۊz
                        salesSlip.SalesOutTax = 0;                      // ������z����Ŋz�i�O�Łj
                        salesSlip.SalAmntConsTaxInclu = 0;              // ������z����Ŋz�i���Łj
                        salesSlip.SalesDisTtlTaxExc = 0;                // ����l�����z�v�i�Ŕ��j
                        salesSlip.ItdedSalesDisOutTax = 0;              // ����l���O�őΏۊz���v
                        salesSlip.ItdedSalesDisInTax = 0;               // ����l�����őΏۊz���v
                        salesSlip.ItdedSalesDisTaxFre = 0;              // ����l����ېőΏۊz���v
                        salesSlip.SalesDisOutTax = 0;                   // ����l������Ŋz�i�O�Łj
                        salesSlip.SalesDisTtlTaxInclu = 0;              // ����l������Ŋz�i���Łj
                        salesSlip.TotalCost = 0;                        // �������z�v
                        salesSlip.StockGoodsTtlTaxExc = 0;              // �݌ɏ��i���v���z�i�Ŕ��j
                        salesSlip.PureGoodsTtlTaxExc = 0;               // �������i���v���z�i�Ŕ��j
                        salesSlip.SalesPrtSubttlInc = 0;                // ���㕔�i���v�i�ō��j
                        salesSlip.SalesPrtSubttlExc = 0;                // ���㕔�i���v�i�Ŕ��j
                        salesSlip.SalesWorkSubttlInc = 0;               // �����Ə��v�i�ō��j
                        salesSlip.SalesWorkSubttlExc = 0;               // �����Ə��v�i�Ŕ��j
                        salesSlip.ItdedPartsDisInTax = 0;               // ���i�l���Ώۊz���v�i�ō��j
                        salesSlip.ItdedPartsDisOutTax = 0;              // ���i�l���Ώۊz���v�i�Ŕ��j
                        salesSlip.ItdedWorkDisInTax = 0;                // ��ƒl���Ώۊz���v�i�ō��j
                        salesSlip.ItdedWorkDisOutTax = 0;               // ��ƒl���Ώۊz���v�i�Ŕ��j
                        salesSlip.TotalMoneyForGrossProfit = 0;         // �e���v�Z�p������z

                        salesSlip.SalesTotalTaxInc = 0;                 // ����`�[���v�i�ō��j
                        salesSlip.SalesTotalTaxExc = 0;                 // ����`�[���v�i�Ŕ��j
                        salesSlip.SalesNetPrice = 0;                    // ���㐳�����z
                        salesSlip.AccRecConsTax = 0;                    // ���|�����
                        salesSlip.PartsDiscountRate = 0;                // ���i�l����
                        break;
                    }
                case SalesGoodsCd.BalanceAdjust:
                case SalesGoodsCd.AccRecBalanceAdjust:
                    {
                        salesSlip.SalesSubtotalTaxInc = 0;              // ���㏬�v�i�ō��j
                        salesSlip.SalesSubtotalTaxExc = 0;              // ���㏬�v�i�Ŕ��j
                        salesSlip.SalesSubtotalTax = 0;                 // ���㏬�v�i�Łj
                        salesSlip.ItdedSalesOutTax = 0;                 // ����O�őΏۊz
                        salesSlip.ItdedSalesInTax = 0;                  // ������őΏۊz
                        salesSlip.SalSubttlSubToTaxFre = 0;             // ���㏬�v��ېőΏۊz
                        salesSlip.SalesOutTax = 0;                      // ������z����Ŋz�i�O�Łj
                        salesSlip.SalAmntConsTaxInclu = 0;              // ������z����Ŋz�i���Łj
                        salesSlip.SalesDisTtlTaxExc = 0;                // ����l�����z�v�i�Ŕ��j
                        salesSlip.ItdedSalesDisOutTax = 0;              // ����l���O�őΏۊz���v
                        salesSlip.ItdedSalesDisInTax = 0;               // ����l�����őΏۊz���v
                        salesSlip.ItdedSalesDisTaxFre = 0;              // ����l����ېőΏۊz���v
                        salesSlip.SalesDisOutTax = 0;                   // ����l������Ŋz�i�O�Łj
                        salesSlip.SalesDisTtlTaxInclu = 0;              // ����l������Ŋz�i���Łj
                        salesSlip.TotalCost = 0;                        // �������z�v
                        salesSlip.StockGoodsTtlTaxExc = 0;              // �݌ɏ��i���v���z�i�Ŕ��j
                        salesSlip.PureGoodsTtlTaxExc = 0;               // �������i���v���z�i�Ŕ��j
                        salesSlip.SalesPrtSubttlInc = 0;                // ���㕔�i���v�i�ō��j
                        salesSlip.SalesPrtSubttlExc = 0;                // ���㕔�i���v�i�Ŕ��j
                        salesSlip.SalesWorkSubttlInc = 0;               // �����Ə��v�i�ō��j
                        salesSlip.SalesWorkSubttlExc = 0;               // �����Ə��v�i�Ŕ��j
                        salesSlip.ItdedPartsDisInTax = 0;               // ���i�l���Ώۊz���v�i�ō��j
                        salesSlip.ItdedPartsDisOutTax = 0;              // ���i�l���Ώۊz���v�i�Ŕ��j
                        salesSlip.ItdedWorkDisInTax = 0;                // ��ƒl���Ώۊz���v�i�ō��j
                        salesSlip.ItdedWorkDisOutTax = 0;               // ��ƒl���Ώۊz���v�i�Ŕ��j
                        salesSlip.TotalMoneyForGrossProfit = 0;         // �e���v�Z�p������z

                        salesSlip.SalesTotalTaxInc = balanceAdjust;     // ����`�[���v�i�ō��j
                        salesSlip.SalesTotalTaxExc = 0;                 // ����`�[���v�i�Ŕ��j
                        salesSlip.SalesNetPrice = 0;                    // ���㐳�����z
                        salesSlip.AccRecConsTax = 0;                    // ���|�����
                        salesSlip.PartsDiscountRate = 0;                // ���i�l����
                        break;
                    }
                case SalesGoodsCd.Goods:
                    {
                        salesSlip.SalesSubtotalTaxInc = salesTotalTaxInc;       // ���㏬�v�i�ō��j
                        salesSlip.SalesSubtotalTaxExc = salesTotalTaxExc;       // ���㏬�v�i�Ŕ��j
                        salesSlip.SalesSubtotalTax = salesSubtotalTax;          // ���㏬�v�i�Łj
                        salesSlip.ItdedSalesOutTax = itdedSalesOutTax;          // ����O�őΏۊz
                        salesSlip.ItdedSalesInTax = itdedSalesInTax;            // ������őΏۊz
                        salesSlip.SalSubttlSubToTaxFre = salSubttlSubToTaxFre;  // ���㏬�v��ېőΏۊz
                        salesSlip.SalesOutTax = salesOutTax;                    // ������z����Ŋz�i�O�Łj
                        salesSlip.SalAmntConsTaxInclu = salAmntConsTaxInclu;    // ������z����Ŋz�i���Łj
                        salesSlip.SalesDisTtlTaxExc = salesDisTtlTaxExc;        // ����l�����z�v�i�Ŕ��j
                        salesSlip.ItdedSalesDisOutTax = itdedSalesDisOutTax;    // ����l���O�őΏۊz���v
                        salesSlip.ItdedSalesDisInTax = itdedSalesDisInTax;      // ����l�����őΏۊz���v
                        salesSlip.ItdedSalesDisTaxFre = itdedSalesDisTaxFre;    // ����l����ېőΏۊz���v
                        salesSlip.SalesDisOutTax = salesDisOutTax;              // ����l������Ŋz�i�O�Łj
                        salesSlip.SalesDisTtlTaxInclu = salesDisTtlTaxInclu;    // ����l������Ŋz�i���Łj
                        salesSlip.TotalCost = totalCost;                        // �������z�v
                        salesSlip.StockGoodsTtlTaxExc = stockGoodsTtlTaxExc;    // �݌ɏ��i���v���z�i�Ŕ��j
                        salesSlip.PureGoodsTtlTaxExc = pureGoodsTtlTaxExc;      // �������i���v���z�i�Ŕ��j
                        salesSlip.SalesPrtSubttlInc = salesPrtSubttlInc;                // ���㕔�i���v�i�ō��j
                        salesSlip.SalesPrtSubttlExc = salesPrtSubttlExc;                // ���㕔�i���v�i�Ŕ��j
                        salesSlip.SalesWorkSubttlInc = salesWorkSubttlInc;              // �����Ə��v�i�ō��j
                        salesSlip.SalesWorkSubttlExc = salesWorkSubttlExc;              // �����Ə��v�i�Ŕ��j
                        salesSlip.ItdedPartsDisInTax = itdedPartsDisInTax;              // ���i�l���Ώۊz���v�i�ō��j
                        salesSlip.ItdedPartsDisOutTax = itdedPartsDisOutTax;            // ���i�l���Ώۊz���v�i�Ŕ��j
                        salesSlip.ItdedWorkDisInTax = itdedWorkDisInTax;                // ��ƒl���Ώۊz���v�i�ō��j
                        salesSlip.ItdedWorkDisOutTax = itdedWorkDisOutTax;              // ��ƒl���Ώۊz���v�i�Ŕ��j
                        salesSlip.TotalMoneyForGrossProfit = totalMoneyForGrossProfit;  // �e���v�Z�p������z

                        salesSlip.SalesTotalTaxInc = salesTotalTaxInc + salSubttlSubToTaxFre;                   // ����`�[���v�i�ō��j= ����`�[���v�i�ō��j + ���㏬�v��ېőΏۊz
                        salesSlip.SalesTotalTaxExc = salesTotalTaxExc + salSubttlSubToTaxFre;                   // ����`�[���v�i�Ŕ��j= ����`�[���v�i�Ŕ��j + ���㏬�v��ېőΏۊz
                        salesSlip.SalesNetPrice = itdedSalesOutTax + itdedSalesInTax + salSubttlSubToTaxFre;    // ���㐳�����z = ����O�őΏۊz + ������őΏۊz + ���㏬�v��ېőΏۊz
                        salesSlip.AccRecConsTax = salesSubtotalTax;                                             // ���|�����
                        salesSlip.SalesPrtTotalTaxInc = salesPrtTotalTaxInc;                                    // ���㕔�i���v�i�ō��j
                        salesSlip.SalesPrtTotalTaxExc = salesPrtTotalTaxExc;                                    // ���㕔�i���v�i�Ŕ��j
                        salesSlip.SalesWorkTotalTaxInc = salesWorkSubttlInc + itdedWorkDisInTax;                // �����ƍ��v�i�ō��j
                        salesSlip.SalesWorkTotalTaxExc = salesWorkSubttlExc + itdedWorkDisOutTax;               // �����ƍ��v�i�Ŕ��j
                        double rate;
                        this.GetRate(itdedPartsDisOutTax, salesPrtSubttlExc, out rate);
                        salesSlip.PartsDiscountRate = rate;                                                     // ���i�l����
                        break;
                    }
            }
        }

        /// <summary>
        /// ������z�̍��v���v�Z���܂��B
        /// </summary>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u��</param>
        /// <param name="consTaxRate">����Őŗ�</param>
        /// <param name="salesTaxFrcProcCd">����Œ[�������R�[�h</param>
        /// <param name="totalAmountDispWayCd">���z�\�����@�敪</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���</param>
        /// <param name="salesTotalTaxInc">����`�[���v�i�ō��j</param>
        /// <param name="salesTotalTaxExc">����`�[���v�i�Ŕ��j</param>
        /// <param name="salesSubtotalTax">���㏬�v�i�Łj</param>
        /// <param name="itdedSalesOutTax">����O�őΏۊz</param>
        /// <param name="itdedSalesInTax">������őΏۊz</param>
        /// <param name="salSubttlSubToTaxFre">���㏬�v��ېőΏۊz</param>
        /// <param name="salesOutTax">������z����Ŋz�i�O�Łj</param>
        /// <param name="salAmntConsTaxInclu">������z����Ŋz�i���Łj</param>
        /// <param name="salesDisTtlTaxExc">����l�����z�v�i�Ŕ��j</param>
        /// <param name="itdedSalesDisOutTax">����l���O�őΏۊz���v</param>
        /// <param name="itdedSalesDisInTax">����l�����őΏۊz���v</param>
        /// <param name="itdedSalesDisTaxFre">����l����ېőΏۊz���v</param>
        /// <param name="salesDisOutTax">����l������Ŋz�i�O�Łj</param>
        /// <param name="salesDisTtlTaxInclu">����l������Ŋz�i���Łj</param>
        /// <param name="totalCost">�������z�v</param>
        /// <param name="StockGoodsTtlTaxExc">�݌ɏ��i���v���z(�Ŕ�)</param>
        /// <param name="PureGoodsTtlTaxExc">�������i���v���z(�Ŕ�)</param>
        /// <param name="balanceAdjust">����Œ����z</param>
        /// <param name="taxAdjust">�c�������z</param>
        /// <param name="salesPrtSubttlInc">���㕔�i���v�i�ō��j</param>
        /// <param name="salesPrtSubttlExc">���㕔�i���v�i�Ŕ��j</param>
        /// <param name="salesWorkSubttlInc">�����Ə��v�i�ō��j</param>
        /// <param name="salesWorkSubttlExc">�����Ə��v�i�Ŕ��j</param>
        /// <param name="itdedPartsDisInTax">���i�l���Ώۊz���v�i�ō��j</param>
        /// <param name="itdedPartsDisOutTax">���i�l���Ώۊz���v�i�Ŕ��j</param>
        /// <param name="itdedWorkDisInTax">��ƒl���Ώۊz���v�i�ō��j</param>
        /// <param name="itdedWorkDisOutTax">��ƒl���Ώۊz���v�i�Ŕ��j</param>
        /// <param name="totalMoneyForGrossProfit">�e���v�Z�p������z</param>
        /// <param name="salesPrtTotalTaxInc">���㕔�i���v�i�ō��j</param>
        /// <param name="salesPrtTotalTaxExc">���㕔�i���v�i�Ŕ��j</param>
        /// <br>Update Note: 2013/12/19 ��</br>
        /// <br>             Redmine#41550 ����`�[���͏����8%���őΉ��B</br> 
        /// <br>Update Note: 2014/01/23 ��</br>
        /// <br>             Redmine#41771 ����`�[���͏����8%���őΉ��B</br> 
        public void CalculationSalesTotalPrice(SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, double consTaxRate, int salesTaxFrcProcCd, int totalAmountDispWayCd, int consTaxLayMethod, out long salesTotalTaxInc, out long salesTotalTaxExc, out long salesSubtotalTax, out long itdedSalesOutTax, out long itdedSalesInTax, out long salSubttlSubToTaxFre, out long salesOutTax, out long salAmntConsTaxInclu, out long salesDisTtlTaxExc, out long itdedSalesDisOutTax, out long itdedSalesDisInTax, out long itdedSalesDisTaxFre, out long salesDisOutTax, out long salesDisTtlTaxInclu, out long totalCost, out long stockGoodsTtlTaxExc, out long pureGoodsTtlTaxExc, out long balanceAdjust, out long taxAdjust, out long salesPrtSubttlInc, out long salesPrtSubttlExc, out long salesWorkSubttlInc, out long salesWorkSubttlExc, out long itdedPartsDisInTax, out long itdedPartsDisOutTax, out long itdedWorkDisInTax, out long itdedWorkDisOutTax, out long totalMoneyForGrossProfit, out long salesPrtTotalTaxInc, out long salesPrtTotalTaxExc)
        {
            #region ����������
            //-----------------------------------------------------------------------------
            // ��������
            //-----------------------------------------------------------------------------
            // ����Œ[�������P�ʁA�[�������敪���擾
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            // �f�[�^�e�[�u���̕ύX���R�~�b�g������
            salesDetailDataTable.AcceptChanges();

            salesTotalTaxInc = 0;           // ����`�[���v�i�ō��j
            salesTotalTaxExc = 0;           // ����`�[���v�i�Ŕ��j
            salesSubtotalTax = 0;           // ���㏬�v�i�Łj
            itdedSalesOutTax = 0;           // ����O�őΏۊz
            itdedSalesInTax = 0;            // ������őΏۊz
            salSubttlSubToTaxFre = 0;       // ���㏬�v��ېőΏۊz
            salesOutTax = 0;                // ������z����Ŋz�i�O�Łj
            salAmntConsTaxInclu = 0;        // ������z����Ŋz�i���Łj
            salesDisTtlTaxExc = 0;          // ����l�����z�v�i�Ŕ��j
            itdedSalesDisOutTax = 0;        // ����l���O�őΏۊz���v
            itdedSalesDisInTax = 0;         // ����l�����őΏۊz���v
            itdedSalesDisTaxFre = 0;        // ����l����ېőΏۊz���v
            salesDisOutTax = 0;             // ����l������Ŋz�i�O�Łj
            salesDisTtlTaxInclu = 0;        // ����l������Ŋz�i���Łj
            stockGoodsTtlTaxExc = 0;        // �݌ɏ��i���v���z�i�Ŕ��j
            pureGoodsTtlTaxExc = 0;         // �������i���v���z�i�Ŕ��j
            totalCost = 0;                  // �������z�v
            taxAdjust = 0;                  // ����Œ����z
            balanceAdjust = 0;              // �c�������z
            salesPrtTotalTaxInc = 0;        // ���㕔�i���v�i�ō��j
            salesPrtTotalTaxExc = 0;        // ���㕔�i���v�i�Ŕ��j
            salesPrtSubttlInc = 0;          // ���㕔�i���v�i�ō��j
            salesPrtSubttlExc = 0;          // ���㕔�i���v�i�Ŕ��j
            salesWorkSubttlInc = 0;         // �����Ə��v�i�ō��j
            salesWorkSubttlExc = 0;         // �����Ə��v�i�Ŕ��j
            itdedPartsDisInTax = 0;         // ���i�l���Ώۊz���v�i�ō��j
            itdedPartsDisOutTax = 0;        // ���i�l���Ώۊz���v�i�Ŕ��j
            itdedWorkDisInTax = 0;          // ��ƒl���Ώۊz���v�i�ō��j
            itdedWorkDisOutTax = 0;         // ��ƒl���Ώۊz���v�i�Ŕ��j
            totalMoneyForGrossProfit = 0;   // �e���v�Z�p������z
            
            object value = null;
            #endregion

            #region ���v�Z�ɕK�v�ȋ��z�̌v�Z
            //-----------------------------------------------------------------------------
            // �v�Z�ɕK�v�ȋ��z�̌v�Z
            //-----------------------------------------------------------------------------
            // ����O�őΏۊz
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})", 
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc, 
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            itdedSalesOutTax = (value is System.DBNull) ? 0 : (long)value;

            // ������z����Ŋz�i�O�Łj
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salesOutTax = (value is System.DBNull) ? 0 : (long)value;

            // ������őΏۊz
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            itdedSalesInTax = (value is System.DBNull) ? 0 : (long)value;

            // ������őΏۊz�i�ō��j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            long itdedSalesInTax_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // ������z����Ŋz�i���Łj
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salAmntConsTaxInclu = (value is System.DBNull) ? 0 : (long)value;

            // ���㏬�v��ېőΏۊz
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salSubttlSubToTaxFre = (value is System.DBNull) ? 0 : (long)value;

            // ����l���O�őΏۊz���v
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}", 
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc, 
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedSalesDisOutTax = (value is System.DBNull) ? 0 : (long)value;

            // ����l������Ŋz�i�O�Łj
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            salesDisOutTax = (value is System.DBNull) ? 0 : (long)value;

            // ����l�����őΏۊz���v
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedSalesDisInTax = (value is System.DBNull) ? 0 : (long)value;

            // ����l�����őΏۊz���v�i�ō��j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            long itdedSalesDisInTax_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // ����l������Ŋz�i���Łj
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            salesDisTtlTaxInclu = (value is System.DBNull) ? 0 : (long)value;

            // ����l����ېőΏۊz���v
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedSalesDisTaxFre = (value is System.DBNull) ? 0 : (long)value;

            // ����l�����z�v�i�Ŕ��j
            salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

            // �c�������z
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} OR {2}={3}",
                    salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.BalanceAdjust, 
                    salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.AccRecBalanceAdjust));
            balanceAdjust = (value is System.DBNull) ? 0 : (long)value;

            // ����Œ����z
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} OR {2}={3}",
                    salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.ConsTaxAdjust, 
                    salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.AccRecConsTaxAdjust));
            taxAdjust = (value is System.DBNull) ? 0 : (long)value;

            // �������z�v�i���ŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.CostTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}", 
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalCost_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // �������z�v�i�O�ŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.CostTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalCost_TaxExc = (value is System.DBNull) ? 0 : (long)value;

            // �������z�v�i��ېŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.CostTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalCost_TaxNone = (value is System.DBNull) ? 0 : (long)value;

            // �������z�v
            totalCost = totalCost_TaxInc + totalCost_TaxExc + totalCost_TaxNone;

            // �e���v�Z�p������z�v�i���ŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalMoney_TaxInc_ForGrossProfitMoney = (value is System.DBNull) ? 0 : (long)value;

            // �e���v�Z�p������z�v�i�O�ŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalMoney_TaxExc_ForGrossProfitMoney = (value is System.DBNull) ? 0 : (long)value;

            // �e���v�Z�p������z�v�i��ېŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalMoney_TaxNone_ForGrossProfitMoney = (value is System.DBNull) ? 0 : (long)value;

            // �e���v�Z�p������z�v
            totalMoneyForGrossProfit = totalMoney_TaxExc_ForGrossProfitMoney + totalMoney_TaxInc_ForGrossProfitMoney + totalMoney_TaxNone_ForGrossProfitMoney;

            // �݌ɏ��i���v���z�i�Ŕ��j�i���ŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // ���ŏ��i AND �݌� AND (���� OR �ԕi OR (�l�� AND �o�א��[��))
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesOrderDivCdColumn, (int)SalesOrderDivCd.Stock,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            long stockGoodsTtlTaxExc_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // �݌ɏ��i���v���z�i�Ŕ��j�i�O�ŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // �O�ŏ��i�i AND �݌� AND (���� OR �ԕi OR (�l�� AND �o�א��[��))
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesOrderDivCdColumn, (int)SalesOrderDivCd.Stock,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            long stockGoodsTtlTaxExc_TaxExc = (value is System.DBNull) ? 0 : (long)value;

            // �݌ɏ��i���v���z�i�Ŕ��j�i��ېŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // ��ېŏ��i AND �݌� AND (���� OR �ԕi OR (�l�� AND �o�א��[��))
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesOrderDivCdColumn, (int)SalesOrderDivCd.Stock,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            long stockGoodsTtlTaxExc_TaxNone = (value is System.DBNull) ? 0 : (long)value;

            // �݌ɏ��i���v���z�i�Ŕ��j
            stockGoodsTtlTaxExc = stockGoodsTtlTaxExc_TaxInc + stockGoodsTtlTaxExc_TaxExc + stockGoodsTtlTaxExc_TaxNone; // �݌ɏ��i���v���z�i�Ŕ��j

            // �������i���v���z�i�Ŕ��j�i���ŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                //string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // ���ŏ��i AND ���� AND (���� OR �ԕi OR (�l�� AND �o�א��[��))
                //    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                //    salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
                //    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                //    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                //    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                //    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR {8}={9})",  // ���ŏ��i AND ���� AND (���� OR �ԕi OR �l��)
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            long pureGoodsTtlTaxExc_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // �������i���v���z�i�Ŕ��j�i�O�ŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                //string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // �O�ŏ��i AND ���� AND (���� OR �ԕi OR (�l�� AND �o�א��[��))
                //    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                //    salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
                //    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                //    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                //    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                //    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR {8}={9})",  // �O�ŏ��i AND ���� AND (���� OR �ԕi OR �l��)
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            long pureGoodsTtlTaxExc_TaxExc = (value is System.DBNull) ? 0 : (long)value;

            // �������i���v���z�i�Ŕ��j�i��ېŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                //string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // ��ې� AND ���� AND (���� OR �ԕi OR (�l�� AND �o�א��[��))
                //    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                //    salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
                //    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                //    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                //    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                //    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR {8}={9})",  // ��ې� AND ���� AND (���� OR �ԕi OR �l��)
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            long pureGoodsTtlTaxExc_TaxNone = (value is System.DBNull) ? 0 : (long)value;

            // �������i���v���z�i�Ŕ��j
            pureGoodsTtlTaxExc = pureGoodsTtlTaxExc_TaxInc + pureGoodsTtlTaxExc_TaxExc + pureGoodsTtlTaxExc_TaxNone; // �������i���v���z�i�Ŕ��j

            // ���㕔�i���v�i�ō��j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} OR {2}={3}",
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salesPrtSubttlInc = (value is System.DBNull) ? 0 : (long)value;

            // ���㕔�i���v�i�Ŕ��j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} OR {2}={3}",
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salesPrtSubttlExc = (value is System.DBNull) ? 0 : (long)value;

            // ���i�l���Ώۊz���v�i�ō��j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1}",
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedPartsDisInTax = (value is System.DBNull) ? 0 : (long)value;

            // ���i�l���Ώۊz���v�i�Ŕ��j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1}",
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedPartsDisOutTax = (value is System.DBNull) ? 0 : (long)value;

            // ���㕔�i���v�i�ō��j
            salesPrtTotalTaxInc = salesPrtSubttlInc + itdedPartsDisInTax;

            // ���㕔�i���v�i�Ŕ��j
            salesPrtTotalTaxExc = salesPrtSubttlExc + itdedPartsDisOutTax;
            #endregion

            #region ���]�ŕ����F��ېł̏ꍇ�ɋ��z�𒲐�����
            //-----------------------------------------------------------------------------
            // �]�ŕ����F��ېł̏ꍇ�ɋ��z�𒲐�����
            //-----------------------------------------------------------------------------
            if (consTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
            {
                // ������z����Ŋz�i�O�Łj
                salesOutTax = 0;

                // ������z����Ŋz�i���Łj
                salAmntConsTaxInclu = 0;

                // ���㏬�v��ېőΏۊz
                salSubttlSubToTaxFre += itdedSalesOutTax + itdedSalesInTax;

                // ����O�őΏۊz
                itdedSalesOutTax = 0;

                // ������őΏۊz
                itdedSalesInTax = 0;

                // ������őΏۊz�i�ō��j
                itdedSalesInTax_TaxInc = 0;

                // ����l������Ŋz�i�O�Łj
                salesDisOutTax = 0;

                // ����l������Ŋz�i���Łj
                salesDisTtlTaxInclu = 0;

                // ����l����ېőΏۊz���v
                itdedSalesDisTaxFre += itdedSalesDisOutTax + itdedSalesDisInTax;

                // ����l���O�őΏۊz���v
                itdedSalesDisOutTax = 0;

                // ����l�����őΏۊz���v
                itdedSalesDisInTax = 0;

                // ����l�����őΏۊz���v�i�ō��j
                itdedSalesDisInTax_TaxInc = 0;

                // ����l�����z�v�i�Ŕ��j
                salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;
            }
            #endregion

            #region ���e����z�Z�o
            //-----------------------------------------------------------------------------
            // �e����z�Z�o
            //-----------------------------------------------------------------------------
            // ���ד]�ňȊO
            if (consTaxLayMethod != (int)ConsTaxLayMethod.DetailLay)
            {
                //-----------------------------------------------------------------------------
                // �@ ����`�[���v�i�Ŕ��j�F����O�őΏۊz + ������őΏۊz + ����l���O�őΏۊz���v + ����l�����őΏۊz���v + ����l����ېőΏۊz���v
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

                //-----------------------------------------------------------------------------
                // �A ����`�[���v�i�ō��j�F ������őΏۊz�i�ō��j + ����O�őΏۊz + ����l�����őΏۊz���v�i�ō��j + ����l���O�őΏۊz���v + ����l����ېőΏۊz���v + (����O�őΏۊz + ����l���O�őΏۊz���v)�~�ŗ�)
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = itdedSalesInTax_TaxInc + itdedSalesOutTax + itdedSalesDisInTax_TaxInc + itdedSalesDisOutTax + itdedSalesDisTaxFre + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // �B ���㏬�v�i�Łj�F�A - �@
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesTotalTaxInc - salesTotalTaxExc;

                //-----------------------------------------------------------------------------
                // �C ������z����Ŋz�i�O�Łj�F����O�őΏۊz �~ �ŗ�
                //-----------------------------------------------------------------------------
                salesOutTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax);

                //-----------------------------------------------------------------------------
                // �D ������z����Ŋz�i�O�Łj(�Ŕ��A�l�����܂�) �F(����O�őΏۊz + ����l���O�őΏۊz���v) �~ �ŗ�
                //-----------------------------------------------------------------------------
                long salesOutTax_All = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // �E ����l������Ŋz�i�O�Łj�F�C - �D
                //-----------------------------------------------------------------------------
                salesDisOutTax = salesOutTax_All - salesOutTax;

                //-----------------------------------------------------------------------------
                // �F ���㕔�i���v�i�ō��j�F���㕔�i���v�i�Ŕ��j �~ �ŗ�
                //-----------------------------------------------------------------------------
                salesPrtSubttlInc = salesPrtSubttlExc + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, salesPrtSubttlExc);

                //-----------------------------------------------------------------------------
                // �G ���i�l���Ώۊz���v�i�ō��j�F���i�l���Ώۊz���v�i�Ŕ��j�~ �ŗ�
                //-----------------------------------------------------------------------------
                itdedPartsDisInTax = itdedPartsDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedPartsDisOutTax);

                //-----------------------------------------------------------------------------
                // �H ���㕔�i���v�i�ō��j�F(���㕔�i���v�i�Ŕ��j+ ���i�l���Ώۊz���v�i�Ŕ��j) �~ �ŗ�
                //-----------------------------------------------------------------------------
                salesPrtTotalTaxInc = salesPrtSubttlExc + itdedPartsDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, salesPrtSubttlExc + itdedPartsDisOutTax);
            }
            // ���ד]��
            else
            {
                // ---------------------------- ADD �� 2013/12/19 Redmine#41550 No.1----------------------------------->>>>>
                // ------------------------------
                // ��Q����
                // ���ד]�ł̏ꍇ�A����O�̓`�[���C�����[�h�ŌĂяo���A������͉����֕ύX���A
                // �ۑ�����ۂɁA�[�i���ɏ���ł�����O�̒l�ŕ\�������
                // ------------------------------
                // ������z����Ŋz�i�O�Łj
                salesOutTax = 0;
                // ����l������Ŋz�i�O�Łj
                salesDisOutTax = 0;
                foreach (SalesInputDataSet.SalesDetailRow row in salesDetailDataTable)
                {
                    if (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc) // ���i���O��
                    {
                        // -----------------------------------------------
                        // ���׃f�[�^�ɐō��̍��ڂƏ���ł��X�V����K�v
                        // �X�V���Ȃ��ƁA���L�̌��ۂ�����
                        // ���ہF���Ӑ�d�q�����ɂČ������āA�u�`�[�\���v�Ɓu���ו\���v�̏���ł��Ⴄ
                        // -----------------------------------------------
                        // �艿(�ō�) = �艿(�Ŕ�) + (�艿(�Ŕ�) * �ŗ�)
                        row.ListPriceTaxIncFl = row.ListPriceTaxExcFl + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, row.ListPriceTaxExcFl);
                        // ����P���i�ō��j= ����P��(�Ŕ�) + (����P��(�Ŕ�) * �ŗ�)
                        row.SalesUnPrcTaxIncFl = row.SalesUnPrcTaxExcFl + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesUnPrcTaxExcFl);
                        // ������z�i�ō��j= ������z(�Ŕ�) + (������z(�Ŕ�) * �ŗ�)
                        row.SalesMoneyTaxInc = row.SalesMoneyTaxExc + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesMoneyTaxExc);

                        // 0:����,1:�ԕi
                        if (row.SalesSlipCdDtl == (int)SalesSlipCdDtl.Sales || row.SalesSlipCdDtl == (int)SalesSlipCdDtl.RetGoods)
                        {
                            // ������z����Ŋz
                            long salesPriceConsTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesMoneyTaxExc);
                            row.SalesPriceConsTax = salesPriceConsTax;
                            salesOutTax += salesPriceConsTax;
                        }
                        // 2:�l��
                        else if (row.SalesSlipCdDtl == (int)SalesSlipCdDtl.Discount)
                        {
                            // ������z����Ŋz
                            long salesPriceConsTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesMoneyTaxExc);
                            row.SalesPriceConsTax = salesPriceConsTax;
                            salesDisOutTax += salesPriceConsTax;
                        }
                        // 3:����,4:���v,5:���
                        else
                        {
                            // �Ȃ�
                        }
                    }
                }
                // ---------------------------- ADD �� 2013/12/19 Redmine#41550 No.9 -----------------------------------<<<<<
                //-----------------------------------------------------------------------------
                // �@ ���㏬�v�i�Łj�F������z����Ŋz�i�O�Łj + ������z����Ŋz�i���Łj +  ����l������Ŋz�i�O�Łj + ����l������Ŋz�i���Łj
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesOutTax + salAmntConsTaxInclu + salesDisOutTax + salesDisTtlTaxInclu;

                //-----------------------------------------------------------------------------
                // �A ����`�[���v�i�Ŕ��j�F����O�őΏۊz + ������őΏۊz + ����l���O�őΏۊz���v + ����l�����őΏۊz���v
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax;

                //-----------------------------------------------------------------------------
                // �B ����`�[���v�i�ō��j�F�@ + �A
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = salesTotalTaxExc + salesSubtotalTax;
            }
            #endregion

            #region �폜
            //// ���z�\������
            //if (totalAmountDispWayCd == 1)
            //{
            //    //-----------------------------------------------------------------------------
            //    // �@ ����`�[���v�i�ō��j�F����O�őΏۊz + ������z����Ŋz�i�O�Łj + ������őΏۊz�i�ō��j +  ����l�����őΏۊz���v�i�ō��j
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxInc = itdedSalesOutTax + salesOutTax + itdedSalesInTax_TaxInc + itdedSalesDisInTax_TaxInc;

            //    //-----------------------------------------------------------------------------
            //    // �A ���㏬�v�i�Łj�F�@������ł��v�Z
            //    //-----------------------------------------------------------------------------
            //    salesSubtotalTax = CalculateTax.GetTaxFromPriceInc(consTaxRate, taxFracProcUnit, taxFracProcCd, salesTotalTaxInc);

            //    //-----------------------------------------------------------------------------
            //    // �B ����`�[���v�i�Ŕ��j�F�A - �@
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxExc = salesTotalTaxInc - salesSubtotalTax;
            //}
            //// ���z�\���Ȃ� �`�[�]�ňȊO
            //else if (consTaxLayMethod != 0)
            //{
            //    //-----------------------------------------------------------------------------
            //    // �@ ���㏬�v�i�Łj�F������z����Ŋz�i�O�Łj + ������z����Ŋz�i���Łj +  ����l������Ŋz�i�O�Łj + ����l������Ŋz�i���Łj
            //    //-----------------------------------------------------------------------------
            //    salesSubtotalTax = salesOutTax + salAmntConsTaxInclu + salesDisOutTax + salesDisTtlTaxInclu;

            //    //-----------------------------------------------------------------------------
            //    // �A ����`�[���v�i�Ŕ��j�F����O�őΏۊz + ������őΏۊz + ����l���O�őΏۊz���v
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax;

            //    //-----------------------------------------------------------------------------
            //    // �B ����`�[���v�i�ō��j�F�@ + �A
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxInc = salesTotalTaxExc + salesSubtotalTax;
            //}
            //// ���z�\�������ŁA�`�[�]��
            //else
            //{
            //    //-----------------------------------------------------------------------------
            //    // �@ ����`�[���v�i�Ŕ��j�F����O�őΏۊz + ������őΏۊz + ����l���O�őΏۊz���v
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax;

            //    //-----------------------------------------------------------------------------
            //    // �A ����`�[���v�i�ō��j�F ������őΏۊz�i�ō��j + ����O�őΏۊz + ����l���O�őΏۊz���v �{ (����O�őΏۊz + ����l���O�őΏۊz���v)�~�ŗ�)
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxInc = itdedSalesInTax_TaxInc + itdedSalesOutTax + itdedSalesDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

            //    //-----------------------------------------------------------------------------
            //    // �B ���㏬�v�i�Łj�F�A - �@
            //    //-----------------------------------------------------------------------------
            //    salesSubtotalTax = salesTotalTaxInc - salesTotalTaxExc;

            //    //-----------------------------------------------------------------------------
            //    // �C ������z����Ŋz�i�O�Łj�F����O�őΏۊz �~ �ŗ�
            //    //-----------------------------------------------------------------------------
            //    salesOutTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax);

            //    //-----------------------------------------------------------------------------
            //    // �D ������z����Ŋz�i�O�Łj(�Ŕ��A�l�����܂�) �F(����O�őΏۊz + ����l���O�őΏۊz���v) �~ �ŗ�
            //    //-----------------------------------------------------------------------------
            //    long salesOutTax_All = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

            //    //-----------------------------------------------------------------------------
            //    // �E ����l������Ŋz�i�O�Łj�F�C - �D
            //    //-----------------------------------------------------------------------------
            //    salesDisOutTax = salesOutTax_All - salesOutTax;
            //}
            #endregion
        }

        /// <summary>
        /// ���㍇�v���z�ݒ菈���i�󒍏��j
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        public void TotalPriceSettingForAcptAnOdr(ref SalesSlip salesSlip)
        {
            this.TotalPriceSettingForAcptAnOdr(ref salesSlip, this._salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// ���㍇�v���z�ݒ菈���i�󒍏��j
        /// </summary>
        /// <param name="salesSlip">����f�[�^�I�u�W�F�N�g</param>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u��</param>
        public void TotalPriceSettingForAcptAnOdr(ref SalesSlip salesSlip, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailDataTable)
        {
            if (salesSlip == null) return;
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// ����Œ[�������R�[�h

            long salesTotalTaxInc = 0;      // ����`�[���v�i�ō��j
            long salesTotalTaxExc = 0;      // ����`�[���v�i�Ŕ��j
            long salesSubtotalTax = 0;      // ���㏬�v�i�Łj
            long itdedSalesOutTax = 0;      // ����O�őΏۊz
            long itdedSalesInTax = 0;       // ������őΏۊz
            long salSubttlSubToTaxFre = 0;  // ���㏬�v��ېőΏۊz
            long salesOutTax = 0;           // ������z����Ŋz�i�O�Łj
            long salAmntConsTaxInclu = 0;   // ������z����Ŋz�i���Łj
            long salesDisTtlTaxExc = 0;     // ����l�����z�v�i�Ŕ��j
            long itdedSalesDisOutTax = 0;   // ����l���O�őΏۊz���v
            long itdedSalesDisInTax = 0;    // ����l�����őΏۊz���v
            long itdedSalesDisTaxFre = 0;   // ����l����ېőΏۊz���v
            long salesDisOutTax = 0;        // ����l������Ŋz�i�O�Łj
            long salesDisTtlTaxInclu = 0;   // ����l������Ŋz�i���Łj
            long totalCost = 0;             // �������z�v
            long stockGoodsTtlTaxExc = 0;   // �݌ɏ��i���v���z�i�Ŕ��j
            long pureGoodsTtlTaxExc = 0;    // �������i���v���z�i�Ŕ��j
            long taxAdjust = 0;             // ����Œ����z
            long balanceAdjust = 0;         // �c�������z
            long salesPrtTotalTaxInc = 0;   // ���㕔�i���v�i�ō��j
            long salesPrtTotalTaxExc = 0;   // ���㕔�i���v�i�Ŕ��j
            long salesPrtSubttlInc = 0;     // ���㕔�i���v�i�ō��j
            long salesPrtSubttlExc = 0;     // ���㕔�i���v�i�Ŕ��j
            long salesWorkSubttlInc = 0;    // �����Ə��v�i�ō��j
            long salesWorkSubttlExc = 0;    // �����Ə��v�i�Ŕ��j
            long itdedPartsDisInTax = 0;    // ���i�l���Ώۊz���v�i�ō��j
            long itdedPartsDisOutTax = 0;   // ���i�l���Ώۊz���v�i�Ŕ��j
            long itdedWorkDisInTax = 0;     // ��ƒl���Ώۊz���v�i�ō��j
            long itdedWorkDisOutTax = 0;    // ��ƒl���Ώۊz���v�i�Ŕ��j
            long totalMoneyForGrossProfit = 0; // �e���v�Z�p������z

            this.CalculationSalesTotalPriceForAcptAnOdr(
                salesDetailDataTable,
                salesSlip.ConsTaxRate,
                salesTaxFrcProcCd,
                salesSlip.TotalAmountDispWayCd,
                salesSlip.ConsTaxLayMethod,
                out salesTotalTaxInc,
                out salesTotalTaxExc,
                out salesSubtotalTax,
                out itdedSalesOutTax,
                out itdedSalesInTax,
                out salSubttlSubToTaxFre,
                out salesOutTax,
                out salAmntConsTaxInclu,
                out salesDisTtlTaxExc,
                out itdedSalesDisOutTax,
                out itdedSalesDisInTax,
                out itdedSalesDisTaxFre,
                out salesDisOutTax,
                out salesDisTtlTaxInclu,
                out totalCost,
                out stockGoodsTtlTaxExc,
                out pureGoodsTtlTaxExc,
                out balanceAdjust,
                out taxAdjust,
                out salesPrtSubttlInc,
                out salesPrtSubttlExc,
                out salesWorkSubttlInc,
                out salesWorkSubttlExc,
                out itdedPartsDisInTax,
                out itdedPartsDisOutTax,
                out itdedWorkDisInTax,
                out itdedWorkDisOutTax,
                out totalMoneyForGrossProfit,
                out salesPrtTotalTaxInc,
                out salesPrtTotalTaxExc);

            switch ((SalesGoodsCd)salesSlip.SalesGoodsCd)
            {
                case SalesGoodsCd.ConsTaxAdjust:
                case SalesGoodsCd.AccRecConsTaxAdjust:
                    {

                        salesSlip.SalesSubtotalTaxInc = 0;              // ���㏬�v�i�ō��j
                        salesSlip.SalesSubtotalTaxExc = 0;              // ���㏬�v�i�Ŕ��j
                        salesSlip.SalesSubtotalTax = taxAdjust;         // ���㏬�v�i�Łj
                        salesSlip.ItdedSalesOutTax = 0;                 // ����O�őΏۊz
                        salesSlip.ItdedSalesInTax = 0;                  // ������őΏۊz
                        salesSlip.SalSubttlSubToTaxFre = 0;             // ���㏬�v��ېőΏۊz
                        salesSlip.SalesOutTax = 0;                      // ������z����Ŋz�i�O�Łj
                        salesSlip.SalAmntConsTaxInclu = 0;              // ������z����Ŋz�i���Łj
                        salesSlip.SalesDisTtlTaxExc = 0;                // ����l�����z�v�i�Ŕ��j
                        salesSlip.ItdedSalesDisOutTax = 0;              // ����l���O�őΏۊz���v
                        salesSlip.ItdedSalesDisInTax = 0;               // ����l�����őΏۊz���v
                        salesSlip.ItdedSalesDisTaxFre = 0;              // ����l����ېőΏۊz���v
                        salesSlip.SalesDisOutTax = 0;                   // ����l������Ŋz�i�O�Łj
                        salesSlip.SalesDisTtlTaxInclu = 0;              // ����l������Ŋz�i���Łj
                        salesSlip.TotalCost = 0;                        // �������z�v
                        salesSlip.StockGoodsTtlTaxExc = 0;              // �݌ɏ��i���v���z�i�Ŕ��j
                        salesSlip.PureGoodsTtlTaxExc = 0;               // �������i���v���z�i�Ŕ��j
                        salesSlip.SalesPrtSubttlInc = 0;                // ���㕔�i���v�i�ō��j
                        salesSlip.SalesPrtSubttlExc = 0;                // ���㕔�i���v�i�Ŕ��j
                        salesSlip.SalesWorkSubttlInc = 0;               // �����Ə��v�i�ō��j
                        salesSlip.SalesWorkSubttlExc = 0;               // �����Ə��v�i�Ŕ��j
                        salesSlip.ItdedPartsDisInTax = 0;               // ���i�l���Ώۊz���v�i�ō��j
                        salesSlip.ItdedPartsDisOutTax = 0;              // ���i�l���Ώۊz���v�i�Ŕ��j
                        salesSlip.ItdedWorkDisInTax = 0;                // ��ƒl���Ώۊz���v�i�ō��j
                        salesSlip.ItdedWorkDisOutTax = 0;               // ��ƒl���Ώۊz���v�i�Ŕ��j
                        salesSlip.TotalMoneyForGrossProfit = 0;         // �e���v�Z�p������z

                        salesSlip.SalesTotalTaxInc = 0;                 // ����`�[���v�i�ō��j
                        salesSlip.SalesTotalTaxExc = 0;                 // ����`�[���v�i�Ŕ��j
                        salesSlip.SalesNetPrice = 0;                    // ���㐳�����z
                        salesSlip.AccRecConsTax = 0;                    // ���|�����
                        break;
                    }
                case SalesGoodsCd.BalanceAdjust:
                case SalesGoodsCd.AccRecBalanceAdjust:
                    {
                        salesSlip.SalesSubtotalTaxInc = 0;              // ���㏬�v�i�ō��j
                        salesSlip.SalesSubtotalTaxExc = 0;              // ���㏬�v�i�Ŕ��j
                        salesSlip.SalesSubtotalTax = 0;                 // ���㏬�v�i�Łj
                        salesSlip.ItdedSalesOutTax = 0;                 // ����O�őΏۊz
                        salesSlip.ItdedSalesInTax = 0;                  // ������őΏۊz
                        salesSlip.SalSubttlSubToTaxFre = 0;             // ���㏬�v��ېőΏۊz
                        salesSlip.SalesOutTax = 0;                      // ������z����Ŋz�i�O�Łj
                        salesSlip.SalAmntConsTaxInclu = 0;              // ������z����Ŋz�i���Łj
                        salesSlip.SalesDisTtlTaxExc = 0;                // ����l�����z�v�i�Ŕ��j
                        salesSlip.ItdedSalesDisOutTax = 0;              // ����l���O�őΏۊz���v
                        salesSlip.ItdedSalesDisInTax = 0;               // ����l�����őΏۊz���v
                        salesSlip.ItdedSalesDisTaxFre = 0;              // ����l����ېőΏۊz���v
                        salesSlip.SalesDisOutTax = 0;                   // ����l������Ŋz�i�O�Łj
                        salesSlip.SalesDisTtlTaxInclu = 0;              // ����l������Ŋz�i���Łj
                        salesSlip.TotalCost = 0;                        // �������z�v
                        salesSlip.StockGoodsTtlTaxExc = 0;              // �݌ɏ��i���v���z�i�Ŕ��j
                        salesSlip.PureGoodsTtlTaxExc = 0;               // �������i���v���z�i�Ŕ��j
                        salesSlip.SalesPrtSubttlInc = 0;                // ���㕔�i���v�i�ō��j
                        salesSlip.SalesPrtSubttlExc = 0;                // ���㕔�i���v�i�Ŕ��j
                        salesSlip.SalesWorkSubttlInc = 0;               // �����Ə��v�i�ō��j
                        salesSlip.SalesWorkSubttlExc = 0;               // �����Ə��v�i�Ŕ��j
                        salesSlip.ItdedPartsDisInTax = 0;               // ���i�l���Ώۊz���v�i�ō��j
                        salesSlip.ItdedPartsDisOutTax = 0;              // ���i�l���Ώۊz���v�i�Ŕ��j
                        salesSlip.ItdedWorkDisInTax = 0;                // ��ƒl���Ώۊz���v�i�ō��j
                        salesSlip.ItdedWorkDisOutTax = 0;               // ��ƒl���Ώۊz���v�i�Ŕ��j
                        salesSlip.TotalMoneyForGrossProfit = 0;         // �e���v�Z�p������z

                        salesSlip.SalesTotalTaxInc = balanceAdjust;     // ����`�[���v�i�ō��j
                        salesSlip.SalesTotalTaxExc = 0;                 // ����`�[���v�i�Ŕ��j
                        salesSlip.SalesNetPrice = 0;                    // ���㐳�����z
                        salesSlip.AccRecConsTax = 0;                    // ���|�����
                        break;
                    }
                case SalesGoodsCd.Goods:
                    {
                        salesSlip.SalesSubtotalTaxInc = salesTotalTaxInc;       // ���㏬�v�i�ō��j
                        salesSlip.SalesSubtotalTaxExc = salesTotalTaxExc;       // ���㏬�v�i�Ŕ��j
                        salesSlip.SalesSubtotalTax = salesSubtotalTax;          // ���㏬�v�i�Łj
                        salesSlip.ItdedSalesOutTax = itdedSalesOutTax;          // ����O�őΏۊz
                        salesSlip.ItdedSalesInTax = itdedSalesInTax;            // ������őΏۊz
                        salesSlip.SalSubttlSubToTaxFre = salSubttlSubToTaxFre;  // ���㏬�v��ېőΏۊz
                        salesSlip.SalesOutTax = salesOutTax;                    // ������z����Ŋz�i�O�Łj
                        salesSlip.SalAmntConsTaxInclu = salAmntConsTaxInclu;    // ������z����Ŋz�i���Łj
                        salesSlip.SalesDisTtlTaxExc = salesDisTtlTaxExc;        // ����l�����z�v�i�Ŕ��j
                        salesSlip.ItdedSalesDisOutTax = itdedSalesDisOutTax;    // ����l���O�őΏۊz���v
                        salesSlip.ItdedSalesDisInTax = itdedSalesDisInTax;      // ����l�����őΏۊz���v
                        salesSlip.ItdedSalesDisTaxFre = itdedSalesDisTaxFre;    // ����l����ېőΏۊz���v
                        salesSlip.SalesDisOutTax = salesDisOutTax;              // ����l������Ŋz�i�O�Łj
                        salesSlip.SalesDisTtlTaxInclu = salesDisTtlTaxInclu;    // ����l������Ŋz�i���Łj
                        salesSlip.TotalCost = totalCost;                        // �������z�v
                        salesSlip.StockGoodsTtlTaxExc = stockGoodsTtlTaxExc;    // �݌ɏ��i���v���z�i�Ŕ��j
                        salesSlip.PureGoodsTtlTaxExc = pureGoodsTtlTaxExc;      // �������i���v���z�i�Ŕ��j
                        salesSlip.SalesPrtSubttlInc = salesPrtSubttlInc;                // ���㕔�i���v�i�ō��j
                        salesSlip.SalesPrtSubttlExc = salesPrtSubttlExc;                // ���㕔�i���v�i�Ŕ��j
                        salesSlip.SalesWorkSubttlInc = salesWorkSubttlInc;              // �����Ə��v�i�ō��j
                        salesSlip.SalesWorkSubttlExc = salesWorkSubttlExc;              // �����Ə��v�i�Ŕ��j
                        salesSlip.ItdedPartsDisInTax = itdedPartsDisInTax;              // ���i�l���Ώۊz���v�i�ō��j
                        salesSlip.ItdedPartsDisOutTax = itdedPartsDisOutTax;            // ���i�l���Ώۊz���v�i�Ŕ��j
                        salesSlip.ItdedWorkDisInTax = itdedWorkDisInTax;                // ��ƒl���Ώۊz���v�i�ō��j
                        salesSlip.ItdedWorkDisOutTax = itdedWorkDisOutTax;              // ��ƒl���Ώۊz���v�i�Ŕ��j
                        salesSlip.TotalMoneyForGrossProfit = totalMoneyForGrossProfit; // �e���v�Z�p������z

                        salesSlip.SalesTotalTaxInc = salesTotalTaxInc + salSubttlSubToTaxFre;                   // ����`�[���v�i�ō��j= ����`�[���v�i�ō��j + ���㏬�v��ېőΏۊz
                        salesSlip.SalesTotalTaxExc = salesTotalTaxExc + salSubttlSubToTaxFre;                   // ����`�[���v�i�Ŕ��j= ����`�[���v�i�Ŕ��j + ���㏬�v��ېőΏۊz
                        salesSlip.SalesNetPrice = itdedSalesOutTax + itdedSalesInTax + salSubttlSubToTaxFre;    // ���㐳�����z = ����O�őΏۊz + ������őΏۊz + ���㏬�v��ېőΏۊz
                        salesSlip.AccRecConsTax = salesSubtotalTax;                                             // ���|�����
                        salesSlip.SalesPrtTotalTaxInc = salesPrtTotalTaxInc;                                    // ���㕔�i���v�i�ō��j
                        salesSlip.SalesPrtTotalTaxExc = salesPrtTotalTaxExc;                                    // ���㕔�i���v�i�Ŕ��j
                        salesSlip.SalesWorkTotalTaxInc = salesWorkSubttlInc + itdedWorkDisInTax;                // �����ƍ��v�i�ō��j
                        salesSlip.SalesWorkTotalTaxExc = salesWorkSubttlExc + itdedWorkDisOutTax;               // �����ƍ��v�i�Ŕ��j
                        break;
                    }
            }
        }

        /// <summary>
        /// ������z�̍��v���v�Z���܂��B�i�󒍏��j
        /// </summary>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u��</param>
        /// <param name="consTaxRate">����Őŗ�</param>
        /// <param name="salesTaxFrcProcCd">����Œ[�������R�[�h</param>
        /// <param name="totalAmountDispWayCd">���z�\�����@�敪</param>
        /// <param name="consTaxLayMethod">����œ]�ŕ���</param>
        /// <param name="salesTotalTaxInc">����`�[���v�i�ō��j</param>
        /// <param name="salesTotalTaxExc">����`�[���v�i�Ŕ��j</param>
        /// <param name="salesSubtotalTax">���㏬�v�i�Łj</param>
        /// <param name="itdedSalesOutTax">����O�őΏۊz</param>
        /// <param name="itdedSalesInTax">������őΏۊz</param>
        /// <param name="salSubttlSubToTaxFre">���㏬�v��ېőΏۊz</param>
        /// <param name="salesOutTax">������z����Ŋz�i�O�Łj</param>
        /// <param name="salAmntConsTaxInclu">������z����Ŋz�i���Łj</param>
        /// <param name="salesDisTtlTaxExc">����l�����z�v�i�Ŕ��j</param>
        /// <param name="itdedSalesDisOutTax">����l���O�őΏۊz���v</param>
        /// <param name="itdedSalesDisInTax">����l�����őΏۊz���v</param>
        /// <param name="itdedSalesDisTaxFre">����l����ېőΏۊz���v</param>
        /// <param name="salesDisOutTax">����l������Ŋz�i�O�Łj</param>
        /// <param name="salesDisTtlTaxInclu">����l������Ŋz�i���Łj</param>
        /// <param name="totalCost">�������z�v</param>
        /// <param name="StockGoodsTtlTaxExc">�݌ɏ��i���v���z(�Ŕ�)</param>
        /// <param name="PureGoodsTtlTaxExc">�������i���v���z(�Ŕ�)</param>
        /// <param name="balanceAdjust">����Œ����z</param>
        /// <param name="taxAdjust">�c�������z</param>
        /// <param name="salesPrtSubttlInc">���㕔�i���v�i�ō��j</param>
        /// <param name="salesPrtSubttlExc">���㕔�i���v�i�Ŕ��j</param>
        /// <param name="salesWorkSubttlInc">�����Ə��v�i�ō��j</param>
        /// <param name="salesWorkSubttlExc">�����Ə��v�i�Ŕ��j</param>
        /// <param name="itdedPartsDisInTax">���i�l���Ώۊz���v�i�ō��j</param>
        /// <param name="itdedPartsDisOutTax">���i�l���Ώۊz���v�i�Ŕ��j</param>
        /// <param name="itdedWorkDisInTax">��ƒl���Ώۊz���v�i�ō��j</param>
        /// <param name="itdedWorkDisOutTax">��ƒl���Ώۊz���v�i�Ŕ��j</param>
        /// <param name="totalMoneyForGrossProfit">�e���v�Z�p������z</param>
        /// <param name="salesPrtTotalTaxInc">���㕔�i���v�i�ō��j</param>
        /// <param name="salesPrtTotalTaxExc">���㕔�i���v�i�Ŕ��j</param>
        /// <br>Update Note: 2013/12/19 ��</br>
        /// <br>             Redmine#41550 ����`�[���͏����8%���őΉ��B</br> 
        public void CalculationSalesTotalPriceForAcptAnOdr(SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailDataTable, double consTaxRate, int salesTaxFrcProcCd, int totalAmountDispWayCd, int consTaxLayMethod, out long salesTotalTaxInc, out long salesTotalTaxExc, out long salesSubtotalTax, out long itdedSalesOutTax, out long itdedSalesInTax, out long salSubttlSubToTaxFre, out long salesOutTax, out long salAmntConsTaxInclu, out long salesDisTtlTaxExc, out long itdedSalesDisOutTax, out long itdedSalesDisInTax, out long itdedSalesDisTaxFre, out long salesDisOutTax, out long salesDisTtlTaxInclu, out long totalCost, out long stockGoodsTtlTaxExc, out long pureGoodsTtlTaxExc, out long balanceAdjust, out long taxAdjust, out long salesPrtSubttlInc, out long salesPrtSubttlExc, out long salesWorkSubttlInc, out long salesWorkSubttlExc, out long itdedPartsDisInTax, out long itdedPartsDisOutTax, out long itdedWorkDisInTax, out long itdedWorkDisOutTax, out long totalMoneyForGrossProfit, out long salesPrtTotalTaxInc, out long salesPrtTotalTaxExc)
        {
            #region ����������
            //-----------------------------------------------------------------------------
            // ��������
            //-----------------------------------------------------------------------------
            // ����Œ[�������P�ʁA�[�������敪���擾
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            // �f�[�^�e�[�u���̕ύX���R�~�b�g������
            salesDetailDataTable.AcceptChanges();

            salesTotalTaxInc = 0;           // ����`�[���v�i�ō��j
            salesTotalTaxExc = 0;           // ����`�[���v�i�Ŕ��j
            salesSubtotalTax = 0;           // ���㏬�v�i�Łj
            itdedSalesOutTax = 0;           // ����O�őΏۊz
            itdedSalesInTax = 0;            // ������őΏۊz
            salSubttlSubToTaxFre = 0;       // ���㏬�v��ېőΏۊz
            salesOutTax = 0;                // ������z����Ŋz�i�O�Łj
            salAmntConsTaxInclu = 0;        // ������z����Ŋz�i���Łj
            salesDisTtlTaxExc = 0;          // ����l�����z�v�i�Ŕ��j
            itdedSalesDisOutTax = 0;        // ����l���O�őΏۊz���v
            itdedSalesDisInTax = 0;         // ����l�����őΏۊz���v
            itdedSalesDisTaxFre = 0;        // ����l����ېőΏۊz���v
            salesDisOutTax = 0;             // ����l������Ŋz�i�O�Łj
            salesDisTtlTaxInclu = 0;        // ����l������Ŋz�i���Łj
            stockGoodsTtlTaxExc = 0;        // �݌ɏ��i���v���z�i�Ŕ��j
            pureGoodsTtlTaxExc = 0;         // �������i���v���z�i�Ŕ��j
            totalCost = 0;                  // �������z�v
            taxAdjust = 0;                  // ����Œ����z
            balanceAdjust = 0;              // �c�������z
            salesPrtTotalTaxInc = 0;        // ���㕔�i���v�i�ō��j
            salesPrtTotalTaxExc = 0;        // ���㕔�i���v�i�Ŕ��j
            salesPrtSubttlInc = 0;          // ���㕔�i���v�i�ō��j
            salesPrtSubttlExc = 0;          // ���㕔�i���v�i�Ŕ��j
            salesWorkSubttlInc = 0;         // �����Ə��v�i�ō��j
            salesWorkSubttlExc = 0;         // �����Ə��v�i�Ŕ��j
            itdedPartsDisInTax = 0;         // ���i�l���Ώۊz���v�i�ō��j
            itdedPartsDisOutTax = 0;        // ���i�l���Ώۊz���v�i�Ŕ��j
            itdedWorkDisInTax = 0;          // ��ƒl���Ώۊz���v�i�ō��j
            itdedWorkDisOutTax = 0;         // ��ƒl���Ώۊz���v�i�Ŕ��j
            totalMoneyForGrossProfit = 0;   // �e���v�Z�p������z

            object value = null;
            #endregion

            #region ���v�Z�ɕK�v�ȋ��z�̌v�Z
            //-----------------------------------------------------------------------------
            // �v�Z�ɕK�v�ȋ��z�̌v�Z
            //-----------------------------------------------------------------------------
            // ����O�őΏۊz
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            itdedSalesOutTax = (value is System.DBNull) ? 0 : (long)value;

            // ������z����Ŋz�i�O�Łj
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salesOutTax = (value is System.DBNull) ? 0 : (long)value;

            // ������őΏۊz
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            itdedSalesInTax = (value is System.DBNull) ? 0 : (long)value;

            // ������őΏۊz�i�ō��j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            long itdedSalesInTax_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // ������z����Ŋz�i���Łj
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salAmntConsTaxInclu = (value is System.DBNull) ? 0 : (long)value;

            // ���㏬�v��ېőΏۊz
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salSubttlSubToTaxFre = (value is System.DBNull) ? 0 : (long)value;

            // ����l���O�őΏۊz���v
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedSalesDisOutTax = (value is System.DBNull) ? 0 : (long)value;

            // ����l������Ŋz�i�O�Łj
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            salesDisOutTax = (value is System.DBNull) ? 0 : (long)value;

            // ����l�����őΏۊz���v
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedSalesDisInTax = (value is System.DBNull) ? 0 : (long)value;

            // ����l�����őΏۊz���v�i�ō��j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            long itdedSalesDisInTax_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // ����l������Ŋz�i���Łj
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            salesDisTtlTaxInclu = (value is System.DBNull) ? 0 : (long)value;

            // ����l����ېőΏۊz���v
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedSalesDisTaxFre = (value is System.DBNull) ? 0 : (long)value;

            // ����l�����z�v�i�Ŕ��j
            salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

            // �c�������z
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} OR {2}={3}",
                    salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.BalanceAdjust,
                    salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.AccRecBalanceAdjust));
            balanceAdjust = (value is System.DBNull) ? 0 : (long)value;

            // ����Œ����z
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
                string.Format("{0}={1} OR {2}={3}",
                    salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.ConsTaxAdjust,
                    salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.AccRecConsTaxAdjust));
            taxAdjust = (value is System.DBNull) ? 0 : (long)value;

            // �������z�v�i���ŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.CostTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalCost_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // �������z�v�i�O�ŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.CostTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalCost_TaxExc = (value is System.DBNull) ? 0 : (long)value;

            // �������z�v�i��ېŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.CostTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalCost_TaxNone = (value is System.DBNull) ? 0 : (long)value;

            // �������z�v
            totalCost = totalCost_TaxInc + totalCost_TaxExc + totalCost_TaxNone;

            // �e���v�Z�p������z�v�i���ŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalMoney_TaxInc_ForGrossProfitMoney = (value is System.DBNull) ? 0 : (long)value;

            // �e���v�Z�p������z�v�i�O�ŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalMoney_TaxExc_ForGrossProfitMoney = (value is System.DBNull) ? 0 : (long)value;

            // �e���v�Z�p������z�v�i��ېŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            long totalMoney_TaxNone_ForGrossProfitMoney = (value is System.DBNull) ? 0 : (long)value;

            // �e���v�Z�p������z�v
            totalMoneyForGrossProfit = totalMoney_TaxExc_ForGrossProfitMoney + totalMoney_TaxInc_ForGrossProfitMoney + totalMoney_TaxNone_ForGrossProfitMoney;

            // �݌ɏ��i���v���z�i�Ŕ��j�i���ŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // ���ŏ��i AND �݌� AND (���� OR �ԕi OR (�l�� AND �o�א��[��))
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.SalesOrderDivCdColumn, (int)SalesOrderDivCd.Stock,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            long stockGoodsTtlTaxExc_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // �݌ɏ��i���v���z�i�Ŕ��j�i�O�ŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // �O�ŏ��i�i AND �݌� AND (���� OR �ԕi OR (�l�� AND �o�א��[��))
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.SalesOrderDivCdColumn, (int)SalesOrderDivCd.Stock,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            long stockGoodsTtlTaxExc_TaxExc = (value is System.DBNull) ? 0 : (long)value;

            // �݌ɏ��i���v���z�i�Ŕ��j�i��ېŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // ��ېŏ��i AND �݌� AND (���� OR �ԕi OR (�l�� AND �o�א��[��))
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.SalesOrderDivCdColumn, (int)SalesOrderDivCd.Stock,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            long stockGoodsTtlTaxExc_TaxNone = (value is System.DBNull) ? 0 : (long)value;

            // �݌ɏ��i���v���z�i�Ŕ��j
            stockGoodsTtlTaxExc = stockGoodsTtlTaxExc_TaxInc + stockGoodsTtlTaxExc_TaxExc + stockGoodsTtlTaxExc_TaxNone; // �݌ɏ��i���v���z�i�Ŕ��j

            // �������i���v���z�i�Ŕ��j�i���ŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // ���ŏ��i AND ���� AND (���� OR �ԕi OR (�l�� AND �o�א��[��))
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
                    salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            long pureGoodsTtlTaxExc_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            // �������i���v���z�i�Ŕ��j�i�O�ŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // �O�ŏ��i AND ���� AND (���� OR �ԕi OR (�l�� AND �o�א��[��))
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
                    salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            long pureGoodsTtlTaxExc_TaxExc = (value is System.DBNull) ? 0 : (long)value;

            // �������i���v���z�i�Ŕ��j�i��ېŏ��i���j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // ��ې� AND ���� AND (���� OR �ԕi OR (�l�� AND �o�א��[��))
                    salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
                    salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
                    salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            long pureGoodsTtlTaxExc_TaxNone = (value is System.DBNull) ? 0 : (long)value;

            // �������i���v���z�i�Ŕ��j
            pureGoodsTtlTaxExc = pureGoodsTtlTaxExc_TaxInc + pureGoodsTtlTaxExc_TaxExc + pureGoodsTtlTaxExc_TaxNone; // �������i���v���z�i�Ŕ��j

            // ���㕔�i���v�i�ō��j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1} OR {2}={3}",
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salesPrtSubttlInc = (value is System.DBNull) ? 0 : (long)value;

            // ���㕔�i���v�i�Ŕ��j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1} OR {2}={3}",
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            salesPrtSubttlExc = (value is System.DBNull) ? 0 : (long)value;

            // ���i�l���Ώۊz���v�i�ō��j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
                string.Format("{0}={1}",
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedPartsDisInTax = (value is System.DBNull) ? 0 : (long)value;

            // ���i�l���Ώۊz���v�i�Ŕ��j
            value = salesDetailDataTable.Compute(
                string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
                string.Format("{0}={1}",
                    salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            itdedPartsDisOutTax = (value is System.DBNull) ? 0 : (long)value;

            // ���㕔�i���v�i�ō��j
            salesPrtTotalTaxInc = salesPrtSubttlInc + itdedPartsDisInTax;

            // ���㕔�i���v�i�Ŕ��j
            salesPrtTotalTaxExc = salesPrtSubttlExc + itdedPartsDisOutTax;
            #endregion

            #region ���]�ŕ����F��ېł̏ꍇ�ɋ��z�𒲐�����
            //-----------------------------------------------------------------------------
            // �]�ŕ����F��ېł̏ꍇ�ɋ��z�𒲐�����
            //-----------------------------------------------------------------------------
            if (consTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
            {
                // ������z����Ŋz�i�O�Łj
                salesOutTax = 0;

                // ������z����Ŋz�i���Łj
                salAmntConsTaxInclu = 0;

                // ���㏬�v��ېőΏۊz
                salSubttlSubToTaxFre += itdedSalesOutTax + itdedSalesInTax;

                // ����O�őΏۊz
                itdedSalesOutTax = 0;

                // ������őΏۊz
                itdedSalesInTax = 0;

                // ������őΏۊz�i�ō��j
                itdedSalesInTax_TaxInc = 0;

                // ����l������Ŋz�i�O�Łj
                salesDisOutTax = 0;

                // ����l������Ŋz�i���Łj
                salesDisTtlTaxInclu = 0;

                // ����l����ېőΏۊz���v
                itdedSalesDisTaxFre += itdedSalesDisOutTax + itdedSalesDisInTax;

                // ����l���O�őΏۊz���v
                itdedSalesDisOutTax = 0;

                // ����l�����őΏۊz���v
                itdedSalesDisInTax = 0;

                // ����l�����őΏۊz���v�i�ō��j
                itdedSalesDisInTax_TaxInc = 0;

                // ����l�����z�v�i�Ŕ��j
                salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;
            }
            #endregion

            #region ���e����z�Z�o
            //-----------------------------------------------------------------------------
            // �e����z�Z�o
            //-----------------------------------------------------------------------------
            // ���ד]�ňȊO
            if (consTaxLayMethod != (int)ConsTaxLayMethod.DetailLay)
            {
                //-----------------------------------------------------------------------------
                // �@ ����`�[���v�i�Ŕ��j�F����O�őΏۊz + ������őΏۊz + ����l���O�őΏۊz���v + ����l�����őΏۊz���v + ����l����ېőΏۊz���v
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

                //-----------------------------------------------------------------------------
                // �A ����`�[���v�i�ō��j�F ������őΏۊz�i�ō��j + ����O�őΏۊz + ����l�����őΏۊz���v�i�ō��j + ����l���O�őΏۊz���v + ����l����ېőΏۊz���v + (����O�őΏۊz + ����l���O�őΏۊz���v)�~�ŗ�)
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = itdedSalesInTax_TaxInc + itdedSalesOutTax + itdedSalesDisInTax_TaxInc + itdedSalesDisOutTax + itdedSalesDisTaxFre + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // �B ���㏬�v�i�Łj�F�A - �@
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesTotalTaxInc - salesTotalTaxExc;

                //-----------------------------------------------------------------------------
                // �C ������z����Ŋz�i�O�Łj�F����O�őΏۊz �~ �ŗ�
                //-----------------------------------------------------------------------------
                salesOutTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax);

                //-----------------------------------------------------------------------------
                // �D ������z����Ŋz�i�O�Łj(�Ŕ��A�l�����܂�) �F(����O�őΏۊz + ����l���O�őΏۊz���v) �~ �ŗ�
                //-----------------------------------------------------------------------------
                long salesOutTax_All = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

                //-----------------------------------------------------------------------------
                // �E ����l������Ŋz�i�O�Łj�F�C - �D
                //-----------------------------------------------------------------------------
                salesDisOutTax = salesOutTax_All - salesOutTax;

                //-----------------------------------------------------------------------------
                // �F ���㕔�i���v�i�ō��j�F���㕔�i���v�i�Ŕ��j�~ �ŗ�
                //-----------------------------------------------------------------------------
                salesPrtSubttlInc = salesPrtSubttlExc + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, salesPrtSubttlExc);

                //-----------------------------------------------------------------------------
                // �G ���i�l���Ώۊz���v�i�ō��j�F���i�l���Ώۊz���v�i�Ŕ��j�~ �ŗ�
                //-----------------------------------------------------------------------------
                itdedPartsDisInTax = itdedPartsDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedPartsDisOutTax);

                //-----------------------------------------------------------------------------
                // �H ���㕔�i���v�i�ō��j�F(���㕔�i���v�i�Ŕ��j+ ���i�l���Ώۊz���v�i�Ŕ��j) �~ �ŗ�
                //-----------------------------------------------------------------------------
                salesPrtTotalTaxInc = salesPrtSubttlExc + itdedPartsDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, salesPrtSubttlExc + itdedPartsDisOutTax);
            }
            // ���ד]��
            else
            {
                // ---------------------------- ADD �� 2013/12/19 Redmine#41550 No.9----------------------------------->>>>>
                // ������z����Ŋz�i�O�Łj
                salesOutTax = 0;
                // ����l������Ŋz�i�O�Łj
                salesDisOutTax = 0;
                foreach (SalesInputDataSet.SalesDetailAcceptAnOrderRow row in salesDetailDataTable)
                {
                    if (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc) // ���i���O��
                    {
                        // 0:����,1:�ԕi
                        if (row.SalesSlipCdDtl == (int)SalesSlipCdDtl.Sales || row.SalesSlipCdDtl == (int)SalesSlipCdDtl.RetGoods)
                        {
                            // ������z����Ŋz
                            long salesPriceConsTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesMoneyTaxExc);
                            salesOutTax += salesPriceConsTax;
                        }
                        // 2:�l��
                        else if (row.SalesSlipCdDtl == (int)SalesSlipCdDtl.Discount)
                        {
                            // ������z����Ŋz
                            long salesPriceConsTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesMoneyTaxExc);
                            salesDisOutTax += salesPriceConsTax;
                        }
                        // 3:����,4:���v,5:���
                        else
                        {
                            // �Ȃ�
                        }
                    }
                }
                // ---------------------------- ADD �� 2013/12/19 Redmine#41550 No.9-----------------------------------<<<<<
                //-----------------------------------------------------------------------------
                // �@ ���㏬�v�i�Łj�F������z����Ŋz�i�O�Łj + ������z����Ŋz�i���Łj +  ����l������Ŋz�i�O�Łj + ����l������Ŋz�i���Łj
                //-----------------------------------------------------------------------------
                salesSubtotalTax = salesOutTax + salAmntConsTaxInclu + salesDisOutTax + salesDisTtlTaxInclu;

                //-----------------------------------------------------------------------------
                // �A ����`�[���v�i�Ŕ��j�F����O�őΏۊz + ������őΏۊz + ����l���O�őΏۊz���v + ����l�����őΏۊz���v
                //-----------------------------------------------------------------------------
                salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax + itdedSalesDisInTax;

                //-----------------------------------------------------------------------------
                // �B ����`�[���v�i�ō��j�F�@ + �A
                //-----------------------------------------------------------------------------
                salesTotalTaxInc = salesTotalTaxExc + salesSubtotalTax;
            }
            #endregion

            #region �폜
            //// ����Œ[�������P�ʁA�[�������敪���擾
            //int taxFracProcCd = 0;
            //double taxFracProcUnit = 0;
            //this._salesSlipInputInitDataAcs.GetFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);

            //// �f�[�^�e�[�u���̕ύX���R�~�b�g������
            //salesDetailDataTable.AcceptChanges();

            //salesTotalTaxInc = 0;       // ����`�[���v�i�ō��j
            //salesTotalTaxExc = 0;       // ����`�[���v�i�Ŕ��j
            //salesSubtotalTax = 0;       // ���㏬�v�i�Łj
            //itdedSalesOutTax = 0;       // ����O�őΏۊz
            //itdedSalesInTax = 0;        // ������őΏۊz
            //salSubttlSubToTaxFre = 0;   // ���㏬�v��ېőΏۊz
            //salesOutTax = 0;            // ������z����Ŋz�i�O�Łj
            //salAmntConsTaxInclu = 0;    // ������z����Ŋz�i���Łj
            //salesDisTtlTaxExc = 0;      // ����l�����z�v�i�Ŕ��j
            //itdedSalesDisOutTax = 0;    // ����l���O�őΏۊz���v
            //itdedSalesDisInTax = 0;     // ����l�����őΏۊz���v
            //itdedSalesDisTaxFre = 0;    // ����l����ېőΏۊz���v
            //salesDisOutTax = 0;         // ����l������Ŋz�i�O�Łj
            //salesDisTtlTaxInclu = 0;    // ����l������Ŋz�i���Łj
            //stockGoodsTtlTaxExc = 0;    // �݌ɏ��i���v���z�i�Ŕ��j
            //pureGoodsTtlTaxExc = 0;     // �������i���v���z�i�Ŕ��j
            //totalCost = 0;              // �������z�v
            //taxAdjust = 0;              // ����Œ����z
            //balanceAdjust = 0;          // �c�������z
            //salesPrtSubttlInc = 0;      // ���㕔�i���v�i�ō��j
            //salesPrtSubttlExc = 0;      // ���㕔�i���v�i�Ŕ��j
            //salesWorkSubttlInc = 0;     // �����Ə��v�i�ō��j
            //salesWorkSubttlExc = 0;     // �����Ə��v�i�Ŕ��j
            //itdedPartsDisInTax = 0;     // ���i�l���Ώۊz���v�i�ō��j
            //itdedPartsDisOutTax = 0;    // ���i�l���Ώۊz���v�i�Ŕ��j
            //itdedWorkDisInTax = 0;      // ��ƒl���Ώۊz���v�i�ō��j
            //itdedWorkDisOutTax = 0;     // ��ƒl���Ώۊz���v�i�Ŕ��j
            //totalMoneyForGrossProfit = 0; // �e���v�Z�p������z

            //object value = null;

            ////-----------------------------------------------------------------------------
            //// �v�Z�ɕK�v�ȋ��z�̌v�Z
            ////-----------------------------------------------------------------------------
            //#region ���v�Z�ɕK�v�ȋ��z�̌v�Z
            //// ����O�őΏۊz
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            //itdedSalesOutTax = (value is System.DBNull) ? 0 : (long)value;

            //// ������z����Ŋz�i�O�Łj
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
            //    string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            //salesOutTax = (value is System.DBNull) ? 0 : (long)value;

            //// ������őΏۊz
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            //itdedSalesInTax = (value is System.DBNull) ? 0 : (long)value;

            //// ������őΏۊz�i�ō��j
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
            //    string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            //long itdedSalesInTax_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            //// ������z����Ŋz�i���Łj
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
            //    string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            //salAmntConsTaxInclu = (value is System.DBNull) ? 0 : (long)value;

            //// ���㏬�v��ېőΏۊz
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
            //    string.Format("{0}={1} AND ({2}={3} OR {4}={5})",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            //salSubttlSubToTaxFre = (value is System.DBNull) ? 0 : (long)value;

            //// ����l���O�őΏۊz���v
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            //itdedSalesDisOutTax = (value is System.DBNull) ? 0 : (long)value;

            //// ����l������Ŋz�i�O�Łj
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            //salesDisOutTax = (value is System.DBNull) ? 0 : (long)value;

            //// ����l�����őΏۊz���v
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            //itdedSalesDisInTax = (value is System.DBNull) ? 0 : (long)value;

            //// ����l�����őΏۊz���v�i�ō��j
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            //long itdedSalesDisInTax_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            //// ����l������Ŋz�i���Łj
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            //salesDisTtlTaxInclu = (value is System.DBNull) ? 0 : (long)value;

            //// ����l����ېőΏۊz���v
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            //itdedSalesDisTaxFre = (value is System.DBNull) ? 0 : (long)value;

            //// ����l�����z�v�i�Ŕ��j
            //salesDisTtlTaxExc = itdedSalesDisOutTax + itdedSalesDisInTax + itdedSalesDisTaxFre;

            //// �c�������z
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
            //    string.Format("{0}={1} OR {2}={3}",
            //        salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.BalanceAdjust,
            //        salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.AccRecBalanceAdjust));
            //balanceAdjust = (value is System.DBNull) ? 0 : (long)value;

            //// ����Œ����z
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesPriceConsTaxColumn.ColumnName),
            //    string.Format("{0}={1} OR {2}={3}",
            //        salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.ConsTaxAdjust,
            //        salesDetailDataTable.SalesGoodsCdColumn.ColumnName, (int)SalesGoodsCd.AccRecConsTaxAdjust));
            //taxAdjust = (value is System.DBNull) ? 0 : (long)value;

            //// �������z�v�i���ŏ��i���j
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.CostTaxIncColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            //long totalCost_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            //// �������z�v�i�O�ŏ��i���j
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.CostTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            //long totalCost_TaxExc = (value is System.DBNull) ? 0 : (long)value;

            //// �������z�v�i��ېŏ��i���j
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.CostTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            //long totalCost_TaxNone = (value is System.DBNull) ? 0 : (long)value;

            //// �������z�v
            //totalCost = totalCost_TaxInc + totalCost_TaxExc + totalCost_TaxNone;

            //// �e���v�Z�p������z�v�i���ŏ��i���j
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            //long totalMoney_TaxInc_ForGrossProfitMoney = (value is System.DBNull) ? 0 : (long)value;

            //// �e���v�Z�p������z�v�i�O�ŏ��i���j
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            //long totalMoney_TaxExc_ForGrossProfitMoney = (value is System.DBNull) ? 0 : (long)value;

            //// �e���v�Z�p������z�v�i��ېŏ��i���j
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}<>{3} AND {4}<>{5}",
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Annotation,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Subtotal));
            //long totalMoney_TaxNone_ForGrossProfitMoney = (value is System.DBNull) ? 0 : (long)value;

            //// �e���v�Z�p������z�v
            //totalMoneyForGrossProfit = totalMoney_TaxExc_ForGrossProfitMoney + totalMoney_TaxInc_ForGrossProfitMoney + totalMoney_TaxNone_ForGrossProfitMoney;

            //// �݌ɏ��i���v���z�i�Ŕ��j�i���ŏ��i���j
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // ���ŏ��i AND �݌� AND (���� OR �ԕi OR (�l�� AND �o�א��[��))
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.SalesOrderDivCdColumn, (int)SalesOrderDivCd.Stock,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
            //        salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            //long stockGoodsTtlTaxExc_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            //// �݌ɏ��i���v���z�i�Ŕ��j�i�O�ŏ��i���j
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // �O�ŏ��i�i AND �݌� AND (���� OR �ԕi OR (�l�� AND �o�א��[��))
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxExc,
            //        salesDetailDataTable.SalesOrderDivCdColumn, (int)SalesOrderDivCd.Stock,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
            //        salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            //long stockGoodsTtlTaxExc_TaxExc = (value is System.DBNull) ? 0 : (long)value;

            //// �݌ɏ��i���v���z�i�Ŕ��j�i��ېŏ��i���j
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // ��ېŏ��i AND �݌� AND (���� OR �ԕi OR (�l�� AND �o�א��[��))
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
            //        salesDetailDataTable.SalesOrderDivCdColumn, (int)SalesOrderDivCd.Stock,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
            //        salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            //long stockGoodsTtlTaxExc_TaxNone = (value is System.DBNull) ? 0 : (long)value;

            //// �݌ɏ��i���v���z�i�Ŕ��j
            //stockGoodsTtlTaxExc = stockGoodsTtlTaxExc_TaxInc + stockGoodsTtlTaxExc_TaxExc + stockGoodsTtlTaxExc_TaxNone; // �݌ɏ��i���v���z�i�Ŕ��j

            //// �������i���v���z�i�Ŕ��j�i���ŏ��i���j
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // ���ŏ��i AND ���� AND (���� OR �ԕi OR (�l�� AND �o�א��[��))
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
            //        salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            //long pureGoodsTtlTaxExc_TaxInc = (value is System.DBNull) ? 0 : (long)value;

            //// �������i���v���z�i�Ŕ��j�i�O�ŏ��i���j
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // �O�ŏ��i AND ���� AND (���� OR �ԕi OR (�l�� AND �o�א��[��))
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxInc,
            //        salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
            //        salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            //long pureGoodsTtlTaxExc_TaxExc = (value is System.DBNull) ? 0 : (long)value;

            //// �������i���v���z�i�Ŕ��j�i��ېŏ��i���j
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} AND {2}={3} AND ({4}={5} OR {6}={7} OR ({8}={9} AND {10}<>{11}))",  // ��ې� AND ���� AND (���� OR �ԕi OR (�l�� AND �o�א��[��))
            //        salesDetailDataTable.TaxationDivCdColumn.ColumnName, (int)CalculateTax.TaxationCode.TaxNone,
            //        salesDetailDataTable.GoodsKindCodeColumn, (int)GoodsKindCode.PureGoods,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount,
            //        salesDetailDataTable.ShipmentCntColumn.ColumnName, 0));
            //long pureGoodsTtlTaxExc_TaxNone = (value is System.DBNull) ? 0 : (long)value;

            //// �������i���v���z�i�Ŕ��j
            //pureGoodsTtlTaxExc = pureGoodsTtlTaxExc_TaxInc + pureGoodsTtlTaxExc_TaxExc + pureGoodsTtlTaxExc_TaxNone; // �������i���v���z�i�Ŕ��j

            //// ���㕔�i���v�i�ō��j
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
            //    string.Format("{0}={1} OR {2}={3}",
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            //salesPrtSubttlInc = (value is System.DBNull) ? 0 : (long)value;

            //// ���㕔�i���v�i�Ŕ��j
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1} OR {2}={3}",
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Sales,
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.RetGoods));
            //salesPrtSubttlExc = (value is System.DBNull) ? 0 : (long)value;

            //// ���i�l���Ώۊz���v�i�ō��j
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxIncColumn.ColumnName),
            //    string.Format("{0}={1}",
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            //itdedPartsDisInTax = (value is System.DBNull) ? 0 : (long)value;

            //// ���i�l���Ώۊz���v�i�Ŕ��j
            //value = salesDetailDataTable.Compute(
            //    string.Format("SUM({0})", salesDetailDataTable.SalesMoneyTaxExcColumn.ColumnName),
            //    string.Format("{0}={1}",
            //        salesDetailDataTable.SalesSlipCdDtlColumn.ColumnName, (int)SalesSlipCdDtl.Discount));
            //itdedPartsDisOutTax = (value is System.DBNull) ? 0 : (long)value;
            //#endregion

            //// ���z�\������
            //if (totalAmountDispWayCd == 1)
            //{
            //    //-----------------------------------------------------------------------------
            //    // �@ ����`�[���v�i�ō��j�F����O�őΏۊz + ������z����Ŋz�i�O�Łj + ������őΏۊz�i�ō��j +  ����l�����őΏۊz���v�i�ō��j
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxInc = itdedSalesOutTax + salesOutTax + itdedSalesInTax_TaxInc + itdedSalesDisInTax_TaxInc;

            //    //-----------------------------------------------------------------------------
            //    // �A ���㏬�v�i�Łj�F�@������ł��v�Z
            //    //-----------------------------------------------------------------------------
            //    salesSubtotalTax = CalculateTax.GetTaxFromPriceInc(consTaxRate, taxFracProcUnit, taxFracProcCd, salesTotalTaxInc);

            //    //-----------------------------------------------------------------------------
            //    // �B ����`�[���v�i�Ŕ��j�F�A - �@
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxExc = salesTotalTaxInc - salesSubtotalTax;
            //}
            //// ���z�\���Ȃ� �`�[�]�ňȊO
            //else if (consTaxLayMethod != 0)
            //{
            //    //-----------------------------------------------------------------------------
            //    // �@ ���㏬�v�i�Łj�F������z����Ŋz�i�O�Łj + ������z����Ŋz�i���Łj +  ����l������Ŋz�i�O�Łj + ����l������Ŋz�i���Łj
            //    //-----------------------------------------------------------------------------
            //    salesSubtotalTax = salesOutTax + salAmntConsTaxInclu + salesDisOutTax + salesDisTtlTaxInclu;

            //    //-----------------------------------------------------------------------------
            //    // �A ����`�[���v�i�Ŕ��j�F����O�őΏۊz + ������őΏۊz + ����l���O�őΏۊz���v
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax;

            //    //-----------------------------------------------------------------------------
            //    // �B ����`�[���v�i�ō��j�F�@ + �A
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxInc = salesTotalTaxExc + salesSubtotalTax;
            //}
            //// ���z�\�������ŁA�`�[�]��
            //else
            //{
            //    //-----------------------------------------------------------------------------
            //    // �@ ����`�[���v�i�Ŕ��j�F����O�őΏۊz + ������őΏۊz + ����l���O�őΏۊz���v
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxExc = itdedSalesOutTax + itdedSalesInTax + itdedSalesDisOutTax;

            //    //-----------------------------------------------------------------------------
            //    // �A ����`�[���v�i�ō��j�F ������őΏۊz�i�ō��j + ����O�őΏۊz + ����l���O�őΏۊz���v �{ (����O�őΏۊz + ����l���O�őΏۊz���v)�~�ŗ�)
            //    //-----------------------------------------------------------------------------
            //    salesTotalTaxInc = itdedSalesInTax_TaxInc + itdedSalesOutTax + itdedSalesDisOutTax + CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

            //    //-----------------------------------------------------------------------------
            //    // �B ���㏬�v�i�Łj�F�A - �@
            //    //-----------------------------------------------------------------------------
            //    salesSubtotalTax = salesTotalTaxInc - salesTotalTaxExc;

            //    //-----------------------------------------------------------------------------
            //    // �C ������z����Ŋz�i�O�Łj�F����O�őΏۊz �~ �ŗ�
            //    //-----------------------------------------------------------------------------
            //    salesOutTax = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax);

            //    //-----------------------------------------------------------------------------
            //    // �D ������z����Ŋz�i�O�Łj(�Ŕ��A�l�����܂�) �F(����O�őΏۊz + ����l���O�őΏۊz���v) �~ �ŗ�
            //    //-----------------------------------------------------------------------------
            //    long salesOutTax_All = CalculateTax.GetTaxFromPriceExc(consTaxRate, taxFracProcUnit, taxFracProcCd, itdedSalesOutTax + itdedSalesDisOutTax);

            //    //-----------------------------------------------------------------------------
            //    // �E ����l������Ŋz�i�O�Łj�F�C - �D
            //    //-----------------------------------------------------------------------------
            //    salesDisOutTax = salesOutTax_All - salesOutTax;
            //}
            #endregion
        }

        // ---------------------------- ADD �� 2013/12/19 Redmine#41550 No.9----------------------------------->>>>>
        /// <summary>
        /// �󒍖��ׂ̍X�V
        /// </summary>
        /// <param name="salesDetailDataTable"></param>
        /// <param name="consTaxRate"></param>
        private void UpdateAcptAnOrdDetailDT(SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailDataTable, SalesSlip salesSlip)
        {
            // ����Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// ����Œ[�������R�[�h
            // ����Œ[�������P�ʁA�[�������敪���擾
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            // ----------------------------------------------------------------
            // ��Q����
            // �󒍓`�[�̏ꍇ�A����O�̎󒍓`�[�͏C�����[�h�ŌĂяo���A������͉����֕ύX���A
            // �ۑ�����ۂɁA�[�i���ɏ���ł�����O�̒l�ŕ\�������
            // ----------------------------------------------------------------
            foreach (SalesInputDataSet.SalesDetailAcceptAnOrderRow row in salesDetailDataTable)
            {
                if (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc) // ���i���O��
                {
                    // -----------------------------------------------
                    // ���׃f�[�^�ɐō��̍��ڂƏ���ł��X�V����K�v
                    // �X�V���Ȃ��ƁA���L�̌��ۂ�����
                    // ���ہF���Ӑ�d�q�����ɂČ������āA�u�`�[�\���v�Ɓu���ו\���v�̏���ł��Ⴄ
                    // -----------------------------------------------
                    row.ListPriceTaxIncFl = row.ListPriceTaxExcFl + CalculateTax.GetTaxFromPriceExc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, row.ListPriceTaxExcFl);
                    // ����P���i�ō��j= ����P��(�Ŕ�) + (����P��(�Ŕ�) * �ŗ�)
                    row.SalesUnPrcTaxIncFl = row.SalesUnPrcTaxExcFl + CalculateTax.GetTaxFromPriceExc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesUnPrcTaxExcFl);
                    // ������z�i�ō��j= ������z(�Ŕ�) + (������z(�Ŕ�) * �ŗ�)
                    row.SalesMoneyTaxInc = row.SalesMoneyTaxExc + CalculateTax.GetTaxFromPriceExc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesMoneyTaxExc);
                    // ������z����Ŋz
                    row.SalesPriceConsTax = CalculateTax.GetTaxFromPriceExc(salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, row.SalesMoneyTaxExc);
                }
            }
        }

        // ---------------------------- ADD �� 2013/12/19 Redmine#41550 No.9-----------------------------------<<<<<

        /// <summary>
        /// �w�肵��������z�̒l�����ɔ��㖾�׍s�I�u�W�F�N�g�̋��z����ݒ肵�܂��i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesRowNo">�s�ԍ�</param>
        /// <param name="salesMoney">������z</param>
        /// <param name="salesRateClearFlag">�P�����N���A�elag</param>
        // --- UPD 2009/12/23 ---------->>>>>
        //public void SalesDetailRowSalesMoneySetting(int salesRowNo, long salesMoney)
        public void SalesDetailRowSalesMoneySetting(int salesRowNo, long salesMoney, bool salesRateClearFlag)
        // --- UPD 2009/12/23 ----------<<<<<
        {
            // --- UPD 2009/12/23 ---------->>>>>
            //this.SalesDetailRowSalesMoneySetting(salesRowNo, salesMoney, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
            this.SalesDetailRowSalesMoneySetting(salesRowNo, salesMoney, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable, salesRateClearFlag);
            // --- UPD 2009/12/23 ----------<<<<<
        }

        /// <summary>
        /// �w�肵��������z�̒l�����ɔ��㖾�׍s�I�u�W�F�N�g�̋��z����ݒ肵�܂��i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesRowNo">�s�ԍ�</param>
        /// <param name="salesMoney">������z</param>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">�󒍖��׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        /// <param name="salesRateClearFlag">�P�����N���A�elag</param>
        // --- UPD 2009/12/23 ---------->>>>>
        //public void SalesDetailRowSalesMoneySetting(int salesRowNo, long salesMoney, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        public void SalesDetailRowSalesMoneySetting(int salesRowNo, long salesMoney, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable, bool salesRateClearFlag)
        // --- UPD 2009/12/23 ----------<<<<<
        {
            #region ����������
            SalesInputDataSet.SalesDetailRow row = salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);

            // ����Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            int sign = 1;
            if (this._salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) sign = -1;
            salesMoney = salesMoney * sign;
            #endregion

            #region ��������
            if (row != null)
            {
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                {
                    //-----------------------------------------------------
                    // ��ې�
                    //-----------------------------------------------------
                    row.SalesMoneyTaxExc = salesMoney;
                    row.SalesMoneyTaxInc = salesMoney;
                }
                else if (this._salesSlip.TotalAmountDispWayCd == 0)
                {
                    //-----------------------------------------------------
                    // ���z�\�����Ȃ�
                    //-----------------------------------------------------
                    switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            row.SalesMoneyTaxExc = salesMoney;
                            row.SalesMoneyTaxInc = salesMoney + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoney);
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            row.SalesMoneyTaxExc = salesMoney - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoney);
                            row.SalesMoneyTaxInc = salesMoney;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            row.SalesMoneyTaxExc = salesMoney;
                            row.SalesMoneyTaxInc = salesMoney;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    //-----------------------------------------------------
                    // ���z�\������
                    //-----------------------------------------------------
                    switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            row.SalesMoneyTaxExc = salesMoney - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoney);
                            row.SalesMoneyTaxInc = salesMoney;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            row.SalesMoneyTaxExc = salesMoney - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoney);
                            row.SalesMoneyTaxInc = salesMoney;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            row.SalesMoneyTaxExc = salesMoney;
                            row.SalesMoneyTaxInc = salesMoney;
                            break;
                    }
                }

                row.SalesPriceConsTax = row.SalesMoneyTaxInc - row.SalesMoneyTaxExc;

                // �P�����N���A
                // --- UPD 2009/12/23 ---------->>>>>
                //this.ClearUnitInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                if (salesRateClearFlag == true)
                {
                    this.ClearUnitInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                }
                // --- UPD 2009/12/23 ----------<<<<<

                // ����P���ύX�敪�ݒ�
                if (row.SalesUnPrcTaxExcFl != row.BfSalesUnitPrice)
                {
                    row.SalesUnPrcChngCd = 1; // �ύX����
                }
                else
                {
                    row.SalesUnPrcChngCd = 0; // �ύX�Ȃ�
                }
            }
            #endregion

            #region ���󒍏��
            if (acptAnOdrRow != null)
            {
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                {
                    //-----------------------------------------------------
                    // ��ې�
                    //-----------------------------------------------------
                    acptAnOdrRow.SalesMoneyTaxExc = salesMoney;
                    acptAnOdrRow.SalesMoneyTaxInc = salesMoney;
                }
                else if (this._salesSlip.TotalAmountDispWayCd == 0)
                {
                    //-----------------------------------------------------
                    // ���z�\�����Ȃ�
                    //-----------------------------------------------------
                    switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            acptAnOdrRow.SalesMoneyTaxExc = salesMoney;
                            acptAnOdrRow.SalesMoneyTaxInc = salesMoney + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoney);
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            acptAnOdrRow.SalesMoneyTaxExc = salesMoney - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoney);
                            acptAnOdrRow.SalesMoneyTaxInc = salesMoney;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            acptAnOdrRow.SalesMoneyTaxExc = salesMoney;
                            acptAnOdrRow.SalesMoneyTaxInc = salesMoney;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    //-----------------------------------------------------
                    // ���z�\������
                    //-----------------------------------------------------
                    switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            acptAnOdrRow.SalesMoneyTaxExc = salesMoney - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoney);
                            acptAnOdrRow.SalesMoneyTaxInc = salesMoney;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            acptAnOdrRow.SalesMoneyTaxExc = salesMoney - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, salesMoney);
                            acptAnOdrRow.SalesMoneyTaxInc = salesMoney;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            acptAnOdrRow.SalesMoneyTaxExc = salesMoney;
                            acptAnOdrRow.SalesMoneyTaxInc = salesMoney;
                            break;
                    }
                }

                acptAnOdrRow.SalesPriceConsTax = acptAnOdrRow.SalesMoneyTaxInc - acptAnOdrRow.SalesMoneyTaxExc;

                // �P�����N���A
                // --- UPD 2009/12/23 ---------->>>>>
                //this.ClearUnitInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                if (salesRateClearFlag == true)
                {
                    this.ClearUnitInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
                }
                // --- UPD 2009/12/23 ----------<<<<<

                // ����P���ύX�敪�ݒ�
                if (acptAnOdrRow.SalesUnPrcTaxExcFl != acptAnOdrRow.BfSalesUnitPrice)
                {
                    acptAnOdrRow.SalesUnPrcChngCd = 1; // �ύX����
                }
                else
                {
                    acptAnOdrRow.SalesUnPrcChngCd = 0; // �ύX�Ȃ�
                }
            }
            #endregion
        }

        /// <summary>
        /// ������z���v�Z���܂��B�i���ו����z�j�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="rowIndex">�ΏۍsIndex</param>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u��</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">�󒍖��׃f�[�^�e�[�u��</param>
        private void CalculationSalesMoney(int rowIndex, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        {
            SalesInputDataSet.SalesDetailRow salesDetailRow = salesDetailDataTable[rowIndex];
            this.CalculationSalesMoney(salesDetailRow, salesDetailDataTable, salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// ������z���v�Z���܂��B�i���ו����z�j�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="rowNo">�Ώۍs�ԍ�</param>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u��</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">�󒍖��׃f�[�^�e�[�u��</param>
        private void CalculationSalesMoney(string salesSlipNum, int rowNo, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        {
            SalesInputDataSet.SalesDetailRow salesDetailRow = salesDetailDataTable.FindBySalesSlipNumSalesRowNo(salesSlipNum, rowNo);
            this.CalculationSalesMoney(salesDetailRow, salesDetailDataTable, salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// ������z���v�Z���܂��B�i���ו����z�j�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesDetailRow">���㖾�׃f�[�^�s�I�u�W�F�N�g</param>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u��</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">�󒍖��׃f�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Call�F���i�����^�艿�^���P���^�������^���P���^�������^������z �ύX��</br>
        /// </remarks>
        private void CalculationSalesMoney(SalesInputDataSet.SalesDetailRow salesDetailRow, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        {
            #region ����������
            SalesSlip salesSlip = this.SalesSlip;
            if (salesSlip == null) return;
            int sign = (salesSlip.SalesSlipCd == (int)SalesSlipInputAcs.SalesSlipCd.RetGoods) ? -1 : 1;

            // �󒍖��׍s�I�u�W�F�N�g�擾
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(salesDetailRow.DtlRelationGuid);
            #endregion

            #region �����z�Z��
            switch ((SalesGoodsCd)salesDetailRow.SalesGoodsCd)
            {
                // ���i
                case SalesGoodsCd.Goods:

                    #region ��������
                    long salesMoneyTaxInc;
                    long salesMoneyTaxExc;
                    long salesMoneyDisplay;

                    if (this.CalculationSalesMoney(salesSlip, salesDetailRow, out salesMoneyTaxInc, out salesMoneyTaxExc, out salesMoneyDisplay))
                    {
                        salesDetailRow.SalesMoneyTaxExc = salesMoneyTaxExc;        // �O��
                        salesDetailRow.SalesMoneyTaxInc = salesMoneyTaxInc;        // ����
                        salesDetailRow.SalesPriceConsTax = (long)((decimal)salesMoneyTaxInc - (decimal)salesMoneyTaxExc);
                        salesDetailRow.SalesMoneyDisplay = salesMoneyDisplay * sign;
                    }
                    #endregion

                    #region ���󒍏��
                    if (acptAnOdrRow != null)
                    {
                        if (this.CalculationSalesMoney(salesSlip, acptAnOdrRow, out salesMoneyTaxInc, out salesMoneyTaxExc, out salesMoneyDisplay))
                        {
                            acptAnOdrRow.SalesMoneyTaxExc = salesMoneyTaxExc;        // �O��
                            acptAnOdrRow.SalesMoneyTaxInc = salesMoneyTaxInc;        // ����
                            acptAnOdrRow.SalesPriceConsTax = (long)((decimal)salesMoneyTaxInc - (decimal)salesMoneyTaxExc);
                            acptAnOdrRow.SalesMoneyDisplay = salesMoneyDisplay * sign;
                        }
                    }
                    #endregion
                    break;
                // ����Œ���
                case SalesGoodsCd.ConsTaxAdjust:
                case SalesGoodsCd.AccRecConsTaxAdjust:
                    salesDetailRow.SalesMoneyDisplay = salesDetailRow.SalesPriceConsTax;
                    break;
                // �c������
                case SalesGoodsCd.BalanceAdjust:
                case SalesGoodsCd.AccRecBalanceAdjust:
                    salesDetailRow.SalesMoneyDisplay = salesDetailRow.SalesMoneyTaxInc;
                    break;
            }
            #endregion
        }

        /// <summary>
        /// ������z���v�Z���܂��B�i���ו����z�j�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesSlip"></param>
        /// <param name="salesDetailRow"></param>
        /// <param name="salesMoneyTaxInc"></param>
        /// <param name="salesMoneyTaxExc"></param>
        /// <param name="salesMoneyDisplay"></param>
        /// <returns></returns>
        public bool CalculationSalesMoney(SalesSlip salesSlip, SalesInputDataSet.SalesDetailRow salesDetailRow, out long salesMoneyTaxInc, out long salesMoneyTaxExc, out long salesMoneyDisplay)
        {
            // ������z���Z��
            double taxRate = salesSlip.ConsTaxRate;

            // ������z�[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesMoneyFrcProcCode = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.MoneyFrcProcCd);

            // ����Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // ����Œ[�������P�ʁA�敪�擾
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            // �ېŋ敪
            int taxationCode = salesDetailRow.TaxationDivCd;

            double salesUnPrc = 0;// ����P��(�Ŕ�)
            if ((salesDetailRow.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc) || // ����
                (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount)) // ���z�\������(���z�\������ꍇ�A���Ōv�Z���s��)
            {
                // ����
                salesUnPrc = salesDetailRow.SalesUnPrcTaxIncFl;
            }
            else
            {
                // �O��/��ې�
                salesUnPrc = salesDetailRow.SalesUnPrcTaxExcFl;
            }

            // ��ې�
            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
            }
            // ���z�\�����͓��łŌv�Z����
            else if (this._salesSlip.TotalAmountDispWayCd == (int)SalesSlipInputAcs.TotalAmountDispWayCd.TotalAmount)
            {
                // ���z�\������
                if (salesDetailRow.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    taxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                }
            }
            bool ret = true;
            if ((salesDetailRow.SalesSlipCdDtl == (int)SalesSlipCdDtl.Discount) && (salesDetailRow.ShipmentCnt == 0)) // �s�l����
            {
                salesMoneyTaxInc = salesDetailRow.SalesMoneyTaxInc;
                salesMoneyTaxExc = salesDetailRow.SalesMoneyTaxExc;
            }
            else if (salesDetailRow.SalesMoneyInputDiv == (int)SalesMoneyInputDiv.Input) // ������z�����
            {
                int sign = (salesDetailRow.ShipmentCnt < 0) ? -1 : 1;
                salesMoneyTaxInc = Math.Abs(salesDetailRow.SalesMoneyTaxInc) * sign;
                salesMoneyTaxExc = Math.Abs(salesDetailRow.SalesMoneyTaxExc) * sign;
            }
            else
            {
                int sign = (salesSlip.SalesSlipCd == (int)SalesSlipCd.RetGoods) ? -1 : 1;
                ret = this.CalculationSalesMoney(
                    salesDetailRow.ShipmentCntDisplay * sign,
                    salesUnPrc,
                    taxationCode,
                    taxRate,
                    salesMoneyFrcProcCode,
                    salesCnsTaxFrcProcCd,
                    out salesMoneyTaxInc,
                    out salesMoneyTaxExc);
            }

            if ((salesDetailRow.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc) ||
                (salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount))
            {
                salesMoneyDisplay = salesMoneyTaxInc; // �\�����z���ō�
            }
            else
            {
                salesMoneyDisplay = salesMoneyTaxExc; // �\�����z���Ŕ�
            }

            return ret;
        }

        /// <summary>
        /// ������z���v�Z���܂��B�i���ו����z�j
        /// </summary>
        /// <param name="shipmentCnt">����</param>
        /// <param name="salesUnitPrice">�P��</param>
        /// <param name="taxationDivCd">�ېŋ敪</param>
        /// <param name="salesMoneyTaxInc">���z(�ō�)</param>
        /// <param name="salesMoneyTaxExc">���z(�Ŕ�)</param>
        /// <param name="salesMoneyDisplay">���z(�\��)</param>
        /// <returns></returns>
        public bool CalculationSalesMoney(double shipmentCnt, double salesUnitPrice, int taxationDivCd, out long salesMoneyTaxInc, out long salesMoneyTaxExc, out long salesMoneyDisplay)
        {
            // ������z���Z��
            double taxRate = this._salesSlip.ConsTaxRate;

            // ������z�[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesMoneyFrcProcCode = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.MoneyFrcProcCd);

            // ����Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // ����Œ[�������P�ʁA�敪�擾
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            // ��ې�
            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
            {
                taxationDivCd = (int)CalculateTax.TaxationCode.TaxNone;
            }
            // ���z�\�����͓��łŌv�Z����
            if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount)
            {
                if (taxationDivCd == (int)CalculateTax.TaxationCode.TaxExc) taxationDivCd = (int)CalculateTax.TaxationCode.TaxInc;
            }

            bool ret = this.CalculationSalesMoney(
                shipmentCnt,
                salesUnitPrice,
                taxationDivCd,
                taxRate,
                salesMoneyFrcProcCode,
                salesCnsTaxFrcProcCd,
                out salesMoneyTaxInc,
                out salesMoneyTaxExc);

            if ((taxationDivCd == (int)CalculateTax.TaxationCode.TaxInc) ||
                (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount))
            {
                salesMoneyDisplay = salesMoneyTaxInc; // �\�����z���ō�
            }
            else
            {
                salesMoneyDisplay = salesMoneyTaxExc; // �\�����z���Ŕ�
            }

            return ret;
        }

        /// <summary>
        /// ������z���v�Z���܂��B�i���ו����z�j�i�󒍏��j�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="acptAnOdrRow"></param>
        private void CalculationSalesMoney(ref SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow)
        {
            #region ����������
            SalesSlip salesSlip = this.SalesSlip;
            if (salesSlip == null) return;
            #endregion

            #region �����z�Z��
            if (acptAnOdrRow != null)
            {
                long salesMoneyTaxInc;
                long salesMoneyTaxExc;
                long salesMoneyDisplay;

                if (this.CalculationSalesMoney(salesSlip, acptAnOdrRow, out salesMoneyTaxInc, out salesMoneyTaxExc, out salesMoneyDisplay))
                {
                    acptAnOdrRow.SalesMoneyTaxExc = salesMoneyTaxExc;        // �O��
                    acptAnOdrRow.SalesMoneyTaxInc = salesMoneyTaxInc;        // ����
                    acptAnOdrRow.SalesPriceConsTax = (long)((decimal)salesMoneyTaxInc - (decimal)salesMoneyTaxExc);
                    acptAnOdrRow.SalesMoneyDisplay = salesMoneyDisplay;
                }
            }
            #endregion
        }

        /// <summary>
        /// ������z���v�Z���܂��B�i���ו����z�j�i�󒍏��j�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesSlip"></param>
        /// <param name="salesDetailRow"></param>
        /// <param name="salesMoneyTaxInc"></param>
        /// <param name="salesMoneyTaxExc"></param>
        /// <param name="salesMoneyDisplay"></param>
        /// <returns></returns>
        public bool CalculationSalesMoney(SalesSlip salesSlip, SalesInputDataSet.SalesDetailAcceptAnOrderRow salesDetailRow, out long salesMoneyTaxInc, out long salesMoneyTaxExc, out long salesMoneyDisplay)
        {
            double taxRate = salesSlip.ConsTaxRate;

            // ������z�[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesMoneyFrcProcCode = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.MoneyFrcProcCd);

            // ����Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // ����Œ[�������P�ʁA�敪�擾
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            // �ېŋ敪
            int taxationCode = salesDetailRow.TaxationDivCd;

            double salesUnPrc = 0;// ����P��(�Ŕ�)
            if ((salesDetailRow.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc) || // ����
                (this._salesSlip.TotalAmountDispWayCd == 1)) // ���z�\������(���z�\������ꍇ�A���Ōv�Z���s��)
            {
                // ����
                salesUnPrc = salesDetailRow.SalesUnPrcTaxIncFl;
            }
            else
            {
                // �O��/��ې�
                salesUnPrc = salesDetailRow.SalesUnPrcTaxExcFl;
            }

            // ��ې�
            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
            }
            // ���z�\�����͓��łŌv�Z����
            else if (this._salesSlip.TotalAmountDispWayCd == 1)
            {
                // ���z�\������
                if (salesDetailRow.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxExc)
                {
                    taxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                }
            }


            bool ret = true;
            if ((salesDetailRow.SalesSlipCdDtl == (int)SalesSlipCdDtl.Discount) && (salesDetailRow.ShipmentCnt == 0)) // �s�l����
            {
                salesMoneyTaxInc = salesDetailRow.SalesMoneyTaxInc;
                salesMoneyTaxExc = salesDetailRow.SalesMoneyTaxExc;
            }
            else if (salesDetailRow.SalesMoneyInputDiv == (int)SalesMoneyInputDiv.Input) // ������z�����
            {
                int sign = (salesDetailRow.ShipmentCnt < 0) ? -1 : 1;
                salesMoneyTaxInc = Math.Abs(salesDetailRow.SalesMoneyTaxInc) * sign;
                salesMoneyTaxExc = Math.Abs(salesDetailRow.SalesMoneyTaxExc) * sign;
            }
            else
            {
                int sign = (salesSlip.SalesSlipCd == (int)SalesSlipCd.RetGoods) ? -1 : 1;
                ret = this.CalculationSalesMoney(
                    salesDetailRow.AcceptAnOrderCntDisplay,
                    salesUnPrc,
                    taxationCode,
                    taxRate,
                    salesMoneyFrcProcCode,
                    salesCnsTaxFrcProcCd,
                    out salesMoneyTaxInc,
                    out salesMoneyTaxExc);
            }

            if ((salesDetailRow.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxInc) ||
                (salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount))
            {
                salesMoneyDisplay = salesMoneyTaxInc; // �\�����z���ō�
            }
            else
            {
                salesMoneyDisplay = salesMoneyTaxExc; // �\�����z���Ŕ�
            }

            return ret;

        }

        /// <summary>
        /// ������z���v�Z���܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesDetailList"></param>
        public void CalculationSalesMoney(List<SalesDetail> salesDetailList)
        {
            foreach (SalesDetail salesDetail in salesDetailList)
            {
                this.CalculationSalesMoney(salesDetail.SalesSlipNum, salesDetail.SalesRowNo);
            }
        }

        /// <summary>
        /// ������z���v�Z���܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="rowIndex">�ΏۍsIndex</param>
        /// <remarks>
        /// <br>Call�F���i�����^�艿�^���P���^�������^���P���^�������^������z �ύX��</br>
        /// </remarks>
        public void CalculationSalesMoney(int rowIndex)
        {
            this.CalculationSalesMoney(rowIndex, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// ������z���v�Z���܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="rowNo">�s�ԍ�</param>
        /// <remarks>
        /// <br>Call�F���i�����^�艿�^���P���^�������^���P���^�������^������z �ύX��</br>
        /// </remarks>
        public void CalculationSalesMoney(string salesSlipNum, int rowNo)
        {
            this.CalculationSalesMoney(salesSlipNum, rowNo, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// ������z���v�Z���܂��B
        /// </summary>
        /// <param name="shipmentCnt">����</param>
        /// <param name="salesUnPrcTaxExcFl">���P��</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="taxRate">����ŗ�</param>
        /// <param name="salesMoneyFrcProcCd">����[�������敪(����*�P���Ɏg�p)</param>
        /// <param name="taxFrac">����Œ[�������敪</param>
        /// <param name="salesMoneyTaxInc">������z�i�ō��݁j</param>
        /// <param name="salesMoneyTaxExc">������z�i�Ŕ����j</param>
        /// <returns>true:�Z�芮�� false:�Z�莸�s</returns>
        /// <remarks>
        /// <br>Call�F���i�����^�艿�^���P���^�������^���P���^�������^������z �ύX��</br>
        /// </remarks>
        private bool CalculationSalesMoney(double shipmentCnt, double salesUnPrcTaxExcFl, int taxationCode, double taxRate, int salesMoneyFrcProcCd, int taxFrac, out long salesMoneyTaxInc, out long salesMoneyTaxExc)
        {
            salesMoneyTaxInc = 0;
            salesMoneyTaxExc = 0;

            double unitPriceExc = 0;    // �P���i�Ŕ����j
            double unitPriceInc = 0;	// �P���i�ō��݁j
            double unitPriceTax = 0;	// �P���i����Łj
            long priceExc = 0;			// ���i�i�Ŕ����j
            long priceInc = 0;			// ���i�i�ō��݁j
            long priceTax = 0;			// ���i�i����Łj

            // ����Œ[�������P�ʁA�敪�擾
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;

            // �o�א���0�܂��͔���P����0�̏ꍇ�͂��ׂ�0�ŏI��
            if ((shipmentCnt == 0) || (salesUnPrcTaxExcFl == 0)) return true;

            switch ((CalculateTax.TaxationCode)taxationCode)
            {
                case CalculateTax.TaxationCode.TaxExc:
                    //---------------------------------
                    // �O��
                    //---------------------------------
                    unitPriceExc = salesUnPrcTaxExcFl;	// �P���i�Ŕ����j
                    priceExc = 0;					        // ���i�i�Ŕ����j

                    this._salesPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, salesMoneyFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);
                    
                    salesMoneyTaxInc = priceInc;		        // ������z�i�ō��݁j
                    salesMoneyTaxExc = priceExc;		        // ������z�i�Ŕ����j		
                    break;
                case CalculateTax.TaxationCode.TaxInc:
                    //---------------------------------
                    // ����
                    //---------------------------------
                    unitPriceInc = salesUnPrcTaxExcFl;	// �P���i�ō��݁j
                    priceInc = 0;					        // ���i�i�ō��݁j

                    this._salesPriceCalculate.CalcTaxExcFromTaxInc(taxationCode, shipmentCnt, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, salesMoneyFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);

                    salesMoneyTaxInc = priceInc;		        // ������z�i�ō��݁j
                    salesMoneyTaxExc = priceExc;		        // ������z�i�Ŕ����j
                    break;
                case CalculateTax.TaxationCode.TaxNone:
                    //---------------------------------
                    // ��ې�
                    //---------------------------------
                    unitPriceExc = salesUnPrcTaxExcFl;	// �P���i�Ŕ����j
                    priceExc = 0;					        // ���i�i�Ŕ����j

                    this._salesPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, salesMoneyFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);

                    salesMoneyTaxInc = priceExc;		// ������z�i�ō��݁j
                    salesMoneyTaxExc = priceExc;		// ������z�i�ō��݁j
                    break;
            }

            this._salesSlip.FractionProcCd = taxFracProcCd;
            return true;
        }

        /// <summary>
        /// �w�肵���������z�̒l�����ɔ��㖾�׍s�I�u�W�F�N�g�̋��z����ݒ肵�܂��i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesRowNo">�s�ԍ�</param>
        public void SalesDetailRowCostSetting(int salesRowNo)
        {
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            this.SalesDetailRowCostSetting(salesRowNo, row.Cost, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// �w�肵���������z�̒l�����ɔ��㖾�׍s�I�u�W�F�N�g�̋��z����ݒ肵�܂��i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesRowNo">�s�ԍ�</param>
        /// <param name="cost">�������z</param>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">�󒍖��׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        public void SalesDetailRowCostSetting(int salesRowNo, long cost, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        {
            #region ����������
            SalesInputDataSet.SalesDetailRow row = salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(row.DtlRelationGuid);

            // ����Œ[�������P�ʁA�敪�擾
            int taxFrac = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd); // �[���Œ�
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, taxFrac, 0, out taxFracProcUnit, out taxFracProcCd);

            #endregion

            #region ��������
            if (row != null)
            {
                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                {
                    case CalculateTax.TaxationCode.TaxExc:
                        row.CostTaxExc = cost;
                        row.CostTaxInc = cost + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, cost);
                        break;
                    case CalculateTax.TaxationCode.TaxInc:
                        row.CostTaxExc = cost - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, cost);
                        row.CostTaxInc = cost;
                        break;
                    case CalculateTax.TaxationCode.TaxNone:
                        row.CostTaxExc = cost;
                        row.CostTaxInc = cost;
                        break;
                    default:
                        break;
                }

                // �P�����N���A
                this.ClearUnitInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_UnitCost);

                // �����P���ύX�敪�ݒ�
                if (row.SalesUnitCostTaxExc != row.BfUnitCost)
                {
                    row.SalesUnitCostChngDiv = 1; // �ύX����
                }
                else
                {
                    row.SalesUnitCostChngDiv = 0; // �ύX�Ȃ�
                }
            }
            #endregion

            #region ���󒍏��
            if (acptAnOdrRow != null)
            {
                switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
                {
                    case CalculateTax.TaxationCode.TaxExc:
                        acptAnOdrRow.CostTaxExc = cost;
                        acptAnOdrRow.CostTaxInc = cost + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, cost);
                        break;
                    case CalculateTax.TaxationCode.TaxInc:
                        acptAnOdrRow.CostTaxExc = cost - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, cost);
                        acptAnOdrRow.CostTaxInc = cost;
                        break;
                    case CalculateTax.TaxationCode.TaxNone:
                        acptAnOdrRow.CostTaxExc = cost;
                        acptAnOdrRow.CostTaxInc = cost;
                        break;
                    default:
                        break;
                }

                // �P�����N���A
                this.ClearUnitInfo(ref acptAnOdrRow, UnitPriceCalculation.ctUnitPriceKind_UnitCost);

                // �����P���ύX�敪�ݒ�
                if (acptAnOdrRow.SalesUnitCostTaxExc != acptAnOdrRow.BfUnitCost)
                {
                    acptAnOdrRow.SalesUnitCostChngDiv = 1; // �ύX����
                }
                else
                {
                    acptAnOdrRow.SalesUnitCostChngDiv = 0; // �ύX�Ȃ�
                }
            }
            #endregion
        }

        /// <summary>
        /// �������z���v�Z���܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesDetailList"></param>
        public void CalculationCost(List<SalesDetail> salesDetailList)
        {
            foreach (SalesDetail salesDetail in salesDetailList)
            {
                this.CalculationCost(salesDetail.SalesSlipNum, salesDetail.SalesRowNo);
            }
        }

        /// <summary>
        /// �������z���v�Z���܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="rowIndex">�ΏۍsIndex</param>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">�󒍖��׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        private void CalculationCost(int rowIndex, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        {
            SalesInputDataSet.SalesDetailRow salesDetailRow = salesDetailDataTable[rowIndex];
            this.CalculationCost(salesDetailRow, salesDetailDataTable, salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// �������z���v�Z���܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="rowIndex">�s�ԍ�</param>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">�󒍖��׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        private void CalculationCost(string salesSlipNum, int rowNo, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        {
            SalesInputDataSet.SalesDetailRow salesDetailRow = salesDetailDataTable.FindBySalesSlipNumSalesRowNo(salesSlipNum, rowNo);
            this.CalculationCost(salesDetailRow, salesDetailDataTable, salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// �������z���v�Z���܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesDetailRow">���㖾�׃f�[�^�s�I�u�W�F�N�g</param>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u��</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">�󒍖��׃f�[�^�e�[�u��</param>
        private void CalculationCost(SalesInputDataSet.SalesDetailRow salesDetailRow, SalesInputDataSet.SalesDetailDataTable salesDetailDataTable, SalesInputDataSet.SalesDetailAcceptAnOrderDataTable salesDetailAcceptAnOrderDataTable)
        {
            #region ����������
            // �󒍖��׍s�I�u�W�F�N�g�擾
            SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow = salesDetailAcceptAnOrderDataTable.FindByDtlRelationGuid(salesDetailRow.DtlRelationGuid);

            // ���̓`�F�b�N
            //if (string.IsNullOrEmpty(salesDetailRow.GoodsName)) return;
            if ((salesDetailRow.EditStatus == ctEDITSTATUS_RowDiscount) || (salesDetailRow.EditStatus == ctEDITSTATUS_Annotation)) return;

            SalesSlip salesSlip = this.SalesSlip;
            if (salesSlip == null) return;
            #endregion

            #region �����z�Z��
            switch ((SalesGoodsCd)salesDetailRow.SalesGoodsCd)
            {
                // ���i
                case SalesGoodsCd.Goods:

                    // �������z���Z��
                    long costTaxInc;
                    long costTaxExc;
                    long costDisplay;
                    double taxRate = salesSlip.ConsTaxRate;

                    // �ېŋ敪
                    int taxationCode = salesDetailRow.TaxationDivCd;

                    double salesUnitCost = 0;

                    switch ((CalculateTax.TaxationCode)salesDetailRow.TaxationDivCd)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            salesUnitCost = salesDetailRow.SalesUnitCostTaxExc;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            salesUnitCost = salesDetailRow.SalesUnitCostTaxInc;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            salesUnitCost = salesDetailRow.SalesUnitCostTaxExc;
                            break;
                    }

                    // ��ې�
                    if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                    {
                        taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
                    }
                    // ����
                    else if ((taxationCode != (int)CalculateTax.TaxationCode.TaxNone) &&
                             (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount))
                    {
                        taxationCode = (int)CalculateTax.TaxationCode.TaxInc;
                    }

                    #region ��������
                    int sign = (salesSlip.SalesSlipCd == (int)SalesSlipCd.RetGoods) ? -1 : 1;
                    if (this.CalculationCost(
                        salesDetailRow.SalesRowNo,
                        salesDetailRow.ShipmentCntDisplay * sign,
                        salesUnitCost,
                        taxationCode,
                        taxRate,
                        out costTaxInc,
                        out costTaxExc,
                        out costDisplay))
                    {
                        salesDetailRow.CostTaxExc = costTaxExc;        // �O��
                        salesDetailRow.CostTaxInc = costTaxInc;        // ����
                        salesDetailRow.Cost = costDisplay;
                    }
                    #endregion

                    #region ���󒍏��
                    if (acptAnOdrRow != null)
                    {
                        if (this.CalculationCost(
                            acptAnOdrRow.SalesRowNo,
                            acptAnOdrRow.AcceptAnOrderCntDisplay,
                            salesUnitCost,
                            taxationCode,
                            taxRate,
                            out costTaxInc,
                            out costTaxExc,
                            out costDisplay))
                        {
                            acptAnOdrRow.CostTaxExc = costTaxExc;        // �O��
                            acptAnOdrRow.CostTaxInc = costTaxInc;        // ����
                            acptAnOdrRow.Cost = costDisplay;
                        }
                    }
                    #endregion

                    break;
                // ����Œ���
                // �c������
                case SalesGoodsCd.ConsTaxAdjust:
                case SalesGoodsCd.AccRecConsTaxAdjust:
                case SalesGoodsCd.BalanceAdjust:
                case SalesGoodsCd.AccRecBalanceAdjust:
                    break;
            }
            #endregion
        }

        /// <summary>
        /// �������z���v�Z���܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="rowIndex">�ΏۍsIndex</param>
        /// <remarks>
        /// <br>Call�F���i�����^�艿�^���P���^������ �ύX��</br>
        /// </remarks>
        public void CalculationCost(int rowIndex)
        {
            this.CalculationCost(rowIndex, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// �������z���v�Z���܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesSlipNum">����`�[�ԍ�</param>
        /// <param name="rowNo">�s�ԍ�</param>
        /// <remarks>
        /// <br>Call�F���i�����^�艿�^���P���^������ �ύX��</br>
        /// </remarks>
        public void CalculationCost(string salesSlipNum, int rowNo)
        {
            this.CalculationCost(salesSlipNum, rowNo, this._salesDetailDataTable, this._salesDetailAcceptAnOrderDataTable);
        }

        /// <summary>
        /// �������z���v�Z���܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="salesDetailRow">���㖾�׃f�[�^�s�I�u�W�F�N�g</param>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u��</param>
        /// <param name="salesDetailAcceptAnOrderDataTable">�󒍖��׃f�[�^�e�[�u��</param>
        private void CalculationCost(SalesInputDataSet.SalesDetailAcceptAnOrderRow acptAnOdrRow)
        {
            #region ����������
            // ���̓`�F�b�N
            if ((acptAnOdrRow.EditStatus == ctEDITSTATUS_RowDiscount) || (acptAnOdrRow.EditStatus == ctEDITSTATUS_Annotation)) return;

            SalesSlip salesSlip = this.SalesSlip;
            if (salesSlip == null) return;
            #endregion

            #region �����z�Z��
            // �������z���Z��
            long costTaxInc;
            long costTaxExc;
            long costDisplay;
            double taxRate = salesSlip.ConsTaxRate;

            // �ېŋ敪
            int taxationCode = acptAnOdrRow.TaxationDivCd;

            double salesUnitCost = 0;

            switch ((CalculateTax.TaxationCode)acptAnOdrRow.TaxationDivCd)
            {
                case CalculateTax.TaxationCode.TaxExc:
                    salesUnitCost = acptAnOdrRow.SalesUnitCostTaxExc;
                    break;
                case CalculateTax.TaxationCode.TaxInc:
                    salesUnitCost = acptAnOdrRow.SalesUnitCostTaxInc;
                    break;
                case CalculateTax.TaxationCode.TaxNone:
                    salesUnitCost = acptAnOdrRow.SalesUnitCostTaxExc;
                    break;
            }

            // ��ې�
            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxNone;
            }
            // ����
            else if ((taxationCode != (int)CalculateTax.TaxationCode.TaxNone) &&
                     (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount))
            {
                taxationCode = (int)CalculateTax.TaxationCode.TaxInc;
            }

            #region ���󒍏��
            if (acptAnOdrRow != null)
            {
                if (this.CalculationCost(
                    acptAnOdrRow.SalesRowNo,
                    acptAnOdrRow.AcceptAnOrderCntDisplay,
                    salesUnitCost,
                    taxationCode,
                    taxRate,
                    out costTaxInc,
                    out costTaxExc,
                    out costDisplay))
                {
                    acptAnOdrRow.CostTaxExc = costTaxExc;        // �O��
                    acptAnOdrRow.CostTaxInc = costTaxInc;        // ����
                    acptAnOdrRow.Cost = costDisplay;
                }
            }
            #endregion
            #endregion
        }

        /// <summary>
        /// �������z���v�Z���܂��B
        /// </summary>
        /// <param name="salesRowNo">����s�ԍ�</param>
        /// <param name="shipmentCnt">����</param>
        /// <param name="SalesUnitCostTaxExc">�����P��</param>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="taxRate">����ŗ�</param>
        /// <param name="costTaxInc">�������z�i�ō��݁j</param>
        /// <param name="costTaxExc">�������z�i�Ŕ����j</param>
        /// <param name="costDisplay">�������z�i�\���j</param>
        /// <returns>true:�Z�芮�� false:�Z�莸�s</returns>
        /// <remarks>
        /// <br>Call�F���i�����^�艿�^���P���^�������^���P���^�������^������z �ύX��</br>
        /// </remarks>
        private bool CalculationCost(int salesRowNo, double shipmentCnt, double SalesUnitCostTaxExc, int taxationCode, double taxRate, out long costInc, out long costExc, out long costDisplay)
        {
            costInc = 0;
            costExc = 0;
            costDisplay = 0;
            double unitPriceExc = 0;	                // �P���i�Ŕ����j
            double unitPriceInc = 0;				    // �P���i�ō��݁j
            double unitPriceTax = 0;					// �P���i����Łj
            long priceExc = 0;					        // ���i�i�Ŕ����j
            long priceInc = 0;						    // ���i�i�ō��݁j
            long priceTax = 0;						    // ���i�i����Łj

            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            // �������z�[�������R�[�h
            int costFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.MoneyFrcProcCd);

            // ����Œ[�������P�ʁA�敪�擾
            int taxFrac = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;

            // �o�א���0�܂��͔���P����0�̏ꍇ�͂��ׂ�0�ŏI��
            if ((shipmentCnt == 0) || (SalesUnitCostTaxExc == 0)) return true;

            switch ((CalculateTax.TaxationCode)taxationCode)
            {
                case CalculateTax.TaxationCode.TaxExc:
                    //---------------------------------
                    // �O��
                    //---------------------------------
                    unitPriceExc = SalesUnitCostTaxExc;	    // �P���i�Ŕ����j
                    priceExc = 0;					        // ���i�i�Ŕ����j

                    //this._salesPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);
                    this._stockPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxRate, taxFrac, out taxFracProcUnit, out taxFracProcCd);
                    costInc = priceInc;		        // ������z�i�ō��݁j
                    costExc = priceExc;		        // ������z�i�Ŕ����j		
                    break;
                case CalculateTax.TaxationCode.TaxInc:
                    //---------------------------------
                    // ����
                    //---------------------------------
                    unitPriceInc = SalesUnitCostTaxExc;	    // �P���i�ō��݁j
                    priceInc = 0;					        // ���i�i�ō��݁j

                    //this._salesPriceCalculate.CalcTaxExcFromTaxInc(taxationCode, shipmentCnt, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);
                    this._stockPriceCalculate.CalcTaxExcFromTaxInc(taxationCode, shipmentCnt, out unitPriceExc, ref unitPriceInc, out unitPriceTax, out priceExc, ref priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);

                    costInc = priceInc;		        // ������z�i�ō��݁j
                    costExc = priceExc;		        // ������z�i�Ŕ����j
                    break;
                case CalculateTax.TaxationCode.TaxNone:
                    //---------------------------------
                    // ��ې�
                    //---------------------------------
                    unitPriceExc = SalesUnitCostTaxExc;	    // �P���i�Ŕ����j
                    priceExc = 0;					        // ���i�i�Ŕ����j

                    //this._salesPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxFrac, taxRate, out taxFracProcUnit, out taxFracProcCd);
                    this._stockPriceCalculate.CalcTaxIncFromTaxExc(taxationCode, shipmentCnt, ref unitPriceExc, out unitPriceInc, out unitPriceTax, ref priceExc, out priceInc, out priceTax, costFrcProcCd, taxRate, taxFrac, out taxFracProcUnit, out taxFracProcCd);
                    
                    costInc = priceExc;		// ������z�i�ō��݁j
                    costExc = priceExc;		// ������z�i�ō��݁j
                    break;
            }

            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc) // �ېŋ敪 // �����͑��z�\���敪�ɂ��Ȃ�
            {
                costDisplay = costInc;
            }
            else
            {
                costDisplay = costExc;
            }

            return true;
        }

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region Private Methods
        /// <summary>
        /// �w�肵�����i���I�u�W�F�N�g�����ɒP���Z�o���i��菤�i���i���擾���A���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i���i����ݒ肵�܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="row">���㖾�׍s�I�u�W�F�N�g</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="reCalcUnitInfoDiv">�|���Ď擾�敪(true:�Ď擾���� false:�Ď擾���Ȃ�)</param>
        private void SalesDetailRowGoodsPriceSetting(ref SalesInputDataSet.SalesDetailRow row, GoodsUnitData goodsUnitData, bool reCalcUnitInfoDiv)
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList = this.CalclationUnitPrice(row, goodsUnitData);
            this.SalesDetailRowGoodsPriceSetting(ref row, goodsUnitData, reCalcUnitInfoDiv, unitPriceCalcRetList);
        }

        //  --------- ADD 2011/09/05 -------------- >>>>>
        /// <summary>
        /// �w�肵�����i���I�u�W�F�N�g�����ɒP���Z�o���i��菤�i���i���擾���A���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i���i����ݒ肵�܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="row">���㖾�׍s�I�u�W�F�N�g</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="reCalcUnitInfoDiv">�|���Ď擾�敪(true:�Ď擾���� false:�Ď擾���Ȃ�)</param>
        private void SalesDetailRowGoodsPriceForSalesCodeCheck(SalesInputDataSet.SalesDetailRow row, GoodsUnitData goodsUnitData, bool reCalcUnitInfoDiv)
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList = this.CalclationUnitPrice(row, goodsUnitData);
            this.SalesDetailRowGoodsPriceForSalesCodeCheck(row, goodsUnitData, reCalcUnitInfoDiv, unitPriceCalcRetList);
        }
        //  --------- ADD 2011/09/05 -------------- <<<<<

        /// <summary>
        /// �w�肵�����i���I�u�W�F�N�g�����ɒP���Z�o���i��菤�i���i���擾���A���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i���i����ݒ肵�܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="row">���㖾�׍s�I�u�W�F�N�g</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="reCalcUnitInfoDiv">�|���Ď擾�敪(true:�Ď擾���� false:�Ď擾���Ȃ�)</param>
        /// <param name="unitPriceCalcRetList">�P���Z�o���ʃ��X�g</param>
        /// <br>Update Note: 2011/05/30 ������</br>
        /// <br>             ��L�����y�[���������擾����悤�ɕύX</br>
        /// <br>UpdateNote : 2011/07/11 杍^ Redmine#22876 ���P���̒[�������Ɋւ��Ă̏C��</br>
        /// <br>UpdateNote : 2011/07/13 ������ Redmine#22953 �W�����i���O�A����`�[���͂łO���Z�̃G���[���b�Z�[�W���\�����܂���</br>
        /// <br>                               Redmine#22773 [�������ݒ莞�敪���[����\��]�A�|���Ȃ��A�L�����y�[���l������0�̏ꍇ�̕s��C��</br>
        /// <br>UpdateNote : 2011/07/14 杍^ Redmine#22876 ���P���̒[�������Ɋւ��Ă̏C��</br>
        /// <br>UpdateNote : 2011/08/15 杍^ Redmine#23554 �L�����y�[���̔����u�������A�l�����A�����z�v���ݒ肳��Ă���ꍇ�́A�|���}�X�^�̔����̐ݒ���N���A����悤�Ɏd�l�ύX�̑Ή�</br>
        /// <br>UpdateNote : 2011/08/31 ����g �A��721 Redmine#23887</br>
        /// <br>Update Note: 2011/09/01 �A��681 yangmj 10704766-00 </br>
        /// <br>             Redmine#23723 �񋟒艿�ƃ��[�U�[�艿����v���Ȃ��ꍇ�A�����F�̉��C</br>
        /// <br>UpdateNote : 2011/09/05 yangmj Redmine#23554 �L�����y�[���̔����u�������A�l�����A�����z�v���ݒ肳��Ă���ꍇ�́A�|���}�X�^�̔����̐ݒ���N���A����悤�Ɏd�l�ύX�̑Ή�</br>
        /// <br>UpdateNote : 2011/09/14 杍^ Redmine#25016 �񋟂̏����i�ԂŁA���������o�^����Ă��違�L�����y�[���������o�^����Ă���ꍇ�A���P�����󔒂ɂȂ�s���̏C��</br>
        /// <br>UpdateNote : 2011/09/16 杍^ Redmine#25195 ����`�[���͂Ŕ��P�����N���A����Ă��܂��̑Ή�</br>
        /// <br>UpdateNote : 2011/09/21 yangmj Redmine#25261 ���`�[���w�肵�Ă̕ԕi������̏C��</br>
        /// <br>Update Note: 2012/02/28 ���N�n��</br>
        /// <br>�Ǘ��ԍ�   : 10707327-00 2012/03/28�z�M��</br>
        /// <br>             Redmine#27385 �����̋��z���s���ɂ��Ă̑Ή�</br>
        private void SalesDetailRowGoodsPriceSetting(ref SalesInputDataSet.SalesDetailRow row, GoodsUnitData goodsUnitData, bool reCalcUnitInfoDiv, List<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            bool salesUnitPriceFlg = false;
            bool salesUnitCostFlg = false;
            bool listPriceFlg = false;
            bool salesUnitCostCalcRetFlg = false; // 2010/07/29

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                if (unitPriceCalcRet != null)
                {
                    #region �����P��
                    //--------------------------------------------
                    // ���P��
                    //--------------------------------------------
                    string unitPriceKind = unitPriceCalcRet.UnitPriceKind;

                    if (UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice == unitPriceKind)
                    {
                        double salesUnitPrice = 0;
                        salesUnitPriceFlg = true;
                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                        {
                            //--------------------------------------------
                            // ���i���i�ېŋ敪�u�O�Łv
                            //--------------------------------------------
                            case CalculateTax.TaxationCode.TaxExc:
                                salesUnitPrice = row.SalesUnPrcTaxExcFl;
                                break;
                            //--------------------------------------------
                            // ���i���i�ېŋ敪�u���Łv
                            //--------------------------------------------
                            case CalculateTax.TaxationCode.TaxInc:
                                salesUnitPrice = row.SalesUnPrcTaxIncFl;
                                break;
                            //--------------------------------------------
                            // ���i���i�ېŋ敪�u��ېŁv
                            //--------------------------------------------
                            case CalculateTax.TaxationCode.TaxNone:
                                salesUnitPrice = row.SalesUnPrcTaxExcFl;
                                break;
                        }

                        // ����������͂ŕύX���Ă���ꍇ�͊|���Ď擾�͍s��Ȃ�
                        //if (salesUnitPrice == row.BfSalesUnitPrice)
                        // �|���ݒ�敪�Ɗ���i���ݒ肳��Ă���ꍇ�́A�|���Ď擾
                        // --- UPD m.suzuki 2011/02/16 ---------->>>>>
                        //if ((reCalcUnitInfoDiv == true) ||
                        //    ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0))))
                        if ((reCalcUnitInfoDiv == true) ||
                            ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0) || (_noneResettingListPriceFlag))))
                        // --- UPD m.suzuki 2011/02/16 ----------<<<<<
                        //if (row.SalesUnPrcTaxExcFl == row.BfSalesUnitPrice)
                        {
                            row.RateSectSalUnPrc = unitPriceCalcRet.SectionCode;            // �|���ݒ苒�_
                            row.RateDivSalUnPrc = unitPriceCalcRet.RateSettingDivide;       // �|���ݒ�敪
                            row.UnPrcCalcCdSalUnPrc = unitPriceCalcRet.UnitPrcCalcDiv;      // �P���Z�o�敪
                            row.PriceCdSalUnPrc = unitPriceCalcRet.PriceDiv;                // ���i�敪

                            // --- ADD 2011/09/16 ------- >>>>>>>
                            if (row.SupplierCdChgFlg == 1)
                            {
                                //�艿�̊|���}�X�^�����擾�ł���ꍇ
                                //�܂��͒艿�̊|���}�X�^�����擾�ł��Ȃ��A���P���Z�o�敪�i����P���j��(2:�����t�o�� OR 3:�e����)�̏ꍇ
                                if ((!string.IsNullOrEmpty(row.RateDivLPrice.Trim())) ||
                                    (string.IsNullOrEmpty(row.RateDivLPrice.Trim()) && (row.UnPrcCalcCdSalUnPrc == 2 || row.UnPrcCalcCdSalUnPrc == 3)))
                                {
                                    row.StdUnPrcSalUnPrc = unitPriceCalcRet.StdUnitPrice;           // ��P��
                                    row.SalesRate = 0;
                                }
                            }
                            else
                            {
                                row.StdUnPrcSalUnPrc = unitPriceCalcRet.StdUnitPrice;
                            }
                            // --- ADD 2011/09/16 ------- <<<<<<<

                            // --- DEL 2011/09/16 ------- >>>>>>>
                            //row.StdUnPrcSalUnPrc = unitPriceCalcRet.StdUnitPrice;           // ��P��  //DEL �A��721 2011/08/31
                            // --------------- ADD �A��721 2011/08/31 ----------------- >>>>>
                            //�艿�̊|���}�X�^�����擾�ł���ꍇ
                            //�܂��͒艿�̊|���}�X�^�����擾�ł��Ȃ��A���P���Z�o�敪�i����P���j��(2:�����t�o�� OR 3:�e����)�̏ꍇ
                            //if ((!string.IsNullOrEmpty(row.RateDivLPrice.Trim())) ||
                            //    (string.IsNullOrEmpty(row.RateDivLPrice.Trim()) && (row.UnPrcCalcCdSalUnPrc == 2 || row.UnPrcCalcCdSalUnPrc == 3)))
                            //{
                            //    row.StdUnPrcSalUnPrc = unitPriceCalcRet.StdUnitPrice;           // ��P��
                            //}
                            // --------------- ADD �A��721 2011/08/31 ----------------- <<<<<
                            // --- DEL 2011/09/16 ------- <<<<<<<

                            row.SalesUnPrcTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;    // ���P��(�Ŕ�)
                            row.SalesUnPrcTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;    // ���P��(�ō�)
                            row.SalesRate = 0; // --- ADD 2015/09/03 Y.Wakita �Г���Q��711 
                            switch ((UnitPriceCalculation.UnitPrcCalcDiv)unitPriceCalcRet.UnitPrcCalcDiv)
                            {
                                // ����i�~������
                                case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                                    row.SalesRate = unitPriceCalcRet.RateVal;                       // ������
                                    break;
                                // ����UP��
                                case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                                    row.CostUpRate = unitPriceCalcRet.RateVal;                      // ����UP��
                                    break;
                                // �e���m�ۗ�
                                case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                                    row.GrossProfitSecureRate = unitPriceCalcRet.RateVal;           // �e���m�ۗ�
                                    break;
                                // �P�����ڎw��
                                case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                                    row.SalesRate = 0;
                                    break;
                            }

                            // --- ADD yangyi K2014/02/09 ------->>>>>>>>>>>
                            row.RateUpdateTimeSales = unitPriceCalcRet.RateUpdateTimeSales;            // �|���X�V��
                            // --- ADD yangyi K2014/02/09 -------<<<<<<<<<<<

                            row.FracProcUnitSalUnPrc = unitPriceCalcRet.UnPrcFracProcUnit;  // �[�������P��
                            row.FracProcSalUnPrc = unitPriceCalcRet.UnPrcFracProcDiv;       // �[�������敪
                            row.BfSalesUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;      // �ύX�O����
                            //row.RateBLGoodsCode = row.BLGoodsCode;                          // BL���i�R�[�h(�|��)
                            //row.RateBLGoodsName = row.BLGoodsFullName;                      // BL���i�R�[�h����(�|��)
                            //row.RateGoodsRateGrpCd = row.GoodsMGroup;                       // ���i�|���O���[�v�R�[�h�i�|���j
                            //row.RateGoodsRateGrpNm = row.GoodsMGroupName;                   // ���i�|���O���[�v���́i�|���j
                            //row.RateBLGroupCode = row.BLGroupCode;                          // BL�O���[�v�R�[�h�i�|���j
                            //row.RateBLGroupName = row.BLGroupName;                          // BL�O���[�v���́i�|���j

                            //>>>2010/02/26
                            double price = row.SalesUnPrcTaxExcFl;
                            double priceTaxExc = 0;
                            double priceTaxInc = 0;

                            ////-----------------------------------------------------------------------------
                            //// �����A�g�l�������i���f
                            ////-----------------------------------------------------------------------------
                            //if (this._salesSlip.OnlineKindDiv == (int)OnlineKindDiv.SCM)
                            //{
                            //    this.ReflectAutoDiscount(row.TaxationDivCd, this._salesSlip.CustomerCode, row.GoodsMGroup, row.BLGoodsCode, row.GoodsMakerCd, row.GoodsNo, ref price);
                            //}

                            //-----------------------------------------------------------------------------
                            // �L�����y�[�����i���f
                            //-----------------------------------------------------------------------------
                            // ---UPD 2011/05/30------------>>>>>
                            //this.ReflectCampaign(row.TaxationDivCd, this._salesSlip.CustomerCode, row.GoodsMGroup, row.BLGoodsCode, row.GoodsMakerCd, row.GoodsNo, this._salesSlip.SalesDate, ref price);
                            this.ReflectCampaign(row.TaxationDivCd, this._salesSlip.CustomerCode, row.BLGoodsCode, row.GoodsMakerCd, row.GoodsNo, row.BLGroupCode, row.SalesCode, this._salesSlip.SalesDate, ref price);
                            if (this._campaignObjGoodsSt != null)
                            {
                                // �L�����y�[�����i�K�p
                                if (this._campaignObjGoodsSt.PriceFl != 0)
                                {
                                    price = this._campaignObjGoodsSt.PriceFl;
                                    row.SalesRate = 0;   // ADD 2011/08/15
                                }
                                // ---UPD 2011/07/14------------>>>>>
                                // �L�����y�[���������K�p
                                if (this._campaignObjGoodsSt.RateVal != 0)
                                {
                                    //row.SalesRate = this._campaignObjGoodsSt.RateVal;
                                    //price = row.ListPriceDisplay * row.SalesRate / 100;
                                    row.SalesRate = this._campaignObjGoodsSt.RateVal;
                                    //double listPriceDisplay = row.ListPriceDisplay;  // DEL 2011/09/14
                                    //double listPriceDisplay = row.BfListPrice;       // ADD 2011/09/14//DEL ���N�n�� 2012/02/28 Redmine#27385
                                    double listPriceDisplay = row.ListPriceDisplay; //ADD ���N�n�� 2012/02/28 Redmine#27385

                                    this.CalclatePriceByRate(row.TaxationDivCd, this._campaignObjGoodsSt.RateVal, ref listPriceDisplay);
                                    price = listPriceDisplay;
                                }
                                // ADD �� 2014/03/20 -------------------------->>>>>
                                Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
                                ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MaehashiKyowaUpdDateCtrl);

                                if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                                {
                                    row.RateUpdateTimeSales = this._campaignObjGoodsSt.UpdateDateTimeAdFormal;
                                }
                                // ADD �� 2014/03/20 --------------------------<<<<<

                                // �L�����y�[���l�����K�p
                                if (this._campaignObjGoodsSt.DiscountRate != 0)
                                {
                                    this.CalclatePriceByRate(row.TaxationDivCd, 100 - this._campaignObjGoodsSt.DiscountRate, ref price);
                                    row.SalesRate = 0;  // ADD 2011/08/15
                                }

                                // ----- ADD 2011/07/11 ------- >>>>>>>>>
                                // ------UPD 2011/07/13-------------->>>>>
                                //if (this._campaignObjGoodsSt.PriceFl == 0)
                                //if (this._campaignObjGoodsSt.PriceFl == 0 && unitPriceCalcRet.UnPrcFracProcUnit != 0)
                                //// ------UPD 2011/07/13-------------->>>>>
                                //{
                                //    // ���P���i�Ŕ��j
                                //    FractionCalculate.FracCalcMoney(price, unitPriceCalcRet.UnPrcFracProcUnit, unitPriceCalcRet.UnPrcFracProcDiv, out price);
                                //}
                                // ----- ADD 2011/07/11 ------- <<<<<<<<<

                                //-----ADD 2011/09/05 ------>>>>>
                                row.CampaignCode = this._campaignObjGoodsSt.CampaignCode;
                                row.CampaignRate = this._campaignObjGoodsSt.RateVal;
                                row.CampaignDiscountRate = this._campaignObjGoodsSt.DiscountRate;
                                row.CampaignPriceFl = this._campaignObjGoodsSt.PriceFl;
                                row.CampaignSettingKind = this._campaignObjGoodsSt.CampaignSettingKind;  // ADD 2011/09/14
                                //-----ADD 2011/09/05 ------<<<<<
                            }
                            // ---UPD 2011/05/30------------<<<<<
                            // ---UPD 2011/07/14------------<<<<<

                            //-----------------------------------------------------------------------------
                            // ���i�ăZ�b�g
                            //-----------------------------------------------------------------------------
                            this.CalcTaxExcAndTaxInc(row.TaxationDivCd, this._salesSlip.CustomerCode, this._salesSlipInputInitDataAcs.TaxRate, this._salesSlip.TotalAmountDispWayCd, price, out priceTaxExc, out priceTaxInc);
                            row.SalesUnPrcTaxExcFl = priceTaxExc;
                            row.SalesUnPrcTaxIncFl = priceTaxInc;
                            //<<<2010/02/26

                            if ((unitPriceCalcRet.RateSettingDivide == string.Empty) &&
                                (unitPriceCalcRet.UnitPrcCalcDiv == 0)) salesUnitPriceFlg = false;

                            //--------------------------------------------
                            // ��ې�
                            //--------------------------------------------
                            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                            {
                                row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                            }
                            //--------------------------------------------
                            // ���z�\�����Ȃ�
                            //--------------------------------------------
                            else if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    //--------------------------------------------
                                    // ���i���i�ېŋ敪�u�O�Łv
                                    //--------------------------------------------
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                                        break;
                                    //--------------------------------------------
                                    // ���i���i�ېŋ敪�u���Łv
                                    //--------------------------------------------
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                                        break;
                                    //--------------------------------------------
                                    // ���i���i�ېŋ敪�u��ېŁv
                                    //--------------------------------------------
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                                        break;
                                }
                            }
                            //--------------------------------------------
                            // ���z�\������
                            //--------------------------------------------
                            else
                            {
                                row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                            }
                        }
                    }
                    #endregion

                    #region �����P��
                    //--------------------------------------------
                    // ���P��
                    //--------------------------------------------
                    else if (UnitPriceCalculation.ctUnitPriceKind_UnitCost == unitPriceKind)
                    {
                        double salesUnitCost = 0;
                        salesUnitCostFlg = true;
                        salesUnitCostCalcRetFlg = true; // 2010/07/29
                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                        {
                            case CalculateTax.TaxationCode.TaxExc:
                                salesUnitCost = row.SalesUnitCostTaxExc;
                                break;
                            case CalculateTax.TaxationCode.TaxInc:
                                salesUnitCost = row.SalesUnitCostTaxInc;
                                break;
                            case CalculateTax.TaxationCode.TaxNone:
                                salesUnitCost = row.SalesUnitCostTaxExc;
                                break;
                        }

                        //if (salesUnitCost == row.BfUnitCost)
                        // �|���ݒ�敪�Ɗ���i���ݒ肳��Ă���ꍇ�́A�|���Ď擾
                        if ((reCalcUnitInfoDiv == true) ||
                            ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivUnCst.Trim())) || (row.StdUnPrcUnCst != 0))))
                        {
                            row.RateSectCstUnPrc = unitPriceCalcRet.SectionCode;            // �|���ݒ苒�_
                            row.RateDivUnCst = unitPriceCalcRet.RateSettingDivide;          // �|���ݒ�敪
                            row.UnPrcCalcCdUnCst = unitPriceCalcRet.UnitPrcCalcDiv;         // �P���Z�o�敪
                            row.PriceCdUnCst = unitPriceCalcRet.PriceDiv;                   // ���i�敪
                            row.StdUnPrcUnCst = unitPriceCalcRet.StdUnitPrice;              // ��P��
                            row.SalesUnitCostTaxExc = unitPriceCalcRet.UnitPriceTaxExcFl;   // ���P��(�Ŕ�)
                            row.SalesUnitCostTaxInc = unitPriceCalcRet.UnitPriceTaxIncFl;   // ���P��(�ō�)
                            row.CostRate = unitPriceCalcRet.RateVal;                        // ������
                            row.FracProcUnitUnCst = unitPriceCalcRet.UnPrcFracProcUnit;     // �[�������P��
                            row.FracProcUnCst = unitPriceCalcRet.UnPrcFracProcDiv;          // �[�������敪
                            row.BfUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;            // �ύX�O����
                            //row.RateBLGoodsCode = row.BLGoodsCode;                          // BL���i�R�[�h(�|��)
                            //row.RateBLGoodsName = row.BLGoodsFullName;                      // BL���i�R�[�h����(�|��)
                            //row.RateGoodsRateGrpCd = row.GoodsMGroup;                       // ���i�|���O���[�v�R�[�h�i�|���j
                            //row.RateGoodsRateGrpNm = row.GoodsMGroupName;                   // ���i�|���O���[�v���́i�|���j
                            //row.RateBLGroupCode = row.BLGroupCode;                          // BL�O���[�v�R�[�h�i�|���j
                            //row.RateBLGroupName = row.BLGroupName;                          // BL�O���[�v���́i�|���j
                            // --- ADD yangyi K2014/02/09 ------->>>>>>>>>>>
                            row.RateUpdateTimeUnit = unitPriceCalcRet.RateUpdateTimeUnit;            // �|���X�V��
                            // --- ADD yangyi K2014/02/09 -------<<<<<<<<<<<

                            if ((unitPriceCalcRet.RateSettingDivide == string.Empty) &&
                                (unitPriceCalcRet.UnitPrcCalcDiv == 0)) salesUnitCostFlg = false;

                            //--------------------------------------------
                            // ��ې�
                            //--------------------------------------------
                            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                            {
                                row.SalesUnitCost = row.SalesUnitCostTaxExc;
                            }
                            //--------------------------------------------
                            // ���z�\�����Ȃ�
                            //--------------------------------------------
                            else if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxInc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                }
                            }
                            //--------------------------------------------
                            // ���z�\������
                            //--------------------------------------------
                            else
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxInc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                }
                            }
                        }
                    }
                    #endregion

                    #region ���艿
                    //--------------------------------------------
                    // �艿
                    //--------------------------------------------
                    else if (UnitPriceCalculation.ctUnitPriceKind_ListPrice == unitPriceKind)
                    {
                        double listPrice = 0;
                        listPriceFlg = true;
                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                        {
                            case CalculateTax.TaxationCode.TaxExc:
                                listPrice = row.ListPriceTaxExcFl;
                                break;
                            case CalculateTax.TaxationCode.TaxInc:
                                listPrice = row.ListPriceTaxIncFl;
                                break;
                            case CalculateTax.TaxationCode.TaxNone:
                                listPrice = row.ListPriceTaxExcFl;
                                break;
                        }

                        // �|���ݒ�敪�Ɗ���i���ݒ肳��Ă���ꍇ�́A�|���Ď擾
                        if ((reCalcUnitInfoDiv == true) ||
                            ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivLPrice.Trim())) || (row.StdUnPrcLPrice != 0))))
                        {
                            row.RateSectPriceUnPrc = unitPriceCalcRet.SectionCode;          // �|���ݒ苒�_
                            row.RateDivLPrice = unitPriceCalcRet.RateSettingDivide;         // �|���ݒ�敪
                            row.UnPrcCalcCdLPrice = unitPriceCalcRet.UnitPrcCalcDiv;        // �P���Z�o�敪
                            row.PriceCdLPrice = unitPriceCalcRet.PriceDiv;                  // ���i�敪
                            row.StdUnPrcLPrice = unitPriceCalcRet.StdUnitPrice;             // ��P��

                            // --- ADD 2011/09/16 ------- >>>>>>>
                            if (row.SupplierCdChgFlg == 1)
                            {
                                if (!string.IsNullOrEmpty(row.RateDivLPrice.Trim()))
                                {
                                    //�艿�|���}�X�^�����擾�ł���ꍇ
                                    row.ListPriceTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;     // �艿(�Ŕ�)
                                }
                                else
                                {
                                    row.StdUnPrcSalUnPrc = row.ListPriceTaxExcFl;           // ��P��(���P��)
                                }
                            }
                            else
                            {
                                row.ListPriceTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;
                            }
                            // --- ADD 2011/09/16 ------- <<<<<<<<

                            // --- DEL 2011/09/16 ------- >>>>>>>
                            //row.ListPriceTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;     // �艿(�Ŕ�)  //DEL �A��721 2011/08/31
                            // --------------- ADD �A��721 2011/08/31 ----------------- >>>>>
                            //if (!string.IsNullOrEmpty(row.RateDivLPrice.Trim()))
                            //{
                            //    //�艿�|���}�X�^�����擾�ł���ꍇ
                            //    row.ListPriceTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;     // �艿(�Ŕ�)
                            //}
                            //else
                            //{
                            //    row.StdUnPrcSalUnPrc = row.ListPriceTaxExcFl;           // ��P��(���P��)
                            //}
                            // --------------- ADD �A��721 2011/08/31 ----------------- <<<<<
                            // --- DEL 2011/09/16 ------- >>>>>>>

                            row.ListPriceTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;     // �艿(�ō�)
                            row.ListPriceRate = unitPriceCalcRet.RateVal;                   // �艿��
                            row.FracProcUnitLPrice = unitPriceCalcRet.UnPrcFracProcUnit;    // �[�������P��
                            row.FracProcLPrice = unitPriceCalcRet.UnPrcFracProcDiv;         // �[�������敪
                            row.BfListPrice = unitPriceCalcRet.UnitPriceTaxExcFl;           // �ύX�O�艿
                            //row.RateBLGoodsCode = row.BLGoodsCode;                          // BL���i�R�[�h(�|��)
                            //row.RateBLGoodsName = row.BLGoodsFullName;                      // BL���i�R�[�h����(�|��)
                            //row.RateGoodsRateGrpCd = row.GoodsMGroup;                       // ���i�|���O���[�v�R�[�h�i�|���j
                            //row.RateGoodsRateGrpNm = row.GoodsMGroupName;                   // ���i�|���O���[�v���́i�|���j
                            //row.RateBLGroupCode = row.BLGroupCode;                          // BL�O���[�v�R�[�h�i�|���j
                            //row.RateBLGroupName = row.BLGroupName;                          // BL�O���[�v���́i�|���j
                            row.OpenPriceDiv = unitPriceCalcRet.OpenPriceDiv;               // �I�[�v�����i�敪

                            if ((unitPriceCalcRet.RateSettingDivide == string.Empty) &&
                                (unitPriceCalcRet.UnitPrcCalcDiv == 0)) listPriceFlg = false;

                            //--------------------------------------------
                            // ��ې�
                            //--------------------------------------------
                            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                            {
                                row.ListPriceDisplay = row.ListPriceTaxExcFl;
                            }
                            //--------------------------------------------
                            // ���z�\�����Ȃ�
                            //--------------------------------------------
                            else if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.ListPriceDisplay = row.ListPriceTaxIncFl;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                        break;
                                }
                            }
                            //--------------------------------------------
                            // ���z�\������
                            //--------------------------------------------
                            else
                            {
                                row.ListPriceDisplay = row.ListPriceTaxIncFl;
                            }
                        }
                    }
                    #endregion
                }
            }
            //-----ADD 2011/09/01----->>>>>
            if (row.StdUnPrcUnCst == 0)
            {
                DateTime targetDate = new DateTime();

                switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlip.AcptAnOdrStatusDisplay)
                {
                    case AcptAnOdrStatusState.Estimate:
                        targetDate = this._salesSlip.SalesDate; // �����
                        break;
                    case AcptAnOdrStatusState.UnitPriceEstimate:
                        targetDate = this._salesSlip.SalesDate; // �����
                        break;
                    case AcptAnOdrStatusState.Sales:
                        targetDate = this._salesSlip.SalesDate; // �����
                        break;
                    case AcptAnOdrStatusState.Shipment:
                        targetDate = this._salesSlip.ShipmentDay; // �o�ד�
                        break;
                }

                //-----------------------------------------------------------------------
                // ���i��񂪑��݂���ꍇ�́A���i��񂩂��艿�m��
                //-----------------------------------------------------------------------
                //if (goodsUnitData.GoodsPriceList != null)//DEL 2011/09/21
                if (goodsUnitData != null && goodsUnitData.GoodsPriceList != null)//ADD 2011/09/21
                {
                    object obj = this._salesSlipInputInitDataAcs.GetGoodsPrice(targetDate, goodsUnitData.GoodsPriceList);
                    if ((obj != null) && (obj is GoodsPrice))
                    {
                        GoodsPrice goodsPrice = (GoodsPrice)obj;
                        row.StdUnPrcUnCst = goodsPrice.ListPrice;             // ��P��
                    }
                }                
            }
            //-----ADD 2011/09/01-----<<<<<
            #region �ύX�O���P���ݒ�
            if (salesUnitPriceFlg == false)
            {
                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                {
                    // �[���\��
                    case 0:
                        row.BfSalesUnitPrice = 0;
                        break;
                    // �艿�\��
                    case 1:
                        row.BfSalesUnitPrice = row.ListPriceTaxExcFl;
                        break;
                    default:
                        row.BfSalesUnitPrice = 0;
                        break;
                }
            }
            #endregion

            #region ������
            if (salesUnitPriceFlg == false)
            {
                // ���P��
                row.RateSectSalUnPrc = string.Empty;    // �|���ݒ苒�_
                row.RateDivSalUnPrc = string.Empty;      // �|���ݒ�敪
                row.UnPrcCalcCdSalUnPrc = 0;   // �P���Z�o�敪
                row.PriceCdSalUnPrc = 0;       // ���i�敪
                row.StdUnPrcSalUnPrc = 0;      // ��P��
                row.FracProcUnitSalUnPrc = 0;  // �[�������P��
                row.FracProcSalUnPrc = 0;      // �[�������敪

                //row.SalesUnPrcDisplay = 0;
                //row.SalesUnPrcTaxExcFl = 0;
                //row.SalesUnPrcTaxIncFl = 0;
                //row.SalesRate = 0;
                //row.CostUpRate = 0;
                //row.GrossProfitSecureRate = 0;

                row.SalesRate = 0; // 2010/07/28
            }
            // --- UPD m.suzuki 2011/02/16 ---------->>>>>
            //if (salesUnitCostFlg == false)
            if (salesUnitCostFlg == false && !_noneResettingUnitCostFlag)
            // --- UPD m.suzuki 2011/02/16 ----------<<<<<
            {
                // ���P��
                row.RateSectCstUnPrc = string.Empty;    // �|���ݒ苒�_
                row.RateDivUnCst = string.Empty;         // �|���ݒ�敪
                row.UnPrcCalcCdUnCst = 0;      // �P���Z�o�敪
                row.PriceCdUnCst = 0;          // ���i�敪
                //row.StdUnPrcUnCst = 0;         // ��P�� // DEL 2011/09/01
                row.FracProcUnitUnCst = 0;     // �[�������P��
                row.FracProcUnCst = 0;         // �[�������敪

                //row.SalesUnitCost = 0;
                //row.SalesUnitCostTaxExc = 0;
                //row.SalesUnitCostTaxInc = 0;
                //row.CostRate = 0;

                //>>>2010/07/29
                ////>>>2010/07/28
                //row.CostRate = 0;
                //row.SalesUnitCost = 0;
                //row.SalesUnitCostTaxExc = 0;
                //row.SalesUnitCostTaxInc = 0;
                ////<<<2010/07/28

                row.CostRate = 0;
                if (salesUnitCostCalcRetFlg == false)
                {
                    row.SalesUnitCost = 0;
                    row.SalesUnitCostTaxExc = 0;
                    row.SalesUnitCostTaxInc = 0;
                }
                //<<<2010/07/29
            }
            // --- UPD m.suzuki 2011/02/16 ---------->>>>>
            //if (listPriceFlg == false)
            if (listPriceFlg == false && !_noneResettingListPriceFlag)
            // --- UPD m.suzuki 2011/02/16 ----------<<<<<
            {
                // �艿
                row.RateSectPriceUnPrc = string.Empty;  // �|���ݒ苒�_
                row.RateDivLPrice = string.Empty;        // �|���ݒ�敪
                row.UnPrcCalcCdLPrice = 0;     // �P���Z�o�敪
                row.PriceCdLPrice = 0;         // ���i�敪
                row.StdUnPrcLPrice = 0;        // ��P��
                row.FracProcUnitLPrice = 0;    // �[�������P��
                row.FracProcLPrice = 0;        // �[�������敪

                //row.ListPriceDisplay = 0;
                //row.ListPriceTaxExcFl = 0;
                //row.ListPriceTaxIncFl = 0;
                //row.ListPriceRate = 0;
            }
            if ((salesUnitPriceFlg == false) &&
                (salesUnitCostFlg == false) &&
                (listPriceFlg == false))
            {
                //row.RateBLGoodsCode = 0;                          // BL���i�R�[�h(�|��)
                //row.RateBLGoodsName = string.Empty;               // BL���i�R�[�h����(�|��)
                //row.RateGoodsRateGrpCd = 0;                       // ���i�|���O���[�v�R�[�h�i�|���j
                //row.RateGoodsRateGrpNm = string.Empty;            // ���i�|���O���[�v���́i�|���j
                //row.RateBLGroupCode = 0;                          // BL�O���[�v�R�[�h�i�|���j
                //row.RateBLGroupName = string.Empty;               // BL�O���[�v���́i�|���j
            }

            // ADD 2011/08/15 ---- >>>>>
            //if (this._campaignObjGoodsSt != null)
            //{
            //    // �|���Z�o���N���A
            //    this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
            //}
            // ADD 2011/08/15 ---- <<<<<
            #endregion

            this.SalesDetailRowUnitPriceSetting(ref row, goodsUnitData);

            // ADD 2011/08/15 ---- >>>>>
            if (this._campaignObjGoodsSt != null)
            {
                // �|���Z�o���N���A
                //this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);// DEL 2011/09/05
                this.ClearRateInfoForCampaign(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);// ADD 2011/09/05
            }
            // ADD 2011/08/15 ---- <<<<<
        }

        // ------ ADD 2011/09/05 -------- >>>>>
        /// <summary>
        /// �w�肵�����i���I�u�W�F�N�g�����ɒP���Z�o���i��菤�i���i���擾���A���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i���i����ݒ肵�܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="row">���㖾�׍s�I�u�W�F�N�g</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="reCalcUnitInfoDiv">�|���Ď擾�敪(true:�Ď擾���� false:�Ď擾���Ȃ�)</param>
        /// <param name="unitPriceCalcRetList">�P���Z�o���ʃ��X�g</param>
        /// <br>Update Note: 2011/05/30 ������</br>
        /// <br>             ��L�����y�[���������擾����悤�ɕύX</br>
        /// <br>UpdateNote : 2011/07/11 杍^ Redmine#22876 ���P���̒[�������Ɋւ��Ă̏C��</br>
        /// <br>UpdateNote : 2011/07/13 ������ Redmine#22953 �W�����i���O�A����`�[���͂łO���Z�̃G���[���b�Z�[�W���\�����܂���</br>
        /// <br>                               Redmine#22773 [�������ݒ莞�敪���[����\��]�A�|���Ȃ��A�L�����y�[���l������0�̏ꍇ�̕s��C��</br>
        /// <br>UpdateNote : 2011/07/14 杍^ Redmine#22876 ���P���̒[�������Ɋւ��Ă̏C��</br>
        /// <br>UpdateNote : 2011/08/15 杍^ Redmine#23554 �L�����y�[���̔����u�������A�l�����A�����z�v���ݒ肳��Ă���ꍇ�́A�|���}�X�^�̔����̐ݒ���N���A����悤�Ɏd�l�ύX�̑Ή�</br>
        private void SalesDetailRowGoodsPriceForSalesCodeCheck(SalesInputDataSet.SalesDetailRow row, GoodsUnitData goodsUnitData, bool reCalcUnitInfoDiv, List<UnitPriceCalcRet> unitPriceCalcRetList)
        {
            bool salesUnitPriceFlg = false;
            bool salesUnitCostFlg = false;
            bool listPriceFlg = false;
            bool salesUnitCostCalcRetFlg = false; // 2010/07/29

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                if (unitPriceCalcRet != null)
                {
                    #region �����P��
                    //--------------------------------------------
                    // ���P��
                    //--------------------------------------------
                    string unitPriceKind = unitPriceCalcRet.UnitPriceKind;

                    if (UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice == unitPriceKind)
                    {
                        double salesUnitPrice = 0;
                        salesUnitPriceFlg = true;
                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                        {
                            //--------------------------------------------
                            // ���i���i�ېŋ敪�u�O�Łv
                            //--------------------------------------------
                            case CalculateTax.TaxationCode.TaxExc:
                                salesUnitPrice = row.SalesUnPrcTaxExcFl;
                                break;
                            //--------------------------------------------
                            // ���i���i�ېŋ敪�u���Łv
                            //--------------------------------------------
                            case CalculateTax.TaxationCode.TaxInc:
                                salesUnitPrice = row.SalesUnPrcTaxIncFl;
                                break;
                            //--------------------------------------------
                            // ���i���i�ېŋ敪�u��ېŁv
                            //--------------------------------------------
                            case CalculateTax.TaxationCode.TaxNone:
                                salesUnitPrice = row.SalesUnPrcTaxExcFl;
                                break;
                        }

                        // ����������͂ŕύX���Ă���ꍇ�͊|���Ď擾�͍s��Ȃ�
                        // �|���ݒ�敪�Ɗ���i���ݒ肳��Ă���ꍇ�́A�|���Ď擾
                        if ((reCalcUnitInfoDiv == true) ||
                            ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0) || (_noneResettingListPriceFlag))))
                        {
                            row.RateSectSalUnPrc = unitPriceCalcRet.SectionCode;            // �|���ݒ苒�_
                            row.RateDivSalUnPrc = unitPriceCalcRet.RateSettingDivide;       // �|���ݒ�敪
                            row.UnPrcCalcCdSalUnPrc = unitPriceCalcRet.UnitPrcCalcDiv;      // �P���Z�o�敪
                            row.PriceCdSalUnPrc = unitPriceCalcRet.PriceDiv;                // ���i�敪
                            row.StdUnPrcSalUnPrc = unitPriceCalcRet.StdUnitPrice;           // ��P��
                            row.SalesUnPrcTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;    // ���P��(�Ŕ�)
                            row.SalesUnPrcTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;    // ���P��(�ō�)
                            row.SalesRate = 0; // --- ADD 2015/09/03 Y.Wakita �Г���Q��711 
                            switch ((UnitPriceCalculation.UnitPrcCalcDiv)unitPriceCalcRet.UnitPrcCalcDiv)
                            {
                                // ����i�~������
                                case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                                    row.SalesRate = unitPriceCalcRet.RateVal;                       // ������
                                    break;
                                // ����UP��
                                case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                                    row.CostUpRate = unitPriceCalcRet.RateVal;                      // ����UP��
                                    break;
                                // �e���m�ۗ�
                                case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                                    row.GrossProfitSecureRate = unitPriceCalcRet.RateVal;           // �e���m�ۗ�
                                    break;
                                // �P�����ڎw��
                                case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                                    row.SalesRate = 0;
                                    break;
                            }
                            row.FracProcUnitSalUnPrc = unitPriceCalcRet.UnPrcFracProcUnit;  // �[�������P��
                            row.FracProcSalUnPrc = unitPriceCalcRet.UnPrcFracProcDiv;       // �[�������敪
                            row.BfSalesUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;      // �ύX�O����
                            double price = row.SalesUnPrcTaxExcFl;
                            double priceTaxExc = 0;
                            double priceTaxInc = 0;


                            //-----------------------------------------------------------------------------
                            // �L�����y�[�����i���f
                            //-----------------------------------------------------------------------------
                            this.ReflectCampaign(row.TaxationDivCd, this._salesSlip.CustomerCode, row.BLGoodsCode, row.GoodsMakerCd, row.GoodsNo, row.BLGroupCode, row.SalesCode, this._salesSlip.SalesDate, ref price);
                            if (this._campaignObjGoodsSt != null)
                            {
                                // �L�����y�[�����i�K�p
                                if (this._campaignObjGoodsSt.PriceFl != 0)
                                {
                                    price = this._campaignObjGoodsSt.PriceFl;
                                    row.SalesRate = 0;   // ADD 2011/08/15
                                }

                                // �L�����y�[���������K�p
                                if (this._campaignObjGoodsSt.RateVal != 0)
                                {
                                    row.SalesRate = this._campaignObjGoodsSt.RateVal;
                                    double listPriceDisplay = row.ListPriceDisplay;
                                    this.CalclatePriceByRate(row.TaxationDivCd, this._campaignObjGoodsSt.RateVal, ref listPriceDisplay);
                                    price = listPriceDisplay;
                                }
                                // ADD �� 2014/03/20 -------------------------->>>>>
                                Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
                                ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MaehashiKyowaUpdDateCtrl);

                                if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                                {
                                    row.RateUpdateTimeSales = this._campaignObjGoodsSt.UpdateDateTimeAdFormal;
                                }
                                // ADD �� 2014/03/20 --------------------------<<<<<

                                // �L�����y�[���l�����K�p
                                if (this._campaignObjGoodsSt.DiscountRate != 0)
                                {
                                    this.CalclatePriceByRate(row.TaxationDivCd, 100 - this._campaignObjGoodsSt.DiscountRate, ref price);
                                    row.SalesRate = 0;  // ADD 2011/08/15
                                }


                                //-----ADD 2011/08/29 ------>>>>>
                                row.CampaignCode = this._campaignObjGoodsSt.CampaignCode;
                                row.CampaignRate = this._campaignObjGoodsSt.RateVal;
                                row.CampaignDiscountRate = this._campaignObjGoodsSt.DiscountRate;
                                row.CampaignPriceFl = this._campaignObjGoodsSt.PriceFl;
                                row.CampaignSettingKind = this._campaignObjGoodsSt.CampaignSettingKind;  // ADD 2011/09/14
                                //-----ADD 2011/08/29 ------<<<<<
                            }
                            // ---UPD 2011/05/30------------<<<<<
                            // ---UPD 2011/07/14------------<<<<<

                            //-----------------------------------------------------------------------------
                            // ���i�ăZ�b�g
                            //-----------------------------------------------------------------------------
                            this.CalcTaxExcAndTaxInc(row.TaxationDivCd, this._salesSlip.CustomerCode, this._salesSlipInputInitDataAcs.TaxRate, this._salesSlip.TotalAmountDispWayCd, price, out priceTaxExc, out priceTaxInc);
                            row.SalesUnPrcTaxExcFl = priceTaxExc;
                            row.SalesUnPrcTaxIncFl = priceTaxInc;

                            if ((unitPriceCalcRet.RateSettingDivide == string.Empty) &&
                                (unitPriceCalcRet.UnitPrcCalcDiv == 0)) salesUnitPriceFlg = false;

                            //--------------------------------------------
                            // ��ې�
                            //--------------------------------------------
                            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                            {
                                row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                            }
                            //--------------------------------------------
                            // ���z�\�����Ȃ�
                            //--------------------------------------------
                            else if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    //--------------------------------------------
                                    // ���i���i�ېŋ敪�u�O�Łv
                                    //--------------------------------------------
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                                        break;
                                    //--------------------------------------------
                                    // ���i���i�ېŋ敪�u���Łv
                                    //--------------------------------------------
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                                        break;
                                    //--------------------------------------------
                                    // ���i���i�ېŋ敪�u��ېŁv
                                    //--------------------------------------------
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                                        break;
                                }
                            }
                            //--------------------------------------------
                            // ���z�\������
                            //--------------------------------------------
                            else
                            {
                                row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                            }
                        }
                    }
                    #endregion

                    #region �����P��
                    //--------------------------------------------
                    // ���P��
                    //--------------------------------------------
                    else if (UnitPriceCalculation.ctUnitPriceKind_UnitCost == unitPriceKind)
                    {
                        double salesUnitCost = 0;
                        salesUnitCostFlg = true;
                        salesUnitCostCalcRetFlg = true; // 2010/07/29
                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                        {
                            case CalculateTax.TaxationCode.TaxExc:
                                salesUnitCost = row.SalesUnitCostTaxExc;
                                break;
                            case CalculateTax.TaxationCode.TaxInc:
                                salesUnitCost = row.SalesUnitCostTaxInc;
                                break;
                            case CalculateTax.TaxationCode.TaxNone:
                                salesUnitCost = row.SalesUnitCostTaxExc;
                                break;
                        }

                        //if (salesUnitCost == row.BfUnitCost)
                        // �|���ݒ�敪�Ɗ���i���ݒ肳��Ă���ꍇ�́A�|���Ď擾
                        if ((reCalcUnitInfoDiv == true) ||
                            ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivUnCst.Trim())) || (row.StdUnPrcUnCst != 0))))
                        {
                            row.RateSectCstUnPrc = unitPriceCalcRet.SectionCode;            // �|���ݒ苒�_
                            row.RateDivUnCst = unitPriceCalcRet.RateSettingDivide;          // �|���ݒ�敪
                            row.UnPrcCalcCdUnCst = unitPriceCalcRet.UnitPrcCalcDiv;         // �P���Z�o�敪
                            row.PriceCdUnCst = unitPriceCalcRet.PriceDiv;                   // ���i�敪
                            row.StdUnPrcUnCst = unitPriceCalcRet.StdUnitPrice;              // ��P��
                            row.SalesUnitCostTaxExc = unitPriceCalcRet.UnitPriceTaxExcFl;   // ���P��(�Ŕ�)
                            row.SalesUnitCostTaxInc = unitPriceCalcRet.UnitPriceTaxIncFl;   // ���P��(�ō�)
                            row.CostRate = unitPriceCalcRet.RateVal;                        // ������
                            row.FracProcUnitUnCst = unitPriceCalcRet.UnPrcFracProcUnit;     // �[�������P��
                            row.FracProcUnCst = unitPriceCalcRet.UnPrcFracProcDiv;          // �[�������敪
                            row.BfUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;            // �ύX�O����
                            //row.RateBLGoodsCode = row.BLGoodsCode;                          // BL���i�R�[�h(�|��)
                            //row.RateBLGoodsName = row.BLGoodsFullName;                      // BL���i�R�[�h����(�|��)
                            //row.RateGoodsRateGrpCd = row.GoodsMGroup;                       // ���i�|���O���[�v�R�[�h�i�|���j
                            //row.RateGoodsRateGrpNm = row.GoodsMGroupName;                   // ���i�|���O���[�v���́i�|���j
                            //row.RateBLGroupCode = row.BLGroupCode;                          // BL�O���[�v�R�[�h�i�|���j
                            //row.RateBLGroupName = row.BLGroupName;                          // BL�O���[�v���́i�|���j

                            if ((unitPriceCalcRet.RateSettingDivide == string.Empty) &&
                                (unitPriceCalcRet.UnitPrcCalcDiv == 0)) salesUnitCostFlg = false;

                            //--------------------------------------------
                            // ��ې�
                            //--------------------------------------------
                            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                            {
                                row.SalesUnitCost = row.SalesUnitCostTaxExc;
                            }
                            //--------------------------------------------
                            // ���z�\�����Ȃ�
                            //--------------------------------------------
                            else if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxInc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                }
                            }
                            //--------------------------------------------
                            // ���z�\������
                            //--------------------------------------------
                            else
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxInc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                }
                            }
                        }
                    }
                    #endregion

                    #region ���艿
                    //--------------------------------------------
                    // �艿
                    //--------------------------------------------
                    else if (UnitPriceCalculation.ctUnitPriceKind_ListPrice == unitPriceKind)
                    {
                        double listPrice = 0;
                        listPriceFlg = true;
                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                        {
                            case CalculateTax.TaxationCode.TaxExc:
                                listPrice = row.ListPriceTaxExcFl;
                                break;
                            case CalculateTax.TaxationCode.TaxInc:
                                listPrice = row.ListPriceTaxIncFl;
                                break;
                            case CalculateTax.TaxationCode.TaxNone:
                                listPrice = row.ListPriceTaxExcFl;
                                break;
                        }

                        // �|���ݒ�敪�Ɗ���i���ݒ肳��Ă���ꍇ�́A�|���Ď擾
                        if ((reCalcUnitInfoDiv == true) ||
                            ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivLPrice.Trim())) || (row.StdUnPrcLPrice != 0))))
                        {
                            row.RateSectPriceUnPrc = unitPriceCalcRet.SectionCode;          // �|���ݒ苒�_
                            row.RateDivLPrice = unitPriceCalcRet.RateSettingDivide;         // �|���ݒ�敪
                            row.UnPrcCalcCdLPrice = unitPriceCalcRet.UnitPrcCalcDiv;        // �P���Z�o�敪
                            row.PriceCdLPrice = unitPriceCalcRet.PriceDiv;                  // ���i�敪
                            row.StdUnPrcLPrice = unitPriceCalcRet.StdUnitPrice;             // ��P��
                            row.ListPriceTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;     // �艿(�Ŕ�)
                            row.ListPriceTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;     // �艿(�ō�)
                            row.ListPriceRate = unitPriceCalcRet.RateVal;                   // �艿��
                            row.FracProcUnitLPrice = unitPriceCalcRet.UnPrcFracProcUnit;    // �[�������P��
                            row.FracProcLPrice = unitPriceCalcRet.UnPrcFracProcDiv;         // �[�������敪
                            row.BfListPrice = unitPriceCalcRet.UnitPriceTaxExcFl;           // �ύX�O�艿
                            //row.RateBLGoodsCode = row.BLGoodsCode;                          // BL���i�R�[�h(�|��)
                            //row.RateBLGoodsName = row.BLGoodsFullName;                      // BL���i�R�[�h����(�|��)
                            //row.RateGoodsRateGrpCd = row.GoodsMGroup;                       // ���i�|���O���[�v�R�[�h�i�|���j
                            //row.RateGoodsRateGrpNm = row.GoodsMGroupName;                   // ���i�|���O���[�v���́i�|���j
                            //row.RateBLGroupCode = row.BLGroupCode;                          // BL�O���[�v�R�[�h�i�|���j
                            //row.RateBLGroupName = row.BLGroupName;                          // BL�O���[�v���́i�|���j
                            row.OpenPriceDiv = unitPriceCalcRet.OpenPriceDiv;               // �I�[�v�����i�敪

                            if ((unitPriceCalcRet.RateSettingDivide == string.Empty) &&
                                (unitPriceCalcRet.UnitPrcCalcDiv == 0)) listPriceFlg = false;

                            //--------------------------------------------
                            // ��ې�
                            //--------------------------------------------
                            if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                            {
                                row.ListPriceDisplay = row.ListPriceTaxExcFl;
                            }
                            //--------------------------------------------
                            // ���z�\�����Ȃ�
                            //--------------------------------------------
                            else if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.ListPriceDisplay = row.ListPriceTaxIncFl;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                        break;
                                }
                            }
                            //--------------------------------------------
                            // ���z�\������
                            //--------------------------------------------
                            else
                            {
                                row.ListPriceDisplay = row.ListPriceTaxIncFl;
                            }
                        }
                    }
                    #endregion
                }
            }

            #region �ύX�O���P���ݒ�
            if (salesUnitPriceFlg == false)
            {
                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                {
                    // �[���\��
                    case 0:
                        row.BfSalesUnitPrice = 0;
                        break;
                    // �艿�\��
                    case 1:
                        row.BfSalesUnitPrice = row.ListPriceTaxExcFl;
                        break;
                    default:
                        row.BfSalesUnitPrice = 0;
                        break;
                }
            }
            #endregion

            #region ������
            if (salesUnitPriceFlg == false)
            {
                // ���P��
                row.RateSectSalUnPrc = string.Empty;    // �|���ݒ苒�_
                row.RateDivSalUnPrc = string.Empty;      // �|���ݒ�敪
                row.UnPrcCalcCdSalUnPrc = 0;   // �P���Z�o�敪
                row.PriceCdSalUnPrc = 0;       // ���i�敪
                row.StdUnPrcSalUnPrc = 0;      // ��P��
                row.FracProcUnitSalUnPrc = 0;  // �[�������P��
                row.FracProcSalUnPrc = 0;      // �[�������敪

                row.SalesRate = 0;
            }
            if (salesUnitCostFlg == false && !_noneResettingUnitCostFlag)
            {
                // ���P��
                row.RateSectCstUnPrc = string.Empty;    // �|���ݒ苒�_
                row.RateDivUnCst = string.Empty;         // �|���ݒ�敪
                row.UnPrcCalcCdUnCst = 0;      // �P���Z�o�敪
                row.PriceCdUnCst = 0;          // ���i�敪
                row.StdUnPrcUnCst = 0;         // ��P��
                row.FracProcUnitUnCst = 0;     // �[�������P��
                row.FracProcUnCst = 0;         // �[�������敪

                row.CostRate = 0;
                if (salesUnitCostCalcRetFlg == false)
                {
                    row.SalesUnitCost = 0;
                    row.SalesUnitCostTaxExc = 0;
                    row.SalesUnitCostTaxInc = 0;
                }
            }
            if (listPriceFlg == false && !_noneResettingListPriceFlag)
            {
                // �艿
                row.RateSectPriceUnPrc = string.Empty;  // �|���ݒ苒�_
                row.RateDivLPrice = string.Empty;        // �|���ݒ�敪
                row.UnPrcCalcCdLPrice = 0;     // �P���Z�o�敪
                row.PriceCdLPrice = 0;         // ���i�敪
                row.StdUnPrcLPrice = 0;        // ��P��
                row.FracProcUnitLPrice = 0;    // �[�������P��
                row.FracProcLPrice = 0;        // �[�������敪

            }
            #endregion

            this.SalesDetailRowUnitPriceForSalesCodeCheck(row, goodsUnitData);

            if (this._campaignObjGoodsSt != null)
            {
                // �|���Z�o���N���A
                this.ClearRateInfo(ref row, UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice);
            }
        }
        // ------ ADD 2011/09/05 -------- <<<<<

        /// <summary>
        /// �w�肵�����i���I�u�W�F�N�g�����ɒP���Z�o���i��菤�i���i���擾���A���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i���i����ݒ肵�܂��B�i�I�[�o�[���[�h�j
        /// </summary>
        /// <param name="row"></param>
        private void SalesDetailRowGoodsPriceSetting(ref SalesInputDataSet.SalesDetailRow row)
        {
            //>>>2010/10/01
            //GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo);
            GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo, row);
            //<<<2010/10/01
            this.SalesDetailRowGoodsPriceSetting(ref row, goodsUnitData, false);
        }

        /// <summary>
        /// �w�肵�����i���I�u�W�F�N�g�����ɏ��i���i���擾���A���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i���i����ݒ肵�܂��B
        /// </summary>
        /// <param name="row">���㖾�׍s�I�u�W�F�N�g</param>
        /// <param name="goodsUnitData">���i���I�u�W�F�N�g</param>
        /// <br>Update Note: 2011/05/30 ������</br>
        /// <br>             ��L�����y�[���������擾����悤�ɕύX</br>
        /// <br>UpdateNote :  2011/07/06 杍^ ����S�̐ݒ�̔������ݒ莞�̑Ή�</br>
        /// <br>UpdateNote :  2011/07/11 杍^ Redmine#22876 ���P���̒[�������Ɋւ��Ă̏C��</br>
        /// <br>UpdateNote : 2011/07/13 ������ Redmine#22953 �W�����i���O�A����`�[���͂łO���Z�̃G���[���b�Z�[�W���\�����܂���</br>
        /// <br>                               Redmine#22773 [�������ݒ莞�敪���[����\��]�A�|���Ȃ��A�L�����y�[���l������0�̏ꍇ�̕s��C��</br>
        /// <br>UpdateNote :  2011/07/14 杍^ Redmine#22876 ���P���̒[�������Ɋւ��Ă̏C��</br>
        /// <br>Update Note:  2011/08/20 �A��882 ���юR 10704766-00 </br>
        /// <br>             ���艿���\���̂�ǉ�</br>
        private void SalesDetailRowUnitPriceSetting(ref SalesInputDataSet.SalesDetailRow row, GoodsUnitData goodsUnitData)
        {
            #region ����������
            // ����Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // ����Œ[�������P�ʁA�敪�擾
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            // ��������Œ[�������R�[�h(�d����}�X�^���擾)
            int stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
            // ��������Œ[�������P�ʁA�敪�擾
            int stockTaxFracProcCd = 0;
            double stockTaxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockCnsTaxFrcProcCd, 0, out stockTaxFracProcUnit, out stockTaxFracProcCd);

            int taxationCode;
            List<GoodsPrice> goodsPriceList = new List<GoodsPrice>();

            if (goodsUnitData != null)
            {
                taxationCode = goodsUnitData.TaxationDivCd;
                goodsPriceList = goodsUnitData.GoodsPriceList;
            }
            else
            {
                taxationCode = row.TaxationDivCd;
            }
            #endregion

            #region ���艿
            // 2011/08/20 XUJS ADD STA ------>>>>>>
            DateTime tDate = new DateTime();

            switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlip.AcptAnOdrStatusDisplay)
            {
                case AcptAnOdrStatusState.Estimate:
                    tDate = this._salesSlip.SalesDate; // �����
                    break;
                case AcptAnOdrStatusState.UnitPriceEstimate:
                    tDate = this._salesSlip.SalesDate; // �����
                    break;
                case AcptAnOdrStatusState.Sales:
                    tDate = this._salesSlip.SalesDate; // �����
                    break;
                case AcptAnOdrStatusState.Shipment:
                    tDate = this._salesSlip.ShipmentDay; // �o�ד�
                    break;
            }
            object objGoodsPrice = this._salesSlipInputInitDataAcs.GetGoodsPrice(tDate, goodsPriceList);
            if ((objGoodsPrice != null) && (objGoodsPrice is GoodsPrice))
            {
                GoodsPrice gPrice = (GoodsPrice)objGoodsPrice;
                row.GoodsListPrice = gPrice.ListPrice;
            }
            // 2011/08/20 XUJS ADD END ------<<<<<
            //--------------------------------------------
            // �艿
            //--------------------------------------------
            double listPrice = 0;
            // �|���Z�o�����ꍇ�A�|���ݒ�敪�Ɗ���i���ݒ肳��Ă���ꍇ�͊�P�����艿�ƂȂ�
            if ((!string.IsNullOrEmpty(row.RateDivLPrice.Trim())) || (row.StdUnPrcLPrice != 0))
            {
                listPrice = row.StdUnPrcLPrice;	// �|���Z�o�����ꍇ�͊���i���艿
            }
            // �|���Z�o�ł��Ă��Ȃ��ꍇ�́A�艿��\������
            //else if ((goodsPriceList != null) && (row.ListPriceRate == 0))
            // --- UPD m.suzuki 2011/02/16 ---------->>>>>
            //else
            else if (!_noneResettingListPriceFlag)
            // --- UPD m.suzuki 2011/02/16 ----------<<<<<
            {
                DateTime targetDate = new DateTime();

                switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlip.AcptAnOdrStatusDisplay)
                {
                    case AcptAnOdrStatusState.Estimate:
                        targetDate = this._salesSlip.SalesDate; // �����
                        break;
                    case AcptAnOdrStatusState.UnitPriceEstimate:
                        targetDate = this._salesSlip.SalesDate; // �����
                        break;
                    case AcptAnOdrStatusState.Sales:
                        targetDate = this._salesSlip.SalesDate; // �����
                        break;
                    case AcptAnOdrStatusState.Shipment:
                        targetDate = this._salesSlip.ShipmentDay; // �o�ד�
                        break;
                }

                //-----------------------------------------------------------------------
                // ���i��񂪑��݂���ꍇ�́A���i��񂩂��艿�m��
                //-----------------------------------------------------------------------
                if (goodsPriceList != null)
                {
                    object obj = this._salesSlipInputInitDataAcs.GetGoodsPrice(targetDate, goodsPriceList);
                    if ((obj != null) && (obj is GoodsPrice))
                    {
                        GoodsPrice goodsPrice = (GoodsPrice)obj;
                        //row.NewListPrice = goodsPrice.NewPrice;
                        //row.NewListPriceStartDate = goodsPrice.NewPriceStartDate;
                        //row.OldListPrice = goodsPrice.OldPrice;
                        //row.ListPriceOpenDiv = goodsPrice.OpenPriceDiv;
                        row.OpenPriceDiv = goodsPrice.OpenPriceDiv;

                        //listPrice = this.GetPrice(targetDate, row.NewListPrice, row.OldListPrice, row.NewListPriceStartDate, goodsPrice.OpenPriceDiv);
                        listPrice = goodsPrice.ListPrice;
                    }
                }
                //-----------------------------------------------------------------------
                // ���i��񂪑��݂��Ȃ��ꍇ�́A�e�[�u�����̉��i��񂩂��艿�m��
                //-----------------------------------------------------------------------
                else
                {
                    //listPrice = this.GetPrice(targetDate, row.NewListPrice, row.OldListPrice, row.NewListPriceStartDate, row.ListPriceOpenDiv);
                    // ����
                    listPrice = row.ListPriceDisplay;
                }

                //--------------------------------------------------
                // �艿
                //--------------------------------------------------
                double listPriceTaxExc;
                double listPriceTaxInc;
                if (row.ListPriceTaxExcFl != 0)
                {
                    listPriceTaxExc = row.ListPriceTaxExcFl;
                }
                else
                {
                    listPriceTaxExc = listPrice;
                }
                if (row.ListPriceTaxIncFl != 0)
                {
                    listPriceTaxInc = row.ListPriceTaxIncFl;
                }
                else
                {
                    listPriceTaxInc = listPrice;
                }

                row.CanTaxDivChange = false;

                //--------------------------------------------------
                // ��ې�
                //--------------------------------------------------
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                {
                    row.ListPriceTaxIncFl = listPriceTaxExc;
                    row.ListPriceTaxExcFl = listPriceTaxExc;
                    row.ListPriceDisplay = row.ListPriceTaxExcFl;
                }
                //--------------------------------------------------
                // ���z�\�����Ȃ�
                //--------------------------------------------------
                else if (this._salesSlip.TotalAmountDispWayCd == 0)
                {

                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // �艿
                            //--------------------------------------------------
                            // �@��艿 = �艿(�Ŕ�)
                            //row.StdUnPrcLPrice = listPriceTaxExc;

                            // �A�艿(�Ŕ�) = �|���K�p��̒艿
                            row.ListPriceTaxExcFl = listPriceTaxExc;

                            // �B�艿(�ō�) = �艿(�Ŕ�) + (�艿(�Ŕ�) * �ŗ�)
                            row.ListPriceTaxIncFl = listPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxExc);

                            // �艿(�\��) = �艿(�Ŕ�)
                            row.ListPriceDisplay = row.ListPriceTaxExcFl;


                            // �ېŋ敪���O��
                            row.TaxationDivCd = 0;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // �艿
                            //--------------------------------------------------
                            // �@��艿 = �艿(�Ŕ�)
                            //row.StdUnPrcLPrice = listPriceTaxExc;

                            // �A�艿(�ō�) = �|���K�p��̒艿
                            row.ListPriceTaxIncFl = listPriceTaxInc;

                            // �B�艿(�Ŕ�) = �艿(�ō�) - (�艿(�ō�)* �ŗ�/�ŗ�+100)
                            row.ListPriceTaxExcFl = listPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxInc);

                            // �艿(�\��) = �艿(�ō�)
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;

                            // �ېŋ敪������
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // �艿
                            //--------------------------------------------------
                            //row.StdUnPrcLPrice = listPriceTaxExc;
                            row.ListPriceTaxIncFl = listPriceTaxExc;
                            row.ListPriceTaxExcFl = listPriceTaxExc;
                            row.ListPriceDisplay = row.ListPriceTaxExcFl;

                            // �ېŋ敪����ې�
                            row.TaxationDivCd = 1;
                            break;
                    }
                }
                //--------------------------------------------------
                // ���z�\������
                //--------------------------------------------------
                else if (this._salesSlip.TotalAmountDispWayCd == 1)
                {

                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // �艿
                            //--------------------------------------------------
                            // �@��艿 = �艿(�Ŕ�)
                            //row.StdUnPrcLPrice = listPriceTaxExc;

                            // �A�艿(�Ŕ�) = �|���K�p��̒艿
                            row.ListPriceTaxExcFl = listPriceTaxExc;

                            // �B�艿(�ō�) = �艿(�Ŕ�) + (�艿(�Ŕ�) * �ŗ�)
                            row.ListPriceTaxIncFl = listPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxExc);

                            // �艿(�\��) = �艿(�ō�)
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;

                            // �ېŋ敪���O��
                            row.TaxationDivCd = 0; // �e�[�u���Z�b�g�l�͕ύX���Ȃ�
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // �艿
                            //--------------------------------------------------
                            // �@��艿 = �艿(�Ŕ�)
                            //row.StdUnPrcLPrice = listPriceTaxExc;

                            // �A�艿(�ō�) = �|���K�p��̒艿
                            row.ListPriceTaxIncFl = listPriceTaxInc;

                            // �B�艿(�Ŕ�) = �艿(�ō�) - (�艿(�ō�)* �ŗ�/�ŗ�+100)
                            row.ListPriceTaxExcFl = listPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxInc);

                            // �艿(�\��) = �艿(�Ŕ�)
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;

                            // �ېŋ敪������
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // �艿
                            //--------------------------------------------------
                            //row.StdUnPrcLPrice = listPriceTaxExc;
                            row.ListPriceTaxExcFl = listPriceTaxExc;
                            row.ListPriceTaxIncFl = listPriceTaxExc;
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;
                            row.TaxationDivCd = 1;									// �ېŋ敪����ې�
                            break;
                    }
                }
            }
            #endregion

            #region �����P��
            //--------------------------------------------
            // ���P��
            //--------------------------------------------
            double unitCost = 0;
            // �|���Z�o�����ꍇ�A�|���ݒ�敪�Ɗ���i���ݒ肳��Ă���ꍇ�͊�P���������ƂȂ�
            if ((!string.IsNullOrEmpty(row.RateDivUnCst.Trim())) || (row.StdUnPrcUnCst != 0))
            {
                unitCost = row.StdUnPrcUnCst;	// �|���Z�o�����ꍇ�͊���i������
            }
            // �|���Z�o�ł��Ă��Ȃ��ꍇ�́A�[����\������
            //else if ((goodsPriceList != null) && (row.CostRate == 0))
            else
            {
                //unitCost = listPrice;
                unitCost = 0;

                //--------------------------------------------------
                // ���P��
                //--------------------------------------------------
                double unitCostTaxExc;
                double unitCostTaxInc;
                if (row.SalesUnitCostTaxExc != 0)
                {
                    unitCostTaxExc = row.SalesUnitCostTaxExc;
                }
                else
                {
                    unitCostTaxExc = unitCost;
                }
                if (row.SalesUnitCostTaxInc != 0)
                {
                    unitCostTaxInc = row.SalesUnitCostTaxInc;
                }
                else
                {
                    unitCostTaxInc = unitCost;
                }

                row.CanTaxDivChange = false;

                //--------------------------------------------------
                // ��ې�
                //--------------------------------------------------
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                {
                    row.SalesUnitCostTaxInc = unitCostTaxExc;
                    row.SalesUnitCostTaxExc = unitCostTaxExc;
                    row.SalesUnitCost = row.SalesUnitCostTaxExc;
                }
                else
                {
                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // ���P��
                            //--------------------------------------------------
                            // �@����� = ����(�Ŕ�)
                            //row.StdUnPrcUnCst = unitCostTaxExc;

                            // �A����(�Ŕ�) = �|���K�p��̌���
                            row.SalesUnitCostTaxExc = unitCostTaxExc;

                            // �B����(�ō�) = ����(�Ŕ�) + (����(�Ŕ�) * �ŗ�)
                            row.SalesUnitCostTaxInc = unitCostTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, stockTaxFracProcUnit, stockTaxFracProcCd, unitCostTaxExc);

                            // ����(�\��) = ����(�Ŕ�)
                            row.SalesUnitCost = row.SalesUnitCostTaxExc;

                            // �ېŋ敪���O��
                            row.TaxationDivCd = 0;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // ���P��
                            //--------------------------------------------------
                            // �@����� = ����(�Ŕ�)
                            //row.StdUnPrcUnCst = unitCostTaxExc;

                            // �A����(�ō�) = �|���K�p��̌���
                            row.SalesUnitCostTaxInc = unitCostTaxInc;

                            // �B����(�Ŕ�) = ����(�ō�) - (����(�ō�)* �ŗ�/�ŗ�+100)
                            row.SalesUnitCostTaxExc = unitCostTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, stockTaxFracProcUnit, stockTaxFracProcCd, unitCostTaxInc);

                            // ����(�\��) = ����(�ō�)
                            row.SalesUnitCost = row.SalesUnitCostTaxInc;

                            // �ېŋ敪������
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // ���P��
                            //--------------------------------------------------
                            //row.StdUnPrcUnCst = unitCostTaxExc;
                            row.SalesUnitCostTaxInc = unitCostTaxExc;
                            row.SalesUnitCostTaxExc = unitCostTaxExc;
                            row.SalesUnitCost = row.SalesUnitCostTaxExc;

                            // �ېŋ敪����ې�
                            row.TaxationDivCd = 1;
                            break;
                    }
                }
            }
            #endregion

            #region �����P��
            //--------------------------------------------
            // ���P��
            //--------------------------------------------
            double unitPrice = 0;
            // �|���Z�o�����ꍇ�A�|���ݒ�敪�Ɗ���i���ݒ肳��Ă���ꍇ�͊�P�������P���ƂȂ�
            if ((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0))
            {
                unitPrice = row.StdUnPrcSalUnPrc;	// �|���Z�o�����ꍇ�͊���i�����P��
            }
            // �|���Z�o�ł��Ă��Ȃ��ꍇ(������z����͈ȊO)
            else if (row.SalesMoneyInputDiv != (int)SalesMoneyInputDiv.Input)
            {
                double goodsPriceTaxExc;
                double goodsPriceTaxInc;
                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                {
                    // �[���\��
                    case 0:
                        goodsPriceTaxExc = 0;
                        goodsPriceTaxInc = 0;
                        break;
                    // �艿�\��
                    case 1:
                        goodsPriceTaxExc = row.ListPriceTaxExcFl;
                        goodsPriceTaxInc = row.ListPriceTaxIncFl;
                        break;
                    default:
                        goodsPriceTaxExc = 0;
                        goodsPriceTaxInc = 0;
                        break;
                }

                row.UnPrcCalcCdSalUnPrcTemp = -1;  // ADD 2011/08/15

                //>>>2010/02/26
                //-----------------------------------------------------------------------------
                // �L�����y�[�����i���f
                //-----------------------------------------------------------------------------
                // ---UPD 2011/05/30------------>>>>>
                //this.ReflectCampaign(row.TaxationDivCd, this._salesSlip.CustomerCode, row.GoodsMGroup, row.BLGoodsCode, row.GoodsMakerCd, row.GoodsNo, this._salesSlip.SalesDate, ref goodsPriceTaxExc);
                this.ReflectCampaign(row.TaxationDivCd, this._salesSlip.CustomerCode, row.BLGoodsCode, row.GoodsMakerCd, row.GoodsNo, row.BLGroupCode, row.SalesCode, this._salesSlip.SalesDate, ref goodsPriceTaxExc);

                // --- ADD 2011/07/06  ---- >>>>>>
                if (this._campaignObjGoodsSt != null)
                {
                    // ---UPD 2011/07/13------------------>>>>>
                    if (this._campaignObjGoodsSt.DiscountRate != 0 && this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv != 1)
                    {
                        goodsPriceTaxExc = 0;
                        goodsPriceTaxInc = 0;
                    }
                    else
                    {
                        goodsPriceTaxExc = row.ListPriceTaxExcFl;
                        goodsPriceTaxInc = row.ListPriceTaxIncFl;
                    }
                    // ---UPD 2011/07/13------------------<<<<<

                    // �L�����y�[���|���K�p
                    if (this._campaignObjGoodsSt.RateVal != 0)
                    {
                        this.CalclatePriceByRate(taxationCode, this._campaignObjGoodsSt.RateVal, ref goodsPriceTaxExc);
                    }

                    // �L�����y�[�������z��0�̏ꍇ
                    if (this._campaignObjGoodsSt.PriceFl != 0)
                    {
                        goodsPriceTaxExc = this._campaignObjGoodsSt.PriceFl;
                    }
                    // ADD �� 2014/03/20 -------------------------->>>>>
                    Broadleaf.Application.Remoting.ParamData.PurchaseStatus ps;
                    ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_MaehashiKyowaUpdDateCtrl);

                    if (ps == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                    {
                        row.RateUpdateTimeSales = this._campaignObjGoodsSt.UpdateDateTimeAdFormal;
                    }
                    // ADD �� 2014/03/20 --------------------------<<<<<

                    // �L�����y�[���l�����K�p
                    if (this._campaignObjGoodsSt.DiscountRate != 0)
                    {
                        this.CalclatePriceByRate(taxationCode, 100 - this._campaignObjGoodsSt.DiscountRate, ref goodsPriceTaxExc);
                    }

                    row.SalesRate = this._campaignObjGoodsSt.RateVal;
                    //-----ADD 2011/09/05 ------>>>>>
                    row.CampaignCode = this._campaignObjGoodsSt.CampaignCode;
                    row.CampaignRate = this._campaignObjGoodsSt.RateVal;
                    row.CampaignDiscountRate = this._campaignObjGoodsSt.DiscountRate;
                    row.CampaignPriceFl = this._campaignObjGoodsSt.PriceFl;
                    row.CampaignSettingKind = this._campaignObjGoodsSt.CampaignSettingKind;  // ADD 2011/09/14
                    //-----ADD 2011/09/05 ------<<<<<
                }
                // --- ADD 2011/07/06  ---- <<<<<<
                // --- DEL 2011/07/14  ---- >>>>>>
                //if ((this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv == 1)
                //    || (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv == 0 && row.SalesRate != 0))
                //{
                //    if (this._campaignObjGoodsSt != null)
                //    {
                //        // �L�����y�[�����i�K�p
                //        if (this._campaignObjGoodsSt.PriceFl != 0)
                //        {
                //            goodsPriceTaxExc = this._campaignObjGoodsSt.PriceFl;
                //        }

                //        if (this._campaignObjGoodsSt.RateVal != 0)
                //        {
                //            row.SalesRate = this._campaignObjGoodsSt.RateVal;
                //            goodsPriceTaxExc = row.ListPriceDisplay * row.SalesRate / 100;
                //        }
                //    }
                //}

                //// ----- ADD 2011/07/11 ------- >>>>>>>>>
                //if (this._campaignObjGoodsSt != null)
                //{
                //    // ------UPD 2011/07/13-------------->>>>>
                //    //if (this._campaignObjGoodsSt.PriceFl == 0)
                //    if (this._campaignObjGoodsSt.PriceFl == 0 && taxFracProcUnit != 0)
                //    // ------UPD 2011/07/13-------------->>>>>
                //    {
                //        // ���P���i�Ŕ��j
                //        FractionCalculate.FracCalcMoney(goodsPriceTaxExc, taxFracProcUnit, taxFracProcCd, out goodsPriceTaxExc);
                //    }
                //}
                // ----- ADD 2011/07/11 ------- <<<<<<<<<
                // ---UPD 2011/05/30------------<<<<<
                // --- DEL 2011/07/14  ---- <<<<<<
                //-----------------------------------------------------------------------------
                // ���i�ăZ�b�g
                //-----------------------------------------------------------------------------
                double priceTaxExc;
                double priceTaxInc;
                this.CalcTaxExcAndTaxInc(row.TaxationDivCd, this._salesSlip.CustomerCode, this._salesSlipInputInitDataAcs.TaxRate, this._salesSlip.TotalAmountDispWayCd, goodsPriceTaxExc, out priceTaxExc, out priceTaxInc);
                row.SalesUnPrcTaxExcFl = priceTaxExc;
                row.SalesUnPrcTaxIncFl = priceTaxInc;
                //<<<2010/02/26

                //--------------------------------------------------
                // ���P��
                //--------------------------------------------------
                if (row.SalesUnPrcTaxExcFl != 0) goodsPriceTaxExc = row.SalesUnPrcTaxExcFl;
                if (row.SalesUnPrcTaxIncFl != 0) goodsPriceTaxInc = row.SalesUnPrcTaxIncFl;

                row.CanTaxDivChange = false;

                //--------------------------------------------------
                // ��ې�
                //--------------------------------------------------
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                {
                    row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;
                    row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                    row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                }

                else if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
                {
                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            // �@��P�� = �Ŕ��P��
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // �A����P��(�Ŕ�) = �|���K�p��̎d���P��
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // �B����P��(�ō�) = ����P��(�Ŕ�) + (����P��(�Ŕ�) * �ŗ�)
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // �\���P�� = �Ŕ��P��
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;

                            // �ېŋ敪���O��
                            row.TaxationDivCd = 0;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            // �@��P�� = �Ŕ����i
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // �A����P��(�ō�) = �|���K�p��̎d���P��
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // �B����P��(�Ŕ�) = ����P��(�ō�) - (����P��(�ō�)* �ŗ�/�ŗ�+100)
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // �\���P�� = �ō��P��
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                            // �ېŋ敪������
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc;
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;

                            // �ېŋ敪����ې�
                            row.TaxationDivCd = 1;
                            break;
                    }
                }
                //--------------------------------------------------
                // ���z�\������
                //--------------------------------------------------
                else if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount)
                {
                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // ���P��
                            //--------------------------------------------------
                            // �@��P�� = �Ŕ��P��
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // �A����P��(�Ŕ�) = �|���K�p��̎d���P��
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // �B����P��(�ō�) = ����P��(�Ŕ�) + (����P��(�Ŕ�) * �ŗ�)
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // �\���P�� = �ō��P��
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                            // �ېŋ敪���O��
                            row.TaxationDivCd = 0; // �e�[�u���Z�b�g�l�͕ύX���Ȃ�
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // ���P��
                            //--------------------------------------------------
                            // �@��P�� = �Ŕ����i
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // �A����P��(�ō�) = �|���K�p��̎d���P��
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // �B����P��(�Ŕ�) = ����P��(�ō�) - (����P��(�ō�)* �ŗ�/�ŗ�+100)
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // �\���P�� = �ō��P��
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                            // �ېŋ敪������
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // ���P��
                            //--------------------------------------------------
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                            row.TaxationDivCd = 1;									// �ېŋ敪����ې�
                            break;
                    }
                }

                #region �폜 2008.12.10
                //--------------------------------------------------
                // ���z�\�����Ȃ�
                //--------------------------------------------------
                //else if (this._salesSlip.TotalAmountDispWayCd == 0)
                //{
                //    switch ((CalculateTax.TaxationCode)taxationCode)
                //    {
                //        case CalculateTax.TaxationCode.TaxExc:
                //            //--------------------------------------------------
                //            // ���P��
                //            //--------------------------------------------------
                //            // �@��P�� = �Ŕ��P��
                //            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                //            // �A����P��(�Ŕ�) = �|���K�p��̎d���P��
                //            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                //            // �B����P��(�ō�) = ����P��(�Ŕ�) + (����P��(�Ŕ�) * �ŗ�)
                //            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, goodsPriceTaxExc);

                //            // �\���P�� = �Ŕ��P��
                //            row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;

                //            // �ېŋ敪���O��
                //            row.TaxationDivCd = 0;
                //            break;
                //        case CalculateTax.TaxationCode.TaxInc:
                //            //--------------------------------------------------
                //            // ���P��
                //            //--------------------------------------------------
                //            // �@��P�� = �Ŕ����i
                //            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                //            // �A����P��(�ō�) = �|���K�p��̎d���P��
                //            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                //            // �B����P��(�Ŕ�) = ����P��(�ō�) - (����P��(�ō�)* �ŗ�/�ŗ�+100)
                //            row.SalesUnPrcTaxExcFl = goodsPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, goodsPriceTaxInc);

                //            // �\���P�� = �ō��P��
                //            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                //            // �ېŋ敪������
                //            row.TaxationDivCd = 2;
                //            break;
                //        case CalculateTax.TaxationCode.TaxNone:
                //            //--------------------------------------------------
                //            // ���P��
                //            //--------------------------------------------------
                //            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;
                //            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc;
                //            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                //            row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;

                //            // �ېŋ敪����ې�
                //            row.TaxationDivCd = 1;
                //            break;
                //    }
                //}
                ////--------------------------------------------------
                //// ���z�\������
                ////--------------------------------------------------
                //else if (this._salesSlip.TotalAmountDispWayCd == 1)
                //{
                //    switch ((CalculateTax.TaxationCode)taxationCode)
                //    {
                //        case CalculateTax.TaxationCode.TaxExc:
                //            //--------------------------------------------------
                //            // ���P��
                //            //--------------------------------------------------
                //            // �@��P�� = �Ŕ��P��
                //            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                //            // �A����P��(�Ŕ�) = �|���K�p��̎d���P��
                //            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                //            // �B����P��(�ō�) = ����P��(�Ŕ�) + (����P��(�Ŕ�) * �ŗ�)
                //            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, goodsPriceTaxExc);

                //            // �\���P�� = �ō��P��
                //            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                //            // �ېŋ敪���O��
                //            row.TaxationDivCd = 0; // �e�[�u���Z�b�g�l�͕ύX���Ȃ�
                //            break;
                //        case CalculateTax.TaxationCode.TaxInc:
                //            //--------------------------------------------------
                //            // ���P��
                //            //--------------------------------------------------
                //            // �@��P�� = �Ŕ����i
                //            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                //            // �A����P��(�ō�) = �|���K�p��̎d���P��
                //            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                //            // �B����P��(�Ŕ�) = ����P��(�ō�) - (����P��(�ō�)* �ŗ�/�ŗ�+100)
                //            row.SalesUnPrcTaxExcFl = goodsPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, goodsPriceTaxInc);

                //            // �\���P�� = �ō��P��
                //            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                //            // �ېŋ敪������
                //            row.TaxationDivCd = 2;
                //            break;
                //        case CalculateTax.TaxationCode.TaxNone:
                //            //--------------------------------------------------
                //            // ���P��
                //            //--------------------------------------------------
                //            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;
                //            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                //            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc;
                //            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                //            row.TaxationDivCd = 1;									// �ېŋ敪����ې�
                //            break;
                //    }
                //}
                #endregion

            }
            #endregion

            #region ������
            if (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
            {
                row.TaxDiv = 1;												// �ېŋ敪����ې�
            }
            else
            {
                row.TaxDiv = 0;												// �ېŋ敪���ې�
            }
            #endregion
        }

        // ------ ADD 2011/09/05 --------- >>>>>>
        /// <summary>
        /// �w�肵�����i���I�u�W�F�N�g�����ɏ��i���i���擾���A���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i���i����ݒ肵�܂��B
        /// </summary>
        /// <param name="row">���㖾�׍s�I�u�W�F�N�g</param>
        /// <param name="goodsUnitData">���i���I�u�W�F�N�g</param>
        /// <br>Update Note: 2011/05/30 ������</br>
        /// <br>             ��L�����y�[���������擾����悤�ɕύX</br>
        /// <br>UpdateNote :  2011/07/06 杍^ ����S�̐ݒ�̔������ݒ莞�̑Ή�</br>
        /// <br>UpdateNote :  2011/07/11 杍^ Redmine#22876 ���P���̒[�������Ɋւ��Ă̏C��</br>
        /// <br>UpdateNote : 2011/07/13 ������ Redmine#22953 �W�����i���O�A����`�[���͂łO���Z�̃G���[���b�Z�[�W���\�����܂���</br>
        /// <br>                               Redmine#22773 [�������ݒ莞�敪���[����\��]�A�|���Ȃ��A�L�����y�[���l������0�̏ꍇ�̕s��C��</br>
        /// <br>UpdateNote :  2011/07/14 杍^ Redmine#22876 ���P���̒[�������Ɋւ��Ă̏C��</br>
        private void SalesDetailRowUnitPriceForSalesCodeCheck(SalesInputDataSet.SalesDetailRow row, GoodsUnitData goodsUnitData)
        {
            #region ����������
            // ����Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // ����Œ[�������P�ʁA�敪�擾
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            // ��������Œ[�������R�[�h(�d����}�X�^���擾)
            int stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
            // ��������Œ[�������P�ʁA�敪�擾
            int stockTaxFracProcCd = 0;
            double stockTaxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockCnsTaxFrcProcCd, 0, out stockTaxFracProcUnit, out stockTaxFracProcCd);

            int taxationCode;
            List<GoodsPrice> goodsPriceList = new List<GoodsPrice>();

            if (goodsUnitData != null)
            {
                taxationCode = goodsUnitData.TaxationDivCd;
                goodsPriceList = goodsUnitData.GoodsPriceList;
            }
            else
            {
                taxationCode = row.TaxationDivCd;
            }
            #endregion

            #region ���艿
            //--------------------------------------------
            // �艿
            //--------------------------------------------
            double listPrice = 0;
            // �|���Z�o�����ꍇ�A�|���ݒ�敪�Ɗ���i���ݒ肳��Ă���ꍇ�͊�P�����艿�ƂȂ�
            if ((!string.IsNullOrEmpty(row.RateDivLPrice.Trim())) || (row.StdUnPrcLPrice != 0))
            {
                listPrice = row.StdUnPrcLPrice;	// �|���Z�o�����ꍇ�͊���i���艿
            }
            // �|���Z�o�ł��Ă��Ȃ��ꍇ�́A�艿��\������
            else if (!_noneResettingListPriceFlag)
            {
                DateTime targetDate = new DateTime();

                switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlip.AcptAnOdrStatusDisplay)
                {
                    case AcptAnOdrStatusState.Estimate:
                        targetDate = this._salesSlip.SalesDate; // �����
                        break;
                    case AcptAnOdrStatusState.UnitPriceEstimate:
                        targetDate = this._salesSlip.SalesDate; // �����
                        break;
                    case AcptAnOdrStatusState.Sales:
                        targetDate = this._salesSlip.SalesDate; // �����
                        break;
                    case AcptAnOdrStatusState.Shipment:
                        targetDate = this._salesSlip.ShipmentDay; // �o�ד�
                        break;
                }

                //-----------------------------------------------------------------------
                // ���i��񂪑��݂���ꍇ�́A���i��񂩂��艿�m��
                //-----------------------------------------------------------------------
                if (goodsPriceList != null)
                {
                    object obj = this._salesSlipInputInitDataAcs.GetGoodsPrice(targetDate, goodsPriceList);
                    if ((obj != null) && (obj is GoodsPrice))
                    {
                        GoodsPrice goodsPrice = (GoodsPrice)obj;
                        row.OpenPriceDiv = goodsPrice.OpenPriceDiv;
                        listPrice = goodsPrice.ListPrice;
                    }
                }
                //-----------------------------------------------------------------------
                // ���i��񂪑��݂��Ȃ��ꍇ�́A�e�[�u�����̉��i��񂩂��艿�m��
                //-----------------------------------------------------------------------
                else
                {
                    // ����
                    listPrice = row.ListPriceDisplay;
                }

                //--------------------------------------------------
                // �艿
                //--------------------------------------------------
                double listPriceTaxExc;
                double listPriceTaxInc;
                if (row.ListPriceTaxExcFl != 0)
                {
                    listPriceTaxExc = row.ListPriceTaxExcFl;
                }
                else
                {
                    listPriceTaxExc = listPrice;
                }
                if (row.ListPriceTaxIncFl != 0)
                {
                    listPriceTaxInc = row.ListPriceTaxIncFl;
                }
                else
                {
                    listPriceTaxInc = listPrice;
                }

                row.CanTaxDivChange = false;

                //--------------------------------------------------
                // ��ې�
                //--------------------------------------------------
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                {
                    row.ListPriceTaxIncFl = listPriceTaxExc;
                    row.ListPriceTaxExcFl = listPriceTaxExc;
                    row.ListPriceDisplay = row.ListPriceTaxExcFl;
                }
                //--------------------------------------------------
                // ���z�\�����Ȃ�
                //--------------------------------------------------
                else if (this._salesSlip.TotalAmountDispWayCd == 0)
                {

                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // �艿
                            //--------------------------------------------------

                            // �A�艿(�Ŕ�) = �|���K�p��̒艿
                            row.ListPriceTaxExcFl = listPriceTaxExc;

                            // �B�艿(�ō�) = �艿(�Ŕ�) + (�艿(�Ŕ�) * �ŗ�)
                            row.ListPriceTaxIncFl = listPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxExc);

                            // �艿(�\��) = �艿(�Ŕ�)
                            row.ListPriceDisplay = row.ListPriceTaxExcFl;


                            // �ېŋ敪���O��
                            row.TaxationDivCd = 0;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // �艿
                            //--------------------------------------------------

                            // �A�艿(�ō�) = �|���K�p��̒艿
                            row.ListPriceTaxIncFl = listPriceTaxInc;

                            // �B�艿(�Ŕ�) = �艿(�ō�) - (�艿(�ō�)* �ŗ�/�ŗ�+100)
                            row.ListPriceTaxExcFl = listPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxInc);

                            // �艿(�\��) = �艿(�ō�)
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;

                            // �ېŋ敪������
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // �艿
                            //--------------------------------------------------
                            //row.StdUnPrcLPrice = listPriceTaxExc;
                            row.ListPriceTaxIncFl = listPriceTaxExc;
                            row.ListPriceTaxExcFl = listPriceTaxExc;
                            row.ListPriceDisplay = row.ListPriceTaxExcFl;

                            // �ېŋ敪����ې�
                            row.TaxationDivCd = 1;
                            break;
                    }
                }
                //--------------------------------------------------
                // ���z�\������
                //--------------------------------------------------
                else if (this._salesSlip.TotalAmountDispWayCd == 1)
                {

                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // �艿
                            //--------------------------------------------------

                            // �A�艿(�Ŕ�) = �|���K�p��̒艿
                            row.ListPriceTaxExcFl = listPriceTaxExc;

                            // �B�艿(�ō�) = �艿(�Ŕ�) + (�艿(�Ŕ�) * �ŗ�)
                            row.ListPriceTaxIncFl = listPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxExc);

                            // �艿(�\��) = �艿(�ō�)
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;

                            // �ېŋ敪���O��
                            row.TaxationDivCd = 0; // �e�[�u���Z�b�g�l�͕ύX���Ȃ�
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // �艿
                            //--------------------------------------------------

                            // �A�艿(�ō�) = �|���K�p��̒艿
                            row.ListPriceTaxIncFl = listPriceTaxInc;

                            // �B�艿(�Ŕ�) = �艿(�ō�) - (�艿(�ō�)* �ŗ�/�ŗ�+100)
                            row.ListPriceTaxExcFl = listPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxInc);

                            // �艿(�\��) = �艿(�Ŕ�)
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;

                            // �ېŋ敪������
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // �艿
                            //--------------------------------------------------
                            row.ListPriceTaxExcFl = listPriceTaxExc;
                            row.ListPriceTaxIncFl = listPriceTaxExc;
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;
                            row.TaxationDivCd = 1;									// �ېŋ敪����ې�
                            break;
                    }
                }
            }
            #endregion

            #region �����P��
            //--------------------------------------------
            // ���P��
            //--------------------------------------------
            double unitCost = 0;
            // �|���Z�o�����ꍇ�A�|���ݒ�敪�Ɗ���i���ݒ肳��Ă���ꍇ�͊�P���������ƂȂ�
            if ((!string.IsNullOrEmpty(row.RateDivUnCst.Trim())) || (row.StdUnPrcUnCst != 0))
            {
                unitCost = row.StdUnPrcUnCst;	// �|���Z�o�����ꍇ�͊���i������
            }
            // �|���Z�o�ł��Ă��Ȃ��ꍇ�́A�[����\������
            else
            {
                unitCost = 0;

                //--------------------------------------------------
                // ���P��
                //--------------------------------------------------
                double unitCostTaxExc;
                double unitCostTaxInc;
                if (row.SalesUnitCostTaxExc != 0)
                {
                    unitCostTaxExc = row.SalesUnitCostTaxExc;
                }
                else
                {
                    unitCostTaxExc = unitCost;
                }
                if (row.SalesUnitCostTaxInc != 0)
                {
                    unitCostTaxInc = row.SalesUnitCostTaxInc;
                }
                else
                {
                    unitCostTaxInc = unitCost;
                }

                row.CanTaxDivChange = false;

                //--------------------------------------------------
                // ��ې�
                //--------------------------------------------------
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                {
                    row.SalesUnitCostTaxInc = unitCostTaxExc;
                    row.SalesUnitCostTaxExc = unitCostTaxExc;
                    row.SalesUnitCost = row.SalesUnitCostTaxExc;
                }
                else
                {
                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // ���P��
                            //--------------------------------------------------

                            // �A����(�Ŕ�) = �|���K�p��̌���
                            row.SalesUnitCostTaxExc = unitCostTaxExc;

                            // �B����(�ō�) = ����(�Ŕ�) + (����(�Ŕ�) * �ŗ�)
                            row.SalesUnitCostTaxInc = unitCostTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, stockTaxFracProcUnit, stockTaxFracProcCd, unitCostTaxExc);

                            // ����(�\��) = ����(�Ŕ�)
                            row.SalesUnitCost = row.SalesUnitCostTaxExc;

                            // �ېŋ敪���O��
                            row.TaxationDivCd = 0;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // ���P��
                            //--------------------------------------------------

                            // �A����(�ō�) = �|���K�p��̌���
                            row.SalesUnitCostTaxInc = unitCostTaxInc;

                            // �B����(�Ŕ�) = ����(�ō�) - (����(�ō�)* �ŗ�/�ŗ�+100)
                            row.SalesUnitCostTaxExc = unitCostTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, stockTaxFracProcUnit, stockTaxFracProcCd, unitCostTaxInc);

                            // ����(�\��) = ����(�ō�)
                            row.SalesUnitCost = row.SalesUnitCostTaxInc;

                            // �ېŋ敪������
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // ���P��
                            //--------------------------------------------------
                            //row.StdUnPrcUnCst = unitCostTaxExc;
                            row.SalesUnitCostTaxInc = unitCostTaxExc;
                            row.SalesUnitCostTaxExc = unitCostTaxExc;
                            row.SalesUnitCost = row.SalesUnitCostTaxExc;

                            // �ېŋ敪����ې�
                            row.TaxationDivCd = 1;
                            break;
                    }
                }
            }
            #endregion

            #region �����P��
            //--------------------------------------------
            // ���P��
            //--------------------------------------------
            double unitPrice = 0;
            // �|���Z�o�����ꍇ�A�|���ݒ�敪�Ɗ���i���ݒ肳��Ă���ꍇ�͊�P�������P���ƂȂ�
            if ((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0))
            {
                unitPrice = row.StdUnPrcSalUnPrc;	// �|���Z�o�����ꍇ�͊���i�����P��
            }
            // �|���Z�o�ł��Ă��Ȃ��ꍇ(������z����͈ȊO)
            else if (row.SalesMoneyInputDiv != (int)SalesMoneyInputDiv.Input)
            {
                double goodsPriceTaxExc;
                double goodsPriceTaxInc;
                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                {
                    // �[���\��
                    case 0:
                        goodsPriceTaxExc = 0;
                        goodsPriceTaxInc = 0;
                        break;
                    // �艿�\��
                    case 1:
                        goodsPriceTaxExc = row.ListPriceTaxExcFl;
                        goodsPriceTaxInc = row.ListPriceTaxIncFl;
                        break;
                    default:
                        goodsPriceTaxExc = 0;
                        goodsPriceTaxInc = 0;
                        break;
                }

                row.UnPrcCalcCdSalUnPrcTemp = -1; 

                //-----------------------------------------------------------------------------
                // �L�����y�[�����i���f
                //-----------------------------------------------------------------------------
                this.ReflectCampaign(row.TaxationDivCd, this._salesSlip.CustomerCode, row.BLGoodsCode, row.GoodsMakerCd, row.GoodsNo, row.BLGroupCode, row.SalesCode, this._salesSlip.SalesDate, ref goodsPriceTaxExc);

                if (this._campaignObjGoodsSt != null)
                {
                    if (this._campaignObjGoodsSt.DiscountRate != 0 && this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv != 1)
                    {
                        goodsPriceTaxExc = 0;
                        goodsPriceTaxInc = 0;
                    }
                    else
                    {
                        goodsPriceTaxExc = row.ListPriceTaxExcFl;
                        goodsPriceTaxInc = row.ListPriceTaxIncFl;
                    }

                    // �L�����y�[���|���K�p
                    if (this._campaignObjGoodsSt.RateVal != 0)
                    {
                        this.CalclatePriceByRate(taxationCode, this._campaignObjGoodsSt.RateVal, ref goodsPriceTaxExc);
                    }

                    // �L�����y�[�������z��0�̏ꍇ
                    if (this._campaignObjGoodsSt.PriceFl != 0)
                    {
                        goodsPriceTaxExc = this._campaignObjGoodsSt.PriceFl;
                    }

                    // �L�����y�[���l�����K�p
                    if (this._campaignObjGoodsSt.DiscountRate != 0)
                    {
                        this.CalclatePriceByRate(taxationCode, 100 - this._campaignObjGoodsSt.DiscountRate, ref goodsPriceTaxExc);
                    }

                    row.SalesRate = this._campaignObjGoodsSt.RateVal;
                    row.CampaignRate = this._campaignObjGoodsSt.RateVal;
                    row.CampaignDiscountRate = this._campaignObjGoodsSt.DiscountRate;
                    row.CampaignPriceFl = this._campaignObjGoodsSt.PriceFl;
                    row.CampaignSettingKind = this._campaignObjGoodsSt.CampaignSettingKind;  // ADD 2011/09/14

                }
                //-----------------------------------------------------------------------------
                // ���i�ăZ�b�g
                //-----------------------------------------------------------------------------
                double priceTaxExc;
                double priceTaxInc;
                this.CalcTaxExcAndTaxInc(row.TaxationDivCd, this._salesSlip.CustomerCode, this._salesSlipInputInitDataAcs.TaxRate, this._salesSlip.TotalAmountDispWayCd, goodsPriceTaxExc, out priceTaxExc, out priceTaxInc);
                row.SalesUnPrcTaxExcFl = priceTaxExc;
                row.SalesUnPrcTaxIncFl = priceTaxInc;
                //<<<2010/02/26

                //--------------------------------------------------
                // ���P��
                //--------------------------------------------------
                if (row.SalesUnPrcTaxExcFl != 0) goodsPriceTaxExc = row.SalesUnPrcTaxExcFl;
                if (row.SalesUnPrcTaxIncFl != 0) goodsPriceTaxInc = row.SalesUnPrcTaxIncFl;

                row.CanTaxDivChange = false;

                //--------------------------------------------------
                // ��ې�
                //--------------------------------------------------
                if (this._salesSlip.ConsTaxLayMethod == (int)ConsTaxLayMethod.TaxExempt)
                {
                    row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;
                    row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                    row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                }

                else if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.NoTotalAmount)
                {
                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            // �@��P�� = �Ŕ��P��
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // �A����P��(�Ŕ�) = �|���K�p��̎d���P��
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // �B����P��(�ō�) = ����P��(�Ŕ�) + (����P��(�Ŕ�) * �ŗ�)
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // �\���P�� = �Ŕ��P��
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;

                            // �ېŋ敪���O��
                            row.TaxationDivCd = 0;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            // �@��P�� = �Ŕ����i
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // �A����P��(�ō�) = �|���K�p��̎d���P��
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // �B����P��(�Ŕ�) = ����P��(�ō�) - (����P��(�ō�)* �ŗ�/�ŗ�+100)
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // �\���P�� = �ō��P��
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                            // �ېŋ敪������
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc;
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;

                            // �ېŋ敪����ې�
                            row.TaxationDivCd = 1;
                            break;
                    }
                }
                //--------------------------------------------------
                // ���z�\������
                //--------------------------------------------------
                else if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount)
                {
                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // ���P��
                            //--------------------------------------------------
                            // �@��P�� = �Ŕ��P��
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // �A����P��(�Ŕ�) = �|���K�p��̎d���P��
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // �B����P��(�ō�) = ����P��(�Ŕ�) + (����P��(�Ŕ�) * �ŗ�)
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // �\���P�� = �ō��P��
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                            // �ېŋ敪���O��
                            row.TaxationDivCd = 0; // �e�[�u���Z�b�g�l�͕ύX���Ȃ�
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // ���P��
                            //--------------------------------------------------
                            // �@��P�� = �Ŕ����i
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // �A����P��(�ō�) = �|���K�p��̎d���P��
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // �B����P��(�Ŕ�) = ����P��(�ō�) - (����P��(�ō�)* �ŗ�/�ŗ�+100)
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // �\���P�� = �ō��P��
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                            // �ېŋ敪������
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // ���P��
                            //--------------------------------------------------
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                            row.TaxationDivCd = 1;									// �ېŋ敪����ې�
                            break;
                    }
                }
            }
            #endregion

            #region ������
            if (row.TaxationDivCd == (int)CalculateTax.TaxationCode.TaxNone)
            {
                row.TaxDiv = 1;												// �ېŋ敪����ې�
            }
            else
            {
                row.TaxDiv = 0;												// �ېŋ敪���ې�
            }
            #endregion

            this._salesUnitPriceForCheck = row.SalesUnPrcDisplay;
            this._salesRateForCheck = row.SalesRate;
        }
        // ------ ADD 2011/09/05 --------- <<<<<<

        /// <summary>
        /// �P���Z�o���W���[���ɂ��A�P�����Z�o���܂��B
        /// </summary>
        /// <param name="row">���㖾�׍s�I�u�W�F�N�g</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <returns>�P���Z�o���ʃI�u�W�F�N�g</returns>
        private List<UnitPriceCalcRet> CalclationUnitPrice(SalesInputDataSet.SalesDetailRow row, GoodsUnitData goodsUnitData)
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

            //>>>2010/10/04
            //if ((row.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(row.GoodsNo)))
            if (row.GoodsMakerCd != 0)
            //<<<2010/10/04
            {
                unitPriceCalcParam.BLGoodsCode = row.RateBLGoodsCode;                   // BL�R�[�h
                unitPriceCalcParam.BLGoodsName = row.RateBLGoodsName;                   // BL�R�[�h����
                unitPriceCalcParam.BLGroupCode = row.RateBLGroupCode;                   // BL�O���[�v�R�[�h
                unitPriceCalcParam.CountFl = row.ShipmentCntDisplay;                    // ����
                // ADD 2013/02/20 T.Miyamoto ------------------------------>>>>>
                // �o�א�=0���󒍐�>0�̏ꍇ�͎󒍐��ŎZ�o
                if ((row.ShipmentCntDisplay == 0) && (row.AcceptAnOrderCntDisplay > 0))
                {
                    unitPriceCalcParam.CountFl = row.AcceptAnOrderCntDisplay;
                }
                // ADD 2013/02/20 T.Miyamoto ------------------------------<<<<<
                unitPriceCalcParam.CustomerCode = this._salesSlip.CustomerCode;         // ���Ӑ�R�[�h
                unitPriceCalcParam.CustRateGrpCode = row.CustRateGrpCode;               // ���Ӑ�|���O���[�v�R�[�h
                unitPriceCalcParam.GoodsMakerCd = row.GoodsMakerCd;                     // ���[�J�[�R�[�h
                unitPriceCalcParam.GoodsNo = row.GoodsNo;                               // �i��
                unitPriceCalcParam.GoodsRateGrpCode = row.RateGoodsRateGrpCd;           // ���i�|���O���[�v�R�[�h
                unitPriceCalcParam.GoodsRateRank = row.GoodsRateRank;                   // ���i�|�������N
                unitPriceCalcParam.PriceApplyDate = this._salesSlip.SalesDate; �@�@�@�@�@// �K�p��
                int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd); // �������Œ[�������R�[�h(���Ӑ�}�X�^���擾)
                unitPriceCalcParam.SalesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;         // �������Œ[�������R�[�h
                int salesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd); // ����P���[�������R�[�h(���Ӑ�}�X�^���擾)
                unitPriceCalcParam.SalesUnPrcFrcProcCd = salesUnPrcFrcProcCd;           // ����P���[�������R�[�h
                unitPriceCalcParam.SectionCode = this._salesSlip.ResultsAddUpSecCd;     // ���_�R�[�h
                int stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd); // �d������Œ[�������R�[�h(�d����}�X�^���擾)
                unitPriceCalcParam.StockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;         // �d������Œ[�������R�[�h
                int stockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd); // �d���P���[�������R�[�h(�d����}�X�^���擾)
                unitPriceCalcParam.StockUnPrcFrcProcCd = stockUnPrcFrcProcCd;           // �d���P���[�������R�[�h
                unitPriceCalcParam.SupplierCd = row.SupplierCd;                         // �d����R�[�h
                unitPriceCalcParam.TaxationDivCd = row.TaxationDivCd;                   // �ېŋ敪
                unitPriceCalcParam.TaxRate = this._salesSlip.ConsTaxRate;               // �ŗ�
                unitPriceCalcParam.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd; // ���z�\�����@�敪
                unitPriceCalcParam.TtlAmntDspRateDivCd = this._salesSlip.TtlAmntDispRateApy;    // ���z�\���|���K�p�敪 0:(�ō����z�~�|��) 1:(�Ŕ����z�~�|��)�������ł����ߍ��Z(����ŎZ�o������ł̒[������������)
                unitPriceCalcParam.ConsTaxLayMethod = this._salesSlip.ConsTaxLayMethod; // ����œ]�ŕ���
                this._unitPriceCalculation.CalculateSalesRelevanceUnitPrice(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);
            }
            return unitPriceCalcRetList;
        }

        // --- ADD m.suzuki 2011/02/16 ---------->>>>>
        /// <summary>
        /// �w�肵�����i���I�u�W�F�N�g�����ɒP���Z�o���i��菤�i���i���擾���A���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i���i����ݒ肵�܂��B�i�󒍏��j
        /// </summary>
        /// <param name="row">�󒍖��׍s�I�u�W�F�N�g</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="reCalcUnitInfoDiv">�|���Ď擾�敪(true:�Ď擾���� false:�Ď擾���Ȃ�)</param>
        private void SalesDetailRowGoodsPriceSetting(ref SalesInputDataSet.SalesDetailAcceptAnOrderRow row, GoodsUnitData goodsUnitData, bool reCalcUnitInfoDiv)
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList = this.CalclationUnitPriceForAcptAnOdr(row, goodsUnitData);
            this.SalesDetailRowGoodsPriceSetting(ref row, goodsUnitData, reCalcUnitInfoDiv, unitPriceCalcRetList);
        }
        // --- ADD m.suzuki 2011/02/16 ----------<<<<<

        /// <summary>
        /// �w�肵�����i���I�u�W�F�N�g�����ɒP���Z�o���i��菤�i���i���擾���A���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i���i����ݒ肵�܂��B�i�󒍏��j
        /// </summary>
        /// <param name="row">�󒍖��׍s�I�u�W�F�N�g</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <param name="reCalcUnitInfoDiv">�|���Ď擾�敪(true:�Ď擾���� false:�Ď擾���Ȃ�)</param>
        // --- UPD m.suzuki 2011/02/16 ---------->>>>>
        //private void SalesDetailRowGoodsPriceSetting(ref SalesInputDataSet.SalesDetailAcceptAnOrderRow row, GoodsUnitData goodsUnitData, bool reCalcUnitInfoDiv)
        private void SalesDetailRowGoodsPriceSetting(ref SalesInputDataSet.SalesDetailAcceptAnOrderRow row, GoodsUnitData goodsUnitData, bool reCalcUnitInfoDiv, List<UnitPriceCalcRet> unitPriceCalcRetList)
        // --- UPD m.suzuki 2011/02/16 ----------<<<<<
        {
            // --- DEL m.suzuki 2011/02/16 ---------->>>>> // ���X�g�͊O������󂯎��
            //List<UnitPriceCalcRet> unitPriceCalcRetList = this.CalclationUnitPriceForAcptAnOdr(row, goodsUnitData);
            // --- DEL m.suzuki 2011/02/16 ----------<<<<<

            bool salesUnitPriceFlg = false;
            bool salesUnitCostFlg = false;
            bool listPriceFlg = false;

            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                if (unitPriceCalcRet != null)
                {
                    #region �����P��
                    //--------------------------------------------
                    // ���P��
                    //--------------------------------------------
                    string unitPriceKind = unitPriceCalcRet.UnitPriceKind;

                    if (UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice == unitPriceKind)
                    {
                        double salesUnitPrice = 0;
                        salesUnitPriceFlg = true;
                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                        {
                            //--------------------------------------------
                            // ���i���i�ېŋ敪�u�O�Łv
                            //--------------------------------------------
                            case CalculateTax.TaxationCode.TaxExc:
                                salesUnitPrice = row.SalesUnPrcTaxExcFl;
                                break;
                            //--------------------------------------------
                            // ���i���i�ېŋ敪�u���Łv
                            //--------------------------------------------
                            case CalculateTax.TaxationCode.TaxInc:
                                salesUnitPrice = row.SalesUnPrcTaxIncFl;
                                break;
                            //--------------------------------------------
                            // ���i���i�ېŋ敪�u��ېŁv
                            //--------------------------------------------
                            case CalculateTax.TaxationCode.TaxNone:
                                salesUnitPrice = row.SalesUnPrcTaxExcFl;
                                break;
                        }

                        // ����������͂ŕύX���Ă���ꍇ�͊|���Ď擾�͍s��Ȃ�
                        //if (salesUnitPrice == row.BfSalesUnitPrice)
                        // �|���ݒ�敪�Ɗ���i���ݒ肳��Ă���ꍇ�́A�|���Ď擾
                        // --- UPD m.suzuki 2011/02/16 ---------->>>>>
                        //if ((reCalcUnitInfoDiv == true) ||
                        //    ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0))))
                        if ((reCalcUnitInfoDiv == true) ||
                            ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0) || (_noneResettingListPriceFlag))))
                        // --- UPD m.suzuki 2011/02/16 ----------<<<<<
                        {
                            row.RateSectSalUnPrc = unitPriceCalcRet.SectionCode;            // �|���ݒ苒�_
                            row.RateDivSalUnPrc = unitPriceCalcRet.RateSettingDivide;       // �|���ݒ�敪
                            row.UnPrcCalcCdSalUnPrc = unitPriceCalcRet.UnitPrcCalcDiv;      // �P���Z�o�敪
                            row.PriceCdSalUnPrc = unitPriceCalcRet.PriceDiv;                // ���i�敪
                            row.StdUnPrcSalUnPrc = unitPriceCalcRet.StdUnitPrice;           // ��P��
                            row.SalesUnPrcTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;    // ���P��(�Ŕ�)
                            row.SalesUnPrcTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;    // ���P��(�ō�)
                            row.SalesRate = 0; // --- ADD 2015/09/03 Y.Wakita �Г���Q��711 
                            switch ((UnitPriceCalculation.UnitPrcCalcDiv)unitPriceCalcRet.UnitPrcCalcDiv)
                            {
                                // ����i�~������
                                case UnitPriceCalculation.UnitPrcCalcDiv.RateVal:
                                    row.SalesRate = unitPriceCalcRet.RateVal;                       // ������
                                    break;
                                // ����UP��
                                case UnitPriceCalculation.UnitPrcCalcDiv.UpRate:
                                    row.CostUpRate = unitPriceCalcRet.RateVal;                      // ����UP��
                                    break;
                                // �e���m�ۗ�
                                case UnitPriceCalculation.UnitPrcCalcDiv.GrsProfitSecureRate:
                                    row.GrossProfitSecureRate = unitPriceCalcRet.RateVal;           // �e���m�ۗ�
                                    break;
                                // �P�����ڎw��
                                case UnitPriceCalculation.UnitPrcCalcDiv.Price:
                                    row.SalesRate = 0;
                                    break;
                            }
                            row.FracProcUnitSalUnPrc = unitPriceCalcRet.UnPrcFracProcUnit;  // �[�������P��
                            row.FracProcSalUnPrc = unitPriceCalcRet.UnPrcFracProcDiv;       // �[�������敪
                            row.BfSalesUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;      // �ύX�O����
                            //row.RateBLGoodsCode = row.BLGoodsCode;                          // BL���i�R�[�h(�|��)
                            //row.RateBLGoodsName = row.BLGoodsFullName;                      // BL���i�R�[�h����(�|��)
                            //row.RateGoodsRateGrpCd = row.GoodsMGroup;                       // ���i�|���O���[�v�R�[�h�i�|���j
                            //row.RateGoodsRateGrpNm = row.GoodsMGroupName;                   // ���i�|���O���[�v���́i�|���j
                            //row.RateBLGroupCode = row.BLGroupCode;                          // BL�O���[�v�R�[�h�i�|���j
                            //row.RateBLGroupName = row.BLGroupName;                          // BL�O���[�v���́i�|���j

                            if (unitPriceCalcRet.RateSettingDivide == string.Empty) salesUnitPriceFlg = false;

                            //--------------------------------------------
                            // ���z�\�����Ȃ�
                            //--------------------------------------------
                            if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    //--------------------------------------------
                                    // ���i���i�ېŋ敪�u�O�Łv
                                    //--------------------------------------------
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                                        break;
                                    //--------------------------------------------
                                    // ���i���i�ېŋ敪�u���Łv
                                    //--------------------------------------------
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                                        break;
                                    //--------------------------------------------
                                    // ���i���i�ېŋ敪�u��ېŁv
                                    //--------------------------------------------
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;
                                        break;
                                }
                            }
                            //--------------------------------------------
                            // ���z�\������
                            //--------------------------------------------
                            else
                            {
                                row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                            }
                        }
                    }
                    #endregion

                    #region �����P��
                    //--------------------------------------------
                    // ���P��
                    //--------------------------------------------
                    else if (UnitPriceCalculation.ctUnitPriceKind_UnitCost == unitPriceKind)
                    {
                        double salesUnitCost = 0;
                        salesUnitCostFlg = true;
                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                        {
                            case CalculateTax.TaxationCode.TaxExc:
                                salesUnitCost = row.SalesUnitCostTaxExc;
                                break;
                            case CalculateTax.TaxationCode.TaxInc:
                                salesUnitCost = row.SalesUnitCostTaxInc;
                                break;
                            case CalculateTax.TaxationCode.TaxNone:
                                salesUnitCost = row.SalesUnitCostTaxExc;
                                break;
                        }

                        //if (salesUnitCost == row.BfUnitCost)
                        // �|���ݒ�敪�Ɗ���i���ݒ肳��Ă���ꍇ�́A�|���Ď擾
                        if ((reCalcUnitInfoDiv == true) ||
                            ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivUnCst.Trim())) || (row.StdUnPrcUnCst != 0))))
                        {
                            row.RateSectCstUnPrc = unitPriceCalcRet.SectionCode;            // �|���ݒ苒�_
                            row.RateDivUnCst = unitPriceCalcRet.RateSettingDivide;          // �|���ݒ�敪
                            row.UnPrcCalcCdUnCst = unitPriceCalcRet.UnitPrcCalcDiv;         // �P���Z�o�敪
                            row.PriceCdUnCst = unitPriceCalcRet.PriceDiv;                   // ���i�敪
                            row.StdUnPrcUnCst = unitPriceCalcRet.StdUnitPrice;              // ��P��
                            row.SalesUnitCostTaxExc = unitPriceCalcRet.UnitPriceTaxExcFl;   // ���P��(�Ŕ�)
                            row.SalesUnitCostTaxInc = unitPriceCalcRet.UnitPriceTaxIncFl;   // ���P��(�ō�)
                            row.CostRate = unitPriceCalcRet.RateVal;                        // ������
                            row.FracProcUnitUnCst = unitPriceCalcRet.UnPrcFracProcUnit;     // �[�������P��
                            row.FracProcUnCst = unitPriceCalcRet.UnPrcFracProcDiv;          // �[�������敪
                            row.BfUnitCost = unitPriceCalcRet.UnitPriceTaxExcFl;            // �ύX�O����
                            //row.RateBLGoodsCode = row.BLGoodsCode;                          // BL���i�R�[�h(�|��)
                            //row.RateBLGoodsName = row.BLGoodsFullName;                      // BL���i�R�[�h����(�|��)
                            //row.RateGoodsRateGrpCd = row.GoodsMGroup;                       // ���i�|���O���[�v�R�[�h�i�|���j
                            //row.RateGoodsRateGrpNm = row.GoodsMGroupName;                   // ���i�|���O���[�v���́i�|���j
                            //row.RateBLGroupCode = row.BLGroupCode;                          // BL�O���[�v�R�[�h�i�|���j
                            //row.RateBLGroupName = row.BLGroupName;                          // BL�O���[�v���́i�|���j
                            if (unitPriceCalcRet.RateSettingDivide == string.Empty) salesUnitCostFlg = false;

                            //--------------------------------------------
                            // ���z�\�����Ȃ�
                            //--------------------------------------------
                            if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxInc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                }
                            }
                            //--------------------------------------------
                            // ���z�\������
                            //--------------------------------------------
                            else
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.SalesUnitCost = row.SalesUnitCostTaxInc;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.SalesUnitCost = row.SalesUnitCostTaxExc;
                                        break;
                                }
                            }
                        }
                    }
                    #endregion

                    #region ���艿
                    //--------------------------------------------
                    // �艿
                    //--------------------------------------------
                    else if (UnitPriceCalculation.ctUnitPriceKind_ListPrice == unitPriceKind)
                    {
                        double listPrice = 0;
                        listPriceFlg = true;
                        switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                        {
                            case CalculateTax.TaxationCode.TaxExc:
                                listPrice = row.ListPriceTaxExcFl;
                                break;
                            case CalculateTax.TaxationCode.TaxInc:
                                listPrice = row.ListPriceTaxIncFl;
                                break;
                            case CalculateTax.TaxationCode.TaxNone:
                                listPrice = row.ListPriceTaxExcFl;
                                break;
                        }

                        // �|���ݒ�敪�Ɗ���i���ݒ肳��Ă���ꍇ�́A�|���Ď擾
                        if ((reCalcUnitInfoDiv == true) ||
                            ((reCalcUnitInfoDiv == false) && ((!string.IsNullOrEmpty(row.RateDivLPrice.Trim())) || (row.StdUnPrcLPrice != 0))))
                        {
                            row.RateSectPriceUnPrc = unitPriceCalcRet.SectionCode;          // �|���ݒ苒�_
                            row.RateDivLPrice = unitPriceCalcRet.RateSettingDivide;         // �|���ݒ�敪
                            row.UnPrcCalcCdLPrice = unitPriceCalcRet.UnitPrcCalcDiv;        // �P���Z�o�敪
                            row.PriceCdLPrice = unitPriceCalcRet.PriceDiv;                  // ���i�敪
                            row.StdUnPrcLPrice = unitPriceCalcRet.StdUnitPrice;             // ��P��
                            row.ListPriceTaxExcFl = unitPriceCalcRet.UnitPriceTaxExcFl;     // �艿(�Ŕ�)
                            row.ListPriceTaxIncFl = unitPriceCalcRet.UnitPriceTaxIncFl;     // �艿(�ō�)
                            row.ListPriceRate = unitPriceCalcRet.RateVal;                   // �艿��
                            row.FracProcUnitLPrice = unitPriceCalcRet.UnPrcFracProcUnit;    // �[�������P��
                            row.FracProcLPrice = unitPriceCalcRet.UnPrcFracProcDiv;         // �[�������敪
                            row.BfListPrice = unitPriceCalcRet.UnitPriceTaxExcFl;           // �ύX�O�艿
                            //row.RateBLGoodsCode = row.BLGoodsCode;                          // BL���i�R�[�h(�|��)
                            //row.RateBLGoodsName = row.BLGoodsFullName;                      // BL���i�R�[�h����(�|��)
                            //row.RateGoodsRateGrpCd = row.GoodsMGroup;                       // ���i�|���O���[�v�R�[�h�i�|���j
                            //row.RateGoodsRateGrpNm = row.GoodsMGroupName;                   // ���i�|���O���[�v���́i�|���j
                            //row.RateBLGroupCode = row.BLGroupCode;                          // BL�O���[�v�R�[�h�i�|���j
                            //row.RateBLGroupName = row.BLGroupName;                          // BL�O���[�v���́i�|���j
                            if (unitPriceCalcRet.RateSettingDivide == string.Empty) listPriceFlg = false;

                            //--------------------------------------------
                            // ���z�\�����Ȃ�
                            //--------------------------------------------
                            if (this._salesSlip.TotalAmountDispWayCd == 0)
                            {
                                switch ((CalculateTax.TaxationCode)row.TaxationDivCd)
                                {
                                    case CalculateTax.TaxationCode.TaxExc:
                                        row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                        break;
                                    case CalculateTax.TaxationCode.TaxInc:
                                        row.ListPriceDisplay = row.ListPriceTaxIncFl;
                                        break;
                                    case CalculateTax.TaxationCode.TaxNone:
                                        row.ListPriceDisplay = row.ListPriceTaxExcFl;
                                        break;
                                }
                            }
                            //--------------------------------------------
                            // ���z�\������
                            //--------------------------------------------
                            else
                            {
                                row.ListPriceDisplay = row.ListPriceTaxIncFl;
                            }
                        }
                    }
                    #endregion
                }
            }

            #region �ύX�O���P���ݒ�
            if (salesUnitPriceFlg == false)
            {
                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                {
                    // �[���\��
                    case 0:
                        row.BfSalesUnitPrice = 0;
                        break;
                    // �艿�\��
                    case 1:
                        row.BfSalesUnitPrice = row.ListPriceTaxExcFl;
                        break;
                    default:
                        row.BfSalesUnitPrice = 0;
                        break;
                }
            }
            #endregion

            #region ������
            if (salesUnitPriceFlg == false)
            {
                // ���P��
                row.RateSectSalUnPrc = string.Empty;    // �|���ݒ苒�_
                row.RateDivSalUnPrc = string.Empty;      // �|���ݒ�敪
                row.UnPrcCalcCdSalUnPrc = 0;   // �P���Z�o�敪
                row.PriceCdSalUnPrc = 0;       // ���i�敪
                row.StdUnPrcSalUnPrc = 0;      // ��P��
                row.FracProcUnitSalUnPrc = 0;  // �[�������P��
                row.FracProcSalUnPrc = 0;      // �[�������敪
            }
            // --- UPD m.suzuki 2011/02/16 ---------->>>>>
            //if (salesUnitCostFlg == false)
            if (salesUnitCostFlg == false && !_noneResettingUnitCostFlag)
            // --- UPD m.suzuki 2011/02/16 ----------<<<<<
            {
                // ���P��
                row.RateSectCstUnPrc = string.Empty;    // �|���ݒ苒�_
                row.RateDivUnCst = string.Empty;         // �|���ݒ�敪
                row.UnPrcCalcCdUnCst = 0;      // �P���Z�o�敪
                row.PriceCdUnCst = 0;          // ���i�敪
                row.StdUnPrcUnCst = 0;         // ��P��
                row.FracProcUnitUnCst = 0;     // �[�������P��
                row.FracProcUnCst = 0;         // �[�������敪
            }
            // --- UPD m.suzuki 2011/02/16 ---------->>>>>
            //if (listPriceFlg == false)
            if (listPriceFlg == false && !_noneResettingListPriceFlag)
            // --- UPD m.suzuki 2011/02/16 ----------<<<<<
            {
                // �艿
                row.RateSectPriceUnPrc = string.Empty;  // �|���ݒ苒�_
                row.RateDivLPrice = string.Empty;        // �|���ݒ�敪
                row.UnPrcCalcCdLPrice = 0;     // �P���Z�o�敪
                row.PriceCdLPrice = 0;         // ���i�敪
                row.StdUnPrcLPrice = 0;        // ��P��
                row.FracProcUnitLPrice = 0;    // �[�������P��
                row.FracProcLPrice = 0;        // �[�������敪
            }
            if ((salesUnitPriceFlg == false) &&
                (salesUnitCostFlg == false) &&
                (listPriceFlg == false))
            {
                //row.RateBLGoodsCode = 0;                          // BL���i�R�[�h(�|��)
                //row.RateBLGoodsName = string.Empty;               // BL���i�R�[�h����(�|��)
                //row.RateGoodsRateGrpCd = 0;                       // ���i�|���O���[�v�R�[�h�i�|���j
                //row.RateGoodsRateGrpNm = string.Empty;            // ���i�|���O���[�v���́i�|���j
                //row.RateBLGroupCode = 0;                          // BL�O���[�v�R�[�h�i�|���j
                //row.RateBLGroupName = string.Empty;               // BL�O���[�v���́i�|���j
            }
            #endregion

            this.SalesDetailRowUnitPriceSetting(ref row, goodsUnitData);
        }

        /// <summary>
        /// �w�肵�����i���I�u�W�F�N�g�����ɒP���Z�o���i��菤�i���i���擾���A���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i���i����ݒ肵�܂��B�i�󒍏��j
        /// </summary>
        /// <param name="row">�󒍖��׍s�I�u�W�F�N�g</param>
        private void SalesDetailRowGoodsPriceSetting(ref SalesInputDataSet.SalesDetailAcceptAnOrderRow row)
        {
            //>>>2010/10/01
            //GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo);
            SalesInputDataSet.SalesDetailRow salesDetailRow = this._salesDetailDataTable.NewSalesDetailRow();
            this.CopySalesDetailFromAcceptAnOrder(row, salesDetailRow); // �󒍁�����
            GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo, salesDetailRow);
            //<<<2010/10/01
            this.SalesDetailRowGoodsPriceSetting(ref row, goodsUnitData, false);
        }

        /// <summary>
        /// �w�肵�����i���I�u�W�F�N�g�����ɏ��i���i���擾���A���㖾�׃f�[�^�s�I�u�W�F�N�g�ɏ��i���i����ݒ肵�܂��B�i�󒍏��j
        /// </summary>
        /// <param name="row">�󒍖��׍s�I�u�W�F�N�g</param>
        /// <param name="goodsUnitData">���i���I�u�W�F�N�g</param>
        private void SalesDetailRowUnitPriceSetting(ref SalesInputDataSet.SalesDetailAcceptAnOrderRow row, GoodsUnitData goodsUnitData)
        {
            #region ����������
            // ����Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // ����Œ[�������P�ʁA�敪�擾
            int taxFracProcCd = 0;
            double taxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesCnsTaxFrcProcCd, 0, out taxFracProcUnit, out taxFracProcCd);
            this._salesSlip.FractionProcCd = taxFracProcCd;

            // ��������Œ[�������R�[�h(�d����}�X�^���擾)
            int stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
            // ��������Œ[�������P�ʁA�敪�擾
            int stockTaxFracProcCd = 0;
            double stockTaxFracProcUnit = 0;
            this._salesSlipInputInitDataAcs.GetSalesFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockCnsTaxFrcProcCd, 0, out stockTaxFracProcUnit, out stockTaxFracProcCd);

            int taxationCode;
            List<GoodsPrice> goodsPriceList = new List<GoodsPrice>();

            if (goodsUnitData != null)
            {
                taxationCode = goodsUnitData.TaxationDivCd;
                goodsPriceList = goodsUnitData.GoodsPriceList;
            }
            else
            {
                taxationCode = row.TaxationDivCd;
            }
            #endregion

            #region ���艿
            //--------------------------------------------
            // �艿
            //--------------------------------------------
            double listPrice = 0;
            // �|���Z�o�����ꍇ�A�|���ݒ�敪�Ɗ���i���ݒ肳��Ă���ꍇ�͊�P�����艿�ƂȂ�
            if ((!string.IsNullOrEmpty(row.RateDivLPrice.Trim())) || (row.StdUnPrcLPrice != 0))
            {
                listPrice = row.StdUnPrcLPrice;	// �|���Z�o�����ꍇ�͊���i���艿
            }
            // �|���Z�o�ł��Ă��Ȃ��ꍇ�́A�艿��\������
            //else if ((goodsPriceList != null) && (row.ListPriceRate == 0))
            // --- UPD m.suzuki 2011/02/16 ---------->>>>>
            //else
            else if (!_noneResettingListPriceFlag)
            // --- UPD m.suzuki 2011/02/16 ----------<<<<<
            {
                DateTime targetDate = new DateTime();

                switch ((SalesSlipInputAcs.AcptAnOdrStatusState)this._salesSlip.AcptAnOdrStatusDisplay)
                {
                    case AcptAnOdrStatusState.Estimate:
                        targetDate = this._salesSlip.SalesDate; // �����
                        break;
                    case AcptAnOdrStatusState.UnitPriceEstimate:
                        targetDate = this._salesSlip.SalesDate; // �����
                        break;
                    case AcptAnOdrStatusState.Sales:
                        targetDate = this._salesSlip.SalesDate; // �����
                        break;
                    case AcptAnOdrStatusState.Shipment:
                        targetDate = this._salesSlip.ShipmentDay; // �o�ד�
                        break;
                }

                //-----------------------------------------------------------------------
                // ���i��񂪑��݂���ꍇ�́A���i��񂩂��艿�m��
                //-----------------------------------------------------------------------
                if (goodsPriceList != null)
                {
                    object obj = this._salesSlipInputInitDataAcs.GetGoodsPrice(targetDate, goodsPriceList);
                    if ((obj != null) && (obj is GoodsPrice))
                    {
                        GoodsPrice goodsPrice = (GoodsPrice)obj;
                        //row.NewListPrice = goodsPrice.NewPrice;
                        //row.NewListPriceStartDate = goodsPrice.NewPriceStartDate;
                        //row.OldListPrice = goodsPrice.OldPrice;
                        //row.ListPriceOpenDiv = goodsPrice.OpenPriceDiv;
                        row.OpenPriceDiv = goodsPrice.OpenPriceDiv;

                        //listPrice = this.GetPrice(targetDate, row.NewListPrice, row.OldListPrice, row.NewListPriceStartDate, goodsPrice.OpenPriceDiv);
                        listPrice = goodsPrice.ListPrice;
                    }
                }
                //-----------------------------------------------------------------------
                // ���i��񂪑��݂��Ȃ��ꍇ�́A�e�[�u�����̉��i��񂩂��艿�m��
                //-----------------------------------------------------------------------
                else
                {
                    //listPrice = this.GetPrice(targetDate, row.NewListPrice, row.OldListPrice, row.NewListPriceStartDate, row.ListPriceOpenDiv);
                    // ����
                    listPrice = row.ListPriceDisplay;
                }

                //--------------------------------------------------
                // �艿
                //--------------------------------------------------
                double listPriceTaxExc;
                double listPriceTaxInc;
                if (row.ListPriceTaxExcFl != 0)
                {
                    listPriceTaxExc = row.ListPriceTaxExcFl;
                }
                else
                {
                    listPriceTaxExc = listPrice;
                }
                if (row.ListPriceTaxIncFl != 0)
                {
                    listPriceTaxInc = row.ListPriceTaxIncFl;
                }
                else
                {
                    listPriceTaxInc = listPrice;
                }

                row.CanTaxDivChange = false;

                //--------------------------------------------------
                // ���z�\�����Ȃ�
                //--------------------------------------------------
                if (this._salesSlip.TotalAmountDispWayCd == 0)
                {

                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // �艿
                            //--------------------------------------------------
                            // �@��艿 = �艿(�Ŕ�)
                            //row.StdUnPrcLPrice = listPriceTaxExc;

                            // �A�艿(�Ŕ�) = �|���K�p��̒艿
                            row.ListPriceTaxExcFl = listPriceTaxExc;

                            // �B�艿(�ō�) = �艿(�Ŕ�) + (�艿(�Ŕ�) * �ŗ�)
                            row.ListPriceTaxIncFl = listPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxExc);

                            // �艿(�\��) = �艿(�Ŕ�)
                            row.ListPriceDisplay = row.ListPriceTaxExcFl;


                            // �ېŋ敪���O��
                            row.TaxationDivCd = 0;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // �艿
                            //--------------------------------------------------
                            // �@��艿 = �艿(�Ŕ�)
                            //row.StdUnPrcLPrice = listPriceTaxExc;

                            // �A�艿(�ō�) = �|���K�p��̒艿
                            row.ListPriceTaxIncFl = listPriceTaxInc;

                            // �B�艿(�Ŕ�) = �艿(�ō�) - (�艿(�ō�)* �ŗ�/�ŗ�+100)
                            row.ListPriceTaxExcFl = listPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxInc);

                            // �艿(�\��) = �艿(�ō�)
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;

                            // �ېŋ敪������
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // �艿
                            //--------------------------------------------------
                            //row.StdUnPrcLPrice = listPriceTaxExc;
                            row.ListPriceTaxIncFl = listPriceTaxExc;
                            row.ListPriceTaxExcFl = listPriceTaxExc;
                            row.ListPriceDisplay = row.ListPriceTaxExcFl;

                            // �ېŋ敪����ې�
                            row.TaxationDivCd = 1;
                            break;
                    }
                }
                //--------------------------------------------------
                // ���z�\������
                //--------------------------------------------------
                else if (this._salesSlip.TotalAmountDispWayCd == 1)
                {

                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // �艿
                            //--------------------------------------------------
                            // �@��艿 = �艿(�Ŕ�)
                            //row.StdUnPrcLPrice = listPriceTaxExc;

                            // �A�艿(�Ŕ�) = �|���K�p��̒艿
                            row.ListPriceTaxExcFl = listPriceTaxExc;

                            // �B�艿(�ō�) = �艿(�Ŕ�) + (�艿(�Ŕ�) * �ŗ�)
                            row.ListPriceTaxIncFl = listPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxExc);

                            // �艿(�\��) = �艿(�ō�)
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;

                            // �ېŋ敪���O��
                            row.TaxationDivCd = 0; // �e�[�u���Z�b�g�l�͕ύX���Ȃ�
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // �艿
                            //--------------------------------------------------
                            // �@��艿 = �艿(�Ŕ�)
                            //row.StdUnPrcLPrice = listPriceTaxExc;

                            // �A�艿(�ō�) = �|���K�p��̒艿
                            row.ListPriceTaxIncFl = listPriceTaxInc;

                            // �B�艿(�Ŕ�) = �艿(�ō�) - (�艿(�ō�)* �ŗ�/�ŗ�+100)
                            row.ListPriceTaxExcFl = listPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, listPriceTaxInc);

                            // �艿(�\��) = �艿(�Ŕ�)
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;


                            // �ېŋ敪������
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // �艿
                            //--------------------------------------------------
                            //row.StdUnPrcLPrice = listPriceTaxExc;
                            row.ListPriceTaxExcFl = listPriceTaxExc;
                            row.ListPriceTaxIncFl = listPriceTaxExc;
                            row.ListPriceDisplay = row.ListPriceTaxIncFl;
                            row.TaxationDivCd = 1;									// �ېŋ敪����ې�
                            break;
                    }
                }
            }
            #endregion

            #region �����P��
            //--------------------------------------------
            // ���P��
            //--------------------------------------------
            double unitCost = 0;
            // �|���Z�o�����ꍇ�A�|���ݒ�敪�Ɗ���i���ݒ肳��Ă���ꍇ�͊�P���������ƂȂ�
            if ((!string.IsNullOrEmpty(row.RateDivUnCst.Trim())) || (row.StdUnPrcUnCst != 0))
            {
                unitCost = row.StdUnPrcUnCst;	// �|���Z�o�����ꍇ�͊���i������
            }
            // �|���Z�o�ł��Ă��Ȃ��ꍇ�́A�[����\������
            //else if ((goodsPriceList != null) && (row.CostRate == 0))
            else
            {
                //unitCost = listPrice;
                unitCost = 0;

                //--------------------------------------------------
                // ���P��
                //--------------------------------------------------
                double unitCostTaxExc;
                double unitCostTaxInc;
                if (row.SalesUnitCostTaxExc != 0)
                {
                    unitCostTaxExc = row.SalesUnitCostTaxExc;
                }
                else
                {
                    unitCostTaxExc = unitCost;
                }
                if (row.SalesUnitCostTaxInc != 0)
                {
                    unitCostTaxInc = row.SalesUnitCostTaxInc;
                }
                else
                {
                    unitCostTaxInc = unitCost;
                }

                row.CanTaxDivChange = false;

                switch ((CalculateTax.TaxationCode)taxationCode)
                {
                    case CalculateTax.TaxationCode.TaxExc:
                        //--------------------------------------------------
                        // ���P��
                        //--------------------------------------------------
                        // �@����� = ����(�Ŕ�)
                        //row.StdUnPrcUnCst = unitCostTaxExc;

                        // �A����(�Ŕ�) = �|���K�p��̌���
                        row.SalesUnitCostTaxExc = unitCostTaxExc;

                        // �B����(�ō�) = ����(�Ŕ�) + (����(�Ŕ�) * �ŗ�)
                        row.SalesUnitCostTaxInc = unitCostTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, stockTaxFracProcUnit, stockTaxFracProcCd, unitCostTaxExc);

                        // ����(�\��) = ����(�Ŕ�)
                        row.SalesUnitCost = row.SalesUnitCostTaxExc;

                        // �ېŋ敪���O��
                        row.TaxationDivCd = 0;
                        break;
                    case CalculateTax.TaxationCode.TaxInc:
                        //--------------------------------------------------
                        // ���P��
                        //--------------------------------------------------
                        // �@����� = ����(�Ŕ�)
                        //row.StdUnPrcUnCst = unitCostTaxExc;

                        // �A����(�ō�) = �|���K�p��̌���
                        row.SalesUnitCostTaxInc = unitCostTaxInc;

                        // �B����(�Ŕ�) = ����(�ō�) - (����(�ō�)* �ŗ�/�ŗ�+100)
                        row.SalesUnitCostTaxExc = unitCostTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, stockTaxFracProcUnit, stockTaxFracProcCd, unitCostTaxInc);

                        // ����(�\��) = ����(�ō�)
                        row.SalesUnitCost = row.SalesUnitCostTaxInc;

                        // �ېŋ敪������
                        row.TaxationDivCd = 2;
                        break;
                    case CalculateTax.TaxationCode.TaxNone:
                        //--------------------------------------------------
                        // ���P��
                        //--------------------------------------------------
                        //row.StdUnPrcUnCst = unitCostTaxExc;
                        row.SalesUnitCostTaxInc = unitCostTaxExc;
                        row.SalesUnitCostTaxExc = unitCostTaxExc;
                        row.SalesUnitCost = row.SalesUnitCostTaxExc;

                        // �ېŋ敪����ې�
                        row.TaxationDivCd = 1;
                        break;
                }
            }
            #endregion

            #region �����P��
            //--------------------------------------------
            // ���P��
            //--------------------------------------------
            double unitPrice = 0;
            // �|���Z�o�����ꍇ�A�|���ݒ�敪�Ɗ���i���ݒ肳��Ă���ꍇ�͊�P�������P���ƂȂ�
            if ((!string.IsNullOrEmpty(row.RateDivSalUnPrc.Trim())) || (row.StdUnPrcSalUnPrc != 0))
            {
                unitPrice = row.StdUnPrcSalUnPrc;	// �|���Z�o�����ꍇ�͊���i�����P��
            }
            // �|���Z�o�ł��Ă��Ȃ��ꍇ(������z����͈ȊO)
            else if (row.SalesMoneyInputDiv != (int)SalesMoneyInputDiv.Input)
            {
                switch (this._salesSlipInputInitDataAcs.GetSalesTtlSt().UnPrcNonSettingDiv)
                {
                    // �[���\��
                    case 0:
                        unitPrice = 0;
                        break;
                    // �艿�\��
                    case 1:
                        unitPrice = listPrice;
                        break;
                    default:
                        unitPrice = 0;
                        break;
                }

                //--------------------------------------------------
                // ���P��
                //--------------------------------------------------
                double goodsPriceTaxExc;
                double goodsPriceTaxInc;
                if (row.SalesUnPrcTaxExcFl != 0)
                {
                    goodsPriceTaxExc = row.SalesUnPrcTaxExcFl;
                }
                else
                {
                    goodsPriceTaxExc = unitPrice;
                }
                if (row.SalesUnPrcTaxIncFl != 0)
                {
                    goodsPriceTaxInc = row.SalesUnPrcTaxIncFl;
                }
                else
                {
                    goodsPriceTaxInc = unitPrice;
                }

                row.CanTaxDivChange = false;

                //--------------------------------------------------
                // ���z�\�����Ȃ�
                //--------------------------------------------------
                if (this._salesSlip.TotalAmountDispWayCd == 0)
                {
                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // ���P��
                            //--------------------------------------------------
                            // �@��P�� = �Ŕ��P��
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // �A����P��(�Ŕ�) = �|���K�p��̎d���P��
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // �B����P��(�ō�) = ����P��(�Ŕ�) + (����P��(�Ŕ�) * �ŗ�)
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, goodsPriceTaxExc);

                            // �\���P�� = �Ŕ��P��
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;

                            // �ېŋ敪���O��
                            row.TaxationDivCd = 0;
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // ���P��
                            //--------------------------------------------------
                            // �@��P�� = �Ŕ����i
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // �A����P��(�ō�) = �|���K�p��̎d���P��
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // �B����P��(�Ŕ�) = ����P��(�ō�) - (����P��(�ō�)* �ŗ�/�ŗ�+100)
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, goodsPriceTaxInc);

                            // �\���P�� = �ō��P��
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                            // �ېŋ敪������
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // ���P��
                            //--------------------------------------------------
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc;
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxExcFl;

                            // �ېŋ敪����ې�
                            row.TaxationDivCd = 1;
                            break;
                    }
                }
                //--------------------------------------------------
                // ���z�\������
                //--------------------------------------------------
                else if (this._salesSlip.TotalAmountDispWayCd == 1)
                {
                    switch ((CalculateTax.TaxationCode)taxationCode)
                    {
                        case CalculateTax.TaxationCode.TaxExc:
                            //--------------------------------------------------
                            // ���P��
                            //--------------------------------------------------
                            // �@��P�� = �Ŕ��P��
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // �A����P��(�Ŕ�) = �|���K�p��̎d���P��
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;

                            // �B����P��(�ō�) = ����P��(�Ŕ�) + (����P��(�Ŕ�) * �ŗ�)
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc + CalculateTax.GetTaxFromPriceExc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, goodsPriceTaxExc);

                            // �\���P�� = �ō��P��
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                            // �ېŋ敪���O��
                            row.TaxationDivCd = 0; // �e�[�u���Z�b�g�l�͕ύX���Ȃ�
                            break;
                        case CalculateTax.TaxationCode.TaxInc:
                            //--------------------------------------------------
                            // ���P��
                            //--------------------------------------------------
                            // �@��P�� = �Ŕ����i
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;

                            // �A����P��(�ō�) = �|���K�p��̎d���P��
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxInc;

                            // �B����P��(�Ŕ�) = ����P��(�ō�) - (����P��(�ō�)* �ŗ�/�ŗ�+100)
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxInc - CalculateTax.GetTaxFromPriceInc(this._salesSlip.ConsTaxRate, taxFracProcUnit, taxFracProcCd, goodsPriceTaxInc);

                            // �\���P�� = �ō��P��
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;

                            // �ېŋ敪������
                            row.TaxationDivCd = 2;
                            break;
                        case CalculateTax.TaxationCode.TaxNone:
                            //--------------------------------------------------
                            // ���P��
                            //--------------------------------------------------
                            //row.StdUnPrcSalUnPrc = goodsPriceTaxExc;
                            row.SalesUnPrcTaxExcFl = goodsPriceTaxExc;
                            row.SalesUnPrcTaxIncFl = goodsPriceTaxExc;
                            row.SalesUnPrcDisplay = row.SalesUnPrcTaxIncFl;
                            row.TaxationDivCd = 1;									// �ېŋ敪����ې�
                            break;
                    }
                }
            }
            #endregion

            #region ������
            if (row.TaxationDivCd == 1)
            {
                row.TaxDiv = 1;												// �ېŋ敪����ې�
            }
            else
            {
                row.TaxDiv = 0;												// �ېŋ敪���ې�
            }
            #endregion
        }

        /// <summary>
        /// �P���Z�o���W���[���ɂ��A�P�����Z�o���܂��B�i�󒍏��j
        /// </summary>
        /// <param name="row">�󒍖��׍s�I�u�W�F�N�g</param>
        /// <param name="goodsUnitData">���i�A���f�[�^�I�u�W�F�N�g</param>
        /// <returns>�P���Z�o���ʃI�u�W�F�N�g</returns>
        private List<UnitPriceCalcRet> CalclationUnitPriceForAcptAnOdr(SalesInputDataSet.SalesDetailAcceptAnOrderRow row, GoodsUnitData goodsUnitData)
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

            if ((row.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(row.GoodsNo)))
            {
                unitPriceCalcParam.BLGoodsCode = row.RateBLGoodsCode;                   // BL�R�[�h
                unitPriceCalcParam.BLGoodsName = row.RateBLGoodsName;                   // BL�R�[�h����
                unitPriceCalcParam.BLGroupCode = row.RateBLGroupCode;                   // BL�O���[�v�R�[�h
                unitPriceCalcParam.CountFl = row.AcceptAnOrderCntDisplay;               // ����
                unitPriceCalcParam.CustomerCode = this._salesSlip.CustomerCode;         // ���Ӑ�R�[�h
                unitPriceCalcParam.CustRateGrpCode = row.CustRateGrpCode;               // ���Ӑ�|���O���[�v�R�[�h
                unitPriceCalcParam.GoodsMakerCd = row.GoodsMakerCd;                     // ���[�J�[�R�[�h
                unitPriceCalcParam.GoodsNo = row.GoodsNo;                               // �i��
                unitPriceCalcParam.GoodsRateGrpCode = row.RateGoodsRateGrpCd;           // ���i�|���O���[�v�R�[�h
                unitPriceCalcParam.GoodsRateRank = row.GoodsRateRank;                   // ���i�|�������N
                unitPriceCalcParam.PriceApplyDate = this._salesSlip.SalesDate;          // �K�p��
                int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd); // �������Œ[�������R�[�h(���Ӑ�}�X�^���擾)
                unitPriceCalcParam.SalesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;         // �������Œ[�������R�[�h
                int salesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd); // ����P���[�������R�[�h(���Ӑ�}�X�^���擾)
                unitPriceCalcParam.SalesUnPrcFrcProcCd = salesUnPrcFrcProcCd;           // ����P���[�������R�[�h
                unitPriceCalcParam.SectionCode = this._salesSlip.ResultsAddUpSecCd;     // ���_�R�[�h
                int stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd); // �d������Œ[�������R�[�h(�d����}�X�^���擾)
                unitPriceCalcParam.StockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;         // �d������Œ[�������R�[�h
                int stockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, row.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd); // �d���P���[�������R�[�h(�d����}�X�^���擾)
                unitPriceCalcParam.StockUnPrcFrcProcCd = stockUnPrcFrcProcCd;           // �d���P���[�������R�[�h
                unitPriceCalcParam.SupplierCd = row.SupplierCd;                         // �d����R�[�h
                unitPriceCalcParam.TaxationDivCd = row.TaxationDivCd;                   // �ېŋ敪
                unitPriceCalcParam.TaxRate = this._salesSlip.ConsTaxRate;               // �ŗ�
                unitPriceCalcParam.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd; // ���z�\�����@�敪
                unitPriceCalcParam.TtlAmntDspRateDivCd = this._salesSlip.TtlAmntDispRateApy;    // ���z�\���|���K�p�敪 0:(�ō����z�~�|��) 1:(�Ŕ����z�~�|��)�������ł����ߍ��Z(����ŎZ�o������ł̒[������������)
                unitPriceCalcParam.ConsTaxLayMethod = this._salesSlip.ConsTaxLayMethod; // ����œ]�ŕ���

                this._unitPriceCalculation.CalculateSalesRelevanceUnitPrice(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);
            }
            return unitPriceCalcRetList;
        }

        /// <summary>
        /// �P���Z�o���W���[���ɂ��A�P�����Z�o���܂��B
        /// </summary>
        /// <returns></returns>
        private List<UnitPriceCalcRet> CalclationUnitPrice()
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
            List<GoodsUnitData> tempGoodsUnitDataList = new List<GoodsUnitData>();

            // �d���P���[�������R�[�h�f�B�N�V���i��
            Dictionary<int, int> stockUnPrcFrcProcCdDic = new Dictionary<int, int>();
            // �d������Œ[�������R�[�h�f�B�N�V���i��
            Dictionary<int, int> stockCnsTaxFrcProcCdDic = new Dictionary<int, int>();
            // ����P���[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
            // �������Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // �d���P���[�������R�[�h
            int stockUnPrcFrcProcCd = 0;
            // �d������Œ[�������R�[�h
            int stockCnsTaxFrcProcCd = 0;

            foreach (SalesInputDataSet.SalesDetailRow salesDetailRow in this._salesDetailDataTable)
            {
                if ((salesDetailRow.GoodsMakerCd == 0) || (string.IsNullOrEmpty(salesDetailRow.GoodsNo))) continue;

                //>>>2010/10/01
                //GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(salesDetailRow.GoodsMakerCd, salesDetailRow.GoodsNo);
                GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(salesDetailRow.GoodsMakerCd, salesDetailRow.GoodsNo, salesDetailRow);
                //<<<2010/10/01
                GoodsUnitData tempGoodsUnitData = goodsUnitData.Clone();
                tempGoodsUnitDataList.Add(tempGoodsUnitData);

                if ((goodsUnitData.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(goodsUnitData.GoodsNo)))
                {
                    UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

                    unitPriceCalcParam.BLGoodsCode = salesDetailRow.RateBLGoodsCode;                // BL�R�[�h
                    unitPriceCalcParam.BLGoodsName = salesDetailRow.RateBLGoodsName;                // BL�R�[�h����
                    unitPriceCalcParam.BLGroupCode = salesDetailRow.RateBLGroupCode;                // BL�O���[�v�R�[�h
                    unitPriceCalcParam.CountFl = salesDetailRow.ShipmentCntDisplay;                 // ����
                    unitPriceCalcParam.CustomerCode = this._salesSlip.CustomerCode;                 // ���Ӑ�R�[�h
                    unitPriceCalcParam.CustRateGrpCode = salesDetailRow.CustRateGrpCode;            // ���Ӑ�|���O���[�v�R�[�h
                    unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                   // ���[�J�[�R�[�h
                    unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                             // ���i�ԍ�
                    unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;           // ���i�|���O���[�v�R�[�h
                    unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                 // ���i�|�������N
                    unitPriceCalcParam.PriceApplyDate = this._salesSlip.SalesDate; �@�@�@�@�@       // �K�p��
                    unitPriceCalcParam.SalesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;                 // �������Œ[�������R�[�h
                    unitPriceCalcParam.SalesUnPrcFrcProcCd = salesUnPrcFrcProcCd;                   // ����P���[�������R�[�h
                    unitPriceCalcParam.SectionCode = this._salesSlip.ResultsAddUpSecCd;             // ���_�R�[�h
                    if (stockCnsTaxFrcProcCdDic.ContainsKey(salesDetailRow.SupplierCd))
                    {
                        stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCdDic[salesDetailRow.SupplierCd];  // �d������Œ[�������R�[�h(�f�B�N�V���i�����d����}�X�^����擾)
                    }
                    else
                    {
                        stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, salesDetailRow.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
                        stockCnsTaxFrcProcCdDic.Add(salesDetailRow.SupplierCd, stockCnsTaxFrcProcCd);
                    }
                    unitPriceCalcParam.StockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;
                    
                    if (stockUnPrcFrcProcCdDic.ContainsKey(salesDetailRow.SupplierCd))
                    {
                        stockUnPrcFrcProcCd = stockUnPrcFrcProcCdDic[salesDetailRow.SupplierCd];    // �d���P���[�������R�[�h(�f�B�N�V���i�����d����}�X�^����擾)
                    }
                    else
                    {
                        stockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, salesDetailRow.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                        stockUnPrcFrcProcCdDic.Add(salesDetailRow.SupplierCd, stockUnPrcFrcProcCd);
                    }
                    unitPriceCalcParam.StockUnPrcFrcProcCd = stockUnPrcFrcProcCd;                   // �d���P���[�������R�[�h
                    unitPriceCalcParam.SupplierCd = salesDetailRow.SupplierCd;                      // �d����R�[�h
                    unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                 // �ېŋ敪
                    unitPriceCalcParam.TaxRate = this._salesSlip.ConsTaxRate;                       // �ŗ�
                    unitPriceCalcParam.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd; // ���z�\�����@�敪
                    unitPriceCalcParam.TtlAmntDspRateDivCd = this._salesSlip.TtlAmntDispRateApy;	// ���z�\���|���K�p�敪
                    unitPriceCalcParam.ConsTaxLayMethod = this._salesSlip.ConsTaxLayMethod;         // ����œ]�ŕ���

                    unitPriceCalcParamList.Add(unitPriceCalcParam);
                }
            }

            this._unitPriceCalculation.CalculateSalesRelevanceUnitPrice(unitPriceCalcParamList, tempGoodsUnitDataList, out unitPriceCalcRetList);

            return unitPriceCalcRetList;
        }

        /// <summary>
        /// �P���Z�o���W���[���ɂ��A�P�����Z�o���܂��B
        /// </summary>
        /// <returns></returns>
        private List<UnitPriceCalcRet> CalclationUnitPriceForAcptAnOdr()
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
            List<GoodsUnitData> tempGoodsUnitDataList = new List<GoodsUnitData>();

            // �d���P���[�������R�[�h�f�B�N�V���i��
            Dictionary<int, int> stockUnPrcFrcProcCdDic = new Dictionary<int, int>();
            // �d������Œ[�������R�[�h�f�B�N�V���i��
            Dictionary<int, int> stockCnsTaxFrcProcCdDic = new Dictionary<int, int>();
            // ����P���[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
            // �������Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // �d���P���[�������R�[�h
            int stockUnPrcFrcProcCd = 0;
            // �d������Œ[�������R�[�h
            int stockCnsTaxFrcProcCd = 0;

            foreach (SalesInputDataSet.SalesDetailAcceptAnOrderRow salesDetailRow in this._salesDetailAcceptAnOrderDataTable)
            {
                if ((salesDetailRow.GoodsMakerCd == 0) || (string.IsNullOrEmpty(salesDetailRow.GoodsNo))) continue;

                //>>>2010/10/01
                //GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(salesDetailRow.GoodsMakerCd, salesDetailRow.GoodsNo);
                SalesInputDataSet.SalesDetailRow aRow = this._salesDetailDataTable.NewSalesDetailRow();
                this.CopySalesDetailFromAcceptAnOrder(salesDetailRow, aRow); // �󒍁�����
                GoodsUnitData goodsUnitData = this.GetGoodsUnitDataDic(salesDetailRow.GoodsMakerCd, salesDetailRow.GoodsNo, aRow);
                //<<<2010/10/01
                GoodsUnitData tempGoodsUnitData = goodsUnitData.Clone();
                tempGoodsUnitDataList.Add(tempGoodsUnitData);

                if ((goodsUnitData.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(goodsUnitData.GoodsNo)))
                {
                    UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

                    unitPriceCalcParam.BLGoodsCode = salesDetailRow.RateBLGoodsCode;                // BL�R�[�h
                    unitPriceCalcParam.BLGoodsName = salesDetailRow.RateBLGoodsName;                // BL�R�[�h����
                    unitPriceCalcParam.BLGroupCode = salesDetailRow.RateBLGroupCode;                // BL�O���[�v�R�[�h
                    unitPriceCalcParam.CountFl = salesDetailRow.ShipmentCntDisplay;                 // ����
                    unitPriceCalcParam.CustomerCode = this._salesSlip.CustomerCode;                 // ���Ӑ�R�[�h
                    unitPriceCalcParam.CustRateGrpCode = salesDetailRow.CustRateGrpCode;            // ���Ӑ�|���O���[�v�R�[�h
                    unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                   // ���[�J�[�R�[�h
                    unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                             // ���i�ԍ�
                    unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;           // ���i�|���O���[�v�R�[�h
                    unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                 // ���i�|�������N
                    unitPriceCalcParam.PriceApplyDate = this._salesSlip.SalesDate; �@�@�@�@�@       // �K�p��
                    unitPriceCalcParam.SalesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;                 // �������Œ[�������R�[�h
                    unitPriceCalcParam.SalesUnPrcFrcProcCd = salesUnPrcFrcProcCd;                   // ����P���[�������R�[�h
                    unitPriceCalcParam.SectionCode = this._salesSlip.ResultsAddUpSecCd;             // ���_�R�[�h
                    if (stockCnsTaxFrcProcCdDic.ContainsKey(salesDetailRow.SupplierCd))
                    {
                        stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCdDic[salesDetailRow.SupplierCd];  // �d������Œ[�������R�[�h(�f�B�N�V���i�����d����}�X�^����擾)
                    }
                    else
                    {
                        stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, salesDetailRow.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
                        stockCnsTaxFrcProcCdDic.Add(salesDetailRow.SupplierCd, stockCnsTaxFrcProcCd);
                    }
                    unitPriceCalcParam.StockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;

                    if (stockUnPrcFrcProcCdDic.ContainsKey(salesDetailRow.SupplierCd))
                    {
                        stockUnPrcFrcProcCd = stockUnPrcFrcProcCdDic[salesDetailRow.SupplierCd];    // �d���P���[�������R�[�h(�f�B�N�V���i�����d����}�X�^����擾)
                    }
                    else
                    {
                        stockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, salesDetailRow.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                        stockUnPrcFrcProcCdDic.Add(salesDetailRow.SupplierCd, stockUnPrcFrcProcCd);
                    }
                    unitPriceCalcParam.StockUnPrcFrcProcCd = stockUnPrcFrcProcCd;                   // �d���P���[�������R�[�h
                    unitPriceCalcParam.SupplierCd = salesDetailRow.SupplierCd;                      // �d����R�[�h
                    unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                 // �ېŋ敪
                    unitPriceCalcParam.TaxRate = this._salesSlip.ConsTaxRate;                       // �ŗ�
                    unitPriceCalcParam.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd; // ���z�\�����@�敪
                    unitPriceCalcParam.TtlAmntDspRateDivCd = this._salesSlip.TtlAmntDispRateApy;	// ���z�\���|���K�p�敪
                    unitPriceCalcParam.ConsTaxLayMethod = this._salesSlip.ConsTaxLayMethod;         // ����œ]�ŕ���

                    unitPriceCalcParamList.Add(unitPriceCalcParam);
                }
            }

            this._unitPriceCalculation.CalculateSalesRelevanceUnitPrice(unitPriceCalcParamList, tempGoodsUnitDataList, out unitPriceCalcRetList);

            return unitPriceCalcRetList;
        }

        /// <summary>
        /// �P���Z�o���W���[���ɂ��A�P�����Z�o���܂��B
        /// </summary>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <returns></returns>
        private List<UnitPriceCalcRet> CalclationUnitPrice(List<GoodsUnitData> goodsUnitDataList)
        {
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();
            List<UnitPriceCalcParam> unitPriceCalcParamList = new List<UnitPriceCalcParam>();
            List<GoodsUnitData> tempGoodsUnitDataList = new List<GoodsUnitData>();

            // �d���P���[�������R�[�h�f�B�N�V���i��
            Dictionary<int, int> stockUnPrcFrcProcCdDic = new Dictionary<int, int>();
            // �d������Œ[�������R�[�h�f�B�N�V���i��
            Dictionary<int, int> stockCnsTaxFrcProcCdDic = new Dictionary<int, int>();
            // ����P���[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesUnPrcFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.UnPrcFrcProcCd);
            // �������Œ[�������R�[�h(���Ӑ�}�X�^���擾)
            int salesCnsTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, this._salesSlip.CustomerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);
            // �d���P���[�������R�[�h
            int stockUnPrcFrcProcCd = 0;
            // �d������Œ[�������R�[�h
            int stockCnsTaxFrcProcCd = 0;

            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                GoodsUnitData tempGoodsUnitData = goodsUnitData.Clone();
                tempGoodsUnitDataList.Add(tempGoodsUnitData);

                if ((goodsUnitData.GoodsMakerCd != 0) && (!string.IsNullOrEmpty(goodsUnitData.GoodsNo)))
                {
                    UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();

                    unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                     // BL�R�[�h
                    unitPriceCalcParam.BLGoodsName = goodsUnitData.BLGoodsFullName;                 // BL�R�[�h����
                    unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                     // BL�O���[�v�R�[�h
                    unitPriceCalcParam.CountFl = 0;                                                 // ����
                    unitPriceCalcParam.CustomerCode = this._salesSlip.CustomerCode;                 // ���Ӑ�R�[�h
                    unitPriceCalcParam.CustRateGrpCode = this.GetCustRateGroupCode(goodsUnitData.GoodsMakerCd);           // ���Ӑ�|���O���[�v�R�[�h
                    unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                   // ���[�J�[�R�[�h
                    unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                             // ���i�ԍ�
                    unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;           // ���i�|���O���[�v�R�[�h
                    unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                 // ���i�|�������N
                    unitPriceCalcParam.PriceApplyDate = this._salesSlip.SalesDate; �@�@�@�@�@       // �K�p��
                    unitPriceCalcParam.SalesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;                 // �������Œ[�������R�[�h
                    unitPriceCalcParam.SalesUnPrcFrcProcCd = salesUnPrcFrcProcCd;                   // ����P���[�������R�[�h
                    unitPriceCalcParam.SectionCode = this._salesSlip.ResultsAddUpSecCd;             // ���_�R�[�h
                    if (stockCnsTaxFrcProcCdDic.ContainsKey(goodsUnitData.SupplierCd))
                    {
                        stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCdDic[goodsUnitData.SupplierCd];   // �d������Œ[�������R�[�h(�f�B�N�V���i�����d����}�X�^����擾)
                    }
                    else
                    {
                        stockCnsTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, goodsUnitData.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);
                        stockCnsTaxFrcProcCdDic.Add(goodsUnitData.SupplierCd, stockCnsTaxFrcProcCd);
                    }
                    unitPriceCalcParam.StockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;

                    if (stockUnPrcFrcProcCdDic.ContainsKey(goodsUnitData.SupplierCd))
                    {
                        stockUnPrcFrcProcCd = stockUnPrcFrcProcCdDic[goodsUnitData.SupplierCd];     // �d���P���[�������R�[�h(�f�B�N�V���i�����d����}�X�^����擾)
                    }
                    else
                    {
                        stockUnPrcFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, goodsUnitData.SupplierCd, SupplierAcs.StockFracProcMoneyDiv.UnPrcFrcProcCd);
                        stockUnPrcFrcProcCdDic.Add(goodsUnitData.SupplierCd, stockUnPrcFrcProcCd);
                    }
                    unitPriceCalcParam.StockUnPrcFrcProcCd = stockUnPrcFrcProcCd;                   // �d���P���[�������R�[�h
                    unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                       // �d����R�[�h
                    unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                 // �ېŋ敪
                    unitPriceCalcParam.TaxRate = this._salesSlip.ConsTaxRate;                       // �ŗ�
                    unitPriceCalcParam.TotalAmountDispWayCd = this._salesSlip.TotalAmountDispWayCd; // ���z�\�����@�敪
                    unitPriceCalcParam.TtlAmntDspRateDivCd = this._salesSlip.TtlAmntDispRateApy;	// ���z�\���|���K�p�敪
                    unitPriceCalcParam.ConsTaxLayMethod = this._salesSlip.ConsTaxLayMethod;         // ����œ]�ŕ���

                    unitPriceCalcParamList.Add(unitPriceCalcParam);
                }
            }

            this._unitPriceCalculation.CalculateSalesRelevanceUnitPrice(unitPriceCalcParamList, tempGoodsUnitDataList, out unitPriceCalcRetList);

            return unitPriceCalcRetList;
        }

        /// <summary>
        ///  ���Ӑ�|���O���[�v�R�[�h�擾����
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private int GetCustRateGroupCode(int goodsMakerCode)
        {
            int pureCode = (goodsMakerCode <= ctPureGoodsMakerCode) ? 0 : 1; // 0:���� 1:�D��

            // �P�ƃL�[
            CustRateGroup custRateGroup = this._custRateGroupList.Find(
                delegate(CustRateGroup custRate)
                {
                    if ((custRate.GoodsMakerCd == goodsMakerCode) &&
                        (custRate.PureCode == pureCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            if (custRateGroup != null) return custRateGroup.CustRateGrpCode;

            // ���ʃL�[
            custRateGroup = this._custRateGroupList.Find(
                delegate(CustRateGroup custRate)
                {
                    if ((custRate.GoodsMakerCd == 0) &&
                        (custRate.PureCode == pureCode))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            if (custRateGroup != null) return custRateGroup.CustRateGrpCode;

            //return 0; // DEL 2010/07/16
            return -1; // ADD 2010/07/16
        }

        /// <summary>
        /// �P�����N���A����
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        private void ClearUnitInfo(ref SalesInputDataSet.SalesDetailRow row, string unitPriceKind)
        {
            // �艿���
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_ListPrice)
            {
                row.ListPriceRate = 0;
                row.ListPriceDisplay = 0;
                row.ListPriceTaxExcFl = 0;
                row.ListPriceTaxIncFl = 0;
            }
            // �������
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
            {
                row.CostRate = 0;
                row.SalesUnitCost = 0;
                row.SalesUnitCostTaxExc = 0;
                row.SalesUnitCostTaxInc = 0;
            }
            // �������
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice)
            {
                row.SalesRate = 0;
                row.GrossProfitSecureRate = 0;
                row.CostUpRate = 0;
                row.SalesUnPrcDisplay = 0;
                row.SalesUnPrcTaxExcFl = 0;
                row.SalesUnPrcTaxIncFl = 0;
            }
            this.ClearRateInfo(ref row, unitPriceKind);
        }

        /// <summary>
        /// �P�����N���A�����i�󒍏��p�j
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        private void ClearUnitInfo(ref SalesInputDataSet.SalesDetailAcceptAnOrderRow row, string unitPriceKind)
        {
            SalesInputDataSet.SalesDetailRow newSalesDetailRow = this._salesDetailDataTable.NewSalesDetailRow();

            this.CopySalesDetailFromAcceptAnOrder(row, newSalesDetailRow);
            this.ClearUnitInfo(ref newSalesDetailRow, unitPriceKind);
            this.CopyAcceptAnOrderFromSalesDetail(newSalesDetailRow, row);
        }

        /// <summary>
        /// �|�����N���A����
        /// </summary>
        /// <param name="salesRowNo"></param>
        /// <param name="unitPriceKind"></param>
        public void ClearRateInfo(int salesRowNo, string unitPriceKind)
        {
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            if (row != null) this.ClearRateInfo(ref row, unitPriceKind);
        }

        /// <summary>
        /// �|�����N���A����
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        /// <br>Update Note: 2010/03/22 ���� �����v�Z�����̕s��Ή�</br>
        /// <br>Update Note: 2011/08/15 Redmine#23554 杍^ �|���}�X�^�̔������ݒ肠��Ŋ��A�L�����y�[���̔����z�ݒ肠��̏ꍇ�A�������̓N���A�̑Ή�</br>
        /// <br>Update Note: 2011/09/05 Redmine#23554 yangmj �|���}�X�^�̔������ݒ肠��Ŋ��A�L�����y�[���̔����z�ݒ肠��̏ꍇ�A�������̓N���A�̑Ή�</br>
        private void ClearRateInfo(ref SalesInputDataSet.SalesDetailRow row, string unitPriceKind)
        {
            // �艿���
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_ListPrice)
            {
                row.RateSectPriceUnPrc = string.Empty;
                row.RateDivLPrice = string.Empty;
                row.UnPrcCalcCdLPrice = 0;
                row.PriceCdLPrice = 0;
                row.StdUnPrcLPrice = 0;
                row.FracProcUnitLPrice = 0;
                row.FracProcLPrice = 0;

                //row.BfListPrice = 0;
            }
            // �������
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
            {
                row.RateSectCstUnPrc = string.Empty;
                row.RateDivUnCst = string.Empty;
                row.UnPrcCalcCdUnCst = 0;
                row.PriceCdUnCst = 0;
                // --- DEL 2010/03/22 ---------->>>>>
                // �W�����i�̊|���ݒ�ɂ����āA���[�U�[�艿��ݒ肷�邽�߁A�N���A���Ȃ��B
                //row.StdUnPrcUnCst = 0;
                // --- DEL 2010/03/22 ----------<<<<<
                row.FracProcUnitUnCst = 0;
                row.FracProcUnCst = 0;

                //row.BfUnitCost = 0;
            }
            // �������
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice)
            {
                // ADD 2011/08/15 ----- >>>>>
                if (row.UnPrcCalcCdSalUnPrcTemp != -1)
                {
                    row.UnPrcCalcCdSalUnPrcTemp = row.UnPrcCalcCdSalUnPrc;
                }
                // ADD 2011/08/15 ----- <<<<<

                row.RateSectSalUnPrc = string.Empty;
                row.RateDivSalUnPrc = string.Empty;
                row.UnPrcCalcCdSalUnPrc = 0;
                row.PriceCdSalUnPrc = 0;
                // --- DEL m.suzuki 2011/02/16 ---------->>>>>
                //row.StdUnPrcSalUnPrc = 0;
                // --- DEL m.suzuki 2011/02/16 ----------<<<<<
                row.FracProcUnitSalUnPrc = 0;
                row.FracProcSalUnPrc = 0;

                // DEL 2011/09/05 ---- >>>>
                // ADD 2011/08/15 ---- >>>>
                //if (this.CampaignObjGoodsStInfo != null && this.CampaignObjGoodsStInfo.RateVal == 0)
                //{
                //    row.SalesRate = 0;
                //}
                // ADD 2011/08/15 ---- <<<<
                // DEL 2011/09/05 ---- <<<<

                //row.BfSalesUnitPrice = 0;
            }
        }

        // ADD 2011/09/05 ---- >>>>
        /// <summary>
        /// �|�����N���A����(�L�����y�[���p)
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        /// <br>Programmer : yangmj</br>
        /// <br>Date       : 2011/09/05</br>
        private void ClearRateInfoForCampaign(ref SalesInputDataSet.SalesDetailRow row, string unitPriceKind)
        {
            // �艿���
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_ListPrice)
            {
                row.RateSectPriceUnPrc = string.Empty;
                row.RateDivLPrice = string.Empty;
                row.UnPrcCalcCdLPrice = 0;
                row.PriceCdLPrice = 0;
                row.StdUnPrcLPrice = 0;
                row.FracProcUnitLPrice = 0;
                row.FracProcLPrice = 0;
            }
            // �������
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
            {
                row.RateSectCstUnPrc = string.Empty;
                row.RateDivUnCst = string.Empty;
                row.UnPrcCalcCdUnCst = 0;
                row.PriceCdUnCst = 0;
                row.FracProcUnitUnCst = 0;
                row.FracProcUnCst = 0;
            }
            // �������
            if (unitPriceKind == UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice)
            {
                if (row.UnPrcCalcCdSalUnPrcTemp != -1)
                {
                    row.UnPrcCalcCdSalUnPrcTemp = row.UnPrcCalcCdSalUnPrc;
                }
                row.RateSectSalUnPrc = string.Empty;
                row.RateDivSalUnPrc = string.Empty;
                row.UnPrcCalcCdSalUnPrc = 0;
                row.PriceCdSalUnPrc = 0;
                row.FracProcUnitSalUnPrc = 0;
                row.FracProcSalUnPrc = 0;

                if (this.CampaignObjGoodsStInfo != null && this.CampaignObjGoodsStInfo.RateVal == 0)
                {
                    row.SalesRate = 0;
                }
            }
        }
        // ADD 2011/09/05 ---- <<<

        /// <summary>
        /// �|�����N���A�����i�󒍏��p�j
        /// </summary>
        /// <param name="row"></param>
        /// <param name="unitPriceKind"></param>
        private void ClearRateInfo(ref SalesInputDataSet.SalesDetailAcceptAnOrderRow row, string unitPriceKind)
        {
            SalesInputDataSet.SalesDetailRow newSalesDetailRow = this._salesDetailDataTable.NewSalesDetailRow();

            this.CopySalesDetailFromAcceptAnOrder(row, newSalesDetailRow);
            this.ClearRateInfo(ref newSalesDetailRow, unitPriceKind);
            this.CopyAcceptAnOrderFromSalesDetail(newSalesDetailRow, row);
        }

        /// <summary>
        /// �|�����N���A�����i�S�āj
        /// </summary>
        public void ClearAllRateInfo()
        {
            foreach (SalesInputDataSet.SalesDetailRow row in this._salesDetailDataTable)
            {
                if ((!string.IsNullOrEmpty(row.GoodsNo)) && (row.GoodsMakerCd != 0))
                {
                    row.RateSectPriceUnPrc = string.Empty;
                    row.RateDivLPrice = string.Empty;
                    row.UnPrcCalcCdLPrice = 0;
                    row.PriceCdLPrice = 0;
                    row.StdUnPrcLPrice = 0;
                    row.FracProcUnitLPrice = 0;
                    row.FracProcLPrice = 0;

                    row.RateSectCstUnPrc = string.Empty;
                    row.RateDivUnCst = string.Empty;
                    row.UnPrcCalcCdUnCst = 0;
                    row.PriceCdUnCst = 0;
                    row.StdUnPrcUnCst = 0;
                    row.FracProcUnitUnCst = 0;
                    row.FracProcUnCst = 0;

                    row.RateSectSalUnPrc = string.Empty;
                    row.RateDivSalUnPrc = string.Empty;
                    row.UnPrcCalcCdSalUnPrc = 0;
                    row.PriceCdSalUnPrc = 0;
                    row.StdUnPrcSalUnPrc = 0;
                    row.FracProcUnitSalUnPrc = 0;
                    row.FracProcSalUnPrc = 0;

                    row.BfListPrice = 0;
                    row.BfSalesUnitPrice = 0;
                    row.BfUnitCost = 0;
                }
            }

            foreach (SalesInputDataSet.SalesDetailAcceptAnOrderRow row in this._salesDetailAcceptAnOrderDataTable)
            {
                if ((!string.IsNullOrEmpty(row.GoodsNo)) && (row.GoodsMakerCd != 0))
                {
                    row.RateSectPriceUnPrc = string.Empty;
                    row.RateDivLPrice = string.Empty;
                    row.UnPrcCalcCdLPrice = 0;
                    row.PriceCdLPrice = 0;
                    row.StdUnPrcLPrice = 0;
                    row.FracProcUnitLPrice = 0;
                    row.FracProcLPrice = 0;

                    row.RateSectCstUnPrc = string.Empty;
                    row.RateDivUnCst = string.Empty;
                    row.UnPrcCalcCdUnCst = 0;
                    row.PriceCdUnCst = 0;
                    row.StdUnPrcUnCst = 0;
                    row.FracProcUnitUnCst = 0;
                    row.FracProcUnCst = 0;

                    row.RateSectSalUnPrc = string.Empty;
                    row.RateDivSalUnPrc = string.Empty;
                    row.UnPrcCalcCdSalUnPrc = 0;
                    row.PriceCdSalUnPrc = 0;
                    row.StdUnPrcSalUnPrc = 0;
                    row.FracProcUnitSalUnPrc = 0;
                    row.FracProcSalUnPrc = 0;

                    row.BfListPrice = 0;
                    row.BfSalesUnitPrice = 0;
                    row.BfUnitCost = 0;
                }
            }
        }
        # endregion

        ///// <summary>
        ///// �w�肵���P������ʂ̌��ʏ������ɁA���㖾�׃f�[�^�s�I�u�W�F�N�g�ɔ��P������ݒ肵�܂��B
        ///// </summary>
        ///// <param name="stockRowNo">�s�ԍ�</param>
        ///// <param name="unPrcInfoConfRet">�P�����m�F��ʌ��ʃI�u�W�F�N�g</param>
        //public void SalesDetailRowUnPrcInfoSetting(int salesRowNo, UnPrcInfoConfRet unPrcInfoConfRet, string unitPriceKind)
        //{
        //    SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

        //    if (row != null)
        //    {

        //        if (UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice == unitPriceKind)
        //        {
        //            //--------------------------------------------
        //            // ���P��
        //            //--------------------------------------------
        //            row.UnPrcCalcCdSalUnPrc = unPrcInfoConfRet.UnitPrcCalcDiv;      // �P���Z�o�敪
        //            row.SalesRate = unPrcInfoConfRet.RateVal;                       // �|��
        //            row.StdUnPrcSalUnPrc = unPrcInfoConfRet.StdUnitPrice;           // ��P��
        //            if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount)
        //            {
        //                row.SalesUnPrcDisplay = unPrcInfoConfRet.UnitPriceTaxIncFl;		    // �P���i�����j
        //                // ���㖾�׃f�[�^�Z�b�e�B���O�����i�P���ݒ�j
        //                this.SalesDetailRowSalesUnitPriceSetting(salesRowNo, SalesUnitPriceInputType.SalesUnitPriceDisplay, unPrcInfoConfRet.UnitPriceTaxIncFl);
        //            }
        //            else
        //            {
        //                row.SalesUnPrcDisplay = unPrcInfoConfRet.UnitPriceTaxExcFl;		    // �P���i�����j
        //                // ���㖾�׃f�[�^�Z�b�e�B���O�����i�P���ݒ�j
        //                this.SalesDetailRowSalesUnitPriceSetting(salesRowNo, SalesUnitPriceInputType.SalesUnitPriceDisplay, unPrcInfoConfRet.UnitPriceTaxExcFl);
        //            }
        //            row.FracProcUnitSalUnPrc = unPrcInfoConfRet.UnPrcFracProcUnit;  // �[�������P��
        //            row.FracProcSalUnPrc = unPrcInfoConfRet.UnPrcFracProcDiv;       // �[�������敪

        //            this.SalesDetailRowUnitPriceSetting(ref row, null);
        //            this.SalesDetailRowSalesUnitPriceSetting(salesRowNo, SalesUnitPriceInputType.SalesUnitPriceDisplay, row.SalesUnPrcDisplay);
        //        }
        //        else if (UnitPriceCalculation.ctUnitPriceKind_UnitCost == unitPriceKind)
        //        {
        //            //--------------------------------------------
        //            // ���P��
        //            //--------------------------------------------
        //            row.UnPrcCalcCdUnCst = unPrcInfoConfRet.UnitPrcCalcDiv;         // �P���Z�o�敪
        //            row.CostRate = unPrcInfoConfRet.RateVal;                        // �|��
        //            row.StdUnPrcUnCst = unPrcInfoConfRet.StdUnitPrice;              // ��P��
        //            if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount)
        //            {
        //                row.SalesUnitCost = unPrcInfoConfRet.UnitPriceTaxIncFl;		        // �P���i�����j
        //                // ���㖾�׃f�[�^�Z�b�e�B���O�����i�����ݒ�j
        //                this.SalesDetailRowSalesUnitCostSetting(salesRowNo, SalesUnitPriceInputType.SalesUnitPriceDisplay, unPrcInfoConfRet.UnitPriceTaxIncFl);
        //            }
        //            else
        //            {
        //                row.SalesUnitCost = unPrcInfoConfRet.UnitPriceTaxExcFl;		        // �P���i�����j
        //                // ���㖾�׃f�[�^�Z�b�e�B���O�����i�����ݒ�j
        //                this.SalesDetailRowSalesUnitCostSetting(salesRowNo, SalesUnitPriceInputType.SalesUnitPriceDisplay, unPrcInfoConfRet.UnitPriceTaxExcFl);
        //            }
        //            row.FracProcUnitUnCst = unPrcInfoConfRet.UnPrcFracProcUnit;     // �[�������P��
        //            row.FracProcUnCst = unPrcInfoConfRet.UnPrcFracProcDiv;          // �[�������敪

        //            this.SalesDetailRowUnitPriceSetting(ref row, null);
        //            //this.StockDetailRowStockUnitPriceSetting(salesRowNo, SalesUnitPriceInputType.SalesUnitPriceDisplay, row.SalesUnPrcDisplay);
        //        }
        //        else if (UnitPriceCalculation.ctUnitPriceKind_ListPrice == unitPriceKind)
        //        {
        //            //--------------------------------------------
        //            // �艿
        //            //--------------------------------------------
        //            row.UnPrcCalcCdLPrice = unPrcInfoConfRet.UnitPrcCalcDiv;         // �P���Z�o�敪
        //            row.ListPriceRate = unPrcInfoConfRet.RateVal;                        // �|��
        //            row.StdUnPrcLPrice = unPrcInfoConfRet.StdUnitPrice;              // ��P��
        //            if (this._salesSlip.TotalAmountDispWayCd == (int)TotalAmountDispWayCd.TotalAmount)
        //            {
        //                row.ListPriceDisplay = unPrcInfoConfRet.UnitPriceTaxIncFl;		        // �P���i�����j
        //                // ���㖾�׃f�[�^�Z�b�e�B���O�����i�艿�ݒ�j
        //                this.SalesDetailRowListPriceSetting(salesRowNo, SalesUnitPriceInputType.SalesUnitPriceDisplay, unPrcInfoConfRet.UnitPriceTaxIncFl);
        //            }
        //            else
        //            {
        //                row.ListPriceDisplay = unPrcInfoConfRet.UnitPriceTaxExcFl;		        // �P���i�����j
        //                // ���㖾�׃f�[�^�Z�b�e�B���O�����i�艿�ݒ�j
        //                this.SalesDetailRowListPriceSetting(salesRowNo, SalesUnitPriceInputType.SalesUnitPriceDisplay, unPrcInfoConfRet.UnitPriceTaxExcFl);
        //            }
        //            row.FracProcUnitLPrice = unPrcInfoConfRet.UnPrcFracProcUnit;     // �[�������P��
        //            row.FracProcLPrice = unPrcInfoConfRet.UnPrcFracProcDiv;          // �[�������敪

        //            this.SalesDetailRowUnitPriceSetting(ref row, null);
        //            //this.StockDetailRowStockUnitPriceSetting(salesRowNo, SalesUnitPriceInputType.SalesUnitPriceDisplay, row.SalesUnPrcDisplay);
        //        }
        //    }
        //}

        /// <summary>
        /// ���i���i�̍Đݒ���s���܂��B
        /// </summary>
        /// <param name="salesRowNo"></param>
        public void SalesDetailRowGoodsPriceReSetting(List<List<GoodsUnitData>> goodsUnitDataListList)
        {
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            this.GetGoodsUnitDataListFromListList(goodsUnitDataListList, out goodsUnitDataList);
            this.SalesDetailRowGoodsPriceReSetting(goodsUnitDataList);
        }

        /// <summary>
        /// ���i���i�̍Đݒ���s���܂��B
        /// </summary>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        public void SalesDetailRowGoodsPriceReSetting(List<GoodsUnitData> goodsUnitDataList)
        {
            // �ŗ��ăZ�b�g
            // --- UPD 2014/04/02 Y.Wakita ---------->>>>>
            //this._salesSlip.ConsTaxRate = _salesSlipInputInitDataAcs.TaxRate;
            this._salesSlip.ConsTaxRate = this._salesSlipInputInitDataAcs.GetTaxRate(this._salesSlip.SalesDate); // �ŗ�
            // --- UPD 2014/04/02 Y.Wakita ----------<<<<<

            List<UnitPriceCalcRet> allUnitPriceCalcRetList = this.CalclationUnitPrice();
            List<UnitPriceCalcRet> unitPriceCalcRetList = new List<UnitPriceCalcRet>();

            for (int i = 0; i < this._salesDetailDataTable.Rows.Count; i++)
            {
                SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable[i];

                if (((row.EditStatus == ctEDITSTATUS_AllOK) || (row.EditStatus == ctEDITSTATUS_AddUpEdit) || (row.EditStatus == ctEDITSTATUS_AddUpNew)) &&
                    (!string.IsNullOrEmpty(row.GoodsNo)) || (!string.IsNullOrEmpty(row.GoodsName)))
                {
                    GoodsUnitData goodsUnitData = new GoodsUnitData();
                    //>>>2010/10/01
                    //goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo);
                    goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo, row);
                    //<<<2010/10/01
                    unitPriceCalcRetList = this.GetUnitPriceCalcRetList(allUnitPriceCalcRetList, row.GoodsNo, row.GoodsMakerCd, row.SupplierCd);
                    this.SalesDetailRowGoodsPriceSetting(ref row, goodsUnitData, true, unitPriceCalcRetList);
                }
            }
        }

        /// <summary>
        /// ���i���i�̍Đݒ���s���܂��B
        /// </summary>
        public void SalesDetailRowGoodsPriceReSetting(int salesRowNo)
        {
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            this.SalesDetailRowGoodsPriceReSetting(row);
        }

        // ------ ADD 2011/09/05 --------- >>>>>>
        /// <summary>
        /// ���i���i�̍Đݒ���s���܂��u�̔��敪�`�F�b�N�p�v�B
        /// </summary>
        public void SalesDetailRowGoodsPriceForSalesCodeCheck(int salesRowNo)
        {
            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);
            SalesInputDataSet.SalesDetailRow rowBak = this._salesDetailDataTable.NewSalesDetailRow();
            rowBak.GoodsMakerCd = row.GoodsMakerCd;
            rowBak.GoodsNo = row.GoodsNo;
            rowBak.BLGroupCode = row.BLGroupCode;  // ADD 2011/09/14
            rowBak.BLGoodsCode = row.BLGoodsCode;
            rowBak.SupplierCd = row.SupplierCd;
            rowBak.RateBLGoodsCode = row.RateBLGoodsCode;
            rowBak.RateBLGoodsName = row.RateBLGoodsName;
            rowBak.RateBLGroupCode = row.RateBLGroupCode;
            rowBak.ShipmentCntDisplay = row.ShipmentCntDisplay;
            rowBak.CustRateGrpCode = row.CustRateGrpCode;
            rowBak.RateGoodsRateGrpCd = row.RateGoodsRateGrpCd;
            rowBak.GoodsRateRank = row.GoodsRateRank;
            rowBak.TaxationDivCd = row.TaxationDivCd;
            rowBak.SalesUnPrcTaxExcFl = row.SalesUnPrcTaxExcFl;
            rowBak.SalesUnPrcTaxIncFl = row.SalesUnPrcTaxIncFl;
            rowBak.SalesCode = row.SalesCode;
            rowBak.ListPriceDisplay = row.ListPriceDisplay;
            rowBak.ListPriceTaxExcFl = row.ListPriceTaxExcFl;
            rowBak.ListPriceTaxIncFl = row.ListPriceTaxIncFl;
            rowBak.SalesUnitCostTaxExc = row.SalesUnitCostTaxExc;
            rowBak.SalesUnitCostTaxInc = row.SalesUnitCostTaxInc;
            rowBak.StdUnPrcUnCst = row.StdUnPrcUnCst;
            rowBak.RateDivUnCst = row.RateDivUnCst;
            rowBak.StdUnPrcLPrice = row.StdUnPrcLPrice;
            rowBak.RateDivLPrice = row.RateDivLPrice;
            this.SalesDetailRowGoodsPriceForSalesCodeCheck(rowBak);
        }

        /// <summary>
        /// ���i���i�̍Đݒ���s���܂��u�̔��敪�`�F�b�N�p�v�B
        /// </summary>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        public void SalesDetailRowGoodsPriceForSalesCodeCheck(SalesInputDataSet.SalesDetailRow row)
        {
            // �ŗ��ăZ�b�g
            // --- UPD 2014/04/02 Y.Wakita ---------->>>>>
            //this._salesSlip.ConsTaxRate = _salesSlipInputInitDataAcs.TaxRate;
            this._salesSlip.ConsTaxRate = this._salesSlipInputInitDataAcs.GetTaxRate(this._salesSlip.SalesDate); // �ŗ�
            // --- UPD 2014/04/02 Y.Wakita ----------<<<<<

            if (((row.EditStatus == ctEDITSTATUS_AllOK) || (row.EditStatus == ctEDITSTATUS_AddUpEdit) ||
                 (row.EditStatus == ctEDITSTATUS_AddUpNew) || (row.EditStatus == ctEDITSTATUS_ExistSlip)))
            {
                GoodsUnitData goodsUnitData = new GoodsUnitData();

                goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo, row);

                this.SalesDetailRowGoodsPriceForSalesCodeCheck(row, goodsUnitData, true);
            }
        }
        // ------ ADD 2011/09/05 --------- <<<<<<

        /// <summary>
        /// ���i���i�̍Đݒ���s���܂��B
        /// </summary>
        /// <param name="salesDetailDataTable">���㖾�׃f�[�^�e�[�u���I�u�W�F�N�g</param>
        public void SalesDetailRowGoodsPriceReSetting(SalesInputDataSet.SalesDetailRow row)
        {
            // �ŗ��ăZ�b�g
            // --- UPD 2014/04/02 Y.Wakita ---------->>>>>
            //this._salesSlip.ConsTaxRate = _salesSlipInputInitDataAcs.TaxRate;
            // ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή� ------>>>>>
            if (this._salesSlip.ConsTaxLayMethod == 0 && (this._salesSlipInputInitDataAcs.TaxRateInput == 0.0 ||
                this._salesSlipInputInitDataAcs.RentSyncSupFlg || (!this._salesSlipInputInitDataAcs.SlipSrcTaxFlg &&
                this._salesSlip.SalesSlipNum != SalesSlipInputAcs.ctDefaultSalesSlipNum)))
            {
                this._salesSlip.ConsTaxRate = this._salesSlipInputInitDataAcs.GetTaxRateMst(this._salesSlip.SalesDate); // �ŗ�
                this._salesSlipInputInitDataAcs.TaxRate = this._salesSlip.ConsTaxRate;
                this._salesSlipInputInitDataAcs.TaxRateDiv = 2;
            }
            else
            {
                // ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή� ------<<<<<
                this._salesSlip.ConsTaxRate = this._salesSlipInputInitDataAcs.GetTaxRate(this._salesSlip.SalesDate); // �ŗ�
            }// ADD 杍^ 2020/02/24 PMKOBETSU-2912�̑Ή�
            // --- UPD 2014/04/02 Y.Wakita ----------<<<<<

            //>>>2010/10/04
            //if (((row.EditStatus == ctEDITSTATUS_AllOK) || (row.EditStatus == ctEDITSTATUS_AddUpEdit) || 
            //     (row.EditStatus == ctEDITSTATUS_AddUpNew) || (row.EditStatus == ctEDITSTATUS_ExistSlip)) &&
            //    (!string.IsNullOrEmpty(row.GoodsNo)))
            if (((row.EditStatus == ctEDITSTATUS_AllOK) || (row.EditStatus == ctEDITSTATUS_AddUpEdit) ||
                 (row.EditStatus == ctEDITSTATUS_AddUpNew) || (row.EditStatus == ctEDITSTATUS_ExistSlip)))
            //<<<2010/10/04
            {
                GoodsUnitData goodsUnitData = new GoodsUnitData();
                //>>>2010/10/01
                //goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo);
                goodsUnitData = this.GetGoodsUnitDataDic(row.GoodsMakerCd, row.GoodsNo, row);
                //<<<2010/10/01
                this.SalesDetailRowGoodsPriceSetting(ref row, goodsUnitData, true);
            }
        }

        /// <summary>
        /// �P���Z�o���ʃN���X�Ώۃ��R�[�h�擾����
        /// </summary>
        /// <param name="unitPriceCalcRetList"></param>
        /// <param name="goodsNo"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="supplierCd"></param>
        /// <returns></returns>
        private List<UnitPriceCalcRet> GetUnitPriceCalcRetList(List<UnitPriceCalcRet> unitPriceCalcRetList, string goodsNo, int goodsMakerCd, int supplierCd)
        {
            List<UnitPriceCalcRet> retUnitPriceCalcRetList = new List<UnitPriceCalcRet>();
            foreach (UnitPriceCalcRet unitPriceCalcRet in unitPriceCalcRetList)
            {
                if ((((!string.IsNullOrEmpty(unitPriceCalcRet.GoodsNo)) && (unitPriceCalcRet.GoodsNo == goodsNo)) || 
                     (string.IsNullOrEmpty(unitPriceCalcRet.GoodsNo))) &&
                    (((unitPriceCalcRet.GoodsMakerCd != 0) && (unitPriceCalcRet.GoodsMakerCd == goodsMakerCd)) ||
                     (unitPriceCalcRet.GoodsMakerCd == 0)) &&
                    (((unitPriceCalcRet.SupplierCd != 0) && (unitPriceCalcRet.SupplierCd == supplierCd)) || 
                     (unitPriceCalcRet.SupplierCd == 0)))
                {
                    UnitPriceCalcRet cloneUnitPriceCalcRet = unitPriceCalcRet.Clone();
                    retUnitPriceCalcRetList.Add(cloneUnitPriceCalcRet);
                }
            }
            return retUnitPriceCalcRetList;
        }

        /// <summary>
        /// �Ώۋ��z���A�Ŕ����A�ō��݉��i���v�Z���܂��B
        /// </summary>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <param name="taxRate">�ŗ�</param>
        /// <param name="totalAmountDispWayCd">���z�\���敪</param>
        /// <param name="displayPrice">�Ώۋ��z</param>
        /// <param name="priceTaxExc">�Ŕ������z</param>
        /// <param name="priceTaxInc">�ō��݋��z</param>
        public void CalcTaxExcAndTaxInc(int taxationCode, int customerCode, double taxRate, int totalAmountDispWayCd, double displayPrice, out double priceTaxExc, out double priceTaxInc)
        {
            priceTaxExc = 0;
            priceTaxInc = 0;
            // ���Ӑ�}�X�^�������Œ[�����������擾
            int salesTaxFrcProcCd = this._customerInfoAcs.GetSalesFractionProcCd(this._enterpriseCode, customerCode, CustomerInfoAcs.FracProcMoneyDiv.CnsTaxFrcProcCd);		// �������Œ[�������R�[�h
            double fracProcUnit;
            int fracProcCd;
            this._salesSlipInputInitDataAcs.GetStockFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, salesTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

            // ���ŕi
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                priceTaxInc = displayPrice;
                priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
            }
            // �O�ŕi
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                // ���z�\�����Ă���ꍇ�͐ō��݉��i
                if (totalAmountDispWayCd == 1)
                {
                    priceTaxInc = displayPrice;
                    priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
                }
                else
                {
                    priceTaxExc = displayPrice;
                    priceTaxInc = displayPrice + CalculateTax.GetTaxFromPriceExc(taxRate, fracProcUnit, fracProcCd, priceTaxExc);
                }
            }
            // ��ېŕi
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
            {
                priceTaxExc = displayPrice;
                priceTaxInc = displayPrice;
            }
            else
            {
                priceTaxExc = 0;
                priceTaxInc = 0;
            }
        }

        /// <summary>
        /// �Ώۋ��z���A�Ŕ����A�ō��݉��i���v�Z���܂��B
        /// </summary>
        /// <param name="taxationCode">�ېŋ敪</param>
        /// <param name="supplierCd">�d����R�[�h</param>
        /// <param name="taxRate">�ŗ�</param>
        /// <param name="totalAmountDispWayCd">���z�\���敪</param>
        /// <param name="displayPrice">�Ώۋ��z</param>
        /// <param name="priceTaxExc">�Ŕ������z</param>
        /// <param name="priceTaxInc">�ō��݋��z</param>
        public void CalcTaxExcAndTaxIncForStock(int taxationCode, int supplierCd, double taxRate, int totalAmountDispWayCd, double displayPrice, out double priceTaxExc, out double priceTaxInc)
        {
            priceTaxExc = 0;
            priceTaxInc = 0;
            // �d����}�X�^�������Œ[�����������擾
            int stockTaxFrcProcCd = this._supplierAcs.GetStockFractionProcCd(this._enterpriseCode, supplierCd, SupplierAcs.StockFracProcMoneyDiv.CnsTaxFrcProcCd);		// �d������Œ[�������R�[�h
            double fracProcUnit;
            int fracProcCd;
            this._salesSlipInputInitDataAcs.GetStockFractionProcInfo(SalesSlipInputInitDataAcs.ctFracProcMoneyDiv_Tax, stockTaxFrcProcCd, 0, out fracProcUnit, out fracProcCd);

            // ���ŕi
            if (taxationCode == (int)CalculateTax.TaxationCode.TaxInc)
            {
                priceTaxInc = displayPrice;
                priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
            }
            // �O�ŕi
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxExc)
            {
                // ���z�\�����Ă���ꍇ�͐ō��݉��i
                if (totalAmountDispWayCd == 1)
                {
                    priceTaxInc = displayPrice;
                    priceTaxExc = displayPrice - CalculateTax.GetTaxFromPriceInc(taxRate, fracProcUnit, fracProcCd, priceTaxInc);
                }
                else
                {
                    priceTaxExc = displayPrice;
                    priceTaxInc = displayPrice + CalculateTax.GetTaxFromPriceExc(taxRate, fracProcUnit, fracProcCd, priceTaxExc);
                }
            }
            // ��ېŕi
            else if (taxationCode == (int)CalculateTax.TaxationCode.TaxNone)
            {
                priceTaxExc = displayPrice;
                priceTaxInc = displayPrice;
            }
            else
            {
                priceTaxExc = 0;
                priceTaxInc = 0;
            }
        }
        #endregion

        // --- ADD 2013/11/05 Y.Wakita ---------->>>>>
        /// <summary>
        /// �������͂��o�א����󒍐������f
        /// </summary>
        /// <returns></returns>
        public bool CheckFocusPositionAfterBLCodeSearch(int salesRowNo)
        {
            bool status = false;

            SalesInputDataSet.SalesDetailRow row = this._salesDetailDataTable.FindBySalesSlipNumSalesRowNo(this._currentSalesSlipNum, salesRowNo);

            if (row != null)
            {
                // �V�K�o�^�@�܂��́@�e��v��
                if ((this._salesSlip.InputMode == ctINPUTMODE_SalesSlip_Normal &&
                     this._salesSlip.SalesSlipNum == ctDefaultSalesSlipNum) ||
                    (this._salesSlip.InputMode == ctINPUTMODE_SalesSlip_AcceptAnOrderAddUp ||
                     this._salesSlip.InputMode == ctINPUTMODE_SalesSlip_EstimateAddUp ||
                     this._salesSlip.InputMode == ctINPUTMODE_SalesSlip_ShipmentAddUp))
                {
                    // �`�[��ʁF����A�ݏo
                    if (this._salesSlip.AcptAnOdrStatus == (int)AcptAnOdrStatusState.Sales ||
                        this._salesSlip.AcptAnOdrStatus == (int)AcptAnOdrStatusState.Shipment)
                    {
                        // �`�[�敪�F�|����
                        if (this._salesSlip.SalesSlipCd == (int)SalesSlipCd.Sales)
                        {
                            // ���i�l���A�s�l���ȊO
                            if (row.EditStatus != ctEDITSTATUS_GoodsDiscount &&
                                row.EditStatus != ctEDITSTATUS_RowDiscount)
                            {
                                // ����S�̐ݒ�@�󒍐����́F����
                                // ���[�U�[�ݒ�@���i������̃J�[�\���ʒu�F�󒍐�
                                if (this._salesSlipInputInitDataAcs.GetSalesTtlSt().AcpOdrInputDiv == 1 &&
                                    SalesSlipInputConstructionAcs.GetInstance().FocusPositionAfterBLCodeSearchValue == 1)
                                {
                                    status = true;
                                }
                            }
                        }
                    }
                }
            }

            return status;
        }
        // --- ADD 2013/11/05 Y.Wakita ----------<<<<<


        // --- ADD 杍^ 2014/09/01 Redmine#43289---------->>>>>
        /// <summary>
        /// �ԗ����THREAD�ɐݒ肵�܂��B
        /// </summary>
        /// <returns></returns>
        private void SetCarInfoToThread(GoodsCndtn cndtn)
        {
            // TLS�p�̕ϐ�
            CarInfoThreadData carInfoThreadData = new CarInfoThreadData();

            // �ԗ����
            if (cndtn != null && cndtn.SearchCarInfo != null)
            {
                if (cndtn.SearchCarInfo.CarModelUIData.Count > 0)
                {
                    // �ޕ�(PM�̏��)
                    carInfoThreadData.ModelDesignationNo = cndtn.SearchCarInfo.CarModelUIData[0].ModelDesignationNo;
                    // �ԍ�(PM�̏��)
                    carInfoThreadData.CategoryNo = cndtn.SearchCarInfo.CarModelUIData[0].CategoryNo;
                    // �ԑ�ԍ�(PM�̏��)
                    carInfoThreadData.FrameNo = cndtn.SearchCarInfo.CarModelUIData[0].FrameNo;
                    // ���Y�^�O�ԋ敪(PM�̏��)���q�Ǘ��}�X�^�u1:���Y,2:�O�ԁv
                    carInfoThreadData.FrameNoKubun = cndtn.SearchCarInfo.CarModelUIData[0].DomesticForeignCode;
                    // �N��(PM�̏��)
                    carInfoThreadData.FirstEntryDate = cndtn.SearchCarInfo.CarModelUIData[0].ProduceTypeOfYearInput;
                }

                if (cndtn.SearchCarInfo.CarModelInfoSummarized.Count > 0)
                {
                    PMKEN01010E.CarModelInfoRow[] row = (PMKEN01010E.CarModelInfoRow[])cndtn.SearchCarInfo.CarModelInfoSummarized.Select("SelectionState = true", "", DataViewRowState.CurrentRows);
                    if (row.Length > 0)
                    {
                        // ���[�J�[(PM�̏��)
                        carInfoThreadData.MakerCode = row[0].MakerCode;
                        // �Ԏ�(PM�̏��)(PM�̏��)
                        carInfoThreadData.ModelCode = row[0].ModelCode;
                        // �Ԏ�T�u�R�[�h(PM�̏��)
                        carInfoThreadData.ModelSubCode = row[0].ModelSubCode;
                        // �Ԏ햼(PM�̏��)
                        carInfoThreadData.ModelFullName = row[0].ModelFullName;
                        // �^��(PM�̏��)
                        carInfoThreadData.FullModel = row[0].FullModel;
                    }
                }
            }

            // �N���敪(PM�̏��)�S�̏����l�ݒ�}�X�^�́u0:����@1:�a��i�N���j�v
            carInfoThreadData.FirstEntryDateKubun = this._salesSlipInputInitDataAcs.GetAllDefSet().EraNameDispCd1;
            // ���l(PM�̏��)
            carInfoThreadData.Note = this._salesSlip.SlipNote;
            // XML�t�@�C���ۑ��p
            carInfoThreadData.Pgid = PGID_XML;

            // SOLT���g���O�ɁAFREE���������s���܂��B
            Thread.FreeNamedDataSlot(CARINFOSOLT);
            carInfoSolt = Thread.AllocateNamedDataSlot(CARINFOSOLT);
            Thread.SetData(carInfoSolt, carInfoThreadData);
        }
        // --- ADD 杍^ 2014/09/01 Redmine#43289----------<<<<<

        // ADD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� --------------------->>>>>
        /// <summary>
        /// �񋟃f�[�^���i���擾
        /// </summary>
        /// <param name="partsInfoDataSet">���i�����f�[�^�Z�b�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <returns></returns>
        private void GetOfrPriceDataList(PartsInfoDataSet partsInfoDataSet, List<GoodsUnitData> goodsUnitDataList)
        {
            this.GetOfrPriceDataListProc(partsInfoDataSet, goodsUnitDataList, false);
        }

        /// <summary>
        /// �񋟃f�[�^���i���擾
        /// </summary>
        /// <param name="partsInfoDataSet">���i�����f�[�^�Z�b�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <returns></returns>
        private void GetOfrPriceDataList(PartsInfoDataSet partsInfoDataSet, List<List<GoodsUnitData>> goodsUnitDataListList)
        {
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            foreach (List<GoodsUnitData> goodsUnitDataList in goodsUnitDataListList)
            {
                if ((goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                {
                    this.GetOfrPriceDataListProc(partsInfoDataSet, goodsUnitDataList, true);
                }
            }
        }

        /// <summary>
        /// �񋟃f�[�^���i���擾
        /// </summary>
        /// <param name="partsInfoDataSet">���i�����f�[�^�Z�b�g</param>
        /// <param name="goodsUnitDataList">���i�A���f�[�^�I�u�W�F�N�g���X�g</param>
        /// <param name="goodsUnitDataList">�X�V�t���O</param>
        /// <returns></returns>
        private void GetOfrPriceDataListProc(PartsInfoDataSet partsInfoDataSet, List<GoodsUnitData> goodsUnitDataList, bool isUpdate)
        {
            GoodsInfoKey goodsInfoKey;
            List<GoodsPrice> mkrSuggestRtPricUList = null;
            List<GoodsPrice> mkrSuggestRtPricList = null;

            if (partsInfoDataSet == null || goodsUnitDataList == null || goodsUnitDataList.Count <= 0)
            {
                // �p�����[�^�s���̂��ߏI��
                return;
            }

            foreach(GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                // �����L�[�쐬
                goodsInfoKey = new GoodsInfoKey(goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd);

                // ���[�J�[��]�������i���쐬
                PartsInfoDataSet.UsrGoodsPriceRow[] usrGoodsPriceRows =
                    (PartsInfoDataSet.UsrGoodsPriceRow[])partsInfoDataSet.UsrGoodsPrice.Select(
                        string.Format("GoodsMakerCd = '{0}' AND GoodsNo = '{1}'",
                        goodsUnitData.GoodsMakerCd,
                        goodsUnitData.GoodsNo));

                // �񋟃f�[�^���i���f�[�^�e�[�u�����牿�i�ꗗ���쐬
                mkrSuggestRtPricUList = GetGoodsPriceList(usrGoodsPriceRows);

                // ���[�J�[��]�������i���i���[�U�[�o�^���j�o�^�ς݃`�F�b�N
                if (this._mkrSuggestRtPricUList.ContainsKey(goodsInfoKey))
                {
                    // �o�^�ς�
                    // �X�V�t���O��true�̏ꍇ�A���f�[�^���폜���V�f�[�^��ǉ�����
                    // �X�V�t���O��false�̏ꍇ�A�f�[�^�ǉ����s��Ȃ�
                    if (isUpdate)
                    {
                        this._mkrSuggestRtPricUList.Remove(goodsInfoKey);
                        this._mkrSuggestRtPricUList.Add(goodsInfoKey, mkrSuggestRtPricUList);
                    }
                }
                else
                {
                    // ���o�^
                    this._mkrSuggestRtPricUList.Add(goodsInfoKey, mkrSuggestRtPricUList);
                }

                // ���[�J�[��]�������i���쐬
                PartsInfoDataSet.UsrGoodsPriceRow[] ofrPriceRows =
                    (PartsInfoDataSet.UsrGoodsPriceRow[])partsInfoDataSet.OfrPriceDataTable.Select(
                        string.Format("GoodsMakerCd = '{0}' AND GoodsNo = '{1}'",
                        goodsUnitData.GoodsMakerCd,
                        goodsUnitData.GoodsNo));

                // �񋟃f�[�^���i���f�[�^�e�[�u�����牿�i�ꗗ���쐬
                mkrSuggestRtPricList = GetGoodsPriceList(ofrPriceRows);

                // ���[�J�[��]�������i���o�^�ς݃`�F�b�N
                if (this._mkrSuggestRtPricList.ContainsKey(goodsInfoKey))
                {
                    // �o�^�ς�
                    // �X�V�t���O��true�̏ꍇ�A���f�[�^���폜���V�f�[�^��ǉ�����
                    // �X�V�t���O��false�̏ꍇ�A�f�[�^�ǉ����s��Ȃ�
                    if (isUpdate)
                    {
                        this._mkrSuggestRtPricList.Remove(goodsInfoKey);
                        this._mkrSuggestRtPricList.Add(goodsInfoKey, mkrSuggestRtPricList);
                    }
                }
                else
                {
                    // ���o�^
                    this._mkrSuggestRtPricList.Add(goodsInfoKey, mkrSuggestRtPricList);
                }
            }
        }

        private List<GoodsPrice> GetGoodsPriceList(PartsInfoDataSet.UsrGoodsPriceRow[] priceRows)
        {
            List<GoodsPrice> retList = new List<GoodsPrice>();

            if (priceRows != null)
            {
                // ���[�J�[��]�������i���쐬
                for (int j = 0; j < priceRows.Length; j++)
                {
                    GoodsPrice prc = new GoodsPrice();
                    prc.CreateDateTime = new DateTime(priceRows[j].CreateDateTime);
                    prc.UpdateDateTime = new DateTime(priceRows[j].UpdateDateTime);
                    prc.EnterpriseCode = priceRows[j].EnterpriseCode;
                    if (priceRows[j].IsFileHeaderGuidNull() == false)
                        prc.FileHeaderGuid = priceRows[j].FileHeaderGuid;
                    prc.UpdAssemblyId1 = priceRows[j].UpdAssemblyId1;
                    prc.UpdAssemblyId2 = priceRows[j].UpdAssemblyId2;
                    prc.UpdEmployeeCode = priceRows[j].UpdEmployeeCode;
                    prc.LogicalDeleteCode = priceRows[j].LogicalDeleteCode;

                    prc.GoodsMakerCd = priceRows[j].GoodsMakerCd;
                    prc.GoodsNo = priceRows[j].GoodsNo;
                    prc.ListPrice = priceRows[j].ListPrice;
                    prc.OpenPriceDiv = priceRows[j].OpenPriceDiv;
                    prc.PriceStartDate = priceRows[j].PriceStartDate;
                    prc.SalesUnitCost = priceRows[j].SalesUnitCost;
                    prc.StockRate = priceRows[j].StockRate;
                    if (priceRows[j].IsUpdateDateNull() == false)
                    {
                        prc.UpdateDate = priceRows[j].UpdateDate;
                    }
                    else
                    {
                        prc.UpdateDate = DateTime.MinValue;
                    }
                    prc.OfferDate = priceRows[j].OfferDate;
                    retList.Add(prc);
                }
            }
            return retList;
        }
        // ADD 2015/03/18 �L�� SCM������ ���[�J�[��]�������i�Ή� ---------------------<<<<<
    }

}