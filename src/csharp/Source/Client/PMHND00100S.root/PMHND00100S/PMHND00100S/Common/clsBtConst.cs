//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : PMNS-HTT�ʐM�T�[�r�X
// �v���O�����T�v   : PMNS-HTT�Ԃ̒ʐM���s���T�[�r�X�v���O�����ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : �����@�q�V
// �� �� ��  2017/07/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : �����@�q�V
// �C �� ��  2017/08/01  �C�����e : �Q���J��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11575094-00 �쐬�S�� : �݁@��
// �C �� ��  2019/06/13  �C�����e : �单����i��Q�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570136-00 �쐬�S�� : ���X  �Ė�
// �C �� ��  2019/10/16  �C�����e : �U���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570136-00 �쐬�S�� : ��
// �C �� ��  2019/11/14  �C�����e : �U���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570249-00 �쐬�S�� : ���X  �Ė�
// �C �� ��  2020/04/01  �C�����e : �n���f�B�d���ꎞ�݌ɓo�^�Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace PMHND00100S.Common
{
    /// public class name:   clsBtConst
    /// <summary>
    ///                      ���ʎg�p����萔��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>note             :   �v���W�F�N�g���ŋ��ʎg�p����萔���`����</br>
    /// <br>Programmer       :   �����@�q�V</br>
    /// <br>Date             :   2017/07/01</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note      :   2017/08/01  �����@�q�V</br>
    /// <br>                 :   �Q���J��</br>
    /// <br></br>
    /// </remarks>
    class clsBtConst
    {
        /// <summary>�N���p�^���[�^</summary>
        public const string START_PARAMETERS = "dsp";

        /// <summary>�ݒ�t�@�C����KEY�@�n���f�B�Ƃ̃\�P�b�g�ʐM�@�h�o�A�h���X</summary>
        public const string KEY_SOCKETIPADDRESS = "ipaddress";

        /// <summary>�ݒ�t�@�C����KEY�@�n���f�B�Ƃ̃\�P�b�g�ʐM�@�|�[�g</summary>
        public const string KEY_SOCKETPORT = "socketport";

        /// <summary>�ݒ�t�@�C����KEY�@���O�̏o�͔���</summary>
        public const string KEY_DEBUGDETAILLOG = "debugdetaillog";
        public const string DEBUG_DETAIL_LOG_ON = "on";
        public const string DEBUG_DETAIL_LOG_OFF = "off";

        /// <summary>�ݒ�t�@�C����KEY�@�h�o�b�A�h���X</summary>
        public const string KEY_IPCADDRESS = "ipcaddress";

        // --- ADD 2019/06/13 ---------->>>>>
        /// <summary>�ݒ�t�@�C����KEY�@���g���C��</summary>
        public const string KEY_RETRYTIMES = "retrytimes";
        /// <summary>�ݒ�t�@�C����KEY�@���g���C�Ԋu</summary>
        public const string KEY_RETRYINTERVAL = "retryinterval";
        // --- ADD 2019/06/13 ----------<<<<<

        // -- ADD 2019/10/16 ------------------------------>>>
        /// <summary>�L�[����  SOCKET_BUFFER_SIZE</summary>
        public const string KEY_SOCKET_BUFFER_SIZE = "socket_buffer_size";
        // -- ADD 2019/10/16 ------------------------------<<<

        /// <summary>�΃n���f�B�\�P�b�g�ʐM�I���R�[�h</summary>
        public const string HT_MSG_CRLF = "\n";
        /// <summary>�\�P�b�g�ʐM�@�ʐM�I���R�[�h��</summary>
        public const Int32 HT_MSG_CRLF_LEN = 1;

        /// <summary>�΃n���f�B�\�P�b�g �G���[</summary>
        public const string HT_MSG_SOCKETERR = "-3";

        /// <summary>�\�P�b�g�ʐM�@�����敪 ���O�C�����擾</summary>
        public const Int32 SCKSYRKBN_GET_LOGININFO = 1;
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i���擾</summary>
        public const Int32 SCKSYRKBN_GET_SYOHININFO = 2;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �`�[���擾 �`�[���i</summary>
        public const Int32 SCKSYRKBN_GET_SLIPINFO_MDDENPYOU = 3;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �`�[���擾 �ꊇ���i</summary>
        public const Int32 SCKSYRKBN_GET_SLIPINFO_MDIKKATSU = 4;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �݌ɏ��擾</summary>
        public const Int32 SCKSYRKBN_GET_ZAIKOINFO = 5;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �`�[���X�V</summary>
        public const Int32 SCKSYRKBN_INS_SLIPINFO = 6;
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i���X�V�i�o�[�R�[�h�j</summary>
        public const Int32 SCKSYRKBN_INS_SYOHININFO_BARCODE = 7;
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i���X�V�i���ʁj</summary>
        public const Int32 SCKSYRKBN_INS_SYOHININFO_SU = 8;

        // -- ADD 2017/08/01 ------------------------------>>>
        /// <summary>�\�P�b�g�ʐM�@�����敪 �݌Ɏd��(���ɍX�V)�@�`�[�ꗗ�擾</summary>
        public const Int32 SCKSYRKBN_GET_NYU_SLIPLIST = 9;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �݌Ɏd��(���ɍX�V)�@�`�[���擾</summary>
        public const Int32 SCKSYRKBN_GET_NYU_SLIPINFO = 10;
        /// <summary>�\�P�b�g�ʐM�@�����敪 ������ꗗ�擾</summary>
        public const Int32 SCKSYRKBN_GET_HACLIST = 11;
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i�f�[�^�o�^(�݌Ɏd���@���ɍX�V)</summary>
        public const Int32 SCKSYRKBN_INS_NYU_SLIPINFO = 12;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �݌Ɏd��(UOE�ȊO)�@�`�[���擾</summary>
        public const Int32 SCKSYRKBN_GET_NOTUOE_SLIPINFO = 13;
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i�f�[�^�o�^(�݌Ɏd���@UOE�ȊO)</summary>
        public const Int32 SCKSYRKBN_INS_NOTUOE_SLIPINFO = 14;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �݌Ɏd��(����/�o��)�@�`�[���擾</summary>
        public const Int32 SCKSYRKBN_GET_NYUSYU_SLIPINFO = 15;
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i�f�[�^�o�^(�݌Ɏd���@����/�o��)</summary>
        public const Int32 SCKSYRKBN_INS_NYUSYU_SLIPINFO = 16;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �݌Ɉړ�(�o��/����)�@�`�[���擾</summary>
        public const Int32 SCKSYRKBN_GET_IDO_SLIPINFO = 17;
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i�f�[�^�o�^(�݌Ɉړ��@�o��/����)</summary>
        public const Int32 SCKSYRKBN_INS_IDO_SLIPINFO = 18;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �q�ɏ��擾</summary>
        public const Int32 SCKSYRKBN_GET_SOKO_INFO = 19;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �ϑ��݌ɕ�[�@�`�[���擾</summary>
        public const Int32 SCKSYRKBN_GET_ITAKU_SLIPINFO = 20;
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i�f�[�^�o�^(�ϑ��݌ɕ�[)</summary>
        public const Int32 SCKSYRKBN_INS_ITAKU_SLIPINFO = 21;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �I��(���)��񑶍݊m�F</summary>
        public const Int32 SCKSYRKBN_GET_TANA_ISSEICHECK = 22;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �I��(���)���擾</summary>
        public const Int32 SCKSYRKBN_GET_TANA_ISSEIINFO = 23;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �I���f�[�^�o�^(���)</summary>
        public const Int32 SCKSYRKBN_INS_TANA_ISSEIINFO = 24;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �I��(�z��)��񑶍݊m�F</summary>
        public const Int32 SCKSYRKBN_GET_TANA_JYUNCHECK = 25;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �I��(�z��)���擾</summary>
        public const Int32 SCKSYRKBN_GET_TANA_JYUNINFO = 26;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �I���f�[�^�o�^(�z��)</summary>
        public const Int32 SCKSYRKBN_INS_TANA_JYUNINFO = 27;
        // -- ADD 2017/08/01 ------------------------------<<<
        // -- ADD 2019/10/16 ------------------------------>>>
        /// <summary>�\�P�b�g�ʐM�@�����敪 �q�Ƀ��X�g�擾</summary>
        public const Int32 SCKSYRKBN_GET_SOKO_LIST = 28;
        // -- ADD 2019/10/16 ------------------------------<<<
        // -- ADD 2020/04/01 ------------------------------>>>
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i�݌ɓo�^�����i�p�^�[�������j</summary>
        public const Int32 SCKSYRKBN_GET_INS_ZAIKOINFO_PATURN = 29;
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i�݌ɓo�^�����i�i�Ԍ����j</summary>
        public const Int32 SCKSYRKBN_GET_INS_ZAIKOINFO_GOODSNO = 30;
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i�݌ɓo�^�m��</summary>
        public const Int32 SCKSYRKBN_INS_ZAIKO_INSERT = 31;
        /// <summary>�\�P�b�g�ʐM�@�����敪 UOE�����f�[�^���݃`�F�b�N</summary>
        public const Int32 SCKSYRKBN_CHK_UOE_ORDER = 32;
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���[�J�[�ꗗ�擾</summary>
        public const Int32 SCKSYRKBN_GET_MAKER_LIST = 33;
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���[�J�[���擾</summary>
        public const Int32 SCKSYRKBN_GET_MAKER_INFO = 34;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �d����ꗗ�擾</summary>
        public const Int32 SCKSYRKBN_GET_SUPPLIER_LIST = 35;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �d������擾</summary>
        public const Int32 SCKSYRKBN_GET_SUPPLIER_INFO = 36;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �q�ɏ��擾</summary>
        public const Int32 SCKSYRKBN_GET_SOKO_INFO_FOR_STOCK = 37;
        // -- ADD 2020/04/01 ------------------------------<<<

        /// <summary>�\�P�b�g�ʐM�@�����敪 ���O�C�����擾</summary>
        public const string STRING_GET_LOGININFO = "���O�C�����擾";
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i���擾</summary>
        public const string STRING_GET_SYOHININFO = "���i���擾";
        /// <summary>�\�P�b�g�ʐM�@�����敪 �`�[���擾 �`�[���i</summary>
        public const string STRING_GET_SLIPINFO_MDDENPYOU = "�`�[���擾(�`�[���i)";
        /// <summary>�\�P�b�g�ʐM�@�����敪 �`�[���擾 �ꊇ���i</summary>
        public const string STRING_GET_SLIPINFO_MDIKKATSU = "�`�[���擾(�ꊇ���i)";
        /// <summary>�\�P�b�g�ʐM�@�����敪 �݌ɏ��擾</summary>
        public const string STRING_GET_ZAIKOINFO = "�݌ɏ��擾";
        /// <summary>�\�P�b�g�ʐM�@�����敪 �`�[���X�V</summary>
        public const string STRING_INS_SLIPINFO = "�`�[���X�V";
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i���X�V�i�o�[�R�[�h�j</summary>
        public const string STRING_INS_SYOHININFO_BARCODE = "���i���X�V�i�o�[�R�[�h�j";
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i���X�V�i���ʁj</summary>
        public const string STRING_INS_SYOHININFO_SU = "���i���X�V�i���ʁj";

        // -- ADD 2017/08/01 ------------------------------>>>
        /// <summary>�\�P�b�g�ʐM�@�����敪 �݌Ɏd��(���ɍX�V)�@�`�[�ꗗ�擾</summary>
        public const string STRING_GET_NYU_SLIPLIST = "�݌Ɏd��(���ɍX�V)�@�`�[�ꗗ�擾";
        /// <summary>�\�P�b�g�ʐM�@�����敪 �݌Ɏd��(���ɍX�V)�@�`�[���擾</summary>
        public const string STRING_GET_NYU_SLIPINFO = "�݌Ɏd��(���ɍX�V)�@�`�[���擾";
        /// <summary>�\�P�b�g�ʐM�@�����敪 ������ꗗ�擾</summary>
        public const string STRING_GET_HACLIST = "������ꗗ�擾";
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i�f�[�^�o�^(�݌Ɏd���@���ɍX�V)</summary>
        public const string STRING_INS_NYU_SLIPINFO = "���i�f�[�^�o�^(�݌Ɏd���@���ɍX�V)";
        /// <summary>�\�P�b�g�ʐM�@�����敪 �݌Ɏd��(UOE�ȊO)�@�`�[���擾</summary>
        public const string STRING_GET_NOTUOE_SLIPINFO = "�݌Ɏd��(UOE�ȊO)�@�`�[���擾";
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i�f�[�^�o�^(�݌Ɏd���@UOE�ȊO)</summary>
        public const string STRING_INS_NOTUOE_SLIPINFO = "���i�f�[�^�o�^(�݌Ɏd���@UOE�ȊO)";
        /// <summary>�\�P�b�g�ʐM�@�����敪 �݌Ɏd��(����/�o��)�@�`�[���擾</summary>
        public const string STRING_GET_NYUSYU_SLIPINFO = "�݌Ɏd��(����/�o��)�@�`�[���擾";
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i�f�[�^�o�^(�݌Ɏd���@����/�o��)</summary>
        public const string STRING_INS_NYUSYU_SLIPINFO = "���i�f�[�^�o�^(�݌Ɏd���@����/�o��)";
        /// <summary>�\�P�b�g�ʐM�@�����敪 �݌Ɉړ�(�o��/����)�@�`�[���擾</summary>
        public const string STRING_GET_IDO_SLIPINFO = "�݌Ɉړ�(�o��/����)�@�`�[���擾";
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i�f�[�^�o�^(�݌Ɉړ��@�o��/����)</summary>
        public const string STRING_INS_IDO_SLIPINFO = "���i�f�[�^�o�^(�݌Ɉړ��@�o��/����)";
        /// <summary>�\�P�b�g�ʐM�@�����敪 �q�ɏ��擾</summary>
        public const string STRING_GET_SOKO_INFO = "�q�ɏ��擾";
        /// <summary>�\�P�b�g�ʐM�@�����敪 �ϑ��݌ɕ�[�@�`�[���擾</summary>
        public const string STRING_GET_ITAKU_SLIPINFO = "�ϑ��݌ɕ�[�@�`�[���擾";
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i�f�[�^�o�^(�ϑ��݌ɕ�[)</summary>
        public const string STRING_INS_ITAKU_SLIPINFO = "���i�f�[�^�o�^(�ϑ��݌ɕ�[)";
        /// <summary>�\�P�b�g�ʐM�@�����敪 �I��(���)��񑶍݊m�F</summary>
        public const string STRING_GET_TANA_ISSEICHECK = "�I��(���)��񑶍݊m�F";
        /// <summary>�\�P�b�g�ʐM�@�����敪 �I��(���)���擾</summary>
        public const string STRING_GET_TANA_ISSEIINFO = "�I��(���)���擾";
        /// <summary>�\�P�b�g�ʐM�@�����敪 �I���f�[�^�o�^(���)</summary>
        public const string STRING_INS_TANA_ISSEIINFO = "�I���f�[�^�o�^(���)";
        /// <summary>�\�P�b�g�ʐM�@�����敪 �I��(�z��)��񑶍݊m�F</summary>
        public const string STRING_GET_TANA_JYUNCHECK = "�I��(�z��)��񑶍݊m�F";
        /// <summary>�\�P�b�g�ʐM�@�����敪 �I��(�z��)���擾</summary>
        public const string STRING_GET_TANA_JYUNINFO = "�I��(�z��)���擾";
        /// <summary>�\�P�b�g�ʐM�@�����敪 �I���f�[�^�o�^(�z��)</summary>
        public const string STRING_INS_TANA_JYUNINFO = "�I���f�[�^�o�^(�z��)";
        // -- ADD 2017/08/01 ------------------------------<<<
        // -- ADD 2019/11/14 ------------------------------>>>
        /// <summary>�\�P�b�g�ʐM�@�����敪 �q�Ƀ��X�g�擾</summary>
        public const string STRING_GET_SOKO_LIST = "�q�Ƀ��X�g�擾";
        // -- ADD 2019/11/14 ------------------------------<<<
        // -- ADD 2020/04/01 ------------------------------>>>
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i�݌ɓo�^����(�p�^�[������)</summary>
        public const string STRING_GET_INS_ZAIKOINFO_PATURN = "���i�݌ɓo�^����(�p�^�[������)";
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i�݌ɓo�^����(�i�Ԍ���)</summary>
        public const string STRING_GET_INS_ZAIKOINFO_GOODSNO = "���i�݌ɓo�^����(�i�Ԍ���)";
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���i�݌ɓo�^�m��</summary>
        public const string STRING_INS_ZAIKO_INSERT = "���i�݌ɓo�^�m��";
        /// <summary>�\�P�b�g�ʐM�@�����敪 UOE�����f�[�^���݃`�F�b�N</summary>
        public const string STRING_CHK_UOE_ORDER = "UOE�����f�[�^���݃`�F�b�N";
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���[�J�[�ꗗ�擾</summary>
        public const string STRING_GET_MAKER_LIST = "���[�J�[�ꗗ�擾";
        /// <summary>�\�P�b�g�ʐM�@�����敪 ���[�J�[���擾</summary>
        public const string STRING_GET_MAKER_INFO = "���[�J�[���擾";
        /// <summary>�\�P�b�g�ʐM�@�����敪 �d����ꗗ�擾</summary>
        public const string STRING_GET_SUPPLIER_LIST = "�d����ꗗ�擾";
        /// <summary>�\�P�b�g�ʐM�@�����敪 �d������擾</summary>
        public const string STRING_GET_SUPPLIER_INFO = "�d������擾";
        // -- ADD 2020/04/01 ------------------------------<<<

        // --- ADD 2019/06/13 ---------->>>>>
        /// <summary>�\�P�b�g�ʐM�@�����敪 �t�@�C���]��</summary>
        public const Int32 SCKSYRKBN_FILE_TRANSFER = 99;
        /// <summary>�\�P�b�g�ʐM�@�����敪 �t�@�C���]��</summary>
        public const string STRING_FILE_TRANSFER = "�t�@�C���]��";
        // --- ADD 2019/06/13 ----------<<<<<

        /// <summary>
        /// �w�肵�����O���x������̂��̂��o�͂����B
        /// ���Ƃ��΁A���O���x���� Warn���w�肵���ꍇ�A
        /// Warn�ȏ�̃��O�̂݁iWarn, Error, Fatal��3��ށj�o�͂���B
        /// </summary>
        public enum enumLOG4_KBN
        {
            /// <summary>���O���x��1�@�V�X�e�����~����悤�Ȓv���I�ȃG���[</summary>
            FATAL = 1,
            /// <summary>���O���x��2�@�V�X�e����~�܂ł����Ȃ����A���ƂȂ�G���[</summary>
            ERROR = 2,
            /// <summary>���O���x��3�@���ӂ�x��</summary>
            WARN = 3,
            /// <summary>���O���x��4�@���샍�O���</summary>
            INFO = 4,
            /// <summary>���O���x��5�@�J���p�f�o�b�O���</summary>
            DEBUG = 5
        }

        // -- UPD 2019/10/16 ------------------------------>>>
        public enum enumStatus
        {
            Nomal    = 0
          , NotFound = 4
          , Timeout  = 5
          , Error    = -1
        }
        // -- UPD 2019/10/16 ------------------------------<<<

    }
}
