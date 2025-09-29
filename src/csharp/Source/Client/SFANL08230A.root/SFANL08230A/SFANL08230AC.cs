using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���R���[�󎚈ʒuDL�萔��`�N���X
    /// </summary>
    public class SFANL08230AC
    {
        #region Public Const
        // �e�[�u������
        /// <summary>�󎚈ʒu�i���[�U�[�j�e�[�u��</summary>
        public const string TABLE_USER = "TABEL_USER";
        /// <summary>�󎚈ʒu�i�񋟁j�e�[�u��</summary>
        public const string TABLE_OFFER = "TABLE_OFFER";

        // �J��������
        /// <summary>�㏑���I���t���O</summary>
        public const string COL_USER_SELECT_UPDATE = "SELECT_UPDATE_USER";
        /// <summary>�����t���O</summary>
        public const string COL_USER_EXISTFLG = "EXISTFLG_USER";
        /// <summary>�X�V�t���O</summary>
        public const string COL_USER_UPDATEFLG = "UPDATEFLG_USER";
        /// <summary>���</summary>
        public const string COL_USER_STATUS = "STATUS_USER";
        /// <summary>�L�[</summary>
        public const string COL_USER_KEY = "KEY_USER";
        /// <summary>�o�̓t�@�C����</summary>
        public const string COL_USER_OUTPUTFORMFILENAME = "OUTPUTFORMFILENAME_USER";
        /// <summary>�o�͖���</summary>
        public const string COL_USER_DISPLAYNAME = "DISPLAYNAME_USER";
        /// <summary>���[�U�[���[ID�}�ԍ�</summary>
        public const string COL_USER_USERPRTPPRIDDERIVNO = "USERPRTPPRIDDERIVNO_USER";
        /// <summary>���[���[�U�[�}�ԃR�����g</summary>
        public const string COL_USER_PRTPPRUSERDERIVNOCMT = "PRTPPRUSERDERIVNOCMT_USER";
        /// <summary>�󎚍��ڃO���[�v�R�[�h</summary>
        public const string COL_USER_FREEPRTPPRITEMGRPCD = "FREEPRTPPRITEMGRPCD_USER";
        /// <summary>�T�[�o�[�X�V����</summary>
        public const string COL_USER_UPDATETIME = "UPDATETIME_USER";
        /// <summary>�V�X�e���敪</summary>
        public const string COL_USER_SYSTEMDIVCD = "SYSTEMDIVCD_USER";
        /// <summary>�V�X�e���敪����</summary>
        public const string COL_USER_SYSTEMDIVNAME = "SYSTEMDIVNAME_USER";
        /// <summary>�I�v�V�����R�[�h</summary>
        public const string COL_USER_OPTIONCODE = "OPTIONCODE_USER";
        /// <summary>�I�v�V��������</summary>
        public const string COL_USER_OPTIONNAME = "OPTIONNAME_USER";
        /// <summary>���[�g�p�敪�R�[�h</summary>
        public const string COL_USER_PRINTPAPERUSEDIVCD = "PRINTPAPERUSEDIVCD_USER";
        /// <summary>���[�g�p�敪����</summary>
        public const string COL_USER_PRINTPAPERUSEDIVCDNM = "PRINTPAPERUSEDIVCDNM_USER";

        ///// <summary>No.�i�O���b�h�\���p�j</summary>
        /// <summary>�I���t���O</summary>
        public const string COL_OFFER_SELECT = "SELECT_OFFER";
        /// <summary>�L�[</summary>
        public const string COL_OFFER_KEY = "KEY_OFFER";
        /// <summary>�o�̓t�@�C����</summary>
        public const string COL_OFFER_OUTPUTFORMFILENAME = "OUTPUTFORMFILENAME_OFFER";
        /// <summary>�o�͖���</summary>
        public const string COL_OFFER_DISPLAYNAME = "DISPLAYNAME_OFFER";
        /// <summary>���[�U�[���[ID�}�ԍ�</summary>
        public const string COL_OFFER_USERPRTPPRIDDERIVNO = "USERPRTPPRIDDERIVNO_OFFER";
        /// <summary>���[���[�U�[�}�ԃR�����g</summary>
        public const string COL_OFFER_PRTPPRUSERDERIVNOCMT = "PRTPPRUSERDERIVNOCMT_OFFER";
        /// <summary>�󎚍��ڃO���[�v</summary>
        public const string COL_OFFER_FREEPRTPPRITEMGRPCD = "FREEPRTPPRITEMGRPCD_OFFER";
        /// <summary>�T�[�o�[�X�V����(�\���p)</summary>
        public const string COL_OFFER_UPDATETIMESTR = "UPDATETIMESTR_OFFER";
        /// <summary>�T�[�o�[�X�V����</summary>
        public const string COL_OFFER_UPDATETIME = "UPDATETIME_OFFER";
        /// <summary>�V�X�e���敪</summary>
        public const string COL_OFFER_SYSTEMDIVCD = "SYSTEMDIVCD_OFFER";
        /// <summary>�V�X�e���敪����</summary>
        public const string COL_OFFER_SYSTEMDIVNAME = "SYSTEMDIVNAME_OFFER";
        /// <summary>�I�v�V�����R�[�h</summary>
        public const string COL_OFFER_OPTIONCODE = "OPTIONCODE_OFFER";
        /// <summary>�I�v�V��������</summary>
        public const string COL_OFFER_OPTIONNAME = "OPTIONNAME_OFFER";
        /// <summary>���_�E�����[�h</summary>
        public const string COL_OFFER_NO_DOWNLOAD = "NO_DOWNLOAD_OFFER";
        /// <summary>�V�o�[�W����</summary>
        public const string COL_OFFER_NEW_VERSION = "NEW_VERSION_OFFER";
        /// <summary>���[�g�p�敪�R�[�h</summary>
        public const string COL_OFFER_PRINTPAPERUSEDIVCD = "PRINTPAPERUSEDIVCD_OFFER";
        /// <summary>���[�g�p�敪����</summary>
        public const string COL_OFFER_PRINTPAPERUSEDIVCDNM = "PRINTPAPERUSEDIVCDNM_OFFER";
        /// <summary>�捞�摜�R�[�h</summary>
        public const string COL_OFFER_TAKEINIMAGEGROUPCD = "TAKEINIMAGEGROUPCD_OFFER";


        /// <summary>�X�V�t���O(�Ȃ�)</summary>
        public const int UPDATEFLG_NONE = 0;
        /// <summary>�X�V�t���O(�㏑���X�V)</summary>
        public const int UPDATEFLG_UPDATE = 1;
        # endregion
    }
}
