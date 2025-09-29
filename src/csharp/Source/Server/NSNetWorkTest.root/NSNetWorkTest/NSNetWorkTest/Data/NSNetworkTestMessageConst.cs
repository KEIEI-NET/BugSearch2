using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.NSNetworkTest.Data
{
    /// <summary>
    /// ���b�Z�[�W�萔�Ǘ��N���X
    /// </summary>
    /// <remarks> 
    /// <br>Note			:	</br>
    /// <br>Programer		:	���@�k��</br>                            
    /// <br>Date			:	2007.10.31</br>                              
    /// <br>Update Note		:	</br>                
    /// </remarks>
    public class NSNetworkTestMsgConst
    {
        #region �f�[�^�O���b�h�r���[�֌W
        /// <summary>�v���L�V�T�[�o�[�̑��݊m�F</summary>
        public const string TEST_PROXY_SERVER = "�v���L�V�T�[�o�[�̊m�F";
        /// <summary>WEB�T�[�o�[�ւ̒ʐM�e�X�g</summary>
        public const string TEST_WEB_SERVER = "WEB�T�[�o�[�ւ̒ʐM�m�F";
        /// <summary>�A�v���P�[�V�����T�[�o�[�ւ̒ʐM�e�X�g</summary>
        public const string TEST_AP_SERVER = "�A�v���P�[�V�����T�[�o�[�ւ̒ʐM�m�F";
        /// <summary>�A�v���P�[�V�����z�M�e�X�g</summary>
        public const string TEST_DELIVERY_SERVER = "�A�v���P�[�V�����z�M�m�F";
        /// <summary>���m�F</summary>
        public const string TEST_RESULT_NONE = "������";

        /// <summary>�񖼉p��FITEM(����)</summary>
        public const string TEST_COLUMN_ITEM = "ITEM";
        /// <summary>�񖼘a���F����(ITEM)</summary>
        public const string TEST_COLUMN_ITEMNAME = "����";

        /// <summary>�񖼉p��FRESULT(����)</summary>
        public const string TEST_COLUMN_RESULT = "RESULT";
        /// <summary>�񖼘a���F����(RESULT)</summary>
        public const string TEST_COLUMN_RESULTNAME = "����";
        
        #endregion

        #region ���b�Z�[�W�{�b�N�X
        /// <summary>���b�Z�[�W�F�m�F</summary>
        public const string MSG_TITLE_CONFIRMATION = "�m�F";
        /// <summary>���b�Z�[�W�F���</summary>
        public const string MSG_TITLE_INFORMATION = "���";
        /// <summary>���b�Z�[�W�F�x��</summary>
        public const string MSG_TITLE_WARNING = "�x��";
        /// <summary>���b�Z�[�W�F�G���[</summary>
        public const string MSG_TITLE_ERROR = "�G���[";
        /// <summary>���b�Z�[�W�F�o�[�W����</summary>
        public const string MSG_TITLE_VERSION = "�o�[�W����";

        /// <summary>���b�Z�[�W�F�{���ɏI�����܂����H</summary>
        public const string MSG_ENDCHECK = "�{���ɏI�����܂����H";
        /// <summary>���b�Z�[�W�F�e�X�g���ʂ�����܂���B�e�X�g�����s���Ă�������</summary>
        public const string MSG_TESTDATANOTFOUND = "�e�X�g���ʂ�����܂���B\r\n�e�X�g�����s���Ă��������B";
        
        /// <summary>���b�Z�[�W�F�X�e�X�g���ʂ̕ۑ����s���܂����H</summary>
        public const string MSG_RESULTDATASAVE_CHECK = "�e�X�g���ʂ̕ۑ����s���܂����H";
        /// <summary>���b�Z�[�W�F����Ƀe�X�g���ʂ�ۑ��ł��܂���</summary>
        public const string MSG_RESULTDATASAVE_OK = "����Ƀe�X�g���ʂ�ۑ��ł��܂����B";
        /// <summary>���b�Z�[�W�F�e�X�g���ʕۑ������ɂăG���[���������܂����B</summary>
        public const string MSG_RESULTDATASAVE_NG = "�e�X�g���ʕۑ������ɂăG���[���������܂����B";


         /// <summary>���b�Z�[�W�F�w���v�̃v���L�V�ݒ���m�F���Ă��������B</summary>
        //public const string MSG_RESULTPROXYCHECK_NG = "NG�F�w���v�̃v���L�V�ݒ���m�F���Ă��������B";
        public const string MSG_RESULTPROXYCHECK_NG = "NG�F�v���L�V�ݒ���m�F���Ă��������B";
        /// <summary>���b�Z�[�W�F�w���v�̃l�b�g���[�N�ݒ���m�F���Ă��������B</summary>
        //public const string MSG_RESULTNETWORK_NG = "NG�F�w���v�̃l�b�g���[�N�ݒ���m�F���Ă��������B";
        public const string MSG_RESULTNETWORK_NG = "NG�F�l�b�g���[�N�ݒ���m�F���Ă��������B";
        
        /// <summary>���b�Z�[�W�FNG�F�A�v���P�[�V�����T�[�o�[�ւ̒ʐM�m�F�����Ă��������B</summary>
        public const string MSG_RESULTAP_NG = "NG�F�A�v���P�[�V�����T�[�o�[�ւ̒ʐM�m�F�����Ă��������B";
        /// <summary>���b�Z�[�W�FNG�FWEB�T�[�o�[�ւ̒ʐM�m�F�����Ă��������B</summary>
        public const string MSG_RESULTWEB_NG = "NG�FWEB�T�[�o�[�ւ̒ʐM�m�F�����Ă��������B";
        /// <summary>���b�Z�[�W�FNG�F�A�v���P�[�V�����z�M�m�F�����Ă��������B</summary>
        public const string MSG_RESULTBITS_NG = "NG�F�A�v���P�[�V�����z�M�m�F�����Ă��������B";
        /// <summary>���b�Z�[�W�FNG�F�v���L�V�T�[�o�[�̊m�F�����Ă��������B</summary>
        public const string MSG_RESULTPROXY_NG = "NG�F�v���L�V�T�[�o�[�̊m�F�����Ă��������B";


        /// <summary>���b�Z�[�W�F�ݒ�t�@�C���擾���ɃG���[���������܂����B</summary>
        public const string MSG_CONFIGLOAD_NG = "�ݒ�t�@�C���擾���ɃG���[���������܂����B";
        /// <summary>���b�Z�[�W�F�ݒ�t�@�C���X�V���ɃG���[���������܂����B</summary>
        public const string MSG_CONFIGSAVE_NG = "�ݒ�t�@�C���X�V���ɃG���[���������܂����B";

        /// <summary>���b�Z�[�W�F�A�����s�͋�����Ă���܂���B</summary>
        public const string MSG_CONTINUOSEXECTION_NG = "�A�����s�͋�����Ă���܂���B";

        /// <summary>���b�Z�[�W�F�����𒆎~���܂����H</summary>
        public const string MSG_IS_PROCESSINGDISCONTINUED = "�����𒆎~���܂����H";
        /// <summary>���b�Z�[�W�F�l�b�g���[�N�ʐM�e�X�g���͍s�Ȃ��܂���B</summary>
        public const string MSG_EXECUTING_LOADSAVE_NG = "�l�b�g���[�N�ʐM�e�X�g���͍s�Ȃ��܂���B";
        /// <summary>���b�Z�[�W�F���s�����ʐM�e�X�g������܂����B\r\n�G���[���e��\�����܂����H</summary>
        public const string MSG_RESULTNGSHOW_NG = "���s�����ʐM�e�X�g������܂����B\r\n�G���[���e��\�����܂����H";
        /// <summary>���b�Z�[�W�F���������~����܂����B�A�v���P�[�V�������I�����܂��B</summary>
        public const string MSG_EXECUTINGSOPAPPCLOSE_NG = "���������~����܂����B�A�v���P�[�V�������I�����܂��B";
        /// <summary>���b�Z�[�W�F�S�Ẵe�X�g������ɏI�����܂����B</summary>
        public const string MSG_RESULTOK_OK = "�S�Ẵe�X�g������ɏI�����܂����B";
        /// <summary>���b�Z�[�W�F�e�X�g�ݒ�t�@�C�������݂��܂���</summary>
        public const string MSG_EXISTENCE_NG = "�ݒ�t�@�C�������݂��܂���";
        /// <summary>���b�Z�[�W�F�e�X�g���i��I�����Ă�������</summary>
        public const string MSG_SELECT_NG = "���i��I�����Ă�������";
        /// <summary>���b�Z�[�W�Fapp.config�t�@�C�����m�F���Ă�������</summary>
        public const string MSG_CONFIG_NG = "app.config�t�@�C�����m�F���Ă�������";
            
        #endregion

        /// <summary>���b�Z�[�W�FOK</summary>
        public const string MSG_OK = "OK";
        /// <summary>���b�Z�[�W�FNG</summary>
        public const string MSG_NG = "NG";
    }
}
