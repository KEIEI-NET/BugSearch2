//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����Y�ƕi�ԕϊ��ꊇ����
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : �i�N
// �� �� ��  2015/01/26   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : �c����
// �� �� ��  2015/02/25   �C�����e : Redmine#44209 �t�@�C�������̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : ���V��
// �� �� ��  2015/02/26   �C�����e : Redmine#44209 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : �i�N
// �� �� ��  2015/02/27   �C�����e : Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : ���V��
// �� �� ��  2015/03/02   �C�����e : Redmine#44209 �O�u�d�l�ύX�v�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11003519-00  �쐬�S�� : ���V��
// �� �� ��  2015/03/16   �C�����e : Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
//----------------------------------------------------------------------------//

using System;
using System.Text;
using System.Data;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
//using Broadleaf.Application.UIData;  // DEL 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using System.Text.RegularExpressions;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �����Y�ƕi�ԕϊ��ꊇ���� �A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: �����Y�ƕi�ԕϊ��ꊇ�����Ŏg�p����f�[�^���擾����B</br>
    /// <br>Programmer	: �i�N</br>
    /// <br>Date		: 2015/01/26</br>
    /// <br>UpdateNote  : 2015/02/25 �c���� </br>
    /// <br>            : Redmine#44209 �t�@�C�������̑Ή�</br>
    /// </remarks>
    public class MeijiGoodsChgAllAcs
    {
        #region �� Constructor
        /// <summary>
        /// �i�ԕϊ��ꊇ�����A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �i�ԕϊ��ꊇ�����A�N�Z�X�N���X�̏��������s���B</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        public MeijiGoodsChgAllAcs()
        {
            this._iMeijiGoodsChgAllDB = (IMeijiGoodsChgAllDB)MediationMeijiGoodsChgAllDB.GetMeijiGoodsChgAllDB();
            this._iofferPrimeSettingSearchDB = (IPrimeSettingDB)MediationPrimeSettingDB.GetPrimeSettingDB(); // ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
        }
        #endregion �� Constructor

        #region �� Private Member
        // ���[�J�[�R�[�h���X�g     
        private IMeijiGoodsChgAllDB _iMeijiGoodsChgAllDB;

        private IPrimeSettingDB _iofferPrimeSettingSearchDB; // ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
        #endregion �� Private Member

        #region �� Const Memebers
        private const int GOODSNOCHGSUCMODE = 0;
        private const int GOODSNOCHGERRMODE = 1;
        private const int GOODSMSTMODE = 2;
        private const int PRICEMSTMODE = 3;
        private const int STOCKMSTMODE = 4;
        private const int GOODSMNGMSTMODE = 5;
        private const int RATEMSTMODE = 6;
        private const int JOINMSTMODE = 7;
        private const int PARTSMSTMODE = 8;
        private const int GOODSSETMSTMODE = 9;
        private const int SHIPMENTERRMODE = 10;
        private const int SHIPMENTSUCMODE = 11;
        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
        private const int PRMUPDATEERRMODE = 12;
        private const int PRMSUCMODE = 13;
        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<

        private const int LOGKINGSUC = 0;
        private const int LOGKINGERR = 1;

        //----- DEL 2015/02/26 ���V�� Redmine#44209 �t�@�C�����̒�`�����ʉ��Ή�----->>>>>
        ////----- ADD 2015/02/25 �c���� Redmine#44209 ----->>>>>
        //private const string ct_GOODS_ERROR = "(�G���[)���i�}�X�^���O.csv";
        //private const string ct_GOODS_LOG = "(�ϊ��ς�)���i�}�X�^���O.csv";
        //private const string ct_GOODSPRICE_ERROR = "(�G���[)���i�}�X�^���O.csv";
        //private const string ct_GOODSPRICE_LOG = "(�ϊ��ς�)���i�}�X�^���O.csv";
        //private const string ct_STOCK_ERROR = "(�G���[)�݌Ƀ}�X�^���O.csv";
        //private const string ct_STOCK_LOG = "(�ϊ��ς�)�݌Ƀ}�X�^���O.csv";
        //private const string ct_GOODSMNG_ERROR = "(�G���[)���i�Ǘ����}�X�^���O.csv";
        //private const string ct_GOODSMNG_LOG = "(�ϊ��ς�)���i�Ǘ����}�X�^���O.csv";
        //private const string ct_RATE_ERROR = "(�G���[)�|���}�X�^���O.csv";
        //private const string ct_RATE_LOG = "(�ϊ��ς�)�|���}�X�^���O.csv";
        //private const string ct_JOINPARTS_ERROR = "(�G���[)�����}�X�^���O.csv";
        //private const string ct_JOINPARTS_LOG = "(�ϊ��ς�)�����}�X�^���O.csv";
        //private const string ct_SUBST_ERROR = "(�G���[)��փ}�X�^���O.csv";
        //private const string ct_SUBST_LOG = "(�ϊ��ς�)��փ}�X�^���O.csv";
        //private const string ct_GOODSSET_ERROR = "(�G���[)�Z�b�g�}�X�^���O.csv";
        //private const string ct_GOODSSET_LOG = "(�ϊ��ς�)�Z�b�g�}�X�^���O.csv";
        //private const string ct_RENTDATA_ERROR = "(�G���[)���v��ݏo�f�[�^���O.csv";
        //private const string ct_RENTDATA_LOG = "(�ϊ��ς�)���v��ݏo�f�[�^���O.csv";
        //private const string ct_CROSS_INDEX_GOODSCHG_ERROR = "(�G���[)�i�ԕϊ��}�X�^���O.csv";
        //private const string ct_CROSS_INDEX_GOODSCHG_LOG = "(�ϊ��ς�)�i�ԕϊ��}�X�^���O.csv";
        ////----- ADD 2015/02/25 �c���� Redmine#44209 -----<<<<<
        //----- DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C�����̒�`�����ʉ��Ή�-----<<<<<

        //----- ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C�����̒�`�����ʉ��Ή�----->>>>>
        #region �t�@�C����
        //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
        ///// <summary>
        ///// ���i�}�X�^�G���[���O
        ///// </summary>
        //public string ct_GOODS_ERROR = "(�G���[)���i�}�X�^���O.csv";
        ///// <summary>
        ///// ���i�}�X�^�G���[���O
        ///// </summary>
        //public string ct_GOODSPRICE_ERROR = "(�G���[)���i�}�X�^���O.csv";
        ///// <summary>
        ///// �݌Ƀ}�X�^�G���[���O
        ///// </summary>
        //public string ct_STOCK_ERROR = "(�G���[)�݌Ƀ}�X�^���O.csv";
        //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
        //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
        /// <summary>
        /// ���i�݌Ƀ}�X�^�G���[���O
        /// </summary>
        public string ct_GOODSSTOCK_ERROR = "(�G���[)���i�݌Ƀ}�X�^���O.csv";
        //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
        /// <summary>
        /// ���i�Ǘ����}�X�^�G���[���O
        /// </summary>
        public string ct_GOODSMNG_ERROR = "(�G���[)���i�Ǘ����}�X�^���O.csv";
        /// <summary>
        /// �|���}�X�^�G���[���O
        /// </summary>
        public string ct_RATE_ERROR = "(�G���[)�|���}�X�^���O.csv";
        /// <summary>
        /// �����}�X�^�G���[���O
        /// </summary>
        public string ct_JOINPARTS_ERROR = "(�G���[)�����}�X�^���O.csv";
        /// <summary>
        /// ��փ}�X�^�G���[���O
        /// </summary>
        public string ct_SUBST_ERROR = "(�G���[)��փ}�X�^���O.csv";
        /// <summary>
        /// �Z�b�g�}�X�^�G���[���O
        /// </summary>
        public string ct_GOODSSET_ERROR = "(�G���[)�Z�b�g�}�X�^���O.csv";
        /// <summary>
        /// ���v��ݏo�f�[�^�G���[���O
        /// </summary>
        public string ct_RENTDATA_ERROR = "(�G���[)���v��ݏo�f�[�^���O.csv";
        /// <summary>
        /// �i�ԕϊ��}�X�^�G���[���O
        /// </summary>
        public string ct_CROSS_INDEX_GOODSCHG_ERROR = "(�G���[)�i�ԕϊ��}�X�^���O.csv";
        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
        /// <summary>
        /// �D�ǐݒ�}�X�^�G���[���O
        /// </summary>
        public string ct_PRMSETTING_ERROR = "(�G���[)�D�ǐݒ�}�X�^���O.csv";
        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<
        //----- ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------>>>>>
        /// <summary>
        /// �D�ǐݒ�񋟕��擾��O�̏ꍇ
        /// </summary>
        public string ct_PRMOFFER_ERROR = "�񋟏��̎擾�Ɏ��s���܂����B";
        //----- ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------<<<<<

        //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
        //private const string ct_GOODS_LOG = "(�ϊ��ς�)���i�}�X�^���O.csv";
        //private const string ct_GOODSPRICE_LOG = "(�ϊ��ς�)���i�}�X�^���O.csv";
        //private const string ct_STOCK_LOG = "(�ϊ��ς�)�݌Ƀ}�X�^���O.csv";
        //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
        private const string ct_GOODSSTOCK_LOG = "(�ϊ��ς�)���i�݌Ƀ}�X�^���O.csv";// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
        private const string ct_GOODSMNG_LOG = "(�ϊ��ς�)���i�Ǘ����}�X�^���O.csv";
        private const string ct_RATE_LOG = "(�ϊ��ς�)�|���}�X�^���O.csv";
        private const string ct_JOINPARTS_LOG = "(�ϊ��ς�)�����}�X�^���O.csv";
        private const string ct_SUBST_LOG = "(�ϊ��ς�)��փ}�X�^���O.csv";
        private const string ct_GOODSSET_LOG = "(�ϊ��ς�)�Z�b�g�}�X�^���O.csv";
        private const string ct_RENTDATA_LOG = "(�ϊ��ς�)���v��ݏo�f�[�^���O.csv";
        private const string ct_CROSS_INDEX_GOODSCHG_LOG = "(�ϊ��ς�)�i�ԕϊ��}�X�^���O.csv";
        private const string ct_PRMSETTING_LOG = "(�ϊ��ς�)�D�ǐݒ�}�X�^���O.csv"; // ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�
        #endregion
        //----- ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C�����̒�`�����ʉ��Ή�-----<<<<<

        //----- ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�----->>>>>
        #region ���ږ�
        private const int SUCLOGMODE = 0; // �������[�h
        private const int ERRLOGMODE = 1; // ���s���[�h
        // Ͻ����
        private const string MSTDIV_COLUMN_NAME = "Ͻ����";
        // ���i�J�n��
        private const string PRICESTRDATE_COLUMN_NAME = "���i�J�n��";
        // �q�ɃR�[�h
        //private const string WARECODE_COLUMN_NAME = "�q�ɃR�[�h"; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string WARECODE_COLUMN_NAME = "�q��"; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // ���_�R�[�h
        //private const string SECTIONCODE_COLUMN_NAME = "���_�R�[�h"; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string SECTIONCODE_COLUMN_NAME = "���_"; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // �P���|���ݒ�敪
        //private const string UNITRATESETDIVCD_COLUMN_NAME = "�P���|���ݒ�敪";// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string UNITRATESETDIVCD_COLUMN_NAME = "�|���ݒ�敪";// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // �P�����
        private const string UNITPRICEKIND_COLUMN_NAME = "�P�����";
        // ���Ӑ�R�[�h
        //private const string CUSTOMERCODE_COLUMN_NAME = "���Ӑ�R�[�h"; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string CUSTOMERCODE_COLUMN_NAME = "���Ӑ�"; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // ���Ӑ�|���O���[�v�R�[�h
        //private const string CUSTRATEGRPCODE_COLUMN_NAME = "���Ӑ�|���O���[�v�R�[�h";// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string CUSTRATEGRPCODE_COLUMN_NAME = "���Ӑ�|��";// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // �d����R�[�h
        //private const string SUPPLIERCD_COLUMN_NAME = "�d����R�[�h"; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string SUPPLIERCD_COLUMN_NAME = "�d����"; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // ���b�g��
        //private const string LOTCOUNT_COLUMN_NAME = "���b�g��"; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string LOTCOUNT_COLUMN_NAME = "ۯ�"; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // ���������[�J�[�R�[�h		
        //private const string JOINSOURCEMAKERCODE_COLUMN_NAME = "���������[�J�[�R�[�h"; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string JOINSOURCEMAKERCODE_COLUMN_NAME = "������Ұ��"; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // �������i��(�|�t���i��)	
        //private const string JOINSOURPARTSNOWITHH_COLUMN_NAME = "�������i��(�|�t���i��)";// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string JOINSOURPARTSNOWITHH_COLUMN_NAME = "�������i��";// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // �����惁�[�J�[�R�[�h
        //private const string JOINDESTMAKERCD_COLUMN_NAME = "�����惁�[�J�[�R�[�h";// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string JOINDESTMAKERCD_COLUMN_NAME = "������Ұ��";// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // ������i��(�|�t���i��)
        //private const string JOINDESTPARTSNORF_COLUMN_NAME = "������i��(�|�t���i��)"; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string JOINDESTPARTSNORF_COLUMN_NAME = "������i��"; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // �ϊ��㌋�����i��(�|�t���i��)			
        //private const string NEWJOINSOURPARTSNOWITHH_COLUMN_NAME = "�ϊ��㌋�����i��(�|�t���i��)";// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string NEWJOINSOURPARTSNOWITHH_COLUMN_NAME = "�ϊ��㌋�����i��";// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // �ϊ��㌋����i��(�|�t���i��)
        //private const string NEWJOINDESTPARTSNORF_COLUMN_NAME = "�ϊ��㌋����i��(�|�t���i��)";// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string NEWJOINDESTPARTSNORF_COLUMN_NAME = "�ϊ��㌋����i��";// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // ��֌����[�J�[�R�[�h
        //private const string CHGSRCMAKERCD_COLUMN_NAME = "��֌����[�J�[�R�[�h";// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string CHGSRCMAKERCD_COLUMN_NAME = "��֌�Ұ��";// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // ��֌��i��
        private const string CHGSRCGOODSNO_COLUMN_NAME = "��֌��i��";
        // ��֐惁�[�J�[�R�[�h
        //private const string CHGDESTMAKERCD_COLUMN_NAME = "��֐惁�[�J�[�R�[�h"; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string CHGDESTMAKERCD_COLUMN_NAME = "��֐�Ұ��"; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // ��֐�i��
        private const string CHGDESTGOODSNO_COLUMN_NAME = "��֐�i��";
        // �ϊ����֌��i��
        private const string CHGSRCCHGGOODSNO_COLUMN_NAME = "�ϊ����֌��i��";
        // �ϊ����֐�i��
        private const string CHGDESTCHGGOODSNO_COLUMN_NAME = "�ϊ����֐�i��";
        // �e���[�J�[�R�[�h
        //private const string PARENTGOODSMAKERCD_COLUMN_NAME = "�e���[�J�[�R�[�h"; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string PARENTGOODSMAKERCD_COLUMN_NAME = "�eҰ��"; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // �e���i�ԍ�
        //private const string PARENTGOODSNO_COLUMN_NAME = "�e���i�ԍ�"; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string PARENTGOODSNO_COLUMN_NAME = "�e�i��"; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // �q���i���[�J�[�R�[�h
        //private const string SUBGOODSMAKERCD_COLUMN_NAME = "�q���i���[�J�[�R�[�h"; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string SUBGOODSMAKERCD_COLUMN_NAME = "�qҰ��"; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // �q���i�ԍ�
        //private const string SUBGOODSNO_COLUMN_NAME = "�q���i�ԍ�";// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string SUBGOODSNO_COLUMN_NAME = "�q�i��";// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // �ϊ���e�i��
        private const string AFCHGPARENTGOODSNO_COLUMN_NAME = "�ϊ���e�i��";
        // �ϊ���q�i��
        private const string AFCHGSUBGOODSNO_COLUMN_NAME = "�ϊ���q�i��";
        // ����`�[�ԍ�
        //private const string SALESSLIPNO_COLUMN_NAME = "����`�[�ԍ�"; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string SALESSLIPNO_COLUMN_NAME = "����`�["; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // ����s�ԍ�
        private const string ROWNO_COLUMN_NAME = "����s�ԍ�";
        // �󒍃X�e�[�^�X
        //private const string ACPTANORDRSTATUS_COLUMN_NAME = "�󒍃X�e�[�^�X";// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string ACPTANORDRSTATUS_COLUMN_NAME = "�󒍽ð��";// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // �����i�ԍ�
        //private const string OLDGOODSNO_COLUMN_NAME = "���i�ԍ�"; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string OLDGOODSNO_COLUMN_NAME = "�i��"; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // �V���i�ԍ�
        //private const string NEWGOODSNO_COLUMN_NAME = "�ϊ��㏤�i�ԍ�"; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string NEWGOODSNO_COLUMN_NAME = "�ϊ���i��"; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // ���i���[�J�[�R�[�h
        //private const string GOODSMAKERCD_COLUMN_NAME = "���i���[�J�[�R�[�h"; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string GOODSMAKERCD_COLUMN_NAME = "Ұ��"; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
        // ���i���[�J�[�R�[�h
        //private const string PARTSMAKERCD_COLUMN_NAME = "Ұ��"; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // ���i�����ރR�[�h
        private const string GOODSMGROUPCD_COLUMN_NAME = "������"; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        // BL�R�[�h
        private const string BLCODE_COLUMN_NAME = "BL����";
        // �D�ǐݒ�ڍ׃R�[�h1
        private const string PRMSETDTLNO1_COLUMN_NAME = "�ڸ�";
        // ���i��-�D�ǐݒ�ڍ׃R�[�h2
        private const string OLDPRMSETDTLNO2_COLUMN_NAME = "���i�Ԏ��";
        // �V�i��-�D�ǐݒ�ڍ׃R�[�h2
        private const string NEWPRMSETDTLNO2_COLUMN_NAME = "�V�i�Ԏ��";
        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<
        // �������O���b�Z�[�W
        private const string GOODSCHG_SUC_NAME = "���l";
        //�G���[���b�Z�[�W
        //private const string GOODSCHG_ERR_NAME = "�G���[���e"; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        private const string GOODSCHG_ERR_NAME = "�װ���e"; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O���e�̕ύX�̑Ή�
        #endregion
        //----- ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�-----<<<<<
        #endregion

        #region �� Public Method
        /// <summary>
        /// �f�[�^���o����
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note        : �e�L�X�g�o�̓f�[�^���擾����B</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// </remarks>
        //public int GoodsChange(GoodsChangeAllCndWorkWork cndtn, string path, out GoodsChangeResultWork goodsChangeResultWork) // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�
        public int GoodsChange(GoodsChangeAllCndWorkWork cndtn, string path, out GoodsChangeResultWork goodsChangeResultWork, out string newPath) // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�    
        {
            //return this.GoodsChangeProc(cndtn, path, out goodsChangeResultWork);// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�
            return this.GoodsChangeProc(cndtn, path, out goodsChangeResultWork, out newPath);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�
        }
        #endregion �� Public Method

        #region �� Private Method
        #region �� �f�[�^�擾
        /// <summary>
        /// �f�[�^�擾
        /// </summary>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note        : �e�L�X�g�o�̓f�[�^���擾����B</br>
        /// <br>Programmer  : �i�N</br>
        /// <br>Date        : 2015/01/26</br>
        /// <br>UpdateNote  : 2015/03/02 ���V�� </br>
        /// <br>            : Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�</br>
        /// </remarks>
        //private int GoodsChangeProc(GoodsChangeAllCndWorkWork cndtn, string path, out GoodsChangeResultWork goodsChangeResultWork)// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�
        private int GoodsChangeProc(GoodsChangeAllCndWorkWork cndtn, string orignalPath, out GoodsChangeResultWork goodsChangeResultWork, out string path)// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            goodsChangeResultWork = new GoodsChangeResultWork();
            path = "";

            try
            {
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�----->>>>>
                path = Path.Combine(@orignalPath, DateTime.Now.ToString("yyyyMMddHHmmss"));
                Directory.CreateDirectory(path);
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�o�͎���Trans_Log�t�H���_�z���ɓ��t�t�H���_���쐬����Ή�-----<<<<<
                #region �i�ԕϊ��}�X�^
                if (cndtn.GoodsChangeMstDiv == 1)
                {
                    status = ChgGoodsNoMst(ref goodsChangeResultWork, cndtn, path);
                }
                #endregion

                if (cndtn.GoodsChangeMstDiv == 1 && goodsChangeResultWork.ErrCntGoodsChgMst > 0)
                {
                    return status;
                }
                else
                {
                    #region ���i�݌Ƀ}�X�^
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && cndtn.GoodsMstDiv == 1)
                    {
                        status = ChgGoodsStockPrc(ref goodsChangeResultWork, cndtn, path);
                    }
                    #endregion

                    #region �Ǘ����}�X�^
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && cndtn.GoodsMngMstDiv == 1)
                    {
                        status = ChgGoodsMngPrc(ref goodsChangeResultWork, cndtn, path);
                    }
                    #endregion

                    #region �|���}�X�^
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && cndtn.RateMstDiv == 1)
                    {
                        status = ChgRatePrc(ref goodsChangeResultWork, cndtn, path);
                    }
                    #endregion

                    #region �����}�X�^
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && cndtn.JoinMstDiv == 1)
                    {
                        status = ChgJoinPrc(ref goodsChangeResultWork, cndtn, path);
                    }
                    #endregion

                    #region ��փ}�X�^
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && cndtn.PartsMstDiv == 1)
                    {
                        status = ChgPartsPrc(ref goodsChangeResultWork, cndtn, path);
                    }
                    #endregion

                    #region �Z�b�g�}�X�^
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && cndtn.SetMstDiv == 1)
                    {
                        status = ChgGoodsSetPrc(ref goodsChangeResultWork, cndtn, path);
                    }
                    #endregion

                    #region �ݏo�ϊ�����
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && cndtn.ShipmentDiv == 1)
                    {
                        status = ChgShipmentPrc(ref goodsChangeResultWork, cndtn, path);
                    }
                    #endregion

                    //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
                    #region �D�ǐݒ�}�X�^
                    if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL && cndtn.PrmMstDiv == 1)
                    {
                        status = ChgPrmSettingPrc(ref goodsChangeResultWork, cndtn, path);
                    }
                    #endregion
                    //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<
                }
            }
            catch (Exception ex)
            {
                string exMsg = ex.ToString();
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }
        #endregion

        #region CSV�o�͏���
        #region CSV�o�͏��ݒ�
        /// <summary>
        /// CSV�o�͏�񏈗�
        /// </summary>
        /// <param name="mode">�e�}�X�^�敪</param>
        /// <param name="dsOutData">DataSet</param>
        /// <param name="fileName">�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : �o�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/26 ���V�� </br>
        /// <br>           : Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�</br>
        /// <br>UpdateNote : 2015/03/02 ���V�� </br>
        /// <br>           : Redmine#44209 ���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�</br>
        /// </remarks>
        public FormattedTextWriter GetCSVInfo(int mode, DataSet dsOutData, string fileName)
        {
            List<string> schemeList = new List<string>();
            // �i�ԕϊ��}�X�^����
            if (mode == GOODSNOCHGSUCMODE)
            {
                schemeList.Add(OLDGOODSNO_COLUMN);
                schemeList.Add(NEWGOODSNO_COLUMN);
                schemeList.Add(GOODSMAKERCD_COLUMN);
            }
            // �i�ԕϊ��}�X�^���s
            else if (mode == GOODSNOCHGERRMODE)
            {
                schemeList.Add(OLDGOODSNO_COLUMN);
                schemeList.Add(NEWGOODSNO_COLUMN);
                schemeList.Add(GOODSMAKERCD_COLUMN);
                schemeList.Add(GOODS_ERROR);
            }
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
            //// ���i�}�X�^
            //else if (mode == GOODSMSTMODE)
            //{
            //    schemeList.Add(ct_Col_GoodsMakerCd1);
            //    schemeList.Add(ct_Col_GoodsOldGoodsNo);
            //    schemeList.Add(ct_Col_GoodsNewGoodsNo);
            //    schemeList.Add(ct_Col_OutNote);
            //}
            //// ���i�}�X�^
            //else if (mode == PRICEMSTMODE)
            //{
            //    schemeList.Add(ct_Col_GoodsMakerCd1);
            //    schemeList.Add(ct_Col_GoodsOldGoodsNo);
            //    schemeList.Add(ct_Col_PriceStartDate);
            //    schemeList.Add(ct_Col_GoodsNewGoodsNo);
            //    schemeList.Add(ct_Col_OutNote);
            //}
            //// �݌Ƀ}�X�^
            //else if (mode == STOCKMSTMODE)
            //{
            //    schemeList.Add(ct_Col_WareCode);
            //    schemeList.Add(ct_Col_GoodsMakerCd1);
            //    schemeList.Add(ct_Col_GoodsOldGoodsNo);
            //    schemeList.Add(ct_Col_GoodsNewGoodsNo);
            //    schemeList.Add(ct_Col_OutNote);
            //}
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
            // ���i�݌Ƀ}�X�^
            else if (mode == GOODSMSTMODE)
            {
                schemeList.Add(ct_Col_MstDiv);
                schemeList.Add(ct_Col_GoodsMakerCd1);
                schemeList.Add(ct_Col_GoodsOldGoodsNo);
                schemeList.Add(ct_Col_GoodsNewGoodsNo);
                schemeList.Add(ct_Col_WareCode);
                schemeList.Add(ct_Col_PriceStartDate);
                schemeList.Add(ct_Col_OutNote);
            }
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            // ���i�Ǘ����}�X�^
            else if (mode == GOODSMNGMSTMODE)
            {
                schemeList.Add(ct_Col_SectionCode);
                schemeList.Add(ct_Col_GoodsMakerCd1);
                schemeList.Add(ct_Col_GoodsOldGoodsNo);
                schemeList.Add(ct_Col_GoodsNewGoodsNo);
                schemeList.Add(ct_Col_OutNote);
            }
            // �|���}�X�^
            else if (mode == RATEMSTMODE)
            {
                schemeList.Add(ct_Col_SectionCode);
                schemeList.Add(ct_Col_UnitRateSetDivCd);
                schemeList.Add(ct_Col_UnitPriceKind);
                schemeList.Add(ct_Col_GoodsMakerCd1);
                schemeList.Add(ct_Col_GoodsOldGoodsNo);
                schemeList.Add(ct_Col_CustomerCode);
                schemeList.Add(ct_Col_CustRateGrpCode);
                schemeList.Add(ct_Col_SupplierCd);
                schemeList.Add(ct_Col_LotCount);
                schemeList.Add(ct_Col_GoodsNewGoodsNo);
                schemeList.Add(ct_Col_OutNote);
            }
            // �����}�X�^
            else if (mode == JOINMSTMODE)
            {
                schemeList.Add(ct_Col_JoinSourceMakerCode);
                schemeList.Add(ct_Col_JoinSourPartsNoWithH);
                schemeList.Add(ct_Col_JoinDestMakerCd);
                schemeList.Add(ct_Col_JoinDestPartsNoRF);
                schemeList.Add(ct_Col_NewJoinSourPartsNoWithH);
                schemeList.Add(ct_Col_NewJoinDestPartsNoRF);
                schemeList.Add(ct_Col_OutNote);
            }
            // ��փ}�X�^
            else if (mode == PARTSMSTMODE)
            {
                schemeList.Add(CHGSRCMAKERCD_COLUMN);
                schemeList.Add(CHGSRCGOODSNO_COLUMN);
                schemeList.Add(CHGDESTMAKERCD_COLUMN);
                schemeList.Add(CHGDESTGOODSNO_COLUMN);
                schemeList.Add(CHGSRCCHGGOODSNO_COLUMN);
                schemeList.Add(CHGDESTCHGGOODSNO_COLUMN);
                schemeList.Add(OUTNOTE_COLUMN);
            }
            // �Z�b�g�}�X�^
            else if (mode == GOODSSETMSTMODE)
            {
                schemeList.Add(PARENTGOODSMAKERCD_COLUMN);
                schemeList.Add(PARENTGOODSNO_COLUMN);
                schemeList.Add(SUBGOODSMAKERCD_COLUMN);
                schemeList.Add(SUBGOODSNO_COLUMN);
                schemeList.Add(AFCHGPARENTGOODSNO_COLUMN);
                schemeList.Add(AFCHGSUBGOODSNO_COLUMN);
                schemeList.Add(AFCONTENTEXPLAIN_COLUMN);
            }
            //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
            // �D�ǐݒ�}�X�^
            else if (mode == PRMSUCMODE)
            {
                schemeList.Add(SECTIONCODE_COLUMN);
                schemeList.Add(PARTSMAKERCD_COLUMN);
                schemeList.Add(GOODSMGROUPCD_COLUMN);
                schemeList.Add(BLCODE_COLUMN);
                schemeList.Add(PRMSETDTLNO1_COLUMN);
                schemeList.Add(OLDPRMSETDTLNO2_COLUMN);
                schemeList.Add(NEWPRMSETDTLNO2_COLUMN);
            }
            else if (mode == PRMUPDATEERRMODE)
            {
                schemeList.Add(SECTIONCODE_COLUMN);
                schemeList.Add(PARTSMAKERCD_COLUMN);
                schemeList.Add(GOODSMGROUPCD_COLUMN);
                schemeList.Add(BLCODE_COLUMN);
                schemeList.Add(PRMSETDTLNO1_COLUMN);
                schemeList.Add(OLDPRMSETDTLNO2_COLUMN);
                schemeList.Add(NEWPRMSETDTLNO2_COLUMN);
                schemeList.Add(OUTNOTE_COLUMN);
            }
            //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<
            // �ݏo�ϊ�����
            else if (mode == SHIPMENTERRMODE)
            {
                schemeList.Add(SALESSLIPNO_COLUMN);
                schemeList.Add(ROWNO_COLUMN);
                schemeList.Add(ACPTANORDRSTATUS_COLUMN);
                schemeList.Add(GOODSMAKERCD_COLUMN);
                schemeList.Add(OLDGOODSNO_COLUMN);
                schemeList.Add(NEWGOODSNO_COLUMN);
                schemeList.Add(ERROR_COLUMN);
            }
            else if (mode == SHIPMENTSUCMODE)
            {
                schemeList.Add(SALESSLIPNO_COLUMN);
                schemeList.Add(ROWNO_COLUMN);
                schemeList.Add(ACPTANORDRSTATUS_COLUMN);
                schemeList.Add(GOODSMAKERCD_COLUMN);
                schemeList.Add(OLDGOODSNO_COLUMN);
                schemeList.Add(NEWGOODSNO_COLUMN);
            }

            object dataSrc = null;
            string outFileName = "";
            dataSrc = dsOutData.Tables[0];
            outFileName = fileName;

            List<Type> enclosingTypeList = new List<Type>();
            enclosingTypeList.Add("".GetType());

            FormattedTextWriter formattedTextWriter = new FormattedTextWriter();
            formattedTextWriter.DataSource = dataSrc;
            formattedTextWriter.DataMember = String.Empty;
            formattedTextWriter.OutputFileName = outFileName;
            //�e�L�X�g�o�͂��鍀�ږ��̃��X�g
            formattedTextWriter.SchemeList = schemeList;
            formattedTextWriter.Splitter = ",";
            formattedTextWriter.Encloser = "\"";
            formattedTextWriter.EnclosingTypeList = enclosingTypeList;
            formattedTextWriter.FormatList = null;
            //formattedTextWriter.CaptionOutput = false; // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
            formattedTextWriter.CaptionOutput = true; // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
            formattedTextWriter.FixedLength = false;
            formattedTextWriter.ReplaceList = null;
            formattedTextWriter.OutputMode = false;

            return formattedTextWriter;
        }
        #endregion

        #region CSV�o�͏���
        /// <summary>
        /// CSV�o�͏�񏈗�
        /// </summary>
        /// <param name="mstMode">�e�}�X�^�敪</param>
        /// <param name="logKindDiv">���O���0:�����@1:���s</param>
        /// <param name="logDataTable">DataTable</param>
        /// <param name="fileName">�t�@�C����</param>
        /// <param name="goodsChangeResultWork">�߂錋�ʃ��[�N</param>
        /// <remarks>
        /// <br>Note       : �o�C���h������f�[�^�Z�b�g���擾���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        public int DoCSVOutPrc(int mstMode, int logKindDiv, DataTable logDataTable, string fileName, ref GoodsChangeResultWork goodsChangeResultWork)
        {
            int outCSVStatus = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            DataView dv = logDataTable.DefaultView;
            DataSet dsOutData = new DataSet();
            dsOutData.Tables.Add(dv.ToTable());

            // CSV�o�͏�񏈗�
            FormattedTextWriter printInfo = new FormattedTextWriter();
            printInfo = GetCSVInfo(mstMode, dsOutData, fileName);
            Object parameter = (object)printInfo;

            // CSV�o�͏���
            outCSVStatus = DoOutPut(parameter);

            // �X�e�[�^�X�̃Z�b�g
            if (outCSVStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL && logKindDiv == 1)
            {
                goodsChangeResultWork.ErrLogCSVOpen = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            else if (outCSVStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL && logKindDiv == 0)
            {
                goodsChangeResultWork.LogCSVOpen = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            else
            { 
                // �Ȃ�
            }
            return outCSVStatus;
        }
        #endregion

        #region �i�ԕϊ��}�X�^
        // �����i�ԍ�
        private const string OLDGOODSNO_COLUMN = "OldGoodsNoRF";
        // �V���i�ԍ�
        private const string NEWGOODSNO_COLUMN = "NewGoodsNoRF";
        // ���i���[�J�[�R�[�h
        private const string GOODSMAKERCD_COLUMN = "GoodsMakerCdRF";
        //�G���[���b�Z�[�W
        private const string GOODS_ERROR = "GoodsErrorRF";

        //----- DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�----->>>>>
        ////----- ADD 2015/02/25 �c���� Redmine#44209 ----->>>>>
        //// �����i�ԍ�
        //private const string OLDGOODSNO_COLUMN_NAME = "���i���[�J�[�R�[�h";
        //// �V���i�ԍ�
        //private const string NEWGOODSNO_COLUMN_NAME = "���i�ԍ�";
        //// ���i���[�J�[�R�[�h
        //private const string GOODSMAKERCD_COLUMN_NAME = "�ϊ��㏤�i�ԍ�";
        ////�G���[���b�Z�[�W
        //private const string GOODS_ERROR_NAME = "���l";
        ////----- ADD 2015/02/25 �c���� Redmine#44209 -----<<<<<
        //----- DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�-----<<<<<

        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private void TableGoodsChgMst(ref DataTable dataTable)
        {
            dataTable.Columns.Add(OLDGOODSNO_COLUMN, typeof(string));                   //  ���i�ԍ�
            dataTable.Columns.Add(NEWGOODSNO_COLUMN, typeof(string));                   //  ���i�ԍ�
            dataTable.Columns.Add(GOODSMAKERCD_COLUMN, typeof(string));                 //  ���i���[�J�[�R�[�h
            dataTable.Columns.Add(GOODS_ERROR, typeof(string));                         //  �G���[���b�Z�[�W

            //----- ADD 2015/02/25 �c���� Redmine#44209 ----->>>>>
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------>>>>>
            //dataTable.Columns[OLDGOODSNO_COLUMN].Caption = OLDGOODSNO_COLUMN_NAME;
            //dataTable.Columns[NEWGOODSNO_COLUMN].Caption = NEWGOODSNO_COLUMN_NAME;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------<<<<<
            dataTable.Columns[GOODSMAKERCD_COLUMN].Caption = GOODSMAKERCD_COLUMN_NAME;
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------>>>>>
            dataTable.Columns[OLDGOODSNO_COLUMN].Caption = SubStringOfByte(OLDGOODSNO_COLUMN_NAME, 20);
            dataTable.Columns[NEWGOODSNO_COLUMN].Caption = SubStringOfByte(NEWGOODSNO_COLUMN_NAME, 20);
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------<<<<<
            //dataTable.Columns[GOODS_ERROR].Caption = GOODS_ERROR_NAME; // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
            dataTable.Columns[GOODS_ERROR].Caption = GOODSCHG_ERR_NAME; // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
            //----- ADD 2015/02/25 �c���� Redmine#44209 -----<<<<<
        }

        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="dataList">���i�Ǘ��f�[�^���X�g</param>
        /// <param name="dataTable">�e�[�v������</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 ���V�� </br>
        /// <br>           : Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�</br>
        /// </remarks>
        private void ConverToDataSetGoodsChgMst(ArrayList dataList, ref DataTable dataTable)
        {
            foreach (GoodsNoChangeWork goodsNoChange in dataList)
            {
                DataRow dataRow = dataTable.NewRow();

                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�----->>>>>
                //// ���i��
                //dataRow[OLDGOODSNO_COLUMN] = goodsNoChange.OldGoodsNo.Trim().Replace("\"", "\"\"");
                //// �V�i��
                //dataRow[NEWGOODSNO_COLUMN] = goodsNoChange.NewGoodsNo.Trim().Replace("\"", "\"\"");
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�-----<<<<<
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�----->>>>>
                // ���i��
                dataRow[OLDGOODSNO_COLUMN] = SubStringOfByte(SubStringOfByte(goodsNoChange.OldGoodsNo.Trim(), 20), 20);
                // �V�i��
                dataRow[NEWGOODSNO_COLUMN] = SubStringOfByte(SubStringOfByte(goodsNoChange.NewGoodsNo.Trim(), 20), 20);
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�-----<<<<<
                // ���i���[�J�[�R�[�h
                int a = 0;
                if (int.TryParse(goodsNoChange.MakerCdCheck.Trim(),out a))
                {
                    //dataRow[GOODSMAKERCD_COLUMN] = a.ToString().PadLeft(4, '0');// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                    dataRow[GOODSMAKERCD_COLUMN] = SubStringOfByte(a.ToString().PadLeft(4, '0'), 4);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                }
                else
                {
                    //dataRow[GOODSMAKERCD_COLUMN] = goodsNoChange.MakerCdCheck.Trim();// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                    dataRow[GOODSMAKERCD_COLUMN] = SubStringOfByte(SubStringOfByte(goodsNoChange.MakerCdCheck.Trim(), 4), 4);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                }
                // �G���[���b�Z�[�W
                dataRow[GOODS_ERROR] = goodsNoChange.ErroLogMessage;

                dataTable.Rows.Add(dataRow);
            }
        }
        #endregion

        #region ���i�݌Ƀ}�X�^
        //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
        /// <summary> Ͻ���� </summary>			
        private const string ct_Col_MstDiv = "MstDiv";
        //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
        /// <summary> ���i�J�n�� </summary>			
        private const string ct_Col_PriceStartDate = "PriceStartDate";
        /// <summary> �q�ɃR�[�h </summary>			
        private const string ct_Col_WareCode = "WareCode";

        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <param name="mode">���O���[�h</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>Note       : Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/02/26</br>
        /// </remarks>
        //private void TableGoodsStock(ref DataTable dataTable) // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
        private void TableGoodsStock(ref DataTable dataTable, int mode) // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
        {
            dataTable.Columns.Add(ct_Col_MstDiv, typeof(string));                          //  Ͻ����  // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
            dataTable.Columns.Add(ct_Col_GoodsMakerCd1, typeof(string));                   //  ���[�J�[�R�[�h
            dataTable.Columns.Add(ct_Col_GoodsOldGoodsNo, typeof(string));                 //  ���i��
            dataTable.Columns.Add(ct_Col_GoodsNewGoodsNo, typeof(string));                 //  �V�i��
            dataTable.Columns.Add(ct_Col_PriceStartDate, typeof(string));                  //  ���i�J�n��
            dataTable.Columns.Add(ct_Col_WareCode, typeof(string));                     �@ //  �q�ɃR�[�h
            dataTable.Columns.Add(ct_Col_OutNote, typeof(string));                         //  ���l

            //----- ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�----->>>>>
            dataTable.Columns[ct_Col_MstDiv].Caption = MSTDIV_COLUMN_NAME; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
            dataTable.Columns[ct_Col_GoodsMakerCd1].Caption = GOODSMAKERCD_COLUMN_NAME;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------>>>>>
            //dataTable.Columns[ct_Col_GoodsOldGoodsNo].Caption = OLDGOODSNO_COLUMN_NAME;
            //dataTable.Columns[ct_Col_GoodsNewGoodsNo].Caption = NEWGOODSNO_COLUMN_NAME;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------<<<<<
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------>>>>>
            dataTable.Columns[ct_Col_GoodsOldGoodsNo].Caption = SubStringOfByte(OLDGOODSNO_COLUMN_NAME, 20);
            dataTable.Columns[ct_Col_GoodsNewGoodsNo].Caption = SubStringOfByte(NEWGOODSNO_COLUMN_NAME, 20);
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------<<<<<
            dataTable.Columns[ct_Col_PriceStartDate].Caption = PRICESTRDATE_COLUMN_NAME;
            dataTable.Columns[ct_Col_WareCode].Caption = WARECODE_COLUMN_NAME;
            if (mode == SUCLOGMODE)
            {
                dataTable.Columns[ct_Col_OutNote].Caption = GOODSCHG_SUC_NAME;
            }
            else
            {
                dataTable.Columns[ct_Col_OutNote].Caption = GOODSCHG_ERR_NAME;
            }
            //----- ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�-----<<<<<
        }

        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="dataList">���i�Ǘ��f�[�^���X�g</param>
        /// <param name="dataTable">�e�[�v������</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 ���V�� </br>
        /// <br>           : Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�</br>
        /// <br>UpdateNote : 2015/03/02 ���V�� </br>
        /// <br>           : Redmine#44209 ���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�</br>
        /// </remarks>
        //private void ConverToDataSetGoodsStock(ArrayList dataList, ref DataTable dataTable, int mode)// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
        private void ConverToDataSetGoodsStock(ArrayList dataList, ref DataTable dataTable)// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�    
        {
            string priceStrDate = ""; // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
            foreach (MeijiGoodsStockWork meijiGoodsStockWork in dataList)
            {
                DataRow dataRow = dataTable.NewRow();

                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�----->>>>>
                //dataRow[ct_Col_GoodsOldGoodsNo] = meijiGoodsStockWork.OldGoodsNo.Trim().Replace("\"", "\"\"");
                //dataRow[ct_Col_GoodsNewGoodsNo] = meijiGoodsStockWork.NewGoodsNo.Trim().Replace("\"", "\"\"");
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�-----<<<<<
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�----->>>>>
                dataRow[ct_Col_GoodsOldGoodsNo] = SubStringOfByte(meijiGoodsStockWork.OldGoodsNo.Trim(), 20);
                dataRow[ct_Col_GoodsNewGoodsNo] = SubStringOfByte(meijiGoodsStockWork.NewGoodsNo.Trim(), 20);
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�-----<<<<<
                dataRow[ct_Col_GoodsMakerCd1] = meijiGoodsStockWork.GoodsMakerCd.ToString().PadLeft(4, '0');
                dataRow[ct_Col_OutNote] = meijiGoodsStockWork.OutNote.Trim();
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
                //// ���i�}�X�^
                //if (mode == 2)
                //{
                //    dataRow[ct_Col_PriceStartDate] = meijiGoodsStockWork.PriceStartDate.Year.ToString() + meijiGoodsStockWork.PriceStartDate.Month.ToString().PadLeft(2, '0') + meijiGoodsStockWork.PriceStartDate.Day.ToString().PadLeft(2, '0');
                //}
                //// �݌Ƀ}�X�^
                //else if (mode == 3)
                //{
                //    //dataRow[ct_Col_WareCode] = meijiGoodsStockWork.WareCode.Trim();
                //}
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
                priceStrDate = string.Empty;
                // ���i�}�X�^
                if (meijiGoodsStockWork.MstDiv == 0)
                {
                    dataRow[ct_Col_MstDiv] = "���iϽ�";
                }
                // ���i�}�X�^
                else if (meijiGoodsStockWork.MstDiv == 1)
                {
                    dataRow[ct_Col_MstDiv] = "���iϽ�";
                    priceStrDate = meijiGoodsStockWork.PriceStartDate.Year.ToString() + meijiGoodsStockWork.PriceStartDate.Month.ToString().PadLeft(2, '0') + meijiGoodsStockWork.PriceStartDate.Day.ToString().PadLeft(2, '0');
                }
                // �݌Ƀ}�X�^
                else
                {
                    dataRow[ct_Col_MstDiv] = "�݌�Ͻ�";
                }
                dataRow[ct_Col_PriceStartDate] = priceStrDate.PadRight(10, ' ');
                dataRow[ct_Col_WareCode] = meijiGoodsStockWork.WareCode.Trim().PadRight(4, ' ');
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
                dataTable.Rows.Add(dataRow);
            }
        }
        #endregion

        #region ���i���Ǘ��}�X�^
        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <param name="mode">���O�̃��[�h</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/26 ���V�� </br>
        /// <br>           : Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�</br>
        /// </remarks>
        //private void TableMng(ref DataTable dataTable) // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
        private void TableMng(ref DataTable dataTable, int mode) // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
        {
            dataTable.Columns.Add(ct_Col_GoodsMakerCd1, typeof(string));                   //  ���[�J�[�R�[�h
            dataTable.Columns.Add(ct_Col_GoodsOldGoodsNo, typeof(string));                 //  ���i��
            dataTable.Columns.Add(ct_Col_GoodsNewGoodsNo, typeof(string));                 //  �V�i��
            dataTable.Columns.Add(ct_Col_SectionCode, typeof(string));                     //  ���_�R�[�h
            dataTable.Columns.Add(ct_Col_OutNote, typeof(string));                         //  ���l

            //----- ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�----->>>>>
            dataTable.Columns[ct_Col_GoodsMakerCd1].Caption = GOODSMAKERCD_COLUMN_NAME;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------>>>>>
            //dataTable.Columns[ct_Col_GoodsOldGoodsNo].Caption = OLDGOODSNO_COLUMN_NAME;
            //dataTable.Columns[ct_Col_GoodsNewGoodsNo].Caption = NEWGOODSNO_COLUMN_NAME;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------<<<<<
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------>>>>>
            dataTable.Columns[ct_Col_GoodsOldGoodsNo].Caption = SubStringOfByte(OLDGOODSNO_COLUMN_NAME, 20);
            dataTable.Columns[ct_Col_GoodsNewGoodsNo].Caption = SubStringOfByte(NEWGOODSNO_COLUMN_NAME, 20);
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------<<<<<
            dataTable.Columns[ct_Col_SectionCode].Caption = SECTIONCODE_COLUMN_NAME;
            if (mode == SUCLOGMODE)
            {
                dataTable.Columns[ct_Col_OutNote].Caption = GOODSCHG_SUC_NAME;
            }
            else
            {
                dataTable.Columns[ct_Col_OutNote].Caption = GOODSCHG_ERR_NAME;
            }
            //----- ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�-----<<<<<
        }

        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="dataList">���i�Ǘ��f�[�^���X�g</param>
        /// <param name="dataTable">�e�[�v������</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 ���V�� </br>
        /// <br>           : Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�</br>
        /// </remarks>
        private void ConverToDataSetMng(ArrayList dataList, ref DataTable dataTable)
        {
            foreach (MeiJiGoodsMngWork meiJiGoodsMngWork in dataList)
            {
                DataRow dataRow = dataTable.NewRow();
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�----->>>>>
                //dataRow[ct_Col_GoodsOldGoodsNo] = meiJiGoodsMngWork.GoodsNo.Trim().Replace("\"", "\"\"");
                //dataRow[ct_Col_GoodsNewGoodsNo] = meiJiGoodsMngWork.NewGoodsNo.Trim().Replace("\"", "\"\"");
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�-----<<<<<
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�----->>>>>
                dataRow[ct_Col_GoodsOldGoodsNo] = SubStringOfByte(meiJiGoodsMngWork.GoodsNo.Trim(), 20);
                dataRow[ct_Col_GoodsNewGoodsNo] = SubStringOfByte(meiJiGoodsMngWork.NewGoodsNo.Trim(), 20);
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�-----<<<<<
                dataRow[ct_Col_GoodsMakerCd1] = meiJiGoodsMngWork.GoodsMakerCd.ToString().PadLeft(4, '0');
                //dataRow[ct_Col_SectionCode] = meiJiGoodsMngWork.SectionCode.Trim();// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                dataRow[ct_Col_SectionCode] = SubStringOfByte(meiJiGoodsMngWork.SectionCode.Trim().PadLeft(2, '0'), 4);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                dataRow[ct_Col_OutNote] = meiJiGoodsMngWork.OutNote.Trim();

                dataTable.Rows.Add(dataRow);
            }
        }
        #endregion

        #region �|���}�X�^
        /// <summary> ���b�g�� </summary>			
        private const string ct_Col_LotCount = "LotCount";
        /// <summary> ���[�J�[�R�[�h </summary>			
        private const string ct_Col_GoodsMakerCd1 = "GoodsMakerCd";
        /// <summary> ���i�� </summary>			
        private const string ct_Col_GoodsOldGoodsNo = "OldGoodsNo";
        /// <summary> �V�i�� </summary>			
        private const string ct_Col_GoodsNewGoodsNo = "NewGoodsNo";
        /// <summary> ���_�R�[�h </summary>			
        private const string ct_Col_SectionCode = "SectionCode";
        /// <summary> �P���|���ݒ�敪 </summary>			
        private const string ct_Col_UnitRateSetDivCd = "UnitRateSetDivCd";
        /// <summary> �P����� </summary>			
        private const string ct_Col_UnitPriceKind = "UnitPriceKind";
        /// <summary> ���Ӑ�R�[�h </summary>			
        private const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> ���Ӑ�|���O���[�v�R�[�h </summary>			
        private const string ct_Col_CustRateGrpCode = "CustRateGrpCode";
        /// <summary> �d����R�[�h </summary>			
        private const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> ���l </summary>			
        private const string ct_Col_OutNote = "OutNote";

        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <param name="mode">���O�̃��[�h</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/26 ���V�� </br>
        /// <br>           : Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�</br>
        /// </remarks>
        //private void TableRate(ref DataTable dataTable) // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
        private void TableRate(ref DataTable dataTable, int mode) // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
        {
            dataTable.Columns.Add(ct_Col_LotCount, typeof(string));                        //  ���b�g��
            dataTable.Columns.Add(ct_Col_GoodsMakerCd1, typeof(string));                   //  ���[�J�[�R�[�h
            dataTable.Columns.Add(ct_Col_GoodsOldGoodsNo, typeof(string));                 //  ���i��
            dataTable.Columns.Add(ct_Col_GoodsNewGoodsNo, typeof(string));                 //  �V�i��
            dataTable.Columns.Add(ct_Col_SectionCode, typeof(string));                     //  ���_�R�[�h
            dataTable.Columns.Add(ct_Col_UnitRateSetDivCd, typeof(string));                //  �P���|���ݒ�敪
            dataTable.Columns.Add(ct_Col_UnitPriceKind, typeof(string));                   //  �P�����
            dataTable.Columns.Add(ct_Col_CustomerCode, typeof(string));                    //  ���Ӑ�R�[�h
            dataTable.Columns.Add(ct_Col_CustRateGrpCode, typeof(string));                 //  ���Ӑ�|���O���[�v�R�[�h
            dataTable.Columns.Add(ct_Col_SupplierCd, typeof(string));                      //  �d����R�[�h
            dataTable.Columns.Add(ct_Col_OutNote, typeof(string));                         //  ���l

            //----- ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�----->>>>>
            dataTable.Columns[ct_Col_GoodsMakerCd1].Caption = GOODSMAKERCD_COLUMN_NAME;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------>>>>>
            //dataTable.Columns[ct_Col_GoodsOldGoodsNo].Caption = OLDGOODSNO_COLUMN_NAME;
            //dataTable.Columns[ct_Col_GoodsNewGoodsNo].Caption = NEWGOODSNO_COLUMN_NAME;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------<<<<<
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------>>>>>
            dataTable.Columns[ct_Col_GoodsOldGoodsNo].Caption = SubStringOfByte(OLDGOODSNO_COLUMN_NAME, 20);
            dataTable.Columns[ct_Col_GoodsNewGoodsNo].Caption = SubStringOfByte(NEWGOODSNO_COLUMN_NAME, 20);
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------<<<<<
            dataTable.Columns[ct_Col_SectionCode].Caption = SECTIONCODE_COLUMN_NAME;
            //dataTable.Columns[ct_Col_LotCount].Caption = LOTCOUNT_COLUMN_NAME;// DEL 2015/03/02 ���V�� Redmine#44209 ���O�̍��ږ��̑Ή�
            dataTable.Columns[ct_Col_LotCount].Caption = SubStringOfByte(LOTCOUNT_COLUMN_NAME, 10);// ADD 2015/03/02 ���V�� Redmine#44209 ���O�̍��ږ��̑Ή�
            dataTable.Columns[ct_Col_UnitRateSetDivCd].Caption = UNITRATESETDIVCD_COLUMN_NAME;
            dataTable.Columns[ct_Col_UnitPriceKind].Caption = UNITPRICEKIND_COLUMN_NAME;
            //dataTable.Columns[ct_Col_CustomerCode].Caption = CUSTOMERCODE_COLUMN_NAME; // DEL 2015/03/02 ���V�� Redmine#44209 ���O�̍��ږ��̑Ή�
            dataTable.Columns[ct_Col_CustomerCode].Caption = SubStringOfByte(CUSTOMERCODE_COLUMN_NAME, 8); // ADD 2015/03/02 ���V�� Redmine#44209 ���O�̍��ږ��̑Ή�
            dataTable.Columns[ct_Col_CustRateGrpCode].Caption = CUSTRATEGRPCODE_COLUMN_NAME;
            dataTable.Columns[ct_Col_SupplierCd].Caption = SUPPLIERCD_COLUMN_NAME;
            if (mode == SUCLOGMODE)
            {
                dataTable.Columns[ct_Col_OutNote].Caption = GOODSCHG_SUC_NAME;
            }
            else
            {
                dataTable.Columns[ct_Col_OutNote].Caption = GOODSCHG_ERR_NAME;
            }
            //----- ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�-----<<<<<
        }

        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="dataList">���i�Ǘ��f�[�^���X�g</param>
        /// <param name="dataTable">�e�[�v������</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 ���V�� </br>
        /// <br>           : Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�</br>
        /// </remarks>
        private void ConverToDataSetRate(ArrayList dataList, ref DataTable dataTable)
        {
            foreach (MeijiRateWork meijiRateWork in dataList)
            {
                DataRow dataRow = dataTable.NewRow();

                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�----->>>>>
                //dataRow[ct_Col_GoodsOldGoodsNo] = meijiRateWork.GoodsNo.Trim().Replace("\"", "\"\"");
                //dataRow[ct_Col_GoodsNewGoodsNo] = meijiRateWork.NewGoodsNo.Trim().Replace("\"", "\"\"");
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�-----<<<<<
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�----->>>>>
                dataRow[ct_Col_GoodsOldGoodsNo] = SubStringOfByte(meijiRateWork.GoodsNo.Trim(), 20);
                dataRow[ct_Col_GoodsNewGoodsNo] = SubStringOfByte(meijiRateWork.NewGoodsNo.Trim(), 20);
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�-----<<<<<
                dataRow[ct_Col_GoodsMakerCd1] = meijiRateWork.GoodsMakerCd.ToString().PadLeft(4, '0');
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�----->>>>>
                //dataRow[ct_Col_LotCount] = meijiRateWork.LotCount.ToString();
                //dataRow[ct_Col_SectionCode] = meijiRateWork.SectionCode.Trim();
                //dataRow[ct_Col_UnitRateSetDivCd] = meijiRateWork.UnitRateSetDivCd.Trim();
                //dataRow[ct_Col_UnitPriceKind] = meijiRateWork.UnitPriceKind.Trim();
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�-----<<<<<
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�----->>>>>
                dataRow[ct_Col_LotCount] = SubStringOfByte(meijiRateWork.LotCount.ToString(), 10);
                dataRow[ct_Col_SectionCode] = SubStringOfByte(meijiRateWork.SectionCode.Trim().PadLeft(2, '0'), 4);
                dataRow[ct_Col_UnitRateSetDivCd] = SubStringOfByte(meijiRateWork.UnitRateSetDivCd.Trim(), 12);
                dataRow[ct_Col_UnitPriceKind] = SubStringOfByte(meijiRateWork.UnitPriceKind.Trim(), 8);
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�-----<<<<<
                dataRow[ct_Col_CustomerCode] = meijiRateWork.CustomerCode.ToString().PadLeft(8, '0');
                //dataRow[ct_Col_CustRateGrpCode] = meijiRateWork.CustRateGrpCode.ToString().PadLeft(4, '0'); //DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                dataRow[ct_Col_CustRateGrpCode] = SubStringOfByte(meijiRateWork.CustRateGrpCode.ToString().PadLeft(4, '0'), 10); //ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                dataRow[ct_Col_SupplierCd] = meijiRateWork.SupplierCd.ToString().PadLeft(6, '0');
                dataRow[ct_Col_OutNote] = meijiRateWork.OutNote.Trim();

                dataTable.Rows.Add(dataRow);
            }
        }
        #endregion

        #region �����}�X�^
        /// <summary> ���������[�J�[�R�[�h </summary>			
        private const string ct_Col_JoinSourceMakerCode = "JoinSourceMakerCode";
        /// <summary> �������i��(�|�t���i��) </summary>			
        private const string ct_Col_JoinSourPartsNoWithH = "JoinSourPartsNoWithH";
        /// <summary> �����惁�[�J�[�R�[�h </summary>			
        private const string ct_Col_JoinDestMakerCd = "JoinDestMakerCd";
        /// <summary> ������i��(�|�t���i��) </summary>			
        private const string ct_Col_JoinDestPartsNoRF = "JoinDestPartsNoRF";
        /// <summary> New�������i��(�|�t���i��) </summary>			
        private const string ct_Col_NewJoinSourPartsNoWithH = "NewJoinSourPartsNoWithH";
        /// <summary> New������i��(�|�t���i��) </summary>			
        private const string ct_Col_NewJoinDestPartsNoRF = "NewJoinDestPartsNoRF";

        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <param name="mode">���O�̃��[�h</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        //private void TableJoin(ref DataTable dataTable) // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
        private void TableJoin(ref DataTable dataTable, int mode) // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
        {
            // ���������[�J�[�R�[�h 
            dataTable.Columns.Add(ct_Col_JoinSourceMakerCode, typeof(string));
            // �������i��(�|�t���i��)
            dataTable.Columns.Add(ct_Col_JoinSourPartsNoWithH, typeof(string));
            // �����惁�[�J�[�R�[�h
            dataTable.Columns.Add(ct_Col_JoinDestMakerCd, typeof(string));
            // ������i��(�|�t���i��)
            dataTable.Columns.Add(ct_Col_JoinDestPartsNoRF, typeof(string));
            // New�������i��(�|�t���i��)
            dataTable.Columns.Add(ct_Col_NewJoinSourPartsNoWithH, typeof(string));
            // New������i��(�|�t���i��)
            dataTable.Columns.Add(ct_Col_NewJoinDestPartsNoRF, typeof(string));
            // ���l
            dataTable.Columns.Add(ct_Col_OutNote, typeof(string));

            //----- ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�----->>>>>
            dataTable.Columns[ct_Col_JoinSourceMakerCode].Caption = JOINSOURCEMAKERCODE_COLUMN_NAME;
            //dataTable.Columns[ct_Col_JoinSourPartsNoWithH].Caption = JOINSOURPARTSNOWITHH_COLUMN_NAME; // DEL 2015/03/02 ���V�� Redmine#44209 ���O�̍��ږ��̑Ή�
            dataTable.Columns[ct_Col_JoinSourPartsNoWithH].Caption = SubStringOfByte(JOINSOURPARTSNOWITHH_COLUMN_NAME, 20); // ADD 2015/03/02 ���V�� Redmine#44209 ���O�̍��ږ��̑Ή�
            dataTable.Columns[ct_Col_JoinDestMakerCd].Caption = JOINDESTMAKERCD_COLUMN_NAME;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------>>>>>
            //dataTable.Columns[ct_Col_JoinDestPartsNoRF].Caption = JOINDESTPARTSNORF_COLUMN_NAME;
            //dataTable.Columns[ct_Col_NewJoinSourPartsNoWithH].Caption = NEWJOINSOURPARTSNOWITHH_COLUMN_NAME;
            //dataTable.Columns[ct_Col_NewJoinDestPartsNoRF].Caption = NEWJOINDESTPARTSNORF_COLUMN_NAME;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------<<<<<
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------>>>>>
            dataTable.Columns[ct_Col_JoinDestPartsNoRF].Caption = SubStringOfByte(JOINDESTPARTSNORF_COLUMN_NAME, 20);
            dataTable.Columns[ct_Col_NewJoinSourPartsNoWithH].Caption = SubStringOfByte(NEWJOINSOURPARTSNOWITHH_COLUMN_NAME, 20);
            dataTable.Columns[ct_Col_NewJoinDestPartsNoRF].Caption = SubStringOfByte(NEWJOINDESTPARTSNORF_COLUMN_NAME, 20);
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------<<<<<
            if (mode == SUCLOGMODE)
            {
                dataTable.Columns[ct_Col_OutNote].Caption = GOODSCHG_SUC_NAME;
            }
            else
            {
                dataTable.Columns[ct_Col_OutNote].Caption = GOODSCHG_ERR_NAME;
            }
            //----- ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�-----<<<<<
        }

        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="dataList">���i�Ǘ��f�[�^���X�g</param>
        /// <param name="dataTable">�e�[�v������</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 ���V�� </br>
        /// <br>           : Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�</br>
        /// </remarks>
        private void ConverToDataSetTableJoin(ArrayList dataList, ref DataTable dataTable)
        {
            foreach (NewJoinPartsWork partsSubst in dataList)
                {
                    DataRow dataRow = dataTable.NewRow();

                    //  ���������[�J�[�R�[�h
                    //dataRow[ct_Col_JoinSourceMakerCode] = partsSubst.JoinSourceMakerCode.ToString("d4");// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                    dataRow[ct_Col_JoinSourceMakerCode] = SubStringOfByte(partsSubst.JoinSourceMakerCode.ToString("d4"), 10);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                    //  �������i��(�|�t���i��) 
                    //dataRow[ct_Col_JoinSourPartsNoWithH] = partsSubst.JoinSourPartsNoWithH.Trim().Replace("\"", "\"\""); ;// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                    dataRow[ct_Col_JoinSourPartsNoWithH] = SubStringOfByte(partsSubst.JoinSourPartsNoWithH.Trim(), 20); // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                    //  �����惁�[�J�[�R�[�h
                    //dataRow[ct_Col_JoinDestMakerCd] = partsSubst.JoinDestMakerCd.ToString("d4");// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                    dataRow[ct_Col_JoinDestMakerCd] = SubStringOfByte(partsSubst.JoinDestMakerCd.ToString("d4"), 10);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                    //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�----->>>>>
                    ////  ������i��(�|�t���i��)
                    //dataRow[ct_Col_JoinDestPartsNoRF] = partsSubst.JoinDestPartsNo.Trim().Replace("\"", "\"\""); ;
                    ////  New�������i��(�|�t���i��)
                    //dataRow[ct_Col_NewJoinSourPartsNoWithH] = partsSubst.NewJoinSourPartsNoWithH.Trim().Replace("\"", "\"\""); ;
                    ////  New������i��(�|�t���i��)
                    //dataRow[ct_Col_NewJoinDestPartsNoRF] = partsSubst.NewJoinDestPartsNo.Trim().Replace("\"", "\"\""); ;
                    //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�-----<<<<<
                    //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�----->>>>>
                    //  ������i��(�|�t���i��)
                    dataRow[ct_Col_JoinDestPartsNoRF] = SubStringOfByte(partsSubst.JoinDestPartsNo.Trim(), 20);
                    //  New�������i��(�|�t���i��)
                    dataRow[ct_Col_NewJoinSourPartsNoWithH] = SubStringOfByte(partsSubst.NewJoinSourPartsNoWithH.Trim(), 20);
                    //  New������i��(�|�t���i��)
                    dataRow[ct_Col_NewJoinDestPartsNoRF] = SubStringOfByte(partsSubst.NewJoinDestPartsNo.Trim(), 20);
                    //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�-----<<<<<
                    //  ���l
                    dataRow[ct_Col_OutNote] = partsSubst.OutNote;

                    dataTable.Rows.Add(dataRow);
                }
        }
        #endregion

        #region ��փ}�X�^
        // ��֌����[�J�[�R�[�h
        private const string CHGSRCMAKERCD_COLUMN = "chgSrcMakerCdRF";
        // ��֌����i�ԍ�
        private const string CHGSRCGOODSNO_COLUMN = "chgSrcGoodsNoRF";
        // ��֐惁�[�J�[�R�[�h
        private const string CHGDESTMAKERCD_COLUMN = "chgDestMakerCdRF";
        // ��֐揤�i�ԍ�
        private const string CHGDESTGOODSNO_COLUMN = "chgDestGoodsNoRF";
        // �ϊ����֌����i�ԍ�
        private const string CHGSRCCHGGOODSNO_COLUMN = "chgSrcChgGoodsNoRF";
        // �ϊ����֐揤�i�ԍ�
        private const string CHGDESTCHGGOODSNO_COLUMN = "chgDestChgGoodsNoRF";
        // ���l
        private const string OUTNOTE_COLUMN = "outNoteRF";

        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <param name="mode">���O�̃��[�h</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/26 ���V�� </br>
        /// <br>           : Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�</br>
        /// </remarks>
        //private void TableGoodsPartsChgMst(ref DataTable dataTable) // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
        private void TableGoodsPartsChgMst(ref DataTable dataTable, int mode) // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
        {
            dataTable.Columns.Add(CHGSRCMAKERCD_COLUMN, typeof(string));                    //  ��֌����[�J�[�R�[�h
            dataTable.Columns.Add(CHGSRCGOODSNO_COLUMN, typeof(string));                    //  ��֌����i�ԍ�
            dataTable.Columns.Add(CHGDESTMAKERCD_COLUMN, typeof(string));                   //  ��֐惁�[�J�[�R�[�h
            dataTable.Columns.Add(CHGDESTGOODSNO_COLUMN, typeof(string));                   //  ��֐揤�i�ԍ�
            dataTable.Columns.Add(CHGSRCCHGGOODSNO_COLUMN, typeof(string));                 //  �ϊ����֌����i�ԍ�
            dataTable.Columns.Add(CHGDESTCHGGOODSNO_COLUMN, typeof(string));                //  �ϊ����֐揤�i�ԍ�
            dataTable.Columns.Add(OUTNOTE_COLUMN, typeof(string));                          //  ���l

            //----- ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�----->>>>>
            dataTable.Columns[CHGSRCMAKERCD_COLUMN].Caption = CHGSRCMAKERCD_COLUMN_NAME;
            //dataTable.Columns[CHGSRCGOODSNO_COLUMN].Caption = CHGSRCGOODSNO_COLUMN_NAME;// DEL 2015/03/02 ���V�� Redmine#44209 ���O�̍��ږ��̑Ή�
            dataTable.Columns[CHGSRCGOODSNO_COLUMN].Caption = SubStringOfByte(CHGSRCGOODSNO_COLUMN_NAME, 20);// ADD 2015/03/02 ���V�� Redmine#44209 ���O�̍��ږ��̑Ή�
            dataTable.Columns[CHGDESTMAKERCD_COLUMN].Caption = CHGDESTMAKERCD_COLUMN_NAME;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------>>>>>
            //dataTable.Columns[CHGDESTGOODSNO_COLUMN].Caption = CHGDESTGOODSNO_COLUMN_NAME;
            //dataTable.Columns[CHGSRCCHGGOODSNO_COLUMN].Caption = CHGSRCCHGGOODSNO_COLUMN_NAME;
            //dataTable.Columns[CHGDESTCHGGOODSNO_COLUMN].Caption = CHGDESTCHGGOODSNO_COLUMN_NAME;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------<<<<<
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------>>>>>
            dataTable.Columns[CHGDESTGOODSNO_COLUMN].Caption = SubStringOfByte(CHGDESTGOODSNO_COLUMN_NAME, 20);
            dataTable.Columns[CHGSRCCHGGOODSNO_COLUMN].Caption = SubStringOfByte(CHGSRCCHGGOODSNO_COLUMN_NAME, 20);
            dataTable.Columns[CHGDESTCHGGOODSNO_COLUMN].Caption = SubStringOfByte(CHGDESTCHGGOODSNO_COLUMN_NAME, 20);
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------<<<<<
            if (mode == SUCLOGMODE)
            {
                dataTable.Columns[OUTNOTE_COLUMN].Caption = GOODSCHG_SUC_NAME;
            }
            else
            {
                dataTable.Columns[OUTNOTE_COLUMN].Caption = GOODSCHG_ERR_NAME;
            }
            //----- ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�-----<<<<<
        }

        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="dataList">���i�Ǘ��f�[�^���X�g</param>
        /// <param name="dataTable">�e�[�v������</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 ���V�� </br>
        /// <br>           : Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�</br>
        /// </remarks>
        private void ConverToDataSetGoodsPartsChgMst(ArrayList dataList, ref DataTable dataTable)
        {
            foreach (MeijiPartsSubstWork meijiPartsSubstWork in dataList)
            {
                DataRow dataRow = dataTable.NewRow();

                // ��֌����[�J�[�R�[�h
                //dataRow[CHGSRCMAKERCD_COLUMN] = meijiPartsSubstWork.ChgSrcMakerCd.ToString().PadLeft(4, '0'); // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                dataRow[CHGSRCMAKERCD_COLUMN] = SubStringOfByte(meijiPartsSubstWork.ChgSrcMakerCd.ToString().PadLeft(4, '0'), 10); // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                // ��֌����i�ԍ�
                //dataRow[CHGSRCGOODSNO_COLUMN] = meijiPartsSubstWork.ChgSrcGoodsNo.Trim().Replace("\"", "\"\"");// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                dataRow[CHGSRCGOODSNO_COLUMN] = SubStringOfByte(meijiPartsSubstWork.ChgSrcGoodsNo.Trim(), 20);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                // ��֐惁�[�J�[�R�[�h
                //dataRow[CHGDESTMAKERCD_COLUMN] = meijiPartsSubstWork.ChgDestMakerCd.ToString().PadLeft(4, '0');// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                dataRow[CHGDESTMAKERCD_COLUMN] = SubStringOfByte(meijiPartsSubstWork.ChgDestMakerCd.ToString().PadLeft(4, '0'), 10);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�----->>>>>
                //// ��֐揤�i�ԍ�
                //dataRow[CHGDESTGOODSNO_COLUMN] = meijiPartsSubstWork.ChgDestGoodsNo.Trim().Replace("\"", "\"\"");
                //// �ϊ����֌����i�ԍ�
                //dataRow[CHGSRCCHGGOODSNO_COLUMN] = meijiPartsSubstWork.ChgSrcChgGoodsNo.Trim().Replace("\"", "\"\"");
                //// �ϊ����֐揤�i�ԍ�
                //dataRow[CHGDESTCHGGOODSNO_COLUMN] = meijiPartsSubstWork.ChgDestChgGoodsNo.Trim().Replace("\"", "\"\"");
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�-----<<<<<
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�----->>>>>
                // ��֐揤�i�ԍ�
                dataRow[CHGDESTGOODSNO_COLUMN] = SubStringOfByte(meijiPartsSubstWork.ChgDestGoodsNo.Trim(), 20);
                // �ϊ����֌����i�ԍ�
                dataRow[CHGSRCCHGGOODSNO_COLUMN] = SubStringOfByte(meijiPartsSubstWork.ChgSrcChgGoodsNo.Trim(), 20);
                // �ϊ����֐揤�i�ԍ�
                dataRow[CHGDESTCHGGOODSNO_COLUMN] = SubStringOfByte(meijiPartsSubstWork.ChgDestChgGoodsNo.Trim(), 20);
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�-----<<<<<
                // ���l
                dataRow[OUTNOTE_COLUMN] = meijiPartsSubstWork.OutNote.Trim();

                dataTable.Rows.Add(dataRow);
            }
        }
        #endregion

        #region �Z�b�g�}�X�^
        // �e���[�J�[�R�[�h
        private const string PARENTGOODSMAKERCD_COLUMN = "ParentGoodsMakerCdRF";
        // �e���i�ԍ�
        private const string PARENTGOODSNO_COLUMN = "ParentGoodsNoRF";
        // �q���i���[�J�[�R�[�h
        private const string SUBGOODSMAKERCD_COLUMN = "SubGoodsMakerCdRF";
        // �q���i�ԍ�
        private const string SUBGOODSNO_COLUMN = "SubGoodsNoRF";
        // �ϊ���e���i�ԍ�
        private const string AFCHGPARENTGOODSNO_COLUMN = "AfChgParentGoodsNoRF";
        // �ϊ���q���i�ԍ�
        private const string AFCHGSUBGOODSNO_COLUMN = "AfChgSubGoodsNoRF";
        // ���l
        private const string AFCONTENTEXPLAIN_COLUMN = "AfContentExplainRF";

        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <param name="mode">���O�̃��[�h</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/26 ���V�� </br>
        /// <br>           : Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�</br>
        /// </remarks>
        //private void TableGoodsSetChgMst(ref DataTable dataTable) // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
        private void TableGoodsSetChgMst(ref DataTable dataTable, int mode) // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
        {
            dataTable.Columns.Add(PARENTGOODSMAKERCD_COLUMN, typeof(string));                       //  �e���[�J�[�R�[�h
            dataTable.Columns.Add(PARENTGOODSNO_COLUMN, typeof(string));                            //  �e���i�ԍ�
            dataTable.Columns.Add(SUBGOODSMAKERCD_COLUMN, typeof(string));                          //  �q���i���[�J�[�R�[�h
            dataTable.Columns.Add(SUBGOODSNO_COLUMN, typeof(string));                               //  �q���i�ԍ�
            dataTable.Columns.Add(AFCHGPARENTGOODSNO_COLUMN, typeof(string));                       //  �ϊ���e���i�ԍ�
            dataTable.Columns.Add(AFCHGSUBGOODSNO_COLUMN, typeof(string));                          //  �ϊ���q���i�ԍ�
            dataTable.Columns.Add(AFCONTENTEXPLAIN_COLUMN, typeof(string));                         //  ���l

            //----- ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�----->>>>>
            dataTable.Columns[PARENTGOODSMAKERCD_COLUMN].Caption = PARENTGOODSMAKERCD_COLUMN_NAME;
            //dataTable.Columns[PARENTGOODSNO_COLUMN].Caption = PARENTGOODSNO_COLUMN_NAME;// DEL 2015/03/02 ���V�� Redmine#44209 ���O�̍��ږ��̑Ή�
            dataTable.Columns[PARENTGOODSNO_COLUMN].Caption = SubStringOfByte(PARENTGOODSNO_COLUMN_NAME, 20);// ADD 2015/03/02 ���V�� Redmine#44209 ���O�̍��ږ��̑Ή�
            dataTable.Columns[SUBGOODSMAKERCD_COLUMN].Caption = SUBGOODSMAKERCD_COLUMN_NAME;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------>>>>>
            //dataTable.Columns[SUBGOODSNO_COLUMN].Caption = SUBGOODSNO_COLUMN_NAME;
            //dataTable.Columns[AFCHGPARENTGOODSNO_COLUMN].Caption = AFCHGPARENTGOODSNO_COLUMN_NAME;
            //dataTable.Columns[AFCHGSUBGOODSNO_COLUMN].Caption = AFCHGSUBGOODSNO_COLUMN_NAME;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------<<<<<
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------>>>>>
            dataTable.Columns[SUBGOODSNO_COLUMN].Caption = SubStringOfByte(SUBGOODSNO_COLUMN_NAME, 20);
            dataTable.Columns[AFCHGPARENTGOODSNO_COLUMN].Caption = SubStringOfByte(AFCHGPARENTGOODSNO_COLUMN_NAME, 20);
            dataTable.Columns[AFCHGSUBGOODSNO_COLUMN].Caption = SubStringOfByte(AFCHGSUBGOODSNO_COLUMN_NAME, 20);
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------<<<<<
            if (mode == SUCLOGMODE)
            {
                dataTable.Columns[AFCONTENTEXPLAIN_COLUMN].Caption = GOODSCHG_SUC_NAME;
            }
            else
            {
                dataTable.Columns[AFCONTENTEXPLAIN_COLUMN].Caption = GOODSCHG_ERR_NAME;
            }
            //----- ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�-----<<<<<
        }

        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="dataList">���i�Ǘ��f�[�^���X�g</param>
        /// <param name="dataTable">�e�[�v������</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 ���V�� </br>
        /// <br>           : Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�</br>
        /// </remarks>
        private void ConverToDataSetGoodsSetChgMst(ArrayList dataList, ref DataTable dataTable)
        {
            foreach (GoodsSetChgWork goodsSetChgWork in dataList)
            {
                DataRow dataRow = dataTable.NewRow();

                // �e���[�J�[�R�[�h
                //dataRow[PARENTGOODSMAKERCD_COLUMN] = goodsSetChgWork.ParentGoodsMakerCd.ToString().PadLeft(4, '0'); // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                dataRow[PARENTGOODSMAKERCD_COLUMN] = SubStringOfByte(goodsSetChgWork.ParentGoodsMakerCd.ToString().PadLeft(4, '0'), 6); // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                // �e���i�ԍ�
                //dataRow[PARENTGOODSNO_COLUMN] = goodsSetChgWork.ParentGoodsNo.Trim().Replace("\"", "\"\"");// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                dataRow[PARENTGOODSNO_COLUMN] = SubStringOfByte(goodsSetChgWork.ParentGoodsNo.Trim(), 20);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                // �q���i���[�J�[�R�[�h
                //dataRow[SUBGOODSMAKERCD_COLUMN] = goodsSetChgWork.SubGoodsMakerCd.ToString().PadLeft(4, '0'); // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                dataRow[SUBGOODSMAKERCD_COLUMN] = SubStringOfByte(goodsSetChgWork.SubGoodsMakerCd.ToString().PadLeft(4, '0'), 6); // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�----->>>>>
                //// �q���i�ԍ�
                //dataRow[SUBGOODSNO_COLUMN] = goodsSetChgWork.SubGoodsNo.Trim().Replace("\"", "\"\"");
                //// �ϊ���e���i�ԍ�
                //dataRow[AFCHGPARENTGOODSNO_COLUMN] = goodsSetChgWork.AfChgParentGoodsNo.Trim().Replace("\"", "\"\"");
                //// �ϊ���q���i�ԍ�
                //dataRow[AFCHGSUBGOODSNO_COLUMN] = goodsSetChgWork.AfChgSubGoodsNo.Trim().Replace("\"", "\"\"");
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�-----<<<<<
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�----->>>>>
                // �q���i�ԍ�
                dataRow[SUBGOODSNO_COLUMN] = SubStringOfByte(goodsSetChgWork.SubGoodsNo.Trim(), 20);
                // �ϊ���e���i�ԍ�
                dataRow[AFCHGPARENTGOODSNO_COLUMN] = SubStringOfByte(goodsSetChgWork.AfChgParentGoodsNo.Trim(), 20);
                // �ϊ���q���i�ԍ�
                dataRow[AFCHGSUBGOODSNO_COLUMN] = SubStringOfByte(goodsSetChgWork.AfChgSubGoodsNo.Trim(), 20);
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�-----<<<<<
                // ���l
                dataRow[AFCONTENTEXPLAIN_COLUMN] = goodsSetChgWork.AfContentExplain.Trim();

                dataTable.Rows.Add(dataRow);
            }
        }
        #endregion

        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
        #region �D�ǐݒ�}�X�^
        // ���_�R�[�h
        private const string SECTIONCODE_COLUMN = "SectionCodeRF";
        // ���i���[�J�[�R�[�h
        private const string PARTSMAKERCD_COLUMN = "PartsMakerCdRF";
        // ���i�����ރR�[�h
        private const string GOODSMGROUPCD_COLUMN = "GoodsMGroupRF";
        // BL�R�[�h
        private const string BLCODE_COLUMN = "TbsPartsCodeRF";
        // �D�ǐݒ�ڍ׃R�[�h1
        private const string PRMSETDTLNO1_COLUMN = "PrmSetDtlName1RF";
        // ���i��-�D�ǐݒ�ڍ׃R�[�h2
        private const string OLDPRMSETDTLNO2_COLUMN = "PrmSetDtlNoAfterOldRF";
        // �V�i��-�D�ǐݒ�ڍ׃R�[�h2
        private const string NEWPRMSETDTLNO2_COLUMN = "PrmSetDtlNoAfterNewRF";

        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <param name="mode">���O�̃��[�h</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/02/27</br>
        /// </remarks>
        private void CreatTablePrmSetting(ref DataTable dataTable, int mode)
        {
            dataTable.Columns.Add(SECTIONCODE_COLUMN, typeof(string));                     //  ���_�R�[�h
            dataTable.Columns.Add(PARTSMAKERCD_COLUMN, typeof(string));                    //  ���i���[�J�[�R�[�h
            dataTable.Columns.Add(GOODSMGROUPCD_COLUMN, typeof(string));                   //  ���i�����ރR�[�h
            dataTable.Columns.Add(BLCODE_COLUMN, typeof(string));                          //  BL�R�[�h
            dataTable.Columns.Add(PRMSETDTLNO1_COLUMN, typeof(string));                    //  �D�ǐݒ�ڍ׃R�[�h1
            dataTable.Columns.Add(OLDPRMSETDTLNO2_COLUMN, typeof(string));                 //  ���i��-�D�ǐݒ�ڍ׃R�[�h2
            dataTable.Columns.Add(NEWPRMSETDTLNO2_COLUMN, typeof(string));                 //  �V�i��-�D�ǐݒ�ڍ׃R�[�h2
            dataTable.Columns.Add(OUTNOTE_COLUMN, typeof(string));                         //  �G���[���e

            dataTable.Columns[SECTIONCODE_COLUMN].Caption = SECTIONCODE_COLUMN_NAME;
            dataTable.Columns[PARTSMAKERCD_COLUMN].Caption = GOODSMAKERCD_COLUMN_NAME;
            dataTable.Columns[GOODSMGROUPCD_COLUMN].Caption = GOODSMGROUPCD_COLUMN_NAME;
            dataTable.Columns[BLCODE_COLUMN].Caption = BLCODE_COLUMN_NAME;
            dataTable.Columns[PRMSETDTLNO1_COLUMN].Caption = PRMSETDTLNO1_COLUMN_NAME;
            dataTable.Columns[OLDPRMSETDTLNO2_COLUMN].Caption = OLDPRMSETDTLNO2_COLUMN_NAME;
            dataTable.Columns[NEWPRMSETDTLNO2_COLUMN].Caption = NEWPRMSETDTLNO2_COLUMN_NAME;
            if (mode == SUCLOGMODE)
            {
                dataTable.Columns[OUTNOTE_COLUMN].Caption = GOODSCHG_SUC_NAME;
            }
            else
            {
                dataTable.Columns[OUTNOTE_COLUMN].Caption = GOODSCHG_ERR_NAME;
            }
        }

        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="dataList">���i�Ǘ��f�[�^���X�g</param>
        /// <param name="dataTable">�e�[�v������</param>
        /// <param name="flg">�t���t</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/02/27</br>
        /// </remarks>
        private void ConverToDataSetPrm(ArrayList dataList, ref DataTable dataTable, bool flg)
        {
            foreach (NewPrmSettingUWork newPrmSettingUWork in dataList)
            {
                DataRow dataRow = dataTable.NewRow();

                if (flg)
                {
                    // ���_�R�[�h
                    dataRow[SECTIONCODE_COLUMN] = newPrmSettingUWork.SectionCode.Trim().PadRight(4, ' ');
                    // ���i���[�J�[�R�[�h
                    dataRow[PARTSMAKERCD_COLUMN] = SubStringOfByte(SubStringOfByte(newPrmSettingUWork.PartsMakerCd.ToString(), 4), 4);
                    // ���i�����ރR�[�h
                    dataRow[GOODSMGROUPCD_COLUMN] = SubStringOfByte(SubStringOfByte(newPrmSettingUWork.GoodsMGroup.ToString(), 6), 6);
                    // BL�R�[�h
                    dataRow[BLCODE_COLUMN] = SubStringOfByte(SubStringOfByte(newPrmSettingUWork.TbsPartsCode.ToString(), 6), 6);
                    // �D�ǐݒ�ڍ׃R�[�h1
                    dataRow[PRMSETDTLNO1_COLUMN] = SubStringOfByte(SubStringOfByte(newPrmSettingUWork.PrmSetDtlNo1.Trim(), 4), 4);
                    // ���i��-�D�ǐݒ�ڍ׃R�[�h2
                    dataRow[OLDPRMSETDTLNO2_COLUMN] = SubStringOfByte(SubStringOfByte(newPrmSettingUWork.PrmSetDtlNoAfterOld.ToString(), 10), 10);
                    // �V�i��-�D�ǐݒ�ڍ׃R�[�h2
                    dataRow[NEWPRMSETDTLNO2_COLUMN] = SubStringOfByte(SubStringOfByte(newPrmSettingUWork.PrmSetDtlNoAfterNew.ToString(), 10), 10);
                    // �G���[���e
                    dataRow[OUTNOTE_COLUMN] = newPrmSettingUWork.OutNote;
                }
                else
                {
                    // ���_�R�[�h
                    dataRow[SECTIONCODE_COLUMN] = SubStringOfByte(newPrmSettingUWork.SectionCode.Trim().PadLeft(2, '0'), 4);
                    // ���i���[�J�[�R�[�h
                    dataRow[PARTSMAKERCD_COLUMN] = newPrmSettingUWork.PartsMakerCd.ToString().PadLeft(4, '0');
                    // ���i�����ރR�[�h
                    dataRow[GOODSMGROUPCD_COLUMN] = SubStringOfByte(newPrmSettingUWork.GoodsMGroup.ToString().PadLeft(4, '0'), 6);
                    // BL�R�[�h
                    dataRow[BLCODE_COLUMN] = SubStringOfByte(newPrmSettingUWork.TbsPartsCode.ToString().PadLeft(4, '0'), 6);
                    // �D�ǐݒ�ڍ׃R�[�h1
                    dataRow[PRMSETDTLNO1_COLUMN] = newPrmSettingUWork.PrmSetDtlNo1.ToString().PadLeft(4, '0');
                    // ���i��-�D�ǐݒ�ڍ׃R�[�h2
                    dataRow[OLDPRMSETDTLNO2_COLUMN] = SubStringOfByte(newPrmSettingUWork.PrmSetDtlNoAfterOld.ToString().PadLeft(4, '0'), 10);
                    // �V�i��-�D�ǐݒ�ڍ׃R�[�h2
                    dataRow[NEWPRMSETDTLNO2_COLUMN] = SubStringOfByte(newPrmSettingUWork.PrmSetDtlNoAfterNew.ToString().PadLeft(4, '0'), 10);
                    // �G���[���e
                    dataRow[OUTNOTE_COLUMN] = newPrmSettingUWork.OutNote;
                }

                dataTable.Rows.Add(dataRow);
            }
        }
        #endregion
        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<

        #region �ݏo�ϊ�����
        // ����`�[�ԍ�
        private const string SALESSLIPNO_COLUMN = "SalesSlipNoRF";
        // ����s�ԍ�
        private const string ROWNO_COLUMN = "RowNoRF";
        // �󒍃X�e�[�^�X
        private const string ACPTANORDRSTATUS_COLUMN = "AcptAnOrdrStatusRF";
        // �G���[���e
        private const string ERROR_COLUMN = "ErrorRF";

        /// <summary>
        /// DataTable��Columns��ǉ�����
        /// </summary>
        /// <param name="dataTable">����DataTable</param>
        /// <param name="mode">���O�̃��[�h</param>
        /// <remarks>
        /// <br>Note       : DataTable��Columns��ǉ�����B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/26 ���V�� </br>
        /// <br>           : Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�</br>
        /// </remarks>
        //private void CreatTableShipment(ref DataTable dataTable) // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
        private void CreatTableShipment(ref DataTable dataTable, int mode) // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
        {
            dataTable.Columns.Add(SALESSLIPNO_COLUMN, typeof(string));                   //  ����`�[�ԍ�
            dataTable.Columns.Add(ROWNO_COLUMN, typeof(string));                         //  ����s�ԍ�
            dataTable.Columns.Add(ACPTANORDRSTATUS_COLUMN, typeof(string));              //  �󒍃X�e�[�^�X
            dataTable.Columns.Add(GOODSMAKERCD_COLUMN, typeof(string));                  //  ���i���[�J�[�R�[�h
            dataTable.Columns.Add(OLDGOODSNO_COLUMN, typeof(string));                    //  �ϊ��O���i�ԍ�
            dataTable.Columns.Add(NEWGOODSNO_COLUMN, typeof(string));                    //  �ϊ��㏤�i�ԍ�
            dataTable.Columns.Add(ERROR_COLUMN, typeof(string));                         //  �G���[���e

            //----- ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�----->>>>>
            //dataTable.Columns[SALESSLIPNO_COLUMN].Caption = SALESSLIPNO_COLUMN_NAME;// DEL 2015/03/02 ���V�� Redmine#44209 ���O�̍��ږ��̑Ή�
            dataTable.Columns[SALESSLIPNO_COLUMN].Caption = SubStringOfByte(SALESSLIPNO_COLUMN_NAME, 9);// ADD 2015/03/02 ���V�� Redmine#44209 ���O�̍��ږ��̑Ή�
            dataTable.Columns[ROWNO_COLUMN].Caption = ROWNO_COLUMN_NAME;
            dataTable.Columns[ACPTANORDRSTATUS_COLUMN].Caption = ACPTANORDRSTATUS_COLUMN_NAME;
            dataTable.Columns[GOODSMAKERCD_COLUMN].Caption = GOODSMAKERCD_COLUMN_NAME;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------>>>>>
            //dataTable.Columns[OLDGOODSNO_COLUMN].Caption = OLDGOODSNO_COLUMN_NAME;
            //dataTable.Columns[NEWGOODSNO_COLUMN].Caption = NEWGOODSNO_COLUMN_NAME;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------<<<<<
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------>>>>>
            dataTable.Columns[OLDGOODSNO_COLUMN].Caption = SubStringOfByte(OLDGOODSNO_COLUMN_NAME, 20);
            dataTable.Columns[NEWGOODSNO_COLUMN].Caption = SubStringOfByte(NEWGOODSNO_COLUMN_NAME, 20);
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̍��ږ��̑Ή�------<<<<<
            if (mode == SUCLOGMODE)
            {
                dataTable.Columns[ERROR_COLUMN].Caption = GOODSCHG_SUC_NAME;
            }
            else
            {
                dataTable.Columns[ERROR_COLUMN].Caption = GOODSCHG_ERR_NAME;
            }
            //----- ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�-----<<<<<
        }

        /// <summary>
        /// �������ʂ�ConvertToDataTable
        /// </summary>
        /// <param name="dataList">���i�Ǘ��f�[�^���X�g</param>
        /// <param name="dataTable">�e�[�v������</param>
        /// <remarks>
        /// <br>Note       : �������ʂ�ConvertToDataTable�ɍs���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/03/02 ���V�� </br>
        /// <br>           : Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�</br>
        /// </remarks>
        private void ConverToDataSetShipment(ArrayList dataList, ref DataTable dataTable)
        {
            foreach (ShipmentChangeWork shipmentChangeWork in dataList)
            {
                DataRow dataRow = dataTable.NewRow();

                // ����`�[�ԍ�
                dataRow[SALESSLIPNO_COLUMN] = shipmentChangeWork.SalesSlipNum.PadLeft(9, '0');
                // ����s�ԍ�
                //dataRow[ROWNO_COLUMN] = shipmentChangeWork.SalesRowNo; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                dataRow[ROWNO_COLUMN] = SubStringOfByte(shipmentChangeWork.SalesRowNo.ToString(), 10); // ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                // �󒍃X�e�[�^�X
                //dataRow[ACPTANORDRSTATUS_COLUMN] = shipmentChangeWork.AcptAnOdrStatus;// DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                dataRow[ACPTANORDRSTATUS_COLUMN] = SubStringOfByte(shipmentChangeWork.AcptAnOdrStatus.ToString().Trim(), 9);// ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�
                // ���i���[�J�[�R�[�h
                dataRow[GOODSMAKERCD_COLUMN] = shipmentChangeWork.MakerCode.ToString().PadLeft(4, '0');
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�----->>>>>
                //// �ϊ��O���i�ԍ�
                //dataRow[OLDGOODSNO_COLUMN] = shipmentChangeWork.OldGoodsNo.Trim().Replace("\"", "\"\"");
                //// �ϊ��㏤�i�ԍ�
                //dataRow[NEWGOODSNO_COLUMN] = shipmentChangeWork.NewGoodsNo.Trim().Replace("\"", "\"\"");
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�-----<<<<<
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�----->>>>>
                // �ϊ��O���i�ԍ�
                dataRow[OLDGOODSNO_COLUMN] = SubStringOfByte(shipmentChangeWork.OldGoodsNo.Trim(), 20);
                // �ϊ��㏤�i�ԍ�
                dataRow[NEWGOODSNO_COLUMN] = SubStringOfByte(shipmentChangeWork.NewGoodsNo.Trim(), 20);
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�-----<<<<<
                // �G���[���e
                dataRow[ERROR_COLUMN] = shipmentChangeWork.Message;

                dataTable.Rows.Add(dataRow);
            }
        }
        #endregion

        #region CSV�o��
        /// <summary>
        /// CSV�o�͏���
        /// </summary>
        /// <param name="parameter">�o��Info</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : CSV�o�͏������s���B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        private int DoOutPut(object parameter)
        {
            int status = 0;
            FormattedTextWriter formattedTextWriter = parameter as FormattedTextWriter;

            try
            {
                int totalCount;
                status = formattedTextWriter.TextOut(out totalCount);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_ERROR)
                {
                    return status;
                }
            }
            catch
            {
                status = -1;
            }
            return status;
        }
        #endregion

        //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�----->>>>>
        #region �o�C�g���w��؂蔲��
        /// <summary>
        /// ������@�o�C�g���w��؂蔲��
        /// </summary>
        /// <param name="orgString">���̕�����</param>
        /// <param name="byteCount">�o�C�g��</param>
        /// <returns>�w��o�C�g���Ő؂蔲����������</returns>
        /// <remarks>
        /// <br>Note       : ������@�o�C�g���w��؂蔲���B</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/03/02</br>
        /// </remarks>
        private string SubStringOfByte(string orgString, int byteCount)
        {
            if (byteCount <= 0)
            {
                return string.Empty;
            }

            Encoding encoding = Encoding.GetEncoding("Shift_JIS");

            string resultString = string.Empty;

            // ���炩���߁u�������v���w�肵�Đ؂蔲���Ă���
            // (���̒i�K��byte����<������>�`2*<������>�̊ԂɂȂ�)
            orgString = orgString.PadRight(byteCount).Substring(0, byteCount);

            int count;

            for (int i = orgString.Length; i >= 0; i--)
            {
                // �u�������v�����炷
                resultString = orgString.Substring(0, i);

                // �o�C�g�����擾���Ĕ���
                count = encoding.GetByteCount(resultString);
                if (count <= byteCount) break;
            }
            // �I�[�̋󔒂͍폜
            return resultString;
        }
        #endregion
        //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���O�̃t�H�[�}�b�g���u�Œ蒷�A�J���}��؂�v�ɕύX����Ή�-----<<<<<

        #endregion

        #region �e�}�X�^�i�ԕϊ�����

        #region �i�ԕϊ��}�X�^
        /// <summary>
        /// �i�ԕϊ��}�X�^�i�ԕϊ�����
        /// </summary>
        /// <param name="goodsChangeResultWork">���ʃ��[�N</param>
        /// <param name="cndtn">�������[�N</param>
        /// <param name="path">�p�[�X</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : �i�ԕϊ������������s��</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/25 �c���� </br>
        /// <br>           : Redmine#44209 �t�@�C�������̑Ή�</br>
        /// </remarks>
        private int ChgGoodsNoMst(ref GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork cndtn, string path)
        {
            // �J�E���g
            int readCntGoodsChgMst = 0;
            int loadCntGoodsChgMst = 0;
            int errCntGoodsChgMst = 0;
            // �t�@�C���̏����X�e�[�^�X
            int statusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int mstStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            // �G���[���b�Z�[�W
            string errMsg = string.Empty;
            // ���O�o�͗p
            ArrayList errDataList = new ArrayList();
            DataTable errDataTable = new DataTable();
            ArrayList sucDataList = new ArrayList();
            DataTable sucDataTable = new DataTable();
            // �o�̓t�@�C���p�[�X
            //----- DEL 2015/02/25 �c���� Redmine#44209 ----->>>>>
            //string errorLogFileName = Path.Combine(@path, "Cross_Index_Goodschg_error.csv");
            //string successLogFileName = Path.Combine(@path, "Cross_Index_Goodschg_Log.csv");
            //----- DEL 2015/02/25 �c���� Redmine#44209 -----<<<<<
            //----- ADD 2015/02/25 �c���� Redmine#44209 ----->>>>>
            string errorLogFileName = Path.Combine(@path, ct_CROSS_INDEX_GOODSCHG_ERROR);
            string successLogFileName = Path.Combine(@path, ct_CROSS_INDEX_GOODSCHG_LOG);
            //----- ADD 2015/02/25 �c���� Redmine#44209 -----<<<<<

            object addUpdWorkObj = null;
            object dataObjectList = null;

            status = this._iMeijiGoodsChgAllDB.GoodsChangeMst(cndtn, out addUpdWorkObj, out dataObjectList, out readCntGoodsChgMst, out loadCntGoodsChgMst, out errCntGoodsChgMst, out errMsg);
            //�G���[�t�@�C��
            errDataList = dataObjectList as ArrayList;
            if (errDataList != null && errDataList.Count > 0)
            {
                TableGoodsChgMst(ref errDataTable);
                ConverToDataSetGoodsChgMst(errDataList, ref errDataTable);
            }
            if (errDataTable.Rows.Count > 0)
            {
                mstStatusErrCSV = this.DoCSVOutPrc(GOODSNOCHGERRMODE, LOGKINGERR, errDataTable, errorLogFileName, ref goodsChangeResultWork);
            }
            //���O�t�@�C��
            sucDataList = addUpdWorkObj as ArrayList;
            if (sucDataList != null && sucDataList.Count > 0)
            {
                TableGoodsChgMst(ref sucDataTable);
                ConverToDataSetGoodsChgMst(sucDataList, ref sucDataTable);
            }
            if (sucDataTable.Rows.Count > 0)
            {
                statusSucCSV = this.DoCSVOutPrc(GOODSNOCHGSUCMODE, LOGKINGSUC, sucDataTable, successLogFileName, ref goodsChangeResultWork);
            }
            goodsChangeResultWork.ReadCntGoodsChgMst = readCntGoodsChgMst;
            goodsChangeResultWork.LoadCntGoodsChgMst = loadCntGoodsChgMst;
            goodsChangeResultWork.ErrCntGoodsChgMst = errCntGoodsChgMst;
            goodsChangeResultWork.ErrMsg = errMsg;
            goodsChangeResultWork.MstStatusErrCSV = mstStatusErrCSV;
                
            return status;
        }
        #endregion

        #region ���i�݌Ƀ}�X�^
        /// <summary>
        /// ���i�݌Ƀ}�X�^�i�ԕϊ�����
        /// </summary>
        /// <param name="goodsChangeResultWork">���ʃ��[�N</param>
        /// <param name="cndtn">�������[�N</param>
        /// <param name="path">�p�[�X</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : �i�ԕϊ������������s��</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/25 �c���� </br>
        /// <br>           : Redmine#44209 �t�@�C�������̑Ή�</br>
        /// <br>UpdateNote : 2015/02/26 ���V�� </br>
        /// <br>           : Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�</br>
        /// </remarks>
        private int ChgGoodsStockPrc(ref GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork cndtn, string path)
        {
            int readCntGoodsAll = 0;
            int loadCntGoodsAll = 0;
            int errCntGoodsAll = 0;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
            //int errorCntGoods = 0;
            //int errorCntPrice = 0;
            //int errorCntStock = 0;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            #region �߂�p�����[�^
            object goodsUpdateSucObj;
            object goodsUpdateErrObj;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
            //object priceUpdateSucObj;
            //object priceUpdateErrObj;
            //object stockUpdateSucObj;
            //object stockUpdateErrObj;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            int readCntGoods = 0;
            //int loadCntGoods = 0; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
            int readCntPrice = 0;
            //int loadCntPrice = 0; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
            int readCntStock = 0;
            //int loadCntStock = 0; // DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�
            #endregion
            #region �b�r�u�o�͊֌W
            DataTable goodsDataTableSuc = new DataTable();
            DataTable goodsDataTableErr = new DataTable();
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
            //DataTable priceDataTableSuc = new DataTable();
            //DataTable priceDataTableErr = new DataTable();
            //DataTable stockDataTableSuc = new DataTable();
            //DataTable stockDataTableErr = new DataTable();
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            ArrayList goodsSucDataList = new ArrayList();
            ArrayList goodsErrDataList = new ArrayList();
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
            //ArrayList priceSucDataList = new ArrayList();
            //ArrayList priceErrDataList = new ArrayList();
            //ArrayList stockSucDataList = new ArrayList();
            //ArrayList stockErrDataList = new ArrayList();
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            int goodsStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int goodsStatusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
            //int priceStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //int priceStatusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //int stockStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //int stockStatusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //----- DEL 2015/02/25 �c���� Redmine#44209 ----->>>>>
            //string goodsErrorLogFileName = Path.Combine(@path, "Goods_error.csv");
            //string goodsSuccessLogFileName = Path.Combine(@path, "Goods_Log.csv");
            //string priceErrorLogFileName = Path.Combine(@path, "GoodsPrice_error.csv");
            //string priceSuccessLogFileName = Path.Combine(@path, "GoodsPrice_Log.csv");
            //string stockErrorLogFileName = Path.Combine(@path, "Stock_error.csv");
            //string stockSuccessLogFileName = Path.Combine(@path, "Stock_Log.csv");
            //----- DEL 2015/02/25 �c���� Redmine#44209 -----<<<<<
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
            //----- ADD 2015/02/25 �c���� Redmine#44209 ----->>>>>
            //string goodsErrorLogFileName = Path.Combine(@path, ct_GOODS_ERROR);
            //string goodsSuccessLogFileName = Path.Combine(@path, ct_GOODS_LOG);
            //string priceErrorLogFileName = Path.Combine(@path, ct_GOODSPRICE_ERROR);
            //string priceSuccessLogFileName = Path.Combine(@path, ct_GOODSPRICE_LOG);
            //string stockErrorLogFileName = Path.Combine(@path, ct_STOCK_ERROR);
            //string stockSuccessLogFileName = Path.Combine(@path, ct_STOCK_LOG);
            //----- ADD 2015/02/25 �c���� Redmine#44209 -----<<<<<
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
            string goodsErrorLogFileName = Path.Combine(@path, ct_GOODSSTOCK_ERROR);
            string goodsSuccessLogFileName = Path.Combine(@path, ct_GOODSSTOCK_LOG);
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            #endregion

            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
            //status = this._iMeijiGoodsChgAllDB.GoodsChangeGoodsStock(cndtn, out goodsUpdateSucObj, out goodsUpdateErrObj, out priceUpdateSucObj, out priceUpdateErrObj,
            //    out stockUpdateSucObj, out stockUpdateErrObj, out readCntGoods, out readCntPrice, out readCntStock);
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
            status = this._iMeijiGoodsChgAllDB.GoodsChangeGoodsStock(cndtn, out goodsUpdateSucObj, out goodsUpdateErrObj, out readCntGoods, out readCntPrice, out readCntStock);
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
                #region DELETE
                //// �R���p���[�^
                //PricePrcCompare pricePrcCompare = new PricePrcCompare();
                //StockPrcCompare stockPrcCompare = new StockPrcCompare();

                //// ���O
                //#region ���i�}�X�^
                //goodsSucDataList = goodsUpdateSucObj as ArrayList;
                //if (goodsSucDataList != null && goodsSucDataList.Count > 0)
                //{
                //    loadCntGoods = goodsSucDataList.Count;
                //    //TableGoodsStock(ref goodsDataTableSuc); // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                //    TableGoodsStock(ref goodsDataTableSuc, SUCLOGMODE); // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                //    ConverToDataSetGoodsStock(goodsSucDataList, ref goodsDataTableSuc, 1);
                //}
                //if (goodsDataTableSuc.Rows.Count > 0)
                //{
                //    goodsStatusSucCSV = this.DoCSVOutPrc(GOODSMSTMODE, LOGKINGSUC, goodsDataTableSuc, goodsSuccessLogFileName, ref goodsChangeResultWork);
                //}
                //#endregion
                //#region ���i�}�X�^
                //priceSucDataList = priceUpdateSucObj as ArrayList;
                //priceSucDataList.Sort(pricePrcCompare);
                //if (priceSucDataList != null && priceSucDataList.Count > 0)
                //{
                //    loadCntPrice = priceSucDataList.Count;
                //    //TableGoodsStock(ref priceDataTableSuc); // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                //    TableGoodsStock(ref priceDataTableSuc, SUCLOGMODE); // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                //    ConverToDataSetGoodsStock(priceSucDataList, ref priceDataTableSuc, 2);
                //}
                //if (priceDataTableSuc.Rows.Count > 0)
                //{
                //    priceStatusSucCSV = this.DoCSVOutPrc(PRICEMSTMODE, LOGKINGSUC, priceDataTableSuc, priceSuccessLogFileName, ref goodsChangeResultWork);
                //}
                //#endregion
                //#region �݌Ƀ}�X�^
                //stockSucDataList = stockUpdateSucObj as ArrayList;
                //stockSucDataList.Sort(stockPrcCompare);
                //if (stockSucDataList != null && stockSucDataList.Count > 0)
                //{
                //    loadCntStock = stockSucDataList.Count;
                //    //TableGoodsStock(ref stockDataTableSuc); // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                //    TableGoodsStock(ref stockDataTableSuc, SUCLOGMODE); // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                //    ConverToDataSetGoodsStock(stockSucDataList, ref stockDataTableSuc, 3);
                //}
                //if (stockDataTableSuc.Rows.Count > 0)
                //{
                //    stockStatusSucCSV = this.DoCSVOutPrc(STOCKMSTMODE, LOGKINGSUC, stockDataTableSuc, stockSuccessLogFileName, ref goodsChangeResultWork);
                //}
                //#endregion

                //// �G���[���O
                //#region ���i�}�X�^
                //goodsErrDataList = goodsUpdateErrObj as ArrayList;
                //if (goodsErrDataList != null && goodsErrDataList.Count > 0)
                //{
                //    errorCntGoods = goodsErrDataList.Count;
                //    //TableGoodsStock(ref goodsDataTableErr); // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                //    TableGoodsStock(ref goodsDataTableErr, ERRLOGMODE); // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                //    ConverToDataSetGoodsStock(goodsErrDataList, ref goodsDataTableErr, 1);
                //}
                //if (goodsDataTableErr.Rows.Count > 0)
                //{
                //    goodsStatusErrCSV = this.DoCSVOutPrc(GOODSMSTMODE, LOGKINGERR, goodsDataTableErr, goodsErrorLogFileName, ref goodsChangeResultWork);
                //}
                //#endregion
                //#region ���i�}�X�^
                //priceErrDataList = priceUpdateErrObj as ArrayList;
                //priceErrDataList.Sort(pricePrcCompare);
                //if (priceErrDataList != null && priceErrDataList.Count > 0)
                //{
                //    errorCntPrice = priceErrDataList.Count;
                //    //TableGoodsStock(ref priceDataTableErr); // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                //    TableGoodsStock(ref priceDataTableErr, ERRLOGMODE); // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                //    ConverToDataSetGoodsStock(priceErrDataList, ref priceDataTableErr, 2);
                //}
                //if (priceDataTableErr.Rows.Count > 0)
                //{
                //    priceStatusErrCSV = this.DoCSVOutPrc(PRICEMSTMODE, LOGKINGERR, priceDataTableErr, priceErrorLogFileName, ref goodsChangeResultWork);
                //}
                //#endregion
                //#region �݌Ƀ}�X�^
                //stockErrDataList = stockUpdateErrObj as ArrayList;
                //stockErrDataList.Sort(stockPrcCompare);
                //if (stockErrDataList != null && stockErrDataList.Count > 0)
                //{
                //    errorCntStock = stockErrDataList.Count;
                //    //TableGoodsStock(ref stockDataTableErr); // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                //    TableGoodsStock(ref stockDataTableErr, ERRLOGMODE); // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                //    ConverToDataSetGoodsStock(stockErrDataList, ref stockDataTableErr, 3);
                //}
                //if (stockDataTableErr.Rows.Count > 0)
                //{
                //    stockStatusErrCSV = this.DoCSVOutPrc(STOCKMSTMODE, LOGKINGERR, stockDataTableErr, stockErrorLogFileName, ref goodsChangeResultWork);
                //}
                //#endregion

                //readCntGoodsAll = readCntGoods + readCntPrice + readCntStock;
                //loadCntGoodsAll = loadCntGoods + loadCntPrice + loadCntStock;
                //errCntGoodsAll = errorCntGoods + errorCntPrice + errorCntStock;
                #endregion
                //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<

                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
                GoodsStockPrcCompare goodsStockPrcCompare = new GoodsStockPrcCompare();

                // ���O
                #region ���i�}�X�^
                goodsSucDataList = goodsUpdateSucObj as ArrayList;
                if (goodsSucDataList != null && goodsSucDataList.Count > 0)
                {
                    loadCntGoodsAll = goodsSucDataList.Count;
                    TableGoodsStock(ref goodsDataTableSuc, SUCLOGMODE);
                    ConverToDataSetGoodsStock(goodsSucDataList, ref goodsDataTableSuc);
                }
                if (goodsDataTableSuc.Rows.Count > 0)
                {
                    goodsStatusSucCSV = this.DoCSVOutPrc(GOODSMSTMODE, LOGKINGSUC, goodsDataTableSuc, goodsSuccessLogFileName, ref goodsChangeResultWork);
                }
                #endregion

                // �G���[���O
                #region ���i�}�X�^
                goodsErrDataList = goodsUpdateErrObj as ArrayList;
                if (goodsErrDataList != null && goodsErrDataList.Count > 0)
                {
                    errCntGoodsAll = goodsErrDataList.Count;
                    TableGoodsStock(ref goodsDataTableErr, ERRLOGMODE);
                    ConverToDataSetGoodsStock(goodsErrDataList, ref goodsDataTableErr);
                }
                if (goodsDataTableErr.Rows.Count > 0)
                {
                    goodsStatusErrCSV = this.DoCSVOutPrc(GOODSMSTMODE, LOGKINGERR, goodsDataTableErr, goodsErrorLogFileName, ref goodsChangeResultWork);
                }
                #endregion

                readCntGoodsAll = readCntGoods + readCntPrice + readCntStock;
                //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            }
            goodsChangeResultWork.ReadCntGoodsAll = readCntGoodsAll;
            goodsChangeResultWork.LoadCntGoodsAll = loadCntGoodsAll;
            goodsChangeResultWork.ErrCntGoodsAll = errCntGoodsAll;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
            //goodsChangeResultWork.ErrorCntGoods = errorCntGoods;
            //goodsChangeResultWork.ErrorCntPrice = errorCntPrice;
            //goodsChangeResultWork.ErrorCntStock =errorCntStock;
            //goodsChangeResultWork.GoodsStatusErrCSV =goodsStatusErrCSV;
            //goodsChangeResultWork.PriceStatusErrCSV = priceStatusErrCSV;
            //goodsChangeResultWork.StockStatusErrCSV = stockStatusErrCSV;
            //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
            goodsChangeResultWork.ErrorCntGoods = errCntGoodsAll;
            goodsChangeResultWork.GoodsStatusErrCSV =goodsStatusErrCSV;
            //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<

            return status;
        }
        #endregion

        #region ���i�Ǘ����}�X�^
        /// <summary>
        /// ���i�Ǘ����}�X�^�i�ԕϊ�����
        /// </summary>
        /// <param name="goodsChangeResultWork">���ʃ��[�N</param>
        /// <param name="cndtn">�������[�N</param>
        /// <param name="path">�p�[�X</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : �i�ԕϊ������������s��</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/25 �c���� </br>
        /// <br>           : Redmine#44209 �t�@�C�������̑Ή�</br>
        /// <br>UpdateNote : 2015/02/26 ���V�� </br>
        /// <br>           : Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�</br>
        /// </remarks>
        private int ChgGoodsMngPrc(ref GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork cndtn, string path)
        {
            int readCntMng = 0;
            int loadCntMng = 0;
            int errorCntMng = 0;

            // �߂�p�����[�^
            object mngUpdateSucObj;
            object mngUpdateErrObj;

            // �b�r�u�o�͊֌W
            DataTable mngDataTableErr = new DataTable();
            ArrayList errDataList = new ArrayList();
            DataTable mngDataTableSuc = new DataTable();
            ArrayList sucDataList = new ArrayList();

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int statusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int mngStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //----- DEL 2015/02/25 �c���� Redmine#44209 ----->>>>>
            //string errorLogFileName = Path.Combine(@path, "GoodsMng_error.csv");
            //string successLogFileName = Path.Combine(@path, "GoodsMng_Log.csv");
            //----- DEL 2015/02/25 �c���� Redmine#44209 -----<<<<<
            //----- ADD 2015/02/25 �c���� Redmine#44209 ----->>>>>
            string errorLogFileName = Path.Combine(@path, ct_GOODSMNG_ERROR);
            string successLogFileName = Path.Combine(@path, ct_GOODSMNG_LOG);
            //----- ADD 2015/02/25 �c���� Redmine#44209 -----<<<<<

            status = this._iMeijiGoodsChgAllDB.GoodsChangeGoodsMng(cndtn, out mngUpdateSucObj, out mngUpdateErrObj, out readCntMng);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                #region ���O
                sucDataList = mngUpdateSucObj as ArrayList;
                if (sucDataList != null && sucDataList.Count > 0)
                {
                    loadCntMng = sucDataList.Count;
                    //TableMng(ref mngDataTableSuc); // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    TableMng(ref mngDataTableSuc, SUCLOGMODE); // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    ConverToDataSetMng(sucDataList, ref mngDataTableSuc);
                }
                if (mngDataTableSuc.Rows.Count > 0)
                {
                    statusSucCSV = this.DoCSVOutPrc(GOODSMNGMSTMODE, LOGKINGSUC, mngDataTableSuc, successLogFileName, ref goodsChangeResultWork);
                }
                #endregion

                #region �G���[���O
                errDataList = mngUpdateErrObj as ArrayList;
                if (errDataList != null && errDataList.Count > 0)
                {
                    errorCntMng = errDataList.Count;
                    //TableMng(ref mngDataTableErr); // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    TableMng(ref mngDataTableErr, ERRLOGMODE); // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    ConverToDataSetMng(errDataList, ref mngDataTableErr);
                }
                if (mngDataTableErr.Rows.Count > 0)
                {
                    mngStatusErrCSV = this.DoCSVOutPrc(GOODSMNGMSTMODE, LOGKINGERR, mngDataTableErr, errorLogFileName, ref goodsChangeResultWork);
                }
                #endregion
            }

            goodsChangeResultWork.ReadCntMng = readCntMng;
            goodsChangeResultWork.LoadCntMng = loadCntMng;
            goodsChangeResultWork.ErrorCntMng = errorCntMng;
            goodsChangeResultWork.MngStatusErrCSV = mngStatusErrCSV;

            return status;
        }
        #endregion

        #region �|���}�X�^
        /// <summary>
        /// �|���}�X�^�i�ԕϊ�����
        /// </summary>
        /// <param name="goodsChangeResultWork">���ʃ��[�N</param>
        /// <param name="cndtn">�������[�N</param>
        /// <param name="path">�p�[�X</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : �i�ԕϊ������������s��</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/25 �c���� </br>
        /// <br>           : Redmine#44209 �t�@�C�������̑Ή�</br>
        /// <br>UpdateNote : 2015/02/26 ���V�� </br>
        /// <br>           : Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�</br>
        /// </remarks>
        private int ChgRatePrc(ref GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork cndtn, string path)
        {
            int readCntRate = 0;
            int loadCntRate = 0;
            int errorCntRate = 0;
            // �߂�p�����[�^
            object rateUpdateSucObj;
            object rateUpdateErrObj;

            // �b�r�u�o�͊֌W
            DataTable rateDataTableErr = new DataTable();
            ArrayList errDataList = new ArrayList();
            DataTable rateDataTableSuc = new DataTable();
            ArrayList sucDataList = new ArrayList();
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int statusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int rateStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //----- DEL 2015/02/25 �c���� Redmine#44209 ----->>>>>
            //string errorLogFileName = Path.Combine(@path, "Rate_error.csv");
            //string successLogFileName = Path.Combine(@path, "Rate_Log.csv");
            //----- DEL 2015/02/25 �c���� Redmine#44209 -----<<<<<
            //----- ADD 2015/02/25 �c���� Redmine#44209 ----->>>>>
            string errorLogFileName = Path.Combine(@path, ct_RATE_ERROR);
            string successLogFileName = Path.Combine(@path, ct_RATE_LOG);
            //----- ADD 2015/02/25 �c���� Redmine#44209 -----<<<<<

            status = this._iMeijiGoodsChgAllDB.GoodsChangeRate(cndtn, out rateUpdateSucObj, out rateUpdateErrObj, out readCntRate);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                #region ���O
                sucDataList = rateUpdateSucObj as ArrayList;
                if (sucDataList != null && sucDataList.Count > 0)
                {
                    loadCntRate = sucDataList.Count;
                    //TableRate(ref rateDataTableSuc); // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    TableRate(ref rateDataTableSuc, SUCLOGMODE); // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    ConverToDataSetRate(sucDataList, ref rateDataTableSuc);
                }
                if (rateDataTableSuc.Rows.Count > 0)
                {
                    statusSucCSV = this.DoCSVOutPrc(RATEMSTMODE, LOGKINGSUC, rateDataTableSuc, successLogFileName, ref goodsChangeResultWork);
                }
                #endregion

                #region �G���[���O
                errDataList = rateUpdateErrObj as ArrayList;
                if (errDataList != null && errDataList.Count > 0)
                {
                    errorCntRate = errDataList.Count;
                    //TableRate(ref rateDataTableErr); // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    TableRate(ref rateDataTableErr, ERRLOGMODE); // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    ConverToDataSetRate(errDataList, ref rateDataTableErr);
                }
                if (rateDataTableErr.Rows.Count > 0)
                {
                    rateStatusErrCSV = this.DoCSVOutPrc(RATEMSTMODE, LOGKINGERR, rateDataTableErr, errorLogFileName, ref goodsChangeResultWork);
                }
                #endregion
            }
            goodsChangeResultWork.ReadCntRate = readCntRate;
            goodsChangeResultWork.LoadCntRate = loadCntRate;
            goodsChangeResultWork.ErrorCntRate = errorCntRate;
            goodsChangeResultWork.RateStatusErrCSV = rateStatusErrCSV;

            return status;
        }
        #endregion

        #region �����}�X�^
        /// <summary>
        /// �����}�X�^�i�ԕϊ�����
        /// </summary>
        /// <param name="goodsChangeResultWork">���ʃ��[�N</param>
        /// <param name="cndtn">�������[�N</param>
        /// <param name="path">�p�[�X</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : �i�ԕϊ������������s��</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/25 �c���� </br>
        /// <br>           : Redmine#44209 �t�@�C�������̑Ή�</br>
        /// <br>UpdateNote : 2015/02/26 ���V�� </br>
        /// <br>           : Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�</br>
        /// </remarks>
        private int ChgJoinPrc(ref GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork cndtn, string path)
        {
            int readCntJoin = 0;
            int loadCntJoin = 0;
            int errorCntJoin = 0;
            ArrayList errDataList = new ArrayList();
            DataTable errDataTable = new DataTable();
            ArrayList sucDataList = new ArrayList();
            DataTable sucDataTable = new DataTable();
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int joinStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int statusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //----- DEL 2015/02/25 �c���� Redmine#44209 ----->>>>>
            //string errorLogFileName = Path.Combine(@path, "JoinParts_error.csv");
            //string successLogFileName = Path.Combine(@path, "JoinParts_Log.csv");
            //----- DEL 2015/02/25 �c���� Redmine#44209 -----<<<<<
            //----- ADD 2015/02/25 �c���� Redmine#44209 ----->>>>>
            string errorLogFileName = Path.Combine(@path, ct_JOINPARTS_ERROR);
            string successLogFileName = Path.Combine(@path, ct_JOINPARTS_LOG);
            //----- ADD 2015/02/25 �c���� Redmine#44209 -----<<<<<

            object addUpdWorkObj = null;
            object dataObjectList = null;

            status = this._iMeijiGoodsChgAllDB.GoodsChangeJoin(cndtn, out addUpdWorkObj, out dataObjectList, out readCntJoin);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                errDataList = dataObjectList as ArrayList;
                if (errDataList != null && errDataList.Count > 0)
                {
                    errorCntJoin = errDataList.Count;
                    //TableJoin(ref errDataTable); // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    TableJoin(ref errDataTable, ERRLOGMODE); // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    ConverToDataSetTableJoin(errDataList, ref errDataTable);
                }
                if (errDataTable.Rows.Count > 0)
                {
                    joinStatusErrCSV = this.DoCSVOutPrc(JOINMSTMODE, LOGKINGERR, errDataTable, errorLogFileName, ref goodsChangeResultWork);
                }

                sucDataList = addUpdWorkObj as ArrayList;
                if (sucDataList != null && sucDataList.Count > 0)
                {
                    loadCntJoin = sucDataList.Count;
                    //TableJoin(ref sucDataTable); // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    TableJoin(ref sucDataTable, SUCLOGMODE); // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    ConverToDataSetTableJoin(sucDataList, ref sucDataTable);
                }
                if (sucDataTable.Rows.Count > 0)
                {
                    statusSucCSV = this.DoCSVOutPrc(JOINMSTMODE, LOGKINGSUC, sucDataTable, successLogFileName, ref goodsChangeResultWork);
                }
            }
            goodsChangeResultWork.ReadCntJoin = readCntJoin;
            goodsChangeResultWork.LoadCntJoin = loadCntJoin;
            goodsChangeResultWork.ErrorCntJoin = errorCntJoin;
            goodsChangeResultWork.JoinStatusErrCSV = joinStatusErrCSV;

            return status;
        }
        #endregion

        #region ��փ}�X�^
        /// <summary>
        /// ��փ}�X�^�i�ԕϊ�����
        /// </summary>
        /// <param name="goodsChangeResultWork">���ʃ��[�N</param>
        /// <param name="cndtn">�������[�N</param>
        /// <param name="path">�p�[�X</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : �i�ԕϊ������������s��</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/25 �c���� </br>
        /// <br>           : Redmine#44209 �t�@�C�������̑Ή�</br>
        /// <br>UpdateNote : 2015/02/26 ���V�� </br>
        /// <br>           : Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�</br>
        /// </remarks>
        private int ChgPartsPrc(ref GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork cndtn, string path)
        {
            int readCntParts = 0;
            int loadCntParts = 0;
            int errCntParts = 0;

            ArrayList errDataList = new ArrayList();
            DataTable errDataTable = new DataTable();
            ArrayList sucDataList = new ArrayList();
            DataTable sucDataTable = new DataTable();

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int statusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int partsStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //----- DEL 2015/02/25 �c���� Redmine#44209 ----->>>>>
            //string errorLogFileName = Path.Combine(@path, "Subst_error.csv");
            //string successLogFileName = Path.Combine(@path, "Subst_Log.csv");
            //----- DEL 2015/02/25 �c���� Redmine#44209 -----<<<<<
            //----- ADD 2015/02/25 �c���� Redmine#44209 ----->>>>>
            string errorLogFileName = Path.Combine(@path, ct_SUBST_ERROR);
            string successLogFileName = Path.Combine(@path, ct_SUBST_LOG);
            //----- ADD 2015/02/25 �c���� Redmine#44209 -----<<<<<

            object addUpdWorkObj = null;
            object dataObjectList = null;
            status = this._iMeijiGoodsChgAllDB.GoodsChangeParts(cndtn, out addUpdWorkObj, out dataObjectList, out readCntParts);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                errDataList = dataObjectList as ArrayList;
                if (errDataList != null && errDataList.Count > 0)
                {
                    errCntParts = errDataList.Count;
                    //TableGoodsPartsChgMst(ref errDataTable); // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    TableGoodsPartsChgMst(ref errDataTable, ERRLOGMODE); // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    ConverToDataSetGoodsPartsChgMst(errDataList, ref errDataTable);
                }
                if (errDataTable.Rows.Count > 0)
                {
                    partsStatusErrCSV = this.DoCSVOutPrc(PARTSMSTMODE, LOGKINGERR, errDataTable, errorLogFileName, ref goodsChangeResultWork);
                }

                sucDataList = addUpdWorkObj as ArrayList;
                if (sucDataList != null && sucDataList.Count > 0)
                {
                    loadCntParts = sucDataList.Count;
                    //TableGoodsPartsChgMst(ref sucDataTable); // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    TableGoodsPartsChgMst(ref sucDataTable, SUCLOGMODE); // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    ConverToDataSetGoodsPartsChgMst(sucDataList, ref sucDataTable);
                }
                if (sucDataTable.Rows.Count > 0)
                {
                    statusSucCSV = this.DoCSVOutPrc(PARTSMSTMODE, LOGKINGSUC, sucDataTable, successLogFileName, ref goodsChangeResultWork);
                }
            }
            goodsChangeResultWork.ReadCntParts = readCntParts;
            goodsChangeResultWork.LoadCntParts = loadCntParts;
            goodsChangeResultWork.ErrCntParts = errCntParts;
            goodsChangeResultWork.PartsStatusErrCSV = partsStatusErrCSV;

            return status;
        }
        #endregion

        #region �Z�b�g�}�X�^
        /// <summary>
        /// �Z�b�g�}�X�^�i�ԕϊ�����
        /// </summary>
        /// <param name="goodsChangeResultWork">���ʃ��[�N</param>
        /// <param name="cndtn">�������[�N</param>
        /// <param name="path">�p�[�X</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : �i�ԕϊ������������s��</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/25 �c���� </br>
        /// <br>           : Redmine#44209 �t�@�C�������̑Ή�</br>
        /// <br>UpdateNote : 2015/02/26 ���V�� </br>
        /// <br>           : Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�</br>
        /// </remarks>
        private int ChgGoodsSetPrc(ref GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork cndtn, string path)
        {
            object addUpdWorkObjSet;
            object dataObjectListSet;

            int readCntSet = 0;
            int loadCntSet = 0;
            int errCntSet = 0;

            ArrayList errDataList = new ArrayList();
            DataTable errDataTable = new DataTable();
            ArrayList sucDataList = new ArrayList();
            DataTable sucDataTable = new DataTable();

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int statusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int setStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //----- DEL 2015/02/25 �c���� Redmine#44209 ----->>>>>
            //string errorLogFileName = Path.Combine(@path, "GoodsSet_error.csv");
            //string successLogFileName = Path.Combine(@path, "GoodsSet_Log.csv");
            //----- DEL 2015/02/25 �c���� Redmine#44209 -----<<<<<
            //----- ADD 2015/02/25 �c���� Redmine#44209 ----->>>>>
            string errorLogFileName = Path.Combine(@path, ct_GOODSSET_ERROR);
            string successLogFileName = Path.Combine(@path, ct_GOODSSET_LOG);
            //----- ADD 2015/02/25 �c���� Redmine#44209 -----<<<<<

            status = this._iMeijiGoodsChgAllDB.GoodsChangeSet(cndtn, out addUpdWorkObjSet, out dataObjectListSet, out readCntSet);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                errDataList = dataObjectListSet as ArrayList;
                if (errDataList != null && errDataList.Count > 0)
                {
                    errCntSet = errDataList.Count;
                    //TableGoodsSetChgMst(ref errDataTable); // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    TableGoodsSetChgMst(ref errDataTable, ERRLOGMODE); // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    ConverToDataSetGoodsSetChgMst(errDataList, ref errDataTable);
                }
                if (errDataTable.Rows.Count > 0)
                {
                    setStatusErrCSV = this.DoCSVOutPrc(GOODSSETMSTMODE, LOGKINGERR, errDataTable, errorLogFileName, ref goodsChangeResultWork);
                }

                sucDataList = addUpdWorkObjSet as ArrayList;
                if (sucDataList != null && sucDataList.Count > 0)
                {
                    loadCntSet = sucDataList.Count;
                    //TableGoodsSetChgMst(ref sucDataTable); // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    TableGoodsSetChgMst(ref sucDataTable, SUCLOGMODE); // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                    ConverToDataSetGoodsSetChgMst(sucDataList, ref sucDataTable);
                }
                if (sucDataTable.Rows.Count > 0)
                {
                    statusSucCSV = this.DoCSVOutPrc(GOODSSETMSTMODE, LOGKINGSUC, sucDataTable, successLogFileName, ref goodsChangeResultWork);
                }
            }
            goodsChangeResultWork.ReadCntSet = readCntSet;
            goodsChangeResultWork.LoadCntSet = loadCntSet;
            goodsChangeResultWork.ErrCntSet = errCntSet;
            goodsChangeResultWork.SetStatusErrCSV = setStatusErrCSV;

            return status;
        }
        #endregion

        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�----->>>>>
        #region �D�ǐݒ�}�X�^
        /// <summary>
        /// �D�ǐݒ�}�X�^����
        /// </summary>
        /// <param name="goodsChangeResultWork">���ʃ��[�N</param>
        /// <param name="cndtn">�������[�N</param>
        /// <param name="path">�p�[�X</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : �D�ǐݒ�}�X�^�ϊ��������s��</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/02/27</br>
        /// </remarks>
        private int ChgPrmSettingPrc(ref GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork cndtn, string path)
        {
            //----- DEL 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------>>>>>
            //object sucObjectList;
            //object errObjectList;
            //----- DEL 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------<<<<<
            //----- ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------>>>>>
            object sucObjectList = null;
            object errObjectList = null;
            //----- ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------<<<<<
            int loadCntPrm = 0;
            int errCntPrm = 0;

            ArrayList errDataList = new ArrayList();
            DataTable errDataTable = new DataTable();
            ArrayList sucDataList = new ArrayList();
            DataTable sucDataTable = new DataTable();
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int prmStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int prmStatusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            string errorLogFileName = Path.Combine(@path, ct_PRMSETTING_ERROR);
            string successLogFileName = Path.Combine(@path, ct_PRMSETTING_LOG);

            int readCount = 0;
            int loginCount = 0;
            string errMsg = "";
            bool flag = false;

            //----- ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------>>>>>
            #region �D�ǐݒ�}�X�^�񋟕��f�[�^���擾����
            Dictionary<string, PrmSettingWork> offerPrmDic;
            status = GetOfferPrm(out offerPrmDic);
            #endregion
            //----- ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------<<<<<

            //�D�ǐݒ�}�X�^�ϊ�����
            //status = this._iMeijiGoodsChgAllDB.PrmSettingChange(cndtn, out sucObjectList, out errObjectList, out readCount, out loginCount, out errMsg, out flag);// DEL 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�
            //----- ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------>>>>>
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_EOF
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                status = this._iMeijiGoodsChgAllDB.PrmSettingChange(cndtn, offerPrmDic, out sucObjectList, out errObjectList, out readCount, out loginCount, out errMsg, out flag);
            }
            else
            {
                errMsg = this.ct_PRMOFFER_ERROR;
            }
            //----- ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------<<<<<

            // �G���[���Olist
            errDataList = errObjectList as ArrayList;
            // �X�V���Olist
            sucDataList = sucObjectList as ArrayList;

            // �G���[���O
            if (errDataList != null && errDataList.Count > 0)
            {
                errCntPrm = errDataList.Count;
                CreatTablePrmSetting(ref errDataTable, ERRLOGMODE);
                ConverToDataSetPrm(errDataList, ref errDataTable, flag);
            }
            if (errDataTable.Rows.Count > 0)
            {
                prmStatusErrCSV = this.DoCSVOutPrc(PRMUPDATEERRMODE, LOGKINGERR, errDataTable, errorLogFileName, ref goodsChangeResultWork);
            }

            // �X�V�������O
            if (sucDataList != null && sucDataList.Count > 0)
            {
                loadCntPrm = loginCount;
                CreatTablePrmSetting(ref sucDataTable, SUCLOGMODE);
                ConverToDataSetPrm(sucDataList, ref sucDataTable, false);
            }
            if (sucDataTable.Rows.Count > 0)
            {
                prmStatusSucCSV = this.DoCSVOutPrc(PRMSUCMODE, LOGKINGSUC, sucDataTable, successLogFileName, ref goodsChangeResultWork);
            }

            goodsChangeResultWork.ReadCntPrm = readCount;
            goodsChangeResultWork.LoadCntPrm = loadCntPrm;
            goodsChangeResultWork.ErrCntPrm = errCntPrm;
            goodsChangeResultWork.PrmStatusErrCSV = prmStatusErrCSV;
            goodsChangeResultWork.ErrMsg = errMsg;

            return status;
        }
        #endregion
        //----- ADD 2015/02/27 �i�N Redmine#44209 �D�ǐݒ�}�X�^�ϊ������̋@�\�ǉ�-----<<<<<

        //----- ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------>>>>>
        /// <summary>
        /// �D�ǐݒ�}�X�^�񋟕��f�[�^���擾����
        /// </summary>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : �D�ǐݒ�}�X�^�񋟕��f�[�^���擾����</br>
        /// <br>Programmer : ���V��</br>
        /// <br>Date       : 2015/03/16</br>
        /// </remarks>
        private int GetOfferPrm(out Dictionary<string, PrmSettingWork> offerPrmDic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            offerPrmDic = new Dictionary<string, PrmSettingWork>();
            object retObj;
            try
            {
                // �񋟃f�[�^�̌���
                status = this._iofferPrimeSettingSearchDB.Search(out retObj);
                string offerPrmKey = "";

                if (retObj != null)
                {
                    foreach (PrmSettingWork wkPrimeSettingWork in (ArrayList)retObj)
                    {
                        offerPrmKey = wkPrimeSettingWork.PartsMakerCd.ToString() + wkPrimeSettingWork.GoodsMGroup.ToString() +
                            wkPrimeSettingWork.TbsPartsCode.ToString() + wkPrimeSettingWork.PrmSetDtlNo1.ToString() + wkPrimeSettingWork.PrmSetDtlNo2.ToString();

                        if (!offerPrmDic.ContainsKey(offerPrmKey))
                        {
                            offerPrmDic.Add(offerPrmKey, wkPrimeSettingWork);
                        }
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        //----- ADD 2015/03/16 ���V�� Redmine#44209 �D�ǐݒ�}�X�^�ϊ��̎d�l�ύX�̑Ή�------<<<<<

        #region �ݏo�ϊ�����
        /// <summary>
        /// �ݏo�ϊ�����
        /// </summary>
        /// <param name="goodsChangeResultWork">���ʃ��[�N</param>
        /// <param name="cndtn">�������[�N</param>
        /// <param name="path">�p�[�X</param>
        /// <returns>status</returns>
        /// <remarks>
        /// <br>Note	   : �ݏo�ϊ��������s��</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// <br>UpdateNote : 2015/02/25 �c���� </br>
        /// <br>           : Redmine#44209 �t�@�C�������̑Ή�</br>
        /// <br>UpdateNote : 2015/02/26 ���V�� </br>
        /// <br>           : Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�</br>
        /// </remarks>
        private int ChgShipmentPrc(ref GoodsChangeResultWork goodsChangeResultWork, GoodsChangeAllCndWorkWork cndtn, string path)
        {
            object sucObjectList;
            object errObjectList;
            int loadCntShipment = 0;
            int errCntShipment = 0;

            ArrayList errDataList = new ArrayList();
            DataTable errDataTable = new DataTable();
            ArrayList sucDataList = new ArrayList();
            DataTable sucDataTable = new DataTable();
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int shipmentStatusErrCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int shipmentStatusSucCSV = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            //----- DEL 2015/02/25 �c���� Redmine#44209 ----->>>>>
            //string errorLogFileName = Path.Combine(@path, "RentData_error.csv");
            //string successLogFileName = Path.Combine(@path, "RentData_Log.csv");
            //----- DEL 2015/02/25 �c���� Redmine#44209 -----<<<<<
            //----- ADD 2015/02/25 �c���� Redmine#44209 ----->>>>>
            string errorLogFileName = Path.Combine(@path, ct_RENTDATA_ERROR);
            string successLogFileName = Path.Combine(@path, ct_RENTDATA_LOG);
            //----- ADD 2015/02/25 �c���� Redmine#44209 -----<<<<<

            int readCount = 0;

            //�ݏo�f�[�^�ϊ�����
            status = this._iMeijiGoodsChgAllDB.ShipmentChange(cndtn, out sucObjectList, out errObjectList, out readCount);

            ShipmentPrcCompare shipmentPrcCompare = new ShipmentPrcCompare(); // ADD 2015/03/02 ���V�� ���O�o�͏��̃\�b�g�����̑Ή�
            // �G���[���Olist
            errDataList = errObjectList as ArrayList;
            // �X�V���Olist
            sucDataList = sucObjectList as ArrayList;

            // �G���[���O
            if (errDataList != null && errDataList.Count > 0)
            {
                errDataList.Sort(shipmentPrcCompare); // ADD 2015/03/02 ���V�� ���O�o�͏��̃\�b�g�����̑Ή�
                errCntShipment = errDataList.Count;
                //CreatTableShipment(ref errDataTable); // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                CreatTableShipment(ref errDataTable, ERRLOGMODE); // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                ConverToDataSetShipment(errDataList, ref errDataTable);
            }
            if (errDataTable.Rows.Count > 0)
            {
                shipmentStatusErrCSV = this.DoCSVOutPrc(SHIPMENTERRMODE, LOGKINGERR, errDataTable, errorLogFileName, ref goodsChangeResultWork);
            }

            // �X�V�������O
            if (sucDataList != null && sucDataList.Count > 0)
            {
                loadCntShipment = sucDataList.Count;
                sucDataList.Sort(shipmentPrcCompare); // ADD 2015/03/02 ���V�� ���O�o�͏��̃\�b�g�����̑Ή�
                //CreatTableShipment(ref sucDataTable); // DEL 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                CreatTableShipment(ref sucDataTable, SUCLOGMODE); // ADD 2015/02/26 ���V�� Redmine#44209 NO.33 �t�@�C���̐擪�Ƀw�b�_�Ƃ��č��ږ����o�͂���Ή�
                ConverToDataSetShipment(sucDataList, ref sucDataTable);
            }
            if (sucDataTable.Rows.Count > 0)
            {
                shipmentStatusSucCSV = this.DoCSVOutPrc(SHIPMENTSUCMODE, LOGKINGSUC, sucDataTable, successLogFileName, ref goodsChangeResultWork);
            }

            goodsChangeResultWork.ReadCntShipment = readCount;
            goodsChangeResultWork.LoadCntShipment = loadCntShipment;
            goodsChangeResultWork.ErrCntShipment = errCntShipment;
            goodsChangeResultWork.SetStatusErrCSV = shipmentStatusErrCSV;

            return status;
        }
        #endregion

        #endregion

        #endregion �� Private Method
    }

    #region ���@IComparer�@�N���X
    //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
    ///// <summary>���i�}�X�^���O�o�͏���r�N���X</summary>
    ///// <remarks>
    ///// <br>Note       : ���i�}�X�^���O�o�͏��̔�r���s���܂��B</br>
    ///// <br>Programmer : �i�N</br>
    ///// <br>Date       : 2015/01/26</br>
    ///// </remarks>
    //public class PricePrcCompare : IComparer
    //{
    //    #region IComparer �����o

    //    /// <summary>��r�p���\�b�h</summary>
    //    /// <param name="a">��r�ΏۃI�u�W�F�N�g</param>
    //    /// <param name="b">��r�ΏۃI�u�W�F�N�g</param>
    //    /// <returns>��r����(a �� b : 0���傫������, a �� b : 0��菬��������, a �� b : 0)</returns>
    //    /// <remarks>
    //    /// <br>Note       : ���i�}�X�^���O�o�͏��̔�r���s���܂��B</br>
    //    /// <br>Programmer : �i�N</br>
    //    /// <br>Date       : 2015/01/26</br>
    //    /// </remarks>
    //    public int Compare(object a, object b)
    //    {
    //        MeijiGoodsStockWork x = a as MeijiGoodsStockWork;
    //        MeijiGoodsStockWork y = b as MeijiGoodsStockWork;

    //        if (x.GoodsMakerCd > y.GoodsMakerCd)
    //        {
    //            return 1;
    //        }
    //        else if (x.GoodsMakerCd == y.GoodsMakerCd)
    //        {
    //            if (string.CompareOrdinal(x.OldGoodsNo.Trim(), y.OldGoodsNo.Trim()) > 0)
    //            {
    //                return 1;
    //            }
    //            else if (string.CompareOrdinal(x.OldGoodsNo.Trim(), y.OldGoodsNo.Trim()) == 0)
    //            {
    //                if (DateTime.Compare(x.PriceStartDate, y.PriceStartDate) > 0)
    //                {
    //                    return 1;
    //                }
    //                else if (DateTime.Compare(x.PriceStartDate, y.PriceStartDate) == 0)
    //                {
    //                    return 0;
    //                }
    //                else
    //                {
    //                    return -1;
    //                }
    //            }
    //            else
    //            {
    //                return -1;
    //            }
    //        }
    //        else
    //        {
    //            return -1;
    //        }
    //    }

    //    #endregion
    //}

    ///// <summary>�݌Ƀ}�X�^���O�o�͏���r�N���X</summary>
    ///// <remarks>
    ///// <br>Note       : �݌Ƀ}�X�^���O�o�͏��̔�r���s���܂��B</br>
    ///// <br>Programmer : �i�N</br>
    ///// <br>Date       : 2015/01/26</br>
    ///// </remarks>
    //public class StockPrcCompare : IComparer
    //{
    //    #region IComparer �����o

    //    /// <summary>��r�p���\�b�h</summary>
    //    /// <param name="a">��r�ΏۃI�u�W�F�N�g</param>
    //    /// <param name="b">��r�ΏۃI�u�W�F�N�g</param>
    //    /// <returns>��r����(a �� b : 0���傫������, a �� b : 0��菬��������, a �� b : 0)</returns>
    //    /// <remarks>
    //    /// <br>Note       : �݌Ƀ}�X�^���O�o�͏��̔�r���s���܂��B</br>
    //    /// <br>Programmer : �i�N</br>
    //    /// <br>Date       : 2015/01/26</br>
    //    /// </remarks>
    //    public int Compare(object a, object b)
    //    {
    //        MeijiGoodsStockWork x = a as MeijiGoodsStockWork;
    //        MeijiGoodsStockWork y = b as MeijiGoodsStockWork;

    //        int c = 0;
    //        int d = 0;
    //        int wareHouseCodex = 0;
    //        int wareHouseCodey = 0;

    //        if (Int32.TryParse(x.WareCode, out c) && Int32.TryParse(y.WareCode, out d))
    //        {
    //            wareHouseCodex = Convert.ToInt32(x.WareCode);
    //            wareHouseCodey = Convert.ToInt32(y.WareCode);
    //        }

    //        if (x.GoodsMakerCd > y.GoodsMakerCd)
    //        {
    //            return 1;
    //        }
    //        else if (x.GoodsMakerCd == y.GoodsMakerCd)
    //        {
    //            if (string.CompareOrdinal(x.OldGoodsNo.Trim(), y.OldGoodsNo.Trim()) > 0)
    //            {
    //                return 1;
    //            }
    //            else if (string.CompareOrdinal(x.OldGoodsNo.Trim(), y.OldGoodsNo.Trim()) == 0)
    //            {
    //                if (wareHouseCodex > wareHouseCodey)
    //                {
    //                    return 1;
    //                }
    //                else if (wareHouseCodex == wareHouseCodey)
    //                {
    //                    return 0;
    //                }
    //                else
    //                {
    //                    return -1;
    //                }
    //            }
    //            else
    //            {
    //                return -1;
    //            }
    //        }
    //        else
    //        {
    //            return -1;
    //        }
    //    }

    //    #endregion
    //}
    //----- DEL 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<

    //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------>>>>>
    /// <summary>���i�݌Ƀ}�X�^���O�o�͏���r�N���X</summary>
    /// <remarks>
    /// <br>Note       : ���i�݌Ƀ}�X�^���O�o�͏��̔�r���s���܂��B</br>
    /// <br>Programmer : ���V��</br>
    /// <br>Date       : 2015/03/02</br>
    /// </remarks>
    public class GoodsStockPrcCompare : IComparer
    {
        #region IComparer �����o

        /// <summary>��r�p���\�b�h</summary>
        /// <param name="a">��r�ΏۃI�u�W�F�N�g</param>
        /// <param name="b">��r�ΏۃI�u�W�F�N�g</param>
        /// <returns>��r����(a �� b : 0���傫������, a �� b : 0��菬��������, a �� b : 0)</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^���O�o�͏��̔�r���s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        public int Compare(object a, object b)
        {
            MeijiGoodsStockWork x = a as MeijiGoodsStockWork;
            MeijiGoodsStockWork y = b as MeijiGoodsStockWork;

            if (x.GoodsMakerCd > y.GoodsMakerCd)
            {
                return 1;
            }
            else if (x.GoodsMakerCd == y.GoodsMakerCd)
            {
                if (string.CompareOrdinal(x.OldGoodsNo.Trim(), y.OldGoodsNo.Trim()) > 0)
                {
                    return 1;
                }
                else if (string.CompareOrdinal(x.OldGoodsNo.Trim(), y.OldGoodsNo.Trim()) == 0)
                {
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }

        #endregion
    }
    //----- ADD 2015/03/02 ���V�� Redmine#44209 �u�d�l�ύX�v���i�}�X�^�A�݌Ƀ}�X�^�A���i�}�X�^�̃��O���P�ɏW�񂵂ďo�͂���Ή�------<<<<<

    // --- ADD 2015/03/02 ���V�� ���O�o�͏��̃\�b�g�����̑Ή� ----->>>>>
    /// <summary>�ݏo�f�[�^�ϊ��������O�o�͏���r�N���X</summary>
    /// <remarks>
    /// <br>Note       : �ݏo�f�[�^�ϊ��������O�o�͏��̔�r���s���܂��B</br>
    /// <br>Programmer : �i�N</br>
    /// <br>Date       : 2015/03/02</br>
    /// </remarks>
    public class ShipmentPrcCompare : IComparer
    {
        #region IComparer �����o

        /// <summary>��r�p���\�b�h</summary>
        /// <param name="a">��r�ΏۃI�u�W�F�N�g</param>
        /// <param name="b">��r�ΏۃI�u�W�F�N�g</param>
        /// <returns>��r����(a �� b : 0���傫������, a �� b : 0��菬��������, a �� b : 0)</returns>
        /// <remarks>
        /// <br>Note       : �ݏo�f�[�^�ϊ��������O�o�͏��̔�r���s���܂��B</br>
        /// <br>Programmer : �i�N</br>
        /// <br>Date       : 2015/01/26</br>
        /// </remarks>
        public int Compare(object a, object b)
        {
            ShipmentChangeWork x = a as ShipmentChangeWork;
            ShipmentChangeWork y = b as ShipmentChangeWork;

            int c = 0;
            int d = 0;
            int salesSlipNox = 0;
            int salesSlipNoy = 0;

            if (Int32.TryParse(x.SalesSlipNum, out c) && Int32.TryParse(y.SalesSlipNum, out d))
            {
                salesSlipNox = c;
                salesSlipNoy = d;
            }

            if (salesSlipNox > salesSlipNoy)
            {
                return 1;
            }
            else if (salesSlipNox == salesSlipNoy)
            {
                if (x.SalesRowNo > y.SalesRowNo)
                {
                    return 1;
                }
                else if (x.SalesRowNo == y.SalesRowNo)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }
        #endregion
    }
    // --- ADD 2015/03/02 ���V�� ���O�o�͏��̃\�b�g�����̑Ή� -----<<<<<
    #endregion
}
